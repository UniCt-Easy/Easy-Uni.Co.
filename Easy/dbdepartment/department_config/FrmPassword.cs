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
using metadatalibrary;
using metaeasylibrary;

namespace dbdepartment_config
{
	/// <summary>
	/// Summary description for FrmPassword.
	/// </summary>
	public class FrmPassword : System.Windows.Forms.Form
	{
		private Easy_DataAccess Conn;
		private string idDbDepartment;
		private System.Windows.Forms.TextBox txtConferma;
		private System.Windows.Forms.Label label3;
		public System.Windows.Forms.TextBox txtPassword;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.Button btnCancel;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public FrmPassword(Easy_DataAccess mainConn, string iddbdepartment)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			idDbDepartment = iddbdepartment;
			Conn = mainConn;
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
			this.txtConferma = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.txtPassword = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.btnOK = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// txtConferma
			// 
			this.txtConferma.Location = new System.Drawing.Point(112, 80);
			this.txtConferma.MaxLength = 31;
			this.txtConferma.Name = "txtConferma";
			this.txtConferma.PasswordChar = '*';
			this.txtConferma.Size = new System.Drawing.Size(160, 20);
			this.txtConferma.TabIndex = 8;
			this.txtConferma.Text = "";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(8, 80);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(112, 20);
			this.label3.TabIndex = 9;
			this.label3.Text = "Conferma password";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtPassword
			// 
			this.txtPassword.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.txtPassword.Location = new System.Drawing.Point(112, 32);
			this.txtPassword.MaxLength = 31;
			this.txtPassword.Name = "txtPassword";
			this.txtPassword.PasswordChar = '*';
			this.txtPassword.Size = new System.Drawing.Size(160, 20);
			this.txtPassword.TabIndex = 7;
			this.txtPassword.Tag = "";
			this.txtPassword.Text = "";
			// 
			// label2
			// 
			this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label2.Location = new System.Drawing.Point(56, 32);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(64, 20);
			this.label2.TabIndex = 6;
			this.label2.Text = "Password";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// btnOK
			// 
			this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnOK.Location = new System.Drawing.Point(56, 168);
			this.btnOK.Name = "btnOK";
			this.btnOK.TabIndex = 10;
			this.btnOK.Text = "OK";
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(176, 168);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.TabIndex = 11;
			this.btnCancel.Text = "Annulla";
			// 
			// FrmPassword
			// 
			this.AcceptButton = this.btnOK;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(292, 222);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.txtConferma);
			this.Controls.Add(this.txtPassword);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Name = "FrmPassword";
			this.Text = "FrmPassword";
			this.ResumeLayout(false);

		}
		#endregion

		private void btnOK_Click(object sender, System.EventArgs e) {
			string password1 = txtPassword.Text;
			string password2 = txtConferma.Text;
			if (password1 != password2) {
				MessageBox.Show(this, "Digitare la stessa parola sia nel campo 'password' che nel campo 'conferma password'");
				this.DialogResult = DialogResult.None;
				return;
			}
			if (password1.Length == 0) {
				MessageBox.Show(this, "La password deve essere composta da almeno 1 carattere");
				this.DialogResult = DialogResult.None;
				return;
			}
			byte[] password = Easy_DataAccess.CryptString(password1.PadRight(31));
			string errore;
			byte[] nuovoAlfa1;
			Easy_DataAccess newConn = Conn.getDepartmentConnection(idDbDepartment, password, out errore, out nuovoAlfa1);
			if (errore != null) {
				MessageBox.Show(this, "La password inserita non è valida per operare sul dipartimento " + idDbDepartment + "\r\n." + errore);
				this.DialogResult = DialogResult.None;
				return;
			}
			this.DialogResult = DialogResult.OK;
		}
	}
}