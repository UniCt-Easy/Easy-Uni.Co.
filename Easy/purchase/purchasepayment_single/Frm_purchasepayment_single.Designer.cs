/*
    Easy
    Copyright (C) 2020 Università degli Studi di Catania (www.unict.it)
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

﻿namespace purchasepayment_single {
    partial class Frm_purchasepayment_single {
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
            this.DS = new purchasepayment_single.vistaForm();
            this.gbxPagoPA = new System.Windows.Forms.GroupBox();
            this.txtCCP = new System.Windows.Forms.TextBox();
            this.lblCCP = new System.Windows.Forms.Label();
            this.txtIUV = new System.Windows.Forms.TextBox();
            this.lblIUV = new System.Windows.Forms.Label();
            this.gbxPagante = new System.Windows.Forms.GroupBox();
            this.txtCliente = new System.Windows.Forms.TextBox();
            this.gbxPagamento = new System.Windows.Forms.GroupBox();
            this.chkCompletato = new System.Windows.Forms.CheckBox();
            this.cmbTipoPagamento = new System.Windows.Forms.ComboBox();
            this.txtIBAN = new System.Windows.Forms.TextBox();
            this.lblIBAN = new System.Windows.Forms.Label();
            this.lblTipoPagamento = new System.Windows.Forms.Label();
            this.btnAnnulla = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.gbxPagoPA.SuspendLayout();
            this.gbxPagante.SuspendLayout();
            this.gbxPagamento.SuspendLayout();
            this.SuspendLayout();
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.EnforceConstraints = false;
            // 
            // gbxPagoPA
            // 
            this.gbxPagoPA.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbxPagoPA.Controls.Add(this.txtCCP);
            this.gbxPagoPA.Controls.Add(this.lblCCP);
            this.gbxPagoPA.Controls.Add(this.txtIUV);
            this.gbxPagoPA.Controls.Add(this.lblIUV);
            this.gbxPagoPA.Location = new System.Drawing.Point(12, 12);
            this.gbxPagoPA.Name = "gbxPagoPA";
            this.gbxPagoPA.Padding = new System.Windows.Forms.Padding(5);
            this.gbxPagoPA.Size = new System.Drawing.Size(389, 84);
            this.gbxPagoPA.TabIndex = 0;
            this.gbxPagoPA.TabStop = false;
            // 
            // txtCCP
            // 
            this.txtCCP.Location = new System.Drawing.Point(197, 47);
            this.txtCCP.Name = "txtCCP";
            this.txtCCP.Size = new System.Drawing.Size(107, 20);
            this.txtCCP.TabIndex = 3;
            this.txtCCP.Tag = "purchasepayment.ccp\r\n";
            // 
            // lblCCP
            // 
            this.lblCCP.AutoSize = true;
            this.lblCCP.Location = new System.Drawing.Point(29, 50);
            this.lblCCP.Name = "lblCCP";
            this.lblCCP.Size = new System.Drawing.Size(162, 13);
            this.lblCCP.TabIndex = 2;
            this.lblCCP.Text = "Codice di contesto di pagamento";
            // 
            // txtIUV
            // 
            this.txtIUV.Location = new System.Drawing.Point(197, 21);
            this.txtIUV.Name = "txtIUV";
            this.txtIUV.Size = new System.Drawing.Size(162, 20);
            this.txtIUV.TabIndex = 1;
            this.txtIUV.Tag = "purchasepayment.iuv\r\n";
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
            // gbxPagante
            // 
            this.gbxPagante.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbxPagante.Controls.Add(this.txtCliente);
            this.gbxPagante.Location = new System.Drawing.Point(12, 102);
            this.gbxPagante.Name = "gbxPagante";
            this.gbxPagante.Padding = new System.Windows.Forms.Padding(5);
            this.gbxPagante.Size = new System.Drawing.Size(470, 52);
            this.gbxPagante.TabIndex = 1;
            this.gbxPagante.TabStop = false;
            this.gbxPagante.Tag = "AutoChoose.txtCliente.lista.(active=\'S\')";
            this.gbxPagante.Text = "Soggetto pagante";
            // 
            // txtCliente
            // 
            this.txtCliente.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCliente.Location = new System.Drawing.Point(8, 21);
            this.txtCliente.Name = "txtCliente";
            this.txtCliente.Size = new System.Drawing.Size(454, 20);
            this.txtCliente.TabIndex = 0;
            this.txtCliente.Tag = "registry.title?purchasesubmission.registry";
            // 
            // gbxPagamento
            // 
            this.gbxPagamento.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbxPagamento.Controls.Add(this.chkCompletato);
            this.gbxPagamento.Controls.Add(this.cmbTipoPagamento);
            this.gbxPagamento.Controls.Add(this.txtIBAN);
            this.gbxPagamento.Controls.Add(this.lblIBAN);
            this.gbxPagamento.Controls.Add(this.lblTipoPagamento);
            this.gbxPagamento.Location = new System.Drawing.Point(12, 160);
            this.gbxPagamento.Name = "gbxPagamento";
            this.gbxPagamento.Padding = new System.Windows.Forms.Padding(5);
            this.gbxPagamento.Size = new System.Drawing.Size(470, 85);
            this.gbxPagamento.TabIndex = 2;
            this.gbxPagamento.TabStop = false;
            this.gbxPagamento.Text = "Pagamento";
            // 
            // chkCompletato
            // 
            this.chkCompletato.AutoSize = true;
            this.chkCompletato.Location = new System.Drawing.Point(356, 25);
            this.chkCompletato.Name = "chkCompletato";
            this.chkCompletato.Size = new System.Drawing.Size(79, 17);
            this.chkCompletato.TabIndex = 2;
            this.chkCompletato.Tag = "purchasepayment.successful:S:N";
            this.chkCompletato.Text = "Completato";
            this.chkCompletato.UseVisualStyleBackColor = true;
            // 
            // cmbTipoPagamento
            // 
            this.cmbTipoPagamento.DataSource = this.DS.purchasepaymentkind;
            this.cmbTipoPagamento.DisplayMember = "description";
            this.cmbTipoPagamento.FormattingEnabled = true;
            this.cmbTipoPagamento.Location = new System.Drawing.Point(134, 21);
            this.cmbTipoPagamento.Name = "cmbTipoPagamento";
            this.cmbTipoPagamento.Size = new System.Drawing.Size(214, 21);
            this.cmbTipoPagamento.TabIndex = 1;
            this.cmbTipoPagamento.Tag = "purchasepaymentkind.idpurchasepaymentkind?purchasepayment.idpurchasepaymentkind";
            this.cmbTipoPagamento.ValueMember = "idpurchasepaymentkind";
            this.cmbTipoPagamento.SelectedValueChanged += new System.EventHandler(this.cmbTipoPagamento_SelectedValueChanged);
            // 
            // txtIBAN
            // 
            this.txtIBAN.Location = new System.Drawing.Point(134, 50);
            this.txtIBAN.Name = "txtIBAN";
            this.txtIBAN.Size = new System.Drawing.Size(162, 20);
            this.txtIBAN.TabIndex = 4;
            this.txtIBAN.Tag = "purchasepayment.iban";
            // 
            // lblIBAN
            // 
            this.lblIBAN.AutoSize = true;
            this.lblIBAN.Location = new System.Drawing.Point(36, 53);
            this.lblIBAN.Name = "lblIBAN";
            this.lblIBAN.Size = new System.Drawing.Size(94, 13);
            this.lblIBAN.TabIndex = 3;
            this.lblIBAN.Text = "IBAN per addebito";
            // 
            // lblTipoPagamento
            // 
            this.lblTipoPagamento.AutoSize = true;
            this.lblTipoPagamento.Location = new System.Drawing.Point(13, 26);
            this.lblTipoPagamento.Name = "lblTipoPagamento";
            this.lblTipoPagamento.Size = new System.Drawing.Size(117, 13);
            this.lblTipoPagamento.TabIndex = 0;
            this.lblTipoPagamento.Text = "Tipologia di pagamento";
            // 
            // btnAnnulla
            // 
            this.btnAnnulla.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAnnulla.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnAnnulla.Location = new System.Drawing.Point(407, 41);
            this.btnAnnulla.Name = "btnAnnulla";
            this.btnAnnulla.Size = new System.Drawing.Size(75, 23);
            this.btnAnnulla.TabIndex = 4;
            this.btnAnnulla.Text = "Annulla";
            this.btnAnnulla.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Location = new System.Drawing.Point(407, 12);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 3;
            this.btnOK.Tag = "mainsave";
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // Frm_purchasepayment_single
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(494, 257);
            this.Controls.Add(this.btnAnnulla);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.gbxPagamento);
            this.Controls.Add(this.gbxPagoPA);
            this.Controls.Add(this.gbxPagante);
            this.Name = "Frm_purchasepayment_single";
            this.Text = "Frm_purchasepayment_single";
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.gbxPagoPA.ResumeLayout(false);
            this.gbxPagoPA.PerformLayout();
            this.gbxPagante.ResumeLayout(false);
            this.gbxPagante.PerformLayout();
            this.gbxPagamento.ResumeLayout(false);
            this.gbxPagamento.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public vistaForm DS;
        private System.Windows.Forms.GroupBox gbxPagoPA;
        private System.Windows.Forms.TextBox txtCCP;
        private System.Windows.Forms.Label lblCCP;
        private System.Windows.Forms.TextBox txtIUV;
        private System.Windows.Forms.Label lblIUV;
        private System.Windows.Forms.GroupBox gbxPagante;
        private System.Windows.Forms.TextBox txtCliente;
        private System.Windows.Forms.GroupBox gbxPagamento;
        private System.Windows.Forms.ComboBox cmbTipoPagamento;
        private System.Windows.Forms.Label lblTipoPagamento;
        private System.Windows.Forms.CheckBox chkCompletato;
        private System.Windows.Forms.TextBox txtIBAN;
        private System.Windows.Forms.Label lblIBAN;
        private System.Windows.Forms.Button btnAnnulla;
        private System.Windows.Forms.Button btnOK;
    }
}