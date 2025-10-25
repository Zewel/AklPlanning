using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SweaterPlanning.Models
{
    [Table("UserInfo")]
    public class UserInfo
    {
        [Key]
        public int UserId { get; set; }

        public string UserCode { get; set; }

        public string UserName { get; set; }

        //public string Email { get; set; }

        //public int? DesignationId { get; set; }

        public string Password { get; set; }

        public bool IsActive { get; set; }
    }
}
