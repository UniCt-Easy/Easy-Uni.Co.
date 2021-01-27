
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


namespace finvarkind_default {
    partial class Frm_finvarkind_default {
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
            this.DS = new finvarkind_default.vistaForm();
            this.txtCodice = new System.Windows.Forms.TextBox();
            this.textBox24 = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.SuspendLayout();
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.EnforceConstraints = false;
            // 
            // txtCodice
            // 
            this.txtCodice.Location = new System.Drawing.Point(85, 26);
            this.txtCodice.Name = "txtCodice";
            this.txtCodice.Size = new System.Drawing.Size(231, 20);
            this.txtCodice.TabIndex = 68;
            this.txtCodice.Tag = "finvarkind.codevarkind";
            // 
            // textBox24
            // 
            this.textBox24.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox24.Location = new System.Drawing.Point(85, 56);
            this.textBox24.Multiline = true;
            this.textBox24.Name = "textBox24";
            this.textBox24.Size = new System.Drawing.Size(231, 63);
            this.textBox24.TabIndex = 69;
            this.textBox24.Tag = "finvarkind.description";
            // 
            // label18
            // 
            this.label18.Location = new System.Drawing.Point(17, 60);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(128, 19);
            this.label18.TabIndex = 71;
            this.label18.Text = "Descrizione";
            // 
            // label19
            // 
            this.label19.Location = new System.Drawing.Point(38, 30);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(160, 16);
            this.label19.TabIndex = 70;
            this.label19.Text = "Codice:";
            // 
            // Frm_finvarkind_default
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(446, 141);
            this.Controls.Add(this.txtCodice);
            this.Controls.Add(this.textBox24);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label19);
            this.Name = "Frm_finvarkind_default";
            this.Text = "Frm_finvarkind_default";
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public vistaForm DS;
        private System.Windows.Forms.TextBox txtCodice;
        private System.Windows.Forms.TextBox textBox24;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;

    }
}
