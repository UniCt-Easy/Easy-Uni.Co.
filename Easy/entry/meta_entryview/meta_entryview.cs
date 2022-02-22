
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
using System.Collections.Generic;
using System.Text;
using metaeasylibrary;
using metadatalibrary;
using System.Data;

namespace meta_entryview {
    public class Meta_entryview : Meta_easydata {
        public Meta_entryview(DataAccess Conn, MetaDataDispatcher Dispatcher)
            :
                base(Conn, Dispatcher, "entryview") {
            Name = "Dettaglio scrittura in partita doppia";
            ListingTypes.Add("default");
        }

        private string[] mykey = new string[] {"yentry", "nentry"};

        public override string[] primaryKey() {
            return mykey;
        }

        public override string GetStaticFilter(string ListingType) {
            if (ListingType == "default") {
                return QHS.CmpEq("yentry", GetSys("esercizio"));
            }
            return base.GetStaticFilter(ListingType);
        }

        public override string GetSorting(string ListingType) {
            if (ListingType == "default") {
                return "nentry desc";
            }
            return base.GetSorting(ListingType);
        }

        public override void DescribeColumns(DataTable T, string ListingType) {
            base.DescribeColumns(T, ListingType);
            if (ListingType == "default") {
                foreach (DataColumn C in T.Columns)
                    DescribeAColumn(T, C.ColumnName, "", -1);
                int nPos = 1;
                DescribeAColumn(T, "nentry", "Num.", nPos++);
                DescribeAColumn(T, "entrykind", "Tipo", nPos++);
                DescribeAColumn(T, "description", "Descrizione", nPos++);
                DescribeAColumn(T, "adate", "Data Cont.", nPos++);
                DescribeAColumn(T, "doc", "Documento", nPos++);
                DescribeAColumn(T, "docdate", "Data Documento", nPos++);
                DescribeAColumn(T, "credit", "Dare", nPos++);
                DescribeAColumn(T, "debit", "Avere", nPos++);
                DescribeAColumn(T, "official", "ufficiale", nPos++);
                DescribeAColumn(T, "locked", "bloccata", nPos++);
                DescribeAColumn(T, "idrelated", "Chiave Ep", nPos++);
            }
        }

    }
}
