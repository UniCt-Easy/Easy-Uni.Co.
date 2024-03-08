
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


namespace stock_default
{
    partial class Frm_stock_default
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
            this.DS = new stock_default.vistaForm();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.grpUbicazione = new System.Windows.Forms.GroupBox();
            this.txtDescUbicazione = new System.Windows.Forms.TextBox();
            this.txtIdUbicazione = new System.Windows.Forms.TextBox();
            this.btnUbicazione = new System.Windows.Forms.Button();
            this.chkUnload = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.pbox = new System.Windows.Forms.PictureBox();
            this.lblScadenza = new System.Windows.Forms.Label();
            this.txtValiditystop = new System.Windows.Forms.TextBox();
            this.grpBollaIngresso = new System.Windows.Forms.GroupBox();
            this.txtYddt = new System.Windows.Forms.TextBox();
            this.txtNumero = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbCausaleCarico = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cmbMagazzino = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCostoUnitario = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblQuantitaConfezioni = new System.Windows.Forms.Label();
            this.txtQuantitaConfezioni = new System.Windows.Forms.TextBox();
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
            this.lblQuantita = new System.Windows.Forms.Label();
            this.txtQuantita = new System.Windows.Forms.TextBox();
            this.grpFattura = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbTipoFattura = new System.Windows.Forms.ComboBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.grpOrdine = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbTipoOrdine = new System.Windows.Forms.ComboBox();
            this.txtNumriga = new System.Windows.Forms.TextBox();
            this.txtNumordine = new System.Windows.Forms.TextBox();
            this.txtEsercordine = new System.Windows.Forms.TextBox();
            this.lblImporto = new System.Windows.Forms.Label();
            this.txtCostoTotale = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label14 = new System.Windows.Forms.Label();
            this.dgrScarichi = new System.Windows.Forms.DataGrid();
            this.chkListDescription = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.grpUbicazione.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbox)).BeginInit();
            this.grpBollaIngresso.SuspendLayout();
            this.gboxListino.SuspendLayout();
            this.grpFattura.SuspendLayout();
            this.grpOrdine.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrScarichi)).BeginInit();
            this.SuspendLayout();
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.EnforceConstraints = false;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(4, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(749, 538);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.grpUbicazione);
            this.tabPage1.Controls.Add(this.chkUnload);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.textBox6);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.textBox1);
            this.tabPage1.Controls.Add(this.textBox5);
            this.tabPage1.Controls.Add(this.pbox);
            this.tabPage1.Controls.Add(this.lblScadenza);
            this.tabPage1.Controls.Add(this.txtValiditystop);
            this.tabPage1.Controls.Add(this.grpBollaIngresso);
            this.tabPage1.Controls.Add(this.cmbCausaleCarico);
            this.tabPage1.Controls.Add(this.label9);
            this.tabPage1.Controls.Add(this.cmbMagazzino);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.txtCostoUnitario);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.lblQuantitaConfezioni);
            this.tabPage1.Controls.Add(this.txtQuantitaConfezioni);
            this.tabPage1.Controls.Add(this.gboxListino);
            this.tabPage1.Controls.Add(this.lblQuantita);
            this.tabPage1.Controls.Add(this.txtQuantita);
            this.tabPage1.Controls.Add(this.grpFattura);
            this.tabPage1.Controls.Add(this.grpOrdine);
            this.tabPage1.Controls.Add(this.lblImporto);
            this.tabPage1.Controls.Add(this.txtCostoTotale);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(741, 512);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Principale";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // grpUbicazione
            // 
            this.grpUbicazione.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.grpUbicazione.Controls.Add(this.txtDescUbicazione);
            this.grpUbicazione.Controls.Add(this.txtIdUbicazione);
            this.grpUbicazione.Controls.Add(this.btnUbicazione);
            this.grpUbicazione.Location = new System.Drawing.Point(28, 270);
            this.grpUbicazione.Name = "grpUbicazione";
            this.grpUbicazione.Size = new System.Drawing.Size(362, 71);
            this.grpUbicazione.TabIndex = 115;
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
            // chkUnload
            // 
            this.chkUnload.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkUnload.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkUnload.Location = new System.Drawing.Point(585, 243);
            this.chkUnload.Name = "chkUnload";
            this.chkUnload.Size = new System.Drawing.Size(125, 24);
            this.chkUnload.TabIndex = 114;
            this.chkUnload.TabStop = false;
            this.chkUnload.Tag = "stock.flagto_unload:S:N";
            this.chkUnload.Text = "Scarico immediato";
            this.chkUnload.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(536, 221);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 13);
            this.label4.TabIndex = 113;
            this.label4.Text = "Data Arrivo";
            // 
            // textBox6
            // 
            this.textBox6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox6.Location = new System.Drawing.Point(612, 217);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(98, 20);
            this.textBox6.TabIndex = 95;
            this.textBox6.Tag = "stock.adate";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(295, 176);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 112;
            this.label2.Text = "Giacenza";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(298, 193);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(78, 20);
            this.textBox1.TabIndex = 111;
            this.textBox1.TabStop = false;
            this.textBox1.Tag = "stockview.residual.n";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(210, 226);
            this.textBox5.Multiline = true;
            this.textBox5.Name = "textBox5";
            this.textBox5.ReadOnly = true;
            this.textBox5.Size = new System.Drawing.Size(265, 38);
            this.textBox5.TabIndex = 110;
            this.textBox5.TabStop = false;
            this.textBox5.Tag = "";
            this.textBox5.Text = "Attenzione, il costo totale include anche l\'iva non detraibile (con applicazione " +
    "di prorata e promiscuo)";
            // 
            // pbox
            // 
            this.pbox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pbox.Location = new System.Drawing.Point(566, 33);
            this.pbox.Name = "pbox";
            this.pbox.Size = new System.Drawing.Size(145, 126);
            this.pbox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbox.TabIndex = 109;
            this.pbox.TabStop = false;
            // 
            // lblScadenza
            // 
            this.lblScadenza.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblScadenza.AutoSize = true;
            this.lblScadenza.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScadenza.ForeColor = System.Drawing.Color.Red;
            this.lblScadenza.Location = new System.Drawing.Point(395, 26);
            this.lblScadenza.Name = "lblScadenza";
            this.lblScadenza.Size = new System.Drawing.Size(63, 13);
            this.lblScadenza.TabIndex = 108;
            this.lblScadenza.Text = "Scadenza";
            // 
            // txtValiditystop
            // 
            this.txtValiditystop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtValiditystop.Location = new System.Drawing.Point(460, 22);
            this.txtValiditystop.Name = "txtValiditystop";
            this.txtValiditystop.Size = new System.Drawing.Size(94, 20);
            this.txtValiditystop.TabIndex = 90;
            this.txtValiditystop.Tag = "stock.expiry";
            // 
            // grpBollaIngresso
            // 
            this.grpBollaIngresso.Controls.Add(this.txtYddt);
            this.grpBollaIngresso.Controls.Add(this.txtNumero);
            this.grpBollaIngresso.Controls.Add(this.label10);
            this.grpBollaIngresso.Controls.Add(this.label8);
            this.grpBollaIngresso.Location = new System.Drawing.Point(28, 344);
            this.grpBollaIngresso.Name = "grpBollaIngresso";
            this.grpBollaIngresso.Size = new System.Drawing.Size(362, 47);
            this.grpBollaIngresso.TabIndex = 98;
            this.grpBollaIngresso.TabStop = false;
            this.grpBollaIngresso.Text = "Bolla di Ingresso";
            // 
            // txtYddt
            // 
            this.txtYddt.Location = new System.Drawing.Point(70, 19);
            this.txtYddt.Name = "txtYddt";
            this.txtYddt.Size = new System.Drawing.Size(69, 20);
            this.txtYddt.TabIndex = 12;
            this.txtYddt.Tag = "ddt_in.yddt_in.year?stockview.yddt_in";
            // 
            // txtNumero
            // 
            this.txtNumero.Location = new System.Drawing.Point(233, 19);
            this.txtNumero.Name = "txtNumero";
            this.txtNumero.Size = new System.Drawing.Size(91, 20);
            this.txtNumero.TabIndex = 13;
            this.txtNumero.Tag = "ddt_in.nddt_in?stockview.nddt_in";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(15, 22);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(49, 13);
            this.label10.TabIndex = 51;
            this.label10.Text = "Esercizio";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(179, 22);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(44, 13);
            this.label8.TabIndex = 54;
            this.label8.Text = "Numero";
            // 
            // cmbCausaleCarico
            // 
            this.cmbCausaleCarico.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbCausaleCarico.DataSource = this.DS.storeload_motive;
            this.cmbCausaleCarico.DisplayMember = "description";
            this.cmbCausaleCarico.FormattingEnabled = true;
            this.cmbCausaleCarico.Location = new System.Drawing.Point(483, 191);
            this.cmbCausaleCarico.Name = "cmbCausaleCarico";
            this.cmbCausaleCarico.Size = new System.Drawing.Size(230, 21);
            this.cmbCausaleCarico.TabIndex = 94;
            this.cmbCausaleCarico.Tag = "stock.idstoreload_motive";
            this.cmbCausaleCarico.ValueMember = "idstoreload_motive";
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(477, 175);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(89, 13);
            this.label9.TabIndex = 107;
            this.label9.Text = "Causale di Carico";
            // 
            // cmbMagazzino
            // 
            this.cmbMagazzino.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbMagazzino.DataSource = this.DS.store;
            this.cmbMagazzino.DisplayMember = "description";
            this.cmbMagazzino.FormattingEnabled = true;
            this.cmbMagazzino.Location = new System.Drawing.Point(95, 21);
            this.cmbMagazzino.Name = "cmbMagazzino";
            this.cmbMagazzino.Size = new System.Drawing.Size(295, 21);
            this.cmbMagazzino.TabIndex = 89;
            this.cmbMagazzino.Tag = "stock.idstore";
            this.cmbMagazzino.ValueMember = "idstore";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(31, 21);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 13);
            this.label5.TabIndex = 106;
            this.label5.Text = "Magazzino";
            // 
            // txtCostoUnitario
            // 
            this.txtCostoUnitario.Location = new System.Drawing.Point(118, 242);
            this.txtCostoUnitario.Name = "txtCostoUnitario";
            this.txtCostoUnitario.ReadOnly = true;
            this.txtCostoUnitario.Size = new System.Drawing.Size(86, 20);
            this.txtCostoUnitario.TabIndex = 105;
            this.txtCostoUnitario.TabStop = false;
            this.txtCostoUnitario.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 225);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 104;
            this.label1.Text = "Costo Totale";
            // 
            // lblQuantitaConfezioni
            // 
            this.lblQuantitaConfezioni.AutoSize = true;
            this.lblQuantitaConfezioni.Location = new System.Drawing.Point(26, 177);
            this.lblQuantitaConfezioni.Name = "lblQuantitaConfezioni";
            this.lblQuantitaConfezioni.Size = new System.Drawing.Size(76, 13);
            this.lblQuantitaConfezioni.TabIndex = 103;
            this.lblQuantitaConfezioni.Text = "Quantità totale";
            this.lblQuantitaConfezioni.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtQuantitaConfezioni
            // 
            this.txtQuantitaConfezioni.Location = new System.Drawing.Point(30, 193);
            this.txtQuantitaConfezioni.Name = "txtQuantitaConfezioni";
            this.txtQuantitaConfezioni.Size = new System.Drawing.Size(82, 20);
            this.txtQuantitaConfezioni.TabIndex = 92;
            this.txtQuantitaConfezioni.Tag = "";
            this.txtQuantitaConfezioni.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtQuantitaConfezioni.Leave += new System.EventHandler(this.txtQuantitaConfezioni_Leave);
            // 
            // gboxListino
            // 
            this.gboxListino.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gboxListino.Controls.Add(this.chkListDescription);
            this.gboxListino.Controls.Add(this.txtCoeffConversione);
            this.gboxListino.Controls.Add(this.label29);
            this.gboxListino.Controls.Add(this.cmbUnitaMisuraAcquisto);
            this.gboxListino.Controls.Add(this.lblIcmbdpackage);
            this.gboxListino.Controls.Add(this.label31);
            this.gboxListino.Controls.Add(this.cmbUnitaMisuraCS);
            this.gboxListino.Controls.Add(this.btnListino);
            this.gboxListino.Controls.Add(this.txtListino);
            this.gboxListino.Controls.Add(this.txtDescrizioneListino);
            this.gboxListino.Location = new System.Drawing.Point(34, 48);
            this.gboxListino.Name = "gboxListino";
            this.gboxListino.Size = new System.Drawing.Size(520, 124);
            this.gboxListino.TabIndex = 91;
            this.gboxListino.TabStop = false;
            this.gboxListino.Tag = "";
            // 
            // txtCoeffConversione
            // 
            this.txtCoeffConversione.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCoeffConversione.Location = new System.Drawing.Point(398, 55);
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
            this.label29.Location = new System.Drawing.Point(282, 58);
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
            this.cmbUnitaMisuraAcquisto.Location = new System.Drawing.Point(399, 28);
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
            this.lblIcmbdpackage.Location = new System.Drawing.Point(288, 31);
            this.lblIcmbdpackage.Name = "lblIcmbdpackage";
            this.lblIcmbdpackage.Size = new System.Drawing.Size(106, 13);
            this.lblIcmbdpackage.TabIndex = 21;
            this.lblIcmbdpackage.Text = "U.tà di misura imballo";
            // 
            // label31
            // 
            this.label31.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(321, 83);
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
            this.cmbUnitaMisuraCS.Location = new System.Drawing.Point(397, 77);
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
            this.btnListino.Location = new System.Drawing.Point(6, 41);
            this.btnListino.Name = "btnListino";
            this.btnListino.Size = new System.Drawing.Size(74, 23);
            this.btnListino.TabIndex = 1;
            this.btnListino.TabStop = false;
            this.btnListino.Tag = "";
            this.btnListino.Text = "Listino";
            this.btnListino.UseVisualStyleBackColor = false;
            this.btnListino.Click += new System.EventHandler(this.btnListino_Click);
            // 
            // txtListino
            // 
            this.txtListino.Location = new System.Drawing.Point(84, 43);
            this.txtListino.Name = "txtListino";
            this.txtListino.Size = new System.Drawing.Size(112, 20);
            this.txtListino.TabIndex = 3;
            this.txtListino.Tag = "listview.intcode?stockview.intcode";
            this.txtListino.Leave += new System.EventHandler(this.txtListino_Leave);
            // 
            // txtDescrizioneListino
            // 
            this.txtDescrizioneListino.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescrizioneListino.Location = new System.Drawing.Point(6, 68);
            this.txtDescrizioneListino.Multiline = true;
            this.txtDescrizioneListino.Name = "txtDescrizioneListino";
            this.txtDescrizioneListino.ReadOnly = true;
            this.txtDescrizioneListino.Size = new System.Drawing.Size(273, 49);
            this.txtDescrizioneListino.TabIndex = 9;
            this.txtDescrizioneListino.TabStop = false;
            this.txtDescrizioneListino.Tag = "";
            // 
            // lblQuantita
            // 
            this.lblQuantita.AutoSize = true;
            this.lblQuantita.Location = new System.Drawing.Point(159, 176);
            this.lblQuantita.Name = "lblQuantita";
            this.lblQuantita.Size = new System.Drawing.Size(47, 13);
            this.lblQuantita.TabIndex = 102;
            this.lblQuantita.Text = "Quantità";
            this.lblQuantita.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtQuantita
            // 
            this.txtQuantita.Location = new System.Drawing.Point(161, 193);
            this.txtQuantita.Name = "txtQuantita";
            this.txtQuantita.ReadOnly = true;
            this.txtQuantita.Size = new System.Drawing.Size(86, 20);
            this.txtQuantita.TabIndex = 96;
            this.txtQuantita.TabStop = false;
            this.txtQuantita.Tag = "stock.number.N";
            this.txtQuantita.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtQuantita.TextChanged += new System.EventHandler(this.txtQuantita_TextChanged);
            this.txtQuantita.Leave += new System.EventHandler(this.txtQuantita_Leave);
            // 
            // grpFattura
            // 
            this.grpFattura.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpFattura.Controls.Add(this.label7);
            this.grpFattura.Controls.Add(this.cmbTipoFattura);
            this.grpFattura.Controls.Add(this.textBox2);
            this.grpFattura.Controls.Add(this.textBox3);
            this.grpFattura.Controls.Add(this.textBox4);
            this.grpFattura.Controls.Add(this.label3);
            this.grpFattura.Enabled = false;
            this.grpFattura.Location = new System.Drawing.Point(28, 453);
            this.grpFattura.Name = "grpFattura";
            this.grpFattura.Size = new System.Drawing.Size(682, 48);
            this.grpFattura.TabIndex = 100;
            this.grpFattura.TabStop = false;
            this.grpFattura.Text = "Riga della Fattura collegata (Tipo  / Eserc. /  Num.  / Riga)";
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
            this.cmbTipoFattura.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbTipoFattura.DataSource = this.DS.invoicekind;
            this.cmbTipoFattura.DisplayMember = "description";
            this.cmbTipoFattura.Location = new System.Drawing.Point(109, 19);
            this.cmbTipoFattura.Name = "cmbTipoFattura";
            this.cmbTipoFattura.Size = new System.Drawing.Size(338, 21);
            this.cmbTipoFattura.TabIndex = 18;
            this.cmbTipoFattura.Tag = "stock.idinvkind";
            this.cmbTipoFattura.ValueMember = "idinvkind";
            // 
            // textBox2
            // 
            this.textBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox2.Location = new System.Drawing.Point(612, 20);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(56, 20);
            this.textBox2.TabIndex = 21;
            this.textBox2.Tag = "stock.inv_idgroup";
            // 
            // textBox3
            // 
            this.textBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox3.Location = new System.Drawing.Point(537, 21);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(56, 20);
            this.textBox3.TabIndex = 20;
            this.textBox3.Tag = "stock.ninv";
            // 
            // textBox4
            // 
            this.textBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox4.Location = new System.Drawing.Point(453, 20);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(48, 20);
            this.textBox4.TabIndex = 19;
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
            // grpOrdine
            // 
            this.grpOrdine.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpOrdine.Controls.Add(this.label6);
            this.grpOrdine.Controls.Add(this.cmbTipoOrdine);
            this.grpOrdine.Controls.Add(this.txtNumriga);
            this.grpOrdine.Controls.Add(this.txtNumordine);
            this.grpOrdine.Controls.Add(this.txtEsercordine);
            this.grpOrdine.Enabled = false;
            this.grpOrdine.Location = new System.Drawing.Point(28, 399);
            this.grpOrdine.Name = "grpOrdine";
            this.grpOrdine.Size = new System.Drawing.Size(684, 48);
            this.grpOrdine.TabIndex = 99;
            this.grpOrdine.TabStop = false;
            this.grpOrdine.Text = "Riga del Contratto Passivo collegato (Tipo  / Eserc. /  Num.  / Riga)";
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
            this.cmbTipoOrdine.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbTipoOrdine.DataSource = this.DS.mandatekind;
            this.cmbTipoOrdine.DisplayMember = "description";
            this.cmbTipoOrdine.Location = new System.Drawing.Point(109, 20);
            this.cmbTipoOrdine.Name = "cmbTipoOrdine";
            this.cmbTipoOrdine.Size = new System.Drawing.Size(336, 21);
            this.cmbTipoOrdine.TabIndex = 13;
            this.cmbTipoOrdine.Tag = "stock.idmankind";
            this.cmbTipoOrdine.ValueMember = "idmankind";
            // 
            // txtNumriga
            // 
            this.txtNumriga.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNumriga.Location = new System.Drawing.Point(612, 23);
            this.txtNumriga.Name = "txtNumriga";
            this.txtNumriga.Size = new System.Drawing.Size(57, 20);
            this.txtNumriga.TabIndex = 16;
            this.txtNumriga.Tag = "stock.man_idgroup";
            // 
            // txtNumordine
            // 
            this.txtNumordine.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNumordine.Location = new System.Drawing.Point(538, 22);
            this.txtNumordine.Name = "txtNumordine";
            this.txtNumordine.Size = new System.Drawing.Size(56, 20);
            this.txtNumordine.TabIndex = 15;
            this.txtNumordine.Tag = "stock.nman";
            // 
            // txtEsercordine
            // 
            this.txtEsercordine.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEsercordine.Location = new System.Drawing.Point(454, 22);
            this.txtEsercordine.Name = "txtEsercordine";
            this.txtEsercordine.Size = new System.Drawing.Size(48, 20);
            this.txtEsercordine.TabIndex = 14;
            this.txtEsercordine.Tag = "stock.yman.year";
            // 
            // lblImporto
            // 
            this.lblImporto.AutoSize = true;
            this.lblImporto.Location = new System.Drawing.Point(117, 226);
            this.lblImporto.Name = "lblImporto";
            this.lblImporto.Size = new System.Drawing.Size(73, 13);
            this.lblImporto.TabIndex = 101;
            this.lblImporto.Text = "Costo Unitario";
            this.lblImporto.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtCostoTotale
            // 
            this.txtCostoTotale.Location = new System.Drawing.Point(30, 242);
            this.txtCostoTotale.Name = "txtCostoTotale";
            this.txtCostoTotale.Size = new System.Drawing.Size(82, 20);
            this.txtCostoTotale.TabIndex = 93;
            this.txtCostoTotale.Tag = "stock.amount.fixed.2...1";
            this.txtCostoTotale.Leave += new System.EventHandler(this.txtCostoTotale_Leave);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label14);
            this.tabPage2.Controls.Add(this.dgrScarichi);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(741, 512);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Scarichi";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label14
            // 
            this.label14.Location = new System.Drawing.Point(13, 16);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(112, 16);
            this.label14.TabIndex = 3;
            this.label14.Text = "Dettagli Scarico";
            // 
            // dgrScarichi
            // 
            this.dgrScarichi.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgrScarichi.DataMember = "";
            this.dgrScarichi.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dgrScarichi.Location = new System.Drawing.Point(16, 35);
            this.dgrScarichi.Name = "dgrScarichi";
            this.dgrScarichi.Size = new System.Drawing.Size(707, 221);
            this.dgrScarichi.TabIndex = 1;
            this.dgrScarichi.Tag = "storeunloaddetailview.lista";
            // 
            // chkListDescription
            // 
            this.chkListDescription.Location = new System.Drawing.Point(6, 15);
            this.chkListDescription.Name = "chkListDescription";
            this.chkListDescription.Size = new System.Drawing.Size(277, 20);
            this.chkListDescription.TabIndex = 24;
            this.chkListDescription.TabStop = false;
            this.chkListDescription.Text = "Fitra per Descrizione/Class.Merceologica";
            // 
            // Frm_stock_default
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(755, 543);
            this.Controls.Add(this.tabControl1);
            this.Name = "Frm_stock_default";
            this.Text = "Frm_stock_default";
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.grpUbicazione.ResumeLayout(false);
            this.grpUbicazione.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbox)).EndInit();
            this.grpBollaIngresso.ResumeLayout(false);
            this.grpBollaIngresso.PerformLayout();
            this.gboxListino.ResumeLayout(false);
            this.gboxListino.PerformLayout();
            this.grpFattura.ResumeLayout(false);
            this.grpFattura.PerformLayout();
            this.grpOrdine.ResumeLayout(false);
            this.grpOrdine.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgrScarichi)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public vistaForm DS;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.CheckBox chkUnload;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.PictureBox pbox;
        private System.Windows.Forms.Label lblScadenza;
        private System.Windows.Forms.TextBox txtValiditystop;
        private System.Windows.Forms.GroupBox grpBollaIngresso;
        private System.Windows.Forms.TextBox txtYddt;
        private System.Windows.Forms.TextBox txtNumero;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmbCausaleCarico;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cmbMagazzino;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtCostoUnitario;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblQuantitaConfezioni;
        private System.Windows.Forms.TextBox txtQuantitaConfezioni;
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
        private System.Windows.Forms.Label lblQuantita;
        private System.Windows.Forms.TextBox txtQuantita;
        private System.Windows.Forms.GroupBox grpFattura;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbTipoFattura;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox grpOrdine;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbTipoOrdine;
        private System.Windows.Forms.TextBox txtNumriga;
        private System.Windows.Forms.TextBox txtNumordine;
        private System.Windows.Forms.TextBox txtEsercordine;
        private System.Windows.Forms.Label lblImporto;
        private System.Windows.Forms.TextBox txtCostoTotale;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGrid dgrScarichi;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.GroupBox grpUbicazione;
        private System.Windows.Forms.TextBox txtDescUbicazione;
        private System.Windows.Forms.TextBox txtIdUbicazione;
        private System.Windows.Forms.Button btnUbicazione;
        private System.Windows.Forms.CheckBox chkListDescription;

    }
}
