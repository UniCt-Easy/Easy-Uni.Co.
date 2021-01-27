
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
using System.Data;
using System.Windows.Forms;
using System.Web;
using metaeasylibrary;
using metadatalibrary;
using HelpWeb;

namespace meta_accmotiveapplied {
	/// <summary>
	/// Summary description for Meta_accmotiveapplied.
	/// </summary>
	public class Meta_accmotiveapplied : Meta_easydata {
		public Meta_accmotiveapplied(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "accmotiveapplied") {
			EditTypes.Add("tree");
			ListingTypes.Add("tree");
		}

       
        public override bool CanSelect(DataRow R) {
            return DataAccess.CanSelect(Conn, R);
        }


        public override DataRow CheckSelectRow(DataRow R) {
            int ResultCount = Conn.RUN_SELECT_COUNT("accmotivedetail",
                           QHS.AppAnd(QHS.CmpEq("idaccmotive", R["idaccmotive"]), QHS.CmpEq("ayear", GetSys("esercizio"))), true);
            if (ResultCount == 0) {
                ShowClientMsg("Causale non associata a Conto.", "Errore", MessageBoxButtons.OK);
                return null;
            }
            return base.CheckSelectRow(R);
            
        }

        private string[] mykey = new string[] { "idaccmotive", "idepoperation" };
        public override string[] primaryKey() {
            return mykey;
        }
        string removefilterEP(string filter){
            string mask = "(codemotive";
            int i = filter.IndexOf(mask);
            if (i < 0) return filter;
            return filter.Substring(i);
            //int j = filter.IndexOf(")", i + mask.Length) + 1;
            //if (j + 1 < filter.Length) j += 3;
            //return filter.Substring(0, i) + filter.Substring(j + 1);
		}

        public override DataRow SelectByCondition(string filter, string searchtable) {
            string filternoEP = removefilterEP(filter);

            int ResultCount = Conn.RUN_SELECT_COUNT("accmotiveusable", filternoEP, true);
            if (ResultCount != 1) return null;

            DataTable T2 = Conn.RUN_SELECT("accmotiveapplied", null, null, filter, null, true);
            if (T2 == null) return null;
            if (T2.Rows.Count == 0) return null;
            return CheckSelectRow(T2.Rows[0]);
        }

		protected override Form GetForm(string FormName){
			if (FormName=="tree"){
				Name= "Selezione della Causale";
				ActAsList();                
				IsTree=true;
				DefaultListType = "tree";
				return GetFormByDllName("accmotiveapplied_tree");
			}
			return null;
		}

		public override void DescribeColumns(DataTable T, string ListingType){
			base.DescribeColumns(T, ListingType);

			if(ListingType=="tree") {
				foreach(DataColumn C in T.Columns) DescribeAColumn(T, C.ColumnName, "",-1);
				DescribeAColumn(T, "codemotive", "Cod. Causale",1);
				DescribeAColumn(T, "motive", "Causale",2);
			}
		}

        public override void WebDescribeTree(hwTreeView tree, DataTable T, string ListingType)
        {
            int esercizio = Convert.ToInt32(GetSys("esercizio"));

            if (ListingType == "tree")
            {
                DescribeColumns(T, ListingType);
            }
            
            
            base.WebDescribeTree(tree, T, ListingType);
            int maxlevel = 9;
            string filterc = QHC.IsNull("paridaccmotive");
            string filtersql = QHS.IsNull("paridaccmotive");
            hwTreeViewManager M = new hwTreeViewAccMotiveApplied(Conn, T, tree, filterc, filtersql, maxlevel);

        }

		public override void DescribeTree(TreeView tree, DataTable T, string ListingType){
			//Aggiorno le intestazioni del DataGrid
			int esercizio = Convert.ToInt32(GetSys("esercizio"));

			if (ListingType == "tree"){
				DescribeColumns(T, ListingType);
			}

			base.DescribeTree(tree, T, ListingType);
			
			int maxlevel = 9;
            string filterc = QHC.IsNull("paridaccmotive");
            string filtersql = QHS.IsNull("paridaccmotive");
            TreeViewManager M = new TreeViewAccMotiveApplied(Conn, T, tree, filterc, filtersql, maxlevel);
		}
	}

