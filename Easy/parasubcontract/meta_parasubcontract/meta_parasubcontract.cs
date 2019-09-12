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

namespace meta_parasubcontract //meta_contratto//
{
    /// <summary>
    /// Summary description for Meta_contratto.
    /// </summary>
    public class Meta_parasubcontract : Meta_easydata {
        public Meta_parasubcontract(DataAccess Conn, MetaDataDispatcher Dispatcher) :
            base(Conn, Dispatcher, "parasubcontract") {
            EditTypes.Add("default");
            EditTypes.Add("trasf_contratto");
            EditTypes.Add("senzacedolini");
            EditTypes.Add("nontrasferibile");
            ListingTypes.Add("default");
            ListingTypes.Add("lista");
        }

        protected override Form GetForm(string FormName) {
            switch (FormName) {
                case "default": {
                    Name = "Contratto";
                    DefaultListType = "default";
                    return GetFormByDllName("parasubcontract_default");
                }
                case "trasf_contratto": {
                    Name = "Wizard Trasferimento dei Contratti";
                    DefaultListType = "lista";
                    return GetFormByDllName("parasubcontract_trasf_contratto");
                }
                case "senzacedolini": {
                    Name = "Contratti senza Cedolini";
                    ActAsList();
                    DefaultListType = "default";
                    return GetFormByDllName("parasubcontract_senzacedolini");
                }
                case "nontrasferibile": {
                    Name = "Contratti non Trasferibili";
                    ActAsList();
                    return GetFormByDllName("parasubcontract_nontrasferibile");
                }
                default:
                    return null;
            }
        }

        public override void SetDefaults(DataTable PrimaryTable) {
            base.SetDefaults(PrimaryTable);
            SetDefault(PrimaryTable, "ycon", GetSys("esercizio"));
            SetDefault(PrimaryTable, "requested_doc", 0);
        }

        public override DataRow SelectOne(string ListingType, string filter, string searchtable, DataTable ToMerge) {
            if (ListingType == "default")
                return base.SelectOne(ListingType, filter, "parasubcontractview", ToMerge);
            return base.SelectOne(ListingType, filter, searchtable, ToMerge);
        }

