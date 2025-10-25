using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SweaterPlanning.Models
{
    [Table("DailyActivity")]
    public class DailyActivity
    {
        [Key]
        public int ActivityId { get; set; }

        public string ActivityCode { get; set; }

        public DateTime? ActivityDate { get; set; }

        public DateTime? StartTime { get; set; }

        public DateTime? EndTime { get; set; }

        public int TaskTypeId { get; set; }

        public string TaskDescription { get; set; }

        public int UserId { get; set; }

        public DateTime? CreateDate { get; set; }

        public int? UpdateBy { get; set; }

        public DateTime? UpdateDate { get; set; }

        public bool? IsComplete { get; set; }
        public TaskType TaskType { get; set; }
    }
}
