
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
using metadatalibrary;
using metaeasylibrary;
using System.Windows.Forms;
using System.Data;
using funzioni_configurazione;
using HelpWeb;

namespace meta_sortingall { //meta_classmovimenti//
    /// <summary>
    /// Descrizione di riepilogo per classmovimenti.
    /// </summary>
    public class Meta_sortingall : Meta_easydata {
        public Meta_sortingall(DataAccess Conn, MetaDataDispatcher Dispatcher) :
            base(Conn, Dispatcher, "sortingall") {
            Name = "Classificazione Movimenti";
            ListingTypes.Add("tree");
            ListingTypes.Add("treenew");
            ListingTypes.Add("treeall");
            ListingTypes.Add("tree5");
            EditTypes.Add("tree");
        }


        protected override Form GetForm(string FormName) {
            switch (FormName) {
                case "treeall": {
                    Name = "Selezione voce di classificazione";
                    ActAsList();
                    IsTree = true;
                    return MetaData.GetFormByDllName("sortingall_tree");
                }
            }

            return null;
        }

        public override DataRow SelectByCondition(string filter, string searchtable) {
            filter = QHS.AppAnd(filter,
                QHS.NullOrLe("start", GetSys("esercizio")),
                QHS.NullOrGe("stop", GetSys("esercizio")));
            if (edit_type == "treeall") return base.SelectByCondition(filter, "sortingall");

            if (edit_type == "tree5") {
                filter = QHS.AppAnd(filter, QHS.CmpEq("nlevel", 5));
                return base.SelectByCondition(filter, "sortingview");
            }

            return base.SelectByCondition(filter, "sortingusable");
        }

        private string[] mykey = new string[] { "idsor"};
        public override string[] primaryKey() {
            return mykey;
        }

        public override void DescribeColumns(DataTable T, string ListingType) {
            base.DescribeColumns(T, ListingType);
            if ((ListingType == "tree") || (ListingType == "treeall") || (ListingType == "tree5")) {
                foreach (DataColumn C in T.Columns) {
                    DescribeAColumn(T, C.ColumnName, "");
                }

                DescribeAColumn(T, "sortcode", "Codice");
                DescribeAColumn(T, "description", "Descrizione");
                DescribeAColumn(T, "movkind", "Tipo movimento");
                DescribeAColumn(T, "printingorder", "Ordine stampa");
            }

            //			DescribeAColumn(T,"sortcode","Codice");
            //			DescribeAColumn(T,"description","Descrizione");
        }

        public override DataRow SelectOne(string ListingType, string filter, string searchtable, DataTable Exclude) {
           
            if (ListingType == "tree5") {
                filter = QHS.AppAnd(filter, QHS.CmpEq("nlevel", 5));
            }

            return base.SelectOne(ListingType, filter, "sortingall", Exclude);
        }


        public override void DescribeTree(TreeView tree, DataTable T, string ListingType) {
            base.DescribeTree(tree, T, ListingType);
            string filterc = QHC.CmpEq("nlevel", "1");
            string filtersql = QHS.CmpEq("nlevel", "1");
            if (ListingType != "history") {
                int eserc = CfgFn.GetNoNullInt32(GetSys("esercizio"));
                filterc = QHC.AppAnd(filterc, QHC.NullOrLe("start", eserc), QHC.NullOrGe("stop", eserc));
                filtersql = QHC.AppAnd(filtersql, QHS.NullOrLe("start", eserc), QHS.NullOrGe("stop", eserc));
            }
            int maxlevel = 0;
            string filterSortLevel = "";

            if (ListingType == "tree5") {
                maxlevel = 5;
                filterSortLevel = QHS.CmpLe("nlevel", maxlevel);
                myGetData.SetStaticFilter("sortinglevel", filterSortLevel);
            }

            bool all = false;
            if (ListingType == "treeall") {
                all = true;
            }
            TreeViewManager M = new TreeViewClassMovimenti(Conn, T, tree, filterc, filtersql, all, maxlevel);
        }

    }

    public class sortingall_node_dispatcher :easy_node_dispatcher {
        DataAccess Conn;
        int maxlevel;
        public sortingall_node_dispatcher(
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
            return new sortingall_tree_node("sortinglevel", "nlevel",
                "description", 
                "description", "sortcode", Child, maxlevel, Conn);
        }

    }

    public class sortingall_tree_node :easy_tree_node {
        //int levelop;
        DataAccess Conn;
        int maxlevel;
        public sortingall_tree_node(string level_table,
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



    public class TreeViewClassMovimenti :TreeViewManager {
        int maxlevel = 0;
        public TreeViewClassMovimenti(DataAccess Conn, DataTable T, TreeView tree, string filterc, string filtersql, bool all, int maxlevel) : //,int levelop):
            base(T, tree,
            (all ?
            new easy_node_dispatcher(
            "sortinglevel",
            "nlevel",
            "description",
            null,
            "description",
            "sortcode"
            ) :
            new sortingall_node_dispatcher(
            "sortinglevel",
            "nlevel",
            "description",
            "description",
            "sortcode",
            maxlevel, Conn
            )
            ), filterc, filtersql) {
            if (all) base.DoubleClickForSelect = false;
            this.maxlevel = maxlevel;
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
            TreeNode[] newroot = new TreeNode[1];
            newroot[0] = new TreeNode("Classificazione");
            if (tree.Nodes.Count > 0) {
                if (tree.Nodes[0].Tag == null) return;
            }

            while (tree.Nodes.Count > 0) {
                TreeNode X = tree.Nodes[0];
                tree.Nodes.RemoveAt(0);
                if (X.Tag == null) continue;
                DataRow R = ((tree_node)X.Tag).Row;
                newroot[0].Nodes.Add(X);
            }
            tree.Nodes.Add(newroot[0]);
            newroot[0].Expand();
            //			}
            AutoEventsEnabled = true;
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

