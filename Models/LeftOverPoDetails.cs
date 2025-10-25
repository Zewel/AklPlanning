using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SweaterPlanning.Models
{
    public class LeftOverPoDetails
    {
        public int? LeftOverPoId { get; set; }
        public int? LeftOverStyleId { get; set; }
        public string LeftOverPoNo { get; set; }
        public string Color { get; set; }
        public int? PoQty { get; set; }
        public DateTime? InitialPlanDate { get; set; }
        public DateTime? BookingExfty { get; set; }
        public int? CreateBy { get; set; }
        public DateTime? CreateDate { get; set; }
    }
}
