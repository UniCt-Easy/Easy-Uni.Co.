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

using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using metadatalibrary;
using System.Data;
using System.Text;
using dbbridge;//dbbridge
using System.IO;
using generaSQL;//GeneraSQL
using LiveUpdate;//LiveUpdate
using ConfigLiveUpdate;//ConfigLiveUpdate
using System.Net;
using System.Threading;
using metaeasylibrary;
using System.Security.Cryptography;


namespace Install{//Install//
	/// <summary>
	/// Summary description for FrmInstall.
	/// </summary>
	public class Frm_Install : System.Windows.Forms.Form {

		#region Win Controls
		private Crownwood.Magic.Controls.TabPage tabPage1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label11;
		private Crownwood.Magic.Controls.TabControl tabController;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnNext;
		private System.Windows.Forms.Button btnBack;
		private System.ComponentModel.IContainer components;
		private Crownwood.Magic.Controls.TabPage tabPage2;
		private System.Windows.Forms.Label label19;
		private System.Windows.Forms.Label label20;
		private System.Windows.Forms.Label label21;
		private System.Windows.Forms.Label label22;
		private System.Windows.Forms.Label label23;
		private System.Windows.Forms.Label label24;
		private System.Windows.Forms.TextBox txtUserName;
		private System.Windows.Forms.TextBox txtDBName;
		private System.Windows.Forms.TextBox txtServerName;
		private System.Windows.Forms.Label label25;
		private System.Windows.Forms.Label label26;
		private System.Windows.Forms.Label label27;
		private System.Windows.Forms.Button btnGeneraScript;
		private System.Windows.Forms.Button btnSysDepends;
		private Crownwood.Magic.Controls.TabPage tabPage3;
        private System.Windows.Forms.Label label28;
		private System.Windows.Forms.Label label29;
		private System.Windows.Forms.Label label30;
		private System.Windows.Forms.Label label31;
		private System.Windows.Forms.Label label32;
        private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label33;
		private System.Windows.Forms.Button btnCreaScriptTabSistema;

		private System.Windows.Forms.TextBox txtSourcePwd;
		private System.Windows.Forms.TextBox txtSourceUser;
		private System.Windows.Forms.TextBox txtSourceDataBase;
		private System.Windows.Forms.TextBox txtSourceServer;
        private System.Windows.Forms.CheckBox chkSourceSSPI;
		private Crownwood.Magic.Controls.TabPage tabPage4;
		private System.Windows.Forms.Label label34;
		private System.Windows.Forms.TextBox txtNomeEnte;
		private System.Windows.Forms.Label label35;
		private System.Windows.Forms.Label label36;
		private System.Windows.Forms.Label label39;
		private System.Windows.Forms.ComboBox cmbUserList;
		private System.Windows.Forms.Label label40;
		private System.Windows.Forms.ListBox listClientUser;
		private System.Windows.Forms.Label label41;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label label42;
		private System.Windows.Forms.ListBox listServerUser;
		private System.Windows.Forms.Button btnAddConnection;
		private System.Windows.Forms.Button btnCreateLogin;
		private System.Windows.Forms.ContextMenu menuDelClient;
		private System.Windows.Forms.ContextMenu menuDelServer;
		private System.Windows.Forms.MenuItem mnuDelClient;
		private System.Windows.Forms.MenuItem mnuDelServer;
		private Crownwood.Magic.Controls.TabPage tabPage5;
		private System.Windows.Forms.Label label44;
		private System.Windows.Forms.Label label45;
		private System.Windows.Forms.Label label46;
		private System.Windows.Forms.Label label47;
		private System.Windows.Forms.Label label48;
		private System.Windows.Forms.Label label49;
		private System.Windows.Forms.Label label50;
		private System.Windows.Forms.TextBox txtUpdateServer;
		private System.Windows.Forms.Label txtServerRaggiungibile;
		private System.Windows.Forms.Label txtNonRaggiungibile;
		string CustomTitle;
		private System.Windows.Forms.Button btnTestServer;
		ConfigLiveUpdate.vistaForm LiveUpdateDS;
		private Crownwood.Magic.Controls.TabPage tabPage6;
		private System.Windows.Forms.Label label51;
		private System.Windows.Forms.Label label52;
		private System.Windows.Forms.Label label53;
		private System.Windows.Forms.TextBox txtReportDir;
		private System.Windows.Forms.Button btnChangeReportDir;
		private System.Windows.Forms.Label labReportOk;
		private System.Windows.Forms.Label labReportNotOk;
		private System.Windows.Forms.FolderBrowserDialog DirectoryPicker;
		private Crownwood.Magic.Controls.TabPage tabPage7;
		private System.Windows.Forms.Label label54;
		private System.Windows.Forms.Label label55;
		private System.Windows.Forms.Button btnLiveUpdate;
		private System.Windows.Forms.Label label56;
		private System.Windows.Forms.Label label57;
		private System.Windows.Forms.Label label58;
		private System.Windows.Forms.TextBox txtLiveSWStatus;
		private System.Windows.Forms.TextBox txtLiveRptStatus;
		private System.Windows.Forms.TextBox txtLiveDBStatus;
		private System.Windows.Forms.Timer UpdateLiveStatus;
		string IndirizzoLiveUpdateValido=null;
		private System.Windows.Forms.Label label59;
		private Crownwood.Magic.Controls.TabPage tabPage8;
		private System.Windows.Forms.Label label60;
		private System.Windows.Forms.Label label61;
		private System.Windows.Forms.Label label62;
		private System.Windows.Forms.Label label63;
		private System.Windows.Forms.Label label64;
		private System.Windows.Forms.Label labInfoLicenzaFound;
		private System.Windows.Forms.Label labInfoLicenzaNotFound;
		private System.Windows.Forms.Button btnInsertInfoLicenza;
		private Crownwood.Magic.Controls.TabPage tabPage9;
		private System.Windows.Forms.Label label65;
		private System.Windows.Forms.Label label66;
		private System.Windows.Forms.Label label67;
		private System.Windows.Forms.Label label68;
		private System.Windows.Forms.Label label69;
		private System.Windows.Forms.Label label70;
        private System.Windows.Forms.Label label71;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.TextBox txtWinUser;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Label label13;
		private Crownwood.Magic.Controls.TabPage tabPage10;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.Button btnAllBanche;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.ContextMenu MenuNino;
		private System.Windows.Forms.MenuItem EnableHidden;
		private System.Windows.Forms.Button btnDelLastVersion;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.TextBox txtUserPwd;
		private Crownwood.Magic.Controls.TabPage tabPage11;
		private System.Windows.Forms.Label label72;
		private System.Windows.Forms.TextBox txtDepDescription;
		private System.Windows.Forms.Label label18;
		private System.Windows.Forms.TextBox txtDepName;
		private System.Windows.Forms.Label label17;
		private System.Windows.Forms.Label label73;
		private System.Windows.Forms.GroupBox grpCreazioneDipartimento;
		private System.Windows.Forms.Label label74;
		private System.Windows.Forms.RadioButton rbtCreazioneDipartimento;
		private System.Windows.Forms.RadioButton rbtNonProprioDipartimento;
		private System.Windows.Forms.Label label75;
		private System.Windows.Forms.RadioButton rbtProprioDipartimento;
		private System.Windows.Forms.GroupBox grpNonProprioDipartimento;
		private System.Windows.Forms.GroupBox grpProprioDipartimento;
		private System.Windows.Forms.TextBox txtNewDepPwd;
		private System.Windows.Forms.ComboBox cmbNonProprioDipartimento;
		private System.Windows.Forms.TextBox txtOldDepPwd;
        private System.Windows.Forms.ComboBox cmbProprioDipartimento;
		private System.Windows.Forms.Button btnCreaDataBase;
		private System.Windows.Forms.TextBox txtSourceConn;
		private System.Windows.Forms.TextBox txtConn;
		private System.Windows.Forms.ListBox listDepartmentUser;
		private System.Windows.Forms.Label label78;
		private System.Windows.Forms.Label labSourceConn;
		private System.Windows.Forms.Label labDestConn;


		#endregion

		//Connessione iniziale al DB, come System Administrator
		AllLocal_DataAccess MainConn;		//Di tipo DataAccess
		
		//Connessione al Dipartimento con user=DIPARTIMENTO
		DataAccess DepConn;		//AllLocal_DataAccess

		bool DBNuovo=false;
		bool DipartimentoNuovo=false;

		//Nome utente-dipartimento
		string iddbdepartment;

		DataAccess SourceConn;
		private System.Windows.Forms.ContextMenu MenuDelFromDip;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.Button btnResetAll;
		private System.Windows.Forms.Button btnRestoreDepartentUser;
		private System.Windows.Forms.Button btnRipristinaUtentiNormali;
        private System.Windows.Forms.Label label37;
        private CheckBox chkCopiaTutto;
        private Button btnEffettuaVerifiche;  //Di tipo DataAccess


		EntityDispatcher Disp=null;

