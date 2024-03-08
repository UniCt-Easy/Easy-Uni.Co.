
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


namespace pccsid_wizard_calcolo {
    partial class Frm_pccsid_wizard_calcolo {
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
			this.btnNext = new System.Windows.Forms.Button();
			this.btnBack = new System.Windows.Forms.Button();
			this._folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
			this.btnAnnulla = new System.Windows.Forms.Button();
			this.tabController = new Crownwood.Magic.Controls.TabControl();
			this.tabPage1 = new Crownwood.Magic.Controls.TabPage();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.grpPagamenti = new System.Windows.Forms.GroupBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.txtEsercizio = new System.Windows.Forms.TextBox();
			this.chkIP = new System.Windows.Forms.CheckBox();
			this.grpGestioneimporti = new System.Windows.Forms.GroupBox();
			this.chkMI = new System.Windows.Forms.CheckBox();
			this.chkScadenza = new System.Windows.Forms.CheckBox();
			this.chkSID = new System.Windows.Forms.CheckBox();
			this.grpInvio = new System.Windows.Forms.GroupBox();
			this.chkInvio = new System.Windows.Forms.CheckBox();
			this.label1 = new System.Windows.Forms.Label();
			this.grpAnagrafica = new System.Windows.Forms.GroupBox();
			this.txtAnagrafica = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.txtPercorso = new System.Windows.Forms.TextBox();
			this.btnCartella = new System.Windows.Forms.Button();
			this.label63 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.txtAl = new System.Windows.Forms.TextBox();
			this.txtDal = new System.Windows.Forms.TextBox();
			this.tabPage2 = new Crownwood.Magic.Controls.TabPage();
			this.btnSelezionaTutto = new System.Windows.Forms.Button();
			this.label8 = new System.Windows.Forms.Label();
			this.gridDettagli = new System.Windows.Forms.DataGrid();
			this.tabPage3 = new Crownwood.Magic.Controls.TabPage();
			this.lblFinale = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.DS = new pccsid_wizard_calcolo.vistaForm();
			this.tabController.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.grpPagamenti.SuspendLayout();
			this.grpGestioneimporti.SuspendLayout();
			this.grpInvio.SuspendLayout();
			this.grpAnagrafica.SuspendLayout();
			this.tabPage2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.gridDettagli)).BeginInit();
			this.tabPage3.SuspendLayout();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
			this.SuspendLayout();
			// 
			// btnNext
			// 
			this.btnNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnNext.Location = new System.Drawing.Point(862, 745);
			this.btnNext.Name = "btnNext";
			this.btnNext.Size = new System.Drawing.Size(72, 23);
			this.btnNext.TabIndex = 21;
			this.btnNext.Text = "Avanti >";
			this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
			// 
			// btnBack
			// 
			this.btnBack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnBack.Location = new System.Drawing.Point(782, 745);
			this.btnBack.Name = "btnBack";
			this.btnBack.Size = new System.Drawing.Size(72, 23);
			this.btnBack.TabIndex = 20;
			this.btnBack.Text = "< Indietro";
			this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
			// 
			// btnAnnulla
			// 
			this.btnAnnulla.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnAnnulla.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnAnnulla.Location = new System.Drawing.Point(972, 745);
			this.btnAnnulla.Name = "btnAnnulla";
			this.btnAnnulla.Size = new System.Drawing.Size(72, 23);
			this.btnAnnulla.TabIndex = 26;
			this.btnAnnulla.Tag = "maincancel";
			this.btnAnnulla.Text = "Chiudi";
			this.btnAnnulla.Click += new System.EventHandler(this.btnAnnulla_Click);
			// 
			// tabController
			// 
			this.tabController.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabController.IDEPixelArea = true;
			this.tabController.Location = new System.Drawing.Point(3, 16);
			this.tabController.Name = "tabController";
			this.tabController.SelectedIndex = 0;
			this.tabController.SelectedTab = this.tabPage1;
			this.tabController.Size = new System.Drawing.Size(1028, 692);
			this.tabController.TabIndex = 25;
			this.tabController.TabPages.AddRange(new Crownwood.Magic.Controls.TabPage[] {
            this.tabPage1,
            this.tabPage2,
            this.tabPage3});
			this.tabController.SelectionChanged += new System.EventHandler(this.tabController_SelectionChanged);
			// 
			// tabPage1
			// 
			this.tabPage1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tabPage1.Controls.Add(this.groupBox2);
			this.tabPage1.Location = new System.Drawing.Point(0, 0);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Size = new System.Drawing.Size(1028, 667);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Title = "Pagina 1 di 3";
			// 
			// groupBox2
			// 
			this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox2.Controls.Add(this.grpPagamenti);
			this.groupBox2.Controls.Add(this.grpGestioneimporti);
			this.groupBox2.Controls.Add(this.grpInvio);
			this.groupBox2.Controls.Add(this.label1);
			this.groupBox2.Controls.Add(this.grpAnagrafica);
			this.groupBox2.Controls.Add(this.label5);
			this.groupBox2.Controls.Add(this.txtPercorso);
			this.groupBox2.Controls.Add(this.btnCartella);
			this.groupBox2.Controls.Add(this.label63);
			this.groupBox2.Controls.Add(this.label4);
			this.groupBox2.Controls.Add(this.txtAl);
			this.groupBox2.Controls.Add(this.txtDal);
			this.groupBox2.Location = new System.Drawing.Point(15, 17);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(996, 636);
			this.groupBox2.TabIndex = 29;
			this.groupBox2.TabStop = false;
			// 
			// grpPagamenti
			// 
			this.grpPagamenti.Controls.Add(this.label3);
			this.grpPagamenti.Controls.Add(this.label2);
			this.grpPagamenti.Controls.Add(this.txtEsercizio);
			this.grpPagamenti.Controls.Add(this.chkIP);
			this.grpPagamenti.Location = new System.Drawing.Point(20, 342);
			this.grpPagamenti.Name = "grpPagamenti";
			this.grpPagamenti.Size = new System.Drawing.Size(609, 104);
			this.grpPagamenti.TabIndex = 55;
			this.grpPagamenti.TabStop = false;
			this.grpPagamenti.Text = "GESTIONE PAGAMENTI (solo per Enti NO Siope+)";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(391, 43);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(178, 21);
			this.label3.TabIndex = 48;
			this.label3.Text = "Non compilare per vederli tutti.";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(94, 46);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(218, 15);
			this.label2.TabIndex = 47;
			this.label2.Text = "Considera Mandati fatture dall\'esercizio:";
			// 
			// txtEsercizio
			// 
			this.txtEsercizio.Location = new System.Drawing.Point(318, 42);
			this.txtEsercizio.Name = "txtEsercizio";
			this.txtEsercizio.Size = new System.Drawing.Size(67, 23);
			this.txtEsercizio.TabIndex = 46;
			this.txtEsercizio.Tag = "";
			this.txtEsercizio.Leave += new System.EventHandler(this.txtEsercizio_Leave);
			// 
			// chkIP
			// 
			this.chkIP.AutoSize = true;
			this.chkIP.Location = new System.Drawing.Point(7, 42);
			this.chkIP.Name = "chkIP";
			this.chkIP.Size = new System.Drawing.Size(36, 19);
			this.chkIP.TabIndex = 45;
			this.chkIP.Text = "IP";
			this.chkIP.UseVisualStyleBackColor = true;
			this.chkIP.CheckedChanged += new System.EventHandler(this.chkIP_CheckedChanged);
			// 
			// grpGestioneimporti
			// 
			this.grpGestioneimporti.Controls.Add(this.chkMI);
			this.grpGestioneimporti.Controls.Add(this.chkScadenza);
			this.grpGestioneimporti.Controls.Add(this.chkSID);
			this.grpGestioneimporti.Location = new System.Drawing.Point(20, 213);
			this.grpGestioneimporti.Name = "grpGestioneimporti";
			this.grpGestioneimporti.Size = new System.Drawing.Size(237, 110);
			this.grpGestioneimporti.TabIndex = 54;
			this.grpGestioneimporti.TabStop = false;
			this.grpGestioneimporti.Text = "GESTIONE IMPORTI DOCUMENTI";
			// 
			// chkMI
			// 
			this.chkMI.AutoSize = true;
			this.chkMI.Location = new System.Drawing.Point(18, 78);
			this.chkMI.Name = "chkMI";
			this.chkMI.Size = new System.Drawing.Size(40, 19);
			this.chkMI.TabIndex = 44;
			this.chkMI.Text = "MI";
			this.chkMI.UseVisualStyleBackColor = true;
			this.chkMI.CheckedChanged += new System.EventHandler(this.chkMI_CheckedChanged);
			// 
			// chkScadenza
			// 
			this.chkScadenza.AutoSize = true;
			this.chkScadenza.Location = new System.Drawing.Point(18, 53);
			this.chkScadenza.Name = "chkScadenza";
			this.chkScadenza.Size = new System.Drawing.Size(40, 19);
			this.chkScadenza.TabIndex = 43;
			this.chkScadenza.Text = "CS";
			this.chkScadenza.UseVisualStyleBackColor = true;
			this.chkScadenza.CheckedChanged += new System.EventHandler(this.chkScadenza_CheckedChanged);
			// 
			// chkSID
			// 
			this.chkSID.AutoSize = true;
			this.chkSID.Location = new System.Drawing.Point(18, 28);
			this.chkSID.Name = "chkSID";
			this.chkSID.Size = new System.Drawing.Size(43, 19);
			this.chkSID.TabIndex = 42;
			this.chkSID.Text = "SID";
			this.chkSID.UseVisualStyleBackColor = true;
			this.chkSID.CheckedChanged += new System.EventHandler(this.chkSID_CheckedChanged);
			// 
			// grpInvio
			// 
			this.grpInvio.Controls.Add(this.chkInvio);
			this.grpInvio.Location = new System.Drawing.Point(20, 118);
			this.grpInvio.Name = "grpInvio";
			this.grpInvio.Size = new System.Drawing.Size(237, 68);
			this.grpInvio.TabIndex = 53;
			this.grpInvio.TabStop = false;
			this.grpInvio.Text = "INVIO Fatture non elettroniche";
			// 
			// chkInvio
			// 
			this.chkInvio.AutoSize = true;
			this.chkInvio.Location = new System.Drawing.Point(16, 31);
			this.chkInvio.Name = "chkInvio";
			this.chkInvio.Size = new System.Drawing.Size(57, 19);
			this.chkInvio.TabIndex = 51;
			this.chkInvio.Text = "INVIO";
			this.chkInvio.UseVisualStyleBackColor = true;
			this.chkInvio.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(17, 19);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(235, 21);
			this.label1.TabIndex = 41;
			this.label1.Text = "Fatture e documenti equivalenti emessi dal";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// grpAnagrafica
			// 
			this.grpAnagrafica.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.grpAnagrafica.Controls.Add(this.txtAnagrafica);
			this.grpAnagrafica.Location = new System.Drawing.Point(20, 479);
			this.grpAnagrafica.Name = "grpAnagrafica";
			this.grpAnagrafica.Size = new System.Drawing.Size(956, 48);
			this.grpAnagrafica.TabIndex = 40;
			this.grpAnagrafica.TabStop = false;
			this.grpAnagrafica.Tag = "AutoChoose.txtAnagrafica.default.(active=\'S\')";
			this.grpAnagrafica.Text = "Utente che trasmette il file (Inserire l\'utente della login al sito dell\'AreaRGS)" +
    "";
			// 
			// txtAnagrafica
			// 
			this.txtAnagrafica.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtAnagrafica.Location = new System.Drawing.Point(16, 16);
			this.txtAnagrafica.Name = "txtAnagrafica";
			this.txtAnagrafica.Size = new System.Drawing.Size(924, 23);
			this.txtAnagrafica.TabIndex = 1;
			this.txtAnagrafica.Tag = "registry.title?x";
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(17, 533);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(470, 21);
			this.label5.TabIndex = 39;
			this.label5.Text = "Indicare la cartella in cui salvare il file";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtPercorso
			// 
			this.txtPercorso.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtPercorso.Location = new System.Drawing.Point(89, 559);
			this.txtPercorso.Name = "txtPercorso";
			this.txtPercorso.ReadOnly = true;
			this.txtPercorso.Size = new System.Drawing.Size(887, 23);
			this.txtPercorso.TabIndex = 38;
			// 
			// btnCartella
			// 
			this.btnCartella.AutoSize = true;
			this.btnCartella.Location = new System.Drawing.Point(20, 558);
			this.btnCartella.Name = "btnCartella";
			this.btnCartella.Size = new System.Drawing.Size(63, 25);
			this.btnCartella.TabIndex = 37;
			this.btnCartella.Text = "Cartella";
			this.btnCartella.UseVisualStyleBackColor = true;
			this.btnCartella.Click += new System.EventHandler(this.btnCartella_Click);
			// 
			// label63
			// 
			this.label63.Location = new System.Drawing.Point(344, 22);
			this.label63.Name = "label63";
			this.label63.Size = new System.Drawing.Size(24, 16);
			this.label63.TabIndex = 31;
			this.label63.Text = "al";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World);
			this.label4.Location = new System.Drawing.Point(23, 78);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(210, 15);
			this.label4.TabIndex = 1;
			this.label4.Text = "Selezionate il tipo di file da generare";
			// 
			// txtAl
			// 
			this.txtAl.Location = new System.Drawing.Point(374, 19);
			this.txtAl.Name = "txtAl";
			this.txtAl.ReadOnly = true;
			this.txtAl.Size = new System.Drawing.Size(72, 23);
			this.txtAl.TabIndex = 33;
			// 
			// txtDal
			// 
			this.txtDal.Location = new System.Drawing.Point(260, 19);
			this.txtDal.Name = "txtDal";
			this.txtDal.ReadOnly = true;
			this.txtDal.Size = new System.Drawing.Size(72, 23);
			this.txtDal.TabIndex = 32;
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.btnSelezionaTutto);
			this.tabPage2.Controls.Add(this.label8);
			this.tabPage2.Controls.Add(this.gridDettagli);
			this.tabPage2.Location = new System.Drawing.Point(0, 0);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Selected = false;
			this.tabPage2.Size = new System.Drawing.Size(1028, 667);
			this.tabPage2.TabIndex = 0;
			this.tabPage2.Title = "Pagina 2 di 3";
			// 
			// btnSelezionaTutto
			// 
			this.btnSelezionaTutto.Location = new System.Drawing.Point(10, 18);
			this.btnSelezionaTutto.Name = "btnSelezionaTutto";
			this.btnSelezionaTutto.Size = new System.Drawing.Size(88, 23);
			this.btnSelezionaTutto.TabIndex = 31;
			this.btnSelezionaTutto.Text = "Seleziona tutto";
			this.btnSelezionaTutto.Click += new System.EventHandler(this.btnSelezionaTutto_Click);
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(102, 21);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(701, 23);
			this.label8.TabIndex = 30;
			this.label8.Text = "Tenere premuto il tasto CTRL o MAIUSC e contemporaneamente cliccare con il mouse " +
    "per selezionare più operazioni da inviare";
			// 
			// gridDettagli
			// 
			this.gridDettagli.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.gridDettagli.CaptionVisible = false;
			this.gridDettagli.DataMember = "";
			this.gridDettagli.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.gridDettagli.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.gridDettagli.Location = new System.Drawing.Point(10, 47);
			this.gridDettagli.Name = "gridDettagli";
			this.gridDettagli.Size = new System.Drawing.Size(1003, 606);
			this.gridDettagli.TabIndex = 28;
			this.gridDettagli.Paint += new System.Windows.Forms.PaintEventHandler(this.gridDettagli_Paint);
			// 
			// tabPage3
			// 
			this.tabPage3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tabPage3.Controls.Add(this.lblFinale);
			this.tabPage3.Location = new System.Drawing.Point(0, 0);
			this.tabPage3.Name = "tabPage3";
			this.tabPage3.Selected = false;
			this.tabPage3.Size = new System.Drawing.Size(1028, 667);
			this.tabPage3.TabIndex = 3;
			this.tabPage3.Title = "Pagina 3 di 3";
			// 
			// lblFinale
			// 
			this.lblFinale.AutoSize = true;
			this.lblFinale.Location = new System.Drawing.Point(29, 45);
			this.lblFinale.Name = "lblFinale";
			this.lblFinale.Size = new System.Drawing.Size(187, 15);
			this.lblFinale.TabIndex = 0;
			this.lblFinale.Text = "Procedere col salvataggio dei dati.";
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox1.Controls.Add(this.tabController);
			this.groupBox1.Location = new System.Drawing.Point(10, 12);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(1034, 711);
			this.groupBox1.TabIndex = 27;
			this.groupBox1.TabStop = false;
			// 
			// DS
			// 
			this.DS.DataSetName = "vistaForm";
			this.DS.EnforceConstraints = false;
			// 
			// Frm_pccsid_wizard_calcolo
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
			this.ClientSize = new System.Drawing.Size(1056, 795);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.btnAnnulla);
			this.Controls.Add(this.btnNext);
			this.Controls.Add(this.btnBack);
			this.Name = "Frm_pccsid_wizard_calcolo";
			this.Text = "Frm_pccsid_wizard_calcolo";
			this.tabController.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.grpPagamenti.ResumeLayout(false);
			this.grpPagamenti.PerformLayout();
			this.grpGestioneimporti.ResumeLayout(false);
			this.grpGestioneimporti.PerformLayout();
			this.grpInvio.ResumeLayout(false);
			this.grpInvio.PerformLayout();
			this.grpAnagrafica.ResumeLayout(false);
			this.grpAnagrafica.PerformLayout();
			this.tabPage2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.gridDettagli)).EndInit();
			this.tabPage3.ResumeLayout(false);
			this.tabPage3.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
			this.ResumeLayout(false);

        }

        #endregion

        public vistaForm DS;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.FolderBrowserDialog _folderBrowserDialog1;
        private System.Windows.Forms.Button btnAnnulla;
		private Crownwood.Magic.Controls.TabControl tabController;
		private Crownwood.Magic.Controls.TabPage tabPage1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.CheckBox chkMI;
		private System.Windows.Forms.CheckBox chkScadenza;
		private System.Windows.Forms.CheckBox chkSID;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.GroupBox grpAnagrafica;
		private System.Windows.Forms.TextBox txtAnagrafica;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox txtPercorso;
		private System.Windows.Forms.Button btnCartella;
		private System.Windows.Forms.Label label63;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox txtAl;
		private System.Windows.Forms.TextBox txtDal;
		private Crownwood.Magic.Controls.TabPage tabPage2;
		private System.Windows.Forms.Button btnSelezionaTutto;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.DataGrid gridDettagli;
		private Crownwood.Magic.Controls.TabPage tabPage3;
		private System.Windows.Forms.Label lblFinale;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.CheckBox chkIP;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtEsercizio;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.CheckBox chkInvio;
		private System.Windows.Forms.GroupBox grpInvio;
		private System.Windows.Forms.GroupBox grpPagamenti;
		private System.Windows.Forms.GroupBox grpGestioneimporti;
	}
}
