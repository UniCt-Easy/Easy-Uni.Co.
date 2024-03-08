
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


using System.Data;
using metaeasylibrary;
using metadatalibrary;

namespace meta_garatraspareview {
    /// <summary>
    /// 
    /// </summary>
    public class Meta_garatraspareview : Meta_easydata {
        public Meta_garatraspareview(DataAccess Conn, MetaDataDispatcher Dispatcher) : base(Conn, Dispatcher, "garatraspareview") {
            ListingTypes.Add("default");
            Name = "gare";
        }
        private string[] mykey = new string[] { "idGaraTraspare", "cig" };
        public override string[] primaryKey() {
            return mykey;
        }

        public override void DescribeColumns(DataTable T, string listtype) {
            base.DescribeColumns(T, listtype);
            if (listtype == "default") {
                foreach (DataColumn C in T.Columns)
                    DescribeAColumn(T, C.ColumnName, "", -1);

                int nPos = 1;
                DescribeAColumn(T, "idGaraTraspare", "Id Gara Traspare", nPos++);
                DescribeAColumn(T, "cig", "CIG", nPos++);
                DescribeAColumn(T, "Fornitore", "Anagr. Fornitore", nPos++);
                DescribeAColumn(T, "FornitoreCFPIva", "Fornitore CF/P.Iva", nPos++);
                DescribeAColumn(T, "FornitoreIdEstero", "Fornitore Id Estero", nPos++);
                DescribeAColumn(T, "SommaImportoAggiudicazione", "Importo Aggiudicazione", nPos++);
                DescribeAColumn(T, "Rup", "Rup", nPos++);
                DescribeAColumn(T, "RupCF", "Rup CF/P.Iva", nPos++);
            }
        }
    }
}
