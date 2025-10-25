using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SweaterPlanning.Models;
using SweaterPlanning.SecureDataClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SweaterPlanning.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class InitialPlanningController : Controller
    {
        private readonly CodeDbSet _context;
        private InitialPlanningDAL _aDal = new InitialPlanningDAL();
        public InitialPlanningController(CodeDbSet context)
        {

            _context = context;
        }
       

        [HttpGet]
        [Route("[action]")]
        public dynamic InitialPlanningList(int yearId)
        {

            var result = _aDal.GetInitialPlanningList(yearId);
            return result;
        }
        [HttpGet]
        [Route("[action]/{startDate:DateTime}/{endDate:DateTime}/{year:int}/{leadTime:int}")]
        public dynamic GetWorkableMuniteFCalCuMcn(DateTime startDate, DateTime endDate,int year, int leadTime)
        {

            var result = _aDal.GetWorkableMuniteFCalCuMcn(year,leadTime,startDate,endDate);
            return result;
        }

        [HttpPost]
        [Route("[action]")]
        public bool SaveSlot(PlanningSlotMaster entity)
        {
            bool result;
            var user = Convert.ToInt32(HttpContext.Session.GetString(SessionCollection.UserId));
            entity.CreateBy = user;
            entity.CreateDate = DateTime.Now;
            if (user == 0){
                result = false;
                return result;
            }
            else
            {
               result = _aDal.SaveSlotAndDetails(entity);
                return result;
            }
        }

    }
}
