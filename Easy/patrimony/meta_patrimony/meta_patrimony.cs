
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
using patrimony_tree;



namespace meta_patrimony
{
    /// <summary>
    /// Summary description for meta_patrimony.
    /// </summary>
    public class Meta_patrimony : Meta_easydata {
        int esercizio;

        public Meta_patrimony(DataAccess Conn, MetaDataDispatcher Dispatcher) :
            base(Conn, Dispatcher, "patrimony") {
            EditTypes.Add("default");
            EditTypes.Add("tree");
            EditTypes.Add("tree_all");
            EditTypes.Add("treea");
            EditTypes.Add("treep");
            EditTypes.Add("treep_all");
            EditTypes.Add("treeanew");
            EditTypes.Add("treepnew");
            EditTypes.Add("treepnew_all");
            ListingTypes.Add("default");
            ListingTypes.Add("tree");
            ListingTypes.Add("treea");
            ListingTypes.Add("treep");
            ListingTypes.Add("treeanew");
            ListingTypes.Add("treepnew");
            ListingTypes.Add("checkimport");
            Name = "Stato Patrimoniale";
            esercizio = Convert.ToInt32(GetSys("esercizio"));
        }

        public override bool CanSelect(DataRow R) {
            return DataAccess.CanSelect(Conn, R);
        }

        protected override Form GetForm(string FormName) {
            if (FormName == "default") {
                Name = "Stato Patrimoniale annuale";
                CanInsertCopy = false;
                ActAsList();
                IsTree = true;
                DefaultListType = "default";
                return MetaData.GetFormByDllName("patrimony_default");
            }

            if (FormName == "tree") {
                Name = "Scelta dello Stato Patrimoniale";
                ActAsList();
                IsTree = true;
                return GetFormByDllName("patrimony_tree");
            }

            if (FormName == "tree_all") {
                Name = "Scelta dello Stato Patrimoniale";
                ActAsList();
                IsTree = true;
                Frm_patrimony_tree F = new Frm_patrimony_tree();
                F.tree.Tag = "patrimony." + FormName;
                return F;
            }

            if (FormName == "treea" || FormName == "treeanew") {
                Name = "Scelta dello Stato Patrimoniale";
                DefaultListType = FormName;
                ActAsList();
                IsTree = true;
                Frm_patrimony_tree F = new Frm_patrimony_tree();
                F.tree.Tag = "patrimony." + FormName;
                return F;
            }

            if (FormName == "treep" || FormName == "treepnew") {
                Name = "Scelta dello Stato Patrimoniale";
                DefaultListType = FormName;
                ActAsList();
                IsTree = true;
                Frm_patrimony_tree F = new Frm_patrimony_tree();
                F.tree.Tag = "patrimony." + FormName;
                return F;
            }

            return null;
        }

        override public void SetDefaults(DataTable Primary) {
            base.SetDefaults(Primary);
            string idprefix = esercizio.ToString().Substring(2, 2);
            SetDefault(Primary, "paridpatrimony", idprefix);
            SetDefault(Primary, "ayear", esercizio);
            SetDefault(Primary, "active", "S");
        }

        public override DataRow SelectOne(string ListingType, string filter, string searchtable, DataTable Exclude) {
            if (ListingType == "default") {
                return base.SelectOne(ListingType, filter, "patrimonyview", Exclude);
            }
            else {
                return base.SelectOne(ListingType, filter, "patrimony", Exclude);
            }
        }

        public override void DescribeColumns(DataTable T, string ListingType) {
            base.DescribeColumns(T, ListingType);
            if (ListingType == "checkimport") {
                foreach (DataColumn C in T.Columns)
                    DescribeAColumn(T, C.ColumnName, "", -1);
                int nPos = 1;
                DescribeAColumn(T, "ayear", "Esercizio", nPos++);
                DescribeAColumn(T, "codepatrimony", "Codice", nPos++);
                DescribeAColumn(T, "title", "Denominazione", nPos++);
            }
        }

