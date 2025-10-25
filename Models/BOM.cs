using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SweaterPlanning.Models
{
    public class BOM
    {
      public string  Mcat_Desc { get; set; }
      public string  Sbcat_Desc { get; set; }
      public string  UnitName { get; set; }
      public string Color { get; set; }
      public decimal REQUIREDQTY { get; set; }

    }
}
