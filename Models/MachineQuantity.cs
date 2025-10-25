using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SweaterPlanning.Models
{
    [Table("MachineQuantity")]
    public class MachineQuantity
    {
        [Key]
        public int MachineId { get; set; }
        [ForeignKey("Years")]
        public int YearId { get; set; }
        public virtual Years Years { get; set; }
        [ForeignKey("Factory")]
        public int FactoryId { get; set; }
        public virtual Factory Factory { get; set; }
        [ForeignKey("MachineBrand")]
        public int BrandId { get; set; }
        
        public virtual MachineBrand MachineBrand { get; set; }
        [ForeignKey("Gauge")]
        public int GaugeId { get; set; }

        public virtual Gauge Gauge { get; set; }
        [ForeignKey("GaugeGroup")]
        public int GaugeGroupId { get; set; }

        public virtual GaugeGroup GaugeGroup { get; set; }

        public int NoOfMachine { get; set; }
        //[NotMapped]
        public int? CreateBy { get; set; }
        //[NotMapped]
        public DateTime? CreateDate { get; set; }
        //[NotMapped]
        public int? UpdateBy { get; set; }
        //[NotMapped]
        public DateTime? UpdateDate { get; set; }
    }
}
