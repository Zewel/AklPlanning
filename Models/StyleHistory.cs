using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SweaterPlanning.Models
{
    public class StyleHistory
    {
        public int StyleId { get; set; }
        public int PoId { get; set; }
        public int StatusType { get; set; }
        public string CurrentStatus { get; set; }
        public string MerchantComments { get; set; }
        public DateTime? PlannerProposeDate { get; set; }
        public int FlagId { get; set; }
    }
}
