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
using System.Data;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using metadatalibrary;
using metaeasylibrary;
using funzioni_configurazione;

namespace expensevar_default{
	/// <summary>
	/// Summary description for frmvariazionespesa.
	/// Revised By Nino on 26/1/2003
	/// </summary>
	public class Frm_expensevar_default : System.Windows.Forms.Form {
		int CurrCausaleIva;
		DataRow IvaLinked;
		bool IvaLinkedMustBeEvalued;
		int fasespesamax;
		bool TipoDocChangePilotato=false;

		private System.Windows.Forms.GroupBox grpImporto;
		private System.Windows.Forms.RadioButton rdbAumento;
		private System.Windows.Forms.RadioButton rdbDiminuzione;
		private System.Windows.Forms.TextBox txtImporto;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.TextBox txtDataDocumento;
		private System.Windows.Forms.TextBox txtDocumento;
		private System.Windows.Forms.TextBox txtDescrizione;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.GroupBox grpVariazione;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtNumVariazione;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtEsercVariazione;
		private System.Windows.Forms.GroupBox grpMovimento;
		private System.Windows.Forms.ComboBox cmbFase;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Button btnAccertamento;
        private System.Windows.Forms.Label label10;
		public vistaForm DS;
		private System.ComponentModel.IContainer components;
		MetaData Meta;
		private System.Windows.Forms.TextBox txtNumSpesa;
		private System.Windows.Forms.TextBox txtEsercSpesa;
		private System.Windows.Forms.RadioButton radioButton2;
		private System.Windows.Forms.GroupBox grpDocumento;
		private System.Windows.Forms.Button btnDocumento;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.CheckBox chkDocIVA;
		private System.Windows.Forms.Label label13;
		private string command;
		private decimal totimponibile_dociva;
		private decimal totiva_dociva;
		private decimal assigned_imponibile_dociva;
		private decimal assigned_iva_dociva;
		private decimal assigned_gen_dociva;
		private DataAccess Conn;
		private string docoper_command="choose.invoiceavailable.variazione";
		private string docoper_command_clear="choose.invoiceavailable.unknown.clear";
		private object m_CodiceCredDebD=null;
		private object m_CodiceCredDebS=null;
		private System.Windows.Forms.ComboBox S1ubEntity_cmbCausale;
		private bool m_DocIVA=false;
		private int  m_CodiceFaseCont=-1;
		private bool InChiusura;
		private System.Windows.Forms.TextBox S1ubEntity_txtNumero;
		private System.Windows.Forms.TextBox S1ubEntity_txtEsercizio;
		private System.Windows.Forms.ComboBox S1ubEntity_cmbTipoDoc;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.RadioButton radAnnPar;
		private System.Windows.Forms.RadioButton radAnnullo;
		private System.Windows.Forms.RadioButton radNormale;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.GroupBox groupBox5;
		private System.Windows.Forms.DataGrid DGridDettagliClassificazioni;
		private System.Windows.Forms.Button btnDelClass;
		private System.Windows.Forms.Button btnEditClass;
		private System.Windows.Forms.DataGrid DGridClassificazioni;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.ImageList imageList1;
		private System.Windows.Forms.Button btnInsertClass;
		private bool ChangingFase=false;
		private System.Windows.Forms.TabPage tabDettagli;
		private System.Windows.Forms.GroupBox grpInvoiceDetail;
		private System.Windows.Forms.Button btnEditInvDet;
		private System.Windows.Forms.TextBox txtTotInvoiceDetail;
		private System.Windows.Forms.Label label17;
		private System.Windows.Forms.Button btnRemoveDettInvoice;
		private System.Windows.Forms.Button btnAddDettInvoice;
		private System.Windows.Forms.DataGrid dgrDettagliFattura;
		private decimal lastamount = 0;
        private RadioButton radEdit;
        private GroupBox groupBox6;
        private Label label14;
        private TextBox textBox2;
        private Label label15;
        private TextBox textBox3;
        private Label label7;
        private TextBox txtDataContabile;
        private bool maxphase = false;
        private GroupBox grpUnderWrinting;
        private Button btnUnderwriting;
        private TextBox txtUnderwriting;
        private Button btnApplicaSplitPayment;
		private RadioButton radCsa;
		MetaData MetaExpSorted;

