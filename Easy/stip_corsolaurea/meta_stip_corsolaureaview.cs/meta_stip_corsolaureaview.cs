
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
using metaeasylibrary;
using metadatalibrary;

namespace meta_stip_corsolaureaview {
    public class Meta_stip_corsolaureaview : Meta_easydata {
        public Meta_stip_corsolaureaview(DataAccess Conn, MetaDataDispatcher Dispatcher)
            : base(Conn, Dispatcher, "stip_corsolaureaview") {
            
            ListingTypes.Add("default");
        }

        public override string[] primaryKey() {
            return new [] { "idstipcorsolaurea" };
        }

        public override string GetSorting(string ListingType) {
            string sorting;
            if (ListingType == "default") {
                sorting = "codicecorsolaurea asc";
                return sorting;
			}

            return base.GetSorting (ListingType);
		}

        public override void DescribeColumns(DataTable T, string ListingType) {
            base.DescribeColumns(T, ListingType);
            if (ListingType == "default") {
                foreach (DataColumn C in T.Columns)
                    DescribeAColumn(T, C.ColumnName, "", -1);
                int nPos = 1;             
                DescribeAColumn(T, "codicecorsolaurea", "Codice corso di laurea", nPos++);
                DescribeAColumn(T, "anno", "Anno", nPos++);
                DescribeAColumn(T, "codeupb", "Codice UPB", nPos++);
                DescribeAColumn(T, "codicedipartimento", "Cod. Dipartimento", nPos++);
                DescribeAColumn(T, "codicepercorso", "Cod. Percorso", nPos++);
                DescribeAColumn(T, "codicesede", "Cod. Sede", nPos++);
                DescribeAColumn(T, "codicetassa", "Codice tassa", nPos++);
                DescribeAColumn(T, "codicevoce", "Codice voce", nPos++);
                DescribeAColumn(T, "descrizione", "Descrizione", nPos++);
                DescribeAColumn(T, "descrizionecorsolaurea", "Descrizione Corso Laurea", nPos++);
                DescribeAColumn(T, "dipartimento", "Dipartimento", nPos++);
                DescribeAColumn(T, "percorso", "Percorso", nPos++);
                DescribeAColumn(T, "sede", "Sede", nPos++);
                DescribeAColumn(T, "tassa", "Tassa", nPos++);
                DescribeAColumn(T, "voce", "Voce", nPos++);
                DescribeAColumn(T, "upb", "UPB", nPos++);
                DescribeAColumn(T, "causale", "Causale", nPos++);
                DescribeAColumn(T, "codicecausale", "Codice Causale", nPos++);
                DescribeAColumn(T, "sortcode1", "Codice CoAn 1", nPos++);
                DescribeAColumn(T, "sortcode2", "Codice CoAn 2", nPos++);
            }            
        }
    }
}
