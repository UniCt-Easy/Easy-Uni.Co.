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

namespace mandateattachment_web {
    partial class FrmMandateattachment_web {
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
            this.btnVisualizza = new System.Windows.Forms.Button();
            this.btnAllega = new System.Windows.Forms.Button();
            this.labAutocertFileName = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnVisualizza
            // 
            this.btnVisualizza.Location = new System.Drawing.Point(132, 71);
            this.btnVisualizza.Name = "btnVisualizza";
            this.btnVisualizza.Size = new System.Drawing.Size(79, 24);
            this.btnVisualizza.TabIndex = 5;
            this.btnVisualizza.Text = "Scarica";
            this.btnVisualizza.UseVisualStyleBackColor = true;
            // 
            // btnAllega
            // 
            this.btnAllega.Location = new System.Drawing.Point(12, 71);
            this.btnAllega.Name = "btnAllega";
            this.btnAllega.Size = new System.Drawing.Size(79, 24);
            this.btnAllega.TabIndex = 3;
            this.btnAllega.Text = "Allega";
            this.btnAllega.UseVisualStyleBackColor = true;
            // 
            // labAutocertFileName
            // 
            this.labAutocertFileName.Location = new System.Drawing.Point(15, 25);
            this.labAutocertFileName.Name = "labAutocertFileName";
            this.labAutocertFileName.Size = new System.Drawing.Size(505, 16);
            this.labAutocertFileName.TabIndex = 75;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.labAutocertFileName);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(536, 53);
            this.groupBox1.TabIndex = 78;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "File allegato";
            // 
            // FrmMandateattachment_web
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(571, 122);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnVisualizza);
            this.Controls.Add(this.btnAllega);
            this.Name = "FrmMandateattachment_web";
            this.Text = "FrmMandateattachment_web";
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnVisualizza;
        private System.Windows.Forms.Button btnAllega;
        private System.Windows.Forms.Label labAutocertFileName;
        private System.Windows.Forms.GroupBox groupBox1;

    }
}