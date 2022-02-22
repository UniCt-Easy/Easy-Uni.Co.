
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



namespace meta_accmotive {
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	public class Meta_accmotive : Meta_easydata {
		int esercizio;
		public Meta_accmotive(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "accmotive") {		
			Name="Piano dei conti";
			EditTypes.Add("default");
			EditTypes.Add("tree");
			ListingTypes.Add("tree");
			esercizio= Convert.ToInt32(GetSys("esercizio"));
		}

		protected override Form GetForm(string FormName){
			switch(FormName) {
				case "default":{
					Name="Causali";
					CanInsertCopy=false;
					ActAsList();
					IsTree = true;
					DefaultListType="tree";
					return MetaData.GetFormByDllName("accmotive_default");
				}
				case "tree": {
					Name = "Scelta della causale";
					ActAsList();
					IsTree = true;
					return GetFormByDllName("accmotive_tree");
				}
			}
			return null;
		}

    
        public override DataRow CheckSelectRow(DataRow R) {
            int ResultCount = Conn.RUN_SELECT_COUNT("accmotivedetail",
                           QHS.AppAnd(QHS.CmpEq("idaccmotive", R["idaccmotive"]), QHS.CmpEq("ayear", GetSys("esercizio"))), true);
            if (edit_type == "default") {
                return base.CheckSelectRow(R);
            }
            if (ResultCount == 0) {
                ShowClientMsg("Causale non associata a Conto.", "Errore", MessageBoxButtons.OK);
                return null;
            }
            return base.CheckSelectRow(R);
        }

        public override DataRow SelectByCondition(string filter, string searchtable){
			int ResultCount = Conn.RUN_SELECT_COUNT("accmotiveusable", filter, true);
			if (ResultCount!=1) return null;		
			DataTable T2 = Conn.RUN_SELECT("accmotive",null,null,filter,null,true);
			if (T2==null) return null;
			if (T2.Rows.Count==0) return null;
			return CheckSelectRow(T2.Rows[0]);

		}
		
		override public void SetDefaults(DataTable Primary){
			base.SetDefaults(Primary);
			string idprefix = esercizio.ToString().Substring(2,2); 
			SetDefault(Primary,"paridaccmotive",idprefix);
			SetDefault(Primary,"ayear", esercizio);
		}
        
		override public DataRow Get_New_Row(DataRow ParentRow, DataTable T){
			int maxDepth = 9;
			int level; 
			string codprefix;

			if (ParentRow!=null){
				level = 1 + ParentRow["idaccmotive"].ToString().Length / 4;
				codprefix = ParentRow["codemotive"].ToString();
			}
			else {
				level = 1;
				codprefix = "";
				SetDefault(T,"paridaccmotive",DBNull.Value);
				//SetDefault(T,"paridaccmotive",GetSys("esercizio").ToString().Substring(2,2));
			}
			if (level > (maxDepth)){
				//MessageBox .Show("Non è possibile inserire un livello inferiore a quello selezionato");
				return null;
			}

			string kind = "A"; //corresponding to "flagreset"

			RowChange.MarkAsAutoincrement(T.Columns["idaccmotive"],
				"paridaccmotive", null,4);

			if (kind.ToLower()=="a") {
				SetDefault(T,"codemotive", codprefix);
				//RowChange.ClearAutoIncrement(T.Columns["codefin"]);
			}		
			DataRow R = base.Get_New_Row(ParentRow, T);
			return R;
		}



		public override DataRow SelectOne(string ListingType, string filter, string searchtable, DataTable Exclude) {
			if (ListingType == "tree") {
				return base.SelectOne(ListingType, filter, "accmotiveview", Exclude);
			}
			else{
				return base.SelectOne(ListingType, filter, "accmotive", Exclude);
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
            string filterc = QHC.IsNull("paridaccmotive");
            string filtersql = QHS.IsNull("paridaccmotive");

			TreeViewAccMotive M = new TreeViewAccMotive(Conn, T, tree, filterc,filtersql);
		}

	}


	public class TreeViewAccMotive : TreeViewManager {
		public TreeViewAccMotive(DataAccess Conn, DataTable T, TreeView tree, string filterc, string filtersql):               
			base(T,tree, 
			new accmotive_node_dispatcher(
			null,
			null,
			null,
			null,
			"title",
			"codemotive", Conn)
			,filterc,filtersql) {
			base.DoubleClickForSelect=false;
		}
	    override public TreeNode AddNode(TreeNodeCollection Nodes, TreeNode NewNode) {
	        if (Nodes.Equals(tree.Nodes) && (NewNode.Tag != null) && (tree.Nodes.Count > 0)) {
	            if (tree.Nodes[0].Tag == null) return base.AddNode(tree.Nodes[0].Nodes, NewNode);
	        }
	        return base.AddNode(Nodes, NewNode);
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
				//					TreeNode temp = new TreeNode("temporary");
				//					X.Nodes.Add(temp);
				//
				tree.Nodes.RemoveAt(0);
				if (X.Tag==null) continue;
				newroot.Nodes.Add(X);
			}
			tree.Nodes.Add(newroot);
			newroot.Expand();
			AutoEventsEnabled=true;
		}		
	}

	public class accmotive_tree_node: easy_tree_node {
		DataAccess Conn;
		public accmotive_tree_node(string level_table, 
			string level_field,
			string descr_level_field,
			string selectable_level_field,
			string descr_field,
			string code_string,
			DataRow R,
			DataAccess Conn
			):base(level_table,
			descr_level_field,
			descr_level_field,
			selectable_level_field,
			descr_field,
			code_string,
			R){
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
        override public string UnselectableMessage() {
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

	public class accmotive_node_dispatcher : easy_node_dispatcher{
		DataAccess Conn;
		public accmotive_node_dispatcher(
			string level_table, 
			string level_field,
			string descr_level_field,
			string selectable_level_field,
			string descr_field,
			string code_string,
			DataAccess Conn
			):base(level_table,
			level_field,
			descr_level_field, 
			selectable_level_field, 
			descr_field,code_string) {
			this.Conn = Conn;
		}		

		override public tree_node GetNode(DataRow Parent, DataRow Child){
			return new accmotive_tree_node(null, null, 
				null, null,
				"title", "codemotive", Child, Conn);
		}

	}
}


