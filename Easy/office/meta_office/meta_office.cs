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

ï»¿using System;
using System.Data;
using System.Windows.Forms;
using metaeasylibrary;
using metadatalibrary;


namespace meta_office
{
    public class Meta_office : Meta_easydata {
        public Meta_office(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "office") 
		{
            EditTypes.Add("default");
            ListingTypes.Add("default");
        }

        protected override Form GetForm(string EditType) {
            if (EditType == "default") {
                Name = "Ufficio";
                DefaultListType = "default";
                return GetFormByDllName("office_default");
            }
            return null;
        }

        public override void SetDefaults(DataTable PrimaryTable) {
            MetaData.SetDefault(PrimaryTable, "active", "S");
            base.SetDefaults(PrimaryTable);
        }

        public override void DescribeColumns(DataTable T, string ListingType) {
            base.DescribeColumns(T, ListingType);

            if (ListingType == "default") {
                foreach (DataColumn C in T.Columns)
                    DescribeAColumn(T, C.ColumnName, "",-1);
                int pos = 1;

                DescribeAColumn(T, "code", "Codice",pos++);
                DescribeAColumn(T, "title", "Denominazione", pos++);
                DescribeAColumn(T, "description", "Descrizione", pos++);
                DescribeAColumn(T, "email", "E-mail", pos++);
                DescribeAColumn(T, "active", "Attivo", pos++);
            }
        }

        public override DataRow Get_New_Row(DataRow ParentRow, DataTable T) {
            RowChange.MarkAsAutoincrement(T.Columns["idoffice"], null,null, 7);
            return base.Get_New_Row(ParentRow, T);
        }
    }
}
