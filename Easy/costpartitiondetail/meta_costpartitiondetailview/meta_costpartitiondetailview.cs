/*
Easy
Copyright (C) 2026 Università degli Studi di Catania (www.unict.it)
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
using System.Windows.Forms;
using System.Data;
using metaeasylibrary;
using metadatalibrary;

namespace meta_costpartitiondetailview {
	/// <summary>
	/// Summary description for Meta_costpartitiondetail.
	/// </summary>
	public class Meta_costpartitiondetailview : Meta_easydata {
		public Meta_costpartitiondetailview(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "costpartitiondetailview") {
			ListingTypes.Add("default");
			ListingTypes.Add("lista");
		}

		public override void DescribeColumns(DataTable T, string listtype) {
			base.DescribeColumns(T, listtype);
			if (listtype == "default" || listtype == "lista") {
				foreach (DataColumn C in T.Columns) {
					DescribeAColumn(T, C.ColumnName, "", -1);
				}

				int nPos = 1;
				object title1 = DBNull.Value;
				object title2 = DBNull.Value;
				object title3 = DBNull.Value;
				
				DescribeAColumn(T, "costpartitioncode", "Cod. Ripartizione", nPos++);
				DescribeAColumn(T, "title", "Denominazione", nPos++);
				DescribeAColumn(T, "active", "Attiva", nPos++);
				DescribeAColumn(T, "kind", "Tipo", nPos++);

				DescribeAColumn(T, "iddetail", "#", nPos);
				DescribeAColumn(T, "amount", "Importo", nPos++);
				DescribeAColumn(T, "rate", "Percentuale", nPos++);

				string filter = QHS.CmpEq("ayear", GetSys("esercizio"));
				DataTable tExpSetup = Conn.RUN_SELECT("config", "*", null,
					filter, null, null, true);

                if ((tExpSetup != null) && (tExpSetup.Rows.Count > 0)) {
                    DataRow r = tExpSetup.Rows[0];
                    object idsorkind1 = r["idsortingkind1"];
                    object idsorkind2 = r["idsortingkind2"];
                    object idsorkind3 = r["idsortingkind3"];

                    if (idsorkind1 != DBNull.Value) {
                        string filter1 = QHS.CmpEq("idsorkind", idsorkind1);
                        title1 = Conn.DO_READ_VALUE("sortingkind", filter1, "description");
                    }

                    if (idsorkind2 != DBNull.Value) {
                        string filter2 = QHS.CmpEq("idsorkind", idsorkind2);
                        title2 = Conn.DO_READ_VALUE("sortingkind", filter2, "description");
                    }

                    if (idsorkind3 != DBNull.Value) {
                        string filter3 = QHS.CmpEq("idsorkind", idsorkind3);
                        title3 = Conn.DO_READ_VALUE("sortingkind", filter3, "description");
                    }

                    if ((title1 != DBNull.Value) && (title1 != null))
                        DescribeAColumn(T, "sortcode1", title1.ToString(), nPos++);
                    if ((title2 != DBNull.Value) && (title2 != null))
                        DescribeAColumn(T, "sortcode2", title2.ToString(), nPos++);
                    if ((title3 != DBNull.Value) && (title3 != null))
                        DescribeAColumn(T, "sortcode3", title3.ToString(), nPos++);
                }

                ComputeRowsAs(T, listtype);
                HelpForm.SetFormatForColumn(T.Columns["rate"], "p6");
			}
		}
	}
}