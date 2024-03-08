
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
using metadatalibrary;
using metaeasylibrary;
using System.Windows.Forms;
using System.Data;
using sorting_tree;//classmovimentiselect
using funzioni_configurazione;
using HelpWeb;

namespace meta_sorting{//meta_classmovimenti//
	/// <summary>
	/// Descrizione di riepilogo per classmovimenti.
	/// </summary>
	public class Meta_sorting : Meta_easydata {
		public Meta_sorting(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "sorting") {		
			Name= "Classificazione Movimenti";
			EditTypes.Add("default");
			EditTypes.Add("tree");
			ListingTypes.Add("tree");
		    ListingTypes.Add("treeusable");
            ListingTypes.Add("treenew");
			EditTypes.Add("treeall");
			ListingTypes.Add("treeall");
            ListingTypes.Add("tree5");
            EditTypes.Add("traduzione");
            EditTypes.Add("historytree");
		}

		protected override Form GetForm(string FormName){
            switch (FormName) {
                case "tree": {
                        Name = "Selezione voce di classificazione";
                        ActAsList();
                        IsTree = true;
                        return MetaData.GetFormByDllName("sorting_tree");
                    }
                case "tree5":
                    {
                        Name = "Selezione voce di classificazione";
                        ActAsList();
                        IsTree = true;
                        DefaultListType = FormName;
                        return MetaData.GetFormByDllName("sorting_tree");
                    }
                case "treeall": {
                        Name = "Selezione voce di classificazione";
                        ActAsList();
                        IsTree = true;
                        Frm_sorting_tree F = new Frm_sorting_tree();
                        F.tree.Tag = "sorting." + FormName;
                        return F;
                    }

                case "default": {
                        Name = "Classificazione";
                        CanInsertCopy = false;
                        ActAsList();
                        DefaultListType = "treenew";
                        IsTree = true;
                        return MetaData.GetFormByDllName("sorting_default");
                    }
                    case "history": {
                        Name = "Classificazione (storico)";
                        CanInsertCopy = false;
                        ActAsList();
                        DefaultListType = "history";
                        IsTree = true;
                        return MetaData.GetFormByDllName("sorting_default");
                    }

                case "traduzione": {
                        CanInsertCopy = false;
                        ActAsList();
                        IsTree = true;
                        DefaultListType = "tree";
                        return GetFormByDllName("sorting_traduzione");
                    }
                case "wizardmiur": {
                        return GetFormByDllName("sorting_wizardmiur");
                    }
            }
			return null;
		}			
    
