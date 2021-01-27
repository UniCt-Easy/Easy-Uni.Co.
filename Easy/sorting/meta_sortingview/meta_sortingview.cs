
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
using metadatalibrary;
using metaeasylibrary;
using funzioni_configurazione;
//Pino: using ClassMovimentiViewTreeSelect; diventato inutile

namespace meta_sortingview//meta_classmovimentiview//
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	public class Meta_sortingview : Meta_easydata 
	{
		public Meta_sortingview(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "sortingview") 
		{		
			Name="Classificazione movimenti";
			EditTypes.Add("tree");
			ListingTypes.Add("tree");
            ListingTypes.Add("default");
        }
        private string[] mykey = new string[] { "idsor", "ayear" };
        public override string[] primaryKey() {
            return mykey;
        }
        /// <summary>
        /// Elimina la parte di filtro costituita da esercizio='yyyy' poiché
        /// la vista classmovimentioperativo non contiene il campo esercizio
        /// </summary>
        /// <param name="filter">filtro da purificare</param>
        /// <returns>filtro purificato</returns>
        //private string PurificaFiltro(string filter) {
        //    string tofind="(ayear='"+GetSys("esercizio").ToString()+"')";
        //    int lentofind=tofind.Length;
        //    //se non contiene la stringa non faccio nulla
        //    if (!(filter.IndexOf(tofind)>0)) return filter;
        //    //cerco il punto di inizio
        //    int begin=filter.IndexOf(tofind);
        //    int end=begin+lentofind;
        //    //elimino la stringa
        //    string newfilter=filter.Substring(0,begin)+filter.Substring(end);
        //    //si trova in prima posizione?
        //    if (newfilter.Trim().StartsWith("AND"))
        //        return newfilter.Trim().Substring(3);
        //    //si trova in ultima posizione?
        //    if (newfilter.Trim().EndsWith("AND")) 
        //        return newfilter.Trim().Substring(0, newfilter.Length - newfilter.LastIndexOf("AND"));
        //    //si trova al centro
        //    return newfilter.Replace("ANDAND","AND");
        //}

        public override DataRow SelectByCondition(string filter, string searchtable) {
            //filter=PurificaFiltro(filter);
			DataRow R = base.SelectByCondition(filter,"sortingusableyear");
			if (R==null) return null;
			string newfilter =QHS.AppAnd(QHS.CmpEq("ayear",GetSys("esercizio")),
                    QHS.MCmp(R,"idsorkind","idsor"),
                    QHS.NullOrLt("start",GetSys("esercizio")),
                    QHS.NullOrGe("stop",GetSys("esercizio")));

			int count = Conn.RUN_SELECT_COUNT("sortingview",newfilter, true);
			if (count==1) return R;
			return null;
		}

		protected override Form GetForm(string FormName)
		{

			if (FormName=="tree")
			{
				Name= "Selezione classificazione";
				ActAsList();                
				IsTree=true;
				return MetaData.GetFormByDllName("sortingview_tree");//PinoRana
			}

			return null;
		}
        
        public override void DescribeColumns(DataTable T, string ListingType) {
            base.DescribeColumns(T, ListingType);
            if (ListingType == "default") {                
                    base.DescribeColumns(T, ListingType);
                    foreach (DataColumn C in T.Columns)
                        DescribeAColumn(T, C.ColumnName, "",-1);
                    DescribeAColumn(T, "sortcode", "Codice",1);
                    DescribeAColumn(T, "description", "Denominazione",2);                
            }
            base.DescribeColumns(T, ListingType);
            if ((ListingType == "tree") || (ListingType == "treeall") || (ListingType == "tree5")) {              
                foreach (DataColumn C in T.Columns)
                    DescribeAColumn(T, C.ColumnName, "", -1);
                DescribeAColumn(T, "leveldescr", "Livello", 1);
                DescribeAColumn(T, "sortcode", "Codice", 2);
                DescribeAColumn(T, "description", "Denominazione", 3);
                DescribeAColumn(T, "movkind", "Tipo movimento", 4);
                DescribeAColumn(T, "printingorder", "Ordine stampa", 5);
            }
        }

	    public override string GetStaticFilter(string ListingType) {
	        int eserc = CfgFn.GetNoNullInt32(GetSys("esercizio"));
	        return QHS.NullOrEq("ayear", eserc);
	    }

	    public override void DescribeTree(TreeView tree, DataTable T, string ListingType)
		{
			//Aggiorno le intestazioni del DataGrid
			if (ListingType=="tree")
			{
				base.DescribeColumns(T, ListingType);
				foreach (DataColumn C in T.Columns)
					DescribeAColumn(T, C.ColumnName, "",-1);
				DescribeAColumn(T,"leveldescr","Livello",1);
				DescribeAColumn(T,"sortcode", "Codice",2);
				DescribeAColumn(T,"description","Denominazione",3);
			    DescribeAColumn(T, "movkind", "Tipo movimento",4);
			    DescribeAColumn(T, "printingorder", "Ordine stampa",5);
                DescribeAColumn(T, "incomeprevision", "Budget Ricavi",6);
                DescribeAColumn(T, "expenseprevision", "Budget Costi",7);
			}


            base.DescribeTree(tree, T, ListingType);
			string filterc=QHC.CmpEq("nlevel",1);
			string filtersql=QHS.CmpEq("nlevel",1);

            int eserc = CfgFn.GetNoNullInt32(GetSys("esercizio"));
            filterc = QHC.AppAnd(filterc, QHC.NullOrLe("start", eserc), QHC.NullOrGe("stop", eserc));
            filtersql = QHC.AppAnd(filtersql, QHS.NullOrLe("start", eserc), QHS.NullOrGe("stop", eserc));

			TreeViewManager M = new TreeViewClassMovimentiView(T, tree, filterc,filtersql);
		}
	}
    //--
    public class sorting_node_dispatcher : easy_node_dispatcher
    {

        public sorting_node_dispatcher(
            string level_table,
            string level_field,
            string descr_level_field,
            string selectable_level_field,
            string descr_field,
            string code_string
            )
            : base(level_table,
                    level_field,
                    descr_level_field,
                    selectable_level_field,
                    descr_field, code_string) { }

        override public tree_node GetNode(DataRow Parent, DataRow Child)
        {
            return new sorting_tree_node("sortinglevel", "nlevel",
                "description", null,
                "description", "sortcode", Child);
        }

    }

    public class sorting_tree_node : easy_tree_node
    {
        public sorting_tree_node(string level_table,
           string level_field,
           string descr_level_field,
           string selectable_level_field,
           string descr_field,
           string code_string,
           DataRow R)
            : base(level_table,
        descr_level_field,
        descr_level_field,
        selectable_level_field,
        descr_field,
        code_string,
        R)
        {
        }
        bool row_exists()
        {
            if (Row == null) return false;
            if (Row.RowState == DataRowState.Deleted) return false;
            if (Row.RowState == DataRowState.Detached) return false;
            return true;
        }
        /// <summary>
        /// True if "selectable" and with "no chidren"
        /// </summary>
        /// <returns></returns>
        override public bool CanSelect()
        {
            if (!row_exists()) return false;
            DataRow Lev = LevelRow();
            int flag = CfgFn.GetNoNullInt32(Lev["flag"]);
            if ((flag & 2) == 0) return false;
            if (HasAutoChildren()) return false;
            return true;
        }
    }
    //----
	public class TreeViewClassMovimentiView : TreeViewManager 
	{
		public TreeViewClassMovimentiView(DataTable T, TreeView tree, string filterc, string filtersql):
            base(T, tree, new sorting_node_dispatcher(
			"sortinglevel",
			"nlevel",
			"description",
			"flag",
			"description",
			"sortcode"                   
			),filterc, filtersql) {}


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
//			if (newroot[0].Nodes.Count>0) {
				tree.Nodes.Add(newroot[0]);
				newroot[0].Expand();
//			}
			AutoEventsEnabled=true;
		}		
	}
}
