using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SweaterPlanning.Models
{
    public class PlanningSlotMaster
    {
        [Key]
        public long PlaneSlotMasterId { get; set; }
        public int YearId { get; set; }
        public int FactoryId { get; set; }
        public int BrandId { get; set; }
        public int GaugeId { get; set; }
        public int LeadTime { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int? StageId { get; set; }
        public int NoOfMachine { get; set; }
        public int CreateBy { get; set; }
        public DateTime CreateDate { get; set; }
        public int? UpdateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public bool? IsEdit { get; set; }
        public bool? IsApproved { get; set; }
        public int? ApproveBy { get; set; }
        public DateTime? ApprovedDate { get; set; }

        public List<PlanningSlotDetails> PlanningSlotDetails { get; set; }
    }
}
