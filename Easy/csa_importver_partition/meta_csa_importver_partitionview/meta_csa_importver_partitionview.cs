
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
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;
using metadatalibrary;
using metaeasylibrary;

namespace meta_csa_importver_partitionview {
    /// <summary>
    /// </summary>
    public class Meta_csa_importver_partitionview :Meta_easydata {
        public Meta_csa_importver_partitionview(DataAccess Conn, MetaDataDispatcher Dispatcher) :
            base(Conn, Dispatcher, "csa_importverview_partition") {

            ListingTypes.Add("elenco");
            ListingTypes.Add("versamentiannuali");
			ListingTypes.Add("pagamentiposticipati");
			ListingTypes.Add("ritenuta");
            ListingTypes.Add("contributo");
            ListingTypes.Add("recupero");
        }

        public override string GetStaticFilter(string ListingType) {
            string filteresercizio;
            string filtertipo = "";
            filteresercizio = QHS.CmpEq("ayear", GetSys("esercizio"));
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
                DescribeAColumn(T, "yimport", "Eserc. Import.", nPos++);
                DescribeAColumn(T, "nimport", "Numero Import.", nPos++);
                DescribeAColumn(T, "idver", "Num. Vers.", nPos++);
                DescribeAColumn(T, "ndetail", "#", nPos++);
                DescribeAColumn(T, "amount", "Importo", nPos++);
                DescribeAColumn(T, "vocecsa", "Voce CSA", nPos++);
                DescribeAColumn(T, "ente", "Ente CSA", nPos++);
                DescribeAColumn(T, "csa_contractkindcode", "Cod. Regola generale CSA", nPos++);
                DescribeAColumn(T, "ycontract", "Eserc. Regola specifica CSA", nPos++);
                DescribeAColumn(T, "ncontract", "Num. Regola specifica CSA", nPos++);
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
                DescribeAColumn(T, "codeacc_cost", "Cod. Conto EP costo", nPos++);
                DescribeAColumn(T, "account_cost", "Conto EP costo", nPos++);
                DescribeAColumn(T, "descflagaccountusage", "Tipo utilizzo conto", nPos++);
                DescribeAColumn(T, "sorting_siope", "Class. Siope", nPos++);
                DescribeAColumn(T, "matricola", "Matricola", nPos++);
                DescribeAColumn(T, "sortcode_income", "Codice Siope Entrate", nPos++);
                DescribeAColumn(T, "sorting_income", "Siope Entrate", nPos++);
                DescribeAColumn(T, "sortcode_incomeclawback", "Codice Siope Recupero", nPos++);
                DescribeAColumn(T, "sorting_incomeclawback", "Siope Recupero", nPos++);
                DescribeAColumn(T, "codeacc_revenue", "Codice Conto EP ricavo", nPos++);
                DescribeAColumn(T, "account_revenue", "Conto EP ricavo", nPos++);
                DescribeAColumn(T, "codeacc_expense", "Codice Conto EP debito", nPos++);
                DescribeAColumn(T, "account_expense", "Conto EP debito", nPos++);
                DescribeAColumn(T, "codeacc_agency_credit", "Codice Conto EP credito", nPos++);
                DescribeAColumn(T, "account_agency_credit", "Conto EP credito", nPos++);
                DescribeAColumn(T, "registry", "Anagrafica Ente", nPos++);
                DescribeAColumn(T, "nobill", "Non richiede sospeso in versamenti", nPos++);
                DescribeAColumn(T, "annualpayment", "Versamenti annuali", nPos++);
                DescribeAColumn(T, "agency", "Ente Versamento", nPos++);
                DescribeAColumn(T, "registry_agency", "Anagrafica Versamento", nPos++);

            }
            if (ListingType == "versamentiannuali") {
                DescribeAColumn(T, "idcsa_import", ".#import", nPos++);
                DescribeAColumn(T, "yimport", ".Eserc. Import.", nPos++);
                DescribeAColumn(T, "nimport", "Num. Import.", nPos++);
                DescribeAColumn(T, "ayear", ".Es. Vers.", nPos++);
                DescribeAColumn(T, "idver", "Num. Vers.", nPos++);
                DescribeAColumn(T, "ndetail", "Riga", nPos++);
                DescribeAColumn(T, "competenza", "Competenza", nPos++);
                DescribeAColumn(T, "amount", "Importo", nPos++);
                DescribeAColumn(T, "vocecsa", "Voce CSA", nPos++);
                DescribeAColumn(T, "ruolocsa", "Ruolo CSA", nPos++);
                DescribeAColumn(T, "capitolocsa", "Capitolo CSA", nPos++);
                DescribeAColumn(T, "ente", "Ente CSA", nPos++);
                DescribeAColumn(T, "csa_contractkindcode", "Tipo contr.", nPos++);
                DescribeAColumn(T, "ycontract", "Esercizio Contr.", nPos++);
                DescribeAColumn(T, "ncontract", "Numero Contr.", nPos++);
                DescribeAColumn(T, "registry", "Anagrafica", nPos++);
                DescribeAColumn(T, "agency", "Ente Versamento", nPos++);
                DescribeAColumn(T, "registry_agency", "Anagrafica Ente Versamento", nPos++);
                //DescribeAColumn(T, "sorting_siope", "Class. Siope", nPos++);
            }

