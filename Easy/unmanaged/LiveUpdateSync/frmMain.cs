
/*
Easy
Copyright (C) 2022 Università degli Studi di Catania (www.unict.it)
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
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Threading;
using metadatalibrary;
using System.IO;
using download;
using EnterpriseDT.Net.Ftp;
using utility;
using System.Text;

namespace LiveUpdateSync {
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class frmMain : MetaDataForm {
		private System.Windows.Forms.Button btnChiudi;
		private System.Windows.Forms.Button btnSync;
		/// <summary>
		/// Required designer variable.
		/// </summary>

		private System.ComponentModel.Container components = null;
		private const string C_FILESYNC="sync.xml";
		private  string C_INDEXDLL= (IsNet45OrNewer() ? "fileindex4.xml" : "fileindex.xml");
        private  string C_INDEXDLLZIP= (IsNet45OrNewer() ? "fileindex4.xml.zip" : "fileindex.xml.zip");
		private const string C_INDEXREPORT="reportindex.xml";
		private const string C_INDEXREPORTZIP="reportindex.xml.zip";
		private const string C_INDEXSQL="scriptindex.xml";
		private const string C_INDEXSQLZIP="scriptindex.xml.zip";
		private const string C_INDEXSP="spindex.xml";
		private const string C_INDEXSPZIP="spindex.xml.zip";
		private const string C_INDEXONDEMAND="remoteondemandindex.xml";
		private const string C_INDEXONDEMANDZIP="remoteondemandindex.zip";
		private System.Windows.Forms.GroupBox grpMaster;
		private System.Windows.Forms.TextBox txtDescrizione;
		private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnCancelMaster;
		private System.Windows.Forms.Button btnDeleteMaster;
		private System.Windows.Forms.Button btnInsertMaster;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.DataGrid gridMaster;
		private LiveUpdateSync.vista DS;
		private System.Windows.Forms.TextBox txtProgressivo;
		private string m_IndexFileName="";
		private string m_IndexFileZip="";
		private string m_IndexFileDir="";
		private string m_Log=null;
		private enum eStato {
			READ,
			INSERT
		}
		private eStato Stato=eStato.READ;
		private DataRow m_CurrentMasterRow=null;
		private bool modified=false;
		private System.Windows.Forms.Button btnSalva;
		private System.Windows.Forms.TextBox txtIndirizzo;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.TextBox txtSource;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox txtUserMaster;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.TextBox txtPwdMaster;
		private System.Windows.Forms.TextBox txtPwd;
		private System.Windows.Forms.TextBox txtUser;
		private System.Windows.Forms.CheckBox chkLocale;
		private System.Windows.Forms.Button btnDirBrowse;
		private System.Windows.Forms.TextBox txtPort;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox txtDBVersion;
		private System.Windows.Forms.Button btnUpdateDBVersion;
		private System.Windows.Forms.CheckBox chkDirectory;
		private System.Windows.Forms.Label label1;
        private CheckBox chkPasV;
		frmLog LogForm;
        
	    void initLicenses() {
	        string txtFile = "";
	        string licFileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "licenses.dat");
	        if (File.Exists(licFileName)) {
	            var b = File.ReadAllBytes(licFileName);
	            var c = DataAccess.DecryptBytes(b);
	            txtFile = UTF32Encoding.UTF8.GetString(c).Trim();
	        }
	        else {
	            //txtFile ="Grid;GGGG-GGGG-GGGG-GGGG|Editors;EEEE-EEEE-EEEE-EEEE|Zip;ZZZZZZZZZZZZZZZZZZZ|Ftp;FFFFFFFFFFFFFFFFFFF";
	            //var c = DataAccess.CryptBytes(UTF32Encoding.UTF8.GetBytes(txtFile));
	            //File.WriteAllBytes(licFileName, c);
	        }

	        var couples = txtFile.Split('|');
	        foreach (var cc in couples) {
	            var kv = cc.Split(';');
	            if (kv[0] == "Grid") Xceed.Grid.Licenser.LicenseKey = kv[1];
	            if (kv[0] == "Editors") Xceed.Editors.Licenser.LicenseKey = kv[1];
	            if (kv[0] == "Zip") Xceed.Zip.Licenser.LicenseKey = kv[1];
	            if (kv[0] == "Ftp") Xceed.Ftp.Licenser.LicenseKey = kv[1];
	        }

	    }
        public static bool IsNet45OrNewer() {
            var result =
                Environment.Version.Major.Equals(4) &&
                Environment.Version.Minor.Equals(0) &&
                Environment.Version.Build.Equals(30319) &&
                Environment.Version.Revision >= 34000;

            return result;
        }

        public frmMain() {
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
            initLicenses();
            MetaData.SetColor(this);
			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			AbilitaSync(false);
			m_IndexFileName=Application.StartupPath+@"\"+C_FILESYNC;
			m_IndexFileDir=Application.StartupPath;
			m_IndexFileZip=m_IndexFileName.Remove(m_IndexFileName.Length-3,3)+"zip";
			Init();
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing ) {
			if( disposing ) {
				if (components != null) {
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
		private void InitializeComponent() {
            this.btnSync = new System.Windows.Forms.Button();
            this.btnChiudi = new System.Windows.Forms.Button();
            this.grpMaster = new System.Windows.Forms.GroupBox();
            this.chkPasV = new System.Windows.Forms.CheckBox();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPwd = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtIndirizzo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSalva = new System.Windows.Forms.Button();
            this.txtDescrizione = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.btnCancelMaster = new System.Windows.Forms.Button();
            this.btnDeleteMaster = new System.Windows.Forms.Button();
            this.btnInsertMaster = new System.Windows.Forms.Button();
            this.txtProgressivo = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.gridMaster = new System.Windows.Forms.DataGrid();
            this.DS = new LiveUpdateSync.vista();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnDirBrowse = new System.Windows.Forms.Button();
            this.chkLocale = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPwdMaster = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtUserMaster = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSource = new System.Windows.Forms.TextBox();
            this.txtDBVersion = new System.Windows.Forms.TextBox();
            this.btnUpdateDBVersion = new System.Windows.Forms.Button();
            this.chkDirectory = new System.Windows.Forms.CheckBox();
            this.grpMaster.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridMaster)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSync
            // 
            this.btnSync.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnSync.Location = new System.Drawing.Point(165, 537);
            this.btnSync.Name = "btnSync";
            this.btnSync.Size = new System.Drawing.Size(83, 23);
            this.btnSync.TabIndex = 3;
            this.btnSync.Text = "Sincronizza";
            this.btnSync.Click += new System.EventHandler(this.btnSync_Click);
            // 
            // btnChiudi
            // 
            this.btnChiudi.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnChiudi.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnChiudi.Location = new System.Drawing.Point(329, 537);
            this.btnChiudi.Name = "btnChiudi";
            this.btnChiudi.Size = new System.Drawing.Size(87, 23);
            this.btnChiudi.TabIndex = 4;
            this.btnChiudi.Text = "Chiudi";
            this.btnChiudi.Click += new System.EventHandler(this.btnChiudi_Click);
            // 
            // grpMaster
            // 
            this.grpMaster.Controls.Add(this.chkPasV);
            this.grpMaster.Controls.Add(this.txtPort);
            this.grpMaster.Controls.Add(this.label4);
            this.grpMaster.Controls.Add(this.txtPwd);
            this.grpMaster.Controls.Add(this.label7);
            this.grpMaster.Controls.Add(this.txtUser);
            this.grpMaster.Controls.Add(this.label8);
            this.grpMaster.Controls.Add(this.txtIndirizzo);
            this.grpMaster.Controls.Add(this.label2);
            this.grpMaster.Controls.Add(this.btnSalva);
            this.grpMaster.Controls.Add(this.txtDescrizione);
            this.grpMaster.Controls.Add(this.label9);
            this.grpMaster.Controls.Add(this.btnCancelMaster);
            this.grpMaster.Controls.Add(this.btnDeleteMaster);
            this.grpMaster.Controls.Add(this.btnInsertMaster);
            this.grpMaster.Controls.Add(this.txtProgressivo);
            this.grpMaster.Controls.Add(this.label5);
            this.grpMaster.Controls.Add(this.gridMaster);
            this.grpMaster.Location = new System.Drawing.Point(16, 96);
            this.grpMaster.Name = "grpMaster";
            this.grpMaster.Size = new System.Drawing.Size(520, 342);
            this.grpMaster.TabIndex = 2;
            this.grpMaster.TabStop = false;
            this.grpMaster.Text = "Siti da sincronizzare";
            // 
            // chkPasV
            // 
            this.chkPasV.AutoSize = true;
            this.chkPasV.Location = new System.Drawing.Point(416, 300);
            this.chkPasV.Name = "chkPasV";
            this.chkPasV.Size = new System.Drawing.Size(83, 17);
            this.chkPasV.TabIndex = 40;
            this.chkPasV.Text = "PASV mode";
            this.chkPasV.UseVisualStyleBackColor = true;
            this.chkPasV.CheckStateChanged += new System.EventHandler(this.chkPasV_CheckStateChanged);
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(432, 264);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(64, 20);
            this.txtPort.TabIndex = 10;
            this.txtPort.TextChanged += new System.EventHandler(this.txtPort_TextChanged);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(392, 266);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 16);
            this.label4.TabIndex = 39;
            this.label4.Text = "Port";
            // 
            // txtPwd
            // 
            this.txtPwd.Location = new System.Drawing.Point(248, 264);
            this.txtPwd.Name = "txtPwd";
            this.txtPwd.PasswordChar = '*';
            this.txtPwd.Size = new System.Drawing.Size(96, 20);
            this.txtPwd.TabIndex = 9;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(184, 266);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 16);
            this.label7.TabIndex = 37;
            this.label7.Text = "Password";
            // 
            // txtUser
            // 
            this.txtUser.Location = new System.Drawing.Point(80, 264);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(100, 20);
            this.txtUser.TabIndex = 8;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(16, 266);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(48, 16);
            this.label8.TabIndex = 35;
            this.label8.Text = "Utente";
            // 
            // txtIndirizzo
            // 
            this.txtIndirizzo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtIndirizzo.Location = new System.Drawing.Point(80, 216);
            this.txtIndirizzo.MaxLength = 2000;
            this.txtIndirizzo.Name = "txtIndirizzo";
            this.txtIndirizzo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtIndirizzo.Size = new System.Drawing.Size(416, 20);
            this.txtIndirizzo.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(16, 216);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 16);
            this.label2.TabIndex = 26;
            this.label2.Text = "Indirizzo";
            // 
            // btnSalva
            // 
            this.btnSalva.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSalva.Location = new System.Drawing.Point(424, 161);
            this.btnSalva.Name = "btnSalva";
            this.btnSalva.Size = new System.Drawing.Size(75, 23);
            this.btnSalva.TabIndex = 5;
            this.btnSalva.Text = "Salva";
            this.btnSalva.Click += new System.EventHandler(this.btnSalva_Click);
            // 
            // txtDescrizione
            // 
            this.txtDescrizione.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescrizione.Location = new System.Drawing.Point(80, 240);
            this.txtDescrizione.MaxLength = 2000;
            this.txtDescrizione.Name = "txtDescrizione";
            this.txtDescrizione.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDescrizione.Size = new System.Drawing.Size(416, 20);
            this.txtDescrizione.TabIndex = 7;
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(16, 240);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(80, 16);
            this.label9.TabIndex = 23;
            this.label9.Text = "Descrizione";
            // 
            // btnCancelMaster
            // 
            this.btnCancelMaster.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelMaster.Location = new System.Drawing.Point(424, 85);
            this.btnCancelMaster.Name = "btnCancelMaster";
            this.btnCancelMaster.Size = new System.Drawing.Size(75, 23);
            this.btnCancelMaster.TabIndex = 4;
            this.btnCancelMaster.Text = "Annulla";
            this.btnCancelMaster.Click += new System.EventHandler(this.btnCancelMaster_Click);
            // 
            // btnDeleteMaster
            // 
            this.btnDeleteMaster.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeleteMaster.Location = new System.Drawing.Point(424, 53);
            this.btnDeleteMaster.Name = "btnDeleteMaster";
            this.btnDeleteMaster.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteMaster.TabIndex = 3;
            this.btnDeleteMaster.Text = "Elimina";
            this.btnDeleteMaster.Click += new System.EventHandler(this.btnDeleteMaster_Click);
            // 
            // btnInsertMaster
            // 
            this.btnInsertMaster.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnInsertMaster.Location = new System.Drawing.Point(424, 24);
            this.btnInsertMaster.Name = "btnInsertMaster";
            this.btnInsertMaster.Size = new System.Drawing.Size(75, 23);
            this.btnInsertMaster.TabIndex = 1;
            this.btnInsertMaster.Text = "Inserisci";
            this.btnInsertMaster.Click += new System.EventHandler(this.btnInsertMaster_Click);
            // 
            // txtProgressivo
            // 
            this.txtProgressivo.Location = new System.Drawing.Point(80, 192);
            this.txtProgressivo.MaxLength = 10;
            this.txtProgressivo.Name = "txtProgressivo";
            this.txtProgressivo.ReadOnly = true;
            this.txtProgressivo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtProgressivo.Size = new System.Drawing.Size(96, 20);
            this.txtProgressivo.TabIndex = 20;
            this.txtProgressivo.Tag = "";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(16, 192);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 16);
            this.label5.TabIndex = 13;
            this.label5.Text = "Progressivo";
            // 
            // gridMaster
            // 
            this.gridMaster.AllowNavigation = false;
            this.gridMaster.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridMaster.CaptionVisible = false;
            this.gridMaster.DataMember = "";
            this.gridMaster.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.gridMaster.Location = new System.Drawing.Point(16, 24);
            this.gridMaster.Name = "gridMaster";
            this.gridMaster.ReadOnly = true;
            this.gridMaster.Size = new System.Drawing.Size(384, 160);
            this.gridMaster.TabIndex = 0;
            this.gridMaster.Tag = "";
            this.gridMaster.Click += new System.EventHandler(this.gridMaster_Click);
            // 
            // DS
            // 
            this.DS.DataSetName = "vista";
            this.DS.Locale = new System.Globalization.CultureInfo("en-US");
            this.DS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnDirBrowse);
            this.groupBox1.Controls.Add(this.chkLocale);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtPwdMaster);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtUserMaster);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtSource);
            this.groupBox1.Location = new System.Drawing.Point(16, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(520, 80);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Sito (remoto o locale) da replicare";
            // 
            // btnDirBrowse
            // 
            this.btnDirBrowse.Location = new System.Drawing.Point(488, 23);
            this.btnDirBrowse.Name = "btnDirBrowse";
            this.btnDirBrowse.Size = new System.Drawing.Size(24, 23);
            this.btnDirBrowse.TabIndex = 37;
            this.btnDirBrowse.Text = "...";
            this.btnDirBrowse.Click += new System.EventHandler(this.btnDirBrowse_Click);
            // 
            // chkLocale
            // 
            this.chkLocale.Checked = true;
            this.chkLocale.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkLocale.Enabled = false;
            this.chkLocale.Location = new System.Drawing.Point(416, 50);
            this.chkLocale.Name = "chkLocale";
            this.chkLocale.Size = new System.Drawing.Size(64, 16);
            this.chkLocale.TabIndex = 36;
            this.chkLocale.Text = "Locale";
            this.chkLocale.CheckedChanged += new System.EventHandler(this.chkLocale_CheckedChanged);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(16, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 16);
            this.label1.TabIndex = 35;
            this.label1.Text = "Indirizzo";
            // 
            // txtPwdMaster
            // 
            this.txtPwdMaster.Enabled = false;
            this.txtPwdMaster.Location = new System.Drawing.Point(256, 48);
            this.txtPwdMaster.Name = "txtPwdMaster";
            this.txtPwdMaster.PasswordChar = '*';
            this.txtPwdMaster.Size = new System.Drawing.Size(104, 20);
            this.txtPwdMaster.TabIndex = 34;
            this.txtPwdMaster.TextChanged += new System.EventHandler(this.txtPwdMaster_TextChanged);
            // 
            // label6
            // 
            this.label6.Enabled = false;
            this.label6.Location = new System.Drawing.Point(192, 50);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 16);
            this.label6.TabIndex = 33;
            this.label6.Text = "Password";
            // 
            // txtUserMaster
            // 
            this.txtUserMaster.Enabled = false;
            this.txtUserMaster.Location = new System.Drawing.Point(72, 48);
            this.txtUserMaster.Name = "txtUserMaster";
            this.txtUserMaster.Size = new System.Drawing.Size(112, 20);
            this.txtUserMaster.TabIndex = 32;
            this.txtUserMaster.TextChanged += new System.EventHandler(this.txtUserMaster_TextChanged);
            // 
            // label3
            // 
            this.label3.Enabled = false;
            this.label3.Location = new System.Drawing.Point(16, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 16);
            this.label3.TabIndex = 31;
            this.label3.Text = "Utente";
            // 
            // txtSource
            // 
            this.txtSource.Location = new System.Drawing.Point(72, 24);
            this.txtSource.Name = "txtSource";
            this.txtSource.Size = new System.Drawing.Size(416, 20);
            this.txtSource.TabIndex = 3;
            this.txtSource.TextChanged += new System.EventHandler(this.txtSource_TextChanged);
            // 
            // txtDBVersion
            // 
            this.txtDBVersion.Location = new System.Drawing.Point(200, 452);
            this.txtDBVersion.Name = "txtDBVersion";
            this.txtDBVersion.Size = new System.Drawing.Size(100, 20);
            this.txtDBVersion.TabIndex = 6;
            // 
            // btnUpdateDBVersion
            // 
            this.btnUpdateDBVersion.Location = new System.Drawing.Point(16, 452);
            this.btnUpdateDBVersion.Name = "btnUpdateDBVersion";
            this.btnUpdateDBVersion.Size = new System.Drawing.Size(168, 23);
            this.btnUpdateDBVersion.TabIndex = 7;
            this.btnUpdateDBVersion.Text = "Aggiorna (singola) versione db n.";
            this.btnUpdateDBVersion.Click += new System.EventHandler(this.btnUpdateDBVersion_Click);
            // 
            // chkDirectory
            // 
            this.chkDirectory.Location = new System.Drawing.Point(360, 444);
            this.chkDirectory.Name = "chkDirectory";
            this.chkDirectory.Size = new System.Drawing.Size(176, 24);
            this.chkDirectory.TabIndex = 8;
            this.chkDirectory.Text = "Controlla Struttura Directory";
            // 
            // frmMain
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(580, 581);
            this.Controls.Add(this.chkDirectory);
            this.Controls.Add(this.btnUpdateDBVersion);
            this.Controls.Add(this.txtDBVersion);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grpMaster);
            this.Controls.Add(this.btnChiudi);
            this.Controls.Add(this.btnSync);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Live Update Sync";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.frmMain_Closing);
            this.grpMaster.ResumeLayout(false);
            this.grpMaster.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridMaster)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() {
			Application.Run(new frmMain());
		}

		private bool Fill=false;
		private void Init() {
			Fill=true;
			DS.Clear();
			if (!File.Exists(m_IndexFileName)) Archivia();
			DS.ReadXml(m_IndexFileName);
			ImpostaRigaMaster();
			ImpostaGridMaster();
			ImpostaControlliMaster();
			AbilitaBottoniMaster();
			Fill=false;
		}

		private bool FromStringToBoolean(string valore) {
			return (valore.ToUpper()=="S");
		}

		private string FromBooleanToString(bool valore) {
			return (valore?"S":"N");
		}

		#region Gestione Controlli form
		private void ImpostaRigaMaster() {
			if (DS.master.Rows.Count==0) {
				DS.master.Rows.Add(DS.master.NewRow());
			}
			txtSource.Text=DS.master.Rows[0][0].ToString();
			txtUserMaster.Text=DS.master.Rows[0]["user"].ToString();
			txtPwdMaster.Text=DS.master.Rows[0]["pwd"].ToString();
			chkLocale.Checked=FromStringToBoolean(DS.master.Rows[0]["flaglocale"].ToString());
            //chkPasV.Checked = !FromStringToBoolean(DS.master.Rows[0]["active"].ToString());
			DisabilitaCampi(chkLocale.Checked);
		}

		private void ImpostaGridMaster() {
			DataTable T=DS.sync;
			foreach (DataColumn C in T.Columns) {
				C.Caption="";
			}
			T.Columns["id"].Caption="ID";
			T.Columns["indirizzo"].Caption="URL / Path locale";
			T.Columns["port"].Caption="Porta";
			T.Columns["descrizione"].Caption="Descrizione";
			HelpForm.SetDataGrid(gridMaster, T);
		}

		private void ImpostaValoriControlliMaster(DataRow R) {
			txtProgressivo.Text=(R==null?"":R["id"].ToString());
			txtIndirizzo.Text=(R==null?"":R["indirizzo"].ToString());
			txtPort.Text=(R==null?"21":R["port"].ToString());
			txtDescrizione.Text=(R==null?"":R["descrizione"].ToString());
			txtUser.Text=(R==null?"":R["user"].ToString());
			txtPwd.Text=(R==null?"":R["pwd"].ToString());
            chkPasV.Checked = (R == null || R["active"].ToString().ToUpper() == "S") ? false : true;
		}

		private void ImpostaControlliMaster() {
			DataRow R=GetCurrentGridRow(gridMaster,"sync");
			if (CurrentMasterRow==R) return;
			CurrentMasterRow=R;
			ImpostaValoriControlliMaster(R);
			AbilitaBottoniMaster();
		}

		private void gridMaster_Click(object sender, System.EventArgs e) {
			ImpostaControlliMaster();
		}

		private DataRow CurrentMasterRow {
			get {
				return m_CurrentMasterRow;
			}
			set {
				m_CurrentMasterRow=value;
				HelpForm.SetLastSelected(DS.sync,m_CurrentMasterRow);
			}
		}

		private void AbilitaBottoniMaster() {
			DataRow[] rows=DS.sync.Select(null,null,DataViewRowState.CurrentRows);
			btnInsertMaster.Enabled=(Stato==eStato.READ);
			btnDeleteMaster.Enabled=((Stato==eStato.READ) && (rows.Length>0));
            //btnUpdateMaster.Enabled=((Stato==eStato.INSERT) || (rows.Length>0));
			btnCancelMaster.Enabled=(Stato!=eStato.READ);
			btnSalva.Enabled=(Stato!=eStato.INSERT);
			btnSync.Enabled=(rows.Length>0);
		}

		private bool IsValidGrid(DataRow R) {
			if (R["indirizzo"].ToString()=="") {
				ShowMsg("Specificare l'indirizzo del sito da sincronizzare");
				txtIndirizzo.Focus();
				return false;
			}
			if (R["descrizione"].ToString()=="") {
				ShowMsg("Specificare la descrizione");
				txtDescrizione.Focus();
				return false;
			}
			if (R["user"].ToString()=="" || R["pwd"].ToString()=="") {
				ShowMsg("Specificare Utente/Password per sito da sincronizzare");
				txtUser.Focus();
				return false;
			}
			return true;
		}

		private void btnInsertMaster_Click(object sender, System.EventArgs e) {
			ImpostaValoriControlliMaster(null);
			Stato=eStato.INSERT;
			AbilitaBottoniMaster();
		}

        void Aggiorna() {
            DataRow R = null;
            if (Stato == eStato.INSERT) {
                R = DS.sync.NewRow();
                DataTable TV = GetTableMemory();
                int max = 0;
                if (TV != null) {
                    DataRow[] rows = TV.Select(null, "id DESC", DataViewRowState.CurrentRows);
                    if (rows.Length > 0)
                        max = (int)rows[0]["id"];
                }
                R["id"] = max + 1;
            }
            else {
                R = CurrentMasterRow;
                R["id"] = Convert.ToInt32(txtProgressivo.Text);
            }
            R["indirizzo"] = txtIndirizzo.Text.Trim();
            R["descrizione"] = txtDescrizione.Text;
            R["user"] = txtUser.Text.Trim();
            R["pwd"] = txtPwd.Text.Trim();
            R["port"] = (txtPort.Text.Trim() != "" ? txtPort.Text.Trim() : "21");
            R["active"] = chkPasV.Checked ? "N" : "S";
            if (!IsValidGrid(R))
                return;
            if (Stato == eStato.INSERT)
                DS.sync.Rows.Add(R);
            R.AcceptChanges();
            Stato = eStato.READ;
            modified = true;
            CurrentMasterRow = R;
            ImpostaValoriControlliMaster(R);
            AbilitaBottoniMaster();
        }

		private void btnUpdateMaster_Click(object sender, System.EventArgs e) {
            Aggiorna();
		}

		private void btnDeleteMaster_Click(object sender, System.EventArgs e) {
			Stato=eStato.READ;
			if (CurrentMasterRow==null) {
				ShowMsg("Selezionare una riga");
				return;
			}
			DialogResult res=ShowQuestion("Sei sicuro di voler cancellare la riga?");
			if (res!=DialogResult.Yes) return;
			CurrentMasterRow.Delete();
			DS.sync.AcceptChanges();
			ImpostaControlliMaster();
			AbilitaBottoniMaster();
			modified=true;
		}

		private void btnCancelMaster_Click(object sender, System.EventArgs e) {
			CurrentMasterRow=null;
			Stato=eStato.READ;
			ImpostaControlliMaster();
			AbilitaBottoniMaster();
			modified=false;
		}

		private void AbilitaSync(bool enable) {
			btnSync.Enabled=enable;
		}

		private DataRow GetCurrentGridRow(DataGrid G,string tablename){
			if (tablename==null) return null;
			DataTable T = DS.Tables[tablename];
			DataSet  DSV = (DataSet) G.DataSource;
			if (DSV==null) return null;
			DataTable TV=  DSV.Tables[G.DataMember];
			if (TV==null) return null;		
			if (TV.Rows.Count==0) return null;
			DataRowView DV = null;
			try {
				DV = (DataRowView) G.BindingContext[DSV, TV.TableName].Current;
			}
			catch {
				DV=null;
			}
			if (DV==null) return null;
			DataRow R = DV.Row;
			HelpForm.SetLastSelected(T, R);
			return HelpForm.FindExternalRow(T, R);
		}

		private void Archivia() {
			DS.WriteXml(m_IndexFileName);
			//			XZip.AddFiles(m_IndexFileZip,m_IndexFileDir,C_FILESYNC,true,true);
		}

		private void ShowMsg(string msg) {
			show(msg,"Attenzione",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
		}
		private DialogResult ShowQuestion(string msg) {
			return show(msg,"Domanda",
				MessageBoxButtons.YesNoCancel,MessageBoxIcon.Question);
		}

		private bool IsValidRigaMaster() {
			if (txtSource.Text.Trim()=="") {
				ShowMsg("Specificare il sito da replicare");
				txtSource.Focus();
				return false;
			}
//			if (!chkLocale.Checked && (txtUserMaster.Text.Trim()=="" || txtPwdMaster.Text.Trim()=="")) {
//				ShowMsg("Specificare Utente/Password per sito da replicare");
//				txtUserMaster.Focus();
//				return false;
//			}
			return true;
		}

		private void SalvaRigaMaster() {
			DS.master.Rows[0]["indirizzo"]=txtSource.Text.Trim();
			DS.master.Rows[0]["user"]=txtUserMaster.Text.Trim();
			DS.master.Rows[0]["pwd"]=txtPwdMaster.Text.Trim();
			DS.master.Rows[0]["flaglocale"]=FromBooleanToString(chkLocale.Checked);
            
		}
        void Salva() {
            if (!IsValidRigaMaster())
                return;
            if (modified) {
                SalvaRigaMaster();
                DS.AcceptChanges();
                Archivia();
            }
            Stato = eStato.READ;
            modified = false;
        }
		private void btnSalva_Click(object sender, System.EventArgs e) {
            Aggiorna();
            Salva();
		}

		private bool Chiudi() {
			if (modified) {
				DialogResult res=show("Ci sono modifche, vuoi salvare?","Attenzione",
					MessageBoxButtons.YesNoCancel,MessageBoxIcon.Question);
				if (res==DialogResult.Cancel) return true;
				if (res==DialogResult.Yes) btnSalva_Click(null,null);
			}
			return false;
		}

		private void btnChiudi_Click(object sender, System.EventArgs e) {
			this.Close();
		}

		private void frmMain_Closing(object sender, System.ComponentModel.CancelEventArgs e) {
			e.Cancel=Chiudi();
		}
		private DataTable GetTableMemory() {
			DataSet DSV = (DataSet) gridMaster.DataSource;
			if (DSV==null) return null;
			return DSV.Tables[gridMaster.DataMember];
		}

		private void txtSource_TextChanged(object sender, System.EventArgs e) {
			if (Fill) return;
			modified=true;
		}

		private void txtUserMaster_TextChanged(object sender, System.EventArgs e) {
			if (Fill) return;
			modified=true;
		}

		private void txtPwdMaster_TextChanged(object sender, System.EventArgs e) {
			if (Fill) return;
			modified=true;
		}

		private void txtPort_TextChanged(object sender, System.EventArgs e) {
			if (Fill) return;
			modified=true;
		}

		private void chkLocale_CheckedChanged(object sender, System.EventArgs e) {
			if (Fill) return;
			modified=true;
			DisabilitaCampi(chkLocale.Checked);
		}

		private void DisabilitaCampi(bool disable) {
			txtUserMaster.ReadOnly=disable;
			txtPwdMaster.ReadOnly=disable;
			btnDirBrowse.Visible=disable;
			if (disable) {
				txtUserMaster.Text="";
				txtPwdMaster.Text="";
			}
		}

		private void btnSync_Click(object sender, System.EventArgs e) {
			if (txtSource.Text.Trim()=="") {
				ShowMsg("E' necessario specificare il sito da replicare");
				return;
			}
			if (modified) {
				ShowMsg("Ci sono modifiche in corso, è necessario salvare prima di effettuare il sync");
				return;
			}
			DataTable T=GetTableMemory();
			if (T==null || T.Rows.Count==0) {
				ShowMsg("Specificare almeno un sito da sincronizzare");
				return;
			}
			m_Log=null;
			this.Cursor=Cursors.WaitCursor;
			VisualizzaLog();

			DO_SYNC(T,chkLocale.Checked);
			this.Cursor=Cursors.Default;

		}

		private void VisualizzaLog() {
			//if (m_Log==null) return;
			if (m_Log==null) m_Log="";
			LogForm= new frmLog(QueryCreator.GetPrintable(m_Log));
			LogForm.Show();
			
		}

		private void DO_SYNC(DataTable T, bool IsLocal) {
//			if (IsLocal)
//				DO_SYNC_LOCALE(T);
//			else
//				DO_SYNC_REMOTO(T);

			//Al momento è gestito solo da locale
			DO_SYNC_LOCALE(T);
		}

		private void btnDirBrowse_Click(object sender, System.EventArgs e) {
			FolderBrowserDialog F=new FolderBrowserDialog();
			if (txtSource.Text.Trim()!="") F.SelectedPath=txtSource.Text.Trim();
			F.Description="Selezionare la cartella radice del LiveUpdate";
			if (F.ShowDialog()!=DialogResult.OK) return;
			txtSource.Text=F.SelectedPath;
		}

		#endregion

		#region Sincronizzazione da LOCALE
		/// <summary>
		/// Questo metodo viene utilizzato quando il sito da replicare è una cartella locale
		/// </summary>
		/// <param name="source">indirizzo da replicare</param>
		/// <param name="T">Tabella che contiene i siti da sincronizzare</param>
		private void DO_SYNC_LOCALE(DataTable T) {
			try {
				string tempdirmaster=Application.StartupPath+@"\sync\";
				string tempdirslave=tempdirmaster+@"slave\";
				string localdir=XDir.CheckFinalSlash(txtSource.Text.Trim());
				XDir.CheckCreate(tempdirmaster);
				XDir.Svuota(tempdirmaster,true);
				XDir.CheckCreate(tempdirslave);
				//Per ogni index, se in locale non esiste anziché uscire continuo l'elaborazione
				//e se l'indice locale è null la sincronizzazione viene ignorata ma viene aggiunto un msg di log
				DataSet DSMasterDLL=GetDSIndex_LOCALE(localdir,tempdirmaster,"D");
				if (DSMasterDLL==null) AggiungiLog(localdir,"Sincronizzazione DLL non eseguita");

				DataSet DSMasterReport=GetDSIndex_LOCALE(localdir, tempdirmaster,"R");
				if (DSMasterReport==null) AggiungiLog(localdir,"Sincronizzazione Report non eseguita");

				DataSet DSMasterSQL=GetDSIndex_LOCALE(localdir, tempdirmaster,"S");
				if (DSMasterSQL==null) AggiungiLog(localdir,"Sincronizzazione Script SQL non eseguita");

                //DataSet DSMasterSP=GetDSIndex_LOCALE(localdir, tempdirmaster,"P");
                //if (DSMasterSP==null) AggiungiLog(localdir,"Sincronizzazione Stored Procedure non eseguita");

				//DataSet DSMasterOnDemand=GetDSIndex_LOCALE(localdir, tempdirmaster,"N");
				//if (DSMasterOnDemand==null) AggiungiLog(localdir,"Sincronizzazione On Demand non eseguita");

				//check per ogni sito da sincronizzare
				foreach (DataRow R in T.Rows) {
					string indirizzo=R["indirizzo"].ToString();
					int port=GetPort(R["port"].ToString());
					string user=R["user"].ToString();
					string pwd=R["pwd"].ToString();
					Ftp ftpSlave;
					try {
						ftpSlave=InitServerFTP(indirizzo, port, user, pwd, (R["active"].ToString().ToUpper() == "S"), false);
					}
					catch (Exception e) {
						ShowMsg($"Errore nel collegamento al sito {indirizzo}\r\n"+e.Message);
						continue;
					}

					if (ftpSlave == null) {
						ShowMsg($"Errore nel collegamento al sito {indirizzo}");
						continue;
					}
                    if (R["active"].ToString().ToUpper() == "S") {
                        ftpSlave.SetActiveMode(true);
                    }
                    else {
                        ftpSlave.SetActiveMode(false);
                    }
					if (ftpSlave==null) continue;
					if (chkDirectory.Checked) CheckLiveUpdateStructure(ftpSlave);
//					DataSet DSSlaveDLL=GetDSIndex_REMOTO(ftpSlave,tempdirslave,"D");
//					DataSet DSSlaveReport=GetDSIndex_REMOTO(ftpSlave,tempdirslave,"R");
//					DataSet DSSlaveSQL=GetDSIndex_REMOTO(ftpSlave,tempdirslave,"S");
//					DataSet DSSlaveSP=GetDSIndex_REMOTO(ftpSlave,tempdirslave,"P");
//					DataSet DSSlaveOnDemand=GetDSIndex_REMOTO(ftpSlave,tempdirslave,"N");
					try {
						Sincronizza_LOCALE(localdir,
							DSMasterDLL, DSMasterReport, DSMasterSQL, null, null,
							ftpSlave,
							tempdirslave,
							//DSSlaveDLL,DSSlaveReport,DSSlaveSQL,DSSlaveSP, DSSlaveOnDemand, 
							tempdirmaster);
					}
					catch (Exception e) {
						ShowMsg($"Errore nell'aggiornamento del sito {indirizzo}\r\n"+e.Message);
					}

					ftpSlave.Close();
				}
                
			}
			catch (Exception E) {
				ShowMsg("Elaborazione interrotta\r\r"+E.Message);
			}
            LogForm.btnChiudi.Visible = true;
		}

		private int GetPort(string testo) {
			//default = 21
			if (testo==null || testo=="") return 21;
			try {
				int port=Convert.ToInt32(testo);
				if (port<0) return 21;
				return port;
			}
			catch {
				return 21;
			}
		}
		/// <summary>
		/// Controlla la struttura della cartella LiveUpdate
		/// Presenza delle cartelle ondemand - report - sp - sql - zip
		/// </summary>
		/// <param name="ftpDest">Istanza ftp da aggiornare</param>
		private void CheckLiveUpdateStructure(Ftp ftpDest) {
            string zipDir = (IsNet45OrNewer() ? "zip4" : "zip");

            //dll
            ftpDest.CheckDir(zipDir);
			//report
			ftpDest.CheckDir("report");
			//script sql
			ftpDest.CheckDir("sql");
			//stored procedure
			ftpDest.CheckDir("sp");
			//on demand
			ftpDest.CheckDir("ondemand");
		}

		/// <summary>
		/// Sincronizzazione ddl/report/sp del server ftp destinazione
		/// </summary>
		/// <param name="localdir">path locale del liveupdate</param>
		/// <param name="SourceDLL">Dataset index sorgente DLL</param>
		/// <param name="SourceReport">Dataset index sorgente Report</param>
		/// <param name="SourceSQL">Dataset index sorgente sql</param>
		/// <param name="ftpDest">server ftp destinazione</param>
		/// <param name="DestDLL">Dataset index destinazione DLL</param>
		/// <param name="DestReport">Dataset index destinazione Report</param>
		/// <param name="DestSQL">Dataset index destinazione sql</param>
		/// <param name="tempdir">cartella di appoggio per download file</param>
		private void Sincronizza_LOCALE(string localdir, DataSet SourceDLL, DataSet SourceReport, 
			DataSet SourceSQL, DataSet SourceSP, DataSet SourceOnDemand,
			Ftp ftpDest, 
			string tempdirslave,
			//DataSet DestDLL, DataSet DestReport, 	DataSet DestSQL, DataSet DestSP, DataSet DestOnDemand, 
			string tempdirmaster) {

			bool res=SincronizzaDLLReport_LOCALE(localdir,SourceDLL,ftpDest,tempdirslave,tempdirmaster, "D");
			if (res) res=SincronizzaDLLReport_LOCALE(localdir,SourceReport,ftpDest,tempdirslave,tempdirmaster, "R");
            if (res) res = SincronizzaSQL_LOCALE(localdir, SourceSQL, ftpDest, tempdirslave, tempdirmaster);
            //if (res) res = SincronizzaSP_LOCALE(localdir, SourceSP, ftpDest, tempdirslave, tempdirmaster);

            //if (res) res = SincronizzaOnDemand_LOCALE(localdir, SourceOnDemand, ftpDest, tempdirslave, tempdirmaster);

			//Aggiorno file siti.txt
            if (res) res = AggiornaFile_LOCALE(localdir, ftpDest, tempdirmaster, "", "easy2siti.txt");
			AggiungiLog(ftpDest.Host,"---------------------------------------------");
		}

		/// <summary>
		/// Esegue sincronizzazione tra cartella locale e server ftp di dll/report
		/// </summary>
		/// <param name="localdir">cartella locale liveupdate (root)</param>
		/// <param name="Source">Dataset index sorgente DLL/Report</param>
		/// <param name="ftpDest">server ftp destinazione</param>
		/// <param name="Dest">Dataset index destinazione DLL/Report</param>
		/// <param name="tempdir">cartella di appoggio per download file</param>
		/// <param name="type">D = Dll - R = Report</param>
		/// <returns>True se va a buon fine o se non ci sono file da aggiornare</returns>
		private bool SincronizzaDLLReport_LOCALE(string localdir, DataSet Source, Ftp ftpDest, 
					string tempdirslave, string tempdirmaster, string type) {

			string versionfilename;
			//La sincronizzazione viene ignorata se il DS sorgente è null
			if (Source==null) return true;
			//risultato del metodo
			bool risultato=true;
			
			string filename="";  //nome del file indice da usare (fileindex.xml.zip / reportindex.xml.zip)
			string remotedir=""; //cartella in cui saranno copiati i singoli file (DLL / REPORT)
			if (type=="D") {
				filename=C_INDEXDLLZIP;
				remotedir= (IsNet45OrNewer() ? "zip4" : "zip"); 
				versionfilename= (IsNet45OrNewer() ? "versionesw4.txt" : "versionesw.txt");
			}
			else {
				filename=C_INDEXREPORTZIP;
				remotedir="report";
				versionfilename="versionereport.txt";
			}


			//Leggo la versione del file locale
			StreamReader read=new StreamReader(localdir+@"\"+versionfilename);
			string localversion=read.ReadLine();
			read.Close();
			string remoteversion;

			string tempname=tempdirmaster+@"\~tmp_"+versionfilename;
			if (!ftpDest.GetFile(tempname, versionfilename)) {
				AggiungiLog(ftpDest.Host, "Impossibile leggere il file remoto "+filename+ " - "+ftpDest.GetLastError());
                if (show("Proseguo riscaricando tutti i file (si) o salto questa fase (no)?", "Avviso",
                            MessageBoxButtons.YesNo) == DialogResult.No) {
                    return false;
                }
				remoteversion="0.0.000";
				//return false;
			}
			else {
				read=new StreamReader(tempname);
				remoteversion=read.ReadLine();
				read.Close();
			}
			if (localversion.CompareTo(remoteversion)<=0) return true;


			//se non ho file nell'indice aggiornamenti copio il file index e la versione (e nessun file) 
			if (Source.Tables.Count==0) {
				bool res=  AggiornaFile_LOCALE(localdir, ftpDest, tempdirmaster, "", filename);
				if (res) res= AggiornaFile_LOCALE(localdir, ftpDest, tempdirmaster, "", versionfilename); 
				return res;
			}

			DataTable Tsource=Source.Tables["DLL"];
			DataTable Tdest=null;
			DataSet Dest=GetDSIndex_REMOTO(ftpDest,tempdirslave,type);
			if (Dest!=null && Dest.Tables.Count>0) Tdest=Dest.Tables["DLL"];
			foreach (DataRow Rsource in Tsource.Rows) {
				if (Tdest!=null) {
					DataRow[] Rdest = Tdest.Select("dllname="+QueryCreator.quotedstrvalue(Rsource["dllname"],false));
					//se il file è nuovo o da aggiornare
					if (Rdest.Length==0 || IsFileToUpdate(Rsource,Rdest[0])) {
						if (!AggiornaFile_LOCALE(localdir, ftpDest, tempdirmaster, remotedir, Rsource["dllname"].ToString()+".zip"))
							risultato=false;
					}
				}
				else {
					//caso in cui non esiste il file index sul server destinazione
					if (!AggiornaFile_LOCALE(localdir, ftpDest, tempdirmaster, remotedir, Rsource["dllname"].ToString()+".zip")) 
						risultato=false;
				}
			}
			//se è tutto ok  aggiorno pure l'index dei file (nella directory principale dello slave)
			if (risultato) risultato= AggiornaFile_LOCALE(localdir, ftpDest, tempdirmaster, "", filename);

			
			//Aggiorna l'indice versionesw.txt/versionereport.txt (nella directory principale dello slave)
			if (risultato) risultato = AggiornaFile_LOCALE(localdir, ftpDest, tempdirmaster, "", versionfilename); 

			
			return risultato;
		}


		/// <summary>
		/// Esegue sincronizzazione tra cartella locale e server per quanto riguarda gli script sql
		/// </summary>
		/// <param name="localdir">cartella locale liveupdate (root)</param>
		/// <param name="Source">Dataset index sorgente SQL</param>
		/// <param name="ftpDest">server ftp destinazione</param>
		/// <param name="Dest">Dataset index destinazione SQL</param>
		/// <param name="tempdir">cartella di appoggio per download file</param>
		/// <returns>True se va a buon fine o se non ci sono versioni sql da aggiornare</returns>
		private bool SincronizzaSQL_LOCALE(string localdir, DataSet Source, Ftp ftpDest, 
					string tempdirslave, string tempdirmaster) {

			string versionfilename="versionedb.txt";
			//La sincronizzazione viene ignorata se il DS sorgente è null
			if (Source==null) return false;
			//risultato del metodo
			bool risultato=true;
			string filename=C_INDEXSQLZIP;
			string remotedir="sql"; //cartella in cui saranno copiati i file
			
			StreamReader read=new StreamReader(localdir+@"\"+versionfilename);
			string localversion=read.ReadLine();
			string remoteversion;
			read.Close();
			string tempname=tempdirmaster+@"\~tmp_"+versionfilename;
			if (!ftpDest.GetFile(tempname, versionfilename)) {
				AggiungiLog(ftpDest.Host, "Impossibile leggere il file remoto "+versionfilename+ " - "+ftpDest.GetLastError());
				remoteversion="0.0.000";
				//return false;
			}
			else {
				read=new StreamReader(tempname);
				remoteversion=read.ReadLine();
				read.Close();
			}

			if (localversion.CompareTo(remoteversion)<=0) return true;


			//se non ho aggiornamenti copio il file index anche se senza aggiornamenti
			if (Source.Tables.Count==0) {
				bool ris =  AggiornaFile_LOCALE(localdir, ftpDest, tempdirmaster, remotedir, filename);
				if (ris) ris = AggiornaFile_LOCALE(localdir, ftpDest, tempdirmaster, "", versionfilename);
				return ris;
			}
			int N=0;

			DataTable Tsource=Source.Tables["updatedbversion"];
			DataTable Tdest=null;
			DataSet Dest=GetDSIndex_REMOTO(ftpDest,tempdirslave,"S"); //S=SQL
			if (Dest!=null && Dest.Tables.Count>0) Tdest=Dest.Tables["updatedbversion"];
			foreach (DataRow Rsource in Tsource.Select(null,"versionname DESC")) {
				N++;
				if (Tdest!=null) {
					DataRow[] Rdest = Tdest.Select("versionname="+QueryCreator.quotedstrvalue(Rsource["versionname"],false));
					if (Rdest.Length==0) {
						if (!AggiornaDir_LOCALE(localdir, ftpDest, tempdirmaster, remotedir, Rsource["versionname"].ToString()))
							risultato=false;
					}
				}
				else {
					//caso in cui non esiste il file index sul server destinazione (la prima volta)
					//if (N%10 != 0) continue;
					if (!AggiornaDir_LOCALE(localdir, ftpDest, tempdirmaster, remotedir, Rsource["versionname"].ToString()))
						risultato=false;
				}
			}
			//se è stato aggiornato almeno un file aggiorno pure l'index (in sql\..) e la versione (nella dir.princ.)
			if (risultato) risultato = AggiornaFile_LOCALE(localdir, ftpDest, tempdirmaster, remotedir, filename);
			if (risultato) risultato= AggiornaFile_LOCALE(localdir, ftpDest, tempdirmaster, "", versionfilename);

			return risultato;
		}


		/// <summary>
		/// Esegue la copia di una cartella specifica di sql 
		/// </summary>
		/// <param name="localdir">cartella locale liveupdate (root)</param>
		/// <param name="Source">Dataset index sorgente SQL</param>
		/// <param name="ftpDest">server ftp destinazione</param>
		/// <param name="Dest">Dataset index destinazione SQL</param>
		/// <param name="tempdir">cartella di appoggio per download file</param>
		/// <returns>True se va a buon fine o se non ci sono versioni sql da aggiornare</returns>
		private bool Sincronizza_DBVERSION_LOCALE(string localdir, DataSet Source, Ftp ftpDest, 
					string tempdirslave, string tempdir, string dbversion) {

			//La sincronizzazione viene ignorata se il DS sorgente è null
			if (Source==null) return false;
			//risultato del metodo
			bool risultato=true;
			//string filename=C_INDEXSQLZIP;
			string remotedir="sql"; //cartella in cui saranno copiati i file
			
			if (!AggiornaDir_LOCALE(localdir, ftpDest, tempdir, remotedir, dbversion))
				risultato=false;

			return risultato;
		}


		
		
		
		/// <summary>
		/// Esegue sincronizzazione tra cartella locale e server per quanto riguarda le stored procedure
		/// </summary>
		/// <param name="localdir">cartella locale liveupdate (root)</param>
		/// <param name="Source">Dataset index sorgente SP</param>
		/// <param name="ftpDest">server ftp destinazione</param>
		/// <param name="Dest">Dataset index destinazione SP</param>
		/// <param name="tempdir">cartella di appoggio per download file</param>
		/// <returns>True se va a buon fine</returns>
		private bool SincronizzaSP_LOCALE(string localdir, DataSet Source, Ftp ftpDest, 
					string tempdirslave, string tempdirmaster) {
			//La sincronizzazione viene ignorata se il DS sorgente è null
			if (Source==null) return false;
			//risultato del metodo
			bool risultato=true;
			//mi dice se è stato aggiornato almeno un file
			bool update=false;
			string filename=C_INDEXSPZIP;
			string remotedir="sp";


			//se non ho aggiornamenti copio il file index anche se senza aggiornamenti
			if (Source.Tables.Count==0) return AggiornaFile_LOCALE(localdir, ftpDest, tempdirmaster, remotedir, filename);
			DataTable Tsource=Source.Tables["DLL"];
			DataTable Tdest=null;
			DataSet Dest=GetDSIndex_REMOTO(ftpDest,tempdirslave,"P"); //P=S.P.

			if (Dest!=null && Dest.Tables.Count>0) Tdest=Dest.Tables["DLL"];
			foreach (DataRow Rsource in Tsource.Rows) {
				if (Tdest!=null) {
					DataRow[] Rdest = Tdest.Select("dllname="+QueryCreator.quotedstrvalue(Rsource["dllname"],false));
					if (Rdest.Length==0 || IsFileToUpdate(Rsource,Rdest[0])) {
						update=true;
						if (!AggiornaFile_LOCALE(localdir, ftpDest, tempdirmaster, remotedir, Rsource["dllname"].ToString()+".zip"))
							risultato=false;
					}
				}
				else {
					update=true;
					//caso in cui non esiste il file index sul server destinazione (la prima volta)
					if (!AggiornaFile_LOCALE(localdir, ftpDest, tempdirmaster, remotedir, Rsource["dllname"].ToString()+".zip")) 
						risultato=false;
				}
			}

			//se è stato aggiornato almeno un file aggiorno pure l'index
			if (update && risultato) return AggiornaFile_LOCALE(localdir, ftpDest, tempdirmaster, "", filename);
			return risultato;
		}

		/// <summary>
		/// Esegue sincronizzazione tra cartella locale e server per quanto riguarda gli aggiornamenti on demand
		/// </summary>
		/// <param name="localdir">cartella locale liveupdate (root)</param>
		/// <param name="Source">Dataset index sorgente SQL</param>
		/// <param name="ftpDest">server ftp destinazione</param>
		/// <param name="Dest">Dataset index destinazione SQL</param>
		/// <param name="tempdir">cartella di appoggio per download file</param>
		/// <returns>True se va a buon fine o se non ci sono versioni sql da aggiornare</returns>
		private bool SincronizzaOnDemand_LOCALE(string localdir, DataSet Source, Ftp ftpDest, 
					string tempdirslave, string tempdirmaster) {
			//La sincronizzazione viene ignorata se il DS sorgente è null
			if (Source==null) return true;
			//risultato del metodo
			bool risultato=true;
			//mi dice se è stato aggiornato almeno un file
			bool update=false;
			string filename=C_INDEXONDEMANDZIP;
			string remotedir="ondemand";
			//se non ho aggiornamenti copio il file index anche se senza aggiornamenti
			if (Source.Tables.Count==0) return AggiornaFile_LOCALE(localdir, ftpDest, tempdirmaster, remotedir, filename);
			DataTable Tsource=Source.Tables["update"];
			DataTable Tdest=null;
			DataSet Dest=GetDSIndex_REMOTO(ftpDest,tempdirslave,"N"); //P=S.P.

			if (Dest!=null && Dest.Tables.Count>0) Tdest=Dest.Tables["update"];
			foreach (DataRow Rsource in Tsource.Select()) {
				if (Tdest!=null) {
                    DataRow[] Rdest = Tdest.Select("code=" + QueryCreator.quotedstrvalue(Rsource["code"], false));
					if (Rdest.Length==0) {
						update=true;
                        if (!AggiornaDir_LOCALE(localdir, ftpDest, tempdirmaster, remotedir, Rsource["code"].ToString()))
							risultato=false;
					}
				}
				else {
					update=true;
					//caso in cui non esiste il file index sul server destinazione (la prima volta)
                    if (!AggiornaDir_LOCALE(localdir, ftpDest, tempdirmaster, remotedir, Rsource["code"].ToString()))
						risultato=false;
				}
			}
			//se è stato aggiornato almeno un file aggiorno pure l'index
			if (update && risultato)return AggiornaFile_LOCALE(localdir, ftpDest, tempdirmaster, "ondemand", filename);
			return risultato;
		}

	
		/// <summary>
		/// Aggiorna il file versione specificato se la versione locale risulta maggiore di quella remota
		/// </summary>
		/// <param name="localdir">root cartella live update</param>
		/// <param name="ftpDest">ftp Server destinazione</param>
		/// <param name="tempdir">cartella temporanea</param>
		/// <param name="filename">file versione da aggiornare</param>
//		private void SincronizzaVersione_LOCALE(string localdir, Ftp ftpDest, string tempdir, string filename) {
//			//Leggo la versione del file locale
//			StreamReader read=new StreamReader(localdir+@"\"+filename);
//			string localversion=read.ReadLine();
//			string tempname=tempdir+@"\~tmp_"+filename;
//			if (!ftpDest.GetFile(tempname, filename)) {
//				AggiungiLog(ftpDest.Host, "Impossibile leggere il file "+filename+ " - "+ftpDest.GetLastError());
//				return;
//			}
//			read=new StreamReader(tempname);
//			string remoteversion=read.ReadLine();
//			if (localversion.CompareTo(remoteversion)<=0) return;
//			AggiornaFile_LOCALE(localdir, ftpDest, tempdir, "", filename);
//		}

		private bool AggiornaFile_LOCALE(string localdir, Ftp ftpDest, string tempdir, string remotedir, string filename) {
			return AggiornaFile_LOCALE(localdir,ftpDest,tempdir,remotedir,filename,false);
		}

		/// <summary>
		/// Se non presente in tempdir copia il file in tempdir ed esegue una Put sul server ftp.
		/// Per i file SQL viene sempre effettuata una copia perché potrebbero esserci più versioni
		/// dello stesso file
		/// </summary>
		/// <param name="localdir">root cartella live update</param>
		/// <param name="ftpDest">server ftp destinazione</param>
		/// <param name="tempdir">cartella temporanea</param>
		/// <param name="remotedir">path relativo destionazione</param>
		/// <param name="filename">nome del file</param>
		/// <param name="GetAlways">True per scaricare/copiare sempre il file e ignorare il file presente in tempdir</param>
		/// <returns>True se va a buon fine l'aggiornamento</returns>
		private bool AggiornaFile_LOCALE(string localdir, Ftp ftpDest, string tempdir, string remotedir, string filename, bool GetAlways) {
			string fullname=tempdir+filename;
			//se non esiste o se il flag è true (in caso di script sql l'omonimia puo' essere frequente) lo copio
			if (!File.Exists(fullname) || GetAlways) {
				string s=XFile.Copia(localdir+@"\"+remotedir+@"\"+filename,fullname,true);
				if (s!=null) {
					AggiungiLog(localdir,s);
					return false;
				}
			}
			string putfile=(remotedir!=""?remotedir+"/"+filename:filename);
			if (!ftpDest.PutFile(fullname,putfile)) {
				AggiungiLog(ftpDest.Host,"Non ho potuto copiare il file "+filename+" sul sito.");
				AggiungiLog(ftpDest.Host,ftpDest.GetLastError());
				return false;
			}			
			else {
				AggiungiLog(ftpDest.Host,"Copiato il file "+putfile+" sul sito.");
			}
            //Application.DoEvents();
			return true;
		}

	    
		/// <summary>
		/// Utilizzata per aggiornare intere versioni (cartelle) di script SQL / on demand
		/// </summary>
		/// <param name="localdir">root cartella live update</param>
		/// <param name="ftpDest">server ftp destinazione</param>
		/// <param name="tempdir">temp folder</param>
		/// <param name="remotedir">path relativo web</param>
		/// <param name="dir">directory (versione sql / codice aggiornamento on demand) da aggiornare</param>
		/// <returns>True se va a buon fine l'operazione</returns>
		private bool AggiornaDir_LOCALE(string localdir, Ftp ftpDest, string tempdir, string remotedir, string dir) {
			bool update=true;
			string fulllocaldir=XDir.Concat(XDir.Concat(localdir,remotedir),dir);
			string fulltempdir=XDir.Concat(XDir.Concat(tempdir,remotedir),dir);
			if (!XDir.CheckCreate(fulltempdir)) return false;
			XDir.Svuota(fulltempdir,true);
			if (XDir.Copia(fulllocaldir,fulltempdir)!=null) return false;

			//Check remote dir
			string fullremotedir=remotedir+"/"+dir;
			string[] files=ftpDest.DirFull(fullremotedir);
			//null or 0 files <-> dir inesistente o cartella esistente ma vuota
			if (files==null || files.Length==0) {
				if (!ftpDest.checkDirectoryFtpCompleta(fullremotedir)) {
					AggiungiLog(ftpDest.Host, ftpDest.GetLastError());
					return false;
				}
			
			}
			DirectoryInfo D=new DirectoryInfo(fulltempdir);
			foreach (FileInfo F in D.GetFiles("*.zip")) {                
				if (!AggiornaFile_LOCALE(localdir,ftpDest,tempdir,"",remotedir+"/"+dir+"/"+F.Name,false)) update=false;
                if (!update) return false;
			}
			return update;
		}

		/// <summary>
		/// Restistuisce il dataset relativo all'indice richiesto (Dll/Report)
		/// </summary>
		/// <param name="localdir">path della cartella liveupdate</param>
		/// <param name="localdir">cartella locale temporanea</param>
		/// <param name="TYPE">"D" Dll - "R" Report - "S" Script sql - "P" Stored procedure - "N" On Demand</param>
		private DataSet GetDSIndex_LOCALE(string localdir, string tempdir, string type) {
			string filename="";
			string filenamezip="";
			string fileziptocopy="";
			switch(type.ToUpper()) {
				case "D": 
					filename=C_INDEXDLL; 
					filenamezip=C_INDEXDLLZIP;
					break;
				case "R": 
					filename=C_INDEXREPORT; 
					filenamezip=C_INDEXREPORTZIP;
					break;
				case "S": 
					filename=C_INDEXSQL; 
					filenamezip=C_INDEXSQLZIP;
					break;
				case "P": 
					filename=C_INDEXSP; 
					filenamezip=C_INDEXSPZIP;
					break;
				case "N": 
					filename=C_INDEXONDEMAND; 
					filenamezip=C_INDEXONDEMANDZIP;
					break;
			}
			fileziptocopy=filenamezip;
			if (type=="S") fileziptocopy=@"\sql\"+filenamezip;
			if (type=="N") fileziptocopy=@"\ondemand\"+filenamezip;
			string s=XFile.Copia(localdir+fileziptocopy,tempdir+filenamezip,true);
			if (s!=null) {
				AggiungiLog(localdir, s);
				return null;
			}
			//lo estraggo
			XZip.ExtractFiles(tempdir+filenamezip,tempdir,filename,true,true);
			//ottengo la lista
			DataSet DSindex=new DataSet();
			DSindex.ReadXml(tempdir+filename);
			return DSindex;
		}

		/// <summary>
		/// Restistuisce il dataset relativo all'indice richiesto (Dll/Report)
		/// </summary>
		/// <param name="server">server ftp</param>
		/// <param name="tempdir">cartella locale</param>
		/// <param name="TYPE">"D" Dll - "R" Report - "S" Script sql</param>
		private DataSet GetDSIndex_REMOTO(Ftp server, string tempdir, string type) {
			string filename="";
			string filenamezip="";
			string fileziptocopy="";
			switch(type.ToUpper()) {
				case "D": 
					filename=C_INDEXDLL; 
					filenamezip=C_INDEXDLLZIP;
					break;
				case "R": 
					filename=C_INDEXREPORT; 
					filenamezip=C_INDEXREPORTZIP;
					break;
				case "S": 
					filename=C_INDEXSQL; 
					filenamezip=C_INDEXSQLZIP;
					break;
				case "P": 
					filename=C_INDEXSP; 
					filenamezip=C_INDEXSPZIP;
					break;
				case "N": 
					filename=C_INDEXONDEMAND; 
					filenamezip=C_INDEXONDEMANDZIP;
					break;
			}
			fileziptocopy=filenamezip;
			if (type=="S") fileziptocopy="sql/"+filenamezip;
			if (type=="N") fileziptocopy="ondemand/"+filenamezip;
			if (!server.GetFile(tempdir+filenamezip,fileziptocopy)) {
				AggiungiLog(server.Host, server.GetLastError());
				return null;
			}
			//lo estraggo
			XZip.ExtractFiles(tempdir+filenamezip,tempdir,filename,true,true);
			//ottengo la lista
			DataSet DSindex=new DataSet();
			DSindex.ReadXml(tempdir+filename);
			return DSindex;
		}

		#endregion


		#region Metodi Comuni
		private bool IsFileToUpdate(DataRow Rsource, DataRow Rdest) {
			int major1=Convert.ToInt32(Rsource["major"]);
			int minor1=Convert.ToInt32(Rsource["minor"]);
			int build1=Convert.ToInt32(Rsource["build"]);
			int major2=Convert.ToInt32(Rdest["major"]);
			int minor2=Convert.ToInt32(Rdest["minor"]);
			int build2=Convert.ToInt32(Rdest["build"]);
			if ((major1>major2) || 
				(major1==major2 && minor1>minor2) || 
				(major1==major2 && minor1==minor2 && build1>build2)) {
				return true;
			}
			return false;
		}

		/// <summary>
		/// Esegue le operazioni di inizializzazione per operare su un server ftp
		/// </summary>
		/// <param name="address">indirizzo server ftp</param>
		/// <param name="user">utente</param>
		/// <param name="pwd">password</param>
		/// <param name="IsMaster">True se riguarda il server da replicare</param>
		/// <returns>Istanza ftp se OK altrimenti null</returns>
		private Ftp InitServerFTP(string address, int port, string user, string pwd, bool active, bool IsMaster) {
			string host=GetHostByAddress(address);
			Ftp server=GetFtpInstance(host, port, user, pwd, active,  IsMaster);
			if (server==null) return null;
			string dir=GetPathByAddress(address);
			if (!server.ChangeDir(dir)) {
				AggiungiLog(server.Host,server.GetLastError());
				return null;
			}
			return server;
		}

		/// <summary>
		/// A partire da ftp://ciccio.pippo.it/cartella1/cartella2/ restituisce ciccio.pippo.it
		/// </summary>
		/// <param name="address">indirizzo ftp</param>
		private string GetHostByAddress(string address) {
			if (address==null || address=="") return null;
			//elimino eventuale prefisso
			if (address.IndexOf("//",0)>0) address=address.Substring(address.IndexOf("//",0)+2);
			//ricavo l'host
			int pos=address.IndexOf("/");
			//non contiene path relativi
			if (pos==-1) return address;
			//restituisco host senza cartelle
			return address.Substring(0,pos);
		}

		/// <summary>
		/// A partire da ftp://ciccio.pippo.it/cartella1/cartella2/ restituisce cartella1/cartella2
		/// </summary>
		/// <param name="address">indirizzo ftp</param>
		private string GetPathByAddress(string address) {
			if (address==null || address=="") return null;
			//elimino eventuale prefisso
			if (address.IndexOf("//",0)>0) address=address.Substring(address.IndexOf("//",0)+2);
			//elimino host
			int pos=address.IndexOf("/");
			//non contiene path relativi
			if (pos==-1 || pos==address.Length-1) return ".";
			//restituisco host senza cartelle
			return address.Substring(pos+1);
		}

		/// <summary>
		/// Apre una connessione ftp ed esegue il login
		/// </summary>
		/// <param name="host">server ftp</param>
		/// <param name="user">utente</param>
		/// <param name="pwd">password</param>
		/// <param name="master">True se riguarda il server da replicare</param>
		/// <returns>Istanza FtpClient se va a buon fine</returns>
		private Ftp GetFtpInstance(string host, int port, string user, string pwd, bool activeMode, bool master) {
			Ftp client=null;
			try {
				client = new Ftp(host, port);
                client.SetActiveMode(activeMode);
				if (!client.IsConnected) throw new Exception(client.GetLastError());
				if (client.Login(user,pwd)) return client;
				throw new Exception(client.GetLastError());
			}	
			catch (Exception E) {
				AggiungiLog(host,(client!=null?E.Message:"Impossibile connettersi"));
				return null;
			}
		}
		private void AggiungiLog(string host, string msg) {
			m_Log="# Server ftp ["+host+"] -  ["+msg+"]\r\n"+m_Log;
			LogForm.txtLog.Text= QueryCreator.GetPrintable(m_Log);
			LogForm.Refresh();
			//Application.DoEvents();
		}

		#endregion

		#region Copia Singola versione SQL
		private void btnUpdateDBVersion_Click(object sender, System.EventArgs e) {
			string dbversion = txtDBVersion.Text.Trim();
			if (dbversion==""){
				ShowMsg("E' necessario specificare la versione db da copiare");
				return;
			}
			if (txtSource.Text.Trim()=="") {
				ShowMsg("E' necessario specificare il sito da replicare");
				return;
			}
			if (modified) {
				ShowMsg("Ci sono modifiche in corso, è necessario salvare prima di effettuare il sync");
				return;
			}
			DataTable T=GetTableMemory();
			if (T==null || T.Rows.Count==0) {
				ShowMsg("Specificare almeno un sito da sincronizzare");
				return;
			}
			m_Log=null;
			this.Cursor=Cursors.WaitCursor;
			VisualizzaLog();

			try {
				string tempdirmaster=Application.StartupPath+@"\sync\";
				string tempdirslave=tempdirmaster+@"slave\";
				string localdir=XDir.CheckFinalSlash(txtSource.Text.Trim());
				XDir.CheckCreate(tempdirmaster);
				XDir.Svuota(tempdirmaster,true);
				XDir.CheckCreate(tempdirslave);

				DataSet DSMasterSQL=GetDSIndex_LOCALE(localdir, tempdirmaster,"S");
				if (DSMasterSQL==null) AggiungiLog(localdir,"Sincronizzazione Script SQL non eseguita");


				//check per ogni sito da sincronizzare
				foreach (DataRow R in T.Rows) {
					string indirizzo=R["indirizzo"].ToString();
					int port=GetPort(R["port"].ToString());
					string user=R["user"].ToString();
					string pwd=R["pwd"].ToString();
					Ftp ftpSlave=InitServerFTP(indirizzo, port, user, pwd,(R["active"].ToString().ToUpper() == "S"), false);
					if (ftpSlave==null) continue;
                    if (R["active"].ToString().ToUpper() == "S") {
                        ftpSlave.SetActiveMode(true);
                    }
                    else {
                        ftpSlave.SetActiveMode(false);
                    }
					CheckLiveUpdateStructure(ftpSlave);

					bool res = Sincronizza_DBVERSION_LOCALE(localdir,DSMasterSQL,ftpSlave,tempdirslave,tempdirmaster,dbversion);
				    if (res) {
                        string remotedir = "sql"; //cartella in cui saranno copiati i file
                        string filename = C_INDEXSQLZIP;
                        AggiornaFile_LOCALE(localdir, ftpSlave, tempdirmaster, remotedir, filename);
                    }

                    ftpSlave.Close();
				}
			}
			catch (Exception E) {
				ShowMsg("Elaborazione interrotta\r\r"+E.Message);
			}
			
			this.Cursor=Cursors.Default;

		}

		#endregion

        private void chkPasV_CheckStateChanged(object sender, EventArgs e) {        
			if (Fill) return;
			modified=true;
		
        }

	}
}


