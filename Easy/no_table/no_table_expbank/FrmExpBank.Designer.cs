
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


namespace no_table_expbank {
    partial class FrmExpBank {
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
            this.lblDa = new System.Windows.Forms.Label();
            this.txtDa = new System.Windows.Forms.TextBox();
            this.lblA = new System.Windows.Forms.Label();
            this.txtA = new System.Windows.Forms.TextBox();
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.btnGeneraFileMandati = new System.Windows.Forms.Button();
            this.txtCartella = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.DS = new no_table_expbank.vistaForm();
            this.btnPercorso = new System.Windows.Forms.Button();
            this.cmbIstitutoCassiere = new System.Windows.Forms.ComboBox();
            this.btnIstitutoCassiere = new System.Windows.Forms.Button();
            this.btnGeneraFileReversali = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.labelUltimoFileSalvato = new System.Windows.Forms.Label();
            this.txtFile = new System.Windows.Forms.TextBox();
            this.btnGeneraUltimaDistMandati = new System.Windows.Forms.Button();
            this.btnGeneraUltimaDistReversali = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.SuspendLayout();
            // 
            // lblDa
            // 
            this.lblDa.AutoSize = true;
            this.lblDa.Location = new System.Drawing.Point(10, 22);
            this.lblDa.Name = "lblDa";
            this.lblDa.Size = new System.Drawing.Size(21, 13);
            this.lblDa.TabIndex = 0;
            this.lblDa.Text = "Da";
            // 
            // txtDa
            // 
            this.txtDa.Location = new System.Drawing.Point(37, 19);
            this.txtDa.Name = "txtDa";
            this.txtDa.Size = new System.Drawing.Size(100, 20);
            this.txtDa.TabIndex = 1;
            this.txtDa.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblA
            // 
            this.lblA.AutoSize = true;
            this.lblA.Location = new System.Drawing.Point(151, 22);
            this.lblA.Name = "lblA";
            this.lblA.Size = new System.Drawing.Size(14, 13);
            this.lblA.TabIndex = 2;
            this.lblA.Text = "A";
            // 
            // txtA
            // 
            this.txtA.Location = new System.Drawing.Point(171, 19);
            this.txtA.Name = "txtA";
            this.txtA.Size = new System.Drawing.Size(100, 20);
            this.txtA.TabIndex = 3;
            this.txtA.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // dataGrid1
            // 
            this.dataGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGrid1.DataMember = "";
            this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid1.Location = new System.Drawing.Point(15, 229);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.Size = new System.Drawing.Size(539, 241);
            this.dataGrid1.TabIndex = 4;
            // 
            // btnGeneraFileMandati
            // 
            this.btnGeneraFileMandati.AutoSize = true;
            this.btnGeneraFileMandati.Location = new System.Drawing.Point(15, 164);
            this.btnGeneraFileMandati.Name = "btnGeneraFileMandati";
            this.btnGeneraFileMandati.Size = new System.Drawing.Size(268, 23);
            this.btnGeneraFileMandati.TabIndex = 5;
            this.btnGeneraFileMandati.Text = "Genera il file della trasmissione MANDATI";
            this.btnGeneraFileMandati.UseVisualStyleBackColor = true;
            this.btnGeneraFileMandati.Click += new System.EventHandler(this.btnGeneraFile_Click);
            // 
            // txtCartella
            // 
            this.txtCartella.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCartella.Location = new System.Drawing.Point(107, 47);
            this.txtCartella.Name = "txtCartella";
            this.txtCartella.ReadOnly = true;
            this.txtCartella.Size = new System.Drawing.Size(440, 20);
            this.txtCartella.TabIndex = 6;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtDa);
            this.groupBox1.Controls.Add(this.lblDa);
            this.groupBox1.Controls.Add(this.lblA);
            this.groupBox1.Controls.Add(this.txtA);
            this.groupBox1.Location = new System.Drawing.Point(12, 105);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(282, 49);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Distinta di trasmissione";
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.EnforceConstraints = false;
            // 
            // btnPercorso
            // 
            this.btnPercorso.AutoSize = true;
            this.btnPercorso.Location = new System.Drawing.Point(8, 45);
            this.btnPercorso.Name = "btnPercorso";
            this.btnPercorso.Size = new System.Drawing.Size(92, 23);
            this.btnPercorso.TabIndex = 9;
            this.btnPercorso.Text = "Cartella";
            this.btnPercorso.UseVisualStyleBackColor = true;
            this.btnPercorso.Click += new System.EventHandler(this.btnPercorso_Click);
            // 
            // cmbIstitutoCassiere
            // 
            this.cmbIstitutoCassiere.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbIstitutoCassiere.DataSource = this.DS.treasurer;
            this.cmbIstitutoCassiere.DisplayMember = "description";
            this.cmbIstitutoCassiere.FormattingEnabled = true;
            this.cmbIstitutoCassiere.Location = new System.Drawing.Point(107, 11);
            this.cmbIstitutoCassiere.Name = "cmbIstitutoCassiere";
            this.cmbIstitutoCassiere.Size = new System.Drawing.Size(441, 21);
            this.cmbIstitutoCassiere.TabIndex = 10;
            this.cmbIstitutoCassiere.Tag = "treasurer.idtreasurer";
            this.cmbIstitutoCassiere.ValueMember = "idtreasurer";
            // 
            // btnIstitutoCassiere
            // 
            this.btnIstitutoCassiere.AutoSize = true;
            this.btnIstitutoCassiere.Location = new System.Drawing.Point(10, 9);
            this.btnIstitutoCassiere.Name = "btnIstitutoCassiere";
            this.btnIstitutoCassiere.Size = new System.Drawing.Size(90, 23);
            this.btnIstitutoCassiere.TabIndex = 11;
            this.btnIstitutoCassiere.Tag = "choose.treasurer.lista";
            this.btnIstitutoCassiere.Text = "Istituto cassiere";
            this.btnIstitutoCassiere.UseVisualStyleBackColor = true;
            // 
            // btnGeneraFileReversali
            // 
            this.btnGeneraFileReversali.AutoSize = true;
            this.btnGeneraFileReversali.Location = new System.Drawing.Point(293, 165);
            this.btnGeneraFileReversali.Name = "btnGeneraFileReversali";
            this.btnGeneraFileReversali.Size = new System.Drawing.Size(244, 23);
            this.btnGeneraFileReversali.TabIndex = 12;
            this.btnGeneraFileReversali.Text = "Genera il file della trasmissione REVERSALI";
            this.btnGeneraFileReversali.UseVisualStyleBackColor = true;
            this.btnGeneraFileReversali.Click += new System.EventHandler(this.btnGeneraFileReversali_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 229);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Elenco messaggi";
            // 
            // labelUltimoFileSalvato
            // 
            this.labelUltimoFileSalvato.AutoSize = true;
            this.labelUltimoFileSalvato.Location = new System.Drawing.Point(7, 78);
            this.labelUltimoFileSalvato.Name = "labelUltimoFileSalvato";
            this.labelUltimoFileSalvato.Size = new System.Drawing.Size(89, 13);
            this.labelUltimoFileSalvato.TabIndex = 14;
            this.labelUltimoFileSalvato.Text = "Ultimo file salvato";
            // 
            // txtFile
            // 
            this.txtFile.Location = new System.Drawing.Point(108, 73);
            this.txtFile.Name = "txtFile";
            this.txtFile.ReadOnly = true;
            this.txtFile.Size = new System.Drawing.Size(440, 20);
            this.txtFile.TabIndex = 15;
            // 
            // btnGeneraUltimaDistMandati
            // 
            this.btnGeneraUltimaDistMandati.Location = new System.Drawing.Point(15, 193);
            this.btnGeneraUltimaDistMandati.Name = "btnGeneraUltimaDistMandati";
            this.btnGeneraUltimaDistMandati.Size = new System.Drawing.Size(268, 23);
            this.btnGeneraUltimaDistMandati.TabIndex = 16;
            this.btnGeneraUltimaDistMandati.Text = "Genera il file per l\'ultima distinta di PAGAMENTO";
            this.btnGeneraUltimaDistMandati.UseVisualStyleBackColor = true;
            this.btnGeneraUltimaDistMandati.Click += new System.EventHandler(this.btnGeneraUltimaDistMandati_Click);
            // 
            // btnGeneraUltimaDistReversali
            // 
            this.btnGeneraUltimaDistReversali.Location = new System.Drawing.Point(293, 194);
            this.btnGeneraUltimaDistReversali.Name = "btnGeneraUltimaDistReversali";
            this.btnGeneraUltimaDistReversali.Size = new System.Drawing.Size(244, 22);
            this.btnGeneraUltimaDistReversali.TabIndex = 17;
            this.btnGeneraUltimaDistReversali.Text = "Genera il file per l\'ultima distinta di INCASSO";
            this.btnGeneraUltimaDistReversali.UseVisualStyleBackColor = true;
            this.btnGeneraUltimaDistReversali.Click += new System.EventHandler(this.btnGeneraUltimaDistReversali_Click);
            // 
            // FrmExpBank
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(560, 473);
            this.Controls.Add(this.btnGeneraUltimaDistReversali);
            this.Controls.Add(this.btnGeneraUltimaDistMandati);
            this.Controls.Add(this.dataGrid1);
            this.Controls.Add(this.txtFile);
            this.Controls.Add(this.labelUltimoFileSalvato);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnGeneraFileReversali);
            this.Controls.Add(this.btnIstitutoCassiere);
            this.Controls.Add(this.cmbIstitutoCassiere);
            this.Controls.Add(this.btnPercorso);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtCartella);
            this.Controls.Add(this.btnGeneraFileMandati);
            this.Name = "FrmExpBank";
            this.Text = "FrmExpBank";
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDa;
        private System.Windows.Forms.TextBox txtDa;
        private System.Windows.Forms.Label lblA;
        private System.Windows.Forms.TextBox txtA;
        private System.Windows.Forms.DataGrid dataGrid1;
        private System.Windows.Forms.Button btnGeneraFileMandati;
        private System.Windows.Forms.TextBox txtCartella;
        private System.Windows.Forms.GroupBox groupBox1;
        public vistaForm DS;
        private System.Windows.Forms.Button btnPercorso;
        private System.Windows.Forms.ComboBox cmbIstitutoCassiere;
        private System.Windows.Forms.Button btnIstitutoCassiere;
        private System.Windows.Forms.Button btnGeneraFileReversali;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Label labelUltimoFileSalvato;
        private System.Windows.Forms.TextBox txtFile;
        private System.Windows.Forms.Button btnGeneraUltimaDistMandati;
        private System.Windows.Forms.Button btnGeneraUltimaDistReversali;
    }
}
