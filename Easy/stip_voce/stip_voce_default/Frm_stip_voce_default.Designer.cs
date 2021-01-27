
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


namespace stip_voce_default {
    partial class Frm_stip_voce_default {
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
            this.DS = new stip_voce_default.vistaForm();
            this.txtDescrizione = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtImporto = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtDataContabile = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.SuspendLayout();
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.EnforceConstraints = false;
            // 
            // txtDescrizione
            // 
            this.txtDescrizione.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescrizione.Location = new System.Drawing.Point(25, 62);
            this.txtDescrizione.Multiline = true;
            this.txtDescrizione.Name = "txtDescrizione";
            this.txtDescrizione.Size = new System.Drawing.Size(373, 64);
            this.txtDescrizione.TabIndex = 95;
            this.txtDescrizione.Tag = "stip_voce.descrizione";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(22, 43);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 16);
            this.label5.TabIndex = 98;
            this.label5.Text = "Descrizione:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtImporto
            // 
            this.txtImporto.Location = new System.Drawing.Point(42, 11);
            this.txtImporto.Name = "txtImporto";
            this.txtImporto.Size = new System.Drawing.Size(60, 20);
            this.txtImporto.TabIndex = 96;
            this.txtImporto.Tag = "stip_voce.idstipvoce";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(13, 11);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 16);
            this.label6.TabIndex = 99;
            this.label6.Text = "#:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(123, 11);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(80, 16);
            this.label7.TabIndex = 100;
            this.label7.Text = "Codice Voce:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDataContabile
            // 
            this.txtDataContabile.Location = new System.Drawing.Point(204, 11);
            this.txtDataContabile.Name = "txtDataContabile";
            this.txtDataContabile.Size = new System.Drawing.Size(194, 20);
            this.txtDataContabile.TabIndex = 97;
            this.txtDataContabile.Tag = "stip_voce.codicevoce";
            // 
            // Frm_stip_voce_default
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(414, 149);
            this.Controls.Add(this.txtDescrizione);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtImporto);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtDataContabile);
            this.Name = "Frm_stip_voce_default";
            this.Text = "Frm_stip_voce_default";
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public vistaForm DS;
        private System.Windows.Forms.TextBox txtDescrizione;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtImporto;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtDataContabile;
    }
}
