/*
    Easy
    Copyright (C) 2020 Universit√† degli Studi di Catania (www.unict.it)
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

namespace meta_serviceregistry {
    /// <summary>
    /// Summary description for Class1.
    /// </summary>
    public class Meta_serviceregistry : Meta_easydata {
        public Meta_serviceregistry(DataAccess Conn, MetaDataDispatcher Dispatcher)
            :
            base(Conn, Dispatcher, "serviceregistry") {
            EditTypes.Add("default");
            ListingTypes.Add("default");
        }

        protected override void InsertCopyColumn(DataColumn C, DataRow Source, DataRow Dest) {
            if (C.ColumnName == "is_delivered") return;
            if (C.ColumnName == "is_changed") return;
            if (C.ColumnName == "is_annulled") return;
            if (C.ColumnName == "is_blocked") return;
            if (C.ColumnName == "id_service") return;
            if (C.ColumnName == "website_annulled") return;
            if (C.ColumnName == "idrelated") return;

            if (C.ColumnName == "idreg") return;        //task 12786
            if (C.ColumnName == "pa_code") return;      //task 12786
            if (C.ColumnName == "authorizationdate") return; //task 12786
            if (C.ColumnName == "senderreporting") return;  //task 12786
            if (C.ColumnName == "nservreg") return;         //task 12786
            
            base.InsertCopyColumn(C, Source, Dest);
        }

        protected override Form GetForm(string FormName) {

            if (FormName == "default") {
                DefaultListType = "default";
                Name = "Banca dati degli Incarichi - Anagrafe Prestazioni e Pubblicazione sito web istituzionale";
                return GetFormByDllName("serviceregistry_default");
            }

            return null;
        }

        public override DataRow SelectOne(string ListingType, string filter, string searchtable, DataTable ToMerge) {
            if (ListingType == "default")
                return base.SelectOne(ListingType, filter, "serviceregistryview", ToMerge);

            return base.SelectOne(ListingType, filter, "serviceregistry", ToMerge);
        }

        public override void SetDefaults(DataTable PrimaryTable) {
            base.SetDefaults(PrimaryTable);
            if ((PrimaryTable.Columns["yservreg"].DefaultValue == DBNull.Value) || (CfgFn.GetNoNullInt32(PrimaryTable.Columns["yservreg"]) == 0)) {
                SetDefault(PrimaryTable, "yservreg", GetSys("esercizio"));
            }
            if (PrimaryTable.Columns["flaghuman"].DefaultValue == DBNull.Value) {
                SetDefault(PrimaryTable, "flaghuman", "N");
            }
            SetDefault(PrimaryTable, "officeduty", "N");
            SetDefault(PrimaryTable, "payment", "N");
            SetDefault(PrimaryTable, "flagforeign", "N");
            SetDefault(PrimaryTable, "conferring_flagforeign", "N");
            SetDefault(PrimaryTable, "is_delivered", "N");
            SetDefault(PrimaryTable, "is_changed", "N");
            SetDefault(PrimaryTable, "is_annulled", "N");
            SetDefault(PrimaryTable, "is_blocked", "N");
            SetDefault(PrimaryTable, "website_annulled", "N");
            SetDefault(PrimaryTable, "regulation", "N");
            SetDefault(PrimaryTable, "rulespecifics", "N");

            string securityServiceagency = Conn.SelectCondition("serviceagency", true);

            DataTable Tserviceagency = Conn.RUN_SELECT("serviceagency", "*", null, securityServiceagency, null, null, false);
            if (Tserviceagency.Rows.Count == 1) {
                DataRow Rserviceagency = Tserviceagency.Rows[0];
                SetDefault(PrimaryTable, "pa_code", Rserviceagency["pa_code"].ToString());
                SetDefault(PrimaryTable, "codicepaipa", Rserviceagency["codicepaipa"].ToString());
                SetDefault(PrimaryTable, "codiceaooipa", Rserviceagency["codiceaooipa"].ToString());
                SetDefault(PrimaryTable, "codiceuoipa", Rserviceagency["codiceuoipa"].ToString());

                //SetDefault(PrimaryTable, "pa_title", Rserviceagency["pa_title"].ToString());
                //SetDefault(PrimaryTable, "pa_cf", Rserviceagency["pa_cf"].ToString());
            }
        }

        public override DataRow Get_New_Row(DataRow ParentRow, DataTable T) {
            SetAutoIncrementProperties(T, Conn);
            RowChange.SetSelector(T, "yservreg");
            RowChange.MarkAsAutoincrement(T.Columns["nservreg"], null,
                null, 7);
            return base.Get_New_Row(ParentRow, T);
        }

        public static void SetAutoIncrementProperties(DataTable T, DataAccess Conn) {
            RowChange.MarkAsAutoincrement(T.Columns["senderreporting"], null, null, 0);
            RowChange.MarkAsCustomAutoincrement(T.Columns["senderreporting"], new RowChange.CustomCalcAutoID(CalcSenderreporting));
        }

        private static object CalcSenderreporting(DataRow R, DataColumn C, DataAccess Conn) {
            DataTable Tlicense = Conn.RUN_SELECT("license", "*", null, null, null, true);
            object iddb = Tlicense.Rows[0]["iddb"];
            object oyservreg = R["yservreg"];
            object onservreg = R["nservreg"];

            string idMittente = oyservreg.ToString() + onservreg.ToString().PadLeft(5, '0') + iddb.ToString().PadLeft(5, '0');
            return idMittente;
        }


        public override void DescribeColumns(DataTable T, string listtype) {
            base.DescribeColumns(T, listtype);
            if (listtype == "default") {
                foreach (DataColumn C in T.Columns) {
                    DescribeAColumn(T, C.ColumnName, "", -1);
                }
                int nPos = 1;
                DescribeAColumn(T, "yservreg", "Anno incarico", nPos++);
                DescribeAColumn(T, "nservreg", "Numero incarico", nPos++);
                DescribeAColumn(T, "is_delivered", "Incarico Trasmesso", nPos++);
                DescribeAColumn(T, "is_changed", "Incarico da Modificare", nPos++);
                DescribeAColumn(T, "is_annulled", "Incarico Annullato", nPos++);
                DescribeAColumn(T, "is_blocked", "Incarico Bloccato", nPos++);
            }
        }
        public override bool IsValid(DataRow R, out string errmess, out string errfield) {
            if (!base.IsValid(R, out errmess, out errfield)) return false;
            string topublish = "";
            string totransmit = "";
            if (R["idreg"] == DBNull.Value) {
                errmess = "Specificare l'incaricato";
                errfield = "idreg";
                return false;
            }
            if (R["idserviceregistrykind"] != DBNull.Value) {
                topublish = Conn.DO_READ_VALUE("serviceregistrykind", QHS.CmpEq("idserviceregistrykind", R["idserviceregistrykind"]), "topublish").ToString();
                totransmit = Conn.DO_READ_VALUE("serviceregistrykind", QHS.CmpEq("idserviceregistrykind", R["idserviceregistrykind"]), "totransmit").ToString();
            }
            if ((totransmit == "") || (totransmit == "S")) {
                if (R["employkind"] == DBNull.Value) {
                    errmess = "Specificare il Tipo Incaricato";
                    errfield = "employkind";
                    return false;
                }

                if (R["ordinancelink"] == DBNull.Value) {
	                errmess = "Per gli incarichi da trasferire a perla Ë obbligatorio il link al decreto di conferimento dellíincarico";
	                errfield = "ordinancelink";
	                return false;
                }
                ///tipologia societ‡ impostata
                if (R["idconsultingkind"] != DBNull.Value) {
                    #region  tipologia societ‡ impostata
                    string tipcons = (string)R["idconsultingkind"];


                    // x un consulente con Tipologia Persona fisica 
                    if ((R["flaghuman"].ToString() == "S") && (R["employkind"].ToString().ToUpper() != "D")) {

                        if ((R["cf"] == DBNull.Value) && (R["flagforeign"].ToString().ToUpper() != "S")) {
                            errmess = "Per un Consulente (con tipolgia Persona Fisica) il Codice fiscale Ë obbligatorio. Inserirlo nel modulo Anagrafica.";
                            errfield = "cf";
                            return false;
                        }
                        if (R["surname"] == DBNull.Value) {
                            errmess = "Per un Consulente (con tipolgia Persona Fisica) il Cognome Ë obbligatorio. Inserirlo nel modulo Anagrafica.";
                            errfield = "surname";
                            return false;
                        }
                        if (R["forename"] == DBNull.Value) {
                            errmess = "Per un Consulente (con tipolgia Persona Fisica) il Nome Ë obbligatoro. Inserirlo nel modulo Anagrafica.";
                            errfield = "forename";
                            return false;
                        }
                        if ((R["flagforeign"].ToString().ToUpper() != "S") && (R["p_iva"] == DBNull.Value) && (R["cf"] == DBNull.Value)) {
                            errmess = "Per un Consulente (con tipolgia Persona Fisica) Ë necessario specificare " +
                                        "o la Partita IVA o il Codice Fiscale";
                            errfield = "p_iva" + "cf";
                            return false;
                        }
                        if ((R["flagforeign"].ToString().ToUpper() == "S") && (R["birthdate"] == DBNull.Value)) {
                            errmess = "Per i consulenti esteri la Data di Nascita Ë obbligatoria. Inserirla nel modulo Anagrafica.";
                            errfield = "birthdate";
                            return false;
                        }
                    }


                    // x un consulente con Tipologia Societ‡ 
                    if ((R["flaghuman"].ToString() != "S") && (R["employkind"].ToString().ToUpper() != "D")) {
                        // Per un consulente Persona giuridica, non estero, il CF Ë obbligatorio task 5972
                        if ((R["cf"] == DBNull.Value) && (R["flagforeign"].ToString().ToUpper() != "S")) {
                            errmess = "Per un Consulente (Persona Giuridica) il Codice fiscale Ë obbligatorio. Inserirlo nel modulo Anagrafica.";
                            errfield = "cf";
                            return false;
                        }

                        if (R["title"] == DBNull.Value) {
                            errmess = "Per una Societ‡ la Denominazione Ë obbligatorio";
                            errfield = "title";
                            return false;
                        }
                        if ((R["flagforeign"].ToString().ToUpper() != "S") && (R["codcity"] == DBNull.Value)) {
                            errmess = "Per una Societ‡ italiana il Codice Comune Sede Ë obbligatorio";
                            errfield = "title";
                            return false;
                        }
                        if ((R["p_iva"] == DBNull.Value) && (R["flagforeign"].ToString().ToUpper() != "S")) {
                            errmess = "Per una Societ‡ la Partita IVA Ë obbligatoria. Inserirla nel modulo Anagrafica.";
                            errfield = "p_iva";
                            return false;
                        }

                    }

                    #endregion
                }
                // x un consulente
                if (R["employkind"].ToString().ToUpper() != "D") {
                    if (R["idconsultingkind"] == DBNull.Value && R["flaghuman"].ToString() == "N") {
                        errmess = "Per un Consulente Ë obbligatorio specificare la Tipologia";
                        errfield = "idconsultingkind";
                        return false;
                    }
                    if (R["description"] == DBNull.Value) {
                        errmess = "Per un Consulente Ë obbligatorio specificare la descrizione dell'incarico";
                        errfield = "description";
                        return false;
                    }
                    if (R["referencesemester"] == DBNull.Value) {
                        errmess = "Per un Consulente Ë obbligatorio specificare il semestre di Riferimento";
                        errfield = "referencesemester";
                        return false;
                    }
                    if (R["expectedamount"] == DBNull.Value) {
                        errmess = "Per un Consulente Ë obbligatorio specificare l'importo previsto";
                        errfield = "expectedamount";
                        return false;
                    }
                    if ((!R["referencesemester"].Equals(1)) && (!R["referencesemester"].Equals(2))) {
                        errmess = "Il Semestre di Riferimento deve avere valore '1' o '2' ";
                        errfield = "referencesemester";
                        return false;
                    }
                    if (R["idacquirekind"] == DBNull.Value)//
                {
                        errmess = "Per un Consulente Ë obbligatorio specificare la Modalit‡ di acquisizione";
                        errfield = "idacquirekind";
                        return false;
                    }
                    else {
                        string active = Conn.DO_READ_VALUE("acquirekind",
                                        QHS.AppAnd(QHS.CmpEq("idacquirekind", R["idacquirekind"]),
                                                    QHS.CmpEq("ayear", R["yservreg"])), "active").ToString();
                        if (active != "S") {
                            errmess = "La Modalit‡ di acquisizione deve essere attiva nell'esercizio dell'incarico";
                            errfield = "idacquirekind";
                            return false;
                        }
                    }

                    if (R["idapcontractkind"] == DBNull.Value) {
                        errmess = "Per un Consulente Ë obbligatorio specificare il Tipo Rapporto";
                        errfield = "idapcontractkind";
                        return false;
                    }
                    else {
                        string active = Conn.DO_READ_VALUE("apcontractkind",
                                        QHS.AppAnd(QHS.CmpEq("idapcontractkind", R["idapcontractkind"]),
                                                    QHS.CmpEq("ayear", R["yservreg"])), "active").ToString();
                        if (active != "S") {
                            errmess = "Il Tipo Rapporto deve essere attivo nell'esercizio dell'incarico";
                            errfield = "idapcontractkind";
                            return false;
                        }

                    }
                    if (CfgFn.GetNoNullInt32(R["yservreg"]) < 2011) {
                        if (R["idfinancialactivity"] == DBNull.Value) {
                            errmess = "Per un Consulente Ë obbligatorio specificare l'Attivit‡ economica";
                            errfield = "idfinancialactivity";
                            return false;
                        }
                        else {
                            string active = Conn.DO_READ_VALUE("financialactivity",
                                            QHS.AppAnd(QHS.CmpEq("idfinancialactivity", R["idfinancialactivity"]),
                                                        QHS.CmpEq("ayear", R["yservreg"])), "active").ToString();
                            if (active != "S") {
                                errmess = "l'Attivit‡ economica deve essere attiva nell'esercizio dell'incarico";
                                errfield = "idfinancialactivity";
                                return false;
                            }
                        }
                    }

                    if ((R["idapfinancialactivity"] == DBNull.Value) && (R["idfinancialactivity"] == DBNull.Value)) {
                        errmess = "Per un Consulente Ë obbligatorio scegliere l'Attivit‡ economica in base alla data di affidamento dell'Incarico";
                        return false;
                    }

                    if ((R["idapfinancialactivity"] == DBNull.Value) && (CfgFn.GetNoNullInt32(R["yservreg"]) >= 2013)) {
                        errmess = "Per un Consulente Ë obbligatorio specificare l'Attivit‡ economica";
                        errfield = "idapfinancialactivity";
                        return false;
                    }

                    if (R["regulation"] == DBNull.Value) {
                        errmess = "Per un Consulente Ë obbligatorio specificare se per la modalit‡ di selezione "
                                 + "si Ë fatto riferimento ad un regolamento all'uopo adottato dall'amministrazione";
                        errfield = "regulation";
                        return false;
                    }
                    //Task 4828
                    //if (R["expectationsdate"] == DBNull.Value) {
                    //    errmess = "Per un Consulente Ë necessario specificare la Data Affidamento incarico";
                    //    errfield = "expectationsdate";
                    //    return false;
                    //}
                }
                // x un dipendente 
                if (R["employkind"].ToString().ToUpper() == "D") {
                    if ((R["idconsultingkind"] == DBNull.Value) &&
                    ((R["idapregistrykind"].ToString() == "4") || (R["idapregistrykind"].ToString() == "5"))) {
                        errmess = "Per un conferente ( se Persona Giuridica ) Ë obbligatorio la Tipologia Azienda.";
                        errfield = "idconsultingkind";
                        return false;
                    }

                    if (R["annotation"] == DBNull.Value) {
                        errmess = "Per un Dipendente la Relazione Accompagnatoria Ë obbligatoria";
                        errfield = "annotation";
                        return false;
                    }

                    if (R["idapmanager"] == DBNull.Value) {
                        errmess = "Per un Dipendente la Qualifica Ë obbligatoria";
                        errfield = "idapmanager";
                        return false;
                    }

                    if (R["surname"] == DBNull.Value) {
                        errmess = "Per un Dipendente il Cognome Ë obbligatorio. Inserirlo nel modulo Anagrafica.";
                        errfield = "surname";
                        return false;
                    }
                    if (R["forename"] == DBNull.Value) {
                        errmess = "Per un Dipendente il Nome Ë obbligatorio. Inserirlo nel modulo Anagrafica.";
                        errfield = "forename";
                        return false;
                    }
                    if (R["cf"] == DBNull.Value) {
                        errmess = "Per un Dipendente il Codice fiscale Ë obbligatorio. Inserirlo nel modulo Anagrafica.";
                        errfield = "cf";
                        return false;
                    }
                    //Vedi task 4830
                    //if (R["authorizationdate"] == DBNull.Value) {
                    //    errmess = "Per un Dipendente la Data autorizzazione Ë obbligatoria";
                    //    errfield = "authorizationdate";
                    //    return false;
                    //}

                    if (R["idapregistrykind"] == DBNull.Value) {
                        errmess = "Per un Dipendente la Tipologia dell'ente Conferente Ë obbligatorio.";
                        errfield = "idapregistrykind";
                        return false;
                    }

                    if (R["idapactivitykind"] == DBNull.Value) {
                        errmess = "Per un Dipendente l'Oggetto dell'incarico Ë obbligatorio";
                        errfield = "idapactivitykind";
                        return false;
                    }

                    //Controlli sul Conferente del dipendente:

                    //1	Pubblico
                    //2	Privato - persona fisica con CF rilasciato in Italia
                    //3	Privato - persona fisica senza CF rilasciato in Italia
                    //4	Privato - persona giuridica con CF rilasciato in Italia
                    //5	Privato - persona giuridica senza CF rilasciato in Italia
                    if ((R["idapregistrykind"].ToString() == "1") || (R["idapregistrykind"].ToString() == "4") || (R["idapregistrykind"].ToString() == "5")) {
                        //Persona giuridica
                        if (R["pa_title"] == DBNull.Value) {
                            errmess = "Per un Dipendente la Denominazione dell'ente Conferente Ë obbligatoria. Inserirlo nel modulo Anagrafica.";
                            errfield = "pa_title";
                            return false;
                        }
                        if ((R["conferring_flagforeign"].ToString().ToUpper() != "S") && (R["conferring_codcity"] == DBNull.Value)) {
                            errmess = "Per Conferente/Persona Giuridica (non estero) il Codice Comune Sede Ë obbligatorio";
                            errfield = "title";
                            return false;
                        }
                    }
                    if ((R["idapregistrykind"].ToString() == "1") || (R["idapregistrykind"].ToString() == "2") || (R["idapregistrykind"].ToString() == "4")) {
                        if (R["pa_cf"] == DBNull.Value) {
                            errmess = "E' necessario specificare il Codice Fiscale dell'Ente Conferente";
                            errfield = "pa_cf";
                            return false;
                        }

                    }
                    if ((R["idapregistrykind"].ToString() == "2") || (R["idapregistrykind"].ToString() == "3")) {
                        if (R["conferring_surname"] == DBNull.Value) {
                            errmess = "Per un Conferente/Persona fisica il Cognome Ë obbligatorio. Inserirlo nel modulo Anagrafica.";
                            errfield = "conferring_surname";
                            return false;
                        }
                        if (R["conferring_forename"] == DBNull.Value) {
                            errmess = "Per un Conferente/Persona fisica il Nome Ë obbligatorio. Inserirlo nel modulo Anagrafica.";
                            errfield = "conferring_forename";
                            return false;
                        }
                        if (R["conferring_birthdate"] == DBNull.Value) {
                            errmess = "Per un Conferente/Persona fisica la Data di nascita Ë obbligatoria. Inserirla nel modulo Anagrafica.";
                            errfield = "conferring_birthdate";
                            return false;
                        }
                        if (R["conferring_flagforeign"] == DBNull.Value) {
                            errmess = "Per un Conferente/Persona fisica Ë necessario specificare se Estero o meno.";
                            errfield = "conferring_flagforeign";
                            return false;
                        }
                        if (R["conferring_gender"] == DBNull.Value) {
                            errmess = "Per un Conferente/Persona fisica Ë necessario specificare il sesso. Inserirlo nel modulo Anagrafica.";
                            errfield = "conferring_gender";
                            return false;
                        }
                    }

                }//Fine dipendenti
                // x entrambi

                if (R["rulespecifics"].ToString().ToUpper() == "S") {
                    if (R["idreferencerule"] == DBNull.Value) {
                        errmess = "E' necessario specificare il Riferimento Normativo";
                        errfield = "idreferencerule";
                        return false;
                    }
                    if (R["articlenumber"] == DBNull.Value) {
                        errmess = "E' necessario specificare il numero dell'articolo del Riferimento Normativo";
                        errfield = "articlenumber";
                        return false;
                    }

                    if (R["referencedate"] == DBNull.Value) {
                        errmess = "E' necessario specificare la data del Riferimento Normativo";
                        errfield = "referencedate";
                        return false;
                    }

                    if (R["article"] == DBNull.Value) {
                        errmess = "E' necessario specificare l'Articolo del Riferimento Normativo";
                        errfield = "article";
                        return false;
                    }
                }
                //Solo per i Dipendenti la data inizio Ë obbligatoria, per i consulente Ë stata resa facoltativa in seguito al task 4872.
                if ((R["employkind"].ToString().ToUpper() == "D") && (R["start"] == DBNull.Value)) {
                    errmess = "E' necessario specificare la Data inizio";
                    errfield = "start";
                    return false;
                }
                if (R["stop"] != DBNull.Value && R["start"] != DBNull.Value) {
                    DateTime dataInizio = (DateTime)R["start"];
                    DateTime dataFine = (DateTime)R["stop"];
                    if (dataInizio > dataFine) {
                        errmess = "La data di fine deve essere identica o successiva a quella di inizio";
                        errfield = "stop";
                        return false;
                    }
                }

                if (R["pa_code"] == DBNull.Value) {
                    errmess = "E' necessario specificare il Codice Ente. Andare in Compensi - Anagrafe delle Prestazioni - Ente";
                    errfield = "pa_code";
                    return false;
                }
                // Data autorizzazione o data affidamento devono essere precedenti o uguali alla data inizio.
                if ((R["authorizationdate"] != DBNull.Value) && (R["start"] != DBNull.Value)) {
                    DateTime dataInizio = (DateTime)R["start"];
                    DateTime dataAutorizzazione = (DateTime)R["authorizationdate"];
                    if (dataAutorizzazione > dataInizio) {
                        errmess = "La Data Conferimento/Autorizzazione deve essere precedente o uguale alla Data inizio.";
                        errfield = "stop";
                        return false;
                    }
                }
                if ((R["expectationsdate"] != DBNull.Value) && (R["start"] != DBNull.Value)) {
                    DateTime dataInizio = (DateTime)R["start"];
                    DateTime dataAutorizzazione = (DateTime)R["expectationsdate"];
                    if (dataAutorizzazione > dataInizio) {
                        errmess = "La Data Affidamento deve essere precedente o uguale alla Data inizio.";
                        errfield = "stop";
                        return false;
                    }
                }
            }//Fine controllo sulla trasmissione

            if (topublish == "S") {
                if ((R["employkind"].ToString().ToUpper() == "D") && (R["description"] == DBNull.Value)) {
                    errmess = "Per un Dipendente Ë obbligatorio specificare la descrizione dell'incarico, per la pubblicazione dei dati sul sito Web Istituzionale"; ;
                    errfield = "description";
                    return false;
                }
                DataTable Tserviceregistrykind = Conn.RUN_SELECT("serviceregistrykind", "*", null, QHS.CmpEq("idserviceregistrykind", R["idserviceregistrykind"]), null, true);

                byte flagconferringstructure = 0;
                flagconferringstructure = CfgFn.GetNoNullByte(Tserviceregistrykind.Rows[0]["flagconferringstructure"]);
                if (((flagconferringstructure & 2) != 0) && (R["conferringstructure"] == DBNull.Value)) {
                    errmess = "E' necessario specificare la Struttura Conferente,  per la pubblicazione dei dati sul sito Web Istituzionale";
                    errfield = "conferringstructure";
                    return false;
                }

                byte flagordinancelink = 0;
                flagordinancelink = CfgFn.GetNoNullByte(Tserviceregistrykind.Rows[0]["flagordinancelink"]);
                if (((flagordinancelink & 2) != 0) && (R["ordinancelink"] == DBNull.Value)) {
                    errmess = "E' necessario specificare il Link al decreto di conferimento dellíincarico,  per la pubblicazione dei dati sul sito Web Istituzionale";
                    errfield = "ordinancelink";
                    return false;
                }

                byte flagauthorizingstructure = 0;
                flagauthorizingstructure = CfgFn.GetNoNullByte(Tserviceregistrykind.Rows[0]["flagauthorizingstructure"]);
                if (((flagauthorizingstructure & 2) != 0) && (R["authorizingstructure"] == DBNull.Value)) {
                    errmess = "E' necessario specificare la Struttura che autorizza,  per la pubblicazione dei dati sul sito Web Istituzionale";
                    errfield = "authorizingstructure";
                    return false;
                }

                byte flagauthorizinglink = 0;
                flagauthorizinglink = CfgFn.GetNoNullByte(Tserviceregistrykind.Rows[0]["flagauthorizinglink"]);
                if (((flagauthorizinglink & 2) != 0) && (R["authorizinglink"] == DBNull.Value)) {
                    errmess = "E' necessario specificare il Link allíatto di autorizzazione,  per la pubblicazione dei dati sul sito Web Istituzionale";
                    errfield = "authorizinglink";
                    return false;
                }

                byte flagactreference = 0;
                flagactreference = CfgFn.GetNoNullByte(Tserviceregistrykind.Rows[0]["flagactreference"]);
                if (((flagactreference & 2) != 0) && (R["actreference"] == DBNull.Value)) {
                    errmess = "E' necessario specificare il Riferimento dellíatto di conferimento,  per la pubblicazione dei dati sul sito Web Istituzionale";
                    errfield = "actreference";
                    return false;
                }

                byte flagannouncementlink = 0;
                flagannouncementlink = CfgFn.GetNoNullByte(Tserviceregistrykind.Rows[0]["flagannouncementlink"]);
                if (((flagannouncementlink & 2) != 0) && (R["announcementlink"] == DBNull.Value)) {
                    errmess = "E' necessario specificare il Link al bando,  per la pubblicazione dei dati sul sito Web Istituzionale";
                    errfield = "announcementlink";
                    return false;
                }
                byte flagotherservice = 0;
                flagotherservice = CfgFn.GetNoNullByte(Tserviceregistrykind.Rows[0]["flagotherservice"]);
                if (((flagotherservice & 2) != 0) && (R["otherservice"] == DBNull.Value)) {
                    errmess = "E' necessario specificare Altri incarichi o cariche in enti di diritto privato finanziati da P.A.,  per la pubblicazione dei dati sul sito Web Istituzionale";
                    errfield = "otherservice";
                    return false;
                }
                byte flagprofessionalservice = 0;
                flagprofessionalservice = CfgFn.GetNoNullByte(Tserviceregistrykind.Rows[0]["flagprofessionalservice"]);
                if (((flagprofessionalservice & 2) != 0) && (R["professionalservice"] == DBNull.Value)) {
                    errmess = "E' necessario specificare Eventuali attivit‡ professionali per la pubblicazione dei dati sul sito Web Istituzionale";
                    errfield = "professionalservice";
                    return false;
                }

                byte flagcomponentsvariable = 0;
                flagcomponentsvariable = CfgFn.GetNoNullByte(Tserviceregistrykind.Rows[0]["flagcomponentsvariable"]);
                if (((flagcomponentsvariable & 2) != 0) && (R["componentsvariable"] == DBNull.Value)) {
                    errmess = "E' necessario specificare le eventuali componenti variabili del compenso per la pubblicazione dei dati sul sito Web Istituzionale";
                    errfield = "componentsvariable";
                    return false;
                }

                byte flagemploytime = 0;
                flagemploytime = CfgFn.GetNoNullByte(Tserviceregistrykind.Rows[0]["flagemploytime"]);
                if (((flagemploytime & 2) != 0) && (R["employtime"] == DBNull.Value)) {
                    errmess = "E' necessario specificare la Durata incarica per la pubblicazione dei dati sul sito Web Istituzionale";
                    errfield = "employtime";
                    return false;
                }
                byte flagcertinterestconflicts = 0;
                flagcertinterestconflicts = CfgFn.GetNoNullByte(Tserviceregistrykind.Rows[0]["flagcertinterestconflicts"]);
                if (((flagcertinterestconflicts & 2) != 0) && (R["certinterestconflicts"] == DBNull.Value)) {
                    errmess = "E' necessario specificare l' Attestazione conflitti di interesse per la pubblicazione dei dati sul sito Web Istituzionale";
                    errfield = "certinterestconflicts";
                    return false;
                }
                //Vedi task 4830
                //if (R["authorizationdate"] == DBNull.Value) {
                //    errmess = "Inserire la Data autorizzazione per la pubblicazione dei dati.";
                //    errfield = "authorizationdate";
                //    return false;
                //}
                if (R["idapactivitykind"] == DBNull.Value) {
                    errmess = "Inserire l'Oggetto dell'incarico per la pubblicazione dei dati sul sito Web Istituzionale.";
                    errfield = "idapactivitykind";
                    return false;
                }
                //Vedi task 4828
                //if (R["expectationsdate"] == DBNull.Value) {
                //    errmess = "Inserire la Data Affidamento incarico per la publicazione dei dati.";
                //    errfield = "expectationsdate";
                //    return false;
                //}

                //task 6234: si richiede che il controllo non scatti per dipendenti dello stesso ente
                if (R["idapcontractkind"] == DBNull.Value && (R["employkind"].ToString().ToUpper() != "D")) {
                    errmess = "Specificare il Tipo Rapporto per la pubblicazione dei dati sul sito Web Istituzionale.";
                    errfield = "idapcontractkind";
                    return false;
                }
            }//fine pubblicazione

            return true;
        }//IsValid

    }



}
