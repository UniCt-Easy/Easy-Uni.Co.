
/*
Easy
Copyright (C) 2021 Università degli Studi di Catania (www.unict.it)
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

namespace meta_upbfinyearview
{
    /// <summary>
    /// Summary description for Class1.
    /// </summary>
    public class Meta_upbfinyearview : Meta_easydata
    {
        public Meta_upbfinyearview(DataAccess Conn, MetaDataDispatcher Dispatcher)
            :
            base(Conn, Dispatcher, "upbfinyearview")
        {
            Name = "Finanziamenti";
            ListingTypes.Add("default");
            ListingTypes.Add("crediti");
        }
        string[] mykey = new string[] { "idfin", "idupb" };
        public override string[] primaryKey() {
            return mykey;
        }
        public override void DescribeColumns(DataTable T, string ListingType){
            base.DescribeColumns(T, ListingType);
            if (ListingType == "default")
            {
                foreach (DataColumn C in T.Columns)
                    DescribeAColumn(T, C.ColumnName, "", -1);
                int nPos = 1;
                DescribeAColumn(T, "upb", "UPB", nPos++);
                DescribeAColumn(T, "codeupb", "Codice UPB", nPos++);
                DescribeAColumn(T, "fin", "Bilancio", nPos++);
                DescribeAColumn(T, "codefin", "Codice Bilancio", nPos++);
                DescribeAColumn(T, "initialprevision", "Prev.iniziale", nPos++);
                DescribeAColumn(T, "varprevision", "Variazioni", nPos++);
                DescribeAColumn(T, "actualprevision", "Prev.Corrente", nPos++);
                DescribeAColumn(T, "assessment", "Accertamenti", nPos++);
                DescribeAColumn(T, "incomeprevavailable", "Disp.ad Accertare", nPos++);
            }

            if (ListingType == "crediti")
            {
                foreach (DataColumn C in T.Columns)
                    DescribeAColumn(T, C.ColumnName, "", -1);
                int nPos = 1;
                DescribeAColumn(T, "codeupb", "Codice UPB", nPos++);
                DescribeAColumn(T, "upb", "UPB", nPos++);
                DescribeAColumn(T, "fin", "Bilancio", nPos++);
                DescribeAColumn(T, "codefin", "Codice Bilancio", nPos++);
                DescribeAColumn(T, "actualprevision", "Prev.Corrente in uscita", nPos++);
                DescribeAColumn(T, "appropriation", "Impegni", nPos++);
                DescribeAColumn(T, "expenseprevavailable", "Disp.ad impegnare", nPos++);
                DescribeAColumn(T, "creditavailable", "Crediti disponibili", nPos++);
            }
        }
    }
}

