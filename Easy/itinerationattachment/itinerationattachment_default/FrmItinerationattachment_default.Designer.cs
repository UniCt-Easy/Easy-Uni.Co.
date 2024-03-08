
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


namespace itinerationattachment_default {
    partial class FrmItinerationattachment_default {
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
			this.btnOk = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.labAutocertFileName = new System.Windows.Forms.Label();
			this.btnVisualizza = new System.Windows.Forms.Button();
			this.btnAllega = new System.Windows.Forms.Button();
			this._openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.label1 = new System.Windows.Forms.Label();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.DS = new itinerationattachment_default.vistaForm();
			this.chkWebDefault = new System.Windows.Forms.CheckBox();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
			this.SuspendLayout();
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(467, 177);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(73, 28);
			this.btnCancel.TabIndex = 88;
			this.btnCancel.Tag = "";
			this.btnCancel.Text = "Annulla";
			this.btnCancel.UseVisualStyleBackColor = true;
			// 
			// btnOk
			// 
			this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnOk.Location = new System.Drawing.Point(366, 177);
			this.btnOk.Name = "btnOk";
			this.btnOk.Size = new System.Drawing.Size(73, 28);
			this.btnOk.TabIndex = 87;
			this.btnOk.Tag = "mainsave";
			this.btnOk.Text = "Ok";
			this.btnOk.UseVisualStyleBackColor = true;
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox1.Controls.Add(this.labAutocertFileName);
			this.groupBox1.Location = new System.Drawing.Point(12, 61);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(528, 53);
			this.groupBox1.TabIndex = 86;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "File allegato";
			// 
			// labAutocertFileName
			// 
			this.labAutocertFileName.Location = new System.Drawing.Point(15, 25);
			this.labAutocertFileName.Name = "labAutocertFileName";
			this.labAutocertFileName.Size = new System.Drawing.Size(505, 16);
			this.labAutocertFileName.TabIndex = 75;
			this.labAutocertFileName.Tag = "itinerationattachment.filename";
			// 
			// btnVisualizza
			// 
			this.btnVisualizza.Location = new System.Drawing.Point(124, 120);
			this.btnVisualizza.Name = "btnVisualizza";
			this.btnVisualizza.Size = new System.Drawing.Size(79, 24);
			this.btnVisualizza.TabIndex = 85;
			this.btnVisualizza.Text = "Visualizza";
			this.btnVisualizza.UseVisualStyleBackColor = true;
			this.btnVisualizza.Click += new System.EventHandler(this.btnVisualizza_Click);
			// 
			// btnAllega
			// 
			this.btnAllega.Location = new System.Drawing.Point(12, 120);
			this.btnAllega.Name = "btnAllega";
			this.btnAllega.Size = new System.Drawing.Size(79, 24);
			this.btnAllega.TabIndex = 84;
			this.btnAllega.Text = "Allega";
			this.btnAllega.UseVisualStyleBackColor = true;
			this.btnAllega.Click += new System.EventHandler(this.btnAllega_Click);
			// 
			// openFileDialog1
			// 
			this._openFileDialog1.Title = "Selezione documento";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 20);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(62, 13);
			this.label1.TabIndex = 89;
			this.label1.Text = "Descrizione";
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(80, 16);
			this.textBox1.Multiline = true;
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(460, 39);
			this.textBox1.TabIndex = 90;
			this.textBox1.Tag = "itinerationattachment.description";
			// 
			// DS
			// 
			this.DS.DataSetName = "vistaForm";
			this.DS.EnforceConstraints = false;
			// 
			// chkWebDefault
			// 
			this.chkWebDefault.AutoSize = true;
			this.chkWebDefault.Location = new System.Drawing.Point(460, 127);
			this.chkWebDefault.Name = "chkWebDefault";
			this.chkWebDefault.Size = new System.Drawing.Size(53, 17);
			this.chkWebDefault.TabIndex = 91;
			this.chkWebDefault.Tag = "itinerationattachment.active:S:N";
			this.chkWebDefault.Text = "Attivo";
			this.chkWebDefault.UseVisualStyleBackColor = true;
			// 
			// FrmItinerationattachment_default
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(561, 217);
			this.Controls.Add(this.chkWebDefault);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOk);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.btnVisualizza);
			this.Controls.Add(this.btnAllega);
			this.Name = "FrmItinerationattachment_default";
			this.Text = "FrmItinerationattachment_default";
			this.groupBox1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label labAutocertFileName;
        private System.Windows.Forms.Button btnVisualizza;
        private System.Windows.Forms.Button btnAllega;
        private System.Windows.Forms.OpenFileDialog _openFileDialog1;
        public vistaForm DS;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.CheckBox chkWebDefault;
	}
}
