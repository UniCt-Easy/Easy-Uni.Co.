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

﻿namespace ct_asscreddetail_single {
    partial class Frm_ct_asscreddetail_single {
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
            this.grpBilancioSpesa = new System.Windows.Forms.GroupBox();
            this.txtDescrBilancioSpesa = new System.Windows.Forms.TextBox();
            this.txtBilancioSpesa = new System.Windows.Forms.TextBox();
            this.btnBilancioSpesa = new System.Windows.Forms.Button();
            this.txtPercentuale = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.DS = new ct_asscreddetail_single.vistaForm();
            this.btnAnnulla = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.grpBilancioSpesa.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.SuspendLayout();
            // 
            // grpBilancioSpesa
            // 
            this.grpBilancioSpesa.Controls.Add(this.txtDescrBilancioSpesa);
            this.grpBilancioSpesa.Controls.Add(this.txtBilancioSpesa);
            this.grpBilancioSpesa.Controls.Add(this.btnBilancioSpesa);
            this.grpBilancioSpesa.Location = new System.Drawing.Point(19, 33);
            this.grpBilancioSpesa.Name = "grpBilancioSpesa";
            this.grpBilancioSpesa.Size = new System.Drawing.Size(348, 112);
            this.grpBilancioSpesa.TabIndex = 39;
            this.grpBilancioSpesa.TabStop = false;
            this.grpBilancioSpesa.Tag = "AutoManage.txtBilancioSpesa.treeS";
            this.grpBilancioSpesa.Text = "Voce di bilancio di spesa";
            // 
            // txtDescrBilancioSpesa
            // 
            this.txtDescrBilancioSpesa.Location = new System.Drawing.Point(126, 16);
            this.txtDescrBilancioSpesa.Multiline = true;
            this.txtDescrBilancioSpesa.Name = "txtDescrBilancioSpesa";
            this.txtDescrBilancioSpesa.ReadOnly = true;
            this.txtDescrBilancioSpesa.Size = new System.Drawing.Size(217, 64);
            this.txtDescrBilancioSpesa.TabIndex = 54;
            this.txtDescrBilancioSpesa.TabStop = false;
            this.txtDescrBilancioSpesa.Tag = "fin.title";
            this.txtDescrBilancioSpesa.TextChanged += new System.EventHandler(this.txtDescrBilancioSpesa_TextChanged);
            // 
            // txtBilancioSpesa
            // 
            this.txtBilancioSpesa.Location = new System.Drawing.Point(8, 86);
            this.txtBilancioSpesa.Name = "txtBilancioSpesa";
            this.txtBilancioSpesa.Size = new System.Drawing.Size(335, 20);
            this.txtBilancioSpesa.TabIndex = 52;
            this.txtBilancioSpesa.Tag = "fin.codefin?ct_asscreddetailview.finexpensecode";
            // 
            // btnBilancioSpesa
            // 
            this.btnBilancioSpesa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBilancioSpesa.ImageIndex = 0;
            this.btnBilancioSpesa.Location = new System.Drawing.Point(8, 60);
            this.btnBilancioSpesa.Name = "btnBilancioSpesa";
            this.btnBilancioSpesa.Size = new System.Drawing.Size(112, 20);
            this.btnBilancioSpesa.TabIndex = 62;
            this.btnBilancioSpesa.TabStop = false;
            this.btnBilancioSpesa.Tag = "manage.fin.treeS";
            this.btnBilancioSpesa.Text = "Bilancio:";
            // 
            // txtPercentuale
            // 
            this.txtPercentuale.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPercentuale.Location = new System.Drawing.Point(287, 151);
            this.txtPercentuale.Name = "txtPercentuale";
            this.txtPercentuale.Size = new System.Drawing.Size(72, 20);
            this.txtPercentuale.TabIndex = 73;
            this.txtPercentuale.Tag = "ct_asscreddetail.quota.fixed.2..%.100";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.Location = new System.Drawing.Point(119, 151);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(160, 16);
            this.label2.TabIndex = 74;
            this.label2.Text = "Percentuale di assegnazione:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.EnforceConstraints = false;
            // 
            // btnAnnulla
            // 
            this.btnAnnulla.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAnnulla.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnAnnulla.Location = new System.Drawing.Point(282, 233);
            this.btnAnnulla.Name = "btnAnnulla";
            this.btnAnnulla.Size = new System.Drawing.Size(75, 24);
            this.btnAnnulla.TabIndex = 76;
            this.btnAnnulla.Text = "Annulla";
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(178, 233);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 24);
            this.btnOK.TabIndex = 75;
            this.btnOK.Tag = "mainsave";
            this.btnOK.Text = "OK";
            // 
            // Frm_ct_asscreddetail_single
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(381, 269);
            this.Controls.Add(this.btnAnnulla);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.txtPercentuale);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.grpBilancioSpesa);
            this.Name = "Frm_ct_asscreddetail_single";
            this.Text = "Frm_ct_asscreddetail_single";
            this.grpBilancioSpesa.ResumeLayout(false);
            this.grpBilancioSpesa.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grpBilancioSpesa;
        private System.Windows.Forms.TextBox txtDescrBilancioSpesa;
        private System.Windows.Forms.TextBox txtBilancioSpesa;
        private System.Windows.Forms.Button btnBilancioSpesa;
        private System.Windows.Forms.TextBox txtPercentuale;
        private System.Windows.Forms.Label label2;
        public vistaForm DS;
        private System.Windows.Forms.Button btnAnnulla;
        private System.Windows.Forms.Button btnOK;
    }
}