        public override void DescribeTree(TreeView tree, DataTable T, string ListingType) {
            int maxlev = 0;

            //Aggiorno le intestazioni del DataGrid
            if (ListingType == "treeap" || ListingType == "tree" || ListingType == "treea" || ListingType == "treep" ||
                ListingType == "treeanew" || ListingType == "treepnew"
                ||ListingType == "tree_all" ||ListingType == "treep_all" ||ListingType == "treepnew_all" 
                ) {
                base.DescribeColumns(T, ListingType);
                foreach (DataColumn C in T.Columns)
                    DescribeAColumn(T, C.ColumnName, "", -1);
                DescribeAColumn(T, "!livello", "Livello", "patrimonylevel.description", 1);
                DescribeAColumn(T, "codepatrimony", "Codice", 2);
                DescribeAColumn(T, "title", "Denominazione", 3);
            }

            base.DescribeTree(tree, T, ListingType);
            int esercizio = Convert.ToInt32(GetSys("esercizio"));
            int esercizionew = esercizio + 1;
            string filteresercizio = QHS.CmpEq("ayear", GetSys("esercizio"));
            string filterc = QHC.CmpEq("nlevel", "1");
            string filtersql = QHS.CmpEq("nlevel", "1");
            string kind = "AP";
            bool all = false;
            bool allLevel = false;

            if (ListingType == "treeap") {
                //filter="(nlevel='1')";
                kind = "AP";
            }

            if (ListingType == "tree") {
                //filter="(nlevel='1')";
                kind = "AP";
            }
            if (ListingType == "tree_all") {
                //filter="(nlevel='1')";
                kind = "AP";
                allLevel = true;
            }
           
            

            if (ListingType == "treea") {
                string livsupid = esercizio.ToString().Substring(2) + "A";
                //filter = "(paridpatrimony=" + QueryCreator.quotedstrvalue(livsupid, true) + ")";
                filterc = QHC.CmpEq("paridpatrimony", livsupid);
                filtersql = QHS.CmpEq("paridpatrimony", livsupid);
                kind = "A";
                all = true;
            }

            if (ListingType == "treep") {
                string livsupid = esercizio.ToString().Substring(2) + "P";
                filterc = QHC.CmpEq("paridpatrimony", livsupid);
                filtersql = QHS.CmpEq("paridpatrimony", livsupid);
                kind = "P";
                all = true;
            }

            if (ListingType == "treep_all") {
                string livsupid = esercizio.ToString().Substring(2) + "P";
                filterc = QHC.CmpEq("paridpatrimony", livsupid);
                filtersql = QHS.CmpEq("paridpatrimony", livsupid);
                kind = "P";
                all = true;
                allLevel = true;
            }

            if (ListingType == "treeanew") {
                string livsupid = esercizionew.ToString().Substring(2) + "A";
                filterc = QHC.CmpEq("paridpatrimony", livsupid);
                filtersql = QHS.CmpEq("paridpatrimony", livsupid);
                kind = "A";
                filteresercizio = QHS.CmpEq("ayear", esercizionew);
                all = true;
            }

            if (ListingType == "treepnew") {
                string livsupid = esercizionew.ToString().Substring(2) + "P";
                filterc = QHC.CmpEq("paridpatrimony", livsupid);
                filtersql = QHS.CmpEq("paridpatrimony", livsupid);
                kind = "P";
                filteresercizio = QHS.CmpEq("ayear", esercizionew);
                all = true;
            }

            if (ListingType == "treepnew_all") {
                string livsupid = esercizionew.ToString().Substring(2) + "P";
                filterc = QHC.CmpEq("paridpatrimony", livsupid);
                filtersql = QHS.CmpEq("paridpatrimony", livsupid);
                kind = "P";
                filteresercizio = QHS.CmpEq("ayear", esercizionew);
                all = true;
            }

            object o = Conn.DO_READ_VALUE("patrimonylevel", filteresercizio, "max(nlevel)");
            if ((o != null) && (o != DBNull.Value)) maxlev = Convert.ToInt32(o);

            if (maxlev > 0) {
                myGetData.SetStaticFilter("patrimony", QHS.AppAnd(filteresercizio, QHS.CmpLe("nlevel", maxlev)));
                //myGetData.SetStaticFilter("patrimonyview", QHS.AppAnd(filteresercizio, QHS.CmpLe("nlevel", maxlev)));
            }

            TreeViewPatrimoniale M = new TreeViewPatrimoniale(T, tree, filterc, filtersql, kind, all, maxlev,allLevel);

            myGetData.SetStaticFilter("patrimonylevel", filteresercizio);
        }

        override public DataRow Get_New_Row(DataRow ParentRow, DataTable T) {
            DataTable Levels = T.DataSet.Tables["patrimonylevel"];
            if (Levels == null) return null;
            int level;
            string partepatrimoniale;
            string codprefix;
            string ordinestampaprefix;
            if (ParentRow != null) {
                level = Convert.ToInt32(ParentRow["nlevel"]) + 1;
                codprefix = ParentRow["codepatrimony"].ToString();
                ordinestampaprefix = ParentRow["printingorder"].ToString();
                partepatrimoniale = ParentRow["patpart"].ToString();
                SetDefault(T, "patpart", partepatrimoniale);
            }
            else {
                level = 1;
                codprefix = "";
                ordinestampaprefix = "";
                partepatrimoniale = T.Columns["patpart"].DefaultValue.ToString();
                SetDefault(T, "paridpatrimony", GetSys("esercizio").ToString().Substring(2, 2) + partepatrimoniale);
            }

            if (level > (Levels.Rows.Count - 1)) {
                //MetaFactory.factory.getSingleton<IMessageShower>() .Show("Non è possibile inserire un livello inferiore a quello selezionato");
                return null;
            }

            string kind = "A"; //corresponding to "flagreset"

            if (kind.ToLower() == "a") {
                SetDefault(T, "codepatrimony", codprefix);
                SetDefault(T, "printingorder", ordinestampaprefix);
            }

            SetDefault(T, "nlevel", level);

            RowChange.MarkAsAutoincrement(T.Columns["idpatrimony"], "paridpatrimony", null, 4);

            DataRow R = base.Get_New_Row(ParentRow, T);
            return R;
        }


