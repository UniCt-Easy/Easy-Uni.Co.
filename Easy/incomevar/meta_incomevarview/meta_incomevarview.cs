
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
using metadatalibrary;
using metaeasylibrary;
using funzioni_configurazione;

namespace meta_incomevarview//meta_variazioneentrataview//
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	public class Meta_incomevarview : Meta_easydata {
		public Meta_incomevarview(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "incomevarview") {		
			Name= "variazioni movimenti di entrata";
			ListingTypes.Add("lista");
            ListingTypes.Add("dociva");
			ListingTypes.Add("autogenerati");
			ListingTypes.Add("autoentrata");
            ListingTypes.Add("documentitrasmessi");
		}

        public override bool FilterRow(DataRow R, string list_type)
        {
            if (list_type == "documentitrasmessi")
            {
                if (R["kproceedstransmission"] == DBNull.Value) return false;
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
            if (CfgFn.GetNoNullInt32(R["autokind"]) == 10) R["!varkind"] = "Annullamento Parziale";
            if (CfgFn.GetNoNullInt32(R["autokind"]) == 11) R["!varkind"] = "Annullamento"; ;
            if (CfgFn.GetNoNullInt32(R["autokind"]) == 22) R["!varkind"] = "Modifica Dati";
            if (flagunchanged) R.AcceptChanges();
        }
		public override void DescribeColumns(DataTable T, string ListingType) {
			base.DescribeColumns(T, ListingType);
			if (ListingType=="lista") {
                foreach (DataColumn C in T.Columns)
                    DescribeAColumn(T, C.ColumnName, "", -1);
                int nPos = 1;

                DescribeAColumn(T, "phase", "Fase", nPos++);
                DescribeAColumn(T, "ymov", "Eserc. mov.", nPos++);
                DescribeAColumn(T, "nmov", "Num. mov.", nPos++);
                DescribeAColumn(T, "yvar", "Eserc. variaz.", nPos++);
                DescribeAColumn(T, "nvar", "Num. variaz.", nPos++);
                DescribeAColumn(T, "description_main", "Descrizione Mov.", nPos++);
                DescribeAColumn(T, "description", "Descrizione", nPos++);
                DescribeAColumn(T, "amount", "Importo", nPos++);
                DescribeAColumn(T, "adate", "Data cont.", nPos++);
                DescribeAColumn(T, "codefin", "Cod.Bil.", nPos++);
                DescribeAColumn(T, "finance", "Bil.", nPos++);
                DescribeAColumn(T, "codeupb", "Cod. UPB", nPos++);
                DescribeAColumn(T, "upb", "UPB", nPos++);
                DescribeAColumn(T, "transferkind", "Tipo trasf.", nPos++);
			}
            if (ListingType == "dociva") {
                foreach (DataColumn C in T.Columns)
                    DescribeAColumn(T, C.ColumnName, "", -1);
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
			if (ListingType=="autogenerati") {
                foreach (DataColumn C in T.Columns)
                    DescribeAColumn(T, C.ColumnName, "", -1);
                int nPos = 1;
                DescribeAColumn(T, "phase", "Fase", nPos++);
                DescribeAColumn(T, "nmov", "Num. Mov.", nPos++);
                DescribeAColumn(T, "nvar", "Num. Var.", nPos++);
                DescribeAColumn(T, "description", "Descrizione", nPos++);
                DescribeAColumn(T, "amount", "Importo", nPos++);
			}
			if (ListingType=="autoentrata") {
                foreach (DataColumn C in T.Columns)
                    DescribeAColumn(T, C.ColumnName, "", -1);
                int nPos = 1;
                DescribeAColumn(T, "autokind", "Tipo", nPos++);
                DescribeAColumn(T, "phase", "Fase", nPos++);
                DescribeAColumn(T, "nmov", "Num. Mov.", nPos++);
                DescribeAColumn(T, "nvar", "Num. Var.", nPos++);
                DescribeAColumn(T, "description", "Descrizione", nPos++);
                DescribeAColumn(T, "amount", "Importo", nPos++);
			}
            if (ListingType == "documentitrasmessi")
            {
                foreach (DataColumn C in T.Columns)
                {
                    DescribeAColumn(T, C.ColumnName, "", -1);
                }
                int nPos = 1;
                DescribeAColumn(T, "idinc", ".#", nPos++);
                DescribeAColumn(T, "yvar", "Eserc. Var.", nPos++);
                DescribeAColumn(T, "nvar", "Numero Var.", nPos++);
                DescribeAColumn(T, "phase", "Fase", nPos++);
                DescribeAColumn(T, "nmov", "Numero Mov.", nPos++);
                DescribeAColumn(T, "npro", "Numero Revers.", nPos++);
                DescribeAColumn(T, "adate", "Data emiss.", nPos++);
                DescribeAColumn(T, "!varkind", "Tipo Variazione", nPos++);
                ComputeRowsAs(T, ListingType);
                FilterRows(T);
            }
           

		}
	}
}
