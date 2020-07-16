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
using System.Windows.Forms;
using System.Data;
using metaeasylibrary;
using metadatalibrary;


namespace meta_finvarkind
{
    /// <summary>
    /// Summary description for Class1.
    /// </summary>
    public class Meta_finvarkind : Meta_easydata {
        public Meta_finvarkind(DataAccess Conn, MetaDataDispatcher Dispatcher)
            :
            base(Conn, Dispatcher, "finvarkind") {
            EditTypes.Add("default");
            ListingTypes.Add("default");
            Name = "Tipo Classificazione";
        }
        public override void SetDefaults(DataTable PrimaryTable) {
            base.SetDefaults(PrimaryTable);
        }

        public override DataRow Get_New_Row(DataRow ParentRow, DataTable T) {
            RowChange.MarkAsAutoincrement(T.Columns["idfinvarkind"], null, null, 7);

            return base.Get_New_Row(ParentRow, T);
        }
        protected override Form GetForm(string FormName) {
            if (FormName == "default" ) {
                DefaultListType = "default";
                return MetaData.GetFormByDllName("finvarkind_default");
            }

            return null;
        }

        public override void DescribeColumns(DataTable T, string ListingType) {
            base.DescribeColumns(T, ListingType);
            if (ListingType == "default") {
                foreach (DataColumn C in T.Columns) {
                    DescribeAColumn(T, C.ColumnName, "", -1);
                }
                int nPos = 1;
                DescribeAColumn(T, "codevarkind", "Codice", nPos++);
                DescribeAColumn(T, "description", "Descrizione", nPos++);
            }
        }
        //public override DataRow SelectOne(string ListingType, string filter, string searchtable, DataTable Exclude) {
        //    return base.SelectOne(ListingType, filter, "finvarkind", Exclude);
        //}


    }
}
