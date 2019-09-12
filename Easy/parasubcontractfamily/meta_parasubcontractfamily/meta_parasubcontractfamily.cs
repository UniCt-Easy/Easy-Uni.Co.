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
using System.Data;
using System.Windows.Forms;
using metaeasylibrary;
using metadatalibrary;
using funzioni_configurazione;

namespace meta_parasubcontractfamily //meta_familiare//
{
    /// <summary>
    /// Summary description for Meta_familiare.
    /// </summary>
    public class Meta_parasubcontractfamily : Meta_easydata {
        public Meta_parasubcontractfamily(DataAccess Conn, MetaDataDispatcher Dispatcher) :
            base(Conn, Dispatcher, "parasubcontractfamily") {
            //EditTypes.Add("default");
            EditTypes.Add("contrattodetail");
            ListingTypes.Add("contrattodetail");
        }

        public override void SetDefaults(DataTable PrimaryTable) {
            base.SetDefaults(PrimaryTable);
            SetDefault(PrimaryTable, "ayear", GetSys("esercizio"));
            SetDefault(PrimaryTable, "flagdependent", "S");
        }

        protected override Form GetForm(string FormName) {
            /*
			if (FormName=="default") 
			{
				DefaultListType="default";
				Name = "Familiare";
				return GetFormByDllName("familiare");
			}
			*/
            if (FormName == "contrattodetail") {
                DefaultListType = "contrattodetail";
                Name = "Familiare - Dettaglio";
                return GetFormByDllName("parasubcontractfamily_contrattodetail");
            }
            return null;
        }

        public override DataRow Get_New_Row(DataRow ParentRow, DataTable T) {
            RowChange.SetSelector(T, "idcon");
            RowChange.SetSelector(T, "ayear");
            RowChange.MarkAsAutoincrement(T.Columns["idfamily"], null,
                null, 7);
            DataRow R = base.Get_New_Row(ParentRow, T);
            return R;
        }

        public override void DescribeColumns(DataTable T, string ListingType) {
            base.DescribeColumns(T, ListingType);
            if (ListingType == "contrattodetail") {
                foreach (DataColumn C in T.Columns) DescribeAColumn(T, C.ColumnName, "");
                DescribeAColumn(T, "idcon", "");
                DescribeAColumn(T, "idfamily", "");
                DescribeAColumn(T, "surname", "Cognome");
                DescribeAColumn(T, "forename", "Nome");
                DescribeAColumn(T, "idaffinity", "");
                DescribeAColumn(T, "!descrparentela", "Descr. Parentela", "affinity.description");
                DescribeAColumn(T, "idcitybirth", "");
                DescribeAColumn(T, "idnation", "");
                DescribeAColumn(T, "birthdate", "Data di Nascita");
                DescribeAColumn(T, "gender", "Sesso");
                DescribeAColumn(T, "flagforeign", "Straniero");
                DescribeAColumn(T, "cf", "Codice Fiscale");
                DescribeAColumn(T, "startapplication", "Data Inizio Applicazione");
                DescribeAColumn(T, "stopapplication", "Data Fine Applicazione");
                DescribeAColumn(T, "appliancepercentage", "% Applicazione");
                DescribeAColumn(T, "starthandicap", "Data Inizio Portatore Handicap");
                DescribeAColumn(T, "foreignresident", "Residenza Estera");
                DescribeAColumn(T, "flagdependent", "A Carico");
                ComputeRowsAs(T, ListingType);
            }
        }

