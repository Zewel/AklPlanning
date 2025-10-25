
using SweaterPlanning.DllClass;
using SweaterPlanning.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace SweaterPlanning.SecureDataClass
{
    public class AddEditPoDAL: DataAccessLayer
    {
        public dynamic StyleReName(int stlCode, string stlName, int userId)
        {
            try
            {
                SqlConnectionOpen("Planning_NW");
                List<SqlParameter> aParameters = new List<SqlParameter>();
                aParameters.Add(new SqlParameter("@stlCode", stlCode));
                aParameters.Add(new SqlParameter("@stlName", stlName));
                aParameters.Add(new SqlParameter("@userId", userId));
                var dt = GetDataTable("StyleReName_sp", aParameters, true);
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
        
        public dynamic StyleQtyEdit(int stlCode, int stlQty, int userId)
        {
            try
            {
                SqlConnectionOpen("Planning_NW");
                List<SqlParameter> aParameters = new List<SqlParameter>();
                aParameters.Add(new SqlParameter("@stlCode", stlCode));
                aParameters.Add(new SqlParameter("@stlQty", stlQty));
                aParameters.Add(new SqlParameter("@userId", userId));
                var dt = SaveData("StyleEditQty_sp", aParameters, true);
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
        
        public dynamic SavePo(StylePurchaseOrder entity, string createBy, int createId)
        {
            try
            {
                if (entity.POCod > 0)
                {
                    SqlConnectionOpen("Planning_NW");
                    List<SqlParameter> aParameters = new List<SqlParameter>();
                    aParameters.Add(new SqlParameter("@Lotno", entity.POCod));
                    aParameters.Add(new SqlParameter("@StlCode", entity.stylecode));
                    aParameters.Add(new SqlParameter("@PONo", entity.PONo));
                    aParameters.Add(new SqlParameter("@POQty", entity.POQty));
                    aParameters.Add(new SqlParameter("@BookExfty", entity.BookingExfty));
                    aParameters.Add(new SqlParameter("@Poexfty", entity.POExfty));
                    aParameters.Add(new SqlParameter("@Revexfty", entity.RevExfty));
                    aParameters.Add(new SqlParameter("@crb", createBy));
                    aParameters.Add(new SqlParameter("@CreateId", createId));
                    aParameters.Add(new SqlParameter("@Remarks", entity.Remarks));
                    aParameters.Add(new SqlParameter("@CnclQty", entity.CnclQty));
                    aParameters.Add(new SqlParameter("@CnclRemarks", entity.CnclRemarks));
                    aParameters.Add(new SqlParameter("@POColor", entity.POColor));
                    aParameters.Add(new SqlParameter("@InitialPlanDate", entity.InitialPlaneDate));
                    var dt = GetDataTable("stl_editpo_New", aParameters, true);
                    return dt;
                }
                else
                {
                    SqlConnectionOpen("Planning_NW");
                    List<SqlParameter> aParameters = new List<SqlParameter>();
                    aParameters.Add(new SqlParameter("@StlCode", entity.stylecode));
                    aParameters.Add(new SqlParameter("@PONo", entity.PONo));
                    aParameters.Add(new SqlParameter("@POQty", entity.POQty));
                    aParameters.Add(new SqlParameter("@BookExfty", entity.BookingExfty));
                    aParameters.Add(new SqlParameter("@Poexfty", entity.POExfty));
                    aParameters.Add(new SqlParameter("@ExftyRev", entity.RevExfty));
                    aParameters.Add(new SqlParameter("@InitialPlanDate", entity.InitialPlaneDate));
                    aParameters.Add(new SqlParameter("@crb", createBy));
                    aParameters.Add(new SqlParameter("@CreateId", createId));
                    aParameters.Add(new SqlParameter("@Remarks", entity.Remarks));
                    aParameters.Add(new SqlParameter("@CnclQty", entity.CnclQty));
                    aParameters.Add(new SqlParameter("@CnclRemarks", entity.CnclRemarks));
                    aParameters.Add(new SqlParameter("@POColor", entity.POColor));
                    var dt = GetDataTable("stl_POAdd_NEW", aParameters, true);
                    return dt;
                }
                
                
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


        public dynamic UnlockCosting(int stlCode, int stlQty, string userId, string unlockRemarks)
        {
            try
            {
                SqlConnectionOpen("Planning_NW");
                List<SqlParameter> aParameters = new List<SqlParameter>();
                aParameters.Add(new SqlParameter("@stlid", stlCode));
                aParameters.Add(new SqlParameter("@ordqty", stlQty));
                aParameters.Add(new SqlParameter("@revby", userId));
                aParameters.Add(new SqlParameter("@remarks", unlockRemarks));
                var dt = SaveData("Pln_stl_qty_update", aParameters, true);
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


        public dynamic StyleList(string styleName)
        {
            try
            {
                SqlConnectionOpen("Planning_NW");
                List<SqlParameter> aParameters = new List<SqlParameter>();
                aParameters.Add(new SqlParameter("@StyleName", styleName));

                var dt = GetDataTable("StyleListByStyleName_sp", aParameters, true);
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

        public dynamic DeleteMasterPo(int poId, int createBy)
        {
            try
            {
                    SqlConnectionOpen("Planning_NW");
                    List<SqlParameter> aParameters = new List<SqlParameter>();
                    aParameters.Add(new SqlParameter("@PoCode", poId));
                    aParameters.Add(new SqlParameter("@CreateBy", createBy));
                var dt = GetDataTable("DeleteMasterPo_sp", aParameters, true);
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


        public dynamic DeletePoSplit(int poId, int createBy)
        {
            try
            {
                SqlConnectionOpen("Planning_NW");
                List<SqlParameter> aParameters = new List<SqlParameter>();
                aParameters.Add(new SqlParameter("@PoId", poId));
                aParameters.Add(new SqlParameter("@DeleteBy", createBy));
                var dt = GetDataTable("DeleteSplitPo_sp", aParameters, true);
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



        public dynamic DeletePlannedPoSplit(int poId, int createBy)
        {
            try
            {
                SqlConnectionOpen("Planning_NW");
                List<SqlParameter> aParameters = new List<SqlParameter>();
                aParameters.Add(new SqlParameter("@poCode", poId));
                aParameters.Add(new SqlParameter("@DeleteBy", createBy));
                var dt = SaveData("DeletePoSplitWithPlanBoard_sp", aParameters, true);
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



        public dynamic StyleHistory(int poCode)
        {
            try
            {
                SqlConnectionOpen("Planning_NW");
                List<SqlParameter> aParameters = new List<SqlParameter>();
                aParameters.Add(new SqlParameter("@poCode", poCode));
                var dt = GetDataSet("StylePlanHistory_sp", aParameters, true);
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
