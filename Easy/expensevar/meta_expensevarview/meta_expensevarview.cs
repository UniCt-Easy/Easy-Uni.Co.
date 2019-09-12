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
using metadatalibrary;
using metaeasylibrary;
using funzioni_configurazione;
namespace meta_expensevarview//meta_variazionespesaview//
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	public class Meta_expensevarview : Meta_easydata 
	{
		public Meta_expensevarview(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "expensevarview") 
		{		
			Name= "variazioni movimenti di spesa";
			ListingTypes.Add("lista");
            ListingTypes.Add("dociva");
			ListingTypes.Add("autospesa");
			ListingTypes.Add("autogenerati");
            ListingTypes.Add("documentitrasmessi");

		}
        private string[] mykey = new string[] { "idexp", "yvar", "nvar" };
        public override string[] primaryKey() {
            return mykey;
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

        public override void CalculateFields(DataRow R, string list_type)
        {
            base.CalculateFields(R, list_type);
            if (list_type == "documentitrasmessi")
            {
                impostaCampi(R, list_type);
            }
        }

        private void impostaCampi(DataRow R, string listingtype)
        {
            if (listingtype != "documentitrasmessi") return;
            if (R["autokind"] == DBNull.Value) return;
            bool flagunchanged = false;
            if (R.RowState == DataRowState.Unchanged) flagunchanged = true;
            if (CfgFn.GetNoNullInt32(R["autokind"]) == 10 ) R["!varkind"] = "Annullamento Parziale";
            if (CfgFn.GetNoNullInt32(R["autokind"]) == 11) R["!varkind"] = "Annullamento"; ;
            if (CfgFn.GetNoNullInt32(R["autokind"]) == 22) R["!varkind"] = "Modifica Dati";
            if (flagunchanged) R.AcceptChanges();
        }
		public override void DescribeColumns(DataTable T, string ListingType) 
		{
			base.DescribeColumns(T, ListingType);
            int pos = 1;
			if (ListingType=="lista")
			{
				foreach (DataColumn C in T.Columns)
					DescribeAColumn(T, C.ColumnName, "",-1);

				DescribeAColumn(T, "phase", "Fase",pos++);
                DescribeAColumn(T, "ymov", "Eserc. mov.", pos++);
                DescribeAColumn(T, "nmov", "Num. mov.", pos++);
                DescribeAColumn(T, "yvar", "Eserc. variaz.", pos++);
                DescribeAColumn(T, "nvar", "Num. variaz.", pos++);
                DescribeAColumn(T, "description_main", "Descrizione Mov.", pos++);
                DescribeAColumn(T, "description", "Descrizione", pos++);
                DescribeAColumn(T, "amount", "Importo", pos++);
                DescribeAColumn(T, "adate", "Data cont.", pos++);
                DescribeAColumn(T, "codefin", "Cod.Bil.", pos++);
                DescribeAColumn(T, "finance", "Bil.", pos++);
                DescribeAColumn(T, "codeupb", "Cod. UPB", pos++);
                DescribeAColumn(T, "upb", "UPB", pos++);
                DescribeAColumn(T, "underwriting", "Finanziamento", pos++);
                DescribeAColumn(T, "transferkind", "Tipo trasf.", pos++);
			}
            if (ListingType == "dociva") {
                foreach (DataColumn C in T.Columns)
                    DescribeAColumn(T, C.ColumnName, "",-1);
                int nPos = 1;
                DescribeAColumn(T, "phase", "Fase", nPos++);
                DescribeAColumn(T, "ymov", "Eserc. mov.", nPos++);
                DescribeAColumn(T, "nmov", "Num. mov.", nPos++);
                DescribeAColumn(T, "yvar", "Eserc. variaz.", nPos++);
                DescribeAColumn(T, "nvar", "Num. variaz.", nPos++);
                DescribeAColumn(T, "description", "Descrizione", nPos++);
                DescribeAColumn(T, "amount", "Importo", nPos++);
                DescribeAColumn(T, "adate", "Data cont.", nPos++);
                DescribeAColumn(T, "codefin", "Cod.Bil.", nPos++);
                DescribeAColumn(T, "transferkind", "Tipo trasf.", nPos++);
                DescribeAColumn(T, "invoicekind", "Tipo Nota di Cred.", nPos++);
                DescribeAColumn(T, "yinv", "Eserc. Nota di Cred.", nPos++);
                DescribeAColumn(T, "ninv", "Num. Nota di Cred.", nPos++);
            }
			if (ListingType=="autospesa") {
				foreach (DataColumn C in T.Columns)
					DescribeAColumn(T, C.ColumnName, "",-1);
                DescribeAColumn(T, "phase", "Fase", pos++);
                DescribeAColumn(T, "nmov", "Num. mov.", pos++);
                DescribeAColumn(T, "nvar", "Num. variaz.", pos++);
                DescribeAColumn(T, "description", "Descrizione", pos++);
                DescribeAColumn(T, "amount", "Importo", pos++);
			}
			if (ListingType=="autogenerati") {
				foreach (DataColumn C in T.Columns)
					DescribeAColumn(T, C.ColumnName, "",-1);
                DescribeAColumn(T, "phase", "Fase", pos++);
                DescribeAColumn(T, "nmov", "Num. Mov.", pos++);
                DescribeAColumn(T, "nvar", "Num. Var.", pos++);
                DescribeAColumn(T, "description", "Descrizione", pos++);
                DescribeAColumn(T, "amount", "Importo", pos++);
			}
            if (ListingType == "documentitrasmessi")
            {
                foreach (DataColumn C in T.Columns)
                {
                    DescribeAColumn(T, C.ColumnName, "", -1);
                }
                int nPos = 1;
                DescribeAColumn(T, "idexp", ".#", nPos++);
                DescribeAColumn(T, "yvar", "Eserc. Var.", nPos++);
                DescribeAColumn(T, "nvar", "Numero Var.", nPos++);
                DescribeAColumn(T, "phase", "Fase", nPos++);
                DescribeAColumn(T, "nmov", "Numero Mov.", nPos++);
                DescribeAColumn(T, "npay", "Numero Mand.", nPos++);
                DescribeAColumn(T, "adate", "Data emiss.", nPos++);
                DescribeAColumn(T, "!varkind", "Tipo Variazione", nPos++);
                ComputeRowsAs(T, ListingType);
                FilterRows(T);
            }
           
		}
		}
	}
