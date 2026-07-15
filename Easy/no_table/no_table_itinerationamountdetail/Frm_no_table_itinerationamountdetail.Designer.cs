/*
Easy
Copyright (C) 2026 Università degli Studi di Catania (www.unict.it)
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


namespace no_table_itinerationamountdetail {
	partial class Frm_no_table_itinerationamountdetail {
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
			this.DS = new no_table_itinerationamountdetail.vistaForm();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.label2 = new System.Windows.Forms.Label();
			this.btnAnnulla = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.txtEsercizioMissione = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.txtNumFine = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.txtNumInizio = new System.Windows.Forms.TextBox();
			this.labelEsercizio = new System.Windows.Forms.Label();
			this.btnEseguiInsert = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
			this.groupBox2.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// DS
			// 
			this.DS.DataSetName = "vistaForm";
			// 
			// groupBox2
			// 
			this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox2.Controls.Add(this.label2);
			this.groupBox2.Location = new System.Drawing.Point(14, 8);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(415, 54);
			this.groupBox2.TabIndex = 17;
			this.groupBox2.TabStop = false;
			// 
			// label2
			// 
			this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.label2.Location = new System.Drawing.Point(9, 16);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(394, 30);
			this.label2.TabIndex = 2;
			this.label2.Text = "Inserisce il Riepilogo degli importi Missione nella tabella del database";
			// 
			// btnAnnulla
			// 
			this.btnAnnulla.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnAnnulla.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnAnnulla.Location = new System.Drawing.Point(354, 262);
			this.btnAnnulla.Name = "btnAnnulla";
			this.btnAnnulla.Size = new System.Drawing.Size(75, 23);
			this.btnAnnulla.TabIndex = 16;
			this.btnAnnulla.Text = "Annulla";
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox1.Controls.Add(this.txtEsercizioMissione);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.txtNumFine);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.txtNumInizio);
			this.groupBox1.Controls.Add(this.labelEsercizio);
			this.groupBox1.Controls.Add(this.btnEseguiInsert);
			this.groupBox1.Location = new System.Drawing.Point(14, 68);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(415, 177);
			this.groupBox1.TabIndex = 14;
			this.groupBox1.TabStop = false;
			// 
			// txtEsercizioMissione
			// 
			this.txtEsercizioMissione.BackColor = System.Drawing.SystemColors.Window;
			this.txtEsercizioMissione.Location = new System.Drawing.Point(239, 18);
			this.txtEsercizioMissione.Name = "txtEsercizioMissione";
			this.txtEsercizioMissione.Size = new System.Drawing.Size(72, 20);
			this.txtEsercizioMissione.TabIndex = 19;
			this.txtEsercizioMissione.Tag = "";
			this.txtEsercizioMissione.TextChanged += new System.EventHandler(this.txtEsercizioMissione_TextChanged);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(14, 18);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(190, 13);
			this.label3.TabIndex = 18;
			this.label3.Text = "Esercizio missione (2025 o successivo)";
			this.label3.Click += new System.EventHandler(this.label3_Click);
			// 
			// txtNumFine
			// 
			this.txtNumFine.BackColor = System.Drawing.SystemColors.Window;
			this.txtNumFine.Location = new System.Drawing.Point(340, 54);
			this.txtNumFine.Name = "txtNumFine";
			this.txtNumFine.Size = new System.Drawing.Size(72, 20);
			this.txtNumFine.TabIndex = 9;
			this.txtNumFine.Tag = "";
			this.txtNumFine.TextChanged += new System.EventHandler(this.txtNumFine_TextChanged);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(236, 58);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(95, 13);
			this.label1.TabIndex = 8;
			this.label1.Text = "Num. missione fine";
			// 
			// txtNumInizio
			// 
			this.txtNumInizio.BackColor = System.Drawing.SystemColors.Window;
			this.txtNumInizio.Location = new System.Drawing.Point(131, 51);
			this.txtNumInizio.Name = "txtNumInizio";
			this.txtNumInizio.Size = new System.Drawing.Size(72, 20);
			this.txtNumInizio.TabIndex = 7;
			this.txtNumInizio.Tag = "";
			// 
			// labelEsercizio
			// 
			this.labelEsercizio.AutoSize = true;
			this.labelEsercizio.Location = new System.Drawing.Point(14, 54);
			this.labelEsercizio.Name = "labelEsercizio";
			this.labelEsercizio.Size = new System.Drawing.Size(101, 13);
			this.labelEsercizio.TabIndex = 6;
			this.labelEsercizio.Text = "Num. missione inizio";
			// 
			// btnEseguiInsert
			// 
			this.btnEseguiInsert.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.btnEseguiInsert.Location = new System.Drawing.Point(131, 129);
			this.btnEseguiInsert.Name = "btnEseguiInsert";
			this.btnEseguiInsert.Size = new System.Drawing.Size(136, 30);
			this.btnEseguiInsert.TabIndex = 1;
			this.btnEseguiInsert.Text = "Esegui";
			this.btnEseguiInsert.UseVisualStyleBackColor = true;
			//this.btnEseguiInsert.DialogResult = None;
			this.btnEseguiInsert.Click += new System.EventHandler(this.btnEseguiInsert_Click);
			// 
			// Frm_no_table_itinerationamountdetail
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(443, 292);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.btnAnnulla);
			this.Controls.Add(this.groupBox1);
			this.Name = "Frm_no_table_itinerationamountdetail";
			this.Text = "Frm_no_table_itinerationamountdetail";
			((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
			this.groupBox2.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button btnAnnulla;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.TextBox txtEsercizioMissione;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox txtNumFine;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtNumInizio;
		private System.Windows.Forms.Label labelEsercizio;
		private System.Windows.Forms.Button btnEseguiInsert;
		public vistaForm DS;
	}
}