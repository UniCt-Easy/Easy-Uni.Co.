
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
using System.Data;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using metaeasylibrary;
using metadatalibrary;
using funzioni_configurazione;

namespace taxsetup_default//automatismiritenute//
{
	/// <summary>
	/// Summary description for frmautomatismiritenute.
	/// Revised (almost rewritten) By Nino on 5/2/2003
	/// </summary>
	public class Frm_taxsetup_default : MetaDataForm
	{
		private System.Windows.Forms.GroupBox grpBilancioSpesa;
		private System.Windows.Forms.TextBox txtDescrBilancioSpesa;
		private System.Windows.Forms.TextBox txtBilancioSpesa;
		private System.Windows.Forms.Button btnBilancioSpesa;
		private System.Windows.Forms.GroupBox grpBilancioEntrata;
		private System.Windows.Forms.TextBox txtDescrBilancioEntrata;
		private System.Windows.Forms.TextBox txtBilancioEntrata;
		private System.Windows.Forms.Button btnBilancioEntrata;
		private System.Windows.Forms.CheckBox chbImputare;
		private System.Windows.Forms.Button btnSpesaAcc;
		private System.Windows.Forms.GroupBox grpMovimentoSpesa;
		private System.Windows.Forms.Button btnBilancio;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.TextBox txtCreditoreDebitore;
		private System.Windows.Forms.GroupBox grpVersamento;
		private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labDay;
		private System.Windows.Forms.RadioButton rdbPeriodoPrec;
		private System.Windows.Forms.RadioButton rdbPeriodoCorr;
		private System.Windows.Forms.ComboBox cmbTipoRitenuta;
		public vistaForm DS;
		private System.Windows.Forms.TextBox txtBilancioVersamento;
		private System.Windows.Forms.TextBox txtGiornoScad;
		private System.Windows.Forms.GroupBox grpBilancioVersamento;
		private System.Windows.Forms.TextBox txtDescrBilancioVersamento;
		private System.ComponentModel.IContainer components;
		private System.Windows.Forms.ComboBox cmbTipoScadenza;
		private System.Windows.Forms.RadioButton rdoCreddeb;
		private System.Windows.Forms.GroupBox grpRegione;
		private System.Windows.Forms.Button btnDelete;
		private System.Windows.Forms.Button btnEdit;
		private System.Windows.Forms.Button btnInsert;
		private System.Windows.Forms.DataGrid gridRegione;
		private System.Windows.Forms.GroupBox grpPerc;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.DataGrid gridPerc;
		private System.Windows.Forms.RadioButton rdoPerc;
        private System.Windows.Forms.RadioButton rdoRegione;
		private System.Windows.Forms.ImageList imageList1;
        private GroupBox grpBilancioEntrataRit;
        private TextBox txtDescrBilancioEntrataRit;
        private TextBox txtBilancioEntrataRit;
        private Button btnBilancioEntrataRit;
        private GroupBox groupBox5;
        private GroupBox grpBilancioVersamentoRit;
        private TextBox txtDescrBilancioVersamentoRit;
        private TextBox txtBilancioVersamentoRit;
        private Button btnBilancioRit;
        private GroupBox groupBox6;
        private Label label3;
        private GroupBox groupBox1;
        private RadioButton radioButton27;
        private RadioButton radioButton26;
		MetaData Meta;
//		int bilancio;

		public Frm_taxsetup_default()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			DataAccess.SetTableForReading(DS.bilancioapplicazione,"finview");
			DataAccess.SetTableForReading(DS.bilanciocontributi,"finview");
			DataAccess.SetTableForReading(DS.bilancioversamento,"finview");
            DataAccess.SetTableForReading(DS.finincomeemploy, "finview");
            DataAccess.SetTableForReading(DS.finexpenseemploy, "finview");
			
			QueryCreator.SetTableForPosting(DS.taxregionsetupview,"taxregionsetup");
			QueryCreator.SetColumnNameForPosting(DS.taxregionsetupview.Columns["taxkind"],"");
			QueryCreator.SetColumnNameForPosting(DS.taxregionsetupview.Columns["place"],"");
			QueryCreator.SetColumnNameForPosting(DS.taxregionsetupview.Columns["regionalagencytitle"],"");

			QueryCreator.SetTableForPosting(DS.taxpaymentpartsetupview,"taxpaymentpartsetup");
			QueryCreator.SetColumnNameForPosting(DS.taxpaymentpartsetupview.Columns["taxkind"],"");
			QueryCreator.SetColumnNameForPosting(DS.taxpaymentpartsetupview.Columns["registry"],"");
            QueryCreator.SetColumnNameForPosting(DS.taxpaymentpartsetupview.Columns["taxref"], "");

