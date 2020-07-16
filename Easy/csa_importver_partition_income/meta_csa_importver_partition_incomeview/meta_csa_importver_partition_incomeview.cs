/*
    Easy
    Copyright (C) 2020 Università degli Studi di Catania (www.unict.it)
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

﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;
using metadatalibrary;
using metaeasylibrary;

namespace meta_csa_importver_partition_incomeview{
    /// <summary>
    /// </summary>
    public class Meta_csa_importver_partition_incomeview:Meta_easydata {
        public Meta_csa_importver_partition_incomeview(DataAccess Conn, MetaDataDispatcher Dispatcher) :
            base(Conn, Dispatcher, "csa_importver_partition_incomeview") {

            ListingTypes.Add("elenco");
            ListingTypes.Add("ritenuta");
            ListingTypes.Add("contributo");
            ListingTypes.Add("recupero");
        }

        public override string GetStaticFilter(string ListingType) {
            string filteresercizio;
            string filtertipo = "";
            filteresercizio = QHS.CmpEq("yimport", GetSys("esercizio"));
            if (ListingType == "elenco") {
                return filteresercizio;
            }
            switch (ListingType) {
                case "ritenuta":
                    filtertipo = QHS.CmpEq("kind", "Ritenuta");
                    break;
                case "contributo":
                    filtertipo = QHS.CmpEq("kind", "Contributo");
                    break;
                case "recupero":
                    filtertipo = QHS.CmpEq("kind", "Recupero");
                    break;
            }

            if ((ListingType == "ritenuta") || (ListingType == "contributo") || (ListingType == "recupero")) {
                return QHS.AppAnd(filteresercizio, filtertipo);
            }

            return base.GetStaticFilter(ListingType);
        }

        public override void DescribeColumns(DataTable T, string ListingType) {
            base.DescribeColumns(T, ListingType);
            foreach (DataColumn C in T.Columns) {
                DescribeAColumn(T, C.ColumnName, "", -1);
            }
            int nPos = 1;
            if (ListingType == "elenco") {
                DescribeAColumn(T, "kind", "Tipo", nPos++);
                DescribeAColumn(T, "yimport", "Eserc. import.", nPos++);
                DescribeAColumn(T, "nimport", "Num. import.", nPos++);
                DescribeAColumn(T, "idver", "Versamento", nPos++);
                DescribeAColumn(T, "importo", "Importo Versamento", nPos++);
                DescribeAColumn(T, "vocecsa", "Voce CSA", nPos++);
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
                DescribeAColumn(T, "registry_agency", "Anagr. Ente versamento", nPos++);
                DescribeAColumn(T, "matricola", "Matricola", nPos++);
                FilterRows(T);

            }
            if ((ListingType == "contributo") || (ListingType == "ritenuta") || (ListingType == "recupero")) {
                DescribeAColumn(T, "kind", "Tipo", nPos++);
                DescribeAColumn(T, "yimport", "Eserc. import.", nPos++);
                DescribeAColumn(T, "nimport", "Num. import.", nPos++);
                DescribeAColumn(T, "idver", "Versamento", nPos++);
                DescribeAColumn(T, "importo", "Importo Versamento", nPos++);
                DescribeAColumn(T, "vocecsa", "Voce CSA", nPos++);
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
                DescribeAColumn(T, "registry_agency", "Anagr. Ente versamento", nPos++);
                DescribeAColumn(T, "matricola", "Matricola", nPos++);
                FilterRows(T);
            }

        }
    }
    }

