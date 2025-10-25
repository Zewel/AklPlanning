using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SweaterPlanning.Models
{
    public class StyleApproval
    {
        public int StlCod { get; set; }
        public int CoOrdinatior { get; set; }
        public int RatioType { get; set; }
        public DateTime KnStartDate { get; set; }
        public DateTime? LnStartDate { get; set; }
        public DateTime? FnStartDate { get; set; }
        public DateTime? InsStartDate { get; set; }
        public string Remarks { get; set; }
        public string DenyReason { get; set; }
        public string BooknigOption { get; set; }

        public List<PoApproval> PoApprovals { get; set; }
    }
}
