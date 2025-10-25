using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SweaterPlanning.Models
{
    [Table("MachineBrand")]
    public class MachineBrand
    {
        [Key]
        public int BrandId { get; set; }

        public string BrandName { get; set; }
    }
}
