/*
    Easy
    Copyright (C) 2019 Università degli Studi di Catania (www.unict.it)

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

ï»¿namespace registryspecialcategory770_detail {
    partial class Frm_registryspecialcategory770_detail {
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
            this.txtAppunti = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.cmbTipologia = new System.Windows.Forms.ComboBox();
            this.DS = new registryspecialcategory770_detail.vistaForm();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAnnulla = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.SuspendLayout();
            // 
            // txtAppunti
            // 
            this.txtAppunti.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtAppunti.Location = new System.Drawing.Point(101, 72);
            this.txtAppunti.Multiline = true;
            this.txtAppunti.Name = "txtAppunti";
            this.txtAppunti.Size = new System.Drawing.Size(320, 44);
            this.txtAppunti.TabIndex = 80;
            this.txtAppunti.Tag = "registryspecialcategory770.description";
            this.txtAppunti.TextChanged += new System.EventHandler(this.txtAppunti_TextChanged_1);
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(17, 65);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(72, 27);
            this.label11.TabIndex = 76;
            this.label11.Text = "Descrizione";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbTipologia
            // 
            this.cmbTipologia.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cmbTipologia.DataSource = this.DS.specialcategory770;
            this.cmbTipologia.DisplayMember = "description";
            this.cmbTipologia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipologia.Location = new System.Drawing.Point(25, 40);
            this.cmbTipologia.Name = "cmbTipologia";
            this.cmbTipologia.Size = new System.Drawing.Size(750, 21);
            this.cmbTipologia.TabIndex = 79;
            this.cmbTipologia.Tag = "registryspecialcategory770.idspecialcategory770";
            this.cmbTipologia.ValueMember = "idspecialcategory770";
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.EnforceConstraints = false;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(17, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 20);
            this.label1.TabIndex = 75;
            this.label1.Text = "Tipologia";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnAnnulla
            // 
            this.btnAnnulla.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAnnulla.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnAnnulla.Location = new System.Drawing.Point(703, 106);
            this.btnAnnulla.Name = "btnAnnulla";
            this.btnAnnulla.Size = new System.Drawing.Size(72, 24);
            this.btnAnnulla.TabIndex = 82;
            this.btnAnnulla.Text = "Annulla";
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(605, 106);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(72, 24);
            this.btnOk.TabIndex = 81;
            this.btnOk.Tag = "mainsave";
            this.btnOk.Text = "OK";
            // 
            // Frm_registryspecialcategory770_detail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(811, 142);
            this.Controls.Add(this.btnAnnulla);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.cmbTipologia);
            this.Controls.Add(this.txtAppunti);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label11);
            this.Name = "Frm_registryspecialcategory770_detail";
            this.Text = "Frm_registryspecialcategory770_detail";
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtAppunti;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cmbTipologia;
        private System.Windows.Forms.Label label1;
        public vistaForm DS;
        private System.Windows.Forms.Button btnAnnulla;
        private System.Windows.Forms.Button btnOk;

    }
}