using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SweaterPlanning.Models;
using SweaterPlanning.Models.ViewModel;
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
    public class CapacityProjectionController : BaseController
    {
        private CapacityProjectionDAL _aDAL = new CapacityProjectionDAL();
        private CapacityAllocationDAL _CAllocation = new CapacityAllocationDAL();
        protected readonly CodeDbSet _context ;
        public CapacityProjectionController(IUnitOfWork uow, CodeDbSet codeDbSet)
        {
            Uow = uow;
            _context = codeDbSet;
        }

        [HttpGet]
        [Route("[action]/{year:int}/{tolaranceTiming:int}")]
        public  dynamic ProjectionProcess(int year,int tolaranceTiming)
        {
            //_context.TaskType.Add(taskType);
            //await _context.SaveChangesAsync();
            //return CreatedAtAction("GetTaskType", new { id = taskType.TaskTypeId }, taskType);
            var user = Convert.ToInt32(HttpContext.Session.GetString(SessionCollection.UserId));
            bool result = _aDAL.ProjectionProcess(year, tolaranceTiming,user);
            return  result;
        }
        [HttpGet]
        [Route("[action]/{yearId:int}")]
        public async Task<IEnumerable<YearlyCapacityProjectionList>>  ProjectionProcessList(int yearId)
        {
            DataTable res =  _aDAL.GetAllprojectinoList(yearId);
            var dt = new DataTable();
            dt =res ;
            IEnumerable<YearlyCapacityProjectionList> result = DataTableToList.ToListof<YearlyCapacityProjectionList>( dt);
            return await Task.FromResult( result);
        }
        //[HttpGet]
        //[Route("[action]/{yearId:int}")]
        //public async Task<IEnumerable<YearlyCapacityProjectionList>>  ProjectionProcessList(int yearId)
        //{
        //    Task<DataTable> res =  _aDAL.GetAllprojectinoList(yearId);
        //    var dt = new DataTable();
        //    dt =await res ;
        //    IEnumerable<YearlyCapacityProjectionList> result = DataTableToList.ToListof<YearlyCapacityProjectionList>( dt);
        //    return await Task.FromResult( result);
        //}

        [HttpGet]
        [Route("[action]/{year:int}")]
        public  dynamic IsProcessCompleted( int year)
        {
            
            IEnumerable<YearlyCapacityProjection> result =  _context.YearlyCapacityProjections.Where(x => x.YearId == year).ToList();
            

            if (result.Any())
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
        [HttpGet]
        [Route("[action]/{capacityProjectionId:int}")]
        public dynamic EditProjectionProcess(int capacityProjectionId)
        {
            //_context.TaskType.Add(taskType);
            //await _context.SaveChangesAsync();
            //return CreatedAtAction("GetTaskType", new { id = taskType.TaskTypeId }, taskType);
            var user = Convert.ToInt32(HttpContext.Session.GetString(SessionCollection.UserId));
            bool result = _aDAL.EditProjectionProcess(capacityProjectionId, user);
            return result;
        }

        [HttpGet]
        [Route("[action]/{yearId:int}/{monthId:int}")]
        public dynamic YearlyRunningCapacity(int yearId, int monthId=0)
        {


            var result = _CAllocation.YearlyBookingCapacity(yearId, monthId);
            return result;
        }
        [HttpGet]
        [Route("[action]/{yearId:int}/{marchantId:int}/{monthId:int}")]
        public dynamic YearlyManagerCapacity(int yearId, int marchantId, int monthId=0)
        {


            var result = _CAllocation.YearlyManagersCapacity(yearId,marchantId,monthId);
            return result;
        }
    }
}
