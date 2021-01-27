
/*
Easy
Copyright (C) 2021 Università degli Studi di Catania (www.unict.it)
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
using checkflags;//checkflags

namespace license_manage//licenzausomanage//
{
	/// <summary>
	/// Summary description for frmPassword.
	/// </summary>
	public class Frm_Password : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button btnAnnulla;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.TextBox txtPwd;
		private System.Windows.Forms.Label label1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Frm_Password(int N)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
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
			this.btnAnnulla = new System.Windows.Forms.Button();
			this.btnOK = new System.Windows.Forms.Button();
			this.txtPwd = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// btnAnnulla
			// 
			this.btnAnnulla.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnAnnulla.Location = new System.Drawing.Point(144, 48);
			this.btnAnnulla.Name = "btnAnnulla";
			this.btnAnnulla.TabIndex = 7;
			this.btnAnnulla.Text = "Annulla";
			// 
			// btnOK
			// 
			this.btnOK.Location = new System.Drawing.Point(48, 48);
			this.btnOK.Name = "btnOK";
			this.btnOK.TabIndex = 6;
			this.btnOK.Text = "OK";
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// txtPwd
			// 
			this.txtPwd.Location = new System.Drawing.Point(144, 8);
			this.txtPwd.Name = "txtPwd";
			this.txtPwd.PasswordChar = '?';
			this.txtPwd.Size = new System.Drawing.Size(112, 20);
			this.txtPwd.TabIndex = 5;
			this.txtPwd.Text = "";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(16, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(109, 16);
			this.label1.TabIndex = 4;
			this.label1.Text = "Inserire la password";
			// 
			// frmPassword
			// 
			this.AcceptButton = this.btnOK;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.btnAnnulla;
			this.ClientSize = new System.Drawing.Size(292, 85);
			this.Controls.Add(this.btnAnnulla);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.txtPwd);
			this.Controls.Add(this.label1);
			this.Name = "frmPassword";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "frmPassword";
			this.ResumeLayout(false);

		}
		#endregion

		private void btnOK_Click(object sender, System.EventArgs e) {

			//string check2= CheckFlags.GetCheck("falcoJ41AB");
			//MessageBox.Show(check2);
			string check= CheckFlags.GetCheck(txtPwd.Text);
			if (check!="0x4C4AD48720B7475B3B24155DB41CCBCB518EF4F6") {
				MessageBox.Show("Password errata", "Password",
					MessageBoxButtons.OK, MessageBoxIcon.Information);
				txtPwd.SelectAll();
				txtPwd.Focus();
				return;
			}
			this.DialogResult=DialogResult.OK;
		}
	}
}
