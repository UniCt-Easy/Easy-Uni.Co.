
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
using metaeasylibrary;
using metadatalibrary;

namespace meta_csa_contractkinddataview {
    /// <summary>
    /// Summary description for Meta_csa_contractkindview.
    /// </summary>
    public class Meta_csa_contractkinddataview :Meta_easydata {
        public Meta_csa_contractkinddataview(DataAccess Conn, MetaDataDispatcher Dispatcher)
            :
            base(Conn, Dispatcher, "csa_contractkinddataview") {
            Name = "Contributi Regola generale CSA";
            EditTypes.Add("default");
            ListingTypes.Add("default");
        }
        public override void DescribeColumns(DataTable T, string ListingType) {
            base.DescribeColumns(T, ListingType);

            if (ListingType == "default") {
                foreach (DataColumn C in T.Columns) {
                    DescribeAColumn(T, C.ColumnName, "", -1);
                }
                int nPos = 1;
                DescribeAColumn(T, "ayear", "Eserc.", nPos++);
                DescribeAColumn(T, "csa_contractkindcode", "Cod. Regola generale CSA", nPos++);
                DescribeAColumn(T, "csa_contractkind", "Regola generale CSA", nPos++);
                DescribeAColumn(T, "idcsa_contractkind", "Numero", nPos++);
                DescribeAColumn(T, "vocecsa", "voce CSA", nPos++);
                DescribeAColumn(T, "codeupb", "Cod.UPB", nPos++);
                DescribeAColumn(T, "upb", "UPB", nPos++);
                DescribeAColumn(T, "codeacc", "Cod.Conto E/P", nPos++);
                DescribeAColumn(T, "account", "Conto E/P", nPos++);
                DescribeAColumn(T, "codefin", "Cod.Bilancio", nPos++);
                DescribeAColumn(T, "fin", "Cod.Bilancio", nPos++);
                DescribeAColumn(T, "sortcode_siope", "Cod.SIOPE", nPos++);
                DescribeAColumn(T, "sort_siope", "SIOPE", nPos++);
                DescribeAColumn(T, "flagcr", "Comp./Residui", nPos++);
            }
        }
    }
}

