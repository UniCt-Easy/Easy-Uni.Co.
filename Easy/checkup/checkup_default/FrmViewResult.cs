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
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using metadatalibrary;
using System.Data;

namespace checkup_default//diagnostica//
{
	/// <summary>
	/// Summary description for FrmViewResult.
	/// </summary>
	public class FrmViewResult : System.Windows.Forms.Form
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		string table;
		string listtype;
		string edittype;
		private System.Windows.Forms.DataGrid dgrid;
		MetaData Meta;
		private System.Windows.Forms.ContextMenu contextMenu1;
		private System.Windows.Forms.MenuItem menuItem1;
		DataTable T;

		public FrmViewResult(MetaData Meta,
				string cmd, string table, string listtype, string edittype)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			this.table=table;
			this.listtype=listtype.Trim();
			this.edittype= edittype;
			this.Meta=Meta;

			T = Meta.Conn.SQLRunner(cmd,false);
			if (T==null) return;

			DataSet DD = new DataSet("temp");

			ClearDataSet.RemoveConstraints(DD);
			DD.Tables.Add(T);
			//HelpForm.SetDataGrid(dgrid, T);
			dgrid.SetDataBinding(DD,T.TableName);

			formatgrids fg = new formatgrids(dgrid);
			fg.AutosizeColumnWidth();

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
			this.dgrid = new System.Windows.Forms.DataGrid();
			this.contextMenu1 = new System.Windows.Forms.ContextMenu();
			this.menuItem1 = new System.Windows.Forms.MenuItem();
			((System.ComponentModel.ISupportInitialize)(this.dgrid)).BeginInit();
			this.SuspendLayout();
			// 
			// dgrid
			// 
			this.dgrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.dgrid.ContextMenu = this.contextMenu1;
			this.dgrid.DataMember = "";
			this.dgrid.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dgrid.Location = new System.Drawing.Point(8, 8);
			this.dgrid.Name = "dgrid";
			this.dgrid.Size = new System.Drawing.Size(664, 424);
			this.dgrid.TabIndex = 0;
			this.dgrid.DoubleClick += new System.EventHandler(this.dgrid_DoubleClick);
			// 
			// contextMenu1
			// 
			this.contextMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																						 this.menuItem1});
			this.contextMenu1.Popup += new System.EventHandler(this.contextMenu1_Popup);
			// 
			// menuItem1
			// 
			this.menuItem1.Index = 0;
			this.menuItem1.Text = "Excel";
			this.menuItem1.Click += new System.EventHandler(this.menuItem1_Click);
			// 
			// FrmViewResult
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(680, 437);
			this.Controls.Add(this.dgrid);
			this.Name = "FrmViewResult";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "FrmViewResult";
			((System.ComponentModel.ISupportInitialize)(this.dgrid)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void dgrid_DoubleClick(object sender, System.EventArgs e) {
			DataRow Curr = CurrentSelectedRow();
			if (Curr==null) return;
			DataTable Dest = Meta.Conn.CreateTableByName(table,"*");
			string []cols  = new string[ Dest.PrimaryKey.Length];
			for(int i=0; i< Dest.PrimaryKey.Length; i++){
				cols[i]=Dest.PrimaryKey[i].ColumnName;
			}

			string filter;
			try {
				filter= QueryCreator.WHERE_COLNAME_CLAUSE(
					Curr,cols,DataRowVersion.Default,true);
			}
			catch {
				string collist= "";
				for (int i=0; i< cols.Length; i++){
					if (collist!="") collist+=",";
					collist+=cols[i];
				}
				MessageBox.Show("Nelle colonne selezionate non era presente la chiave primaria della "+
					"tabella "+Dest.TableName+".\r"+
					" Le colonne sono "+collist,"Errore");
				return;
			}

			MetaData DestM= Meta.Dispatcher.Get(table);
			if (listtype=="") listtype= DestM.DefaultListType;
			bool res= DestM.Edit(this, edittype.ToString(), false);
			DataRow RR = DestM.SelectOne(listtype, filter, null,null);
			if (RR!=null) DestM.SelectRow(RR,listtype);

		}
		public DataRow CurrentSelectedRow(){
			DataGrid GParent = dgrid;

			DataSet  DSV = (DataSet) GParent.DataSource;
			if (DSV==null) return null;
			DataTable TV=  DSV.Tables[GParent.DataMember];
			if (TV==null) return null;		
                
			if (TV.Rows.Count==0) return null;
			DataRowView DV = null;
			try {
				DV = (DataRowView) GParent.BindingContext[DSV, TV.TableName].Current;
			}
			catch {
				DV=null;
			}
			if (DV==null) return null;

			return DV.Row;


		}

		private void contextMenu1_Popup(object sender, System.EventArgs e) {
		
		}

		private void menuItem1_Click(object menusender, System.EventArgs e) {
			if (menusender==null) return;
			if (!(typeof(MenuItem).IsAssignableFrom(menusender.GetType())))return;
			object sender  = ((MenuItem) menusender).Parent.GetContextMenu().SourceControl;
			if (!(typeof(DataGrid).IsAssignableFrom(sender.GetType())))return;
			DataGrid G = (DataGrid) sender;
			object DDS = G.DataSource;
			if (DDS==null) return;
			if (!typeof(DataSet).IsAssignableFrom(DDS.GetType()))return;
			string DDT = G.DataMember;
			if (DDT==null) return;
			DataTable T = ((DataSet)DDS).Tables[DDT];
			if (T==null) return;
			exportclass.DataTableToExcel(T,true);

		}
	}
}
