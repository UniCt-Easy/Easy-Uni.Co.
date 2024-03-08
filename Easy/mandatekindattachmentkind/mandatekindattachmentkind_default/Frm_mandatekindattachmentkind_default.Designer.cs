
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


namespace mandatekindattachmentkind_default {
    partial class Frm_mandatekindattachmentkind_default {
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
            this.DS = new mandatekindattachmentkind_default.vistaForm();
            this.cmbCodiceAllegato = new System.Windows.Forms.ComboBox();
            this.grpTipoallegato = new System.Windows.Forms.GroupBox();
            this.chkAllegatoObbligatorio = new System.Windows.Forms.CheckBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnAnnulla = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.grpTipoallegato.SuspendLayout();
            this.SuspendLayout();
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.EnforceConstraints = false;
            // 
            // cmbCodiceAllegato
            // 
            this.cmbCodiceAllegato.DataSource = this.DS.attachmentkind;
            this.cmbCodiceAllegato.DisplayMember = "title";
            this.cmbCodiceAllegato.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCodiceAllegato.FormattingEnabled = true;
            this.cmbCodiceAllegato.Location = new System.Drawing.Point(5, 19);
            this.cmbCodiceAllegato.Name = "cmbCodiceAllegato";
            this.cmbCodiceAllegato.Size = new System.Drawing.Size(416, 21);
            this.cmbCodiceAllegato.TabIndex = 0;
            this.cmbCodiceAllegato.Tag = "mandatekindattachmentkind.idattachmentkind";
            this.cmbCodiceAllegato.ValueMember = "idattachmentkind";
            // 
            // grpTipoallegato
            // 
            this.grpTipoallegato.Controls.Add(this.cmbCodiceAllegato);
            this.grpTipoallegato.Location = new System.Drawing.Point(12, 12);
            this.grpTipoallegato.Name = "grpTipoallegato";
            this.grpTipoallegato.Size = new System.Drawing.Size(427, 50);
            this.grpTipoallegato.TabIndex = 27;
            this.grpTipoallegato.TabStop = false;
            this.grpTipoallegato.Text = "Tipo di documento allegato";
            // 
            // chkAllegatoObbligatorio
            // 
            this.chkAllegatoObbligatorio.ForeColor = System.Drawing.Color.DarkRed;
            this.chkAllegatoObbligatorio.Location = new System.Drawing.Point(179, 82);
            this.chkAllegatoObbligatorio.Name = "chkAllegatoObbligatorio";
            this.chkAllegatoObbligatorio.Size = new System.Drawing.Size(214, 24);
            this.chkAllegatoObbligatorio.TabIndex = 29;
            this.chkAllegatoObbligatorio.Tag = "mandatekindattachmentkind.mandatory:S:N";
            this.chkAllegatoObbligatorio.Text = "Tipo allegato obbligatorio";
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(271, 155);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 30;
            this.btnOk.TabStop = false;
            this.btnOk.Tag = "mainsave";
            this.btnOk.Text = "Ok";
            // 
            // btnAnnulla
            // 
            this.btnAnnulla.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAnnulla.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnAnnulla.Location = new System.Drawing.Point(375, 155);
            this.btnAnnulla.Name = "btnAnnulla";
            this.btnAnnulla.Size = new System.Drawing.Size(75, 23);
            this.btnAnnulla.TabIndex = 31;
            this.btnAnnulla.TabStop = false;
            this.btnAnnulla.Text = "Annulla";
            // 
            // Frm_mandatekindattachmentkind_default
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(462, 199);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnAnnulla);
            this.Controls.Add(this.chkAllegatoObbligatorio);
            this.Controls.Add(this.grpTipoallegato);
            this.Name = "Frm_mandatekindattachmentkind_default";
            this.Text = "Frm_mandatekindattachmentkind_default";
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.grpTipoallegato.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public vistaForm DS;
        private System.Windows.Forms.ComboBox cmbCodiceAllegato;
        private System.Windows.Forms.GroupBox grpTipoallegato;
        private System.Windows.Forms.CheckBox chkAllegatoObbligatorio;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnAnnulla;
    }
}
