
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
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using metadatalibrary;
using funzioni_configurazione;//funzioni_configurazione

namespace income_wizardchangeunderwriting {//spesawizardelimina//
	/// <summary>
	/// Summary description for FrmSpesaWizardElimina.
	/// </summary>
	public class Frm_income_wizardchangeunderwriting : MetaDataForm {
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnBack;
		public vistaForm DS;
		DataAccess Conn;
        string CustomTitle;
        private System.ComponentModel.IContainer components;
        private System.Windows.Forms.ImageList imageList1;
        private Crownwood.Magic.Controls.TabPage tabShow;
        private Label label10;
        private Label label8;
        private Label label7;
        private DataGrid grdEntrata;
        private DataGrid grdUnderWriting;
        private Crownwood.Magic.Controls.TabPage tabSelectIncome;
        private Crownwood.Magic.Controls.TabPage tabPage1;
        private GroupBox groupBox2;
        private GroupBox groupBox3;
        private TextBox txtDescrUpbIncome;
        private GroupBox groupBox4;
        private Label label14;
        private TextBox txtAdateIncome;
        private TextBox txtExpirationIncome;
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
        private TextBox txtFaseEntrata;
        private Button btnSelectIncome;
        private TextBox txtNmovIncome;
        private Label label23;
        private TextBox txtYmovIncome;
        private Label label24;
        private Label label25;
        private Crownwood.Magic.Controls.TabPage tabIntro;
        private Label label3;
        private Label label2;
        private Label label1;
        private Crownwood.Magic.Controls.TabControl txtNumIncome;
        private Crownwood.Magic.Controls.TabPage tabSelectUnderwriting;
        private GroupBox groupBox1;
        private TextBox txtFinanziamento;
        private Button btnFinanziamento;
        private CheckBox chkFilterAvailable;
		public MetaData Meta;
        private object idupb_Selected;
        private object idfin_Selected;
        private object amount_Selected;
        private GroupBox groupBox11;
        private TextBox txtUnderWriting_Income;
        private TextBox txtManagerIncome;
        private Label label4;
        private TextBox txtUPB;
        private object idunderwriting_Selected;
		public Frm_income_wizardchangeunderwriting() {
			InitializeComponent();

			txtNumIncome.HideTabsMode = 
				Crownwood.Magic.Controls.TabControl.HideTabsModes.HideAlways;
		}

