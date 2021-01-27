
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
using System.Windows.Forms;

namespace meta_accmotivesorting {
    public class Meta_accmotivesorting : Meta_easydata {
        public Meta_accmotivesorting(DataAccess Conn, MetaDataDispatcher Dispatcher)
            :
            base(Conn, Dispatcher, "accmotivesorting") {
            EditTypes.Add("single");
            ListingTypes.Add("default");
        }

        protected override Form GetForm(string FormName) {

            if (FormName == "single") {
                Name = "Classificazione causale E/P";
                DefaultListType = "default";
                return GetFormByDllName("accmotivesorting_single");
            }
            return null;
        }

        public override void DescribeColumns(DataTable T, string ListingType) {
            base.DescribeColumns(T, ListingType);
            foreach (DataColumn C in T.Columns) {
                DescribeAColumn(T, C.ColumnName, "", -1);
            }
            int nPos = 1;
            DescribeAColumn(T, "!sortingkind", "Tipo", "sortingview.sortingkind", nPos++);
            DescribeAColumn(T, "!codiceclass", "Codice", "sortingview.sortcode", nPos++);
            DescribeAColumn(T, "!descrizione", "Descrizione", "sortingview.description", nPos++);
        }
    }
}
