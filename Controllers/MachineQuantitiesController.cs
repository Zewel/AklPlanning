using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SweaterPlanning.Models;

namespace SweaterPlanning.Controllers
{
    public class MachineQuantitiesController : Controller
    {
        private readonly CodeDbSet _context;

        private static MachineQuantity machineData;

        public MachineQuantitiesController(CodeDbSet context)
        {
            _context = context;
        }

        // GET: MachineQuantities
        public async Task<IActionResult> Index()
        {
            var codeDbSet = _context.MachineQuantities.Include(m => m.Factory).Include(m => m.Gauge).Include(m => m.MachineBrand).Include(m => m.Years);
            return View(await codeDbSet.ToListAsync());
        }

        // GET: MachineQuantities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var machineQuantity = await _context.MachineQuantities
                .Include(m => m.Factory)
                .Include(m => m.Gauge)
                .Include(m => m.MachineBrand)
                .Include(m => m.Years)
                .FirstOrDefaultAsync(m => m.MachineId == id);
            if (machineQuantity == null)
            {
                return NotFound();
            }

            return View(machineQuantity);
        }

        // GET: MachineQuantities/Create
        public IActionResult Create()
        {
            var factories = _context.Factories.FromSqlRaw("GetFactory").ToList();
            var brands = _context.MachineBrands.FromSqlRaw("MachineBrand_sp").ToList();
            var gauges = _context.Gauges.FromSqlRaw("GaugeList_sp").ToList();
            ViewData["FactoryId"] = new SelectList(factories, "FactoryId", "FactoryCode");
            ViewData["GaugeId"] = new SelectList(gauges, "GaugeId", "GaugeName");
            ViewData["BrandId"] = new SelectList(brands, "BrandId", "BrandName");
            ViewData["YearId"] = new SelectList(_context.Years, "YearId", "YearName");
            ViewData["GaugeGroupId"] = new SelectList(_context.gaugeGroups, "GaugeGroupId", "GaugeGroupName");
            return View();
        }

        // POST: MachineQuantities/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MachineId,YearId,FactoryId,BrandId,GaugeId,GaugeGroupId,NoOfMachine")] MachineQuantity machineQuantity)
        {
            if (ModelState.IsValid)
            {
                if (_context.MachineQuantities.Any(x => x.YearId == machineQuantity.YearId && x.FactoryId == machineQuantity.FactoryId && x.BrandId == machineQuantity.BrandId
                                                                    && x.GaugeId == machineQuantity.GaugeId && x.GaugeGroupId == machineQuantity.GaugeGroupId))
                {
                    return Json("Data already Exist");
                }
                else
                {
                    var user = Convert.ToInt32(HttpContext.Session.GetString(SessionCollection.UserId));
                    machineQuantity.CreateBy = user;
                    machineQuantity.CreateDate = DateTime.Now;
                    _context.Add(machineQuantity);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Create));
                }
            }
            ViewData["FactoryId"] = new SelectList(_context.Factories, "FactoryId", "FactoryCode", machineQuantity.FactoryId);
            ViewData["GaugeId"] = new SelectList(_context.Gauges, "GaugeId", "GaugeName", machineQuantity.GaugeId);
            ViewData["BrandId"] = new SelectList(_context.MachineBrands, "BrandId", "BrandName", machineQuantity.BrandId);
            ViewData["YearId"] = new SelectList(_context.Years, "YearId", "YearName", machineQuantity.YearId);
            ViewData["GaugeGroupId"] = new SelectList(_context.gaugeGroups, "GaugeGroupId", "GaugeGroupName", machineQuantity.GaugeGroupId);
            return View(machineQuantity);
        }

        // GET: MachineQuantities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var machineQuantity = await _context.MachineQuantities.FindAsync(id);
            machineData = machineQuantity;
            if (machineQuantity == null)
            {
                return NotFound();
            }
            var factories = _context.Factories.FromSqlRaw("GetFactory").ToList();
            var brands = _context.MachineBrands.FromSqlRaw("MachineBrand_sp").ToList();
            var gauges = _context.Gauges.FromSqlRaw("GaugeList_sp").ToList();
            ViewData["FactoryId"] = new SelectList(factories, "FactoryId", "FactoryCode", machineQuantity.FactoryId);
            ViewData["GaugeId"] = new SelectList(gauges, "GaugeId", "GaugeName", machineQuantity.GaugeId);
            ViewData["BrandId"] = new SelectList(brands, "BrandId", "BrandName", machineQuantity.BrandId);
            ViewData["YearId"] = new SelectList(_context.Years, "YearId", "YearName", machineQuantity.YearId);
            ViewData["GaugeGroupId"] = new SelectList(_context.gaugeGroups, "GaugeGroupId", "GaugeGroupName", machineQuantity.GaugeGroupId);
            return View(machineQuantity);
        }

        // POST: MachineQuantities/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MachineId,YearId,FactoryId,BrandId,GaugeId,GaugeGroupId,NoOfMachine,CreateBy,CreateDate")] MachineQuantity machineQuantity)
        {
            if (id == machineQuantity.MachineId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {

                    var manId = machineQuantity.MachineId;
                    machineQuantity.UpdateBy = Convert.ToInt32(HttpContext.Session.GetString(SessionCollection.UserId));
                    machineQuantity.UpdateDate = DateTime.Now;
                    //LogTable aLogTable = new LogTable();
                    //aLogTable.TableName = "MachineQuantity";
                    //aLogTable.TableData = machineData.MachineId + "," + machineData.YearId + "," + machineData.FactoryId + "," + machineData.BrandId + "," + machineData.GaugeId + "," + machineData.GaugeGroupId + "," + machineData.NoOfMachine;
                    //aLogTable.CreateBy = Convert.ToInt32(HttpContext.Session.GetString(SessionCollection.UserId));
                    //aLogTable.CreateDate = DateTime.Now;
                    //_context.LogTables.Add(aLogTable);
                    _context.MachineQuantities.Update(machineQuantity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MachineQuantityExists(machineQuantity.MachineId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Create));
            }
            ViewData["FactoryId"] = new SelectList(_context.Factories, "FactoryId", "FactoryId", machineQuantity.FactoryId);
            ViewData["GaugeId"] = new SelectList(_context.Gauges, "GaugeId", "GaugeId", machineQuantity.GaugeId);
            ViewData["BrandId"] = new SelectList(_context.MachineBrands, "BrandId", "BrandId", machineQuantity.BrandId);
            ViewData["YearId"] = new SelectList(_context.Years, "YearId", "YearId", machineQuantity.YearId);
            return View(machineQuantity);
        }

        // GET: MachineQuantities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var machineQuantity = await _context.MachineQuantities
                .Include(m => m.Factory)
                .Include(m => m.Gauge)
                .Include(m => m.MachineBrand)
                .Include(m => m.Years)
                .FirstOrDefaultAsync(m => m.MachineId == id);
            if (machineQuantity == null)
            {
                return NotFound();
            }

            return View(machineQuantity);
        }

        // POST: MachineQuantities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var machineQuantity = await _context.MachineQuantities.FindAsync(id);
            _context.MachineQuantities.Remove(machineQuantity);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MachineQuantityExists(int id)
        {
            return _context.MachineQuantities.Any(e => e.MachineId == id);
        }
    }
}
