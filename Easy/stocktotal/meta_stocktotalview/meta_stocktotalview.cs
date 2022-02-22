
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
using metaeasylibrary;
using metadatalibrary;
using System.Windows.Forms;
using System.Data;

namespace meta_stocktotalview {
	/// <summary>
    /// Summary description for meta_stocktotalview.
	/// </summary>
	public class Meta_stocktotalview : Meta_easydata {
        public Meta_stocktotalview (DataAccess Conn, MetaDataDispatcher Dispatcher)
            :
            base(Conn, Dispatcher, "stocktotalview") {
			ListingTypes.Add("default");
			DefaultListType = "default";
			Name = "Totale Magazzino";
		}
        private string[] mykey = new string[] { "idlist", "idstore" };

        public override string[] primaryKey() {
            return mykey;
        }
        public override void DescribeColumns(DataTable T, string listtype) {
			base.DescribeColumns(T, listtype);
			int nPos = 1;
			switch (listtype) {
				case "default": {
					foreach (DataColumn C in T.Columns) {
						DescribeAColumn(T, C.ColumnName, "", -1);
					}
                    DescribeAColumn(T, "idstore", ".Cod. magazzino", nPos++);
                    DescribeAColumn(T, "idlist", ".Cod. listino", nPos++);
					DescribeAColumn(T, "store", "Magazzino", nPos++);
					DescribeAColumn(T, "list",  "Voce Listino", nPos++);
					DescribeAColumn(T, "intcode", "Codice interno", nPos++);
					DescribeAColumn(T, "codelistclass", "Cod. classificazione", nPos++);
					DescribeAColumn(T, "listclass", "Classificazione", nPos++);
					DescribeAColumn(T, "number", "Quantità non evasa", nPos++);
                    HelpForm.SetFormatForColumn(T.Columns["number"], "n");
					break;
				}
			}
		} 
	}
}

