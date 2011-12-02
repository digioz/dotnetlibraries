using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class _Default : System.Web.UI.Page 
{
    public dbClass db1;
    public string sql;

    protected void Page_Load(object sender, EventArgs e)
    {
        int i = 0;
        string sOut;

        db1 = new dbClass();
        
        db1.dbhost = "localhost";
        db1.dbname = "northwind";
        db1.dbuser = "root";
        db1.dbpass = "password";

        if (IsPostBack)
        {
            if (DropDownList1.Text != "ALL")
            {
                sql = "SELECT EmployeeID,FirstName,LastName,City FROM `northwind`.`employees` WHERE City='" + DropDownList1.Text + "'";
            }
            else
            {
                sql = "SELECT EmployeeID,FirstName,LastName,City FROM `northwind`.`employees`;";
            }
        }
        else
        {
            sql = "SELECT EmployeeID,FirstName,LastName,City FROM `northwind`.`employees`;";
        }

        db1.openConnection();
        db1.QueryDBDataset(sql);
        sOut = "<table>";

        for (i = 0; i < db1.ds.Tables[0].Rows.Count; i++)
        {
            sOut += "<tr><td>" + db1.ds.Tables[0].Rows[i].ItemArray[0].ToString() + "</td>";
            sOut += "<td>" + db1.ds.Tables[0].Rows[i].ItemArray[1].ToString() + "</td>";
            sOut += "<td>" + db1.ds.Tables[0].Rows[i].ItemArray[2].ToString() + "</td>";
            sOut += "<td>" + db1.ds.Tables[0].Rows[i].ItemArray[3].ToString() + "</td></tr>";
        }

        sOut += "</table>";

        lblOut.Text = sOut;

        db1.closeConnection();        
    }
}
