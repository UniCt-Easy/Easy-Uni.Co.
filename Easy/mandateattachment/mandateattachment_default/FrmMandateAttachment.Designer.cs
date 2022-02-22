
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


using metadatalibrary;

namespace mandateattachment_default {
    partial class FrmMandateAttachment {
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.labAutocertFileName = new System.Windows.Forms.Label();
            this.btnVisualizza = new System.Windows.Forms.Button();
            this.btnAllega = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            //this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this._openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.DS = new mandateattachment_default.vistaForm();
            this.grpTipoallegato = new System.Windows.Forms.GroupBox();
            this.cmbCodiceAllegato = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.grpTipoallegato.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.labAutocertFileName);
            this.groupBox1.Location = new System.Drawing.Point(11, 84);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(536, 53);
            this.groupBox1.TabIndex = 81;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "File allegato";
            // 
            // labAutocertFileName
            // 
            this.labAutocertFileName.Location = new System.Drawing.Point(15, 25);
            this.labAutocertFileName.Name = "labAutocertFileName";
            this.labAutocertFileName.Size = new System.Drawing.Size(505, 16);
            this.labAutocertFileName.TabIndex = 75;
            this.labAutocertFileName.Tag = "mandateattachment.filename";
            // 
            // btnVisualizza
            // 
            this.btnVisualizza.Location = new System.Drawing.Point(123, 143);
            this.btnVisualizza.Name = "btnVisualizza";
            this.btnVisualizza.Size = new System.Drawing.Size(79, 24);
            this.btnVisualizza.TabIndex = 80;
            this.btnVisualizza.Text = "Visualizza";
            this.btnVisualizza.UseVisualStyleBackColor = true;
            this.btnVisualizza.Click += new System.EventHandler(this.btnVisualizza_Click);
            // 
            // btnAllega
            // 
            this.btnAllega.Location = new System.Drawing.Point(11, 143);
            this.btnAllega.Name = "btnAllega";
            this.btnAllega.Size = new System.Drawing.Size(79, 24);
            this.btnAllega.TabIndex = 79;
            this.btnAllega.Text = "Allega";
            this.btnAllega.UseVisualStyleBackColor = true;
            this.btnAllega.Click += new System.EventHandler(this.btnAllega_Click);
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(346, 205);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(73, 28);
            this.btnOk.TabIndex = 82;
            this.btnOk.Tag = "mainsave";
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(447, 205);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(73, 28);
            this.btnCancel.TabIndex = 83;
            this.btnCancel.Tag = "";
            this.btnCancel.Text = "Annulla";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // openFileDialog1
            // 
            //this.openFileDialog1.Title = "Selezione documento";
            this._openFileDialog1.Title = "Selezione documento";
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.EnforceConstraints = false;
            // 
            // grpTipoallegato
            // 
            this.grpTipoallegato.Controls.Add(this.cmbCodiceAllegato);
            this.grpTipoallegato.Location = new System.Drawing.Point(12, 12);
            this.grpTipoallegato.Name = "grpTipoallegato";
            this.grpTipoallegato.Size = new System.Drawing.Size(535, 50);
            this.grpTipoallegato.TabIndex = 84;
            this.grpTipoallegato.TabStop = false;
            this.grpTipoallegato.Text = "Tipo di documento allegato";
            // 
            // cmbCodiceAllegato
            // 
            this.cmbCodiceAllegato.DataSource = this.DS.attachmentkind;
            this.cmbCodiceAllegato.DisplayMember = "title";
            this.cmbCodiceAllegato.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCodiceAllegato.FormattingEnabled = true;
            this.cmbCodiceAllegato.Location = new System.Drawing.Point(5, 19);
            this.cmbCodiceAllegato.Name = "cmbCodiceAllegato";
            this.cmbCodiceAllegato.Size = new System.Drawing.Size(515, 21);
            this.cmbCodiceAllegato.TabIndex = 0;
            this.cmbCodiceAllegato.Tag = "mandateattachment.idattachmentkind";
            this.cmbCodiceAllegato.ValueMember = "idattachmentkind";
            // 
            // FrmMandateAttachment
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(559, 245);
            this.Controls.Add(this.grpTipoallegato);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnVisualizza);
            this.Controls.Add(this.btnAllega);
            this.Name = "FrmMandateAttachment";
            this.Text = " ";
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.grpTipoallegato.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label labAutocertFileName;
        private System.Windows.Forms.Button btnVisualizza;
        private System.Windows.Forms.Button btnAllega;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        //private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.OpenFileDialog _openFileDialog1;
        public vistaForm DS;
        private System.Windows.Forms.GroupBox grpTipoallegato;
        private System.Windows.Forms.ComboBox cmbCodiceAllegato;
    }
}
