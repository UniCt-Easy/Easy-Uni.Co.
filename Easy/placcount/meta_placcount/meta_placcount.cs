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
using placcount_tree;


namespace meta_placcount
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	public class Meta_placcount : Meta_easydata{
		int esercizio;
		public Meta_placcount(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "placcount"){
			EditTypes.Add("default");
			EditTypes.Add("treecr");
			EditTypes.Add("tree");
            EditTypes.Add("treec");
            EditTypes.Add("treer");
            EditTypes.Add("treecnew");
            EditTypes.Add("treernew");
			ListingTypes.Add("default");
			ListingTypes.Add("treecr");
			ListingTypes.Add("tree");
            ListingTypes.Add("treec");
            ListingTypes.Add("treer");
            ListingTypes.Add("treecnew");
            ListingTypes.Add("treernew");
            ListingTypes.Add("checkimport");
			Name = "Conto Economico";
			esercizio= Convert.ToInt32(GetSys("esercizio"));
		}


        public override bool CanSelect(DataRow R)
        {
            return DataAccess.CanSelect(Conn, R);
        }

		protected override Form GetForm(string FormName) {
			if (FormName=="default") {
				Name="Conto Economico annuale";
				CanInsertCopy=false;
				ActAsList();                
				IsTree=true;
				DefaultListType="default";
				return MetaData.GetFormByDllName("placcount_default");
			}
			if (FormName== "tree") {
					Name = "Scelta del Conto Economico";
					ActAsList();
					IsTree = true;
					return GetFormByDllName("placcount_tree");
				}
                if (FormName == "treec"||FormName == "treecnew")
                {
                    Name = "Scelta del Conto Economico";
                    DefaultListType = FormName;
                    ActAsList();
                    IsTree = true;
                    Frm_placcount_tree F = new Frm_placcount_tree();
                    F.tree.Tag = "placcount." + FormName;
                    return F;
                }
                if (FormName == "treer" || FormName == "treernew")
                {
                    Name = "Scelta del Conto Economico";
                    DefaultListType = FormName;
                    ActAsList();
                    IsTree = true;
                    Frm_placcount_tree F = new Frm_placcount_tree();
                    F.tree.Tag = "placcount." + FormName;
                    return F;
                }
			return null;
		}

		override public void SetDefaults(DataTable Primary) {
			base.SetDefaults(Primary);
			string idprefix = esercizio.ToString().Substring(2,2); 
			SetDefault(Primary,"paridplaccount",idprefix);	
			SetDefault(Primary,"ayear", esercizio);
			SetDefault(Primary,"active","S");
		}

		public override DataRow SelectOne(string ListingType, string filter, string searchtable, DataTable Exclude) {
			if (ListingType == "default") {
				return base.SelectOne(ListingType, filter, "placcountview", Exclude);
			}
			else {
				return base.SelectOne(ListingType, filter, "placcount", Exclude);
			}
		}
        public override void DescribeColumns(DataTable T, string ListingType)
        {
            base.DescribeColumns(T, ListingType);
            if (ListingType == "checkimport")
            {
                foreach (DataColumn C in T.Columns)
                    DescribeAColumn(T, C.ColumnName, "", -1);
                int nPos = 1;
                DescribeAColumn(T, "ayear", "Esercizio", nPos++);
                DescribeAColumn(T, "codeplaccount", "Codice", nPos++);
                DescribeAColumn(T, "title", "Denominazione", nPos++);
            }
        }
		public override void DescribeTree(TreeView tree, DataTable T, string ListingType) {
			int maxlev=0;

            if (ListingType == "treecr" || ListingType == "tree" || ListingType == "treec" || ListingType == "treer" || ListingType == "treecnew" || ListingType == "treernew")
            {
				base.DescribeColumns(T, ListingType);
				foreach (DataColumn C in T.Columns)
					DescribeAColumn(T, C.ColumnName, "");
				DescribeAColumn(T,"!livello","Livello", "placcountlevel.description");
				DescribeAColumn(T,"codeplaccount", "Codice");
				DescribeAColumn(T,"title","Denominazione");
			}

			base.DescribeTree(tree, T, ListingType);
			int esercizio = Convert.ToInt32( GetSys("esercizio"));
            int esercizionew = esercizio + 1;
            string filteresercizio = QHS.CmpEq("ayear",GetSys("esercizio"));
			string filterc=QHC.CmpEq("nlevel","1");
			string filtersql=QHS.CmpEq("nlevel","1");
			string kind="CR";
			bool all = false;
			
			if (ListingType=="treecr") {
                //filter="(nlevel='1')";
				kind="CR";
			}
            if (ListingType == "treec")
            {
                string livsupid = esercizio.ToString().Substring(2) + "C";
                filterc = QHC.CmpEq("paridplaccount", livsupid);
                filtersql = QHS.CmpEq("paridplaccount", livsupid);
                kind = "C";
                all = true;
            }
            if (ListingType == "treer")
            {
                string livsupid = esercizio.ToString().Substring(2) + "R";
                filterc = QHC.CmpEq("paridplaccount", livsupid);
                filtersql = QHS.CmpEq("paridplaccount", livsupid);
                kind = "R";
                all = true;
            }
            if (ListingType == "treecnew")
            {
                string livsupid = esercizionew.ToString().Substring(2) + "C";
                filterc = QHC.CmpEq("paridplaccount", livsupid);
                filtersql = QHS.CmpEq("paridplaccount", livsupid);
                kind = "C";
                filteresercizio = QHS.CmpEq("ayear", esercizionew);
                all = true;
            }
            if (ListingType == "treernew")
            {
                string livsupid = esercizionew.ToString().Substring(2) + "R";
                filterc = QHC.CmpEq("paridplaccount", livsupid);
                filtersql = QHS.CmpEq("paridplaccount", livsupid);

                kind = "R";
                filteresercizio = QHS.CmpEq("ayear", esercizionew);
                all = true;
            }

            int maxlevel = 0;
            object o = Conn.DO_READ_VALUE("placcountlevel", filteresercizio , "max(nlevel)");
            if ((o != null) && (o != DBNull.Value)) maxlevel = Convert.ToInt32(o);
	
			if (maxlev>0) {
                myGetData.SetStaticFilter("placcount", QHS.AppAnd(filteresercizio, QHS.CmpLe("nlevel", maxlev)));
                myGetData.SetStaticFilter("placcountview", QHS.AppAnd(filteresercizio, QHS.CmpLe("nlevel", maxlev)));
			}

			TreeViewContoEconomico M = new TreeViewContoEconomico(T, tree, filterc,  filtersql, kind, all,maxlev);
            myGetData.SetStaticFilter("placcountlevel", filteresercizio);
		}

		override public DataRow Get_New_Row(DataRow ParentRow, DataTable T){
			DataTable Levels = T.DataSet.Tables["placcountlevel"];
			if (Levels==null) return null;
			int level; 
			string codprefix;
			string parteconto;
			string ordinestampaprefix;
			if (ParentRow!=null){
				level = Convert.ToInt32(ParentRow["nlevel"])+1;
				codprefix = ParentRow["codeplaccount"].ToString();
				ordinestampaprefix=ParentRow["printingorder"].ToString();
				parteconto=ParentRow["placcpart"].ToString();
				SetDefault(T, "placcpart", parteconto);
			}
			else {
				level = 1;
				codprefix = "";
				ordinestampaprefix = "";
				parteconto = T.Columns["placcpart"].DefaultValue.ToString();
				SetDefault(T,"paridplaccount",GetSys("esercizio").ToString().Substring(2,2)+parteconto);
			}
			if (level > (Levels.Rows.Count-1)){
				MessageBox.Show("Non è possibile inserire un livello inferiore a quello selezionato");
				return null;
			}
			string kind = "A"; //corresponding to "flagreset"
			RowChange.MarkAsAutoincrement(T.Columns["idplaccount"],
				"paridplaccount", null, 4);

			if (kind.ToLower()=="a") {
				SetDefault(T,"codeplaccount", codprefix);
				SetDefault(T,"printingorder", ordinestampaprefix);
			}
			SetDefault(T, "nlevel", level);
			DataRow R = base.Get_New_Row(ParentRow, T);
			return R;
		}


		public override bool IsValid (DataRow R, out string errmess, out string errfield) {
			if (!base.IsValid(R, out errmess, out errfield))
				return false;
			if (R.RowState!=DataRowState.Added) return true;
			return true;
		}

		public class contoeconomico_node_dispatcher : easy_node_dispatcher {
			int maxlevel;
			public contoeconomico_node_dispatcher(
				string level_table, 
				string level_field,
				string descr_level_field,
				string selectable_level_field,
				string descr_field,
				string code_string,
				int maxlevel
				):base(level_table,
				level_field,
				descr_level_field, 
				selectable_level_field, 
				descr_field,code_string) {
				this.maxlevel= maxlevel;
			}		
			override public tree_node GetNode(DataRow Parent, DataRow Child) {
				return new contoeconomico_tree_node("placcountlevel", "nlevel", 
					"description",null,
					"title", "codeplaccount", Child,maxlevel);
			}
		}// class contoeconomico_node_dispatcher
		
		public class contoeconomico_tree_node: easy_tree_node {
			int maxlevel;
			public contoeconomico_tree_node(string level_table, 
				string level_field,
				string descr_level_field,
				string selectable_level_field,
				string descr_field,
				string code_string,
				DataRow R,
				int maxlevel
				):base(level_table,
				descr_level_field,
				descr_level_field,
				selectable_level_field,
				descr_field,
				code_string,
				R) {
				this.maxlevel=maxlevel;
			}

			bool row_exists() {
				if (Row==null) return false;
				if (Row.RowState== DataRowState.Deleted) return false;
				if (Row.RowState== DataRowState.Detached) return false;
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
                if (HasAutoChildren()) return false;
                return true;
            }
		}// class contoeconomico_tree_node

		public class TreeViewContoEconomico : TreeViewManager {
			string kind;
			public int maxlevel=0;
			public TreeViewContoEconomico(DataTable T, TreeView tree, string filterc, string filtersql, 
                            string kind, bool all,int maxlevel):               
				base(T,tree, 
				(all?new easy_node_dispatcher(
				"placcountlevel",
				"nlevel",
				"description",
				null,
				"title",
				"codeplaccount")
				:new contoeconomico_node_dispatcher(
				"placcountlevel",
				"nlevel",
				"description",
				null,
				"title",
				"codeplaccount",
				maxlevel
				)
				),filterc,filtersql) {
				this.kind=kind;
				base.DoubleClickForSelect=false;
			}



			override public TreeNode AddNode(TreeNodeCollection Nodes, TreeNode NewNode) {
				if (Nodes.Equals(tree.Nodes) && (NewNode.Tag!=null)) {
					//searches the right node into which do the additon
					DataRow R = ((tree_node) NewNode.Tag).Row;
					string kind= R["placcpart"].ToString();
					foreach(TreeNode N in Nodes) {
						if (N.Text==kind) {
							return base.AddNode(N.Nodes, NewNode);
						}
					}
				}
				return base.AddNode(Nodes,NewNode);
			}
			public override void FillNodes() {
				base.FillNodes();
				AutoEventsEnabled=false;
				TreeNode [] newroot= new TreeNode[kind.Length];
				int n_root= newroot.Length;
				for (int i=0; i< kind.Length; i++) {
					newroot[i]= new TreeNode(kind.Substring(i,1));
				}
				if (tree.Nodes.Count>0) {
					if (tree.Nodes[0].Tag==null) return;
				}

				while (tree.Nodes.Count>0) {
					TreeNode X = tree.Nodes[0];
					tree.Nodes.RemoveAt(0);
					for (int i=0;i< kind.Length;i++) {
						if (X.Tag==null) continue;
						DataRow R = ((tree_node) X.Tag).Row;
						if (R["placcpart"].ToString()==kind.Substring(i,1)) {
							newroot[i].Nodes.Add(X);
							break;
						}
					}
				}
				for (int i=0;i< kind.Length;i++) {
					tree.Nodes.Add(newroot[i]);
					newroot[i].Expand();
				}
				AutoEventsEnabled=true;
			}	
		}	// class TreeViewContoEconomico
		

	}
}