		override public DataRow Get_New_Row(DataRow ParentRow, DataTable T){
			DataTable Levels = T.DataSet.Tables["sortinglevel"];
			if (Levels==null) return null;
			bool linear=false;
			int level; 
			string codprefix;
			string ordinestampaprefix;
			if (ParentRow!=null){
				level = Convert.ToInt32(ParentRow["nlevel"])+1;
				codprefix = ParentRow["sortcode"].ToString();
				ordinestampaprefix=ParentRow["printingorder"].ToString();
			}
			else {
				level = 1;
				codprefix = "";
				ordinestampaprefix = "";
			}
			if (level> (Levels.Select(QHC.CmpEq("idsorkind",this.ExtraParameter)).Length)){
				MetaFactory.factory.getSingleton<IMessageShower>().Show("Non è possibile inserire un livello inferiore a quello selezionato");
				return null;
			}
			int len=6;
			string kind = "A";
			DataRow [] levrow = Levels.Select(QHC.AppAnd(QHC.CmpEq("idsorkind",this.ExtraParameter),QHC.CmpEq("nlevel",level)));

			if (levrow.Length!=1) return null;

            int flag = CfgFn.GetNoNullInt32(levrow[0]["flag"]);
            len = flag >> 8;
            kind = (flag & 1) != 0 ? "A" : "N";
            if ((flag & 4) == 0) {
                linear = true;
			}

			T.Columns["sortcode"].ExtendedProperties["length"]=codprefix.Length+len;
			if (kind.ToUpper()=="A"){				
				RowChange.MarkAsAutoincrement(T.Columns["printingorder"], null,ordinestampaprefix,len,linear);
			}
			
			SetDefault(T, "nlevel", level);

           //RowChange.SetSelector(T,"idsorkind");
			RowChange.MarkAsAutoincrement(T.Columns["idsor"], null, null, 8);

			if (kind.ToLower()=="a"){
				SetDefault(T,"sortcode", codprefix);
				RowChange.ClearAutoIncrement(T.Columns["sortcode"]);
				SetDefault(T,"printingorder", ordinestampaprefix);//??
			}
			else {
				RowChange.MarkAsAutoincrement(T.Columns["sortcode"],
					null,codprefix,len,linear);
				RowChange.MarkAsAutoincrement(T.Columns["printingorder"],
                    null, ordinestampaprefix, len, linear);
                if (!linear)
                {
                    RowChange.SetMySelector(T.Columns["sortcode"], "paridsor", 0);
                    RowChange.SetMySelector(T.Columns["printingorder"], "paridsor", 0);
                }
                RowChange.SetMySelector(T.Columns["sortcode"], "idsorkind", 0);
                RowChange.SetMySelector(T.Columns["printingorder"], "idsorkind", 0);
			
			}			


			DataRow R = base.Get_New_Row(ParentRow, T);
			if (kind.ToLower()=="a")
				RowChange.ClearAutoIncrement(T.Columns["printingorder"]);
			return R;
		}

        /*
		public override bool IsValid (DataRow R, out string errmess, out string errfield){
			if (!base.IsValid(R, out errmess, out errfield))
				return false;
			if (R.RowState!=DataRowState.Added) return true;
			int lunghezza =(int)PrimaryDataTable.Columns["sortcode"].ExtendedProperties["length"];
			if (lunghezza>0 &&  R["sortcode"].ToString().Length != lunghezza){
				errmess="Attenzione! Il campo 'codice' deve avere lunghezza "+lunghezza+".";
				errfield="sortcode";
				return false;
			}
			return true;
		}
        */

		public override DataRow SelectByCondition(string filter, string searchtable){
            filter = QHS.AppAnd(filter,
                        QHS.NullOrLe("start", GetSys("esercizio")),
                        QHS.NullOrGe("stop", GetSys("esercizio")));
			if (edit_type=="treeall") return base.SelectByCondition(filter,"sorting");

            if (edit_type == "tree5") {
                filter = QHS.AppAnd(filter, QHS.CmpEq("nlevel", 5));
                return base.SelectByCondition(filter, "sortingview");
            }

            return base.SelectByCondition(filter,"sortingusable");
		}


		public override void DescribeColumns(DataTable T, string ListingType){
			base.DescribeColumns(T, ListingType);
			if ((ListingType=="tree")||(ListingType=="treeall") || (ListingType == "tree5")) {
                foreach (DataColumn C in T.Columns) {
                    DescribeAColumn(T, C.ColumnName, "");
                }
				DescribeAColumn(T,"sortcode","Codice");
				DescribeAColumn(T,"description","Descrizione");
				DescribeAColumn(T,"movkind","Tipo movimento");
				DescribeAColumn(T,"printingorder","Ordine stampa");
			}

//			DescribeAColumn(T,"sortcode","Codice");
//			DescribeAColumn(T,"description","Descrizione");
		}

