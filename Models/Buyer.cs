using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SweaterPlanning.Models
{
    [Table("Buyer")]
    public class Buyer
    {
        [Key]
        public int BuyerId { get; set; }

        public string BuyerName { get; set; }
    }
}