        public override bool IsValid(DataRow R, out string errmess, out string errfield) {
            if (!base.IsValid(R, out errmess, out errfield)) return false;

//parasubcon§06000011
            string filter_idrelated = "parasubcontract§" + R["idcon"].ToString();
            filter_idrelated = QHS.CmpEq("idrelated", filter_idrelated);

            bool IsAdmin = (GetSys("manage_prestazioni") != null)
                ? GetSys("manage_prestazioni").ToString() == "S"
                : false;


            DataTable Tserviceregistry = Conn.RUN_SELECT("serviceregistry", "*", null, filter_idrelated, null, null,
                true);

            if ((Tserviceregistry.Rows.Count > 0) && (R.RowState == DataRowState.Modified)) {
                bool error = false;
                string message = "";
                if (R["idreg", DataRowVersion.Current].ToString() != R["idreg", DataRowVersion.Original].ToString()) {
                    message = "Percipiente \n\r ";
                    error = true;
                }

                if (R["duty", DataRowVersion.Current].ToString() != R["duty", DataRowVersion.Original].ToString()) {
                    message = message + "Mansione \n\r ";
                    error = true;
                }

                if (R["start", DataRowVersion.Current].ToString() != R["start", DataRowVersion.Original].ToString()) {
                    message = message + "Data Inizio \n\r ";
                    error = true;
                }

                if (R["stop", DataRowVersion.Current].ToString() != R["stop", DataRowVersion.Original].ToString()) {
                    message = message + "Data Fine \n\r ";
                    error = true;
                }

                if (R["grossamount", DataRowVersion.Current].ToString() !=
                    R["grossamount", DataRowVersion.Original].ToString()) {
                    message = message + "Lordo al beneficiario \n\r ";
                    error = true;
                }

                if (error) {
                    if (IsAdmin) {
                        errmess =
                            "L'Anagrafe delle Prestazioni è stata già generata, e risultano modificati i seguenti dati: \n\r" +
                            message + "Adeguare anche i dati dell'Incarico.";
                        MessageBox.Show(errmess, "Avviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else {
                        errmess = "Risultano modificati i seguenti dati: \n\r" + message +
                                  "La modifica non è consentita perché l'Anagrafe delle Prestazioni è stata già generata.\r\n" +
                                  "Contattare il servizio assistenza o un utente con ruolo 'manage_prestazioni' ";
                        return false;
                    }
                }
            }
//

            if (Convert.ToInt32(R["grossamount"]) <= 0) {
                errmess = "L'importo del contratto deve essere maggiore di zero";
                errfield = "grossamount";
                return false;
            }

            if (CfgFn.GetNoNullInt32(R["idser"]) != 0) {
                string q = "SELECT * FROM servicetax JOIN tax " +
                           "ON servicetax.taxcode = tax.taxcode WHERE " +
                           QHS.AppAnd(QHS.CmpEq("tax.taxkind", 4), QHS.CmpEq("servicetax.idser", R["idser"]));
                DataTable prestazione = Conn.SQLRunner(q, -1, out errmess);
                if (prestazione == null) {
                    errfield = null;
                    return false;
                }

                if (prestazione.Rows.Count != 0)
                    if (CfgFn.GetNoNullInt32(R["idpat"]) <= 0) {
                        errmess = "Scegliere una Posizione Assicurativa Territoriale";
                        errfield = "idpat";
                        return false;
                    }
            }
            else {
                errmess = "Inserire la prestazione";
                errfield = "idser";
                return false;
            }

            if (!(R["start"] is DateTime)) {
                errmess = "Inserire la data di inizio del contratto";
                errfield = "start";
                return false;
            }

            if (!(R["stop"] is DateTime)) {
                errmess = "Inserire la data di fine del contratto";
                errfield = "stop";
                return false;
            }

            DateTime dataInizio = (DateTime) R["start"];
            DateTime dataFine = (DateTime) R["stop"];

            if (dataInizio.Year > (int) GetSys("esercizio")) {
                errmess = "L'anno di inizio del contratto deve essere minore o uguale all'esercizio";
                errfield = "start";
                return false;
            }

            if (dataInizio > dataFine) {
                errmess = "La data di fine del contratto deve essere successiva alla data di inizio del contratto";
                errfield = "stop";
                return false;
            }

            if (CfgFn.GetNoNullInt32(R["idreg"]) <= 0) {
                errmess = "Inserire il Percipiente";
                errfield = "registry.title";
                return false;
            }

            //Se il DS contiene la tabella registry, controlla che l'idreg abbia il CF,se SI chiama il metodo.
            if (R.Table.DataSet.Tables.Contains("registry") && (R.Table.DataSet.Tables["registry"].Rows.Count > 0)) {
                DataRow Registry = R.Table.DataSet.Tables["registry"].Rows[0];
                if (Registry["cf"] != DBNull.Value) {
                    string errori;
                    if (!CalcolaCodiceFiscale.CodiceFiscaleValido(this.Conn, Registry, out errori)) {
                        errmess = "Il Codice Fiscale non è valido!\n" + errori;
                        errfield = "idreg";
                        return false;
                    }
                }
            }
            else {
                //Se il DS non contiene la tabella registry,controlla che l'idreg abbia il CF se SI legge la riga dal DB
                // e chiama il metodo.
                object CF = Conn.DO_READ_VALUE("registry", QHS.CmpEq("idreg", R["idreg"]), "cf");
                if (CF != DBNull.Value) {
                    DataTable TRegistry = Conn.RUN_SELECT("registry", "*", null, QHS.CmpEq("idreg", R["idreg"]), null,
                        null, true);
                    if (TRegistry.Rows.Count > 0) {
                        DataRow Registry = TRegistry.Rows[0];
                        string errori;
                        if (!CalcolaCodiceFiscale.CodiceFiscaleValido(this.Conn, Registry, out errori)) {
                            errmess = "Il Codice Fiscale non è valido!\n" + errori;
                            errfield = "idreg";
                            return false;
                        }
                    }
                }
                else {
                    errmess = "E' necessario che il percipiente abbia il codice fiscale";
                    errfield = "idreg";
                    return false;
                }
            }

            return true;
        }

        public override DataRow Get_New_Row(DataRow ParentRow, DataTable T) {
            DataTable tConfigurazione = T.DataSet.Tables["config"];
            DataRow[] rConfig = tConfigurazione.Select(QHC.CmpEq("ayear", GetSys("esercizio")));
            if (rConfig.Length == 0) {
                MessageBox.Show("Bisogna inserire i dati nel form di configurazione del contratto",
                    "Contratto - Dati Mancanti", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return null;
            }

            int flag_autodocnumbering = CfgFn.GetNoNullInt32(rConfig[0]["flag_autodocnumbering"]);
            string kind = ((flag_autodocnumbering & 0x10) == 0) ? "A" : "M";

            RowChange.SetSelector(T, "ycon");
            RowChange.MarkAsAutoincrement(T.Columns["idcon"], null,
                Conn.GetSys("esercizio").ToString().Substring(2, 2), 6);
            if (kind.ToUpper() == "A") {
                RowChange.MarkAsAutoincrement(T.Columns["ncon"], null, null, 0);
            }
            else {
                int nmax = CfgFn.GetNoNullInt32(
                               Conn.DO_READ_VALUE("parasubcontract", QHS.CmpEq("ycon", GetSys("esercizio"))
                                   , "MAX(CONVERT(int,ncon))")) + 1;
                SetDefault(T, "ncon", nmax);
            }

            return base.Get_New_Row(ParentRow, T);
        }

        protected override void InsertCopyColumn(DataColumn C, DataRow Source, DataRow Dest) {
            if ((C.ColumnName == "ycon") ||
                (C.ColumnName == "ncon") ||
                (C.ColumnName == "idcon")) return;
            base.InsertCopyColumn(C, Source, Dest);
        }

        public override void DescribeColumns(DataTable T, string ListingType) {
            base.DescribeColumns(T, ListingType);
            if (ListingType == "lista") {
                foreach (DataColumn C in T.Columns) DescribeAColumn(T, C.ColumnName, "");
                DescribeAColumn(T, "idcon", "");
                DescribeAColumn(T, "ycon", "Esercizio");
                DescribeAColumn(T, "ncon", "Num. Contratto");
                DescribeAColumn(T, "!denominazione", "Percipiente", "registry.title");
            }
        }
    }
}