			if (ListingType == "pagamentiposticipati") {
				foreach (DataColumn C in T.Columns) {
					DescribeAColumn(T, C.ColumnName, "", -1);
				}
				DescribeAColumn(T, "idcsa_import", "#import", nPos++);
				DescribeAColumn(T, "idver", "Num. Vers.", nPos++);
				DescribeAColumn(T, "ndetail", "Riga", nPos++);
				DescribeAColumn(T, "kind", "Tipo", nPos++);
				DescribeAColumn(T, "ymov", ".Eserc. Mov.", nPos++);
				DescribeAColumn(T, "nmov", ".Eserc. Nmov.", nPos++);
				DescribeAColumn(T, "nphase", "Fase", nPos++);
				DescribeAColumn(T, "yimport", ".Eserc. Import.", nPos++);
				DescribeAColumn(T, "nimport", "Num. Import.", nPos++);
				DescribeAColumn(T, "ayear", ".Es. Vers.", nPos++);
				DescribeAColumn(T, "kind", "Tipo", nPos++);
				DescribeAColumn(T, "competenza", "Competenza", nPos++);
				DescribeAColumn(T, "importo", "Importo", nPos++);
				DescribeAColumn(T, "vocecsa", "Voce CSA", nPos++);
				DescribeAColumn(T, "ruolocsa", "Ruolo CSA", nPos++);
				DescribeAColumn(T, "capitolocsa", "Capitolo CSA", nPos++);
				DescribeAColumn(T, "ente", "Ente CSA", nPos++);
				DescribeAColumn(T, "csa_contractkindcode", "Tipo contr.", nPos++);
				DescribeAColumn(T, "ycontract", "Esercizio Contr.", nPos++);
				DescribeAColumn(T, "ncontract", "Numero Contr.", nPos++);
				DescribeAColumn(T, "registry", "Anagrafica", nPos++);
				DescribeAColumn(T, "agency", "Ente Versamento", nPos++);
				DescribeAColumn(T, "registry_agency", "Anagrafica Ente Versamento", nPos++);
			}
			if ((ListingType == "contributo")|| (ListingType == "ritenuta") || (ListingType == "recupero"))  {
                DescribeAColumn(T, "kind", "Tipo", nPos++);
                DescribeAColumn(T, "idver", "Num. Vers.", nPos++);
                DescribeAColumn(T, "idcsa_import", ".#import", nPos++);
                DescribeAColumn(T, "yimport", ".Eserc. Import.", nPos++);
                DescribeAColumn(T, "nimport", "Num. Import.", nPos++);
                DescribeAColumn(T, "ayear", ".Es. Vers.", nPos++);
                DescribeAColumn(T, "idver", "Num. Vers.", nPos++);
                DescribeAColumn(T, "ndetail", "Riga", nPos++);
                DescribeAColumn(T, "competenza", "Competenza", nPos++);
                DescribeAColumn(T, "amount", "Importo", nPos++);
                DescribeAColumn(T, "vocecsa", "Voce CSA", nPos++);
                DescribeAColumn(T, "ruolocsa", "Ruolo CSA", nPos++);
                DescribeAColumn(T, "capitolocsa", "Capitolo CSA", nPos++);
                DescribeAColumn(T, "ente", "Ente CSA", nPos++);
                DescribeAColumn(T, "csa_contractkindcode", "Tipo contr.", nPos++);
                DescribeAColumn(T, "ycontract", "Esercizio Contr.", nPos++);
                DescribeAColumn(T, "ncontract", "Numero Contr.", nPos++);
                DescribeAColumn(T, "registry", "Anagrafica", nPos++);
                DescribeAColumn(T, "agency", "Ente Versamento", nPos++);
                DescribeAColumn(T, "registry_agency", "Anagrafica Ente Versamento", nPos++);
                DescribeAColumn(T, "sorting_siope", "Class. Siope", nPos++);
                FilterRows(T);
            }

        } }

    }

