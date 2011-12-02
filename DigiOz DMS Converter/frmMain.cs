using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace DMS_To_DD
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class frmMain : System.Windows.Forms.Form
	{
		private System.Windows.Forms.GroupBox grpDMSToDD;
		private System.Windows.Forms.GroupBox grpDDToDMS;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox txtDeg;
		private System.Windows.Forms.TextBox txtMin;
		private System.Windows.Forms.TextBox txtSec;
		private System.Windows.Forms.Label txtOut1;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Button btnConv1;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox txtDec;
		private System.Windows.Forms.Button btnConv2;
		private System.Windows.Forms.Label txtOut2;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.MainMenu mainMenu1;
		private System.Windows.Forms.MenuItem mnuFile;
		private System.Windows.Forms.MenuItem mnuExit;
		private System.Windows.Forms.MenuItem mnuAbout;
		private System.Windows.Forms.MenuItem mnuCopyright;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmMain()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmMain));
			this.grpDMSToDD = new System.Windows.Forms.GroupBox();
			this.grpDDToDMS = new System.Windows.Forms.GroupBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.txtDeg = new System.Windows.Forms.TextBox();
			this.txtMin = new System.Windows.Forms.TextBox();
			this.txtSec = new System.Windows.Forms.TextBox();
			this.txtOut1 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.btnConv1 = new System.Windows.Forms.Button();
			this.label5 = new System.Windows.Forms.Label();
			this.txtDec = new System.Windows.Forms.TextBox();
			this.btnConv2 = new System.Windows.Forms.Button();
			this.txtOut2 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.mainMenu1 = new System.Windows.Forms.MainMenu();
			this.mnuFile = new System.Windows.Forms.MenuItem();
			this.mnuExit = new System.Windows.Forms.MenuItem();
			this.mnuAbout = new System.Windows.Forms.MenuItem();
			this.mnuCopyright = new System.Windows.Forms.MenuItem();
			this.grpDMSToDD.SuspendLayout();
			this.grpDDToDMS.SuspendLayout();
			this.SuspendLayout();
			// 
			// grpDMSToDD
			// 
			this.grpDMSToDD.Controls.Add(this.btnConv1);
			this.grpDMSToDD.Controls.Add(this.label4);
			this.grpDMSToDD.Controls.Add(this.txtOut1);
			this.grpDMSToDD.Controls.Add(this.txtSec);
			this.grpDMSToDD.Controls.Add(this.txtMin);
			this.grpDMSToDD.Controls.Add(this.txtDeg);
			this.grpDMSToDD.Controls.Add(this.label3);
			this.grpDMSToDD.Controls.Add(this.label2);
			this.grpDMSToDD.Controls.Add(this.label1);
			this.grpDMSToDD.Location = new System.Drawing.Point(8, 8);
			this.grpDMSToDD.Name = "grpDMSToDD";
			this.grpDMSToDD.Size = new System.Drawing.Size(416, 128);
			this.grpDMSToDD.TabIndex = 1;
			this.grpDMSToDD.TabStop = false;
			this.grpDMSToDD.Text = "DMS To DD";
			// 
			// grpDDToDMS
			// 
			this.grpDDToDMS.Controls.Add(this.btnConv2);
			this.grpDDToDMS.Controls.Add(this.txtOut2);
			this.grpDDToDMS.Controls.Add(this.label7);
			this.grpDDToDMS.Controls.Add(this.txtDec);
			this.grpDDToDMS.Controls.Add(this.label5);
			this.grpDDToDMS.Location = new System.Drawing.Point(8, 144);
			this.grpDDToDMS.Name = "grpDDToDMS";
			this.grpDDToDMS.Size = new System.Drawing.Size(416, 128);
			this.grpDDToDMS.TabIndex = 1;
			this.grpDDToDMS.TabStop = false;
			this.grpDDToDMS.Text = "DD To DMS";
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label1.Location = new System.Drawing.Point(16, 28);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(56, 16);
			this.label1.TabIndex = 0;
			this.label1.Text = "Degrees:";
			// 
			// label2
			// 
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label2.Location = new System.Drawing.Point(144, 28);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(56, 16);
			this.label2.TabIndex = 2;
			this.label2.Text = "Minutes:";
			// 
			// label3
			// 
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label3.Location = new System.Drawing.Point(280, 28);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(56, 16);
			this.label3.TabIndex = 4;
			this.label3.Text = "Seconds:";
			// 
			// txtDeg
			// 
			this.txtDeg.Location = new System.Drawing.Point(72, 24);
			this.txtDeg.Name = "txtDeg";
			this.txtDeg.Size = new System.Drawing.Size(64, 20);
			this.txtDeg.TabIndex = 1;
			this.txtDeg.Text = "";
			// 
			// txtMin
			// 
			this.txtMin.Location = new System.Drawing.Point(200, 24);
			this.txtMin.Name = "txtMin";
			this.txtMin.Size = new System.Drawing.Size(64, 20);
			this.txtMin.TabIndex = 3;
			this.txtMin.Text = "";
			// 
			// txtSec
			// 
			this.txtSec.Location = new System.Drawing.Point(336, 24);
			this.txtSec.Name = "txtSec";
			this.txtSec.Size = new System.Drawing.Size(64, 20);
			this.txtSec.TabIndex = 5;
			this.txtSec.Text = "";
			// 
			// txtOut1
			// 
			this.txtOut1.BackColor = System.Drawing.Color.White;
			this.txtOut1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtOut1.Location = new System.Drawing.Point(72, 56);
			this.txtOut1.Name = "txtOut1";
			this.txtOut1.Size = new System.Drawing.Size(328, 24);
			this.txtOut1.TabIndex = 7;
			this.txtOut1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label4
			// 
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label4.Location = new System.Drawing.Point(16, 64);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(56, 16);
			this.label4.TabIndex = 6;
			this.label4.Text = "Decimal:";
			// 
			// btnConv1
			// 
			this.btnConv1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnConv1.Location = new System.Drawing.Point(328, 88);
			this.btnConv1.Name = "btnConv1";
			this.btnConv1.Size = new System.Drawing.Size(72, 24);
			this.btnConv1.TabIndex = 8;
			this.btnConv1.Text = "Convert";
			this.btnConv1.Click += new System.EventHandler(this.btnConv1_Click);
			// 
			// label5
			// 
			this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label5.Location = new System.Drawing.Point(16, 24);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(56, 16);
			this.label5.TabIndex = 7;
			this.label5.Text = "Decimal:";
			// 
			// txtDec
			// 
			this.txtDec.Location = new System.Drawing.Point(72, 20);
			this.txtDec.Name = "txtDec";
			this.txtDec.Size = new System.Drawing.Size(328, 20);
			this.txtDec.TabIndex = 8;
			this.txtDec.Text = "";
			// 
			// btnConv2
			// 
			this.btnConv2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnConv2.Location = new System.Drawing.Point(328, 88);
			this.btnConv2.Name = "btnConv2";
			this.btnConv2.Size = new System.Drawing.Size(72, 24);
			this.btnConv2.TabIndex = 11;
			this.btnConv2.Text = "Convert";
			this.btnConv2.Click += new System.EventHandler(this.btnConv2_Click);
			// 
			// txtOut2
			// 
			this.txtOut2.BackColor = System.Drawing.Color.White;
			this.txtOut2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtOut2.Location = new System.Drawing.Point(72, 56);
			this.txtOut2.Name = "txtOut2";
			this.txtOut2.Size = new System.Drawing.Size(328, 24);
			this.txtOut2.TabIndex = 10;
			this.txtOut2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label7
			// 
			this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label7.Location = new System.Drawing.Point(16, 64);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(56, 16);
			this.label7.TabIndex = 9;
			this.label7.Text = "Degrees:";
			// 
			// mainMenu1
			// 
			this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.mnuFile,
																					  this.mnuAbout});
			// 
			// mnuFile
			// 
			this.mnuFile.Index = 0;
			this.mnuFile.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					this.mnuExit});
			this.mnuFile.Text = "&File";
			// 
			// mnuExit
			// 
			this.mnuExit.Index = 0;
			this.mnuExit.Text = "&Exit";
			this.mnuExit.Click += new System.EventHandler(this.mnuExit_Click);
			// 
			// mnuAbout
			// 
			this.mnuAbout.Index = 1;
			this.mnuAbout.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					 this.mnuCopyright});
			this.mnuAbout.Text = "&About";
			// 
			// mnuCopyright
			// 
			this.mnuCopyright.Index = 0;
			this.mnuCopyright.Text = "&Copyright";
			this.mnuCopyright.Click += new System.EventHandler(this.mnuCopyright_Click);
			// 
			// frmMain
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(432, 285);
			this.Controls.Add(this.grpDDToDMS);
			this.Controls.Add(this.grpDMSToDD);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Menu = this.mainMenu1;
			this.Name = "frmMain";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "DigiOz DMS To DD Converter";
			this.grpDMSToDD.ResumeLayout(false);
			this.grpDDToDMS.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new frmMain());
		}

		private void btnConv1_Click(object sender, System.EventArgs e)
		{
			// declare variables
			double vDeg, 
				   vMin,
				   vSec,
				   vConv1;
			
			// attempt to convert if valid data
			try
			{
				vDeg = Double.Parse(txtDeg.Text);
				vMin = Double.Parse(txtMin.Text);
				vSec = Double.Parse(txtSec.Text);

				vConv1 = vDeg + (vMin/60) + (vSec/3600);
				txtOut1.Text = vConv1.ToString();
			}
			catch
			{
				MessageBox.Show("Invalid Value!");
			}

		}

		private void btnConv2_Click(object sender, System.EventArgs e)
		{
			// declare variables
			int fDeg,
				fMin,
				fSec;

			double dDeg,
				   dMin,
				   dSec,
				   vDec;

			string vConv2;

			// attempt to convert if valid data
			try
			{
				vDec = Double.Parse(txtDec.Text);
				fDeg = Convert.ToInt32(Math.Floor(vDec));
				
				vDec = vDec - fDeg;
				fMin = Convert.ToInt32(Math.Floor(vDec * 60));

				vDec = (vDec * 60) - fMin;
				fSec = Convert.ToInt32(Math.Ceiling(vDec * 60));
				
				txtOut2.Text = fDeg.ToString() + "D " + fMin.ToString() + "M " + fSec.ToString() + "S";
 


			}
			catch
			{
				MessageBox.Show("Invalid Value!");
			}
		
		}

		private void mnuExit_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void mnuCopyright_Click(object sender, System.EventArgs e)
		{
			MessageBox.Show("Copyright DigiOz Multimedia 2006");
		}
	}
}
