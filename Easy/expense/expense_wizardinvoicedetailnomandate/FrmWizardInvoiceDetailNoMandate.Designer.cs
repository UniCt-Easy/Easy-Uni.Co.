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

namespace expense_wizardinvoicedetailnomandate
{
    partial class FrmWizardInvoiceDetailNoMandate
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmWizardInvoiceDetailNoMandate));
            this.DS = new expense_wizardinvoicedetailnomandate.dsmeta();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.tabControl1 = new Crownwood.Magic.Controls.TabControl();
            this.tabController = new Crownwood.Magic.Controls.TabControl();
            this.tabIntro = new Crownwood.Magic.Controls.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.tabSetDetail = new Crownwood.Magic.Controls.TabPage();
            this.chk_Enable_Split_Payment = new System.Windows.Forms.CheckBox();
            this.cmbTipoFattura = new System.Windows.Forms.ComboBox();
            this.txtDescrFattura = new System.Windows.Forms.TextBox();
            this.labDescrFattura = new System.Windows.Forms.Label();
            this.txtFornitore = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
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
            this.tabSelMov = new Crownwood.Magic.Controls.TabPage();
            this.gboxSelMov = new System.Windows.Forms.GroupBox();
            this.lblWarningMandate = new System.Windows.Forms.Label();
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
            this.chkAutomRecuperi = new System.Windows.Forms.CheckBox();
            this.grpInfoOpzionali = new System.Windows.Forms.GroupBox();
            this.gboxBolletta = new System.Windows.Forms.GroupBox();
            this.txtBolletta = new System.Windows.Forms.TextBox();
            this.btnBolletta = new System.Windows.Forms.Button();
            this.gboxBilToCreate = new System.Windows.Forms.GroupBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtCodeBilSelected = new System.Windows.Forms.TextBox();
            this.txtDenomBilSelected = new System.Windows.Forms.TextBox();
            this.labMsgTODO2 = new System.Windows.Forms.Label();
            this.labMsgTODO1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.tabController.SuspendLayout();
            this.tabIntro.SuspendLayout();
            this.tabSetDetail.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridDetails)).BeginInit();
            this.tabSplit.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tabSelMov.SuspendLayout();
            this.gboxSelMov.SuspendLayout();
            this.gboxUPB.SuspendLayout();
            this.gboxMovimento.SuspendLayout();
            this.groupBox17.SuspendLayout();
            this.gboxBilAnnuale.SuspendLayout();
            this.groupBox20.SuspendLayout();
            this.groupBox18.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabConfirm.SuspendLayout();
            this.grpInfoOpzionali.SuspendLayout();
            this.gboxBolletta.SuspendLayout();
            this.gboxBilToCreate.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.EnforceConstraints = false;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(743, 516);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 19;
            this.btnCancel.Tag = "maincancel";
            this.btnCancel.Text = "Cancel";
            // 
            // btnNext
            // 
            this.btnNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNext.Location = new System.Drawing.Point(621, 516);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(88, 23);
            this.btnNext.TabIndex = 18;
            this.btnNext.Text = "Avanti >";
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnBack
            // 
            this.btnBack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBack.Location = new System.Drawing.Point(530, 517);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(80, 23);
            this.btnBack.TabIndex = 17;
            this.btnBack.Text = "< Indietro";
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.IDEPixelArea = true;
            this.tabControl1.Location = new System.Drawing.Point(635, 486);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.Size = new System.Drawing.Size(200, 100);
            this.tabControl1.TabIndex = 8;
            // 
            // tabController
            // 
            this.tabController.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabController.IDEPixelArea = true;
            this.tabController.Location = new System.Drawing.Point(0, 0);
            this.tabController.Name = "tabController";
            this.tabController.SelectedIndex = 4;
            this.tabController.SelectedTab = this.tabConfirm;
            this.tabController.Size = new System.Drawing.Size(830, 508);
            this.tabController.TabIndex = 20;
            this.tabController.TabPages.AddRange(new Crownwood.Magic.Controls.TabPage[] {
            this.tabIntro,
            this.tabSetDetail,
            this.tabSplit,
            this.tabSelMov,
            this.tabConfirm});
            this.tabController.SelectionChanged += new System.EventHandler(this.tabController_SelectionChanged);
            // 
            // tabIntro
            // 
            this.tabIntro.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabIntro.Controls.Add(this.label1);
            this.tabIntro.Location = new System.Drawing.Point(0, 0);
            this.tabIntro.Name = "tabIntro";
            this.tabIntro.Selected = false;
            this.tabIntro.Size = new System.Drawing.Size(830, 483);
            this.tabIntro.TabIndex = 3;
            this.tabIntro.Title = "Pagina 1 di 5";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(723, 105);
            this.label1.TabIndex = 0;
            this.label1.Text = resources.GetString("label1.Text");
            // 
            // tabSetDetail
            // 
            this.tabSetDetail.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabSetDetail.Controls.Add(this.chk_Enable_Split_Payment);
            this.tabSetDetail.Controls.Add(this.cmbTipoFattura);
            this.tabSetDetail.Controls.Add(this.txtDescrFattura);
            this.tabSetDetail.Controls.Add(this.labDescrFattura);
            this.tabSetDetail.Controls.Add(this.txtFornitore);
            this.tabSetDetail.Controls.Add(this.label6);
            this.tabSetDetail.Controls.Add(this.btnSelectAllDetail);
            this.tabSetDetail.Controls.Add(this.label18);
            this.tabSetDetail.Controls.Add(this.groupBox2);
            this.tabSetDetail.Controls.Add(this.gridDetails);
            this.tabSetDetail.Controls.Add(this.cmbCausale);
            this.tabSetDetail.Controls.Add(this.labelCausale);
            this.tabSetDetail.Controls.Add(this.btnDocumento);
            this.tabSetDetail.Controls.Add(this.label7);
            this.tabSetDetail.Controls.Add(this.txtNumDoc);
            this.tabSetDetail.Controls.Add(this.label10);
            this.tabSetDetail.Controls.Add(this.txtEsercDoc);
            this.tabSetDetail.Location = new System.Drawing.Point(0, 0);
            this.tabSetDetail.Name = "tabSetDetail";
            this.tabSetDetail.Selected = false;
            this.tabSetDetail.Size = new System.Drawing.Size(830, 483);
            this.tabSetDetail.TabIndex = 4;
            this.tabSetDetail.Title = "Pagina 2 di 5";
            // 
            // chk_Enable_Split_Payment
            // 
            this.chk_Enable_Split_Payment.Enabled = false;
            this.chk_Enable_Split_Payment.Location = new System.Drawing.Point(513, 9);
            this.chk_Enable_Split_Payment.Name = "chk_Enable_Split_Payment";
            this.chk_Enable_Split_Payment.Size = new System.Drawing.Size(181, 22);
            this.chk_Enable_Split_Payment.TabIndex = 145;
            this.chk_Enable_Split_Payment.Tag = " ";
            this.chk_Enable_Split_Payment.Text = "Crea Recupero Split Payment";
            // 
            // cmbTipoFattura
            // 
            this.cmbTipoFattura.DataSource = this.DS.invoicekind;
            this.cmbTipoFattura.DisplayMember = "description";
            this.cmbTipoFattura.Location = new System.Drawing.Point(121, 4);
            this.cmbTipoFattura.Name = "cmbTipoFattura";
            this.cmbTipoFattura.Size = new System.Drawing.Size(256, 23);
            this.cmbTipoFattura.TabIndex = 133;
            this.cmbTipoFattura.ValueMember = "idinvkind";
            this.cmbTipoFattura.SelectedIndexChanged += new System.EventHandler(this.cmbTipoFattura_SelectedIndexChanged);
            // 
            // txtDescrFattura
            // 
            this.txtDescrFattura.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescrFattura.Location = new System.Drawing.Point(97, 84);
            this.txtDescrFattura.Multiline = true;
            this.txtDescrFattura.Name = "txtDescrFattura";
            this.txtDescrFattura.ReadOnly = true;
            this.txtDescrFattura.Size = new System.Drawing.Size(724, 40);
            this.txtDescrFattura.TabIndex = 132;
            // 
            // labDescrFattura
            // 
            this.labDescrFattura.Location = new System.Drawing.Point(9, 84);
            this.labDescrFattura.Name = "labDescrFattura";
            this.labDescrFattura.Size = new System.Drawing.Size(80, 16);
            this.labDescrFattura.TabIndex = 131;
            this.labDescrFattura.Text = "Descrizione";
            this.labDescrFattura.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtFornitore
            // 
            this.txtFornitore.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFornitore.Location = new System.Drawing.Point(97, 52);
            this.txtFornitore.Name = "txtFornitore";
            this.txtFornitore.ReadOnly = true;
            this.txtFornitore.Size = new System.Drawing.Size(724, 23);
            this.txtFornitore.TabIndex = 130;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(9, 52);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 16);
            this.label6.TabIndex = 129;
            this.label6.Text = "Fornitore";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnSelectAllDetail
            // 
            this.btnSelectAllDetail.Location = new System.Drawing.Point(592, 135);
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
            this.label18.Location = new System.Drawing.Point(9, 174);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(818, 16);
            this.label18.TabIndex = 126;
            this.label18.Text = "Selezionare i dettagli da contabilizzare (sono visualizzati solo i dettagli colle" +
    "gati a un UPB e a cui non è associata una data di annullamento)";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.txtTotGenerale);
            this.groupBox2.Controls.Add(this.txtTotIva);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txtTotImponibile);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Location = new System.Drawing.Point(9, 401);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(812, 72);
            this.groupBox2.TabIndex = 125;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Dettagli selezionati";
            // 
            // txtTotGenerale
            // 
            this.txtTotGenerale.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtTotGenerale.Location = new System.Drawing.Point(296, 40);
            this.txtTotGenerale.Name = "txtTotGenerale";
            this.txtTotGenerale.ReadOnly = true;
            this.txtTotGenerale.Size = new System.Drawing.Size(128, 23);
            this.txtTotGenerale.TabIndex = 109;
            // 
            // txtTotIva
            // 
            this.txtTotIva.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtTotIva.Location = new System.Drawing.Point(160, 40);
            this.txtTotIva.Name = "txtTotIva";
            this.txtTotIva.ReadOnly = true;
            this.txtTotIva.Size = new System.Drawing.Size(112, 23);
            this.txtTotIva.TabIndex = 108;
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
            this.txtTotImponibile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtTotImponibile.Location = new System.Drawing.Point(8, 40);
            this.txtTotImponibile.Name = "txtTotImponibile";
            this.txtTotImponibile.ReadOnly = true;
            this.txtTotImponibile.Size = new System.Drawing.Size(136, 23);
            this.txtTotImponibile.TabIndex = 107;
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
            this.gridDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridDetails.DataMember = "";
            this.gridDetails.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.gridDetails.Location = new System.Drawing.Point(9, 196);
            this.gridDetails.Name = "gridDetails";
            this.gridDetails.Size = new System.Drawing.Size(812, 199);
            this.gridDetails.TabIndex = 124;
            this.gridDetails.Paint += new System.Windows.Forms.PaintEventHandler(this.gridDetails_Paint);
            // 
            // cmbCausale
            // 
            this.cmbCausale.DataSource = this.DS.tipomovimento;
            this.cmbCausale.DisplayMember = "descrizione";
            this.cmbCausale.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World, ((byte)(0)));
            this.cmbCausale.ItemHeight = 13;
            this.cmbCausale.Location = new System.Drawing.Point(97, 132);
            this.cmbCausale.Name = "cmbCausale";
            this.cmbCausale.Size = new System.Drawing.Size(256, 21);
            this.cmbCausale.TabIndex = 123;
            this.cmbCausale.ValueMember = "idtipo";
            this.cmbCausale.SelectedIndexChanged += new System.EventHandler(this.cmbCausale_SelectedIndexChanged);
            // 
            // labelCausale
            // 
            this.labelCausale.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World, ((byte)(0)));
            this.labelCausale.Location = new System.Drawing.Point(41, 132);
            this.labelCausale.Name = "labelCausale";
            this.labelCausale.Size = new System.Drawing.Size(48, 23);
            this.labelCausale.TabIndex = 122;
            this.labelCausale.Text = "Causale";
            this.labelCausale.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnDocumento
            // 
            this.btnDocumento.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDocumento.Location = new System.Drawing.Point(9, 4);
            this.btnDocumento.Name = "btnDocumento";
            this.btnDocumento.Size = new System.Drawing.Size(104, 20);
            this.btnDocumento.TabIndex = 121;
            this.btnDocumento.Text = "Documento IVA";
            this.btnDocumento.Click += new System.EventHandler(this.btnDocumento_Click);
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(177, 28);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(48, 16);
            this.label7.TabIndex = 117;
            this.label7.Text = "Eserc.";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtNumDoc
            // 
            this.txtNumDoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNumDoc.Location = new System.Drawing.Point(313, 28);
            this.txtNumDoc.Name = "txtNumDoc";
            this.txtNumDoc.Size = new System.Drawing.Size(64, 20);
            this.txtNumDoc.TabIndex = 120;
            this.txtNumDoc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtNumDoc.Leave += new System.EventHandler(this.txtNumDoc_Leave);
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(281, 28);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(32, 16);
            this.label10.TabIndex = 119;
            this.label10.Text = "Num.";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtEsercDoc
            // 
            this.txtEsercDoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEsercDoc.Location = new System.Drawing.Point(225, 28);
            this.txtEsercDoc.Name = "txtEsercDoc";
            this.txtEsercDoc.Size = new System.Drawing.Size(56, 20);
            this.txtEsercDoc.TabIndex = 118;
            this.txtEsercDoc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtEsercDoc.Leave += new System.EventHandler(this.txtEsercDoc_Leave);
            // 
            // tabSplit
            // 
            this.tabSplit.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
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
            this.tabSplit.Size = new System.Drawing.Size(830, 483);
            this.tabSplit.TabIndex = 7;
            this.tabSplit.Title = "Pagina 3 di 5";
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.lblCausale);
            this.groupBox3.Controls.Add(this.txtTotSelezionato);
            this.groupBox3.Controls.Add(this.label19);
            this.groupBox3.Controls.Add(this.rdbSplittaUno);
            this.groupBox3.Controls.Add(this.rdbSplittaTutti);
            this.groupBox3.Location = new System.Drawing.Point(3, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(812, 131);
            this.groupBox3.TabIndex = 7;
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
            this.txtTotSelezionato.Location = new System.Drawing.Point(685, 26);
            this.txtTotSelezionato.Name = "txtTotSelezionato";
            this.txtTotSelezionato.ReadOnly = true;
            this.txtTotSelezionato.Size = new System.Drawing.Size(100, 23);
            this.txtTotSelezionato.TabIndex = 0;
            this.txtTotSelezionato.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label19
            // 
            this.label19.Location = new System.Drawing.Point(368, 30);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(163, 13);
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
            this.rdbSplittaUno.Text = "Contabilizza interamente i dettagli fino a coprire l\'importo da pagare. Sarà sudd" +
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
            this.rdbSplittaTutti.Text = "Distribuisci l\'importo da pagare su tutti i dettagli selezionati. Tutti i dettagl" +
    "i saranno suddivisi";
            this.rdbSplittaTutti.UseVisualStyleBackColor = true;
            // 
            // label23
            // 
            this.label23.Location = new System.Drawing.Point(346, 156);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(128, 16);
            this.label23.TabIndex = 8;
            this.label23.Text = "Importo";
            this.label23.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label22
            // 
            this.label22.Location = new System.Drawing.Point(277, 156);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(56, 16);
            this.label22.TabIndex = 5;
            this.label22.Text = "%";
            this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtPerc
            // 
            this.txtPerc.Location = new System.Drawing.Point(274, 172);
            this.txtPerc.Name = "txtPerc";
            this.txtPerc.Size = new System.Drawing.Size(64, 23);
            this.txtPerc.TabIndex = 9;
            this.txtPerc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtPerc.Leave += new System.EventHandler(this.txtPerc_Leave);
            // 
            // label17
            // 
            this.label17.Location = new System.Drawing.Point(20, 170);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(224, 23);
            this.label17.TabIndex = 6;
            this.label17.Text = "Inserire il valore che si desidera pagare:";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtDaPagare
            // 
            this.txtDaPagare.Location = new System.Drawing.Point(346, 172);
            this.txtDaPagare.Name = "txtDaPagare";
            this.txtDaPagare.Size = new System.Drawing.Size(112, 23);
            this.txtDaPagare.TabIndex = 10;
            this.txtDaPagare.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtDaPagare.Leave += new System.EventHandler(this.txtDaPagare_Leave);
            // 
            // tabSelMov
            // 
            this.tabSelMov.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabSelMov.Controls.Add(this.gboxSelMov);
            this.tabSelMov.Controls.Add(this.radioNewLinkedMov);
            this.tabSelMov.Controls.Add(this.radioNewCont);
            this.tabSelMov.Controls.Add(this.radioAddCont);
            this.tabSelMov.Controls.Add(this.labelMessage);
            this.tabSelMov.Location = new System.Drawing.Point(0, 0);
            this.tabSelMov.Name = "tabSelMov";
            this.tabSelMov.Selected = false;
            this.tabSelMov.Size = new System.Drawing.Size(830, 483);
            this.tabSelMov.TabIndex = 5;
            this.tabSelMov.Title = "Pagina 4 di 5";
            // 
            // gboxSelMov
            // 
            this.gboxSelMov.Controls.Add(this.lblWarningMandate);
            this.gboxSelMov.Controls.Add(this.gboxUPB);
            this.gboxSelMov.Controls.Add(this.gboxMovimento);
            this.gboxSelMov.Controls.Add(this.groupBox17);
            this.gboxSelMov.Controls.Add(this.gboxBilAnnuale);
            this.gboxSelMov.Controls.Add(this.groupBox20);
            this.gboxSelMov.Controls.Add(this.groupBox18);
            this.gboxSelMov.Controls.Add(this.groupBox1);
            this.gboxSelMov.Location = new System.Drawing.Point(8, 71);
            this.gboxSelMov.Name = "gboxSelMov";
            this.gboxSelMov.Size = new System.Drawing.Size(740, 370);
            this.gboxSelMov.TabIndex = 110;
            this.gboxSelMov.TabStop = false;
            this.gboxSelMov.Text = "Selezione del movimento di spesa";
            // 
            // lblWarningMandate
            // 
            this.lblWarningMandate.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWarningMandate.Location = new System.Drawing.Point(384, 101);
            this.lblWarningMandate.Name = "lblWarningMandate";
            this.lblWarningMandate.Size = new System.Drawing.Size(323, 66);
            this.lblWarningMandate.TabIndex = 99;
            this.lblWarningMandate.Text = "label2";
            this.lblWarningMandate.Visible = false;
            // 
            // gboxUPB
            // 
            this.gboxUPB.Controls.Add(this.txtUPB);
            this.gboxUPB.Controls.Add(this.txtDescrUPB);
            this.gboxUPB.Controls.Add(this.btnUPBCode);
            this.gboxUPB.Location = new System.Drawing.Point(8, 111);
            this.gboxUPB.Name = "gboxUPB";
            this.gboxUPB.Size = new System.Drawing.Size(373, 103);
            this.gboxUPB.TabIndex = 98;
            this.gboxUPB.TabStop = false;
            this.gboxUPB.Tag = "";
            // 
            // txtUPB
            // 
            this.txtUPB.Location = new System.Drawing.Point(3, 76);
            this.txtUPB.Name = "txtUPB";
            this.txtUPB.ReadOnly = true;
            this.txtUPB.Size = new System.Drawing.Size(352, 23);
            this.txtUPB.TabIndex = 100;
            // 
            // txtDescrUPB
            // 
            this.txtDescrUPB.Location = new System.Drawing.Point(99, 8);
            this.txtDescrUPB.Multiline = true;
            this.txtDescrUPB.Name = "txtDescrUPB";
            this.txtDescrUPB.ReadOnly = true;
            this.txtDescrUPB.Size = new System.Drawing.Size(256, 62);
            this.txtDescrUPB.TabIndex = 4;
            this.txtDescrUPB.TabStop = false;
            this.txtDescrUPB.Tag = "upb.title";
            // 
            // btnUPBCode
            // 
            this.btnUPBCode.BackColor = System.Drawing.SystemColors.Control;
            this.btnUPBCode.Enabled = false;
            this.btnUPBCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUPBCode.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnUPBCode.Location = new System.Drawing.Point(8, 50);
            this.btnUPBCode.Name = "btnUPBCode";
            this.btnUPBCode.Size = new System.Drawing.Size(83, 20);
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
            this.gboxMovimento.Size = new System.Drawing.Size(373, 48);
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
            this.txtNumeroMovimento.Location = new System.Drawing.Point(305, 18);
            this.txtNumeroMovimento.Name = "txtNumeroMovimento";
            this.txtNumeroMovimento.Size = new System.Drawing.Size(62, 23);
            this.txtNumeroMovimento.TabIndex = 3;
            this.txtNumeroMovimento.Tag = "";
            this.txtNumeroMovimento.Leave += new System.EventHandler(this.txtNumeroMovimento_Leave);
            // 
            // labNum
            // 
            this.labNum.Location = new System.Drawing.Point(238, 20);
            this.labNum.Name = "labNum";
            this.labNum.Size = new System.Drawing.Size(61, 20);
            this.labNum.TabIndex = 0;
            this.labNum.Text = "Num.";
            this.labNum.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtEsercizioMovimento
            // 
            this.txtEsercizioMovimento.Location = new System.Drawing.Point(182, 20);
            this.txtEsercizioMovimento.Name = "txtEsercizioMovimento";
            this.txtEsercizioMovimento.Size = new System.Drawing.Size(39, 23);
            this.txtEsercizioMovimento.TabIndex = 2;
            this.txtEsercizioMovimento.Tag = "";
            this.txtEsercizioMovimento.Leave += new System.EventHandler(this.txtEsercizioMovimento_Leave);
            // 
            // labEserc
            // 
            this.labEserc.Location = new System.Drawing.Point(124, 20);
            this.labEserc.Name = "labEserc";
            this.labEserc.Size = new System.Drawing.Size(58, 20);
            this.labEserc.TabIndex = 0;
            this.labEserc.Text = "Eserc.";
            this.labEserc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBox17
            // 
            this.groupBox17.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox17.Controls.Add(this.txtDescrizione);
            this.groupBox17.Location = new System.Drawing.Point(387, 16);
            this.groupBox17.Name = "groupBox17";
            this.groupBox17.Size = new System.Drawing.Size(345, 72);
            this.groupBox17.TabIndex = 93;
            this.groupBox17.TabStop = false;
            this.groupBox17.Text = "Descrizione";
            // 
            // txtDescrizione
            // 
            this.txtDescrizione.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescrizione.Location = new System.Drawing.Point(8, 16);
            this.txtDescrizione.Multiline = true;
            this.txtDescrizione.Name = "txtDescrizione";
            this.txtDescrizione.ReadOnly = true;
            this.txtDescrizione.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDescrizione.Size = new System.Drawing.Size(332, 48);
            this.txtDescrizione.TabIndex = 1;
            this.txtDescrizione.Tag = "";
            // 
            // gboxBilAnnuale
            // 
            this.gboxBilAnnuale.Controls.Add(this.label9);
            this.gboxBilAnnuale.Controls.Add(this.txtCodiceBilancio);
            this.gboxBilAnnuale.Controls.Add(this.txtDenominazioneBilancio);
            this.gboxBilAnnuale.Location = new System.Drawing.Point(8, 212);
            this.gboxBilAnnuale.Name = "gboxBilAnnuale";
            this.gboxBilAnnuale.Size = new System.Drawing.Size(373, 96);
            this.gboxBilAnnuale.TabIndex = 90;
            this.gboxBilAnnuale.TabStop = false;
            this.gboxBilAnnuale.Tag = "";
            // 
            // label9
            // 
            this.label9.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label9.Location = new System.Drawing.Point(8, 49);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(69, 13);
            this.label9.TabIndex = 3;
            this.label9.Text = "Bilancio";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtCodiceBilancio
            // 
            this.txtCodiceBilancio.Location = new System.Drawing.Point(11, 68);
            this.txtCodiceBilancio.Name = "txtCodiceBilancio";
            this.txtCodiceBilancio.ReadOnly = true;
            this.txtCodiceBilancio.Size = new System.Drawing.Size(344, 23);
            this.txtCodiceBilancio.TabIndex = 1;
            this.txtCodiceBilancio.Tag = "";
            // 
            // txtDenominazioneBilancio
            // 
            this.txtDenominazioneBilancio.Location = new System.Drawing.Point(83, 22);
            this.txtDenominazioneBilancio.Multiline = true;
            this.txtDenominazioneBilancio.Name = "txtDenominazioneBilancio";
            this.txtDenominazioneBilancio.ReadOnly = true;
            this.txtDenominazioneBilancio.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDenominazioneBilancio.Size = new System.Drawing.Size(272, 40);
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
            this.groupBox20.Location = new System.Drawing.Point(6, 314);
            this.groupBox20.Name = "groupBox20";
            this.groupBox20.Size = new System.Drawing.Size(373, 40);
            this.groupBox20.TabIndex = 96;
            this.groupBox20.TabStop = false;
            this.groupBox20.Text = "Data";
            // 
            // label15
            // 
            this.label15.Location = new System.Drawing.Point(2, 16);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(77, 20);
            this.label15.TabIndex = 0;
            this.label15.Text = "Contabile";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDataCont
            // 
            this.txtDataCont.Location = new System.Drawing.Point(85, 13);
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
            this.groupBox18.Size = new System.Drawing.Size(373, 40);
            this.groupBox18.TabIndex = 95;
            this.groupBox18.TabStop = false;
            this.groupBox18.Text = "Importo";
            // 
            // SubEntity_txtImportoMovimento
            // 
            this.SubEntity_txtImportoMovimento.Location = new System.Drawing.Point(124, 11);
            this.SubEntity_txtImportoMovimento.Name = "SubEntity_txtImportoMovimento";
            this.SubEntity_txtImportoMovimento.ReadOnly = true;
            this.SubEntity_txtImportoMovimento.Size = new System.Drawing.Size(112, 23);
            this.SubEntity_txtImportoMovimento.TabIndex = 1;
            this.SubEntity_txtImportoMovimento.Tag = "";
            this.SubEntity_txtImportoMovimento.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(62, 12);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(56, 20);
            this.label11.TabIndex = 0;
            this.label11.Text = "Originale:";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.lblImportoDisponibile);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.txtImportoDisponibile);
            this.groupBox1.Controls.Add(this.txtImportoCorrente);
            this.groupBox1.Location = new System.Drawing.Point(387, 290);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(343, 64);
            this.groupBox1.TabIndex = 97;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Situazione riassuntiva importo del movimento";
            // 
            // lblImportoDisponibile
            // 
            this.lblImportoDisponibile.Location = new System.Drawing.Point(8, 40);
            this.lblImportoDisponibile.Name = "lblImportoDisponibile";
            this.lblImportoDisponibile.Size = new System.Drawing.Size(213, 20);
            this.lblImportoDisponibile.TabIndex = 0;
            this.lblImportoDisponibile.Text = "Disponibile:";
            this.lblImportoDisponibile.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(8, 12);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(213, 24);
            this.label12.TabIndex = 0;
            this.label12.Text = "Attuale (comprensivo delle variazioni):";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtImportoDisponibile
            // 
            this.txtImportoDisponibile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtImportoDisponibile.Location = new System.Drawing.Point(227, 40);
            this.txtImportoDisponibile.Name = "txtImportoDisponibile";
            this.txtImportoDisponibile.ReadOnly = true;
            this.txtImportoDisponibile.Size = new System.Drawing.Size(111, 23);
            this.txtImportoDisponibile.TabIndex = 0;
            this.txtImportoDisponibile.TabStop = false;
            this.txtImportoDisponibile.Tag = "";
            this.txtImportoDisponibile.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtImportoCorrente
            // 
            this.txtImportoCorrente.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtImportoCorrente.Location = new System.Drawing.Point(227, 16);
            this.txtImportoCorrente.Name = "txtImportoCorrente";
            this.txtImportoCorrente.ReadOnly = true;
            this.txtImportoCorrente.Size = new System.Drawing.Size(111, 23);
            this.txtImportoCorrente.TabIndex = 0;
            this.txtImportoCorrente.TabStop = false;
            this.txtImportoCorrente.Tag = "";
            this.txtImportoCorrente.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // radioNewLinkedMov
            // 
            this.radioNewLinkedMov.Location = new System.Drawing.Point(8, 27);
            this.radioNewLinkedMov.Name = "radioNewLinkedMov";
            this.radioNewLinkedMov.Size = new System.Drawing.Size(693, 16);
            this.radioNewLinkedMov.TabIndex = 109;
            this.radioNewLinkedMov.Text = "Si desidera creare un NUOVO movimento di spesa, collegandolo però ad un movimento" +
    " esistente";
            this.radioNewLinkedMov.CheckedChanged += new System.EventHandler(this.radioNewLinkedMov_CheckedChanged);
            // 
            // radioNewCont
            // 
            this.radioNewCont.Location = new System.Drawing.Point(8, 7);
            this.radioNewCont.Name = "radioNewCont";
            this.radioNewCont.Size = new System.Drawing.Size(685, 16);
            this.radioNewCont.TabIndex = 108;
            this.radioNewCont.Text = "Si desidera creare un NUOVO movimento di spesa";
            this.radioNewCont.CheckedChanged += new System.EventHandler(this.radioNewCont_CheckedChanged);
            // 
            // radioAddCont
            // 
            this.radioAddCont.Location = new System.Drawing.Point(8, 47);
            this.radioAddCont.Name = "radioAddCont";
            this.radioAddCont.Size = new System.Drawing.Size(685, 16);
            this.radioAddCont.TabIndex = 107;
            this.radioAddCont.Text = "Si desidera AGGIUNGERE LA CONTABILIZZAZIONE ai dettagli fattura";
            this.radioAddCont.CheckedChanged += new System.EventHandler(this.radioAddCont_CheckedChanged);
            // 
            // labelMessage
            // 
            this.labelMessage.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.labelMessage.Location = new System.Drawing.Point(8, 316);
            this.labelMessage.Name = "labelMessage";
            this.labelMessage.Size = new System.Drawing.Size(679, 32);
            this.labelMessage.TabIndex = 106;
            // 
            // tabConfirm
            // 
            this.tabConfirm.Controls.Add(this.groupBox4);
            this.tabConfirm.Controls.Add(this.grpInfoOpzionali);
            this.tabConfirm.Controls.Add(this.gboxBilToCreate);
            this.tabConfirm.Controls.Add(this.labMsgTODO2);
            this.tabConfirm.Controls.Add(this.labMsgTODO1);
            this.tabConfirm.Location = new System.Drawing.Point(0, 0);
            this.tabConfirm.Name = "tabConfirm";
            this.tabConfirm.Size = new System.Drawing.Size(830, 483);
            this.tabConfirm.TabIndex = 6;
            this.tabConfirm.Title = "Pagina 5 di 5";
            // 
            // chkAutomRecuperi
            // 
            this.chkAutomRecuperi.Location = new System.Drawing.Point(6, 26);
            this.chkAutomRecuperi.Name = "chkAutomRecuperi";
            this.chkAutomRecuperi.Size = new System.Drawing.Size(328, 24);
            this.chkAutomRecuperi.TabIndex = 94;
            this.chkAutomRecuperi.Tag = " ";
            this.chkAutomRecuperi.Text = "Non generare automatismi per i Recuperi";
            // 
            // grpInfoOpzionali
            // 
            this.grpInfoOpzionali.Controls.Add(this.gboxBolletta);
            this.grpInfoOpzionali.Location = new System.Drawing.Point(19, 222);
            this.grpInfoOpzionali.Name = "grpInfoOpzionali";
            this.grpInfoOpzionali.Size = new System.Drawing.Size(332, 68);
            this.grpInfoOpzionali.TabIndex = 93;
            this.grpInfoOpzionali.TabStop = false;
            this.grpInfoOpzionali.Text = "Informazioni da associare al pagamento (opzionali)";
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
            this.btnBolletta.Tag = "choose.bill.spesa";
            this.btnBolletta.Text = "N. bolletta";
            // 
            // gboxBilToCreate
            // 
            this.gboxBilToCreate.Controls.Add(this.label14);
            this.gboxBilToCreate.Controls.Add(this.txtCodeBilSelected);
            this.gboxBilToCreate.Controls.Add(this.txtDenomBilSelected);
            this.gboxBilToCreate.Location = new System.Drawing.Point(15, 84);
            this.gboxBilToCreate.Name = "gboxBilToCreate";
            this.gboxBilToCreate.Size = new System.Drawing.Size(377, 123);
            this.gboxBilToCreate.TabIndex = 92;
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
            this.txtCodeBilSelected.Location = new System.Drawing.Point(4, 96);
            this.txtCodeBilSelected.Name = "txtCodeBilSelected";
            this.txtCodeBilSelected.ReadOnly = true;
            this.txtCodeBilSelected.Size = new System.Drawing.Size(367, 23);
            this.txtCodeBilSelected.TabIndex = 1;
            this.txtCodeBilSelected.Tag = "";
            // 
            // txtDenomBilSelected
            // 
            this.txtDenomBilSelected.Location = new System.Drawing.Point(136, 13);
            this.txtDenomBilSelected.Multiline = true;
            this.txtDenomBilSelected.Name = "txtDenomBilSelected";
            this.txtDenomBilSelected.ReadOnly = true;
            this.txtDenomBilSelected.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDenomBilSelected.Size = new System.Drawing.Size(235, 77);
            this.txtDenomBilSelected.TabIndex = 2;
            this.txtDenomBilSelected.TabStop = false;
            this.txtDenomBilSelected.Tag = "";
            // 
            // labMsgTODO2
            // 
            this.labMsgTODO2.Location = new System.Drawing.Point(16, 45);
            this.labMsgTODO2.Name = "labMsgTODO2";
            this.labMsgTODO2.Size = new System.Drawing.Size(680, 23);
            this.labMsgTODO2.TabIndex = 3;
            // 
            // labMsgTODO1
            // 
            this.labMsgTODO1.Location = new System.Drawing.Point(16, 6);
            this.labMsgTODO1.Name = "labMsgTODO1";
            this.labMsgTODO1.Size = new System.Drawing.Size(680, 23);
            this.labMsgTODO1.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.tabController);
            this.panel1.Location = new System.Drawing.Point(1, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(830, 508);
            this.panel1.TabIndex = 21;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.chkAutomRecuperi);
            this.groupBox4.Location = new System.Drawing.Point(371, 228);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(369, 62);
            this.groupBox4.TabIndex = 95;
            this.groupBox4.TabStop = false;
            // 
            // FrmWizardInvoiceDetailNoMandate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(834, 546);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnBack);
            this.Name = "FrmWizardInvoiceDetailNoMandate";
            this.Text = "FrmWizardInvoiceDetailNoMandate";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmWizardInvoiceDetailNoMandate_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.tabController.ResumeLayout(false);
            this.tabIntro.ResumeLayout(false);
            this.tabIntro.PerformLayout();
            this.tabSetDetail.ResumeLayout(false);
            this.tabSetDetail.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridDetails)).EndInit();
            this.tabSplit.ResumeLayout(false);
            this.tabSplit.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.tabSelMov.ResumeLayout(false);
            this.gboxSelMov.ResumeLayout(false);
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
            this.grpInfoOpzionali.ResumeLayout(false);
            this.gboxBolletta.ResumeLayout(false);
            this.gboxBolletta.PerformLayout();
            this.gboxBilToCreate.ResumeLayout(false);
            this.gboxBilToCreate.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnBack;
        public dsmeta DS;
        private Crownwood.Magic.Controls.TabControl tabControl1;
        private Crownwood.Magic.Controls.TabControl tabController;
        private Crownwood.Magic.Controls.TabPage tabSelMov;
        private System.Windows.Forms.GroupBox gboxSelMov;
        private System.Windows.Forms.Label lblWarningMandate;
        private System.Windows.Forms.GroupBox gboxUPB;
        private System.Windows.Forms.TextBox txtDescrUPB;
        private System.Windows.Forms.Button btnUPBCode;
        private System.Windows.Forms.GroupBox gboxMovimento;
        private System.Windows.Forms.Button btnSelectMov;
        private System.Windows.Forms.TextBox txtNumeroMovimento;
        private System.Windows.Forms.Label labNum;
        private System.Windows.Forms.TextBox txtEsercizioMovimento;
        private System.Windows.Forms.Label labEserc;
        private System.Windows.Forms.GroupBox groupBox17;
        private System.Windows.Forms.TextBox txtDescrizione;
        private System.Windows.Forms.GroupBox gboxBilAnnuale;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtCodiceBilancio;
        private System.Windows.Forms.TextBox txtDenominazioneBilancio;
        private System.Windows.Forms.GroupBox groupBox20;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtDataCont;
        private System.Windows.Forms.TextBox txtScadenza;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.GroupBox groupBox18;
        private System.Windows.Forms.TextBox SubEntity_txtImportoMovimento;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblImportoDisponibile;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtImportoDisponibile;
        private System.Windows.Forms.TextBox txtImportoCorrente;
        private System.Windows.Forms.RadioButton radioNewLinkedMov;
        private System.Windows.Forms.RadioButton radioNewCont;
        private System.Windows.Forms.RadioButton radioAddCont;
        private System.Windows.Forms.Label labelMessage;
        private Crownwood.Magic.Controls.TabPage tabIntro;
        private System.Windows.Forms.Label label1;
        private Crownwood.Magic.Controls.TabPage tabSetDetail;
        private System.Windows.Forms.ComboBox cmbTipoFattura;
        private System.Windows.Forms.TextBox txtDescrFattura;
        private System.Windows.Forms.Label labDescrFattura;
        private System.Windows.Forms.TextBox txtFornitore;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnSelectAllDetail;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtTotGenerale;
        private System.Windows.Forms.TextBox txtTotIva;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtTotImponibile;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGrid gridDetails;
        private System.Windows.Forms.ComboBox cmbCausale;
        private System.Windows.Forms.Label labelCausale;
        private System.Windows.Forms.Button btnDocumento;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtNumDoc;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtEsercDoc;
        private Crownwood.Magic.Controls.TabPage tabSplit;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label lblCausale;
        private System.Windows.Forms.TextBox txtTotSelezionato;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.RadioButton rdbSplittaUno;
        private System.Windows.Forms.RadioButton rdbSplittaTutti;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.TextBox txtPerc;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txtDaPagare;
        private Crownwood.Magic.Controls.TabPage tabConfirm;
        private System.Windows.Forms.GroupBox grpInfoOpzionali;
        private System.Windows.Forms.GroupBox gboxBolletta;
        private System.Windows.Forms.TextBox txtBolletta;
        private System.Windows.Forms.Button btnBolletta;
        private System.Windows.Forms.GroupBox gboxBilToCreate;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtCodeBilSelected;
        private System.Windows.Forms.TextBox txtDenomBilSelected;
        private System.Windows.Forms.Label labMsgTODO2;
        private System.Windows.Forms.Label labMsgTODO1;
        private System.Windows.Forms.TextBox txtUPB;
        private System.Windows.Forms.CheckBox chk_Enable_Split_Payment;
        private System.Windows.Forms.CheckBox chkAutomRecuperi;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox4;
    }
}