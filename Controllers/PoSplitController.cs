using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SweaterPlanning.Models;
using SweaterPlanning.SecureDataClass;
using SweaterPlanning.Substructure.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SweaterPlanning.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class PoSplitController : BaseController
    {
        private readonly CodeDbSet _context;
        private PoSplitDAL _dal = new PoSplitDAL();
        public PoSplitController(IUnitOfWork uow, CodeDbSet context)
        {
            Uow = uow;
            _context = context;
        }

        [HttpPost]
        [Route("[action]")]
        //[ValidateAntiForgeryToken]
        public dynamic AddPoSplit(List<PoApproval> entity)
        {
            var CreateBy = Convert.ToInt32(HttpContext.Session.GetString(SessionCollection.UserId));
            entity.ForEach(c => { c.UserId = CreateBy; c.CreateDate = DateTime.Now; });
            bool result = _dal.SaveAllPoSPlit(entity);
            return result;
        }
    }
}
