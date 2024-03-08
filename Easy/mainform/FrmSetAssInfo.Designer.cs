
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


namespace mainform {
    partial class FrmSetAssInfo {
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
            this.button1 = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.txtEasyFolder = new System.Windows.Forms.TextBox();
            this.btnSetFileInfo = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 28);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(153, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Scegli cartella";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // txtEasyFolder
            // 
            this.txtEasyFolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEasyFolder.Location = new System.Drawing.Point(191, 28);
            this.txtEasyFolder.Name = "txtEasyFolder";
            this.txtEasyFolder.Size = new System.Drawing.Size(620, 20);
            this.txtEasyFolder.TabIndex = 1;
            // 
            // btnSetFileInfo
            // 
            this.btnSetFileInfo.Location = new System.Drawing.Point(146, 89);
            this.btnSetFileInfo.Name = "btnSetFileInfo";
            this.btnSetFileInfo.Size = new System.Drawing.Size(153, 23);
            this.btnSetFileInfo.TabIndex = 2;
            this.btnSetFileInfo.Text = "Sistema gli ass.info";
            this.btnSetFileInfo.UseVisualStyleBackColor = true;
            this.btnSetFileInfo.Click += new System.EventHandler(this.btnSetFileInfo_Click);
            // 
            // FrmSetAssInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(823, 297);
            this.Controls.Add(this.btnSetFileInfo);
            this.Controls.Add(this.txtEasyFolder);
            this.Controls.Add(this.button1);
            this.Name = "FrmSetAssInfo";
            this.Text = "FrmSetAssInfo";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TextBox txtEasyFolder;
        private System.Windows.Forms.Button btnSetFileInfo;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
    }
}
