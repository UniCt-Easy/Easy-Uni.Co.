
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
using System.Windows.Forms;
using metadatalibrary;
using metaeasylibrary;
//Pino: using classinventario; diventato inutile
using System.Data;
using funzioni_configurazione;

namespace meta_inventorytree//meta_classinventario//
{
	/// <summary>
	/// Summary description for causalescaricoinventario.
	/// </summary>
	public class Meta_inventorytree : Meta_easydata {
		public Meta_inventorytree(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "inventorytree") {		
			EditTypes.Add("default");
            EditTypes.Add("uniforma");
			ListingTypes.Add("default");
            ListingTypes.Add("checkimport");
		}
		
		protected override Form GetForm(string FormName){
			if (FormName=="default"){
				Name="Classificazione inventariale";
				CanInsertCopy=false;
				ActAsList();                
				IsTree=true;
				DefaultListType="default";
				return MetaData.GetFormByDllName("inventorytree_default");//PinoRana
			}
            if (FormName == "uniforma") {
                Name = "Uniformazione della classificazione inventariale";
                return GetFormByDllName("inventorytree_uniforma");
            }
			return null;
		}

		override public DataRow Get_New_Row(DataRow ParentRow, DataTable T){
			DataTable Levels = T.DataSet.Tables["inventorysortinglevel"];
			if (Levels==null) return null;
            RowChange.ClearMySelector(T, "paridinv");
          	bool linear=false;
            CQueryHelper QHC = new CQueryHelper();
			int level; 
			string codprefix;
			if (ParentRow!=null){
				level = Convert.ToInt32(ParentRow["nlevel"])+1;
				codprefix = ParentRow["codeinv"].ToString();
                //SetDefault(T, "flag", ParentRow["flag"]);
			}
			else {
				level = 1;
				codprefix = "";
                SetDefault(T, "paridinv", DBNull.Value);
			}
            int levelmax = CfgFn.GetNoNullInt32(Levels.Compute("max(nlevel)",null));
			if (level> levelmax){
                //MetaFactory.factory.getSingleton<IMessageShower>(). Show("Non è possibile inserire un livello inferiore a quello selezionato");
				return null;
			}
			int len=6;
			//string kind = "A";
            DataRow[] levrow = Levels.Select(QHC.CmpEq("nlevel", level));

			if (levrow.Length!=1) return null;
			
			len = Convert.ToInt32(levrow[0]["codelen"].ToString());
            byte flag = CfgFn.GetNoNullByte(levrow[0]["flag"]);
            
            if ((flag & 4) == 0) { //manuale
				linear=true;
			}

			T.Columns["codeinv"].ExtendedProperties["length"]=codprefix.Length+len;
			
			SetDefault(T, "nlevel", level);

			RowChange.MarkAsAutoincrement(T.Columns["idinv"],null, null, 4);

            if ((flag & 1) != 0){ // automatica
				SetDefault(T,"codeinv", codprefix);
				RowChange.ClearAutoIncrement(T.Columns["codeinv"]);
			}
			else {
				RowChange.MarkAsAutoincrement(T.Columns["codeinv"],
					null,codprefix,len,linear);
			}			
			return base.Get_New_Row(ParentRow, T);
		}

		public override void DescribeColumns(DataTable T, string ListingType){
			base.DescribeColumns(T, ListingType);
			if (ListingType=="default"){
				foreach (DataColumn C in T.Columns) 
					DescribeAColumn(T,C.ColumnName,"");

				DescribeAColumn(T,"codeinv","Codice");
				DescribeAColumn(T,"description","Denominazione");
			}
            if (ListingType == "checkimport"){
                foreach (DataColumn C in T.Columns)
                    DescribeAColumn(T, C.ColumnName, "", -1);
                int nPos = 1;
                DescribeAColumn(T, "codeinv", "Codice", nPos++);
                DescribeAColumn(T, "description", "Denominazione", nPos++);
            }
		}

		public override bool IsValid (DataRow R, out string errmess, out string errfield){
			if (!base.IsValid(R, out errmess, out errfield))
				return false;
			if (R.RowState!=DataRowState.Added) return true;
			int lunghezza =(int)PrimaryDataTable.Columns["codeinv"].ExtendedProperties["length"];
			if (R["codeinv"].ToString().Length != lunghezza){
				errmess="Attenzione! Il campo 'codice' deve avere lunghezza "+lunghezza+".";
				errfield="codeinv";
				return false;
			}
			return true;
		}

        public override DataRow SelectOne(string ListingType, string filter, string searchtable, DataTable Exclude)
        {
            if (ListingType == "default")
            {
                return base.SelectOne(ListingType, filter, "inventorytreeview", Exclude);
            }
            return base.SelectOne(ListingType, filter, "inventorytree", Exclude);
        }		

        public class inventory_node_dispatcher : easy_node_dispatcher
        {
            
            public inventory_node_dispatcher(
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
                return new inventory_tree_node("inventorysortinglevel", "nlevel",
                    "description",null,
                    "description", "codeinv",Child);
            }

        }

        public class inventory_tree_node : easy_tree_node
        {
            public inventory_tree_node(string level_table, 
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

		public override void DescribeTree(TreeView tree, DataTable T, string ListingType){
			base.DescribeTree(tree, T, ListingType);
			string filterc= QHC.CmpEq("nlevel",1);
            string filtersql = QHS.CmpEq("nlevel",1);

            inventory_node_dispatcher D = new inventory_node_dispatcher(
				"inventorysortinglevel",
				"nlevel",
				"description",
				"flag",
				"description",
				"codeinv"
				);
			TreeViewManager M = new TreeViewClassInventario(T, tree, filterc,filtersql);
			
		}
	}

    public class TreeViewClassInventario : TreeViewManager
    {
        public TreeViewClassInventario(DataTable T, TreeView tree, string filterc, string filtersql)
            :
            base(T, tree, new easy_node_dispatcher(
            "inventorysortinglevel",
            "nlevel",
            "description",
            null,
            "description",
            "codeinv"
            ), filterc, filtersql) { }


		override public TreeNode AddNode(TreeNodeCollection Nodes, TreeNode NewNode) {
			if (Nodes.Equals(tree.Nodes) && (NewNode.Tag!=null)&& (tree.Nodes.Count>0)) {
				if (tree.Nodes[0].Tag==null) return base.AddNode(tree.Nodes[0].Nodes, NewNode);
			}
			return base.AddNode(Nodes,NewNode);
		}

		public override void FillNodes() {

			base.FillNodes();
			AutoEventsEnabled=false;
			TreeNode [] newroot= new TreeNode[1];
			newroot[0]= new TreeNode("Classificazione inventariale");
			if (tree.Nodes.Count>0) {
				if (tree.Nodes[0].Tag==null) return;
			}

			while (tree.Nodes.Count>0) {
				TreeNode X = tree.Nodes[0];
				tree.Nodes.RemoveAt(0);
				if (X.Tag==null) continue;
				DataRow R = ((tree_node) X.Tag).Row;
				newroot[0].Nodes.Add(X);
			}
			tree.Nodes.Add(newroot[0]);
			newroot[0].Expand();
			AutoEventsEnabled=true;
		}		
	}
}
