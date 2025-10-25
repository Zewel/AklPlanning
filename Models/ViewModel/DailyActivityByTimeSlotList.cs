using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SweaterPlanning.Models.ViewModel
{
    public class DailyActivityByTimeSlotList
    {
        public int DailyActivityId { get; set; }

        public string ActivityDate { get; set; }

        public int TimeSlotId { get; set; }
        public string FromTime { get; set; }
        public string ToTime { get; set; }
        public int? TaskTypeId { get; set; }
        public string TastTypeName { get; set; }
        public string TaskDescription { get; set; }
        public bool IsComplete { get; set; }
    }
}
