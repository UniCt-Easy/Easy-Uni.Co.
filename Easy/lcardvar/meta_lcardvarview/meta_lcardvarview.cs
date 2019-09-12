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
using metaeasylibrary;
using metadatalibrary;
using System.Data;

namespace meta_lcardvarview {
    public class Meta_lcardvarview: Meta_easydata {

        public Meta_lcardvarview(DataAccess Conn, MetaDataDispatcher Dispatcher)
            :
           base(Conn, Dispatcher, "lcardvarview") {
            ListingTypes.Add("default");
            ListingTypes.Add("cardcollegata");
        }
        public override bool FilterRow(DataRow R, string list_type)
        {
            if (list_type == "cardcollegata")
            {
                if (R["yvar"] == DBNull.Value) return false;
                return true;
            }

            return true;
        }


        public override void DescribeColumns(DataTable T, string ListingType) {
            base.DescribeColumns(T, ListingType);
            switch (ListingType)
            {
                case "default":
                    {
                        foreach (DataColumn C in T.Columns)
                        {
                            DescribeAColumn(T, C.ColumnName, "", -1);
                        }
                        int npos = 1;
                        DescribeAColumn(T, "ylvar", "Eserc.ricarica", npos++);
                        DescribeAColumn(T, "nlvar", "Num.ricarica", npos++);
                        DescribeAColumn(T, "amount", "Importo", npos++);
                        DescribeAColumn(T, "card", "Card", npos++);
                        DescribeAColumn(T, "codefin", "Codice Bil.", npos++);
                        DescribeAColumn(T, "fin", "Bil.", npos++);
                        DescribeAColumn(T, "codeupb", "Codice Upb", npos++);
                        DescribeAColumn(T, "upb", "Upb", npos++);
                        DescribeAColumn(T, "adate", "Data", npos++);
                        break;

                    }
                case "cardcollegata":
                    {
                        foreach (DataColumn C in T.Columns)
                        {
                            DescribeAColumn(T, C.ColumnName, "", -1);
                        }
                        int npos = 1;
                        DescribeAColumn(T, "ylvar", "Eserc.ricarica", npos++);
                        DescribeAColumn(T, "nlvar", "Num.ricarica", npos++);
                        DescribeAColumn(T, "amount", "Importo", npos++);
                        DescribeAColumn(T, "title", "Card", npos++);
                        DescribeAColumn(T, "codefin", "Codice Bil.", npos++);
                        DescribeAColumn(T, "fin", "Bil.", npos++);
                        DescribeAColumn(T, "codeupb", "Codice Upb", npos++);
                        DescribeAColumn(T, "upb", "Upb", npos++);
                        DescribeAColumn(T, "email", "Email", npos++);
                        DescribeAColumn(T, "adate", "Data", npos++);
                        FilterRows(T);
                        break;

                    }
            }
        }
    }
}
