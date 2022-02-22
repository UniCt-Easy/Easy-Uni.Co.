
/*
Easy
Copyright (C) 2022 Università degli Studi di Catania (www.unict.it)
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
using metadatalibrary;
using metaeasylibrary;


namespace meta_invoicedetaildeferred {
    /// <summary>
    /// Summary description for Meta_invoicedetaildeferred.
    /// </summary>
    public class Meta_invoicedetaildeferred : Meta_easydata {
        public Meta_invoicedetaildeferred(DataAccess Conn, MetaDataDispatcher Dispatcher) :
            base(Conn, Dispatcher, "invoicedetaildeferred") {
            EditTypes.Add("default");
            ListingTypes.Add("default");
        }

        public override void DescribeColumns(DataTable T, string ListingType) {
            base.DescribeColumns(T, ListingType);
            if (ListingType == "default") {
                foreach (DataColumn C in T.Columns) {
                    DescribeAColumn(T, C.ColumnName, "");
                }
                int nPos = 1;
                DescribeAColumn(T, "yivapay", "Eserc. Liquidazione", nPos++);
                DescribeAColumn(T, "nivapay", "Num. Liquidazione", nPos++);
                DescribeAColumn(T, "ivatotalpayed", "IVA Liquidata", nPos++);
                DescribeAColumn(T, "taxable", "Imponibile", nPos++);
            }
        }
    }
}
