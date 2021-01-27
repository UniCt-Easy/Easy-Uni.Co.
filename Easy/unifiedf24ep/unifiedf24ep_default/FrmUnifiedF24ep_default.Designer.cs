
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


namespace unifiedf24ep_default {
    partial class Frmunifiedf24ep_default {
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
            this.tabPageSanzioni = new System.Windows.Forms.TabPage();
            this.btnEliminaSanzione = new System.Windows.Forms.Button();
            this.btnModificaSanzione = new System.Windows.Forms.Button();
            this.btnInserisciSanzione = new System.Windows.Forms.Button();
            this.gridSanzioni = new System.Windows.Forms.DataGrid();
            this.DS = new unifiedf24ep_default.vistaForm();
            this.grpTotaleAddebito = new System.Windows.Forms.GroupBox();
            this.btnCollegaDettagli = new System.Windows.Forms.Button();
            this.btnSituazione = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbMese = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPageSanzioni.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridSanzioni)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.grpTotaleAddebito.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtTotaleAddebito
            // 
            this.txtTotaleAddebito.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTotaleAddebito.Location = new System.Drawing.Point(126, 7);
            this.txtTotaleAddebito.Name = "txtTotaleAddebito";
            this.txtTotaleAddebito.Size = new System.Drawing.Size(117, 20);
            this.txtTotaleAddebito.TabIndex = 10;
            this.txtTotaleAddebito.Tag = "";
            // 
            // txtEsercizio
            // 
            this.txtEsercizio.Location = new System.Drawing.Point(210, 12);
            this.txtEsercizio.Name = "txtEsercizio";
            this.txtEsercizio.ReadOnly = true;
            this.txtEsercizio.Size = new System.Drawing.Size(83, 20);
            this.txtEsercizio.TabIndex = 6;
            this.txtEsercizio.Tag = "unifiedf24ep.ayear";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(155, 15);
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
            this.txtDataDiVersamento.Tag = "unifiedf24ep.paymentdate";
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
            this.groupBox2.Location = new System.Drawing.Point(12, 48);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(641, 85);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Dati identificativi del fornitore del file";
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Location = new System.Drawing.Point(350, 52);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(32, 13);
            this.label.TabIndex = 9;
            this.label.Text = "Email";
            // 
            // txtEmail
            // 
            this.txtEmail.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEmail.Location = new System.Drawing.Point(388, 49);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.ReadOnly = true;
            this.txtEmail.Size = new System.Drawing.Size(246, 20);
            this.txtEmail.TabIndex = 8;
            // 
            // txtDenominazione
            // 
            this.txtDenominazione.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDenominazione.Location = new System.Drawing.Point(288, 23);
            this.txtDenominazione.Name = "txtDenominazione";
            this.txtDenominazione.ReadOnly = true;
            this.txtDenominazione.Size = new System.Drawing.Size(347, 20);
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
            this.groupBox3.Location = new System.Drawing.Point(12, 132);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(641, 52);
            this.groupBox3.TabIndex = 11;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Modalità di versamento";
            // 
            // txtContoDiAddebito
            // 
            this.txtContoDiAddebito.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
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
            this.btnGeneraF24.Location = new System.Drawing.Point(13, 238);
            this.btnGeneraF24.Name = "btnGeneraF24";
            this.btnGeneraF24.Size = new System.Drawing.Size(159, 34);
            this.btnGeneraF24.TabIndex = 12;
            this.btnGeneraF24.Text = "Genera F24 EP Consolidato";
            this.btnGeneraF24.UseVisualStyleBackColor = true;
            this.btnGeneraF24.Click += new System.EventHandler(this.btnGeneraF24_Click);
            // 
            // txtPercorso
            // 
            this.txtPercorso.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPercorso.Location = new System.Drawing.Point(178, 246);
            this.txtPercorso.Name = "txtPercorso";
            this.txtPercorso.ReadOnly = true;
            this.txtPercorso.Size = new System.Drawing.Size(474, 20);
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
            this.textBox3.Size = new System.Drawing.Size(83, 20);
            this.textBox3.TabIndex = 15;
            this.textBox3.Tag = "unifiedf24ep.idunifiedf24ep";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(265, 202);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(102, 13);
            this.label10.TabIndex = 16;
            this.label10.Text = "Data di generazione";
            // 
            // txtDataGenerazione
            // 
            this.txtDataGenerazione.Location = new System.Drawing.Point(373, 199);
            this.txtDataGenerazione.Name = "txtDataGenerazione";
            this.txtDataGenerazione.ReadOnly = true;
            this.txtDataGenerazione.Size = new System.Drawing.Size(100, 20);
            this.txtDataGenerazione.TabIndex = 17;
            this.txtDataGenerazione.Tag = "unifiedf24ep.adate";
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
            this.tabControl1.Controls.Add(this.tabPageSanzioni);
            this.tabControl1.Location = new System.Drawing.Point(12, 289);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(644, 278);
            this.tabControl1.TabIndex = 19;
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
            this.tabPageSanzioni.Size = new System.Drawing.Size(636, 252);
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
            this.gridSanzioni.Size = new System.Drawing.Size(540, 221);
            this.gridSanzioni.TabIndex = 9;
            this.gridSanzioni.TabStop = false;
            this.gridSanzioni.Tag = "unifiedf24epsanction.default.single";
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.EnforceConstraints = false;
            // 
            // grpTotaleAddebito
            // 
            this.grpTotaleAddebito.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpTotaleAddebito.Controls.Add(this.txtTotaleAddebito);
            this.grpTotaleAddebito.Location = new System.Drawing.Point(403, 268);
            this.grpTotaleAddebito.Name = "grpTotaleAddebito";
            this.grpTotaleAddebito.Size = new System.Drawing.Size(251, 33);
            this.grpTotaleAddebito.TabIndex = 20;
            this.grpTotaleAddebito.TabStop = false;
            this.grpTotaleAddebito.Text = "Totale Addebito";
            // 
            // btnCollegaDettagli
            // 
            this.btnCollegaDettagli.AutoSize = true;
            this.btnCollegaDettagli.Location = new System.Drawing.Point(13, 191);
            this.btnCollegaDettagli.Name = "btnCollegaDettagli";
            this.btnCollegaDettagli.Size = new System.Drawing.Size(189, 34);
            this.btnCollegaDettagli.TabIndex = 21;
            this.btnCollegaDettagli.Text = "Collega Dettagli Ritenute e Recuperi";
            this.btnCollegaDettagli.UseVisualStyleBackColor = true;
            this.btnCollegaDettagli.Click += new System.EventHandler(this.btnCollegaDettagli_Click);
            // 
            // btnSituazione
            // 
            this.btnSituazione.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSituazione.AutoSize = true;
            this.btnSituazione.Location = new System.Drawing.Point(491, 191);
            this.btnSituazione.Name = "btnSituazione";
            this.btnSituazione.Size = new System.Drawing.Size(159, 34);
            this.btnSituazione.TabIndex = 22;
            this.btnSituazione.Text = "Situazione F24EP Consolidato";
            this.btnSituazione.UseVisualStyleBackColor = true;
            this.btnSituazione.Click += new System.EventHandler(this.btnSituazione_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(306, 15);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(98, 13);
            this.label6.TabIndex = 24;
            this.label6.Text = "Mese dichiarazione";
            // 
            // cmbMese
            // 
            this.cmbMese.DataSource = this.DS.monthname;
            this.cmbMese.DisplayMember = "title";
            this.cmbMese.FormattingEnabled = true;
            this.cmbMese.Location = new System.Drawing.Point(412, 11);
            this.cmbMese.Name = "cmbMese";
            this.cmbMese.Size = new System.Drawing.Size(154, 21);
            this.cmbMese.TabIndex = 23;
            this.cmbMese.Tag = "unifiedf24ep.nmonth";
            this.cmbMese.ValueMember = "code";
            // 
            // button1
            // 
            this.button1.AutoSize = true;
            this.button1.Location = new System.Drawing.Point(259, 274);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(130, 23);
            this.button1.TabIndex = 25;
            this.button1.Text = "Esporta Dati in Excel";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Frmunifiedf24ep_default
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(665, 576);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cmbMese);
            this.Controls.Add(this.btnSituazione);
            this.Controls.Add(this.btnCollegaDettagli);
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
            this.Name = "Frmunifiedf24ep_default";
            this.Text = "Frmunifiedf24ep_default";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPageSanzioni.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridSanzioni)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.grpTotaleAddebito.ResumeLayout(false);
            this.grpTotaleAddebito.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

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
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtDataGenerazione;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageSanzioni;
        private System.Windows.Forms.DataGrid gridSanzioni;
        private System.Windows.Forms.Button btnEliminaSanzione;
        private System.Windows.Forms.Button btnModificaSanzione;
        private System.Windows.Forms.Button btnInserisciSanzione;
        private System.Windows.Forms.GroupBox grpTotaleAddebito;
        private System.Windows.Forms.Button btnCollegaDettagli;
        private System.Windows.Forms.Button btnSituazione;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbMese;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Button button1;
    }
}
