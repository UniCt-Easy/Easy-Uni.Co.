/*
    Easy
    Copyright (C) 2020 Università degli Studi di Catania (www.unict.it)
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

namespace no_table_elencoclientiforn {
    partial class FrmElencoClientiFornitori {
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
            this.btnScegliFile = new System.Windows.Forms.Button();
            this.txtFile = new System.Windows.Forms.TextBox();
            this.btnScriviElenco = new System.Windows.Forms.Button();
            this.btnClienti = new System.Windows.Forms.Button();
            this.btnFornitori = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.DS = new no_table_elencoclientiforn.vistaForm();
            this.btnCheck = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.SuspendLayout();
            // 
            // btnScegliFile
            // 
            this.btnScegliFile.AutoSize = true;
            this.btnScegliFile.Location = new System.Drawing.Point(12, 12);
            this.btnScegliFile.Name = "btnScegliFile";
            this.btnScegliFile.Size = new System.Drawing.Size(81, 23);
            this.btnScegliFile.TabIndex = 0;
            this.btnScegliFile.Text = "File da creare";
            this.btnScegliFile.UseVisualStyleBackColor = true;
            this.btnScegliFile.Click += new System.EventHandler(this.btnScegliFile_Click);
            // 
            // txtFile
            // 
            this.txtFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFile.Location = new System.Drawing.Point(99, 14);
            this.txtFile.Name = "txtFile";
            this.txtFile.ReadOnly = true;
            this.txtFile.Size = new System.Drawing.Size(338, 20);
            this.txtFile.TabIndex = 1;
            // 
            // btnScriviElenco
            // 
            this.btnScriviElenco.AutoSize = true;
            this.btnScriviElenco.Location = new System.Drawing.Point(267, 99);
            this.btnScriviElenco.Name = "btnScriviElenco";
            this.btnScriviElenco.Size = new System.Drawing.Size(160, 35);
            this.btnScriviElenco.TabIndex = 2;
            this.btnScriviElenco.Text = "Genera l\'elenco clienti/fornitori";
            this.btnScriviElenco.UseVisualStyleBackColor = true;
            this.btnScriviElenco.Click += new System.EventHandler(this.btnScriviElenco_Click);
            // 
            // btnClienti
            // 
            this.btnClienti.AutoSize = true;
            this.btnClienti.Location = new System.Drawing.Point(22, 207);
            this.btnClienti.Name = "btnClienti";
            this.btnClienti.Size = new System.Drawing.Size(129, 23);
            this.btnClienti.TabIndex = 3;
            this.btnClienti.Text = "Esporta Clienti (in excel)";
            this.btnClienti.UseVisualStyleBackColor = true;
            this.btnClienti.Click += new System.EventHandler(this.btnClienti_Click);
            // 
            // btnFornitori
            // 
            this.btnFornitori.AutoSize = true;
            this.btnFornitori.Location = new System.Drawing.Point(267, 207);
            this.btnFornitori.Name = "btnFornitori";
            this.btnFornitori.Size = new System.Drawing.Size(160, 23);
            this.btnFornitori.TabIndex = 4;
            this.btnFornitori.Text = "Esporta Fornitori (in excel)";
            this.btnFornitori.UseVisualStyleBackColor = true;
            this.btnFornitori.Click += new System.EventHandler(this.btnFornitori_Click);
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.EnforceConstraints = false;
            // 
            // btnCheck
            // 
            this.btnCheck.AutoSize = true;
            this.btnCheck.Location = new System.Drawing.Point(22, 99);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(128, 35);
            this.btnCheck.TabIndex = 5;
            this.btnCheck.Text = "Effettua verifiche sul db";
            this.btnCheck.UseVisualStyleBackColor = true;
            this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
            // 
            // FrmElencoClientiFornitori
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(449, 263);
            this.Controls.Add(this.btnCheck);
            this.Controls.Add(this.btnFornitori);
            this.Controls.Add(this.btnClienti);
            this.Controls.Add(this.btnScriviElenco);
            this.Controls.Add(this.txtFile);
            this.Controls.Add(this.btnScegliFile);
            this.Name = "FrmElencoClientiFornitori";
            this.Text = "FrmElencoClientiFornitori";
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnScegliFile;
        private System.Windows.Forms.TextBox txtFile;
        private System.Windows.Forms.Button btnScriviElenco;
        private System.Windows.Forms.Button btnClienti;
        private System.Windows.Forms.Button btnFornitori;
        public vistaForm DS;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button btnCheck;
    }
}