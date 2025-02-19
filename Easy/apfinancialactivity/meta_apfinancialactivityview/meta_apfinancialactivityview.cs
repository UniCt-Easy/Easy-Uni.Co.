
/*
Easy
Copyright (C) 2024 Universit� degli Studi di Catania (www.unict.it)
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
using apfinancialactivityview_tree;
using System.Windows.Forms;
using System.Data;
using funzioni_configurazione;

namespace meta_apfinancialactivityview{
    public class Meta_apfinancialactivityview : Meta_easydata{
        public Meta_apfinancialactivityview(DataAccess Conn, MetaDataDispatcher Dispatcher)
            :
            base(Conn, Dispatcher, "apfinancialactivityview"){
            Name = "Attivit� Economica";
            EditTypes.Add("tree");
            ListingTypes.Add("tree");
            ListingTypes.Add("default");

            EditTypes.Add("treeall");
            ListingTypes.Add("treeall");
        }

        protected override Form GetForm(string FormName)
        {
            if (FormName == "tree"){
                Name = "Attivit� Economica";
                ActAsList();
                IsTree = true;
                Frm_apfinancialactivityview_tree F = new Frm_apfinancialactivityview_tree();
                F.tree.Tag = "apfinancialactivityview.tree";
                return F;
            }
            if (FormName == "treeall"){
                Name = "Attivit� Economica";
                ActAsList();
                IsTree = true;
                Frm_apfinancialactivityview_tree F = new Frm_apfinancialactivityview_tree();
                F.tree.Tag = "apfinancialactivityview.treeall";
                return F;
            }
            return null;
        }

        public override void DescribeColumns(DataTable T, string ListingType){
            base.DescribeColumns(T, ListingType);

            if (ListingType == "default")
            {
                foreach (DataColumn C in T.Columns)
                    DescribeAColumn(T, C.ColumnName, "");

                DescribeAColumn(T, "apfinancialactivitycode", "Codice");
                DescribeAColumn(T, "description", "Denominazione");
            }
        }

        public override void DescribeTree(TreeView tree, DataTable T, string ListingType)
        {
            bool all = false;
            base.DescribeTree(tree, T, ListingType);
            //Aggiorno le intestazioni del DataGrid
            if (ListingType == "tree"){
                base.DescribeColumns(T, ListingType);
                foreach (DataColumn C in T.Columns)
                    DescribeAColumn(T, C.ColumnName, "");
                DescribeAColumn(T, "leveldescr", "Livello");
                DescribeAColumn(T, "apfinancialactivitycode", "Codice");
                DescribeAColumn(T, "description", "Descrizione");
            }

            if (ListingType == "treeall"){
                base.DescribeColumns(T, ListingType);
                foreach (DataColumn C in T.Columns)
                    DescribeAColumn(T, C.ColumnName, "");
                DescribeAColumn(T, "leveldescr", "Livello");
                DescribeAColumn(T, "apfinancialactivitycode", "Codice");
                DescribeAColumn(T, "description", "Descrizione");
                all = true;
            }

            string filterc = QHC.CmpEq("nlevel", 1);
            string filtersql = QHS.CmpEq("nlevel", 1);
            TreeViewManager M = new TreeAttivitaEconomicaView(T, tree, filterc, filtersql, all);
        }

        public override DataRow SelectByCondition(string filter, string searchtable)
        {
            return base.SelectByCondition(filter, "apfinancialactivityusable");
        }

    }

    public class TreeAttivitaEconomicaView : TreeViewManager
    {
        public TreeAttivitaEconomicaView(DataTable T, TreeView tree, string filterc, string filtersql, bool all)
            :
            base(T, tree,
            (all ? new easy_node_dispatcher(
            "apfinancialactivitylevel",
            "nlevel",
            "description",
            null,
            "description",
            "apfinancialactivitycode"
            ) : (new apfinancialactivityview_node_dispatcher(
            "apfinancialactivitylevel",
            "nlevel",
            "description",
            null,
            "description",
            "apfinancialactivitycode"
            ))), filterc, filtersql)
        {

            //se all vale true disabilito il doppio click come selezione
            if (all) base.DoubleClickForSelect = false;
        }

        override public TreeNode AddNode(TreeNodeCollection Nodes, TreeNode NewNode)
        {
            if (Nodes.Equals(tree.Nodes) && (NewNode.Tag != null) && (tree.Nodes.Count > 0))
            {
                if (tree.Nodes[0].Tag == null) return base.AddNode(tree.Nodes[0].Nodes, NewNode);
            }
            return base.AddNode(Nodes, NewNode);
        }

        public override void FillNodes()
        {

            base.FillNodes();
            AutoEventsEnabled = false;
            TreeNode[] newroot = new TreeNode[1];
            newroot[0] = new TreeNode("Attivit�");
            if (tree.Nodes.Count > 0)
            {
                if (tree.Nodes[0].Tag == null) return;
            }

            while (tree.Nodes.Count > 0)
            {
                TreeNode X = tree.Nodes[0];
                tree.Nodes.RemoveAt(0);
                if (X.Tag == null) continue;
                DataRow R = ((tree_node)X.Tag).Row;
                newroot[0].Nodes.Add(X);
            }
            tree.Nodes.Add(newroot[0]);
            newroot[0].Expand();

            AutoEventsEnabled = true;
        }
    }


    public class apfinancialactivityview_node_dispatcher : easy_node_dispatcher
    {

        public apfinancialactivityview_node_dispatcher(
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
            return new apfinancialactivityview_tree_node("apfinancialactivitylevel", "nlevel",
                "description", null,
                "description", "apfinancialactivitycode", Child);
        }

    }

    public class apfinancialactivityview_tree_node : easy_tree_node
    {
        public apfinancialactivityview_tree_node(string level_table,
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
            //if (selectable_level_field == null) return true;
            DataRow Lev = LevelRow();
            //if (Lev[selectable_level_field].ToString().ToLower() == "n") return false;
            byte flag = CfgFn.GetNoNullByte(Lev["flag"]);
            if ((flag & 2) == 0) return false;
            if (HasAutoChildren()) return false;
            return true;
        }
    }

}

