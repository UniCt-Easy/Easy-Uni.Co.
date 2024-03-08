
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


namespace pettycashoperation_wizardinvoicedetail
{
    partial class Frm_pettycashoperation_wizardinvoicedetail
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_pettycashoperation_wizardinvoicedetail));
			this.DS = new pettycashoperation_wizardinvoicedetail.vistaForm();
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnNext = new System.Windows.Forms.Button();
			this.btnBack = new System.Windows.Forms.Button();
			this.btnInserisciClassificazioni = new System.Windows.Forms.Button();
			this.tabController = new System.Windows.Forms.TabControl();
			this.tabIntro = new System.Windows.Forms.TabPage();
			this.label1 = new System.Windows.Forms.Label();
			this.tabSetDetail = new System.Windows.Forms.TabPage();
			this.cmbTipoFattura = new System.Windows.Forms.ComboBox();
			this.txtDescrFattura = new System.Windows.Forms.TextBox();
			this.labDescrFattura = new System.Windows.Forms.Label();
			this.txtFornitore = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.cmbCausale = new System.Windows.Forms.ComboBox();
			this.labelCausale = new System.Windows.Forms.Label();
			this.btnDocumento = new System.Windows.Forms.Button();
			this.label7 = new System.Windows.Forms.Label();
			this.txtNumDoc = new System.Windows.Forms.TextBox();
			this.label10 = new System.Windows.Forms.Label();
			this.txtEsercDoc = new System.Windows.Forms.TextBox();
			this.gridDetails = new System.Windows.Forms.DataGrid();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.txtTotGenerale = new System.Windows.Forms.TextBox();
			this.txtTotIva = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.txtTotImponibile = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.tabSplit = new System.Windows.Forms.TabPage();
			this.grpInfo = new System.Windows.Forms.GroupBox();
			this.grpTipoDoc = new System.Windows.Forms.GroupBox();
			this.label9 = new System.Windows.Forms.Label();
			this.txtDocumento = new System.Windows.Forms.TextBox();
			this.txtDataDoc = new System.Windows.Forms.TextBox();
			this.label11 = new System.Windows.Forms.Label();
			this.grpTipoSpesa = new System.Windows.Forms.GroupBox();
			this.chkDocumentata = new System.Windows.Forms.CheckBox();
			this.grpDescrizione = new System.Windows.Forms.GroupBox();
			this.txtDescrizione = new System.Windows.Forms.TextBox();
			this.grpFondoEconomale = new System.Windows.Forms.GroupBox();
			this.cmbFondoPS = new System.Windows.Forms.ComboBox();
			this.txtRimasto = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.txtTotaleFattura = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.btnCancella = new System.Windows.Forms.Button();
			this.btnAggiungi = new System.Windows.Forms.Button();
			this.btnModificaInfo = new System.Windows.Forms.Button();
			this.gridInfo = new System.Windows.Forms.DataGrid();
			this.tabSave = new System.Windows.Forms.TabPage();
			this.label12 = new System.Windows.Forms.Label();
			this.gridMovSpesa = new System.Windows.Forms.DataGrid();
			((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
			this.tabController.SuspendLayout();
			this.tabIntro.SuspendLayout();
			this.tabSetDetail.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.gridDetails)).BeginInit();
			this.groupBox2.SuspendLayout();
			this.tabSplit.SuspendLayout();
			this.grpInfo.SuspendLayout();
			this.grpTipoDoc.SuspendLayout();
			this.grpTipoSpesa.SuspendLayout();
			this.grpDescrizione.SuspendLayout();
			this.grpFondoEconomale.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.gridInfo)).BeginInit();
			this.tabSave.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.gridMovSpesa)).BeginInit();
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
			this.btnCancel.Location = new System.Drawing.Point(699, 544);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 23);
			this.btnCancel.TabIndex = 24;
			this.btnCancel.Tag = "maincancel";
			this.btnCancel.Text = "Annulla";
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click_1);
			// 
			// btnNext
			// 
			this.btnNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnNext.Location = new System.Drawing.Point(572, 545);
			this.btnNext.Name = "btnNext";
			this.btnNext.Size = new System.Drawing.Size(88, 23);
			this.btnNext.TabIndex = 23;
			this.btnNext.Text = "Avanti >";
			this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
			// 
			// btnBack
			// 
			this.btnBack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnBack.Location = new System.Drawing.Point(436, 545);
			this.btnBack.Name = "btnBack";
			this.btnBack.Size = new System.Drawing.Size(80, 23);
			this.btnBack.TabIndex = 22;
			this.btnBack.Text = "< Indietro";
			this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
			// 
			// btnInserisciClassificazioni
			// 
			this.btnInserisciClassificazioni.Location = new System.Drawing.Point(522, 545);
			this.btnInserisciClassificazioni.Name = "btnInserisciClassificazioni";
			this.btnInserisciClassificazioni.Size = new System.Drawing.Size(160, 23);
			this.btnInserisciClassificazioni.TabIndex = 26;
			this.btnInserisciClassificazioni.Text = "Inserisci Classificazioni";
			this.btnInserisciClassificazioni.UseVisualStyleBackColor = true;
			this.btnInserisciClassificazioni.Click += new System.EventHandler(this.btnInserisciClassificazioni_Click);
			// 
			// tabController
			// 
			this.tabController.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tabController.Controls.Add(this.tabIntro);
			this.tabController.Controls.Add(this.tabSetDetail);
			this.tabController.Controls.Add(this.tabSplit);
			this.tabController.Controls.Add(this.tabSave);
			this.tabController.Location = new System.Drawing.Point(12, 12);
			this.tabController.Name = "tabController";
			this.tabController.SelectedIndex = 1;
			this.tabController.Size = new System.Drawing.Size(778, 511);
			this.tabController.TabIndex = 27;
			// 
			// tabIntro
			// 
			this.tabIntro.Controls.Add(this.label1);
			this.tabIntro.Location = new System.Drawing.Point(4, 22);
			this.tabIntro.Name = "tabIntro";
			this.tabIntro.Size = new System.Drawing.Size(770, 485);
			this.tabIntro.TabIndex = 3;
			this.tabIntro.Text = "Pagina 1 di 4";
			// 
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.label1.Location = new System.Drawing.Point(11, 62);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(750, 60);
			this.label1.TabIndex = 1;
			this.label1.Text = resources.GetString("label1.Text");
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// tabSetDetail
			// 
			this.tabSetDetail.Controls.Add(this.cmbTipoFattura);
			this.tabSetDetail.Controls.Add(this.txtDescrFattura);
			this.tabSetDetail.Controls.Add(this.labDescrFattura);
			this.tabSetDetail.Controls.Add(this.txtFornitore);
			this.tabSetDetail.Controls.Add(this.label6);
			this.tabSetDetail.Controls.Add(this.cmbCausale);
			this.tabSetDetail.Controls.Add(this.labelCausale);
			this.tabSetDetail.Controls.Add(this.btnDocumento);
			this.tabSetDetail.Controls.Add(this.label7);
			this.tabSetDetail.Controls.Add(this.txtNumDoc);
			this.tabSetDetail.Controls.Add(this.label10);
			this.tabSetDetail.Controls.Add(this.txtEsercDoc);
			this.tabSetDetail.Controls.Add(this.gridDetails);
			this.tabSetDetail.Controls.Add(this.groupBox2);
			this.tabSetDetail.Location = new System.Drawing.Point(4, 22);
			this.tabSetDetail.Name = "tabSetDetail";
			this.tabSetDetail.Size = new System.Drawing.Size(770, 485);
			this.tabSetDetail.TabIndex = 6;
			this.tabSetDetail.Text = "Pagina 2 di 4";
			// 
			// cmbTipoFattura
			// 
			this.cmbTipoFattura.DataSource = this.DS.invoicekind;
			this.cmbTipoFattura.DisplayMember = "description";
			this.cmbTipoFattura.Location = new System.Drawing.Point(143, 3);
			this.cmbTipoFattura.Name = "cmbTipoFattura";
			this.cmbTipoFattura.Size = new System.Drawing.Size(256, 21);
			this.cmbTipoFattura.TabIndex = 147;
			this.cmbTipoFattura.ValueMember = "idinvkind";
			this.cmbTipoFattura.SelectedIndexChanged += new System.EventHandler(this.cmbTipoFattura_SelectedIndexChanged);
			// 
			// txtDescrFattura
			// 
			this.txtDescrFattura.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtDescrFattura.Location = new System.Drawing.Point(117, 87);
			this.txtDescrFattura.Multiline = true;
			this.txtDescrFattura.Name = "txtDescrFattura";
			this.txtDescrFattura.ReadOnly = true;
			this.txtDescrFattura.Size = new System.Drawing.Size(639, 53);
			this.txtDescrFattura.TabIndex = 146;
			// 
			// labDescrFattura
			// 
			this.labDescrFattura.Location = new System.Drawing.Point(31, 100);
			this.labDescrFattura.Name = "labDescrFattura";
			this.labDescrFattura.Size = new System.Drawing.Size(80, 16);
			this.labDescrFattura.TabIndex = 145;
			this.labDescrFattura.Text = "Descrizione";
			this.labDescrFattura.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtFornitore
			// 
			this.txtFornitore.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtFornitore.Location = new System.Drawing.Point(117, 58);
			this.txtFornitore.Name = "txtFornitore";
			this.txtFornitore.ReadOnly = true;
			this.txtFornitore.Size = new System.Drawing.Size(637, 20);
			this.txtFornitore.TabIndex = 144;
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(29, 58);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(80, 16);
			this.label6.TabIndex = 143;
			this.label6.Text = "Fornitore";
			this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// cmbCausale
			// 
			this.cmbCausale.DataSource = this.DS.tipomovimento;
			this.cmbCausale.DisplayMember = "descrizione";
			this.cmbCausale.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World, ((byte)(0)));
			this.cmbCausale.ItemHeight = 13;
			this.cmbCausale.Location = new System.Drawing.Point(119, 146);
			this.cmbCausale.Name = "cmbCausale";
			this.cmbCausale.Size = new System.Drawing.Size(256, 21);
			this.cmbCausale.TabIndex = 142;
			this.cmbCausale.ValueMember = "idtipo";
			// 
			// labelCausale
			// 
			this.labelCausale.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World, ((byte)(0)));
			this.labelCausale.Location = new System.Drawing.Point(63, 146);
			this.labelCausale.Name = "labelCausale";
			this.labelCausale.Size = new System.Drawing.Size(48, 23);
			this.labelCausale.TabIndex = 141;
			this.labelCausale.Text = "Causale";
			this.labelCausale.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// btnDocumento
			// 
			this.btnDocumento.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnDocumento.Location = new System.Drawing.Point(31, 3);
			this.btnDocumento.Name = "btnDocumento";
			this.btnDocumento.Size = new System.Drawing.Size(104, 20);
			this.btnDocumento.TabIndex = 140;
			this.btnDocumento.Text = "Documento IVA";
			this.btnDocumento.Click += new System.EventHandler(this.btnDocumento_Click);
			// 
			// label7
			// 
			this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label7.Location = new System.Drawing.Point(199, 32);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(48, 16);
			this.label7.TabIndex = 136;
			this.label7.Text = "Eserc.";
			this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtNumDoc
			// 
			this.txtNumDoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtNumDoc.Location = new System.Drawing.Point(335, 32);
			this.txtNumDoc.Name = "txtNumDoc";
			this.txtNumDoc.Size = new System.Drawing.Size(64, 20);
			this.txtNumDoc.TabIndex = 139;
			this.txtNumDoc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.txtNumDoc.Leave += new System.EventHandler(this.txtNumDoc_Leave);
			// 
			// label10
			// 
			this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label10.Location = new System.Drawing.Point(303, 32);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(32, 16);
			this.label10.TabIndex = 138;
			this.label10.Text = "Num.";
			this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtEsercDoc
			// 
			this.txtEsercDoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtEsercDoc.Location = new System.Drawing.Point(247, 32);
			this.txtEsercDoc.Name = "txtEsercDoc";
			this.txtEsercDoc.Size = new System.Drawing.Size(56, 20);
			this.txtEsercDoc.TabIndex = 137;
			this.txtEsercDoc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.txtEsercDoc.Leave += new System.EventHandler(this.txtEsercDoc_Leave);
			// 
			// gridDetails
			// 
			this.gridDetails.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.gridDetails.DataMember = "";
			this.gridDetails.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.gridDetails.Location = new System.Drawing.Point(11, 182);
			this.gridDetails.Name = "gridDetails";
			this.gridDetails.Size = new System.Drawing.Size(745, 206);
			this.gridDetails.TabIndex = 135;
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
			this.groupBox2.Location = new System.Drawing.Point(3, 397);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(753, 72);
			this.groupBox2.TabIndex = 126;
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
			this.txtTotGenerale.Size = new System.Drawing.Size(128, 20);
			this.txtTotGenerale.TabIndex = 109;
			// 
			// txtTotIva
			// 
			this.txtTotIva.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.txtTotIva.Location = new System.Drawing.Point(160, 40);
			this.txtTotIva.Name = "txtTotIva";
			this.txtTotIva.ReadOnly = true;
			this.txtTotIva.Size = new System.Drawing.Size(112, 20);
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
			this.txtTotImponibile.Size = new System.Drawing.Size(136, 20);
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
			this.label8.Size = new System.Drawing.Size(128, 16);
			this.label8.TabIndex = 106;
			this.label8.Text = "Totale da contabilizzare";
			// 
			// tabSplit
			// 
			this.tabSplit.Controls.Add(this.grpInfo);
			this.tabSplit.Location = new System.Drawing.Point(4, 22);
			this.tabSplit.Name = "tabSplit";
			this.tabSplit.Size = new System.Drawing.Size(770, 485);
			this.tabSplit.TabIndex = 4;
			this.tabSplit.Text = "Pagina 3 di 4";
			// 
			// grpInfo
			// 
			this.grpInfo.Controls.Add(this.grpTipoDoc);
			this.grpInfo.Controls.Add(this.grpTipoSpesa);
			this.grpInfo.Controls.Add(this.grpDescrizione);
			this.grpInfo.Controls.Add(this.grpFondoEconomale);
			this.grpInfo.Controls.Add(this.txtRimasto);
			this.grpInfo.Controls.Add(this.label3);
			this.grpInfo.Controls.Add(this.txtTotaleFattura);
			this.grpInfo.Controls.Add(this.label2);
			this.grpInfo.Controls.Add(this.btnCancella);
			this.grpInfo.Controls.Add(this.btnAggiungi);
			this.grpInfo.Controls.Add(this.btnModificaInfo);
			this.grpInfo.Controls.Add(this.gridInfo);
			this.grpInfo.Location = new System.Drawing.Point(19, 13);
			this.grpInfo.Name = "grpInfo";
			this.grpInfo.Size = new System.Drawing.Size(743, 455);
			this.grpInfo.TabIndex = 129;
			this.grpInfo.TabStop = false;
			// 
			// grpTipoDoc
			// 
			this.grpTipoDoc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.grpTipoDoc.Controls.Add(this.label9);
			this.grpTipoDoc.Controls.Add(this.txtDocumento);
			this.grpTipoDoc.Controls.Add(this.txtDataDoc);
			this.grpTipoDoc.Controls.Add(this.label11);
			this.grpTipoDoc.Location = new System.Drawing.Point(359, 336);
			this.grpTipoDoc.Name = "grpTipoDoc";
			this.grpTipoDoc.Size = new System.Drawing.Size(370, 73);
			this.grpTipoDoc.TabIndex = 130;
			this.grpTipoDoc.TabStop = false;
			this.grpTipoDoc.Text = "Documento collegato";
			// 
			// label9
			// 
			this.label9.Location = new System.Drawing.Point(142, 17);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(72, 16);
			this.label9.TabIndex = 10;
			this.label9.Text = "Descrizione:";
			this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtDocumento
			// 
			this.txtDocumento.Location = new System.Drawing.Point(6, 33);
			this.txtDocumento.Name = "txtDocumento";
			this.txtDocumento.Size = new System.Drawing.Size(208, 20);
			this.txtDocumento.TabIndex = 1;
			this.txtDocumento.Tag = "pettycashoperation.doc";
			// 
			// txtDataDoc
			// 
			this.txtDataDoc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtDataDoc.Location = new System.Drawing.Point(230, 33);
			this.txtDataDoc.Name = "txtDataDoc";
			this.txtDataDoc.Size = new System.Drawing.Size(130, 20);
			this.txtDataDoc.TabIndex = 2;
			this.txtDataDoc.Tag = "pettycashoperation.docdate";
			// 
			// label11
			// 
			this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.label11.Location = new System.Drawing.Point(230, 17);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(82, 16);
			this.label11.TabIndex = 9;
			this.label11.Text = "Data:";
			this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// grpTipoSpesa
			// 
			this.grpTipoSpesa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.grpTipoSpesa.Controls.Add(this.chkDocumentata);
			this.grpTipoSpesa.Location = new System.Drawing.Point(359, 273);
			this.grpTipoSpesa.Name = "grpTipoSpesa";
			this.grpTipoSpesa.Size = new System.Drawing.Size(370, 59);
			this.grpTipoSpesa.TabIndex = 129;
			this.grpTipoSpesa.TabStop = false;
			this.grpTipoSpesa.Text = "Tipo di spesa";
			// 
			// chkDocumentata
			// 
			this.chkDocumentata.Location = new System.Drawing.Point(224, 15);
			this.chkDocumentata.Name = "chkDocumentata";
			this.chkDocumentata.Size = new System.Drawing.Size(136, 25);
			this.chkDocumentata.TabIndex = 1;
			this.chkDocumentata.Tag = "";
			this.chkDocumentata.Text = "Spese Documentate";
			// 
			// grpDescrizione
			// 
			this.grpDescrizione.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.grpDescrizione.Controls.Add(this.txtDescrizione);
			this.grpDescrizione.Location = new System.Drawing.Point(15, 336);
			this.grpDescrizione.Name = "grpDescrizione";
			this.grpDescrizione.Size = new System.Drawing.Size(338, 73);
			this.grpDescrizione.TabIndex = 128;
			this.grpDescrizione.TabStop = false;
			this.grpDescrizione.Text = "Descrizione";
			// 
			// txtDescrizione
			// 
			this.txtDescrizione.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtDescrizione.Location = new System.Drawing.Point(8, 16);
			this.txtDescrizione.Multiline = true;
			this.txtDescrizione.Name = "txtDescrizione";
			this.txtDescrizione.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtDescrizione.Size = new System.Drawing.Size(322, 40);
			this.txtDescrizione.TabIndex = 1;
			this.txtDescrizione.Tag = "pettycashoperation.description";
			// 
			// grpFondoEconomale
			// 
			this.grpFondoEconomale.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.grpFondoEconomale.Controls.Add(this.cmbFondoPS);
			this.grpFondoEconomale.Location = new System.Drawing.Point(15, 273);
			this.grpFondoEconomale.Name = "grpFondoEconomale";
			this.grpFondoEconomale.Size = new System.Drawing.Size(336, 57);
			this.grpFondoEconomale.TabIndex = 127;
			this.grpFondoEconomale.TabStop = false;
			this.grpFondoEconomale.Text = "Fondo Economale";
			// 
			// cmbFondoPS
			// 
			this.cmbFondoPS.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.cmbFondoPS.DataSource = this.DS.pettycash;
			this.cmbFondoPS.DisplayMember = "description";
			this.cmbFondoPS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbFondoPS.Location = new System.Drawing.Point(10, 17);
			this.cmbFondoPS.Name = "cmbFondoPS";
			this.cmbFondoPS.Size = new System.Drawing.Size(320, 21);
			this.cmbFondoPS.TabIndex = 1;
			this.cmbFondoPS.Tag = "";
			this.cmbFondoPS.ValueMember = "idpettycash";
			// 
			// txtRimasto
			// 
			this.txtRimasto.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.txtRimasto.Location = new System.Drawing.Point(599, 24);
			this.txtRimasto.Name = "txtRimasto";
			this.txtRimasto.ReadOnly = true;
			this.txtRimasto.Size = new System.Drawing.Size(128, 20);
			this.txtRimasto.TabIndex = 121;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(457, 27);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(136, 24);
			this.label3.TabIndex = 120;
			this.label3.Text = "Importo non assegnato";
			// 
			// txtTotaleFattura
			// 
			this.txtTotaleFattura.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.txtTotaleFattura.Location = new System.Drawing.Point(208, 24);
			this.txtTotaleFattura.Name = "txtTotaleFattura";
			this.txtTotaleFattura.ReadOnly = true;
			this.txtTotaleFattura.Size = new System.Drawing.Size(128, 20);
			this.txtTotaleFattura.TabIndex = 119;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(102, 24);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(100, 16);
			this.label2.TabIndex = 118;
			this.label2.Text = "Totale Fattura";
			// 
			// btnCancella
			// 
			this.btnCancella.Location = new System.Drawing.Point(15, 138);
			this.btnCancella.Name = "btnCancella";
			this.btnCancella.Size = new System.Drawing.Size(75, 23);
			this.btnCancella.TabIndex = 117;
			this.btnCancella.Tag = "";
			this.btnCancella.Text = "Cancella";
			this.btnCancella.Click += new System.EventHandler(this.btnCancella_Click);
			// 
			// btnAggiungi
			// 
			this.btnAggiungi.Location = new System.Drawing.Point(15, 54);
			this.btnAggiungi.Name = "btnAggiungi";
			this.btnAggiungi.Size = new System.Drawing.Size(75, 23);
			this.btnAggiungi.TabIndex = 116;
			this.btnAggiungi.Tag = "";
			this.btnAggiungi.Text = "Aggiungi";
			this.btnAggiungi.Click += new System.EventHandler(this.btnAggiungi_Click);
			// 
			// btnModificaInfo
			// 
			this.btnModificaInfo.Location = new System.Drawing.Point(15, 96);
			this.btnModificaInfo.Name = "btnModificaInfo";
			this.btnModificaInfo.Size = new System.Drawing.Size(75, 23);
			this.btnModificaInfo.TabIndex = 114;
			this.btnModificaInfo.Tag = "";
			this.btnModificaInfo.Text = "Modifica";
			this.btnModificaInfo.Click += new System.EventHandler(this.btnModificaInfo_Click);
			// 
			// gridInfo
			// 
			this.gridInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.gridInfo.CaptionVisible = false;
			this.gridInfo.DataMember = "";
			this.gridInfo.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.gridInfo.Location = new System.Drawing.Point(105, 54);
			this.gridInfo.Name = "gridInfo";
			this.gridInfo.Size = new System.Drawing.Size(622, 213);
			this.gridInfo.TabIndex = 115;
			this.gridInfo.Tag = "";
			// 
			// tabSave
			// 
			this.tabSave.Controls.Add(this.label12);
			this.tabSave.Controls.Add(this.gridMovSpesa);
			this.tabSave.Location = new System.Drawing.Point(4, 22);
			this.tabSave.Name = "tabSave";
			this.tabSave.Size = new System.Drawing.Size(770, 485);
			this.tabSave.TabIndex = 5;
			this.tabSave.Text = "Pagina 4 di 4";
			// 
			// label12
			// 
			this.label12.AutoSize = true;
			this.label12.Location = new System.Drawing.Point(110, 29);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(510, 13);
			this.label12.TabIndex = 116;
			this.label12.Text = "Avvertimento: se l\'operazione viene confermata, verranno generate le seguenti ope" +
    "razioni di piccola spesa.\r\n";
			// 
			// gridMovSpesa
			// 
			this.gridMovSpesa.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.gridMovSpesa.DataMember = "";
			this.gridMovSpesa.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.gridMovSpesa.Location = new System.Drawing.Point(25, 47);
			this.gridMovSpesa.Name = "gridMovSpesa";
			this.gridMovSpesa.Size = new System.Drawing.Size(728, 413);
			this.gridMovSpesa.TabIndex = 115;
			// 
			// Frm_pettycashoperation_wizardinvoicedetail
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(802, 579);
			this.Controls.Add(this.tabController);
			this.Controls.Add(this.btnInserisciClassificazioni);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnNext);
			this.Controls.Add(this.btnBack);
			this.Name = "Frm_pettycashoperation_wizardinvoicedetail";
			this.Text = "Frm_pettycashoperation_wizardinvoicedetail";
			((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
			this.tabController.ResumeLayout(false);
			this.tabIntro.ResumeLayout(false);
			this.tabSetDetail.ResumeLayout(false);
			this.tabSetDetail.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.gridDetails)).EndInit();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.tabSplit.ResumeLayout(false);
			this.grpInfo.ResumeLayout(false);
			this.grpInfo.PerformLayout();
			this.grpTipoDoc.ResumeLayout(false);
			this.grpTipoDoc.PerformLayout();
			this.grpTipoSpesa.ResumeLayout(false);
			this.grpDescrizione.ResumeLayout(false);
			this.grpDescrizione.PerformLayout();
			this.grpFondoEconomale.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.gridInfo)).EndInit();
			this.tabSave.ResumeLayout(false);
			this.tabSave.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.gridMovSpesa)).EndInit();
			this.ResumeLayout(false);

        }

        #endregion

        public vistaForm DS;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnInserisciClassificazioni;

		private System.Windows.Forms.TabControl tabController;
		private System.Windows.Forms.TabPage tabIntro;
		private System.Windows.Forms.TabPage tabSetDetail;
		private System.Windows.Forms.TabPage tabSplit;
		private System.Windows.Forms.TabPage tabSave;

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.TextBox txtTotGenerale;
		private System.Windows.Forms.TextBox txtTotIva;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox txtTotImponibile;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.DataGrid gridDetails;
		private System.Windows.Forms.ComboBox cmbTipoFattura;
		private System.Windows.Forms.TextBox txtDescrFattura;
		private System.Windows.Forms.Label labDescrFattura;
		private System.Windows.Forms.TextBox txtFornitore;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.ComboBox cmbCausale;
		private System.Windows.Forms.Label labelCausale;
		private System.Windows.Forms.Button btnDocumento;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox txtNumDoc;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.TextBox txtEsercDoc;
		private System.Windows.Forms.GroupBox grpInfo;
		private System.Windows.Forms.TextBox txtRimasto;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox txtTotaleFattura;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button btnCancella;
		private System.Windows.Forms.Button btnAggiungi;
		private System.Windows.Forms.Button btnModificaInfo;
		private System.Windows.Forms.DataGrid gridInfo;
		private System.Windows.Forms.GroupBox grpTipoDoc;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.TextBox txtDocumento;
		private System.Windows.Forms.TextBox txtDataDoc;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.GroupBox grpTipoSpesa;
		private System.Windows.Forms.CheckBox chkDocumentata;
		private System.Windows.Forms.GroupBox grpDescrizione;
		private System.Windows.Forms.TextBox txtDescrizione;
		private System.Windows.Forms.GroupBox grpFondoEconomale;
		private System.Windows.Forms.ComboBox cmbFondoPS;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.DataGrid gridMovSpesa;
	}
}
