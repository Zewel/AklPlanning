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
    public class AddEditPoController : BaseController
    {
        private AddEditPoDAL _aDal = new AddEditPoDAL();

        [HttpPost]
        [Route("[action]/{stlCode:int}/{stlName}")]
        public async Task<ActionResult<dynamic>> StyleReName(int stlCode, string stlName)
        {

            var user = Convert.ToInt32(HttpContext.Session.GetString(SessionCollection.UserId));
            var result = _aDal.StyleReName(stlCode, stlName, user);
            return await Task.FromResult(result);
        }
        [HttpPost]
        [Route("[action]/{stlCode:int}/{stlQty:int}")]
        public async Task<ActionResult<dynamic>> StyleReQty(int stlCode, int stlQty)
        {

            var user = Convert.ToInt32(HttpContext.Session.GetString(SessionCollection.UserId));
            var result = _aDal.StyleQtyEdit(stlCode, stlQty, user);
            return await Task.FromResult(result);
        }

        //[HttpPost]
        //[Route("[action]")]
        ////[ValidateAntiForgeryToken]
        //public dynamic AddPo(StylePurchaseOrder entity)
        //{
        //    var CreateBy = Convert.ToInt32(HttpContext.Session.GetString(SessionCollection.UserId));
        //    entity.ForEach(c => { c.UserId = CreateBy; c.CreateDate = DateTime.Now; });
        //    var result = _dal.SaveAllPoSPlit(entity);
        //    return  result;
        //}


        [HttpGet]
        [Route("[action]/{stlCode:int}/{stlQty:int}/{remarks}")]
        public async Task<ActionResult<dynamic>> StyleUnlock(int stlCode, int stlQty, string remarks= null)
        {

            var user = HttpContext.Session.GetString(SessionCollection.UserCode);
            var result = _aDal.UnlockCosting(stlCode, stlQty, user,remarks);
            return await Task.FromResult(result);
        }
    }
}
