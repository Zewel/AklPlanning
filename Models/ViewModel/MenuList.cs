using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SweaterPlanning.Models.ViewModel
{
    public class MenuList
    {
        public int MenuId { get; set; }
        public string MenuName { get; set; }
        public string ControllerName { get; set; }
        public string ActionName { get; set; }
        public string Parent { get; set; }
        public bool IsPage { get; set; }
        public bool IsMVC { get; set; }
        public string MenuStepName { get; set; }
        public string MenuTypeName { get; set; }
        public bool IsActive { get; set; }
    }
}
