
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



namespace serviceattachmentkind_default
{
	partial class Frm_serviceattachmentkind_default
	{
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
		private void InitializeComponent()
		{
			this.DS = new serviceattachmentkind_default.vistaForm();
			this.grpTipoPrestazione = new System.Windows.Forms.GroupBox();
			this.cmbPrestazione = new System.Windows.Forms.ComboBox();
			this.grpCertificatiNecessari = new System.Windows.Forms.GroupBox();
			this.checkBox3 = new System.Windows.Forms.CheckBox();
			this.chkDurc = new System.Windows.Forms.CheckBox();
			this.chkVisura = new System.Windows.Forms.CheckBox();
			this.chkCCdedicato = new System.Windows.Forms.CheckBox();
			this.checkBox1 = new System.Windows.Forms.CheckBox();
			this.label2 = new System.Windows.Forms.Label();
			this.txtCodice = new System.Windows.Forms.TextBox();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.checkBox2 = new System.Windows.Forms.CheckBox();
			((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
			this.grpTipoPrestazione.SuspendLayout();
			this.grpCertificatiNecessari.SuspendLayout();
			this.SuspendLayout();
			// 
			// DS
			// 
			this.DS.DataSetName = "vistaForm";
			// 
			// grpTipoPrestazione
			// 
			this.grpTipoPrestazione.Controls.Add(this.cmbPrestazione);
			this.grpTipoPrestazione.Location = new System.Drawing.Point(23, 246);
			this.grpTipoPrestazione.Name = "grpTipoPrestazione";
			this.grpTipoPrestazione.Size = new System.Drawing.Size(535, 50);
			this.grpTipoPrestazione.TabIndex = 96;
			this.grpTipoPrestazione.TabStop = false;
			this.grpTipoPrestazione.Text = "Tipo Prestazione";
			// 
			// cmbPrestazione
			// 
			this.cmbPrestazione.DataSource = this.DS.service;
			this.cmbPrestazione.DisplayMember = "description";
			this.cmbPrestazione.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbPrestazione.FormattingEnabled = true;
			this.cmbPrestazione.Location = new System.Drawing.Point(5, 19);
			this.cmbPrestazione.Name = "cmbPrestazione";
			this.cmbPrestazione.Size = new System.Drawing.Size(515, 21);
			this.cmbPrestazione.TabIndex = 0;
			this.cmbPrestazione.Tag = "serviceattachmentkind.idser";
			this.cmbPrestazione.ValueMember = "idser";
			// 
			// grpCertificatiNecessari
			// 
			this.grpCertificatiNecessari.Controls.Add(this.checkBox3);
			this.grpCertificatiNecessari.Controls.Add(this.chkDurc);
			this.grpCertificatiNecessari.Controls.Add(this.chkVisura);
			this.grpCertificatiNecessari.Controls.Add(this.chkCCdedicato);
			this.grpCertificatiNecessari.Location = new System.Drawing.Point(23, 137);
			this.grpCertificatiNecessari.Name = "grpCertificatiNecessari";
			this.grpCertificatiNecessari.Size = new System.Drawing.Size(371, 87);
			this.grpCertificatiNecessari.TabIndex = 100;
			this.grpCertificatiNecessari.TabStop = false;
			this.grpCertificatiNecessari.Text = "Moduli in cui sarà visibile";
			// 
			// checkBox3
			// 
			this.checkBox3.AutoSize = true;
			this.checkBox3.Location = new System.Drawing.Point(185, 49);
			this.checkBox3.Name = "checkBox3";
			this.checkBox3.Size = new System.Drawing.Size(131, 17);
			this.checkBox3.TabIndex = 95;
			this.checkBox3.Tag = "serviceattachmentkind.flag:3";
			this.checkBox3.Text = "Autonomi professionali";
			this.checkBox3.UseVisualStyleBackColor = true;
			// 
			// chkDurc
			// 
			this.chkDurc.AutoSize = true;
			this.chkDurc.Location = new System.Drawing.Point(185, 26);
			this.chkDurc.Name = "chkDurc";
			this.chkDurc.Size = new System.Drawing.Size(126, 17);
			this.chkDurc.TabIndex = 94;
			this.chkDurc.Tag = "serviceattachmentkind.flag:2";
			this.chkDurc.Text = "Autonomi occasionali";
			this.chkDurc.UseVisualStyleBackColor = true;
			// 
			// chkVisura
			// 
			this.chkVisura.AutoSize = true;
			this.chkVisura.Location = new System.Drawing.Point(18, 49);
			this.chkVisura.Name = "chkVisura";
			this.chkVisura.Size = new System.Drawing.Size(92, 17);
			this.chkVisura.TabIndex = 93;
			this.chkVisura.Tag = "serviceattachmentkind.flag:1";
			this.chkVisura.Text = "Altri Compensi";
			this.chkVisura.UseVisualStyleBackColor = true;
			// 
			// chkCCdedicato
			// 
			this.chkCCdedicato.AutoSize = true;
			this.chkCCdedicato.Location = new System.Drawing.Point(18, 26);
			this.chkCCdedicato.Name = "chkCCdedicato";
			this.chkCCdedicato.Size = new System.Drawing.Size(99, 17);
			this.chkCCdedicato.TabIndex = 91;
			this.chkCCdedicato.Tag = "serviceattachmentkind.flag:0";
			this.chkCCdedicato.Text = "Parasubordinati";
			// 
			// checkBox1
			// 
			this.checkBox1.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.checkBox1.Location = new System.Drawing.Point(280, 27);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.Size = new System.Drawing.Size(67, 24);
			this.checkBox1.TabIndex = 103;
			this.checkBox1.Tag = "serviceattachmentkind.active:S:N";
			this.checkBox1.Text = "Attivo";
			this.checkBox1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(23, 56);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(72, 16);
			this.label2.TabIndex = 105;
			this.label2.Text = "Descrizione";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtCodice
			// 
			this.txtCodice.Location = new System.Drawing.Point(23, 31);
			this.txtCodice.Name = "txtCodice";
			this.txtCodice.Size = new System.Drawing.Size(72, 20);
			this.txtCodice.TabIndex = 101;
			this.txtCodice.Tag = "serviceattachmentkind.idattachmentkind";
			// 
			// textBox2
			// 
			this.textBox2.Location = new System.Drawing.Point(23, 74);
			this.textBox2.Multiline = true;
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(324, 43);
			this.textBox2.TabIndex = 102;
			this.textBox2.Tag = "serviceattachmentkind.title";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(23, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(64, 16);
			this.label1.TabIndex = 104;
			this.label1.Text = "Codice";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// checkBox2
			// 
			this.checkBox2.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.checkBox2.Location = new System.Drawing.Point(415, 200);
			this.checkBox2.Name = "checkBox2";
			this.checkBox2.Size = new System.Drawing.Size(143, 24);
			this.checkBox2.TabIndex = 106;
			this.checkBox2.Tag = "serviceattachmentkind.flagforced:S:N";
			this.checkBox2.Text = "Obbligatorio";
			this.checkBox2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// Frm_serviceattachmentkind_default
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(569, 328);
			this.Controls.Add(this.checkBox2);
			this.Controls.Add(this.checkBox1);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.txtCodice);
			this.Controls.Add(this.textBox2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.grpCertificatiNecessari);
			this.Controls.Add(this.grpTipoPrestazione);
			this.Name = "Frm_serviceattachmentkind_default";
			this.Text = "Frm_serviceattachmentkind_default";
			((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
			this.grpTipoPrestazione.ResumeLayout(false);
			this.grpCertificatiNecessari.ResumeLayout(false);
			this.grpCertificatiNecessari.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		public vistaForm DS;
		private System.Windows.Forms.GroupBox grpTipoPrestazione;
		private System.Windows.Forms.ComboBox cmbPrestazione;
		private System.Windows.Forms.GroupBox grpCertificatiNecessari;
		private System.Windows.Forms.CheckBox chkDurc;
		private System.Windows.Forms.CheckBox chkVisura;
		private System.Windows.Forms.CheckBox chkCCdedicato;
		private System.Windows.Forms.CheckBox checkBox1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtCodice;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.CheckBox checkBox2;
		private System.Windows.Forms.CheckBox checkBox3;
	}
}
