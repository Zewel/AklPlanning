using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SweaterPlanning.Models
{
    [Table("GaugeGroup")]
    public class GaugeGroup
    {
        [Key]
        public int GaugeGroupId { get; set; }
        public string GaugeGroupName { get; set; }
        public bool IsActive { get; set; }
    }
}