		public Frm_Install() {
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			tabController.HideTabsMode = 
				Crownwood.Magic.Controls.TabControl.HideTabsModes.HideAlways;

			FormInit();

		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing ) {
			if( disposing ) {
				if (MainConn!=null) MainConn.Destroy();
				DisposeDepConn();
				DisposeSourceConn();
				if(components != null) {
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Install));
            this.tabController = new Crownwood.Magic.Controls.TabControl();
            this.tabPage3 = new Crownwood.Magic.Controls.TabPage();
            this.chkCopiaTutto = new System.Windows.Forms.CheckBox();
            this.label33 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnEffettuaVerifiche = new System.Windows.Forms.Button();
            this.label32 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.chkSourceSSPI = new System.Windows.Forms.CheckBox();
            this.txtSourceServer = new System.Windows.Forms.TextBox();
            this.txtSourceDataBase = new System.Windows.Forms.TextBox();
            this.txtSourceUser = new System.Windows.Forms.TextBox();
            this.txtSourcePwd = new System.Windows.Forms.TextBox();
            this.label28 = new System.Windows.Forms.Label();
            this.tabPage1 = new Crownwood.Magic.Controls.TabPage();
            this.label13 = new System.Windows.Forms.Label();
            this.label61 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new Crownwood.Magic.Controls.TabPage();
            this.btnRipristinaUtentiNormali = new System.Windows.Forms.Button();
            this.btnRestoreDepartentUser = new System.Windows.Forms.Button();
            this.btnResetAll = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.MenuNino = new System.Windows.Forms.ContextMenu();
            this.EnableHidden = new System.Windows.Forms.MenuItem();
            this.btnSysDepends = new System.Windows.Forms.Button();
            this.btnGeneraScript = new System.Windows.Forms.Button();
            this.label27 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.txtUserPwd = new System.Windows.Forms.TextBox();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.txtDBName = new System.Windows.Forms.TextBox();
            this.txtServerName = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.btnCreaDataBase = new System.Windows.Forms.Button();
            this.btnCreaScriptTabSistema = new System.Windows.Forms.Button();
            this.tabPage11 = new Crownwood.Magic.Controls.TabPage();
            this.grpCreazioneDipartimento = new System.Windows.Forms.GroupBox();
            this.txtNewDepPwd = new System.Windows.Forms.TextBox();
            this.label72 = new System.Windows.Forms.Label();
            this.txtDepDescription = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.txtDepName = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.grpProprioDipartimento = new System.Windows.Forms.GroupBox();
            this.cmbProprioDipartimento = new System.Windows.Forms.ComboBox();
            this.label75 = new System.Windows.Forms.Label();
            this.rbtProprioDipartimento = new System.Windows.Forms.RadioButton();
            this.rbtCreazioneDipartimento = new System.Windows.Forms.RadioButton();
            this.grpNonProprioDipartimento = new System.Windows.Forms.GroupBox();
            this.cmbNonProprioDipartimento = new System.Windows.Forms.ComboBox();
            this.label73 = new System.Windows.Forms.Label();
            this.txtOldDepPwd = new System.Windows.Forms.TextBox();
            this.label74 = new System.Windows.Forms.Label();
            this.rbtNonProprioDipartimento = new System.Windows.Forms.RadioButton();
            this.tabPage10 = new Crownwood.Magic.Controls.TabPage();
            this.btnAllBanche = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.tabPage4 = new Crownwood.Magic.Controls.TabPage();
            this.label37 = new System.Windows.Forms.Label();
            this.listDepartmentUser = new System.Windows.Forms.ListBox();
            this.MenuDelFromDip = new System.Windows.Forms.ContextMenu();
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.label78 = new System.Windows.Forms.Label();
            this.listServerUser = new System.Windows.Forms.ListBox();
            this.menuDelServer = new System.Windows.Forms.ContextMenu();
            this.mnuDelServer = new System.Windows.Forms.MenuItem();
            this.label42 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtWinUser = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.btnCreateLogin = new System.Windows.Forms.Button();
            this.cmbUserList = new System.Windows.Forms.ComboBox();
            this.label35 = new System.Windows.Forms.Label();
            this.btnAddConnection = new System.Windows.Forms.Button();
            this.label41 = new System.Windows.Forms.Label();
            this.listClientUser = new System.Windows.Forms.ListBox();
            this.menuDelClient = new System.Windows.Forms.ContextMenu();
            this.mnuDelClient = new System.Windows.Forms.MenuItem();
            this.label40 = new System.Windows.Forms.Label();
            this.label39 = new System.Windows.Forms.Label();
            this.label36 = new System.Windows.Forms.Label();
            this.txtNomeEnte = new System.Windows.Forms.TextBox();
            this.label34 = new System.Windows.Forms.Label();
            this.tabPage5 = new Crownwood.Magic.Controls.TabPage();
            this.txtNonRaggiungibile = new System.Windows.Forms.Label();
            this.txtServerRaggiungibile = new System.Windows.Forms.Label();
            this.btnTestServer = new System.Windows.Forms.Button();
            this.txtUpdateServer = new System.Windows.Forms.TextBox();
            this.label50 = new System.Windows.Forms.Label();
            this.label49 = new System.Windows.Forms.Label();
            this.label48 = new System.Windows.Forms.Label();
            this.label47 = new System.Windows.Forms.Label();
            this.label46 = new System.Windows.Forms.Label();
            this.label45 = new System.Windows.Forms.Label();
            this.label44 = new System.Windows.Forms.Label();
            this.tabPage6 = new Crownwood.Magic.Controls.TabPage();
            this.labReportNotOk = new System.Windows.Forms.Label();
            this.labReportOk = new System.Windows.Forms.Label();
            this.btnChangeReportDir = new System.Windows.Forms.Button();
            this.txtReportDir = new System.Windows.Forms.TextBox();
            this.label53 = new System.Windows.Forms.Label();
            this.label52 = new System.Windows.Forms.Label();
            this.label51 = new System.Windows.Forms.Label();
            this.tabPage7 = new Crownwood.Magic.Controls.TabPage();
            this.label16 = new System.Windows.Forms.Label();
            this.btnDelLastVersion = new System.Windows.Forms.Button();
            this.label59 = new System.Windows.Forms.Label();
            this.txtLiveDBStatus = new System.Windows.Forms.TextBox();
            this.txtLiveRptStatus = new System.Windows.Forms.TextBox();
            this.txtLiveSWStatus = new System.Windows.Forms.TextBox();
            this.label58 = new System.Windows.Forms.Label();
            this.label57 = new System.Windows.Forms.Label();
            this.label56 = new System.Windows.Forms.Label();
            this.label55 = new System.Windows.Forms.Label();
            this.label54 = new System.Windows.Forms.Label();
            this.btnLiveUpdate = new System.Windows.Forms.Button();
            this.tabPage8 = new Crownwood.Magic.Controls.TabPage();
            this.labInfoLicenzaNotFound = new System.Windows.Forms.Label();
            this.labInfoLicenzaFound = new System.Windows.Forms.Label();
            this.btnInsertInfoLicenza = new System.Windows.Forms.Button();
            this.label64 = new System.Windows.Forms.Label();
            this.label63 = new System.Windows.Forms.Label();
            this.label62 = new System.Windows.Forms.Label();
            this.label60 = new System.Windows.Forms.Label();
            this.tabPage9 = new Crownwood.Magic.Controls.TabPage();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label71 = new System.Windows.Forms.Label();
            this.label70 = new System.Windows.Forms.Label();
            this.label69 = new System.Windows.Forms.Label();
            this.label68 = new System.Windows.Forms.Label();
            this.label67 = new System.Windows.Forms.Label();
            this.label66 = new System.Windows.Forms.Label();
            this.label65 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.DirectoryPicker = new System.Windows.Forms.FolderBrowserDialog();
            this.UpdateLiveStatus = new System.Windows.Forms.Timer(this.components);
            this.txtSourceConn = new System.Windows.Forms.TextBox();
            this.txtConn = new System.Windows.Forms.TextBox();
            this.labSourceConn = new System.Windows.Forms.Label();
            this.labDestConn = new System.Windows.Forms.Label();
            this.tabController.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage11.SuspendLayout();
            this.grpCreazioneDipartimento.SuspendLayout();
            this.grpProprioDipartimento.SuspendLayout();
            this.grpNonProprioDipartimento.SuspendLayout();
            this.tabPage10.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.tabPage6.SuspendLayout();
            this.tabPage7.SuspendLayout();
            this.tabPage8.SuspendLayout();
            this.tabPage9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // tabController
            // 
            this.tabController.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabController.IDEPixelArea = true;
            this.tabController.Location = new System.Drawing.Point(8, -8);
            this.tabController.Name = "tabController";
            this.tabController.SelectedIndex = 2;
            this.tabController.SelectedTab = this.tabPage11;
            this.tabController.Size = new System.Drawing.Size(616, 496);
            this.tabController.TabIndex = 0;
            this.tabController.TabPages.AddRange(new Crownwood.Magic.Controls.TabPage[] {
            this.tabPage1,
            this.tabPage2,
            this.tabPage11,
            this.tabPage3,
            this.tabPage10,
            this.tabPage4,
            this.tabPage5,
            this.tabPage6,
            this.tabPage7,
            this.tabPage8,
            this.tabPage9});
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.chkCopiaTutto);
            this.tabPage3.Controls.Add(this.label33);
            this.tabPage3.Controls.Add(this.groupBox1);
            this.tabPage3.Controls.Add(this.label28);
            this.tabPage3.Location = new System.Drawing.Point(0, 0);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Selected = false;
            this.tabPage3.Size = new System.Drawing.Size(616, 471);
            this.tabPage3.TabIndex = 5;
            this.tabPage3.Title = "Configurazione e/o copia dati";
            // 
            // chkCopiaTutto
            // 
            this.chkCopiaTutto.Location = new System.Drawing.Point(16, 256);
            this.chkCopiaTutto.Name = "chkCopiaTutto";
            this.chkCopiaTutto.Size = new System.Drawing.Size(560, 24);
            this.chkCopiaTutto.TabIndex = 30;
            this.chkCopiaTutto.Text = "Migra un database esistente";
            // 
            // label33
            // 
            this.label33.Location = new System.Drawing.Point(16, 32);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(560, 23);
            this.label33.TabIndex = 24;
            this.label33.Text = "Se lo si desidera, è possibile prelevare alcuni dati da un database esistente, se" +
                "lezionando le relative caselle:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnEffettuaVerifiche);
            this.groupBox1.Controls.Add(this.label32);
            this.groupBox1.Controls.Add(this.label31);
            this.groupBox1.Controls.Add(this.label30);
            this.groupBox1.Controls.Add(this.label29);
            this.groupBox1.Controls.Add(this.chkSourceSSPI);
            this.groupBox1.Controls.Add(this.txtSourceServer);
            this.groupBox1.Controls.Add(this.txtSourceDataBase);
            this.groupBox1.Controls.Add(this.txtSourceUser);
            this.groupBox1.Controls.Add(this.txtSourcePwd);
            this.groupBox1.Location = new System.Drawing.Point(16, 288);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(408, 152);
            this.groupBox1.TabIndex = 20;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Database esistente da cui migrare i dati";
            // 
            // btnEffettuaVerifiche
            // 
            this.btnEffettuaVerifiche.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEffettuaVerifiche.ForeColor = System.Drawing.Color.Brown;
            this.btnEffettuaVerifiche.Location = new System.Drawing.Point(185, 114);
            this.btnEffettuaVerifiche.Name = "btnEffettuaVerifiche";
            this.btnEffettuaVerifiche.Size = new System.Drawing.Size(200, 23);
            this.btnEffettuaVerifiche.TabIndex = 31;
            this.btnEffettuaVerifiche.Text = "Effettua verifiche";
            this.btnEffettuaVerifiche.Click += new System.EventHandler(this.btnEffettuaVerifiche_Click);
            // 
            // label32
            // 
            this.label32.Location = new System.Drawing.Point(80, 16);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(100, 23);
            this.label32.TabIndex = 11;
            this.label32.Text = "Nome server";
            this.label32.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label31
            // 
            this.label31.Location = new System.Drawing.Point(16, 40);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(168, 23);
            this.label31.TabIndex = 12;
            this.label31.Text = "Nome del database";
            this.label31.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label30
            // 
            this.label30.Location = new System.Drawing.Point(8, 64);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(176, 23);
            this.label30.TabIndex = 13;
            this.label30.Text = "Nome utente per connettersi";
            this.label30.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label29
            // 
            this.label29.Location = new System.Drawing.Point(72, 88);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(100, 23);
            this.label29.TabIndex = 14;
            this.label29.Text = "Password";
            this.label29.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chkSourceSSPI
            // 
            this.chkSourceSSPI.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkSourceSSPI.Location = new System.Drawing.Point(3, 114);
            this.chkSourceSSPI.Name = "chkSourceSSPI";
            this.chkSourceSSPI.Size = new System.Drawing.Size(152, 24);
            this.chkSourceSSPI.TabIndex = 15;
            this.chkSourceSSPI.Text = "Sicurezza integrata";
            this.chkSourceSSPI.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkSourceSSPI.CheckedChanged += new System.EventHandler(this.chkSourceSSPI_CheckedChanged);
            // 
            // txtSourceServer
            // 
            this.txtSourceServer.Location = new System.Drawing.Point(184, 16);
            this.txtSourceServer.Name = "txtSourceServer";
            this.txtSourceServer.Size = new System.Drawing.Size(200, 21);
            this.txtSourceServer.TabIndex = 16;
            this.txtSourceServer.Text = "serversw\\sql2000";
            // 
            // txtSourceDataBase
            // 
            this.txtSourceDataBase.Location = new System.Drawing.Point(184, 40);
            this.txtSourceDataBase.Name = "txtSourceDataBase";
            this.txtSourceDataBase.Size = new System.Drawing.Size(200, 21);
            this.txtSourceDataBase.TabIndex = 17;
            this.txtSourceDataBase.Text = "dip00022";
            // 
            // txtSourceUser
            // 
            this.txtSourceUser.Location = new System.Drawing.Point(184, 64);
            this.txtSourceUser.Name = "txtSourceUser";
            this.txtSourceUser.Size = new System.Drawing.Size(200, 21);
            this.txtSourceUser.TabIndex = 18;
            this.txtSourceUser.Text = "sa";
            // 
            // txtSourcePwd
            // 
            this.txtSourcePwd.Location = new System.Drawing.Point(184, 88);
            this.txtSourcePwd.Name = "txtSourcePwd";
            this.txtSourcePwd.PasswordChar = '*';
            this.txtSourcePwd.Size = new System.Drawing.Size(200, 21);
            this.txtSourcePwd.TabIndex = 19;
            this.txtSourcePwd.Text = "PASSWORD";
            // 
            // label28
            // 
            this.label28.Location = new System.Drawing.Point(8, 8);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(600, 23);
            this.label28.TabIndex = 0;
            this.label28.Text = "In questa fase sono riempite le tabelle di configurazione ed eventualmente copiat" +
                "i alcuni dati da un altro database.";
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label13);
            this.tabPage1.Controls.Add(this.label61);
            this.tabPage1.Controls.Add(this.label11);
            this.tabPage1.Controls.Add(this.label10);
            this.tabPage1.Controls.Add(this.label9);
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(0, 0);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Selected = false;
            this.tabPage1.Size = new System.Drawing.Size(616, 471);
            this.tabPage1.TabIndex = 3;
            this.tabPage1.Title = "Introduzione";
            // 
            // label13
            // 
            this.label13.Location = new System.Drawing.Point(24, 128);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(576, 23);
            this.label13.TabIndex = 21;
            this.label13.Text = "Saranno eventualmente inseriti i dati di tutte le banche e sportelli d\'italia";
            // 
            // label61
            // 
            this.label61.Location = new System.Drawing.Point(24, 248);
            this.label61.Name = "label61";
            this.label61.Size = new System.Drawing.Size(576, 16);
            this.label61.TabIndex = 20;
            this.label61.Text = "Saranno inserite le informazioni necessarie alla registrazione del prodotto";
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World);
            this.label11.Location = new System.Drawing.Point(16, 304);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(576, 23);
            this.label11.TabIndex = 12;
            this.label11.Text = "Sarà quindi possibile passare alla configurazione CONTABILE del database.";
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.Location = new System.Drawing.Point(24, 272);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(576, 16);
            this.label10.TabIndex = 11;
            this.label10.Text = "Saranno inserite le informazioni sul cliente, per poter richiedere alla Software " +
                "&& More l\'attivazione del database";
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.Location = new System.Drawing.Point(24, 224);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(576, 16);
            this.label9.TabIndex = 10;
            this.label9.Text = "Sarà effettuato l\'aggiornamento dei dati, dell\'applicazione e dei report";
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.Location = new System.Drawing.Point(24, 80);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(576, 16);
            this.label8.TabIndex = 9;
            this.label8.Text = "Sarà creato, se richiesto, un nuovo database";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.Location = new System.Drawing.Point(24, 200);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(576, 16);
            this.label6.TabIndex = 8;
            this.label6.Text = "Sarà impostata la cartella dei report";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.Location = new System.Drawing.Point(24, 152);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(576, 16);
            this.label4.TabIndex = 7;
            this.label4.Text = "Sarà configurata la connessione al database";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.Location = new System.Drawing.Point(24, 104);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(576, 16);
            this.label7.TabIndex = 6;
            this.label7.Text = "Saranno, ove richiesto, copiati i dati (creditori/bilancio/classificazioni) da un" +
                " altro database esistente";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.Location = new System.Drawing.Point(24, 176);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(576, 16);
            this.label5.TabIndex = 4;
            this.label5.Text = "Sarà impostato il sito dove risiedono gli aggiornamenti";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World);
            this.label3.Location = new System.Drawing.Point(16, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 23);
            this.label3.TabIndex = 2;
            this.label3.Text = "In particolare:";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World);
            this.label2.Location = new System.Drawing.Point(16, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(576, 23);
            this.label2.TabIndex = 1;
            this.label2.Text = "Questa procedura vi guiderà alla corretta istallazione e configurazione del softw" +
                "are Easy";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World);
            this.label1.Location = new System.Drawing.Point(16, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(272, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Guida alla configurazione di Easy";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnRipristinaUtentiNormali);
            this.tabPage2.Controls.Add(this.btnRestoreDepartentUser);
            this.tabPage2.Controls.Add(this.btnResetAll);
            this.tabPage2.Controls.Add(this.label15);
            this.tabPage2.Controls.Add(this.btnSysDepends);
            this.tabPage2.Controls.Add(this.btnGeneraScript);
            this.tabPage2.Controls.Add(this.label27);
            this.tabPage2.Controls.Add(this.label26);
            this.tabPage2.Controls.Add(this.label25);
            this.tabPage2.Controls.Add(this.txtUserPwd);
            this.tabPage2.Controls.Add(this.txtUserName);
            this.tabPage2.Controls.Add(this.txtDBName);
            this.tabPage2.Controls.Add(this.txtServerName);
            this.tabPage2.Controls.Add(this.label24);
            this.tabPage2.Controls.Add(this.label23);
            this.tabPage2.Controls.Add(this.label22);
            this.tabPage2.Controls.Add(this.label21);
            this.tabPage2.Controls.Add(this.label20);
            this.tabPage2.Controls.Add(this.label19);
            this.tabPage2.Controls.Add(this.btnCreaDataBase);
            this.tabPage2.Controls.Add(this.btnCreaScriptTabSistema);
            this.tabPage2.Location = new System.Drawing.Point(0, 0);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Selected = false;
            this.tabPage2.Size = new System.Drawing.Size(616, 471);
            this.tabPage2.TabIndex = 4;
            this.tabPage2.Title = "Creazione nuovo database";
            // 
            // btnRipristinaUtentiNormali
            // 
            this.btnRipristinaUtentiNormali.ForeColor = System.Drawing.Color.Brown;
            this.btnRipristinaUtentiNormali.Location = new System.Drawing.Point(112, 416);
            this.btnRipristinaUtentiNormali.Name = "btnRipristinaUtentiNormali";
            this.btnRipristinaUtentiNormali.Size = new System.Drawing.Size(272, 23);
            this.btnRipristinaUtentiNormali.TabIndex = 43;
            this.btnRipristinaUtentiNormali.Text = "Ripristina Utenti-Normali del dip. dopo RESTORE";
            this.btnRipristinaUtentiNormali.Visible = false;
            this.btnRipristinaUtentiNormali.Click += new System.EventHandler(this.btnRipristinaUtentiNormali_Click);
            // 
            // btnRestoreDepartentUser
            // 
            this.btnRestoreDepartentUser.Location = new System.Drawing.Point(128, 344);
            this.btnRestoreDepartentUser.Name = "btnRestoreDepartentUser";
            this.btnRestoreDepartentUser.Size = new System.Drawing.Size(240, 23);
            this.btnRestoreDepartentUser.TabIndex = 42;
            this.btnRestoreDepartentUser.Text = "Ripristina Utenti-Dipartimento dopo RESTORE";
            this.btnRestoreDepartentUser.Visible = false;
            this.btnRestoreDepartentUser.Click += new System.EventHandler(this.btnRestoreDepartentUser_Click);
            // 
            // btnResetAll
            // 
            this.btnResetAll.ForeColor = System.Drawing.Color.Brown;
            this.btnResetAll.Location = new System.Drawing.Point(128, 376);
            this.btnResetAll.Name = "btnResetAll";
            this.btnResetAll.Size = new System.Drawing.Size(240, 23);
            this.btnResetAll.TabIndex = 41;
            this.btnResetAll.Text = "Reset All Password di utenti del dipartimento";
            this.btnResetAll.Visible = false;
            this.btnResetAll.Click += new System.EventHandler(this.btnResetAll_Click);
            // 
            // label15
            // 
            this.label15.ContextMenu = this.MenuNino;
            this.label15.Location = new System.Drawing.Point(56, 256);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(8, 16);
            this.label15.TabIndex = 17;
            // 
            // MenuNino
            // 
            this.MenuNino.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.EnableHidden});
            this.MenuNino.Popup += new System.EventHandler(this.MenuNino_Popup);
            // 
            // EnableHidden
            // 
            this.EnableHidden.Index = 0;
            this.EnableHidden.Text = "default";
            this.EnableHidden.Click += new System.EventHandler(this.EnableHidden_Click);
            // 
            // btnSysDepends
            // 
            this.btnSysDepends.Location = new System.Drawing.Point(448, 128);
            this.btnSysDepends.Name = "btnSysDepends";
            this.btnSysDepends.Size = new System.Drawing.Size(136, 23);
            this.btnSysDepends.TabIndex = 16;
            this.btnSysDepends.Text = "Aggiorna SysDepends";
            this.btnSysDepends.Visible = false;
            this.btnSysDepends.Click += new System.EventHandler(this.btnSysDepends_Click);
            // 
            // btnGeneraScript
            // 
            this.btnGeneraScript.ForeColor = System.Drawing.Color.Brown;
            this.btnGeneraScript.Location = new System.Drawing.Point(448, 96);
            this.btnGeneraScript.Name = "btnGeneraScript";
            this.btnGeneraScript.Size = new System.Drawing.Size(136, 23);
            this.btnGeneraScript.TabIndex = 15;
            this.btnGeneraScript.Text = "Genera Script strutture";
            this.btnGeneraScript.Visible = false;
            this.btnGeneraScript.Click += new System.EventHandler(this.btnGeneraScript_Click);
            // 
            // label27
            // 
            this.label27.Location = new System.Drawing.Point(16, 200);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(272, 23);
            this.label27.TabIndex = 14;
            this.label27.Text = "Nota per i TECNICI:";
            // 
            // label26
            // 
            this.label26.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label26.Location = new System.Drawing.Point(16, 224);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(592, 32);
            this.label26.TabIndex = 13;
            this.label26.Text = "Il database sarà creato nella cartella predefinita per l\'istanza di SQL Server se" +
                "lezionata. Analogamente, le collation saranno quelle di default del Server";
            this.label26.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label25
            // 
            this.label25.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label25.Location = new System.Drawing.Point(16, 272);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(592, 48);
            this.label25.TabIndex = 12;
            this.label25.Text = resources.GetString("label25.Text");
            this.label25.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtUserPwd
            // 
            this.txtUserPwd.Location = new System.Drawing.Point(224, 128);
            this.txtUserPwd.Name = "txtUserPwd";
            this.txtUserPwd.PasswordChar = '*';
            this.txtUserPwd.Size = new System.Drawing.Size(200, 21);
            this.txtUserPwd.TabIndex = 10;
            this.txtUserPwd.Text = "PASSWORD";
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(224, 104);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(200, 21);
            this.txtUserName.TabIndex = 9;
            this.txtUserName.Text = "sa";
            // 
            // txtDBName
            // 
            this.txtDBName.Location = new System.Drawing.Point(224, 80);
            this.txtDBName.Name = "txtDBName";
            this.txtDBName.Size = new System.Drawing.Size(200, 21);
            this.txtDBName.TabIndex = 8;
            this.txtDBName.Text = "nino1";
            // 
            // txtServerName
            // 
            this.txtServerName.Location = new System.Drawing.Point(224, 56);
            this.txtServerName.Name = "txtServerName";
            this.txtServerName.Size = new System.Drawing.Size(200, 21);
            this.txtServerName.TabIndex = 7;
            this.txtServerName.Text = "serversw\\sql2000";
            // 
            // label24
            // 
            this.label24.Location = new System.Drawing.Point(112, 128);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(112, 23);
            this.label24.TabIndex = 5;
            this.label24.Text = "Password dell\'utente";
            this.label24.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label23
            // 
            this.label23.Location = new System.Drawing.Point(48, 104);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(176, 23);
            this.label23.TabIndex = 4;
            this.label23.Text = "Nome utente per connettersi";
            this.label23.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label22
            // 
            this.label22.Location = new System.Drawing.Point(56, 80);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(168, 23);
            this.label22.TabIndex = 3;
            this.label22.Text = "Nome del database";
            this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label21
            // 
            this.label21.Location = new System.Drawing.Point(120, 56);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(100, 23);
            this.label21.TabIndex = 2;
            this.label21.Text = "Nome server";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label20
            // 
            this.label20.Location = new System.Drawing.Point(16, 32);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(592, 16);
            this.label20.TabIndex = 1;
            this.label20.Text = "Se non si desidera creare il database, digitare le informazioni sul db a cui conn" +
                "ettersi e spingere il bottone \'Avanti\'";
            // 
            // label19
            // 
            this.label19.Location = new System.Drawing.Point(16, 8);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(592, 23);
            this.label19.TabIndex = 0;
            this.label19.Text = "E\' possibile, se necessario, creare un nuovo database.";
            // 
            // btnCreaDataBase
            // 
            this.btnCreaDataBase.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World);
            this.btnCreaDataBase.Location = new System.Drawing.Point(448, 64);
            this.btnCreaDataBase.Name = "btnCreaDataBase";
            this.btnCreaDataBase.Size = new System.Drawing.Size(136, 23);
            this.btnCreaDataBase.TabIndex = 11;
            this.btnCreaDataBase.Text = "Crea Nuovo Database";
            this.btnCreaDataBase.Click += new System.EventHandler(this.btnCreaDataBase_Click);
            // 
            // btnCreaScriptTabSistema
            // 
            this.btnCreaScriptTabSistema.ForeColor = System.Drawing.Color.Brown;
            this.btnCreaScriptTabSistema.Location = new System.Drawing.Point(432, 344);
            this.btnCreaScriptTabSistema.Name = "btnCreaScriptTabSistema";
            this.btnCreaScriptTabSistema.Size = new System.Drawing.Size(152, 23);
            this.btnCreaScriptTabSistema.TabIndex = 25;
            this.btnCreaScriptTabSistema.Text = "Crea Script dati tab.Sistema";
            this.btnCreaScriptTabSistema.Visible = false;
            this.btnCreaScriptTabSistema.Click += new System.EventHandler(this.btnCreaScriptTabSistema_Click);
            // 
            // tabPage11
            // 
            this.tabPage11.Controls.Add(this.grpCreazioneDipartimento);
            this.tabPage11.Controls.Add(this.grpProprioDipartimento);
            this.tabPage11.Controls.Add(this.rbtProprioDipartimento);
            this.tabPage11.Controls.Add(this.rbtCreazioneDipartimento);
            this.tabPage11.Controls.Add(this.grpNonProprioDipartimento);
            this.tabPage11.Controls.Add(this.rbtNonProprioDipartimento);
            this.tabPage11.Location = new System.Drawing.Point(0, 0);
            this.tabPage11.Name = "tabPage11";
            this.tabPage11.Size = new System.Drawing.Size(616, 471);
            this.tabPage11.TabIndex = 13;
            this.tabPage11.Title = "Scelta dip.";
            // 
            // grpCreazioneDipartimento
            // 
            this.grpCreazioneDipartimento.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grpCreazioneDipartimento.Controls.Add(this.txtNewDepPwd);
            this.grpCreazioneDipartimento.Controls.Add(this.label72);
            this.grpCreazioneDipartimento.Controls.Add(this.txtDepDescription);
            this.grpCreazioneDipartimento.Controls.Add(this.label18);
            this.grpCreazioneDipartimento.Controls.Add(this.txtDepName);
            this.grpCreazioneDipartimento.Controls.Add(this.label17);
            this.grpCreazioneDipartimento.Location = new System.Drawing.Point(184, 248);
            this.grpCreazioneDipartimento.Name = "grpCreazioneDipartimento";
            this.grpCreazioneDipartimento.Size = new System.Drawing.Size(424, 144);
            this.grpCreazioneDipartimento.TabIndex = 33;
            this.grpCreazioneDipartimento.TabStop = false;
            this.grpCreazioneDipartimento.Text = "Creazione di un nuovo dipartimento";
            // 
            // txtNewDepPwd
            // 
            this.txtNewDepPwd.Location = new System.Drawing.Point(80, 56);
            this.txtNewDepPwd.MaxLength = 31;
            this.txtNewDepPwd.Name = "txtNewDepPwd";
            this.txtNewDepPwd.PasswordChar = '*';
            this.txtNewDepPwd.Size = new System.Drawing.Size(160, 21);
            this.txtNewDepPwd.TabIndex = 27;
            // 
            // label72
            // 
            this.label72.Location = new System.Drawing.Point(24, 56);
            this.label72.Name = "label72";
            this.label72.Size = new System.Drawing.Size(144, 23);
            this.label72.TabIndex = 28;
            this.label72.Text = "Password";
            this.label72.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtDepDescription
            // 
            this.txtDepDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDepDescription.Location = new System.Drawing.Point(80, 88);
            this.txtDepDescription.Multiline = true;
            this.txtDepDescription.Name = "txtDepDescription";
            this.txtDepDescription.Size = new System.Drawing.Size(336, 40);
            this.txtDepDescription.TabIndex = 29;
            // 
            // label18
            // 
            this.label18.Location = new System.Drawing.Point(16, 96);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(136, 23);
            this.label18.TabIndex = 26;
            this.label18.Text = "Descrizione";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtDepName
            // 
            this.txtDepName.Location = new System.Drawing.Point(80, 24);
            this.txtDepName.Name = "txtDepName";
            this.txtDepName.Size = new System.Drawing.Size(160, 21);
            this.txtDepName.TabIndex = 25;
            // 
            // label17
            // 
            this.label17.Location = new System.Drawing.Point(40, 24);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(128, 23);
            this.label17.TabIndex = 24;
            this.label17.Text = "Codice";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // grpProprioDipartimento
            // 
            this.grpProprioDipartimento.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grpProprioDipartimento.Controls.Add(this.cmbProprioDipartimento);
            this.grpProprioDipartimento.Controls.Add(this.label75);
            this.grpProprioDipartimento.Location = new System.Drawing.Point(184, 24);
            this.grpProprioDipartimento.Name = "grpProprioDipartimento";
            this.grpProprioDipartimento.Size = new System.Drawing.Size(424, 64);
            this.grpProprioDipartimento.TabIndex = 38;
            this.grpProprioDipartimento.TabStop = false;
            this.grpProprioDipartimento.Text = "Scelta di un proprio dipartimento";
            // 
            // cmbProprioDipartimento
            // 
            this.cmbProprioDipartimento.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbProprioDipartimento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProprioDipartimento.Location = new System.Drawing.Point(80, 24);
            this.cmbProprioDipartimento.Name = "cmbProprioDipartimento";
            this.cmbProprioDipartimento.Size = new System.Drawing.Size(336, 21);
            this.cmbProprioDipartimento.TabIndex = 30;
            // 
            // label75
            // 
            this.label75.Location = new System.Drawing.Point(8, 24);
            this.label75.Name = "label75";
            this.label75.Size = new System.Drawing.Size(112, 21);
            this.label75.TabIndex = 31;
            this.label75.Text = "Dipartimento";
            this.label75.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rbtProprioDipartimento
            // 
            this.rbtProprioDipartimento.Location = new System.Drawing.Point(8, 24);
            this.rbtProprioDipartimento.Name = "rbtProprioDipartimento";
            this.rbtProprioDipartimento.Size = new System.Drawing.Size(178, 74);
            this.rbtProprioDipartimento.TabIndex = 39;
            this.rbtProprioDipartimento.Text = "Si desidera eseguire il setup su un dipartimento di propria pertinenza";
            this.rbtProprioDipartimento.CheckedChanged += new System.EventHandler(this.rdbtDipartimento_CheckedChanged);
            // 
            // rbtCreazioneDipartimento
            // 
            this.rbtCreazioneDipartimento.Location = new System.Drawing.Point(8, 288);
            this.rbtCreazioneDipartimento.Name = "rbtCreazioneDipartimento";
            this.rbtCreazioneDipartimento.Size = new System.Drawing.Size(184, 40);
            this.rbtCreazioneDipartimento.TabIndex = 37;
            this.rbtCreazioneDipartimento.Text = "Si desidera creare un nuovo dipartimento";
            this.rbtCreazioneDipartimento.CheckedChanged += new System.EventHandler(this.rdbtDipartimento_CheckedChanged);
            // 
            // grpNonProprioDipartimento
            // 
            this.grpNonProprioDipartimento.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grpNonProprioDipartimento.Controls.Add(this.cmbNonProprioDipartimento);
            this.grpNonProprioDipartimento.Controls.Add(this.label73);
            this.grpNonProprioDipartimento.Controls.Add(this.txtOldDepPwd);
            this.grpNonProprioDipartimento.Controls.Add(this.label74);
            this.grpNonProprioDipartimento.Location = new System.Drawing.Point(184, 120);
            this.grpNonProprioDipartimento.Name = "grpNonProprioDipartimento";
            this.grpNonProprioDipartimento.Size = new System.Drawing.Size(424, 96);
            this.grpNonProprioDipartimento.TabIndex = 32;
            this.grpNonProprioDipartimento.TabStop = false;
            this.grpNonProprioDipartimento.Text = "Scelta di un dipartimento non proprio";
            // 
            // cmbNonProprioDipartimento
            // 
            this.cmbNonProprioDipartimento.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbNonProprioDipartimento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbNonProprioDipartimento.Location = new System.Drawing.Point(80, 24);
            this.cmbNonProprioDipartimento.Name = "cmbNonProprioDipartimento";
            this.cmbNonProprioDipartimento.Size = new System.Drawing.Size(336, 21);
            this.cmbNonProprioDipartimento.TabIndex = 30;
            // 
            // label73
            // 
            this.label73.Location = new System.Drawing.Point(8, 24);
            this.label73.Name = "label73";
            this.label73.Size = new System.Drawing.Size(112, 21);
            this.label73.TabIndex = 31;
            this.label73.Text = "Dipartimento";
            this.label73.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtOldDepPwd
            // 
            this.txtOldDepPwd.Location = new System.Drawing.Point(80, 56);
            this.txtOldDepPwd.Name = "txtOldDepPwd";
            this.txtOldDepPwd.Size = new System.Drawing.Size(200, 21);
            this.txtOldDepPwd.TabIndex = 35;
            // 
            // label74
            // 
            this.label74.Location = new System.Drawing.Point(8, 56);
            this.label74.Name = "label74";
            this.label74.Size = new System.Drawing.Size(64, 23);
            this.label74.TabIndex = 34;
            this.label74.Text = "Password";
            this.label74.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // rbtNonProprioDipartimento
            // 
            this.rbtNonProprioDipartimento.Location = new System.Drawing.Point(8, 120);
            this.rbtNonProprioDipartimento.Name = "rbtNonProprioDipartimento";
            this.rbtNonProprioDipartimento.Size = new System.Drawing.Size(170, 96);
            this.rbtNonProprioDipartimento.TabIndex = 36;
            this.rbtNonProprioDipartimento.Text = "Si desidera eseguire il setup su un dipartimento già esistente ma non di propria " +
                "pertinenza";
            this.rbtNonProprioDipartimento.CheckedChanged += new System.EventHandler(this.rdbtDipartimento_CheckedChanged);
            // 
            // tabPage10
            // 
            this.tabPage10.Controls.Add(this.btnAllBanche);
            this.tabPage10.Controls.Add(this.label14);
            this.tabPage10.Location = new System.Drawing.Point(0, 0);
            this.tabPage10.Name = "tabPage10";
            this.tabPage10.Selected = false;
            this.tabPage10.Size = new System.Drawing.Size(616, 471);
            this.tabPage10.TabIndex = 12;
            this.tabPage10.Title = "Banche e sportelli";
            // 
            // btnAllBanche
            // 
            this.btnAllBanche.Location = new System.Drawing.Point(208, 72);
            this.btnAllBanche.Name = "btnAllBanche";
            this.btnAllBanche.Size = new System.Drawing.Size(184, 23);
            this.btnAllBanche.TabIndex = 1;
            this.btnAllBanche.Text = "Acquisisci informazioni banche";
            this.btnAllBanche.Click += new System.EventHandler(this.btnAllBanche_Click);
            // 
            // label14
            // 
            this.label14.Location = new System.Drawing.Point(8, 8);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(584, 40);
            this.label14.TabIndex = 0;
            this.label14.Text = resources.GetString("label14.Text");
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.label37);
            this.tabPage4.Controls.Add(this.listDepartmentUser);
            this.tabPage4.Controls.Add(this.label78);
            this.tabPage4.Controls.Add(this.listServerUser);
            this.tabPage4.Controls.Add(this.label42);
            this.tabPage4.Controls.Add(this.groupBox2);
            this.tabPage4.Controls.Add(this.label41);
            this.tabPage4.Controls.Add(this.listClientUser);
            this.tabPage4.Controls.Add(this.label40);
            this.tabPage4.Controls.Add(this.label39);
            this.tabPage4.Controls.Add(this.label36);
            this.tabPage4.Controls.Add(this.txtNomeEnte);
            this.tabPage4.Controls.Add(this.label34);
            this.tabPage4.Location = new System.Drawing.Point(0, 0);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Selected = false;
            this.tabPage4.Size = new System.Drawing.Size(616, 471);
            this.tabPage4.TabIndex = 6;
            this.tabPage4.Title = "Configurazione della connessione";
            // 
            // label37
            // 
            this.label37.Location = new System.Drawing.Point(224, 96);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(376, 16);
            this.label37.TabIndex = 19;
            this.label37.Text = "Lasciando vuota la casella non sarà effettuata la configurazione del client";
            // 
            // listDepartmentUser
            // 
            this.listDepartmentUser.ContextMenu = this.MenuDelFromDip;
            this.listDepartmentUser.Location = new System.Drawing.Point(416, 256);
            this.listDepartmentUser.Name = "listDepartmentUser";
            this.listDepartmentUser.Size = new System.Drawing.Size(192, 199);
            this.listDepartmentUser.TabIndex = 17;
            // 
            // MenuDelFromDip
            // 
            this.MenuDelFromDip.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem1});
            // 
            // menuItem1
            // 
            this.menuItem1.Index = 0;
            this.menuItem1.Text = "elimina";
            this.menuItem1.Click += new System.EventHandler(this.menuItem1_Click);
            // 
            // label78
            // 
            this.label78.Location = new System.Drawing.Point(416, 240);
            this.label78.Name = "label78";
            this.label78.Size = new System.Drawing.Size(192, 23);
            this.label78.TabIndex = 18;
            this.label78.Text = "Utenti del dipartimento:";
            // 
            // listServerUser
            // 
            this.listServerUser.ContextMenu = this.menuDelServer;
            this.listServerUser.Location = new System.Drawing.Point(208, 256);
            this.listServerUser.Name = "listServerUser";
            this.listServerUser.Size = new System.Drawing.Size(192, 199);
            this.listServerUser.TabIndex = 16;
            // 
            // menuDelServer
            // 
            this.menuDelServer.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mnuDelServer});
            // 
            // mnuDelServer
            // 
            this.mnuDelServer.Index = 0;
            this.mnuDelServer.Text = "Elimina";
            this.mnuDelServer.Click += new System.EventHandler(this.mnuDelServer_Click);
            // 
            // label42
            // 
            this.label42.Location = new System.Drawing.Point(208, 240);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(192, 16);
            this.label42.TabIndex = 15;
            this.label42.Text = "Utenti del db configurati sul server";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtWinUser);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.btnCreateLogin);
            this.groupBox2.Controls.Add(this.cmbUserList);
            this.groupBox2.Controls.Add(this.label35);
            this.groupBox2.Controls.Add(this.btnAddConnection);
            this.groupBox2.Location = new System.Drawing.Point(8, 120);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(600, 112);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Inserire le informazioni sugli utenti che accederanno al db da questo client";
            // 
            // txtWinUser
            // 
            this.txtWinUser.Location = new System.Drawing.Point(8, 80);
            this.txtWinUser.Name = "txtWinUser";
            this.txtWinUser.Size = new System.Drawing.Size(248, 21);
            this.txtWinUser.TabIndex = 4;
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(8, 64);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(384, 16);
            this.label12.TabIndex = 13;
            this.label12.Text = "Utente Windows sul client (da specificare se diverso dal nome utente)";
            // 
            // btnCreateLogin
            // 
            this.btnCreateLogin.Location = new System.Drawing.Point(480, 32);
            this.btnCreateLogin.Name = "btnCreateLogin";
            this.btnCreateLogin.Size = new System.Drawing.Size(104, 23);
            this.btnCreateLogin.TabIndex = 3;
            this.btnCreateLogin.Text = "Crea nuova login";
            this.btnCreateLogin.Click += new System.EventHandler(this.btnCreateLogin_Click);
            // 
            // cmbUserList
            // 
            this.cmbUserList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbUserList.Location = new System.Drawing.Point(8, 32);
            this.cmbUserList.Name = "cmbUserList";
            this.cmbUserList.Size = new System.Drawing.Size(248, 21);
            this.cmbUserList.TabIndex = 1;
            this.cmbUserList.SelectedIndexChanged += new System.EventHandler(this.cmbUserList_SelectedIndexChanged);
            // 
            // label35
            // 
            this.label35.Location = new System.Drawing.Point(8, 16);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(288, 16);
            this.label35.TabIndex = 2;
            this.label35.Text = "Nome utente (Login sul server)";
            // 
            // btnAddConnection
            // 
            this.btnAddConnection.Location = new System.Drawing.Point(272, 32);
            this.btnAddConnection.Name = "btnAddConnection";
            this.btnAddConnection.Size = new System.Drawing.Size(192, 24);
            this.btnAddConnection.TabIndex = 2;
            this.btnAddConnection.Text = "Aggiungi utente al dipartimento";
            this.btnAddConnection.Click += new System.EventHandler(this.btnAddConnection_Click);
            // 
            // label41
            // 
            this.label41.Location = new System.Drawing.Point(8, 240);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(304, 16);
            this.label41.TabIndex = 13;
            this.label41.Text = "Utenti configurati su questo client:";
            // 
            // listClientUser
            // 
            this.listClientUser.ContextMenu = this.menuDelClient;
            this.listClientUser.Location = new System.Drawing.Point(8, 256);
            this.listClientUser.Name = "listClientUser";
            this.listClientUser.Size = new System.Drawing.Size(192, 199);
            this.listClientUser.TabIndex = 12;
            // 
            // menuDelClient
            // 
            this.menuDelClient.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mnuDelClient});
            // 
            // mnuDelClient
            // 
            this.mnuDelClient.Index = 0;
            this.mnuDelClient.Text = "Elimina (su tutti gli utenti Windows del CLIENT)";
            this.mnuDelClient.Click += new System.EventHandler(this.mnuDelClient_Click);
            // 
            // label40
            // 
            this.label40.Location = new System.Drawing.Point(8, 40);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(600, 32);
            this.label40.TabIndex = 11;
            this.label40.Text = resources.GetString("label40.Text");
            // 
            // label39
            // 
            this.label39.Location = new System.Drawing.Point(8, 24);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(568, 16);
            this.label39.TabIndex = 9;
            this.label39.Text = "E\' possibile da qui configurare tale lista per tutti gli utenti del client.";
            // 
            // label36
            // 
            this.label36.Location = new System.Drawing.Point(8, 8);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(600, 16);
            this.label36.TabIndex = 6;
            this.label36.Text = "All\'apertura del programma, normalmente si apre una finestra in cui l\'utente può " +
                "scegliere l\'ente a cui collegarsi.";
            // 
            // txtNomeEnte
            // 
            this.txtNomeEnte.Location = new System.Drawing.Point(8, 96);
            this.txtNomeEnte.Name = "txtNomeEnte";
            this.txtNomeEnte.Size = new System.Drawing.Size(208, 21);
            this.txtNomeEnte.TabIndex = 1;
            // 
            // label34
            // 
            this.label34.Location = new System.Drawing.Point(8, 80);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(592, 16);
            this.label34.TabIndex = 0;
            this.label34.Text = "Inserire il nome  da assegnare alla connessione, che apparirà nella lista degli E" +
                "nti (su questo CLIENT)";
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.txtNonRaggiungibile);
            this.tabPage5.Controls.Add(this.txtServerRaggiungibile);
            this.tabPage5.Controls.Add(this.btnTestServer);
            this.tabPage5.Controls.Add(this.txtUpdateServer);
            this.tabPage5.Controls.Add(this.label50);
            this.tabPage5.Controls.Add(this.label49);
            this.tabPage5.Controls.Add(this.label48);
            this.tabPage5.Controls.Add(this.label47);
            this.tabPage5.Controls.Add(this.label46);
            this.tabPage5.Controls.Add(this.label45);
            this.tabPage5.Controls.Add(this.label44);
            this.tabPage5.Location = new System.Drawing.Point(0, 0);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Selected = false;
            this.tabPage5.Size = new System.Drawing.Size(616, 471);
            this.tabPage5.TabIndex = 7;
            this.tabPage5.Title = "Impostazione Sito per aggiornamenti";
            // 
            // txtNonRaggiungibile
            // 
            this.txtNonRaggiungibile.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World);
            this.txtNonRaggiungibile.ForeColor = System.Drawing.Color.Red;
            this.txtNonRaggiungibile.Location = new System.Drawing.Point(16, 288);
            this.txtNonRaggiungibile.Name = "txtNonRaggiungibile";
            this.txtNonRaggiungibile.Size = new System.Drawing.Size(576, 32);
            this.txtNonRaggiungibile.TabIndex = 10;
            this.txtNonRaggiungibile.Text = "Il server non risulta essere al momento raggiungibile. Contattare un tecnico per " +
                "verificare che la rete ed internet siano correttamente configurati.";
            // 
            // txtServerRaggiungibile
            // 
            this.txtServerRaggiungibile.Location = new System.Drawing.Point(16, 256);
            this.txtServerRaggiungibile.Name = "txtServerRaggiungibile";
            this.txtServerRaggiungibile.Size = new System.Drawing.Size(568, 23);
            this.txtServerRaggiungibile.TabIndex = 9;
            this.txtServerRaggiungibile.Text = "Il server risulta essere raggiungibile, pertanto non è necessario modificare l\'im" +
                "postazione corrente.";
            // 
            // btnTestServer
            // 
            this.btnTestServer.Location = new System.Drawing.Point(192, 216);
            this.btnTestServer.Name = "btnTestServer";
            this.btnTestServer.Size = new System.Drawing.Size(200, 23);
            this.btnTestServer.TabIndex = 8;
            this.btnTestServer.Text = "Prova a collegarti al server";
            this.btnTestServer.Click += new System.EventHandler(this.btnTestServer_Click);
            // 
            // txtUpdateServer
            // 
            this.txtUpdateServer.Location = new System.Drawing.Point(16, 184);
            this.txtUpdateServer.Name = "txtUpdateServer";
            this.txtUpdateServer.Size = new System.Drawing.Size(552, 21);
            this.txtUpdateServer.TabIndex = 7;
            // 
            // label50
            // 
            this.label50.Location = new System.Drawing.Point(16, 168);
            this.label50.Name = "label50";
            this.label50.Size = new System.Drawing.Size(320, 16);
            this.label50.TabIndex = 6;
            this.label50.Text = "Il server attuale per gli aggiornamenti risulta essere:";
            // 
            // label49
            // 
            this.label49.Location = new System.Drawing.Point(16, 128);
            this.label49.Name = "label49";
            this.label49.Size = new System.Drawing.Size(552, 23);
            this.label49.TabIndex = 5;
            this.label49.Text = "- Miglioramenti delle funzioni esistenti o correzioni quando ci viene segnalato q" +
                "ualche problema";
            // 
            // label48
            // 
            this.label48.Location = new System.Drawing.Point(16, 104);
            this.label48.Name = "label48";
            this.label48.Size = new System.Drawing.Size(560, 23);
            this.label48.TabIndex = 4;
            this.label48.Text = "- Nuove funzioni per coprire sempre più esigenze degli utenti";
            // 
            // label47
            // 
            this.label47.Location = new System.Drawing.Point(16, 80);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(552, 23);
            this.label47.TabIndex = 3;
            this.label47.Text = "- Nuove report necessari per il corretto funzionamento dei dipartimenti/amministr" +
                "azioni";
            // 
            // label46
            // 
            this.label46.Location = new System.Drawing.Point(16, 56);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(552, 23);
            this.label46.TabIndex = 2;
            this.label46.Text = "- Aggiornamenti delle tabelle di configurazione per le prestazioni (diarie, aliqu" +
                "ote, gruppi esteri, etc.)";
            // 
            // label45
            // 
            this.label45.Location = new System.Drawing.Point(16, 32);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(312, 23);
            this.label45.TabIndex = 1;
            this.label45.Text = "Gli aggiornamenti consistono principalmente di:";
            // 
            // label44
            // 
            this.label44.Location = new System.Drawing.Point(8, 8);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(584, 23);
            this.label44.TabIndex = 0;
            this.label44.Text = "Easy automaticamente si connette periodicamente ad un elenco di server per reperi" +
                "re gli aggiornamenti.";
            // 
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.labReportNotOk);
            this.tabPage6.Controls.Add(this.labReportOk);
            this.tabPage6.Controls.Add(this.btnChangeReportDir);
            this.tabPage6.Controls.Add(this.txtReportDir);
            this.tabPage6.Controls.Add(this.label53);
            this.tabPage6.Controls.Add(this.label52);
            this.tabPage6.Controls.Add(this.label51);
            this.tabPage6.Location = new System.Drawing.Point(0, 0);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Selected = false;
            this.tabPage6.Size = new System.Drawing.Size(616, 471);
            this.tabPage6.TabIndex = 8;
            this.tabPage6.Title = "Impostazione cartella dei report";
            // 
            // labReportNotOk
            // 
            this.labReportNotOk.ForeColor = System.Drawing.Color.Red;
            this.labReportNotOk.Location = new System.Drawing.Point(8, 152);
            this.labReportNotOk.Name = "labReportNotOk";
            this.labReportNotOk.Size = new System.Drawing.Size(592, 23);
            this.labReportNotOk.TabIndex = 6;
            this.labReportNotOk.Text = "La cartella selezionata non esiste o non è accessibile. Selezionare una cartella " +
                "valida.";
            // 
            // labReportOk
            // 
            this.labReportOk.Location = new System.Drawing.Point(8, 128);
            this.labReportOk.Name = "labReportOk";
            this.labReportOk.Size = new System.Drawing.Size(584, 23);
            this.labReportOk.TabIndex = 5;
            this.labReportOk.Text = "La cartella selezionata risulta accessibile. Non è necessario cambiare le imposta" +
                "zioni correnti.";
            // 
            // btnChangeReportDir
            // 
            this.btnChangeReportDir.Location = new System.Drawing.Point(480, 96);
            this.btnChangeReportDir.Name = "btnChangeReportDir";
            this.btnChangeReportDir.Size = new System.Drawing.Size(112, 23);
            this.btnChangeReportDir.TabIndex = 4;
            this.btnChangeReportDir.Text = "Scegli Cartella";
            this.btnChangeReportDir.Click += new System.EventHandler(this.btnChangeReportDir_Click);
            // 
            // txtReportDir
            // 
            this.txtReportDir.Location = new System.Drawing.Point(8, 96);
            this.txtReportDir.Name = "txtReportDir";
            this.txtReportDir.ReadOnly = true;
            this.txtReportDir.Size = new System.Drawing.Size(456, 21);
            this.txtReportDir.TabIndex = 3;
            // 
            // label53
            // 
            this.label53.Location = new System.Drawing.Point(8, 72);
            this.label53.Name = "label53";
            this.label53.Size = new System.Drawing.Size(592, 23);
            this.label53.TabIndex = 2;
            this.label53.Text = "La cartella attualmente impostata per i report è:";
            // 
            // label52
            // 
            this.label52.Location = new System.Drawing.Point(8, 40);
            this.label52.Name = "label52";
            this.label52.Size = new System.Drawing.Size(592, 32);
            this.label52.TabIndex = 1;
            this.label52.Text = "Normalmente i report risiedono in una cartella locale, ma è anche possibile usare" +
                " dei report condivisi su un altro computer della rete.";
            // 
            // label51
            // 
            this.label51.Location = new System.Drawing.Point(8, 8);
            this.label51.Name = "label51";
            this.label51.Size = new System.Drawing.Size(592, 23);
            this.label51.TabIndex = 0;
            this.label51.Text = "Impostazione della cartella ove risiedono i report";
            // 
            // tabPage7
            // 
            this.tabPage7.Controls.Add(this.label16);
            this.tabPage7.Controls.Add(this.btnDelLastVersion);
            this.tabPage7.Controls.Add(this.label59);
            this.tabPage7.Controls.Add(this.txtLiveDBStatus);
            this.tabPage7.Controls.Add(this.txtLiveRptStatus);
            this.tabPage7.Controls.Add(this.txtLiveSWStatus);
            this.tabPage7.Controls.Add(this.label58);
            this.tabPage7.Controls.Add(this.label57);
            this.tabPage7.Controls.Add(this.label56);
            this.tabPage7.Controls.Add(this.label55);
            this.tabPage7.Controls.Add(this.label54);
            this.tabPage7.Controls.Add(this.btnLiveUpdate);
            this.tabPage7.Location = new System.Drawing.Point(0, 0);
            this.tabPage7.Name = "tabPage7";
            this.tabPage7.Selected = false;
            this.tabPage7.Size = new System.Drawing.Size(616, 471);
            this.tabPage7.TabIndex = 9;
            this.tabPage7.Title = "LiveUpdate";
            // 
            // label16
            // 
            this.label16.Location = new System.Drawing.Point(8, 416);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(432, 32);
            this.label16.TabIndex = 11;
            this.label16.Text = "Se si verifica un timeout è possibile ritentare l\'esecuzione eliminando l\'ultima " +
                "versione e riavviando l\'aggiornamento.";
            // 
            // btnDelLastVersion
            // 
            this.btnDelLastVersion.Location = new System.Drawing.Point(448, 416);
            this.btnDelLastVersion.Name = "btnDelLastVersion";
            this.btnDelLastVersion.Size = new System.Drawing.Size(152, 23);
            this.btnDelLastVersion.TabIndex = 10;
            this.btnDelLastVersion.Text = "Elimina ultima versione";
            this.btnDelLastVersion.Click += new System.EventHandler(this.btnDelLastVersion_Click);
            // 
            // label59
            // 
            this.label59.Location = new System.Drawing.Point(8, 456);
            this.label59.Name = "label59";
            this.label59.Size = new System.Drawing.Size(408, 16);
            this.label59.TabIndex = 9;
            this.label59.Text = "Se si verificano errori durante l\'aggiornamento contattare il settore assistenza." +
                "";
            // 
            // txtLiveDBStatus
            // 
            this.txtLiveDBStatus.AcceptsReturn = true;
            this.txtLiveDBStatus.AcceptsTab = true;
            this.txtLiveDBStatus.Location = new System.Drawing.Point(8, 336);
            this.txtLiveDBStatus.Multiline = true;
            this.txtLiveDBStatus.Name = "txtLiveDBStatus";
            this.txtLiveDBStatus.ReadOnly = true;
            this.txtLiveDBStatus.Size = new System.Drawing.Size(592, 72);
            this.txtLiveDBStatus.TabIndex = 8;
            // 
            // txtLiveRptStatus
            // 
            this.txtLiveRptStatus.AcceptsReturn = true;
            this.txtLiveRptStatus.AcceptsTab = true;
            this.txtLiveRptStatus.Location = new System.Drawing.Point(8, 240);
            this.txtLiveRptStatus.Multiline = true;
            this.txtLiveRptStatus.Name = "txtLiveRptStatus";
            this.txtLiveRptStatus.ReadOnly = true;
            this.txtLiveRptStatus.Size = new System.Drawing.Size(592, 72);
            this.txtLiveRptStatus.TabIndex = 7;
            // 
            // txtLiveSWStatus
            // 
            this.txtLiveSWStatus.AcceptsReturn = true;
            this.txtLiveSWStatus.AcceptsTab = true;
            this.txtLiveSWStatus.Location = new System.Drawing.Point(8, 144);
            this.txtLiveSWStatus.Multiline = true;
            this.txtLiveSWStatus.Name = "txtLiveSWStatus";
            this.txtLiveSWStatus.ReadOnly = true;
            this.txtLiveSWStatus.Size = new System.Drawing.Size(592, 72);
            this.txtLiveSWStatus.TabIndex = 6;
            // 
            // label58
            // 
            this.label58.Location = new System.Drawing.Point(8, 320);
            this.label58.Name = "label58";
            this.label58.Size = new System.Drawing.Size(592, 23);
            this.label58.TabIndex = 5;
            this.label58.Text = "Stato dell\'aggiornamento del Database:";
            // 
            // label57
            // 
            this.label57.Location = new System.Drawing.Point(8, 216);
            this.label57.Name = "label57";
            this.label57.Size = new System.Drawing.Size(592, 23);
            this.label57.TabIndex = 4;
            this.label57.Text = "Stato dell\'aggiornamento dei report:";
            // 
            // label56
            // 
            this.label56.Location = new System.Drawing.Point(8, 128);
            this.label56.Name = "label56";
            this.label56.Size = new System.Drawing.Size(592, 23);
            this.label56.TabIndex = 3;
            this.label56.Text = "Stato dell\'aggiornamento del Software:";
            // 
            // label55
            // 
            this.label55.Location = new System.Drawing.Point(8, 80);
            this.label55.Name = "label55";
            this.label55.Size = new System.Drawing.Size(552, 23);
            this.label55.TabIndex = 2;
            this.label55.Text = "Se non si desidera effettuare l\'aggiornamento ora, premere semplicemente il botto" +
                "ne \'Avanti\'";
            // 
            // label54
            // 
            this.label54.Location = new System.Drawing.Point(8, 8);
            this.label54.Name = "label54";
            this.label54.Size = new System.Drawing.Size(536, 23);
            this.label54.TabIndex = 1;
            this.label54.Text = "E\' ora possibile aggiornare il software. Premere il bottone per effettuare l\'aggi" +
                "ornamento.";
            // 
            // btnLiveUpdate
            // 
            this.btnLiveUpdate.Location = new System.Drawing.Point(192, 40);
            this.btnLiveUpdate.Name = "btnLiveUpdate";
            this.btnLiveUpdate.Size = new System.Drawing.Size(200, 23);
            this.btnLiveUpdate.TabIndex = 0;
            this.btnLiveUpdate.Text = "Avvia l\'aggiornamento";
            this.btnLiveUpdate.Click += new System.EventHandler(this.btnLiveUpdate_Click);
            // 
            // tabPage8
            // 
            this.tabPage8.Controls.Add(this.labInfoLicenzaNotFound);
            this.tabPage8.Controls.Add(this.labInfoLicenzaFound);
            this.tabPage8.Controls.Add(this.btnInsertInfoLicenza);
            this.tabPage8.Controls.Add(this.label64);
            this.tabPage8.Controls.Add(this.label63);
            this.tabPage8.Controls.Add(this.label62);
            this.tabPage8.Controls.Add(this.label60);
            this.tabPage8.Location = new System.Drawing.Point(0, 0);
            this.tabPage8.Name = "tabPage8";
            this.tabPage8.Selected = false;
            this.tabPage8.Size = new System.Drawing.Size(616, 471);
            this.tabPage8.TabIndex = 10;
            this.tabPage8.Title = "Inserimento informazioni relative all\'ente";
            // 
            // labInfoLicenzaNotFound
            // 
            this.labInfoLicenzaNotFound.ForeColor = System.Drawing.Color.Red;
            this.labInfoLicenzaNotFound.Location = new System.Drawing.Point(8, 144);
            this.labInfoLicenzaNotFound.Name = "labInfoLicenzaNotFound";
            this.labInfoLicenzaNotFound.Size = new System.Drawing.Size(584, 23);
            this.labInfoLicenzaNotFound.TabIndex = 6;
            this.labInfoLicenzaNotFound.Text = "Le informazioni relative alla licenza NON sono state trovate, è pertanto necessar" +
                "io inserirle.";
            // 
            // labInfoLicenzaFound
            // 
            this.labInfoLicenzaFound.Location = new System.Drawing.Point(8, 208);
            this.labInfoLicenzaFound.Name = "labInfoLicenzaFound";
            this.labInfoLicenzaFound.Size = new System.Drawing.Size(592, 48);
            this.labInfoLicenzaFound.TabIndex = 5;
            this.labInfoLicenzaFound.Text = resources.GetString("labInfoLicenzaFound.Text");
            // 
            // btnInsertInfoLicenza
            // 
            this.btnInsertInfoLicenza.Location = new System.Drawing.Point(208, 176);
            this.btnInsertInfoLicenza.Name = "btnInsertInfoLicenza";
            this.btnInsertInfoLicenza.Size = new System.Drawing.Size(168, 23);
            this.btnInsertInfoLicenza.TabIndex = 4;
            this.btnInsertInfoLicenza.Text = "Inserisci informazioni licenza";
            this.btnInsertInfoLicenza.Click += new System.EventHandler(this.btnInsertInfoLicenza_Click);
            // 
            // label64
            // 
            this.label64.Location = new System.Drawing.Point(8, 104);
            this.label64.Name = "label64";
            this.label64.Size = new System.Drawing.Size(584, 40);
            this.label64.TabIndex = 3;
            this.label64.Text = resources.GetString("label64.Text");
            // 
            // label63
            // 
            this.label63.Location = new System.Drawing.Point(8, 64);
            this.label63.Name = "label63";
            this.label63.Size = new System.Drawing.Size(584, 40);
            this.label63.TabIndex = 2;
            this.label63.Text = "Le informazioni saranno inviate ad un server della Software && More e il settore " +
                "AMMINISTRATIVO provvederà, secondo le procedure organizzative previste, ad abili" +
                "tare il database da remoto.";
            // 
            // label62
            // 
            this.label62.Location = new System.Drawing.Point(8, 32);
            this.label62.Name = "label62";
            this.label62.Size = new System.Drawing.Size(584, 32);
            this.label62.TabIndex = 1;
            this.label62.Text = "A tal fine è necessario inserire le informazioni sul cliente, INDISPENSABILI per " +
                "poter ricevere il codice di attivazione del database e quindi poter usare l\'appl" +
                "icazione.";
            // 
            // label60
            // 
            this.label60.Location = new System.Drawing.Point(8, 8);
            this.label60.Name = "label60";
            this.label60.Size = new System.Drawing.Size(536, 23);
            this.label60.TabIndex = 0;
            this.label60.Text = "Per poter utilizzare il software è necessario registrare il prodotto.";
            // 
            // tabPage9
            // 
            this.tabPage9.Controls.Add(this.pictureBox1);
            this.tabPage9.Controls.Add(this.label71);
            this.tabPage9.Controls.Add(this.label70);
            this.tabPage9.Controls.Add(this.label69);
            this.tabPage9.Controls.Add(this.label68);
            this.tabPage9.Controls.Add(this.label67);
            this.tabPage9.Controls.Add(this.label66);
            this.tabPage9.Controls.Add(this.label65);
            this.tabPage9.Location = new System.Drawing.Point(0, 0);
            this.tabPage9.Name = "tabPage9";
            this.tabPage9.Selected = false;
            this.tabPage9.Size = new System.Drawing.Size(616, 471);
            this.tabPage9.TabIndex = 11;
            this.tabPage9.Title = "Fine";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(112, 256);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(384, 216);
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // label71
            // 
            this.label71.Location = new System.Drawing.Point(8, 208);
            this.label71.Name = "label71";
            this.label71.Size = new System.Drawing.Size(584, 40);
            this.label71.TabIndex = 6;
            this.label71.Text = "Potete fare riferimento all\'indirizzo assistenzahw@swandmore.it per informazioni " +
                "tecniche sull\'installazione del prodotto.";
            // 
            // label70
            // 
            this.label70.Location = new System.Drawing.Point(8, 168);
            this.label70.Name = "label70";
            this.label70.Size = new System.Drawing.Size(592, 40);
            this.label70.TabIndex = 5;
            this.label70.Text = "Potete scrivere all\'indirizzo sviluppo@swandmore.it per segnalare eventuali imper" +
                "fezioni del  prodotto, oppure per richiedere lo sviluppo di nuove funzionalità.";
            // 
            // label69
            // 
            this.label69.Location = new System.Drawing.Point(8, 144);
            this.label69.Name = "label69";
            this.label69.Size = new System.Drawing.Size(592, 16);
            this.label69.TabIndex = 4;
            this.label69.Text = "La Software && More vi augura buon lavoro, e vi ricorda che:";
            // 
            // label68
            // 
            this.label68.Location = new System.Drawing.Point(8, 88);
            this.label68.Name = "label68";
            this.label68.Size = new System.Drawing.Size(592, 40);
            this.label68.TabIndex = 3;
            this.label68.Text = "Se invece si vuole richiamare nuovamente questa procedura guidata, sarà possibile" +
                " farlo dal menu File/Configurazione/Configurazione TECNICA";
            // 
            // label67
            // 
            this.label67.Location = new System.Drawing.Point(8, 48);
            this.label67.Name = "label67";
            this.label67.Size = new System.Drawing.Size(592, 40);
            this.label67.TabIndex = 2;
            this.label67.Text = "Se è la prima volta che si usa Easy sarà necessario effettuare la configurazione " +
                "CONTABILE del database, richiamabile dal menu File/Configurazione/Configurazione" +
                " CONTABILE";
            // 
            // label66
            // 
            this.label66.Location = new System.Drawing.Point(8, 24);
            this.label66.Name = "label66";
            this.label66.Size = new System.Drawing.Size(592, 23);
            this.label66.TabIndex = 1;
            this.label66.Text = "E\' consigliabile chiudere questa finestra e poi chiudere l\'applicazione.";
            // 
            // label65
            // 
            this.label65.Location = new System.Drawing.Point(8, 8);
            this.label65.Name = "label65";
            this.label65.Size = new System.Drawing.Size(592, 23);
            this.label65.TabIndex = 0;
            this.label65.Text = "Easy è stato configurato.";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(552, 512);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 13;
            this.btnCancel.Text = "Annulla";
            // 
            // btnNext
            // 
            this.btnNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNext.Location = new System.Drawing.Point(448, 512);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(72, 23);
            this.btnNext.TabIndex = 12;
            this.btnNext.Text = "Avanti >";
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnBack
            // 
            this.btnBack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBack.Location = new System.Drawing.Point(368, 512);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(72, 23);
            this.btnBack.TabIndex = 11;
            this.btnBack.Text = "< Indietro";
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // DirectoryPicker
            // 
            this.DirectoryPicker.Description = "Selezione della cartella dei report";
            // 
            // UpdateLiveStatus
            // 
            this.UpdateLiveStatus.Interval = 1000;
            this.UpdateLiveStatus.Tick += new System.EventHandler(this.UpdateLiveStatus_Tick);
            // 
            // txtSourceConn
            // 
            this.txtSourceConn.Location = new System.Drawing.Point(48, 504);
            this.txtSourceConn.Name = "txtSourceConn";
            this.txtSourceConn.Size = new System.Drawing.Size(304, 20);
            this.txtSourceConn.TabIndex = 14;
            this.txtSourceConn.Visible = false;
            // 
            // txtConn
            // 
            this.txtConn.Location = new System.Drawing.Point(48, 528);
            this.txtConn.Name = "txtConn";
            this.txtConn.Size = new System.Drawing.Size(304, 20);
            this.txtConn.TabIndex = 15;
            this.txtConn.Visible = false;
            // 
            // labSourceConn
            // 
            this.labSourceConn.Location = new System.Drawing.Point(8, 504);
            this.labSourceConn.Name = "labSourceConn";
            this.labSourceConn.Size = new System.Drawing.Size(48, 23);
            this.labSourceConn.TabIndex = 16;
            this.labSourceConn.Text = "Source";
            this.labSourceConn.Visible = false;
            // 
            // labDestConn
            // 
            this.labDestConn.Location = new System.Drawing.Point(16, 528);
            this.labDestConn.Name = "labDestConn";
            this.labDestConn.Size = new System.Drawing.Size(32, 23);
            this.labDestConn.TabIndex = 17;
            this.labDestConn.Text = "Dest";
            this.labDestConn.Visible = false;
            // 
            // Frm_Install
            // 
            this.AcceptButton = this.btnNext;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(632, 550);
            this.Controls.Add(this.txtConn);
            this.Controls.Add(this.txtSourceConn);
            this.Controls.Add(this.tabController);
            this.Controls.Add(this.labDestConn);
            this.Controls.Add(this.labSourceConn);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnBack);
            this.Name = "Frm_Install";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Configurazione Easy";
            this.tabController.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage11.ResumeLayout(false);
            this.grpCreazioneDipartimento.ResumeLayout(false);
            this.grpCreazioneDipartimento.PerformLayout();
            this.grpProprioDipartimento.ResumeLayout(false);
            this.grpNonProprioDipartimento.ResumeLayout(false);
            this.grpNonProprioDipartimento.PerformLayout();
            this.tabPage10.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tabPage5.ResumeLayout(false);
            this.tabPage5.PerformLayout();
            this.tabPage6.ResumeLayout(false);
            this.tabPage6.PerformLayout();
            this.tabPage7.ResumeLayout(false);
            this.tabPage7.PerformLayout();
            this.tabPage8.ResumeLayout(false);
            this.tabPage9.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		void FormInit() {
			CustomTitle="Configurazione Easy";
			//Selects first tab
			DisplayTabs(0);
			
			
		}

		#region Gestione Tabs

		/// <summary>
		/// Displays tab n. NewTab and updates buttons
		/// </summary>
		/// <param name="newTab"></param>
		void DisplayTabs(int newTab) {
			tabController.SelectedIndex= newTab;
			//Evaluates Buttons Appearance
			btnBack.Visible=(newTab>0);
			if (newTab== tabController.TabPages.Count-1)
				btnNext.Text="Fine.";
			else
				btnNext.Text="Avanti >";
			Text = CustomTitle+ " (Pagina "+(newTab+1)+" di "+tabController.TabPages.Count+")";
		}


		/// <summary>
		/// Changes tab backward/forward
		/// </summary>
		/// <param name="step"></param>
		void StandardChangeTab(int step) {
			int oldTab= tabController.SelectedIndex;
			int newTab= oldTab+step;
			if ((newTab<0)||(newTab>tabController.TabPages.Count))return;
			EnableDisableNavigation(false);
			if (!CustomChangeTab(oldTab,newTab)){
				EnableDisableNavigation(true);
				return;
			}
			if (newTab==tabController.TabPages.Count) {
				DialogResult= DialogResult.OK;
				return;
			}
			EnableDisableNavigation(true);
			DisplayTabs(newTab);
		}

		private void btnNext_Click(object sender, System.EventArgs e) {
			StandardChangeTab(+1);
		}

		private void btnBack_Click(object sender, System.EventArgs e) {
			StandardChangeTab(-1);
		
		}
		#endregion


		/// <summary>
		/// Si connette ad un dipartimento (imposta DepConn), lo crea se non esiste
		/// </summary>
		/// <param name="idDbDepartment"></param>
		/// <param name="passwordDB"></param>
		/// <returns>true se riuscito</returns>
		bool connectToDepartment(string idDbDepartment, string passwordDB) {
			string errore;
			DataTable T1= MainConn.SQLRunner("select * from master.dbo.syslogins where loginname="
				+ QueryCreator.quotedstrvalue(idDbDepartment, true), -1, out errore);
			if (errore != null) {
				QueryCreator.ShowError(this, "Non è stato possibile ottenere l'elenco delle login dal server", errore);
				return false;
			}

			bool loginPresente = T1.Rows.Count > 0;
			if (!loginPresente) {
				string err;
				MainConn.DO_SYS_CMD("EXEC sp_addlogin "+QueryCreator.quotedstrvalue(idDbDepartment,false)+
					","+QueryCreator.quotedstrvalue(passwordDB,false), out err);
				if (err!=null){
					MessageBox.Show(this, "Errore: "+err);
					return false;
				}		
			}


			DataTable T2= MainConn.SQLRunner(
				//"select * from sysusers where loginname="
				"select o.name, l.loginname from sysusers o join master.dbo.syslogins l on l.sid = o.sid "+
				" where l.loginname="+ QueryCreator.quotedstrvalue(idDbDepartment, true), -1, out errore);
				
			if (errore != null) {
				QueryCreator.ShowError(this, "Non è stato possibile connettersi al dipartimento", errore);
				return false;
			}

			
			bool userPresente = T2.Rows.Count > 0;
			if (!userPresente) {
				MainConn.SQLRunner("exec sp_grantdbaccess "+
					QueryCreator.quotedstrvalue(idDbDepartment,false)+","+
					QueryCreator.quotedstrvalue(idDbDepartment,false), -1, out errore);
				if (errore != null) {
					QueryCreator.ShowError(this, "Non è stato creare aggiungere l'utente dipartimento al db", errore);
					return false;
				}
				MainConn.SQLRunner("exec sp_addrolemember  N'db_owner',"+
					QueryCreator.quotedstrvalue(idDbDepartment,false),-1, out errore);
				if (errore != null) {
					QueryCreator.ShowError(this, "Non è stato possibile rendere l'utente dipartimento DBO", errore);
					return false;
				}
			}

			//Collega l'utente-operatore all'utente-dipartimento
			Easy_DataAccess.linkUserToDepartment(MainConn, txtUserName.Text,
				txtUserPwd.Text, idDbDepartment, passwordDB, out errore);

			if (errore != null) {
				QueryCreator.ShowError(this, "Non è stato collegare l'utente-operatore all utente-dipartimento", errore);
				return false;
			}
			MainConn.DO_SYS_CMD("UPDATE dbdepartment set description="+
				QueryCreator.quotedstrvalue(txtDepDescription.Text,true)+
							" WHERE iddbdepartment="+QueryCreator.quotedstrvalue(idDbDepartment,true),true);

			//			Easy_DataAccess depConn = Easy_DataAccess.getEasyDataAccess("NewDB", txtServerName.Text.Trim(),
			//				txtDBName.Text.Trim(), txtUserName.Text.Trim(), txtUserPwd.Text.Trim(), 
			//				idDbDepartment,
			//				2000, DateTime.Now, 
			//				out errore, out dettaglio);
			DataAccess myConn = new AllLocal_DataAccess("NewDB", txtServerName.Text.Trim(),
				txtDBName.Text.Trim(), idDbDepartment, passwordDB,
				txtUserName.Text.Trim(), txtUserPwd.Text.Trim(), 
				2000, DateTime.Now);

			myConn.Open();
			if (myConn.OpenError){
				QueryCreator.ShowError(this, 
					"Non è stato possibile connettersi al dipartimento "+idDbDepartment, myConn.LastError);
				return false;
			}

			setDepConn(myConn);
			if (userPresente) return true;

			//Esegue gli script per creare il DB
			StringBuilder SB = Download.LeggiTestoScript("creatabsistnondbo.sql");
			bool ok = Download.RUN_SCRIPT_NONSTOP(DepConn,SB,"Creazione tabelle di sistema non dbo");
			if (!ok) {
				MessageBox.Show(this, "Errore durante la creazione delle tabelle di sistema non dbo");
				//					return null;
			}

			if (ok){
				SB = Download.LeggiTestoScript("creatabnondbo.sql");
				ok = Download.RUN_SCRIPT_NONSTOP(DepConn,SB,"Creazione tabelle non dbo");
				if (!ok) {
					MessageBox.Show(this, "Errore durante la creazione delle tabelle non dbo");
					//					return null;
				}
			}

			if (ok){
				SB = Download.LeggiTestoScript("creaviewnondbo.sql");
				ok = Download.RUN_SCRIPT_NONSTOP(DepConn,SB,"Creazione viste non dbo");
				if (!ok) {
					MessageBox.Show(this, "Errore durante la creazione delle viste non dbo");
					//					return null;
				}
			}

			if (ok){
				SB = Download.LeggiTestoScript("creaspnondbo.sql");
				ok = Download.RUN_SCRIPT_NONSTOP(DepConn,SB,"Creazione stored procedure non dbo");
				if (!ok) {
					MessageBox.Show(this, "Errore durante la creazione delle stored procedure non dbo");
					//					return null;
				}
			}

			if (ok){
				//Esegue un analizza struttura
				DepConn.GenerateCustomObjects();
				DepConn.SaveStructure();

			}
			if (!ok){
				DisposeDepConn();
			}
			return ok;
		}

		/// <summary>
		/// Must return true if operation is possible, and do any
		///  operation related to change from tab oldTab to newTab
		/// </summary>
		/// <param name="oldTab"></param>
		/// <param name="newTab"></param>
		/// <returns></returns>
		bool CustomChangeTab(int oldTab, int newTab) {
			if (oldTab==0) {//Introduzione -> Creazione nuovo database
				return true ; // 0->1: nothing to do
			}
			if (oldTab==1 && newTab==2){//Creazione nuovo database -> Scelta dipartimento
//				btnGrandePunto_Click(null, null);
				//				if (Conn!=null) {
				//					//EnableDisableButtonsTabConfigurazione();
				//					return true;
				//				}
				//				if (chkSSPI.Checked){
				//					Conn= new DataAccess("NewDB",txtServerName.Text.Trim(),txtDBName.Text.Trim(),2000,DateTime.Now);
				//				}
				//				else {
				MainConn= new AllLocal_DataAccess("NewDB",txtServerName.Text.Trim(),txtDBName.Text.Trim(),
					txtUserName.Text.Trim(), txtUserPwd.Text.Trim(), 2000, DateTime.Now);
				//				}
				if (!MainConn.Open()){
					MainConn.Destroy();
					MainConn=null;
					MessageBox.Show(this,"Non è stato possibile collegarsi al database "+txtDBName.Text);
					return false;
				}
				if (DBNuovo) {
					grpNonProprioDipartimento.Visible = false;
					rbtNonProprioDipartimento.Visible = false;

					grpProprioDipartimento.Visible = false;
					rbtProprioDipartimento.Visible = false;

					rbtCreazioneDipartimento.Visible = false;
					rbtCreazioneDipartimento.Checked = true;
				} else {
					string filtro = "(login=" + QueryCreator.quotedstrvalue(txtUserName.Text.Trim(), true) + ")";
					DataTable t = DataAccess.SQLRunner(MainConn,"SELECT * from dbaccess WHERE "+filtro,true);
					string elencoPropriDip = QueryCreator.ColumnValues(t, null, "iddbdepartment", true);
					string filtroPropriDip;
					string filtroNonPropriDip;
					if (elencoPropriDip != "" && elencoPropriDip!=null) {
						filtroPropriDip = "(iddbdepartment in (" + elencoPropriDip + "))";
						filtroNonPropriDip = "(iddbdepartment not in (" + elencoPropriDip + "))";;
					}
					else {
						filtroPropriDip = "(iddbdepartment <> iddbdepartment)";
						filtroNonPropriDip = "(iddbdepartment = iddbdepartment)";
					}
					DataTable t1 = DataAccess.SQLRunner(MainConn,"SELECT * from dbdepartment WHERE "+filtroPropriDip,true);
					DataSet D1=new DataSet("temp1");
					D1.Tables.Add(t1);
					t1.PrimaryKey = new DataColumn[]{ t1.Columns["iddbdepartment"]};
					t1.TableName="aa";

					DataTable t2 = DataAccess.SQLRunner(MainConn,"SELECT * from dbdepartment WHERE "+filtroNonPropriDip,true);
					DataSet D2=new DataSet("temp2");
					D2.Tables.Add(t2);
					t2.PrimaryKey = new DataColumn[]{ t2.Columns["iddbdepartment"]};
					t2.TableName="nn";


					cmbProprioDipartimento.DataSource=null;
					cmbProprioDipartimento.Items.Clear();
					cmbProprioDipartimento.DataSource = t1;
					cmbProprioDipartimento.DisplayMember = "description";
					cmbProprioDipartimento.ValueMember = "iddbdepartment";
					//foreach (DataRow R1 in t1.Rows) cmbProprioDipartimento.Items.Add(R1);

					cmbNonProprioDipartimento.DataSource=null;
					cmbNonProprioDipartimento.Items.Clear();
					cmbNonProprioDipartimento.DataSource = t2;
					cmbNonProprioDipartimento.DisplayMember = "description";
					cmbNonProprioDipartimento.ValueMember = "iddbdepartment";

					grpNonProprioDipartimento.Visible = false ; // t2.Rows.Count>0;
					rbtNonProprioDipartimento.Visible = false ; //t2.Rows.Count>0;

					grpProprioDipartimento.Visible = t1.Rows.Count>0;
					rbtProprioDipartimento.Visible = t1.Rows.Count>0;

					rbtCreazioneDipartimento.Visible = (t1.Rows.Count>0); //||(t2.Rows.Count>0);

					if (t1.Rows.Count>0) {
						rbtProprioDipartimento.Checked = true;
						cmbProprioDipartimento.SelectedIndex=0;
					}
					else {
						rbtCreazioneDipartimento.Checked = true;
					}


				}
				return true;
			}

			if (oldTab==2 && newTab==3) {//Scelta dipartimento -> Configurazione e/o copia dati
				iddbdepartment=null;
				if (rbtProprioDipartimento.Checked){
					string error;
					string dettaglio;
					DataAccess TempConn= Easy_DataAccess.GetAllLocalDataAccess(
							"temp",
							txtServerName.Text.Trim(),
							txtDBName.Text.Trim(),
							txtUserName.Text.Trim(),
							txtUserPwd.Text.Trim(),
							cmbProprioDipartimento.SelectedValue.ToString(),
							DateTime.Now.Year,DateTime.Now, out error, out dettaglio);
					if (error!=null){
						QueryCreator.ShowError(this,error,dettaglio,null);
						return false;
					}
					TempConn.Open();
					if (TempConn.OpenError){
						TempConn.Destroy();
						return false;
					}
					setDepConn(TempConn);
					iddbdepartment= cmbProprioDipartimento.SelectedValue.ToString();
					DipartimentoNuovo=false;
					return true;
				}
				if (rbtNonProprioDipartimento.Checked) {
					//					idDbDepartment = (string) cmbNonProprioDipartimento.SelectedValue;
					return false;
				}
				if (rbtCreazioneDipartimento.Checked){
					//Deve creare un nuovo utente-dipartimento
					string idDbDepartment = txtDepName.Text.Trim();
					string passwordDB =  txtNewDepPwd.Text;
					bool res= connectToDepartment(idDbDepartment, passwordDB);
					if (res) iddbdepartment= idDbDepartment;
					DipartimentoNuovo=true;
					return res;
				}
				return false;
			}

			if (oldTab==3 && newTab==4){//Configurazione e/o copia dati -> Banche e sportelli
				EnableDisableNavigation(false);
                bool res=false;
                try {
                    res = CopiaTutto();
                }
                catch(Exception E) {
                    QueryCreator.ShowException(E);
                    res = false;
                }
				if (!res){
					EnableDisableNavigation(true);
					return false;
				}
				ImpostaTabConnessioni();
				EnableDisableNavigation(true);
				return true;
			}

			if (oldTab==4 && newTab==5){//Banche e sportelli -> Configurazione della connessione
				return true;
			}

			if (oldTab==5 && newTab==6){//Configurazione della connessione -> Impostazione Sito per aggiornamenti
				ImpostaTabLiveUpdate();
				return true;
			}

			if (oldTab==6 && newTab==7){//Impostazione Sito per aggiornamenti -> Impostazione cartella dei report
				ImpostaTabReport();
				return true;
			}
			if (oldTab==7 && newTab==8){//Impostazione cartella dei report -> LiveUpdate
				ImpostaTabEseguiLiveUpdate();
				return true;
			}

			if (oldTab==8 && newTab==9){//LiveUpdate -> Inserimento informazioni relative all'ente
				ImpostaTabInfoLicenza();
				return true;
			}

			return true;//Inserimento informazioni relative all'ente -> Fine
		}
		void DisposeDepConn(){
			try {
				if (DepConn!=null){
					DepConn.Destroy();
					setDepConn(null);

				}
			}
			catch {};
		}
		void DisposeSourceConn(){
			try {
				if (SourceConn!=null){
					SourceConn.Destroy();
					setSourceConn(null);

				}
			}
			catch {};
		}

		void EnableDisableNavigation(bool Enable){
			btnBack.Enabled=Enable;
			btnNext.Enabled=Enable;
		}

		#region Gestione Creazione DB
		
		private void btnCreaDataBase_Click(object sender, System.EventArgs e) {
			DBNuovo=false;
			MainConn=null;
			if (txtDBName.Text.Trim()==""){
				MessageBox.Show(this, "Inserire il nome del database da creare (o esistente vuoto)");
				txtDBName.Focus();
				return;
			}
			EnableDisableNavigation(false);
			DataAccess MASTERConn=null;
			try {
				if (txtServerName.Text.Trim()==""){
					MessageBox.Show(this, "Inserire il nome del server");
					txtServerName.Focus();
					return;
				}
				//				if (chkSSPI.Checked){
				//					Conn= new DataAccess("MasterDB",
				//						txtServerName.Text, "master",2000,DateTime.Now);
				//				}
				//				else {
				if (txtUserName.Text.Trim()==""){
					MessageBox.Show(this, "Inserire il nome dell'utente con cui collegarsi al server");
					txtUserName.Focus();
					return;
				}
			MASTERConn= new DataAccess("MasterDB",
					txtServerName.Text.Trim(), "master",
					txtUserName.Text.Trim(), txtUserPwd.Text.Trim(),
					2000,DateTime.Now);
				//				}
			}
			catch (Exception E) {
				QueryCreator.ShowException(this, null, E);
				MASTERConn.Destroy();
				return;
			}
			MASTERConn.Open();
			if (MASTERConn.OpenError){
				MASTERConn.Destroy();
				EnableDisableNavigation(true);
				MessageBox.Show(this,"Non è stato possibile collegarsi al server "+txtServerName.Text);
				return;
			}
			string err;
			DataTable T= MASTERConn.SQLRunner("select name from master.dbo.sysdatabases order by name",
				false,-1);
			if (T==null) {
				MessageBox.Show(this, "Errore accedendo all'elenco dei db sul server");
				MASTERConn.Destroy();
				EnableDisableNavigation(true);
				return;
			}
			//Se il database non esiste, lo crea.
			if (T.Select("name="+QueryCreator.quotedstrvalue(txtDBName.Text.Trim(),false)).Length==0){
				object O = MASTERConn.DO_SYS_CMD("CREATE DATABASE "+txtDBName.Text.Trim(),out err);
				if (err!=null) 	{
					MessageBox.Show(this,err,"Errore nella creazione del database. ");
					MainConn.Destroy();
					EnableDisableNavigation(true);
					return;
				}
				MessageBox.Show(this, "Il database "+txtDBName.Text+" è stato creato sul server "+
					txtServerName.Text+ ".");
			}
			MASTERConn.Destroy();

			//Si collega al nuovo database 
			MainConn = new AllLocal_DataAccess("NewDB",txtServerName.Text.Trim(),txtDBName.Text.Trim(),
				txtUserName.Text.Trim(), txtUserPwd.Text.Trim(), 2000,DateTime.Now);	
			MainConn.Open();

			if (MainConn.OpenError){
				MainConn.Destroy();
				MessageBox.Show(this,"Non è stato possibile collegarsi al database "+txtDBName.Text);
				EnableDisableNavigation(true);
				return;
			}

			//Se esistono già delle tabelle nel nuovo db, non prosegue!
			T= MainConn.SQLRunner("SELECT * FROM DBO.SYSOBJECTS WHERE XTYPE='U'",-1, out err);
			if (err!=null){
				MessageBox.Show(this,err);
				MainConn.Destroy();
				EnableDisableNavigation(true);
				return;
			}

			if (T.Rows.Count>0){
				MessageBox.Show(this, "Esistono già delle tabelle nel database "+txtDBName.Text.Trim()+
					". La creazione non sarà effettuata.");
				MainConn.Destroy();
				EnableDisableNavigation(true);
				return;
			}

			//CREAZIONE DEL DATABASE: Sono create solo le tabelle DBO 
			StringBuilder SB = Download.LeggiTestoScript("creatabsistdbo.sql");
			bool ok = Download.RUN_SCRIPT_NONSTOP(MainConn,SB,"Creazione tabelle di sistema dbo");



			if (ok) {
				SB = Download.LeggiTestoScript("creatabdbo.sql");
				ok = Download.RUN_SCRIPT_NONSTOP(MainConn,SB,"Creazione tabelle dbo");
				if (!ok) {
					MessageBox.Show(this, "Errore durante la creazione delle tabelle dbo");
					//					return null;
				}
			}

			if (ok){
				SB = Download.LeggiTestoScript("creaviewdbo.sql");
				ok = Download.RUN_SCRIPT_NONSTOP(MainConn,SB,"Creazione viste dbo");
				if (!ok) {
					MessageBox.Show(this, "Errore durante la creazione delle viste dbo");
					//					return null;
				}
			}
			
			if (ok){
				SB = Download.LeggiTestoScript("creaspdbo.sql");
				ok = Download.RUN_SCRIPT_NONSTOP(MainConn,SB,"Creazione stored procedure dbo");
				if (!ok) {
					MessageBox.Show(this, "Errore durante la creazione delle stored procedure dbo");
					//					return null;
				}
			}



			if (ok){
				SB = Download.LeggiTestoScript("AllSystemNoGeo.sql");
				ok =Download.RUN_SCRIPT(MainConn,SB,"Configurazione tabelle sistema");
				if (!ok)
					MessageBox.Show("Errore nella copia dei dati di sistema (AllSystemNoGeo).");
			}
			if (ok){
				SB = Download.LeggiTestoScript("AllGeo.sql");
				ok=Download.RUN_SCRIPT(MainConn,SB,"Configurazione tabelle geo");
				if (!ok)
					MessageBox.Show("Errore nella copia dei dati GEO.");
			}

			if (ok){
				MessageBox.Show(this,"La creazione del database ha avuto successo.");
				DBNuovo=true;
				btnCreaDataBase.Enabled=false;
			}
			else
			{
				MessageBox.Show(this,"Sono avvenuti degli errori. Il database NON E'stato creato.");
				DBNuovo=false;
			}

			MainConn.Destroy();
			EnableDisableNavigation(true);
			
		}

		#endregion



		#region Creazione Script di Sistema per DB

		private void btnSysDepends_Click(object sender, System.EventArgs e) {
			correggiDipendenzeProcedure();
			correggiDipendenzeViste();
		}

		private void correggiDipendenzeViste() {
			DataAccess TempConn= new AllLocal_DataAccess("NewDB",txtServerName.Text.Trim(),txtDBName.Text.Trim(),
				txtUserName.Text.Trim(), txtUserPwd.Text.Trim(), 2000,DateTime.Now);
			TempConn.Open();
			if (TempConn.OpenError){
				TempConn.Destroy();
				MessageBox.Show(this,"Non è stato possibile collegarsi al database "+txtDBName.Text);
				return;
			}

			DataTable SysComments = TempConn.RUN_SELECT("syscomments","id,colid,text,encrypted","id,colid",
				"(objectproperty(id,'isview')=1) and (OBJECTPROPERTY(id, 'IsMSShipped')=0)",
				null,false);
			//Nomi delle sp
			DataTable SysObjects = TempConn.RUN_SELECT("sysobjects","id,name,parent_obj,xtype,uid",null,
				"(xtype ='V') and OBJECTPROPERTY(id, 'IsMSShipped')=0",
				null,false);

			int NDONE=0;
			int NSP= SysObjects.Rows.Count;

			Queue coda = new Queue();
			foreach (DataRow r in SysObjects.Rows) {
				coda.Enqueue(r["id"]);
			}

			while (coda.Count > 0) {
				int id = (int) coda.Dequeue();
				DataRow SPObj = SysObjects.Select("id="+id)[0];

				StringBuilder All= new StringBuilder(100000);

				string spname= SPObj["name"].ToString();
				if (spname.StartsWith("check_")&&
					((spname.EndsWith("_pre")||spname.EndsWith("_post")))){
					NSP--;
					continue;
				}

				//SPObj è la riga in sysobject, che contiene il nome nel campo name
				DataRow []SPBodys= SysComments.Select("id="+id.ToString(),"colid");
				if (SPBodys[0]["encrypted"].ToString().ToUpper()=="TRUE") {
					NSP--;
					continue;
				}
				string spbody="";
				foreach (DataRow RR in SPBodys) {
					spbody+=RR["text"].ToString();
				}

				//Prende il testo della sp e si accerta che sia una SP DBO
				SPBridge SPB = new SPBridge(spbody);
				string skipped;
				dbbridge.SPToken Tok;
				Tok = SPB.NextToken(out skipped);
				All.Append(skipped);
				if (Tok.val.ToLower()!="create"){
					MessageBox.Show(this, "Impossibile compilare la sp "+spname);
					continue;
				}
				All.Append("ALTER "); //All.Append(Tok.val);
				Tok= SPB.NextToken(out skipped);
				All.Append(skipped);
				bool isView = Tok.val.ToLower()=="view";
				if ((Tok.val.ToLower()!="view")&&(Tok.val.ToLower()!="procedure")&&(Tok.val.ToLower()!="trigger")){
					MessageBox.Show(this, "Impossibile compilare la sp "+spname);
					continue;
				}
				All.Append(Tok.val);
				Tok = SPB.NextToken(out skipped);
				All.Append(skipped);
				string foundname= Tok.val;
				All.Append(foundname);

				int mark = SPB.GetMark();
				All.Append(spbody.Substring(mark));				
				TempConn.SQLRunner(All.ToString());
						
				DataTable t2 = TempConn.SQLRunner("select distinct depid from sysdepends where id="+id+" and objectproperty(depid,'isview')=1");

				bool elaborata = true;
				foreach (DataRow r in t2.Rows) {
					if (coda.Contains(r["depid"])) {
						elaborata = false;
						coda.Enqueue(id);
						break;
					}
				}
				if (elaborata) {
					NDONE++;
					SPObj["id"] = -id;
				}
			}

			if (NDONE==NSP){
				MessageBox.Show(this, "Aggiornamento effettuato correttamente");
			}
			else {
				MessageBox.Show(this, NDONE+" di "+NSP+" s.p. elaborate");
				foreach (DataRow EL in SysObjects.Rows){
					int id = (int) EL["id"];
					if (id<0) continue;
					MessageBox.Show(this, "La sp "+EL["name"]+" non è stata elaborata.");

				}
			}

			TempConn.Destroy();

		}
		private void correggiDipendenzeProcedure() {
			DataAccess TempConn=
						   new AllLocal_DataAccess("NewDB",txtServerName.Text.Trim(),txtDBName.Text.Trim(),
						   txtUserName.Text.Trim(), txtUserPwd.Text.Trim(), 2000,DateTime.Now);
			TempConn.Open();
			if (TempConn.OpenError){
				TempConn.Destroy();
				MessageBox.Show(this,"Non è stato possibile collegarsi al database "+txtDBName.Text);
				return;
			}

			DataTable SysComments = TempConn.SQLRunner("select syscomments.id,colid,text,encrypted from syscomments "
				+ " join SYSOBJECTS on syscomments.id=sysobjects.id "
				+ " WHERE (xtype in ('P','TR','FN')) and OBJECTPROPERTY(syscomments.id,'IsMSShipped')=0 and (uid=user_id()or uid=user_id('dbo'))"
				+ " order by syscomments.id,colid");

			DataTable SysObjects = TempConn.SQLRunner("select id,name,parent_obj,xtype,uid from sysobjects "
				+ "where (xtype in ('P','TR','FN')) and OBJECTPROPERTY(id, 'IsMSShipped')=0 and (uid=user_id()or uid=user_id('dbo'))");

			DataTable SysDepends = TempConn.SQLRunner("select sysdepends.id,depid from sysdepends "
				+ "join sysobjects obj on sysdepends.id=obj.id "
				+ "join sysobjects dep on sysdepends.depid=dep.id "
				+ "where (obj.xtype in ('P','TR','FN')) and (obj.uid=user_id()or obj.uid=user_id('dbo')) and "
				+"(dep.xtype in ('P','TR','FN')) and (dep.uid=user_id()or dep.uid=user_id('dbo')) "
				+ "order by sysdepends.id");
//			DataTable SysComments = TempConn.RUN_SELECT("syscomments","id,colid,text,encrypted","id,colid","(id in (SELECT ID FROM SYSOBJECTS WHERE (xtype in ('P','TR')) and OBJECTPROPERTY(id, 'IsMSShipped')=0))",
//				null,false);
			//Nomi delle sp
//			DataTable SysObjects = TempConn.RUN_SELECT("sysobjects","id,name,parent_obj,xtype,uid",null,"(xtype in ('P','TR')) and OBJECTPROPERTY(id, 'IsMSShipped')=0",
//				null,false);
//
//			DataTable SysDepends = TempConn.RUN_SELECT("sysdepends","id,depid","id","id in (select id from sysobjects where (xtype in ('P','TR'))) and depid in (select id from sysobjects where (xtype in ('P','TR')))",
//				null,null,false);

			bool SomethingDone=true;
			int NDONE=0;
			int NSP= SysObjects.Rows.Count;

			while (SomethingDone){
				SomethingDone=false;
				
				//Ora per ogni sp estrae il testo
				foreach (DataRow SPObj in SysObjects.Rows){
					StringBuilder All= new StringBuilder(100000);

					int id= (int) SPObj["id"];
					if (id<0) continue; //Già messa!
					//Vede se la sp dipende da qualche altra 
					//depid= l'oggetto che crea la dipendenza id=l'oggetto DIPENDENTE
					if (SysDepends.Select("id="+id.ToString()+" and depid<>"+id.ToString()).Length>0){
						//PostPone!
						//continue;
					}

					SPObj["id"]=-id;
					SomethingDone=true;						

					string spname= SPObj["name"].ToString();
					if (spname.StartsWith("check_")&&
						((spname.EndsWith("_pre")||spname.EndsWith("_post")))){
						NSP--;
						continue;
					}

					//SPObj è la riga in sysobject, che contiene il nome nel campo name
					DataRow []SPBodys= SysComments.Select("id="+id.ToString(),"colid");
					if (SPBodys[0]["encrypted"].ToString().ToUpper()=="TRUE") {
						NSP--;
						continue;
					}
					string spbody="";
					foreach (DataRow RR in SPBodys) {
						spbody+=RR["text"].ToString();
					}

					//Prende il testo della sp e si accerta che sia una SP DBO
					SPBridge SPB = new SPBridge(spbody);
					string skipped;
					dbbridge.SPToken Tok;
					Tok = SPB.NextToken(out skipped);
					All.Append(skipped);
					if (Tok.val.ToLower()!="create"){
						MessageBox.Show("Impossibile compilare la sp "+spname);
						continue;
					}
					
					All.Append("ALTER "); //All.Append(Tok.val);
					Tok= SPB.NextToken(out skipped);
					All.Append(skipped);
					bool isView = Tok.val.ToLower()=="view";
                    if ((Tok.val.ToLower() != "view") && (Tok.val.ToLower() != "function") &&
                        (Tok.val.ToLower()!="procedure")&&(Tok.val.ToLower()!="trigger")){
						MessageBox.Show("Impossibile compilare la sp "+spname);
						continue;
					}
					All.Append(Tok.val);
					Tok = SPB.NextToken(out skipped);
					All.Append(skipped);
					string foundname= Tok.val;
//					string []parts = foundname.Split(new char[]{'.'});
//					string newname= "[DBO]."+parts[parts.Length-1];
//					All.Append(newname);
					All.Append(foundname);
					int mark = SPB.GetMark();
					All.Append(spbody.Substring(mark));				
					DataTable t = TempConn.SQLRunner(All.ToString());
					if (t == null) {
						MessageBox.Show(this, TempConn.LastError);
					}
//					if (foundname=="[DBO].[invoiceavailable]") {
//						Console.WriteLine(All);
//					}

//					DataTable t2 = TempConn.SQLRunner("select * from sysdepends where id=172996143 and depid=1471044722");
//					if (t2.Rows.Count != 5) {
//						Console.WriteLine(All);
//					}

					NDONE++;
						
				}
			}
			if (NDONE==NSP){
				MessageBox.Show("Aggiornamento effettuato correttamente");
			}
			else {
				MessageBox.Show(NDONE.ToString()+" di "+NSP.ToString()+" s.p. elaborate");
				foreach (DataRow EL in SysObjects.Rows){
					int id = (int) EL["id"];
					if (id<0) continue;
					MessageBox.Show("La sp "+EL["name"].ToString()+" non è stata elaborata.");

				}
			}

			TempConn.Destroy();

		}


		private void btnGeneraScript_Click(object sender, System.EventArgs e) {
			//Si collega al nuovo database.
			//			if (chkSSPI.Checked){
			//				Conn= new DataAccess("NewDB",txtServerName.Text.Trim(),txtDBName.Text.Trim(),2000,DateTime.Now);
			//			}
			//			else {
			DataAccess TempConn=new AllLocal_DataAccess("NewDB",txtServerName.Text.Trim(),txtDBName.Text.Trim(),
				txtUserName.Text.Trim(), txtUserPwd.Text.Trim(), 2000,DateTime.Now);
			TempConn.Open();
			//			}
			if (TempConn.OpenError){
				TempConn.Destroy();
				MessageBox.Show(this,"Non è stato possibile collegarsi al database "+txtDBName.Text);
				return;
			}
			
			Cursor = Cursors.WaitCursor;
			Migrazione.CreaScriptStrutturaPerTabDiSistema(true, "creatabsistdbo.sql",TempConn,  this);
			Migrazione.CreaScriptStrutturaPerTabDiSistema(false, "creatabsistnondbo.sql",TempConn,  this);
			Migrazione.CreaScriptStrutturaPerTabelle(this, true,"creatabdbo.sql",TempConn);
			Migrazione.CreaScriptStrutturaPerTabelle(this, false,"creatabnondbo.sql",TempConn);
			Migrazione.CreaScriptPerViste("creaviewnondbo.sql", "creaviewdbo.sql", TempConn, this);
			Migrazione.CreaScriptPerSP("creaspdbo.sql","creaspnondbo.sql",TempConn);
			Cursor = null;

			TempConn.Destroy();			
		
		}
		#endregion




		#region Configurazione e importazione dati 







		bool CopyTable(DataTable TT, DataAccess Dest, out string s) {
			s = "";
			if (TT.Rows.Count==0) {
				return true;
			}
			string insert = "INSERT INTO "+TT.TableName+" (";
			foreach (DataColumn C in TT.Columns) {
				insert += C.ColumnName + ",";
			}
			insert = insert.Remove(insert.Length - 1, 1);
			insert += ") VALUES (";
			int count=0;
			FrmMeter FM= new FrmMeter(true);

			FM.StartPosition= FormStartPosition.CenterScreen;
			FM.Text="Copia della tabella "+TT.TableName;
			FM.pBar.Maximum= TT.Rows.Count;
			FM.Show();

			string err;
			foreach (DataRow row in TT.Rows) {
				FM.pBar.Increment(1);
				//				int i = 0;
				count++;
				string values = GeneraSQL.GetSQLDataValues(row);
				s += 	insert		+ values;
				if (count ==10){
					Dest.SQLRunner(s,-1, out err);
					Application.DoEvents();
					if (err!=null){
						QueryCreator.ShowError(FM,s,err);
						FM.Close();
						return false;
					}
					s = "";
					count=0;
				}
			}
			if (s!=""){
				Dest.SQLRunner(s,-1, out err);
				if (err!=null){
					QueryCreator.ShowError(FM,s,err);
					FM.Close();
					return false;
				}
				s = "";
			}
			FM.Close();
			Application.DoEvents();
			return true;
		}
	


		bool CopiaTutto() {
            // Esegue verifiche sui dati del DB Sorgente
            if (chkSourceSSPI.Checked) {
                setSourceConn(new DataAccess("NewDB", txtSourceServer.Text.Trim(), txtSourceDataBase.Text.Trim(), 2000, DateTime.Now));
            }
            else {
                setSourceConn(new DataAccess("NewDB", txtSourceServer.Text.Trim(), txtSourceDataBase.Text.Trim(),
                    txtSourceUser.Text.Trim(), txtSourcePwd.Text.Trim(), 2000, DateTime.Now));
            }
            if (!effettuaVerificheDB(SourceConn,true)) return false;
			
			//Disable all Triggers
			//DepConn.SQLRunner("exec sp_MSforeachtable 'ALTER TABLE ? DISABLE TRIGGER ALL'",false,-1);
            DepConn.CallSP("enable_disable_triggers",
                              new object[2]{txtDepName.Text.Trim(),
			                          'D'},
                              false,
                              500);
			
            StringBuilder SB;
            if (DBNuovo || DipartimentoNuovo) {
                DepConn.SQLRunner("INSERT INTO updatedbversion (versionname, description, flagerror, swversion) " +
                    " VALUES('2.0.234','Start Version', 'N', '2.2.235')", false, -1);
            }


            if (DBNuovo) {

                //MessageBox.Show("Configurazione delle regole trasferita correttamente.");

                SB = Download.LeggiTestoScript("Report.sql");
                Download.RUN_SCRIPT(DepConn, SB, "Configurazione dei reports");


                SB = Download.LeggiTestoScript("DBVuotiDBO.sql");
                Download.RUN_SCRIPT(DepConn, SB, "Configurazione x db vuoti (tab. DBO)");

                SB = Download.LeggiTestoScript("Anag.sql");
                Download.RUN_SCRIPT(DepConn, SB, "Configurazione tabelle anagrafica");

                SB = Download.LeggiTestoScript("Prestazioni.sql");
                Download.RUN_SCRIPT(DepConn, SB, "Configurazioni prestazioni e ritenute");

                SB = Download.LeggiTestoScript("IvaDBO.sql");
                Download.RUN_SCRIPT(DepConn, SB, "Configurazione iva (tab. DBO)");

                DBNuovo = false;

            }

            if (DipartimentoNuovo) {
                SB = Download.LeggiTestoScript("AllRules.sql");
                Download.RUN_SCRIPT(DepConn, SB, "Configurazione logica di business");
            }

            if (DipartimentoNuovo) {
                SB = Download.LeggiTestoScript("DBVuotiNonDBO.sql");
                Download.RUN_SCRIPT(DepConn, SB, "Configurazione x db vuoti (tab. Non DBO)");
            }

            if (DipartimentoNuovo) {
                SB = Download.LeggiTestoScript("IvaNonDBO.sql");
                Download.RUN_SCRIPT(DepConn, SB, "Configurazione iva (tab. Non DBO)");
                
            }


			bool res=true;

            Anagrafica.Reset();
            Upb.Reset();
            Iva.Reset();
            Patrimonio.Reset();
            Classificazioni.Reset();
            Missione.Reset();

            Anagrafica.migraCreditoreDebitore_eseguito = true;
            if (res) res = Anagrafica.migraAnagrafica(this, SourceConn, DepConn);
            //if (res) res = Upb.migraUpb(this, SourceConn, DepConn);
            //if (res) res = Iva.migraIva(this, SourceConn, DepConn);
            //if (res) res = Migrazione.migraVarie(this, SourceConn, DepConn);
            //if (res) res = Patrimonio.migraPatrimonio(this, SourceConn, DepConn);			
            //if (res) res=Classificazioni.migraClassificazioni(this, SourceConn, DepConn);
            //if (res) res = Missione.migraDatiMissione(this, SourceConn, DepConn);

			if (!res){
				//DepConn.SQLRunner("exec sp_MSforeachtable 'ALTER TABLE ? ENABLE TRIGGER ALL'",false,-1);
                DepConn.CallSP("enable_disable_triggers",
                              new object[2]{txtDepName.Text.Trim(),
			                          'E'},
                              false,
                              500);
				return false;
			}
			
            

			//Iva.RifinisciDettagliFattura(this,DepConn);
			Migrazione.DisabilitaVecchiOrdiniEFatture(this, DepConn);
            Migrazione.ImpostaExpenseSetup(this, SourceConn, DepConn);

            SB = Download.LeggiTestoScript("firstupdate_db.sql");
            bool ok = Download.RUN_SCRIPT(DepConn, SB, "Impostazione di alcuni campi ");
            if (!ok)
                MessageBox.Show("Errore in firstupdate_db.sql");


			DisposeSourceConn();




			//Enable all Triggers
			//DepConn.SQLRunner("exec sp_MSforeachtable 'ALTER TABLE ? ENABLE TRIGGER ALL'",false,-1);
            DepConn.CallSP("enable_disable_triggers",
                              new object[2]{txtDepName.Text.Trim(),
			                          'E'},
                              false,
                              500);
            FrmMeter FM = new FrmMeter(true);
			string []tnames = new string[]{"expenseyear","incomeyear","expense","income",
										"upb","incomevar","expensevar","creditpart","proceedspart",
											  "fin","finyear","finvar","finvardetail"
										  };
			FM.pBar.Maximum= tnames.Length;
			foreach(string tname in tnames){
				FM.Show();
				FM.Text="Rebuild index of "+tname;
				Application.DoEvents();
				DepConn.SQLRunner("DBCC DBREINDEX("+tname+")");
				FM.pBar.Increment(1);
			}
			FM.Close();


			//Esegue un rebuild totali
			object min_ayear = DepConn.DO_READ_VALUE("accountingyear", null, "MIN(ayear)");
			if ((min_ayear == null) || (min_ayear == DBNull.Value)) return true;
			object max_ayear = DepConn.DO_READ_VALUE("accountingyear", null, "MAX(ayear)");
			int min = Convert.ToInt32(min_ayear);
			int max = Convert.ToInt32(max_ayear);

			int Nobjr= (max-min+1)*14;

			FM = new FrmMeter(true);
			FM.Text= "Ricostruzione dei totalizzatori";
			FM.pBar.Maximum= Nobjr;
			FM.Show();
			Application.DoEvents();
			for(int i = min; i<= max; i++) {
				FM.pBar.Increment(1);
				FM.Text= "Ricostruzione dei totalizzatori ("+"rebuild_incometotal " + i.ToString()+")";
				Application.DoEvents();
				DepConn.SQLRunner("rebuild_incometotal " + i.ToString(),false,0);//0=no timeout

				FM.pBar.Increment(1);
				FM.Text="Rebuild index of incometotal";
				Application.DoEvents();
				DepConn.SQLRunner("DBCC DBREINDEX(incometotal)");

				FM.pBar.Increment(1);
				FM.Text= "Ricostruzione dei totalizzatori ("+"rebuild_expensetotal " + i.ToString()+")";
				Application.DoEvents();
				DepConn.SQLRunner("rebuild_expensetotal " + i.ToString(),false,0);//0=no timeout

				FM.pBar.Increment(1);
				FM.Text="Rebuild index of expensetotal";
				Application.DoEvents();
				DepConn.SQLRunner("DBCC DBREINDEX(expensetotal)");


				FM.pBar.Increment(1);
				FM.Text= "Ricostruzione dei totalizzatori ("+"rebuild_upbincometotal " + i.ToString()+")";
				Application.DoEvents();
				DepConn.SQLRunner("rebuild_upbincometotal " + i.ToString(),false,0);//0=no timeout

				FM.pBar.Increment(1);
				FM.Text="Rebuild index of upbincometotal";
				Application.DoEvents();
				DepConn.SQLRunner("DBCC DBREINDEX(upbincometotal)");



				FM.pBar.Increment(1);
				FM.Text= "Ricostruzione dei totalizzatori ("+"rebuild_upbexpensetotal " + i.ToString()+")";
				Application.DoEvents();
				DepConn.SQLRunner("rebuild_upbexpensetotal " + i.ToString(),false,0);//0=no timeout

				FM.pBar.Increment(1);
				FM.Text="Rebuild index of upbexpensetotal";
				Application.DoEvents();
				DepConn.SQLRunner("DBCC DBREINDEX(upbexpensetotal)");

				FM.pBar.Increment(1);
				FM.Text= "Ricostruzione dei totalizzatori ("+"rebuild_upbtotal " + i.ToString()+")";
				Application.DoEvents();
				DepConn.SQLRunner("rebuild_upbtotal " + i.ToString(),false,0);//0=no timeout

				FM.pBar.Increment(1);
				FM.Text="Rebuild index of upbtotal";
				Application.DoEvents();
				DepConn.SQLRunner("DBCC DBREINDEX(upbtotal)");

                FM.pBar.Increment(1);
                FM.Text = "Rebuild finyear " + i.ToString();
                Application.DoEvents();
                DepConn.SQLRunner("rebuild_finyear " + i.ToString(), false, 0); //0 = no timeout

				FM.pBar.Increment(1);
				FM.Text= "Ricostruzione dei totalizzatori ("+"rebuild_currentfloatfund " + i.ToString()+")";
				Application.DoEvents();
				DepConn.SQLRunner("rebuild_currentfloatfund " + i.ToString(),false,0);//0=no timeout

				FM.pBar.Increment(1);
				FM.Text= "Ricostruzione dei totalizzatori ("+"rebuild_sortedmovementtotal " + i.ToString()+")";
				Application.DoEvents();
				DepConn.SQLRunner("rebuild_sortedmovementtotal " + i.ToString(),false,0);//0=no timeout

				FM.pBar.Increment(1);
				FM.Text= "Ricostruzione dei totalizzatori ("+"rebuild_group_budget " + i.ToString()+")";
				Application.DoEvents();
				DepConn.SQLRunner("rebuild_group_budget " + i.ToString(),false,0);//0=no timeout
			}
			FM.Close();

			DBNuovo=false;

			return true;
		}

		



		private void creaUnoScriptDati(string scriptPath, DataAccess Conn, string[]tablename) {
			string scriptName = Path.GetFileNameWithoutExtension(scriptPath);
			DataSet DD= new DataSet();

			foreach (string tname  in tablename) {
				DataTable TT;
					TT= Conn.CreateTableByName(tname,"*");
					string filtro = null;
                    if (tname == "upb") {
						filtro = "idupb='0001'";
					}
					Conn.RUN_SELECT_INTO_TABLE(TT,null,filtro,null,false);
//				}
				DD.Tables.Add(TT);
			}

			try {
				GeneraSQL.GeneraStrutturaEDati(Conn, DD,
					scriptPath, false, UpdateType.bulkinsert,
					DataGenerationType.onlyData, true);
			}
			catch (Exception e){
				MessageBox.Show(this, "Errore creando lo script "+scriptPath+"\n"+e);
				return;
			}
		}


		private void btnCreaScriptTabSistema_Click(object sender, System.EventArgs e) {
			DataAccess Conn=new AllLocal_DataAccess("NewDB",txtServerName.Text.Trim(),txtDBName.Text.Trim(),
				txtUserName.Text.Trim(), txtUserPwd.Text.Trim(), 2000,DateTime.Now);

			if (!Conn.Open()){
				Conn.Destroy();
				MessageBox.Show(this,"Non è stato possibile collegarsi al database "+txtSourceDataBase.Text);
				return;
			}
			Cursor = Cursors.WaitCursor;
            //Tabelle che 
            string[] tabelle = new string[]{
                "abatement", "abatementcode", 
                "adminoperation", "affinity", "allowancerule", "allowanceruledetail",
                "apactivitykind", "apcontractkind", "apmanager", "apregistrykind", "buildcf", 
                "casualcontractexemption", "casualdeduction", "certificationmodel", "checkup", "connector", 
                "consultingkind", "contractlength", "customdirectrel", "customdirectrelcol", "customindirectrel", 
                "customindirectrelcol", "customoperator", "customselection", "deduction", "deductioncode", 
                "emenscontractkind", 
                //"employment", //??????????
                "epcontext", "epoperation", "expirationkind",
                "financialactivity", "acquirekind",
                "foreignallowancerule", "foreignallowanceruledetail", "foreigncountry", "foreigngroup", "foreigngrouprule", 
                "foreigngroupruledetail", //"generalreportparameter",
                "inpsactivity", "inpscenter", "itinerationparameter", 
                "itinerationrefundkindgroup", "itinerationrefundkindgroupreduction", "itinerationrefundrule", 
                "itinerationrefundruledetail", "mod770_details", "monthname", "motive770", "motive770service", 
                "otherinsurance", "position", "positionworkcontract", "reduction", "reductionrule", 
                "reductionruledetail", "registryclass", "residence", 
                "restrictedfunction","securitycondition","securityvar",
                 "sortabletable", "taxablekind", "taxableminmax", 
                "taxratebracket", "taxratecitybracket", "taxratecitystart", "taxrateregionbracket", 
                "taxrateregioncitystart", "taxrateregionstart", "taxratestart", "taxrateregioncitybracket",
                "trasmissiondocument","variationkind",
                 "workingtime"
            };
            creaUnoScriptDati("AllSystemNoGeo.sql",Conn,tabelle);

            tabelle = new string[]{"geo_agency", "geo_cap", "geo_cf", "geo_city", "geo_city_agency", "geo_code", 
                "geo_country", "geo_country_agency", "geo_nation", "geo_nation_agency", "geo_region",
                "geo_region_agency"
            };
			creaUnoScriptDati("AllGeo.sql",Conn,tabelle);



            tabelle = new string[]{"itinerationrefundkind", "service", "tax","servicetax", 
            };

			creaUnoScriptDati("Prestazioni.sql",Conn,tabelle);

            tabelle = new string[]{"address", "category", "centralizedcategory", "currency", "maritalstatus", 
                "paymethod", "registrykind", "title"
            };
            creaUnoScriptDati("Anag.sql", Conn, tabelle);//position, residence e role sono in comune con PrestazioniCfg

            tabelle = new string[]{"clawback", "stamphandling"
            };
            creaUnoScriptDati("DBVuotiDBO.sql", Conn, tabelle);

            tabelle = new string[]{"ivapayperiodicity"
            };
            creaUnoScriptDati("IvaDBO.sql", Conn, tabelle);




            //Da eseguire su dipartimenti nuovi (non dbo)
            tabelle = new string[]{"audit", "auditcheck", "auditparameter"};
            creaUnoScriptDati("AllRules.sql", Conn, tabelle);


            tabelle = new string[]{"exportfunction", "exportfunctionparam", "report", "reportadditionalparam", 
                "reportparameter"
            };
            creaUnoScriptDati("Report.sql", Conn, tabelle); 

            tabelle = new string[]{"mandatekind","estimatekind", "casualrefund", "profrefund",
                "pettycash","generalreportparameter"
            };
            creaUnoScriptDati("DBVuotiNonDBO.sql", Conn, tabelle);

           
            tabelle = new string[]{"invoicekind", "invoicekindregisterkind", "iva_mixed", "iva_prorata",
                "ivakind", "ivaregisterkind"
            };
            creaUnoScriptDati("IvaNonDBO.sql", Conn, tabelle);

			Conn.Destroy();
			Cursor = null;

			MessageBox.Show(this, "Script della cfg di sistema creato correttamente");

		}



		private void chkSourceSSPI_CheckedChanged(object sender, System.EventArgs e) {
			txtSourceUser.ReadOnly=chkSourceSSPI.Checked;
			txtSourcePwd.ReadOnly=chkSourceSSPI.Checked;

		}


		#endregion


		#region Gestione Connessioni 

		DataTable SysLogins;

		/// <summary>
		/// Aggiunge una riga dummy su questo utente al dblist ove assente
		/// </summary>
		/// <param name="dbl"></param>
		bool UpdateList(string curruser, dblist dbl){
			try {
				if (curruser==null)	curruser = System.Environment.UserName.ToUpper();
				if (dbl.db.Select("ntuser="+
					QueryCreator.quotedstrvalue(curruser,false)).Length>0) return false;

				//Adds a dummy row so it will never come here again
				DataRow dummy  = dbl.db.NewRow();
				dummy["ntuser"]= curruser;
				dummy["description"]="**dummy**";
				dbl.db.Rows.Add(dummy);
				return true;

			}
			catch (Exception E){
				QueryCreator.ShowException(this, null, E);
			}
			return false;
		}

		void SetDBList(dblist dbl){
			string curpath = AppDomain.CurrentDomain.BaseDirectory;
			if (!curpath.EndsWith("\\"))curpath+="\\";
			try {
				dbl.WriteXml(curpath+"dblist.xml", XmlWriteMode.WriteSchema);
			}
			catch (Exception E){
				QueryCreator.ShowException(this, null, E);
			}
		}

		bool ExistsInList(string ntuser, string username, string dep){
			string filterusr = 
				"(server="+	QueryCreator.quotedstrvalue(txtServerName.Text,false)+")AND"+
				"(database="+	QueryCreator.quotedstrvalue(txtDBName.Text,false)+")AND"+
				"(ntuser="+	QueryCreator.quotedstrvalue(ntuser.ToUpper(),false)+")";	
			dblist dbl=GetDBList();
			DataTable DB = dbl.Tables["db"];
			if (DB.Select(filterusr).Length>0) return true;
			return false;

		}
		void AddUserToList(string ntuser, string username, string dep){
			string filterusr = "(description="+	QueryCreator.quotedstrvalue(txtNomeEnte.Text,false)+")AND"+
				"(ntuser="+	QueryCreator.quotedstrvalue(ntuser.ToUpper(),false)+")";	

			string filterall = "(description="+	QueryCreator.quotedstrvalue(txtNomeEnte.Text,false)+")AND"+
				"(ntuser='*')";
			dblist dbl = GetDBList();
			DataTable DB = dbl.Tables["db"];
			DataRow dbr;
			DataRow []foundall = DB.Select(filterall);
			if (foundall.Length>0) return;
			DataRow []foundusr = DB.Select(filterusr);
			if (foundusr.Length>0) {
				dbr = foundusr[0];
				if ((dbr["server"].ToString()==txtServerName.Text)&&
					(dbr["database"].ToString()==txtDBName.Text)
					//					&&(dbr["trusted"].ToString()== (chkSSPI.Checked? "S":"N"))
					) return;
				dbr["server"]= txtServerName.Text;
				dbr["database"] = txtDBName.Text;
				dbr["department"] = dep;
				dbr["user"] = username.ToUpper();
				//dbr["trusted"]= chkConnectionSSPI.Checked? "S":"N";
				SetDBList(dbl);
			}
			else {
				dbr = DB.NewRow();
				dbr["description"]= txtNomeEnte.Text;
				dbr["server"]= txtServerName.Text;
				dbr["database"] = txtDBName.Text;
				dbr["user"] = username.ToUpper();
				dbr["ntuser"] = ntuser;
				dbr["department"] = dep;
				//dbr["trusted"]= chkConnectionSSPI.Checked? "S":"N";
				DB.Rows.Add(dbr);
				SetDBList(dbl);
			}

		}

		void RemoveFromList(string user,string dep){
			string filterusr = "(database="+	QueryCreator.quotedstrvalue(txtDBName.Text,false)+")AND"+
				"(user="+	QueryCreator.quotedstrvalue(user,false)+")AND"+
				"(department="+QueryCreator.quotedstrvalue(dep,false)+")";			
			dblist dbl = GetDBList();
			DataTable DB = dbl.Tables["db"];

			DataRow []foundusr = DB.Select(filterusr);
			if (foundusr==null) return;
			foreach( DataRow todel in foundusr) todel.Delete();
			DB.AcceptChanges();
			SetDBList(dbl);
		}

		
		/// <summary>
		/// Legge il dblist da file o ne crea uno vuoto
		/// </summary>
		/// <returns></returns>
		dblist GetDBList(){
			string curpath = AppDomain.CurrentDomain.BaseDirectory;
			if (!curpath.EndsWith("\\"))curpath+="\\";
			if (!File.Exists(curpath+"dblist.xml")) return new dblist();
			dblist newdblist = new dblist();
			try {
				newdblist.ReadXml(curpath+"dblist.xml",XmlReadMode.ReadSchema);
			}
			catch (Exception E) {
				QueryCreator.ShowException(this, null, E);
				//UpdateList(newdblist);
			}
			return newdblist;
		}

		
		void ImpostaTabConnessioni() {
			DataTable tUser = MainConn.SQLRunner("select distinct login from dbaccess where iddbdepartment="+
				QueryCreator.quotedstrvalue(iddbdepartment,false));
			
			DataTable tDip = MainConn.SQLRunner("select distinct iddbdepartment from dbaccess");
			string dipartimenti = QueryCreator.ColumnValues(tDip, null, "iddbdepartment", true);
			//PINO: NOME UTENTE (LOGIN SUL SERVER)
			string queryLoginServer = "select name,isntname,isntgroup,isntuser,loginname from master.dbo.syslogins "+
				"where hasaccess=1 and isntgroup=0";
			string queryUtentiDB = 	"select DISTINCT l.loginname  "+
				" from dbo.sysusers o "+
				" join master.dbo.syslogins l on l.sid = o.sid "+
				"where ((o.issqlrole != 1 and o.isapprole != 1 and o.status != 0) AND (o.isntuser=0))";
			if (dipartimenti != "") {
				queryLoginServer += " and loginname not in ("+dipartimenti+")";
				queryUtentiDB += " and loginname not in ("+dipartimenti+")";
			}
			SysLogins = MainConn.SQLRunner(queryLoginServer, false);
			if (SysLogins!=null){
				cmbUserList.Items.Clear();
				foreach (DataRow R in SysLogins.Rows){
					cmbUserList.Items.Add(R["loginname"].ToString());
				}
			}
			cmbUserList.Text="";

			listServerUser.Items.Clear();
			//PINO: UTENTI DEL DB CONFIGURATI SUL SERVER
			DataTable T1= MainConn.SQLRunner(queryUtentiDB);
			if (T1!=null){
				foreach(DataRow R1 in T1.Rows){
					if (R1["loginname"].ToString().Trim()=="")continue;
					listServerUser.Items.Add(R1["loginname"].ToString().ToUpper());
				}
			}

			listClientUser.Items.Clear();
			dblist DBL= GetDBList();
			if (DBL!=null){ 
				DataTable T2= DBL.Tables[0];
				foreach(DataRow R2 in T2.Select("(database="+
					QueryCreator.quotedstrvalue(MainConn.GetSys("database").ToString(),false)+
					")AND(user<>'*')")
					){
					if (listClientUser.Items.IndexOf(R2["user"].ToString().ToUpper())<0)
						listClientUser.Items.Add(R2["user"].ToString().ToUpper());
				}
			}

			listDepartmentUser.Items.Clear();
			foreach (DataRow r in tUser.Rows) {
				listDepartmentUser.Items.Add(r["login"]);
			}

			cmbUserList_SelectedIndexChanged(null,null);

		}

		


		private void btnAddConnection_Click(object sender, System.EventArgs e) {
			bool IsSQLAdmin=(bool)MainConn.GetSys("IsSystemAdmin");

			if (!IsSQLAdmin){
				MessageBox.Show(this, "Per poter aggiungere utenti è necessario essere amministratori del db.");
				return;
			}
			
			bool DoClientConfig=true;
			if (txtNomeEnte.Text.Trim()==""){
				DoClientConfig=false;
//				MessageBox.Show(this, "Inserire il nome ente");
//				txtNomeEnte.Focus();
//				return;
			}
			if (cmbUserList.Text.Trim()==""){
				MessageBox.Show(this, "Selezionare un utente da abilitare");
				cmbUserList.Focus();
				return;
			}
			string user= cmbUserList.Text.Trim();
			string WINUSER= txtWinUser.Text.Trim().ToUpper();
			string USER= user.ToUpper();
			if (WINUSER=="") WINUSER= USER;
			

			//Aggiunge l'utente alla lista utenti CLIENT (sul file DBLIST)
			if (DoClientConfig){
				if (!ExistsInList(WINUSER,USER,iddbdepartment)){
					AddUserToList(WINUSER, USER, iddbdepartment);
					if (listClientUser.Items.IndexOf(USER)<0)
						listClientUser.Items.Add(USER);
				}
				else {
					MessageBox.Show(this, "L'utente è già configurato sul client");
				}
			}
		
			if (listServerUser.Items.IndexOf(USER)<0){
				MainConn.SQLRunner("exec sp_grantdbaccess "+
					QueryCreator.quotedstrvalue(user,false)+", "+
					QueryCreator.quotedstrvalue(user,false));
				MainConn.SQLRunner("exec sp_addrolemember  N'db_denydatawriter',"+
					QueryCreator.quotedstrvalue(user,false));
				MainConn.SQLRunner("GRANT  SELECT  ON [dbo].[dbaccess] TO ["+user+"]");
				MainConn.SQLRunner("GRANT  SELECT  ON ["+iddbdepartment+"].[customobject] TO ["+user+"]");
				MainConn.SQLRunner("GRANT  SELECT  ON ["+iddbdepartment+"].[columntypes] TO ["+user+"]");
				
			}
			else {
				MessageBox.Show(this, "L'utente è già configurato sul server");
			}

			if (listDepartmentUser.Items.IndexOf(USER)<0){
				aggiungiUtenteAlDipartimento(USER);

				ImpostaTabConnessioni();
			}
			else {
				MessageBox.Show(this, "L'utente è già configurato sul dipartimento");
			}
		}

		private void btnCreateLogin_Click(object sender, System.EventArgs e) {
			bool IsSQLAdmin=(bool)MainConn.GetSys("IsSystemAdmin");
			if (!IsSQLAdmin){
				MessageBox.Show(this, "Per poter aggiungere login è necessario essere amministratori del db.");
				return ;
			}

			FrmAskLoginData F= new FrmAskLoginData(MainConn);
			DialogResult DR = F.ShowDialog(this);
			if (DR==DialogResult.OK) ImpostaTabConnessioni();
		}


		private void mnuDelClient_Click(object sender, System.EventArgs e) {
			bool IsSQLAdmin=(bool)MainConn.GetSys("IsSystemAdmin");
			if (!IsSQLAdmin){
				MessageBox.Show(this, "Per poter rimuovere utenti è necessario essere amministratori del db.");
				return ;
			}
			if (listClientUser.SelectedIndex<0) return;
			if (listClientUser.Items.Count<0) return;
			string todel= listClientUser.Items[listClientUser.SelectedIndex].ToString();
			RemoveFromList(todel,iddbdepartment);
			ImpostaTabConnessioni();
		}

		private void mnuDelServer_Click(object sender, System.EventArgs e) {
			if (listServerUser.SelectedIndex<0) return;
			if (listServerUser.Items.Count<0) return;

			bool IsSQLAdmin=(bool)MainConn.GetSys("IsSystemAdmin");
			if (!IsSQLAdmin){
				MessageBox.Show(this, "Per poter rimuovere utenti è necessario essere amministratori del db.");
				return ;
			}
			string todel= listServerUser.Items[listServerUser.SelectedIndex].ToString();


			string delcmd= "DELETE FROM DBACCESS WHERE login="+QueryCreator.quotedstrvalue(todel,true);
			string err;
			
			object res=MainConn.DO_SYS_CMD(delcmd,out err);
			if (err!=null) {
				MessageBox.Show(this, "Errore :"+err);
				return;
			}

			RemoveFromList(todel,iddbdepartment);

			string cmd=
				"select o.name from dbo.sysusers o "+
				"join master.dbo.syslogins l on l.sid = o.sid "+
				"where ((o.issqlrole != 1 and o.isapprole != 1 and o.status != 0)) "+
				"and (l.loginname = "+	QueryCreator.quotedstrvalue(todel,false)+ ")";
			object DBName=MainConn.DO_SYS_CMD(cmd,out err);
			if (DBName==DBNull.Value){
				MessageBox.Show("L'utente non era più collegato al DB");
				RemoveFromList(todel,iddbdepartment);
				ImpostaTabConnessioni();
				return;
			}
			if (err!=null) {
				MessageBox.Show(this, "Errore :"+err);
				ImpostaTabConnessioni();
				return;
			}

			cmd = "exec sp_revokedbaccess "+QueryCreator.quotedstrvalue(DBName,false);
			DBName=MainConn.DO_SYS_CMD(cmd,out err);
			if (err!=null) {
				MessageBox.Show(this, "Errore :"+err);
				ImpostaTabConnessioni();
				return;
			}			

			ImpostaTabConnessioni();
		}

		private void cmbUserList_SelectedIndexChanged(object sender, System.EventArgs e) {
			if (cmbUserList.SelectedItem==null) return;
			string curruser= cmbUserList.SelectedItem.ToString();
			if (SysLogins==null) return;
			DataRow []RR = SysLogins.Select("(loginname="+
				QueryCreator.quotedstrvalue(curruser,false)+")");
			if (RR.Length==0)return;
			//txtWinUser.Text="";
			txtWinUser.ReadOnly=false;
		}


		#endregion

		#region Configurazione LiveUpdate
		void ImpostaTabLiveUpdate(){
			LiveUpdateDS = new ConfigLiveUpdate.vistaForm();
			string currserver=null;
			
			string filename=AppDomain.CurrentDomain.BaseDirectory+"updateconfig.xml";
			try {
				LiveUpdateDS.ReadXml(filename);
				currserver = LiveUpdateDS.Tables["configtable"].Rows[0]["httpupdatepath"].ToString();
				if (currserver==null)currserver=LiveUpdateDS.Tables["configtable"].Rows[0]["httpupdatepath2"].ToString();
				if (currserver==null)currserver=LiveUpdateDS.Tables["configtable"].Rows[0]["httpupdatepath3"].ToString();
			}
			catch {

				currserver = "http://www.swandmore.it/easy2/";
				string currdir = AppDomain.CurrentDomain.BaseDirectory;
				string reportdir=currdir;
				if (reportdir.EndsWith("\\"))reportdir= reportdir.Substring(0,reportdir.Length-1);
				int lastslash= reportdir.LastIndexOf("\\");
				if (lastslash>0) reportdir= reportdir.Substring(0,lastslash);

                reportdir = reportdir + "\\report";


				DataRow NN= LiveUpdateDS.configtable.NewRow();
				LiveUpdateDS.configtable.Rows.Add(NN);
				LiveUpdateDS.AcceptChanges();
				LiveUpdateDS.configtable.Rows[0]["localreportdir"]=reportdir;

				LiveUpdateDS.configtable.Rows[0]["httpupdatepath"]=currserver;				
			}
			txtUpdateServer.Text=currserver;
			CheckServer();


		}
		void CheckServer(){
			txtServerRaggiungibile.Visible=false;
			txtNonRaggiungibile.Visible=false;

			bool esito=false;
			try {
				esito=TestServer();
			}
			catch{				
				esito=false;
			}

			if (esito){
				string filename=AppDomain.CurrentDomain.BaseDirectory+"updateconfig.xml";
				try {
					string currserver= txtUpdateServer.Text;
					LiveUpdateDS.configtable.Rows[0]["httpupdatepath"]=currserver;				
					LiveUpdateDS.WriteXml(filename);
				}
				catch (Exception E) {
					QueryCreator.ShowException(this, null, E);
				}
			}

			if (esito){
				txtServerRaggiungibile.Visible=true;
				txtNonRaggiungibile.Visible=false;
				IndirizzoLiveUpdateValido=txtUpdateServer.Text;
			}
			else {
				txtServerRaggiungibile.Visible=false;
				txtNonRaggiungibile.Visible=true;
				IndirizzoLiveUpdateValido=null;

			}
		}

		bool TestServer(){
			string server= txtUpdateServer.Text;
			if (!server.EndsWith("/"))server+="/";
			WebClient W = new WebClient();
			W.BaseAddress= server;			
			try {
				byte [] B = W.DownloadData(server+"versionesw.txt");
				W.Dispose();
				return true;
			}
			catch (Exception E) {
				QueryCreator.ShowException(this, null, E);
				return false;
			}

		}

		private void btnTestServer_Click(object sender, System.EventArgs e) {
			CheckServer();
		}
		
		#endregion


		#region Configurazione Cartella Report
		
		void ImpostaTabReport(){
			LiveUpdateDS = new ConfigLiveUpdate.vistaForm();
			string reportdir=null;
			
			string filename=AppDomain.CurrentDomain.BaseDirectory+"updateconfig.xml";
			try {
				LiveUpdateDS.ReadXml(filename);
				reportdir = LiveUpdateDS.Tables["configtable"].Rows[0]["localreportdir"].ToString();
			}
			catch {

				string currserver = "http://www.swandmore.it/easy2/";
				string currdir = AppDomain.CurrentDomain.BaseDirectory;
				reportdir=currdir;
				if (reportdir.EndsWith("\\"))reportdir= reportdir.Substring(0,reportdir.Length-1);
                int lastslash = reportdir.LastIndexOf("\\");
                if (lastslash > 0) reportdir = reportdir.Substring(0, lastslash);

                reportdir = reportdir + "\\report";




				LiveUpdateDS.configtable.Rows[0]["localreportdir"]=reportdir;

				LiveUpdateDS.configtable.Rows[0]["httpupdatepath"]=currserver;				
			}
			txtReportDir.Text=reportdir;
			CheckReportDir();

		}
		void CheckReportDir(){
			labReportOk.Visible=false;
			labReportNotOk.Visible=false;

			bool esito=false;
			try {
				esito=TestReport();
			}
			catch{				
				esito=false;
			}
			if (esito){
				string filename=AppDomain.CurrentDomain.BaseDirectory+"updateconfig.xml";
				try {
					string reportdir= txtReportDir.Text;
					LiveUpdateDS.configtable.Rows[0]["localreportdir"]=reportdir;
					LiveUpdateDS.WriteXml(filename);
				}
				catch (Exception E) {
					QueryCreator.ShowException(this, null, E);
				}

			}
			if (esito){
				labReportOk.Visible=true;
				labReportNotOk.Visible=false;
			}
			else {
				labReportOk.Visible=false;
				labReportNotOk.Visible=true;

			}
		}

		bool TestReport(){
			string reportdir= txtReportDir.Text;
			if (!reportdir.EndsWith("/"))reportdir+="/";
			if (Directory.Exists(reportdir))return true;
			return false;

		}

		private void btnChangeReportDir_Click(object sender, System.EventArgs e) {
			if (DirectoryPicker.ShowDialog(this)!=DialogResult.OK)return;
			txtReportDir.Text= DirectoryPicker.SelectedPath;
			CheckReportDir();			
		}


		#endregion


		#region Esegui LiveUpdate
		bool LiveSwInAvvio=false;
		bool LiveRptInAvvio=false;
		bool LiveDBInAvvio=false;

		void ImpostaTabEseguiLiveUpdate(){
			if (txtLiveSWStatus.Text==""){
				txtLiveDBStatus.Text="Non avviato";
				txtLiveRptStatus.Text="Non avviato";
				txtLiveSWStatus.Text="Non avviato";
			}
		}

		private void btnLiveUpdate_Click(object sender, System.EventArgs e) {
			btnLiveUpdate.Enabled=false;
			LiveSwInAvvio=true;
			LiveRptInAvvio=true;
			LiveDBInAvvio=true;

			btnBack.Enabled=false;
			btnNext.Enabled=false;
			btnCancel.Enabled=false;
			btnDelLastVersion.Enabled=false;
			
			UpdateDB();
			UpdateDll();
			UpdateReport();
			UpdateLiveStatus.Enabled=true;		
		}

		private Download MyDownloadSW;
		private Thread threadDownloadSW;
		private Download MyDownloadRep;
		private Thread threadDownloadRep;

		private Download MyDownloadDB;
		private Thread threadDownloadDB;


		private const string C_FILEINDEXNAME = "fileindex.xml";
		private const string C_REPORTINDEXNAME = "reportindex.xml";



		void UpdateDB(){
			// Avvia il live update del DB
			//if (threadDownloadDB==null || !threadDownloadDB.IsAlive) {
			threadDownloadDB = new Thread(new ThreadStart(UpdateDBThread));
			threadDownloadDB.Name = "UpdateDB";
			threadDownloadDB.Priority = ThreadPriority.BelowNormal;
			threadDownloadDB.Start();
			//}

		}

		void UpdateDll(){
			threadDownloadSW = new Thread(new ThreadStart(UpdateDllThread));
			threadDownloadSW.Name = "UpdateDll";
			threadDownloadSW.Priority = ThreadPriority.BelowNormal;
			threadDownloadSW.Start();
			
		}

		void UpdateReport(){
			threadDownloadRep = new Thread(new ThreadStart(UpdateReportThread));
			threadDownloadRep.Name = "UpdateReport";
			threadDownloadRep.Priority = ThreadPriority.BelowNormal;
			threadDownloadRep.Start();
		}

		private string[] GetLiveUpdateAddress() {
			string[] siti = new string[3];
			try {
				string filename=AppDomain.CurrentDomain.BaseDirectory+"updateconfig.xml";
				//string filename="updateconfig.xml";
				DataSet DS = new DataSet();
				DS.ReadXml(filename);
				siti[0] = DS.Tables["configtable"].Rows[0]["httpupdatepath"].ToString();
				siti[1] = DS.Tables["configtable"].Rows[0]["httpupdatepath2"].ToString();
				siti[2] = DS.Tables["configtable"].Rows[0]["httpupdatepath3"].ToString();
			}
			catch {}
			return siti;
		}

		void UpdateDllThread() {
			if ((MyDownloadSW!=null) && (MyDownloadSW.is_alive)) return;
			string[] rempath = GetLiveUpdateAddress();
			MyDownloadSW = new Download(null,
				rempath, 
				C_FILEINDEXNAME, 
				AppDomain.CurrentDomain.BaseDirectory);
			MyDownloadSW.GetNewSWVersion();

		}

		void UpdateReportThread() {
			if ((MyDownloadRep!=null) && (MyDownloadRep.is_alive)) return;
			string[] rempath = GetLiveUpdateAddress();
			MyDownloadRep = new Download(null,
				rempath, 
				C_FILEINDEXNAME, 
				AppDomain.CurrentDomain.BaseDirectory);
			MyDownloadRep.GetNewReportVersion(C_REPORTINDEXNAME);
		}


		
		bool UpdatingStatus=false;
		private void UpdateLiveStatus_Tick(object sender, System.EventArgs e) {		
			if (UpdatingStatus) return;
			UpdatingStatus=true;
			//terminato di default è true
			//Basta che ci sia un Livexxx in avvio a true che terminato diventa false.
			bool terminato=true;
			if (LiveSwInAvvio||LiveDBInAvvio||LiveRptInAvvio)terminato=false;

			if (MyDownloadSW!=null){
				LiveSwInAvvio=false;
				txtLiveSWStatus.Text= 
					QueryCreator.GetPrintable( MyDownloadSW.GetStatusSW()+"\r\n"+
					MyDownloadSW.GetLastErrorSW());
				if (MyDownloadSW.is_alive) terminato=false;
				else MyDownloadSW=null;
			}
			if (MyDownloadRep!=null){
				LiveRptInAvvio=false;
				txtLiveRptStatus.Text=
					QueryCreator.GetPrintable(MyDownloadRep.GetStatusSW()+"\r\n"+
					MyDownloadRep.GetLastErrorSW());
				if (MyDownloadRep.is_alive) terminato=false;
				else MyDownloadRep=null;
			}
			
			if (MyDownloadDB!=null) {
				LiveDBInAvvio=false;
				txtLiveDBStatus.Text= QueryCreator.GetPrintable(MyDownloadDB.GetStatusDB()+"\r\n"+
					MyDownloadDB.GetLastErrorDB());
				switch (Download.UpdateDbInCorso) {
					case "0":	//stato iniziale
						txtLiveDBStatus.Text="In avvio...";
						break;
					case "1":	//download e esecuzione script in corso
						txtLiveDBStatus.Text= 
							QueryCreator.GetPrintable( MyDownloadDB.GetStatusDB()+"\r\n"+
							Disp.GetSys("dbliveupdatedescription").ToString());
						break;
					default:	//aggiornamento terminato
						txtLiveDBStatus.Text= QueryCreator.GetPrintable(
							MyDownloadDB.GetStatusDB()+"\r\n"+
							MyDownloadDB.GetLastErrorDB());
						break;
				}
				if (MyDownloadDB.is_alive) {
					terminato=false;
				}
				else {
					MyDownloadDB.Connessione.Destroy();
					MyDownloadDB.Connessione=null;
					MyDownloadDB=null;
				}
			}

			if (terminato){
				btnNext.Enabled=true;
				btnBack.Enabled=true;
				btnCancel.Enabled=true;
				btnDelLastVersion.Enabled=true;
				btnLiveUpdate.Enabled=true;
				UpdateLiveStatus.Enabled=false;
			}
			UpdatingStatus=false;
		}

		/// <summary>
		/// Questo metodo è eseguito in un THREAD SECONDARIO!!!!! Non usare la conn.principale!!
		/// </summary>
		private void UpdateDBThread() {
			if ((MyDownloadDB!=null) && (MyDownloadDB.is_alive)) return;

			if (DepConn==null) return;
			string[] rempath = GetLiveUpdateAddress();
			Disp= new EntityDispatcher(DepConn);
			//Forzo la creazione perché posso aver aggiornato
			//la configurazione locale
			MyDownloadDB = new Download(Disp,   rempath, C_FILEINDEXNAME, 
				AppDomain.CurrentDomain.BaseDirectory);
			
			//Si può verififcare quando durante l'attesa per la connessione
			//al server web ci si disconnette dal Database
			DataAccess DownloadDBConnection = DepConn.Duplicate();
			MyDownloadDB.Connessione = DownloadDBConnection;
			MyDownloadDB.IsAdmin = Convert.ToBoolean(Disp.GetSys("IsSystemAdmin"));
			MyDownloadDB.GetNewDBVersion();

			//La connessione è distrutta dal metodo chiamato dal timer, che tra l'altro azzera la var. MyDownloadDB
			//se non è connesso non faccio nessun controllo di versione e/o aggiornamento
//			if (//MyDownloadSW == null || 
//				//!MyDownloadSW.Connected || 
//				!MyDownloadDB.Connected) {
//				MyDownloadDB.Connessione.Destroy();
//				MyDownloadDB.Connessione=null;
//				MyDownloadDB=null;				
//				return;
//			}
//
//			MyDownloadDB.Connessione.Destroy();
//			MyDownloadDB.Connessione=null;

		}

		#endregion


		#region Informazioni licenza uso

		/*
				int NL= MyDataAccess.RUN_SELECT_COUNT("licenzauso",
					"(iddbcliente is not null)and(universita is not null)and(dipartimento is not null)and"+
					"(rifcont is not null)and"+
					"(len(telefono)>=9)and(len(fax)>=9)and(len(email)>=9)and"+
					"(codicefiscale is not null)and(provincia is not null)",false);
				if (NL>0) return;
				*/


		void ImpostaTabInfoLicenza(){
			int NL= DepConn.RUN_SELECT_COUNT("license","(iddb is not null)and(agency is not null)and(department is not null)and"+
				"(referent is not null)and"+
				"(len(phonenumber)>=9)and(len(fax)>=9)and(len(email)>=9)and"+
				"(cf is not null)and(country is not null)",false);
			if (NL>0) { 
				labInfoLicenzaFound.Visible=true;
				labInfoLicenzaNotFound.Visible=false;
			}
			else {
				labInfoLicenzaFound.Visible=false;
				labInfoLicenzaNotFound.Visible=true;
			}
			if (NL==0){
				//Crea una riga vuota in licenzauso se licenzauso è vuota
				NL= DepConn.RUN_SELECT_COUNT("license",null,false);
				if (NL==0){
					DepConn.DO_SYS_CMD("insert into license(dummykey)VALUES (1)",false);
				}
			}

		}
		private void btnInsertInfoLicenza_Click(object sender, System.EventArgs e) {
			string error;
			string msg;
			Easy_DataAccess CConn= Easy_DataAccess.getEasyDataAccess(
				"temp",txtServerName.Text,txtDBName.Text,
							txtUserName.Text, txtUserPwd.Text, iddbdepartment,
							DateTime.Now.Year,DateTime.Now, out error, out msg);
			if (error!=null){
				if (CConn!=null) CConn.Destroy();
				QueryCreator.ShowError(this,error,msg);
				return;
			}
			//			if (chkSSPI.Checked){
			//				CConn= new DataAccess("NewDB",txtServerName.Text.Trim(),txtDBName.Text.Trim(),2000,DateTime.Now);
			//			}
			//			else {

			EntityDispatcher DD= new EntityDispatcher(CConn);
			bool res=DD.Edit(this,"license","estesa",true,null);	
			if (res) ImpostaTabInfoLicenza();
			CConn.Destroy();
		}


		#endregion

		private void btnAllBanche_Click(object sender, System.EventArgs e) {
			try {
				btnAllBanche.Enabled=false;
				StringBuilder SB = Download.LeggiTestoScript("tuttelebanche.sql");
				Download.RUN_SCRIPT_NONSTOP(DepConn,SB,"Creazione dati BANCHE");
				SB = Download.LeggiTestoScript("tuttiglisportelli.sql");
				Download.RUN_SCRIPT_NONSTOP(DepConn,SB,"Creazione dati SPORTELLI");
			}
			catch (Exception E) {
				QueryCreator.ShowException(this, "Errore creando le informazioni sulle banche.", E);
				btnAllBanche.Enabled=true;
			}
		}

		private void MenuNino_Popup(object sender, System.EventArgs e) {
		
		}


		private void EnableHidden_Click(object sender, System.EventArgs e) {
			FrmAskPwd  F = new FrmAskPwd(2);
			if (F.ShowDialog(this)!=DialogResult.OK) return;
			if (F.txtResult.Text=="falco"){
				btnGeneraScript.Visible=true;
				btnSysDepends.Visible=true;
				btnCreaScriptTabSistema.Visible=true;
				btnResetAll.Visible=true;
				btnRestoreDepartentUser.Visible=true;
				btnRipristinaUtentiNormali.Visible=true;
				txtSourceConn.Visible=true;
				txtConn.Visible=true;
				labSourceConn.Visible=true;
				labDestConn.Visible=true;
			}
		}

		private void btnDelLastVersion_Click(object sender, System.EventArgs e) {
			object lastver= DepConn.DO_READ_VALUE("updatedbversion", null, "max(versionname)");
			if (lastver==null) return;
			if (lastver.ToString().Trim()=="") return;
			DepConn.DO_SYS_CMD("DELETE FROM updatedbscript where versionname="+
				QueryCreator.quotedstrvalue(lastver,true),true);
			DepConn.DO_SYS_CMD("DELETE FROM updatedbversion where versionname="+
				QueryCreator.quotedstrvalue(lastver,true),true);

		
		}

		private void rdbtDipartimento_CheckedChanged(object sender, System.EventArgs e) {
			grpProprioDipartimento.Enabled = rbtProprioDipartimento.Checked;
			grpCreazioneDipartimento.Enabled = rbtCreazioneDipartimento.Checked;
			grpNonProprioDipartimento.Enabled = rbtNonProprioDipartimento.Checked;
		}

		public static bool ExportTableToXML(string filename, string tablename, DataAccess Conn, string filter) {
			DataSet DS = new DataSet();
			DataTable T = Conn.CreateTableByName(tablename,null);
			Conn.AddExtendedProperty(T);
			DS.Tables.Add(T);
			
			//reads table
			DataAccess.RUN_SELECT_INTO_TABLE(Conn,T,null,filter,null,true);

			try {
				DS.WriteXml(filename, XmlWriteMode.WriteSchema);
			}
			catch(Exception E) {
				MessageBox.Show("Couldn't write to file " + filename + " - " +
					E.Message,"ExportTableToXML");
				return false;
			}
			return true;
		}

		/// <summary>
		/// Crea il file tables.dat in base al contenuto delle tabelle tablename e colname del db
		/// Aggiorna anche le tabelle in memoria (tTableName e tColName)
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>





		private void riempiTxtDB(TextBox txt, DataAccess dataAccess) {
			if (dataAccess == null) {
				txt.Text = null;
			} else {
				string server = dataAccess.GetSys("server").ToString();
				if (server == ".") {
					server = dataAccess.GetSys("computername").ToString();
				}
				txt.Text = server+"."+dataAccess.GetSys("database")+"."+dataAccess.GetSys("userdb");
			}
		}

		/// <summary>
		/// Imposta la variabile globale Conn (master Connection)
		/// </summary>
		/// <param name="dataAccess"></param>
		private void setDepConn(DataAccess dataAccess) {
			DepConn = dataAccess;
			riempiTxtDB(txtConn, dataAccess);
		}

		private void setSourceConn(DataAccess dataAccess) {
			SourceConn = dataAccess;
            SourceConn.UseCustomObject = false;
			riempiTxtDB(txtSourceConn, dataAccess);
		}
		private string aggiungiUtenteAlDipartimento(string username) { 
			string errore;
			string dettaglio;
			Easy_DataAccess EA = Easy_DataAccess.getEasyDataAccess("TEMP",
						txtServerName.Text,txtDBName.Text,txtUserName.Text,txtUserPwd.Text,
						iddbdepartment,DateTime.Now.Year,DateTime.Now, out errore, out dettaglio);
			if (errore!=null && errore !=""){
				QueryCreator.ShowError(this,errore,dettaglio);
				return errore;
			}
			EA.linkUserToDepartment(username, out errore);
			if (errore!=null) MessageBox.Show(errore);
			return errore;
		}


		private byte[] xor(byte[] a, byte[] b) {
			BitArray orEsclusivo = new BitArray(a).Xor(new BitArray(b));
			byte[] result = new byte[32];
			orEsclusivo.CopyTo(result, 0);
			return result;
		}


		private void menuItem1_Click(object sender, System.EventArgs e) {
			if (listDepartmentUser.SelectedIndex<0) return;
			if (listDepartmentUser.Items.Count<0) return;

			bool IsSQLAdmin=(bool)MainConn.GetSys("IsSystemAdmin");
			if (!IsSQLAdmin){
				MessageBox.Show(this, "Per poter rimuovere utenti è necessario essere amministratori del db.");
				return ;
			}
			string todel= listDepartmentUser.Items[listDepartmentUser.SelectedIndex].ToString();


			string delcmd= "DELETE FROM DBACCESS WHERE login="+QueryCreator.quotedstrvalue(todel,true);
			string err;
			
			object res=MainConn.DO_SYS_CMD(delcmd,out err);
			if (err!=null) {
				MessageBox.Show(this, "Errore :"+err);
				ImpostaTabConnessioni();
				return;
			}

			RemoveFromList(todel,iddbdepartment);
			ImpostaTabConnessioni();
		
		}

		private void btnResetAll_Click(object sender, System.EventArgs e) {
			string err;
			DataAccess Main= new DataAccess("temp",txtServerName.Text, txtDBName.Text,
									txtUserName.Text,txtUserPwd.Text, 
									txtUserName.Text,txtUserPwd.Text,
									DateTime.Now.Year,DateTime.Now);
			Main.Open();
			if (Main.OpenError){
				err= Main.LastError;
				QueryCreator.ShowError(this,"Impossibile connettersi al db",err);
				Main.Destroy();
				return;
			}			

			if (ResetPassword(Main,txtUserName.Text,txtUserPwd.Text)){
				MessageBox.Show(this,"Reset effettuato");
			}
			Main.Destroy();
		
		}

		bool ResetPassword(DataAccess Conn, string iddbdepartment, string deppassword){
			string err;
			DataTable DBACCESS= Conn.SQLRunner(
				"SELECT * from dbaccess WHERE iddbdepartment="+
				QueryCreator.quotedstrvalue(iddbdepartment,true),
				-1, out err);

			if (DBACCESS==null){
				QueryCreator.ShowError(this,"Errore nella lettura di DBACCESS",err);
				return false;
			}
			if (DBACCESS.Rows.Count==0){
				MessageBox.Show("Non ci sono utenti, probabilmente l'utente"+iddbdepartment+" non è un DIPARTIMENTO");
				return false;
			}
			foreach(DataRow R in DBACCESS.Select()){
				Easy_DataAccess.linkUserToDepartment(Conn, R["login"].ToString(),Easy_DataAccess.INITIAL_PASSWORD,
					iddbdepartment,deppassword, out err);
				if ((err!=null)&&(err!="")){
					QueryCreator.ShowError(this,"Errore resettando la password di "+R["login"].ToString(),err);					
				}						
			}
			return true;
		}

		private void btnRestoreDepartentUser_Click(object sender, System.EventArgs e) {
			string err;
			DataAccess Main= new DataAccess("temp",txtServerName.Text, txtDBName.Text,
				txtUserName.Text,txtUserPwd.Text, 
				txtUserName.Text,txtUserPwd.Text,
				DateTime.Now.Year,DateTime.Now);
			Main.Open();
			if (Main.OpenError){
				err= Main.LastError;
				QueryCreator.ShowError(this,"Impossibile connettersi al db",err);
				Main.Destroy();
				return;
			}			

			DataTable DBACCESS= Main.SQLRunner(	"SELECT DISTINCT iddbdepartment from dbaccess ",-1, out err);
			if (DBACCESS==null){
				QueryCreator.ShowError(this,"Errore nella lettura di DBACCESS",err);
				Main.Destroy();
				return;
			}
			int NDip=DBACCESS.Rows.Count;
			MessageBox.Show("Dipartimenti trovati:"+NDip);
			foreach(DataRow R in DBACCESS.Select()){
				string idDbDepartment= R["iddbdepartment"].ToString();

				//Vede se esiste la login sul server 
				////////////////////////////////////////////////////////////////////////////////////////////
				
				DataTable T1= Main.SQLRunner("select name from master.dbo.syslogins where loginname="
					+ QueryCreator.quotedstrvalue(idDbDepartment, true), -1, out err);
				if (err != null) {
					QueryCreator.ShowError(this, "Non è stato possibile ottenere l'elenco delle login dal server", err);
					return;
				}

				bool loginPresente = T1.Rows.Count > 0;
				if (!loginPresente) {
					//Crea la login con password 12345
					Main.DO_SYS_CMD("EXEC sp_addlogin "+QueryCreator.quotedstrvalue(idDbDepartment,false)+
						","+QueryCreator.quotedstrvalue(Easy_DataAccess.INITIAL_PASSWORD,false), out err);
					if (err!=null){
						MessageBox.Show(this, "Errore creando l'utente "+idDbDepartment+": " +err);
						continue;
					}		
					else {
						MessageBox.Show(this, "Login "+idDbDepartment+" creata con password: " +
							Easy_DataAccess.INITIAL_PASSWORD);
						MessageBox.Show(this,"Sarà necessario azzerare le password degli utenti di "+idDbDepartment);
					}
				}
				object id_DIP= Main.DO_SYS_CMD("SELECT sid from sysusers where name="+
							QueryCreator.quotedstrvalue(idDbDepartment,true));
				if (id_DIP==null) id_DIP=new byte[]{12};
				object id_SER= Main.DO_SYS_CMD("SELECT sid from master.dbo.syslogins where name="+
					QueryCreator.quotedstrvalue(idDbDepartment,true));
				if (id_SER==null) id_SER=new byte[]{13};
				if (QueryCreator.ByteArrayToString((byte [])id_DIP)==QueryCreator.ByteArrayToString((byte [])id_SER)){
					MessageBox.Show("La login "+idDbDepartment+" è già sincronizzata.");
					continue;
				}


				//Collega la login adesso certamente esistente  con lo user-dipartimento del db
				Main.DO_SYS_CMD("sp_change_users_login 'UPDATE_ONE',"+
							QueryCreator.quotedstrvalue(idDbDepartment,true)+","+
							QueryCreator.quotedstrvalue(idDbDepartment,true),out err);
				if ((err!=null)&&(err!="")){
					MessageBox.Show(this,"Problemi correggendo la login del dipartimento "+idDbDepartment);
				}
				else {
					MessageBox.Show(this,"La login del dipartimento "+idDbDepartment+ " è stata sincronizzata.");
				}

			}
			
			

		}

		private void btnRipristinaUtentiNormali_Click(object sender, System.EventArgs e) {
			string err;
			DataAccess Main= new DataAccess("temp",txtServerName.Text, txtDBName.Text,
				txtUserName.Text,txtUserPwd.Text, 
				txtUserName.Text,txtUserPwd.Text,
				DateTime.Now.Year,DateTime.Now);
			Main.Open();
			if (Main.OpenError){
				err= Main.LastError;
				QueryCreator.ShowError(this,"Impossibile connettersi al db",err);
				Main.Destroy();
				return;
			}			
			string iddep=txtUserName.Text;
			string pwddep=txtUserPwd.Text;

			DataTable DBACCESS= Main.SQLRunner(
				"SELECT * from dbaccess WHERE iddbdepartment="+
				QueryCreator.quotedstrvalue(iddep,true),
				-1, out err);

			if (DBACCESS==null){
				QueryCreator.ShowError(this,"Errore nella lettura di DBACCESS",err);
				return ;
			}
			if (DBACCESS.Rows.Count==0){
				MessageBox.Show("Non ci sono utenti, probabilmente l'utente"+iddep+" non è un DIPARTIMENTO");
				return ;
			}

			int NDip=DBACCESS.Rows.Count;
			MessageBox.Show("Utenti trovati:"+NDip);
			foreach(DataRow R in DBACCESS.Select()){
				string iduser= R["login"].ToString();
				if (iduser.ToUpper()=="SA"){
					MessageBox.Show("Utente SA saltato.");
					continue;
				}

				//Vede se esiste la login sul server 
				////////////////////////////////////////////////////////////////////////////////////////////
				
				DataTable T1= Main.SQLRunner("select name from master.dbo.syslogins where loginname="
					+ QueryCreator.quotedstrvalue(iduser, true), -1, out err);
				if (err != null) {
					QueryCreator.ShowError(this, "Non è stato possibile ottenere l'elenco delle login dal server", err);
					return;
				}

				bool loginPresente = T1.Rows.Count > 0;
				if (!loginPresente) {
					//Crea la login con password 12345
					Main.DO_SYS_CMD("EXEC sp_addlogin "+QueryCreator.quotedstrvalue(iduser,false)+
						","+QueryCreator.quotedstrvalue(Easy_DataAccess.INITIAL_PASSWORD,false), out err);
					if (err!=null){
						MessageBox.Show(this, "Errore creando l'utente "+iduser+": " +err);
						continue;
					}		
					else {
						MessageBox.Show(this, "Login "+iduser+" creata con password: " +
							Easy_DataAccess.INITIAL_PASSWORD);
					}
				}
				object id_DIP= Main.DO_SYS_CMD("SELECT sid from sysusers where name="+
					QueryCreator.quotedstrvalue(iduser,true));
				if (id_DIP==null) id_DIP=new byte[]{12};
				object id_SER= Main.DO_SYS_CMD("SELECT sid from master.dbo.syslogins where name="+
					QueryCreator.quotedstrvalue(iduser,true));
				if (id_SER==null) id_SER=new byte[]{13};
				if (QueryCreator.ByteArrayToString((byte [])id_DIP)==QueryCreator.ByteArrayToString((byte [])id_SER)){
					MessageBox.Show("La login "+iduser+" è già sincronizzata.");
					continue;
				}


				//Collega la login adesso certamente esistente  con lo user-dipartimento del db
				Main.DO_SYS_CMD("sp_change_users_login 'UPDATE_ONE',"+
					QueryCreator.quotedstrvalue(iduser,true)+","+
					QueryCreator.quotedstrvalue(iduser,true),out err);
				if ((err!=null)&&(err!="")){
					MessageBox.Show(this,"Problemi correggendo la login dell'utente "+iduser);
				}
				else {
					MessageBox.Show(this,"La login dell'utente "+iduser+ " è stata sincronizzata.");
				}

			}
		}



		

        private void btnDBCopia_Click(object sender, EventArgs e) {
            //Si collega al nuovo database.
            //			if (chkSSPI.Checked){
            //				Conn= new DataAccess("NewDB",txtServerName.Text.Trim(),txtDBName.Text.Trim(),2000,DateTime.Now);
            //			}
            //			else {
            DataAccess TempConn = new AllLocal_DataAccess("NewDB", txtServerName.Text.Trim(), txtDBName.Text.Trim(),
                txtUserName.Text.Trim(), txtUserPwd.Text.Trim(), 2000, DateTime.Now);
            TempConn.Open();
            //			}
            if (TempConn.OpenError) {
                TempConn.Destroy();
                MessageBox.Show(this, "Non è stato possibile collegarsi al database " + txtDBName.Text);
                return;
            }

            Cursor = Cursors.WaitCursor;
            Migrazione.CreaScriptStrutturaPerTabDiSistema(true, "creatabsistdbo.sql", TempConn, this);
            Migrazione.CreaScriptStrutturaPerTabDiSistema(false, "creatabsistnondbo.sql", TempConn,  this);
            Migrazione.CreaScriptStrutturaPerTabelle(this, true, "creatabdbo.sql", TempConn);
            Migrazione.CreaScriptStrutturaPerTabelle(this, false, "creatabnondbo.sql", TempConn);
            Migrazione.CreaScriptPerViste("creaviewnondbo.sql", "creaviewdbo.sql", TempConn, this);
            Migrazione.CreaScriptPerSP("creaspdbo.sql", "creaspnondbo.sql", TempConn);
            Cursor = null;

            TempConn.Destroy();		
        }

        private bool effettuaVerificheDB (DataAccess SourceConn, bool question) {
            if (!SourceConn.Open()) {
                DisposeSourceConn();
                MessageBox.Show(this, "Non è stato possibile collegarsi al database " + txtSourceDataBase.Text);
                return false;
            }
            //Commentati temporaneamente x velocizzare
            if (!Anagrafica.EffettuaControlli(this, SourceConn,question)) return false;
            if (!Patrimonio.EffettuaControlli(this, SourceConn)) return false;
            if (!Upb.EffettuaControlli(this, SourceConn)) return false;
            if (!Migrazione.EffettuaControlli(this, SourceConn)) return false;
            return true;
        }

        private void btnEffettuaVerifiche_Click (object sender, EventArgs e) {
            if (chkSourceSSPI.Checked) {
                setSourceConn(new DataAccess("NewDB", txtSourceServer.Text.Trim(), txtSourceDataBase.Text.Trim(), 2000, DateTime.Now));
            }
            else {
                setSourceConn(new DataAccess("NewDB", txtSourceServer.Text.Trim(), txtSourceDataBase.Text.Trim(),
                    txtSourceUser.Text.Trim(), txtSourcePwd.Text.Trim(), 2000, DateTime.Now));
            }
            effettuaVerificheDB(SourceConn,false);
        }

	}
}
