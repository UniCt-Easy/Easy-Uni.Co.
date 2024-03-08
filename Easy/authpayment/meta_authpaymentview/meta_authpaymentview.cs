
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


using System;
using System.Collections.Generic;
using System.Text;
using metaeasylibrary;
using metadatalibrary;
using System.Data;

namespace meta_authpaymentview {
    public class Meta_authpaymentview : Meta_easydata {
        public Meta_authpaymentview(DataAccess Conn, MetaDataDispatcher Dispatcher)
            :
            base(Conn, Dispatcher, "authpaymentview") {
            ListingTypes.Add("default");
        }

        private string[] mykey = new string[] { "yauthpayment", "nauthpayment" };
        public override string[] primaryKey() {
            return mykey;
        }
        public override void DescribeColumns(DataTable T, string listtype) {
            base.DescribeColumns(T, listtype);
            if (listtype == "default") {
                foreach (DataColumn C in T.Columns) {
                    DescribeAColumn(T, C.ColumnName, "", -1);
                }
                int nPos = 1;
                DescribeAColumn(T, "yauthpayment", "Esercizio", nPos++);
                DescribeAColumn(T, "nauthpayment", "Num.", nPos++);
                DescribeAColumn(T, "description", "Descrizione", nPos++);
                DescribeAColumn(T, "registry", "Percipiente", nPos++);
                DescribeAColumn(T, "sent_date", "Data Invio Richiesta", nPos++);
                DescribeAColumn(T, "authorize_date", "Data Tacita Autorizzazione", nPos++);
                DescribeAColumn(T, "attach_amount", "Importo da pignorare", nPos++);
                DescribeAColumn(T, "payable_amount", "Importo Pagabile", nPos++);
                DescribeAColumn(T, "payed_amount", "Importo Pagato", nPos++);
                DescribeAColumn(T, "active", "Da regolarizzare", nPos++);
            }
        }

    }
}
