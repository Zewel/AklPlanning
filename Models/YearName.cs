using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SweaterPlanning.Models
{
    [Table("YearName")]
    public class Years
    {
        [Key]
        public int YearId { get; set; }

        public string YearName { get; set; }
        public bool CurrentYear { get; set; }

        public virtual MonthWiseWorkingDay MonthWiseWorkingDay { get; set; }
    }
}