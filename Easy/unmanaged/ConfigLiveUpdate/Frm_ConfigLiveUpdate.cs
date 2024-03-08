
/*
Easy
Copyright (C) 2024 Università degli Studi di Catania (www.unict.it)
This program is free software: you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.
This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.
You should have received a copy of the GNU General Public License
along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/


using System;
using System.Data;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using metadatalibrary;

namespace ConfigLiveUpdate//ConfigLiveUpdate//
{
	/// <summary>
	/// Summary description for frmConfigLiveUpdate.
	/// </summary>
	public class Frm_ConfigLiveUpdate : MetaDataForm
	{
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.Button btnAnnulla;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtReportDir;
		private /*Rana:ConfigLiveUpdate.*/vistaForm DS;
		private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
		private System.Windows.Forms.Button btnChooseDir;
		string ConfigFileName;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.TextBox txtLiveUpdateSite;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox txtLiveUpdateSite2;
		private System.Windows.Forms.TextBox txtLiveUpdateSite3;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Frm_ConfigLiveUpdate()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			DS.Namespace ="http://tempuri.org/VistaConfigLiveUpdate.xsd";
			ConfigFileName=AppDomain.CurrentDomain.BaseDirectory+"updateconfig.xml";
			try {
				DS.ReadXml(ConfigFileName);
			}
			catch
			{
				DataRow R = DS.configtable.NewRow();
				DS.configtable.Rows.Add(R);
                string reportdir = AppDomain.CurrentDomain.BaseDirectory; 
                if (reportdir.EndsWith("\\")) reportdir = reportdir.Substring(0, reportdir.Length - 1);
                int lastslash = reportdir.LastIndexOf("\\");
                if (lastslash > 0) reportdir = reportdir.Substring(0, lastslash);

                reportdir = reportdir + "\\report";
                if (!System.IO.Directory.Exists(reportdir)) {
                    System.IO.Directory.CreateDirectory(reportdir);
                }
                R["localreportdir"] = reportdir;
                R["httpupdatepath"] = "http://www.temposrl.com/easy2/";
			}
			txtReportDir.Text=DS.configtable.Rows[0]["localreportdir"].ToString();
			txtLiveUpdateSite.Text=DS.configtable.Rows[0]["httpupdatepath"].ToString();
			txtLiveUpdateSite2.Text=DS.configtable.Rows[0]["httpupdatepath2"].ToString();
			txtLiveUpdateSite3.Text=DS.configtable.Rows[0]["httpupdatepath3"].ToString();
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
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
			this.btnOK = new System.Windows.Forms.Button();
			this.btnAnnulla = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.txtReportDir = new System.Windows.Forms.TextBox();
			this.DS = new /*Rana:ConfigLiveUpdate.*/vistaForm();
			this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
			this.btnChooseDir = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.txtLiveUpdateSite = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.txtLiveUpdateSite2 = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.txtLiveUpdateSite3 = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// btnOK
			// 
			this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnOK.Location = new System.Drawing.Point(448, 248);
			this.btnOK.Name = "btnOK";
			this.btnOK.TabIndex = 0;
			this.btnOK.Text = "OK";
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// btnAnnulla
			// 
			this.btnAnnulla.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnAnnulla.Location = new System.Drawing.Point(536, 248);
			this.btnAnnulla.Name = "btnAnnulla";
			this.btnAnnulla.TabIndex = 1;
			this.btnAnnulla.Text = "Annulla";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(16, 24);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(200, 24);
			this.label1.TabIndex = 2;
			this.label1.Text = "Cartella locale in cui risiedono i report:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtReportDir
			// 
			this.txtReportDir.Location = new System.Drawing.Point(216, 24);
			this.txtReportDir.MaxLength = 255;
			this.txtReportDir.Name = "txtReportDir";
			this.txtReportDir.Size = new System.Drawing.Size(384, 20);
			this.txtReportDir.TabIndex = 4;
			this.txtReportDir.Text = "";
			// 
			// DS
			// 
			this.DS.DataSetName = "vistaForm";
			this.DS.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// btnChooseDir
			// 
			this.btnChooseDir.Location = new System.Drawing.Point(600, 24);
			this.btnChooseDir.Name = "btnChooseDir";
			this.btnChooseDir.Size = new System.Drawing.Size(24, 20);
			this.btnChooseDir.TabIndex = 6;
			this.btnChooseDir.Text = "...";
			this.btnChooseDir.Click += new System.EventHandler(this.btnChooseDir_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.txtLiveUpdateSite3);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.txtLiveUpdateSite2);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.txtLiveUpdateSite);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Location = new System.Drawing.Point(24, 64);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(600, 160);
			this.groupBox1.TabIndex = 7;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Live Update";
			// 
			// txtLiveUpdateSite
			// 
			this.txtLiveUpdateSite.Location = new System.Drawing.Point(192, 38);
			this.txtLiveUpdateSite.MaxLength = 255;
			this.txtLiveUpdateSite.Name = "txtLiveUpdateSite";
			this.txtLiveUpdateSite.Size = new System.Drawing.Size(392, 20);
			this.txtLiveUpdateSite.TabIndex = 7;
			this.txtLiveUpdateSite.Text = "";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(16, 36);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(136, 24);
			this.label2.TabIndex = 6;
			this.label2.Text = "Sito web o cartella locale";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtLiveUpdateSite2
			// 
			this.txtLiveUpdateSite2.Location = new System.Drawing.Point(192, 74);
			this.txtLiveUpdateSite2.MaxLength = 255;
			this.txtLiveUpdateSite2.Name = "txtLiveUpdateSite2";
			this.txtLiveUpdateSite2.Size = new System.Drawing.Size(392, 20);
			this.txtLiveUpdateSite2.TabIndex = 9;
			this.txtLiveUpdateSite2.Text = "";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(16, 72);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(136, 24);
			this.label3.TabIndex = 8;
			this.label3.Text = "Sito web o cartella locale";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtLiveUpdateSite3
			// 
			this.txtLiveUpdateSite3.Location = new System.Drawing.Point(192, 112);
			this.txtLiveUpdateSite3.MaxLength = 255;
			this.txtLiveUpdateSite3.Name = "txtLiveUpdateSite3";
			this.txtLiveUpdateSite3.Size = new System.Drawing.Size(392, 20);
			this.txtLiveUpdateSite3.TabIndex = 11;
			this.txtLiveUpdateSite3.Text = "";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(16, 112);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(136, 24);
			this.label4.TabIndex = 10;
			this.label4.Text = "Sito web o cartella locale";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// frmConfigLiveUpdate
			// 
			this.AcceptButton = this.btnOK;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.btnAnnulla;
			this.ClientSize = new System.Drawing.Size(642, 296);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.btnChooseDir);
			this.Controls.Add(this.txtReportDir);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.btnAnnulla);
			this.Controls.Add(this.btnOK);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "frmConfigLiveUpdate";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Configurazione aggiornamenti automatici";
			((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void btnChooseDir_Click(object sender, System.EventArgs e)
		{
			folderBrowserDialog1.SelectedPath = txtReportDir.Text;
			DialogResult res = folderBrowserDialog1.ShowDialog(this);
			if (res != DialogResult.OK) return;
			txtReportDir.Text=folderBrowserDialog1.SelectedPath;
		}

		private void btnOK_Click(object sender, System.EventArgs e)
		{
			DS.configtable.Rows[0]["localreportdir"]=txtReportDir.Text;
			DS.configtable.Rows[0]["httpupdatepath"]=txtLiveUpdateSite.Text.Trim();
			DS.configtable.Rows[0]["httpupdatepath2"]=txtLiveUpdateSite2.Text.Trim();
			DS.configtable.Rows[0]["httpupdatepath3"]=txtLiveUpdateSite3.Text.Trim();
			DS.WriteXml(ConfigFileName);
		}

	}
}
