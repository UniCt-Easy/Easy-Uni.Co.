
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
using System.Windows.Forms;
using System.Data;
using metaeasylibrary;
using metadatalibrary;

namespace meta_csa_contracttaxview {
    /// <summary>
    /// </summary>
    public class Meta_csa_contracttaxview :Meta_easydata {
        public Meta_csa_contracttaxview(DataAccess Conn, MetaDataDispatcher Dispatcher) :
            base(Conn, Dispatcher, "csa_contracttaxview") {
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
                DescribeAColumn(T, "idcsa_contracttax", "#", nPos++);
                DescribeAColumn(T, "ycontract", "Esercizio Regola specifica CSA", nPos++);
                DescribeAColumn(T, "ncontract", "Numero Regola specifica CSA", nPos++);
                DescribeAColumn(T, "csa_contractkindcode", "Cod. Regola generale CSA", nPos++);
                DescribeAColumn(T, "contractkind", "Regola generale CSA", nPos++);
                DescribeAColumn(T, "ayear", "Esercizio", nPos++);
                DescribeAColumn(T, "vocecsa", "Voce CSA", nPos++);
                DescribeAColumn(T, "codeupb", "Codice UPB", nPos++);
                DescribeAColumn(T, "codefin", "Voce Bilancio Spesa", nPos++);
                DescribeAColumn(T, "sortcode", "Codice SIOPE", nPos++);
                DescribeAColumn(T, "codeacc", "Codice Conto", nPos++);
                DescribeAColumn(T, "nphase", "Fase Movimento", nPos++);
                DescribeAColumn(T, "ymov", "Eserc. Movimento", nPos++);
                DescribeAColumn(T, "nmov", "Num. Movimento", nPos++);
                DescribeAColumn(T, "epexp_nphase", "Fase Movimento budget", nPos++);
                DescribeAColumn(T, "yepexp", "Eserc. Movimento budget", nPos++);
                DescribeAColumn(T, "nepexp", "Num. Movimento budget", nPos++);

            }
        }

    }
}
