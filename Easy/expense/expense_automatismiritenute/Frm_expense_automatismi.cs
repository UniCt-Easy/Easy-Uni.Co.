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
using System.Data;

namespace expense_automatismi//spesa_automatismi//
{
	/// <summary>
	/// Summary description for frmSpesaAutomatismi.
	/// </summary>
	public class Frm_expense_automatismi : System.Windows.Forms.Form
	{
		private Crownwood.Magic.Controls.TabControl tabControl1;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnOk;
		private Crownwood.Magic.Controls.TabPage tabEntrata;
		private Crownwood.Magic.Controls.TabPage tabSpesa;
		private Crownwood.Magic.Controls.TabPage tabVarSpesa;
		private System.Windows.Forms.DataGrid gridEntrata;
		private System.Windows.Forms.DataGrid gridSpesa;
		private System.Windows.Forms.DataGrid gridVarSpesa;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtEsercMovimento;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtNumMovimento;
		public /*Rana:spesa_automatismi.*/vistaForm DS;
		MetaData Meta;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Frm_expense_automatismi()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

		}

		public frmSpesaAutomatismi(
			MetaData Parent,
			string filterspesa,string filterentrata,string filtervarspesa) {

			InitializeComponent();
			this.Meta = Parent;
			string filteresercizio = "(esercizio='" + Meta.GetSys("esercizio") + "')";
			ClearDataSet.RemoveConstraints(DS);
			if (filterspesa!=null) 
			{
				filterspesa = GetData.MergeFilters("("+filterspesa+")",filteresercizio);
				DataAccess.RUN_SELECT_INTO_TABLE(Meta.Conn,DS.expenseview, null, filterspesa, null,true);
			}
			if (filterentrata!=null)
			{
				filterentrata = GetData.MergeFilters("("+filterentrata+")",filteresercizio);
				DataAccess.RUN_SELECT_INTO_TABLE(Meta.Conn,DS.incomeview, null, filterentrata, null,true);
			}
			if (filtervarspesa!=null)
			{
				DataAccess.RUN_SELECT_INTO_TABLE(Meta.Conn,DS.expensevarview, null, filtervarspesa, null,true);
			}

			MetaData MSpesaView = Meta.Dispatcher.Get("spesaview");
			MSpesaView.DescribeColumns(DS.expenseview,"autospesa");
			HelpForm.SetDataGrid(gridSpesa, DS.expenseview);			
			formatgrids FGSpesa= new formatgrids(gridSpesa);
			FGSpesa.AutosizeColumnWidth();

			MetaData MEntrataView = Meta.Dispatcher.Get("entrataview");
			MEntrataView.DescribeColumns(DS.incomeview,"autospesa");
			HelpForm.SetDataGrid(gridEntrata, DS.incomeview);			
			formatgrids FGEntrata= new formatgrids(gridEntrata);
			FGEntrata.AutosizeColumnWidth();

			MetaData MVarSpesaView = Meta.Dispatcher.Get("variazionespesaview");
			MVarSpesaView.DescribeColumns(DS.expensevarview,"autospesa");
			HelpForm.SetDataGrid(gridVarSpesa, DS.expensevarview);			
			formatgrids FGVarSpesa= new formatgrids(gridVarSpesa);
			FGVarSpesa.AutosizeColumnWidth();

			HideEmpties();

		}


		public void HideEmpties(){
			if (DS.expenseview.Rows.Count==0){
				tabControl1.TabPages.Remove(tabSpesa);
			}
			if (DS.incomeview.Rows.Count==0){
				tabControl1.TabPages.Remove(tabEntrata);
			}
			if (DS.expensevarview.Rows.Count==0){
				tabControl1.TabPages.Remove(tabVarSpesa);
			}

		}

