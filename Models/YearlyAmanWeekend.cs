using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SweaterPlanning.Models
{
    [Table("YearlyAmanWeekend")]
    public class YearlyAmanWeekend
    {
        [Key]
        public int YearlyWorkDay { get; set; }
        public int YearId { get; set; }
        public string WeekendDay { get; set; }
        public bool IsActive { get; set; }
        public int? CreateBy { get; set; }
        public DateTime? CreateDate { get; set; }
        public int? UpdateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
