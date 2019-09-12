/*
    Easy
    Copyright (C) 2019 Università degli Studi di Catania (www.unict.it)

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

ï»¿using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.IO;
using System.Threading;

namespace LiveUpdate//LiveUpdate//
{
	/// <summary>
	/// Summary description for frmPath.
	/// </summary>
	public class frmPath : System.Windows.Forms.Form
	{
		private System.Windows.Forms.TextBox txtFile;
		private System.Windows.Forms.TextBox txtDir;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button cmdGenera;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.RadioButton radioDLL;
		private System.Windows.Forms.RadioButton radioReport;
		private System.Windows.Forms.Button btnDir;

		private  string C_FILEINDEXNAME = (IsNet45OrNewer() ? "fileindex4.xml" : "fileindex.xml")
;
        private const string C_REPORTINDEXNAME = "reportindex.xml";
		private string filter = "*.dll"; //default

        public static bool IsNet45OrNewer() {
            var result =
                Environment.Version.Major.Equals(4) &&
                Environment.Version.Minor.Equals(0) &&
                Environment.Version.Build.Equals(30319) &&
                Environment.Version.Revision >= 34000;

            return result;
        }

        public frmPath()
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
            this.txtFile = new System.Windows.Forms.TextBox();
            this.cmdGenera = new System.Windows.Forms.Button();
            this.txtDir = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioReport = new System.Windows.Forms.RadioButton();
            this.radioDLL = new System.Windows.Forms.RadioButton();
            this.btnDir = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtFile
            // 
            this.txtFile.Enabled = false;
            this.txtFile.Location = new System.Drawing.Point(100, 120);
            this.txtFile.Name = "txtFile";
            this.txtFile.Size = new System.Drawing.Size(310, 20);
            this.txtFile.TabIndex = 9;
            // 
            // cmdGenera
            // 
            this.cmdGenera.Location = new System.Drawing.Point(162, 170);
            this.cmdGenera.Name = "cmdGenera";
            this.cmdGenera.Size = new System.Drawing.Size(96, 24);
            this.cmdGenera.TabIndex = 8;
            this.cmdGenera.Text = "Genera";
            this.cmdGenera.Click += new System.EventHandler(this.cmdGenera_Click);
            // 
            // txtDir
            // 
            this.txtDir.Location = new System.Drawing.Point(100, 80);
            this.txtDir.Name = "txtDir";
            this.txtDir.Size = new System.Drawing.Size(280, 20);
            this.txtDir.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(20, 122);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 16);
            this.label2.TabIndex = 6;
            this.label2.Text = "Nome file XML";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(20, 82);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 16);
            this.label1.TabIndex = 5;
            this.label1.Text = "Directory";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioReport);
            this.groupBox1.Controls.Add(this.radioDLL);
            this.groupBox1.Location = new System.Drawing.Point(10, 10);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(400, 50);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tipo cartella";
            // 
            // radioReport
            // 
            this.radioReport.Location = new System.Drawing.Point(228, 20);
            this.radioReport.Name = "radioReport";
            this.radioReport.Size = new System.Drawing.Size(104, 24);
            this.radioReport.TabIndex = 1;
            this.radioReport.Text = "Report";
            this.radioReport.CheckedChanged += new System.EventHandler(this.radioReport_CheckedChanged);
            // 
            // radioDLL
            // 
            this.radioDLL.Checked = true;
            this.radioDLL.Location = new System.Drawing.Point(68, 20);
            this.radioDLL.Name = "radioDLL";
            this.radioDLL.Size = new System.Drawing.Size(104, 24);
            this.radioDLL.TabIndex = 0;
            this.radioDLL.TabStop = true;
            this.radioDLL.Text = "DLL / EXE";
            this.radioDLL.CheckedChanged += new System.EventHandler(this.radioDLL_CheckedChanged);
            // 
            // btnDir
            // 
            this.btnDir.Location = new System.Drawing.Point(380, 80);
            this.btnDir.Name = "btnDir";
            this.btnDir.Size = new System.Drawing.Size(30, 20);
            this.btnDir.TabIndex = 11;
            this.btnDir.Text = "...";
            this.btnDir.Click += new System.EventHandler(this.btnDir_Click);
            // 
            // frmPath
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(420, 231);
            this.Controls.Add(this.btnDir);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtFile);
            this.Controls.Add(this.txtDir);
            this.Controls.Add(this.cmdGenera);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "frmPath";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Generazione File Index";
            this.Load += new System.EventHandler(this.frmPath_Load);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void ImpostaNomeFile() {
			if (radioDLL.Checked) {
				txtFile.Text = C_FILEINDEXNAME;
				filter = "*.dll";
			}
			else {
				txtFile.Text = C_REPORTINDEXNAME;
				filter = "*.rpt";
			}
		}

		private void frmPath_Load(object sender, System.EventArgs e) {
			txtDir.Text = AppDomain.CurrentDomain.BaseDirectory;
			ImpostaNomeFile();
		}

		private void cmdGenera_Click(object sender, System.EventArgs e) {
			if (txtDir.Text == "") {
				MessageBox.Show(this, "Specificare una directory.","XML Generator");
				return;
			}
			if (txtFile.Text == "") {
				MessageBox.Show(this, "Specificare un nome per il file XML da generare.","XML Generator");
				return;
			}
			if (!Directory.Exists(txtDir.Text)) {
				MessageBox.Show(this, "Impossibile trovare la directory " + txtDir.Text, "XML Generator");
				return;
			}

			this.Cursor = Cursors.WaitCursor;
			string errori;
			if (GenXML.GeneraFileXML(txtDir.Text, txtFile.Text, filter, null, false, out errori))
				MessageBox.Show("File XML generato con successo", "XML Generator",
					MessageBoxButtons.OK, MessageBoxIcon.Information);
			else
				MessageBox.Show("Sono stati riscontrati i seguenti errori nella generazione:\r"
					+ errori, "XML Generator", MessageBoxButtons.OK, 
					MessageBoxIcon.Information);
			this.Cursor = Cursors.Default;
			return;
		}

		private void radioDLL_CheckedChanged(object sender, System.EventArgs e) {
			ImpostaNomeFile();
		}

		private void radioReport_CheckedChanged(object sender, System.EventArgs e) {
			ImpostaNomeFile();
		}

		private void btnDir_Click(object sender, System.EventArgs e) {
			FolderBrowserDialog dir = new FolderBrowserDialog();
			dir.SelectedPath = txtDir.Text;
			dir.Description = "Seleziona la cartella in cui si trovano i file";
			if (dir.ShowDialog()==DialogResult.OK) {
				txtDir.Text = dir.SelectedPath;
			}
		}
	}
}
