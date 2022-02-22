
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
using System.Data;

namespace expense_automatismi//spesa_automatismi//
{
	/// <summary>
	/// Summary description for frmSpesaAutomatismi.
	/// </summary>
	public class Frm_expense_automatismi : MetaDataForm
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
		public vistaForm DS;
		MetaData Meta;
		private Crownwood.Magic.Controls.TabPage tabVarEntrata;
		private System.Windows.Forms.DataGrid gridVarEntrata;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
        ContextMenu ExcelMenu;

        QueryHelper QHS;
        CQueryHelper QHC;
		public Frm_expense_automatismi()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
            ExcelMenu = new ContextMenu();
            ExcelMenu.MenuItems.Add("Excel", new EventHandler(Excel_Click));

        }

        private void Excel_Click(object menusender, EventArgs e) {
            if (menusender == null) return;
            if (!(typeof(MenuItem).IsAssignableFrom(menusender.GetType()))) return;
            object sender = ((MenuItem)menusender).Parent.GetContextMenu().SourceControl;
            if (!(typeof(DataGrid).IsAssignableFrom(sender.GetType()))) return;
            DataGrid G = (DataGrid)sender;
            object DDS = G.DataSource;
            if (DDS == null) return;
            if (!typeof(DataSet).IsAssignableFrom(DDS.GetType())) return;
            string DDT = G.DataMember;
            if (DDT == null) return;
            DataTable T = ((DataSet)DDS).Tables[DDT];
            if (T == null) return;
            exportclass.DataTableToExcel(T, true);
        }

        public Frm_expense_automatismi(
			MetaData Parent,
			string filterspesa,string filterentrata,string filtervarspesa,string filtervarentrata) {

			InitializeComponent();
			this.Meta = Parent;
            MetaData.SetColor(this);

            ExcelMenu = new ContextMenu();
            ExcelMenu.MenuItems.Add("Excel", new EventHandler(Excel_Click));

            QHS = Meta.Conn.GetQueryHelper();
            QHC = new CQueryHelper();
			string filteresercizio = QHS.CmpEq("ayear",Meta.GetSys("esercizio"));
			ClearDataSet.RemoveConstraints(DS);
			if (filterspesa!=null) 
			{
				filterspesa = QHS.AppAnd("("+filterspesa+")",filteresercizio);
                DataAccess.RUN_SELECT_INTO_TABLE(Meta.Conn, DS.expenseview, "autokind asc, autocode asc, amount asc, idfin asc, nphase asc", filterspesa, null, true);
			}
			if (filterentrata!=null)
			{
				filterentrata = QHS.AppAnd("("+filterentrata+")",filteresercizio);
                DataAccess.RUN_SELECT_INTO_TABLE(Meta.Conn, DS.incomeview, "autokind asc, autocode asc, amount asc,idfin asc, nphase asc", filterentrata, null, true);
			}
			if (filtervarspesa!=null)
			{
                DataAccess.RUN_SELECT_INTO_TABLE(Meta.Conn, DS.expensevarview, "nvar asc", filtervarspesa, null, true);
			}

			if (filtervarentrata!=null) {
                DataAccess.RUN_SELECT_INTO_TABLE(Meta.Conn, DS.incomevarview, "nvar asc", filtervarentrata, null, true);
			}		

			MetaData MSpesaView = Meta.Dispatcher.Get("expenseview");
			MSpesaView.DescribeColumns(DS.expenseview,"autospesa");
			HelpForm.SetDataGrid(gridSpesa, DS.expenseview);
            gridSpesa.ContextMenu = ExcelMenu;
            formatgrids FGSpesa= new formatgrids(gridSpesa);
			FGSpesa.AutosizeColumnWidth();

			MetaData MEntrataView = Meta.Dispatcher.Get("incomeview");
			MEntrataView.DescribeColumns(DS.incomeview,"autospesa");
			HelpForm.SetDataGrid(gridEntrata, DS.incomeview);
            gridEntrata.ContextMenu = ExcelMenu;
            formatgrids FGEntrata= new formatgrids(gridEntrata);
			FGEntrata.AutosizeColumnWidth();

			MetaData MVarSpesaView = Meta.Dispatcher.Get("expensevarview");
			MVarSpesaView.DescribeColumns(DS.expensevarview,"autospesa");
			HelpForm.SetDataGrid(gridVarSpesa, DS.expensevarview);
            gridVarSpesa.ContextMenu = ExcelMenu;
            formatgrids FGVarSpesa= new formatgrids(gridVarSpesa);
			FGVarSpesa.AutosizeColumnWidth();

			MetaData MVarEntrataView = Meta.Dispatcher.Get("incomevarview");
			MVarEntrataView.DescribeColumns(DS.incomevarview,"autoentrata");
			HelpForm.SetDataGrid(gridVarEntrata, DS.incomevarview);
            gridVarEntrata.ContextMenu = ExcelMenu;
            formatgrids FGVarEntrata= new formatgrids(gridVarEntrata);
			FGVarEntrata.AutosizeColumnWidth();

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
			if (DS.incomevarview.Rows.Count==0){
				tabControl1.TabPages.Remove(tabVarEntrata);
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

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.tabControl1 = new Crownwood.Magic.Controls.TabControl();
			this.tabVarEntrata = new Crownwood.Magic.Controls.TabPage();
			this.gridVarEntrata = new System.Windows.Forms.DataGrid();
			this.tabEntrata = new Crownwood.Magic.Controls.TabPage();
			this.gridEntrata = new System.Windows.Forms.DataGrid();
			this.tabSpesa = new Crownwood.Magic.Controls.TabPage();
			this.gridSpesa = new System.Windows.Forms.DataGrid();
			this.tabVarSpesa = new Crownwood.Magic.Controls.TabPage();
			this.gridVarSpesa = new System.Windows.Forms.DataGrid();
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnOk = new System.Windows.Forms.Button();
			this.DS = new expense_automatismi.vistaForm();
			this.tabControl1.SuspendLayout();
			this.tabVarEntrata.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.gridVarEntrata)).BeginInit();
			this.tabEntrata.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.gridEntrata)).BeginInit();
			this.tabSpesa.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.gridSpesa)).BeginInit();
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
			this.tabControl1.Location = new System.Drawing.Point(8, 8);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.SelectedTab = this.tabEntrata;
			this.tabControl1.Size = new System.Drawing.Size(624, 384);
			this.tabControl1.TabIndex = 0;
			this.tabControl1.TabPages.AddRange(new Crownwood.Magic.Controls.TabPage[] {
																						  this.tabEntrata,
																						  this.tabSpesa,
																						  this.tabVarSpesa,
																						  this.tabVarEntrata});
			this.tabControl1.SelectionChanged += new System.EventHandler(this.tabControl1_SelectionChanged);
			// 
			// tabVarEntrata
			// 
			this.tabVarEntrata.Controls.Add(this.gridVarEntrata);
			this.tabVarEntrata.Location = new System.Drawing.Point(0, 0);
			this.tabVarEntrata.Name = "tabVarEntrata";
			this.tabVarEntrata.Selected = false;
			this.tabVarEntrata.Size = new System.Drawing.Size(624, 359);
			this.tabVarEntrata.TabIndex = 3;
			this.tabVarEntrata.Title = "Variazioni Entrata";
			// 
			// gridVarEntrata
			// 
			this.gridVarEntrata.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.gridVarEntrata.DataMember = "";
			this.gridVarEntrata.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.gridVarEntrata.Location = new System.Drawing.Point(8, 7);
			this.gridVarEntrata.Name = "gridVarEntrata";
			this.gridVarEntrata.Size = new System.Drawing.Size(608, 344);
			this.gridVarEntrata.TabIndex = 2;
			this.gridVarEntrata.Tag = "incomevarview.autospesa";
			this.gridVarEntrata.DoubleClick += new System.EventHandler(this.gridVarEntrata_DoubleClick);
			// 
			// tabEntrata
			// 
			this.tabEntrata.Controls.Add(this.gridEntrata);
			this.tabEntrata.Location = new System.Drawing.Point(0, 0);
			this.tabEntrata.Name = "tabEntrata";
			this.tabEntrata.Size = new System.Drawing.Size(624, 359);
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
			this.gridEntrata.Size = new System.Drawing.Size(600, 344);
			this.gridEntrata.TabIndex = 0;
			this.gridEntrata.Tag = "incomeview.autospesa";
			this.gridEntrata.DoubleClick += new System.EventHandler(this.gridEntrata_DoubleClick);
			// 
			// tabSpesa
			// 
			this.tabSpesa.Controls.Add(this.gridSpesa);
			this.tabSpesa.Location = new System.Drawing.Point(0, 0);
			this.tabSpesa.Name = "tabSpesa";
			this.tabSpesa.Selected = false;
			this.tabSpesa.Size = new System.Drawing.Size(624, 359);
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
			this.gridSpesa.Size = new System.Drawing.Size(608, 344);
			this.gridSpesa.TabIndex = 1;
			this.gridSpesa.Tag = "expenseview.autospesa";
			this.gridSpesa.DoubleClick += new System.EventHandler(this.gridSpesa_DoubleClick);
			// 
			// tabVarSpesa
			// 
			this.tabVarSpesa.Controls.Add(this.gridVarSpesa);
			this.tabVarSpesa.Location = new System.Drawing.Point(0, 0);
			this.tabVarSpesa.Name = "tabVarSpesa";
			this.tabVarSpesa.Selected = false;
			this.tabVarSpesa.Size = new System.Drawing.Size(624, 359);
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
			this.gridVarSpesa.Size = new System.Drawing.Size(608, 344);
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
			// DS
			// 
			this.DS.DataSetName = "vistaForm";
			this.DS.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// Frm_expense_automatismi
			// 
			this.AcceptButton = this.btnOk;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(632, 437);
			this.Controls.Add(this.tabControl1);
			this.Controls.Add(this.btnOk);
			this.Controls.Add(this.btnCancel);
			this.Name = "Frm_expense_automatismi";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Elenco Movimenti Automatici";
			this.tabControl1.ResumeLayout(false);
			this.tabVarEntrata.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.gridVarEntrata)).EndInit();
			this.tabEntrata.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.gridEntrata)).EndInit();
			this.tabSpesa.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.gridSpesa)).EndInit();
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
			MetaData newEntrata = Meta.Dispatcher.Get("income");
			newEntrata.Edit(this.ParentForm, "gerarchico", false);
			object identrata = R["idinc"];
			DataRow R2 = newEntrata.SelectOne(newEntrata.DefaultListType,
                QHS.AppAnd( QHS.CmpEq("ayear",Meta.GetSys("esercizio")),
                           QHS.CmpEq("idinc",identrata)),
                           "income",null);
			if (R2!=null) newEntrata.SelectRow(R2, newEntrata.DefaultListType);
					
		}
		private void gridVarEntrata_DoubleClick(object sender, System.EventArgs e) {
			DataTable T;
			DataRow R;
			bool res = GetCurrentRow(DS,gridVarEntrata, out T, out R);
			if (!res) return;
			if (R==null) return;
			MetaData newEntrata = Meta.Dispatcher.Get( "income");
			newEntrata.Edit(this.ParentForm, "gerarchico", false);
            object identrata = R["idinc"];
            DataRow R2 = newEntrata.SelectOne(newEntrata.DefaultListType,
                QHS.AppAnd(QHS.CmpEq("ayear", Meta.GetSys("esercizio")),
                           QHS.CmpEq("idinc", identrata)),
                           "income", null);
			if (R2!=null) newEntrata.SelectRow(R2, newEntrata.DefaultListType);
		
		}

		private void gridVarSpesa_DoubleClick(object sender, System.EventArgs e) {
			DataTable T;
			DataRow R;
			bool res = GetCurrentRow(DS,gridVarSpesa, out T, out R);
			if (!res) return;
			if (R==null) return;
			MetaData newSpesa = Meta.Dispatcher.Get( "expense");
			newSpesa.Edit(this.ParentForm, "gerarchico", false);
			object idspesa = R["idexp"];
			DataRow R2 = newSpesa.SelectOne(newSpesa.DefaultListType,
                QHS.AppAnd(QHS.CmpEq("ayear", Meta.GetSys("esercizio")),
                           QHS.CmpEq("idexp", idspesa)), 
                           "expense", null);
			if (R2!=null) newSpesa.SelectRow(R2, newSpesa.DefaultListType);
		}

		private void gridSpesa_DoubleClick(object sender, System.EventArgs e) {
			DataTable T;
			DataRow R;
			bool res = GetCurrentRow(DS,gridSpesa, out T, out R);
			if (!res) return;
			if (R==null) return;
			MetaData newSpesa = Meta.Dispatcher.Get( "expense");
			newSpesa.Edit(this.ParentForm, "gerarchico", false);
            object idspesa = R["idexp"];
            DataRow R2 = newSpesa.SelectOne(newSpesa.DefaultListType,
				QHS.AppAnd(QHS.CmpEq("ayear", Meta.GetSys("esercizio")),
                           QHS.CmpEq("idexp", idspesa)),
                         "expense",null);
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
