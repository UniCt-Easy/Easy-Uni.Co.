
/*
Easy
Copyright (C) 2021 Università degli Studi di Catania (www.unict.it)
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


namespace assetload_default{
    partial class FrmAskDescr {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
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
            this.btnOk = new System.Windows.Forms.Button();
            this.grpInvMain = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cmbInv = new System.Windows.Forms.ComboBox();
            this.txtNinv = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.txtYinv = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.btnSeleziona = new System.Windows.Forms.Button();
            this.grpInvMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(636, 86);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 15;
            this.btnCancel.Text = "Cancel";
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(524, 86);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 14;
            this.btnOk.Text = "Ok";
            // 
            // grpInvMain
            // 
            this.grpInvMain.Controls.Add(this.btnSeleziona);
            this.grpInvMain.Controls.Add(this.label10);
            this.grpInvMain.Controls.Add(this.cmbInv);
            this.grpInvMain.Controls.Add(this.txtNinv);
            this.grpInvMain.Controls.Add(this.label19);
            this.grpInvMain.Controls.Add(this.txtYinv);
            this.grpInvMain.Controls.Add(this.label20);
            this.grpInvMain.Location = new System.Drawing.Point(23, 12);
            this.grpInvMain.Name = "grpInvMain";
            this.grpInvMain.Size = new System.Drawing.Size(695, 49);
            this.grpInvMain.TabIndex = 16;
            this.grpInvMain.TabStop = false;
            this.grpInvMain.Text = " Fattura di riferimento";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(135, 19);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(28, 13);
            this.label10.TabIndex = 10;
            this.label10.Text = "Tipo";
            // 
            // cmbInv
            // 
            this.cmbInv.DisplayMember = "description";
            this.cmbInv.Location = new System.Drawing.Point(182, 15);
            this.cmbInv.Name = "cmbInv";
            this.cmbInv.Size = new System.Drawing.Size(258, 21);
            this.cmbInv.TabIndex = 1;
            this.cmbInv.Tag = "";
            this.cmbInv.ValueMember = "idinvkind";
            // 
            // txtNinv
            // 
            this.txtNinv.Location = new System.Drawing.Point(618, 16);
            this.txtNinv.Name = "txtNinv";
            this.txtNinv.Size = new System.Drawing.Size(65, 20);
            this.txtNinv.TabIndex = 3;
            this.txtNinv.Tag = "";
            this.txtNinv.Leave += new System.EventHandler(this.txtNinv_Leave);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(569, 17);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(44, 13);
            this.label19.TabIndex = 8;
            this.label19.Text = "Numero";
            // 
            // txtYinv
            // 
            this.txtYinv.Location = new System.Drawing.Point(501, 15);
            this.txtYinv.Name = "txtYinv";
            this.txtYinv.Size = new System.Drawing.Size(61, 20);
            this.txtYinv.TabIndex = 2;
            this.txtYinv.Tag = "";
            this.txtYinv.Leave += new System.EventHandler(this.txtYinv_Leave);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(446, 18);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(49, 13);
            this.label20.TabIndex = 6;
            this.label20.Text = "Esercizio";
            // 
            // btnSeleziona
            // 
            this.btnSeleziona.Location = new System.Drawing.Point(6, 15);
            this.btnSeleziona.Name = "btnSeleziona";
            this.btnSeleziona.Size = new System.Drawing.Size(123, 23);
            this.btnSeleziona.TabIndex = 11;
            this.btnSeleziona.Text = "Seleziona la fattura";
            this.btnSeleziona.UseVisualStyleBackColor = true;
            this.btnSeleziona.Click += new System.EventHandler(this.btnSeleziona_Click);
            // 
            // FrmAskDescr
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(725, 132);
            this.Controls.Add(this.grpInvMain);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Name = "FrmAskDescr";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Fatture collegate a Cespiti";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmAskDescr_FormClosing);
            this.grpInvMain.ResumeLayout(false);
            this.grpInvMain.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.GroupBox grpInvMain;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cmbInv;
        private System.Windows.Forms.TextBox txtNinv;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox txtYinv;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Button btnSeleziona;
    }
}