		public void MetaData_AfterFill(){
			if (Meta.FirstFillForThisRow)	HideEmpties();
		}
		public void MetaData_AfterLink(){
			Meta= MetaData.GetMetaData(this);
			string filter= Meta.ExtraParameter.ToString();
			GetData.SetStaticFilter(DS.expenseview, filter);
			GetData.SetStaticFilter(DS.incomeview,filter);
			GetData.SetStaticFilter(DS.expensevarview,filter);
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
			this.tabControl1 = new Crownwood.Magic.Controls.TabControl();
			this.tabSpesa = new Crownwood.Magic.Controls.TabPage();
			this.gridSpesa = new System.Windows.Forms.DataGrid();
			this.tabEntrata = new Crownwood.Magic.Controls.TabPage();
			this.gridEntrata = new System.Windows.Forms.DataGrid();
			this.tabVarSpesa = new Crownwood.Magic.Controls.TabPage();
			this.gridVarSpesa = new System.Windows.Forms.DataGrid();
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnOk = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.txtEsercMovimento = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.txtNumMovimento = new System.Windows.Forms.TextBox();
			this.DS = new /*Rana:spesa_automatismi.*/vistaForm();
			this.tabControl1.SuspendLayout();
			this.tabSpesa.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.gridSpesa)).BeginInit();
			this.tabEntrata.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.gridEntrata)).BeginInit();
			this.tabVarSpesa.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.gridVarSpesa)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
			this.SuspendLayout();
			// 
			// tabControl1
			// 
			this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.tabControl1.IDEPixelArea = true;
			this.tabControl1.Location = new System.Drawing.Point(16, 48);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.SelectedTab = this.tabEntrata;
			this.tabControl1.Size = new System.Drawing.Size(616, 344);
			this.tabControl1.TabIndex = 0;
			this.tabControl1.TabPages.AddRange(new Crownwood.Magic.Controls.TabPage[] {
																						  this.tabEntrata,
																						  this.tabSpesa,
																						  this.tabVarSpesa});
			this.tabControl1.SelectionChanged += new System.EventHandler(this.tabControl1_SelectionChanged);
			// 
			// tabSpesa
			// 
			this.tabSpesa.Controls.Add(this.gridSpesa);
			this.tabSpesa.Location = new System.Drawing.Point(0, 0);
			this.tabSpesa.Name = "tabSpesa";
			this.tabSpesa.Selected = false;
			this.tabSpesa.Size = new System.Drawing.Size(616, 319);
			this.tabSpesa.TabIndex = 1;
			this.tabSpesa.Title = "Movimenti Spesa";
			// 
			// gridSpesa
			// 
			this.gridSpesa.AllowNavigation = false;
			this.gridSpesa.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.gridSpesa.DataMember = "";
			this.gridSpesa.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.gridSpesa.Location = new System.Drawing.Point(8, 8);
			this.gridSpesa.Name = "gridSpesa";
			this.gridSpesa.ReadOnly = true;
			this.gridSpesa.Size = new System.Drawing.Size(600, 304);
			this.gridSpesa.TabIndex = 1;
			this.gridSpesa.Tag = "expenseview.autospesa";
			this.gridSpesa.DoubleClick += new System.EventHandler(this.gridSpesa_DoubleClick);
			// 
			// tabEntrata
			// 
			this.tabEntrata.Controls.Add(this.gridEntrata);
			this.tabEntrata.Location = new System.Drawing.Point(0, 0);
			this.tabEntrata.Name = "tabEntrata";
			this.tabEntrata.Size = new System.Drawing.Size(616, 319);
			this.tabEntrata.TabIndex = 0;
			this.tabEntrata.Title = "Movimenti Entrata";
			// 
			// gridEntrata
			// 
			this.gridEntrata.AllowNavigation = false;
			this.gridEntrata.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.gridEntrata.DataMember = "";
			this.gridEntrata.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.gridEntrata.Location = new System.Drawing.Point(8, 8);
			this.gridEntrata.Name = "gridEntrata";
			this.gridEntrata.ReadOnly = true;
			this.gridEntrata.Size = new System.Drawing.Size(600, 304);
			this.gridEntrata.TabIndex = 0;
			this.gridEntrata.Tag = "incomeview.autospesa";
			this.gridEntrata.DoubleClick += new System.EventHandler(this.gridEntrata_DoubleClick);
			// 
			// tabVarSpesa
			// 
			this.tabVarSpesa.Controls.Add(this.gridVarSpesa);
			this.tabVarSpesa.Location = new System.Drawing.Point(0, 0);
			this.tabVarSpesa.Name = "tabVarSpesa";
			this.tabVarSpesa.Selected = false;
			this.tabVarSpesa.Size = new System.Drawing.Size(616, 319);
			this.tabVarSpesa.TabIndex = 2;
			this.tabVarSpesa.Title = "Variazioni Spesa";
			// 
			// gridVarSpesa
			// 
			this.gridVarSpesa.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.gridVarSpesa.DataMember = "";
			this.gridVarSpesa.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.gridVarSpesa.Location = new System.Drawing.Point(8, 8);
			this.gridVarSpesa.Name = "gridVarSpesa";
			this.gridVarSpesa.Size = new System.Drawing.Size(600, 304);
			this.gridVarSpesa.TabIndex = 1;
			this.gridVarSpesa.Tag = "expensevarview.autospesa";
			this.gridVarSpesa.DoubleClick += new System.EventHandler(this.gridVarSpesa_DoubleClick);
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(464, 408);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.TabIndex = 1;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.Visible = false;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// btnOk
			// 
			this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnOk.Location = new System.Drawing.Point(552, 408);
			this.btnOk.Name = "btnOk";
			this.btnOk.TabIndex = 2;
			this.btnOk.Tag = "mainsave";
			this.btnOk.Text = "Ok";
			this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(32, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(72, 16);
			this.label1.TabIndex = 3;
			this.label1.Text = "Esercizio";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtEsercMovimento
			// 
			this.txtEsercMovimento.Location = new System.Drawing.Point(104, 8);
			this.txtEsercMovimento.Name = "txtEsercMovimento";
			this.txtEsercMovimento.ReadOnly = true;
			this.txtEsercMovimento.Size = new System.Drawing.Size(96, 20);
			this.txtEsercMovimento.TabIndex = 4;
			this.txtEsercMovimento.Tag = "expense.ymov";
			this.txtEsercMovimento.Text = "";
			this.txtEsercMovimento.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(232, 8);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(56, 16);
			this.label2.TabIndex = 5;
			this.label2.Text = "Numero";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtNumMovimento
			// 
			this.txtNumMovimento.Location = new System.Drawing.Point(288, 8);
			this.txtNumMovimento.Name = "txtNumMovimento";
			this.txtNumMovimento.ReadOnly = true;
			this.txtNumMovimento.Size = new System.Drawing.Size(88, 20);
			this.txtNumMovimento.TabIndex = 6;
			this.txtNumMovimento.Tag = "expense.nmov";
			this.txtNumMovimento.Text = "";
			this.txtNumMovimento.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// DS
			// 
			this.DS.DataSetName = "vistaForm";
			this.DS.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// frmSpesaAutomatismi
			// 
			this.AcceptButton = this.btnOk;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(632, 437);
			this.Controls.Add(this.txtNumMovimento);
			this.Controls.Add(this.txtEsercMovimento);
			this.Controls.Add(this.tabControl1);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.btnOk);
			this.Controls.Add(this.btnCancel);
			this.Name = "frmSpesaAutomatismi";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Elenco Movimenti Automatici";
			this.tabControl1.ResumeLayout(false);
			this.tabSpesa.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.gridSpesa)).EndInit();
			this.tabEntrata.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.gridEntrata)).EndInit();
			this.tabVarSpesa.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.gridVarSpesa)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion


		private void gridEntrata_DoubleClick(object sender, System.EventArgs e) {
			DataTable T;
			DataRow R;
			bool res = GetCurrentRow(DS,gridEntrata, out T, out R);
			if (!res) return;
			if (R==null) return;
			MetaData newEntrata = Meta.Dispatcher.Get("entrata");
			newEntrata.Edit(this.ParentForm, "gerarchico", false);
			string identrata = R["idinc"].ToString();
			DataRow R2 = newEntrata.SelectOne(newEntrata.DefaultListType,
					"(esercizio='"+Meta.Conn.sys["esercizio"].ToString()+"')AND"+
					"(identrata="+QueryCreator.quotedstrvalue(identrata,true)
							+")","entrata",null);
			if (R2!=null) newEntrata.SelectRow(R2, newEntrata.DefaultListType);
					
		}

		private void gridVarSpesa_DoubleClick(object sender, System.EventArgs e) {
			DataTable T;
			DataRow R;
			bool res = GetCurrentRow(DS,gridVarSpesa, out T, out R);
			if (!res) return;
			if (R==null) return;
			MetaData newSpesa = Meta.Dispatcher.Get( "spesa");
			newSpesa.Edit(this.ParentForm, "gerarchico", false);
			string idspesa = R["idexp"].ToString();
			DataRow R2 = newSpesa.SelectOne(newSpesa.DefaultListType,
				"(esercizio='"+Meta.Conn.sys["esercizio"].ToString()+"')AND"+
				"(idspesa="+QueryCreator.quotedstrvalue(idspesa,true)
				+")","spesa",null);
			if (R2!=null) newSpesa.SelectRow(R2, newSpesa.DefaultListType);
		}

		private void gridSpesa_DoubleClick(object sender, System.EventArgs e) {
			DataTable T;
			DataRow R;
			bool res = GetCurrentRow(DS,gridSpesa, out T, out R);
			if (!res) return;
			if (R==null) return;
			MetaData newSpesa = Meta.Dispatcher.Get( "spesa");
			newSpesa.Edit(this.ParentForm, "gerarchico", false);
			string idspesa = R["idexp"].ToString();
			DataRow R2 = newSpesa.SelectOne(newSpesa.DefaultListType,
				"(esercizio='"+Meta.Conn.sys["esercizio"].ToString()+"')AND"+
				"(idspesa="+QueryCreator.quotedstrvalue(idspesa,true)
				+")","spesa",null);
			if (R2!=null) newSpesa.SelectRow(R2, newSpesa.DefaultListType);

		}


		/// <summary>
		/// Takes from a table T a row having same key as R
		/// </summary>
		/// <param name="T"></param>
		/// <param name="R">Row to search</param>
		/// <returns>Row found in T with same key of given Row</returns>
		public static DataRow FindExternalRow (DataTable T, DataRow R){
			string condition = QueryCreator.WHERE_REL_CLAUSE(R, T.PrimaryKey, T.PrimaryKey, 
				DataRowVersion.Default,false);
			DataRow [] Found = T.Select(condition);
			if (Found.Length==0) return null;
			return Found[0];
		}

		/// <summary>
		/// Gets current row from ComboBox, Grids and tree-views, return false on errors
		/// </summary>
		/// <param name="C">Control to analyze</param>
		/// <param name="T">Table containing rows</param>
		/// <param name="R">Current selected row (null if none)</param>
		/// <returns>false on errors</returns>
		public static bool GetCurrentRow(DataSet DS, Control C, out DataTable T, out DataRow R){
			R=null; //in case of errors, always return a value
			T=null;
			if (typeof(ComboBox).IsAssignableFrom(C.GetType())){
				ComboBox CParent = (ComboBox)C;
				if (CParent.DataSource==null) return false;
				T= DS.Tables[((DataTable) (CParent.DataSource)).TableName];

				if (CParent.SelectedIndex<=0) { //index 0 is used for blank row
					R=null;
					return true;
				}
				DataRowView RV = ((DataRowView)((ComboBox)C).Items[CParent.SelectedIndex]);
				if (RV==null) return true;
				R= RV.Row;
				if (R.Table==T)return true;
				R = FindExternalRow(T,R);
				return true;
			}

			//T is taken from DS, using TAG Table
			//Row is taken from T, using a filter using current grid row
			if (typeof(DataGrid).IsAssignableFrom(C.GetType())){
				if (C.Tag==null) return false;
				string tablename = HelpForm.GetField(C.Tag.ToString(),0);
				if (tablename==null) return false;
				T = DS.Tables[tablename];

				DataGrid GParent = (DataGrid) C;

				DataSet  DSV = (DataSet) GParent.DataSource;
				if (DSV==null) return false;
				DataTable TV=  DSV.Tables[GParent.DataMember];
				if (TV==null) return false;		
                
				if (TV.Rows.Count==0) return true;
				DataRowView DV = null;
				try {
					DV = (DataRowView) GParent.BindingContext[DSV, TV.TableName].Current;
				}
				catch {
					DV=null;
				}
				if (DV==null) return true;

				R = DV.Row;
				if (TV.Equals(T)) return true;

				R = FindExternalRow(T, R);
				return true;
			}

			if (typeof(TreeView).IsAssignableFrom(C.GetType())){
				TreeView  TParent= (TreeView) C;
				string tablename = HelpForm.GetField(TParent.Tag.ToString(),0);
				if (tablename==null) return false;
				T = DS.Tables[tablename];
				
				TreeNode  N = (TreeNode) TParent.SelectedNode;
				try {
					tree_node treenode = (tree_node)(N.Tag);
					T = treenode.Row.Table;
					R = treenode.Row;
					return true;
				}
				catch {
					return true;
				}
			}
			return false;

		}



		private void btnCancel_Click(object sender, System.EventArgs e) {
			if (!Modal) Close();
		}

		private void btnOk_Click(object sender, System.EventArgs e) {
			if (!Modal) Close();
		}

		private void tabControl1_SelectionChanged(object sender, System.EventArgs e) {

		}




	}
}
