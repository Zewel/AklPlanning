using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace SweaterPlanning.DllClass
{
    public class DataAccessLayer
    {
        private SqlConnection sqlConnection = null;
        private SqlCommand sqlCommand = null;
        private SqlDataReader sqlDataReader = null;
        private SqlTransaction sqlTransaction = null;
        private SqlDataAdapter sqlDataAdapter = null;
        private const int CommandTimeout = 3600000;
        private bool isException;
        private bool returnValue = true;
        private string ConnectionString(string database)
        {
            return @"data source=" + SqlUserAccess.DataSource + ";Initial Catalog=" + database +
                   ";Integrated Security=false; User Id=" +
                   SqlUserAccess.UserName + "; password=" + SqlUserAccess.PassWord + ";";
        }
        public bool SqlConnectionOpen(string database)
        {
            try
            {
                sqlConnection = new SqlConnection(ConnectionString(database));

                if (sqlConnection.State != ConnectionState.Open)
                {
                    sqlConnection.Open();
                    sqlTransaction = sqlConnection.BeginTransaction();

                }
            }
            catch (SqlException)
            {
                isException = true;
                throw;
            }
            finally
            {
                if (isException)
                {
                    returnValue = false;
                }

            }
            return returnValue;
        }
        public bool SqlConnectionClose(bool IsRollBack = false)
        {
            try
            {
                if (sqlConnection.State == ConnectionState.Open)
                {
                    if (sqlTransaction != null)
                    {
                        if (sqlDataReader != null)
                        {
                            sqlDataReader.Close();

                        }
                        if (IsRollBack)
                        {
                            sqlTransaction.Rollback();
                        }
                        else
                        {
                            sqlTransaction.Commit();
                        }
                        sqlTransaction.Dispose();
                        if (sqlCommand != null)
                        {
                            sqlCommand.Dispose();
                        }

                    }
                    sqlConnection.Close();
                }

            }
            catch (SqlException)
            {
                isException = true;
                throw;
            }
            finally
            {
                if (isException)
                {
                    returnValue = false;
                }

            }

            return returnValue;
        }
        public SqlDataReader GetSqlDataReader(string StoreProcedure, bool IsBigData = false)
        {
            try
            {
                sqlCommand = new SqlCommand
                {
                    Connection = sqlConnection,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = StoreProcedure,
                    Transaction = sqlTransaction
                };
                if (IsBigData)
                {
                    sqlCommand.CommandTimeout = CommandTimeout;
                }

                sqlDataReader = sqlCommand.ExecuteReader();
            }
            catch (SqlException)
            {
                isException = true;
                sqlDataReader = null;
                throw;
            }
            finally
            {
                if (isException)
                {
                    SqlConnectionClose(true);
                }

            }
            return sqlDataReader;
        }
        public SqlDataReader GetSqlDataReader(string StoreProcedure, List<SqlParameter> SqlParameterList, bool IsBigData = false)
        {
            try
            {
                sqlCommand = new SqlCommand
                {
                    Connection = sqlConnection,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = StoreProcedure,
                    Transaction = sqlTransaction
                };

                sqlCommand.Parameters.Clear();
                sqlCommand.Parameters.AddRange(SqlParameterList.ToArray());
                if (IsBigData)
                {
                    sqlCommand.CommandTimeout = CommandTimeout;
                }



                sqlDataReader = sqlCommand.ExecuteReader();
                sqlCommand.Parameters.Clear();
            }
            catch (SqlException)
            {
                isException = true;
                sqlDataReader = null;
                throw;
            }
            finally
            {
                sqlCommand.Parameters.Clear();
                sqlCommand.Dispose();
                if (isException)
                {
                    SqlConnectionClose(true);
                }

            }
            return sqlDataReader;
        }
        public dynamic GetDataTable(string StoreProcedure, List<SqlParameter> SqlParameterList, bool IsBigData = false)
        {
            DataTable dt = new DataTable();

            try
            {
                DataSet ds = new DataSet();
                sqlCommand = new SqlCommand
                {
                    Connection = sqlConnection,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = StoreProcedure,
                    Transaction = sqlTransaction
                };

                sqlCommand.Parameters.Clear();
                sqlCommand.Parameters.AddRange(SqlParameterList.ToArray());
                if (IsBigData)
                {
                    sqlCommand.CommandTimeout = CommandTimeout;
                }
                //DataTable dt1 = new DataTable();
                sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                sqlDataAdapter.Fill(ds);
                //sqlDataAdapter.Fill(dt);


                dt = ds.Tables[0];

            }
            catch (SqlException)
            {
                isException = true;
                dt = null;
                throw;
            }
            finally
            {
                sqlCommand.Parameters.Clear();
                if (isException)
                {
                    SqlConnectionClose(true);
                }
            }
            return dt;
        }
        private bool ExecuteNonQueryData(string StoreProcedure, List<SqlParameter> SqlParameterList, bool IsBigData = false)
        {
            try
            {
                sqlCommand = new SqlCommand
                {
                    Connection = sqlConnection,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = StoreProcedure,
                    Transaction = sqlTransaction
                };
                sqlCommand.Parameters.Clear();
                sqlCommand.Parameters.AddRange(SqlParameterList.ToArray());
                if (IsBigData)
                {
                    sqlCommand.CommandTimeout = CommandTimeout;
                }
                sqlCommand.ExecuteNonQuery();
            }
            catch (SqlException)
            {
                returnValue = false;
                isException = true;
                throw;
            }
            finally
            {
                sqlCommand.Parameters.Clear();
                if (isException)
                {
                    SqlConnectionClose(true);
                }
            }

            return returnValue;
        }
        public bool SaveData(string StoreProcedure, List<SqlParameter> SqlParameterList, bool IsBigData = false)
        {
            try
            {
                returnValue = ExecuteNonQueryData(StoreProcedure, SqlParameterList, IsBigData);
            }
            catch (SqlException)
            {
                returnValue = false;
                throw;
            }
            return returnValue;
        }

        public DataTable GetDataTable(string StoreProcedure, bool IsBigData = false)
        {
            DataTable dt = new DataTable();

            try
            {
                DataSet ds = new DataSet();
                sqlCommand = new SqlCommand
                {
                    Connection = sqlConnection,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = StoreProcedure,
                    Transaction = sqlTransaction
                };

                if (IsBigData)
                {
                    sqlCommand.CommandTimeout = CommandTimeout;
                }
                sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                sqlDataAdapter.Fill(ds);
                dt = ds.Tables[0];
            }
            catch (SqlException)
            {
                isException = true;
                dt = null;
                throw;
            }
            finally
            {
                if (isException)
                {
                    SqlConnectionClose(true);
                }

            }
            return dt;
        }
        public DataSet GetDataSet(string StoreProcedure, bool IsBigData = false)
        {
            DataSet ds = new DataSet();
            try
            {

                sqlCommand = new SqlCommand
                {
                    Connection = sqlConnection,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = StoreProcedure,
                    Transaction = sqlTransaction
                };

                if (IsBigData)
                {
                    sqlCommand.CommandTimeout = CommandTimeout;
                }
                sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                sqlDataAdapter.Fill(ds);
            }
            catch (SqlException)
            {
                isException = true;
                ds = null;
                throw;
            }
            finally
            {
                if (isException)
                {
                    SqlConnectionClose(true);
                }

            }
            return ds;
        }
        public DataSet GetDataSet(string StoreProcedure, List<SqlParameter> SqlParameterList, bool IsBigData = false)
        {
            DataSet ds = new DataSet();
            try
            {

                sqlCommand = new SqlCommand
                {
                    Connection = sqlConnection,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = StoreProcedure,
                    Transaction = sqlTransaction
                };

                sqlCommand.Parameters.Clear();
                sqlCommand.Parameters.AddRange(SqlParameterList.ToArray());
                if (IsBigData)
                {
                    sqlCommand.CommandTimeout = CommandTimeout;
                }
                sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                sqlDataAdapter.Fill(ds);

            }
            catch (SqlException)
            {
                isException = true;
                ds = null;
                throw;
            }
            finally
            {
                sqlCommand.Parameters.Clear();
                if (isException)
                {
                    SqlConnectionClose(true);
                }

            }
            return ds;
        }

        public int SaveDataReturnPrimaryKey(string StoreProcedure, List<SqlParameter> SqlParameterList, bool IsBigData = false)
        {
            int primaryKey = 0;
            try
            {
                primaryKey = ExecuteNonQueryData(StoreProcedure, SqlParameterList, true, IsBigData);
            }
            catch (SqlException)
            {
                throw;
            }
            return primaryKey;
        }
        private int ExecuteNonQueryData(string StoreProcedure, List<SqlParameter> SqlParameterList, bool IsPrimaryKey = true, bool IsBigData = false)
        {
            int primaryKey = 0;
            try
            {
                sqlCommand = new SqlCommand();

                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.CommandText = StoreProcedure;
                sqlCommand.Transaction = sqlTransaction;

                sqlCommand.Parameters.Clear();
                sqlCommand.Parameters.AddRange(SqlParameterList.ToArray());
                if (IsBigData)
                {
                    sqlCommand.CommandTimeout = CommandTimeout;
                }
                primaryKey = Convert.ToInt32(sqlCommand.ExecuteScalar());

            }
            catch (SqlException)
            {
                returnValue = false;
                isException = true;
                throw;
            }
            finally
            {
                sqlCommand.Parameters.Clear();
                if (isException)
                {
                    SqlConnectionClose(true);
                }
            }
            return primaryKey;
        }
    }
}
