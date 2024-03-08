
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
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;
using metadatalibrary;
using metaeasylibrary;

namespace meta_flowchart {
    public class Meta_flowchart : Meta_easydata {
        int esercizio;
        public Meta_flowchart(DataAccess Conn, MetaDataDispatcher Dispatcher)
            :
                base(Conn, Dispatcher, "flowchart") {
            Name = "Organigramma";
            EditTypes.Add("default");
            EditTypes.Add("tree");
            EditTypes.Add("treeall");
            EditTypes.Add("applica");
            EditTypes.Add("applicaforall");
            ListingTypes.Add("tree");
            ListingTypes.Add("treeall");
            esercizio = Convert.ToInt32(GetSys("esercizio"));
        }

        protected override Form GetForm(string FormName) {
            switch (FormName) {
                case "default": {
                        Name = "Organigramma";
                        CanInsertCopy = false;
                        ActAsList();
                        IsTree = true;
                        DefaultListType = "default";
                        return MetaData.GetFormByDllName("flowchart_default");
                    }
                case "tree": {
                        Name = "Scelta del nodo";
                        ActAsList();
                        IsTree = true;
                        return GetFormByDllName("flowchart_tree");
                    }
                case "treeall": {
                        Name = "Scelta del nodo";
                        ActAsList();
                        IsTree = true;
                        return GetFormByDllName("flowchart_treeall");
                    }
                case "applica": {
                        Name = "Applica sicurezza";
                        return GetFormByDllName("flowchart_applica");
                    }
                case "applicaforall": {
                        Name = "Applica sicurezza su tutti i dipartimenti";
                        return GetFormByDllName("flowchart_applicaforall");
                    }

            }
            return null;
        }

        public override DataRow SelectByCondition(string filter, string searchtable) {
            if (edit_type == "treeall")
                return base.SelectByCondition(filter, "flowchart");
            int ResultCount = Conn.RUN_SELECT_COUNT("flowchartusable", filter, true);
            if (ResultCount != 1) return null;
            DataTable T2 = Conn.RUN_SELECT("flowchart", null, null, filter, null, true);
            if (T2 == null) return null;
            if (T2.Rows.Count == 0) return null;
            return CheckSelectRow(T2.Rows[0]);

        }

        override public void SetDefaults(DataTable Primary) {
            base.SetDefaults(Primary);
            string idprefix = esercizio.ToString().Substring(2, 2);
            SetDefault(Primary, "paridflowchart", idprefix);
            SetDefault(Primary, "ayear", esercizio);
        }

        override public DataRow Get_New_Row(DataRow ParentRow, DataTable T) {
            DataTable Levels = T.DataSet.Tables["flowchartlevel"];
            if (Levels == null) return null;
            int level;
            string codprefix;
            string ordinestampaprefix;
            if (ParentRow != null) {
                level = Convert.ToInt32(ParentRow["nlevel"]) + 1;
                codprefix = ParentRow["codeflowchart"].ToString();
                ordinestampaprefix = ParentRow["printingorder"].ToString();
            }
            else {
                level = 1;
                codprefix = "";
                ordinestampaprefix = "";
                SetDefault(T, "paridflowchart", GetSys("esercizio").ToString().Substring(2, 2));
            }
            if (level > (Levels.Rows.Count - 1)) {
                MetaFactory.factory.getSingleton<IMessageShower>().Show("Non è possibile inserire un livello inferiore a quello selezionato");
                return null;
            }
            string kind = "A"; //corresponding to "flagreset"
            DataRow[] levrow = Levels.Select("(nlevel=" + QueryCreator.quotedstrvalue(level, false) + ") AND " +
                "(ayear=" + QueryCreator.quotedstrvalue(esercizio, false) + ")");

            if (levrow.Length != 1) return null;

            SetDefault(T, "nlevel", level);

            RowChange.MarkAsAutoincrement(T.Columns["idflowchart"],
                "paridflowchart", null, 4);

            if (kind.ToLower() == "a") {
                SetDefault(T, "codeflowchart", codprefix);
                SetDefault(T, "printingorder", ordinestampaprefix);
            }

            DataRow R = base.Get_New_Row(ParentRow, T);
            if (kind.ToLower() == "a")
                RowChange.ClearAutoIncrement(T.Columns["printingorder"]);
            return R;
        }

        public override void DescribeColumns(DataTable T, string ListingType) {
            base.DescribeColumns(T, ListingType);
            if (ListingType == "tree" || ListingType == "treeall") {
                foreach (DataColumn C in T.Columns)
                    DescribeAColumn(T, C.ColumnName, "", -1);
                DescribeAColumn(T, "codeflowchart", "Codice", 1);
                DescribeAColumn(T, "title", "Denominazione", 2);
            }
        }


        public override DataRow SelectOne(string ListingType, string filter, string searchtable, DataTable Exclude) {
            if (ListingType == "default") {
                return base.SelectOne(ListingType, filter, "flowchartview", Exclude);
            }
            else {
                return base.SelectOne(ListingType, filter, "flowchart", Exclude);
            }
        }

