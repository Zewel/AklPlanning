
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
    public class InitialPlanningDAL : DataAccessLayer
    {
        public dynamic GetInitialPlanningList(int yearId)
        {
            try
            {
                SqlConnectionOpen("Planning_NW");
                List<SqlParameter> aParameters = new List<SqlParameter>();
                aParameters.Add(new SqlParameter("@YearId", yearId));
                DataSet dt = GetDataSet("InitialPlanningList_sp", aParameters, true);
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
        public dynamic GetWorkableMuniteFCalCuMcn(int year,int leadTime, DateTime startDate, DateTime endDate)
        {
            try
            {
                SqlConnectionOpen("Planning_NW");
                List<SqlParameter> aParameters = new List<SqlParameter>();
                aParameters.Add(new SqlParameter("@YearId", year));
                aParameters.Add(new SqlParameter("@LeadTime", leadTime));
                aParameters.Add(new SqlParameter("@StartDate", startDate));
                aParameters.Add(new SqlParameter("@EndDate", endDate));
                DataTable dt = GetDataTable("GetWorkableMuniteFCalCuMcn", aParameters, true);
                
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

        public dynamic SaveSlotAndDetails(PlanningSlotMaster entity)
        {
            try
            {
                SqlConnectionOpen("Planning_NW");
                List<SqlParameter> aParameters = new List<SqlParameter>();
                aParameters.Add(new SqlParameter("@yearId", entity.YearId));
                aParameters.Add(new SqlParameter("@FactoryId", entity.FactoryId));
                aParameters.Add(new SqlParameter("@BrandId", entity.BrandId));
                aParameters.Add(new SqlParameter("@GaugeId", entity.GaugeId));
                aParameters.Add(new SqlParameter("@LeadTime", entity.LeadTime));
                aParameters.Add(new SqlParameter("@StartDate", entity.StartDate));
                aParameters.Add(new SqlParameter("@EndDate", entity.EndDate));
                aParameters.Add(new SqlParameter("@StageId", entity.StageId));
                aParameters.Add(new SqlParameter("@CreateBy", entity.CreateBy));
                aParameters.Add(new SqlParameter("@CreateDate", entity.CreateDate));
                aParameters.Add(new SqlParameter("@MachineQty", entity.NoOfMachine));

                int pk = SaveDataReturnPrimaryKey("SaveSlotReturnPK_sp", aParameters);
                bool data = false;
                foreach (var item in entity.PlanningSlotDetails)
                {
                    //SqlConnectionOpen("Planning_NW");
                    List<SqlParameter> bParameters = new List<SqlParameter>();
                    bParameters.Add(new SqlParameter("@PlaneSlotMasterId", pk));
                    bParameters.Add(new SqlParameter("@POCod", item.POCod));
                    bParameters.Add(new SqlParameter("@PoQty", item.PoQty));
                    bParameters.Add(new SqlParameter("@SmvKn", item.SmvKn));
                    bParameters.Add(new SqlParameter("@RequiredMachine", item.RequiredMachine));
                    bParameters.Add(new SqlParameter("@Remarks", item.Remarks));
                    bParameters.Add(new SqlParameter("@userID", entity.CreateBy));
                    bParameters.Add(new SqlParameter("@CreateDate", DateTime.Now));
                    bParameters.Add(new SqlParameter("@PreviousQty", item.PreviousQty));
                    bParameters.Add(new SqlParameter("@TrialDate", item.TrialDate));
                    bParameters.Add(new SqlParameter("@ProductionPerMcn", item.ProductionPerMcn));
                    bParameters.Add(new SqlParameter("@PorductionPerDay", item.PorductionPerDay));
                    bParameters.Add(new SqlParameter("@DaybeforeKnitt", item.DaybeforeKnitt));
                    bParameters.Add(new SqlParameter("@PoSplitId", item.PoSplitId));

                    bParameters.Add(new SqlParameter("@PoOwnerType", item.PoOwnType));
                    data = SaveData("SavePlanningDetails_sp", bParameters, true);
                }
                return data;
            }
            catch (Exception)
            {
                SqlConnectionClose(true);
                throw;
            }
            finally
            {
                SqlConnectionClose();
            }
            
        }

        public dynamic GETGRN(int stlCode)
        {
            try
            {
                SqlConnectionOpen("Planning_NW");
                List<SqlParameter> aParameters = new List<SqlParameter>();
                aParameters.Add(new SqlParameter("@stlCode", stlCode));
                DataSet dt = GetDataSet("GrnConsumption_sp", aParameters, true);
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
        public dynamic GetTAndA(int stlCode)
        {
            try
            {
                SqlConnectionOpen("Planning_NW");
                List<SqlParameter> aParameters = new List<SqlParameter>();
                aParameters.Add(new SqlParameter("@stlCode", stlCode));
                DataTable dt = GetDataTable("TAndADetails_sp", aParameters, true);
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

        public dynamic GetInitialPlanningListModify(int yearId,int guageId, int brandId)
        {
            try
            {
                SqlConnectionOpen("Planning_NW");
                List<SqlParameter> aParameters = new List<SqlParameter>();
                aParameters.Add(new SqlParameter("@YearId", yearId));
                aParameters.Add(new SqlParameter("@GaugeId", guageId));
                aParameters.Add(new SqlParameter("@MachineType", brandId));
                DataTable dt = GetDataTable("InitialPlanningListModify_sp", aParameters, true);
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
