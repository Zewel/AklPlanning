
using SweaterPlanning.DllClass;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace SweaterPlanning.SecureDataClass
{
    public class CapacityAllocationDAL: DataAccessLayer
    {
        //EncryptionDecryption encryptionDecryption = new EncryptionDecryption();
        public dynamic GetAllAllocationList(int yearId)
        {
            try
            {
                SqlConnectionOpen("Planning_NW");
                List<SqlParameter> aParameters = new List<SqlParameter>();
                aParameters.Add(new SqlParameter("@YearId", yearId));
                DataTable dt = GetDataTable("CapacityAllocationList_sp",aParameters, true);
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
        
        public dynamic GetAllAllocationSummery(int yearId)
        {
            try
            {
                SqlConnectionOpen("Planning_NW");
                List<SqlParameter> aParameters = new List<SqlParameter>();
                aParameters.Add(new SqlParameter("@YearId", yearId));
                DataSet dt = GetDataSet("CapacityAllocationSummery_sp", aParameters, true);

                //string aaa = "WWWrYb2pSP5/HoVzDNHYHg===";
                //var data = EncryptionDecryption.DecryptText(aaa);

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
        //public dynamic AllocationValidation(int buyerId,int marchantId,int yearId,int monthId,int gaugeId)
        //{
        //    try
        //    {
        //        SqlConnectionOpen("Planning_NW");
        //        List<SqlParameter> aParameters = new List<SqlParameter>();
        //        aParameters.Add(new SqlParameter("@BuyerId", buyerId));
        //        aParameters.Add(new SqlParameter("@Marchantid", marchantId));
        //        aParameters.Add(new SqlParameter("@YearId", yearId));
        //        aParameters.Add(new SqlParameter("@MonthId", monthId));
        //        aParameters.Add(new SqlParameter("@GaugeId", gaugeId));
        //        DataTable dt = GetDataTable("CapacityAllocationValidation", aParameters, true);
        //        return dt;
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
        public dynamic AllocationValidation(int buyerId,int marchantId,int yearId,int monthId,int GaugeGroupId)
        {
            try
            {
                SqlConnectionOpen("Planning_NW");
                List<SqlParameter> aParameters = new List<SqlParameter>();
                aParameters.Add(new SqlParameter("@BuyerId", buyerId));
                aParameters.Add(new SqlParameter("@Marchantid", marchantId));
                aParameters.Add(new SqlParameter("@YearId", yearId));
                aParameters.Add(new SqlParameter("@MonthId", monthId));
                aParameters.Add(new SqlParameter("@GaugeGroupId", GaugeGroupId));
                DataTable dt = GetDataTable("CapacityAllocationValidation", aParameters, true);
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
        public dynamic AllocationAssistant(int buyerId,int marchantId,int yearId,int monthId,int gaugeGroup)
        {
            try
            {
               
                SqlConnectionOpen("Planning_NW");
                List<SqlParameter> aParameters = new List<SqlParameter>();
                aParameters.Add(new SqlParameter("@BuyerId", buyerId));
                aParameters.Add(new SqlParameter("@Marchantid", marchantId));
                aParameters.Add(new SqlParameter("@YearId", yearId));
                aParameters.Add(new SqlParameter("@MonthId", monthId));
                aParameters.Add(new SqlParameter("@GaugeGroup", gaugeGroup));
                DataSet dt = GetDataSet("AllocationSummaryAssistant_sp", aParameters, true);

                


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


        public dynamic EditAllocateData(string buyerName, string marchantName, string yearName, string gaugeName)
        {
            try
            {
                SqlConnectionOpen("Planning_NW");
                List<SqlParameter> aParameters = new List<SqlParameter>();
                aParameters.Add(new SqlParameter("@BuyerName", buyerName));
                aParameters.Add(new SqlParameter("@MarchantName", marchantName));
                aParameters.Add(new SqlParameter("@YearName", yearName));
                aParameters.Add(new SqlParameter("@GaugeName", gaugeName));
                DataTable dt = GetDataTable("CapacityAllocationById", aParameters, true);
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

        public dynamic SubmitEditAllocateData(int allocateId, int allocateqty, int userId)
        {
            try
            {
                SqlConnectionOpen("Planning_NW");
                List<SqlParameter> aParameters = new List<SqlParameter>();
                aParameters.Add(new SqlParameter("@AllocateId", allocateId));
                aParameters.Add(new SqlParameter("@AllocateQty", allocateqty));
                aParameters.Add(new SqlParameter("@UserId", userId));
                aParameters.Add(new SqlParameter("@UpdateDate", DateTime.Now));
                var dt = SaveDataReturnPrimaryKey("EditAllocationQty_sp", aParameters, true);
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
        
        public dynamic YearlyBookingCapacity(int yearId, int monthId=0)
        {
            try
            {
                SqlConnectionOpen("Planning_NW");
                List<SqlParameter> aParameters = new List<SqlParameter>();
                aParameters.Add(new SqlParameter("@yearId", yearId));
                aParameters.Add(new SqlParameter("@MonthId", monthId));

                var dt = GetDataTable("YearlyBookingCapacity_sp", aParameters, true);
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
        public dynamic YearlyManagersCapacity(int yearId, int marchantId, int monthId=0)
        {
            try
            {
                SqlConnectionOpen("Planning_NW");
                List<SqlParameter> aParameters = new List<SqlParameter>();
                aParameters.Add(new SqlParameter("@YearId", yearId));
                aParameters.Add(new SqlParameter("@MarchantId", marchantId));
                aParameters.Add(new SqlParameter("@MonthId", monthId));

                var dt = GetDataTable("MarchantWiseCapacityAnalysis_sp", aParameters, true);
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
