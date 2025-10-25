using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SweaterPlanning.Models;
using SweaterPlanning.Models.ViewModel;
using SweaterPlanning.SecureDataClass;
using SweaterPlanning.Substructure.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using System.Drawing;
using QRCoder;
using IronBarCode;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace SweaterPlanning.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class CommonController : BaseController
    {
        JsonSerializerSettings _jsonSetting = new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore };
        private readonly CodeDbSet _context;
        private CommonDAL _aDal = new CommonDAL();
        private CapacityAllocationDAL _capacityAllocationDAL = new CapacityAllocationDAL();
        public CommonController(IUnitOfWork uow, CodeDbSet context)
        {
            Uow = uow;
            _context = context;
        }
        [HttpGet]
        [Route("[action]")]
        public async Task<IEnumerable<Years>> GetYear()
        {
            return await  Uow.TblYearsRepository.GetAll();
        }
        [HttpGet]
        [Route("[action]")]
        public async Task<IEnumerable<Months>> GetMonth()
        {
            return await  Uow.TblMonthsRepository.GetAll();
        }

        [HttpGet]
        [Route("[action]")]
        public async  Task<IEnumerable<MonthWiseWorkingDayList>> GetAllMonthWiseOrkingDay()
        {
            DataTable dt = _aDal.GetAll();
            IEnumerable<MonthWiseWorkingDayList> alist = DataTableToList.ToListof<MonthWiseWorkingDayList>(dt);
            return await Task.FromResult(alist);
            
        }
        [HttpGet]
        [Route("[action]")]
        public async  Task<IEnumerable<AllMachineQty>> GetAllMachineQty()
        {
            DataTable dt = _aDal.GetAllMachineQty();
            IEnumerable<AllMachineQty> alist = DataTableToList.ToListof<AllMachineQty>(dt);
            return await Task.FromResult(alist);
            
        }
        [HttpGet]
        [Route("[action]/{yearId:int}")]
        public async  Task<IEnumerable<CapacityAllocationList>> GetCapacityAllocatioLlist( int yearId)
        {
             
            DataTable dt = _capacityAllocationDAL.GetAllAllocationList(yearId);
            IEnumerable<CapacityAllocationList> alist = DataTableToList.ToListof<CapacityAllocationList>(dt);
            return await Task.FromResult(alist);
            
        }
        [HttpGet]
        [Route("[action]")]
        public async  Task<IEnumerable<Years>> GetAllocateYear()
        {
            string yearSp = "exec AllocationYear_sp";
            var res=  Uow.TblYearsRepository.StoreProcedure(yearSp);

            return await res;
        }
        [HttpGet]
        [Route("[action]")]
        public async  Task<DataSet> CapacityAllocationSummery(int yearId)
        {
            
            DataSet ds = _capacityAllocationDAL.GetAllAllocationSummery(yearId);

            return await Task.FromResult(ds);
        }
        //[HttpGet]
        //[Route("[action]/{buyerId:int}/{marchantId:int}/{yearId:int}/{monthId:int}/{gaugeId:int}")]
        //public async  Task<int> AllocationValidation(int buyerId, int marchantId, int yearId, int monthId, int gaugeId)
        //{
        //    DataTable ds = _capacityAllocationDAL.AllocationValidation(buyerId,marchantId,yearId,monthId,gaugeId);
        //    if (ds.Rows.Count > 0)
        //    {
        //        return await Task.FromResult(1);
        //    }
        //    else
        //    {
        //        return await Task.FromResult(0);
        //    }
            
        //}
        [HttpGet]
        [Route("[action]/{buyerId:int}/{marchantId:int}/{yearId:int}/{monthId:int}/{gaugeGroup:int}")]
        public async  Task<int> AllocationValidation(int buyerId, int marchantId, int yearId, int monthId, int gaugeGroup)
        {
            DataTable ds = _capacityAllocationDAL.AllocationValidation(buyerId,marchantId,yearId,monthId, gaugeGroup);
            if (ds.Rows.Count > 0)
            {
                return await Task.FromResult(1);
            }
            else
            {
                return await Task.FromResult(0);
            }
            
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IEnumerable<MenuStep>> GetAllMenuStep()
        {
            DataTable dt = _aDal.GetAllMenuSetp();
            IEnumerable<MenuStep> alist = DataTableToList.ToListof<MenuStep>(dt);
            return await Task.FromResult(alist);

        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IEnumerable<MenuType>> GetAllMenuType()
        {
            DataTable dt = _aDal.GetAllMenuType();
            IEnumerable<MenuType> alist = DataTableToList.ToListof<MenuType>(dt);
            return await Task.FromResult(alist);

        }
        [HttpGet]
        [Route("[action]/{menuStep:int}")]
        public async Task<IEnumerable<Menu>> GetAllParent( int menuStep)
        {
            DataTable dt = _aDal.GetAllParent(menuStep);
            IEnumerable<Menu> alist = DataTableToList.ToListof<Menu>(dt);
            return await Task.FromResult(alist);

        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IEnumerable<MenuList>> GetAllMenu()
        {
           DataTable dt = _aDal.GetAllMenu();
            IEnumerable<MenuList> alist = DataTableToList.ToListof<MenuList>(dt);
            return await Task.FromResult(alist);

        }

        /// <summary>
        /// Save Daily Task
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        /// api/Common/AddMenu
        //[Route("[action]")]
        //[HttpPost]
        //public async Task<dynamic> AddMenu([FromBody] Menu entity)
        //{
        //    try
        //    {
        //        entity.CreateDate = DateTime.Now;
        //        entity.CreateBy = 1;

        //        var result =/* await Uow.TblDailyActivityRepository.Add(entity);*/ await 1;
        //        return result;
        //    }
        //    catch (Exception ex)
        //    {
        //        Logger.LogInformation(ex.Message);
        //        throw;
        //    }
        //}
        [HttpGet]
        [Route("[action]/{yearId:int}")]
        public async Task<IEnumerable<YearlyAmanWeekend>> GetWeekendDays(int yearId) 
        {
            try
            {
               
                    string sp = "GetWeekendDays_sp " + yearId;
                    var res = Uow.TblYearlyAmanWeekendRepository.StoreProcedure(sp);

                    return await res;
            }
            catch (Exception )
            {

                throw;
            }
        
            
        }
        [HttpPost]
        [Route("[action]")]
        public async Task<ActionResult<dynamic>> SaveOffDays(YearlyAmanWeekend amanWeekend)
        {
            //string offdays = "121";
            var user = Convert.ToInt32(HttpContext.Session.GetString(SessionCollection.UserId));
            bool result = _aDal.AmanWorkCalander(amanWeekend.YearId, user,amanWeekend.WeekendDay);
            return await Task.FromResult(result);
        }

        [HttpPost]
        [Route("[action]")]
        //[ValidateAntiForgeryToken]
        public dynamic AddMenu([FromBody] Menu entity)
        {
            
            entity.CreateBy= Convert.ToInt32(HttpContext.Session.GetString(SessionCollection.UserId));
            entity.CreateDate = DateTime.Now;
            
            bool result = _aDal.SaveMenu(entity);
            return result;
        }

        [HttpGet]
        [Route("[action]/{yearId:int}/{monthId:int}")]
        public async Task<IEnumerable<MonthWiseWorkingDay>> GetMonthDuplicateCheck(int yearId, int monthId)
        {
            try
            {
                var list = _context.MonthWiseWorkingDay;
                var data = await Uow.TblMonthWiseWorkingDay.FindBy(x=> x.YearId==yearId && x.MonthId==monthId);

                return  data;
            }
            catch (Exception)
            {

                throw;
            }

        }


        [HttpGet]
        [Route("[action]/{buyerName}/{marchantName}/{yearName}/{gaugeName}")]
        public dynamic MarchantAllocateData(string buyerName, string marchantName, string yearName, string gaugeName)
        {
            var gaugeGroup = gaugeName.Replace("-", "/");
            DataTable ds = _capacityAllocationDAL.EditAllocateData(buyerName, marchantName, yearName, gaugeGroup);
            return ds;
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IEnumerable<Years>> GetallYear()
        {
            
            var res = Uow.TblYearsRepository.GetAll();

            return await res;
        }
        [HttpGet]
        [Route("[action]")]
        public async Task<IEnumerable<Years>> GetCurrentYear()
        {
            
            var res = Uow.TblYearsRepository.FindBy(x=> x.CurrentYear==true);

            return await res;
        }
        [HttpGet]
        [Route("[action]/{yearId:int}")]
        public DataTable ChartData3Gauge(int yearId)
        {
            
            var res = _aDal.ChartData3Gauge(yearId);

            return  res;
        }
        [HttpGet]
        [Route("[action]/{yearId:int}")]
        public DataTable FactoryWiseCapacity(int yearId)
        {
            
            var res = _aDal.FactoryWiseCapacity(yearId);

            return  res;
        }
        [HttpGet]
        [Route("[action]")]
        public async Task<IEnumerable<Factory>> GetFactory()
        {
            var factories = _context.Factories.FromSqlRaw("GetFactory").ToList();
            return await Task.FromResult(factories);
        }
        [HttpGet]
        [Route("[action]/{yearId:int}")]
        public dynamic GetAllMachineQty( int yearId=0)
        {
            return _aDal.GetAllMachineQty(yearId);
        }

        [HttpGet]
        [Route("[action]/{yearIds:int}")]
        public DataTable BuyerWiseAvgFob(int yearIds)
        {

            var res = _aDal.BuyerWiseAvgFob(yearIds);

            return res;
        }
        [HttpGet]
        [Route("[action]/{exFtyYear:int}")]
        public DataTable TotalBuyerOrder(int exFtyYear)
        {

            var res = _aDal.TotalBuyerOrder(exFtyYear);

            return res;
        }
        [HttpGet]
        [Route("[action]/{exFtyYear:int}/{buyerId:int}")]
        public DataSet TotalBuyerGuageOrder(int exFtyYear, int buyerId)
        {

            var res = _aDal.TotalBuyerGuageOrder(exFtyYear,buyerId);

            return res;
        }
        [HttpGet]
        [Route("[action]")]
        public DataTable GetKnittingOperation()
        {

            var res = _aDal.GetKnittingOperation();

            return res;
        }
        [HttpGet]
        [Route("[action]/{exFtyYear:int}")]
        public dynamic MonthWiseOrderEfficiency(int exFtyYear)
        {
            var res = _aDal.MonthWiseOrderEfficiency(exFtyYear);
           

            // Shorthand:: Create and save a barcode in a single line of code
            //BarcodeWriter.CreateBarcode("12345", BarcodeWriterEncoding.EAN8).ResizeTo(400, 100).SaveAsImage("EAN8.jpeg");


            /*****  IN-DEPTH BARCODE CREATION OPTIONS *****/

            // BarcodeWriter.CreateBarcode creates a GeneratedBarcode which can be styles and exported as an Image object or File
            GeneratedBarcode MyBarCode = BarcodeWriter.CreateBarcode("Mr. Zahir is Chutia", BarcodeWriterEncoding.Code128);

            // Style the Barcode in a fluent LINQ style fashion
            MyBarCode.ResizeTo(300, 150).SetMargins(20).AddAnnotationTextAboveBarcode("Example EAN8 Barcode").AddBarcodeValueTextBelowBarcode();
            MyBarCode.ChangeBackgroundColor(Color.LightGoldenrodYellow);

            // Save MyBarCode as an image file
            MyBarCode.SaveAsImage("MyBarCode.png");
            //MyBarCode.SaveAsGif("MyBarCode.gif");
            //MyBarCode.SaveAsHtmlFile("MyBarCode.html");
            //MyBarCode.SaveAsJpeg("MyBarCode.jpg");
            //MyBarCode.SaveAsPdf("MyBarCode.Pdf");
            //MyBarCode.SaveAsPng("MyBarCode.png");
            //MyBarCode.SaveAsTiff("MyBarCode.tiff");
            //MyBarCode.SaveAsWindowsBitmap("MyBarCode.bmp");

            // Save MyBarCode as a .Net native objects
            Image MyBarCodeImage = MyBarCode.Image;

            //foreach (DataRow item in res.Rows)
            //{
            //    item.ItemArray
            //}
            return MyBarCodeImage;

        }

        [HttpGet]
        [Route("[action]/{exFtyYear:int}/{marchantId:int}")]
        public DataTable CapacityVsOrder(int exFtyYear, int marchantId=0)
        {

            var res = _aDal.CapacityVsOrder(exFtyYear,marchantId);

            return res;
        }


        [HttpGet]
        [Route("[action]")]
        public dynamic GetAllMarchantHead()
        {

            var res = _aDal.GetAllMarchantHod();

            return  res;
        }
        [HttpGet]
        [Route("[action]/{stlNo}")]
        public dynamic GetStlNo(string stlNo)
        {

            var res = _aDal.GetStyleNo(stlNo);

            return  res;
        }
        [HttpGet]
        [Route("[action]/{catagory}")]
        public dynamic GetCatagory(string catagory)
        {

            var res = _aDal.GetItemcatagory(catagory);

            return  res;
        }
        [HttpGet]
        [Route("[action]/{catagory}")]
        public dynamic GetGrnMastCata(string catagory)
        {

            var res = _aDal.GrnMastCatagory(catagory);

            return  res;
        }
        [HttpGet]
        [Route("[action]/{eventId}")]
        public dynamic GetEvent(string eventId)
        {

            var res = _aDal.GetTAEvent(eventId);

            return  res;
        }


        [HttpGet]
        [Route("[action]/{Year:int}")]
        public DataTable CapacityVsOrder(int Year)
        {

            var res = _aDal.GetLoadVsCapacity(Year);

            return res;
        }
        [HttpGet]
        [Route("[action]/{ProductionDate:DateTime}")]
        public DataTable FactoryWiseProSumm(DateTime ProductionDate)
        {

            var res = _aDal.FactoryWiseProSumm(ProductionDate);

            return res;
        }

        [HttpGet]
        [Route("[action]")]
        public dynamic GetAllPlanStatus()
        {

            var res = _aDal.GetAllPlanStatus();

            return res;
        }

        [HttpGet]
        [Route("[action]/{catagoryId:int}/{cataOpId}")]
        public dynamic UpdateCataSeg(int catagoryId, string cataOpId )
        {

            var res = _aDal.UpdateCatagorySeg(catagoryId, cataOpId);

            return res;
        }


        [HttpGet]
        [Route("[action]")]
        public dynamic GetStyleType()
        {

            var res = _aDal.StyleType();

            return res;
        }

        [HttpGet]
        [Route("[action]")]
        public dynamic GetAllBuyer()
        {
            return  _aDal.GetAllBuyer();
        }

        //[HttpGet]
        //[Route("[action]/{startDate:DateTime?}/{endDate:DateTime?}/{factoryId:int?}/{styleNumber?}")]
        ////[Route("api/Common/GetPlanningGanntChart")]
        [HttpPost]
        [Route("[action]")]
        //public DataTable GetPlanningGanntChart(DateTime? startDate, DateTime? endDate, int? factoryId=0, string styleNumber="")

        public dynamic GetPlanningGanntChart(GanntChartSearchParameter entity)
        {

            var res = _aDal.GetPlanningGanntChart(entity.PlanFromDate, entity.PlanToDate, entity.FactoryId, entity.StyleNumber);

            return res;
        }
    }
}
