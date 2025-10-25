using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SweaterPlanning.Models
{
    public class MenuChild
    {
        public int MenuId { get; set; }
        public string MenuName { get; set; }
        public string ControllerName { get; set; }
        public string ActionName { get; set; }
        public List<MenuSubChild> MenuSubChildList { get; set; }
        public string Permission { get; set; }
    }
}
