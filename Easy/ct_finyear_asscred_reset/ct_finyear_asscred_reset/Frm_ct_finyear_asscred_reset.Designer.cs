
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


namespace ct_finyear_asscred_reset
{
    partial class Frm_ct_finyear_asscred_reset
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.DS = new ct_finyear_asscred_reset.vistaForm();
            this.btnMostraPrevisioni = new System.Windows.Forms.Button();
            this.btnAnnulla = new System.Windows.Forms.Button();
            this.btnAzzera = new System.Windows.Forms.Button();
            this.gridDettagli = new System.Windows.Forms.DataGrid();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridDettagli)).BeginInit();
            this.SuspendLayout();
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.EnforceConstraints = false;
            // 
            // btnMostraPrevisioni
            // 
            this.btnMostraPrevisioni.Location = new System.Drawing.Point(185, 12);
            this.btnMostraPrevisioni.Name = "btnMostraPrevisioni";
            this.btnMostraPrevisioni.Size = new System.Drawing.Size(213, 23);
            this.btnMostraPrevisioni.TabIndex = 40;
            this.btnMostraPrevisioni.Text = "Mostra Previsioni da Azzerare";
            this.btnMostraPrevisioni.Click += new System.EventHandler(this.btnMostraPrevisioni_Click);
            // 
            // btnAnnulla
            // 
            this.btnAnnulla.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAnnulla.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnAnnulla.Location = new System.Drawing.Point(494, 470);
            this.btnAnnulla.Name = "btnAnnulla";
            this.btnAnnulla.Size = new System.Drawing.Size(75, 24);
            this.btnAnnulla.TabIndex = 39;
            this.btnAnnulla.Text = "Annulla";
            // 
            // btnAzzera
            // 
            this.btnAzzera.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAzzera.Location = new System.Drawing.Point(393, 470);
            this.btnAzzera.Name = "btnAzzera";
            this.btnAzzera.Size = new System.Drawing.Size(80, 26);
            this.btnAzzera.TabIndex = 38;
            this.btnAzzera.Text = "Azzera";
            this.btnAzzera.UseVisualStyleBackColor = true;
            this.btnAzzera.Click += new System.EventHandler(this.btnAzzera_Click);
            // 
            // gridDettagli
            // 
            this.gridDettagli.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridDettagli.CaptionVisible = false;
            this.gridDettagli.DataMember = "";
            this.gridDettagli.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.gridDettagli.Location = new System.Drawing.Point(12, 54);
            this.gridDettagli.Name = "gridDettagli";
            this.gridDettagli.Size = new System.Drawing.Size(557, 410);
            this.gridDettagli.TabIndex = 37;
            // 
            // Frm_ct_finyear_asscred_reset
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(581, 520);
            this.Controls.Add(this.btnMostraPrevisioni);
            this.Controls.Add(this.btnAnnulla);
            this.Controls.Add(this.btnAzzera);
            this.Controls.Add(this.gridDettagli);
            this.Name = "Frm_ct_finyear_asscred_reset";
            this.Text = "Frm_ct_finyear_asscred_reset";
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridDettagli)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public vistaForm DS;
        private System.Windows.Forms.Button btnMostraPrevisioni;
        private System.Windows.Forms.Button btnAnnulla;
        private System.Windows.Forms.Button btnAzzera;
        private System.Windows.Forms.DataGrid gridDettagli;
    }
}
