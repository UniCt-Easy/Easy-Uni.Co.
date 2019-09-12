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
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using metadatalibrary;
using metaeasylibrary;
using System.Data;
using funzioni_configurazione;
using movimentofunctions;
using System.Globalization;
using AskInfo;

namespace income_wizardestimatedetail {
    /// <summary>
    /// Summary description for FrmWizardEstimateDetail.
    /// </summary>
    public class FrmWizardEstimateDetail : System.Windows.Forms.Form {
        private Crownwood.Magic.Controls.TabControl tabController;
        private Crownwood.Magic.Controls.TabPage tabIntro;
        private System.Windows.Forms.Label label1;

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private Crownwood.Magic.Controls.TabPage tabSelMov;
        private System.Windows.Forms.GroupBox groupBox20;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtDataCont;
        private System.Windows.Forms.TextBox txtScadenza;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.GroupBox groupBox18;
        private System.Windows.Forms.TextBox SubEntity_txtImportoMovimento;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.GroupBox groupBox17;
        private System.Windows.Forms.TextBox txtDescrizione;
        private System.Windows.Forms.GroupBox gboxBilAnnuale;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtCodiceBilancio;
        private System.Windows.Forms.TextBox txtDenominazioneBilancio;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblImportoDisponibile;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtImportoDisponibile;
        private System.Windows.Forms.TextBox txtImportoCorrente;
        private System.Windows.Forms.GroupBox gboxMovimento;
        private System.Windows.Forms.Button btnSelectMov;
        private System.Windows.Forms.TextBox txtNumeroMovimento;
        private System.Windows.Forms.Label labNum;
        private System.Windows.Forms.TextBox txtEsercizioMovimento;
        private System.Windows.Forms.Label labEserc;
        private Crownwood.Magic.Controls.TabPage tabSelDetail;
        private System.Windows.Forms.Button btnDocumento;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtNumDoc;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtEsercDoc;
        private System.Windows.Forms.ComboBox cmbCausale;
        private System.Windows.Forms.Label labelCausale;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtTotImponibile;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtTotIva;
        private System.Windows.Forms.TextBox txtTotGenerale;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Button btnSelectAllDetail;
        private System.Windows.Forms.RadioButton radioAddCont;
        private System.Windows.Forms.RadioButton radioNewCont;
        private System.Windows.Forms.RadioButton radioNewLinkedMov;
        private System.Windows.Forms.Label labMsgTODO1;
        private System.Windows.Forms.Label labMsgTODO2;
        private Crownwood.Magic.Controls.TabPage tabConfirm;
        MetaData Meta;

        string CustomTitle;
        private System.Windows.Forms.DataGrid gridDetails;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtCliente;
        private System.Windows.Forms.Label labDescrContratto;
        private System.Windows.Forms.TextBox txtDescrContratto;
        private System.Windows.Forms.Label labelMessage;
        private System.Windows.Forms.GroupBox gboxSelMov;
        DataAccess Conn;
        DataSet DSCopy;
        private System.Windows.Forms.GroupBox gboxUPB;
        private System.Windows.Forms.TextBox txtDescrUPB;
        private System.Windows.Forms.Button btnUPBCode;
        private System.Windows.Forms.Label labelAddCont;
        private System.Windows.Forms.Label labelNewLinkedCont;
        private System.Windows.Forms.GroupBox gboxBilToCreate;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtCodeBilSelected;
        private System.Windows.Forms.TextBox txtDenomBilSelected;
        private System.Windows.Forms.ComboBox cmbTipoContratto;
        decimal TotaleDaContabilizzare = 0;
        public income_wizardestimatedetail.vistaForm DS;
        int fasecontratto;
        bool genMultipla = true;
        private System.Windows.Forms.CheckBox chkAddContab;
        private Crownwood.Magic.Controls.TabPage tabSplit;
        private GroupBox groupBox3;
        private Label lblCausale;
        private TextBox txtTotSelezionato;
        private Label label19;
        private RadioButton rdbSplittaUno;
        private RadioButton rdbSplittaTutti;
        private Label label23;
        private Label label22;
        private TextBox txtPerc;
        private Label label17;
        private TextBox txtDaIncassare;
        bool SalvataggioEnabled = true;
        ArrayList DetailsToUpdate;
        CQueryHelper QHC;
        private GroupBox groupBox4;
        private TextBox txtResponsabile;
        private GroupBox groupBox5;
        private TextBox txtResponsabileContratto;
        private TextBox txtUPB;
        private Panel panel1;
        QueryHelper QHS;