            HelpForm.SetDenyNull(DS.taxsetup.Columns["taxpaykind"], true);
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_taxsetup_default));
            this.cmbTipoRitenuta = new System.Windows.Forms.ComboBox();
            this.DS = new taxsetup_default.vistaForm();
            this.btnSpesaAcc = new System.Windows.Forms.Button();
            this.grpBilancioSpesa = new System.Windows.Forms.GroupBox();
            this.chbImputare = new System.Windows.Forms.CheckBox();
            this.txtDescrBilancioSpesa = new System.Windows.Forms.TextBox();
            this.txtBilancioSpesa = new System.Windows.Forms.TextBox();
            this.btnBilancioSpesa = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.grpBilancioEntrata = new System.Windows.Forms.GroupBox();
            this.txtDescrBilancioEntrata = new System.Windows.Forms.TextBox();
            this.txtBilancioEntrata = new System.Windows.Forms.TextBox();
            this.btnBilancioEntrata = new System.Windows.Forms.Button();
            this.grpVersamento = new System.Windows.Forms.GroupBox();
            this.cmbTipoScadenza = new System.Windows.Forms.ComboBox();
            this.rdbPeriodoCorr = new System.Windows.Forms.RadioButton();
            this.rdbPeriodoPrec = new System.Windows.Forms.RadioButton();
            this.txtGiornoScad = new System.Windows.Forms.TextBox();
            this.labDay = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.grpMovimentoSpesa = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButton27 = new System.Windows.Forms.RadioButton();
            this.radioButton26 = new System.Windows.Forms.RadioButton();
            this.grpPerc = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.gridPerc = new System.Windows.Forms.DataGrid();
            this.grpRegione = new System.Windows.Forms.GroupBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnInsert = new System.Windows.Forms.Button();
            this.gridRegione = new System.Windows.Forms.DataGrid();
            this.rdoPerc = new System.Windows.Forms.RadioButton();
            this.rdoRegione = new System.Windows.Forms.RadioButton();
            this.rdoCreddeb = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtCreditoreDebitore = new System.Windows.Forms.TextBox();
            this.grpBilancioVersamento = new System.Windows.Forms.GroupBox();
            this.txtDescrBilancioVersamento = new System.Windows.Forms.TextBox();
            this.txtBilancioVersamento = new System.Windows.Forms.TextBox();
            this.btnBilancio = new System.Windows.Forms.Button();
            this.grpBilancioEntrataRit = new System.Windows.Forms.GroupBox();
            this.txtDescrBilancioEntrataRit = new System.Windows.Forms.TextBox();
            this.txtBilancioEntrataRit = new System.Windows.Forms.TextBox();
            this.btnBilancioEntrataRit = new System.Windows.Forms.Button();
            this.grpBilancioVersamentoRit = new System.Windows.Forms.GroupBox();
            this.txtDescrBilancioVersamentoRit = new System.Windows.Forms.TextBox();
            this.txtBilancioVersamentoRit = new System.Windows.Forms.TextBox();
            this.btnBilancioRit = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.grpBilancioSpesa.SuspendLayout();
            this.grpBilancioEntrata.SuspendLayout();
            this.grpVersamento.SuspendLayout();
            this.grpMovimentoSpesa.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.grpPerc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridPerc)).BeginInit();
            this.grpRegione.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridRegione)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.grpBilancioVersamento.SuspendLayout();
            this.grpBilancioEntrataRit.SuspendLayout();
            this.grpBilancioVersamentoRit.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbTipoRitenuta
            // 
            this.cmbTipoRitenuta.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbTipoRitenuta.DataSource = this.DS.tax;
            this.cmbTipoRitenuta.DisplayMember = "description";
            this.cmbTipoRitenuta.Location = new System.Drawing.Point(104, 7);
            this.cmbTipoRitenuta.Name = "cmbTipoRitenuta";
            this.cmbTipoRitenuta.Size = new System.Drawing.Size(576, 21);
            this.cmbTipoRitenuta.TabIndex = 1;
            this.cmbTipoRitenuta.Tag = "taxsetup.taxcode?taxsetupview.taxcode";
            this.cmbTipoRitenuta.ValueMember = "taxcode";
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.EnforceConstraints = false;
            this.DS.Locale = new System.Globalization.CultureInfo("en-US");
            // 
            // btnSpesaAcc
            // 
            this.btnSpesaAcc.BackColor = System.Drawing.SystemColors.Control;
            this.btnSpesaAcc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnSpesaAcc.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnSpesaAcc.Location = new System.Drawing.Point(8, 7);
            this.btnSpesaAcc.Name = "btnSpesaAcc";
            this.btnSpesaAcc.Size = new System.Drawing.Size(88, 23);
            this.btnSpesaAcc.TabIndex = 74;
            this.btnSpesaAcc.TabStop = false;
            this.btnSpesaAcc.Tag = "choose.tax.default";
            this.btnSpesaAcc.Text = "Ritenuta:";
            this.btnSpesaAcc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSpesaAcc.UseVisualStyleBackColor = false;
            // 
            // grpBilancioSpesa
            // 
            this.grpBilancioSpesa.Controls.Add(this.chbImputare);
            this.grpBilancioSpesa.Controls.Add(this.txtDescrBilancioSpesa);
            this.grpBilancioSpesa.Controls.Add(this.txtBilancioSpesa);
            this.grpBilancioSpesa.Controls.Add(this.btnBilancioSpesa);
            this.grpBilancioSpesa.Location = new System.Drawing.Point(8, 36);
            this.grpBilancioSpesa.Name = "grpBilancioSpesa";
            this.grpBilancioSpesa.Size = new System.Drawing.Size(288, 96);
            this.grpBilancioSpesa.TabIndex = 2;
            this.grpBilancioSpesa.TabStop = false;
            this.grpBilancioSpesa.Tag = "AutoManage.txtBilancioSpesa.treeSupb";
            this.grpBilancioSpesa.Text = "Movimento di spesa per applicazione CONTRIBUTI";
            // 
            // chbImputare
            // 
            this.chbImputare.Location = new System.Drawing.Point(8, 16);
            this.chbImputare.Name = "chbImputare";
            this.chbImputare.Size = new System.Drawing.Size(264, 16);
            this.chbImputare.TabIndex = 1;
            this.chbImputare.Tag = "taxsetup.flagadminfinance:S:N?taxsetupview.flagadminfinance:S:N";
            this.chbImputare.Text = "Non usare il capitolo del mov. principale";
            this.chbImputare.CheckedChanged += new System.EventHandler(this.chbImputare_CheckedChanged);
            // 
            // txtDescrBilancioSpesa
            // 
            this.txtDescrBilancioSpesa.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescrBilancioSpesa.Location = new System.Drawing.Point(136, 40);
            this.txtDescrBilancioSpesa.Multiline = true;
            this.txtDescrBilancioSpesa.Name = "txtDescrBilancioSpesa";
            this.txtDescrBilancioSpesa.ReadOnly = true;
            this.txtDescrBilancioSpesa.Size = new System.Drawing.Size(136, 48);
            this.txtDescrBilancioSpesa.TabIndex = 54;
            this.txtDescrBilancioSpesa.TabStop = false;
            this.txtDescrBilancioSpesa.Tag = "bilanciocontributi.title";
            // 
            // txtBilancioSpesa
            // 
            this.txtBilancioSpesa.Location = new System.Drawing.Point(8, 64);
            this.txtBilancioSpesa.Name = "txtBilancioSpesa";
            this.txtBilancioSpesa.Size = new System.Drawing.Size(112, 20);
            this.txtBilancioSpesa.TabIndex = 3;
            this.txtBilancioSpesa.Tag = "bilanciocontributi.codefin?taxsetupview.codefinadmintax";
            // 
            // btnBilancioSpesa
            // 
            this.btnBilancioSpesa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBilancioSpesa.ImageIndex = 0;
            this.btnBilancioSpesa.ImageList = this.imageList1;
            this.btnBilancioSpesa.Location = new System.Drawing.Point(8, 40);
            this.btnBilancioSpesa.Name = "btnBilancioSpesa";
            this.btnBilancioSpesa.Size = new System.Drawing.Size(72, 24);
            this.btnBilancioSpesa.TabIndex = 2;
            this.btnBilancioSpesa.TabStop = false;
            this.btnBilancioSpesa.Tag = "manage.bilanciocontributi.treeSupb";
            this.btnBilancioSpesa.Text = "Bilancio";
            this.btnBilancioSpesa.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBilancioSpesa.Click += new System.EventHandler(this.btnBilancioSpesa_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "");
            // 
            // grpBilancioEntrata
            // 
            this.grpBilancioEntrata.Controls.Add(this.txtDescrBilancioEntrata);
            this.grpBilancioEntrata.Controls.Add(this.txtBilancioEntrata);
            this.grpBilancioEntrata.Controls.Add(this.btnBilancioEntrata);
            this.grpBilancioEntrata.Location = new System.Drawing.Point(7, 16);
            this.grpBilancioEntrata.Name = "grpBilancioEntrata";
            this.grpBilancioEntrata.Size = new System.Drawing.Size(320, 72);
            this.grpBilancioEntrata.TabIndex = 1;
            this.grpBilancioEntrata.TabStop = false;
            this.grpBilancioEntrata.Tag = "AutoManage.txtBilancioEntrata.treeEupb";
            this.grpBilancioEntrata.Text = "Capitolo di entrata";
            // 
            // txtDescrBilancioEntrata
            // 
            this.txtDescrBilancioEntrata.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescrBilancioEntrata.Location = new System.Drawing.Point(144, 16);
            this.txtDescrBilancioEntrata.Multiline = true;
            this.txtDescrBilancioEntrata.Name = "txtDescrBilancioEntrata";
            this.txtDescrBilancioEntrata.ReadOnly = true;
            this.txtDescrBilancioEntrata.Size = new System.Drawing.Size(168, 48);
            this.txtDescrBilancioEntrata.TabIndex = 54;
            this.txtDescrBilancioEntrata.TabStop = false;
            this.txtDescrBilancioEntrata.Tag = "bilancioapplicazione.title";
            // 
            // txtBilancioEntrata
            // 
            this.txtBilancioEntrata.Location = new System.Drawing.Point(8, 40);
            this.txtBilancioEntrata.Name = "txtBilancioEntrata";
            this.txtBilancioEntrata.Size = new System.Drawing.Size(128, 20);
            this.txtBilancioEntrata.TabIndex = 1;
            this.txtBilancioEntrata.Tag = "bilancioapplicazione.codefin?taxsetupview.codefinincomecontra";
            // 
            // btnBilancioEntrata
            // 
            this.btnBilancioEntrata.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBilancioEntrata.ImageIndex = 0;
            this.btnBilancioEntrata.ImageList = this.imageList1;
            this.btnBilancioEntrata.Location = new System.Drawing.Point(8, 16);
            this.btnBilancioEntrata.Name = "btnBilancioEntrata";
            this.btnBilancioEntrata.Size = new System.Drawing.Size(72, 24);
            this.btnBilancioEntrata.TabIndex = 1;
            this.btnBilancioEntrata.TabStop = false;
            this.btnBilancioEntrata.Tag = "manage.bilancioapplicazione.treeEupb";
            this.btnBilancioEntrata.Text = "Bilancio";
            this.btnBilancioEntrata.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBilancioEntrata.Click += new System.EventHandler(this.btnBilancioEntrata_Click);
            // 
            // grpVersamento
            // 
            this.grpVersamento.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpVersamento.Controls.Add(this.cmbTipoScadenza);
            this.grpVersamento.Controls.Add(this.rdbPeriodoCorr);
            this.grpVersamento.Controls.Add(this.rdbPeriodoPrec);
            this.grpVersamento.Controls.Add(this.txtGiornoScad);
            this.grpVersamento.Controls.Add(this.labDay);
            this.grpVersamento.Controls.Add(this.label1);
            this.grpVersamento.Location = new System.Drawing.Point(296, 36);
            this.grpVersamento.Name = "grpVersamento";
            this.grpVersamento.Size = new System.Drawing.Size(384, 96);
            this.grpVersamento.TabIndex = 3;
            this.grpVersamento.TabStop = false;
            this.grpVersamento.Text = "Periodicità della liquidazione periodica";
            // 
            // cmbTipoScadenza
            // 
            this.cmbTipoScadenza.DataSource = this.DS.tmp_tiposcadenza;
            this.cmbTipoScadenza.DisplayMember = "descrizione";
            this.cmbTipoScadenza.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoScadenza.Location = new System.Drawing.Point(112, 24);
            this.cmbTipoScadenza.Name = "cmbTipoScadenza";
            this.cmbTipoScadenza.Size = new System.Drawing.Size(121, 21);
            this.cmbTipoScadenza.TabIndex = 1;
            this.cmbTipoScadenza.Tag = "";
            this.cmbTipoScadenza.ValueMember = "tiposcadenza";
            // 
            // rdbPeriodoCorr
            // 
            this.rdbPeriodoCorr.Location = new System.Drawing.Point(248, 56);
            this.rdbPeriodoCorr.Name = "rdbPeriodoCorr";
            this.rdbPeriodoCorr.Size = new System.Drawing.Size(128, 16);
            this.rdbPeriodoCorr.TabIndex = 4;
            this.rdbPeriodoCorr.Tag = "taxsetup.flag::#3";
            this.rdbPeriodoCorr.Text = "Periodo corrente";
            this.rdbPeriodoCorr.CheckedChanged += new System.EventHandler(this.rdbPeriodoCorr_CheckedChanged);
            // 
            // rdbPeriodoPrec
            // 
            this.rdbPeriodoPrec.Location = new System.Drawing.Point(248, 32);
            this.rdbPeriodoPrec.Name = "rdbPeriodoPrec";
            this.rdbPeriodoPrec.Size = new System.Drawing.Size(128, 16);
            this.rdbPeriodoPrec.TabIndex = 3;
            this.rdbPeriodoPrec.Tag = "taxsetup.flag::3";
            this.rdbPeriodoPrec.Text = "Periodo precedente";
            this.rdbPeriodoPrec.CheckedChanged += new System.EventHandler(this.rdbPeriodoPrec_CheckedChanged);
            // 
            // txtGiornoScad
            // 
            this.txtGiornoScad.Location = new System.Drawing.Point(112, 56);
            this.txtGiornoScad.Name = "txtGiornoScad";
            this.txtGiornoScad.Size = new System.Drawing.Size(48, 20);
            this.txtGiornoScad.TabIndex = 2;
            this.txtGiornoScad.Tag = "taxsetup.expiringday?taxsetupview.expiringday";
            // 
            // labDay
            // 
            this.labDay.Location = new System.Drawing.Point(16, 56);
            this.labDay.Name = "labDay";
            this.labDay.Size = new System.Drawing.Size(96, 16);
            this.labDay.TabIndex = 2;
            this.labDay.Text = "Giorno del mese:";
            this.labDay.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(8, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Periodicità:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // grpMovimentoSpesa
            // 
            this.grpMovimentoSpesa.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpMovimentoSpesa.Controls.Add(this.groupBox1);
            this.grpMovimentoSpesa.Controls.Add(this.grpPerc);
            this.grpMovimentoSpesa.Controls.Add(this.grpRegione);
            this.grpMovimentoSpesa.Controls.Add(this.rdoPerc);
            this.grpMovimentoSpesa.Controls.Add(this.rdoRegione);
            this.grpMovimentoSpesa.Controls.Add(this.rdoCreddeb);
            this.grpMovimentoSpesa.Controls.Add(this.groupBox3);
            this.grpMovimentoSpesa.Location = new System.Drawing.Point(8, 138);
            this.grpMovimentoSpesa.Name = "grpMovimentoSpesa";
            this.grpMovimentoSpesa.Size = new System.Drawing.Size(672, 228);
            this.grpMovimentoSpesa.TabIndex = 4;
            this.grpMovimentoSpesa.TabStop = false;
            this.grpMovimentoSpesa.Text = "Configurazione della liquidazione periodica";
            this.grpMovimentoSpesa.Enter += new System.EventHandler(this.grpMovimentoSpesa_Enter);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButton27);
            this.groupBox1.Controls.Add(this.radioButton26);
            this.groupBox1.Location = new System.Drawing.Point(400, 14);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(256, 58);
            this.groupBox1.TabIndex = 75;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Modello prodotto in Liquidazione";
            // 
            // radioButton27
            // 
            this.radioButton27.AutoSize = true;
            this.radioButton27.Location = new System.Drawing.Point(8, 35);
            this.radioButton27.Name = "radioButton27";
            this.radioButton27.Size = new System.Drawing.Size(57, 17);
            this.radioButton27.TabIndex = 2;
            this.radioButton27.TabStop = true;
            this.radioButton27.Tag = "taxsetup.taxpaykind:E";
            this.radioButton27.Text = "F24EP";
            this.radioButton27.UseVisualStyleBackColor = true;
            // 
            // radioButton26
            // 
            this.radioButton26.AutoSize = true;
            this.radioButton26.Location = new System.Drawing.Point(8, 16);
            this.radioButton26.Name = "radioButton26";
            this.radioButton26.Size = new System.Drawing.Size(43, 17);
            this.radioButton26.TabIndex = 1;
            this.radioButton26.TabStop = true;
            this.radioButton26.Tag = "taxsetup.taxpaykind:I";
            this.radioButton26.Text = "F24";
            this.radioButton26.UseVisualStyleBackColor = true;
            // 
            // grpPerc
            // 
            this.grpPerc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpPerc.Controls.Add(this.button1);
            this.grpPerc.Controls.Add(this.button2);
            this.grpPerc.Controls.Add(this.button3);
            this.grpPerc.Controls.Add(this.gridPerc);
            this.grpPerc.Location = new System.Drawing.Point(16, 120);
            this.grpPerc.Name = "grpPerc";
            this.grpPerc.Size = new System.Drawing.Size(640, 98);
            this.grpPerc.TabIndex = 5;
            this.grpPerc.TabStop = false;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(560, 68);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(72, 23);
            this.button1.TabIndex = 81;
            this.button1.TabStop = false;
            this.button1.Tag = "delete";
            this.button1.Text = "Elimina";
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Location = new System.Drawing.Point(560, 38);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(72, 23);
            this.button2.TabIndex = 80;
            this.button2.TabStop = false;
            this.button2.Tag = "edit.single";
            this.button2.Text = "Modifica";
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button3.Location = new System.Drawing.Point(560, 8);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(72, 23);
            this.button3.TabIndex = 79;
            this.button3.TabStop = false;
            this.button3.Tag = "insert.single";
            this.button3.Text = "Inserisci";
            // 
            // gridPerc
            // 
            this.gridPerc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridPerc.CaptionVisible = false;
            this.gridPerc.DataMember = "";
            this.gridPerc.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.gridPerc.Location = new System.Drawing.Point(8, 16);
            this.gridPerc.Name = "gridPerc";
            this.gridPerc.Size = new System.Drawing.Size(544, 75);
            this.gridPerc.TabIndex = 78;
            this.gridPerc.TabStop = false;
            this.gridPerc.Tag = "taxpaymentpartsetupview.enteesattore.single";
            // 
            // grpRegione
            // 
            this.grpRegione.Controls.Add(this.btnDelete);
            this.grpRegione.Controls.Add(this.btnEdit);
            this.grpRegione.Controls.Add(this.btnInsert);
            this.grpRegione.Controls.Add(this.gridRegione);
            this.grpRegione.Location = new System.Drawing.Point(16, 120);
            this.grpRegione.Name = "grpRegione";
            this.grpRegione.Size = new System.Drawing.Size(464, 98);
            this.grpRegione.TabIndex = 74;
            this.grpRegione.TabStop = false;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(384, 72);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(72, 23);
            this.btnDelete.TabIndex = 81;
            this.btnDelete.Tag = "delete";
            this.btnDelete.Text = "Elimina";
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(384, 40);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(72, 23);
            this.btnEdit.TabIndex = 80;
            this.btnEdit.Tag = "edit.single";
            this.btnEdit.Text = "Modifica";
            // 
            // btnInsert
            // 
            this.btnInsert.Location = new System.Drawing.Point(384, 8);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new System.Drawing.Size(72, 23);
            this.btnInsert.TabIndex = 79;
            this.btnInsert.Tag = "insert.single";
            this.btnInsert.Text = "Inserisci";
            // 
            // gridRegione
            // 
            this.gridRegione.CaptionVisible = false;
            this.gridRegione.DataMember = "";
            this.gridRegione.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.gridRegione.Location = new System.Drawing.Point(8, 16);
            this.gridRegione.Name = "gridRegione";
            this.gridRegione.Size = new System.Drawing.Size(368, 80);
            this.gridRegione.TabIndex = 78;
            this.gridRegione.Tag = "taxregionsetupview.enteesattore.single";
            // 
            // rdoPerc
            // 
            this.rdoPerc.Location = new System.Drawing.Point(24, 56);
            this.rdoPerc.Name = "rdoPerc";
            this.rdoPerc.Size = new System.Drawing.Size(456, 16);
            this.rdoPerc.TabIndex = 3;
            this.rdoPerc.Tag = "taxsetup.flag::2";
            this.rdoPerc.Text = "Ripartisci il mov. di spesa in base a ripartizione percentuale";
            this.rdoPerc.CheckedChanged += new System.EventHandler(this.rdoPerc_CheckedChanged);
            // 
            // rdoRegione
            // 
            this.rdoRegione.Location = new System.Drawing.Point(24, 40);
            this.rdoRegione.Name = "rdoRegione";
            this.rdoRegione.Size = new System.Drawing.Size(464, 16);
            this.rdoRegione.TabIndex = 2;
            this.rdoRegione.Tag = "taxsetup.flag::1";
            this.rdoRegione.Text = "Genera un mov. di spesa per ogni regione o provincia autonoma";
            this.rdoRegione.CheckedChanged += new System.EventHandler(this.rdoRegione_CheckedChanged);
            // 
            // rdoCreddeb
            // 
            this.rdoCreddeb.Location = new System.Drawing.Point(24, 24);
            this.rdoCreddeb.Name = "rdoCreddeb";
            this.rdoCreddeb.Size = new System.Drawing.Size(432, 16);
            this.rdoCreddeb.TabIndex = 1;
            this.rdoCreddeb.Tag = "taxsetup.flag::0";
            this.rdoCreddeb.Text = "Genera un unico movimento di spesa ";
            this.rdoCreddeb.CheckedChanged += new System.EventHandler(this.rdoCreddeb_CheckedChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.txtCreditoreDebitore);
            this.groupBox3.Location = new System.Drawing.Point(16, 72);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(640, 48);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Tag = "AutoChoose.txtCreditoreDebitore.lista.(active=\'S\')";
            this.groupBox3.Text = "Percipiente per la liquidazione periodica delle ritenute";
            // 
            // txtCreditoreDebitore
            // 
            this.txtCreditoreDebitore.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCreditoreDebitore.Location = new System.Drawing.Point(8, 16);
            this.txtCreditoreDebitore.Name = "txtCreditoreDebitore";
            this.txtCreditoreDebitore.Size = new System.Drawing.Size(624, 20);
            this.txtCreditoreDebitore.TabIndex = 50;
            this.txtCreditoreDebitore.Tag = "registry.title?taxsetupview.paymentagencytitle";
            // 
            // grpBilancioVersamento
            // 
            this.grpBilancioVersamento.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpBilancioVersamento.Controls.Add(this.txtDescrBilancioVersamento);
            this.grpBilancioVersamento.Controls.Add(this.txtBilancioVersamento);
            this.grpBilancioVersamento.Controls.Add(this.btnBilancio);
            this.grpBilancioVersamento.Location = new System.Drawing.Point(333, 17);
            this.grpBilancioVersamento.Name = "grpBilancioVersamento";
            this.grpBilancioVersamento.Size = new System.Drawing.Size(321, 72);
            this.grpBilancioVersamento.TabIndex = 2;
            this.grpBilancioVersamento.TabStop = false;
            this.grpBilancioVersamento.Tag = "AutoManage.txtBilancioVersamento.treesupb";
            this.grpBilancioVersamento.Text = "Capitolo di spesa, usato per la LIQUIDAZIONE PERIODICA";
            // 
            // txtDescrBilancioVersamento
            // 
            this.txtDescrBilancioVersamento.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescrBilancioVersamento.Location = new System.Drawing.Point(144, 16);
            this.txtDescrBilancioVersamento.Multiline = true;
            this.txtDescrBilancioVersamento.Name = "txtDescrBilancioVersamento";
            this.txtDescrBilancioVersamento.ReadOnly = true;
            this.txtDescrBilancioVersamento.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDescrBilancioVersamento.Size = new System.Drawing.Size(170, 48);
            this.txtDescrBilancioVersamento.TabIndex = 54;
            this.txtDescrBilancioVersamento.TabStop = false;
            this.txtDescrBilancioVersamento.Tag = "bilancioversamento.title";
            // 
            // txtBilancioVersamento
            // 
            this.txtBilancioVersamento.Location = new System.Drawing.Point(8, 40);
            this.txtBilancioVersamento.Name = "txtBilancioVersamento";
            this.txtBilancioVersamento.Size = new System.Drawing.Size(128, 20);
            this.txtBilancioVersamento.TabIndex = 1;
            this.txtBilancioVersamento.Tag = "bilancioversamento.codefin?taxsetupview.codefinexpensecontra";
            // 
            // btnBilancio
            // 
            this.btnBilancio.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBilancio.ImageIndex = 0;
            this.btnBilancio.ImageList = this.imageList1;
            this.btnBilancio.Location = new System.Drawing.Point(8, 16);
            this.btnBilancio.Name = "btnBilancio";
            this.btnBilancio.Size = new System.Drawing.Size(72, 24);
            this.btnBilancio.TabIndex = 1;
            this.btnBilancio.TabStop = false;
            this.btnBilancio.Tag = "manage.bilancioversamento.treeSupb";
            this.btnBilancio.Text = "Bilancio";
            this.btnBilancio.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBilancio.Click += new System.EventHandler(this.btnBilancio_Click);
            // 
            // grpBilancioEntrataRit
            // 
            this.grpBilancioEntrataRit.Controls.Add(this.txtDescrBilancioEntrataRit);
            this.grpBilancioEntrataRit.Controls.Add(this.txtBilancioEntrataRit);
            this.grpBilancioEntrataRit.Controls.Add(this.btnBilancioEntrataRit);
            this.grpBilancioEntrataRit.Location = new System.Drawing.Point(7, 16);
            this.grpBilancioEntrataRit.Name = "grpBilancioEntrataRit";
            this.grpBilancioEntrataRit.Size = new System.Drawing.Size(320, 72);
            this.grpBilancioEntrataRit.TabIndex = 3;
            this.grpBilancioEntrataRit.TabStop = false;
            this.grpBilancioEntrataRit.Tag = "AutoManage.txtBilancioEntrataRit.treeEupb";
            this.grpBilancioEntrataRit.Text = "Capitolo di entrata";
            // 
            // txtDescrBilancioEntrataRit
            // 
            this.txtDescrBilancioEntrataRit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescrBilancioEntrataRit.Location = new System.Drawing.Point(144, 16);
            this.txtDescrBilancioEntrataRit.Multiline = true;
            this.txtDescrBilancioEntrataRit.Name = "txtDescrBilancioEntrataRit";
            this.txtDescrBilancioEntrataRit.ReadOnly = true;
            this.txtDescrBilancioEntrataRit.Size = new System.Drawing.Size(168, 48);
            this.txtDescrBilancioEntrataRit.TabIndex = 54;
            this.txtDescrBilancioEntrataRit.TabStop = false;
            this.txtDescrBilancioEntrataRit.Tag = "finincomeemploy.title";
            // 
            // txtBilancioEntrataRit
            // 
            this.txtBilancioEntrataRit.Location = new System.Drawing.Point(8, 40);
            this.txtBilancioEntrataRit.Name = "txtBilancioEntrataRit";
            this.txtBilancioEntrataRit.Size = new System.Drawing.Size(128, 20);
            this.txtBilancioEntrataRit.TabIndex = 1;
            this.txtBilancioEntrataRit.Tag = "finincomeemploy.codefin?taxsetupview.codefinincomeemploy";
            // 
            // btnBilancioEntrataRit
            // 
            this.btnBilancioEntrataRit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBilancioEntrataRit.ImageIndex = 0;
            this.btnBilancioEntrataRit.ImageList = this.imageList1;
            this.btnBilancioEntrataRit.Location = new System.Drawing.Point(8, 16);
            this.btnBilancioEntrataRit.Name = "btnBilancioEntrataRit";
            this.btnBilancioEntrataRit.Size = new System.Drawing.Size(72, 24);
            this.btnBilancioEntrataRit.TabIndex = 1;
            this.btnBilancioEntrataRit.TabStop = false;
            this.btnBilancioEntrataRit.Tag = "manage.finincomeemploy.treeEupb";
            this.btnBilancioEntrataRit.Text = "Bilancio";
            this.btnBilancioEntrataRit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // grpBilancioVersamentoRit
            // 
            this.grpBilancioVersamentoRit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpBilancioVersamentoRit.Controls.Add(this.txtDescrBilancioVersamentoRit);
            this.grpBilancioVersamentoRit.Controls.Add(this.txtBilancioVersamentoRit);
            this.grpBilancioVersamentoRit.Controls.Add(this.btnBilancioRit);
            this.grpBilancioVersamentoRit.Location = new System.Drawing.Point(333, 17);
            this.grpBilancioVersamentoRit.Name = "grpBilancioVersamentoRit";
            this.grpBilancioVersamentoRit.Size = new System.Drawing.Size(321, 72);
            this.grpBilancioVersamentoRit.TabIndex = 4;
            this.grpBilancioVersamentoRit.TabStop = false;
            this.grpBilancioVersamentoRit.Tag = "AutoManage.txtBilancioVersamentoRit.treesupb";
            this.grpBilancioVersamentoRit.Text = "Capitolo di spesa, usato per la LIQUIDAZIONE PERIODICA";
            // 
            // txtDescrBilancioVersamentoRit
            // 
            this.txtDescrBilancioVersamentoRit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescrBilancioVersamentoRit.Location = new System.Drawing.Point(144, 16);
            this.txtDescrBilancioVersamentoRit.Multiline = true;
            this.txtDescrBilancioVersamentoRit.Name = "txtDescrBilancioVersamentoRit";
            this.txtDescrBilancioVersamentoRit.ReadOnly = true;
            this.txtDescrBilancioVersamentoRit.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDescrBilancioVersamentoRit.Size = new System.Drawing.Size(169, 48);
            this.txtDescrBilancioVersamentoRit.TabIndex = 54;
            this.txtDescrBilancioVersamentoRit.TabStop = false;
            this.txtDescrBilancioVersamentoRit.Tag = "finexpenseemploy.title";
            // 
            // txtBilancioVersamentoRit
            // 
            this.txtBilancioVersamentoRit.Location = new System.Drawing.Point(8, 40);
            this.txtBilancioVersamentoRit.Name = "txtBilancioVersamentoRit";
            this.txtBilancioVersamentoRit.Size = new System.Drawing.Size(128, 20);
            this.txtBilancioVersamentoRit.TabIndex = 1;
            this.txtBilancioVersamentoRit.Tag = "finexpenseemploy.codefin?taxsetupview.codefinexpenseemploy";
            // 
            // btnBilancioRit
            // 
            this.btnBilancioRit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBilancioRit.ImageIndex = 0;
            this.btnBilancioRit.ImageList = this.imageList1;
            this.btnBilancioRit.Location = new System.Drawing.Point(8, 16);
            this.btnBilancioRit.Name = "btnBilancioRit";
            this.btnBilancioRit.Size = new System.Drawing.Size(72, 24);
            this.btnBilancioRit.TabIndex = 1;
            this.btnBilancioRit.TabStop = false;
            this.btnBilancioRit.Tag = "manage.finexpenseemploy.treeSupb";
            this.btnBilancioRit.Text = "Bilancio";
            this.btnBilancioRit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.grpBilancioEntrata);
            this.groupBox5.Controls.Add(this.grpBilancioVersamento);
            this.groupBox5.Location = new System.Drawing.Point(7, 387);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(668, 94);
            this.groupBox5.TabIndex = 5;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Gestione dei CONTRIBUTI";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.grpBilancioEntrataRit);
            this.groupBox6.Controls.Add(this.grpBilancioVersamentoRit);
            this.groupBox6.Location = new System.Drawing.Point(7, 483);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(668, 94);
            this.groupBox6.TabIndex = 6;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Gestione delle RITENUTE c/DIPENDENTE";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(9, 372);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(271, 11);
            this.label3.TabIndex = 75;
            this.label3.Text = "CONFIGURAZIONE delle PARTITE DI GIRO";
            // 
            // Frm_taxsetup_default
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(682, 584);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.btnSpesaAcc);
            this.Controls.Add(this.cmbTipoRitenuta);
            this.Controls.Add(this.grpBilancioSpesa);
            this.Controls.Add(this.grpVersamento);
            this.Controls.Add(this.grpMovimentoSpesa);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "Frm_taxsetup_default";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmautomatismiritenute";
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.grpBilancioSpesa.ResumeLayout(false);
            this.grpBilancioSpesa.PerformLayout();
            this.grpBilancioEntrata.ResumeLayout(false);
            this.grpBilancioEntrata.PerformLayout();
            this.grpVersamento.ResumeLayout(false);
            this.grpVersamento.PerformLayout();
            this.grpMovimentoSpesa.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.grpPerc.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridPerc)).EndInit();
            this.grpRegione.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridRegione)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.grpBilancioVersamento.ResumeLayout(false);
            this.grpBilancioVersamento.PerformLayout();
            this.grpBilancioEntrataRit.ResumeLayout(false);
            this.grpBilancioEntrataRit.PerformLayout();
            this.grpBilancioVersamentoRit.ResumeLayout(false);
            this.grpBilancioVersamentoRit.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

        CQueryHelper QHC;
        QueryHelper QHS;
        int esercizio;

		public void MetaData_AfterLink(){
			Meta = MetaData.GetMetaData(this);
            QHC = new CQueryHelper();
            QHS = Meta.Conn.GetQueryHelper();
            esercizio = (int)Meta.GetSys("esercizio");

			string filter =QHS.CmpEq("ayear",esercizio);
            GetData.SetStaticFilter(DS.taxsetupview, QHS.CmpEq("ayear",esercizio));				
			filter = QHS.AppAnd(filter,QHS.CmpEq("idupb","0001"));
			
			GetData.SetStaticFilter(DS.bilancioapplicazione,QHS.AppAnd(filter,QHS.CmpEq("finpart","E")));
			GetData.SetStaticFilter(DS.bilanciocontributi,QHS.AppAnd(filter,QHS.CmpEq("finpart","S")));
            GetData.SetStaticFilter(DS.bilancioversamento, QHS.AppAnd(filter, QHS.CmpEq("finpart", "S")));
            GetData.SetStaticFilter(DS.finincomeemploy, QHS.AppAnd(filter, QHS.CmpEq("finpart", "E")));
            GetData.SetStaticFilter(DS.finexpenseemploy, QHS.AppAnd(filter, QHS.CmpEq("finpart", "S")));
			FillTipoScadenzaTmpTable();
		}

		void FillTipoScadenzaTmpTable() {
			DS.tmp_tiposcadenza.Rows.Add(new object[]{0, ""});
			DS.tmp_tiposcadenza.Rows.Add(new object[]{1, "Mensile"});
			DS.tmp_tiposcadenza.Rows.Add(new object[]{2, "Bimestrale"});
			DS.tmp_tiposcadenza.Rows.Add(new object[]{3, "Trimestrale"});
			DS.tmp_tiposcadenza.Rows.Add(new object[]{4, "Quadrimestrale"});
			DS.tmp_tiposcadenza.Rows.Add(new object[]{6, "Semestrale"});
			DS.tmp_tiposcadenza.Rows.Add(new object[]{12, "Annuale"});
			PostData.MarkAsTemporaryTable(DS.tmp_tiposcadenza, false);
			DS.tmp_tiposcadenza.AcceptChanges();
		}

		public void MetaData_AfterClear(){
//			txtDescrBilancioEntrata.Text="";
//			txtDescrBilancioSpesa.Text="";
//			txtDescrBilancioVersamento.Text="";
			cmbTipoScadenza.SelectedIndex=-1;
			NascondiControlli(1,true);
            labDay.Visible = true;
            txtGiornoScad.Visible = true;
		}

		public void MetaData_AfterGetFormData(){
			DataRow R = HelpForm.GetLastSelected(DS.taxsetup);
			if (cmbTipoScadenza.SelectedIndex<=0){
				R["idexpirationkind"]=DBNull.Value;
				return;
			}
			R["idexpirationkind"]= cmbTipoScadenza.SelectedValue;

		}

		public void MetaData_AfterFill(){
			DataRow R = HelpForm.GetLastSelected(DS.taxsetup);
			cmbTipoScadenza.SelectedValue=R["idexpirationkind"];
//			DataRow Curr = DS.automatismiritenute.Rows[0];
//			DataRow bilapplicazione = Curr.GetParentRow("applicazione");
//			UpdateBilancio(txtBilancioEntrata, txtDescrBilancioEntrata, 
//							bilapplicazione,"bilancioapplicazione");
//			DataRow bilcontributi = Curr.GetParentRow("contributi");
//			UpdateBilancio(txtBilancioSpesa, txtDescrBilancioSpesa, 
//							bilcontributi,"bilanciocontributi");
//			DataRow bilversamento = Curr.GetParentRow("versamento");
//			UpdateBilancio(txtBilancioVersamento, txtDescrBilancioVersamento, 
//					bilversamento,"bilancioversamento");
			if (Meta.EditMode) {
                int maskente = CfgFn.GetNoNullInt32(DS.taxsetup.Rows[0]["flag"]) & 0x07;
                NascondiControlli(maskente, true);
			}
		}


		void UpdateBilancio(TextBox cod, TextBox descr, DataRow bil, string field){
			DataRow CurrRow=null;
			if (!Meta.IsEmpty) CurrRow= DS.taxsetup.Rows[0];
			if (bil==null){
				cod.Text="";
				descr.Text="";
				if (CurrRow!=null) CurrRow[field]= DBNull.Value;
			}
			else {
				cod.Text= bil["codefin"].ToString();
				descr.Text= bil["title"].ToString();
				if (CurrRow!=null) CurrRow[field]= bil["idfin"];
			}


		}

		void ManageBilancio(string E_S, string field,
				TextBox cod, TextBox descr){
//			if (!Meta.IsEmpty) Meta.GetFormData(true);
//			
//			string filter ="(esercizio='"+Meta.Conn.sys["esercizio"]+"')";
//			string edit_type =	"tree"+E_S.ToUpper();
//			string command="manage.bilancio."+edit_type+"."+filter;
//
//			GetData.SetStaticFilter(DS.bilancio,"(partebilancio='"+E_S+"')");
//			
//			bool entitychanged;
//			DataRow SelRow;
//			DataTable SelTable;
//			bool res = Meta.ManageWithoutRefresh(command,null,null, out entitychanged,
//							out SelRow, out SelTable);
//			GetData.SetStaticFilter(DS.bilancio,null);
//
//			if (!res) {
//				cod.Focus();
//				return;
//			}
//			UpdateBilancio(cod, descr, SelRow, field);
//			if (!Meta.IsEmpty) Meta.FreshForm(true);
		}

		private void btnBilancioEntrata_Click(object sender, System.EventArgs e) {
//			ManageBilancio("E", "bilancioapplicazione", 
//							txtBilancioEntrata, txtDescrBilancioEntrata);
		}

		private void btnBilancioSpesa_Click(object sender, System.EventArgs e) {
//			ManageBilancio("S", "bilanciocontributi", 
//					txtBilancioSpesa, txtDescrBilancioSpesa);
		}

		private void btnBilancio_Click(object sender, System.EventArgs e) {
            //ManageBilancio("S", "idfinexpensecontra", 
            //            txtBilancioVersamento, txtDescrBilancioVersamento);
		}



		void AutoChooseBilancio(string E_S, string field,
			TextBox cod, TextBox descr){
		}
		
		


		private void chbImputare_CheckedChanged(object sender, System.EventArgs e) {			
			bool check = ((CheckBox)(sender)).Checked;
			btnBilancioSpesa.Enabled=check;
			txtBilancioSpesa.ReadOnly=!check;
			if (!Meta.DrawStateIsDone) return;
			if (!check) UpdateBilancio(txtBilancioSpesa, txtDescrBilancioSpesa, null, 
				"idfinadmintax");
		}

		private void grpMovimentoSpesa_Enter(object sender, System.EventArgs e) {
		
		}

		private void DeleteRows(DataGrid G) {
			DataTable T=GetGridTable(G);
			if (T==null) return;
			foreach (DataRow R in T.Select(null,null,DataViewRowState.CurrentRows)) {
				R.Delete();
			}
		}

		/// <summary>
		/// Restituisce True se ho nascosto i controlli ed eventualmente ho eliminato le righe
		/// presenti nel grid
		/// </summary>
		/// <param name="valore">flagenteregionale</param>
		/// <param name="IgnoraCheck">true per skippare il controllo righe</param>
		private bool NascondiControlli(int mask, bool IgnoraCheck) {
			switch (mask) {
				case 1:
					if (!IgnoraCheck) {
						if (!HasRows(gridRegione)) return false;
						if (!HasRows(gridPerc)) return false;
					}
					grpRegione.Visible=false;
					grpPerc.Visible=false;
					LastRadioButton=rdoCreddeb;
					break;
				case 2:
					if ((!IgnoraCheck) && (!HasRows(gridPerc))) return false;
					grpRegione.Visible=true;
					grpPerc.Visible=false;
					LastRadioButton=rdoRegione;
					break;
				case 4:
					if ((!IgnoraCheck) && (!HasRows(gridRegione))) return false;
					grpRegione.Visible=false;
					grpPerc.Visible=true;
					LastRadioButton=rdoPerc;;
					break;
			}
			return true;
		}

		private DialogResult HasRowsMsg(string tipo) {
			string regione="degli esattori di carattere regionale";
			string percent="delle ripartizioni percentuali tra diversi enti esattori";

			string msg="Questa operazione cancella l'elenco ";
			if (tipo=="R") msg+=regione;
			else msg+=percent;
			msg+=". Confermi?";
			return show(msg,"Attenzione",
				MessageBoxButtons.YesNoCancel,MessageBoxIcon.Question);
		}

		private DataTable GetGridTable(DataGrid G) {
			DataSet DSV=(DataSet)G.DataSource;
			if (DSV==null) return null;
			return DSV.Tables[G.DataMember];
		}

		private bool HasRows(DataGrid G) {
			string tipo=(G.Name=="gridRegione"?"R":"P");
			DataTable T=GetGridTable(G);
			if (T==null) return true;		                
			if (T.Select(null,null,DataViewRowState.CurrentRows).Length==0) return true;
			if (HasRowsMsg(tipo)==DialogResult.Yes) {
				DeleteRows(G);
				return true;
			}
			return false;
		}

		private RadioButton LastRadioButton=null;
		private bool LastClick=false;

		private void RadioClick(int tipo) {
			if (!Meta.DrawStateIsDone) return;
			if (LastClick) {
				LastClick=false;
				return;
			}
			if (!NascondiControlli(tipo,false)) {
				LastClick=true;
				if (LastRadioButton!=null) LastRadioButton.Checked=true;
			}
		}

		private void rdoCreddeb_CheckedChanged(object sender, System.EventArgs e) {
			RadioClick(1);
		}

		private void rdoRegione_CheckedChanged(object sender, System.EventArgs e) {
			RadioClick(2);
		}

		private void rdoPerc_CheckedChanged(object sender, System.EventArgs e) {
			RadioClick(4);
		}

        private void rdbPeriodoPrec_CheckedChanged(object sender, EventArgs e) {
            if (Meta == null) return;
            if (Meta.IsEmpty) return;
            if (labDay.Visible != rdbPeriodoPrec.Checked)  labDay.Visible = rdbPeriodoPrec.Checked;
            if (txtGiornoScad.Visible != rdbPeriodoPrec.Checked) txtGiornoScad.Visible = rdbPeriodoPrec.Checked;



        }

        private void rdbPeriodoCorr_CheckedChanged(object sender, EventArgs e) {
            if (Meta == null) return;
            if (Meta.IsEmpty) return;
            if (labDay.Visible != rdbPeriodoPrec.Checked) labDay.Visible = rdbPeriodoPrec.Checked;
            if (txtGiornoScad.Visible != rdbPeriodoPrec.Checked) txtGiornoScad.Visible = rdbPeriodoPrec.Checked;

        }


	}
}
