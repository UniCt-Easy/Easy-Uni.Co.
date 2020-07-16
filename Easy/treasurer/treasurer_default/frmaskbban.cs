/*
    Easy
    Copyright (C) 2020 Universit√† degli Studi di Catania (www.unict.it)
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

namespace treasurer_default//istitutocassiere//
{
	/// <summary>
	/// Summary description for frmaskbban.
	/// </summary>
	public class frmaskbban : System.Windows.Forms.Form
	{
		private System.Windows.Forms.TextBox txtBBAN;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Label label1;
		bool inChiusura = false;
		public string insertedBBAN = "";
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmaskbban(int i)
		{
			InitializeComponent();
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			inChiusura = true;
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
			this.txtBBAN = new System.Windows.Forms.TextBox();
			this.button2 = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// txtBBAN
			// 
			this.txtBBAN.Location = new System.Drawing.Point(144, 18);
			this.txtBBAN.Name = "txtBBAN";
			this.txtBBAN.Size = new System.Drawing.Size(200, 20);
			this.txtBBAN.TabIndex = 15;
			this.txtBBAN.Text = "";
			this.txtBBAN.Leave += new System.EventHandler(this.txtBBAN_Leave);
			// 
			// button2
			// 
			this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.button2.Location = new System.Drawing.Point(192, 94);
			this.button2.Name = "button2";
			this.button2.TabIndex = 14;
			this.button2.Text = "Cancel";
			// 
			// button1
			// 
			this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.button1.Location = new System.Drawing.Point(80, 94);
			this.button1.Name = "button1";
			this.button1.TabIndex = 13;
			this.button1.Text = "Ok";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 18);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(128, 20);
			this.label1.TabIndex = 12;
			this.label1.Text = "Inserisci il codice BBAN:";
			// 
			// frmaskbban
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(352, 134);
			this.Controls.Add(this.txtBBAN);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.label1);
			this.Name = "frmaskbban";
			this.Text = "Codice BBAN";
			this.ResumeLayout(false);

		}
		#endregion

		private void txtBBAN_Leave(object sender, System.EventArgs e)
		{
			if (inChiusura) return;
			//Lunghezza del BBAN = 1 (CIN) + 5 (ABI) + 5(CAB) + 12 (C/C) = 23
			if (txtBBAN.Text.Length != 23)
			{
				MessageBox.Show("Attenzione il BBAN inserito non Ë corretto!");
				insertedBBAN = "";
			}
			else
			{
				insertedBBAN = txtBBAN.Text;
			}
		}
	}
}
