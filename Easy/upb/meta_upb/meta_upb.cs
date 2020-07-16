/*
    Easy
    Copyright (C) 2020 Universit√† degli Studi di Catania (www.unict.it)
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
using HelpWeb;

namespace meta_upb {
	/// <summary>
	/// Summary description for Meta_upb.
	/// </summary>
	public class Meta_upb : Meta_easydata {
		public Meta_upb(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "upb") {		
			Name = "U.P.B.";
			EditTypes.Add("default");
			EditTypes.Add("tree");
            ListingTypes.Add("daticontabili");
			ListingTypes.Add("default");
            ListingTypes.Add("missioni");
            ListingTypes.Add("tree");
		}

		public override void SetDefaults(DataTable PrimaryTable) {
			base.SetDefaults (PrimaryTable);
			SetDefault(PrimaryTable,"active","S");
			SetDefault(PrimaryTable, "assured", "N");
            SetDefault(PrimaryTable, "flag", 0);
        }

		protected override Form GetForm(string FormName){
			switch(FormName) {
				case "default" : {
					Name = "U.P.B.";
					CanInsertCopy = false;
					ActAsList();                
					IsTree = true;
					DefaultListType = "daticontabili";
					return GetFormByDllName("upb_default");
				}
                case "history": {
                    Name = "U.P.B.";
                    CanInsertCopy = false;
                    ActAsList();
                    IsTree = true;
                    DefaultListType = "daticontabili";
                    return GetFormByDllName("upb_default");
                }

                case "tree": {
					Name = "Scelta dell'U.P.B.";
					ActAsList();
					IsTree = true;
					return GetFormByDllName("upb_tree");
				}
			}
			return null;
		}

		override public DataRow Get_New_Row(DataRow ParentRow, DataTable T){
			int maxDepth = 9;
			int level; 
			string codprefix;
			string ordinestampaprefix;
			if (ParentRow!=null){
				level = 1 + ParentRow["idupb"].ToString().Length / 4;
				codprefix = ParentRow["codeupb"].ToString();
				ordinestampaprefix=ParentRow["printingorder"].ToString();
			}
			else {
				level = 1;
				codprefix = "";
				ordinestampaprefix = "";
				SetDefault(T,"paridupb",DBNull.Value);
			}
			if (level > (maxDepth)){
				//MessageBox. Show("Non Ë possibile inserire un livello inferiore a quello selezionato");
				return null;
			}

			string kind = "A"; //corresponding to "flagreset"

			RowChange.MarkAsAutoincrement(T.Columns["idupb"],
				"paridupb", null, 4);

			if (kind.ToLower()=="a") {
				SetDefault(T,"codeupb", codprefix);
				//RowChange.ClearAutoIncrement(T.Columns["codefin"]);
				SetDefault(T,"printingorder", ordinestampaprefix);
			}		
			DataRow R = base.Get_New_Row(ParentRow, T);
			return R;
		}


		public override DataRow SelectOne(string ListingType, string filter, string searchtable, DataTable Exclude)	{
            switch (ListingType) {
                case "default": {
                        return base.SelectOne(ListingType, filter, "upbview", Exclude);
                    }
                case "missioni": {
                        return base.SelectOne(ListingType, filter, "upbitinerationavailable", Exclude);
                    }
                case "daticontabili": {
                        return base.SelectOne(ListingType, filter, "upbyearview", Exclude);
                    }
                default: {
                        return base.SelectOne(ListingType, filter, "upb", Exclude);
                    }
            }
		}

        public override string GetSorting(string ListingType) {
            if (ListingType == "tree") {
                return "codeupb asc";
            }
            return base.GetSorting(ListingType);
        }
		public override void DescribeColumns(DataTable T, string ListingType)
		{
			base.DescribeColumns(T, ListingType);
			if (ListingType=="tree"){
				foreach (DataColumn C in T.Columns)
					DescribeAColumn(T, C.ColumnName, "",-1);
				DescribeAColumn(T,"codeupb","Codice",1);
				DescribeAColumn(T,"title","Denominazione",2);
			}
		}

        public override bool IsValid(DataRow R, out string errmess, out string errfield) {
            if (!base.IsValid(R, out errmess, out errfield)) return false;
            if (R["stop"] != DBNull.Value) {
                bool agisci = true;
                if (R.RowState == DataRowState.Modified) {
                    if (R["stop"].ToString() == R["stop", DataRowVersion.Original].ToString()) agisci = false;
                }
                DateTime dateStop = (DateTime) R["stop"];
                if (agisci && dateStop.Year < CfgFn.GetNoNullInt32(GetSys("esercizio"))) {
                    errmess = "Attenzione! Non Ë possibile inserire una data fine antecedente l'esercizio corrente.";
                    errfield = "stop";
                    return false;
                }
            }
            if (!CfgFn.IsValidString(R["cigcode"].ToString())) {
                errmess = "Il CIG contiene caratteri non validi.I caratteri ammessi sono solo numeri e lettere.";
                errfield = "cigcode";
                return false;
            }
 
			if (((R["uesiopecode"] != DBNull.Value) && (R["cofogmpcode"] == DBNull.Value))|| 
				((R["uesiopecode"] == DBNull.Value) && (R["cofogmpcode"] != DBNull.Value))) {
				errmess = "Attenzione! I dati ARCONET nella scheda fabbisogno devono essere entrambi valorizzati oppure entrambi assenti.";
				errfield = "uesiopecode";
				return false;
			}
				return true;
        }



        public override void WebDescribeTree(hwTreeView tree, DataTable T, string ListingType)
        {
            // L'idupb ha una lunghezza di 36 caratteri ed ogni livello ha una lunghezza di 4 caratteri
            int maxDepth = 9;

            //Aggiorno le intestazioni del DataGrid
            if (ListingType == "tree")
            {
                base.DescribeColumns(T, ListingType);
                foreach (DataColumn C in T.Columns)
                    DescribeAColumn(T, C.ColumnName, "");
                DescribeAColumn(T, "codeupb", "Codice");
                DescribeAColumn(T, "title", "Denominazione");
                DescribeAColumn(T, "!responsabile", "Responsabile", "manager.title");
            }

            base.WebDescribeTree(tree, T, ListingType);
            string filterc = QHC.IsNull("paridupb");
            string filtersql = QHS.IsNull("paridupb");

            bool withdescr = false;
            if (Conn.GetSys("upb_with_description") != null) {
                if (Conn.GetSys("upb_with_description").ToString().ToUpper() == "S") withdescr = true;
            }
            WebTreeViewUpb M = new WebTreeViewUpb(T, tree, filterc, filtersql, maxDepth, withdescr);
        }



		public override void DescribeTree(TreeView tree, DataTable T, string ListingType)
		{
			// L'idupb ha una lunghezza di 36 caratteri ed ogni livello ha una lunghezza di 4 caratteri
			int maxDepth = 9;

			//Aggiorno le intestazioni del DataGrid
			if (ListingType=="tree"){
				base.DescribeColumns(T, ListingType);
				foreach (DataColumn C in T.Columns)
					DescribeAColumn(T, C.ColumnName, "");
				DescribeAColumn(T,"codeupb", "Codice");
				DescribeAColumn(T,"title","Denominazione");
				DescribeAColumn(T,"!responsabile","Responsabile", "manager.title");
			}

			base.DescribeTree(tree, T, ListingType);
			string filterc=QHC.IsNull("paridupb");
            string filtersql = QHS.IsNull("paridupb");
            bool withdescr = false;
            if (Conn.GetSys("upb_with_description") != null) {
                if (Conn.GetSys("upb_with_description").ToString().ToUpper() == "S") withdescr = true;
            }
			TreeViewUpb M = new TreeViewUpb(T, tree, filterc,filtersql, maxDepth,withdescr);
		}
	}

    public class WebTreeViewUpb : hwTreeViewManager
    {
        public WebTreeViewUpb(DataTable T, hwTreeView tree, string filterc, string filtersql, int maxlevel, bool withdescr)
            :
            base(T, tree,
            (withdescr?  new easy_node_dispatcher(null,null,null,null,"title","codeupb"):
                              new upb_node_dispatcher("title","codeupb")
            ), filterc, filtersql)
        {
            base.DoubleClickForSelect = false;
        }
    }


	public class TreeViewUpb : TreeViewManager {
		public TreeViewUpb(DataTable T, TreeView tree, string filterc, string filtersql, int maxlevel, bool withdescr):               
			base(T,tree, 
			( withdescr?  new easy_node_dispatcher(null,null,null,null,"title","codeupb"):
                              new upb_node_dispatcher("title","codeupb") 
			),filterc,filtersql) {
			base.DoubleClickForSelect=false;
		}
	}

    public class upb_node_dispatcher : easy_node_dispatcher {
        public upb_node_dispatcher(string descr_field,
            string code_string)
            : base(null,null,null,null,descr_field, code_string) {
        }

        override public tree_node GetNode(DataRow Parent, DataRow Child) {
            return new upb_tree_node("title", "codeupb",Child);
        }

    }


    public class upb_tree_node : easy_tree_node {
        public upb_tree_node(string descr_field, string code_string, DataRow R)
            : base(null,null,null,null,descr_field,code_string,R){
            
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
            S = Row["codeupb"].ToString();            
            return S;

        }

    }

}