
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



namespace registry_aziende_anagraficadetail {
	partial class Frm_registry_aziende_anagraficadetail {
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
			this.DS = new registry_aziende_anagraficadetail.vistaForm();
			this.cmbNaturagiu = new System.Windows.Forms.ComboBox();
			this.cmbDip = new System.Windows.Forms.ComboBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.gboxAteco = new System.Windows.Forms.GroupBox();
			this.txtUPB = new System.Windows.Forms.TextBox();
			this.txtDescrUPB = new System.Windows.Forms.TextBox();
			this.grpNace = new System.Windows.Forms.GroupBox();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.btnAnnulla = new System.Windows.Forms.Button();
			this.btnOK = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
			this.gboxAteco.SuspendLayout();
			this.grpNace.SuspendLayout();
			this.SuspendLayout();
			// 
			// DS
			// 
			this.DS.DataSetName = "vistaForm";
			// 
			// cmbNaturagiu
			// 
			this.cmbNaturagiu.DataSource = this.DS.naturagiur;
			this.cmbNaturagiu.DisplayMember = "title";
			this.cmbNaturagiu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbNaturagiu.Location = new System.Drawing.Point(114, 211);
			this.cmbNaturagiu.Name = "cmbNaturagiu";
			this.cmbNaturagiu.Size = new System.Drawing.Size(367, 21);
			this.cmbNaturagiu.TabIndex = 11;
			this.cmbNaturagiu.Tag = "registry_aziende.idnaturagiur";
			this.cmbNaturagiu.ValueMember = "idnaturagiur";
			// 
			// cmbDip
			// 
			this.cmbDip.DataSource = this.DS.numerodip;
			this.cmbDip.DisplayMember = "sortcode";
			this.cmbDip.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbDip.Location = new System.Drawing.Point(114, 252);
			this.cmbDip.Name = "cmbDip";
			this.cmbDip.Size = new System.Drawing.Size(367, 21);
			this.cmbDip.TabIndex = 13;
			this.cmbDip.Tag = "registry_aziende.idnumerodip";
			this.cmbDip.ValueMember = "idnumerodip";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(28, 214);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(81, 13);
			this.label3.TabIndex = 16;
			this.label3.Text = "Natura giuridica";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(9, 252);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(100, 13);
			this.label4.TabIndex = 17;
			this.label4.Text = "Numero dipartimenti";
			// 
			// gboxAteco
			// 
			this.gboxAteco.Controls.Add(this.txtUPB);
			this.gboxAteco.Controls.Add(this.txtDescrUPB);
			this.gboxAteco.Location = new System.Drawing.Point(12, 12);
			this.gboxAteco.Name = "gboxAteco";
			this.gboxAteco.Size = new System.Drawing.Size(469, 84);
			this.gboxAteco.TabIndex = 18;
			this.gboxAteco.TabStop = false;
			this.gboxAteco.Tag = "";
			this.gboxAteco.Text = "ATECO";
			// 
			// txtUPB
			// 
			this.txtUPB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtUPB.Location = new System.Drawing.Point(6, 51);
			this.txtUPB.Name = "txtUPB";
			this.txtUPB.Size = new System.Drawing.Size(106, 20);
			this.txtUPB.TabIndex = 5;
			this.txtUPB.Tag = "ateco.codice?x";
			// 
			// txtDescrUPB
			// 
			this.txtDescrUPB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtDescrUPB.Location = new System.Drawing.Point(127, 9);
			this.txtDescrUPB.Multiline = true;
			this.txtDescrUPB.Name = "txtDescrUPB";
			this.txtDescrUPB.ReadOnly = true;
			this.txtDescrUPB.Size = new System.Drawing.Size(333, 62);
			this.txtDescrUPB.TabIndex = 4;
			this.txtDescrUPB.TabStop = false;
			this.txtDescrUPB.Tag = "ateco.title";
			// 
			// grpNace
			// 
			this.grpNace.Controls.Add(this.textBox1);
			this.grpNace.Controls.Add(this.textBox2);
			this.grpNace.Location = new System.Drawing.Point(12, 102);
			this.grpNace.Name = "grpNace";
			this.grpNace.Size = new System.Drawing.Size(469, 81);
			this.grpNace.TabIndex = 19;
			this.grpNace.TabStop = false;
			this.grpNace.Tag = "";
			this.grpNace.Text = "NACE";
			// 
			// textBox1
			// 
			this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox1.Location = new System.Drawing.Point(8, 50);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(113, 20);
			this.textBox1.TabIndex = 5;
			this.textBox1.Tag = "nace.idnace?x";
			// 
			// textBox2
			// 
			this.textBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox2.Location = new System.Drawing.Point(127, 9);
			this.textBox2.Multiline = true;
			this.textBox2.Name = "textBox2";
			this.textBox2.ReadOnly = true;
			this.textBox2.Size = new System.Drawing.Size(333, 62);
			this.textBox2.TabIndex = 4;
			this.textBox2.TabStop = false;
			this.textBox2.Tag = "nace.activity";
			// 
			// btnAnnulla
			// 
			this.btnAnnulla.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnAnnulla.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnAnnulla.Location = new System.Drawing.Point(406, 302);
			this.btnAnnulla.Name = "btnAnnulla";
			this.btnAnnulla.Size = new System.Drawing.Size(75, 23);
			this.btnAnnulla.TabIndex = 73;
			this.btnAnnulla.Text = "Annulla";
			// 
			// btnOK
			// 
			this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnOK.Location = new System.Drawing.Point(302, 302);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(75, 23);
			this.btnOK.TabIndex = 72;
			this.btnOK.Tag = "mainsave";
			this.btnOK.Text = "OK";
			// 
			// Frm_registry_aziende_anagraficadetail
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(499, 337);
			this.Controls.Add(this.btnAnnulla);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.grpNace);
			this.Controls.Add(this.gboxAteco);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.cmbDip);
			this.Controls.Add(this.cmbNaturagiu);
			this.Name = "Frm_registry_aziende_anagraficadetail";
			this.Text = "Frm_registry_aziende_anagraficadetail";
			((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
			this.gboxAteco.ResumeLayout(false);
			this.gboxAteco.PerformLayout();
			this.grpNace.ResumeLayout(false);
			this.grpNace.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		public vistaForm DS;
		private System.Windows.Forms.ComboBox cmbNaturagiu;
		private System.Windows.Forms.ComboBox cmbDip;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.GroupBox gboxAteco;
		public System.Windows.Forms.TextBox txtUPB;
		private System.Windows.Forms.TextBox txtDescrUPB;
		private System.Windows.Forms.GroupBox grpNace;
		public System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.Button btnAnnulla;
		private System.Windows.Forms.Button btnOK;
	}
}
