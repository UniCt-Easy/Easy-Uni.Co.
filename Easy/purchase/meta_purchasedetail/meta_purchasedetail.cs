
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


using metadatalibrary;
using metaeasylibrary;
using System.Data;
using System.Windows.Forms;

namespace meta_purchasedetail {

    public class Meta_purchasedetail : Meta_easydata {

        public Meta_purchasedetail(DataAccess Conn, MetaDataDispatcher Dispatcher) : base(Conn, Dispatcher, "purchasedetail") {
            ListingTypes.Add("list");
            EditTypes.Add("single");
        }

        protected override Form GetForm(string EditType) {
            if (EditType == "single") {
                DefaultListType = "list";
                Name = "Dettaglio ordine di fornitura";
                return GetFormByDllName("purchasedetail_single");
            }

            return null;
        }

        public override void SetDefaults(DataTable T) {
            base.SetDefaults(T);

            SetDefault(T, "quantity", 1);
        }

        public override DataRow Get_New_Row(DataRow ParentRow, DataTable T) {
            RowChange.SetSelector(T, "idpurchase");
            RowChange.MarkAsAutoincrement(T.Columns["iddetail"], null, null, 0);

            return base.Get_New_Row(ParentRow, T);
        }

        public override void DescribeColumns(DataTable T, string ListingType) {
            base.DescribeColumns(T, ListingType);

            if (ListingType == "list") {
                foreach (DataColumn C in T.Columns) {
                    DescribeAColumn(T, C.ColumnName, "", -1);
                }

                int nPos = 1;
                DescribeAColumn(T, "!intcode", "Codice articolo", "listview.intcode", nPos++);
                DescribeAColumn(T, "!description", "Desc. articolo", "listview.description", nPos++);
                DescribeAColumn(T, "quantity", "Quantità", nPos++);
                DescribeAColumn(T, "!total", "Totale", nPos++);

                ComputeRowsAs(T, ListingType);
            }
        }

        public override bool IsValid(DataRow R, out string errmess, out string errfield) {
            if (R.IsNull("idlist")) {
                errmess = "Selezionare un listino";
                errfield = "idlist";
                return false;
            }

            return base.IsValid(R, out errmess, out errfield);
        }

        public override void CalculateFields(DataRow R, string ListingType) {
            if (ListingType == "list") {
                var imponibile = R.Field<decimal>("unitprice");
                var imposta = R.Field<decimal>("unitiva");

                if (R.Table.Columns.Contains("!total")) {
                    R.SetField("!total", imponibile + imposta);
                }
            }
        }

    }

}
