using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SweaterPlanning.Models.ViewModel
{
    public class YearlyCapacityProjectionList
    {
        [Key]
        public int CapacityProjectionId { get; set; }

        public string Factory { get; set; }

        public string Brand { get; set; }

        public string Gauge { get; set; }

        public string Year { get; set; }

        public string MonthName { get; set; }

        public int? DayNo { get; set; }

        public int? TotalMinutes { get; set; }

        public decimal? AvgKnittingTime { get; set; }
        public int? TolaranceTiming { get; set; }

        public int? NoOfMachine { get; set; }

        public int? TotalProductionQty { get; set; }
    }
}
