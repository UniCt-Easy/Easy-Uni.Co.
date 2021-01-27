
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
using System.Data;
using metaeasylibrary;
using metadatalibrary;
using System.Windows.Forms;

namespace meta_ddt_in_motive
{
    /// <summary>
    /// Summary description for Class1.
    /// </summary>
    public class Meta_ddt_in_motive : Meta_easydata{
        public Meta_ddt_in_motive(DataAccess Conn, MetaDataDispatcher Dispatcher):
            base(Conn, Dispatcher, "ddt_in_motive"){
            EditTypes.Add("lista");
            ListingTypes.Add("lista");
            Name = " Causali Bolla in Ingresso";
        }
        protected override Form GetForm(string FormName){
            if (FormName == "lista"){
                ActAsList();
                SearchEnabled = false;
                return MetaData.GetFormByDllName("ddt_in_motive_lista");
            }
            return null;
        }

        public override void SetDefaults(DataTable PrimaryTable){
            base.SetDefaults(PrimaryTable);
            SetDefault(PrimaryTable, "active", "S");
        }

        public override DataRow Get_New_Row(DataRow ParentRow, DataTable T){
            RowChange.MarkAsAutoincrement(T.Columns["idddt_in_motive"], null, null, 0);
            return base.Get_New_Row(ParentRow, T);

        }

        public override void DescribeColumns(DataTable T, string listtype){
            base.DescribeColumns(T, listtype);

            if (listtype == "lista"){
                foreach (DataColumn C in T.Columns)
                    DescribeAColumn(T, C.ColumnName, "");

                DescribeAColumn(T, "idddt_in_motive", "Codice");
                DescribeAColumn(T, "description", "Descrizione");
                DescribeAColumn(T, "!storeload_motive", "Causale", "storeload_motive.description");
                DescribeAColumn(T, "active", "Attivo");
            }
        }
    }
}

