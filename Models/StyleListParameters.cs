using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SweaterPlanning.Models
{
    public class StyleListParameters
    {
        public string PoNo { get; set; }
        public string StyleNo { get; set; }
        public string Buyer { get; set; }
        public string Marchant { get; set; }
        public string TeamHead { get; set; }
        public string OrderFromDate { get; set; }
        public string OrderToDate { get; set; }
        public string DeliveryFromDate { get; set; }
        public string DeliveryToDate { get; set; }
        public string PlanFromDate { get; set; }
        public string PlanToDate { get; set; }
    }
}
