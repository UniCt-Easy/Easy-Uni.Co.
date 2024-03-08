
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



namespace registrypattointegrita_anagraficadetail {
	partial class Frm_registrypattointegrita_anagraficadetail {
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
			this.DS = new registrypattointegrita_anagraficadetail.vistaForm();
			this.btnAnnulla = new System.Windows.Forms.Button();
			this.btnOk = new System.Windows.Forms.Button();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.labPattoFileName = new System.Windows.Forms.Label();
			this.btnVisualizzaVisura = new System.Windows.Forms.Button();
			this.btnRimuoviVisura = new System.Windows.Forms.Button();
			this.btnAllegaVisura = new System.Windows.Forms.Button();
			this.txtDataIniziovalidita = new System.Windows.Forms.TextBox();
			this.txtscadenza = new System.Windows.Forms.TextBox();
			this.label10 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this._opendlg = new System.Windows.Forms.OpenFileDialog();
			((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
			this.groupBox3.SuspendLayout();
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
			this.btnAnnulla.Location = new System.Drawing.Point(380, 162);
			this.btnAnnulla.Name = "btnAnnulla";
			this.btnAnnulla.Size = new System.Drawing.Size(72, 24);
			this.btnAnnulla.TabIndex = 194;
			this.btnAnnulla.Text = "Annulla";
			// 
			// btnOk
			// 
			this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnOk.Location = new System.Drawing.Point(282, 162);
			this.btnOk.Name = "btnOk";
			this.btnOk.Size = new System.Drawing.Size(72, 24);
			this.btnOk.TabIndex = 193;
			this.btnOk.Tag = "mainsave";
			this.btnOk.Text = "OK";
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.labPattoFileName);
			this.groupBox3.Controls.Add(this.btnVisualizzaVisura);
			this.groupBox3.Controls.Add(this.btnRimuoviVisura);
			this.groupBox3.Controls.Add(this.btnAllegaVisura);
			this.groupBox3.Location = new System.Drawing.Point(20, 63);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(432, 79);
			this.groupBox3.TabIndex = 192;
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
			// btnVisualizzaVisura
			// 
			this.btnVisualizzaVisura.Location = new System.Drawing.Point(333, 41);
			this.btnVisualizzaVisura.Name = "btnVisualizzaVisura";
			this.btnVisualizzaVisura.Size = new System.Drawing.Size(79, 24);
			this.btnVisualizzaVisura.TabIndex = 2;
			this.btnVisualizzaVisura.Text = "Visualizza";
			this.btnVisualizzaVisura.UseVisualStyleBackColor = true;
			this.btnVisualizzaVisura.Click += new System.EventHandler(this.btnVisualizzaPatto_Click);
			// 
			// btnRimuoviVisura
			// 
			this.btnRimuoviVisura.Location = new System.Drawing.Point(214, 41);
			this.btnRimuoviVisura.Name = "btnRimuoviVisura";
			this.btnRimuoviVisura.Size = new System.Drawing.Size(99, 24);
			this.btnRimuoviVisura.TabIndex = 1;
			this.btnRimuoviVisura.Text = "Rimuovi Allegato";
			this.btnRimuoviVisura.UseVisualStyleBackColor = true;
			this.btnRimuoviVisura.Click += new System.EventHandler(this.btnRimuoviPatto_Click);
			// 
			// btnAllegaVisura
			// 
			this.btnAllegaVisura.Location = new System.Drawing.Point(117, 41);
			this.btnAllegaVisura.Name = "btnAllegaVisura";
			this.btnAllegaVisura.Size = new System.Drawing.Size(79, 24);
			this.btnAllegaVisura.TabIndex = 0;
			this.btnAllegaVisura.Text = "Allega";
			this.btnAllegaVisura.UseVisualStyleBackColor = true;
			this.btnAllegaVisura.Click += new System.EventHandler(this.btnAllegaPatto_Click);
			// 
			// txtDataIniziovalidita
			// 
			this.txtDataIniziovalidita.Location = new System.Drawing.Point(121, 15);
			this.txtDataIniziovalidita.Name = "txtDataIniziovalidita";
			this.txtDataIniziovalidita.Size = new System.Drawing.Size(120, 20);
			this.txtDataIniziovalidita.TabIndex = 188;
			this.txtDataIniziovalidita.Tag = "registrypattointegrita.start";
			this.txtDataIniziovalidita.Leave += new System.EventHandler(this.txtDataIniziovalidita_Leave);
			// 
			// txtscadenza
			// 
			this.txtscadenza.Location = new System.Drawing.Point(332, 15);
			this.txtscadenza.Name = "txtscadenza";
			this.txtscadenza.Size = new System.Drawing.Size(120, 20);
			this.txtscadenza.TabIndex = 189;
			this.txtscadenza.Tag = "registrypattointegrita.stop";
			// 
			// label10
			// 
			this.label10.Location = new System.Drawing.Point(239, 15);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(87, 23);
			this.label10.TabIndex = 191;
			this.label10.Text = "Data scadenza";
			this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(12, 12);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(103, 30);
			this.label4.TabIndex = 190;
			this.label4.Text = "Data inizio validità";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// _opendlg
			// 
			this._opendlg.Title = "Scegli il file da allegare";
			// 
			// Frm_registrypattointegrita_anagraficadetail
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(505, 229);
			this.Controls.Add(this.btnAnnulla);
			this.Controls.Add(this.btnOk);
			this.Controls.Add(this.groupBox3);
			this.Controls.Add(this.txtDataIniziovalidita);
			this.Controls.Add(this.txtscadenza);
			this.Controls.Add(this.label10);
			this.Controls.Add(this.label4);
			this.Name = "Frm_registrypattointegrita_anagraficadetail";
			this.Text = "Frm_registrypattointegrita_anagraficadetail";
			((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
			this.groupBox3.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		public vistaForm DS;
		private System.Windows.Forms.Button btnAnnulla;
		private System.Windows.Forms.Button btnOk;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.Label labPattoFileName;
		private System.Windows.Forms.Button btnVisualizzaVisura;
		private System.Windows.Forms.Button btnRimuoviVisura;
		private System.Windows.Forms.Button btnAllegaVisura;
		private System.Windows.Forms.TextBox txtDataIniziovalidita;
		private System.Windows.Forms.TextBox txtscadenza;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.OpenFileDialog _opendlg;
	}
}
