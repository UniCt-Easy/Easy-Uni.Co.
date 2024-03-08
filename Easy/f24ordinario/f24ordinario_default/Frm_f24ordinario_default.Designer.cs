
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



namespace f24ordinario_default
{
	partial class Frm_f24ordinario_default
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
			this.DS = new f24ordinario_default.vistaForm();
			this.button1 = new System.Windows.Forms.Button();
			this.label6 = new System.Windows.Forms.Label();
			this.cmbMese = new System.Windows.Forms.ComboBox();
			this.grpTotaleAddebito = new System.Windows.Forms.GroupBox();
			this.txtTotaleAddebito = new System.Windows.Forms.TextBox();
			this.txtDataGenerazione = new System.Windows.Forms.TextBox();
			this.label10 = new System.Windows.Forms.Label();
			this.textBox3 = new System.Windows.Forms.TextBox();
			this.label9 = new System.Windows.Forms.Label();
			this.txtPercorso = new System.Windows.Forms.TextBox();
			this.btnGeneraf24ordinario = new System.Windows.Forms.Button();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.txtContoDiAddebito = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.txtDataDiVersamento = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.label = new System.Windows.Forms.Label();
			this.txtEmail = new System.Windows.Forms.TextBox();
			this.txtDenominazione = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.txtCodiceFiscale = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.txtEsercizio = new System.Windows.Forms.TextBox();
			this._saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
			this.saveFileDialog1 = createSaveFileDialog(_saveFileDialog1);
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPageLiquidazioni = new System.Windows.Forms.TabPage();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.txtDataUltimaLiquid = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.txtDataPrimaLiquid = new System.Windows.Forms.TextBox();
			this.btnRimuovi = new System.Windows.Forms.Button();
			this.btnModifica = new System.Windows.Forms.Button();
			this.btnInserisci = new System.Windows.Forms.Button();
			this.gridLiquidazioni = new System.Windows.Forms.DataGrid();
			this.tabPageIVA = new System.Windows.Forms.TabPage();
			this.btnDeleteIVA = new System.Windows.Forms.Button();
			this.btnEditIVA = new System.Windows.Forms.Button();
			this.btnInsertIVA = new System.Windows.Forms.Button();
			this.gridIVA = new System.Windows.Forms.DataGrid();
			this.tabPageSezioneManuale = new System.Windows.Forms.TabPage();
			this.btnRimuoviSezione = new System.Windows.Forms.Button();
			this.btnModificaSezione = new System.Windows.Forms.Button();
			this.btnInsertSezione = new System.Windows.Forms.Button();
			this.dataGridManuale = new System.Windows.Forms.DataGrid();
			this.btnImport = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
			this.grpTotaleAddebito.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.tabControl1.SuspendLayout();
			this.tabPageLiquidazioni.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.groupBox4.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.gridLiquidazioni)).BeginInit();
			this.tabPageIVA.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.gridIVA)).BeginInit();
			this.tabPageSezioneManuale.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridManuale)).BeginInit();
			this.SuspendLayout();
			// 
			// DS
			// 
			this.DS.DataSetName = "vistaForm";
			// 
			// button1
			// 
			this.button1.AutoSize = true;
			this.button1.Location = new System.Drawing.Point(12, 42);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(130, 23);
			this.button1.TabIndex = 37;
			this.button1.Text = "Esporta Dati in Excel";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(283, 21);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(95, 13);
			this.label6.TabIndex = 36;
			this.label6.Text = "Mese di riferimento";
			// 
			// cmbMese
			// 
			this.cmbMese.DataSource = this.DS.monthname;
			this.cmbMese.DisplayMember = "title";
			this.cmbMese.FormattingEnabled = true;
			this.cmbMese.Location = new System.Drawing.Point(392, 17);
			this.cmbMese.Name = "cmbMese";
			this.cmbMese.Size = new System.Drawing.Size(154, 21);
			this.cmbMese.TabIndex = 35;
			this.cmbMese.Tag = "f24ordinario.nmonth";
			this.cmbMese.ValueMember = "code";
			// 
			// grpTotaleAddebito
			// 
			this.grpTotaleAddebito.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.grpTotaleAddebito.Controls.Add(this.txtTotaleAddebito);
			this.grpTotaleAddebito.Location = new System.Drawing.Point(409, 254);
			this.grpTotaleAddebito.Name = "grpTotaleAddebito";
			this.grpTotaleAddebito.Size = new System.Drawing.Size(273, 33);
			this.grpTotaleAddebito.TabIndex = 34;
			this.grpTotaleAddebito.TabStop = false;
			this.grpTotaleAddebito.Text = "Totale Addebito";
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
			// txtDataGenerazione
			// 
			this.txtDataGenerazione.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtDataGenerazione.Location = new System.Drawing.Point(552, 48);
			this.txtDataGenerazione.Name = "txtDataGenerazione";
			this.txtDataGenerazione.ReadOnly = true;
			this.txtDataGenerazione.Size = new System.Drawing.Size(129, 20);
			this.txtDataGenerazione.TabIndex = 33;
			this.txtDataGenerazione.Tag = "f24ordinario.adate";
			// 
			// label10
			// 
			this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(443, 51);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(102, 13);
			this.label10.TabIndex = 32;
			this.label10.Text = "Data di generazione";
			// 
			// textBox3
			// 
			this.textBox3.Location = new System.Drawing.Point(61, 19);
			this.textBox3.Name = "textBox3";
			this.textBox3.Size = new System.Drawing.Size(65, 20);
			this.textBox3.TabIndex = 31;
			this.textBox3.Tag = "f24ordinario.idf24ordinario";
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(12, 22);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(44, 13);
			this.label9.TabIndex = 30;
			this.label9.Text = "Numero";
			// 
			// txtPercorso
			// 
			this.txtPercorso.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtPercorso.Location = new System.Drawing.Point(177, 78);
			this.txtPercorso.Name = "txtPercorso";
			this.txtPercorso.ReadOnly = true;
			this.txtPercorso.Size = new System.Drawing.Size(505, 20);
			this.txtPercorso.TabIndex = 29;
			// 
			// btnGeneraf24ordinario
			// 
			this.btnGeneraf24ordinario.AutoSize = true;
			this.btnGeneraf24ordinario.Location = new System.Drawing.Point(12, 70);
			this.btnGeneraf24ordinario.Name = "btnGeneraf24ordinario";
			this.btnGeneraf24ordinario.Size = new System.Drawing.Size(158, 34);
			this.btnGeneraf24ordinario.TabIndex = 28;
			this.btnGeneraf24ordinario.Text = "Genera Modello F24 Ordinario";
			this.btnGeneraf24ordinario.UseVisualStyleBackColor = true;
			this.btnGeneraf24ordinario.Click += new System.EventHandler(this.btnGeneraf24ordinario_Click);
			// 
			// groupBox3
			// 
			this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox3.Controls.Add(this.txtContoDiAddebito);
			this.groupBox3.Controls.Add(this.label5);
			this.groupBox3.Controls.Add(this.txtDataDiVersamento);
			this.groupBox3.Controls.Add(this.label2);
			this.groupBox3.Location = new System.Drawing.Point(12, 198);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(670, 52);
			this.groupBox3.TabIndex = 27;
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
			// txtDataDiVersamento
			// 
			this.txtDataDiVersamento.Location = new System.Drawing.Point(92, 23);
			this.txtDataDiVersamento.Name = "txtDataDiVersamento";
			this.txtDataDiVersamento.Size = new System.Drawing.Size(100, 20);
			this.txtDataDiVersamento.TabIndex = 9;
			this.txtDataDiVersamento.Tag = "f24ordinario.paymentdate";
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
			this.groupBox2.Location = new System.Drawing.Point(12, 111);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(670, 81);
			this.groupBox2.TabIndex = 26;
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
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(136, 22);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(49, 13);
			this.label1.TabIndex = 25;
			this.label1.Text = "Esercizio";
			// 
			// txtEsercizio
			// 
			this.txtEsercizio.Location = new System.Drawing.Point(185, 19);
			this.txtEsercizio.Name = "txtEsercizio";
			this.txtEsercizio.ReadOnly = true;
			this.txtEsercizio.Size = new System.Drawing.Size(67, 20);
			this.txtEsercizio.TabIndex = 24;
			this.txtEsercizio.Tag = "f24ordinario.ayear";
			// 
			// saveFileDialog1
			// 
			//this.saveFileDialog1.DefaultExt = "T24";
			// 
			// tabControl1
			// 
			this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tabControl1.Controls.Add(this.tabPageLiquidazioni);
			this.tabControl1.Controls.Add(this.tabPageIVA);
			this.tabControl1.Controls.Add(this.tabPageSezioneManuale);
			this.tabControl1.Location = new System.Drawing.Point(8, 287);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(673, 288);
			this.tabControl1.TabIndex = 38;
			// 
			// tabPageLiquidazioni
			// 
			this.tabPageLiquidazioni.Controls.Add(this.groupBox1);
			this.tabPageLiquidazioni.Location = new System.Drawing.Point(4, 22);
			this.tabPageLiquidazioni.Name = "tabPageLiquidazioni";
			this.tabPageLiquidazioni.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageLiquidazioni.Size = new System.Drawing.Size(665, 262);
			this.tabPageLiquidazioni.TabIndex = 0;
			this.tabPageLiquidazioni.Text = "Ritenute";
			this.tabPageLiquidazioni.UseVisualStyleBackColor = true;
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
			this.groupBox1.Size = new System.Drawing.Size(662, 270);
			this.groupBox1.TabIndex = 5;
			this.groupBox1.TabStop = false;
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
			// txtDataUltimaLiquid
			// 
			this.txtDataUltimaLiquid.Location = new System.Drawing.Point(11, 76);
			this.txtDataUltimaLiquid.Name = "txtDataUltimaLiquid";
			this.txtDataUltimaLiquid.Size = new System.Drawing.Size(82, 20);
			this.txtDataUltimaLiquid.TabIndex = 4;
			this.txtDataUltimaLiquid.Tag = "f24ordinario.taxpay_stop";
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
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(11, 21);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(56, 13);
			this.label7.TabIndex = 14;
			this.label7.Text = "Data inizio";
			// 
			// txtDataPrimaLiquid
			// 
			this.txtDataPrimaLiquid.Location = new System.Drawing.Point(11, 37);
			this.txtDataPrimaLiquid.Name = "txtDataPrimaLiquid";
			this.txtDataPrimaLiquid.Size = new System.Drawing.Size(82, 20);
			this.txtDataPrimaLiquid.TabIndex = 16;
			this.txtDataPrimaLiquid.Tag = "f24ordinario.taxpay_start";
			// 
			// btnRimuovi
			// 
			this.btnRimuovi.Location = new System.Drawing.Point(11, 87);
			this.btnRimuovi.Name = "btnRimuovi";
			this.btnRimuovi.Size = new System.Drawing.Size(101, 23);
			this.btnRimuovi.TabIndex = 7;
			this.btnRimuovi.Text = "Rimuovi";
			this.btnRimuovi.UseVisualStyleBackColor = true;
			this.btnRimuovi.Click += new System.EventHandler(this.btnRimuovi_Click);
			// 
			// btnModifica
			// 
			this.btnModifica.Location = new System.Drawing.Point(11, 51);
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
			this.gridLiquidazioni.Size = new System.Drawing.Size(527, 227);
			this.gridLiquidazioni.TabIndex = 4;
			this.gridLiquidazioni.TabStop = false;
			this.gridLiquidazioni.Tag = "taxpayview.liqcollegataF24ord";
			// 
			// tabPageIVA
			// 
			this.tabPageIVA.Controls.Add(this.btnDeleteIVA);
			this.tabPageIVA.Controls.Add(this.btnEditIVA);
			this.tabPageIVA.Controls.Add(this.btnInsertIVA);
			this.tabPageIVA.Controls.Add(this.gridIVA);
			this.tabPageIVA.Location = new System.Drawing.Point(4, 22);
			this.tabPageIVA.Name = "tabPageIVA";
			this.tabPageIVA.Size = new System.Drawing.Size(665, 262);
			this.tabPageIVA.TabIndex = 3;
			this.tabPageIVA.Text = "IVA";
			this.tabPageIVA.UseVisualStyleBackColor = true;
			// 
			// btnDeleteIVA
			// 
			this.btnDeleteIVA.Location = new System.Drawing.Point(11, 85);
			this.btnDeleteIVA.Name = "btnDeleteIVA";
			this.btnDeleteIVA.Size = new System.Drawing.Size(82, 23);
			this.btnDeleteIVA.TabIndex = 11;
			this.btnDeleteIVA.Text = "Rimuovi";
			this.btnDeleteIVA.UseVisualStyleBackColor = true;
			this.btnDeleteIVA.Click += new System.EventHandler(this.btnDeleteIVA_Click);
			// 
			// btnEditIVA
			// 
			this.btnEditIVA.Location = new System.Drawing.Point(11, 48);
			this.btnEditIVA.Name = "btnEditIVA";
			this.btnEditIVA.Size = new System.Drawing.Size(82, 23);
			this.btnEditIVA.TabIndex = 12;
			this.btnEditIVA.Text = "Modifica...";
			this.btnEditIVA.UseVisualStyleBackColor = true;
			this.btnEditIVA.Click += new System.EventHandler(this.btnEditIVA_Click);
			// 
			// btnInsertIVA
			// 
			this.btnInsertIVA.Location = new System.Drawing.Point(11, 13);
			this.btnInsertIVA.Name = "btnInsertIVA";
			this.btnInsertIVA.Size = new System.Drawing.Size(82, 23);
			this.btnInsertIVA.TabIndex = 10;
			this.btnInsertIVA.Text = "Inserisci";
			this.btnInsertIVA.UseVisualStyleBackColor = true;
			this.btnInsertIVA.Click += new System.EventHandler(this.btnInsertIVA_Click);
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
			this.gridIVA.Size = new System.Drawing.Size(522, 236);
			this.gridIVA.TabIndex = 9;
			this.gridIVA.TabStop = false;
			this.gridIVA.Tag = "ivapay.liqcollegataF24ord";
			// 
			// tabPageSezioneManuale
			// 
			this.tabPageSezioneManuale.Controls.Add(this.btnRimuoviSezione);
			this.tabPageSezioneManuale.Controls.Add(this.btnModificaSezione);
			this.tabPageSezioneManuale.Controls.Add(this.btnInsertSezione);
			this.tabPageSezioneManuale.Controls.Add(this.dataGridManuale);
			this.tabPageSezioneManuale.Location = new System.Drawing.Point(4, 22);
			this.tabPageSezioneManuale.Name = "tabPageSezioneManuale";
			this.tabPageSezioneManuale.Size = new System.Drawing.Size(665, 262);
			this.tabPageSezioneManuale.TabIndex = 4;
			this.tabPageSezioneManuale.Text = "Inserimento Sezione F24 manuale";
			this.tabPageSezioneManuale.UseVisualStyleBackColor = true;
			// 
			// btnRimuoviSezione
			// 
			this.btnRimuoviSezione.Location = new System.Drawing.Point(11, 82);
			this.btnRimuoviSezione.Name = "btnRimuoviSezione";
			this.btnRimuoviSezione.Size = new System.Drawing.Size(82, 23);
			this.btnRimuoviSezione.TabIndex = 15;
			this.btnRimuoviSezione.Tag = "delete";
			this.btnRimuoviSezione.Text = "Rimuovi";
			this.btnRimuoviSezione.UseVisualStyleBackColor = true;
			// 
			// btnModificaSezione
			// 
			this.btnModificaSezione.Location = new System.Drawing.Point(11, 46);
			this.btnModificaSezione.Name = "btnModificaSezione";
			this.btnModificaSezione.Size = new System.Drawing.Size(82, 23);
			this.btnModificaSezione.TabIndex = 16;
			this.btnModificaSezione.Tag = "edit.single";
			this.btnModificaSezione.Text = "Modifica...";
			this.btnModificaSezione.UseVisualStyleBackColor = true;
			// 
			// btnInsertSezione
			// 
			this.btnInsertSezione.Location = new System.Drawing.Point(11, 13);
			this.btnInsertSezione.Name = "btnInsertSezione";
			this.btnInsertSezione.Size = new System.Drawing.Size(82, 23);
			this.btnInsertSezione.TabIndex = 14;
			this.btnInsertSezione.Tag = "insert.single";
			this.btnInsertSezione.Text = "Inserisci";
			this.btnInsertSezione.UseVisualStyleBackColor = true;
			// 
			// dataGridManuale
			// 
			this.dataGridManuale.AllowNavigation = false;
			this.dataGridManuale.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dataGridManuale.DataMember = "";
			this.dataGridManuale.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGridManuale.Location = new System.Drawing.Point(104, 9);
			this.dataGridManuale.Name = "dataGridManuale";
			this.dataGridManuale.Size = new System.Drawing.Size(548, 236);
			this.dataGridManuale.TabIndex = 13;
			this.dataGridManuale.TabStop = false;
			this.dataGridManuale.Tag = "f24ordinariodetail.lista";
			// 
			// btnImport
			// 
			this.btnImport.AutoSize = true;
			this.btnImport.Location = new System.Drawing.Point(164, 42);
			this.btnImport.Name = "btnImport";
			this.btnImport.Size = new System.Drawing.Size(199, 23);
			this.btnImport.TabIndex = 39;
			this.btnImport.Text = "Importa F24 da File Emisti (CSV)";
			this.btnImport.UseVisualStyleBackColor = true;
			this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
			// 
			// Frm_f24ordinario_default
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(694, 587);
			this.Controls.Add(this.btnImport);
			this.Controls.Add(this.tabControl1);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.cmbMese);
			this.Controls.Add(this.grpTotaleAddebito);
			this.Controls.Add(this.txtDataGenerazione);
			this.Controls.Add(this.label10);
			this.Controls.Add(this.textBox3);
			this.Controls.Add(this.label9);
			this.Controls.Add(this.txtPercorso);
			this.Controls.Add(this.btnGeneraf24ordinario);
			this.Controls.Add(this.groupBox3);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.txtEsercizio);
			this.Name = "Frm_f24ordinario_default";
			this.Text = "Frm_f24ordinario_default";
			((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
			this.grpTotaleAddebito.ResumeLayout(false);
			this.grpTotaleAddebito.PerformLayout();
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.tabControl1.ResumeLayout(false);
			this.tabPageLiquidazioni.ResumeLayout(false);
			this.tabPageLiquidazioni.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			this.groupBox4.ResumeLayout(false);
			this.groupBox4.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.gridLiquidazioni)).EndInit();
			this.tabPageIVA.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.gridIVA)).EndInit();
			this.tabPageSezioneManuale.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataGridManuale)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		public vistaForm DS;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.ComboBox cmbMese;
		private System.Windows.Forms.GroupBox grpTotaleAddebito;
		private System.Windows.Forms.TextBox txtTotaleAddebito;
		private System.Windows.Forms.TextBox txtDataGenerazione;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.TextBox textBox3;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.TextBox txtPercorso;
		private System.Windows.Forms.Button btnGeneraf24ordinario;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.TextBox txtContoDiAddebito;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox txtDataDiVersamento;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label label;
		private System.Windows.Forms.TextBox txtEmail;
		private System.Windows.Forms.TextBox txtDenominazione;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox txtCodiceFiscale;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtEsercizio;
		private System.Windows.Forms.SaveFileDialog _saveFileDialog1;
		private metadatalibrary.ISaveFileDialog saveFileDialog1;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPageLiquidazioni;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.TextBox txtDataUltimaLiquid;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox txtDataPrimaLiquid;
		private System.Windows.Forms.Button btnRimuovi;
		private System.Windows.Forms.Button btnModifica;
		private System.Windows.Forms.Button btnInserisci;
		private System.Windows.Forms.DataGrid gridLiquidazioni;
		private System.Windows.Forms.TabPage tabPageIVA;
		private System.Windows.Forms.Button btnDeleteIVA;
		private System.Windows.Forms.Button btnEditIVA;
		private System.Windows.Forms.Button btnInsertIVA;
		private System.Windows.Forms.DataGrid gridIVA;
		private System.Windows.Forms.TabPage tabPageSezioneManuale;
		private System.Windows.Forms.Button btnRimuoviSezione;
		private System.Windows.Forms.Button btnModificaSezione;
		private System.Windows.Forms.Button btnInsertSezione;
		private System.Windows.Forms.DataGrid dataGridManuale;
		private System.Windows.Forms.Button btnImport;
	}
}
