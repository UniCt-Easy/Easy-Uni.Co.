
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
using metaeasylibrary;
using metadatalibrary;

namespace meta_proceeds_bankview {
	/// <summary>
	/// Summary description for Meta_proceeds_bankview.
	/// </summary>
	public class Meta_proceeds_bankview : Meta_easydata {
		public Meta_proceeds_bankview(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "proceeds_bankview") {
			ListingTypes.Add("default");
			ListingTypes.Add("elenco");
			Name = "Movimento Bancario";
		}
        private string[] mykey = new string[] { "idpro", "kpro" };
        public override string[] primaryKey() {
            return mykey;
        }
        public override void DescribeColumns(DataTable T, string ListingType) {
			base.DescribeColumns (T, ListingType);
			int nPos = 1;
			if (ListingType == "default") {
				foreach(DataColumn C in T.Columns) {
					DescribeAColumn(T, C.ColumnName, "", -1);
				}
                DescribeAColumn(T, "kpro", ".#Reversale", nPos++);
				DescribeAColumn(T, "ypro", "Eserc. Reversale", nPos++);
				DescribeAColumn(T, "npro", "Num. Reversale", nPos++);
				DescribeAColumn(T, "nmov", "Num. Incasso", nPos++);
				DescribeAColumn(T, "idpro", "Num. SUB", nPos++);
				DescribeAColumn(T, "registry", "Versante", nPos++);
				DescribeAColumn(T, "amount", "Importo", nPos++);
				DescribeAColumn(T, "performed", "Importo totale esitato ", nPos++);
				DescribeAColumn(T, "notperformed", "Importo totale non esitato", nPos++);
				DescribeAColumn(T, "description", "Descrizione", nPos++);
			}
			if (ListingType == "elenco") {
				foreach(DataColumn C in T.Columns) {
					DescribeAColumn(T, C.ColumnName, "", -1);
				}
                DescribeAColumn(T, "kpro", ".#Reversale", nPos++);
				DescribeAColumn(T, "ypro", "Eserc. Reversale", nPos++);
				DescribeAColumn(T, "npro", "Num. Reversale", nPos++);
				DescribeAColumn(T, "nmov", "Num. Incasso", nPos++);
				DescribeAColumn(T, "idpro", "Num. SUB", nPos++);
				DescribeAColumn(T, "registry", "Versante", nPos++);
				DescribeAColumn(T, "amount", "Importo", nPos++);
				DescribeAColumn(T, "performed", "Importo totale esitato ", nPos++);
				DescribeAColumn(T, "notperformed", "Importo totale non esitato", nPos++);
				DescribeAColumn(T, "description", "Descrizione", nPos++);
			}
		}
	}
}
