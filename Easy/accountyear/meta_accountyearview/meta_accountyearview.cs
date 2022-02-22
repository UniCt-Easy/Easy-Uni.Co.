
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
using System.Data;
using System.Windows.Forms;
using metaeasylibrary;
using metadatalibrary;

namespace meta_accountyearview {
	/// <summary>
	/// Summary description for Meta_accountyearview.
	/// </summary>
	public class Meta_accountyearview : Meta_easydata {
		public Meta_accountyearview(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "accountyearview") {	
			EditTypes.Add("default");
            EditTypes.Add("previsionaccount");
            EditTypes.Add("previsionupb");
            ListingTypes.Add("tree");
            ListingTypes.Add("previsionaccount");
            ListingTypes.Add("previsionupb");
        }
        string[] mykey = new string[] { "idacc", "idupb" };
        public override string[] primaryKey() {
            return mykey;
        }
        protected override Form GetForm(string EditType) {
			switch(EditType) {
				case "default": {
					Name = "Budget sul conto suddiviso per U.P.B.";
					DefaultListType = "default";
					ActAsList();
					IsTree=true;
					return GetFormByDllName("accountyearview_default");
				}
                case "previsionaccount": {
                        Name = "Budget dell' U.P.B.";
                        DefaultListType = "default";
                        return GetFormByDllName("accountyearview_previsionaccount");
                    }
                case "previsionupb": {
                        Name = "Budget sul conto";
                        DefaultListType = "default";
                        return GetFormByDllName("accountyearview_previsionupb");
                    }
            }
			return null;
		}

		public override void SetDefaults(DataTable PrimaryTable) {
			base.SetDefaults (PrimaryTable);
			SetDefault(PrimaryTable,"ayear",Conn.GetSys("esercizio"));
		}

		override public DataRow Get_New_Row(DataRow ParentRow, DataTable T){
			if (edit_type == "default") {
				if (ParentRow!=null){
					SetDefault(T,"idacc",ParentRow["idacc"]);
					SetDefault(T,"paridacc",ParentRow["paridacc"]);
					SetDefault(T,"codeacc",ParentRow["codeacc"]);
					SetDefault(T,"account",ParentRow["account"]);
					SetDefault(T,"nlevel",ParentRow["nlevel"]);
					SetDefault(T,"leveldescr",ParentRow["leveldescr"]);
				}
			}
            if (edit_type == "previsionaccount") {
                if (ParentRow != null) {
                    SetDefault(T, "idupb", ParentRow["idupb"]);
                    SetDefault(T, "paridupb", ParentRow["paridupb"]);
                    SetDefault(T, "codeupb", ParentRow["codeupb"]);
                    SetDefault(T, "upb", ParentRow["title"]);
                }
            }
            if (edit_type == "previsionupb") {
                if (ParentRow != null) {
                    SetDefault(T, "idacc", ParentRow["idacc"]);
                    SetDefault(T, "paridacc", ParentRow["paridacc"]);
                    SetDefault(T, "codeacc", ParentRow["codeacc"]);
                    SetDefault(T, "account", ParentRow["title"]);
                    SetDefault(T, "nlevel", ParentRow["nlevel"]);
                    string filterfinlevel = QHS.AppAnd(QHS.CmpEq("ayear", Conn.GetSys("esercizio")), QHS.CmpEq("nlevel", ParentRow["nlevel"]));
                    object leveldescr = Conn.DO_READ_VALUE("accountlevel", filterfinlevel, "description");
                    SetDefault(T, "leveldescr", leveldescr);
                }
            }
			DataRow R = base.Get_New_Row(ParentRow, T);
			return R;
		}

