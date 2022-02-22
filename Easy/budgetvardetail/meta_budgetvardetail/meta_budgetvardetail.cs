
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
using System.Data;
using metaeasylibrary;
using metadatalibrary;
using funzioni_configurazione;


namespace meta_budgetvardetail
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	public class Meta_budgetvardetail : Meta_easydata {
		public Meta_budgetvardetail(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "budgetvardetail") {
			EditTypes.Add("default");
			EditTypes.Add("single");
			ListingTypes.Add("default");
            ListingTypes.Add("lista");
            ListingTypes.Add("listaestesa");
            // i seguenti listing type sono da tenere presente nel caso vogliamo aggiungere nuovi grid al form delle classificazioni
            // e dell'UPB
            ListingTypes.Add("classificazione");
            ListingTypes.Add("upb");
		}

		protected override Form GetForm(string FormName){
			if (FormName=="default") {
				DefaultListType="listaestesa";
				Name = "Dettaglio variazione di Budget";
				return MetaData.GetFormByDllName("budgetvardetail_default");
			}
			if (FormName=="single") {
				Name = "Dettaglio";
				return MetaData.GetFormByDllName("budgetvardetail_single");
			}
			return null;
		}			
	
		public override void SetDefaults(DataTable PrimaryTable){
			base.SetDefaults(PrimaryTable);
			SetDefault(PrimaryTable, "ybudgetvar", GetSys("esercizio"));
		}
		override public DataRow Get_New_Row(DataRow ParentRow, DataTable T)
		{	
            RowChange.SetSelector(T, "ybudgetvar");
            RowChange.SetSelector(T, "nbudgetvar");
            RowChange.MarkAsAutoincrement(T.Columns["rownum"], null, null, 6);
			DataRow R = base.Get_New_Row(ParentRow, T);
			return R;

		}

        public override void CalculateFields(System.Data.DataRow R, string listtype) {
            //string filterSorting = "";
            //string filterBudgetVar = "";
         
            //bool sortingInDS = false;
            //if (R.Table.DataSet.Tables["sorting"] != null) {
            //    DataTable tSorting = R.Table.DataSet.Tables["sorting"];
            //    filterSorting = QHC.CmpEq("idsor", R["idsor"]);
            //    if (tSorting.Select(filterFin).Length > 0) {
            //        DataRow rSorting = tSorting.Select(filterSorting)[0];
            //        sortingInDS = true;
            //    }
            //}

            //bool budgetVarInDS = false;
            //if (R.Table.DataSet.Tables["budgetvar"] != null)
            //{
            //    DataTable tBudgetVar = R.Table.DataSet.Tables["budgetvar"];
            //    filterBudgetVar = QHC.AppAnd(QHC.CmpEq("ybudgetvar", R["ybudgetvar"]),
            //                              QHC.CmpEq("nbudgetvar", R["nbudgetvar"]));
                 
            //    if (tBudgetVar.Select(filterBudgetVar).Length > 0)
            //    {
            //        DataRow rBudgetVar = tBudgetVar.Select(filterBudgetVar)[0];
            //        budgetVarInDS = true;
            //    }
            //}
            //if (!sortingInDS)
            //{
            //    filterSorting = QHS.CmpEq("idsor", R["idsor"]);
            //    flagObj = Conn.DO_READ_VALUE("sorting", filterSorting, "flag");
            //}
   
		}
		
		public override void DescribeColumns(DataTable T, string listtype){
			base.DescribeColumns(T, listtype);
			if (listtype=="default") {
                foreach (DataColumn C in T.Columns){
                    DescribeAColumn(T, C.ColumnName, "", -1);
                }
                int nPos = 1;
                DescribeAColumn(T, "!upb", "U.P.B.", "upb.codeupb", nPos++);
                DescribeAColumn(T, "!sortcode", "Voce di classificazione", "sorting.sortcode", nPos++);
                DescribeAColumn(T, "amount", "Importo", nPos++);
                DescribeAColumn(T, "description", "Descrizione", nPos++);
                //ComputeRowsAs(T, listtype);
			}

            if (listtype == "lista")
            {
                foreach (DataColumn C in T.Columns)
                {
                    DescribeAColumn(T, C.ColumnName, "", -1);
                }
                int nPos = 1;
                DescribeAColumn(T, "ybudgetvar", "Eserc. variaz.", nPos++);
                DescribeAColumn(T, "nbudgetvar", "Num. variaz.", nPos++);
                DescribeAColumn(T, "amount", "Importo", nPos++);
                DescribeAColumn(T, "description", "Descrizione", nPos++);
            }

            //if (listtype == "listaweb")
            //{
            //    foreach (DataColumn C in T.Columns)
            //    {
            //        DescribeAColumn(T, C.ColumnName, "", -1);
            //    }
            //    int nPos = 1;
            //    DescribeAColumn(T, "!codicebilancio", "Voce di bilancio", "fin.codefin", nPos++);
            //    DescribeAColumn(T, "description", "Descrizione", nPos++);
            //    DescribeAColumn(T, "!entrata", "Entrata", nPos++);
            //    DescribeAColumn(T, "!spesa", "Spesa", nPos++);
            //    DescribeAColumn(T, "!upb", "U.P.B.", "upb.codeupb", nPos++);
            //    DescribeAColumn(T, "!finanziamento", "Finanziamento", "underwriting.title", nPos++);
            //    DescribeAColumn(T, "limit", "Limite Variazione", nPos++);
            //    DescribeAColumn(T, "!semaphore", "Limite Superato", "fin.limit", nPos++);
            //    ComputeRowsAs(T, listtype);
            //}

            //if (listtype == "bilancio")
            //{
            //    foreach (DataColumn C in T.Columns)
            //    {
            //        DescribeAColumn(T, C.ColumnName, "", -1);
            //    }
            //    int nPos = 1;
            //    DescribeAColumn(T, "!variationkind", "Tipo Var.", nPos++);
            //    DescribeAColumn(T, "nvar", "Num. Prot.", nPos++);
            //    DescribeAColumn(T, "!nofficial", "Num. Var. Uff.", "budgetvar.nofficial", nPos++);
            //    DescribeAColumn(T, "!upb", "U.P.B.", "upb.codeupb", nPos++);
            //    DescribeAColumn(T, "!finanziamento", "Finanziamento", "underwriting.title", nPos++);
            //    DescribeAColumn(T, "description", "Descrizione", nPos++);
            //    if (CfgFn.NomePrevisionePrincipale(Conn) != null)
            //         DescribeAColumn(T, "!prev_competenza", "Prev. " + CfgFn.NomePrevisionePrincipale(Conn), nPos++);
            //    if (CfgFn.NomePrevisioneSecondaria(Conn)!= null)
            //         DescribeAColumn(T, "!prev_cassa", "Prev. " + CfgFn.NomePrevisioneSecondaria(Conn), nPos++);
            //    DescribeAColumn(T, "!crediti", "Dot. Crediti", nPos++);
            //    DescribeAColumn(T, "!cassa", "Dot.Cassa", nPos++);
            //    ComputeRowsAs(T, listtype);
            //    FilterRows(T);
            //}

            //if (listtype == "upb")
            //{
            //    foreach (DataColumn C in T.Columns)
            //    {
            //        DescribeAColumn(T, C.ColumnName, "", -1);
            //    }
            //    int nPos = 1;
            //    DescribeAColumn(T, "!variationkind", "Tipo Var.", nPos++);
            //    DescribeAColumn(T, "nvar", "Num. Prot.", nPos++);
            //    DescribeAColumn(T, "!nofficial", "Num. Var. Uff.", "budgetvar.nofficial", nPos++);
            //    DescribeAColumn(T, "!E/S", "E/S", nPos++);
            //    DescribeAColumn(T, "!codicebilancio", "Voce di bilancio", "fin.codefin", nPos++);
            //    DescribeAColumn(T, "!finanziamento", "Finanziamento", "underwriting.title", nPos++);
            //    DescribeAColumn(T, "description", "Descrizione", nPos++);
            //    if (CfgFn.NomePrevisionePrincipale(Conn) != null)
            //        DescribeAColumn(T, "!prev_competenza", "Prev. " + CfgFn.NomePrevisionePrincipale(Conn), nPos++);
            //    if (CfgFn.NomePrevisioneSecondaria(Conn) != null)
            //        DescribeAColumn(T, "!prev_cassa", "Prev. " + CfgFn.NomePrevisioneSecondaria(Conn), nPos++);
            //    DescribeAColumn(T, "!crediti", "Dot. Crediti", nPos++);
            //    DescribeAColumn(T, "!cassa", "Dot.Cassa", nPos++);
            //    ComputeRowsAs(T, listtype);
            //    FilterRows(T);
            //}
		}   

        public override bool IsValid(DataRow R, out string errmess, out string errfield){            
            if (!base.IsValid(R, out errmess, out errfield)) return false;                 
			if (R["amount"]==DBNull.Value){
				errmess="Attenzione! L'importo non può essere nullo.";
				errfield="amount";
				return false;
			}
			if (CfgFn.GetNoNullInt32(R["idsor"])==0){
				errmess="Attenzione! La voce di classificazione non può essere nulla.";
                errfield = "budgetvardetailview.codesor";
				return false;
			}
          
            DataRelation Rfound = null;
            foreach (DataRelation Rp in PrimaryDataTable.ParentRelations){
                if (Rp.ParentTable.TableName != "budgetvar")continue;
                Rfound=Rp;
                break;
            }
            if (Rfound==null)return true;
            DataRow ParentRow = R.GetParentRow(Rfound);
            if (ParentRow==null) {
                errmess="E' necessario selezionare una variazione";
                errfield="nbudgetvar";
                return false;
            }
			return true;
        }


		public override DataRow SelectOne(string ListingType, string filter, string searchtable, DataTable Exclude) {
			if (ListingType=="listaestesa")
				return base.SelectOne(ListingType, filter, "budgetvardetailview", Exclude);
			else
				return base.SelectOne(ListingType, filter, "budgetvardetail", Exclude);
		}		

	}
}
