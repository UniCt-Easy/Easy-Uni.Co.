
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



namespace registry_docenti_anagraficadetail {
	partial class Frm_registry_docenti_anagraficadetail {
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
			this.DS = new registry_docenti_anagraficadetail.vistaForm();
			this.btnAnnulla = new System.Windows.Forms.Button();
			this.btnOK = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.cmbistituto = new System.Windows.Forms.ComboBox();
			((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
			this.SuspendLayout();
			// 
			// DS
			// 
			this.DS.DataSetName = "vistaForm";
			// 
			// btnAnnulla
			// 
			this.btnAnnulla.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnAnnulla.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnAnnulla.Location = new System.Drawing.Point(600, 133);
			this.btnAnnulla.Name = "btnAnnulla";
			this.btnAnnulla.Size = new System.Drawing.Size(75, 23);
			this.btnAnnulla.TabIndex = 81;
			this.btnAnnulla.Text = "Annulla";
			// 
			// btnOK
			// 
			this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnOK.Location = new System.Drawing.Point(496, 133);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(75, 23);
			this.btnOK.TabIndex = 80;
			this.btnOK.Tag = "mainsave";
			this.btnOK.Text = "OK";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(10, 77);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(116, 13);
			this.label1.TabIndex = 83;
			this.label1.Text = "Istituto, Ente o Azienda";
			// 
			// cmbistituto
			// 
			this.cmbistituto.DataSource = this.DS.registry_istituti;
			this.cmbistituto.DisplayMember = "title";
			this.cmbistituto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbistituto.Location = new System.Drawing.Point(132, 74);
			this.cmbistituto.Name = "cmbistituto";
			this.cmbistituto.Size = new System.Drawing.Size(543, 21);
			this.cmbistituto.TabIndex = 82;
			this.cmbistituto.Tag = "registry_docenti.idreg_istituti";
			this.cmbistituto.ValueMember = "idreg";
			// 
			// Frm_registry_docenti_anagraficadetail
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(687, 168);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.cmbistituto);
			this.Controls.Add(this.btnAnnulla);
			this.Controls.Add(this.btnOK);
			this.Name = "Frm_registry_docenti_anagraficadetail";
			this.Text = "Frm_registry_docenti_anagraficadetail";
			((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		public vistaForm DS;
		private System.Windows.Forms.Button btnAnnulla;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox cmbistituto;
	}
}
