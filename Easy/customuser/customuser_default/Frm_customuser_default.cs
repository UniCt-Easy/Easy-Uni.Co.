/*
    Easy
    Copyright (C) 2020 Università degli Studi di Catania (www.unict.it)
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
using System.Data;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using metadatalibrary;


namespace customuser_default//customuser//
{
	/// <summary>
	/// Summary description for FrmCustomUser.
	/// </summary>
	public class Frm_customuser_default : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ListView listView1;
		public /*Rana:customuser.*/vistaForm DS;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.DataGrid dataGrid1;
		private System.Windows.Forms.Button btnDelVar;
		private System.Windows.Forms.Button btnEditVar;
		private System.Windows.Forms.Button btnInsertVar;
		private System.Windows.Forms.Button btnCopyAll;
		public MetaData meta;
		bool IsAdmin;
		private System.Windows.Forms.TextBox txtUserID;
		private System.Windows.Forms.TextBox txtUserName;
		string curruserid;


		public Frm_customuser_default()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			GetData.CacheTable(DS.customgroup);
			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}
		public void MetaData_AfterLink() 
		{
			meta = MetaData.GetMetaData(this);
			IsAdmin=false;
			if (meta.GetSys("IsSystemAdmin")!=null) {
				IsAdmin=(bool)meta.GetSys("IsSystemAdmin");
			}
			if (IsAdmin== false)
			{
				btnCopyAll.Enabled=false;
				meta.CanSave =false;
				meta.CanInsert=false;
				meta.CanCancel=false;
				meta.CanInsertCopy=false;
				DS.userenvironment.Columns["flagadmin"].DefaultValue="N";
				string filteruser="(username="+
					QueryCreator.quotedstrvalue(meta.GetSys("user"),true)+")";
				DataTable TBUsers= meta.Conn.RUN_SELECT("customuser","*",null,filteruser,null,false);
				string filterme;
				if ((TBUsers==null)||(TBUsers.Rows.Count==0)){
					curruserid="";
					filterme="(idcustomuser IS NULL)";
				}
				else {
					curruserid= TBUsers.Rows[0]["idcustomuser"].ToString();
					filterme = "(idcustomuser="+
						QueryCreator.quotedstrvalue(curruserid,true)+")";
				}
				GetData.SetStaticFilter(DS.userenvironment, filterme);
                MetaData.SetDefault(DS.userenvironment, "idcustomuser", curruserid);
				txtUserID.Enabled=false;
				MetaData.SetDefault(DS.userenvironment,"username", meta.GetSys("user"));
				txtUserName.ReadOnly=false;
			}
			

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
			meta.CanSave=true;
		}
		public void MetaData_AfterFill(){
			if (!IsAdmin){
				DataRow Curr = DS.customuser.Rows[0];
				meta.CanSave =  (Curr["idcustomuser"].ToString()==curruserid);
				if (meta.InsertMode) meta.CanSave=false;
			}
		}

		void SelectVariable(DataRow V){
			if (V==null){
				btnDelVar.Enabled=false;
				return;
			}
			if (IsAdmin){
				btnDelVar.Enabled=true;
				return;
			}

			if (V["flagadmin"].ToString().ToUpper()=="S"){
				btnDelVar.Enabled=true;
			}
			else {
				btnDelVar.Enabled=true;
			}
		}

		public void MetaData_AfterRowSelect(DataTable T, DataRow R){
			if (T.TableName == "userenvironment"){
				SelectVariable(R);
			}
		}


		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.label2 = new System.Windows.Forms.Label();
			this.listView1 = new System.Windows.Forms.ListView();
			this.DS = new /*Rana:customuser.*/vistaForm();
			this.txtUserID = new System.Windows.Forms.TextBox();
			this.txtUserName = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.btnCopyAll = new System.Windows.Forms.Button();
			this.btnDelVar = new System.Windows.Forms.Button();
			this.btnEditVar = new System.Windows.Forms.Button();
			this.btnInsertVar = new System.Windows.Forms.Button();
			this.dataGrid1 = new System.Windows.Forms.DataGrid();
			((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
			this.groupBox1.SuspendLayout();
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.tabPage2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
			this.SuspendLayout();
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(16, 16);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(88, 16);
			this.label2.TabIndex = 1;
			this.label2.Text = "Codice utente:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// listView1
			// 
			this.listView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.listView1.Location = new System.Drawing.Point(16, 24);
			this.listView1.Name = "listView1";
			this.listView1.Size = new System.Drawing.Size(544, 240);
			this.listView1.TabIndex = 4;
			this.listView1.Tag = "customgroup.default";
			// 
			// DS
			// 
			this.DS.DataSetName = "vistaForm";
			this.DS.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// txtUserID
			// 
			this.txtUserID.Location = new System.Drawing.Point(120, 16);
			this.txtUserID.Name = "txtUserID";
			this.txtUserID.Size = new System.Drawing.Size(192, 20);
			this.txtUserID.TabIndex = 3;
			this.txtUserID.Tag = "customuser.idcustomuser";
			this.txtUserID.Text = "";
			// 
			// txtUserName
			// 
			this.txtUserName.Location = new System.Drawing.Point(120, 48);
			this.txtUserName.Name = "txtUserName";
			this.txtUserName.Size = new System.Drawing.Size(192, 20);
			this.txtUserName.TabIndex = 7;
			this.txtUserName.Tag = "customuser.username";
			this.txtUserName.Text = "";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(32, 48);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(72, 16);
			this.label1.TabIndex = 6;
			this.label1.Text = "Nome utente:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox1.Controls.Add(this.listView1);
			this.groupBox1.Location = new System.Drawing.Point(24, 80);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(568, 280);
			this.groupBox1.TabIndex = 8;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Gruppi di sicurezza associati all\'utente:";
			// 
			// tabControl1
			// 
			this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Controls.Add(this.tabPage2);
			this.tabControl1.Location = new System.Drawing.Point(8, 8);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(616, 400);
			this.tabControl1.TabIndex = 9;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.txtUserName);
			this.tabPage1.Controls.Add(this.label1);
			this.tabPage1.Controls.Add(this.groupBox1);
			this.tabPage1.Controls.Add(this.label2);
			this.tabPage1.Controls.Add(this.txtUserID);
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Size = new System.Drawing.Size(608, 374);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Principale";
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.btnCopyAll);
			this.tabPage2.Controls.Add(this.btnDelVar);
			this.tabPage2.Controls.Add(this.btnEditVar);
			this.tabPage2.Controls.Add(this.btnInsertVar);
			this.tabPage2.Controls.Add(this.dataGrid1);
			this.tabPage2.Location = new System.Drawing.Point(4, 22);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Size = new System.Drawing.Size(608, 374);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "Variabili";
			// 
			// btnCopyAll
			// 
			this.btnCopyAll.Location = new System.Drawing.Point(392, 16);
			this.btnCopyAll.Name = "btnCopyAll";
			this.btnCopyAll.Size = new System.Drawing.Size(200, 23);
			this.btnCopyAll.TabIndex = 4;
			this.btnCopyAll.Text = "Copia la variabile per tutti gli utenti";
			this.btnCopyAll.Click += new System.EventHandler(this.btnCopyAll_Click);
			// 
			// btnDelVar
			// 
			this.btnDelVar.Location = new System.Drawing.Point(192, 16);
			this.btnDelVar.Name = "btnDelVar";
			this.btnDelVar.TabIndex = 3;
			this.btnDelVar.Tag = "delete";
			this.btnDelVar.Text = "Elimina";
			// 
			// btnEditVar
			// 
			this.btnEditVar.Location = new System.Drawing.Point(104, 16);
			this.btnEditVar.Name = "btnEditVar";
			this.btnEditVar.TabIndex = 2;
			this.btnEditVar.Tag = "edit.default";
			this.btnEditVar.Text = "Modifica";
			// 
			// btnInsertVar
			// 
			this.btnInsertVar.Location = new System.Drawing.Point(16, 16);
			this.btnInsertVar.Name = "btnInsertVar";
			this.btnInsertVar.TabIndex = 1;
			this.btnInsertVar.Tag = "insert.default";
			this.btnInsertVar.Text = "Inserisci...";
			// 
			// dataGrid1
			// 
			this.dataGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.dataGrid1.DataMember = "";
			this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGrid1.Location = new System.Drawing.Point(16, 48);
			this.dataGrid1.Name = "dataGrid1";
			this.dataGrid1.Size = new System.Drawing.Size(576, 304);
			this.dataGrid1.TabIndex = 0;
			this.dataGrid1.Tag = "userenvironment.default.default";
			// 
			// FrmCustomUser
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(640, 413);
			this.Controls.Add(this.tabControl1);
			this.Name = "FrmCustomUser";
			this.Text = "FrmCustomUser";
			this.Load += new System.EventHandler(this.FrmCustomUser_Load);
			((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.tabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tabPage2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void FrmCustomUser_Load(object sender, System.EventArgs e)
		{
		
		}

		private void btnCopyAll_Click(object sender, System.EventArgs e) {
			if (meta.IsEmpty)return;
			meta.DoMainCommand("mainsave");
			DataRow CurrVar = HelpForm.GetLastSelected(DS.userenvironment);
			if (CurrVar==null) return;
			bool Restricted=false;
			if (MessageBox.Show("Si vuole limitare la copia ai soli utenti facenti parte "+
				"degli stessi gruppi dell'utente corrente?","Opzioni",
				MessageBoxButtons.YesNo)==DialogResult.Yes) Restricted=true;
			string filterusers=null;
			vistaForm DS2 = new vistaForm();
			ClearDataSet.RemoveConstraints(DS2);
			if (Restricted){
				string grouplist = QueryCreator.ColumnValues(DS.customusergroup,
					null,"idcustomgroup",true);
				if (grouplist=="")
					filterusers="(idcustomuser is null)";
				else
					filterusers="(idcustomuser in (SELECT idcustomuser FROM customusergroup WHERE (idcustomgroup in ("+grouplist+"))))";

			}
			string filtervar = GetData.MergeFilters(filterusers, 
				"(variablename="+
				QueryCreator.quotedstrvalue(CurrVar["variablename"],true)
				+")");
			DataAccess.RUN_SELECT_INTO_TABLE(meta.Conn,DS2.customuser,null,filterusers,null,true);
			DataAccess.RUN_SELECT_INTO_TABLE(meta.Conn,DS2.userenvironment,null,filtervar,null,true);
			foreach (DataRow User in DS2.customuser.Rows){
				DataRow[] UserVar= User.GetChildRows("customuseruserenvironment");
				DataRow ThisVar;
				if ((UserVar==null)||(UserVar.Length==0)){
					ThisVar= DS2.userenvironment.NewRow();
					ThisVar["idcustomuser"]= User["idcustomuser"];
					ThisVar["variablename"]= CurrVar["variablename"];
					DS2.userenvironment.Rows.Add(ThisVar);
				}
				else {
					ThisVar= UserVar[0];
				}
				foreach (string fieldname in new string[]{"value","flagadmin","kind"}){
					ThisVar[fieldname]=CurrVar[fieldname];
				}
			}
			PostData PP = meta.Get_PostData();
			PP.InitClass(DS2, meta.Conn);
			PP.DO_POST();
		}

		

		
	}
}