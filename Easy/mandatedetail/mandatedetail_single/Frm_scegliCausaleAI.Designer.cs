
/*
Easy
Copyright (C) 2025 Università degli Studi di Catania (www.unict.it)
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



namespace mandatedetail_single {
	partial class Frm_scegliCausaleAI {
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
			this.btnNext = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.gridDettagliCausale = new System.Windows.Forms.DataGrid();
			this.label1 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.gridDettagliCausale)).BeginInit();
			this.SuspendLayout();
			// 
			// btnNext
			// 
			this.btnNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnNext.Location = new System.Drawing.Point(708, 382);
			this.btnNext.Name = "btnNext";
			this.btnNext.Size = new System.Drawing.Size(114, 30);
			this.btnNext.TabIndex = 20;
			this.btnNext.Text = "Inserisci";
			this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(828, 382);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(114, 30);
			this.btnCancel.TabIndex = 21;
			this.btnCancel.Text = "Annulla";
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// gridDettagliCausale
			// 
			this.gridDettagliCausale.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.gridDettagliCausale.CaptionVisible = false;
			this.gridDettagliCausale.DataMember = "";
			this.gridDettagliCausale.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.gridDettagliCausale.Location = new System.Drawing.Point(8, 24);
			this.gridDettagliCausale.Name = "gridDettagliCausale";
			this.gridDettagliCausale.Size = new System.Drawing.Size(934, 352);
			this.gridDettagliCausale.TabIndex = 27;
			this.gridDettagliCausale.Paint += new System.Windows.Forms.PaintEventHandler(this.gridDettagliFatturaMadre_Paint);
			this.gridDettagliCausale.DoubleClick += new System.EventHandler(this.gridDettagliCausale_DoubleClick);
			this.gridDettagliCausale.MouseUp += new System.Windows.Forms.MouseEventHandler(this.gridDettagliCausale_MouseUp);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(5, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(285, 13);
			this.label1.TabIndex = 22;
			this.label1.Text = "Scegliere una Causale EP ed una Classificazione";
			// 
			// Frm_scegliCausaleAI
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(950, 420);
			this.Controls.Add(this.gridDettagliCausale);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.btnNext);
			this.Controls.Add(this.btnCancel);
			this.Name = "Frm_scegliCausaleAI";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Frm_scegliCausaleAI";
			((System.ComponentModel.ISupportInitialize)(this.gridDettagliCausale)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button btnNext;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.DataGrid gridDettagliCausale;
		private System.Windows.Forms.Label label1;
	}
}
