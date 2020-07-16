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
using metaeasylibrary;
using metadatalibrary;
using funzioni_configurazione;

namespace incomevar_default
{
	/// <summary>
	/// Summary description for frmvariazioneentrata.
	/// Revised By Nino on 26/1/2003
	/// </summary>
	public class Frm_incomevar_default : System.Windows.Forms.Form
	{
		int CurrCausaleIva;
		DataRow IvaLinked;
		bool IvaLinkedMustBeEvalued;
		int faseentratamax;
		bool TipoDocChangePilotato=false;
        private bool maxphase = false;
		public vistaForm DS;
		private System.ComponentModel.IContainer components;
		MetaData Meta;
		private System.Windows.Forms.RadioButton radioButton1;
		string command;
		private decimal totimponibile_dociva;
		private decimal totiva_dociva;
		private decimal assigned_imponibile_dociva;
		private decimal assigned_iva_dociva;
		private decimal assigned_gen_dociva;
		private string docoper_command="choose.invoiceavailable.variazione";
		private string docoper_command_clear="choose.invoiceavailable.unknown.clear";
		private object m_CodiceCredDebD=null;
		private object m_CodiceCredDebE=null;
		private bool m_DocIVA=false;
		private string m_CodiceFaseCont="";
		private bool InChiusura;
		private bool ChangingFase=false;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.RadioButton radAnnPar;
		private System.Windows.Forms.RadioButton radAnnullo;
		private System.Windows.Forms.RadioButton radNormale;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.TextBox txtDocumento;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.TextBox txtDataDocumento;
		private System.Windows.Forms.CheckBox chkDocIVA;
		private System.Windows.Forms.GroupBox grpDocumento;
		private System.Windows.Forms.ComboBox S1ubEntity_cmbCausale;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.TextBox S1ubEntity_txtNumero;
		private System.Windows.Forms.TextBox S1ubEntity_txtEsercizio;
		private System.Windows.Forms.Button btnDocumento;
		private System.Windows.Forms.ComboBox S1ubEntity_cmbTipoDoc;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.GroupBox grpImporto;
		private System.Windows.Forms.RadioButton rdbAumento;
		private System.Windows.Forms.RadioButton rdbDiminuzione;
		private System.Windows.Forms.TextBox txtImporto;
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
		private System.Windows.Forms.TextBox txtNumEntrata;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox txtEsercEntrata;
		private System.Windows.Forms.Button btnAccertamento;
        private System.Windows.Forms.Label label10;
		private System.Windows.Forms.ImageList imageList1;
		private System.Windows.Forms.DataGrid DGridClassificazioni;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.GroupBox groupBox5;
		private System.Windows.Forms.Button btnInsertClass;
		private System.Windows.Forms.DataGrid DGridDettagliClassificazioni;
		private System.Windows.Forms.Button btnDelClass;
		private System.Windows.Forms.Button btnEditClass;
		private DataAccess Conn;
		private System.Windows.Forms.TabPage tabPage3;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.DataGrid dataGrid1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Button button4;
		private System.Windows.Forms.DataGrid dataGrid2;
		private System.Windows.Forms.Button button5;
		private System.Windows.Forms.Button button6;
		private System.Windows.Forms.GroupBox grpAssCrediti;
		private System.Windows.Forms.GroupBox grpAssIncassi;
		private System.Windows.Forms.TabPage tabDettagli;
		private System.Windows.Forms.GroupBox grpInvoiceDetail;
		private System.Windows.Forms.DataGrid dgrDettagliFattura;
		private System.Windows.Forms.Button btnEditInvDet;
		private System.Windows.Forms.TextBox txtTotInvoiceDetail;
		private System.Windows.Forms.Label label17;
		private System.Windows.Forms.Button btnRemoveDettInvoice;
		private System.Windows.Forms.Button btnAddDettInvoice;
		private decimal lastamount = 0;
        private RadioButton radEdit;
        private GroupBox groupBox6;
        private Label label14;
        private TextBox textBox2;
        private Label label15;
        private TextBox textBox3;
        private TextBox txtDataContabile;
        private Label label7;
        private GroupBox groupBox3;
        private RadioButton radioButton3;
        private RadioButton radioButton2;
        MetaData MetaIncSorted;

