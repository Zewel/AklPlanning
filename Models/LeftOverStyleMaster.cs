using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SweaterPlanning.Models
{
    public class LeftOverStyleMaster
    {
        public int LeftOverStyleId { get; set; }
        public string SimilarStyleId { get; set; }
        public string LeftOverStyleNo { get; set; }
        public string StyleDesc { get; set; }
        public int? StyleType { get; set; }
        public string YarnDesc { get; set; }
        public int? TotalQty { get; set; }
        public int? CreateBy { get; set; }
        public int? BarndId { get; set; }
        public int? GaugeId { get; set; }
        public int? BuyerId { get; set; }
        
        public DateTime? CreateDate { get; set; }

        public decimal KnttSMV { get; set; }

        public List<LeftOverPoDetails> LeftOverPoDetailsLst { get; set; }
    }
}
