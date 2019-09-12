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
using SituazioneViewer;
using funzioni_configurazione;

namespace account_default {
	/// <summary>
	/// Summary description for FrmAccount_default.
	/// </summary>
	public class FrmAccount_default : System.Windows.Forms.Form {
		MetaData Meta;
		
		public account_default.vistaForm DS;
		private System.Windows.Forms.ImageList icons;
		private System.Windows.Forms.TreeView treeView1;
		private System.Windows.Forms.Splitter splitter1;
		public System.Windows.Forms.TabControl MetaDataDetail;
		private System.Windows.Forms.TabPage tabPrincipale;
		private System.Windows.Forms.TextBox txtOrdineStampa;
		private System.Windows.Forms.Label lblOrdineStampa;
		private System.Windows.Forms.TextBox txtDenominazione;
		private System.Windows.Forms.Label lblDenominazione;
		private System.Windows.Forms.Label lblCodice;
		private System.Windows.Forms.TabPage tabClassificazione;
		private System.Windows.Forms.DataGrid dGridClassSup;
		private System.Windows.Forms.Button btnElimina;
		private System.Windows.Forms.Button btnModifica;
		private System.Windows.Forms.Button btnInserisci;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label lblLivello;
		private System.Windows.Forms.ComboBox cmbLivello;
		private System.ComponentModel.IContainer components;
		private System.Windows.Forms.CheckBox chkUPB;
		private System.Windows.Forms.ComboBox cmbAccountKind;
		private System.Windows.Forms.CheckBox chkRegistry;
		private System.Windows.Forms.GroupBox gboxOperativo;
		private System.Windows.Forms.GroupBox grbPatrimony;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button btnPatrimony;
		private System.Windows.Forms.Button btnPlaccount;
		private System.Windows.Forms.TextBox txtCodicen;
		private System.Windows.Forms.TextBox txtCodice;
		private System.Windows.Forms.TextBox txtPlaccounttitle;
		private System.Windows.Forms.TextBox txtPatrimonytitle;
        private System.Windows.Forms.GroupBox grbPlaccount;
		private System.Windows.Forms.GroupBox grpProfitLoss;
		private System.Windows.Forms.CheckBox chkUtile;
		private System.Windows.Forms.CheckBox chkPerdita;
		private System.Windows.Forms.CheckBox chkSegnoSP;
		private System.Windows.Forms.CheckBox chkSegnoCE;
        private CheckBox chkCompetency;
        private Button btnSituazione;
        private GroupBox grpEpilogo;
        private CheckBox checkBox2;
        private CheckBox checkBox1;
        private CheckBox chkCdOrdine;
        private GroupBox gboxConto;
        private TextBox txtDenominazioneConto;
        private TextBox txtCodiceConto;
        private Button button1;
        private Button btnSuddivUPB;
        private TabPage tabBudget;
        private DataGrid dgPrevisione;
        private Button btnInsPrevisione;
        private Button btnEditPrevisione;
        private Button btnDelPrevisione;
        private GroupBox groupBox2;
        private DataGrid dgVariazioni;
        private TabPage tabRiepilogo;
        private Button btnCalcolaTotali;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private Button btnImpegniBudget;
        private Label label6;
        private TextBox txtImpegniBudget;
        private Label label7;
        private Button btnVarBudget;
        private Label label8;
        private TextBox txtVariazioniBudget;
        private Label label9;
        private TextBox txtBudgetDisponibile;
        private Button btnPreimpegniBudget;
        private Label label10;
        private TextBox txtPreimpegniBudget;
        private Button btnBudgetIniziale;
        private Label label11;
        private TextBox txtBudgetIniziale;
        private CheckBox chkBoxEnableBudget;
        private GroupBox grpboxUtilizzoConto;
        private CheckBox chkRiscontiPassivi;
        private CheckBox chkRiscontiAttivi;
        private CheckBox chkRateiPassivi;
        private CheckBox chkRateiAttivi;
        private CheckBox chkDebit;
        private CheckBox chkCredit;
        private CheckBox checkBox5;
        private CheckBox checkBox3;
        private CheckBox checkBox4;
        private CheckBox checkBox6;
        private CheckBox checkBox7;
        private CheckBox checkBox8;
        public GroupBox gboxBudgetInvestimenti;
        private CheckBox chkSegnoBudgetI;
        public TextBox txtCodiceI;
        public Button btnCodiceInv;
        private TextBox txtDenom02;
        public GroupBox gboxBudgetEconomico;
        private CheckBox chkSegnoBudgetE;
        public TextBox txtCodiceE;
        public Button btnCodiceEcon;
        private TextBox txtDenom01;
        private Button btnVarImpegni;
        private Label label4;
        private TextBox txtVarImpegni;
        private TextBox txtVarPreimpegni;
        private Label label3;
        private Button btnVarPreimpegni;
        private CheckBox checkBox9;
        private Button btnVarAccertamenti;
        private Label label2;
        private TextBox txtVarAccertamenti;
        private TextBox txtVarPreaccertamenti;
        private Label label5;
        private Button btnVarPreaccertamenti;
        private Button btnAccertamentiBudget;
        private Label label12;
        private TextBox txtAccertamentiBudget;
        private Button btnPreaccertamentiBudget;
        private Label label13;
        private TextBox txtPreaccertamentiBudget;
        private CheckBox checkBox13;
        private CheckBox checkBox12;
        private CheckBox checkBox11;
        private CheckBox checkBox10;
        private CheckBox checkBox14;
        private CheckBox checkBox15;
        private CheckBox checkBox16;
        private TextBox txtCodiceEconomico;
        private TextBox txtCodicePatrimoniale;
        string filteresercizio;

