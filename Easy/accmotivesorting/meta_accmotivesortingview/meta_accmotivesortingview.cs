
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
using System.Data;
using metadatalibrary;
using metaeasylibrary;
using System.Windows.Forms;

namespace meta_accmotivesortingview {
    public class Meta_accmotivesortingview : Meta_easydata{
        public Meta_accmotivesortingview(DataAccess Conn, MetaDataDispatcher Dispatcher):
		base(Conn, Dispatcher, "accmotivesortingview") {
            ListingTypes.Add("default");
            EditTypes.Add("default");
        }
        public override void DescribeColumns(DataTable T, string listtype) {
            base.DescribeColumns(T, listtype);
            if (listtype == "default") {
                foreach (DataColumn C in T.Columns)
                    DescribeAColumn(T, C.ColumnName, "", -1);
                int nPos = 1;
                DescribeAColumn(T, "codemotive", "Codice Causale", nPos++);
                DescribeAColumn(T, "title", "Causale", nPos++);
                DescribeAColumn(T, "codesorkind", "Codice Tipo Class.", nPos++);
                DescribeAColumn(T, "sortingkind", "Tipo Class.", nPos++);
                DescribeAColumn(T, "sortcode", "Codice Class.", nPos++);
                DescribeAColumn(T, "sorting", "Classificazione", nPos++);
           }
        }
        protected override Form GetForm(string FormName) {
            if (FormName == "default") {
                DefaultListType = "default";
                Name = "Classificazione Causali EP";
                return GetFormByDllName("accmotivesortingview_default");
            }
            return null;
        }
    }
}
