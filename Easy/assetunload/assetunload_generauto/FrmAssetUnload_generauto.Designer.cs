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

ï»¿namespace assetunload_generauto {
    partial class FrmAssetUnload_generauto {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Liberare le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.grpElabora = new System.Windows.Forms.GroupBox();
            this.btnNo = new System.Windows.Forms.Button();
            this.btnSi = new System.Windows.Forms.Button();
            this.btnGeneraTutto = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBoxDataProvvedimento = new System.Windows.Forms.TextBox();
            this.textBoxProvvedimento = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtNumero = new System.Windows.Forms.TextBox();
            this.textBoxDescrizione = new System.Windows.Forms.TextBox();
            this.grpRatifica = new System.Windows.Forms.GroupBox();
            this.btnScollegaMov = new System.Windows.Forms.Button();
            this.gridRatifica = new System.Windows.Forms.DataGrid();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDataRatifica = new System.Windows.Forms.TextBox();
            this.btnCollegaMov = new System.Windows.Forms.Button();
            this.btnSuccessivo = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtDataContabile = new System.Windows.Forms.TextBox();
            this.grpDocumento = new System.Windows.Forms.GroupBox();
            this.textBoxDocumento = new System.Windows.Forms.TextBox();
            this.textBoxDataDocumento = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.grpIncludi = new System.Windows.Forms.GroupBox();
            this.button4 = new System.Windows.Forms.Button();
            this.rdoParte = new System.Windows.Forms.RadioButton();
            this.btnInizia = new System.Windows.Forms.Button();
            this.rdoAll = new System.Windows.Forms.RadioButton();
            this.rdoBene = new System.Windows.Forms.RadioButton();
            this.cboTipo = new System.Windows.Forms.ComboBox();
            this.grpScaricoBene = new System.Windows.Forms.GroupBox();
            this.btnDeselBene = new System.Windows.Forms.Button();
            this.btnAddBene = new System.Windows.Forms.Button();
            this.dgrCaricoBene = new System.Windows.Forms.DataGrid();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.txtEsercizio = new System.Windows.Forms.TextBox();
            this.grpCausale = new System.Windows.Forms.GroupBox();
            this.txtCausale = new System.Windows.Forms.TextBox();
            this.grpCred = new System.Windows.Forms.GroupBox();
            this.txtCredDeb = new System.Windows.Forms.TextBox();
            this.btnChiudi = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.DS = new assetunload_generauto.vistaForm();
            this.Tip = new System.Windows.Forms.ToolTip(this.components);
            this.grpElabora.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.grpRatifica.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridRatifica)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.grpDocumento.SuspendLayout();
            this.grpIncludi.SuspendLayout();
            this.grpScaricoBene.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrCaricoBene)).BeginInit();
            this.groupBox5.SuspendLayout();
            this.grpCausale.SuspendLayout();
            this.grpCred.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.SuspendLayout();
            // 
            // grpElabora
            // 
            this.grpElabora.Controls.Add(this.btnNo);
            this.grpElabora.Controls.Add(this.btnSi);
            this.grpElabora.Controls.Add(this.btnGeneraTutto);
            this.grpElabora.Location = new System.Drawing.Point(632, 131);
            this.grpElabora.Name = "grpElabora";
            this.grpElabora.Size = new System.Drawing.Size(104, 112);
            this.grpElabora.TabIndex = 130;
            this.grpElabora.TabStop = false;
            this.grpElabora.Text = "Conferma";
            // 
            // btnNo
            // 
            this.btnNo.Location = new System.Drawing.Point(8, 80);
            this.btnNo.Name = "btnNo";
            this.btnNo.Size = new System.Drawing.Size(88, 24);
            this.btnNo.TabIndex = 2;
            this.btnNo.Text = "No";
            this.btnNo.Click += new System.EventHandler(this.btnNo_Click);
            // 
            // btnSi
            // 
            this.btnSi.Location = new System.Drawing.Point(8, 16);
            this.btnSi.Name = "btnSi";
            this.btnSi.Size = new System.Drawing.Size(88, 24);
            this.btnSi.TabIndex = 0;
            this.btnSi.Text = "Si";
            this.btnSi.Click += new System.EventHandler(this.btnSi_Click);
            // 
            // btnGeneraTutto
            // 
            this.btnGeneraTutto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGeneraTutto.Enabled = false;
            this.btnGeneraTutto.Location = new System.Drawing.Point(8, 48);
            this.btnGeneraTutto.Name = "btnGeneraTutto";
            this.btnGeneraTutto.Size = new System.Drawing.Size(88, 24);
            this.btnGeneraTutto.TabIndex = 3;
            this.btnGeneraTutto.Text = "Si tutti";
            this.btnGeneraTutto.Click += new System.EventHandler(this.btnGeneraTutto_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBoxDataProvvedimento);
            this.groupBox1.Controls.Add(this.textBoxProvvedimento);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Location = new System.Drawing.Point(168, 187);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(160, 72);
            this.groupBox1.TabIndex = 129;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Provvedimento";
            // 
            // textBoxDataProvvedimento
            // 
            this.textBoxDataProvvedimento.Location = new System.Drawing.Point(64, 16);
            this.textBoxDataProvvedimento.Name = "textBoxDataProvvedimento";
            this.textBoxDataProvvedimento.Size = new System.Drawing.Size(88, 20);
            this.textBoxDataProvvedimento.TabIndex = 109;
            this.textBoxDataProvvedimento.Tag = "assetunload.enactmentdate";
            // 
            // textBoxProvvedimento
            // 
            this.textBoxProvvedimento.Location = new System.Drawing.Point(64, 48);
            this.textBoxProvvedimento.Name = "textBoxProvvedimento";
            this.textBoxProvvedimento.Size = new System.Drawing.Size(88, 20);
            this.textBoxProvvedimento.TabIndex = 111;
            this.textBoxProvvedimento.Tag = "assetunload.enactment";
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(8, 16);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 20);
            this.label7.TabIndex = 108;
            this.label7.Text = "Data";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(8, 48);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(64, 20);
            this.label8.TabIndex = 110;
            this.label8.Text = "Numero";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtNumero);
            this.groupBox3.Location = new System.Drawing.Point(184, 43);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(144, 48);
            this.groupBox3.TabIndex = 128;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Numero";
            // 
            // txtNumero
            // 
            this.txtNumero.Location = new System.Drawing.Point(8, 16);
            this.txtNumero.Name = "txtNumero";
            this.txtNumero.ReadOnly = true;
            this.txtNumero.Size = new System.Drawing.Size(128, 20);
            this.txtNumero.TabIndex = 61;
            this.txtNumero.Tag = "assetunload.nassetunload";
            // 
            // textBoxDescrizione
            // 
            this.textBoxDescrizione.Location = new System.Drawing.Point(336, 203);
            this.textBoxDescrizione.Multiline = true;
            this.textBoxDescrizione.Name = "textBoxDescrizione";
            this.textBoxDescrizione.Size = new System.Drawing.Size(288, 48);
            this.textBoxDescrizione.TabIndex = 127;
            this.textBoxDescrizione.Tag = "assetunload.description";
            // 
            // grpRatifica
            // 
            this.grpRatifica.Controls.Add(this.btnScollegaMov);
            this.grpRatifica.Controls.Add(this.gridRatifica);
            this.grpRatifica.Controls.Add(this.label1);
            this.grpRatifica.Controls.Add(this.txtDataRatifica);
            this.grpRatifica.Controls.Add(this.btnCollegaMov);
            this.grpRatifica.Location = new System.Drawing.Point(336, 51);
            this.grpRatifica.Name = "grpRatifica";
            this.grpRatifica.Size = new System.Drawing.Size(296, 136);
            this.grpRatifica.TabIndex = 125;
            this.grpRatifica.TabStop = false;
            this.grpRatifica.Text = "Ratifica";
            // 
            // btnScollegaMov
            // 
            this.btnScollegaMov.Location = new System.Drawing.Point(216, 14);
            this.btnScollegaMov.Name = "btnScollegaMov";
            this.btnScollegaMov.Size = new System.Drawing.Size(64, 24);
            this.btnScollegaMov.TabIndex = 181;
            this.btnScollegaMov.Tag = "";
            this.btnScollegaMov.Text = "Scollega";
            this.btnScollegaMov.Click += new System.EventHandler(this.btnScollegaMov_Click);
            // 
            // gridRatifica
            // 
            this.gridRatifica.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gridRatifica.CaptionVisible = false;
            this.gridRatifica.DataMember = "";
            this.gridRatifica.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.gridRatifica.Location = new System.Drawing.Point(8, 48);
            this.gridRatifica.Name = "gridRatifica";
            this.gridRatifica.Size = new System.Drawing.Size(280, 80);
            this.gridRatifica.TabIndex = 180;
            this.gridRatifica.Tag = "assetunloadincome.buonodiscarico";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(8, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 16);
            this.label1.TabIndex = 179;
            this.label1.Text = "Data";
            // 
            // txtDataRatifica
            // 
            this.txtDataRatifica.Location = new System.Drawing.Point(40, 16);
            this.txtDataRatifica.Name = "txtDataRatifica";
            this.txtDataRatifica.ReadOnly = true;
            this.txtDataRatifica.Size = new System.Drawing.Size(80, 20);
            this.txtDataRatifica.TabIndex = 178;
            this.txtDataRatifica.Tag = "assetunload.ratificationdate";
            // 
            // btnCollegaMov
            // 
            this.btnCollegaMov.Location = new System.Drawing.Point(128, 14);
            this.btnCollegaMov.Name = "btnCollegaMov";
            this.btnCollegaMov.Size = new System.Drawing.Size(80, 24);
            this.btnCollegaMov.TabIndex = 177;
            this.btnCollegaMov.Tag = "";
            this.btnCollegaMov.Text = "Collega mov.";
            this.btnCollegaMov.Click += new System.EventHandler(this.btnCollegaMov_Click);
            // 
            // btnSuccessivo
            // 
            this.btnSuccessivo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSuccessivo.Enabled = false;
            this.btnSuccessivo.Location = new System.Drawing.Point(640, 51);
            this.btnSuccessivo.Name = "btnSuccessivo";
            this.btnSuccessivo.Size = new System.Drawing.Size(88, 24);
            this.btnSuccessivo.TabIndex = 124;
            this.btnSuccessivo.Text = "Prossimo";
            this.btnSuccessivo.Click += new System.EventHandler(this.btnSuccessivo_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtDataContabile);
            this.groupBox2.Location = new System.Drawing.Point(8, 43);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(104, 48);
            this.groupBox2.TabIndex = 123;
            this.groupBox2.TabStop = false;
            this.groupBox2.Tag = "";
            this.groupBox2.Text = "Data contabile";
            // 
            // txtDataContabile
            // 
            this.txtDataContabile.Location = new System.Drawing.Point(8, 16);
            this.txtDataContabile.Name = "txtDataContabile";
            this.txtDataContabile.ReadOnly = true;
            this.txtDataContabile.Size = new System.Drawing.Size(88, 20);
            this.txtDataContabile.TabIndex = 87;
            this.txtDataContabile.Tag = "assetunload.adate";
            // 
            // grpDocumento
            // 
            this.grpDocumento.Controls.Add(this.textBoxDocumento);
            this.grpDocumento.Controls.Add(this.textBoxDataDocumento);
            this.grpDocumento.Controls.Add(this.label5);
            this.grpDocumento.Controls.Add(this.label6);
            this.grpDocumento.Location = new System.Drawing.Point(8, 187);
            this.grpDocumento.Name = "grpDocumento";
            this.grpDocumento.Size = new System.Drawing.Size(152, 72);
            this.grpDocumento.TabIndex = 122;
            this.grpDocumento.TabStop = false;
            this.grpDocumento.Text = "Documento";
            // 
            // textBoxDocumento
            // 
            this.textBoxDocumento.Location = new System.Drawing.Point(56, 48);
            this.textBoxDocumento.Name = "textBoxDocumento";
            this.textBoxDocumento.Size = new System.Drawing.Size(88, 20);
            this.textBoxDocumento.TabIndex = 107;
            this.textBoxDocumento.Tag = "assetunload.doc";
            // 
            // textBoxDataDocumento
            // 
            this.textBoxDataDocumento.Location = new System.Drawing.Point(56, 16);
            this.textBoxDataDocumento.Name = "textBoxDataDocumento";
            this.textBoxDataDocumento.Size = new System.Drawing.Size(88, 20);
            this.textBoxDataDocumento.TabIndex = 105;
            this.textBoxDataDocumento.Tag = "assetunload.docdate";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(8, 48);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 20);
            this.label5.TabIndex = 106;
            this.label5.Text = "Numero";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(8, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 20);
            this.label6.TabIndex = 104;
            this.label6.Text = "Data";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // grpIncludi
            // 
            this.grpIncludi.Controls.Add(this.button4);
            this.grpIncludi.Controls.Add(this.rdoParte);
            this.grpIncludi.Controls.Add(this.btnInizia);
            this.grpIncludi.Controls.Add(this.rdoAll);
            this.grpIncludi.Controls.Add(this.rdoBene);
            this.grpIncludi.Controls.Add(this.cboTipo);
            this.grpIncludi.Location = new System.Drawing.Point(8, 3);
            this.grpIncludi.Name = "grpIncludi";
            this.grpIncludi.Size = new System.Drawing.Size(728, 40);
            this.grpIncludi.TabIndex = 116;
            this.grpIncludi.TabStop = false;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(312, 8);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(72, 24);
            this.button4.TabIndex = 177;
            this.button4.Tag = "manage.assetunloadkind.default";
            this.button4.Text = "Tipo buono";
            // 
            // rdoParte
            // 
            this.rdoParte.Location = new System.Drawing.Point(200, 8);
            this.rdoParte.Name = "rdoParte";
            this.rdoParte.Size = new System.Drawing.Size(112, 24);
            this.rdoParte.TabIndex = 2;
            this.rdoParte.Text = "Solo accessori";
            // 
            // btnInizia
            // 
            this.btnInizia.Location = new System.Drawing.Point(632, 8);
            this.btnInizia.Name = "btnInizia";
            this.btnInizia.Size = new System.Drawing.Size(88, 24);
            this.btnInizia.TabIndex = 0;
            this.btnInizia.Text = "Inizia Ricerca";
            this.btnInizia.Click += new System.EventHandler(this.btnInizia_Click);
            // 
            // rdoAll
            // 
            this.rdoAll.Checked = true;
            this.rdoAll.Location = new System.Drawing.Point(8, 8);
            this.rdoAll.Name = "rdoAll";
            this.rdoAll.Size = new System.Drawing.Size(56, 24);
            this.rdoAll.TabIndex = 0;
            this.rdoAll.TabStop = true;
            this.rdoAll.Text = "Tutto";
            // 
            // rdoBene
            // 
            this.rdoBene.Location = new System.Drawing.Point(72, 8);
            this.rdoBene.Name = "rdoBene";
            this.rdoBene.Size = new System.Drawing.Size(120, 24);
            this.rdoBene.TabIndex = 1;
            this.rdoBene.Text = "Solo cespiti";
            // 
            // cboTipo
            // 
            this.cboTipo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cboTipo.DisplayMember = "description";
            this.cboTipo.Location = new System.Drawing.Point(392, 8);
            this.cboTipo.Name = "cboTipo";
            this.cboTipo.Size = new System.Drawing.Size(240, 21);
            this.cboTipo.TabIndex = 3;
            this.cboTipo.Tag = "assetunload.idassetunloadkind";
            this.cboTipo.ValueMember = "idassetunloadkind";
            // 
            // grpScaricoBene
            // 
            this.grpScaricoBene.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.grpScaricoBene.Controls.Add(this.btnDeselBene);
            this.grpScaricoBene.Controls.Add(this.btnAddBene);
            this.grpScaricoBene.Controls.Add(this.dgrCaricoBene);
            this.grpScaricoBene.Location = new System.Drawing.Point(8, 259);
            this.grpScaricoBene.Name = "grpScaricoBene";
            this.grpScaricoBene.Size = new System.Drawing.Size(728, 270);
            this.grpScaricoBene.TabIndex = 120;
            this.grpScaricoBene.TabStop = false;
            this.grpScaricoBene.Text = "Cespiti e aumenti di  valore da scaricare";
            // 
            // btnDeselBene
            // 
            this.btnDeselBene.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeselBene.Location = new System.Drawing.Point(632, 80);
            this.btnDeselBene.Name = "btnDeselBene";
            this.btnDeselBene.Size = new System.Drawing.Size(88, 47);
            this.btnDeselBene.TabIndex = 74;
            this.btnDeselBene.Text = "Annulla Selezione";
            this.btnDeselBene.Click += new System.EventHandler(this.btnDeselBene_Click);
            // 
            // btnAddBene
            // 
            this.btnAddBene.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddBene.Enabled = false;
            this.btnAddBene.Location = new System.Drawing.Point(632, 24);
            this.btnAddBene.Name = "btnAddBene";
            this.btnAddBene.Size = new System.Drawing.Size(88, 48);
            this.btnAddBene.TabIndex = 73;
            this.btnAddBene.Text = "Seleziona tutti i cespiti";
            this.btnAddBene.Click += new System.EventHandler(this.btnAddBene_Click);
            // 
            // dgrCaricoBene
            // 
            this.dgrCaricoBene.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgrCaricoBene.CaptionVisible = false;
            this.dgrCaricoBene.DataMember = "";
            this.dgrCaricoBene.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dgrCaricoBene.Location = new System.Drawing.Point(8, 16);
            this.dgrCaricoBene.Name = "dgrCaricoBene";
            this.dgrCaricoBene.Size = new System.Drawing.Size(616, 246);
            this.dgrCaricoBene.TabIndex = 3;
            this.dgrCaricoBene.TabStop = false;
            this.dgrCaricoBene.Tag = "assetpieceview.buonoscarico";
            this.dgrCaricoBene.Paint += new System.Windows.Forms.PaintEventHandler(this.dgrCaricoBene_Paint);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.txtEsercizio);
            this.groupBox5.Location = new System.Drawing.Point(112, 43);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(72, 48);
            this.groupBox5.TabIndex = 117;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Esercizio";
            // 
            // txtEsercizio
            // 
            this.txtEsercizio.Location = new System.Drawing.Point(8, 16);
            this.txtEsercizio.Name = "txtEsercizio";
            this.txtEsercizio.ReadOnly = true;
            this.txtEsercizio.Size = new System.Drawing.Size(56, 20);
            this.txtEsercizio.TabIndex = 59;
            this.txtEsercizio.Tag = "assetunload.yassetunload.year";
            // 
            // grpCausale
            // 
            this.grpCausale.Controls.Add(this.txtCausale);
            this.grpCausale.Location = new System.Drawing.Point(8, 139);
            this.grpCausale.Name = "grpCausale";
            this.grpCausale.Size = new System.Drawing.Size(320, 48);
            this.grpCausale.TabIndex = 119;
            this.grpCausale.TabStop = false;
            this.grpCausale.Tag = "";
            this.grpCausale.Text = "Causale di scarico";
            // 
            // txtCausale
            // 
            this.txtCausale.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCausale.Location = new System.Drawing.Point(8, 16);
            this.txtCausale.Name = "txtCausale";
            this.txtCausale.ReadOnly = true;
            this.txtCausale.Size = new System.Drawing.Size(304, 20);
            this.txtCausale.TabIndex = 2;
            this.txtCausale.Tag = "assetunloadmotive.description";
            // 
            // grpCred
            // 
            this.grpCred.Controls.Add(this.txtCredDeb);
            this.grpCred.Location = new System.Drawing.Point(8, 91);
            this.grpCred.Name = "grpCred";
            this.grpCred.Size = new System.Drawing.Size(320, 48);
            this.grpCred.TabIndex = 118;
            this.grpCred.TabStop = false;
            this.grpCred.Tag = "AutoChoose.txtCredDeb.default";
            this.grpCred.Text = "Cessionario";
            // 
            // txtCredDeb
            // 
            this.txtCredDeb.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCredDeb.Location = new System.Drawing.Point(8, 16);
            this.txtCredDeb.Name = "txtCredDeb";
            this.txtCredDeb.ReadOnly = true;
            this.txtCredDeb.Size = new System.Drawing.Size(304, 20);
            this.txtCredDeb.TabIndex = 1;
            this.txtCredDeb.Tag = "registry.title?assetunloadview.title";
            // 
            // btnChiudi
            // 
            this.btnChiudi.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnChiudi.Location = new System.Drawing.Point(640, 91);
            this.btnChiudi.Name = "btnChiudi";
            this.btnChiudi.Size = new System.Drawing.Size(88, 24);
            this.btnChiudi.TabIndex = 115;
            this.btnChiudi.Text = "Termina";
            this.btnChiudi.Click += new System.EventHandler(this.btnChiudi_Click);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(336, 187);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 16);
            this.label4.TabIndex = 126;
            this.label4.Text = "Descrizione";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // FrmAssetUnload_generauto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(744, 534);
            this.Controls.Add(this.grpElabora);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.textBoxDescrizione);
            this.Controls.Add(this.grpRatifica);
            this.Controls.Add(this.btnSuccessivo);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.grpDocumento);
            this.Controls.Add(this.grpIncludi);
            this.Controls.Add(this.grpScaricoBene);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.grpCausale);
            this.Controls.Add(this.grpCred);
            this.Controls.Add(this.btnChiudi);
            this.Controls.Add(this.label4);
            this.Name = "FrmAssetUnload_generauto";
            this.Text = "FrmAssetUnload_generauto";
            this.grpElabora.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.grpRatifica.ResumeLayout(false);
            this.grpRatifica.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridRatifica)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.grpDocumento.ResumeLayout(false);
            this.grpDocumento.PerformLayout();
            this.grpIncludi.ResumeLayout(false);
            this.grpScaricoBene.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgrCaricoBene)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.grpCausale.ResumeLayout(false);
            this.grpCausale.PerformLayout();
            this.grpCred.ResumeLayout(false);
            this.grpCred.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grpElabora;
        private System.Windows.Forms.Button btnNo;
        private System.Windows.Forms.Button btnSi;
        private System.Windows.Forms.Button btnGeneraTutto;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBoxDataProvvedimento;
        private System.Windows.Forms.TextBox textBoxProvvedimento;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtNumero;
        private System.Windows.Forms.TextBox textBoxDescrizione;
        private System.Windows.Forms.GroupBox grpRatifica;
        private System.Windows.Forms.Button btnScollegaMov;
        private System.Windows.Forms.DataGrid gridRatifica;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDataRatifica;
        private System.Windows.Forms.Button btnCollegaMov;
        private System.Windows.Forms.Button btnSuccessivo;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtDataContabile;
        private System.Windows.Forms.GroupBox grpDocumento;
        private System.Windows.Forms.TextBox textBoxDocumento;
        private System.Windows.Forms.TextBox textBoxDataDocumento;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox grpIncludi;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.RadioButton rdoParte;
        private System.Windows.Forms.Button btnInizia;
        private System.Windows.Forms.RadioButton rdoAll;
        private System.Windows.Forms.RadioButton rdoBene;
        private System.Windows.Forms.ComboBox cboTipo;
        private System.Windows.Forms.GroupBox grpScaricoBene;
        private System.Windows.Forms.Button btnDeselBene;
        private System.Windows.Forms.Button btnAddBene;
        private System.Windows.Forms.DataGrid dgrCaricoBene;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox txtEsercizio;
        private System.Windows.Forms.GroupBox grpCausale;
        private System.Windows.Forms.TextBox txtCausale;
        private System.Windows.Forms.GroupBox grpCred;
        private System.Windows.Forms.TextBox txtCredDeb;
        private System.Windows.Forms.Button btnChiudi;
        private System.Windows.Forms.Label label4;
        public vistaForm DS;
        private System.Windows.Forms.ToolTip Tip;
    }
}