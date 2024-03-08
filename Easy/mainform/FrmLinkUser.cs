
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


using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using metaeasylibrary;
using metadatalibrary;

namespace mainform
{
	/// <summary>
	/// Summary description for FrmLinkUser.
	/// </summary>
	public class FrmLinkUser : MetaDataForm
	{
		private System.Windows.Forms.TextBox txtLogin;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox txtNomeDip;
		private System.Windows.Forms.TextBox txt;
		private System.Windows.Forms.Button btnOk;
		private System.Windows.Forms.Button button1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		Easy_DataAccess Conn;

		public FrmLinkUser(Easy_DataAccess Conn)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			this.Conn=Conn;

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
			this.txtLogin = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.txtNomeDip = new System.Windows.Forms.TextBox();
			this.txt = new System.Windows.Forms.TextBox();
			this.btnOk = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// txtLogin
			// 
			this.txtLogin.Location = new System.Drawing.Point(8, 40);
			this.txtLogin.Name = "txtLogin";
			this.txtLogin.Size = new System.Drawing.Size(264, 20);
			this.txtLogin.TabIndex = 0;
			this.txtLogin.Text = "";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(232, 16);
			this.label1.TabIndex = 1;
			this.label1.Text = "Login utente";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(8, 112);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(224, 16);
			this.label2.TabIndex = 2;
			this.label2.Text = "Password dipartimento";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(8, 64);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(100, 16);
			this.label3.TabIndex = 3;
			this.label3.Text = "Nome dipartimento";
			// 
			// txtNomeDip
			// 
			this.txtNomeDip.Location = new System.Drawing.Point(8, 80);
			this.txtNomeDip.Name = "txtNomeDip";
			this.txtNomeDip.Size = new System.Drawing.Size(264, 20);
			this.txtNomeDip.TabIndex = 4;
			this.txtNomeDip.Text = "";
			// 
			// txt
			// 
			this.txt.Location = new System.Drawing.Point(8, 136);
			this.txt.Name = "txt";
			this.txt.PasswordChar = '*';
			this.txt.Size = new System.Drawing.Size(264, 20);
			this.txt.TabIndex = 5;
			this.txt.Text = "";
			// 
			// btnOk
			// 
			this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnOk.Location = new System.Drawing.Point(24, 168);
			this.btnOk.Name = "btnOk";
			this.btnOk.Size = new System.Drawing.Size(88, 24);
			this.btnOk.TabIndex = 6;
			this.btnOk.Text = "Ok";
			this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
			// 
			// button1
			// 
			this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.button1.Location = new System.Drawing.Point(152, 168);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(104, 24);
			this.button1.TabIndex = 7;
			this.button1.Text = "Annulla";
			// 
			// FrmLinkUser
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(296, 213);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.btnOk);
			this.Controls.Add(this.txt);
			this.Controls.Add(this.txtNomeDip);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.txtLogin);
			this.Name = "FrmLinkUser";
			this.Text = "FrmLinkUser";
			this.ResumeLayout(false);

		}
		#endregion

		private void btnOk_Click(object sender, System.EventArgs e) {
			string error;
			Conn.linkUserToDepartment(txtLogin.Text,out error);
            if (error==null) return;
			show("Prolemi nel resettare la password dell'utente: "+error);
			DialogResult = DialogResult.None;
			
		}
	}
}
