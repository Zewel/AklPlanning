using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using SweaterPlanning.SecureDataClass;
using SweaterPlanning.Substructure.UnitOfWork;
using SweaterPlanning.Models;
using System.Reflection;
using System.Text;
using AspNetCore.Reporting;
using System.IO;
using static System.Net.Mime.MediaTypeNames;
using AspNetCore.Report;
using AspNetCore.Report.ReportExecutionService;
using Microsoft.AspNetCore.Http;

namespace SweaterPlanning.Controllers.ViewContrrollers.PartialViewControllers
{
    public class PartialViewController : Controller
    {

        //private IUnitOfWork uow;
        private readonly CodeDbSet codeDbSet;
        public PartialViewController(CodeDbSet context)
        {
            codeDbSet = context;
        }
        private CapacityAllocationDAL _capacityAllocateDal = new CapacityAllocationDAL();
        private InitialPlanningDAL _aDal = new InitialPlanningDAL();
        private CreateSlotDAL _aSlotDal = new CreateSlotDAL();
        private CommonDAL _commonDAL = new CommonDAL();
        private AddEditPoDAL _addPoDAL = new AddEditPoDAL();
        private StyleApprovalDAL styleApproval = new StyleApprovalDAL();
        public dynamic capacityAllocationSummeryView(int yearId)
        {

            
            //Task<DataSet> ds = new CommonController( uow,codeDbSet).CapacityAllocationSummery(yearId) ;
            DataSet ds = _capacityAllocateDal.GetAllAllocationSummery(yearId);
            return PartialView("~/Views/PartialView/_partialCapacityAllocateSummery.cshtml", ds);
        }
        public dynamic capacityAllocationAssistantView(int buyerId, int marchantId, int yearId, int monthId, int gaugeGroup)
        {
            DataSet ds = _capacityAllocateDal.AllocationAssistant(buyerId, marchantId, yearId, monthId, gaugeGroup);
            return PartialView("~/Views/PartialView/_partialCapacityAllocationAssistant.cshtml", ds);
        }
        public dynamic InitialPlanningPartial(int yearId)
        {
            DataSet ds = _aDal.GetInitialPlanningList(yearId);
            return PartialView("~/Views/PartialView/_partialInitaialPlanningList.cshtml", ds);
        }
        public dynamic PlanningSlotPartial(int yearId)
        {
            var ds = _aSlotDal.SlotList(yearId);
            return PartialView("~/Views/PartialView/_partialPlanningSlot.cshtml", ds);
            //return PartialView("~/Views/PartialView/_partialPlanningSlot1.cshtml", ds);
        }
        public dynamic PlanningSlotPartial1(int yearId, int factoryId = 0, string styleNumber=null)
        {
            var ds = _aSlotDal.SlotList(yearId, factoryId, styleNumber);
            //return PartialView("~/Views/PartialView/_partialPlanningSlot.cshtml", ds);
            return PartialView("~/Views/PartialView/_partialPlanningSlot1.cshtml", ds);
        }


        public dynamic PlanningSlotPartialFull(int yearId, int factoryId = 0)
        {
            var ds = _aSlotDal.SlotListFull(yearId, factoryId);
            //return PartialView("~/Views/PartialView/_partialPlanningSlot.cshtml", ds);
            return PartialView("~/Views/PartialView/_partialPlanningSlot1.cshtml", ds);
        }

        public dynamic GetAddRow(int tr)
        {
            TempData["trSl"] = tr;
            return PartialView("~/Views/PartialView/_partialAddStyleForPlanning.cshtml");
        }


        public dynamic PlanningPoView(string slotId)
        {
            var ds = _aSlotDal.GetAllPOBySlotId(slotId);
            return PartialView("~/Views/PartialView/_partialViewPoBySlotId.cshtml", ds);
        }
        public dynamic StyleInfo(int styleNo)
        {
            StyleApprovalController aController = new StyleApprovalController();
            var result = aController.StyleInfo(styleNo);

            return PartialView("~/Views/PartialView/_partialStyleInfo.cshtml", result);
        }
         public dynamic StyleInfoByStyleNo(string styleNo)
        {
            StyleApprovalController aController = new StyleApprovalController();
            var result = aController.StyleInfoByStyleNo(styleNo);

            return PartialView("~/Views/PartialView/_partialStyleInfo.cshtml", result);
        }

