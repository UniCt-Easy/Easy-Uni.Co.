
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


namespace incomelastestimatedetail_detail {
	partial class frmeincomelastestimatedetail_detail {
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
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.txtNumero = new System.Windows.Forms.TextBox();
			this.label25 = new System.Windows.Forms.Label();
			this.txtEsercizio = new System.Windows.Forms.TextBox();
			this.label24 = new System.Windows.Forms.Label();
			this.cmbTipoContratto = new System.Windows.Forms.ComboBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.label1 = new System.Windows.Forms.Label();
			this.txtDescrizione = new System.Windows.Forms.TextBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.txtImponibileEUR = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.btnSelRiga = new System.Windows.Forms.Button();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.txtIncassato = new System.Windows.Forms.TextBox();
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnOk = new System.Windows.Forms.Button();
			this.DS = new incomelastestimatedetail_detail.dsmeta();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.labelImpPreAnnullo = new System.Windows.Forms.Label();
			this.groupBox4.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
			this.SuspendLayout();
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
			this.groupBox4.Size = new System.Drawing.Size(354, 73);
			this.groupBox4.TabIndex = 2;
			this.groupBox4.TabStop = false;
			this.groupBox4.Tag = "AutoChoose.txtNumero.default";
			this.groupBox4.Text = "Contratto Attivo";
			// 
			// txtNumero
			// 
			this.txtNumero.Location = new System.Drawing.Point(248, 48);
			this.txtNumero.Name = "txtNumero";
			this.txtNumero.Size = new System.Drawing.Size(100, 20);
			this.txtNumero.TabIndex = 5;
			this.txtNumero.Tag = "estimate.nestim";
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
			this.txtEsercizio.Tag = "estimate.yestim.year";
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
			this.cmbTipoContratto.Size = new System.Drawing.Size(247, 21);
			this.cmbTipoContratto.TabIndex = 1;
			this.cmbTipoContratto.Tag = "estimate.idestimkind";
			this.cmbTipoContratto.ValueMember = "idestimkind";
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
			this.groupBox1.Size = new System.Drawing.Size(759, 206);
			this.groupBox1.TabIndex = 9;
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
			this.txtDescrizione.Size = new System.Drawing.Size(732, 48);
			this.txtDescrizione.TabIndex = 12;
			this.txtDescrizione.Tag = "estimatedetail.detaildescription";
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
			this.textBox1.Tag = "estimatedetail.rownum";
			// 
			// label2
			// 
			this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(23, 315);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(90, 13);
			this.label2.TabIndex = 10;
			this.label2.Text = "Importo incassato";
			// 
			// txtIncassato
			// 
			this.txtIncassato.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.txtIncassato.Location = new System.Drawing.Point(26, 331);
			this.txtIncassato.Name = "txtIncassato";
			this.txtIncassato.Size = new System.Drawing.Size(145, 20);
			this.txtIncassato.TabIndex = 11;
			this.txtIncassato.Tag = "incomelastestimatedetail.amount";
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(695, 331);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 23);
			this.btnCancel.TabIndex = 17;
			this.btnCancel.Tag = "maincancel";
			this.btnCancel.Text = "Cancel";
			// 
			// btnOk
			// 
			this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnOk.Location = new System.Drawing.Point(583, 331);
			this.btnOk.Name = "btnOk";
			this.btnOk.Size = new System.Drawing.Size(75, 23);
			this.btnOk.TabIndex = 16;
			this.btnOk.Tag = "mainsave";
			this.btnOk.Text = "Ok";
			// 
			// DS
			// 
			this.DS.DataSetName = "vistaForm";
			this.DS.EnforceConstraints = false;
			// 
			// textBox2
			// 
			this.textBox2.Location = new System.Drawing.Point(196, 331);
			this.textBox2.Name = "textBox2";
			this.textBox2.ReadOnly = true;
			this.textBox2.Size = new System.Drawing.Size(145, 20);
			this.textBox2.TabIndex = 18;
			this.textBox2.Tag = "incomelastestimatedetail.originalamount";
			// 
			// labelImpPreAnnullo
			// 
			this.labelImpPreAnnullo.AutoSize = true;
			this.labelImpPreAnnullo.Location = new System.Drawing.Point(193, 315);
			this.labelImpPreAnnullo.Name = "labelImpPreAnnullo";
			this.labelImpPreAnnullo.Size = new System.Drawing.Size(97, 13);
			this.labelImpPreAnnullo.TabIndex = 19;
			this.labelImpPreAnnullo.Text = "Importo pre annullo";
			// 
			// frmeincomelastestimatedetail_detail
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 390);
			this.Controls.Add(this.labelImpPreAnnullo);
			this.Controls.Add(this.textBox2);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOk);
			this.Controls.Add(this.txtIncassato);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.groupBox4);
			this.Name = "frmeincomelastestimatedetail_detail";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "incomelastestimatedetail_detail";
			this.groupBox4.ResumeLayout(false);
			this.groupBox4.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		public incomelastestimatedetail_detail.dsmeta DS;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.TextBox txtNumero;
		private System.Windows.Forms.Label label25;
		private System.Windows.Forms.TextBox txtEsercizio;
		private System.Windows.Forms.Label label24;
		private System.Windows.Forms.ComboBox cmbTipoContratto;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button btnSelRiga;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.TextBox txtImponibileEUR;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtDescrizione;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtIncassato;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnOk;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.Label labelImpPreAnnullo;
	}
}

