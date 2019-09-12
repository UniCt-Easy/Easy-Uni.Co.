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
using funzioni_configurazione;
using q = metadatalibrary.MetaExpression;

namespace expensevar_detail { //variazionespesadettaglio//
    /// <summary>
    /// Summary description for frmVariazioneSpesaDettaglio.
    /// </summary>
    public class Frm_expensevar_detail : System.Windows.Forms.Form {
        private System.Windows.Forms.GroupBox grpImporto;
        private System.Windows.Forms.RadioButton rdbAumento;
        private System.Windows.Forms.RadioButton rdbDiminuzione;
        private System.Windows.Forms.TextBox txtImporto;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtDataDocumento;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtDocumento;
        private System.Windows.Forms.TextBox txtDescrizione;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox grpVariazione;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNumVariazione;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtEsercVariazione;
        private System.Windows.Forms.GroupBox grpMovimento;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNumSpesa;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtEsercSpesa;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtDataContabile;
        private System.Windows.Forms.Label label7;

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;

        private System.Windows.Forms.ComboBox cmbFase;
        public vistaForm DS;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.GroupBox grpTrasferimento;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton radAnnPar;
        private System.Windows.Forms.RadioButton radAnnullo;
        private System.Windows.Forms.RadioButton radNormale;
        private RadioButton radEdit;
        private GroupBox groupBox6;
        private Label label14;
        private TextBox textBox2;
        private Label label15;
        private TextBox textBox3;
        private bool maxphase = false;
        private GroupBox grpUnderWrinting;
        private Button btnUnderwriting;
        private TextBox txtUnderwriting;
        private GroupBox grpDocumento;
        private ComboBox S1ubEntity_cmbCausale;
        private Label label13;
        private TextBox S1ubEntity_txtNumero;
        private TextBox S1ubEntity_txtEsercizio;
        private Button btnDocumento;
        private ComboBox S1ubEntity_cmbTipoDoc;
        private Label label6;
        private Label label11;
        private Label label12;
        private CheckBox chkDocIVA;
        MetaData Meta;
        private bool ChangingFase = false;
        private object m_CodiceCredDebD = null;
        private object m_CodiceCredDebS = null;
        private bool m_DocIVA = false;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage grpInvoiceDetail;
        private GroupBox groupBox3;
        private DataGrid dgrDettagliFattura;
        private Button btnEditInvDet;
        private TextBox txtTotInvoiceDetail;
        private Label label17;
        private Button btnRemoveDettInvoice;
        private Button btnAddDettInvoice;
        private bool InChiusura;
        private string command;
        private decimal totimponibile_dociva;
        private decimal totiva_dociva;
        private decimal assigned_imponibile_dociva;
        private decimal assigned_iva_dociva;
		private RadioButton radCsa;
		private decimal assigned_gen_dociva;

        public Frm_expensevar_detail() {
            InitializeComponent();
            SetComboCausale();

        }

