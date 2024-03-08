
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

namespace meta_listclass {
    /// <summary>
    /// Summary description for Meta_listclass.
    /// </summary>
    public class Meta_listclass : Meta_easydata {
        public Meta_listclass(DataAccess Conn, MetaDataDispatcher Dispatcher)
            : base(Conn, Dispatcher, "listclass") {
            Name = "Classificazione Merceologica";
            EditTypes.Add("default");
            EditTypes.Add("tree");
            EditTypes.Add("estimatetree");
            EditTypes.Add("mandatetree");
            EditTypes.Add("bookingtree");
            ListingTypes.Add("default");
            ListingTypes.Add("tree");
        }

        public override void SetDefaults(DataTable PrimaryTable) {
            base.SetDefaults(PrimaryTable);
            SetDefault(PrimaryTable, "active", "S");
            SetDefault(PrimaryTable, "authrequired", "N");
            SetDefault(PrimaryTable, "flagvisiblekind", 0);
        }

        protected override Form GetForm(string FormName) {
            switch (FormName) {
                case "default":
                    {
                        Name = "Classificazione Merceologica";
                        CanInsertCopy = false;
                        ActAsList();
                        IsTree = true;
                        DefaultListType = "default";//daticontabili
                        return GetFormByDllName("listclass_default");
                    }

                case "tree":
                    {
                        Name = "Classificazione Merceologica";
                        ActAsList();
                        IsTree = true;
                        return GetFormByDllName("listclass_tree");
                    }
                case "estimatetree": {
                        Name = "Classificazione Merceologica";
                        ActAsList();
                        IsTree = true;
                        return GetFormByDllName("listclass_tree");
                    }
                case "mandatetree": {
                        Name = "Classificazione Merceologica";
                        ActAsList();
                        IsTree = true;
                        return GetFormByDllName("listclass_tree");
                    }
                case "bookingtree": {
                        Name = "Classificazione Merceologica";
                        ActAsList();
                        IsTree = true;
                        return GetFormByDllName("listclass_tree");
                    }
            }
            return null;
        }

        override public DataRow Get_New_Row(DataRow ParentRow, DataTable T) {
            int maxDepth = 9;
            int level;
            string codprefix;
            string ordinestampaprefix;
            if (ParentRow != null) {
                level = 1 + ParentRow["idlistclass"].ToString().Length / 4;
                codprefix = ParentRow["codelistclass"].ToString();
                ordinestampaprefix = ParentRow["printingorder"].ToString();
            }
            else {
                level = 1;
                codprefix = "";
                ordinestampaprefix = "";
                SetDefault(T, "paridlistclass", DBNull.Value);
            }
            if (level > (maxDepth)) {
                //MetaFactory.factory.getSingleton<IMessageShower>(). Show("Non è possibile inserire un livello inferiore a quello selezionato");
                return null;
            }

            string kind = "A"; //corresponding to "flagreset"

            RowChange.MarkAsAutoincrement(T.Columns["idlistclass"],
                "paridlistclass", null, 4);

            if (kind.ToLower() == "a") {
                SetDefault(T, "codelistclass", codprefix);
                SetDefault(T, "printingorder", ordinestampaprefix);
            }
            DataRow R = base.Get_New_Row(ParentRow, T);
            return R;
        }


        public override DataRow SelectOne(string ListingType, string filter, string searchtable, DataTable Exclude) {

            if (ListingType == "default") {
                return base.SelectOne(ListingType, filter, "listclassyearview", Exclude);
            }
            return base.SelectOne(ListingType, filter, "listclass", Exclude);

        }

        public override void DescribeColumns(DataTable T, string ListingType) {
            base.DescribeColumns(T, ListingType);
            if (ListingType == "tree") {
                foreach (DataColumn C in T.Columns)
                    DescribeAColumn(T, C.ColumnName, "", -1);
                int nPos = 1;
                DescribeAColumn(T, "codelistclass", "Codice", nPos++);
                DescribeAColumn(T, "title", "Denominazione", nPos++);
            }
            if (ListingType == "default") {
                foreach (DataColumn C in T.Columns)
                    DescribeAColumn(T, C.ColumnName, "", -1);
                int nPos = 1;
                DescribeAColumn(T, "codelistclass", "Codice", nPos++);
                DescribeAColumn(T, "title", "Denominazione", nPos++);
                DescribeAColumn(T, "active", "Attivo", nPos++);
                DescribeAColumn(T, "authrequired", "Richiede Autorizzazione", nPos++);
            }

        }

        public override void DescribeTree(TreeView tree, DataTable T, string ListingType) {
            // L'idlistclass ha una lunghezza di 36 caratteri ed ogni livello ha una lunghezza di 4 caratteri
            int maxDepth = 9;

            //Aggiorno le intestazioni del DataGrid
            if (ListingType == "tree") {
                base.DescribeColumns(T, ListingType);
                foreach (DataColumn C in T.Columns)
                    DescribeAColumn(T, C.ColumnName, "");
                DescribeAColumn(T, "codelistclass", "Codice");
                DescribeAColumn(T, "title", "Denominazione");
            }
           
            base.DescribeTree(tree, T, ListingType);
            string filterc = QHC.IsNull("paridlistclass");
            string filtersql = QHS.IsNull("paridlistclass");

            TreeViewlistclass M = new TreeViewlistclass(T, tree, filterc, filtersql, maxDepth);
        }

        public override void WebDescribeTree(hwTreeView tree, DataTable T, string ListingType) {
            int maxDepth = 9;

            if (ListingType == "tree") {
                base.DescribeColumns(T, ListingType);
                foreach (DataColumn C in T.Columns)
                    DescribeAColumn(T, C.ColumnName, "");
                DescribeAColumn(T, "codelistclass", "Codice");
                DescribeAColumn(T, "title", "Denominazione");
            }

            base.WebDescribeTree(tree, T, ListingType);
            string filterc = QHC.IsNull("paridlistclass");
            string filtersql = QHS.IsNull("paridlistclass");

            hwTreeViewListClass M = new hwTreeViewListClass(Conn, T, tree, filterc, filtersql, false, maxDepth);
        }
    }



    public class TreeViewlistclass : TreeViewManager {
        public TreeViewlistclass(DataTable T, TreeView tree, string filterc, string filtersql, int maxlevel)
            :
            base(T, tree,
            (new easy_node_dispatcher(
            null,
            null,
            null,
            null,
            "title",
            "codelistclass")
            ), filterc, filtersql) {
            base.DoubleClickForSelect = false;
        }
    }

    public class hwTreeViewListClass : hwTreeViewManager {
        public int maxlevel = 0;
        public hwTreeViewListClass(DataAccess Conn, DataTable T, hwTreeView tree, string filterc,
                string filtersql, bool all, int maxlevel) :
            base(T, tree,
                new easy_node_dispatcher(
                null,
                null,
                null,
                null,
                "title",
                "codelistclass"),
                filterc, filtersql) {
            //se all vale true disabilito il doppio click come selezione
            if (all) base.DoubleClickForSelect = false;
        }
    }
}
