using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SweaterPlanning.Models
{
    public class TandASearchParameters
    {
        public string StyleNo { get; set; }
        public string Buyer { get; set; }
        public string TCatagory { get; set; }
        public string TEvent { get; set; }
        public string PlnFromDate { get; set; }
        public string PlnToDate { get; set; }
        public string ExFromDate { get; set; }
        public string ExnToDate { get; set; }
        public string Metarial { get; set; }
    }
}
