
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
using System.Data;
using System.Windows.Forms;
using metadatalibrary;
using metaeasylibrary;

namespace meta_csa_importriep_partition_expenseview {
    /// <summary>
    /// </summary>
    public class Meta_csa_importriep_partition_expenseview :Meta_easydata {
        public Meta_csa_importriep_partition_expenseview(DataAccess Conn, MetaDataDispatcher Dispatcher) :
            base(Conn, Dispatcher, "csa_importriep_partition_expenseview") {

            ListingTypes.Add("elenco");
        }


        public override string GetStaticFilter(string ListingType) {
            string filteresercizio;
            if (ListingType == "elenco") {
                filteresercizio = "(yimport='" + GetSys("esercizio").ToString() + "')";
                return filteresercizio;
            }
            return base.GetStaticFilter(ListingType);
        }
        public override void DescribeColumns(DataTable T, string ListingType) {
            base.DescribeColumns(T, ListingType);
            if (ListingType == "elenco") {
                foreach (DataColumn C in T.Columns) {
                    DescribeAColumn(T, C.ColumnName, "", -1);
                }
                int nPos = 1;
                DescribeAColumn(T, "yimport", "Eserc. import.", nPos++);
                DescribeAColumn(T, "nimport", "Num. import.", nPos++);
                DescribeAColumn(T, "idriep", "Riepilogo", nPos++);
                DescribeAColumn(T, "importo", "Importo Riepilogo", nPos++);
                DescribeAColumn(T, "ndetail", "Num. Riga", nPos++);
                DescribeAColumn(T, "amount", "Importo", nPos++);
                DescribeAColumn(T, "csa_contractkindcode", "Cod. Regola generale CSA", nPos++);
                DescribeAColumn(T, "ycontract", "Eserc. Regola specifica CSA", nPos++);
                DescribeAColumn(T, "ncontract", "Num. Regola specifica CSA", nPos++);
                DescribeAColumn(T, "phase", "Fase", nPos++);
                DescribeAColumn(T, "ymov", "Eserc. Movimento", nPos++);
                DescribeAColumn(T, "nmov", "Num. Movimento", nPos++);
                DescribeAColumn(T, "descrmov", "Descrizione", nPos++);
                DescribeAColumn(T, "movkind", ".Tipo mov CSA", nPos++);
                DescribeAColumn(T, "descrmovkind", "Tipo mov CSA", nPos++);
                DescribeAColumn(T, "registry_main", "Anagr. Movimento", nPos++);
                DescribeAColumn(T, "registry", "Anagr. Regola Sp.", nPos++);
                DescribeAColumn(T, "matricola", "Matricola", nPos++);
                DescribeAColumn(T, "ruolocsa", "Ruolo CSA", nPos++);
            }


        }
    }
    }