        public override DataRow SelectOne (string ListingType, string filter, string searchtable, DataTable Exclude) {
            if (ListingType == "treenew") return base.SelectOne(ListingType, filter, "sortingyearview", Exclude);
            if (ListingType == "history") return base.SelectOne(ListingType, filter, "sortingyearview", Exclude);
            if (ListingType == "treeusable") {
                //includo filtro su anno inzio e fine
                filter = QHS.AppAnd(filter, QHS.AppAnd(QHS.NullOrLe("start", GetSys("esercizio")),
                         QHS.NullOrGe("stop", GetSys("esercizio"))));
                return base.SelectOne(ListingType, filter, "sortingusable", Exclude);
            }
            if (ListingType == "treeall") return base.SelectOne(ListingType, filter, "sortingall", Exclude);
            if (ListingType == "tree5") {
                filter = QHS.AppAnd(filter, QHS.CmpEq("nlevel", 5));
            } 
            return base.SelectOne(ListingType, filter, "sorting", Exclude);
        }	


		public override void DescribeTree(TreeView tree, DataTable T, string ListingType){
			base.DescribeTree(tree, T, ListingType);
			string filterc=QHC.CmpEq("nlevel","1");
			string filtersql=QHS.CmpEq("nlevel","1");
            if (ListingType != "history") {
                int eserc= CfgFn.GetNoNullInt32( GetSys("esercizio"));
                filterc = QHC.AppAnd(filterc, QHC.NullOrLe("start", eserc), QHC.NullOrGe("stop", eserc));
                filtersql = QHC.AppAnd(filtersql, QHS.NullOrLe("start", eserc), QHS.NullOrGe("stop", eserc));
            }
            //			if (ListingType=="tree"){
            //				string eserc = esercizio.ToString();
            //				filter=filter+"AND(esercizio='" + eserc + "')";
            //			}
            //easy_node_dispatcher D = new easy_node_dispatcher(
            //    "sortinglevel",
            //    "nlevel",
            //    "description",
            //    "flagusable",
            //    "description",
            //    "sortcode"
            //    );
            int maxlevel = 0;
            string filterSortLevel = "";

            if (ListingType == "tree5") {
                maxlevel = 5;
                filterSortLevel = QHS.CmpLe("nlevel", maxlevel);
                myGetData.SetStaticFilter("sortinglevel", filterSortLevel);
            }

            bool all = false;
			if (ListingType=="treeall"){
				all=true;
			}
            //object o = T.ExtendedProperties["idsorkindFilter"];
            //string filtro = o==null
            //    ? QHS.BitSet("flag", 1)
            //    : QHS.AppAnd(o.ToString(), QHS.BitSet("flag", 1));
            //int levelop = CfgFn.GetNoNullInt32(Conn.DO_READ_VALUE("sortinglevel", filtro, "min(nlevel)"));
			TreeViewManager M = new TreeViewClassMovimenti(Conn,T, tree, filterc, filtersql,all,maxlevel); //, levelop);
		}

	    public override void WebDescribeTree(hwTreeView tree, DataTable T, string ListingType) {
	        base.WebDescribeTree(tree, T, ListingType);
	        string filterc = QHC.CmpEq("nlevel", "1");
	        string filtersql = QHS.CmpEq("nlevel", "1");
	        if (ListingType != "history") {
	            int eserc = CfgFn.GetNoNullInt32(GetSys("esercizio"));
	            filterc = QHC.AppAnd(filterc, QHC.NullOrLe("start", eserc), QHC.NullOrGe("stop", eserc));
	            filtersql = QHC.AppAnd(filtersql, QHS.NullOrLe("start", eserc), QHS.NullOrGe("stop", eserc));
	        }
            //			if (ListingType=="tree"){
            //				string eserc = esercizio.ToString();
            //				filter=filter+"AND(esercizio='" + eserc + "')";
            //			}
            //easy_node_dispatcher D = new easy_node_dispatcher(
            //    "sortinglevel",
            //    "nlevel",
            //    "description",
            //    "flagusable",
            //    "description",
            //    "sortcode"
            //    );
            int maxlevel = 0;
            if (ListingType == "tree5") {
                maxlevel = 5;
            }
            bool all = false;
	        if (ListingType == "treeall") {
	            all = true;
	        }
	        //object o = T.ExtendedProperties["idsorkindFilter"];
	        //string filtro = o==null
	        //    ? QHS.BitSet("flag", 1)
	        //    : QHS.AppAnd(o.ToString(), QHS.BitSet("flag", 1));
	        //int levelop = CfgFn.GetNoNullInt32(Conn.DO_READ_VALUE("sortinglevel", filtro, "min(nlevel)"));
	        hwTreeViewManager M = new WebTreeViewClassMovimenti(Conn,T, tree, filterc, filtersql, all,maxlevel); //, levelop);
	    }


	}
    public class sorting_node_dispatcher : easy_node_dispatcher {
        DataAccess Conn;
        int maxlevel;
        public sorting_node_dispatcher(
            string level_table,
            string level_field,
            string descr_level_field,
            //int levelop,
            string descr_field,
            string code_string,
            int maxlevel,
            DataAccess Conn
            )
            : base(level_table,
                    level_field,
                    descr_level_field,
                    null,
                    descr_field, code_string) {
            this.maxlevel = maxlevel;
            this.Conn = Conn;
        }

