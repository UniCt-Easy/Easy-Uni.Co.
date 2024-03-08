
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
using HelpWeb;
using funzioni_configurazione;
using System.Web.UI.WebControls;

namespace meta_account {
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	public class Meta_account : Meta_easydata {
		int esercizio;
		public Meta_account(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "account") {		
			Name="Piano dei conti";
			EditTypes.Add("default");
			EditTypes.Add("tree");
            EditTypes.Add("treenew");
			EditTypes.Add("treeall");
            ListingTypes.Add("tree");
            ListingTypes.Add("treenew");
			ListingTypes.Add("treeall");
            ListingTypes.Add("checkimport");
            esercizio = Convert.ToInt32(GetSys("esercizio"));
		}

        public override bool CanSelect(DataRow R)
        {
            return DataAccess.CanSelect(Conn, R);
        }

		protected override Form GetForm(string FormName){
            switch (FormName) {
                case "default":
                    {
                        Name = "Piano dei conti";
                        CanInsertCopy = false;
                        ActAsList();
                        IsTree = true;
                        DefaultListType = "default";
                        return MetaData.GetFormByDllName("account_default");
                    }
                case "tree":
                    {
                        Name = "Scelta del conto";
                        ActAsList();
                        IsTree = true;
                        return GetFormByDllName("account_tree");
                    }
                case "treeall":
                    {
                        Name = "Scelta del conto";
                        ActAsList();
                        IsTree = true;
                        return GetFormByDllName("account_treeall");
                    }
                case "treenew":
                    {
                        Name = "Scelta del conto";
                        DefaultListType = FormName;
                        ActAsList();
                        IsTree = true;
                        return GetFormByDllName("account_tree");
                    }
                case "treeminusable": {
                        Name = "Scelta del conto";
                        DefaultListType = FormName;
                        ActAsList();
                        IsTree = true;
                        return GetFormByDllName("account_tree");
                    }
            }
            return null;
		}

		public override DataRow SelectByCondition(string filter, string searchtable){
		    if (edit_type == "treeall") {
		        return base.SelectByCondition(filter,"account");
		    }
		    int ResultCount = 0;
		    if (edit_type == "treeminusable") {
		        string filterenablebudgetprev = QHS.NullOrEq("flagenablebudgetprev", "S");
		        filter = QHS.AppAnd(filter, filterenablebudgetprev);
                ResultCount = Conn.RUN_SELECT_COUNT("accountminusable", filter, true);
            }
		    else {
                ResultCount = Conn.RUN_SELECT_COUNT("accountusable", filter, true);
            }
			
			if (ResultCount!=1) return null;		
			DataTable T2 = Conn.RUN_SELECT("account",null,null,filter,null,true);
			if (T2==null) return null;
			if (T2.Rows.Count==0) return null;
			return CheckSelectRow(T2.Rows[0]);

		}

		override public void SetDefaults(DataTable Primary){
			base.SetDefaults(Primary);
			string idprefix = esercizio.ToString().Substring(2,2); 
			SetDefault(Primary,"paridacc",idprefix);
			SetDefault(Primary,"ayear", esercizio);
			SetDefault(Primary,"flagregistry","N");
			SetDefault(Primary,"flagupb","S");
			SetDefault(Primary,"flagtransitory","N");
			SetDefault(Primary,"flagprofit", "N");
			SetDefault(Primary,"flagloss", "N");
			SetDefault(Primary,"placcount_sign","S");
			SetDefault(Primary,"patrimony_sign","S");
            SetDefault(Primary, "flagcompetency", "N");
            SetDefault(Primary, "flagenablebudgetprev", "S");
            SetDefault(Primary, "flag",0);
            SetDefault(Primary, "flagaccountusage", 0);
            SetDefault(Primary, "economicbudget_sign", "S");
            SetDefault(Primary, "investmentbudget_sign", "S");
		}
        
		override public DataRow Get_New_Row(DataRow ParentRow, DataTable T){
			DataTable Levels = T.DataSet.Tables["accountlevel"];
			if (Levels==null) return null;
			int level; 
			string codprefix;
			string ordinestampaprefix;
            object esercizio = T.Columns["ayear"].DefaultValue;
            if (esercizio == DBNull.Value) esercizio = Conn.GetEsercizio();

            if (ParentRow!=null){
				level = Convert.ToInt32(ParentRow["nlevel"])+1;
				codprefix = ParentRow["codeacc"].ToString();
				ordinestampaprefix=ParentRow["printingorder"].ToString();
			}
			else {
				level = 1;
				codprefix = "";
				ordinestampaprefix = "";
				SetDefault(T,"paridacc",esercizio.ToString().Substring(2,2));
			}
			if (level > Levels.Rows.Count){
				//MetaFactory.factory.getSingleton<IMessageShower>() .Show("Non è possibile inserire un livello inferiore a quello selezionato");
				return null;
			}
			string kind = "A"; //corresponding to "flagreset"
			DataRow [] levrow = Levels.Select(QHC.AppAnd(QHC.CmpEq("nlevel", level), QHC.CmpEq("ayear", esercizio)));

			if (levrow.Length!=1) return null;
			
			SetDefault(T, "nlevel", level);

			RowChange.MarkAsAutoincrement(T.Columns["idacc"],
				"paridacc", null, 4);

			if (kind.ToLower()=="a") {
				SetDefault(T,"codeacc", codprefix);
				SetDefault(T,"printingorder", ordinestampaprefix);
			}
					
			DataRow R = base.Get_New_Row(ParentRow, T);
			if (kind.ToLower()=="a")
				RowChange.ClearAutoIncrement(T.Columns["printingorder"]);
			return R;
		}

		public override void DescribeColumns(DataTable T, string ListingType) {
			base.DescribeColumns(T, ListingType);
			if (ListingType=="tree"||ListingType=="treeall"||ListingType == "treeminusable") {
                foreach (DataColumn C in T.Columns)
					DescribeAColumn(T, C.ColumnName, "",-1);
                int nPos = 1;
                DescribeAColumn(T, "codeacc", "Codice", nPos++);
                DescribeAColumn(T, "title", "Denominazione", nPos++);
			}
            if (ListingType == "checkimport" )
            {
                foreach (DataColumn C in T.Columns)
                    DescribeAColumn(T, C.ColumnName, "", -1);
                int nPos = 1;
                DescribeAColumn(T, "ayear", "Esercizio", nPos++);
                DescribeAColumn(T, "codeacc", "Codice", nPos++);
                DescribeAColumn(T, "title", "Denominazione", nPos++);
            }
		}


		public override DataRow SelectOne(string ListingType, string filter, string searchtable, DataTable Exclude) {
			if (ListingType == "default") {
				return base.SelectOne(ListingType, filter, "accountview", Exclude);
			}
			else{
				return base.SelectOne(ListingType, filter, "account", Exclude);
			}
		}

		public override void DescribeTree(System.Windows.Forms.TreeView tree, DataTable T, string ListingType){
			bool all = false;
			//Aggiorno le intestazioni del DataGrid
            if (ListingType == "tree" || ListingType == "treeall" || ListingType == "treenew" || ListingType == "treeminusable")
            {
				base.DescribeColumns(T, ListingType);
				foreach (DataColumn C in T.Columns)
					DescribeAColumn(T, C.ColumnName, "");
				DescribeAColumn(T,"!livello","Livello", "accountlevel.description");
				DescribeAColumn(T,"codeacc", "Codice");
				DescribeAColumn(T,"title","Denominazione");
			}

			base.DescribeTree(tree, T, ListingType);
            int esercizio = Convert.ToInt32(GetSys("esercizio"));
            int esercizionew = esercizio + 1;
            string filteresercizio = QHC.CmpEq("ayear",GetSys("esercizio"));
			string filterc=QHC.CmpEq("nlevel","1");
            string filtersql = QHS.CmpEq("nlevel", "1");

			int maxlevel = 0;
			object o = Conn.DO_READ_VALUE("accountlevel",filteresercizio,"max(nlevel)");
			if ((o != null) && (o != DBNull.Value)) maxlevel = Convert.ToInt32(o);
            int minlevelop = CfgFn.GetNoNullInt32(GetSys("accountusablelevel"));
		    string filterAccountLevel = filteresercizio;
            if (ListingType == "treeminusable") {
                maxlevel = minlevelop;
                filterAccountLevel = QHS.AppAnd(QHS.CmpEq("ayear", esercizionew),QHS.CmpLe("nlevel",minlevelop));
            }

            //		TreeViewAccount M = new TreeViewAccount(Conn, T, tree, filter, maxlevel);
            //		myGetData.SetStaticFilter("accountevel","(ayear='"+GetSys("esercizio").ToString()+"')");  
            //		
            if (ListingType=="treeall"){
				all=true;
			}
            if (ListingType == "treenew")
            {
                //string livsupid = esercizionew.ToString().Substring(2);
                //filter = "(paridacc is null + QueryCreator.quotedstrvalue(livsupid, true) + ")";
                filterAccountLevel = QHS.CmpEq("ayear", esercizionew);
                all = true;
            }
			TreeViewAccount M = new TreeViewAccount(Conn,T, tree, filterc,filtersql, all,maxlevel);
			myGetData.SetStaticFilter("accountlevel", filterAccountLevel);  
		}


        public override void WebDescribeTree(hwTreeView tree, DataTable T, string ListingType) {
            int esercizio = Convert.ToInt32(GetSys("esercizio"));
            int esercizionew = esercizio + 1;
            string filteresercizio = QHC.CmpEq("ayear", GetSys("esercizio"));
            string filterc = QHC.CmpEq("nlevel", "1");
            string filtersql = QHS.CmpEq("nlevel", "1");

            if (ListingType == "tree" || ListingType == "treeall" || ListingType == "treenew" || ListingType=="treeminusable") {
                base.DescribeColumns(T, ListingType);
                foreach (DataColumn C in T.Columns)
                    DescribeAColumn(T, C.ColumnName, "");
                DescribeAColumn(T, "!livello", "Livello", "accountlevel.description");
                DescribeAColumn(T, "codeacc", "Codice");
                DescribeAColumn(T, "title", "Denominazione");
            }
            int maxlevel = 0;
            object o = Conn.DO_READ_VALUE("accountlevel", filteresercizio, "max(nlevel)");
            if ((o != null) && (o != DBNull.Value)) maxlevel = Convert.ToInt32(o);
            int minlevelop = CfgFn.GetNoNullInt32(GetSys("accountusablelevel"));
            if (ListingType == "treeminusable") {
                maxlevel = minlevelop;
            }
            //Aggiorno le intestazioni del DataGrid
            if (ListingType == "tree") {
                base.DescribeColumns(T, ListingType);
                foreach (DataColumn C in T.Columns)
                    DescribeAColumn(T, C.ColumnName, "");
                DescribeAColumn(T, "codeacc", "Codice");
                DescribeAColumn(T, "title", "Denominazione");
            }

            base.WebDescribeTree(tree, T, ListingType);

            hwTreeViewAccount M = new hwTreeViewAccount(Conn,T, tree, filterc, filtersql, false, maxlevel);
        }
        public override bool IsValid (DataRow R, out string errmess, out string errfield){
			if (!base.IsValid(R, out errmess, out errfield))
				return false;
			if (R.RowState!=DataRowState.Added) return true;
			return true;
		}
	}
	
