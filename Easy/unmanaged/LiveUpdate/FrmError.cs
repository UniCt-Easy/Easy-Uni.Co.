
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


using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using metadatalibrary;

namespace LiveUpdate
{
	/// <summary>
	/// Summary description for FrmError.
	/// </summary>
	public class FrmError : MetaDataForm
	{
		private System.Windows.Forms.Button btnContinua;
		private System.Windows.Forms.Button btnInterrompi;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Label label1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public FrmError(string nomeScript, string messaggio)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			Text = "Errore durante l'esecuzione dello script '"+nomeScript+"'";
			textBox1.Text = QueryCreator.GetPrintable(messaggio);
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.btnContinua = new System.Windows.Forms.Button();
			this.btnInterrompi = new System.Windows.Forms.Button();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// btnContinua
			// 
			this.btnContinua.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnContinua.DialogResult = System.Windows.Forms.DialogResult.Yes;
			this.btnContinua.Location = new System.Drawing.Point(280, 472);
			this.btnContinua.Name = "btnContinua";
			this.btnContinua.TabIndex = 0;
			this.btnContinua.Text = "Continua";
			// 
			// btnInterrompi
			// 
			this.btnInterrompi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnInterrompi.DialogResult = System.Windows.Forms.DialogResult.No;
			this.btnInterrompi.Location = new System.Drawing.Point(376, 472);
			this.btnInterrompi.Name = "btnInterrompi";
			this.btnInterrompi.TabIndex = 1;
			this.btnInterrompi.Text = "Interrompi";
			// 
			// textBox1
			// 
			this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.textBox1.Location = new System.Drawing.Point(8, 8);
			this.textBox1.Multiline = true;
			this.textBox1.Name = "textBox1";
			this.textBox1.ReadOnly = true;
			this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.textBox1.Size = new System.Drawing.Size(696, 456);
			this.textBox1.TabIndex = 2;
			this.textBox1.Text = "";
			// 
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label1.Location = new System.Drawing.Point(88, 472);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(192, 23);
			this.label1.TabIndex = 3;
			this.label1.Text = "Continuare l\'esecuzione dello script?";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// FrmError
			// 
			this.AcceptButton = this.btnContinua;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.btnInterrompi;
			this.ClientSize = new System.Drawing.Size(712, 506);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.btnInterrompi);
			this.Controls.Add(this.btnContinua);
			this.Name = "FrmError";
			this.Text = "Errore durante l\'esecuzione dello script";
			this.ResumeLayout(false);

		}
		#endregion
	}
}
