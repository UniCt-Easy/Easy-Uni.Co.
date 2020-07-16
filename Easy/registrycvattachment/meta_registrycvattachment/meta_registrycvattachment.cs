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


namespace meta_registrycvattachment {
    public class Meta_registrycvattachment : Meta_easydata {
        public Meta_registrycvattachment(DataAccess Conn, MetaDataDispatcher Dispatcher)
            :
            base(Conn, Dispatcher, "registrycvattachment") {
            EditTypes.Add("default");
            ListingTypes.Add("lista");
        }
        protected override Form GetForm(string EditType) {
            if (EditType == "default") {
                Name = "CV";
                return GetFormByDllName("registrycvattachment_default");
            }
            return null;
        }
        public override DataRow Get_New_Row(DataRow ParentRow, DataTable T) {
            RowChange.SetSelector(T, "idreg");
            RowChange.MarkAsAutoincrement(T.Columns["idregistrycvattachment"], null, null, 7);
            DataRow R = base.Get_New_Row(ParentRow, T);
            return R;
        }

        public override void DescribeColumns(DataTable T, string listtype) {
            base.DescribeColumns(T, listtype);
            if (listtype == "lista") {
                foreach (DataColumn C in T.Columns)
                    DescribeAColumn(T, C.ColumnName, "", -1);

                int nPos = 1;
                DescribeAColumn(T, "filename", "Nome file", nPos++);
            }
        }
        public override bool IsValid(DataRow R, out string errmess, out string errfield) {
            if (!base.IsValid(R, out errmess, out errfield)) return false;
            if (R["referencedate"] == DBNull.Value) {
                    errmess = "Attenzione! E' necessario inserire una data di riferimento per il CV.";
                    errfield = "referencedate";
                    return false;
                }
            return true;
        }
    }
}
