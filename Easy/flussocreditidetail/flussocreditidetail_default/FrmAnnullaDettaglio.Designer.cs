
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


namespace flussocreditidetail_default {
	partial class FrmAnnullaDettaglio {
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
			this.txtCodiceBollettino = new System.Windows.Forms.TextBox();
			this.btnElaboraAnnullamento = new System.Windows.Forms.Button();
			this.btnAnnulla = new System.Windows.Forms.Button();
			this.btnOK = new System.Windows.Forms.Button();
			this.gBoxAnnulla = new System.Windows.Forms.GroupBox();
			this.dgrCreditiAnnullati = new System.Windows.Forms.DataGrid();
			this.gBoxAnnulla.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgrCreditiAnnullati)).BeginInit();
			this.SuspendLayout();
			// 
			// txtCodiceBollettino
			// 
			this.txtCodiceBollettino.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtCodiceBollettino.Location = new System.Drawing.Point(141, 17);
			this.txtCodiceBollettino.Name = "txtCodiceBollettino";
			this.txtCodiceBollettino.Size = new System.Drawing.Size(315, 20);
			this.txtCodiceBollettino.TabIndex = 47;
			this.txtCodiceBollettino.Tag = "";
			this.txtCodiceBollettino.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// btnElaboraAnnullamento
			// 
			this.btnElaboraAnnullamento.BackColor = System.Drawing.SystemColors.Control;
			this.btnElaboraAnnullamento.FlatAppearance.BorderSize = 2;
			this.btnElaboraAnnullamento.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnElaboraAnnullamento.ForeColor = System.Drawing.SystemColors.ControlText;
			this.btnElaboraAnnullamento.Location = new System.Drawing.Point(10, 16);
			this.btnElaboraAnnullamento.Name = "btnElaboraAnnullamento";
			this.btnElaboraAnnullamento.Size = new System.Drawing.Size(122, 23);
			this.btnElaboraAnnullamento.TabIndex = 48;
			this.btnElaboraAnnullamento.TabStop = false;
			this.btnElaboraAnnullamento.Tag = "";
			this.btnElaboraAnnullamento.Text = "Elabora Annullamento:";
			this.btnElaboraAnnullamento.UseVisualStyleBackColor = false;
			this.btnElaboraAnnullamento.Click += new System.EventHandler(this.btnElaboraAnnullamento_Click);
			// 
			// btnAnnulla
			// 
			this.btnAnnulla.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnAnnulla.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnAnnulla.Location = new System.Drawing.Point(400, 227);
			this.btnAnnulla.Name = "btnAnnulla";
			this.btnAnnulla.Size = new System.Drawing.Size(75, 23);
			this.btnAnnulla.TabIndex = 69;
			this.btnAnnulla.Text = "Annulla";
			// 
			// btnOK
			// 
			this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnOK.Location = new System.Drawing.Point(304, 227);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(75, 23);
			this.btnOK.TabIndex = 68;
			this.btnOK.Tag = "";
			this.btnOK.Text = "OK";
			// 
			// gBoxAnnulla
			// 
			this.gBoxAnnulla.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.gBoxAnnulla.Controls.Add(this.txtCodiceBollettino);
			this.gBoxAnnulla.Controls.Add(this.btnElaboraAnnullamento);
			this.gBoxAnnulla.Location = new System.Drawing.Point(12, 12);
			this.gBoxAnnulla.Name = "gBoxAnnulla";
			this.gBoxAnnulla.Size = new System.Drawing.Size(462, 44);
			this.gBoxAnnulla.TabIndex = 52;
			this.gBoxAnnulla.TabStop = false;
			// 
			// dgrCreditiAnnullati
			// 
			this.dgrCreditiAnnullati.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dgrCreditiAnnullati.DataMember = "";
			this.dgrCreditiAnnullati.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dgrCreditiAnnullati.Location = new System.Drawing.Point(12, 74);
			this.dgrCreditiAnnullati.Name = "dgrCreditiAnnullati";
			this.dgrCreditiAnnullati.Size = new System.Drawing.Size(463, 128);
			this.dgrCreditiAnnullati.TabIndex = 70;
			this.dgrCreditiAnnullati.Tag = "flussocreditidetail.default_annullati";
			this.dgrCreditiAnnullati.DoubleClick += new System.EventHandler(this.datagrid_DoubleClick);
			// 
			// FrmAnnullaDettaglio
			// 
			this.AcceptButton = this.btnOK;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnAnnulla;
			this.ClientSize = new System.Drawing.Size(504, 262);
			this.Controls.Add(this.dgrCreditiAnnullati);
			this.Controls.Add(this.btnAnnulla);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.gBoxAnnulla);
			this.Name = "FrmAnnullaDettaglio";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "FrmAnnullaDettaglio";
			this.gBoxAnnulla.ResumeLayout(false);
			this.gBoxAnnulla.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgrCreditiAnnullati)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion
		public System.Windows.Forms.TextBox txtCodiceBollettino;
		public System.Windows.Forms.Button btnElaboraAnnullamento;
		private System.Windows.Forms.Button btnAnnulla;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.GroupBox gBoxAnnulla;
		private System.Windows.Forms.DataGrid dgrCreditiAnnullati;
	}
}
