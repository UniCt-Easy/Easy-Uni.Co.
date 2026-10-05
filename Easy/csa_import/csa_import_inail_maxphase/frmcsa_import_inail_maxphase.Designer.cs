/*
Easy
Copyright (C) 2026 Università degli Studi di Catania (www.unict.it)
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

namespace csa_import_inail_maxphase {
	partial class frmcsa_import_inail_maxphase {
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmcsa_import_inail_maxphase));
			this.dsFinancial = new csa_import_inail_maxphase.dsFinancial();
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnNext = new System.Windows.Forms.Button();
			this.btnBack = new System.Windows.Forms.Button();
			this.tabController = new Crownwood.Magic.Controls.TabControl();
			this.tabIntro = new Crownwood.Magic.Controls.TabPage();
			this.labelIntro = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.tabLordi = new Crownwood.Magic.Controls.TabPage();
			this.label2 = new System.Windows.Forms.Label();
			this.btnVerificaLordi = new System.Windows.Forms.Button();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.dgrVerificheLordi = new System.Windows.Forms.DataGrid();
			this.grpVerificheLordi = new System.Windows.Forms.GroupBox();
			this.dgrLordiPosticipati = new System.Windows.Forms.DataGrid();
			this.btnLordi = new System.Windows.Forms.Button();
			this.tabSelectVersamenti = new Crownwood.Magic.Controls.TabPage();
			this.btnVerifica = new System.Windows.Forms.Button();
			this.btnDelSospesi = new System.Windows.Forms.Button();
			this.lblTask = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.dgrSospesi = new System.Windows.Forms.DataGrid();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.dgrVerificheFin = new System.Windows.Forms.DataGrid();
			this.btnInputSospesi = new System.Windows.Forms.Button();
			this.gBoxBollettaVersamenti = new System.Windows.Forms.GroupBox();
			this.label8 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.txtNumBollettaVersamenti = new System.Windows.Forms.TextBox();
			this.txtEsercBollettaVersamenti = new System.Windows.Forms.TextBox();
			this.btnBollettaVersamenti = new System.Windows.Forms.Button();
			this.grpVerifiche = new System.Windows.Forms.GroupBox();
			this.dgrVersamentiAnnuali = new System.Windows.Forms.DataGrid();
			this.btnVersamenti = new System.Windows.Forms.Button();
			this.tabRisultati = new Crownwood.Magic.Controls.TabPage();
			this.labelRisultato = new System.Windows.Forms.Label();
			//this.progressBarImport = new System.Windows.Forms.ProgressBar();
			this.panel1 = new System.Windows.Forms.Panel();
			this.DS = new csa_import_inail_maxphase.dsmeta();
			this._openInputFileDlg = new System.Windows.Forms.OpenFileDialog();
			this.CMenu = new System.Windows.Forms.ContextMenu();
			this.MenuEnterPwd = new System.Windows.Forms.MenuItem();
			((System.ComponentModel.ISupportInitialize)(this.dsFinancial)).BeginInit();
			this.tabController.SuspendLayout();
			this.tabIntro.SuspendLayout();
			this.tabLordi.SuspendLayout();
			this.groupBox4.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgrVerificheLordi)).BeginInit();
			this.grpVerificheLordi.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgrLordiPosticipati)).BeginInit();
			this.tabSelectVersamenti.SuspendLayout();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgrSospesi)).BeginInit();
			this.groupBox2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgrVerificheFin)).BeginInit();
			this.gBoxBollettaVersamenti.SuspendLayout();
			this.grpVerifiche.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgrVersamentiAnnuali)).BeginInit();
			this.tabRisultati.SuspendLayout();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
			this.SuspendLayout();
			// 
			// dsFinancial
			// 
			this.dsFinancial.DataSetName = "dsFinancial";
			this.dsFinancial.EnforceConstraints = false;
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(732, 548);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 23);
			this.btnCancel.TabIndex = 13;
			this.btnCancel.Tag = "maincancel";
			this.btnCancel.Text = "Cancel";
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// btnNext
			// 
			this.btnNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnNext.Location = new System.Drawing.Point(612, 548);
			this.btnNext.Name = "btnNext";
			this.btnNext.Size = new System.Drawing.Size(88, 23);
			this.btnNext.TabIndex = 12;
			this.btnNext.Text = "Avanti >";
			this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
			// 
			// btnBack
			// 
			this.btnBack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnBack.Location = new System.Drawing.Point(524, 548);
			this.btnBack.Name = "btnBack";
			this.btnBack.Size = new System.Drawing.Size(80, 23);
			this.btnBack.TabIndex = 11;
			this.btnBack.Text = "< Indietro";
			this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
			// 
			// tabController
			// 
			this.tabController.AutoSize = true;
			this.tabController.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabController.IDEPixelArea = true;
			this.tabController.Location = new System.Drawing.Point(0, 0);
			this.tabController.Name = "tabController";
			this.tabController.SelectedIndex = 0;
			this.tabController.SelectedTab = this.tabIntro;
			this.tabController.Size = new System.Drawing.Size(808, 542);
			this.tabController.TabIndex = 0;
			this.tabController.TabPages.AddRange(new Crownwood.Magic.Controls.TabPage[] {
            this.tabIntro,
            this.tabLordi,
            this.tabSelectVersamenti,
            this.tabRisultati});
			// 
			// tabIntro
			// 
			this.tabIntro.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tabIntro.Controls.Add(this.labelIntro);
			this.tabIntro.Controls.Add(this.label3);
			this.tabIntro.Controls.Add(this.label1);
			this.tabIntro.Location = new System.Drawing.Point(0, 0);
			this.tabIntro.Name = "tabIntro";
			this.tabIntro.Size = new System.Drawing.Size(808, 517);
			this.tabIntro.TabIndex = 3;
			this.tabIntro.Title = "Pagina 1 di 3";
			// 
			// labelIntro
			// 
			this.labelIntro.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.labelIntro.Location = new System.Drawing.Point(12, 22);
			this.labelIntro.Name = "labelIntro";
			this.labelIntro.Size = new System.Drawing.Size(749, 48);
			this.labelIntro.TabIndex = 6;
			this.labelIntro.Text = resources.GetString("labelIntro.Text");
			// 
			// label3
			// 
			this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.label3.Location = new System.Drawing.Point(12, 91);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(749, 40);
			this.label3.TabIndex = 5;
			this.label3.Text = resources.GetString("label3.Text");
			// 
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.label1.ForeColor = System.Drawing.SystemColors.Highlight;
			this.label1.Location = new System.Drawing.Point(12, 153);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(749, 53);
			this.label1.TabIndex = 3;
			this.label1.Text = resources.GetString("label1.Text");
			// 
			// tabLordi
			// 
			this.tabLordi.Controls.Add(this.label2);
			this.tabLordi.Controls.Add(this.btnVerificaLordi);
			this.tabLordi.Controls.Add(this.groupBox4);
			this.tabLordi.Controls.Add(this.grpVerificheLordi);
			this.tabLordi.Controls.Add(this.btnLordi);
			this.tabLordi.Location = new System.Drawing.Point(0, 0);
			this.tabLordi.Name = "tabLordi";
			this.tabLordi.Selected = false;
			this.tabLordi.Size = new System.Drawing.Size(808, 517);
			this.tabLordi.TabIndex = 6;
			this.tabLordi.Title = "Pagina 2 di 3";
			// 
			// label2
			// 
			this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label2.Location = new System.Drawing.Point(18, 17);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(290, 21);
			this.label2.TabIndex = 37;
			this.label2.Text = "ELABORAZIONE LORDI POSTICIPATI";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// btnVerificaLordi
			// 
			this.btnVerificaLordi.Location = new System.Drawing.Point(9, 413);
			this.btnVerificaLordi.Name = "btnVerificaLordi";
			this.btnVerificaLordi.Size = new System.Drawing.Size(167, 41);
			this.btnVerificaLordi.TabIndex = 35;
			this.btnVerificaLordi.Text = "Verifica Disponibile Mov. finanziari Residui";
			this.btnVerificaLordi.Click += new System.EventHandler(this.btnVerificaLordi_Click);
			// 
			// groupBox4
			// 
			this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox4.Controls.Add(this.dgrVerificheLordi);
			this.groupBox4.Location = new System.Drawing.Point(12, 45);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(425, 161);
			this.groupBox4.TabIndex = 36;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "Verifiche";
			// 
			// dgrVerificheLordi
			// 
			this.dgrVerificheLordi.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dgrVerificheLordi.DataMember = "";
			this.dgrVerificheLordi.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dgrVerificheLordi.Location = new System.Drawing.Point(10, 19);
			this.dgrVerificheLordi.Name = "dgrVerificheLordi";
			this.dgrVerificheLordi.Size = new System.Drawing.Size(407, 131);
			this.dgrVerificheLordi.TabIndex = 4;
			this.dgrVerificheLordi.DoubleClick += new System.EventHandler(this.dgrVerifiche_DoubleClick);
			// 
			// grpVerificheLordi
			// 
			this.grpVerificheLordi.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.grpVerificheLordi.Controls.Add(this.dgrLordiPosticipati);
			this.grpVerificheLordi.Location = new System.Drawing.Point(9, 212);
			this.grpVerificheLordi.Name = "grpVerificheLordi";
			this.grpVerificheLordi.Size = new System.Drawing.Size(786, 195);
			this.grpVerificheLordi.TabIndex = 29;
			this.grpVerificheLordi.TabStop = false;
			this.grpVerificheLordi.Text = "Pagamenti e Incassi posticipati fase LORDI";
			// 
			// dgrLordiPosticipati
			// 
			this.dgrLordiPosticipati.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dgrLordiPosticipati.DataMember = "";
			this.dgrLordiPosticipati.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dgrLordiPosticipati.Location = new System.Drawing.Point(11, 22);
			this.dgrLordiPosticipati.Name = "dgrLordiPosticipati";
			this.dgrLordiPosticipati.Size = new System.Drawing.Size(768, 167);
			this.dgrLordiPosticipati.TabIndex = 4;
			// 
			// btnLordi
			// 
			this.btnLordi.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.btnLordi.Location = new System.Drawing.Point(182, 413);
			this.btnLordi.Name = "btnLordi";
			this.btnLordi.Size = new System.Drawing.Size(304, 41);
			this.btnLordi.TabIndex = 28;
			this.btnLordi.Text = "Elabora Pagamenti e Incassi  LORDI posticipati";
			this.btnLordi.UseVisualStyleBackColor = true;
			this.btnLordi.Click += new System.EventHandler(this.btnLordi_Click);
			// 
			// tabSelectVersamenti
			// 
			this.tabSelectVersamenti.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tabSelectVersamenti.BackColor = System.Drawing.SystemColors.Control;
			this.tabSelectVersamenti.Controls.Add(this.btnVerifica);
			this.tabSelectVersamenti.Controls.Add(this.btnDelSospesi);
			this.tabSelectVersamenti.Controls.Add(this.lblTask);
			this.tabSelectVersamenti.Controls.Add(this.groupBox1);
			this.tabSelectVersamenti.Controls.Add(this.groupBox2);
			this.tabSelectVersamenti.Controls.Add(this.btnInputSospesi);
			this.tabSelectVersamenti.Controls.Add(this.gBoxBollettaVersamenti);
			this.tabSelectVersamenti.Controls.Add(this.grpVerifiche);
			this.tabSelectVersamenti.Controls.Add(this.btnVersamenti);
			this.tabSelectVersamenti.Location = new System.Drawing.Point(0, 0);
			this.tabSelectVersamenti.Name = "tabSelectVersamenti";
			this.tabSelectVersamenti.Selected = false;
			this.tabSelectVersamenti.Size = new System.Drawing.Size(808, 517);
			this.tabSelectVersamenti.TabIndex = 4;
			this.tabSelectVersamenti.Title = "Pagina 2 di 3";
			// 
			// btnVerifica
			// 
			this.btnVerifica.Location = new System.Drawing.Point(23, 445);
			this.btnVerifica.Name = "btnVerifica";
			this.btnVerifica.Size = new System.Drawing.Size(167, 40);
			this.btnVerifica.TabIndex = 26;
			this.btnVerifica.Text = "Verifica Disponibile Mov. finanziari Residui";
			this.btnVerifica.Click += new System.EventHandler(this.btnVerifica_Click);
			// 
			// btnDelSospesi
			// 
			this.btnDelSospesi.Location = new System.Drawing.Point(370, 24);
			this.btnDelSospesi.Name = "btnDelSospesi";
			this.btnDelSospesi.Size = new System.Drawing.Size(242, 23);
			this.btnDelSospesi.TabIndex = 25;
			this.btnDelSospesi.Text = "Cancella Importazione Sospesi  ";
			this.btnDelSospesi.Click += new System.EventHandler(this.btnDelSospesi_Click);
			// 
			// lblTask
			// 
			this.lblTask.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lblTask.ForeColor = System.Drawing.SystemColors.HotTrack;
			this.lblTask.Location = new System.Drawing.Point(368, 50);
			this.lblTask.Name = "lblTask";
			this.lblTask.Size = new System.Drawing.Size(290, 21);
			this.lblTask.TabIndex = 24;
			this.lblTask.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox1.Controls.Add(this.dgrSospesi);
			this.groupBox1.Location = new System.Drawing.Point(385, 77);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(399, 161);
			this.groupBox1.TabIndex = 23;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Sospesi";
			// 
			// dgrSospesi
			// 
			this.dgrSospesi.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dgrSospesi.DataMember = "";
			this.dgrSospesi.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dgrSospesi.Location = new System.Drawing.Point(10, 20);
			this.dgrSospesi.Name = "dgrSospesi";
			this.dgrSospesi.Size = new System.Drawing.Size(381, 133);
			this.dgrSospesi.TabIndex = 4;
			// 
			// groupBox2
			// 
			this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox2.Controls.Add(this.dgrVerificheFin);
			this.groupBox2.Location = new System.Drawing.Point(12, 77);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(370, 161);
			this.groupBox2.TabIndex = 27;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Verifiche";
			// 
			// dgrVerificheFin
			// 
			this.dgrVerificheFin.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dgrVerificheFin.DataMember = "";
			this.dgrVerificheFin.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dgrVerificheFin.Location = new System.Drawing.Point(10, 19);
			this.dgrVerificheFin.Name = "dgrVerificheFin";
			this.dgrVerificheFin.Size = new System.Drawing.Size(352, 131);
			this.dgrVerificheFin.TabIndex = 4;
			this.dgrVerificheFin.DoubleClick += new System.EventHandler(this.dgrVerifiche_DoubleClick);
			// 
			// btnInputSospesi
			// 
			this.btnInputSospesi.Location = new System.Drawing.Point(620, 24);
			this.btnInputSospesi.Name = "btnInputSospesi";
			this.btnInputSospesi.Size = new System.Drawing.Size(167, 23);
			this.btnInputSospesi.TabIndex = 22;
			this.btnInputSospesi.Text = "Importa Dati da File Sospesi";
			this.btnInputSospesi.Click += new System.EventHandler(this.btnInputSospesi_Click);
			// 
			// gBoxBollettaVersamenti
			// 
			this.gBoxBollettaVersamenti.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.gBoxBollettaVersamenti.Controls.Add(this.label8);
			this.gBoxBollettaVersamenti.Controls.Add(this.label7);
			this.gBoxBollettaVersamenti.Controls.Add(this.txtNumBollettaVersamenti);
			this.gBoxBollettaVersamenti.Controls.Add(this.txtEsercBollettaVersamenti);
			this.gBoxBollettaVersamenti.Controls.Add(this.btnBollettaVersamenti);
			this.gBoxBollettaVersamenti.Location = new System.Drawing.Point(13, 9);
			this.gBoxBollettaVersamenti.Name = "gBoxBollettaVersamenti";
			this.gBoxBollettaVersamenti.Size = new System.Drawing.Size(353, 69);
			this.gBoxBollettaVersamenti.TabIndex = 21;
			this.gBoxBollettaVersamenti.TabStop = false;
			this.gBoxBollettaVersamenti.Tag = "AutoChoose.txtNumBollettaVersamenti.spesa.(active=\'S\')";
			this.gBoxBollettaVersamenti.Text = "ELABORAZIONE VERSAMENTI POSTICIPATI";
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(229, 19);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(54, 20);
			this.label8.TabIndex = 4;
			this.label8.Tag = "";
			this.label8.Text = "Numero:";
			this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(120, 19);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(57, 20);
			this.label7.TabIndex = 3;
			this.label7.Tag = "";
			this.label7.Text = "Esercizio:";
			this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtNumBollettaVersamenti
			// 
			this.txtNumBollettaVersamenti.Location = new System.Drawing.Point(216, 39);
			this.txtNumBollettaVersamenti.Name = "txtNumBollettaVersamenti";
			this.txtNumBollettaVersamenti.Size = new System.Drawing.Size(100, 23);
			this.txtNumBollettaVersamenti.TabIndex = 2;
			this.txtNumBollettaVersamenti.Tag = "bill_versamenti.nbill?billview.nbill";
			// 
			// txtEsercBollettaVersamenti
			// 
			this.txtEsercBollettaVersamenti.Location = new System.Drawing.Point(110, 39);
			this.txtEsercBollettaVersamenti.Name = "txtEsercBollettaVersamenti";
			this.txtEsercBollettaVersamenti.Size = new System.Drawing.Size(100, 23);
			this.txtEsercBollettaVersamenti.TabIndex = 1;
			this.txtEsercBollettaVersamenti.Tag = "bill_versamenti.ybill.year?billview.ybill.year";
			// 
			// btnBollettaVersamenti
			// 
			this.btnBollettaVersamenti.Location = new System.Drawing.Point(14, 39);
			this.btnBollettaVersamenti.Name = "btnBollettaVersamenti";
			this.btnBollettaVersamenti.Size = new System.Drawing.Size(88, 23);
			this.btnBollettaVersamenti.TabIndex = 0;
			this.btnBollettaVersamenti.TabStop = false;
			this.btnBollettaVersamenti.Tag = "";
			this.btnBollettaVersamenti.Text = "N. sospeso";
			this.btnBollettaVersamenti.Click += new System.EventHandler(this.btnBollettaVersamenti_Click);
			// 
			// grpVerifiche
			// 
			this.grpVerifiche.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.grpVerifiche.Controls.Add(this.dgrVersamentiAnnuali);
			this.grpVerifiche.Location = new System.Drawing.Point(9, 244);
			this.grpVerifiche.Name = "grpVerifiche";
			this.grpVerifiche.Size = new System.Drawing.Size(775, 195);
			this.grpVerifiche.TabIndex = 8;
			this.grpVerifiche.TabStop = false;
			this.grpVerifiche.Text = "Pagamenti e Incassi posticipati fase VERSAMENTI";
			// 
			// dgrVersamentiAnnuali
			// 
			this.dgrVersamentiAnnuali.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dgrVersamentiAnnuali.DataMember = "";
			this.dgrVersamentiAnnuali.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dgrVersamentiAnnuali.Location = new System.Drawing.Point(10, 22);
			this.dgrVersamentiAnnuali.Name = "dgrVersamentiAnnuali";
			this.dgrVersamentiAnnuali.Size = new System.Drawing.Size(757, 167);
			this.dgrVersamentiAnnuali.TabIndex = 4;
			// 
			// btnVersamenti
			// 
			this.btnVersamenti.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.btnVersamenti.Location = new System.Drawing.Point(196, 445);
			this.btnVersamenti.Name = "btnVersamenti";
			this.btnVersamenti.Size = new System.Drawing.Size(304, 40);
			this.btnVersamenti.TabIndex = 1;
			this.btnVersamenti.Text = "Elabora Pagamenti e Incassi posticipati";
			this.btnVersamenti.UseVisualStyleBackColor = true;
			this.btnVersamenti.Click += new System.EventHandler(this.btnVersamenti_Click);
			// 
			// tabRisultati
			// 
			this.tabRisultati.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tabRisultati.Controls.Add(this.labelRisultato);
			//this.tabRisultati.Controls.Add(this.progressBarImport);
			this.tabRisultati.Location = new System.Drawing.Point(0, 0);
			this.tabRisultati.Name = "tabRisultati";
			this.tabRisultati.Selected = false;
			this.tabRisultati.Size = new System.Drawing.Size(808, 517);
			this.tabRisultati.TabIndex = 5;
			this.tabRisultati.Title = "Pagina 3 di 3";
			// 
			// labelRisultato
			// 
			this.labelRisultato.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.labelRisultato.Location = new System.Drawing.Point(11, 14);
			this.labelRisultato.Name = "labelRisultato";
			this.labelRisultato.Size = new System.Drawing.Size(774, 48);
			this.labelRisultato.TabIndex = 12;
			// 
			// progressBarImport
			// 
			//this.progressBarImport.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
   //         | System.Windows.Forms.AnchorStyles.Right)));
			//this.progressBarImport.Location = new System.Drawing.Point(14, 321);
			//this.progressBarImport.Name = "progressBarImport";
			//this.progressBarImport.Size = new System.Drawing.Size(779, 22);
			//this.progressBarImport.TabIndex = 11;
			//this.progressBarImport.Visible = false;
			// 
			// panel1
			// 
			this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panel1.BackColor = System.Drawing.SystemColors.Control;
			this.panel1.Controls.Add(this.tabController);
			this.panel1.Location = new System.Drawing.Point(12, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(808, 542);
			this.panel1.TabIndex = 7;
			// 
			// DS
			// 
			this.DS.DataSetName = "vistaForm";
			this.DS.EnforceConstraints = false;
			// 
			// CMenu
			// 
			this.CMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.MenuEnterPwd});
			// 
			// MenuEnterPwd
			// 
			this.MenuEnterPwd.Index = 0;
			this.MenuEnterPwd.Text = "Visualizza tracciato";
			this.MenuEnterPwd.Click += new System.EventHandler(this.MenuEnterPwd_Click);
			// 
			// frmcsa_import_inail_maxphase
			// 
			this.ClientSize = new System.Drawing.Size(832, 587);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnNext);
			this.Controls.Add(this.btnBack);
			this.Controls.Add(this.panel1);
			this.Name = "frmcsa_import_inail_maxphase";
			this.Text = "frmcsa_import_inail_maxphase";
			((System.ComponentModel.ISupportInitialize)(this.dsFinancial)).EndInit();
			this.tabController.ResumeLayout(false);
			this.tabIntro.ResumeLayout(false);
			this.tabLordi.ResumeLayout(false);
			this.groupBox4.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgrVerificheLordi)).EndInit();
			this.grpVerificheLordi.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgrLordiPosticipati)).EndInit();
			this.tabSelectVersamenti.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgrSospesi)).EndInit();
			this.groupBox2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgrVerificheFin)).EndInit();
			this.gBoxBollettaVersamenti.ResumeLayout(false);
			this.gBoxBollettaVersamenti.PerformLayout();
			this.grpVerifiche.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgrVersamentiAnnuali)).EndInit();
			this.tabRisultati.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		public csa_import_inail_maxphase.dsmeta DS;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnNext;
		private System.Windows.Forms.Button btnBack;
		private Crownwood.Magic.Controls.TabControl tabController;
		private Crownwood.Magic.Controls.TabPage tabRisultati;
		private Crownwood.Magic.Controls.TabPage tabIntro;
		private Crownwood.Magic.Controls.TabPage tabSelectVersamenti;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label labelIntro;
		private System.Windows.Forms.Button btnVersamenti;
		private System.Windows.Forms.GroupBox grpVerifiche;
		private System.Windows.Forms.DataGrid dgrVersamentiAnnuali;
		//private System.Windows.Forms.ProgressBar progressBarImport;
		private System.Windows.Forms.Label labelRisultato;
		private System.Windows.Forms.GroupBox gBoxBollettaVersamenti;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox txtNumBollettaVersamenti;
		private System.Windows.Forms.TextBox txtEsercBollettaVersamenti;
		private System.Windows.Forms.Button btnBollettaVersamenti;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.DataGrid dgrSospesi;
		private System.Windows.Forms.Button btnInputSospesi;
		private System.Windows.Forms.Label lblTask;
		private System.Windows.Forms.OpenFileDialog _openInputFileDlg;
		private System.Windows.Forms.Button btnDelSospesi;
		private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ContextMenu CMenu;
        private System.Windows.Forms.MenuItem MenuEnterPwd;
		private System.Windows.Forms.Button btnVerifica;
		private System.Windows.Forms.DataGrid dgrVerificheFin;
		private System.Windows.Forms.GroupBox groupBox2;
		private Crownwood.Magic.Controls.TabPage tabLordi;
		private System.Windows.Forms.Button btnVerificaLordi;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.DataGrid dgrVerificheLordi;
		private System.Windows.Forms.GroupBox grpVerificheLordi;
		private System.Windows.Forms.DataGrid dgrLordiPosticipati;
		private System.Windows.Forms.Button btnLordi;
		private System.Windows.Forms.Label label2;
	}
}

