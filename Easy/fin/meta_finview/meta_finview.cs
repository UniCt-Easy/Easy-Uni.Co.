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
using finview_tree;//bilancioviewtree
using finview_treeupb;
using finview_treealle;
using funzioni_configurazione;
using System.Web;
using HelpWeb;
using finview_trees;

namespace meta_finview {//meta_bilancioview//
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	public class Meta_finview : Meta_easydata {
		int esercizio;
		public Meta_finview(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "finview") {		
			Name="Bilancio";
			EditTypes.Add("tree");
            EditTypes.Add("treealle");
            EditTypes.Add("treealls");
            EditTypes.Add("treeallenew");
            EditTypes.Add("treeallsnew");
			EditTypes.Add("treee");
			EditTypes.Add("trees");
			EditTypes.Add("treees");
			EditTypes.Add("treeenew");
			EditTypes.Add("treesnew");
			EditTypes.Add("treeeupb");
			EditTypes.Add("treesupb");
			EditTypes.Add("upbprevision");
			EditTypes.Add("relation");
            ListingTypes.Add("relation");
            ListingTypes.Add("tree");
            ListingTypes.Add("treealle");
            ListingTypes.Add("treealls");
			ListingTypes.Add("treee");
			ListingTypes.Add("trees");
			ListingTypes.Add("treees");
			ListingTypes.Add("default");
			ListingTypes.Add("manager");
			ListingTypes.Add("treeenew");
			ListingTypes.Add("treesnew");
            ListingTypes.Add("treeallenew");
            ListingTypes.Add("treeallsnew");
			ListingTypes.Add("treeeupb");
			ListingTypes.Add("treesupb");
			ListingTypes.Add("upbprevision");
			EditTypes.Add("treesupbnew");
			ListingTypes.Add("treesupbnew");
			EditTypes.Add("treeeupbnew");
			ListingTypes.Add("treeeupbnew");
            ListingTypes.Add("articolifratelli");// usato nel modulo expense_ct_stornoresidui, ha lo stesso comportamento del default
			
			esercizio=(int) GetSys("esercizio");
		}

		public override bool CanSelect(DataRow R) {
			return DataAccess.CanSelect(Conn, R);
		}

        public override string GetNoRowFoundMessage(string listingtype) {
            if (listingtype == "articolifratelli") {
                return "Residui: non è ammessa la variazione da un capitolo ad un altro";
            }
            return base.GetNoRowFoundMessage(listingtype);
        }

		//string removefilterupb(string filter){
  //          if (filter.IndexOf("AND(idupb IS NULL)")>=0) {
  //              return filter.Replace("AND(idupb IS NULL)", "");
  //          }
		//	int i = filter.IndexOf("(idupb=");
		//	if (i<0) return filter;
		//	int j= filter.IndexOf(")",i+5);
  //          if (filter.Length >= j + 4) {
  //              if (filter.Substring(j, 4).ToLower() == ")and") {
  //                  j += 3;
  //              }
  //          }

		//    if (filter.Length >= j + 2 && i>=3) {
		//        if (filter[j + 1] == ')' && filter.Substring(i-3, 3).ToLower() == "and") {
		//            i -= 3;//caso in cui c'è ... AND(idupb='asasa'))
		//        }
		//    }
		//	//if (j+1< filter.Length) 
  //          return removefilterupb(filter.Substring(0, i) + filter.Substring(j + 1));
		//}

		public override string GetStaticFilter(string ListingType)
		{		
			string filteresercizio,filtraSuUpbLibero;
			//if ((ListingType!="default")&&(ListingType!="upbprevision"))
			if ((ListingType=="tree")||(ListingType=="treee")||(ListingType=="trees")
				||(ListingType=="treees")||(ListingType=="manager")||(ListingType=="treeenew")||(ListingType=="treesnew")
                || (ListingType == "treealle") || (ListingType == "treealls")
                || (ListingType == "treeallenew") || (ListingType == "treeallsnew")
				||(ListingType=="treeeupb")||(ListingType=="treesupb"))
			{
                filteresercizio = QHC.CmpEq("ayear", GetSys("esercizio"));                    
                filtraSuUpbLibero = QHC.AppAnd(filteresercizio,QHC.CmpEq("idupb", "0001"));  
				return filtraSuUpbLibero;
			}
			return base.GetStaticFilter (ListingType);
		}

		public override string GetSorting(string ListingType) 
		{//sa, se il ListingType è default è chiamata la vista: finunified, in caso contrario la vista:finview
			string sorting;
            sorting = "finpart asc, printingorder asc";
            return sorting;
            //if (ListingType!="default") 
            //{
            //sorting = "finpart asc, printingorder asc";
            //    return sorting;
            //}
            //return base.GetSorting (ListingType);
		}


		public override DataRow SelectByCondition(string filter, string searchtable)
		{
            if (edit_type == "treealle" || edit_type == "treealls"  ||
                edit_type == "treeallenew" || edit_type == "treeallsnew"
                )
                return base.SelectByCondition(filter, "finview");

			//string filternoupb= removefilterupb(filter);
		    //int ResultCount = Conn.RUN_SELECT_COUNT("finusable", filternoupb, true);

			int ResultCount = Conn.RUN_SELECT_COUNT("finview", QHS.AppAnd(filter,QHS.CmpEq("flagusable","S")), true);
			if (ResultCount!=1) return null;
			
			DataTable T2 = Conn.RUN_SELECT("finview",null,null,filter,null,true);
			if (T2==null) return null;
			if (T2.Rows.Count==0) return null;
			return CheckSelectRow(T2.Rows[0]);

		}

		protected override Form GetForm(string FormName){

			if (FormName=="tree"){
				Name= "Selezione voce di bilancio";
				ActAsList();                
				IsTree=true;
				Frm_finview_tree F =  new Frm_finview_tree();
				F.tree.Tag= "finview."+FormName;
				return F;
			}


			if ((FormName=="treee"||(FormName=="trees")||(FormName=="treees")||(FormName=="treeenew")||(FormName=="treesnew"))){
				Name= "Selezione voce di bilancio";
				ActAsList();                
				IsTree=true;
				Frm_finview_tree F =  new Frm_finview_tree();
				F.tree.Tag= "finview."+FormName;
				return F;
			}

			if ((FormName == "treeeupb") || (FormName == "treesupb") || (FormName == "treesupbnew")|| (FormName == "treeeupbnew") ) {
				Name = "Selezione voce di bilancio";
				ActAsList();
				IsTree = true;
				DefaultListType = FormName;
				Frm_finview_treeupb F = new Frm_finview_treeupb();
				F.tree.Tag = "finview." + FormName;				
				return F;
			}

			if (FormName == "upbprevision") {
				Name = "bilancio dell'U.P.B.";
				ActAsList();
				IsTree = true;
				DefaultListType = FormName;
				return GetFormByDllName("finview_prevision");
			}
			if (FormName == "relation") 
			{
				Name = "bilancio dell'U.P.B.";
				ActAsList();
				IsTree = true;
				DefaultListType = FormName;
				return GetFormByDllName("finview_prevision");
			}

            if ((FormName == "treealle") || (FormName == "treealls") || (FormName == "treeallenew") || (FormName == "treeallsnew")) {
                Name = "Selezione voce di bilancio";
                ActAsList();
                IsTree = true;
                Frm_finview_treealle F = new Frm_finview_treealle();
                F.tree.Tag = "finview." + FormName;
                return F;
            }

			return null;
		}
        string[] mykey = new string[] { "idfin", "idupb" };
        public override string[] primaryKey() {
            return mykey;
        }
        public override void DescribeColumns(DataTable T, string ListingType){
			base.DescribeColumns(T, ListingType);
            if ((ListingType == "default") || (ListingType == "articolifratelli"))
				{
				foreach (DataColumn C in T.Columns)
					DescribeAColumn(T, C.ColumnName, "",-1);
				DescribeAColumn(T,"ayear",".Esercizio",-1);
				DescribeAColumn(T,"finpart","Parte",1);
				DescribeAColumn(T,"codefin", "Codice",2);
				DescribeAColumn(T, "title","Denominazione",3);
				DescribeAColumn(T, "manager", "Responsabile",4);
				DescribeAColumn(T, "prevision", "Prev. Iniziale",5);
				DescribeAColumn(T, "currentprevision", "Prev. Attuale",6);
				DescribeAColumn(T, "availableprevision", "Prev. Disponibile",7);
				if (Conn!=null){
                    int finkind = CfgFn.GetNoNullInt32(Conn.GetSys("fin_kind"));
					if (finkind==3){
						DescribeAColumn(T, "prevision", "Prev. Iniziale Comp.");
						DescribeAColumn(T, "currentprevision", "Prev. Attuale Comp.");
						DescribeAColumn(T, "availableprevision", "Prev. Disponibile Comp.");
						DescribeAColumn(T, "secondaryprev", "Prev. Iniziale Cassa",8);
						DescribeAColumn(T, "currentsecondaryprev", "Prev. Attuale Cassa",9);
						DescribeAColumn(T, "availablesecondaryprev", "Prev. Disponibile Cassa",10);

					}
				}				
			}
			if ((ListingType == "upbprevision")|| (ListingType == "relation")){			//	+
				foreach (DataColumn C in T.Columns)
					DescribeAColumn(T, C.ColumnName, "",-1);
				DescribeAColumn(T,"finpart","Parte",1);	
				DescribeAColumn(T,"codefin", "Codice",2);
				DescribeAColumn(T,"leveldescr","Livello",3);
				DescribeAColumn(T,"title","Denominazione",4);
				DescribeAColumn(T,"manager","Responsabile",5);
				DescribeAColumn(T, "prevision", "Prev. Iniziale",6);
				DescribeAColumn(T, "currentprevision", "Prev. Attuale ",7);
				DescribeAColumn(T, "availableprevision", "Prev. Disponibile ",8);
				if (Conn!=null)
				{
                    int finkind = CfgFn.GetNoNullInt32(Conn.GetSys("fin_kind"));
                    if (finkind==3)
					{
						DescribeAColumn(T, "prevision", "Prev. Iniziale Comp." );
						DescribeAColumn(T, "currentprevision", "Prev. Attuale Comp.");
						DescribeAColumn(T, "availableprevision", "Prev. Disponibile Comp.");
						DescribeAColumn(T, "secondaryprev", "Prev. Iniziale Cassa",9);
						DescribeAColumn(T, "currentsecondaryprev", "Prev. Attuale Cassa",10);
						DescribeAColumn(T, "availablesecondaryprev", "Prev. Disponibile Cassa",11);
					}
				}
			}

			if (ListingType=="manager"){
				foreach (DataColumn C in T.Columns)
					DescribeAColumn(T, C.ColumnName, "",-1);
				DescribeAColumn(T,"ayear",".Esercizio",-1);
				DescribeAColumn(T,"finpart","Parte",1);
				DescribeAColumn(T,"codefin", "Codice",2);
				DescribeAColumn(T, "title","Denominazione",3);
				DescribeAColumn(T, "upb", "UPB",4);
				DescribeAColumn(T, "prevision", "Prev. Iniziale",5);
				DescribeAColumn(T, "currentprevision", "Prev. Attuale",6);
				DescribeAColumn(T, "availableprevision", "Prev. Disponibile",7);
				if (Conn!=null){
                    int finkind = CfgFn.GetNoNullInt32(Conn.GetSys("fin_kind"));
                    if (finkind==3){
						DescribeAColumn(T, "prevision", "Prev. Iniziale Comp.");
						DescribeAColumn(T, "currentprevision", "Prev. Attuale Comp.");
						DescribeAColumn(T, "availableprevision", "Prev. Disponibile Comp.");
						DescribeAColumn(T, "secondaryprev", "Prev. Iniziale Cassa",8);
						DescribeAColumn(T, "currentsecondaryprev", "Prev. Attuale Cassa",9);
						DescribeAColumn(T, "availablesecondaryprev", "Prev. Disponibile Cassa",10);

					}
				}
				
			}

			if ((ListingType=="tree") || (ListingType=="treee") || (ListingType=="trees") ||
				(ListingType=="treees")||(ListingType=="treeenew")||(ListingType=="treesnew")) {
				foreach (DataColumn C in T.Columns)
					DescribeAColumn(T, C.ColumnName, "");
				DescribeAColumn(T, "leveldescr", "Livello");
				DescribeAColumn(T,"codefin", "Codice");
				DescribeAColumn(T, "title","Denominazione");
				DescribeAColumn(T, "manager", "Responsabile");
			}

			if (ListingType=="tree1") {
				foreach (DataColumn C in T.Columns)
					DescribeAColumn(T, C.ColumnName, "");
				DescribeAColumn(T, "leveldescr", "Livello");
				DescribeAColumn(T,"codefin", "Codice");
				DescribeAColumn(T, "title","Denominazione");
				DescribeAColumn(T, "manager", "Responsabile");
				DescribeAColumn(T, "prevision", "Prev. Iniziale");
				DescribeAColumn(T, "currentprevision", "Prev. Attuale");
				DescribeAColumn(T, "availableprevision", "Prev. Disponibile");
				if (Conn!=null){
                    int finkind = CfgFn.GetNoNullInt32(Conn.GetSys("fin_kind"));
                    if (finkind==3){
						DescribeAColumn(T, "prevision", "Prev. Iniziale Comp.");
						DescribeAColumn(T, "currentprevision", "Prev. Attuale Comp.");
						DescribeAColumn(T, "availableprevision", "Prev. Disponibile Comp.");
						DescribeAColumn(T, "secondaryprev", "Prev. Iniziale Cassa");
						DescribeAColumn(T, "currentsecondaryprev", "Prev. Attuale Cassa");
						DescribeAColumn(T, "availablesecondaryprev", "Prev. Disponibile Cassa");

					}
				}

			}
			if (ListingType=="tree2") {
				foreach (DataColumn C in T.Columns)
					DescribeAColumn(T, C.ColumnName, "");
				DescribeAColumn(T, "leveldescr", "Livello");
				DescribeAColumn(T,"codefin", "Codice");
				DescribeAColumn(T, "title","Denominazione");
				DescribeAColumn(T, "manager", "Responsabile");
				DescribeAColumn(T, "prevision", "Prev. Iniziale");
				DescribeAColumn(T, "currentprevision", "Prev. Attuale");
				DescribeAColumn(T, "availableprevision", "Prev. Disponibile");
				if (Conn!=null){
                    int finkind = CfgFn.GetNoNullInt32(Conn.GetSys("fin_kind"));
                    if (finkind==3){
						DescribeAColumn(T, "prevision", "Prev. Iniziale Comp.");
						DescribeAColumn(T, "currentprevision", "Prev. Attuale Comp.");
						DescribeAColumn(T, "availableprevision", "Prev. Disponibile Comp.");
						DescribeAColumn(T, "secondaryprev", "Prev. Iniziale Cassa");
						DescribeAColumn(T, "currentsecondaryprev", "Prev. Attuale Cassa");
						DescribeAColumn(T, "availablesecondaryprev", "Prev. Disponibile Cassa");

					}
				}
			}

			if((ListingType=="treeeupb") || (ListingType=="treesupb")) {
				foreach(DataColumn C in T.Columns) DescribeAColumn(T, C.ColumnName, "");
				DescribeAColumn(T, "codefin", "Cod. Bilancio");
				DescribeAColumn(T, "finance", "Bilancio");
			}
		}

        public override void WebDescribeTree(HelpWeb.hwTreeView tree, DataTable T, string ListingType)
        {
            if (ListingType == "treeeupb" || ListingType == "treesupb")
            {
                base.DescribeColumns(T, ListingType);
                foreach (DataColumn C in T.Columns)
                    DescribeAColumn(T, C.ColumnName, "");
                DescribeAColumn(T, "codefin", "Codice");
                DescribeAColumn(T, "leveldescr", "Livello");
                DescribeAColumn(T, "title", "Denominazione");
                DescribeAColumn(T, "manager", "Responsabile");
                DescribeAColumn(T, "prevision", "Prev. Iniziale Princ.");
                DescribeAColumn(T, "currentprevision", "Prev. Attuale Princ.");
                DescribeAColumn(T, "availableprevision", "Prev. Disponibile Princ.");
                if (Conn != null)
                {
                    int finkind = CfgFn.GetNoNullInt32(Conn.GetSys("fin_kind"));
                    if (finkind == 3)
                    {
                        DescribeAColumn(T, "secondaryprev", "Prev. Iniziale Second.");
                        DescribeAColumn(T, "currentsecondaryprev", "Prev. Attuale Second.");
                        DescribeAColumn(T, "availablesecondaryprev", "Prev. Disponibile Second.");
                    }
                }

            }
            base.WebDescribeTree(tree, T, ListingType);

            int esercizionew = esercizio + 1;
            string filterC = QHC.CmpEq("nlevel", 1);
            string filtersql = QHS.CmpEq("nlevel", 1);
            string kind = "ES";
            string filteresercizio = QHS.CmpEq("ayear", GetSys("esercizio"));
            bool all = false;

            if (ListingType == "treeeupb")
            {
                filtersql = QHS.AppAnd(
                                  QHS.BitClear("flag", 0),
                                  QHS.AppAnd(QHS.CmpEq("ayear", esercizio), QHS.IsNull("paridfin")));
                filterC = QHC.AppAnd(
                                 QHC.BitClear("flag", 0),
                                 QHC.AppAnd(QHC.CmpEq("ayear", esercizio), QHC.IsNull("paridfin")));
                kind = "E";
            }

            if (ListingType == "treesupb")
            {
                filtersql = QHS.AppAnd(
                                  QHS.BitSet("flag", 0),
                                  QHS.AppAnd(QHS.CmpEq("ayear", esercizio), QHS.IsNull("paridfin")));
                filterC = QHC.AppAnd(
                                 QHC.BitSet("flag", 0),
                                 QHC.AppAnd(QHC.CmpEq("ayear", esercizio), QHC.IsNull("paridfin")));
                kind = "S";
            }

            int maxlevel = 0;
            object o = Conn.DO_READ_VALUE("finlevel", QHS.CmpEq("ayear", GetSys("esercizio")), "max(nlevel)");
            if ((o != null) && (o != DBNull.Value)) maxlevel = Convert.ToInt32(o);
            
            hwTreeViewManager M = new WebTreeViewBilancio(Conn, T, tree, filterC, filtersql, kind, all, maxlevel,
                    CfgFn.GetNoNullInt32(GetSys("finusablelevel")));
            myGetData.SetStaticFilter("finlevel", filteresercizio);
        }

		public override void DescribeTree(TreeView tree, DataTable T, string ListingType){
			//Aggiorno le intestazioni del DataGrid
			int esercizio = Convert.ToInt32(GetSys("esercizio"));

			if (ListingType == "tree" || ListingType == "treee" ||  ListingType == "treesupbnew"||ListingType == "treeeupbnew"||
				ListingType == "trees" || ListingType == "treees" ||
				ListingType == "treeenew" || ListingType == "treesnew" ||
				ListingType == "treeeupb" || ListingType == "treesupb" ||
                ListingType=="treealle" || ListingType=="treealls" ||
                ListingType == "treeallenew" || ListingType == "treeallsnew" ||
				ListingType == "upbprevision"){
				base.DescribeColumns(T, ListingType);
				foreach (DataColumn C in T.Columns)
					DescribeAColumn(T, C.ColumnName, "");
				DescribeAColumn(T,"codefin", "Codice");
				DescribeAColumn(T,"leveldescr","Livello");
				DescribeAColumn(T,"title","Denominazione");
				DescribeAColumn(T,"manager","Responsabile");
                DescribeAColumn(T, "cupcode", "CUP");
				DescribeAColumn(T, "prevision", "Prev. Iniziale Princ.");
				DescribeAColumn(T, "currentprevision", "Prev. Attuale Princ.");
				DescribeAColumn(T, "availableprevision", "Prev. Disponibile Princ.");
				if (Conn!=null){
                    int finkind = CfgFn.GetNoNullInt32(Conn.GetSys("fin_kind"));
                    if (finkind==3){
						DescribeAColumn(T, "secondaryprev", "Prev. Iniziale Second.");
						DescribeAColumn(T, "currentsecondaryprev", "Prev. Attuale Second.");
						DescribeAColumn(T, "availablesecondaryprev", "Prev. Disponibile Second.");
					}
				}
			}

			base.DescribeTree(tree, T, ListingType);
			
			int esercizionew = esercizio + 1;
			string filterC=QHC.CmpEq("nlevel",1);
            string filtersql = QHS.CmpEq("nlevel", 1);
            string kind = "ES";
            string filteresercizio = QHS.CmpEq("ayear", GetSys("esercizio"));
			if (ListingType=="treee"){
                filtersql = QHS.AppAnd(
                                 QHS.BitClear("flag", 0),
                                 QHS.AppAnd(QHS.CmpEq("ayear", esercizio), QHS.IsNull("paridfin")));
                filterC = QHC.AppAnd(
                                 QHC.BitClear("flag", 0),
                                 QHC.AppAnd(QHC.CmpEq("ayear", esercizio), QHC.IsNull("paridfin")));
                kind = "E";
			}
			if (ListingType=="trees"){
                filtersql = QHS.AppAnd(
                                 QHS.BitSet("flag", 0),
                                 QHS.AppAnd(QHS.CmpEq("ayear", esercizio), QHS.IsNull("paridfin")));
                filterC = QHC.AppAnd(
                                 QHC.BitSet("flag", 0),
                                 QHC.AppAnd(QHC.CmpEq("ayear", esercizio), QHC.IsNull("paridfin")));
                kind = "S";
			}
			if (ListingType=="treees"){
                //filter="(nlevel='1')";
				kind="ES";
			}
			if (ListingType=="tree"){
                //filter="(nlevel='1')";
				kind="ES";
			}
			if (ListingType=="treeenew") {

                filtersql = QHS.AppAnd(
                                 QHS.BitClear("flag", 0),
                                 QHS.AppAnd(QHS.CmpEq("ayear", esercizionew), QHS.IsNull("paridfin")));
                filterC = QHC.AppAnd(
                                 QHC.BitClear("flag", 0),
                                 QHC.AppAnd(QHC.CmpEq("ayear", esercizionew), QHC.IsNull("paridfin")));
                kind = "E";
                filteresercizio = QHS.CmpEq("ayear", esercizionew);
			}
			if (ListingType=="treeeupbnew") 
			{

                filtersql = QHS.AppAnd(
                                  QHS.BitClear("flag", 0),
                                  QHS.AppAnd(QHS.CmpEq("ayear", esercizionew), QHS.IsNull("paridfin")));
                filterC = QHC.AppAnd(
                                 QHC.BitClear("flag", 0),
                                 QHC.AppAnd(QHC.CmpEq("ayear", esercizionew), QHC.IsNull("paridfin")));
                kind = "E";
                filteresercizio = QHS.CmpEq("ayear", esercizionew);
            }
			
			if (ListingType=="treesnew") {
                filtersql = QHS.AppAnd(
                                  QHS.BitSet("flag", 0),
                                  QHS.AppAnd(QHS.CmpEq("ayear", esercizionew), QHS.IsNull("paridfin")));
                filterC = QHC.AppAnd(
                                 QHC.BitSet("flag", 0),
                                 QHC.AppAnd(QHC.CmpEq("ayear", esercizionew), QHC.IsNull("paridfin")));
                kind = "S";
                filteresercizio = QHS.CmpEq("ayear", esercizionew);
            }
			if (ListingType=="treesupbnew") 
			{
                filtersql = QHS.AppAnd(
                                  QHS.BitSet("flag", 0),
                                  QHS.AppAnd(QHS.CmpEq("ayear", esercizionew), QHS.IsNull("paridfin")));
                filterC = QHC.AppAnd(
                                 QHC.BitSet("flag", 0),
                                 QHC.AppAnd(QHC.CmpEq("ayear", esercizionew), QHC.IsNull("paridfin")));
                kind = "S";
                filteresercizio = QHS.CmpEq("ayear", esercizionew);
            }
			if (ListingType == "treeeupb") {
                filtersql = QHS.AppAnd(
                                  QHS.BitClear("flag", 0),
                                  QHS.AppAnd(QHS.CmpEq("ayear", esercizio), QHS.IsNull("paridfin")));
                filterC = QHC.AppAnd(
                                 QHC.BitClear("flag", 0),
                                 QHC.AppAnd(QHC.CmpEq("ayear", esercizio), QHC.IsNull("paridfin")));
                kind = "E";
			}

			if (ListingType == "treesupb") {
                filtersql = QHS.AppAnd(
                                  QHS.BitSet("flag", 0),
                                  QHS.AppAnd(QHS.CmpEq("ayear", esercizio), QHS.IsNull("paridfin")));
                filterC = QHC.AppAnd(
                                 QHC.BitSet("flag", 0),
                                 QHC.AppAnd(QHC.CmpEq("ayear", esercizio), QHC.IsNull("paridfin")));
                kind = "S";
			}

			if (ListingType == "upbprevision") {
                filtersql = QHS.AppAnd(QHS.CmpEq("ayear", esercizio), QHS.IsNull("paridfin"));
                filterC = QHC.AppAnd(QHC.CmpEq("ayear", esercizio), QHC.IsNull("paridfin"));
				kind = "ES";
			}

            bool all = false;

            if (ListingType == "treealle") {
                filtersql = QHS.AppAnd(
                                  QHS.BitClear("flag", 0),
                                  QHS.AppAnd(QHS.CmpEq("ayear", esercizio), QHS.IsNull("paridfin")));
                filterC = QHC.AppAnd(
                                 QHC.BitClear("flag", 0),
                                 QHC.AppAnd(QHC.CmpEq("ayear", esercizio), QHC.IsNull("paridfin")));
                kind = "E";
                all = true;
            }
            if (ListingType == "treealls") {
                filtersql = QHS.AppAnd(
                                  QHS.BitSet("flag", 0),
                                  QHS.AppAnd(QHS.CmpEq("ayear", esercizio), QHS.IsNull("paridfin")));
                filterC = QHC.AppAnd(
                                 QHC.BitSet("flag", 0),
                                 QHC.AppAnd(QHC.CmpEq("ayear", esercizio), QHC.IsNull("paridfin")));
                kind = "S";
                all = true;
            }

            if (ListingType == "treeallenew") {
                filtersql = QHS.AppAnd(
                                  QHS.BitClear("flag", 0),
                                  QHS.AppAnd(QHS.CmpEq("ayear", esercizionew), QHS.IsNull("paridfin")));
                filterC = QHC.AppAnd(
                                 QHC.BitClear("flag", 0),
                                 QHC.AppAnd(QHC.CmpEq("ayear", esercizionew), QHC.IsNull("paridfin")));
                kind = "E";
                all = true;
            }
            if (ListingType == "treeallsnew") {
                filtersql = QHS.AppAnd(
                                  QHS.BitSet("flag", 0),
                                  QHS.AppAnd(QHS.CmpEq("ayear", esercizionew), QHS.IsNull("paridfin")));
                filterC = QHC.AppAnd(
                                 QHC.BitSet("flag", 0),
                                 QHC.AppAnd(QHC.CmpEq("ayear", esercizionew), QHC.IsNull("paridfin")));
                kind = "S";
                all = true;
            }
            int maxlevel = 0;
			object o = Conn.DO_READ_VALUE("finlevel",QHS.CmpEq("ayear", GetSys("esercizio")),"max(nlevel)");
			if ((o != null) && (o != DBNull.Value)) maxlevel = Convert.ToInt32(o);
			TreeViewManager M = new TreeViewBilancio(Conn, T, tree, filterC, filtersql, kind, all, maxlevel,
                    CfgFn.GetNoNullInt32(GetSys("finusablelevel")));
			myGetData.SetStaticFilter("finlevel",filteresercizio);
		}
	}

