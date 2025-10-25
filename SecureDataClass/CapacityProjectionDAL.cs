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
    public class CapacityProjectionDAL:DataAccessLayer
    {
        public dynamic ProjectionProcess(int year, int tolaranceTiming, int user)
        {
            try
            {
                _ = SqlConnectionOpen("Planning_NW");
                List<SqlParameter> aParameters = new List<SqlParameter>();
                aParameters.Add(new SqlParameter("@Year", year));
                //aParameters.Add(new SqlParameter("@AvgTiming", avgTiming));
                aParameters.Add(new SqlParameter("@TolaranceTiming", tolaranceTiming));
                aParameters.Add(new SqlParameter("@CreateBy",user ));

                bool dt = SaveData("sp_CapacityProjcetion", aParameters);
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


        public DataTable GetAllprojectinoList(int yearId)
        {
            try
            {
                 SqlConnectionOpen("Planning_NW");
                List<SqlParameter> aParameters = new List<SqlParameter>();
                aParameters.Add(new SqlParameter("@YearId", yearId));
                var dt = new DataTable("YearlyCapacityProjectionList");
                 dt = GetDataTable("CapacityProjectionList_sp",aParameters, true);
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
        public dynamic EditProjectionProcess(int capacityProjectionId, int user)
        {
            try
            {
                _ = SqlConnectionOpen("Planning_NW");
                List<SqlParameter> aParameters = new List<SqlParameter>();
               
                aParameters.Add(new SqlParameter("@CapacityProjectionId", capacityProjectionId));
                aParameters.Add(new SqlParameter("@UserId", user));

                bool dt = SaveData("EditCapacityProjection_sp", aParameters);
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
