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

namespace stock_ddt_in {
    partial class FrmStock_ddt_in {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.DS = new stock_ddt_in.vistaForm();
            this.grpRiga = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbTipoOrdine = new System.Windows.Forms.ComboBox();
            this.txtNumriga = new System.Windows.Forms.TextBox();
            this.txtNumordine = new System.Windows.Forms.TextBox();
            this.txtEsercordine = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbTipoFattura = new System.Windows.Forms.ComboBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtQuantita = new System.Windows.Forms.TextBox();
            this.lblQuantita = new System.Windows.Forms.Label();
            this.gboxListino = new System.Windows.Forms.GroupBox();
            this.txtCoeffConversione = new System.Windows.Forms.TextBox();
            this.label29 = new System.Windows.Forms.Label();
            this.cmbUnitaMisuraAcquisto = new System.Windows.Forms.ComboBox();
            this.lblIcmbdpackage = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.cmbUnitaMisuraCS = new System.Windows.Forms.ComboBox();
            this.btnListino = new System.Windows.Forms.Button();
            this.txtListino = new System.Windows.Forms.TextBox();
            this.txtDescrizioneListino = new System.Windows.Forms.TextBox();
            this.txtValiditystop = new System.Windows.Forms.TextBox();
            this.lblQuantitaConfezioni = new System.Windows.Forms.Label();
            this.txtQuantitaConfezioni = new System.Windows.Forms.TextBox();
            this.btnAnnulla = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.lblScadenza = new System.Windows.Forms.Label();
            this.pbox = new System.Windows.Forms.PictureBox();
            this.cmbCausaleCarico = new System.Windows.Forms.ComboBox();
            this.labCausale = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtResidual = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.chkUnload = new System.Windows.Forms.CheckBox();
            this.grpUbicazione = new System.Windows.Forms.GroupBox();
            this.txtDescUbicazione = new System.Windows.Forms.TextBox();
            this.txtIdUbicazione = new System.Windows.Forms.TextBox();
            this.btnUbicazione = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.grpRiga.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.gboxListino.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbox)).BeginInit();
            this.grpUbicazione.SuspendLayout();
            this.SuspendLayout();
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.EnforceConstraints = false;
            // 
            // grpRiga
            // 
            this.grpRiga.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grpRiga.Controls.Add(this.label6);
            this.grpRiga.Controls.Add(this.cmbTipoOrdine);
            this.grpRiga.Controls.Add(this.txtNumriga);
            this.grpRiga.Controls.Add(this.txtNumordine);
            this.grpRiga.Controls.Add(this.txtEsercordine);
            this.grpRiga.Controls.Add(this.label2);
            this.grpRiga.Enabled = false;
            this.grpRiga.Location = new System.Drawing.Point(13, 324);
            this.grpRiga.Name = "grpRiga";
            this.grpRiga.Size = new System.Drawing.Size(677, 48);
            this.grpRiga.TabIndex = 16;
            this.grpRiga.TabStop = false;
            this.grpRiga.Text = "Riga del Contratto Passivo collegato (Tipo  / Eserc. /  Num.  / Riga)";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 23);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(90, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Contratto Passivo";
            // 
            // cmbTipoOrdine
            // 
            this.cmbTipoOrdine.DataSource = this.DS.mandatekind;
            this.cmbTipoOrdine.DisplayMember = "description";
            this.cmbTipoOrdine.Location = new System.Drawing.Point(109, 20);
            this.cmbTipoOrdine.Name = "cmbTipoOrdine";
            this.cmbTipoOrdine.Size = new System.Drawing.Size(266, 21);
            this.cmbTipoOrdine.TabIndex = 2;
            this.cmbTipoOrdine.TabStop = false;
            this.cmbTipoOrdine.Tag = "stock.idmankind";
            this.cmbTipoOrdine.ValueMember = "idmankind";
            // 
            // txtNumriga
            // 
            this.txtNumriga.Location = new System.Drawing.Point(528, 23);
            this.txtNumriga.Name = "txtNumriga";
            this.txtNumriga.Size = new System.Drawing.Size(64, 20);
            this.txtNumriga.TabIndex = 5;
            this.txtNumriga.TabStop = false;
            this.txtNumriga.Tag = "stock.man_idgroup";
            // 
            // txtNumordine
            // 
            this.txtNumordine.Location = new System.Drawing.Point(453, 23);
            this.txtNumordine.Name = "txtNumordine";
            this.txtNumordine.Size = new System.Drawing.Size(69, 20);
            this.txtNumordine.TabIndex = 4;
            this.txtNumordine.TabStop = false;
            this.txtNumordine.Tag = "stock.nman";
            // 
            // txtEsercordine
            // 
            this.txtEsercordine.Location = new System.Drawing.Point(385, 22);
            this.txtEsercordine.Name = "txtEsercordine";
            this.txtEsercordine.Size = new System.Drawing.Size(63, 20);
            this.txtEsercordine.TabIndex = 3;
            this.txtEsercordine.TabStop = false;
            this.txtEsercordine.Tag = "stock.yman.year";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(120, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(136, 16);
            this.label2.TabIndex = 0;
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.cmbTipoFattura);
            this.groupBox1.Controls.Add(this.textBox2);
            this.groupBox1.Controls.Add(this.textBox3);
            this.groupBox1.Controls.Add(this.textBox4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Enabled = false;
            this.groupBox1.Location = new System.Drawing.Point(13, 377);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(677, 48);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Riga della Fattura collegata (Tipo  / Eserc. /  Num.  / Riga)";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 23);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(40, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Fattura";
            // 
            // cmbTipoFattura
            // 
            this.cmbTipoFattura.DataSource = this.DS.invoicekind;
            this.cmbTipoFattura.DisplayMember = "description";
            this.cmbTipoFattura.Location = new System.Drawing.Point(109, 19);
            this.cmbTipoFattura.Name = "cmbTipoFattura";
            this.cmbTipoFattura.Size = new System.Drawing.Size(266, 21);
            this.cmbTipoFattura.TabIndex = 2;
            this.cmbTipoFattura.TabStop = false;
            this.cmbTipoFattura.Tag = "stock.idinvkind";
            this.cmbTipoFattura.ValueMember = "idinvkind";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(528, 23);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(64, 20);
            this.textBox2.TabIndex = 5;
            this.textBox2.TabStop = false;
            this.textBox2.Tag = "stock.inv_idgroup";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(454, 22);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(68, 20);
            this.textBox3.TabIndex = 4;
            this.textBox3.TabStop = false;
            this.textBox3.Tag = "stock.ninv";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(385, 22);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(63, 20);
            this.textBox4.TabIndex = 3;
            this.textBox4.TabStop = false;
            this.textBox4.Tag = "stock.yinv.year";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(120, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(136, 16);
            this.label3.TabIndex = 0;
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtQuantita
            // 
            this.txtQuantita.Location = new System.Drawing.Point(113, 173);
            this.txtQuantita.Name = "txtQuantita";
            this.txtQuantita.ReadOnly = true;
            this.txtQuantita.Size = new System.Drawing.Size(90, 20);
            this.txtQuantita.TabIndex = 4;
            this.txtQuantita.TabStop = false;
            this.txtQuantita.Tag = "stock.number.N";
            this.txtQuantita.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtQuantita.Leave += new System.EventHandler(this.textQuantita_Leave);
            // 
            // lblQuantita
            // 
            this.lblQuantita.AutoSize = true;
            this.lblQuantita.Location = new System.Drawing.Point(108, 156);
            this.lblQuantita.Name = "lblQuantita";
            this.lblQuantita.Size = new System.Drawing.Size(47, 13);
            this.lblQuantita.TabIndex = 19;
            this.lblQuantita.Text = "Quantità";
            this.lblQuantita.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // gboxListino
            // 
            this.gboxListino.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gboxListino.Controls.Add(this.txtCoeffConversione);
            this.gboxListino.Controls.Add(this.label29);
            this.gboxListino.Controls.Add(this.cmbUnitaMisuraAcquisto);
            this.gboxListino.Controls.Add(this.lblIcmbdpackage);
            this.gboxListino.Controls.Add(this.label31);
            this.gboxListino.Controls.Add(this.cmbUnitaMisuraCS);
            this.gboxListino.Controls.Add(this.btnListino);
            this.gboxListino.Controls.Add(this.txtListino);
            this.gboxListino.Controls.Add(this.txtDescrizioneListino);
            this.gboxListino.Location = new System.Drawing.Point(13, 43);
            this.gboxListino.Name = "gboxListino";
            this.gboxListino.Size = new System.Drawing.Size(528, 105);
            this.gboxListino.TabIndex = 1;
            this.gboxListino.TabStop = false;
            this.gboxListino.Tag = "";
            // 
            // txtCoeffConversione
            // 
            this.txtCoeffConversione.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCoeffConversione.Location = new System.Drawing.Point(406, 46);
            this.txtCoeffConversione.Name = "txtCoeffConversione";
            this.txtCoeffConversione.ReadOnly = true;
            this.txtCoeffConversione.Size = new System.Drawing.Size(69, 20);
            this.txtCoeffConversione.TabIndex = 8;
            this.txtCoeffConversione.TabStop = false;
            this.txtCoeffConversione.Tag = "";
            // 
            // label29
            // 
            this.label29.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(290, 49);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(107, 13);
            this.label29.TabIndex = 22;
            this.label29.Text = "Coeff. di conversione";
            // 
            // cmbUnitaMisuraAcquisto
            // 
            this.cmbUnitaMisuraAcquisto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbUnitaMisuraAcquisto.DataSource = this.DS.package;
            this.cmbUnitaMisuraAcquisto.DisplayMember = "description";
            this.cmbUnitaMisuraAcquisto.Enabled = false;
            this.cmbUnitaMisuraAcquisto.FormattingEnabled = true;
            this.cmbUnitaMisuraAcquisto.Location = new System.Drawing.Point(407, 14);
            this.cmbUnitaMisuraAcquisto.Name = "cmbUnitaMisuraAcquisto";
            this.cmbUnitaMisuraAcquisto.Size = new System.Drawing.Size(115, 21);
            this.cmbUnitaMisuraAcquisto.TabIndex = 7;
            this.cmbUnitaMisuraAcquisto.TabStop = false;
            this.cmbUnitaMisuraAcquisto.Tag = "";
            this.cmbUnitaMisuraAcquisto.ValueMember = "idpackage";
            // 
            // lblIcmbdpackage
            // 
            this.lblIcmbdpackage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblIcmbdpackage.AutoSize = true;
            this.lblIcmbdpackage.Location = new System.Drawing.Point(296, 17);
            this.lblIcmbdpackage.Name = "lblIcmbdpackage";
            this.lblIcmbdpackage.Size = new System.Drawing.Size(106, 13);
            this.lblIcmbdpackage.TabIndex = 21;
            this.lblIcmbdpackage.Text = "U.tà di misura imballo";
            // 
            // label31
            // 
            this.label31.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(329, 82);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(71, 13);
            this.label31.TabIndex = 23;
            this.label31.Text = "U.tà di misura";
            // 
            // cmbUnitaMisuraCS
            // 
            this.cmbUnitaMisuraCS.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbUnitaMisuraCS.DataSource = this.DS.unit;
            this.cmbUnitaMisuraCS.DisplayMember = "description";
            this.cmbUnitaMisuraCS.Enabled = false;
            this.cmbUnitaMisuraCS.FormattingEnabled = true;
            this.cmbUnitaMisuraCS.Location = new System.Drawing.Point(406, 76);
            this.cmbUnitaMisuraCS.Name = "cmbUnitaMisuraCS";
            this.cmbUnitaMisuraCS.Size = new System.Drawing.Size(117, 21);
            this.cmbUnitaMisuraCS.TabIndex = 9;
            this.cmbUnitaMisuraCS.TabStop = false;
            this.cmbUnitaMisuraCS.Tag = "";
            this.cmbUnitaMisuraCS.ValueMember = "idunit";
            // 
            // btnListino
            // 
            this.btnListino.BackColor = System.Drawing.SystemColors.Control;
            this.btnListino.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnListino.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnListino.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnListino.ImageIndex = 0;
            this.btnListino.Location = new System.Drawing.Point(6, 17);
            this.btnListino.Name = "btnListino";
            this.btnListino.Size = new System.Drawing.Size(107, 23);
            this.btnListino.TabIndex = 1;
            this.btnListino.TabStop = false;
            this.btnListino.Tag = "";
            this.btnListino.Text = "Listino";
            this.btnListino.UseVisualStyleBackColor = false;
            this.btnListino.Click += new System.EventHandler(this.btnListino_Click);
            // 
            // txtListino
            // 
            this.txtListino.Location = new System.Drawing.Point(119, 18);
            this.txtListino.Name = "txtListino";
            this.txtListino.Size = new System.Drawing.Size(112, 20);
            this.txtListino.TabIndex = 2;
            this.txtListino.Tag = "listview.intcode?x";
            this.txtListino.Leave += new System.EventHandler(this.txtListino_Leave);
            // 
            // txtDescrizioneListino
            // 
            this.txtDescrizioneListino.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescrizioneListino.Location = new System.Drawing.Point(6, 45);
            this.txtDescrizioneListino.Multiline = true;
            this.txtDescrizioneListino.Name = "txtDescrizioneListino";
            this.txtDescrizioneListino.ReadOnly = true;
            this.txtDescrizioneListino.Size = new System.Drawing.Size(279, 52);
            this.txtDescrizioneListino.TabIndex = 9;
            this.txtDescrizioneListino.TabStop = false;
            this.txtDescrizioneListino.Tag = "";
            // 
            // txtValiditystop
            // 
            this.txtValiditystop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtValiditystop.Location = new System.Drawing.Point(430, 17);
            this.txtValiditystop.Name = "txtValiditystop";
            this.txtValiditystop.Size = new System.Drawing.Size(111, 20);
            this.txtValiditystop.TabIndex = 28;
            this.txtValiditystop.TabStop = false;
            this.txtValiditystop.Tag = "stock.expiry";
            // 
            // lblQuantitaConfezioni
            // 
            this.lblQuantitaConfezioni.AutoSize = true;
            this.lblQuantitaConfezioni.Location = new System.Drawing.Point(16, 156);
            this.lblQuantitaConfezioni.Name = "lblQuantitaConfezioni";
            this.lblQuantitaConfezioni.Size = new System.Drawing.Size(76, 13);
            this.lblQuantitaConfezioni.TabIndex = 24;
            this.lblQuantitaConfezioni.Text = "Quantità totale";
            this.lblQuantitaConfezioni.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtQuantitaConfezioni
            // 
            this.txtQuantitaConfezioni.Location = new System.Drawing.Point(17, 173);
            this.txtQuantitaConfezioni.Name = "txtQuantitaConfezioni";
            this.txtQuantitaConfezioni.Size = new System.Drawing.Size(90, 20);
            this.txtQuantitaConfezioni.TabIndex = 3;
            this.txtQuantitaConfezioni.Tag = "";
            this.txtQuantitaConfezioni.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtQuantitaConfezioni.Leave += new System.EventHandler(this.txtquantitatotale_Leave);
            // 
            // btnAnnulla
            // 
            this.btnAnnulla.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAnnulla.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnAnnulla.Location = new System.Drawing.Point(611, 443);
            this.btnAnnulla.Name = "btnAnnulla";
            this.btnAnnulla.Size = new System.Drawing.Size(75, 23);
            this.btnAnnulla.TabIndex = 27;
            this.btnAnnulla.Text = "Annulla";
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(514, 443);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 26;
            this.btnOK.Tag = "mainsave";
            this.btnOK.Text = "OK";
            // 
            // lblScadenza
            // 
            this.lblScadenza.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblScadenza.AutoSize = true;
            this.lblScadenza.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScadenza.ForeColor = System.Drawing.Color.Red;
            this.lblScadenza.Location = new System.Drawing.Point(352, 20);
            this.lblScadenza.Name = "lblScadenza";
            this.lblScadenza.Size = new System.Drawing.Size(63, 13);
            this.lblScadenza.TabIndex = 29;
            this.lblScadenza.Text = "Scadenza";
            // 
            // pbox
            // 
            this.pbox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pbox.Location = new System.Drawing.Point(547, 20);
            this.pbox.Name = "pbox";
            this.pbox.Size = new System.Drawing.Size(145, 126);
            this.pbox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbox.TabIndex = 30;
            this.pbox.TabStop = false;
            // 
            // cmbCausaleCarico
            // 
            this.cmbCausaleCarico.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbCausaleCarico.DataSource = this.DS.storeload_motive;
            this.cmbCausaleCarico.DisplayMember = "description";
            this.cmbCausaleCarico.FormattingEnabled = true;
            this.cmbCausaleCarico.Location = new System.Drawing.Point(457, 179);
            this.cmbCausaleCarico.Name = "cmbCausaleCarico";
            this.cmbCausaleCarico.Size = new System.Drawing.Size(230, 21);
            this.cmbCausaleCarico.TabIndex = 4;
            this.cmbCausaleCarico.Tag = "stock.idstoreload_motive";
            this.cmbCausaleCarico.ValueMember = "idstoreload_motive";
            // 
            // labCausale
            // 
            this.labCausale.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labCausale.AutoSize = true;
            this.labCausale.Location = new System.Drawing.Point(454, 159);
            this.labCausale.Name = "labCausale";
            this.labCausale.Size = new System.Drawing.Size(89, 13);
            this.labCausale.TabIndex = 50;
            this.labCausale.Text = "Causale di Carico";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(212, 156);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 60;
            this.label4.Text = "Giacenza";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtResidual
            // 
            this.txtResidual.Location = new System.Drawing.Point(209, 173);
            this.txtResidual.Name = "txtResidual";
            this.txtResidual.ReadOnly = true;
            this.txtResidual.Size = new System.Drawing.Size(74, 20);
            this.txtResidual.TabIndex = 59;
            this.txtResidual.TabStop = false;
            this.txtResidual.Tag = "";
            this.txtResidual.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 196);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 13);
            this.label5.TabIndex = 62;
            this.label5.Text = "Data Arrivo";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBox6
            // 
            this.textBox6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox6.Location = new System.Drawing.Point(17, 212);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(94, 20);
            this.textBox6.TabIndex = 5;
            this.textBox6.Tag = "stock.adate";
            // 
            // chkUnload
            // 
            this.chkUnload.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkUnload.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkUnload.Location = new System.Drawing.Point(511, 212);
            this.chkUnload.Name = "chkUnload";
            this.chkUnload.Size = new System.Drawing.Size(176, 24);
            this.chkUnload.TabIndex = 64;
            this.chkUnload.TabStop = false;
            this.chkUnload.Tag = "stock.flagto_unload:S:N";
            this.chkUnload.Text = "Scarico immediato";
            this.chkUnload.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // grpUbicazione
            // 
            this.grpUbicazione.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.grpUbicazione.Controls.Add(this.txtDescUbicazione);
            this.grpUbicazione.Controls.Add(this.txtIdUbicazione);
            this.grpUbicazione.Controls.Add(this.btnUbicazione);
            this.grpUbicazione.Location = new System.Drawing.Point(12, 247);
            this.grpUbicazione.Name = "grpUbicazione";
            this.grpUbicazione.Size = new System.Drawing.Size(362, 71);
            this.grpUbicazione.TabIndex = 116;
            this.grpUbicazione.TabStop = false;
            this.grpUbicazione.Tag = "AutoManage.txtIdUbicazione.tree";
            this.grpUbicazione.Text = "Ubicazione";
            // 
            // txtDescUbicazione
            // 
            this.txtDescUbicazione.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescUbicazione.Location = new System.Drawing.Point(128, 16);
            this.txtDescUbicazione.Multiline = true;
            this.txtDescUbicazione.Name = "txtDescUbicazione";
            this.txtDescUbicazione.ReadOnly = true;
            this.txtDescUbicazione.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDescUbicazione.Size = new System.Drawing.Size(226, 49);
            this.txtDescUbicazione.TabIndex = 3;
            this.txtDescUbicazione.TabStop = false;
            this.txtDescUbicazione.Tag = "stocklocationview.description";
            // 
            // txtIdUbicazione
            // 
            this.txtIdUbicazione.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtIdUbicazione.Location = new System.Drawing.Point(6, 45);
            this.txtIdUbicazione.Name = "txtIdUbicazione";
            this.txtIdUbicazione.Size = new System.Drawing.Size(112, 20);
            this.txtIdUbicazione.TabIndex = 1;
            this.txtIdUbicazione.Tag = "stocklocationview.stocklocationcode?stockview.stocklocationcode";
            // 
            // btnUbicazione
            // 
            this.btnUbicazione.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnUbicazione.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUbicazione.Location = new System.Drawing.Point(6, 14);
            this.btnUbicazione.Name = "btnUbicazione";
            this.btnUbicazione.Size = new System.Drawing.Size(112, 23);
            this.btnUbicazione.TabIndex = 1;
            this.btnUbicazione.TabStop = false;
            this.btnUbicazione.Tag = "manage.stocklocationview.tree";
            this.btnUbicazione.Text = "Ubicazione";
            // 
            // FrmStock_ddt_in
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(699, 478);
            this.Controls.Add(this.grpUbicazione);
            this.Controls.Add(this.chkUnload);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBox6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtResidual);
            this.Controls.Add(this.cmbCausaleCarico);
            this.Controls.Add(this.labCausale);
            this.Controls.Add(this.pbox);
            this.Controls.Add(this.lblScadenza);
            this.Controls.Add(this.txtValiditystop);
            this.Controls.Add(this.btnAnnulla);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.lblQuantitaConfezioni);
            this.Controls.Add(this.txtQuantitaConfezioni);
            this.Controls.Add(this.gboxListino);
            this.Controls.Add(this.lblQuantita);
            this.Controls.Add(this.txtQuantita);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grpRiga);
            this.Name = "FrmStock_ddt_in";
            this.Text = "FrmStock_ddt_in";
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.grpRiga.ResumeLayout(false);
            this.grpRiga.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gboxListino.ResumeLayout(false);
            this.gboxListino.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbox)).EndInit();
            this.grpUbicazione.ResumeLayout(false);
            this.grpUbicazione.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public vistaForm DS;
        private System.Windows.Forms.GroupBox grpRiga;
        private System.Windows.Forms.ComboBox cmbTipoOrdine;
        private System.Windows.Forms.TextBox txtNumriga;
        private System.Windows.Forms.TextBox txtNumordine;
        private System.Windows.Forms.TextBox txtEsercordine;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cmbTipoFattura;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtQuantita;
        private System.Windows.Forms.Label lblQuantita;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox gboxListino;
        private System.Windows.Forms.TextBox txtCoeffConversione;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.ComboBox cmbUnitaMisuraAcquisto;
        private System.Windows.Forms.Label lblIcmbdpackage;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.ComboBox cmbUnitaMisuraCS;
        private System.Windows.Forms.Button btnListino;
        private System.Windows.Forms.TextBox txtListino;
        private System.Windows.Forms.TextBox txtDescrizioneListino;
        private System.Windows.Forms.Label lblQuantitaConfezioni;
        private System.Windows.Forms.TextBox txtQuantitaConfezioni;
        private System.Windows.Forms.Button btnAnnulla;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.TextBox txtValiditystop;
        private System.Windows.Forms.Label lblScadenza;
        private System.Windows.Forms.PictureBox pbox;
        private System.Windows.Forms.ComboBox cmbCausaleCarico;
        private System.Windows.Forms.Label labCausale;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtResidual;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.CheckBox chkUnload;
        private System.Windows.Forms.GroupBox grpUbicazione;
        private System.Windows.Forms.TextBox txtDescUbicazione;
        private System.Windows.Forms.TextBox txtIdUbicazione;
        private System.Windows.Forms.Button btnUbicazione;

    }
}