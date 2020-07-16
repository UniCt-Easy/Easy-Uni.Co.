/*
    Easy
    Copyright (C) 2020 UniversitÃ  degli Studi di Catania (www.unict.it)
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
using System.Globalization;
using movimentofunctions;
using AskInfo;
using q = metadatalibrary.MetaExpression;

namespace expense_wizardmandatedetail {
    /// <summary>
    /// Summary description for FrmWizardMandateDetail.
    /// </summary>
    public class FrmWizardMandateDetail : System.Windows.Forms.Form {
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
        public expense_wizardmandatedetail.vistaFrm DS;

        string CustomTitle;
        private System.Windows.Forms.DataGrid gridDetails;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtFornitore;
        private System.Windows.Forms.Label labDescrOrdine;
        private System.Windows.Forms.TextBox txtDescrOrdine;
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
        private System.Windows.Forms.ComboBox cmbTipoOrdine;
        decimal TotaleDaContabilizzare = 0;
        private System.Windows.Forms.CheckBox chkAddContab;
        private Crownwood.Magic.Controls.TabPage tabSplit;
        private Label label23;
        private Label label22;
        private TextBox txtPerc;
        private TextBox txtDaPagare;
        private Label label17;
        int faseordine;
        bool genMultipla = true;
        private GroupBox groupBox3;
        private RadioButton rdbSplittaUno;
        private RadioButton rdbSplittaTutti;
        private Label lblCausale;
        private TextBox txtTotSelezionato;
        private Label label19;
        private Panel panel1;
        private GroupBox groupBox4;
        private TextBox txtResponsabile;
        private GroupBox groupBox5;
        private TextBox txtResponsabileContratto;
        private TextBox txtUPB;
        ArrayList DetailsToUpdate;

        public FrmWizardMandateDetail() {
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
            this.tabIntro = new Crownwood.Magic.Controls.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabSelDetail = new Crownwood.Magic.Controls.TabPage();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.txtResponsabileContratto = new System.Windows.Forms.TextBox();
            this.cmbTipoOrdine = new System.Windows.Forms.ComboBox();
            this.DS = new expense_wizardmandatedetail.vistaFrm();
            this.txtDescrOrdine = new System.Windows.Forms.TextBox();
            this.labDescrOrdine = new System.Windows.Forms.Label();
            this.txtFornitore = new System.Windows.Forms.TextBox();
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
            this.tabSplit = new Crownwood.Magic.Controls.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lblCausale = new System.Windows.Forms.Label();
            this.txtTotSelezionato = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.rdbSplittaUno = new System.Windows.Forms.RadioButton();
            this.rdbSplittaTutti = new System.Windows.Forms.RadioButton();
            this.label23 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.txtPerc = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.txtDaPagare = new System.Windows.Forms.TextBox();
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
            this.tabIntro.SuspendLayout();
            this.tabSelDetail.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize) (this.DS)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize) (this.gridDetails)).BeginInit();
            this.tabSplit.SuspendLayout();
            this.groupBox3.SuspendLayout();
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
            this.tabController.SelectedIndex = 1;
            this.tabController.SelectedTab = this.tabSelDetail;
            this.tabController.Size = new System.Drawing.Size(700, 468);
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
            // tabSelMov
            // 
            this.tabSelMov.Anchor =
                ((System.Windows.Forms.AnchorStyles) ((((System.Windows.Forms.AnchorStyles.Top |
                                                         System.Windows.Forms.AnchorStyles.Bottom)
                                                        | System.Windows.Forms.AnchorStyles.Left)
                                                       | System.Windows.Forms.AnchorStyles.Right)));
            this.tabSelMov.Controls.Add(this.labelNewLinkedCont);
            this.tabSelMov.Controls.Add(this.labelAddCont);
            this.tabSelMov.Controls.Add(this.gboxSelMov);
            this.tabSelMov.Controls.Add(this.radioNewLinkedMov);
            this.tabSelMov.Controls.Add(this.radioNewCont);
            this.tabSelMov.Controls.Add(this.radioAddCont);
            this.tabSelMov.Location = new System.Drawing.Point(0, 0);
            this.tabSelMov.Name = "tabSelMov";
            this.tabSelMov.Selected = false;
            this.tabSelMov.Size = new System.Drawing.Size(700, 443);
            this.tabSelMov.TabIndex = 4;
            this.tabSelMov.Title = "Pagina 4 di 5";
            // 
            // labelNewLinkedCont
            // 
            this.labelNewLinkedCont.Location = new System.Drawing.Point(8, 408);
            this.labelNewLinkedCont.Name = "labelNewLinkedCont";
            this.labelNewLinkedCont.Size = new System.Drawing.Size(704, 32);
            this.labelNewLinkedCont.TabIndex = 105;
            // 
            // labelAddCont
            // 
            this.labelAddCont.Location = new System.Drawing.Point(8, 448);
            this.labelAddCont.Name = "labelAddCont";
            this.labelAddCont.Size = new System.Drawing.Size(704, 24);
            this.labelAddCont.TabIndex = 104;
            // 
            // gboxSelMov
            // 
            this.gboxSelMov.Anchor =
                ((System.Windows.Forms.AnchorStyles) (((System.Windows.Forms.AnchorStyles.Top |
                                                        System.Windows.Forms.AnchorStyles.Left)
                                                       | System.Windows.Forms.AnchorStyles.Right)));
            this.gboxSelMov.Controls.Add(this.groupBox4);
            this.gboxSelMov.Controls.Add(this.gboxUPB);
            this.gboxSelMov.Controls.Add(this.gboxMovimento);
            this.gboxSelMov.Controls.Add(this.groupBox17);
            this.gboxSelMov.Controls.Add(this.gboxBilAnnuale);
            this.gboxSelMov.Controls.Add(this.groupBox20);
            this.gboxSelMov.Controls.Add(this.groupBox18);
            this.gboxSelMov.Controls.Add(this.groupBox1);
            this.gboxSelMov.Location = new System.Drawing.Point(8, 73);
            this.gboxSelMov.Name = "gboxSelMov";
            this.gboxSelMov.Size = new System.Drawing.Size(688, 332);
            this.gboxSelMov.TabIndex = 103;
            this.gboxSelMov.TabStop = false;
            this.gboxSelMov.Text = "Selezione del movimento di spesa";
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor =
                ((System.Windows.Forms.AnchorStyles) (((System.Windows.Forms.AnchorStyles.Top |
                                                        System.Windows.Forms.AnchorStyles.Left)
                                                       | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.txtResponsabile);
            this.groupBox4.Location = new System.Drawing.Point(354, 86);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(328, 48);
            this.groupBox4.TabIndex = 99;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Responsabile";
            // 
            // txtResponsabile
            // 
            this.txtResponsabile.Anchor =
                ((System.Windows.Forms.AnchorStyles) (((System.Windows.Forms.AnchorStyles.Top |
                                                        System.Windows.Forms.AnchorStyles.Left)
                                                       | System.Windows.Forms.AnchorStyles.Right)));
            this.txtResponsabile.Location = new System.Drawing.Point(8, 16);
            this.txtResponsabile.Multiline = true;
            this.txtResponsabile.Name = "txtResponsabile";
            this.txtResponsabile.ReadOnly = true;
            this.txtResponsabile.Size = new System.Drawing.Size(314, 24);
            this.txtResponsabile.TabIndex = 1;
            this.txtResponsabile.Tag = "";
            // 
            // gboxUPB
            // 
            this.gboxUPB.Anchor =
                ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Bottom |
                                                       System.Windows.Forms.AnchorStyles.Left)));
            this.gboxUPB.Controls.Add(this.txtUPB);
            this.gboxUPB.Controls.Add(this.txtDescrUPB);
            this.gboxUPB.Controls.Add(this.btnUPBCode);
            this.gboxUPB.Location = new System.Drawing.Point(6, 120);
            this.gboxUPB.Name = "gboxUPB";
            this.gboxUPB.Size = new System.Drawing.Size(338, 84);
            this.gboxUPB.TabIndex = 98;
            this.gboxUPB.TabStop = false;
            this.gboxUPB.Tag = "";
            // 
            // txtUPB
            // 
            this.txtUPB.Location = new System.Drawing.Point(6, 55);
            this.txtUPB.Name = "txtUPB";
            this.txtUPB.ReadOnly = true;
            this.txtUPB.Size = new System.Drawing.Size(322, 23);
            this.txtUPB.TabIndex = 5;
            this.txtUPB.Tag = "";
            // 
            // txtDescrUPB
            // 
            this.txtDescrUPB.Location = new System.Drawing.Point(123, 8);
            this.txtDescrUPB.Multiline = true;
            this.txtDescrUPB.Name = "txtDescrUPB";
            this.txtDescrUPB.ReadOnly = true;
            this.txtDescrUPB.Size = new System.Drawing.Size(205, 44);
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
            this.btnUPBCode.Location = new System.Drawing.Point(18, 23);
            this.btnUPBCode.Name = "btnUPBCode";
            this.btnUPBCode.Size = new System.Drawing.Size(86, 20);
            this.btnUPBCode.TabIndex = 2;
            this.btnUPBCode.TabStop = false;
            this.btnUPBCode.Tag = "";
            this.btnUPBCode.Text = "UPB:";
            this.btnUPBCode.UseVisualStyleBackColor = false;
            // 
            // gboxMovimento
            // 
            this.gboxMovimento.Anchor =
                ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Bottom |
                                                       System.Windows.Forms.AnchorStyles.Left)));
            this.gboxMovimento.Controls.Add(this.btnSelectMov);
            this.gboxMovimento.Controls.Add(this.txtNumeroMovimento);
            this.gboxMovimento.Controls.Add(this.labNum);
            this.gboxMovimento.Controls.Add(this.txtEsercizioMovimento);
            this.gboxMovimento.Controls.Add(this.labEserc);
            this.gboxMovimento.Location = new System.Drawing.Point(8, 20);
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
            this.groupBox17.Anchor =
                ((System.Windows.Forms.AnchorStyles) (((System.Windows.Forms.AnchorStyles.Top |
                                                        System.Windows.Forms.AnchorStyles.Left)
                                                       | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox17.Controls.Add(this.txtDescrizione);
            this.groupBox17.Location = new System.Drawing.Point(354, 8);
            this.groupBox17.Name = "groupBox17";
            this.groupBox17.Size = new System.Drawing.Size(328, 72);
            this.groupBox17.TabIndex = 93;
            this.groupBox17.TabStop = false;
            this.groupBox17.Text = "Descrizione";
            // 
            // txtDescrizione
            // 
            this.txtDescrizione.Anchor =
                ((System.Windows.Forms.AnchorStyles) (((System.Windows.Forms.AnchorStyles.Top |
                                                        System.Windows.Forms.AnchorStyles.Left)
                                                       | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescrizione.Location = new System.Drawing.Point(8, 16);
            this.txtDescrizione.Multiline = true;
            this.txtDescrizione.Name = "txtDescrizione";
            this.txtDescrizione.ReadOnly = true;
            this.txtDescrizione.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDescrizione.Size = new System.Drawing.Size(314, 48);
            this.txtDescrizione.TabIndex = 1;
            this.txtDescrizione.Tag = "";
            // 
            // gboxBilAnnuale
            // 
            this.gboxBilAnnuale.Anchor =
                ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Bottom |
                                                       System.Windows.Forms.AnchorStyles.Left)));
            this.gboxBilAnnuale.Controls.Add(this.label9);
            this.gboxBilAnnuale.Controls.Add(this.txtCodiceBilancio);
            this.gboxBilAnnuale.Controls.Add(this.txtDenominazioneBilancio);
            this.gboxBilAnnuale.Location = new System.Drawing.Point(6, 202);
            this.gboxBilAnnuale.Name = "gboxBilAnnuale";
            this.gboxBilAnnuale.Size = new System.Drawing.Size(336, 76);
            this.gboxBilAnnuale.TabIndex = 90;
            this.gboxBilAnnuale.TabStop = false;
            this.gboxBilAnnuale.Tag = "";
            // 
            // label9
            // 
            this.label9.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label9.Location = new System.Drawing.Point(10, 33);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(64, 13);
            this.label9.TabIndex = 3;
            this.label9.Text = "Bilancio";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtCodiceBilancio
            // 
            this.txtCodiceBilancio.Location = new System.Drawing.Point(7, 49);
            this.txtCodiceBilancio.Name = "txtCodiceBilancio";
            this.txtCodiceBilancio.ReadOnly = true;
            this.txtCodiceBilancio.Size = new System.Drawing.Size(321, 23);
            this.txtCodiceBilancio.TabIndex = 1;
            this.txtCodiceBilancio.Tag = "";
            // 
            // txtDenominazioneBilancio
            // 
            this.txtDenominazioneBilancio.Location = new System.Drawing.Point(78, 8);
            this.txtDenominazioneBilancio.Multiline = true;
            this.txtDenominazioneBilancio.Name = "txtDenominazioneBilancio";
            this.txtDenominazioneBilancio.ReadOnly = true;
            this.txtDenominazioneBilancio.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDenominazioneBilancio.Size = new System.Drawing.Size(250, 40);
            this.txtDenominazioneBilancio.TabIndex = 2;
            this.txtDenominazioneBilancio.TabStop = false;
            this.txtDenominazioneBilancio.Tag = "";
            // 
            // groupBox20
            // 
            this.groupBox20.Anchor =
                ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Bottom |
                                                       System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox20.Controls.Add(this.label15);
            this.groupBox20.Controls.Add(this.txtDataCont);
            this.groupBox20.Controls.Add(this.txtScadenza);
            this.groupBox20.Controls.Add(this.label13);
            this.groupBox20.Location = new System.Drawing.Point(8, 284);
            this.groupBox20.Name = "groupBox20";
            this.groupBox20.Size = new System.Drawing.Size(336, 40);
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
            this.groupBox18.Anchor =
                ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Bottom |
                                                       System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox18.Controls.Add(this.SubEntity_txtImportoMovimento);
            this.groupBox18.Controls.Add(this.label11);
            this.groupBox18.Location = new System.Drawing.Point(8, 74);
            this.groupBox18.Name = "groupBox18";
            this.groupBox18.Size = new System.Drawing.Size(336, 40);
            this.groupBox18.TabIndex = 95;
            this.groupBox18.TabStop = false;
            this.groupBox18.Text = "Importo";
            // 
            // SubEntity_txtImportoMovimento
            // 
            this.SubEntity_txtImportoMovimento.Location = new System.Drawing.Point(211, 12);
            this.SubEntity_txtImportoMovimento.Name = "SubEntity_txtImportoMovimento";
            this.SubEntity_txtImportoMovimento.ReadOnly = true;
            this.SubEntity_txtImportoMovimento.Size = new System.Drawing.Size(112, 23);
            this.SubEntity_txtImportoMovimento.TabIndex = 1;
            this.SubEntity_txtImportoMovimento.Tag = "";
            this.SubEntity_txtImportoMovimento.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(64, 11);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(56, 20);
            this.label11.TabIndex = 0;
            this.label11.Text = "Originale:";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor =
                ((System.Windows.Forms.AnchorStyles) (((System.Windows.Forms.AnchorStyles.Bottom |
                                                        System.Windows.Forms.AnchorStyles.Left)
                                                       | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.lblImportoDisponibile);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.txtImportoDisponibile);
            this.groupBox1.Controls.Add(this.txtImportoCorrente);
            this.groupBox1.Location = new System.Drawing.Point(348, 260);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(336, 64);
            this.groupBox1.TabIndex = 97;
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
            // txtImportoDisponibile
            // 
            this.txtImportoDisponibile.Anchor =
                ((System.Windows.Forms.AnchorStyles) (((System.Windows.Forms.AnchorStyles.Top |
                                                        System.Windows.Forms.AnchorStyles.Left)
                                                       | System.Windows.Forms.AnchorStyles.Right)));
            this.txtImportoDisponibile.Location = new System.Drawing.Point(227, 40);
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
            this.txtImportoCorrente.Anchor =
                ((System.Windows.Forms.AnchorStyles) (((System.Windows.Forms.AnchorStyles.Top |
                                                        System.Windows.Forms.AnchorStyles.Left)
                                                       | System.Windows.Forms.AnchorStyles.Right)));
            this.txtImportoCorrente.Location = new System.Drawing.Point(227, 16);
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
            this.radioNewLinkedMov.Size = new System.Drawing.Size(696, 26);
            this.radioNewLinkedMov.TabIndex = 102;
            this.radioNewLinkedMov.Text =
                "Si desidera creare un NUOVO movimento di spesa, collegandolo però ad un movimento" +
                " esistente";
            this.radioNewLinkedMov.CheckedChanged += new System.EventHandler(this.radioNewLinkedMov_CheckedChanged);
            // 
            // radioNewCont
            // 
            this.radioNewCont.Location = new System.Drawing.Point(8, 8);
            this.radioNewCont.Name = "radioNewCont";
            this.radioNewCont.Size = new System.Drawing.Size(688, 16);
            this.radioNewCont.TabIndex = 101;
            this.radioNewCont.Text =
                "Si desidera creare un NUOVO movimento di spesa (uno per ogni diverso UPB e Fornit" +
                "ore presente nei dettagli selezionati)";
            this.radioNewCont.CheckedChanged += new System.EventHandler(this.radioNewCont_CheckedChanged);
            // 
            // radioAddCont
            // 
            this.radioAddCont.Location = new System.Drawing.Point(8, 50);
            this.radioAddCont.Name = "radioAddCont";
            this.radioAddCont.Size = new System.Drawing.Size(688, 25);
            this.radioAddCont.TabIndex = 100;
            this.radioAddCont.Text = "Si desidera AGGIUNGERE LA CONTABILIZZAZIONE ai dettagli contratto passivo";
            this.radioAddCont.CheckedChanged += new System.EventHandler(this.radioAddCont_CheckedChanged);
            // 
            // tabIntro
            // 
            this.tabIntro.Anchor =
                ((System.Windows.Forms.AnchorStyles) ((((System.Windows.Forms.AnchorStyles.Top |
                                                         System.Windows.Forms.AnchorStyles.Bottom)
                                                        | System.Windows.Forms.AnchorStyles.Left)
                                                       | System.Windows.Forms.AnchorStyles.Right)));
            this.tabIntro.Controls.Add(this.label3);
            this.tabIntro.Controls.Add(this.label2);
            this.tabIntro.Controls.Add(this.label1);
            this.tabIntro.Location = new System.Drawing.Point(0, 0);
            this.tabIntro.Name = "tabIntro";
            this.tabIntro.Selected = false;
            this.tabIntro.Size = new System.Drawing.Size(700, 443);
            this.tabIntro.TabIndex = 3;
            this.tabIntro.Title = "Pagina 1 di 5";
            // 
            // label3
            // 
            this.label3.Anchor =
                ((System.Windows.Forms.AnchorStyles) (((System.Windows.Forms.AnchorStyles.Top |
                                                        System.Windows.Forms.AnchorStyles.Left)
                                                       | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.Location = new System.Drawing.Point(8, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(668, 48);
            this.label3.TabIndex = 2;
            this.label3.Text = "Saranno considerati solo i dettagli non ancora associati a movimenti finanziari, " +
                               "inoltre il movimento dovrà avere il  percipiente uguale al fornitore del contrat" +
                               "to passivo o dei dettagli.";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(8, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(689, 23);
            this.label2.TabIndex = 1;
            this.label2.Text = "Sarà possibile creare nuovi movimenti oppure associare i dettagli a movimenti già" +
                               " creati.";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(8, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(689, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Questo wizard serve a contabilizzare in finanziario uno o più dettagli di un cont" +
                               "ratto passivo.";
            // 
            // tabSelDetail
            // 
            this.tabSelDetail.Anchor =
                ((System.Windows.Forms.AnchorStyles) ((((System.Windows.Forms.AnchorStyles.Top |
                                                         System.Windows.Forms.AnchorStyles.Bottom)
                                                        | System.Windows.Forms.AnchorStyles.Left)
                                                       | System.Windows.Forms.AnchorStyles.Right)));
            this.tabSelDetail.Controls.Add(this.groupBox5);
            this.tabSelDetail.Controls.Add(this.cmbTipoOrdine);
            this.tabSelDetail.Controls.Add(this.txtDescrOrdine);
            this.tabSelDetail.Controls.Add(this.labDescrOrdine);
            this.tabSelDetail.Controls.Add(this.txtFornitore);
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
            this.tabSelDetail.Size = new System.Drawing.Size(700, 443);
            this.tabSelDetail.TabIndex = 5;
            this.tabSelDetail.Title = "Pagina 2 di 5";
            // 
            // groupBox5
            // 
            this.groupBox5.Anchor =
                ((System.Windows.Forms.AnchorStyles) (((System.Windows.Forms.AnchorStyles.Top |
                                                        System.Windows.Forms.AnchorStyles.Left)
                                                       | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox5.Controls.Add(this.txtResponsabileContratto);
            this.groupBox5.Location = new System.Drawing.Point(431, 78);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(262, 52);
            this.groupBox5.TabIndex = 117;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Responsabile";
            // 
            // txtResponsabileContratto
            // 
            this.txtResponsabileContratto.Anchor =
                ((System.Windows.Forms.AnchorStyles) (((System.Windows.Forms.AnchorStyles.Top |
                                                        System.Windows.Forms.AnchorStyles.Left)
                                                       | System.Windows.Forms.AnchorStyles.Right)));
            this.txtResponsabileContratto.Location = new System.Drawing.Point(8, 16);
            this.txtResponsabileContratto.Multiline = true;
            this.txtResponsabileContratto.Name = "txtResponsabileContratto";
            this.txtResponsabileContratto.ReadOnly = true;
            this.txtResponsabileContratto.Size = new System.Drawing.Size(248, 26);
            this.txtResponsabileContratto.TabIndex = 1;
            this.txtResponsabileContratto.Tag = "";
            // 
            // cmbTipoOrdine
            // 
            this.cmbTipoOrdine.DataSource = this.DS.mandatekind;
            this.cmbTipoOrdine.DisplayMember = "description";
            this.cmbTipoOrdine.Location = new System.Drawing.Point(120, 8);
            this.cmbTipoOrdine.Name = "cmbTipoOrdine";
            this.cmbTipoOrdine.Size = new System.Drawing.Size(256, 23);
            this.cmbTipoOrdine.TabIndex = 116;
            this.cmbTipoOrdine.ValueMember = "idmankind";
            this.cmbTipoOrdine.SelectedIndexChanged += new System.EventHandler(this.cmbTipoOrdine_SelectedIndexChanged);
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaFrm";
            this.DS.EnforceConstraints = false;
            // 
            // txtDescrOrdine
            // 
            this.txtDescrOrdine.Anchor =
                ((System.Windows.Forms.AnchorStyles) (((System.Windows.Forms.AnchorStyles.Top |
                                                        System.Windows.Forms.AnchorStyles.Left)
                                                       | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescrOrdine.Location = new System.Drawing.Point(88, 85);
            this.txtDescrOrdine.Multiline = true;
            this.txtDescrOrdine.Name = "txtDescrOrdine";
            this.txtDescrOrdine.ReadOnly = true;
            this.txtDescrOrdine.Size = new System.Drawing.Size(337, 44);
            this.txtDescrOrdine.TabIndex = 115;
            // 
            // labDescrOrdine
            // 
            this.labDescrOrdine.Location = new System.Drawing.Point(4, 88);
            this.labDescrOrdine.Name = "labDescrOrdine";
            this.labDescrOrdine.Size = new System.Drawing.Size(80, 16);
            this.labDescrOrdine.TabIndex = 114;
            this.labDescrOrdine.Text = "Descrizione";
            this.labDescrOrdine.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtFornitore
            // 
            this.txtFornitore.Anchor =
                ((System.Windows.Forms.AnchorStyles) (((System.Windows.Forms.AnchorStyles.Top |
                                                        System.Windows.Forms.AnchorStyles.Left)
                                                       | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFornitore.Location = new System.Drawing.Point(88, 56);
            this.txtFornitore.Name = "txtFornitore";
            this.txtFornitore.ReadOnly = true;
            this.txtFornitore.Size = new System.Drawing.Size(604, 23);
            this.txtFornitore.TabIndex = 113;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(4, 56);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 16);
            this.label6.TabIndex = 112;
            this.label6.Text = "Fornitore";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chkAddContab
            // 
            this.chkAddContab.Anchor =
                ((System.Windows.Forms.AnchorStyles) (((System.Windows.Forms.AnchorStyles.Top |
                                                        System.Windows.Forms.AnchorStyles.Left)
                                                       | System.Windows.Forms.AnchorStyles.Right)));
            this.chkAddContab.Location = new System.Drawing.Point(408, 8);
            this.chkAddContab.Name = "chkAddContab";
            this.chkAddContab.Size = new System.Drawing.Size(284, 40);
            this.chkAddContab.TabIndex = 111;
            this.chkAddContab.Text = "Associare i dettagli selezionati ad un movimento finanziario esistente";
            this.chkAddContab.CheckedChanged += new System.EventHandler(this.chkAddContab_CheckedChanged);
            // 
            // btnSelectAllDetail
            // 
            this.btnSelectAllDetail.Anchor =
                ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Top |
                                                       System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelectAllDetail.Location = new System.Drawing.Point(596, 144);
            this.btnSelectAllDetail.Name = "btnSelectAllDetail";
            this.btnSelectAllDetail.Size = new System.Drawing.Size(96, 23);
            this.btnSelectAllDetail.TabIndex = 110;
            this.btnSelectAllDetail.Text = "Seleziona tutto";
            this.btnSelectAllDetail.Click += new System.EventHandler(this.btnSelectAllDetail_Click);
            // 
            // label18
            // 
            this.label18.Anchor =
                ((System.Windows.Forms.AnchorStyles) (((System.Windows.Forms.AnchorStyles.Top |
                                                        System.Windows.Forms.AnchorStyles.Left)
                                                       | System.Windows.Forms.AnchorStyles.Right)));
            this.label18.Location = new System.Drawing.Point(8, 176);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(684, 16);
            this.label18.TabIndex = 109;
            this.label18.Text = "Selezionare i dettagli da contabilizzare (sono visualizzati solo i dettagli a cui" +
                                " non è associata una data di annullamento)";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor =
                ((System.Windows.Forms.AnchorStyles) (((System.Windows.Forms.AnchorStyles.Bottom |
                                                        System.Windows.Forms.AnchorStyles.Left)
                                                       | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.txtTotGenerale);
            this.groupBox2.Controls.Add(this.txtTotIva);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txtTotImponibile);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Location = new System.Drawing.Point(8, 364);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(684, 72);
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
                ((System.Windows.Forms.AnchorStyles) ((((System.Windows.Forms.AnchorStyles.Top |
                                                         System.Windows.Forms.AnchorStyles.Bottom)
                                                        | System.Windows.Forms.AnchorStyles.Left)
                                                       | System.Windows.Forms.AnchorStyles.Right)));
            this.gridDetails.DataMember = "";
            this.gridDetails.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.gridDetails.Location = new System.Drawing.Point(8, 200);
            this.gridDetails.Name = "gridDetails";
            this.gridDetails.Size = new System.Drawing.Size(684, 158);
            this.gridDetails.TabIndex = 103;
            this.gridDetails.Paint += new System.Windows.Forms.PaintEventHandler(this.gridDetails_Paint);
            // 
            // cmbCausale
            // 
            this.cmbCausale.DataSource = this.DS.tipomovimento;
            this.cmbCausale.DisplayMember = "descrizione";
            this.cmbCausale.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F,
                System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World, ((byte) (0)));
            this.cmbCausale.ItemHeight = 13;
            this.cmbCausale.Location = new System.Drawing.Point(88, 136);
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
            this.labelCausale.Location = new System.Drawing.Point(32, 136);
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
            this.btnDocumento.Text = "Contratto Passivo";
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
            // tabSplit
            // 
            this.tabSplit.Anchor =
                ((System.Windows.Forms.AnchorStyles) ((((System.Windows.Forms.AnchorStyles.Top |
                                                         System.Windows.Forms.AnchorStyles.Bottom)
                                                        | System.Windows.Forms.AnchorStyles.Left)
                                                       | System.Windows.Forms.AnchorStyles.Right)));
            this.tabSplit.Controls.Add(this.groupBox3);
            this.tabSplit.Controls.Add(this.label23);
            this.tabSplit.Controls.Add(this.label22);
            this.tabSplit.Controls.Add(this.txtPerc);
            this.tabSplit.Controls.Add(this.label17);
            this.tabSplit.Controls.Add(this.txtDaPagare);
            this.tabSplit.Location = new System.Drawing.Point(0, 0);
            this.tabSplit.Name = "tabSplit";
            this.tabSplit.Selected = false;
            this.tabSplit.Size = new System.Drawing.Size(700, 443);
            this.tabSplit.TabIndex = 7;
            this.tabSplit.Title = "Page 3 di 5";
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor =
                ((System.Windows.Forms.AnchorStyles) (((System.Windows.Forms.AnchorStyles.Top |
                                                        System.Windows.Forms.AnchorStyles.Left)
                                                       | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.lblCausale);
            this.groupBox3.Controls.Add(this.txtTotSelezionato);
            this.groupBox3.Controls.Add(this.label19);
            this.groupBox3.Controls.Add(this.rdbSplittaUno);
            this.groupBox3.Controls.Add(this.rdbSplittaTutti);
            this.groupBox3.Location = new System.Drawing.Point(4, 4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(693, 131);
            this.groupBox3.TabIndex = 0;
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
            this.txtTotSelezionato.Anchor =
                ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Top |
                                                       System.Windows.Forms.AnchorStyles.Right)));
            this.txtTotSelezionato.Location = new System.Drawing.Point(536, 26);
            this.txtTotSelezionato.Name = "txtTotSelezionato";
            this.txtTotSelezionato.ReadOnly = true;
            this.txtTotSelezionato.Size = new System.Drawing.Size(130, 23);
            this.txtTotSelezionato.TabIndex = 0;
            this.txtTotSelezionato.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label19
            // 
            this.label19.Anchor =
                ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Top |
                                                       System.Windows.Forms.AnchorStyles.Right)));
            this.label19.Location = new System.Drawing.Point(336, 33);
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
            this.rdbSplittaUno.Size = new System.Drawing.Size(565, 19);
            this.rdbSplittaUno.TabIndex = 1;
            this.rdbSplittaUno.TabStop = true;
            this.rdbSplittaUno.Text =
                "Contabilizza interamente i dettagli fino a coprire l\'importo da pagare. Sarà sudd" +
                "iviso al più un dettaglio";
            this.rdbSplittaUno.UseVisualStyleBackColor = true;
            // 
            // rdbSplittaTutti
            // 
            this.rdbSplittaTutti.AutoSize = true;
            this.rdbSplittaTutti.Location = new System.Drawing.Point(18, 93);
            this.rdbSplittaTutti.Name = "rdbSplittaTutti";
            this.rdbSplittaTutti.Size = new System.Drawing.Size(511, 19);
            this.rdbSplittaTutti.TabIndex = 2;
            this.rdbSplittaTutti.Text =
                "Distribuisci l\'importo da pagare su tutti i dettagli selezionati. Tutti i dettagl" +
                "i saranno suddivisi";
            this.rdbSplittaTutti.UseVisualStyleBackColor = true;
            // 
            // label23
            // 
            this.label23.Location = new System.Drawing.Point(347, 148);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(128, 16);
            this.label23.TabIndex = 0;
            this.label23.Text = "Importo";
            this.label23.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label22
            // 
            this.label22.Location = new System.Drawing.Point(278, 148);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(56, 16);
            this.label22.TabIndex = 0;
            this.label22.Text = "%";
            this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtPerc
            // 
            this.txtPerc.Location = new System.Drawing.Point(275, 164);
            this.txtPerc.Name = "txtPerc";
            this.txtPerc.Size = new System.Drawing.Size(64, 23);
            this.txtPerc.TabIndex = 3;
            this.txtPerc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtPerc.Leave += new System.EventHandler(this.txtPerc_Leave);
            // 
            // label17
            // 
            this.label17.Location = new System.Drawing.Point(21, 162);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(224, 23);
            this.label17.TabIndex = 0;
            this.label17.Text = "Inserire il valore che si desidera pagare:";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtDaPagare
            // 
            this.txtDaPagare.Location = new System.Drawing.Point(347, 164);
            this.txtDaPagare.Name = "txtDaPagare";
            this.txtDaPagare.Size = new System.Drawing.Size(112, 23);
            this.txtDaPagare.TabIndex = 4;
            this.txtDaPagare.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtDaPagare.Leave += new System.EventHandler(this.txtDaPagare_Leave);
            // 
            // tabConfirm
            // 
            this.tabConfirm.Controls.Add(this.gboxBilToCreate);
            this.tabConfirm.Controls.Add(this.labMsgTODO2);
            this.tabConfirm.Controls.Add(this.labMsgTODO1);
            this.tabConfirm.Location = new System.Drawing.Point(0, 0);
            this.tabConfirm.Name = "tabConfirm";
            this.tabConfirm.Selected = false;
            this.tabConfirm.Size = new System.Drawing.Size(700, 443);
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
            this.gboxBilToCreate.Size = new System.Drawing.Size(336, 56);
            this.gboxBilToCreate.TabIndex = 91;
            this.gboxBilToCreate.TabStop = false;
            this.gboxBilToCreate.Tag = "";
            // 
            // label14
            // 
            this.label14.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label14.Location = new System.Drawing.Point(8, 11);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(64, 13);
            this.label14.TabIndex = 3;
            this.label14.Text = "Bilancio";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtCodeBilSelected
            // 
            this.txtCodeBilSelected.Location = new System.Drawing.Point(8, 24);
            this.txtCodeBilSelected.Name = "txtCodeBilSelected";
            this.txtCodeBilSelected.ReadOnly = true;
            this.txtCodeBilSelected.Size = new System.Drawing.Size(120, 23);
            this.txtCodeBilSelected.TabIndex = 1;
            this.txtCodeBilSelected.Tag = "";
            // 
            // txtDenomBilSelected
            // 
            this.txtDenomBilSelected.Location = new System.Drawing.Point(136, 8);
            this.txtDenomBilSelected.Multiline = true;
            this.txtDenomBilSelected.Name = "txtDenomBilSelected";
            this.txtDenomBilSelected.ReadOnly = true;
            this.txtDenomBilSelected.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDenomBilSelected.Size = new System.Drawing.Size(192, 40);
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
                ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Bottom |
                                                       System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(631, 489);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 16;
            this.btnCancel.Tag = "maincancel";
            this.btnCancel.Text = "Cancel";
            // 
            // btnNext
            // 
            this.btnNext.Anchor =
                ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Bottom |
                                                       System.Windows.Forms.AnchorStyles.Right)));
            this.btnNext.Location = new System.Drawing.Point(511, 489);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(88, 23);
            this.btnNext.TabIndex = 15;
            this.btnNext.Text = "Avanti >";
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnBack
            // 
            this.btnBack.Anchor =
                ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Bottom |
                                                       System.Windows.Forms.AnchorStyles.Right)));
            this.btnBack.Location = new System.Drawing.Point(423, 489);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(80, 23);
            this.btnBack.TabIndex = 14;
            this.btnBack.Text = "< Indietro";
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor =
                ((System.Windows.Forms.AnchorStyles) ((((System.Windows.Forms.AnchorStyles.Top |
                                                         System.Windows.Forms.AnchorStyles.Bottom)
                                                        | System.Windows.Forms.AnchorStyles.Left)
                                                       | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.tabController);
            this.panel1.Location = new System.Drawing.Point(8, 8);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(700, 468);
            this.panel1.TabIndex = 17;
            // 
            // FrmWizardMandateDetail
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(727, 518);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.panel1);
            this.Name = "FrmWizardMandateDetail";
            this.Text = "FrmWizardMandateDetail";
            this.tabController.ResumeLayout(false);
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
            this.tabIntro.ResumeLayout(false);
            this.tabSelDetail.ResumeLayout(false);
            this.tabSelDetail.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize) (this.DS)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize) (this.gridDetails)).EndInit();
            this.tabSplit.ResumeLayout(false);
            this.tabSplit.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
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
                string filteridreg = "";
                string filterupb_forexpense = "";
                bool stop = false;
                genMultipla = SetGenMultipla(Selected, out upb, out registry, out filterupb, out filterupb_forexpense,
                    out filteridreg, out stop);

                if (stop) return false;
                if (genMultipla) {
                    rdbSplittaTutti.Enabled = false;
                    rdbSplittaUno.Enabled = false;

                    txtDaPagare.ReadOnly = true;
                    txtPerc.ReadOnly = true;
                }
                else {
                    rdbSplittaTutti.Enabled = true;
                    rdbSplittaUno.Enabled = true;

                    txtDaPagare.ReadOnly = false;
                    txtPerc.ReadOnly = false;
                }

                txtDaPagare.Text = txtTotSelezionato.Text;
                txtPerc.Text = "100";
                return true;
            }

            if ((oldTab == 2) && (newTab == 1)) {
                VisualizzaUPB();
                VisualizzaRegistry();
                AggiornaGridDettagliOrdine();
                rdbSplittaTutti.Checked = false;
                txtDaPagare.Text = "";
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

        CQueryHelper QHC;
        QueryHelper QHS;

        public void MetaData_AfterActivation() {
            CustomTitle = "Wizard Contabilizzazione Dettagli Contratto Passivo";
            //Selects first tab
            DisplayTabs(0);
        }

        bool SetGenMultipla(DataRow[] SelectedRows, out object[] upb, out object[] registry,
            out string filterupb, out string filterupb_forexpense, out string filteridreg, out bool stop) {
            string field = "idupb";
            int causale = CfgFn.GetNoNullInt32(cmbCausale.SelectedValue);
            if (causale == 2) {
                field = "idupb_iva";
            }

            stop = false;
            // Legge i dettagli con l'importo originale nel dataset
            foreach (DataRow Det in SelectedRows) {
                string filtermandatedetail = QueryCreator.WHERE_COLNAME_CLAUSE(
                    Det, new string[] {"idmankind", "yman", "nman", "rownum"}, DataRowVersion.Default, true);
                DataAccess.RUN_SELECT_INTO_TABLE(Conn, DS.Tables["mandatedetail"], null, filtermandatedetail, null,
                    false);
            }

            object[] upb1 = ValoriDiversi2(SelectedRows, field, "idupb");
            object[] registry1 = ValoriDiversi(SelectedRows, "idreg");
            string filteridreg1 = "";
            string filterupb1 = "";
            string filterupbForexpense1 = "";
            DataRow M = DS.mandate.Rows[0];
            DataTable mandateKind = Conn.RUN_SELECT("mandatekind", "*", null,
                QHS.CmpEq("idmankind", M["idmankind"]), null, null, true);
            // in base alla configurazione del tipo ordine, prendo il fornitore dell'ordine
            // oppure i fornitori dei vari dettagli

            if (mandateKind.Rows.Count > 0) {
                string multiReg = mandateKind.Rows[0]["multireg"].ToString();
                if (multiReg == "N") { // Anagrafe nell'ordine
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
                var Details = FiltraRows(SelectedRows, QHC.IsNotNull(field));
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
                if (field == "idupb_iva") {
                    filterupb1 = QHC.CmpEq("isnull(idupb_iva,idupb)", idupb);
                    filterupbForexpense1 = QHC.CmpEq("idupb", idupb);
                }
                else {
                    filterupb1 = QHC.CmpEq(field, idupb);
                    filterupbForexpense1 = QHC.CmpEq("idupb", idupb);
                }
            }
            else {
                filterupb1 = filter;
                filterupbForexpense1 = filter;
            }

            object objidreg = registry1[0];
            //string idreg = objidreg.ToString();

            if (objidreg != DBNull.Value)
                filteridreg1 = QHC.CmpEq("idreg", objidreg);
            else {
                MessageBox.Show(" Il fornitore non è correttamente impostato." +
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
            filterupb_forexpense = filterupbForexpense1;
            filteridreg = filteridreg1;
            return genMultipla;
        }

        private bool isNumeric(string str, out int valore) {
            valore = 0;
            try {
                valore = Convert.ToInt32(str);
                return true;
            }
            catch {
                return false;
            }
        }

        DataRow GetGridRow(DataGrid G, int index) {
            string TableName = G.DataMember.ToString();
            DataSet MyDS = (DataSet) G.DataSource;
            DataTable MyTable = MyDS.Tables[TableName];
            string filter;
            filter = QHC.AppAnd(QHC.CmpEq("idmankind", G[index, 0]), QHC.CmpEq("yman", G[index, 1]),
                QHC.CmpEq("nman", G[index, 2]), QHC.CmpEq("rownum", G[index, 3]));
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
            GetData.CacheTable(DS.expensephase);
            string filteresercizio = QHS.CmpEq("ayear", Meta.GetSys("esercizio"));
            GetData.CacheTable(DS.config, filteresercizio, null, false);
            GetData.CacheTable(DS.mandatekind, null, "description", true);
            GetData.SetStaticFilter(DS.mandatekind, QHS.NullOrEq("isrequest", "N"));

            faseordine = CfgFn.GetNoNullInt32(Meta.GetSys("mandatephase"));
            if (faseordine == 0) {
                MessageBox.Show("E' necessario configurare la fase di contabilizzazione dell'ordine", "Avviso");
            }

            DataAccess.SetTableForReading(DS.registry1, "registry");
            DataAccess.SetTableForReading(DS.registry2, "registry");
            DetailsToUpdate = new ArrayList();
        }

        public void MetaData_AfterClear() {
            DisplayTabs(tabController.SelectedIndex);
        }


        private void btnDocumento_Click(object sender, System.EventArgs e) {
            //bool allMandate= chkAddContab.Checked;
            string filter = "";
            int esercizio = (int) Meta.GetSys("esercizio");
            int esercText = CfgFn.GetNoNullInt32(txtEsercDoc.Text);
            //if (esercText==0) esercText=esercizio;
            if (esercText != 0)
                filter = GetData.MergeFilters(filter, QHS.CmpEq("yman", esercText));

            if ((!sender.Equals(btnDocumento)) && txtNumDoc.Text.Trim() != "") {
                int ndoc = CfgFn.GetNoNullInt32(txtNumDoc.Text);
                if (ndoc > 0) filter = GetData.MergeFilters(filter, QHS.CmpEq("nman", ndoc));
            }

            if (cmbTipoOrdine.SelectedIndex > 0) {
                filter = GetData.MergeFilters(filter, QHS.CmpEq("idmankind", cmbTipoOrdine.SelectedValue));
            }

            filter = GetData.MergeFilters(filter, QHS.CmpGt("residual", 0));
            filter = QHS.AppAnd(filter, QHS.CmpEq("idmandatestatus", 5)); // stato approvato
            filter = QHS.AppAnd(filter, QHS.NullOrEq("isrequest", "N")); // vero ordine
            filter = QHS.AppAnd(filter, QHS.NullOrEq("active", "S"));
            MetaData Mandate = MetaData.GetMetaData(this, "mandateexpavailable");
            Mandate.FilterLocked = true;
            Mandate.DS = new DataSet();
            DataRow M = Mandate.SelectOne("default", filter, null, null);
            if (M == null) return;
            HelpForm.SetComboBoxValue(cmbTipoOrdine, M["idmankind"]);
            txtEsercDoc.Text = M["yman"].ToString();
            txtNumDoc.Text = M["nman"].ToString();
            txtFornitore.Text = M["registry"].ToString();
            txtDescrOrdine.Text = M["description"].ToString();

            DS.mandatedetail.Clear();
            DetailsToUpdate.Clear();
            DS.mandate.Clear();

            string filtermandate = QHS.AppAnd(QHS.CmpEq("idmankind", M["idmankind"]),
                QHS.CmpEq("yman", M["yman"]), QHS.CmpEq("nman", M["nman"]));

            DataAccess.RUN_SELECT_INTO_TABLE(Conn, DS.mandate, null, filtermandate, null, false);
            if (DS.mandate.Rows.Count > 0) {
                object idman = DS.mandate.Rows[0]["idman"];
                if (idman != DBNull.Value) {
                    string manager = Conn.DO_READ_VALUE("manager", QHS.CmpEq("idman", idman), "title").ToString();
                    txtResponsabileContratto.Text = manager;
                }
                else txtResponsabileContratto.Text = "";
            }

            SetComboCausaleOrdine(M);
            AggiornaGridDettagliOrdine();
        }

        void ResetWizard() {
            if (DS.mandate.Rows.Count > 0)
                SetComboCausaleOrdine(DS.mandate.Rows[0]);
            gridDetails.DataSource = null;
            AggiornaGridDettagliOrdine();
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
        /// <param name="Ordine"></param>
        void SetComboCausaleOrdine(DataRow Ordine) {
            decimal totimponibile = 0;
            decimal totiva = 0;
            decimal assigned_imponibile = 0;
            decimal assigned_iva = 0;
            decimal assigned_gen = 0;
            bool EnableImpon = true;
            bool EnableImpos = true;
            bool EnableDocum = true;
            bool intracom = false;

            string filterordine = QHS.AppAnd(QHS.CmpEq("idmankind", Ordine["idmankind"]),
                QHS.CmpEq("yman", Ordine["yman"]), QHS.CmpEq("nman", Ordine["nman"]));

            DataTable T = Conn.RUN_SELECT("mandateresidual", "*", null, filterordine, null, true);
            bool recuperoIvaEstera = false;
            if ((T != null) && (T.Rows.Count > 0)) {
                //DataRow R=T.Rows[0];
                //totimponibile=CfgFn.GetNoNullDecimal(R["taxabletotal"]);
                //totiva=CfgFn.GetNoNullDecimal(R["ivatotal"]);
                foreach (DataRow Dett in T.Rows) {
                    totimponibile += CfgFn.GetNoNullDecimal(Dett["taxabletotal"]);
                    totiva += CfgFn.GetNoNullDecimal(Dett["ivatotal"]);
                    assigned_imponibile += CfgFn.GetNoNullDecimal(Dett["linkedimpon"]);
                    assigned_iva += CfgFn.GetNoNullDecimal(Dett["linkedimpos"]);
                    assigned_gen += CfgFn.GetNoNullDecimal(Dett["linkedordin"]);
                    if (Dett["flagintracom"].ToString().ToUpper() != "N") intracom = true;
                    int flag = CfgFn.GetNoNullInt32(Dett["flagbit"]);
                    if ((flag & 1) != 0) {
                        recuperoIvaEstera = true;
                    }
                }
            }

            ClearComboCausale();

            if ((intracom) && (!recuperoIvaEstera)) {
                EnableDocum = false;
                EnableImpos = false;
            }

            if (EnableDocum &&
                ((assigned_imponibile + assigned_iva) == 0) &&
                (assigned_gen < (totimponibile + totiva))
            ) {
                EnableTipoMovimento(1, "Contabilizzazione Totale Contratto Passivo");
            }

            if (EnableImpon &&
                ((assigned_gen == 0) && (assigned_imponibile < totimponibile))
            ) {
                EnableTipoMovimento(3, "Contabilizzazione Imponibile Contratto Passivo");
            }

            if (EnableImpos &&
                ((assigned_gen == 0) && (assigned_iva < totiva))
            ) {
                EnableTipoMovimento(2, "Contabilizzazione Iva Contratto Passivo");
            }
        }

        void AggiornaGridDettagliOrdine() {
            DS.mandatedetail.Clear();
            DetailsToUpdate.Clear();
            if (cmbCausale.SelectedIndex < 0) return;
            int causale = CfgFn.GetNoNullInt32(cmbCausale.SelectedValue);
            if (causale == 0) return;
            string filtercausale = QHC.CmpEq("idtipo", causale);
            lblCausale.Text = "Sulla Causale: " +
                              DS.tipomovimento.Select(filtercausale, null)[0]["descrizione"].ToString();
            if (DS.mandate.Rows.Count == 0) return;

            DataRow M = DS.mandate.Rows[0];
            string filtermandate = QHS.AppAnd(QHS.CmpEq("idmankind", M["idmankind"]),
                QHS.CmpEq("yman", M["yman"]), QHS.CmpEq("nman", M["nman"]));
            string filtermandatedetail = filtermandate;
            //filtermandatedetail=GetData.MergeFilters(filtermandatedetail, "(idupb is not null)");
            filtermandatedetail = GetData.MergeFilters(filtermandatedetail, QHS.IsNull("stop"));
            if (causale == 1) {
                // Se è abilitato ORDIN significa che non ci sono contabilizzazioni diverse da ORDIN attivate,
                // ossia tutti i dettagli sono o contabilizzati del tutto o per niente
                // --> basta un filtro su idexp_iva is null
                filtermandatedetail = GetData.MergeFilters(filtermandatedetail,
                    QHS.AppAnd(QHS.IsNull("idexp_iva"), QHS.IsNull("idexp_taxable")));
            }

            if (causale == 3) {
                // Se è abilitato IMPON significa che non ci sono contabilizzazioni ORDIN attivate,
                // ossia tutti i dettagli sono contabilizzati con imponibile + iva
                // --> basta un filtro su idexp_taxable is null
                filtermandatedetail = GetData.MergeFilters(filtermandatedetail, QHS.IsNull("idexp_taxable"));
            }

            if (causale == 2) {
                // Se è abilitato IMPOS significa che non ci sono contabilizzazioni diverse da ORDIN attivate,
                // ossia tutti i dettagli sono o contabilizzati con imponibile + iva
                // --> basta un filtro su idexp_iva is null
                filtermandatedetail = GetData.MergeFilters(filtermandatedetail, QHS.IsNull("idexp_iva"));
            }

            DSCopy = DS.Copy();
            DataAccess.RUN_SELECT_INTO_TABLE(Conn, DSCopy.Tables["mandatedetail"], null, filtermandatedetail, null,
                false);
            MetaData MD = MetaData.GetMetaData(this, "mandatedetail");
            MD.DS = DSCopy;
            MD.DescribeColumns(DSCopy.Tables["mandatedetail"], "default");
            GetData GD = new GetData();
            GD.InitClass(DSCopy, Conn, "mandatedetail");
            //foreach (DataRow r in DSCopy.Tables["mandatedetail"].Select()) {
            //    if (r["idupb_iva"] == DBNull.Value)
            //        r["idupb_iva"] = r["idupb"];
            //    r.AcceptChanges();
            //}
            GD.GetTemporaryValues(DSCopy.Tables["mandatedetail"]);
            gridDetails.DataSource = null;
            HelpForm.SetDataGrid(gridDetails, DSCopy.Tables["mandatedetail"]);
            btnSelectAllDetail_Click(null, null);
            VisualizzaUPB();
            VisualizzaRegistry();
            RecalcTotalDetails();
        }

        private void cmbCausale_SelectedIndexChanged(object sender, System.EventArgs e) {
            AggiornaGridDettagliOrdine();
        }

        void ClearOrdine() {
            //txtEsercDoc.Text="";
            txtNumDoc.Text = "";
            txtDescrOrdine.Text = "";
            txtFornitore.Text = "";
            txtResponsabileContratto.Text = "";
            DS.mandate.Clear();
            if (DSCopy != null) {
                DSCopy.Tables["mandatedetail"].Clear();
            }

            DS.mandatedetail.Clear();
            DetailsToUpdate.Clear();
            RecalcTotalDetails();
        }

        private void txtEsercDoc_Leave(object sender, System.EventArgs e) {
            int YMan = CfgFn.GetNoNullInt32(txtEsercDoc.Text);
            if (YMan <= 0) {
                ClearOrdine();
                return;
            }

            if (YMan < 1000) {
                YMan += 2000;
                txtEsercDoc.Text = YMan.ToString();
            }

            if (txtNumDoc.Text.Trim() != "") {
                btnDocumento_Click(sender, e);
                return;
            }
        }

        private void txtNumDoc_Leave(object sender, System.EventArgs e) {
            int NMan = CfgFn.GetNoNullInt32(txtNumDoc.Text);
            if (NMan <= 0) {
                ClearOrdine();
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
                for (int i = 0; i < DSCopy.Tables["mandatedetail"].Rows.Count; i++) gridDetails.Select(i);
            }
        }

        void RecalcTotalDetails() {
            txtDaPagare.Text = "";
            txtPerc.Text = "";
            DataRow[] Selected = GetGridSelectedRows(gridDetails);
            if ((Selected == null) || (Selected.Length == 0)) {
                txtTotGenerale.Text = "";
                txtTotImponibile.Text = "";
                txtTotIva.Text = "";
                TotaleDaContabilizzare = 0;
                return;
            }

            if (DS.mandate.Rows.Count == 0) return;
            DataRow Mandate = DS.mandate.Rows[0];
            double tassocambio = CfgFn.GetNoNullDouble(Mandate["exchangerate"]);
            if (tassocambio == 0) tassocambio = 1;
            double totiva = 0;
            double totimpo = 0;
            double total = 0;
            int causale = CfgFn.GetNoNullInt32(cmbCausale.SelectedValue);
            foreach (DataRow Curr in Selected) {
                double imponibile = CfgFn.GetNoNullDouble(Curr["taxable"]);
                double QuantitaConfezioni = CfgFn.GetNoNullDouble(Curr["npackage"]);
                double aliquota = CfgFn.GetNoNullDouble(Curr["taxrate"]);
                double sconto = CfgFn.GetNoNullDouble(Curr["discount"]);
                double imponibileEUR = (imponibile * QuantitaConfezioni * (1 - sconto)) * tassocambio;
                double ivaEUR = CfgFn.GetNoNullDouble(Curr["tax"]); // *tassocambio;
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
                txtTotGenerale.Enabled = true;
                txtTotGenerale.Text = total.ToString("C");
                txtTotImponibile.Text = totimpo.ToString("C");
                txtTotIva.Text = totiva.ToString("C");
                TotaleDaContabilizzare = CfgFn.GetNoNullDecimal(total);
                txtTotSelezionato.Text = total.ToString("C");
            }

        }

        void VisualizzaUPB() {
            DataTable Details = DSCopy.Tables["mandatedetail"];
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
            DataTable Details = DSCopy.Tables["mandatedetail"];
            object idreg;
            object title;
            if (Details.Rows.Count == 0) return;
            foreach (DataRow Curr in Details.Rows) {
                idreg = Curr["idreg"];
                if (idreg != DBNull.Value) {
                    string filterregistry = QHS.CmpEq("idreg", idreg);
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

            //ClearOrdine();
        }


        private decimal CalcolaTotCausale(DataRow MandateDetail, int causale) {
            double tassocambio = CfgFn.GetNoNullDouble(DS.mandate.Rows[0]["exchangerate"]);
            if (tassocambio == 0) tassocambio = 1;
            DataRow Curr = MandateDetail;

            double imponibile = CfgFn.GetNoNullDouble(Curr["taxable"]);
            double QuantitaConfezioni = CfgFn.GetNoNullDouble(Curr["npackage"]);
            double aliquota = CfgFn.GetNoNullDouble(Curr["taxrate"]);
            double sconto = CfgFn.GetNoNullDouble(Curr["discount"]);
            double imponibileEUR = (imponibile * QuantitaConfezioni * (1 - sconto)) * tassocambio;
            double ivaEUR = CfgFn.GetNoNullDouble(Curr["tax"]); // *tassocambio;
            //double ivaEUR      = imponibileEUR*aliquota;
            imponibileEUR = CfgFn.RoundValuta(imponibileEUR);
            ivaEUR = CfgFn.RoundValuta(ivaEUR);
            if (causale == 1) return CfgFn.GetNoNullDecimal(ivaEUR + imponibileEUR);
            if (causale == 3) return CfgFn.GetNoNullDecimal(imponibileEUR);
            return CfgFn.GetNoNullDecimal(ivaEUR);
        }

        decimal CalcTotCausale(DataRow[] MandateDetail, int causale, bool genMultipla) {
            decimal sum = 0;

            foreach (DataRow R in MandateDetail) sum += CalcolaTotCausale(R, causale);
            if (genMultipla) return sum;
            // verifica se l'importo da contabilizzare è diverso da quello digitato dall'utente

            decimal importototale = CfgFn.GetNoNullDecimal(
                HelpForm.GetObjectFromString(typeof(decimal),
                    txtDaPagare.Text, "x.y.c"));
            if (importototale != 0 && importototale != sum) sum = importototale;
            return sum;
        }


        bool SelezioneMovimentiEffettuata = false;


        string FilterAddCont = null;

        object[] ValoriDiversi2(DataRow[] Rows, string field, string field2) {
            object[] DIV = new object[Rows.Length];
            int N = 0;
            foreach (DataRow R in Rows) {
                object currval = R[field];
                if (currval == DBNull.Value) currval = R[field2];
                int j = 0;
                for (j = 0; j < N; j++) {
                    if (DIV[j].ToString() == currval.ToString()) {
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

        object[] ValoriDiversi(DataRow[] Rows, string field) {
            object[] DIV = new object[Rows.Length];
            int N = 0;
            foreach (DataRow R in Rows) {
                object currval = R[field];
                int j = 0;
                for (j = 0; j < N; j++) {
                    if (DIV[j].ToString() == currval.ToString()) {
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

            //DataTable T = DS.invoicedetail;
            DataTable T = DS.mandatedetail;
            DataRow[] found = T.Select(filter);
            var rowFound = new Dictionary<string, bool>();
            foreach (DataRow r in found) {
                string sk = $"{r["idmankind"]}#{r["yman"]}#{r["nman"]}#{r["rownum"]}";
                rowFound.Add(sk, true);
            }

            foreach (DataRow r in Rows) {
                if (r.RowState == DataRowState.Deleted) continue;
                string sk = $"{r["idmankind"]}#{r["yman"]}#{r["nman"]}#{r["rownum"]}";
                if (rowFound.ContainsKey(sk)) RR.Add(r);
            }

            return RR;
        }



        DataRow AutoSelectedMov = null;

        bool RecalcSelezioneMovimenti() {
            DataRow[] SelectedRows = GetGridSelectedRows(gridDetails);
            if ((SelectedRows == null) || (GetGridSelectedRows(gridDetails).Length == 0)) {
                return false;
            }

            labelAddCont.Text = "";
            labelNewLinkedCont.Text = "";
            int esercizio = (int) Meta.GetSys("esercizio");
            filterMovimento = null;
            AutoSelectedMov = null;
            ClearMovimento();
            DS.expensemandate.Clear();
            string filtermandate;
            FilterAddCont = null;
            //string sumexpr = null;
            DataRow M = DS.mandate.Rows[0];
            filtermandate = QHS.AppAnd(QHS.CmpEq("idmankind", M["idmankind"]),
                QHS.CmpEq("yman", M["yman"]), QHS.CmpEq("nman", M["nman"]));
            int currcausale = CfgFn.GetNoNullInt32(cmbCausale.SelectedValue);
            if (currcausale == 1) {
                foreach (DataRow r in SelectedRows) {
                    if (r["idupb_iva"] != DBNull.Value && r["idupb_iva"].ToString() != r["idupb"].ToString()) {
                        MessageBox.Show("La contabilizzazione totale non può essere usata su dettagli con upb diverse",
                            "Avviso");
                        return false;
                    }

                }
            }

            string fieldtolink = "";
            switch (currcausale) {
                case 1:
                    //sumexpr ="(isnull(SUM(taxable_euro),0)+isnull(SUM(iva_euro),0))";	
                    fieldtolink = "idexp_taxable";
                    break;
                case 3:
                    //sumexpr ="SUM(taxable_euro)";
                    fieldtolink = "idexp_taxable";
                    break;
                case 2:
                    //sumexpr ="SUM(iva_euro)";
                    fieldtolink = "idexp_iva";
                    break;
                default:
                    return false;
            }

            string field = "idupb";
            int causale = CfgFn.GetNoNullInt32(cmbCausale.SelectedValue);
            if (causale == 2) {
                field = "idupb_iva";
            }

            object[] upb = ValoriDiversi(SelectedRows, field);
            object[] registry = ValoriDiversi(SelectedRows, "idreg");
            string filterupb = "";
            string filterupb_forexpense = "";
            string filteridreg = "";
            bool stop = false;
            genMultipla = SetGenMultipla(SelectedRows, out upb, out registry, out filterupb, out filterupb_forexpense,
                out filteridreg, out stop);
            object objidupb = upb[0];
            string idupb = objidupb.ToString();
            decimal importoupb =
                CalcTotCausale(FiltraRows(SelectedRows, filterupb).ToArray(), currcausale, genMultipla);

            string filtercont = "";

            //filtercont= GetData.MergeFilters(filtermandate,filterupb);

            // J.T.R. 06.03.2007 - Il wizard non deve filtrare sull'importo!
            //filtercont= GetData.MergeFilters(filtercont,
            //    "(curramount = "+QueryCreator.quotedstrvalue(importoupb,true) + ")");

            filtercont = GetData.MergeFilters(filtercont,
                "(NOT idexp in (SELECT idexp from expensemandate))");
            filtercont = GetData.MergeFilters(filtercont,
                "(NOT idexp in (SELECT idexp from expenseitineration))");
            filtercont = GetData.MergeFilters(filtercont,
                "(NOT idexp in (SELECT idexp from expensecasualcontract))");
            filtercont = GetData.MergeFilters(filtercont,
                "(NOT idexp in (SELECT idexp from expenseprofservice))");
            filtercont = GetData.MergeFilters(filtercont,
                "(NOT idexp in (SELECT idexp from expenseinvoice))");
            filtercont = GetData.MergeFilters(filtercont,
                "(NOT idexp in (SELECT idexp from expensepayroll))");
            filtercont = GetData.MergeFilters(filtercont,
                "(NOT idexp in (SELECT idexp from expensewageaddition))");

            if (idupb != "") {
                filtercont = GetData.MergeFilters(filtercont, filterupb_forexpense);
            }

            filtercont = GetData.MergeFilters(filtercont, filteridreg);
            filtercont = GetData.MergeFilters(filtercont, QHS.CmpEq("ayear", esercizio));
            filtercont = GetData.MergeFilters(filtercont, QHS.CmpEq("nphase", faseordine));
            filtercont = GetData.MergeFilters(filtercont, QHS.CmpEq("curramount", importoupb));

            DataTable ContabilizzazioniDisponibili = Conn.RUN_SELECT("expenseview",
                "idexp,idupb,ymov,nmov,description,manager,amount,adate,codefin,finance,codeupb,upb,curramount,available",
                null,
                filtercont, null, null, true);

            if (chkAddContab.Checked) {
                // Si desidera aggiungere la contabilizzazione a un movimento esistente
                // Disabilito le altre opzioni 
                // radioNewLinkedMov.Visible=false;
                // radioNewCont.Visible=false;
                // Abilito la terza opzione per aggiungere la contabilizzazione
                radioAddCont.Visible = true;
                radioAddCont.Enabled = true;
                radioAddCont.Checked = true;
                // Deve essere un solo FORNITORE e un solo UPB per tutti i dettagli
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
                    //DS.mandatedetail.RejectChanges();
                    //ClearMovimento();
                    //radioAddCont.Enabled=false;
                    return false;
                }

                // 2. Sono stati individuati più movimenti per contabilizzare i dettagli selezionati
                // abilito il tasto di selezione 
                if (ContabilizzazioniDisponibili.Rows.Count > 1) {
                    MessageBox.Show(
                        "Esistono più movimenti con capienza sufficiente per i dettagli selezionati. Selezionare il movimento");
                    //DS.mandatedetail.RejectChanges();
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
                    //DS.mandatedetail.RejectChanges();
                    //ClearMovimento();
                    //radioAddCont.Enabled=false;
                    //Aggiorna già i dettagli dell'ordine per collegarli ognuno al proprio movimento
                    foreach (DataRow DetailToLink in FiltraRows(SelectedRows, filterupb)) {
                        DetailToLink[fieldtolink] = ContabilizzazioniDisponibili.Rows[0]["idexp"];
                        if (currcausale == 1) {
                            DetailToLink["idexp_iva"] = ContabilizzazioniDisponibili.Rows[0]["idexp"];
                        }

                        DetailToLink["idupb"] = ContabilizzazioniDisponibili.Rows[0]["idupb"];
                        AutoSelectedMov = ContabilizzazioniDisponibili.Rows[0];
                        if (DS.expensemandate.Rows.Count == 0) {
                            MetaData MetaExpMan = MetaData.GetMetaData(this, "expensemandate");
                            MetaExpMan.SetDefaults(DS.expensemandate);
                            DS.expensemandate.Columns["idexp"].DefaultValue =
                                ContabilizzazioniDisponibili.Rows[0]["idexp"];
                            DS.expensemandate.Columns["movkind"].DefaultValue = currcausale;
                            DataRow ExpMandate = MetaExpMan.Get_New_Row(DS.mandate.Rows[0], DS.expensemandate);
                        }

                        //somethingdone=true;
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
                // essere un solo FORNITORE e un solo UPB per tutti i dettagli
                if (registry.Length > 1) {
                    labelNewLinkedCont.Text =
                        "Per creare la contabilizzazione su movimento esistente i dettagli selezionati devono avere lo stesso Fornitore";
                    radioNewLinkedMov.Visible = false;
                    AbilitaDisabilitaSelezioneMovimento(false);
                }

                if (upb.Length > 1) {
                    labelNewLinkedCont.Text =
                        "Per creare la contabilizzazione su movimento esistente i dettagli selezionati devono avere lo stesso UPB";
                    radioNewLinkedMov.Visible = false;
                    AbilitaDisabilitaSelezioneMovimento(false);
                }

                if (faseordine == 1) {
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
                    if (idupb != "") {
                        filtercont = GetData.MergeFilters(filtercont, filterupb_forexpense);
                    }

                    int phase = faseordine - 1;
                    int fasecred = CfgFn.GetNoNullInt32(Meta.GetSys("expenseregphase"));
                    if (fasecred <= phase) {
                        filtercont = GetData.MergeFilters(filtercont, filteridreg);
                    }

                    filtercont = GetData.MergeFilters(filtercont, QHS.CmpEq("nphase", phase));
                    DataTable MovimentiDisponibili = Conn.RUN_SELECT("expenseview",
                        "idexp,idupb,ymov,nmov,description,manager,amount,adate,codefin,finance,codeupb,upb,curramount,available",
                        null, filtercont, null, null, true);
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

        object idexp_selected;

        void FillMovimento(DataRow Expense) {
            idexp_selected = Expense["idexp"];
            txtNumeroMovimento.Text = Expense["nmov"].ToString();
            txtEsercizioMovimento.Text = Expense["ymov"].ToString();
            txtDescrizione.Text = Expense["description"].ToString();
            txtResponsabile.Text = Expense["manager"].ToString();
            SubEntity_txtImportoMovimento.Text = CfgFn.GetNoNullDecimal(Expense["amount"]).ToString("c");
            txtDataCont.Text = ((DateTime) Expense["adate"]).ToShortDateString();
            txtCodiceBilancio.Text = Expense["codefin"].ToString();
            txtDenominazioneBilancio.Text = Expense["finance"].ToString();
            txtUPB.Text = Expense["codeupb"].ToString();
            txtDescrUPB.Text = Expense["upb"].ToString();
            txtImportoCorrente.Text = CfgFn.GetNoNullDecimal(Expense["curramount"]).ToString("c");
            txtImportoDisponibile.Text = CfgFn.GetNoNullDecimal(Expense["available"]).ToString("c");
        }

        void ClearMovimento() {
            idexp_selected = DBNull.Value;
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
            //se true, deve visualizzare le contabilizzazioni disponibili
            bool allMandate = chkAddContab.Checked;
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
            //int faseordine = CfgFn.GetNoNullInt32(Meta.GetSys("mandatephase"));
            if (radioAddCont.Checked)
                phase = faseordine;
            else
                phase = faseordine - 1;

            filter = GetData.MergeFilters(filter, QHS.CmpEq("nphase", phase));
            MetaData ExpenseToConsider;
            ExpenseToConsider = MetaData.GetMetaData(this, "expense");
            ExpenseToConsider.FilterLocked = true;
            ExpenseToConsider.DS = new DataSet();
            DataRow M = ExpenseToConsider.SelectOne("default", filter, null, null);
            if (M == null) return;
            FillMovimento(M);
            idexp_selected = M["idexp"];
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
            //labelMessage.Visible= radioAddCont.Checked;
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
            // int faseprecedente = faseordine -1;
            string filterfase = QHS.CmpEq("nphase", faseordine);
            string descfaseordine = "";
            descfaseordine = Conn.DO_READ_VALUE("expensephase", filterfase, "description").ToString();
            if (descfaseordine != "" && descfaseordine != null) {
                gboxMovimento.Text = descfaseordine;
            }

        }

        void SetNewMov() {
            ClearMovimento();
            AbilitaDisabilitaSelezioneMovimento(false);
            SelezioneMovimentiEffettuata = true; //!!
            int primafasespesa = 1;
            string filterfase = QHS.CmpEq("nphase", primafasespesa);
            string descfase = "";
            descfase = Conn.DO_READ_VALUE("expensephase", filterfase, "description").ToString();
            if (descfase != "") {
                gboxMovimento.Text = descfase;
            }

        }

        void SetNewLinkedMov() {
            DataRow Mand = DS.mandate.Rows[0];
            DataRow[] Selected = GetGridSelectedRows(gridDetails);
            string filterregistry = "";

            object[] registry = ValoriDiversi(Selected, "idreg");
            DataTable MandateKind = Conn.RUN_SELECT("mandatekind", "*", null,
                QHS.CmpEq("idmankind", Mand["idmankind"]), null, null, true);
            // In base alla configurazione del tipo ordine, prendo il fornitore dell'ordine
            // oppure i fornitori dei vari dettagli
            if (MandateKind.Rows.Count > 0) {
                string multiReg = MandateKind.Rows[0]["multireg"].ToString();
                if (multiReg == "N") { // Anagrafe nell'ordine
                    filterregistry = QHS.CmpEq("idreg", Mand["idreg"]);
                }
                else {
                    if ((Selected != null) || (GetGridSelectedRows(gridDetails).Length != 0)) {
                        filterregistry = QHS.CmpEq("idreg", registry[0]); //primo dettaglio
                    }
                }
            }

            int fasecred = CfgFn.GetNoNullInt32(Meta.GetSys("expenseregphase"));
            int fasebilancio = CfgFn.GetNoNullInt32(Meta.GetSys("expensefinphase"));

            int currcausale = CfgFn.GetNoNullInt32(cmbCausale.SelectedValue);
            if (currcausale == 1) {
                decimal importototale = CfgFn.GetNoNullDecimal(HelpForm.GetObjectFromString(typeof(Decimal),
                    txtTotGenerale.Text, "x.y.c"));
                //if (importototale!=TotaleDaContabilizzare) TotaleDaContabilizzare = importototale;
            }

            if (currcausale == 3) {
                decimal importoimponibile = CfgFn.GetNoNullDecimal(HelpForm.GetObjectFromString(typeof(Decimal),
                    txtTotImponibile.Text, "x.y.c"));
                //if (importoimponibile!=TotaleDaContabilizzare) TotaleDaContabilizzare = importoimponibile;
            }

            if (currcausale == 2) {
                decimal importoiva = CfgFn.GetNoNullDecimal(HelpForm.GetObjectFromString(typeof(Decimal),
                    txtTotIva.Text, "x.y.c"));
                //if (importoiva!=TotaleDaContabilizzare) TotaleDaContabilizzare = importoiva;
            }

            decimal ImportoDaPagare = CfgFn.GetNoNullDecimal(
                HelpForm.GetObjectFromString(typeof(decimal),
                    txtDaPagare.Text, "x.y.c"));
            if ((ImportoDaPagare != 0) && (ImportoDaPagare < TotaleDaContabilizzare)) {
                filterMovimento = QHS.CmpGe("available", ImportoDaPagare);
            }
            else {
                filterMovimento = QHS.CmpGe("available", TotaleDaContabilizzare);
            }

            filterMovimento = GetData.MergeFilters(filterMovimento, QHS.CmpEq("nphase", faseordine - 1));
            if (fasecred <= faseordine - 1) {
                filterMovimento = GetData.MergeFilters(filterregistry, filterMovimento);
            }

            if (fasebilancio <= faseordine - 1) {
                if ((Selected != null) || (GetGridSelectedRows(gridDetails).Length != 0)) {
                    DataRow ManDett = Selected[0];
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

                    if (ManDett[field] != DBNull.Value) {
                        filterMovimento = QHS.AppAnd(filterMovimento, QHS.CmpEq("idupb", ManDett[field]));
                    }

                }
            }

            ClearMovimento();
            AbilitaDisabilitaSelezioneMovimento(true);
            SelezioneMovimentiEffettuata = false;
            labMsgTODO1.Text = "Sarà creato un nuovo movimento di spesa";


            if (faseordine > 1) {
                int faseprecedente = faseordine - 1;
                string filterfase = QHS.CmpEq("nphase", faseprecedente);
                string descfaseprecedente = "";
                descfaseprecedente = Conn.DO_READ_VALUE("expensephase", filterfase, "description").ToString();
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
        object idUPBSelected;
        object idfinSelected;

        bool CheckInfoFin() {
            idUPBSelected = null;
            if (radioAddCont.Checked) {
                gboxBilToCreate.Visible = false;
                return true; //movimento esistente!
            }

            if (radioNewLinkedMov.Checked) {
                //Prende il creditore ed il responsabile dall'ordine, quindi non ha bisogno di nulla!!
                int fasebilancio = CfgFn.GetNoNullInt32(Meta.GetSys("expensefinphase"));
//				int faseordine= CfgFn.GetNoNullInt32( Meta.GetSys("mandatephase"));
                if (faseordine - 1 >= fasebilancio) {
                    gboxBilToCreate.Visible = false;
                    return true;
                }

                //Se passa di qui deve creare un nuovo mov. di spesa, agganciandolo ad una fase s
                // in cui non è prevista l'informazione del bilancio
            }

            // Amount può essere il totale da contabilizzare oppure l'importo digitato dall'utente
            decimal amount = 0;
            decimal ImportoDaPagare = CfgFn.GetNoNullDecimal(
                HelpForm.GetObjectFromString(typeof(decimal),
                    txtDaPagare.Text, "x.y.c"));
            if ((ImportoDaPagare != 0) && (ImportoDaPagare < TotaleDaContabilizzare)) {
                amount = ImportoDaPagare;
            }
            else {
                amount = TotaleDaContabilizzare;
            }

            DataRow CurrMandate = DS.mandate.Rows[0];

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

            string filter = QHC.IsNull(field);
            if ((FiltraRows(Selected, filter).Count > 0) && (upb.Length == 2)) {
                object idupbtoassign = "";
                var Details = FiltraRows(Selected, QHC.IsNotNull(field));
                if (Details.Count > 0) idupbtoassign = Details[0][field];
                upb = new object[] {idupbtoassign};
                ;
            }

            object idman_start = CurrMandate["idman"];
            bool manager_in_details = false;
            if (upb.Length == 1) {
                if (upb[0].ToString() != "") idupb = upb[0];
            }
            else {
                foreach (string myidupb in upb) {
                    string filtermyupb = QHS.CmpEq("idupb", myidupb);
                    //object idman_mydetail= DS.upb.Select(filtermyupb)[0]["idman"];
                    object idman_mydetail = Conn.DO_READ_VALUE("upb", filtermyupb, "idman");
                    if (idman_mydetail != DBNull.Value) manager_in_details = true;
                }

                if (manager_in_details) idman_start = DBNull.Value; //idman_start=null significa idman BLOCCATO 
            }

            string filterupb = null;
            if (idupb.ToString() == "") idupb = DBNull.Value;
            if (idupb != DBNull.Value) {
                filterupb = QHS.CmpEq("idupb", idupb);
                //object idman_detail = DS.upb.Select(filterupb)[0]["idman"];
                object idman_detail = Conn.DO_READ_VALUE("upb", filterupb, "idman");
                if (idman_detail != DBNull.Value) idman_start = idman_detail;
            }

            bool upbToSelect = true;
            if (FiltraRows(Selected, QHC.IsNull(field)).Count == 0 || idupb != DBNull.Value) {
                // Se contabilizzo separatamente l'IVA oppure l'imponibile si deve dare la possibilità  
                // di selezionare   UPB diversi
                upbToSelect = false;
            }


            FrmAskInfo F = new FrmAskInfo(Meta, "S", upbToSelect)
                .SetManager(idman_start)
                .SetUPB(idupb)
                .EnableFilterAvailable(amount)
                .EnableUPBSelection(upbToSelect);
            if (manager_in_details)
                F.EnableManagerSelection(false);
            else
                F.AllowNoManagerSelection(true);

            if (F.ShowDialog(this) != DialogResult.OK) return false;
            if (idman_start == null)
                idmanagerSelected = null;
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
//			int faseordine = CfgFn.GetNoNullInt32(Meta.GetSys("mandatephase"));
            // seleziona una delle tre opzioni in base alla fase di contabilizzazione
            if (tabController.SelectedIndex == 2 && (!chkAddContab.Checked) && SelezioneMovimentiEffettuata) {
                if (faseordine == 1 && radioNewCont.Visible) {
                    radioNewCont.Checked = true;
                }
                else {
                    if (faseordine > 1 && radioNewLinkedMov.Visible) {
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
                //DS.mandatedetail.RejectChanges();
                DS.expense.Clear();
                DS.expenseyear.Clear();
                DS.expensemandate.Clear();
                return doSaveNewExpense(null);
            }

            if (radioNewLinkedMov.Checked) {
                //DS.mandatedetail.RejectChanges();
                DS.expense.Clear();
                DS.expenseyear.Clear();
                DS.expensemandate.Clear();
                return doSaveNewExpense(idexp_selected);
            }

            if (radioAddCont.Checked) {
                DS.expensemandate.Clear();
                DS.expenseyear.Clear();
                DS.expense.Clear();
                return doAddConta();
            }

            return false;
        }

        bool doAssociaSoloDettagli() {
            if (idexp_selected == null || idexp_selected == DBNull.Value) {
                MessageBox.Show(this, "Selezionare prima il movimento di spesa", "Avviso");
                return false;
            }

            int idexp_selected_int;

            bool isnum = isNumeric(idexp_selected.ToString(), out idexp_selected_int);

            if ((isnum == false) || (idexp_selected_int == 0)) {
                MessageBox.Show(this, "Selezionare prima il movimento di spesa", "Avviso");
                return false;
            }

            int esercizio = Convert.ToInt32(Meta.GetSys("esercizio"));
            Conn.RUN_SELECT_INTO_TABLE(DS.expense, null,
                QHS.CmpEq("idexp", idexp_selected_int), null, false);
            Conn.RUN_SELECT_INTO_TABLE(DS.expenseyear, null,
                QHS.AppAnd(QHS.CmpEq("idexp", idexp_selected_int),
                    QHS.CmpEq("ayear", esercizio)), null, false);
            Conn.RUN_SELECT_INTO_TABLE(DS.expensesorted, null,
                QHS.AppAnd(QHS.CmpEq("idexp", idexp_selected_int),
                    QHS.CmpEq("ayear", esercizio)), null, false);

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
            DataRow[] Details = DS.mandatedetail.Select(filterDetails);
            foreach (DataRow R in Details) {
                switch (currcausale) {
                    case 1:
                        R["idexp_taxable"] = idexp_selected_int;
                        R["idexp_iva"] = idexp_selected_int;
                        break;
                    case 3:
                        R["idexp_taxable"] = idexp_selected_int;
                        break;
                    case 2:
                        R["idexp_iva"] = idexp_selected_int;
                        break;
                }
            }

            AggiornaUPBDettagli(Details);

            if (DS.expenseyear.Rows[0]["idupb"] != DBNull.Value) idUPBSelected = DS.expenseyear.Rows[0]["idupb"];

            return doSave();
        }

        bool doSave() {
            DataSet DSP = DS.Copy();
            int fasespesamax = CfgFn.GetNoNullInt32(Meta.GetSys("maxexpensephase"));
            GestioneAutomatismi ga = new GestioneAutomatismi(this, Meta.Conn, Meta.Dispatcher,
                DSP, fasespesamax, fasespesamax, "expense", true);
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

//			PostData Post = Meta.Get_PostData();
//			Post.InitClass(DS,Conn);
            if (!res) {
                return false;
            }

            DS.AcceptChanges();
            DS.expensemandate.Clear();
            DS.mandatedetail.Clear();
            DS.expense.Clear();
            DS.expenseyear.Clear();
            DS.expenselast.Clear();
            DS.registry.Clear();
            DetailsToUpdate.Clear();
            return true;
        }

        void ViewAutomatismi(DataSet DS) {
            string spesa = null;
            if (DS.Tables["expense"] != null) {
                DataTable Var = DS.Tables["expense"];
                if (DS.Tables["expense"].Select().Length == 0) return;
                spesa = QHS.FieldIn("idexp", Var.Select(), "idexp");
            }


            Form F = ShowAutomatismi.Show(Meta, spesa, null, null, null);
            F?.ShowDialog(this);
        }

        bool doAddConta() {
            //Crea la riga in expensemandate
            //Non solo deve associare i dettagli, ma deve anche creare la righe in expensemandate
            MetaData ExpMand = MetaData.GetMetaData(this, "expensemandate");
            DataRow Mand = DS.mandate.Rows[0];
            MetaData.SetDefault(DS.expensemandate, "idexp", idexp_selected);
            ExpMand.SetDefaults(DS.expensemandate);
            DataRow M = ExpMand.Get_New_Row(Mand, DS.expensemandate);
            M["movkind"] = cmbCausale.SelectedValue;
            return doAssociaSoloDettagli();
        }

        /// <summary>
        /// Riempie i dati di una riga di entata o spesa prendendoli dall'automatismo e dall'
        ///  IDmovimento in ingresso
        /// </summary>
        /// <param name="E_S"></param>
        /// <param name="Auto"></param>
        /// <param name="CurrSpesa"></param>
        void FillMovimento(DataRow E_S, decimal amount, object idman, int idreg,
            string description) {
            int esercizio = Convert.ToInt32(Meta.GetSys("esercizio"));
            DateTime DataCont = Convert.ToDateTime(Meta.GetSys("datacontabile"));
            E_S.BeginEdit();
            E_S["ymov"] = esercizio;
            E_S["adate"] = DataCont;
            E_S["idman"] = idman;
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

        bool doSaveNewExpense(object idparent) {
            //			int faseordine= CfgFn.GetNoNullInt32( Meta.GetSys("mandatephase"));
            int fasecred = CfgFn.GetNoNullInt32(Meta.GetSys("expenseregphase"));
            int fasebilancio = CfgFn.GetNoNullInt32(Meta.GetSys("expensefinphase"));
            int fasespesamax = CfgFn.GetNoNullInt32(Meta.GetSys("maxexpensephase"));
            int faseinizio;
            int fasefine;
            if (idparent == null || idparent == DBNull.Value) {
                faseinizio = 1;
                fasefine = faseordine;
                idparent = DBNull.Value;
            }
            else {
                faseinizio = faseordine;
                fasefine = faseordine;
            }

            MetaData Exp = MetaData.GetMetaData(this, "expense");
            MetaData ExpY = MetaData.GetMetaData(this, "expenseyear");
            MetaData ExpL = MetaData.GetMetaData(this, "expenselast");
            MetaData ExpMandate = MetaData.GetMetaData(this, "expensemandate");
            MetaData MandateDetail = MetaData.GetMetaData(this, "mandatedetail");
            Exp.SetDefaults(DS.expense);
            ExpY.SetDefaults(DS.expenseyear);
            ExpL.SetDefaults(DS.expenselast);
            ExpMandate.SetDefaults(DS.expensemandate);
            MandateDetail.SetDefaults(DS.mandatedetail);


            if (idparent != DBNull.Value) MetaData.SetDefault(DS.expense, "parentidexp", idparent);
            else MetaData.SetDefault(DS.expense, "parentidexp", DBNull.Value);

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
            DataTable Mov = DS.expense;
            DataTable ImpMov = DS.expenseyear;
            DataTable LastMov = DS.expenselast;

            if (DS.mandate.Rows.Count == 0) {
                return false;
            }

            DataRow Mandate = DS.mandate.Rows[0];

            DataTable MandateKind = Conn.RUN_SELECT("mandatekind", "*", null,
                QHS.CmpEq("idmankind", Mandate["idmankind"]), null, null, true);
            // in base alla configurazione del tipo ordine, prendo il fornitore dell'ordine
            // oppure i fornitori dei vari dettagli
            if (MandateKind.Rows.Count > 0) {
                string multiReg = MandateKind.Rows[0]["multireg"].ToString();
                if (multiReg == "N") { // Anagrafe nell'ordine
                    registry[0] = Mandate["idreg"];
                }
            }

            int esercizio = CfgFn.GetNoNullInt32(Meta.GetSys("esercizio"));

            MetaData.SetDefault(DS.expenseyear, "ayear", esercizio);
            bool ExistMan_parent = false;
            if (idparent != DBNull.Value) {
                MetaData.SetDefault(DS.expense, "parentidexp", idparent);
                DataTable ExpenseYear = Conn.RUN_SELECT("expenseyear", "*", null,
                    QHS.AppAnd(QHS.CmpEq("idexp", idparent), QHS.CmpEq("ayear", esercizio)),
                    null, null, false);
                if (ExpenseYear.Rows.Count == 0) {
                    return false;
                }

                DataRow ParExpY = ExpenseYear.Rows[0];
                if (ParExpY["idfin"] != DBNull.Value) idfinSelected = ParExpY["idfin"];
                if (ParExpY["idupb"] != DBNull.Value) idUPBSelected = ParExpY["idupb"];

                DataRow CurrMandate = DS.mandate.Rows[0];
                object idman_start = CurrMandate["idman"];
                object idman_parent = Conn.DO_READ_VALUE("expense", QHS.CmpEq("idexp", idparent), "idman");

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

            foreach (object idupb in upb) {
                if (!ExistMan_parent) {
                    idmanagerSelected = DBNull.Value;
                }


                string filterupbnew = "";
                string filtermandetoriginal = "";
                object idupbManager;
                if (idupb == DBNull.Value) {
                    filtermandetoriginal = QHS.IsNull(field_upb);
                    idupbManager = idUPBSelected;
                }
                else {
                    if (field_upb == "idupb_iva") {
                        filtermandetoriginal = QHS.CmpEq("isnull(idupb_iva,idupb)", idupb);
                    }
                    else {
                        filtermandetoriginal = QHS.CmpEq(field_upb, idupb);
                    }

                    idupbManager = idupb;
                }

                object idmanagerupb;

                //DataRow UPB = DS.upb.Select(filterupb)[0];
                //idmanagerupb= UPB["idman"].ToString();
                idmanagerupb = Conn.DO_READ_VALUE("upb", QHS.CmpEq("idupb", idupbManager), "idman");


                if ((idmanagerSelected == null) || (idmanagerSelected == DBNull.Value))
                    idmanagerSelected = idmanagerupb;
                if (idmanagerSelected == null) idmanagerSelected = DBNull.Value;

                bool avvisoDelegatoMostrato = false;
                foreach (object idreg in registry) {

                    if (idreg == DBNull.Value) continue;
                    int codicereg = CfgFn.GetNoNullInt32(idreg);
                    string filterregistry = QHC.CmpEq("idreg", idreg);

                    DS.registry.Clear();
                    Conn.RUN_SELECT_INTO_TABLE(DS.registry, null, filterregistry, null, true);
                    if (DS.registry.Rows.Count == 0) continue;
                    string title = DS.registry.Rows[0]["title"].ToString();

                    string filterdetail = "";
                    string filter = GetData.MergeFilters(filtermandetoriginal, filterregistry);

                    if (MandateKind.Rows.Count > 0) {
                        string multiReg = MandateKind.Rows[0]["multireg"].ToString();
                        if (multiReg == "N") { // Anagrafe nell'ordine
                            filterdetail = filtermandetoriginal;
                        }
                        else {
                            filterdetail = filter;
                        }
                    }

                    decimal amount = CalcTotCausale(FiltraRows(SelectedRows, filterdetail).ToArray(), currcausale,
                        genMultipla);
                    if (amount == 0) continue;
                    DataRow ParentR = null;
                    DataRow ExpenseToLink = null;

                    for (int faseCorrente = faseinizio; faseCorrente <= fasefine; faseCorrente++) {
                        Mov.Columns["nphase"].DefaultValue = faseCorrente;

                        DataRow NewSpesaRow = Exp.Get_New_Row(ParentR, Mov);
                        if (faseCorrente == faseordine) ExpenseToLink = NewSpesaRow;
                        ParentR = NewSpesaRow;

                        FillMovimento(NewSpesaRow, amount, idmanagerSelected, codicereg,
                            Mandate["description"].ToString());

                        NewSpesaRow["doc"] = "Ord." +
                                             Mandate["idmankind"].ToString() + "/" +
                                             Mandate["yman"].ToString().Substring(2, 2) + "/" +
                                             Mandate["nman"].ToString().PadLeft(6, '0');
                        //"Ord."+ValoriOrdine["documento"];
                        NewSpesaRow["docdate"] = Mandate["adate"];

                        NewSpesaRow["nphase"] = faseCorrente;

                        if (faseCorrente < fasecred) {
                            NewSpesaRow["idreg"] = DBNull.Value;
                        }
                        else {
                            NewSpesaRow["idreg"] = codicereg;
                        }


                        if (faseCorrente == fasespesamax) {
                            DataRow ModPagam = CfgFn.ModalitaPagamentoDefault(Meta.Conn, NewSpesaRow["idreg"]);
                            if (ModPagam == null) {
                                MessageBox.Show(
                                    "E' necessario che sia definita almeno una modalità di pagamento per il creditore/debitore " +
                                    "\"" + title + "\"\n\n" +
                                    "Dati non salvati", "Errore", MessageBoxButtons.OK);
                                return false;
                            }

                            DataRow NewLastMov = ExpL.Get_New_Row(NewSpesaRow, LastMov);
                            //aggiungere le informazioni della modalità di pagamento
                            NewLastMov["idregistrypaymethod"] = ModPagam["idregistrypaymethod"];
                            NewLastMov["idpaymethod"] = ModPagam["idpaymethod"];
                            NewLastMov["cin"] = ModPagam["cin"];
                            NewLastMov["idbank"] = ModPagam["idbank"];
                            NewLastMov["idcab"] = ModPagam["idcab"];
                            NewLastMov["cc"] = ModPagam["cc"];
                            NewLastMov["paymentdescr"] = ModPagam["paymentdescr"];
                            NewLastMov["iddeputy"] = ModPagam["iddeputy"];
                            NewLastMov["refexternaldoc"] = ModPagam["refexternaldoc"];
                            NewLastMov["biccode"] = ModPagam["biccode"];
                            NewLastMov["extracode"] = ModPagam["extracode"];
                            NewLastMov["idchargehandling"] = ModPagam["idchargehandling"];
                            object idpaymethod = ModPagam["idpaymethod"];
                            string filterpaymethod = QHS.CmpEq("idpaymethod", idpaymethod);

                            DataTable TPaymethod = Conn.RUN_SELECT("paymethod", "*", null, filterpaymethod, null, true);

                            if ((TPaymethod != null) && (TPaymethod.Rows.Count > 0)) {
                                object paymethod_allowdeputy = TPaymethod.Rows[0]["allowdeputy"];
                                object paymethod_flag = TPaymethod.Rows[0]["flag"];
                                NewLastMov["paymethod_allowdeputy"] = paymethod_allowdeputy;
                                NewLastMov["paymethod_flag"] = paymethod_flag;
                            }

                            if (NewLastMov["iddeputy"] != DBNull.Value && !avvisoDelegatoMostrato) {
                                avvisoDelegatoMostrato = true;
                                string titleDelegato =
                                    Conn.readValue("registry", q.eq("idreg", NewLastMov["iddeputy"]), "title")
                                        ?.ToString() ?? "";
                                MessageBox.Show(
                                    "Attenzione, l'anagrafica considerata è associata ad un delegato come modalità di pagamento. Il pagamento sarà pertanto effettuato al delegato "
                                    + titleDelegato + " sull'iban " + NewLastMov["iban"].ToString(),
                                    "Avviso");
                            }


                        }

                        DataRow NewImpMov = ImpMov.NewRow();


                        if (idupb != DBNull.Value) {
                            FillImputazioneMovimento(NewImpMov, amount, idfinSelected, idupb);
                        }
                        else {
                            FillImputazioneMovimento(NewImpMov, amount, idfinSelected, idUPBSelected);
                        }

                        NewImpMov["idexp"] = NewSpesaRow["idexp"];
                        NewImpMov["ayear"] = esercizio;

                        if (faseCorrente < fasebilancio) {
                            NewImpMov["idfin"] = DBNull.Value;
                            NewImpMov["idupb"] = DBNull.Value;
                        }

                        ImpMov.Rows.Add(NewImpMov);
                    }

                    //Aggiunge la riga in expensemandate
                    DataRow ExpManRow = ExpMandate.Get_New_Row(ExpenseToLink, DS.expensemandate);
                    ExpManRow["movkind"] = currcausale;
                    ExpManRow["idmankind"] = Mandate["idmankind"];
                    ExpManRow["yman"] = Mandate["yman"];
                    ExpManRow["nman"] = Mandate["nman"];

                    //Effettua i collegamenti con i dettagli

                    //DataRow []Details = FiltraRows(SelectedRows,filterdetail);
                    string listRownum = "(";
                    foreach (int rownum in DetailsToUpdate) {
                        listRownum += rownum.ToString() + ",";
                    }

                    listRownum = listRownum.Substring(0, listRownum.Length - 1) + ")";
                    string filterToUpdate = null;
                    if (listRownum != "") filterToUpdate = "(rownum in " + listRownum + ")";
                    DataRow[] RowsToUpdate = DS.mandatedetail.Select(filterToUpdate);
                    var Details = FiltraRows(RowsToUpdate, filterdetail);

                    foreach (DataRow RD in Details) {
                        switch (currcausale) {
                            case 1:
                                RD["idexp_taxable"] = ExpenseToLink["idexp"];
                                RD["idexp_iva"] = ExpenseToLink["idexp"];
                                break;
                            case 3:
                                RD["idexp_taxable"] = ExpenseToLink["idexp"];
                                break;
                            case 2:
                                RD["idexp_iva"] = ExpenseToLink["idexp"];
                                break;
                        }
                    }

                    // Associa l'UPB ai dettagli sui quali non era stato impostato
                    if (currcausale == 1) // solo in caso di contabilizzazione totale
                    {
                        var DetailsUPBNull = FiltraRows(Details.ToArray(), "(idupb is null)");
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

        private void cmbTipoOrdine_SelectedIndexChanged(object sender, System.EventArgs e) {
            if (Meta == null) return;
            if (!Meta.DrawStateIsDone) return;
            ClearOrdine();
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
                var Details = FiltraRows(SelectedRows, QHC.IsNotNull(field));
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
            decimal valore = CfgFn.GetNoNullDecimal(HelpForm.GetObjectFromString(typeof(Decimal),
                T.Text, "x.y.c"));
            if (valore < 0) {
                MessageBox.Show("Valore non valido");
                T.Focus();
                return;
            }

            decimal importoimponibile = CfgFn.GetNoNullDecimal(HelpForm.GetObjectFromString(typeof(Decimal),
                txtTotImponibile.Text, "x.y.c"));
            decimal importoiva = CfgFn.GetNoNullDecimal(HelpForm.GetObjectFromString(typeof(Decimal),
                txtTotIva.Text, "x.y.c"));
            T.Text = valore.ToString("c");
            //txtTotGenerale.Text = (importoimponibile + importoiva).ToString("c");
        }



        void RecalcOperationsToDo() {


            int causale = CfgFn.GetNoNullInt32(cmbCausale.SelectedValue);

            DataRow[] Selected = GetGridSelectedRows(gridDetails);

            decimal ImportoMax = CfgFn.GetNoNullDecimal(
                HelpForm.GetObjectFromString(typeof(decimal),
                    txtTotSelezionato.Text, "x.y.c"));

            decimal ImportoDaPagare = CfgFn.GetNoNullDecimal(
                HelpForm.GetObjectFromString(typeof(decimal),
                    txtDaPagare.Text, "x.y.c"));
            if (ImportoDaPagare == 0) {
                ImportoDaPagare = ImportoMax;
            }

            txtDaPagare.Text = ImportoDaPagare.ToString("c");
            decimal PercentualeDigitata = CfgFn.GetNoNullDecimal(
                HelpForm.GetObjectFromString(typeof(decimal),
                    txtPerc.Text, "x.y.c"));

            if (ImportoDaPagare > ImportoMax) {
                MessageBox.Show("L'importo da pagare è superiore al totale dei dettagli selezionati");
                txtDaPagare.Text = "";
                ImportoDaPagare = 0;
                return;
            }

            decimal percentuale = 100;
            if (ImportoMax != 0) percentuale = ImportoDaPagare / ImportoMax * 100;
            decimal rounded = Math.Round(percentuale, 4);
            // calcola la percentuale in base all'importo
            txtPerc.Text = HelpForm.StringValue(rounded, "x.y.fixed.4...1");
            string operazioni = "";
            operazioni = QueryCreator.GetPrintable(operazioni);

        }

        decimal CalcolaCoefficiente(decimal importoDaPagare, decimal importoMax, DataRow rowToSplit) {
            decimal epsilon = 0;
            if ((importoDaPagare != 0) && (importoMax != 0)) epsilon = importoDaPagare / importoMax;
            if (epsilon >= 1) return epsilon;

            int maxIter = 100;
            int niter = 1;
            decimal epsilon_min = epsilon - 0.01M;
            decimal epsilon_max = epsilon + 0.01M;
            decimal epsilon_med = (epsilon_min + epsilon_max) / 2;
            decimal importoRicalcolato = RicalcolaTotaleDaContabilizzare(epsilon_med, rowToSplit);
            while (niter < maxIter && importoRicalcolato != importoDaPagare) {
                if (importoDaPagare - importoRicalcolato > 0) {
                    epsilon_min = epsilon_med;
                }
                else {
                    epsilon_max = epsilon_med;
                }

                epsilon_med = (epsilon_min + epsilon_max) / 2;
                importoRicalcolato = RicalcolaTotaleDaContabilizzare(epsilon_med, rowToSplit);
                if (importoRicalcolato != importoDaPagare) {
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
            decimal TotaleImponibile = CfgFn.RoundValuta(taxable * number * (1 - discount) * exchangerate);
            decimal imponibilecomplementare = taxable - imponibiletest;
            decimal totale1 = CfgFn.RoundValuta(imponibiletest * number * (1 - discount) * exchangerate);
            decimal totale2 = CfgFn.RoundValuta(imponibilecomplementare * number * (1 - discount) * exchangerate);
            if (totale1 + totale2 == TotaleImponibile) return imponibiletest;
            decimal x = number * (1 - discount) * exchangerate;
            decimal passo = 0;
            if (x <= 10) passo = 0.001M;
            if ((x > 10) && (x <= 100)) passo = 0.0001M;
            if ((x > 100) && (x <= 1000)) passo = 0.00001M;
            if (x > 1000) passo = 0.00001M;
            decimal cent = passo;
            while (cent < 0.2M) {
                decimal imponibile_try = imponibiletest + cent;
                decimal imponibilecomplementare_try = taxable - imponibile_try;
                totale1 = CfgFn.RoundValuta(imponibile_try * number * (1 - discount) * exchangerate);
                totale2 = CfgFn.RoundValuta(imponibilecomplementare_try * number * (1 - discount) * exchangerate);
                if (totale1 + totale2 == TotaleImponibile) {
                    return imponibile_try;
                }

                imponibile_try = imponibiletest - cent;
                imponibilecomplementare_try = taxable - imponibile_try;
                totale1 = CfgFn.RoundValuta(imponibile_try * number * (1 - discount) * exchangerate);
                totale2 = CfgFn.RoundValuta(imponibilecomplementare_try * number * (1 - discount) * exchangerate);
                if (totale1 + totale2 == TotaleImponibile) {
                    return imponibile_try;
                }

                cent += passo;
            }

            return imponibiletest;
        }

        DataTable AggiungiOSottraiCentADettagli(decimal proporzione, decimal importoDaPagare, decimal cents) {
            DataRow[] Selected = GetGridSelectedRows(gridDetails);
            DataTable Info = new DataTable();

            Info.Columns.Add("rownum", typeof(int));
            Info.Columns.Add("difference", typeof(decimal));
            Info.Columns.Add("cents", typeof(decimal)); // Centesimi da sommare/sottrarre all'iva totale
            bool success = false;
            foreach (DataRow Row1 in Selected) {
                decimal imponibile1 = CfgFn.GetNoNullDecimal(Row1["taxable"]);
                decimal QuantitaConfezioni1 = CfgFn.GetNoNullDecimal(Row1["npackage"]);
                //string  filter1 = "(idivakind=" + QueryCreator.quotedstrvalue(Row1["idivakind"], true) + ")";
                decimal aliquota1 = CfgFn.GetNoNullDecimal(Row1["taxrate"]);
                decimal sconto1 = CfgFn.GetNoNullDecimal(Row1["discount"]);
                DataRow Mandate1 = DS.mandate.Rows[0]; //Row1.GetParentRow("invoiceinvoicedetail");
                decimal tassocambio1 = CfgFn.GetNoNullDecimal(Mandate1["exchangerate"]);
                decimal taxable = CfgFn.Round(CfgFn.GetNoNullDecimal(Row1["taxable"]), 5);
                decimal taxabletotal =
                    CfgFn.RoundValuta((taxable * QuantitaConfezioni1 * (1 - sconto1) * tassocambio1));
                // Ricalcolo l'imponibile unitario
                decimal taxable1 = CfgFn.Round(CfgFn.GetNoNullDecimal(Row1["taxable"]) * proporzione, 5);
                decimal taxable_recalc =
                    GetImponibileNear(taxable1, imponibile1, QuantitaConfezioni1, sconto1, tassocambio1);
                // Ricalcolo l'iva
                decimal taxtotal = CfgFn.RoundValuta(CfgFn.GetNoNullDecimal(Row1["tax"]));
                decimal tax_recalctotal = CfgFn.RoundValuta(CfgFn.GetNoNullDecimal(Row1["tax"]) * proporzione);
                decimal taxable_recalctotal =
                    CfgFn.RoundValuta((taxable_recalc * QuantitaConfezioni1 * (1 - sconto1) * tassocambio1));
                DataRow rInfo = Info.NewRow();
                decimal difference;
                if ((taxable_recalctotal != 0) && (taxabletotal != 0)) {
                    difference = tax_recalctotal / taxable_recalctotal - taxtotal / taxabletotal;
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
                // Ordino in base a difference in ordine decrescente o crescente
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
                    decimal QuantitaConfezioni = CfgFn.GetNoNullDecimal(Row["npackage"]);
                    // string filter = "(idivakind=" + QueryCreator.quotedstrvalue(Row["idivakind"], true) + ")";
                    decimal aliquota = CfgFn.GetNoNullDecimal(Row["taxrate"]);
                    decimal sconto = CfgFn.GetNoNullDecimal(Row["discount"]);
                    //decimal percindeduc = CfgFn.GetNoNullDecimal(Conn.DO_READ_VALUE("ivakind", filter, "unabatabilitypercentage"));
                    DataRow Mandate = DS.mandate.Rows[0]; //Row.GetParentRow("invoiceinvoicedetail");
                    decimal tassocambio = CfgFn.GetNoNullDecimal(Mandate["exchangerate"]);
                    decimal taxable = CfgFn.Round(CfgFn.GetNoNullDecimal(Row["taxable"]), 5);
                    // Ricalcolo l'imponibile unitario
                    decimal taxable_recalc = CfgFn.Round(CfgFn.GetNoNullDecimal(Row["taxable"]) * proporzione, 5);
                    taxable_recalc = GetImponibileNear(taxable_recalc, imponibile, QuantitaConfezioni, sconto,
                        tassocambio);
                    // Uso l'imponibile unitario per  calcolare l'iva totale e l'iva indetraibile
                    decimal taxabletotal =
                        CfgFn.RoundValuta((taxable * QuantitaConfezioni * (1 - sconto) * tassocambio));
                    decimal taxtotal = CfgFn.RoundValuta(CfgFn.GetNoNullDecimal(Row["tax"]));
                    decimal tax_recalc = CfgFn.RoundValuta(CfgFn.GetNoNullDecimal(Row["tax"]) * proporzione);
                    decimal taxabletot_recalc =
                        CfgFn.RoundValuta((taxable_recalc * QuantitaConfezioni * (1 - sconto) * tassocambio));
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
                            difference = tax_recalc / taxabletot_recalc - taxtotal / taxabletotal;
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
                    //decimal unabatable = CfgFn.RoundValuta(tax * percindeduc);

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

                if (TotaleDaContabilizzare == importoDaPagare) {
                    cent = cents;
                    success = true;
                    break;
                }

                if (TotaleDaContabilizzare < importoDaPagare) aggiungi = true;
                if (TotaleDaContabilizzare > importoDaPagare) aggiungi = false;
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
            DataRow Mandate = DS.mandate.Rows[0]; //Row.GetParentRow("invoiceinvoicedetail");
            decimal tassocambio = CfgFn.GetNoNullDecimal(Mandate["exchangerate"]);
            if (rowToSplit == null) {
                DataRow[] Selected = GetGridSelectedRows(gridDetails);


                foreach (DataRow Row in Selected) {
                    decimal imponibile = CfgFn.GetNoNullDecimal(Row["taxable"]);
                    decimal iva = CfgFn.GetNoNullDecimal(Row["tax"]);
                    decimal QuantitaConfezioni = CfgFn.GetNoNullDecimal(Row["npackage"]);
                    //string  filter = "(idivakind=" + QueryCreator.quotedstrvalue(Row["idivakind"], true) + ")";
                    decimal aliquota = CfgFn.GetNoNullDecimal(Row["taxrate"]);
                    decimal sconto = CfgFn.GetNoNullDecimal(Row["discount"]);
                    //decimal percindeduc = CfgFn.GetNoNullDecimal(Conn.DO_READ_VALUE("ivakind", filter, "unabatabilitypercentage"));
                    // Ricalcolo l'imponibile unitario
                    decimal taxable = CfgFn.Round(CfgFn.GetNoNullDecimal(Row["taxable"]) * proporzione, 5);
                    taxable = GetImponibileNear(taxable, imponibile, QuantitaConfezioni, sconto, tassocambio);
                    // Uso l'imponibile unitario per  calcolare l'iva totale e l'iva indetraibile
                    decimal taxabletot = CfgFn.RoundValuta((taxable * QuantitaConfezioni * (1 - sconto) * tassocambio));
                    decimal tax = CfgFn.RoundValuta(CfgFn.GetNoNullDecimal(Row["tax"]) * proporzione);

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
                decimal QuantitaConfezioni = CfgFn.GetNoNullDecimal(rowToSplit["npackage"]);
                //string  filter = "(idivakind=" + QueryCreator.quotedstrvalue(Row["idivakind"], true) + ")";
                decimal aliquota = CfgFn.GetNoNullDecimal(rowToSplit["taxrate"]);
                decimal sconto = CfgFn.GetNoNullDecimal(rowToSplit["discount"]);
                //decimal percindeduc = CfgFn.GetNoNullDecimal(Conn.DO_READ_VALUE("ivakind", filter, "unabatabilitypercentage"));

                // Ricalcolo l'imponibile unitario
                decimal taxable = CfgFn.Round(CfgFn.GetNoNullDecimal(rowToSplit["taxable"]) * proporzione, 5);
                taxable = GetImponibileNear(taxable, imponibile, QuantitaConfezioni, sconto, tassocambio);
                // Uso l'imponibile unitario per  calcolare l'iva totale e l'iva indetraibile
                decimal taxabletot = CfgFn.RoundValuta((taxable * QuantitaConfezioni * (1 - sconto) * tassocambio));
                decimal tax = CfgFn.RoundValuta(CfgFn.GetNoNullDecimal(rowToSplit["tax"]) * proporzione);
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
                    HelpForm.GetObjectFromString(typeof(decimal),
                        txtTotSelezionato.Text, "x.y.c"));
                // calcola l'importo in base alla percentuale
                decimal perc =
                    CfgFn.GetNoNullDecimal(HelpForm.GetObjectFromString(typeof(Decimal), txtPerc.Text, "x.y.c"));
                decimal importoDaPagare = CfgFn.Round(ImportoMax * perc / 100, 2);
                //RicalcolaTotaleDaContabilizzare(perc/100);
                txtDaPagare.Text = importoDaPagare.ToString("c");
                txtPerc.Text = HelpForm.StringValue(perc, "x.y.fixed.4...1");

                txtDaPagare_Leave(txtDaPagare, null);
            }
        }

        void InsertNewDetail(DataRow Row, decimal taxable, decimal tax, decimal percindeduc) {
            // Creo una nuova riga con gli importi residui (vedere gli arrotondamenti)
            MetaData metaDT = MetaData.GetMetaData(this, "mandatedetail");
            metaDT.SetDefaults(DS.mandatedetail);
            decimal taxableResiduo = CfgFn.GetNoNullDecimal(Row["taxable"]) - taxable;
            decimal taxResiduo = CfgFn.GetNoNullDecimal(Row["tax"]) - tax;
            decimal unabatableResiduo = CfgFn.RoundValuta(taxResiduo * percindeduc);
            // Creazione di un nuovo dettaglio
            DataRow rDT = metaDT.Get_New_Row(DS.mandate.Rows[0], DS.mandatedetail);
            rDT["idgroup"] = Row["idgroup"];
            rDT["idreg"] = Row["idreg"];
            rDT["taxrate"] = Row["taxrate"];
            rDT["taxable"] = taxableResiduo;
            rDT["tax"] = taxResiduo;
            rDT["unabatable"] = unabatableResiduo;
            rDT["idupb"] = Row["idupb"];
            rDT["idupb_iva"] = Row["idupb_iva"];
            rDT["number"] = CfgFn.GetNoNullDecimal(Row["number"]);
            rDT["npackage"] = CfgFn.GetNoNullDecimal(Row["npackage"]);
            rDT["idlist"] = Row["idlist"];
            rDT["idunit"] = Row["idunit"];
            rDT["idpackage"] = Row["idpackage"];
            rDT["unitsforpackage"] = Row["unitsforpackage"];
            rDT["assetkind"] = Row["assetkind"];
            rDT["idinv"] = Row["idinv"];
            rDT["detaildescription"] = Row["detaildescription"].ToString();
            rDT["competencystart"] = Row["competencystart"];
            rDT["competencystop"] = Row["competencystop"];
            rDT["epkind"] = Row["epkind"];
            rDT["annotations"] = Row["annotations"];
            rDT["discount"] = Row["discount"];
            rDT["flagto_unload"] = Row["flagto_unload"];


            rDT["start"] = Row["start"];
            rDT["stop"] = Row["stop"];
            rDT["toinvoice"] = Row["toinvoice"];
            rDT["ninvoiced"] = Row["ninvoiced"];
            rDT["idexp_taxable"] = Row["idexp_taxable"]; // contabilizzaione imponibile già effettuata
            rDT["idexp_iva"] = Row["idexp_iva"]; // contabilizzaione iva già effettuata
            rDT["idivakind"] = Row["idivakind"];
            rDT["flagmixed"] = Row["flagmixed"];
            rDT["flagactivity"] = Row["flagactivity"];
            rDT["idaccmotive"] = Row["idaccmotive"];
            rDT["idsor1"] = Row["idsor1"];
            rDT["idsor2"] = Row["idsor2"];
            rDT["idsor3"] = Row["idsor3"];
            rDT["idcostpartition"] = Row["idcostpartition"];
            rDT["idpccdebitstatus"] = Row["idpccdebitstatus"];
            rDT["idpccdebitmotive"] = Row["idpccdebitmotive"];
            rDT["expensekind"] = Row["expensekind"];
            rDT["va3type"] = Row["va3type"];
            rDT["cupcode"] = Row["cupcode"];
            rDT["cigcode"] = Row["cigcode"];
            rDT["idepexp"] = Row["idepexp"];
            rDT["idsor_siope"] = Row["idsor_siope"];
        }


        void RecalcDettagliSelezionati() {
            DataRow[] Selected = GetGridSelectedRows(gridDetails);
            int causale = CfgFn.GetNoNullInt32(cmbCausale.SelectedValue);
            decimal ImportoMax = CfgFn.GetNoNullDecimal(
                HelpForm.GetObjectFromString(typeof(decimal),
                    txtTotSelezionato.Text, "x.y.c"));
            decimal ImportoDaPagare = CfgFn.GetNoNullDecimal(
                HelpForm.GetObjectFromString(typeof(decimal),
                    txtDaPagare.Text, "x.y.c"));
            if (ImportoDaPagare == 0) {
                ImportoDaPagare = ImportoMax;
            }

            DataRow Mandate = DS.mandate.Rows[0];
            decimal tassocambio = CfgFn.GetNoNullDecimal(Mandate["exchangerate"]);

            ClearOperazionsToDo();
            // Rilegge i dettagli con l'importo originale nel dataset
            foreach (DataRow Det in Selected) {
                string filtermandatedetail = QueryCreator.WHERE_COLNAME_CLAUSE(
                    Det, new string[] {"idmankind", "yman", "nman", "rownum"}, DataRowVersion.Default, true);
                DataAccess.RUN_SELECT_INTO_TABLE(Conn, DS.Tables["mandatedetail"], null, filtermandatedetail, null,
                    false);
            }

            if (ImportoMax == 0) return;


            if (ImportoDaPagare < ImportoMax) {
                if (rdbSplittaTutti.Checked) { // Distribuisce la quota parziale da contabilizzare su tutti i dettagli
                    DataTable T = null;
                    decimal epsilon = CalcolaCoefficiente(ImportoDaPagare, ImportoMax, null);
                    if (RicalcolaTotaleDaContabilizzare(epsilon, null) != ImportoDaPagare) {
                        decimal cents = (RicalcolaTotaleDaContabilizzare(epsilon, null) - ImportoDaPagare);
                        T = AggiungiOSottraiCentADettagli(epsilon, ImportoDaPagare, cents);
                    }

                    foreach (DataRow Row in DS.mandatedetail.Select()) { // Solo le righe selezionate
                        if (!DetailsToUpdate.Contains(Row["rownum"])) {
                            DetailsToUpdate.Add(Row["rownum"]);
                        }

                        decimal imponibile = CfgFn.GetNoNullDecimal(Row["taxable"]);
                        decimal iva = CfgFn.GetNoNullDecimal(Row["tax"]);
                        decimal QuantitaConfezioni = CfgFn.GetNoNullDecimal(Row["npackage"]);
                        decimal aliquota = CfgFn.GetNoNullDecimal(Row["taxrate"]);
                        decimal sconto = CfgFn.GetNoNullDecimal(Row["discount"]);
                        // Ricalcolo l'imponibile unitario
                        decimal taxable = CfgFn.Round(CfgFn.GetNoNullDecimal(Row["taxable"]) * epsilon, 5);
                        taxable = GetImponibileNear(taxable, imponibile, QuantitaConfezioni, sconto, tassocambio);
                        // Uso l'imponibile unitario per  calcolare l'iva totale
                        decimal tax = CfgFn.RoundValuta(CfgFn.GetNoNullDecimal(Row["tax"]) * epsilon);
                        decimal unabatabilitypercentage = CfgFn.GetNoNullDecimal(Meta.Conn.DO_READ_VALUE("ivakind",
                            QHS.CmpEq("idivakind", Row["idivakind"]), "unabatabilitypercentage"));
                        decimal unabatable = CfgFn.RoundValuta(tax * unabatabilitypercentage);
                        string filterdetail = QHS.CmpEq("rownum", Row["rownum"]);
                        if (T != null) {
                            DataRow[] Det = T.Select(filterdetail);
                            if (Det.Length != 0) {
                                decimal cents = CfgFn.GetNoNullDecimal(Det[0]["cents"]);
                                tax += cents;
                            }
                        }

                        InsertNewDetail(Row, taxable, tax, unabatabilitypercentage);
                        //Aggiorno la riga originale con i valori ricalcolati
                        Row["taxable"] = taxable;
                        Row["tax"] = tax;
                        Row["unabatable"] = unabatable;
                    }
                }
                else { //La quota parziale da contabilizzare viene raggiunta sommando i dettagli, e splittando l'ultimo
                    DataTable Info = new DataTable();
                    Info.Columns.Add("rownum", typeof(int));
                    Info.Columns.Add("total", typeof(decimal));
                    // Ciclo per riempire il datatable Info con il totale da contabilizzare su ogni dettaglio
                    foreach (DataRow Row in DS.mandatedetail.Select(null, "rownum"))
                        // Solo le righe selezionate ordinate per importo crescente
                    {
                        // Calcolo il totale sulla causale per quel dettaglio
                        DataRow rInfo = Info.NewRow();
                        rInfo["rownum"] = Row["rownum"];
                        rInfo["total"] = CalcolaTotCausale(Row, causale);
                        Info.Rows.Add(rInfo);

                    }

                    decimal sum = ImportoDaPagare;
                    decimal oldsum = 0;
                    string filterrow = null;
                    // Ciclo per calcolare la somma da contabilizzare
                    foreach (DataRow Row in Info.Select(null, "total asc"))
                        // Solo le righe selezionate ordinate per importo crescente 
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
                            DataRow R = DS.mandatedetail.Select(filterrow, null)[0];
                            decimal imponibile = CfgFn.GetNoNullDecimal(R["taxable"]);
                            decimal iva = CfgFn.GetNoNullDecimal(R["tax"]);
                            decimal QuantitaConfezioni = CfgFn.GetNoNullDecimal(R["npackage"]);
                            decimal aliquota = CfgFn.GetNoNullDecimal(R["taxrate"]);
                            decimal sconto = CfgFn.GetNoNullDecimal(R["discount"]);
                            // Splitto il dettaglio corrente in due, uno risulterà contabilizzato,l'altro no

                            decimal epsilon1 = CalcolaCoefficiente(oldsum, CfgFn.GetNoNullDecimal(Row["total"]), R);
                            // Ricalcolo l'imponibile unitario
                            decimal taxable = CfgFn.Round(CfgFn.GetNoNullDecimal(R["taxable"]) * epsilon1, 5);
                            taxable = GetImponibileNear(taxable, imponibile, QuantitaConfezioni, sconto, tassocambio);
                            // Uso l'imponibile unitario per  calcolare l'iva totale
                            decimal tax = CfgFn.RoundValuta(CfgFn.GetNoNullDecimal(R["tax"]) * epsilon1);
                            decimal unabatabilitypercentage = CfgFn.GetNoNullDecimal(Meta.Conn.DO_READ_VALUE("ivakind",
                                QHS.CmpEq("idivakind", R["idivakind"]), "unabatabilitypercentage"));
                            decimal unabatable = CfgFn.RoundValuta(tax * unabatabilitypercentage);
                            // Creo una nuova riga con gli importi residui (vedere gli arrotondamenti)
                            InsertNewDetail(R, taxable, tax, unabatabilitypercentage);
                            //Aggiorno la riga originale con i valori ricalcolati
                            R["taxable"] = taxable;
                            R["tax"] = tax;
                            R["unabatable"] = unabatable;
                            break;
                        }
                    }

                }

            }
            else {
                foreach (DataRow Row in DS.mandatedetail.Select()) { // Solo le righe selezionate
                    if (!DetailsToUpdate.Contains(Row["rownum"])) {
                        DetailsToUpdate.Add(Row["rownum"]);
                    }
                }
            }
        }


        void ClearOperazionsToDo() {
            DS.expensemandate.Clear();
            DS.expenseyear.Clear();
            DS.expense.Clear();
            DS.expenselast.Clear();
            DS.mandatedetail.Clear();
            DetailsToUpdate.Clear();
        }

        private void txtDaPagare_Leave(object sender, EventArgs e) {
            RecalcOperationsToDo();
        }

    }
}
