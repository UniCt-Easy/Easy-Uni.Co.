
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


namespace no_table_consolidclientiforn {
    partial class FrmConsolidamentoClientiFornitori {
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
            this.btnScegliCartella = new System.Windows.Forms.Button();
            this.txtCartella = new System.Windows.Forms.TextBox();
            this.DS = new no_table_consolidclientiforn.vistaForm();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.btnNomeFile = new System.Windows.Forms.Button();
            this.txtFile = new System.Windows.Forms.TextBox();
            this.btnConsolida = new System.Windows.Forms.Button();
            this.btnClienti = new System.Windows.Forms.Button();
            this.btnFornitori = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCFIntermediario = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.SuspendLayout();
            // 
            // btnScegliCartella
            // 
            this.btnScegliCartella.Location = new System.Drawing.Point(12, 12);
            this.btnScegliCartella.Name = "btnScegliCartella";
            this.btnScegliCartella.Size = new System.Drawing.Size(89, 23);
            this.btnScegliCartella.TabIndex = 0;
            this.btnScegliCartella.Text = "Scegli cartella";
            this.btnScegliCartella.UseVisualStyleBackColor = true;
            this.btnScegliCartella.Click += new System.EventHandler(this.btnScegliCartella_Click);
            // 
            // txtCartella
            // 
            this.txtCartella.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCartella.Location = new System.Drawing.Point(107, 15);
            this.txtCartella.Name = "txtCartella";
            this.txtCartella.ReadOnly = true;
            this.txtCartella.Size = new System.Drawing.Size(323, 20);
            this.txtCartella.TabIndex = 1;
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.EnforceConstraints = false;
            // 
            // btnNomeFile
            // 
            this.btnNomeFile.Location = new System.Drawing.Point(12, 41);
            this.btnNomeFile.Name = "btnNomeFile";
            this.btnNomeFile.Size = new System.Drawing.Size(89, 23);
            this.btnNomeFile.TabIndex = 2;
            this.btnNomeFile.Text = "File da creare";
            this.btnNomeFile.UseVisualStyleBackColor = true;
            this.btnNomeFile.Click += new System.EventHandler(this.btnNomeFile_Click);
            // 
            // txtFile
            // 
            this.txtFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFile.Location = new System.Drawing.Point(107, 41);
            this.txtFile.Name = "txtFile";
            this.txtFile.ReadOnly = true;
            this.txtFile.Size = new System.Drawing.Size(323, 20);
            this.txtFile.TabIndex = 3;
            // 
            // btnConsolida
            // 
            this.btnConsolida.AutoSize = true;
            this.btnConsolida.Location = new System.Drawing.Point(154, 194);
            this.btnConsolida.Name = "btnConsolida";
            this.btnConsolida.Size = new System.Drawing.Size(126, 40);
            this.btnConsolida.TabIndex = 4;
            this.btnConsolida.Text = "Consolida";
            this.btnConsolida.UseVisualStyleBackColor = true;
            this.btnConsolida.Click += new System.EventHandler(this.btnConsolida_Click);
            // 
            // btnClienti
            // 
            this.btnClienti.Enabled = false;
            this.btnClienti.Location = new System.Drawing.Point(54, 211);
            this.btnClienti.Name = "btnClienti";
            this.btnClienti.Size = new System.Drawing.Size(75, 23);
            this.btnClienti.TabIndex = 5;
            this.btnClienti.Text = "Clienti";
            this.btnClienti.UseVisualStyleBackColor = true;
            this.btnClienti.Click += new System.EventHandler(this.btnClienti_Click);
            // 
            // btnFornitori
            // 
            this.btnFornitori.Enabled = false;
            this.btnFornitori.Location = new System.Drawing.Point(304, 211);
            this.btnFornitori.Name = "btnFornitori";
            this.btnFornitori.Size = new System.Drawing.Size(75, 23);
            this.btnFornitori.TabIndex = 6;
            this.btnFornitori.Text = "Fornitori";
            this.btnFornitori.UseVisualStyleBackColor = true;
            this.btnFornitori.Click += new System.EventHandler(this.btnFornitori_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 86);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(138, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Codice fiscale intermediario:";
            // 
            // txtCFIntermediario
            // 
            this.txtCFIntermediario.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCFIntermediario.Location = new System.Drawing.Point(145, 83);
            this.txtCFIntermediario.Name = "txtCFIntermediario";
            this.txtCFIntermediario.Size = new System.Drawing.Size(285, 20);
            this.txtCFIntermediario.TabIndex = 8;
            // 
            // FrmConsolidamentoClientiFornitori
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(442, 266);
            this.Controls.Add(this.txtCFIntermediario);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnFornitori);
            this.Controls.Add(this.btnClienti);
            this.Controls.Add(this.btnConsolida);
            this.Controls.Add(this.txtFile);
            this.Controls.Add(this.btnNomeFile);
            this.Controls.Add(this.txtCartella);
            this.Controls.Add(this.btnScegliCartella);
            this.Name = "FrmConsolidamentoClientiFornitori";
            this.Text = "FrmConsolidamentoClientiFornitori";
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnScegliCartella;
        private System.Windows.Forms.TextBox txtCartella;
        public vistaForm DS;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button btnNomeFile;
        private System.Windows.Forms.TextBox txtFile;
        private System.Windows.Forms.Button btnConsolida;
        private System.Windows.Forms.Button btnClienti;
        private System.Windows.Forms.Button btnFornitori;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCFIntermediario;
    }
}
