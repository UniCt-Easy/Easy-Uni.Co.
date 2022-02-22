
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


namespace mandate_default {
	partial class FrmAnnullaDettaglio {
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
			this.gBoxCausale = new System.Windows.Forms.GroupBox();
			this.txtCausaleAnnullo = new System.Windows.Forms.TextBox();
			this.btnCausaleAnnullamento = new System.Windows.Forms.Button();
			this.label25 = new System.Windows.Forms.Label();
			this.txtStop = new System.Windows.Forms.TextBox();
			this.btnAnnulla = new System.Windows.Forms.Button();
			this.btnOK = new System.Windows.Forms.Button();
			this.gBoxCausale.SuspendLayout();
			this.SuspendLayout();
			// 
			// gBoxCausale
			// 
			this.gBoxCausale.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.gBoxCausale.Controls.Add(this.txtCausaleAnnullo);
			this.gBoxCausale.Controls.Add(this.btnCausaleAnnullamento);
			this.gBoxCausale.Location = new System.Drawing.Point(254, 12);
			this.gBoxCausale.Name = "gBoxCausale";
			this.gBoxCausale.Size = new System.Drawing.Size(380, 44);
			this.gBoxCausale.TabIndex = 52;
			this.gBoxCausale.TabStop = false;
			// 
			// txtCausaleAnnullo
			// 
			this.txtCausaleAnnullo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtCausaleAnnullo.Location = new System.Drawing.Point(141, 17);
			this.txtCausaleAnnullo.Name = "txtCausaleAnnullo";
			this.txtCausaleAnnullo.Size = new System.Drawing.Size(233, 20);
			this.txtCausaleAnnullo.TabIndex = 47;
			this.txtCausaleAnnullo.Tag = "";
			this.txtCausaleAnnullo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.txtCausaleAnnullo.Leave += new System.EventHandler(this.txtCausaleAnnullo_Leave);
			// 
			// btnCausaleAnnullamento
			// 
			this.btnCausaleAnnullamento.BackColor = System.Drawing.SystemColors.Control;
			this.btnCausaleAnnullamento.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnCausaleAnnullamento.ForeColor = System.Drawing.SystemColors.ControlText;
			this.btnCausaleAnnullamento.Location = new System.Drawing.Point(15, 16);
			this.btnCausaleAnnullamento.Name = "btnCausaleAnnullamento";
			this.btnCausaleAnnullamento.Size = new System.Drawing.Size(122, 23);
			this.btnCausaleAnnullamento.TabIndex = 48;
			this.btnCausaleAnnullamento.TabStop = false;
			this.btnCausaleAnnullamento.Tag = "";
			this.btnCausaleAnnullamento.Text = "Causale annullamento:";
			this.btnCausaleAnnullamento.UseVisualStyleBackColor = false;
			this.btnCausaleAnnullamento.Click += new System.EventHandler(this.btnCausaleAnnullamento_Click);
			// 
			// label25
			// 
			this.label25.Location = new System.Drawing.Point(22, 30);
			this.label25.Name = "label25";
			this.label25.Size = new System.Drawing.Size(104, 16);
			this.label25.TabIndex = 51;
			this.label25.Text = "Data annullamento:";
			this.label25.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// txtStop
			// 
			this.txtStop.Location = new System.Drawing.Point(131, 29);
			this.txtStop.Name = "txtStop";
			this.txtStop.Size = new System.Drawing.Size(104, 20);
			this.txtStop.TabIndex = 50;
			this.txtStop.Tag = "";
			// 
			// btnAnnulla
			// 
			this.btnAnnulla.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnAnnulla.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnAnnulla.Location = new System.Drawing.Point(560, 70);
			this.btnAnnulla.Name = "btnAnnulla";
			this.btnAnnulla.Size = new System.Drawing.Size(75, 23);
			this.btnAnnulla.TabIndex = 69;
			this.btnAnnulla.Text = "Annulla";
			// 
			// btnOK
			// 
			this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnOK.Location = new System.Drawing.Point(464, 70);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(75, 23);
			this.btnOK.TabIndex = 68;
			this.btnOK.Tag = "";
			this.btnOK.Text = "OK";
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// FrmAnnullaDettaglio
			// 
			this.AcceptButton = this.btnOK;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnAnnulla;
			this.ClientSize = new System.Drawing.Size(664, 105);
			this.Controls.Add(this.btnAnnulla);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.gBoxCausale);
			this.Controls.Add(this.label25);
			this.Controls.Add(this.txtStop);
			this.Name = "FrmAnnullaDettaglio";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "FrmAnnullaDettaglio";
			this.gBoxCausale.ResumeLayout(false);
			this.gBoxCausale.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.GroupBox gBoxCausale;
		public System.Windows.Forms.TextBox txtCausaleAnnullo;
		public System.Windows.Forms.Button btnCausaleAnnullamento;
		private System.Windows.Forms.Label label25;
		public System.Windows.Forms.TextBox txtStop;
		private System.Windows.Forms.Button btnAnnulla;
		private System.Windows.Forms.Button btnOK;
	}
}
