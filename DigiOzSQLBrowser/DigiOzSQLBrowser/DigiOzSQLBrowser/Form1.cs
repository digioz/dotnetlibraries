using DigiOzSQLBrowser.Libraries;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DigiOzSQLBrowser
{
    public partial class frmMain : Form
    {
        private string csConnectionString;

        private string GetConnectionString()
        {
            string lsServer = txtServer.Text.Trim();
            string lsDatabase = txtDatabase.Text.Trim();
            string lsUsername = txtUsername.Text.Trim();
            string lsPassword = txtPassword.Text.Trim();

            csConnectionString = "Server=" + lsServer + ";Database=" + lsDatabase + ";User Id=" + lsUsername + ";Pwd=" + lsPassword + ";Asynchronous Processing=false;";

            return csConnectionString;
        }

        public frmMain()
        {
            InitializeComponent();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            GetConnectionString();

            // Query Database for Table Names
            MSSQL loDB = new MSSQL(csConnectionString);
            string lsSQL = "SELECT TABLE_NAME FROM information_schema.tables;";

            try
            {
                loDB.openConnection();
                DataTable lsDT = loDB.QueryDBDataset(lsSQL);

                if (loDB.csErr != null && loDB.csErr != string.Empty)
                {
                    MessageBox.Show("Error: " + loDB.csErr);
                    return;
                }

                cboTables.Items.Clear();

                if (lsDT != null && lsDT.Rows.Count > 0)
                {
                    foreach (DataRow lsDR in lsDT.Rows)
                    {
                        cboTables.Items.Add(lsDR[0].ToString());
                    }
                }
            }
            catch (Exception lsEx)
            {
                MessageBox.Show("Error: " + lsEx.Message);
            }

            loDB.closeConnection();

            MessageBox.Show("Connected Successfully!");
        }

        private void cboTables_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetConnectionString();

            // Query Database for Table Names
            Int32 liLID = 0;
            MSSQL loDB = new MSSQL(csConnectionString);
            string lsSQL = "SELECT * FROM " + cboTables.SelectedItem.ToString() + ";";

            try
            {
                loDB.openConnection();
                DataTable lsDT = loDB.QueryDBDataset(lsSQL);
                grdData.DataSource = null;

                if (lsDT != null)
                {
                    grdData.DataSource = lsDT;
                }
            }
            catch
            {
                liLID = 0;
            }

            loDB.closeConnection();
        }
    }
}
