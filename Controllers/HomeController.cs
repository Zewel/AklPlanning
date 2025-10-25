using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using SweaterPlanning.Models;
using SweaterPlanning.SecureDataClass;
using Microsoft.AspNetCore.Http;

namespace SweaterPlanning.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString(SessionCollection.UserName)))
            {
                var user = HttpContext.Session.GetString(SessionCollection.UserName);
                return View();
            }
            else
            {
                return RedirectToAction(nameof(UserInfoesController.Create), "UserInfoes");
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public ActionResult MenuGeneration()
        {
            try
            {
                HomeDAL homeDal = new HomeDAL();
                return PartialView("~/Views/PartialView/_partialMenuList.cshtml",
                    homeDal.Parent(Convert.ToInt32(HttpContext.Session.GetString(SessionCollection.UserId)), Convert.ToInt32(HttpContext.Session.GetString(SessionCollection.ModuleId)))
                    );
            }
            catch (Exception exception)
            {
                string message = exception.ToString();

                return RedirectToAction("Index", "Home");
            }
        }
    }
}
