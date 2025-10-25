using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SweaterPlanning.Models
{
    [Table("CapacityAllocate")]
    public class CapacityAllocate
    {
        [Key]
        public int CapacityAllocateId { get; set; }
        [ForeignKey("Marchant")]
        public int MarchantId { get; set; }
        public virtual Marchant Marchant { get; set; }
        [ForeignKey("Buyer")]
        public int BuyerId { get; set; }

        public virtual Buyer Buyer { get; set; }

        [ForeignKey("Years")]
        public int YearId { get; set; }
        public virtual Years Years { get; set; }
        [ForeignKey("Months")]
        public int MonthId { get; set; }
        
        public virtual Months Months { get; set; }
        //[ForeignKey("Gauge")]
        //public int GaugeId { get; set; }
        [ForeignKey("GaugeGroup")]
        public int GaugeGroupId { get; set; }
        public virtual Gauge Gauge { get; set; }
        public int AllocateQty { get; set; }
        
        public int CreateBy { get; set; }
       
        public DateTime CreateDate { get; set; }
        [NotMapped]
        public int? UpdateBy { get; set; }
        [NotMapped]
        public int? UpdateDate { get; set; }
    }
}
