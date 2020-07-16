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

﻿namespace ep_functions {
    partial class frmAskCostPartitionDetail {
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
            this.txtDenominazione = new System.Windows.Forms.TextBox();
            this.txtCodice = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdbPercentuali = new System.Windows.Forms.RadioButton();
            this.rdbCosti = new System.Windows.Forms.RadioButton();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.chkAttivo = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtDenominazione
            // 
            this.txtDenominazione.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDenominazione.Location = new System.Drawing.Point(15, 123);
            this.txtDenominazione.Multiline = true;
            this.txtDenominazione.Name = "txtDenominazione";
            this.txtDenominazione.Size = new System.Drawing.Size(469, 64);
            this.txtDenominazione.TabIndex = 36;
            this.txtDenominazione.Tag = "costpartition.title";
            // 
            // txtCodice
            // 
            this.txtCodice.Location = new System.Drawing.Point(12, 74);
            this.txtCodice.Name = "txtCodice";
            this.txtCodice.Size = new System.Drawing.Size(174, 20);
            this.txtCodice.TabIndex = 37;
            this.txtCodice.Tag = "costpartition.costpartitioncode";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(9, 59);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 16);
            this.label5.TabIndex = 39;
            this.label5.Text = "Codice:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(15, 107);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 16);
            this.label2.TabIndex = 38;
            this.label2.Text = "Denominazione:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdbPercentuali);
            this.groupBox1.Controls.Add(this.rdbCosti);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(191, 45);
            this.groupBox1.TabIndex = 40;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tipo Ripartizione";
            // 
            // rdbPercentuali
            // 
            this.rdbPercentuali.AutoSize = true;
            this.rdbPercentuali.Location = new System.Drawing.Point(103, 15);
            this.rdbPercentuali.Name = "rdbPercentuali";
            this.rdbPercentuali.Size = new System.Drawing.Size(78, 17);
            this.rdbPercentuali.TabIndex = 4;
            this.rdbPercentuali.Tag = "costpartition.kind:P";
            this.rdbPercentuali.Text = "Percentuali";
            this.rdbPercentuali.UseVisualStyleBackColor = true;
            // 
            // rdbCosti
            // 
            this.rdbCosti.Checked = true;
            this.rdbCosti.Location = new System.Drawing.Point(26, 16);
            this.rdbCosti.Name = "rdbCosti";
            this.rdbCosti.Size = new System.Drawing.Size(71, 16);
            this.rdbCosti.TabIndex = 0;
            this.rdbCosti.TabStop = true;
            this.rdbCosti.Tag = "costpartition.kind:C";
            this.rdbCosti.Text = "Costi";
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button1.Location = new System.Drawing.Point(277, 206);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 41;
            this.button1.Text = "Ok";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.Location = new System.Drawing.Point(409, 206);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 42;
            this.button2.Text = "Annulla";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // chkAttivo
            // 
            this.chkAttivo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkAttivo.AutoSize = true;
            this.chkAttivo.CheckAlign = System.Drawing.ContentAlignment.TopRight;
            this.chkAttivo.Checked = true;
            this.chkAttivo.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAttivo.Location = new System.Drawing.Point(430, 12);
            this.chkAttivo.Name = "chkAttivo";
            this.chkAttivo.Size = new System.Drawing.Size(53, 17);
            this.chkAttivo.TabIndex = 346;
            this.chkAttivo.TabStop = false;
            this.chkAttivo.Tag = "costpartition.active:S:N";
            this.chkAttivo.Text = "Attiva";
            this.chkAttivo.UseVisualStyleBackColor = true;
            // 
            // frmAskCostPartitionDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(495, 241);
            this.Controls.Add(this.chkAttivo);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtDenominazione);
            this.Controls.Add(this.txtCodice);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Name = "frmAskCostPartitionDetail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Importazione ripartizione costi";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox txtDenominazione;
        public System.Windows.Forms.TextBox txtCodice;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.RadioButton rdbPercentuali;
        public System.Windows.Forms.RadioButton rdbCosti;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        public System.Windows.Forms.CheckBox chkAttivo;
    }
}