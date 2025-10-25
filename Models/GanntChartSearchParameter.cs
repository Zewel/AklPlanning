using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SweaterPlanning.Models
{
    public class GanntChartSearchParameter
    {
        public DateTime? PlanFromDate { get; set; }
        public DateTime? PlanToDate { get; set; }
        public int? FactoryId { get; set; }
        public string StyleNumber { get; set; }
    }
}
