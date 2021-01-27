
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


namespace f24ep_default {
    partial class FrmF24ep_default {
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtDataUltimaLiquid = new System.Windows.Forms.TextBox();
            this.txtDataPrimaLiquid = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnRimuovi = new System.Windows.Forms.Button();
            this.btnModifica = new System.Windows.Forms.Button();
            this.btnInserisci = new System.Windows.Forms.Button();
            this.gridLiquidazioni = new System.Windows.Forms.DataGrid();
            this.txtTotaleAddebito = new System.Windows.Forms.TextBox();
            this.txtEsercizio = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDataDiVersamento = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtDenominazione = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCodiceFiscale = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtContoDiAddebito = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnGeneraF24 = new System.Windows.Forms.Button();
            this.txtPercorso = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtDataGenerazione = new System.Windows.Forms.TextBox();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageLiquidazioni = new System.Windows.Forms.TabPage();
            this.tabPageSanzioni = new System.Windows.Forms.TabPage();
            this.btnEliminaSanzione = new System.Windows.Forms.Button();
            this.btnModificaSanzione = new System.Windows.Forms.Button();
            this.btnInserisciSanzione = new System.Windows.Forms.Button();
            this.gridSanzioni = new System.Windows.Forms.DataGrid();
            this.tabPageDetails = new System.Windows.Forms.TabPage();
            this.btnRimuoviDetail = new System.Windows.Forms.Button();
            this.btnModificaDetail = new System.Windows.Forms.Button();
            this.btnInserisciDetail = new System.Windows.Forms.Button();
            this.GridDetails = new System.Windows.Forms.DataGrid();
            this.tabPageIVA = new System.Windows.Forms.TabPage();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.gridIVA = new System.Windows.Forms.DataGrid();
            this.grpTotaleAddebito = new System.Windows.Forms.GroupBox();
            this.DS = new f24ep_default.vistaForm();
            this.cmbMese = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridLiquidazioni)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPageLiquidazioni.SuspendLayout();
            this.tabPageSanzioni.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridSanzioni)).BeginInit();
            this.tabPageDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridDetails)).BeginInit();
            this.tabPageIVA.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridIVA)).BeginInit();
            this.grpTotaleAddebito.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.AutoSize = true;
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Controls.Add(this.btnRimuovi);
            this.groupBox1.Controls.Add(this.btnModifica);
            this.groupBox1.Controls.Add(this.btnInserisci);
            this.groupBox1.Controls.Add(this.gridLiquidazioni);
            this.groupBox1.Location = new System.Drawing.Point(2, -1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(662, 274);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(10, 60);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(50, 13);
            this.label8.TabIndex = 15;
            this.label8.Text = "Data fine";
            // 
            // txtDataUltimaLiquid
            // 
            this.txtDataUltimaLiquid.Location = new System.Drawing.Point(11, 76);
            this.txtDataUltimaLiquid.Name = "txtDataUltimaLiquid";
            this.txtDataUltimaLiquid.Size = new System.Drawing.Size(82, 20);
            this.txtDataUltimaLiquid.TabIndex = 4;
            this.txtDataUltimaLiquid.Tag = "f24ep.taxpay_stop";
            // 
            // txtDataPrimaLiquid
            // 
            this.txtDataPrimaLiquid.Location = new System.Drawing.Point(11, 37);
            this.txtDataPrimaLiquid.Name = "txtDataPrimaLiquid";
            this.txtDataPrimaLiquid.Size = new System.Drawing.Size(82, 20);
            this.txtDataPrimaLiquid.TabIndex = 16;
            this.txtDataPrimaLiquid.Tag = "f24ep.taxpay_start";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(11, 21);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "Data inizio";
            // 
            // btnRimuovi
            // 
            this.btnRimuovi.Location = new System.Drawing.Point(11, 49);
            this.btnRimuovi.Name = "btnRimuovi";
            this.btnRimuovi.Size = new System.Drawing.Size(101, 23);
            this.btnRimuovi.TabIndex = 7;
            this.btnRimuovi.Text = "Rimuovi";
            this.btnRimuovi.UseVisualStyleBackColor = true;
            this.btnRimuovi.Click += new System.EventHandler(this.btnRimuovi_Click);
            // 
            // btnModifica
            // 
            this.btnModifica.Location = new System.Drawing.Point(11, 78);
            this.btnModifica.Name = "btnModifica";
            this.btnModifica.Size = new System.Drawing.Size(101, 23);
            this.btnModifica.TabIndex = 8;
            this.btnModifica.Text = "Modifica...";
            this.btnModifica.UseVisualStyleBackColor = true;
            this.btnModifica.Click += new System.EventHandler(this.btnModifica_Click);
            // 
            // btnInserisci
            // 
            this.btnInserisci.Location = new System.Drawing.Point(11, 20);
            this.btnInserisci.Name = "btnInserisci";
            this.btnInserisci.Size = new System.Drawing.Size(101, 23);
            this.btnInserisci.TabIndex = 6;
            this.btnInserisci.Text = "Inserisci";
            this.btnInserisci.UseVisualStyleBackColor = true;
            this.btnInserisci.Click += new System.EventHandler(this.btnInserisci_Click);
            // 
            // gridLiquidazioni
            // 
            this.gridLiquidazioni.AllowNavigation = false;
            this.gridLiquidazioni.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridLiquidazioni.DataMember = "";
            this.gridLiquidazioni.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.gridLiquidazioni.Location = new System.Drawing.Point(130, 20);
            this.gridLiquidazioni.Name = "gridLiquidazioni";
            this.gridLiquidazioni.Size = new System.Drawing.Size(527, 231);
            this.gridLiquidazioni.TabIndex = 4;
            this.gridLiquidazioni.TabStop = false;
            this.gridLiquidazioni.Tag = "taxpayview.liqcollegata";
            // 
            // txtTotaleAddebito
            // 
            this.txtTotaleAddebito.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTotaleAddebito.Location = new System.Drawing.Point(99, 7);
            this.txtTotaleAddebito.Name = "txtTotaleAddebito";
            this.txtTotaleAddebito.Size = new System.Drawing.Size(166, 20);
            this.txtTotaleAddebito.TabIndex = 10;
            this.txtTotaleAddebito.Tag = "";
            // 
            // txtEsercizio
            // 
            this.txtEsercizio.Location = new System.Drawing.Point(185, 12);
            this.txtEsercizio.Name = "txtEsercizio";
            this.txtEsercizio.ReadOnly = true;
            this.txtEsercizio.Size = new System.Drawing.Size(67, 20);
            this.txtEsercizio.TabIndex = 6;
            this.txtEsercizio.Tag = "f24ep.ayear";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(136, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Esercizio";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Data di addebito";
            // 
            // txtDataDiVersamento
            // 
            this.txtDataDiVersamento.Location = new System.Drawing.Point(92, 23);
            this.txtDataDiVersamento.Name = "txtDataDiVersamento";
            this.txtDataDiVersamento.Size = new System.Drawing.Size(100, 20);
            this.txtDataDiVersamento.TabIndex = 9;
            this.txtDataDiVersamento.Tag = "f24ep.paymentdate";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.label);
            this.groupBox2.Controls.Add(this.txtEmail);
            this.groupBox2.Controls.Add(this.txtDenominazione);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txtCodiceFiscale);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(12, 104);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(670, 81);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Dati identificativi del fornitore del file";
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Location = new System.Drawing.Point(351, 52);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(32, 13);
            this.label.TabIndex = 7;
            this.label.Text = "Email";
            // 
            // txtEmail
            // 
            this.txtEmail.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEmail.Location = new System.Drawing.Point(389, 49);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.ReadOnly = true;
            this.txtEmail.Size = new System.Drawing.Size(275, 20);
            this.txtEmail.TabIndex = 6;
            // 
            // txtDenominazione
            // 
            this.txtDenominazione.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDenominazione.Location = new System.Drawing.Point(288, 23);
            this.txtDenominazione.Name = "txtDenominazione";
            this.txtDenominazione.ReadOnly = true;
            this.txtDenominazione.Size = new System.Drawing.Size(376, 20);
            this.txtDenominazione.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(202, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Denominazione";
            // 
            // txtCodiceFiscale
            // 
            this.txtCodiceFiscale.Location = new System.Drawing.Point(92, 23);
            this.txtCodiceFiscale.Name = "txtCodiceFiscale";
            this.txtCodiceFiscale.ReadOnly = true;
            this.txtCodiceFiscale.Size = new System.Drawing.Size(100, 20);
            this.txtCodiceFiscale.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Codice fiscale";
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.txtContoDiAddebito);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.txtDataDiVersamento);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Location = new System.Drawing.Point(12, 191);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(670, 52);
            this.groupBox3.TabIndex = 11;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Modalità di versamento";
            // 
            // txtContoDiAddebito
            // 
            this.txtContoDiAddebito.Location = new System.Drawing.Point(303, 23);
            this.txtContoDiAddebito.Name = "txtContoDiAddebito";
            this.txtContoDiAddebito.ReadOnly = true;
            this.txtContoDiAddebito.Size = new System.Drawing.Size(332, 20);
            this.txtContoDiAddebito.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(213, 26);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(90, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Conto di addebito";
            // 
            // btnGeneraF24
            // 
            this.btnGeneraF24.AutoSize = true;
            this.btnGeneraF24.Location = new System.Drawing.Point(12, 63);
            this.btnGeneraF24.Name = "btnGeneraF24";
            this.btnGeneraF24.Size = new System.Drawing.Size(130, 34);
            this.btnGeneraF24.TabIndex = 12;
            this.btnGeneraF24.Text = "Genera Modello F24 EP";
            this.btnGeneraF24.UseVisualStyleBackColor = true;
            this.btnGeneraF24.Click += new System.EventHandler(this.btnGeneraF24_Click);
            // 
            // txtPercorso
            // 
            this.txtPercorso.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPercorso.Location = new System.Drawing.Point(177, 71);
            this.txtPercorso.Name = "txtPercorso";
            this.txtPercorso.ReadOnly = true;
            this.txtPercorso.Size = new System.Drawing.Size(505, 20);
            this.txtPercorso.TabIndex = 13;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 15);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(44, 13);
            this.label9.TabIndex = 14;
            this.label9.Text = "Numero";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(61, 12);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(65, 20);
            this.textBox3.TabIndex = 15;
            this.textBox3.Tag = "f24ep.idf24ep";
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(443, 44);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(102, 13);
            this.label10.TabIndex = 16;
            this.label10.Text = "Data di generazione";
            // 
            // txtDataGenerazione
            // 
            this.txtDataGenerazione.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDataGenerazione.Location = new System.Drawing.Point(552, 41);
            this.txtDataGenerazione.Name = "txtDataGenerazione";
            this.txtDataGenerazione.ReadOnly = true;
            this.txtDataGenerazione.Size = new System.Drawing.Size(129, 20);
            this.txtDataGenerazione.TabIndex = 17;
            this.txtDataGenerazione.Tag = "f24ep.adate";
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "T24";
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPageLiquidazioni);
            this.tabControl1.Controls.Add(this.tabPageSanzioni);
            this.tabControl1.Controls.Add(this.tabPageDetails);
            this.tabControl1.Controls.Add(this.tabPageIVA);
            this.tabControl1.Location = new System.Drawing.Point(12, 265);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(673, 300);
            this.tabControl1.TabIndex = 19;
            // 
            // tabPageLiquidazioni
            // 
            this.tabPageLiquidazioni.Controls.Add(this.groupBox1);
            this.tabPageLiquidazioni.Location = new System.Drawing.Point(4, 22);
            this.tabPageLiquidazioni.Name = "tabPageLiquidazioni";
            this.tabPageLiquidazioni.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageLiquidazioni.Size = new System.Drawing.Size(665, 274);
            this.tabPageLiquidazioni.TabIndex = 0;
            this.tabPageLiquidazioni.Text = "Liquidazioni";
            this.tabPageLiquidazioni.UseVisualStyleBackColor = true;
            // 
            // tabPageSanzioni
            // 
            this.tabPageSanzioni.Controls.Add(this.btnEliminaSanzione);
            this.tabPageSanzioni.Controls.Add(this.btnModificaSanzione);
            this.tabPageSanzioni.Controls.Add(this.btnInserisciSanzione);
            this.tabPageSanzioni.Controls.Add(this.gridSanzioni);
            this.tabPageSanzioni.Location = new System.Drawing.Point(4, 22);
            this.tabPageSanzioni.Name = "tabPageSanzioni";
            this.tabPageSanzioni.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageSanzioni.Size = new System.Drawing.Size(665, 274);
            this.tabPageSanzioni.TabIndex = 1;
            this.tabPageSanzioni.Text = "Sanzioni Ravvedimento";
            this.tabPageSanzioni.UseVisualStyleBackColor = true;
            // 
            // btnEliminaSanzione
            // 
            this.btnEliminaSanzione.Location = new System.Drawing.Point(12, 84);
            this.btnEliminaSanzione.Name = "btnEliminaSanzione";
            this.btnEliminaSanzione.Size = new System.Drawing.Size(72, 23);
            this.btnEliminaSanzione.TabIndex = 21;
            this.btnEliminaSanzione.TabStop = false;
            this.btnEliminaSanzione.Tag = "delete";
            this.btnEliminaSanzione.Text = "Elimina";
            // 
            // btnModificaSanzione
            // 
            this.btnModificaSanzione.Location = new System.Drawing.Point(12, 52);
            this.btnModificaSanzione.Name = "btnModificaSanzione";
            this.btnModificaSanzione.Size = new System.Drawing.Size(72, 23);
            this.btnModificaSanzione.TabIndex = 20;
            this.btnModificaSanzione.TabStop = false;
            this.btnModificaSanzione.Tag = "edit.single";
            this.btnModificaSanzione.Text = "Modifica";
            // 
            // btnInserisciSanzione
            // 
            this.btnInserisciSanzione.Location = new System.Drawing.Point(12, 20);
            this.btnInserisciSanzione.Name = "btnInserisciSanzione";
            this.btnInserisciSanzione.Size = new System.Drawing.Size(72, 23);
            this.btnInserisciSanzione.TabIndex = 19;
            this.btnInserisciSanzione.TabStop = false;
            this.btnInserisciSanzione.Tag = "insert.single";
            this.btnInserisciSanzione.Text = "Inserisci";
            // 
            // gridSanzioni
            // 
            this.gridSanzioni.AllowNavigation = false;
            this.gridSanzioni.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridSanzioni.DataMember = "";
            this.gridSanzioni.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.gridSanzioni.Location = new System.Drawing.Point(90, 17);
            this.gridSanzioni.Name = "gridSanzioni";
            this.gridSanzioni.Size = new System.Drawing.Size(569, 243);
            this.gridSanzioni.TabIndex = 9;
            this.gridSanzioni.TabStop = false;
            this.gridSanzioni.Tag = "f24epsanction.default.single";
            // 
            // tabPageDetails
            // 
            this.tabPageDetails.Controls.Add(this.btnRimuoviDetail);
            this.tabPageDetails.Controls.Add(this.btnModificaDetail);
            this.tabPageDetails.Controls.Add(this.btnInserisciDetail);
            this.tabPageDetails.Controls.Add(this.GridDetails);
            this.tabPageDetails.Location = new System.Drawing.Point(4, 22);
            this.tabPageDetails.Name = "tabPageDetails";
            this.tabPageDetails.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageDetails.Size = new System.Drawing.Size(665, 274);
            this.tabPageDetails.TabIndex = 2;
            this.tabPageDetails.Text = "Interventi Sostitutivi";
            this.tabPageDetails.UseVisualStyleBackColor = true;
            // 
            // btnRimuoviDetail
            // 
            this.btnRimuoviDetail.Location = new System.Drawing.Point(11, 55);
            this.btnRimuoviDetail.Name = "btnRimuoviDetail";
            this.btnRimuoviDetail.Size = new System.Drawing.Size(82, 23);
            this.btnRimuoviDetail.TabIndex = 11;
            this.btnRimuoviDetail.Tag = "";
            this.btnRimuoviDetail.Text = "Rimuovi";
            this.btnRimuoviDetail.UseVisualStyleBackColor = true;
            this.btnRimuoviDetail.Click += new System.EventHandler(this.btnRimuoviDetail_Click);
            // 
            // btnModificaDetail
            // 
            this.btnModificaDetail.Location = new System.Drawing.Point(11, 84);
            this.btnModificaDetail.Name = "btnModificaDetail";
            this.btnModificaDetail.Size = new System.Drawing.Size(82, 23);
            this.btnModificaDetail.TabIndex = 12;
            this.btnModificaDetail.Text = "Modifica...";
            this.btnModificaDetail.UseVisualStyleBackColor = true;
            this.btnModificaDetail.Click += new System.EventHandler(this.btnModificaDetail_Click);
            // 
            // btnInserisciDetail
            // 
            this.btnInserisciDetail.Location = new System.Drawing.Point(11, 26);
            this.btnInserisciDetail.Name = "btnInserisciDetail";
            this.btnInserisciDetail.Size = new System.Drawing.Size(82, 23);
            this.btnInserisciDetail.TabIndex = 10;
            this.btnInserisciDetail.Text = "Inserisci";
            this.btnInserisciDetail.UseVisualStyleBackColor = true;
            this.btnInserisciDetail.Click += new System.EventHandler(this.btnInserisciDetail_Click);
            // 
            // GridDetails
            // 
            this.GridDetails.AllowNavigation = false;
            this.GridDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GridDetails.DataMember = "";
            this.GridDetails.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.GridDetails.Location = new System.Drawing.Point(104, 22);
            this.GridDetails.Name = "GridDetails";
            this.GridDetails.Size = new System.Drawing.Size(551, 231);
            this.GridDetails.TabIndex = 9;
            this.GridDetails.TabStop = false;
            this.GridDetails.Tag = "expenseclawbackview.dettagliocollegato";
            // 
            // tabPageIVA
            // 
            this.tabPageIVA.Controls.Add(this.button2);
            this.tabPageIVA.Controls.Add(this.button3);
            this.tabPageIVA.Controls.Add(this.button4);
            this.tabPageIVA.Controls.Add(this.gridIVA);
            this.tabPageIVA.Location = new System.Drawing.Point(4, 22);
            this.tabPageIVA.Name = "tabPageIVA";
            this.tabPageIVA.Size = new System.Drawing.Size(636, 274);
            this.tabPageIVA.TabIndex = 3;
            this.tabPageIVA.Text = "IVA";
            this.tabPageIVA.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(11, 42);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(82, 23);
            this.button2.TabIndex = 11;
            this.button2.Text = "Rimuovi";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(11, 71);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(82, 23);
            this.button3.TabIndex = 12;
            this.button3.Text = "Modifica...";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(11, 13);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(82, 23);
            this.button4.TabIndex = 10;
            this.button4.Text = "Inserisci";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // gridIVA
            // 
            this.gridIVA.AllowNavigation = false;
            this.gridIVA.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridIVA.DataMember = "";
            this.gridIVA.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.gridIVA.Location = new System.Drawing.Point(104, 9);
            this.gridIVA.Name = "gridIVA";
            this.gridIVA.Size = new System.Drawing.Size(522, 248);
            this.gridIVA.TabIndex = 9;
            this.gridIVA.TabStop = false;
            this.gridIVA.Tag = "ivapay.default";
            // 
            // grpTotaleAddebito
            // 
            this.grpTotaleAddebito.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpTotaleAddebito.Controls.Add(this.txtTotaleAddebito);
            this.grpTotaleAddebito.Location = new System.Drawing.Point(409, 247);
            this.grpTotaleAddebito.Name = "grpTotaleAddebito";
            this.grpTotaleAddebito.Size = new System.Drawing.Size(273, 33);
            this.grpTotaleAddebito.TabIndex = 20;
            this.grpTotaleAddebito.TabStop = false;
            this.grpTotaleAddebito.Text = "Totale Addebito";
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.EnforceConstraints = false;
            // 
            // cmbMese
            // 
            this.cmbMese.DataSource = this.DS.monthname;
            this.cmbMese.DisplayMember = "title";
            this.cmbMese.FormattingEnabled = true;
            this.cmbMese.Location = new System.Drawing.Point(392, 10);
            this.cmbMese.Name = "cmbMese";
            this.cmbMese.Size = new System.Drawing.Size(154, 21);
            this.cmbMese.TabIndex = 21;
            this.cmbMese.Tag = "f24ep.nmonth";
            this.cmbMese.ValueMember = "code";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(283, 14);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(98, 13);
            this.label6.TabIndex = 22;
            this.label6.Text = "Mese dichiarazione";
            // 
            // button1
            // 
            this.button1.AutoSize = true;
            this.button1.Location = new System.Drawing.Point(12, 35);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(130, 23);
            this.button1.TabIndex = 23;
            this.button1.Text = "Esporta Dati in Excel";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.txtDataUltimaLiquid);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.txtDataPrimaLiquid);
            this.groupBox4.Location = new System.Drawing.Point(3, 147);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(121, 104);
            this.groupBox4.TabIndex = 24;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Periodo competenza";
            // 
            // FrmF24ep_default
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(694, 569);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cmbMese);
            this.Controls.Add(this.grpTotaleAddebito);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.txtDataGenerazione);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtPercorso);
            this.Controls.Add(this.btnGeneraF24);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtEsercizio);
            this.Name = "FrmF24ep_default";
            this.Text = "FrmF24ep_default";
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridLiquidazioni)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPageLiquidazioni.ResumeLayout(false);
            this.tabPageLiquidazioni.PerformLayout();
            this.tabPageSanzioni.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridSanzioni)).EndInit();
            this.tabPageDetails.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GridDetails)).EndInit();
            this.tabPageIVA.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridIVA)).EndInit();
            this.grpTotaleAddebito.ResumeLayout(false);
            this.grpTotaleAddebito.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnRimuovi;
        private System.Windows.Forms.Button btnModifica;
        private System.Windows.Forms.Button btnInserisci;
        private System.Windows.Forms.TextBox txtEsercizio;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDataDiVersamento;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtDenominazione;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtCodiceFiscale;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtContoDiAddebito;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnGeneraF24;
        private System.Windows.Forms.TextBox txtPercorso;
        public vistaForm DS;
        private System.Windows.Forms.TextBox txtTotaleAddebito;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtDataUltimaLiquid;
        private System.Windows.Forms.TextBox txtDataPrimaLiquid;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtDataGenerazione;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.DataGrid gridLiquidazioni;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageLiquidazioni;
        private System.Windows.Forms.TabPage tabPageSanzioni;
        private System.Windows.Forms.DataGrid gridSanzioni;
        private System.Windows.Forms.Button btnEliminaSanzione;
        private System.Windows.Forms.Button btnModificaSanzione;
        private System.Windows.Forms.Button btnInserisciSanzione;
        private System.Windows.Forms.GroupBox grpTotaleAddebito;
        private System.Windows.Forms.ComboBox cmbMese;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TabPage tabPageDetails;
        private System.Windows.Forms.Button btnRimuoviDetail;
        private System.Windows.Forms.Button btnModificaDetail;
        private System.Windows.Forms.Button btnInserisciDetail;
        private System.Windows.Forms.DataGrid GridDetails;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TabPage tabPageIVA;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.DataGrid gridIVA;
        private System.Windows.Forms.GroupBox groupBox4;
    }
}
