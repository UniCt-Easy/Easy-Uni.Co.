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
using System.Windows.Forms; 
using System.Data;
using metaeasylibrary;
using metadatalibrary;
               
namespace meta_csa_contracttaxexpenseview {
    /// <summary>
    /// Summary description for Class1.
    /// </summary>
    public class Meta_csa_contracttaxexpenseview :Meta_easydata {
        public Meta_csa_contracttaxexpenseview(DataAccess Conn, MetaDataDispatcher Dispatcher) :
            base(Conn, Dispatcher, "csa_contracttaxexpenseview") {
            ListingTypes.Add("elenco");
        }


        public override void DescribeColumns(DataTable T, string ListingType) {
            base.DescribeColumns(T, ListingType);
            if (ListingType == "elenco") {
                foreach (DataColumn C in T.Columns) {
                    DescribeAColumn(T, C.ColumnName, "", -1);
                }
                int nPos = 1;
                DescribeAColumn(T, "ayear", "Esercizio Ripartizione", nPos++);
                DescribeAColumn(T, "vocecsa", "Voce CSA", nPos++);
                DescribeAColumn(T, "csa_contractkindcode", "Cod. Regola generale CSA", nPos++);
                DescribeAColumn(T, "ycontract", "Eserc. Regola specifica CSA", nPos++);
                DescribeAColumn(T, "ncontract", "Num. Regola specifica CSA", nPos++);
                DescribeAColumn(T, "active", "Attivo", nPos++);
                DescribeAColumn(T, "quota", "Quota", nPos++);
                DescribeAColumn(T, "phase", "Fase", nPos++);
                DescribeAColumn(T, "ymov", "Eserc. Movimento", nPos++);
                DescribeAColumn(T, "nmov", "Num. Movimento", nPos++);
                HelpForm.SetFormatForColumn(T.Columns["quota"], "p4");
            }
        }

    }
}

