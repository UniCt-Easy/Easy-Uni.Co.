
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


namespace admpay_spt {
    partial class FrmAdmPay_Spt {
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnFileReversali = new System.Windows.Forms.Button();
            this.btnFileContr = new System.Windows.Forms.Button();
            this.btnFileLordi = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.txtInputFile = new System.Windows.Forms.TextBox();
            this.btnInputFile = new System.Windows.Forms.Button();
            this.lblTask = new System.Windows.Forms.Label();
            this._openInputFileDlg = new System.Windows.Forms.OpenFileDialog();
            this.saveOutputFileDlg = new System.Windows.Forms.SaveFileDialog();
            this.DS = new admpay_spt.vistaForm();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnFileReversali);
            this.groupBox1.Controls.Add(this.btnFileContr);
            this.groupBox1.Controls.Add(this.btnFileLordi);
            this.groupBox1.Location = new System.Drawing.Point(11, 83);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(481, 54);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Formattazione dei file per";
            // 
            // btnFileReversali
            // 
            this.btnFileReversali.Location = new System.Drawing.Point(6, 19);
            this.btnFileReversali.Name = "btnFileReversali";
            this.btnFileReversali.Size = new System.Drawing.Size(121, 23);
            this.btnFileReversali.TabIndex = 7;
            this.btnFileReversali.Text = "Reversali";
            this.btnFileReversali.UseVisualStyleBackColor = true;
            this.btnFileReversali.Click += new System.EventHandler(this.btnFileReversali_Click);
            // 
            // btnFileContr
            // 
            this.btnFileContr.Location = new System.Drawing.Point(362, 19);
            this.btnFileContr.Name = "btnFileContr";
            this.btnFileContr.Size = new System.Drawing.Size(113, 23);
            this.btnFileContr.TabIndex = 8;
            this.btnFileContr.Text = "Versamenti";
            this.btnFileContr.UseVisualStyleBackColor = true;
            this.btnFileContr.Click += new System.EventHandler(this.btnFileContr_Click);
            // 
            // btnFileLordi
            // 
            this.btnFileLordi.Location = new System.Drawing.Point(191, 19);
            this.btnFileLordi.Name = "btnFileLordi";
            this.btnFileLordi.Size = new System.Drawing.Size(104, 23);
            this.btnFileLordi.TabIndex = 4;
            this.btnFileLordi.Text = "Lordi";
            this.btnFileLordi.Click += new System.EventHandler(this.btnFileLordi_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar1.Location = new System.Drawing.Point(5, 187);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(481, 23);
            this.progressBar1.TabIndex = 13;
            // 
            // txtInputFile
            // 
            this.txtInputFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtInputFile.Location = new System.Drawing.Point(99, 10);
            this.txtInputFile.Name = "txtInputFile";
            this.txtInputFile.ReadOnly = true;
            this.txtInputFile.Size = new System.Drawing.Size(393, 20);
            this.txtInputFile.TabIndex = 12;
            // 
            // btnInputFile
            // 
            this.btnInputFile.Location = new System.Drawing.Point(11, 10);
            this.btnInputFile.Name = "btnInputFile";
            this.btnInputFile.Size = new System.Drawing.Size(80, 23);
            this.btnInputFile.TabIndex = 11;
            this.btnInputFile.Text = "File di Input";
            this.btnInputFile.Click += new System.EventHandler(this.btnInputFile_Click);
            // 
            // lblTask
            // 
            this.lblTask.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTask.Location = new System.Drawing.Point(5, 155);
            this.lblTask.Name = "lblTask";
            this.lblTask.Size = new System.Drawing.Size(481, 23);
            this.lblTask.TabIndex = 16;
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.EnforceConstraints = false;
            // 
            // FrmAdmPay_Spt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(497, 220);
            this.Controls.Add(this.lblTask);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.txtInputFile);
            this.Controls.Add(this.btnInputFile);
            this.Name = "FrmAdmPay_Spt";
            this.Text = "FrmAdmPay_Spt";
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnFileReversali;
        private System.Windows.Forms.Button btnFileContr;
        private System.Windows.Forms.Button btnFileLordi;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.TextBox txtInputFile;
        private System.Windows.Forms.Button btnInputFile;
        private System.Windows.Forms.Label lblTask;
        public vistaForm DS;
        private System.Windows.Forms.OpenFileDialog _openInputFileDlg;
        private System.Windows.Forms.SaveFileDialog saveOutputFileDlg;
    }
}
