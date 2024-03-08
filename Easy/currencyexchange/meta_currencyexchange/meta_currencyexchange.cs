
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


using System.Data;
using metaeasylibrary;
using metadatalibrary;
using System.Windows.Forms;

namespace meta_currencyexchange {

    public class Meta_currencyexchange : Meta_easydata {

        public Meta_currencyexchange(DataAccess Conn, MetaDataDispatcher Dispatcher) :
            base(Conn, Dispatcher, "currencyexchange") {
            ListingTypes.Add("default");
            Name = "Cambio";
        }

        public override DataRow SelectOne(string ListingType, string filter, string searchtable, DataTable ToMerge) {
            if (ListingType == "default")
                return base.SelectOne(ListingType, filter, "currencyexchange", ToMerge);

            return base.SelectOne(ListingType, filter, searchtable, ToMerge);
        }

        public override void DescribeColumns(DataTable T, string listtype) {
            base.DescribeColumns(T, listtype);
            if (listtype == "default") {
                foreach (DataColumn C in T.Columns)
                    DescribeAColumn(T, C.ColumnName, "", -1);
                int nPos = 1;
                DescribeAColumn(T, "referencedate", "Data", nPos++);
                DescribeAColumn(T, "eurocurrencyrate", "Tasso", nPos++);
                HelpForm.SetFormatForColumn(T.Columns["eurocurrencyrate"], "fixed.8...1");
            }
        }

        public override string GetSorting(string ListingType) {
            if (ListingType == "default") return "idcurrencyexchange asc";

            return base.GetSorting(ListingType);
        }

        public override DataRow Get_New_Row(DataRow ParentRow, DataTable T) {
            RowChange.SetSelector(T, T.Columns["idcurrency"].ColumnName);
            RowChange.MarkAsAutoincrement(T.Columns["idcurrencyexchange"], null, null, 7);
            RowChange.setMinimumTempValue(T.Columns["idcurrencyexchange"], 9999000);
            return base.Get_New_Row(ParentRow, T);
        }
    }
}
