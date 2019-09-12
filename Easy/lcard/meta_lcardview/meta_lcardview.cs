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
using System.Collections.Generic;
using System.Text;
using metaeasylibrary;
using metadatalibrary;
using System.Data;

namespace meta_lcardview {
    public class Meta_lcardview : Meta_easydata {
        public Meta_lcardview(DataAccess Conn, MetaDataDispatcher Dispatcher)
            :
           base(Conn, Dispatcher, "lcardview") {
            ListingTypes.Add("default");
            ListingTypes.Add("ricarica");
        }

        public override void DescribeColumns(DataTable T, string ListingType) {
            base.DescribeColumns(T, ListingType);
            if (ListingType == "default") {
                foreach (DataColumn C in T.Columns) {
                    DescribeAColumn(T, C.ColumnName, "", -1);
                }
                int npos = 1;
                DescribeAColumn(T, "title", "Intestazione", npos++);
                DescribeAColumn(T, "store", "magazzino", npos++);
                DescribeAColumn(T, "manager", "Responsabile", npos++);
            }
            if (ListingType == "ricarica") {
                foreach (DataColumn C in T.Columns) {
                    DescribeAColumn(T, C.ColumnName, "", -1);
                }
                int npos = 1;
                DescribeAColumn(T, "title", "Intestazione", npos++);
                DescribeAColumn(T, "store", "magazzino", npos++);
            }
        }
    }
}