        DataTable FinanziamentiDisponibili = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing) {
            if (disposing) {
                if (components != null) {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
			this.grpImporto = new System.Windows.Forms.GroupBox();
			this.rdbAumento = new System.Windows.Forms.RadioButton();
			this.rdbDiminuzione = new System.Windows.Forms.RadioButton();
			this.txtImporto = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.txtDataDocumento = new System.Windows.Forms.TextBox();
			this.label9 = new System.Windows.Forms.Label();
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
			this.DS = new expensevar_detail.vistaForm();
			this.label3 = new System.Windows.Forms.Label();
			this.txtNumSpesa = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.txtEsercSpesa = new System.Windows.Forms.TextBox();
			this.label10 = new System.Windows.Forms.Label();
			this.txtDataContabile = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnOk = new System.Windows.Forms.Button();
			this.grpTrasferimento = new System.Windows.Forms.GroupBox();
			this.radioButton3 = new System.Windows.Forms.RadioButton();
			this.radioButton1 = new System.Windows.Forms.RadioButton();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.radEdit = new System.Windows.Forms.RadioButton();
			this.radAnnPar = new System.Windows.Forms.RadioButton();
			this.radAnnullo = new System.Windows.Forms.RadioButton();
			this.radNormale = new System.Windows.Forms.RadioButton();
			this.groupBox6 = new System.Windows.Forms.GroupBox();
			this.label14 = new System.Windows.Forms.Label();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.label15 = new System.Windows.Forms.Label();
			this.textBox3 = new System.Windows.Forms.TextBox();
			this.grpUnderWrinting = new System.Windows.Forms.GroupBox();
			this.txtUnderwriting = new System.Windows.Forms.TextBox();
			this.btnUnderwriting = new System.Windows.Forms.Button();
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
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.grpInvoiceDetail = new System.Windows.Forms.TabPage();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.dgrDettagliFattura = new System.Windows.Forms.DataGrid();
			this.btnEditInvDet = new System.Windows.Forms.Button();
			this.txtTotInvoiceDetail = new System.Windows.Forms.TextBox();
			this.label17 = new System.Windows.Forms.Label();
			this.btnRemoveDettInvoice = new System.Windows.Forms.Button();
			this.btnAddDettInvoice = new System.Windows.Forms.Button();
			this.radCsa = new System.Windows.Forms.RadioButton();
			this.grpImporto.SuspendLayout();
			this.grpVariazione.SuspendLayout();
			this.grpMovimento.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
			this.grpTrasferimento.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox6.SuspendLayout();
			this.grpUnderWrinting.SuspendLayout();
			this.grpDocumento.SuspendLayout();
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.grpInvoiceDetail.SuspendLayout();
			this.groupBox3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgrDettagliFattura)).BeginInit();
			this.SuspendLayout();
			// 
			// grpImporto
			// 
			this.grpImporto.Controls.Add(this.rdbAumento);
			this.grpImporto.Controls.Add(this.rdbDiminuzione);
			this.grpImporto.Controls.Add(this.txtImporto);
			this.grpImporto.Location = new System.Drawing.Point(273, 309);
			this.grpImporto.Name = "grpImporto";
			this.grpImporto.Size = new System.Drawing.Size(256, 64);
			this.grpImporto.TabIndex = 5;
			this.grpImporto.TabStop = false;
			this.grpImporto.Tag = "expensevar.amount.valuesigned";
			this.grpImporto.Text = "Importo";
			// 
			// rdbAumento
			// 
			this.rdbAumento.Location = new System.Drawing.Point(152, 16);
			this.rdbAumento.Name = "rdbAumento";
			this.rdbAumento.Size = new System.Drawing.Size(88, 16);
			this.rdbAumento.TabIndex = 85;
			this.rdbAumento.Tag = "+";
			this.rdbAumento.Text = "Aumento";
			// 
			// rdbDiminuzione
			// 
			this.rdbDiminuzione.Location = new System.Drawing.Point(152, 40);
			this.rdbDiminuzione.Name = "rdbDiminuzione";
			this.rdbDiminuzione.Size = new System.Drawing.Size(88, 16);
			this.rdbDiminuzione.TabIndex = 84;
			this.rdbDiminuzione.Tag = "-";
			this.rdbDiminuzione.Text = "Diminuzione";
			// 
			// txtImporto
			// 
			this.txtImporto.Location = new System.Drawing.Point(16, 24);
			this.txtImporto.Name = "txtImporto";
			this.txtImporto.Size = new System.Drawing.Size(120, 20);
			this.txtImporto.TabIndex = 82;
			this.txtImporto.Tag = "expensevar.amount";
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(572, 339);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(64, 21);
			this.label8.TabIndex = 111;
			this.label8.Text = "Data doc.:";
			this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtDataDocumento
			// 
			this.txtDataDocumento.Location = new System.Drawing.Point(570, 361);
			this.txtDataDocumento.Name = "txtDataDocumento";
			this.txtDataDocumento.Size = new System.Drawing.Size(80, 20);
			this.txtDataDocumento.TabIndex = 7;
			this.txtDataDocumento.Tag = "expensevar.docdate";
			// 
			// label9
			// 
			this.label9.Location = new System.Drawing.Point(572, 305);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(72, 16);
			this.label9.TabIndex = 109;
			this.label9.Text = "Documento";
			this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtDocumento
			// 
			this.txtDocumento.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtDocumento.Location = new System.Drawing.Point(575, 320);
			this.txtDocumento.Name = "txtDocumento";
			this.txtDocumento.Size = new System.Drawing.Size(355, 20);
			this.txtDocumento.TabIndex = 6;
			this.txtDocumento.Tag = "expensevar.doc";
			// 
			// txtDescrizione
			// 
			this.txtDescrizione.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtDescrizione.Location = new System.Drawing.Point(273, 243);
			this.txtDescrizione.Multiline = true;
			this.txtDescrizione.Name = "txtDescrizione";
			this.txtDescrizione.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtDescrizione.Size = new System.Drawing.Size(657, 56);
			this.txtDescrizione.TabIndex = 3;
			this.txtDescrizione.Tag = "expensevar.description";
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(270, 227);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(64, 16);
			this.label5.TabIndex = 104;
			this.label5.Text = "Descrizione";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// grpVariazione
			// 
			this.grpVariazione.Controls.Add(this.label1);
			this.grpVariazione.Controls.Add(this.txtNumVariazione);
			this.grpVariazione.Controls.Add(this.label2);
			this.grpVariazione.Controls.Add(this.txtEsercVariazione);
			this.grpVariazione.Location = new System.Drawing.Point(6, 227);
			this.grpVariazione.Name = "grpVariazione";
			this.grpVariazione.Size = new System.Drawing.Size(246, 75);
			this.grpVariazione.TabIndex = 2;
			this.grpVariazione.TabStop = false;
			this.grpVariazione.Text = "Variazione";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(32, 40);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(64, 24);
			this.label1.TabIndex = 11;
			this.label1.Text = "Numero:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtNumVariazione
			// 
			this.txtNumVariazione.Location = new System.Drawing.Point(104, 42);
			this.txtNumVariazione.Name = "txtNumVariazione";
			this.txtNumVariazione.ReadOnly = true;
			this.txtNumVariazione.Size = new System.Drawing.Size(96, 20);
			this.txtNumVariazione.TabIndex = 10;
			this.txtNumVariazione.Tag = "expensevar.nvar";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(40, 16);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(64, 24);
			this.label2.TabIndex = 9;
			this.label2.Text = "Esercizio:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtEsercVariazione
			// 
			this.txtEsercVariazione.Location = new System.Drawing.Point(104, 16);
			this.txtEsercVariazione.Name = "txtEsercVariazione";
			this.txtEsercVariazione.ReadOnly = true;
			this.txtEsercVariazione.Size = new System.Drawing.Size(56, 20);
			this.txtEsercVariazione.TabIndex = 8;
			this.txtEsercVariazione.Tag = "expensevar.yvar";
			// 
			// grpMovimento
			// 
			this.grpMovimento.Controls.Add(this.cmbFase);
			this.grpMovimento.Controls.Add(this.label3);
			this.grpMovimento.Controls.Add(this.txtNumSpesa);
			this.grpMovimento.Controls.Add(this.label4);
			this.grpMovimento.Controls.Add(this.txtEsercSpesa);
			this.grpMovimento.Controls.Add(this.label10);
			this.grpMovimento.Location = new System.Drawing.Point(6, 6);
			this.grpMovimento.Name = "grpMovimento";
			this.grpMovimento.Size = new System.Drawing.Size(412, 80);
			this.grpMovimento.TabIndex = 1;
			this.grpMovimento.TabStop = false;
			this.grpMovimento.Tag = "";
			this.grpMovimento.Text = "Movimento";
			// 
			// cmbFase
			// 
			this.cmbFase.DataSource = this.DS.expensephase;
			this.cmbFase.DisplayMember = "description";
			this.cmbFase.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbFase.Enabled = false;
			this.cmbFase.ItemHeight = 13;
			this.cmbFase.Location = new System.Drawing.Point(104, 16);
			this.cmbFase.Name = "cmbFase";
			this.cmbFase.Size = new System.Drawing.Size(272, 21);
			this.cmbFase.TabIndex = 8;
			this.cmbFase.Tag = "";
			this.cmbFase.ValueMember = "nphase";
			// 
			// DS
			// 
			this.DS.DataSetName = "vistaForm";
			this.DS.EnforceConstraints = false;
			this.DS.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(216, 48);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(64, 24);
			this.label3.TabIndex = 7;
			this.label3.Text = "Numero:";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtNumSpesa
			// 
			this.txtNumSpesa.Location = new System.Drawing.Point(280, 48);
			this.txtNumSpesa.Name = "txtNumSpesa";
			this.txtNumSpesa.ReadOnly = true;
			this.txtNumSpesa.Size = new System.Drawing.Size(96, 20);
			this.txtNumSpesa.TabIndex = 6;
			this.txtNumSpesa.Tag = "";
			this.txtNumSpesa.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(40, 48);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(64, 24);
			this.label4.TabIndex = 5;
			this.label4.Text = "Esercizio:";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtEsercSpesa
			// 
			this.txtEsercSpesa.Location = new System.Drawing.Point(104, 48);
			this.txtEsercSpesa.Name = "txtEsercSpesa";
			this.txtEsercSpesa.ReadOnly = true;
			this.txtEsercSpesa.Size = new System.Drawing.Size(56, 20);
			this.txtEsercSpesa.TabIndex = 4;
			this.txtEsercSpesa.Tag = "";
			this.txtEsercSpesa.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label10
			// 
			this.label10.Location = new System.Drawing.Point(24, 16);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(72, 24);
			this.label10.TabIndex = 90;
			this.label10.Text = "Fase:";
			this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtDataContabile
			// 
			this.txtDataContabile.Location = new System.Drawing.Point(365, 402);
			this.txtDataContabile.Name = "txtDataContabile";
			this.txtDataContabile.Size = new System.Drawing.Size(81, 20);
			this.txtDataContabile.TabIndex = 8;
			this.txtDataContabile.Tag = "expensevar.adate";
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(258, 401);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(101, 20);
			this.label7.TabIndex = 107;
			this.label7.Text = "Data contabile";
			this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(624, 506);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 23);
			this.btnCancel.TabIndex = 12;
			this.btnCancel.Text = "Cancel";
			// 
			// btnOk
			// 
			this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnOk.Location = new System.Drawing.Point(752, 506);
			this.btnOk.Name = "btnOk";
			this.btnOk.Size = new System.Drawing.Size(75, 23);
			this.btnOk.TabIndex = 13;
			this.btnOk.Tag = "mainsave";
			this.btnOk.Text = "Ok";
			// 
			// grpTrasferimento
			// 
			this.grpTrasferimento.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.grpTrasferimento.Controls.Add(this.radioButton3);
			this.grpTrasferimento.Controls.Add(this.radioButton1);
			this.grpTrasferimento.Location = new System.Drawing.Point(6, 496);
			this.grpTrasferimento.Name = "grpTrasferimento";
			this.grpTrasferimento.Size = new System.Drawing.Size(192, 39);
			this.grpTrasferimento.TabIndex = 11;
			this.grpTrasferimento.TabStop = false;
			this.grpTrasferimento.Tag = "";
			this.grpTrasferimento.Text = "Tipo trasferimento";
			// 
			// radioButton3
			// 
			this.radioButton3.Location = new System.Drawing.Point(103, 17);
			this.radioButton3.Name = "radioButton3";
			this.radioButton3.Size = new System.Drawing.Size(80, 16);
			this.radioButton3.TabIndex = 86;
			this.radioButton3.Tag = "expensevar.transferkind:A";
			this.radioButton3.Text = "Altro";
			// 
			// radioButton1
			// 
			this.radioButton1.Location = new System.Drawing.Point(22, 17);
			this.radioButton1.Name = "radioButton1";
			this.radioButton1.Size = new System.Drawing.Size(80, 16);
			this.radioButton1.TabIndex = 85;
			this.radioButton1.Tag = "expensevar.transferkind:I";
			this.radioButton1.Text = "Interno";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.radCsa);
			this.groupBox2.Controls.Add(this.radEdit);
			this.groupBox2.Controls.Add(this.radAnnPar);
			this.groupBox2.Controls.Add(this.radAnnullo);
			this.groupBox2.Controls.Add(this.radNormale);
			this.groupBox2.Location = new System.Drawing.Point(6, 308);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(247, 136);
			this.groupBox2.TabIndex = 4;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Tipo variazione";
			// 
			// radEdit
			// 
			this.radEdit.Location = new System.Drawing.Point(16, 84);
			this.radEdit.Name = "radEdit";
			this.radEdit.Size = new System.Drawing.Size(225, 19);
			this.radEdit.TabIndex = 7;
			this.radEdit.Text = "Modifica Dati di Pagamenti Trasmessi";
			// 
			// radAnnPar
			// 
			this.radAnnPar.Location = new System.Drawing.Point(16, 61);
			this.radAnnPar.Name = "radAnnPar";
			this.radAnnPar.Size = new System.Drawing.Size(152, 16);
			this.radAnnPar.TabIndex = 2;
			this.radAnnPar.Text = "Annullamento parziale";
			// 
			// radAnnullo
			// 
			this.radAnnullo.Enabled = false;
			this.radAnnullo.Location = new System.Drawing.Point(16, 39);
			this.radAnnullo.Name = "radAnnullo";
			this.radAnnullo.Size = new System.Drawing.Size(152, 16);
			this.radAnnullo.TabIndex = 1;
			this.radAnnullo.Text = "Annullamento mandato";
			// 
			// radNormale
			// 
			this.radNormale.Location = new System.Drawing.Point(16, 16);
			this.radNormale.Name = "radNormale";
			this.radNormale.Size = new System.Drawing.Size(104, 16);
			this.radNormale.TabIndex = 0;
			this.radNormale.Text = "Normale";
			// 
			// groupBox6
			// 
			this.groupBox6.Controls.Add(this.label14);
			this.groupBox6.Controls.Add(this.textBox2);
			this.groupBox6.Controls.Add(this.label15);
			this.groupBox6.Controls.Add(this.textBox3);
			this.groupBox6.Location = new System.Drawing.Point(459, 387);
			this.groupBox6.Name = "groupBox6";
			this.groupBox6.Size = new System.Drawing.Size(398, 43);
			this.groupBox6.TabIndex = 10;
			this.groupBox6.TabStop = false;
			this.groupBox6.Text = "Distinta di trasmissione ";
			// 
			// label14
			// 
			this.label14.Location = new System.Drawing.Point(218, 16);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(72, 16);
			this.label14.TabIndex = 86;
			this.label14.Text = "Data trasm.:";
			this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// textBox2
			// 
			this.textBox2.Location = new System.Drawing.Point(296, 14);
			this.textBox2.Name = "textBox2";
			this.textBox2.ReadOnly = true;
			this.textBox2.Size = new System.Drawing.Size(96, 20);
			this.textBox2.TabIndex = 12;
			this.textBox2.TabStop = false;
			this.textBox2.Tag = "paymenttransmission.transmissiondate";
			// 
			// label15
			// 
			this.label15.Location = new System.Drawing.Point(31, 16);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(72, 16);
			this.label15.TabIndex = 84;
			this.label15.Text = "Numero:";
			this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// textBox3
			// 
			this.textBox3.Location = new System.Drawing.Point(111, 14);
			this.textBox3.Name = "textBox3";
			this.textBox3.ReadOnly = true;
			this.textBox3.Size = new System.Drawing.Size(96, 20);
			this.textBox3.TabIndex = 11;
			this.textBox3.TabStop = false;
			this.textBox3.Tag = "paymenttransmission.npaymenttransmission";
			// 
			// grpUnderWrinting
			// 
			this.grpUnderWrinting.Controls.Add(this.txtUnderwriting);
			this.grpUnderWrinting.Controls.Add(this.btnUnderwriting);
			this.grpUnderWrinting.Location = new System.Drawing.Point(5, 436);
			this.grpUnderWrinting.Name = "grpUnderWrinting";
			this.grpUnderWrinting.Size = new System.Drawing.Size(448, 43);
			this.grpUnderWrinting.TabIndex = 9;
			this.grpUnderWrinting.TabStop = false;
			this.grpUnderWrinting.Tag = "AutoChoose.txtUnderwriting.default.(active = \'S\')";
			// 
			// txtUnderwriting
			// 
			this.txtUnderwriting.Location = new System.Drawing.Point(117, 14);
			this.txtUnderwriting.Name = "txtUnderwriting";
			this.txtUnderwriting.Size = new System.Drawing.Size(324, 20);
			this.txtUnderwriting.TabIndex = 83;
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
			this.grpDocumento.Location = new System.Drawing.Point(6, 116);
			this.grpDocumento.Name = "grpDocumento";
			this.grpDocumento.Size = new System.Drawing.Size(924, 78);
			this.grpDocumento.TabIndex = 113;
			this.grpDocumento.TabStop = false;
			this.grpDocumento.Tag = "AutoChoose.S1ubEntity_txtNumero.lista";
			this.grpDocumento.Text = "Nota di Credito";
			// 
			// S1ubEntity_cmbCausale
			// 
			this.S1ubEntity_cmbCausale.DisplayMember = "descrizione";
			this.S1ubEntity_cmbCausale.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.S1ubEntity_cmbCausale.Location = new System.Drawing.Point(107, 49);
			this.S1ubEntity_cmbCausale.Name = "S1ubEntity_cmbCausale";
			this.S1ubEntity_cmbCausale.Size = new System.Drawing.Size(321, 21);
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
			this.S1ubEntity_cmbTipoDoc.DisplayMember = "description";
			this.S1ubEntity_cmbTipoDoc.Location = new System.Drawing.Point(107, 19);
			this.S1ubEntity_cmbTipoDoc.Name = "S1ubEntity_cmbTipoDoc";
			this.S1ubEntity_cmbTipoDoc.Size = new System.Drawing.Size(321, 21);
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
			this.chkDocIVA.Location = new System.Drawing.Point(6, 92);
			this.chkDocIVA.Name = "chkDocIVA";
			this.chkDocIVA.Size = new System.Drawing.Size(264, 18);
			this.chkDocIVA.TabIndex = 112;
			this.chkDocIVA.Text = "Abilita contabilizzazione delle note di credito";
			this.chkDocIVA.CheckedChanged += new System.EventHandler(this.chkDocIVA_CheckedChanged);
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Controls.Add(this.grpInvoiceDetail);
			this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControl1.Location = new System.Drawing.Point(0, 0);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(960, 575);
			this.tabControl1.TabIndex = 114;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.grpMovimento);
			this.tabPage1.Controls.Add(this.grpDocumento);
			this.tabPage1.Controls.Add(this.label7);
			this.tabPage1.Controls.Add(this.chkDocIVA);
			this.tabPage1.Controls.Add(this.grpVariazione);
			this.tabPage1.Controls.Add(this.grpUnderWrinting);
			this.tabPage1.Controls.Add(this.label5);
			this.tabPage1.Controls.Add(this.groupBox6);
			this.tabPage1.Controls.Add(this.label9);
			this.tabPage1.Controls.Add(this.groupBox2);
			this.tabPage1.Controls.Add(this.txtDescrizione);
			this.tabPage1.Controls.Add(this.grpTrasferimento);
			this.tabPage1.Controls.Add(this.txtDocumento);
			this.tabPage1.Controls.Add(this.txtDataContabile);
			this.tabPage1.Controls.Add(this.txtDataDocumento);
			this.tabPage1.Controls.Add(this.btnOk);
			this.tabPage1.Controls.Add(this.label8);
			this.tabPage1.Controls.Add(this.btnCancel);
			this.tabPage1.Controls.Add(this.grpImporto);
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(952, 549);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Principale";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// grpInvoiceDetail
			// 
			this.grpInvoiceDetail.Controls.Add(this.groupBox3);
			this.grpInvoiceDetail.Location = new System.Drawing.Point(4, 22);
			this.grpInvoiceDetail.Name = "grpInvoiceDetail";
			this.grpInvoiceDetail.Padding = new System.Windows.Forms.Padding(3);
			this.grpInvoiceDetail.Size = new System.Drawing.Size(952, 549);
			this.grpInvoiceDetail.TabIndex = 1;
			this.grpInvoiceDetail.Text = "Dettagli";
			this.grpInvoiceDetail.UseVisualStyleBackColor = true;
			// 
			// groupBox3
			// 
			this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox3.Controls.Add(this.dgrDettagliFattura);
			this.groupBox3.Controls.Add(this.btnEditInvDet);
			this.groupBox3.Controls.Add(this.txtTotInvoiceDetail);
			this.groupBox3.Controls.Add(this.label17);
			this.groupBox3.Controls.Add(this.btnRemoveDettInvoice);
			this.groupBox3.Controls.Add(this.btnAddDettInvoice);
			this.groupBox3.Location = new System.Drawing.Point(15, 16);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(934, 525);
			this.groupBox3.TabIndex = 1;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Dettagli Fattura";
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
			this.dgrDettagliFattura.Size = new System.Drawing.Size(832, 509);
			this.dgrDettagliFattura.TabIndex = 13;
			// 
			// btnEditInvDet
			// 
			this.btnEditInvDet.Location = new System.Drawing.Point(8, 80);
			this.btnEditInvDet.Name = "btnEditInvDet";
			this.btnEditInvDet.Size = new System.Drawing.Size(75, 23);
			this.btnEditInvDet.TabIndex = 12;
			this.btnEditInvDet.Text = "Modifica..";
			this.btnEditInvDet.Click += new System.EventHandler(this.btnEditInvDet_Click);
			// 
			// txtTotInvoiceDetail
			// 
			this.txtTotInvoiceDetail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.txtTotInvoiceDetail.Location = new System.Drawing.Point(6, 495);
			this.txtTotInvoiceDetail.Name = "txtTotInvoiceDetail";
			this.txtTotInvoiceDetail.ReadOnly = true;
			this.txtTotInvoiceDetail.Size = new System.Drawing.Size(80, 20);
			this.txtTotInvoiceDetail.TabIndex = 11;
			this.txtTotInvoiceDetail.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label17
			// 
			this.label17.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label17.Location = new System.Drawing.Point(6, 476);
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
			this.btnRemoveDettInvoice.Click += new System.EventHandler(this.btnRemoveDettInvoice_Click);
			// 
			// btnAddDettInvoice
			// 
			this.btnAddDettInvoice.Location = new System.Drawing.Point(8, 16);
			this.btnAddDettInvoice.Name = "btnAddDettInvoice";
			this.btnAddDettInvoice.Size = new System.Drawing.Size(75, 23);
			this.btnAddDettInvoice.TabIndex = 8;
			this.btnAddDettInvoice.Text = "Aggiungi";
			this.btnAddDettInvoice.Click += new System.EventHandler(this.btnAddDettInvoice_Click);
			// 
			// radCsa
			// 
			this.radCsa.Location = new System.Drawing.Point(17, 108);
			this.radCsa.Name = "radCsa";
			this.radCsa.Size = new System.Drawing.Size(210, 19);
			this.radCsa.TabIndex = 8;
			this.radCsa.Text = "Azzeramento Versamenti CSA";
			// 
			// Frm_expensevar_detail
			// 
			this.AcceptButton = this.btnOk;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(960, 575);
			this.Controls.Add(this.tabControl1);
			this.Name = "Frm_expensevar_detail";
			this.Text = "frmVariazioneSpesaDettaglio";
			this.grpImporto.ResumeLayout(false);
			this.grpImporto.PerformLayout();
			this.grpVariazione.ResumeLayout(false);
			this.grpVariazione.PerformLayout();
			this.grpMovimento.ResumeLayout(false);
			this.grpMovimento.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
			this.grpTrasferimento.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.groupBox6.ResumeLayout(false);
			this.groupBox6.PerformLayout();
			this.grpUnderWrinting.ResumeLayout(false);
			this.grpUnderWrinting.PerformLayout();
			this.grpDocumento.ResumeLayout(false);
			this.grpDocumento.PerformLayout();
			this.tabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tabPage1.PerformLayout();
			this.grpInvoiceDetail.ResumeLayout(false);
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgrDettagliFattura)).EndInit();
			this.ResumeLayout(false);

        }

        #endregion

        private DataAccess Conn;
        private string docoper_command = "choose.invoiceavailable.variazione";
        private string docoper_command_clear = "choose.invoiceavailable.unknown.clear";

        QueryHelper QHS;
        CQueryHelper QHC;
        int esercizio;


        int CurrCausaleIva;
        DataRow IvaLinked;
        bool IvaLinkedMustBeEvalued;
        int fasespesamax;
        bool TipoDocChangePilotato = false;
        private int currPhase;

        public void MetaData_AfterLink() {
            Meta = MetaData.GetMetaData(this);
            Conn = Meta.Conn;
            GetData.CacheTable(DS.expensephase, null, null, true);
            QHC = new CQueryHelper();
            QHS = Conn.GetQueryHelper();
            esercizio = CfgFn.GetNoNullInt32(Meta.GetSys("esercizio"));

            string filterflag = QHS.AppAnd(QHS.BitClear("flag", 0), QHS.BitSet("flag", 2));
            GetData.CacheTable(DS.invoicekind, filterflag, null, true);
            GetData.SetStaticFilter(DS.invoiceavailable, filterflag);
            PostData.MarkAsTemporaryTable(DS.tipomovimento, false);
            string filterfasespesa = QHS.IsNotNull("nphaseexpense");
            DataAccess.SetTableForReading(DS.invoicedetail_iva_nc, "invoicedetailview");
            DataAccess.SetTableForReading(DS.invoicedetail_taxable_nc, "invoicedetailview");
            QueryCreator.SetTableForPosting(DS.invoicedetail_iva_nc, "invoicedetail");
            QueryCreator.SetTableForPosting(DS.invoicedetail_taxable_nc, "invoicedetail");
            GetData.SetStaticFilter(DS.invoicedetail_iva_nc, QHS.CmpEq("flagvariation", 'S'));
            GetData.SetStaticFilter(DS.invoicedetail_taxable_nc, QHS.CmpEq("flagvariation", 'S'));
            fasespesamax = CfgFn.GetNoNullInt32(Meta.GetSys("maxexpensephase"));

            Meta.MarkTableAsNotEntityChild(DS.invoicedetail_iva_nc);
            Meta.MarkTableAsNotEntityChild(DS.invoicedetail_taxable_nc);
            S1ubEntity_cmbTipoDoc.DataSource = DS.invoicekind;
            S1ubEntity_cmbTipoDoc.DisplayMember = "description";
            S1ubEntity_cmbTipoDoc.ValueMember = "idinvkind";

            S1ubEntity_cmbCausale.DataSource = DS.tipomovimento;
            S1ubEntity_cmbCausale.DisplayMember = "descrizione";
            S1ubEntity_cmbCausale.ValueMember = "idtipo";
            ParentSpesa = Meta.SourceRow.Table.DataSet.Tables["expense"].Rows[0];
            currPhase = CfgFn.GetNoNullInt32(ParentSpesa["nphase"]);

            thereWasInv = Meta.sourceRow.RowState!=DataRowState.Added  && (Meta.sourceRow["idinvkind", DataRowVersion.Original] != DBNull.Value);
            if (thereWasInv) {
                oldInvoiceFilter = q.eq("idinvkind", Meta.sourceRow["idinvkind", DataRowVersion.Original]) &
                                   q.eq("yinv", Meta.sourceRow["yinv", DataRowVersion.Original]) &
                                   q.eq("ninv", Meta.sourceRow["ninv", DataRowVersion.Original]);
            }
            else {
                if (Meta.sourceRow.RowState == DataRowState.Added)
                    thereWasInv = (Meta.sourceRow["idinvkind"] != DBNull.Value);
                if (thereWasInv) {
                    oldInvoiceFilter = q.eq("idinvkind", Meta.sourceRow["idinvkind"]) &
                                       q.eq("yinv", Meta.sourceRow["yinv"]) &
                                       q.eq("ninv", Meta.sourceRow["ninv"]);
                }
            }

        }

        private q oldInvoiceFilter;

        private object parentIdUPB;
        private DataRow ParentSpesa;

        public void MetaData_AfterActivation() {
            

            //Fill GroupBox "Movimento"
            //Meta.helpForm.addExtraEntity(DS.invoicedetail_taxable_nc.TableName);
            //Meta.helpForm.addExtraEntity(DS.invoicedetail_iva_nc.TableName);
            getRowsFromParent();

            DataRow ParentImpSpesa = Meta.SourceRow.Table.DataSet.Tables["expenseyear"].Rows[0];
            parentIdUPB = ParentImpSpesa["idupb"];

            cmbFase.SelectedValue = currPhase;
            
            
            if (currPhase == fasespesamax) {
                FinanziamentiDisponibili = ParentSpesa.Table.DataSet.Tables["underwritingpayment"];
                maxphase = true;
            }
            else {
                FinanziamentiDisponibili = ParentSpesa.Table.DataSet.Tables["underwritingappropriation"];
                maxphase = false;
            }
            
            radEdit.Enabled = maxphase;
            txtEsercSpesa.Text = ParentSpesa["ymov"].ToString();
            txtNumSpesa.Text = ParentSpesa["nmov"].ToString();
            EnableDisableUnderWrinting(currPhase);


            MetaData MetaInvDet = MetaData.GetMetaData(this, "invoicedetailview");
            MetaInvDet.DescribeColumns(DS.invoicedetail_taxable_nc, "listaimpon");
            MetaInvDet.DescribeColumns(DS.invoicedetail_iva_nc, "listaimpos");

        }

        void getRowsFromParent() {
            DataSet parentDs = Meta.SourceRow.Table.DataSet;
            //Rimuove dal parent le righe di questo ds e poi le rimette
            var ev = DS.expensevar.Rows[0];
            object idexp = ev["idexp"];

            bool thereIsInv = ev["idinvkind", DataRowVersion.Current] != DBNull.Value;
            if (thereIsInv) {
                q newInvoiceFilter = q.eq("idinvkind", ev["idinvkind"]) &
                                     q.eq("yinv", ev["yinv"]) &
                                     q.eq("ninv", ev["ninv"]);
                foreach (string tName in new[] {"invoicedetail_taxable_nc", "invoicedetail_iva_nc"}) {
                    if (!parentDs.Tables.Contains(tName)) continue;
                    DataTable parentTable = parentDs.Tables[tName];

                    foreach (DataRow rExistent in parentTable._Filter(newInvoiceFilter)) {
                        var checkFilter = q.eq("idinvkind", rExistent["idinvkind"]) &
                                          q.eq("yinv", rExistent["yinv"]) &
                                          q.eq("ninv", rExistent["ninv"]) &
                                          q.eq("rownum", rExistent["rownum"]);
                        var readRows = DS.Tables[tName]._get(Conn, checkFilter);
                        if (readRows._HasRows()) {
                            var found = readRows[0];
                            found["idexp_iva"] = rExistent["idexp_iva"];
                            found["idexp_taxable"] = rExistent["idexp_taxable"];
                        }

                    }

                }

            }
           

        }

        public void MetaData_AfterFill() {
            EnableDisableCheckAnnullo();
            FillAnnullo();


            if (!Meta.InsertMode) {
                grpMovimento.Enabled = false;
            }
            if (!Meta.IsEmpty) {
                impostaFiltroPerDocIVA(ParentSpesa);
            }

            EnableDisableCheckAnnullo();
            FillAnnullo();
            
            EnableDisableCheckDocIVA(currPhase);
            //EnableDisableUnderWrinting(currPhase);
            if (chkDocIVA.Enabled) {
                DisabilitaDocIVA(!chkDocIVA.Checked);

                if ((IvaLinkedMustBeEvalued == false) && (IvaLinked != null) &&
                    (IvaLinked.RowState == DataRowState.Detached)) {
                    if (DS.invoice.Rows.Count > 0) {
                        IvaLinked = DS.invoice.Rows[0];
                    }
                    else
                        ResetIva();
                }

                bool IvaWasToLink = IvaLinkedMustBeEvalued;
                RintracciaIva();
                if (IvaWasToLink) {
                    if (IvaLinked != null) {
                        VisualizzaMainInfo_Iva(IvaLinked);
                    }
                }
            }
            else {
                DisabilitaDocIVA(true);
            }

            if (Meta.EditMode||Meta.InsertMode) {
                bool abilita = ((DS.expensevar.Rows.Count > 0) && (DS.expensevar.Rows[0]["idinvkind"] != DBNull.Value));
                AbilitaDisabilitaControlliFattura(abilita);
            }


            if (Meta.FirstFillForThisRow && !Meta.IsEmpty) {
                CalcTotInvoiceDetail();
            }
            txtEsercVariazione.Enabled = false;


        }

        void VisualizzaMainInfo_Iva(DataRow Iva2) {

            if (!faseMaxInclusa()) return;
            grpInvoiceDetail.Visible = true;

            S1ubEntity_txtNumero.Text = Iva2["ninv"].ToString();
            S1ubEntity_txtEsercizio.Text = Iva2["yinv"].ToString();

            TipoDocChangePilotato = true;
            HelpForm.SetComboBoxValue(S1ubEntity_cmbTipoDoc, Iva2["idinvkind"]);
            TipoDocChangePilotato = false;
        }

        private void EnableDisableCheckDocIVA(int currphase) {
            int maxPhase = CfgFn.GetNoNullInt32(Meta.GetSys("maxexpensephase"));
            bool abilita = (Meta.InsertMode || Meta.IsEmpty) && (currphase == maxPhase);
            chkDocIVA.Enabled = abilita;
        }

        public void MetaData_AfterClear() {
            chkDocIVA.Enabled = true;
            chkDocIVA.Checked = false;
            DisabilitaDocIVA(true);
            SetComboCausale();
            m_CodiceCredDebD = null;
            m_CodiceCredDebS = null;
            ChangingFase = false;
            ResetIva();
            grpInvoiceDetail.Visible = false;
            impostaFiltroPerDocIVA(null);
            grpUnderWrinting.Visible = true;
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


        void EnableDisableCheckAnnullo() {
            if (Meta.IsEmpty) {
                radNormale.Enabled = false;
                radAnnPar.Enabled = false;
                radEdit.Enabled = false;
                return;
            }
			/* switch (currauto)
		 {
			 case 0: // normale

			 case 10: //ANPAR

			 case 11: //ANN

			 case 22: //EDIT

			 case 32: //AZZERACSA

		 }*/
			DataRow R = DS.expensevar.Rows[0];
            int currauto = CfgFn.GetNoNullInt32(R["autokind"]);
            if ((currauto == 0) || (currauto == 10) || (currauto == 22)|| (currauto == 32)) {
                //ANPAR
                radNormale.Enabled = true;
                radAnnPar.Enabled = true;
                radEdit.Enabled = maxphase;
				radCsa.Enabled = maxphase;
			}
            else {
                radNormale.Enabled = false;
                radAnnPar.Enabled = false;
                radEdit.Enabled = false;
				radCsa.Enabled = false;
			}
        }

        void FillAnnullo() {
            if (Meta.IsEmpty) {
                return;
            }
            DataRow R = DS.expensevar.Rows[0];
            int currauto = CfgFn.GetNoNullInt32(R["autokind"]);
            if (currauto == 11) //ANNULL
                radAnnullo.Checked = true;
            else
                radAnnullo.Checked = false;
            if (currauto == 10) //ANPAR
                radAnnPar.Checked = true;
            else
                radAnnPar.Checked = false;
            if (currauto == 22) //EDIT
                radEdit.Checked = true;
            else
                radEdit.Checked = false;
			if (currauto == 32)  //AZZERACSA
				radCsa.Checked = true;
			else
				radCsa.Checked = false;
			if (currauto == 0)
                radNormale.Checked = true;
            else
                radNormale.Checked = false;
        }

        void GetAnnullo() {
            if (Meta.IsEmpty) return;
            if (radAnnPar.Enabled == false) return;
            if (radNormale.Enabled == false) return;
            if (radEdit.Enabled == false) return;
            DataRow R = DS.expensevar.Rows[0];
            int currauto = CfgFn.GetNoNullInt32(R["autokind"]);
            if (radNormale.Checked) {
                if (currauto != 0) R["autokind"] = 0;
            }
            if (radAnnPar.Checked) {
                if (currauto != 10) R["autokind"] = 10; //ANPAR
            }
            if (radEdit.Checked) {
                if (currauto != 22) R["autokind"] = 22; //EDIT
            }
			if (radCsa.Checked) {
				if (currauto != 32) R["autokind"] = 32;  //AZZERACSA
			}
		}

        private void resetIvaRef() {
            if (DS.expensevar.Rows.Count == 0) return;
            DataRow Curr = DS.expensevar.Rows[0];
            Curr["idinvkind"] = DBNull.Value;
            Curr["yinv"] = DBNull.Value;
            Curr["ninv"] = DBNull.Value;
            Curr["movkind"] = DBNull.Value;
        }


        private void SetCredDebFilter(DataRow R, string FlagRichiedente) {
            if (FlagRichiedente.ToUpper() == "D") {
                m_CodiceCredDebD = (R == null ? null : R["idreg"]);
            }
            if (FlagRichiedente.ToUpper() == "S") {
                m_CodiceCredDebS = (R == null ? null : R["idreg"]);
            }
        }

        public void MetaData_AfterRowSelect(DataTable T, DataRow R) {
            if (T.TableName == "expenseview") {
                //if (!Meta.DrawStateIsDone) return;
                if (Meta.InsertMode) {
                    impostaFiltroPerDocIVA(R);
                    SetCredDebFilter(R, "S");
                }
            }

            if (T.TableName == "tipomovimento") {
                if (!Meta.DrawStateIsDone) return;
                if (Meta.InsertMode) {
                    if (DS.expensevar.Rows.Count == 0) return;
                    DS.expensevar.Rows[0]["movkind"] = (S1ubEntity_cmbCausale.SelectedValue != null)
                        ? S1ubEntity_cmbCausale.SelectedValue
                        : DBNull.Value;
                    GetCausaleIva();
                    SvuotaDettagliFattura();
                    CollegaTuttiDettagliFattura();
                    ReCalcImporto_Iva();
                    bool abilita = (R != null);
                    AbilitaDisabilitaControlliFattura(abilita);
                }
            }

            if (T.TableName == "invoiceavailable" &&  Meta.InsertMode) {
                if (!Meta.DrawStateIsDone) return;
                if (R == null) {
                    DS.expensevar.Rows[0]["description"] = "";
                    DS.expensevar.Rows[0]["doc"] = DBNull.Value;
                    DS.expensevar.Rows[0]["docdate"] = DBNull.Value;
                    grpInvoiceDetail.Visible = false;
                    AbilitaDisabilitaControlliFattura(false);
                }
                else {
                    DS.expensevar.Rows[0]["description"] = R["description"];
                    DS.expensevar.Rows[0]["doc"] = R["doc"];
                    DS.expensevar.Rows[0]["docdate"] = R["docdate"];
                    grpInvoiceDetail.Visible = true;
                }
                SetCredDebFilter(R, "D");
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

            if (T.TableName == "invoicedetail_iva_nc" && R!=null) {
                R["idexp_iva"] = DS.expensevar.Rows[0]["idexp"];
            }
            if (T.TableName == "invoicedetail_taxable_nc" && R!=null) {
                R["idexp_taxable"] = DS.expensevar.Rows[0]["idexp"];
                if (GetCausaleIva() == 3) {
                    R["idexp_iva"] = DS.expensevar.Rows[0]["idexp"];
                }
            }


        }

        public void MetaData_AfterGetFormData() {
            GetAnnullo();
        }

        private void rimuoviDettagliFatturaEsterni() {
            foreach (DataRow rDet in DS.invoicedetail_iva_nc.Select()) {
                if (rDet.RowState != DataRowState.Unchanged) continue;
                string filtro =
                    QHC.AppAnd(QHC.CmpEq("idinvkind", rDet["idinvkind"]),
                        QHC.CmpEq("yinv", rDet["yinv"]),
                        QHC.CmpEq("ninv", rDet["ninv"]),
                        QHC.CmpEq("idexp", rDet["idexp_iva"]));
                if (DS.expensevar.Select(filtro).Length == 0) {
                    rDet.Delete();
                    rDet.AcceptChanges();
                }
            }

            foreach (DataRow rDet in DS.invoicedetail_taxable_nc.Select()) {
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

        public void MetaData_BeforeFill() {
            if (DS.expensevar.Rows[0]["idinvkind"] != DBNull.Value) chkDocIVA.Checked = true;
            if (!Meta.IsEmpty) {
                rimuoviDettagliFatturaEsterni();
            }

        }

        void MakeSpaceFrom(GroupBox G) {
            Form F = G.FindForm();
            int disp = G.Size.Height;
            int y0 = G.Location.Y;
            F.SuspendLayout();
            foreach (Control C in F.Controls) {
                if (C.Location.Y < y0) continue;
                if ((C.Anchor & AnchorStyles.Bottom) == 0)
                    C.Location = new Point(C.Location.X, C.Location.Y - disp);
                else {
                    if ((C.Anchor & AnchorStyles.Top) != 0) {
                        C.Size = new Size(C.Size.Width, C.Size.Height + disp);
                        C.Location = new Point(C.Location.X, C.Location.Y - disp);
                    }
                }
            }
            F.Size = new Size(F.Size.Width, F.Size.Height - disp);
            F.ResumeLayout();
            grpTrasferimento.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left);
            btnCancel.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left);
            btnOk.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left);
        }


        private void EnableDisableUnderWrinting(int currphase) {
            int finPhase = CfgFn.GetNoNullInt32(Meta.GetSys("expensefinphase"));
            int maxPhase = CfgFn.GetNoNullInt32(Meta.GetSys("maxexpensephase"));
            bool abilita = ((Meta.InsertMode) || (Meta.EditMode))
                           && ((currphase == maxPhase) || (currphase == finPhase));

            if (FinanziamentiDisponibili == null || FinanziamentiDisponibili.Select().Length == 0) abilita = false;
            grpUnderWrinting.Visible = abilita;

            if (!abilita) {
                MakeSpaceFrom(grpUnderWrinting);
            }
            else {
                grpTrasferimento.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left);
                btnCancel.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left);
                btnOk.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left);
            }
        }

        void SelezionaFinanziamento() {
            if (Meta.IsEmpty) return; //superfluo in expensevar_detail
            if (FinanziamentiDisponibili == null) return;
            if (FinanziamentiDisponibili.Select().Length == 0) return;

            QueryHelper QHS = Meta.Conn.GetQueryHelper();
            string filteridunderwriting = QHS.FieldIn("idunderwriting", FinanziamentiDisponibili.Select());

            MetaData MetaUnd = MetaData.GetMetaData(this, "underwriting");
            MetaUnd.DS = new DataSet();
            MetaUnd.LinkedForm = this;
            MetaUnd.FilterLocked = true;
            DataRow Und = MetaUnd.SelectOne("default", filteridunderwriting, "underwritingview", null);
            if (Und == null) return;
            object idunderwriting = Und["idunderwriting"];
            DS.underwriting.Clear();
            Meta.Conn.RUN_SELECT_INTO_TABLE(DS.underwriting, null, QHS.CmpEq("idunderwriting", idunderwriting), null,
                false);
            txtUnderwriting.Text = Und["title"].ToString();
            DS.expensevar.Rows[0]["idunderwriting"] = idunderwriting;
        }

        private void btnUnderwriting_Click(object sender, EventArgs e) {
            SelezionaFinanziamento();
        }

        private void chkDocIVA_CheckedChanged(object sender, EventArgs e) {
            if (!Meta.DrawStateIsDone) return;

            ChangingFase = true;
            m_DocIVA = chkDocIVA.Checked;
            //SetListingType(!m_DocIVA);
            DisabilitaDocIVA(!m_DocIVA);
            m_CodiceCredDebD = null;

            if (Meta.InsertMode) {
                if (chkDocIVA.Checked) {
                    grpMovimento.Enabled = false;
                }
                else {
                    grpMovimento.Enabled = true;
                    DS.invoicedetail_iva_nc.Clear();
                    DS.invoicedetail_taxable_nc.Clear();
                    ScollegaIva(true);
                    ResetIva();
                }
            }
        }

        private void btnDocumento_Click(object sender, EventArgs e) {
            DataRow MyDR = DoChooseCommandDocumento(null);
            if (Meta.InsertMode) {
                ResetIva();
                DataRow MyDRIva = ottieniRigaInInvoiceResidual(MyDR);
                CollegaIva(MyDR, MyDRIva);
                CollegaTuttiDettagliFattura();
                RintracciaIva();
            }
            AbilitaDisabilitaControlliFattura(true);
        }

        private DataRow DoChooseCommandDocumento(Control sender) {
            string mycommand = docoper_command;
            //string filter=Meta.myHelpForm.GetSpecificCondition(grpDocumento.Controls, "invoiceavailable");
            string filter = ""; //Meta.myHelpForm.GetSpecificCondition(grpDocumento.Controls, "invoiceavailable");
            if (S1ubEntity_txtEsercizio.Text.Trim() != "") {
                int esercizio = CfgFn.GetNoNullInt32(
                    HelpForm.GetObjectFromString(typeof(int), S1ubEntity_txtEsercizio.Text, "x.y.year"));
                filter = QHS.CmpEq("yinv", esercizio);
            }
            if (S1ubEntity_cmbTipoDoc.SelectedIndex > 0) {
                object code = S1ubEntity_cmbTipoDoc.SelectedValue;
                filter = QHS.AppAnd(filter, QHS.CmpEq("idinvkind", code));
            }
            if (sender == S1ubEntity_txtNumero) {
                int num = CfgFn.GetNoNullInt32(
                    HelpForm.GetObjectFromString(typeof(int), S1ubEntity_txtNumero.Text, "x.y"));
                filter = QHS.AppAnd(filter, QHS.CmpEq("ninv", num));
            }
            DataRow pExpense = ParentSpesa.Table.DataSet.Tables["expense"].Rows[0];
            object idreg = pExpense["idreg"];
            if (idreg != DBNull.Value) {
                filter = QHS.AppAnd(filter, QHC.CmpEq("idreg",idreg));
            }
            if (Meta.InsertMode) {
                filter = QHS.AppAnd(filter, QHS.CmpGt("residual", 0), QHS.NullOrEq("active", 'S'));
            }
            if (filter != "") mycommand += "." + filter;
            string fStatico = QHS.AppAnd(QHS.BitClear("flag", 0), QHS.BitSet("flag", 2));
            filter = QHS.AppAnd(filter, fStatico);
            MetaData MDocumentoIva = MetaData.GetMetaData(this, "invoiceavailable");
            MDocumentoIva.FilterLocked = true;
            DataRow rInv = MDocumentoIva.SelectOne("default", filter, null, null);
            if (rInv == null) return null;
            string f2 = QHS.AppAnd(QHS.CmpEq("idinvkind", rInv["idinvkind"]), QHS.CmpEq("yinv", rInv["yinv"]),
                QHS.CmpEq("ninv", rInv["ninv"]));

            DataTable tInvoiceView = DataAccess.RUN_SELECT(Meta.Conn, "invoiceview", "*", null, f2, null, null, true);
            if ((tInvoiceView == null) || (tInvoiceView.Rows.Count == 0)) return null;
            return tInvoiceView.Rows[0];
        }

        private void DisabilitaDocIVA(bool disable) {
            S1ubEntity_cmbTipoDoc.Enabled = !disable;
            btnDocumento.Enabled = !disable;
            S1ubEntity_txtEsercizio.ReadOnly = disable;
            S1ubEntity_txtNumero.ReadOnly = disable;
            S1ubEntity_cmbCausale.Enabled = !disable;
            
            if (chkDocIVA.Enabled) {
                if (!chkDocIVA.Checked) {
                    HelpForm.SetComboBoxValue(S1ubEntity_cmbCausale, 0);
                }
            }
        }

        private string GetCredDebFilter(string FlagRichiedente) {
            object cred = null;
            if (FlagRichiedente == "D")
                cred = m_CodiceCredDebS;
            else
                cred = m_CodiceCredDebD;
            if (cred == null || cred.ToString() == "") return "";
            return QHS.CmpEq("idreg", cred);
        }



        /// <summary>
        /// utilizzato semplicemente in ricerca
        /// </summary>
        private void SetComboCausale() {
            ClearComboCausale();
            EnableTipoMovimento(0, "");
            EnableTipoMovimento(1, "Contabilizzazione importo totale documento");
            EnableTipoMovimento(3, "Contabilizzazione imponibile documento");
            EnableTipoMovimento(2, "Contabilizzazione iva documento");
            HelpForm.SetComboBoxValue(S1ubEntity_cmbCausale, 0);
        }

        void ResetIva() {
            IvaLinkedMustBeEvalued = true;
            IvaLinked = null;
        }

        /// <summary>
        /// Svuota la tabella DS.tipomovimento, a cui è agganciato il combo causale
        /// </summary>
        void ClearComboCausale() {
            DataTable TCombo = DS.tipomovimento;
            TCombo.Clear();
        }


        private void EnableTipoMovimento(int IDtipo, string descrtipo) {
            DataRow R = DS.tipomovimento.NewRow();
            R["idtipo"] = IDtipo;
            R["descrizione"] = descrtipo;
            DS.tipomovimento.Rows.Add(R);
            DS.tipomovimento.AcceptChanges();
            if (DS.tipomovimento.Rows.Count == 1) {
                HelpForm.SetComboBoxValue(S1ubEntity_cmbCausale, IDtipo);
            }
        }

        private DataRow ottieniRigaInInvoiceResidual(DataRow R) {
            if (R == null) return null;
            string filtro =
                QHS.AppAnd(QHS.CmpEq("idinvkind", R["idinvkind"]), QHS.CmpEq("yinv", R["yinv"]),
                    QHS.CmpEq("ninv", R["ninv"]));
            DataTable tResiduo =
                DataAccess.RUN_SELECT(Meta.Conn, "invoiceresidual", "*", null, filtro, null, null, true);
            return (tResiduo != null && tResiduo.Rows.Count > 0) ? tResiduo.Rows[0] : null;
        }

        void ScollegaIva() {
            ScollegaIva(false);
        }

        void ScollegaIva(bool skiptipodoc) {
            grpInvoiceDetail.Visible = false;
            ResetIva();
            DS.invoicedetail_iva_nc.Clear();
            DS.invoicedetail_taxable_nc.Clear();
            DS.invoice.Clear();
            ClearComboCausale();
            DataRow CurrRow = DS.expensevar.Rows[0];

            CurrRow["doc"] = DBNull.Value;
            CurrRow["docdate"] = DBNull.Value;
            CurrRow["description"] = "";
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
        void CollegaIva(DataRow Iva2, DataRow IvaResiduo) {
            grpInvoiceDetail.Visible = true;
            if (Meta.EditMode) {
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
                    ValoriDocumentoIva[C.ColumnName] = Iva2[C.ColumnName];
                }
            }

            ScollegaIva();

            if (!faseMaxInclusa()) return;

            DataRow NewIvaR = DS.invoice.NewRow();

            foreach (DataColumn C in DS.invoice.Columns) {
                NewIvaR[C.ColumnName] = ValoriDocumentoIva[C.ColumnName];
            }

            DS.invoice.Rows.Add(NewIvaR);
            NewIvaR.AcceptChanges();

            DataRow CurrRow = DS.expensevar.Rows[0];

            CurrRow["ninv"] = ValoriDocumentoIva["ninv"];
            S1ubEntity_txtNumero.Text = ValoriDocumentoIva["ninv"].ToString();
            CurrRow["yinv"] = ValoriDocumentoIva["yinv"];
            S1ubEntity_txtEsercizio.Text = ValoriDocumentoIva["yinv"].ToString();

            TipoDocChangePilotato = true;
            CurrRow["idinvkind"] = ValoriDocumentoIva["idinvkind"];
            HelpForm.SetComboBoxValue(S1ubEntity_cmbTipoDoc, ValoriDocumentoIva["idinvkind"]);
            TipoDocChangePilotato = false;

            CurrRow["description"] = ValoriDocumentoIva["description"];
            txtDescrizione.Text = ValoriDocumentoIva["description"].ToString();

            CurrRow["doc"] = "Doc." + ValoriDocumentoIva["doc"];
            txtDocumento.Text = "Doc." + ValoriDocumentoIva["doc"];
            CurrRow["docdate"] = ValoriDocumentoIva["docdate"];
            txtDataDocumento.Text =
                HelpForm.StringValue(ValoriDocumentoIva["docdate"], txtDataDocumento.Tag.ToString());

            IvaLinkedMustBeEvalued = true;
            RintracciaIva();
            SetComboCausale(IvaResiduo);
        }

        /// <summary>
        /// Riempie il combobox causale con i valori ammessi, senza impostarvi alcun valore
        /// </summary>
        /// <param name="R">riga di invoiceavailable</param>
        private void SetComboCausale(DataRow R) {
            if (R == null) {
                SetComboCausale();
                return;
            }
            totimponibile_dociva = CfgFn.GetNoNullDecimal(R["taxabletotal"]);
            totiva_dociva = CfgFn.GetNoNullDecimal(R["ivatotal"]);

            assigned_imponibile_dociva = CfgFn.GetNoNullDecimal(R["linkedimpon"]);
            assigned_iva_dociva = CfgFn.GetNoNullDecimal(R["linkedimpos"]);
            assigned_gen_dociva = CfgFn.GetNoNullDecimal(R["linkeddocum"]);

            string filteriva = QHS.AppAnd(QHS.CmpEq("idinvkind", R["idinvkind"]),
                QHS.CmpEq("yinv", R["yinv"]), QHS.CmpEq("ninv", R["ninv"]));

            string filter_idupbivaset = QHS.AppAnd(filteriva, QHS.IsNotNull("idupb_iva"));
            int n_idupbivaset = Conn.RUN_SELECT_COUNT("invoicedetail", filter_idupbivaset, false);

            bool EnableImpon = true;
            bool EnableImpos = true;
            bool EnableDocum = true;

            ClearComboCausale();
            DataTable TCombo = DS.tipomovimento;
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
                (EnableDocum && (assigned_imponibile_dociva + assigned_iva_dociva) == 0) &&
                (assigned_gen_dociva < (totimponibile_dociva + totiva_dociva))) {
                EnableTipoMovimento(1, "Contabilizzazione importo totale documento");
            }

            if ((Meta.EditMode) ||
                (EnableImpon && (assigned_gen_dociva == 0)
                 && (assigned_imponibile_dociva < totimponibile_dociva))
            ) {
                EnableTipoMovimento(3, "Contabilizzazione imponibile documento");
            }

            if ((Meta.EditMode) ||
                (EnableImpos && (assigned_gen_dociva == 0)
                 && (assigned_iva_dociva < totiva_dociva))
            ) {
                EnableTipoMovimento(2, "Contabilizzazione iva documento");
            }
            if (DS.expensevar.Rows.Count != 0) {
                DS.expensevar.Rows[0]["movkind"] = (S1ubEntity_cmbCausale.SelectedValue != null)
                    ? S1ubEntity_cmbCausale.SelectedValue
                    : DBNull.Value;
            }
            S1ubEntity_cmbCausale.Enabled = !(Meta.EditMode);
            ReCalcImporto_Iva();
        }

        void RintracciaIva() {
            if (!IvaLinkedMustBeEvalued) return;
            GetDocIva(out IvaLinked,
                out CurrCausaleIva);
            IvaLinkedMustBeEvalued = false;
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
        ) {
            if (Meta.IsEmpty) return null;
            if (DS.expensevar.Rows.Count == 0) return null;         

            if (currPhase == faseattivazione) {
                //Se la fase attivazione è inclusa nel range, è possibile che 
                // il documento sia stato selezionato e sia in memoria, oppure che non 
                // sia stato selezionato il documento e quindi non ci sono righe
                if (DS.Tables[tablename].Rows.Count == 0) return null;
                return DS.Tables[tablename].Rows[0];
            }
            return null;
        }

        void GetDocIva(out DataRow IvaRow,
            out int CurrCausaleIva) {
            CurrCausaleIva = 0;
            IvaRow = null;
            if (DS.expensevar.Rows.Count == 0) return;
            DataRow MiddleRow = DS.expensevar.Rows[0];
            int faseiva = Convert.ToInt32(fasespesamax);
            IvaRow = GetDocRow("invoice", "expensevar", faseiva);
            if (IvaRow == null) return;
            if (MiddleRow != null) CurrCausaleIva = CfgFn.GetNoNullInt32(MiddleRow["movkind"]);
        }

        private bool thereWasInv = false;
        public void MetaData_BeforePost() {
            if (DS.expensevar.Rows.Count==0)return;

            DataSet parentDs = Meta.SourceRow.Table.DataSet;
            //Rimuove dal parent le righe di questo ds e poi le rimette
            var ev = DS.expensevar.Rows[0];
            object idexp = ev["idexp"];

            
            if (thereWasInv) {
                //rimuove tutto quello che c'era nel ds parent e che ora non c'è più
               
                foreach (string tName in new[] {"invoicedetail_taxable_nc", "invoicedetail_iva_nc"}) {
                    if (!parentDs.Tables.Contains(tName)) continue;
                    DataTable parentTable = parentDs.Tables[tName];
                    foreach (DataRow rOld in parentTable._Filter(oldInvoiceFilter)) {
                        var checkFilter = q.eq("idinvkind", rOld["idinvkind"]) &
                                           q.eq("yinv", rOld["yinv"]) &
                                           q.eq("ninv", rOld["ninv"]) &
                                          q.eq("rownum", rOld["rownum"]) ;
                        var newRows = DS.Tables[tName]._Filter(checkFilter);
                        if (newRows._IsEmpty()) {
                            //annulla l'idexp delle righe del ds di origine
                            if (rOld["idexp_taxable"].Equals(idexp)) rOld["idexp_taxable"] = DBNull.Value;
                            if (rOld["idexp_iva"].Equals(idexp)) rOld["idexp_iva"] = DBNull.Value;
                            if (PostData.CheckForFalseUpdate(rOld)) {
                                rOld.RejectChanges();
                                if (!((rOld["idexp_iva"].Equals(idexp)) || (rOld["idexp_taxable"].Equals(idexp)))) {
                                    parentTable.Rows.Remove(rOld);
                                }
                            }
                        }
                    }
                }
            }

            bool thereIsInv = ev["idinvkind", DataRowVersion.Current] != DBNull.Value;
            if (thereIsInv) {
                q newInvoiceFilter = q.eq("idinvkind", ev["idinvkind"]) &
                                     q.eq("yinv", ev["yinv"]) &
                                     q.eq("ninv", ev["ninv"]);
                foreach (string tName in new[] {"invoicedetail_taxable_nc", "invoicedetail_iva_nc"}) {
                    if (!parentDs.Tables.Contains(tName)) continue;
                    DataTable parentTable = parentDs.Tables[tName];

                    foreach (DataRow rOld in DS.Tables[tName]._Filter(newInvoiceFilter)) {
                        //Copia nel ds parent quello che già non c'è
                        var checkFilter = q.eq("idinvkind", rOld["idinvkind"]) &
                                          q.eq("yinv", rOld["yinv"]) &
                                          q.eq("ninv", rOld["ninv"]) &
                                          q.eq("rownum", rOld["rownum"]);
                        var exRows = parentTable._Filter(checkFilter);
                        if (exRows._IsEmpty()) {
                            var rows = parentTable._getFromDb(Conn, checkFilter);
                            foreach (DataRow r in rows) {
                                r["idexp_taxable"] = rOld["idexp_taxable"];
                                r["idexp_iva"] = rOld["idexp_iva"];
                            }
                        }

                    }

                }

               
            }


        }


        void CollegaTuttiDettagliFattura() {
            CurrCausaleIva = GetCausaleIva();
            string filter = CalculateFilterForInvoiceDetailLinking(true);
            DS.invoicedetail_iva_nc.Clear();
            DS.invoicedetail_taxable_nc.Clear();
            object idexp = DS.expensevar.Rows[0]["idexp"];
            // JTR 29.11.2006 - Se l'idexp è vuoto non fare nulla (questo accade quando non ho ancora scelto un movimento di spesa al 
            // quale associare la variazione)
            if (idexp == DBNull.Value) return;
            if (CurrCausaleIva == 0) return;
            if (CurrCausaleIva == 1) {
                Meta.Conn.RUN_SELECT_INTO_TABLE(DS.invoicedetail_taxable_nc, null, filter, null, true);
                foreach (DataRow R in DS.invoicedetail_taxable_nc.Rows) {
                    R["idexp_taxable"] = idexp;
                    R["idexp_iva"] = idexp;
                }
                GetData.CalculateTable(DS.invoicedetail_taxable_nc);
                Meta.MarkTableAsNotEntityChild(DS.invoicedetail_taxable_nc);
            }
            if (CurrCausaleIva == 3) {
                Meta.Conn.RUN_SELECT_INTO_TABLE(DS.invoicedetail_taxable_nc, null, filter, null, true);
                foreach (DataRow R in DS.invoicedetail_taxable_nc.Rows) {
                    R["idexp_taxable"] = idexp;
                }
                GetData.CalculateTable(DS.invoicedetail_taxable_nc);
                Meta.MarkTableAsNotEntityChild(DS.invoicedetail_taxable_nc);
            }
            if (CurrCausaleIva == 2) {
                Meta.Conn.RUN_SELECT_INTO_TABLE(DS.invoicedetail_iva_nc, null, filter, null, true);
                foreach (DataRow R in DS.invoicedetail_iva_nc.Rows) {
                    R["idexp_iva"] = idexp;
                }
                GetData.CalculateTable(DS.invoicedetail_iva_nc);
                Meta.MarkTableAsNotEntityChild(DS.invoicedetail_iva_nc);
            }
            //ComunicaInfoARighePadre(filter, CurrCausaleIva);
            CalcolaImportoInBaseADettagliFattura();
            if ((DS.invoicedetail_iva_nc.Rows.Count == 0) && (DS.invoicedetail_taxable_nc.Rows.Count == 0)) {
                MessageBox.Show("Non sono stati trovati dettagli coerenti con UPB e Causale selezionati.");
                return;
            }

        }

        //void ComunicaInfoARighePadre(string filter, int CurrCausaleIva) {
        //    DataRow rExpensevar = Meta.SourceRow;
        //    rExpensevar.Table.ExtendedProperties["filter_nc"] = filter;
        //    rExpensevar.Table.ExtendedProperties["CausaleContabilizzazione"] = CurrCausaleIva;
        //}
        void SvuotaDettagliFattura() {
            if (Meta.EditMode) return;
            DS.invoicedetail_taxable_nc.Clear();
            DS.invoicedetail_iva_nc.Clear();
            CalcTotInvoiceDetail();
        }

        void CalcolaImportoInBaseADettagliFattura() {
            if (Meta.IsEmpty) return;
            CurrCausaleIva = GetCausaleIva();
            decimal totale = GetImportoDettagliFattura();
            SetImporto(-totale);
            CalcTotInvoiceDetail();
        }

        void CalcTotInvoiceDetail() {
            txtTotInvoiceDetail.Text = "";
            if (Meta.IsEmpty) return;
            decimal totale = GetImportoDettagliFattura();
            txtTotInvoiceDetail.Text = totale.ToString("c");
        }

        decimal GetImportoDettagliFattura() {
            if (DS.invoice.Rows.Count == 0)
                return 0;
            decimal tassocambio;
            DataRow Fattura = DS.invoice.Rows[0];
            tassocambio = CfgFn.GetNoNullDecimal(Fattura["exchangerate"]);
            if (tassocambio == 0) tassocambio = 1;
            decimal imponibile = 0;
            decimal imposta = 0;
            DataRow[] ToConsider = new DataRow[0];
            CurrCausaleIva = GetCausaleIva();
            if (CurrCausaleIva == 3) {
                ToConsider = DS.invoicedetail_taxable_nc.Select(QHC.IsNotNull("idexp_taxable"));
            }
            if (CurrCausaleIva == 2) {
                ToConsider = DS.invoicedetail_iva_nc.Select(QHC.IsNotNull("idexp_iva"));
            }
            if (CurrCausaleIva == 1) {
                ToConsider = DS.invoicedetail_taxable_nc.Select(QHC.IsNotNull("idexp_taxable"));
            }

            foreach (DataRow R in ToConsider) {
                if (R.RowState == DataRowState.Deleted) continue;
                decimal R_imponibile = CfgFn.GetNoNullDecimal(R["taxable"]);
                decimal R_quantita = CfgFn.GetNoNullDecimal(R["number"]);
                decimal R_imposta = CfgFn.GetNoNullDecimal(R["tax"]);
                decimal R_sconto = CfgFn.Round(CfgFn.GetNoNullDecimal(R["discount"]), 6);
                imponibile += CfgFn.RoundValuta((R_imponibile * R_quantita * (1 - R_sconto)) * tassocambio);
                imposta += CfgFn.RoundValuta(R_imposta * tassocambio);
            }

            decimal totale = 0;

            if (CurrCausaleIva == 3) {
                totale = imponibile;
            }
            if (CurrCausaleIva == 2) {
                totale = imposta;
            }
            if (CurrCausaleIva == 1) {
                totale = imponibile + imposta;
            }

            return totale;

        }


        void AbilitaDisabilitaControlliFattura(bool abilita) {
            bool abilitagrid = abilita && faseMaxInclusa();
            btnAddDettInvoice.Enabled = abilitagrid;
            btnRemoveDettInvoice.Enabled = abilitagrid;
            btnEditInvDet.Enabled = abilitagrid;
            grpInvoiceDetail.Visible = abilitagrid;
            CurrCausaleIva = GetCausaleIva();
            if (CurrCausaleIva == 1 || CurrCausaleIva == 3) {
                dgrDettagliFattura.Tag = "invoicedetail_taxable_nc.listaimpon";
                dgrDettagliFattura.TableStyles.Clear();
                HelpForm.SetDataGrid(dgrDettagliFattura, DS.invoicedetail_taxable_nc);
                if (Meta.EditMode) DS.invoicedetail_iva_nc.Clear(); //Importante per evitare problemi in fase di delete
            }
            if (CurrCausaleIva == 2) {
                dgrDettagliFattura.TableStyles.Clear();
                dgrDettagliFattura.Tag = "invoicedetail_iva_nc.listaimpos";
                HelpForm.SetDataGrid(dgrDettagliFattura, DS.invoicedetail_iva_nc);
            }
        }

        bool faseMaxInclusa() {

            return (fasespesamax == currPhase);
        }

        int GetCausaleIva() {
            CurrCausaleIva = 0;
            if (DS.expensevar.Rows.Count == 0) return 0;
            DataRow Curr = DS.expensevar.Rows[0];
            if (!verificaDocIvaSelezionato()) return 0;

            if (!Meta.DrawStateIsDone) {
                CurrCausaleIva = (Curr["movkind"] == DBNull.Value) ? 0 : CfgFn.GetNoNullInt32(Curr["movkind"]);
                return CurrCausaleIva;
            }

            CurrCausaleIva = CfgFn.GetNoNullInt32(Curr["movkind"]);
            return CurrCausaleIva;
        }

        /// <summary>
        /// Metodo che verifica se la nota di credito è stata selezionata
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


        private void ReCalcImporto_Iva() {
            if (!Meta.DrawStateIsDone) return;
            if (Meta.IsEmpty) return;
            if (S1ubEntity_cmbCausale.SelectedValue == null) return;
            int tipomovimento = CfgFn.GetNoNullInt32(S1ubEntity_cmbCausale.SelectedValue);
            decimal Importo = 0;
            if (tipomovimento == 2) {
                Importo = totiva_dociva - assigned_iva_dociva;
            }
            if (tipomovimento == 3) {
                Importo = totimponibile_dociva - assigned_imponibile_dociva;
            }
            if (tipomovimento == 1) {
                Importo = totimponibile_dociva + totiva_dociva - assigned_gen_dociva;
            }

            SetImporto(-Importo);
        }


        private void SetImporto(decimal valore) {
            DS.expensevar.Rows[0]["amount"] = valore;
            valore = -valore;
            txtImporto.Text = valore.ToString("c");
            rdbAumento.Checked = false;
            rdbDiminuzione.Checked = true;
        }

        string CalculateFilterForInvoiceDetailLinking(bool SQL) {
            string MyFilter;
            object idupb = parentIdUPB;

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


            if (CurrCausaleIva == 1) {
                MyFilter = QH.AppAnd(MyFilter, QH.IsNull("idexp_iva"), QH.IsNull("idexp_taxable"));
            }
            if (CurrCausaleIva == 2) {
                MyFilter = QH.AppAnd(MyFilter, QH.IsNull("idexp_iva"));
            }
            if (CurrCausaleIva == 3) {
                MyFilter = QH.AppAnd(MyFilter, QH.IsNull("idexp_taxable"));
            }

            return MyFilter;
        }

        private void btnAddDettInvoice_Click(object sender, EventArgs e) {

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
                tablename="invoicedetail_taxable_nc";
            }
            if (CurrCausaleIva==2){
                tablename="invoicedetail_iva_nc";
            }

            string command = "choose."+tablename+".listaspesa." + MyFilter;
            if (!MetaData.Choose(this,command))return;
            if (CurrCausaleIva==1){
                foreach(DataRow R in DS.invoicedetail_taxable_nc.Rows){
                    R["idexp_iva"]=R["idexp_taxable"];
                };
            }
            CalcolaImportoInBaseADettagliFattura();
        }

        private void btnRemoveDettInvoice_Click(object sender, EventArgs e) {
            Meta.GetFormData(true);
            if (!verificaDocIvaSelezionato()) {
                MessageBox.Show(this, "Bisogna selezionare la nota di credito");
                return;
            }
            MetaData.Unlink_Grid(dgrDettagliFattura);
            if (CurrCausaleIva==1){
                foreach(DataRow R in DS.invoicedetail_taxable_nc.Rows){
                    R["idexp_iva"]=R["idexp_taxable"];
                };
            }
            CalcolaImportoInBaseADettagliFattura();
        }

        private void btnEditInvDet_Click(object sender, EventArgs e) {
            Meta.GetFormData(true);

            DataRow Curr = DS.expensevar.Rows[0];
            if (!verificaDocIvaSelezionato()) {
                MessageBox.Show(this, "Bisogna selezionare la nota di credito");
                return;
            }
            
            DataTable ToLink=null;
            if (CurrCausaleIva==1||CurrCausaleIva==3){
                ToLink=DS.invoicedetail_taxable_nc;
            }
            if (CurrCausaleIva==2){
                ToLink=DS.invoicedetail_iva_nc;
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
                foreach(DataRow R in DS.invoicedetail_taxable_nc.Rows){
                    R["idexp_iva"]=R["idexp_taxable"];
                };
            }

            CalcolaImportoInBaseADettagliFattura();		
        }
    }
}