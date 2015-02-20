using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Data.SqlClient;
using System.Data.Common;
using System.Collections.Generic;

namespace DigiOzSQLBrowser.Libraries
{
    /// <summary>
    /// MSSQL Database Communication Class
    /// </summary>
    public class MSSQL
    {
        #region "Variable Declaration"
        public DataSet coDS;
        public SqlDataAdapter coDA;
        public DataTable coDT = new DataTable();
        public SqlCommandBuilder coCB;
        public SqlConnection coCN;
        public SqlDataReader coReader;
        public string cnString;
        public string csDLLVersion = "1.1.0";
        public string csErr;
        public int csErrNumber;
        #endregion

        public MSSQL(string psConnection)
        {
            cnString = psConnection;
        }


        public void openConnection()
        {
            coCN = new SqlConnection(cnString);
            try
            {
                coCN.Open();
                csErr = "";
            }
            catch (SqlException ex)
            {
                csErr = ex.Message.ToString();
            }
        }

        public void closeConnection()
        {
            coCN.Close();
        }

        public DataTable QueryDBDataset(string sql)
        {
            return _QueryDBDataset(sql, null);
        }

        public DataTable QueryDBDataset(string sql, DbParameter[] _par)
        {
            return _QueryDBDataset(sql, _par);
        }

        private DataTable _QueryDBDataset(string sql, DbParameter[] _par)
        {
            DataTable loReturnTable;
            try
            {
                SqlCommand cmd = new SqlCommand(sql, coCN);
                if (_par != null)
                {
                    foreach (DbParameter p in _par)
                    {
                        cmd.Parameters.Add((SqlParameter)p);
                    }
                }
                coDA = new SqlDataAdapter(cmd);
                coDS = new DataSet();
                coDA.SelectCommand = cmd;
                coCB = new SqlCommandBuilder(coDA);
                coDA.Fill(coDS);
                loReturnTable = coDS.Tables[0];
            }
            catch (SqlException ex)
            {
                csErr = ex.Message.ToString();
                loReturnTable = new DataTable();
            }

            return loReturnTable;
        }

        public DataSet QueryDBDatasetProc(string sql, DbParameter[] _par)
        {
            DataSet loDataSet;
            try
            {
                SqlCommand cmd = new SqlCommand(sql, coCN);
                cmd.CommandType = CommandType.StoredProcedure;
                if (_par != null)
                {
                    foreach (DbParameter p in _par)
                    {
                        cmd.Parameters.Add((SqlParameter)p);
                    }
                }
                coDA = new SqlDataAdapter(cmd);
                coDS = new DataSet();
                coDA.SelectCommand = cmd;
                coCB = new SqlCommandBuilder(coDA);
                coDA.Fill(coDS);
                loDataSet = coDS;
            }
            catch (SqlException ex)
            {
                csErr = ex.Message.ToString();
                loDataSet = new DataSet();
            }

            return loDataSet;
        }

        public DataTable QueryDBDatasetProc(string sql, out int count, DbParameter[] _par)
        {
            count = 0;
            DataTable loReturnTable = null;
            try
            {
                SqlCommand cmd = new SqlCommand(sql, coCN);
                cmd.CommandType = CommandType.StoredProcedure;
                foreach (DbParameter p in _par)
                {
                    cmd.Parameters.Add((SqlParameter)p);
                }
                coDA = new SqlDataAdapter(cmd);
                coDS = new DataSet();
                coDA.SelectCommand = cmd;
                coCB = new SqlCommandBuilder(coDA);
                coDA.Fill(coDS);
                if (coDS.Tables.Count > 0)
                {
                    loReturnTable = coDS.Tables[0];
                    if (cmd.Parameters.Contains("@Count"))
                    {
                        count = Convert.ToInt32(cmd.Parameters["@Count"].Value);
                    }
                    else
                    {
                        count = coDS.Tables[0].Rows.Count;
                    }
                }
            }
            catch (SqlException ex)
            {
                csErr = ex.Message.ToString();
                loReturnTable = new DataTable();
            }

            return loReturnTable;
        }