        public override bool IsValid(DataRow R, out string errmess, out string errfield) {
            if (!base.IsValid(R, out errmess, out errfield)) return false;
            string errori;
            if ((R["forename"] == DBNull.Value) || (R["forename"].ToString() == "")) {
                errmess = "Inserire il Nome del familiare";
                errfield = "forename";
                return false;
            }

            if ((R["surname"] == DBNull.Value) || (R["surname"].ToString() == "")) {
                errmess = "Inserire il Cognome del familiare";
                errfield = "surname";
                return false;
            }

            if (R["birthdate"] == DBNull.Value) {
                errmess = "Inserire la Data di Nascita del familiare";
                errfield = "birthdate";
                return false;
            }

            if (R["gender"] == DBNull.Value) {
                errmess = "Inserire il Sesso del familiare";
                errfield = "gender";
                return false;
            }

            string TipoGeo = "";
            int idgeo = 0;

            if (R["flagforeign"] == DBNull.Value) {
                errmess = null;
                errfield = null;
                return false;
            }

            if (R["flagforeign"].ToString() == "S") {
                TipoGeo = "N";
                idgeo = CfgFn.GetNoNullInt32(R["idnation"]);
                if (idgeo <= 0) {
                    errmess = "Manca lo stato estero di nascita";
                    errfield = "idnation";
                    return false;
                }
            }
            if (R["flagforeign"].ToString() == "N") {
                TipoGeo = "C";
                idgeo = CfgFn.GetNoNullInt32(R["idcitybirth"]);
                if (idgeo <= 0) {
                    errmess = "Manca il comune di nascita";
                    errfield = "idnation";
                    return false;
                }
            }

            if (R["cf"] == DBNull.Value) {
                errmess = "CF Mancante";
                errfield = "cf";
                return false;
            }

            CalcolaCodiceFiscale.CheckCF(R["cf"].ToString(), out errori);
            if (errori != "") {

                errmess = errori = "Nel codice fiscale inserito compaiono i seguenti errori:\n\r " + errori;
                errfield = "cf";
                return false;
            }

            string codicefiscalecalcolato;
            bool isValid;
            string errCF;

            string cfNormal = CalcolaCodiceFiscale.normalizza(R["cf"].ToString().ToUpper());
            // Se arrivo a questo punto del codice vuol dire che i dati presenti nel dataset sono quantomeno diversi da null
            codicefiscalecalcolato =
                CalcolaCodiceFiscale.Make(this.Conn,
                    R["forename"].ToString(),
                    R["surname"].ToString(),
                    (DateTime) R["birthdate"],
                    idgeo.ToString(),
                    R["gender"].ToString(),
                    TipoGeo,
                    out isValid,
                    out errCF);

            if (cfNormal.Substring(0, 15) != codicefiscalecalcolato.Substring(0, 15)) {
                errmess = "Dati anagrafici errati!";
                errfield = "cf";
                if (cfNormal.Substring(0, 3) != codicefiscalecalcolato.Substring(0, 3)) {
                    errmess += "\r\nCF non coerente con il cognome";
                }
                if (cfNormal.Substring(3, 3) != codicefiscalecalcolato.Substring(3, 3)) {
                    errmess += "\r\nCF non coerente con il nome";
                }
                if (cfNormal.Substring(6, 2) != codicefiscalecalcolato.Substring(6, 2)) {
                    errmess += "\r\nCF non coerente con l'anno di nascita";
                }
                if (cfNormal.Substring(8, 1) != codicefiscalecalcolato.Substring(8, 1)) {
                    errmess += "\r\nCF non coerente con il mese di nascita";
                }

                int g1 = Convert.ToInt32(cfNormal.Substring(9, 2));
                int g2 = Convert.ToInt32(codicefiscalecalcolato.Substring(9, 2));
                string s1 = "M";
                string s2 = "M";
                if (g1 > 40) {
                    s1 = "F";
                    g1 -= 40;
                }
                if (g2 > 40) {
                    s2 = "F";
                    g2 -= 40;
                }

                if (g1 != g2) {
                    errmess += "\r\nCF non coerente con il giorno di nascita";
                }
                if (s1 != s2) {
                    errmess += "\r\nCF non coerente con il sesso";
                }

                if (cfNormal.Substring(11, 4) != codicefiscalecalcolato.Substring(11, 4)) {
                    errmess += "\r\nCF non coerente con il comune o la nazione di nascita";
                }
                return false;
            }

            decimal perc = 1;
            if (R["appliancepercentage"] != DBNull.Value) {
                perc = (decimal) R["appliancepercentage"];
            }
            if ((R["flagdependent"].ToString().ToUpper() == "S") && (perc == 0)) {
                errmess = "Se il familiare risulta a carico la percentuale di applicazione deve essere diversa da zero";
                errfield = "appliancepercentage";
                return false;
            }

            return true;
        }
    }
}
