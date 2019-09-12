/*
    Easy
    Copyright (C) 2019 Università degli Studi di Catania (www.unict.it)

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
using metadatalibrary;
using metaeasylibrary;

namespace meta_estimatedetailgroupview {
    public class Meta_estimatedetailgroupview : Meta_easydata {
        public Meta_estimatedetailgroupview(DataAccess Conn, MetaDataDispatcher Dispatcher)
            :
            base(Conn, Dispatcher, "estimatedetailgroupview") {
            Name = "Riga Contratto attivo";
            ListingTypes.Add("dettaglio");
        }

        public override string GetSorting(string ListingType) {
            string sorting;
            if (ListingType == "dettaglio") {
                sorting = "estimkind asc,yestim desc,nestim desc";
                return sorting;
            }
            return base.GetSorting(ListingType);
        }

        private string[] mykey = new string[] { "idestimkind", "yestim", "nestim", "idgroup" };
        public override string[] primaryKey() {
            return mykey;
        }
        public override void DescribeColumns(DataTable T, string listtype) {
            base.DescribeColumns(T, listtype);
            if (listtype == "dettaglio") {
                foreach (DataColumn C in T.Columns)
                    DescribeAColumn(T, C.ColumnName, "", -1);
                int nPos = 1;
                DescribeAColumn(T, "estimkind", "Tipo", nPos++);
                DescribeAColumn(T, "yestim", "Esercizio", nPos++);
                DescribeAColumn(T, "nestim", "Numero", nPos++);
                DescribeAColumn(T, "idgroup", "Num. riga", nPos++);
                DescribeAColumn(T, "idinv", "Class. inventariale", nPos++);
                DescribeAColumn(T, "detaildescription", "Descrizione", nPos++);
                DescribeAColumn(T, "registry", "Versante", nPos++);
                DescribeAColumn(T, "taxable", "Importo Unitario", nPos++);
                DescribeAColumn(T, "taxable_euro", "Imponibile totale", nPos++);
                DescribeAColumn(T, "ivakind", "Tipo IVA", nPos++);
                DescribeAColumn(T, "iva_euro", "Iva", nPos++);
                DescribeAColumn(T, "number", "Q.tà", nPos++);
                DescribeAColumn(T, "start", "Inizio val.", nPos++);
                DescribeAColumn(T, "stop", "Fine val.", nPos++);
                HelpForm.SetFormatForColumn(T.Columns["number"], "n");

            }
        }

    }
}