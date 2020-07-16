/*
    Easy
    Copyright (C) 2020 Universit√† degli Studi di Catania (www.unict.it)
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



namespace meta_finmotive {
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	public class Meta_finmotive : Meta_easydata {
		int esercizio;
		public Meta_finmotive(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "finmotive") {		
			//Name="Piano dei conti";
			EditTypes.Add("default");
			EditTypes.Add("tree");
			ListingTypes.Add("tree");
			esercizio= Convert.ToInt32(GetSys("esercizio"));
		}

		protected override Form GetForm(string FormName){
			switch(FormName) {
				case "default":{
					Name="Causali bilancio";
					CanInsertCopy=false;
					ActAsList();
					IsTree = true;
					DefaultListType="tree";
					return MetaData.GetFormByDllName("finmotive_default");
				}
				case "tree": {
					Name = "Scelta della causale";
					ActAsList();
					IsTree = true;
					return GetFormByDllName("finmotive_tree");
				}
			}
			return null;
		}

		public override DataRow SelectByCondition(string filter, string searchtable){
			int ResultCount = Conn.RUN_SELECT_COUNT("finmotiveusable", filter, true);
			if (ResultCount!=1) return null;		
			DataTable T2 = Conn.RUN_SELECT("finmotive",null,null,filter,null,true);
			if (T2==null) return null;
			if (T2.Rows.Count==0) return null;
			return CheckSelectRow(T2.Rows[0]);

		}
		
		override public void SetDefaults(DataTable Primary){
			base.SetDefaults(Primary);
			string idprefix = esercizio.ToString().Substring(2,2); 
			SetDefault(Primary,"paridfinmotive",idprefix);
			SetDefault(Primary,"ayear", esercizio);
            SetDefault(Primary, "active", "S");
		}
        
		override public DataRow Get_New_Row(DataRow ParentRow, DataTable T){
			int maxDepth = 9;
			int level; 
			string codprefix;

			if (ParentRow!=null){
				level = 1 + ParentRow["idfinmotive"].ToString().Length / 4;
				codprefix = ParentRow["codemotive"].ToString();
			}
			else {
				level = 1;
				codprefix = "";
				SetDefault(T,"paridfinmotive",DBNull.Value);
				//SetDefault(T,"paridaccmotive",GetSys("esercizio").ToString().Substring(2,2));
			}
			if (level > (maxDepth)){
				//MessageBox. Show("Non Ë possibile inserire un livello inferiore a quello selezionato");
				return null;
			}

			string kind = "A"; //corresponding to "flagreset"

			RowChange.MarkAsAutoincrement(T.Columns["idfinmotive"],
				"paridfinmotive", null,4);

			if (kind.ToLower()=="a") {
				SetDefault(T,"codemotive", codprefix);
				//RowChange.ClearAutoIncrement(T.Columns["codefin"]);
			}		
			DataRow R = base.Get_New_Row(ParentRow, T);
			return R;
		}



		public override DataRow SelectOne(string ListingType, string filter, string searchtable, DataTable Exclude) {
			if (ListingType == "tree") {
				return base.SelectOne(ListingType, filter, "finmotiveview", Exclude);
			}
			else{
				return base.SelectOne(ListingType, filter, "finmotive", Exclude);
			}
		}

		public override void DescribeColumns(DataTable T, string ListingType) {
			base.DescribeColumns(T, ListingType);
			if (ListingType=="tree"){
				foreach (DataColumn C in T.Columns)
					DescribeAColumn(T, C.ColumnName, "",-1);
				DescribeAColumn(T,"codemotive","Codice",1);
				DescribeAColumn(T,"title","Denominazione",2);
			}
            if (ListingType == "default")
            {
                foreach (DataColumn C in T.Columns)
                    DescribeAColumn(T, C.ColumnName, "", -1);
                DescribeAColumn(T, "codemotive", "Codice", 1);
                DescribeAColumn(T, "title", "Denominazione", 2);
            }
		}


		public override void DescribeTree(TreeView tree, DataTable T, string ListingType) {
			// L'idupb ha una lunghezza di 36 caratteri ed ogni livello ha una lunghezza di 4 caratteri

			//Aggiorno le intestazioni del DataGrid
			if (ListingType=="tree"){
				base.DescribeColumns(T, ListingType);
				foreach (DataColumn C in T.Columns)
					DescribeAColumn(T, C.ColumnName, "");
				DescribeAColumn(T,"codemotive", "Codice");
				DescribeAColumn(T,"title","Denominazione");
			}

			base.DescribeTree(tree, T, ListingType);
            string filterc = QHC.IsNull("paridfinmotive");
            string filtersql = QHS.IsNull("paridfinmotive");

            TreeViewFinMotive M = new TreeViewFinMotive(Conn, T, tree, filterc, filtersql);
		}

	}


	public class TreeViewFinMotive : TreeViewManager {
        public TreeViewFinMotive(DataAccess Conn, DataTable T, TreeView tree, string filterc, string filtersql) :
            base(T, tree,
            new finmotive_node_dispatcher(
            "title",
            "codemotive", Conn)
            , filterc, filtersql) {
            base.DoubleClickForSelect = false;
        }
	    override public TreeNode AddNode(TreeNodeCollection Nodes, TreeNode NewNode) {
	        if (Nodes.Equals(tree.Nodes) && (NewNode.Tag != null) && (tree.Nodes.Count > 0)) {
	            if (tree.Nodes[0].Tag == null) return base.AddNode(tree.Nodes[0].Nodes, NewNode);
	        }
	        return base.AddNode(Nodes, NewNode);
	    }

        public override void FillNodes() {

            base.FillNodes();
            AutoEventsEnabled = false;
            TreeNode newroot = new TreeNode("Causali");
            if (tree.Nodes.Count >0) {
                if (tree.Nodes[0].Tag == null) return;
            }

            while (tree.Nodes.Count > 0) {
                TreeNode X = tree.Nodes[0];
                tree.Nodes.RemoveAt(0);
                if (X.Tag == null) continue;
                newroot.Nodes.Add(X);
            }

            tree.Nodes.Add(newroot);
            newroot.Expand();
            AutoEventsEnabled = true;
        }
    }

	public class finmotive_tree_node: easy_tree_node {
		DataAccess Conn;
		public finmotive_tree_node(
			string descr_field,
			string code_string,
			DataRow R, DataAccess Conn
            ) : base(null, null, null, null, descr_field, code_string, R) { this.Conn = Conn;  }

     
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
		    if (Conn == null) return false;
            QueryHelper QHS = Conn.GetQueryHelper();
			string filter = QHS.Like("idfinmotive", Row["idfinmotive"] + "%");
			int ResultCount = Conn.RUN_SELECT_COUNT("finmotiveusable", filter, true);
			if (ResultCount!=1) return false;
			return true;
		}
	}

	public class finmotive_node_dispatcher : easy_node_dispatcher{
        DataAccess Conn;
        public finmotive_node_dispatcher(string descr_field,
            string code_string, DataAccess Conn)
            : base(null,null,null,null,descr_field, code_string) {
            this.Conn = Conn;
        }
        

        override public tree_node GetNode(DataRow Parent, DataRow Child){
			return new finmotive_tree_node("title", "codemotive", Child, Conn);
		}

	}
}