        public FrmWizardEstimateDetail() {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();


            tabController.HideTabsMode =
                Crownwood.Magic.Controls.TabControl.HideTabsModes.HideAlways;
        }

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
            this.tabController = new Crownwood.Magic.Controls.TabControl();
            this.tabSelDetail = new Crownwood.Magic.Controls.TabPage();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.txtResponsabileContratto = new System.Windows.Forms.TextBox();
            this.cmbTipoContratto = new System.Windows.Forms.ComboBox();
            this.DS = new income_wizardestimatedetail.vistaForm();
            this.txtDescrContratto = new System.Windows.Forms.TextBox();
            this.labDescrContratto = new System.Windows.Forms.Label();
            this.txtCliente = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.chkAddContab = new System.Windows.Forms.CheckBox();
            this.btnSelectAllDetail = new System.Windows.Forms.Button();
            this.label18 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtTotGenerale = new System.Windows.Forms.TextBox();
            this.txtTotIva = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTotImponibile = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.gridDetails = new System.Windows.Forms.DataGrid();
            this.cmbCausale = new System.Windows.Forms.ComboBox();
            this.labelCausale = new System.Windows.Forms.Label();
            this.btnDocumento = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.txtNumDoc = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtEsercDoc = new System.Windows.Forms.TextBox();
            this.tabIntro = new Crownwood.Magic.Controls.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabSplit = new Crownwood.Magic.Controls.TabPage();
            this.label23 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.txtPerc = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.txtDaIncassare = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lblCausale = new System.Windows.Forms.Label();
            this.txtTotSelezionato = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.rdbSplittaUno = new System.Windows.Forms.RadioButton();
            this.rdbSplittaTutti = new System.Windows.Forms.RadioButton();
            this.tabSelMov = new Crownwood.Magic.Controls.TabPage();
            this.labelNewLinkedCont = new System.Windows.Forms.Label();
            this.labelAddCont = new System.Windows.Forms.Label();
            this.gboxSelMov = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtResponsabile = new System.Windows.Forms.TextBox();
            this.gboxUPB = new System.Windows.Forms.GroupBox();
            this.txtUPB = new System.Windows.Forms.TextBox();
            this.txtDescrUPB = new System.Windows.Forms.TextBox();
            this.btnUPBCode = new System.Windows.Forms.Button();
            this.gboxMovimento = new System.Windows.Forms.GroupBox();
            this.btnSelectMov = new System.Windows.Forms.Button();
            this.txtNumeroMovimento = new System.Windows.Forms.TextBox();
            this.labNum = new System.Windows.Forms.Label();
            this.txtEsercizioMovimento = new System.Windows.Forms.TextBox();
            this.labEserc = new System.Windows.Forms.Label();
            this.groupBox17 = new System.Windows.Forms.GroupBox();
            this.txtDescrizione = new System.Windows.Forms.TextBox();
            this.gboxBilAnnuale = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtCodiceBilancio = new System.Windows.Forms.TextBox();
            this.txtDenominazioneBilancio = new System.Windows.Forms.TextBox();
            this.groupBox20 = new System.Windows.Forms.GroupBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtDataCont = new System.Windows.Forms.TextBox();
            this.txtScadenza = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.groupBox18 = new System.Windows.Forms.GroupBox();
            this.SubEntity_txtImportoMovimento = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblImportoDisponibile = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtImportoDisponibile = new System.Windows.Forms.TextBox();
            this.txtImportoCorrente = new System.Windows.Forms.TextBox();
            this.radioNewLinkedMov = new System.Windows.Forms.RadioButton();
            this.radioNewCont = new System.Windows.Forms.RadioButton();
            this.radioAddCont = new System.Windows.Forms.RadioButton();
            this.labelMessage = new System.Windows.Forms.Label();
            this.tabConfirm = new Crownwood.Magic.Controls.TabPage();
            this.gboxBilToCreate = new System.Windows.Forms.GroupBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtCodeBilSelected = new System.Windows.Forms.TextBox();
            this.txtDenomBilSelected = new System.Windows.Forms.TextBox();
            this.labMsgTODO2 = new System.Windows.Forms.Label();
            this.labMsgTODO1 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tabController.SuspendLayout();
            this.tabSelDetail.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize) (this.DS)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize) (this.gridDetails)).BeginInit();
            this.tabIntro.SuspendLayout();
            this.tabSplit.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tabSelMov.SuspendLayout();
            this.gboxSelMov.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.gboxUPB.SuspendLayout();
            this.gboxMovimento.SuspendLayout();
            this.groupBox17.SuspendLayout();
            this.gboxBilAnnuale.SuspendLayout();
            this.groupBox20.SuspendLayout();
            this.groupBox18.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabConfirm.SuspendLayout();
            this.gboxBilToCreate.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabController
            // 
            this.tabController.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabController.IDEPixelArea = true;
            this.tabController.Location = new System.Drawing.Point(0, 0);
            this.tabController.Name = "tabController";
            this.tabController.SelectedIndex = 0;
            this.tabController.SelectedTab = this.tabIntro;
            this.tabController.Size = new System.Drawing.Size(791, 536);
            this.tabController.TabIndex = 0;
            this.tabController.TabPages.AddRange(new Crownwood.Magic.Controls.TabPage[] {
                this.tabIntro,
                this.tabSelDetail,
                this.tabSplit,
                this.tabSelMov,
                this.tabConfirm
            });
            this.tabController.SelectionChanged += new System.EventHandler(this.tabController_SelectionChanged);
            // 
            // tabSelDetail
            // 
            this.tabSelDetail.Controls.Add(this.groupBox5);
            this.tabSelDetail.Controls.Add(this.cmbTipoContratto);
            this.tabSelDetail.Controls.Add(this.txtDescrContratto);
            this.tabSelDetail.Controls.Add(this.labDescrContratto);
            this.tabSelDetail.Controls.Add(this.txtCliente);
            this.tabSelDetail.Controls.Add(this.label6);
            this.tabSelDetail.Controls.Add(this.chkAddContab);
            this.tabSelDetail.Controls.Add(this.btnSelectAllDetail);
            this.tabSelDetail.Controls.Add(this.label18);
            this.tabSelDetail.Controls.Add(this.groupBox2);
            this.tabSelDetail.Controls.Add(this.gridDetails);
            this.tabSelDetail.Controls.Add(this.cmbCausale);
            this.tabSelDetail.Controls.Add(this.labelCausale);
            this.tabSelDetail.Controls.Add(this.btnDocumento);
            this.tabSelDetail.Controls.Add(this.label7);
            this.tabSelDetail.Controls.Add(this.txtNumDoc);
            this.tabSelDetail.Controls.Add(this.label10);
            this.tabSelDetail.Controls.Add(this.txtEsercDoc);
            this.tabSelDetail.Location = new System.Drawing.Point(0, 0);
            this.tabSelDetail.Name = "tabSelDetail";
            this.tabSelDetail.Selected = false;
            this.tabSelDetail.Size = new System.Drawing.Size(791, 511);
            this.tabSelDetail.TabIndex = 5;
            this.tabSelDetail.Title = "Pagina 2 di 5";
            // 
            // groupBox5
            // 
            this.groupBox5.Anchor =
                ((System.Windows.Forms.AnchorStyles)
                    (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                      | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox5.Controls.Add(this.txtResponsabileContratto);
            this.groupBox5.Location = new System.Drawing.Point(450, 82);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(333, 48);
            this.groupBox5.TabIndex = 118;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Responsabile";
            // 
            // txtResponsabileContratto
            // 
            this.txtResponsabileContratto.Anchor =
                ((System.Windows.Forms.AnchorStyles)
                    (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                      | System.Windows.Forms.AnchorStyles.Right)));
            this.txtResponsabileContratto.Location = new System.Drawing.Point(8, 16);
            this.txtResponsabileContratto.Multiline = true;
            this.txtResponsabileContratto.Name = "txtResponsabileContratto";
            this.txtResponsabileContratto.ReadOnly = true;
            this.txtResponsabileContratto.Size = new System.Drawing.Size(319, 26);
            this.txtResponsabileContratto.TabIndex = 1;
            this.txtResponsabileContratto.Tag = "";
            // 
            // cmbTipoContratto
            // 
            this.cmbTipoContratto.DataSource = this.DS.estimatekind;
            this.cmbTipoContratto.DisplayMember = "description";
            this.cmbTipoContratto.Location = new System.Drawing.Point(120, 8);
            this.cmbTipoContratto.Name = "cmbTipoContratto";
            this.cmbTipoContratto.Size = new System.Drawing.Size(256, 23);
            this.cmbTipoContratto.TabIndex = 116;
            this.cmbTipoContratto.ValueMember = "idestimkind";
            this.cmbTipoContratto.SelectedIndexChanged +=
                new System.EventHandler(this.cmbTipoContratto_SelectedIndexChanged);
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.EnforceConstraints = false;
            // 
            // txtDescrContratto
            // 
            this.txtDescrContratto.Location = new System.Drawing.Point(96, 88);
            this.txtDescrContratto.Multiline = true;
            this.txtDescrContratto.Name = "txtDescrContratto";
            this.txtDescrContratto.ReadOnly = true;
            this.txtDescrContratto.Size = new System.Drawing.Size(348, 40);
            this.txtDescrContratto.TabIndex = 115;
            // 
            // labDescrContratto
            // 
            this.labDescrContratto.Location = new System.Drawing.Point(8, 88);
            this.labDescrContratto.Name = "labDescrContratto";
            this.labDescrContratto.Size = new System.Drawing.Size(80, 16);
            this.labDescrContratto.TabIndex = 114;
            this.labDescrContratto.Text = "Descrizione";
            this.labDescrContratto.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtCliente
            // 
            this.txtCliente.Anchor =
                ((System.Windows.Forms.AnchorStyles)
                    (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                      | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCliente.Location = new System.Drawing.Point(96, 56);
            this.txtCliente.Name = "txtCliente";
            this.txtCliente.ReadOnly = true;
            this.txtCliente.Size = new System.Drawing.Size(687, 23);
            this.txtCliente.TabIndex = 113;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(8, 56);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 16);
            this.label6.TabIndex = 112;
            this.label6.Text = "Cliente";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chkAddContab
            // 
            this.chkAddContab.Anchor =
                ((System.Windows.Forms.AnchorStyles)
                    (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                      | System.Windows.Forms.AnchorStyles.Right)));
            this.chkAddContab.Location = new System.Drawing.Point(415, 8);
            this.chkAddContab.Name = "chkAddContab";
            this.chkAddContab.Size = new System.Drawing.Size(321, 44);
            this.chkAddContab.TabIndex = 111;
            this.chkAddContab.Text = "Associare i dettagli selezionati ad un movimento finanziario esistente";
            this.chkAddContab.CheckedChanged += new System.EventHandler(this.chkAddContab_CheckedChanged);
            // 
            // btnSelectAllDetail
            // 
            this.btnSelectAllDetail.Anchor =
                ((System.Windows.Forms.AnchorStyles)
                    ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelectAllDetail.Location = new System.Drawing.Point(679, 136);
            this.btnSelectAllDetail.Name = "btnSelectAllDetail";
            this.btnSelectAllDetail.Size = new System.Drawing.Size(96, 23);
            this.btnSelectAllDetail.TabIndex = 110;
            this.btnSelectAllDetail.Text = "Seleziona tutto";
            this.btnSelectAllDetail.Click += new System.EventHandler(this.btnSelectAllDetail_Click);
            // 
            // label18
            // 
            this.label18.Location = new System.Drawing.Point(8, 168);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(704, 32);
            this.label18.TabIndex = 109;
            this.label18.Text = "Selezionare i dettagli da contabilizzare (sono visualizzati solo i dettagli a cui" +
                                " non è associata una data di annullamento)";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor =
                ((System.Windows.Forms.AnchorStyles)
                    (((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                      | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.txtTotGenerale);
            this.groupBox2.Controls.Add(this.txtTotIva);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txtTotImponibile);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Location = new System.Drawing.Point(8, 432);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(775, 72);
            this.groupBox2.TabIndex = 108;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Dettagli selezionati";
            // 
            // txtTotGenerale
            // 
            this.txtTotGenerale.Location = new System.Drawing.Point(296, 40);
            this.txtTotGenerale.Name = "txtTotGenerale";
            this.txtTotGenerale.ReadOnly = true;
            this.txtTotGenerale.Size = new System.Drawing.Size(128, 23);
            this.txtTotGenerale.TabIndex = 109;
            this.txtTotGenerale.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtTotIva
            // 
            this.txtTotIva.Location = new System.Drawing.Point(160, 40);
            this.txtTotIva.Name = "txtTotIva";
            this.txtTotIva.ReadOnly = true;
            this.txtTotIva.Size = new System.Drawing.Size(112, 23);
            this.txtTotIva.TabIndex = 108;
            this.txtTotIva.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtTotIva.Leave += new System.EventHandler(this.txtTotIva_Leave);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(8, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 16);
            this.label4.TabIndex = 104;
            this.label4.Text = "Tot. Imponibile";
            // 
            // txtTotImponibile
            // 
            this.txtTotImponibile.Location = new System.Drawing.Point(8, 40);
            this.txtTotImponibile.Name = "txtTotImponibile";
            this.txtTotImponibile.ReadOnly = true;
            this.txtTotImponibile.Size = new System.Drawing.Size(136, 23);
            this.txtTotImponibile.TabIndex = 107;
            this.txtTotImponibile.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtTotImponibile.Leave += new System.EventHandler(this.txtTotImponibile_Leave);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(160, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 16);
            this.label5.TabIndex = 105;
            this.label5.Text = "Tot. Iva";
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(296, 24);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(100, 16);
            this.label8.TabIndex = 106;
            this.label8.Text = "Totale";
            // 
            // gridDetails
            // 
            this.gridDetails.Anchor =
                ((System.Windows.Forms.AnchorStyles)
                    ((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                       | System.Windows.Forms.AnchorStyles.Left)
                      | System.Windows.Forms.AnchorStyles.Right)));
            this.gridDetails.DataMember = "";
            this.gridDetails.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.gridDetails.Location = new System.Drawing.Point(8, 200);
            this.gridDetails.Name = "gridDetails";
            this.gridDetails.Size = new System.Drawing.Size(775, 232);
            this.gridDetails.TabIndex = 103;
            this.gridDetails.Paint += new System.Windows.Forms.PaintEventHandler(this.gridDetails_Paint);
            // 
            // cmbCausale
            // 
            this.cmbCausale.DataSource = this.DS.tipomovimento;
            this.cmbCausale.DisplayMember = "descrizione";
            this.cmbCausale.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular,
                System.Drawing.GraphicsUnit.World, ((byte) (0)));
            this.cmbCausale.ItemHeight = 13;
            this.cmbCausale.Location = new System.Drawing.Point(96, 136);
            this.cmbCausale.Name = "cmbCausale";
            this.cmbCausale.Size = new System.Drawing.Size(256, 21);
            this.cmbCausale.TabIndex = 102;
            this.cmbCausale.ValueMember = "idtipo";
            this.cmbCausale.SelectedIndexChanged += new System.EventHandler(this.cmbCausale_SelectedIndexChanged);
            // 
            // labelCausale
            // 
            this.labelCausale.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F,
                System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World, ((byte) (0)));
            this.labelCausale.Location = new System.Drawing.Point(40, 136);
            this.labelCausale.Name = "labelCausale";
            this.labelCausale.Size = new System.Drawing.Size(48, 23);
            this.labelCausale.TabIndex = 101;
            this.labelCausale.Text = "Causale";
            this.labelCausale.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnDocumento
            // 
            this.btnDocumento.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F,
                System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.btnDocumento.Location = new System.Drawing.Point(8, 8);
            this.btnDocumento.Name = "btnDocumento";
            this.btnDocumento.Size = new System.Drawing.Size(104, 20);
            this.btnDocumento.TabIndex = 15;
            this.btnDocumento.Text = "Contratto";
            this.btnDocumento.Click += new System.EventHandler(this.btnDocumento_Click);
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular,
                System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.label7.Location = new System.Drawing.Point(176, 32);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(48, 16);
            this.label7.TabIndex = 11;
            this.label7.Text = "Eserc.";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtNumDoc
            // 
            this.txtNumDoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F,
                System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.txtNumDoc.Location = new System.Drawing.Point(312, 32);
            this.txtNumDoc.Name = "txtNumDoc";
            this.txtNumDoc.Size = new System.Drawing.Size(64, 20);
            this.txtNumDoc.TabIndex = 14;
            this.txtNumDoc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtNumDoc.Leave += new System.EventHandler(this.txtNumDoc_Leave);
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular,
                System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.label10.Location = new System.Drawing.Point(280, 32);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(32, 16);
            this.label10.TabIndex = 13;
            this.label10.Text = "Num.";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtEsercDoc
            // 
            this.txtEsercDoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F,
                System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.txtEsercDoc.Location = new System.Drawing.Point(224, 32);
            this.txtEsercDoc.Name = "txtEsercDoc";
            this.txtEsercDoc.Size = new System.Drawing.Size(56, 20);
            this.txtEsercDoc.TabIndex = 12;
            this.txtEsercDoc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtEsercDoc.Leave += new System.EventHandler(this.txtEsercDoc_Leave);
            // 
            // tabIntro
            // 
            this.tabIntro.Controls.Add(this.label3);
            this.tabIntro.Controls.Add(this.label2);
            this.tabIntro.Controls.Add(this.label1);
            this.tabIntro.Location = new System.Drawing.Point(0, 0);
            this.tabIntro.Name = "tabIntro";
            this.tabIntro.Selected = false;
            this.tabIntro.Size = new System.Drawing.Size(791, 511);
            this.tabIntro.TabIndex = 3;
            this.tabIntro.Title = "Pagina 1 di 5";
            // 
            // label3
            // 
            this.label3.Anchor =
                ((System.Windows.Forms.AnchorStyles)
                    (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                      | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.Location = new System.Drawing.Point(8, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(759, 48);
            this.label3.TabIndex = 2;
            this.label3.Text = "Saranno considerati solo i dettagli non ancora associati a movimenti finanziari, " +
                               "inoltre il movimento dovrà avere il  versante uguale al cliente del contratto at" +
                               "tivo o dei dettagli";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(8, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(696, 23);
            this.label2.TabIndex = 1;
            this.label2.Text = "Sarà possibile creare nuovi movimenti oppure associare i dettagli a movimenti già" +
                               " creati.";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(8, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(696, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Questo wizard serve a contabilizzare in finanziario uno o più dettagli di un cont" +
                               "ratto attivo.";
            // 
            // tabSplit
            // 
            this.tabSplit.Controls.Add(this.label23);
            this.tabSplit.Controls.Add(this.label22);
            this.tabSplit.Controls.Add(this.txtPerc);
            this.tabSplit.Controls.Add(this.label17);
            this.tabSplit.Controls.Add(this.txtDaIncassare);
            this.tabSplit.Controls.Add(this.groupBox3);
            this.tabSplit.Location = new System.Drawing.Point(0, 0);
            this.tabSplit.Name = "tabSplit";
            this.tabSplit.Selected = false;
            this.tabSplit.Size = new System.Drawing.Size(791, 511);
            this.tabSplit.TabIndex = 7;
            this.tabSplit.Title = "Page 3 di 5";
            // 
            // label23
            // 
            this.label23.Location = new System.Drawing.Point(345, 171);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(128, 16);
            this.label23.TabIndex = 7;
            this.label23.Text = "Importo";
            this.label23.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label22
            // 
            this.label22.Location = new System.Drawing.Point(276, 171);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(56, 16);
            this.label22.TabIndex = 6;
            this.label22.Text = "%";
            this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtPerc
            // 
            this.txtPerc.Location = new System.Drawing.Point(273, 187);
            this.txtPerc.Name = "txtPerc";
            this.txtPerc.Size = new System.Drawing.Size(64, 23);
            this.txtPerc.TabIndex = 8;
            this.txtPerc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtPerc.Leave += new System.EventHandler(this.txtPerc_Leave);
            // 
            // label17
            // 
            this.label17.Location = new System.Drawing.Point(19, 185);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(224, 23);
            this.label17.TabIndex = 5;
            this.label17.Text = "Inserire il valore che si desidera incassare:";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtDaIncassare
            // 
            this.txtDaIncassare.Location = new System.Drawing.Point(345, 187);
            this.txtDaIncassare.Name = "txtDaIncassare";
            this.txtDaIncassare.Size = new System.Drawing.Size(112, 23);
            this.txtDaIncassare.TabIndex = 9;
            this.txtDaIncassare.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtDaIncassare.Leave += new System.EventHandler(this.txtDaIncassare_Leave);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lblCausale);
            this.groupBox3.Controls.Add(this.txtTotSelezionato);
            this.groupBox3.Controls.Add(this.label19);
            this.groupBox3.Controls.Add(this.rdbSplittaUno);
            this.groupBox3.Controls.Add(this.rdbSplittaTutti);
            this.groupBox3.Location = new System.Drawing.Point(4, 24);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(712, 131);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            // 
            // lblCausale
            // 
            this.lblCausale.AutoSize = true;
            this.lblCausale.Location = new System.Drawing.Point(14, 33);
            this.lblCausale.Name = "lblCausale";
            this.lblCausale.Size = new System.Drawing.Size(48, 15);
            this.lblCausale.TabIndex = 0;
            this.lblCausale.Text = "Causale";
            // 
            // txtTotSelezionato
            // 
            this.txtTotSelezionato.Location = new System.Drawing.Point(555, 26);
            this.txtTotSelezionato.Name = "txtTotSelezionato";
            this.txtTotSelezionato.ReadOnly = true;
            this.txtTotSelezionato.Size = new System.Drawing.Size(130, 23);
            this.txtTotSelezionato.TabIndex = 0;
            this.txtTotSelezionato.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label19
            // 
            this.label19.Anchor =
                ((System.Windows.Forms.AnchorStyles)
                    (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                      | System.Windows.Forms.AnchorStyles.Right)));
            this.label19.Location = new System.Drawing.Point(355, 33);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(193, 13);
            this.label19.TabIndex = 0;
            this.label19.Text = "il totale dei dettagli selezionati è";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // rdbSplittaUno
            // 
            this.rdbSplittaUno.AutoSize = true;
            this.rdbSplittaUno.Checked = true;
            this.rdbSplittaUno.Location = new System.Drawing.Point(17, 69);
            this.rdbSplittaUno.Name = "rdbSplittaUno";
            this.rdbSplittaUno.Size = new System.Drawing.Size(577, 19);
            this.rdbSplittaUno.TabIndex = 1;
            this.rdbSplittaUno.TabStop = true;
            this.rdbSplittaUno.Text =
                "Contabilizza interamente i dettagli fino a coprire l\'importo da incassare. Sarà s" +
                "uddiviso al più un dettaglio";
            this.rdbSplittaUno.UseVisualStyleBackColor = true;
            // 
            // rdbSplittaTutti
            // 
            this.rdbSplittaTutti.AutoSize = true;
            this.rdbSplittaTutti.Location = new System.Drawing.Point(18, 93);
            this.rdbSplittaTutti.Name = "rdbSplittaTutti";
            this.rdbSplittaTutti.Size = new System.Drawing.Size(523, 19);
            this.rdbSplittaTutti.TabIndex = 2;
            this.rdbSplittaTutti.Text =
                "Distribuisci l\'importo da incassare su tutti i dettagli selezionati. Tutti i dett" +
                "agli saranno suddivisi";
            this.rdbSplittaTutti.UseVisualStyleBackColor = true;
            // 
            // tabSelMov
            // 
            this.tabSelMov.Controls.Add(this.labelNewLinkedCont);
            this.tabSelMov.Controls.Add(this.labelAddCont);
            this.tabSelMov.Controls.Add(this.gboxSelMov);
            this.tabSelMov.Controls.Add(this.radioNewLinkedMov);
            this.tabSelMov.Controls.Add(this.radioNewCont);
            this.tabSelMov.Controls.Add(this.radioAddCont);
            this.tabSelMov.Controls.Add(this.labelMessage);
            this.tabSelMov.Location = new System.Drawing.Point(0, 0);
            this.tabSelMov.Name = "tabSelMov";
            this.tabSelMov.Selected = false;
            this.tabSelMov.Size = new System.Drawing.Size(791, 511);
            this.tabSelMov.TabIndex = 4;
            this.tabSelMov.Title = "Pagina 4 di 5";
            // 
            // labelNewLinkedCont
            // 
            this.labelNewLinkedCont.Location = new System.Drawing.Point(5, 415);
            this.labelNewLinkedCont.Name = "labelNewLinkedCont";
            this.labelNewLinkedCont.Size = new System.Drawing.Size(704, 19);
            this.labelNewLinkedCont.TabIndex = 105;
            // 
            // labelAddCont
            // 
            this.labelAddCont.Location = new System.Drawing.Point(5, 441);
            this.labelAddCont.Name = "labelAddCont";
            this.labelAddCont.Size = new System.Drawing.Size(704, 18);
            this.labelAddCont.TabIndex = 104;
            // 
            // gboxSelMov
            // 
            this.gboxSelMov.Controls.Add(this.groupBox4);
            this.gboxSelMov.Controls.Add(this.gboxUPB);
            this.gboxSelMov.Controls.Add(this.gboxMovimento);
            this.gboxSelMov.Controls.Add(this.groupBox17);
            this.gboxSelMov.Controls.Add(this.gboxBilAnnuale);
            this.gboxSelMov.Controls.Add(this.groupBox20);
            this.gboxSelMov.Controls.Add(this.groupBox18);
            this.gboxSelMov.Controls.Add(this.groupBox1);
            this.gboxSelMov.Location = new System.Drawing.Point(8, 72);
            this.gboxSelMov.Name = "gboxSelMov";
            this.gboxSelMov.Size = new System.Drawing.Size(740, 321);
            this.gboxSelMov.TabIndex = 103;
            this.gboxSelMov.TabStop = false;
            this.gboxSelMov.Text = "Selezione del movimento di entrata";
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor =
                ((System.Windows.Forms.AnchorStyles)
                    (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                      | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.txtResponsabile);
            this.groupBox4.Location = new System.Drawing.Point(353, 119);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(381, 43);
            this.groupBox4.TabIndex = 100;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Responsabile";
            // 
            // txtResponsabile
            // 
            this.txtResponsabile.Anchor =
                ((System.Windows.Forms.AnchorStyles)
                    (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                      | System.Windows.Forms.AnchorStyles.Right)));
            this.txtResponsabile.Location = new System.Drawing.Point(8, 16);
            this.txtResponsabile.Multiline = true;
            this.txtResponsabile.Name = "txtResponsabile";
            this.txtResponsabile.ReadOnly = true;
            this.txtResponsabile.Size = new System.Drawing.Size(367, 20);
            this.txtResponsabile.TabIndex = 1;
            this.txtResponsabile.Tag = "";
            // 
            // gboxUPB
            // 
            this.gboxUPB.Controls.Add(this.txtUPB);
            this.gboxUPB.Controls.Add(this.txtDescrUPB);
            this.gboxUPB.Controls.Add(this.btnUPBCode);
            this.gboxUPB.Location = new System.Drawing.Point(8, 111);
            this.gboxUPB.Name = "gboxUPB";
            this.gboxUPB.Size = new System.Drawing.Size(336, 99);
            this.gboxUPB.TabIndex = 98;
            this.gboxUPB.TabStop = false;
            this.gboxUPB.Tag = "";
            // 
            // txtUPB
            // 
            this.txtUPB.Location = new System.Drawing.Point(6, 71);
            this.txtUPB.Name = "txtUPB";
            this.txtUPB.ReadOnly = true;
            this.txtUPB.Size = new System.Drawing.Size(324, 23);
            this.txtUPB.TabIndex = 5;
            this.txtUPB.Tag = "";
            // 
            // txtDescrUPB
            // 
            this.txtDescrUPB.Location = new System.Drawing.Point(99, 8);
            this.txtDescrUPB.Multiline = true;
            this.txtDescrUPB.Name = "txtDescrUPB";
            this.txtDescrUPB.ReadOnly = true;
            this.txtDescrUPB.Size = new System.Drawing.Size(229, 57);
            this.txtDescrUPB.TabIndex = 4;
            this.txtDescrUPB.TabStop = false;
            this.txtDescrUPB.Tag = "upb.title";
            // 
            // btnUPBCode
            // 
            this.btnUPBCode.BackColor = System.Drawing.SystemColors.Control;
            this.btnUPBCode.Enabled = false;
            this.btnUPBCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F,
                System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.btnUPBCode.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnUPBCode.Location = new System.Drawing.Point(6, 45);
            this.btnUPBCode.Name = "btnUPBCode";
            this.btnUPBCode.Size = new System.Drawing.Size(69, 20);
            this.btnUPBCode.TabIndex = 2;
            this.btnUPBCode.TabStop = false;
            this.btnUPBCode.Tag = "";
            this.btnUPBCode.Text = "UPB";
            this.btnUPBCode.UseVisualStyleBackColor = false;
            // 
            // gboxMovimento
            // 
            this.gboxMovimento.Controls.Add(this.btnSelectMov);
            this.gboxMovimento.Controls.Add(this.txtNumeroMovimento);
            this.gboxMovimento.Controls.Add(this.labNum);
            this.gboxMovimento.Controls.Add(this.txtEsercizioMovimento);
            this.gboxMovimento.Controls.Add(this.labEserc);
            this.gboxMovimento.Location = new System.Drawing.Point(8, 16);
            this.gboxMovimento.Name = "gboxMovimento";
            this.gboxMovimento.Size = new System.Drawing.Size(336, 48);
            this.gboxMovimento.TabIndex = 89;
            this.gboxMovimento.TabStop = false;
            this.gboxMovimento.Tag = "";
            this.gboxMovimento.Text = "Movimento";
            // 
            // btnSelectMov
            // 
            this.btnSelectMov.Location = new System.Drawing.Point(16, 17);
            this.btnSelectMov.Name = "btnSelectMov";
            this.btnSelectMov.Size = new System.Drawing.Size(75, 23);
            this.btnSelectMov.TabIndex = 4;
            this.btnSelectMov.Tag = "";
            this.btnSelectMov.Text = "Seleziona";
            this.btnSelectMov.Click += new System.EventHandler(this.btnSelectMov_Click);
            // 
            // txtNumeroMovimento
            // 
            this.txtNumeroMovimento.Location = new System.Drawing.Point(224, 16);
            this.txtNumeroMovimento.Name = "txtNumeroMovimento";
            this.txtNumeroMovimento.Size = new System.Drawing.Size(48, 23);
            this.txtNumeroMovimento.TabIndex = 3;
            this.txtNumeroMovimento.Tag = "";
            this.txtNumeroMovimento.Leave += new System.EventHandler(this.txtNumeroMovimento_Leave);
            // 
            // labNum
            // 
            this.labNum.Location = new System.Drawing.Point(192, 16);
            this.labNum.Name = "labNum";
            this.labNum.Size = new System.Drawing.Size(32, 20);
            this.labNum.TabIndex = 0;
            this.labNum.Text = "Num.";
            this.labNum.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtEsercizioMovimento
            // 
            this.txtEsercizioMovimento.Location = new System.Drawing.Point(136, 16);
            this.txtEsercizioMovimento.Name = "txtEsercizioMovimento";
            this.txtEsercizioMovimento.Size = new System.Drawing.Size(39, 23);
            this.txtEsercizioMovimento.TabIndex = 2;
            this.txtEsercizioMovimento.Tag = "";
            this.txtEsercizioMovimento.Leave += new System.EventHandler(this.txtEsercizioMovimento_Leave);
            // 
            // labEserc
            // 
            this.labEserc.Location = new System.Drawing.Point(96, 16);
            this.labEserc.Name = "labEserc";
            this.labEserc.Size = new System.Drawing.Size(40, 20);
            this.labEserc.TabIndex = 0;
            this.labEserc.Text = "Eserc.";
            this.labEserc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBox17
            // 
            this.groupBox17.Controls.Add(this.txtDescrizione);
            this.groupBox17.Location = new System.Drawing.Point(352, 16);
            this.groupBox17.Name = "groupBox17";
            this.groupBox17.Size = new System.Drawing.Size(382, 97);
            this.groupBox17.TabIndex = 93;
            this.groupBox17.TabStop = false;
            this.groupBox17.Text = "Descrizione";
            // 
            // txtDescrizione
            // 
            this.txtDescrizione.Location = new System.Drawing.Point(8, 16);
            this.txtDescrizione.Multiline = true;
            this.txtDescrizione.Name = "txtDescrizione";
            this.txtDescrizione.ReadOnly = true;
            this.txtDescrizione.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDescrizione.Size = new System.Drawing.Size(368, 71);
            this.txtDescrizione.TabIndex = 1;
            this.txtDescrizione.Tag = "";
            // 
            // gboxBilAnnuale
            // 
            this.gboxBilAnnuale.Controls.Add(this.label9);
            this.gboxBilAnnuale.Controls.Add(this.txtCodiceBilancio);
            this.gboxBilAnnuale.Controls.Add(this.txtDenominazioneBilancio);
            this.gboxBilAnnuale.Location = new System.Drawing.Point(10, 208);
            this.gboxBilAnnuale.Name = "gboxBilAnnuale";
            this.gboxBilAnnuale.Size = new System.Drawing.Size(336, 107);
            this.gboxBilAnnuale.TabIndex = 90;
            this.gboxBilAnnuale.TabStop = false;
            this.gboxBilAnnuale.Tag = "";
            // 
            // label9
            // 
            this.label9.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label9.Location = new System.Drawing.Point(11, 61);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(64, 13);
            this.label9.TabIndex = 3;
            this.label9.Text = "Bilancio";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtCodiceBilancio
            // 
            this.txtCodiceBilancio.Location = new System.Drawing.Point(6, 80);
            this.txtCodiceBilancio.Name = "txtCodiceBilancio";
            this.txtCodiceBilancio.ReadOnly = true;
            this.txtCodiceBilancio.Size = new System.Drawing.Size(324, 23);
            this.txtCodiceBilancio.TabIndex = 1;
            this.txtCodiceBilancio.Tag = "";
            // 
            // txtDenominazioneBilancio
            // 
            this.txtDenominazioneBilancio.Location = new System.Drawing.Point(89, 8);
            this.txtDenominazioneBilancio.Multiline = true;
            this.txtDenominazioneBilancio.Name = "txtDenominazioneBilancio";
            this.txtDenominazioneBilancio.ReadOnly = true;
            this.txtDenominazioneBilancio.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDenominazioneBilancio.Size = new System.Drawing.Size(239, 66);
            this.txtDenominazioneBilancio.TabIndex = 2;
            this.txtDenominazioneBilancio.TabStop = false;
            this.txtDenominazioneBilancio.Tag = "";
            // 
            // groupBox20
            // 
            this.groupBox20.Controls.Add(this.label15);
            this.groupBox20.Controls.Add(this.txtDataCont);
            this.groupBox20.Controls.Add(this.txtScadenza);
            this.groupBox20.Controls.Add(this.label13);
            this.groupBox20.Location = new System.Drawing.Point(352, 208);
            this.groupBox20.Name = "groupBox20";
            this.groupBox20.Size = new System.Drawing.Size(382, 40);
            this.groupBox20.TabIndex = 96;
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
            // txtDataCont
            // 
            this.txtDataCont.Location = new System.Drawing.Point(67, 15);
            this.txtDataCont.Name = "txtDataCont";
            this.txtDataCont.ReadOnly = true;
            this.txtDataCont.Size = new System.Drawing.Size(72, 23);
            this.txtDataCont.TabIndex = 1;
            this.txtDataCont.Tag = "";
            this.txtDataCont.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtScadenza
            // 
            this.txtScadenza.Location = new System.Drawing.Point(256, 16);
            this.txtScadenza.Name = "txtScadenza";
            this.txtScadenza.ReadOnly = true;
            this.txtScadenza.Size = new System.Drawing.Size(72, 23);
            this.txtScadenza.TabIndex = 2;
            this.txtScadenza.Tag = "";
            this.txtScadenza.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label13
            // 
            this.label13.Location = new System.Drawing.Point(184, 16);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(64, 20);
            this.label13.TabIndex = 0;
            this.label13.Text = "Scadenza:";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBox18
            // 
            this.groupBox18.Controls.Add(this.SubEntity_txtImportoMovimento);
            this.groupBox18.Controls.Add(this.label11);
            this.groupBox18.Location = new System.Drawing.Point(8, 72);
            this.groupBox18.Name = "groupBox18";
            this.groupBox18.Size = new System.Drawing.Size(336, 40);
            this.groupBox18.TabIndex = 95;
            this.groupBox18.TabStop = false;
            this.groupBox18.Text = "Importo";
            // 
            // SubEntity_txtImportoMovimento
            // 
            this.SubEntity_txtImportoMovimento.Location = new System.Drawing.Point(216, 12);
            this.SubEntity_txtImportoMovimento.Name = "SubEntity_txtImportoMovimento";
            this.SubEntity_txtImportoMovimento.ReadOnly = true;
            this.SubEntity_txtImportoMovimento.Size = new System.Drawing.Size(112, 23);
            this.SubEntity_txtImportoMovimento.TabIndex = 1;
            this.SubEntity_txtImportoMovimento.Tag = "";
            this.SubEntity_txtImportoMovimento.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(143, 11);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(56, 20);
            this.label11.TabIndex = 0;
            this.label11.Text = "Originale:";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblImportoDisponibile);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.txtImportoDisponibile);
            this.groupBox1.Controls.Add(this.txtImportoCorrente);
            this.groupBox1.Location = new System.Drawing.Point(352, 251);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(382, 64);
            this.groupBox1.TabIndex = 97;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Situazione riassuntiva importo del movimento";
            // 
            // lblImportoDisponibile
            // 
            this.lblImportoDisponibile.Location = new System.Drawing.Point(82, 37);
            this.lblImportoDisponibile.Name = "lblImportoDisponibile";
            this.lblImportoDisponibile.Size = new System.Drawing.Size(192, 20);
            this.lblImportoDisponibile.TabIndex = 0;
            this.lblImportoDisponibile.Text = "Disponibile:";
            this.lblImportoDisponibile.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(6, 12);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(269, 24);
            this.label12.TabIndex = 0;
            this.label12.Text = "Attuale (comprensivo delle variazioni):";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtImportoDisponibile
            // 
            this.txtImportoDisponibile.Location = new System.Drawing.Point(280, 40);
            this.txtImportoDisponibile.Name = "txtImportoDisponibile";
            this.txtImportoDisponibile.ReadOnly = true;
            this.txtImportoDisponibile.Size = new System.Drawing.Size(96, 23);
            this.txtImportoDisponibile.TabIndex = 0;
            this.txtImportoDisponibile.TabStop = false;
            this.txtImportoDisponibile.Tag = "";
            this.txtImportoDisponibile.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtImportoCorrente
            // 
            this.txtImportoCorrente.Location = new System.Drawing.Point(280, 14);
            this.txtImportoCorrente.Name = "txtImportoCorrente";
            this.txtImportoCorrente.ReadOnly = true;
            this.txtImportoCorrente.Size = new System.Drawing.Size(96, 23);
            this.txtImportoCorrente.TabIndex = 0;
            this.txtImportoCorrente.TabStop = false;
            this.txtImportoCorrente.Tag = "";
            this.txtImportoCorrente.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // radioNewLinkedMov
            // 
            this.radioNewLinkedMov.Location = new System.Drawing.Point(8, 28);
            this.radioNewLinkedMov.Name = "radioNewLinkedMov";
            this.radioNewLinkedMov.Size = new System.Drawing.Size(696, 16);
            this.radioNewLinkedMov.TabIndex = 102;
            this.radioNewLinkedMov.Text =
                "Si desidera creare un NUOVO movimento di entrata, collegandolo però ad un movimen" +
                "to esistente";
            this.radioNewLinkedMov.CheckedChanged += new System.EventHandler(this.radioNewLinkedMov_CheckedChanged);
            // 
            // radioNewCont
            // 
            this.radioNewCont.Location = new System.Drawing.Point(8, 8);
            this.radioNewCont.Name = "radioNewCont";
            this.radioNewCont.Size = new System.Drawing.Size(688, 16);
            this.radioNewCont.TabIndex = 101;
            this.radioNewCont.Text =
                "Si desidera creare un NUOVO movimento di entrata (uno per ogni diverso UPB e Clie" +
                "nte presente nei dettagli selezionati)";
            this.radioNewCont.CheckedChanged += new System.EventHandler(this.radioNewCont_CheckedChanged);
            // 
            // radioAddCont
            // 
            this.radioAddCont.Location = new System.Drawing.Point(8, 48);
            this.radioAddCont.Name = "radioAddCont";
            this.radioAddCont.Size = new System.Drawing.Size(688, 16);
            this.radioAddCont.TabIndex = 100;
            this.radioAddCont.Text = "Si desidera AGGIUNGERE LA CONTABILIZZAZIONE ai dettagli del Contratto Attivo ";
            this.radioAddCont.CheckedChanged += new System.EventHandler(this.radioAddCont_CheckedChanged);
            // 
            // labelMessage
            // 
            this.labelMessage.Anchor =
                ((System.Windows.Forms.AnchorStyles)
                    (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                      | System.Windows.Forms.AnchorStyles.Right)));
            this.labelMessage.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.labelMessage.Location = new System.Drawing.Point(5, 396);
            this.labelMessage.Name = "labelMessage";
            this.labelMessage.Size = new System.Drawing.Size(775, 17);
            this.labelMessage.TabIndex = 99;
            // 
            // tabConfirm
            // 
            this.tabConfirm.Controls.Add(this.gboxBilToCreate);
            this.tabConfirm.Controls.Add(this.labMsgTODO2);
            this.tabConfirm.Controls.Add(this.labMsgTODO1);
            this.tabConfirm.Location = new System.Drawing.Point(0, 0);
            this.tabConfirm.Name = "tabConfirm";
            this.tabConfirm.Selected = false;
            this.tabConfirm.Size = new System.Drawing.Size(791, 511);
            this.tabConfirm.TabIndex = 6;
            this.tabConfirm.Title = "Pagina 5 di 5";
            // 
            // gboxBilToCreate
            // 
            this.gboxBilToCreate.Controls.Add(this.label14);
            this.gboxBilToCreate.Controls.Add(this.txtCodeBilSelected);
            this.gboxBilToCreate.Controls.Add(this.txtDenomBilSelected);
            this.gboxBilToCreate.Location = new System.Drawing.Point(8, 112);
            this.gboxBilToCreate.Name = "gboxBilToCreate";
            this.gboxBilToCreate.Size = new System.Drawing.Size(336, 106);
            this.gboxBilToCreate.TabIndex = 91;
            this.gboxBilToCreate.TabStop = false;
            this.gboxBilToCreate.Tag = "";
            // 
            // label14
            // 
            this.label14.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label14.Location = new System.Drawing.Point(8, 63);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(64, 13);
            this.label14.TabIndex = 3;
            this.label14.Text = "Bilancio";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtCodeBilSelected
            // 
            this.txtCodeBilSelected.Location = new System.Drawing.Point(6, 79);
            this.txtCodeBilSelected.Name = "txtCodeBilSelected";
            this.txtCodeBilSelected.ReadOnly = true;
            this.txtCodeBilSelected.Size = new System.Drawing.Size(322, 23);
            this.txtCodeBilSelected.TabIndex = 1;
            this.txtCodeBilSelected.Tag = "";
            // 
            // txtDenomBilSelected
            // 
            this.txtDenomBilSelected.Location = new System.Drawing.Point(88, 8);
            this.txtDenomBilSelected.Multiline = true;
            this.txtDenomBilSelected.Name = "txtDenomBilSelected";
            this.txtDenomBilSelected.ReadOnly = true;
            this.txtDenomBilSelected.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDenomBilSelected.Size = new System.Drawing.Size(240, 65);
            this.txtDenomBilSelected.TabIndex = 2;
            this.txtDenomBilSelected.TabStop = false;
            this.txtDenomBilSelected.Tag = "";
            // 
            // labMsgTODO2
            // 
            this.labMsgTODO2.Location = new System.Drawing.Point(16, 40);
            this.labMsgTODO2.Name = "labMsgTODO2";
            this.labMsgTODO2.Size = new System.Drawing.Size(680, 23);
            this.labMsgTODO2.TabIndex = 1;
            // 
            // labMsgTODO1
            // 
            this.labMsgTODO1.Location = new System.Drawing.Point(16, 16);
            this.labMsgTODO1.Name = "labMsgTODO1";
            this.labMsgTODO1.Size = new System.Drawing.Size(680, 23);
            this.labMsgTODO1.TabIndex = 0;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor =
                ((System.Windows.Forms.AnchorStyles)
                    ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(705, 550);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 16;
            this.btnCancel.Tag = "maincancel";
            this.btnCancel.Text = "Cancel";
            // 
            // btnNext
            // 
            this.btnNext.Anchor =
                ((System.Windows.Forms.AnchorStyles)
                    ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNext.Location = new System.Drawing.Point(585, 550);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(88, 23);
            this.btnNext.TabIndex = 15;
            this.btnNext.Text = "Avanti >";
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnBack
            // 
            this.btnBack.Anchor =
                ((System.Windows.Forms.AnchorStyles)
                    ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBack.Location = new System.Drawing.Point(497, 550);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(80, 23);
            this.btnBack.TabIndex = 14;
            this.btnBack.Text = "< Indietro";
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor =
                ((System.Windows.Forms.AnchorStyles)
                    ((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                       | System.Windows.Forms.AnchorStyles.Left)
                      | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.tabController);
            this.panel1.Location = new System.Drawing.Point(4, 8);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(791, 536);
            this.panel1.TabIndex = 17;
            // 
            // FrmWizardEstimateDetail
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(801, 579);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnBack);
            this.Name = "FrmWizardEstimateDetail";
            this.Text = "FrmWizardEstimateDetail";
            this.tabController.ResumeLayout(false);
            this.tabSelDetail.ResumeLayout(false);
            this.tabSelDetail.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize) (this.DS)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize) (this.gridDetails)).EndInit();
            this.tabIntro.ResumeLayout(false);
            this.tabSplit.ResumeLayout(false);
            this.tabSplit.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.tabSelMov.ResumeLayout(false);
            this.gboxSelMov.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.gboxUPB.ResumeLayout(false);
            this.gboxUPB.PerformLayout();
            this.gboxMovimento.ResumeLayout(false);
            this.gboxMovimento.PerformLayout();
            this.groupBox17.ResumeLayout(false);
            this.groupBox17.PerformLayout();
            this.gboxBilAnnuale.ResumeLayout(false);
            this.gboxBilAnnuale.PerformLayout();
            this.groupBox20.ResumeLayout(false);
            this.groupBox20.PerformLayout();
            this.groupBox18.ResumeLayout(false);
            this.groupBox18.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabConfirm.ResumeLayout(false);
            this.gboxBilToCreate.ResumeLayout(false);
            this.gboxBilToCreate.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion


        #region Gestione Tabs

        /// <summary>
        /// Displays tab n. NewTab and updates buttons
        /// </summary>
        /// <param name="newTab"></param>
        void DisplayTabs(int newTab) {
            tabController.SelectedIndex = newTab;
            //Evaluates Buttons Appearance
            btnBack.Visible = (newTab > 0);
            if (newTab == tabController.TabPages.Count - 1)
                btnNext.Text = "Esegui.";
            else
                btnNext.Text = "Next >";
            Text = CustomTitle + " (Pagina " + (newTab + 1) + " di " + tabController.TabPages.Count + ")";
        }

        void StandardChangeTab(int step) {
            int oldTab = tabController.SelectedIndex;
            int newTab = oldTab + step;
            if ((newTab < 0) || (newTab > tabController.TabPages.Count)) return;
            if (!CustomChangeTab(oldTab, newTab)) return;
            if (newTab == tabController.TabPages.Count) {
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

        private void btnBack_Click(object sender, System.EventArgs e) {
            StandardChangeTab(-1);
        }


        private void btnNext_Click(object sender, System.EventArgs e) {
            StandardChangeTab(+1);
        }

        bool CustomChangeTab(int oldTab, int newTab) {
            if (!SalvataggioEnabled) {
                return false;
            }
            if (oldTab == 0) {
                return true; // 0->1: nothing to do
            }
            if ((oldTab == 1) && (newTab == 0)) return true; //1->0:nothing to do!
            if ((oldTab == 1) && (newTab == 2)) {
                DataRow[] Selected = GetGridSelectedRows(gridDetails);
                if ((Selected == null) || (GetGridSelectedRows(gridDetails).Length == 0)) {
                    MessageBox.Show("Non è stato selezionato alcun dettaglio.");
                    return false;
                }
                // Verifico se devo abilitare o meno la digitazione dell'importo
                // anche in base al tipo di contabilizzazione
                // Se devo aggiungere la contabilizzazione a un movimento esistente, 
                // non posso digitare l'importo
                object[] upb;
                object[] registry;
                string filterupb = "";
                string filterupb_forincome = "";
                string filteridreg = "";
                bool stop = false;
                genMultipla = SetGenMultipla(Selected, out upb, out registry, out filterupb, out filterupb_forincome,
                    out filteridreg, out stop);
                if (stop) return false;
                if (genMultipla) {
                    rdbSplittaTutti.Enabled = false;
                    rdbSplittaUno.Enabled = false;

                    txtDaIncassare.ReadOnly = true;
                    txtPerc.ReadOnly = true;
                }
                else {
                    rdbSplittaTutti.Enabled = true;
                    rdbSplittaUno.Enabled = true;

                    txtDaIncassare.ReadOnly = false;
                    txtPerc.ReadOnly = false;
                }
                txtDaIncassare.Text = txtTotSelezionato.Text;
                txtPerc.Text = "100";
                return true;
            }
            if ((oldTab == 2) && (newTab == 1)) {
                VisualizzaUPB();
                VisualizzaRegistry();
                AggiornaGridDettagliContratto();
                rdbSplittaTutti.Checked = false;
                txtDaIncassare.Text = "";
                txtPerc.Text = "";
                return true;
            }
            ;
            if ((oldTab == 2) && (newTab == 3)) {
                if (!RecalcSelezioneMovimenti()) return false;
                RadioCheck_Changed();
            }
            if ((oldTab == 3) && (newTab == 4)) {
                if ((radioNewCont.Checked == false) && (radioNewLinkedMov.Checked == false)
                    && (radioAddCont.Checked == false)) {
                    MessageBox.Show("Non sarà possibile contabilizzare i dettagli selezionati.");
                    return false;
                }
                if (!CheckInfoFin()) return false;
                return true;
            }
            if ((oldTab == 4) && (newTab == 5)) {
                if (!SelezioneMovimentiEffettuata) {
                    MessageBox.Show("Non è stato selezionato il movimento.");
                    return false;
                }
                RecalcDettagliSelezionati();

                DisplayMessages();
                return doAssocia();
            }
            return true;
        }

        #endregion

        public void MetaData_AfterActivation() {
            CustomTitle = "Wizard Contabilizzazione Dettagli Contratto Attivo";
            //Selects first tab
            DisplayTabs(0);
        }

        bool SetGenMultipla(DataRow[] SelectedRows, out object[] upb, out object[] registry,
            out string filterupb, out string filterupb_forincome, out string filteridreg, out bool stop) {
            string field = "idupb";
            int causale = CfgFn.GetNoNullInt32(cmbCausale.SelectedValue);
            if (causale == 2) {
                field = "idupb_iva";
            }
            stop = false;
            // Legge i dettagli con l'importo originale nel dataset
            foreach (DataRow Det in SelectedRows) {
                string filterestimatedetail = QueryCreator.WHERE_COLNAME_CLAUSE(
                    Det, new string[] {"idestimkind", "yestim", "nestim", "rownum"}, DataRowVersion.Default, true);
                DataAccess.RUN_SELECT_INTO_TABLE(Conn, DS.Tables["estimatedetail"], null, filterestimatedetail, null,
                    false);
            }
            object[] upb1 = ValoriDiversi(SelectedRows, field);

            object[] registry1 = ValoriDiversi(SelectedRows, "idreg");
            string filteridreg1 = "";
            string filterupb1 = "";
            string filterupb_forincome1 = "";
            DataRow M = DS.estimate.Rows[0];
            DataTable EstimateKind = Conn.RUN_SELECT("estimatekind", "*", null,
                QHS.CmpEq("idestimkind", M["idestimkind"]), null, null, true);
            // in base alla configurazione del tipo contratto, prendo il cliente del contratto
            // oppure i clienti dei vari dettagli

            if (EstimateKind.Rows.Count > 0) {
                string multiReg = EstimateKind.Rows[0]["multireg"].ToString();
                if (multiReg == "N") {
                    // Anagrafe nel contratto
                    registry1[0] = M["idreg"];
                }
            }

            // Elimino le righe con idreg = null
            // Controllo che tutti i dettagli abbiano associato l'upb oppure no
            // se non sono coerenti viene avvisato l'utente. Se poi l'UPB è uguale
            // per tutti i dettagli su cui è impostato, valorizzare gli altri dettagli con
            // lo stesso UPB

            string filter = QHC.IsNull(field);
            if ((FiltraRows(SelectedRows, filter).Count > 0) && (upb1.Length == 2)) {
                string idupbtoassign = "";
                List<DataRow> Details = FiltraRows(SelectedRows, QHC.IsNotNull(field));
                if (Details.Count > 0) idupbtoassign = Details[0][field].ToString();
                object[] result = new object[1];
                result[0] = idupbtoassign;
                upb1 = result;
            }

            if ((FiltraRows(SelectedRows, filter).Count > 0) && (upb1.Length > 2)) {
                MessageBox.Show(
                    " Ad alcuni dettagli tra quelli selezionati non è stato attribuito l'UPB, ad altri si." +
                    " Selezionare dettagli coerenti");
                stop = true;
            }
            object idupb = upb1[0];

            if (idupb != DBNull.Value) {
                filterupb1 = QHC.CmpEq(field, idupb);
                filterupb_forincome1 = QHC.CmpEq("idupb", idupb);
            }
            else {
                filterupb1 = filter;
                filterupb_forincome1 = filter;
            }

            object idreg = registry1[0];

            if (idreg != DBNull.Value)
                filteridreg1 = QHC.CmpEq("idreg", idreg);
            else {
                MessageBox.Show(" Il cliente non è correttamente impostato." +
                                " Pertanto non sarà possibile contabilizzare il contratto.");
                stop = true;
            }

            // Trovo un movimento  

            bool genMultipla = true;
            if ((upb1.Length == 1) && (registry1.Length == 1)) {
                genMultipla = false;
            }
            registry = registry1;
            upb = upb1;
            filterupb = filterupb1;
            filterupb_forincome = filterupb_forincome1;
            filteridreg = filteridreg1;
            return genMultipla;
        }

        DataRow GetGridRow(DataGrid G, int index) {
            string TableName = G.DataMember.ToString();
            DataSet MyDS = (DataSet) G.DataSource;
            DataTable MyTable = MyDS.Tables[TableName];
            string filter;
            filter = QHC.AppAnd(QHC.CmpEq("idestimkind", G[index, 0]), QHC.CmpEq("yestim", G[index, 1]),
                QHC.CmpEq("nestim", G[index, 2]), QHC.CmpEq("rownum", G[index, 3]));

            DataRow[] selectresult = MyTable.Select(filter);
            return selectresult[0];

        }

        private DataRow[] GetGridSelectedRows(DataGrid G) {
            if (G.DataMember == null) return null;
            if (G.DataSource == null) return null;
            string TableName = G.DataMember.ToString();
            DataSet MyDS = (DataSet) G.DataSource;
            DataTable MyTable = MyDS.Tables[TableName];
            int numrighetemp = MyTable.Rows.Count;
            int numrighe = 0;
            int i;
            for (i = 0; i < numrighetemp; i++) {
                if (G.IsSelected(i)) {
                    numrighe++;
                }
            }

            DataRow[] Res = new DataRow[numrighe];
            int count = 0;
            for (i = 0; i < numrighetemp; i++) {
                if (G.IsSelected(i)) {
                    Res[count++] = GetGridRow(G, i);
                }
            }
            return Res;
        }


        public void MetaData_AfterLink() {
            Meta = MetaData.GetMetaData(this);
            Conn = Meta.Conn;

            QHC = new CQueryHelper();
            QHS = Conn.GetQueryHelper();

            GetData.CacheTable(DS.incomephase);
            int esercizio = (int) Meta.GetSys("esercizio");
            string filteresercizio = QHS.CmpEq("ayear", esercizio);
            GetData.CacheTable(DS.config, filteresercizio, null, false);
            GetData.CacheTable(DS.estimatekind, null, "description", true);
            fasecontratto = CfgFn.GetNoNullInt32(Meta.GetSys("estimatephase"));
            if (fasecontratto == 0) {
                MessageBox.Show("La configurazione della fase di contabilizzazione in entrata " +
                                "non è stata definita per l'esercizio corrente! Non sarà possibile utilizzare questa procedura ",
                    "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                SalvataggioEnabled = false;
            }
            DataAccess.SetTableForReading(DS.registry1, "registry");
            DataAccess.SetTableForReading(DS.registry2, "registry");
            DetailsToUpdate = new ArrayList();
            Meta.CanCancel = false;
            Meta.SearchEnabled = false;
            Meta.CanSave = false;
        }

        public void MetaData_AfterClear() {
            DisplayTabs(tabController.SelectedIndex);
        }


        private void btnDocumento_Click(object sender, System.EventArgs e) {
            string filter = "";
            int esercizio = (int) Meta.GetSys("esercizio");
            int esercText = CfgFn.GetNoNullInt32(txtEsercDoc.Text);
            if (esercText != 0)
                filter = GetData.MergeFilters(filter,
                    QHS.CmpEq("yestim", esercText));

            if ((!sender.Equals(btnDocumento)) && txtNumDoc.Text.Trim() != "") {
                int ndoc = CfgFn.GetNoNullInt32(txtNumDoc.Text);
                if (ndoc > 0)
                    filter = GetData.MergeFilters(filter,
                        QHS.CmpEq("nestim", ndoc));
            }
            if (cmbTipoContratto.SelectedIndex > 0) {
                filter = GetData.MergeFilters(filter,
                    QHS.CmpEq("idestimkind", cmbTipoContratto.SelectedValue));
            }

            filter = GetData.MergeFilters(filter, QHS.CmpGt("residual", 0));
            filter = QHS.AppAnd(filter, QHS.NullOrEq("active", "S")); // utilizzabile per la contabilizzazione
            MetaData Estimate = MetaData.GetMetaData(this, "estimateincavailable");
            Estimate.FilterLocked = true;
            Estimate.DS = new DataSet();
            DataRow M = Estimate.SelectOne("default", filter, null, null);
            if (M == null) return;
            HelpForm.SetComboBoxValue(cmbTipoContratto, M["idestimkind"]);
            txtEsercDoc.Text = M["yestim"].ToString();
            txtNumDoc.Text = M["nestim"].ToString();
            txtCliente.Text = M["registry"].ToString();
            txtDescrContratto.Text = M["description"].ToString();

            DS.estimatedetail.Clear();
            DetailsToUpdate.Clear();
            DS.estimate.Clear();

            string filterestimate =
                QHS.AppAnd(QHS.AppAnd(QHS.CmpEq("idestimkind", M["idestimkind"]),
                    QHS.CmpEq("yestim", M["yestim"])), QHS.CmpEq("nestim", M["nestim"]));
            DataAccess.RUN_SELECT_INTO_TABLE(Conn, DS.estimate, null, filterestimate, null, false);
            if (DS.estimate.Rows.Count > 0) {
                object idman = DS.estimate.Rows[0]["idman"];
                if (idman != DBNull.Value) {
                    string manager = Conn.DO_READ_VALUE("manager", QHS.CmpEq("idman", idman), "title").ToString();
                    txtResponsabileContratto.Text = manager;
                }
                else txtResponsabileContratto.Text = "";
            }
            SetComboCausaleContratto(M);
            AggiornaGridDettagliContratto();
        }

        void ResetWizard() {
            if (DS.estimate.Rows.Count > 0)
                SetComboCausaleContratto(DS.estimate.Rows[0]);
            gridDetails.DataSource = null;
            AggiornaGridDettagliContratto();
        }

        void ClearComboCausale() {
            DataTable TCombo = DS.tipomovimento;
            TCombo.Clear();
            lblCausale.Text = "";
        }

        void EnableTipoMovimento(int IDtipo, string descrtipo) {
            DataRow R = DS.tipomovimento.NewRow();
            R["idtipo"] = IDtipo;
            R["descrizione"] = descrtipo;
            DS.tipomovimento.Rows.Add(R);
            DS.tipomovimento.AcceptChanges();
        }

        /// <summary>
        /// Riempie il combobox causale con i valori ammessi, senza impostarvi alcun valore
        /// </summary>
        /// <param name="Contratto"></param>
        void SetComboCausaleContratto(DataRow Contratto) {
            decimal totimponibile = 0;
            decimal totiva = 0;
            decimal assigned_imponibile = 0;
            decimal assigned_iva = 0;
            decimal assigned_gen = 0;
            bool EnableImpon = true;
            bool EnableImpos = true;
            bool EnableDocum = true;
            //bool intracom = false; //Per i C.A. e Fatture intracom., l'università incassa anche l'iva, per cui deve essere possibile contabilizzarla.Vedi 8524

            string filterContratto =
                QHS.AppAnd(QHS.CmpEq("idestimkind", Contratto["idestimkind"]),
                    QHS.CmpEq("yestim", Contratto["yestim"]), QHS.CmpEq("nestim", Contratto["nestim"]));
            DataTable T = Conn.RUN_SELECT("estimateresidual", "*", null, filterContratto, null, true);
            if ((T != null) && (T.Rows.Count > 0)) {
                //DataRow R=T.Rows[0];
                //totimponibile=CfgFn.GetNoNullDecimal( R["taxabletotal"]);
                //totiva=CfgFn.GetNoNullDecimal( R["ivatotal"]);
                foreach (DataRow Dett in T.Rows) {
                    totimponibile += CfgFn.GetNoNullDecimal(Dett["taxabletotal"]);
                    totiva += CfgFn.GetNoNullDecimal(Dett["ivatotal"]);
                    assigned_imponibile += CfgFn.GetNoNullDecimal(Dett["linkedimpon"]);
                    assigned_iva += CfgFn.GetNoNullDecimal(Dett["linkedimpos"]);
                    assigned_gen += CfgFn.GetNoNullDecimal(Dett["linkedestim"]);
                    //if (Dett["flagintracom"].ToString().ToUpper() != "N") intracom = true;
                }
            }
            ClearComboCausale();
            //if (intracom) {
            //    EnableDocum = false;
            //    EnableImpos = false;
            //}

            if (EnableDocum &&
                ((assigned_imponibile + assigned_iva) == 0) &&
                (assigned_gen < (totimponibile + totiva))
                ) {
                EnableTipoMovimento(1, "Contabilizzazione Totale Contratto");
            }

            if (EnableImpon &&
                ((assigned_gen == 0) && (assigned_imponibile < totimponibile))
                ) {
                EnableTipoMovimento(3, "Contabilizzazione Imponibile Contratto");
            }

            if (EnableImpos &&
                ((assigned_gen == 0) && (assigned_iva < totiva))
                ) {
                EnableTipoMovimento(2, "Contabilizzazione Iva Contratto");
            }

        }

        void AggiornaGridDettagliContratto() {
            DS.estimatedetail.Clear();
            DetailsToUpdate.Clear();
            if (cmbCausale.SelectedIndex < 0) return;
            int causale = CfgFn.GetNoNullInt32(cmbCausale.SelectedValue);
            if (causale == 0) return;
            string filtercausale = QHC.CmpEq("idtipo", causale);
            lblCausale.Text = "Sulla Causale: " +
                              DS.tipomovimento.Select(filtercausale, null)[0]["descrizione"].ToString();

            if (DS.estimate.Rows.Count == 0) return;

            DataRow M = DS.estimate.Rows[0];
            string filterestimate =
                QHS.AppAnd(QHS.AppAnd(QHS.CmpEq("idestimkind", M["idestimkind"]),
                    QHS.CmpEq("yestim", M["yestim"])), QHS.CmpEq("nestim", M["nestim"]));
            string filterestimatedetail = filterestimate;
            //filterestimatedetail=GetData.MergeFilters(filterestimatedetail, "(idupb is not null)");
            filterestimatedetail = GetData.MergeFilters(filterestimatedetail, QHS.IsNull("stop"));
            if (causale == 1) {
                //Se è abilitato ESTIM significa che non ci sono contabilizzazioni diverse da ESTIM attivate,
                // ossia tutti i dettagli sono o contabilizzati del tutto o per niente
                // --> basta un filtro su idinc_iva is null
                filterestimatedetail = GetData.MergeFilters(filterestimatedetail,
                    QHS.AppAnd(QHS.IsNull("idinc_iva"), QHS.IsNull("idinc_taxable")));
            }
            if (causale == 3) {
                //Se è abilitato ESTM significa che non ci sono contabilizzazioni diverse da ESTIM attivate,
                // ossia tutti i dettagli sono o contabilizzati del tutto o per niente
                // --> basta un filtro su idinc_iva is null
                filterestimatedetail = GetData.MergeFilters(filterestimatedetail, QHS.IsNull("idinc_taxable"));
            }
            if (causale == 2) {
                //Se è abilitato ESTIM significa che non ci sono contabilizzazioni diverse da ESTIM attivate,
                // ossia tutti i dettagli sono o contabilizzati del tutto o per niente
                // --> basta un filtro su idinc_iva is null
                filterestimatedetail = GetData.MergeFilters(filterestimatedetail, QHS.IsNull("idinc_iva"));
            }

            DSCopy = DS.Copy();
            DataAccess.RUN_SELECT_INTO_TABLE(Conn, DSCopy.Tables["estimatedetail"], null, filterestimatedetail, null,
                false);

            MetaData MD = MetaData.GetMetaData(this, "estimatedetail");
            MD.DS = DSCopy;
            MD.DescribeColumns(DSCopy.Tables["estimatedetail"], "default");
            GetData GD = new GetData();
            GD.InitClass(DSCopy, Conn, "estimatedetail");
            foreach (DataRow r in DSCopy.Tables["estimatedetail"].Select()) {
                if (r["idupb_iva"] == DBNull.Value)
                    r["idupb_iva"] = r["idupb"];
                r.AcceptChanges();
            }


            GD.GetTemporaryValues(DSCopy.Tables["estimatedetail"]);
            gridDetails.DataSource = null;
            HelpForm.SetDataGrid(gridDetails, DSCopy.Tables["estimatedetail"]);
            btnSelectAllDetail_Click(null, null);
            VisualizzaUPB();
            VisualizzaRegistry();
            RecalcTotalDetails();
        }

        private void cmbCausale_SelectedIndexChanged(object sender, System.EventArgs e) {
            AggiornaGridDettagliContratto();
        }

        void ClearContratto() {
            //txtEsercDoc.Text="";
            txtNumDoc.Text = "";
            txtDescrContratto.Text = "";
            txtCliente.Text = "";
            txtResponsabileContratto.Text = "";
            DS.estimate.Clear();
            DS.estimatedetail.Clear();
            DetailsToUpdate.Clear();
            if (DSCopy != null) {
                DSCopy.Tables["estimatedetail"].Clear();
            }
            RecalcTotalDetails();
        }

        private void txtEsercDoc_Leave(object sender, System.EventArgs e) {
            int yestim = CfgFn.GetNoNullInt32(txtEsercDoc.Text);
            if (yestim <= 0) {
                ClearContratto();
                return;
            }
            if (yestim < 1000) {
                yestim += 2000;
                txtEsercDoc.Text = yestim.ToString();
            }
            if (txtNumDoc.Text.Trim() != "") {
                btnDocumento_Click(sender, e);
                return;
            }
        }

        private void txtNumDoc_Leave(object sender, System.EventArgs e) {
            int nestim = CfgFn.GetNoNullInt32(txtNumDoc.Text);
            if (nestim <= 0) {
                ClearContratto();
                return;
            }
            //if (txtEsercDoc.Text.Trim()!=""){
            btnDocumento_Click(sender, e);
            return;
            //}

        }

        private void btnSelectAllDetail_Click(object sender, System.EventArgs e) {
            if (gridDetails.DataSource == null) return;
            if (DSCopy != null) {
                for (int i = 0; i < DSCopy.Tables["estimatedetail"].Rows.Count; i++) gridDetails.Select(i);
            }
        }

        void RecalcTotalDetails() {
            txtDaIncassare.Text = "";
            txtPerc.Text = "";
            DataRow[] Selected = GetGridSelectedRows(gridDetails);
            if ((Selected == null) || (Selected.Length == 0) ||
                (cmbCausale.SelectedValue == null) || (cmbCausale.SelectedValue == DBNull.Value)) {
                txtTotGenerale.Text = "";
                txtTotImponibile.Text = "";
                txtTotIva.Text = "";
                TotaleDaContabilizzare = 0;
                return;
            }
            if (DS.estimate.Rows.Count == 0) return;
            DataRow estimate = DS.estimate.Rows[0];
            double tassocambio = CfgFn.GetNoNullDouble(estimate["exchangerate"]);
            if (tassocambio == 0) tassocambio = 1;
            double totiva = 0;
            double totimpo = 0;
            double total = 0;

            int causale = CfgFn.GetNoNullInt32(cmbCausale.SelectedValue);
            foreach (DataRow Curr in Selected) {
                double imponibile = CfgFn.GetNoNullDouble(Curr["taxable"]);
                double quantita = CfgFn.GetNoNullDouble(Curr["number"]);
                double aliquota = CfgFn.GetNoNullDouble(Curr["taxrate"]);
                double sconto = CfgFn.GetNoNullDouble(Curr["discount"]);
                double imponibileEUR = (imponibile*quantita*(1 - sconto))*tassocambio;
                double ivaEUR = CfgFn.GetNoNullDouble(Curr["tax"])*tassocambio;
                //imponibileEUR*aliquota;

                imponibileEUR = CfgFn.RoundValuta(imponibileEUR);
                ivaEUR = CfgFn.RoundValuta(ivaEUR);
                if (causale == 3) {
                    totimpo += imponibileEUR;
                }
                if (causale == 2) {
                    totiva += ivaEUR;
                }
                if (causale == 1) {
                    totimpo += imponibileEUR;
                    totiva += ivaEUR;
                }
                total = totimpo + totiva;

            }
            if (causale == 3) {
                txtTotGenerale.Text = total.ToString("C");
                txtTotImponibile.Text = totimpo.ToString("C");
                txtTotIva.Text = "";
                TotaleDaContabilizzare = CfgFn.GetNoNullDecimal(totimpo);
                txtTotSelezionato.Text = totimpo.ToString("C");
            }
            if (causale == 2) {
                txtTotGenerale.Text = total.ToString("C");
                txtTotImponibile.Text = "";
                txtTotIva.Text = totiva.ToString("C");
                TotaleDaContabilizzare = CfgFn.GetNoNullDecimal(totiva);
                txtTotSelezionato.Text = totiva.ToString("C");
            }
            if (causale == 1) {
                txtTotGenerale.Text = total.ToString("C");
                txtTotImponibile.Text = totimpo.ToString("C");
                txtTotIva.Text = totiva.ToString("C");
                TotaleDaContabilizzare = CfgFn.GetNoNullDecimal(total);
                txtTotSelezionato.Text = total.ToString("C");
            }

        }

        void VisualizzaUPB() {
            DataTable Details = DSCopy.Tables["estimatedetail"];
            object idupb;
            string filterupb;
            object codeupb;
            if (Details.Rows.Count == 0) return;
            foreach (DataRow Curr in Details.Rows) {
                idupb = Curr["idupb"];
                if (idupb != DBNull.Value) {
                    filterupb = QHS.CmpEq("idupb", idupb);
                    codeupb = Conn.DO_READ_VALUE("upb", filterupb, "codeupb");
                    Curr["!codeupb"] = codeupb;
                }
                idupb = Curr["idupb_iva"];
                if (idupb != DBNull.Value) {
                    filterupb = QHS.CmpEq("idupb", idupb);
                    codeupb = Conn.DO_READ_VALUE("upb", filterupb, "codeupb");
                    Curr["!codeupb_iva"] = codeupb;
                }
            }
        }

        void VisualizzaRegistry() {
            DataTable Details = DSCopy.Tables["estimatedetail"];
            object idreg;
            string filterregistry;
            object title;
            if (Details.Rows.Count == 0) return;
            foreach (DataRow Curr in Details.Rows) {
                idreg = Curr["idreg"];
                if (idreg != DBNull.Value) {
                    filterregistry = QHS.CmpEq("idreg", idreg);
                    title = Conn.DO_READ_VALUE("registry", filterregistry, "title");
                    Curr["!registry"] = title;
                }
            }
        }

        private void gridDetails_Paint(object sender, System.Windows.Forms.PaintEventArgs e) {
            RecalcTotalDetails();
        }

        private void chkAddContab_CheckedChanged(object sender, System.EventArgs e) {
            if (chkAddContab.Checked) {
                radioAddCont.Checked = true;
                radioNewCont.Checked = false;
                radioNewLinkedMov.Checked = false;
                radioAddCont.Enabled = false;
                radioNewCont.Enabled = false;
                radioNewLinkedMov.Enabled = false;
            }
            else {
                radioAddCont.Enabled = false;
                radioAddCont.Checked = false;
                radioNewCont.Enabled = true;
                radioNewCont.Checked = true;
                radioNewLinkedMov.Enabled = true;
            }
            //ClearContratto();
        }


        private decimal CalcolaTotCausale(DataRow EstimateDetail, int causale) {
            double tassocambio = CfgFn.GetNoNullDouble(DS.estimate.Rows[0]["exchangerate"]);
            if (tassocambio == 0) tassocambio = 1;
            DataRow Curr = EstimateDetail;

            double imponibile = CfgFn.GetNoNullDouble(Curr["taxable"]);
            double quantita = CfgFn.GetNoNullDouble(Curr["number"]);
            double aliquota = CfgFn.GetNoNullDouble(Curr["taxrate"]);
            double sconto = CfgFn.GetNoNullDouble(Curr["discount"]);
            double imponibileEUR = (imponibile*quantita*(1 - sconto))*tassocambio;
            double ivaEUR = CfgFn.GetNoNullDouble(Curr["tax"])*tassocambio;
            imponibileEUR = CfgFn.RoundValuta(imponibileEUR);
            ivaEUR = CfgFn.RoundValuta(ivaEUR);
            if (causale == 1) return CfgFn.GetNoNullDecimal(ivaEUR + imponibileEUR);
            if (causale == 3) return CfgFn.GetNoNullDecimal(imponibileEUR);
            return CfgFn.GetNoNullDecimal(ivaEUR);
        }

        decimal CalcTotCausale(DataRow[] EstimateDetail, int causale, bool genMultipla) {
            decimal sum = 0;
            foreach (DataRow R in EstimateDetail) sum += CalcolaTotCausale(R, causale);
            if (genMultipla) return sum;

            // verifica se l'importo da contabilizzare è diverso da quello digitato dall'utente
            decimal importototale = CfgFn.GetNoNullDecimal(
                HelpForm.GetObjectFromString(typeof (decimal),
                    txtDaIncassare.Text, "x.y.c"));
            if (importototale != 0 && importototale != sum) sum = importototale;

            return sum;
        }


        bool SelezioneMovimentiEffettuata = false;


        string FilterAddCont = null;

        object[] ValoriDiversi(DataRow[] Rows, string field) {
            object[] DIV = new object[Rows.Length];
            int N = 0;
            foreach (DataRow R in Rows) {
                object currval = R[field];
                int j = 0;
                for (j = 0; j < N; j++) {
                    if (DIV[j].Equals(currval)) {
                        break;
                    }
                }
                if (j == N) {
                    DIV[N++] = currval;
                }
            }
            object[] result = new object[N];
            for (int i = 0; i < N; i++) result[i] = DIV[i];
            return result;
        }

        List<DataRow> FiltraRows(DataRow[] Rows, string filter) {
            List<DataRow> RR = new List<DataRow>();
            if (Rows.Length == 0) {
                return RR;
            }            
            //DataTable T = DS.estimatedetail;
            DataTable TCopy = DSCopy.Tables["estimatedetail"];
            DataRow[] found = TCopy.Select(filter);
            var rowFound = new Dictionary<string, bool>();
            foreach (DataRow r in found) {
                string sk = $"{r["idestimkind"]}#{r["yestim"]}#{r["nestim"]}#{r["rownum"]}";
                rowFound.Add(sk,true);
            }
            foreach (DataRow r in Rows) {
                if (r.RowState == DataRowState.Deleted) continue;
                string sk = $"{r["idestimkind"]}#{r["yestim"]}#{r["nestim"]}#{r["rownum"]}";
                if (rowFound.ContainsKey(sk))RR.Add(r);
            }
            
            return RR;
        }

        DataRow AutoSelectedMov = null;


        //bool incomeestimatedone = false;
        bool RecalcSelezioneMovimenti() {
            DataRow[] SelectedRows = GetGridSelectedRows(gridDetails);
            if ((SelectedRows == null) || (GetGridSelectedRows(gridDetails).Length == 0)) {
                return false;
            }
            labelAddCont.Text = "";
            labelNewLinkedCont.Text = "";
            labelMessage.Text = "";
            int esercizio = (int) Meta.GetSys("esercizio");
            filterMovimento = null;
            AutoSelectedMov = null;
            ClearMovimento();
            DS.incomeestimate.Clear();
            string filterestimate;
            FilterAddCont = null;

            DataRow M = DS.estimate.Rows[0];
            filterestimate =
                QHS.AppAnd(QHS.AppAnd(QHS.CmpEq("idestimkind", M["idestimkind"]),
                    QHS.CmpEq("yestim", M["yestim"])), QHS.CmpEq("nestim", M["nestim"]));
            int currcausale = CfgFn.GetNoNullInt32(cmbCausale.SelectedValue);

            if (currcausale == 1) {
                foreach (DataRow r in SelectedRows) {
                    if (r["idupb_iva"].ToString() != r["idupb"].ToString()) {
                        MessageBox.Show("La contabilizzazione totale non può essere usata su dettagli con upb diverse",
                            "Avviso");
                        return false;
                    }
                    
                }
            }

            //string sumexpr = "";
            string fieldtolink = "";
            switch (currcausale) {
                case 1:
                    //sumexpr = "(isnull(SUM(taxable_euro),0)+isnull(SUM(iva_euro),0))";
                    fieldtolink = "idinc_taxable";
                    break;
                case 3:
                    //sumexpr = "SUM(taxable_euro)";
                    fieldtolink = "idinc_taxable";
                    break;
                case 2:
                    //sumexpr = "SUM(iva_euro)";
                    fieldtolink = "idinc_iva";
                    break;
            }
            string field = "idupb";
            int causale = CfgFn.GetNoNullInt32(cmbCausale.SelectedValue);
            if (causale == 2) {
                field = "idupb_iva";
            }

            object[] upb = ValoriDiversi(SelectedRows, field);
            object[] registry = ValoriDiversi(SelectedRows, "idreg");
            string filterupb = "";
            string filterupb_forincome = "";
            string filteridreg = "";
            bool stop = false;
            genMultipla = SetGenMultipla(SelectedRows, out upb, out registry, out filterupb, out filterupb_forincome,
                out filteridreg, out stop);

            object idupb = upb[0];

            decimal importoupb = CalcTotCausale(FiltraRows(SelectedRows, filterupb).ToArray(), currcausale, genMultipla);

            string filtercont = "";

            filtercont = GetData.MergeFilters(filtercont, "(NOT idinc in (SELECT idinc from incomeestimate))");
            filtercont = GetData.MergeFilters(filtercont, "(NOT idinc in (SELECT idinc from incomeinvoice))");

            if (idupb != DBNull.Value) {
                filtercont = GetData.MergeFilters(filtercont, filterupb_forincome);
            }
            filtercont = GetData.MergeFilters(filtercont, filteridreg);
            filtercont = GetData.MergeFilters(filtercont, QHS.CmpEq("ayear", esercizio));
            filtercont = GetData.MergeFilters(filtercont, QHS.CmpEq("nphase", fasecontratto));
            filtercont = GetData.MergeFilters(filtercont, QHS.CmpEq("curramount", importoupb));

            DataTable ContabilizzazioniDisponibili = Conn.RUN_SELECT("incomeview", "*", null, filtercont, null, null,
                true);

            if (chkAddContab.Checked) {
                // Si desidera aggiungere la contabilizzazione a un movimento esistente
                // Disabilito le altre opzioni 
                // radioNewLinkedMov.Visible=false;
                // radioNewCont.Visible=false;
                // Abilito la terza opzione per aggiungere la contabilizzazione
                // Deve essere un solo clientE e un solo UPB per tutti i dettagli
                radioAddCont.Visible = true;
                radioAddCont.Enabled = true;
                radioAddCont.Checked = true;

                if (registry.Length > 1) {
                    MessageBox.Show(
                        "Per aggiungere la contabilizzazione i dettagli selezionati devono avere lo stesso creditore");
                    return false;
                }

                if (upb.Length > 1) {
                    MessageBox.Show(
                        "Per aggiungere la contabilizzazione i dettagli selezionati devono avere lo stesso UPB");
                    return false;
                }


                // 1. Non esiste un movimento con capienza sufficiente per i dettagli selezionati
                if (ContabilizzazioniDisponibili.Rows.Count == 0) {
                    //string DescrUpb= Conn.DO_READ_VALUE("upb",filterupb,"title").ToString();
                    MessageBox.Show("Non esiste un movimento con capienza sufficiente per i dettagli selezionati");
                    //" (UPB "+DescrUpb+")"); 
                    AbilitaDisabilitaSelezioneMovimento(false);
                    //DS.Estimatedetail.RejectChanges();
                    //ClearMovimento();
                    //radioAddCont.Enabled=false;
                    return false;
                }

                // 2. Sono stati individuati più movimenti per contabilizzare i dettagli selezionati
                // abilito il tasto di selezione 
                if (ContabilizzazioniDisponibili.Rows.Count > 1) {
                    MessageBox.Show(
                        "Esistono più movimenti con capienza sufficiente per i dettagli selezionati. selezionare il movimento");
                    //DS.Estimatedetail.RejectChanges();
                    //ClearMovimento();
                    //radioAddCont.Enabled=false;
                    AbilitaDisabilitaSelezioneMovimento(true);
                    FilterAddCont = filtercont;
                    return true;
                    // Abilitare la selezione
                }

                // 3. E' stato individuato un solo movimento per aggiungere la contabilizzazione,
                // esso viene collegato automaticamente
                if (ContabilizzazioniDisponibili.Rows.Count == 1) {
                    MessageBox.Show("Il movimento è stato determinato automaticamente");
                    AbilitaDisabilitaSelezioneMovimento(false);
                    //DS.Estimatedetail.RejectChanges();
                    //ClearMovimento();
                    //radioAddCont.Enabled=false;
                    //Aggiorna già i dettagli del contratto per collegarli ognuno al proprio movimento
                    foreach (DataRow DetailToLink in FiltraRows(SelectedRows, filterupb)) {
                        DetailToLink[fieldtolink] = ContabilizzazioniDisponibili.Rows[0]["idinc"];
                        if (currcausale == 1) {
                            DetailToLink["idinc_iva"] = ContabilizzazioniDisponibili.Rows[0]["idinc"];
                        }
                        DetailToLink["idupb"] = ContabilizzazioniDisponibili.Rows[0]["idupb"];
                        AutoSelectedMov = ContabilizzazioniDisponibili.Rows[0];
                        MetaData MetaIncMan = MetaData.GetMetaData(this, "incomeestimate");
                        MetaIncMan.SetDefaults(DS.incomeestimate);
                        DS.incomeestimate.Columns["idinc"].DefaultValue = ContabilizzazioniDisponibili.Rows[0]["idinc"];
                        DS.incomeestimate.Columns["movkind"].DefaultValue = currcausale;
                        DataRow IncEstimate = MetaIncMan.Get_New_Row(DS.estimate.Rows[0], DS.incomeestimate);
                        //somethingdone=true;
                        //incomeestimatedone = true;
                    }
                    return true;
                }
                return true;
            }
            if (!chkAddContab.Checked) {
                radioAddCont.Visible = false;
                radioNewCont.Visible = true;
                radioNewCont.Checked = true;
                radioNewLinkedMov.Visible = true;
                // Si desidera creare una nuova contabilizzazione associandola a un movimento esistente 
                // oppure ex novo
                // Per abilitare Collega a un movimento esistente deve 
                // essere un solo clientE e un solo UPB per tutti i dettagli
                if (registry.Length > 1) {
                    labelNewLinkedCont.Text =
                        "Per creare la contabilizzazione su movimento esistente i dettagli selezionati devono avere lo stesso cliente";
                    radioNewLinkedMov.Visible = false;
                    AbilitaDisabilitaSelezioneMovimento(false);
                }
                if (upb.Length > 1) {
                    labelNewLinkedCont.Text =
                        "Per creare la contabilizzazione su movimento esistente i dettagli selezionati devono avere lo stesso UPB";
                    radioNewLinkedMov.Visible = false;
                    AbilitaDisabilitaSelezioneMovimento(false);
                }
                if (fasecontratto == 1) {
                    radioNewLinkedMov.Visible = false;
                    AbilitaDisabilitaSelezioneMovimento(false);
                }
                // L'importo del movimento da collegare deve essere determinato sulla base di 
                // quello digitato dall'utente
                if ((registry.Length == 1) && (upb.Length == 1)) {
                    // Verifico che sia possibile collegare ad un movimento esistente
                    filtercont = "";
                    filtercont = GetData.MergeFilters(filtercont, QHS.CmpGe("available", importoupb));
                    filtercont = GetData.MergeFilters(filtercont, QHS.CmpEq("ayear", esercizio));
                    if (idupb != DBNull.Value) {
                        filtercont = GetData.MergeFilters(filtercont, filterupb_forincome);
                    }
                    int phase = fasecontratto - 1;
                    int fasecred = CfgFn.GetNoNullInt32(Meta.GetSys("incomeregphase"));
                    if (fasecred <= phase) {
                        filtercont = GetData.MergeFilters(filtercont, filteridreg);
                    }
                    filtercont = GetData.MergeFilters(filtercont, QHS.CmpEq("nphase", phase));
                    DataTable MovimentiDisponibili = Conn.RUN_SELECT("incomeview", "*", null, filtercont, null, null,
                        true);
                    if (MovimentiDisponibili.Rows.Count == 0) {
                        radioNewLinkedMov.Visible = false;
                        AbilitaDisabilitaSelezioneMovimento(false);
                    }
                    if (MovimentiDisponibili.Rows.Count >= 1) {
                        radioNewLinkedMov.Visible = true;
                        AbilitaDisabilitaSelezioneMovimento(true);
                    }
                }
            }
            return true;
        }

        string idinc_selected;

        void FillMovimento(DataRow income) {
            idinc_selected = income["idinc"].ToString();
            txtNumeroMovimento.Text = income["nmov"].ToString();
            txtEsercizioMovimento.Text = income["ymov"].ToString();
            txtDescrizione.Text = income["description"].ToString();
            txtResponsabile.Text = income["manager"].ToString();
            SubEntity_txtImportoMovimento.Text = CfgFn.GetNoNullDecimal(income["amount"]).ToString("c");
            txtDataCont.Text = ((DateTime) income["adate"]).ToShortDateString();
            txtCodiceBilancio.Text = income["codefin"].ToString();
            txtDenominazioneBilancio.Text = income["finance"].ToString();
            txtUPB.Text = income["codeupb"].ToString();
            txtDescrUPB.Text = income["upb"].ToString();
            txtImportoCorrente.Text = CfgFn.GetNoNullDecimal(income["curramount"]).ToString("c");
            txtImportoDisponibile.Text = CfgFn.GetNoNullDecimal(income["available"]).ToString("c");
        }

        void ClearMovimento() {
            idinc_selected = null;
            txtNumeroMovimento.Text = "";
            txtEsercizioMovimento.Text = "";
            txtDescrizione.Text = "";
            txtResponsabile.Text = "";
            SubEntity_txtImportoMovimento.Text = "";
            txtDataCont.Text = "";
            txtCodiceBilancio.Text = "";
            txtDenominazioneBilancio.Text = "";
            txtUPB.Text = "";
            txtDescrUPB.Text = "";
            txtImportoCorrente.Text = "";
            txtImportoDisponibile.Text = "";
        }


        string filterMovimento;

        void AbilitaDisabilitaSelezioneMovimento(bool enable) {
            gboxMovimento.Enabled = enable;
        }

        private void btnSelectMov_Click(object sender, System.EventArgs e) {
            //se true, deve visualizzare anche contratti attivi contabilizzati (genericamente)
            bool allEstimate = chkAddContab.Checked;
            int esercizio = (int) Meta.GetSys("esercizio");
            string filter = QHS.CmpEq("ayear", esercizio);
            filter = GetData.MergeFilters(filter, filterMovimento);

            int esercText = CfgFn.GetNoNullInt32(txtEsercizioMovimento.Text);
            if (esercText > 0) //esercText=esercizio; 
                filter = GetData.MergeFilters(filter, QHS.CmpEq("ymov", esercText));

            if ((!sender.Equals(btnSelectMov)) && txtNumeroMovimento.Text.Trim() != "") {
                int nmov = CfgFn.GetNoNullInt32(txtNumeroMovimento.Text);
                if (nmov > 0) filter = GetData.MergeFilters(filter, QHS.CmpEq("nmov", nmov));
            }
            int phase;
            if (radioAddCont.Checked)
                phase = fasecontratto;
            else
                phase = fasecontratto - 1;

            filter = GetData.MergeFilters(filter, QHS.CmpEq("nphase", phase));
            MetaData incomeToConsider;
            incomeToConsider = MetaData.GetMetaData(this, "income");
            incomeToConsider.FilterLocked = true;
            incomeToConsider.DS = new DataSet();
            DataRow M = incomeToConsider.SelectOne("default", filter, null, null);
            if (M == null) return;
            FillMovimento(M);
            idinc_selected = M["idinc"].ToString();
            SelezioneMovimentiEffettuata = true;
        }

        private void radioAddCont_CheckedChanged(object sender, System.EventArgs e) {
            if (radioAddCont.Checked) SetAddCont();
            labelAddCont.Visible = radioAddCont.Checked;
        }

        private void radioNewCont_CheckedChanged(object sender, System.EventArgs e) {
            if (radioNewCont.Checked) SetNewMov();
        }

        void SetAddCont() {
            if (FilterAddCont != null) {
                AbilitaDisabilitaSelezioneMovimento(true);
                filterMovimento = FilterAddCont;
                SelezioneMovimentiEffettuata = false;
                labMsgTODO1.Text = "I dettagli selezionati saranno aggiunti al movimento selezionato";
                labMsgTODO2.Text = "";
            }
            else {
                AbilitaDisabilitaSelezioneMovimento(false);
                filterMovimento = null;
                SelezioneMovimentiEffettuata = true;
                labMsgTODO1.Text = "I dettagli selezionati saranno aggiunti al movimento selezionato automaticamente";
                labMsgTODO2.Text = "";
            }
            if (AutoSelectedMov != null) FillMovimento(AutoSelectedMov);

            string filterfase = QHS.CmpEq("nphase", fasecontratto);
            string descfasecontratto = "";
            descfasecontratto = Conn.DO_READ_VALUE("incomephase", filterfase, "description").ToString();
            if (descfasecontratto != "") {
                gboxMovimento.Text = descfasecontratto;
            }

        }

        void SetNewMov() {
            ClearMovimento();
            AbilitaDisabilitaSelezioneMovimento(false);
            SelezioneMovimentiEffettuata = true; //!!
            int primafaseentrata = 1;
            string filterfase = QHS.CmpEq("nphase", primafaseentrata);
            string descfase = "";
            descfase = Conn.DO_READ_VALUE("incomephase", filterfase, "description").ToString();
            if (descfase != "") {
                gboxMovimento.Text = descfase;
            }

        }

        void SetNewLinkedMov() {
            DataRow Estim = DS.estimate.Rows[0];
            DataRow[] Selected = GetGridSelectedRows(gridDetails);
            string filterregistry = "";
            string filteridunderwriting = "";

            object[] registry = ValoriDiversi(Selected, "idreg");
            DataTable EstimateKind = Conn.RUN_SELECT("estimatekind", "*", null,
                QHS.CmpEq("idestimkind", Estim["idestimkind"]), null, null, true);
            // In base alla configurazione del tipo contratto, prendo il cliente del contratto
            // oppure i clienti dei vari dettagli
            if (EstimateKind.Rows.Count > 0) {
                string multiReg = EstimateKind.Rows[0]["multireg"].ToString();
                if (multiReg == "N") {
                    // Anagrafe nel contratto
                    filterregistry = QHS.CmpEq("idreg", Estim["idreg"]);
                }
                else {
                    if ((Selected != null) || (GetGridSelectedRows(gridDetails).Length != 0)) {
                        filterregistry = QHS.CmpEq("idreg", registry[0]); //primo dettaglio
                    }
                }
            }
            if (Estim["idunderwriting"] != DBNull.Value) {
                filteridunderwriting = QHS.CmpEq("idunderwriting", Estim["idunderwriting"]);
            }
            int fasecred = CfgFn.GetNoNullInt32(Meta.GetSys("incomeregphase"));
            int fasebilancio = CfgFn.GetNoNullInt32(Meta.GetSys("incomefinphase"));

            int currcausale = CfgFn.GetNoNullInt32(cmbCausale.SelectedValue);
            if (currcausale == 1) {
                decimal importototale = CfgFn.GetNoNullDecimal(HelpForm.GetObjectFromString(typeof (Decimal),
                    txtTotGenerale.Text, "x.y.c"));
                //if (importototale!=TotaleDaContabilizzare) TotaleDaContabilizzare = importototale;
            }
            if (currcausale == 3) {
                decimal importoimponibile = CfgFn.GetNoNullDecimal(HelpForm.GetObjectFromString(typeof (Decimal),
                    txtTotImponibile.Text, "x.y.c"));
                //if (importoimponibile!=TotaleDaContabilizzare) TotaleDaContabilizzare = importoimponibile;
            }
            if (currcausale == 2) {
                decimal importoiva = CfgFn.GetNoNullDecimal(HelpForm.GetObjectFromString(typeof (Decimal),
                    txtTotIva.Text, "x.y.c"));
                //if (importoiva!=TotaleDaContabilizzare) TotaleDaContabilizzare = importoiva;
            }

            decimal ImportoDaIncassare = CfgFn.GetNoNullDecimal(
                HelpForm.GetObjectFromString(typeof (decimal),
                    txtDaIncassare.Text, "x.y.c"));
            if ((ImportoDaIncassare != 0) && (ImportoDaIncassare < TotaleDaContabilizzare)) {
                filterMovimento = QHS.CmpGe("available", ImportoDaIncassare);
            }
            else {
                filterMovimento = QHS.CmpGe("available", TotaleDaContabilizzare);
            }

            filterMovimento = GetData.MergeFilters(filterMovimento, QHS.CmpEq("nphase", fasecontratto - 1));

            if (fasecred <= fasecontratto - 1) {
                filterMovimento = GetData.MergeFilters(filterregistry, filterMovimento);
            }
            if (fasebilancio <= fasecontratto - 1) {
                if ((Selected != null) || (GetGridSelectedRows(gridDetails).Length != 0)) {
                    DataRow EstimDett = Selected[0];
                    //if (EstimDett["idupb"] != DBNull.Value)
                    //{
                    //    filterMovimento = QHS.AppAnd(QHS.CmpEq("idupb", EstimDett["idupb"]), filterMovimento);
                    //}
                    object[] upb = ValoriDiversi(Selected, "idupb");
                    object[] upb_iva = ValoriDiversi(Selected, "idupb_iva");
                    string field = "idupb";
                    int causale = CfgFn.GetNoNullInt32(cmbCausale.SelectedValue);
                    if (causale == 2) {
                        if (upb_iva.Length > 1 || upb_iva[0] != DBNull.Value) {
                            upb = upb_iva;
                            field = "idupb_iva";
                        }
                    }
                    if (EstimDett[field] != DBNull.Value) {
                        filterMovimento = QHS.AppAnd(filterMovimento, QHS.CmpEq("idupb", EstimDett[field]));
                    }
                }
            }
            if (fasebilancio <= fasecontratto - 1 && filteridunderwriting != "") {
                filterMovimento = GetData.MergeFilters(filteridunderwriting, filterMovimento);
            }

            ClearMovimento();
            AbilitaDisabilitaSelezioneMovimento(true);
            SelezioneMovimentiEffettuata = false;
            labMsgTODO1.Text = "Sarà creato un nuovo movimento di entrata";

            if (fasecontratto > 1) {
                int faseprecedente = fasecontratto - 1;
                string filterfase = QHS.CmpEq("nphase", faseprecedente);
                string descfaseprecedente = "";
                descfaseprecedente = Conn.DO_READ_VALUE("incomephase", filterfase, "description").ToString();
                if (descfaseprecedente != "") {
                    gboxMovimento.Text = descfaseprecedente;
                }
            }
        }

        void RadioCheck_Changed() {
            if (radioAddCont.Checked) SetAddCont();
            if (radioNewCont.Checked) SetNewMov();
            if (radioNewLinkedMov.Checked) SetNewLinkedMov();
        }

        private void txtEsercizioMovimento_Leave(object sender, System.EventArgs e) {
            if (txtEsercizioMovimento.ReadOnly == true) return;
            int Ymov = CfgFn.GetNoNullInt32(txtEsercizioMovimento.Text);
            if (Ymov <= 0) {
                ClearMovimento();
                SelezioneMovimentiEffettuata = false;
                return;
            }
            if (Ymov < 1000) {
                Ymov += 2000;
                txtEsercizioMovimento.Text = Ymov.ToString();
            }
            if (txtNumeroMovimento.Text.Trim() != "") {
                btnSelectMov_Click(sender, e);
                return;
            }

        }

        private void txtNumeroMovimento_Leave(object sender, System.EventArgs e) {
            int NMov = CfgFn.GetNoNullInt32(txtNumeroMovimento.Text);
            if (NMov <= 0) {
                ClearMovimento();
                return;
            }
            if (txtEsercizioMovimento.Text.Trim() != "") {
                btnSelectMov_Click(sender, e);
                return;
            }
        }

        private void radioNewLinkedMov_CheckedChanged(object sender, System.EventArgs e) {
            if (radioNewLinkedMov.Checked) SetNewLinkedMov();
        }


        object idmanagerSelected;
        object idunderwritingSelected;
        object idUPBSelected;
        object idfinSelected;

        Dictionary<int, object> voci_bilancio_entrata = new Dictionary<int, object>();
        object GetBilancioFromCausaleFin(object idfinmotive, out string errori)
        {
            errori = "";
            if (idfinmotive == DBNull.Value || idfinmotive == null)

            {
                errori = " Causale finanziaria non trovata";
                return DBNull.Value;
            }

            int idfinmotive_i = CfgFn.GetNoNullInt32(idfinmotive);
            if (idfinmotive_i == 0) return null;
            if (voci_bilancio_entrata.ContainsKey(idfinmotive_i)) return voci_bilancio_entrata[idfinmotive_i];
            string filterEsercizio = QHS.CmpEq("ayear", Meta.GetSys("esercizio"));
            string filter = QHS.AppAnd(QHS.CmpEq("idfinmotive", idfinmotive), filterEsercizio);
            DataTable t = Conn.SQLRunner(
                "select idfin " +
                " from finmotivedetail  " +
                " where " + filter, false);
            if (t.Rows.Count == 0)
            {
                errori = "Voce di bilancio associata alla causale finanziaria non trovata";
                return DBNull.Value;
            }
            else
            {
                voci_bilancio_entrata[idfinmotive_i] = t.Rows[0]["idfin"];
                return voci_bilancio_entrata[idfinmotive_i];
            }

        }

        bool CheckInfoFin() {
            idUPBSelected = null;
            if (radioAddCont.Checked) {
                gboxBilToCreate.Visible = false;
                return true; //movimento esistente!
            }
            if (radioNewLinkedMov.Checked) {
                //Prende il creditore ed il responsabile dall'Contratto, quindi non ha bisogno di nulla!!
                int fasebilancio = CfgFn.GetNoNullInt32(Meta.GetSys("incomefinphase"));
                if (fasecontratto - 1 >= fasebilancio) {
                    gboxBilToCreate.Visible = false;
                    return true;
                }
                //Se passa di qui deve creare un nuovo mov. di entrata, agganciandolo ad una fase s
                // in cui non è prevista l'informazione del bilancio
            }
            // Amount può essere il totale da contabilizzare oppure l'importo digitato dall'utente
            decimal amount = 0;
            decimal ImportoDaIncassare = CfgFn.GetNoNullDecimal(
                HelpForm.GetObjectFromString(typeof (decimal),
                    txtDaIncassare.Text, "x.y.c"));
            if ((ImportoDaIncassare != 0) && (ImportoDaIncassare < TotaleDaContabilizzare)) {
                amount = ImportoDaIncassare;
            }
            else {
                amount = TotaleDaContabilizzare;
            }

            if (DS.estimate.Rows.Count == 0) {
                MessageBox.Show("Nessun contratto selezionato", "Errore");
                return false;
            }
            DataRow CurrEstimate = DS.estimate.Rows[0];


            if (CurrEstimate["idunderwriting"] == DBNull.Value)
                idunderwritingSelected = DBNull.Value;
            else
                idunderwritingSelected = CurrEstimate["idunderwriting"];


            DataRow[] Selected = GetGridSelectedRows(gridDetails);
            object idupb = DBNull.Value;
            object[] upb = ValoriDiversi(Selected, "idupb");
            object[] upb_iva = ValoriDiversi(Selected, "idupb_iva");
            string field = "idupb";
            int causale = CfgFn.GetNoNullInt32(cmbCausale.SelectedValue);
            if (causale == 2) {
                if (upb_iva.Length > 1 || upb_iva[0] != DBNull.Value) {
                    upb = upb_iva;
                    field = "idupb_iva";
                }
            }
            string filter = QHS.IsNull(field);
            if ((FiltraRows(Selected, filter).Count > 0) && (upb.Length == 2)) {
                object idupbtoassign = DBNull.Value;
                List<DataRow> Details = FiltraRows(Selected, QHC.IsNotNull(field));
                if (Details.Count > 0) idupbtoassign = Details[0][field];
                object[] result = new object[] { idupbtoassign };                
                upb = result;
            }
            object idman_start = CurrEstimate["idman"];
            bool manager_in_details = false;
            if (upb.Length == 1) {
                if (upb[0].ToString() != "") idupb = upb[0];
            }
            else {
                foreach (object myidupb in upb) {
                    object idman_mydetail = Conn.DO_READ_VALUE("upb", QHS.CmpEq("idupb", myidupb), "idman");
                    if (idman_mydetail != DBNull.Value) manager_in_details = true;
                }
                if (manager_in_details) idman_start = DBNull.Value; //idman_start=null significa idman BLOCCATO 
            }
            //string filterupb = null;
            if (idupb.ToString() == "") idupb = DBNull.Value;
            if (idupb != DBNull.Value) {
                //object idman_detail = DS.upb.Select(filterupb)[0]["idman"];
                object idman_detail = Conn.DO_READ_VALUE("upb", QHS.CmpEq("idupb", idupb), "idman");
                if (idman_detail != DBNull.Value) idman_start = idman_detail;
            }
            bool upbToSelect = true;
            if (FiltraRows(Selected, QHC.IsNull(field)).Count == 0 || idupb != DBNull.Value) {
                // Se contabilizzo separatamente l'IVA oppure l'imponibile si deve dare la possibilità  
                // di selezionare   UPB diversi
                upbToSelect = false;
            }

            FrmAskInfo F = new FrmAskInfo(Meta, "E", upbToSelect)
                .SetUPB(idupb)
                .EnableFilterAvailable(amount)
                .SetManager(idman_start)
                .EnableUPBSelection(upbToSelect);

            //bool fin_in_details = false;
            if (manager_in_details)
                F.EnableManagerSelection(false);
            else
                F.AllowNoManagerSelection(true);

            //if (manager_in_details)
            //    F.AllowNoFinSelection(false);
            //else
            //    F.AllowNoFinSelection(true);

            
            //"E", filterupb, Meta.Dispatcher, idman_start, amount, upbToSelect);
            if (F.ShowDialog(this) != DialogResult.OK) return false;

            if (idman_start == DBNull.Value)
                idmanagerSelected = DBNull.Value;
            else
                idmanagerSelected = F.GetManager();

            idUPBSelected = F.GetUPB();
            idfinSelected = F.GetFin();
            F.Destroy();
            DataTable T = Conn.RUN_SELECT("fin", "*", null, QHS.CmpEq("idfin", idfinSelected), null, false);
            DataRow RB = T.Rows[0];
            txtCodeBilSelected.Text = RB["codefin"].ToString();
            txtDenomBilSelected.Text = RB["title"].ToString();
            gboxBilToCreate.Visible = true;
            return true;
        }

        private void tabController_SelectionChanged(object sender, System.EventArgs e) {
            // seleziona una delle tre opzioni in base alla fase di contabilizzazione
            if (tabController.SelectedIndex == 2 && (!chkAddContab.Checked) && SelezioneMovimentiEffettuata) {
                if (fasecontratto == 1 && radioNewCont.Visible) {
                    radioNewCont.Checked = true;
                }
                else {
                    if (fasecontratto > 1 && radioNewLinkedMov.Visible) {
                        radioNewLinkedMov.Checked = true;
                    }
                    else {
                        if (radioNewCont.Visible)
                            radioNewCont.Checked = true;
                        else if (radioAddCont.Enabled)
                            radioAddCont.Checked = true;
                    }
                }
            }
        }

        bool doAssocia() {
            if (radioNewCont.Checked) {
                //DS.estimatedetail.RejectChanges();
                DS.income.Clear();
                DS.incomeyear.Clear();
                DS.incomeestimate.Clear();
                DS.incomelast.Clear();
                return doSaveNewIncome(null);
            }
            if (radioNewLinkedMov.Checked) {
                //DS.estimatedetail.RejectChanges();
                DS.income.Clear();
                DS.incomeyear.Clear();
                DS.incomeestimate.Clear();
                DS.incomelast.Clear();
                return doSaveNewIncome(idinc_selected);
            }
            if (radioAddCont.Checked) {
                DS.incomeestimate.Clear();
                DS.incomeyear.Clear();
                DS.income.Clear();
                DS.incomelast.Clear();
                return doAddConta();
            }
            return false;
        }

        bool doAssociaSoloDettagli() {
            int esercizio = Convert.ToInt32(Meta.GetSys("esercizio"));
            string filteridinc = QHS.CmpEq("idinc", idinc_selected);
            Conn.RUN_SELECT_INTO_TABLE(DS.income, null, filteridinc, null, false);
            Conn.RUN_SELECT_INTO_TABLE(DS.incomeyear, null,
                QHS.AppAnd(filteridinc, QHS.CmpEq("ayear", esercizio)), null, false);
            Conn.RUN_SELECT_INTO_TABLE(DS.incomesorted, null,
                QHS.AppAnd(filteridinc, QHS.CmpEq("ayear", esercizio)), null, false);
            int currcausale = CfgFn.GetNoNullInt32(cmbCausale.SelectedValue);
            DataRow[] Selected = GetGridSelectedRows(gridDetails);
            //DataRow []Details = FiltraRows(Selected,null);
            string listRownum = "(";
            foreach (int rownum in DetailsToUpdate) {
                listRownum += rownum.ToString() + ",";
            }
            listRownum = listRownum.Substring(0, listRownum.Length - 1) + ")";
            string filterDetails = null;
            if (listRownum != "") filterDetails = "(rownum in " + listRownum + ")";
            DataRow[] Details = DS.estimatedetail.Select(filterDetails);
            foreach (DataRow R in Details) {
                switch (currcausale) {
                    case 1:
                        R["idinc_taxable"] = idinc_selected;
                        R["idinc_iva"] = idinc_selected;
                        break;
                    case 3:
                        R["idinc_taxable"] = idinc_selected;
                        break;
                    case 2:
                        R["idinc_iva"] = idinc_selected;
                        break;
                }
            }
            AggiornaUPBDettagli(Details);

            if (DS.incomeyear.Rows[0]["idupb"] != DBNull.Value)
                idUPBSelected = DS.incomeyear.Rows[0]["idupb"];

            return doSave();
        }

        bool doSave() {
            DataSet DSP = DS.Copy();
            int faseentratamax = CfgFn.GetNoNullInt32(Meta.GetSys("maxincomephase"));
            GestioneAutomatismi ga = new GestioneAutomatismi(this, Meta.Conn, Meta.Dispatcher,
                DSP, faseentratamax, faseentratamax, "income", true);
            ga.GeneraClassificazioniAutomatiche(ga.DSP, true);
            //ga.GeneraClassificazioniIndirette(ga.DSP, true); lo fa già GeneraClassificazioniAutomatiche
            bool res = ga.GeneraAutomatismiAfterPost(true);
            if (!res) {
                MessageBox.Show(this,
                    "Si è verificato un errore o si è deciso di non salvare! L'operazione sarà terminata");
                return false;
            }
            res = ga.doPost(Meta.Dispatcher);
            if (res) ViewAutomatismi(ga.DSP);
            if (!res) {
                return false;
            }
            DS.AcceptChanges();
            DS.incomeestimate.Clear();
            DS.estimatedetail.Clear();
            DS.incomelast.Clear();
            DS.income.Clear();
            DS.incomeyear.Clear();
            DS.registry.Clear();
            DetailsToUpdate.Clear();
            return true;
        }

        void ViewAutomatismi(DataSet DS) {
            string entrata = null;
            if (DS.Tables["income"] != null) {
                DataTable Var = DS.Tables["income"];
                if (DS.Tables["income"].Select().Length == 0) return;
                entrata = QHS.FieldIn("idinc", Var.Select(), "idinc");
            }
            Form F = ShowAutomatismi.Show(Meta, null, entrata, null, null);
            F.ShowDialog(this);
        }

        bool doAddConta() {
            //Crea la riga in incomeestimate
            //Non solo deve associare i dettagli, ma deve anche creare la righe in incomeestimate
            //if (!incomeestimatedone) {
            MetaData IncEstim = MetaData.GetMetaData(this, "incomeestimate");
            DataRow Estim = DS.estimate.Rows[0];
            MetaData.SetDefault(DS.incomeestimate, "idinc", idinc_selected);
            IncEstim.SetDefaults(DS.incomeestimate);
            DataRow M = IncEstim.Get_New_Row(Estim, DS.incomeestimate);
            M["movkind"] = cmbCausale.SelectedValue;
            //}
            return doAssociaSoloDettagli();
        }

        /// <summary>
        /// Riempie i dati di una riga di entata o entrata prendendoli dall'automatismo e dall'
        ///  IDmovimento in ingresso
        /// </summary>
        /// <param name="E_S"></param>
        /// <param name="Auto"></param>
        /// <param name="Currentrata"></param>
        void FillMovimento(DataRow E_S, decimal amount, object idman, object idunderwriting, int idreg,
            string description) {
            int esercizio = Convert.ToInt32(Meta.GetSys("esercizio"));
            DateTime DataCont = Convert.ToDateTime(Meta.GetSys("datacontabile"));
            E_S.BeginEdit();
            E_S["ymov"] = esercizio;
            E_S["adate"] = DataCont;
            E_S["idman"] = idman;
            E_S["idunderwriting"] = idunderwriting;
            E_S["idreg"] = idreg;
            E_S["description"] = description;
            //E_S["amount"]=CfgFn.RoundValuta(amount);
            E_S.EndEdit();
        }


        void FillImputazioneMovimento(DataRow ImpMov, decimal amount, object idfin, object idupb) {
            ImpMov["amount"] = amount;
            ImpMov["idfin"] = idfin;
            ImpMov["idupb"] = idupb;
        }

        bool doSaveNewIncome(string idparent) {
            //			int fasecontratto= CfgFn.GetNoNullInt32( Meta.GetSys("Estimatephase"));
            int fasecred = CfgFn.GetNoNullInt32(Meta.GetSys("incomeregphase"));
            int fasebilancio = CfgFn.GetNoNullInt32(Meta.GetSys("incomefinphase"));
            int faseentratamax = CfgFn.GetNoNullInt32(Meta.GetSys("maxincomephase"));
            int faseinizio;
            int fasefine;
            if (idparent == null) {
                faseinizio = 1;
                fasefine = fasecontratto;
            }
            else {
                faseinizio = fasecontratto;
                fasefine = fasecontratto;
            }

            MetaData Inc = MetaData.GetMetaData(this, "income");
            MetaData IncY = MetaData.GetMetaData(this, "incomeyear");
            MetaData IncL = MetaData.GetMetaData(this, "incomelast");
            MetaData IncEstimate = MetaData.GetMetaData(this, "incomeestimate");
            MetaData EstimateDetail = MetaData.GetMetaData(this, "estimatedetail");
            Inc.SetDefaults(DS.income);
            IncY.SetDefaults(DS.incomeyear);
            IncL.SetDefaults(DS.incomelast);
            IncEstimate.SetDefaults(DS.incomeestimate);
            EstimateDetail.SetDefaults(DS.estimatedetail);


            if (idparent != null) MetaData.SetDefault(DS.income, "parentidinc", idparent);
            else MetaData.SetDefault(DS.income, "parentidinc", DBNull.Value);

            DataRow[] SelectedRows = GetGridSelectedRows(gridDetails);
            AggiornaUPBDettagli(SelectedRows);
            object[] upb = ValoriDiversi(SelectedRows, "idupb");
            object[] upbiva = ValoriDiversi(SelectedRows, "idupb_iva");
            string field_upb = "idupb";
            int currcausale = CfgFn.GetNoNullInt32(cmbCausale.SelectedValue);
            if (currcausale == 2) {
                if (upbiva.Length > 1 || upbiva[0] != DBNull.Value) {
                    upb = upbiva;
                    field_upb = "idupb_iva";
                }
            }


            if (upb.Length == 2) {
                object idupb1 = upb[0];
                object idupb2 = upb[1];
                if (idupb1 != DBNull.Value && idupb2 == DBNull.Value) {
                    object[] result = new object[1];
                    result[0] = idupb1;
                    upb = result;
                }
                else if (idupb1 == DBNull.Value && idupb2 != DBNull.Value) {
                    object[] result = new object[1];
                    result[0] = idupb2;
                    upb = result;
                }
            }

            object[] registry = ValoriDiversi(SelectedRows, "idreg");
            DataTable Mov = DS.income;
            DataTable ImpMov = DS.incomeyear;
            DataTable LastMov = DS.incomelast;
            DataRow Estimate = DS.estimate.Rows[0];

            DataTable EstimateKind = Conn.RUN_SELECT("estimatekind", "*", null,
                QHS.CmpEq("idestimkind", Estimate["idestimkind"]), null, null, true);
            // in base alla configurazione del tipo ESTIMe, prendo il fornitore dell'ESTIMe
            // oppure i fornitori dei vari dettagli
            if (EstimateKind.Rows.Count > 0) {
                string multiReg = EstimateKind.Rows[0]["multireg"].ToString();
                if (multiReg == "N") {
                    // Anagrafe nell'ESTIMe
                    registry[0] = Estimate["idreg"];
                }
            }
            int esercizio = CfgFn.GetNoNullInt32(Meta.GetSys("esercizio"));

            object idunderwritingSelected = DBNull.Value;
            MetaData.SetDefault(DS.incomeyear, "ayear", esercizio);
            bool ExistMan_parent = false;
            if (idparent != null) {
                MetaData.SetDefault(DS.income, "parentidinc", idparent);
                DataTable IncomeYear = Conn.RUN_SELECT("incomeyear", "*", null,
                    QHS.AppAnd(QHS.CmpEq("idinc", idparent), QHS.CmpEq("ayear", esercizio)),
                    null, null, false);


                object idincfinphase = Meta.Conn.DO_READ_VALUE("incomelink",
                    QHS.AppAnd(QHS.CmpEq("idchild", idparent), QHS.CmpEq("nlevel", fasebilancio)), "idparent");

                object idunderwriting = Meta.Conn.DO_READ_VALUE("income",
                    QHS.CmpEq("idinc", idincfinphase), "idunderwriting");

                DataRow ParIncY = IncomeYear.Rows[0];
                if (ParIncY["idfin"] != DBNull.Value) idfinSelected = ParIncY["idfin"];
                if (ParIncY["idupb"] != DBNull.Value) idUPBSelected = ParIncY["idupb"];
                if ((idunderwriting != DBNull.Value) && (idunderwriting != null))
                    idunderwritingSelected = idunderwriting;

                DataRow CurrEstimate = DS.estimate.Rows[0];
                object idman_start = CurrEstimate["idman"];
                object idman_parent = Conn.DO_READ_VALUE("income", QHS.CmpEq("idinc", idparent), "idman");

                if ((idmanagerSelected == null) || (idmanagerSelected == DBNull.Value)) idmanagerSelected = idman_start;
                if ((idmanagerSelected == null) || (idmanagerSelected == DBNull.Value))
                    idmanagerSelected = idman_parent;
                if ((idmanagerSelected == null) || (idmanagerSelected == DBNull.Value)) {
                    ExistMan_parent = false;
                }
                else {
                    ExistMan_parent = true;
                }

            }

            if (idunderwritingSelected == DBNull.Value) {
                if (Estimate["idunderwriting"] != DBNull.Value) {
                    idunderwritingSelected = Estimate["idunderwriting"];
                }
            }
            foreach (object idupb in upb) {
                if (!ExistMan_parent) {
                    idmanagerSelected = DBNull.Value;
                }
                string filterupbnew = "";
                string filterinvdetoriginal = "";
                object idupbManager;

                if (idupb == DBNull.Value) {
                    filterinvdetoriginal = QHS.IsNull(field_upb);
                    idupbManager = idUPBSelected;
                }
                else {
                    if (field_upb == "idupb_iva") {
                        filterinvdetoriginal = QHS.CmpEq("isnull(idupb_iva,idupb)", idupb);

                    }
                    else {
                        filterinvdetoriginal = QHS.CmpEq(field_upb, idupb);
                    }
                    idupbManager = idupb;
                }

                object idmanagerupb ;
                idmanagerupb = Conn.DO_READ_VALUE("upb", QHS.CmpEq("idupb", idupbManager), "idman");

                if ((idmanagerSelected == null) || (idmanagerSelected == DBNull.Value))idmanagerSelected = idmanagerupb;
                if (idmanagerSelected == null) idmanagerSelected = DBNull.Value;

                foreach (object idreg in registry) {
                    if (idreg == DBNull.Value) continue;
                    int codicereg = CfgFn.GetNoNullInt32(idreg);
                    string filterregistry = QHS.CmpEq("idreg", idreg);

                    DS.registry.Clear();
                    Conn.RUN_SELECT_INTO_TABLE(DS.registry, null, filterregistry, null, true);
                    string title = DS.registry.Rows[0]["title"].ToString();

                    string filterdetail = "";
                    string filter = GetData.MergeFilters(filterinvdetoriginal, filterregistry);

                    if (EstimateKind.Rows.Count > 0) {
                        string multiReg = EstimateKind.Rows[0]["multireg"].ToString();
                        if (multiReg == "N") {
                            // Anagrafe nell'ESTIMe
                            filterdetail = filterinvdetoriginal;
                        }
                        else {
                            filterdetail = filter;
                        }
                    }

                    decimal amount = CalcTotCausale(FiltraRows(SelectedRows, filterdetail).ToArray(), currcausale, genMultipla);
                    if (amount == 0) continue;
                    DataRow ParentR = null;
                    DataRow IncomeToLink = null;

                    for (int faseCorrente = faseinizio; faseCorrente <= fasefine; faseCorrente++) {
                        Mov.Columns["nphase"].DefaultValue = faseCorrente;

                        DataRow NewEntrataRow = Inc.Get_New_Row(ParentR, Mov);
                        if (faseCorrente == fasecontratto) IncomeToLink = NewEntrataRow;
                        ParentR = NewEntrataRow;

                        FillMovimento(NewEntrataRow, amount, idmanagerSelected, idunderwritingSelected, codicereg,
                            Estimate["description"].ToString());


                        NewEntrataRow["doc"] = "C.A." +
                                               Estimate["idestimkind"].ToString() + "/" +
                                               Estimate["yestim"].ToString().Substring(2, 2) + "/" +
                                               Estimate["nestim"].ToString().PadLeft(6, '0');
                        //"Ord."+ValoriESTIMe["documento"];
                        NewEntrataRow["docdate"] = Estimate["adate"];

                        NewEntrataRow["nphase"] = faseCorrente;
                        NewEntrataRow["idunderwriting"] = idunderwritingSelected;


                        if (faseCorrente < fasecred) {
                            NewEntrataRow["idreg"] = DBNull.Value;
                        }
                        else {
                            NewEntrataRow["idreg"] = codicereg;
                        }

                        DataRow NewImpMov = ImpMov.NewRow();

                        if (idupb != DBNull.Value) {
                            FillImputazioneMovimento(NewImpMov, amount, idfinSelected, idupb);
                        }
                        else {
                            FillImputazioneMovimento(NewImpMov, amount, idfinSelected, idUPBSelected);
                        }
                        NewImpMov["idinc"] = NewEntrataRow["idinc"];
                        NewImpMov["ayear"] = esercizio;

                        if (faseCorrente < fasebilancio) {
                            NewImpMov["idfin"] = DBNull.Value;
                            NewImpMov["idupb"] = DBNull.Value;
                        }
                        ImpMov.Rows.Add(NewImpMov);

                        if (faseCorrente == faseentratamax) {
                            DataRow NewLastMov = IncL.Get_New_Row(NewEntrataRow, LastMov);
                        }
                    }

                    //Aggiunge la riga in IncomeEstimate
                    DataRow IncEstimRow = IncEstimate.Get_New_Row(IncomeToLink, DS.incomeestimate);
                    IncEstimRow["movkind"] = currcausale;
                    IncEstimRow["idestimkind"] = Estimate["idestimkind"];
                    IncEstimRow["yestim"] = Estimate["yestim"];
                    IncEstimRow["nestim"] = Estimate["nestim"];

                    //Effettua i collegamenti con i dettagli

                    //DataRow []Details = FiltraRows(SelectedRows,filterdetail);
                    string listRownum = "(";
                    foreach (int rownum in DetailsToUpdate) {
                        listRownum += rownum.ToString() + ",";
                    }
                    listRownum = listRownum.Substring(0, listRownum.Length - 1) + ")";
                    string filterToUpdate = null;
                    if (listRownum != "") filterToUpdate = "(rownum in " + listRownum + ")";
                    DataRow[] RowsToUpdate = DS.estimatedetail.Select(filterToUpdate);
                    List<DataRow> Details = FiltraRows(RowsToUpdate, filterdetail);

                    foreach (DataRow RD in Details) {
                        switch (currcausale) {
                            case 1:
                                RD["idinc_taxable"] = IncomeToLink["idinc"];
                                RD["idinc_iva"] = IncomeToLink["idinc"];
                                break;
                            case 3:
                                RD["idinc_taxable"] = IncomeToLink["idinc"];
                                break;
                            case 2:
                                RD["idinc_iva"] = IncomeToLink["idinc"];
                                break;
                        }
                    }
                    // Associa l'UPB ai dettagli sui quali non era stato impostato
                    if (currcausale == 1) // solo in caso di contabilizzazione totale
                    {
                        List<DataRow> DetailsUPBNull = FiltraRows(Details.ToArray(), "(idupb is null)");
                        foreach (DataRow RD1 in DetailsUPBNull) {
                            RD1["idupb"] = idUPBSelected;
                        }
                    }

                }
            }
            //Effettua il post

            return doSave();
        }


        void DisplayMessages() {
        }

        private void cmbTipoContratto_SelectedIndexChanged(object sender, System.EventArgs e) {
            if (Meta == null) return;
            if (!Meta.DrawStateIsDone) return;
            ClearContratto();
            return;

        }

        void AggiornaUPBDettagli(DataRow[] SelectedRows) {
            object[] upb = ValoriDiversi(SelectedRows, "idupb");
            object[] upb_iva = ValoriDiversi(SelectedRows, "idupb_iva");
            string field = "idupb";
            int causale = CfgFn.GetNoNullInt32(cmbCausale.SelectedValue);
            if (causale == 2) {
                if (upb_iva.Length > 1 || upb_iva[0] != DBNull.Value) {
                    upb = upb_iva;
                    field = "idupb_iva";
                }
            }
            string filterupbnull = QHC.IsNull(field);
            if ((FiltraRows(SelectedRows, filterupbnull).Count > 0) && (upb.Length == 2)) {
                object idupbtoassign = DBNull.Value;
                List<DataRow> Details = FiltraRows(SelectedRows, QHC.IsNotNull(field));
                if (Details.Count > 0) idupbtoassign = Details[0][field];
                foreach (DataRow Curr in FiltraRows(SelectedRows, filterupbnull)) {
                    Curr[field] = idupbtoassign;
                }

            }
        }

        private void txtTotImponibile_Leave(object sender, System.EventArgs e) {
            //AggiornaTotSelezione(sender);
        }

        private void txtTotIva_Leave(object sender, System.EventArgs e) {
            //AggiornaTotSelezione(sender);
        }

        void AggiornaTotSelezione(object sender) {
            TextBox T = (TextBox) sender;
            if (!T.Modified) return;
            decimal valore = CfgFn.GetNoNullDecimal(HelpForm.GetObjectFromString(typeof (Decimal),
                T.Text, "x.y.c"));
            if (valore < 0) {
                MessageBox.Show("Valore non valido");
                T.Focus();
                return;
            }
            decimal importoimponibile = CfgFn.GetNoNullDecimal(HelpForm.GetObjectFromString(typeof (Decimal),
                txtTotImponibile.Text, "x.y.c"));
            decimal importoiva = CfgFn.GetNoNullDecimal(HelpForm.GetObjectFromString(typeof (Decimal),
                txtTotIva.Text, "x.y.c"));
            T.Text = valore.ToString("c");
            //txtTotGenerale.Text = (importoimponibile + importoiva).ToString("c");  
        }

        void RecalcOperationsToDo() {

            decimal ImportoMax = CfgFn.GetNoNullDecimal(
                HelpForm.GetObjectFromString(typeof (decimal),
                    txtTotSelezionato.Text, "x.y.c"));

            decimal ImportoDaIncassare = CfgFn.GetNoNullDecimal(
                HelpForm.GetObjectFromString(typeof (decimal),
                    txtDaIncassare.Text, "x.y.c"));
            if (ImportoDaIncassare == 0) {
                ImportoDaIncassare = ImportoMax;
            }
            txtDaIncassare.Text = ImportoDaIncassare.ToString("c");
            
            if (ImportoDaIncassare > ImportoMax) {
                MessageBox.Show("L'importo da incassare è superiore al totale dei dettagli selezionati");
                txtDaIncassare.Text = "";
                return;
            }
            decimal percentuale = 100;
            if (ImportoMax != 0) percentuale = ImportoDaIncassare/ImportoMax*100;
            decimal rounded = Math.Round(percentuale, 4);
            // calcola la percentuale in base all'importo
            txtPerc.Text = HelpForm.StringValue(rounded, "x.y.fixed.4...1");
            

        }

        decimal CalcolaCoefficiente(decimal importoDaIncassare, decimal importoMax, DataRow rowToSplit) {
            decimal epsilon = 0;
            if ((importoDaIncassare != 0) && (importoMax != 0)) epsilon = importoDaIncassare/importoMax;
            if (epsilon >= 1) return epsilon;

            int maxIter = 100;
            int niter = 1;
            decimal epsilon_min = epsilon - 0.01M;
            decimal epsilon_max = epsilon + 0.01M;
            decimal epsilon_med = (epsilon_min + epsilon_max)/2;
            decimal importoRicalcolato = RicalcolaTotaleDaContabilizzare(epsilon_med, rowToSplit);
            while (niter < maxIter && importoRicalcolato != importoDaIncassare) {
                if (importoDaIncassare - importoRicalcolato > 0) {
                    epsilon_min = epsilon_med;
                }
                else {
                    epsilon_max = epsilon_med;
                }
                epsilon_med = (epsilon_min + epsilon_max)/2;
                importoRicalcolato = RicalcolaTotaleDaContabilizzare(epsilon_med, rowToSplit);
                if (importoRicalcolato != importoDaIncassare) {
                    decimal totale_min = RicalcolaTotaleDaContabilizzare(epsilon_min, rowToSplit);
                    decimal totale_max = RicalcolaTotaleDaContabilizzare(epsilon_max, rowToSplit);
                    if (totale_min == totale_max) {
                        epsilon = epsilon_med;
                        niter = 100;
                    }
                }
                niter += 1;
            }
            return epsilon_med;
        }

        decimal GetImponibileNear(decimal imponibiletest, decimal taxable, decimal number, decimal discount,
            decimal exchangerate) {
            decimal TotaleImponibile = CfgFn.RoundValuta(taxable*number*(1 - discount)*exchangerate);
            decimal imponibilecomplementare = taxable - imponibiletest;
            decimal totale1 = CfgFn.RoundValuta(imponibiletest*number*(1 - discount)*exchangerate);
            decimal totale2 = CfgFn.RoundValuta(imponibilecomplementare*number*(1 - discount)*exchangerate);
            if (totale1 + totale2 == TotaleImponibile) return imponibiletest;
            decimal x = number*(1 - discount)*exchangerate;
            decimal passo = 0;
            if (x <= 10) passo = 0.001M;
            if ((x > 10) && (x <= 100)) passo = 0.0001M;
            if ((x > 100) && (x <= 1000)) passo = 0.00001M;
            if (x > 1000) passo = 0.00001M;
            decimal cent = passo;
            while (cent <= 0.1M) {
                decimal imponibile_try = imponibiletest + cent;
                decimal imponibilecomplementare_try = taxable - imponibile_try;
                totale1 = CfgFn.RoundValuta(imponibile_try*number*(1 - discount)*exchangerate);
                totale2 = CfgFn.RoundValuta(imponibilecomplementare_try*number*(1 - discount)*exchangerate);
                if (totale1 + totale2 == TotaleImponibile) {
                    return imponibile_try;
                }
                imponibile_try = imponibiletest - cent;
                imponibilecomplementare_try = taxable - imponibile_try;
                totale1 = CfgFn.RoundValuta(imponibile_try*number*(1 - discount)*exchangerate);
                totale2 = CfgFn.RoundValuta(imponibilecomplementare_try*number*(1 - discount)*exchangerate);
                if (totale1 + totale2 == TotaleImponibile) {
                    return imponibile_try;
                }
                cent += passo;
            }
            return imponibiletest;
        }

        DataTable AggiungiOSottraiCentADettagli(decimal proporzione, decimal importoDaIncassare, decimal cents) {
            DataRow[] Selected = GetGridSelectedRows(gridDetails);
            DataTable Info = new DataTable();

            Info.Columns.Add("rownum", typeof (int));
            Info.Columns.Add("difference", typeof (decimal));
            Info.Columns.Add("cents", typeof (decimal)); // Centesimi da sommare/sottrarre all'iva totale
            bool success = false;
            foreach (DataRow Row1 in Selected) {
                decimal imponibile1 = CfgFn.GetNoNullDecimal(Row1["taxable"]);
                decimal quantita1 = CfgFn.GetNoNullDecimal(Row1["number"]);
                //string  filter1 = "(idivakind=" + QueryCreator.quotedstrvalue(Row1["idivakind"], true) + ")";
                decimal aliquota1 = CfgFn.GetNoNullDecimal(Row1["taxrate"]);
                decimal sconto1 = CfgFn.GetNoNullDecimal(Row1["discount"]);
                DataRow Estimate1 = DS.estimate.Rows[0]; //Row1.GetParentRow("invoiceinvoicedetail");
                decimal tassocambio1 = CfgFn.GetNoNullDecimal(Estimate1["exchangerate"]);
                decimal taxable = CfgFn.Round(CfgFn.GetNoNullDecimal(Row1["taxable"]), 5);
                decimal taxabletotal = CfgFn.RoundValuta((taxable*quantita1*(1 - sconto1)*tassocambio1));
                // Ricalcolo l'imponibile unitario
                decimal taxable1 = CfgFn.Round(CfgFn.GetNoNullDecimal(Row1["taxable"])*proporzione, 5);
                decimal taxable_recalc = GetImponibileNear(taxable1, imponibile1, quantita1, sconto1, tassocambio1);
                // Ricalcolo l'iva
                decimal tax = CfgFn.RoundValuta(CfgFn.GetNoNullDecimal(Row1["tax"]));
                decimal taxtotal = CfgFn.RoundValuta(tax*tassocambio1);
                decimal tax_recalc = CfgFn.RoundValuta(CfgFn.GetNoNullDecimal(Row1["tax"])*proporzione);
                decimal tax_recalctotal = CfgFn.RoundValuta(tax_recalc*tassocambio1);
                decimal taxable_recalctotal = CfgFn.RoundValuta((taxable_recalc*quantita1*(1 - sconto1)*tassocambio1));
                DataRow rInfo = Info.NewRow();
                decimal difference;
                if ((taxable_recalctotal != 0) && (taxabletotal != 0)) {
                    difference = tax_recalctotal/taxable_recalctotal - taxtotal/taxabletotal;
                }
                else {
                    difference = -1000;
                }
                rInfo["rownum"] = Row1["rownum"];
                rInfo["difference"] = difference;
                rInfo["cents"] = 0;
                Info.Rows.Add(rInfo);
            }
            DataRow[] Details;
            bool aggiungi;
            if (cents < 0) {
                aggiungi = true;
                cents = -cents;
            }
            else aggiungi = false;

            decimal cent = 0.01M;
            if (cmbCausale.SelectedValue == null) return null;
            int causale = CfgFn.GetNoNullInt32(cmbCausale.SelectedValue);
            if (causale == 3) return null;
            while (cent <= cents) {
                decimal totiva = 0;
                decimal totimpo = 0;
                decimal total = 0;
                DataRow Det;
                // ESTIMo in base a difference in ESTIMe decrescente o crescente
                if (aggiungi) {
                    Details = Info.Select(null, "difference ASC");
                }
                else {
                    Details = Info.Select(null, "difference DESC");
                }
                Det = Details[0];
                foreach (DataRow Row in Selected) {
                    string filterrow = QHC.CmpEq("rownum", Row["rownum"]);
                    DataRow RowAdjust = Info.Select(filterrow, null)[0];
                    decimal imponibile = CfgFn.GetNoNullDecimal(Row["taxable"]);
                    decimal iva = CfgFn.GetNoNullDecimal(Row["tax"]);
                    decimal quantita = CfgFn.GetNoNullDecimal(Row["number"]);
                    decimal aliquota = CfgFn.GetNoNullDecimal(Row["taxrate"]);
                    decimal sconto = CfgFn.GetNoNullDecimal(Row["discount"]);
                    DataRow Estimate = DS.estimate.Rows[0];
                    decimal tassocambio = CfgFn.GetNoNullDecimal(Estimate["exchangerate"]);
                    decimal taxable = CfgFn.Round(CfgFn.GetNoNullDecimal(Row["taxable"]), 5);
                    // Ricalcolo l'imponibile unitario
                    decimal taxable_recalc = CfgFn.Round(CfgFn.GetNoNullDecimal(Row["taxable"])*proporzione, 5);
                    taxable_recalc = GetImponibileNear(taxable_recalc, imponibile, quantita, sconto, tassocambio);
                    // Uso l'imponibile unitario per  calcolare l'iva totale e l'iva indetraibile
                    decimal taxabletotal = CfgFn.RoundValuta((taxable*quantita*(1 - sconto)*tassocambio));
                    decimal tax = CfgFn.RoundValuta(CfgFn.GetNoNullDecimal(Row["tax"]));
                    decimal taxtotal = CfgFn.RoundValuta(tax*tassocambio);
                    decimal tax_recalc = CfgFn.RoundValuta(CfgFn.GetNoNullDecimal(Row["tax"])*proporzione);
                    tax_recalc = CfgFn.RoundValuta(tax_recalc*tassocambio);
                    decimal taxabletot_recalc = CfgFn.RoundValuta((taxable_recalc*quantita*(1 - sconto)*tassocambio));
                    // aggiungi o sottrai centesimi all'iva del dettaglio
                    if (Det["rownum"].Equals(Row["rownum"])) {
                        if (aggiungi) {
                            tax_recalc = tax_recalc + CfgFn.GetNoNullDecimal(Det["cents"]) + 0.01M;
                            Det["cents"] = CfgFn.GetNoNullDecimal(Det["cents"]) + 0.01M;
                        }
                        if (!aggiungi) {
                            tax_recalc = tax_recalc + (CfgFn.GetNoNullDecimal(Det["cents"])) - 0.01M;
                            Det["cents"] = CfgFn.GetNoNullDecimal(Det["cents"]) - 0.01M;
                        }
                        decimal difference;
                        if ((taxable_recalc != 0) && (taxable != 0)) {
                            difference = tax_recalc/taxabletot_recalc - taxtotal/taxabletotal;
                        }
                        else {
                            difference = -1000;
                        }
                        Det["difference"] = difference;
                    }
                    else {
                        decimal aggiustamento = CfgFn.GetNoNullDecimal(RowAdjust["cents"]);
                        tax_recalc += aggiustamento;
                    }

                    if (causale == 3) {
                        totimpo += taxabletot_recalc;
                    }
                    if (causale == 2) {
                        totiva += tax_recalc;
                    }
                    if (causale == 1) {
                        totimpo += taxabletot_recalc;
                        totiva += tax_recalc;
                    }
                    total = totimpo + totiva;
                }
                decimal TotaleDaContabilizzare = 0;
                if (causale == 3) {
                    TotaleDaContabilizzare = CfgFn.GetNoNullDecimal(totimpo);
                }
                if (causale == 2) {
                    TotaleDaContabilizzare = CfgFn.GetNoNullDecimal(totiva);
                }
                if (causale == 1) {
                    TotaleDaContabilizzare = CfgFn.GetNoNullDecimal(total);
                }

                if (TotaleDaContabilizzare == importoDaIncassare) {
                    cent = cents;
                    success = true;
                    break;
                }
                if (TotaleDaContabilizzare < importoDaIncassare) aggiungi = true;
                if (TotaleDaContabilizzare > importoDaIncassare) aggiungi = false;
                cent += 0.01M;
            }

            if (success) return Info;
            else return null;
        }


        decimal RicalcolaTotaleDaContabilizzare(decimal proporzione, DataRow rowToSplit) {
            if (cmbCausale.SelectedValue == null) return 0;
            int causale = CfgFn.GetNoNullInt32(cmbCausale.SelectedValue);
            decimal totiva = 0;
            decimal totimpo = 0;
            decimal total = 0;
            DataRow Estimate = DS.estimate.Rows[0]; //Row.GetParentRow("invoiceinvoicedetail");
            decimal tassocambio = CfgFn.GetNoNullDecimal(Estimate["exchangerate"]);
            if (rowToSplit == null) {
                DataRow[] Selected = GetGridSelectedRows(gridDetails);


                foreach (DataRow Row in Selected) {
                    decimal imponibile = CfgFn.GetNoNullDecimal(Row["taxable"]);
                    decimal iva = CfgFn.GetNoNullDecimal(Row["tax"]);
                    decimal quantita = CfgFn.GetNoNullDecimal(Row["number"]);
                    //string  filter = "(idivakind=" + QueryCreator.quotedstrvalue(Row["idivakind"], true) + ")";
                    decimal aliquota = CfgFn.GetNoNullDecimal(Row["taxrate"]);
                    decimal sconto = CfgFn.GetNoNullDecimal(Row["discount"]);
                    //decimal percindeduc = CfgFn.GetNoNullDecimal(Conn.DO_READ_VALUE("ivakind", filter, "unabatabilitypercentage"));
                    // Ricalcolo l'imponibile unitario
                    decimal taxable = CfgFn.Round(CfgFn.GetNoNullDecimal(Row["taxable"])*proporzione, 5);
                    taxable = GetImponibileNear(taxable, imponibile, quantita, sconto, tassocambio);
                    // Uso l'imponibile unitario per  calcolare l'iva totale e l'iva indetraibile
                    decimal taxabletot = CfgFn.RoundValuta((taxable*quantita*(1 - sconto)*tassocambio));
                    decimal tax = CfgFn.RoundValuta(CfgFn.GetNoNullDecimal(Row["tax"])*proporzione);

                    if (causale == 3) {
                        totimpo += taxabletot;
                    }
                    if (causale == 2) {
                        totiva += tax;
                    }
                    if (causale == 1) {
                        totimpo += taxabletot;
                        totiva += tax;
                    }
                    total = totimpo + totiva;
                }
                if (causale == 3) {
                    TotaleDaContabilizzare = CfgFn.GetNoNullDecimal(totimpo);
                }
                if (causale == 2) {
                    TotaleDaContabilizzare = CfgFn.GetNoNullDecimal(totiva);
                }
                if (causale == 1) {
                    TotaleDaContabilizzare = CfgFn.GetNoNullDecimal(total);
                }
                return TotaleDaContabilizzare;
            }
            else {
                decimal imponibile = CfgFn.GetNoNullDecimal(rowToSplit["taxable"]);
                decimal iva = CfgFn.GetNoNullDecimal(rowToSplit["tax"]);
                decimal quantita = CfgFn.GetNoNullDecimal(rowToSplit["number"]);
                //string  filter = "(idivakind=" + QueryCreator.quotedstrvalue(Row["idivakind"], true) + ")";
                decimal aliquota = CfgFn.GetNoNullDecimal(rowToSplit["taxrate"]);
                decimal sconto = CfgFn.GetNoNullDecimal(rowToSplit["discount"]);
                //decimal percindeduc = CfgFn.GetNoNullDecimal(Conn.DO_READ_VALUE("ivakind", filter, "unabatabilitypercentage"));

                // Ricalcolo l'imponibile unitario
                decimal taxable = CfgFn.Round(CfgFn.GetNoNullDecimal(rowToSplit["taxable"])*proporzione, 5);
                taxable = GetImponibileNear(taxable, imponibile, quantita, sconto, tassocambio);
                // Uso l'imponibile unitario per  calcolare l'iva totale e l'iva indetraibile
                decimal taxabletot = CfgFn.RoundValuta((taxable*quantita*(1 - sconto)*tassocambio));
                decimal tax = CfgFn.RoundValuta(CfgFn.GetNoNullDecimal(rowToSplit["tax"])*proporzione);
                decimal importoRicalcolato = 0;
                if (causale == 3) {
                    importoRicalcolato = CfgFn.GetNoNullDecimal(taxabletot);
                }
                if (causale == 2) {
                    importoRicalcolato = CfgFn.GetNoNullDecimal(tax);
                }
                if (causale == 1) {
                    importoRicalcolato = CfgFn.GetNoNullDecimal(taxabletot + tax);
                }
                return importoRicalcolato;

            }

        }

        private bool checkPercentuale(object sender) {
            TextBox T = (TextBox) sender;
            bool OK = false;
            if (T.Text == "") return false;
            decimal percentmax = 100;
            string errmsg = "Il valore percentuale dovrebbe essere un numero compreso \r" +
                            "tra 0 e " + percentmax.ToString("n");
            try {
                decimal percent = Decimal.Parse(T.Text,
                    NumberStyles.Number,
                    NumberFormatInfo.CurrentInfo);
                if ((percent < 0) || (percent > percentmax)) {
                    MessageBox.Show(errmsg, "Avviso");
                    T.Focus();
                    OK = false;
                }
                else {
                    OK = true;
                }
            }
            catch {
                MessageBox.Show("E' necessario digitare un numero", "Avviso", System.Windows.Forms.MessageBoxButtons.OK,
                    System.Windows.Forms.MessageBoxIcon.Exclamation);
                return false;
            }
            return OK;
        }

        private void txtPerc_Leave(object sender, System.EventArgs e) {
            if (checkPercentuale(sender)) {
                decimal ImportoMax = CfgFn.GetNoNullDecimal(
                    HelpForm.GetObjectFromString(typeof (decimal),
                        txtTotSelezionato.Text, "x.y.c"));
                // calcola l'importo in base alla percentuale
                decimal perc =
                    CfgFn.GetNoNullDecimal(HelpForm.GetObjectFromString(typeof (Decimal), txtPerc.Text, "x.y.c"));
                decimal importoDaIncassare = CfgFn.Round(ImportoMax*perc/100, 2);
                //RicalcolaTotaleDaContabilizzare(perc/100);
                txtDaIncassare.Text = importoDaIncassare.ToString("c");
                txtPerc.Text = HelpForm.StringValue(perc, "x.y.fixed.4...1");

                txtDaIncassare_Leave(txtDaIncassare, null);
            }
        }

        void InsertNewDetail(DataRow Row, decimal taxable, decimal tax) {
            // Creo una nuova riga con gli importi residui (vedere gli arrotondamenti)
            MetaData metaDT = MetaData.GetMetaData(this, "estimatedetail");
            metaDT.SetDefaults(DS.estimatedetail);
            decimal taxableResiduo = CfgFn.GetNoNullDecimal(Row["taxable"]) - taxable;
            decimal taxResiduo = CfgFn.GetNoNullDecimal(Row["tax"]) - tax;
            // Creazione di un nuovo dettaglio
            DataRow rDT = metaDT.Get_New_Row(DS.estimate.Rows[0], DS.estimatedetail);
            rDT["idgroup"] = Row["idgroup"];
            rDT["idreg"] = Row["idreg"];
            rDT["taxrate"] = Row["taxrate"];
            rDT["taxable"] = taxableResiduo;
            rDT["tax"] = taxResiduo;
            rDT["idupb"] = Row["idupb"];
            rDT["idupb_iva"] = Row["idupb_iva"];
            rDT["number"] = CfgFn.GetNoNullDecimal(Row["number"]);
            rDT["detaildescription"] = Row["detaildescription"].ToString();
            rDT["annotations"] = Row["annotations"];
            rDT["discount"] = Row["discount"];
            rDT["start"] = Row["start"];
            rDT["stop"] = Row["stop"];
            rDT["toinvoice"] = Row["toinvoice"];
            rDT["ninvoiced"] = Row["ninvoiced"];
            rDT["idinc_taxable"] = Row["idinc_taxable"]; // contabilizzaione imponibile già effettuata
            rDT["idinc_iva"] = Row["idinc_iva"]; // contabilizzaione iva già effettuata
            rDT["idivakind"] = Row["idivakind"];
            rDT["idaccmotive"] = Row["idaccmotive"];
            rDT["idsor1"] = Row["idsor1"];
            rDT["idsor2"] = Row["idsor2"];
            rDT["idsor3"] = Row["idsor3"];
            rDT["competencystart"] = Row["competencystart"];
            rDT["competencystop"] = Row["competencystop"];
            rDT["cigcode"] = Row["cigcode"];
            rDT["idfinmotive"] = Row["idfinmotive"];
            rDT["iduniqueformcode"] = Row["iduniqueformcode"];
            rDT["nform"] = Row["nform"];
            rDT["idlist"] = Row["idlist"];
            rDT["idsor_siope"] = Row["idsor_siope"];
        }

        void RecalcDettagliSelezionati() {
            DataRow[] Selected = GetGridSelectedRows(gridDetails);
            int causale = CfgFn.GetNoNullInt32(cmbCausale.SelectedValue);
            decimal ImportoMax = CfgFn.GetNoNullDecimal(
                HelpForm.GetObjectFromString(typeof (decimal),
                    txtTotSelezionato.Text, "x.y.c"));
            decimal ImportoDaIncassare = CfgFn.GetNoNullDecimal(
                HelpForm.GetObjectFromString(typeof (decimal),
                    txtDaIncassare.Text, "x.y.c"));
            if (ImportoDaIncassare == 0) {
                ImportoDaIncassare = ImportoMax;
            }
            DataRow Estimate = DS.estimate.Rows[0];
            decimal tassocambio = CfgFn.GetNoNullDecimal(Estimate["exchangerate"]);

            ClearOperazionsToDo();
            // Rilegge i dettagli con l'importo originale nel dataset
            foreach (DataRow Det in Selected) {
                string filterestimatedetail = QueryCreator.WHERE_COLNAME_CLAUSE(
                    Det, new string[] {"idestimkind", "yestim", "nestim", "rownum"}, DataRowVersion.Default, true);
                DataAccess.RUN_SELECT_INTO_TABLE(Conn, DS.Tables["estimatedetail"], null, filterestimatedetail, null,
                    false);
            }

            if (ImportoMax == 0) return;


            if (ImportoDaIncassare < ImportoMax) {
                if (rdbSplittaTutti.Checked) {
                    // Distribuisce la quota parziale da contabilizzare su tutti i dettagli
                    DataTable T = null;
                    decimal epsilon = CalcolaCoefficiente(ImportoDaIncassare, ImportoMax, null);
                    if (RicalcolaTotaleDaContabilizzare(epsilon, null) != ImportoDaIncassare) {
                        decimal cents = (RicalcolaTotaleDaContabilizzare(epsilon, null) - ImportoDaIncassare);
                        T = AggiungiOSottraiCentADettagli(epsilon, ImportoDaIncassare, cents);
                    }
                    foreach (DataRow Row in DS.estimatedetail.Select()) {
                        // Solo le righe selezionate
                        if (!DetailsToUpdate.Contains(Row["rownum"])) {
                            DetailsToUpdate.Add(Row["rownum"]);
                        }
                        decimal imponibile = CfgFn.GetNoNullDecimal(Row["taxable"]);
                        decimal iva = CfgFn.GetNoNullDecimal(Row["tax"]);
                        decimal quantita = CfgFn.GetNoNullDecimal(Row["number"]);
                        decimal aliquota = CfgFn.GetNoNullDecimal(Row["taxrate"]);
                        decimal sconto = CfgFn.GetNoNullDecimal(Row["discount"]);
                        // Ricalcolo l'imponibile unitario
                        decimal taxable = CfgFn.Round(CfgFn.GetNoNullDecimal(Row["taxable"])*epsilon, 5);
                        taxable = GetImponibileNear(taxable, imponibile, quantita, sconto, tassocambio);
                        // Uso l'imponibile unitario per  calcolare l'iva totale
                        decimal tax = CfgFn.RoundValuta(CfgFn.GetNoNullDecimal(Row["tax"])*epsilon);
                        string filterdetail = "(rownum=" + QueryCreator.quotedstrvalue(Row["rownum"], true) + ")";
                        if (T != null) {
                            DataRow[] Det = T.Select(filterdetail);
                            if (Det.Length != 0) {
                                decimal cents = CfgFn.GetNoNullDecimal(Det[0]["cents"]);
                                tax += cents;
                            }
                        }
                        InsertNewDetail(Row, taxable, tax);
                        //Aggiorno la riga originale con i valori ricalcolati
                        Row["taxable"] = taxable;
                        Row["tax"] = tax;
                    }
                }
                else {
                    //La quota parziale da contabilizzare viene raggiunta sommando i dettagli, e splittando l'ultimo
                    DataTable Info = new DataTable();
                    Info.Columns.Add("rownum", typeof (int));
                    Info.Columns.Add("total", typeof (decimal));
                    // Ciclo per riempire il datatable Info con il totale da contabilizzare su ogni dettaglio
                    foreach (DataRow Row in DS.estimatedetail.Select(null, "rownum"))
                        // Solo le righe selezionate ESTIMate per importo crescente
                    {
                        // Calcolo il totale sulla causale per quel dettaglio
                        DataRow rInfo = Info.NewRow();
                        rInfo["rownum"] = Row["rownum"];
                        rInfo["total"] = CalcolaTotCausale(Row, causale);
                        Info.Rows.Add(rInfo);

                    }
                    decimal sum = ImportoDaIncassare;
                    decimal oldsum = 0;
                    string filterrow = null;
                    // Ciclo per calcolare la somma da contabilizzare
                    foreach (DataRow Row in Info.Select(null, "total asc"))
                        // Solo le righe selezionate ESTIMate per importo crescente 
                    {
                        if (!DetailsToUpdate.Contains(Row["rownum"])) {
                            DetailsToUpdate.Add(Row["rownum"]);
                        }
                        oldsum = sum;
                        sum -= CfgFn.GetNoNullDecimal(Row["total"]);

                        if (sum == 0) {
                            break;
                        }

                        if (sum > 0) {
                            continue;
                        }
                        else {
                            filterrow = QHC.CmpEq("rownum", Row["rownum"]);
                            DataRow R = DS.estimatedetail.Select(filterrow, null)[0];
                            decimal imponibile = CfgFn.GetNoNullDecimal(R["taxable"]);
                            decimal iva = CfgFn.GetNoNullDecimal(R["tax"]);
                            decimal quantita = CfgFn.GetNoNullDecimal(R["number"]);
                            decimal aliquota = CfgFn.GetNoNullDecimal(R["taxrate"]);
                            decimal sconto = CfgFn.GetNoNullDecimal(R["discount"]);
                            // Splitto il dettaglio corrente in due, uno risulterà contabilizzato,l'altro no

                            decimal epsilon1 = CalcolaCoefficiente(oldsum, CfgFn.GetNoNullDecimal(Row["total"]), R);
                            // Ricalcolo l'imponibile unitario
                            decimal taxable = CfgFn.Round(CfgFn.GetNoNullDecimal(R["taxable"])*epsilon1, 5);
                            taxable = GetImponibileNear(taxable, imponibile, quantita, sconto, tassocambio);
                            // Uso l'imponibile unitario per  calcolare l'iva totale
                            decimal tax = CfgFn.RoundValuta(CfgFn.GetNoNullDecimal(R["tax"])*epsilon1);
                            // Creo una nuova riga con gli importi residui (vedere gli arrotondamenti)
                            InsertNewDetail(R, taxable, tax);
                            //Aggiorno la riga originale con i valori ricalcolati
                            R["taxable"] = taxable;
                            R["tax"] = tax;
                            break;
                        }
                    }

                }

            }
            else {
                foreach (DataRow Row in DS.estimatedetail.Select()) {
                    // Solo le righe selezionate
                    if (!DetailsToUpdate.Contains(Row["rownum"])) {
                        DetailsToUpdate.Add(Row["rownum"]);
                    }
                }
            }
        }

        void ClearOperazionsToDo() {
            DS.incomeyear.Clear();
            DS.incomelast.Clear();
            DS.income.Clear();
            DS.estimatedetail.Clear();
            DetailsToUpdate.Clear();
        }

        private void txtDaIncassare_Leave(object sender, EventArgs e) {
            RecalcOperationsToDo();
        }

    }
}
