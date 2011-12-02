using System;
using System.Data;
using MySql.Data.MySqlClient;

public class dbClass
{
    private string pr_dbhost;
    private string pr_dbuser;
    private string pr_dbpass;
    private string pr_dbname;
    private string connStr;
    public MySqlConnection conn;
    public MySqlDataReader reader;
    public DataSet ds = new DataSet();
    public MySqlDataAdapter da = new MySqlDataAdapter();
    public MySqlCommandBuilder cb;
    public DataTable dt = new DataTable();
    public string err;
    public int errNumber;
    public string dllversion = "1.0.0";

    public void openConnection()
    {
        connStr = string.Format("server={0};user id={1}; password={2}; database={3}; pooling=false; Allow Zero DateTime=False;", dbhost, dbuser, dbpass, dbname);
        if (!(conn == null))
        {
            conn.Close();
        }
        try
        {
            conn = new MySqlConnection(connStr);
            conn.Open();
        }
        catch (MySqlException ex)
        {
            err += "Error: " + ex.Message.ToString();
            errNumber = ex.Number;
        }
    }

    public void closeConnection()
    {
        try
        {
            conn.Close();
        }
        catch (MySqlException ex)
        {
            err += "Error: " + ex.Message.ToString();
            errNumber = ex.Number;
        }
    }

    public object QueryDBReader(string sql)
    {
        reader = null;
        MySqlCommand cmd = new MySqlCommand(sql, conn);
        try
        {
            reader = cmd.ExecuteReader();
        }
        catch (MySqlException ex)
        {
            err += "Error: " + ex.Message.ToString();
            errNumber = ex.Number;
        }
        finally
        {
            if (!(reader == null))
            {
                reader.Close();
            }
        }
        return reader;
    }

    public void QueryDBDataset(string sql)
    {
        try
        {
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            da.SelectCommand = cmd;
            cb = new MySqlCommandBuilder(da);
            da.Fill(ds);
        }
        catch (MySqlException ex)
        {
            err += "Error: " + ex.Message.ToString();
            errNumber = ex.Number;
        }
    }

    public void UpdateDBDataset()
    {
        try
        {
            dt = ds.Tables[0];
            DataTable changes = dt.GetChanges();
            da.Update(changes);
            dt.AcceptChanges();
        }
        catch (MySqlException ex)
        {
            err += "Error: " + ex.Message.ToString();
            errNumber = ex.Number;
        }
    }

    public void DeleteDBDataset(int primarykey)
    {
        try
        {
            ds.Tables[0].Rows[primarykey].Delete();
        }
        catch (MySqlException ex)
        {
            err += "Error: " + ex.Message.ToString();
            errNumber = ex.Number;
        }
    }

    public void ExecDB(string sql)
    {
        try
        {
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.ExecuteNonQuery();
        }
        catch (MySqlException ex)
        {
            err += "Error: " + ex.Message.ToString();
            errNumber = ex.Number;
        }
    }

    public object ExecDBScalar(string sql)
    {
        MySqlCommand cmd = new MySqlCommand(sql, conn);
        string strReturn = "";
        try
        {
            strReturn = cmd.ExecuteScalar().ToString();
        }
        catch (MySqlException ex)
        {
            err += "Error: " + ex.Message.ToString();
            errNumber = ex.Number;
        }
        return strReturn;
    }

    public object GetDLLVersion()
    {
        return "DigiOz MySql DLL Version " + dllversion;
    }

    public string dbhost
    {
        get
        {
            return pr_dbhost;
        }
        set
        {
            pr_dbhost = value;
        }
    }

    public string dbuser
    {
        get
        {
            return pr_dbuser;
        }
        set
        {
            pr_dbuser = value;
        }
    }

    public string dbpass
    {
        get
        {
            return pr_dbpass;
        }
        set
        {
            pr_dbpass = value;
        }
    }

    public string dbname
    {
        get
        {
            return pr_dbname;
        }
        set
        {
            pr_dbname = value;
        }
    }
}