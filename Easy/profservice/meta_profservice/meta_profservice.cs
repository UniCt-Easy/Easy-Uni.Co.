
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
using System.Windows.Forms;
using metaeasylibrary;
using metadatalibrary;
using funzioni_configurazione;

namespace meta_profservice//meta_contrattoprof//
{
    /// <summary>
    /// Summary description for Meta_contrattoprof.
    /// </summary>
    public class Meta_profservice : Meta_easydata {
        public Meta_profservice(DataAccess Conn, MetaDataDispatcher Dispatcher) :
            base(Conn, Dispatcher, "profservice") {
            EditTypes.Add("default");
            ListingTypes.Add("default");
        }

        protected override Form GetForm(string FormName) {
            if (FormName == "default") {
                Name = "Parcella Professionale e Fatture con Ritenute";
                DefaultListType = "default";
                return GetFormByDllName("profservice_default");
            }
            return null;
        }

        public override DataRow Get_New_Row(DataRow ParentRow, DataTable T) {
            string testoMessaggio = "Bisogna inserire i dati nel form di configurazione del contratto professionale";
            string filteresercizio = QHC.CmpEq("ayear", GetSys("esercizio"));
            DataTable tConfigurazione = T.DataSet.Tables["config"];
            DataRow[] rConfig = tConfigurazione.Select(filteresercizio);
            if (rConfig.Length == 0) {
                MetaFactory.factory.getSingleton<IMessageShower>().Show(testoMessaggio, "Contratto Professionale - Dati Mancanti", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return null;
            }

            int flag_autodocnumbering = CfgFn.GetNoNullInt32(rConfig[0]["flag_autodocnumbering"]);
            string kind = ((flag_autodocnumbering & 0x40) == 0) ? "A" : "M";

            if (kind.ToUpper() == "A") {
                string reset = rConfig[0]["profservice_flagrestart"].ToString();
                if (reset.ToUpper() == "S") {
                    RowChange.SetSelector(T, "ycon");
                }
                RowChange.MarkAsAutoincrement(T.Columns["ncon"], null, null, 0);
            }
            else {
                string filter = QHS.CmpEq("ycon", GetSys("esercizio"));
                int nmax = CfgFn.GetNoNullInt32(
                    Conn.DO_READ_VALUE("profservice", filter, "MAX(ncon)")) + 1;
                SetDefault(T, "ncon", nmax);
            }
            return base.Get_New_Row(ParentRow, T);
        }

        protected override void InsertCopyColumn(DataColumn C, DataRow Source, DataRow Dest) {
            if ((C.ColumnName == "idinvkind") || (C.ColumnName == "yinv") || (C.ColumnName == "ninv")) return;
            base.InsertCopyColumn(C, Source, Dest);
        }

        public override DataRow SelectOne(string ListingType, string filter, string searchtable, DataTable ToMerge) {
            if (ListingType == "default")
                return base.SelectOne(ListingType, filter, "profserviceview", ToMerge);
            return base.SelectOne(ListingType, filter, searchtable, ToMerge);
        }

        public override bool IsValid(DataRow R, out string errmess, out string errfield) {
            if (!base.IsValid(R, out errmess, out errfield)) return false;
            //profservice§2006§34

            if (CfgFn.GetNoNullInt32(R["idser"]) <= 0) {
                errmess = "Bisogna specificare la prestazione";
                errfield = "idser";
                return false;
            }

            string filterRitEnpals = QHS.AppAnd(QHS.CmpEq("idser", R["idser"]), QHS.CmpEq("taxkind", 3), QHS.Like("taxref", "%enpals%"));
            DataTable TRitEnpals = Conn.RUN_SELECT("servicetaxview", "*", null, filterRitEnpals, null, false);
            if (TRitEnpals.Rows.Count > 0) {
                errmess = "La denuncia UNIEMENS per il compenso assoggettato ad ENPALS \n\r " +
                          "non sarà prodotta con il flusso UNIEMENS di Easy ma \n\r " +
                          "dovrà essere eventualmente effettuata direttamente dal sito \n\r " +
                          "http://www.inps.it/ . Si raccomanda di informare tempestivamente \n\r " +
                          "l'ufficio competente alla trasmissione della denuncia UNIEMENS.";
                errfield = "idser";
                MetaFactory.factory.getSingleton<IMessageShower>().Show(errmess, "Avviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            bool IsAdmin = (GetSys("manage_prestazioni") != null)
                            ? GetSys("manage_prestazioni").ToString() == "S"
                            : false;

            string filter_idrelated = QHC.CmpEq("idrelated", "profservice§" + R["ycon"] + "§" + R["ncon"]);
            //filter_idrelated = "(idrelated="+QueryCreator.quotedstrvalue(filter_idrelated,true)+")";

            DataTable Tserviceregistry = Conn.RUN_SELECT("serviceregistry", "*", null, filter_idrelated, null, null, true);
            if ((Tserviceregistry.Rows.Count > 0) && (R.RowState == DataRowState.Modified)) {
                bool error = false;
                string message = "";
                if (R["idreg", DataRowVersion.Current].ToString() != R["idreg", DataRowVersion.Original].ToString()) {
                    message = "Percipiente \n\r ";
                    error = true;
                }
                if (R["description", DataRowVersion.Current].ToString() != R["description", DataRowVersion.Original].ToString()) {
                    message = message + "Descrizione \n\r ";
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
                if (CfgFn.RoundValuta(CfgFn.GetNoNullDecimal(R["totalcost", DataRowVersion.Current])) != CfgFn.RoundValuta(CfgFn.GetNoNullDecimal(R["totalcost", DataRowVersion.Original]))) {
                    message = message + "Lordo al beneficiario \n\r ";
                    error = true;
                }

                if (error) {
                    if (IsAdmin) {
                        errmess = "L'Anagrafe delle Prestazioni è stata già generata, e risultano modificati i seguenti dati: \n\r"
                            + message + "Adeguare anche i dati dell'Incarico.";
                        MetaFactory.factory.getSingleton<IMessageShower>().Show(errmess, "Avviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else {
                        errmess = "Risultano modificati i seguenti dati: \n\r"
                            + message + "La modifica non è consentita perché l'Anagrafe delle Prestazioni è stata già generata.\r\n" +
                            "Contattare il servizio assistenza o un utente con ruolo 'manage_prestazioni' ";
                        return false;
                    }
                }
            }

            //

            if (CfgFn.GetNoNullInt32(R["idreg"]) == 0) {
                errmess = "Inserire il percipiente";
                errfield = "idreg";
                return false;
            }
            if (R["description"].ToString() == "") {
                errmess = "Il campo descrizione è obbligatorio.";
                errfield = "description";
                return false;
            }
            if (R["doc"].ToString() == "") {
                errmess = "Il campo documento è obbligatorio e dovrebbe contenere il rif. alla fattura.";
                errfield = "doc";
            }

            if (R["docdate"].ToString() == "") {
                errmess = "Il campo data documento è obbligatorio e dovrebbe contenere la data della fattura.";
                errfield = "docdate";
            }
            //A questo controllo è stato tolto l' uguale,perchè ci sono dei casi in cui i professionisti fatturano solo spese non imponibili 
            //anticipate per conto del committente quindi è possibile che l'importo della prestazione sia uguale a zero. Task 3750
            if (CfgFn.GetNoNullDecimal(R["feegross"]) < 0) {
                errmess = "L'importo lordo del contratto deve essere maggiore di zero";
                errfield = "feegross";
                return false;
            }

            DateTime dataInizio = (DateTime)R["start"];
            DateTime dataFine = (DateTime)R["stop"];
            if (dataInizio > dataFine) {
                errmess = "La data di fine deve essere identica o successiva a quella di inizio";
                errfield = "stop";
                return false;
            }

            //Se il percipiente ha un indirizzo AP, nel form del compenso si deve scegliere o S o N
            String codeaddress = "07_SW_ANP";
            DateTime DataInizio = (DateTime)R["start"];
            object idaddresskind = Conn.DO_READ_VALUE("address", QHS.CmpEq("codeaddress", codeaddress), "idaddress");
            DataTable Address = DataAccess.RUN_SELECT(Conn, "registryaddress", "*", null,
                                QHS.AppAnd(QHS.CmpEq("idaddresskind", idaddresskind), QHS.CmpEq("idreg", R["idreg"]),
                                QHS.CmpLe("start", DataInizio), QHS.NullOrGe("stop", DataInizio)), false);
            if (Address.Rows.Count > 0) {
                if ((R["authneeded"].ToString() != "S") && (R["authneeded"].ToString() != "N")) {
                    errfield = "authneeded";
                    errmess = "Il percipiente ha un indirizzo Anagrafe delle Prestazioni, pertanto va indicato se necessita o meno dell'autorizzazione.";
                    return false;
                }
            }
            if (R["authneeded"].ToString() == "S" && R["authdoc"].ToString() == "") {
                errmess = "Il campo 'Documento' è obbligatorio";
                errfield = "authdoc";
                return false;
            }

            if (R["authneeded"].ToString() == "S" && R["authdocdate"] == DBNull.Value) {
                errmess = "Il campo 'data' è obbligatorio";
                errfield = "authdocdate";
                return false;
            }

            if (R["authneeded"].ToString() == "N" && R["noauthreason"].ToString() == "") {
                errmess = "Il campo 'Motivo' è obbligatorio";
                errfield = "authdoc";
                return false;
            }
            if (R.Table.DataSet.Tables.Contains("profservicetax") && (R.Table.DataSet.Tables["profservicetax"].Select().Length == 0)) {
	           
			            errmess = "Non è possibile salvare una prestazione professionale senza ritenute";
			            return false;
            
            }


            if ((R.RowState == DataRowState.Added) && (!RowChange.IsAutoIncrement(R.Table.Columns["ncon"]))) {
                string filterProfService = QHS.AppAnd(QHS.CmpEq("ycon", R["ycon"]),
                    QHS.CmpEq("ncon", R["ncon"]));
                int NPRESENT = Conn.RUN_SELECT_COUNT("profservice", filterProfService, true);
                if (NPRESENT > 0) {
                    errmess = "Esiste già un contratto con lo stesso numero.";
                    errfield = "ncon";
                    return false;
                }
            }
            //Se il DS contiene la tabella registry, controlla che l'idreg abbia il CF,se SI chiama il metodo.
            if (R.Table.DataSet.Tables.Contains("registry") && (R.Table.DataSet.Tables["registry"].Rows.Count > 0)) {
                DataRow Registry = R.Table.DataSet.Tables["registry"].Rows[0];
                if (Registry["cf"] != DBNull.Value) {
                    string errori;
                    if (!CalcolaCodiceFiscale.CodiceFiscaleValido(this.Conn, Registry, out errori)) {
                        errmess = "Il Codice Fiscale non è valido!\n" + errori;
                        return false;
                    }
                }
            }
            else {
                //Se il DS non contiene la tabella registry,controlla che l'idreg abbia il CF se SI legge la riga dal DB
                // e chiama il metodo.
                object CF = Conn.DO_READ_VALUE("registry", QHS.CmpEq("idreg", R["idreg"]), "cf");
                if (CF != DBNull.Value) {
                    DataTable TRegistry = Conn.RUN_SELECT("registry", "*", null, QHS.CmpEq("idreg", R["idreg"]), null, null, true);
                    if (TRegistry.Rows.Count > 0) {
                        DataRow Registry = TRegistry.Rows[0];
                        string errori;
                        if (!CalcolaCodiceFiscale.CodiceFiscaleValido(this.Conn, Registry, out errori)) {
                            errmess = "Il Codice Fiscale non è valido!\n" + errori;
                            return false;
                        }
                    }
                }
            }
            return true;
        }

        public override void SetDefaults(DataTable PrimaryTable) {
            base.SetDefaults(PrimaryTable);
            SetDefault(PrimaryTable, "ycon", GetSys("esercizio"));
            //SetDefault(PrimaryTable, "idser", "07_PRF");
            SetDefault(PrimaryTable, "adate", GetSys("datacontabile"));
            SetDefault(PrimaryTable, "flaginvoiced", "N");
            SetDefault(PrimaryTable, "flagmixed", "N");
            SetDefault(PrimaryTable, "authneeded", "X");
            SetDefault(PrimaryTable, "requested_doc", 0);
        }

        public override void DescribeColumns(DataTable T, string ListingType) {
            base.DescribeColumns(T, ListingType);
            if (ListingType == "default") {
                foreach (DataColumn C in T.Columns) DescribeAColumn(T, C.ColumnName, "");
                DescribeAColumn(T, "ycon", "Esercizio Contratto");
                DescribeAColumn(T, "ncon", "Numero Contratto");
            }
        }
    }
}
