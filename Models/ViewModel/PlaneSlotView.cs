using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SweaterPlanning.Models.ViewModel
{
    public class PlaneSlotView
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
        public DateTime EndDate { get; set; }
        public string StageName { get; set; }
        public long PlanningSlotDetailsId { get; set; }
        public long PlaneMasterId { get; set; }
        public int POCod { get; set; }
        public string PONo { get; set; }
        public int PoQty { get; set; }
        public int stylecode { get; set; }
        public string StyleNumber { get; set; }
        public int SmvKn { get; set; }
        public int RequiredMachine { get; set; }
        public string Remarks { get; set; }
        public string TrialDate { get; set; }
        public string ExftyNew { get; set; }
        public string CriticalTyp { get; set; }
        public int DaybeforeKnitt { get; set; }
        public int KnittQty { get; set; }
        public int FlagStatus { get; set; }
        public int PoSplitId { get; set; }
    }
}
