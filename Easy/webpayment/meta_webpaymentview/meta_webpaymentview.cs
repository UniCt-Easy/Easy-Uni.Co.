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

﻿using System;
using System.Collections.Generic;
using System.Text;
using metadatalibrary;
using metaeasylibrary;
using System.Data;

namespace meta_webpaymentview {
    public class Meta_webpaymentview :Meta_easydata {
        public Meta_webpaymentview(DataAccess Conn, MetaDataDispatcher Dispatcher)
            : base(Conn, Dispatcher, "webpaymentview") {
            ListingTypes.Add("list");
            Name = "Prenotazione";
        }
        private string[] mykey = new string[] { "idwebpayment" };
        public override string[] primaryKey() {
            return mykey;
        }
        public override void DescribeColumns(DataTable T, string ListingType) {
            base.DescribeColumns(T, ListingType);
            if (ListingType == "list") {
                foreach (DataColumn C in T.Columns) {
                    DescribeAColumn(T, C.ColumnName, "", -1);
                }
                int nPos = 1;

                DescribeAColumn(T, "ywebpayment", "Anno", nPos++);
                DescribeAColumn(T, "nwebpayment", "Numero", nPos++);
                DescribeAColumn(T, "surname", "Cognome Richiedente", nPos++);
                DescribeAColumn(T, "forename", "Nome Richiedente", nPos++);
                DescribeAColumn(T, "cf", "CF", nPos++);
                DescribeAColumn(T, "webpaymentstatus", "Stato", nPos++);
                DescribeAColumn(T, "adate", "Data", nPos++);
            }
    }

        public override string GetSorting(string ListingType) {
            string sorting;
            if (ListingType == "list") {
                sorting = "ywebpayment desc,nwebpayment desc";
                return sorting;
            }
            return base.GetSorting(ListingType);
        }


    }


}
