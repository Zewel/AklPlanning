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
    public class MonthWiseWorkingDaysController : Controller
    {
        private readonly CodeDbSet _context;
        private static MonthWiseWorkingDay monthWiseWorkingDayLog;
        public MonthWiseWorkingDaysController(CodeDbSet context)
        {
            _context = context;
        }

        // GET: MonthWiseWorkingDays
        public async Task<IActionResult> Index()
        {
            var codeDbSet = _context.MonthWiseWorkingDay.Include(m => m.Months).Include(m => m.Years);
            return View(await codeDbSet.ToListAsync());
        }

        // GET: MonthWiseWorkingDays/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var monthWiseWorkingDay = await _context.MonthWiseWorkingDay
                .Include(m => m.Months)
                .Include(m => m.Years)
                .FirstOrDefaultAsync(m => m.MonthWiseWorkId == id);
            if (monthWiseWorkingDay == null)
            {
                return NotFound();
            }

            return View(monthWiseWorkingDay);
        }

        // GET: MonthWiseWorkingDays/Create
        public IActionResult Create()
        {
            ViewData["MonthId"] = new SelectList(_context.Months, "MonthId", "MonthNames");
            ViewData["YearId"] = new SelectList(_context.Years.OrderByDescending(x => x.YearId), "YearId", "YearName");
            return View();
        }

        // POST: MonthWiseWorkingDays/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MonthWiseWorkId,YearId,MonthId,DayNo,WorkableMinutes,AvgKnittingTime,CreateBy,CreateDate")] MonthWiseWorkingDay monthWiseWorkingDay)
        {
            if (ModelState.IsValid)
            {
                var data = _context.MonthWiseWorkingDay.Where(x => x.YearId == monthWiseWorkingDay.YearId && x.MonthId == monthWiseWorkingDay.MonthId).ToList();
                if (!data.Any())
                {
                    monthWiseWorkingDay.CreateBy =Convert.ToInt32( HttpContext.Session.GetString(SessionCollection.UserId));
                    monthWiseWorkingDay.CreateDate = DateTime.Now;
                    _context.Add(monthWiseWorkingDay);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Create));
                }

            }
            ViewData["MonthId"] = new SelectList(_context.Months, "MonthId", "MonthId", monthWiseWorkingDay.MonthId);
            ViewData["YearId"] = new SelectList(_context.Years, "YearId", "YearId", monthWiseWorkingDay.YearId);
            return View(monthWiseWorkingDay);
        }

        // GET: MonthWiseWorkingDays/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var monthWiseWorkingDay = await _context.MonthWiseWorkingDay.FindAsync(id);
            monthWiseWorkingDayLog = monthWiseWorkingDay;
            if (monthWiseWorkingDay == null)
            {
                return NotFound();
            }
            ViewData["MonthId"] = new SelectList(_context.Months, "MonthId", "MonthNames", monthWiseWorkingDay.MonthId);
            ViewData["YearId"] = new SelectList(_context.Years, "YearId", "YearName", monthWiseWorkingDay.YearId);
            return View(monthWiseWorkingDay);
        }

        // POST: MonthWiseWorkingDays/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MonthWiseWorkId,YearId,MonthId,DayNo,WorkableMinutes,AvgKnittingTime,CreateBy,CreateDate")] MonthWiseWorkingDay monthWiseWorkingDay)
        {
            if (id == monthWiseWorkingDay.MonthWiseWorkId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    //LogTable logTable= new LogTable();
                    //logTable.TableName = "MonthWiseWorkingDay";
                    //logTable.TableData = monthWiseWorkingDayLog.MonthWiseWorkId + "," + monthWiseWorkingDayLog.YearId + "," + monthWiseWorkingDayLog.MonthId + "," + monthWiseWorkingDayLog.DayNo + "," + monthWiseWorkingDayLog.WorkableMinutes + "," +
                    //                    monthWiseWorkingDayLog.AvgKnittingTime;
                    //logTable.CreateBy = Convert.ToInt32(HttpContext.Session.GetString(SessionCollection.UserId));
                    //logTable.CreateDate = DateTime.Now;
                    //_context.LogTables.Add(logTable);
                    monthWiseWorkingDay.UpdateBy= Convert.ToInt32(HttpContext.Session.GetString(SessionCollection.UserId));
                    monthWiseWorkingDay.UpdateDate= DateTime.Now;
                    _context.Update(monthWiseWorkingDay);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MonthWiseWorkingDayExists(monthWiseWorkingDay.MonthWiseWorkId))
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
            ViewData["MonthId"] = new SelectList(_context.Months, "MonthId", "MonthId", monthWiseWorkingDay.MonthId);
            ViewData["YearId"] = new SelectList(_context.Years, "YearId", "YearId", monthWiseWorkingDay.YearId);
            return View(monthWiseWorkingDay);
        }

        // GET: MonthWiseWorkingDays/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var monthWiseWorkingDay = await _context.MonthWiseWorkingDay
                .Include(m => m.Months)
                .Include(m => m.Years)
                .FirstOrDefaultAsync(m => m.MonthWiseWorkId == id);
            if (monthWiseWorkingDay == null)
            {
                return NotFound();
            }

            return View(monthWiseWorkingDay);
        }

        // POST: MonthWiseWorkingDays/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var monthWiseWorkingDay = await _context.MonthWiseWorkingDay.FindAsync(id);
            _context.MonthWiseWorkingDay.Remove(monthWiseWorkingDay);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MonthWiseWorkingDayExists(int id)
        {
            return _context.MonthWiseWorkingDay.Any(e => e.MonthWiseWorkId == id);
        }
    }
}
