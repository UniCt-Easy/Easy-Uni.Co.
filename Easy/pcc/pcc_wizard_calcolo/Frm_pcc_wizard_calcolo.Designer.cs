
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


namespace pcc_wizard_calcolo {
    partial class Frm_pcc_wizard_calcolo {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_pcc_wizard_calcolo));
            this.btnNext = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.tabController = new Crownwood.Magic.Controls.TabControl();
            this.tabPage2 = new Crownwood.Magic.Controls.TabPage();
            this.btnSelezionaTutto = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.gridDettagli = new System.Windows.Forms.DataGrid();
            this.tabPage1 = new Crownwood.Magic.Controls.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chkPagamento = new System.Windows.Forms.CheckBox();
            this.chkScadenza = new System.Windows.Forms.CheckBox();
            this.chkContabilizzazione = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.grpAnagrafica = new System.Windows.Forms.GroupBox();
            this.txtAnagrafica = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPercorso = new System.Windows.Forms.TextBox();
            this.btnCartella = new System.Windows.Forms.Button();
            this.label63 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.rdbOperazioni = new System.Windows.Forms.RadioButton();
            this.txtAl = new System.Windows.Forms.TextBox();
            this.rdbInvio = new System.Windows.Forms.RadioButton();
            this.txtDal = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tabPage3 = new Crownwood.Magic.Controls.TabPage();
            this.lblFinale = new System.Windows.Forms.Label();
            this._folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.DS = new pcc_wizard_calcolo.vistaForm();
            this.btnAnnulla = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tabController.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridDettagli)).BeginInit();
            this.tabPage1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.grpAnagrafica.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnNext
            // 
            this.btnNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNext.Location = new System.Drawing.Point(650, 534);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(72, 23);
            this.btnNext.TabIndex = 21;
            this.btnNext.Text = "Avanti >";
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnBack
            // 
            this.btnBack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBack.Location = new System.Drawing.Point(570, 534);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(72, 23);
            this.btnBack.TabIndex = 20;
            this.btnBack.Text = "< Indietro";
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // tabController
            // 
            this.tabController.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabController.IDEPixelArea = true;
            this.tabController.Location = new System.Drawing.Point(3, 16);
            this.tabController.Name = "tabController";
            this.tabController.SelectedIndex = 1;
            this.tabController.SelectedTab = this.tabPage2;
            this.tabController.Size = new System.Drawing.Size(816, 481);
            this.tabController.TabIndex = 25;
            this.tabController.TabPages.AddRange(new Crownwood.Magic.Controls.TabPage[] {
            this.tabPage1,
            this.tabPage2,
            this.tabPage3});
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnSelezionaTutto);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.gridDettagli);
            this.tabPage2.Location = new System.Drawing.Point(0, 0);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(816, 456);
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
            this.gridDettagli.Size = new System.Drawing.Size(791, 395);
            this.gridDettagli.TabIndex = 28;
            this.gridDettagli.Paint += new System.Windows.Forms.PaintEventHandler(this.gridDettagli_Paint);
            // 
            // tabPage1
            // 
            this.tabPage1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Location = new System.Drawing.Point(0, 0);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Selected = false;
            this.tabPage1.Size = new System.Drawing.Size(816, 456);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Title = "Pagina 1 di 3";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.chkPagamento);
            this.groupBox2.Controls.Add(this.chkScadenza);
            this.groupBox2.Controls.Add(this.chkContabilizzazione);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.grpAnagrafica);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.txtPercorso);
            this.groupBox2.Controls.Add(this.btnCartella);
            this.groupBox2.Controls.Add(this.label63);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.rdbOperazioni);
            this.groupBox2.Controls.Add(this.txtAl);
            this.groupBox2.Controls.Add(this.rdbInvio);
            this.groupBox2.Controls.Add(this.txtDal);
            this.groupBox2.Location = new System.Drawing.Point(15, 143);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(670, 305);
            this.groupBox2.TabIndex = 29;
            this.groupBox2.TabStop = false;
            // 
            // chkPagamento
            // 
            this.chkPagamento.AutoSize = true;
            this.chkPagamento.Location = new System.Drawing.Point(499, 91);
            this.chkPagamento.Name = "chkPagamento";
            this.chkPagamento.Size = new System.Drawing.Size(87, 19);
            this.chkPagamento.TabIndex = 44;
            this.chkPagamento.Text = "Pagamento";
            this.chkPagamento.UseVisualStyleBackColor = true;
            // 
            // chkScadenza
            // 
            this.chkScadenza.AutoSize = true;
            this.chkScadenza.Location = new System.Drawing.Point(404, 91);
            this.chkScadenza.Name = "chkScadenza";
            this.chkScadenza.Size = new System.Drawing.Size(75, 19);
            this.chkScadenza.TabIndex = 43;
            this.chkScadenza.Text = "Scadenza";
            this.chkScadenza.UseVisualStyleBackColor = true;
            // 
            // chkContabilizzazione
            // 
            this.chkContabilizzazione.AutoSize = true;
            this.chkContabilizzazione.Location = new System.Drawing.Point(280, 90);
            this.chkContabilizzazione.Name = "chkContabilizzazione";
            this.chkContabilizzazione.Size = new System.Drawing.Size(118, 19);
            this.chkContabilizzazione.TabIndex = 42;
            this.chkContabilizzazione.Text = "Contabilizzazione";
            this.chkContabilizzazione.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(17, 130);
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
            this.grpAnagrafica.Location = new System.Drawing.Point(20, 177);
            this.grpAnagrafica.Name = "grpAnagrafica";
            this.grpAnagrafica.Size = new System.Drawing.Size(630, 48);
            this.grpAnagrafica.TabIndex = 40;
            this.grpAnagrafica.TabStop = false;
            this.grpAnagrafica.Tag = "AutoChoose.txtAnagrafica.default.(active=\'S\')";
            this.grpAnagrafica.Text = "Utente che trasmette il file (Inserire l\'utente della login al sito dalla PCC)";
            // 
            // txtAnagrafica
            // 
            this.txtAnagrafica.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAnagrafica.Location = new System.Drawing.Point(16, 16);
            this.txtAnagrafica.Name = "txtAnagrafica";
            this.txtAnagrafica.Size = new System.Drawing.Size(598, 23);
            this.txtAnagrafica.TabIndex = 1;
            this.txtAnagrafica.Tag = "registry.title?x";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(17, 245);
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
            this.txtPercorso.Location = new System.Drawing.Point(89, 271);
            this.txtPercorso.Name = "txtPercorso";
            this.txtPercorso.ReadOnly = true;
            this.txtPercorso.Size = new System.Drawing.Size(561, 23);
            this.txtPercorso.TabIndex = 38;
            // 
            // btnCartella
            // 
            this.btnCartella.AutoSize = true;
            this.btnCartella.Location = new System.Drawing.Point(20, 269);
            this.btnCartella.Name = "btnCartella";
            this.btnCartella.Size = new System.Drawing.Size(63, 25);
            this.btnCartella.TabIndex = 37;
            this.btnCartella.Text = "Cartella";
            this.btnCartella.UseVisualStyleBackColor = true;
            this.btnCartella.Click += new System.EventHandler(this.btnCartella_Click);
            // 
            // label63
            // 
            this.label63.Location = new System.Drawing.Point(344, 133);
            this.label63.Name = "label63";
            this.label63.Size = new System.Drawing.Size(24, 16);
            this.label63.TabIndex = 31;
            this.label63.Text = "al";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 31);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(196, 15);
            this.label4.TabIndex = 1;
            this.label4.Text = "Selezionate il tipo di file da generare";
            // 
            // rdbOperazioni
            // 
            this.rdbOperazioni.AutoSize = true;
            this.rdbOperazioni.Location = new System.Drawing.Point(32, 89);
            this.rdbOperazioni.Name = "rdbOperazioni";
            this.rdbOperazioni.Size = new System.Drawing.Size(196, 19);
            this.rdbOperazioni.TabIndex = 3;
            this.rdbOperazioni.Text = "Operazioni su fatture precaricate";
            this.rdbOperazioni.UseVisualStyleBackColor = true;
            // 
            // txtAl
            // 
            this.txtAl.Location = new System.Drawing.Point(374, 130);
            this.txtAl.Name = "txtAl";
            this.txtAl.ReadOnly = true;
            this.txtAl.Size = new System.Drawing.Size(72, 23);
            this.txtAl.TabIndex = 33;
            // 
            // rdbInvio
            // 
            this.rdbInvio.AutoSize = true;
            this.rdbInvio.Checked = true;
            this.rdbInvio.Location = new System.Drawing.Point(32, 57);
            this.rdbInvio.Name = "rdbInvio";
            this.rdbInvio.Size = new System.Drawing.Size(51, 19);
            this.rdbInvio.TabIndex = 2;
            this.rdbInvio.TabStop = true;
            this.rdbInvio.Text = "Invio";
            this.rdbInvio.UseVisualStyleBackColor = true;
            // 
            // txtDal
            // 
            this.txtDal.Location = new System.Drawing.Point(260, 130);
            this.txtDal.Name = "txtDal";
            this.txtDal.ReadOnly = true;
            this.txtDal.Size = new System.Drawing.Size(72, 23);
            this.txtDal.TabIndex = 32;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(16, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(748, 117);
            this.label3.TabIndex = 28;
            this.label3.Text = resources.GetString("label3.Text");
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
            this.tabPage3.Size = new System.Drawing.Size(816, 456);
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
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.EnforceConstraints = false;
            // 
            // btnAnnulla
            // 
            this.btnAnnulla.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAnnulla.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnAnnulla.Location = new System.Drawing.Point(760, 534);
            this.btnAnnulla.Name = "btnAnnulla";
            this.btnAnnulla.Size = new System.Drawing.Size(72, 23);
            this.btnAnnulla.TabIndex = 26;
            this.btnAnnulla.Tag = "maincancel";
            this.btnAnnulla.Text = "Chiudi";
            this.btnAnnulla.Click += new System.EventHandler(this.btnAnnulla_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.tabController);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(822, 500);
            this.groupBox1.TabIndex = 27;
            this.groupBox1.TabStop = false;
            // 
            // Frm_pcc_wizard_calcolo
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(844, 584);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnAnnulla);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnBack);
            this.Name = "Frm_pcc_wizard_calcolo";
            this.Text = "Frm_pcc_wizard_calcolo";
            this.tabController.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridDettagli)).EndInit();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.grpAnagrafica.ResumeLayout(false);
            this.grpAnagrafica.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public vistaForm DS;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnBack;
        private Crownwood.Magic.Controls.TabControl tabController;
        private Crownwood.Magic.Controls.TabPage tabPage1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton rdbOperazioni;
        private System.Windows.Forms.RadioButton rdbInvio;
        private System.Windows.Forms.Label label3;
        private Crownwood.Magic.Controls.TabPage tabPage2;
        private System.Windows.Forms.DataGrid gridDettagli;
        private Crownwood.Magic.Controls.TabPage tabPage3;
        private System.Windows.Forms.Label lblFinale;
        private System.Windows.Forms.Label label63;
        private System.Windows.Forms.TextBox txtAl;
        private System.Windows.Forms.TextBox txtDal;
        private System.Windows.Forms.Button btnSelezionaTutto;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.FolderBrowserDialog _folderBrowserDialog1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtPercorso;
        private System.Windows.Forms.Button btnCartella;
        private System.Windows.Forms.GroupBox grpAnagrafica;
        private System.Windows.Forms.TextBox txtAnagrafica;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAnnulla;
        private System.Windows.Forms.CheckBox chkPagamento;
        private System.Windows.Forms.CheckBox chkScadenza;
        private System.Windows.Forms.CheckBox chkContabilizzazione;
        private System.Windows.Forms.GroupBox groupBox1;

    }
}
