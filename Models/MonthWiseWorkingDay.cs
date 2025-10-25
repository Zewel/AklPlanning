using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SweaterPlanning.Models
{
    [Table("MonthWiseWorkingDay")]
    public class MonthWiseWorkingDay
    {
        [Key]
        public int MonthWiseWorkId { get; set; }
        public virtual Years Years { get; set; }
        [ForeignKey("Years")]
        [Required(ErrorMessage = "Please enter Year")]
        public int YearId { get; set; }

        public virtual Months Months { get; set; }
        [ForeignKey("Months")]
        public int MonthId { get; set; }

        public int DayNo { get; set; }

        public int WorkableMinutes { get; set; }
        public decimal AvgKnittingTime { get; set; }
        
        public int? CreateBy { get; set; }
        public DateTime? CreateDate { get; set; }
        public int? UpdateBy { get; set; }
        public DateTime? UpdateDate { get; set; }


       
    }
}
