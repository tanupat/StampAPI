using Parking.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Configuration;

namespace Parking.Models
{
    public class clsDatabase
    {
        private SqlConnection objConn;
        private SqlCommand objCmd;
        private SqlTransaction Trans;
        private string strConnString;
        private WarpsystemEntities db = new WarpsystemEntities();
        public clsDatabase()
        {

            strConnString = db.Database.Connection.ConnectionString.ToString();
            //ConfigurationManager.AppSettings["connectString"].ToString();
            //db.Database.Connection.ConnectionString.ToString();
        }

        public SqlDataReader QueryDataReader(String strSQL)
        {
            SqlDataReader dtReader;
            objConn = new SqlConnection();
            objConn.ConnectionString = strConnString;
            objConn.Open();

            objCmd = new SqlCommand(strSQL, objConn);
            dtReader = objCmd.ExecuteReader();
            return dtReader; //*** Return DataReader ***//
        }

        public DataSet QueryDataSet(String strSQL)
        {
            DataSet ds = new DataSet();
            SqlDataAdapter dtAdapter = new SqlDataAdapter();
            objConn = new SqlConnection();
            objConn.ConnectionString = strConnString;
            objConn.Open();

            objCmd = new SqlCommand();
            objCmd.Connection = objConn;
            objCmd.CommandText = strSQL;
            objCmd.CommandType = CommandType.Text;

            dtAdapter.SelectCommand = objCmd;
            dtAdapter.Fill(ds);
            return ds;   //*** Return DataSet ***//
        }

        public DataTable QueryDataTable(String strSQL)
        {
            try {
                SqlDataAdapter dtAdapter;
                DataTable dt = new DataTable();
                objConn = new SqlConnection();
                objConn.ConnectionString = strConnString;
                objConn.Open();

                dtAdapter = new SqlDataAdapter(strSQL, objConn);
                dtAdapter.Fill(dt);
                objConn.Close();
                return dt; //*** Return DataTable ***//
            } catch (Exception ex) {
                throw ex;
            }
           
        }

        public string QueryExecuteNonQuery(String strSQL)
        {
            objConn = new SqlConnection();
            objConn.ConnectionString = strConnString;
            objConn.Open();

            try
            {
                objCmd = new SqlCommand();
                objCmd.Connection = objConn;
                objCmd.CommandType = CommandType.Text;
                objCmd.CommandText = strSQL;

                objCmd.ExecuteNonQuery();
                return "OK"; //*** Return True ***//
            }
            catch (Exception ex)
            {
                return ex.Message; //*** Return False ***//
            }
        }

        public DataTable StoreQuery(string sql, SqlParameterCollection parameters)
        {
            try
            {
                DataTable dt = new DataTable();

                SqlDataAdapter dtAdapter = new SqlDataAdapter();
                objConn = new SqlConnection();
                objConn.ConnectionString = strConnString;
                objConn.Open();

                objCmd = new SqlCommand();
                objCmd.Connection = objConn;
                objCmd.CommandText = sql;
                objCmd.CommandType = CommandType.StoredProcedure;
                foreach (SqlParameter param in parameters)
                {
                    objCmd.Parameters.Add(new SqlParameter(param.ParameterName, param.Value));
                }

                dtAdapter.SelectCommand = objCmd;
                dtAdapter.Fill(dt);

                objCmd.Dispose();
                objConn.Close();


                return dt;   //*** Return DataSet ***//

            }
            catch (Exception ex)
            {
                throw ex; //*** Return False ***//
            }
            finally
            {
                objConn.Close();
                objConn.Dispose();
                SqlConnection.ClearPool(objConn);
            }

        }


        public DataSet StoreQueryDataSet(string sql, SqlParameterCollection parameters)
        {
            try
            {
                DataSet dt = new DataSet();

                SqlDataAdapter dtAdapter = new SqlDataAdapter();
                objConn = new SqlConnection();
                objConn.ConnectionString = strConnString;
                objConn.Open();

                objCmd = new SqlCommand();
                objCmd.Connection = objConn;
                objCmd.CommandText = sql;
                objCmd.CommandType = CommandType.StoredProcedure;
                foreach (SqlParameter param in parameters)
                {
                    objCmd.Parameters.Add(new SqlParameter(param.ParameterName, param.Value));
                }

                dtAdapter.SelectCommand = objCmd;
                dtAdapter.Fill(dt);

                objCmd.Dispose();
                objConn.Close();


                return dt;   //*** Return DataSet ***//

            }
            catch (Exception ex)
            {
                throw ex; //*** Return False ***//
            }
            finally
            {
                objConn.Close();
                objConn.Dispose();
                SqlConnection.ClearPool(objConn);
            }
        }

        public string QueryExecuteNonQueryStor(String strSQL, SqlParameterCollection parameters)
        {
            objConn = new SqlConnection();
            objConn.ConnectionString = strConnString;
            objConn.Open();


            try
            {
                objCmd = new SqlCommand();

                objCmd.Connection = objConn;
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = strSQL;
                foreach (SqlParameter param in parameters)
                {
                    objCmd.Parameters.Add(new SqlParameter(param.ParameterName, param.Value));
                }


                objCmd.ExecuteNonQuery();
                return "OK";

            }
            catch (Exception ex)
            {
                return ex.Message; //*** Return False ***//
            }
            finally
            {
                objConn.Close();
                objConn.Dispose();
                SqlConnection.ClearPool(objConn);
            }


        }

        public Object QueryExecuteScalar(String strSQL)
        {
            Object obj;
            objConn = new SqlConnection();
            objConn.ConnectionString = strConnString;
            objConn.Open();

            try
            {
                objCmd = new SqlCommand();
                objCmd.Connection = objConn;
                objCmd.CommandType = CommandType.Text;
                objCmd.CommandText = strSQL;

                obj = objCmd.ExecuteScalar();  //*** Return Scalar ***//
                return obj;
            }
            catch (Exception)
            {
                return null; //*** Return Nothing ***//
            }
        }
        public void TransStart()
        {
            objConn = new SqlConnection();
            objConn.ConnectionString = strConnString;
            objConn.Open();
            Trans = objConn.BeginTransaction(IsolationLevel.ReadCommitted);
        }
        public void TransExecute(String strSQL)
        {
            objCmd = new SqlCommand();
            objCmd.Connection = objConn;
            objCmd.Transaction = Trans;
            objCmd.CommandType = CommandType.Text;
            objCmd.CommandText = strSQL;
            objCmd.ExecuteNonQuery();
        }
        public void TransRollBack()
        {
            Trans.Rollback();
        }

        public void TransCommit()
        {
            Trans.Commit();
        }

        public void Close()
        {
            objConn.Close();
            objConn = null;
        }
    }
}