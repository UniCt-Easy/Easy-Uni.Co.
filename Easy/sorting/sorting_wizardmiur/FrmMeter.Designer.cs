
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


namespace sorting_wizardmiur {
    partial class FrmMeter {
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
            this.lblOpCorrente = new System.Windows.Forms.Label();
            this.pBar = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // lblOpCorrente
            // 
            this.lblOpCorrente.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblOpCorrente.Location = new System.Drawing.Point(4, 35);
            this.lblOpCorrente.Name = "lblOpCorrente";
            this.lblOpCorrente.Size = new System.Drawing.Size(528, 23);
            this.lblOpCorrente.TabIndex = 8;
            this.lblOpCorrente.Text = "Attendere prego...";
            // 
            // pBar
            // 
            this.pBar.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pBar.Location = new System.Drawing.Point(4, 3);
            this.pBar.Name = "pBar";
            this.pBar.Size = new System.Drawing.Size(528, 23);
            this.pBar.Step = 1;
            this.pBar.TabIndex = 7;
            // 
            // FrmMeter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(536, 61);
            this.Controls.Add(this.lblOpCorrente);
            this.Controls.Add(this.pBar);
            this.Name = "FrmMeter";
            this.Text = "Elaborazione in corso";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblOpCorrente;
        public System.Windows.Forms.ProgressBar pBar;
    }
}
