
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
using System.Data;
using System.Windows.Forms;
using metadatalibrary;
using metaeasylibrary;

namespace meta_sortingyearview 
{
    /// <summary>
    /// Summary description for Class1.
    /// </summary>
    public class Meta_sortingyearview : Meta_easydata {
        public Meta_sortingyearview (DataAccess Conn, MetaDataDispatcher Dispatcher)
            :
            base(Conn, Dispatcher, "sortingyearview") {
            ListingTypes.Add("treenew");
        }
        private string[] mykey = new string[] { "idsor", "ayear" };
        public override string[] primaryKey() {
            return mykey;
        }

        public override void DescribeColumns (DataTable T, string ListingType) {
            base.DescribeColumns(T, ListingType);
            if (ListingType == "treenew") {
                foreach (DataColumn C in T.Columns) {
                    DescribeAColumn(T, C.ColumnName, "");
                }
                int nPos = 1;
                DescribeAColumn(T, "sorting", "Descr. class.", nPos++);
                DescribeAColumn(T, "idman", "Codice resp.", nPos++);
                DescribeAColumn(T, "manager", "Responsabile", nPos++);
                DescribeAColumn(T, "sortcode", "Codice", nPos++);
                DescribeAColumn(T, "description", "Denominazione", nPos++);
				DescribeAColumn(T, "start", "Anno inizio", nPos++);
				DescribeAColumn(T, "stop", "Anno fine", nPos++);
				DescribeAColumn(T, "incomeprevision", "Prev. Entrata", nPos++);
                DescribeAColumn(T, "totincomevariation", "Variazioni Prev. Entrata", nPos++);
                DescribeAColumn(T, "totincome", "Tot. Entrate", nPos++);
                DescribeAColumn(T, "currentincomeprevision", "Prev. Attuale Entrata", nPos++);
                DescribeAColumn(T, "availableincomeprevision","Prev. Disp. Entrata", nPos++);
                DescribeAColumn(T, "expenseprevision", "Prev. Spesa", nPos++);
                DescribeAColumn(T, "totexpensevariation","Variazioni Prev. Spesa", nPos++);
                DescribeAColumn(T, "totexpense", "Tot. Spese", nPos++);
                DescribeAColumn(T, "currentexpenseprevision", "Prev. Attuale Spesa", nPos++);
                DescribeAColumn(T, "availableexpenseprevision", "Prev. Disp. Spesa", nPos++);
               }
        }
    }
}
