
/*
Easy
Copyright (C) 2021 Università degli Studi di Catania (www.unict.it)
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
using fin_treealle;//TreeBilancio
using metaeasylibrary;
using metadatalibrary;
using funzioni_configurazione;
using HelpWeb;
using System.Web;

namespace meta_fin//meta_bilancio//
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
    public class Meta_fin : Meta_easydata {
		public Meta_fin(DataAccess Conn, MetaDataDispatcher Dispatcher):
            base(Conn, Dispatcher, "fin") {		
            Name="Bilancio";
            EditTypes.Add("default");
            EditTypes.Add("treee");
            EditTypes.Add("trees");
            EditTypes.Add("treees");
			//edittype per la selezioni di voce anche non operative
			EditTypes.Add("treealle");
			EditTypes.Add("treealls");

            ListingTypes.Add("treee");
			ListingTypes.Add("treee1");
			ListingTypes.Add("treee2");
			ListingTypes.Add("treee3");
			ListingTypes.Add("treee4");
			ListingTypes.Add("treee5");
			ListingTypes.Add("trees");
			ListingTypes.Add("trees1");
			ListingTypes.Add("trees2");
			ListingTypes.Add("trees3");
			ListingTypes.Add("trees4");
			ListingTypes.Add("trees5");
			ListingTypes.Add("treees");
            ListingTypes.Add("default");
			ListingTypes.Add("treealle");
			ListingTypes.Add("treealls");
            ListingTypes.Add("lista");
        }
		public override DataRow SelectByCondition(string filter, string searchtable){
			if (edit_type=="treealle"||edit_type=="treealls")
				return base.SelectByCondition(filter,"fin");
			int maxlev=0;
			for (int i=1;i<=5;i++){
				if (edit_type == "treee"+i){
					maxlev=i;
					edit_type="treee";
				}
				if (edit_type == "trees"+i){
					maxlev=i;
					edit_type="trees";
				}
			}
			if (maxlev>0){
				filter=filter.Replace("nlevel<=","nlevel=");
				return base.SelectByCondition(filter,"fin");
			}
			//string filternoupb=removefilterupb(filter);
			//int ResultCount = Conn.RUN_SELECT_COUNT("finusable", filternoupb, true);

		    int ResultCount = Conn.RUN_SELECT_COUNT("finview", QHS.AppAnd(filter,QHS.CmpEq("flagusable","S")), true);
			if (ResultCount!=1) return null;
			
			DataTable T2 = Conn.RUN_SELECT("fin",null,null,filter,null,true);
			if (T2==null) return null;
			if (T2.Rows.Count==0) return null;
			return CheckSelectRow(T2.Rows[0]);

		}

		//string removefilterupb(string filter){
		//	int i = filter.IndexOf("(idupb=");
		//	if (i<0) return filter;
		//	int j= filter.IndexOf(")",i+5);
		//    if (filter.Length >= j + 3) {
		//        if (filter.Substring(j, 3).ToLower() == "and") {
		//            j+=3;
		//        }
		//    }
		//    if (filter.Length >= j + 2 && i>=3) {
		//        if (filter[j + 1] == ')' && filter.Substring(i-3, 3).ToLower() == "and") {
		//            i -= 3;//caso in cui c'è ... AND(idupb='asasa'))
		//        }
		//    }
		//	//if (j+1< filter.Length) j+=3;
		//	return filter.Substring(0,i)+filter.Substring(j+1);
		//}

	
        protected override Form GetForm(string FormName){
			if (FormName=="default"){
				Name="Bilancio annuale";
				CanInsertCopy=false;
				ActAsList();                
				IsTree=true;
				DefaultListType="default";
				return MetaData.GetFormByDllName("fin_default");//PinoRana
			}
			if (FormName=="tree"){
				Name= "Selezione voce di bilancio";
				ActAsList();                
				IsTree=true;
				Frm_fin_treealle F =  new Frm_fin_treealle();
				F.tree.Tag= "fin."+FormName;
				return F;
			}
			
            if ((FormName=="treee"||(FormName=="trees")||(FormName=="treees")) ){
                Name= "Selezione voce di bilancio";
                ActAsList();                
                IsTree=true;
                Frm_fin_treealle F =  new Frm_fin_treealle();
                F.tree.Tag= "fin."+FormName;
                return F;
            }

			if ((FormName=="treee1"||(FormName=="treee2")||(FormName=="treee3")||
					(FormName=="treee4")||(FormName=="treee5") ) ){
				Name= "Selezione voce di bilancio";
				ActAsList();                
				IsTree=true;
				Frm_fin_treealle F =  new Frm_fin_treealle();
				F.tree.Tag= "fin."+FormName;
				return F;
			}

			if ((FormName=="trees1"||(FormName=="trees2")||(FormName=="trees3")||
				(FormName=="trees4")||(FormName=="trees5") ) ){
				Name= "Selezione voce di bilancio";
				ActAsList();                
				IsTree=true;
				Frm_fin_treealle F =  new Frm_fin_treealle();
				F.tree.Tag= "fin."+FormName;
				return F;
			}


			if ((FormName=="treealle")||(FormName=="treealls")){
				Name= "Selezione voce di bilancio";
				ActAsList();                
				IsTree=true;
				Frm_fin_treealle F =  new Frm_fin_treealle();
				F.tree.Tag= "fin."+FormName;
				return F;
			}

			return null;
        }
		
		override public void SetDefaults(DataTable Primary){
			base.SetDefaults(Primary);
            int esercizio = Convert.ToInt32(GetSys("esercizio"));

			SetDefault(Primary,"ayear", esercizio);
            //SetDefault(Primary,"flag",0);
		}
        
		override public DataRow Get_New_Row(DataRow ParentRow, DataTable T){
			DataTable Levels = T.DataSet.Tables["finlevel"];
			if (Levels==null) return null;
            RowChange.ClearMySelector(T, "paridfin");
            RowChange.ClearMySelector(T, "ayear");
            RowChange.ClearMySelector(T, "flag");
			bool linear=false;
            CQueryHelper QHC = new CQueryHelper();
			int level; 
			string codprefix;
			//string idprefix;
			string ordinestampaprefix;
			if (ParentRow!=null){
				level = Convert.ToInt32(ParentRow["nlevel"])+1;
				codprefix = ParentRow["codefin"].ToString();
				//idprefix = ParentRow["idbilancio"].ToString();
				ordinestampaprefix=ParentRow["printingorder"].ToString();
                SetDefault(T, "flag", ParentRow["flag"]);
			}
			else {
				level = 1;
				codprefix = "";
				//idprefix="";
				ordinestampaprefix = "";
                //partebilancio = T.Columns["flag"].DefaultValue.ToString();
                SetDefault(T, "paridfin", DBNull.Value);
			}
            int levelmax = CfgFn.GetNoNullInt32(Levels.Compute("max(nlevel)", null));
            if (level > levelmax) {
				//MessageBox. Show("Non è possibile inserire un livello inferiore a quello selezionato");
				return null;
			}
			int len=6;
			//string kind = "A"; //corresponding to "flagreset"
            object esercizio = T.Columns["ayear"].DefaultValue;

			DataRow [] levrow = Levels.Select(QHC.AppAnd(
                QHC.CmpEq("nlevel",level), QHC.CmpEq("ayear",esercizio)));

			if (levrow.Length!=1) return null;
            int levelflag = Convert.ToInt32(levrow[0]["flag"]);

            len = levelflag >> 8; //Convert.ToInt32(levrow[0]["codelen"].ToString());

            //kind = levrow[0]["codekind"].ToString();
            if ((levelflag & 4) == 0) { //non  è di tipo restart
                linear = true;
            }
       
			T.Columns["codefin"].ExtendedProperties["length"]=codprefix.Length+len;
			if ((levelflag&1)!=0 ){				
				//Genera l'ID ad autoincremento, ma poi lo rende editabile. Ossia lo suggerisce soltanto
				RowChange.MarkAsAutoincrement(T.Columns["printingorder"],
					null,ordinestampaprefix,len,linear);
			}

			SetDefault(T, "nlevel", level);
			

			RowChange.MarkAsAutoincrement(T.Columns["idfin"],
				null, null, 9);

            RowChange.ClearMySelector(T,"codefin");
            RowChange.ClearMySelector(T,"printingorder");
            if ((levelflag & 1) != 0)
			{
				SetDefault(T,"codefin", codprefix);
				RowChange.ClearAutoIncrement(T.Columns["codefin"]);
				SetDefault(T,"printingorder", ordinestampaprefix);//??
			}
			else {
				RowChange.MarkAsAutoincrement(T.Columns["codefin"],
					null,codprefix,len,linear);
				RowChange.MarkAsAutoincrement(T.Columns["printingorder"],
					null,ordinestampaprefix,len,linear);

                if (!linear)
				{
                    RowChange.SetMySelector(T.Columns["codefin"], "paridfin", 0);
                    RowChange.SetMySelector(T.Columns["printingorder"], "paridfin", 0);
                    //RowChange.MarkAsAutoincrement(T.Columns["idfin"], null, idprefix, 4);
				}
                RowChange.SetMySelector(T.Columns["codefin"], "ayear", 0);
                RowChange.SetMySelector(T.Columns["printingorder"], "ayear", 0);
			}			
			RowChange.SetMySelector(T.Columns["codefin"],"flag",1);
            RowChange.SetMySelector(T.Columns["printingorder"], "flag", 1);
            DataRow R = base.Get_New_Row(ParentRow, T);
            if ((levelflag & 1) != 0)
				RowChange.ClearAutoIncrement(T.Columns["printingorder"]);
			return R;
		}

		public override DataRow SelectOne(string ListingType, string filter, string searchtable, DataTable Exclude) {
            if (ListingType == "lista") {
                return base.SelectOne("default", filter, "finview", Exclude);
            }

			if (ListingType == "default") {
                string Filter = Conn.SelectCondition("finyearview", true);
                if ((Filter != null) && (Filter.ToString() != "")) {
					return base.SelectOne(ListingType, filter, "finview", Exclude);
                }
                else {
                    return base.SelectOne(ListingType, filter, "finunified", Exclude);
                }
			}
			else{
				return base.SelectOne(ListingType, filter, "fin", Exclude);
			}
		}

        public override void DescribeTree(TreeView tree, DataTable T, string ListingType){
			int maxlev=0;
            CQueryHelper QHC = new CQueryHelper();
            QueryHelper QHS= Conn.GetQueryHelper();

			for (int i=1;i<=5;i++){
				if (ListingType=="treee"+i.ToString()) {
					ListingType="treee";
					maxlev=i;
				}
			}

			for (int i=1;i<=5;i++){
				if (ListingType=="trees"+i.ToString()) {
					ListingType="trees";
					maxlev=i;
				}
			}

			//Aggiorno le intestazioni del DataGrid
			if (ListingType=="tree"||ListingType=="treee"||ListingType=="trees"||ListingType=="treees"||
				ListingType=="treealle"||ListingType=="treealls"){
				base.DescribeColumns(T, ListingType);
				foreach (DataColumn C in T.Columns)
					DescribeAColumn(T, C.ColumnName, "");
				DescribeAColumn(T,"!livello","Livello", "finlevel.description");
				DescribeAColumn(T,"codefin", "Codice");
				DescribeAColumn(T,"title","Denominazione");
				DescribeAColumn(T,"!responsabile","Responsabile", "manager.title");
			}

            base.DescribeTree(tree, T, ListingType);
            int esercizio = Convert.ToInt32( GetSys("esercizio"));
            string filterC = QHC.CmpEq("nlevel", 1);
            string filterSql = QHS.CmpEq("nlevel", 1);
            string kind = "ES";
			bool all = false;

            if (ListingType=="treee"){
                filterSql = QHS.AppAnd(
                    QHS.BitClear("flag",0),
                    QHS.AppAnd(QHS.CmpEq("ayear", esercizio), QHS.IsNull("paridfin")));
                filterC = QHC.AppAnd(
                    QHC.BitClear("flag", 0),
                    QHC.AppAnd(QHC.CmpEq("ayear", esercizio), QHC.IsNull("paridfin")));
                kind = "E";
            }
            if (ListingType=="trees"){
                filterSql = QHS.AppAnd(
                    QHS.BitSet("flag", 0),
                    QHS.AppAnd(QHS.CmpEq("ayear", esercizio), QHS.IsNull("paridfin")));
                filterC = QHC.AppAnd(
                    QHC.BitSet("flag", 0),
                    QHC.AppAnd(QHC.CmpEq("ayear", esercizio), QHC.IsNull("paridfin")));
                kind = "S";
            }
            if (ListingType=="treees"){
                filterSql = QHS.AppAnd(QHS.CmpEq("ayear", esercizio), QHS.IsNull("paridfin"));
                filterC = QHC.AppAnd(QHC.CmpEq("ayear", esercizio), QHC.IsNull("paridfin"));
                kind = "ES";
            }
			if (ListingType=="tree"){
                filterSql = QHS.AppAnd(QHS.CmpEq("ayear", esercizio), QHS.IsNull("paridfin"));
                filterC = QHC.AppAnd(QHC.CmpEq("ayear", esercizio), QHC.IsNull("paridfin"));
                kind = "ES";
			}

			if (ListingType=="treealle"){
                filterSql = QHS.AppAnd(
                    QHS.BitClear("flag", 0),
                    QHS.AppAnd(QHS.CmpEq("ayear", esercizio), QHS.IsNull("paridfin")));
                filterC = QHC.AppAnd(
                    QHC.BitClear("flag", 0),
                    QHC.AppAnd(QHC.CmpEq("ayear", esercizio), QHC.IsNull("paridfin")));
                kind = "E";
				all=true;
			}
			if (ListingType=="treealls"){
                filterSql = QHS.AppAnd(
                    QHS.BitSet("flag", 0),
                    QHS.AppAnd(QHS.CmpEq("ayear", esercizio), QHS.IsNull("paridfin")));
                filterC = QHC.AppAnd(
                    QHC.BitSet("flag", 0),
                    QHC.AppAnd(QHC.CmpEq("ayear", esercizio), QHC.IsNull("paridfin")));
                kind = "S";
				all=true;
			}
			if (maxlev>0) {
				myGetData.SetStaticFilter("fin",QHS.CmpLe("nlevel",maxlev));
                myGetData.SetStaticFilter("finview", QHS.CmpLe("nlevel", maxlev));
			}

			TreeViewBilancio M = new TreeViewBilancio(T, tree, filterC, filterSql, kind, all,maxlev,
                        CfgFn.GetNoNullInt32(GetSys("finusablelevel")));
			myGetData.SetStaticFilter("finlevel",QHS.CmpEq("ayear",GetSys("esercizio")));
        }

        public override void WebDescribeTree(hwTreeView tree, DataTable T, string ListingType) {
            int maxlev = 0;
            CQueryHelper QHC = new CQueryHelper();
            QueryHelper QHS = Conn.GetQueryHelper();

            for (int i = 1; i <= 5; i++) {
                if (ListingType == "treee" + i.ToString()) {
                    ListingType = "treee";
                    maxlev = i;
                }
            }

            for (int i = 1; i <= 5; i++) {
                if (ListingType == "trees" + i.ToString()) {
                    ListingType = "trees";
                    maxlev = i;
                }
            }

            //Aggiorno le intestazioni del DataGrid
            if (ListingType == "tree" || ListingType == "treee" || ListingType == "trees" || ListingType == "treees" ||
                ListingType == "treealle" || ListingType == "treealls") {
                base.DescribeColumns(T, ListingType);
                foreach (DataColumn C in T.Columns)
                    DescribeAColumn(T, C.ColumnName, "");
                DescribeAColumn(T, "!livello", "Livello", "finlevel.description");
                DescribeAColumn(T, "codefin", "Codice");
                DescribeAColumn(T, "title", "Denominazione");
                DescribeAColumn(T, "!responsabile", "Responsabile", "manager.title");
            }

            base.WebDescribeTree(tree, T, ListingType);
            int esercizio = Convert.ToInt32(GetSys("esercizio"));
            string filterC = QHC.CmpEq("nlevel", 1);
            string filterSql = QHS.CmpEq("nlevel", 1);
            string kind = "ES";
            bool all = false;

            if (ListingType == "treee") {
                filterSql = QHS.AppAnd(
                    QHS.BitClear("flag", 0),
                    QHS.AppAnd(QHS.CmpEq("ayear", esercizio), QHS.IsNull("paridfin")));
                filterC = QHC.AppAnd(
                    QHC.BitClear("flag", 0),
                    QHC.AppAnd(QHC.CmpEq("ayear", esercizio), QHC.IsNull("paridfin")));
                kind = "E";
            }
            if (ListingType == "trees") {
                filterSql = QHS.AppAnd(
                    QHS.BitSet("flag", 0),
                    QHS.AppAnd(QHS.CmpEq("ayear", esercizio), QHS.IsNull("paridfin")));
                filterC = QHC.AppAnd(
                    QHC.BitSet("flag", 0),
                    QHC.AppAnd(QHC.CmpEq("ayear", esercizio), QHC.IsNull("paridfin")));
                kind = "S";
            }
            if (ListingType == "treees") {
                filterSql = QHS.AppAnd(QHS.CmpEq("ayear", esercizio), QHS.IsNull("paridfin"));
                filterC = QHC.AppAnd(QHC.CmpEq("ayear", esercizio), QHC.IsNull("paridfin"));
                kind = "ES";
            }
            if (ListingType == "tree") {
                filterSql = QHS.AppAnd(QHS.CmpEq("ayear", esercizio), QHS.IsNull("paridfin"));
                filterC = QHC.AppAnd(QHC.CmpEq("ayear", esercizio), QHC.IsNull("paridfin"));
                kind = "ES";
            }

            if (ListingType == "treealle") {
                filterSql = QHS.AppAnd(
                    QHS.BitClear("flag", 0),
                    QHS.AppAnd(QHS.CmpEq("ayear", esercizio), QHS.IsNull("paridfin")));
                filterC = QHC.AppAnd(
                    QHC.BitClear("flag", 0),
                    QHC.AppAnd(QHC.CmpEq("ayear", esercizio), QHC.IsNull("paridfin")));
                kind = "E";
                all = true;
            }
            if (ListingType == "treealls") {
                filterSql = QHS.AppAnd(
                    QHS.BitSet("flag", 0),
                    QHS.AppAnd(QHS.CmpEq("ayear", esercizio), QHS.IsNull("paridfin")));
                filterC = QHC.AppAnd(
                    QHC.BitSet("flag", 0),
                    QHC.AppAnd(QHC.CmpEq("ayear", esercizio), QHC.IsNull("paridfin")));
                kind = "S";
                all = true;
            }
            if (maxlev > 0) {
                myGetData.SetStaticFilter("fin", QHS.CmpLe("nlevel", maxlev));
                myGetData.SetStaticFilter("finview", QHS.CmpLe("nlevel", maxlev));
            }

            hwTreeViewBilancio M = new hwTreeViewBilancio(T, tree, filterC, filterSql, kind, all, maxlev,
                        CfgFn.GetNoNullInt32(GetSys("finusablelevel")));
            myGetData.SetStaticFilter("finlevel", QHS.CmpEq("ayear", GetSys("esercizio")));
        }


		public override bool IsValid (DataRow R, out string errmess, out string errfield){
			if (!base.IsValid(R, out errmess, out errfield))
				return false;
			if (R.RowState!=DataRowState.Added) return true;
			int lunghezza =Convert.ToInt16(PrimaryDataTable.Columns["codefin"].ExtendedProperties["length"]);
			if (R["codefin"].ToString().Length != lunghezza){
				errmess="Attenzione! Il campo 'codice' deve avere lunghezza "+lunghezza+".";
				errfield="codefin";
				return false;
			}
			return true;
		}
	}


	public class bilancio_node_dispatcher : easy_node_dispatcher{
		int maxlevel;
        int levelop;
		public bilancio_node_dispatcher(
			string level_table, 
			string level_field,
			string descr_level_field,
			int levelop,
			string descr_field,
			string code_string,
			int maxlevel
			):base(level_table,
					level_field,
					descr_level_field, 
					null, 
					descr_field,code_string) {
			this.maxlevel= maxlevel;
            this.levelop = levelop;
		}		

		override public tree_node GetNode(DataRow Parent, DataRow Child){
			return new bilancio_tree_node("finlevel", "nlevel", 
				"description", levelop,
				"title", "codefin", Child,maxlevel);
		}

	}

	public class bilancio_tree_node: easy_tree_node {
		int maxlevel;
        int levelop;
		public bilancio_tree_node(string level_table, 
			string level_field,
			string descr_level_field,
			int levelop,
			string descr_field,
			string code_string,
			DataRow R,
			int maxlevel
			):base(level_table,
			descr_level_field,
			descr_level_field,
			null,
			descr_field,
			code_string,
			R){
			this.maxlevel=maxlevel;
            this.levelop = levelop;
		}

		bool row_exists(){
			if (Row==null) return false;
			if (Row.RowState== DataRowState.Deleted) return false;
			if (Row.RowState== DataRowState.Detached) return false;
			return true;
		}

		/// <summary>
		/// True if "selectable" and with "no chidren" or maxlevel==current level
		/// </summary>
		/// <returns></returns>
		override public bool CanSelect(){
			if (!row_exists()) return false;
			DataRow Lev = LevelRow();
            int thislev = CfgFn.GetNoNullInt32(Lev["nlevel"]);
            if (thislev < levelop) return false;
            //int flag = CfgFn.GetNoNullInt32(Lev["flag"]);
            //if ((flag & 2) == 0) return false;
            if (HasAutoChildren()) return false;
			return true;           
		}

	}

	//alla classe base viene passato nel primo caso (parametro all = true)
	//un node_dispatcher che consente di selezionare anche nodi non operativi
	public class TreeViewBilancio : TreeViewManager {
        string kind;
		public int maxlevel=0;
        public TreeViewBilancio(DataTable T, TreeView tree, string filterc, 
                string filtersql, string kind, bool all,int maxlevel,int levelop):               
            base(T,tree, 
			(all?new easy_node_dispatcher(
				"finlevel",
				"nlevel",
				"description",
				null,
				"title",
				"codefin")
			:new bilancio_node_dispatcher(
				"finlevel",
				"nlevel",
				"description",
				levelop,
				"title",
				"codefin",
				maxlevel
			)
			),filterc,filtersql) {
            this.kind=kind;
			//se all vale true disabilito il doppio click come selezione
			if (all) base.DoubleClickForSelect=false;
        }

		override public TreeNode AddNode(TreeNodeCollection Nodes, TreeNode NewNode){
			if (Nodes.Equals(tree.Nodes) && (NewNode.Tag!=null)){
				//searches the right node into which do the additon
				DataRow R = ((tree_node) NewNode.Tag).Row;
				int skind=  Convert.ToInt32(R["flag"]);
                string kind;
                if ((skind & 1) == 1) 
                    kind = "S";
                else 
                    kind = "E";
				foreach(TreeNode N in Nodes){
					if (N.Text==kind){
						return base.AddNode(N.Nodes, NewNode);
					}
				}
			}
			return base.AddNode(Nodes,NewNode);
		}

        public override void FillNodes(){
			//re-Normalizes tree
//			if (tree.Nodes.Count>0){
//				int noldroots=0;
//				int copied=0;
//				foreach (TreeNode TN1 in tree.Nodes) noldroots+= TN1.Nodes.Count;
//				TreeNode [] OldRoots = new TreeNode[noldroots];
//				foreach (TreeNode TN2 in tree.Nodes){
//					while (TN2.Nodes.Count>0){
//						TreeNode X  = TN2.Nodes[0];
//						OldRoots[copied++]=X;
//						TN2.Nodes.RemoveAt(0);
//					}
//				}
//				tree.Nodes.Clear();
//				for (int i2=0;i2< copied; i2++){
//					tree.Nodes.Add(OldRoots[i2]);
//				}
//			}

            base.FillNodes();
			AutoEventsEnabled=false;
            TreeNode [] newroot= new TreeNode[kind.Length];
            int n_root= newroot.Length;
            for (int i=0; i< kind.Length; i++){
                newroot[i]= new TreeNode(kind.Substring(i,1));
            }
			if (tree.Nodes.Count>0){
				if (tree.Nodes[0].Tag==null) return;
			}

            while (tree.Nodes.Count>0){
                TreeNode X = tree.Nodes[0];
//					TreeNode temp = new TreeNode("temporary");
//					X.Nodes.Add(temp);
//
                tree.Nodes.RemoveAt(0);
                for (int i=0;i< kind.Length;i++){
                    if (X.Tag==null) continue;
                    DataRow R = ((tree_node) X.Tag).Row;
                    int skind = Convert.ToInt32(R["flag"]);
                    string akind;
                    if ((skind & 1) == 1)
                        akind = "S";
                    else
                        akind = "E";

                    if (akind==kind.Substring(i,1)){
                        newroot[i].Nodes.Add(X);
                        break;
                    }
                }
            }
            AutoEventsEnabled=true;
            for (int i=0;i< kind.Length;i++){
//				if (newroot[i].Nodes.Count>0){
					tree.Nodes.Add(newroot[i]);
					newroot[i].Expand();
//				}
            }
			
        }		
    }


    public class hwTreeViewBilancio : hwTreeViewManager {
        string kind;
		public int maxlevel=0;
        public hwTreeViewBilancio(DataTable T, hwTreeView tree, string filterc, 
                string filtersql, string kind, bool all,int maxlevel,int levelop):               
            base(T,tree, 
			(all?new easy_node_dispatcher(
				"finlevel",
				"nlevel",
				"description",
				null,
				"title",
				"codefin")
			:new bilancio_node_dispatcher(
				"finlevel",
				"nlevel",
				"description",
				levelop,
				"title",
				"codefin",
				maxlevel
			)
			),filterc,filtersql) {
            this.kind=kind;
			//se all vale true disabilito il doppio click come selezione
			if (all) base.DoubleClickForSelect=false;
        }


        override public System.Web.UI.WebControls.TreeNode AddNode(
            System.Web.UI.WebControls.TreeNodeCollection Nodes, 
            System.Web.UI.WebControls.TreeNode NewNode,
            tree_node T_N) {
            if (Nodes.Equals(tree.Nodes) && (T_N != null)) {
                //searches the right node into which do the additon
                DataRow R = T_N.Row;
                int skind = Convert.ToInt32(R["flag"]);
                string kind;
                if ((skind & 1) == 1)
                    kind = "S";
                else
                    kind = "E";
                foreach (System.Web.UI.WebControls.TreeNode N in Nodes) {
                    if (N.Text == kind) {
                        return base.AddNode(N.ChildNodes, NewNode, T_N);
                    }
                }
            }
            return base.AddNode(Nodes, NewNode, T_N);
        }

        public override void FillNodes() {
            base.FillNodes();
            AutoEventsEnabled = false;
            System.Web.UI.WebControls.TreeNode[] newroot = new System.Web.UI.WebControls.TreeNode[kind.Length];
            int n_root = newroot.Length;
            for (int i = 0; i < kind.Length; i++) {
                newroot[i] = new System.Web.UI.WebControls.TreeNode(kind.Substring(i, 1));
                tree.Nodes.Add(newroot[i]);
            }
            if (tree.Nodes.Count > 0) {
                System.Web.UI.WebControls.TreeNode TN = tree.Nodes[0] as System.Web.UI.WebControls.TreeNode;
                if (GetTag(TN) == null) return;
            }
            while (tree.Nodes.Count > n_root) {
                System.Web.UI.WebControls.TreeNode X = tree.Nodes[0] as System.Web.UI.WebControls.TreeNode;
                tree_node X_TAG = GetTag(X);
                if (X_TAG == null) {
                    tree.Nodes.RemoveAt(0);
                    continue;
                }
                DataRow R = X_TAG.Row;
                for (int i = 0; i < kind.Length; i++) {
                    int skind = Convert.ToInt32(R["flag"]);
                    string akind;
                    if ((skind & 1) == 1)
                        akind = "S";
                    else
                        akind = "E";

                    if (akind == kind.Substring(i, 1)) {
                        MovSubTree(tree.Nodes, 0, newroot[i]);
                        break;
                    }
                }
            }
            int j = 0;
            for (int i = 0; i < kind.Length; i++) {
                if (newroot[j].ChildNodes.Count > 0) {
                    newroot[j].Expand();
                    j++;
                }
                else {
                    tree.Nodes.RemoveAt(j);
                }
            }
            AutoEventsEnabled = true;
        }		
    }
}