        public override bool IsValid(DataRow R, out string errmess, out string errfield) {
            if (!base.IsValid(R, out errmess, out errfield))
                return false;
            if (R.RowState != DataRowState.Added) return true;
            return true;
        }

        public class patrimoniale_node_dispatcher : easy_node_dispatcher {
            int maxlevel;
            private bool allLevel;
            public patrimoniale_node_dispatcher(
                string level_table,
                string level_field,
                string descr_level_field,
                string selectable_level_field,
                string descr_field,
                string code_string,
                int maxlevel,
                bool allLevel
            ) : base(level_table,
                level_field,
                descr_level_field,
                selectable_level_field,
                descr_field, code_string) {
                this.maxlevel = maxlevel;
                this.allLevel=allLevel;
            }

            override public tree_node GetNode(DataRow Parent, DataRow Child) {
                return new patrimoniale_tree_node("patrimonylevel", "nlevel",
                    "description", "flagusable",
                    "title", "codepatrimony", Child, maxlevel,allLevel);
            }
        } // class patrimoniale_node_dispatcher


        public class patrimoniale_tree_node : easy_tree_node {
            int maxlevel;
            public bool allSelectable = false;

            public patrimoniale_tree_node(string level_table,
                string level_field,
                string descr_level_field,
                string selectable_level_field,
                string descr_field,
                string code_string,
                DataRow R,
                int maxlevel,
                bool allSelectable
            ) : base(level_table,
                descr_level_field,
                descr_level_field,
                selectable_level_field,
                descr_field,
                code_string,
                R) {
                this.maxlevel = maxlevel;
                this.allSelectable = allSelectable;
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
                if (allSelectable) return true;
                DataRow Lev = LevelRow();
                if (maxlevel > 0) {
                    if (Lev["nlevel"].ToString() == maxlevel.ToString()) return true;
                }

                if (HasAutoChildren()) return false;

                //object idpatrimony = Row["idpatrimony"];
                //QueryHelper QHS = Conn.GetQueryHelper();
                //string filter = QHS.AppAnd(QHS.CmpEq("ayear", Conn.GetSys("esercizio")), QHS.CmpEq("paridpatrimony", idpatrimony));
                //int ResultCount = Conn.RUN_SELECT_COUNT("patrimony", filter, true);
                //if (ResultCount != 0) return false;
                return true;
            }
        } // class patrimoniale_tree_node


        //alla classe base viene passato nel primo caso (parametro all = true)
        //un node_dispatcher che consente di selezionare anche nodi non operativi
        public class TreeViewPatrimoniale : TreeViewManager {
            string kind;
            public int maxlevel = 0;

            public TreeViewPatrimoniale(DataTable T, TreeView tree, string filterc, string filtersql, string kind,
                bool all, int maxlevel, bool allLevel) :
                base(T, tree,
                    (all
                        ? new easy_node_dispatcher(
                            "patrimonylevel",
                            "nlevel",
                            "description",
                            null,
                            "title",
                            "codepatrimony")
                        : new patrimoniale_node_dispatcher(
                            "patrimonylevel",
                            "nlevel",
                            "description",
                            "flagusable",
                            "title",
                            "codepatrimony",
                            maxlevel,allLevel
                        )
                    ), filterc, filtersql) {
                this.kind = kind;
                //se all vale true disabilito il doppio click come selezione
//				if (all) base.DoubleClickForSelect=false;
                base.DoubleClickForSelect = false;
            }

            override public TreeNode AddNode(TreeNodeCollection Nodes, TreeNode NewNode) {
                if (Nodes.Equals(tree.Nodes) && (NewNode.Tag != null)) {
                    //searches the right node into which do the additon
                    DataRow R = ((tree_node) NewNode.Tag).Row;
                    string kind = R["patpart"].ToString();
                    foreach (TreeNode N in Nodes) {
                        if (N.Text == kind) {
                            return base.AddNode(N.Nodes, NewNode);
                        }
                    }
                }

                return base.AddNode(Nodes, NewNode);
            }

            public override void FillNodes() {
                base.FillNodes();
                AutoEventsEnabled = false;
                TreeNode[] newroot = new TreeNode[kind.Length];
                int n_root = newroot.Length;
                for (int i = 0; i < kind.Length; i++) {
                    newroot[i] = new TreeNode(kind.Substring(i, 1));
                }

                if (tree.Nodes.Count > 0) {
                    if (tree.Nodes[0].Tag == null) return;
                }

                while (tree.Nodes.Count > 0) {
                    TreeNode X = tree.Nodes[0];
                    tree.Nodes.RemoveAt(0);
                    for (int i = 0; i < kind.Length; i++) {
                        if (X.Tag == null) continue;
                        DataRow R = ((tree_node) X.Tag).Row;
                        if (R["patpart"].ToString() == kind.Substring(i, 1)) {
                            newroot[i].Nodes.Add(X);
                            break;
                        }
                    }
                }

                for (int i = 0; i < kind.Length; i++) {
                    tree.Nodes.Add(newroot[i]);
                    newroot[i].Expand();
                }

                AutoEventsEnabled = true;
            }
        } // class TreeViewPatrimoniale
        //

    }
}
