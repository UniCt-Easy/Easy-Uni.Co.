
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


namespace accountenactment_default {
    partial class AskConfirm {
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
            this.BtnAnnulla = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.grpUpdateAdate = new System.Windows.Forms.GroupBox();
            this.rdb_do_update_approved_accountvar_adate = new System.Windows.Forms.RadioButton();
            this.rdb_do_update_all_accountvar_adate = new System.Windows.Forms.RadioButton();
            this.chk_do_update_accountvar = new System.Windows.Forms.CheckBox();
            this.chk_do_update_enactment = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.grpUpdateAdate.SuspendLayout();
            this.SuspendLayout();
            // 
            // BtnAnnulla
            // 
            this.BtnAnnulla.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnAnnulla.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnAnnulla.Location = new System.Drawing.Point(441, 196);
            this.BtnAnnulla.Name = "BtnAnnulla";
            this.BtnAnnulla.Size = new System.Drawing.Size(75, 23);
            this.BtnAnnulla.TabIndex = 19;
            this.BtnAnnulla.Text = "Annulla";
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(343, 196);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 18;
            this.btnOk.Text = "Ok";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.grpUpdateAdate);
            this.groupBox1.Controls.Add(this.chk_do_update_accountvar);
            this.groupBox1.Controls.Add(this.chk_do_update_enactment);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(499, 166);
            this.groupBox1.TabIndex = 20;
            this.groupBox1.TabStop = false;
            // 
            // grpUpdateAdate
            // 
            this.grpUpdateAdate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpUpdateAdate.Controls.Add(this.rdb_do_update_approved_accountvar_adate);
            this.grpUpdateAdate.Controls.Add(this.rdb_do_update_all_accountvar_adate);
            this.grpUpdateAdate.Location = new System.Drawing.Point(10, 74);
            this.grpUpdateAdate.Name = "grpUpdateAdate";
            this.grpUpdateAdate.Size = new System.Drawing.Size(476, 78);
            this.grpUpdateAdate.TabIndex = 4;
            this.grpUpdateAdate.TabStop = false;
            // 
            // rdb_do_update_approved_accountvar_adate
            // 
            this.rdb_do_update_approved_accountvar_adate.AutoSize = true;
            this.rdb_do_update_approved_accountvar_adate.Location = new System.Drawing.Point(13, 17);
            this.rdb_do_update_approved_accountvar_adate.Name = "rdb_do_update_approved_accountvar_adate";
            this.rdb_do_update_approved_accountvar_adate.Size = new System.Drawing.Size(443, 17);
            this.rdb_do_update_approved_accountvar_adate.TabIndex = 5;
            this.rdb_do_update_approved_accountvar_adate.TabStop = true;
            this.rdb_do_update_approved_accountvar_adate.Text = "Si desidera aggiornare la data contabile delle variazioni non approvate del prese" +
    "nte atto?";
            this.rdb_do_update_approved_accountvar_adate.UseVisualStyleBackColor = true;
            // 
            // rdb_do_update_all_accountvar_adate
            // 
            this.rdb_do_update_all_accountvar_adate.AutoSize = true;
            this.rdb_do_update_all_accountvar_adate.Location = new System.Drawing.Point(13, 45);
            this.rdb_do_update_all_accountvar_adate.Name = "rdb_do_update_all_accountvar_adate";
            this.rdb_do_update_all_accountvar_adate.Size = new System.Drawing.Size(313, 17);
            this.rdb_do_update_all_accountvar_adate.TabIndex = 4;
            this.rdb_do_update_all_accountvar_adate.TabStop = true;
            this.rdb_do_update_all_accountvar_adate.Text = "Si desidera aggiornare la data contabile  di tutte le variazioni?";
            this.rdb_do_update_all_accountvar_adate.UseVisualStyleBackColor = true;
            // 
            // chk_do_update_accountvar
            // 
            this.chk_do_update_accountvar.AutoSize = true;
            this.chk_do_update_accountvar.Location = new System.Drawing.Point(16, 46);
            this.chk_do_update_accountvar.Name = "chk_do_update_accountvar";
            this.chk_do_update_accountvar.Size = new System.Drawing.Size(290, 17);
            this.chk_do_update_accountvar.TabIndex = 1;
            this.chk_do_update_accountvar.Text = "Si desidera aggiornare la data contabile delle variazioni?";
            this.chk_do_update_accountvar.UseVisualStyleBackColor = true;
            this.chk_do_update_accountvar.CheckedChanged += new System.EventHandler(this.chk_do_update_accountvar_CheckedChanged);
            // 
            // chk_do_update_enactment
            // 
            this.chk_do_update_enactment.AutoSize = true;
            this.chk_do_update_enactment.Location = new System.Drawing.Point(16, 18);
            this.chk_do_update_enactment.Name = "chk_do_update_enactment";
            this.chk_do_update_enactment.Size = new System.Drawing.Size(320, 17);
            this.chk_do_update_enactment.TabIndex = 0;
            this.chk_do_update_enactment.Text = "Si desidera aggiornare data e numero provvedimento dell\'atto?";
            this.chk_do_update_enactment.UseVisualStyleBackColor = true;
            // 
            // AskConfirm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(528, 231);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.BtnAnnulla);
            this.Controls.Add(this.btnOk);
            this.Name = "AskConfirm";
            this.Text = "Conferma";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.grpUpdateAdate.ResumeLayout(false);
            this.grpUpdateAdate.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BtnAnnulla;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox grpUpdateAdate;
        public System.Windows.Forms.CheckBox chk_do_update_accountvar;
        public System.Windows.Forms.CheckBox chk_do_update_enactment;
        public System.Windows.Forms.RadioButton rdb_do_update_approved_accountvar_adate;
        public System.Windows.Forms.RadioButton rdb_do_update_all_accountvar_adate;
    }
}