		public override void DescribeColumns(DataTable T, string ListingType) {
			base.DescribeColumns(T, ListingType);
			if (ListingType=="default"){				//		+
				foreach (DataColumn C in T.Columns)
					DescribeAColumn(T, C.ColumnName, "",-1);
				DescribeAColumn(T,"ayear",".Esercizio",-1);
				DescribeAColumn(T,"codeacc", "Codice",1);
				DescribeAColumn(T, "account","Conto",2);
				DescribeAColumn(T,"codeupb","UPB",3);
                int esercizio = Convert.ToInt32(GetSys("esercizio"));
                DescribeAColumn(T, "prevision", esercizio.ToString(), 4);
                DescribeAColumn(T, "prevision2", (++esercizio).ToString(), 5);
                DescribeAColumn(T, "prevision3", (++esercizio).ToString(), 6);
                DescribeAColumn(T, "prevision4", (++esercizio).ToString(), 7);
                DescribeAColumn(T, "prevision5", (++esercizio).ToString(), 8);
            }

            if (ListingType == "previsionaccount") {
                foreach (DataColumn C in T.Columns)
                    DescribeAColumn(T, C.ColumnName, "", -1);
                DescribeAColumn(T, "ayear", ".Esercizio", -1);
                DescribeAColumn(T, "codeacc", "Codice", 2);
                int esercizio = Convert.ToInt32(GetSys("esercizio"));
                DescribeAColumn(T, "prevision", esercizio.ToString(), 3);
                DescribeAColumn(T, "prevision2", (++esercizio).ToString(), 4);
                DescribeAColumn(T, "prevision3", (++esercizio).ToString(), 5);
                DescribeAColumn(T, "prevision4", (++esercizio).ToString(), 6);
                DescribeAColumn(T, "prevision5", (++esercizio).ToString(), 7);

            }
            if (ListingType == "previsionupb") {
                foreach (DataColumn C in T.Columns)
                    DescribeAColumn(T, C.ColumnName, "", -1);
                DescribeAColumn(T, "ayear", ".Esercizio", -1);
                DescribeAColumn(T, "codeupb", "UPB", 2);
                int esercizio = Convert.ToInt32(GetSys("esercizio"));
                DescribeAColumn(T, "prevision", esercizio.ToString(), 3);
                DescribeAColumn(T, "prevision2", (++esercizio).ToString(), 4);
                DescribeAColumn(T, "prevision3", (++esercizio).ToString(), 5);
                DescribeAColumn(T, "prevision4", (++esercizio).ToString(), 6);
                DescribeAColumn(T, "prevision5", (++esercizio).ToString(), 7);

            }
		}

		public override void DescribeTree(TreeView tree, DataTable T, string ListingType){
			// Listing Type chiamato dal form di gestione di ACCOUNTYEAR (fissato l'IDACC)
			if (ListingType == "tree") {
				string idAcc = T.ExtendedProperties["idacc"].ToString();
				base.DescribeTree(tree, T, ListingType);
                string filterc = QHC.AppAnd(QHC.CmpEq("idacc", idAcc), QHC.IsNull("paridupb"));
                string filtersql = QHS.AppAnd(QHS.CmpEq("idacc", idAcc), QHS.IsNull("paridupb"));
                string filteresercizio = QHS.CmpEq("ayear", GetSys("esercizio"));
                TreeViewManager M = new TreeViewAccountYear(Conn, T, tree, filterc,filtersql, null, 10);
				myGetData.SetStaticFilter("accountlevel",filteresercizio);  
			}
		}
	}

	public class TreeViewAccountYear : TreeViewManager {
		int maxlevel = 0;
		public TreeViewAccountYear(DataAccess Conn, DataTable T, TreeView tree, string filterc, string filtersql, string kind, int maxlevel):               
			base(T,tree, new accountyearview_node_dispatcher(
            "accountlevel",
			"nlevel",
			"description",
			"flagusable",
			"upb",
			"codeupb",maxlevel,Conn)
			,filterc,filtersql) {
			this.maxlevel = maxlevel;
			base.DoubleClickForSelect=false;
		}

		override public TreeNode AddNode(TreeNodeCollection Nodes, TreeNode NewNode){
			if (Nodes.Equals(tree.Nodes) && (NewNode.Tag!=null)){
				if (Nodes.Count==0)return base.AddNode(Nodes,NewNode); //should not happen!
				TreeNode N = Nodes[0];
				return base.AddNode(N.Nodes, NewNode);
			}
			return base.AddNode(Nodes,NewNode);
		}

		public override void FillNodes(){
			base.FillNodes();
			AutoEventsEnabled=false;
			TreeNode newroot= new TreeNode("-");
			if (tree.Nodes.Count>0){
				if (tree.Nodes[0].Tag==null) return;
			}

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

	public class accountyearview_tree_node: easy_tree_node {
		DataAccess Conn;
		int maxlevel;
		public accountyearview_tree_node(string level_table, 
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
			string filter = "(idacc LIKE '" + Row["idacc"] + "%')";
			int ResultCount = Conn.RUN_SELECT_COUNT("accountusable", filter, true);
			if (ResultCount!=1) return false;
			return true;           
		}
	}

	public class accountyearview_node_dispatcher : easy_node_dispatcher{
		DataAccess Conn;
		int maxlevel;
		public accountyearview_node_dispatcher(
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
			return new accountyearview_tree_node("accountlevel", "nlevel",
				"description", "flagusable",
				"upb", "codeupb", Child,maxlevel, Conn);
		}
	}
}
