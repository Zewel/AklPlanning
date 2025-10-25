using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SweaterPlanning.Models
{
    [Table("Factory")]
    public class Factory
    {
        [Key]
        public int FactoryId { get; set; }

        public string FactoryCode { get; set; }

        public string FactoryName { get; set; }

        public string FactoryLocation { get; set; }

        public bool IsActive { get; set; }
    }
}