        override public tree_node GetNode(DataRow Parent, DataRow Child) {
            return new sorting_tree_node("sortinglevel", "nlevel",
                "description", //levelop,
                "description", "sortcode", Child,maxlevel,Conn);
        }

    }

    public class sorting_tree_node : easy_tree_node {
        //int levelop;
        DataAccess Conn;
        int maxlevel;
        public sorting_tree_node(string level_table,
            string level_field,
            string descr_level_field,
            //int levelop,
            string descr_field,
            string code_string,
            DataRow R,//,
            int maxlevel,
            DataAccess Conn
            )
            : base(level_table,
            descr_level_field,
            descr_level_field,
            null,
            descr_field,
            code_string,
            R) {
            this.maxlevel = maxlevel;
            this.Conn = Conn;
        }

        bool row_exists() {
            if (Row == null) return false;
            if (Row.RowState == DataRowState.Deleted) return false;
            if (Row.RowState == DataRowState.Detached) return false;
            return true;
        }

        /// <summary>
        /// True if "selectable" and with "no chidren" or maxlevel==current level
        /// </summary>
        /// <returns></returns>
        override public bool CanSelect() {
            if (!row_exists()) return false;
            DataRow Lev = LevelRow();
            if (Lev == null) return false;
            if (maxlevel > 0) {
                if (Lev["nlevel"].ToString() == maxlevel.ToString()) return true;
            }
            //int thislev = CfgFn.GetNoNullInt32(Lev["nlevel"]);
            //if (thislev < levelop) return false;
            int flag = CfgFn.GetNoNullInt32(Lev["flag"]);
            if ((flag & 2) == 0) return false;
            if (HasAutoChildren()) return false;
            return true;
        }

    }