        public DataTable GetDBDataset(string sql, string _host, string _name, string _user, string _pass)
        {
            DataTable loReturnTable;
            openConnection();

            try
            {
                SqlCommand cmd = new SqlCommand(sql, coCN);
                coDA.SelectCommand = cmd;
                coCB = new SqlCommandBuilder(coDA);
                coDA.Fill(coDS);
                loReturnTable = coDS.Tables[0];
            }
            catch (SqlException ex)
            {
                csErr += "Error: " + ex.Message.ToString();
                csErrNumber = ex.Number;
                loReturnTable = new DataTable();
            }
            closeConnection();

            return loReturnTable;
        }

        public object ExecDBScalar(string sql)
        {
            return _ExecDBScalar(sql, null);
        }

        public object ExecDBScalar(string sql, DbParameter[] _par)
        {
            return _ExecDBScalar(sql, _par);
        }

        private object _ExecDBScalar(string sql, DbParameter[] _par)
        {
            SqlCommand cmd = new SqlCommand(sql, coCN);
            object oReturn;

            try
            {
                if (_par != null)
                {
                    foreach (DbParameter p in _par)
                    {
                        cmd.Parameters.Add((SqlParameter)p);
                    }
                }

                oReturn = cmd.ExecuteScalar();
                if (oReturn != null)
                {
                    oReturn = oReturn.ToString();
                }
            }
            catch (SqlException ex)
            {
                csErr = ex.Message.ToString();
                csErrNumber = ex.Number;
                oReturn = null;
            }

            return oReturn;
        }

        public void ExecDB(string sql)
        {
            int cnt;
            _ExecDB(sql, out cnt, null);
        }

        public void ExecDB(string sql, out int count, DbParameter[] _par)
        {
            _ExecDB(sql, out count, _par);
        }

        private void _ExecDB(string sql, out int count, DbParameter[] _par)
        {
            count = 0;
            try
            {
                SqlCommand cmd = new SqlCommand(sql, coCN);
                if (_par != null)
                {
                    foreach (DbParameter p in _par)
                    {
                        cmd.Parameters.Add((SqlParameter)p);
                    }
                }
                count = cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                csErr = ex.Message.ToString();
            }
        }

        public void UpdateDBDataset()
        {
            try
            {
                coDT = coDS.Tables[0];
                DataTable changes = coDT.GetChanges();

                coDA.Update(changes);
                coDT.AcceptChanges();
            }
            catch (SqlException ex)
            {
                csErr = ex.Message.ToString();
            }
        }

        public void DeleteDBDataset(int primarykey)
        {
            try
            {
                coDS.Tables[0].Rows[primarykey].Delete();
            }
            catch (SqlException ex)
            {
                csErr += "Error: " + ex.Message.ToString();
                csErrNumber = ex.Number;
            }
        }

        public void CreateDatabase(string DatabaseName)
        {
            try
            {
                this.ExecDB("CREATE DATABASE " + DatabaseName + ";");
            }
            catch (SqlException ex)
            {
                csErr = ex.Message.ToString();
            }
        }

        public string GetDLLVersion()
        {
            return "DigiOz MSSQL DLL Version " + csDLLVersion;
        }

        public void ExecDBProc(string sql, out int count, DbParameter[] _par)
        {
            count = 0;
            SqlCommand cmd = new SqlCommand(sql, coCN);
            cmd.CommandType = CommandType.StoredProcedure;
            foreach (DbParameter p in _par)
            {
                cmd.Parameters.Add((SqlParameter)p);
            }

            try
            {
                count = cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                csErr = ex.Message.ToString();
            }
        }

        #region "Public Properties"
        public string sErr
        {
            get
            {
                return csErr;
            }
        }
        #endregion
    }
}
