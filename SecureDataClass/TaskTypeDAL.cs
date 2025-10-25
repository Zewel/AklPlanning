
using SweaterPlanning.DllClass;
using System;
using System.Data;

namespace SweaterPlanning.SecureDataClass
{
    public class TaskTypeDAL:DataAccessLayer
    {
        public dynamic GetAll()
        {
            try
            {
                SqlConnectionOpen("DailyPlaneManagement");
                //List<SqlParameter> aParameters = new List<SqlParameter>();
                //aParameters.Add(new SqlParameter("@id", id));
                
                DataTable dt = GetDataTable("sp_GetAllTaskType", true);
                return dt;
            }
            catch (Exception )
            {

                throw ;
            }
            finally
            {
                SqlConnectionClose();
            }
        }
    }
}