	public class accmotiveapplied_tree_node: easy_tree_node {
		DataAccess Conn;
		int maxlevel;
		public accmotiveapplied_tree_node(string level_table, 
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
			if (HasAutoChildren()) return false;
            QueryHelper QHS = Conn.GetQueryHelper();
			string filter = QHS.Like("idaccmotive", Row["idaccmotive"] + "%");
			int ResultCount = Conn.RUN_SELECT_COUNT("accmotiveusable", filter, true);
			if (ResultCount!=1) return false;
            ResultCount = Conn.RUN_SELECT_COUNT("accmotivedetail",
                           QHS.AppAnd(QHS.CmpEq("idaccmotive", Row["idaccmotive"]), QHS.CmpEq("ayear", Conn.GetSys("esercizio"))), true);
            if (ResultCount == 0) {                
                return false;
            }
            return true;
        }
        /// <summary>
        /// True if "selectable" and with "no chidren" or maxlevel==current level
        /// </summary>
        /// <returns></returns>
        override public string  UnselectableMessage() {
            if (!row_exists()) return base.UnselectableMessage();
            if (HasAutoChildren()) return base.UnselectableMessage();
            QueryHelper QHS = Conn.GetQueryHelper();
            string filter = QHS.Like("idaccmotive", Row["idaccmotive"] + "%");
            int ResultCount = Conn.RUN_SELECT_COUNT("accmotiveusable", filter, true);
            if (ResultCount != 1) return base.UnselectableMessage();
            ResultCount = Conn.RUN_SELECT_COUNT("accmotivedetail",
                           QHS.AppAnd(QHS.CmpEq("idaccmotive", Row["idaccmotive"]), QHS.CmpEq("ayear", Conn.GetSys("esercizio"))), true);
            if (ResultCount == 0) {
                return $"La causale selezionata non ha conti associati nell'esercizio {Conn.GetEsercizio()}";
            }
            return "Errore in UnselectableMessage di meta_accmotiveapplied";
        }
    }

	public class accmotiveapplied_node_dispatcher : easy_node_dispatcher{
		DataAccess Conn;
		int maxlevel;
		public accmotiveapplied_node_dispatcher(
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
			return new accmotiveapplied_tree_node(null, null, 
				null, null, 
				"motive", "codemotive", Child,maxlevel,Conn);
		}
	}

    public class hwTreeViewAccMotiveApplied : hwTreeViewManager {
        public int maxlevel;
		public hwTreeViewAccMotiveApplied(DataAccess Conn, DataTable T, hwTreeView tree, string filterc, string filtersql,
            int maxlevel):               
			base(T,tree, new accmotiveapplied_node_dispatcher(
			null,
			null,
			null,
			null,
			"motive",
			"codemotive",
			maxlevel,
			Conn
			),filterc, filtersql) {
			this.maxlevel = maxlevel;
		}

        override public System.Web.UI.WebControls.TreeNode AddNode(System.Web.UI.WebControls.TreeNodeCollection Nodes, System.Web.UI.WebControls.TreeNode NewNode,tree_node T_N)
        {
            if (Nodes.Equals(tree.Nodes) && (T_N != null))
            {
                foreach (System.Web.UI.WebControls.TreeNode N in Nodes)
                {
                    if (N.Text == "Causale")
                    {
                        return base.AddNode(N.ChildNodes, NewNode,T_N);
                    }
                }
            }
            return base.AddNode(Nodes, NewNode,T_N);
        }

        public override void FillNodes()
        {
            base.FillNodes();
            AutoEventsEnabled = false;

            if (tree.Nodes.Count > 0)
            {
                System.Web.UI.WebControls.TreeNode TN = tree.Nodes[0] as System.Web.UI.WebControls.TreeNode;
                if (GetTag(TN) == null) return;

                //if (tree.Nodes[0].Tag == null) return;
            }
            System.Web.UI.WebControls.TreeNode newroot = new System.Web.UI.WebControls.TreeNode("Causale");
            tree.Nodes.Add(newroot);
            while (tree.Nodes.Count > 1)
            {
                System.Web.UI.WebControls.TreeNode X = tree.Nodes[0] as System.Web.UI.WebControls.TreeNode;
                tree_node X_TAG = GetTag(X);
                if (X_TAG == null)
                {
                    tree.Nodes.RemoveAt(0);
                    continue;
                }
                MovSubTree(tree.Nodes, 0, newroot);

            }

            //tree.Nodes.Add(newroot);

            if(newroot.ChildNodes.Count>0)
                newroot.Expand();
            AutoEventsEnabled = true;
        }	
    
    }

	public class TreeViewAccMotiveApplied : TreeViewManager {
		public int maxlevel;
		public TreeViewAccMotiveApplied(DataAccess Conn, DataTable T, TreeView tree, string filterc, string filtersql,
            int maxlevel):               
			base(T,tree, new accmotiveapplied_node_dispatcher(
			null,
			null,
			null,
			null,
			"motive",
			"codemotive",
			maxlevel,
			Conn
			),filterc, filtersql) {
			this.maxlevel = maxlevel;


		}

		override public TreeNode AddNode(TreeNodeCollection Nodes, TreeNode NewNode){
			if (Nodes.Equals(tree.Nodes) && (NewNode.Tag!=null)){
				foreach(TreeNode N in Nodes) {
					if (N.Text == "Causale") {
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
			TreeNode newroot= new TreeNode("Causale");

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
}
