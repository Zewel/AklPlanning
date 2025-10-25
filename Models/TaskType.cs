using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SweaterPlanning.Models
{
    [Table("TaskType")]
    public class TaskType
    {
        [Key]
        public int TaskTypeId { get; set; }
        public string TastTypeName { get; set; }
        [NotMapped]
        public string CreateBy { get; set; }
        [NotMapped]
        public DateTime CreateDate { get; set; }
        [NotMapped]
        public string UpdateBy { get; set; }
        [NotMapped]
        public DateTime UpdateDate { get; set; }
    }
}
