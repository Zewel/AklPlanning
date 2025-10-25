using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SweaterPlanning.Models
{
    [Table("Gauge")]
    public class Gauge
    {
        [Key]
        public int GaugeId { get; set; }

        public string GaugeName { get; set; }
    }
}
