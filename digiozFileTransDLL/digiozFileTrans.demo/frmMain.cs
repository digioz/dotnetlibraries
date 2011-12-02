using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using digiozFileTrans;

namespace digiozFileTrans.demo
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            txtPath.Text = openFileDialog1.FileName;
            digiozFileTrans loFileTrans = new digiozFileTrans();
            string lsError = string.Empty;

            txtEdit.Text = loFileTrans.GetFileContents(txtPath.Text.Trim(), ref lsError);

            if (lsError.Length > 0)
            {
                MessageBox.Show(lsError);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtPath.Text.Length > 0 && System.IO.File.Exists(txtPath.Text.Trim()))
            {
                string lsError = string.Empty;
                digiozFileTrans loFileTrans = new digiozFileTrans();
                loFileTrans.SaveTextToFile(txtEdit.Text, txtPath.Text.Trim(), ref lsError);

                if (lsError.Length > 0)
                {
                    MessageBox.Show(lsError);
                }
                else
                {
                    MessageBox.Show("Changes Saved Successfully");
                }
            }
            else
            {
                MessageBox.Show("Unable to Read the file at the path specified");
            }
        }
    }
}
