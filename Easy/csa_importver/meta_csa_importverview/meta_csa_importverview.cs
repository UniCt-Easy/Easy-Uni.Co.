
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
using System.Data;
using metaeasylibrary;
using metadatalibrary;

namespace meta_csa_importverview
{
	/// <summary>
    /// Summary description for Meta_csa_contractview.
	/// </summary>
	public class Meta_csa_importverview : Meta_easydata
	{
        public Meta_csa_importverview (DataAccess Conn, MetaDataDispatcher Dispatcher):
            base(Conn, Dispatcher, "csa_importverview") {
            ListingTypes.Add("default");
            ListingTypes.Add("versamentiannuali");
            ListingTypes.Add("ritenuta");
            ListingTypes.Add("contributo");
            ListingTypes.Add("recupero");
            ListingTypes.Add("vocecsa");
        }
        string[] mykey = new string[] { "ayear", "idcsa_import", "idver" };
        public override string[] primaryKey() {
            return mykey;
        }
        public override string GetStaticFilter (string ListingType) {
            string filteresercizio;
            string filtertipo = "";
            filteresercizio = QHS.CmpEq("yimport", GetSys("esercizio"));  
            if (ListingType == "default"|| ListingType == "versamentiannuali"||ListingType == "pagamentiposticipati") {
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
                    filtertipo = QHS.CmpEq("kind","Recupero");
                    break;
                case "vocecsa":
                    filtertipo = QHS.CmpEq("kind", "Voce CSA");
                    break;
            }

            if ((ListingType == "ritenuta")||(ListingType == "contributo")|| (ListingType == "recupero") || (ListingType == "vocecsa")) {
                return QHS.AppAnd(filteresercizio, filtertipo);
            }
            
            return base.GetStaticFilter(ListingType);
        }

     
        public override void DescribeColumns (DataTable T, string ListingType) {
            base.DescribeColumns(T, ListingType);

            if (ListingType == "default") {
                foreach (DataColumn C in T.Columns) {
                    DescribeAColumn(T, C.ColumnName, "", -1);
                }
                int nPos = 1;
                DescribeAColumn(T, "ayear", ".Es. Vers.", nPos++);
                DescribeAColumn(T, "kind", "Tipo", nPos++);
                DescribeAColumn(T, "nimport", "Num. Imp.", nPos++);
                DescribeAColumn(T, "idver", "Num. Vers.", nPos++);
                DescribeAColumn(T, "competenza", "Competenza", nPos++);
                DescribeAColumn(T, "importo", "Importo", nPos++);
                DescribeAColumn(T, "vocecsa", "Voce CSA", nPos++);
                DescribeAColumn(T, "ruolocsa", "Ruolo CSA", nPos++);
                DescribeAColumn(T, "capitolocsa", "Capitolo CSA", nPos++);
                DescribeAColumn(T, "ente", "Ente CSA", nPos++);
                DescribeAColumn(T, "agency", "Ente Versamento", nPos++);
                DescribeAColumn(T, "registry_agency", "Anagrafica Versamento", nPos++);
                DescribeAColumn(T, "nobill", "Non richiede sospeso in versamenti", nPos++);
                DescribeAColumn(T, "annualpayment", "Versamenti annuali", nPos++);

                DescribeAColumn(T, "csa_contractkindcode", "Tipo contr.", nPos++);
                DescribeAColumn(T, "ycontract", "Esercizio Contr.", nPos++);
                DescribeAColumn(T, "ncontract", "Numero Contr.", nPos++);
                DescribeAColumn(T, "codeupb", "UPB Costo", nPos++);
                DescribeAColumn(T, "codefin_expense", "Cod.Voce Spesa Ritenuta", nPos++);
                DescribeAColumn(T, "fin_expense", "Voce Spesa Ritenuta", nPos++);
                DescribeAColumn(T, "codefin_income", "Cod.Voce Entrata Ritenuta", nPos++);
                DescribeAColumn(T, "fin_income", "Voce Entrata Ritenuta ", nPos++);
                DescribeAColumn(T, "codefin_incomeclawback", "Cod.Voce Entrata Recupero positivo", nPos++);
                DescribeAColumn(T, "fin_incomeclawback", "Voce Entrata Recupero positivo ", nPos++);
                DescribeAColumn(T, "codeacc_revenue", "Cod.Conto Ricavo Recupero positivo", nPos++);
                DescribeAColumn(T, "account_revenue", "Conto Ricavo Recupero positivo", nPos++);
                DescribeAColumn(T, "codefin_cost", "Cod.Voce Spesa Recupero negativo", nPos++);
                DescribeAColumn(T, "fin_cost", "Voce Spesa Recupero negativo", nPos++);
                DescribeAColumn(T, "account_cost", "Conto Costo Recupero negativo", nPos++);
                DescribeAColumn(T, "codeacc_cost", "Cod.Conto Costo Recupero negativo", nPos++);
                DescribeAColumn(T, "codeacc_expense", "Cod.Conto Debito verso Ente", nPos++);
                DescribeAColumn(T, "account_expense", "Conto Debito verso Ente", nPos++);
                DescribeAColumn(T, "codeacc_agency_credit", "Cod.Conto Credito verso Ente", nPos++);
                DescribeAColumn(T, "account_agency_credit", "Conto Credito verso Ente", nPos++);
                //DescribeAColumn(T, "yimport", ".Eserc. Imp.", nPos++);

                //DescribeAColumn(T, "registry", "Anagrafica", nPos++);

                //DescribeAColumn(T, "underwriting", "Finanziamento", nPos++);
                //DescribeAColumn(T, "phase_cost", "Fase Mov. costo", nPos++);
                //DescribeAColumn(T, "ymov_cost", "Esercizio  Mov. costo", nPos++);
                //DescribeAColumn(T, "nmov_cost", "Numero  Mov. costo", nPos++);
                //DescribeAColumn(T, "codefin_cost", "Bilancio Costo", nPos++);

            }
            if (ListingType == "contributo") {
                foreach (DataColumn C in T.Columns) {
                    DescribeAColumn(T, C.ColumnName, "", -1);
                }
                int nPos = 1;
                DescribeAColumn(T, "ayear", ".Es. Vers.", nPos++);
                DescribeAColumn(T, "kind", "Tipo", nPos++);
                DescribeAColumn(T, "idver", "Num. Vers.", nPos++);
                DescribeAColumn(T, "competenza", "Competenza", nPos++);
                DescribeAColumn(T, "importo", "Importo", nPos++);
                DescribeAColumn(T, "vocecsa", "Voce CSA", nPos++);
                DescribeAColumn(T, "ruolocsa", "Ruolo CSA", nPos++);
                DescribeAColumn(T, "capitolocsa", "Capitolo CSA", nPos++);
                DescribeAColumn(T, "ente", "Ente CSA", nPos++);
                DescribeAColumn(T, "yimport", ".Eserc. Imp.", nPos++);
                DescribeAColumn(T, "nimport", "Num. Imp.", nPos++);
                DescribeAColumn(T, "registry", "Anagrafica", nPos++);
                DescribeAColumn(T, "csa_contractkindcode", "Tipo contr.", nPos++);
                DescribeAColumn(T, "ycontract", "Esercizio Contr.", nPos++);
                DescribeAColumn(T, "ncontract", "Numero Contr.", nPos++);
                DescribeAColumn(T, "underwriting", "Finanziamento", nPos++);
                DescribeAColumn(T, "phase_cost", "Fase Mov. costo", nPos++);
                DescribeAColumn(T, "ymov_cost", "Esercizio  Mov. costo", nPos++);
                DescribeAColumn(T, "nmov_cost", "Numero  Mov. costo", nPos++);
                DescribeAColumn(T, "codefin_cost", "Bilancio Costo", nPos++);
                DescribeAColumn(T, "codeupb", "UPB Costo", nPos++);
                DescribeAColumn(T, "agency", "Ente Versamento", nPos++);
                DescribeAColumn(T, "registry_agency", "Anagrafica Versamento", nPos++);
                FilterRows(T);
            }
            if (ListingType == "ritenuta") {
                foreach (DataColumn C in T.Columns) {
                    DescribeAColumn(T, C.ColumnName, "", -1);
                }
                int nPos = 1;
                DescribeAColumn(T, "ayear", ".Es. Vers.", nPos++);
                DescribeAColumn(T, "kind", "Tipo", nPos++);
                DescribeAColumn(T, "idver", "Num. Vers.", nPos++);
                DescribeAColumn(T, "competenza", "Competenza", nPos++);
                DescribeAColumn(T, "importo", "Importo", nPos++);
                DescribeAColumn(T, "vocecsa", "Voce CSA", nPos++);
                DescribeAColumn(T, "ruolocsa", "Ruolo CSA", nPos++);
                DescribeAColumn(T, "capitolocsa", "Capitolo CSA", nPos++);
                DescribeAColumn(T, "ente", "Ente CSA", nPos++);
                DescribeAColumn(T, "yimport", ".Eserc. Imp.", nPos++);
                DescribeAColumn(T, "nimport", "Num. Imp.", nPos++);
                DescribeAColumn(T, "registry", "Anagrafica", nPos++);
                DescribeAColumn(T, "csa_contractkindcode", "Tipo contr.", nPos++);
                DescribeAColumn(T, "ycontract", "Esercizio Contr.", nPos++);
                DescribeAColumn(T, "ncontract", "Numero Contr.", nPos++);
                DescribeAColumn(T, "underwriting", "Finanziamento", nPos++);
                DescribeAColumn(T, "phase_cost", "Fase Mov. costo", nPos++);
                DescribeAColumn(T, "ymov_cost", "Esercizio  Mov. costo", nPos++);
                DescribeAColumn(T, "nmov_cost", "Numero  Mov. costo", nPos++);
                DescribeAColumn(T, "codefin_cost", "Bilancio Costo", nPos++);
                DescribeAColumn(T, "codeupb", "UPB Costo", nPos++);
                DescribeAColumn(T, "agency", "Ente Versamento", nPos++);
                DescribeAColumn(T, "registry_agency", "Anagrafica Versamento", nPos++);
                FilterRows(T);
            }
            if (ListingType == "recupero") {
                foreach (DataColumn C in T.Columns) {
                    DescribeAColumn(T, C.ColumnName, "", -1);
                }
                int nPos = 1;
                DescribeAColumn(T, "ayear", ".Es. Vers.", nPos++);
                DescribeAColumn(T, "kind", "Tipo", nPos++);
                DescribeAColumn(T, "idver", "Num. Vers.", nPos++);
                DescribeAColumn(T, "competenza", "Competenza", nPos++);
                DescribeAColumn(T, "importo", "Importo", nPos++);
                DescribeAColumn(T, "vocecsa", "Voce CSA", nPos++);
                DescribeAColumn(T, "ruolocsa", "Ruolo CSA", nPos++);
                DescribeAColumn(T, "capitolocsa", "Capitolo CSA", nPos++);
                DescribeAColumn(T, "ente", "Ente CSA", nPos++);
                DescribeAColumn(T, "yimport", ".Eserc. Imp.", nPos++);
                DescribeAColumn(T, "nimport", "Num. Imp.", nPos++);
                DescribeAColumn(T, "registry", "Anagrafica", nPos++);
                DescribeAColumn(T, "csa_contractkindcode", "Tipo contr.", nPos++);
                DescribeAColumn(T, "ycontract", "Esercizio Contr.", nPos++);
                DescribeAColumn(T, "ncontract", "Numero Contr.", nPos++);
                DescribeAColumn(T, "underwriting", "Finanziamento", nPos++);
                DescribeAColumn(T, "phase_cost", "Fase Mov. costo", nPos++);
                DescribeAColumn(T, "ymov_cost", "Esercizio  Mov. costo", nPos++);
                DescribeAColumn(T, "nmov_cost", "Numero  Mov. costo", nPos++);
                DescribeAColumn(T, "codefin_cost", "Bilancio Costo", nPos++);
                DescribeAColumn(T, "codeupb", "UPB Costo", nPos++);
                DescribeAColumn(T, "agency", "Ente Versamento", nPos++);
                DescribeAColumn(T, "registry_agency", "Anagrafica Versamento", nPos++);
                FilterRows(T);
            }
            if (ListingType == "vocecsa") {
                foreach (DataColumn C in T.Columns) {
                    DescribeAColumn(T, C.ColumnName, "", -1);
                }
                int nPos = 1;
                DescribeAColumn(T, "ayear", ".Es. Vers.", nPos++);
                DescribeAColumn(T, "kind", "Tipo", nPos++);
                DescribeAColumn(T, "idver", "Num. Vers.", nPos++);
                DescribeAColumn(T, "competenza", "Competenza", nPos++);
                DescribeAColumn(T, "importo", "Importo", nPos++);
                DescribeAColumn(T, "vocecsa", "Voce CSA", nPos++);
                DescribeAColumn(T, "ruolocsa", "Ruolo CSA", nPos++);
                DescribeAColumn(T, "capitolocsa", "Capitolo CSA", nPos++);
                DescribeAColumn(T, "ente", "Ente CSA", nPos++);
                DescribeAColumn(T, "yimport", ".Eserc. Imp.", nPos++);
                DescribeAColumn(T, "nimport", "Num. Imp.", nPos++);
                DescribeAColumn(T, "registry", "Anagrafica", nPos++);
                DescribeAColumn(T, "csa_contractkindcode", "Tipo contr.", nPos++);
                DescribeAColumn(T, "ycontract", "Esercizio Contr.", nPos++);
                DescribeAColumn(T, "ncontract", "Numero Contr.", nPos++);
                DescribeAColumn(T, "underwriting", "Finanziamento", nPos++);
                DescribeAColumn(T, "phase_cost", "Fase Mov. costo", nPos++);
                DescribeAColumn(T, "ymov_cost", "Esercizio  Mov. costo", nPos++);
                DescribeAColumn(T, "nmov_cost", "Numero  Mov. costo", nPos++);
                DescribeAColumn(T, "codefin_cost", "Bilancio Costo", nPos++);
                DescribeAColumn(T, "codeupb", "UPB Costo", nPos++);
                DescribeAColumn(T, "agency", "Ente Versamento", nPos++);
                DescribeAColumn(T, "registry_agency", "Anagrafica Versamento", nPos++);
                FilterRows(T);
            }
            if (ListingType == "versamentiannuali") {
                foreach (DataColumn C in T.Columns) {
                    DescribeAColumn(T, C.ColumnName, "", -1);
                }
                int nPos = 1;

                DescribeAColumn(T, "yimport", ".Eserc. Import.", nPos++);
                DescribeAColumn(T, "nimport", "Num. Import.", nPos++);
                DescribeAColumn(T, "ayear", ".Es. Vers.", nPos++);
                DescribeAColumn(T, "kind", "Tipo", nPos++);
                DescribeAColumn(T, "idver", "Num. Vers.", nPos++);
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
			if (ListingType == "pagamentiposticipati") {
				foreach (DataColumn C in T.Columns) {
					DescribeAColumn(T, C.ColumnName, "", -1);
				}
				int nPos = 1;
				DescribeAColumn(T, "kind", "Tipo", nPos++);
				DescribeAColumn(T, "ymov", ".Eserc. Mov.", nPos++);
				DescribeAColumn(T, "nmov", ".Eserc. Nmov.", nPos++);
				DescribeAColumn(T, "nphase", "Fase", nPos++);
				DescribeAColumn(T, "yimport", ".Eserc. Import.", nPos++);
				DescribeAColumn(T, "nimport", "Num. Import.", nPos++);
				DescribeAColumn(T, "ayear", ".Es. Vers.", nPos++);
				DescribeAColumn(T, "kind", "Tipo", nPos++);
				DescribeAColumn(T, "idver", "Num. Vers.", nPos++);
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
		}
	}
}