		public Frm_expensevar_default() {
			InitializeComponent();

			InChiusura=false;
			SetComboCausale();

		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing ) {
			InChiusura=true;
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_expensevar_default));
			this.grpImporto = new System.Windows.Forms.GroupBox();
			this.rdbAumento = new System.Windows.Forms.RadioButton();
			this.rdbDiminuzione = new System.Windows.Forms.RadioButton();
			this.txtImporto = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.txtDataDocumento = new System.Windows.Forms.TextBox();
			this.txtDocumento = new System.Windows.Forms.TextBox();
			this.txtDescrizione = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.grpVariazione = new System.Windows.Forms.GroupBox();
			this.label1 = new System.Windows.Forms.Label();
			this.txtNumVariazione = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.txtEsercVariazione = new System.Windows.Forms.TextBox();
			this.grpMovimento = new System.Windows.Forms.GroupBox();
			this.cmbFase = new System.Windows.Forms.ComboBox();
			this.DS = new expensevar_default.vistaForm();
			this.label3 = new System.Windows.Forms.Label();
			this.txtNumSpesa = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.txtEsercSpesa = new System.Windows.Forms.TextBox();
			this.btnAccertamento = new System.Windows.Forms.Button();
			this.label10 = new System.Windows.Forms.Label();
			this.radioButton2 = new System.Windows.Forms.RadioButton();
			this.grpDocumento = new System.Windows.Forms.GroupBox();
			this.S1ubEntity_cmbCausale = new System.Windows.Forms.ComboBox();
			this.label13 = new System.Windows.Forms.Label();
			this.S1ubEntity_txtNumero = new System.Windows.Forms.TextBox();
			this.S1ubEntity_txtEsercizio = new System.Windows.Forms.TextBox();
			this.btnDocumento = new System.Windows.Forms.Button();
			this.S1ubEntity_cmbTipoDoc = new System.Windows.Forms.ComboBox();
			this.label6 = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
			this.label12 = new System.Windows.Forms.Label();
			this.chkDocIVA = new System.Windows.Forms.CheckBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.radEdit = new System.Windows.Forms.RadioButton();
			this.radAnnPar = new System.Windows.Forms.RadioButton();
			this.radAnnullo = new System.Windows.Forms.RadioButton();
			this.radNormale = new System.Windows.Forms.RadioButton();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.btnApplicaSplitPayment = new System.Windows.Forms.Button();
			this.label7 = new System.Windows.Forms.Label();
			this.txtDataContabile = new System.Windows.Forms.TextBox();
			this.grpUnderWrinting = new System.Windows.Forms.GroupBox();
			this.txtUnderwriting = new System.Windows.Forms.TextBox();
			this.btnUnderwriting = new System.Windows.Forms.Button();
			this.groupBox6 = new System.Windows.Forms.GroupBox();
			this.label14 = new System.Windows.Forms.Label();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.label15 = new System.Windows.Forms.Label();
			this.textBox3 = new System.Windows.Forms.TextBox();
			this.tabDettagli = new System.Windows.Forms.TabPage();
			this.grpInvoiceDetail = new System.Windows.Forms.GroupBox();
			this.dgrDettagliFattura = new System.Windows.Forms.DataGrid();
			this.btnEditInvDet = new System.Windows.Forms.Button();
			this.txtTotInvoiceDetail = new System.Windows.Forms.TextBox();
			this.label17 = new System.Windows.Forms.Label();
			this.btnRemoveDettInvoice = new System.Windows.Forms.Button();
			this.btnAddDettInvoice = new System.Windows.Forms.Button();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.groupBox5 = new System.Windows.Forms.GroupBox();
			this.btnInsertClass = new System.Windows.Forms.Button();
			this.DGridDettagliClassificazioni = new System.Windows.Forms.DataGrid();
			this.btnDelClass = new System.Windows.Forms.Button();
			this.btnEditClass = new System.Windows.Forms.Button();
			this.DGridClassificazioni = new System.Windows.Forms.DataGrid();
			this.label9 = new System.Windows.Forms.Label();
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.radCsa = new System.Windows.Forms.RadioButton();
			this.grpImporto.SuspendLayout();
			this.grpVariazione.SuspendLayout();
			this.grpMovimento.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
			this.grpDocumento.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.grpUnderWrinting.SuspendLayout();
			this.groupBox6.SuspendLayout();
			this.tabDettagli.SuspendLayout();
			this.grpInvoiceDetail.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgrDettagliFattura)).BeginInit();
			this.tabPage2.SuspendLayout();
			this.groupBox5.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.DGridDettagliClassificazioni)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.DGridClassificazioni)).BeginInit();
			this.SuspendLayout();
			// 
			// grpImporto
			// 
			this.grpImporto.Controls.Add(this.rdbAumento);
			this.grpImporto.Controls.Add(this.rdbDiminuzione);
			this.grpImporto.Controls.Add(this.txtImporto);
			this.grpImporto.Location = new System.Drawing.Point(259, 263);
			this.grpImporto.Name = "grpImporto";
			this.grpImporto.Size = new System.Drawing.Size(258, 64);
			this.grpImporto.TabIndex = 6;
			this.grpImporto.TabStop = false;
			this.grpImporto.Tag = "expensevar.amount.valuesigned";
			this.grpImporto.Text = "Importo della variazione";
			this.grpImporto.Leave += new System.EventHandler(this.grpImporto_Leave);
			// 
			// rdbAumento
			// 
			this.rdbAumento.Location = new System.Drawing.Point(152, 16);
			this.rdbAumento.Name = "rdbAumento";
			this.rdbAumento.Size = new System.Drawing.Size(104, 16);
			this.rdbAumento.TabIndex = 2;
			this.rdbAumento.Tag = "+";
			this.rdbAumento.Text = "Aumento";
			// 
			// rdbDiminuzione
			// 
			this.rdbDiminuzione.Location = new System.Drawing.Point(152, 40);
			this.rdbDiminuzione.Name = "rdbDiminuzione";
			this.rdbDiminuzione.Size = new System.Drawing.Size(104, 16);
			this.rdbDiminuzione.TabIndex = 3;
			this.rdbDiminuzione.Tag = "-";
			this.rdbDiminuzione.Text = "Diminuzione";
			// 
			// txtImporto
			// 
			this.txtImporto.Location = new System.Drawing.Point(16, 24);
			this.txtImporto.Name = "txtImporto";
			this.txtImporto.Size = new System.Drawing.Size(120, 20);
			this.txtImporto.TabIndex = 1;
			this.txtImporto.Tag = "expensevar.amount?expensevarview.amount";
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(205, 16);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(40, 16);
			this.label8.TabIndex = 100;
			this.label8.Text = "Data";
			this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtDataDocumento
			// 
			this.txtDataDocumento.Location = new System.Drawing.Point(251, 14);
			this.txtDataDocumento.Name = "txtDataDocumento";
			this.txtDataDocumento.Size = new System.Drawing.Size(103, 20);
			this.txtDataDocumento.TabIndex = 2;
			this.txtDataDocumento.Tag = "expensevar.docdate?expensevarview.docdate";
			// 
			// txtDocumento
			// 
			this.txtDocumento.Location = new System.Drawing.Point(7, 15);
			this.txtDocumento.Name = "txtDocumento";
			this.txtDocumento.Size = new System.Drawing.Size(192, 20);
			this.txtDocumento.TabIndex = 1;
			this.txtDocumento.Tag = "expensevar.doc?expensevarview.doc";
			// 
			// txtDescrizione
			// 
			this.txtDescrizione.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtDescrizione.Location = new System.Drawing.Point(152, 197);
			this.txtDescrizione.Multiline = true;
			this.txtDescrizione.Name = "txtDescrizione";
			this.txtDescrizione.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtDescrizione.Size = new System.Drawing.Size(825, 60);
			this.txtDescrizione.TabIndex = 4;
			this.txtDescrizione.Tag = "expensevar.description?expensevarview.description";
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(153, 177);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(152, 17);
			this.label5.TabIndex = 93;
			this.label5.Text = "Descrizione della Variazione";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// grpVariazione
			// 
			this.grpVariazione.Controls.Add(this.label1);
			this.grpVariazione.Controls.Add(this.txtNumVariazione);
			this.grpVariazione.Controls.Add(this.label2);
			this.grpVariazione.Controls.Add(this.txtEsercVariazione);
			this.grpVariazione.Location = new System.Drawing.Point(9, 177);
			this.grpVariazione.Name = "grpVariazione";
			this.grpVariazione.Size = new System.Drawing.Size(138, 80);
			this.grpVariazione.TabIndex = 3;
			this.grpVariazione.TabStop = false;
			this.grpVariazione.Text = "Variazione";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 48);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(48, 16);
			this.label1.TabIndex = 11;
			this.label1.Text = "Numero";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtNumVariazione
			// 
			this.txtNumVariazione.Location = new System.Drawing.Point(72, 48);
			this.txtNumVariazione.Name = "txtNumVariazione";
			this.txtNumVariazione.Size = new System.Drawing.Size(56, 20);
			this.txtNumVariazione.TabIndex = 1;
			this.txtNumVariazione.Tag = "expensevar.nvar?expensevarview.nvar";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(8, 18);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(56, 16);
			this.label2.TabIndex = 9;
			this.label2.Text = "Esercizio";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtEsercVariazione
			// 
			this.txtEsercVariazione.Location = new System.Drawing.Point(72, 16);
			this.txtEsercVariazione.Name = "txtEsercVariazione";
			this.txtEsercVariazione.Size = new System.Drawing.Size(56, 20);
			this.txtEsercVariazione.TabIndex = 8;
			this.txtEsercVariazione.TabStop = false;
			this.txtEsercVariazione.Tag = "expensevar.yvar?expensevarview.yvar";
			// 
			// grpMovimento
			// 
			this.grpMovimento.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.grpMovimento.Controls.Add(this.cmbFase);
			this.grpMovimento.Controls.Add(this.label3);
			this.grpMovimento.Controls.Add(this.txtNumSpesa);
			this.grpMovimento.Controls.Add(this.label4);
			this.grpMovimento.Controls.Add(this.txtEsercSpesa);
			this.grpMovimento.Controls.Add(this.btnAccertamento);
			this.grpMovimento.Controls.Add(this.label10);
			this.grpMovimento.Location = new System.Drawing.Point(8, 116);
			this.grpMovimento.Name = "grpMovimento";
			this.grpMovimento.Size = new System.Drawing.Size(969, 51);
			this.grpMovimento.TabIndex = 2;
			this.grpMovimento.TabStop = false;
			this.grpMovimento.Tag = "";
			this.grpMovimento.Text = "Movimento di spesa";
			// 
			// cmbFase
			// 
			this.cmbFase.DataSource = this.DS.expensephase;
			this.cmbFase.DisplayMember = "description";
			this.cmbFase.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbFase.Location = new System.Drawing.Point(112, 16);
			this.cmbFase.Name = "cmbFase";
			this.cmbFase.Size = new System.Drawing.Size(339, 21);
			this.cmbFase.TabIndex = 1;
			this.cmbFase.Tag = "expenseview.nphase?expensevarview.nphase";
			this.cmbFase.ValueMember = "nphase";
			// 
			// DS
			// 
			this.DS.DataSetName = "vistaForm";
			this.DS.EnforceConstraints = false;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(740, 16);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(48, 16);
			this.label3.TabIndex = 7;
			this.label3.Text = "Numero";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtNumSpesa
			// 
			this.txtNumSpesa.Location = new System.Drawing.Point(794, 13);
			this.txtNumSpesa.Name = "txtNumSpesa";
			this.txtNumSpesa.Size = new System.Drawing.Size(90, 20);
			this.txtNumSpesa.TabIndex = 3;
			this.txtNumSpesa.Tag = "expenseview.nmov?expensevarview.nmov";
			this.txtNumSpesa.Leave += new System.EventHandler(this.txtNumSpesa_Leave);
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(604, 14);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(56, 16);
			this.label4.TabIndex = 5;
			this.label4.Text = "Esercizio";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtEsercSpesa
			// 
			this.txtEsercSpesa.Location = new System.Drawing.Point(660, 11);
			this.txtEsercSpesa.Name = "txtEsercSpesa";
			this.txtEsercSpesa.Size = new System.Drawing.Size(56, 20);
			this.txtEsercSpesa.TabIndex = 2;
			this.txtEsercSpesa.Tag = "expenseview.ymov.year?expensevarview.ymov.year";
			this.txtEsercSpesa.Leave += new System.EventHandler(this.txtEsercSpesa_Leave);
			// 
			// btnAccertamento
			// 
			this.btnAccertamento.Location = new System.Drawing.Point(460, 14);
			this.btnAccertamento.Name = "btnAccertamento";
			this.btnAccertamento.Size = new System.Drawing.Size(96, 23);
			this.btnAccertamento.TabIndex = 0;
			this.btnAccertamento.TabStop = false;
			this.btnAccertamento.Tag = "";
			this.btnAccertamento.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnAccertamento.Click += new System.EventHandler(this.btnAccertamento_Click);
			// 
			// label10
			// 
			this.label10.Location = new System.Drawing.Point(48, 16);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(56, 24);
			this.label10.TabIndex = 90;
			this.label10.Text = "Fase:";
			this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// radioButton2
			// 
			this.radioButton2.Location = new System.Drawing.Point(0, 0);
			this.radioButton2.Name = "radioButton2";
			this.radioButton2.Size = new System.Drawing.Size(104, 24);
			this.radioButton2.TabIndex = 0;
			// 
			// grpDocumento
			// 
			this.grpDocumento.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.grpDocumento.Controls.Add(this.S1ubEntity_cmbCausale);
			this.grpDocumento.Controls.Add(this.label13);
			this.grpDocumento.Controls.Add(this.S1ubEntity_txtNumero);
			this.grpDocumento.Controls.Add(this.S1ubEntity_txtEsercizio);
			this.grpDocumento.Controls.Add(this.btnDocumento);
			this.grpDocumento.Controls.Add(this.S1ubEntity_cmbTipoDoc);
			this.grpDocumento.Controls.Add(this.label6);
			this.grpDocumento.Controls.Add(this.label11);
			this.grpDocumento.Controls.Add(this.label12);
			this.grpDocumento.Location = new System.Drawing.Point(8, 32);
			this.grpDocumento.Name = "grpDocumento";
			this.grpDocumento.Size = new System.Drawing.Size(969, 78);
			this.grpDocumento.TabIndex = 1;
			this.grpDocumento.TabStop = false;
			this.grpDocumento.Tag = "AutoChoose.S1ubEntity_txtNumero.lista";
			this.grpDocumento.Text = "Nota di Credito";
			// 
			// S1ubEntity_cmbCausale
			// 
			this.S1ubEntity_cmbCausale.DataSource = this.DS.tipomovimento;
			this.S1ubEntity_cmbCausale.DisplayMember = "descrizione";
			this.S1ubEntity_cmbCausale.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.S1ubEntity_cmbCausale.Location = new System.Drawing.Point(107, 49);
			this.S1ubEntity_cmbCausale.Name = "S1ubEntity_cmbCausale";
			this.S1ubEntity_cmbCausale.Size = new System.Drawing.Size(339, 21);
			this.S1ubEntity_cmbCausale.TabIndex = 4;
			this.S1ubEntity_cmbCausale.Tag = "expensevar.movkind";
			this.S1ubEntity_cmbCausale.ValueMember = "idtipo";
			// 
			// label13
			// 
			this.label13.Location = new System.Drawing.Point(32, 52);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(48, 16);
			this.label13.TabIndex = 23;
			this.label13.Text = "Causale";
			// 
			// S1ubEntity_txtNumero
			// 
			this.S1ubEntity_txtNumero.Location = new System.Drawing.Point(788, 19);
			this.S1ubEntity_txtNumero.Name = "S1ubEntity_txtNumero";
			this.S1ubEntity_txtNumero.Size = new System.Drawing.Size(96, 20);
			this.S1ubEntity_txtNumero.TabIndex = 3;
			this.S1ubEntity_txtNumero.Tag = "invoiceavailable.ninv?expensevar.ninv";
			// 
			// S1ubEntity_txtEsercizio
			// 
			this.S1ubEntity_txtEsercizio.Location = new System.Drawing.Point(660, 19);
			this.S1ubEntity_txtEsercizio.Name = "S1ubEntity_txtEsercizio";
			this.S1ubEntity_txtEsercizio.Size = new System.Drawing.Size(56, 20);
			this.S1ubEntity_txtEsercizio.TabIndex = 2;
			this.S1ubEntity_txtEsercizio.Tag = "invoiceavailable.yinv.year?expensevar.yinv.year";
			this.S1ubEntity_txtEsercizio.Leave += new System.EventHandler(this.txtEsercizio_Leave);
			// 
			// btnDocumento
			// 
			this.btnDocumento.Location = new System.Drawing.Point(460, 19);
			this.btnDocumento.Name = "btnDocumento";
			this.btnDocumento.Size = new System.Drawing.Size(96, 23);
			this.btnDocumento.TabIndex = 4;
			this.btnDocumento.TabStop = false;
			this.btnDocumento.Tag = "";
			this.btnDocumento.Text = "Seleziona doc.";
			this.btnDocumento.Click += new System.EventHandler(this.btnDocumento_Click);
			// 
			// S1ubEntity_cmbTipoDoc
			// 
			this.S1ubEntity_cmbTipoDoc.DataSource = this.DS.invoicekind;
			this.S1ubEntity_cmbTipoDoc.DisplayMember = "description";
			this.S1ubEntity_cmbTipoDoc.Location = new System.Drawing.Point(107, 19);
			this.S1ubEntity_cmbTipoDoc.Name = "S1ubEntity_cmbTipoDoc";
			this.S1ubEntity_cmbTipoDoc.Size = new System.Drawing.Size(339, 21);
			this.S1ubEntity_cmbTipoDoc.TabIndex = 1;
			this.S1ubEntity_cmbTipoDoc.Tag = "invoiceavailable.idinvkind?expensevar.idinvkind";
			this.S1ubEntity_cmbTipoDoc.ValueMember = "idinvkind";
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(740, 22);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(48, 16);
			this.label6.TabIndex = 2;
			this.label6.Text = "Numero";
			// 
			// label11
			// 
			this.label11.Location = new System.Drawing.Point(596, 22);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(64, 16);
			this.label11.TabIndex = 1;
			this.label11.Text = "Esercizio";
			// 
			// label12
			// 
			this.label12.Location = new System.Drawing.Point(32, 24);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(56, 16);
			this.label12.TabIndex = 0;
			this.label12.Text = "Tipo doc.";
			// 
			// chkDocIVA
			// 
			this.chkDocIVA.Location = new System.Drawing.Point(8, 8);
			this.chkDocIVA.Name = "chkDocIVA";
			this.chkDocIVA.Size = new System.Drawing.Size(264, 18);
			this.chkDocIVA.TabIndex = 0;
			this.chkDocIVA.Text = "Abilita contabilizzazione delle note di credito";
			this.chkDocIVA.CheckedChanged += new System.EventHandler(this.chkDocIVA_CheckedChanged);
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox1.Controls.Add(this.txtDocumento);
			this.groupBox1.Controls.Add(this.label8);
			this.groupBox1.Controls.Add(this.txtDataDocumento);
			this.groupBox1.Location = new System.Drawing.Point(598, 263);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(379, 48);
			this.groupBox1.TabIndex = 7;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Documento";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.radCsa);
			this.groupBox2.Controls.Add(this.radEdit);
			this.groupBox2.Controls.Add(this.radAnnPar);
			this.groupBox2.Controls.Add(this.radAnnullo);
			this.groupBox2.Controls.Add(this.radNormale);
			this.groupBox2.Location = new System.Drawing.Point(8, 263);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(245, 128);
			this.groupBox2.TabIndex = 5;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Tipo Variazione";
			// 
			// radEdit
			// 
			this.radEdit.Location = new System.Drawing.Point(12, 74);
			this.radEdit.Name = "radEdit";
			this.radEdit.Size = new System.Drawing.Size(227, 19);
			this.radEdit.TabIndex = 6;
			this.radEdit.Text = "Modifica Dati di Pagamenti Trasmessi";
			// 
			// radAnnPar
			// 
			this.radAnnPar.Location = new System.Drawing.Point(12, 56);
			this.radAnnPar.Name = "radAnnPar";
			this.radAnnPar.Size = new System.Drawing.Size(152, 16);
			this.radAnnPar.TabIndex = 5;
			this.radAnnPar.Text = "Annullamento parziale";
			// 
			// radAnnullo
			// 
			this.radAnnullo.Enabled = false;
			this.radAnnullo.Location = new System.Drawing.Point(12, 36);
			this.radAnnullo.Name = "radAnnullo";
			this.radAnnullo.Size = new System.Drawing.Size(152, 16);
			this.radAnnullo.TabIndex = 4;
			this.radAnnullo.Text = "Annullamento mandato";
			// 
			// radNormale
			// 
			this.radNormale.Location = new System.Drawing.Point(12, 16);
			this.radNormale.Name = "radNormale";
			this.radNormale.Size = new System.Drawing.Size(104, 16);
			this.radNormale.TabIndex = 3;
			this.radNormale.Text = "Normale";
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Controls.Add(this.tabDettagli);
			this.tabControl1.Controls.Add(this.tabPage2);
			this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControl1.ImageList = this.imageList1;
			this.tabControl1.Location = new System.Drawing.Point(0, 0);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(993, 473);
			this.tabControl1.TabIndex = 98;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.btnApplicaSplitPayment);
			this.tabPage1.Controls.Add(this.label7);
			this.tabPage1.Controls.Add(this.txtDataContabile);
			this.tabPage1.Controls.Add(this.grpUnderWrinting);
			this.tabPage1.Controls.Add(this.groupBox6);
			this.tabPage1.Controls.Add(this.label5);
			this.tabPage1.Controls.Add(this.grpVariazione);
			this.tabPage1.Controls.Add(this.grpDocumento);
			this.tabPage1.Controls.Add(this.grpMovimento);
			this.tabPage1.Controls.Add(this.grpImporto);
			this.tabPage1.Controls.Add(this.chkDocIVA);
			this.tabPage1.Controls.Add(this.groupBox1);
			this.tabPage1.Controls.Add(this.groupBox2);
			this.tabPage1.Controls.Add(this.txtDescrizione);
			this.tabPage1.Location = new System.Drawing.Point(4, 23);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Size = new System.Drawing.Size(985, 446);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Principale";
			// 
			// btnApplicaSplitPayment
			// 
			this.btnApplicaSplitPayment.Location = new System.Drawing.Point(806, 330);
			this.btnApplicaSplitPayment.Name = "btnApplicaSplitPayment";
			this.btnApplicaSplitPayment.Size = new System.Drawing.Size(152, 27);
			this.btnApplicaSplitPayment.TabIndex = 99;
			this.btnApplicaSplitPayment.TabStop = false;
			this.btnApplicaSplitPayment.Tag = "";
			this.btnApplicaSplitPayment.Text = "Applica SplitPayment";
			this.btnApplicaSplitPayment.Visible = false;
			this.btnApplicaSplitPayment.Click += new System.EventHandler(this.btnApplicaSplitPayment_Click);
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(326, 337);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(80, 16);
			this.label7.TabIndex = 98;
			this.label7.Text = "Data contabile";
			this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtDataContabile
			// 
			this.txtDataContabile.Location = new System.Drawing.Point(414, 337);
			this.txtDataContabile.Name = "txtDataContabile";
			this.txtDataContabile.Size = new System.Drawing.Size(101, 20);
			this.txtDataContabile.TabIndex = 97;
			this.txtDataContabile.Tag = "expensevar.adate?expensevarview.adate";
			// 
			// grpUnderWrinting
			// 
			this.grpUnderWrinting.Controls.Add(this.txtUnderwriting);
			this.grpUnderWrinting.Controls.Add(this.btnUnderwriting);
			this.grpUnderWrinting.Location = new System.Drawing.Point(8, 397);
			this.grpUnderWrinting.Name = "grpUnderWrinting";
			this.grpUnderWrinting.Size = new System.Drawing.Size(506, 43);
			this.grpUnderWrinting.TabIndex = 9;
			this.grpUnderWrinting.TabStop = false;
			this.grpUnderWrinting.Tag = "AutoChoose.txtUnderwriting.default.(active = \'S\')";
			// 
			// txtUnderwriting
			// 
			this.txtUnderwriting.Location = new System.Drawing.Point(117, 14);
			this.txtUnderwriting.Name = "txtUnderwriting";
			this.txtUnderwriting.Size = new System.Drawing.Size(383, 20);
			this.txtUnderwriting.TabIndex = 2;
			this.txtUnderwriting.Tag = "underwriting.title?expensevarview.underwriting";
			// 
			// btnUnderwriting
			// 
			this.btnUnderwriting.Location = new System.Drawing.Point(7, 14);
			this.btnUnderwriting.Name = "btnUnderwriting";
			this.btnUnderwriting.Size = new System.Drawing.Size(104, 23);
			this.btnUnderwriting.TabIndex = 0;
			this.btnUnderwriting.TabStop = false;
			this.btnUnderwriting.Tag = "";
			this.btnUnderwriting.Text = "Finanziamento";
			this.btnUnderwriting.UseVisualStyleBackColor = true;
			this.btnUnderwriting.Click += new System.EventHandler(this.btnUnderwriting_Click);
			// 
			// groupBox6
			// 
			this.groupBox6.Controls.Add(this.label14);
			this.groupBox6.Controls.Add(this.textBox2);
			this.groupBox6.Controls.Add(this.label15);
			this.groupBox6.Controls.Add(this.textBox3);
			this.groupBox6.Location = new System.Drawing.Point(533, 397);
			this.groupBox6.Name = "groupBox6";
			this.groupBox6.Size = new System.Drawing.Size(425, 41);
			this.groupBox6.TabIndex = 10;
			this.groupBox6.TabStop = false;
			this.groupBox6.Text = "Distinta di trasmissione ";
			// 
			// label14
			// 
			this.label14.Location = new System.Drawing.Point(238, 14);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(72, 16);
			this.label14.TabIndex = 86;
			this.label14.Text = "Data trasm.:";
			this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// textBox2
			// 
			this.textBox2.Location = new System.Drawing.Point(323, 14);
			this.textBox2.Name = "textBox2";
			this.textBox2.ReadOnly = true;
			this.textBox2.Size = new System.Drawing.Size(96, 20);
			this.textBox2.TabIndex = 12;
			this.textBox2.TabStop = false;
			this.textBox2.Tag = "paymenttransmission.transmissiondate";
			// 
			// label15
			// 
			this.label15.Location = new System.Drawing.Point(50, 15);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(72, 16);
			this.label15.TabIndex = 84;
			this.label15.Text = "Numero:";
			this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// textBox3
			// 
			this.textBox3.Location = new System.Drawing.Point(130, 15);
			this.textBox3.Name = "textBox3";
			this.textBox3.ReadOnly = true;
			this.textBox3.Size = new System.Drawing.Size(96, 20);
			this.textBox3.TabIndex = 11;
			this.textBox3.TabStop = false;
			this.textBox3.Tag = "paymenttransmission.npaymenttransmission";
			// 
			// tabDettagli
			// 
			this.tabDettagli.Controls.Add(this.grpInvoiceDetail);
			this.tabDettagli.Location = new System.Drawing.Point(4, 23);
			this.tabDettagli.Name = "tabDettagli";
			this.tabDettagli.Size = new System.Drawing.Size(985, 428);
			this.tabDettagli.TabIndex = 2;
			this.tabDettagli.Text = "Dettagli";
			// 
			// grpInvoiceDetail
			// 
			this.grpInvoiceDetail.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.grpInvoiceDetail.Controls.Add(this.dgrDettagliFattura);
			this.grpInvoiceDetail.Controls.Add(this.btnEditInvDet);
			this.grpInvoiceDetail.Controls.Add(this.txtTotInvoiceDetail);
			this.grpInvoiceDetail.Controls.Add(this.label17);
			this.grpInvoiceDetail.Controls.Add(this.btnRemoveDettInvoice);
			this.grpInvoiceDetail.Controls.Add(this.btnAddDettInvoice);
			this.grpInvoiceDetail.Location = new System.Drawing.Point(8, 8);
			this.grpInvoiceDetail.Name = "grpInvoiceDetail";
			this.grpInvoiceDetail.Size = new System.Drawing.Size(967, 408);
			this.grpInvoiceDetail.TabIndex = 0;
			this.grpInvoiceDetail.TabStop = false;
			this.grpInvoiceDetail.Text = "Dettagli Fattura";
			// 
			// dgrDettagliFattura
			// 
			this.dgrDettagliFattura.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dgrDettagliFattura.DataMember = "";
			this.dgrDettagliFattura.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dgrDettagliFattura.Location = new System.Drawing.Point(94, 8);
			this.dgrDettagliFattura.Name = "dgrDettagliFattura";
			this.dgrDettagliFattura.Size = new System.Drawing.Size(865, 392);
			this.dgrDettagliFattura.TabIndex = 13;
			// 
			// btnEditInvDet
			// 
			this.btnEditInvDet.Location = new System.Drawing.Point(8, 80);
			this.btnEditInvDet.Name = "btnEditInvDet";
			this.btnEditInvDet.Size = new System.Drawing.Size(75, 23);
			this.btnEditInvDet.TabIndex = 12;
			this.btnEditInvDet.Text = "Modifica..";
			this.btnEditInvDet.Click += new System.EventHandler(this.btnModificaDettInvoice_Click);
			// 
			// txtTotInvoiceDetail
			// 
			this.txtTotInvoiceDetail.Location = new System.Drawing.Point(8, 147);
			this.txtTotInvoiceDetail.Name = "txtTotInvoiceDetail";
			this.txtTotInvoiceDetail.ReadOnly = true;
			this.txtTotInvoiceDetail.Size = new System.Drawing.Size(80, 20);
			this.txtTotInvoiceDetail.TabIndex = 11;
			this.txtTotInvoiceDetail.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label17
			// 
			this.label17.Location = new System.Drawing.Point(8, 128);
			this.label17.Name = "label17";
			this.label17.Size = new System.Drawing.Size(48, 16);
			this.label17.TabIndex = 10;
			this.label17.Text = "Totale";
			this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// btnRemoveDettInvoice
			// 
			this.btnRemoveDettInvoice.Location = new System.Drawing.Point(8, 48);
			this.btnRemoveDettInvoice.Name = "btnRemoveDettInvoice";
			this.btnRemoveDettInvoice.Size = new System.Drawing.Size(75, 23);
			this.btnRemoveDettInvoice.TabIndex = 9;
			this.btnRemoveDettInvoice.Text = "Rimuovi";
			this.btnRemoveDettInvoice.Click += new System.EventHandler(this.btnScollegaDettInvoice_Click);
			// 
			// btnAddDettInvoice
			// 
			this.btnAddDettInvoice.Location = new System.Drawing.Point(8, 16);
			this.btnAddDettInvoice.Name = "btnAddDettInvoice";
			this.btnAddDettInvoice.Size = new System.Drawing.Size(75, 23);
			this.btnAddDettInvoice.TabIndex = 8;
			this.btnAddDettInvoice.Text = "Aggiungi";
			this.btnAddDettInvoice.Click += new System.EventHandler(this.btnCollegaDettInvoice_Click);
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.groupBox5);
			this.tabPage2.Controls.Add(this.DGridClassificazioni);
			this.tabPage2.Controls.Add(this.label9);
			this.tabPage2.ImageIndex = 1;
			this.tabPage2.Location = new System.Drawing.Point(4, 23);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Size = new System.Drawing.Size(985, 428);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "Classificazioni";
			// 
			// groupBox5
			// 
			this.groupBox5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox5.Controls.Add(this.btnInsertClass);
			this.groupBox5.Controls.Add(this.DGridDettagliClassificazioni);
			this.groupBox5.Controls.Add(this.btnDelClass);
			this.groupBox5.Controls.Add(this.btnEditClass);
			this.groupBox5.Location = new System.Drawing.Point(8, 103);
			this.groupBox5.Name = "groupBox5";
			this.groupBox5.Size = new System.Drawing.Size(967, 312);
			this.groupBox5.TabIndex = 8;
			this.groupBox5.TabStop = false;
			this.groupBox5.Text = "Dettagli Classificazioni";
			// 
			// btnInsertClass
			// 
			this.btnInsertClass.Location = new System.Drawing.Point(8, 24);
			this.btnInsertClass.Name = "btnInsertClass";
			this.btnInsertClass.Size = new System.Drawing.Size(75, 23);
			this.btnInsertClass.TabIndex = 8;
			this.btnInsertClass.Tag = "";
			this.btnInsertClass.Text = "Aggiungi";
			this.btnInsertClass.Click += new System.EventHandler(this.btnInsertClass_Click);
			// 
			// DGridDettagliClassificazioni
			// 
			this.DGridDettagliClassificazioni.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.DGridDettagliClassificazioni.DataMember = "";
			this.DGridDettagliClassificazioni.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.DGridDettagliClassificazioni.Location = new System.Drawing.Point(8, 56);
			this.DGridDettagliClassificazioni.Name = "DGridDettagliClassificazioni";
			this.DGridDettagliClassificazioni.Size = new System.Drawing.Size(951, 248);
			this.DGridDettagliClassificazioni.TabIndex = 7;
			this.DGridDettagliClassificazioni.Tag = "expensesorted.default";
			// 
			// btnDelClass
			// 
			this.btnDelClass.Location = new System.Drawing.Point(184, 24);
			this.btnDelClass.Name = "btnDelClass";
			this.btnDelClass.Size = new System.Drawing.Size(75, 23);
			this.btnDelClass.TabIndex = 6;
			this.btnDelClass.Tag = "";
			this.btnDelClass.Text = "Cancella";
			this.btnDelClass.Click += new System.EventHandler(this.btnDelClass_Click);
			// 
			// btnEditClass
			// 
			this.btnEditClass.Location = new System.Drawing.Point(96, 24);
			this.btnEditClass.Name = "btnEditClass";
			this.btnEditClass.Size = new System.Drawing.Size(75, 23);
			this.btnEditClass.TabIndex = 5;
			this.btnEditClass.Tag = "";
			this.btnEditClass.Text = "Correggi";
			this.btnEditClass.Click += new System.EventHandler(this.btnEditClass_Click);
			// 
			// DGridClassificazioni
			// 
			this.DGridClassificazioni.AllowNavigation = false;
			this.DGridClassificazioni.AllowSorting = false;
			this.DGridClassificazioni.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.DGridClassificazioni.DataMember = "";
			this.DGridClassificazioni.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.DGridClassificazioni.Location = new System.Drawing.Point(8, 32);
			this.DGridClassificazioni.Name = "DGridClassificazioni";
			this.DGridClassificazioni.Size = new System.Drawing.Size(967, 71);
			this.DGridClassificazioni.TabIndex = 7;
			this.DGridClassificazioni.Tag = "sortingkind.default";
			// 
			// label9
			// 
			this.label9.Location = new System.Drawing.Point(8, 8);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(100, 23);
			this.label9.TabIndex = 6;
			this.label9.Text = "Classificazioni";
			// 
			// imageList1
			// 
			this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
			this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
			this.imageList1.Images.SetKeyName(0, "");
			this.imageList1.Images.SetKeyName(1, "");
			// 
			// radCsa
			// 
			this.radCsa.Location = new System.Drawing.Point(12, 99);
			this.radCsa.Name = "radCsa";
			this.radCsa.Size = new System.Drawing.Size(227, 19);
			this.radCsa.TabIndex = 7;
			this.radCsa.Text = "Azzeramento Versamenti CSA";
			// 
			// Frm_expensevar_default
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(993, 473);
			this.Controls.Add(this.tabControl1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "Frm_expensevar_default";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "frmvariazionespesa";
			this.grpImporto.ResumeLayout(false);
			this.grpImporto.PerformLayout();
			this.grpVariazione.ResumeLayout(false);
			this.grpVariazione.PerformLayout();
			this.grpMovimento.ResumeLayout(false);
			this.grpMovimento.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
			this.grpDocumento.ResumeLayout(false);
			this.grpDocumento.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.tabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tabPage1.PerformLayout();
			this.grpUnderWrinting.ResumeLayout(false);
			this.grpUnderWrinting.PerformLayout();
			this.groupBox6.ResumeLayout(false);
			this.groupBox6.PerformLayout();
			this.tabDettagli.ResumeLayout(false);
			this.grpInvoiceDetail.ResumeLayout(false);
			this.grpInvoiceDetail.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgrDettagliFattura)).EndInit();
			this.tabPage2.ResumeLayout(false);
			this.groupBox5.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.DGridDettagliClassificazioni)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.DGridClassificazioni)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

        QueryHelper QHS;
        CQueryHelper QHC;
        int esercizio;
	    string filteresercizio;
		public void MetaData_AfterLink() {
			Meta=MetaData.GetMetaData(this);
            MetaExpSorted = MetaData.GetMetaData(this, "expensesorted");

			this.Conn=Meta.Conn;
            QHC = new CQueryHelper();
            QHS = Conn.GetQueryHelper();
            esercizio = CfgFn.GetNoNullInt32(Meta.GetSys("esercizio"));

            filteresercizio = QHS.CmpEq("ayear", esercizio);
			GetData.CacheTable(DS.expensephase, null, "nphase", true);
			GetData.SetStaticFilter(DS.expenseview, filteresercizio);
			command="choose.expenseview.variazionemovimento";
			GetData.CacheTable(DS.config, filteresercizio, null, false);
            string filterflag = QHS.AppAnd(QHS.BitClear("flag",0),QHS.BitSet("flag",2));
			GetData.CacheTable(DS.invoicekind, filterflag, null,true);
            GetData.SetStaticFilter(DS.invoiceavailable, filterflag);
			PostData.MarkAsTemporaryTable(DS.tipomovimento,false);
			string filterfasespesa = QHS.IsNotNull("nphaseexpense");
			GetData.CacheTable(DS.sortingkind, filterfasespesa,null,false);
			DS.expensesorted.ExtendedProperties["gridmaster"]="sortingkind";
            GetData.SetStaticFilter(DS.expensesorted, filteresercizio);
			DataAccess.SetTableForReading(DS.invoicedetail_iva, "invoicedetailview");
			DataAccess.SetTableForReading(DS.invoicedetail_taxable, "invoicedetailview");
			QueryCreator.SetTableForPosting(DS.invoicedetail_iva, "invoicedetail");
			QueryCreator.SetTableForPosting(DS.invoicedetail_taxable, "invoicedetail");
            GetData.SetStaticFilter(DS.invoicedetail_iva, QHS.CmpEq("flagvariation", 'S'));
            GetData.SetStaticFilter(DS.invoicedetail_taxable, QHS.CmpEq("flagvariation", 'S'));
			fasespesamax = CfgFn.GetNoNullInt32(Meta.GetSys("maxexpensephase"));
            HelpForm.SetDenyNull(DS.expensevar.Columns["amount"],true);
		}

       


		public void MetaData_AfterClear() {
			txtEsercVariazione.Text=esercizio.ToString();
            txtEsercVariazione.Enabled = true;
            grpMovimento.Enabled=true;
            cmbFase.SelectedIndex = 0;
            btnAccertamento.Text = "Fase da Selezionare";
			radAnnullo.Checked=false;
			radAnnullo.Enabled=false;
			radAnnPar.Enabled=false;
			radAnnPar.Checked=false;
			radNormale.Enabled=false;
			radNormale.Checked=false;
            radEdit.Enabled = false;
            radEdit.Checked = false;
			chkDocIVA.Enabled=true;
			chkDocIVA.Checked=false;
			DisabilitaDocIVA(true);
			SetComboCausale();
			m_CodiceCredDebD=null;
			m_CodiceCredDebS=null;
			SetListingType(true);
			ChangingFase=false;
			EnableDisableClassificazioni(false);
			Meta.UnMarkTableAsNotEntityChild(DS.expensesorted);
			ResetIva();
			grpInvoiceDetail.Visible = false;
			lastamount=0;
            impostaFiltroPerDocIVA(null);
            grpUnderWrinting.Visible = true;
            btnApplicaSplitPayment.Visible = false;
		}

		public void MetaData_AfterActivation() {
			if (DS.config.Rows.Count==0) return;
			m_CodiceFaseCont = CfgFn.GetNoNullInt32(Meta.GetSys("maxexpensephase"));
			btnInsertClass.BackColor = formcolors.GridButtonBackColor();
			btnInsertClass.ForeColor = formcolors.GridButtonForeColor();
			btnEditClass.BackColor = formcolors.GridButtonBackColor();
			btnEditClass.ForeColor = formcolors.GridButtonForeColor();
			btnDelClass.BackColor = formcolors.GridButtonBackColor();
			btnDelClass.ForeColor = formcolors.GridButtonForeColor();
			
			MetaData MetaInvDet = MetaData.GetMetaData(this,"invoicedetailview");
			MetaInvDet.DescribeColumns(DS.invoicedetail_taxable,"listaimpon");
			MetaInvDet.DescribeColumns(DS.invoicedetail_iva,"listaimpos");
		}

		public void MetaData_BeforeFill() {
			if (!Meta.IsEmpty){
				rimuoviDettagliFatturaEsterni();
				DataRow Curr= DS.expensevar.Rows[0];
				object idexp=Curr["idexp"];
                DataRow[] Exp = DS.expenseview.Select(QHC.CmpEq("idexp", idexp));
                int nfase;
                if (Exp.Length > 0) {
                    nfase = CfgFn.GetNoNullInt32(Exp[0]["nphase"]);
                }
                else {
                    nfase = CfgFn.GetNoNullInt32(Conn.DO_READ_VALUE("expense", QHS.CmpEq("idexp", idexp), "nphase")); 
                }
				if (nfase==0) {
					DS.sortingkind.Clear();
				}
				else {
                    string filterfasespesa = QHS.CmpEq("nphaseexpense", nfase);
					DS.sortingkind.Clear();
					Conn.RUN_SELECT_INTO_TABLE(DS.sortingkind,null, filterfasespesa,null,false); 
				}
			}
			CalcolaTotaliClassificazioni();
		}

		public void MetaData_AfterFill() {
                DataRow CurrSorKind = HelpForm.GetLastSelected(DS.sortingkind);
                if (CurrSorKind != null) {
                    string f = QHC.CmpEq("!idsorkind", CurrSorKind["idsorkind"]);
                    DS.expensesorted.ExtendedProperties["CustomParentRelation"] = f;
                }

			if (!Meta.InsertMode) {
				grpMovimento.Enabled=false;
			}

			
			Meta.MarkTableAsNotEntityChild(DS.expensesorted);
			EnableDisableCheckAnnullo();
			FillAnnullo();
            int currPhase = CfgFn.GetNoNullInt32(cmbFase.SelectedValue);
			EnableDisableCheckDocIVA(currPhase);
            EnableDisableUnderWrinting(currPhase);
			if (chkDocIVA.Enabled) {
				DisabilitaDocIVA(!chkDocIVA.Checked);

				if ((IvaLinkedMustBeEvalued==false)&&(IvaLinked!=null) &&
					(IvaLinked.RowState==DataRowState.Detached)){
					if (DS.invoice.Rows.Count>0){
						IvaLinked= DS.invoice.Rows[0];
					}
					else 
						ResetIva();
				}

				bool IvaWasToLink = IvaLinkedMustBeEvalued;
				RintracciaIva();
				if (IvaWasToLink){
					if (IvaLinked !=null) {
						VisualizzaMainInfo_Iva(IvaLinked);
					}
				}
			}
			else {
				DisabilitaDocIVA(true);
			}

			if (Meta.EditMode) {
                bool abilita = ((DS.expensevar.Rows.Count > 0) && (DS.expensevar.Rows[0]["idinvkind"] != DBNull.Value));
				AbilitaDisabilitaControlliFattura(abilita);
			}

			EnableDisableClassificazioni(true);
			if (Meta.FirstFillForThisRow && !Meta.IsEmpty){
				ManageTipoClassMovimentiRowChanged(GetImportoPerClassificazione(),DS.expensevar.Rows[0]);
                CalcTotInvoiceDetail();
			}
            txtEsercVariazione.Enabled =false;

        }

		private void rimuoviDettagliFatturaEsterni() {
			foreach(DataRow rDet in DS.invoicedetail_iva.Select()) {
                if (rDet.RowState != DataRowState.Unchanged) continue;
                string filtro =
                    QHC.AppAnd(QHC.CmpEq("idinvkind", rDet["idinvkind"]),
                        QHC.CmpEq("yinv", rDet["yinv"]),
                        QHC.CmpEq("ninv", rDet["ninv"]),
                        QHC.CmpEq("idexp",rDet["idexp_iva"]));
                if (DS.expensevar.Select(filtro).Length == 0) {
					rDet.Delete();
					rDet.AcceptChanges();
				}
			}

			foreach(DataRow rDet in DS.invoicedetail_taxable.Select()) {
                if (rDet.RowState != DataRowState.Unchanged) continue;
				string filtro =
                         QHC.AppAnd(QHC.CmpEq("idinvkind", rDet["idinvkind"]),
                        QHC.CmpEq("yinv", rDet["yinv"]),
                        QHC.CmpEq("ninv", rDet["ninv"]),
                        QHC.CmpEq("idexp", rDet["idexp_taxable"]));
                if (DS.expensevar.Select(filtro).Length == 0) {
					rDet.Delete();
					rDet.AcceptChanges();
				}
			}
		}

		void ResetIva(){
			IvaLinkedMustBeEvalued=true;
			IvaLinked=null;
		}

		public void MetaData_AfterGetFormData(){
			GetAnnullo();
		}


        private void resetIvaRef() {
            if (DS.expensevar.Rows.Count == 0) return;
            DataRow Curr = DS.expensevar.Rows[0];
            Curr["idinvkind"] = DBNull.Value;
            Curr["yinv"] = DBNull.Value;
            Curr["ninv"] = DBNull.Value;
            Curr["movkind"] = DBNull.Value;
        }

        private void impostaFiltroPerDocIVA(DataRow rExpense) {
            MetaData.AutoInfo AI = Meta.GetAutoInfo(S1ubEntity_txtNumero.Name);
            if (AI == null) {
                Meta.SetAutoMode(grpDocumento);
                AI = Meta.GetAutoInfo(S1ubEntity_txtNumero.Name);
            }

            if (Meta.IsEmpty) {
                if (AI != null) AI.startfilter = null; //Elimina il filtro sull'anagrafica
                return;
            }

            if (Meta.InsertMode) {
                if (AI != null) {
                    if (rExpense == null) return;
                    string fReg = QHS.CmpEq("idreg", rExpense["idreg"]);
                    string filtro = QHS.CmpGt("residual", 0);
                    filtro = QHS.AppAnd(filtro, fReg);
                    AI.startfilter = filtro;
                }
                return;
            }
        }

        public void MetaData_BeforeRowSelect(DataTable T, DataRow R) {
            if (Meta.DrawStateIsDone && T.TableName == "sortingkind") {
                if (R != null) {
                    string f = QHC.CmpEq("!idsorkind", R["idsorkind"]);
                    DS.expensesorted.ExtendedProperties["CustomParentRelation"] = f;
                }
            }
        }

		public void MetaData_AfterRowSelect(DataTable T, DataRow R) {
            if (T.TableName == "expenseview") {
                //if (!Meta.DrawStateIsDone) return;
                if (Meta.InsertMode) {
                    if (R == null) {
                        DS.expensesorted.Clear();
                        resetIvaRef();
                    }
                    else {
                        DS.expensesorted.Clear();
                        string filtro = QHS.AppAnd(
                            QHS.CmpEq("idexp", R["idexp"]), QHS.CmpEq("ayear", esercizio));
                        Conn.RUN_SELECT_INTO_TABLE(DS.expensesorted, null, filtro, null, false);
                        // Riempio la tabella sorting 
                        RicalcolaSorting();
                        DS.expensevar.Rows[0]["idexp"] = R["idexp"];
                    }
                    impostaFiltroPerDocIVA(R);
                    SetCredDebFilter(R, "S");
                    DrawGridTipoClass();
                }
            }

			if (T.TableName == "tipomovimento") {
				if (!Meta.DrawStateIsDone)return;
                if (Meta.InsertMode) {
                    if (DS.expensevar.Rows.Count == 0) return;
                    DS.expensevar.Rows[0]["movkind"] = (S1ubEntity_cmbCausale.SelectedValue != null)
                        ? S1ubEntity_cmbCausale.SelectedValue : DBNull.Value;
                    GetCausaleIva();
                    SvuotaDettagliFattura();
                    CollegaTuttiDettagliFattura();
                    ReCalcImporto_Iva();
                    bool abilita = (R != null);
                    AbilitaDisabilitaControlliFattura(abilita);
                }
			}

			if (T.TableName == "invoiceavailable" && m_DocIVA && Meta.InsertMode) {
				if (!Meta.DrawStateIsDone) return;
				if (R==null) {
					DS.expensevar.Rows[0]["description"]="";
					DS.expensevar.Rows[0]["doc"]=DBNull.Value;
					DS.expensevar.Rows[0]["docdate"]=DBNull.Value;
                    grpInvoiceDetail.Visible = false;
                    AbilitaDisabilitaControlliFattura(false);
				}
				else {
					DS.expensevar.Rows[0]["description"]=R["description"];
					DS.expensevar.Rows[0]["doc"]=R["doc"];
					DS.expensevar.Rows[0]["docdate"]=R["docdate"];
                    grpInvoiceDetail.Visible = true;
				}
				SetCredDebFilter(R,"D");
				DataRow rResiduo = ottieniRigaInInvoiceResidual(R);

				SetComboCausale(rResiduo);

                bool abilita = ((S1ubEntity_cmbCausale.SelectedValue != DBNull.Value) &&
                    (S1ubEntity_cmbCausale.SelectedValue.ToString() != ""));
                AbilitaDisabilitaControlliFattura(abilita);
                if (abilita) {
                    CollegaTuttiDettagliFattura();
                }

				Meta.FreshForm(true);
			}

			if (T.TableName == "expensephase"){
				string DescrFase="";
                if (!Meta.DrawStateIsDone) return;
                DS.expensesorted.Clear();
                if (cmbFase.SelectedIndex == 0) {
                    btnAccertamento.Text = "Movimento";
                    if (ChangingFase) {
                        ChangingFase = false;
                        return;
                    }
                    DS.sortingkind.Clear();
                    ClearSpesa(true);
                    //DrawGridTipoClass(); //maria
                    return;
                }
                else {
                    //					 // rileggere in base alla fase selezionata
                    string filterfasespesa = QHS.CmpEq("nphaseexpense", cmbFase.SelectedValue);
                    DS.sortingkind.Clear();
                    Conn.RUN_SELECT_INTO_TABLE(DS.sortingkind, null, filterfasespesa, null, false);
                    if (CfgFn.GetNoNullInt32(cmbFase.SelectedValue) == fasespesamax){
                        maxphase = true;
                    }
                    else{
                        maxphase = false;
                        radEdit.Checked = false;
                    }
                    if (!Meta.IsEmpty){
                        radEdit.Enabled = maxphase;
                    }
                }

				DescrFase=cmbFase.Text;
				btnAccertamento.Text=DescrFase;
				txtEsercSpesa.Text="";
				txtNumSpesa.Text="";
				if (!Meta.DrawStateIsDone)return;
				if (ChangingFase) {
					ChangingFase=false;
					return;
				}
				ClearSpesa(true);
                if (R != null) {
                    int selectedPhase = CfgFn.GetNoNullInt32(R["nphase"]);
                    EnableDisableCheckDocIVA(selectedPhase);
                    EnableDisableUnderWrinting(selectedPhase);
                }
				//DrawGridTipoClass(); //maria spostato all'interno di ClearSpesa
			}
			if ((T.TableName == "sortingkind")&& Meta.DrawStateIsDone) {				
				ManageTipoClassMovimentiRowChanged(
					GetImportoPerClassificazione(), R);
				return;
			}
		}

		void RicalcolaSorting(){
			object idsor;
            //object idsorkind;
			string filteridsor;

			if (DS.expensesorted.Rows.Count>0) {
				// Ciclo sulle righe di DS.expensesorted per eseguire la lettura della tabella DS.sorting 
				// e per valorizzare i campi calcolati relativi al codice e alla descrizione
				foreach (DataRow Curr in DS.expensesorted.Rows){
					idsor   = Curr["idsor"];
                    filteridsor = QHC.CmpEq("idsor", idsor);
					//idsorkind = Curr["idsorkind"];
                    //filteridsorkind = QHC.CmpEq("idsorkind", idsorkind);
                    //filter = QHC.AppAnd(filteridsor, filteridsorkind);
					DataRow []RigheInserite;
                    RigheInserite = DS.Tables["sorting"].Select(filteridsor);//filter
					if (RigheInserite.Length==0) {
                        //string sqlfilter = QHS.AppAnd(QHS.CmpEq("idsor", idsor), QHS.CmpEq("idsorkind", idsorkind));
                        string sqlfilter = (QHS.CmpEq("idsor", idsor));
						Conn.RUN_SELECT_INTO_TABLE(DS.sorting,null, sqlfilter,null,false); 
					}
                    DataRow[] RigheFiltrate = DS.sorting.Select(filteridsor);//filter
					if (RigheFiltrate.Length>0){
                        Curr["!idsorkind"] = RigheFiltrate[0]["idsorkind"];
						Curr["!codice"]= RigheFiltrate[0]["sortcode"];
						Curr["!descr"]=  RigheFiltrate[0]["description"];
					}
				}
			}
		}

		decimal GetImportoVariazione(){
			DataRow R = DS.expensevar.Rows[0];
			if (R["amount"]==DBNull.Value) return 0;
			return Convert.ToDecimal(R["amount"]);
		}

		void VerificaImportovariazione(){
			Meta.GetFormData(true);
			if ((!Meta.IsEmpty)&&(lastamount!=GetImportoVariazione())){
				lastamount= GetImportoVariazione();
				ManageTipoClassMovimentiRowChanged(GetImportoPerClassificazione(),DS.expensevar.Rows[0]);
			}
			Meta.FreshForm();
		}

		void DrawGridTipoClass(){
			CalcolaTotaliClassificazioni();
			Meta.myHelpForm.FillControl(DGridClassificazioni);
			Meta.myHelpForm.FillControl(DGridDettagliClassificazioni);
		}

		bool varCancellata = false;
		bool mustUpdateProceedsBank=false;
		int kpay = 0;
    	public void MetaData_BeforePost() {
			mustUpdateProceedsBank=false;
			kpay=0; //Di norma NON fa nulla
			
			//se in fase di inserimento non ho la spunta su doc iva
			//non viene inserita la riga in expensevarinvoice
			if (DS.expensevar.Rows.Count == 0) { // Se annullo l'inserimento non salva le classificazioni
				DS.expensesorted.Clear(); 
			}
			if (DS.expensevar.Rows.Count==0) return;
			varCancellata=false;
			if (DS.expensevar.Rows[0].RowState == DataRowState.Deleted) {
				varCancellata = true;
				DataRow CurrVar = DS.expensevar.Rows[0];
                string filtroSpesa = QHC.CmpEq("idexp", CurrVar["idexp", DataRowVersion.Original]);
				DataRow [] rSpesa = DS.expenseview.Select(filtroSpesa);
				if (rSpesa.Length == 0) return;
				if (rSpesa[0]["kpay"] == DBNull.Value) return;
				kpay = CfgFn.GetNoNullInt32(rSpesa[0]["kpay"]);
			}
			
			if (DS.expensevar.Rows[0].RowState== DataRowState.Added){
				mustUpdateProceedsBank=true;
			}
			if (DS.expensevar.Rows[0].RowState== DataRowState.Modified){
				decimal oldimporto= CfgFn.GetNoNullDecimal(DS.expensevar.Rows[0]["amount",DataRowVersion.Original]);
				decimal newimporto= CfgFn.GetNoNullDecimal(DS.expensevar.Rows[0]["amount",DataRowVersion.Current]);
				if (oldimporto!=newimporto) mustUpdateProceedsBank=true;
			}
		}

		public void MetaData_AfterPost() {
			if (mustUpdateProceedsBank) fillPaymentBank();
		}

		private void fillPaymentBank() {
			if (!varCancellata) {
				DataRow CurrVar = DS.expensevar.Rows[0];
                string filtro = QHC.CmpEq("idexp", CurrVar["idexp"]);
				DataRow [] rSpesa = DS.expenseview.Select(filtro);
				if (rSpesa.Length == 0) return;
				if (rSpesa[0]["kpay"] == DBNull.Value) return;
				kpay = CfgFn.GetNoNullInt32(rSpesa[0]["kpay"]);
			}
			// Nel caso la var. Ë stata cancellata e il mov. di spesa non era presente in un mandato non devo eseguire
			// il ricalcolo dei movimenti bancari
			if (kpay == 0) return;
			Meta.Conn.CallSP("compute_payment_bank", new object [] {kpay});
		}

		private void EnableDisableCheckAnnullo(){
			if (Meta.IsEmpty) {
				radNormale.Enabled=false;
				radAnnPar.Enabled=false;
                radEdit.Enabled = false;
				return;
			}
			DataRow R= DS.expensevar.Rows[0];
			int currauto=CfgFn.GetNoNullInt32( R["autokind"]);

			/* switch (currauto)
			 {
				 case 0: // normale

				 case 10: //ANPAR

				 case 11: //ANN

				 case 22: //EDIT
				 
			     case 32: //AZZERACSA

			 }*/

			if ((currauto == 0) || (currauto == 10) || (currauto == 22) || (currauto == 32)) {
				//ANPAR
				radNormale.Enabled = true;
				radAnnPar.Enabled = true;
				radEdit.Enabled = maxphase;
				radCsa.Enabled = maxphase;
			} else {
				radNormale.Enabled = false;
				radAnnPar.Enabled = false;
				radEdit.Enabled = false;
				radCsa.Enabled = false;
			}
		}

		private void FillAnnullo() {
			if (Meta.IsEmpty) {
				return;
			}
			DataRow R= DS.expensevar.Rows[0];
            int currauto = CfgFn.GetNoNullInt32(R["autokind"]);

            if (currauto==11) //ANNUL
				radAnnullo.Checked=true;
			else 
				radAnnullo.Checked=false;
            if (currauto == 10)  //ANPAR
				radAnnPar.Checked=true;
			else 
				radAnnPar.Checked=false;
            if (currauto == 22)  //EDIT
                radEdit.Checked = true;
            else
                radEdit.Checked = false;
			if (currauto == 32)  //AZZERACSA
				radCsa.Checked = true;
			else
				radCsa.Checked = false;
			if (currauto==0)
				radNormale.Checked=true;
			else 
				radNormale.Checked=false;
		}

		private void GetAnnullo(){
			if (Meta.IsEmpty) return;
			if (radAnnPar.Enabled==false) return;
			if (radNormale.Enabled==false) return;
            if (radEdit.Enabled == false) return;
			DataRow R= DS.expensevar.Rows[0];
            int currauto = CfgFn.GetNoNullInt32(R["autokind"]);
            if (radNormale.Checked) {
                if (currauto != 0) R["autokind"] = DBNull.Value;
			}
			if (radAnnPar.Checked){
                if (currauto != 10) R["autokind"] = 10;  //ANPAR
			}
            if (radEdit.Checked)
            {
                if (currauto != 22) R["autokind"] = 22;  //EDIT
            }
			if (radCsa.Checked) {
				if (currauto != 32) R["autokind"] = 32;  //AZZERACSA
			}
		}

		private void DoChooseCommand(Control sender) {			
			string mycommand=command;
			string filter1=Meta.myHelpForm.GetSpecificCondition(grpMovimento.Controls, "expenseview");
			string filter2="";
			if (m_DocIVA) filter2=GetCredDebFilter("S");
			filter1=GetData.MergeFilters(filter1, filter2);
		    filter1=GetData.MergeFilters(filter1, filteresercizio);
		    
			if (filter1!="") mycommand+="."+filter1;
			if (!MetaData.Choose(this,mycommand)) {
				if (sender!=null) sender.Focus();
			}
		}

		private void DoChooseCommandWithoutFilter() {			
			string mycommand=command;
			string filter="";
            if (cmbFase.Text != "") filter = QHS.CmpEq("nphase", cmbFase.SelectedValue);
			if (m_DocIVA) filter=QHS.AppAnd(filter,GetCredDebFilter("S"));
			string esercspesa = txtEsercSpesa.Text.Trim();
            if (esercspesa != "") filter = QHS.AppAnd(filter, QHS.CmpEq("ymov", esercspesa));
		    filter=GetData.MergeFilters(filter, filteresercizio);

			if (filter!="") mycommand+="."+filter;
			MetaData.Choose(this,mycommand);
		}

		private void ClearSpesa(bool ClearEsercizio) {
			//causa errore dopo un getformdata
			//			txtNumVariazione.Text="";
			txtNumSpesa.Text="";
			if (ClearEsercizio) txtEsercSpesa.Text="";
			if (Meta.IsEmpty) return;
			if (!Meta.InsertMode) return; //idexp can be changed only on insert!
            DS.expensevar.Rows[0]["idexp"] = 0;
			DS.expensevar.Rows[0]["nvar"]=99999;
            DS.expenseview.Clear();
			DS.expensesorted.Clear();
			DrawGridTipoClass();
		}

		private void btnAccertamento_Click(object sender, System.EventArgs e) {
			DoChooseCommandWithoutFilter();		
		}

		private void txtEsercSpesa_Leave(object sender, System.EventArgs e) {
			if (InChiusura) return;
			if (Meta.EditMode) return;

			string esercspesa=txtEsercSpesa.Text.Trim();
			if (esercspesa=="") {
				MetaData.Choose(this, "choose.expenseview.unknown.clear");
				return;
			}
			
			//if txtEsercEntrata is not Empty:
			if (Meta.IsEmpty) return;
				
			if(DS.expenseview.Rows.Count>0 ) {
				if (esercspesa== DS.expenseview.Rows[0]["ymov"].ToString())
					return;
				else {
					ClearSpesa(false);
					return;
				}	
			}		
		}

		private void txtNumSpesa_Leave(object sender, System.EventArgs e) {
			if (InChiusura) return;
			if (Meta.EditMode) return;
			if (txtNumSpesa.Text.Trim()!="") {
				DoChooseCommand((Control)sender);
				return;
			}
			//if txtNumentrata is empty:
			if (Meta.IsEmpty) return;
			ClearSpesa(false);	
		}

		private void EnableTipoMovimento(int IDtipo, string descrtipo){
			DataRow R = DS.tipomovimento.NewRow();
			R["idtipo"]= IDtipo;
			R["descrizione"]= descrtipo;
			DS.tipomovimento.Rows.Add(R);
			DS.tipomovimento.AcceptChanges();
            if (DS.tipomovimento.Rows.Count == 1) {
                HelpForm.SetComboBoxValue(S1ubEntity_cmbCausale, IDtipo);
            }
		}

		/// <summary>
		/// utilizzato semplicemente in ricerca
		/// </summary>
		private void SetComboCausale() {
			ClearComboCausale();
			EnableTipoMovimento(0,"");
			EnableTipoMovimento(1,"Contabilizzazione importo totale documento");
			EnableTipoMovimento(3,"Contabilizzazione imponibile documento");
			EnableTipoMovimento(2,"Contabilizzazione iva documento");
			HelpForm.SetComboBoxValue(S1ubEntity_cmbCausale,0);
		}

		/// <summary>
		/// Svuota la tabella DS.tipomovimento, a cui Ë agganciato il combo causale
		/// </summary>
		void ClearComboCausale(){
			DataTable TCombo= DS.tipomovimento;
			TCombo.Clear();
		}

		/// <summary>
		/// Riempie il combobox causale con i valori ammessi, senza impostarvi alcun valore
		/// </summary>
		/// <param name="R">riga di invoiceavailable</param>
		private void SetComboCausale(DataRow R){
			if (R==null) {
				SetComboCausale();
				return;
			}
			totimponibile_dociva=CfgFn.GetNoNullDecimal(R["taxabletotal"]);
			totiva_dociva=CfgFn.GetNoNullDecimal(R["ivatotal"]);

			assigned_imponibile_dociva = CfgFn.GetNoNullDecimal( R["linkedimpon"]);
			assigned_iva_dociva = CfgFn.GetNoNullDecimal( R["linkedimpos"]);
			assigned_gen_dociva = CfgFn.GetNoNullDecimal( R["linkeddocum"]);

            string filteriva = QHS.AppAnd(QHS.CmpEq("idinvkind", R["idinvkind"]),
                  QHS.CmpEq("yinv", R["yinv"]), QHS.CmpEq("ninv", R["ninv"]));

            string filter_idupbivaset = QHS.AppAnd(filteriva, QHS.IsNotNull("idupb_iva"));
            int n_idupbivaset = Conn.RUN_SELECT_COUNT("invoicedetail", filter_idupbivaset, false);

            bool EnableImpon = true;
            bool EnableImpos = true;
            bool EnableDocum = true;

			ClearComboCausale();
			DataTable TCombo= DS.tipomovimento;
			EnableTipoMovimento(0, "");

            bool intracom = false;
            DataTable T = Conn.RUN_SELECT("invoiceresidual", "*", null, filteriva, null, true);
            if ((T != null) && (T.Rows.Count > 0)) {
                //DataRow R=T.Rows[0];
                //totimponibile=CfgFn.GetNoNullDecimal(R["taxabletotal"]);
                //totiva=CfgFn.GetNoNullDecimal(R["ivatotal"]);
                foreach (DataRow Dett in T.Rows) {
                    if (Dett["flagintracom"].ToString().ToUpper() != "N") intracom = true;
                }
            }


            if (intracom) {
                EnableDocum = false;
                EnableImpos = false;
            }


            if (n_idupbivaset > 0) {
                EnableDocum = false;
            }

			if ((Meta.EditMode) ||
                 (EnableDocum &&  (assigned_imponibile_dociva+assigned_iva_dociva)==0) && 
                    (assigned_gen_dociva< (totimponibile_dociva+totiva_dociva)))
				{
				EnableTipoMovimento(1,"Contabilizzazione importo totale documento");
			}

			if ((Meta.EditMode) ||
                (EnableImpon && (assigned_gen_dociva == 0)
                    && (assigned_imponibile_dociva < totimponibile_dociva))
				){
				EnableTipoMovimento(3,"Contabilizzazione imponibile documento");
			}

			if ( (Meta.EditMode) ||
                (EnableImpos        && (assigned_gen_dociva == 0) 
                    && (assigned_iva_dociva < totiva_dociva))
				){
				EnableTipoMovimento(2,"Contabilizzazione iva documento");
			}
            if (DS.expensevar.Rows.Count != 0) {
                DS.expensevar.Rows[0]["movkind"] = (S1ubEntity_cmbCausale.SelectedValue != null)
                    ? S1ubEntity_cmbCausale.SelectedValue : DBNull.Value;
            }
			S1ubEntity_cmbCausale.Enabled=!(Meta.EditMode);
			ReCalcImporto_Iva();
		}

		private void ReCalcImporto_Iva() {
			if (!Meta.DrawStateIsDone) return;
			if (Meta.IsEmpty) return;
			if (S1ubEntity_cmbCausale.SelectedValue==null) return;
			int tipomovimento = CfgFn.GetNoNullInt32(S1ubEntity_cmbCausale.SelectedValue);
			decimal Importo=0;
			if (tipomovimento==2){
				Importo= totiva_dociva-assigned_iva_dociva;
			}
			if (tipomovimento==3){
				Importo= totimponibile_dociva-assigned_imponibile_dociva;
			}
			if (tipomovimento==1){
				Importo= totimponibile_dociva+totiva_dociva-assigned_gen_dociva;
			}

			SetImporto(-Importo);
		}

		private void SetImporto(decimal valore){
			DS.expensevar.Rows[0]["amount"]= valore;
			valore= -valore;
			txtImporto.Text= valore.ToString("c");
			rdbAumento.Checked=false;
			rdbDiminuzione.Checked=true;
		}

		private void txtEsercizio_Leave(object sender, System.EventArgs e) {
			if (InChiusura) return;
			if (TipoDocChangePilotato) return;
			if (S1ubEntity_txtEsercizio.ReadOnly) return;
			if (Meta.EditMode) return;
		}

		private void txtNumero_Leave(object sender, System.EventArgs e) {
			if (InChiusura) return;
			if (TipoDocChangePilotato) return;
			if (S1ubEntity_txtNumero.ReadOnly) return;
			if (Meta.EditMode) return;
			if (S1ubEntity_txtNumero.Text.Trim()!=""){
				DataRow MyDR = DoChooseCommandDocumento((Control)sender);
                if(Meta.InsertMode) {
                    DataRow MyDRIva = ottieniRigaInInvoiceResidual(MyDR);

                    CollegaIva(MyDR, MyDRIva);
                    CollegaTuttiDettagliFattura();
                    RintracciaIva();
                }
				AbilitaDisabilitaControlliFattura(true);
				return;
			}
			MetaData.Choose(this, docoper_command_clear);
			ClearComboCausale();
		}

		private void btnDocumento_Click(object sender, System.EventArgs e) {
			DataRow MyDR = DoChooseCommandDocumento(null);
			if(Meta.InsertMode) {
				ResetIva();
				DataRow MyDRIva = ottieniRigaInInvoiceResidual(MyDR);
				CollegaIva(MyDR,MyDRIva);
				CollegaTuttiDettagliFattura();
				RintracciaIva();
			}
			AbilitaDisabilitaControlliFattura(true);
		}

		private DataRow ottieniRigaInInvoiceResidual(DataRow R) {
			if (R == null) return null;
            string filtro =
                QHS.AppAnd(QHS.CmpEq("idinvkind", R["idinvkind"]),QHS.CmpEq("yinv", R["yinv"]), QHS.CmpEq("ninv", R["ninv"]));
            filtro = QHS.AppAnd(filtro, QHS.CmpGt("residual",0));
			DataTable tResiduo = DataAccess.RUN_SELECT(Meta.Conn, "invoiceresidual", "*", null, filtro, null, null, true);
			return (tResiduo != null && tResiduo.Rows.Count > 0) ? tResiduo.Rows[0] : null;
		}

		private DataRow DoChooseCommandDocumento(Control sender){			
			string mycommand=docoper_command;
			//string filter=Meta.myHelpForm.GetSpecificCondition(grpDocumento.Controls, "invoiceavailable");
			string filter= "";//Meta.myHelpForm.GetSpecificCondition(grpDocumento.Controls, "invoiceavailable");
			if (S1ubEntity_txtEsercizio.Text.Trim()!=""){
				int esercizio= CfgFn.GetNoNullInt32(
					HelpForm.GetObjectFromString(typeof(int),S1ubEntity_txtEsercizio.Text,"x.y.year"));
                filter = QHS.CmpEq("yinv", esercizio);
			}
			if (S1ubEntity_cmbTipoDoc.SelectedIndex>0){
				object code= S1ubEntity_cmbTipoDoc.SelectedValue;
                filter = QHS.AppAnd(filter, QHS.CmpEq("idinvkind", code));
			}
			if (sender== S1ubEntity_txtNumero){
				int num= CfgFn.GetNoNullInt32(
					HelpForm.GetObjectFromString(typeof(int),S1ubEntity_txtNumero.Text,"x.y"));
                filter = QHS.AppAnd(filter,QHS.CmpEq("ninv", num));
			}

			filter=QHS.AppAnd(filter,GetCredDebFilter("D"));
			if (Meta.InsertMode) {
                filter = QHS.AppAnd(filter, QHS.CmpGt("residual", 0), QHS.NullOrEq("active", 'S'));
			}
			if (filter!="") mycommand+= "."+filter;
            string fStatico = QHS.AppAnd(QHS.BitClear("flag", 0), QHS.BitSet("flag", 2));
            filter = QHS.AppAnd(filter, fStatico);
			MetaData MDocumentoIva = MetaData.GetMetaData(this, "invoiceavailable");
            MDocumentoIva.FilterLocked = true;
			DataRow rInv = MDocumentoIva.SelectOne("default", filter, null, null);
			if (rInv == null) return null;
            string f2 = QHS.AppAnd(
                QHS.CmpEq("idinvkind", rInv["idinvkind"]), QHS.CmpEq("yinv", rInv["yinv"]), QHS.CmpEq("ninv", rInv["ninv"]));

			DataTable tInvoiceView = DataAccess.RUN_SELECT(Meta.Conn, "invoiceview", "*", null, f2, null, null, true);
			if ((tInvoiceView == null) || (tInvoiceView.Rows.Count == 0)) return null;
			return tInvoiceView.Rows[0];
		}

		/// <summary>
		/// Se la riga Ë NULL viene ripulito
		/// </summary>
		/// <param name="R">riga che contiene il codicecreddeb</param>
		/// <param name="FlagRichiedente">D per documentoivaoperativo, S per spesaview</param>
		private void SetCredDebFilter(DataRow R, string FlagRichiedente) {
			if (FlagRichiedente.ToUpper()=="D") {
				m_CodiceCredDebD=(R==null?null:R["idreg"]);
			}
			if (FlagRichiedente.ToUpper()=="S") {
				m_CodiceCredDebS=(R==null?null:R["idreg"]);
			}
		}

		/// <param name="FlagRichiedente">D per documentoivaoperativo, S per spesaview</param>
		private string GetCredDebFilter(string FlagRichiedente) {
			object cred=null;
			if (FlagRichiedente=="D") 
				cred=m_CodiceCredDebS;
			else
				cred=m_CodiceCredDebD;
			if (cred==null || cred.ToString()=="") return "";
			return QHS.CmpEq("idreg",cred);
		}


		private void DisabilitaDocIVA(bool disable) {
			S1ubEntity_cmbTipoDoc.Enabled=!disable;
			btnDocumento.Enabled=!disable;
			S1ubEntity_txtEsercizio.ReadOnly=disable;
			S1ubEntity_txtNumero.ReadOnly=disable;
			S1ubEntity_cmbCausale.Enabled=!disable;
			cmbFase.Enabled=disable;
			if (chkDocIVA.Enabled) {
				if (m_DocIVA) {
					HelpForm.SetComboBoxValue(cmbFase,m_CodiceFaseCont);
				}
				else {
					HelpForm.SetComboBoxValue(S1ubEntity_cmbCausale,0);
				}
			}
		}
		
		private bool ControlloEseguito=false;
		private void chkDocIVA_CheckedChanged(object sender, System.EventArgs e) {
			if (!Meta.DrawStateIsDone) return;
			if (DS.config.Rows.Count==0 && !ControlloEseguito) {
				ControlloEseguito=true;
				MessageBox.Show("Non Ë stata effettuata la configurazione della gestione IVA relativa all'esercizio corrente",
					"Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				Meta.CanSave=false;
				return;
			}
			ChangingFase=true;
			m_DocIVA=chkDocIVA.Checked;
			SetListingType(!m_DocIVA);
			DisabilitaDocIVA(!m_DocIVA);
			m_CodiceCredDebD=null;

			if (Meta.InsertMode) {
				if (chkDocIVA.Checked) {
					grpMovimento.Enabled = false;
                    btnApplicaSplitPayment.Visible = true; ;
				}
				else {
					grpMovimento.Enabled = true;
					DS.invoicedetail_iva.Clear();
					DS.invoicedetail_taxable.Clear();
					ScollegaIva(true);
					ResetIva();
                    btnApplicaSplitPayment.Visible = false;
				}
			}
		}

		private void EnableDisableCheckDocIVA(int currphase){
            int maxPhase = CfgFn.GetNoNullInt32(Meta.GetSys("maxexpensephase"));
			bool abilita = ((Meta.InsertMode && DS.expenseview.Rows.Count > 0) || Meta.IsEmpty)
                && (currphase == maxPhase);
			chkDocIVA.Enabled=abilita;
		}

        private void EnableDisableUnderWrinting(int currphase)
        {
            int finPhase = CfgFn.GetNoNullInt32(Meta.GetSys("expensefinphase"));
            int maxPhase = CfgFn.GetNoNullInt32(Meta.GetSys("maxexpensephase"));
            bool abilita = ((Meta.InsertMode && DS.expenseview.Rows.Count > 0) || (Meta.EditMode) || Meta.IsEmpty)
                && ((currphase == maxPhase) || (currphase == finPhase));
            grpUnderWrinting.Visible = abilita;
        }

		private void SetListingType(bool DefaultListType) {
			if (DefaultListType)
				Meta.DefaultListType="lista";
			else
				Meta.DefaultListType="dociva";
		}

		#region Gestione Classificazioni
		
		private void btnInsertClass_Click(object sender, System.EventArgs e) {
			if (Meta.IsEmpty) return;
			if (DS.expensevar.Rows.Count == 0) return;
			Meta.GetFormData(true);
			if (DS.expenseview.Rows.Count == 0) return;
			DataRow CurrExp = DS.expenseview.Rows[0];
			decimal importo= GetImportoPerClassificazione();

			CalcImpClassMovDefaults(importo); 

			DataTable T;
			DataRow CurrTipoClass;
			bool res = Meta.myHelpForm.GetCurrentRow(DGridClassificazioni, out T, out CurrTipoClass);
			if (!res) return;
			if (CurrTipoClass==null) return;
            string filter = QHS.CmpEq("idsorkind", CurrTipoClass["idsorkind"]);
			DataTable ClassMovAllowed = DS.sorting.Clone();
			ClassMovAllowed.Clear();
			Meta.Conn.RUN_SELECT_INTO_TABLE(ClassMovAllowed,null,filter,null,true);
			if (ClassMovAllowed.Rows.Count == 0) return;

			DS.expensesorted.ExtendedProperties[MetaData.ExtraParams]= ClassMovAllowed;
			DS.expensesorted.ExtendedProperties["importoresiduo"]= Convert.ToDecimal(0);

            MetaExpSorted.SetDefaults(DS.expensesorted);
			DataRow Added = MetaData.Insert_Grid(DGridDettagliClassificazioni, "default");//qui Ë scattata un'eccezione ma non ne trovo il motivo 
		        //System.NullReferenceException: Riferimento a un oggetto non impostato su un'istanza di oggetto.
		        //in metadatalibrary.MetaData.Insert_Grid_Row(DataGrid G, String edit_type)

            if (Added==null) return;

			Meta.FreshForm(true);
		}
		

		private void btnEditClass_Click(object sender, System.EventArgs e) {
			if (Meta.IsEmpty) return;
			if (DS.expenseview.Rows.Count == 0) return;
			if (DS.expensevar.Rows.Count==0) return;
			Meta.GetFormData(true);
			CalcImpClassMovDefaults(GetImportoPerClassificazione());

			DataTable T;
			DataRow CurrTipoClass;
			bool res = Meta.myHelpForm.GetCurrentRow(DGridClassificazioni, out T, out CurrTipoClass);
			if (!res) return;
			if (CurrTipoClass==null) return;
			DataTable SourceTable;
			DataRow CurrDR;            
			res = Meta.myHelpForm.GetCurrentRow(DGridDettagliClassificazioni, out SourceTable, out CurrDR);
			if (!res) return;
			if (CurrDR==null) return;

            string filter = QHS.CmpEq("idsorkind", CurrTipoClass["idsorkind"]);
			DataTable ClassMovAllowed = DS.sorting.Clone();
			ClassMovAllowed.Clear();
			Meta.Conn.RUN_SELECT_INTO_TABLE(ClassMovAllowed,null,filter,null,true);
			if (ClassMovAllowed.Rows.Count == 0) return;
			DS.expensesorted.ExtendedProperties[MetaData.ExtraParams]= ClassMovAllowed;
			DataRow Modified = MetaData.Edit_Grid(DGridDettagliClassificazioni, "default");
			if (Modified==null) return;

			Meta.FreshForm(true);
		}

		private void btnDelClass_Click(object sender, System.EventArgs e) {
			if (Meta.IsEmpty) return;
			if (DS.expensevar.Rows.Count == 0) return;
			Meta.GetFormData(true);
			DataRow Curr = DS.expensevar.Rows[0];
			
			DataTable SourceTable;
			DataRow CurrDR;
            
			bool res = Meta.myHelpForm.GetCurrentRow(DGridDettagliClassificazioni, 
				out SourceTable, out CurrDR);
			if (!res) return ;
			if (CurrDR==null) return;

			
			if (MessageBox.Show(
				"Cancello la classificazione selezionata?",
				"Richiesta di conferma", 
				MessageBoxButtons.YesNo)!=DialogResult.Yes) return;


			DeleteImpClassMov(CurrDR);
			
			HelpForm.SetLastSelected(SourceTable,null);
			Meta.myHelpForm.SetDataRowRelated(DGridClassificazioni.FindForm(), SourceTable, null);
			Meta.myHelpForm.ControlChanged(DGridClassificazioni,null);
			Meta.FreshForm();
		}

		void AbilitaSubMovimenti() {
			RowChange.MarkAsAutoincrement(
				DS.expensesorted.Columns["idsubclass"], 
				null,
				null,
				7,
				false);
            //RowChange.SetSelector(DS.expensesorted, "idsorkind");
			RowChange.SetSelector(DS.expensesorted, "idsor");
			RowChange.SetSelector(DS.expensesorted, "idexp");
		}

		public void CalcImpClassMovDefaults(decimal ImportoPerClassificazione) {
			DataTable T;
			DataRow Curr;
			bool res = Meta.myHelpForm.GetCurrentRow(DGridClassificazioni, 
				out T, out Curr);
			if (Curr==null)return;

            //DS.expensesorted.Columns["idsorkind"].DefaultValue = Curr["idsorkind"];

			AbilitaSubMovimenti();
			DataRow CurrMov = DS.expensevar.Rows[0];

            decimal importoclassificato = CfgFn.GetNoNullDecimal(DS.expensesorted.Compute("SUM(amount)",
                QHC.FieldIn("idsor", DS.sorting.Select(QHC.CmpEq("idsorkind", Curr["idsorkind"])))));
			
			decimal importototale  = ImportoPerClassificazione;
			decimal importoresiduo = importototale - importoclassificato;

			if (Curr["totalexpression"].ToString()=="")
				DS.expensesorted.Columns["amount"].DefaultValue = importoresiduo;
			else 
				DS.expensesorted.Columns["amount"].DefaultValue = 0;

			DS.expensesorted.ExtendedProperties["importoresiduo"]= importoresiduo;
			DS.expensesorted.ExtendedProperties["importototale"]= importototale;
			btnEditClass.Enabled=true;
			btnInsertClass.Enabled=true;
			btnDelClass.Enabled=true;
		}

		void EnableDisableClassificazioni(bool enable){
			btnInsertClass.Enabled = enable;
			btnEditClass.Enabled = enable;
			btnDelClass.Enabled = enable;
		}
		/// <summary>
		/// Deletes epexp with all sub-autoclasses
		/// </summary>
		/// <param name="R"></param>
		void DeleteImpClassMov(DataRow R) {
			R.Delete();
		}

		public void EnterTabClassificazioni(){
			if (Meta.IsEmpty) return;
			CalcolaTotaliClassificazioni();
			SelectTipoClassMovimenti();

		}

		public void ManageTipoClassMovimentiRowChanged(decimal ImportoPerClassificazione,
			DataRow Curr) {
			if (Curr==null) {
				btnEditClass.Enabled=false;
				btnInsertClass.Enabled=false;
				btnDelClass.Enabled=false;
				return;
			}
			btnEditClass.Enabled=true;
			btnInsertClass.Enabled=true;
			btnDelClass.Enabled=true;

			CalcImpClassMovHeaders(ImportoPerClassificazione);
		}

		/// <summary>
		/// Calcs column names of impclassspesa grid and freshes grid
		/// </summary>
		void CalcImpClassMovHeaders(decimal importoperclassificazione) {
			DataTable T;
			DataRow Curr;

			bool res = Meta.myHelpForm.GetCurrentRow(DGridClassificazioni, out T, out Curr);
			if (Curr==null)return;

			RefillDettagliClassificazioni(importoperclassificazione);
		}

		/// <summary>
		/// redraws grid
		/// </summary>
		/// <param name="importoperclassificazione"></param>
		public void RefillDettagliClassificazioni(decimal importoperclassificazione){
			if (Meta.IsEmpty) return;
			DS.expensesorted.ExtendedProperties["TotaleImporto"]= importoperclassificazione;
			GetData.CalculateTable(DS.expensesorted);
			DGridDettagliClassificazioni.TableStyles.Clear();
			HelpForm.SetGridStyle(DGridDettagliClassificazioni, DS.expensesorted);
			if (DGridDettagliClassificazioni.DataSource==null) return;
			formatgrids format = new formatgrids(DGridDettagliClassificazioni);
			format.AutosizeColumnWidth();	
			HelpForm.SetDataGrid(DGridDettagliClassificazioni, DS.expensesorted);
		}

		public void CalcolaTotaliClassificazioni(){
			foreach (DataRow TR in DS.sortingkind.Rows) {
				decimal importo=0;
                string filter = QHC.CmpEq("idsorkind", TR["idsorkind"]);
				string expression= TR["totalexpression"].ToString();
				if (expression=="")expression="SUM(amount)";
                string filterMovSor = QHC.FieldIn("idsor", DS.sorting.Select(filter));
				object importoo = null;
				try {
					importoo= DS.expensesorted.Compute(expression,filterMovSor);
				}
				catch {
				}
				importo = CfgFn.GetNoNullDecimal(importoo);
				TR["!importo"]=importo;
				TR.AcceptChanges();
			}

		}

		decimal GetImportoPerClassificazione(){
			if (DS.expensevar.Rows.Count==0) return 0;
			if (DS.expenseview.Rows.Count==0) return 0;
			DataRow CurrExp = DS.expenseview.Rows[0];
			decimal importoexp = CfgFn.GetNoNullDecimal(CurrExp["curramount"]);
			DataRow CurrVar = DS.expensevar.Rows[0];
			decimal importovar = CfgFn.GetNoNullDecimal(CurrVar["amount",DataRowVersion.Default]);
			if ((CurrVar.RowState==DataRowState.Modified)||(CurrVar.RowState==DataRowState.Unchanged)){
				importovar-=CfgFn.GetNoNullDecimal(CurrVar["amount",DataRowVersion.Original]);
			}
			decimal importo= importoexp+importovar;
			return importo;
		}

		public void SelectTipoClassMovimenti(){		
			DataTable T;
			DataRow CurrTipoClass;
			bool res = Meta.myHelpForm.GetCurrentRow(DGridClassificazioni, 
				out T, out CurrTipoClass);
			if (!res) {
				return;
			}
			if (CurrTipoClass!=null) {
				if (DGridDettagliClassificazioni.DataSource==null)
					Meta.myHelpForm.ControlChanged(DGridClassificazioni, null);
				return;
			}
			if (T.Rows.Count==0) {
				return;
			}
			DGridDettagliClassificazioni.CurrentRowIndex=0;
			Meta.myHelpForm.ControlChanged(DGridClassificazioni, null);
			res = Meta.myHelpForm.GetCurrentRow(DGridClassificazioni, 
				out T, out CurrTipoClass);
		}
		#endregion

		private void grpImporto_Leave(object sender, System.EventArgs e) {
			VerificaImportovariazione();
		}

		#region Gestione Dettagli Fattura
		int GetCausaleIva(){
			CurrCausaleIva= 0;
            if (DS.expensevar.Rows.Count == 0) return 0;
            DataRow Curr = DS.expensevar.Rows[0];
            if (!verificaDocIvaSelezionato()) return 0;

			if (!Meta.DrawStateIsDone){
                CurrCausaleIva = (Curr["movkind"] == DBNull.Value) ? 0 : CfgFn.GetNoNullInt32(Curr["movkind"]);
				return CurrCausaleIva;
			}

            CurrCausaleIva = CfgFn.GetNoNullInt32(Curr["movkind"]);
			return CurrCausaleIva;
		}

		private void btnCollegaDettInvoice_Click(object sender, System.EventArgs e) {
			if (DS.config.Rows.Count==0) return;
            if (DS.expensevar.Rows.Count == 0) return;

            if (!verificaDocIvaSelezionato()) {
                MessageBox.Show(this, "Bisogna selezionare la nota di credito");
                return;
            }

			if (MetaData.Empty(this)) return;
			MetaData.GetFormData(this,true);
			CurrCausaleIva= GetCausaleIva();
		    if (CurrCausaleIva == 0) {
		        MessageBox.Show("Occorre selezionare prima la causale", "Avviso");
		        return;
		    }
			string MyFilter = CalculateFilterForInvoiceDetailLinking(true);
			string tablename="";
			if (CurrCausaleIva== 1||CurrCausaleIva==3){
				tablename="invoicedetail_taxable";
			}
			if (CurrCausaleIva==2){
				tablename="invoicedetail_iva";
			}

			string command = "choose."+tablename+".listaspesa." + MyFilter;
			if (!MetaData.Choose(this,command))return;
			if (CurrCausaleIva==1){
				foreach(DataRow R in DS.invoicedetail_taxable.Rows){
					R["idexp_iva"]=R["idexp_taxable"];
				};
			}
			CalcolaImportoInBaseADettagliFattura();
		}

		void CalcolaImportoInBaseADettagliFattura(){
			if (Meta.IsEmpty) return;
			CurrCausaleIva= GetCausaleIva();
			decimal totale= GetImportoDettagliFattura();
			SetImporto(-totale);
			CalcTotInvoiceDetail();
		}

		void CalcTotInvoiceDetail(){
			txtTotInvoiceDetail.Text="";
			if (Meta.IsEmpty) return;
			decimal totale= GetImportoDettagliFattura();
			txtTotInvoiceDetail.Text=totale.ToString("c");
		}

		decimal GetImportoDettagliFattura(){
			if (DS.invoice.Rows.Count==0) 
				return 0;
			decimal tassocambio;
			DataRow Fattura= DS.invoice.Rows[0];
			tassocambio= CfgFn.GetNoNullDecimal(Fattura["exchangerate"]);
			if(tassocambio==0) tassocambio=1;
			decimal imponibile=0;
			decimal imposta=0;
			DataRow[] ToConsider=new DataRow[0];
			CurrCausaleIva= GetCausaleIva();
			if (CurrCausaleIva==3){
				ToConsider= DS.invoicedetail_taxable.Select(QHC.IsNotNull("idexp_taxable"));
			}
			if (CurrCausaleIva==2){
				ToConsider= DS.invoicedetail_iva.Select(QHC.IsNotNull("idexp_iva"));
			}
			if (CurrCausaleIva==1){
				ToConsider= DS.invoicedetail_taxable.Select(QHC.IsNotNull("idexp_taxable"));
			}

			foreach (DataRow R in ToConsider){
				if (R.RowState== DataRowState.Deleted) continue;
				decimal R_imponibile = CfgFn.GetNoNullDecimal(R["taxable"]);
				decimal R_quantita = CfgFn.GetNoNullDecimal(R["number"]);
				decimal R_imposta  = CfgFn.GetNoNullDecimal(R["tax"]);
				decimal R_sconto   = CfgFn.Round(CfgFn.GetNoNullDecimal(R["discount"]),6);
				imponibile +=  CfgFn.RoundValuta((R_imponibile*R_quantita *(1-R_sconto))*tassocambio) ;
				imposta    +=  CfgFn.RoundValuta(R_imposta);
			}

			decimal totale=0;

			if (CurrCausaleIva== 3){
				totale= imponibile;
			}
			if (CurrCausaleIva== 2 ){
				totale= imposta;
			}
			if (CurrCausaleIva==1){
				totale= imponibile+imposta;
			}

			return totale;

		}

		string CalculateFilterForInvoiceDetailLinking(bool SQL){
			string MyFilter;
			object idupb = DBNull.Value;

			if (DS.expenseview.Rows.Count > 0) {
				idupb = DS.expenseview.Rows[0]["idupb"];
            }
            if (DS.expensevar.Rows.Count == 0) return "";
            if (!verificaDocIvaSelezionato()) return "";
            DataRow Curr = DS.expensevar.Rows[0];
            QueryHelper QH = SQL ? QHS : QHC;
            MyFilter = QH.AppAnd(
                QH.CmpEq("idinvkind", Curr["idinvkind"]),
                QH.CmpEq("yinv", Curr["yinv"]),
                QH.CmpEq("ninv", Curr["ninv"]));


            //if (idupb != DBNull.Value)
            //    MyFilter = QH.AppAnd(MyFilter, QH.NullOrEq("idupb", idupb));

            if (idupb != DBNull.Value) {
                if (CurrCausaleIva == 1) {
                    //totale, prende upb standard
                    MyFilter = QH.AppAnd(MyFilter, QH.NullOrEq("idupb", idupb));
                }
                if (CurrCausaleIva == 2) {
                    //IVA
                    MyFilter = QH.AppAnd(MyFilter, QH.NullOrEq("isnull(idupb_iva,idupb)", idupb));
                }
                if (CurrCausaleIva == 3) {
                    //imponibile 
                    MyFilter = QH.AppAnd(MyFilter, QH.NullOrEq("idupb", idupb));
                }
            }


			if (CurrCausaleIva==1){
                MyFilter = QH.AppAnd(MyFilter, QH.IsNull("idexp_iva"), QH.IsNull("idexp_taxable"));
			}
			if (CurrCausaleIva==2){
                MyFilter = QH.AppAnd(MyFilter, QH.IsNull("idexp_iva"));
			}
			if (CurrCausaleIva==3){
                MyFilter = QH.AppAnd(MyFilter, QH.IsNull("idexp_taxable"));
			}

			return MyFilter;
		}

        /// <summary>
        /// Metodo che verifica se la nota di credito Ë stata selezionata
        /// </summary>
        /// <returns></returns>
        private bool verificaDocIvaSelezionato() {
            if (DS.expensevar.Rows.Count == 0) return false;
            
            DataRow Curr = DS.expensevar.Rows[0];
            if ((Curr["idinvkind"] == DBNull.Value) ||
                (Curr["yinv"] == DBNull.Value) ||
                (Curr["ninv"] == DBNull.Value)) {
                return false;
            }
            return true;
        }
		private void btnScollegaDettInvoice_Click(object sender, System.EventArgs e) {
			if (Meta.IsEmpty) return;
			Meta.GetFormData(true);
            if (DS.expensevar.Rows.Count == 0) return;
            if (!verificaDocIvaSelezionato()) {
                MessageBox.Show(this, "Bisogna selezionare la nota di credito");
                return;
            }
			MetaData.Unlink_Grid(dgrDettagliFattura);
			if (CurrCausaleIva==1){
				foreach(DataRow R in DS.invoicedetail_taxable.Rows){
					R["idexp_iva"]=R["idexp_taxable"];
				};
			}
			CalcolaImportoInBaseADettagliFattura();
		}

		private void btnModificaDettInvoice_Click(object sender, System.EventArgs e) {
			if (Meta.IsEmpty) return;
			Meta.GetFormData(true);

            if (DS.expensevar.Rows.Count == 0) return;
            DataRow Curr = DS.expensevar.Rows[0];
            if (!verificaDocIvaSelezionato()) {
                MessageBox.Show(this, "Bisogna selezionare la nota di credito");
                return;
            }
            
			DataTable ToLink=null;
			if (CurrCausaleIva==1||CurrCausaleIva==3){
				ToLink=DS.invoicedetail_taxable;
			}
			if (CurrCausaleIva==2){
				ToLink=DS.invoicedetail_iva;
			}
            if (ToLink == null) {
                MessageBox.Show("E' necessario selezionare prima la causale");
                return;
            }
            string MyFilter = CalculateFilterForInvoiceDetailLinking(false);
			string MyFilterSQL = CalculateFilterForInvoiceDetailLinking(true);
			Meta.MultipleLinkUnlinkRows("Selezione dettagli fattura",
				"Dettagli inclusi nella variazione corrente", 
				"Dettagli non inclusi in alcuna variazione",
				ToLink, MyFilter, MyFilterSQL, "listaspesa"); 
			if (CurrCausaleIva==1){
				foreach(DataRow R in DS.invoicedetail_taxable.Rows){
					R["idexp_iva"]=R["idexp_taxable"];
				};
			}

			CalcolaImportoInBaseADettagliFattura();		
		}

		void CollegaTuttiDettagliFattura(){
			CurrCausaleIva = GetCausaleIva();
			string filter = CalculateFilterForInvoiceDetailLinking(true);
			DS.invoicedetail_iva.Clear();
			DS.invoicedetail_taxable.Clear();
			object idexp=DS.expensevar.Rows[0]["idexp"];
			// JTR 29.11.2006 - Se l'idexp Ë vuoto non fare nulla (questo accade quando non ho ancora scelto un movimento di spesa al 
			// quale associare la variazione)
			if (idexp == DBNull.Value) return;
			if (CurrCausaleIva == 0) return;
			if (CurrCausaleIva==1){
				Meta.Conn.RUN_SELECT_INTO_TABLE(DS.invoicedetail_taxable,null,filter,null,true);
				foreach(DataRow R in DS.invoicedetail_taxable.Rows){
					R["idexp_taxable"]=idexp;
					R["idexp_iva"]=idexp;
				}
				GetData.CalculateTable(DS.invoicedetail_taxable);
				Meta.MarkTableAsNotEntityChild(DS.invoicedetail_taxable);
			}
			if (CurrCausaleIva==3){
				Meta.Conn.RUN_SELECT_INTO_TABLE(DS.invoicedetail_taxable,null,filter,null,true);
				foreach(DataRow R in DS.invoicedetail_taxable.Rows){
					R["idexp_taxable"]=idexp;
				}
				GetData.CalculateTable(DS.invoicedetail_taxable);
				Meta.MarkTableAsNotEntityChild(DS.invoicedetail_taxable);
			}
			if (CurrCausaleIva==2){
				Meta.Conn.RUN_SELECT_INTO_TABLE(DS.invoicedetail_iva,null,filter,null,true);
				foreach(DataRow R in DS.invoicedetail_iva.Rows){
					R["idexp_iva"]=idexp;
				}
				GetData.CalculateTable(DS.invoicedetail_iva);
				Meta.MarkTableAsNotEntityChild(DS.invoicedetail_iva);
			}

			CalcolaImportoInBaseADettagliFattura();
            if ((DS.invoicedetail_iva.Rows.Count == 0) && (DS.invoicedetail_taxable.Rows.Count == 0)) {
                MessageBox.Show("Non sono stati trovati dettagli coerenti con UPB e Causale selezionati.");
                return;
            }

		}

		void SvuotaDettagliFattura(){
			if (Meta.EditMode)return;
			DS.invoicedetail_taxable.Clear();
			DS.invoicedetail_iva.Clear();
			CalcTotInvoiceDetail();
		}

		private void S1ubEntity_cmbCausale_SelectedIndexChanged(object sender, System.EventArgs e) {
			if (!Meta.InsertMode) return;
			GetCausaleIva();
			SvuotaDettagliFattura();
			CollegaTuttiDettagliFattura();
			ReCalcImporto_Iva();
		}

		void RintracciaIva(){
			if (!IvaLinkedMustBeEvalued)return;
            if(DS.config.Rows.Count == 0) return;
			GetDocIva(out IvaLinked, 
				out CurrCausaleIva);
			IvaLinkedMustBeEvalued=false;
		}

		/// <summary>
		/// Restituisce il documento contabilizzato con il movimento corrente
		/// </summary>
		/// <param name="tablename">nome tabella documento</param>
		/// <param name="middletablename">nome tabella intermedia del DataSet</param>
		/// <param name="faseattivazione">fase di contabilizzazione del documento</param>
		/// <param name="CurrMiddleDocRow">Riga intermedia associata a questo movimento</param>
		/// <returns>Documento contabilizzato dal movimento corrente</returns>
		DataRow GetDocRow(string tablename, string middletablename, 
			int faseattivazione
			){
			if (Meta.IsEmpty) return null;
			if (DS.expensevar.Rows.Count == 0) return null;
			int currphase = CfgFn.GetNoNullInt32(cmbFase.SelectedValue);
			
			if (currphase==faseattivazione){
				//Se la fase attivazione Ë inclusa nel range, Ë possibile che 
				// il documento sia stato selezionato e sia in memoria, oppure che non 
				// sia stato selezionato il documento e quindi non ci sono righe
				if (DS.Tables[tablename].Rows.Count==0) return null;
				return DS.Tables[tablename].Rows[0];
			}
            return null;
		}

		void GetDocIva(out DataRow IvaRow, 
			out int CurrCausaleIva){
			CurrCausaleIva=0;
            IvaRow = null;
            if (DS.expensevar.Rows.Count == 0) return;
			DataRow MiddleRow = DS.expensevar.Rows[0];
			int faseiva = Convert.ToInt32(m_CodiceFaseCont);
            IvaRow = GetDocRow("invoice", "expensevar", faseiva);
			if (IvaRow==null)return;
            if (MiddleRow != null) CurrCausaleIva = CfgFn.GetNoNullInt32(MiddleRow["movkind"]);
		}

		bool faseMaxInclusa(){
			if ((cmbFase.SelectedValue == null) || (cmbFase.SelectedValue == DBNull.Value)) return false;
			int currphase = CfgFn.GetNoNullInt32(cmbFase.SelectedValue);

			return (fasespesamax==currphase);
		}

		void ScollegaIva(){
			ScollegaIva(false);
		}

		void ScollegaIva(bool skiptipodoc){
			grpInvoiceDetail.Visible=false;
			ResetIva();
			DS.invoicedetail_iva.Clear();
			DS.invoicedetail_taxable.Clear();
			DS.invoice.Clear();
			ClearComboCausale();
			DataRow CurrRow= DS.expensevar.Rows[0];

			CurrRow["doc"] = DBNull.Value;
			CurrRow["docdate"] = DBNull.Value;
			CurrRow["description"]="";
            CurrRow["idinvkind"] = DBNull.Value;
            CurrRow["yinv"] = DBNull.Value;
            CurrRow["ninv"] = DBNull.Value;
            CurrRow["movkind"] = DBNull.Value;
            HelpForm.SetComboBoxValue(S1ubEntity_cmbTipoDoc, null);
            S1ubEntity_txtEsercizio.Text = "";
            S1ubEntity_txtNumero.Text = "";
            HelpForm.SetComboBoxValue(S1ubEntity_cmbCausale, null);
			DisabilitaDocIVA(skiptipodoc);
		}

		/// <summary>
		/// Collega la riga al movimento e aggiorna il form.
		/// </summary>
		/// <param name="Ordine"></param>
		void CollegaIva(DataRow Iva2, DataRow IvaResiduo){
			grpInvoiceDetail.Visible=true;
			if (Meta.EditMode){
				S1ubEntity_txtNumero.Text = Iva2["ninv"].ToString();
				S1ubEntity_txtEsercizio.Text = Iva2["yinv"].ToString();
				return;
			}
			if (Meta.IsEmpty) return;
			if (Iva2 == null) return;
			Hashtable ValoriDocumentoIva = new Hashtable();
			foreach (DataColumn C in DS.invoice.Columns) {
				if (!Iva2.Table.Columns.Contains(C.ColumnName)) {
					ValoriDocumentoIva[C.ColumnName] = DBNull.Value;
				}
				else {
					ValoriDocumentoIva[C.ColumnName]= Iva2[C.ColumnName];
				}
			}

			ScollegaIva();

			if (!faseMaxInclusa()) return;

			DataRow NewIvaR = DS.invoice.NewRow();

			foreach (DataColumn C in DS.invoice.Columns){
				NewIvaR[C.ColumnName]= ValoriDocumentoIva[C.ColumnName];
			}

			DS.invoice.Rows.Add(NewIvaR);
			NewIvaR.AcceptChanges();

			DataRow CurrRow= DS.expensevar.Rows[0];

            CurrRow["ninv"] = ValoriDocumentoIva["ninv"];
			S1ubEntity_txtNumero.Text=ValoriDocumentoIva["ninv"].ToString();
            CurrRow["yinv"] = ValoriDocumentoIva["yinv"];
			S1ubEntity_txtEsercizio.Text=ValoriDocumentoIva["yinv"].ToString();

			TipoDocChangePilotato=true;
            CurrRow["idinvkind"] = ValoriDocumentoIva["idinvkind"];
			HelpForm.SetComboBoxValue(S1ubEntity_cmbTipoDoc,ValoriDocumentoIva["idinvkind"]);
			TipoDocChangePilotato=false;
            
			CurrRow["description"] = ValoriDocumentoIva["description"];
			txtDescrizione.Text= ValoriDocumentoIva["description"].ToString();
			
			CurrRow["doc"] = "Doc."+ValoriDocumentoIva["doc"];
			txtDocumento.Text = "Doc."+ValoriDocumentoIva["doc"];
			CurrRow["docdate"] = ValoriDocumentoIva["docdate"];
			txtDataDocumento.Text=   HelpForm.StringValue( ValoriDocumentoIva["docdate"], txtDataDocumento.Tag.ToString());

			IvaLinkedMustBeEvalued=true;
			RintracciaIva();
			SetComboCausale(IvaResiduo);
		}

		void VisualizzaMainInfo_Iva(DataRow Iva2){

			if (!faseMaxInclusa())return;
			grpInvoiceDetail.Visible=true;

			S1ubEntity_txtNumero.Text= Iva2["ninv"].ToString();
			S1ubEntity_txtEsercizio.Text = Iva2["yinv"].ToString();

			TipoDocChangePilotato=true;
			HelpForm.SetComboBoxValue(S1ubEntity_cmbTipoDoc, Iva2["idinvkind"]);
			TipoDocChangePilotato=false;
		}

		void AbilitaDisabilitaControlliFattura(bool abilita){
			bool abilitagrid= abilita && faseMaxInclusa();
			btnAddDettInvoice.Enabled= abilitagrid;
			btnRemoveDettInvoice.Enabled=abilitagrid;
			btnEditInvDet.Enabled= abilitagrid;
			grpInvoiceDetail.Visible= abilitagrid;
			CurrCausaleIva= GetCausaleIva();
			if (CurrCausaleIva==1||CurrCausaleIva==3){
				dgrDettagliFattura.Tag="invoicedetail_taxable.listaimpon";
				dgrDettagliFattura.TableStyles.Clear();
				HelpForm.SetDataGrid(dgrDettagliFattura,DS.invoicedetail_taxable);
				if (Meta.EditMode) DS.invoicedetail_iva.Clear(); //Importante per evitare problemi in fase di delete
			}
			if (CurrCausaleIva==2){
				dgrDettagliFattura.TableStyles.Clear();
				dgrDettagliFattura.Tag="invoicedetail_iva.listaimpos";
				HelpForm.SetDataGrid(dgrDettagliFattura,DS.invoicedetail_iva);
			}
            }

		#endregion



		private void S1ubEntity_cmbTipoDoc_SelectedIndexChanged(object sender, System.EventArgs e) {
			if (!Meta.DrawStateIsDone) return;
			if (TipoDocChangePilotato) return;
			TipoDocChangePilotato=true;
			if (Meta.InsertMode) ScollegaIva(true);
			AbilitaDisabilitaControlliFattura(true);
			S1ubEntity_txtEsercizio.Text="";
			S1ubEntity_txtNumero.Text="";
			TipoDocChangePilotato=false;
		}



        DataTable GetFinanziamentiDisponibili(object idexp, int nphase) {
            int finPhase = CfgFn.GetNoNullInt32(Meta.GetSys("expensefinphase"));
            int maxPhase = CfgFn.GetNoNullInt32(Meta.GetSys("maxexpensephase"));

            if (nphase != finPhase && nphase != maxPhase) return null; //non si associano fin. a questa fase
            string table;
            if (nphase == finPhase)
                table = "underwritingappropriation";
            else
                table = "underwritingpayment";
            DataTable T = Conn.RUN_SELECT(table, "*", null, QHS.CmpEq("idexp", idexp), null, false);
            if (T==null || T.Rows.Count == 0) return null;
            return T;

        }


        void SelezionaFinanziamento(DataTable FinanziamentiDisponibili) {
            if (Meta.IsEmpty) return; //superfluo in expensevar_detail
            if (FinanziamentiDisponibili == null) return;
            if (FinanziamentiDisponibili.Select().Length == 0) return;

            QueryHelper QHS = Meta.Conn.GetQueryHelper();
            string filteridunderwriting = QHS.FieldIn("idunderwriting", FinanziamentiDisponibili.Select());

            MetaData MetaUnd = MetaData.GetMetaData(this, "underwriting");
            MetaUnd.DS = new DataSet();
            MetaUnd.linkedForm = this;
            MetaUnd.FilterLocked = true;
            DataRow Und = MetaUnd.SelectOne("default", filteridunderwriting, "underwritingview", null);
            if (Und == null) return;
            object idunderwriting = Und["idunderwriting"];
            DS.underwriting.Clear();
            Meta.Conn.RUN_SELECT_INTO_TABLE(DS.underwriting, null, QHS.CmpEq("idunderwriting", idunderwriting), null, false);
            txtUnderwriting.Text = Und["title"].ToString();
            DS.expensevar.Rows[0]["idunderwriting"] = idunderwriting;
        }

        private void btnUnderwriting_Click(object sender, EventArgs e) {
            if (Meta.IsEmpty || DS.expenseview.Rows.Count==0){
                Meta.DoMainCommand("choose.underwriting.default.(active='S')");
                return;
            }
            DataRow Exp= DS.expenseview.Rows[0];
            DataTable FinanziamentiDisponibili = GetFinanziamentiDisponibili(Exp["idexp"],
                            CfgFn.GetNoNullInt32(Exp["nphase"]));
            SelezionaFinanziamento(FinanziamentiDisponibili);
        }

        private void btnApplicaSplitPayment_Click(object sender, EventArgs e)
        {
            if (Meta.IsEmpty) return;
            if (Meta.InsertMode) return; 
            MetaData MElenco = MetaData.GetMetaData(this, "expense");
            
            if (MElenco == null) return;
            string filter = QHC.CmpEq("idexp", DS.expensevar.Rows[0]["idexp"]);
            MElenco.ContextFilter = filter;
            bool result = MElenco.Edit(Meta.linkedForm.ParentForm, "default", false);
            DataRow R = MElenco.SelectOne("default", filter, null, null);
            if (R != null) MElenco.SelectRow(R, "default"); else return;

            DataRow rLast = MElenco.DS.Tables["expenselast"].Rows[0];
            rLast["flag"]= CfgFn.GetNoNullInt32(rLast["flag"]) & 0xFFFB; 
            //Ossia puliamo il bit 2, di peso 4
            MElenco.FreshForm();

            MetaData.sendBroadcast(this, "ForzaRecuperoSplitPayment");
            MElenco.SaveFormData();

            if (MElenco.DS.HasChanges())
            {
                //rendi il bottone invisibile
                btnApplicaSplitPayment.Visible = false;
            }
        }
	}
}