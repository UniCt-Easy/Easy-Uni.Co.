
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


namespace expenselastmandatedetail_detail {
	partial class Frm_expenselastmandatedetail_detail {
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
			this.DS = new expenselastmandatedetail_detail.vistaForm();
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnOk = new System.Windows.Forms.Button();
			this.txtIncassato = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.label1 = new System.Windows.Forms.Label();
			this.txtDescrizione = new System.Windows.Forms.TextBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.txtImponibileEUR = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.btnSelRiga = new System.Windows.Forms.Button();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.txtNumero = new System.Windows.Forms.TextBox();
			this.label25 = new System.Windows.Forms.Label();
			this.txtEsercizio = new System.Windows.Forms.TextBox();
			this.label24 = new System.Windows.Forms.Label();
			this.cmbTipoContratto = new System.Windows.Forms.ComboBox();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.labelImpPreAnnullo = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox4.SuspendLayout();
			this.SuspendLayout();
			// 
			// DS
			// 
			this.DS.DataSetName = "vistaForm";
			this.DS.EnforceConstraints = false;
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(672, 337);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 23);
			this.btnCancel.TabIndex = 23;
			this.btnCancel.Tag = "maincancel";
			this.btnCancel.Text = "Cancel";
			// 
			// btnOk
			// 
			this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnOk.Location = new System.Drawing.Point(560, 337);
			this.btnOk.Name = "btnOk";
			this.btnOk.Size = new System.Drawing.Size(75, 23);
			this.btnOk.TabIndex = 22;
			this.btnOk.Tag = "mainsave";
			this.btnOk.Text = "Ok";
			// 
			// txtIncassato
			// 
			this.txtIncassato.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.txtIncassato.Location = new System.Drawing.Point(14, 341);
			this.txtIncassato.Name = "txtIncassato";
			this.txtIncassato.Size = new System.Drawing.Size(145, 20);
			this.txtIncassato.TabIndex = 21;
			this.txtIncassato.Tag = "expenselastmandatedetail.amount";
			// 
			// label2
			// 
			this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(11, 326);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(78, 13);
			this.label2.TabIndex = 20;
			this.label2.Text = "Importo pagato";
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.txtDescrizione);
			this.groupBox1.Controls.Add(this.groupBox2);
			this.groupBox1.Controls.Add(this.btnSelRiga);
			this.groupBox1.Controls.Add(this.textBox1);
			this.groupBox1.Location = new System.Drawing.Point(12, 91);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(735, 221);
			this.groupBox1.TabIndex = 19;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Dettaglio";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(6, 134);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(62, 13);
			this.label1.TabIndex = 13;
			this.label1.Text = "Descrizione";
			// 
			// txtDescrizione
			// 
			this.txtDescrizione.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtDescrizione.Location = new System.Drawing.Point(6, 150);
			this.txtDescrizione.Multiline = true;
			this.txtDescrizione.Name = "txtDescrizione";
			this.txtDescrizione.ReadOnly = true;
			this.txtDescrizione.Size = new System.Drawing.Size(723, 63);
			this.txtDescrizione.TabIndex = 12;
			this.txtDescrizione.Tag = "mandatedetail.detaildescription";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.txtImponibileEUR);
			this.groupBox2.Controls.Add(this.label4);
			this.groupBox2.Location = new System.Drawing.Point(6, 60);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(280, 56);
			this.groupBox2.TabIndex = 11;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Valore totale in EUR";
			// 
			// txtImponibileEUR
			// 
			this.txtImponibileEUR.Location = new System.Drawing.Point(8, 32);
			this.txtImponibileEUR.Name = "txtImponibileEUR";
			this.txtImponibileEUR.ReadOnly = true;
			this.txtImponibileEUR.Size = new System.Drawing.Size(88, 20);
			this.txtImponibileEUR.TabIndex = 37;
			this.txtImponibileEUR.TabStop = false;
			this.txtImponibileEUR.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(8, 16);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(64, 16);
			this.label4.TabIndex = 34;
			this.label4.Text = "Imponibile:";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// btnSelRiga
			// 
			this.btnSelRiga.Location = new System.Drawing.Point(6, 19);
			this.btnSelRiga.Name = "btnSelRiga";
			this.btnSelRiga.Size = new System.Drawing.Size(75, 23);
			this.btnSelRiga.TabIndex = 10;
			this.btnSelRiga.Text = "Numero riga";
			this.btnSelRiga.UseVisualStyleBackColor = true;
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(94, 19);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(100, 20);
			this.textBox1.TabIndex = 9;
			this.textBox1.Tag = "mandatedetail.rownum";
			// 
			// groupBox4
			// 
			this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox4.Controls.Add(this.txtNumero);
			this.groupBox4.Controls.Add(this.label25);
			this.groupBox4.Controls.Add(this.txtEsercizio);
			this.groupBox4.Controls.Add(this.label24);
			this.groupBox4.Controls.Add(this.cmbTipoContratto);
			this.groupBox4.Location = new System.Drawing.Point(12, 12);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(352, 73);
			this.groupBox4.TabIndex = 18;
			this.groupBox4.TabStop = false;
			this.groupBox4.Tag = "AutoChoose.txtNumero.default";
			this.groupBox4.Text = "Contratto Passivo";
			// 
			// txtNumero
			// 
			this.txtNumero.Location = new System.Drawing.Point(248, 48);
			this.txtNumero.Name = "txtNumero";
			this.txtNumero.Size = new System.Drawing.Size(100, 20);
			this.txtNumero.TabIndex = 5;
			this.txtNumero.Tag = "mandate.nman";
			// 
			// label25
			// 
			this.label25.AutoSize = true;
			this.label25.Location = new System.Drawing.Point(198, 51);
			this.label25.Name = "label25";
			this.label25.Size = new System.Drawing.Size(44, 13);
			this.label25.TabIndex = 4;
			this.label25.Text = "Numero";
			// 
			// txtEsercizio
			// 
			this.txtEsercizio.Location = new System.Drawing.Point(99, 48);
			this.txtEsercizio.Name = "txtEsercizio";
			this.txtEsercizio.Size = new System.Drawing.Size(81, 20);
			this.txtEsercizio.TabIndex = 3;
			this.txtEsercizio.Tag = "mandate.yman.year";
			// 
			// label24
			// 
			this.label24.AutoSize = true;
			this.label24.Location = new System.Drawing.Point(37, 51);
			this.label24.Name = "label24";
			this.label24.Size = new System.Drawing.Size(49, 13);
			this.label24.TabIndex = 2;
			this.label24.Text = "Esercizio";
			// 
			// cmbTipoContratto
			// 
			this.cmbTipoContratto.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.cmbTipoContratto.DisplayMember = "description";
			this.cmbTipoContratto.FormattingEnabled = true;
			this.cmbTipoContratto.Location = new System.Drawing.Point(99, 19);
			this.cmbTipoContratto.Name = "cmbTipoContratto";
			this.cmbTipoContratto.Size = new System.Drawing.Size(245, 21);
			this.cmbTipoContratto.TabIndex = 1;
			this.cmbTipoContratto.Tag = "mandate.idmankind";
			this.cmbTipoContratto.ValueMember = "idmankind";
			// 
			// textBox2
			// 
			this.textBox2.Location = new System.Drawing.Point(188, 341);
			this.textBox2.Name = "textBox2";
			this.textBox2.ReadOnly = true;
			this.textBox2.Size = new System.Drawing.Size(145, 20);
			this.textBox2.TabIndex = 24;
			this.textBox2.Tag = "expenselastmandatedetail.originalamount";
			// 
			// labelImpPreAnnullo
			// 
			this.labelImpPreAnnullo.AutoSize = true;
			this.labelImpPreAnnullo.Location = new System.Drawing.Point(185, 326);
			this.labelImpPreAnnullo.Name = "labelImpPreAnnullo";
			this.labelImpPreAnnullo.Size = new System.Drawing.Size(97, 13);
			this.labelImpPreAnnullo.TabIndex = 25;
			this.labelImpPreAnnullo.Text = "Importo pre annullo";
			// 
			// Frm_expenselastmandatedetail_detail
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(763, 397);
			this.Controls.Add(this.labelImpPreAnnullo);
			this.Controls.Add(this.textBox2);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOk);
			this.Controls.Add(this.txtIncassato);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.groupBox4);
			this.Name = "Frm_expenselastmandatedetail_detail";
			this.Text = "Frm_expenselastmandatedetail_detail";
			((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.groupBox4.ResumeLayout(false);
			this.groupBox4.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

			}

		#endregion
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnOk;
		private System.Windows.Forms.TextBox txtIncassato;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtDescrizione;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.TextBox txtImponibileEUR;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Button btnSelRiga;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.TextBox txtNumero;
		private System.Windows.Forms.Label label25;
		private System.Windows.Forms.TextBox txtEsercizio;
		private System.Windows.Forms.Label label24;
		private System.Windows.Forms.ComboBox cmbTipoContratto;
		public vistaForm DS;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.Label labelImpPreAnnullo;
	}
	}
