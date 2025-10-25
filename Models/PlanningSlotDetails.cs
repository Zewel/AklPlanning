using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SweaterPlanning.Models
{
    public class PlanningSlotDetails
    {
        [Key]
        public long PlanningSlotDetailsId { get; set; }
        public int PlaneSlotMasterId { get; set; }
        public int POCod { get; set; }
        public int PoQty { get; set; }
        public int SmvKn { get; set; }
        public int RequiredMachine { get; set; }
        public int CreateBy { get; set; }
        public DateTime CreateDate { get; set; }
        public string Remarks { get; set; }
        public int? PreviousQty { get; set; }
        public DateTime? TrialDate { get; set; }
        public bool? IsDelete { get; set; }
        public int? DeleteBy { get; set; }
        public DateTime? DeleteDate { get; set; }
        public bool? IsEdit { get; set; }
        public int? EditBy { get; set; }

        public DateTime? EditDate { get; set; }
        public int? ProductionPerMcn { get; set; }
        public int? PorductionPerDay { get; set; }
        public int? DaybeforeKnitt { get; set; }
        public int? PoSplitId { get; set; }
        public int? KntOperationId { get; set; }

        public int? PoOwnType { get; set; }

    }
}
