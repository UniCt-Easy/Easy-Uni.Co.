
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
using metaeasylibrary;
using metadatalibrary;
using locationview_tree;//UbicazioneViewTree
using System.Windows.Forms;
using System.Data;
using funzioni_configurazione;
using HelpWeb;

namespace meta_locationview{//meta_ubicazioneview//
	/// <summary>
	/// Summary description for /*Rana:meta_ubicazioneview.*/
	/// </summary>
	public class Meta_locationview : Meta_easydata	{
		public Meta_locationview(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "locationview") {		
		
			Name="Ubicazione";
			EditTypes.Add("tree");
			ListingTypes.Add("tree");
			ListingTypes.Add("default");
			//edittype per la selezioni di voci anche non operative
			EditTypes.Add("treeall");
			ListingTypes.Add("treeall");
		}

		protected override Form GetForm(string FormName) {
			if (FormName=="tree"){
				Name= "Selezione ubicazione";
				ActAsList();                
				IsTree=true;
			    return GetFormByDllName("locationview_tree");
			}
			if (FormName=="treeall"){
				Name= "Selezione ubicazione";
				ActAsList();                
				IsTree=true;
                return GetFormByDllName("locationview_tree");
            }
            return null;
		}

        private string[] mykey = new string[] { "idlocation" };
        public override string[] primaryKey() {
            return mykey;
        }
		public override void DescribeColumns(DataTable T, string ListingType) {
			base.DescribeColumns (T, ListingType);

			if (ListingType=="default") {
				foreach (DataColumn C in T.Columns)
					DescribeAColumn(T,C.ColumnName, "");

				DescribeAColumn(T,"locationcode","Codice");
				DescribeAColumn(T,"description","Denominazione");
				DescribeAColumn(T,"manager","Responsabile");
			}
		}

		public override void DescribeTree(TreeView tree, DataTable T, string ListingType) {
			bool all=false;
			base.DescribeTree(tree, T, ListingType);
			//Aggiorno le intestazioni del DataGrid
			if (ListingType=="tree") {
				base.DescribeColumns(T, ListingType);
				foreach (DataColumn C in T.Columns)
					DescribeAColumn(T, C.ColumnName, "");
				DescribeAColumn(T,"leveldescr","Livello");
				DescribeAColumn(T,"locationcode", "Codice");
				DescribeAColumn(T,"description","Descrizione");
				DescribeAColumn(T,"manager","Responsabile");
			}			

			if (ListingType=="treeall") {
				base.DescribeColumns(T, ListingType);
				foreach (DataColumn C in T.Columns)
					DescribeAColumn(T, C.ColumnName, "");
				DescribeAColumn(T,"leveldescr","Livello");
				DescribeAColumn(T,"locationcode", "Codice");
				DescribeAColumn(T,"description","Descrizione");
				DescribeAColumn(T,"manager","Responsabile");
				all=true;
			}

            string filterc = QHC.CmpEq("nlevel", 1);
            string filtersql = QHS.CmpEq("nlevel", 1);
            //			if (ListingType=="tree"){
            TreeViewManager M = new TreeUbicazioneView(T, tree, filterc,filtersql, all);
		}



        public override void WebDescribeTree(hwTreeView tree, DataTable T, string ListingType) {
            int maxDepth = 9; bool withdescr = true;

            if (ListingType == "default") {
                base.DescribeColumns(T, ListingType);
                foreach (DataColumn C in T.Columns)
                    DescribeAColumn(T, C.ColumnName, "");
                DescribeAColumn(T, "idlocation", "Id Ubicazione");
                DescribeAColumn(T, "locationcode", "Codice Ubicazione");
                DescribeAColumn(T, "description", "Ubicazione");
            }

            base.WebDescribeTree(tree, T, ListingType);
            string filterc = QHC.CmpEq("nlevel", 1);
            string filtersql = QHS.CmpEq("nlevel", 1);
            easy_node_dispatcher D = new locationview_node_dispatcher(
                "locationlevel",
                "nlevel",
                "description",
                null,
                "description",
                "locationcode"
                );
            WebTreeViewLocation M = new WebTreeViewLocation(T, tree, filterc, filtersql, maxDepth, withdescr);

        }
        

