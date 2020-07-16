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

namespace assetacquire_export {
    partial class FrmAssetAcquire_Export {
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
            this.btnEsporta = new System.Windows.Forms.Button();
            this.saveFile = new System.Windows.Forms.SaveFileDialog();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.lblTabella = new System.Windows.Forms.Label();
            this.cmbEnte = new System.Windows.Forms.ComboBox();
            this.DS = new assetacquire_export.vistaForm();
            this.label3 = new System.Windows.Forms.Label();
            this.chkAnagrafica = new System.Windows.Forms.CheckBox();
            this.folderDlg = new System.Windows.Forms.FolderBrowserDialog();
            this.btnPath = new System.Windows.Forms.Button();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnEsporta
            // 
            this.btnEsporta.Location = new System.Drawing.Point(170, 95);
            this.btnEsporta.Name = "btnEsporta";
            this.btnEsporta.Size = new System.Drawing.Size(75, 23);
            this.btnEsporta.TabIndex = 2;
            this.btnEsporta.Text = "Esporta Dati";
            this.btnEsporta.Click += new System.EventHandler(this.btnEsporta_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(10, 188);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(416, 24);
            this.progressBar1.TabIndex = 4;
            // 
            // lblTabella
            // 
            this.lblTabella.Location = new System.Drawing.Point(10, 159);
            this.lblTabella.Name = "lblTabella";
            this.lblTabella.Size = new System.Drawing.Size(416, 23);
            this.lblTabella.TabIndex = 5;
            // 
            // cmbEnte
            // 
            this.cmbEnte.DataSource = this.DS.inventoryagency;
            this.cmbEnte.DisplayMember = "description";
            this.cmbEnte.Location = new System.Drawing.Point(8, 24);
            this.cmbEnte.Name = "cmbEnte";
            this.cmbEnte.Size = new System.Drawing.Size(416, 21);
            this.cmbEnte.TabIndex = 6;
            this.cmbEnte.ValueMember = "idinventoryagency";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(8, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 16);
            this.label3.TabIndex = 7;
            this.label3.Text = "Ente Inventario:";
            // 
            // chkAnagrafica
            // 
            this.chkAnagrafica.Checked = true;
            this.chkAnagrafica.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAnagrafica.Location = new System.Drawing.Point(11, 136);
            this.chkAnagrafica.Name = "chkAnagrafica";
            this.chkAnagrafica.Size = new System.Drawing.Size(408, 24);
            this.chkAnagrafica.TabIndex = 8;
            this.chkAnagrafica.Text = "Esporta Anagrafica (Si per i Dipartimenti, No per l\'Amministrazione Centrale)";
            // 
            // btnPath
            // 
            this.btnPath.Location = new System.Drawing.Point(12, 67);
            this.btnPath.Name = "btnPath";
            this.btnPath.Size = new System.Drawing.Size(104, 23);
            this.btnPath.TabIndex = 9;
            this.btnPath.Text = "Scegli Cartella";
            this.btnPath.UseVisualStyleBackColor = true;
            this.btnPath.Click += new System.EventHandler(this.btnPath_Click);
            // 
            // txtPath
            // 
            this.txtPath.Location = new System.Drawing.Point(122, 69);
            this.txtPath.Name = "txtPath";
            this.txtPath.ReadOnly = true;
            this.txtPath.Size = new System.Drawing.Size(302, 20);
            this.txtPath.TabIndex = 10;
            // 
            // FrmAssetAcquire_Export
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(432, 224);
            this.Controls.Add(this.txtPath);
            this.Controls.Add(this.btnPath);
            this.Controls.Add(this.chkAnagrafica);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbEnte);
            this.Controls.Add(this.lblTabella);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.btnEsporta);
            this.Name = "FrmAssetAcquire_Export";
            this.Text = "FrmAssetAcquire_Export";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnEsporta;
        private System.Windows.Forms.SaveFileDialog saveFile;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label lblTabella;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbEnte;
        private System.Windows.Forms.CheckBox chkAnagrafica;
        public vistaForm DS;
        private System.Windows.Forms.FolderBrowserDialog folderDlg;
        private System.Windows.Forms.Button btnPath;
        private System.Windows.Forms.TextBox txtPath;
    }
}