
using SweaterPlanning.DllClass;
using SweaterPlanning.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace SweaterPlanning.SecureDataClass
{
    public class CommonDAL : DataAccessLayer
    {
        public dynamic GetAll()
        {
            try
            {
                SqlConnectionOpen("Planning_NW");
                //List<SqlParameter> aParameters = new List<SqlParameter>();
                //aParameters.Add(new SqlParameter("@id", id));

                DataTable dt = GetDataTable("sp_GetAllWorkingDay", true);
                return dt;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                SqlConnectionClose();
            }
        }
        public dynamic GetAllMachineQty()
        {
            try
            {
                SqlConnectionOpen("Planning_NW");
                //List<SqlParameter> aParameters = new List<SqlParameter>();
                //aParameters.Add(new SqlParameter("@id", id));

                DataTable dt = GetDataTable("sp_GetAllMachine", true);
                return dt;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                SqlConnectionClose();
            }
        }
        public dynamic GetAllMenuSetp()
        {
            try
            {
                SqlConnectionOpen("Planning_NW");
                //List<SqlParameter> aParameters = new List<SqlParameter>();
                //aParameters.Add(new SqlParameter("@id", id));

                DataTable dt = GetDataTable("MenuStep_sp", true);
                return dt;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                SqlConnectionClose();
            }
        }
        public dynamic GetAllMenuType()
        {
            try
            {
                SqlConnectionOpen("Planning_NW");
                //List<SqlParameter> aParameters = new List<SqlParameter>();
                //aParameters.Add(new SqlParameter("@id", id));

                DataTable dt = GetDataTable("MenuType_sp", true);
                return dt;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                SqlConnectionClose();
            }
        }
        public dynamic GetAllParent(int menuStep)
        {
            try
            {
                SqlConnectionOpen("Planning_NW");
                List<SqlParameter> aParameters = new List<SqlParameter>();
                aParameters.Add(new SqlParameter("@MenuSetp", menuStep));

                DataTable dt = GetDataTable("GetAllParent", aParameters, true);
                return dt;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                SqlConnectionClose();
            }
        }
        public dynamic GetAllMenu()
        {
            try
            {
                SqlConnectionOpen("Planning_NW");
                DataTable dt = GetDataTable("MenuList_sp", true);
                return dt;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                SqlConnectionClose();
            }
        }


        public dynamic AmanWorkCalander(int yearId, int user, string weekends)
        {
            try
            {
                SqlConnectionOpen("Planning_NW");
                List<SqlParameter> aParameters = new List<SqlParameter>();
                aParameters.Add(new SqlParameter("@YearId", yearId));
                aParameters.Add(new SqlParameter("@WeekendDay", weekends));
                aParameters.Add(new SqlParameter("@UserId", user));

                bool dt = SaveData("AmanWorkCalender_sp", aParameters);
                return dt;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                SqlConnectionClose();
            }
        }
        public dynamic SaveMenu(Menu entity)
        {
            try
            {

                SqlConnectionOpen("Planning_NW");
                List<SqlParameter> aParameters = new List<SqlParameter>();
                aParameters.Add(new SqlParameter("@MenuStepId", entity.MenuStepId));
                aParameters.Add(new SqlParameter("@ParantId", entity.ParantId));
                aParameters.Add(new SqlParameter("@MenuName", entity.MenuName));
                aParameters.Add(new SqlParameter("@IsMVC", entity.IsMVC));
                aParameters.Add(new SqlParameter("@IsPage", entity.IsPage));
                aParameters.Add(new SqlParameter("@ControllerName", entity.ControllerName));
                aParameters.Add(new SqlParameter("@ActionName", entity.ActionName));
                aParameters.Add(new SqlParameter("@MenuTypeId", entity.MenuTypeId));
                aParameters.Add(new SqlParameter("@IsActive", entity.IsActive));
                aParameters.Add(new SqlParameter("@CreateBy", entity.CreateBy));
                aParameters.Add(new SqlParameter("@CreateDate", entity.CreateDate));
                bool dt = SaveData("SaveMenu_sp", aParameters);
                return dt;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                SqlConnectionClose();
            }
        }

        public DataTable ChartData3Gauge(int yearId)
        {
            try
            {
                SqlConnectionOpen("Planning_NW");
                List<SqlParameter> aParameters = new List<SqlParameter>();
                aParameters.Add(new SqlParameter("@YearId", yearId));
                DataTable dt = GetDataTable("ChartFor3Guage_sp", aParameters, true);
                return dt;
            }
            catch (Exception)
            {
                throw;
                //e.ToString();
            }
            finally
            {
                SqlConnectionClose();
            }
        }
        public DataTable FactoryWiseCapacity(int yearId)
        {
            try
            {
                SqlConnectionOpen("Planning_NW");
                List<SqlParameter> aParameters = new List<SqlParameter>();
                aParameters.Add(new SqlParameter("@YearId", yearId));
                DataTable dt = GetDataTable("FactoryWiseProductionCapacity_sp", aParameters, true);
                return dt;
            }
            catch (Exception)
            {
                throw;
                //e.ToString();
            }
            finally
            {
                SqlConnectionClose();
            }
        }
        public DataTable GetAllMachineQty(int yearId = 0)
        {
            try
            {
                SqlConnectionOpen("Planning_NW");
                List<SqlParameter> aParameters = new List<SqlParameter>();
                aParameters.Add(new SqlParameter("@yearId", yearId));
                DataTable dt = GetDataTable("GatAllMachineQty_sp", aParameters, true);
                return dt;
            }
            catch (Exception)
            {
                throw;
                //e.ToString();
            }
            finally
            {
                SqlConnectionClose();
            }
        }

        public dynamic GetAllStyleList(StyleListParameters entity)
        {
            try
            {
                SqlConnectionOpen("Planning_NW");
                List<SqlParameter> aParameters = new List<SqlParameter>();
                aParameters.Add(new SqlParameter("@PoNo", entity.PoNo));
                aParameters.Add(new SqlParameter("@STYLENO", entity.StyleNo));
                aParameters.Add(new SqlParameter("@BUYER", entity.Buyer));
                aParameters.Add(new SqlParameter("@MARCHANT", entity.Marchant));
                aParameters.Add(new SqlParameter("@TEAM", entity.TeamHead));
                aParameters.Add(new SqlParameter("@OrderFromDate", entity.OrderFromDate.ToString() == "1/1/0001 12:00:00 AM" ? null : entity.OrderFromDate));
                aParameters.Add(new SqlParameter("@OrderToDate", entity.OrderToDate.ToString() == "1/1/0001 12:00:00 AM" ? null : entity.OrderToDate));
                aParameters.Add(new SqlParameter("@DeliveryFromDate", entity.DeliveryFromDate.ToString() == "1/1/0001 12:00:00 AM" ? null : entity.DeliveryFromDate));
                aParameters.Add(new SqlParameter("@DeliveryToDate", entity.DeliveryToDate.ToString() == "1/1/0001 12:00:00 AM" ? null : entity.DeliveryToDate));

                aParameters.Add(new SqlParameter("@PlanFromDate", entity.PlanFromDate.ToString() == "1/1/0001 12:00:00 AM" ? null : entity.PlanFromDate));
                aParameters.Add(new SqlParameter("@PlanToDate", entity.PlanToDate.ToString() == "1/1/0001 12:00:00 AM" ? null : entity.PlanToDate));
                DataTable dt = GetDataTable("GetAllStyleList_sp", aParameters, true);
                return dt;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                SqlConnectionClose();
            }
        }
        public dynamic GetAllPoFStyle(string stlNO)
        {
            try
            {
                SqlConnectionOpen("Planning_NW");
                List<SqlParameter> aParameters = new List<SqlParameter>();
                aParameters.Add(new SqlParameter("@STYLENO", stlNO));
                DataTable dt = GetDataTable("GetAllPOFCPlanMonth", aParameters, true);
                return dt;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                SqlConnectionClose();
            }
        }

        public DataTable BuyerWiseAvgFob(int yearId)
        {
            try
            {
                SqlConnectionOpen("Planning_NW");
                List<SqlParameter> aParameters = new List<SqlParameter>();
                aParameters.Add(new SqlParameter("@YearId", yearId));
                DataTable dt = GetDataTable("BuyerWiseAvgFob", aParameters, true);
                return dt;
            }
            catch (Exception)
            {
                throw;
                //e.ToString();
            }
            finally
            {
                SqlConnectionClose();
            }
        }
        public DataTable TotalBuyerOrder(int yearId)
        {
            try
            {
                SqlConnectionOpen("Planning_NW");
                List<SqlParameter> aParameters = new List<SqlParameter>();
                aParameters.Add(new SqlParameter("@YearId", yearId));
                DataTable dt = GetDataTable("BuyerWiseOrderQty_sp", aParameters, true);
                return dt;
            }
            catch (Exception)
            {
                throw;
                //e.ToString();
            }
            finally
            {
                SqlConnectionClose();
            }
        } 
        public DataSet TotalBuyerGuageOrder(int yearId,int buyerId)
        {
            try
            {
                SqlConnectionOpen("Planning_NW");
                List<SqlParameter> aParameters = new List<SqlParameter>();
                aParameters.Add(new SqlParameter("@YearId", yearId));
                aParameters.Add(new SqlParameter("@MarchantId", buyerId));
                DataSet dt = GetDataSet("BuyerCapacityVsOrder_sp", aParameters, true);
                return dt;
            }
            catch (Exception)
            {
                throw;
                //e.ToString();
            }
            finally
            {
                SqlConnectionClose();
            }
        }
        public DataTable MonthWiseOrderEfficiency(int yearId)
        {
            try
            {
                SqlConnectionOpen("Planning_NW");
                List<SqlParameter> aParameters = new List<SqlParameter>();
                aParameters.Add(new SqlParameter("@YearId", yearId));
                DataTable dt = GetDataTable("MonthWiseOrderEfficiency_sp", aParameters, true);
                return dt;
            }
            catch (Exception)
            {
                throw;
                //e.ToString();
            }
            finally
            {
                SqlConnectionClose();
            }
        }
        
        public dynamic GetStyleInfoByStlNo(int StyleNo)
        {
            try
            {
                SqlConnectionOpen("Planning_NW");
                List<SqlParameter> aParameters = new List<SqlParameter>();
                aParameters.Add(new SqlParameter("@StlNo", StyleNo));
                DataSet ds = GetDataSet("GetStyleDetailsByStyleNoPoSplit_sp", aParameters, true);
                return ds;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                SqlConnectionClose();
            }
        }
        
        public dynamic GetStyleAllPOByStlNo(int StyleNo)
        {
            try
            {
                SqlConnectionOpen("Planning_NW");
                List<SqlParameter> aParameters = new List<SqlParameter>();
                aParameters.Add(new SqlParameter("@StlNo", StyleNo));
                DataSet ds = GetDataSet("GetStyleDetailsByStyleNoPo_sp", aParameters, true);
                return ds;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                SqlConnectionClose();
            }
        }


        public dynamic GetStyleInfoByStlNoFPoAdd(string StyleNo)
        {
            try
            {
                SqlConnectionOpen("Planning_NW");
                List<SqlParameter> aParameters = new List<SqlParameter>();
                aParameters.Add(new SqlParameter("@StlNo", StyleNo));
                DataSet ds = GetDataSet("GetStyleDetailsByStyleNoPo_sp", aParameters, true);
                return ds;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                SqlConnectionClose();
            }
        }


        public dynamic GetKnittingOperation()
        {
            try
            {
                SqlConnectionOpen("Planning_NW");

                DataTable ds = GetDataTable("GetAllOperation_sp", true);
                return ds;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                SqlConnectionClose();
            }
        }
        public dynamic CapacityVsOrder(int yearId, int merchantId = 0)
        {
            try
            {
                SqlConnectionOpen("Planning_NW");
                List<SqlParameter> aParameters = new List<SqlParameter>();
                aParameters.Add(new SqlParameter("@YearId", yearId));
                aParameters.Add(new SqlParameter("@MarchantId", merchantId));
                DataTable ds = GetDataTable("CapacityVsOrder_sp", aParameters, true);
                var name = ds.AsEnumerable().FirstOrDefault().ItemArray[1];
                return ds;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                SqlConnectionClose();
            }
        }
        public dynamic GetAllMarchantHod()
        {
            try
            {
                SqlConnectionOpen("Planning_NW");

                DataTable ds = GetDataTable("GetMerchantHeadList_sp", true);
                return ds;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                SqlConnectionClose();
            }
        }
        public dynamic GetStyleNo(string styleNo)
        {
            try
            {
                SqlConnectionOpen("Planning_NW");
                List<SqlParameter> aParameters = new List<SqlParameter>();
                aParameters.Add(new SqlParameter("@stlCode", styleNo));
                DataTable ds = GetDataTable("StlAutoCom_sp",aParameters, true);
                return ds;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                SqlConnectionClose();
            }
        }
        
        public dynamic GetItemcatagory(string catagory)
        {
            try
            {
                SqlConnectionOpen("Planning_NW");
                List<SqlParameter> aParameters = new List<SqlParameter>();
                aParameters.Add(new SqlParameter("@catagoryId", catagory));
                DataTable ds = GetDataTable("ItemCataAutoCom_sp", aParameters, true);
                return ds;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                SqlConnectionClose();
            }
        }
        
        public dynamic GrnMastCatagory(string MastCatagory)
        {
            try
            {
                SqlConnectionOpen("Planning_NW");
                List<SqlParameter> aParameters = new List<SqlParameter>();
                aParameters.Add(new SqlParameter("@catagoryId", MastCatagory));
                DataTable ds = GetDataTable("GrnMastCataAutoCom_sp", aParameters, true);
                return ds;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                SqlConnectionClose();
            }
        }
        
        public dynamic GetTAEvent(string eventId)
        {
            try
            {
                SqlConnectionOpen("Planning_NW");
                List<SqlParameter> aParameters = new List<SqlParameter>();
                aParameters.Add(new SqlParameter("@eventId", eventId));
                DataTable ds = GetDataTable("EventAutoCom_sp", aParameters, true);
                return ds;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                SqlConnectionClose();
            }
        }

        public dynamic GetAllTAndA(TandASearchParameters entity)
        {
            try
            {
                SqlConnectionOpen("Planning_NW");
                List<SqlParameter> aParameters = new List<SqlParameter>();
                aParameters.Add(new SqlParameter("@styleNo", entity.StyleNo));
                aParameters.Add(new SqlParameter("@buyer", entity.Buyer));
                aParameters.Add(new SqlParameter("@catagory", entity.TCatagory));
                aParameters.Add(new SqlParameter("@event", entity.TEvent));
                aParameters.Add(new SqlParameter("@plnFromDate", entity.PlnFromDate.ToString() == "1/1/0001 12:00:00 AM" ? null : entity.PlnFromDate));
                aParameters.Add(new SqlParameter("@plnToDate", entity.PlnToDate.ToString() == "1/1/0001 12:00:00 AM" ? null : entity.PlnToDate));
               aParameters.Add(new SqlParameter("@ExFromDate", entity.ExFromDate.ToString() == "1/1/0001 12:00:00 AM" ? null : entity.ExFromDate));
                aParameters.Add(new SqlParameter("@ExToDate", entity.ExnToDate.ToString() == "1/1/0001 12:00:00 AM" ? null : entity.ExnToDate));

                aParameters.Add(new SqlParameter("@Metarial", entity.Metarial));
                DataTable dt = GetDataTable("TAndASerachResult_sp", aParameters, true);
                return dt;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                SqlConnectionClose();
            }
        }
        
        public dynamic GetAllGRN(GRNSearchParameters entity)
        {
            try
            {
                SqlConnectionOpen("Planning_NW");
                List<SqlParameter> aParameters = new List<SqlParameter>();
                aParameters.Add(new SqlParameter("@styleNo", entity.StyleNo));
                aParameters.Add(new SqlParameter("@buyer", entity.Buyer));
                aParameters.Add(new SqlParameter("@catagory", entity.TCatagory));
                aParameters.Add(new SqlParameter("@event", entity.TEvent));
                aParameters.Add(new SqlParameter("@plnFromDate", entity.GRNDate));
                DataTable dt = GetDataTable("SearchAllGRN_sp", aParameters, true);
                return dt;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                SqlConnectionClose();
            }
        }

        // public dynamic GetStyleInfoByStlNo(string StyleNo)
        //{
        //    try
        //    {
        //        SqlConnectionOpen("Planning_NW");
        //        List<SqlParameter> aParameters = new List<SqlParameter>();
        //        aParameters.Add(new SqlParameter("@StlNo", StyleNo));
        //        DataSet ds = GetDataSet("GetStyleDetailsByStyleNo_sp", aParameters, true);
        //        return ds;
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //    finally
        //    {
        //        SqlConnectionClose();
        //    }
        //}


        public dynamic BOM(string StyleNo)
        {
            try
            {
                SqlConnectionOpen("Planning_NW");
                List<SqlParameter> aParameters = new List<SqlParameter>();
                aParameters.Add(new SqlParameter("@StlNo", StyleNo));
                DataSet ds = GetDataSet("BOM_sp", aParameters, true);
                return ds;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                SqlConnectionClose();
            }
        }


        public dynamic MonthWiseTotalOrder()
        {
            try
            {
                SqlConnectionOpen("Planning_NW");
                List<SqlParameter> aParameters = new List<SqlParameter>();
                DataTable ds = GetDataTable("MonthWiseTotalOrder_sp", aParameters, true);
                return ds;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                SqlConnectionClose();
            }
        }
        public dynamic GetLoadVsCapacity(int yearId)
        {
            try
            {
                SqlConnectionOpen("Planning_NW");
                List<SqlParameter> aParameters = new List<SqlParameter>();
                aParameters.Add(new SqlParameter("@YearId", yearId));
                DataTable dt = GetDataTable("LoadVsCapcityYearly_sp", aParameters, true);
                return dt;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                SqlConnectionClose();
            }
        }

        public dynamic ShipmentList(int yearId,int monthId)
        {
            try
            {
                SqlConnectionOpen("Planning_NW");
                List<SqlParameter> aParameters = new List<SqlParameter>();
                aParameters.Add(new SqlParameter("@YearId", yearId));
                aParameters.Add(new SqlParameter("@MonthId", monthId));
                DataTable dt = GetDataTable("ShipmentList_sp", aParameters, true);
                return dt;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                SqlConnectionClose();
            }
        }


        public dynamic GetAllPlanGanntChart(StyleListParameters entity)
        {
            try
            {
                SqlConnectionOpen("Planning_NW");
                List<SqlParameter> aParameters = new List<SqlParameter>();
                aParameters.Add(new SqlParameter("@PoNo", entity.PoNo));
                aParameters.Add(new SqlParameter("@STYLENO", entity.StyleNo));
                aParameters.Add(new SqlParameter("@BUYER", entity.Buyer));
                aParameters.Add(new SqlParameter("@MARCHANT", entity.Marchant));
                aParameters.Add(new SqlParameter("@TEAM", entity.TeamHead));
                aParameters.Add(new SqlParameter("@PlanFromDate", entity.OrderFromDate.ToString() == "1/1/0001 12:00:00 AM" ? null : entity.OrderFromDate));
                aParameters.Add(new SqlParameter("@PlanToDate", entity.OrderToDate.ToString() == "1/1/0001 12:00:00 AM" ? null : entity.OrderToDate));
                aParameters.Add(new SqlParameter("@DeliveryFromDate", entity.DeliveryFromDate.ToString() == "1/1/0001 12:00:00 AM" ? null : entity.DeliveryFromDate));
                aParameters.Add(new SqlParameter("@DeliveryToDate", entity.DeliveryToDate.ToString() == "1/1/0001 12:00:00 AM" ? null : entity.DeliveryToDate));
                DataTable dt = GetDataTable("StylePlanGanntChart", aParameters, true);
                return dt;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                SqlConnectionClose();
            }
        }


        public dynamic FactoryWiseProSumm(DateTime productionDate)
        {
            try
            {
                SqlConnectionOpen("Planning_NW");
                List<SqlParameter> aParameters = new List<SqlParameter>();
                aParameters.Add(new SqlParameter("@ProductionDate", productionDate));
                DataTable dt = GetDataTable("FactoryWiseKnittProSummNew_sp", aParameters, true);
                return dt;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                SqlConnectionClose();
            }
        }


        public dynamic GetAllPlanStatus()
        {
            try
            {
                SqlConnectionOpen("Planning_NW");

                DataTable ds = GetDataTable("AllPlanStatus_sp", true);
                return ds;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                SqlConnectionClose();
            }
        }


        public dynamic ItemCatagoryList()
        {
            try
            {
                SqlConnectionOpen("Planning_NW");

                DataTable ds = GetDataTable("MasterItemList_sp", true);
                return ds;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                SqlConnectionClose();
            }
        }

        public dynamic UpdateCatagorySeg(int cataId, string cataOp)
        {
            try
            {
                SqlConnectionOpen("Planning_NW");
                List<SqlParameter> aParameters = new List<SqlParameter>();
                aParameters.Add(new SqlParameter("@MasterCataId", cataId));
                aParameters.Add(new SqlParameter("@OperationSeg", cataOp));
                var ds = SaveData("UpdateMasterCatagory_sp", aParameters, true);
                return ds;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                SqlConnectionClose();
            }
        }

        public dynamic StyleType()
        {
            try
            {
                SqlConnectionOpen("Planning_NW");

                DataTable ds = GetDataTable("StyleType_sp", true);
                return ds;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                SqlConnectionClose();
            }
        }

        public dynamic GetAllBuyer()
        {
            try
            {
                SqlConnectionOpen("Planning_NW");
                //List<SqlParameter> aParameters = new List<SqlParameter>();
                //aParameters.Add(new SqlParameter("@id", id));

                DataTable dt = GetDataTable("GetBuyerList_sp", true);
                return dt;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                SqlConnectionClose();
            }
        }

        public dynamic GetAllBookingHistoryList(StyleListParameters entity)
        {
            try
            {
                SqlConnectionOpen("Planning_NW");
                List<SqlParameter> aParameters = new List<SqlParameter>();
                aParameters.Add(new SqlParameter("@PoNo", entity.PoNo));
                aParameters.Add(new SqlParameter("@STYLENO", entity.StyleNo));
                aParameters.Add(new SqlParameter("@BUYER", entity.Buyer));
                aParameters.Add(new SqlParameter("@MARCHANT", entity.Marchant));
                aParameters.Add(new SqlParameter("@TEAM", entity.TeamHead));
                aParameters.Add(new SqlParameter("@OrderFromDate", entity.OrderFromDate.ToString() == "1/1/0001 12:00:00 AM" ? null : entity.OrderFromDate));
                aParameters.Add(new SqlParameter("@OrderToDate", entity.OrderToDate.ToString() == "1/1/0001 12:00:00 AM" ? null : entity.OrderToDate));
                aParameters.Add(new SqlParameter("@DeliveryFromDate", entity.DeliveryFromDate.ToString() == "1/1/0001 12:00:00 AM" ? null : entity.DeliveryFromDate));
                aParameters.Add(new SqlParameter("@DeliveryToDate", entity.DeliveryToDate.ToString() == "1/1/0001 12:00:00 AM" ? null : entity.DeliveryToDate));

                DataTable dt = GetDataTable("GetAllBookingHistoryList_sp", aParameters, true);
                return dt;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                SqlConnectionClose();
            }
        }
        public DataTable GetPlanningGanntChart( DateTime? startDate, DateTime? endDate, int? factoryId , string styleNumber=null)
        {
            try
            {
                SqlConnectionOpen("Planning_NW");
                if( startDate==null && styleNumber == "")
                {
                    startDate = Convert.ToDateTime(DateTime.Now.Date);
                    endDate = Convert.ToDateTime(DateTime.Now.Date);
                }
                List<SqlParameter> aParameters = new List<SqlParameter>();
                aParameters.Add(new SqlParameter("@StartDate", startDate));
                aParameters.Add(new SqlParameter("@EndDate", endDate));
                aParameters.Add(new SqlParameter("@FactoryId", factoryId));
                aParameters.Add(new SqlParameter("@StyleNumber", styleNumber));
                DataTable dt = GetDataTable("GetFactoryGanntChart_sp", aParameters, true);
                return dt;
            }
            catch (Exception)
            {
                throw;
                //e.ToString();
            }
            finally
            {
                SqlConnectionClose();
            }
        }

        public dynamic DailyLinkingEfficiency(DateTime productionDate)
        {
            try
            {
                SqlConnectionOpen("Planning_NW");
                List<SqlParameter> aParameters = new List<SqlParameter>();
                aParameters.Add(new SqlParameter("@ProductionDate", productionDate));
                DataTable dt = GetDataTable("DailyLinkingEff_sp", aParameters, true);
                return dt;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                SqlConnectionClose();
            }
        }
    }
}
