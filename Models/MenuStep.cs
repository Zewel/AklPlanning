using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SweaterPlanning.Models
{
    [Table("MenuStep")]
    public class MenuStep
    {
        [Key]
        public int MenuStepId { get; set; }
        public string MenuStepName { get; set; }
    }
}
