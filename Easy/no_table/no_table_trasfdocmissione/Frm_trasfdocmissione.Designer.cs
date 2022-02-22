
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


namespace no_table_trasfdocmissione {
    partial class Frm_trasfdocmissione {
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
            this.DS = new no_table_trasfdocmissione.vistaForm();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnAnnulla = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtNumFine = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNumInizio = new System.Windows.Forms.TextBox();
            this.labelEsercizio = new System.Windows.Forms.Label();
            this.btnEseguidownload = new System.Windows.Forms.Button();
            this.txtFolder = new System.Windows.Forms.TextBox();
            this.btnSelezionaFolder = new System.Windows.Forms.Button();
            this.folderDlg = new System.Windows.Forms.FolderBrowserDialog();
            this.txtEsercizioMissione = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(438, 54);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.Location = new System.Drawing.Point(22, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(404, 29);
            this.label2.TabIndex = 2;
            this.label2.Text = "La procedura il download in una unica cartella, di tutti i documenti informatici " +
    "associati alla missione e della relativa nota spese";
            // 
            // btnAnnulla
            // 
            this.btnAnnulla.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAnnulla.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnAnnulla.Location = new System.Drawing.Point(402, 266);
            this.btnAnnulla.Name = "btnAnnulla";
            this.btnAnnulla.Size = new System.Drawing.Size(75, 23);
            this.btnAnnulla.TabIndex = 12;
            this.btnAnnulla.Text = "Annulla";
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(292, 266);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 11;
            this.btnOK.Tag = "";
            this.btnOK.Text = "OK";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.txtEsercizioMissione);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtFolder);
            this.groupBox1.Controls.Add(this.btnSelezionaFolder);
            this.groupBox1.Controls.Add(this.txtNumFine);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtNumInizio);
            this.groupBox1.Controls.Add(this.labelEsercizio);
            this.groupBox1.Controls.Add(this.btnEseguidownload);
            this.groupBox1.Location = new System.Drawing.Point(12, 72);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(465, 174);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            // 
            // txtNumFine
            // 
            this.txtNumFine.BackColor = System.Drawing.SystemColors.Window;
            this.txtNumFine.Enabled = true;
            this.txtNumFine.Location = new System.Drawing.Point(280, 31);
            this.txtNumFine.Name = "txtNumFine";
            this.txtNumFine.Size = new System.Drawing.Size(72, 20);
            this.txtNumFine.TabIndex = 9;
            this.txtNumFine.Tag = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(277, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Num. missione fine";
            // 
            // txtNumInizio
            // 
            this.txtNumInizio.BackColor = System.Drawing.SystemColors.Window;
            this.txtNumInizio.Enabled = true;
            this.txtNumInizio.Location = new System.Drawing.Point(150, 31);
            this.txtNumInizio.Name = "txtNumInizio";
            this.txtNumInizio.Size = new System.Drawing.Size(72, 20);
            this.txtNumInizio.TabIndex = 7;
            this.txtNumInizio.Tag = "";
            // 
            // labelEsercizio
            // 
            this.labelEsercizio.AutoSize = true;
            this.labelEsercizio.Location = new System.Drawing.Point(147, 15);
            this.labelEsercizio.Name = "labelEsercizio";
            this.labelEsercizio.Size = new System.Drawing.Size(101, 13);
            this.labelEsercizio.TabIndex = 6;
            this.labelEsercizio.Text = "Num. missione inizio";
            // 
            // btnEseguidownload
            // 
            this.btnEseguidownload.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEseguidownload.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnEseguidownload.Location = new System.Drawing.Point(291, 138);
            this.btnEseguidownload.Name = "btnEseguidownload";
            this.btnEseguidownload.Size = new System.Drawing.Size(162, 30);
            this.btnEseguidownload.TabIndex = 1;
            this.btnEseguidownload.Text = "Esegui download";
            this.btnEseguidownload.UseVisualStyleBackColor = true;
            this.btnEseguidownload.Click += new System.EventHandler(this.btnEseguidownload_Click);
            // 
            // txtFolder
            // 
            this.txtFolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFolder.Location = new System.Drawing.Point(6, 102);
            this.txtFolder.Name = "txtFolder";
            this.txtFolder.Size = new System.Drawing.Size(447, 20);
            this.txtFolder.TabIndex = 17;
            // 
            // btnSelezionaFolder
            // 
            this.btnSelezionaFolder.Location = new System.Drawing.Point(6, 73);
            this.btnSelezionaFolder.Name = "btnSelezionaFolder";
            this.btnSelezionaFolder.Size = new System.Drawing.Size(134, 23);
            this.btnSelezionaFolder.TabIndex = 16;
            this.btnSelezionaFolder.Text = "Seleziona cartella";
            this.btnSelezionaFolder.UseVisualStyleBackColor = true;
            this.btnSelezionaFolder.Click += new System.EventHandler(this.btnSelezionaFolder_Click);
            // 
            // txtEsercizioMissione
            // 
            this.txtEsercizioMissione.BackColor = System.Drawing.SystemColors.Window;
            this.txtEsercizioMissione.Enabled = true;
            this.txtEsercizioMissione.Location = new System.Drawing.Point(9, 31);
            this.txtEsercizioMissione.Name = "txtEsercizioMissione";
            this.txtEsercizioMissione.Size = new System.Drawing.Size(72, 20);
            this.txtEsercizioMissione.TabIndex = 19;
            this.txtEsercizioMissione.Tag = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 13);
            this.label3.TabIndex = 18;
            this.label3.Text = "Esercizio missione";
            // 
            // Frm_trasfdocmissione
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(489, 292);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnAnnulla);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.groupBox1);
            this.Name = "Frm_trasfdocmissione";
            this.Text = "Frm_trasfdocmissione";
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnAnnulla;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtNumFine;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNumInizio;
        private System.Windows.Forms.Label labelEsercizio;
        private System.Windows.Forms.Button btnEseguidownload;
        private System.Windows.Forms.TextBox txtFolder;
        private System.Windows.Forms.Button btnSelezionaFolder;
        private System.Windows.Forms.FolderBrowserDialog folderDlg;
        public vistaForm DS;
        private System.Windows.Forms.TextBox txtEsercizioMissione;
        private System.Windows.Forms.Label label3;
    }
}