	public class bilancio_tree_node: easy_tree_node {
		DataAccess Conn;
		int maxlevel;
        int levelop;
        public bilancio_tree_node(string level_table, 
			string level_field,
			string descr_level_field,
			int  levelop,
			string descr_field,
			string code_string,
			DataRow R,
			int maxlevel,
			DataAccess Conn
			):base(level_table,
			descr_level_field,
			descr_level_field,
			null,
			descr_field,
			code_string,
			R){
			this.maxlevel=maxlevel;
            this.levelop = levelop;
			this.Conn = Conn;
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
        override public bool CanSelect () {
            if (!row_exists()) return false;
            DataRow Lev = LevelRow();
            int thislev = CfgFn.GetNoNullInt32(Lev["nlevel"]);
            if (thislev < levelop) return false;
            //int flag = CfgFn.GetNoNullInt32(Lev["flag"]);
            //if ((flag & 2) == 0) return false;
            if (HasAutoChildren()) return false;
            QueryHelper QHS = Conn.GetQueryHelper();
            if (Conn.RUN_SELECT_COUNT("finusable", QHS.CmpEq("idfin", this.Row["idfin"]), false) == 0) return false;
            return true;
        }
	}

	public class bilancio_node_dispatcher : easy_node_dispatcher{
		DataAccess Conn;
		int maxlevel;
        int levelop;
		public bilancio_node_dispatcher(
			string level_table, 
			string level_field,
			string descr_level_field,
            int levelop,
			string descr_field,
			string code_string,
			int maxlevel,
			DataAccess Conn
			):base(level_table,
			level_field,
			descr_level_field, 
			null, 
			descr_field,code_string) {
			this.maxlevel= maxlevel;
            this.levelop = levelop;
			this.Conn = Conn;
		}		

