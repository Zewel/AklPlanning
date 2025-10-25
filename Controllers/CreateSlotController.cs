using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SweaterPlanning.Models;
using SweaterPlanning.SecureDataClass;
using SweaterPlanning.Substructure.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace SweaterPlanning.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class CreateSlotController : BaseController
    {
        private readonly CodeDbSet _context;
        private CreateSlotDAL _aDal = new CreateSlotDAL();
        public CreateSlotController(IUnitOfWork uow, CodeDbSet context)
        {
            Uow = uow;
            _context = context;
        }
        [HttpGet]
        [Route("[action]/{yearId:int}/{factoryId:int}/{brandId:int}/{guageId:int}/{leadTime:int}")]
        public dynamic StartDateEndDate(int yearId, int factoryId, int brandId, int guageId, int leadTime)
        {
            DataTable dt = _aDal.StartDateEndDate(yearId, factoryId, brandId, guageId, leadTime);
            return dt;

        }
        [HttpPost]
        [Route("[action]")]
        public bool SaveSlot(PlanningSlotMaster entity)
        {
            var user = Convert.ToInt32(HttpContext.Session.GetString(SessionCollection.UserId));
            entity.CreateBy = user;
            entity.CreateDate = DateTime.Now;
            bool result = _aDal.SvaeSlot(entity);
            return result;
        }

        [HttpGet]
        [Route("[action]/{yearId:int}")]
        public dynamic InitialPlanningList(int yearId)
        {

            var result = _aDal.SlotList(yearId);
            return result;
        }
        [HttpGet]
        [Route("[action]/{slotId:int}")]
        public dynamic GetAllPoForActualPlanning(int slotId)
        {

            var result = _aDal.AllPoNO(slotId);
            return result;
        }
        [HttpGet]
        [Route("[action]/{yearId:int}/{factoryId:int}/{brandId:int}/{guageId:int}")]
        public dynamic GetLastDateForPlanning(int yearId, int factoryId, int brandId, int guageId)
        {
            DataTable dt = _aDal.GetLastDateForPlanning(yearId, factoryId, brandId, guageId);
            return dt;

        }
        [HttpGet]
        [Route("[action]/{firstDate:DateTime}/{leadTime:int}")]
        public dynamic CalculateLastDateForPlanning(DateTime firstDate, int leadTime)
        {
            DataTable dt = _aDal.CalculateLastDateForPlanning(firstDate, leadTime);
            return dt;

        }
        [HttpGet]
        [Route("[action]/{poId:int}")]
        public dynamic GetPoDetails(int poId)
        {
            DataTable dt = _aDal.GetStyleInfo(poId);
            return dt;

        }
        [HttpGet]
        [Route("[action]/{slotId:int}")]
        public dynamic GetSlotDetailsForCalCuMcn(int slotId)
        {
            DataTable dt = _aDal.GetSlotDetailFCalCuMcn(slotId);
            return dt;

        }
        [HttpGet]
        [Route("[action]/{slotId:int}")]
        public dynamic GetSlotDetails(int slotId)
        {
            DataTable dt = _aDal.GetSlotDetail(slotId);
            return dt;

        }
        [HttpGet]
        [Route("[action]/{slotId:int}")]
        public dynamic GetSlotInfo(int slotId)
        {
            DataTable dt = _aDal.GetSlotInfo(slotId);
            return dt;

        }

        [HttpPost]
        [Route("[action]")]
        public bool SaveAllPO([FromBody] EditPoLit editPoLits)
        {
            var user = Convert.ToInt32(HttpContext.Session.GetString(SessionCollection.UserId));
            bool result = _aDal.SaveAllPo(editPoLits.Entity, user, editPoLits.LeadTime);
            return result;
        }

       public class EditPoLit
        {
            public IEnumerable<PlanningSlotDetails> Entity { get; set; }
            public int LeadTime { get; set; }
        }


        [HttpGet]
        [Route("[action]/{slotId}")]
        public dynamic GetAllPOBySlotId(string slotId)
        {
            DataTable dt = _aDal.GetAllPOBySlotId(slotId);
            return dt;

        }
        [HttpGet]
        [Route("[action]/{poId:int}/{poSplitId:int}")]
        public dynamic DeletePO(int poId, int poSplitId=0)
        {
            var user = Convert.ToInt32(HttpContext.Session.GetString(SessionCollection.UserId));
            bool dt = _aDal.DeletePO(poId, poSplitId, user);
            return dt;

        }

        [HttpGet]
        [Route("[action]/{slotId:int}/{newLeadTime:int}")]
        public dynamic StartDateEndDateFCNS(int slotId, int newLeadTime)
        {
            DataTable dt = _aDal.StartDateEndDateFCNS(slotId, newLeadTime);
            return dt;

        }

        [HttpPost]
        [Route("[action]")]
        public bool EditSlot(PlanningSlotMaster entity)
        {
            var user = Convert.ToInt32(HttpContext.Session.GetString(SessionCollection.UserId));
            entity.CreateBy = user;
            entity.CreateDate = DateTime.Now;
            bool result = _aDal.SaveSlotAndDetails(entity);
            return result;
        }


        [HttpGet]
        [Route("[action]/{slotId}")]
        public dynamic DeleteAllSlot(string slotId)
        {
            var user = Convert.ToInt32(HttpContext.Session.GetString(SessionCollection.UserId));
            if (user == 0)
            {
                return false;
            }
            else
            {
                var dt = _aDal.DeleteAllSlot(slotId, user);
                return dt;
            }


        }

        [HttpGet]
        [Route("[action]/{slotId:int}/{styleNo}")]
        public dynamic GetAllPoForActualPlanning(int slotId, string styleNo)
        {

            var result = _aDal.AllSplitPoNO(slotId, styleNo);
            return result;
        }
        [HttpGet]
        [Route("[action]/{poId:int}/{poSplitId:int}/{poOwnerType:int}")]
        public dynamic GetAllSplitPoDetails(int poId, int poSplitId=0, int poOwnerType=0)
        {
            DataTable dt = _aDal.GetStyleInfoAllSplitPo(poId, poSplitId, poOwnerType);
            return dt;

        }

        [HttpPost]
        [Route("[action]")]
        public bool SaveHistory(StyleHistory entity)
        {
            var user = Convert.ToInt32(HttpContext.Session.GetString(SessionCollection.UserId));
            
            bool result = _aDal.SvaeHistory(entity, user);
            return result;
        }


        [HttpGet]
        [Route("[action]/{slotId:int}")]
        public bool CompleteSlot(int slotId)
        {
            var user = Convert.ToInt32(HttpContext.Session.GetString(SessionCollection.UserId));

            bool result = _aDal.Completeslot(slotId, user);
            return result;
        }

        [HttpPost]
        [Route("[action]")]
        public bool SaveLeftOverStyle([FromBody] LeftOverStyleMaster AddEntity)
        {
            var user = Convert.ToInt32(HttpContext.Session.GetString(SessionCollection.UserId));
            bool result = _aDal.SaveLeftOverStyle(AddEntity, user);
            return result;
        }

    }
}