		public FrmAccount_default() {
			InitializeComponent();
			HelpForm.SetDenyNull(DS.account.Columns["flagprofit"], true);
			HelpForm.SetDenyNull(DS.account.Columns["flagloss"], true);
			HelpForm.SetDenyNull(DS.account.Columns["placcount_sign"], true);
			HelpForm.SetDenyNull(DS.account.Columns["patrimony_sign"], true);
            HelpForm.SetDenyNull(DS.account.Columns["flagcompetency"], true);
            HelpForm.SetDenyNull(DS.account.Columns["flag"], true);
            HelpForm.SetDenyNull(DS.account.Columns["flagenablebudgetprev"], true);
            HelpForm.SetDenyNull(DS.account.Columns["flagaccountusage"], true);
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

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAccount_default));
            this.DS = new account_default.vistaForm();
            this.icons = new System.Windows.Forms.ImageList(this.components);
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.MetaDataDetail = new System.Windows.Forms.TabControl();
            this.tabPrincipale = new System.Windows.Forms.TabPage();
            this.gboxBudgetInvestimenti = new System.Windows.Forms.GroupBox();
            this.chkSegnoBudgetI = new System.Windows.Forms.CheckBox();
            this.txtCodiceI = new System.Windows.Forms.TextBox();
            this.btnCodiceInv = new System.Windows.Forms.Button();
            this.txtDenom02 = new System.Windows.Forms.TextBox();
            this.gboxBudgetEconomico = new System.Windows.Forms.GroupBox();
            this.chkSegnoBudgetE = new System.Windows.Forms.CheckBox();
            this.txtCodiceE = new System.Windows.Forms.TextBox();
            this.btnCodiceEcon = new System.Windows.Forms.Button();
            this.txtDenom01 = new System.Windows.Forms.TextBox();
            this.grpboxUtilizzoConto = new System.Windows.Forms.GroupBox();
            this.checkBox16 = new System.Windows.Forms.CheckBox();
            this.checkBox13 = new System.Windows.Forms.CheckBox();
            this.checkBox12 = new System.Windows.Forms.CheckBox();
            this.checkBox11 = new System.Windows.Forms.CheckBox();
            this.checkBox10 = new System.Windows.Forms.CheckBox();
            this.checkBox9 = new System.Windows.Forms.CheckBox();
            this.checkBox8 = new System.Windows.Forms.CheckBox();
            this.checkBox6 = new System.Windows.Forms.CheckBox();
            this.checkBox7 = new System.Windows.Forms.CheckBox();
            this.checkBox5 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.chkCredit = new System.Windows.Forms.CheckBox();
            this.chkDebit = new System.Windows.Forms.CheckBox();
            this.chkRiscontiPassivi = new System.Windows.Forms.CheckBox();
            this.chkRiscontiAttivi = new System.Windows.Forms.CheckBox();
            this.chkRateiPassivi = new System.Windows.Forms.CheckBox();
            this.chkRateiAttivi = new System.Windows.Forms.CheckBox();
            this.btnSuddivUPB = new System.Windows.Forms.Button();
            this.gboxConto = new System.Windows.Forms.GroupBox();
            this.txtDenominazioneConto = new System.Windows.Forms.TextBox();
            this.txtCodiceConto = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.chkCdOrdine = new System.Windows.Forms.CheckBox();
            this.grpEpilogo = new System.Windows.Forms.GroupBox();
            this.checkBox14 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.btnSituazione = new System.Windows.Forms.Button();
            this.chkCompetency = new System.Windows.Forms.CheckBox();
            this.grpProfitLoss = new System.Windows.Forms.GroupBox();
            this.chkPerdita = new System.Windows.Forms.CheckBox();
            this.chkUtile = new System.Windows.Forms.CheckBox();
            this.grbPlaccount = new System.Windows.Forms.GroupBox();
            this.btnPlaccount = new System.Windows.Forms.Button();
            this.txtPlaccounttitle = new System.Windows.Forms.TextBox();
            this.chkSegnoCE = new System.Windows.Forms.CheckBox();
            this.grbPatrimony = new System.Windows.Forms.GroupBox();
            this.txtPatrimonytitle = new System.Windows.Forms.TextBox();
            this.btnPatrimony = new System.Windows.Forms.Button();
            this.chkSegnoSP = new System.Windows.Forms.CheckBox();
            this.gboxOperativo = new System.Windows.Forms.GroupBox();
            this.checkBox15 = new System.Windows.Forms.CheckBox();
            this.chkBoxEnableBudget = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbAccountKind = new System.Windows.Forms.ComboBox();
            this.chkRegistry = new System.Windows.Forms.CheckBox();
            this.chkUPB = new System.Windows.Forms.CheckBox();
            this.lblLivello = new System.Windows.Forms.Label();
            this.cmbLivello = new System.Windows.Forms.ComboBox();
            this.txtOrdineStampa = new System.Windows.Forms.TextBox();
            this.lblOrdineStampa = new System.Windows.Forms.Label();
            this.txtDenominazione = new System.Windows.Forms.TextBox();
            this.lblDenominazione = new System.Windows.Forms.Label();
            this.txtCodice = new System.Windows.Forms.TextBox();
            this.lblCodice = new System.Windows.Forms.Label();
            this.tabBudget = new System.Windows.Forms.TabPage();
            this.dgPrevisione = new System.Windows.Forms.DataGrid();
            this.btnInsPrevisione = new System.Windows.Forms.Button();
            this.btnEditPrevisione = new System.Windows.Forms.Button();
            this.btnDelPrevisione = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgVariazioni = new System.Windows.Forms.DataGrid();
            this.tabClassificazione = new System.Windows.Forms.TabPage();
            this.dGridClassSup = new System.Windows.Forms.DataGrid();
            this.btnElimina = new System.Windows.Forms.Button();
            this.btnModifica = new System.Windows.Forms.Button();
            this.btnInserisci = new System.Windows.Forms.Button();
            this.tabRiepilogo = new System.Windows.Forms.TabPage();
            this.btnCalcolaTotali = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnVarAccertamenti = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtVarAccertamenti = new System.Windows.Forms.TextBox();
            this.txtVarPreaccertamenti = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnVarPreaccertamenti = new System.Windows.Forms.Button();
            this.btnAccertamentiBudget = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.txtAccertamentiBudget = new System.Windows.Forms.TextBox();
            this.btnPreaccertamentiBudget = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.txtPreaccertamentiBudget = new System.Windows.Forms.TextBox();
            this.btnVarImpegni = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtVarImpegni = new System.Windows.Forms.TextBox();
            this.txtVarPreimpegni = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnVarPreimpegni = new System.Windows.Forms.Button();
            this.btnImpegniBudget = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.txtImpegniBudget = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnVarBudget = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.txtVariazioniBudget = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtBudgetDisponibile = new System.Windows.Forms.TextBox();
            this.btnPreimpegniBudget = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.txtPreimpegniBudget = new System.Windows.Forms.TextBox();
            this.btnBudgetIniziale = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.txtBudgetIniziale = new System.Windows.Forms.TextBox();
            this.txtCodicen = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.txtCodicePatrimoniale = new System.Windows.Forms.TextBox();
            this.txtCodiceEconomico = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.MetaDataDetail.SuspendLayout();
            this.tabPrincipale.SuspendLayout();
            this.gboxBudgetInvestimenti.SuspendLayout();
            this.gboxBudgetEconomico.SuspendLayout();
            this.grpboxUtilizzoConto.SuspendLayout();
            this.gboxConto.SuspendLayout();
            this.grpEpilogo.SuspendLayout();
            this.grpProfitLoss.SuspendLayout();
            this.grbPlaccount.SuspendLayout();
            this.grbPatrimony.SuspendLayout();
            this.gboxOperativo.SuspendLayout();
            this.tabBudget.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgPrevisione)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgVariazioni)).BeginInit();
            this.tabClassificazione.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGridClassSup)).BeginInit();
            this.tabRiepilogo.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.EnforceConstraints = false;
            this.DS.Locale = new System.Globalization.CultureInfo("en-US");
            // 
            // icons
            // 
            this.icons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("icons.ImageStream")));
            this.icons.TransparentColor = System.Drawing.Color.Transparent;
            this.icons.Images.SetKeyName(0, "");
            this.icons.Images.SetKeyName(1, "");
            // 
            // treeView1
            // 
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Left;
            this.treeView1.HideSelection = false;
            this.treeView1.ImageIndex = 0;
            this.treeView1.ImageList = this.icons;
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Name = "treeView1";
            this.treeView1.SelectedImageIndex = 0;
            this.treeView1.ShowPlusMinus = false;
            this.treeView1.Size = new System.Drawing.Size(251, 648);
            this.treeView1.TabIndex = 1;
            this.treeView1.Tag = "account.tree";
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(251, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 648);
            this.splitter1.TabIndex = 3;
            this.splitter1.TabStop = false;
            // 
            // MetaDataDetail
            // 
            this.MetaDataDetail.Controls.Add(this.tabPrincipale);
            this.MetaDataDetail.Controls.Add(this.tabBudget);
            this.MetaDataDetail.Controls.Add(this.tabClassificazione);
            this.MetaDataDetail.Controls.Add(this.tabRiepilogo);
            this.MetaDataDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MetaDataDetail.Location = new System.Drawing.Point(254, 0);
            this.MetaDataDetail.Name = "MetaDataDetail";
            this.MetaDataDetail.SelectedIndex = 0;
            this.MetaDataDetail.Size = new System.Drawing.Size(714, 648);
            this.MetaDataDetail.TabIndex = 4;
            // 
            // tabPrincipale
            // 
            this.tabPrincipale.Controls.Add(this.gboxBudgetInvestimenti);
            this.tabPrincipale.Controls.Add(this.gboxBudgetEconomico);
            this.tabPrincipale.Controls.Add(this.grpboxUtilizzoConto);
            this.tabPrincipale.Controls.Add(this.btnSuddivUPB);
            this.tabPrincipale.Controls.Add(this.gboxConto);
            this.tabPrincipale.Controls.Add(this.chkCdOrdine);
            this.tabPrincipale.Controls.Add(this.grpEpilogo);
            this.tabPrincipale.Controls.Add(this.btnSituazione);
            this.tabPrincipale.Controls.Add(this.chkCompetency);
            this.tabPrincipale.Controls.Add(this.grpProfitLoss);
            this.tabPrincipale.Controls.Add(this.grbPlaccount);
            this.tabPrincipale.Controls.Add(this.grbPatrimony);
            this.tabPrincipale.Controls.Add(this.gboxOperativo);
            this.tabPrincipale.Controls.Add(this.lblLivello);
            this.tabPrincipale.Controls.Add(this.cmbLivello);
            this.tabPrincipale.Controls.Add(this.txtOrdineStampa);
            this.tabPrincipale.Controls.Add(this.lblOrdineStampa);
            this.tabPrincipale.Controls.Add(this.txtDenominazione);
            this.tabPrincipale.Controls.Add(this.lblDenominazione);
            this.tabPrincipale.Controls.Add(this.txtCodice);
            this.tabPrincipale.Controls.Add(this.lblCodice);
            this.tabPrincipale.Location = new System.Drawing.Point(4, 22);
            this.tabPrincipale.Name = "tabPrincipale";
            this.tabPrincipale.Size = new System.Drawing.Size(706, 622);
            this.tabPrincipale.TabIndex = 0;
            this.tabPrincipale.Text = "Principale";
            // 
            // gboxBudgetInvestimenti
            // 
            this.gboxBudgetInvestimenti.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gboxBudgetInvestimenti.Controls.Add(this.chkSegnoBudgetI);
            this.gboxBudgetInvestimenti.Controls.Add(this.txtCodiceI);
            this.gboxBudgetInvestimenti.Controls.Add(this.btnCodiceInv);
            this.gboxBudgetInvestimenti.Controls.Add(this.txtDenom02);
            this.gboxBudgetInvestimenti.Location = new System.Drawing.Point(370, 515);
            this.gboxBudgetInvestimenti.Name = "gboxBudgetInvestimenti";
            this.gboxBudgetInvestimenti.Size = new System.Drawing.Size(328, 92);
            this.gboxBudgetInvestimenti.TabIndex = 42;
            this.gboxBudgetInvestimenti.TabStop = false;
            this.gboxBudgetInvestimenti.Tag = "AutoChoose.txtCodiceI.tree5";
            this.gboxBudgetInvestimenti.Text = "Budget Investimenti";
            // 
            // chkSegnoBudgetI
            // 
            this.chkSegnoBudgetI.Location = new System.Drawing.Point(6, 66);
            this.chkSegnoBudgetI.Name = "chkSegnoBudgetI";
            this.chkSegnoBudgetI.Size = new System.Drawing.Size(104, 20);
            this.chkSegnoBudgetI.TabIndex = 7;
            this.chkSegnoBudgetI.Tag = "account.investmentbudget_sign:S:N";
            this.chkSegnoBudgetI.Text = "Segno Positivo";
            // 
            // txtCodiceI
            // 
            this.txtCodiceI.Location = new System.Drawing.Point(6, 43);
            this.txtCodiceI.Name = "txtCodiceI";
            this.txtCodiceI.Size = new System.Drawing.Size(134, 20);
            this.txtCodiceI.TabIndex = 6;
            this.txtCodiceI.Tag = "sorting_investimenti.sortcode?x";
            // 
            // btnCodiceInv
            // 
            this.btnCodiceInv.Location = new System.Drawing.Point(6, 14);
            this.btnCodiceInv.Name = "btnCodiceInv";
            this.btnCodiceInv.Size = new System.Drawing.Size(134, 23);
            this.btnCodiceInv.TabIndex = 4;
            this.btnCodiceInv.Tag = "manage.sorting_investimenti.tree5";
            this.btnCodiceInv.Text = "Codice";
            this.btnCodiceInv.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtDenom02
            // 
            this.txtDenom02.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDenom02.Location = new System.Drawing.Point(146, 12);
            this.txtDenom02.Multiline = true;
            this.txtDenom02.Name = "txtDenom02";
            this.txtDenom02.ReadOnly = true;
            this.txtDenom02.Size = new System.Drawing.Size(176, 59);
            this.txtDenom02.TabIndex = 3;
            this.txtDenom02.TabStop = false;
            this.txtDenom02.Tag = "sorting_investimenti.description";
            // 
            // gboxBudgetEconomico
            // 
            this.gboxBudgetEconomico.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gboxBudgetEconomico.Controls.Add(this.chkSegnoBudgetE);
            this.gboxBudgetEconomico.Controls.Add(this.txtCodiceE);
            this.gboxBudgetEconomico.Controls.Add(this.btnCodiceEcon);
            this.gboxBudgetEconomico.Controls.Add(this.txtDenom01);
            this.gboxBudgetEconomico.Location = new System.Drawing.Point(11, 515);
            this.gboxBudgetEconomico.Name = "gboxBudgetEconomico";
            this.gboxBudgetEconomico.Size = new System.Drawing.Size(357, 92);
            this.gboxBudgetEconomico.TabIndex = 41;
            this.gboxBudgetEconomico.TabStop = false;
            this.gboxBudgetEconomico.Tag = "AutoChoose.txtCodiceE.tree5";
            this.gboxBudgetEconomico.Text = "Budget Economico";
            // 
            // chkSegnoBudgetE
            // 
            this.chkSegnoBudgetE.Location = new System.Drawing.Point(8, 70);
            this.chkSegnoBudgetE.Name = "chkSegnoBudgetE";
            this.chkSegnoBudgetE.Size = new System.Drawing.Size(104, 22);
            this.chkSegnoBudgetE.TabIndex = 6;
            this.chkSegnoBudgetE.Tag = "account.economicbudget_sign:S:N";
            this.chkSegnoBudgetE.Text = "Segno Positivo";
            // 
            // txtCodiceE
            // 
            this.txtCodiceE.Location = new System.Drawing.Point(5, 47);
            this.txtCodiceE.Name = "txtCodiceE";
            this.txtCodiceE.Size = new System.Drawing.Size(143, 20);
            this.txtCodiceE.TabIndex = 5;
            this.txtCodiceE.Tag = "sorting_economico.sortcode?x";
            // 
            // btnCodiceEcon
            // 
            this.btnCodiceEcon.Location = new System.Drawing.Point(5, 18);
            this.btnCodiceEcon.Name = "btnCodiceEcon";
            this.btnCodiceEcon.Size = new System.Drawing.Size(143, 23);
            this.btnCodiceEcon.TabIndex = 4;
            this.btnCodiceEcon.Tag = "manage.sorting_economico.tree5";
            this.btnCodiceEcon.Text = "Codice";
            this.btnCodiceEcon.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtDenom01
            // 
            this.txtDenom01.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDenom01.Location = new System.Drawing.Point(152, 8);
            this.txtDenom01.Multiline = true;
            this.txtDenom01.Name = "txtDenom01";
            this.txtDenom01.ReadOnly = true;
            this.txtDenom01.Size = new System.Drawing.Size(199, 63);
            this.txtDenom01.TabIndex = 3;
            this.txtDenom01.TabStop = false;
            this.txtDenom01.Tag = "sorting_economico.description";
            // 
            // grpboxUtilizzoConto
            // 
            this.grpboxUtilizzoConto.Controls.Add(this.checkBox16);
            this.grpboxUtilizzoConto.Controls.Add(this.checkBox13);
            this.grpboxUtilizzoConto.Controls.Add(this.checkBox12);
            this.grpboxUtilizzoConto.Controls.Add(this.checkBox11);
            this.grpboxUtilizzoConto.Controls.Add(this.checkBox10);
            this.grpboxUtilizzoConto.Controls.Add(this.checkBox9);
            this.grpboxUtilizzoConto.Controls.Add(this.checkBox8);
            this.grpboxUtilizzoConto.Controls.Add(this.checkBox6);
            this.grpboxUtilizzoConto.Controls.Add(this.checkBox7);
            this.grpboxUtilizzoConto.Controls.Add(this.checkBox5);
            this.grpboxUtilizzoConto.Controls.Add(this.checkBox3);
            this.grpboxUtilizzoConto.Controls.Add(this.checkBox4);
            this.grpboxUtilizzoConto.Controls.Add(this.chkCredit);
            this.grpboxUtilizzoConto.Controls.Add(this.chkDebit);
            this.grpboxUtilizzoConto.Controls.Add(this.chkRiscontiPassivi);
            this.grpboxUtilizzoConto.Controls.Add(this.chkRiscontiAttivi);
            this.grpboxUtilizzoConto.Controls.Add(this.chkRateiPassivi);
            this.grpboxUtilizzoConto.Controls.Add(this.chkRateiAttivi);
            this.grpboxUtilizzoConto.Location = new System.Drawing.Point(392, 307);
            this.grpboxUtilizzoConto.Name = "grpboxUtilizzoConto";
            this.grpboxUtilizzoConto.Size = new System.Drawing.Size(302, 201);
            this.grpboxUtilizzoConto.TabIndex = 40;
            this.grpboxUtilizzoConto.TabStop = false;
            this.grpboxUtilizzoConto.Text = "Utilizzo del conto";
            // 
            // checkBox16
            // 
            this.checkBox16.AutoSize = true;
            this.checkBox16.Location = new System.Drawing.Point(136, 180);
            this.checkBox16.Name = "checkBox16";
            this.checkBox16.Size = new System.Drawing.Size(99, 17);
            this.checkBox16.TabIndex = 17;
            this.checkBox16.Tag = "account.flagaccountusage:17";
            this.checkBox16.Text = "Ammortamento ";
            this.checkBox16.UseVisualStyleBackColor = true;
            // 
            // checkBox13
            // 
            this.checkBox13.AutoSize = true;
            this.checkBox13.Location = new System.Drawing.Point(6, 180);
            this.checkBox13.Name = "checkBox13";
            this.checkBox13.Size = new System.Drawing.Size(130, 17);
            this.checkBox13.TabIndex = 16;
            this.checkBox13.Tag = "account.flagaccountusage:16";
            this.checkBox13.Text = "Altre voci del Passivo ";
            this.checkBox13.UseVisualStyleBackColor = true;
            // 
            // checkBox12
            // 
            this.checkBox12.AutoSize = true;
            this.checkBox12.Location = new System.Drawing.Point(136, 160);
            this.checkBox12.Name = "checkBox12";
            this.checkBox12.Size = new System.Drawing.Size(128, 17);
            this.checkBox12.TabIndex = 15;
            this.checkBox12.Tag = "account.flagaccountusage:15";
            this.checkBox12.Text = "Fondi Ammortamento ";
            this.checkBox12.UseVisualStyleBackColor = true;
            // 
            // checkBox11
            // 
            this.checkBox11.AutoSize = true;
            this.checkBox11.Location = new System.Drawing.Point(6, 160);
            this.checkBox11.Name = "checkBox11";
            this.checkBox11.Size = new System.Drawing.Size(118, 17);
            this.checkBox11.TabIndex = 14;
            this.checkBox11.Tag = "account.flagaccountusage:14";
            this.checkBox11.Text = "Altre voci dell\'Attivo";
            this.checkBox11.UseVisualStyleBackColor = true;
            // 
            // checkBox10
            // 
            this.checkBox10.AutoSize = true;
            this.checkBox10.Location = new System.Drawing.Point(136, 140);
            this.checkBox10.Name = "checkBox10";
            this.checkBox10.Size = new System.Drawing.Size(115, 17);
            this.checkBox10.TabIndex = 13;
            this.checkBox10.Tag = "account.flagaccountusage:13";
            this.checkBox10.Text = "Disponibilità liquide";
            this.checkBox10.UseVisualStyleBackColor = true;
            // 
            // checkBox9
            // 
            this.checkBox9.AutoSize = true;
            this.checkBox9.Location = new System.Drawing.Point(136, 120);
            this.checkBox9.Name = "checkBox9";
            this.checkBox9.Size = new System.Drawing.Size(151, 17);
            this.checkBox9.TabIndex = 12;
            this.checkBox9.Tag = "account.flagaccountusage:12";
            this.checkBox9.Text = "Fondo di Accantonamento";
            this.checkBox9.UseVisualStyleBackColor = true;
            // 
            // checkBox8
            // 
            this.checkBox8.AutoSize = true;
            this.checkBox8.Location = new System.Drawing.Point(6, 140);
            this.checkBox8.Name = "checkBox8";
            this.checkBox8.Size = new System.Drawing.Size(62, 17);
            this.checkBox8.TabIndex = 11;
            this.checkBox8.Tag = "account.flagaccountusage:11";
            this.checkBox8.Text = "Riserva";
            this.checkBox8.UseVisualStyleBackColor = true;
            // 
            // checkBox6
            // 
            this.checkBox6.AutoSize = true;
            this.checkBox6.Location = new System.Drawing.Point(6, 120);
            this.checkBox6.Name = "checkBox6";
            this.checkBox6.Size = new System.Drawing.Size(109, 17);
            this.checkBox6.TabIndex = 10;
            this.checkBox6.Tag = "account.flagaccountusage:10";
            this.checkBox6.Text = "Avanzo Vincolato";
            this.checkBox6.UseVisualStyleBackColor = true;
            // 
            // checkBox7
            // 
            this.checkBox7.AutoSize = true;
            this.checkBox7.Location = new System.Drawing.Point(136, 100);
            this.checkBox7.Name = "checkBox7";
            this.checkBox7.Size = new System.Drawing.Size(94, 17);
            this.checkBox7.TabIndex = 9;
            this.checkBox7.Tag = "account.flagaccountusage:9";
            this.checkBox7.Text = "Avanzo Libero";
            this.checkBox7.UseVisualStyleBackColor = true;
            // 
            // checkBox5
            // 
            this.checkBox5.AutoSize = true;
            this.checkBox5.Location = new System.Drawing.Point(136, 80);
            this.checkBox5.Name = "checkBox5";
            this.checkBox5.Size = new System.Drawing.Size(100, 17);
            this.checkBox5.TabIndex = 8;
            this.checkBox5.Tag = "account.flagaccountusage:8";
            this.checkBox5.Text = "Immobilizzazioni";
            this.checkBox5.UseVisualStyleBackColor = true;
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(6, 100);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(56, 17);
            this.checkBox3.TabIndex = 7;
            this.checkBox3.Tag = "account.flagaccountusage:7";
            this.checkBox3.Text = "Ricavi";
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // checkBox4
            // 
            this.checkBox4.AutoSize = true;
            this.checkBox4.Location = new System.Drawing.Point(6, 80);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(49, 17);
            this.checkBox4.TabIndex = 6;
            this.checkBox4.Tag = "account.flagaccountusage:6";
            this.checkBox4.Text = "Costi";
            this.checkBox4.UseVisualStyleBackColor = true;
            // 
            // chkCredit
            // 
            this.chkCredit.AutoSize = true;
            this.chkCredit.Location = new System.Drawing.Point(136, 60);
            this.chkCredit.Name = "chkCredit";
            this.chkCredit.Size = new System.Drawing.Size(101, 17);
            this.chkCredit.TabIndex = 5;
            this.chkCredit.Tag = "account.flagaccountusage:5";
            this.chkCredit.Text = "Conto di Credito";
            this.chkCredit.UseVisualStyleBackColor = true;
            // 
            // chkDebit
            // 
            this.chkDebit.AutoSize = true;
            this.chkDebit.Location = new System.Drawing.Point(6, 60);
            this.chkDebit.Name = "chkDebit";
            this.chkDebit.Size = new System.Drawing.Size(99, 17);
            this.chkDebit.TabIndex = 4;
            this.chkDebit.Tag = "account.flagaccountusage:4";
            this.chkDebit.Text = "Conto di Debito";
            this.chkDebit.UseVisualStyleBackColor = true;
            // 
            // chkRiscontiPassivi
            // 
            this.chkRiscontiPassivi.AutoSize = true;
            this.chkRiscontiPassivi.Location = new System.Drawing.Point(136, 40);
            this.chkRiscontiPassivi.Name = "chkRiscontiPassivi";
            this.chkRiscontiPassivi.Size = new System.Drawing.Size(100, 17);
            this.chkRiscontiPassivi.TabIndex = 3;
            this.chkRiscontiPassivi.Tag = "account.flagaccountusage:3";
            this.chkRiscontiPassivi.Text = "Risconti Passivi";
            this.chkRiscontiPassivi.UseVisualStyleBackColor = true;
            // 
            // chkRiscontiAttivi
            // 
            this.chkRiscontiAttivi.AutoSize = true;
            this.chkRiscontiAttivi.Location = new System.Drawing.Point(136, 20);
            this.chkRiscontiAttivi.Name = "chkRiscontiAttivi";
            this.chkRiscontiAttivi.Size = new System.Drawing.Size(93, 17);
            this.chkRiscontiAttivi.TabIndex = 2;
            this.chkRiscontiAttivi.Tag = "account.flagaccountusage:2";
            this.chkRiscontiAttivi.Text = "Risconti Attivi ";
            this.chkRiscontiAttivi.UseVisualStyleBackColor = true;
            // 
            // chkRateiPassivi
            // 
            this.chkRateiPassivi.AutoSize = true;
            this.chkRateiPassivi.Location = new System.Drawing.Point(6, 40);
            this.chkRateiPassivi.Name = "chkRateiPassivi";
            this.chkRateiPassivi.Size = new System.Drawing.Size(87, 17);
            this.chkRateiPassivi.TabIndex = 1;
            this.chkRateiPassivi.Tag = "account.flagaccountusage:1";
            this.chkRateiPassivi.Text = "Ratei Passivi";
            this.chkRateiPassivi.UseVisualStyleBackColor = true;
            // 
            // chkRateiAttivi
            // 
            this.chkRateiAttivi.AutoSize = true;
            this.chkRateiAttivi.Location = new System.Drawing.Point(6, 20);
            this.chkRateiAttivi.Name = "chkRateiAttivi";
            this.chkRateiAttivi.Size = new System.Drawing.Size(77, 17);
            this.chkRateiAttivi.TabIndex = 0;
            this.chkRateiAttivi.Tag = "account.flagaccountusage:0";
            this.chkRateiAttivi.Text = "Ratei Attivi";
            this.chkRateiAttivi.UseVisualStyleBackColor = true;
            // 
            // btnSuddivUPB
            // 
            this.btnSuddivUPB.Location = new System.Drawing.Point(413, 19);
            this.btnSuddivUPB.Name = "btnSuddivUPB";
            this.btnSuddivUPB.Size = new System.Drawing.Size(139, 23);
            this.btnSuddivUPB.TabIndex = 39;
            this.btnSuddivUPB.Text = "Suddivisione nelle UPB";
            this.btnSuddivUPB.UseVisualStyleBackColor = true;
            this.btnSuddivUPB.Click += new System.EventHandler(this.btnSuddivUPB_Click);
            // 
            // gboxConto
            // 
            this.gboxConto.Controls.Add(this.txtDenominazioneConto);
            this.gboxConto.Controls.Add(this.txtCodiceConto);
            this.gboxConto.Controls.Add(this.button1);
            this.gboxConto.Location = new System.Drawing.Point(11, 427);
            this.gboxConto.Name = "gboxConto";
            this.gboxConto.Size = new System.Drawing.Size(375, 89);
            this.gboxConto.TabIndex = 38;
            this.gboxConto.TabStop = false;
            this.gboxConto.Tag = "AutoManage.txtCodiceConto.tree";
            this.gboxConto.Text = "Contabilità speciale su impegni di budget (in base a UPB)";
            // 
            // txtDenominazioneConto
            // 
            this.txtDenominazioneConto.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDenominazioneConto.Location = new System.Drawing.Point(126, 16);
            this.txtDenominazioneConto.Multiline = true;
            this.txtDenominazioneConto.Name = "txtDenominazioneConto";
            this.txtDenominazioneConto.ReadOnly = true;
            this.txtDenominazioneConto.Size = new System.Drawing.Size(244, 39);
            this.txtDenominazioneConto.TabIndex = 2;
            this.txtDenominazioneConto.TabStop = false;
            this.txtDenominazioneConto.Tag = "accountspecial.title";
            // 
            // txtCodiceConto
            // 
            this.txtCodiceConto.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCodiceConto.Location = new System.Drawing.Point(6, 61);
            this.txtCodiceConto.Name = "txtCodiceConto";
            this.txtCodiceConto.Size = new System.Drawing.Size(364, 20);
            this.txtCodiceConto.TabIndex = 1;
            this.txtCodiceConto.Tag = "accountspecial.codeacc?x";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(6, 32);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(88, 23);
            this.button1.TabIndex = 0;
            this.button1.TabStop = false;
            this.button1.Tag = "manage.accountspecial.tree";
            this.button1.Text = "Conto";
            // 
            // chkCdOrdine
            // 
            this.chkCdOrdine.Location = new System.Drawing.Point(274, 36);
            this.chkCdOrdine.Name = "chkCdOrdine";
            this.chkCdOrdine.Size = new System.Drawing.Size(100, 24);
            this.chkCdOrdine.TabIndex = 37;
            this.chkCdOrdine.Tag = "account.flag:2";
            this.chkCdOrdine.Text = "Conto d\'Ordine";
            // 
            // grpEpilogo
            // 
            this.grpEpilogo.Controls.Add(this.checkBox14);
            this.grpEpilogo.Controls.Add(this.checkBox2);
            this.grpEpilogo.Controls.Add(this.checkBox1);
            this.grpEpilogo.Location = new System.Drawing.Point(392, 243);
            this.grpEpilogo.Name = "grpEpilogo";
            this.grpEpilogo.Size = new System.Drawing.Size(306, 61);
            this.grpEpilogo.TabIndex = 36;
            this.grpEpilogo.TabStop = false;
            this.grpEpilogo.Text = "Nella generazione delle scritture di epilogo";
            // 
            // checkBox14
            // 
            this.checkBox14.AutoSize = true;
            this.checkBox14.Location = new System.Drawing.Point(6, 39);
            this.checkBox14.Name = "checkBox14";
            this.checkBox14.Size = new System.Drawing.Size(120, 17);
            this.checkBox14.TabIndex = 3;
            this.checkBox14.Tag = "account.flag:3";
            this.checkBox14.Text = "Ignora Mov. Budget";
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(159, 16);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(81, 17);
            this.checkBox2.TabIndex = 2;
            this.checkBox2.Tag = "account.flag:1";
            this.checkBox2.Text = "Ignora UPB";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(6, 16);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(133, 17);
            this.checkBox1.TabIndex = 1;
            this.checkBox1.Tag = "account.flag:0";
            this.checkBox1.Text = "Ignora cliente/fornitore";
            // 
            // btnSituazione
            // 
            this.btnSituazione.Location = new System.Drawing.Point(446, 48);
            this.btnSituazione.Name = "btnSituazione";
            this.btnSituazione.Size = new System.Drawing.Size(75, 23);
            this.btnSituazione.TabIndex = 35;
            this.btnSituazione.Text = "Situazione";
            this.btnSituazione.UseVisualStyleBackColor = true;
            this.btnSituazione.Click += new System.EventHandler(this.btnSituazione_Click);
            // 
            // chkCompetency
            // 
            this.chkCompetency.Location = new System.Drawing.Point(274, 6);
            this.chkCompetency.Name = "chkCompetency";
            this.chkCompetency.Size = new System.Drawing.Size(100, 24);
            this.chkCompetency.TabIndex = 34;
            this.chkCompetency.Tag = "account.flagcompetency:S:N";
            this.chkCompetency.Text = "Competenza";
            // 
            // grpProfitLoss
            // 
            this.grpProfitLoss.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.grpProfitLoss.Controls.Add(this.chkPerdita);
            this.grpProfitLoss.Controls.Add(this.chkUtile);
            this.grpProfitLoss.Location = new System.Drawing.Point(622, 149);
            this.grpProfitLoss.Name = "grpProfitLoss";
            this.grpProfitLoss.Size = new System.Drawing.Size(81, 86);
            this.grpProfitLoss.TabIndex = 33;
            this.grpProfitLoss.TabStop = false;
            // 
            // chkPerdita
            // 
            this.chkPerdita.Location = new System.Drawing.Point(8, 45);
            this.chkPerdita.Name = "chkPerdita";
            this.chkPerdita.Size = new System.Drawing.Size(72, 24);
            this.chkPerdita.TabIndex = 1;
            this.chkPerdita.Tag = "account.flagloss:S:N";
            this.chkPerdita.Text = "Perdita";
            // 
            // chkUtile
            // 
            this.chkUtile.Location = new System.Drawing.Point(8, 15);
            this.chkUtile.Name = "chkUtile";
            this.chkUtile.Size = new System.Drawing.Size(60, 24);
            this.chkUtile.TabIndex = 0;
            this.chkUtile.Tag = "account.flagprofit:S:N";
            this.chkUtile.Text = "Utile";
            // 
            // grbPlaccount
            // 
            this.grbPlaccount.Controls.Add(this.txtCodiceEconomico);
            this.grbPlaccount.Controls.Add(this.btnPlaccount);
            this.grbPlaccount.Controls.Add(this.txtPlaccounttitle);
            this.grbPlaccount.Controls.Add(this.chkSegnoCE);
            this.grbPlaccount.Location = new System.Drawing.Point(11, 337);
            this.grbPlaccount.Name = "grbPlaccount";
            this.grbPlaccount.Size = new System.Drawing.Size(375, 88);
            this.grbPlaccount.TabIndex = 29;
            this.grbPlaccount.TabStop = false;
            this.grbPlaccount.Tag = "AutoManage.txtCodiceEconomico.tree";
            this.grbPlaccount.Text = "Conto Economico";
            // 
            // btnPlaccount
            // 
            this.btnPlaccount.Location = new System.Drawing.Point(8, 16);
            this.btnPlaccount.Name = "btnPlaccount";
            this.btnPlaccount.Size = new System.Drawing.Size(128, 24);
            this.btnPlaccount.TabIndex = 3;
            this.btnPlaccount.Tag = "manage.placcount.tree";
            this.btnPlaccount.Text = "Conto Economico";
            // 
            // txtPlaccounttitle
            // 
            this.txtPlaccounttitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPlaccounttitle.Location = new System.Drawing.Point(152, 16);
            this.txtPlaccounttitle.Multiline = true;
            this.txtPlaccounttitle.Name = "txtPlaccounttitle";
            this.txtPlaccounttitle.Size = new System.Drawing.Size(215, 68);
            this.txtPlaccounttitle.TabIndex = 2;
            this.txtPlaccounttitle.Tag = "placcount.title";
            // 
            // chkSegnoCE
            // 
            this.chkSegnoCE.Location = new System.Drawing.Point(8, 64);
            this.chkSegnoCE.Name = "chkSegnoCE";
            this.chkSegnoCE.Size = new System.Drawing.Size(104, 16);
            this.chkSegnoCE.TabIndex = 3;
            this.chkSegnoCE.Tag = "account.placcount_sign:S:N";
            this.chkSegnoCE.Text = "Segno Positivo";
            // 
            // grbPatrimony
            // 
            this.grbPatrimony.Controls.Add(this.txtCodicePatrimoniale);
            this.grbPatrimony.Controls.Add(this.txtPatrimonytitle);
            this.grbPatrimony.Controls.Add(this.btnPatrimony);
            this.grbPatrimony.Controls.Add(this.chkSegnoSP);
            this.grbPatrimony.Location = new System.Drawing.Point(11, 243);
            this.grbPatrimony.Name = "grbPatrimony";
            this.grbPatrimony.Size = new System.Drawing.Size(375, 88);
            this.grbPatrimony.TabIndex = 28;
            this.grbPatrimony.TabStop = false;
            this.grbPatrimony.Tag = "AutoManage.txtCodicePatrimoniale.tree";
            this.grbPatrimony.Text = "Stato Patrimoniale";
            // 
            // txtPatrimonytitle
            // 
            this.txtPatrimonytitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPatrimonytitle.Location = new System.Drawing.Point(152, 16);
            this.txtPatrimonytitle.Multiline = true;
            this.txtPatrimonytitle.Name = "txtPatrimonytitle";
            this.txtPatrimonytitle.Size = new System.Drawing.Size(215, 68);
            this.txtPatrimonytitle.TabIndex = 2;
            this.txtPatrimonytitle.Tag = "patrimony.title";
            // 
            // btnPatrimony
            // 
            this.btnPatrimony.Location = new System.Drawing.Point(8, 16);
            this.btnPatrimony.Name = "btnPatrimony";
            this.btnPatrimony.Size = new System.Drawing.Size(128, 24);
            this.btnPatrimony.TabIndex = 0;
            this.btnPatrimony.Tag = "manage.patrimony.tree";
            this.btnPatrimony.Text = "Stato Patrimoniale";
            // 
            // chkSegnoSP
            // 
            this.chkSegnoSP.Location = new System.Drawing.Point(8, 64);
            this.chkSegnoSP.Name = "chkSegnoSP";
            this.chkSegnoSP.Size = new System.Drawing.Size(104, 16);
            this.chkSegnoSP.TabIndex = 2;
            this.chkSegnoSP.Tag = "account.patrimony_sign:S:N";
            this.chkSegnoSP.Text = "Segno Positivo";
            // 
            // gboxOperativo
            // 
            this.gboxOperativo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gboxOperativo.Controls.Add(this.checkBox15);
            this.gboxOperativo.Controls.Add(this.chkBoxEnableBudget);
            this.gboxOperativo.Controls.Add(this.label1);
            this.gboxOperativo.Controls.Add(this.cmbAccountKind);
            this.gboxOperativo.Controls.Add(this.chkRegistry);
            this.gboxOperativo.Controls.Add(this.chkUPB);
            this.gboxOperativo.Location = new System.Drawing.Point(8, 149);
            this.gboxOperativo.Name = "gboxOperativo";
            this.gboxOperativo.Size = new System.Drawing.Size(613, 88);
            this.gboxOperativo.TabIndex = 27;
            this.gboxOperativo.TabStop = false;
            this.gboxOperativo.Text = "Dettagli per i conti operativi";
            // 
            // checkBox15
            // 
            this.checkBox15.AutoSize = true;
            this.checkBox15.Location = new System.Drawing.Point(317, 42);
            this.checkBox15.Name = "checkBox15";
            this.checkBox15.Size = new System.Drawing.Size(291, 17);
            this.checkBox15.TabIndex = 42;
            this.checkBox15.Tag = "account.flag:4";
            this.checkBox15.Text = "Mov. budget non atteso nelle scritture (per diagnostiche)";
            // 
            // chkBoxEnableBudget
            // 
            this.chkBoxEnableBudget.AutoSize = true;
            this.chkBoxEnableBudget.Location = new System.Drawing.Point(8, 44);
            this.chkBoxEnableBudget.Name = "chkBoxEnableBudget";
            this.chkBoxEnableBudget.Size = new System.Drawing.Size(143, 17);
            this.chkBoxEnableBudget.TabIndex = 41;
            this.chkBoxEnableBudget.Tag = "account.flagenablebudgetprev:S:N";
            this.chkBoxEnableBudget.Text = "Abilita Previsione Budget";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(8, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 23);
            this.label1.TabIndex = 22;
            this.label1.Text = "Tipo conto";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbAccountKind
            // 
            this.cmbAccountKind.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbAccountKind.DataSource = this.DS.accountkind;
            this.cmbAccountKind.DisplayMember = "description";
            this.cmbAccountKind.Location = new System.Drawing.Point(88, 19);
            this.cmbAccountKind.Name = "cmbAccountKind";
            this.cmbAccountKind.Size = new System.Drawing.Size(517, 21);
            this.cmbAccountKind.TabIndex = 23;
            this.cmbAccountKind.Tag = "account.idaccountkind";
            this.cmbAccountKind.ValueMember = "idaccountkind";
            // 
            // chkRegistry
            // 
            this.chkRegistry.AutoSize = true;
            this.chkRegistry.Location = new System.Drawing.Point(8, 65);
            this.chkRegistry.Name = "chkRegistry";
            this.chkRegistry.Size = new System.Drawing.Size(292, 17);
            this.chkRegistry.TabIndex = 21;
            this.chkRegistry.Tag = "account.flagregistry:S:N";
            this.chkRegistry.Text = "Registra il cliente/fornitore nella scrittura in partita doppia";
            // 
            // chkUPB
            // 
            this.chkUPB.AutoSize = true;
            this.chkUPB.Location = new System.Drawing.Point(317, 65);
            this.chkUPB.Name = "chkUPB";
            this.chkUPB.Size = new System.Drawing.Size(237, 17);
            this.chkUPB.TabIndex = 24;
            this.chkUPB.Tag = "account.flagupb:S:N";
            this.chkUPB.Text = "Registra l\'UPB nella scrittura in partita doppia";
            // 
            // lblLivello
            // 
            this.lblLivello.Location = new System.Drawing.Point(32, 8);
            this.lblLivello.Name = "lblLivello";
            this.lblLivello.Size = new System.Drawing.Size(54, 14);
            this.lblLivello.TabIndex = 26;
            this.lblLivello.Text = "Livello:";
            this.lblLivello.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbLivello
            // 
            this.cmbLivello.DataSource = this.DS.accountlevel;
            this.cmbLivello.DisplayMember = "description";
            this.cmbLivello.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLivello.Location = new System.Drawing.Point(96, 8);
            this.cmbLivello.Name = "cmbLivello";
            this.cmbLivello.Size = new System.Drawing.Size(160, 21);
            this.cmbLivello.TabIndex = 25;
            this.cmbLivello.Tag = "account.nlevel";
            this.cmbLivello.ValueMember = "nlevel";
            // 
            // txtOrdineStampa
            // 
            this.txtOrdineStampa.Location = new System.Drawing.Point(96, 72);
            this.txtOrdineStampa.Name = "txtOrdineStampa";
            this.txtOrdineStampa.Size = new System.Drawing.Size(160, 20);
            this.txtOrdineStampa.TabIndex = 2;
            this.txtOrdineStampa.Tag = "account.printingorder";
            // 
            // lblOrdineStampa
            // 
            this.lblOrdineStampa.Location = new System.Drawing.Point(8, 72);
            this.lblOrdineStampa.Name = "lblOrdineStampa";
            this.lblOrdineStampa.Size = new System.Drawing.Size(88, 24);
            this.lblOrdineStampa.TabIndex = 20;
            this.lblOrdineStampa.Text = "Ordine stampa:";
            this.lblOrdineStampa.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDenominazione
            // 
            this.txtDenominazione.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDenominazione.Location = new System.Drawing.Point(102, 96);
            this.txtDenominazione.Multiline = true;
            this.txtDenominazione.Name = "txtDenominazione";
            this.txtDenominazione.Size = new System.Drawing.Size(454, 47);
            this.txtDenominazione.TabIndex = 4;
            this.txtDenominazione.Tag = "account.title";
            // 
            // lblDenominazione
            // 
            this.lblDenominazione.Location = new System.Drawing.Point(8, 96);
            this.lblDenominazione.Name = "lblDenominazione";
            this.lblDenominazione.Size = new System.Drawing.Size(88, 24);
            this.lblDenominazione.TabIndex = 18;
            this.lblDenominazione.Text = "Denominazione:";
            this.lblDenominazione.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtCodice
            // 
            this.txtCodice.Location = new System.Drawing.Point(96, 40);
            this.txtCodice.Name = "txtCodice";
            this.txtCodice.Size = new System.Drawing.Size(160, 20);
            this.txtCodice.TabIndex = 1;
            this.txtCodice.Tag = "account.codeacc";
            // 
            // lblCodice
            // 
            this.lblCodice.Location = new System.Drawing.Point(32, 40);
            this.lblCodice.Name = "lblCodice";
            this.lblCodice.Size = new System.Drawing.Size(56, 24);
            this.lblCodice.TabIndex = 15;
            this.lblCodice.Text = "Codice:";
            this.lblCodice.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tabBudget
            // 
            this.tabBudget.Controls.Add(this.dgPrevisione);
            this.tabBudget.Controls.Add(this.btnInsPrevisione);
            this.tabBudget.Controls.Add(this.btnEditPrevisione);
            this.tabBudget.Controls.Add(this.btnDelPrevisione);
            this.tabBudget.Controls.Add(this.groupBox2);
            this.tabBudget.Location = new System.Drawing.Point(4, 22);
            this.tabBudget.Name = "tabBudget";
            this.tabBudget.Size = new System.Drawing.Size(706, 622);
            this.tabBudget.TabIndex = 2;
            this.tabBudget.Text = "Budget";
            this.tabBudget.UseVisualStyleBackColor = true;
            // 
            // dgPrevisione
            // 
            this.dgPrevisione.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgPrevisione.DataMember = "";
            this.dgPrevisione.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dgPrevisione.Location = new System.Drawing.Point(104, 12);
            this.dgPrevisione.Name = "dgPrevisione";
            this.dgPrevisione.Size = new System.Drawing.Size(594, 312);
            this.dgPrevisione.TabIndex = 24;
            this.dgPrevisione.Tag = "accountyearview.previsionupb.previsionupb";
            // 
            // btnInsPrevisione
            // 
            this.btnInsPrevisione.Location = new System.Drawing.Point(12, 12);
            this.btnInsPrevisione.Name = "btnInsPrevisione";
            this.btnInsPrevisione.Size = new System.Drawing.Size(86, 26);
            this.btnInsPrevisione.TabIndex = 21;
            this.btnInsPrevisione.Tag = "insert.previsionupb";
            this.btnInsPrevisione.Text = "Inserisci";
            // 
            // btnEditPrevisione
            // 
            this.btnEditPrevisione.Location = new System.Drawing.Point(12, 44);
            this.btnEditPrevisione.Name = "btnEditPrevisione";
            this.btnEditPrevisione.Size = new System.Drawing.Size(86, 26);
            this.btnEditPrevisione.TabIndex = 22;
            this.btnEditPrevisione.Tag = "edit.previsionupb";
            this.btnEditPrevisione.Text = "Modifica";
            // 
            // btnDelPrevisione
            // 
            this.btnDelPrevisione.Location = new System.Drawing.Point(12, 76);
            this.btnDelPrevisione.Name = "btnDelPrevisione";
            this.btnDelPrevisione.Size = new System.Drawing.Size(86, 26);
            this.btnDelPrevisione.TabIndex = 23;
            this.btnDelPrevisione.Tag = "delete";
            this.btnDelPrevisione.Text = "Elimina";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.dgVariazioni);
            this.groupBox2.Location = new System.Drawing.Point(19, 330);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(679, 278);
            this.groupBox2.TabIndex = 25;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Variazioni Budget";
            // 
            // dgVariazioni
            // 
            this.dgVariazioni.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgVariazioni.DataMember = "";
            this.dgVariazioni.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dgVariazioni.Location = new System.Drawing.Point(6, 19);
            this.dgVariazioni.Name = "dgVariazioni";
            this.dgVariazioni.Size = new System.Drawing.Size(667, 249);
            this.dgVariazioni.TabIndex = 20;
            this.dgVariazioni.Tag = "accountvardetailview.account";
            // 
            // tabClassificazione
            // 
            this.tabClassificazione.Controls.Add(this.dGridClassSup);
            this.tabClassificazione.Controls.Add(this.btnElimina);
            this.tabClassificazione.Controls.Add(this.btnModifica);
            this.tabClassificazione.Controls.Add(this.btnInserisci);
            this.tabClassificazione.ImageIndex = 0;
            this.tabClassificazione.Location = new System.Drawing.Point(4, 22);
            this.tabClassificazione.Name = "tabClassificazione";
            this.tabClassificazione.Size = new System.Drawing.Size(706, 622);
            this.tabClassificazione.TabIndex = 1;
            this.tabClassificazione.Text = "Classificazione";
            this.tabClassificazione.Visible = false;
            // 
            // dGridClassSup
            // 
            this.dGridClassSup.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dGridClassSup.DataMember = "";
            this.dGridClassSup.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dGridClassSup.Location = new System.Drawing.Point(88, 9);
            this.dGridClassSup.Name = "dGridClassSup";
            this.dGridClassSup.Size = new System.Drawing.Size(610, 603);
            this.dGridClassSup.TabIndex = 17;
            this.dGridClassSup.Tag = "accountsorting.default.default";
            // 
            // btnElimina
            // 
            this.btnElimina.Location = new System.Drawing.Point(8, 72);
            this.btnElimina.Name = "btnElimina";
            this.btnElimina.Size = new System.Drawing.Size(72, 24);
            this.btnElimina.TabIndex = 16;
            this.btnElimina.Tag = "delete";
            this.btnElimina.Text = "Elimina";
            // 
            // btnModifica
            // 
            this.btnModifica.Location = new System.Drawing.Point(8, 40);
            this.btnModifica.Name = "btnModifica";
            this.btnModifica.Size = new System.Drawing.Size(72, 24);
            this.btnModifica.TabIndex = 15;
            this.btnModifica.Tag = "edit.single";
            this.btnModifica.Text = "Modifica";
            // 
            // btnInserisci
            // 
            this.btnInserisci.Location = new System.Drawing.Point(8, 8);
            this.btnInserisci.Name = "btnInserisci";
            this.btnInserisci.Size = new System.Drawing.Size(72, 24);
            this.btnInserisci.TabIndex = 14;
            this.btnInserisci.Tag = "insert.single";
            this.btnInserisci.Text = "Inserisci";
            // 
            // tabRiepilogo
            // 
            this.tabRiepilogo.Controls.Add(this.btnCalcolaTotali);
            this.tabRiepilogo.Controls.Add(this.tabControl1);
            this.tabRiepilogo.Location = new System.Drawing.Point(4, 22);
            this.tabRiepilogo.Name = "tabRiepilogo";
            this.tabRiepilogo.Padding = new System.Windows.Forms.Padding(3);
            this.tabRiepilogo.Size = new System.Drawing.Size(706, 622);
            this.tabRiepilogo.TabIndex = 3;
            this.tabRiepilogo.Text = "Riepilogo";
            this.tabRiepilogo.UseVisualStyleBackColor = true;
            // 
            // btnCalcolaTotali
            // 
            this.btnCalcolaTotali.Location = new System.Drawing.Point(6, 26);
            this.btnCalcolaTotali.Name = "btnCalcolaTotali";
            this.btnCalcolaTotali.Size = new System.Drawing.Size(105, 25);
            this.btnCalcolaTotali.TabIndex = 2;
            this.btnCalcolaTotali.Text = "Calcola totali";
            this.btnCalcolaTotali.UseVisualStyleBackColor = true;
            this.btnCalcolaTotali.Click += new System.EventHandler(this.btnCalcolaTotali_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(6, 67);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(697, 552);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnVarAccertamenti);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.txtVarAccertamenti);
            this.tabPage1.Controls.Add(this.txtVarPreaccertamenti);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.btnVarPreaccertamenti);
            this.tabPage1.Controls.Add(this.btnAccertamentiBudget);
            this.tabPage1.Controls.Add(this.label12);
            this.tabPage1.Controls.Add(this.txtAccertamentiBudget);
            this.tabPage1.Controls.Add(this.btnPreaccertamentiBudget);
            this.tabPage1.Controls.Add(this.label13);
            this.tabPage1.Controls.Add(this.txtPreaccertamentiBudget);
            this.tabPage1.Controls.Add(this.btnVarImpegni);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.txtVarImpegni);
            this.tabPage1.Controls.Add(this.txtVarPreimpegni);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.btnVarPreimpegni);
            this.tabPage1.Controls.Add(this.btnImpegniBudget);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.txtImpegniBudget);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.btnVarBudget);
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(this.txtVariazioniBudget);
            this.tabPage1.Controls.Add(this.label9);
            this.tabPage1.Controls.Add(this.txtBudgetDisponibile);
            this.tabPage1.Controls.Add(this.btnPreimpegniBudget);
            this.tabPage1.Controls.Add(this.label10);
            this.tabPage1.Controls.Add(this.txtPreimpegniBudget);
            this.tabPage1.Controls.Add(this.btnBudgetIniziale);
            this.tabPage1.Controls.Add(this.label11);
            this.tabPage1.Controls.Add(this.txtBudgetIniziale);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(689, 526);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Budget";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btnVarAccertamenti
            // 
            this.btnVarAccertamenti.Location = new System.Drawing.Point(483, 241);
            this.btnVarAccertamenti.Name = "btnVarAccertamenti";
            this.btnVarAccertamenti.Size = new System.Drawing.Size(76, 20);
            this.btnVarAccertamenti.TabIndex = 78;
            this.btnVarAccertamenti.Text = "F";
            this.btnVarAccertamenti.UseVisualStyleBackColor = true;
            this.btnVarAccertamenti.Click += new System.EventHandler(this.btnVarAccertamenti_Click);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(364, 220);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(196, 18);
            this.label2.TabIndex = 76;
            this.label2.Text = "Variazioni a accertamenti di Budget";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtVarAccertamenti
            // 
            this.txtVarAccertamenti.Location = new System.Drawing.Point(357, 241);
            this.txtVarAccertamenti.Name = "txtVarAccertamenti";
            this.txtVarAccertamenti.ReadOnly = true;
            this.txtVarAccertamenti.Size = new System.Drawing.Size(120, 20);
            this.txtVarAccertamenti.TabIndex = 77;
            this.txtVarAccertamenti.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtVarPreaccertamenti
            // 
            this.txtVarPreaccertamenti.Location = new System.Drawing.Point(358, 146);
            this.txtVarPreaccertamenti.Name = "txtVarPreaccertamenti";
            this.txtVarPreaccertamenti.ReadOnly = true;
            this.txtVarPreaccertamenti.Size = new System.Drawing.Size(120, 20);
            this.txtVarPreaccertamenti.TabIndex = 74;
            this.txtVarPreaccertamenti.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(361, 125);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(199, 18);
            this.label5.TabIndex = 73;
            this.label5.Text = "Variazioni a preaccertamenti di Budget";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnVarPreaccertamenti
            // 
            this.btnVarPreaccertamenti.Location = new System.Drawing.Point(484, 146);
            this.btnVarPreaccertamenti.Name = "btnVarPreaccertamenti";
            this.btnVarPreaccertamenti.Size = new System.Drawing.Size(76, 20);
            this.btnVarPreaccertamenti.TabIndex = 75;
            this.btnVarPreaccertamenti.Text = "D";
            this.btnVarPreaccertamenti.UseVisualStyleBackColor = true;
            this.btnVarPreaccertamenti.Click += new System.EventHandler(this.btnVarPreaccertamenti_Click);
            // 
            // btnAccertamentiBudget
            // 
            this.btnAccertamentiBudget.Location = new System.Drawing.Point(481, 192);
            this.btnAccertamentiBudget.Name = "btnAccertamentiBudget";
            this.btnAccertamentiBudget.Size = new System.Drawing.Size(75, 20);
            this.btnAccertamentiBudget.TabIndex = 72;
            this.btnAccertamentiBudget.Text = "E";
            this.btnAccertamentiBudget.UseVisualStyleBackColor = true;
            this.btnAccertamentiBudget.Click += new System.EventHandler(this.btnAccertamentiBudget_Click);
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(358, 175);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(198, 13);
            this.label12.TabIndex = 67;
            this.label12.Text = "Accertamenti di Budget";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtAccertamentiBudget
            // 
            this.txtAccertamentiBudget.Location = new System.Drawing.Point(354, 191);
            this.txtAccertamentiBudget.Name = "txtAccertamentiBudget";
            this.txtAccertamentiBudget.ReadOnly = true;
            this.txtAccertamentiBudget.Size = new System.Drawing.Size(121, 20);
            this.txtAccertamentiBudget.TabIndex = 71;
            this.txtAccertamentiBudget.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnPreaccertamentiBudget
            // 
            this.btnPreaccertamentiBudget.Location = new System.Drawing.Point(485, 102);
            this.btnPreaccertamentiBudget.Name = "btnPreaccertamentiBudget";
            this.btnPreaccertamentiBudget.Size = new System.Drawing.Size(75, 20);
            this.btnPreaccertamentiBudget.TabIndex = 70;
            this.btnPreaccertamentiBudget.Text = "C";
            this.btnPreaccertamentiBudget.UseVisualStyleBackColor = true;
            this.btnPreaccertamentiBudget.Click += new System.EventHandler(this.btnPreaccertamentiBudget_Click);
            // 
            // label13
            // 
            this.label13.Location = new System.Drawing.Point(362, 86);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(198, 13);
            this.label13.TabIndex = 68;
            this.label13.Text = "Preaccertamenti di Budget";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtPreaccertamentiBudget
            // 
            this.txtPreaccertamentiBudget.Location = new System.Drawing.Point(358, 101);
            this.txtPreaccertamentiBudget.Name = "txtPreaccertamentiBudget";
            this.txtPreaccertamentiBudget.ReadOnly = true;
            this.txtPreaccertamentiBudget.Size = new System.Drawing.Size(121, 20);
            this.txtPreaccertamentiBudget.TabIndex = 69;
            this.txtPreaccertamentiBudget.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnVarImpegni
            // 
            this.btnVarImpegni.Location = new System.Drawing.Point(242, 241);
            this.btnVarImpegni.Name = "btnVarImpegni";
            this.btnVarImpegni.Size = new System.Drawing.Size(76, 20);
            this.btnVarImpegni.TabIndex = 66;
            this.btnVarImpegni.Text = "F";
            this.btnVarImpegni.UseVisualStyleBackColor = true;
            this.btnVarImpegni.Click += new System.EventHandler(this.btnVarImpegni_Click_1);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(123, 220);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(196, 18);
            this.label4.TabIndex = 64;
            this.label4.Text = "Variazioni a impegni di Budget";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtVarImpegni
            // 
            this.txtVarImpegni.Location = new System.Drawing.Point(116, 241);
            this.txtVarImpegni.Name = "txtVarImpegni";
            this.txtVarImpegni.ReadOnly = true;
            this.txtVarImpegni.Size = new System.Drawing.Size(120, 20);
            this.txtVarImpegni.TabIndex = 65;
            this.txtVarImpegni.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtVarPreimpegni
            // 
            this.txtVarPreimpegni.Location = new System.Drawing.Point(117, 146);
            this.txtVarPreimpegni.Name = "txtVarPreimpegni";
            this.txtVarPreimpegni.ReadOnly = true;
            this.txtVarPreimpegni.Size = new System.Drawing.Size(120, 20);
            this.txtVarPreimpegni.TabIndex = 62;
            this.txtVarPreimpegni.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(120, 125);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(199, 18);
            this.label3.TabIndex = 61;
            this.label3.Text = "Variazioni a preimpegni di Budget";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnVarPreimpegni
            // 
            this.btnVarPreimpegni.Location = new System.Drawing.Point(243, 146);
            this.btnVarPreimpegni.Name = "btnVarPreimpegni";
            this.btnVarPreimpegni.Size = new System.Drawing.Size(76, 20);
            this.btnVarPreimpegni.TabIndex = 63;
            this.btnVarPreimpegni.Text = "D";
            this.btnVarPreimpegni.UseVisualStyleBackColor = true;
            this.btnVarPreimpegni.Click += new System.EventHandler(this.btnVarPreimpegni_Click);
            // 
            // btnImpegniBudget
            // 
            this.btnImpegniBudget.Location = new System.Drawing.Point(240, 192);
            this.btnImpegniBudget.Name = "btnImpegniBudget";
            this.btnImpegniBudget.Size = new System.Drawing.Size(75, 20);
            this.btnImpegniBudget.TabIndex = 37;
            this.btnImpegniBudget.Text = "E";
            this.btnImpegniBudget.UseVisualStyleBackColor = true;
            this.btnImpegniBudget.Click += new System.EventHandler(this.btnImpegniBudget_Click);
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(117, 175);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(198, 13);
            this.label6.TabIndex = 25;
            this.label6.Text = "Impegni di Budget";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtImpegniBudget
            // 
            this.txtImpegniBudget.Location = new System.Drawing.Point(113, 191);
            this.txtImpegniBudget.Name = "txtImpegniBudget";
            this.txtImpegniBudget.ReadOnly = true;
            this.txtImpegniBudget.Size = new System.Drawing.Size(121, 20);
            this.txtImpegniBudget.TabIndex = 36;
            this.txtImpegniBudget.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(415, 286);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(86, 13);
            this.label7.TabIndex = 39;
            this.label7.Text = "G = A + B - C - D";
            // 
            // btnVarBudget
            // 
            this.btnVarBudget.Location = new System.Drawing.Point(418, 45);
            this.btnVarBudget.Name = "btnVarBudget";
            this.btnVarBudget.Size = new System.Drawing.Size(75, 20);
            this.btnVarBudget.TabIndex = 33;
            this.btnVarBudget.Text = "B";
            this.btnVarBudget.UseVisualStyleBackColor = true;
            this.btnVarBudget.Click += new System.EventHandler(this.btnVarBudget_Click);
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(87, 47);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(198, 13);
            this.label8.TabIndex = 26;
            this.label8.Text = "Variazione Budget";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtVariazioniBudget
            // 
            this.txtVariazioniBudget.Location = new System.Drawing.Point(291, 45);
            this.txtVariazioniBudget.Name = "txtVariazioniBudget";
            this.txtVariazioniBudget.ReadOnly = true;
            this.txtVariazioniBudget.Size = new System.Drawing.Size(121, 20);
            this.txtVariazioniBudget.TabIndex = 32;
            this.txtVariazioniBudget.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(84, 285);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(198, 13);
            this.label9.TabIndex = 27;
            this.label9.Text = "Budget disponibile";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtBudgetDisponibile
            // 
            this.txtBudgetDisponibile.Location = new System.Drawing.Point(288, 283);
            this.txtBudgetDisponibile.Name = "txtBudgetDisponibile";
            this.txtBudgetDisponibile.ReadOnly = true;
            this.txtBudgetDisponibile.Size = new System.Drawing.Size(124, 20);
            this.txtBudgetDisponibile.TabIndex = 38;
            this.txtBudgetDisponibile.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnPreimpegniBudget
            // 
            this.btnPreimpegniBudget.Location = new System.Drawing.Point(244, 102);
            this.btnPreimpegniBudget.Name = "btnPreimpegniBudget";
            this.btnPreimpegniBudget.Size = new System.Drawing.Size(75, 20);
            this.btnPreimpegniBudget.TabIndex = 35;
            this.btnPreimpegniBudget.Text = "C";
            this.btnPreimpegniBudget.UseVisualStyleBackColor = true;
            this.btnPreimpegniBudget.Click += new System.EventHandler(this.btnPreimpegniBudget_Click);
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(121, 86);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(198, 13);
            this.label10.TabIndex = 28;
            this.label10.Text = "Preimpegni di Budget";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtPreimpegniBudget
            // 
            this.txtPreimpegniBudget.Location = new System.Drawing.Point(117, 101);
            this.txtPreimpegniBudget.Name = "txtPreimpegniBudget";
            this.txtPreimpegniBudget.ReadOnly = true;
            this.txtPreimpegniBudget.Size = new System.Drawing.Size(121, 20);
            this.txtPreimpegniBudget.TabIndex = 34;
            this.txtPreimpegniBudget.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnBudgetIniziale
            // 
            this.btnBudgetIniziale.Location = new System.Drawing.Point(418, 15);
            this.btnBudgetIniziale.Name = "btnBudgetIniziale";
            this.btnBudgetIniziale.Size = new System.Drawing.Size(75, 20);
            this.btnBudgetIniziale.TabIndex = 31;
            this.btnBudgetIniziale.Text = "A";
            this.btnBudgetIniziale.UseVisualStyleBackColor = true;
            this.btnBudgetIniziale.Click += new System.EventHandler(this.btnBudgetIniziale_Click);
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(87, 18);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(198, 13);
            this.label11.TabIndex = 29;
            this.label11.Text = "Budget iniziale";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtBudgetIniziale
            // 
            this.txtBudgetIniziale.Location = new System.Drawing.Point(291, 16);
            this.txtBudgetIniziale.Name = "txtBudgetIniziale";
            this.txtBudgetIniziale.ReadOnly = true;
            this.txtBudgetIniziale.Size = new System.Drawing.Size(121, 20);
            this.txtBudgetIniziale.TabIndex = 30;
            this.txtBudgetIniziale.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtCodicen
            // 
            this.txtCodicen.Location = new System.Drawing.Point(0, 0);
            this.txtCodicen.Name = "txtCodicen";
            this.txtCodicen.Size = new System.Drawing.Size(100, 20);
            this.txtCodicen.TabIndex = 0;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(0, 0);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 0;
            // 
            // txtCodicePatrimoniale
            // 
            this.txtCodicePatrimoniale.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCodicePatrimoniale.Location = new System.Drawing.Point(8, 41);
            this.txtCodicePatrimoniale.Name = "txtCodicePatrimoniale";
            this.txtCodicePatrimoniale.Size = new System.Drawing.Size(128, 20);
            this.txtCodicePatrimoniale.TabIndex = 3;
            this.txtCodicePatrimoniale.Tag = "patrimony.codepatrimony?x";
            // 
            // txtCodiceEconomico
            // 
            this.txtCodiceEconomico.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCodiceEconomico.Location = new System.Drawing.Point(8, 44);
            this.txtCodiceEconomico.Name = "txtCodiceEconomico";
            this.txtCodiceEconomico.Size = new System.Drawing.Size(128, 20);
            this.txtCodiceEconomico.TabIndex = 4;
            this.txtCodiceEconomico.Tag = "placcount.codeplaccount?x";
            // 
            // FrmAccount_default
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(968, 648);
            this.Controls.Add(this.MetaDataDetail);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.treeView1);
            this.Name = "FrmAccount_default";
            this.Text = "FrmAccount_default";
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.MetaDataDetail.ResumeLayout(false);
            this.tabPrincipale.ResumeLayout(false);
            this.tabPrincipale.PerformLayout();
            this.gboxBudgetInvestimenti.ResumeLayout(false);
            this.gboxBudgetInvestimenti.PerformLayout();
            this.gboxBudgetEconomico.ResumeLayout(false);
            this.gboxBudgetEconomico.PerformLayout();
            this.grpboxUtilizzoConto.ResumeLayout(false);
            this.grpboxUtilizzoConto.PerformLayout();
            this.gboxConto.ResumeLayout(false);
            this.gboxConto.PerformLayout();
            this.grpEpilogo.ResumeLayout(false);
            this.grpEpilogo.PerformLayout();
            this.grpProfitLoss.ResumeLayout(false);
            this.grbPlaccount.ResumeLayout(false);
            this.grbPlaccount.PerformLayout();
            this.grbPatrimony.ResumeLayout(false);
            this.grbPatrimony.PerformLayout();
            this.gboxOperativo.ResumeLayout(false);
            this.gboxOperativo.PerformLayout();
            this.tabBudget.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgPrevisione)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgVariazioni)).EndInit();
            this.tabClassificazione.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dGridClassSup)).EndInit();
            this.tabRiepilogo.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion

        CQueryHelper QHC;
        QueryHelper QHS;
		public void MetaData_AfterLink(){
			Meta = MetaData.GetMetaData(this);
            QHC = new CQueryHelper();
            QHS = Meta.Conn.GetQueryHelper();
            filteresercizio = QHS.CmpEq("ayear", Meta.GetSys("esercizio"));
			GetData.SetStaticFilter(DS.account, filteresercizio);
            GetData.SetStaticFilter(DS.accountspecial, filteresercizio);
            GetData.SetStaticFilter(DS.patrimony, filteresercizio);
            GetData.SetStaticFilter(DS.placcount, filteresercizio);
            GetData.SetSorting(DS.account, "printingorder");
			GetData.SetStaticFilter(DS.accountyear,filteresercizio);
            DataAccess.SetTableForReading(DS.accountspecial, "account");

            string Filteraccountyearview = "(isnull(coalesce(prevision,prevision2,prevision3,prevision4,prevision5),0)<>0)";
            GetData.SetStaticFilter(DS.accountyearview, Filteraccountyearview);
            QueryCreator.SetTableForPosting(DS.accountyearview, "accountyear");
            GetData.SetStaticFilter(DS.accountvardetailview, QHS.CmpEq("yvar", Meta.GetSys("esercizio")));
            GetData.SetSorting(DS.accountvardetailview, "nvar,rownum");
            DataAccess.SetTableForReading(DS.sorting_economico, "sorting");
            DataAccess.SetTableForReading(DS.sorting_investimenti, "sorting");
            ImpostaFiltriEconomicoInvestimenti();
            PostData.SetPostingOrder(DS.accountyearview, "idupb");
            btnSuddivUPB.Enabled = false;
            AbilitaBtnPrevisione(false);
		}

        public void ImpostaFiltriEconomicoInvestimenti(){
            object idsorkind = Meta.Conn.DO_READ_VALUE("sortingkind", QHS.CmpEq("codesorkind", "BUDGET_UFF"), "idsorkind");
            if ((idsorkind != null) && (idsorkind != DBNull.Value)) {
                string filterkind = QHS.CmpEq("idsorkind", idsorkind);
                GetData.SetStaticFilter(DS.sorting_economico, QHS.AppAnd(filterkind, QHS.Like("sortcode", "E%")));
                GetData.SetStaticFilter(DS.sorting_investimenti, QHS.AppAnd(filterkind, QHS.Like("sortcode", "I%")));

                DS.Tables["sorting_economico"].ExtendedProperties[MetaData.ExtraParams] = filterkind;
                DS.Tables["sorting_investimenti"].ExtendedProperties[MetaData.ExtraParams] = filterkind;
            }
            else {
                gboxBudgetEconomico.Enabled = false;
                gboxBudgetInvestimenti.Enabled = false;
            }
        }
		public void MetaData_AfterActivation() {
            //tExpenseSetup = DataAccess.RUN_SELECT(Meta.Conn, "config",
            //    "idsortingkind1,idsortingkind2,idsortingkind3", null, filteresercizio, null, null, true);
			
            //if ((tExpenseSetup == null) || (tExpenseSetup.Rows.Count == 0)) return;
            //gestisciBottoniSuddivisioni(tExpenseSetup.Rows[0]);
		}

        //private void gestisciBottoniSuddivisioni(DataRow rExpenseSetup) {
        //    int maxClass = 3;
        //    string field = "idsortingkind";
        //    for (int i = 1; i <= maxClass; i++) {
        //        if (rExpenseSetup[field + i] != DBNull.Value) {
        //            Button B = GetBtnByName("btnSudClass" + i.ToString());
        //            abilitaBottoniSuddivisioni(B);
        //            assegnaNomiBottoniSuddivisioni(B, rExpenseSetup[field + i]);
        //        }
        //    }
        //}

        //private void assegnaNomiBottoniSuddivisioni(Button btn, object idSorKind) {
        //    string filtro = QHS.CmpEq("idsorkind", idSorKind);
        //    object btnText = Meta.Conn.DO_READ_VALUE("sortingkind", filtro, "description");
        //    if (btnText == null) return;
        //    btn.Text = btnText.ToString();
        //}

        //private void abilitaBottoniSuddivisioni(Button btn) {
        //    btn.Enabled = true;
        //}

        void AbilitaBtnPrevisione(bool enable) {
            btnInsPrevisione.Enabled = enable;
            btnEditPrevisione.Enabled = enable;
            btnDelPrevisione.Enabled = enable;
        }


        public void MetaData_BeforePost() {
            impostaCampiDaSalvare(false);
        }

        public void MetaData_AfterPost() {
            impostaCampiDaSalvare(true);
            DataRow rBilancio = HelpForm.GetLastSelected(DS.account);
            if (rBilancio == null) return;
            object idacc = rBilancio["idacc"];
            string filter = QHS.CmpEq("idacc", idacc);
            string FilterFinyearview = "(isnull(prevision,0) <>0 or isnull(prevision2,0)<>0 or isnull(prevision3,0)<>0 or isnull(prevision4,0)<>0 or isnull(prevision5,0)<>0)";
            filter = QHS.AppAnd(FilterFinyearview, filter);

            Meta.Conn.RUN_SELECT_INTO_TABLE(DS.accountyearview, null, filter, null, true);
            Meta.FreshForm();
        }

        /// <summary>
        /// Metodo esclude i campi della vista ACCOUNTYEARVIEW non appartenenti alla tabella ACCOUNTYEAR in fase di salvataggio
        /// e li reinclude dopo aver salvato
        /// </summary>
        /// <param name="salva">TRUE: Campi salvabili; FALSE: Campi non salvabili</param>
        private void impostaCampiDaSalvare(bool salva) {
            string []field_accountyearview = new string[]{"account","codeacc","paridacc","upb","codeupb","paridupb","nlevel","leveldescr",
                "idsor01","idsor02","idsor03","idsor04","idsor05"};

            if (!salva){
                string empty = "";
                foreach (string field in field_accountyearview) {
                    QueryCreator.SetColumnNameForPosting(DS.accountyearview.Columns[field], empty);
                }
            }
            else{
                foreach (string field in field_accountyearview) {
                    QueryCreator.SetColumnNameForPosting(DS.accountyearview.Columns[field], field);
                }

               
            }
        }

		Button GetBtnByName(string Name){
			System.Reflection.FieldInfo Ctrl = this.GetType().GetField(Name);
			if (Ctrl==null) return null;
			if (!typeof(Button).IsAssignableFrom(Ctrl.FieldType)) return null;
			Button B =  (Button) Ctrl.GetValue(this);                        
			return B;
		}

		public void MetaData_AfterFill(){
            if (!Meta.CanInsert) {
                Meta.CanInsert = true;
                Meta.FreshToolBar();
            }
			//abilita/disabilita i controlli
			
			bool ModoInsert= Meta.InsertMode;
			cmbLivello.Enabled=false;
					
			if (ModoInsert){
				DataRow R = HelpForm.GetLastSelected(DS.account);
				if (R==null) return;
				txtCodice.ReadOnly = false;
				txtOrdineStampa.ReadOnly = false;
//				btnPatrimony.Enabled = true;
//				btnPlaccount.Enabled = true;
				if (Operativo(R)){
					EnableControls(true);
                    AbilitaBtnPrevisione(AbilitaBudgetPrev(R));
				}
				else{
					EnableControls(false);
				}
			}
            if (Meta.InsertMode) {
                AbilitaBottoni(false);
            }
            else {
                DataRow R = HelpForm.GetLastSelected(DS.account);
                if (R == null) return;
                if (Operativo(R)) {
                    AbilitaBottoni(true);
                }
                else {
                    AbilitaBottoni(false);
                    pulisciTextRiepilogo();
                }
            }
            btnSituazione.Enabled = !ModoInsert;
		}

        private void AbilitaBottoni(bool Enable) {
            btnBudgetIniziale.Enabled = Enable;
            btnVarBudget.Enabled = Enable;
            btnPreimpegniBudget.Enabled = Enable;
            btnVarImpegni.Enabled = Enable;
            btnVarPreimpegni.Enabled = Enable;
            btnImpegniBudget.Enabled = Enable;
            btnCalcolaTotali.Enabled = Enable;

            btnPreaccertamentiBudget.Enabled = Enable;
            btnVarAccertamenti.Enabled = Enable;
            btnVarPreaccertamenti.Enabled = Enable;
            btnAccertamentiBudget.Enabled = Enable;
        }

        private bool Operativo(DataRow R) {
            if (R == null) return false;
            int levelop = CfgFn.GetNoNullInt32(Meta.GetSys("accountusablelevel"));
            int thislevel = CfgFn.GetNoNullInt32(R["nlevel"]);
            if (thislevel < levelop) return false;
            return true;
        }

        private bool AbilitaBudgetPrev(DataRow R)
        {
            if (R == null) return false;
           
            object enable = R["flagenablebudgetprev"];
            if (enable != DBNull.Value)
            {
                if (enable.ToString() == "N") return false;
            }
            
            return true;
        }

        //private bool Operativo(DataRow R) {
        //    if (R == null) return false;
        //    object livellorow = R["nlevel"];
        //    DataRow[] Res = DS.accountlevel.Select(QHC.AppAnd(QHC.CmpEq("nlevel", livellorow),
        //        filteresercizio));
        //    if (Res.Length != 1) return false;
        //    string operativo = Res[0]["flagusable"].ToString().ToUpper();
        //    if (operativo == "N") return false;
        //    return true;
        //}
		public void MetaData_AfterClear(){
			EnableControls(true);
			cmbLivello.Enabled = true;
			txtCodice.ReadOnly = false;
			txtOrdineStampa.ReadOnly = false;
            Meta.CanInsert = false;
//			btnPatrimony.Enabled = true;
//			btnPlaccount.Enabled = true;
            pulisciTextRiepilogo();
            btnSuddivUPB.Enabled = false;
            AbilitaBtnPrevisione(false);
            btnSituazione.Enabled = false;
            chkBoxEnableBudget.Visible = true;
        }

        private void pulisciTextRiepilogo() {
            txtBudgetIniziale.Text = "";
            txtVariazioniBudget.Text = "";
            txtPreimpegniBudget.Text = "";
            txtVarImpegni.Text = "";
            txtVarPreimpegni.Text = "";
            txtImpegniBudget.Text = "";
            txtBudgetDisponibile.Text = "";
            txtPreaccertamentiBudget.Text = "";
            txtAccertamentiBudget.Text = "";
            txtVarPreaccertamenti.Text = "";
            txtVarAccertamenti.Text = "";
        }

		public void MetaData_AfterRowSelect(DataTable T, DataRow R)
		{ 
			bool flagUtilePerdita = chkUtile.Checked || chkPerdita.Checked;
			if (R==null) return;
						
			if (T.TableName == "patrimony")	
			{
				if (!flagUtilePerdita) {
					txtPlaccounttitle.Text ="";
				}
				if (!(MetaData.Empty(this) || flagUtilePerdita)){
					DS.account.Rows[0]["idplaccount"]=DBNull.Value; 
				}
			}

			if (T.TableName == "placcount")
			{	
				if (!flagUtilePerdita) {
					txtPatrimonytitle.Text ="";
				}
				if (!(MetaData.Empty(this) || flagUtilePerdita)){
					DS.account.Rows[0]["idpatrimony"]=DBNull.Value; 
				}
			}

			if (T.TableName != "account") return;
            pulisciTextRiepilogo();
			bool ModoInsert=Meta.InsertMode;
			cmbLivello.Enabled=false;
            btnSituazione.Enabled = !ModoInsert;
			txtOrdineStampa.ReadOnly = false;
//			btnPatrimony.Enabled = true;
//			btnPlaccount.Enabled = true;
			if (Operativo(R))
			{
				EnableControls(true);
                AbilitaBtnPrevisione(AbilitaBudgetPrev(R));
                chkBoxEnableBudget.Visible = true;
                txtCodice.ReadOnly = (!ModoInsert);
			}
			else{
				EnableControls(false);
                chkBoxEnableBudget.Visible = false;
                txtCodice.ReadOnly = true;
			}
			
	}

		private void EnableControls(bool enable) {
			gboxOperativo.Visible=enable;
			grbPatrimony.Visible=enable;
			grbPlaccount.Visible=enable;
			grpProfitLoss.Visible = enable;
            grpEpilogo.Visible = enable;
            grpboxUtilizzoConto.Visible = enable;
            chkCdOrdine.Visible = enable;
            gboxConto.Visible = enable;
            AbilitaBtnPrevisione(enable);
            btnSuddivUPB.Enabled = enable;
			HelpForm.SetDenyNull(DS.account.Columns["idaccountkind"],enable);
            gboxBudgetEconomico.Visible = enable;
            gboxBudgetInvestimenti.Visible = enable;
		}

		private void btnSudClass1_Click(object sender, System.EventArgs e) {
			chiamaForm(1);
		}

		private void btnSudClass2_Click(object sender, System.EventArgs e) {
			chiamaForm(2);
		}

		private void btnSudClass3_Click(object sender, System.EventArgs e) {
			chiamaForm(3);
		}

		/// <summary>
		/// Metodo che richiama il form delle suddivisioni del conto in classificazioni
		/// </summary>
		/// <param name="nClass">Numero della classificazione tra le 3 configurate in expensesetup</param>
		private void chiamaForm(int nClass) {
			if (Meta.IsEmpty) return;
			DataRow contoRow = HelpForm.GetLastSelected(DS.account);
			if (contoRow == null)return;
			

			object idAcc = contoRow["idacc"];
			string field = "idsortingkind" + nClass;
            object idSorKind = Meta.Conn.GetSys("idsortingkind" + nClass);
			if (idSorKind.ToString() == "") return;
			string filterPassed = idAcc + "§" + idSorKind;
			DS.accountyear.ExtendedProperties[MetaData.ExtraParams] = filterPassed;
			Meta.Dispatcher.Edit(this.ParentForm,"accountyearview","default",false,filterPassed);
		}

        private void btnSituazione_Click(object sender, EventArgs e) {
            DataRow MyRow = HelpForm.GetLastSelected(DS.account);
            string esercizio = Meta.GetSys("esercizio").ToString();
            object idacc = esercizio.Substring(2);
            if (MyRow != null) {
                idacc = MyRow["idacc"];
            }
            Cursor = Cursors.WaitCursor;
            btnSituazione.Enabled = false;
            Application.DoEvents();
            DataSet Out = Meta.Conn.CallSP("show_account",
                new Object[2] {Meta.GetSys("datacontabile"),
								  idacc
							  }, false, 600
                );
            Cursor = Cursors.Default;
            btnSituazione.Enabled = true;
            Application.DoEvents();
            if (Out == null) return;
            if (Out.Tables.Count == 0) {
                string err = Meta.Conn.LastError;
                QueryCreator.ShowError(this, err, null);
                Meta.LogError(err);
                return;
            }
            Out.Tables[0].TableName = "Situazione conto";

            frmSituazioneViewer view = new frmSituazioneViewer(Out);
            view.Show();
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e) {
            if ((!Meta.IsEmpty) && (!Meta.CanInsert)) {
                Meta.CanInsert = true;
                Meta.FreshToolBar();
            }
        }

        private void btnSuddivUPB_Click(object sender, EventArgs e) {
            if (Meta.IsEmpty)
                return;
            DataRow accountRow = HelpForm.GetLastSelected(DS.account);
            if (accountRow == null)
                return;

            object idAccount = accountRow["idacc"];
            DS.accountyearview.ExtendedProperties[MetaData.ExtraParams] = idAccount;
            Meta.Dispatcher.Edit(this.ParentForm, "accountyearview", "default", false, idAccount);
        }

        private void btnCalcolaTotali_Click(object sender, EventArgs e) {
            decimal budgetIni = BudgetIniziale();
            txtBudgetIniziale.Text = budgetIni.ToString("c");
            decimal varBudget = VariazioniBudget();
            txtVariazioniBudget.Text = varBudget.ToString("c");
            decimal preImp = Impegni_Accertamenti_Budget("epexp", 1);
            txtPreimpegniBudget.Text = preImp.ToString("c");
            decimal varPreImp = VariazioniImpegni_Accertamenti_Budget("epexp", 1);
            txtVarPreimpegni.Text = varPreImp.ToString("c");
            txtImpegniBudget.Text = Impegni_Accertamenti_Budget("epexp", 2).ToString("c");
            txtVarImpegni.Text = VariazioniImpegni_Accertamenti_Budget("epexp", 2).ToString("c");

            decimal preAcc = Impegni_Accertamenti_Budget("epacc", 1);
            txtPreaccertamentiBudget.Text = preAcc.ToString("c"); 
            decimal varPreAcc = VariazioniImpegni_Accertamenti_Budget("epacc", 1);
            txtVarPreaccertamenti.Text = varPreAcc.ToString("c");

            txtAccertamentiBudget.Text = Impegni_Accertamenti_Budget("epacc", 2).ToString("c");
            txtVarAccertamenti.Text = VariazioniImpegni_Accertamenti_Budget("epacc", 2).ToString("c");

            txtBudgetDisponibile.Text = (budgetIni + varBudget - preImp - varPreImp  - preAcc - varPreAcc).ToString("c");
        }

        private decimal BudgetIniziale() {
            decimal valore;
            DataRow Curr = HelpForm.GetLastSelected(DS.account);
            if (Curr == null) return 0;
            int esercizioCurr = (int)Meta.GetSys("esercizio");

            string filter = QHS.CmpEq("ayear", Meta.GetSys("esercizio"));
            filter = QHS.AppAnd(filter, QHS.CmpEq("idacc", Curr["idacc"]));
            filter = QHS.AppAnd(filter, QHS.CmpNe("prevision", 0));

            filter = QHS.AppAnd(filter, Meta.Conn.SelectCondition("accountyearview", true));
            string strExpr = "SUM(prevision)";
            valore = CK(Meta.Conn.DO_READ_VALUE("accountyearview", filter, strExpr));
            return valore;
        }
        private Decimal CK(Object O) {
            if (O == DBNull.Value) return 0;
            return CfgFn.GetNoNullDecimal(O);
        }
        private decimal VariazioniBudget() {
            decimal valore;
            DataRow Curr = HelpForm.GetLastSelected(DS.account);
            if (Curr == null) return 0;
            string filter = QHS.CmpEq("yvar", Meta.GetSys("esercizio"));
            filter = QHS.AppAnd(filter, QHS.CmpEq("idaccountvarstatus", "5"));
            filter = QHS.AppAnd(filter, QHS.FieldInList("variationkind", "1,4"));
            filter = QHS.AppAnd(filter, QHS.CmpLe("adate", Meta.GetSys("datacontabile")));
            filter = QHS.AppAnd(filter, QHS.Like("idacc", Curr["idacc"].ToString() + "%"));
            filter = QHS.AppAnd(filter, Meta.Conn.SelectCondition("accountvardetailview", true));
            string strExpr = "SUM(amount)";
            valore = CK(Meta.Conn.DO_READ_VALUE("accountvardetailview", filter, strExpr));

            return valore;
        }
        private decimal Impegni_Accertamenti_Budget(string tablename, object nphase) {
            decimal valore;
            string Filter = "";
            DataRow Curr = HelpForm.GetLastSelected(DS.account);
            if (Curr == null) return 0;
            Filter = QHS.CmpEq("E.nphase", nphase);
            //Filter = QHS.AppAnd(Filter, QHS.CmpEq("E.yepexp", Meta.GetSys("esercizio")));
            Filter = QHS.AppAnd(Filter, QHS.CmpLe("E.adate", Meta.GetSys("datacontabile")));
            Filter = QHS.AppAnd(Filter, QHS.Like("EY.idacc", Curr["idacc"].ToString() + "%"));
            Filter = QHS.AppAnd(Filter, QHS.CmpEq("EY.ayear", Meta.GetSys("esercizio")));
            Filter = QHS.AppAnd(Filter, Meta.Conn.SelectCondition("upb", true));

         

            // quindi sommiamo gli amount degli impegni / accertamenti associati alla voce di bilancio corrente
            string sql = "SELECT SUM(CASE WHEN E.flagvariation = 'S' THEN - EY.amount  ELSE EY.amount END ) as amount from "+ tablename + "year EY " +
                         " JOIN " + tablename + " E on EY.id" + tablename + " = E.id" + tablename +   
                         " JOIN upb U on EY.idupb = U.idupb " +
                         " WHERE " + Filter;

            valore = CK(Meta.Conn.SQLRunner(sql, false).Rows[0]["amount"]);

            return valore;
        }

        

        private decimal VariazioniImpegni_Accertamenti_Budget(string tablename, object nphase) {
            decimal valore;
            string Filter = "";
            DataRow Curr = HelpForm.GetLastSelected(DS.account);
            if (Curr == null) return 0;

            // Aggiungiamo le var. dei suddetti impegni.
            Filter = QHS.CmpEq("E.nphase", nphase);
            //Filter = QHS.AppAnd(Filter, QHS.CmpEq("E.yepexp", Meta.GetSys("esercizio")));  8469
            Filter = QHS.AppAnd(Filter, QHS.CmpEq("EY.ayear", Meta.GetSys("esercizio")));
            Filter = QHS.AppAnd(Filter, QHS.Like("EY.idacc", Curr["idacc"].ToString() + "%"));
            Filter = QHS.AppAnd(Filter, QHS.CmpEq("EV.yvar", Meta.GetSys("esercizio")));
            Filter = QHS.AppAnd(Filter, QHS.CmpLe("EV.adate", Meta.GetSys("datacontabile")));
            Filter = QHS.AppAnd(Filter, Meta.Conn.SelectCondition("upb", true));

            string sql = "SELECT SUM(CASE WHEN E.flagvariation = 'S' THEN - EV.amount  ELSE EV.amount END )  as amount from " + tablename + "year EY " +
                         " JOIN " + tablename + " E on EY.id" + tablename + " = E.id" + tablename +
                         " JOIN " + tablename + "var EV on EV.id" + tablename + " = EY.id" + tablename +   
                         " JOIN upb U on EY.idupb = U.idupb " +
                         " WHERE " + Filter;

            valore = CK(Meta.Conn.SQLRunner(sql, false).Rows[0]["amount"]);
            return valore;
        }

        private void SelezionaVariazione(DataRow MyDR) {
            MetaData newAccVarDetail = Meta.Dispatcher.Get("accountvardetail");

            newAccVarDetail.Edit(this.ParentForm, "default", false);
            DataRow R2 = newAccVarDetail.SelectOne("lista",
                QHS.AppAnd(QHS.CmpEq("yvar", MyDR["yvar"]),
                QHS.CmpEq("nvar", MyDR["nvar"]), QHS.CmpEq("rownum", MyDR["rownum"])),
                "accountvardetail", null);
            if (R2 != null) newAccVarDetail.SelectRow(R2, "lista");
        }
        private void btnBudgetIniziale_Click(object sender, EventArgs e) {
            string VistaScelta;
            DataRow Curr = HelpForm.GetLastSelected(DS.account);
            if (Curr == null) return;
            int esercizioCurr = (int)Meta.GetSys("esercizio");

            //Previsione corrente (principale)
            string filter = QHS.CmpEq("ayear", Meta.GetSys("esercizio"));
            filter = QHS.AppAnd(filter, QHS.CmpEq("idacc", Curr["idacc"]));
            filter = QHS.AppAnd(filter, QHS.CmpNe("prevision", 0));

            VistaScelta = "accountyearview";
            MetaData MFinyearView = MetaData.GetMetaData(this, VistaScelta);
            MFinyearView.FilterLocked = true;
            MFinyearView.DS = DS;

            DataRow MyDR = MFinyearView.SelectOne("default", filter, null, null);

            if (MyDR != null) {

                SelezionaBudget(MyDR);
            }
        }
        private void SelezionaBudget(DataRow MyDR) {
            MetaData newAccyearView = Meta.Dispatcher.Get("accountyearview");
            newAccyearView.ExtraParameter = MyDR["idacc"];
            newAccyearView.Edit(this.ParentForm, "default", false);
            DataRow R2 = newAccyearView.SelectOne(newAccyearView.DefaultListType,
                 QHS.AppAnd(QHS.CmpEq("idacc", MyDR["idacc"]),
                               QHS.CmpEq("idupb", MyDR["idupb"])), "accountyearview", null);
            if (R2 != null)
                newAccyearView.SelectRow(R2, newAccyearView.DefaultListType);
        }

        private void btnPreimpegniBudget_Click(object sender, EventArgs e) {
            listImpegni_Accertamenti("epexp",1);
        }

        private void listImpegni_Accertamenti(string tablename, object nphase) {
            string Filter = "";
            DataRow Curr = HelpForm.GetLastSelected(DS.account);
            if (Curr == null) return;
            Filter = QHS.CmpEq("nphase", nphase);
            Filter = QHS.AppAnd(Filter, QHS.CmpEq("ayear", Meta.GetSys("esercizio")));
            Filter = QHS.AppAnd(Filter, QHS.CmpLe("adate", Meta.GetSys("datacontabile")));
            Filter = QHS.AppAnd(Filter, QHS.Like("idacc", Curr["idacc"].ToString() + "%"));

            string VistaScelta = tablename + "view";
            MetaData MImpegni = MetaData.GetMetaData(this, VistaScelta);
            MImpegni.FilterLocked = true;
            MImpegni.DS = DS;
            DataRow MyDR = MImpegni.SelectOne("default", Filter, null, null);
            if (MyDR != null) {
                MetaData newSpesa = Meta.Dispatcher.Get(tablename);
                newSpesa.Edit(this.ParentForm, "default", false);
                DataRow R2 = newSpesa.SelectOne(newSpesa.DefaultListType,
                    QHS.CmpEq("id" + tablename, MyDR["id" + tablename]), tablename, null);
                if (R2 != null) newSpesa.SelectRow(R2, newSpesa.DefaultListType);
            }
        }
        private void btnImpegniBudget_Click(object sender, EventArgs e) {
            listImpegni_Accertamenti("epexp", 2);
        }

        private void listVarImpegni_Accertamenti(string tablename, object nphase) {
            string idep = "";
            if (tablename == "epexpvar") {
                idep = "idepexp";
            }
            else {
                idep = "idepacc";
            }
            string Filter = "";
            DataRow Curr = HelpForm.GetLastSelected(DS.account);
            if (Curr == null) return;

            Filter = QHS.CmpEq("nphase", nphase);
            //Filter = QHS.AppAnd(Filter, QHS.CmpEq("E.yepexp", Meta.GetSys("esercizio")));  8469            
            Filter = QHS.AppAnd(Filter, QHS.Like("idacc", Curr["idacc"].ToString() + "%"));
            Filter = QHS.AppAnd(Filter, QHS.CmpEq("yvar", Meta.GetSys("esercizio")));
            Filter = QHS.AppAnd(Filter, QHS.CmpLe("adate", Meta.GetSys("datacontabile")));
            Filter = QHS.AppAnd(Filter, Meta.Conn.SelectCondition("upb", true));

            string VistaScelta = tablename+ "view";
            MetaData MVarImpegni = MetaData.GetMetaData(this, VistaScelta);
            MVarImpegni.FilterLocked = true;
            MVarImpegni.DS = DS;
            DataRow MyDR = MVarImpegni.SelectOne("budgetupb", Filter, null, null);
            if (MyDR != null) {
                MetaData newVarSpesa = Meta.Dispatcher.Get(tablename);
                newVarSpesa.Edit(this.ParentForm, "default", false);
                DataRow R2 = newVarSpesa.SelectOne(newVarSpesa.DefaultListType,
                    QHS.AppAnd(QHS.CmpEq(idep, MyDR[idep]), QHS.CmpEq("yvar", MyDR["yvar"]), QHS.CmpEq("nvar", MyDR["nvar"])), tablename, null);
                if (R2 != null)
                    newVarSpesa.SelectRow(R2, newVarSpesa.DefaultListType);
            }
        }

        private void btnVarImpegni_Click(object sender, EventArgs e) {
            listVarImpegni_Accertamenti("epexpvar", 2);
        }

        private void btnVarPreimpegni_Click(object sender, EventArgs e) {
            listVarImpegni_Accertamenti("epexpvar", 1);
        }

        private void btnPreaccertamentiBudget_Click(object sender, EventArgs e) {
            listImpegni_Accertamenti("epacc", 1);
        }

        private void btnVarPreaccertamenti_Click(object sender, EventArgs e) {
            listVarImpegni_Accertamenti("epaccvar", 1);
        }

        private void btnAccertamentiBudget_Click(object sender, EventArgs e) {
            listImpegni_Accertamenti("epacc", 2);
        }

        private void btnVarAccertamenti_Click(object sender, EventArgs e) {
            listVarImpegni_Accertamenti("epaccvar", 2);
        }

        private void btnVarImpegni_Click_1(object sender, EventArgs e) {
            listVarImpegni_Accertamenti("epexpvar", 2);
        }

        private void btnVarBudget_Click(object sender, EventArgs e) {
            DataRow Curr = HelpForm.GetLastSelected(DS.account);
            if (Curr == null)
                return;
            /*
             *  1	Normale
                2	Ripartizione
                3	Assestamento
                4	Storno
                5	Iniziale
             * */
            string filter = QHS.CmpEq("yvar", Meta.GetSys("esercizio"));
            filter = QHS.AppAnd(filter, QHS.CmpEq("idaccountvarstatus", "5"));
            filter = QHS.AppAnd(filter, QHS.FieldInList("variationkind", "1,3,4"));
            filter = QHS.AppAnd(filter, QHS.CmpLe("adate", Meta.GetSys("datacontabile")));
            filter = QHS.AppAnd(filter, QHS.Like("idacc", Curr["idacc"].ToString() + "%"));

            string VistaScelta = "accountvardetailview";
            MetaData MFinVarDetail = MetaData.GetMetaData(this, VistaScelta);
            MFinVarDetail.FilterLocked = true;
            MFinVarDetail.DS = DS;
            DataRow MyDR = MFinVarDetail.SelectOne("listaestesa", filter, null, null);

            if (MyDR != null) {
                SelezionaVariazione(MyDR);
            }
        }
    }
}