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
using System.Data;
using metadatalibrary;
using funzioni_configurazione;//funzioni_configurazione

namespace expense_wizardlinkexptoinc {//spesawizardelimina//
	/// <summary>
	/// Summary description for FrmSpesaWizardElimina.
	/// </summary>
	public class Frm_expense_wizardlinkexptoinc : System.Windows.Forms.Form {
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnNext;
		private System.Windows.Forms.Button btnBack;
		private Crownwood.Magic.Controls.TabPage tabIntro;
		private Crownwood.Magic.Controls.TabPage tabSelectExpense;
		private Crownwood.Magic.Controls.TabPage tabShow;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.GroupBox gboxMovimento;
        private System.Windows.Forms.TextBox txtNmovExpense;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox txtYmovExpense;
		private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblFaseMovimento;
		private System.Windows.Forms.Label label6;
		public vistaForm DS;
		DataAccess Conn;
		string CustomTitle;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label10;
		private Crownwood.Magic.Controls.TabControl txtNumIncome;
		private System.Windows.Forms.Button btnSelectMov;
		private System.Windows.Forms.GroupBox groupBox20;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.TextBox txtAdateExpense;
		private System.Windows.Forms.TextBox txtExpirationExpense;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.GroupBox groupBox18;
		private System.Windows.Forms.TextBox SubEntity_txtOriginalExpense;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.GroupBox groupBox17;
		private System.Windows.Forms.TextBox txtDescrExpense;
		private System.Windows.Forms.GroupBox gboxBilAnnuale;
		private System.Windows.Forms.TextBox txtCodefinExpense;
		private System.Windows.Forms.TextBox txtFinExpense;
		private System.Windows.Forms.GroupBox groupCredDeb;
		private System.Windows.Forms.TextBox txtRegistryExpense;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label lblImportoDisponibile;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.TextBox txtAvailableExpense;
		private System.Windows.Forms.TextBox txtCurrentExpense;
		private System.Windows.Forms.Label label9;
		private System.ComponentModel.IContainer components;
		private System.Windows.Forms.DataGrid grdEntrata;
        private System.Windows.Forms.DataGrid grdSpesa;
		private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.GroupBox groupBox16;
        private System.Windows.Forms.GroupBox gboxUPB;
        private System.Windows.Forms.TextBox txtDescrUPBExpense;
        private Crownwood.Magic.Controls.TabPage tabSelectIncome;
        private Crownwood.Magic.Controls.TabPage tabPage1;
        private GroupBox groupBox2;
        private GroupBox groupBox3;
        private TextBox txtDescrUpbIncome;
        private GroupBox groupBox4;
        private Label label14;
        private TextBox txtAdateIncome;
        private Label label16;
        private GroupBox groupBox5;
        private TextBox SubEntity_txtOriginalIncome;
        private Label label17;
        private GroupBox groupBox6;
        private TextBox txtDescrIncome;
        private GroupBox groupBox7;
        private Label label19;
        private TextBox txtCodefinIncome;
        private TextBox txtFinIncome;
        private GroupBox groupBox8;
        private TextBox txtRegistryIncome;
        private GroupBox groupBox9;
        private Label label20;
        private Label label21;
        private TextBox txtAvailableIncome;
        private TextBox txtCurrentIncome;
        private Label label22;
        private GroupBox groupBox10;
        private Button btnSelectIncome;
        private TextBox txtNmovIncome;
        private Label label23;
        private TextBox txtYmovIncome;
        private Label label24;
        private Label label25;
        private TextBox txtExpirationIncome;
        private GroupBox groupBox11;
        private TextBox SubEntity_txtNumMandato;
        private Label label28;
        private GroupBox groupBox12;
        private TextBox SubEntity_txtNumReversale;
        private Label label26;
        private TextBox txtFaseEntrata;
        private TextBox txtFaseSpesa;
        private TextBox txtResponsabile;
        private Label label18;
        private TextBox txtUPB;
        private TextBox txtManagerIncome;
        private TextBox txtUPBIncome;
        private Label label27;
		public MetaData Meta;

		public Frm_expense_wizardlinkexptoinc() {
			InitializeComponent();

			txtNumIncome.HideTabsMode = 
				Crownwood.Magic.Controls.TabControl.HideTabsModes.HideAlways;
		}

