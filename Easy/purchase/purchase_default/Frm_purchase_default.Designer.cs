
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


namespace purchase_default {
    partial class Frm_purchase_default {
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
            this.DS = new purchase_default.vistaForm();
            this.gboxCliente = new System.Windows.Forms.GroupBox();
            this.txtCliente = new System.Windows.Forms.TextBox();
            this.gboxVendita = new System.Windows.Forms.GroupBox();
            this.txtData = new System.Windows.Forms.TextBox();
            this.txtNumero = new System.Windows.Forms.TextBox();
            this.lblData = new System.Windows.Forms.Label();
            this.lblNumero = new System.Windows.Forms.Label();
            this.tabInfo = new System.Windows.Forms.TabControl();
            this.tabDettagli = new System.Windows.Forms.TabPage();
            this.btnEliminaDettaglio = new System.Windows.Forms.Button();
            this.gridDettagli = new System.Windows.Forms.DataGrid();
            this.btnInserisciDettaglio = new System.Windows.Forms.Button();
            this.btnModificaDettaglio = new System.Windows.Forms.Button();
            this.tabVersamenti = new System.Windows.Forms.TabPage();
            this.btnEliminaVersamento = new System.Windows.Forms.Button();
            this.gridVersamento = new System.Windows.Forms.DataGrid();
            this.btnInserisciVersamento = new System.Windows.Forms.Button();
            this.btnModificaVersamento = new System.Windows.Forms.Button();
            this.tabPagamenti = new System.Windows.Forms.TabPage();
            this.btnEliminaPagamento = new System.Windows.Forms.Button();
            this.gridPagamenti = new System.Windows.Forms.DataGrid();
            this.btnInserisciPagamento = new System.Windows.Forms.Button();
            this.btnModificaPagamento = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.gboxCliente.SuspendLayout();
            this.gboxVendita.SuspendLayout();
            this.tabInfo.SuspendLayout();
            this.tabDettagli.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridDettagli)).BeginInit();
            this.tabVersamenti.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridVersamento)).BeginInit();
            this.tabPagamenti.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridPagamenti)).BeginInit();
            this.SuspendLayout();
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.EnforceConstraints = false;
            // 
            // gboxCliente
            // 
            this.gboxCliente.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gboxCliente.Controls.Add(this.txtCliente);
            this.gboxCliente.Location = new System.Drawing.Point(12, 70);
            this.gboxCliente.Name = "gboxCliente";
            this.gboxCliente.Size = new System.Drawing.Size(585, 52);
            this.gboxCliente.TabIndex = 1;
            this.gboxCliente.TabStop = false;
            this.gboxCliente.Tag = "AutoChoose.txtCliente.lista.(active=\'S\')";
            this.gboxCliente.Text = "Cliente";
            // 
            // txtCliente
            // 
            this.txtCliente.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCliente.Location = new System.Drawing.Point(6, 19);
            this.txtCliente.Name = "txtCliente";
            this.txtCliente.Size = new System.Drawing.Size(573, 20);
            this.txtCliente.TabIndex = 0;
            this.txtCliente.Tag = "registry.title?purchase.registry";
            // 
            // gboxVendita
            // 
            this.gboxVendita.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gboxVendita.Controls.Add(this.txtData);
            this.gboxVendita.Controls.Add(this.txtNumero);
            this.gboxVendita.Controls.Add(this.lblData);
            this.gboxVendita.Controls.Add(this.lblNumero);
            this.gboxVendita.Location = new System.Drawing.Point(12, 12);
            this.gboxVendita.Name = "gboxVendita";
            this.gboxVendita.Size = new System.Drawing.Size(585, 52);
            this.gboxVendita.TabIndex = 0;
            this.gboxVendita.TabStop = false;
            // 
            // txtData
            // 
            this.txtData.Location = new System.Drawing.Point(186, 19);
            this.txtData.Name = "txtData";
            this.txtData.Size = new System.Drawing.Size(86, 20);
            this.txtData.TabIndex = 3;
            this.txtData.Tag = "purchase.adate";
            // 
            // txtNumero
            // 
            this.txtNumero.Location = new System.Drawing.Point(62, 19);
            this.txtNumero.Name = "txtNumero";
            this.txtNumero.Size = new System.Drawing.Size(82, 20);
            this.txtNumero.TabIndex = 1;
            this.txtNumero.Tag = "purchase.idpurchase";
            // 
            // lblData
            // 
            this.lblData.AutoSize = true;
            this.lblData.Location = new System.Drawing.Point(150, 22);
            this.lblData.Name = "lblData";
            this.lblData.Size = new System.Drawing.Size(30, 13);
            this.lblData.TabIndex = 2;
            this.lblData.Text = "Data";
            // 
            // lblNumero
            // 
            this.lblNumero.AutoSize = true;
            this.lblNumero.Location = new System.Drawing.Point(12, 22);
            this.lblNumero.Name = "lblNumero";
            this.lblNumero.Size = new System.Drawing.Size(44, 13);
            this.lblNumero.TabIndex = 0;
            this.lblNumero.Text = "Numero";
            // 
            // tabInfo
            // 
            this.tabInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabInfo.Controls.Add(this.tabDettagli);
            this.tabInfo.Controls.Add(this.tabVersamenti);
            this.tabInfo.Controls.Add(this.tabPagamenti);
            this.tabInfo.Location = new System.Drawing.Point(12, 128);
            this.tabInfo.Name = "tabInfo";
            this.tabInfo.SelectedIndex = 0;
            this.tabInfo.Size = new System.Drawing.Size(585, 261);
            this.tabInfo.TabIndex = 2;
            // 
            // tabDettagli
            // 
            this.tabDettagli.Controls.Add(this.btnEliminaDettaglio);
            this.tabDettagli.Controls.Add(this.gridDettagli);
            this.tabDettagli.Controls.Add(this.btnInserisciDettaglio);
            this.tabDettagli.Controls.Add(this.btnModificaDettaglio);
            this.tabDettagli.Location = new System.Drawing.Point(4, 22);
            this.tabDettagli.Name = "tabDettagli";
            this.tabDettagli.Padding = new System.Windows.Forms.Padding(3);
            this.tabDettagli.Size = new System.Drawing.Size(577, 235);
            this.tabDettagli.TabIndex = 0;
            this.tabDettagli.Text = "Dettagli";
            this.tabDettagli.UseVisualStyleBackColor = true;
            // 
            // btnEliminaDettaglio
            // 
            this.btnEliminaDettaglio.Location = new System.Drawing.Point(6, 78);
            this.btnEliminaDettaglio.Name = "btnEliminaDettaglio";
            this.btnEliminaDettaglio.Size = new System.Drawing.Size(75, 30);
            this.btnEliminaDettaglio.TabIndex = 3;
            this.btnEliminaDettaglio.Tag = "delete.single";
            this.btnEliminaDettaglio.Text = "Elimina";
            this.btnEliminaDettaglio.UseVisualStyleBackColor = true;
            // 
            // gridDettagli
            // 
            this.gridDettagli.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridDettagli.DataMember = "";
            this.gridDettagli.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.gridDettagli.Location = new System.Drawing.Point(87, 6);
            this.gridDettagli.Name = "gridDettagli";
            this.gridDettagli.Size = new System.Drawing.Size(484, 223);
            this.gridDettagli.TabIndex = 0;
            this.gridDettagli.Tag = "purchasedetail.list.single";
            // 
            // btnInserisciDettaglio
            // 
            this.btnInserisciDettaglio.Location = new System.Drawing.Point(6, 6);
            this.btnInserisciDettaglio.Name = "btnInserisciDettaglio";
            this.btnInserisciDettaglio.Size = new System.Drawing.Size(75, 30);
            this.btnInserisciDettaglio.TabIndex = 1;
            this.btnInserisciDettaglio.Tag = "insert.single";
            this.btnInserisciDettaglio.Text = "Inserisci";
            this.btnInserisciDettaglio.UseVisualStyleBackColor = true;
            // 
            // btnModificaDettaglio
            // 
            this.btnModificaDettaglio.Location = new System.Drawing.Point(6, 42);
            this.btnModificaDettaglio.Name = "btnModificaDettaglio";
            this.btnModificaDettaglio.Size = new System.Drawing.Size(75, 30);
            this.btnModificaDettaglio.TabIndex = 2;
            this.btnModificaDettaglio.Tag = "edit.single";
            this.btnModificaDettaglio.Text = "Modifica";
            this.btnModificaDettaglio.UseVisualStyleBackColor = true;
            // 
            // tabVersamenti
            // 
            this.tabVersamenti.Controls.Add(this.btnEliminaVersamento);
            this.tabVersamenti.Controls.Add(this.gridVersamento);
            this.tabVersamenti.Controls.Add(this.btnInserisciVersamento);
            this.tabVersamenti.Controls.Add(this.btnModificaVersamento);
            this.tabVersamenti.Location = new System.Drawing.Point(4, 22);
            this.tabVersamenti.Name = "tabVersamenti";
            this.tabVersamenti.Padding = new System.Windows.Forms.Padding(3);
            this.tabVersamenti.Size = new System.Drawing.Size(577, 235);
            this.tabVersamenti.TabIndex = 1;
            this.tabVersamenti.Text = "Versamenti";
            this.tabVersamenti.UseVisualStyleBackColor = true;
            // 
            // btnEliminaVersamento
            // 
            this.btnEliminaVersamento.Location = new System.Drawing.Point(6, 78);
            this.btnEliminaVersamento.Name = "btnEliminaVersamento";
            this.btnEliminaVersamento.Size = new System.Drawing.Size(75, 30);
            this.btnEliminaVersamento.TabIndex = 3;
            this.btnEliminaVersamento.Tag = "delete.single";
            this.btnEliminaVersamento.Text = "Elimina";
            this.btnEliminaVersamento.UseVisualStyleBackColor = true;
            // 
            // gridVersamento
            // 
            this.gridVersamento.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridVersamento.DataMember = "";
            this.gridVersamento.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.gridVersamento.Location = new System.Drawing.Point(87, 6);
            this.gridVersamento.Name = "gridVersamento";
            this.gridVersamento.Size = new System.Drawing.Size(484, 223);
            this.gridVersamento.TabIndex = 0;
            this.gridVersamento.Tag = "purchasesubmission.list.single";
            // 
            // btnInserisciVersamento
            // 
            this.btnInserisciVersamento.Location = new System.Drawing.Point(6, 6);
            this.btnInserisciVersamento.Name = "btnInserisciVersamento";
            this.btnInserisciVersamento.Size = new System.Drawing.Size(75, 30);
            this.btnInserisciVersamento.TabIndex = 1;
            this.btnInserisciVersamento.Tag = "insert.single";
            this.btnInserisciVersamento.Text = "Inserisci";
            this.btnInserisciVersamento.UseVisualStyleBackColor = true;
            // 
            // btnModificaVersamento
            // 
            this.btnModificaVersamento.Location = new System.Drawing.Point(6, 42);
            this.btnModificaVersamento.Name = "btnModificaVersamento";
            this.btnModificaVersamento.Size = new System.Drawing.Size(75, 30);
            this.btnModificaVersamento.TabIndex = 2;
            this.btnModificaVersamento.Tag = "edit.single";
            this.btnModificaVersamento.Text = "Modifica";
            this.btnModificaVersamento.UseVisualStyleBackColor = true;
            // 
            // tabPagamenti
            // 
            this.tabPagamenti.Controls.Add(this.btnEliminaPagamento);
            this.tabPagamenti.Controls.Add(this.gridPagamenti);
            this.tabPagamenti.Controls.Add(this.btnInserisciPagamento);
            this.tabPagamenti.Controls.Add(this.btnModificaPagamento);
            this.tabPagamenti.Location = new System.Drawing.Point(4, 22);
            this.tabPagamenti.Name = "tabPagamenti";
            this.tabPagamenti.Padding = new System.Windows.Forms.Padding(3);
            this.tabPagamenti.Size = new System.Drawing.Size(577, 235);
            this.tabPagamenti.TabIndex = 2;
            this.tabPagamenti.Text = "Pagamenti";
            this.tabPagamenti.UseVisualStyleBackColor = true;
            // 
            // btnEliminaPagamento
            // 
            this.btnEliminaPagamento.Location = new System.Drawing.Point(6, 78);
            this.btnEliminaPagamento.Name = "btnEliminaPagamento";
            this.btnEliminaPagamento.Size = new System.Drawing.Size(75, 30);
            this.btnEliminaPagamento.TabIndex = 3;
            this.btnEliminaPagamento.Tag = "delete.single";
            this.btnEliminaPagamento.Text = "Elimina";
            this.btnEliminaPagamento.UseVisualStyleBackColor = true;
            // 
            // gridPagamenti
            // 
            this.gridPagamenti.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridPagamenti.DataMember = "";
            this.gridPagamenti.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.gridPagamenti.Location = new System.Drawing.Point(87, 6);
            this.gridPagamenti.Name = "gridPagamenti";
            this.gridPagamenti.Size = new System.Drawing.Size(484, 223);
            this.gridPagamenti.TabIndex = 0;
            this.gridPagamenti.Tag = "purchasepayment.list.single";
            // 
            // btnInserisciPagamento
            // 
            this.btnInserisciPagamento.Location = new System.Drawing.Point(6, 6);
            this.btnInserisciPagamento.Name = "btnInserisciPagamento";
            this.btnInserisciPagamento.Size = new System.Drawing.Size(75, 30);
            this.btnInserisciPagamento.TabIndex = 1;
            this.btnInserisciPagamento.Tag = "insert.single";
            this.btnInserisciPagamento.Text = "Inserisci";
            this.btnInserisciPagamento.UseVisualStyleBackColor = true;
            // 
            // btnModificaPagamento
            // 
            this.btnModificaPagamento.Location = new System.Drawing.Point(6, 42);
            this.btnModificaPagamento.Name = "btnModificaPagamento";
            this.btnModificaPagamento.Size = new System.Drawing.Size(75, 30);
            this.btnModificaPagamento.TabIndex = 2;
            this.btnModificaPagamento.Tag = "edit.single";
            this.btnModificaPagamento.Text = "Modifica";
            this.btnModificaPagamento.UseVisualStyleBackColor = true;
            // 
            // Frm_purchase_default
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(609, 401);
            this.Controls.Add(this.tabInfo);
            this.Controls.Add(this.gboxVendita);
            this.Controls.Add(this.gboxCliente);
            this.Name = "Frm_purchase_default";
            this.Text = "Frm_purchase_default";
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.gboxCliente.ResumeLayout(false);
            this.gboxCliente.PerformLayout();
            this.gboxVendita.ResumeLayout(false);
            this.gboxVendita.PerformLayout();
            this.tabInfo.ResumeLayout(false);
            this.tabDettagli.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridDettagli)).EndInit();
            this.tabVersamenti.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridVersamento)).EndInit();
            this.tabPagamenti.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridPagamenti)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public vistaForm DS;
        private System.Windows.Forms.GroupBox gboxCliente;
        private System.Windows.Forms.TextBox txtCliente;
        private System.Windows.Forms.GroupBox gboxVendita;
        private System.Windows.Forms.TextBox txtData;
        private System.Windows.Forms.TextBox txtNumero;
        private System.Windows.Forms.Label lblNumero;
        private System.Windows.Forms.Label lblData;
        private System.Windows.Forms.TabControl tabInfo;
        private System.Windows.Forms.TabPage tabDettagli;
        private System.Windows.Forms.Button btnEliminaDettaglio;
        private System.Windows.Forms.DataGrid gridDettagli;
        private System.Windows.Forms.Button btnInserisciDettaglio;
        private System.Windows.Forms.Button btnModificaDettaglio;
        private System.Windows.Forms.TabPage tabVersamenti;
        private System.Windows.Forms.Button btnEliminaVersamento;
        private System.Windows.Forms.DataGrid gridVersamento;
        private System.Windows.Forms.Button btnInserisciVersamento;
        private System.Windows.Forms.Button btnModificaVersamento;
        private System.Windows.Forms.TabPage tabPagamenti;
        private System.Windows.Forms.Button btnEliminaPagamento;
        private System.Windows.Forms.DataGrid gridPagamenti;
        private System.Windows.Forms.Button btnInserisciPagamento;
        private System.Windows.Forms.Button btnModificaPagamento;
    }
}
