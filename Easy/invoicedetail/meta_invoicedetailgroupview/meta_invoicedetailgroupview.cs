
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
using metaeasylibrary;
using metadatalibrary;
using System.Data;

namespace meta_invoicedetailgroupview {
    public class Meta_invoicedetailgroupview :Meta_easydata {
        public Meta_invoicedetailgroupview(DataAccess Conn, MetaDataDispatcher Dispatcher) :
            base(Conn, Dispatcher, "invoicedetailgroupview") {
            Name = "Riga Fattura";
            ListingTypes.Add("dettaglio");
        }

        public override string GetSorting(string ListingType) {
            string sorting;
            if (ListingType == "dettaglio") {
                sorting = "invoicekind asc,yinv desc,ninv desc";
                return sorting;
            }
            return base.GetSorting(ListingType);
        }
        private string[] mykey = new string[] { "idinvkind", "yinv", "ninv", "invidgroup" };
        public override string[] primaryKey() {
            return mykey;
        }
        public override void DescribeColumns(DataTable T, string listtype) {
            base.DescribeColumns(T, listtype);
            if (listtype == "dettaglio") {
                foreach (DataColumn C in T.Columns)
                    DescribeAColumn(T, C.ColumnName, "", -1);
                DescribeAColumn(T, "invoicekind", "Tipo", 1);
                DescribeAColumn(T, "yinv", "Esercizio", 2);
                DescribeAColumn(T, "ninv", "Numero", 3);
                DescribeAColumn(T, "invidgroup", "Num. riga", 4);
                DescribeAColumn(T, "detaildescription", "Descrizione", 6);
                DescribeAColumn(T, "registry", "Percipiente", 7);
                DescribeAColumn(T, "number", "Q.tà fatturata", 8);
                HelpForm.SetFormatForColumn(T.Columns["number"], "n");

            }
        }

    }
}
