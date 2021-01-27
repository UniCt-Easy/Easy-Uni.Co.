
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
using System.Collections.Generic;
using System.Text;
using System.Data;
using metaeasylibrary;
using metadatalibrary;
using System.Windows.Forms;

namespace meta_paydispositionview {
    public class Meta_paydispositionview : Meta_easydata {
        public Meta_paydispositionview(DataAccess Conn, MetaDataDispatcher Dispatcher)
            :
			base(Conn, Dispatcher, "paydispositionview") {
			ListingTypes.Add("default");
			DefaultListType = "default";
		}
        private string[] mykey = new string[] { "idpaydisposition" };
        public override string[] primaryKey() {
            return mykey;
        }
        public override void DescribeColumns(DataTable T, string ListingType) {
            base.DescribeColumns(T);
            if (ListingType == "default") {
                foreach (DataColumn C in T.Columns) {
                    DescribeAColumn(T, C.ColumnName, "", -1);
                }

                int nPos = 1;
                DescribeAColumn(T, "ayear", "Eserc. Disposizione", nPos++);
                DescribeAColumn(T, "idpaydisposition", "Num. Disposizione", nPos++);
                DescribeAColumn(T, "description", "Descrizione", nPos++);
                DescribeAColumn(T, "total", "Importo Totale", nPos++);
                DescribeAColumn(T, "npay", "Eserc. Mandato", nPos++);
                DescribeAColumn(T, "npay", "Num. Mandato", nPos++);
            }
        }
    }
}
