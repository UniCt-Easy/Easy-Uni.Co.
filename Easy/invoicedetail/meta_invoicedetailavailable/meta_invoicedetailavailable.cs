/*
    Easy
    Copyright (C) 2019 Universit� degli Studi di Catania (www.unict.it)

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

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using metadatalibrary;
using metaeasylibrary;
using System.Data;


namespace meta_invoicedetailavailable
{
    /// <summary>
    /// Summary description for meta_invoicedetailavailable.
    /// </summary>
    public class Meta_invoicedetailavailable :Meta_easydata {
        public Meta_invoicedetailavailable(DataAccess Conn, MetaDataDispatcher Dispatcher) :
            base(Conn, Dispatcher, "invoicedetailavailable") {
            Name = "riga fattura";
            ListingTypes.Add("dettaglio");
        }

        public override string GetSorting(string ListingType) {
            string sorting;
            if (ListingType == "dettaglio") {
                sorting = "idinvkind asc,yinv desc,ninv desc";
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
                    DescribeAColumn(T, C.ColumnName, "");
                DescribeAColumn(T, "invkind", "Tipo", 1);
                DescribeAColumn(T, "yinv", "Esercizio", 2);
                DescribeAColumn(T, "ninv", "Numero", 3);
                DescribeAColumn(T, "invidgroup", "Gruppo", 4);
                DescribeAColumn(T, "registry", "Fornitore", 5);
                DescribeAColumn(T, "detaildescription", "Descrizione", 6);
                DescribeAColumn(T, "invoiced", "Q.tà fatturata", 7);
                DescribeAColumn(T, "loaded", "Q.tà associata a carichi", 7); 
                DescribeAColumn(T, "residual", "Disponibile a caricare", 8);
                HelpForm.SetFormatForColumn(T.Columns["loaded"], "n");
                HelpForm.SetFormatForColumn(T.Columns["invoiced"], "n");
                HelpForm.SetFormatForColumn(T.Columns["residual"], "n");
            }
        }
    }
}
