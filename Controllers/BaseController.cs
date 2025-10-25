using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SweaterPlanning.Substructure.UnitOfWork;

namespace SweaterPlanning.Controllers
{
    public class BaseController : ControllerBase
    {
        protected IUnitOfWork Uow { get; set; }
        protected ILogger Logger { get; set; }
    }
}
