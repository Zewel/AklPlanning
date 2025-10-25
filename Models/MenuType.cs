using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SweaterPlanning.Models
{
    [Table("MenuType")]
    public class MenuType
    {
        [Key]
        public int MenuTypeId { get; set; }
        public string MenuTypeName { get; set; }

    }
}
