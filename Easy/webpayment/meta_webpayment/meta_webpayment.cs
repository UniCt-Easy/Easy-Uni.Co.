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

ï»¿using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;
using metadatalibrary;
using metaeasylibrary;
using funzioni_configurazione;

namespace meta_webpayment {
    public class Meta_webpayment :Meta_easydata {
        public Meta_webpayment(DataAccess Conn, MetaDataDispatcher Dispatcher)
            : base(Conn, Dispatcher, "webpayment") {
            Name = "Prenotazione Pagamenti";
            EditTypes.Add("default");
            ListingTypes.Add("list");
            ListingTypes.Add("default");
        }

        public override DataRow Get_New_Row(DataRow ParentRow, DataTable T) {
            RowChange.MarkAsAutoincrement(T.Columns["idwebpayment"], null, null, 0);
            RowChange.MarkAsAutoincrement(T.Columns["nwebpayment"], null, null, 0);
            RowChange.SetMySelector(T.Columns["nwebpayment"], "ywebpayment", 0);
            DataRow R = base.Get_New_Row(ParentRow, T);
            return R;
        }


        public override bool IsValid(DataRow R, out string errmess, out string errfield) {
            if (!base.IsValid(R, out errmess, out errfield)) return false;

            return true;
        }


        public override string GetSorting(string ListingType) {
            string sorting;
            if (ListingType == "list") {
                sorting = "ywebpayment desc,nwebpayment desc";
                return sorting;
            }
            return base.GetSorting(ListingType);
        }

        public override void SetDefaults(DataTable PrimaryTable) {
            base.SetDefaults(PrimaryTable);
            SetDefault(PrimaryTable, "ywebpayment", GetSys("esercizio"));
            SetDefault(PrimaryTable, "adate", GetSys("datacontabile"));
            SetDefault(PrimaryTable, "idwebpaymentstatus", 1);
        }

        public override DataRow SelectOne(string ListingType, string filter, string searchtable, DataTable ToMerge) {
            if (ListingType == "list") {
                return base.SelectOne(ListingType, filter, "webpaymentview", ToMerge);
            }
            return base.SelectOne(ListingType, filter, searchtable, ToMerge);
        }
        public override void DescribeColumns(DataTable T, string ListingType) {
            base.DescribeColumns(T, ListingType);
            //if (ListingType == "list") {
            //    foreach (DataColumn C in T.Columns) {
            //        DescribeAColumn(T, C.ColumnName, "", -1);
            //    }
            //    int nPos = 1;

            //    DescribeAColumn(T, "ywebpayment", "Anno", nPos++);
            //    DescribeAColumn(T, "nwebpayment", "Numero", nPos++);
            //}

                foreach (DataColumn C in T.Columns) {
                    DescribeAColumn(T, C.ColumnName, "", -1);
                }
                int nPos = 1;

                DescribeAColumn(T, "ywebpayment", "Anno", nPos++);
                DescribeAColumn(T, "nwebpayment", "Numero", nPos++);
                DescribeAColumn(T, "cf", "CF", nPos++);
                DescribeAColumn(T, "email", "e-mail", nPos++);
                DescribeAColumn(T, "forename", "Nome", nPos++);
                DescribeAColumn(T, "idreg", "Cod.Anagrafica", nPos++);
                DescribeAColumn(T, "idwebpaymentstatus", "id Stato", nPos++);
                DescribeAColumn(T, "surname", "Cognome", nPos++);
            }
    }
}
