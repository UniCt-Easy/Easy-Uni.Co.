
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


namespace invoiceattachmentkind_default {
    partial class Frm_invoiceattachmentkind_default {
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
			this.DS = new invoiceattachmentkind_default.vistaForm();
			this.checkBox1 = new System.Windows.Forms.CheckBox();
			this.label2 = new System.Windows.Forms.Label();
			this.txtCodice = new System.Windows.Forms.TextBox();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.chkFeVendita = new System.Windows.Forms.CheckBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.chkFattVen = new System.Windows.Forms.CheckBox();
			this.chkFattAcq = new System.Windows.Forms.CheckBox();
			((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// DS
			// 
			this.DS.DataSetName = "vistaForm";
			// 
			// checkBox1
			// 
			this.checkBox1.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.checkBox1.Location = new System.Drawing.Point(284, 41);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.Size = new System.Drawing.Size(67, 20);
			this.checkBox1.TabIndex = 42;
			this.checkBox1.Tag = "invoiceattachmentkind.active:S:N";
			this.checkBox1.Text = "Attivo";
			this.checkBox1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(26, 63);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(72, 16);
			this.label2.TabIndex = 44;
			this.label2.Text = "Descrizione";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtCodice
			// 
			this.txtCodice.Location = new System.Drawing.Point(27, 36);
			this.txtCodice.Name = "txtCodice";
			this.txtCodice.Size = new System.Drawing.Size(72, 20);
			this.txtCodice.TabIndex = 40;
			this.txtCodice.Tag = "invoiceattachmentkind.idattachmentkind";
			// 
			// textBox2
			// 
			this.textBox2.Location = new System.Drawing.Point(27, 79);
			this.textBox2.Multiline = true;
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(324, 43);
			this.textBox2.TabIndex = 41;
			this.textBox2.Tag = "invoiceattachmentkind.title";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(26, 19);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(64, 16);
			this.label1.TabIndex = 43;
			this.label1.Text = "Codice";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// chkFeVendita
			// 
			this.chkFeVendita.AutoSize = true;
			this.chkFeVendita.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.chkFeVendita.Location = new System.Drawing.Point(236, 19);
			this.chkFeVendita.Name = "chkFeVendita";
			this.chkFeVendita.Size = new System.Drawing.Size(115, 17);
			this.chkFeVendita.TabIndex = 45;
			this.chkFeVendita.Tag = "invoiceattachmentkind.attachment_fe:S:N";
			this.chkFeVendita.Text = "Invia in FE Vendita";
			this.chkFeVendita.UseVisualStyleBackColor = true;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.chkFattVen);
			this.groupBox1.Controls.Add(this.chkFattAcq);
			this.groupBox1.Location = new System.Drawing.Point(27, 140);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(324, 86);
			this.groupBox1.TabIndex = 46;
			this.groupBox1.TabStop = false;
			// 
			// chkFattVen
			// 
			this.chkFattVen.AutoSize = true;
			this.chkFattVen.Location = new System.Drawing.Point(23, 51);
			this.chkFattVen.Name = "chkFattVen";
			this.chkFattVen.Size = new System.Drawing.Size(155, 17);
			this.chkFattVen.TabIndex = 1;
			this.chkFattVen.Tag = "invoiceattachmentkind.flagvisiblekind:1";
			this.chkFattVen.Text = "Visibile in Fattura di Vendita";
			this.chkFattVen.UseVisualStyleBackColor = true;
			// 
			// chkFattAcq
			// 
			this.chkFattAcq.AutoSize = true;
			this.chkFattAcq.Location = new System.Drawing.Point(23, 28);
			this.chkFattAcq.Name = "chkFattAcq";
			this.chkFattAcq.Size = new System.Drawing.Size(160, 17);
			this.chkFattAcq.TabIndex = 0;
			this.chkFattAcq.Tag = "invoiceattachmentkind.flagvisiblekind:0";
			this.chkFattAcq.Text = "Visibile in Fattura di Acquisto";
			this.chkFattAcq.UseVisualStyleBackColor = true;
			// 
			// Frm_invoiceattachmentkind_default
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(378, 252);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.chkFeVendita);
			this.Controls.Add(this.checkBox1);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.txtCodice);
			this.Controls.Add(this.textBox2);
			this.Controls.Add(this.label1);
			this.Name = "Frm_invoiceattachmentkind_default";
			this.Text = "Frm_invoiceattachmentkind_default";
			((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCodice;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label1;
        public vistaForm DS;
		private System.Windows.Forms.CheckBox chkFeVendita;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.CheckBox chkFattVen;
		private System.Windows.Forms.CheckBox chkFattAcq;
	}
}
