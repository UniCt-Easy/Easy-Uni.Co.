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

namespace meta_expensevar//meta_variazionespesa//
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	public class Meta_expensevar : Meta_easydata 
	{
		public Meta_expensevar(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "expensevar")
		{
			EditTypes.Add("default");
			EditTypes.Add("detail");
			ListingTypes.Add("default");
			ListingTypes.Add("lista");
			ListingTypes.Add("dociva");
            ListingTypes.Add("posting");
            ListingTypes.Add("documentitrasmessi");
			Name = "Variazione movimento di spesa";
		}
        
        protected override void InsertCopyColumn(DataColumn C, DataRow Source, DataRow Dest)
        {
            if (C.ColumnName == "kpaymenttransmission") return;
            base.InsertCopyColumn(C, Source, Dest);
        }

        public override bool FilterRow(DataRow R, string list_type)
        {
            if (list_type == "documentitrasmessi")
            {
                if (R["kpaymenttransmission"] == DBNull.Value) return false;
                return true;
            }
            return true;
        }

		protected override Form GetForm(string FormName) 
		{
			if (FormName=="default") 
			{
				DefaultListType="lista";
				return MetaData.GetFormByDllName("expensevar_default");//PinoRana
			}

			if (FormName=="detail"){
				return MetaData.GetFormByDllName("expensevar_detail");//PinoRana
			}
			return null;
		}			

		public override DataRow Get_New_Row(DataRow ParentRow, DataTable T)
		{
			RowChange.SetSelector(T, "idexp");
            RowChange.setMinimumTempValue(T.Columns["nvar"],9999000);
			RowChange.MarkAsAutoincrement(T.Columns["nvar"],null,
				null,7);
			DataRow R = base.Get_New_Row(ParentRow, T);
			//R["numvariazione"]=-1;	Deleted By nino
			return R;
		}
		
		public override void DescribeColumns(DataTable T, string listtype) 
		{
			base.DescribeColumns(T, listtype);
			if (listtype=="default") {
				foreach (DataColumn C in T.Columns)
					DescribeAColumn(T, C.ColumnName, "");
				DescribeAColumn(T, "yvar", "Eserc. variaz.");
				DescribeAColumn(T, "nvar", "Num. variaz.");
				DescribeAColumn(T, "description", "Descrizione");
				DescribeAColumn(T, "amount", "Importo");
				DescribeAColumn(T, "adate", "Data cont.");
				DescribeAColumn(T, "transferkind", "Tipo trasf.");
                DescribeAColumn(T, "!codeunderwriting", "Codice Fin.", "underwriting_var.codeunderwriting");
                DescribeAColumn(T, "!underwriting", "Fin.", "underwriting_var.title");
			}
            if (listtype == "documentitrasmessi")
            {
                foreach (DataColumn C in T.Columns)
                {
                    DescribeAColumn(T, C.ColumnName, "", -1);
                }
                int nPos = 1;
                DescribeAColumn(T, "yvar", "Eserc.", nPos++);
                DescribeAColumn(T, "nvar", "Numero", nPos++);
                DescribeAColumn(T, "adate", "Data emiss.", nPos++);
                DescribeAColumn(T, "description", "Descrizione", nPos++);
                FilterRows(T);
            }
		}   
		

		public override void SetDefaults(DataTable T) 
		{
			base.SetDefaults(T);
			SetDefault(T,"yvar",GetSys("esercizio"));
			SetDefault(T,"adate", GetSys("datacontabile"));
			SetDefault(T,"amount",0);
			SetDefault(T,"transferkind","A");
		}

		public override DataRow SelectOne(string ListingType, string filter, string searchtable, DataTable Exclude) 
		{
			if (ListingType=="default") {
				return base.SelectOne(ListingType, filter, "expensevar", Exclude);
			}
			return base.SelectOne(ListingType, filter, "expensevarview", Exclude);

		}		
		public override bool IsValid(DataRow R, out string errmess, out string errfield){
			if (!base.IsValid(R,out errmess,out errfield))return false;
            if ((CfgFn.GetNoNullDecimal(R["amount"])==0) && (CfgFn.GetNoNullInt32(R["autokind"]) != 22))
            {  
                // 22 --> variazione di tipo EDIT, indicante la possibilit‡ di correggere i dati di pagamenti trasmessi
                // ai fini dell'ordinativo informatico
				errmess= "E' necessario specificare l'importo della variazione";
				errfield="amount";
				return false;
			}

            if ((CfgFn.GetNoNullDecimal(R["amount"]) != 0) && (CfgFn.GetNoNullInt32(R["autokind"]) == 22))
            {
                // 22 --> variazione di tipo EDIT, indicante la possibilit‡ di correggere i dati di pagamenti trasmessi
                // ai fini dell'ordinativo informatico
                errmess = "L'importo della variazione per modifica pagamenti trasmessi deve essere pari a zero";
                errfield = "amount";
                return false;
            }
            if (R.Table.Columns.Contains("idinvkind")
                && R.Table.Columns.Contains("yinv")
                && R.Table.Columns.Contains("ninv")
                && R.Table.Columns.Contains("movkind")) {
                if ((R["idinvkind"] != DBNull.Value) &&
                    (R["yinv"] != DBNull.Value) &&
                    (R["ninv"] != DBNull.Value)) {
                    if (CfgFn.GetNoNullInt32(R["movkind"]) == 0) {
                        errmess = "Bisogna selezionare la causale di contabilizzazione";
                        errfield = "movkind";
                        return false;
                    }

                }
            }
			return true;
		}

        private void impostaCampi(DataRow R, string listingtype) {
			if (listingtype != "posting") return;
			if (R["autokind"] == DBNull.Value) return;
			if (R["idpayment"] == DBNull.Value) return;
            object idmov = R["idpayment"];
            DataSet DS = R.Table.DataSet;

            DataRow[] Exp = R.Table.DataSet.Tables["expense"].Select("idexp=" + QueryCreator.quotedstrvalue(idmov, false));
            if (Exp.Length == 0) return;
            object nmov = Exp[0]["nmov"];

            //object nmov=DBNull.Value;
            //foreach(DataRelation ParRel in R.Table.ParentRelations){
            //    if (ParRel.ChildColumns[0].ColumnName=="idexp"){
            //        if (ParRel.ParentTable.Columns.Contains("nmov")){
            //            DataRow ParRow= R.GetParentRow(ParRel);
            //            if (ParRow!=null){ nmov= ParRow["nmov"].ToString();
            //            break;
            //            }
            //        }
            //    }
            //}
            if (nmov==DBNull.Value) 
                nmov="(ATTENZIONE: NUMERO NON TROVATO)";

			
			string suCosa = "su pagamento";

			string descr = R["description"].ToString();

			int pos = descr.LastIndexOf(suCosa);
			// Non ho trovato il token "su pagamento" o "su incasso"
			if (pos == -1) return;
			pos += suCosa.Length;

			string temp_s = descr.Substring(pos);
			int pos_n = temp_s.IndexOf("n. ");
			// Non ho trovato il token "n. "
			if (pos_n == -1) return;

			string s1 = descr.Substring(0,pos) + temp_s.Substring(0, pos_n);
			
			string s2 = "n. ";
			string temp_s1 = temp_s.Substring(pos_n + 3);

			int nCharToPaste = 0;
			foreach(char c in temp_s1.ToCharArray()) {
				if ((c >= '0') && (c <= '9')) {
					s2 += c.ToString();
					nCharToPaste++;
				}
				else {
					break;
				}
			}
			s2 = "n. " + nmov.ToString();

			string s3 = temp_s1.Substring(nCharToPaste);

			R["description"] = s1 + s2 + s3;
		}

        public override void CalculateFields(DataRow R, string list_type) {
            base.CalculateFields(R, list_type);
            if (list_type == "posting") {
                impostaCampi(R, list_type);
            }
        }
	}
}
