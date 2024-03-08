
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


namespace purchasedetail_single {
    partial class Frm_purchasedetail_single {
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
            this.gboxListino = new System.Windows.Forms.GroupBox();
            this.txtDescrizioneListino = new System.Windows.Forms.TextBox();
            this.pbox = new System.Windows.Forms.PictureBox();
            this.lblDescrizioneListino = new System.Windows.Forms.Label();
            this.btnListino = new System.Windows.Forms.Button();
            this.txtCodiceListino = new System.Windows.Forms.TextBox();
            this.DS = new purchasedetail_single.vistaForm();
            this.gbxInfo = new System.Windows.Forms.GroupBox();
            this.txtQuantità = new System.Windows.Forms.TextBox();
            this.lblQuantità = new System.Windows.Forms.Label();
            this.txtImposta = new System.Windows.Forms.TextBox();
            this.lblImposta = new System.Windows.Forms.Label();
            this.txtImponibile = new System.Windows.Forms.TextBox();
            this.lblImponibile = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnAnnulla = new System.Windows.Forms.Button();
            this.gboxListino.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.gbxInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // gboxListino
            // 
            this.gboxListino.Controls.Add(this.txtDescrizioneListino);
            this.gboxListino.Controls.Add(this.pbox);
            this.gboxListino.Controls.Add(this.lblDescrizioneListino);
            this.gboxListino.Controls.Add(this.btnListino);
            this.gboxListino.Controls.Add(this.txtCodiceListino);
            this.gboxListino.Location = new System.Drawing.Point(12, 71);
            this.gboxListino.Name = "gboxListino";
            this.gboxListino.Size = new System.Drawing.Size(471, 153);
            this.gboxListino.TabIndex = 1;
            this.gboxListino.TabStop = false;
            this.gboxListino.Tag = "";
            this.gboxListino.Text = "Listino";
            // 
            // txtDescrizioneListino
            // 
            this.txtDescrizioneListino.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescrizioneListino.Location = new System.Drawing.Point(6, 61);
            this.txtDescrizioneListino.Multiline = true;
            this.txtDescrizioneListino.Name = "txtDescrizioneListino";
            this.txtDescrizioneListino.ReadOnly = true;
            this.txtDescrizioneListino.Size = new System.Drawing.Size(325, 86);
            this.txtDescrizioneListino.TabIndex = 3;
            this.txtDescrizioneListino.Tag = "listview.description";
            // 
            // pbox
            // 
            this.pbox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pbox.Location = new System.Drawing.Point(337, 18);
            this.pbox.Name = "pbox";
            this.pbox.Size = new System.Drawing.Size(128, 128);
            this.pbox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbox.TabIndex = 18;
            this.pbox.TabStop = false;
            // 
            // lblDescrizioneListino
            // 
            this.lblDescrizioneListino.AutoSize = true;
            this.lblDescrizioneListino.Location = new System.Drawing.Point(6, 45);
            this.lblDescrizioneListino.Name = "lblDescrizioneListino";
            this.lblDescrizioneListino.Size = new System.Drawing.Size(62, 13);
            this.lblDescrizioneListino.TabIndex = 2;
            this.lblDescrizioneListino.Text = "Descrizione";
            // 
            // btnListino
            // 
            this.btnListino.BackColor = System.Drawing.SystemColors.Control;
            this.btnListino.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnListino.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnListino.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnListino.ImageIndex = 0;
            this.btnListino.Location = new System.Drawing.Point(6, 19);
            this.btnListino.Name = "btnListino";
            this.btnListino.Size = new System.Drawing.Size(62, 23);
            this.btnListino.TabIndex = 1;
            this.btnListino.TabStop = false;
            this.btnListino.Tag = "";
            this.btnListino.Text = "Listino";
            this.btnListino.UseVisualStyleBackColor = false;
            this.btnListino.Click += new System.EventHandler(this.btnListino_Click);
            // 
            // txtCodiceListino
            // 
            this.txtCodiceListino.Location = new System.Drawing.Point(74, 21);
            this.txtCodiceListino.Name = "txtCodiceListino";
            this.txtCodiceListino.Size = new System.Drawing.Size(122, 20);
            this.txtCodiceListino.TabIndex = 0;
            this.txtCodiceListino.Tag = "listview.intcode?x";
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.EnforceConstraints = false;
            // 
            // gbxInfo
            // 
            this.gbxInfo.Controls.Add(this.txtQuantità);
            this.gbxInfo.Controls.Add(this.lblQuantità);
            this.gbxInfo.Controls.Add(this.txtImposta);
            this.gbxInfo.Controls.Add(this.lblImposta);
            this.gbxInfo.Controls.Add(this.txtImponibile);
            this.gbxInfo.Controls.Add(this.lblImponibile);
            this.gbxInfo.Location = new System.Drawing.Point(12, 12);
            this.gbxInfo.Name = "gbxInfo";
            this.gbxInfo.Size = new System.Drawing.Size(471, 53);
            this.gbxInfo.TabIndex = 0;
            this.gbxInfo.TabStop = false;
            // 
            // txtQuantità
            // 
            this.txtQuantità.Location = new System.Drawing.Point(388, 19);
            this.txtQuantità.Name = "txtQuantità";
            this.txtQuantità.Size = new System.Drawing.Size(55, 20);
            this.txtQuantità.TabIndex = 5;
            this.txtQuantità.Tag = "purchasedetail.quantity";
            // 
            // lblQuantità
            // 
            this.lblQuantità.AutoSize = true;
            this.lblQuantità.Location = new System.Drawing.Point(335, 22);
            this.lblQuantità.Name = "lblQuantità";
            this.lblQuantità.Size = new System.Drawing.Size(47, 13);
            this.lblQuantità.TabIndex = 4;
            this.lblQuantità.Text = "Quantità";
            this.lblQuantità.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtImposta
            // 
            this.txtImposta.Location = new System.Drawing.Point(229, 19);
            this.txtImposta.Name = "txtImposta";
            this.txtImposta.Size = new System.Drawing.Size(100, 20);
            this.txtImposta.TabIndex = 3;
            this.txtImposta.Tag = "purchasedetail.unitiva";
            // 
            // lblImposta
            // 
            this.lblImposta.AutoSize = true;
            this.lblImposta.Location = new System.Drawing.Point(180, 22);
            this.lblImposta.Name = "lblImposta";
            this.lblImposta.Size = new System.Drawing.Size(44, 13);
            this.lblImposta.TabIndex = 2;
            this.lblImposta.Text = "Imposta";
            this.lblImposta.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtImponibile
            // 
            this.txtImponibile.Location = new System.Drawing.Point(74, 19);
            this.txtImponibile.Name = "txtImponibile";
            this.txtImponibile.Size = new System.Drawing.Size(100, 20);
            this.txtImponibile.TabIndex = 1;
            this.txtImponibile.Tag = "purchasedetail.unitprice";
            // 
            // lblImponibile
            // 
            this.lblImponibile.AutoSize = true;
            this.lblImponibile.Location = new System.Drawing.Point(14, 22);
            this.lblImponibile.Name = "lblImponibile";
            this.lblImponibile.Size = new System.Drawing.Size(54, 13);
            this.lblImponibile.TabIndex = 0;
            this.lblImponibile.Text = "Imponibile";
            this.lblImponibile.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(169, 230);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 2;
            this.btnOK.Tag = "mainsave";
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // btnAnnulla
            // 
            this.btnAnnulla.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnAnnulla.Location = new System.Drawing.Point(250, 230);
            this.btnAnnulla.Name = "btnAnnulla";
            this.btnAnnulla.Size = new System.Drawing.Size(75, 23);
            this.btnAnnulla.TabIndex = 3;
            this.btnAnnulla.Text = "Annulla";
            this.btnAnnulla.UseVisualStyleBackColor = true;
            // 
            // Frm_purchasedetail_single
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(495, 266);
            this.Controls.Add(this.btnAnnulla);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.gbxInfo);
            this.Controls.Add(this.gboxListino);
            this.Name = "Frm_purchasedetail_single";
            this.Text = "Frm_purchasedetail_single";
            this.gboxListino.ResumeLayout(false);
            this.gboxListino.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.gbxInfo.ResumeLayout(false);
            this.gbxInfo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gboxListino;
        private System.Windows.Forms.TextBox txtDescrizioneListino;
        private System.Windows.Forms.PictureBox pbox;
        private System.Windows.Forms.Label lblDescrizioneListino;
        private System.Windows.Forms.Button btnListino;
        private System.Windows.Forms.TextBox txtCodiceListino;
        public vistaForm DS;
        private System.Windows.Forms.GroupBox gbxInfo;
        private System.Windows.Forms.TextBox txtQuantità;
        private System.Windows.Forms.Label lblQuantità;
        private System.Windows.Forms.TextBox txtImposta;
        private System.Windows.Forms.Label lblImposta;
        private System.Windows.Forms.TextBox txtImponibile;
        private System.Windows.Forms.Label lblImponibile;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnAnnulla;
    }
}
