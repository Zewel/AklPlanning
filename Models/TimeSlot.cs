using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SweaterPlanning.Models
{
    public class TimeSlot
    {
        [Key]
        public int TimeSlotId { get; set; }

        public string FromTime { get; set; }

        public string ToTime { get; set; }
    }
}
