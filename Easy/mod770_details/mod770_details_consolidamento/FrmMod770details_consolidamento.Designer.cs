
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


namespace mod770_details_consolidamento {
    partial class FrmMod770details_consolidamento {
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
            this._folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.btnScegliCartella = new System.Windows.Forms.Button();
            this.txtCartella = new System.Windows.Forms.TextBox();
            this.btnConsolida = new System.Windows.Forms.Button();
            this.DS = new mod770_details_consolidamento.vistaForm();
            this._saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.txtFile770 = new System.Windows.Forms.TextBox();
            this.btnFile = new System.Windows.Forms.Button();
            this.saveFileDialog1 = createSaveFileDialog(_saveFileDialog1);
            this.folderBrowserDialog1 = createFolderBrowserDialog(_folderBrowserDialog1);
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.SuspendLayout();
            // 
            // btnScegliCartella
            // 
            this.btnScegliCartella.Location = new System.Drawing.Point(12, 12);
            this.btnScegliCartella.Name = "btnScegliCartella";
            this.btnScegliCartella.Size = new System.Drawing.Size(88, 23);
            this.btnScegliCartella.TabIndex = 0;
            this.btnScegliCartella.Text = "Scegli cartella";
            this.btnScegliCartella.UseVisualStyleBackColor = true;
            this.btnScegliCartella.Click += new System.EventHandler(this.btnScegliCartella_Click);
            // 
            // txtCartella
            // 
            this.txtCartella.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCartella.Location = new System.Drawing.Point(106, 14);
            this.txtCartella.Name = "txtCartella";
            this.txtCartella.ReadOnly = true;
            this.txtCartella.Size = new System.Drawing.Size(451, 20);
            this.txtCartella.TabIndex = 1;
            // 
            // btnConsolida
            // 
            this.btnConsolida.Location = new System.Drawing.Point(237, 155);
            this.btnConsolida.Name = "btnConsolida";
            this.btnConsolida.Size = new System.Drawing.Size(79, 31);
            this.btnConsolida.TabIndex = 2;
            this.btnConsolida.Text = "Consolida";
            this.btnConsolida.UseVisualStyleBackColor = true;
            this.btnConsolida.Click += new System.EventHandler(this.btnConsolida_Click);
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.EnforceConstraints = false;
            // 
            // saveFileDialog1
            // 
            //this.saveFileDialog1.DefaultExt = "77s";
            // 
            // txtFile770
            // 
            this.txtFile770.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFile770.Location = new System.Drawing.Point(106, 60);
            this.txtFile770.Name = "txtFile770";
            this.txtFile770.ReadOnly = true;
            this.txtFile770.Size = new System.Drawing.Size(451, 20);
            this.txtFile770.TabIndex = 3;
            // 
            // btnFile
            // 
            this.btnFile.AutoSize = true;
            this.btnFile.Location = new System.Drawing.Point(12, 57);
            this.btnFile.Name = "btnFile";
            this.btnFile.Size = new System.Drawing.Size(90, 23);
            this.btnFile.TabIndex = 4;
            this.btnFile.Text = "File consolidato";
            this.btnFile.UseVisualStyleBackColor = true;
            this.btnFile.Click += new System.EventHandler(this.btnFile_Click);
            // 
            // FrmMod770details_consolidamento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(569, 266);
            this.Controls.Add(this.btnFile);
            this.Controls.Add(this.txtFile770);
            this.Controls.Add(this.btnConsolida);
            this.Controls.Add(this.txtCartella);
            this.Controls.Add(this.btnScegliCartella);
            this.Name = "FrmMod770details_consolidamento";
            this.Text = "FrmMod770details_consolidamento";
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FolderBrowserDialog _folderBrowserDialog1;
        private System.Windows.Forms.Button btnScegliCartella;
        private System.Windows.Forms.TextBox txtCartella;
        private System.Windows.Forms.Button btnConsolida;
        public vistaForm DS;
        private System.Windows.Forms.SaveFileDialog _saveFileDialog1;
        private System.Windows.Forms.TextBox txtFile770;
        private System.Windows.Forms.Button btnFile;
        private metadatalibrary.ISaveFileDialog saveFileDialog1;
        private metadatalibrary.IFolderBrowserDialog folderBrowserDialog1;
    }
}
