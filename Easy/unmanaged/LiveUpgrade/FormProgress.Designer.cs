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

﻿namespace LiveUpgrade {
    partial class FormProgress {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormProgress));
            this.labelUpgrade = new System.Windows.Forms.Label();
            this.progressUpgrade = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // labelUpgrade
            // 
            this.labelUpgrade.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelUpgrade.BackColor = System.Drawing.Color.Transparent;
            this.labelUpgrade.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelUpgrade.Location = new System.Drawing.Point(12, 9);
            this.labelUpgrade.Name = "labelUpgrade";
            this.labelUpgrade.Size = new System.Drawing.Size(600, 87);
            this.labelUpgrade.TabIndex = 0;
            this.labelUpgrade.Text = "Aggiornamento in corso...";
            this.labelUpgrade.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // progressUpgrade
            // 
            this.progressUpgrade.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressUpgrade.Location = new System.Drawing.Point(12, 99);
            this.progressUpgrade.Name = "progressUpgrade";
            this.progressUpgrade.Size = new System.Drawing.Size(600, 30);
            this.progressUpgrade.TabIndex = 1;
            // 
            // FormProgress
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 141);
            this.ControlBox = false;
            this.Controls.Add(this.progressUpgrade);
            this.Controls.Add(this.labelUpgrade);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormProgress";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Aggiornamento di Easy";
            this.TopMost = true;
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelUpgrade;
        private System.Windows.Forms.ProgressBar progressUpgrade;
    }
}