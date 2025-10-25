using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SweaterPlanning.Models;
using SweaterPlanning.SecureDataClass;

namespace SweaterPlanning.Controllers
{
    public class CapacityAllocatesController : Controller
    {
        private readonly CodeDbSet _context;

        public CapacityAllocatesController(CodeDbSet context)
        {
            _context = context;
        }

        // GET: CapacityAllocates
        public async Task<IActionResult> Index()
        {
            var codeDbSet = _context.CapacityAllocates.Include(c => c.Buyer).Include(c => c.Gauge).Include(c => c.Marchant).Include(c => c.Months).Include(c => c.Years);
            return View(await codeDbSet.ToListAsync());
        }

        // GET: CapacityAllocates/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var capacityAllocate = await _context.CapacityAllocates
                .Include(c => c.Buyer)
                .Include(c => c.Gauge)
                .Include(c => c.Marchant)
                .Include(c => c.Months)
                .Include(c => c.Years)
                .FirstOrDefaultAsync(m => m.CapacityAllocateId == id);
            if (capacityAllocate == null)
            {
                return NotFound();
            }

            return View(capacityAllocate);
        }

        // GET: CapacityAllocates/Create
        public IActionResult Create()
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString(SessionCollection.UserName)))
            {
                var buyers = _context.Buyers.FromSqlRaw("GetBuyerList_sp").ToList();
                var merchant = _context.Marchants.FromSqlRaw("GetMerchantList_sp").ToList();
                var gauges = _context.Gauges.FromSqlRaw("GetGaugeForCapacityAllocate_sp").ToList();
                ViewData["BuyerId"] = new SelectList(buyers, "BuyerId", "BuyerName");
                //ViewData["GaugeId"] = new SelectList(gauges, "GaugeId", "GaugeName");
                ViewData["MarchantId"] = new SelectList(merchant, "MarchantId", "MarchantName");
                ViewData["MonthId"] = new SelectList(_context.Months, "MonthId", "MonthNames");
                ViewData["YearId"] = new SelectList(_context.Years, "YearId", "YearName");
                ViewData["GaugeGroupId"] = new SelectList(_context.gaugeGroups, "GaugeGroupId", "GaugeGroupName");
                return View();
            }
            else
            {
                return RedirectToAction(nameof(UserInfoesController.Create), "UserInfoes");
            }
        }

        // POST: CapacityAllocates/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CapacityAllocateId,MarchantId,BuyerId,YearId,MonthId,GaugeGroupId,AllocateQty")] CapacityAllocate capacityAllocate)
        {
            if (ModelState.IsValid)
            {
                capacityAllocate.CreateBy = Convert.ToInt32(HttpContext.Session.GetString(SessionCollection.UserId));
                capacityAllocate.CreateDate = DateTime.Now;
                _context.Add(capacityAllocate);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Create));
            }
            ViewData["BuyerId"] = new SelectList(_context.Buyers, "BuyerId", "BuyerId", capacityAllocate.BuyerId);
            //ViewData["GaugeId"] = new SelectList(_context.Gauges, "GaugeId", "GaugeId", capacityAllocate.GaugeId);
            ViewData["GaugeGroupId"] = new SelectList(_context.gaugeGroups, "GaugeGroupId", "GaugeGroupId", capacityAllocate.GaugeGroupId);
            ViewData["MarchantId"] = new SelectList(_context.Marchants, "MarchantId", "MarchantId", capacityAllocate.MarchantId);
            ViewData["MonthId"] = new SelectList(_context.Months, "MonthId", "MonthId", capacityAllocate.MonthId);
            ViewData["YearId"] = new SelectList(_context.Years, "YearId", "YearId", capacityAllocate.YearId);
            return View(capacityAllocate);
        }

        // GET: CapacityAllocates/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var capacityAllocate = await _context.CapacityAllocates.FindAsync(id);
            if (capacityAllocate == null)
            {
                return NotFound();
            }
            ViewData["BuyerId"] = new SelectList(_context.Buyers, "BuyerId", "BuyerId", capacityAllocate.BuyerId);
            //ViewData["GaugeId"] = new SelectList(_context.Gauges, "GaugeId", "GaugeId", capacityAllocate.GaugeId);
            ViewData["GaugeGroupId"] = new SelectList(_context.Gauges, "GaugeGroupId", "GaugeGroupId", capacityAllocate.GaugeGroupId);
            ViewData["MarchantId"] = new SelectList(_context.Marchants, "MarchantId", "MarchantId", capacityAllocate.MarchantId);
            ViewData["MonthId"] = new SelectList(_context.Months, "MonthId", "MonthId", capacityAllocate.MonthId);
            ViewData["YearId"] = new SelectList(_context.Years, "YearId", "YearId", capacityAllocate.YearId);
            return View(capacityAllocate);
        }

        // POST: CapacityAllocates/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CapacityAllocateId,MarchantId,BuyerId,YearId,MonthId,GaugeGroupId,AllocateQty")] CapacityAllocate capacityAllocate)
        {
            if (id != capacityAllocate.CapacityAllocateId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(capacityAllocate);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CapacityAllocateExists(capacityAllocate.CapacityAllocateId))
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
            ViewData["BuyerId"] = new SelectList(_context.Buyers, "BuyerId", "BuyerId", capacityAllocate.BuyerId);
            //ViewData["GaugeId"] = new SelectList(_context.Gauges, "GaugeId", "GaugeId", capacityAllocate.GaugeId);
            ViewData["GaugeGroupId"] = new SelectList(_context.Gauges, "GaugeGroupId", "GaugeGroupId", capacityAllocate.GaugeGroupId);
            ViewData["MarchantId"] = new SelectList(_context.Marchants, "MarchantId", "MarchantId", capacityAllocate.MarchantId);
            ViewData["MonthId"] = new SelectList(_context.Months, "MonthId", "MonthId", capacityAllocate.MonthId);
            ViewData["YearId"] = new SelectList(_context.Years, "YearId", "YearId", capacityAllocate.YearId);
            return View(capacityAllocate);
        }

        // GET: CapacityAllocates/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var capacityAllocate = await _context.CapacityAllocates
                .Include(c => c.Buyer)
                .Include(c => c.Gauge)
                .Include(c => c.Marchant)
                .Include(c => c.Months)
                .Include(c => c.Years)
                .FirstOrDefaultAsync(m => m.CapacityAllocateId == id);
            if (capacityAllocate == null)
            {
                return NotFound();
            }

            return View(capacityAllocate);
        }

        // POST: CapacityAllocates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var capacityAllocate = await _context.CapacityAllocates.FindAsync(id);
            _context.CapacityAllocates.Remove(capacityAllocate);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CapacityAllocateExists(int id)
        {
            return _context.CapacityAllocates.Any(e => e.CapacityAllocateId == id);
        }
        [HttpGet]
        //[ValidateAntiForgeryToken]
        public dynamic EditAllocationQty(int allocationId,int allocationQty)
        {
                try
                {
                CapacityAllocationDAL _aDal = new CapacityAllocationDAL();
                var CreateBy = Convert.ToInt32(HttpContext.Session.GetString(SessionCollection.UserId));
               var result= _aDal.SubmitEditAllocateData(allocationId,allocationQty,CreateBy);
                return result;
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CapacityAllocateExists(allocationId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
        }

    }
}