        public override DataRow SelectByCondition(string filter, string searchtable) {
			return base.SelectByCondition (filter, "locationusable");
		}

	}

	public class TreeUbicazioneView:TreeViewManager {
		public TreeUbicazioneView(DataTable T, TreeView tree, string filterc, string filtersql, bool all):               
			base(T,tree, 
			(all?new easy_node_dispatcher(
			"locationlevel",
			"nlevel",
			"description",
			null,
			"description",
			"locationcode"
            ) : (new locationview_node_dispatcher(
			"locationlevel",
			"nlevel",
			"description",
			null,
			"description",
			"locationcode"                   
			))),filterc,filtersql) {

			//se all vale true disabilito il doppio click come selezione
			if (all) base.DoubleClickForSelect=false;
		}

		override public TreeNode AddNode(TreeNodeCollection Nodes, TreeNode NewNode) {
			if (Nodes.Equals(tree.Nodes) && (NewNode.Tag!=null)&& (tree.Nodes.Count>0)) {
				if (tree.Nodes[0].Tag==null) return base.AddNode(tree.Nodes[0].Nodes, NewNode);
			}
			return base.AddNode(Nodes,NewNode);
		}

		public override void FillNodes() {

			base.FillNodes();
			AutoEventsEnabled=false;
			TreeNode [] newroot= new TreeNode[1];
			newroot[0]= new TreeNode("Ubicazione");
			if (tree.Nodes.Count>0) {
				if (tree.Nodes[0].Tag==null) return;
			}

			while (tree.Nodes.Count>0) {
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


    public class locationview_node_dispatcher : easy_node_dispatcher {

        public locationview_node_dispatcher(
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

        override public tree_node GetNode(DataRow Parent, DataRow Child) {
            return new locationview_tree_node("locationlevel", "nlevel",
                "description", null,
                "description", "locationcode", Child);
        }

    }

    public class locationview_tree_node : easy_tree_node {
        public locationview_tree_node(string level_table,
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
        R) {
        }
        bool row_exists() {
            if (Row == null) return false;
            if (Row.RowState == DataRowState.Deleted) return false;
            if (Row.RowState == DataRowState.Detached) return false;
            return true;
        }
        /// <summary>
        /// True if "selectable" and with "no chidren"
        /// </summary>
        /// <returns></returns>
        override public bool CanSelect() {
            if (!row_exists()) return false;
            //if (selectable_level_field == null) return true;
            DataRow Lev = LevelRow();
            //if (Lev[selectable_level_field].ToString().ToLower() == "n") return false;
            byte flag = CfgFn.GetNoNullByte(Lev["flag"]);
            if ((flag & 2) == 0) return false;
            if (HasAutoChildren()) return false;
            return true;
        }
    }




    public class WebTreeViewLocation :hwTreeViewManager {
        public WebTreeViewLocation(DataTable T, hwTreeView tree, string filterc, string filtersql, int maxlevel, bool withdescr)
            :
            base(T, tree,
            (withdescr ? new easy_node_dispatcher(null, null, null, null, "description", "locationcode") :
                              new location_node_dispatcher("description", "locationcode")
            ), filterc, filtersql) {
            base.DoubleClickForSelect = false;
        }
    }

    public class location_node_dispatcher :easy_node_dispatcher {
        public location_node_dispatcher(string descr_field,
            string code_string)
            : base(null, null, null, null, descr_field, code_string) {
        }

        override public tree_node GetNode(DataRow Parent, DataRow Child) {
            return new location_tree_node("description", "locationcode", Child);
        }

    }


    public class location_tree_node :easy_tree_node {
        public location_tree_node(string descr_field, string code_string, DataRow R)
            : base(null, null, null, null, descr_field, code_string, R) {

        }

        bool row_exists() {
            if (Row == null) return false;
            if (Row.RowState == DataRowState.Deleted) return false;
            if (Row.RowState == DataRowState.Detached) return false;
            return true;
        }

        override public string Text() {
            string S = "";
            if (!row_exists()) return S;
            S = Row["locationcode"].ToString();
            return S;

        }

    }

}

