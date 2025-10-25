using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SweaterPlanning.Models.ViewModel
{
    public class FactoryListView
    {
        public int FactoryId { get; set; }
        public string ShortForm { get; set; }
        public int BrandId { get; set; }
        public string McnType { get; set; }
        public int GaugeId { get; set; }
        public string GaugeDesc { get; set; }
        public long Number { get; set; }
    }
}
