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

﻿namespace invoice_default {
    partial class FrmAskStatoDelDebito {
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.cmbStatodeldebito = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCasuale = new System.Windows.Forms.Button();
            this.txtCausale = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(413, 237);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 15;
            this.btnCancel.Text = "Cancel";
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(301, 237);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 14;
            this.btnOK.Text = "Ok";
            // 
            // cmbStatodeldebito
            // 
            this.cmbStatodeldebito.Location = new System.Drawing.Point(26, 69);
            this.cmbStatodeldebito.Name = "cmbStatodeldebito";
            this.cmbStatodeldebito.Size = new System.Drawing.Size(462, 21);
            this.cmbStatodeldebito.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(23, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(465, 22);
            this.label1.TabIndex = 12;
            this.label1.Text = "Indicare lo Stato del Debito da attribuire ai dettagli del documento";
            // 
            // btnCasuale
            // 
            this.btnCasuale.BackColor = System.Drawing.SystemColors.Control;
            this.btnCasuale.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCasuale.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnCasuale.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCasuale.ImageIndex = 0;
            this.btnCasuale.Location = new System.Drawing.Point(26, 117);
            this.btnCasuale.Name = "btnCasuale";
            this.btnCasuale.Size = new System.Drawing.Size(57, 23);
            this.btnCasuale.TabIndex = 25;
            this.btnCasuale.TabStop = false;
            this.btnCasuale.Tag = "";
            this.btnCasuale.Text = "Causale";
            this.btnCasuale.UseVisualStyleBackColor = false;
            this.btnCasuale.Click += new System.EventHandler(this.btnCasuale_Click);
            // 
            // txtCausale
            // 
            this.txtCausale.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCausale.Location = new System.Drawing.Point(26, 146);
            this.txtCausale.Multiline = true;
            this.txtCausale.Name = "txtCausale";
            this.txtCausale.ReadOnly = true;
            this.txtCausale.Size = new System.Drawing.Size(463, 69);
            this.txtCausale.TabIndex = 26;
            this.txtCausale.TabStop = false;
            this.txtCausale.Tag = "";
            // 
            // FrmAskStatoDelDebito
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(582, 282);
            this.Controls.Add(this.btnCasuale);
            this.Controls.Add(this.txtCausale);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.cmbStatodeldebito);
            this.Controls.Add(this.label1);
            this.Name = "FrmAskStatoDelDebito";
            this.Text = "Stato del Debito";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        public System.Windows.Forms.ComboBox cmbStatodeldebito;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCasuale;
        private System.Windows.Forms.TextBox txtCausale;
    }
}