/*
    Easy
    Copyright (C) 2020 Università degli Studi di Catania (www.unict.it)
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
namespace meta_finyearview {
	/// <summary>
	/// Summary description for Meta_finyear.
	/// </summary>
	public class Meta_finyearview : Meta_easydata {
		public Meta_finyearview(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "finyearview") {
               
            Name = "Previsione sulla voce di bilancio dell' U.P.B.";
			EditTypes.Add("default");
            EditTypes.Add("treee");
			EditTypes.Add("trees");
			ListingTypes.Add("default");
			ListingTypes.Add("tree");

            EditTypes.Add("previsionupb");
            ListingTypes.Add("previsionupb");

            ListingTypes.Add("previsionfin");
            EditTypes.Add("previsionfin");

		}

		protected override Form GetForm(string EditType) {
			switch(EditType) {
                case "previsionupb":{
                        Name = "Previsione sulla voce di bilancio dell' U.P.B.";
                        DefaultListType = "default";
                        return GetFormByDllName("finyearview_previsionupb");
                    }
                case "previsionfin":{
                        Name = "Previsione sulla voce di bilancio dell' U.P.B.";
                        DefaultListType = "default";
                        return GetFormByDllName("finyearview_previsionfin");
                    }
				case "default": {
					Name = "Previsione sulla voce di bilancio suddivisa per U.P.B.";
					DefaultListType = "default";
					ActAsList();
					IsTree=true;
					return GetFormByDllName("finyearview_default");
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
			if (ListingType=="default"){				//		+
				foreach (DataColumn C in T.Columns)
					DescribeAColumn(T, C.ColumnName, "",-1);
				DescribeAColumn(T,"ayear",".Esercizio",-1);
				DescribeAColumn(T,"codefin", "Codice",1);
				DescribeAColumn(T, "finance","Denominazione",2);
				DescribeAColumn(T,"upb","UPB",3);	
				DescribeAColumn(T, "prevision", "Prev. Iniziale",4);
				if (Conn!=null)	{
                    int finkind = CfgFn.GetNoNullInt32(Conn.GetSys("fin_kind"));
					if (finkind==3)
					{
						DescribeAColumn(T, "prevision", "Prev. Iniziale Comp.");
						DescribeAColumn(T, "secondaryprev", "Prev. Iniziale Cassa",5);
					}
				}				
			}
            if (ListingType == "previsionupb"){				
                foreach (DataColumn C in T.Columns)
                    DescribeAColumn(T, C.ColumnName, "", -1);
                DescribeAColumn(T, "ayear", ".Esercizio", -1);
                DescribeAColumn(T, "codeupb", "UPB", 1);
                DescribeAColumn(T, "prevision", "Prev. Iniziale", 2);
                if (Conn != null){
                    int finkind = CfgFn.GetNoNullInt32(Conn.GetSys("fin_kind"));
                    if (finkind == 3){
                        DescribeAColumn(T, "prevision", "Prev. Iniziale Comp.",3);
                        DescribeAColumn(T, "secondaryprev", "Prev. Iniziale Cassa", 4);
                    }
                }
            }
            if (ListingType == "previsionfin"){
                foreach (DataColumn C in T.Columns)
                    DescribeAColumn(T, C.ColumnName, "", -1);
                DescribeAColumn(T, "ayear", ".Esercizio", -1);
                DescribeAColumn(T, "finpart", "E/S", 1);
                DescribeAColumn(T, "codefin", "Codice", 2);
                DescribeAColumn(T, "prevision", "Prev. Iniziale", 3);
                if (Conn != null)
                {
                    int finkind = CfgFn.GetNoNullInt32(Conn.GetSys("fin_kind"));
                    if (finkind == 3)
                    {
                        DescribeAColumn(T, "prevision", "Prev. Iniziale Comp.", 4);
                        DescribeAColumn(T, "secondaryprev", "Prev. Iniziale Cassa", 5);
                    }
                }
            }
		}

        string []mykey=new string[] {"idfin","idupb"};
	    public override string[] primaryKey() {
	        return mykey;
	    }

	    public override bool IsValid(DataRow R, out string errmess, out string errfield){
            if (!base.IsValid(R, out errmess, out errfield))
                return false;
            if (R.Table.Columns.Contains("nlevel")) {
                int levelop = CfgFn.GetNoNullInt32(Conn.GetSys("finusablelevel"));
                int thislevel = CfgFn.GetNoNullInt32(R["nlevel"]);
                if (thislevel < levelop) {
                    errmess = "Attenzione! Scegliere una voce operativa.";
                    errfield = "codefin";
                    return false;
                }
            }
            return true;

        }

		override public DataRow Get_New_Row(DataRow ParentRow, DataTable T){
			if (edit_type == "default") {
				if (ParentRow!=null){
					SetDefault(T,"idfin",ParentRow["idfin"]);
					SetDefault(T,"paridfin",ParentRow["paridfin"]);
					SetDefault(T,"codefin",ParentRow["codefin"]);
					SetDefault(T,"finance",ParentRow["finance"]);
				}
			}
            if (edit_type == "previsionupb"){
                if (ParentRow != null){
                    SetDefault(T, "idfin", ParentRow["idfin"]);
                    SetDefault(T, "paridfin", ParentRow["paridfin"]);
                    SetDefault(T, "codefin", ParentRow["codefin"]);
                    SetDefault(T, "finance", ParentRow["title"]);
                    SetDefault(T, "flag", ParentRow["flag"]);
                    SetDefault(T, "nlevel", ParentRow["nlevel"]);

                    int flag = CfgFn.GetNoNullInt32(ParentRow["flag"]);
                    object finpart = DBNull.Value;
                    if ((flag & 1) == 1){
                        finpart = "S";
                    }
                    else{
                        finpart = "E";
                    }
                    SetDefault(T, "finpart", finpart);

                    string filterfinlevel = QHS.AppAnd(QHS.CmpEq("ayear", Conn.GetSys("esercizio")), QHS.CmpEq("nlevel", ParentRow["nlevel"]));
                    object leveldescr = Conn.DO_READ_VALUE("finlevel", filterfinlevel, "description");
                    SetDefault(T, "leveldescr", leveldescr);
                    

                }
            }

            if (edit_type == "previsionfin"){
                if (ParentRow != null){
                    SetDefault(T, "idupb", ParentRow["idupb"]);
                    SetDefault(T, "paridupb", ParentRow["paridupb"]);
                    SetDefault(T, "codeupb", ParentRow["codeupb"]);
                    SetDefault(T, "upb", ParentRow["title"]);
                }
            }

			DataRow R = base.Get_New_Row(ParentRow, T);
			return R;
		}

		public override void DescribeTree(TreeView tree, DataTable T, string ListingType){
			// Listing Type chiamato dal form di gestione di FINYEAR (fissato l'IDFIN)
			if (ListingType == "tree") {
				object idBilancio = T.ExtendedProperties["idfin"];
				base.DescribeTree(tree, T, ListingType);
                string filterC = QHC.AppAnd(QHC.CmpEq("idfin", idBilancio), QHC.IsNull("paridupb"));
                string filterSql = QHS.AppAnd(QHS.CmpEq("idfin", idBilancio), QHS.IsNull("paridupb"));
                string filteresercizio = QHS.CmpEq("ayear",GetSys("esercizio"));
				TreeViewManager M = new TreeViewFinYear(T, tree, filterC,filterSql, null);
                myGetData.SetStaticFilter("finlevel", filteresercizio);  
			}
		}
	}

	public class TreeViewFinYear : TreeViewManager {
		public TreeViewFinYear(DataTable T, TreeView tree, string filterc, string filtersql, string kind):               
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
}