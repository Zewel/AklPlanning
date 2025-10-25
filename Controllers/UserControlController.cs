using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SweaterPlanning.Models;
using SweaterPlanning.Substructure.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace SweaterPlanning.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class UserControlController : BaseController
    {
        private readonly CodeDbSet _context;
        public UserControlController(IUnitOfWork uow, CodeDbSet context)
        {
            Uow = uow;
            _context = context;
        }
        
        [HttpPost]
        [Route("[action]")]
        public async Task<ActionResult<dynamic>> SavePassword([FromBody]UserInfo userInfo)
        {
            //string offdays = "121";
            var res = "ww";
            var result = System.Text.Encoding.UTF8.GetBytes(userInfo.Password);
            var mainText = System.Convert.ToBase64String(result);
            userInfo.Password = mainText;
            userInfo.IsActive = true;
            userInfo.UserName = userInfo.UserCode;
            UserInfo auser ;
            auser =  _context.UserInfo.AsNoTracking().Where(x=> x.UserId==userInfo.UserId).FirstOrDefault();
            if (auser== null)
            {

                res = await Uow.TblUserInfoRepository.Add(userInfo);
            }
            else
            {
                try
                {

                    _context.ChangeTracker.Clear();
                    _context.UserInfo.Update(userInfo);
                    _context.SaveChanges();
                }
                catch (Exception e)
                {

                    throw new ArgumentException(e.ToString());
                }
            }
            return "Ok";
           
        }

    }
}
