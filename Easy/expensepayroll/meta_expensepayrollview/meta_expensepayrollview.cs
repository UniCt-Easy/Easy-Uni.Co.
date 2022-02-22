
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
using System.Data;
using metaeasylibrary;
using metadatalibrary;

namespace meta_expensepayrollview {//meta_cedolinomovspesaview//
	/// <summary>
	/// Summary description for Meta_cedolinomovspesaview.
	/// </summary>
	public class Meta_expensepayrollview : Meta_easydata {
		public Meta_expensepayrollview(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "expensepayrollview") {
			ListingTypes.Add("default");
			Name = "Cedolino - Mov. Spesa";
		}
		public override string GetSorting(string ListingType) {
			string sorting;
			if (ListingType=="default") {
				sorting="nphase asc,ymov desc,nmov desc";
				return sorting;
			}
			return base.GetSorting (ListingType);
			
		}
        private string[] mykey = new string[] { "ayear", "idpayroll", "idexp" };
        public override string[] primaryKey() {
            return mykey;
        }

        public override string GetStaticFilter(string ListingType) {
			string filteresercizio;
			if (ListingType=="default") {
				filteresercizio = QHS.CmpEq("ayear", GetSys("esercizio"));
				return filteresercizio;
			}
			return base.GetStaticFilter (ListingType);
		}

		public override void DescribeColumns(DataTable T, string listtype) {
			base.DescribeColumns(T, listtype);
			switch (listtype) {
				case "default": {
					foreach (DataColumn C in T.Columns)
						DescribeAColumn(T, C.ColumnName, "",-1);
					int nPos = 1;
					DescribeAColumn(T, "idpayroll", "Num. Cedolino",nPos++);
					DescribeAColumn(T, "fiscalyear", "Anno Fiscale",nPos++);
					DescribeAColumn(T, "npayroll", "Progressivo Anno",nPos++);
					DescribeAColumn(T, "phase", "Fase",nPos++);
					DescribeAColumn(T, "ymov", "Eserc.Mov.",nPos++);
					DescribeAColumn(T, "nmov", "Num.Mov.",nPos++);
					DescribeAColumn(T, "codefin", "Voce Bil.",nPos++);
					DescribeAColumn(T, "finance", "Denom. Bil.",nPos++);
					DescribeAColumn(T, "codeupb", "Cod. U.P.B.",nPos++);
					DescribeAColumn(T, "upb", "Denom. U.P.B.",nPos++);
					DescribeAColumn(T, "registry", "Percipiente",nPos++);
					DescribeAColumn(T, "manager", "Responsabile",nPos++);
					DescribeAColumn(T, "doc", "Documento",nPos++);
					DescribeAColumn(T, "docdate", "Data Doc.",nPos++);
					DescribeAColumn(T, "description", "Descrizione",nPos++);
					DescribeAColumn(T, "amount", "Importo Originale",nPos++);
					DescribeAColumn(T, "curramount", "Imp.Corrente",nPos++);
					DescribeAColumn(T, "available", "Disponibile",nPos++);
					DescribeAColumn(T, "adate", "Data Contabile",nPos++);
                    DescribeAColumn(T, "idexp", ".idexp", -1);
                    DescribeAColumn(T, "ayearstartamount", "Imp.Esercizio", -1);
                    DescribeAColumn(T, "autokind", ".Tipo Auto", -1);
                    DescribeAColumn(T, "flagarrear", ".Competenza", -1);
                    DescribeAColumn(T, "expiration", ".Data Scadenza", -1);
					break;
				}
				case "contratto": {
					foreach (DataColumn C in T.Columns)
						DescribeAColumn(T, C.ColumnName, "");
					int nPos = 1;
					DescribeAColumn(T, "idpayroll", "Num. Cedolino",nPos++);
					DescribeAColumn(T, "fiscalyear", "Anno Fiscale",nPos++);
					DescribeAColumn(T, "npayroll", "Progressivo Anno",nPos++);
					DescribeAColumn(T, "phase", "Fase",nPos++);
					DescribeAColumn(T, "ymov", "Eserc.Mov.",nPos++);
					DescribeAColumn(T, "nmov", "Num.Mov.",nPos++);
					DescribeAColumn(T, "codefin", "Voce Bil.",nPos++);
					DescribeAColumn(T, "finance", "Denom. Bil.",nPos++);
					DescribeAColumn(T, "codeupb", "Cod. U.P.B.",nPos++);
					DescribeAColumn(T, "upb", "Denom. U.P.B.",nPos++);
					DescribeAColumn(T, "registry", "Percipiente",nPos++);
					DescribeAColumn(T, "manager", "Responsabile",nPos++);
					DescribeAColumn(T, "doc", "Documento",nPos++);
					DescribeAColumn(T, "docdate", "Data Doc.",nPos++);
					DescribeAColumn(T, "description", "Descrizione",nPos++);
					DescribeAColumn(T, "amount", "Importo Originale",nPos++);
					DescribeAColumn(T, "ayearstartamount", "Imp.Esercizio",nPos++);
					DescribeAColumn(T, "curramount", "Imp.Corrente",nPos++);
					DescribeAColumn(T, "available", "Disponibile",nPos++);
					DescribeAColumn(T, "adate", "Data Contabile",nPos++);
					break;
				}
			}
		}
	}
}
