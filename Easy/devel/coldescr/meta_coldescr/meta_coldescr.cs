
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

namespace meta_coldescr
{
    public class Meta_coldescr : Meta_easydata {
        public Meta_coldescr(DataAccess Conn, MetaDataDispatcher Dispatcher)
            :
            base(Conn, Dispatcher, "coldescr") {
            EditTypes.Add("default");
            ListingTypes.Add("default");
            ListingTypes.Add("main");
        }
        protected override Form GetForm(string FormName) {
            if (FormName == "default") {
                Name = "Descrizione campo";
                DefaultListType = "main";
                return MetaData.GetFormByDllName("coldescr_default");
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
                DescribeAColumn(T, "colname", "campo", nPos++);                
                DescribeAColumn(T, "title", "Significato", nPos++);
                DescribeAColumn(T, "description", "Spiegazione", nPos++);
                DescribeAColumn(T, "sqldeclaration", "tipo Sql", nPos++);
                DescribeAColumn(T, "primarykey", "Chiave", nPos++);
                DescribeAColumn(T, "system_type", "tipo .NET", nPos++);
                DescribeAColumn(T, "title", "Significato", nPos++);

            }
            if (ListingType == "main") {
                int nPos = 1;
                DescribeAColumn(T, "tablename", "Tabella", nPos++);
                DescribeAColumn(T, "colname", "campo", nPos++);
                DescribeAColumn(T, "title", "Significato", nPos++);
                DescribeAColumn(T, "description", "Spiegazione", nPos++);
                DescribeAColumn(T, "sqldeclaration", "tipo Sql", nPos++);
                DescribeAColumn(T, "primarykey", "Chiave", nPos++);
                DescribeAColumn(T, "system_type", "tipo .NET", nPos++);
                DescribeAColumn(T, "title", "Significato", nPos++);

            }
            return;
        }

    }

}
