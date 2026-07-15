/*
Easy
Copyright (C) 2026 Università degli Studi di Catania (www.unict.it)
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

namespace meta_debito {
    /// <summary>
    /// Summary description for Class1.
    /// </summary>
    public class Meta_debito : Meta_easydata {
        public Meta_debito(DataAccess Conn, MetaDataDispatcher Dispatcher) :
            base(Conn, Dispatcher, "debito") {
            EditTypes.Add("default");
            ListingTypes.Add("default");
        }
        protected override Form GetForm(string FormName) {
            return null;
        }

        public override void SetDefaults(DataTable PrimaryTable) {
            base.SetDefaults(PrimaryTable);
        }

        public override DataRow Get_New_Row(DataRow ParentRow, DataTable T) {
            RowChange.MarkAsAutoincrement(T.Columns["iddebito"], null, null, 0);
            RowChange.setMinimumTempValue(T.Columns["iddebito"], 99990000);
            DataRow R = base.Get_New_Row(ParentRow, T);
            return R;
        }


        public override DataRow SelectOne(string ListingType, string filter, string searchtable, DataTable ToMerge) {
            return base.SelectOne(ListingType, filter, searchtable, ToMerge);
        }

        public override void DescribeColumns(DataTable T, string ListingType) {
            base.DescribeColumns(T, ListingType);
        }
    }
}