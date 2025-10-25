using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SweaterPlanning.Models
{
    public class GRNSearchParameters
    {
        public string StyleNo { get; set; }
        public string Buyer { get; set; }
        public string TCatagory { get; set; }
        public string TEvent { get; set; }
        public DateTime? GRNDate { get; set; }
    }
}
