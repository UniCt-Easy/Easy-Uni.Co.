/*
    Easy
    Copyright (C) 2020 Universit√† degli Studi di Catania (www.unict.it)
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
using metaeasylibrary;
using System.Data;
using System.Text;
using LiveUpdate;//LiveUpdate
using funzioni_configurazione;

namespace accountingyear_confcontabile//InstallContabile//
{
	/// <summary>
	/// Summary description for FrmInstallContabile.
	/// </summary>
	public class Frm_accountingyear_confcontabile : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnNext;
		private System.Windows.Forms.Button btnBack;
		private Crownwood.Magic.Controls.TabControl tabController;
		Easy_DataAccess Conn;
		private Crownwood.Magic.Controls.TabPage tabPage1;
		private System.Windows.Forms.Label label18;
		private System.Windows.Forms.Label label17;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private Crownwood.Magic.Controls.TabPage tabPage2;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.GroupBox gboxEsercizio;
		private System.Windows.Forms.Button btnCreaEsercizio;
		private System.Windows.Forms.Label labEsercizioFound;
		private System.Windows.Forms.Label labEsercizioNotFound;
		private System.Windows.Forms.NumericUpDown numEsercizio;
		string CustomTitle;
		private Crownwood.Magic.Controls.TabPage tabPage3;
		private System.Windows.Forms.Label label8;
		MetaData Meta;
		private Crownwood.Magic.Controls.TabPage tabPage4;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Button btnInserisciInfoEnte;
		public vistaForm DS;
		private Crownwood.Magic.Controls.TabPage tabPage5;
		private System.Windows.Forms.Label label19;
		private System.Windows.Forms.Label label21;
		private System.Windows.Forms.Button btnSetFaseEntrata;
		private System.Windows.Forms.Button btnSetFaseSpesa;
		private System.Windows.Forms.Label label22;
		private System.Windows.Forms.Label label23;
		private System.Windows.Forms.Label label24;
		private System.Windows.Forms.Label label20;
		private Crownwood.Magic.Controls.TabPage tabPage6;
		private System.Windows.Forms.Label label25;
		private System.Windows.Forms.Label label26;
		private System.Windows.Forms.Button btnLeveBilancio;
		private System.Windows.Forms.Label label27;
		private System.Windows.Forms.Label label28;
		private System.Windows.Forms.Button btnModificaBilancio;
		private System.Windows.Forms.Label label29;
		private System.Windows.Forms.Label label30;
		private Crownwood.Magic.Controls.TabPage tabPage7;
		private System.Windows.Forms.Label label31;
		private System.Windows.Forms.Label label32;
		private System.Windows.Forms.Label label33;
		private System.Windows.Forms.Label label34;
		private System.Windows.Forms.Label label35;
		private System.Windows.Forms.Label label36;
		private System.Windows.Forms.Label label37;
        private System.Windows.Forms.Label label38;
		private System.Windows.Forms.Button btnCfgEntrata;
		private System.Windows.Forms.Label label40;
		private System.Windows.Forms.Label label41;
		private System.Windows.Forms.Label label42;
		private System.Windows.Forms.Label label43;
        private System.Windows.Forms.Label label44;
		private System.Windows.Forms.Label label46;
		private System.Windows.Forms.Label label47;
		private System.Windows.Forms.Label label48;
		private System.Windows.Forms.Label label49;
		private System.Windows.Forms.Label label50;
		private System.Windows.Forms.Button btnCfgSpese;
		private Crownwood.Magic.Controls.TabPage tabPage8;
		private System.Windows.Forms.Label label51;
		private System.Windows.Forms.Label label52;
		private System.Windows.Forms.Label label53;
		private System.Windows.Forms.Button btnCfgBilancio;
		private Crownwood.Magic.Controls.TabPage tabPage9;
		private System.Windows.Forms.Label label54;
		private System.Windows.Forms.Label label55;
		private System.Windows.Forms.Label label56;
		private System.Windows.Forms.Label label57;
		private System.Windows.Forms.Label label58;
		private System.Windows.Forms.Button btnCfgMissioni;
		private Crownwood.Magic.Controls.TabPage tabPage10;
		private System.Windows.Forms.Label label59;
		private System.Windows.Forms.Label label60;
		private System.Windows.Forms.Button btnCfgIstCassiere;
		private System.Windows.Forms.Label label61;
		private System.Windows.Forms.Button btnCfgMovBancari;
		private Crownwood.Magic.Controls.TabPage tabPage11;
		private System.Windows.Forms.Label label62;
		private System.Windows.Forms.Label label63;
		private System.Windows.Forms.Button btnCfgBollo;
		private Crownwood.Magic.Controls.TabPage tabPage12;
		private System.Windows.Forms.Label label64;
		private System.Windows.Forms.Label label66;
		private System.Windows.Forms.Button btnRicompila;
		private System.Windows.Forms.Label label67;
		private System.Windows.Forms.PictureBox pictureBox1;
		private Crownwood.Magic.Controls.TabPage tabPage13;
		private System.Windows.Forms.Label label68;
		private System.Windows.Forms.Label label69;
		private System.Windows.Forms.Button btnPersonalizzaReport;
		private System.Windows.Forms.Label label70;
		private System.Windows.Forms.Label label71;
		private Crownwood.Magic.Controls.TabPage tabPage14;
		private System.Windows.Forms.Label label72;
        private Label label39;
        private Button button1;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Frm_accountingyear_confcontabile()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			tabController.HideTabsMode = 
				Crownwood.Magic.Controls.TabControl.HideTabsModes.HideAlways;

//			FormInit();
		}
        QueryHelper QHS;
        CQueryHelper QHC;
		public void MetaData_AfterLink(){
			this.Meta= MetaData.GetMetaData(this);
			this.Conn=Meta.Conn as Easy_DataAccess;
			Meta.CanInsert=false;
			Meta.CanInsertCopy=false;
			Meta.CanCancel=false;
			Meta.CanSave=false;
            QHC = new CQueryHelper();
            QHS = Conn.GetQueryHelper();
		}
			
		public void MetaData_AfterActivation(){
			CustomTitle= "Configurazione contabile";
			//Selects first tab
			DisplayTabs(0);
		}
		public void MetaData_AfterClear(){
			DisplayTabs(tabController.SelectedIndex);
		}
		public void MetaData_AfterFill(){
			DisplayTabs(tabController.SelectedIndex);
		}
		/// <summary>
		/// Must return true if operation is possible, and do any
		///  operation related to change from tab oldTab to newTab
		/// </summary>
		/// <param name="oldTab"></param>
		/// <param name="newTab"></param>
		/// <returns></returns>
		bool CustomChangeTab(int oldTab, int newTab) {
			if (oldTab==0 && newTab==1){				
				return true;
			}

			if (oldTab==1 && newTab==2){
				SetTabConfiguraEsercizio();
				return true;
			}
			if (oldTab==2 && newTab==3){
				if (labEsercizioFound.Visible==false){
					MessageBox.Show("E' necessario creare l'esercizio.");
					return false;
				}
				SetTabConfiguraEsercizio();
				return true;
			}

			return true;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_accountingyear_confcontabile));
            this.tabController = new Crownwood.Magic.Controls.TabControl();
            this.tabPage5 = new Crownwood.Magic.Controls.TabPage();
            this.label39 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label20 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.btnSetFaseSpesa = new System.Windows.Forms.Button();
            this.btnSetFaseEntrata = new System.Windows.Forms.Button();
            this.label21 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.tabPage1 = new Crownwood.Magic.Controls.TabPage();
            this.label71 = new System.Windows.Forms.Label();
            this.label70 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.tabPage4 = new Crownwood.Magic.Controls.TabPage();
            this.btnInserisciInfoEnte = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.tabPage2 = new Crownwood.Magic.Controls.TabPage();
            this.label32 = new System.Windows.Forms.Label();
            this.gboxEsercizio = new System.Windows.Forms.GroupBox();
            this.btnCreaEsercizio = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.numEsercizio = new System.Windows.Forms.NumericUpDown();
            this.labEsercizioNotFound = new System.Windows.Forms.Label();
            this.labEsercizioFound = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tabPage6 = new Crownwood.Magic.Controls.TabPage();
            this.label33 = new System.Windows.Forms.Label();
            this.btnModificaBilancio = new System.Windows.Forms.Button();
            this.label28 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.btnLeveBilancio = new System.Windows.Forms.Button();
            this.label26 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.tabPage7 = new Crownwood.Magic.Controls.TabPage();
            this.btnCfgSpese = new System.Windows.Forms.Button();
            this.label50 = new System.Windows.Forms.Label();
            this.label49 = new System.Windows.Forms.Label();
            this.label48 = new System.Windows.Forms.Label();
            this.label47 = new System.Windows.Forms.Label();
            this.label46 = new System.Windows.Forms.Label();
            this.label44 = new System.Windows.Forms.Label();
            this.label43 = new System.Windows.Forms.Label();
            this.label42 = new System.Windows.Forms.Label();
            this.label41 = new System.Windows.Forms.Label();
            this.label40 = new System.Windows.Forms.Label();
            this.btnCfgEntrata = new System.Windows.Forms.Button();
            this.label38 = new System.Windows.Forms.Label();
            this.label37 = new System.Windows.Forms.Label();
            this.label36 = new System.Windows.Forms.Label();
            this.label35 = new System.Windows.Forms.Label();
            this.label34 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.tabPage8 = new Crownwood.Magic.Controls.TabPage();
            this.btnCfgBilancio = new System.Windows.Forms.Button();
            this.label53 = new System.Windows.Forms.Label();
            this.label52 = new System.Windows.Forms.Label();
            this.label51 = new System.Windows.Forms.Label();
            this.tabPage9 = new Crownwood.Magic.Controls.TabPage();
            this.btnCfgMissioni = new System.Windows.Forms.Button();
            this.label58 = new System.Windows.Forms.Label();
            this.label57 = new System.Windows.Forms.Label();
            this.label56 = new System.Windows.Forms.Label();
            this.label55 = new System.Windows.Forms.Label();
            this.label54 = new System.Windows.Forms.Label();
            this.tabPage10 = new Crownwood.Magic.Controls.TabPage();
            this.label61 = new System.Windows.Forms.Label();
            this.btnCfgMovBancari = new System.Windows.Forms.Button();
            this.btnCfgIstCassiere = new System.Windows.Forms.Button();
            this.label60 = new System.Windows.Forms.Label();
            this.label59 = new System.Windows.Forms.Label();
            this.tabPage11 = new Crownwood.Magic.Controls.TabPage();
            this.btnCfgBollo = new System.Windows.Forms.Button();
            this.label63 = new System.Windows.Forms.Label();
            this.label62 = new System.Windows.Forms.Label();
            this.tabPage12 = new Crownwood.Magic.Controls.TabPage();
            this.label66 = new System.Windows.Forms.Label();
            this.btnRicompila = new System.Windows.Forms.Button();
            this.label64 = new System.Windows.Forms.Label();
            this.tabPage13 = new Crownwood.Magic.Controls.TabPage();
            this.btnPersonalizzaReport = new System.Windows.Forms.Button();
            this.label69 = new System.Windows.Forms.Label();
            this.label68 = new System.Windows.Forms.Label();
            this.tabPage14 = new Crownwood.Magic.Controls.TabPage();
            this.label72 = new System.Windows.Forms.Label();
            this.tabPage3 = new Crownwood.Magic.Controls.TabPage();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label67 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.DS = new accountingyear_confcontabile.vistaForm();
            this.tabController.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.gboxEsercizio.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numEsercizio)).BeginInit();
            this.tabPage6.SuspendLayout();
            this.tabPage7.SuspendLayout();
            this.tabPage8.SuspendLayout();
            this.tabPage9.SuspendLayout();
            this.tabPage10.SuspendLayout();
            this.tabPage11.SuspendLayout();
            this.tabPage12.SuspendLayout();
            this.tabPage13.SuspendLayout();
            this.tabPage14.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.SuspendLayout();
            // 
            // tabController
            // 
            this.tabController.IDEPixelArea = true;
            this.tabController.Location = new System.Drawing.Point(16, 24);
            this.tabController.Name = "tabController";
            this.tabController.SelectedIndex = 13;
            this.tabController.SelectedTab = this.tabPage3;
            this.tabController.Size = new System.Drawing.Size(704, 560);
            this.tabController.TabIndex = 0;
            this.tabController.TabPages.AddRange(new Crownwood.Magic.Controls.TabPage[] {
            this.tabPage1,
            this.tabPage4,
            this.tabPage2,
            this.tabPage5,
            this.tabPage6,
            this.tabPage7,
            this.tabPage8,
            this.tabPage9,
            this.tabPage10,
            this.tabPage11,
            this.tabPage12,
            this.tabPage13,
            this.tabPage14,
            this.tabPage3});
            this.tabController.SelectionChanged += new System.EventHandler(this.tabController_SelectionChanged);
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.label39);
            this.tabPage5.Controls.Add(this.button1);
            this.tabPage5.Controls.Add(this.label20);
            this.tabPage5.Controls.Add(this.label22);
            this.tabPage5.Controls.Add(this.btnSetFaseSpesa);
            this.tabPage5.Controls.Add(this.btnSetFaseEntrata);
            this.tabPage5.Controls.Add(this.label21);
            this.tabPage5.Controls.Add(this.label19);
            this.tabPage5.Location = new System.Drawing.Point(0, 0);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Selected = false;
            this.tabPage5.Size = new System.Drawing.Size(704, 535);
            this.tabPage5.TabIndex = 7;
            this.tabPage5.Title = "Impostazioni delle fasi di entrata e di spesa";
            // 
            // label39
            // 
            this.label39.Location = new System.Drawing.Point(17, 37);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(572, 38);
            this.label39.TabIndex = 20;
            this.label39.Text = "Per evitare errori di salvataggio Ë necessario compilare inizialmente le regole, " +
    "tuttavia poi andranno nuovamente compilate alla fine della configurazione.";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(239, 78);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(160, 23);
            this.button1.TabIndex = 19;
            this.button1.Text = "Compila Logica di Business";
            this.button1.Click += new System.EventHandler(this.btnRicompila_Click);
            // 
            // label20
            // 
            this.label20.Location = new System.Drawing.Point(17, 245);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(672, 23);
            this.label20.TabIndex = 18;
            this.label20.Text = "Easy non vincola il cliente ad usare un numero di fasi predeterminato, bensÏ si a" +
    "datta al modello contabile di chi lo usa.";
            // 
            // label22
            // 
            this.label22.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World);
            this.label22.Location = new System.Drawing.Point(25, 405);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(664, 48);
            this.label22.TabIndex = 4;
            this.label22.Text = resources.GetString("label22.Text");
            // 
            // btnSetFaseSpesa
            // 
            this.btnSetFaseSpesa.Location = new System.Drawing.Point(385, 357);
            this.btnSetFaseSpesa.Name = "btnSetFaseSpesa";
            this.btnSetFaseSpesa.Size = new System.Drawing.Size(160, 23);
            this.btnSetFaseSpesa.TabIndex = 3;
            this.btnSetFaseSpesa.Text = "Imposta le fasi di spesa";
            this.btnSetFaseSpesa.Click += new System.EventHandler(this.btnSetFaseSpesa_Click);
            // 
            // btnSetFaseEntrata
            // 
            this.btnSetFaseEntrata.Location = new System.Drawing.Point(137, 357);
            this.btnSetFaseEntrata.Name = "btnSetFaseEntrata";
            this.btnSetFaseEntrata.Size = new System.Drawing.Size(160, 23);
            this.btnSetFaseEntrata.TabIndex = 2;
            this.btnSetFaseEntrata.Text = "Imposta le fasi di entrata";
            this.btnSetFaseEntrata.Click += new System.EventHandler(this.btnSetFaseEntrata_Click);
            // 
            // label21
            // 
            this.label21.Location = new System.Drawing.Point(17, 269);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(672, 40);
            this.label21.TabIndex = 1;
            this.label21.Text = "E\' possibile avere una o pi˘ fasi di entrata e/o di spesa. Il mandato Ë inteso co" +
    "me contenitore di \'ultime fasi di spesa\' mentre la reversale Ë intesa come conte" +
    "nitore di \'ultime fasi di entrata\'";
            // 
            // label19
            // 
            this.label19.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World);
            this.label19.Location = new System.Drawing.Point(17, 221);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(456, 23);
            this.label19.TabIndex = 0;
            this.label19.Text = "Impostazione delle fasi contabili di entrata e di spesa";
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label71);
            this.tabPage1.Controls.Add(this.label70);
            this.tabPage1.Controls.Add(this.label30);
            this.tabPage1.Controls.Add(this.label29);
            this.tabPage1.Controls.Add(this.label24);
            this.tabPage1.Controls.Add(this.label23);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.label18);
            this.tabPage1.Controls.Add(this.label17);
            this.tabPage1.Controls.Add(this.label16);
            this.tabPage1.Controls.Add(this.label15);
            this.tabPage1.Controls.Add(this.label14);
            this.tabPage1.Controls.Add(this.label13);
            this.tabPage1.Controls.Add(this.label12);
            this.tabPage1.Location = new System.Drawing.Point(0, 0);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Selected = false;
            this.tabPage1.Size = new System.Drawing.Size(704, 535);
            this.tabPage1.TabIndex = 3;
            this.tabPage1.Title = "Introduzione";
            // 
            // label71
            // 
            this.label71.Location = new System.Drawing.Point(8, 386);
            this.label71.Name = "label71";
            this.label71.Size = new System.Drawing.Size(584, 16);
            this.label71.TabIndex = 37;
            this.label71.Text = "Aggiornamento del menu";
            // 
            // label70
            // 
            this.label70.Location = new System.Drawing.Point(8, 363);
            this.label70.Name = "label70";
            this.label70.Size = new System.Drawing.Size(576, 16);
            this.label70.TabIndex = 36;
            this.label70.Text = "Configurazione delle stampe in base alla gestione del bilancio";
            // 
            // label30
            // 
            this.label30.Location = new System.Drawing.Point(8, 257);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(576, 23);
            this.label30.TabIndex = 35;
            this.label30.Text = "Saranno configurate le missioni";
            // 
            // label29
            // 
            this.label29.Location = new System.Drawing.Point(8, 333);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(576, 23);
            this.label29.TabIndex = 34;
            this.label29.Text = "Configurazione della logica di business in conformit‡ al modello contabile";
            // 
            // label24
            // 
            this.label24.Location = new System.Drawing.Point(8, 227);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(576, 23);
            this.label24.TabIndex = 33;
            this.label24.Text = "Sar‡ configurata la gestione del bilancio";
            // 
            // label23
            // 
            this.label23.Location = new System.Drawing.Point(8, 151);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(576, 23);
            this.label23.TabIndex = 32;
            this.label23.Text = "Saranno configurati i livelli di bilancio";
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World);
            this.label4.Location = new System.Drawing.Point(8, 416);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(576, 23);
            this.label4.TabIndex = 31;
            this.label4.Text = "E\' consigliabile in questa procedura farsi seguire da un esperto contabile che co" +
    "nosca bene Easy.";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World);
            this.label3.Location = new System.Drawing.Point(8, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 23);
            this.label3.TabIndex = 30;
            this.label3.Text = "In particolare:";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World);
            this.label2.Location = new System.Drawing.Point(8, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(680, 23);
            this.label2.TabIndex = 29;
            this.label2.Text = "Questa procedura vi aiuter‡ ad effettuare una corretta configurazione contabile d" +
    "el software Easy";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World);
            this.label1.Location = new System.Drawing.Point(8, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(680, 23);
            this.label1.TabIndex = 28;
            this.label1.Text = "Guida alla configurazione CONTABILE di Easy";
            // 
            // label18
            // 
            this.label18.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label18.Location = new System.Drawing.Point(8, 105);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(576, 16);
            this.label18.TabIndex = 27;
            this.label18.Text = "Sar‡ creato un nuovo esercizio";
            // 
            // label17
            // 
            this.label17.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label17.Location = new System.Drawing.Point(8, 80);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(576, 18);
            this.label17.TabIndex = 26;
            this.label17.Text = "Saranno inserite le informazioni relative all\'ente";
            // 
            // label16
            // 
            this.label16.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label16.Location = new System.Drawing.Point(8, 310);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(576, 16);
            this.label16.TabIndex = 25;
            this.label16.Text = "Sar‡ inserito uno o pi˘ trattamenti bollo";
            // 
            // label15
            // 
            this.label15.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label15.Location = new System.Drawing.Point(8, 287);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(576, 16);
            this.label15.TabIndex = 24;
            this.label15.Text = "Sar‡ inserito un istituto cassiere";
            // 
            // label14
            // 
            this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label14.Location = new System.Drawing.Point(8, 204);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(576, 16);
            this.label14.TabIndex = 23;
            this.label14.Text = "Saranno configurate la gestione dei movimenti di entrata e di spesa";
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label13.Location = new System.Drawing.Point(8, 181);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(576, 16);
            this.label13.TabIndex = 22;
            this.label13.Text = "Sar‡ inserito il bilancio";
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label12.Location = new System.Drawing.Point(8, 128);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(576, 16);
            this.label12.TabIndex = 21;
            this.label12.Text = "Saranno impostate le fasi di entrata e di spesa";
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.btnInserisciInfoEnte);
            this.tabPage4.Controls.Add(this.label11);
            this.tabPage4.Controls.Add(this.label10);
            this.tabPage4.Location = new System.Drawing.Point(0, 0);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Selected = false;
            this.tabPage4.Size = new System.Drawing.Size(704, 535);
            this.tabPage4.TabIndex = 6;
            this.tabPage4.Title = "Informazioni relative all\'ente";
            // 
            // btnInserisciInfoEnte
            // 
            this.btnInserisciInfoEnte.Location = new System.Drawing.Point(264, 72);
            this.btnInserisciInfoEnte.Name = "btnInserisciInfoEnte";
            this.btnInserisciInfoEnte.Size = new System.Drawing.Size(144, 23);
            this.btnInserisciInfoEnte.TabIndex = 2;
            this.btnInserisciInfoEnte.Text = "Inserisci informazioni";
            this.btnInserisciInfoEnte.Click += new System.EventHandler(this.btnInserisciInfoEnte_Click);
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(8, 48);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(552, 23);
            this.label11.TabIndex = 1;
            this.label11.Text = "Se si desidera inserire/aggiornare le informazioni sull\'ente, premere il bottone " +
    "\'Inserisci informazioni\'";
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(8, 16);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(680, 23);
            this.label10.TabIndex = 0;
            this.label10.Text = "Per un funzionamento corretto del software, Ë necessario inserire alcune informaz" +
    "ioni relative all\'ente  (dipartimento/amministrazione).";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label32);
            this.tabPage2.Controls.Add(this.gboxEsercizio);
            this.tabPage2.Controls.Add(this.labEsercizioNotFound);
            this.tabPage2.Controls.Add(this.labEsercizioFound);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Location = new System.Drawing.Point(0, 0);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Selected = false;
            this.tabPage2.Size = new System.Drawing.Size(704, 535);
            this.tabPage2.TabIndex = 4;
            this.tabPage2.Title = "Configurazione esercizio";
            // 
            // label32
            // 
            this.label32.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World);
            this.label32.Location = new System.Drawing.Point(16, 8);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(664, 23);
            this.label32.TabIndex = 9;
            this.label32.Text = "Creazione esercizio contabile";
            // 
            // gboxEsercizio
            // 
            this.gboxEsercizio.Controls.Add(this.btnCreaEsercizio);
            this.gboxEsercizio.Controls.Add(this.label9);
            this.gboxEsercizio.Controls.Add(this.numEsercizio);
            this.gboxEsercizio.Location = new System.Drawing.Point(8, 152);
            this.gboxEsercizio.Name = "gboxEsercizio";
            this.gboxEsercizio.Size = new System.Drawing.Size(672, 64);
            this.gboxEsercizio.TabIndex = 8;
            this.gboxEsercizio.TabStop = false;
            // 
            // btnCreaEsercizio
            // 
            this.btnCreaEsercizio.Location = new System.Drawing.Point(192, 24);
            this.btnCreaEsercizio.Name = "btnCreaEsercizio";
            this.btnCreaEsercizio.Size = new System.Drawing.Size(120, 23);
            this.btnCreaEsercizio.TabIndex = 8;
            this.btnCreaEsercizio.Text = "Crea Esercizio";
            this.btnCreaEsercizio.Click += new System.EventHandler(this.btnCreaEsercizio_Click);
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(8, 24);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(104, 16);
            this.label9.TabIndex = 5;
            this.label9.Text = "Esercizio da creare:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // numEsercizio
            // 
            this.numEsercizio.Location = new System.Drawing.Point(120, 24);
            this.numEsercizio.Maximum = new decimal(new int[] {
            2100,
            0,
            0,
            0});
            this.numEsercizio.Minimum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.numEsercizio.Name = "numEsercizio";
            this.numEsercizio.Size = new System.Drawing.Size(48, 23);
            this.numEsercizio.TabIndex = 7;
            this.numEsercizio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numEsercizio.Value = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            // 
            // labEsercizioNotFound
            // 
            this.labEsercizioNotFound.Location = new System.Drawing.Point(8, 136);
            this.labEsercizioNotFound.Name = "labEsercizioNotFound";
            this.labEsercizioNotFound.Size = new System.Drawing.Size(680, 23);
            this.labEsercizioNotFound.TabIndex = 4;
            this.labEsercizioNotFound.Text = "Non Ë presente alcun esercizio, Ë pertanto necessario crearne uno.";
            // 
            // labEsercizioFound
            // 
            this.labEsercizioFound.Location = new System.Drawing.Point(8, 112);
            this.labEsercizioFound.Name = "labEsercizioFound";
            this.labEsercizioFound.Size = new System.Drawing.Size(680, 23);
            this.labEsercizioFound.TabIndex = 3;
            this.labEsercizioFound.Text = "Sono presenti gli esercizi: xxxx-xxxx pertanto non Ë necessario creare un eserciz" +
    "io.";
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(8, 72);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(672, 23);
            this.label7.TabIndex = 2;
            this.label7.Text = "Se si usa Easy per la prima volta, Ë necessario quindi creare almeno un esercizio" +
    " contabile.";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(8, 56);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(672, 23);
            this.label6.TabIndex = 1;
            this.label6.Text = "Normalmente questa operazione Ë effettuata quando si crea il bilancio di previsio" +
    "ne per l\'anno successivo. ";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(8, 32);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(672, 23);
            this.label5.TabIndex = 0;
            this.label5.Text = "Per poter usare Easy in un determinato esercizio, Ë necessario \'creare\' l\'eserciz" +
    "io contabile.";
            // 
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.label33);
            this.tabPage6.Controls.Add(this.btnModificaBilancio);
            this.tabPage6.Controls.Add(this.label28);
            this.tabPage6.Controls.Add(this.label27);
            this.tabPage6.Controls.Add(this.btnLeveBilancio);
            this.tabPage6.Controls.Add(this.label26);
            this.tabPage6.Controls.Add(this.label25);
            this.tabPage6.Location = new System.Drawing.Point(0, 0);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Selected = false;
            this.tabPage6.Size = new System.Drawing.Size(704, 535);
            this.tabPage6.TabIndex = 8;
            this.tabPage6.Title = "Configurazione bilancio";
            // 
            // label33
            // 
            this.label33.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World);
            this.label33.Location = new System.Drawing.Point(8, 8);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(680, 23);
            this.label33.TabIndex = 6;
            this.label33.Text = "Configurazione del bilancio";
            // 
            // btnModificaBilancio
            // 
            this.btnModificaBilancio.Location = new System.Drawing.Point(264, 200);
            this.btnModificaBilancio.Name = "btnModificaBilancio";
            this.btnModificaBilancio.Size = new System.Drawing.Size(168, 23);
            this.btnModificaBilancio.TabIndex = 5;
            this.btnModificaBilancio.Text = "Modifica bilancio";
            this.btnModificaBilancio.Click += new System.EventHandler(this.btnModificaBilancio_Click);
            // 
            // label28
            // 
            this.label28.Location = new System.Drawing.Point(8, 168);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(672, 23);
            this.label28.TabIndex = 4;
            this.label28.Text = "E\' inoltre possibile, in questa fase ed in qualsiasi momento, aggiungere nuovi ca" +
    "pitoli al bilancio.";
            // 
            // label27
            // 
            this.label27.Location = new System.Drawing.Point(8, 80);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(672, 23);
            this.label27.TabIndex = 3;
            this.label27.Text = "Se si desidera inserire/modificare i livelli di bilancio premere il bottone \'Modi" +
    "fica Livelli bilancio\'";
            // 
            // btnLeveBilancio
            // 
            this.btnLeveBilancio.Location = new System.Drawing.Point(264, 120);
            this.btnLeveBilancio.Name = "btnLeveBilancio";
            this.btnLeveBilancio.Size = new System.Drawing.Size(168, 23);
            this.btnLeveBilancio.TabIndex = 2;
            this.btnLeveBilancio.Text = "Modifica Livelli bilancio";
            this.btnLeveBilancio.Click += new System.EventHandler(this.btnLeveBilancio_Click);
            // 
            // label26
            // 
            this.label26.Location = new System.Drawing.Point(8, 56);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(672, 23);
            this.label26.TabIndex = 1;
            this.label26.Text = "Ossia i livelli di bilancio non sono prefissati.";
            // 
            // label25
            // 
            this.label25.Location = new System.Drawing.Point(8, 32);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(672, 23);
            this.label25.TabIndex = 0;
            this.label25.Text = "E\' possibile con Easy avere, oltre a Titolo/Categoria/Capitolo, anche la gestione" +
    " di articoli e subarticoli ove richiesto.";
            // 
            // tabPage7
            // 
            this.tabPage7.Controls.Add(this.btnCfgSpese);
            this.tabPage7.Controls.Add(this.label50);
            this.tabPage7.Controls.Add(this.label49);
            this.tabPage7.Controls.Add(this.label48);
            this.tabPage7.Controls.Add(this.label47);
            this.tabPage7.Controls.Add(this.label46);
            this.tabPage7.Controls.Add(this.label44);
            this.tabPage7.Controls.Add(this.label43);
            this.tabPage7.Controls.Add(this.label42);
            this.tabPage7.Controls.Add(this.label41);
            this.tabPage7.Controls.Add(this.label40);
            this.tabPage7.Controls.Add(this.btnCfgEntrata);
            this.tabPage7.Controls.Add(this.label38);
            this.tabPage7.Controls.Add(this.label37);
            this.tabPage7.Controls.Add(this.label36);
            this.tabPage7.Controls.Add(this.label35);
            this.tabPage7.Controls.Add(this.label34);
            this.tabPage7.Controls.Add(this.label31);
            this.tabPage7.Location = new System.Drawing.Point(0, 0);
            this.tabPage7.Name = "tabPage7";
            this.tabPage7.Selected = false;
            this.tabPage7.Size = new System.Drawing.Size(704, 535);
            this.tabPage7.TabIndex = 9;
            this.tabPage7.Title = "Configurazione entrate e  spese";
            // 
            // btnCfgSpese
            // 
            this.btnCfgSpese.Location = new System.Drawing.Point(256, 470);
            this.btnCfgSpese.Name = "btnCfgSpese";
            this.btnCfgSpese.Size = new System.Drawing.Size(184, 23);
            this.btnCfgSpese.TabIndex = 19;
            this.btnCfgSpese.Text = "Configura Spese";
            this.btnCfgSpese.Click += new System.EventHandler(this.btnCfgSpese_Click);
            // 
            // label50
            // 
            this.label50.Location = new System.Drawing.Point(16, 424);
            this.label50.Name = "label50";
            this.label50.Size = new System.Drawing.Size(664, 23);
            this.label50.TabIndex = 18;
            this.label50.Text = "La fase di contabilizzazione dei documenti (ordini,missioni,cedolini..)";
            // 
            // label49
            // 
            this.label49.Location = new System.Drawing.Point(16, 401);
            this.label49.Name = "label49";
            this.label49.Size = new System.Drawing.Size(656, 23);
            this.label49.TabIndex = 17;
            this.label49.Text = "- La numerazione degli ordini (manuale/automatica)";
            // 
            // label48
            // 
            this.label48.Location = new System.Drawing.Point(16, 378);
            this.label48.Name = "label48";
            this.label48.Size = new System.Drawing.Size(656, 23);
            this.label48.TabIndex = 16;
            this.label48.Text = "- La data da considerare ai fini della competenza delle ritenute";
            // 
            // label47
            // 
            this.label47.Location = new System.Drawing.Point(16, 355);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(616, 23);
            this.label47.TabIndex = 15;
            this.label47.Text = "- La gestione dei recuperi";
            // 
            // label46
            // 
            this.label46.Location = new System.Drawing.Point(16, 332);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(656, 23);
            this.label46.TabIndex = 14;
            this.label46.Text = "- Il tipo di automatismi da generare per le ritenute";
            // 
            // label44
            // 
            this.label44.Location = new System.Drawing.Point(16, 286);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(672, 23);
            this.label44.TabIndex = 12;
            this.label44.Text = "- Se generare o meno dei mandati ogni qualvolta si creano dei movimenti di entrat" +
    "a automatici";
            // 
            // label43
            // 
            this.label43.Location = new System.Drawing.Point(16, 263);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(384, 23);
            this.label43.TabIndex = 11;
            this.label43.Text = "- Se limitare o meno gli elenchi di trasmissione ad un singolo responsabile";
            // 
            // label42
            // 
            this.label42.Location = new System.Drawing.Point(16, 309);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(656, 23);
            this.label42.TabIndex = 10;
            this.label42.Text = "- Il tipo di automatismi da generare per i contributi";
            this.label42.Click += new System.EventHandler(this.label42_Click);
            // 
            // label41
            // 
            this.label41.Location = new System.Drawing.Point(16, 240);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(448, 23);
            this.label41.TabIndex = 9;
            this.label41.Text = "- Il tipo di raggruppamento usato per comporre i mandati";
            // 
            // label40
            // 
            this.label40.Location = new System.Drawing.Point(16, 216);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(656, 23);
            this.label40.TabIndex = 8;
            this.label40.Text = "Per la parte spese Ë possibile impostare:";
            // 
            // btnCfgEntrata
            // 
            this.btnCfgEntrata.Location = new System.Drawing.Point(256, 164);
            this.btnCfgEntrata.Name = "btnCfgEntrata";
            this.btnCfgEntrata.Size = new System.Drawing.Size(176, 23);
            this.btnCfgEntrata.TabIndex = 7;
            this.btnCfgEntrata.Text = "Configura Entrate";
            this.btnCfgEntrata.Click += new System.EventHandler(this.btnCfgEntrata_Click);
            // 
            // label38
            // 
            this.label38.Location = new System.Drawing.Point(8, 125);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(672, 23);
            this.label38.TabIndex = 5;
            this.label38.Text = "- Se generare o meno delle reversali ogni qualvolta si creano dei movimenti di en" +
    "trata automatici";
            // 
            // label37
            // 
            this.label37.Location = new System.Drawing.Point(8, 102);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(384, 23);
            this.label37.TabIndex = 4;
            this.label37.Text = "- Se limitare o meno gli elenchi di trasmissione ad un singolo responsabile";
            // 
            // label36
            // 
            this.label36.Location = new System.Drawing.Point(8, 79);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(384, 23);
            this.label36.TabIndex = 3;
            this.label36.Text = "- Il tipo di conto (fruttifero/infruttifero)";
            // 
            // label35
            // 
            this.label35.Location = new System.Drawing.Point(8, 56);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(384, 23);
            this.label35.TabIndex = 2;
            this.label35.Text = "- Il tipo di raggruppamento seguito per comporre le reversali";
            // 
            // label34
            // 
            this.label34.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World);
            this.label34.Location = new System.Drawing.Point(8, 8);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(672, 23);
            this.label34.TabIndex = 1;
            this.label34.Text = "Configurazione Entrate e Spese";
            // 
            // label31
            // 
            this.label31.Location = new System.Drawing.Point(8, 32);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(672, 24);
            this.label31.TabIndex = 0;
            this.label31.Text = "Per la parte entrate Ë possibile impostare:";
            // 
            // tabPage8
            // 
            this.tabPage8.Controls.Add(this.btnCfgBilancio);
            this.tabPage8.Controls.Add(this.label53);
            this.tabPage8.Controls.Add(this.label52);
            this.tabPage8.Controls.Add(this.label51);
            this.tabPage8.Location = new System.Drawing.Point(0, 0);
            this.tabPage8.Name = "tabPage8";
            this.tabPage8.Selected = false;
            this.tabPage8.Size = new System.Drawing.Size(704, 535);
            this.tabPage8.TabIndex = 10;
            this.tabPage8.Title = "Configura gestione bilancio";
            // 
            // btnCfgBilancio
            // 
            this.btnCfgBilancio.Location = new System.Drawing.Point(248, 112);
            this.btnCfgBilancio.Name = "btnCfgBilancio";
            this.btnCfgBilancio.Size = new System.Drawing.Size(176, 23);
            this.btnCfgBilancio.TabIndex = 3;
            this.btnCfgBilancio.Text = "Configura gestione Bilancio";
            this.btnCfgBilancio.Click += new System.EventHandler(this.btnCfgBilancio_Click);
            // 
            // label53
            // 
            this.label53.Location = new System.Drawing.Point(8, 64);
            this.label53.Name = "label53";
            this.label53.Size = new System.Drawing.Size(664, 40);
            this.label53.TabIndex = 2;
            this.label53.Text = "E\' possibile anche stabilire quale considerare come fase di \'Impegno\' ai fini del" +
    " consuntivo, e quale considerare come \'pagamento\' ai fini del giornale di cassa." +
    "";
            // 
            // label52
            // 
            this.label52.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World);
            this.label52.Location = new System.Drawing.Point(8, 16);
            this.label52.Name = "label52";
            this.label52.Size = new System.Drawing.Size(288, 23);
            this.label52.TabIndex = 1;
            this.label52.Text = "Gestione del bilancio";
            // 
            // label51
            // 
            this.label51.Location = new System.Drawing.Point(8, 40);
            this.label51.Name = "label51";
            this.label51.Size = new System.Drawing.Size(656, 23);
            this.label51.TabIndex = 0;
            this.label51.Text = "Easy si adatta a qualsiasi gestione si desideri fare del bilancio: cassa/competen" +
    "za/competenza e cassa";
            // 
            // tabPage9
            // 
            this.tabPage9.Controls.Add(this.btnCfgMissioni);
            this.tabPage9.Controls.Add(this.label58);
            this.tabPage9.Controls.Add(this.label57);
            this.tabPage9.Controls.Add(this.label56);
            this.tabPage9.Controls.Add(this.label55);
            this.tabPage9.Controls.Add(this.label54);
            this.tabPage9.Location = new System.Drawing.Point(0, 0);
            this.tabPage9.Name = "tabPage9";
            this.tabPage9.Selected = false;
            this.tabPage9.Size = new System.Drawing.Size(704, 535);
            this.tabPage9.TabIndex = 11;
            this.tabPage9.Title = "Configurazione missioni";
            // 
            // btnCfgMissioni
            // 
            this.btnCfgMissioni.Location = new System.Drawing.Point(264, 144);
            this.btnCfgMissioni.Name = "btnCfgMissioni";
            this.btnCfgMissioni.Size = new System.Drawing.Size(168, 23);
            this.btnCfgMissioni.TabIndex = 5;
            this.btnCfgMissioni.Text = "Configura le missioni";
            this.btnCfgMissioni.Click += new System.EventHandler(this.btnCfgMissioni_Click);
            // 
            // label58
            // 
            this.label58.Location = new System.Drawing.Point(16, 112);
            this.label58.Name = "label58";
            this.label58.Size = new System.Drawing.Size(632, 23);
            this.label58.TabIndex = 4;
            this.label58.Text = "- Se applicare o meno la riduzione della diaria agli anticipi delle missioni";
            // 
            // label57
            // 
            this.label57.Location = new System.Drawing.Point(16, 88);
            this.label57.Name = "label57";
            this.label57.Size = new System.Drawing.Size(632, 23);
            this.label57.TabIndex = 3;
            this.label57.Text = "- il tipo di recupero per  gli anticipi";
            // 
            // label56
            // 
            this.label56.Location = new System.Drawing.Point(16, 64);
            this.label56.Name = "label56";
            this.label56.Size = new System.Drawing.Size(632, 23);
            this.label56.TabIndex = 2;
            this.label56.Text = "- il capitolo delle partite di giro su cui fare eventualmente transitare gli anti" +
    "cipi";
            // 
            // label55
            // 
            this.label55.Location = new System.Drawing.Point(16, 40);
            this.label55.Name = "label55";
            this.label55.Size = new System.Drawing.Size(512, 23);
            this.label55.TabIndex = 1;
            this.label55.Text = "Per un corretto calcolo delle missioni, Ë importante stabilire dei parametri qual" +
    "i:";
            // 
            // label54
            // 
            this.label54.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World);
            this.label54.Location = new System.Drawing.Point(16, 16);
            this.label54.Name = "label54";
            this.label54.Size = new System.Drawing.Size(224, 23);
            this.label54.TabIndex = 0;
            this.label54.Text = "Configurazione missioni";
            // 
            // tabPage10
            // 
            this.tabPage10.Controls.Add(this.label61);
            this.tabPage10.Controls.Add(this.btnCfgMovBancari);
            this.tabPage10.Controls.Add(this.btnCfgIstCassiere);
            this.tabPage10.Controls.Add(this.label60);
            this.tabPage10.Controls.Add(this.label59);
            this.tabPage10.Location = new System.Drawing.Point(0, 0);
            this.tabPage10.Name = "tabPage10";
            this.tabPage10.Selected = false;
            this.tabPage10.Size = new System.Drawing.Size(704, 535);
            this.tabPage10.TabIndex = 12;
            this.tabPage10.Title = "Istituto Cassiere";
            // 
            // label61
            // 
            this.label61.Location = new System.Drawing.Point(16, 120);
            this.label61.Name = "label61";
            this.label61.Size = new System.Drawing.Size(664, 23);
            this.label61.TabIndex = 4;
            this.label61.Text = "Se Ë necessario usare un programma esterno per la trasmissione elettronica, Ë pos" +
    "sibile configurarlo ora.";
            // 
            // btnCfgMovBancari
            // 
            this.btnCfgMovBancari.Location = new System.Drawing.Point(264, 160);
            this.btnCfgMovBancari.Name = "btnCfgMovBancari";
            this.btnCfgMovBancari.Size = new System.Drawing.Size(168, 23);
            this.btnCfgMovBancari.TabIndex = 3;
            this.btnCfgMovBancari.Text = "Configura Movimenti Bancari";
            this.btnCfgMovBancari.Click += new System.EventHandler(this.btnCfgMovBancari_Click);
            // 
            // btnCfgIstCassiere
            // 
            this.btnCfgIstCassiere.Location = new System.Drawing.Point(264, 72);
            this.btnCfgIstCassiere.Name = "btnCfgIstCassiere";
            this.btnCfgIstCassiere.Size = new System.Drawing.Size(168, 23);
            this.btnCfgIstCassiere.TabIndex = 2;
            this.btnCfgIstCassiere.Text = "Configura Istituto Cassiere";
            this.btnCfgIstCassiere.Click += new System.EventHandler(this.btnCfgIstCassiere_Click);
            // 
            // label60
            // 
            this.label60.Location = new System.Drawing.Point(8, 40);
            this.label60.Name = "label60";
            this.label60.Size = new System.Drawing.Size(664, 23);
            this.label60.TabIndex = 1;
            this.label60.Text = "E\' indispensabile, per un corretto funzionamento del programma, creare almeno un " +
    "istituto cassiere.";
            // 
            // label59
            // 
            this.label59.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World);
            this.label59.Location = new System.Drawing.Point(8, 16);
            this.label59.Name = "label59";
            this.label59.Size = new System.Drawing.Size(320, 23);
            this.label59.TabIndex = 0;
            this.label59.Text = "Configurazione dell\'istituto cassiere";
            // 
            // tabPage11
            // 
            this.tabPage11.Controls.Add(this.btnCfgBollo);
            this.tabPage11.Controls.Add(this.label63);
            this.tabPage11.Controls.Add(this.label62);
            this.tabPage11.Location = new System.Drawing.Point(0, 0);
            this.tabPage11.Name = "tabPage11";
            this.tabPage11.Selected = false;
            this.tabPage11.Size = new System.Drawing.Size(704, 535);
            this.tabPage11.TabIndex = 13;
            this.tabPage11.Title = "Trattamento bollo";
            // 
            // btnCfgBollo
            // 
            this.btnCfgBollo.Location = new System.Drawing.Point(272, 80);
            this.btnCfgBollo.Name = "btnCfgBollo";
            this.btnCfgBollo.Size = new System.Drawing.Size(160, 23);
            this.btnCfgBollo.TabIndex = 2;
            this.btnCfgBollo.Text = "Configura trattamento bollo";
            this.btnCfgBollo.Click += new System.EventHandler(this.btnCfgBollo_Click);
            // 
            // label63
            // 
            this.label63.Location = new System.Drawing.Point(16, 48);
            this.label63.Name = "label63";
            this.label63.Size = new System.Drawing.Size(632, 23);
            this.label63.TabIndex = 1;
            this.label63.Text = "E\' importante configurare uno o pi˘ trattamenti bollo da usare per i mandati.";
            // 
            // label62
            // 
            this.label62.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World);
            this.label62.Location = new System.Drawing.Point(16, 24);
            this.label62.Name = "label62";
            this.label62.Size = new System.Drawing.Size(624, 23);
            this.label62.TabIndex = 0;
            this.label62.Text = "Configurazione trattamento bollo";
            // 
            // tabPage12
            // 
            this.tabPage12.Controls.Add(this.label66);
            this.tabPage12.Controls.Add(this.btnRicompila);
            this.tabPage12.Controls.Add(this.label64);
            this.tabPage12.Location = new System.Drawing.Point(0, 0);
            this.tabPage12.Name = "tabPage12";
            this.tabPage12.Selected = false;
            this.tabPage12.Size = new System.Drawing.Size(704, 535);
            this.tabPage12.TabIndex = 14;
            this.tabPage12.Title = "Logica Business";
            // 
            // label66
            // 
            this.label66.Location = new System.Drawing.Point(8, 40);
            this.label66.Name = "label66";
            this.label66.Size = new System.Drawing.Size(656, 40);
            this.label66.TabIndex = 4;
            this.label66.Text = "Al fine rendere effettivi gli adattamenti della logica di business alla propria g" +
    "estione del bilancio, Ë necessario effettuare una ricompilazione delle regole.";
            // 
            // btnRicompila
            // 
            this.btnRicompila.Location = new System.Drawing.Point(248, 88);
            this.btnRicompila.Name = "btnRicompila";
            this.btnRicompila.Size = new System.Drawing.Size(160, 23);
            this.btnRicompila.TabIndex = 3;
            this.btnRicompila.Text = "Ricompila Logica di Business";
            this.btnRicompila.Click += new System.EventHandler(this.btnRicompila_Click);
            // 
            // label64
            // 
            this.label64.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World);
            this.label64.Location = new System.Drawing.Point(8, 8);
            this.label64.Name = "label64";
            this.label64.Size = new System.Drawing.Size(368, 23);
            this.label64.TabIndex = 0;
            this.label64.Text = "Configurazione logica di business";
            // 
            // tabPage13
            // 
            this.tabPage13.Controls.Add(this.btnPersonalizzaReport);
            this.tabPage13.Controls.Add(this.label69);
            this.tabPage13.Controls.Add(this.label68);
            this.tabPage13.Location = new System.Drawing.Point(0, 0);
            this.tabPage13.Name = "tabPage13";
            this.tabPage13.Selected = false;
            this.tabPage13.Size = new System.Drawing.Size(704, 535);
            this.tabPage13.TabIndex = 15;
            this.tabPage13.Title = "Personalizza le stampe";
            // 
            // btnPersonalizzaReport
            // 
            this.btnPersonalizzaReport.Location = new System.Drawing.Point(264, 96);
            this.btnPersonalizzaReport.Name = "btnPersonalizzaReport";
            this.btnPersonalizzaReport.Size = new System.Drawing.Size(136, 23);
            this.btnPersonalizzaReport.TabIndex = 2;
            this.btnPersonalizzaReport.Text = "Personalizza Report";
            this.btnPersonalizzaReport.Click += new System.EventHandler(this.btnPersonalizzaReport_Click);
            // 
            // label69
            // 
            this.label69.Location = new System.Drawing.Point(8, 48);
            this.label69.Name = "label69";
            this.label69.Size = new System.Drawing.Size(680, 23);
            this.label69.TabIndex = 1;
            this.label69.Text = "E\' dunque indispensabile, se non lo si Ë gi‡ fatto, personalizzare i report.";
            // 
            // label68
            // 
            this.label68.Location = new System.Drawing.Point(8, 16);
            this.label68.Name = "label68";
            this.label68.Size = new System.Drawing.Size(680, 32);
            this.label68.TabIndex = 0;
            this.label68.Text = "A seconda della gestione del bilancio (cassa/competenza/competenza e cassa) e del" +
    " n. di fasi di spesa/entrata Ë necessario configurare alcune stampe per ottenere" +
    " dati significativi.  ";
            // 
            // tabPage14
            // 
            this.tabPage14.Controls.Add(this.label72);
            this.tabPage14.Location = new System.Drawing.Point(0, 0);
            this.tabPage14.Name = "tabPage14";
            this.tabPage14.Selected = false;
            this.tabPage14.Size = new System.Drawing.Size(704, 535);
            this.tabPage14.TabIndex = 16;
            this.tabPage14.Title = "Aggiornamento del menu";
            // 
            // label72
            // 
            this.label72.Location = new System.Drawing.Point(16, 16);
            this.label72.Name = "label72";
            this.label72.Size = new System.Drawing.Size(672, 48);
            this.label72.TabIndex = 0;
            this.label72.Text = "Non Ë necessario aggiornare il menu";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.pictureBox1);
            this.tabPage3.Controls.Add(this.label67);
            this.tabPage3.Controls.Add(this.label8);
            this.tabPage3.Location = new System.Drawing.Point(0, 0);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(704, 535);
            this.tabPage3.TabIndex = 5;
            this.tabPage3.Title = "Fine";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(168, 176);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(384, 208);
            this.pictureBox1.TabIndex = 35;
            this.pictureBox1.TabStop = false;
            // 
            // label67
            // 
            this.label67.Location = new System.Drawing.Point(8, 8);
            this.label67.Name = "label67";
            this.label67.Size = new System.Drawing.Size(648, 23);
            this.label67.TabIndex = 34;
            this.label67.Text = "La procedura di configurazione contabile  Ë terminata.";
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World);
            this.label8.Location = new System.Drawing.Point(8, 32);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(664, 23);
            this.label8.TabIndex = 33;
            this.label8.Text = "Ricordarsi di inserire, nell\'anno precedente, l\'avanzo di amministrazione nella s" +
    "ituazione amministrativa effettiva.";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(640, 608);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 16;
            this.btnCancel.Text = "Cancel";
            // 
            // btnNext
            // 
            this.btnNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNext.Location = new System.Drawing.Point(536, 608);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(72, 23);
            this.btnNext.TabIndex = 15;
            this.btnNext.Text = "Avanti >";
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnBack
            // 
            this.btnBack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBack.Location = new System.Drawing.Point(456, 608);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(72, 23);
            this.btnBack.TabIndex = 14;
            this.btnBack.Text = "< Indietro";
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.EnforceConstraints = false;
            this.DS.Locale = new System.Globalization.CultureInfo("en-US");
            // 
            // Frm_accountingyear_confcontabile
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(736, 645);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.tabController);
            this.Name = "Frm_accountingyear_confcontabile";
            this.Text = "FrmInstallContabile";
            this.tabController.ResumeLayout(false);
            this.tabPage5.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.gboxEsercizio.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numEsercizio)).EndInit();
            this.tabPage6.ResumeLayout(false);
            this.tabPage7.ResumeLayout(false);
            this.tabPage8.ResumeLayout(false);
            this.tabPage9.ResumeLayout(false);
            this.tabPage10.ResumeLayout(false);
            this.tabPage11.ResumeLayout(false);
            this.tabPage12.ResumeLayout(false);
            this.tabPage13.ResumeLayout(false);
            this.tabPage14.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion



//		void FormInit() {
        //			CustomTitle="Configurazione contabile di Easy";
//			//Selects first tab
//			DisplayTabs(0);
//		}

		
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
			if (!CustomChangeTab(oldTab,newTab))return;
			if (newTab==tabController.TabPages.Count) {
				DialogResult= DialogResult.OK;
				return;
			}
			DisplayTabs(newTab);
		}

		private void btnNext_Click(object sender, System.EventArgs e) {
			StandardChangeTab(+1);
		}

		private void btnBack_Click(object sender, System.EventArgs e) {
			StandardChangeTab(-1);
		
		}
		#endregion

		public void MetaData_ListFilled(){
			DisplayTabs(0);
		}

		void SetTabConfiguraEsercizio(){
			DataTable Esercizio= Conn.RUN_SELECT("accountingyear","*",null,null,null,null,false);
			if (Esercizio.Rows.Count==0){
				labEsercizioNotFound.Visible=true;
				gboxEsercizio.Visible=true;
				labEsercizioFound.Visible=false;
				numEsercizio.Value= DateTime.Now.Year;
			}
			else {
				labEsercizioNotFound.Visible=false;
				gboxEsercizio.Visible=false;
				labEsercizioFound.Visible=true;
				string labtxt="";
				if (Esercizio.Rows.Count==1){
					int eserc= Convert.ToInt32(Esercizio.Rows[0]["ayear"]);
					labtxt="E' presente l'esercizio "+eserc.ToString()+
						" pertanto non Ë necessario creare un esercizio.";
				}
				else {
					object MIN= Esercizio.Compute("min(ayear)",null);
					object MAX= Esercizio.Compute("max(ayear)",null);
					labtxt= "Sono presenti gli esercizi: "+
							MIN.ToString()+"-"+MAX.ToString()+
						" pertanto non Ë necessario creare un esercizio.";
					labEsercizioFound.Text= labtxt;
				}

			}
		}

		private void btnCreaEsercizio_Click(object sender, System.EventArgs e) {
			DataSet D= new DataSet();

            DataTable Esercizio = Conn.RUN_SELECT("accountingyear", "*", null, null, null, null, false);
            D.Tables.Add(Esercizio);
			DataRow NewE= Esercizio.NewRow();
			NewE["ayear"]= Convert.ToInt32(numEsercizio.Value)-1;
            NewE["flag"] = 54; 
			Esercizio.Rows.Add(NewE);
			
			NewE= Esercizio.NewRow();
			NewE["ayear"]= Convert.ToInt32(numEsercizio.Value);
            NewE["flag"] = 0;
            Esercizio.Rows.Add(NewE);
            DataTable MainEs = Conn.RUN_SELECT("mainaccountingyear", "*", null, null, null, null, false);
            D.Tables.Add(MainEs);

            if (Conn.RUN_SELECT_COUNT("mainaccountingyear", QHS.CmpEq("ayear", Convert.ToInt32(numEsercizio.Value)-1), false) == 0) {
                DataRow NewM = MainEs.NewRow();
                NewM["ayear"] = Convert.ToInt32(numEsercizio.Value) - 1;
                NewM["completed"] = 'S';
                NewM["ct"] = DateTime.Now;
                NewM["cu"] = Conn.GetSys("userdb").ToString();
                NewM["lt"] = DateTime.Now;
                NewM["lu"] = Conn.GetSys("userdb").ToString();
                MainEs.Rows.Add(NewM);
            }

            if (Conn.RUN_SELECT_COUNT("mainaccountingyear", QHS.CmpEq("ayear", Convert.ToInt32(numEsercizio.Value)), false) == 0) {
                DataRow NewM = MainEs.NewRow();
                NewM["ayear"] = Convert.ToInt32(numEsercizio.Value);
                NewM["completed"] = 'N';
                NewM["ct"] = DateTime.Now;
                NewM["cu"] = Conn.GetSys("userdb").ToString();
                NewM["lt"] = DateTime.Now;
                NewM["lu"] = Conn.GetSys("userdb").ToString();
                MainEs.Rows.Add(NewM);
            }

            if (Conn.RUN_SELECT_COUNT("commonconfig", QHS.CmpEq("ayear", Convert.ToInt32(numEsercizio.Value)), false) == 0) {
                DataTable Common = Conn.RUN_SELECT("commonconfig", "*", null, null, null, null, false);
                D.Tables.Add(Common);
                DataRow NewC = Common.NewRow();
                NewC["ayear"] = Convert.ToInt32(numEsercizio.Value);
                NewC["unifiedfinlevel"] = 2;
                NewC["lt"] = DateTime.Now;
                NewC["lu"] = Conn.GetSys("userdb").ToString();
                Common.Rows.Add(NewC);
            }

          
            

			Easy_PostData CP= new Easy_PostData();
			CP.InitClass(D,Conn);
			if (CP.DO_POST())SetTabConfiguraEsercizio();
			Conn.SetSys("esercizio",Convert.ToInt32(numEsercizio.Value));
			Conn.RecalcUserEnvironment();

		}

		private void btnInserisciInfoEnte_Click(object sender, System.EventArgs e) {
			MetaDataDispatcher MD = Meta.Dispatcher;
			MD.Edit(this,"license","default",true,null);
		}

		private void btnSetFaseEntrata_Click(object sender, System.EventArgs e) {
			MetaDataDispatcher MD = Meta.Dispatcher;
			MD.Edit(this,"incomephase","default",true,null);
			Conn.RecalcUserEnvironment();
			
		}

		private void btnSetFaseSpesa_Click(object sender, System.EventArgs e) {
			MetaDataDispatcher MD = Meta.Dispatcher;
			MD.Edit(this,"expensephase","default",true,null);
			Conn.RecalcUserEnvironment();
		}

		private void btnLeveBilancio_Click(object sender, System.EventArgs e) {
			MetaDataDispatcher MD = Meta.Dispatcher;
			MD.Edit(this,"finlevel","default",true,null);		
			Conn.RecalcUserEnvironment();
		}

		private void btnModificaBilancio_Click(object sender, System.EventArgs e) {
			MetaDataDispatcher MD = Meta.Dispatcher;
			MD.Edit(this,"fin","default",true,null);				
		}

		private void label42_Click(object sender, System.EventArgs e) {
		
		}

		private void btnCfgSpese_Click(object sender, System.EventArgs e) {
			MetaDataDispatcher MD = Meta.Dispatcher;
			MD.Edit(this,"config","default",true,null);				
			Conn.RecalcUserEnvironment();
		}

		private void btnCfgEntrata_Click(object sender, System.EventArgs e) {
			MetaDataDispatcher MD = Meta.Dispatcher;
            MD.Edit(this, "config", "default", true, null);				
			Conn.RecalcUserEnvironment();		
		}

		private void btnCfgBilancio_Click(object sender, System.EventArgs e) {
			MetaDataDispatcher MD = Meta.Dispatcher;
            MD.Edit(this, "config", "default", true, null);				
			Conn.RecalcUserEnvironment();				
		}

		private void btnCfgMissioni_Click(object sender, System.EventArgs e) {
			MetaDataDispatcher MD = Meta.Dispatcher;
            MD.Edit(this, "config", "default", true, null);				
			Conn.RecalcUserEnvironment();						
		}

		private void tabController_SelectionChanged(object sender, System.EventArgs e) {
		
		}

		private void btnCfgIstCassiere_Click(object sender, System.EventArgs e) {
			MetaDataDispatcher MD = Meta.Dispatcher;
			MD.Edit(this,"treasurer","default",true,null);				
		
		}

		private void btnCfgMovBancari_Click(object sender, System.EventArgs e) {
			MetaDataDispatcher MD = Meta.Dispatcher;
            MD.Edit(this, "config", "default", true, null);				
		
		}

		private void btnCfgBollo_Click(object sender, System.EventArgs e) {
			MetaDataDispatcher MD = Meta.Dispatcher;
			MD.Edit(this,"stamphandling","lista",true,null);						
		}

		



		private void btnRicompila_Click(object sender, System.EventArgs e) {
			MetaDataDispatcher MD = Meta.Dispatcher;
			MD.Edit(this,"auditparameter","recalc",true,null);
		}

		private void btnPersonalizzaReport_Click(object sender, System.EventArgs e) {
			try {
				StringBuilder SB = Download.LeggiTestoScript("persreport.sql");
				Download.RUN_SCRIPT(Conn,SB,"Personalizzazione reports");
			}
			catch (Exception E) {
				QueryCreator.ShowException("Errore nella personalizzazione report.",E);
			}

		}

		//void ReadMenuFromXML(bool ClearExistent,bool Replace,
		//	string FileName,DataAccess ConnClone){

		//	if (ConnClone==null) return;
		//	DataSet DS;
		//	dbanalyzer.ImportTableFromXML(FileName, out DS);
		//	dbanalyzer.WriteDataTableToDB(DS.Tables[0], ConnClone, ClearExistent, Replace, null);
		//}

		




	}
}
