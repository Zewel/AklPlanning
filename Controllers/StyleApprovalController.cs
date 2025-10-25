using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SweaterPlanning.Models;
using SweaterPlanning.Models.ViewModel;
using SweaterPlanning.SecureDataClass;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace SweaterPlanning.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StyleApprovalController : BaseController
    {
        private StyleApprovalDAL _aDAL = new StyleApprovalDAL();
        public StyleApprovalController()
        {

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="styleNo"></param>
        /// <returns></returns>
        /// api/StyleApproval/StyleInfo/6547

        [HttpGet]
        [Route("[action]/{styleNo:int}")]
        public dynamic StyleInfo(int styleNo)
        {

            var result = _aDAL.GetStyleApprovalData(styleNo);
            IEnumerable<StyleMaster> styleMasters = DataTableToList.ToListof<StyleMaster>(result.Tables[0]);
            StyleMaster astyleMaster = styleMasters.FirstOrDefault();
            astyleMaster.StylePurchaseOrders = DataTableToList.ToListof<StylePurchaseOrder>(result.Tables[1]);
            return astyleMaster;
        }
        [HttpGet]
        [Route("[action]/{styleNo}")]
        public dynamic StyleInfoByStyleNo(string styleNo)
        {

            var result = _aDAL.StyleInfoByStyleNo(styleNo);
            IEnumerable<StyleMaster> styleMasters = DataTableToList.ToListof<StyleMaster>(result.Tables[0]);
            StyleMaster astyleMaster = styleMasters.FirstOrDefault();
            astyleMaster.StylePurchaseOrders = DataTableToList.ToListof<StylePurchaseOrder>(result.Tables[1]);
            return astyleMaster;
        }
        [HttpGet]
        [Route("[action]")]
        public dynamic  GetCoOrdinator()
        {

            var result = _aDAL.GetCoordinator();
            IEnumerable<CoOrdinator> coOrdinators = DataTableToList.ToListof<CoOrdinator>(result);
            return coOrdinators;
        }
        [HttpGet]
        [Route("[action]")]
        public dynamic GetRatioType()
        {

            var result = _aDAL.GetRatioType();
            IEnumerable<RatioType> ratioTypes = DataTableToList.ToListof<RatioType>(result);
            return ratioTypes;
        }
        [HttpGet]
        [Route("[action]")]
        public async Task<IEnumerable<CapacityAppvView>> GetAllStyleFApp()
        {
            DataTable dt = _aDAL.GetAllStyleFApp();
            IEnumerable<CapacityAppvView> alist = DataTableToList.ToListof<CapacityAppvView>(dt);
            return await Task.FromResult(alist);

        }
        [HttpGet]
        [Route("[action]")]
        public async Task<IEnumerable<CapacityAppvView>> GetAllStyleSpaceFSApp()
        {
            DataTable dt = _aDAL.GetAllStyleSpaceFSApp();
            IEnumerable<CapacityAppvView> alist = DataTableToList.ToListof<CapacityAppvView>(dt);
            return await Task.FromResult(alist);

        }


        [HttpPost]
        [Route("[action]")]
        public dynamic StyleApporve(StyleApproval entity)
        {


            if (!string.IsNullOrEmpty(HttpContext.Session.GetString(SessionCollection.UserName)))
            {
                var userId = Convert.ToInt32(HttpContext.Session.GetString(SessionCollection.UserId));
                var userName = HttpContext.Session.GetString(SessionCollection.UserName);
                bool result = _aDAL.SaveStyleApproval(entity, userName, userId);
                return result;
            }
            else
            {
                return RedirectToAction(nameof(UserInfoesController.Create), "UserInfoes");
            }
           
        }
        [HttpPost]
        [Route("[action]")]
        public bool StyleDeny(StyleApproval entity)
        {
            var userName = HttpContext.Session.GetString(SessionCollection.UserName);
            bool result = _aDAL.StyleDeny(entity, userName);
            return result;
        }

        [HttpGet]
        [Route("[action]")]
        public dynamic NumberOfPendinStyle()
        {
            DataTable dt = _aDAL.NumberOfPendinStyle();
            return dt;

        }
        [HttpGet]
        [Route("[action]")]
        public dynamic NumberOfPendinStyleFPlanning()
        {
            DataTable dt = _aDAL.NumberOfPendinStyleFPlanning();
            return dt;

        }
        [HttpPost]
        [Route("[action]")]
        public bool PlanMonthEdit(PoApproval entity)
        {
            var userId = Convert.ToInt32(HttpContext.Session.GetString(SessionCollection.UserId));
            entity.CreateDate = DateTime.Now;
            bool result = _aDAL.UpdatePlanMonth(entity, userId);
            return result;
        }


        [HttpPost]
        [Route("[action]")]
        public dynamic StyleIntialTAndA(InitialTAndA entity)
        {


            if (!string.IsNullOrEmpty(HttpContext.Session.GetString(SessionCollection.UserName)))
            {
                var userId = Convert.ToInt32(HttpContext.Session.GetString(SessionCollection.UserId));
                var userName = HttpContext.Session.GetString(SessionCollection.UserName);
                bool result = _aDAL.SaveInitialTAndA(entity, userName, userId);
                return result;
            }
            else
            {
                return RedirectToAction(nameof(UserInfoesController.Create), "UserInfoes");
            }

        }
        [HttpGet]
        [Route("[action]")]
        public dynamic NumberOfEventPendingFPlanning()
        {
            DataSet dt = _aDAL.NumberOfEventPendingFPlanning();
            return dt;

        }
    }
}
