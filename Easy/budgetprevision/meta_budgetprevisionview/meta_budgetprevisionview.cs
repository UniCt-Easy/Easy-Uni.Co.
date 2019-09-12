/*
    Easy
    Copyright (C) 2019 Università degli Studi di Catania (www.unict.it)

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
using funzioni_configurazione;
namespace meta_budgetprevisionview {
	/// <summary>
	/// Summary description for Meta_budgetprevision.
	/// </summary>
	public class Meta_budgetprevisionview : Meta_easydata {
		public Meta_budgetprevisionview(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "budgetprevisionview") {	
			EditTypes.Add("default");
			ListingTypes.Add("default");


            EditTypes.Add("previsionupb");
            ListingTypes.Add("previsionupb");

            ListingTypes.Add("previsionsorting");
            EditTypes.Add("previsionsorting");
		}

		protected override Form GetForm(string EditType) {
			switch(EditType) {
                case "previsionupb":
                    {
                        Name = "Budget voce di classificazione - U.P.B.";
                        DefaultListType = "default";
                        return GetFormByDllName("budgetprevisionview_previsionupb");
                    }
                case "previsionsorting":
                    {
                        Name = "Budget voce di classificazione - U.P.B.";
                        DefaultListType = "default";
                        return GetFormByDllName("budgetprevisionview_previsionfin");
                    }
				case "default": {
					Name = "Budget classificazione suddivisa per U.P.B.";
					DefaultListType = "default";
					ActAsList();
					IsTree=true;
					return GetFormByDllName("budgetprevisionview_default");
				}
			}
			return null;
		}

		public override void SetDefaults(DataTable PrimaryTable) {
			base.SetDefaults (PrimaryTable);
			SetDefault(PrimaryTable,"ayear",Conn.GetSys("esercizio"));
		}
		public override void DescribeColumns(DataTable T, string ListingType)
		{
			base.DescribeColumns(T, ListingType);
			if (ListingType=="default"){				 
				foreach (DataColumn C in T.Columns)
					DescribeAColumn(T, C.ColumnName, "",-1);
                 int nPos = 1;
				DescribeAColumn(T,"ayear",".Esercizio",nPos++);
				DescribeAColumn(T,"sortcode", "Codice",nPos++);
				DescribeAColumn(T, "sorting","Denominazione",nPos++);
				DescribeAColumn(T,"upb","UPB",nPos++);
                DescribeAColumn(T, "prevision", "Budget", nPos++);
			}

            if (ListingType == "previsionupb")
            {
                foreach (DataColumn C in T.Columns)
                    DescribeAColumn(T, C.ColumnName, "", -1);
                int nPos = 1;
                DescribeAColumn(T, "ayear", ".Esercizio",nPos++);
                DescribeAColumn(T, "codeupb", "UPB",nPos++);
                DescribeAColumn(T, "upb", "UPB", nPos++);
                DescribeAColumn(T, "prevision", "Budget",nPos++);
            }

            if (ListingType == "previsionsorting")
            {
                foreach (DataColumn C in T.Columns)
                    DescribeAColumn(T, C.ColumnName, "", -1);
                DescribeAColumn(T, "ayear", ".Esercizio", -1);
                DescribeAColumn(T, "sortcode", "Codice", 2);
                DescribeAColumn(T, "prevision", "Budget Iniziale", 3);
               
            }
		}

        public override bool IsValid(DataRow R, out string errmess, out string errfield){
            if (!base.IsValid(R, out errmess, out errfield))
                return false;
            if (R.Table.Columns.Contains("nlevel")) {
                int levelop = CfgFn.GetNoNullInt32(Conn.GetSys("sortingusablelevel"));
                int thislevel = CfgFn.GetNoNullInt32(R["nlevel"]);
                if (thislevel < levelop) {
                    errmess = "Attenzione! Scegliere una voce operativa.";
                    errfield = "sortcode";
                    return false;
                }
            }
            return true;

        }

		override public DataRow Get_New_Row(DataRow ParentRow, DataTable T){
			if (edit_type == "default") {
				if (ParentRow!=null){
					SetDefault(T,"idsor",ParentRow["idfin"]);
					SetDefault(T,"paridsor",ParentRow["paridsor"]);
					SetDefault(T,"sortcode",ParentRow["sortcode"]);
					SetDefault(T,"sorting",ParentRow["description"]);
				}
			}
            if (edit_type == "previsionupb")
            {
                if (ParentRow != null)
                {
                    SetDefault(T, "idsorkind", ParentRow["idsorkind"]);
                    SetDefault(T, "idsor", ParentRow["idsor"]);
                    SetDefault(T, "paridsor", ParentRow["paridsor"]);
                    SetDefault(T, "sortcode", ParentRow["sortcode"]);
                    SetDefault(T, "sorting", ParentRow["description"]);
                    SetDefault(T, "nlevel", ParentRow["nlevel"]);

                    DataTable SortTable = Conn.RUN_SELECT("sortingview", "codesorkind,sortingkind,nlevel,leveldescr", null, QHS.CmpEq("idsor", ParentRow["idsor"]), null, null, true);
                    object leveldescr   = DBNull.Value;
                    object codesorkind  = DBNull.Value;
                    object sortingkind = DBNull.Value;

                    if (SortTable.Rows.Count > 0)
                      {
                           leveldescr  = SortTable.Rows[0]["leveldescr"];
                           codesorkind = SortTable.Rows[0]["codesorkind"];
                           sortingkind = SortTable.Rows[0]["sortingkind"];
                      }
                    SetDefault(T, "leveldescr",  leveldescr);
                    SetDefault(T, "codesorkind", codesorkind);
                    SetDefault(T, "sortingkind", sortingkind);

                }
            }
			DataRow R = base.Get_New_Row(ParentRow, T);
			return R;
		}

		public override void DescribeTree(TreeView tree, DataTable T, string ListingType){
			// Listing Type chiamato dal form di gestione di budgetprevision (fissato l'IDFIN)
			if (ListingType == "tree") {
				object idSorting = T.ExtendedProperties["idsor"];
				base.DescribeTree(tree, T, ListingType);
                string filterC = QHC.AppAnd(QHC.CmpEq("idsor", idSorting), QHC.IsNull("paridupb"));
                string filterSql = QHS.AppAnd(QHS.CmpEq("idsor", idSorting), QHS.IsNull("paridupb"));
                string filteresercizio = QHS.CmpEq("ayear",GetSys("esercizio"));
				TreeViewManager M = new TreeViewbudgetprevision(T, tree, filterC,filterSql, null);
                myGetData.SetStaticFilter("sortinglevel", filteresercizio);  
			}
		}
	}

	public class TreeViewbudgetprevision : TreeViewManager {
		public TreeViewbudgetprevision(DataTable T, TreeView tree, string filterc, string filtersql, string kind):               
			base(T,tree, new easy_node_dispatcher(
			null,
			null,
			null,
			null,
			"upb",
			"codeupb"
			),filterc,filtersql) {
			base.DoubleClickForSelect=false;
		}
		override public TreeNode AddNode(TreeNodeCollection Nodes, TreeNode NewNode){
			if (Nodes.Equals(tree.Nodes) && (NewNode.Tag!=null)){
				if (Nodes.Count==0)return base.AddNode(Nodes,NewNode); //should not happen!
				TreeNode N = Nodes[0];
				return base.AddNode(N.Nodes, NewNode);
			}
			return base.AddNode(Nodes,NewNode);
		}
		public override void FillNodes(){
			base.FillNodes();
			AutoEventsEnabled=false;
			TreeNode newroot= new TreeNode("-");
			if (tree.Nodes.Count>0){
				if (tree.Nodes[0].Tag==null) return;
			}

			while (tree.Nodes.Count>0){
				TreeNode X = tree.Nodes[0];
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
	}
}