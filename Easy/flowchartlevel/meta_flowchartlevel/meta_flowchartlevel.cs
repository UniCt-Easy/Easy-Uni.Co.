
/*
Easy
Copyright (C) 2024 UniversitÓ degli Studi di Catania (www.unict.it)
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
using metaeasylibrary;
using metadatalibrary;

namespace meta_flowchartlevel {
    public class Meta_flowchartlevel : Meta_easydata {
        public Meta_flowchartlevel(DataAccess Conn, MetaDataDispatcher Dispatcher)
            :
            base(Conn, Dispatcher, "flowchartlevel") {
            EditTypes.Add("default");
            ListingTypes.Add("default");
        }
        protected override Form GetForm(string FormName) {
            if (FormName == "default") {
                Name = "Livelli dell'organigramma";
                ActAsList();
                return MetaData.GetFormByDllName("flowchartlevel_default");
            }

            return null;
        }

        public override void SetDefaults(DataTable PrimaryTable) {
            base.SetDefaults(PrimaryTable);
            SetDefault(PrimaryTable, "ayear", GetSys("esercizio"));
        }

        public override DataRow Get_New_Row(DataRow ParentRow, DataTable T) {
            RowChange.MarkAsAutoincrement(T.Columns["nlevel"], null,
                null, 0);
            RowChange.SetSelector(T, "ayear");
            return base.Get_New_Row(ParentRow, T);
        }

        public override void DescribeColumns(DataTable T, string listtype) {
            base.DescribeColumns(T, listtype);
            foreach (DataColumn C in T.Columns)
                DescribeAColumn(T, C.ColumnName, "");
            DescribeAColumn(T, "nlevel", "Codice Livello");
            DescribeAColumn(T, "description", "Descrizione");
        }  
    }
}
