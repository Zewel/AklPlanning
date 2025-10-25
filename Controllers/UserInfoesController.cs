using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.NetworkInformation;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SweaterPlanning.Models;
using SweaterPlanning.SecureDataClass;

namespace SweaterPlanning.Controllers
{
    public class UserInfoesController : Controller
    {
        private readonly CodeDbSet _context;
        private LogInDAL _aDAL = new LogInDAL();

        public UserInfoesController(CodeDbSet context)
        {
            _context = context;
        }

        // GET: UserInfoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.UserInfo.ToListAsync());
        }

        // GET: UserInfoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userInfo = await _context.UserInfo
                .FirstOrDefaultAsync(m => m.UserId == id);
            if (userInfo == null)
            {
                return NotFound();
            }

            return View(userInfo);
        }

        // GET: UserInfoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: UserInfoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public dynamic Create([Bind("UserCode,Password")] UserInfo userInfo)
        {
            if (ModelState.IsValid)
            {
               
                try
                {

                    DataTable dt = _aDAL.LogIn(userInfo.UserCode, userInfo.Password);

                    if (dt.Rows.Count > 0)
                    {
                        var macAddress = GetMACAddress();
                        var pcName = System.Environment.MachineName;
                        var net = System.Net.Dns.GetHostName().ToString();
                        

                       



                        HttpContext.Session.SetString(SessionCollection.UserId, dt.Rows[0]["UserId"].ToString());
                        HttpContext.Session.SetString(SessionCollection.UserCode, dt.Rows[0]["UserCode"].ToString());
                        HttpContext.Session.SetString(SessionCollection.UserName, dt.Rows[0]["UserName"].ToString());
                        HttpContext.Session.SetString(SessionCollection.Email, dt.Rows[0]["Email"].ToString());
                        HttpContext.Session.SetString(SessionCollection.DesignationId, dt.Rows[0]["DesignationId"].ToString());
                        HttpContext.Session.SetString(SessionCollection.MACAddress, macAddress);
                        HttpContext.Session.SetString(SessionCollection.PcName, net);
                        HttpContext.Session.SetString(SessionCollection.ModuleId, "1");
                        HttpContext.Session.SetString(SessionCollection.CompanyId, dt.Rows[0]["CompId"].ToString());


                        return   RedirectToAction("Index", "Home"); ;
                    }
                    else
                    {
                        HttpContext.Session.Clear();
                        HttpContext.Session.Remove(SessionCollection.UserCode);
                        HttpContext.Session.Remove(SessionCollection.UserName);
                        HttpContext.Session.Remove(SessionCollection.Email);
                        HttpContext.Session.Remove(SessionCollection.DesignationId);
                        //return false;
                        return RedirectToAction("LogIn", "Create");
                    }
                }
                catch (Exception ex)
                {
                    string exception = ex.ToString();
                    return false;
                }
                finally
                {

                }
            }
            return View(userInfo);
        }

        // GET: UserInfoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userInfo = await _context.UserInfo.FindAsync(id);
            if (userInfo == null)
            {
                return NotFound();
            }
            return View(userInfo);
        }

        // POST: UserInfoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UserId,UserCode,UserName,Email,DesignationId,Password,IsActive")] UserInfo userInfo)
        {
            if (id != userInfo.UserId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userInfo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserInfoExists(userInfo.UserId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(userInfo);
        }

        // GET: UserInfoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userInfo = await _context.UserInfo
                .FirstOrDefaultAsync(m => m.UserId == id);
            if (userInfo == null)
            {
                return NotFound();
            }

            return View(userInfo);
        }

        // POST: UserInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var userInfo = await _context.UserInfo.FindAsync(id);
            _context.UserInfo.Remove(userInfo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserInfoExists(int id)
        {
            return _context.UserInfo.Any(e => e.UserId == id);
        }

        public ActionResult Logout()
        {
           // await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);\
           
            HttpContext.Session.Clear();
            // HttpContext.Session.Abandon();
            return  RedirectToAction("Create", "UserInfoes");
        }


        public static string GetMACAddress()
        {
            //ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_NetworkAdapterConfiguration where IPEnabled=true");
            //IEnumerable<ManagementObject> objects = searcher.Get().Cast<ManagementObject>();
            //string mac = (from o in objects orderby o["IPConnectionMetric"] select o["MACAddress"].ToString()).FirstOrDefault();
            //return mac;


            //ManagementObjectSearcher objMOS = new ManagementObjectSearcher("Win32_NetworkAdapterConfiguration");
            //ManagementObjectCollection objMOC = objMOS.Get();
            //string MACAddress = String.Empty;
            //foreach (ManagementObject objMO in objMOC)
            //{
            //    if (MACAddress == String.Empty) // only return MAC Address from first card   
            //    {
            //        MACAddress = objMO["MacAddress"].ToString();
            //    }
            //    objMO.Dispose();
            //}
            //MACAddress = MACAddress.Replace(":", "");
            //return MACAddress;

            NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
            String sMacAddress = string.Empty;
            foreach (NetworkInterface adapter in nics)
            {
                if (sMacAddress == String.Empty)// only return MAC Address from first card  
                {
                    IPInterfaceProperties properties = adapter.GetIPProperties();
                    sMacAddress = adapter.GetPhysicalAddress().ToString();
                }
            }
            return sMacAddress;
        }
    }
}