        public override void DescribeTree(TreeView tree, DataTable T, string ListingType) {
            bool all = false;
            //Aggiorno le intestazioni del DataGrid
            if (ListingType == "tree" || ListingType == "treeall") {
                base.DescribeColumns(T, ListingType);
                foreach (DataColumn C in T.Columns)
                    DescribeAColumn(T, C.ColumnName, "");
                DescribeAColumn(T, "!livello", "Livello", "flowchartlevel.description");
                DescribeAColumn(T, "codeflowchart", "Codice");
                DescribeAColumn(T, "title", "Denominazione");
            }

            base.DescribeTree(tree, T, ListingType);
            int esercizio = Convert.ToInt32(GetSys("esercizio"));
            string filterc = QHC.CmpEq("nlevel","1");
            string filtersql = QHS.CmpEq("nlevel","1");
            int maxlevel = 0;
            object o = Conn.DO_READ_VALUE("flowchartlevel", "(ayear = '" + Conn.GetSys("esercizio") + "')", "max(nlevel)");
            if ((o != null) && (o != DBNull.Value)) maxlevel = Convert.ToInt32(o);

            if (ListingType == "treeall") {
                all = true;
            }

            TreeViewFlowChart M = new TreeViewFlowChart(Conn, T, tree, filterc,filtersql, all, maxlevel);
            myGetData.SetStaticFilter("flowchartlevel", QHS.CmpEq("ayear", esercizio));
        }

        public override bool IsValid(DataRow R, out string errmess, out string errfield) {
            if (!base.IsValid(R, out errmess, out errfield))
                return false;
            if (R.RowState != DataRowState.Added) return true;
            return true;
        }
    }

    //alla classe base viene passato nel primo caso (parametro all = true)
    //un node_dispatcher che consente di selezionare anche nodi non operativi
    public class TreeViewFlowChart : TreeViewManager {
        public TreeViewFlowChart(DataAccess Conn, DataTable T, TreeView tree, string filterc, string filtersql,
            bool all, int maxlevel)
            :
            base(T, tree,
                all ? new easy_node_dispatcher(
            "flowchartlevel",
            "nlevel",
            "description",
            null,
            "title",
            "codeTreeViewFlowChart")
            : new flowchart_node_dispatcher(
            "TreeViewFlowChartlevel",
            "nlevel",
            "description",
            "flagusable",
            "title",
            "codeflowchart", maxlevel, Conn)
            , filterc,filtersql 
            ) {
            //se all vale true disabilito il doppio click come selezione
            if (all) base.DoubleClickForSelect = false;
        }

        override public TreeNode AddNode(TreeNodeCollection Nodes, TreeNode NewNode) {
            if (Nodes.Equals(tree.Nodes) && (NewNode.Tag != null)) {
                //searches the right node into which do the additon
                //DataRow R = ((tree_node) NewNode.Tag).Row;
                foreach (TreeNode N in Nodes) {
                    if (N.Text == "Organigramma") {
                        return base.AddNode(N.Nodes, NewNode);
                    }
                }
            }
            return base.AddNode(Nodes, NewNode);
        }

        public override void FillNodes() {
            base.FillNodes();
            AutoEventsEnabled = false;

            if (tree.Nodes.Count > 0) {
                if (tree.Nodes[0].Tag == null) return;
            }
            TreeNode newroot = new TreeNode("Organigramma");

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

    public class flowchart_tree_node : easy_tree_node {
        DataAccess Conn;
        int maxlevel;
        public flowchart_tree_node(string level_table,
            string level_field,
            string descr_level_field,
            string selectable_level_field,
            string descr_field,
            string code_string,
            DataRow R,
            int maxlevel,
            DataAccess Conn
            )
            : base(level_table,
            descr_level_field,
            descr_level_field,
            selectable_level_field,
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
            if (maxlevel > 0) {
                if (Lev["nlevel"].ToString() == maxlevel.ToString()) return true;
            }
            if (Lev["flagusable"].ToString().ToLower() == "n") return false;
            if (HasAutoChildren()) return false;
            string filter = "(idflowchart LIKE '" + Row["idflowchart"] + "%')";
            int ResultCount = Conn.RUN_SELECT_COUNT("flowchartusable", filter, true);
            if (ResultCount != 1) return false;
            return true;
        }
    }

    public class flowchart_node_dispatcher : easy_node_dispatcher {
        DataAccess Conn;
        int maxlevel;
        public flowchart_node_dispatcher(
            string level_table,
            string level_field,
            string descr_level_field,
            string selectable_level_field,
            string descr_field,
            string code_string,
            int maxlevel,
            DataAccess Conn
            )
            : base(level_table,
            level_field,
            descr_level_field,
            selectable_level_field,
            descr_field, code_string) {
            this.maxlevel = maxlevel;
            this.Conn = Conn;
        }

        override public tree_node GetNode(DataRow Parent, DataRow Child) {
            return new flowchart_tree_node("flowchartlevel", "nlevel",
                "description", "flagusable",
                "title", "codeflowchart", Child, maxlevel, Conn);
        }

    }
}
