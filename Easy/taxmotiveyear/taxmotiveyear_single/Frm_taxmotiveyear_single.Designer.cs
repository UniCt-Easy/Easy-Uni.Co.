
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


namespace taxmotiveyear_single {
    partial class Frm_taxmotiveyear_single {
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
            this.btnAnnulla = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPrincipale = new System.Windows.Forms.TabPage();
            this.grpPrestazione = new System.Windows.Forms.GroupBox();
            this.btnTipoPrestazione = new System.Windows.Forms.Button();
            this.cmbTipoPrestazione = new System.Windows.Forms.ComboBox();
            this.tabEP = new System.Windows.Forms.TabPage();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.textBox9 = new System.Windows.Forms.TextBox();
            this.txtCodiceCausaleLiq = new System.Windows.Forms.TextBox();
            this.button9 = new System.Windows.Forms.Button();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.textBox11 = new System.Windows.Forms.TextBox();
            this.txtCodiceCausaleDebit = new System.Windows.Forms.TextBox();
            this.button10 = new System.Windows.Forms.Button();
            this.grpCausale = new System.Windows.Forms.GroupBox();
            this.txtDescrizioneCausale = new System.Windows.Forms.TextBox();
            this.txtCodiceCausale = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.DS = new taxmotiveyear_single.vistaForm();
            this.tabControl1.SuspendLayout();
            this.tabPrincipale.SuspendLayout();
            this.grpPrestazione.SuspendLayout();
            this.tabEP.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.grpCausale.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAnnulla
            // 
            this.btnAnnulla.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnAnnulla.Location = new System.Drawing.Point(349, 321);
            this.btnAnnulla.Name = "btnAnnulla";
            this.btnAnnulla.Size = new System.Drawing.Size(75, 23);
            this.btnAnnulla.TabIndex = 14;
            this.btnAnnulla.Text = "Annulla";
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(450, 321);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 13;
            this.btnOK.Tag = "mainsave";
            this.btnOK.Text = "OK";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPrincipale);
            this.tabControl1.Controls.Add(this.tabEP);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(517, 293);
            this.tabControl1.TabIndex = 15;
            // 
            // tabPrincipale
            // 
            this.tabPrincipale.Controls.Add(this.grpPrestazione);
            this.tabPrincipale.Location = new System.Drawing.Point(4, 22);
            this.tabPrincipale.Name = "tabPrincipale";
            this.tabPrincipale.Padding = new System.Windows.Forms.Padding(3);
            this.tabPrincipale.Size = new System.Drawing.Size(509, 267);
            this.tabPrincipale.TabIndex = 0;
            this.tabPrincipale.Text = "Principale";
            this.tabPrincipale.UseVisualStyleBackColor = true;
            // 
            // grpPrestazione
            // 
            this.grpPrestazione.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpPrestazione.Controls.Add(this.btnTipoPrestazione);
            this.grpPrestazione.Controls.Add(this.cmbTipoPrestazione);
            this.grpPrestazione.Location = new System.Drawing.Point(6, 18);
            this.grpPrestazione.Name = "grpPrestazione";
            this.grpPrestazione.Size = new System.Drawing.Size(497, 48);
            this.grpPrestazione.TabIndex = 10;
            this.grpPrestazione.TabStop = false;
            this.grpPrestazione.Text = "Prestazione";
            // 
            // btnTipoPrestazione
            // 
            this.btnTipoPrestazione.Location = new System.Drawing.Point(8, 16);
            this.btnTipoPrestazione.Name = "btnTipoPrestazione";
            this.btnTipoPrestazione.Size = new System.Drawing.Size(75, 24);
            this.btnTipoPrestazione.TabIndex = 1;
            this.btnTipoPrestazione.Tag = "manage.service.default";
            this.btnTipoPrestazione.Text = "Tipo";
            // 
            // cmbTipoPrestazione
            // 
            this.cmbTipoPrestazione.DataSource = DS.service;
            this.cmbTipoPrestazione.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbTipoPrestazione.DisplayMember = "description";
            this.cmbTipoPrestazione.ItemHeight = 13;
            this.cmbTipoPrestazione.Location = new System.Drawing.Point(96, 16);
            this.cmbTipoPrestazione.Name = "cmbTipoPrestazione";
            this.cmbTipoPrestazione.Size = new System.Drawing.Size(393, 21);
            this.cmbTipoPrestazione.TabIndex = 2;
            this.cmbTipoPrestazione.Tag = "taxmotiveyear.idser";
            this.cmbTipoPrestazione.ValueMember = "idser";
            // 
            // tabEP
            // 
            this.tabEP.Controls.Add(this.groupBox7);
            this.tabEP.Controls.Add(this.groupBox8);
            this.tabEP.Controls.Add(this.grpCausale);
            this.tabEP.Location = new System.Drawing.Point(4, 22);
            this.tabEP.Name = "tabEP";
            this.tabEP.Padding = new System.Windows.Forms.Padding(3);
            this.tabEP.Size = new System.Drawing.Size(509, 267);
            this.tabEP.TabIndex = 1;
            this.tabEP.Text = "EP";
            this.tabEP.UseVisualStyleBackColor = true;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.textBox9);
            this.groupBox7.Controls.Add(this.txtCodiceCausaleLiq);
            this.groupBox7.Controls.Add(this.button9);
            this.groupBox7.Location = new System.Drawing.Point(7, 180);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(472, 80);
            this.groupBox7.TabIndex = 8;
            this.groupBox7.TabStop = false;
            this.groupBox7.Tag = "AutoManage.txtCodiceCausaleLiq.tree";
            this.groupBox7.Text = "Causale per liquidazione ritenute";
            // 
            // textBox9
            // 
            this.textBox9.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox9.Location = new System.Drawing.Point(191, 16);
            this.textBox9.Multiline = true;
            this.textBox9.Name = "textBox9";
            this.textBox9.ReadOnly = true;
            this.textBox9.Size = new System.Drawing.Size(273, 56);
            this.textBox9.TabIndex = 2;
            this.textBox9.TabStop = false;
            this.textBox9.Tag = "accmotiveapplied_pay.motive";
            // 
            // txtCodiceCausaleLiq
            // 
            this.txtCodiceCausaleLiq.Location = new System.Drawing.Point(8, 48);
            this.txtCodiceCausaleLiq.Name = "txtCodiceCausaleLiq";
            this.txtCodiceCausaleLiq.Size = new System.Drawing.Size(160, 20);
            this.txtCodiceCausaleLiq.TabIndex = 1;
            this.txtCodiceCausaleLiq.Tag = "accmotiveapplied_pay.codemotive?x";
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(64, 16);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(104, 23);
            this.button9.TabIndex = 0;
            this.button9.TabStop = false;
            this.button9.Tag = "manage.accmotiveapplied_pay.tree";
            this.button9.Text = "Causale";
            this.button9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.textBox11);
            this.groupBox8.Controls.Add(this.txtCodiceCausaleDebit);
            this.groupBox8.Controls.Add(this.button10);
            this.groupBox8.Location = new System.Drawing.Point(6, 97);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(472, 83);
            this.groupBox8.TabIndex = 7;
            this.groupBox8.TabStop = false;
            this.groupBox8.Tag = "AutoManage.txtCodiceCausaleDebit.tree";
            this.groupBox8.Text = "Causale applicazione (per rit. carico ente è OPZIONALE)";
            // 
            // textBox11
            // 
            this.textBox11.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox11.Location = new System.Drawing.Point(191, 16);
            this.textBox11.Multiline = true;
            this.textBox11.Name = "textBox11";
            this.textBox11.ReadOnly = true;
            this.textBox11.Size = new System.Drawing.Size(273, 52);
            this.textBox11.TabIndex = 2;
            this.textBox11.TabStop = false;
            this.textBox11.Tag = "accmotiveapplied_debit.motive";
            // 
            // txtCodiceCausaleDebit
            // 
            this.txtCodiceCausaleDebit.Location = new System.Drawing.Point(8, 48);
            this.txtCodiceCausaleDebit.Name = "txtCodiceCausaleDebit";
            this.txtCodiceCausaleDebit.Size = new System.Drawing.Size(160, 20);
            this.txtCodiceCausaleDebit.TabIndex = 1;
            this.txtCodiceCausaleDebit.Tag = "accmotiveapplied_debit.codemotive?x";
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(64, 19);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(104, 23);
            this.button10.TabIndex = 0;
            this.button10.TabStop = false;
            this.button10.Tag = "manage.accmotiveapplied_debit.tree";
            this.button10.Text = "Causale";
            this.button10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // grpCausale
            // 
            this.grpCausale.Controls.Add(this.txtDescrizioneCausale);
            this.grpCausale.Controls.Add(this.txtCodiceCausale);
            this.grpCausale.Controls.Add(this.button2);
            this.grpCausale.Location = new System.Drawing.Point(6, 6);
            this.grpCausale.Name = "grpCausale";
            this.grpCausale.Size = new System.Drawing.Size(472, 92);
            this.grpCausale.TabIndex = 3;
            this.grpCausale.TabStop = false;
            this.grpCausale.Tag = "AutoManage.txtCodiceCausale.tree";
            this.grpCausale.Text = "Causale di Costo";
            // 
            // txtDescrizioneCausale
            // 
            this.txtDescrizioneCausale.Location = new System.Drawing.Point(189, 19);
            this.txtDescrizioneCausale.Multiline = true;
            this.txtDescrizioneCausale.Name = "txtDescrizioneCausale";
            this.txtDescrizioneCausale.ReadOnly = true;
            this.txtDescrizioneCausale.Size = new System.Drawing.Size(275, 56);
            this.txtDescrizioneCausale.TabIndex = 2;
            this.txtDescrizioneCausale.TabStop = false;
            this.txtDescrizioneCausale.Tag = "accmotiveapplied_cost.motive";
            // 
            // txtCodiceCausale
            // 
            this.txtCodiceCausale.Location = new System.Drawing.Point(4, 55);
            this.txtCodiceCausale.Name = "txtCodiceCausale";
            this.txtCodiceCausale.Size = new System.Drawing.Size(162, 20);
            this.txtCodiceCausale.TabIndex = 1;
            this.txtCodiceCausale.Tag = "accmotiveapplied_cost.codemotive?x";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(62, 26);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(104, 23);
            this.button2.TabIndex = 0;
            this.button2.Tag = "manage.accmotiveapplied_cost.tree";
            this.button2.Text = "Causale";
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.EnforceConstraints = false;
            // 
            // Frm_taxmotiveyear_single
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(533, 356);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnAnnulla);
            this.Controls.Add(this.btnOK);
            this.Name = "Frm_taxmotiveyear_single";
            this.Text = "Frm_taxmotiveyear_single";
            this.tabControl1.ResumeLayout(false);
            this.tabPrincipale.ResumeLayout(false);
            this.grpPrestazione.ResumeLayout(false);
            this.tabEP.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.grpCausale.ResumeLayout(false);
            this.grpCausale.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
    
        private System.Windows.Forms.Button btnAnnulla;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPrincipale;
        private System.Windows.Forms.GroupBox grpPrestazione;
        private System.Windows.Forms.Button btnTipoPrestazione;
        private System.Windows.Forms.ComboBox cmbTipoPrestazione;
        private System.Windows.Forms.TabPage tabEP;
        private System.Windows.Forms.GroupBox grpCausale;
        private System.Windows.Forms.TextBox txtDescrizioneCausale;
        private System.Windows.Forms.TextBox txtCodiceCausale;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.TextBox textBox9;
        private System.Windows.Forms.TextBox txtCodiceCausaleLiq;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.TextBox textBox11;
        private System.Windows.Forms.TextBox txtCodiceCausaleDebit;
        private System.Windows.Forms.Button button10;
        public vistaForm DS;
    }
}
