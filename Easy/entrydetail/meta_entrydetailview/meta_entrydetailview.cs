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
using metaeasylibrary;
using metadatalibrary;

namespace meta_entrydetailview {
	/// <summary>
	/// Summary description for Meta_entrydetailview.
	/// </summary>
	public class Meta_entrydetailview : Meta_easydata {
		public Meta_entrydetailview(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "entrydetailview") {
			ListingTypes.Add("listaestesa");
		}

        public override string GetStaticFilter(string ListingType) {
            if (ListingType == "listaestesa") {
                string filteresercizio = QHS.CmpEq("yentry", GetSys("esercizio"));
                return filteresercizio;
            }
            return base.GetStaticFilter(ListingType);
        }
        private string[] mykey = new string[] { "yentry", "nentry", "ndetail" };
        public override string[] primaryKey() {
            return mykey;
        }
        public override void DescribeColumns(DataTable T, string ListingType) {
			base.DescribeColumns (T, ListingType);
			if (ListingType == "listaestesa") {
				foreach(DataColumn C in T.Columns) {
					DescribeAColumn(T, C.ColumnName, "", -1);
				}
				int nPos = 1;
				DescribeAColumn(T, "yentry", "Eserc. Scrittura", nPos++);
				DescribeAColumn(T, "nentry", "Num. Scrittura", nPos++);
				DescribeAColumn(T, "ndetail", "Num. Dettaglio", nPos++);
				DescribeAColumn(T, "codeacc", "Cod. Conto", nPos++);
                DescribeAColumn(T, "account", "Conto", nPos++);
                DescribeAColumn(T, "patpart", "Parte Stato Patrim.", nPos++);
                DescribeAColumn(T, "codepatrimony", "Cod. Stato Patrim.", nPos++);
                DescribeAColumn(T, "placcpart", "Parte Conto. Econ.", nPos++);
                DescribeAColumn(T, "codeplaccount", "Cod. Conto Econ.", nPos++);
                DescribeAColumn(T, "registry", "Cliente/Fornitore", nPos++);
				DescribeAColumn(T, "codeupb", "Cod. U.P.B.", nPos++);
				DescribeAColumn(T, "upb", "U.P.B.", nPos++);
				DescribeAColumn(T, "give", "Dare", nPos++);
				DescribeAColumn(T, "have", "Avere", nPos++);
                DescribeAColumn(T, "detaildescription", "Descrizione dettaglio", nPos++);
                DescribeAColumn(T, "description", "Descrizione Scrittura", nPos++);
				DescribeAColumn(T, "codemotive", "Cod. Causale", nPos++);
				DescribeAColumn(T, "accmotive", "Causale", nPos++);
                DescribeAColumn(T, "competencystart", "Inizio competenza", nPos++);
                DescribeAColumn(T, "competencystop", "Fine competenza", nPos++);
                DescribeAColumn(T, "nepexp", "Numero Impegno di Budget", nPos++);
                DescribeAColumn(T, "yepexp", "Anno Impegno di Budget", nPos++);
                DescribeAColumn(T, "nepacc", "Numero Accertamento di Budget", nPos++);
                DescribeAColumn(T, "yepacc", "Anno Accertamento di Budget", nPos++);
                DescribeAColumn(T, "sortcode1", "Classificazione 1", nPos++);
                DescribeAColumn(T, "sortcode2", "Classificazione 2", nPos++);
                DescribeAColumn(T, "sortcode3", "Classificazione 3", nPos++);

            }
		}
	}
}