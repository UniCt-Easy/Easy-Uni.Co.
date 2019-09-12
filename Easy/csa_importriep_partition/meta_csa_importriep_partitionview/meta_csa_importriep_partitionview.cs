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
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;
using metadatalibrary;
using metaeasylibrary;

namespace meta_csa_importriep_partitionview {
    /// <summary>
    /// </summary>
    public class Meta_csa_importriep_partitionview :Meta_easydata {
        public Meta_csa_importriep_partitionview(DataAccess Conn, MetaDataDispatcher Dispatcher) :
            base(Conn, Dispatcher, "csa_importriep_partitionview") {

            ListingTypes.Add("default");
        }

        public override string GetStaticFilter(string listingType) {
            string filteresercizio;
            filteresercizio = QHS.CmpEq("ayear", GetSys("esercizio"));
            if (listingType == "default") {
                return filteresercizio;
            }
            return base.GetStaticFilter(listingType);
        }
        
        public override void DescribeColumns(DataTable T, string ListingType) {
            base.DescribeColumns(T, ListingType);
            if (ListingType == "default") {
                foreach (DataColumn C in T.Columns) {
                    DescribeAColumn(T, C.ColumnName, "", -1);
                }
                int nPos = 1;
                DescribeAColumn(T, "yimport", ".Es.Imp.", nPos++);
                DescribeAColumn(T, "nimport", "N.Imp.", nPos++);
                DescribeAColumn(T, "idriep", "Num. Riep.", nPos++);
                DescribeAColumn(T, "ndetail", "#", nPos++);
                DescribeAColumn(T, "amount", "Importo", nPos++);
                DescribeAColumn(T, "csa_contractkindcode", "Cod. Regola generale CSA", nPos++);
                DescribeAColumn(T, "ycontract", "Eserc. Regola specifica CSA", nPos++);
                DescribeAColumn(T, "ncontract", "Num. Regola specifica CS", nPos++);
                DescribeAColumn(T, "nphaseexpense", "Fase", nPos++);
                DescribeAColumn(T, "ymov", "Eserc. Movimento", nPos++);
                DescribeAColumn(T, "nmov", "Num. Movimento", nPos++);
                DescribeAColumn(T, "nphaseepexp", "Fase", nPos++);
                DescribeAColumn(T, "yepexp", "Eserc. Imp. Budget", nPos++);
                DescribeAColumn(T, "nepexp", "Num. Imp. Budget", nPos++);
                DescribeAColumn(T, "codeupb", "Cod. UPB", nPos++);
                DescribeAColumn(T, "upb", "UPB", nPos++);
                DescribeAColumn(T, "codefin", "Cod. Bilancio Spesa", nPos++);
                DescribeAColumn(T, "fin", "Bilancio Spesa", nPos++);
                DescribeAColumn(T, "codeacc", "Cod. Conto EP", nPos++);
                DescribeAColumn(T, "account", "Conto EP", nPos++);
                DescribeAColumn(T, "sorting_siope", "Class. Siope", nPos++);
    
            }


        }
    }
    }

