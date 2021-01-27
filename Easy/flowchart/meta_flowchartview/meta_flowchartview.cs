
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
using metadatalibrary;
using metaeasylibrary;
using System.Data;

namespace meta_flowchartview {
    public class Meta_flowchartview : Meta_easydata {
        int esercizio;
        public Meta_flowchartview(DataAccess Conn, MetaDataDispatcher Dispatcher)
            :
                base(Conn, Dispatcher, "flowchartview") {
            Name = "Organigramma";
            EditTypes.Add("default");
            ListingTypes.Add("default");
            esercizio = Convert.ToInt32(GetSys("esercizio"));
        }

        public override string GetStaticFilter(string ListingType) {
            if ((ListingType == "default") || (ListingType == "tree") || (ListingType == "treall")) {
                string filteresercizio = QHS.CmpEq("ayear", GetSys("esercizio"));
                return filteresercizio;
            }
            return base.GetStaticFilter(ListingType);
        }

        public override void DescribeColumns(DataTable T, string ListingType) {
            base.DescribeColumns(T, ListingType);
            if ((ListingType == "default") || (ListingType == "tree") || (ListingType == "treeall")) {
                foreach (DataColumn C in T.Columns)
                    DescribeAColumn(T, C.ColumnName, "", -1);
                int nPos = 1;
                DescribeAColumn(T, "codeflowchart", "Codice", nPos++);
                DescribeAColumn(T, "title", "Denominazione", nPos++);
                DescribeAColumn(T, "fax", "Fax", nPos++);
                DescribeAColumn(T, "phone", "Tel.", nPos++);
                DescribeAColumn(T, "address", "Indirizzo", nPos++);
                DescribeAColumn(T, "cap", "C.A.P.", nPos++);
                DescribeAColumn(T, "city", "Città", nPos++);
            }
        }
    }
}
