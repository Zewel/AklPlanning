using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SweaterPlanning.Models
{
    public class DailyActivityByTimeSlot
    {
        [Key]
        public int DailyActivityId { get; set; }

        public DateTime ActivityDate { get; set; }

        public int TimeSlotId { get; set; }

        public int? TaskTypeId { get; set; }

        public string TaskDescription { get; set; }

        public int UserId { get; set; }

        public DateTime CreateDate { get; set; }

        public int? UpdateBy { get; set; }

        public DateTime? UpdateDate { get; set; }
        public bool IsComplete { get; set; }
    }
}
