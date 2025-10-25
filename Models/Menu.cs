using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SweaterPlanning.Models
{
    [Table("Menu")]
    public class Menu
    {
        [Key]
        public int MenuId { get; set; }
        public string MenuName { get; set; }
        public bool? IsPage { get; set; }
        public string URL { get; set; }
        public string ControllerName { get; set; }
        public string ActionName { get; set; }
        public int? ParantId { get; set; }
        public bool? IsApprovalPage { get; set; }
        public int? ModuleId { get; set; }
        public bool? IsMVC { get; set; }
        public int? MenuStepId { get; set; }
        public int? MenuTypeId { get; set; }
        public bool? IsActive { get; set; }
        public int? CreateBy { get; set; }
        public DateTime? CreateDate { get; set; }
        public string UpdateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int? MenuSerialNo { get; set; }
        public bool? IsPortalMenu { get; set; }
        public bool? IsInsert { get; set; }
        public bool? IsEdit { get; set; }
        public bool? IsDelete { get; set; }
        public bool? IsView { get; set; }
        public bool? IsApprove { get; set; }
    }
}
