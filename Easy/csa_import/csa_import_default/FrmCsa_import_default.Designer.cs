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

ï»¿namespace csa_import_default {
    partial class FrmCsa_import_default {
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.btnImportaRiepiloghi = new System.Windows.Forms.Button();
            this.btnImportaVersamenti = new System.Windows.Forms.Button();
            this.btnEffettuaCalcoli = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 43);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(84, 20);
            this.textBox1.TabIndex = 0;
            this.textBox1.Tag = "csa_import.yimport.ayear";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Esercizio";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(116, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Numero";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(116, 43);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(84, 20);
            this.textBox2.TabIndex = 2;
            this.textBox2.Tag = "csa_import.nimport";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(251, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Data";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(251, 43);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(84, 20);
            this.textBox3.TabIndex = 4;
            this.textBox3.Tag = "csa_import.adate";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 74);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Descrizione";
            // 
            // textBox4
            // 
            this.textBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox4.Location = new System.Drawing.Point(12, 90);
            this.textBox4.Multiline = true;
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(736, 81);
            this.textBox4.TabIndex = 6;
            this.textBox4.Tag = "csa_import.yimport.ayear";
            // 
            // btnImportaRiepiloghi
            // 
            this.btnImportaRiepiloghi.Location = new System.Drawing.Point(15, 188);
            this.btnImportaRiepiloghi.Name = "btnImportaRiepiloghi";
            this.btnImportaRiepiloghi.Size = new System.Drawing.Size(118, 23);
            this.btnImportaRiepiloghi.TabIndex = 8;
            this.btnImportaRiepiloghi.Text = "Importa Riepiloghi";
            this.btnImportaRiepiloghi.UseVisualStyleBackColor = true;
            // 
            // btnImportaVersamenti
            // 
            this.btnImportaVersamenti.Location = new System.Drawing.Point(151, 188);
            this.btnImportaVersamenti.Name = "btnImportaVersamenti";
            this.btnImportaVersamenti.Size = new System.Drawing.Size(118, 23);
            this.btnImportaVersamenti.TabIndex = 9;
            this.btnImportaVersamenti.Text = "Importa Versamenti";
            this.btnImportaVersamenti.UseVisualStyleBackColor = true;
            // 
            // btnEffettuaCalcoli
            // 
            this.btnEffettuaCalcoli.Location = new System.Drawing.Point(353, 188);
            this.btnEffettuaCalcoli.Name = "btnEffettuaCalcoli";
            this.btnEffettuaCalcoli.Size = new System.Drawing.Size(118, 23);
            this.btnEffettuaCalcoli.TabIndex = 10;
            this.btnEffettuaCalcoli.Text = "Effettua calcoli";
            this.btnEffettuaCalcoli.UseVisualStyleBackColor = true;
            // 
            // FrmCsa_import_default
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(772, 548);
            this.Controls.Add(this.btnEffettuaCalcoli);
            this.Controls.Add(this.btnImportaVersamenti);
            this.Controls.Add(this.btnImportaRiepiloghi);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Name = "FrmCsa_import_default";
            this.Text = "FrmCsa_import_default";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Button btnImportaRiepiloghi;
        private System.Windows.Forms.Button btnImportaVersamenti;
        private System.Windows.Forms.Button btnEffettuaCalcoli;
    }
}