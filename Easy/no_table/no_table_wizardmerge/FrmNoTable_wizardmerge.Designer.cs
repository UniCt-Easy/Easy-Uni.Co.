
/*
Easy
Copyright (C) 2022 Università degli Studi di Catania (www.unict.it)
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


namespace no_table_wizardmerge {
    partial class FrmNoTable_wizardmerge {
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
			this.tabController = new Crownwood.Magic.Controls.TabControl();
			this.tabIntro = new Crownwood.Magic.Controls.TabPage();
			this.txtIntro = new System.Windows.Forms.TextBox();
			this.tabPage1 = new Crownwood.Magic.Controls.TabPage();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.label17 = new System.Windows.Forms.Label();
			this.label18 = new System.Windows.Forms.Label();
			this.txtDestUser = new System.Windows.Forms.TextBox();
			this.txtDestPwd = new System.Windows.Forms.TextBox();
			this.label16 = new System.Windows.Forms.Label();
			this.txtDipDestinazione = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.label1 = new System.Windows.Forms.Label();
			this.txtSourceDip = new System.Windows.Forms.TextBox();
			this.label32 = new System.Windows.Forms.Label();
			this.label31 = new System.Windows.Forms.Label();
			this.label30 = new System.Windows.Forms.Label();
			this.label29 = new System.Windows.Forms.Label();
			this.txtSourceServer = new System.Windows.Forms.TextBox();
			this.txtSourceDataBase = new System.Windows.Forms.TextBox();
			this.txtSourceUser = new System.Windows.Forms.TextBox();
			this.txtSourcePwd = new System.Windows.Forms.TextBox();
			this.tabCheckDBO = new Crownwood.Magic.Controls.TabPage();
			this.label19 = new System.Windows.Forms.Label();
			this.label20 = new System.Windows.Forms.Label();
			this.dgridC1 = new System.Windows.Forms.DataGrid();
			this.labDBPrinc = new System.Windows.Forms.Label();
			this.labDBSec = new System.Windows.Forms.Label();
			this.btnAssumi = new System.Windows.Forms.Button();
			this.btnProcedi = new System.Windows.Forms.Button();
			this.txt2 = new System.Windows.Forms.TextBox();
			this.labDBCorrente = new System.Windows.Forms.Label();
			this.labDBOrigine = new System.Windows.Forms.Label();
			this.dgridB1 = new System.Windows.Forms.DataGrid();
			this.dgridA1 = new System.Windows.Forms.DataGrid();
			this.label3 = new System.Windows.Forms.Label();
			this.tabCheckFin = new Crownwood.Magic.Controls.TabPage();
			this.cmbFinLevel = new System.Windows.Forms.ComboBox();
			this.btnCheckFin = new System.Windows.Forms.Button();
			this.label5 = new System.Windows.Forms.Label();
			this.labPrinc2 = new System.Windows.Forms.Label();
			this.labSec2 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.dgridB2 = new System.Windows.Forms.DataGrid();
			this.dgridA2 = new System.Windows.Forms.DataGrid();
			this.txt3 = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.tabCopyDBO = new Crownwood.Magic.Controls.TabPage();
			this.label13 = new System.Windows.Forms.Label();
			this.label12 = new System.Windows.Forms.Label();
			this.prgBarRegistry = new System.Windows.Forms.ProgressBar();
			this.label11 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.prgBarDBO = new System.Windows.Forms.ProgressBar();
			this.btnCopyDBO = new System.Windows.Forms.Button();
			this.label9 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.tabCopyNonDBO = new Crownwood.Magic.Controls.TabPage();
			this.labCurrTable = new System.Windows.Forms.Label();
			this.pBarCurrTab = new System.Windows.Forms.ProgressBar();
			this.label15 = new System.Windows.Forms.Label();
			this.pbarAllNonDBO = new System.Windows.Forms.ProgressBar();
			this.btnCopyNonDBO = new System.Windows.Forms.Button();
			this.label14 = new System.Windows.Forms.Label();
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnNext = new System.Windows.Forms.Button();
			this.btnBack = new System.Windows.Forms.Button();
			this.btnRefresh = new System.Windows.Forms.Button();
			this.DS = new no_table_wizardmerge.vistaForm();
			this.tabController.SuspendLayout();
			this.tabIntro.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.tabCheckDBO.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgridC1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dgridB1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dgridA1)).BeginInit();
			this.tabCheckFin.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgridB2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dgridA2)).BeginInit();
			this.tabCopyDBO.SuspendLayout();
			this.tabCopyNonDBO.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
			this.SuspendLayout();
			// 
			// tabController
			// 
			this.tabController.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tabController.IDEPixelArea = true;
			this.tabController.Location = new System.Drawing.Point(12, 12);
			this.tabController.Name = "tabController";
			this.tabController.SelectedIndex = 0;
			this.tabController.SelectedTab = this.tabIntro;
			this.tabController.Size = new System.Drawing.Size(908, 656);
			this.tabController.TabIndex = 0;
			this.tabController.TabPages.AddRange(new Crownwood.Magic.Controls.TabPage[] {
            this.tabIntro,
            this.tabPage1,
            this.tabCheckDBO,
            this.tabCheckFin,
            this.tabCopyDBO,
            this.tabCopyNonDBO});
			// 
			// tabIntro
			// 
			this.tabIntro.Controls.Add(this.txtIntro);
			this.tabIntro.Location = new System.Drawing.Point(0, 0);
			this.tabIntro.Name = "tabIntro";
			this.tabIntro.Size = new System.Drawing.Size(908, 631);
			this.tabIntro.TabIndex = 4;
			this.tabIntro.Title = "Introduzione";
			// 
			// txtIntro
			// 
			this.txtIntro.AcceptsReturn = true;
			this.txtIntro.AcceptsTab = true;
			this.txtIntro.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtIntro.Location = new System.Drawing.Point(12, 13);
			this.txtIntro.Multiline = true;
			this.txtIntro.Name = "txtIntro";
			this.txtIntro.ReadOnly = true;
			this.txtIntro.Size = new System.Drawing.Size(878, 602);
			this.txtIntro.TabIndex = 3;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.groupBox2);
			this.tabPage1.Controls.Add(this.label2);
			this.tabPage1.Controls.Add(this.groupBox1);
			this.tabPage1.Location = new System.Drawing.Point(0, 0);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Selected = false;
			this.tabPage1.Size = new System.Drawing.Size(908, 631);
			this.tabPage1.TabIndex = 5;
			this.tabPage1.Title = "Passo 1";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.label17);
			this.groupBox2.Controls.Add(this.label18);
			this.groupBox2.Controls.Add(this.txtDestUser);
			this.groupBox2.Controls.Add(this.txtDestPwd);
			this.groupBox2.Controls.Add(this.label16);
			this.groupBox2.Controls.Add(this.txtDipDestinazione);
			this.groupBox2.Location = new System.Drawing.Point(19, 222);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(408, 124);
			this.groupBox2.TabIndex = 23;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Dipartimento sul data base principale in cui importare i dati";
			// 
			// label17
			// 
			this.label17.Location = new System.Drawing.Point(6, 27);
			this.label17.Name = "label17";
			this.label17.Size = new System.Drawing.Size(176, 23);
			this.label17.TabIndex = 24;
			this.label17.Text = "Nome utente per connettersi";
			this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label18
			// 
			this.label18.Location = new System.Drawing.Point(76, 51);
			this.label18.Name = "label18";
			this.label18.Size = new System.Drawing.Size(100, 23);
			this.label18.TabIndex = 25;
			this.label18.Text = "Password";
			this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtDestUser
			// 
			this.txtDestUser.Location = new System.Drawing.Point(182, 27);
			this.txtDestUser.Name = "txtDestUser";
			this.txtDestUser.Size = new System.Drawing.Size(200, 23);
			this.txtDestUser.TabIndex = 1;
			// 
			// txtDestPwd
			// 
			this.txtDestPwd.Location = new System.Drawing.Point(182, 51);
			this.txtDestPwd.Name = "txtDestPwd";
			this.txtDestPwd.PasswordChar = '*';
			this.txtDestPwd.Size = new System.Drawing.Size(200, 23);
			this.txtDestPwd.TabIndex = 2;
			// 
			// label16
			// 
			this.label16.Location = new System.Drawing.Point(12, 79);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(168, 23);
			this.label16.TabIndex = 22;
			this.label16.Text = " Dipartimento";
			this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtDipDestinazione
			// 
			this.txtDipDestinazione.Location = new System.Drawing.Point(184, 81);
			this.txtDipDestinazione.Name = "txtDipDestinazione";
			this.txtDipDestinazione.Size = new System.Drawing.Size(200, 23);
			this.txtDipDestinazione.TabIndex = 3;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(16, 11);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(188, 15);
			this.label2.TabIndex = 22;
			this.label2.Text = "Selezione del Database Secondario";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.txtSourceDip);
			this.groupBox1.Controls.Add(this.label32);
			this.groupBox1.Controls.Add(this.label31);
			this.groupBox1.Controls.Add(this.label30);
			this.groupBox1.Controls.Add(this.label29);
			this.groupBox1.Controls.Add(this.txtSourceServer);
			this.groupBox1.Controls.Add(this.txtSourceDataBase);
			this.groupBox1.Controls.Add(this.txtSourceUser);
			this.groupBox1.Controls.Add(this.txtSourcePwd);
			this.groupBox1.Location = new System.Drawing.Point(19, 46);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(408, 150);
			this.groupBox1.TabIndex = 21;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Database esistente da cui importare i dati";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(12, 109);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(168, 23);
			this.label1.TabIndex = 20;
			this.label1.Text = "Dipartimento";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtSourceDip
			// 
			this.txtSourceDip.Location = new System.Drawing.Point(184, 111);
			this.txtSourceDip.Name = "txtSourceDip";
			this.txtSourceDip.Size = new System.Drawing.Size(200, 23);
			this.txtSourceDip.TabIndex = 21;
			// 
			// label32
			// 
			this.label32.Location = new System.Drawing.Point(80, 16);
			this.label32.Name = "label32";
			this.label32.Size = new System.Drawing.Size(100, 23);
			this.label32.TabIndex = 11;
			this.label32.Text = "Nome server";
			this.label32.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label31
			// 
			this.label31.Location = new System.Drawing.Point(16, 40);
			this.label31.Name = "label31";
			this.label31.Size = new System.Drawing.Size(168, 23);
			this.label31.TabIndex = 12;
			this.label31.Text = "Nome del database";
			this.label31.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label30
			// 
			this.label30.Location = new System.Drawing.Point(8, 64);
			this.label30.Name = "label30";
			this.label30.Size = new System.Drawing.Size(176, 23);
			this.label30.TabIndex = 13;
			this.label30.Text = "Nome utente per connettersi";
			this.label30.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label29
			// 
			this.label29.Location = new System.Drawing.Point(78, 88);
			this.label29.Name = "label29";
			this.label29.Size = new System.Drawing.Size(100, 23);
			this.label29.TabIndex = 14;
			this.label29.Text = "Password";
			this.label29.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtSourceServer
			// 
			this.txtSourceServer.Location = new System.Drawing.Point(184, 16);
			this.txtSourceServer.Name = "txtSourceServer";
			this.txtSourceServer.Size = new System.Drawing.Size(200, 23);
			this.txtSourceServer.TabIndex = 16;
			// 
			// txtSourceDataBase
			// 
			this.txtSourceDataBase.Location = new System.Drawing.Point(184, 40);
			this.txtSourceDataBase.Name = "txtSourceDataBase";
			this.txtSourceDataBase.Size = new System.Drawing.Size(200, 23);
			this.txtSourceDataBase.TabIndex = 17;
			// 
			// txtSourceUser
			// 
			this.txtSourceUser.Location = new System.Drawing.Point(184, 64);
			this.txtSourceUser.Name = "txtSourceUser";
			this.txtSourceUser.Size = new System.Drawing.Size(200, 23);
			this.txtSourceUser.TabIndex = 18;
			// 
			// txtSourcePwd
			// 
			this.txtSourcePwd.Location = new System.Drawing.Point(184, 88);
			this.txtSourcePwd.Name = "txtSourcePwd";
			this.txtSourcePwd.PasswordChar = '*';
			this.txtSourcePwd.Size = new System.Drawing.Size(200, 23);
			this.txtSourcePwd.TabIndex = 19;
			// 
			// tabCheckDBO
			// 
			this.tabCheckDBO.Controls.Add(this.label19);
			this.tabCheckDBO.Controls.Add(this.label20);
			this.tabCheckDBO.Controls.Add(this.dgridC1);
			this.tabCheckDBO.Controls.Add(this.labDBPrinc);
			this.tabCheckDBO.Controls.Add(this.labDBSec);
			this.tabCheckDBO.Controls.Add(this.btnAssumi);
			this.tabCheckDBO.Controls.Add(this.btnProcedi);
			this.tabCheckDBO.Controls.Add(this.txt2);
			this.tabCheckDBO.Controls.Add(this.labDBCorrente);
			this.tabCheckDBO.Controls.Add(this.labDBOrigine);
			this.tabCheckDBO.Controls.Add(this.dgridB1);
			this.tabCheckDBO.Controls.Add(this.dgridA1);
			this.tabCheckDBO.Controls.Add(this.label3);
			this.tabCheckDBO.Location = new System.Drawing.Point(0, 0);
			this.tabCheckDBO.Name = "tabCheckDBO";
			this.tabCheckDBO.Selected = false;
			this.tabCheckDBO.Size = new System.Drawing.Size(908, 631);
			this.tabCheckDBO.TabIndex = 6;
			this.tabCheckDBO.Title = "Passo 2";
			// 
			// label19
			// 
			this.label19.AutoSize = true;
			this.label19.Location = new System.Drawing.Point(468, 264);
			this.label19.Name = "label19";
			this.label19.Size = new System.Drawing.Size(83, 15);
			this.label19.TabIndex = 45;
			this.label19.Text = "DB secondario";
			// 
			// label20
			// 
			this.label20.AutoSize = true;
			this.label20.Location = new System.Drawing.Point(12, 264);
			this.label20.Name = "label20";
			this.label20.Size = new System.Drawing.Size(315, 15);
			this.label20.TabIndex = 44;
			this.label20.Text = "Righe presenti solo sul database da importare (secondario)";
			// 
			// dgridC1
			// 
			this.dgridC1.AllowNavigation = false;
			this.dgridC1.AllowSorting = false;
			this.dgridC1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dgridC1.DataMember = "";
			this.dgridC1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dgridC1.Location = new System.Drawing.Point(10, 280);
			this.dgridC1.Name = "dgridC1";
			this.dgridC1.ParentRowsVisible = false;
			this.dgridC1.ReadOnly = true;
			this.dgridC1.Size = new System.Drawing.Size(887, 147);
			this.dgridC1.TabIndex = 43;
			this.dgridC1.Tag = "";
			// 
			// labDBPrinc
			// 
			this.labDBPrinc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.labDBPrinc.AutoSize = true;
			this.labDBPrinc.Location = new System.Drawing.Point(468, 430);
			this.labDBPrinc.Name = "labDBPrinc";
			this.labDBPrinc.Size = new System.Drawing.Size(77, 15);
			this.labDBPrinc.TabIndex = 42;
			this.labDBPrinc.Text = "DB principale";
			// 
			// labDBSec
			// 
			this.labDBSec.AutoSize = true;
			this.labDBSec.Location = new System.Drawing.Point(468, 97);
			this.labDBSec.Name = "labDBSec";
			this.labDBSec.Size = new System.Drawing.Size(83, 15);
			this.labDBSec.TabIndex = 41;
			this.labDBSec.Text = "DB secondario";
			// 
			// btnAssumi
			// 
			this.btnAssumi.Location = new System.Drawing.Point(650, 55);
			this.btnAssumi.Name = "btnAssumi";
			this.btnAssumi.Size = new System.Drawing.Size(163, 39);
			this.btnAssumi.TabIndex = 40;
			this.btnAssumi.Text = "Assumi come buoni quelli del db secondario";
			this.btnAssumi.UseVisualStyleBackColor = true;
			this.btnAssumi.Click += new System.EventHandler(this.btnAssumi_Click);
			// 
			// btnProcedi
			// 
			this.btnProcedi.Location = new System.Drawing.Point(650, 10);
			this.btnProcedi.Name = "btnProcedi";
			this.btnProcedi.Size = new System.Drawing.Size(163, 39);
			this.btnProcedi.TabIndex = 39;
			this.btnProcedi.Text = "Procedi (prendi per buoni quelli del db principale)";
			this.btnProcedi.UseVisualStyleBackColor = true;
			this.btnProcedi.Click += new System.EventHandler(this.btnProcedi_Click);
			// 
			// txt2
			// 
			this.txt2.Location = new System.Drawing.Point(10, 26);
			this.txt2.Multiline = true;
			this.txt2.Name = "txt2";
			this.txt2.ReadOnly = true;
			this.txt2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txt2.Size = new System.Drawing.Size(632, 68);
			this.txt2.TabIndex = 38;
			// 
			// labDBCorrente
			// 
			this.labDBCorrente.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.labDBCorrente.AutoSize = true;
			this.labDBCorrente.Location = new System.Drawing.Point(12, 430);
			this.labDBCorrente.Name = "labDBCorrente";
			this.labDBCorrente.Size = new System.Drawing.Size(165, 15);
			this.labDBCorrente.TabIndex = 37;
			this.labDBCorrente.Text = "Database corrente (principale)";
			// 
			// labDBOrigine
			// 
			this.labDBOrigine.AutoSize = true;
			this.labDBOrigine.Location = new System.Drawing.Point(12, 97);
			this.labDBOrigine.Name = "labDBOrigine";
			this.labDBOrigine.Size = new System.Drawing.Size(312, 15);
			this.labDBOrigine.TabIndex = 36;
			this.labDBOrigine.Text = "Possibibili conflitti sul database da importare (secondario)";
			// 
			// dgridB1
			// 
			this.dgridB1.AllowNavigation = false;
			this.dgridB1.AllowSorting = false;
			this.dgridB1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dgridB1.DataMember = "";
			this.dgridB1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dgridB1.Location = new System.Drawing.Point(10, 446);
			this.dgridB1.Name = "dgridB1";
			this.dgridB1.ParentRowsVisible = false;
			this.dgridB1.ReadOnly = true;
			this.dgridB1.Size = new System.Drawing.Size(887, 172);
			this.dgridB1.TabIndex = 35;
			this.dgridB1.Tag = "";
			// 
			// dgridA1
			// 
			this.dgridA1.AllowNavigation = false;
			this.dgridA1.AllowSorting = false;
			this.dgridA1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dgridA1.DataMember = "";
			this.dgridA1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dgridA1.Location = new System.Drawing.Point(10, 113);
			this.dgridA1.Name = "dgridA1";
			this.dgridA1.ParentRowsVisible = false;
			this.dgridA1.ReadOnly = true;
			this.dgridA1.Size = new System.Drawing.Size(887, 147);
			this.dgridA1.TabIndex = 34;
			this.dgridA1.Tag = "";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(12, 10);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(239, 15);
			this.label3.TabIndex = 0;
			this.label3.Text = "Verifica dei dati presenti del db da importare";
			// 
			// tabCheckFin
			// 
			this.tabCheckFin.Controls.Add(this.cmbFinLevel);
			this.tabCheckFin.Controls.Add(this.btnCheckFin);
			this.tabCheckFin.Controls.Add(this.label5);
			this.tabCheckFin.Controls.Add(this.labPrinc2);
			this.tabCheckFin.Controls.Add(this.labSec2);
			this.tabCheckFin.Controls.Add(this.label7);
			this.tabCheckFin.Controls.Add(this.label8);
			this.tabCheckFin.Controls.Add(this.dgridB2);
			this.tabCheckFin.Controls.Add(this.dgridA2);
			this.tabCheckFin.Controls.Add(this.txt3);
			this.tabCheckFin.Controls.Add(this.label4);
			this.tabCheckFin.Location = new System.Drawing.Point(0, 0);
			this.tabCheckFin.Name = "tabCheckFin";
			this.tabCheckFin.Selected = false;
			this.tabCheckFin.Size = new System.Drawing.Size(908, 631);
			this.tabCheckFin.TabIndex = 7;
			this.tabCheckFin.Title = "Passo 3";
			// 
			// cmbFinLevel
			// 
			this.cmbFinLevel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.cmbFinLevel.FormattingEnabled = true;
			this.cmbFinLevel.Location = new System.Drawing.Point(719, 38);
			this.cmbFinLevel.Name = "cmbFinLevel";
			this.cmbFinLevel.Size = new System.Drawing.Size(176, 23);
			this.cmbFinLevel.TabIndex = 51;
			// 
			// btnCheckFin
			// 
			this.btnCheckFin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCheckFin.Location = new System.Drawing.Point(719, 64);
			this.btnCheckFin.Name = "btnCheckFin";
			this.btnCheckFin.Size = new System.Drawing.Size(134, 23);
			this.btnCheckFin.TabIndex = 50;
			this.btnCheckFin.Text = "Effettua la verifica";
			this.btnCheckFin.UseVisualStyleBackColor = true;
			this.btnCheckFin.Click += new System.EventHandler(this.btnCheckFin_Click);
			// 
			// label5
			// 
			this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(716, 22);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(161, 15);
			this.label5.TabIndex = 49;
			this.label5.Text = "Livello sino al quale verificare";
			// 
			// labPrinc2
			// 
			this.labPrinc2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.labPrinc2.AutoSize = true;
			this.labPrinc2.Location = new System.Drawing.Point(320, 431);
			this.labPrinc2.Name = "labPrinc2";
			this.labPrinc2.Size = new System.Drawing.Size(77, 15);
			this.labPrinc2.TabIndex = 48;
			this.labPrinc2.Text = "DB principale";
			// 
			// labSec2
			// 
			this.labSec2.AutoSize = true;
			this.labSec2.Location = new System.Drawing.Point(320, 98);
			this.labSec2.Name = "labSec2";
			this.labSec2.Size = new System.Drawing.Size(83, 15);
			this.labSec2.TabIndex = 47;
			this.labSec2.Text = "DB secondario";
			// 
			// label7
			// 
			this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(10, 431);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(165, 15);
			this.label7.TabIndex = 46;
			this.label7.Text = "Database corrente (principale)";
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(10, 98);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(195, 15);
			this.label8.TabIndex = 45;
			this.label8.Text = "Database da importare (secondario)";
			// 
			// dgridB2
			// 
			this.dgridB2.AllowNavigation = false;
			this.dgridB2.AllowSorting = false;
			this.dgridB2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dgridB2.DataMember = "";
			this.dgridB2.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dgridB2.Location = new System.Drawing.Point(8, 447);
			this.dgridB2.Name = "dgridB2";
			this.dgridB2.ParentRowsVisible = false;
			this.dgridB2.ReadOnly = true;
			this.dgridB2.Size = new System.Drawing.Size(887, 172);
			this.dgridB2.TabIndex = 44;
			this.dgridB2.Tag = "";
			// 
			// dgridA2
			// 
			this.dgridA2.AllowNavigation = false;
			this.dgridA2.AllowSorting = false;
			this.dgridA2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dgridA2.DataMember = "";
			this.dgridA2.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dgridA2.Location = new System.Drawing.Point(8, 114);
			this.dgridA2.Name = "dgridA2";
			this.dgridA2.ParentRowsVisible = false;
			this.dgridA2.ReadOnly = true;
			this.dgridA2.Size = new System.Drawing.Size(887, 159);
			this.dgridA2.TabIndex = 43;
			this.dgridA2.Tag = "";
			// 
			// txt3
			// 
			this.txt3.Location = new System.Drawing.Point(3, 19);
			this.txt3.Multiline = true;
			this.txt3.Name = "txt3";
			this.txt3.ReadOnly = true;
			this.txt3.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txt3.Size = new System.Drawing.Size(632, 68);
			this.txt3.TabIndex = 40;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(5, 3);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(185, 15);
			this.label4.TabIndex = 39;
			this.label4.Text = "Verifica della struttura del bilancio";
			// 
			// tabCopyDBO
			// 
			this.tabCopyDBO.Controls.Add(this.label13);
			this.tabCopyDBO.Controls.Add(this.label12);
			this.tabCopyDBO.Controls.Add(this.prgBarRegistry);
			this.tabCopyDBO.Controls.Add(this.label11);
			this.tabCopyDBO.Controls.Add(this.label10);
			this.tabCopyDBO.Controls.Add(this.prgBarDBO);
			this.tabCopyDBO.Controls.Add(this.btnCopyDBO);
			this.tabCopyDBO.Controls.Add(this.label9);
			this.tabCopyDBO.Controls.Add(this.label6);
			this.tabCopyDBO.Location = new System.Drawing.Point(0, 0);
			this.tabCopyDBO.Name = "tabCopyDBO";
			this.tabCopyDBO.Selected = false;
			this.tabCopyDBO.Size = new System.Drawing.Size(908, 631);
			this.tabCopyDBO.TabIndex = 8;
			this.tabCopyDBO.Title = "Passo 4";
			// 
			// label13
			// 
			this.label13.AutoSize = true;
			this.label13.Location = new System.Drawing.Point(16, 340);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(514, 15);
			this.label13.TabIndex = 8;
			this.label13.Text = "Una volta eseguita l\'importazione è importante non aggiungere più dati nel databa" +
    "se secondario";
			// 
			// label12
			// 
			this.label12.AutoSize = true;
			this.label12.Location = new System.Drawing.Point(16, 262);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(309, 15);
			this.label12.TabIndex = 7;
			this.label12.Text = "Stato di avanzamento dell\'importazione delle anagrafiche";
			// 
			// prgBarRegistry
			// 
			this.prgBarRegistry.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.prgBarRegistry.Location = new System.Drawing.Point(19, 278);
			this.prgBarRegistry.Name = "prgBarRegistry";
			this.prgBarRegistry.Size = new System.Drawing.Size(869, 26);
			this.prgBarRegistry.TabIndex = 6;
			// 
			// label11
			// 
			this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.label11.Location = new System.Drawing.Point(12, 59);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(872, 49);
			this.label11.TabIndex = 5;
			this.label11.Text = "Tutti i dati nelle tabelle comuni \"tipologiche\" presenti nel db secondario e non " +
    "in quello principale saranno aggiunti al principale come \"non attivi\" ove esiste" +
    " il concetto di attivo/non attivo.";
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(16, 202);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(317, 15);
			this.label10.TabIndex = 4;
			this.label10.Text = "Stato di avanzamento dell\'importazione tabelle tipologiche";
			// 
			// prgBarDBO
			// 
			this.prgBarDBO.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.prgBarDBO.Location = new System.Drawing.Point(19, 218);
			this.prgBarDBO.Name = "prgBarDBO";
			this.prgBarDBO.Size = new System.Drawing.Size(869, 26);
			this.prgBarDBO.TabIndex = 3;
			// 
			// btnCopyDBO
			// 
			this.btnCopyDBO.Location = new System.Drawing.Point(284, 143);
			this.btnCopyDBO.Name = "btnCopyDBO";
			this.btnCopyDBO.Size = new System.Drawing.Size(219, 23);
			this.btnCopyDBO.TabIndex = 2;
			this.btnCopyDBO.Text = "Inizia l\'importazione ";
			this.btnCopyDBO.UseVisualStyleBackColor = true;
			this.btnCopyDBO.Click += new System.EventHandler(this.btnCopyDBO_Click);
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(12, 37);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(643, 15);
			this.label9.TabIndex = 1;
			this.label9.Text = "Le anagrafiche saranno tutte trasferite, ma sarà poi possibile, in un secondo mom" +
    "ento, raffinarle con apposite procedure.";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(12, 14);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(342, 15);
			this.label6.TabIndex = 0;
			this.label6.Text = "Si può adesso procedere alla importazione delle tabelle comuni.";
			// 
			// tabCopyNonDBO
			// 
			this.tabCopyNonDBO.Controls.Add(this.labCurrTable);
			this.tabCopyNonDBO.Controls.Add(this.pBarCurrTab);
			this.tabCopyNonDBO.Controls.Add(this.label15);
			this.tabCopyNonDBO.Controls.Add(this.pbarAllNonDBO);
			this.tabCopyNonDBO.Controls.Add(this.btnCopyNonDBO);
			this.tabCopyNonDBO.Controls.Add(this.label14);
			this.tabCopyNonDBO.Location = new System.Drawing.Point(0, 0);
			this.tabCopyNonDBO.Name = "tabCopyNonDBO";
			this.tabCopyNonDBO.Selected = false;
			this.tabCopyNonDBO.Size = new System.Drawing.Size(908, 631);
			this.tabCopyNonDBO.TabIndex = 9;
			this.tabCopyNonDBO.Title = "Passo 5";
			// 
			// labCurrTable
			// 
			this.labCurrTable.AutoSize = true;
			this.labCurrTable.Location = new System.Drawing.Point(15, 168);
			this.labCurrTable.Name = "labCurrTable";
			this.labCurrTable.Size = new System.Drawing.Size(234, 15);
			this.labCurrTable.TabIndex = 8;
			this.labCurrTable.Text = "Stato di avanzamento della tabella corrente";
			// 
			// pBarCurrTab
			// 
			this.pBarCurrTab.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.pBarCurrTab.Location = new System.Drawing.Point(18, 184);
			this.pBarCurrTab.Name = "pBarCurrTab";
			this.pBarCurrTab.Size = new System.Drawing.Size(869, 26);
			this.pBarCurrTab.TabIndex = 7;
			// 
			// label15
			// 
			this.label15.AutoSize = true;
			this.label15.Location = new System.Drawing.Point(15, 104);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(254, 15);
			this.label15.TabIndex = 6;
			this.label15.Text = "Stato di avanzamento dell\'importazione tabelle";
			// 
			// pbarAllNonDBO
			// 
			this.pbarAllNonDBO.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.pbarAllNonDBO.Location = new System.Drawing.Point(18, 120);
			this.pbarAllNonDBO.Name = "pbarAllNonDBO";
			this.pbarAllNonDBO.Size = new System.Drawing.Size(869, 26);
			this.pbarAllNonDBO.TabIndex = 5;
			// 
			// btnCopyNonDBO
			// 
			this.btnCopyNonDBO.Location = new System.Drawing.Point(295, 52);
			this.btnCopyNonDBO.Name = "btnCopyNonDBO";
			this.btnCopyNonDBO.Size = new System.Drawing.Size(219, 23);
			this.btnCopyNonDBO.TabIndex = 3;
			this.btnCopyNonDBO.Text = "Inizia l\'importazione ";
			this.btnCopyNonDBO.UseVisualStyleBackColor = true;
			this.btnCopyNonDBO.Click += new System.EventHandler(this.btnCopyNonDBO_Click);
			// 
			// label14
			// 
			this.label14.AutoSize = true;
			this.label14.Location = new System.Drawing.Point(15, 16);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(377, 15);
			this.label14.TabIndex = 1;
			this.label14.Text = "Si può adesso procedere alla importazione di tutte le tabelle rimanenti.";
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(851, 674);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 23);
			this.btnCancel.TabIndex = 22;
			this.btnCancel.Tag = "maincancel";
			this.btnCancel.Text = "Cancel";
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// btnNext
			// 
			this.btnNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnNext.Location = new System.Drawing.Point(731, 674);
			this.btnNext.Name = "btnNext";
			this.btnNext.Size = new System.Drawing.Size(88, 23);
			this.btnNext.TabIndex = 21;
			this.btnNext.Text = "Avanti >";
			this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
			// 
			// btnBack
			// 
			this.btnBack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnBack.Location = new System.Drawing.Point(643, 674);
			this.btnBack.Name = "btnBack";
			this.btnBack.Size = new System.Drawing.Size(80, 23);
			this.btnBack.TabIndex = 20;
			this.btnBack.Text = "< Indietro";
			this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
			// 
			// btnRefresh
			// 
			this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnRefresh.Location = new System.Drawing.Point(430, 674);
			this.btnRefresh.Name = "btnRefresh";
			this.btnRefresh.Size = new System.Drawing.Size(125, 23);
			this.btnRefresh.TabIndex = 23;
			this.btnRefresh.Text = "Aggiorna i dati";
			this.btnRefresh.UseVisualStyleBackColor = true;
			this.btnRefresh.Visible = false;
			this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
			// 
			// DS
			// 
			this.DS.DataSetName = "vistaForm";
			// 
			// FrmNoTable_wizardmerge
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
			this.ClientSize = new System.Drawing.Size(932, 709);
			this.Controls.Add(this.btnRefresh);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnNext);
			this.Controls.Add(this.btnBack);
			this.Controls.Add(this.tabController);
			this.Name = "FrmNoTable_wizardmerge";
			this.Text = "FrmNoTable_wizardmerge";
			this.tabController.ResumeLayout(false);
			this.tabIntro.ResumeLayout(false);
			this.tabIntro.PerformLayout();
			this.tabPage1.ResumeLayout(false);
			this.tabPage1.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.tabCheckDBO.ResumeLayout(false);
			this.tabCheckDBO.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgridC1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dgridB1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dgridA1)).EndInit();
			this.tabCheckFin.ResumeLayout(false);
			this.tabCheckFin.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgridB2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dgridA2)).EndInit();
			this.tabCopyDBO.ResumeLayout(false);
			this.tabCopyDBO.PerformLayout();
			this.tabCopyNonDBO.ResumeLayout(false);
			this.tabCopyNonDBO.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
			this.ResumeLayout(false);

        }

        #endregion

        private Crownwood.Magic.Controls.TabControl tabController;
        private System.Windows.Forms.TextBox txtIntro;
        private Crownwood.Magic.Controls.TabPage tabIntro;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnRefresh;
        private Crownwood.Magic.Controls.TabPage tabPage1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.TextBox txtSourceServer;
        private System.Windows.Forms.TextBox txtSourceDataBase;
        private System.Windows.Forms.TextBox txtSourceUser;
        private System.Windows.Forms.TextBox txtSourcePwd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSourceDip;
        private Crownwood.Magic.Controls.TabPage tabCheckDBO;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labDBOrigine;
        private System.Windows.Forms.DataGrid dgridB1;
        private System.Windows.Forms.DataGrid dgridA1;
        private System.Windows.Forms.Label labDBCorrente;
        private System.Windows.Forms.TextBox txt2;
        private System.Windows.Forms.Button btnProcedi;
        public vistaForm DS;
        private System.Windows.Forms.Button btnAssumi;
        private System.Windows.Forms.Label labDBPrinc;
        private System.Windows.Forms.Label labDBSec;
        private Crownwood.Magic.Controls.TabPage tabCheckFin;
        private System.Windows.Forms.TextBox txt3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labPrinc2;
        private System.Windows.Forms.Label labSec2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGrid dgridB2;
        private System.Windows.Forms.DataGrid dgridA2;
        private System.Windows.Forms.ComboBox cmbFinLevel;
        private System.Windows.Forms.Button btnCheckFin;
        private System.Windows.Forms.Label label5;
        private Crownwood.Magic.Controls.TabPage tabCopyDBO;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnCopyDBO;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ProgressBar prgBarDBO;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ProgressBar prgBarRegistry;
        private System.Windows.Forms.Label label13;
        private Crownwood.Magic.Controls.TabPage tabCopyNonDBO;
        private System.Windows.Forms.Label labCurrTable;
        private System.Windows.Forms.ProgressBar pBarCurrTab;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ProgressBar pbarAllNonDBO;
        private System.Windows.Forms.Button btnCopyNonDBO;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtDipDestinazione;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox txtDestUser;
        private System.Windows.Forms.TextBox txtDestPwd;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.DataGrid dgridC1;
    }
}
