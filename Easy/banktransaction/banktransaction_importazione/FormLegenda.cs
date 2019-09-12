/*
    Easy
    Copyright (C) 2019 Università degli Studi di Catania (www.unict.it)

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

namespace banktransaction_importazione//movimentobancario_import//
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Frm_Legenda : System.Windows.Forms.Form
	{
		internal System.Windows.Forms.DataGrid dataGridLegenda;
		internal System.Windows.Forms.TextBox textBox1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Frm_Legenda(int i)
		{
			InitializeComponent();
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
			this.dataGridLegenda = new System.Windows.Forms.DataGrid();
			this.textBox1 = new System.Windows.Forms.TextBox();
			((System.ComponentModel.ISupportInitialize)(this.dataGridLegenda)).BeginInit();
			this.SuspendLayout();
			// 
			// dataGridLegenda
			// 
			this.dataGridLegenda.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.dataGridLegenda.DataMember = "";
			this.dataGridLegenda.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGridLegenda.Location = new System.Drawing.Point(8, 152);
			this.dataGridLegenda.Name = "dataGridLegenda";
			this.dataGridLegenda.Size = new System.Drawing.Size(616, 288);
			this.dataGridLegenda.TabIndex = 0;
			// 
			// textBox1
			// 
			this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.textBox1.Location = new System.Drawing.Point(8, 8);
			this.textBox1.Multiline = true;
			this.textBox1.Name = "textBox1";
			this.textBox1.ReadOnly = true;
			this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBox1.Size = new System.Drawing.Size(616, 144);
			this.textBox1.TabIndex = 1;
			this.textBox1.Text = "";
			// 
			// FormLegenda
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(632, 446);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.dataGridLegenda);
			this.Name = "FormLegenda";
			this.Text = "Legenda del foglio Excel";
			((System.ComponentModel.ISupportInitialize)(this.dataGridLegenda)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion
	}
}
