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

namespace no_table_f24ep {
    partial class Frmf24ep {
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
            this.DS = new no_table_f24ep.vistaForm();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtInputFile = new System.Windows.Forms.TextBox();
            this.btnFileInput = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.openInputFileDlg = new System.Windows.Forms.OpenFileDialog();
            this.saveOutputFileDlg = new System.Windows.Forms.SaveFileDialog();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtContoDiAddebito = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDataDiVersamento = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtDenominazione = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCodiceFiscale = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtDataGenerazione = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtPercorso = new System.Windows.Forms.TextBox();
            this.lblIndividuazione = new System.Windows.Forms.Label();
            this.btnElabora = new System.Windows.Forms.Button();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.EnforceConstraints = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtInputFile);
            this.groupBox2.Controls.Add(this.btnFileInput);
            this.groupBox2.Location = new System.Drawing.Point(11, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(539, 71);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Input";
            // 
            // txtInputFile
            // 
            this.txtInputFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtInputFile.Location = new System.Drawing.Point(7, 43);
            this.txtInputFile.Name = "txtInputFile";
            this.txtInputFile.ReadOnly = true;
            this.txtInputFile.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.txtInputFile.Size = new System.Drawing.Size(523, 20);
            this.txtInputFile.TabIndex = 0;
            // 
            // btnFileInput
            // 
            this.btnFileInput.Location = new System.Drawing.Point(6, 17);
            this.btnFileInput.Name = "btnFileInput";
            this.btnFileInput.Size = new System.Drawing.Size(182, 23);
            this.btnFileInput.TabIndex = 1;
            this.btnFileInput.Text = "Importa Dati da File Excel";
            this.btnFileInput.Click += new System.EventHandler(this.btnFileInput_Click);
            // 
            // saveOutputFileDlg
            // 
            this.saveOutputFileDlg.DefaultExt = "T24";
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.txtContoDiAddebito);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.txtDataDiVersamento);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Location = new System.Drawing.Point(10, 267);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(540, 52);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Modalità di versamento";
            // 
            // txtContoDiAddebito
            // 
            this.txtContoDiAddebito.Location = new System.Drawing.Point(288, 23);
            this.txtContoDiAddebito.Name = "txtContoDiAddebito";
            this.txtContoDiAddebito.ReadOnly = true;
            this.txtContoDiAddebito.Size = new System.Drawing.Size(244, 20);
            this.txtContoDiAddebito.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(198, 26);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(90, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Conto di addebito";
            // 
            // txtDataDiVersamento
            // 
            this.txtDataDiVersamento.Location = new System.Drawing.Point(92, 23);
            this.txtDataDiVersamento.Name = "txtDataDiVersamento";
            this.txtDataDiVersamento.Size = new System.Drawing.Size(100, 20);
            this.txtDataDiVersamento.TabIndex = 1;
            this.txtDataDiVersamento.Tag = "";
            this.txtDataDiVersamento.Leave += new System.EventHandler(this.txtDataDiVersamento_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Data di addebito";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.label);
            this.groupBox1.Controls.Add(this.txtEmail);
            this.groupBox1.Controls.Add(this.txtDenominazione);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtCodiceFiscale);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(10, 175);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(540, 86);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Dati identificativi del fornitore del file";
            // 
            // txtDenominazione
            // 
            this.txtDenominazione.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDenominazione.Location = new System.Drawing.Point(288, 23);
            this.txtDenominazione.Name = "txtDenominazione";
            this.txtDenominazione.ReadOnly = true;
            this.txtDenominazione.Size = new System.Drawing.Size(246, 20);
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Codice fiscale";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.txtDataGenerazione);
            this.groupBox4.Controls.Add(this.label10);
            this.groupBox4.Controls.Add(this.txtPercorso);
            this.groupBox4.Controls.Add(this.lblIndividuazione);
            this.groupBox4.Controls.Add(this.btnElabora);
            this.groupBox4.Location = new System.Drawing.Point(11, 76);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(539, 98);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Generazione";
            // 
            // txtDataGenerazione
            // 
            this.txtDataGenerazione.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDataGenerazione.Location = new System.Drawing.Point(430, 66);
            this.txtDataGenerazione.Name = "txtDataGenerazione";
            this.txtDataGenerazione.ReadOnly = true;
            this.txtDataGenerazione.Size = new System.Drawing.Size(100, 20);
            this.txtDataGenerazione.TabIndex = 4;
            this.txtDataGenerazione.Tag = "";
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(321, 69);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(102, 13);
            this.label10.TabIndex = 3;
            this.label10.Text = "Data di generazione";
            // 
            // txtPercorso
            // 
            this.txtPercorso.Location = new System.Drawing.Point(7, 40);
            this.txtPercorso.Name = "txtPercorso";
            this.txtPercorso.ReadOnly = true;
            this.txtPercorso.Size = new System.Drawing.Size(523, 20);
            this.txtPercorso.TabIndex = 2;
            // 
            // lblIndividuazione
            // 
            this.lblIndividuazione.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblIndividuazione.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblIndividuazione.Location = new System.Drawing.Point(194, 9);
            this.lblIndividuazione.Name = "lblIndividuazione";
            this.lblIndividuazione.Size = new System.Drawing.Size(338, 23);
            this.lblIndividuazione.TabIndex = 1;
            this.lblIndividuazione.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnElabora
            // 
            this.btnElabora.Location = new System.Drawing.Point(7, 15);
            this.btnElabora.Name = "btnElabora";
            this.btnElabora.Size = new System.Drawing.Size(184, 23);
            this.btnElabora.TabIndex = 0;
            this.btnElabora.Text = "Elabora File F24EP";
            this.btnElabora.UseVisualStyleBackColor = true;
            this.btnElabora.Click += new System.EventHandler(this.btnElabora_Click);
            // 
            // txtEmail
            // 
            this.txtEmail.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEmail.Location = new System.Drawing.Point(288, 49);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.ReadOnly = true;
            this.txtEmail.Size = new System.Drawing.Size(246, 20);
            this.txtEmail.TabIndex = 4;
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Location = new System.Drawing.Point(250, 52);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(32, 13);
            this.label.TabIndex = 5;
            this.label.Text = "Email";
            // 
            // Frmf24ep
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(560, 332);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Name = "Frmf24ep";
            this.Text = "Frmf24EP";
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public vistaForm DS;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtInputFile;
        private System.Windows.Forms.Button btnFileInput;
        //string ConnectionString;
        string fileName;
        System.Data.DataTable mData = new System.Data.DataTable();
        System.Data.DataTable tributi = new System.Data.DataTable();
        //private System.Windows.Forms.OpenFileDialog MyOpenFile;
        //private System.Windows.Forms.ProgressBar progressBarImport;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.OpenFileDialog openInputFileDlg;
        private System.Windows.Forms.SaveFileDialog saveOutputFileDlg;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtContoDiAddebito;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtDataDiVersamento;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtDenominazione;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtCodiceFiscale;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox txtPercorso;
        private System.Windows.Forms.Label lblIndividuazione;
        private System.Windows.Forms.Button btnElabora;
        private System.Windows.Forms.TextBox txtDataGenerazione;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.TextBox txtEmail;
    }
}