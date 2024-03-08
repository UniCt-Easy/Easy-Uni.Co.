
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
using System.Data;
using System.Windows.Forms;
using metaeasylibrary;
using metadatalibrary;

namespace meta_accountprevisionview {
	/// <summary>
	/// Summary description for Meta_accountprevisionview.
	/// </summary>
	public class Meta_accountprevisionview : Meta_easydata {
		public Meta_accountprevisionview(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "accountprevisionview") {		
			Name="Piano dei conti";
			EditTypes.Add("prevision");
            EditTypes.Add("relation");
			ListingTypes.Add("tree");
            ListingTypes.Add("prevision");
		}

		protected override Form GetForm(string FormName){
			switch(FormName) {
				case "prevision":{
					Name="Budget Economico Patrimoniale";
					CanInsertCopy=false;
					ActAsList();
					IsTree = true;
					DefaultListType="tree";
					return MetaData.GetFormByDllName("accountprevisionview_prevision");
				}
                case "relation": {
                Name = "Conto suddiviso sull'U.P.B.";
                ActAsList();
                IsTree = true;
                DefaultListType = FormName;
                return GetFormByDllName("accountprevisionview_prevision");
            }

			}
			return null;
		}

		public override DataRow SelectByCondition(string filter, string searchtable){
			int ResultCount = Conn.RUN_SELECT_COUNT("accountusable", filter, true);
			if (ResultCount!=1) return null;		
			DataTable T2 = Conn.RUN_SELECT("account",null,null,filter,null,true);
			if (T2==null) return null;
			if (T2.Rows.Count==0) return null;
			return CheckSelectRow(T2.Rows[0]);

		}

		public override void DescribeColumns(DataTable T, string ListingType) {
			base.DescribeColumns(T, ListingType);
			if (ListingType=="tree"){
				foreach (DataColumn C in T.Columns) {
					DescribeAColumn(T, C.ColumnName, "",-1);
				}
				DescribeAColumn(T,"codeacc","Codice",1);
				DescribeAColumn(T,"account","Denominazione",2);
			}
            if (ListingType == "prevision") {
                foreach (DataColumn C in T.Columns) {
                    DescribeAColumn(T, C.ColumnName, "", -1);
                }
                int npos = 1;
                DescribeAColumn(T, "codeacc", "Codice Conto", npos++);
                DescribeAColumn(T, "account", "Conto", npos++);
                int neserc = Convert.ToInt32(GetSys("esercizio"));
                DescribeAColumn(T, "prevision", neserc.ToString(), npos++);
                DescribeAColumn(T, "prevision2", (++neserc).ToString(), npos++);
                DescribeAColumn(T, "prevision3", (++neserc).ToString(), npos++);
                DescribeAColumn(T, "prevision4", (++neserc).ToString(), npos++);
                DescribeAColumn(T, "prevision5", (++neserc).ToString(), npos++);

            }

		}

		public override void DescribeTree(TreeView tree, DataTable T, string ListingType){
			//Aggiorno le intestazioni del DataGrid
			if (ListingType=="tree"){
				base.DescribeColumns(T, ListingType);
				foreach (DataColumn C in T.Columns)
					DescribeAColumn(T, C.ColumnName, "",-1);
				DescribeAColumn(T,"codeacc", "Codice",1);
				DescribeAColumn(T,"account","Denominazione",2);
			}

			base.DescribeTree(tree, T, ListingType);
            string filterc = QHC.CmpEq("nlevel", "1");
            string filtersql = QHS.CmpEq("nlevel", "1");

			int maxlevel = 0;
			string filterEsercizio = QHS.CmpEq("ayear",GetSys("esercizio"));
			object o = Conn.DO_READ_VALUE("accountlevel", filterEsercizio, "max(nlevel)");
			if ((o != null) && (o != DBNull.Value)) maxlevel = Convert.ToInt32(o);
			TreeViewManager M = new TreeViewAccountPrevisionView(Conn, T, tree, filterc, filtersql, maxlevel);
			myGetData.SetStaticFilter("accountlevel", filterEsercizio);  
		}

