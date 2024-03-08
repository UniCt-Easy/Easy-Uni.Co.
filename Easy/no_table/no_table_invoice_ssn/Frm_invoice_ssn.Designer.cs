
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


namespace no_table_invoice_ssn {
    partial class Frm_invoice_ssn {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_invoice_ssn));
            this.gridFatture = new System.Windows.Forms.DataGrid();
            this.gboxFatture = new System.Windows.Forms.GroupBox();
            this.btnEstraiFatture = new System.Windows.Forms.Button();
            this.btnInvia = new System.Windows.Forms.Button();
            this.DS = new no_table_invoice_ssn.vistaForm();
            ((System.ComponentModel.ISupportInitialize)(this.gridFatture)).BeginInit();
            this.gboxFatture.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.SuspendLayout();
            // 
            // gridFatture
            // 
            this.gridFatture.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridFatture.DataMember = "";
            this.gridFatture.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.gridFatture.Location = new System.Drawing.Point(8, 21);
            this.gridFatture.Name = "gridFatture";
            this.gridFatture.Size = new System.Drawing.Size(1030, 514);
            this.gridFatture.TabIndex = 0;
            // 
            // gboxFatture
            // 
            this.gboxFatture.Controls.Add(this.btnEstraiFatture);
            this.gboxFatture.Controls.Add(this.gridFatture);
            this.gboxFatture.Location = new System.Drawing.Point(12, 12);
            this.gboxFatture.Name = "gboxFatture";
            this.gboxFatture.Padding = new System.Windows.Forms.Padding(5);
            this.gboxFatture.Size = new System.Drawing.Size(1046, 572);
            this.gboxFatture.TabIndex = 1;
            this.gboxFatture.TabStop = false;
            this.gboxFatture.Text = "Fatture";
            // 
            // btnEstraiFatture
            // 
            this.btnEstraiFatture.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnEstraiFatture.Location = new System.Drawing.Point(8, 541);
            this.btnEstraiFatture.Name = "btnEstraiFatture";
            this.btnEstraiFatture.Size = new System.Drawing.Size(90, 23);
            this.btnEstraiFatture.TabIndex = 1;
            this.btnEstraiFatture.Text = "Estrai fatture";
            this.btnEstraiFatture.UseVisualStyleBackColor = true;
            this.btnEstraiFatture.Click += new System.EventHandler(this.btnEstraiFatture_Click);
            // 
            // btnInvia
            // 
            this.btnInvia.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnInvia.Enabled = false;
            this.btnInvia.Location = new System.Drawing.Point(968, 590);
            this.btnInvia.Name = "btnInvia";
            this.btnInvia.Size = new System.Drawing.Size(90, 23);
            this.btnInvia.TabIndex = 1;
            this.btnInvia.Text = "Invia a TS";
            this.btnInvia.UseVisualStyleBackColor = true;
            this.btnInvia.Click += new System.EventHandler(this.btnInvia_Click);
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.EnforceConstraints = false;
            // 
            // Frm_invoice_ssn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1070, 625);
            this.Controls.Add(this.btnInvia);
            this.Controls.Add(this.gboxFatture);
            this.Name = "Frm_invoice_ssn";
            this.Text = "Frm_invoice_ssn";
            ((System.ComponentModel.ISupportInitialize)(this.gridFatture)).EndInit();
            this.gboxFatture.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGrid gridFatture;
        private System.Windows.Forms.GroupBox gboxFatture;
        private System.Windows.Forms.Button btnEstraiFatture;
        private System.Windows.Forms.Button btnInvia;
        public no_table_invoice_ssn.vistaForm DS;
    }
}