		public Frm_incomevar_default()
		{
			InitializeComponent();

			InChiusura=false;
			SetComboCausale();
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing ) {
			InChiusura=true;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_incomevar_default));
            this.DS = new incomevar_default.vistaForm();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.txtDataContabile = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.label14 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.radEdit = new System.Windows.Forms.RadioButton();
            this.radAnnPar = new System.Windows.Forms.RadioButton();
            this.radAnnullo = new System.Windows.Forms.RadioButton();
            this.radNormale = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtDocumento = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtDataDocumento = new System.Windows.Forms.TextBox();
            this.chkDocIVA = new System.Windows.Forms.CheckBox();
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
            this.grpImporto = new System.Windows.Forms.GroupBox();
            this.rdbAumento = new System.Windows.Forms.RadioButton();
            this.rdbDiminuzione = new System.Windows.Forms.RadioButton();
            this.txtImporto = new System.Windows.Forms.TextBox();
            this.txtDescrizione = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.grpVariazione = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNumVariazione = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtEsercVariazione = new System.Windows.Forms.TextBox();
            this.grpMovimento = new System.Windows.Forms.GroupBox();
            this.cmbFase = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNumEntrata = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtEsercEntrata = new System.Windows.Forms.TextBox();
            this.btnAccertamento = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
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
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.grpAssIncassi = new System.Windows.Forms.GroupBox();
            this.button4 = new System.Windows.Forms.Button();
            this.dataGrid2 = new System.Windows.Forms.DataGrid();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.grpAssCrediti = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.grpDocumento.SuspendLayout();
            this.grpImporto.SuspendLayout();
            this.grpVariazione.SuspendLayout();
            this.grpMovimento.SuspendLayout();
            this.tabDettagli.SuspendLayout();
            this.grpInvoiceDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrDettagliFattura)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGridDettagliClassificazioni)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGridClassificazioni)).BeginInit();
            this.tabPage3.SuspendLayout();
            this.grpAssIncassi.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid2)).BeginInit();
            this.grpAssCrediti.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            this.SuspendLayout();
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.EnforceConstraints = false;
            // 
            // radioButton1
            // 
            this.radioButton1.Location = new System.Drawing.Point(0, 0);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(104, 24);
            this.radioButton1.TabIndex = 0;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabDettagli);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.ImageList = this.imageList1;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(864, 452);
            this.tabControl1.TabIndex = 120;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox3);
            this.tabPage1.Controls.Add(this.txtDataContabile);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.groupBox6);
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.chkDocIVA);
            this.tabPage1.Controls.Add(this.grpDocumento);
            this.tabPage1.Controls.Add(this.grpImporto);
            this.tabPage1.Controls.Add(this.txtDescrizione);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.grpVariazione);
            this.tabPage1.Controls.Add(this.grpMovimento);
            this.tabPage1.Location = new System.Drawing.Point(4, 23);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(856, 425);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Principale";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.radioButton3);
            this.groupBox3.Controls.Add(this.radioButton2);
            this.groupBox3.Location = new System.Drawing.Point(8, 363);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(207, 49);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            this.groupBox3.Tag = "";
            this.groupBox3.Text = "Tipo trasferimento";
            // 
            // radioButton3
            // 
            this.radioButton3.Location = new System.Drawing.Point(119, 18);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(80, 16);
            this.radioButton3.TabIndex = 2;
            this.radioButton3.Tag = "incomevar.transferkind:A";
            this.radioButton3.Text = "Altro";
            // 
            // radioButton2
            // 
            this.radioButton2.Location = new System.Drawing.Point(15, 18);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(80, 16);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.Tag = "incomevar.transferkind:I";
            this.radioButton2.Text = "Interno";
            // 
            // txtDataContabile
            // 
            this.txtDataContabile.Location = new System.Drawing.Point(395, 330);
            this.txtDataContabile.Name = "txtDataContabile";
            this.txtDataContabile.Size = new System.Drawing.Size(96, 20);
            this.txtDataContabile.TabIndex = 9;
            this.txtDataContabile.Tag = "incomevar.adate?incomevarview.adate";
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(295, 330);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(88, 24);
            this.label7.TabIndex = 131;
            this.label7.Text = "Data contabile:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.label14);
            this.groupBox6.Controls.Add(this.textBox2);
            this.groupBox6.Controls.Add(this.label15);
            this.groupBox6.Controls.Add(this.textBox3);
            this.groupBox6.Location = new System.Drawing.Point(334, 363);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(486, 49);
            this.groupBox6.TabIndex = 11;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Distinta di trasmissione ";
            // 
            // label14
            // 
            this.label14.Location = new System.Drawing.Point(305, 20);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(72, 16);
            this.label14.TabIndex = 86;
            this.label14.Text = "Data trasm.:";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(383, 19);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(96, 20);
            this.textBox2.TabIndex = 12;
            this.textBox2.TabStop = false;
            this.textBox2.Tag = "proceedstransmission.transmissiondate";
            // 
            // label15
            // 
            this.label15.Location = new System.Drawing.Point(119, 16);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(72, 16);
            this.label15.TabIndex = 84;
            this.label15.Text = "Numero:";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(199, 16);
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(96, 20);
            this.textBox3.TabIndex = 11;
            this.textBox3.TabStop = false;
            this.textBox3.Tag = "proceedstransmission.nproceedstransmission";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.radEdit);
            this.groupBox2.Controls.Add(this.radAnnPar);
            this.groupBox2.Controls.Add(this.radAnnullo);
            this.groupBox2.Controls.Add(this.radNormale);
            this.groupBox2.Location = new System.Drawing.Point(8, 257);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(224, 97);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Tipo variazione";
            // 
            // radEdit
            // 
            this.radEdit.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.radEdit.Location = new System.Drawing.Point(16, 64);
            this.radEdit.Name = "radEdit";
            this.radEdit.Size = new System.Drawing.Size(206, 24);
            this.radEdit.TabIndex = 9;
            this.radEdit.Text = "Modifica Dati di Incassi Trasmessi";
            // 
            // radAnnPar
            // 
            this.radAnnPar.Location = new System.Drawing.Point(16, 48);
            this.radAnnPar.Name = "radAnnPar";
            this.radAnnPar.Size = new System.Drawing.Size(152, 16);
            this.radAnnPar.TabIndex = 2;
            this.radAnnPar.Text = "Annullamento parziale";
            // 
            // radAnnullo
            // 
            this.radAnnullo.Enabled = false;
            this.radAnnullo.Location = new System.Drawing.Point(16, 32);
            this.radAnnullo.Name = "radAnnullo";
            this.radAnnullo.Size = new System.Drawing.Size(152, 16);
            this.radAnnullo.TabIndex = 1;
            this.radAnnullo.Text = "Annullamento reversale";
            // 
            // radNormale
            // 
            this.radNormale.Location = new System.Drawing.Point(16, 16);
            this.radNormale.Name = "radNormale";
            this.radNormale.Size = new System.Drawing.Size(104, 16);
            this.radNormale.TabIndex = 0;
            this.radNormale.Text = "Normale";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.txtDocumento);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.txtDataDocumento);
            this.groupBox1.Location = new System.Drawing.Point(507, 257);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(313, 93);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Documento";
            // 
            // txtDocumento
            // 
            this.txtDocumento.Location = new System.Drawing.Point(8, 16);
            this.txtDocumento.Name = "txtDocumento";
            this.txtDocumento.Size = new System.Drawing.Size(291, 20);
            this.txtDocumento.TabIndex = 1;
            this.txtDocumento.Tag = "incomevar.doc?incomevarview.doc";
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(125, 48);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(64, 24);
            this.label8.TabIndex = 89;
            this.label8.Text = "Data:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDataDocumento
            // 
            this.txtDataDocumento.Location = new System.Drawing.Point(203, 51);
            this.txtDataDocumento.Name = "txtDataDocumento";
            this.txtDataDocumento.Size = new System.Drawing.Size(96, 20);
            this.txtDataDocumento.TabIndex = 2;
            this.txtDataDocumento.Tag = "incomevar.docdate?incomevarview.docdate";
            // 
            // chkDocIVA
            // 
            this.chkDocIVA.Location = new System.Drawing.Point(8, 8);
            this.chkDocIVA.Name = "chkDocIVA";
            this.chkDocIVA.Size = new System.Drawing.Size(256, 18);
            this.chkDocIVA.TabIndex = 1;
            this.chkDocIVA.Text = "Abilita contabilizzazione note di credito";
            this.chkDocIVA.CheckedChanged += new System.EventHandler(this.chkDocIVA_CheckedChanged);
            // 
            // grpDocumento
            // 
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
            this.grpDocumento.Size = new System.Drawing.Size(812, 80);
            this.grpDocumento.TabIndex = 2;
            this.grpDocumento.TabStop = false;
            this.grpDocumento.Tag = "AutoChoose.S1ubEntity_txtNumero.lista";
            this.grpDocumento.Text = "Nota di Credito";
            // 
            // S1ubEntity_cmbCausale
            // 
            this.S1ubEntity_cmbCausale.DataSource = this.DS.tipomovimento;
            this.S1ubEntity_cmbCausale.DisplayMember = "descrizione";
            this.S1ubEntity_cmbCausale.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.S1ubEntity_cmbCausale.Location = new System.Drawing.Point(72, 48);
            this.S1ubEntity_cmbCausale.Name = "S1ubEntity_cmbCausale";
            this.S1ubEntity_cmbCausale.Size = new System.Drawing.Size(284, 21);
            this.S1ubEntity_cmbCausale.TabIndex = 4;
            this.S1ubEntity_cmbCausale.Tag = "incomevar.movkind";
            this.S1ubEntity_cmbCausale.ValueMember = "idtipo";
            // 
            // label13
            // 
            this.label13.Location = new System.Drawing.Point(13, 48);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(48, 16);
            this.label13.TabIndex = 23;
            this.label13.Text = "Causale";
            // 
            // S1ubEntity_txtNumero
            // 
            this.S1ubEntity_txtNumero.Location = new System.Drawing.Point(702, 18);
            this.S1ubEntity_txtNumero.Name = "S1ubEntity_txtNumero";
            this.S1ubEntity_txtNumero.Size = new System.Drawing.Size(96, 20);
            this.S1ubEntity_txtNumero.TabIndex = 3;
            this.S1ubEntity_txtNumero.Tag = "invoiceavailable.ninv?incomevar.ninv";
            // 
            // S1ubEntity_txtEsercizio
            // 
            this.S1ubEntity_txtEsercizio.Location = new System.Drawing.Point(566, 18);
            this.S1ubEntity_txtEsercizio.Name = "S1ubEntity_txtEsercizio";
            this.S1ubEntity_txtEsercizio.Size = new System.Drawing.Size(56, 20);
            this.S1ubEntity_txtEsercizio.TabIndex = 2;
            this.S1ubEntity_txtEsercizio.Tag = "invoiceavailable.yinv.year?incomevar.yinv.year";
            this.S1ubEntity_txtEsercizio.Leave += new System.EventHandler(this.txtEsercizio_Leave);
            // 
            // btnDocumento
            // 
            this.btnDocumento.Location = new System.Drawing.Point(390, 14);
            this.btnDocumento.Name = "btnDocumento";
            this.btnDocumento.Size = new System.Drawing.Size(96, 23);
            this.btnDocumento.TabIndex = 4;
            this.btnDocumento.TabStop = false;
            this.btnDocumento.Text = "Seleziona doc.";
            this.btnDocumento.Click += new System.EventHandler(this.btnDocumento_Click);
            // 
            // S1ubEntity_cmbTipoDoc
            // 
            this.S1ubEntity_cmbTipoDoc.DataSource = this.DS.invoicekind;
            this.S1ubEntity_cmbTipoDoc.DisplayMember = "description";
            this.S1ubEntity_cmbTipoDoc.Location = new System.Drawing.Point(72, 16);
            this.S1ubEntity_cmbTipoDoc.Name = "S1ubEntity_cmbTipoDoc";
            this.S1ubEntity_cmbTipoDoc.Size = new System.Drawing.Size(284, 21);
            this.S1ubEntity_cmbTipoDoc.TabIndex = 1;
            this.S1ubEntity_cmbTipoDoc.Tag = "invoiceavailable.idinvkind?incomevar.idinvkind";
            this.S1ubEntity_cmbTipoDoc.ValueMember = "idinvkind";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(654, 21);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 16);
            this.label6.TabIndex = 2;
            this.label6.Text = "Numero";
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(502, 21);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(64, 16);
            this.label11.TabIndex = 1;
            this.label11.Text = "Esercizio";
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(13, 16);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(56, 16);
            this.label12.TabIndex = 0;
            this.label12.Text = "Tipo doc.";
            // 
            // grpImporto
            // 
            this.grpImporto.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpImporto.Controls.Add(this.rdbAumento);
            this.grpImporto.Controls.Add(this.rdbDiminuzione);
            this.grpImporto.Controls.Add(this.txtImporto);
            this.grpImporto.Location = new System.Drawing.Point(236, 257);
            this.grpImporto.Name = "grpImporto";
            this.grpImporto.Size = new System.Drawing.Size(258, 64);
            this.grpImporto.TabIndex = 7;
            this.grpImporto.TabStop = false;
            this.grpImporto.Tag = "incomevar.amount.valuesigned";
            this.grpImporto.Text = "Importo della variazione";
            this.grpImporto.Leave += new System.EventHandler(this.grpImporto_Leave);
            // 
            // rdbAumento
            // 
            this.rdbAumento.Location = new System.Drawing.Point(152, 16);
            this.rdbAumento.Name = "rdbAumento";
            this.rdbAumento.Size = new System.Drawing.Size(80, 16);
            this.rdbAumento.TabIndex = 2;
            this.rdbAumento.Tag = "+";
            this.rdbAumento.Text = "Aumento";
            // 
            // rdbDiminuzione
            // 
            this.rdbDiminuzione.Location = new System.Drawing.Point(152, 40);
            this.rdbDiminuzione.Name = "rdbDiminuzione";
            this.rdbDiminuzione.Size = new System.Drawing.Size(88, 16);
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
            this.txtImporto.Tag = "incomevar.amount?incomevarview.amount";
            // 
            // txtDescrizione
            // 
            this.txtDescrizione.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescrizione.Location = new System.Drawing.Point(166, 195);
            this.txtDescrizione.Multiline = true;
            this.txtDescrizione.Name = "txtDescrizione";
            this.txtDescrizione.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDescrizione.Size = new System.Drawing.Size(640, 56);
            this.txtDescrizione.TabIndex = 5;
            this.txtDescrizione.Tag = "incomevar.description?incomevarview.description";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(166, 179);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(160, 16);
            this.label5.TabIndex = 128;
            this.label5.Text = "Descrizione della Variazione:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // grpVariazione
            // 
            this.grpVariazione.Controls.Add(this.label1);
            this.grpVariazione.Controls.Add(this.txtNumVariazione);
            this.grpVariazione.Controls.Add(this.label2);
            this.grpVariazione.Controls.Add(this.txtEsercVariazione);
            this.grpVariazione.Location = new System.Drawing.Point(8, 179);
            this.grpVariazione.Name = "grpVariazione";
            this.grpVariazione.Size = new System.Drawing.Size(152, 72);
            this.grpVariazione.TabIndex = 4;
            this.grpVariazione.TabStop = false;
            this.grpVariazione.Text = "Variazione";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(32, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 16);
            this.label1.TabIndex = 11;
            this.label1.Text = "Numero:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtNumVariazione
            // 
            this.txtNumVariazione.Location = new System.Drawing.Point(88, 40);
            this.txtNumVariazione.Name = "txtNumVariazione";
            this.txtNumVariazione.Size = new System.Drawing.Size(56, 20);
            this.txtNumVariazione.TabIndex = 2;
            this.txtNumVariazione.Tag = "incomevar.nvar?incomevarview.nvar";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(16, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 24);
            this.label2.TabIndex = 9;
            this.label2.Text = "Esercizio:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtEsercVariazione
            // 
            this.txtEsercVariazione.Location = new System.Drawing.Point(88, 16);
            this.txtEsercVariazione.Name = "txtEsercVariazione";
            this.txtEsercVariazione.Size = new System.Drawing.Size(56, 20);
            this.txtEsercVariazione.TabIndex = 1;
            this.txtEsercVariazione.Tag = "incomevar.yvar?incomevarview.yvar";
            // 
            // grpMovimento
            // 
            this.grpMovimento.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpMovimento.Controls.Add(this.cmbFase);
            this.grpMovimento.Controls.Add(this.label3);
            this.grpMovimento.Controls.Add(this.txtNumEntrata);
            this.grpMovimento.Controls.Add(this.label4);
            this.grpMovimento.Controls.Add(this.txtEsercEntrata);
            this.grpMovimento.Controls.Add(this.btnAccertamento);
            this.grpMovimento.Controls.Add(this.label10);
            this.grpMovimento.Location = new System.Drawing.Point(8, 118);
            this.grpMovimento.Name = "grpMovimento";
            this.grpMovimento.Size = new System.Drawing.Size(812, 55);
            this.grpMovimento.TabIndex = 3;
            this.grpMovimento.TabStop = false;
            this.grpMovimento.Tag = "";
            this.grpMovimento.Text = "Movimento di entrata";
            // 
            // cmbFase
            // 
            this.cmbFase.DataSource = this.DS.incomephase;
            this.cmbFase.DisplayMember = "description";
            this.cmbFase.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFase.Location = new System.Drawing.Point(72, 16);
            this.cmbFase.Name = "cmbFase";
            this.cmbFase.Size = new System.Drawing.Size(284, 21);
            this.cmbFase.TabIndex = 1;
            this.cmbFase.Tag = "incomeview.nphase?incomevarview.nphase";
            this.cmbFase.ValueMember = "nphase";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(640, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 24);
            this.label3.TabIndex = 7;
            this.label3.Text = "Numero";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtNumEntrata
            // 
            this.txtNumEntrata.Location = new System.Drawing.Point(696, 15);
            this.txtNumEntrata.Name = "txtNumEntrata";
            this.txtNumEntrata.Size = new System.Drawing.Size(102, 20);
            this.txtNumEntrata.TabIndex = 3;
            this.txtNumEntrata.Tag = "incomeview.nmov?incomevarview.nmov";
            this.txtNumEntrata.Leave += new System.EventHandler(this.txtNumEntrata_Leave);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(496, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 24);
            this.label4.TabIndex = 5;
            this.label4.Text = "Esercizio:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtEsercEntrata
            // 
            this.txtEsercEntrata.Location = new System.Drawing.Point(568, 15);
            this.txtEsercEntrata.Name = "txtEsercEntrata";
            this.txtEsercEntrata.Size = new System.Drawing.Size(56, 20);
            this.txtEsercEntrata.TabIndex = 2;
            this.txtEsercEntrata.Tag = "incomeview.ymov.year?incomevarview.ymov.year";
            this.txtEsercEntrata.Leave += new System.EventHandler(this.txtEsercEntrata_Leave);
            // 
            // btnAccertamento
            // 
            this.btnAccertamento.Location = new System.Drawing.Point(384, 14);
            this.btnAccertamento.Name = "btnAccertamento";
            this.btnAccertamento.Size = new System.Drawing.Size(104, 23);
            this.btnAccertamento.TabIndex = 0;
            this.btnAccertamento.TabStop = false;
            this.btnAccertamento.Tag = "";
            this.btnAccertamento.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAccertamento.Click += new System.EventHandler(this.btnAccertamento_Click);
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(21, 17);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(40, 16);
            this.label10.TabIndex = 90;
            this.label10.Text = "Fase:";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label10.Click += new System.EventHandler(this.label10_Click);
            // 
            // tabDettagli
            // 
            this.tabDettagli.Controls.Add(this.grpInvoiceDetail);
            this.tabDettagli.Location = new System.Drawing.Point(4, 23);
            this.tabDettagli.Name = "tabDettagli";
            this.tabDettagli.Size = new System.Drawing.Size(856, 425);
            this.tabDettagli.TabIndex = 3;
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
            this.grpInvoiceDetail.Location = new System.Drawing.Point(8, -2);
            this.grpInvoiceDetail.Name = "grpInvoiceDetail";
            this.grpInvoiceDetail.Size = new System.Drawing.Size(840, 428);
            this.grpInvoiceDetail.TabIndex = 1;
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
            this.dgrDettagliFattura.Location = new System.Drawing.Point(88, 8);
            this.dgrDettagliFattura.Name = "dgrDettagliFattura";
            this.dgrDettagliFattura.Size = new System.Drawing.Size(744, 412);
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
            this.txtTotInvoiceDetail.Location = new System.Drawing.Point(8, 144);
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
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox5);
            this.tabPage2.Controls.Add(this.DGridClassificazioni);
            this.tabPage2.Controls.Add(this.label9);
            this.tabPage2.ImageIndex = 1;
            this.tabPage2.Location = new System.Drawing.Point(4, 23);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(856, 425);
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
            this.groupBox5.Location = new System.Drawing.Point(0, 124);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(856, 296);
            this.groupBox5.TabIndex = 10;
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
            this.DGridDettagliClassificazioni.Size = new System.Drawing.Size(840, 224);
            this.DGridDettagliClassificazioni.TabIndex = 7;
            this.DGridDettagliClassificazioni.Tag = "incomesorted.default";
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
            this.DGridClassificazioni.Location = new System.Drawing.Point(0, 32);
            this.DGridClassificazioni.Name = "DGridClassificazioni";
            this.DGridClassificazioni.Size = new System.Drawing.Size(856, 90);
            this.DGridClassificazioni.TabIndex = 9;
            this.DGridClassificazioni.Tag = "sortingkind.default";
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(8, 8);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(100, 23);
            this.label9.TabIndex = 8;
            this.label9.Text = "Classificazioni";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.grpAssIncassi);
            this.tabPage3.Controls.Add(this.grpAssCrediti);
            this.tabPage3.Location = new System.Drawing.Point(4, 23);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(856, 425);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Assegnazioni";
            // 
            // grpAssIncassi
            // 
            this.grpAssIncassi.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpAssIncassi.Controls.Add(this.button4);
            this.grpAssIncassi.Controls.Add(this.dataGrid2);
            this.grpAssIncassi.Controls.Add(this.button5);
            this.grpAssIncassi.Controls.Add(this.button6);
            this.grpAssIncassi.Location = new System.Drawing.Point(0, 232);
            this.grpAssIncassi.Name = "grpAssIncassi";
            this.grpAssIncassi.Size = new System.Drawing.Size(856, 188);
            this.grpAssIncassi.TabIndex = 14;
            this.grpAssIncassi.TabStop = false;
            this.grpAssIncassi.Text = "Dettagli Incassi";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(8, 24);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 8;
            this.button4.Tag = "insert.variazione";
            this.button4.Text = "Aggiungi";
            // 
            // dataGrid2
            // 
            this.dataGrid2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGrid2.DataMember = "";
            this.dataGrid2.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid2.Location = new System.Drawing.Point(8, 56);
            this.dataGrid2.Name = "dataGrid2";
            this.dataGrid2.Size = new System.Drawing.Size(840, 122);
            this.dataGrid2.TabIndex = 7;
            this.dataGrid2.Tag = "proceedspart.detail";
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(184, 24);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 6;
            this.button5.Tag = "delete";
            this.button5.Text = "Cancella";
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(96, 24);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(75, 23);
            this.button6.TabIndex = 5;
            this.button6.Tag = "edit.variazione";
            this.button6.Text = "Correggi";
            // 
            // grpAssCrediti
            // 
            this.grpAssCrediti.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpAssCrediti.Controls.Add(this.button1);
            this.grpAssCrediti.Controls.Add(this.dataGrid1);
            this.grpAssCrediti.Controls.Add(this.button2);
            this.grpAssCrediti.Controls.Add(this.button3);
            this.grpAssCrediti.Location = new System.Drawing.Point(0, 8);
            this.grpAssCrediti.Name = "grpAssCrediti";
            this.grpAssCrediti.Size = new System.Drawing.Size(856, 224);
            this.grpAssCrediti.TabIndex = 13;
            this.grpAssCrediti.TabStop = false;
            this.grpAssCrediti.Text = "Dettagli Crediti";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(8, 24);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 8;
            this.button1.Tag = "insert.variazione";
            this.button1.Text = "Aggiungi";
            // 
            // dataGrid1
            // 
            this.dataGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGrid1.DataMember = "";
            this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid1.Location = new System.Drawing.Point(8, 56);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.Size = new System.Drawing.Size(840, 158);
            this.dataGrid1.TabIndex = 7;
            this.dataGrid1.Tag = "creditpart.detail";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(184, 24);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 6;
            this.button2.Tag = "delete";
            this.button2.Text = "Cancella";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(96, 24);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 5;
            this.button3.Tag = "edit.variazione";
            this.button3.Text = "Correggi";
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "");
            this.imageList1.Images.SetKeyName(1, "");
            // 
            // Frm_incomevar_default
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(864, 452);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Frm_incomevar_default";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmvariazioneentrata";
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.grpDocumento.ResumeLayout(false);
            this.grpDocumento.PerformLayout();
            this.grpImporto.ResumeLayout(false);
            this.grpImporto.PerformLayout();
            this.grpVariazione.ResumeLayout(false);
            this.grpVariazione.PerformLayout();
            this.grpMovimento.ResumeLayout(false);
            this.grpMovimento.PerformLayout();
            this.tabDettagli.ResumeLayout(false);
            this.grpInvoiceDetail.ResumeLayout(false);
            this.grpInvoiceDetail.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrDettagliFattura)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGridDettagliClassificazioni)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGridClassificazioni)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.grpAssIncassi.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid2)).EndInit();
            this.grpAssCrediti.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

	    string filteresercizio;
        int esercizio;
        QueryHelper QHS;
        CQueryHelper QHC;
		public void MetaData_AfterLink() {
			
			Meta=MetaData.GetMetaData(this);
            MetaIncSorted = MetaData.GetMetaData(this, "incomevar");
			this.Conn=Meta.Conn;
            QHC = new CQueryHelper();
            QHS = Conn.GetQueryHelper();
            esercizio = CfgFn.GetNoNullInt32(Meta.GetSys("esercizio"));

            filteresercizio = QHS.CmpEq("ayear", esercizio);
			GetData.CacheTable(DS.incomephase, null, "nphase", true);
			GetData.SetStaticFilter(DS.incomeview, filteresercizio);
			command="choose.incomeview.assegnazionecredito";
			GetData.CacheTable(DS.config, filteresercizio, null, false);
            string filterflag = QHS.AppAnd(QHS.BitSet("flag", 0), QHS.BitSet("flag", 2));
			GetData.CacheTable(DS.invoicekind,filterflag,null,true);
            GetData.SetStaticFilter(DS.invoiceavailable, filterflag);
			PostData.MarkAsTemporaryTable(DS.tipomovimento,false);
            string filterfaseentrata = QHS.IsNotNull("nphaseincome");
			GetData.CacheTable(DS.sortingkind, filterfaseentrata,null,false);
			DS.incomesorted.ExtendedProperties["gridmaster"]="sortingkind";
			GetData.SetStaticFilter(DS.incomesorted, filteresercizio);
            string filteresercassCrediti = QHS.CmpEq("ycreditpart", esercizio);
            string filteresercassIncassi = QHS.CmpEq("yproceedspart", esercizio);
			GetData.SetStaticFilter(DS.creditpart, filteresercassCrediti);
			GetData.SetStaticFilter(DS.proceedspart, filteresercassIncassi);

			DataAccess.SetTableForReading(DS.invoicedetail_iva, "invoicedetailview");
			DataAccess.SetTableForReading(DS.invoicedetail_taxable, "invoicedetailview");
			QueryCreator.SetTableForPosting(DS.invoicedetail_iva, "invoicedetail");
			QueryCreator.SetTableForPosting(DS.invoicedetail_taxable, "invoicedetail");
            GetData.SetStaticFilter(DS.invoicedetail_iva, QHS.BitSet("flag", 2));
            GetData.SetStaticFilter(DS.invoicedetail_taxable, QHS.BitSet("flag", 2));

		    HelpForm.SetDenyNull(DS.incomevar.Columns["amount"], true);

			faseentratamax = CfgFn.GetNoNullInt32(Meta.GetSys("maxincomephase"));
		}

		public void MetaData_AfterClear() {
			txtEsercVariazione.Text= esercizio.ToString();
            txtEsercVariazione.Enabled = true;
            grpMovimento.Enabled=true;
			cmbFase.SelectedIndex=0;
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
			m_CodiceCredDebE=null;
			SetListingType(true);
			ChangingFase=false;
			EnableDisableClassificazioni(false);
			Meta.UnMarkTableAsNotEntityChild(DS.incomesorted);
			Meta.UnMarkTableAsNotEntityChild(DS.creditpart);
			Meta.UnMarkTableAsNotEntityChild(DS.proceedspart);
			ResetIva();
			grpInvoiceDetail.Visible = false;
			lastamount=0;
            impostaFiltroPerDocIVA(null);
		}

		public void MetaData_AfterActivation() {
			if (DS.config.Rows.Count==0) return;
			m_CodiceFaseCont=Meta.GetSys("invoiceincomephase").ToString();
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
				DataRow Curr= DS.incomevar.Rows[0];
                object idinc = Curr["idinc"];
                DataRow[] Inc = DS.incomeview.Select(QHC.CmpEq("idinc", idinc));
                int nfase;
                if (Inc.Length > 0) {
                    nfase = CfgFn.GetNoNullInt32(Inc[0]["nphase"]);
                }
                else {
                    nfase = CfgFn.GetNoNullInt32(Conn.DO_READ_VALUE("income", QHS.CmpEq("idinc", idinc), "nphase"));
                }

				if (nfase==0) {
					DS.sortingkind.Clear();
				}
				else {
                    string filterfaseentrata = QHS.CmpEq("nphaseincome", nfase);
					DS.sortingkind.Clear();
					Conn.RUN_SELECT_INTO_TABLE(DS.sortingkind,null, filterfaseentrata,null,false); 
				}
			}
			CalcolaTotaliClassificazioni();
		}

		public void MetaData_AfterFill() {
                DataRow CurrSorKind = HelpForm.GetLastSelected(DS.sortingkind);
                if (CurrSorKind != null) {
                    string f = QHC.CmpEq("!idsorkind", CurrSorKind["idsorkind"]);
                    DS.incomesorted.ExtendedProperties["CustomParentRelation"] = f;
                }

            if (!Meta.InsertMode){
				grpMovimento.Enabled=false;
			}
			Meta.MarkTableAsNotEntityChild(DS.incomesorted);
			Meta.MarkTableAsNotEntityChild(DS.creditpart);
			Meta.MarkTableAsNotEntityChild(DS.proceedspart);
			EnableDisableCheckAnnullo();
			FillAnnullo();
            int currPhase = CfgFn.GetNoNullInt32(cmbFase.SelectedValue);
			EnableDisableCheckDocIVA(currPhase);
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
                bool abilita = ((DS.incomevar.Rows.Count > 0) && (DS.incomevar.Rows[0]["idinvkind"] != DBNull.Value));
				AbilitaDisabilitaControlliFattura(abilita);
			}

			EnableDisableClassificazioni(true);

			if (Meta.FirstFillForThisRow && !Meta.IsEmpty){
				ManageTipoClassMovimentiRowChanged(GetImportoPerClassificazione(),DS.incomevar.Rows[0]);
				gestioneGrpAssegnazioni(currPhase);
                CalcTotInvoiceDetail();
			}
            txtEsercVariazione.Enabled = false;
        }

		private void rimuoviDettagliFatturaEsterni() {
			foreach(DataRow rDet in DS.invoicedetail_iva.Select()) {
                if (rDet.RowState != DataRowState.Unchanged) continue;
				string filtro =
                    QHC.AppAnd(QHC.CmpEq("idinvkind", rDet["idinvkind"]),
                        QHC.CmpEq("yinv", rDet["yinv"]),
                        QHC.CmpEq("ninv", rDet["ninv"]),
                        QHC.CmpEq("idinc", rDet["idinc_iva"]));
				if (DS.incomevar.Select(filtro).Length == 0) {
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
                        QHC.CmpEq("idinc", rDet["idinc_taxable"]));
				if (DS.incomevar.Select(filtro).Length == 0) {
					rDet.Delete();
					rDet.AcceptChanges();
				}
			}
		}

        void ResetIva() {
            IvaLinkedMustBeEvalued = true;
            IvaLinked = null;
        }

        public void MetaData_AfterGetFormData() {
            GetAnnullo();
        }

        private void resetIvaRef() {
            if (DS.incomevar.Rows.Count == 0) return;
            DataRow Curr = DS.incomevar.Rows[0];
            Curr["idinvkind"] = DBNull.Value;
            Curr["yinv"] = DBNull.Value;
            Curr["ninv"] = DBNull.Value;
            Curr["movkind"] = DBNull.Value;
        }

        private void impostaFiltroPerDocIVA(DataRow rIncome) {
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
                    if (rIncome == null) return;
                    string fReg = QHS.CmpEq("idreg", rIncome["idreg"]);
                    string filtro = QHS.CmpGt("residual", 0);
                    filtro = GetData.MergeFilters(filtro, fReg);
                    AI.startfilter = filtro;
                }
                return;
            }
        }

        public void MetaData_BeforeRowSelect(DataTable T, DataRow R) {
            if (Meta.DrawStateIsDone && T.TableName == "sortingkind") {
                if (R != null) {
                    string f = QHC.CmpEq("!idsorkind", R["idsorkind"]);
                    DS.incomesorted.ExtendedProperties["CustomParentRelation"] = f;
                }
            }
        }

		public void MetaData_AfterRowSelect(DataTable T, DataRow R){
			if (T.TableName == "incomeview"){
                if (!Meta.DrawStateIsDone) return;
				if (Meta.InsertMode){
					if (R==null){
						DS.incomesorted.Clear();
						DS.creditpart.Clear();
						DS.proceedspart.Clear();
						grpAssCrediti.Enabled = false;
						grpAssIncassi.Enabled = false;
                        resetIvaRef();
					}
					else {
						DS.incomesorted.Clear();
						DS.creditpart.Clear();
						DS.proceedspart.Clear();
                        string filterIdEntrata = QHS.CmpEq("idinc", R["idinc"]);
                        string filterClass = QHS.AppAnd(filterIdEntrata, QHS.CmpEq("ayear", esercizio));
                        string filterAssC = QHS.AppAnd(filterIdEntrata, QHS.CmpEq("ycreditpart", esercizio));
                        string filterAssI = QHS.AppAnd(filterIdEntrata, QHS.CmpEq("yproceedspart", esercizio));
						Conn.RUN_SELECT_INTO_TABLE(DS.incomesorted, null, filterClass, null, false);
						Conn.RUN_SELECT_INTO_TABLE(DS.creditpart,null,filterAssC, null, false);
						Conn.RUN_SELECT_INTO_TABLE(DS.proceedspart,null, filterAssI, null, false);
						// Riempio la tabella sorting 
						RicalcolaSorting();
						RicalcolaAssegnazioneCrediti();
						RicalcolaAssegnazioneIncassi();
						DS.incomevar.Rows[0]["idinc"]=R["idinc"];						
						gestioneGrpAssegnazioni(CfgFn.GetNoNullInt32(R["nphase"]));
					}
                    impostaFiltroPerDocIVA(R);
					SetCredDebFilter(R,"E");
					DrawGridTipoClass();
				}
			}

			if (T.TableName == "tipomovimento") {
				if (!Meta.DrawStateIsDone)return;
                if (Meta.InsertMode) {
                    if (DS.incomevar.Rows.Count == 0) return;
                    DS.incomevar.Rows[0]["movkind"] = (S1ubEntity_cmbCausale.SelectedValue != null)
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
					DS.incomevar.Rows[0]["description"]="";
					DS.incomevar.Rows[0]["doc"]=DBNull.Value;
					DS.incomevar.Rows[0]["docdate"]=DBNull.Value;
                    grpInvoiceDetail.Visible = false;
                    AbilitaDisabilitaControlliFattura(false);
				}
				else {
					DS.incomevar.Rows[0]["description"]=R["description"];
					DS.incomevar.Rows[0]["doc"]=R["doc"];
					DS.incomevar.Rows[0]["docdate"]=R["docdate"];
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

			if (T.TableName == "incomephase"){
                if (!Meta.DrawStateIsDone) return;
				string DescrFase="";
				DS.incomesorted.Clear();
				DS.creditpart.Clear();
				DS.proceedspart.Clear();
                if (cmbFase.SelectedIndex == 0) {

                    btnAccertamento.Text = "Movimento";
                    if (ChangingFase) {
                        ChangingFase = false;
                        return;
                    }
                    DS.sortingkind.Clear();
                    grpAssCrediti.Enabled = false;
                    grpAssIncassi.Enabled = false;
                    ClearEntrata(true);
                    return;
                }
                else {
                    // rileggere in base alla fase selezionata
                    string filterfaseentrata = QHS.CmpEq("nphaseincome", cmbFase.SelectedValue);
                    DS.sortingkind.Clear();
                    Conn.RUN_SELECT_INTO_TABLE(DS.sortingkind, null, filterfaseentrata, null, false);
                    if (CfgFn.GetNoNullInt32(cmbFase.SelectedValue) == faseentratamax){
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
				txtEsercEntrata.Text="";
				txtNumEntrata.Text="";
				if (!Meta.DrawStateIsDone)return;
				if (ChangingFase) {
					ChangingFase=false;
					return;
				}
				ClearEntrata(true);
                if (R != null) {
                    int selectedPhase = CfgFn.GetNoNullInt32(R["nphase"]);
                    EnableDisableCheckDocIVA(selectedPhase);
                 }
			}
			if ((T.TableName == "sortingkind")&& Meta.DrawStateIsDone) {				
				ManageTipoClassMovimentiRowChanged(
					GetImportoPerClassificazione(), R);
				return;
			}
		}
	
		private void gestioneGrpAssegnazioni(int currphase) {
			if (Meta.IsEmpty) {
				grpAssCrediti.Enabled = false;
				grpAssIncassi.Enabled = false;
				return;
			}
			int faseBilancio = CfgFn.GetNoNullInt32(Meta.GetSys("incomefinphase"));
			int faseEntrataMax = CfgFn.GetNoNullInt32(Meta.GetSys("maxincomephase"));
			if (currphase == faseBilancio) {
				grpAssCrediti.Enabled = true;
			}
			else {
				grpAssCrediti.Enabled = false;
			}
			if (currphase == faseEntrataMax) {
				grpAssIncassi.Enabled = true;
			}
			else {
				grpAssIncassi.Enabled = false;
			}
		}

		void RicalcolaSorting(){
			object idsor;
            //object idsorkind;
			string filteridsor;
            
			if (DS.incomesorted.Rows.Count>0) {
				// Ciclo sulle righe di DS.incomesorted per eseguire la lettura della tabella DS.sorting 
				// e per valorizzare i campi calcolati relativi al codice e alla descrizione
				foreach (DataRow Curr in DS.incomesorted.Rows){
					idsor   = Curr["idsor"];
                    filteridsor = QHC.CmpEq("idsor", idsor);
                    //idsorkind = Curr["idsorkind"];
                    //filteridsorkind = QHC.CmpEq("idsorkind", idsorkind);
                    //filter = GetData.MergeFilters(filteridsor, filteridsorkind);
					DataRow []RigheInserite;
                    RigheInserite = DS.Tables["sorting"].Select(filteridsor);
					if (RigheInserite.Length==0) {
                        //string sqlfilter = QHS.AppAnd(QHS.CmpEq("idsor", idsor), QHS.CmpEq("idsorkind", idsorkind));
                        string sqlfilter = (QHS.CmpEq("idsor", idsor));
                        Conn.RUN_SELECT_INTO_TABLE(DS.sorting, null, sqlfilter, null, false); 
					}
                    DataRow[] RigheFiltrate = DS.sorting.Select(filteridsor);
					if (RigheFiltrate.Length>0){
                        Curr["!idsorkind"] = RigheFiltrate[0]["idsorkind"];
                        Curr["!codice"] = RigheFiltrate[0]["sortcode"];
						Curr["!descr"]=  RigheFiltrate[0]["description"];
					}
				}
			}
		}

		void RicalcolaAssegnazioneCrediti() {
			object idfin;
			string filter;

			if (DS.creditpart.Rows.Count>0) {
				// Ciclo sulle righe di DS.creditpart per eseguire la lettura della tabella DS.creditpart
				// e per valorizzare i campi calcolati relativi al codice e alla descrizione
				foreach (DataRow Curr in DS.creditpart.Rows){
					idfin = Curr["idfin"];
                    filter = QHC.CmpEq("idfin", idfin);
					DataRow []RigheInserite;
					RigheInserite = DS.Tables["fin"].Select(filter);
					if (RigheInserite.Length==0) {
						Conn.RUN_SELECT_INTO_TABLE(DS.fin,null, QHS.CmpEq("idfin", idfin),null,false); 
					}
					DataRow []RigheFiltrate = DS.fin.Select(filter);
					if (RigheFiltrate.Length>0){
						Curr["!codice"]= RigheFiltrate[0]["codefin"];
						Curr["!descr"]=  RigheFiltrate[0]["title"];
					}
				}
			}
		}

		void RicalcolaAssegnazioneIncassi() {
			object idfin;
			string filter;

			if (DS.proceedspart.Rows.Count>0) {
				// Ciclo sulle righe di DS.creditpart per eseguire la lettura della tabella DS.creditpart
				// e per valorizzare i campi calcolati relativi al codice e alla descrizione
				foreach (DataRow Curr in DS.proceedspart.Rows){
                    idfin = Curr["idfin"];
                    filter = QHC.CmpEq("idfin", idfin);
                    DataRow[] RigheInserite;
					RigheInserite = DS.Tables["fin"].Select(filter);
					if (RigheInserite.Length==0) {
                        Conn.RUN_SELECT_INTO_TABLE(DS.fin, null, QHS.CmpEq("idfin", idfin), null, false); 
					}
					DataRow []RigheFiltrate = DS.fin.Select(filter);
					if (RigheFiltrate.Length>0){
						Curr["!codice"]= RigheFiltrate[0]["codefin"];
						Curr["!descr"]=  RigheFiltrate[0]["title"];
					}
				}
			}
		}

		decimal GetImportoVariazione(){
			DataRow R = DS.incomevar.Rows[0];
			if (R["amount"]==DBNull.Value) return 0;
			return Convert.ToDecimal(R["amount"]);
		}

		void VerificaImportovariazione(){
			Meta.GetFormData(true);
			if ((!Meta.IsEmpty)&&(lastamount!=GetImportoVariazione())){
				lastamount= GetImportoVariazione();
				ManageTipoClassMovimentiRowChanged(GetImportoPerClassificazione(),DS.incomevar.Rows[0]);
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
		int kpro = 0;
		public void MetaData_BeforePost() {
			mustUpdateProceedsBank=false;
			kpro=0; //Di norma NON fa nulla
			//se in fase di inserimento non ho la spunta su doc iva

			if (DS.incomevar.Rows.Count == 0) { // Se annullo l'inserimento non salva le classificazioni
				DS.incomesorted.Clear(); 
				DS.creditpart.Clear();
				DS.proceedspart.Clear();
			}
			if (DS.incomevar.Rows.Count==0) return;
			varCancellata=false;
			if (DS.incomevar.Rows[0].RowState == DataRowState.Deleted) {
				//In questo caso si preserva l'eventuale n. di reversale
				mustUpdateProceedsBank=true;
				varCancellata = true;
				DataRow CurrVar = DS.incomevar.Rows[0];
                string filtroEntrata = QHC.CmpEq("idinc", CurrVar["idinc", DataRowVersion.Original]);
				DataRow [] rEntrata = DS.incomeview.Select(filtroEntrata);
				if (rEntrata.Length == 0) return;
				if (rEntrata[0]["kpro"] == DBNull.Value) return;
				kpro = CfgFn.GetNoNullInt32(rEntrata[0]["kpro"]);
			}
			if (DS.incomevar.Rows[0].RowState== DataRowState.Added){
				mustUpdateProceedsBank=true;
			}
			if (DS.incomevar.Rows[0].RowState== DataRowState.Modified){
				decimal oldimporto= CfgFn.GetNoNullDecimal(DS.incomevar.Rows[0]["amount",DataRowVersion.Original]);
				decimal newimporto= CfgFn.GetNoNullDecimal(DS.incomevar.Rows[0]["amount",DataRowVersion.Current]);
				if (oldimporto!=newimporto) mustUpdateProceedsBank=true;
			}


		}

		public void MetaData_AfterPost() {
			if (mustUpdateProceedsBank) fillProceedsBank();
		}

		private void fillProceedsBank() {
			if (!varCancellata) {
				DataRow CurrVar = DS.incomevar.Rows[0];
                string filtro = QHC.CmpEq("idinc", CurrVar["idinc"]);
				DataRow [] rEntrata = DS.incomeview.Select(filtro);
				if (rEntrata.Length == 0) return;
				if (rEntrata[0]["kpro"] == DBNull.Value) return;
				kpro = CfgFn.GetNoNullInt32(rEntrata[0]["kpro"]);
			}
			// Nel caso la var. Ë stata cancellata e il mov. di entrata non era presente in una reversale non devo eseguire
			// il ricalcolo dei movimenti bancari
			if (kpro == 0) return;
			Meta.Conn.CallSP("compute_proceeds_bank", new object [] {kpro});
		}

		private void EnableDisableCheckAnnullo()
		{
			if (Meta.IsEmpty) 
			{
				radNormale.Enabled=false;
				radAnnPar.Enabled=false;
				return;
			}
			DataRow R= DS.incomevar.Rows[0];
            int currauto = CfgFn.GetNoNullInt32(R["autokind"]);
            if ((currauto == 0) || (currauto == 10) || (currauto == 22))
            { //ANPAR
                radNormale.Enabled = true;
                radAnnPar.Enabled = true;
                radEdit.Enabled = maxphase;
            }
            else
            {
                radNormale.Enabled = false;
                radAnnPar.Enabled = false;
                radEdit.Enabled = false;
            }
        }

		private void FillAnnullo() 
		{
			if (Meta.IsEmpty) 
			{
				return;
			}
			DataRow R= DS.incomevar.Rows[0];
            int currauto = CfgFn.GetNoNullInt32(R["autokind"]);

            if (currauto == 11) //ANNUL
                radAnnullo.Checked = true;
            else
                radAnnullo.Checked = false;
            if (currauto == 10)  //ANPAR
                radAnnPar.Checked = true;
            else
                radAnnPar.Checked = false;
            if (currauto == 22)  //EDIT
                radEdit.Checked = true;
            else
                radEdit.Checked = false;
            if (currauto == 0)
                radNormale.Checked = true;
            else
                radNormale.Checked = false;
        }

		private void GetAnnullo()
		{
			if (Meta.IsEmpty) return;
			if (radAnnPar.Enabled==false) return;
			if (radNormale.Enabled==false) return;
			DataRow R= DS.incomevar.Rows[0];
            int currauto = CfgFn.GetNoNullInt32(R["autokind"]);
            if (radNormale.Checked) {
                if (currauto != 0) R["autokind"] = DBNull.Value;
            }
            if (radAnnPar.Checked) {
                if (currauto != 10) R["autokind"] = 10;  //ANPAR
            }
            if (radEdit.Checked)
            {
                if (currauto != 22) R["autokind"] = 22;  //EDIT
            }
        }

		private void DoChooseCommand(Control sender){			
			string mycommand=command;
			string filter1=Meta.myHelpForm.GetSpecificCondition(grpMovimento.Controls, "incomeview");
			string filter2="";
			if (m_DocIVA) filter2=GetCredDebFilter("E");
			filter1=GetData.MergeFilters(filter1, filter2);
		    filter1 = QHS.AppAnd(filter1, filteresercizio);
			if (filter1!="") mycommand+="."+filter1;
			if (!MetaData.Choose(this,mycommand)) {
				if (sender!=null) sender.Focus();
			}
		}

		private void DoChooseCommandWithoutFilter(){			
			string mycommand=command;
			string filter="";
            if (cmbFase.Text != "") filter = QHS.CmpEq("nphase", cmbFase.SelectedValue);
            if (m_DocIVA) filter = QHS.AppAnd(filter, GetCredDebFilter("E"));
			string esercentrata = txtEsercEntrata.Text.Trim();
            if (esercentrata != "") filter = QHS.AppAnd(filter, QHS.CmpEq("ymov", esercentrata));
		    filter = QHS.AppAnd(filter, filteresercizio);
			if (filter!="") mycommand+="."+filter;
			MetaData.Choose(this,mycommand);
		}

		private void ClearEntrata(bool ClearEsercizio){
			txtNumEntrata.Text="";
			if (ClearEsercizio) txtEsercEntrata.Text="";
			if (Meta.IsEmpty) return;
			if (!Meta.InsertMode) return; //idinc can be changed only on insert!
            DS.incomevar.Rows[0]["idinc"] =0;
			DS.incomevar.Rows[0]["nvar"]=9999;
			
            DS.incomeview.Clear();
			DS.incomesorted.Clear();
			DS.creditpart.Clear();
			DS.proceedspart.Clear();
			DrawGridTipoClass();

		}

		private void btnAccertamento_Click(object sender, System.EventArgs e) {
			DoChooseCommandWithoutFilter();		
		}

		private void txtEsercEntrata_Leave(object sender, System.EventArgs e) {
			if (Meta.EditMode) return;

			string esercentrata=txtEsercEntrata.Text.Trim();
			if (esercentrata==""){
				MetaData.Choose(this, "choose.incomeview.unknown.clear");
				return;
			}
			
			//if txtEsercEntrata is not Empty:
			if (Meta.IsEmpty) return;
				
			if(DS.incomeview.Rows.Count>0 ){
				if (esercentrata== DS.incomeview.Rows[0]["ymov"].ToString())
					return;
				else{
					ClearEntrata(false);
					return;
				}	
			}		
		}

		private void txtNumEntrata_Leave(object sender, System.EventArgs e) {
			if (Meta.EditMode) return;
			if (txtNumEntrata.Text.Trim()!=""){
				DoChooseCommand((Control)sender);
				return;
			}
			//if txtNumentrata is empty:
			if (Meta.IsEmpty) return;
			ClearEntrata(false);	
		}
		private void EnableTipoMovimento(int IDtipo, string descrtipo){
			DataRow R = DS.tipomovimento.NewRow();
			R["idtipo"]= IDtipo;
			R["descrizione"]= descrtipo;
			DS.tipomovimento.Rows.Add(R);
			DS.tipomovimento.AcceptChanges();
			HelpForm.SetComboBoxValue(S1ubEntity_cmbCausale, IDtipo);
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
		/// <param name="R">riga di documentoivaoperativo</param>
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
                (EnableDocum &&
				(assigned_imponibile_dociva+assigned_iva_dociva)==0) && 
				(assigned_gen_dociva< (totimponibile_dociva+totiva_dociva))
				){
				EnableTipoMovimento(1,"Contabilizzazione importo totale documento");
			}

			if ((Meta.EditMode) ||
                (EnableImpon &&  (assigned_gen_dociva == 0) && (assigned_imponibile_dociva < totimponibile_dociva))
				){
				EnableTipoMovimento(3,"Contabilizzazione imponibile documento");
			}

			if ( (Meta.EditMode) ||
                (EnableImpos &&  (assigned_gen_dociva == 0) && (assigned_iva_dociva < totiva_dociva))
				){
				EnableTipoMovimento(2,"Contabilizzazione iva documento");
			}
            if (DS.incomevar.Rows.Count != 0) {
                DS.incomevar.Rows[0]["movkind"] = (S1ubEntity_cmbCausale.SelectedValue != null)
                        ? S1ubEntity_cmbCausale.SelectedValue : DBNull.Value;
            }
            S1ubEntity_cmbCausale.Enabled = !(Meta.EditMode);
			ReCalcImporto_Iva();
		}

		private void ReCalcImporto_Iva() {
			if (!Meta.DrawStateIsDone) return;
			if (Meta.IsEmpty) return;
			if (S1ubEntity_cmbCausale.SelectedValue==null) return;
			int tipomovimento = CfgFn.GetNoNullInt32( S1ubEntity_cmbCausale.SelectedValue);
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
		/// <summary>
		/// Imposta l'importo "esercizio"
		/// </summary>
		private void SetImporto(decimal valore){
			DS.incomevar.Rows[0]["amount"]= valore;
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
                 QHS.AppAnd(QHS.CmpEq("idinvkind", R["idinvkind"]), QHS.CmpEq("yinv", R["yinv"]), QHS.CmpEq("ninv", R["ninv"]));
            filtro = QHS.AppAnd(filtro, QHS.CmpGt("residual", 0));
            DataTable tResiduo = DataAccess.RUN_SELECT(Meta.Conn, "invoiceresidual", "*", null, filtro, null, null, true);
			return (tResiduo != null && tResiduo.Rows.Count > 0) ? tResiduo.Rows[0] : null;
		}

		private DataRow DoChooseCommandDocumento(Control sender){			
			string mycommand=docoper_command;
			string filter= "";//Meta.myHelpForm.GetSpecificCondition(grpDocumento.Controls, "invoiceavailable");
			if (S1ubEntity_txtEsercizio.Text.Trim()!=""){
				int esercizio= CfgFn.GetNoNullInt32(
					HelpForm.GetObjectFromString(typeof(int),S1ubEntity_txtEsercizio.Text,"x.y.year"));
                filter = QHS.CmpEq("yinv", esercizio);
			}
			if (S1ubEntity_cmbTipoDoc.SelectedIndex>0){
                object code = S1ubEntity_cmbTipoDoc.SelectedValue;
                filter = QHS.AppAnd(filter, QHS.CmpEq("idinvkind", code));
            }
			if (sender== S1ubEntity_txtNumero){
				int num= CfgFn.GetNoNullInt32(
					HelpForm.GetObjectFromString(typeof(int),S1ubEntity_txtNumero.Text,"x.y"));
                filter = QHS.AppAnd(filter, QHS.CmpEq("ninv", num));
			}

			filter=GetData.MergeFilters(filter,GetCredDebFilter("D"));
			if (Meta.InsertMode) {
                filter = QHS.AppAnd(filter, QHS.CmpGt("residual", 0), QHS.NullOrEq("active", 'S'));
            }
			if (filter!="") mycommand+= "."+filter;
            string fStatico = QHS.AppAnd(QHS.BitSet("flag", 0), QHS.BitSet("flag", 2));
            filter = GetData.MergeFilters(filter, fStatico);
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
		/// <param name="FlagRichiedente">D per documentoivaoperativo, E per entrataview</param>
		private void SetCredDebFilter(DataRow R, string FlagRichiedente) {
			if (FlagRichiedente.ToUpper()=="D") {
				m_CodiceCredDebD=(R==null?null:R["idreg"]);
			}
			if (FlagRichiedente.ToUpper()=="E") {
				m_CodiceCredDebE=(R==null?null:R["idreg"]);
			}
		}

		/// <param name="FlagRichiedente">D per documentoivaoperativo, E per entrataview</param>
		private string GetCredDebFilter(string FlagRichiedente) {
			object cred=null;
			if (FlagRichiedente=="D") 
				cred=m_CodiceCredDebE;
			else
				cred=m_CodiceCredDebD;
			if (cred==null || cred.ToString()=="") return "";
            return QHS.CmpEq("idreg", cred);
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
				}
				else {
					grpMovimento.Enabled = true;
					DS.invoicedetail_iva.Clear();
					DS.invoicedetail_taxable.Clear();
					ScollegaIva(true);
					ResetIva();
				}
			}
		}

		private void EnableDisableCheckDocIVA(int currPhase){
            int maxPhase = CfgFn.GetNoNullInt32(Meta.GetSys("maxincomephase"));
            bool abilita = ((Meta.InsertMode && DS.incomeview.Rows.Count > 0) || Meta.IsEmpty)
            && (currPhase == maxPhase);
			chkDocIVA.Enabled=abilita;
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
			if (DS.incomevar.Rows.Count == 0) return;
			Meta.GetFormData(true);
			if (DS.incomeview.Rows.Count == 0) return;
			DataRow CurrExp = DS.incomeview.Rows[0];
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

			DS.incomesorted.ExtendedProperties[MetaData.ExtraParams]= ClassMovAllowed;
			DS.incomesorted.ExtendedProperties["importoresiduo"]= Convert.ToDecimal(0);

            MetaIncSorted.SetDefaults(DS.incomesorted);
			DataRow Added = MetaData.Insert_Grid(DGridDettagliClassificazioni, "default");
			if (Added==null) return;

			Meta.FreshForm(true);
		}
		

		private void btnEditClass_Click(object sender, System.EventArgs e) {
			if (Meta.IsEmpty) return;
			if (DS.incomeview.Rows.Count == 0) return;
			if (DS.incomevar.Rows.Count==0) return;
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
			DS.incomesorted.ExtendedProperties[MetaData.ExtraParams]= ClassMovAllowed;
			DataRow Modified = MetaData.Edit_Grid(DGridDettagliClassificazioni, "default");
			if (Modified==null) return;

			Meta.FreshForm(true);
		}

		private void btnDelClass_Click(object sender, System.EventArgs e) {
			if (Meta.IsEmpty) return;
			if (DS.incomevar.Rows.Count == 0) return;
			Meta.GetFormData(true);
			DataRow Curr = DS.incomevar.Rows[0];
			
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
				DS.incomesorted.Columns["idsubclass"], 
				null,
				null,
				7,
				false);
            //RowChange.SetSelector(DS.incomesorted, "idsorkind");
			RowChange.SetSelector(DS.incomesorted, "idsor");
			RowChange.SetSelector(DS.incomesorted, "idinc");
		}

		public void CalcImpClassMovDefaults(decimal ImportoPerClassificazione) {
			DataTable T;
			DataRow Curr;
			bool res = Meta.myHelpForm.GetCurrentRow(DGridClassificazioni, 
				out T, out Curr);
			if (Curr==null)return;

            //DS.incomesorted.Columns["idsorkind"].DefaultValue = Curr["idsorkind"];

			AbilitaSubMovimenti();
			DataRow CurrMov = DS.incomevar.Rows[0];

			decimal importoclassificato = CfgFn.GetNoNullDecimal(DS.incomesorted.Compute("SUM(amount)",
                QHC.FieldIn("idsor", DS.sorting.Select(QHC.CmpEq("idsorkind", Curr["idsorkind"])))));
			
			decimal importototale  = ImportoPerClassificazione;
			decimal importoresiduo = importototale - importoclassificato;

			if (Curr["totalexpression"].ToString()=="")
				DS.incomesorted.Columns["amount"].DefaultValue = importoresiduo;
			else 
				DS.incomesorted.Columns["amount"].DefaultValue = 0;

			DS.incomesorted.ExtendedProperties["importoresiduo"]= importoresiduo;
			DS.incomesorted.ExtendedProperties["importototale"]= importototale;
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
			DS.incomesorted.ExtendedProperties["TotaleImporto"]= importoperclassificazione;
			GetData.CalculateTable(DS.incomesorted);
			DGridDettagliClassificazioni.TableStyles.Clear();
			HelpForm.SetGridStyle(DGridDettagliClassificazioni, DS.incomesorted);
			if (DGridDettagliClassificazioni.DataSource==null) return;
			formatgrids format = new formatgrids(DGridDettagliClassificazioni);
			format.AutosizeColumnWidth();	
			HelpForm.SetDataGrid(DGridDettagliClassificazioni, DS.incomesorted);
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
                    importoo = DS.incomesorted.Compute(expression, filterMovSor);
				}
				catch {
				}
				importo = CfgFn.GetNoNullDecimal(importoo);
				TR["!importo"]=importo;
				TR.AcceptChanges();
			}

		}

		decimal GetImportoPerClassificazione(){
			if (DS.incomevar.Rows.Count==0) return 0;
			if (DS.incomeview.Rows.Count==0) return 0;
			DataRow CurrExp = DS.incomeview.Rows[0];
			decimal importoinc = CfgFn.GetNoNullDecimal(CurrExp["curramount"]);
			DataRow CurrVar = DS.incomevar.Rows[0];
			decimal importovar = CfgFn.GetNoNullDecimal(CurrVar["amount",DataRowVersion.Default]);
			if ((CurrVar.RowState==DataRowState.Modified)||(CurrVar.RowState==DataRowState.Unchanged)){
				importovar-=CfgFn.GetNoNullDecimal(CurrVar["amount",DataRowVersion.Original]);
			}
			decimal importo= importoinc+importovar;
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
			CurrCausaleIva=0;
            if (DS.incomevar.Rows.Count == 0) return 0;
            DataRow Curr = DS.incomevar.Rows[0];
            if (!verificaDocIvaSelezionato()) return 0;

			if (!Meta.DrawStateIsDone){
                CurrCausaleIva = (Curr["movkind"] == DBNull.Value) ? 0 : CfgFn.GetNoNullInt32( Curr["movkind"]);
				return CurrCausaleIva;
			}
            CurrCausaleIva = CfgFn.GetNoNullInt32( Curr["movkind"]);
			return CurrCausaleIva;
		}

		private void btnAddDettInvoice_Click(object sender, System.EventArgs e) {
			if (DS.config.Rows.Count==0) return;
            if (DS.incomevar.Rows.Count == 0) return;

            if (!verificaDocIvaSelezionato()) {
                MessageBox.Show(this, "Bisogna selezionare la nota di credito");
                return;
            }

			if (MetaData.Empty(this)) return;
			MetaData.GetFormData(this,true);
			CurrCausaleIva= GetCausaleIva();
			string MyFilter = CalculateFilterForInvoiceDetailLinking(true);
			string tablename="";
			if (CurrCausaleIva==1||CurrCausaleIva==3){
				tablename="invoicedetail_taxable";
			}
			if (CurrCausaleIva==2){
				tablename="invoicedetail_iva";
			}

			string command = "choose."+tablename+".listaentrata." + MyFilter;
			if (!MetaData.Choose(this,command))return;
			if (CurrCausaleIva==1){
				foreach(DataRow R in DS.invoicedetail_taxable.Rows){
					R["idinc_iva"]=R["idinc_taxable"];
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
				ToConsider= DS.invoicedetail_taxable.Select(QHC.IsNotNull("idinc_taxable"));
			}
			if (CurrCausaleIva==2){
                ToConsider = DS.invoicedetail_iva.Select(QHC.IsNotNull("idinc_iva"));
			}
			if (CurrCausaleIva==1){
                ToConsider = DS.invoicedetail_taxable.Select(QHC.IsNotNull("idinc_taxable"));
            }

			foreach (DataRow R in ToConsider){
				if (R.RowState== DataRowState.Deleted) continue;
				decimal R_imponibile = CfgFn.GetNoNullDecimal(R["taxable"]);
				decimal R_quantita = CfgFn.GetNoNullDecimal(R["number"]);
				decimal R_imposta  = CfgFn.GetNoNullDecimal(R["tax"]);
				decimal R_sconto   = CfgFn.Round(CfgFn.GetNoNullDecimal(R["discount"]),6);
				imponibile +=  CfgFn.RoundValuta((R_imponibile*R_quantita *(1-R_sconto))*tassocambio) ;
				imposta    +=  CfgFn.RoundValuta(R_imposta*tassocambio);
			}

			decimal totale=0;

			if (CurrCausaleIva==3){
				totale= imponibile;
			}
			if (CurrCausaleIva==2){
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

			if (DS.incomeview.Rows.Count > 0) {
				idupb = DS.incomeview.Rows[0]["idupb"];
			}

            if (DS.incomevar.Rows.Count == 0) return "";
            if (!verificaDocIvaSelezionato()) return "";
            DataRow Curr = DS.incomevar.Rows[0];

            QueryHelper QH = SQL ? QHS : QHC;
            MyFilter = QH.AppAnd(
                QH.CmpEq("idinvkind", Curr["idinvkind"]),
                QH.CmpEq("yinv", Curr["yinv"]),
                QH.CmpEq("ninv", Curr["ninv"]));


            //if (idupb!=DBNull.Value)
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
                MyFilter = QH.AppAnd(MyFilter, QH.IsNull("idinc_iva"), QH.IsNull("idinc_taxable"));
            }
            if (CurrCausaleIva == 2) {
                MyFilter = QH.AppAnd(MyFilter, QH.IsNull("idinc_iva"));
            }
            if (CurrCausaleIva == 3) {
                MyFilter = QH.AppAnd(MyFilter, QH.IsNull("idinc_taxable"));
            }


			return MyFilter;
		}

        /// <summary>
        /// Metodo che verifica se la nota di credito Ë stata selezionata
        /// </summary>
        /// <returns></returns>
        private bool verificaDocIvaSelezionato() {
            if (DS.incomevar.Rows.Count == 0) return false;

            DataRow Curr = DS.incomevar.Rows[0];
            if ((Curr["idinvkind"] == DBNull.Value) ||
                (Curr["yinv"] == DBNull.Value) ||
                (Curr["ninv"] == DBNull.Value)) {
                return false;
            }
            return true;
        }

		private void btnRemoveDettInvoice_Click(object sender, System.EventArgs e) {
			if (Meta.IsEmpty) return;
			Meta.GetFormData(true);
            if (DS.incomevar.Rows.Count == 0) return;
            if (!verificaDocIvaSelezionato()) {
                MessageBox.Show(this, "Bisogna selezionare la nota di credito");
                return;
            }
			MetaData.Unlink_Grid(dgrDettagliFattura);
			if (CurrCausaleIva==1){
				foreach(DataRow R in DS.invoicedetail_taxable.Rows){
					R["idinc_iva"]=R["idinc_taxable"];
				};
			}
			CalcolaImportoInBaseADettagliFattura();
		}

		private void btnEditInvDet_Click(object sender, System.EventArgs e) {
			if (Meta.IsEmpty) return;
			Meta.GetFormData(true);

            if (DS.incomevar.Rows.Count == 0) return;
            DataRow Curr = DS.incomevar.Rows[0];
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
				ToLink, MyFilter, MyFilterSQL, "listaentrata"); 
			if (CurrCausaleIva==1){
				foreach(DataRow R in DS.invoicedetail_taxable.Rows){
					R["idinc_iva"]=R["idinc_taxable"];
				};
			}

			CalcolaImportoInBaseADettagliFattura();
		}

		void CollegaTuttiDettagliFattura(){
			CurrCausaleIva = GetCausaleIva();
			string filter = CalculateFilterForInvoiceDetailLinking(true);
			DS.invoicedetail_iva.Clear();
			DS.invoicedetail_taxable.Clear();
			object idinc=DS.incomevar.Rows[0]["idinc"];
			// JTR 29.11.2006 - Se l'idinc Ë vuoto non fare nulla (questo accade quando non ho ancora scelto un movimento di entrata al 
			// quale associare la variazione)
			if (idinc == DBNull.Value) return;
			if (CurrCausaleIva == 0) return;
			if (CurrCausaleIva==1){
				Meta.Conn.RUN_SELECT_INTO_TABLE(DS.invoicedetail_taxable,null,filter,null,true);
				foreach(DataRow R in DS.invoicedetail_taxable.Rows){
					R["idinc_taxable"]=idinc;
					R["idinc_iva"]=idinc;
				}
				GetData.CalculateTable(DS.invoicedetail_taxable);
				Meta.MarkTableAsNotEntityChild(DS.invoicedetail_taxable);
			}
			if (CurrCausaleIva==3){
				Meta.Conn.RUN_SELECT_INTO_TABLE(DS.invoicedetail_taxable,null,filter,null,true);
                foreach (DataRow R in DS.invoicedetail_taxable.Rows) {
					R["idinc_taxable"]=idinc;
				}
				GetData.CalculateTable(DS.invoicedetail_taxable);
				Meta.MarkTableAsNotEntityChild(DS.invoicedetail_taxable);
			}
			if (CurrCausaleIva==2){
				Meta.Conn.RUN_SELECT_INTO_TABLE(DS.invoicedetail_iva,null,filter,null,true);
                foreach (DataRow R in DS.invoicedetail_iva.Rows) {
					R["idinc_iva"]=idinc;
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
            if(DS.config.Rows.Count == 0) return;
			if (!IvaLinkedMustBeEvalued)return;
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
			int faseattivazione){
			if (Meta.IsEmpty) return null;
			if (DS.incomevar.Rows.Count == 0) return null;
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
			CurrCausaleIva = 0;
            IvaRow = null;
            if (DS.incomevar.Rows.Count == 0) return;
            DataRow MiddleRow = DS.incomevar.Rows[0];
			int faseiva = Convert.ToInt32(m_CodiceFaseCont);
            IvaRow = GetDocRow("invoice", "incomevar", faseiva);
			if (IvaRow==null)return;
			if (MiddleRow!=null) CurrCausaleIva= CfgFn.GetNoNullInt32( MiddleRow["movkind"]);
		}

		bool faseMaxInclusa(){
			if ((cmbFase.SelectedValue == null) || (cmbFase.SelectedValue == DBNull.Value)) return false;
			int currphase = CfgFn.GetNoNullInt32(cmbFase.SelectedValue);

			return (faseentratamax==currphase);
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
			DataRow CurrRow= DS.incomevar.Rows[0];

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

			DataRow CurrRow= DS.incomevar.Rows[0];

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

        private void label10_Click(object sender, EventArgs e) {

        }

	}
}
