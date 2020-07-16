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
using System.Collections.Generic;
using System.Text;
using metadatalibrary;
using metaeasylibrary;
using System.Data;
using System.Windows.Forms;

namespace meta_securityvar {
    public class Meta_securityvar : Meta_easydata {
        public Meta_securityvar(DataAccess Conn, MetaDataDispatcher Dispatcher)
            :
            base(Conn, Dispatcher, "securityvar") {
            EditTypes.Add("default");
            ListingTypes.Add("default");
        }

        protected override Form GetForm(string FormName) {
            if (FormName == "default") {
                Name = "Variabili di Sicurezza";
                DefaultListType = "default";
                return MetaData.GetFormByDllName("securityvar_default");
            }
            return null;
        }

        public override void DescribeColumns(DataTable T, string ListingType) {
            base.DescribeColumns(T, ListingType);
            foreach (DataColumn C in T.Columns) {
                DescribeAColumn(T, C.ColumnName, "", -1);
            }
            if (ListingType == "default") {
                int nPos = 1;
                DescribeAColumn(T, "idsecurityvar", "ID. Var.", nPos++);
                DescribeAColumn(T, "description", "Descr. Variabile", nPos++);
                DescribeAColumn(T, "variablename", "Nome Var.", nPos++);
                DescribeAColumn(T, "value", "Valore", nPos++);
                DescribeAColumn(T, "kind", "Tipo", nPos++);
            }
            return;
        }

        public override DataRow Get_New_Row(DataRow ParentRow, DataTable T) {
            RowChange.MarkAsAutoincrement(T.Columns["idsecurityvar"], null, null, 0);
            return base.Get_New_Row(ParentRow, T);
        }
    }
}
