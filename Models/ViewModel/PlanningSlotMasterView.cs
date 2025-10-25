using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SweaterPlanning.Models.ViewModel
{
    public class PlanningSlotMasterView
    {
        public long PlaneSlotMasterId { get; set; }
        public int YearId { get; set; }
        public string YearName { get; set; }
        public int FactoryId { get; set; }
        public string ShortForm { get; set; }
        public int BrandId { get; set; }
        public string McnType { get; set; }
        public int GaugeId { get; set; }
        public string GaugeDesc { get; set; }
        public int LeadTime { get; set; }
        public int NoOfMachine { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string StageName { get; set; }
        public List<PlanningSlotDetailsView> SlotDetailsViews { get; set; }
    }
}
