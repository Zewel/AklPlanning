using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SweaterPlanning.Models
{
    public class InitialTAndA
    {
       public int StlCod { get; set; }
       public DateTime YarnOrderDate { get; set; }
        public DateTime YarnTranDate { get; set; }
        public DateTime ColorAppDate { get; set; }
        public DateTime TestAppDate { get; set; }
        public DateTime BulkHangAppDate { get; set; }
        public DateTime SampleAppDate { get; set; }
        public DateTime YarnInHDate { get; set; }
        public DateTime FileHDate { get; set; }
        public DateTime SiInHDate { get; set; }
        public DateTime PackItemInHDate { get; set; }
        public int YarnPurLeadTime { get; set; }
        public int ProLeadTime { get; set; }


    }
}
