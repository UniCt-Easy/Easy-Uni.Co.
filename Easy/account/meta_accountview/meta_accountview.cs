
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
using System.Data;
using System.Windows.Forms;
using metadatalibrary;
using metaeasylibrary;

namespace meta_accountview {
	/// <summary>
	/// Summary description for Meta_accountview.
	/// </summary>
	public class Meta_accountview : Meta_easydata {
		public Meta_accountview(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "accountview") {
			EditTypes.Add("default");
			ListingTypes.Add("default");
		}

        public override string GetStaticFilter(string ListingType) {
            if (ListingType == "default") {
                string filteresercizio = QHS.CmpEq("ayear", GetSys("esercizio"));
                return filteresercizio;
            }
            return base.GetStaticFilter(ListingType);
        }
        string[] mykey = new string[] { "idacc"};
        public override string[] primaryKey() {
            return mykey;
        }

        public override void DescribeColumns(System.Data.DataTable T, string ListingType) {
			base.DescribeColumns (T, ListingType);
			if (ListingType == "default") {
				foreach(DataColumn C in T.Columns) {
					DescribeAColumn(T, C.ColumnName, "", -1);
				}
				int nPos = 1;
				DescribeAColumn(T, "codeacc", "Codice Conto", nPos++);
				DescribeAColumn(T, "title", "Conto", nPos++);
				DescribeAColumn(T, "leveldescr", "Livello", nPos++);
				DescribeAColumn(T, "flagtransitory", "Transitorio", nPos++);
				DescribeAColumn(T, "flagregistry", "Flag Anagrafica", nPos++);
				DescribeAColumn(T, "flagupb", "Flag U.P.B.", nPos++);
				DescribeAColumn(T, "codepatrimony", "Codice Stato Patrimoniale", nPos++);
				DescribeAColumn(T, "patrimony", "Stato Patrimoniale", nPos++);
                DescribeAColumn(T, "flagcompetency", "Competenza", nPos++);
				DescribeAColumn(T, "codeplaccount", "Codice Conto Economico", nPos++);
				DescribeAColumn(T, "placcount", "Conto Economico", nPos++);
				DescribeAColumn(T, "flagprofit", "Utile", nPos++);
				DescribeAColumn(T, "flagloss", "Perdita", nPos++);
                DescribeAColumn(T, "rateiattivi", "Ratei Attivi", nPos++);
		        DescribeAColumn(T, "rateipassivi", "Ratei Passivi", nPos++);
		        DescribeAColumn(T, "riscontiattivi", "Risconti Attivi", nPos++);
                DescribeAColumn(T, "riscontipassivi", "Risconti Passivi", nPos++);
                DescribeAColumn(T, "debit", "Debiti", nPos++);
                DescribeAColumn(T, "credit", "Crediti", nPos++);
                DescribeAColumn(T, "cost", "Costi", nPos++);
                DescribeAColumn(T, "revenue", "Ricavi", nPos++);
                DescribeAColumn(T, "fixedassets", "Immobilizzazioni", nPos++);
                DescribeAColumn(T, "freeusesurplus", "Avanzo libero", nPos++);
                DescribeAColumn(T, "captiveusesurplus", "Avanzo vincolato", nPos++);
				DescribeAColumn(T, "reserve","Riserva", nPos++);
				DescribeAColumn(T, "provision","Accantonamento", nPos++);
				DescribeAColumn(T, "cash", "Disponibilità liquide", nPos++);
				DescribeAColumn(T, "otheritems_A", "Altre voci dell'attivo", nPos++);
				DescribeAColumn(T, "otheritems_P", "Altre voci del passivo", nPos++);
				DescribeAColumn(T, "amortization, ", "Ammortamento", nPos++);
				DescribeAColumn(T, "reservecofi", "Ex Riserve COFI", nPos++);
                DescribeAColumn(T, "sortcode_economicbudget", "Codice Budget Economico", nPos++);
                DescribeAColumn(T, "sortcode_investmentbudget", "Codice Budget Investimenti", nPos++);
            }
        }
	}
}
