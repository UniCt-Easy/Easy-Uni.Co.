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
using System.Data;
using metadatalibrary;
using metaeasylibrary;

namespace meta_underwritingview
{
    /// <summary>
    /// Summary description for Class1.
    /// </summary>
    public class Meta_underwritingview : Meta_easydata{
        public Meta_underwritingview(DataAccess Conn, MetaDataDispatcher Dispatcher):
            base(Conn, Dispatcher, "underwritingview"){
            Name = "Finanziamento";
            ListingTypes.Add("default");
        }
        public override string GetSorting(string ListingType) {
            if (ListingType == "default") return "title asc";
            return base.GetSorting(ListingType);
        }
        string[] mykey = new string[] { "ayear", "idunderwriting" };
        public override string[] primaryKey() {
            return mykey;
        }
        public override string GetStaticFilter(string ListingType)
        {
            string filteresercizio;
            if (ListingType == "default")
            {
                filteresercizio = QHC.CmpEq("ayear", GetSys("esercizio"));
                return filteresercizio;
            }
            return base.GetStaticFilter(ListingType);
        }

        public override void DescribeColumns(DataTable T, string ListingType){
            base.DescribeColumns(T, ListingType);
            if (ListingType == "default"){                
                foreach (DataColumn C in T.Columns)
                    DescribeAColumn(T, C.ColumnName, "", -1);

                int nPos = 1;
                DescribeAColumn(T, "title", "Denominazione", nPos++);
                DescribeAColumn(T, "codeunderwriting", "Codice", nPos++);
                DescribeAColumn(T, "underwriter", "Finanziatore", nPos++);
                DescribeAColumn(T, "doc", "Documento", nPos++);
                DescribeAColumn(T, "docdate", "Data Doc.", nPos++);
                DescribeAColumn(T, "prevision", "Previsione", nPos++);
                DescribeAColumn(T, "active", "attivo", nPos++);
            }
        }
    }
}
