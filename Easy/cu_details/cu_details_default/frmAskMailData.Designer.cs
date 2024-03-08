
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


namespace cu_details_default {
    partial class frmAskMailData {
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
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.txtOggetto = new System.Windows.Forms.TextBox();
			this.txtContenuto = new System.Windows.Forms.TextBox();
			this.btnInvia = new System.Windows.Forms.Button();
			this.btnAnnulla = new System.Windows.Forms.Button();
			this.txtCopiaConoscenza = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.chkInvioProva = new System.Windows.Forms.CheckBox();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 157);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(129, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Testo della mail da inviare";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(12, 87);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(91, 13);
			this.label2.TabIndex = 1;
			this.label2.Text = "Oggetto della mail";
			// 
			// txtOggetto
			// 
			this.txtOggetto.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtOggetto.Location = new System.Drawing.Point(15, 101);
			this.txtOggetto.Name = "txtOggetto";
			this.txtOggetto.Size = new System.Drawing.Size(565, 20);
			this.txtOggetto.TabIndex = 2;
			// 
			// txtContenuto
			// 
			this.txtContenuto.AcceptsReturn = true;
			this.txtContenuto.AcceptsTab = true;
			this.txtContenuto.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtContenuto.Location = new System.Drawing.Point(15, 172);
			this.txtContenuto.Multiline = true;
			this.txtContenuto.Name = "txtContenuto";
			this.txtContenuto.Size = new System.Drawing.Size(565, 170);
			this.txtContenuto.TabIndex = 3;
			// 
			// btnInvia
			// 
			this.btnInvia.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnInvia.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnInvia.Location = new System.Drawing.Point(402, 358);
			this.btnInvia.Name = "btnInvia";
			this.btnInvia.Size = new System.Drawing.Size(75, 23);
			this.btnInvia.TabIndex = 4;
			this.btnInvia.Text = "Ok";
			this.btnInvia.UseVisualStyleBackColor = true;
			// 
			// btnAnnulla
			// 
			this.btnAnnulla.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnAnnulla.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnAnnulla.Location = new System.Drawing.Point(505, 358);
			this.btnAnnulla.Name = "btnAnnulla";
			this.btnAnnulla.Size = new System.Drawing.Size(75, 23);
			this.btnAnnulla.TabIndex = 5;
			this.btnAnnulla.Text = "Annulla";
			this.btnAnnulla.UseVisualStyleBackColor = true;
			// 
			// txtCopiaConoscenza
			// 
			this.txtCopiaConoscenza.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtCopiaConoscenza.Location = new System.Drawing.Point(15, 46);
			this.txtCopiaConoscenza.Name = "txtCopiaConoscenza";
			this.txtCopiaConoscenza.Size = new System.Drawing.Size(565, 20);
			this.txtCopiaConoscenza.TabIndex = 1;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(12, 32);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(153, 13);
			this.label3.TabIndex = 6;
			this.label3.Text = "Indirizzo per copia conoscenza";
			// 
			// chkInvioProva
			// 
			this.chkInvioProva.AutoSize = true;
			this.chkInvioProva.Checked = true;
			this.chkInvioProva.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkInvioProva.Location = new System.Drawing.Point(15, 360);
			this.chkInvioProva.Name = "chkInvioProva";
			this.chkInvioProva.Size = new System.Drawing.Size(238, 17);
			this.chkInvioProva.TabIndex = 8;
			this.chkInvioProva.Text = "Invio di prova, non inviare mail a collaboratori";
			this.chkInvioProva.UseVisualStyleBackColor = true;
			// 
			// frmAskMailData
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(596, 389);
			this.Controls.Add(this.chkInvioProva);
			this.Controls.Add(this.txtCopiaConoscenza);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.btnAnnulla);
			this.Controls.Add(this.btnInvia);
			this.Controls.Add(this.txtContenuto);
			this.Controls.Add(this.txtOggetto);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Name = "frmAskMailData";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "frmAskMailData";
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnInvia;
        private System.Windows.Forms.Button btnAnnulla;
        public System.Windows.Forms.TextBox txtOggetto;
        public System.Windows.Forms.TextBox txtContenuto;
        public System.Windows.Forms.TextBox txtCopiaConoscenza;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.CheckBox chkInvioProva;
	}
}
