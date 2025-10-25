using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SweaterPlanning.Models.ViewModel
{
    public class MonthWiseWorkingDayList
    {
        public int MonthWiseWorkId { get; set; }
        public string YearName { get; set; }
        public string MonthNames { get; set; }
        public int DayNo { get; set; }
        public int WorkableMinutes { get; set; }
        public decimal AvgKnittingTime { get; set; }
        public int TotalWorkableMinute { get; set; }

    }
}