    public class WebTreeViewClassMovimenti : hwTreeViewManager
    {
        public int maxlevel = 0;
        public WebTreeViewClassMovimenti(DataAccess Conn, DataTable T, hwTreeView tree, string filterc, 
                string filtersql, bool all, int maxlevel)
            : //,int levelop):
			base(T,tree, 
			(all?
			new easy_node_dispatcher(
			"sortinglevel",
			"nlevel",
			"description",
			null,
			"description",
			"sortcode"
			):
            new sorting_node_dispatcher(
			"sortinglevel",//level_table
			"nlevel",//level_field
			"description",//descr_level_field
            //levelop,//selectable_level_field
			"description",//descr_field
			"sortcode", maxlevel, Conn
            )
			),filterc,filtersql) {
            this.maxlevel = maxlevel;
            if (all) base.DoubleClickForSelect=false;
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
        public override System.Web.UI.WebControls.TreeNode AddNode(System.Web.UI.WebControls.TreeNodeCollection Nodes, System.Web.UI.WebControls.TreeNode NewNode, tree_node T_N)
        {
            if (Nodes.Equals(tree.Nodes) && (T_N!= null) && (tree.Nodes.Count > 0))
            {
                if (GetTag(tree.Nodes[0])  == null) return base.AddNode(tree.Nodes[0].ChildNodes, NewNode,T_N);
            }
            return base.AddNode(Nodes, NewNode, T_N);
        }

		public override void FillNodes()
		{

			base.FillNodes();
			AutoEventsEnabled=false;
            System.Web.UI.WebControls.TreeNode[] newroot = new System.Web.UI.WebControls.TreeNode[1];
            newroot[0] = new System.Web.UI.WebControls.TreeNode("Classificazione");
            tree.Nodes.Add(newroot[0]);

			if (tree.Nodes.Count>0)
			{
                System.Web.UI.WebControls.TreeNode TN = tree.Nodes[0] as System.Web.UI.WebControls.TreeNode;
                if (GetTag(TN) == null) return;
			}

			while (tree.Nodes.Count>1)
			{
                System.Web.UI.WebControls.TreeNode X= tree.Nodes[0];
                tree_node TN = GetTag(X);
                if (TN == null) {
                    tree.Nodes.RemoveAt(0);
                    continue;
                }
                MovSubTree(tree.Nodes, 0, newroot[0]);
			}

    		newroot[0].Expand();

			AutoEventsEnabled=true;
		}		
        
    }


    public class TreeViewClassMovimenti : TreeViewManager 
	{
        int maxlevel = 0;
        public TreeViewClassMovimenti(DataAccess Conn, DataTable T, TreeView tree, string filterc,string filtersql,bool all, int maxlevel) : //,int levelop):
			base(T,tree, 
			(all?
			new easy_node_dispatcher(
			"sortinglevel",
			"nlevel",
			"description",
			null,
			"description",
			"sortcode"
			):
            new sorting_node_dispatcher(
			"sortinglevel",//level_table
			"nlevel",//level_field
			"description",//descr_level_field
            //levelop,//selectable_level_field
			"description",//descr_field
			"sortcode",
            maxlevel,Conn//code_string
            )
			),filterc,filtersql) {
			if (all) base.DoubleClickForSelect=false;
            this.maxlevel = maxlevel;
        }

		override public TreeNode AddNode(TreeNodeCollection Nodes, TreeNode NewNode)
		{
			if (Nodes.Equals(tree.Nodes) && (NewNode.Tag!=null)&& (tree.Nodes.Count>0))
			{
				if (tree.Nodes[0].Tag==null) return base.AddNode(tree.Nodes[0].Nodes, NewNode);
			}
			return base.AddNode(Nodes,NewNode);
		}

		public override void FillNodes()
		{

			base.FillNodes();
			AutoEventsEnabled=false;
			TreeNode [] newroot= new TreeNode[1];
			newroot[0]= new TreeNode("Classificazione");
			if (tree.Nodes.Count>0)
			{
				if (tree.Nodes[0].Tag==null) return;
			}

			while (tree.Nodes.Count>0)
			{
				TreeNode X = tree.Nodes[0];
				tree.Nodes.RemoveAt(0);
				if (X.Tag==null) continue;
				DataRow R = ((tree_node) X.Tag).Row;
				newroot[0].Nodes.Add(X);
			}
//			if (newroot[0].Nodes.Count>0)
//			{
				tree.Nodes.Add(newroot[0]);
				newroot[0].Expand();
//			}
			AutoEventsEnabled=true;
		}


        public override void treeview_BeforeSelect(object sender, TreeViewCancelEventArgs e) {
            System.Windows.Forms.TreeNode N = e.Node;

            if (N.Tag != null) {
                tree_node TN = (tree_node)N.Tag;
                DataRow r = TN.Row;
                if (maxlevel > 0 && CfgFn.GetNoNullInt32(r["nlevel"]) >= maxlevel) {
                    N.Nodes.Clear();
                    return;
                }
            }
            base.treeview_BeforeSelect(sender, e);
        }
    }
}