		public override bool IsValid (DataRow R, out string errmess, out string errfield){
			if (!base.IsValid(R, out errmess, out errfield))
				return false;
			if (R.RowState!=DataRowState.Added) return true;
			return true;
		}
	}
	
	public class TreeViewAccountPrevisionView : TreeViewManager {
		int maxlevel = 0;
		public TreeViewAccountPrevisionView(DataAccess Conn, DataTable T, TreeView tree, 
                        string filterc, string filtersql, int maxlevel):               
			base(T,tree, 
			new accountprevisionview_node_dispatcher(
			"accountlevel",
			"nlevel",
			"description",
			"flagusable",
			"account",
			"codeacc",maxlevel,Conn)
			,filterc,filtersql) {
			this.maxlevel = maxlevel;
			base.DoubleClickForSelect=false;
		}

		override public TreeNode AddNode(TreeNodeCollection Nodes, TreeNode NewNode){
			if (Nodes.Equals(tree.Nodes) && (NewNode.Tag!=null)){
				//searches the right node into which do the additon
				//DataRow R = ((tree_node) NewNode.Tag).Row;
				foreach(TreeNode N in Nodes) {
					if (N.Text == "E/P") {
						return base.AddNode(N.Nodes, NewNode);
					}
				}
			}
			return base.AddNode(Nodes,NewNode);
		}

		public override void FillNodes(){
			base.FillNodes();
			AutoEventsEnabled=false;

			if (tree.Nodes.Count>0){
				if (tree.Nodes[0].Tag==null) return;
			}

			TreeNode newroot= new TreeNode("E/P");

			while (tree.Nodes.Count>0){
				TreeNode X = tree.Nodes[0];
				tree.Nodes.RemoveAt(0);
				if (X.Tag==null) continue;
				newroot.Nodes.Add(X);
			}
			tree.Nodes.Add(newroot);
			newroot.Expand();
			AutoEventsEnabled=true;
		}		
	}

	public class accountprevisionview_tree_node: easy_tree_node {
		DataAccess Conn;
		int maxlevel;
		public accountprevisionview_tree_node(string level_table, 
			string level_field,
			string descr_level_field,
			string selectable_level_field,
			string descr_field,
			string code_string,
			DataRow R,
			int maxlevel,
			DataAccess Conn
			):base(level_table,
			descr_level_field,
			descr_level_field,
			selectable_level_field,
			descr_field,
			code_string,
			R){
			this.maxlevel=maxlevel;
			this.Conn = Conn;
		}

		bool row_exists(){
			if (Row==null) return false;
			if (Row.RowState== DataRowState.Deleted) return false;
			if (Row.RowState== DataRowState.Detached) return false;
			return true;
		}

		/// <summary>
		/// True if "selectable" and with "no chidren" or maxlevel==current level
		/// </summary>
		/// <returns></returns>
		override public bool CanSelect(){
			if (!row_exists()) return false;
			DataRow Lev = LevelRow();
			if (maxlevel>0){ 
				if (Lev["nlevel"].ToString()==maxlevel.ToString()) return true;
			}
			if (Lev["flagusable"].ToString().ToLower()=="n") return false;
			if (HasAutoChildren()) return false;
            QueryHelper QHS = Conn.GetQueryHelper();
			string filter = QHS.Like("idacc", Row["idacc"] + "%");
			int ResultCount = Conn.RUN_SELECT_COUNT("accountusable", filter, true);
			if (ResultCount!=1) return false;
			return true;           
		}
	}

	public class accountprevisionview_node_dispatcher : easy_node_dispatcher{
		DataAccess Conn;
		int maxlevel;
		public accountprevisionview_node_dispatcher(
			string level_table, 
			string level_field,
			string descr_level_field,
			string selectable_level_field,
			string descr_field,
			string code_string,
			int maxlevel,
			DataAccess Conn
			):base(level_table,
			level_field,
			descr_level_field, 
			selectable_level_field, 
			descr_field,code_string) {
			this.maxlevel= maxlevel;
			this.Conn = Conn;
		}		

		override public tree_node GetNode(DataRow Parent, DataRow Child){
			return new accountprevisionview_tree_node("accountlevel", "nlevel",
				"description", "flagusable",
				"account", "codeacc", Child,maxlevel, Conn);
		}
	}
}
