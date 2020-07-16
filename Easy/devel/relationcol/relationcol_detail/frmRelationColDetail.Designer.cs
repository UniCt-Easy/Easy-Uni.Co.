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

﻿namespace relationcol_detail {
    partial class frmRelationColDetail {
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
            this.txtRelazione = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.DS = new relationcol_detail.vistaForm();
            this.cmbParentCol = new System.Windows.Forms.ComboBox();
            this.cmbChildCol = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnAnnulla = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.SuspendLayout();
            // 
            // txtRelazione
            // 
            this.txtRelazione.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRelazione.Location = new System.Drawing.Point(12, 26);
            this.txtRelazione.Name = "txtRelazione";
            this.txtRelazione.Size = new System.Drawing.Size(426, 20);
            this.txtRelazione.TabIndex = 9;
            this.txtRelazione.Tag = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Nome relazione";
            // 
            // DS
            // 
            this.DS.DataSetName = "dsmeta";
            this.DS.EnforceConstraints = false;
            // 
            // cmbParentCol
            // 
            this.cmbParentCol.DataSource = this.DS.coldescr;
            this.cmbParentCol.DisplayMember = "colname";
            this.cmbParentCol.FormattingEnabled = true;
            this.cmbParentCol.Location = new System.Drawing.Point(12, 82);
            this.cmbParentCol.Name = "cmbParentCol";
            this.cmbParentCol.Size = new System.Drawing.Size(261, 21);
            this.cmbParentCol.TabIndex = 10;
            this.cmbParentCol.Tag = "relationcol.parentcol";
            this.cmbParentCol.ValueMember = "colname";
            // 
            // cmbChildCol
            // 
            this.cmbChildCol.DataSource = this.DS.coldescr1;
            this.cmbChildCol.DisplayMember = "colname";
            this.cmbChildCol.FormattingEnabled = true;
            this.cmbChildCol.Location = new System.Drawing.Point(15, 152);
            this.cmbChildCol.Name = "cmbChildCol";
            this.cmbChildCol.Size = new System.Drawing.Size(261, 21);
            this.cmbChildCol.TabIndex = 11;
            this.cmbChildCol.Tag = "relationcol.childcol";
            this.cmbChildCol.ValueMember = "colname";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Da Colonna";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 136);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "A Colonna";
            // 
            // btnAnnulla
            // 
            this.btnAnnulla.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnAnnulla.Location = new System.Drawing.Point(235, 196);
            this.btnAnnulla.Name = "btnAnnulla";
            this.btnAnnulla.Size = new System.Drawing.Size(75, 23);
            this.btnAnnulla.TabIndex = 43;
            this.btnAnnulla.Text = "Annulla";
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(122, 196);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 42;
            this.btnOK.Tag = "mainsave";
            this.btnOK.Text = "OK";
            // 
            // frmRelationColDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(472, 240);
            this.Controls.Add(this.btnAnnulla);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbChildCol);
            this.Controls.Add(this.cmbParentCol);
            this.Controls.Add(this.txtRelazione);
            this.Controls.Add(this.label3);
            this.Name = "frmRelationColDetail";
            this.Text = "frmRelationColDetail";
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public vistaForm DS;
        private System.Windows.Forms.TextBox txtRelazione;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbParentCol;
        private System.Windows.Forms.ComboBox cmbChildCol;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnAnnulla;
        private System.Windows.Forms.Button btnOK;
    }
}