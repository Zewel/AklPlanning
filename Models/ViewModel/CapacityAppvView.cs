using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SweaterPlanning.Models.ViewModel
{
    public class CapacityAppvView
    {
        public int StlCode { get; set; }
        public string StlDesc { get; set; }
        public int StlQty { get; set; }
        public decimal FobAmnt { get; set; }
        public string StlDescrptn { get; set; }
        public string Stag { get; set; }
        public string BurName { get; set; }
        public string TeamName { get; set; }
        public string GmtDept { get; set; }
        public string Fullname { get; set; }
        public string SeasonName { get; set; }
        public string GaugeDesc { get; set; }
        public string DelvendFormatted { get; set; }
        public string DelvstrtFormatted { get; set; }
        public string ConfDtFormatted { get; set; }
        public int stp { get; set; }
        public string ApvSts { get; set; }
        public DateTime IEdt { get; set; }
        public string ApvStsDtl { get; set; }
        public int Age { get; set; }
    }
}