        public dynamic PlanningPoListView(string slotId)
        {
            var ds = _aSlotDal.GetAllPOBySlotId(slotId);
            return PartialView("~/Views/PartialView/_partialViewPoBySlotId.cshtml", ds);
        }
        [HttpPost]
        public dynamic StyleListView([FromBody] StyleListParameters entity)
        {
            //StyleListParameters styleListParameters = new StyleListParameters();
            //styleListParameters.Buyer = Buyer;
            try
            {
                var ds = _commonDAL.GetAllStyleList(entity);
                return PartialView("~/Views/PartialView/_partialAllStyleList.cshtml", ds);
            }
            catch(Exception ex)
            {
                var a = ex;
                throw  ;
            }
           
        }

        public dynamic PoListView(string stlNo)
        {

            var ds = _commonDAL.GetAllPoFStyle(stlNo);
            return PartialView("~/Views/PartialView/_partialAllPoList.cshtml", ds);
        }
        public dynamic StyleListForPoSplit(int styleNo)
        {

            var ds = _commonDAL.GetStyleInfoByStlNo(styleNo);
            if (ds.Tables[0].Rows.Count > 0)
            {
                IEnumerable<StyleMaster> styleMasters = DataTableToList.ToListof<StyleMaster>(ds.Tables[0]);
                StyleMaster astyleMaster = styleMasters.FirstOrDefault();
                astyleMaster.StylePurchaseOrders = DataTableToList.ToListof<StylePurchaseOrder>(ds.Tables[1]);
                var dataSet = Tuple.Create(styleMasters, astyleMaster.StylePurchaseOrders);
                var splitList = ds.Tables[2];
                var tupleList = new Tuple<StyleMaster, DataTable>(astyleMaster, splitList);
                return PartialView("~/Views/PartialView/_partialPoSplit.cshtml", tupleList);
            }
            else
            {
                return "Invalid Style Name";
            }

        }


        public dynamic CapacityVsOrderPartial(int yearId, int MarchatId = 0)
        {
            var ds = _commonDAL.CapacityVsOrder(yearId, MarchatId);
            //return PartialView("~/Views/PartialView/_partialPlanningSlot.cshtml", ds);
            return PartialView("~/Views/PartialView/_partialCapacityVsOrder.cshtml", ds);
        }
        public dynamic SwappingPo(int destinationSltNo, int SlotDetailsId, int numberOfMainSlot)
        {
            var ds = _aSlotDal.SwappingPo(destinationSltNo, SlotDetailsId, numberOfMainSlot);
            return PartialView("~/Views/PartialView/_partialSwappingRow.cshtml", ds);
        }

