
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
using System.Data;
using metadatalibrary;
using metaeasylibrary;

namespace meta_upbmonthlycapview
{
    /// <summary>
    /// Summary description for Class1.
    /// </summary>
    public class Meta_upbmonthlycapview : Meta_easydata
    {
        public Meta_upbmonthlycapview(DataAccess Conn, MetaDataDispatcher Dispatcher) : base(Conn, Dispatcher, "upbmonthlycapview")
        {
            Name = "Limite mensile per U.P.B.";
            ListingTypes.Add("default");
        }

        string[] mykey = new string[] { "ayear", "idupb" };
        public override string[] primaryKey() {
            return mykey;
        }

        public override string GetSorting(string ListingType) {
            if (ListingType == "default") {
                return "idupb asc";
            }
            return base.GetSorting(ListingType);
        }

        public override void DescribeColumns(DataTable T, string ListingType){
            base.DescribeColumns(T, ListingType);
            if (ListingType == "default")
            {
                foreach (DataColumn C in T.Columns)
                    DescribeAColumn(T, C.ColumnName, "", -1);
                int nPos = 1;
                DescribeAColumn(T, "ayear", "Esercizio", nPos++);
                DescribeAColumn(T, "codeupb", "Codice UPB", nPos++);
                DescribeAColumn(T, "upb", "UPB", nPos++);
                DescribeAColumn(T, "amount_1", "Gennaio", nPos++);
                DescribeAColumn(T, "amount_2", "Febbraio", nPos++);
                DescribeAColumn(T, "amount_3", "Marzo", nPos++);
                DescribeAColumn(T, "amount_4", "Aprile", nPos++);
                DescribeAColumn(T, "amount_5", "Maggio", nPos++);
                DescribeAColumn(T, "amount_6", "Giugno", nPos++);
                DescribeAColumn(T, "amount_7", "Luglio", nPos++);
                DescribeAColumn(T, "amount_8", "Agosto", nPos++);
                DescribeAColumn(T, "amount_9", "Settembre", nPos++);
                DescribeAColumn(T, "amount_10", "Ottobre", nPos++);
                DescribeAColumn(T, "amount_11", "Novembre", nPos++);
                DescribeAColumn(T, "amount_12", "Dicembre", nPos++);
                DescribeAColumn(T, "amount_reserve", "Riserva", nPos++);
                DescribeAColumn(T, "idupb", "#Id UPB", nPos++);
            }           
        }
    }
}