		public void MetaData_AfterActivation(){
			CustomTitle= "Associa Finanziamento ad Accertamento";
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
            GetData.CacheTable(DS.incomephase, QHS.CmpEq("nphase", Meta.GetSys("assessmentphase")), null, false);
            string filteresercizio = QHC.CmpEq("ayear", Meta.GetSys("esercizio"));
            DataAccess.SetTableForReading(DS.manager_income, "manager");
            DataAccess.SetTableForReading(DS.fin_income, "fin");
            DataAccess.SetTableForReading(DS.upb_income, "upb");
            GetData.CacheTable(DS.manager_income, null, "title", true);
            txtYmovIncome.Text = Meta.GetSys("esercizio").ToString();
            object descrPhaseIncome = Conn.DO_READ_VALUE("incomephase", QHS.CmpEq("nphase", Meta.GetSys("assessmentphase")), "description");
            txtFaseEntrata.Text = descrPhaseIncome.ToString();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_income_wizardchangeunderwriting));
            this.DS = new income_wizardchangeunderwriting.vistaForm();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.tabShow = new Crownwood.Magic.Controls.TabPage();
            this.label10 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.grdEntrata = new System.Windows.Forms.DataGrid();
            this.grdUnderWriting = new System.Windows.Forms.DataGrid();
            this.tabSelectIncome = new Crownwood.Magic.Controls.TabPage();
            this.tabPage1 = new Crownwood.Magic.Controls.TabPage();
            this.groupBox11 = new System.Windows.Forms.GroupBox();
            this.txtUnderWriting_Income = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
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
            this.tabIntro = new Crownwood.Magic.Controls.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNumIncome = new Crownwood.Magic.Controls.TabControl();
            this.tabSelectUnderwriting = new Crownwood.Magic.Controls.TabPage();
            this.chkFilterAvailable = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtFinanziamento = new System.Windows.Forms.TextBox();
            this.btnFinanziamento = new System.Windows.Forms.Button();
            this.txtManagerIncome = new System.Windows.Forms.TextBox();
            this.txtUPB = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.tabShow.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdEntrata)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdUnderWriting)).BeginInit();
            this.tabSelectIncome.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox11.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.groupBox10.SuspendLayout();
            this.tabIntro.SuspendLayout();
            this.txtNumIncome.SuspendLayout();
            this.tabSelectUnderwriting.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.EnforceConstraints = false;
            this.DS.Locale = new System.Globalization.CultureInfo("en-US");
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "");
            this.imageList1.Images.SetKeyName(1, "");
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(695, 492);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Tag = "maincancel";
            this.btnCancel.Text = "Cancel";
            // 
            // btnNext
            // 
            this.btnNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNext.Location = new System.Drawing.Point(575, 492);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(88, 23);
            this.btnNext.TabIndex = 6;
            this.btnNext.Text = "Avanti >";
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnBack
            // 
            this.btnBack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBack.Location = new System.Drawing.Point(487, 492);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(80, 23);
            this.btnBack.TabIndex = 5;
            this.btnBack.Text = "< Indietro";
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // tabShow
            // 
            this.tabShow.Controls.Add(this.label10);
            this.tabShow.Controls.Add(this.label8);
            this.tabShow.Controls.Add(this.label7);
            this.tabShow.Controls.Add(this.grdEntrata);
            this.tabShow.Controls.Add(this.grdUnderWriting);
            this.tabShow.Location = new System.Drawing.Point(0, 0);
            this.tabShow.Name = "tabShow";
            this.tabShow.Selected = false;
            this.tabShow.Size = new System.Drawing.Size(766, 452);
            this.tabShow.TabIndex = 5;
            this.tabShow.Title = "Pagina 4 di 4";
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label10.Location = new System.Drawing.Point(8, 269);
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
            this.label7.Text = "Finanziamento";
            // 
            // grdEntrata
            // 
            this.grdEntrata.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grdEntrata.DataMember = "";
            this.grdEntrata.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.grdEntrata.Location = new System.Drawing.Point(8, 288);
            this.grdEntrata.Name = "grdEntrata";
            this.grdEntrata.Size = new System.Drawing.Size(750, 144);
            this.grdEntrata.TabIndex = 1;
            this.grdEntrata.Tag = "incomeview.default";
            // 
            // grdUnderWriting
            // 
            this.grdUnderWriting.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grdUnderWriting.DataMember = "";
            this.grdUnderWriting.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.grdUnderWriting.Location = new System.Drawing.Point(8, 48);
            this.grdUnderWriting.Name = "grdUnderWriting";
            this.grdUnderWriting.Size = new System.Drawing.Size(750, 218);
            this.grdUnderWriting.TabIndex = 0;
            this.grdUnderWriting.Tag = "underwriting.default";
            // 
            // tabSelectIncome
            // 
            this.tabSelectIncome.Controls.Add(this.tabPage1);
            this.tabSelectIncome.Location = new System.Drawing.Point(0, 0);
            this.tabSelectIncome.Name = "tabSelectIncome";
            this.tabSelectIncome.Size = new System.Drawing.Size(766, 452);
            this.tabSelectIncome.TabIndex = 6;
            this.tabSelectIncome.Title = "Pagina 2 di 4";
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox11);
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
            this.tabPage1.Size = new System.Drawing.Size(762, 451);
            this.tabPage1.TabIndex = 5;
            this.tabPage1.Title = "Pagina 2 di 4";
            // 
            // groupBox11
            // 
            this.groupBox11.Controls.Add(this.txtUnderWriting_Income);
            this.groupBox11.Location = new System.Drawing.Point(401, 148);
            this.groupBox11.Name = "groupBox11";
            this.groupBox11.Size = new System.Drawing.Size(361, 56);
            this.groupBox11.TabIndex = 93;
            this.groupBox11.TabStop = false;
            this.groupBox11.Tag = "";
            this.groupBox11.Text = "Finanziamento";
            // 
            // txtUnderWriting_Income
            // 
            this.txtUnderWriting_Income.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUnderWriting_Income.Location = new System.Drawing.Point(6, 22);
            this.txtUnderWriting_Income.Multiline = true;
            this.txtUnderWriting_Income.Name = "txtUnderWriting_Income";
            this.txtUnderWriting_Income.ReadOnly = true;
            this.txtUnderWriting_Income.Size = new System.Drawing.Size(348, 22);
            this.txtUnderWriting_Income.TabIndex = 2;
            this.txtUnderWriting_Income.TabStop = false;
            this.txtUnderWriting_Income.Tag = "";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtManagerIncome);
            this.groupBox2.Location = new System.Drawing.Point(9, 261);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(367, 40);
            this.groupBox2.TabIndex = 92;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Responsabile";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.txtUPB);
            this.groupBox3.Controls.Add(this.txtDescrUpbIncome);
            this.groupBox3.Location = new System.Drawing.Point(14, 154);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(367, 101);
            this.groupBox3.TabIndex = 91;
            this.groupBox3.TabStop = false;
            this.groupBox3.Tag = "";
            // 
            // txtDescrUpbIncome
            // 
            this.txtDescrUpbIncome.Location = new System.Drawing.Point(89, 8);
            this.txtDescrUpbIncome.Multiline = true;
            this.txtDescrUpbIncome.Name = "txtDescrUpbIncome";
            this.txtDescrUpbIncome.ReadOnly = true;
            this.txtDescrUpbIncome.Size = new System.Drawing.Size(273, 60);
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
            this.groupBox4.Location = new System.Drawing.Point(14, 405);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(367, 40);
            this.groupBox4.TabIndex = 18;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Data";
            // 
            // label14
            // 
            this.label14.Location = new System.Drawing.Point(60, 15);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(56, 20);
            this.label14.TabIndex = 0;
            this.label14.Text = "Contabile";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtAdateIncome
            // 
            this.txtAdateIncome.Location = new System.Drawing.Point(125, 14);
            this.txtAdateIncome.Name = "txtAdateIncome";
            this.txtAdateIncome.ReadOnly = true;
            this.txtAdateIncome.Size = new System.Drawing.Size(72, 21);
            this.txtAdateIncome.TabIndex = 1;
            this.txtAdateIncome.Tag = "";
            this.txtAdateIncome.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtExpirationIncome
            // 
            this.txtExpirationIncome.Location = new System.Drawing.Point(264, 16);
            this.txtExpirationIncome.Name = "txtExpirationIncome";
            this.txtExpirationIncome.ReadOnly = true;
            this.txtExpirationIncome.Size = new System.Drawing.Size(72, 21);
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
            this.groupBox5.Location = new System.Drawing.Point(14, 114);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(367, 40);
            this.groupBox5.TabIndex = 17;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Importo";
            // 
            // SubEntity_txtOriginalIncome
            // 
            this.SubEntity_txtOriginalIncome.Location = new System.Drawing.Point(225, 12);
            this.SubEntity_txtOriginalIncome.Name = "SubEntity_txtOriginalIncome";
            this.SubEntity_txtOriginalIncome.ReadOnly = true;
            this.SubEntity_txtOriginalIncome.Size = new System.Drawing.Size(112, 21);
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
            this.groupBox6.Location = new System.Drawing.Point(401, 28);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(364, 80);
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
            this.txtDescrIncome.Size = new System.Drawing.Size(346, 48);
            this.txtDescrIncome.TabIndex = 1;
            this.txtDescrIncome.Tag = "";
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.label19);
            this.groupBox7.Controls.Add(this.txtCodefinIncome);
            this.groupBox7.Controls.Add(this.txtFinIncome);
            this.groupBox7.Location = new System.Drawing.Point(14, 299);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(367, 100);
            this.groupBox7.TabIndex = 12;
            this.groupBox7.TabStop = false;
            this.groupBox7.Tag = "";
            // 
            // label19
            // 
            this.label19.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label19.ImageIndex = 0;
            this.label19.ImageList = this.imageList1;
            this.label19.Location = new System.Drawing.Point(12, 31);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(71, 18);
            this.label19.TabIndex = 3;
            this.label19.Text = "Bilancio";
            this.label19.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtCodefinIncome
            // 
            this.txtCodefinIncome.Location = new System.Drawing.Point(10, 73);
            this.txtCodefinIncome.Name = "txtCodefinIncome";
            this.txtCodefinIncome.ReadOnly = true;
            this.txtCodefinIncome.Size = new System.Drawing.Size(343, 21);
            this.txtCodefinIncome.TabIndex = 1;
            this.txtCodefinIncome.Tag = "";
            // 
            // txtFinIncome
            // 
            this.txtFinIncome.Location = new System.Drawing.Point(89, 8);
            this.txtFinIncome.Multiline = true;
            this.txtFinIncome.Name = "txtFinIncome";
            this.txtFinIncome.ReadOnly = true;
            this.txtFinIncome.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtFinIncome.Size = new System.Drawing.Size(267, 59);
            this.txtFinIncome.TabIndex = 2;
            this.txtFinIncome.TabStop = false;
            this.txtFinIncome.Tag = "";
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.txtRegistryIncome);
            this.groupBox8.Location = new System.Drawing.Point(401, 108);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(364, 40);
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
            this.txtRegistryIncome.Size = new System.Drawing.Size(346, 21);
            this.txtRegistryIncome.TabIndex = 1;
            this.txtRegistryIncome.Tag = "";
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.label20);
            this.groupBox9.Controls.Add(this.label21);
            this.groupBox9.Controls.Add(this.txtAvailableIncome);
            this.groupBox9.Controls.Add(this.txtCurrentIncome);
            this.groupBox9.Location = new System.Drawing.Point(395, 384);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(364, 64);
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
            this.txtAvailableIncome.Size = new System.Drawing.Size(96, 21);
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
            this.txtCurrentIncome.Size = new System.Drawing.Size(96, 21);
            this.txtCurrentIncome.TabIndex = 0;
            this.txtCurrentIncome.TabStop = false;
            this.txtCurrentIncome.Tag = "";
            this.txtCurrentIncome.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label22
            // 
            this.label22.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(11, 2);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(416, 23);
            this.label22.TabIndex = 2;
            this.label22.Text = "Seleziona un Accertamento tra quelli in C/Competenza";
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
            this.groupBox10.Location = new System.Drawing.Point(14, 28);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(367, 80);
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
            this.txtFaseEntrata.Size = new System.Drawing.Size(221, 21);
            this.txtFaseEntrata.TabIndex = 5;
            this.txtFaseEntrata.Tag = "";
            // 
            // btnSelectIncome
            // 
            this.btnSelectIncome.Location = new System.Drawing.Point(15, 17);
            this.btnSelectIncome.Name = "btnSelectIncome";
            this.btnSelectIncome.Size = new System.Drawing.Size(75, 23);
            this.btnSelectIncome.TabIndex = 4;
            this.btnSelectIncome.Tag = "";
            this.btnSelectIncome.Text = "Seleziona";
            this.btnSelectIncome.Click += new System.EventHandler(this.btnSelectIncome_Click);
            // 
            // txtNmovIncome
            // 
            this.txtNmovIncome.Location = new System.Drawing.Point(139, 49);
            this.txtNmovIncome.Name = "txtNmovIncome";
            this.txtNmovIncome.Size = new System.Drawing.Size(48, 21);
            this.txtNmovIncome.TabIndex = 3;
            this.txtNmovIncome.Tag = "";
            this.txtNmovIncome.Leave += new System.EventHandler(this.txtNmovIncome_Leave);
            // 
            // label23
            // 
            this.label23.Location = new System.Drawing.Point(102, 49);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(32, 20);
            this.label23.TabIndex = 0;
            this.label23.Text = "Num.";
            this.label23.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtYmovIncome
            // 
            this.txtYmovIncome.Location = new System.Drawing.Point(52, 49);
            this.txtYmovIncome.Name = "txtYmovIncome";
            this.txtYmovIncome.ReadOnly = true;
            this.txtYmovIncome.Size = new System.Drawing.Size(39, 21);
            this.txtYmovIncome.TabIndex = 2;
            this.txtYmovIncome.Tag = "";
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
            // tabIntro
            // 
            this.tabIntro.Controls.Add(this.label3);
            this.tabIntro.Controls.Add(this.label2);
            this.tabIntro.Controls.Add(this.label1);
            this.tabIntro.Location = new System.Drawing.Point(0, 0);
            this.tabIntro.Name = "tabIntro";
            this.tabIntro.Selected = false;
            this.tabIntro.Size = new System.Drawing.Size(766, 452);
            this.tabIntro.TabIndex = 3;
            this.tabIntro.Title = "Pagina 1 di 4";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.Location = new System.Drawing.Point(8, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(750, 37);
            this.label3.TabIndex = 6;
            this.label3.Text = "Nel secondo passo vi verranno mostrati tutti i Finanziamenti utilizzabili e  sarà" +
                " chiesta conferma di voler procedere nell\'operazione.";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.Location = new System.Drawing.Point(8, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(750, 32);
            this.label2.TabIndex = 5;
            this.label2.Text = " Nel primo passo vi verrà richiesto di selezionare un Accertamento tra quelli in " +
                "C/Competenza";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Location = new System.Drawing.Point(8, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(750, 48);
            this.label1.TabIndex = 4;
            this.label1.Text = "Questo Wizard serve a modificare il Finanziamento associato ad un Accertamento  e" +
                " ai relativi  Incassi";
            // 
            // txtNumIncome
            // 
            this.txtNumIncome.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNumIncome.IDEPixelArea = true;
            this.txtNumIncome.Location = new System.Drawing.Point(8, 9);
            this.txtNumIncome.Name = "txtNumIncome";
            this.txtNumIncome.SelectedIndex = 1;
            this.txtNumIncome.SelectedTab = this.tabSelectIncome;
            this.txtNumIncome.Size = new System.Drawing.Size(766, 477);
            this.txtNumIncome.TabIndex = 4;
            this.txtNumIncome.TabPages.AddRange(new Crownwood.Magic.Controls.TabPage[] {
            this.tabIntro,
            this.tabSelectIncome,
            this.tabSelectUnderwriting,
            this.tabShow});
            this.txtNumIncome.SelectionChanged += new System.EventHandler(this.txtNumIncome_SelectionChanged);
            // 
            // tabSelectUnderwriting
            // 
            this.tabSelectUnderwriting.Controls.Add(this.chkFilterAvailable);
            this.tabSelectUnderwriting.Controls.Add(this.groupBox1);
            this.tabSelectUnderwriting.Location = new System.Drawing.Point(0, 0);
            this.tabSelectUnderwriting.Name = "tabSelectUnderwriting";
            this.tabSelectUnderwriting.Selected = false;
            this.tabSelectUnderwriting.Size = new System.Drawing.Size(766, 452);
            this.tabSelectUnderwriting.TabIndex = 7;
            this.tabSelectUnderwriting.Title = "Pagina 3 di 4";
            // 
            // chkFilterAvailable
            // 
            this.chkFilterAvailable.Checked = true;
            this.chkFilterAvailable.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkFilterAvailable.Location = new System.Drawing.Point(28, 102);
            this.chkFilterAvailable.Name = "chkFilterAvailable";
            this.chkFilterAvailable.Size = new System.Drawing.Size(288, 28);
            this.chkFilterAvailable.TabIndex = 88;
            this.chkFilterAvailable.TabStop = false;
            this.chkFilterAvailable.Text = "Filtra per disponibilità sufficiente";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtFinanziamento);
            this.groupBox1.Controls.Add(this.btnFinanziamento);
            this.groupBox1.Location = new System.Drawing.Point(28, 136);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(340, 73);
            this.groupBox1.TabIndex = 87;
            this.groupBox1.TabStop = false;
            this.groupBox1.Tag = "AutoChoose.txtFinanziamento.default.(active = \'S\')";
            // 
            // txtFinanziamento
            // 
            this.txtFinanziamento.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFinanziamento.Location = new System.Drawing.Point(6, 41);
            this.txtFinanziamento.Multiline = true;
            this.txtFinanziamento.Name = "txtFinanziamento";
            this.txtFinanziamento.ReadOnly = true;
            this.txtFinanziamento.Size = new System.Drawing.Size(327, 22);
            this.txtFinanziamento.TabIndex = 2;
            this.txtFinanziamento.TabStop = false;
            this.txtFinanziamento.Tag = "underwriting.title?incomeview.underwriting";
            // 
            // btnFinanziamento
            // 
            this.btnFinanziamento.Location = new System.Drawing.Point(6, 14);
            this.btnFinanziamento.Name = "btnFinanziamento";
            this.btnFinanziamento.Size = new System.Drawing.Size(104, 23);
            this.btnFinanziamento.TabIndex = 0;
            this.btnFinanziamento.Tag = "";
            this.btnFinanziamento.Text = "Finanziamento";
            this.btnFinanziamento.UseVisualStyleBackColor = true;
            this.btnFinanziamento.Click += new System.EventHandler(this.btnFinanziamento_Click);
            // 
            // txtManagerIncome
            // 
            this.txtManagerIncome.Location = new System.Drawing.Point(6, 13);
            this.txtManagerIncome.Name = "txtManagerIncome";
            this.txtManagerIncome.ReadOnly = true;
            this.txtManagerIncome.Size = new System.Drawing.Size(355, 21);
            this.txtManagerIncome.TabIndex = 94;
            // 
            // txtUPB
            // 
            this.txtUPB.Location = new System.Drawing.Point(5, 74);
            this.txtUPB.Name = "txtUPB";
            this.txtUPB.ReadOnly = true;
            this.txtUPB.Size = new System.Drawing.Size(357, 21);
            this.txtUPB.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 55);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(26, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "UPB";
            // 
            // Frm_income_wizardchangeunderwriting
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(782, 518);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.txtNumIncome);
            this.Name = "Frm_income_wizardchangeunderwriting";
            this.Text = "Associa Finanziamento ad Accertamento";
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.tabShow.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdEntrata)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdUnderWriting)).EndInit();
            this.tabSelectIncome.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox11.ResumeLayout(false);
            this.groupBox11.PerformLayout();
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
            this.tabIntro.ResumeLayout(false);
            this.txtNumIncome.ResumeLayout(false);
            this.tabSelectUnderwriting.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
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
				DialogResult= DialogResult.OK;
				Close();
				return;
			}
			DisplayTabs(newTab);
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
			if ((oldTab==1)&&(newTab==2))return GetIncome();
            if ((oldTab == 2) && (newTab == 3)) return GetUnderwriting();
            if ((oldTab == 3) && (newTab == 4)) return doAssocia(); 
			return true;
		}

		bool GetUnderwriting(){
            if (txtFinanziamento.Text.Trim() == "")
            {
                show("Selezionare un Finanziamento per procedere");
                return false;
            }
            string filter = QHS.CmpEq("idunderwriting", idunderwriting_Selected);
            DataAccess.RUN_SELECT_INTO_TABLE(Conn, DS.underwriting, null, filter, null, true);
            //idupb_Selected = DBNull.Value;
            //idfin_Selected = DBNull.Value;
            //amount_Selected = DBNull.Value;
            //idunderwriting_Selected = DBNull.Value;
			return true;
		}


        bool GetIncome () {
            //txtYmovIncome.Text = Meta.GetSys("esercizio").ToString();
            if (txtNmovIncome.Text.Trim() == "") {
                show("Selezionare un movimento di entrata per procedere");
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
        string GetFilterIncome (bool IsNumMov) {
            string MyFilter = QHS.CmpEq("ayear", Meta.GetSys("esercizio"));
            MyFilter = QHS.CmpEq("nphase", Meta.GetSys("assessmentphase"));
            MyFilter = QHS.AppAnd(MyFilter, QHS.CmpEq("ayear", Meta.GetSys("esercizio")));

            if (txtYmovIncome.Text.Trim() != "")
                MyFilter = QHS.AppAnd(MyFilter, QHS.CmpEq("ymov", txtYmovIncome.Text.Trim()));

            if ((IsNumMov) && (txtNmovIncome.Text.Trim() != ""))
                MyFilter = QHS.AppAnd(MyFilter, QHS.CmpEq("nmov", txtNmovIncome.Text.Trim()));
            
            return MyFilter;
        }



        private void txtNmovIncome_Leave(object sender, System.EventArgs e)
        {
            if (txtNmovIncome.Text.Trim() == "")
            {
                ClearIncome();
                return;
            }
            btnSelectIncome_Click(sender, e);
        }

        private void txtYmovIncome_Leave(object sender, System.EventArgs e)
        {
            if (!Meta.DrawStateIsDone) return;
            FormattaDataDelTexBox(txtYmovIncome);
        }

        private void FormattaDataDelTexBox(TextBox TB)
        {
            if (!TB.Modified) return;
            HelpForm.FormatLikeYear(TB);
        }


        void AddAllCollegate(DataRow R)
        {
            string filter = "";
            string filterParent = "";
            string filterChild = "";
            if (R["idinc"]!=DBNull.Value) 
            {
                DS.income.Clear();
                DS.incomeview.Clear();
                filter = QHS.CmpEq("idinc", R["idinc"]);
                DataAccess.RUN_SELECT_INTO_TABLE(Conn, DS.income, null, filter, null, true);
                string filteryear = QHS.AppAnd(filter, QHS.CmpEq("ayear", Conn.GetEsercizio()));
                DataAccess.RUN_SELECT_INTO_TABLE(Conn, DS.incomeview, null, filteryear, null, true);
                filterParent = QHS.CmpEq("idparent", R["idinc"]);
                DataTable IncomeLink = Meta.Conn.RUN_SELECT("incomelink", "idchild", null,filterParent, null,true);
                string lista = QHC.DistinctVal(IncomeLink.Select(), "idchild");
                filterChild = QHS.AppAnd( QHS.FieldInList("idinc",lista),QHS.CmpEq("nphase",Meta.GetSys("maxincomephase")));
                string filterChildYear = QHS.AppAnd(filterChild, QHS.CmpEq("ayear", Conn.GetEsercizio()));
                DataAccess.RUN_SELECT_INTO_TABLE(Conn, DS.income, null, filterChild, null, true);
                DataAccess.RUN_SELECT_INTO_TABLE(Conn, DS.incomeview, null, filterChildYear, null, true);
            }
        }

        void ClearIncome () {
            idupb_Selected = DBNull.Value;
            idfin_Selected = DBNull.Value;
            amount_Selected = DBNull.Value;
            idunderwriting_Selected = DBNull.Value;
            DS.income.Clear();
            DS.incomeview.Clear();
            DS.underwriting.Clear();
            txtNmovIncome.Text = "";
            txtRegistryIncome.Text = "";
            txtDescrIncome.Text = "";
            SubEntity_txtOriginalIncome.Text = "";
            txtAdateIncome.Text = "";
            txtCodefinIncome.Text = "";
            txtFinIncome.Text = "";
            txtUPB.Text = "";
            txtDescrUpbIncome.Text = "";
            txtManagerIncome.Text = "";
            txtCurrentIncome.Text = "";
            txtAvailableIncome.Text = "";
            txtFinanziamento.Text = "";
            txtUnderWriting_Income.Text = "";
           
        }

        bool doAssocia () {
            if (idupb_Selected == DBNull.Value)
            {
                show("Non è stato selezionato un finanziamento");
                return false;
            }
            if (DS.income.Rows.Count == 0) {
                show("Non è stato selezionato nessun movimento finanziamento");
                return false;
            }

            DataRow[] Income= DS.income.Select(QHC.CmpEq("nphase",Meta.GetSys("assessmentphase")));
            if (Income.Length == 0) return false;
            DataRow CurrIncome = Income[0];
        

            if (show(this, "Si desidera associare il finanziamento all' Accertamento e agli Incassi selezionati?", "Conferma", MessageBoxButtons.OKCancel) == DialogResult.OK) {
               CurrIncome["idunderwriting"] = idunderwriting_Selected;
            }
            else {
                return false;
            }
           
            PostData Post = Meta.Get_PostData();
            Post.InitClass(DS, Conn);
            bool res = Post.DO_POST();
            if (res) show("Operazione effettuata.");
            else
                show("Operazione non effettuata.");
            //if (!res) CurrIncome.RejectChanges();
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
            txtUPB.Text = MyDR["codeupb"].ToString();
            txtDescrUpbIncome.Text = MyDR["upb"].ToString();
            txtManagerIncome.Text = MyDR["manager"].ToString();
            txtCurrentIncome.Text = CfgFn.GetNoNullDecimal(MyDR["curramount"]).ToString("c");
            txtAvailableIncome.Text = CfgFn.GetNoNullDecimal(MyDR["available"]).ToString("c");
            txtUnderWriting_Income.Text = MyDR["underwriting"].ToString();
            grdEntrata.DataSource = null;
            idupb_Selected = MyDR["idupb"];
            idfin_Selected = MyDR["idfin"];
          
            amount_Selected = MyDR["curramount"];
            HelpForm.SetDataGrid(grdEntrata, DS.Tables["incomeview"]);
        }

        private void btnFinanziamento_Click(object sender, EventArgs e)
        {
            //Seleziona il finanziamento in modo diverso a seconda del Filtro su Disponibilità Sufficiente
            //tendo fissi il bilancio e l'U.P.B.
            string Filter = "";
            string VistaScelta = "";
            int esercizioCurr = (int)Meta.GetSys("esercizio");

            if (chkFilterAvailable.Checked)
            {
                VistaScelta = "upbunderwritingyearview";
                Filter = QHS.CmpEq("ayear", Meta.GetSys("esercizio"));
                Filter = QHS.AppAnd(Filter, QHS.CmpEq("idupb", idupb_Selected));
                Filter = QHS.AppAnd(Filter, QHS.CmpEq("idfin", idfin_Selected));
                Filter = QHS.AppAnd(Filter, QHS.CmpGe("incomeprevavailable", CfgFn.GetNoNullDecimal(amount_Selected)));
                
                int N =  Meta.Conn.RUN_SELECT_COUNT(VistaScelta, Filter, false);
                if (N == 0)
                {
                    show("Non vi sono Finanziamenti con disponibilità sufficiente");
                    return;
                }

            }
            else
            {
                VistaScelta = "underwriting";
            }
            
            MetaData MUnderwritingView = MetaData.GetMetaData(this, VistaScelta);
            MUnderwritingView.FilterLocked = true;
            MUnderwritingView.DS = DS;
            DS.underwriting.Clear();
            DataRow MyDR = MUnderwritingView.SelectOne("default", Filter, null, null);

            if (MyDR != null)
            {
                SelezionaFinanziamento(MyDR);
            }
        }

        private void SelezionaFinanziamento(DataRow MyDR)
        {
            idunderwriting_Selected = MyDR["idunderwriting"];
            object title = Conn.DO_READ_VALUE("underwriting", QHS.CmpEq("idunderwriting",idunderwriting_Selected ), "title");
            txtFinanziamento.Text = title.ToString();
            HelpForm.SetDataGrid(grdUnderWriting, DS.Tables["underwriting"]);
        }

        private void txtNumIncome_SelectionChanged(object sender, EventArgs e) {

        }
	}
}
