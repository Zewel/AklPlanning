using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SweaterPlanning.Models
{
    [Table("YearlyCapacityProjection")]
    public class YearlyCapacityProjection
    {
        [Key]
        //public int CapacityProjectionId { get; set; }

        //public string Factory { get; set; }

        //public string Brand { get; set; }

        //public string Gauge { get; set; }

        //public int YearId { get; set; }
        //public string Year { get; set; }

        //public string MonthName { get; set; }

        //public int? DayNo { get; set; }

        //public int? TotalMinutes { get; set; }

        //public int? AvgKnittingTime { get; set; }

        //public int? NoOfMachine { get; set; }

        //public int? TotalProductionQty { get; set; }

        //public int? CreateBy { get; set; }

        //public DateTime? CreateDate { get; set; }
        public int CapacityProjectionId { get; set; }
        public int FactoryId { get; set; }
        public int BrandId { get; set; }
        public int GaugeId { get; set; }
        public int YearId { get; set; }
        public int MonthId { get; set; }
        public int DayNo { get; set; }
        public int TotalMinutes { get; set; }
        public int AvgKnittingTime { get; set; }
        public int TolaranceTiming { get; set; }
        public int NoOfMachine { get; set; }
        public int TotalProductionQty { get; set; }
        public int? CreateBy { get; set; }
        public DateTime? CreateDate { get; set; }
    }
}
