
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
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using metadatalibrary;
using System.Data;
using System.Drawing;
using System.IO;

namespace BackupRestore//BackupRestore//
{
	/// <summary>
	/// Summary description for frmDB.
	/// </summary>
	public class frmDB : MetaDataForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		//connessione al db master
		EntityDispatcher E;
		private DataAccess Conn;
//		private MySQL Conn;

		private string dbname="";
		private string LastBackupFileDir="";
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabBackup;
		private System.Windows.Forms.TabPage tabRestore;
		private System.Windows.Forms.Button btnCambia;
		private System.Windows.Forms.TextBox txtLastBackup;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtDesc;
		private System.Windows.Forms.TextBox txtName;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.RadioButton rdoSovrascrivi;
		private System.Windows.Forms.RadioButton rdoAggiungi;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.RadioButton rdoDifferenziale;
		private System.Windows.Forms.RadioButton rdoCompleto;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Button btnEseguiBackup;
		private System.Windows.Forms.TextBox txtDBName;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtDBName2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ComboBox cboRestore;
		private System.Windows.Forms.CheckBox chkReplace;
		private System.Windows.Forms.Button btnEseguiRestore;
		private System.Windows.Forms.Button btnInfo;
		private string[,] roots;
		private System.Windows.Forms.Label lblRestore;
		private bool InBinding;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label lblRipristino;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.RadioButton rdoFile;
		private System.Windows.Forms.RadioButton rdoDB;
		private System.Windows.Forms.RadioButton rdoOperativo;
		private System.Windows.Forms.RadioButton rdoNonOperativo;
		private System.Windows.Forms.Button btnCambiaFile;
		private System.Windows.Forms.TextBox txtLastRestore;
		private System.Windows.Forms.DataGrid gridDB;
		private System.Windows.Forms.DataGrid gridFile;
        private DataRow LastSelRow = null;
        string servername;
        private Label label8;
        private TextBox txtPwdUtente;
        private TextBox txtNomeUtente;
        private Label label6;
        private Label label9;
        private TextBox txtPwdBackup;
        private TextBox txtUserBackup;
        private Label label10;
        private Label label11;
		private DataRow LastSelRowNum=null;
		public frmDB(EntityDispatcher E)
		{

			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			this.E=E;
			Conn = E.Conn;

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			if (Conn==null) {
				btnEseguiBackup.Enabled=false;
				btnEseguiRestore.Enabled=false;
				btnCambia.Enabled=false;
				return;
			}

			Conn.ChangeDataBase("master");
			
			txtDBName.Text=E.GetSys("database").ToString();
            servername = E.GetSys("server").ToString();
			dbname=txtDBName.Text;
			txtDBName2.Text=dbname;
			GetDBInfo();
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabBackup = new System.Windows.Forms.TabPage();
            this.label11 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtPwdBackup = new System.Windows.Forms.TextBox();
            this.txtUserBackup = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btnCambia = new System.Windows.Forms.Button();
            this.txtLastBackup = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDesc = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rdoSovrascrivi = new System.Windows.Forms.RadioButton();
            this.rdoAggiungi = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdoDifferenziale = new System.Windows.Forms.RadioButton();
            this.rdoCompleto = new System.Windows.Forms.RadioButton();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnEseguiBackup = new System.Windows.Forms.Button();
            this.txtDBName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tabRestore = new System.Windows.Forms.TabPage();
            this.label8 = new System.Windows.Forms.Label();
            this.txtPwdUtente = new System.Windows.Forms.TextBox();
            this.txtNomeUtente = new System.Windows.Forms.TextBox();
            this.gridFile = new System.Windows.Forms.DataGrid();
            this.btnCambiaFile = new System.Windows.Forms.Button();
            this.rdoNonOperativo = new System.Windows.Forms.RadioButton();
            this.rdoOperativo = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.rdoFile = new System.Windows.Forms.RadioButton();
            this.rdoDB = new System.Windows.Forms.RadioButton();
            this.txtLastRestore = new System.Windows.Forms.TextBox();
            this.btnInfo = new System.Windows.Forms.Button();
            this.btnEseguiRestore = new System.Windows.Forms.Button();
            this.chkReplace = new System.Windows.Forms.CheckBox();
            this.gridDB = new System.Windows.Forms.DataGrid();
            this.lblRipristino = new System.Windows.Forms.Label();
            this.cboRestore = new System.Windows.Forms.ComboBox();
            this.txtDBName2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblRestore = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabBackup.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabRestore.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridFile)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridDB)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabBackup);
            this.tabControl1.Controls.Add(this.tabRestore);
            this.tabControl1.Location = new System.Drawing.Point(8, 8);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(517, 541);
            this.tabControl1.TabIndex = 49;
            // 
            // tabBackup
            // 
            this.tabBackup.Controls.Add(this.label11);
            this.tabBackup.Controls.Add(this.label9);
            this.tabBackup.Controls.Add(this.txtPwdBackup);
            this.tabBackup.Controls.Add(this.txtUserBackup);
            this.tabBackup.Controls.Add(this.label10);
            this.tabBackup.Controls.Add(this.label7);
            this.tabBackup.Controls.Add(this.btnCambia);
            this.tabBackup.Controls.Add(this.txtLastBackup);
            this.tabBackup.Controls.Add(this.label1);
            this.tabBackup.Controls.Add(this.txtDesc);
            this.tabBackup.Controls.Add(this.txtName);
            this.tabBackup.Controls.Add(this.groupBox2);
            this.tabBackup.Controls.Add(this.groupBox1);
            this.tabBackup.Controls.Add(this.label5);
            this.tabBackup.Controls.Add(this.label4);
            this.tabBackup.Controls.Add(this.btnEseguiBackup);
            this.tabBackup.Controls.Add(this.txtDBName);
            this.tabBackup.Controls.Add(this.label2);
            this.tabBackup.Location = new System.Drawing.Point(4, 22);
            this.tabBackup.Name = "tabBackup";
            this.tabBackup.Size = new System.Drawing.Size(509, 515);
            this.tabBackup.TabIndex = 0;
            this.tabBackup.Text = "Backup";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(38, 326);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(194, 13);
            this.label11.TabIndex = 77;
            this.label11.Text = "Informazioni necessarie su alcuni server";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(251, 350);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(190, 13);
            this.label9.TabIndex = 76;
            this.label9.Text = "Password utente autorizzato al backuo";
            // 
            // txtPwdBackup
            // 
            this.txtPwdBackup.Location = new System.Drawing.Point(254, 366);
            this.txtPwdBackup.Name = "txtPwdBackup";
            this.txtPwdBackup.PasswordChar = '*';
            this.txtPwdBackup.Size = new System.Drawing.Size(144, 20);
            this.txtPwdBackup.TabIndex = 75;
            // 
            // txtUserBackup
            // 
            this.txtUserBackup.Location = new System.Drawing.Point(38, 367);
            this.txtUserBackup.Name = "txtUserBackup";
            this.txtUserBackup.Size = new System.Drawing.Size(144, 20);
            this.txtUserBackup.TabIndex = 73;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(38, 350);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(172, 13);
            this.label10.TabIndex = 74;
            this.label10.Text = "Nome utente autorizzato al backup";
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Red;
            this.label7.Location = new System.Drawing.Point(64, 160);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(320, 24);
            this.label7.TabIndex = 61;
            this.label7.Text = "ATTENZIONE, il backup verrà salvato sul server";
            this.label7.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnCambia
            // 
            this.btnCambia.Location = new System.Drawing.Point(60, 232);
            this.btnCambia.Name = "btnCambia";
            this.btnCambia.Size = new System.Drawing.Size(128, 23);
            this.btnCambia.TabIndex = 60;
            this.btnCambia.Text = "Cambia destinazione";
            this.btnCambia.Click += new System.EventHandler(this.btnCambia_Click);
            // 
            // txtLastBackup
            // 
            this.txtLastBackup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLastBackup.Location = new System.Drawing.Point(60, 208);
            this.txtLastBackup.Name = "txtLastBackup";
            this.txtLastBackup.ReadOnly = true;
            this.txtLastBackup.Size = new System.Drawing.Size(381, 20);
            this.txtLastBackup.TabIndex = 59;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(60, 192);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(224, 16);
            this.label1.TabIndex = 58;
            this.label1.Text = "Backup su";
            // 
            // txtDesc
            // 
            this.txtDesc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDesc.Location = new System.Drawing.Point(156, 72);
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Size = new System.Drawing.Size(285, 20);
            this.txtDesc.TabIndex = 57;
            // 
            // txtName
            // 
            this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtName.Location = new System.Drawing.Point(156, 48);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(285, 20);
            this.txtName.TabIndex = 56;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rdoSovrascrivi);
            this.groupBox2.Controls.Add(this.rdoAggiungi);
            this.groupBox2.Location = new System.Drawing.Point(60, 264);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(320, 48);
            this.groupBox2.TabIndex = 55;
            this.groupBox2.TabStop = false;
            // 
            // rdoSovrascrivi
            // 
            this.rdoSovrascrivi.Location = new System.Drawing.Point(162, 16);
            this.rdoSovrascrivi.Name = "rdoSovrascrivi";
            this.rdoSovrascrivi.Size = new System.Drawing.Size(140, 24);
            this.rdoSovrascrivi.TabIndex = 1;
            this.rdoSovrascrivi.Text = "Sovrascrivi il supporto";
            // 
            // rdoAggiungi
            // 
            this.rdoAggiungi.Checked = true;
            this.rdoAggiungi.Location = new System.Drawing.Point(18, 16);
            this.rdoAggiungi.Name = "rdoAggiungi";
            this.rdoAggiungi.Size = new System.Drawing.Size(128, 24);
            this.rdoAggiungi.TabIndex = 0;
            this.rdoAggiungi.TabStop = true;
            this.rdoAggiungi.Text = "Aggiungi al supporto";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdoDifferenziale);
            this.groupBox1.Controls.Add(this.rdoCompleto);
            this.groupBox1.Location = new System.Drawing.Point(60, 96);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(320, 48);
            this.groupBox1.TabIndex = 54;
            this.groupBox1.TabStop = false;
            // 
            // rdoDifferenziale
            // 
            this.rdoDifferenziale.Location = new System.Drawing.Point(168, 16);
            this.rdoDifferenziale.Name = "rdoDifferenziale";
            this.rdoDifferenziale.Size = new System.Drawing.Size(88, 24);
            this.rdoDifferenziale.TabIndex = 43;
            this.rdoDifferenziale.Text = "Differenziale";
            this.rdoDifferenziale.CheckedChanged += new System.EventHandler(this.rdoDifferenziale_CheckedChanged);
            // 
            // rdoCompleto
            // 
            this.rdoCompleto.Checked = true;
            this.rdoCompleto.Location = new System.Drawing.Point(64, 16);
            this.rdoCompleto.Name = "rdoCompleto";
            this.rdoCompleto.Size = new System.Drawing.Size(72, 24);
            this.rdoCompleto.TabIndex = 42;
            this.rdoCompleto.TabStop = true;
            this.rdoCompleto.Text = "Completo";
            this.rdoCompleto.CheckedChanged += new System.EventHandler(this.rdoCompleto_CheckedChanged);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(60, 74);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 16);
            this.label5.TabIndex = 53;
            this.label5.Text = "Descrizione";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(60, 50);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 16);
            this.label4.TabIndex = 52;
            this.label4.Text = "Nome";
            // 
            // btnEseguiBackup
            // 
            this.btnEseguiBackup.Location = new System.Drawing.Point(163, 394);
            this.btnEseguiBackup.Name = "btnEseguiBackup";
            this.btnEseguiBackup.Size = new System.Drawing.Size(121, 23);
            this.btnEseguiBackup.TabIndex = 51;
            this.btnEseguiBackup.Text = "Esegui BACKUP";
            this.btnEseguiBackup.Click += new System.EventHandler(this.btnEsegui_Click);
            // 
            // txtDBName
            // 
            this.txtDBName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDBName.Location = new System.Drawing.Point(156, 24);
            this.txtDBName.Name = "txtDBName";
            this.txtDBName.ReadOnly = true;
            this.txtDBName.Size = new System.Drawing.Size(285, 20);
            this.txtDBName.TabIndex = 50;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(60, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 16);
            this.label2.TabIndex = 49;
            this.label2.Text = "Database";
            // 
            // tabRestore
            // 
            this.tabRestore.Controls.Add(this.label8);
            this.tabRestore.Controls.Add(this.txtPwdUtente);
            this.tabRestore.Controls.Add(this.txtNomeUtente);
            this.tabRestore.Controls.Add(this.gridFile);
            this.tabRestore.Controls.Add(this.btnCambiaFile);
            this.tabRestore.Controls.Add(this.rdoNonOperativo);
            this.tabRestore.Controls.Add(this.rdoOperativo);
            this.tabRestore.Controls.Add(this.groupBox3);
            this.tabRestore.Controls.Add(this.txtLastRestore);
            this.tabRestore.Controls.Add(this.btnInfo);
            this.tabRestore.Controls.Add(this.btnEseguiRestore);
            this.tabRestore.Controls.Add(this.chkReplace);
            this.tabRestore.Controls.Add(this.gridDB);
            this.tabRestore.Controls.Add(this.lblRipristino);
            this.tabRestore.Controls.Add(this.cboRestore);
            this.tabRestore.Controls.Add(this.txtDBName2);
            this.tabRestore.Controls.Add(this.label3);
            this.tabRestore.Controls.Add(this.label6);
            this.tabRestore.Controls.Add(this.lblRestore);
            this.tabRestore.Location = new System.Drawing.Point(4, 22);
            this.tabRestore.Name = "tabRestore";
            this.tabRestore.Size = new System.Drawing.Size(509, 515);
            this.tabRestore.TabIndex = 1;
            this.tabRestore.Text = "Restore";
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(235, 416);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(186, 13);
            this.label8.TabIndex = 72;
            this.label8.Text = "Password utente autorizzato al restore";
            // 
            // txtPwdUtente
            // 
            this.txtPwdUtente.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtPwdUtente.Location = new System.Drawing.Point(238, 432);
            this.txtPwdUtente.Name = "txtPwdUtente";
            this.txtPwdUtente.PasswordChar = '*';
            this.txtPwdUtente.Size = new System.Drawing.Size(144, 20);
            this.txtPwdUtente.TabIndex = 71;
            // 
            // txtNomeUtente
            // 
            this.txtNomeUtente.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtNomeUtente.Location = new System.Drawing.Point(22, 433);
            this.txtNomeUtente.Name = "txtNomeUtente";
            this.txtNomeUtente.Size = new System.Drawing.Size(144, 20);
            this.txtNomeUtente.TabIndex = 69;
            // 
            // gridFile
            // 
            this.gridFile.AllowNavigation = false;
            this.gridFile.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridFile.CaptionVisible = false;
            this.gridFile.DataMember = "";
            this.gridFile.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.gridFile.Location = new System.Drawing.Point(8, 120);
            this.gridFile.Name = "gridFile";
            this.gridFile.ReadOnly = true;
            this.gridFile.Size = new System.Drawing.Size(485, 184);
            this.gridFile.TabIndex = 68;
            this.gridFile.Visible = false;
            this.gridFile.Click += new System.EventHandler(this.gridFile_Click);
            this.gridFile.DoubleClick += new System.EventHandler(this.gridFile_DoubleClick);
            // 
            // btnCambiaFile
            // 
            this.btnCambiaFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCambiaFile.Location = new System.Drawing.Point(461, 88);
            this.btnCambiaFile.Name = "btnCambiaFile";
            this.btnCambiaFile.Size = new System.Drawing.Size(32, 23);
            this.btnCambiaFile.TabIndex = 67;
            this.btnCambiaFile.Text = "...";
            this.btnCambiaFile.Visible = false;
            this.btnCambiaFile.Click += new System.EventHandler(this.btnCambiaFile_Click);
            // 
            // rdoNonOperativo
            // 
            this.rdoNonOperativo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.rdoNonOperativo.Location = new System.Drawing.Point(8, 324);
            this.rdoNonOperativo.Name = "rdoNonOperativo";
            this.rdoNonOperativo.Size = new System.Drawing.Size(354, 22);
            this.rdoNonOperativo.TabIndex = 66;
            this.rdoNonOperativo.Text = "Lascia il DB non operativo. Restore differenziali consentiti";
            this.rdoNonOperativo.Visible = false;
            // 
            // rdoOperativo
            // 
            this.rdoOperativo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.rdoOperativo.Checked = true;
            this.rdoOperativo.Location = new System.Drawing.Point(8, 310);
            this.rdoOperativo.Name = "rdoOperativo";
            this.rdoOperativo.Size = new System.Drawing.Size(342, 18);
            this.rdoOperativo.TabIndex = 65;
            this.rdoOperativo.TabStop = true;
            this.rdoOperativo.Text = "Lascia il DB operativo. Restore differenziali non consentiti";
            this.rdoOperativo.Visible = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.rdoFile);
            this.groupBox3.Controls.Add(this.rdoDB);
            this.groupBox3.Location = new System.Drawing.Point(8, 32);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(485, 48);
            this.groupBox3.TabIndex = 64;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Tipo di restore";
            // 
            // rdoFile
            // 
            this.rdoFile.Location = new System.Drawing.Point(240, 16);
            this.rdoFile.Name = "rdoFile";
            this.rdoFile.Size = new System.Drawing.Size(136, 24);
            this.rdoFile.TabIndex = 64;
            this.rdoFile.Text = "Restore da File";
            this.rdoFile.CheckedChanged += new System.EventHandler(this.rdoFile_CheckedChanged);
            // 
            // rdoDB
            // 
            this.rdoDB.Checked = true;
            this.rdoDB.Location = new System.Drawing.Point(64, 16);
            this.rdoDB.Name = "rdoDB";
            this.rdoDB.Size = new System.Drawing.Size(144, 24);
            this.rdoDB.TabIndex = 63;
            this.rdoDB.TabStop = true;
            this.rdoDB.Text = "Restore da Database";
            this.rdoDB.CheckedChanged += new System.EventHandler(this.rdoDB_CheckedChanged);
            // 
            // txtLastRestore
            // 
            this.txtLastRestore.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLastRestore.Location = new System.Drawing.Point(136, 88);
            this.txtLastRestore.Name = "txtLastRestore";
            this.txtLastRestore.ReadOnly = true;
            this.txtLastRestore.Size = new System.Drawing.Size(296, 20);
            this.txtLastRestore.TabIndex = 63;
            this.txtLastRestore.Visible = false;
            // 
            // btnInfo
            // 
            this.btnInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnInfo.Location = new System.Drawing.Point(368, 343);
            this.btnInfo.Name = "btnInfo";
            this.btnInfo.Size = new System.Drawing.Size(64, 24);
            this.btnInfo.TabIndex = 59;
            this.btnInfo.Text = "Info";
            this.btnInfo.Click += new System.EventHandler(this.btnInfo_Click);
            // 
            // btnEseguiRestore
            // 
            this.btnEseguiRestore.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnEseguiRestore.Location = new System.Drawing.Point(158, 463);
            this.btnEseguiRestore.Name = "btnEseguiRestore";
            this.btnEseguiRestore.Size = new System.Drawing.Size(120, 24);
            this.btnEseguiRestore.TabIndex = 58;
            this.btnEseguiRestore.Text = "Esegui RESTORE";
            this.btnEseguiRestore.Click += new System.EventHandler(this.btnEseguiRestore_Click);
            // 
            // chkReplace
            // 
            this.chkReplace.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkReplace.Location = new System.Drawing.Point(8, 348);
            this.chkReplace.Name = "chkReplace";
            this.chkReplace.Size = new System.Drawing.Size(216, 16);
            this.chkReplace.TabIndex = 57;
            this.chkReplace.Text = "Forza ripristino sul database esistente";
            // 
            // gridDB
            // 
            this.gridDB.AllowNavigation = false;
            this.gridDB.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridDB.CaptionVisible = false;
            this.gridDB.DataMember = "";
            this.gridDB.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.gridDB.Location = new System.Drawing.Point(8, 120);
            this.gridDB.Name = "gridDB";
            this.gridDB.ReadOnly = true;
            this.gridDB.Size = new System.Drawing.Size(485, 184);
            this.gridDB.TabIndex = 55;
            this.gridDB.Click += new System.EventHandler(this.grid_Click);
            this.gridDB.DoubleClick += new System.EventHandler(this.grid_DoubleClick);
            // 
            // lblRipristino
            // 
            this.lblRipristino.Location = new System.Drawing.Point(8, 90);
            this.lblRipristino.Name = "lblRipristino";
            this.lblRipristino.Size = new System.Drawing.Size(128, 16);
            this.lblRipristino.TabIndex = 54;
            this.lblRipristino.Text = "Backup da ripristinare";
            // 
            // cboRestore
            // 
            this.cboRestore.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboRestore.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboRestore.Location = new System.Drawing.Point(136, 88);
            this.cboRestore.Name = "cboRestore";
            this.cboRestore.Size = new System.Drawing.Size(296, 21);
            this.cboRestore.TabIndex = 53;
            this.cboRestore.SelectedValueChanged += new System.EventHandler(this.cboRestore_SelectedValueChanged);
            // 
            // txtDBName2
            // 
            this.txtDBName2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDBName2.Location = new System.Drawing.Point(136, 8);
            this.txtDBName2.Name = "txtDBName2";
            this.txtDBName2.ReadOnly = true;
            this.txtDBName2.Size = new System.Drawing.Size(357, 20);
            this.txtDBName2.TabIndex = 52;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(8, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 16);
            this.label3.TabIndex = 51;
            this.label3.Text = "Database";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(22, 416);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(168, 13);
            this.label6.TabIndex = 70;
            this.label6.Text = "Nome utente autorizzato al restore";
            // 
            // lblRestore
            // 
            this.lblRestore.Location = new System.Drawing.Point(5, 290);
            this.lblRestore.Name = "lblRestore";
            this.lblRestore.Size = new System.Drawing.Size(416, 24);
            this.lblRestore.TabIndex = 60;
            // 
            // frmDB
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(530, 557);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MaximizeBox = false;
            this.Name = "frmDB";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Backup / Restore Database";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmDB_FormClosed);
            this.tabControl1.ResumeLayout(false);
            this.tabBackup.ResumeLayout(false);
            this.tabBackup.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.tabRestore.ResumeLayout(false);
            this.tabRestore.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridFile)).EndInit();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridDB)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		private void GetDBInfo() {
			// ************ Info per BACKUP ************************
			ImpostaBackup();

			// ************ Info per RESTORE ************************
			ImpostaRestore();
		}

		#region Backup

		private void ImpostaBackup() {
            DataAccess MyConn = Conn;
            if (txtUserBackup.Text.Trim() != "") {
                MyConn = new DataAccess("no", servername, "master",
                txtUserBackup.Text, txtPwdBackup.Text, DateTime.Now.Year, DateTime.Now);
                bool res = false;
                if (MyConn != null) res = MyConn.Open();
                if (!res) MyConn = null;
                if (MyConn == null) {
                    show("Impossibile collegarsi con nome utente e password inseriti", "Attenzione",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }

			//ottengo device_type, physical_device_name, logical_device_name, database_name
			string backupfamily = "use msdb select distinct f.device_type, f.physical_device_name, "+
				"f.logical_device_name, b.database_name from backupmediafamily f, backupset b "+
				"where b.database_name = N'"+dbname+"' and b.backup_finish_date = "+
				"(select MAX(backup_finish_date) from backupmediafamily "+
				"INNER JOIN backupset ON backupmediafamily.media_set_id=backupset.media_set_id "+
				"where backupset.database_name = N'"+dbname+"' and "+
				"(backupmediafamily.device_type=2 or backupmediafamily.device_type=102)) "+
				"and b.media_set_id = f.media_set_id";
            DataTable T = MyConn.SQLRunner(backupfamily);
			if (T!=null && T.Rows.Count>0) txtLastBackup.Text=T.Rows[0]["physical_device_name"].ToString();

			//ottengo LastBackupFileDir
			string lastdir=@"use master execute master.dbo.xp_instance_regread N'HKEY_CURRENT_USER', N'Software\Microsoft\MSSQLServer', N'LastBackupFileDir'";
            T = MyConn.SQLRunner(lastdir);
			if (T!=null && T.Rows.Count>0) LastBackupFileDir=T.Rows[0]["Data"].ToString();
	
			string slash=@":\";
			//ottengo radici tree e lo spazio disponibile per ciascun drive
			string mb="use master execute master.dbo.xp_fixeddrives";
            T = MyConn.SQLRunner(mb);
            if (T == null || T.Rows.Count == 0) {
                if (Conn != MyConn) MyConn.Destroy();
                return;
            }
			roots=new string[2,T.Rows.Count];
			int i=0;
			foreach (DataRow R in T.Rows) {
				//memorizzo radice
				roots[0,i]=R[0].ToString()+slash;
				//ottengo i mega disponibili
				roots[1,i]=R[1].ToString();
				i++;
			}
            if (Conn != MyConn) MyConn.Destroy();
        }

		private string ComponiScriptBackup(string dbname, string path,
			bool differential, bool init, string name, string description) {

			string s = "USE master DECLARE @mydbname varchar(800) SET @mydbname="+
				QueryCreator.quotedstrvalue(dbname,true)+" "+
				"BACKUP DATABASE @mydbname " +
				"TO DISK = "+QueryCreator.quotedstrvalue(path,true)+" WITH";
			if (init)
				s+=" INIT";
			else
				s+=" NOINIT";
			if (differential)
				s+=", DIFFERENTIAL";
			if (name!="")
				s+=", NAME = N"+QueryCreator.quotedstrvalue(name,true);
			if (description!="")
				s+=", DESCRIPTION = N"+QueryCreator.quotedstrvalue(description,true);
			return s;
		}

		//Esecuzione backup
		private void btnEsegui_Click(object sender, System.EventArgs e) {

            DataAccess MyConn=Conn;

            if (txtUserBackup.Text.Trim() != "") {
                MyConn = new DataAccess("no", servername, "master",
                txtUserBackup.Text, txtPwdBackup.Text, DateTime.Now.Year, DateTime.Now);
                bool res = false;
                if (MyConn != null) res = MyConn.Open();
                if (!res) MyConn = null;
                if (MyConn == null) {
                    show("Impossibile collegarsi con nome utente e password inseriti", "Attenzione",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }

            if (MyConn == null) {
				show("Impossibile procedere, la connessione non è attiva", "Attenzione",
					MessageBoxButtons.OK, MessageBoxIcon.Information);
				return;
			}
			
			if (txtLastBackup.Text=="") {
				show("Specificare il nome del file del backup", "Attenzione",
					MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (Conn != MyConn) MyConn.Destroy();
                return;
			}

            if (!CheckFile(txtLastBackup.Text, MyConn)) {
                if (Conn != MyConn) MyConn.Destroy();
                return;
            }

			Cursor.Current=Cursors.WaitCursor;
			try {
				string script = ComponiScriptBackup(dbname,
					txtLastBackup.Text,
					rdoDifferenziale.Checked,
					rdoSovrascrivi.Checked,
					txtName.Text,
					txtDesc.Text);
				//0 = timeout illimitato
                DataTable t = MyConn.SQLRunner(script, true, 0);
				if (t==null)
                    show("Backup fallito\r\rDesc.: " + MyConn.LastError, "Info");
				else {
					show("Operazione di Backup terminata", "Info");
					ImpostaRestore();
				}
			}
			catch (Exception E) {
				show("Impossibile eseguire il backup\r\r"+E.Message, "Attenzione",
					MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			Cursor.Current=Cursors.Default;
            ScriviRegistry(MyConn);
            if (Conn != MyConn) MyConn.Destroy();
        }

		#endregion

		#region Restore

		private void ImpostaRestore() {
			InBinding=true;
			SetBackupHistoryCombo();		
			InBinding=false;
			SetDataGridDB();
		}

		private void SetBackupHistoryCombo() {
			string cmd="use master select backup_set_id,backup_finish_date,name "+
				"from msdb..backupset where database_name = N"+
				QueryCreator.quotedstrvalue(dbname,true)+" and type='D' "+
				"order by backup_start_date desc";
			DataTable T=Conn.SQLRunner(cmd);
			if (T!=null) {
				cboRestore.DataSource=T;
				cboRestore.ValueMember="backup_set_id";
				cboRestore.DisplayMember="backup_finish_date";
			}
		}

		private void SetDataGridDB() {
			if (InBinding) return;
			string backup_id="";
			if (cboRestore.SelectedValue!=null)
				backup_id = cboRestore.SelectedValue.ToString();
			string cmd="use master select backup_set_id, backup_start_date,backup_finish_date,"+
				"name,type,backup_size,position,physical_device_name,description,server_name "+
				"from msdb..backupset inner join msdb..backupmediafamily on "+
				"(msdb..backupset.media_set_id = msdb..backupmediafamily.media_set_id) "+
				"where database_name = N"+
				QueryCreator.quotedstrvalue(dbname,true)+" and type !='F'and backup_start_date >= "+
				"(select backup_start_date from msdb..backupset where backup_set_id = "+
				QueryCreator.quotedstrvalue(backup_id,true)+") order by backup_start_date";
			DataTable T=Conn.SQLRunner(cmd);
			if (T!=null) {
				DataSet DS = new DataSet();
				T.TableName="BackupSet";
				DS.Tables.Add(T);
				gridDB.SetDataBinding(DS, T.TableName);
				//seleziono la riga + recente
				if (T.Rows.Count>0) {
					gridDB.Select(T.Rows.Count-1);
					gridDB.CurrentRowIndex=T.Rows.Count-1;
					LastSelRow=GetSelectedRow(gridDB,true);
				}
				ImpostaGridDB(gridDB, T);
			}
		}

		private void SetDataGridFile(string supporto) {
			//ricavo info relative al file selezionato
			string cmd="RESTORE HEADERONLY FROM DISK = N"+
				QueryCreator.quotedstrvalue(supporto,true)+" WITH NOUNLOAD";
			DataTable T=Conn.SQLRunner(cmd);
			if (T!=null) {
				DataSet DS = new DataSet();
				T.TableName="RestoreSet";
				DS.Tables.Add(T);
				gridFile.SetDataBinding(DS, T.TableName);
				//seleziono la riga + recente
				if (T.Rows.Count>0) {
					gridFile.Select(T.Rows.Count-1);
					gridFile.CurrentRowIndex=T.Rows.Count-1;
					LastSelRowNum=GetSelectedRow(gridFile,false);
				}
				ImpostaGridFile(gridFile, T);
			}
		}

		private void ImpostaGridDB(DataGrid G, DataTable T) {
			foreach (DataColumn C in T.Columns)
				C.Caption="";

			//il primo bisogna valorizzarlo per far sapere che c'è un ordinamento
			T.Columns[0].ExtendedProperties["ListColPos"]=5;

			T.Columns[1].Caption="Data inizio";
			//format per data breve e ora estesa
			HelpForm.SetFormatForColumn(T.Columns[1],"G");
			T.Columns[1].ExtendedProperties["ListColPos"]=4;

			T.Columns[2].Caption="Data fine";
			HelpForm.SetFormatForColumn(T.Columns[2],"G");
			T.Columns[2].ExtendedProperties["ListColPos"]=5;

			T.Columns[3].Caption="Nome";
			T.Columns[3].ExtendedProperties["ListColPos"]=2;

			//tipo di backup (completo, differenziale, ...)
			T.Columns.Add("tipo");
			T.Columns[T.Columns.Count-1].Caption="Tipo";
			AssociaTipoBackup(T,4,T.Columns.Count-1,true);
			T.Columns[T.Columns.Count-1].ExtendedProperties["ListColPos"]=3;
			
			//nascondo backup_size
			T.Columns[5].Caption="";

			//nascondo position
			T.Columns[6].Caption="";

			T.Columns[7].Caption="Ripristina da";
			T.Columns[7].ExtendedProperties["ListColPos"]=1;
			HelpForm.SetGridStyle(G, T);
			metadatalibrary.formatgrids fg = new formatgrids(G);
			fg.AutosizeColumnWidth();
		}

		private void ImpostaGridFile(DataGrid G, DataTable T) {
			foreach (DataColumn C in T.Columns)
				C.Caption="";

			T.Columns[0].Caption="Nome Backup";
			//il primo bisogna valorizzarlo per far sapere che c'è un ordinamento
			T.Columns[0].ExtendedProperties["ListColPos"]=2;

			T.Columns[1].Caption="Descrizione";
			T.Columns[1].ExtendedProperties["ListColPos"]=3;
			
			T.Columns.Add("tipo");
			T.Columns[T.Columns.Count-1].Caption="Tipo";
			AssociaTipoBackup(T,2,T.Columns.Count-1,false);
			T.Columns[T.Columns.Count-1].ExtendedProperties["ListColPos"]=4;

			T.Columns[5].Caption="Numero";
			T.Columns[5].ExtendedProperties["ListColPos"]=1;

			HelpForm.SetGridStyle(G, T);
			metadatalibrary.formatgrids fg = new formatgrids(G);
			fg.AutosizeColumnWidth();
		}

		private void AssociaTipoBackup(DataTable T, int SourceColumnPos, int NewColumnPos, bool FromDB) {
			string COMPLETO=(FromDB?"D":"1");
			string DIFF=(FromDB?"I":"5");
			foreach (DataRow row in T.Rows) {
				if (row[SourceColumnPos].ToString()==COMPLETO) row[NewColumnPos]="Completo";
				if (row[SourceColumnPos].ToString()==DIFF) row[NewColumnPos]="Differenziale";
			}
		}

		private string ComponiScriptRestore(string dbname, string path, string file, bool recovery) {
			string s = "DECLARE @mydbname varchar(800) SET @mydbname="+QueryCreator.quotedstrvalue(dbname,true)+
				" RESTORE DATABASE @mydbname " +
				"FROM DISK = "+QueryCreator.quotedstrvalue(path,true)+" "+
				"WITH  FILE = "+file+" ";
			if (recovery)
				s+=", RECOVERY ";
			else
				s+=", NORECOVERY ";
			if (chkReplace.Checked) s+= ", REPLACE"; 			
			return s;
		}

		private bool CheckFile(string supporto,DataAccess Conn) {
			string cmd="use master EXECUTE master.dbo.xp_fileexist N'"+supporto+"'";
			DataTable T=Conn.SQLRunner(cmd);
			if (T!=null && T.Rows.Count > 0) {
				//la seconda colonna mi dice se è un file o directory
				if (T.Rows[0][1].ToString()=="1") {
					show("Impossibile procedere, il supporto selezionato è una directory", "Attenzione",
						MessageBoxButtons.OK, MessageBoxIcon.Information);
					return false;
				}
				//la terza colonna mi dice se il path esiste
				if (T.Rows[0][2].ToString()=="0") {
					show("Impossibile procedere, la directory contenente il file è inesistente", "Attenzione",
						MessageBoxButtons.OK, MessageBoxIcon.Information);
					return false;
				}
			}
			return true;
		}

		private void btnCambia_Click(object sender, System.EventArgs e) {
            ImpostaBackup();
            DataAccess MyConn = Conn;
            if (txtUserBackup.Text.Trim() != "") {
                MyConn = new DataAccess("no", servername, "master",
                txtUserBackup.Text, txtPwdBackup.Text, DateTime.Now.Year, DateTime.Now);
                bool res = false;
                if (MyConn != null) res = MyConn.Open();
                if (!res) MyConn = null;
                if (MyConn == null) {
                    show("Impossibile collegarsi con nome utente e password inseriti", "Attenzione",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }

            frmTree f = new frmTree(MyConn, roots);
			if (f.ShowDialog()!=DialogResult.OK) return;
			txtLastBackup.Text=f.SupportoSelezionato;
            if (Conn != MyConn) MyConn.Destroy();
        }

		private void cboRestore_SelectedValueChanged(object sender, System.EventArgs e) {
			SetDataGridDB();
		}

		private void btnInfo_Click(object sender, System.EventArgs e) {
			DataRow row=null;
			bool RestoreFromDB;
			if (rdoDB.Checked) {
				row=LastSelRow;
				RestoreFromDB=true;
			}
			else {
				row=LastSelRowNum;
				RestoreFromDB=false;
			}
			if (row==null) {
				show("Selezionare una riga", "Attenzione",
					MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}
			frmInfo F = new frmInfo(row,RestoreFromDB);
			F.ShowDialog();
		}

		private void btnEseguiRestore_Click(object sender, System.EventArgs e) {
            DataAccess MyConn = new DataAccess("no", servername, "master",
                    txtNomeUtente.Text, txtPwdUtente.Text, DateTime.Now.Year, DateTime.Now);
            bool res=false;
            if(MyConn != null) res=MyConn.Open();
            if(!res) MyConn = null;


			if (MyConn==null) {
				show("Impossibile collegarsi con nome utente e password inseriti", "Attenzione",
					MessageBoxButtons.OK, MessageBoxIcon.Information);
				return;
			}
           
			if (rdoDB.Checked) {
				if (LastSelRow==null) {
					show("Seleziona un database da ripristinare", "Attenzione",
						MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MyConn.Close();
					return;
				}
			}
			else {
				if (txtLastRestore.Text=="") {
					show("Specificare il file dal quale eseguire il restore", "Attenzione",
						MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MyConn.Close();
					return;
				}
				if (LastSelRowNum==null) {
					show("Seleziona un database da ripristinare", "Attenzione",
						MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MyConn.Close();
					return;
				}

				if (!CheckFile(txtLastRestore.Text,MyConn)) return;
			}

			string msg="Chiudere tutte le finestre, tutti i dati non salvati verranno persi.\r"+
				"Continuare con il ripristino del database?";
            if (show(msg, "Attenzione",
                MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) != DialogResult.Yes) {
                MyConn.Close();
                return;
            }
        
			Cursor.Current=Cursors.WaitCursor;
            Application.DoEvents();
			try {
                DataTable t;
				string script="";
				if (rdoDB.Checked) {
					if (LastSelRow["tipo"].ToString()=="Completo") {
						script = ComponiScriptRestore(dbname,LastSelRow["physical_device_name"].ToString(),
							LastSelRow["position"].ToString(), true);
						//completo with recovery
						t = EseguiRestore(MyConn, script);
					}
					else {
						//Se ho selezionato un DB di tipo ?Differenziale', eseguo prima un restore
						//dell'ultimo, in senso cronologico, DB Completo e poi quello differenziale
						int id = Convert.ToInt32(LastSelRow["backup_set_id"]);
						string filter = "backup_set_id < "+id+" and type='Completo'";
						string sort = "backup_set_id DESC";
						DataRow[] gridRows=((DataSet)gridDB.DataSource).Tables[0].Select(filter, sort);
						//db completo with norecovery (non operativo)
						script = ComponiScriptRestore(dbname,gridRows[0]["physical_device_name"].ToString(),
							gridRows[0]["position"].ToString(), false);
						t = EseguiRestore( MyConn, script);
						if (t!=null) {
							//db differenziale, with recovery
							script = ComponiScriptRestore(dbname,LastSelRow["physical_device_name"].ToString(),
								LastSelRow["position"].ToString(), true);

                            t = EseguiRestore( MyConn, script);
						}
					}
				}
				else {
                    
                    //In questa modalità è compito dell'utente fornire le opzioni esatte,
					//come recovery/norecovery e/o Completo/Differenziale
					script = ComponiScriptRestore(dbname,txtLastRestore.Text,
						LastSelRowNum["Position"].ToString(), rdoOperativo.Checked);
                    t = EseguiRestore( MyConn, script);
				}

                if(t == null) {
                    show(this,"Restore fallito\r\rDesc.: " + MyConn.LastError, "Informazione",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Cursor.Current = Cursors.Default;
                    MyConn.Close();
                    return;
                }
                else
                    show(this, "Operazione di Restore eseguita con successo.", "Informazione",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			catch (Exception E) {
                show(this, "Impossibile eseguire il restore\r\r" + E.Message, "Attenzione",
					MessageBoxButtons.OK, MessageBoxIcon.Error);
                Cursor.Current = Cursors.Default;
                MyConn.Close();
                return;
            }
			Cursor.Current=Cursors.Default;
			ScriviRegistry(MyConn);
            MyConn.persisting = false;
            MyConn.Close();
            show(this, "Sarà necessario ora chiudere il programma.");
            Close();
            Application.Exit();

		}

		private DataTable EseguiRestore(DataAccess CurrConn, string script) {

//			string script = ComponiScriptRestore(dbname,
//				row["physical_device_name"].ToString(),
//				row["position"].ToString(),
//				recovery);
			//0 = timeout illimitato
			DataTable T= CurrConn.SQLRunner(script,true,0);
            return T;
		}

		private void grid_Click(object sender, System.EventArgs e) {
			LastSelRow=GetSelectedRow(gridDB,true);
		}

		private void gridFile_Click(object sender, System.EventArgs e) {
			LastSelRowNum=GetSelectedRow(gridFile,false);		
		}

		private DataRow GetSelectedRow(DataGrid grid, bool FromDB) {
			DataSet DS = (DataSet)grid.DataSource;
			DataTable TV = DS.Tables[grid.DataMember];
			if (TV.Rows.Count < 1) return null;
			DataRowView DRV = (DataRowView)grid.BindingContext[DS,TV.TableName].Current;
			if (DRV==null) return null;
			if (FromDB) {
				lblRestore.Text="Ripristino da  "+DRV.Row["physical_device_name"].ToString()+
					"  del  "+DRV.Row["backup_finish_date"].ToString();
			}
			else {
				lblRestore.Text="Ripristino del backup - ";
			}
			return DRV.Row;
		}

		private void grid_DoubleClick(object sender, System.EventArgs e) {
			LastSelRow=GetSelectedRow(gridDB,true);
			btnInfo_Click(null,null);
		}

		private void gridFile_DoubleClick(object sender, System.EventArgs e) {
			LastSelRowNum=GetSelectedRow(gridFile,false);
			btnInfo_Click(null,null);
		}

		private void rdoCompleto_CheckedChanged(object sender, System.EventArgs e) {
			AbilitaSupporto(true);
		}

		private void rdoDifferenziale_CheckedChanged(object sender, System.EventArgs e) {
			rdoAggiungi.Checked=true;
			AbilitaSupporto(false);
		}

		private void AbilitaSupporto(bool enable) {
			rdoAggiungi.Enabled=enable;
			rdoSovrascrivi.Enabled=enable;
		}

		private void rdoDB_CheckedChanged(object sender, System.EventArgs e) {
			ImpostaTipoRestore(rdoDB.Checked);
		}
		private void rdoFile_CheckedChanged(object sender, System.EventArgs e) {
			ImpostaTipoRestore(!rdoFile.Checked);
		}

		/// <summary>
		/// Imposta tipologia di restore, se FromDB = True vuol dire che sono
		/// in modalità Database, altrimenti in modalità periferica/file
		/// </summary>
		/// <param name="FromDB"></param>
		private void ImpostaTipoRestore(bool FromDB) {
			if (FromDB) {
				lblRipristino.Text="Database da ripristinare";
			}
			else {
				lblRipristino.Text="File da ripristinare";
			}
			//campi visibili tipologia DB
			cboRestore.Visible=FromDB;
			gridDB.Visible=FromDB;
			//campi visibili tipologia File
			txtLastRestore.Visible=!FromDB;
			rdoOperativo.Visible=!FromDB;
			rdoNonOperativo.Visible=!FromDB;
			btnCambiaFile.Visible=!FromDB;
			gridFile.Visible=!FromDB;
		}

		private void btnCambiaFile_Click(object sender, System.EventArgs e) {
			frmTree f = new frmTree(Conn, roots);
			if (f.ShowDialog()!=DialogResult.OK) return;
			txtLastRestore.Text=f.SupportoSelezionato;
			SetDataGridFile(txtLastRestore.Text);
		}

		#endregion

		private void ScriviRegistry(DataAccess C) {
			FileInfo f = new FileInfo(txtLastBackup.Text);
			string dir=f.Directory.FullName;
			if (!dir.EndsWith(@"\")) dir+=@"\";
			string cmd=@"execute master.dbo.xp_instance_regwrite N'HKEY_CURRENT_USER', "+
				@"N'Software\Microsoft\MSSQLServer', N'LastBackupFileDir',REG_SZ, N"+
				QueryCreator.quotedstrvalue(dir,true);
            DataTable t = C.SQLRunner(cmd);
		}

        private void frmDB_FormClosed(object sender, FormClosedEventArgs e) {
            Conn?.ChangeDataBase(dbname);
        }
	}
}
