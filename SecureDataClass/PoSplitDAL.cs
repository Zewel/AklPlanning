
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
    public class PoSplitDAL: DataAccessLayer
    {
        public dynamic SaveAllPoSPlit(List<PoApproval> entity)
        {
            try
            {

                SqlConnectionOpen("Planning_NW");
                List<SqlParameter> aParameters = new List<SqlParameter>();
                aParameters.Add(new SqlParameter("@PoSPlit", ListToDatatable.ToDataTable(entity) ));
                var dt = SaveData("SavePOSPlit_sp", aParameters);
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
