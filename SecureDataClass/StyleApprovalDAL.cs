using Microsoft.AspNetCore.Http;

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
    public class StyleApprovalDAL : DataAccessLayer
    {

        public dynamic GetStyleApprovalData(int StyleNo)
        {
            try
            {
                SqlConnectionOpen("Planning_NW");
                List<SqlParameter> aParameters = new List<SqlParameter>();
                aParameters.Add(new SqlParameter("@StlCode", StyleNo));
                DataSet ds = GetDataSet("GetStyleDetailsById_sp", aParameters, true);
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
        public dynamic StyleInfoByStyleNo(string StyleNo)
        {
            try
            {
                SqlConnectionOpen("Planning_NW");
                List<SqlParameter> aParameters = new List<SqlParameter>();
                aParameters.Add(new SqlParameter("@StlCode", StyleNo));
                DataSet ds = GetDataSet("GetStyleByStyleNo_sp", aParameters, true);
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
        public dynamic GetCoordinator()
        {
            try
            {
                SqlConnectionOpen("Planning_NW");
                DataTable ds = GetDataTable("CoordinatorList_sp", true);
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
        public dynamic GetRatioType()
        {
            try
            {
                SqlConnectionOpen("Planning_NW");
                DataTable ds = GetDataTable("RatioType_sp", true);
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
        public dynamic GetAllStyleFApp()
        {
            try
            {
                SqlConnectionOpen("Planning_NW");

                DataTable dt = GetDataTable("stl_cap_PlnApvPending", true);
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
        
        public dynamic GetAllStyleSpaceFSApp()
        {
            try
            {
                SqlConnectionOpen("Planning_NW");

                DataTable dt = GetDataTable("stl_spc_PlnApvPending", true);
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

        public dynamic SaveStyleApproval(StyleApproval entity, string userName, int userId)
        {
            try
            {

                SqlConnectionOpen("Planning_NW");
                entity.PoApprovals.ForEach(c => { c.UserId = userId; c.CreateDate = DateTime.Now; });
                List<SqlParameter> aParameters = new List<SqlParameter>();
                aParameters.Add(new SqlParameter("@STLCODE", entity.StlCod));
                aParameters.Add(new SqlParameter("@Remrks", entity.Remarks));
                aParameters.Add(new SqlParameter("@PLNBY", userName));
                aParameters.Add(new SqlParameter("@pln_knit", entity.KnStartDate));
                aParameters.Add(new SqlParameter("@pln_link", entity.LnStartDate));
                aParameters.Add(new SqlParameter("@pln_Finis", entity.FnStartDate));
                aParameters.Add(new SqlParameter("@pln_insp", entity.InsStartDate));
                aParameters.Add(new SqlParameter("@apvsts", entity.BooknigOption));
                aParameters.Add(new SqlParameter("@OrderRatioCod", entity.RatioType));
                aParameters.Add(new SqlParameter("@CoOrdntrID", entity.CoOrdinatior));
                //aParameters.Add(new SqlParameter("@POList", entity.PoApprovals));

                var data = SaveData("stl_cap_plnApv", aParameters);
                if (data == true)
                {
                    List<SqlParameter> bParameters = new List<SqlParameter>();
                    bParameters.Add(new SqlParameter("@PoList", ListToDatatable.ToDataTable(entity.PoApprovals)));
                    data = SaveData("SavePO_sp", bParameters);
                }
                else
                {
                    SqlConnectionClose(true);
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
        public dynamic StyleDeny(StyleApproval entity, string userName)
        {
            try
            {

                SqlConnectionOpen("Planning_NW");
                if(entity.Remarks==null|| entity.Remarks == "")
                {
                    entity.Remarks = "Deny";
                }
                List<SqlParameter> aParameters = new List<SqlParameter>();
                aParameters.Add(new SqlParameter("@STLCODE", entity.StlCod));
                aParameters.Add(new SqlParameter("@Remrks", entity.Remarks));
                aParameters.Add(new SqlParameter("@PLNBY", userName));
                aParameters.Add(new SqlParameter("@DnyMainReason", entity.DenyReason));

                var data = SaveData("stl_cap_plndNY", aParameters);

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
        public dynamic NumberOfPendinStyle()
        {
            try
            {
                SqlConnectionOpen("Planning_NW");

                DataTable dt = GetDataTable("PendingStyleFCapAppCount", true);
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
        public dynamic NumberOfPendinStyleFPlanning()
        {
            try
            {
                SqlConnectionOpen("Planning_NW");

                DataTable dt = GetDataTable("NoOfStyleFPlanning", true);
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

        public dynamic UpdatePlanMonth(PoApproval entity, int userId)
        {
            try
            {

                SqlConnectionOpen("Planning_NW");
                List<SqlParameter> aParameters = new List<SqlParameter>();
                aParameters.Add(new SqlParameter("@PoConfirmId", entity.StlCod));
                aParameters.Add(new SqlParameter("@NewPlanDate", entity.InitialPlaneDate));
                aParameters.Add(new SqlParameter("@UpdateBy", userId));
                aParameters.Add(new SqlParameter("@UpdateDate", entity.CreateDate));

                var data = SaveData("UpdateNewPlanDate", aParameters);

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

        public dynamic SaveInitialTAndA(InitialTAndA entity, string userName, int userId)
        {
            try
            {

                SqlConnectionOpen("Planning_NW");
                List<SqlParameter> aParameters = new List<SqlParameter>();
                aParameters.Add(new SqlParameter("@stlid", entity.StlCod));
                aParameters.Add(new SqlParameter("@YrnOrddt", entity.YarnOrderDate));
                aParameters.Add(new SqlParameter("@YrnTrnsitdt", entity.YarnTranDate));
                aParameters.Add(new SqlParameter("@YrnColapvdt", entity.ColorAppDate));
                aParameters.Add(new SqlParameter("@tstApvdt", entity.TestAppDate));
                aParameters.Add(new SqlParameter("@BlkHngrapvdt", entity.BulkHangAppDate));
                aParameters.Add(new SqlParameter("@Smpapvdt", entity.SampleAppDate));
                aParameters.Add(new SqlParameter("@YrnInhsDt", entity.YarnInHDate));
                aParameters.Add(new SqlParameter("@filehndovrdt", entity.FileHDate));
                aParameters.Add(new SqlParameter("@SewitmIH", entity.SiInHDate));
                aParameters.Add(new SqlParameter("@PakItmIH", entity.PackItemInHDate));
                aParameters.Add(new SqlParameter("@Yrnprclead", entity.YarnPurLeadTime));
                aParameters.Add(new SqlParameter("@ProdLead", entity.ProLeadTime));
                aParameters.Add(new SqlParameter("@revby", userName));
                aParameters.Add(new SqlParameter("@remarks", "Booking Time T&A Change"));

                var data = SaveData("StyleBookingTAndAModify_sp", aParameters);
                
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
        public dynamic NumberOfEventPendingFPlanning()
        {
            try
            {
                SqlConnectionOpen("Planning_NW");

                DataSet dt = GetDataSet("planningEvent_sp",true);
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
