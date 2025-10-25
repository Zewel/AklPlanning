using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SweaterPlanning.Models
{
    [Table("MonthNames")]
    public class Months
    {
        [Key]
        public int MonthId { get; set; }

        public string MonthNames { get; set; }

        public MonthWiseWorkingDay monthWiseWorkingDays { get; set; }
    }
}
