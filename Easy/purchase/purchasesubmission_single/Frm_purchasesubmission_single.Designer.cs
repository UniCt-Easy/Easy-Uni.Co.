
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


namespace purchasesubmission_single {
    partial class Frm_purchasesubmission_single {
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
            this.DS = new purchasesubmission_single.vistaForm();
            this.gbxVersante = new System.Windows.Forms.GroupBox();
            this.txtCliente = new System.Windows.Forms.TextBox();
            this.gbxPagoPA = new System.Windows.Forms.GroupBox();
            this.btnAvviso = new System.Windows.Forms.Button();
            this.txtEsercizio = new System.Windows.Forms.TextBox();
            this.lblEsercizio = new System.Windows.Forms.Label();
            this.txtDataScadenza = new System.Windows.Forms.TextBox();
            this.lblDataScadenza = new System.Windows.Forms.Label();
            this.txtIUV = new System.Windows.Forms.TextBox();
            this.lblIUV = new System.Windows.Forms.Label();
            this.gbxAnnotazioni = new System.Windows.Forms.GroupBox();
            this.txtAnnotazioni = new System.Windows.Forms.TextBox();
            this.btnAnnulla = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.dialogSalvaAvviso = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.gbxVersante.SuspendLayout();
            this.gbxPagoPA.SuspendLayout();
            this.gbxAnnotazioni.SuspendLayout();
            this.SuspendLayout();
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.EnforceConstraints = false;
            // 
            // gbxVersante
            // 
            this.gbxVersante.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbxVersante.Controls.Add(this.txtCliente);
            this.gbxVersante.Location = new System.Drawing.Point(12, 102);
            this.gbxVersante.Name = "gbxVersante";
            this.gbxVersante.Padding = new System.Windows.Forms.Padding(5);
            this.gbxVersante.Size = new System.Drawing.Size(504, 52);
            this.gbxVersante.TabIndex = 1;
            this.gbxVersante.TabStop = false;
            this.gbxVersante.Tag = "AutoChoose.txtCliente.lista.(active=\'S\')";
            this.gbxVersante.Text = "Soggetto versante";
            // 
            // txtCliente
            // 
            this.txtCliente.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCliente.Location = new System.Drawing.Point(8, 21);
            this.txtCliente.Name = "txtCliente";
            this.txtCliente.Size = new System.Drawing.Size(488, 20);
            this.txtCliente.TabIndex = 0;
            this.txtCliente.Tag = "registry.title?purchasesubmission.registry";
            // 
            // gbxPagoPA
            // 
            this.gbxPagoPA.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbxPagoPA.Controls.Add(this.btnAvviso);
            this.gbxPagoPA.Controls.Add(this.txtEsercizio);
            this.gbxPagoPA.Controls.Add(this.lblEsercizio);
            this.gbxPagoPA.Controls.Add(this.txtDataScadenza);
            this.gbxPagoPA.Controls.Add(this.lblDataScadenza);
            this.gbxPagoPA.Controls.Add(this.txtIUV);
            this.gbxPagoPA.Controls.Add(this.lblIUV);
            this.gbxPagoPA.Location = new System.Drawing.Point(12, 12);
            this.gbxPagoPA.Name = "gbxPagoPA";
            this.gbxPagoPA.Padding = new System.Windows.Forms.Padding(5);
            this.gbxPagoPA.Size = new System.Drawing.Size(504, 84);
            this.gbxPagoPA.TabIndex = 0;
            this.gbxPagoPA.TabStop = false;
            // 
            // btnAvviso
            // 
            this.btnAvviso.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAvviso.Location = new System.Drawing.Point(377, 19);
            this.btnAvviso.Name = "btnAvviso";
            this.btnAvviso.Size = new System.Drawing.Size(119, 23);
            this.btnAvviso.TabIndex = 2;
            this.btnAvviso.Text = "Avviso di pagamento";
            this.btnAvviso.UseVisualStyleBackColor = true;
            this.btnAvviso.Click += new System.EventHandler(this.btnAvviso_Click);
            // 
            // txtEsercizio
            // 
            this.txtEsercizio.Location = new System.Drawing.Point(365, 47);
            this.txtEsercizio.Name = "txtEsercizio";
            this.txtEsercizio.Size = new System.Drawing.Size(56, 20);
            this.txtEsercizio.TabIndex = 6;
            this.txtEsercizio.Tag = "purchasesubmission.ayear";
            // 
            // lblEsercizio
            // 
            this.lblEsercizio.AutoSize = true;
            this.lblEsercizio.Location = new System.Drawing.Point(310, 50);
            this.lblEsercizio.Name = "lblEsercizio";
            this.lblEsercizio.Size = new System.Drawing.Size(49, 13);
            this.lblEsercizio.TabIndex = 5;
            this.lblEsercizio.Text = "Esercizio";
            // 
            // txtDataScadenza
            // 
            this.txtDataScadenza.Location = new System.Drawing.Point(197, 47);
            this.txtDataScadenza.Name = "txtDataScadenza";
            this.txtDataScadenza.Size = new System.Drawing.Size(107, 20);
            this.txtDataScadenza.TabIndex = 4;
            this.txtDataScadenza.Tag = "purchasesubmission.expirationdate";
            // 
            // lblDataScadenza
            // 
            this.lblDataScadenza.AutoSize = true;
            this.lblDataScadenza.Location = new System.Drawing.Point(28, 50);
            this.lblDataScadenza.Name = "lblDataScadenza";
            this.lblDataScadenza.Size = new System.Drawing.Size(163, 13);
            this.lblDataScadenza.TabIndex = 3;
            this.lblDataScadenza.Text = "Data di scadenza del pagamento";
            // 
            // txtIUV
            // 
            this.txtIUV.Location = new System.Drawing.Point(197, 21);
            this.txtIUV.Name = "txtIUV";
            this.txtIUV.Size = new System.Drawing.Size(162, 20);
            this.txtIUV.TabIndex = 1;
            this.txtIUV.Tag = "purchasesubmission.iuv";
            // 
            // lblIUV
            // 
            this.lblIUV.AutoSize = true;
            this.lblIUV.Location = new System.Drawing.Point(11, 24);
            this.lblIUV.Name = "lblIUV";
            this.lblIUV.Size = new System.Drawing.Size(180, 13);
            this.lblIUV.TabIndex = 0;
            this.lblIUV.Text = "Identificativo Univoco di Versamento";
            // 
            // gbxAnnotazioni
            // 
            this.gbxAnnotazioni.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbxAnnotazioni.Controls.Add(this.txtAnnotazioni);
            this.gbxAnnotazioni.Location = new System.Drawing.Point(12, 160);
            this.gbxAnnotazioni.Name = "gbxAnnotazioni";
            this.gbxAnnotazioni.Padding = new System.Windows.Forms.Padding(5);
            this.gbxAnnotazioni.Size = new System.Drawing.Size(504, 233);
            this.gbxAnnotazioni.TabIndex = 2;
            this.gbxAnnotazioni.TabStop = false;
            this.gbxAnnotazioni.Text = "Annotazioni";
            // 
            // txtAnnotazioni
            // 
            this.txtAnnotazioni.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAnnotazioni.Location = new System.Drawing.Point(8, 21);
            this.txtAnnotazioni.Multiline = true;
            this.txtAnnotazioni.Name = "txtAnnotazioni";
            this.txtAnnotazioni.Size = new System.Drawing.Size(488, 204);
            this.txtAnnotazioni.TabIndex = 0;
            this.txtAnnotazioni.Tag = "purchasesubmission.notes";
            // 
            // btnAnnulla
            // 
            this.btnAnnulla.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnAnnulla.Location = new System.Drawing.Point(267, 399);
            this.btnAnnulla.Name = "btnAnnulla";
            this.btnAnnulla.Size = new System.Drawing.Size(75, 23);
            this.btnAnnulla.TabIndex = 4;
            this.btnAnnulla.Text = "Annulla";
            this.btnAnnulla.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(186, 399);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 3;
            this.btnOK.Tag = "mainsave";
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // dialogSalvaAvviso
            // 
            this.dialogSalvaAvviso.Title = "Salva avviso di pagamento";
            // 
            // Frm_purchasesubmission_single
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(528, 434);
            this.Controls.Add(this.btnAnnulla);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.gbxAnnotazioni);
            this.Controls.Add(this.gbxPagoPA);
            this.Controls.Add(this.gbxVersante);
            this.Name = "Frm_purchasesubmission_single";
            this.Text = "Frm_purchasesubmission_single";
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.gbxVersante.ResumeLayout(false);
            this.gbxVersante.PerformLayout();
            this.gbxPagoPA.ResumeLayout(false);
            this.gbxPagoPA.PerformLayout();
            this.gbxAnnotazioni.ResumeLayout(false);
            this.gbxAnnotazioni.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public vistaForm DS;
        private System.Windows.Forms.GroupBox gbxVersante;
        private System.Windows.Forms.TextBox txtCliente;
        private System.Windows.Forms.GroupBox gbxPagoPA;
        private System.Windows.Forms.TextBox txtIUV;
        private System.Windows.Forms.Label lblIUV;
        private System.Windows.Forms.TextBox txtEsercizio;
        private System.Windows.Forms.Label lblEsercizio;
        private System.Windows.Forms.TextBox txtDataScadenza;
        private System.Windows.Forms.Label lblDataScadenza;
        private System.Windows.Forms.GroupBox gbxAnnotazioni;
        private System.Windows.Forms.TextBox txtAnnotazioni;
        private System.Windows.Forms.Button btnAvviso;
        private System.Windows.Forms.Button btnAnnulla;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.SaveFileDialog dialogSalvaAvviso;
    }
}
