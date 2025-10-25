using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SweaterPlanning.Models
{
    [Table("Marchant")]
    public class Marchant
    {
        [Key]
        public int MarchantId { get; set; }

        public string MarchantName { get; set; }
    }
}
