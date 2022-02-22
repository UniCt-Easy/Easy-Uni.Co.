
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
using System.Windows.Forms;
using metadatalibrary;
using metaeasylibrary;
using System.Data;
using funzioni_configurazione;

namespace meta_apfinancialactivity
{
    public class Meta_apfinancialactivity : Meta_easydata
    {
        public Meta_apfinancialactivity(DataAccess Conn, MetaDataDispatcher Dispatcher)
            :
            base(Conn, Dispatcher, "apfinancialactivity")
        {
            EditTypes.Add("default");
            ListingTypes.Add("default");
        }

        public override void SetDefaults(DataTable PrimaryTable)
        {
            base.SetDefaults(PrimaryTable);
            SetDefault(PrimaryTable, "active", "S");
        }

        protected override Form GetForm(string FormName)
        {
            if (FormName == "default")
            {
                Name = "Attività Economica";
                CanInsertCopy = false;
                ActAsList();
                IsTree = true;
                DefaultListType = "default";
                return MetaData.GetFormByDllName("apfinancialactivity_default");
            }
            return null;
        }

        override public DataRow Get_New_Row(DataRow ParentRow, DataTable T)
        {
            DataTable Levels = T.DataSet.Tables["apfinancialactivitylevel"];
            if (Levels == null) return null;
            bool linear = false;
            int level;
            string codprefix;
            if (ParentRow != null)
            {
                level = Convert.ToInt32(ParentRow["nlevel"]) + 1;
                codprefix = ParentRow["apfinancialactivitycode"].ToString();
            }
            else
            {
                level = 1;
                codprefix = "";
            }
            int levelmax = CfgFn.GetNoNullInt32(Levels.Compute("max(nlevel)", null));
            if (level > levelmax)
            {
                MetaFactory.factory.getSingleton<IMessageShower>().Show("Non è possibile inserire un livello inferiore a quello selezionato");
                return null;
            }
            int len = 6;
            //string kind = "A";
            DataRow[] levrow = Levels.Select("(nlevel=" + QueryCreator.quotedstrvalue(level, false) + ")");

            if (levrow.Length != 1) return null;

            len = Convert.ToInt32(levrow[0]["codelen"].ToString());
            int flag = CfgFn.GetNoNullInt32(levrow[0]["flag"]);
            bool usable = ((flag & 2) != 0);
            bool numerico = ((flag & 1) == 0);
            bool alfanumerico = ((flag & 1) != 0);
            bool restart = ((flag & 4) != 0);

            if (!restart)
            {
                linear = true;
            }

            T.Columns["apfinancialactivitycode"].ExtendedProperties["length"] = codprefix.Length + len;

            SetDefault(T, "nlevel", level);

            RowChange.MarkAsAutoincrement(T.Columns["idapfinancialactivity"], null, null, 10);

            if (alfanumerico)
            {
                SetDefault(T, "apfinancialactivitycode", codprefix);
                RowChange.ClearAutoIncrement(T.Columns["apfinancialactivitycode"]);
            }
            else
            {
                RowChange.MarkAsAutoincrement(T.Columns["apfinancialactivitycode"],
                    null, codprefix, len, linear);
            }
            return base.Get_New_Row(ParentRow, T);
        }

        public override DataRow SelectOne(string ListingType, string filter, string searchtable, DataTable ToMerge)
        {
            if (ListingType == "default")
                return base.SelectOne(ListingType, filter, "apfinancialactivityview", ToMerge);

            return base.SelectOne(ListingType, filter, searchtable, ToMerge);
        }

        public override bool IsValid(DataRow R, out string errmess, out string errfield)
        {
            if (!base.IsValid(R, out errmess, out errfield))
                return false;
            if (R.RowState != DataRowState.Added) return true;
            int lunghezza = (int)PrimaryDataTable.Columns["apfinancialactivitycode"].ExtendedProperties["length"];
            if (R["apfinancialactivitycode"].ToString().Length != lunghezza)
            {
                errmess = "Attenzione! Il campo 'Codice' deve avere lunghezza " + lunghezza + ".";
                errfield = "apfinancialactivitycode";
                return false;
            }
            return true;
        }

        public override void DescribeTree(TreeView tree, DataTable T, string ListingType)
        {
            base.DescribeTree(tree, T, ListingType);
            string filterc = QHC.CmpEq("nlevel", 1);
            string filtersql = QHS.CmpEq("nlevel", 1);
            easy_node_dispatcher D = new apfinancialactivity_node_dispatcher(
                "apfinancialactivitylevel",
                "nlevel",
                "description",
                null,
                "description",
                "apfinancialactivitycode"
                );
            TreeViewManager M = new TreeViewClassInventario(T, tree, filterc, filtersql);

        }
    }

    public class TreeViewClassInventario : TreeViewManager
    {
        public TreeViewClassInventario(DataTable T, TreeView tree, string filterc, string filtersql)
            :
            base(T, tree, new easy_node_dispatcher(
            "apfinancialactivitylevel",
            "nlevel",
            "description",
            null,
            "description",
            "apfinancialactivitycode"
            ), filterc, filtersql) { }

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
            newroot[0] = new TreeNode("Attività Economica");
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


    public class apfinancialactivity_node_dispatcher : easy_node_dispatcher
    {

        public apfinancialactivity_node_dispatcher(
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
            return new apfinancialactivity_tree_node("apfinancialactivitylevel", "nlevel",
                "description", null,
                "description", "apfinancialactivitycode", Child);
        }

    }

    public class apfinancialactivity_tree_node : easy_tree_node
    {
        public apfinancialactivity_tree_node(string level_table,
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
            byte flag = CfgFn.GetNoNullByte(Lev["flag"]);
            if ((flag & 2) == 0) return false;
            if (HasAutoChildren()) return false;
            return true;
        }
    }

}
