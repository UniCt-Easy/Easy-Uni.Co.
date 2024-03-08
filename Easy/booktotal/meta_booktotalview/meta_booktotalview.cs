
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
using metaeasylibrary;
using metadatalibrary;
using System.Windows.Forms;
using System.Data;

namespace meta_booktotalview {
	/// <summary>
    /// Summary description for meta_booktotalview.
	/// </summary>
	public class Meta_booktotalview : Meta_easydata {
		public Meta_booktotalview(DataAccess Conn, MetaDataDispatcher Dispatcher):
            base(Conn, Dispatcher, "booktotalview") {
			ListingTypes.Add("default");
            ListingTypes.Add("list");
			DefaultListType = "default";
			Name = "Totale Prenotazioni";
		}

		public override void DescribeColumns(DataTable T, string listtype) {
			base.DescribeColumns(T, listtype);
			int nPos = 1;
			switch (listtype) {
				case "default": {
					foreach (DataColumn C in T.Columns) {
						DescribeAColumn(T, C.ColumnName, "", -1);
					}
                    DescribeAColumn(T, "idbooking", ".Cod. prenotazione", nPos++);
                    DescribeAColumn(T, "idlist", ".Cod. listino", nPos++);
                    DescribeAColumn(T, "idstore", ".Cod. magazzino", nPos++);
                    DescribeAColumn(T, "idstock", ".Cod. stock", nPos++);
                    DescribeAColumn(T, "manager", "Responsabile", nPos++);
                    DescribeAColumn(T, "list", "Voce Listino", nPos++);
                    DescribeAColumn(T, "allocated", "Q. disponibile", nPos++);
                    DescribeAColumn(T, "number", "Quantità inevasa", nPos++);
                    DescribeAColumn(T, "store", "Magazzino", nPos++);
                    //DescribeAColumn(T, "intcode", "Codice interno", nPos++);
					//DescribeAColumn(T, "codelistclass", "Cod. classificazione", nPos++);
					//DescribeAColumn(T, "listclass", "Classificazione", nPos++);
					DescribeAColumn(T, "ybooking", "Eserc. prenotazione", nPos++);
					DescribeAColumn(T, "nbooking", "Numero prenotazione", nPos++);
                    HelpForm.SetFormatForColumn(T.Columns["number"], "n");
                    HelpForm.SetFormatForColumn(T.Columns["allocated"], "n");
					break;
				}
                case "list": {
                    foreach (DataColumn C in T.Columns) {
                        DescribeAColumn(T, C.ColumnName, "", -1);
                    }
                    DescribeAColumn(T, "store", "Magazzino", nPos++);
                    DescribeAColumn(T, "manager", "Responsabile", nPos++);
                    DescribeAColumn(T, "number", "Quantità non evasa", nPos++);
                    HelpForm.SetFormatForColumn(T.Columns["number"], "n");
                    DescribeAColumn(T, "allocated", "Quantità allocata", nPos++);
                    HelpForm.SetFormatForColumn(T.Columns["allocated"], "n");
                    DescribeAColumn(T, "booked", "Quantità Richiesta", nPos++);
                    HelpForm.SetFormatForColumn(T.Columns["booked"], "n");
                    break;
                }
			}
		} 
	}
}

