
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
using metadatalibrary;
using System.Data;

namespace EasyInstall//Install//
{
	/// <summary>
	/// Summary description for FrmAskLoginData.
	/// </summary>
	public class FrmAskLoginData : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtNome;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtPWD1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox txtPWD2;
		private System.Windows.Forms.CheckBox chkSSPI;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Button btnOk;
		private System.Windows.Forms.Button btnCancel;
		DataAccess Conn;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public FrmAskLoginData(DataAccess Conn)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
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
			this.label1 = new System.Windows.Forms.Label();
			this.txtNome = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.txtPWD1 = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.txtPWD2 = new System.Windows.Forms.TextBox();
			this.chkSSPI = new System.Windows.Forms.CheckBox();
			this.btnOk = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.label4 = new System.Windows.Forms.Label();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 56);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(256, 16);
			this.label1.TabIndex = 0;
			this.label1.Text = "Nome";
			// 
			// txtNome
			// 
			this.txtNome.Location = new System.Drawing.Point(8, 72);
			this.txtNome.Name = "txtNome";
			this.txtNome.Size = new System.Drawing.Size(248, 20);
			this.txtNome.TabIndex = 1;
			this.txtNome.Text = "";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(16, 24);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(100, 16);
			this.label2.TabIndex = 2;
			this.label2.Text = "Password";
			// 
			// txtPWD1
			// 
			this.txtPWD1.Location = new System.Drawing.Point(16, 40);
			this.txtPWD1.Name = "txtPWD1";
			this.txtPWD1.PasswordChar = '*';
			this.txtPWD1.Size = new System.Drawing.Size(248, 20);
			this.txtPWD1.TabIndex = 3;
			this.txtPWD1.Text = "";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(16, 64);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(208, 16);
			this.label3.TabIndex = 4;
			this.label3.Text = "Conferma Password";
			// 
			// txtPWD2
			// 
			this.txtPWD2.Location = new System.Drawing.Point(16, 80);
			this.txtPWD2.Name = "txtPWD2";
			this.txtPWD2.PasswordChar = '*';
			this.txtPWD2.Size = new System.Drawing.Size(248, 20);
			this.txtPWD2.TabIndex = 5;
			this.txtPWD2.Text = "";
			// 
			// chkSSPI
			// 
			this.chkSSPI.Location = new System.Drawing.Point(8, 96);
			this.chkSSPI.Name = "chkSSPI";
			this.chkSSPI.Size = new System.Drawing.Size(248, 24);
			this.chkSSPI.TabIndex = 6;
			this.chkSSPI.Text = "Usa Sicurezza integrata";
			this.chkSSPI.Visible = false;
			this.chkSSPI.CheckedChanged += new System.EventHandler(this.chkSSPI_CheckedChanged);
			// 
			// btnOk
			// 
			this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnOk.Location = new System.Drawing.Point(144, 248);
			this.btnOk.Name = "btnOk";
			this.btnOk.TabIndex = 7;
			this.btnOk.Text = "Ok";
			this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(240, 248);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.TabIndex = 8;
			this.btnCancel.Text = "Annulla";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.txtPWD1);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.txtPWD2);
			this.groupBox1.Location = new System.Drawing.Point(8, 120);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(424, 120);
			this.groupBox1.TabIndex = 9;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Dati per sicurezza SQL";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(8, 8);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(424, 40);
			this.label4.TabIndex = 10;
			this.label4.Text = "Nota: per usare la sicurezza integrata, il nome deve riferirsi ad un account wind" +
				"ows esistente sul server.";
			// 
			// FrmAskLoginData
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(448, 285);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOk);
			this.Controls.Add(this.chkSSPI);
			this.Controls.Add(this.txtNome);
			this.Controls.Add(this.label1);
			this.Name = "FrmAskLoginData";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "FrmAskLoginData";
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void chkSSPI_CheckedChanged(object sender, System.EventArgs e) {
			txtPWD1.ReadOnly=chkSSPI.Checked;
			txtPWD2.ReadOnly=chkSSPI.Checked;
		}

		private void btnOk_Click(object sender, System.EventArgs e) {
			if (txtNome.Text.Trim()==""){
				MetaFactory.factory.getSingleton<IMessageShower>().Show("E' necessario specificare un nome per la login da creare");
				DialogResult= DialogResult.None;
				txtNome.Focus();
				return;
			}
			string username=txtNome.Text.Trim();
			DataTable T1= Conn.SQLRunner(
				"select DISTINCT loginname = (case when (o.sid = 0x00) then NULL else l.loginname end) "+
				" from dbo.sysusers o "+
				"left join master.dbo.syslogins l on l.sid = o.sid "+
				"where ((o.issqlrole != 1 and o.isapprole != 1 ) or (o.sid = 0x00) "+
				"and o.hasdbaccess = 1)and o.isaliased != 1 ");
			if (T1!=null){
				foreach(DataRow R1 in T1.Rows){
					if (R1["loginname"].ToString().ToUpper()==username.ToUpper()){
						MetaFactory.factory.getSingleton<IMessageShower>().Show("La login "+R1["loginname"].ToString()+
							" è già presente nel server.");
						DialogResult=DialogResult.None;
						txtNome.Focus();
						return;
					}
				}
			}

			if (chkSSPI.Checked){
				if (!CreateSSPIAccount()){
					DialogResult= DialogResult.None;
					return;
				}
			}
			else {
				if (!CreateSQLAccount()){
					DialogResult= DialogResult.None;
					return;
				}
			}
			MetaFactory.factory.getSingleton<IMessageShower>().Show("Account creato con successo.");
		}


		bool CreateSQLAccount(){
			if (txtPWD1.Text==""){
				MetaFactory.factory.getSingleton<IMessageShower>().Show("Specificare la password.");
				txtPWD1.Focus();
				return false;
			}
			if (txtPWD2.Text!=txtPWD1.Text){
				MetaFactory.factory.getSingleton<IMessageShower>().Show("Le due password inserite sono diverse.");
				txtPWD1.Focus();
				return false;
			}
			string username= txtNome.Text.Trim();

			string err;
			Conn.DO_SYS_CMD("EXEC sp_addlogin "+QueryCreator.quotedstrvalue(username,false)+
											","+QueryCreator.quotedstrvalue(txtPWD1.Text,false), out err);
			if (err!=null){
				MetaFactory.factory.getSingleton<IMessageShower>().Show("Errore: "+err);
				return false;
			}		
			return true;
		}

		bool CreateSSPIAccount(){
			string username= txtNome.Text.Trim();

			string err;
			Conn.DO_SYS_CMD("EXEC sp_grantlogin "+QueryCreator.quotedstrvalue(username,false), out err);
			if (err!=null){
				MetaFactory.factory.getSingleton<IMessageShower>().Show("Errore: "+err);
				return false;
			}		

			//EXEC sp_grantlogin 'Corporate\BobJ'
			return true;

		}
	}
}
