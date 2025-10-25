
using SweaterPlanning.DllClass;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace SweaterPlanning.SecureDataClass
{
    public class LogInDAL:DataAccessLayer
    {
        public dynamic LogIn(string email, string password)
        {
            try
            {

                var result = System.Text.Encoding.UTF8.GetBytes(password);
                var mainText = System.Convert.ToBase64String(result);

                var text = System.Convert.FromBase64String("S2licmlhNjA=");
                var mtext = System.Text.Encoding.UTF8.GetString(text);
                SqlConnectionOpen("Planning_NW");
                List<SqlParameter> aParameters = new List<SqlParameter>();
                aParameters.Add(new SqlParameter("@Email", email));
                aParameters.Add(new SqlParameter("@Password", mainText));

                DataTable dt = GetDataTable("sp_UserAuthentication",aParameters, true);
                return dt;
            }
            catch (Exception e )
            {
                var exe = e.ToString();
                throw;
            }
            finally
            {
                SqlConnectionClose();
            }
        }
    }
}
