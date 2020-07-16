/*
    Easy
    Copyright (C) 2020 Università degli Studi di Catania (www.unict.it)
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
using metaeasylibrary;
using metadatalibrary;
//Pino: using ordinegenerico; diventato inutile
using funzioni_configurazione;//funzioni_configurazione

namespace meta_itinerationattachment {
    public class Meta_itinerationattachment : Meta_easydata {
        public Meta_itinerationattachment(DataAccess Conn, MetaDataDispatcher Dispatcher)
            :
            base(Conn, Dispatcher, "itinerationattachment") {
            EditTypes.Add("default");
            ListingTypes.Add("default");
        }
        protected override Form GetForm(string EditType) {
            if (EditType == "default") return GetFormByDllName("itinerationattachment_default");
            return null;
        }
        public override DataRow Get_New_Row(DataRow ParentRow, DataTable T) {
            RowChange.SetSelector(T, "iditineration");
            RowChange.MarkAsAutoincrement(T.Columns["idattachment"], null, null, 7);
            DataRow R = base.Get_New_Row(ParentRow, T);
            return R;
        }

        public override void DescribeColumns(DataTable T, string listtype) {
            base.DescribeColumns(T, listtype);
            if (listtype == "default") {
                foreach (DataColumn C in T.Columns)
                    DescribeAColumn(T, C.ColumnName, "", -1);

                int nPos = 1;
                DescribeAColumn(T, "filename", "Nome file", nPos++);
                DescribeAColumn(T, "description", "descrizione", nPos++);
            }
        }

        public override bool IsValid(DataRow R, out string errmess, out string errfield) {
            if (!base.IsValid(R, out errmess, out errfield)) return false;

            if (R["filename"].ToString() == "") {
                errmess = "E' necessario selezionare un file";
                errfield = "filename";
                return false;
            }

            if (R["attachment"].ToString() == "") {
                errmess = "E' necessario selezionare un file (non vuoto)";
                errfield = "attachment";
                return false;
            }


            return true;
        }

    }
}