	//alla classe base viene passato nel primo caso (parametro all = true)
	//un node_dispatcher che consente di selezionare anche nodi non operativi
	public class TreeViewAccount : TreeViewManager {
		int maxlevel = 0;
		public TreeViewAccount(DataAccess Conn, DataTable T, System.Windows.Forms.TreeView tree, string filterc, string filtersql,
                    bool all, int maxlevel):               
			base(T,tree, 
				all?new easy_node_dispatcher(
			"accountlevel",
			"nlevel",
			"description",
			null,
			"title",
			"codeacc")
			:new account_node_dispatcher(
			"accountlevel",
			"nlevel",
			"description",
			"flagusable",
			"title",
			"codeacc",maxlevel,Conn)
			,filterc,filtersql
		    ){
			//se all vale true disabilito il doppio click come selezione
			if (all) base.DoubleClickForSelect=false;
		    this.maxlevel = maxlevel;
		}

		override public System.Windows.Forms.TreeNode AddNode(System.Windows.Forms.TreeNodeCollection Nodes, System.Windows.Forms.TreeNode NewNode){
			if (Nodes.Equals(tree.Nodes) && (NewNode.Tag!=null)){
				//searches the right node into which do the additon
				//DataRow R = ((tree_node) NewNode.Tag).Row;
				foreach(System.Windows.Forms.TreeNode N in Nodes) {
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
            System.Windows.Forms.TreeNode newroot= new System.Windows.Forms.TreeNode("E/P");

			while (tree.Nodes.Count>0){
                System.Windows.Forms.TreeNode X = tree.Nodes[0];
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
        public override void treeview_BeforeSelect(object sender, TreeViewCancelEventArgs e) {
            System.Windows.Forms.TreeNode N = e.Node;

            if (N.Tag != null) {
                tree_node TN = (tree_node) N.Tag;
                DataRow r = TN.Row;
                if (maxlevel>0 && CfgFn.GetNoNullInt32(r["nlevel"]) >= maxlevel) {
                    N.Nodes.Clear();            
                    return;
                }                
            }
            base.treeview_BeforeSelect(sender, e);
        }
        
       
    }

	public class account_tree_node: easy_tree_node {
		DataAccess Conn;
		int maxlevel;
		public account_tree_node(string level_table, 
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
            if (Lev == null) return false;
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

	public class account_node_dispatcher : easy_node_dispatcher{
		DataAccess Conn;
		int maxlevel;
		public account_node_dispatcher(
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
			return new account_tree_node("accountlevel", "nlevel", 
				"description", "flagusable",
				"title", "codeacc", Child,maxlevel, Conn);
		}

	}

    public class hwTreeViewAccount : hwTreeViewManager {
        public int maxlevel = 0;
        public hwTreeViewAccount(DataAccess Conn,DataTable T, hwTreeView tree, string filterc,
                string filtersql, bool all, int maxlevel) :
            base(T, tree,
            (all ? new easy_node_dispatcher(
                "accountlevel",
                "nlevel",
                "description",
                null,
                "title",
                "codeacc")
            : new account_node_dispatcher(
                "accountlevel",
            "nlevel",
            "description",
            "flagusable",
            "title",
            "codeacc", maxlevel, Conn
            )
            ), filterc, filtersql) {
            //se all vale true disabilito il doppio click come selezione
            this.maxlevel = maxlevel;
            if (all) base.DoubleClickForSelect = false;
        }

        public override void treeview_BeforeSelect(System.Web.UI.WebControls.TreeNode N) {
            if (N == null) return;
            if (GetTag(N) == null) return;
            tree_node TN = GetTag(N);
            DataRow r = TN.Row;
            if (maxlevel > 0 && CfgFn.GetNoNullInt32(r["nlevel"]) >= maxlevel) {
                N.ChildNodes.Clear();                
                return;
            }
            base.treeview_BeforeSelect(N);
        }
    }





}


