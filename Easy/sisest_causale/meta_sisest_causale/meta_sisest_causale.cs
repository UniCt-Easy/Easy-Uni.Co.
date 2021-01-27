
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
using System.Windows.Forms;
using metaeasylibrary;
using metadatalibrary;

namespace meta_sisest_causale {
    /// <summary>
    /// Summary description for Class1.
    /// </summary>
    public class Meta_sisest_causale :Meta_easydata {
        public Meta_sisest_causale(DataAccess Conn, MetaDataDispatcher Dispatcher) :
            base(Conn, Dispatcher, "sisest_causale") {
            EditTypes.Add("default");
            ListingTypes.Add("default");
            ListingTypes.Add("elenco");
        }

        protected override Form GetForm(string FormName) {

            if (FormName == "default") {
                Name = "Causale SISEST";
                return GetFormByDllName("sisest_causale_default");
            }
            return null;
        }
        public override void SetDefaults(DataTable T) {
            base.SetDefaults(T);
            SetDefault(T, "active", "S");
            SetDefault(T, "ayear", Conn.GetSys("esercizio"));
        }

        public override void DescribeColumns(DataTable T, string listtype) {
            base.DescribeColumns(T, listtype);
            if (listtype == "default") {
                foreach (DataColumn C in T.Columns)
                    DescribeAColumn(T, C.ColumnName, "", -1);

                int nPos = 1;
                DescribeAColumn(T, "ayear", "Esercizio", nPos++);
                DescribeAColumn(T, "codesisest_causale", "Cod. Cassiere", nPos++);
                DescribeAColumn(T, "description", "Banca", nPos++);

            }
        }

        public override DataRow SelectOne(string ListingType, string filter, string searchtable, DataTable Exclude) {
            if (ListingType == "default")
                return base.SelectOne(ListingType, filter, "sisest_causaleview", Exclude);

            return base.SelectOne(ListingType, filter, "sisest_causale", Exclude);
        }

        public override bool IsValid(DataRow R, out string errmess, out string errfield) {
            if (!base.IsValid(R, out errmess, out errfield)) return false;
            return true;
        }

        public override DataRow Get_New_Row(DataRow ParentRow, DataTable T) {
            RowChange.MarkAsAutoincrement(T.Columns["idcausale"], null, null, 7);
            RowChange.setMinimumTempValue(T.Columns["idcausale"], 9999000);
            DataRow R = base.Get_New_Row(ParentRow, T);

            return R;
        }
    }
}
