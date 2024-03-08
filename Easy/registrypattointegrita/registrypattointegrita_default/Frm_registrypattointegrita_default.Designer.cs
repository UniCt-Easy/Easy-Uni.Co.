
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



namespace registrypattointegrita_default {
	partial class Frm_registrypattointegrita_default {
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
			this.DS = new registrypattointegrita_default.vistaForm();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.labPattoFileName = new System.Windows.Forms.Label();
			this.btnVisualizzaPatto = new System.Windows.Forms.Button();
			this.btnRimuoviPatto = new System.Windows.Forms.Button();
			this.btnAllegaPatto = new System.Windows.Forms.Button();
			this.textBox4 = new System.Windows.Forms.TextBox();
			this.label12 = new System.Windows.Forms.Label();
			this.txtscadenza = new System.Windows.Forms.TextBox();
			this.txtDataIniziovalidita = new System.Windows.Forms.TextBox();
			this.label10 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.groupCredDeb = new System.Windows.Forms.GroupBox();
			this.txtCreDeb = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this._opendlg = new System.Windows.Forms.OpenFileDialog();
			((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
			this.groupBox3.SuspendLayout();
			this.groupCredDeb.SuspendLayout();
			this.SuspendLayout();
			// 
			// DS
			// 
			this.DS.DataSetName = "vistaForm";
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.labPattoFileName);
			this.groupBox3.Controls.Add(this.btnVisualizzaPatto);
			this.groupBox3.Controls.Add(this.btnRimuoviPatto);
			this.groupBox3.Controls.Add(this.btnAllegaPatto);
			this.groupBox3.Location = new System.Drawing.Point(12, 158);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(510, 73);
			this.groupBox3.TabIndex = 211;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Allegato Patto di Integrità";
			// 
			// labPattoFileName
			// 
			this.labPattoFileName.Location = new System.Drawing.Point(10, 16);
			this.labPattoFileName.Name = "labPattoFileName";
			this.labPattoFileName.Size = new System.Drawing.Size(406, 18);
			this.labPattoFileName.TabIndex = 75;
			// 
			// btnVisualizzaPatto
			// 
			this.btnVisualizzaPatto.Location = new System.Drawing.Point(333, 36);
			this.btnVisualizzaPatto.Name = "btnVisualizzaPatto";
			this.btnVisualizzaPatto.Size = new System.Drawing.Size(79, 24);
			this.btnVisualizzaPatto.TabIndex = 2;
			this.btnVisualizzaPatto.Text = "Visualizza";
			this.btnVisualizzaPatto.UseVisualStyleBackColor = true;
			this.btnVisualizzaPatto.Click += new System.EventHandler(this.btnVisualizzaPatto_Click);
			// 
			// btnRimuoviPatto
			// 
			this.btnRimuoviPatto.Location = new System.Drawing.Point(213, 36);
			this.btnRimuoviPatto.Name = "btnRimuoviPatto";
			this.btnRimuoviPatto.Size = new System.Drawing.Size(99, 24);
			this.btnRimuoviPatto.TabIndex = 1;
			this.btnRimuoviPatto.Text = "Rimuovi Allegato";
			this.btnRimuoviPatto.UseVisualStyleBackColor = true;
			this.btnRimuoviPatto.Click += new System.EventHandler(this.btnRimuoviPatto_Click);
			// 
			// btnAllegaPatto
			// 
			this.btnAllegaPatto.Location = new System.Drawing.Point(117, 36);
			this.btnAllegaPatto.Name = "btnAllegaPatto";
			this.btnAllegaPatto.Size = new System.Drawing.Size(79, 24);
			this.btnAllegaPatto.TabIndex = 0;
			this.btnAllegaPatto.Text = "Allega";
			this.btnAllegaPatto.UseVisualStyleBackColor = true;
			this.btnAllegaPatto.Click += new System.EventHandler(this.btnAllegaPatto_Click);
			// 
			// textBox4
			// 
			this.textBox4.Location = new System.Drawing.Point(49, 66);
			this.textBox4.Name = "textBox4";
			this.textBox4.Size = new System.Drawing.Size(69, 20);
			this.textBox4.TabIndex = 209;
			this.textBox4.Tag = "registrypattointegrita.idregistrypattointegrita";
			// 
			// label12
			// 
			this.label12.AutoSize = true;
			this.label12.Location = new System.Drawing.Point(23, 68);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(14, 13);
			this.label12.TabIndex = 210;
			this.label12.Text = "#";
			// 
			// txtscadenza
			// 
			this.txtscadenza.Location = new System.Drawing.Point(373, 109);
			this.txtscadenza.Name = "txtscadenza";
			this.txtscadenza.Size = new System.Drawing.Size(120, 20);
			this.txtscadenza.TabIndex = 206;
			this.txtscadenza.Tag = "registrypattointegrita.stop";
			// 
			// txtDataIniziovalidita
			// 
			this.txtDataIniziovalidita.Location = new System.Drawing.Point(125, 109);
			this.txtDataIniziovalidita.Name = "txtDataIniziovalidita";
			this.txtDataIniziovalidita.Size = new System.Drawing.Size(120, 20);
			this.txtDataIniziovalidita.TabIndex = 205;
			this.txtDataIniziovalidita.Tag = "registrypattointegrita.start";
			this.txtDataIniziovalidita.Leave += new System.EventHandler(this.txtDataIniziovalidita_Leave);
			// 
			// label10
			// 
			this.label10.Location = new System.Drawing.Point(280, 104);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(87, 23);
			this.label10.TabIndex = 208;
			this.label10.Text = "Data scadenza";
			this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(15, 102);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(104, 30);
			this.label4.TabIndex = 207;
			this.label4.Text = "Data inizio validità";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// groupCredDeb
			// 
			this.groupCredDeb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupCredDeb.Controls.Add(this.txtCreDeb);
			this.groupCredDeb.Controls.Add(this.label6);
			this.groupCredDeb.Location = new System.Drawing.Point(12, 12);
			this.groupCredDeb.Name = "groupCredDeb";
			this.groupCredDeb.Size = new System.Drawing.Size(510, 48);
			this.groupCredDeb.TabIndex = 204;
			this.groupCredDeb.TabStop = false;
			this.groupCredDeb.Tag = "AutoChoose.txtCreDeb.anagrafica.(active<>\'N\')";
			this.groupCredDeb.Text = "Anagrafica";
			// 
			// txtCreDeb
			// 
			this.txtCreDeb.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtCreDeb.Location = new System.Drawing.Point(109, 16);
			this.txtCreDeb.Name = "txtCreDeb";
			this.txtCreDeb.Size = new System.Drawing.Size(393, 20);
			this.txtCreDeb.TabIndex = 1;
			this.txtCreDeb.Tag = "registry.title?registrypattointegritaview.registry";
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(3, 16);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(104, 16);
			this.label6.TabIndex = 1;
			this.label6.Text = "Denominazione:";
			this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// _opendlg
			// 
			this._opendlg.Title = "Scegli il file da allegare";
			// 
			// Frm_registrypattointegrita_default
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(550, 243);
			this.Controls.Add(this.groupBox3);
			this.Controls.Add(this.textBox4);
			this.Controls.Add(this.label12);
			this.Controls.Add(this.txtscadenza);
			this.Controls.Add(this.txtDataIniziovalidita);
			this.Controls.Add(this.label10);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.groupCredDeb);
			this.Name = "Frm_registrypattointegrita_default";
			this.Text = "Frm_registrypattointegrita_default";
			((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
			this.groupBox3.ResumeLayout(false);
			this.groupCredDeb.ResumeLayout(false);
			this.groupCredDeb.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		public vistaForm DS;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.Label labPattoFileName;
		private System.Windows.Forms.Button btnVisualizzaPatto;
		private System.Windows.Forms.Button btnRimuoviPatto;
		private System.Windows.Forms.Button btnAllegaPatto;
		private System.Windows.Forms.TextBox textBox4;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.TextBox txtscadenza;
		private System.Windows.Forms.TextBox txtDataIniziovalidita;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.GroupBox groupCredDeb;
		private System.Windows.Forms.TextBox txtCreDeb;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.OpenFileDialog _opendlg;
	}
}
