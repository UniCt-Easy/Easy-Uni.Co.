
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


namespace siopekind_default {
    partial class Frm_siopekind_default {
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
            this.txtEserc = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSiopeEntrate = new System.Windows.Forms.TextBox();
            this.txtSiopeSpese = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ckbCassierePredefinito = new System.Windows.Forms.CheckBox();
            this.DS = new siopekind_default.vistaForm();
            this.btnAnnulla = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.SuspendLayout();
            // 
            // txtEserc
            // 
            this.txtEserc.Location = new System.Drawing.Point(100, 15);
            this.txtEserc.Name = "txtEserc";
            this.txtEserc.Size = new System.Drawing.Size(56, 20);
            this.txtEserc.TabIndex = 3;
            this.txtEserc.Tag = "siopekind.ayear.year";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(36, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Esercizio:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(16, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 22);
            this.label2.TabIndex = 78;
            this.label2.Text = "Siope Entrate";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtSiopeEntrate
            // 
            this.txtSiopeEntrate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSiopeEntrate.Location = new System.Drawing.Point(100, 40);
            this.txtSiopeEntrate.Name = "txtSiopeEntrate";
            this.txtSiopeEntrate.Size = new System.Drawing.Size(148, 20);
            this.txtSiopeEntrate.TabIndex = 75;
            this.txtSiopeEntrate.Tag = "siopekind.codesorkind_siopeentrate";
            // 
            // txtSiopeSpese
            // 
            this.txtSiopeSpese.Location = new System.Drawing.Point(348, 40);
            this.txtSiopeSpese.Multiline = true;
            this.txtSiopeSpese.Name = "txtSiopeSpese";
            this.txtSiopeSpese.Size = new System.Drawing.Size(148, 20);
            this.txtSiopeSpese.TabIndex = 76;
            this.txtSiopeSpese.Tag = "siopekind.codesorkind_siopespese";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(268, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 22);
            this.label3.TabIndex = 77;
            this.label3.Text = "Siope Spese";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ckbCassierePredefinito
            // 
            this.ckbCassierePredefinito.Location = new System.Drawing.Point(100, 76);
            this.ckbCassierePredefinito.Name = "ckbCassierePredefinito";
            this.ckbCassierePredefinito.Size = new System.Drawing.Size(317, 23);
            this.ckbCassierePredefinito.TabIndex = 79;
            this.ckbCassierePredefinito.Tag = "siopekind.newcomputesorting:S:N";
            this.ckbCassierePredefinito.Text = "Genera classificazioni automatiche da causali EP";
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
            this.btnAnnulla.Location = new System.Drawing.Point(423, 129);
            this.btnAnnulla.Name = "btnAnnulla";
            this.btnAnnulla.Size = new System.Drawing.Size(75, 23);
            this.btnAnnulla.TabIndex = 81;
            this.btnAnnulla.Text = "Annulla";
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(342, 129);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 80;
            this.btnOK.Tag = "mainsave";
            this.btnOK.Text = "OK";
            // 
            // Frm_siopekind_default
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(510, 164);
            this.Controls.Add(this.btnAnnulla);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.ckbCassierePredefinito);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtSiopeEntrate);
            this.Controls.Add(this.txtSiopeSpese);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtEserc);
            this.Controls.Add(this.label1);
            this.Name = "Frm_siopekind_default";
            this.Text = "Frm_siopekind_default";
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtEserc;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSiopeEntrate;
        private System.Windows.Forms.TextBox txtSiopeSpese;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox ckbCassierePredefinito;
        public vistaForm DS;
        private System.Windows.Forms.Button btnAnnulla;
        private System.Windows.Forms.Button btnOK;
    }
}
