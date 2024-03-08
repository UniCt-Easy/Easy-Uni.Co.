
/*
Easy
Copyright (C) 2024 Università degli Studi di Catania (www.unict.it)
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
using System.Data;
using System.Windows.Forms;
using metadatalibrary;
using metaeasylibrary;


namespace meta_relation
{
    public class Meta_relation : Meta_easydata {
        public Meta_relation(DataAccess Conn, MetaDataDispatcher Dispatcher)
            :base(Conn, Dispatcher, "relation") {
            EditTypes.Add("default");
            EditTypes.Add("child");
            ListingTypes.Add("default");
        }
        protected override Form GetForm(string FormName) {
            if (FormName == "default") {
                Name = "Relazione";
                DefaultListType = "default";
                return GetFormByDllName("relation_default");
            }
            if (FormName == "child") {
                Name = "Relazione";
                DefaultListType = "default";
                return GetFormByDllName("relation_default");
            }
            return null;
        }

        public override DataRow Get_New_Row(DataRow ParentRow, DataTable T) {
            RowChange.MarkAsAutoincrement(T.Columns["idrelation"], null, null, 0);
            return base.Get_New_Row(ParentRow, T);
        }
        public override void DescribeColumns(DataTable T, string ListingType) {
            base.DescribeColumns(T, ListingType);
            foreach (DataColumn C in T.Columns) {
                DescribeAColumn(T, C.ColumnName, "", -1);
            }

            if (ListingType == "parent") {
                int nPos = 1;
                DescribeAColumn(T, "parenttable", "Tab.Padre", nPos++);
                DescribeAColumn(T, "description", "Significato nella child", nPos++);
            }
            if (ListingType == "child") {
                int nPos = 1;
                DescribeAColumn(T, "childtable", "Tab.Figlia", nPos++);
                DescribeAColumn(T, "title", "Tabella Child", nPos++);
                DescribeAColumn(T, "description", "Significato nella child", nPos++);
            }
            return;
        }

    }
}