        public dynamic StyleForPoAddEdit(int styleNo)
        {

            var ds = _commonDAL.GetStyleAllPOByStlNo(styleNo);
            if (ds.Tables[0].Rows.Count > 0)
            {
                IEnumerable<StyleMaster> styleMasters = DataTableToList.ToListof<StyleMaster>(ds.Tables[0]);
                StyleMaster astyleMaster = styleMasters.FirstOrDefault();
                astyleMaster.StylePurchaseOrders = DataTableToList.ToListof<StylePurchaseOrder>(ds.Tables[1]);
                return PartialView("~/Views/PartialView/_partialAddEditPo.cshtml", astyleMaster);
            }
            else
            {
                return "Invalid Style Name";
            }

        }
        [HttpPost]
        public dynamic AddPo([FromBody] StylePurchaseOrder entity)
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString(SessionCollection.UserName)))
            {

                string CreateBy = HttpContext.Session.GetString(SessionCollection.UserName);
                int createId = Convert.ToInt32(HttpContext.Session.GetString(SessionCollection.UserId));
                var ds = _addPoDAL.SavePo(entity, CreateBy, createId);
                IEnumerable<StylePurchaseOrder> aorder = DataTableToList.ToListof<StylePurchaseOrder>(ds);
                return PartialView("~/Views/PartialView/_partialAddEditPocshtml.cshtml", aorder);
            }
            else
            {
                return "Session Out";
            }

        }

        public dynamic SearchAllTAndA([FromBody] TandASearchParameters entity)
        {
            var ds = _commonDAL.GetAllTAndA(entity);
            return PartialView("~/Views/PartialView/_partialAllTAndA.cshtml", ds);
        }
        public dynamic SearchAllGRN([FromBody] GRNSearchParameters entity)
        {
            var ds = _commonDAL.GetAllGRN(entity);
            return PartialView("~/Views/PartialView/_partialAllGRN.cshtml", ds);
        }

        // [HttpPost]
        //public dynamic EditPo([FromBody] StylePurchaseOrder entity)
        // {

        //    var ds = _addPoDAL.SavePo(entity, CreateBy);
        //    IEnumerable<StylePurchaseOrder> aorder = DataTableToList.ToListof<StylePurchaseOrder>(ds);
        //    return PartialView("~/Views/PartialView/_partialAddEditPocshtml.cshtml", aorder);


        //}

        public dynamic SearchGRN(int styleCode)
        {

            var ds = _aDal.GETGRN(styleCode);
            return PartialView("~/Views/PartialView/_partialGRN.cshtml", ds);
        }
        
        public dynamic SearchTAndA(int styleCode)
        {

            var ds = _aDal.GetTAndA(styleCode);
            return PartialView("~/Views/PartialView/_partialTAndA.cshtml", ds);
        }

        public dynamic BOM(string styleNo)
        {

            var ds = _commonDAL.BOM(styleNo);
            if (ds.Tables[0].Rows.Count > 0)
            {
                IEnumerable<StyleMaster> styleMasters = DataTableToList.ToListof<StyleMaster>(ds.Tables[0]);
                StyleMaster astyleMaster = styleMasters.FirstOrDefault();
                astyleMaster.StylePurchaseOrders = DataTableToList.ToListof<StylePurchaseOrder>(ds.Tables[1]);
                astyleMaster.BOMs = DataTableToList.ToListof<BOM>(ds.Tables[2]);
                return PartialView("~/Views/PartialView/_partialBOM.cshtml", astyleMaster);
            }
            else
            {
                return "Invalid Style Name";
            }
          
        }
        public dynamic StyleListForPoAdd(string styleName)
        {

            var ds = _addPoDAL.StyleList(styleName);
            return PartialView("~/Views/PartialView/_partialStyleListFAdd.cshtml", ds);
        }
        public dynamic MonthWiseTotalOrder()
        {

            var ds = _commonDAL.MonthWiseTotalOrder();
            return PartialView("~/Views/PartialView/_partialMonthWiseTOrder.cshtml", ds);
        }
        public dynamic CapacityVsLoadMinute(int year)
        {

            var ds = _commonDAL.GetLoadVsCapacity(year);
            return PartialView("~/Views/PartialView/_partialCapaciityVsLoadMinute.cshtml", ds);
        }

        [HttpGet]
        public dynamic DeleteMasterPo(int poId)
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString(SessionCollection.UserName)))
            {

                string CreateBy = HttpContext.Session.GetString(SessionCollection.UserName);
                int createId = Convert.ToInt32(HttpContext.Session.GetString(SessionCollection.UserId));
                var ds = _addPoDAL.DeleteMasterPo(poId, createId);
                IEnumerable<StylePurchaseOrder> aorder = DataTableToList.ToListof<StylePurchaseOrder>(ds);
                return PartialView("~/Views/PartialView/_partialAddEditPocshtml.cshtml", aorder);
            }
            else
            {
                return "Session Out";
            }

        }

        public dynamic ShipmentList(int year, int monthId=0)
        {

            var ds = _commonDAL.ShipmentList(year,monthId);
            return PartialView("~/Views/PartialView/_partialShipmentList.cshtml", ds);
        }

        public dynamic GetAllPoForActualPlanning(int slotId, string styleNo)
        {

            var result = _aSlotDal.AllSplitPoNO(slotId, styleNo);
            return PartialView("~/Views/PartialView/_partialAllSplitPo.cshtml", result);
        }

        public dynamic InitialPlanningPartialModify(int yearId, int gaugeId,int brandId)
        {
            DataTable ds = _aDal.GetInitialPlanningListModify(yearId,gaugeId,brandId);
            return PartialView("~/Views/PartialView/_partialInitaialPlanningListModify.cshtml", ds);
        }
        public dynamic PlanGanntChart([FromBody] StyleListParameters entity)
        {
            //StyleListParameters styleListParameters = new StyleListParameters();
            //styleListParameters.Buyer = Buyer;
            try
            {
                var ds = _commonDAL.GetAllPlanGanntChart(entity);
                return PartialView("~/Views/PartialView/_partialPlanGanntChart.cshtml", ds);
            }
            catch (Exception ex)
            {
                var a = ex;
                throw;
            }

        }


        [HttpGet]
        public dynamic DeletePoSplit(int poId)
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString(SessionCollection.UserName)))
            {

                string CreateBy = HttpContext.Session.GetString(SessionCollection.UserName);
                int createId = Convert.ToInt32(HttpContext.Session.GetString(SessionCollection.UserId));
                var ds = _addPoDAL.DeletePoSplit(poId, createId);
                return Convert.ToInt32(ds.Rows[0][0]);
            }
            else
            {
                return "Session Out";
            }

        }
        
        [HttpGet]
        public dynamic DeletePlannedPoSplit(int poId)
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString(SessionCollection.UserName)))
            {

                string CreateBy = HttpContext.Session.GetString(SessionCollection.UserName);
                int createId = Convert.ToInt32(HttpContext.Session.GetString(SessionCollection.UserId));
                var ds = _addPoDAL.DeletePlannedPoSplit(poId, createId);
                return ds;
            }
            else
            {
                return "Session Out";
            }

        }
        [HttpGet]
        public dynamic StyleHistory(int poCode)
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString(SessionCollection.UserName)))
            {

                string CreateBy = HttpContext.Session.GetString(SessionCollection.UserName);
                int createId = Convert.ToInt32(HttpContext.Session.GetString(SessionCollection.UserId));
                var ds = _addPoDAL.StyleHistory(poCode);
                return PartialView("~/Views/PartialView/_partialPlanHistory.cshtml", ds);
            }
            else
            {
                return "Session Out";
            }

        }
       
        public dynamic FactoryWiseProSumm(DateTime ProductionDate)
        {
            
            try
            {
                var ds = _commonDAL.FactoryWiseProSumm(ProductionDate);
                return PartialView("~/Views/PartialView/_partialProSumm.cshtml", ds);
            }
            catch (Exception ex)
            {
                var a = ex;
                throw;
            }

        }

        [HttpPost]
        public dynamic PlanHistory([FromBody] StyleListParameters entity)
        {
            
            try
            {
                var ds = _commonDAL.GetAllStyleList(entity);
                return PartialView("~/Views/PartialView/_partialAllStyleList.cshtml", ds);
            }
            catch (Exception ex)
            {
                var a = ex;
                throw;
            }

        }

        public dynamic TNAEventFPlan()
        {

            var ds = styleApproval.NumberOfEventPendingFPlanning();
            return PartialView("~/Views/PartialView/_partialEventPlan.cshtml", ds);
        }

        public dynamic LeftOverStyleList()
        {

            var ds = _aSlotDal.LeftOverStyleList();
            return PartialView("~/Views/PartialView/_partialLeftOverStyleList.cshtml", ds);
        }

        [HttpPost]
        public dynamic StyleBookingHistoryView([FromBody] StyleListParameters entity)
        {
            //StyleListParameters styleListParameters = new StyleListParameters();
            //styleListParameters.Buyer = Buyer;
            try
            {
                var ds = _commonDAL.GetAllBookingHistoryList(entity);
                return PartialView("~/Views/PartialView/_partialAllStyleList.cshtml", ds);
            }
            catch (Exception ex)
            {
                var a = ex;
                throw;
            }

        }

        public dynamic StylePlanSummary(string slotId)
        {
            var ds = _aSlotDal.StylePlanSummary(slotId);
            return PartialView("~/Views/PartialView/_partialStylePlanSummary.cshtml", ds);
        }

        public dynamic DailyLinkingProEff(DateTime productionDate)
        {
            var data = _commonDAL.DailyLinkingEfficiency(productionDate);
            if (data.Rows.Count > 0)
            {

                return PartialView("~/Views/PartialView/_partialLinkingEff.cshtml", data);
            }
            else
            {
                return "No Data Fount";
            }
        }

    }
}

