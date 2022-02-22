
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
using metaeasylibrary;
using System.Data;

namespace changedepartmentpassword_default
{
	/// <summary>
	/// Summary description for FrmChangeDepartPwd.
	/// </summary>
	public class FrmChangeDepartPwd : MetaDataForm
	{
		public DataSet DS;
		MetaData Meta;
		private System.Windows.Forms.GroupBox groupBox1;
		public System.Windows.Forms.TextBox txtNew1;
		private System.Windows.Forms.Label label2;
		public System.Windows.Forms.TextBox txtOld;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnOk;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public FrmChangeDepartPwd()
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

		public void MetaData_AfterFill() {
			Meta = MetaData.GetMetaData(this);
			bool isAdmin = (bool) Meta.GetSys("isAdmin");
			groupBox1.Enabled = isAdmin;
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtNew1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtOld = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.txtNew1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtOld);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnCancel);
            this.groupBox1.Controls.Add(this.btnOk);
            this.groupBox1.Location = new System.Drawing.Point(8, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(408, 152);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // txtNew1
            // 
            this.txtNew1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNew1.Location = new System.Drawing.Point(16, 80);
            this.txtNew1.MaxLength = 31;
            this.txtNew1.Name = "txtNew1";
            this.txtNew1.PasswordChar = '*';
            this.txtNew1.Size = new System.Drawing.Size(376, 20);
            this.txtNew1.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(12, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(172, 16);
            this.label2.TabIndex = 6;
            this.label2.Text = "Nuova password del dipartimento";
            // 
            // txtOld
            // 
            this.txtOld.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOld.Location = new System.Drawing.Point(16, 32);
            this.txtOld.Name = "txtOld";
            this.txtOld.PasswordChar = '*';
            this.txtOld.Size = new System.Drawing.Size(376, 20);
            this.txtOld.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(12, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(196, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "Vecchia password del dipartimento";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(216, 112);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Annulla";
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(112, 112);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 3;
            this.btnOk.Text = "Ok";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // FrmChangeDepartPwd
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(424, 174);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmChangeDepartPwd";
            this.Text = "Cambio della password per l\'accesso al Dipartimento";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion

		public void MetaData_AfterLink(){
			Meta = MetaData.GetMetaData(this);	
		}

		private void btnOk_Click(object sender, System.EventArgs e) {
			Easy_DataAccess DepConn =  (Easy_DataAccess) MetaData.GetConnection(this);
			string old = txtOld.Text;
			string dbuser = DepConn.GetSys("userdb").ToString();

			DataAccess Try= new DataAccess("temp",
				DepConn.GetSys("server").ToString(), DepConn.GetSys("database").ToString(),
				dbuser,old,DateTime.Now.Year,DateTime.Now);
			Try.Open();
			if (Try.openError){
				show(this,"La vecchia password inserita non è corretta!","Errore");
				DialogResult = DialogResult.None;
				return;
			}

			PwdConfirm Confirm = new PwdConfirm(1);
			DialogResult Res=  Confirm.ShowDialog(this);
			if (Res!=DialogResult.OK){
				DialogResult = DialogResult.None;
				return;
			}
			string new1= txtNew1.Text.ToUpper();
			string new2= Confirm.txtPwd.Text.ToUpper();
			if (new1!=new2) {
				show(this,"La password inserita come conferma era diversa!","Errore");
				DialogResult = DialogResult.None;
				return;
			}
			if (new1.Length == 0) {
				show(this, "La password deve essere composta da almeno 1 carattere");
				this.DialogResult = DialogResult.None;
				return;
			}
			byte []oldpwd= DataAccess.CryptString(old);
			byte []newpwd= DataAccess.CryptString(new1);
			if (DepConn.changeDepartmentPassword(oldpwd,newpwd)){
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
					DepConn.changeDepartmentPassword(oldpwd,newpwd);//Annulla l'azione del precedente!!
					DialogResult = DialogResult.None;
					return;
				}
				DepConn.SetSys("passworddb", new1);
				show(this, "Password reimpostata con successo");
			} else {
				show(this, "Non è stato possibile cambiare la password");
			}
		}
	}
}
