
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


namespace no_table_esterometro {
    partial class Frm_no_table_esterometro {
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
			this.DS = new no_table_esterometro.vistaForm();
			this.btnGenera = new System.Windows.Forms.Button();
			this.txtEsercizio = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.rdbV = new System.Windows.Forms.RadioButton();
			this.rdbA = new System.Windows.Forms.RadioButton();
			this.label5 = new System.Windows.Forms.Label();
			this.txtNomeFile = new System.Windows.Forms.TextBox();
			this.txtPercorso = new System.Windows.Forms.TextBox();
			this._folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
			this._saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.btnDocElaborati = new System.Windows.Forms.Button();
			this.cmbTrimestre = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.cmbMese = new System.Windows.Forms.ComboBox();
			this.label4 = new System.Windows.Forms.Label();
			this.saveFileDialog1 = createSaveFileDialog(_saveFileDialog1);
			this.folderBrowserDialog1 = createFolderBrowserDialog(_folderBrowserDialog1);
			((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// DS
			// 
			this.DS.DataSetName = "vistaForm";
			this.DS.EnforceConstraints = false;
			// 
			// btnGenera
			// 
			this.btnGenera.AutoSize = true;
			this.btnGenera.Location = new System.Drawing.Point(18, 149);
			this.btnGenera.Name = "btnGenera";
			this.btnGenera.Size = new System.Drawing.Size(117, 23);
			this.btnGenera.TabIndex = 71;
			this.btnGenera.Text = "Genera File";
			this.btnGenera.UseVisualStyleBackColor = true;
			this.btnGenera.Click += new System.EventHandler(this.btnGenera_Click);
			// 
			// txtEsercizio
			// 
			this.txtEsercizio.Location = new System.Drawing.Point(64, 30);
			this.txtEsercizio.Name = "txtEsercizio";
			this.txtEsercizio.Size = new System.Drawing.Size(65, 20);
			this.txtEsercizio.TabIndex = 70;
			this.txtEsercizio.Tag = "";
			this.txtEsercizio.Leave += new System.EventHandler(this.txtEsercizio_Leave);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(15, 33);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(49, 13);
			this.label2.TabIndex = 69;
			this.label2.Text = "Esercizio";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.rdbV);
			this.groupBox1.Controls.Add(this.rdbA);
			this.groupBox1.Location = new System.Drawing.Point(288, 12);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(107, 73);
			this.groupBox1.TabIndex = 74;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Tipo documento";
			// 
			// rdbV
			// 
			this.rdbV.AutoSize = true;
			this.rdbV.Location = new System.Drawing.Point(6, 44);
			this.rdbV.Name = "rdbV";
			this.rdbV.Size = new System.Drawing.Size(61, 17);
			this.rdbV.TabIndex = 1;
			this.rdbV.TabStop = true;
			this.rdbV.Text = "Vendita";
			this.rdbV.UseVisualStyleBackColor = true;
			// 
			// rdbA
			// 
			this.rdbA.AutoSize = true;
			this.rdbA.Checked = true;
			this.rdbA.Location = new System.Drawing.Point(6, 21);
			this.rdbA.Name = "rdbA";
			this.rdbA.Size = new System.Drawing.Size(66, 17);
			this.rdbA.TabIndex = 0;
			this.rdbA.TabStop = true;
			this.rdbA.Text = "Acquisto";
			this.rdbA.UseVisualStyleBackColor = true;
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(17, 204);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(124, 20);
			this.label5.TabIndex = 77;
			this.label5.Text = "Nome File Generato";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtNomeFile
			// 
			this.txtNomeFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtNomeFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtNomeFile.Location = new System.Drawing.Point(147, 204);
			this.txtNomeFile.Name = "txtNomeFile";
			this.txtNomeFile.ReadOnly = true;
			this.txtNomeFile.Size = new System.Drawing.Size(423, 20);
			this.txtNomeFile.TabIndex = 76;
			this.txtNomeFile.Tag = "";
			// 
			// txtPercorso
			// 
			this.txtPercorso.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtPercorso.Location = new System.Drawing.Point(147, 178);
			this.txtPercorso.Name = "txtPercorso";
			this.txtPercorso.ReadOnly = true;
			this.txtPercorso.Size = new System.Drawing.Size(423, 20);
			this.txtPercorso.TabIndex = 75;
			// 
			// saveFileDialog1
			// 
			//this.saveFileDialog1.DefaultExt = "xml";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.btnDocElaborati);
			this.groupBox2.Location = new System.Drawing.Point(413, 15);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(157, 70);
			this.groupBox2.TabIndex = 78;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Verifiche";
			// 
			// btnDocElaborati
			// 
			this.btnDocElaborati.Location = new System.Drawing.Point(10, 25);
			this.btnDocElaborati.Name = "btnDocElaborati";
			this.btnDocElaborati.Size = new System.Drawing.Size(139, 25);
			this.btnDocElaborati.TabIndex = 0;
			this.btnDocElaborati.Text = "Documenti elaborati";
			this.btnDocElaborati.UseVisualStyleBackColor = true;
			this.btnDocElaborati.Click += new System.EventHandler(this.btnDocElaborati_Click);
			// 
			// cmbTrimestre
			// 
			this.cmbTrimestre.DataSource = this.DS.trimestre;
			this.cmbTrimestre.DisplayMember = "descrizione";
			this.cmbTrimestre.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World, ((byte)(0)));
			this.cmbTrimestre.ItemHeight = 13;
			this.cmbTrimestre.Location = new System.Drawing.Point(64, 66);
			this.cmbTrimestre.Name = "cmbTrimestre";
			this.cmbTrimestre.Size = new System.Drawing.Size(216, 21);
			this.cmbTrimestre.TabIndex = 79;
			this.cmbTrimestre.ValueMember = "idtrimestre";
			this.cmbTrimestre.SelectionChangeCommitted += new System.EventHandler(this.cmbTrimestre_SelectionChangeCommitted);
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(7, 64);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(51, 23);
			this.label1.TabIndex = 80;
			this.label1.Text = "Trimestre";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label3
			// 
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World, ((byte)(0)));
			this.label3.Location = new System.Drawing.Point(7, 91);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(51, 23);
			this.label3.TabIndex = 81;
			this.label3.Text = "Mese";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// cmbMese
			// 
			this.cmbMese.DataSource = this.DS.mese;
			this.cmbMese.DisplayMember = "descrizione";
			this.cmbMese.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World, ((byte)(0)));
			this.cmbMese.ItemHeight = 13;
			this.cmbMese.Location = new System.Drawing.Point(64, 93);
			this.cmbMese.Name = "cmbMese";
			this.cmbMese.Size = new System.Drawing.Size(216, 21);
			this.cmbMese.TabIndex = 82;
			this.cmbMese.ValueMember = "idmese";
			this.cmbMese.SelectionChangeCommitted += new System.EventHandler(this.cmbMese_SelectionChangeCommitted);
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(17, 178);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(124, 20);
			this.label4.TabIndex = 83;
			this.label4.Text = "Percorso";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// Frm_no_table_esterometro
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(582, 420);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.cmbMese);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.cmbTrimestre);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.txtNomeFile);
			this.Controls.Add(this.txtPercorso);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.btnGenera);
			this.Controls.Add(this.txtEsercizio);
			this.Controls.Add(this.label2);
			this.Name = "Frm_no_table_esterometro";
			this.Text = "Frm_no_table_esterometro";
			((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnGenera;
        private System.Windows.Forms.TextBox txtEsercizio;
        private System.Windows.Forms.Label label2;
        public vistaForm DS;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdbV;
        private System.Windows.Forms.RadioButton rdbA;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtNomeFile;
        private System.Windows.Forms.TextBox txtPercorso;
        private System.Windows.Forms.FolderBrowserDialog _folderBrowserDialog1;
        private System.Windows.Forms.SaveFileDialog _saveFileDialog1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnDocElaborati;
		private System.Windows.Forms.ComboBox cmbTrimestre;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ComboBox cmbMese;
		private System.Windows.Forms.Label label4;
		private metadatalibrary.ISaveFileDialog saveFileDialog1;
		private metadatalibrary.IFolderBrowserDialog folderBrowserDialog1;
	}
}
