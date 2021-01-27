
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


namespace bankdispositionsetup_siopeplus {
    partial class FrmErrori {
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
            this.txtErrori = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtErrori
            // 
            this.txtErrori.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtErrori.Location = new System.Drawing.Point(0, 0);
            this.txtErrori.Multiline = true;
            this.txtErrori.Name = "txtErrori";
            this.txtErrori.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtErrori.Size = new System.Drawing.Size(650, 451);
            this.txtErrori.TabIndex = 0;
            // 
            // FrmErrori
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(650, 451);
            this.Controls.Add(this.txtErrori);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "FrmErrori";
            this.Text = "Registro errori";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtErrori;
    }
}
