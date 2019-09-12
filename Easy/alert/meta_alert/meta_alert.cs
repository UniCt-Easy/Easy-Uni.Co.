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
using metadatalibrary;
using metaeasylibrary;
using System.Data;
using System.Windows.Forms;

namespace meta_alert {
    public class Meta_alert : Meta_easydata {
        public Meta_alert(DataAccess Conn, MetaDataDispatcher Dispatcher)
            :
            base(Conn, Dispatcher, "alert") {
            Name = "Avvisi";
            EditTypes.Add("default");
            DefaultListType = "default";
        }
        protected override Form GetForm(string FormName) {
            switch (FormName) {
                case "default": return GetFormByDllName("alert_default");
            }
            return null;
        }
        public override void DescribeColumns(System.Data.DataTable T, string ListingType) {
            base.DescribeColumns(T);
            foreach (DataColumn c in T.Columns) DescribeAColumn(T, c.ColumnName, "");
            int nPos = 1;
            DescribeAColumn(T, "idalert", "Id.",nPos++);
            DescribeAColumn(T, "alertcode", "Codice Avviso",nPos++);
            DescribeAColumn(T, "description", "Avviso", nPos++);
            DescribeAColumn(T, "toshow", "Da mostrare", nPos++);
        }

        public override bool IsValid (DataRow R, out string errmess, out string errfield) {
            if (!base.IsValid(R, out errmess, out errfield)) return false;
            if (R["alertcode"] == DBNull.Value) {
                errmess = "Il campo \"Codice Avviso\" è obbligatorio";
                errfield = "alertcode";
                return false;
            }

            return true;
        }

        public override DataRow Get_New_Row(DataRow ParentRow, DataTable T) {
            RowChange.MarkAsAutoincrement(T.Columns["idalert"], null, null, 6);
            return base.Get_New_Row(ParentRow, T);
        }
    }
}