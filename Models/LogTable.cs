using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SweaterPlanning.Models
{
    [Table("LogTable")]
    public class LogTable
    {
        [Key]
        public long LogId { get; set; }
        public string TableName { get; set; }
        public string TableData { get; set; }
        public int CreateBy { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
