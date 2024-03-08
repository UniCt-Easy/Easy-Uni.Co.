
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
using metadatalibrary;
using System.Data;
using metaeasylibrary;

namespace changepassword_default//ChangePwd//
{
	/// <summary>
	/// Summary description for FrmChangePwd.
	/// </summary>
	public class Frm_changepassword_default : MetaDataForm
	{
		private System.Windows.Forms.Label label1;
		public System.Windows.Forms.TextBox txtOld;
		private System.Windows.Forms.Label label2;
		public System.Windows.Forms.TextBox txtNew1;
		private System.Windows.Forms.Button btnOk;
		private System.Windows.Forms.Button btnCancel;
		public DataSet DS;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Frm_changepassword_default()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			DS = new DataSet();
		
			DataTable T = new DataTable("changepassword");
			DS.Tables.Add(T);

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

		public void MetaData_AfterClear(){
			Text="Cambio della password per l'accesso al DB";
		}
		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.label1 = new System.Windows.Forms.Label();
            this.txtOld = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNew1 = new System.Windows.Forms.TextBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(16, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(168, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Vecchia password";
            // 
            // txtOld
            // 
            this.txtOld.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOld.Location = new System.Drawing.Point(16, 24);
            this.txtOld.Name = "txtOld";
            this.txtOld.PasswordChar = '*';
            this.txtOld.Size = new System.Drawing.Size(312, 20);
            this.txtOld.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(16, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Nuova password";
            // 
            // txtNew1
            // 
            this.txtNew1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNew1.Location = new System.Drawing.Point(16, 80);
            this.txtNew1.MaxLength = 31;
            this.txtNew1.Name = "txtNew1";
            this.txtNew1.PasswordChar = '*';
            this.txtNew1.Size = new System.Drawing.Size(312, 20);
            this.txtNew1.TabIndex = 3;
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(80, 128);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 4;
            this.btnOk.Text = "Ok";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(192, 128);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Annulla";
            // 
            // Frm_changepassword_default
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(346, 168);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.txtNew1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtOld);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Frm_changepassword_default";
            this.Text = "Cambio della password SQL";
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void btnOk_Click(object sender, System.EventArgs e) {
			Easy_DataAccess DepConn =  (Easy_DataAccess) MetaData.GetConnection(this);
			string old = txtOld.Text;
			string user = DepConn.GetSys("user").ToString();

			DataAccess Try= new DataAccess("temp",
							DepConn.GetSys("server").ToString(), DepConn.GetSys("database").ToString(),
							user,old,DateTime.Now.Year,DateTime.Now);
			Try.Open();
			if (Try.openError){
				show(this,"La vecchia password inserita non è corretta!","Errore");
				DialogResult = DialogResult.None;
				return;
			}
							
			PwdConfirm Confirm = new PwdConfirm("s");
			DialogResult Res=  Confirm.ShowDialog(this);
			if (Res!=DialogResult.OK){
				DialogResult = DialogResult.None;
				return;
			}
			string new1= txtNew1.Text;
			string new2= Confirm.txtPwd.Text;
			if (new1!=new2) {
				show(this,"La password inserita come conferma era diversa!","Errore");
				DialogResult = DialogResult.None;
				return;
			}
			byte []oldalfa= Easy_DataAccess.getAlfaFromPassword(old);
			byte []newalfa= Easy_DataAccess.getAlfaFromPassword(new1);
			if (DepConn.changeUserPassword(oldalfa,newalfa)) {
				object PWDOLD = (old=="") ? DBNull.Value : (object) old;
				object PWDNEW = (new1=="") ? DBNull.Value : (object) new1;
				string err;
				string sql = "sp_password "+
					QueryCreator.quotedstrvalue(PWDOLD,true)+","+
					QueryCreator.quotedstrvalue(PWDNEW,true);				
				object O = Try.DO_SYS_CMD(sql, out err);
				Try.Destroy();
				if (err!=null){
					QueryCreator.ShowError(this,"Errore nell'impostazione della password", err);
					DepConn.changeUserPassword(oldalfa,newalfa);//Annulla l'azione del precedente!!
					DialogResult = DialogResult.None;
					return;
				}
				DepConn.SetSys("password", new1);
                if (new1 == Easy_DataAccess.INITIAL_PASSWORD) {
                    DepConn.SetSys("initial_password_set", "S");
                }
                else {
                    DepConn.SetSys("initial_password_set", "N");
                }
				show(this, "Password reimpostata con successo");
			} else {
				show(this, "Non è stato possibile cambiare la password");
			}
			
		}
	}
}