		public void MetaData_AfterActivation(){
			CustomTitle= "Vincolo tra Pagamento e Incasso";
			//Selects first tab
			DisplayTabs(0);
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing ) {
			if( disposing ) {
				if(components != null) {
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}


        CQueryHelper QHC;
        QueryHelper QHS;
        public void MetaData_AfterLink () {
            Meta = MetaData.GetMetaData(this);
            Conn = Meta.Conn;
            Meta.CanInsert = false;
            Meta.CanSave = false;
            Meta.SearchEnabled = false;
            QHS = Conn.GetQueryHelper();
            QHC = new CQueryHelper();
            GetData.CacheTable(DS.incomephase, QHS.CmpEq("nphase", Meta.GetSys("maxincomephase")), null, false);
            GetData.CacheTable(DS.expensephase, QHS.CmpEq("nphase", Meta.GetSys("maxexpensephase")), null, false);
            DataAccess.SetTableForReading(DS.manager_income, "manager");
            string filteresercizio = QHC.CmpEq("ayear", Meta.GetSys("esercizio"));
            GetData.CacheTable(DS.manager, null, "title", true);
            GetData.CacheTable(DS.manager_income, null, "title", true);
            txtYmovExpense.Text = Meta.GetSys("esercizio").ToString();
            txtYmovIncome.Text = Meta.GetSys("esercizio").ToString();
            object descrPhaseIncome = Conn.DO_READ_VALUE("incomephase", QHS.CmpEq("nphase", Meta.GetSys("maxincomephase")), "description");
            object descrPhaseExpense = Conn.DO_READ_VALUE("expensephase", QHS.CmpEq("nphase", Meta.GetSys("maxexpensephase")), "description");
            txtFaseEntrata.Text = descrPhaseIncome.ToString();
            txtFaseSpesa.Text = descrPhaseExpense.ToString();
        }

		public void MetaData_AfterClear(){
			DisplayTabs(txtNumIncome.SelectedIndex);
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_expense_wizardlinkexptoinc));
            this.DS = new expense_wizardlinkexptoinc.vistaForm();
            this.txtNumIncome = new Crownwood.Magic.Controls.TabControl();
            this.tabSelectExpense = new Crownwood.Magic.Controls.TabPage();
            this.groupBox11 = new System.Windows.Forms.GroupBox();
            this.SubEntity_txtNumMandato = new System.Windows.Forms.TextBox();
            this.label28 = new System.Windows.Forms.Label();
            this.groupBox16 = new System.Windows.Forms.GroupBox();
            this.txtResponsabile = new System.Windows.Forms.TextBox();
            this.gboxUPB = new System.Windows.Forms.GroupBox();
            this.label18 = new System.Windows.Forms.Label();
            this.txtUPB = new System.Windows.Forms.TextBox();
            this.txtDescrUPBExpense = new System.Windows.Forms.TextBox();
            this.groupBox20 = new System.Windows.Forms.GroupBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtAdateExpense = new System.Windows.Forms.TextBox();
            this.txtExpirationExpense = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.groupBox17 = new System.Windows.Forms.GroupBox();
            this.txtDescrExpense = new System.Windows.Forms.TextBox();
            this.groupCredDeb = new System.Windows.Forms.GroupBox();
            this.txtRegistryExpense = new System.Windows.Forms.TextBox();
            this.groupBox18 = new System.Windows.Forms.GroupBox();
            this.SubEntity_txtOriginalExpense = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.gboxBilAnnuale = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.txtCodefinExpense = new System.Windows.Forms.TextBox();
            this.txtFinExpense = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblImportoDisponibile = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtAvailableExpense = new System.Windows.Forms.TextBox();
            this.txtCurrentExpense = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.gboxMovimento = new System.Windows.Forms.GroupBox();
            this.txtFaseSpesa = new System.Windows.Forms.TextBox();
            this.btnSelectMov = new System.Windows.Forms.Button();
            this.txtNmovExpense = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtYmovExpense = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lblFaseMovimento = new System.Windows.Forms.Label();
            this.tabIntro = new Crownwood.Magic.Controls.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabSelectIncome = new Crownwood.Magic.Controls.TabPage();
            this.tabPage1 = new Crownwood.Magic.Controls.TabPage();
            this.groupBox12 = new System.Windows.Forms.GroupBox();
            this.SubEntity_txtNumReversale = new System.Windows.Forms.TextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtManagerIncome = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtUPBIncome = new System.Windows.Forms.TextBox();
            this.label27 = new System.Windows.Forms.Label();
            this.txtDescrUpbIncome = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtAdateIncome = new System.Windows.Forms.TextBox();
            this.txtExpirationIncome = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.SubEntity_txtOriginalIncome = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.txtDescrIncome = new System.Windows.Forms.TextBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.label19 = new System.Windows.Forms.Label();
            this.txtCodefinIncome = new System.Windows.Forms.TextBox();
            this.txtFinIncome = new System.Windows.Forms.TextBox();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.txtRegistryIncome = new System.Windows.Forms.TextBox();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.txtAvailableIncome = new System.Windows.Forms.TextBox();
            this.txtCurrentIncome = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.txtFaseEntrata = new System.Windows.Forms.TextBox();
            this.btnSelectIncome = new System.Windows.Forms.Button();
            this.txtNmovIncome = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.txtYmovIncome = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.tabShow = new Crownwood.Magic.Controls.TabPage();
            this.label10 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.grdEntrata = new System.Windows.Forms.DataGrid();
            this.grdSpesa = new System.Windows.Forms.DataGrid();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.txtNumIncome.SuspendLayout();
            this.tabSelectExpense.SuspendLayout();
            this.groupBox11.SuspendLayout();
            this.groupBox16.SuspendLayout();
            this.gboxUPB.SuspendLayout();
            this.groupBox20.SuspendLayout();
            this.groupBox17.SuspendLayout();
            this.groupCredDeb.SuspendLayout();
            this.groupBox18.SuspendLayout();
            this.gboxBilAnnuale.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.gboxMovimento.SuspendLayout();
            this.tabIntro.SuspendLayout();
            this.tabSelectIncome.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox12.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.groupBox10.SuspendLayout();
            this.tabShow.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdEntrata)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdSpesa)).BeginInit();
            this.SuspendLayout();
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.EnforceConstraints = false;
            this.DS.Locale = new System.Globalization.CultureInfo("en-US");
            // 
            // txtNumIncome
            // 
            this.txtNumIncome.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNumIncome.IDEPixelArea = true;
            this.txtNumIncome.Location = new System.Drawing.Point(8, 9);
            this.txtNumIncome.Name = "txtNumIncome";
            this.txtNumIncome.SelectedIndex = 2;
            this.txtNumIncome.SelectedTab = this.tabSelectIncome;
            this.txtNumIncome.Size = new System.Drawing.Size(704, 471);
            this.txtNumIncome.TabIndex = 4;
            this.txtNumIncome.TabPages.AddRange(new Crownwood.Magic.Controls.TabPage[] {
            this.tabIntro,
            this.tabSelectExpense,
            this.tabSelectIncome,
            this.tabShow});
            this.txtNumIncome.SelectionChanged += new System.EventHandler(this.txtNumIncome_SelectionChanged);
            // 
            // tabSelectExpense
            // 
            this.tabSelectExpense.Controls.Add(this.groupBox11);
            this.tabSelectExpense.Controls.Add(this.groupBox16);
            this.tabSelectExpense.Controls.Add(this.gboxUPB);
            this.tabSelectExpense.Controls.Add(this.groupBox20);
            this.tabSelectExpense.Controls.Add(this.groupBox17);
            this.tabSelectExpense.Controls.Add(this.gboxBilAnnuale);
            this.tabSelectExpense.Controls.Add(this.groupBox1);
            this.tabSelectExpense.Controls.Add(this.label6);
            this.tabSelectExpense.Controls.Add(this.gboxMovimento);
            this.tabSelectExpense.Location = new System.Drawing.Point(0, 0);
            this.tabSelectExpense.Name = "tabSelectExpense";
            this.tabSelectExpense.Selected = false;
            this.tabSelectExpense.Size = new System.Drawing.Size(704, 446);
            this.tabSelectExpense.TabIndex = 4;
            this.tabSelectExpense.Title = "Pagina 2 di 4";
            // 
            // groupBox11
            // 
            this.groupBox11.Controls.Add(this.SubEntity_txtNumMandato);
            this.groupBox11.Controls.Add(this.label28);
            this.groupBox11.Location = new System.Drawing.Point(360, 170);
            this.groupBox11.Name = "groupBox11";
            this.groupBox11.Size = new System.Drawing.Size(160, 51);
            this.groupBox11.TabIndex = 93;
            this.groupBox11.TabStop = false;
            this.groupBox11.Text = "Mandato di pagamento";
            // 
            // SubEntity_txtNumMandato
            // 
            this.SubEntity_txtNumMandato.Location = new System.Drawing.Point(75, 20);
            this.SubEntity_txtNumMandato.Name = "SubEntity_txtNumMandato";
            this.SubEntity_txtNumMandato.ReadOnly = true;
            this.SubEntity_txtNumMandato.Size = new System.Drawing.Size(64, 23);
            this.SubEntity_txtNumMandato.TabIndex = 2;
            this.SubEntity_txtNumMandato.Tag = "";
            // 
            // label28
            // 
            this.label28.Location = new System.Drawing.Point(21, 24);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(48, 16);
            this.label28.TabIndex = 13;
            this.label28.Text = "Numero:";
            this.label28.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBox16
            // 
            this.groupBox16.Controls.Add(this.txtResponsabile);
            this.groupBox16.Location = new System.Drawing.Point(8, 251);
            this.groupBox16.Name = "groupBox16";
            this.groupBox16.Size = new System.Drawing.Size(344, 40);
            this.groupBox16.TabIndex = 92;
            this.groupBox16.TabStop = false;
            this.groupBox16.Text = "Responsabile";
            // 
            // txtResponsabile
            // 
            this.txtResponsabile.Location = new System.Drawing.Point(5, 13);
            this.txtResponsabile.Name = "txtResponsabile";
            this.txtResponsabile.ReadOnly = true;
            this.txtResponsabile.Size = new System.Drawing.Size(334, 23);
            this.txtResponsabile.TabIndex = 0;
            // 
            // gboxUPB
            // 
            this.gboxUPB.Controls.Add(this.label18);
            this.gboxUPB.Controls.Add(this.txtUPB);
            this.gboxUPB.Controls.Add(this.txtDescrUPBExpense);
            this.gboxUPB.Location = new System.Drawing.Point(8, 127);
            this.gboxUPB.Name = "gboxUPB";
            this.gboxUPB.Size = new System.Drawing.Size(344, 118);
            this.gboxUPB.TabIndex = 91;
            this.gboxUPB.TabStop = false;
            this.gboxUPB.Tag = "";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(8, 71);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(29, 15);
            this.label18.TabIndex = 6;
            this.label18.Text = "UPB";
            // 
            // txtUPB
            // 
            this.txtUPB.Location = new System.Drawing.Point(5, 91);
            this.txtUPB.Name = "txtUPB";
            this.txtUPB.ReadOnly = true;
            this.txtUPB.Size = new System.Drawing.Size(334, 23);
            this.txtUPB.TabIndex = 5;
            // 
            // txtDescrUPBExpense
            // 
            this.txtDescrUPBExpense.Location = new System.Drawing.Point(82, 20);
            this.txtDescrUPBExpense.Multiline = true;
            this.txtDescrUPBExpense.Name = "txtDescrUPBExpense";
            this.txtDescrUPBExpense.ReadOnly = true;
            this.txtDescrUPBExpense.Size = new System.Drawing.Size(254, 63);
            this.txtDescrUPBExpense.TabIndex = 4;
            this.txtDescrUPBExpense.TabStop = false;
            this.txtDescrUPBExpense.Tag = "upb.title";
            // 
            // groupBox20
            // 
            this.groupBox20.Controls.Add(this.label15);
            this.groupBox20.Controls.Add(this.txtAdateExpense);
            this.groupBox20.Controls.Add(this.txtExpirationExpense);
            this.groupBox20.Controls.Add(this.label13);
            this.groupBox20.Location = new System.Drawing.Point(8, 382);
            this.groupBox20.Name = "groupBox20";
            this.groupBox20.Size = new System.Drawing.Size(344, 40);
            this.groupBox20.TabIndex = 18;
            this.groupBox20.TabStop = false;
            this.groupBox20.Text = "Data";
            // 
            // label15
            // 
            this.label15.Location = new System.Drawing.Point(2, 16);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(56, 20);
            this.label15.TabIndex = 0;
            this.label15.Text = "Contabile";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtAdateExpense
            // 
            this.txtAdateExpense.Location = new System.Drawing.Point(67, 15);
            this.txtAdateExpense.Name = "txtAdateExpense";
            this.txtAdateExpense.ReadOnly = true;
            this.txtAdateExpense.Size = new System.Drawing.Size(72, 23);
            this.txtAdateExpense.TabIndex = 1;
            this.txtAdateExpense.Tag = "";
            this.txtAdateExpense.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtExpirationExpense
            // 
            this.txtExpirationExpense.Location = new System.Drawing.Point(264, 16);
            this.txtExpirationExpense.Name = "txtExpirationExpense";
            this.txtExpirationExpense.ReadOnly = true;
            this.txtExpirationExpense.Size = new System.Drawing.Size(72, 23);
            this.txtExpirationExpense.TabIndex = 2;
            this.txtExpirationExpense.Tag = "";
            this.txtExpirationExpense.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label13
            // 
            this.label13.Location = new System.Drawing.Point(192, 14);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(64, 20);
            this.label13.TabIndex = 0;
            this.label13.Text = "Scadenza:";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBox17
            // 
            this.groupBox17.Controls.Add(this.txtDescrExpense);
            this.groupBox17.Controls.Add(this.groupCredDeb);
            this.groupBox17.Controls.Add(this.groupBox18);
            this.groupBox17.Location = new System.Drawing.Point(360, 42);
            this.groupBox17.Name = "groupBox17";
            this.groupBox17.Size = new System.Drawing.Size(344, 80);
            this.groupBox17.TabIndex = 15;
            this.groupBox17.TabStop = false;
            this.groupBox17.Text = "Descrizione";
            // 
            // txtDescrExpense
            // 
            this.txtDescrExpense.Location = new System.Drawing.Point(8, 16);
            this.txtDescrExpense.Multiline = true;
            this.txtDescrExpense.Name = "txtDescrExpense";
            this.txtDescrExpense.ReadOnly = true;
            this.txtDescrExpense.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDescrExpense.Size = new System.Drawing.Size(328, 58);
            this.txtDescrExpense.TabIndex = 1;
            this.txtDescrExpense.Tag = "";
            // 
            // groupCredDeb
            // 
            this.groupCredDeb.Controls.Add(this.txtRegistryExpense);
            this.groupCredDeb.Location = new System.Drawing.Point(4, 86);
            this.groupCredDeb.Name = "groupCredDeb";
            this.groupCredDeb.Size = new System.Drawing.Size(344, 40);
            this.groupCredDeb.TabIndex = 14;
            this.groupCredDeb.TabStop = false;
            this.groupCredDeb.Tag = "";
            this.groupCredDeb.Text = "Percipiente";
            // 
            // txtRegistryExpense
            // 
            this.txtRegistryExpense.Location = new System.Drawing.Point(8, 16);
            this.txtRegistryExpense.Name = "txtRegistryExpense";
            this.txtRegistryExpense.ReadOnly = true;
            this.txtRegistryExpense.Size = new System.Drawing.Size(326, 23);
            this.txtRegistryExpense.TabIndex = 1;
            this.txtRegistryExpense.Tag = "";
            // 
            // groupBox18
            // 
            this.groupBox18.Controls.Add(this.SubEntity_txtOriginalExpense);
            this.groupBox18.Controls.Add(this.label11);
            this.groupBox18.Location = new System.Drawing.Point(-348, 87);
            this.groupBox18.Name = "groupBox18";
            this.groupBox18.Size = new System.Drawing.Size(344, 40);
            this.groupBox18.TabIndex = 17;
            this.groupBox18.TabStop = false;
            this.groupBox18.Text = "Importo";
            // 
            // SubEntity_txtOriginalExpense
            // 
            this.SubEntity_txtOriginalExpense.Location = new System.Drawing.Point(225, 12);
            this.SubEntity_txtOriginalExpense.Name = "SubEntity_txtOriginalExpense";
            this.SubEntity_txtOriginalExpense.ReadOnly = true;
            this.SubEntity_txtOriginalExpense.Size = new System.Drawing.Size(112, 23);
            this.SubEntity_txtOriginalExpense.TabIndex = 1;
            this.SubEntity_txtOriginalExpense.Tag = "";
            this.SubEntity_txtOriginalExpense.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(8, 12);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(56, 20);
            this.label11.TabIndex = 0;
            this.label11.Text = "Originale:";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // gboxBilAnnuale
            // 
            this.gboxBilAnnuale.Controls.Add(this.label9);
            this.gboxBilAnnuale.Controls.Add(this.txtCodefinExpense);
            this.gboxBilAnnuale.Controls.Add(this.txtFinExpense);
            this.gboxBilAnnuale.Location = new System.Drawing.Point(8, 289);
            this.gboxBilAnnuale.Name = "gboxBilAnnuale";
            this.gboxBilAnnuale.Size = new System.Drawing.Size(344, 93);
            this.gboxBilAnnuale.TabIndex = 12;
            this.gboxBilAnnuale.TabStop = false;
            this.gboxBilAnnuale.Tag = "";
            // 
            // label9
            // 
            this.label9.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label9.ImageIndex = 0;
            this.label9.ImageList = this.imageList1;
            this.label9.Location = new System.Drawing.Point(8, 42);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 18);
            this.label9.TabIndex = 3;
            this.label9.Text = "Bilancio";
            this.label9.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "");
            // 
            // txtCodefinExpense
            // 
            this.txtCodefinExpense.Location = new System.Drawing.Point(7, 66);
            this.txtCodefinExpense.Name = "txtCodefinExpense";
            this.txtCodefinExpense.ReadOnly = true;
            this.txtCodefinExpense.Size = new System.Drawing.Size(332, 23);
            this.txtCodefinExpense.TabIndex = 1;
            this.txtCodefinExpense.Tag = "";
            this.txtCodefinExpense.TextChanged += new System.EventHandler(this.txtCodefinExpense_TextChanged);
            // 
            // txtFinExpense
            // 
            this.txtFinExpense.Location = new System.Drawing.Point(94, 8);
            this.txtFinExpense.Multiline = true;
            this.txtFinExpense.Name = "txtFinExpense";
            this.txtFinExpense.ReadOnly = true;
            this.txtFinExpense.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtFinExpense.Size = new System.Drawing.Size(245, 52);
            this.txtFinExpense.TabIndex = 2;
            this.txtFinExpense.TabStop = false;
            this.txtFinExpense.Tag = "";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblImportoDisponibile);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.txtAvailableExpense);
            this.groupBox1.Controls.Add(this.txtCurrentExpense);
            this.groupBox1.Location = new System.Drawing.Point(360, 358);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(336, 64);
            this.groupBox1.TabIndex = 19;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Situazione riassuntiva importo del movimento";
            // 
            // lblImportoDisponibile
            // 
            this.lblImportoDisponibile.Location = new System.Drawing.Point(8, 40);
            this.lblImportoDisponibile.Name = "lblImportoDisponibile";
            this.lblImportoDisponibile.Size = new System.Drawing.Size(192, 20);
            this.lblImportoDisponibile.TabIndex = 0;
            this.lblImportoDisponibile.Text = "Disponibile:";
            this.lblImportoDisponibile.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(8, 12);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(200, 24);
            this.label12.TabIndex = 0;
            this.label12.Text = "Attuale (comprensivo delle variazioni):";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtAvailableExpense
            // 
            this.txtAvailableExpense.Location = new System.Drawing.Point(227, 40);
            this.txtAvailableExpense.Name = "txtAvailableExpense";
            this.txtAvailableExpense.ReadOnly = true;
            this.txtAvailableExpense.Size = new System.Drawing.Size(96, 23);
            this.txtAvailableExpense.TabIndex = 0;
            this.txtAvailableExpense.TabStop = false;
            this.txtAvailableExpense.Tag = "";
            this.txtAvailableExpense.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtCurrentExpense
            // 
            this.txtCurrentExpense.Location = new System.Drawing.Point(227, 16);
            this.txtCurrentExpense.Name = "txtCurrentExpense";
            this.txtCurrentExpense.ReadOnly = true;
            this.txtCurrentExpense.Size = new System.Drawing.Size(96, 23);
            this.txtCurrentExpense.TabIndex = 0;
            this.txtCurrentExpense.TabStop = false;
            this.txtCurrentExpense.Tag = "";
            this.txtCurrentExpense.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(16, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(416, 23);
            this.label6.TabIndex = 2;
            this.label6.Text = "Selezionare il movimento di spesa tra quelli non trasmessi";
            // 
            // gboxMovimento
            // 
            this.gboxMovimento.Controls.Add(this.txtFaseSpesa);
            this.gboxMovimento.Controls.Add(this.btnSelectMov);
            this.gboxMovimento.Controls.Add(this.txtNmovExpense);
            this.gboxMovimento.Controls.Add(this.label4);
            this.gboxMovimento.Controls.Add(this.txtYmovExpense);
            this.gboxMovimento.Controls.Add(this.label5);
            this.gboxMovimento.Controls.Add(this.lblFaseMovimento);
            this.gboxMovimento.Location = new System.Drawing.Point(8, 42);
            this.gboxMovimento.Name = "gboxMovimento";
            this.gboxMovimento.Size = new System.Drawing.Size(344, 80);
            this.gboxMovimento.TabIndex = 1;
            this.gboxMovimento.TabStop = false;
            this.gboxMovimento.Tag = "";
            this.gboxMovimento.Text = "Movimento";
            // 
            // txtFaseSpesa
            // 
            this.txtFaseSpesa.Location = new System.Drawing.Point(155, 18);
            this.txtFaseSpesa.Name = "txtFaseSpesa";
            this.txtFaseSpesa.ReadOnly = true;
            this.txtFaseSpesa.Size = new System.Drawing.Size(182, 23);
            this.txtFaseSpesa.TabIndex = 6;
            this.txtFaseSpesa.Tag = "";
            // 
            // btnSelectMov
            // 
            this.btnSelectMov.Location = new System.Drawing.Point(16, 15);
            this.btnSelectMov.Name = "btnSelectMov";
            this.btnSelectMov.Size = new System.Drawing.Size(83, 23);
            this.btnSelectMov.TabIndex = 4;
            this.btnSelectMov.Tag = "";
            this.btnSelectMov.Text = "Seleziona";
            this.btnSelectMov.Click += new System.EventHandler(this.btnSelectMov_Click);
            // 
            // txtNmovExpense
            // 
            this.txtNmovExpense.Location = new System.Drawing.Point(155, 49);
            this.txtNmovExpense.Name = "txtNmovExpense";
            this.txtNmovExpense.Size = new System.Drawing.Size(48, 23);
            this.txtNmovExpense.TabIndex = 3;
            this.txtNmovExpense.Tag = "";
            this.txtNmovExpense.Leave += new System.EventHandler(this.txtNmovExpense_Leave);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(102, 49);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 20);
            this.label4.TabIndex = 0;
            this.label4.Text = "Num.";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtYmovExpense
            // 
            this.txtYmovExpense.Location = new System.Drawing.Point(52, 49);
            this.txtYmovExpense.Name = "txtYmovExpense";
            this.txtYmovExpense.Size = new System.Drawing.Size(47, 23);
            this.txtYmovExpense.TabIndex = 2;
            this.txtYmovExpense.Tag = "";
            this.txtYmovExpense.Leave += new System.EventHandler(this.txtYmovExpense_Leave);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(12, 49);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 20);
            this.label5.TabIndex = 0;
            this.label5.Text = "Eserc.";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblFaseMovimento
            // 
            this.lblFaseMovimento.Location = new System.Drawing.Point(117, 20);
            this.lblFaseMovimento.Name = "lblFaseMovimento";
            this.lblFaseMovimento.Size = new System.Drawing.Size(32, 20);
            this.lblFaseMovimento.TabIndex = 0;
            this.lblFaseMovimento.Text = "Fase";
            this.lblFaseMovimento.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tabIntro
            // 
            this.tabIntro.Controls.Add(this.label3);
            this.tabIntro.Controls.Add(this.label2);
            this.tabIntro.Controls.Add(this.label1);
            this.tabIntro.Location = new System.Drawing.Point(0, 0);
            this.tabIntro.Name = "tabIntro";
            this.tabIntro.Selected = false;
            this.tabIntro.Size = new System.Drawing.Size(704, 446);
            this.tabIntro.TabIndex = 3;
            this.tabIntro.Title = "Pagina 1 di 4";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.Location = new System.Drawing.Point(8, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(688, 37);
            this.label3.TabIndex = 6;
            this.label3.Text = "Nel secondo passo vi verranno mostrati tutti i movimenti di entrata non ancora tr" +
    "asmessi che sono stati trovati e vi sarà chiesta conferma di voler procedere nel" +
    "l\'operazione.";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.Location = new System.Drawing.Point(8, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(688, 32);
            this.label2.TabIndex = 5;
            this.label2.Text = " Nel primo passo vi verrà richiesto di selezionare un pagamento tra quelli non an" +
    "cora trasmessi";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Location = new System.Drawing.Point(8, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(688, 48);
            this.label1.TabIndex = 4;
            this.label1.Text = "Questo Wizard serve a collegare un incasso ad un pagamento";
            // 
            // tabSelectIncome
            // 
            this.tabSelectIncome.Controls.Add(this.tabPage1);
            this.tabSelectIncome.Location = new System.Drawing.Point(0, 0);
            this.tabSelectIncome.Name = "tabSelectIncome";
            this.tabSelectIncome.Size = new System.Drawing.Size(704, 446);
            this.tabSelectIncome.TabIndex = 6;
            this.tabSelectIncome.Title = "Pagina 3 di 4";
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox12);
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.groupBox3);
            this.tabPage1.Controls.Add(this.groupBox4);
            this.tabPage1.Controls.Add(this.groupBox5);
            this.tabPage1.Controls.Add(this.groupBox6);
            this.tabPage1.Controls.Add(this.groupBox7);
            this.tabPage1.Controls.Add(this.groupBox8);
            this.tabPage1.Controls.Add(this.groupBox9);
            this.tabPage1.Controls.Add(this.label22);
            this.tabPage1.Controls.Add(this.groupBox10);
            this.tabPage1.Location = new System.Drawing.Point(0, -2);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Selected = false;
            this.tabPage1.Size = new System.Drawing.Size(704, 445);
            this.tabPage1.TabIndex = 5;
            this.tabPage1.Title = "Pagina 2 di 4";
            // 
            // groupBox12
            // 
            this.groupBox12.Controls.Add(this.SubEntity_txtNumReversale);
            this.groupBox12.Controls.Add(this.label26);
            this.groupBox12.Location = new System.Drawing.Point(360, 152);
            this.groupBox12.Name = "groupBox12";
            this.groupBox12.Size = new System.Drawing.Size(160, 56);
            this.groupBox12.TabIndex = 94;
            this.groupBox12.TabStop = false;
            this.groupBox12.Text = "Reversale di incasso";
            // 
            // SubEntity_txtNumReversale
            // 
            this.SubEntity_txtNumReversale.Location = new System.Drawing.Point(75, 20);
            this.SubEntity_txtNumReversale.Name = "SubEntity_txtNumReversale";
            this.SubEntity_txtNumReversale.ReadOnly = true;
            this.SubEntity_txtNumReversale.Size = new System.Drawing.Size(64, 23);
            this.SubEntity_txtNumReversale.TabIndex = 2;
            this.SubEntity_txtNumReversale.Tag = "";
            // 
            // label26
            // 
            this.label26.Location = new System.Drawing.Point(21, 24);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(48, 16);
            this.label26.TabIndex = 13;
            this.label26.Text = "Numero:";
            this.label26.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtManagerIncome);
            this.groupBox2.Location = new System.Drawing.Point(8, 256);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(344, 40);
            this.groupBox2.TabIndex = 92;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Responsabile";
            // 
            // txtManagerIncome
            // 
            this.txtManagerIncome.Location = new System.Drawing.Point(4, 13);
            this.txtManagerIncome.Name = "txtManagerIncome";
            this.txtManagerIncome.ReadOnly = true;
            this.txtManagerIncome.Size = new System.Drawing.Size(334, 23);
            this.txtManagerIncome.TabIndex = 1;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtUPBIncome);
            this.groupBox3.Controls.Add(this.label27);
            this.groupBox3.Controls.Add(this.txtDescrUpbIncome);
            this.groupBox3.Location = new System.Drawing.Point(8, 157);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(344, 93);
            this.groupBox3.TabIndex = 91;
            this.groupBox3.TabStop = false;
            this.groupBox3.Tag = "";
            // 
            // txtUPBIncome
            // 
            this.txtUPBIncome.Location = new System.Drawing.Point(5, 66);
            this.txtUPBIncome.Name = "txtUPBIncome";
            this.txtUPBIncome.ReadOnly = true;
            this.txtUPBIncome.Size = new System.Drawing.Size(334, 23);
            this.txtUPBIncome.TabIndex = 6;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(12, 50);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(29, 15);
            this.label27.TabIndex = 5;
            this.label27.Text = "UPB";
            // 
            // txtDescrUpbIncome
            // 
            this.txtDescrUpbIncome.Location = new System.Drawing.Point(79, 8);
            this.txtDescrUpbIncome.Multiline = true;
            this.txtDescrUpbIncome.Name = "txtDescrUpbIncome";
            this.txtDescrUpbIncome.ReadOnly = true;
            this.txtDescrUpbIncome.Size = new System.Drawing.Size(257, 52);
            this.txtDescrUpbIncome.TabIndex = 4;
            this.txtDescrUpbIncome.TabStop = false;
            this.txtDescrUpbIncome.Tag = "";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label14);
            this.groupBox4.Controls.Add(this.txtAdateIncome);
            this.groupBox4.Controls.Add(this.txtExpirationIncome);
            this.groupBox4.Controls.Add(this.label16);
            this.groupBox4.Location = new System.Drawing.Point(8, 392);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(344, 40);
            this.groupBox4.TabIndex = 18;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Data";
            // 
            // label14
            // 
            this.label14.Location = new System.Drawing.Point(2, 16);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(56, 20);
            this.label14.TabIndex = 0;
            this.label14.Text = "Contabile";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtAdateIncome
            // 
            this.txtAdateIncome.Location = new System.Drawing.Point(67, 15);
            this.txtAdateIncome.Name = "txtAdateIncome";
            this.txtAdateIncome.ReadOnly = true;
            this.txtAdateIncome.Size = new System.Drawing.Size(72, 23);
            this.txtAdateIncome.TabIndex = 1;
            this.txtAdateIncome.Tag = "";
            this.txtAdateIncome.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtExpirationIncome
            // 
            this.txtExpirationIncome.Location = new System.Drawing.Point(264, 16);
            this.txtExpirationIncome.Name = "txtExpirationIncome";
            this.txtExpirationIncome.ReadOnly = true;
            this.txtExpirationIncome.Size = new System.Drawing.Size(72, 23);
            this.txtExpirationIncome.TabIndex = 2;
            this.txtExpirationIncome.Tag = "";
            this.txtExpirationIncome.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label16
            // 
            this.label16.Location = new System.Drawing.Point(192, 14);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(64, 20);
            this.label16.TabIndex = 0;
            this.label16.Text = "Scadenza:";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.SubEntity_txtOriginalIncome);
            this.groupBox5.Controls.Add(this.label17);
            this.groupBox5.Location = new System.Drawing.Point(4, 118);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(344, 40);
            this.groupBox5.TabIndex = 17;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Importo";
            // 
            // SubEntity_txtOriginalIncome
            // 
            this.SubEntity_txtOriginalIncome.Location = new System.Drawing.Point(225, 12);
            this.SubEntity_txtOriginalIncome.Name = "SubEntity_txtOriginalIncome";
            this.SubEntity_txtOriginalIncome.ReadOnly = true;
            this.SubEntity_txtOriginalIncome.Size = new System.Drawing.Size(112, 23);
            this.SubEntity_txtOriginalIncome.TabIndex = 1;
            this.SubEntity_txtOriginalIncome.Tag = "";
            this.SubEntity_txtOriginalIncome.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label17
            // 
            this.label17.Location = new System.Drawing.Point(8, 12);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(56, 20);
            this.label17.TabIndex = 0;
            this.label17.Text = "Originale:";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.txtDescrIncome);
            this.groupBox6.Location = new System.Drawing.Point(360, 32);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(344, 80);
            this.groupBox6.TabIndex = 15;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Descrizione";
            // 
            // txtDescrIncome
            // 
            this.txtDescrIncome.Location = new System.Drawing.Point(8, 16);
            this.txtDescrIncome.Multiline = true;
            this.txtDescrIncome.Name = "txtDescrIncome";
            this.txtDescrIncome.ReadOnly = true;
            this.txtDescrIncome.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDescrIncome.Size = new System.Drawing.Size(328, 48);
            this.txtDescrIncome.TabIndex = 1;
            this.txtDescrIncome.Tag = "";
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.label19);
            this.groupBox7.Controls.Add(this.txtCodefinIncome);
            this.groupBox7.Controls.Add(this.txtFinIncome);
            this.groupBox7.Location = new System.Drawing.Point(8, 294);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(344, 92);
            this.groupBox7.TabIndex = 12;
            this.groupBox7.TabStop = false;
            this.groupBox7.Tag = "";
            // 
            // label19
            // 
            this.label19.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label19.ImageIndex = 0;
            this.label19.ImageList = this.imageList1;
            this.label19.Location = new System.Drawing.Point(8, 35);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(65, 18);
            this.label19.TabIndex = 3;
            this.label19.Text = "Bilancio";
            this.label19.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtCodefinIncome
            // 
            this.txtCodefinIncome.Location = new System.Drawing.Point(4, 65);
            this.txtCodefinIncome.Name = "txtCodefinIncome";
            this.txtCodefinIncome.ReadOnly = true;
            this.txtCodefinIncome.Size = new System.Drawing.Size(332, 23);
            this.txtCodefinIncome.TabIndex = 1;
            this.txtCodefinIncome.Tag = "";
            // 
            // txtFinIncome
            // 
            this.txtFinIncome.Location = new System.Drawing.Point(79, 8);
            this.txtFinIncome.Multiline = true;
            this.txtFinIncome.Name = "txtFinIncome";
            this.txtFinIncome.ReadOnly = true;
            this.txtFinIncome.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtFinIncome.Size = new System.Drawing.Size(260, 45);
            this.txtFinIncome.TabIndex = 2;
            this.txtFinIncome.TabStop = false;
            this.txtFinIncome.Tag = "";
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.txtRegistryIncome);
            this.groupBox8.Location = new System.Drawing.Point(360, 112);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(344, 40);
            this.groupBox8.TabIndex = 14;
            this.groupBox8.TabStop = false;
            this.groupBox8.Tag = "";
            this.groupBox8.Text = "Percipiente";
            // 
            // txtRegistryIncome
            // 
            this.txtRegistryIncome.Location = new System.Drawing.Point(8, 16);
            this.txtRegistryIncome.Name = "txtRegistryIncome";
            this.txtRegistryIncome.ReadOnly = true;
            this.txtRegistryIncome.Size = new System.Drawing.Size(326, 23);
            this.txtRegistryIncome.TabIndex = 1;
            this.txtRegistryIncome.Tag = "";
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.label20);
            this.groupBox9.Controls.Add(this.label21);
            this.groupBox9.Controls.Add(this.txtAvailableIncome);
            this.groupBox9.Controls.Add(this.txtCurrentIncome);
            this.groupBox9.Location = new System.Drawing.Point(358, 368);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(336, 64);
            this.groupBox9.TabIndex = 19;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "Situazione riassuntiva importo del movimento";
            // 
            // label20
            // 
            this.label20.Location = new System.Drawing.Point(8, 40);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(192, 20);
            this.label20.TabIndex = 0;
            this.label20.Text = "Disponibile:";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label21
            // 
            this.label21.Location = new System.Drawing.Point(8, 12);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(200, 24);
            this.label21.TabIndex = 0;
            this.label21.Text = "Attuale (comprensivo delle variazioni):";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtAvailableIncome
            // 
            this.txtAvailableIncome.Location = new System.Drawing.Point(227, 40);
            this.txtAvailableIncome.Name = "txtAvailableIncome";
            this.txtAvailableIncome.ReadOnly = true;
            this.txtAvailableIncome.Size = new System.Drawing.Size(96, 23);
            this.txtAvailableIncome.TabIndex = 0;
            this.txtAvailableIncome.TabStop = false;
            this.txtAvailableIncome.Tag = "";
            this.txtAvailableIncome.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtCurrentIncome
            // 
            this.txtCurrentIncome.Location = new System.Drawing.Point(227, 16);
            this.txtCurrentIncome.Name = "txtCurrentIncome";
            this.txtCurrentIncome.ReadOnly = true;
            this.txtCurrentIncome.Size = new System.Drawing.Size(96, 23);
            this.txtCurrentIncome.TabIndex = 0;
            this.txtCurrentIncome.TabStop = false;
            this.txtCurrentIncome.Tag = "";
            this.txtCurrentIncome.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label22
            // 
            this.label22.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(9, 6);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(416, 23);
            this.label22.TabIndex = 2;
            this.label22.Text = "Selezionare il movimento di entrata tra quelli non trasmessi";
            // 
            // groupBox10
            // 
            this.groupBox10.Controls.Add(this.txtFaseEntrata);
            this.groupBox10.Controls.Add(this.btnSelectIncome);
            this.groupBox10.Controls.Add(this.txtNmovIncome);
            this.groupBox10.Controls.Add(this.label23);
            this.groupBox10.Controls.Add(this.txtYmovIncome);
            this.groupBox10.Controls.Add(this.label24);
            this.groupBox10.Controls.Add(this.label25);
            this.groupBox10.Location = new System.Drawing.Point(8, 32);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(344, 80);
            this.groupBox10.TabIndex = 1;
            this.groupBox10.TabStop = false;
            this.groupBox10.Tag = "";
            this.groupBox10.Text = "Movimento";
            // 
            // txtFaseEntrata
            // 
            this.txtFaseEntrata.Location = new System.Drawing.Point(140, 19);
            this.txtFaseEntrata.Name = "txtFaseEntrata";
            this.txtFaseEntrata.ReadOnly = true;
            this.txtFaseEntrata.Size = new System.Drawing.Size(196, 23);
            this.txtFaseEntrata.TabIndex = 5;
            this.txtFaseEntrata.Tag = "";
            // 
            // btnSelectIncome
            // 
            this.btnSelectIncome.Location = new System.Drawing.Point(15, 17);
            this.btnSelectIncome.Name = "btnSelectIncome";
            this.btnSelectIncome.Size = new System.Drawing.Size(82, 23);
            this.btnSelectIncome.TabIndex = 4;
            this.btnSelectIncome.Tag = "";
            this.btnSelectIncome.Text = "Seleziona";
            this.btnSelectIncome.Click += new System.EventHandler(this.btnSelectIncome_Click);
            // 
            // txtNmovIncome
            // 
            this.txtNmovIncome.Location = new System.Drawing.Point(172, 48);
            this.txtNmovIncome.Name = "txtNmovIncome";
            this.txtNmovIncome.Size = new System.Drawing.Size(48, 23);
            this.txtNmovIncome.TabIndex = 3;
            this.txtNmovIncome.Tag = "";
            this.txtNmovIncome.Leave += new System.EventHandler(this.txtNmovIncome_Leave);
            // 
            // label23
            // 
            this.label23.Location = new System.Drawing.Point(102, 49);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(64, 20);
            this.label23.TabIndex = 0;
            this.label23.Text = "Num.";
            this.label23.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtYmovIncome
            // 
            this.txtYmovIncome.Location = new System.Drawing.Point(58, 46);
            this.txtYmovIncome.Name = "txtYmovIncome";
            this.txtYmovIncome.Size = new System.Drawing.Size(39, 23);
            this.txtYmovIncome.TabIndex = 2;
            this.txtYmovIncome.Tag = "";
            this.txtYmovIncome.Leave += new System.EventHandler(this.txtYmovIncome_Leave);
            // 
            // label24
            // 
            this.label24.Location = new System.Drawing.Point(12, 49);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(40, 20);
            this.label24.TabIndex = 0;
            this.label24.Text = "Eserc.";
            this.label24.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label25
            // 
            this.label25.Location = new System.Drawing.Point(102, 19);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(32, 20);
            this.label25.TabIndex = 0;
            this.label25.Text = "Fase";
            this.label25.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tabShow
            // 
            this.tabShow.Controls.Add(this.label10);
            this.tabShow.Controls.Add(this.label8);
            this.tabShow.Controls.Add(this.label7);
            this.tabShow.Controls.Add(this.grdEntrata);
            this.tabShow.Controls.Add(this.grdSpesa);
            this.tabShow.Location = new System.Drawing.Point(0, 0);
            this.tabShow.Name = "tabShow";
            this.tabShow.Selected = false;
            this.tabShow.Size = new System.Drawing.Size(704, 446);
            this.tabShow.TabIndex = 5;
            this.tabShow.Title = "Pagina 4 di 4";
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label10.Location = new System.Drawing.Point(8, 263);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(128, 16);
            this.label10.TabIndex = 5;
            this.label10.Text = "Movimenti di entrata";
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(8, 8);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(352, 23);
            this.label8.TabIndex = 3;
            this.label8.Text = "I movimenti selezionati sono i seguenti:";
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(8, 32);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(112, 16);
            this.label7.TabIndex = 2;
            this.label7.Text = "Movimenti di spesa";
            // 
            // grdEntrata
            // 
            this.grdEntrata.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdEntrata.DataMember = "";
            this.grdEntrata.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.grdEntrata.Location = new System.Drawing.Point(8, 282);
            this.grdEntrata.Name = "grdEntrata";
            this.grdEntrata.Size = new System.Drawing.Size(688, 144);
            this.grdEntrata.TabIndex = 1;
            this.grdEntrata.Tag = "incomelastview.default";
            // 
            // grdSpesa
            // 
            this.grdSpesa.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdSpesa.DataMember = "";
            this.grdSpesa.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.grdSpesa.Location = new System.Drawing.Point(8, 48);
            this.grdSpesa.Name = "grdSpesa";
            this.grdSpesa.Size = new System.Drawing.Size(688, 212);
            this.grdSpesa.TabIndex = 0;
            this.grdSpesa.Tag = "expenselastview.default";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(633, 486);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Tag = "maincancel";
            this.btnCancel.Text = "Cancel";
            // 
            // btnNext
            // 
            this.btnNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNext.Location = new System.Drawing.Point(513, 486);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(88, 23);
            this.btnNext.TabIndex = 6;
            this.btnNext.Text = "Avanti >";
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnBack
            // 
            this.btnBack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBack.Location = new System.Drawing.Point(425, 486);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(80, 23);
            this.btnBack.TabIndex = 5;
            this.btnBack.Text = "< Indietro";
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // Frm_expense_wizardlinkexptoinc
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(720, 512);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.txtNumIncome);
            this.Name = "Frm_expense_wizardlinkexptoinc";
            this.Text = "Vincolo tra Pagamento e Incasso";
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.txtNumIncome.ResumeLayout(false);
            this.tabSelectExpense.ResumeLayout(false);
            this.groupBox11.ResumeLayout(false);
            this.groupBox11.PerformLayout();
            this.groupBox16.ResumeLayout(false);
            this.groupBox16.PerformLayout();
            this.gboxUPB.ResumeLayout(false);
            this.gboxUPB.PerformLayout();
            this.groupBox20.ResumeLayout(false);
            this.groupBox20.PerformLayout();
            this.groupBox17.ResumeLayout(false);
            this.groupBox17.PerformLayout();
            this.groupCredDeb.ResumeLayout(false);
            this.groupCredDeb.PerformLayout();
            this.groupBox18.ResumeLayout(false);
            this.groupBox18.PerformLayout();
            this.gboxBilAnnuale.ResumeLayout(false);
            this.gboxBilAnnuale.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gboxMovimento.ResumeLayout(false);
            this.gboxMovimento.PerformLayout();
            this.tabIntro.ResumeLayout(false);
            this.tabSelectIncome.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox12.ResumeLayout(false);
            this.groupBox12.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            this.groupBox10.ResumeLayout(false);
            this.groupBox10.PerformLayout();
            this.tabShow.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdEntrata)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdSpesa)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

	

	

		/// <summary>
		/// Displays tab n. NewTab and updates buttons
		/// </summary>
		/// <param name="newTab"></param>
		void DisplayTabs(int newTab){
			txtNumIncome.SelectedIndex= newTab;
			//Evaluates Buttons Appearance
			btnBack.Visible=(newTab>0);
			if (newTab== txtNumIncome.TabPages.Count-1)
				btnNext.Text="Associa.";
			else
				btnNext.Text="Next >";
			Text = CustomTitle+ " (Pagina "+(newTab+1)+" di "+txtNumIncome.TabPages.Count+")";
		}
		void StandardChangeTab(int step){
			int oldTab= txtNumIncome.SelectedIndex;
			int newTab= oldTab+step;
			if ((newTab<0)||(newTab>txtNumIncome.TabPages.Count))return;
			if (!CustomChangeTab(oldTab,newTab))return;
			if (newTab==txtNumIncome.TabPages.Count){
                if (MessageBox.Show(this, "Si desidera eseguire ancora la procedura",
                    "Conferma", MessageBoxButtons.YesNo) == DialogResult.Yes) {
                    newTab = 1;
                    ResetWizard();
                }
                else {
                    DialogResult = DialogResult.OK;
                    Close();
                    return;
                }
            }

            if ((oldTab == 4) && (newTab == 3)) {
                newTab = 1;
                ResetWizard();
            }
            DisplayTabs(newTab);
        }


        void ResetWizard() {

            if ((DS.expense.Rows.Count > 0) && (DS.income.Rows.Count > 0)) {
                grdSpesa.DataSource = null;
                grdEntrata.DataSource = null;
                DS.expensephase.Clear();
                DS.expenseyear.Clear();
                DS.incomephase.Clear();
                DS.incomeyear.Clear();
                ClearExpense();
                ClearIncome();
            }

        }

        private void btnBack_Click(object sender, System.EventArgs e) {
			StandardChangeTab(-1);
		}


		private void btnNext_Click(object sender, System.EventArgs e) {
			StandardChangeTab(+1);
		}

		bool CustomChangeTab(int oldTab, int newTab){
			if (oldTab==0) 	{
				return true ; // 0->1: nothing to do
			}
     		if ((oldTab==1)&&(newTab==0))return true; //1->0:nothing to do!
			if ((oldTab==1)&&(newTab==2))return GetExpense();
            if ((oldTab == 2) && (newTab == 3)) return GetIncome();
            if ((oldTab == 3) && (newTab == 4)) return doAssocia(); 
			return true;
		}

		bool GetExpense(){
			if (txtNmovExpense.Text.Trim()==""){
				MessageBox.Show("Selezionare un movimento di spesa per procedere");
				return false;
			}
            string filter = GetFilterExpense(true);
			MetaData MFase = MetaData.GetMetaData(this,"expense");
			MFase.FilterLocked=true;
			MFase.DS=DS.Copy();
			
			DataRow MyDR = MFase.SelectOne("default",filter,null,null);
			if (MyDR==null) return false;
            AddAllCollegate(MyDR);

			return true;
		}


        bool GetIncome () {
            if (txtNmovIncome.Text.Trim() == "") {
                MessageBox.Show("Selezionare un movimento di entrata per procedere");
                return false;
            }
            string filter = GetFilterIncome(true);
            MetaData MFase = MetaData.GetMetaData(this, "income");
            MFase.FilterLocked = true;
            MFase.DS = DS.Copy();

            DataRow MyDR = MFase.SelectOne("default", filter, null, null);
            if (MyDR == null) return false;
            AddAllCollegate(MyDR);

            return true;
        }

		string GetFilterExpense(bool IsNumMov){
            string MyFilter = QHS.CmpEq("ayear", Meta.GetSys("esercizio"));
            MyFilter = QHS.CmpEq("nphase", Meta.GetSys("maxexpensephase"));
            MyFilter = QHS.AppAnd(MyFilter, QHS.CmpEq("ayear", Meta.GetSys("esercizio")));
            if (txtYmovExpense.Text.Trim() != "")
                MyFilter = QHS.AppAnd(MyFilter, QHS.CmpEq("ymov", txtYmovExpense.Text.Trim()));

            if ((IsNumMov) &&(txtNmovExpense.Text.Trim() != ""))
                MyFilter = QHS.AppAnd(MyFilter, QHS.CmpEq("nmov", txtNmovExpense.Text.Trim()));

            MyFilter = QHS.AppAnd(MyFilter, QHS.IsNull("npaymenttransmission"));
            //DataTable ExpenseTax = Meta.Conn.RUN_SELECT("expensetax","idexp",null, QHS.CmpEq("ayear",Meta.GetSys("esercizio")),null,true);
            //string lista = QHC.DistinctVal(ExpenseTax.Select(), "idexp");
            //MyFilter = QHS.AppAnd(MyFilter, QHS.Not(QHS.FieldInList("idexp", lista)));            
            MyFilter = QHS.AppAnd(MyFilter, "(idexp not in (select idexp from expensetax where " + 
                                    QHS.CmpEq("ayear", Meta.GetSys("esercizio")) + "))");

            bool IsAdmin = false;
            if (Meta.GetSys("manage_prestazioni") != null)
                IsAdmin = (Meta.GetSys("manage_prestazioni").ToString() == "S");

		    if (!IsAdmin) {
		        string autokind = "REFPS";
		        object idAutokind = Conn.DO_READ_VALUE("autokind", QHS.CmpEq("code", autokind), "idautokind");
		        MyFilter = QHS.AppAnd(MyFilter, QHS.NullOrEq("autokind",idAutokind));
		    }

		    return MyFilter;
		}

        string GetFilterIncome (bool IsNumMov) {
            string MyFilter = QHS.CmpEq("ayear", Meta.GetSys("esercizio"));
            MyFilter = QHS.CmpEq("nphase", Meta.GetSys("maxincomephase"));
            MyFilter = QHS.AppAnd(MyFilter, QHS.CmpEq("ayear", Meta.GetSys("esercizio")));

            if (txtYmovIncome.Text.Trim() != "")
                MyFilter = QHS.AppAnd(MyFilter, QHS.CmpEq("ymov", txtYmovIncome.Text.Trim()));

            if ((IsNumMov) && (txtNmovIncome.Text.Trim() != ""))
                MyFilter = QHS.AppAnd(MyFilter, QHS.CmpEq("nmov", txtNmovIncome.Text.Trim()));
            // Non deve essere trasmesso
            MyFilter = QHS.AppAnd(MyFilter, QHS.IsNull("nproceedstransmission"));
            // Non deve essere associato come automatismo a un altro pagamento
            MyFilter = QHS.AppAnd(MyFilter, QHS.IsNull("idpayment"));

            bool IsAdmin = false;
            if (Meta.GetSys("manage_prestazioni") != null)
                IsAdmin = (Meta.GetSys("manage_prestazioni").ToString() == "S");

            if (!IsAdmin)
                MyFilter = QHS.AppAnd(MyFilter, "(autokind is null)");


            // Aggiungo il fitro sullo stesso creditore di spesa: non è necessario che l'anagrafica sia la stessa
            //DataRow CurrExpense = DS.expense.Rows[0];
            //MyFilter = QHS.AppAnd(MyFilter, QHS.CmpEq("idreg", CurrExpense["idreg"]));

            return MyFilter;
        }

		private void btnSelectMov_Click(object sender, System.EventArgs e) {
			string MyFilter; 
			
			if (((Control)sender).Name == "txtNmovExpense")
				MyFilter = GetFilterExpense(true);
			else
                MyFilter = GetFilterExpense(false);

			MetaData MFase = MetaData.GetMetaData(this,"expense");
			MFase.FilterLocked=true;
			MFase.DS=DS;
			
			DataRow MyDR = MFase.SelectOne("default",MyFilter,null,null);
			
			if(MyDR == null) {
				if (Meta.InsertMode){
					if (typeof(TextBox).IsAssignableFrom(sender.GetType())){
						if (((TextBox)sender).Text.Trim()!="")	((TextBox)sender).Focus();
					}
				}
				return;
			}
            txtFaseSpesa.Text = MyDR["phase"].ToString();
            txtYmovExpense.Text = MyDR["ymov"].ToString();
			txtNmovExpense.Text=MyDR["nmov"].ToString();
			txtRegistryExpense.Text= MyDR["registry"].ToString();
			txtDescrExpense.Text= MyDR["description"].ToString();
			SubEntity_txtOriginalExpense.Text= CfgFn.GetNoNullDecimal(MyDR["amount"]).ToString("c");
			txtAdateExpense.Text= ((DateTime)MyDR["adate"]).ToShortDateString();
			txtCodefinExpense.Text=MyDR["codefin"].ToString();
			txtFinExpense.Text=MyDR["finance"].ToString();
            txtUPB.Text = MyDR["codeupb"].ToString();
			txtDescrUPBExpense.Text=MyDR["upb"].ToString();
            txtResponsabile.Text = MyDR["manager"].ToString();
            SubEntity_txtNumMandato.Text = MyDR["npay"].ToString();
			txtCurrentExpense.Text= CfgFn.GetNoNullDecimal(MyDR["curramount"]).ToString("c");
			txtAvailableExpense.Text= CfgFn.GetNoNullDecimal(MyDR["available"]).ToString("c");
            grdSpesa.DataSource = null;
            HelpForm.SetDataGrid(grdSpesa, DS.Tables["expenselastview"]);
		}

		private void txtNmovExpense_Leave(object sender, System.EventArgs e) {
			if (txtNmovExpense.Text.Trim()==""){
				ClearExpense();
				return;
			}
			btnSelectMov_Click(sender,e);
		}

        private void txtNmovIncome_Leave (object sender, System.EventArgs e) {
            if (txtNmovIncome.Text.Trim() == "") {
                ClearIncome();
                return;
            }
            btnSelectIncome_Click(sender, e);
        }

		private void txtYmovExpense_Leave(object sender, System.EventArgs e) {			
			if (!Meta.DrawStateIsDone) return;
			FormattaDataDelTexBox(txtYmovExpense);		
		}

        private void txtYmovIncome_Leave (object sender, System.EventArgs e) {
            if (!Meta.DrawStateIsDone) return;
            FormattaDataDelTexBox(txtYmovExpense);
        }

		private void FormattaDataDelTexBox(TextBox TB) {
			if(!TB.Modified)return;
			HelpForm.FormatLikeYear(TB);
		}


        void AddAllCollegate (DataRow R) {
            int NSpesa = DS.expense.Rows.Count;
            int NEntrata = DS.income.Rows.Count;
            string filter;
            if (R.Table.TableName.StartsWith("expense")) {
                DS.expense.Clear();
                DS.expenselastview.Clear();
                filter = QHS.CmpEq("idexp", R["idexp"]);
                DataAccess.RUN_SELECT_INTO_TABLE(Conn, DS.expense, null, filter, null, true);
                DataAccess.RUN_SELECT_INTO_TABLE(Conn, DS.expenselastview, null, filter, null, true);
            }
            else {
                DS.income.Clear();
                DS.incomelastview.Clear();
                filter = QHS.CmpEq("idinc", R["idinc"]);
                DataAccess.RUN_SELECT_INTO_TABLE(Conn, DS.income, null, filter, null, true);
                DataAccess.RUN_SELECT_INTO_TABLE(Conn, DS.incomelastview, null, filter, null, true);
            }
        }

		void ClearExpense(){
            DS.expense.Clear();
            DS.expenseview.Clear();
            DS.expenselastview.Clear();
			txtNmovExpense.Text="";
			txtRegistryExpense.Text= "";
			txtDescrExpense.Text= "";
			SubEntity_txtOriginalExpense.Text= "";
			txtAdateExpense.Text= "";
			txtCodefinExpense.Text="";
			txtFinExpense.Text="";
            txtUPB.Text = "";
			txtDescrUPBExpense.Text="";
            txtResponsabile.Text = "";
			txtCurrentExpense.Text= "";
			txtAvailableExpense.Text= "";
            SubEntity_txtNumMandato.Text = "";
        }

        void ClearIncome () {
            DS.income.Clear();
            DS.incomeview.Clear();
            DS.incomelastview.Clear();
            txtNmovIncome.Text = "";
            txtRegistryIncome.Text = "";
            txtDescrIncome.Text = "";
            SubEntity_txtOriginalIncome.Text = "";
            txtAdateIncome.Text = "";
            txtCodefinIncome.Text = "";
            txtFinIncome.Text = "";
            txtUPBIncome.Text = "";
            txtDescrUpbIncome.Text = "";
            txtManagerIncome.Text = "";
            txtCurrentIncome.Text = "";
            txtAvailableIncome.Text = "";
            SubEntity_txtNumReversale.Text = "";
        }

        bool doAssocia () {
            if (DS.expense.Rows.Count == 0) {
                MessageBox.Show("Non è stato selezionato un movimento di spesa");
                return false;
            }
            if (DS.income.Rows.Count == 0) {
                MessageBox.Show("Non è stato selezionato un movimento di entrata");
                return false;
            }
          
            DataRow CurrIncome = DS.income.Rows[0];
            DataRow CurrExpense = DS.expense.Rows[0];

            if (MessageBox.Show(this, "Si desidera associare l'incasso al pagamento selezionato?", "Conferma", MessageBoxButtons.OKCancel) == DialogResult.OK) {
                
                object incomeflag = Conn.DO_READ_VALUE("incomelast", QHS.CmpEq("idinc", CurrIncome["idinc"]), "flag");
                int flag = CfgFn.GetNoNullInt32(incomeflag);
                bool incassoNetto = (flag & 32) != 0;
                string autokind = incassoNetto ? "INCASREG" : "GENER";
                object idAutokind = Conn.DO_READ_VALUE("autokind", QHS.CmpEq("code", autokind), "idautokind");
                CurrIncome["autokind"] = idAutokind; // Automatismo GENERICO o "Incasso da regolarizzare al netto delle spese accessorie" a seconda
                CurrIncome["idpayment"] = CurrExpense["idexp"];
            }
            else {
                return false;
            }
           
            PostData Post = Meta.Get_PostData();
            Post.InitClass(DS, Conn);
            bool res = Post.DO_POST();
            if (res) MessageBox.Show("Operazione effettuata.");
            if (!res) CurrIncome.RejectChanges();
            return res;
        }

        private void btnSelectIncome_Click (object sender, EventArgs e) {
            string MyFilter;

            if (((Control)sender).Name == "txtNmovIncome")
                MyFilter = GetFilterIncome(true);
            else
                MyFilter = GetFilterIncome(false);

            MetaData MFase = MetaData.GetMetaData(this, "income");
            MFase.FilterLocked = true;
            MFase.DS = DS;

            DataRow MyDR = MFase.SelectOne("default", MyFilter, null, null);

            if (MyDR == null) {
                if (Meta.InsertMode) {
                    if (typeof(TextBox).IsAssignableFrom(sender.GetType())) {
                        if (((TextBox)sender).Text.Trim() != "") ((TextBox)sender).Focus();
                    }
                }
                return;
            }
            txtFaseEntrata.Text = MyDR["phase"].ToString();
            txtYmovIncome.Text = MyDR["ymov"].ToString();
            txtNmovIncome.Text = MyDR["nmov"].ToString();
            txtRegistryIncome.Text = MyDR["registry"].ToString();
            txtDescrIncome.Text = MyDR["description"].ToString();
            SubEntity_txtOriginalIncome.Text = CfgFn.GetNoNullDecimal(MyDR["amount"]).ToString("c");
            txtAdateIncome.Text = ((DateTime)MyDR["adate"]).ToShortDateString();
            txtCodefinIncome.Text = MyDR["codefin"].ToString();
            txtFinIncome.Text = MyDR["finance"].ToString();
            txtUPBIncome.Text = MyDR["codeupb"].ToString();
            txtDescrUpbIncome.Text = MyDR["upb"].ToString();
            txtManagerIncome.Text = MyDR["manager"].ToString();
            SubEntity_txtNumMandato.Text = MyDR["npro"].ToString();
            txtCurrentIncome.Text = CfgFn.GetNoNullDecimal(MyDR["curramount"]).ToString("c");
            txtAvailableIncome.Text = CfgFn.GetNoNullDecimal(MyDR["available"]).ToString("c");
            grdEntrata.DataSource = null;
            HelpForm.SetDataGrid(grdEntrata, DS.Tables["incomelastview"]);
        }

        private void txtCodefinExpense_TextChanged(object sender, EventArgs e) {

        }

        private void txtNumIncome_SelectionChanged(object sender, EventArgs e) {

        }
	}
}