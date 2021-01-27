
/*
Easy
Copyright (C) 2021 Università degli Studi di Catania (www.unict.it)
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
using System.Globalization;
using funzioni_configurazione;
using movimentofunctions;
using ep_functions;
using gestioneclassificazioni;
using q = metadatalibrary.MetaExpression;

namespace expense_wizardinvoicedetail {
    /// <summary>
    /// Summary description for FrmWizardInvoiceDetail.
    /// </summary>
    public class FrmWizardInvoiceDetail : System.Windows.Forms.Form {
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnBack;
        private Crownwood.Magic.Controls.TabPage tabPage1;
        private Crownwood.Magic.Controls.TabPage tabPage2;
        private Crownwood.Magic.Controls.TabPage tabPage3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labDescrOrdine;
        private System.Windows.Forms.TextBox txtFornitore;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnSelectAllDetail;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtTotGenerale;
        private System.Windows.Forms.TextBox txtTotIva;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtTotImponibile;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGrid gridDetails;
        private System.Windows.Forms.ComboBox cmbCausale;
        private System.Windows.Forms.Label labelCausale;
        private System.Windows.Forms.Button btnDocumento;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtNumDoc;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtEsercDoc;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtDaPagare;
        string CustomTitle;
        DataAccess Conn;
        MetaData Meta;
        DataSet DSCopy;
        GestioneClassificazioni ManageClassificazioni;
        ArrayList DetailsToUpdate;
        bool SalvataggioEnabled = true;
        private System.Windows.Forms.ComboBox cmbTipoDocumento;
        public expense_wizardinvoicedetail.vistaForm DS;
        private Crownwood.Magic.Controls.TabControl tabController;
        private System.Windows.Forms.TextBox txtDescrDoc;
        decimal TotaleDaContabilizzare = 0;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label labTotPagato;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtTotaleFattura;
        private System.Windows.Forms.TextBox txtIvaFattura;
        private System.Windows.Forms.TextBox txtImponibileFattura;
        private System.Windows.Forms.TextBox txtTotPagatoCausale;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox txtTotalePagatoGenerale;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.TextBox txtPerc;
        private System.Windows.Forms.Label labelAttenzione;
        private GroupBox groupBox3;
        private Label lblCausale;
        private TextBox txtTotSelezionato;
        private Label label3;
        private RadioButton rdbSplittaUno;
        private RadioButton rdbSplittaTutti;
        private Panel panel1;
        private GroupBox groupBox1;
        private GroupBox gboxBolletta;
        private TextBox txtBolletta;
        private Button btnBolletta;
        private CheckBox chk_Enable_Split_Payment;
        private CheckBox SubEntity_chkAutomRecuperi;


        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;

        public FrmWizardInvoiceDetail() {
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
			this.tabPage1 = new Crownwood.Magic.Controls.TabPage();
			this.label20 = new System.Windows.Forms.Label();
			this.label19 = new System.Windows.Forms.Label();
			this.label17 = new System.Windows.Forms.Label();
			this.label16 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.tabPage2 = new Crownwood.Magic.Controls.TabPage();
			this.chk_Enable_Split_Payment = new System.Windows.Forms.CheckBox();
			this.txtTotalePagatoGenerale = new System.Windows.Forms.TextBox();
			this.label21 = new System.Windows.Forms.Label();
			this.txtTotPagatoCausale = new System.Windows.Forms.TextBox();
			this.txtTotaleFattura = new System.Windows.Forms.TextBox();
			this.txtIvaFattura = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.txtImponibileFattura = new System.Windows.Forms.TextBox();
			this.label14 = new System.Windows.Forms.Label();
			this.label15 = new System.Windows.Forms.Label();
			this.labTotPagato = new System.Windows.Forms.Label();
			this.cmbTipoDocumento = new System.Windows.Forms.ComboBox();
			this.DS = new expense_wizardinvoicedetail.vistaForm();
			this.txtDescrDoc = new System.Windows.Forms.TextBox();
			this.labDescrOrdine = new System.Windows.Forms.Label();
			this.txtFornitore = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.btnSelectAllDetail = new System.Windows.Forms.Button();
			this.label18 = new System.Windows.Forms.Label();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.txtTotGenerale = new System.Windows.Forms.TextBox();
			this.txtTotIva = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.txtTotImponibile = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.gridDetails = new System.Windows.Forms.DataGrid();
			this.cmbCausale = new System.Windows.Forms.ComboBox();
			this.labelCausale = new System.Windows.Forms.Label();
			this.btnDocumento = new System.Windows.Forms.Button();
			this.label9 = new System.Windows.Forms.Label();
			this.txtNumDoc = new System.Windows.Forms.TextBox();
			this.label10 = new System.Windows.Forms.Label();
			this.txtEsercDoc = new System.Windows.Forms.TextBox();
			this.tabPage3 = new Crownwood.Magic.Controls.TabPage();
			this.SubEntity_chkAutomRecuperi = new System.Windows.Forms.CheckBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.gboxBolletta = new System.Windows.Forms.GroupBox();
			this.txtBolletta = new System.Windows.Forms.TextBox();
			this.btnBolletta = new System.Windows.Forms.Button();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.lblCausale = new System.Windows.Forms.Label();
			this.txtTotSelezionato = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.rdbSplittaUno = new System.Windows.Forms.RadioButton();
			this.rdbSplittaTutti = new System.Windows.Forms.RadioButton();
			this.label23 = new System.Windows.Forms.Label();
			this.label22 = new System.Windows.Forms.Label();
			this.txtPerc = new System.Windows.Forms.TextBox();
			this.labelAttenzione = new System.Windows.Forms.Label();
			this.label13 = new System.Windows.Forms.Label();
			this.txtMessage = new System.Windows.Forms.TextBox();
			this.txtDaPagare = new System.Windows.Forms.TextBox();
			this.label12 = new System.Windows.Forms.Label();
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnNext = new System.Windows.Forms.Button();
			this.btnBack = new System.Windows.Forms.Button();
			this.panel1 = new System.Windows.Forms.Panel();
			this.tabController.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.tabPage2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
			this.groupBox2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.gridDetails)).BeginInit();
			this.tabPage3.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.gboxBolletta.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// tabController
			// 
			this.tabController.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabController.IDEPixelArea = true;
			this.tabController.Location = new System.Drawing.Point(0, 0);
			this.tabController.Name = "tabController";
			this.tabController.SelectedIndex = 2;
			this.tabController.SelectedTab = this.tabPage3;
			this.tabController.Size = new System.Drawing.Size(704, 430);
			this.tabController.TabIndex = 0;
			this.tabController.TabPages.AddRange(new Crownwood.Magic.Controls.TabPage[] {
            this.tabPage1,
            this.tabPage2,
            this.tabPage3});
			// 
			// tabPage1
			// 
			this.tabPage1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tabPage1.Controls.Add(this.label20);
			this.tabPage1.Controls.Add(this.label19);
			this.tabPage1.Controls.Add(this.label17);
			this.tabPage1.Controls.Add(this.label16);
			this.tabPage1.Controls.Add(this.label2);
			this.tabPage1.Controls.Add(this.label1);
			this.tabPage1.Location = new System.Drawing.Point(0, 0);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Selected = false;
			this.tabPage1.Size = new System.Drawing.Size(704, 405);
			this.tabPage1.TabIndex = 3;
			this.tabPage1.Title = "Pagina 1 di 3";
			// 
			// label20
			// 
			this.label20.Location = new System.Drawing.Point(8, 112);
			this.label20.Name = "label20";
			this.label20.Size = new System.Drawing.Size(648, 23);
			this.label20.TabIndex = 10;
			this.label20.Text = "3) Aver creato la fattura richiamando i dettagli degli ordini relativi";
			// 
			// label19
			// 
			this.label19.Location = new System.Drawing.Point(8, 88);
			this.label19.Name = "label19";
			this.label19.Size = new System.Drawing.Size(656, 16);
			this.label19.TabIndex = 9;
			this.label19.Text = "2) Aver contabilizzato i dettagli dell\'ordine mediante l\'apposita procedura guida" +
    "ta ";
			// 
			// label17
			// 
			this.label17.Location = new System.Drawing.Point(8, 64);
			this.label17.Name = "label17";
			this.label17.Size = new System.Drawing.Size(656, 16);
			this.label17.TabIndex = 8;
			this.label17.Text = "1) Aver creato l\'ordine (o gli ordini) a cui la fattura si riferisce";
			// 
			// label16
			// 
			this.label16.Location = new System.Drawing.Point(8, 40);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(656, 23);
			this.label16.TabIndex = 7;
			this.label16.Text = "E\' necessario, prima di usare questa procedura:";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(8, 144);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(656, 16);
			this.label2.TabIndex = 2;
			this.label2.Text = "Sarà effettuato il pagamento della fattura a partire dalle contabilizzazioni degl" +
    "i ordini esistenti. (creati nel punto 2)";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(656, 16);
			this.label1.TabIndex = 1;
			this.label1.Text = "Questa procedura serve a contabilizzare in finanziario una fattura (tutta o in pa" +
    "rte).";
			// 
			// tabPage2
			// 
			this.tabPage2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tabPage2.Controls.Add(this.chk_Enable_Split_Payment);
			this.tabPage2.Controls.Add(this.txtTotalePagatoGenerale);
			this.tabPage2.Controls.Add(this.label21);
			this.tabPage2.Controls.Add(this.txtTotPagatoCausale);
			this.tabPage2.Controls.Add(this.txtTotaleFattura);
			this.tabPage2.Controls.Add(this.txtIvaFattura);
			this.tabPage2.Controls.Add(this.label4);
			this.tabPage2.Controls.Add(this.txtImponibileFattura);
			this.tabPage2.Controls.Add(this.label14);
			this.tabPage2.Controls.Add(this.label15);
			this.tabPage2.Controls.Add(this.labTotPagato);
			this.tabPage2.Controls.Add(this.cmbTipoDocumento);
			this.tabPage2.Controls.Add(this.txtDescrDoc);
			this.tabPage2.Controls.Add(this.labDescrOrdine);
			this.tabPage2.Controls.Add(this.txtFornitore);
			this.tabPage2.Controls.Add(this.label6);
			this.tabPage2.Controls.Add(this.btnSelectAllDetail);
			this.tabPage2.Controls.Add(this.label18);
			this.tabPage2.Controls.Add(this.groupBox2);
			this.tabPage2.Controls.Add(this.gridDetails);
			this.tabPage2.Controls.Add(this.cmbCausale);
			this.tabPage2.Controls.Add(this.labelCausale);
			this.tabPage2.Controls.Add(this.btnDocumento);
			this.tabPage2.Controls.Add(this.label9);
			this.tabPage2.Controls.Add(this.txtNumDoc);
			this.tabPage2.Controls.Add(this.label10);
			this.tabPage2.Controls.Add(this.txtEsercDoc);
			this.tabPage2.Location = new System.Drawing.Point(0, 0);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Selected = false;
			this.tabPage2.Size = new System.Drawing.Size(704, 405);
			this.tabPage2.TabIndex = 4;
			this.tabPage2.Title = "Pagina 2 di 3";
			// 
			// chk_Enable_Split_Payment
			// 
			this.chk_Enable_Split_Payment.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.chk_Enable_Split_Payment.Enabled = false;
			this.chk_Enable_Split_Payment.Location = new System.Drawing.Point(502, 105);
			this.chk_Enable_Split_Payment.Name = "chk_Enable_Split_Payment";
			this.chk_Enable_Split_Payment.Size = new System.Drawing.Size(181, 22);
			this.chk_Enable_Split_Payment.TabIndex = 144;
			this.chk_Enable_Split_Payment.Tag = " ";
			this.chk_Enable_Split_Payment.Text = "Crea Recupero Split Payment";
			// 
			// txtTotalePagatoGenerale
			// 
			this.txtTotalePagatoGenerale.Location = new System.Drawing.Point(544, 56);
			this.txtTotalePagatoGenerale.Name = "txtTotalePagatoGenerale";
			this.txtTotalePagatoGenerale.ReadOnly = true;
			this.txtTotalePagatoGenerale.Size = new System.Drawing.Size(127, 23);
			this.txtTotalePagatoGenerale.TabIndex = 143;
			this.txtTotalePagatoGenerale.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label21
			// 
			this.label21.Location = new System.Drawing.Point(541, 40);
			this.label21.Name = "label21";
			this.label21.Size = new System.Drawing.Size(84, 16);
			this.label21.TabIndex = 142;
			this.label21.Text = "Totale pagato";
			// 
			// txtTotPagatoCausale
			// 
			this.txtTotPagatoCausale.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.txtTotPagatoCausale.Location = new System.Drawing.Point(558, 168);
			this.txtTotPagatoCausale.Name = "txtTotPagatoCausale";
			this.txtTotPagatoCausale.ReadOnly = true;
			this.txtTotPagatoCausale.Size = new System.Drawing.Size(113, 23);
			this.txtTotPagatoCausale.TabIndex = 141;
			this.txtTotPagatoCausale.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// txtTotaleFattura
			// 
			this.txtTotaleFattura.Location = new System.Drawing.Point(368, 56);
			this.txtTotaleFattura.Name = "txtTotaleFattura";
			this.txtTotaleFattura.ReadOnly = true;
			this.txtTotaleFattura.Size = new System.Drawing.Size(128, 23);
			this.txtTotaleFattura.TabIndex = 140;
			this.txtTotaleFattura.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// txtIvaFattura
			// 
			this.txtIvaFattura.Location = new System.Drawing.Point(232, 56);
			this.txtIvaFattura.Name = "txtIvaFattura";
			this.txtIvaFattura.ReadOnly = true;
			this.txtIvaFattura.Size = new System.Drawing.Size(112, 23);
			this.txtIvaFattura.TabIndex = 139;
			this.txtIvaFattura.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(88, 40);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(100, 16);
			this.label4.TabIndex = 135;
			this.label4.Text = "Tot. Imponibile";
			// 
			// txtImponibileFattura
			// 
			this.txtImponibileFattura.Location = new System.Drawing.Point(88, 56);
			this.txtImponibileFattura.Name = "txtImponibileFattura";
			this.txtImponibileFattura.ReadOnly = true;
			this.txtImponibileFattura.Size = new System.Drawing.Size(120, 23);
			this.txtImponibileFattura.TabIndex = 138;
			this.txtImponibileFattura.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label14
			// 
			this.label14.Location = new System.Drawing.Point(232, 40);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(100, 16);
			this.label14.TabIndex = 136;
			this.label14.Text = "Tot. Iva";
			// 
			// label15
			// 
			this.label15.Location = new System.Drawing.Point(368, 40);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(100, 16);
			this.label15.TabIndex = 137;
			this.label15.Text = "Totale";
			// 
			// labTotPagato
			// 
			this.labTotPagato.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.labTotPagato.Location = new System.Drawing.Point(384, 170);
			this.labTotPagato.Name = "labTotPagato";
			this.labTotPagato.Size = new System.Drawing.Size(169, 19);
			this.labTotPagato.TabIndex = 134;
			this.labTotPagato.Text = "Totale pagato sulla causale:";
			this.labTotPagato.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// cmbTipoDocumento
			// 
			this.cmbTipoDocumento.DataSource = this.DS.invoicekind;
			this.cmbTipoDocumento.DisplayMember = "description";
			this.cmbTipoDocumento.Location = new System.Drawing.Point(128, 8);
			this.cmbTipoDocumento.Name = "cmbTipoDocumento";
			this.cmbTipoDocumento.Size = new System.Drawing.Size(256, 23);
			this.cmbTipoDocumento.TabIndex = 133;
			this.cmbTipoDocumento.ValueMember = "idinvkind";
			// 
			// DS
			// 
			this.DS.DataSetName = "vistaForm";
			this.DS.EnforceConstraints = false;
			// 
			// txtDescrDoc
			// 
			this.txtDescrDoc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtDescrDoc.Location = new System.Drawing.Point(88, 120);
			this.txtDescrDoc.Multiline = true;
			this.txtDescrDoc.Name = "txtDescrDoc";
			this.txtDescrDoc.ReadOnly = true;
			this.txtDescrDoc.Size = new System.Drawing.Size(392, 40);
			this.txtDescrDoc.TabIndex = 132;
			// 
			// labDescrOrdine
			// 
			this.labDescrOrdine.Location = new System.Drawing.Point(16, 120);
			this.labDescrOrdine.Name = "labDescrOrdine";
			this.labDescrOrdine.Size = new System.Drawing.Size(64, 16);
			this.labDescrOrdine.TabIndex = 131;
			this.labDescrOrdine.Text = "Descrizione";
			this.labDescrOrdine.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtFornitore
			// 
			this.txtFornitore.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtFornitore.Location = new System.Drawing.Point(88, 88);
			this.txtFornitore.Name = "txtFornitore";
			this.txtFornitore.ReadOnly = true;
			this.txtFornitore.Size = new System.Drawing.Size(392, 23);
			this.txtFornitore.TabIndex = 130;
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(16, 88);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(56, 16);
			this.label6.TabIndex = 129;
			this.label6.Text = "Fornitore";
			this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// btnSelectAllDetail
			// 
			this.btnSelectAllDetail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnSelectAllDetail.Location = new System.Drawing.Point(576, 200);
			this.btnSelectAllDetail.Name = "btnSelectAllDetail";
			this.btnSelectAllDetail.Size = new System.Drawing.Size(96, 23);
			this.btnSelectAllDetail.TabIndex = 127;
			this.btnSelectAllDetail.Text = "Seleziona tutto";
			this.btnSelectAllDetail.Click += new System.EventHandler(this.btnSelectAllDetail_Click);
			// 
			// label18
			// 
			this.label18.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.label18.Location = new System.Drawing.Point(8, 200);
			this.label18.Name = "label18";
			this.label18.Size = new System.Drawing.Size(542, 32);
			this.label18.TabIndex = 126;
			this.label18.Text = "Selezionare i dettagli da contabilizzare (sono visualizzati solo i dettagli a cui" +
    " è stato associato un UPB e il cui dettaglio ordine collegato non sia già stato " +
    "pagato)";
			// 
			// groupBox2
			// 
			this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox2.Controls.Add(this.txtTotGenerale);
			this.groupBox2.Controls.Add(this.txtTotIva);
			this.groupBox2.Controls.Add(this.label5);
			this.groupBox2.Controls.Add(this.txtTotImponibile);
			this.groupBox2.Controls.Add(this.label7);
			this.groupBox2.Controls.Add(this.label8);
			this.groupBox2.Location = new System.Drawing.Point(16, 338);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(664, 64);
			this.groupBox2.TabIndex = 125;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Dettagli selezionati";
			// 
			// txtTotGenerale
			// 
			this.txtTotGenerale.Location = new System.Drawing.Point(296, 32);
			this.txtTotGenerale.Name = "txtTotGenerale";
			this.txtTotGenerale.ReadOnly = true;
			this.txtTotGenerale.Size = new System.Drawing.Size(128, 23);
			this.txtTotGenerale.TabIndex = 109;
			this.txtTotGenerale.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// txtTotIva
			// 
			this.txtTotIva.Location = new System.Drawing.Point(160, 32);
			this.txtTotIva.Name = "txtTotIva";
			this.txtTotIva.ReadOnly = true;
			this.txtTotIva.Size = new System.Drawing.Size(112, 23);
			this.txtTotIva.TabIndex = 108;
			this.txtTotIva.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(8, 16);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(100, 16);
			this.label5.TabIndex = 104;
			this.label5.Text = "Tot. Imponibile";
			// 
			// txtTotImponibile
			// 
			this.txtTotImponibile.Location = new System.Drawing.Point(8, 32);
			this.txtTotImponibile.Name = "txtTotImponibile";
			this.txtTotImponibile.ReadOnly = true;
			this.txtTotImponibile.Size = new System.Drawing.Size(136, 23);
			this.txtTotImponibile.TabIndex = 107;
			this.txtTotImponibile.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(160, 16);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(100, 16);
			this.label7.TabIndex = 105;
			this.label7.Text = "Tot. Iva";
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(296, 16);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(100, 16);
			this.label8.TabIndex = 106;
			this.label8.Text = "Totale";
			// 
			// gridDetails
			// 
			this.gridDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.gridDetails.DataMember = "";
			this.gridDetails.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.gridDetails.Location = new System.Drawing.Point(16, 232);
			this.gridDetails.Name = "gridDetails";
			this.gridDetails.Size = new System.Drawing.Size(664, 100);
			this.gridDetails.TabIndex = 124;
			this.gridDetails.Paint += new System.Windows.Forms.PaintEventHandler(this.gridDetails_Paint);
			// 
			// cmbCausale
			// 
			this.cmbCausale.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.cmbCausale.DataSource = this.DS.tipomovimento;
			this.cmbCausale.DisplayMember = "descrizione";
			this.cmbCausale.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World, ((byte)(0)));
			this.cmbCausale.ItemHeight = 13;
			this.cmbCausale.Location = new System.Drawing.Point(88, 168);
			this.cmbCausale.Name = "cmbCausale";
			this.cmbCausale.Size = new System.Drawing.Size(289, 21);
			this.cmbCausale.TabIndex = 123;
			this.cmbCausale.ValueMember = "idtipo";
			this.cmbCausale.SelectedIndexChanged += new System.EventHandler(this.cmbCausale_SelectedIndexChanged);
			// 
			// labelCausale
			// 
			this.labelCausale.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World, ((byte)(0)));
			this.labelCausale.Location = new System.Drawing.Point(16, 168);
			this.labelCausale.Name = "labelCausale";
			this.labelCausale.Size = new System.Drawing.Size(48, 23);
			this.labelCausale.TabIndex = 122;
			this.labelCausale.Text = "Causale";
			this.labelCausale.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// btnDocumento
			// 
			this.btnDocumento.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnDocumento.Location = new System.Drawing.Point(16, 8);
			this.btnDocumento.Name = "btnDocumento";
			this.btnDocumento.Size = new System.Drawing.Size(104, 20);
			this.btnDocumento.TabIndex = 121;
			this.btnDocumento.Text = "Documento Iva";
			this.btnDocumento.Click += new System.EventHandler(this.btnDocumento_Click);
			// 
			// label9
			// 
			this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label9.Location = new System.Drawing.Point(392, 8);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(48, 16);
			this.label9.TabIndex = 117;
			this.label9.Text = "Eserc.";
			this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtNumDoc
			// 
			this.txtNumDoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtNumDoc.Location = new System.Drawing.Point(528, 8);
			this.txtNumDoc.Name = "txtNumDoc";
			this.txtNumDoc.Size = new System.Drawing.Size(64, 20);
			this.txtNumDoc.TabIndex = 120;
			this.txtNumDoc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.txtNumDoc.Leave += new System.EventHandler(this.txtNumDoc_Leave);
			// 
			// label10
			// 
			this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label10.Location = new System.Drawing.Point(496, 8);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(32, 16);
			this.label10.TabIndex = 119;
			this.label10.Text = "Num.";
			this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtEsercDoc
			// 
			this.txtEsercDoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtEsercDoc.Location = new System.Drawing.Point(440, 8);
			this.txtEsercDoc.Name = "txtEsercDoc";
			this.txtEsercDoc.Size = new System.Drawing.Size(56, 20);
			this.txtEsercDoc.TabIndex = 118;
			this.txtEsercDoc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.txtEsercDoc.Leave += new System.EventHandler(this.txtEsercDoc_Leave);
			// 
			// tabPage3
			// 
			this.tabPage3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tabPage3.Controls.Add(this.SubEntity_chkAutomRecuperi);
			this.tabPage3.Controls.Add(this.groupBox1);
			this.tabPage3.Controls.Add(this.groupBox3);
			this.tabPage3.Controls.Add(this.label23);
			this.tabPage3.Controls.Add(this.label22);
			this.tabPage3.Controls.Add(this.txtPerc);
			this.tabPage3.Controls.Add(this.labelAttenzione);
			this.tabPage3.Controls.Add(this.label13);
			this.tabPage3.Controls.Add(this.txtMessage);
			this.tabPage3.Controls.Add(this.txtDaPagare);
			this.tabPage3.Controls.Add(this.label12);
			this.tabPage3.Location = new System.Drawing.Point(0, 0);
			this.tabPage3.Name = "tabPage3";
			this.tabPage3.Size = new System.Drawing.Size(704, 405);
			this.tabPage3.TabIndex = 5;
			this.tabPage3.Title = "Pagina 3 di 3";
			// 
			// SubEntity_chkAutomRecuperi
			// 
			this.SubEntity_chkAutomRecuperi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.SubEntity_chkAutomRecuperi.Location = new System.Drawing.Point(360, 358);
			this.SubEntity_chkAutomRecuperi.Name = "SubEntity_chkAutomRecuperi";
			this.SubEntity_chkAutomRecuperi.Size = new System.Drawing.Size(328, 24);
			this.SubEntity_chkAutomRecuperi.TabIndex = 15;
			this.SubEntity_chkAutomRecuperi.Tag = " ";
			this.SubEntity_chkAutomRecuperi.Text = "Non generare automatismi per i Recuperi";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.gboxBolletta);
			this.groupBox1.Location = new System.Drawing.Point(16, 336);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(332, 59);
			this.groupBox1.TabIndex = 14;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Informazioni da associare al pagamento (opzionali)";
			// 
			// gboxBolletta
			// 
			this.gboxBolletta.Controls.Add(this.txtBolletta);
			this.gboxBolletta.Controls.Add(this.btnBolletta);
			this.gboxBolletta.Location = new System.Drawing.Point(6, 13);
			this.gboxBolletta.Name = "gboxBolletta";
			this.gboxBolletta.Size = new System.Drawing.Size(312, 40);
			this.gboxBolletta.TabIndex = 73;
			this.gboxBolletta.TabStop = false;
			this.gboxBolletta.Tag = "AutoChoose.txtBolletta.spesa.(active=\'S\')";
			// 
			// txtBolletta
			// 
			this.txtBolletta.Location = new System.Drawing.Point(104, 12);
			this.txtBolletta.Name = "txtBolletta";
			this.txtBolletta.Size = new System.Drawing.Size(100, 23);
			this.txtBolletta.TabIndex = 1;
			this.txtBolletta.Tag = "bill.nbill";
			// 
			// btnBolletta
			// 
			this.btnBolletta.Location = new System.Drawing.Point(8, 12);
			this.btnBolletta.Name = "btnBolletta";
			this.btnBolletta.Size = new System.Drawing.Size(88, 23);
			this.btnBolletta.TabIndex = 0;
			this.btnBolletta.TabStop = false;
			this.btnBolletta.Tag = "choose.bill.spesa.((active=\'S\') AND (isnull(total,0)-isnull(reduction,0)>covered)" +
    " AND (ISNULL(toregularize,0)>0))";
			this.btnBolletta.Text = "N. bolletta";
			// 
			// groupBox3
			// 
			this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox3.Controls.Add(this.lblCausale);
			this.groupBox3.Controls.Add(this.txtTotSelezionato);
			this.groupBox3.Controls.Add(this.label3);
			this.groupBox3.Controls.Add(this.rdbSplittaUno);
			this.groupBox3.Controls.Add(this.rdbSplittaTutti);
			this.groupBox3.Location = new System.Drawing.Point(16, 19);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(672, 104);
			this.groupBox3.TabIndex = 13;
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
			this.txtTotSelezionato.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.txtTotSelezionato.Location = new System.Drawing.Point(498, 26);
			this.txtTotSelezionato.Name = "txtTotSelezionato";
			this.txtTotSelezionato.ReadOnly = true;
			this.txtTotSelezionato.Size = new System.Drawing.Size(151, 23);
			this.txtTotSelezionato.TabIndex = 0;
			this.txtTotSelezionato.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label3
			// 
			this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label3.Location = new System.Drawing.Point(283, 30);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(205, 13);
			this.label3.TabIndex = 0;
			this.label3.Text = "il totale dei dettagli selezionati è";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// rdbSplittaUno
			// 
			this.rdbSplittaUno.AutoSize = true;
			this.rdbSplittaUno.Checked = true;
			this.rdbSplittaUno.Location = new System.Drawing.Point(17, 52);
			this.rdbSplittaUno.Name = "rdbSplittaUno";
			this.rdbSplittaUno.Size = new System.Drawing.Size(565, 19);
			this.rdbSplittaUno.TabIndex = 1;
			this.rdbSplittaUno.TabStop = true;
			this.rdbSplittaUno.Text = "Contabilizza interamente i dettagli fino a coprire l\'importo da pagare. Sarà sudd" +
    "iviso al più un dettaglio";
			this.rdbSplittaUno.UseVisualStyleBackColor = true;
			this.rdbSplittaUno.CheckedChanged += new System.EventHandler(this.rdbSplittaUno_CheckedChanged);
			// 
			// rdbSplittaTutti
			// 
			this.rdbSplittaTutti.AutoSize = true;
			this.rdbSplittaTutti.Location = new System.Drawing.Point(18, 76);
			this.rdbSplittaTutti.Name = "rdbSplittaTutti";
			this.rdbSplittaTutti.Size = new System.Drawing.Size(511, 19);
			this.rdbSplittaTutti.TabIndex = 2;
			this.rdbSplittaTutti.Text = "Distribuisci l\'importo da pagare su tutti i dettagli selezionati. Tutti i dettagl" +
    "i saranno suddivisi";
			this.rdbSplittaTutti.UseVisualStyleBackColor = true;
			this.rdbSplittaTutti.CheckedChanged += new System.EventHandler(this.rdbSplittaTutti_CheckedChanged);
			// 
			// label23
			// 
			this.label23.Location = new System.Drawing.Point(324, 126);
			this.label23.Name = "label23";
			this.label23.Size = new System.Drawing.Size(128, 16);
			this.label23.TabIndex = 12;
			this.label23.Text = "Importo";
			this.label23.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label22
			// 
			this.label22.Location = new System.Drawing.Point(260, 126);
			this.label22.Name = "label22";
			this.label22.Size = new System.Drawing.Size(56, 16);
			this.label22.TabIndex = 11;
			this.label22.Text = "%";
			this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtPerc
			// 
			this.txtPerc.Location = new System.Drawing.Point(256, 144);
			this.txtPerc.Name = "txtPerc";
			this.txtPerc.Size = new System.Drawing.Size(64, 23);
			this.txtPerc.TabIndex = 10;
			this.txtPerc.Leave += new System.EventHandler(this.txtPerc_Leave);
			// 
			// labelAttenzione
			// 
			this.labelAttenzione.Location = new System.Drawing.Point(16, 1);
			this.labelAttenzione.Name = "labelAttenzione";
			this.labelAttenzione.Size = new System.Drawing.Size(352, 16);
			this.labelAttenzione.TabIndex = 8;
			this.labelAttenzione.Text = "Attenzione! Ci sono impegni che non hanno disponibilità sufficiente";
			this.labelAttenzione.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.labelAttenzione.Visible = false;
			// 
			// label13
			// 
			this.label13.Location = new System.Drawing.Point(16, 177);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(656, 16);
			this.label13.TabIndex = 7;
			this.label13.Text = "In base alle impostazioni attuali saranno effettuate le seguenti operazioni:";
			// 
			// txtMessage
			// 
			this.txtMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtMessage.Location = new System.Drawing.Point(16, 198);
			this.txtMessage.Multiline = true;
			this.txtMessage.Name = "txtMessage";
			this.txtMessage.ReadOnly = true;
			this.txtMessage.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtMessage.Size = new System.Drawing.Size(672, 105);
			this.txtMessage.TabIndex = 6;
			// 
			// txtDaPagare
			// 
			this.txtDaPagare.Location = new System.Drawing.Point(328, 144);
			this.txtDaPagare.Name = "txtDaPagare";
			this.txtDaPagare.Size = new System.Drawing.Size(112, 23);
			this.txtDaPagare.TabIndex = 3;
			this.txtDaPagare.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.txtDaPagare.Leave += new System.EventHandler(this.txtDaPagare_Leave);
			// 
			// label12
			// 
			this.label12.Location = new System.Drawing.Point(16, 144);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(224, 23);
			this.label12.TabIndex = 2;
			this.label12.Text = "Inserire il valore che si desidera pagare:";
			this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(640, 446);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 23);
			this.btnCancel.TabIndex = 19;
			this.btnCancel.Tag = "maincancel";
			this.btnCancel.Text = "Cancel";
			// 
			// btnNext
			// 
			this.btnNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnNext.Location = new System.Drawing.Point(520, 446);
			this.btnNext.Name = "btnNext";
			this.btnNext.Size = new System.Drawing.Size(88, 23);
			this.btnNext.TabIndex = 18;
			this.btnNext.Text = "Avanti >";
			this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
			// 
			// btnBack
			// 
			this.btnBack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnBack.Location = new System.Drawing.Point(432, 446);
			this.btnBack.Name = "btnBack";
			this.btnBack.Size = new System.Drawing.Size(80, 23);
			this.btnBack.TabIndex = 17;
			this.btnBack.Text = "< Indietro";
			this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
			// 
			// panel1
			// 
			this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panel1.Controls.Add(this.tabController);
			this.panel1.Location = new System.Drawing.Point(8, 8);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(704, 430);
			this.panel1.TabIndex = 20;
			// 
			// FrmWizardInvoiceDetail
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(720, 491);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnNext);
			this.Controls.Add(this.btnBack);
			this.Controls.Add(this.panel1);
			this.Name = "FrmWizardInvoiceDetail";
			this.Text = "FrmWizardInvoiceDetail";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmWizardInvoiceDetail_FormClosing);
			this.tabController.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tabPage2.ResumeLayout(false);
			this.tabPage2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.gridDetails)).EndInit();
			this.tabPage3.ResumeLayout(false);
			this.tabPage3.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			this.gboxBolletta.ResumeLayout(false);
			this.gboxBolletta.PerformLayout();
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			this.panel1.ResumeLayout(false);
			this.ResumeLayout(false);

        }

        #endregion

        CQueryHelper QHC;
        QueryHelper QHS;

        public void MetaData_AfterLink() {
            Meta = MetaData.GetMetaData(this);
            Conn = Meta.Conn;

            QHC = new CQueryHelper();
            QHS = Conn.GetQueryHelper();

            GetData.CacheTable(DS.mandatekind, null, "description", true);
            string fInvKind = QHS.AppAnd(QHS.BitClear("flag", 2), QHS.BitClear("flag", 0));
            GetData.CacheTable(DS.invoicekind, fInvKind, "description", true);
            GetData.CacheTable(DS.ivakind);
            string filteresercizio = QHS.CmpEq("ayear", Meta.GetSys("esercizio"));
            GetData.CacheTable(DS.config, filteresercizio, null, false);
            GetData.CacheTable(DS.expensephase, null, null, false);
            GetData.CacheTable(DS.clawback);

            string billfilter = QHS.AppAnd(QHS.CmpEq("billkind", 'D'), QHS.CmpEq("ybill", Meta.GetSys("esercizio")),
                QHS.CmpEq("active", "S"));
            GetData.SetStaticFilter(DS.bill, billfilter);
            GetData.SetStaticFilter(DS.billview, billfilter);

            int fasecontratto = CfgFn.GetNoNullInt32(Meta.GetSys("mandatephase"));
            int fasespesamax = CfgFn.GetNoNullInt32(Meta.GetSys("maxexpensephase"));

            if (fasecontratto == fasespesamax) {
                MessageBox.Show(
                    "La fase di contabilizzazione del contratto passivo coincide con l'ultima fase di spesa." +
                    "Non sarà possibile utilizzare questa procedura ",
                    "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                SalvataggioEnabled = false;
            }
            DetailsToUpdate = new ArrayList();
            Meta.CanInsert = false;
            Meta.CanSave = false;
            Meta.SearchEnabled = false;
        }

        public void MetaData_AfterActivation() {
            CustomTitle = "Wizard Pagamento Fatture di Acquisto";
            //Selects first tab
            DisplayTabs(0);
        }


        public void MetaData_AfterClear() {
            DisplayTabs(tabController.SelectedIndex);
        }


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
            if ((oldTab == 3) && (newTab == 2)) {
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
                txtPerc.Text = "100";
                txtDaPagare.Text = txtTotSelezionato.Text;
                RecalcOperationsToDo();
                //				RadioCheck_Changed();

                return true;
            }
            if ((oldTab == 2) && (newTab == 1)) {
                VisualizzaUPB();
                AggiornaGridDettagliDocum();
                rdbSplittaTutti.Checked = false;
                txtDaPagare.Text = "";
                txtPerc.Text = "";
                return true;
            }
            ;
            if ((oldTab == 2) && (newTab == 3)) {
                if (CondizioneErroreBloccante) return false;
                bool Saved = true;
                Saved = doSave();
                if (!Saved) {
                    DialogResult = DialogResult.OK;
                    Close();
                    return false;
                }

                return Saved;

                //				if ((radioNewCont.Checked==false)&&(radioNewLinkedMov.Checked==false)
                //					&&(radioAddCont.Checked==false)) {
                //					MessageBox.Show("Non sarà possibile contabilizzare i dettagli selezionati.");
                //					return false;
                //				}
                //				if (!SelezioneMovimentiEffettuata){
                //					MessageBox.Show("Non è stato selezionato il movimento.");
                //					return false;
                //				}
                //
                //				if (!CheckInfoFin()) return false;
                //				DisplayMessages();
            }
            //			if ((oldTab==3)&&(newTab==4))return doAssocia(); 
            return true;
        }

        #endregion


        DataRow GetGridRow(DataGrid G, int index) {
            string TableName = G.DataMember.ToString();
            DataSet MyDS = (DataSet) G.DataSource;
            DataTable MyTable = MyDS.Tables[TableName];
            string filter;
            DataRow Invoice = DS.invoice.Rows[0];
            filter = QHC.AppAnd(QHC.CmpEq("idinvkind", Invoice["idinvkind"]),
                QHC.CmpEq("yinv", Invoice["yinv"]), QHC.CmpEq("ninv", Invoice["ninv"]), QHC.CmpEq("rownum", G[index, 0]));
            DataRow[] selectresult = MyTable.Select(filter);
            return (selectresult.Length > 0) ? selectresult[0] : null;
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
                    DataRow R = GetGridRow(G, i);
                    if (R == null) continue;
                    numrighe++;
                }
            }

            DataRow[] Res = new DataRow[numrighe];
            int count = 0;
            for (i = 0; i < numrighetemp; i++) {
                if (G.IsSelected(i)) {
                    DataRow R = GetGridRow(G, i);
                    if (R == null) continue;
                    Res[count++] = R;
                }
            }
            return Res;
        }



        private void btnDocumento_Click(object sender, System.EventArgs e) {
            //se true, deve visualizzare anche ordini contabilizzati (genericamente)
            string filter = "";
            int esercizio = (int) Meta.GetSys("esercizio");
            int esercText = CfgFn.GetNoNullInt32(txtEsercDoc.Text);
            if (esercText == 0) esercText = esercizio;
            filter = GetData.MergeFilters(filter, QHS.CmpEq("yinv", esercText));

            if ((!sender.Equals(btnDocumento)) && txtNumDoc.Text.Trim() != "") {
                int ndoc = CfgFn.GetNoNullInt32(txtNumDoc.Text);
                if (ndoc > 0) filter = GetData.MergeFilters(filter, QHS.CmpEq("ninv", ndoc));
            }

            if (cmbTipoDocumento.SelectedIndex > 0) {
                filter = GetData.MergeFilters(filter,
                    QHS.CmpEq("idinvkind", cmbTipoDocumento.SelectedValue));
            }
            else {
                filter = GetData.MergeFilters(filter, QHS.AppAnd(QHS.CmpEq("flagvariation", 'N'),
                    QHS.CmpEq("flagbuysell", 'A')));
            }

            filter = GetData.MergeFilters(filter, QHS.CmpGt("residual", 0));
            filter = QHS.AppAnd(filter, QHS.NullOrEq("active", "S"));
            MetaData Invoice = MetaData.GetMetaData(this, "invoiceavailable");
            Invoice.FilterLocked = true;
            Invoice.DS = new DataSet();
            DataRow I = Invoice.SelectOne("default", filter, null, null);
            if (I == null) return;
            HelpForm.SetComboBoxValue(cmbTipoDocumento, I["idinvkind"]);
            txtEsercDoc.Text = I["yinv"].ToString();
            txtNumDoc.Text = I["ninv"].ToString();
            txtFornitore.Text = I["registry"].ToString();
            txtDescrDoc.Text = I["description"].ToString();
            if (I["flag_enable_split_payment"].ToString() == "S")
                chk_Enable_Split_Payment.Checked = true;
            else
                chk_Enable_Split_Payment.Checked = false;
            decimal imponibile = CfgFn.GetNoNullDecimal(I["taxabletotal"]);
            txtImponibileFattura.Text = imponibile.ToString("c");
            decimal iva = CfgFn.GetNoNullDecimal(I["ivatotal"]);
            txtIvaFattura.Text = iva.ToString("c");
            decimal tot = imponibile + iva;
            txtTotaleFattura.Text = tot.ToString("c");
            decimal linked = CfgFn.GetNoNullDecimal(I["linkedamount"]);
            txtTotalePagatoGenerale.Text = linked.ToString("c");

            DS.invoicedetail.Clear();
            DetailsToUpdate.Clear();
            DS.invoice.Clear();

            string filterinvoice = QHS.AppAnd(QHS.CmpEq("idinvkind", I["idinvkind"]),
                QHS.CmpEq("yinv", I["yinv"]), QHS.CmpEq("ninv", I["ninv"]));

            DataAccess.RUN_SELECT_INTO_TABLE(Conn, DS.invoice, null, filterinvoice, null, false);
            SetComboCausaleDocumento(I);
            AggiornaGridDettagliDocum();
        }


        void ClearDocum() {
            //txtEsercDoc.Text="";
            txtNumDoc.Text = "";
            txtDescrDoc.Text = "";
            txtFornitore.Text = "";
            txtImponibileFattura.Text = "";
            txtIvaFattura.Text = "";
            txtTotaleFattura.Text = "";
            txtTotalePagatoGenerale.Text = "";
            txtTotPagatoCausale.Text = "";
            DS.invoice.Clear();
            DS.invoicedetail.Clear();
            if (DSCopy != null) {
                DSCopy.Tables["invoicedetail"].Clear();
            }
            DS.invoicedetail.Clear();
            RecalcTotalDetails();
        }

        bool insideEsercLeave = false;
        private void txtEsercDoc_Leave(object sender, System.EventArgs e) {
            if (Meta.destroyed) return;
            if (insideEsercLeave) return;
            int YMan = CfgFn.GetNoNullInt32(txtEsercDoc.Text);
            if (YMan <= 0) {
                ClearDocum();
                return;
            }
            if (YMan < 1000) {
                YMan += 2000;
                txtEsercDoc.Text = YMan.ToString();
            }
            if (txtNumDoc.Text.Trim() != "") {
                insideEsercLeave = true;
                btnDocumento_Click(sender, e);
                insideEsercLeave = false;
                return;
            }
        }

        bool insideNumDocLeave = false;
        private void txtNumDoc_Leave(object sender, System.EventArgs e) {
            if (insideNumDocLeave) return;
            if (Meta.destroyed) return;
            if (Meta.formController.isClosing) return;
            int NMan = CfgFn.GetNoNullInt32(txtNumDoc.Text);
            if (NMan <= 0) {
                ClearDocum();
                return;
            }
            insideNumDocLeave = true;
            
            //	if (txtEsercDoc.Text.Trim()!=""){
            btnDocumento_Click(sender, e);
            insideNumDocLeave = false;
            
            //	}		
        }

        private void btnSelectAllDetail_Click(object sender, System.EventArgs e) {
            if (gridDetails.DataSource == null) return;
            if (DSCopy != null) {
                for (int i = 0; i < DSCopy.Tables["invoicedetail"].Rows.Count; i++) gridDetails.Select(i);
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
            if (cmbCausale.SelectedValue == null) return;
            DataRow Docum = DS.invoice.Rows[0];
            double tassocambio = CfgFn.GetNoNullDouble(Docum["exchangerate"]);
            if (tassocambio == 0) tassocambio = 1;
            double totiva = 0;
            double totimpo = 0;
            double total = 0;

            int causale = CfgFn.GetNoNullInt32(cmbCausale.SelectedValue);
            foreach (DataRow Curr in Selected) {
                double imponibile = CfgFn.GetNoNullDouble(Curr["taxable"]);
                double iva = CfgFn.GetNoNullDouble(Curr["tax"]);
                double quantitaConfezioni = CfgFn.GetNoNullDouble(Curr["npackage"]);
                //double aliquota  = CfgFn.GetNoNullDouble(Curr["taxrate"]);
                double sconto = CfgFn.GetNoNullDouble(Curr["discount"]);
                double imponibileEUR = (imponibile*quantitaConfezioni*(1 - sconto))*tassocambio;
                double ivaEUR = iva; // *tassocambio;

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
            //txtTotSelezionato.Text= TotaleDaContabilizzare.ToString("c");
            //txtDaPagare.Text= TotaleDaContabilizzare.ToString("c");
        }

        void ResetWizard() {
            if (DS.invoice.Rows.Count > 0) {
                DataRow I = DS.invoice.Rows[0];
                SetComboCausaleDocumento(I);
                string filterinvoice = QHS.AppAnd(QHS.CmpEq("idinvkind", I["idinvkind"]),
                    QHS.CmpEq("yinv", I["yinv"]), QHS.CmpEq("ninv", I["ninv"]));
                totpagatogenerale = CalcolaPagamentiEffettuati(filterinvoice);
                txtTotalePagatoGenerale.Text = totpagatogenerale.ToString("c");
            }
            gridDetails.DataSource = null;
            AggiornaGridDettagliDocum();
            labelAttenzione.Visible = false;
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
        void SetComboCausaleDocumento(DataRow Docum) {
            decimal totimponibile = 0;
            decimal totiva = 0;
            decimal assigned_imponibile = 0;
            decimal assigned_iva = 0;
            decimal assigned_gen = 0;
            bool EnableImpon = true;
            bool EnableImpos = true;
            bool EnableDocum = true;
            bool intracom = false;
            bool recuperoIvaEstera = false;

            string filterdoc = QHS.AppAnd(QHS.CmpEq("idinvkind", Docum["idinvkind"]),
                QHS.CmpEq("yinv", Docum["yinv"]), QHS.CmpEq("ninv", Docum["ninv"]));
            DataTable T = Conn.RUN_SELECT("invoiceresidual", "*", null, filterdoc, null, true);
            if ((T != null) && (T.Rows.Count > 0)) {
                foreach (DataRow Dett in T.Rows) {
                    totimponibile += CfgFn.GetNoNullDecimal(Dett["taxabletotal"]);
                    totiva += CfgFn.GetNoNullDecimal(Dett["ivatotal"]);
                    assigned_imponibile += CfgFn.GetNoNullDecimal(Dett["linkedimpon"]);
                    assigned_iva += CfgFn.GetNoNullDecimal(Dett["linkedimpos"]);
                    assigned_gen += CfgFn.GetNoNullDecimal(Dett["linkeddocum"]);
                    if (Dett["flagintracom"].ToString().ToUpper() != "N") intracom = true;
                    int flag = CfgFn.GetNoNullInt32(Dett["flagbit"]);
                    if ((flag & 64) != 0) {
                        recuperoIvaEstera = true;
                    }
                }
            }
            else {
                totimponibile = 0;
                totiva = 0;
                assigned_imponibile = 0;
                assigned_iva = 0;
                assigned_gen = 0;
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
                EnableTipoMovimento(1, "Contabilizzazione Totale Fattura");
            }

            if (EnableImpon &&
                ((assigned_gen == 0) && (assigned_imponibile < totimponibile))
                ) {
                EnableTipoMovimento(3, "Contabilizzazione Imponibile Fattura");
            }

            if (EnableImpos &&
                ((assigned_gen == 0) && (assigned_iva < totiva))
                ) {
                EnableTipoMovimento(2, "Contabilizzazione Iva Fattura");
            }
        }



        void VisualizzaUPB() {
            DataTable Details = DSCopy.Tables["invoicedetail"];
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

        private void gridDetails_Paint(object sender, System.Windows.Forms.PaintEventArgs e) {
            RecalcTotalDetails();
        }

        private void cmbCausale_SelectedIndexChanged(object sender, System.EventArgs e) {
            AggiornaGridDettagliDocum();
        }

        private decimal CalcolaTotCausale(DataRow InvoiceDetail, int causale) {
            double tassocambio = CfgFn.GetNoNullDouble(DS.invoice.Rows[0]["exchangerate"]);
            if (tassocambio == 0) tassocambio = 1;
            DataRow Curr = InvoiceDetail;

            double imponibile = CfgFn.GetNoNullDouble(Curr["taxable"]);
            double quantitaConfezioni = CfgFn.GetNoNullDouble(Curr["npackage"]);
            //double aliquota  = CfgFn.GetNoNullDouble(Curr["taxrate"]);
            double sconto = CfgFn.GetNoNullDouble(Curr["discount"]);
            double iva = CfgFn.GetNoNullDouble(Curr["tax"]);
            double imponibileEUR = (imponibile*quantitaConfezioni*(1 - sconto))*tassocambio;
            double ivaEUR = iva; // *tassocambio;
            imponibileEUR = CfgFn.RoundValuta(imponibileEUR);
            ivaEUR = CfgFn.RoundValuta(ivaEUR);
            if (causale == 1) return CfgFn.GetNoNullDecimal(ivaEUR + imponibileEUR);
            if (causale == 3) return CfgFn.GetNoNullDecimal(imponibileEUR);
            return CfgFn.GetNoNullDecimal(ivaEUR);
        }

        decimal CalcTotCausale(DataRow[] InvoiceDetail, int causale) {
            decimal sum = 0;
            foreach (DataRow R in InvoiceDetail) sum += CalcolaTotCausale(R, causale);
            // verifica se l'importo è diverso da quello digitato dall'utente

            decimal importototale = CfgFn.GetNoNullDecimal(
                HelpForm.GetObjectFromString(typeof(decimal),
                    txtDaPagare.Text, "x.y.c"));
            if (importototale != 0 && importototale != sum) sum = importototale;
            return sum;
        }


        DataTable PagamentiEsistentiSuCausale = null;
        DataTable LiquidazioniView = null;
        decimal totpagatosucausale = 0;
        decimal totpagatogenerale = 0;

        void AggiornaGridDettagliDocum() {
            DS.invoicedetail.Clear();
            DetailsToUpdate.Clear();
            DS.mandatedetail.Clear();
            DS.mandate.Clear();
            DS.expense.Clear();
            DS.expenseyear.Clear();
            DS.expenseclawback.Clear();

            if (cmbCausale.SelectedIndex < 0) return;
            int causale = CfgFn.GetNoNullInt32(cmbCausale.SelectedValue);
            if (causale == 0) return;
            string filtercausale = QHC.CmpEq("idtipo", causale);
            lblCausale.Text = "Sulla Causale: " + DS.tipomovimento.Select(filtercausale, null)[0]["descrizione"];
            if (DS.invoice.Rows.Count == 0) return;

            DataRow M = DS.invoice.Rows[0];
            string filterinvoice = QHS.AppAnd(QHS.CmpEq("idinvkind", M["idinvkind"]),
                QHS.CmpEq("yinv", M["yinv"]), QHS.CmpEq("ninv", M["ninv"]));
            string filterinvoicedetail = filterinvoice;

            filterinvoicedetail = GetData.MergeFilters(filterinvoicedetail, QHS.IsNotNull("idmankind"));

            if (causale == 1) {
                filterinvoicedetail = GetData.MergeFilters(filterinvoicedetail,
                    QHS.AppAnd(QHS.IsNull("idexp_iva"), QHS.IsNull("idexp_taxable")));
            }
            if (causale == 3) {
                filterinvoicedetail = GetData.MergeFilters(filterinvoicedetail, QHS.IsNull("idexp_taxable"));
            }
            if (causale == 2) {
                filterinvoicedetail = GetData.MergeFilters(filterinvoicedetail, QHS.IsNull("idexp_iva"));
            }

            DSCopy = DS.Copy();
            //DataAccess.RUN_SELECT_INTO_TABLE(Conn,DS.invoicedetail,null,filterinvoicedetail,null,false);
            DataAccess.RUN_SELECT_INTO_TABLE(Conn, DSCopy.Tables["invoicedetail"], null, filterinvoicedetail, null,
                false);

            string filterinvoicepayment = GetData.MergeFilters(filterinvoice, QHS.CmpEq("movkind", causale));

            //In PagamentiEsistentisuCausale mettiamo il complessivo di tutti i pagamenti effettuati sulla causale per quella fattura
            PagamentiEsistentiSuCausale = DataAccess.RUN_SELECT(Conn, "expenseinvoiceview", "*", null,
                filterinvoicepayment, null, null, true);
            totpagatosucausale =
                CfgFn.GetNoNullDecimal(PagamentiEsistentiSuCausale.Compute("SUM(ayearstartamount)", null));
            txtTotPagatoCausale.Text = totpagatosucausale.ToString("c");
            totpagatogenerale = CalcolaPagamentiEffettuati(filterinvoice);
            txtTotalePagatoGenerale.Text = totpagatogenerale.ToString("c");

            LiquidazioniView = DataAccess.CreateTableByName(Conn, "expenseview", null);
            LiquidazioniView.Columns.Add("!disponibile", typeof(decimal));
            LiquidazioniView.Columns.Add("!assegnato", typeof(decimal));
            //LiquidazioniView.Columns.Add("!totale",typeof(decimal));
            LiquidazioniView.Columns.Add("!pagato", typeof(decimal));
            LiquidazioniView.Columns.Add("!selezionato", typeof(decimal));

            LeggiDatiDettagliOrdini();

            EliminaDettagliImpossibili();
            MetaData MD = MetaData.GetMetaData(this, "invoicedetail");
            MD.DescribeColumns(DSCopy.Tables["invoicedetail"], "wizardiva");
            GetData GD = new GetData();
            GD.InitClass(DSCopy, Conn, "invoicedetail");
            GD.GetTemporaryValues(DSCopy.Tables["invoicedetail"]);
            gridDetails.DataSource = null;
            HelpForm.SetDataGrid(gridDetails, DSCopy.Tables["invoicedetail"]);
            btnSelectAllDetail_Click(null, null);
            VisualizzaUPB();
            RecalcTotalDetails();
        }

        private decimal CalcolaPagamentiEffettuati(string invoice) {
            DataTable PagamentiEffettuati = null;
            decimal totpagatogenerale;
            //In PagamentiEffettuati mettiamo il complessivo di tutti i pagamenti effettuati su quella fattura
            PagamentiEffettuati = DataAccess.RUN_SELECT(Conn, "expenseinvoiceview", "*", null, invoice, null, null, true);
            totpagatogenerale = CfgFn.GetNoNullDecimal(PagamentiEffettuati.Compute("SUM(ayearstartamount)", null));
            return totpagatogenerale;
        }

        private decimal CalcolaTotCausaleOrdine(DataRow MandateDetail, int causale) {
            string filtermandate = QueryCreator.WHERE_COLNAME_CLAUSE(
                MandateDetail, new string[] {"idmankind", "yman", "nman"}, DataRowVersion.Default, true);
            DataRow Mandate = DS.mandate.Select(filtermandate)[0];

            double tassocambio = CfgFn.GetNoNullDouble(Mandate["exchangerate"]);
            if (tassocambio == 0) tassocambio = 1;
            DataRow Curr = MandateDetail;

            double imponibile = CfgFn.GetNoNullDouble(Curr["taxable"]);
            double quantitaConfezioni = CfgFn.GetNoNullDouble(Curr["npackage"]);
            double aliquota = CfgFn.GetNoNullDouble(Curr["taxrate"]);
            double sconto = CfgFn.GetNoNullDouble(Curr["discount"]);
            double imponibileEUR = (imponibile*quantitaConfezioni*(1 - sconto))*tassocambio;
            double ivaEUR = imponibileEUR*aliquota;
            imponibileEUR = CfgFn.RoundValuta(imponibileEUR);
            ivaEUR = CfgFn.RoundValuta(ivaEUR);
            if (causale == 1) return CfgFn.GetNoNullDecimal(ivaEUR + imponibileEUR);
            if (causale == 3) return CfgFn.GetNoNullDecimal(imponibileEUR);
            return CfgFn.GetNoNullDecimal(ivaEUR);
        }


        object GetIdMovimento(DataRow MandateDetail, int causale) {
            if (causale == 1 || causale == 1) return MandateDetail["idexp_taxable"];
            if (causale == 3) return MandateDetail["idexp_taxable"];
            if (causale == 2) return MandateDetail["idexp_iva"];
            return DBNull.Value;
        }


        void LeggiDatiDettagliOrdini() {
            int causale = CfgFn.GetNoNullInt32(cmbCausale.SelectedValue);
            int causaledoc = CfgFn.GetNoNullInt32(cmbCausale.SelectedValue);
            //Per ogni dettaglio fattura, legge il dettaglio ordine corrispondente.
            foreach (DataRow InvDet in DSCopy.Tables["invoicedetail"].Rows) {
                string filtermandate = QueryCreator.WHERE_COLNAME_CLAUSE(
                    InvDet, new string[] {"idmankind", "yman", "nman"}, DataRowVersion.Default, true);
                if (DS.mandate.Select(filtermandate).Length == 0) {
                    DataAccess.RUN_SELECT_INTO_TABLE(Conn, DS.mandate, null, filtermandate, null, true);
                }
                string filterdetail = GetData.MergeFilters(filtermandate,
                    QHS.CmpEq("rownum", InvDet["manrownum"]));
                if (DS.mandatedetail.Select(filterdetail).Length == 0) {
                    DataAccess.RUN_SELECT_INTO_TABLE(Conn, DS.mandatedetail, null, filterdetail, null, true);
                }
                //DataRow ManDet = DS.mandatedetail.Select(filterdetail)[0];
                //decimal totdetinvoice = CalcolaTotCausale(InvDet, causaledoc);
                //ManDet["!totale"]= CfgFn.GetNoNullDecimal(ManDet["!totale"])+totdetinvoice;
            }

            foreach (DataRow ManDet in DS.mandatedetail.Rows) {
                object id_liquidazione = GetIdMovimento(ManDet, causale);
                string filteridliquid = QHS.AppAnd(QHS.CmpEq("idexp", id_liquidazione),
                    QHS.CmpEq("ayear", Meta.GetSys("esercizio")));
                if (LiquidazioniView.Select(filteridliquid).Length == 0) {
                    //Legge il mov. di spesa collegato al dettaglio ordine
                    DataAccess.RUN_SELECT_INTO_TABLE(Conn, LiquidazioniView, null, filteridliquid, null, true);
                }
                if (LiquidazioniView.Select(filteridliquid).Length == 0) {
                    MessageBox.Show("Del dettaglio ordine " +
                                    ManDet["idmankind"].ToString() + "/" + ManDet["yman"].ToString() + "/" +
                                    ManDet["nman"].ToString() + "/" + ManDet["rownum"].ToString() +
                                    " non è stata effettuata la contabilizzazione, quindi il dettaglio fattura " +
                                    " non sarà disponibile in questa procedura.");
                    continue;
                }
                DataRow Liquidazione = LiquidazioniView.Select(filteridliquid)[0];
                //Inizialmente disponibile = quello della liquidazione 
                Liquidazione["!disponibile"] = CfgFn.GetNoNullDecimal(Liquidazione["available"]);
                //Imposta a 0 l'assegnato, che sarà calcolato in seguito.
                Liquidazione["!assegnato"] = 0;

                //Calcola il totale pagato su quel dettaglio per questa fattura
                //decimal pagato = CfgFn.GetNoNullDecimal(
                //    PagamentiEsistentiSuCausale.Compute("SUM(ayearstartamount)",
                //    "(idexp like " + QueryCreator.quotedstrvalue(id_liquidazione + "%", false) + ")"));

                decimal pagato = 0;
                foreach (DataRow R in PagamentiEsistentiSuCausale.Rows) {
                    object idmandatephase = Meta.Conn.DO_READ_VALUE("expenselink",
                        QHS.AppAnd(QHS.CmpEq("idchild", R["idexp"]),
                            QHS.CmpEq("nlevel", Meta.GetSys("mandatephase"))), "idparent");
                    if (idmandatephase.Equals(id_liquidazione)) pagato += CfgFn.GetNoNullDecimal(R["ayearstartamount"]);
                }

                Liquidazione["!pagato"] = pagato;
            }
        }


        /// <summary>
        /// Elimina dalla tabella InvoiceDetail i dettagli che per vari motivi NON
        ///  possono essere contabilizzati e quindi non devono apparire nel grid dei dettagli. 
        /// </summary>
        void EliminaDettagliImpossibili() {
            int causale = CfgFn.GetNoNullInt32(cmbCausale.SelectedValue);
            string filtercausaleantagonista = "";
            PagamentiEsistentiSuCausale = null;

            if (DS.invoice.Rows.Count == 0) return;
            DataRow Invoice = DS.invoice.Rows[0];

            // J.T.R. - QUESTO FILTRO NON E' STATO MAI USATO. HO VISTO TUTTE LE VERSIONI SU VSS DALLA PRIMA
            //string filterinvoice = QueryCreator.WHERE_COLNAME_CLAUSE(
            //    Invoice, new string[] { "idinvkind", "yinv", "ninv" }, DataRowVersion.Default, true);
            //filterinvoice = GetData.MergeFilters(filterinvoice,
            //    "(movkind=" + QueryCreator.quotedstrvalue(causale, true) + ")");

            if (causale == 3) {
                filtercausaleantagonista = QHS.CmpEq("movkind", 1);
            }
            if (causale == 2) {
                filtercausaleantagonista = QHS.CmpEq("movkind", 1);
            }
            if (causale == 1) {
                filtercausaleantagonista = QHS.DoPar(QHS.AppOr(QHS.CmpEq("movkind", 3), QHS.CmpEq("movkind", 2)));
            }

            //Inizia a valorizzare l'idexptolink per ogni dettaglio collegato a dettaglio ordine contabilizzato
            foreach (DataRow InvDet in DSCopy.Tables["invoicedetail"].Rows) {
                //alla fine saranno cancellati i dettagli con InvDet["!idexptolink"] a NULL
                InvDet["!idexptolink"] = DBNull.Value; //di default il dettaglio è da eliminare.

                string filtermandate = QueryCreator.WHERE_COLNAME_CLAUSE(
                    InvDet, new string[] {"idmankind", "yman", "nman"}, DataRowVersion.Default, true);
                string filterdetail = GetData.MergeFilters(filtermandate,
                    QHC.CmpEq("rownum", InvDet["manrownum"]));

                if (DS.mandatedetail.Select(filterdetail).Length == 0) continue; //non dovrebbe capitare
                DataRow MandateDetail = DS.mandatedetail.Select(filterdetail)[0];

                object id_liquidazione = GetIdMovimento(MandateDetail, causale);
                string filteridliquid = QHS.AppAnd(QHS.CmpEq("idexp", id_liquidazione),
                    QHS.CmpEq("ayear", Meta.GetSys("esercizio")));
                if (LiquidazioniView.Select(filteridliquid).Length == 0) continue;

                DataRow Liquidazione = LiquidazioniView.Select(filteridliquid)[0];

                string filterantagonista = GetData.MergeFilters(
                    filtermandate, filtercausaleantagonista);
                int N = Conn.RUN_SELECT_COUNT("expensemandate", filterantagonista, true);
                if (N > 0) continue;
                InvDet["!idexptolink"] = GetIdMovimento(MandateDetail, causale);

            }

            //Elimina tutti i dettagli con idexptolink a null
            foreach (DataRow InvDet in DSCopy.Tables["invoicedetail"].Select()) {
                if (InvDet["!idexptolink"] == DBNull.Value) {
                    string filtermandate = QueryCreator.WHERE_COLNAME_CLAUSE(
                        InvDet, new string[] {"idmankind", "yman", "nman"}, DataRowVersion.Default, true);
                    string filterdetail = GetData.MergeFilters(filtermandate,
                        QHC.CmpEq("rownum", InvDet["manrownum"]));
                    DataRow[] MandateDetail = DS.mandatedetail.Select(filterdetail);

                    if (MandateDetail.Length > 0) {
                        DataRow Detail = MandateDetail[0];
                        Detail.Delete();
                    }
                    InvDet.Delete();
                }
            }
            DSCopy.Tables["invoicedetail"].AcceptChanges();
            DS.mandatedetail.AcceptChanges();
        }


        bool CondizioneErroreBloccante = false;

        void RecalcOperationsToDo() {
            CondizioneErroreBloccante = true;
            ClearOperazionsToDo();

            int causale = CfgFn.GetNoNullInt32(cmbCausale.SelectedValue);

            DataRow[] Selected = GetGridSelectedRows(gridDetails);

            decimal ImportoMax = CfgFn.GetNoNullDecimal(
                HelpForm.GetObjectFromString(typeof(decimal),
                    txtTotSelezionato.Text, "x.y.c"));

            decimal ImportoDaPagare = CfgFn.GetNoNullDecimal(
                HelpForm.GetObjectFromString(typeof(decimal),
                    txtDaPagare.Text, "x.y.c"));
            txtDaPagare.Text = ImportoDaPagare.ToString("c");
            decimal PercentualeDigitata = CfgFn.GetNoNullDecimal(
                HelpForm.GetObjectFromString(typeof(decimal),
                    txtPerc.Text, "x.y.c"));

            if (ImportoDaPagare > ImportoMax) {
                MessageBox.Show("L'importo da pagare è superiore al totale dei dettagli selezionati");
                return;
            }
            foreach (DataRow InvDet in Selected) {
                string filterinvoicedetail = QueryCreator.WHERE_COLNAME_CLAUSE(
                    InvDet, new string[] {"idinvkind", "yinv", "ninv", "rownum"}, DataRowVersion.Default, true);
                DataAccess.RUN_SELECT_INTO_TABLE(Conn, DS.Tables["invoicedetail"], null, filterinvoicedetail, null,
                    false);
            }
            decimal percentuale = 100;
            if (ImportoMax != 0) percentuale = ImportoDaPagare/ImportoMax*100;
            decimal rounded = Math.Round(percentuale, 4);
            // calcola la percentuale in base all'importo
            txtPerc.Text = HelpForm.StringValue(rounded, "x.y.fixed.4...1");
            // Ricalcolo dettagli da contabilizzare
            // Ciclo per riempire DS.invoicedetail con i soli dettagli selezionati 
            RecalcDettagliSelezionati();
            // Ora i dettagli sono splittati in base alla scelta dell'utente

            // Calcolo delle liquidazioni
            // decimal ImportoResiduoSelezionato=0;
            foreach (DataRow ManDet in DS.mandatedetail.Rows) ManDet["!assegnato"] = 0;
            foreach (DataRow Liquid in LiquidazioniView.Rows) {
                //ImportoResiduoSelezionato+= CfgFn.GetNoNullDecimal(Liquid["!totale"])-
                //	CfgFn.GetNoNullDecimal(Liquid["!pagato"]);
                Liquid["!assegnato"] = 0;
                Liquid["!selezionato"] = 0;
            }
            string filterDetails = null;
            if (DetailsToUpdate.Count > 0) {
                string listRownum = "(";
                foreach (int rownum in DetailsToUpdate) {
                    listRownum += rownum.ToString() + ",";
                }
                listRownum = listRownum.Substring(0, listRownum.Length - 1) + ")";
                filterDetails = "(rownum in " + listRownum + ")";
            }
            else {
                MessageBox.Show(this, "Nessun dettaglio selezionato", "Avviso");
                return;
            }
            DataRow[] details = DS.invoicedetail.Select(filterDetails);

            //Calcola il campo !assegnato di LiquidazioniView
            foreach (DataRow InvDet in details) {

                string filterinvdetail = QueryCreator.WHERE_COLNAME_CLAUSE
                    (InvDet, new string[] {"idinvkind", "yinv", "ninv", "rownum"}, DataRowVersion.Default, true);
                DataRow[] Recalc = DS.invoicedetail.Select(filterinvdetail);
                DataRow InvDetRecalc = null;
                if (Recalc.Length == 1) InvDetRecalc = Recalc[0];
                decimal totdetinvoice = CalcolaTotCausale(InvDetRecalc, causale);
                string filtermandate = QueryCreator.WHERE_COLNAME_CLAUSE(
                    InvDet, new string[] {"idmankind", "yman", "nman"}, DataRowVersion.Default, true);
                string filterdetail = GetData.MergeFilters(filtermandate,
                    QHC.CmpEq("rownum", InvDet["manrownum"]));

                if (DS.mandatedetail.Select(filterdetail).Length == 0) continue; //non dovrebbe capitare
                DataRow MandateDetail = DS.mandatedetail.Select(filterdetail)[0];

                object id_liquidazione = GetIdMovimento(MandateDetail, causale);
                string filteridliquid = QHC.AppAnd(QHC.CmpEq("idexp", id_liquidazione),
                    QHC.CmpEq("ayear", Meta.GetSys("esercizio")));
                if (LiquidazioniView.Select(filteridliquid).Length == 0) continue;

                DataRow Liquidazione = LiquidazioniView.Select(filteridliquid)[0];
                Liquidazione["!selezionato"] = CfgFn.GetNoNullDecimal(Liquidazione["!selezionato"]) + totdetinvoice;

                // Si predisponde già ad associare il dettaglio fattura con la corrispondente liquidazione
                // Per il momento associa l'idexp dell'impegno che contabilizza il dettaglio ordine, poi sarà
                // sostituito in DoSave, dall'idexp del pagamento che contabilizza il dettaglio fattura
                switch (causale) {
                    case 1:
                        InvDetRecalc["idexp_taxable"] = Liquidazione["idexp"];
                        InvDetRecalc["idexp_iva"] = Liquidazione["idexp"];
                        break;
                    case 3:
                        InvDetRecalc["idexp_taxable"] = Liquidazione["idexp"];
                        break;
                    case 2:
                        InvDetRecalc["idexp_iva"] = Liquidazione["idexp"];
                        break;
                }
            }

            //txtResidui.Text= ImportoResiduoSelezionato.ToString("c");
            /*if (ImportoResiduoSelezionato<ImportoDaPagare){
				MessageBox.Show("L'importo da pagare è superiore al disponibile sugli impegni associati ai dettagli ordine");
				return;
			}*/

            //Tenterà di pagare, dettaglio per dettaglio, una porzione in base al totale specificato.
            decimal totassegnato = 0; //Somma di ciò che ha assegnato nei vari impegni						
            foreach (DataRow Liquidazione in LiquidazioniView.Rows) {
                decimal selezionato = CfgFn.GetNoNullDecimal(Liquidazione["!selezionato"]);
                //decimal totale= CfgFn.GetNoNullDecimal(Liquidazione["!totale"]);
                decimal pagato = CfgFn.GetNoNullDecimal(Liquidazione["!pagato"]);
                decimal disponibile = CfgFn.GetNoNullDecimal(Liquidazione["!disponibile"]) -
                                      CfgFn.GetNoNullDecimal(Liquidazione["!assegnato"]);
                decimal old_assegnato = CfgFn.GetNoNullDecimal(Liquidazione["!assegnato"]);
                decimal toPay = selezionato;
                //if (pagato+toPay > totale)	toPay= totale-pagato;
                //if (toPay > disponibile) toPay=disponibile;
                Liquidazione["!assegnato"] = old_assegnato + toPay;
                totassegnato += toPay;
            }
            if (totassegnato == 0) {
                MessageBox.Show("Non è stato possibile generare nessun pagamento.");
                return;
            }

            foreach (DataRow Liquid in LiquidazioniView.Rows) {
                decimal assegnato = CfgFn.GetNoNullDecimal(Liquid["!assegnato"]);
                if (assegnato == 0) continue;
                // Calcolo il diponibile sull'impegno
                decimal disponibile = CfgFn.GetNoNullDecimal(Liquid["!disponibile"]);
                if (disponibile < assegnato) {
                    labelAttenzione.Visible = true;
                    break;
                }
            }

            string operazioni = "";
            foreach (DataRow Liquid in LiquidazioniView.Rows) {
                decimal assegnato = CfgFn.GetNoNullDecimal(Liquid["!assegnato"]);
                if (assegnato == 0) continue;
                operazioni += "Su " + Liquid["phase"] + " " + Liquid["ymov"] + "/" + Liquid["nmov"] + ":" +
                              " pagamento di " + assegnato.ToString("c");
                operazioni += "\r";
            }
            operazioni = QueryCreator.GetPrintable(operazioni);
            txtMessage.Text = operazioni;
            CondizioneErroreBloccante = false;

            /*MetaData MD= MetaData.GetMetaData(this,"invoicedetail");
			MD.DescribeColumns(DS.Tables["invoicedetail"],"wizardiva");
			Meta.myGetData.GetTemporaryValues(DS.Tables["invoicedetail"]);
			HelpForm.SetDataGrid(gridDetail1,DS.Tables["invoicedetail"]);*/
            //VisualizzaUPB();
        }

        decimal GetImponibileNear(decimal imponibiletest, decimal taxable, decimal number, double discount, double exchangerate) {
	        //var imponibileD = CfgFn.RoundValuta(rImponibile * quantita * tassocambio * (1 - scontoPerc));

            var  TotaleImponibileR = CfgFn.RoundValuta(Convert.ToDouble( taxable)*Convert.ToDouble(number)*(1 - discount)*exchangerate);
            var TotaleImponibile = Convert.ToDecimal(TotaleImponibileR);
            var imponibilecomplementare = Convert.ToDouble(taxable) - Convert.ToDouble(imponibiletest);
            var totale1 = Convert.ToDecimal(CfgFn.RoundValuta(Convert.ToDouble(imponibiletest)*Convert.ToDouble(number)*(1 - discount)*exchangerate));
            var totale2 = Convert.ToDecimal(CfgFn.RoundValuta(Convert.ToDouble(imponibilecomplementare)*Convert.ToDouble(number)*(1 - discount)*exchangerate));
            if (totale1 + totale2 == TotaleImponibile) return imponibiletest;
            var x = Convert.ToDouble(number)*(1 - discount)*exchangerate;
            decimal passo = 0;
            if (x <= 10) passo = 0.001M;
            if ((x > 10) && (x <= 100)) passo = 0.0001M;
            if ((x > 100) && (x <= 1000)) passo = 0.00001M;
            if (x > 1000) passo = 0.00001M;
            decimal cent = passo;
            while (cent <= 0.1M) {
                decimal imponibile_try = imponibiletest + cent;
                decimal imponibilecomplementare_try = taxable - imponibile_try;
                totale1 = Convert.ToDecimal(CfgFn.RoundValuta(Convert.ToDouble(imponibile_try)*Convert.ToDouble(number)*(1 - discount)*exchangerate));
                totale2 = Convert.ToDecimal(CfgFn.RoundValuta(Convert.ToDouble(imponibilecomplementare_try)*Convert.ToDouble(number)*(1 - discount)*exchangerate));
                if (totale1 + totale2 == TotaleImponibile) {
                    return imponibile_try;
                }
                imponibile_try = imponibiletest - cent;
                imponibilecomplementare_try = taxable - imponibile_try;
                totale1 = Convert.ToDecimal(CfgFn.RoundValuta(Convert.ToDouble(imponibile_try)*Convert.ToDouble(number)*(1 - discount)*exchangerate));
                totale2 = Convert.ToDecimal(CfgFn.RoundValuta(Convert.ToDouble(imponibilecomplementare_try)*Convert.ToDouble(number)*(1 - discount)*exchangerate));
                if (totale1 + totale2 == TotaleImponibile) {
                    return imponibile_try;
                }
                cent += passo;
            }
            return imponibiletest;
        }


        decimal CalcolaCoefficiente(decimal importoDaPagare, decimal importoMax, DataRow rowToSplit) {
            decimal epsilon = 0;
            if ((importoDaPagare != 0) && (importoMax != 0)) epsilon = importoDaPagare/importoMax;
            if (epsilon >= 1) return epsilon;

            int maxIter = 100;
            int niter = 1;
            decimal epsilon_min = epsilon - 0.01M;
            decimal epsilon_max = epsilon + 0.01M;
            decimal epsilon_med = (epsilon_min + epsilon_max)/2;
            decimal importoRicalcolato = RicalcolaTotaleDaContabilizzare(epsilon_med, rowToSplit);
            while (niter < maxIter && importoRicalcolato != importoDaPagare) {
                if (importoDaPagare - importoRicalcolato > 0) {
                    epsilon_min = epsilon_med;
                }
                else {
                    epsilon_max = epsilon_med;
                }
                epsilon_med = (epsilon_min + epsilon_max)/2;
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


        void RecalcDettagliSelezionati() {
            DataRow[] Selected = GetGridSelectedRows(gridDetails);
            int causale = CfgFn.GetNoNullInt32(cmbCausale.SelectedValue);
            decimal ImportoMax = CfgFn.GetNoNullDecimal(HelpForm.GetObjectFromString(typeof(decimal),txtTotSelezionato.Text, "x.y.c"));
            decimal ImportoDaPagare = CfgFn.GetNoNullDecimal(HelpForm.GetObjectFromString(typeof(decimal),txtDaPagare.Text, "x.y.c"));
            if (ImportoDaPagare == 0) {
                ImportoDaPagare = ImportoMax;
            }
            DataRow Mandate = DS.invoice.Rows[0];
            var tassocambio = CfgFn.GetNoNullDouble(Mandate["exchangerate"]);
            ClearOperationsToDo();
            // Rilegge i dettagli con l'importo originale nel dataset
            foreach (DataRow Det in Selected) {
                string filterinvoicedetail = QueryCreator.WHERE_COLNAME_CLAUSE(
                    Det, new string[] {"idinvkind", "yinv", "ninv", "rownum"}, DataRowVersion.Default, true);
                DataAccess.RUN_SELECT_INTO_TABLE(Conn, DS.Tables["invoicedetail"], null, filterinvoicedetail, null,
                    false);
            }

            if (ImportoMax == 0) return;

            if (ImportoDaPagare < ImportoMax) {
                if (rdbSplittaTutti.Checked) {
                    // Distribuisce la quota parziale da contabilizzare su tutti i dettagli
                    DataTable T = null;
                    decimal epsilon = CalcolaCoefficiente(ImportoDaPagare, ImportoMax, null);
                    if (RicalcolaTotaleDaContabilizzare(epsilon, null) != ImportoDaPagare) {
                        decimal cents = (RicalcolaTotaleDaContabilizzare(epsilon, null) - ImportoDaPagare);
                        T = AggiungiOSottraiCentADettagli(epsilon, ImportoDaPagare, cents);
                    }
                    foreach (DataRow Row in DS.invoicedetail.Select()) {
                        // Solo le righe selezionate
                        if (!DetailsToUpdate.Contains(Row["rownum"])) {
                            DetailsToUpdate.Add(Row["rownum"]);
                        }
                        DataRow[] IvaKind = DS.ivakind.Select(QHC.CmpEq("idivakind", Row["idivakind"]));
                        if (IvaKind.Length == 0) {
                            MessageBox.Show(this, "Non esiste la riga nell'anagrafica dei tipi IVA", "Errore");
                            return;
                        }
                        decimal imponibile = CfgFn.GetNoNullDecimal(Row["taxable"]);
                        decimal iva = CfgFn.GetNoNullDecimal(Row["tax"]);
                        decimal quantitaConfezioni = CfgFn.GetNoNullDecimal(Row["npackage"]);
                        decimal aliquota = CfgFn.GetNoNullDecimal(IvaKind[0]["rate"]);
                        var sconto = CfgFn.GetNoNullDouble(Row["discount"]);
                        // Ricalcolo l'imponibile unitario
                        decimal taxable = CfgFn.Round(CfgFn.GetNoNullDecimal(Row["taxable"])*epsilon, 5);
                        taxable = GetImponibileNear(taxable, imponibile, quantitaConfezioni, sconto, tassocambio);
                        

                        // Uso l'imponibile unitario per  calcolare l'iva totale
                        decimal tax = CfgFn.RoundValuta(CfgFn.GetNoNullDecimal(Row["tax"])*epsilon);
                        decimal unabatabilitypercentage = CfgFn.GetNoNullDecimal(IvaKind[0]["unabatabilitypercentage"]);
                        decimal unabatable = CfgFn.RoundValuta(tax*unabatabilitypercentage);
                        string filterdetail = QHC.CmpEq("rownum", Row["rownum"]);
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
                else {
                    //La quota parziale da contabilizzare viene raggiunta sommando i dettagli, e splittando l'ultimo
                    DataTable Info = new DataTable();
                    Info.Columns.Add("rownum", typeof(int));
                    Info.Columns.Add("total", typeof(decimal));
                    // Ciclo per riempire il datatable Info con il totale da contabilizzare su ogni dettaglio
                    foreach (DataRow Row in DS.invoicedetail.Select(null, "rownum"))
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
                            DataRow R = DS.invoicedetail.Select(filterrow, null)[0];
                            DataRow[] IvaKind1 = DS.ivakind.Select(QHC.CmpEq("idivakind", R["idivakind"]));
                            if (IvaKind1.Length == 0) {
                                MessageBox.Show(this, "Non esiste la riga nell'anagrafica dei tipi IVA", "Errore");
                                return;
                            }
                            decimal imponibile = CfgFn.GetNoNullDecimal(R["taxable"]);
                            decimal iva = CfgFn.GetNoNullDecimal(R["tax"]);
                            decimal quantitaConfezioni = CfgFn.GetNoNullDecimal(R["npackage"]);
                            decimal aliquota = CfgFn.GetNoNullDecimal(IvaKind1[0]["rate"]);
                            var sconto = CfgFn.GetNoNullDouble(R["discount"]);
                            // Splitto il dettaglio corrente in due, uno risulterà contabilizzato,l'altro no

                            decimal epsilon1 = CalcolaCoefficiente(oldsum, CfgFn.GetNoNullDecimal(Row["total"]), R);
                            // Ricalcolo l'imponibile unitario
                            decimal taxable = CfgFn.Round(CfgFn.GetNoNullDecimal(R["taxable"])*epsilon1, 5);
                            taxable = GetImponibileNear(taxable, imponibile, quantitaConfezioni, sconto, tassocambio);
                            // Uso l'imponibile unitario per  calcolare l'iva totale
                            decimal tax = CfgFn.RoundValuta(CfgFn.GetNoNullDecimal(R["tax"])*epsilon1);
                            decimal unabatabilitypercentage =
                                CfgFn.GetNoNullDecimal(IvaKind1[0]["unabatabilitypercentage"]);
                            decimal unabatable = CfgFn.RoundValuta(tax*unabatabilitypercentage);
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
                foreach (DataRow Row in DS.invoicedetail.Select()) {
                    // Solo le righe selezionate
                    if (!DetailsToUpdate.Contains(Row["rownum"])) {
                        DetailsToUpdate.Add(Row["rownum"]);
                    }
                }
            }
        }


        void ClearOperazionsToDo() {
            DS.expenseyear.Clear();
            DS.expenseclawback.Clear();
            DS.expense.Clear();
            DS.invoicedetail.Clear();
            DS.invoicedetail.Clear();
            txtMessage.Text = "";
            labelAttenzione.Visible = false;
            //.. etc.
        }

        private void txtDaPagare_Leave(object sender, System.EventArgs e) {
            RecalcOperationsToDo();
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
            //E_S["ycreation"]= esercizio;
            E_S["adate"] = DataCont;
            //E_S["fulfilled"]="N";
            //if (E_S.Table.Columns.Contains("autotaxflag"))E_S["autotaxflag"]="N";
            //if (E_S.Table.Columns.Contains("autoclawbackflag"))E_S["autoclawbackflag"]="N";
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

        void ViewAutomatismi(DataSet DS) {
            string spesa = null;
            string entrata = null;
            if (DS.Tables["expense"] != null) {
                DataTable Var = DS.Tables["expense"];
                spesa = QHS.FieldIn("idexp", Var.Select(), "idexp");
                entrata = QHS.FieldIn("idpayment", Var.Select(), "idexp");
            }

            Form F = ShowAutomatismi.Show(Meta, spesa, entrata, null, null);
            F.ShowDialog(this);
        }

        //-----------------------------------------------------------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------------------
        void GeneraRigaRecuperoSplitPayment_o_IvaEstera(DataRow Parent, object codice, decimal importo) {
            DataRow[] found =
                DS.expenseclawback.Select(QHC.AppAnd(QHC.CmpEq("idclawback", codice),
                    QHC.CmpEq("idexp", Parent["idexp"])));
            DataRow Recupero;
            if (found.Length > 0) {

                Recupero = found[0];
                if (Recupero.RowState != DataRowState.Added) return;
                if (CfgFn.GetNoNullDecimal(Recupero["amount"]) == importo) return;
            }
            else {
                MetaData MetaRec = MetaData.GetMetaData(this, "expenseclawback");
                MetaRec.SetDefaults(DS.expenseclawback);
                DS.expenseclawback.Columns["idclawback"].DefaultValue = codice;
                Recupero = MetaRec.Get_New_Row(Parent, DS.expenseclawback);
                DS.expenseclawback.Columns["idclawback"].DefaultValue = DBNull.Value;
            }

            Recupero["amount"] = importo;
            Recupero["!clawbackref"] = DS.clawback.Compute("MIN(clawbackref)",
                QHC.CmpEq("idclawback", Recupero["idclawback"]));
        }

        void GeneraOAzzeraRecuperoSplitPayment(DataRow Parent, decimal ImportoDaRecuperare) {
            if (DS.clawback.Rows.Count == 0) return;
            if (DS.invoice.Rows.Count == 0)
                return;
            DataRow Fattura = DS.invoice.Rows[0];
            bool intracom = false;
            if (Fattura["flagintracom"].ToString().ToUpper() != "N") intracom = true;
            int flag = CfgFn.GetNoNullInt32(Fattura["flagbit"]);
            if (intracom && (flag & 64) != 0) //Verrà generato il Recupero IVA Intra ed Extra-UE 
                return;
            object currIdInvKind = Fattura["idinvkind"];
            int nAcq = CfgFn.GetNoNullInt32(Conn.DO_SYS_CMD(
                "select count(*) from invoicekindregisterkind IIRK " +
                " join ivaregisterkind IRK on IRK.idivaregisterkind = IIRK.idivaregisterkind " +
                " where " +
                QHS.AppAnd(QHS.CmpEq("IIRK.idinvkind", currIdInvKind), QHS.CmpEq("registerclass", "A"),
                    QHS.CmpNe("flagactivity", 1))));

            bool isAcquistoCommerciale = nAcq > 0;
            string codeClawBack = isAcquistoCommerciale ? "16_SPLIT_PAYMENT_C" : "15_SPLIT_PAYMENT";

            DataRow[] RSplitPayment = DS.clawback.Select(QHC.CmpEq("clawbackref", codeClawBack));
            if (RSplitPayment.Length == 0) return;

            object codicerecupero = RSplitPayment[0]["idclawback"];
            if (codicerecupero == DBNull.Value) return;

            if (Fattura["flag_enable_split_payment"].ToString() == "N") return;

            // Calcolo importo IVA da contabilizzare
            if (ImportoDaRecuperare == 0) {
                AzzeraRigaRecupero(Parent, codicerecupero);
                return;
            }
            GeneraRigaRecuperoSplitPayment_o_IvaEstera(Parent, codicerecupero, ImportoDaRecuperare);

        }

        void GeneraOAzzeraRecuperoIvaEstera(DataRow Parent, decimal ImportoDaRecuperare) {
            if (DS.clawback.Rows.Count == 0) return;
            if (DS.invoice.Rows.Count == 0)
                return;
            DataRow Fattura = DS.invoice.Rows[0];
            bool intracom = false;
            if (Fattura["flagintracom"].ToString().ToUpper() != "N") intracom = true;
            if (!intracom) return;
            int flag = CfgFn.GetNoNullInt32(Fattura["flagbit"]);
            if ((flag & 64) == 0) //Recupero IVA Intra ed Extra-UE = N
                return;
            object currIdInvKind = Fattura["idinvkind"];
            int nAcq = CfgFn.GetNoNullInt32(Conn.DO_SYS_CMD(
                "select count(*) from invoicekindregisterkind IIRK " +
                " join ivaregisterkind IRK on IRK.idivaregisterkind = IIRK.idivaregisterkind " +
                " where " +
                QHS.AppAnd(QHS.CmpEq("IIRK.idinvkind", currIdInvKind), QHS.CmpEq("registerclass", "A"),
                    QHS.FieldIn("flagactivity", new object[] { 2, 3, 4 }))));//Comm. Promoscuo o qualsiasi

            bool isAcquistoCommerciale = nAcq > 0;
            int nIst = CfgFn.GetNoNullInt32(Conn.DO_SYS_CMD(
                "select count(*) from invoicekindregisterkind IIRK " +
                " join ivaregisterkind IRK on IRK.idivaregisterkind = IIRK.idivaregisterkind " +
                " where " +
                QHS.AppAnd(QHS.CmpEq("IIRK.idinvkind", currIdInvKind), QHS.CmpEq("registerclass", "A"),
                    QHS.CmpEq("flagactivity", 1))));//Ist

            bool isAcquistoIstituzionale = nIst > 0;

            string codeClawBack = isAcquistoCommerciale ? "IVAESTERA_COMM" : "IVAESTERA_IST";

            DataRow[] RSplitPayment = DS.clawback.Select(QHC.CmpEq("clawbackref", codeClawBack));
            if (RSplitPayment.Length == 0) return;

            object codicerecupero = RSplitPayment[0]["idclawback"];
            if (codicerecupero == DBNull.Value) return;


            // Calcolo importo IVA da contabilizzare
            if (ImportoDaRecuperare == 0) {
                AzzeraRigaRecupero(Parent, codicerecupero);
                return;
            }
            GeneraRigaRecuperoSplitPayment_o_IvaEstera(Parent, codicerecupero, ImportoDaRecuperare);

        }

        decimal GetIVADettagliFattura(DataRow[] SelectedRows) {
            if (DS.invoice.Rows.Count == 0)
                return 0;
            
            DataRow Fattura = DS.invoice.Rows[0];
            

            decimal imposta = 0;
            DataRow[] ToConsider = new DataRow[0];
            int CurrCausaleIva = GetCausaleIva();

            if (CurrCausaleIva == 3) return 0;

            foreach (DataRow R in SelectedRows) {
                if (R.RowState == DataRowState.Deleted) continue;
                decimal R_imposta = CfgFn.GetNoNullDecimal(R["tax"]);
                imposta += CfgFn.RoundValuta(R_imposta);
            }

            return imposta;

        }

        int GetCausaleIva() {
            int CurrCausaleIva = 0;
            CurrCausaleIva = CfgFn.GetNoNullInt32(cmbCausale.SelectedValue);
            return CurrCausaleIva;

        }

        void AzzeraRigaRecupero(DataRow Parent, object codice) {
            DataRow[] found =
                DS.expenseclawback.Select(QHC.AppAnd(QHC.CmpEq("idclawback", codice),
                    QHC.CmpEq("idexp", Parent["idexp"])));

            if (found.Length == 0) return;
            found[0].Delete();
        }

        //-----------------------------------------------------------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------------------
        bool doSave() {
            DS.expenseinvoice.Clear();
            //DS.invoicedetail.Clear();
            DS.expense.Clear();
            DS.expenseyear.Clear();
            DS.expenseclawback.Clear();
            DS.expenselast.Clear();

            int faseordine = CfgFn.GetNoNullInt32(Meta.GetSys("mandatephase"));
            int fasespesamax = CfgFn.GetNoNullInt32(Meta.GetSys("maxexpensephase"));
            int faseinizio = faseordine + 1;
            int fasefine = fasespesamax;

            MetaData Exp = MetaData.GetMetaData(this, "expense");
            MetaData ExpY = MetaData.GetMetaData(this, "expenseyear");
            MetaData ExpL = MetaData.GetMetaData(this, "expenselast");
            MetaData ExpInvoice = MetaData.GetMetaData(this, "expenseinvoice");
            Exp.SetDefaults(DS.expense);
            ExpY.SetDefaults(DS.expenseyear);
            ExpL.SetDefaults(DS.expenselast);
            ExpInvoice.SetDefaults(DS.expenseinvoice);

            DataRow[] SelectedRows = GetGridSelectedRows(gridDetails);

            DataTable Mov = DS.expense;
            DataTable ImpMov = DS.expenseyear;
            DataTable LastMov = DS.expenselast;
            DataRow Invoice = DS.invoice.Rows[0];
            int idreg = CfgFn.GetNoNullInt32(Invoice["idreg"]);
            DS.registry.Clear();
            Conn.RUN_SELECT_INTO_TABLE(DS.registry, null, QHS.CmpEq("idreg", idreg), null, true);
            object title = DS.registry.Rows[0]["title"];

            int currcausale = CfgFn.GetNoNullInt32(cmbCausale.SelectedValue);
            int esercizio = CfgFn.GetNoNullInt32(Meta.GetSys("esercizio"));

            MetaData.SetDefault(DS.expenseyear, "ayear", esercizio);

            bool avvisoDelegatoMostrato = false;


            foreach (DataRow Liquid in LiquidazioniView.Rows) {
                decimal assegnato = CfgFn.GetNoNullDecimal(Liquid["!assegnato"]);
                if (assegnato == 0) continue; //Non deve fare nulla per quel dettaglio

                string idparent = Liquid["idexp"].ToString();
                MetaData.SetDefault(DS.expense, "parentidexp", idparent);

                object idfinSelected = Liquid["idfin"];
                object idupb = Liquid["idupb"];
             
                string filterupb = QHC.CmpEq("idupb", idupb);
                if (DS.upb.Select(filterupb).Length == 0) {
                    DataAccess.RUN_SELECT_INTO_TABLE(Conn, DS.upb, null, filterupb, null, true);
                }
                DataRow UPB = DS.upb.Select(filterupb)[0];
                object idmanagerSelected = UPB["idman"];

                //DataRow ParentR= FindParentRow(Mov, R, idfield_name);
                DataRow ParentR = null;
                decimal amount = assegnato;
                object curridmanager = idmanagerSelected;
                string currdescr = Invoice["description"].ToString();

                for (int faseCorrente = faseinizio; faseCorrente <= fasefine; faseCorrente++) {
                    Mov.Columns["nphase"].DefaultValue = faseCorrente;

                    DataRow NewSpesaRow = Exp.Get_New_Row(ParentR, Mov);
                    ParentR = NewSpesaRow;

                    FillMovimento(NewSpesaRow, amount, curridmanager, idreg, currdescr);

                    NewSpesaRow["doc"] = Invoice["doc"].ToString();
                    NewSpesaRow["docdate"] = Invoice["docdate"];

                    if (faseCorrente == fasespesamax) {
                        //Aggiunge la cont. del documento iva
                        //Aggiunge la riga in expenseinvoice
                        DataRow ExpManRow = ExpInvoice.Get_New_Row(NewSpesaRow, DS.expenseinvoice);
                        ExpManRow["movkind"] = currcausale;
                        ExpManRow["idinvkind"] = Invoice["idinvkind"];
                        ExpManRow["yinv"] = Invoice["yinv"];
                        ExpManRow["ninv"] = Invoice["ninv"];
                    }

                    NewSpesaRow["nphase"] = faseCorrente;

                    if (faseCorrente == fasespesamax) {
                        object codicecreddeb = NewSpesaRow["idreg"];
                        DataRow ModPagam = CfgFn.ModalitaPagamentoDefault(Meta.Conn, codicecreddeb);
                        if (ModPagam == null) {
                            MessageBox.Show(
                                "E' necessario che sia definita almeno una modalità di pagamento per il fornitore " +
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
                        NewLastMov["iban"] = ModPagam["iban"];
                        NewLastMov["paymentdescr"] = ModPagam["paymentdescr"];
                        NewLastMov["iddeputy"] = ModPagam["iddeputy"];
                        NewLastMov["refexternaldoc"] = ModPagam["refexternaldoc"];
                        NewLastMov["biccode"] = ModPagam["biccode"];
                        NewLastMov["extracode"] = ModPagam["extracode"];
                        NewLastMov["idchargehandling"] = ModPagam["idchargehandling"];
                        if (LeggiFlagEsenteBancaPredefinita()) {
                            int flag = CfgFn.GetNoNullInt32(NewLastMov["flag"]);
                            int flag_exemption = (CfgFn.GetNoNullInt32(NewLastMov["flag"]) & 0xF7) |
                                                 ((CfgFn.GetNoNullInt32(ModPagam["flag"]) & 1) << 3);
                            NewLastMov["flag"] = flag_exemption;
                        }
                        object idpaymethod = ModPagam["idpaymethod"];
                        string filterpaymethod = QHS.CmpEq("idpaymethod", idpaymethod);

                        DataTable TPaymethod = Conn.RUN_SELECT("paymethod", "*", null, filterpaymethod, null, true);

                        if ((TPaymethod != null) && (TPaymethod.Rows.Count > 0)) {
                            object paymethod_allowdeputy = TPaymethod.Rows[0]["allowdeputy"];
                            NewLastMov["paymethod_allowdeputy"] = paymethod_allowdeputy;

                            int paymethod_flag = CfgFn.GetNoNullInt32(TPaymethod.Rows[0]["flag"]);
                            int flag = CfgFn.GetNoNullInt32(Invoice["requested_doc"]) & 7;
                            // lo spostiamo di 15 posizioni a sinistra
                            flag = flag << 15;
                            NewLastMov["paymethod_flag"] = flag | (paymethod_flag & ~0x38000);

                        }

                        if (NewLastMov["iddeputy"] != DBNull.Value && !avvisoDelegatoMostrato) {
                            avvisoDelegatoMostrato = true;
                            string titleDelegato = Conn.readValue("registry", q.eq("idreg", NewLastMov["iddeputy"]), "title")?.ToString()??"";
                            MessageBox.Show(
                                "Attenzione, l'anagrafica considerata è associata ad un delegato come modalità di pagamento. Il pagamento sarà pertanto effettuato al delegato "
                                +titleDelegato+" sull'iban "+NewLastMov["iban"].ToString(),
                                "Avviso");
                        }
                        // aggiunge le informazioni sul numero bolletta se sono state digitate dall'utente
                        int nBill = CfgFn.GetNoNullInt32(HelpForm.GetObjectFromString(typeof(int),
                            txtBolletta.Text.ToString(), "x"));
                        if (nBill > 0) {
                            NewLastMov["nbill"] = nBill;
                            int flag = CfgFn.GetNoNullInt32(NewLastMov["flag"]);
                            flag = flag | 1;
                            NewLastMov["flag"] = flag;
                        }

                        if (SubEntity_chkAutomRecuperi.Checked) {
                            foreach (DataRow RD in DS.expenselast.Rows) {
                                int flag = CfgFn.GetNoNullInt32(NewLastMov["flag"]);
                                flag = flag | 4;
                                NewLastMov["flag"] = flag;
                            }
                        }

                        EP_functions EP = new EP_functions(Meta.Dispatcher);

                        object idaccmotive = DBNull.Value;
                        object idacc = DBNull.Value;

                        idaccmotive = Invoice["idaccmotivedebit_crg"];
                        if (idaccmotive == DBNull.Value) idaccmotive = Invoice["idaccmotivedebit"];

                        if (EP.attivo) {
                            idacc = EP.GetSupplierAccountForRegistry(idaccmotive, NewSpesaRow["idreg"]);
                        }
                        if (idacc != DBNull.Value) {
                            if (DS.account.Select(QHC.CmpEq("idacc", idacc)).Length == 0) {
                                DS.account.Clear();
                                Meta.Conn.RUN_SELECT_INTO_TABLE(DS.account, null, QHS.CmpEq("idacc", idacc), null, false);
                                if (DS.account.Rows.Count > 0) {
                                    DataRow Acc = DS.account.Rows[0];
                                }
                            }
                            NewLastMov["idaccdebit"] = idacc;
                        }



                    }

                    DataRow NewImpMov = ImpMov.NewRow();

                    FillImputazioneMovimento(NewImpMov, amount, idfinSelected, idupb);
                    NewImpMov["idexp"] = NewSpesaRow["idexp"];
                    NewImpMov["ayear"] = esercizio;

                    ImpMov.Rows.Add(NewImpMov);

                    if (faseCorrente == fasespesamax) {
                        //Determino i dettagli fattura collegati alla liquidazione corrente
                        //Effettua i collegamenti con i dettagli
                        //Trova i dettagli collegati alla liquidazione tra quelli selezionati
                        DataRow[] Details = FiltraRows(SelectedRows, idparent, currcausale);
                        foreach (DataRow RD in Details) {
                            switch (currcausale) {
                                case 1:
                                    RD["idexp_taxable"] = NewSpesaRow["idexp"];
                                    RD["idexp_iva"] = NewSpesaRow["idexp"];
                                    break;
                                case 3:
                                    RD["idexp_taxable"] = NewSpesaRow["idexp"];
                                    break;
                                case 2:
                                    RD["idexp_iva"] = NewSpesaRow["idexp"];
                                    break;
                            }
                        }

                        decimal ImportoDaRecuperare = GetIVADettagliFattura(Details);
                        GeneraOAzzeraRecuperoSplitPayment(NewSpesaRow, ImportoDaRecuperare);
                        GeneraOAzzeraRecuperoIvaEstera(NewSpesaRow, ImportoDaRecuperare);
                    }


                }

            }


            DataSet DSP = DS.Copy();
            GestioneAutomatismi ga = new GestioneAutomatismi(this, Meta.Conn, Meta.Dispatcher,
                DSP, fasespesamax, fasespesamax, "expense", true);
            string newcomputesorting = Meta.Conn.DO_READ_VALUE("siopekind",
            QHS.AppAnd(QHS.CmpEq("codesorkind_siopespese", Meta.GetSys("codesorkind_siopespese")),
                        QHS.CmpEq("ayear", CfgFn.GetNoNullInt32(Meta.GetSys("esercizio")))
                ),
            "newcomputesorting")?.ToString();

            if (newcomputesorting == "S") {
                ManageClassificazioni = new GestioneClassificazioni(Meta, null, null, null, null, null, null, null, null);
                ManageClassificazioni.ClassificaTramiteClassDocumento(ga.DSP, DS);
				ManageClassificazioni.completaClassificazioniSiope(DS.expensesorted, ga.DSP);
				//Meta.FreshForm();
			}

            ga.GeneraClassificazioniAutomatiche(ga.DSP, true);
            //ga.GeneraClassificazioniIndirette(ga.DSP, true);
            bool res = ga.GeneraAutomatismiAfterPost(true);
            if (!res) {
                MessageBox.Show(this,
                    @"Si è verificato un errore o si è deciso di non salvare! L'operazione sarà terminata");
                return false;
            }
            res = ga.doPost(Meta.Dispatcher);
            if (res) ViewAutomatismi(ga.DSP);

            if (!res) {
                return false;
            }

            DS.AcceptChanges();
            DS.registry.Clear();
            return true;

        }

        DataRow[] FiltraRows(DataRow[] Rows, string filter, int currcausale) {
            DataRow[] RR = new DataRow[Rows.Length];
            if (Rows.Length == 0) {
                return new DataRow[0];
            }
            DataTable T = DS.invoicedetail;
            // Dettagli selezionati associati all'idexp parent
            // In base alla contabilizzazione
            string filtercontab = null;
            switch (currcausale) {
                case 1:
                    filtercontab =
                        QHC.DoPar(QHC.AppAnd(QHC.CmpEq("idexp_taxable", filter), QHC.CmpEq("idexp_iva", filter)));
                    break;
                case 3:
                    //filtercontab="((idexp_taxable = "+QueryCreator.quotedstrvalue(filter,false)+") AND (idexp_iva is null))" ;
                    filtercontab = QHC.DoPar(QHC.CmpEq("idexp_taxable", filter));
                    break;
                case 2:
                    //filtercontab="((idexp_iva = "+QueryCreator.quotedstrvalue(filter,false)+") AND (idexp_taxable is null))" ;
                    filtercontab = QHC.DoPar(QHC.CmpEq("idexp_iva", filter));
                    break;
            }
            DataRow[] TFiltered = T.Select(filtercontab);
            int N = 0;
            foreach (DataRow R in TFiltered) {
                foreach (DataRow R2 in Rows) {
                    string filterR = QueryCreator.WHERE_COLNAME_CLAUSE
                        (R, new string[] {"idinvkind", "yinv", "ninv", "rownum"}, DataRowVersion.Default, true);
                    string filterR2 = QueryCreator.WHERE_COLNAME_CLAUSE
                        (R2, new string[] {"idinvkind", "yinv", "ninv", "rownum"}, DataRowVersion.Default, true);
                    if (filterR2.Equals(filterR)) {
                        RR[N++] = R;
                    }
                }

            }
            DataRow[] result = new DataRow[N];
            for (int i = 0; i < N; i++) result[i] = RR[i];
            return result;
        }

        private bool LeggiFlagEsenteBancaPredefinita() {
            DataTable tTreasurer = Meta.Conn.RUN_SELECT("treasurer", "*", null,
                QHS.AppAnd(QHS.CmpEq("flagdefault", "S"), QHS.BitSet("flag", 1)), null, false);
            if (tTreasurer.Rows.Count == 0) return false;
            else
                return true;
        }

        decimal RicalcolaTotaleDaContabilizzare(decimal proporzione, DataRow rowToSplit) {
            if (cmbCausale.SelectedValue == null) return 0;
            int causale = CfgFn.GetNoNullInt32(cmbCausale.SelectedValue);
            decimal totiva = 0;
            decimal totimpo = 0;
            decimal total = 0;
            DataRow Invoice = DS.invoice.Rows[0];
            var tassocambio = CfgFn.GetNoNullDouble(Invoice["exchangerate"]);
            if (rowToSplit == null) {
                DataRow[] Selected = GetGridSelectedRows(gridDetails);

                foreach (DataRow Row in Selected) {
                    DataRow[] IvaKind = DS.ivakind.Select(QHC.CmpEq("idivakind", Row["idivakind"]));
                    if (IvaKind.Length == 0) {
                        MessageBox.Show(this,
                            "Attenzione nell'anagrafica dei tipi IVA è assente il tipo IVA selezionato nel dettaglio",
                            "Errore");
                        return 0;
                    }
                    decimal imponibile = CfgFn.GetNoNullDecimal(Row["taxable"]);
                    decimal iva = CfgFn.GetNoNullDecimal(Row["tax"]);
                    decimal quantitaConfezioni = CfgFn.GetNoNullDecimal(Row["npackage"]);
                    decimal aliquota = CfgFn.GetNoNullDecimal(IvaKind[0]["rate"]);
                    var sconto = CfgFn.GetNoNullDouble(Row["discount"]);
                    // Ricalcolo l'imponibile unitario
                    decimal taxable = CfgFn.Round(CfgFn.GetNoNullDecimal(Row["taxable"])*proporzione, 5);
                    taxable = GetImponibileNear(taxable, imponibile, quantitaConfezioni, sconto, tassocambio);
                    // Uso l'imponibile unitario per  calcolare l'iva totale e l'iva indetraibile
                    decimal taxabletot = Convert.ToDecimal(CfgFn.RoundValuta(Convert.ToDouble(taxable)*Convert.ToDouble(quantitaConfezioni)*(1 - sconto)*tassocambio));
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
                DataRow[] IvaKindSplit = DS.ivakind.Select(QHC.CmpEq("idivakind", rowToSplit["idivakind"]));
                if (IvaKindSplit.Length == 0) {
                    MessageBox.Show(this,
                        "Attenzione nell'anagrafica dei tipi IVA è assente il tipo IVA selezionato nel dettaglio",
                        "Errore");
                    return 0;
                }
                decimal imponibile = CfgFn.GetNoNullDecimal(rowToSplit["taxable"]);
                decimal iva = CfgFn.GetNoNullDecimal(rowToSplit["tax"]);
                decimal quantitaConfezioni = CfgFn.GetNoNullDecimal(rowToSplit["npackage"]);
                decimal aliquota = CfgFn.GetNoNullDecimal(IvaKindSplit[0]["rate"]);
                var sconto = CfgFn.GetNoNullDouble(rowToSplit["discount"]);

                // Ricalcolo l'imponibile unitario
                decimal taxable = CfgFn.Round(CfgFn.GetNoNullDecimal(rowToSplit["taxable"])*proporzione, 5);
                taxable = GetImponibileNear(taxable, imponibile, quantitaConfezioni, sconto, tassocambio);
                // Uso l'imponibile unitario per  calcolare l'iva totale e l'iva indetraibile
                decimal taxabletot = CfgFn.GetNoNullDecimal(CfgFn.RoundValuta(Convert.ToDouble(taxable)*Convert.ToDouble(quantitaConfezioni)*(1 - sconto)*tassocambio));
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


        private void txtPerc_Leave(object sender, System.EventArgs e) {
            if (checkPercentuale(sender)) {
                decimal ImportoMax = CfgFn.GetNoNullDecimal(
                    HelpForm.GetObjectFromString(typeof(decimal),
                        txtTotSelezionato.Text, "x.y.c"));
                // calcola l'importo in base alla percentuale
                decimal perc =
                    CfgFn.GetNoNullDecimal(HelpForm.GetObjectFromString(typeof(Decimal), txtPerc.Text, "x.y.c"));
                decimal importoDaPagare = CfgFn.Round(ImportoMax*perc/100, 2);
                //RicalcolaTotaleDaContabilizzare(perc/100);
                txtDaPagare.Text = importoDaPagare.ToString("c");
                txtPerc.Text = HelpForm.StringValue(perc, "x.y.fixed.4...1");

                txtDaPagare_Leave(txtDaPagare, null);
            }
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
                decimal quantitaConfezioni1 = CfgFn.GetNoNullDecimal(Row1["npackage"]);
                string filter1 = QHS.CmpEq("idivakind", Row1["idivakind"]);
                decimal aliquota1 = CfgFn.GetNoNullDecimal(Conn.DO_READ_VALUE("ivakind", filter1, "rate"));
                var sconto1 = CfgFn.GetNoNullDouble(Row1["discount"]);
                DataRow Invoice1 = DS.invoice.Rows[0]; //Row1.GetParentRow("invoiceinvoicedetail");
                var tassocambio1 = CfgFn.GetNoNullDouble(Invoice1["exchangerate"]);
                decimal taxable = CfgFn.Round(CfgFn.GetNoNullDecimal(Row1["taxable"]), 5);
                decimal taxabletotal = Convert.ToDecimal(CfgFn.RoundValuta(Convert.ToDouble(taxable)*CfgFn.GetNoNullDouble(quantitaConfezioni1)*(1 - sconto1)*tassocambio1));
                // Ricalcolo l'imponibile unitario
                decimal taxable1 = CfgFn.Round(CfgFn.GetNoNullDecimal(Row1["taxable"])*proporzione, 5);
                decimal taxable_recalc = GetImponibileNear(taxable1, imponibile1, quantitaConfezioni1, sconto1, tassocambio1);
                // Ricalcolo l'iva
                decimal taxtotal = CfgFn.RoundValuta(CfgFn.GetNoNullDecimal(Row1["tax"]));
                decimal tax_recalctotal = CfgFn.RoundValuta(CfgFn.GetNoNullDecimal(Row1["tax"])*proporzione);
                decimal taxable_recalctotal =Convert.ToDecimal( CfgFn.RoundValuta(Convert.ToDouble(taxable_recalc)*Convert.ToDouble(quantitaConfezioni1)*(1 - sconto1)*tassocambio1));
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
                    decimal quantitaConfezioni = CfgFn.GetNoNullDecimal(Row["npackage"]);
                    string filter = QHS.CmpEq("idivakind", Row["idivakind"]);
                    decimal aliquota = CfgFn.GetNoNullDecimal(Conn.DO_READ_VALUE("ivakind", filter, "rate"));
                    var sconto = CfgFn.GetNoNullDouble(Row["discount"]);
                    decimal percindeduc =
                        CfgFn.GetNoNullDecimal(Conn.DO_READ_VALUE("ivakind", filter, "unabatabilitypercentage"));
                    DataRow Invoice = DS.invoice.Rows[0]; //Row.GetParentRow("invoiceinvoicedetail");
                    var tassocambio = CfgFn.GetNoNullDouble(Invoice["exchangerate"]);
                    decimal taxable = CfgFn.Round(CfgFn.GetNoNullDecimal(Row["taxable"]), 5);
                    // Ricalcolo l'imponibile unitario
                    decimal taxable_recalc = CfgFn.Round(CfgFn.GetNoNullDecimal(Row["taxable"])*proporzione, 5);
                    taxable_recalc = GetImponibileNear(taxable_recalc, imponibile, quantitaConfezioni, sconto,tassocambio);
                    // Uso l'imponibile unitario per  calcolare l'iva totale e l'iva indetraibile
                    decimal taxabletotal = Convert.ToDecimal(CfgFn.RoundValuta(Convert.ToDouble(taxable)*Convert.ToDouble(quantitaConfezioni)*(1 - sconto)*tassocambio));
                    decimal taxtotal = CfgFn.RoundValuta(CfgFn.GetNoNullDecimal(Row["tax"]));
                    decimal tax_recalc = CfgFn.RoundValuta(CfgFn.GetNoNullDecimal(Row["tax"])*proporzione);
                    decimal taxabletot_recalc = Convert.ToDecimal( CfgFn.RoundValuta(Convert.ToDouble(taxable_recalc)*Convert.ToDouble(quantitaConfezioni)*(1 - sconto)*tassocambio));
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
                    decimal unabatable = CfgFn.RoundValuta(taxtotal*percindeduc);

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

        void InsertNewDetail(DataRow Row, decimal taxable, decimal tax, decimal percindeduc) {
            // Creo una nuova riga con gli importi residui (vedere gli arrotondamenti)
            MetaData metaDT = MetaData.GetMetaData(this, "invoicedetail");
            metaDT.SetDefaults(DS.invoicedetail);
            decimal taxableResiduo = CfgFn.GetNoNullDecimal(Row["taxable"]) - taxable;
            decimal taxResiduo = CfgFn.GetNoNullDecimal(Row["tax"]) - tax;
            decimal unabatableResiduo = CfgFn.RoundValuta(taxResiduo*percindeduc);
            // Creazione di un nuovo dettaglio
            DataRow rDT = metaDT.Get_New_Row(DS.invoice.Rows[0], DS.invoicedetail);
            rDT["idgroup"] = Row["idgroup"];
            rDT["idivakind"] = Row["idivakind"];
            rDT["taxable"] = taxableResiduo;
            rDT["tax"] = taxResiduo;
            rDT["unabatable"] = unabatableResiduo;
            rDT["idupb"] = Row["idupb"];
            rDT["number"] = CfgFn.GetNoNullDecimal(Row["number"]);
            rDT["npackage"] = CfgFn.GetNoNullDecimal(Row["npackage"]);
            rDT["idlist"] = Row["idlist"];
            rDT["idunit"] = Row["idunit"];
            rDT["idpackage"] = Row["idpackage"];
            rDT["unitsforpackage"] = Row["unitsforpackage"];
            rDT["detaildescription"] = Row["detaildescription"].ToString();
            rDT["competencystart"] = Row["competencystart"];
            rDT["competencystop"] = Row["competencystop"];
            rDT["annotations"] = Row["annotations"];
            rDT["discount"] = Row["discount"];
            rDT["idmankind"] = Row["idmankind"];
            rDT["manrownum"] = Row["manrownum"];
            rDT["nman"] = Row["nman"];
            rDT["yman"] = Row["yman"];
            rDT["idexp_taxable"] = Row["idexp_taxable"]; // contabilizzaione imponibile già effettuata
            rDT["idexp_iva"] = Row["idexp_iva"]; // contabilizzaione iva già effettuata
            rDT["idaccmotive"] = Row["idaccmotive"];
            rDT["idsor1"] = Row["idsor1"];
            rDT["idsor2"] = Row["idsor2"];
            rDT["idsor3"] = Row["idsor3"];
            rDT["idcostpartition"] = Row["idcostpartition"];
            rDT["idpccdebitstatus"] = Row["idpccdebitstatus"];
            rDT["idpccdebitmotive"] = Row["idpccdebitmotive"];
            rDT["expensekind"] = Row["expensekind"];

            rDT["idintrastatcode"] = Row["idintrastatcode"];
            rDT["idintrastatmeasure"] = Row["idintrastatmeasure"];
            rDT["weight"] = Row["weight"];
            rDT["va3type"] = Row["va3type"];
            rDT["flag"] = Row["flag"];
            rDT["intrastatoperationkind"] = Row["intrastatoperationkind"];
            rDT["intra12operationkind"] = Row["intra12operationkind"];
            rDT["exception12"] = Row["exception12"];
            rDT["move12"] = Row["move12"];
            rDT["idupb_iva"] = Row["idupb_iva"];
            rDT["idintrastatservice"] = Row["idintrastatservice"];
            rDT["idintrastatsupplymethod"] = Row["idintrastatsupplymethod"];
            rDT["rounding"] = Row["rounding"];
            rDT["idepexp"] = Row["idepexp"];
            rDT["idepacc"] = Row["idepacc"];
            rDT["idsor_siope"] = Row["idsor_siope"];


            Conn.RUN_SELECT_INTO_TABLE(DS.invoicedetaildeferred, null,
                QHS.MCmp(Row, "idinvkind", "yinv", "ninv", "rownum"), null, false);
            DataRow[] def = DS.invoicedetaildeferred.Select(QHC.MCmp(Row, "idinvkind", "yinv", "ninv", "rownum"));
            foreach (DataRow rDef in def) {
                DataRow newDef = DS.invoicedetaildeferred.NewRow();
                foreach (DataColumn c in DS.invoicedetaildeferred.Columns) {
                    newDef[c] = rDef[c];
                }
                newDef["rownum"] = rDT["rownum"];
                newDef["ivatotalpayed"] = rDT["tax"];
                newDef["taxable"] = rDT["taxable"];

                rDef["ivatotalpayed"] = tax;
                rDef["taxable"] = taxable;

                DS.invoicedetaildeferred.Rows.Add(newDef);
            }



        }

        void ClearOperationsToDo() {
            DS.expenseinvoice.Clear();
            DS.expenseyear.Clear();
            DS.expenselast.Clear();
            DS.expense.Clear();
            DS.expenseclawback.Clear();
            DS.invoicedetail.Clear();
            DS.invoicedetaildeferred.Clear();
            DetailsToUpdate.Clear();
        }

        private void rdbSplittaTutti_CheckedChanged(object sender, EventArgs e) {
            if (rdbSplittaTutti.Checked) RecalcOperationsToDo();
        }

        private void rdbSplittaUno_CheckedChanged(object sender, EventArgs e) {
            if (rdbSplittaUno.Checked) RecalcOperationsToDo();
        }
        
        private void FrmWizardInvoiceDetail_FormClosing(object sender, FormClosingEventArgs e) {
            this.ActiveControl = null;
        }
    }
}
