using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SweaterPlanning.Models
{
    public class UserOperationPermission
    {
        public long UserPermissionId { get; set; }
        public int UserId { get; set; }
        public int MenuId { get; set; }
        public bool IsInsert { get; set; }
        public bool IsUpdate { get; set; }
        public int CreateBy { get; set; }
        public DateTime CreateDate { get; set; }
        public int? UpdateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