		override public tree_node GetNode(DataRow Parent, DataRow Child){
			return new bilancio_tree_node("finlevel", "nlevel", 
				"description", levelop,
				"title", "codefin", Child,maxlevel,Conn);
		}
	}

    public class WebTreeViewBilancio : hwTreeViewManager
    {
        string kind;
        public int maxlevel = 0;
        		public WebTreeViewBilancio(DataAccess Conn, DataTable T, hwTreeView tree, string filterc,string filtersql, 
                            string kind, bool all, int maxlevel,int levelop):               
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
			maxlevel,
			Conn
            )
			),filterc,filtersql) {
			this.kind=kind;
            if (all) base.DoubleClickForSelect = false;
		}

        override public System.Web.UI.WebControls.TreeNode AddNode(
            System.Web.UI.WebControls.TreeNodeCollection Nodes, 
            System.Web.UI.WebControls.TreeNode NewNode,
            tree_node T_N)
        {
            if (Nodes.Equals(tree.Nodes) && (T_N != null)) {
				//searches the right node into which do the additon
                DataRow R = T_N.Row;
				string kind= R["finpart"].ToString();
                foreach (System.Web.UI.WebControls.TreeNode N in Nodes)
                {
					if (N.Text==kind){
						return base.AddNode(N.ChildNodes, NewNode,T_N);
					}
				}
			}
			return base.AddNode(Nodes,NewNode,T_N);
		}

		public override void FillNodes(){
			base.FillNodes();
			AutoEventsEnabled=false;
            System.Web.UI.WebControls.TreeNode[] newroot = new System.Web.UI.WebControls.TreeNode[kind.Length];
			int n_root= newroot.Length;
			for (int i=0; i< kind.Length; i++){
                newroot[i] = new System.Web.UI.WebControls.TreeNode(kind.Substring(i, 1));
                tree.Nodes.Add(newroot[i]);
			}
			if (tree.Nodes.Count>0){
                System.Web.UI.WebControls.TreeNode TN = tree.Nodes[0] as System.Web.UI.WebControls.TreeNode;
				if (GetTag(TN)==null) return;
			}
            while (tree.Nodes.Count > n_root) {
                System.Web.UI.WebControls.TreeNode X = tree.Nodes[0] as System.Web.UI.WebControls.TreeNode;
                tree_node X_TAG = GetTag(X);
                if (X_TAG == null) {
                    tree.Nodes.RemoveAt(0);
                    continue;
                }
               DataRow R = X_TAG.Row;
				for (int i=0;i< kind.Length;i++){
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
			for (int i=0;i< kind.Length;i++){
                if (newroot[j].ChildNodes.Count > 0) {
                    newroot[j].Expand();
                    j++;
                }
                else {
                    tree.Nodes.RemoveAt(j);
                }
			}
			AutoEventsEnabled=true;
		}		
	}

	public class TreeViewBilancio : TreeViewManager {
		string kind;
		public int maxlevel=0;
		public TreeViewBilancio(DataAccess Conn, DataTable T, TreeView tree, string filterc,string filtersql, 
                            string kind, bool all, int maxlevel,int levelop):               
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
			maxlevel,
			Conn
            )
			),filterc,filtersql) {
			this.kind=kind;
            if (all) base.DoubleClickForSelect = false;
		}

		override public TreeNode AddNode(TreeNodeCollection Nodes, TreeNode NewNode){
			if (Nodes.Equals(tree.Nodes) && (NewNode.Tag!=null)){
				//searches the right node into which do the additon
				DataRow R = ((tree_node) NewNode.Tag).Row;
				string kind= R["finpart"].ToString();
				foreach(TreeNode N in Nodes){
					if (N.Text==kind){
						return base.AddNode(N.Nodes, NewNode);
					}
				}
			}
			return base.AddNode(Nodes,NewNode);
		}

		public override void FillNodes(){
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
				tree.Nodes.RemoveAt(0);
				for (int i=0;i< kind.Length;i++){
					if (X.Tag==null) continue;

                    DataRow R = ((tree_node)X.Tag).Row;
                    int skind = Convert.ToInt32(R["flag"]);
                    string akind;
                    if ((skind & 1) == 1)
                        akind = "S";
                    else
                        akind = "E";

                    if (akind == kind.Substring(i, 1)) {
                        newroot[i].Nodes.Add(X);
                        break;
                    }
				}
			}
			for (int i=0;i< kind.Length;i++){
				if (newroot[i].Nodes.Count>0){
					tree.Nodes.Add(newroot[i]);
					newroot[i].Expand();
				}
			}
			AutoEventsEnabled=true;
		}		
	}
}