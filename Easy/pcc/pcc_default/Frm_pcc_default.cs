
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
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using metadatalibrary;
using funzioni_configurazione;
using metaeasylibrary;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Xsl;
using System.IO;
using System.Threading;
using System.Diagnostics;
using System.Security;
using System.Globalization;
using System.Data.OleDb;
using System.Collections;
using CsvHelper;
using System.Linq;

namespace pcc_default {
    public partial class Frm_pcc_default : MetaDataForm {
        private MetaData Meta;
        private DataAccess Conn;
        string CFTrasmittente = "";
        private object idreg = DBNull.Value;
        //private string cartellaFile = "";
        private string NomeCompletoFileCSV = "";
        public IOpenFileDialog openFileDialog1;
        public ISaveFileDialog saveFileDialog1;
        public IFolderBrowserDialog folderBrowserDialog1;

        public Frm_pcc_default() {
            InitializeComponent();
            QueryCreator.SetTableForPosting(DS.pccsendview, "pccsend");
            QueryCreator.SetTableForPosting(DS.pccexpenseview, "pccexpense");
            QueryCreator.SetTableForPosting(DS.pccpaymentview, "pccpayment");
            QueryCreator.SetTableForPosting(DS.pccexpiringview, "pccexpiring");
            QueryCreator.SetTableForPosting(DS.pccdocamountvarview, "pccdocamountvar");
            QueryCreator.SetTableForPosting(DS.pccsplitpaymentview, "pccsplitpayment");
            openFileDialog1 = createOpenFileDialog(_openFileDialog1);
            saveFileDialog1 = createSaveFileDialog(_saveFileDialog1);
            folderBrowserDialog1 = createFolderBrowserDialog(_folderBrowserDialog1);
        }

        //DataAccess Conn;
        QueryHelper QHS;
        CQueryHelper QHC;
        public void MetaData_AfterLink() {
            QueryCreator.SetTableForPosting(DS.pccsendview, "pccsend");
            QueryCreator.SetTableForPosting(DS.pccexpenseview, "pccexpense");
            QueryCreator.SetTableForPosting(DS.pccpaymentview, "pccpayment");
            QueryCreator.SetTableForPosting(DS.pccexpiringview, "pccexpiring");
            QueryCreator.SetTableForPosting(DS.pccdocamountvarview, "pccdocamountvar");
            QueryCreator.SetTableForPosting(DS.pccsplitpaymentview, "pccsplitpayment");
            Meta = MetaData.GetMetaData(this);
            Conn = Meta.Conn;
            QHS = Meta.Conn.GetQueryHelper();
            QHC = new CQueryHelper();
            Meta.SearchEnabled = true;
            Meta.CanInsertCopy = false;
            Meta.CanInsert = false;
            Meta.CanCancel = true;

            DataAccess.SetTableForReading(DS.sorting01, "sorting");
            DataAccess.SetTableForReading(DS.sorting02, "sorting");
            DataAccess.SetTableForReading(DS.sorting03, "sorting");
            DataAccess.SetTableForReading(DS.sorting04, "sorting");
            DataAccess.SetTableForReading(DS.sorting05, "sorting");

            DataTable tUniConfig = Conn.RUN_SELECT("uniconfig", "*", null,
                                                   null, null, null, true);
            if ((tUniConfig != null) && (tUniConfig.Rows.Count > 0)) {
                DataRow r = tUniConfig.Rows[0];
                object idsorkind1 = r["idsorkind01"];
                object idsorkind2 = r["idsorkind02"];
                object idsorkind3 = r["idsorkind03"];
                object idsorkind4 = r["idsorkind04"];
                object idsorkind5 = r["idsorkind05"];
                CfgFn.SetGBoxClass0(this, 1, idsorkind1);
                CfgFn.SetGBoxClass0(this, 2, idsorkind2);
                CfgFn.SetGBoxClass0(this, 3, idsorkind3);
                CfgFn.SetGBoxClass0(this, 4, idsorkind4);
                CfgFn.SetGBoxClass0(this, 5, idsorkind5);
                if (idsorkind1 == DBNull.Value && idsorkind2 == DBNull.Value &&
                    idsorkind3 == DBNull.Value && idsorkind4 == DBNull.Value && idsorkind5 == DBNull.Value) {
                    tabControl1.TabPages.Remove(tabAttributi);
                }
            }
        }

        public void MetaData_AfterClear() {
            txtFilename.Enabled = true;
            txtPercorso.Clear();
            btnImportaFileEsito.Enabled = false;
            labelEsito.Text = "Importazione del file di esito";
        }
        public void ValorizzaLabelImportazione() {
            string kindDate = getTipoFile();
            switch (kindDate) {
                case "P": labelEsito.Text = "Importazione del file di esito PAGAMENTI";
                    break;
                case "O": labelEsito.Text = "Importazione del file di esito OPERAZIONI: SID - MI - CS";
                    break;
                default:
                    labelEsito.Text = "Importazione del file di esito";
                    break;
            }
        }

        public void MetaData_AfterFill() {
            txtFilename.Enabled = false;
            btnImportaFileEsito.Enabled = Meta.EditMode;
            ValorizzaLabelImportazione();
        }

        DataTable Tpccsend = null;
        DataTable Tpccsendoperation = null;
        //string tipoGenerazione = "X";
        private void RigeneraFile(bool importazione) {
            if (Meta.IsEmpty)
                return;
            if (importazione) {
                // In caso di importazione prende un idreg fittizio
                DataTable tLicense = Conn.RUN_SELECT("license", "*", null, null, null, null, true);
                DataRow rLicense = tLicense.Rows[0];
                object cf = rLicense["cf"];
                object p_iva = rLicense["p_iva"];
                string filterAll = QHS.DoPar(QHS.AppOr(QHS.CmpEq("cf", cf), QHS.CmpEq("p_iva", p_iva)));
                string script = "select top 1 idreg from registry " +
                                " where " + filterAll;
                DataTable tRegistry = Conn.SQLRunner(script, true);
                if (tRegistry == null || tRegistry.Rows.Count == 0) {
                    show(this, "Non è stato trovata una Angrafica con CF o P.iva, uguali a quelli indicati nella licenza");
                    return;
                }
                idreg = tRegistry.Rows[0]["idreg"];
            }
            else {
                //In caso di vera generazione file, deve prendere l'anagrafica indicata dall'utente
                if (txtAnagrafica.Text != "") {
                    string filteridreg = QHS.AppAnd(QHS.CmpEq("title", txtAnagrafica.Text), QHS.CmpEq("active", "S"));
                    DataAccess.RUN_SELECT_INTO_TABLE(Meta.Conn, DS.registry, null, filteridreg, null, true);
                    idreg = DS.registry.Rows[0]["idreg"];
                }
                else {
                    show(this, "Selezionare il Responsabile");
                    return;
                }

                if (txtPercorso.Text == "") {
                    show(this, "Occorre specificare la cartella in cui salvare il file", "errore");
                    return;
                }
            }
            DataRow Curr = DS.pcc.Rows[0];
            object idpcc = Curr["idpcc"];
            object[] param = new object[] { idpcc };
            if (DS.pccsendview.Rows.Count > 0) {
                DataSet DSpccsend = Conn.CallSP("compute_resendpccsend", param, true, 900);
                if (DSpccsend == null || DSpccsend.Tables.Count == 0)
                    return;
                Tpccsend = DSpccsend.Tables[0];
            }
            else {
                if (DS.pccpaymentview.Rows.Count > 0) {
                    DataSet DSpccsendOperation = Conn.CallSP("compute_resendpccoperation_pagamenti", param, true, 900);
                    if (DSpccsendOperation == null || DSpccsendOperation.Tables.Count == 0)
                        return;
                    Tpccsendoperation = DSpccsendOperation.Tables[0];
                }
                else {
                    DataSet DSpccsendOperation = Conn.CallSP("compute_resendpccoperation_sdi", param, true, 900);
                    if (DSpccsendOperation == null || DSpccsendOperation.Tables.Count == 0)
                        return;
                    Tpccsendoperation = DSpccsendOperation.Tables[0];
                }
            }
            if (!importazione) {
                //Solo in caso di vera rigenerazione deve generare il file e scriverlo sul db, se siamo in fase di importazione ci servono solo i DataTale Tpccsend o Tpccsendoperation
                GeneraFile();
                ScriviFileNelDB(NomeCompletoFileCSV);
            }
        }

        private void RigeneraFileNuovaVersione(bool importazione) {
            if (Meta.IsEmpty)
                return;
            if (importazione) {
                // In caso di importazione prende un idreg fittizio
                DataTable tLicense = Conn.RUN_SELECT("license", "*", null, null, null, null, true);
                DataRow rLicense = tLicense.Rows[0];
                object cf = rLicense["cf"];
                object p_iva = rLicense["p_iva"];
                string filterAll = QHS.DoPar(QHS.AppOr(QHS.CmpEq("cf", cf), QHS.CmpEq("p_iva", p_iva)));
                string script = "select top 1 idreg from registry " +
                                " where " + filterAll;
                DataTable tRegistry = Conn.SQLRunner(script, true);
                if (tRegistry == null || tRegistry.Rows.Count == 0) {
                    show(this, "Non è stato trovata una Angrafica con CF o P.iva, uguali a quelli indicati nella licenza");
                    return;
                }
                idreg = tRegistry.Rows[0]["idreg"];
            }
            else {
                //In caso di vera generazione file, deve prendere l'anagrafica indicata dall'utente
                if (txtAnagrafica.Text != "") {
                    string filteridreg = QHS.AppAnd(QHS.CmpEq("title", txtAnagrafica.Text), QHS.CmpEq("active", "S"));
                    DataAccess.RUN_SELECT_INTO_TABLE(Meta.Conn, DS.registry, null, filteridreg, null, true);
                    idreg = DS.registry.Rows[0]["idreg"];
                }
                else {
                    show(this, "Selezionare il Responsabile");
                    return;
                }

                if (txtPercorso.Text == "") {
                    show(this, "Occorre specificare la cartella in cui salvare il file", "errore");
                    return;
                }
            }
            DataRow Curr = DS.pcc.Rows[0];
            object idpcc = Curr["idpcc"];
            object[] param = new object[] { idpcc };
            if (DS.pccsendview.Rows.Count > 0) {
                DataSet DSpccsend = null;// Conn.CallSP("compute_resendpccsend", param, true, 900);
                if (DSpccsend == null || DSpccsend.Tables.Count == 0)
                    return;
                Tpccsend = DSpccsend.Tables[0];
            }
            else {
                if (DS.pccpaymentview.Rows.Count > 0) {
                    DataSet DSpccsendOperation = Conn.CallSP("compute_resendpccoperation_pagamenti", param, true, 900);
                    if (DSpccsendOperation == null || DSpccsendOperation.Tables.Count == 0)
                        return;
                    Tpccsendoperation = DSpccsendOperation.Tables[0];
                }
                else {
                    DataSet DSpccsendOperation = Conn.CallSP("compute_resendpccoperation_sdi", param, true, 900);
                    if (DSpccsendOperation == null || DSpccsendOperation.Tables.Count == 0)
                        return;
                    Tpccsendoperation = DSpccsendOperation.Tables[0];
                }
            }
            if (!importazione) {
                //Solo in caso di vera rigenerazione deve generare il file e scriverlo sul db, se siamo in fase di importazione ci servono solo i DataTale Tpccsend o Tpccsendoperation
                GeneraFile();
                ScriviFileNelDB(NomeCompletoFileCSV);
            }
        }

        string getTipoFile() {
            if (DS.pccsendview.Rows.Count > 0) return "I";
            if (DS.pccpaymentview.Rows.Count > 0) return "P";
            if ((DS.pccdocamountvarview.Rows.Count > 0)|| (DS.pccsplitpaymentview.Rows.Count > 0)|| (DS.pccexpiringview.Rows.Count > 0)) return "O";
            return "X";
        }
        private void btnRigeneraFile_Click(object sender, EventArgs e) {
            RigeneraFile(false);
        }


        public string MyDataTableToCSV(string kind, System.Data.DataTable DT, bool Header) {
            if (DT.Rows.Count == 0)
                return "";
            string separator = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ListSeparator;

            DataRow[] Rows = DT.Select(null,
                (string)DT.ExtendedProperties["ExcelSort"]);

            string crlf = "\r\n";
            StringBuilder SB = new StringBuilder();
            string Intestazione = ScriviIntestazione(kind);
            SB.Append(Intestazione);

            //string variabileHeader = "";
            //if (Header) {
            //    foreach (DataColumn C in DT.Columns) {
            //        variabileHeader = C.ColumnName.ToString();
            //        SB.Append(variabileHeader + separator);
            //    }
            //    SB.Append(crlf);
            //}

            string variabile = "";
            foreach (DataRow r in DT.Rows) {
                foreach (DataColumn C in DT.Columns) {
                    // quando  lo stato della fattura è diversa da LIQ, LIQDASOSP LIQDANL (ovvero tutti gli stati che determinano la liquidabilità della fattura) 
                    //  la natura della spesa deve essere sovrascritta con il codice NAII  (task 6178)
                    //Cambiate le cose col task 8424: solo per gli stati elencati la natura di spesa va sovrascritta con NA
                    if (DT.Columns.Contains("statodeldebito") && DT.Columns.Contains("naturadispesa_co")) {
                        string statodebito = r["statodeldebito"].ToString();
                        if (C.ColumnName == "naturadispesa_co" && r["naturadispesa_co"].ToString() != "" &&
                             (statodebito == "SOSP" || statodebito == "NOLIQ" || statodebito == "SOSPdaNL" || statodebito == "NLdaSOSP")) {
                            variabile = format("NA");
                            SB.Append(variabile + separator);
                            continue;
                        }
                    }

                    //solo per gli stati SOSP e NOLIQ, in fase di prima contabilizzazione, qualora siano valorizzati CIG e CUP, questi devono essere sovrascritti 
                    // con il codice NA  (task 6178)
                    if (DT.Columns.Contains("statodeldebito") && DT.Columns.Contains("codicecig_co") && DT.Columns.Contains("codicecup_co")) {
                        string statodebito = r["statodeldebito"].ToString();
                        if ((C.ColumnName == "codicecig_co" || C.ColumnName == "codicecup_co") && r[C.ColumnName].ToString() != "" &&
                            (statodebito == "SOSP" || statodebito == "NOLIQ")) {
                            variabile = format("NA");
                            SB.Append(variabile + separator);
                            continue;
                        }
                    }


                    if (C.ColumnName == "aliquotaiva") {
                        //se natura non è stringa vuota o è NA, allora non è ammessa l'aliquota
                        if (r["natura"].ToString() != "" && r["natura"].ToString().ToUpper() != "NA") {
                            variabile = format("NA");
                        }
                        else {
                            variabile = format(r[C]);
                        }
                        SB.Append(variabile + separator);
                        continue;
                    }

                    //if (C.ColumnName == "natura") {
                    //    if (r["natura"].ToString() == "" ) {
                    //        variabile = format("NA");
                    //    }
                    //    else {
                    //        variabile = format(r[C]);
                    //    }
                    //    continue;
                    //}

                    variabile = format(r[C]);

                    SB.Append(variabile + separator);
                }
                SB.Append(crlf);
            }
            return SB.ToString();
        }

        private static string FormatData(DateTime Data) {
            return Data.Day.ToString().PadLeft(2, '0') + "/" + Data.Month.ToString().PadLeft(2, '0') + "/" + Data.Year.ToString();
        }
        private static string FormatDecimal(Decimal d) {
            return d.ToString("F2", CultureInfo.InvariantCulture);
        }

        private static string format(object o) {
            if (o == null || o == DBNull.Value)
                return "";
            if (o.GetType() == typeof(DateTime))
                return FormatData((DateTime)o);
            if (o.GetType() == typeof(Decimal))
                return FormatDecimal((Decimal)o);
            string val = o.ToString();
            if (val.IndexOf("\"") >= 0 || val.IndexOf(";") >= 0 || val.IndexOf("\r") >= 0 || val.IndexOf("\n") >= 0) {
                val = "\"" + val.Replace("\"", "\"\"") + "\"";
            }
            return val;
        }

        public string ScriviIntestazione(string kind) {
            //string CFTrasmittente0 = Conn.DO_READ_VALUE("registry", QHS.CmpEq("idreg", idreg), "cf").ToString();
            string valore = "";
            if (kind == "I") {
                valore = "0;0;0;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;" + "\r\n" +
                        "Codice del modello;002 - UTENTE PA - RICEZIONE FATTURE;;i campi contrassegnati da * sono obbligatori;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;" + "\r\n" +
                        "Versione del modello;1;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;" + "\r\n" +
                        "Utente che trasmette il file (Codice Fiscale);" + CFTrasmittente + ";;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;" + "\r\n" +
                        "DATI AMMINISTRAZIONE (SDI 1.4 CessionarioCommittente);;;DATI FORNITORE (SDI 1.2 CedentePrestatore);;;LOTTO;DATI FATTURA;;;;;;;;;;;;;;;;;;;;;;ESITO ELABORAZIONE;;;;;;;;;;;;;;;;;;;;;;" + "\r\n" +
                        "Codice Fiscale* - Specificare il Codice Fiscale della Amministrazione destinataria del documento (SDI 1.4.1.2 CodiceFiscale);Codice Ufficio* - Specificare il Codice Univoco Ufficio di IPA oppure il Codice Ufficio PCC (SDI   1.1.4 CodiceDestinatario);Denominazione Amministrazione* - Specificare la denominazione dell'Amministrazione destinataria del documento (SDI 1.4.1.3 Anagrafica); Codice Fiscale* - Specificare il Codice Fiscale del Fornitore che ha emesso il documento (SDI  1.2.1.2 CodiceFiscale);Id Fiscale IVA* - Specificare il numero di identificazione fiscale ai fini IVA nel formato IT12345678901  (SDI  1.2.1.1 IdFiscaleIVA);Denominazione Fornitore* - Specificare la denominazione del Fornitore che ha emesso il documento (SDI 1.2.1.3 Anagrafica);Descrizione distinta o lotto* - Specificare una descrizione o numero relativo all'invio  (SDI 1.1.2 ProgressivoInvio);DATI GENERALI (SDI 2.1 DatiGenerali);;;;;;;;RIEPILOGO ALIQUOTE (SDI 2.2.2 DatiRiepilogo);;;;DISTRIBUZIONE PER CIG/CUP (SDI 2.2.1 DettaglioLinee);;;DETTAGLIO PAGAMENTO (SDI 2.4.2 DettaglioPagamento);;;;RICEZIONE;;;Forzatura immissione - Consente di specificare l'azione da eseguire nei casi di segnalazione di sospetto duplicato.  AG: Aggiungi la fattura come nuova /  SO: Sovrascivi la fattura già presente;Codice segnalazione;Descrizione segnalazione;;;;;;;;;;;;;;;;;;;;" + "\r\n" +
                        ";;;;;;;Tipo Documento* - Specificare TD01: fattura /  TD02: acconto/anticipo su fattura /  TD03: acconto/anticipo su parcella /  TD04: nota di credito /  TD05: nota di debito /  TD06: parcella (SDI 2.1.1.1 TipoDocumento);Numero fattura* (SDI 2.1.1.4 Numero);Data emissione* (SDI 2.1.1.3 Data);Importo totale documento* (SDI 2.1.1.9 ImportoTotaleDocumento);Descrizione / Causale* (SDI 2.1.1.11 Causale);Art. 73 - Specificare SI  - Documento emesso secondo le modalità stabilite con DM ai sensi dell'art. 73 DPR 633/72 (SDI  2.1.1.12 Art73);Totale imponibile della fattura* (SDI  somma di 2.2.2.5 ImponibileImporto);Totale imposta della fattura* (SDI  somma di 2.2.2.6 Imposta);Aliquota IVA (SDI 2.2.2.1 AliquotaIVA);Codice Esenzione IVA (SDI 2.2.2.2 Natura);Totale Imponibile per aliquota (SDI 2.2.2.5 Imposta);Totale Imposta per aliquota (SDI 2.2.2.6 Imposta);Importo per CIG/CUP (SDI Somma di 2.2.1.11 PrezzoTotale + applicazione 2.2.1.12 AliquotaIVA);Codice CIG - Codice Identificativo della gara (SDI  2.1.2.7 CIG);Codice CUP - Codice Unitario Progetto (SDI 2.1.2.6 CUP);Data riferimento termini di pagamento - Specificare la data dalla quale decorrono i termini di pagamento (SDI 2.4.2.3 DataRiferimentoTerminiPagamento);Giorni termini pagamento - Specificare il numero di giorni entro i quali sarà effettuato il pagamento  (SDI 2.4.2.4 GiorniTerminiPagamento);Data scadenza pagamento (SDI 2.4.2.5 DataScadenzaPagamento);Importo Pagamento (SDI 2.4.2.6 ImportoPagamento);Numero Protocollo in Entrata;Data ricezione - Specificare la data di ricezione da parte della PA. Se omessa, viene assunta come data di ricezione quella in cui viene caricato il file;Note;;;;;;;;;;;;;;;;;;;;;;;" + "\r\n";
            }
            if (kind == "O") {
                valore = 
                    ";;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;" + "\r\n" +
                    "Codice del modello;GESTIONE IMPORTI DOCUMENTI;;i campi contrassegnati da * sono obbligatori;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;" + "\r\n" +
                    "Versione del modello;1;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;" + "\r\n" +
                    "Utente che trasmette il file (Codice Fiscale);" + CFTrasmittente + ";;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;" + "\r\n" +
                    "DATI IDENTIFICATIVI FATTURA*;;;;;;TIPO OPERAZIONE*;VARIAZIONE IMPORTI DOCUMENTI Tutti i campi sono obbligatori Sezione da compilare solo per le righe del modello per le quali Azione = 'SID';;;;;;;;;;REGIME IVA Sezione da compilare solo per le righe del modello per le quali Azione = 'MI';RICEZIONE / RIFIUTO / COMUNICAZIONE SCADENZA Sezione da compilare solo per le righe del modello per le quali Azione = 'RC' Azione = 'RF' Azione = 'CS';;ESITO ELABORAZIONE;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;" + "\r\n" +
                    "IDENTIFICATIVO 1;;IDENTIFICATIVO 3 ;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;" + "\r\n" +
                    "Numero progressivo di registrazione;IDENTIFICATIVO 2 ;;Data documento (SDI 2.1.1.3 Data);Codice fiscale fornitore;Codice ufficio;Azione ;Imponibile;Imposta;Importo non commerciale*;Importo sospeso in Contenzioso*;Data inizio sospesione in Contenzioso*;Importo sospeso in contestazione/adempimenti normativi*;Data inizio sospesione in contestazione /adempimenti normativi*;Importo sospeso per data esito regolare verifica di conformità*;Data inizio sospensione per data esito regolare verifica di conformità*;Importo non liquidabile*;Flag split (S/N);Data;Numero protocollo di entrata;Codice segnalazione;Descrizione segnalazione;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;" + "\r\n" +
                    ";Lotto SDI;Numero fattura(SDI 2.1.1.4 Numero);;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;" + "\r\n" ;
            }
            if (kind == "P") {
                valore =
                    ";;;;;;;;;;;;;;;;;;;;" + "\r\n" +
                    "Codice del modello;GESTIONE PAGAMENTI;;i campi contrassegnati da * sono obbligatori;;;;;;;;;;;;;;;;;" + "\r\n" +
                    "Versione del modello;1;;;;;;;;;;;;;;;;;;;" + "\r\n" +
                    "Utente che trasmette il file (Codice Fiscale);" + CFTrasmittente + ";;;;;;;;;;;;;;;;;;;" + "\r\n" +
                    "DATI IDENTIFICATIVI DOCUMENTO* ;;;;;;TIPO OPERAZIONE;DATI PAGAMENTO;;;;;;;;;;;;ESITO ELABORAZIONE;" + "\r\n" +
                    "IDENTIFICATIVO 1;;IDENTIFICATIVO 3 ;;;;;;;;;;;;;;;;;;" + "\r\n" +
                    "Numero progressivo di registrazione;IDENTIFICATIVO 2 ;;Data documento (SDI 2.1.1.3 Data);Codice fiscale fornitore;Codice ufficio;Azione ;Id pagamento(Per nuovo pagamento non compilare il campo);Tipo debito(C = Commerciale / NC = Non Commerciale);Importo pagato;Natura di spesa;Mandato di pagamento;;Id fiscale IVA del beneficiario;Codice CIG;Codice CUP;Pagamento OPI S/N;Pagamento IVA S/N;Giorni di sospensione effettivi;Codice segnalazione;Descrizione segnalazione" + "\r\n" +
                    ";Lotto SDI;Numero documento(SDI 2.1.1.4 Numero);;;;;;;;;Numero;Data;;;;;;;;" + "\r\n";
            }
            return valore;
        }

        private void GeneraFile(string fileName = null) {
            // Crea il file .CSV contenente le fatture/contratti da trasmettere
            DataTable DT = null;
            if (getTipoFile() == "I") {
                DT = Tpccsend;
            }
            else {
                DT = Tpccsendoperation;
            }

            //  FGTFRT76S26H501J_YYYYMMGG.CSV
            string DataNow = DateTime.Now.Millisecond.ToString(); // .ToString("yyyyMMdd");non va bene se in un gg generano 2 file

            CFTrasmittente = Conn.DO_READ_VALUE("registry", QHS.CmpEq("idreg", idreg), "cf").ToString();
            string suffisso = getTipoFile();
            string NomeFile = CFTrasmittente + "_" + DataNow + suffisso + ".csv";
            NomeCompletoFileCSV = Path.Combine(txtPercorso.Text, NomeFile);
            string completename = NomeCompletoFileCSV;
            if (fileName != null) completename = fileName;
            //try {
            //    File.Copy(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, NomeFile), completename, true);
            //}
            //catch (Exception ex) {
            //}
            //txtPercorso.Text = NomeCompletoFileCSV;
            
            try {
                string S = MyDataTableToCSV(suffisso, DT, false);// il secondo parametro è l'header, ma impostato a false
                StreamWriter SWR = new StreamWriter(completename, false, Encoding.Default);
                SWR.Write(S);
                SWR.Close();
                SWR.Dispose();
                txtFilename.Text = NomeFile;
                show(this, "File salvato in " + completename);
            }
            catch (Exception E) {
                QueryCreator.ShowException(E);
            }

        }

        private void ScriviFileNelDB(string fileName) {
            DataRow Curr = DS.pcc.Rows[0];

            FileStream FS = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            int n = (int)FS.Length;
            if (n == 0) {
                return;
            }
            byte[] ByteArray = new byte[n];
            FS.Read(ByteArray, 0, n);

            FS.Close();
            Curr["attachment"] = ByteArray;
            Curr["filename"] = txtFilename.Text;
            Meta.SaveFormData();
        }

        private void faiScegliereCartella() {
            DialogResult dr = folderBrowserDialog1.ShowDialog(this);
            if (dr == DialogResult.OK) {
                txtPercorso.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void btnCartella_Click(object sender, EventArgs e) {
            txtPercorso.Text = "";
            faiScegliereCartella();
            if (txtPercorso.Text == "") {
                show(this, "Occorre specificare la cartella in cui salvare il file", "errore");
                return;
            }
        }
        private string TipoOperazione(DataTable T) {
            //return "O";//Per il momento sarà solo O
            //Prendiamo la prima riga con i dati
            if (T == null) return "";
            DataRow R = T.Rows[0];
            string colonnaC = R[6].ToString();
            if (colonnaC=="IP") {
                //Azione =IP, quindi Pagamento
                return "P";
            }
            if (colonnaC=="SID" || colonnaC == "MI"|| colonnaC == "CS") {
                //è una operazione sul documento
                return "O";
            }

            return "I";
        }

        private void AssociaNomiAColonne(DataTable tTrasmesso, DataTable tEsito) {
            //Attribuisce dei nomi alle colonne
            int ncol = tTrasmesso.Columns.Count;
            for (int i = 0; i < ncol; i++) {
                tTrasmesso.Columns[i].ColumnName = tEsito.Columns[i].ColumnName;
            }
        }

        bool allNumeric(string s) {
            for (int i = 0; i < s.Length; i++) {
                if (!Char.IsDigit(s[i])) return false;
            }
            return true;
        }
        string removeZero(string s) {
            if (!s.StartsWith("0")) return s;
            if (!allNumeric(s)) return s;
            int i = 0;
            while (i < s.Length - 1) {
                if (s[i] != '0') break;
                i++;
            }
            return s.Substring(i);
        }


        bool isNumberEqual(string s1, string s2) {
            return removeZero(s1).ToLower() != removeZero(s2).ToLower();
        }

        int indexOfDataRow(DataRow r) {
            DataTable t = r.Table;
            for (int i = 0; i < t.Rows.Count; i++) {
                if (t.Rows[i] == r) return i;
            }
            return -1;
        }


        class campiSkeleton :IEquatable<campiSkeleton> {
            string standardize(string S) {
                return S.Trim().ToLowerInvariant().Replace("\n", "").Replace("\r", "");
            }

            public Dictionary<string, object> campi = new Dictionary<string, object>();
            public campiSkeleton(DataRow r) {
                //Riempie il dictionary a partire da r eventualmente facendo i round, trim, e lower del caso per rendere omogenea la struttura risultante
                //Per esempio (due campi a caso, non è importante il nome che si da al campo basta che sono tra loro diversi)
                campi["IDENTIFICATIVO_1"] = standardize(r[0].ToString());
                campi["IDENTIFICATIVO_2_a"] = standardize(r[1].ToString());
                campi["IDENTIFICATIVO_2_b"] = standardize(r[2].ToString());
                campi["IDENTIFICATIVO_3_a"] = (r[3].ToString() == "") ? standardize(r[3].ToString()) : FormatData((DateTime)r[3]);
                campi["IDENTIFICATIVO_3_b"] = standardize(r[4].ToString());
                campi["IDENTIFICATIVO_3_c"] = standardize(r[5].ToString());
                campi["azione"] = standardize(r[6].ToString());
            }

            public bool Equals(campiSkeleton c) {
                foreach (string key in c.campi.Keys) {
                    if (!campi.ContainsKey(key)) return false;
                    if (!c.campi[key].Equals(campi[key])) return false;
                }
                foreach (string key in campi.Keys) {
                    if (!c.campi.ContainsKey(key)) return false;
                }
                return true;
            }
        }

        class skeletonCompare {
            Dictionary<campiSkeleton, int> skeleton = new Dictionary<campiSkeleton, int>();

            void updateCampiSkeleton(DataRow r, int value) {
                campiSkeleton c = new campiSkeleton(r);

                foreach (campiSkeleton k in skeleton.Keys) {
                    if (c.Equals(k)) {
                        skeleton[k] += value;
                        return;
                    }
                }
                skeleton[c] = value;
            }

            public void loadSource(DataRow r) {
                updateCampiSkeleton(r, 1);
            }

            public void loadDest(DataRow r) {
                updateCampiSkeleton(r, -1);
            }

            public bool equal() {
                int errorFound = 0;
                foreach (campiSkeleton c in skeleton.Keys) {
                    if (skeleton[c] != 0) {
                        string location = skeleton[c] > 0 ? "Riga trasmessa" : "Riga di Esito";
                        string elencocampi =
                                "\n IDENTIFICATIVO 1 (colonna A): " + c.campi["IDENTIFICATIVO_1"].ToString().ToUpperInvariant()
                                + "\n IDENTIFICATIVO 2a (colonna B): " + c.campi["IDENTIFICATIVO_2_a"].ToString().ToUpperInvariant()
                                + "\n IDENTIFICATIVO 2b (colonna C): " + c.campi["IDENTIFICATIVO_2_b"].ToString().ToUpperInvariant()
                                + "\n IDENTIFICATIVO 3a (colonna D): " + c.campi["IDENTIFICATIVO_3_a"].ToString().ToUpperInvariant()
                                + "\n IDENTIFICATIVO 3b (colonna E): " + c.campi["IDENTIFICATIVO_3_b"].ToString().ToUpperInvariant()
                                + "\n IDENTIFICATIVO 3c (colonna F): " + c.campi["IDENTIFICATIVO_3_c"].ToString().ToUpperInvariant()
                                + "\n Tipo Operazione (col. G): " + c.campi["azione"].ToString().ToUpperInvariant()
                                ;
                        //show($"Riscontrate differenze tra il file generato e il file importato. \r\n{location} non trovata :" + elencocampi, "Elenco campi");
                        errorFound++;
                        //if (errorFound>10)break;
                    }
                }
                return errorFound == 0;
            }
        }

        private bool IsFileEqual(DataTable tTrasmesso, DataTable tEsito) {
            skeletonCompare sComp = new skeletonCompare();
            foreach (DataRow r in tTrasmesso.Rows) {
                sComp.loadSource(r);
            }
            foreach (DataRow r in tEsito.Rows) {
                sComp.loadDest(r);
            }
            return sComp.equal();
        }
        private void btnImportaFileEsito_Click(object sender, EventArgs e) {
            if (DS.HasChanges()) {
                show("E' necessario salvare prima di importare un file", "Avviso");
                return;
            }
            DialogResult dr = openFileDialog1.ShowDialog(this);
            if (dr != DialogResult.OK) return;
            RigeneraFileNuovaVersione(true);

            //Da ora in poi lavoreremo con Ttrasmesso
            DataTable tTrasmesso = (getTipoFile() == "I") ? Tpccsend : Tpccsendoperation;
            string fileName = openFileDialog1.FileName;
            string extension = Path.GetExtension(fileName);
            DataTable tEsito = null;
            if (extension.ToLower() == ".csv") {
                tEsito = ReadCurrentSheet(fileName, tTrasmesso, 8, "csv");// Salta le prime 8 righe sia per il .CSV che per l'Excel.
            }
            else {
                if (extension.ToLower() == ".xlsx") {
                    tEsito = ReadCurrentSheet(fileName, tTrasmesso, 8, "xlsx");// >>> come in disposizioni di pagamento
                }
                else {
                    tEsito = ReadCurrentSheet(fileName, tTrasmesso, 8, "excel");// >>> come in disposizioni di pagamento
                }

            }
            try {
                if (File.Exists("imported_temp.xlsx")) {
                    File.Delete("imported_temp.xlsx");
                }
                exportclass.DataTableToExcel(tEsito, true, null, null, "imported_temp.xlsx");
            }
            catch {

            }
            if (tEsito == null) return;
            if (CfgFn.GetNoNullInt32(idreg) == 0)
                return;
            string KindEsito = TipoOperazione(tEsito);
            if (KindEsito != getTipoFile()) {
                //Il file di esito e il file generato contengono operazioni diverse.
                string mess1 = (KindEsito == "I") ? "Invio" : "Operazioni su fatture precaricate";
                string mess2 = (getTipoFile() == "I") ? "Invio" : "Operazioni su fatture precaricate";
                show(this, "Il file di esito contiene: " + mess1 + ", mentre il file trasmesso contiene: " + mess2 + ". Selezionare il file corretto da importare");
                return;
            }

            // Cancella le prime 7 righe di intestazione, sia che sia I sia che sia O => per il .CSV
            // Cancella le prime 6 righe di intestazione, sia che sia I sia che sia O => per il .XLS
            //for (int i = 0; i <= 5; i++) {
            //    tEsito.Rows[i].Delete();
            //}
            tEsito.AcceptChanges();
            foreach (DataColumn c in tEsito.Columns) {
                if (c.DataType == typeof(String)) {
                    foreach (DataRow r in tEsito.Rows) {
                        if (r[c] == DBNull.Value) continue;
                        r[c] = r[c].ToString().Trim();
                    }
                }
            }
            tEsito.AcceptChanges();

            //Ho scritto il contenuto della tabella in un file xml, per vederne il contenuto.
            //string fileTemp = Path.GetTempFileName();
            //StreamWriter sw2 = new StreamWriter(fileTemp, false, System.Text.Encoding.GetEncoding(1252));
            //tEsito.WriteXml(sw2);

            //foreach (DataColumn c in tTrasmesso.Columns) { // SARA
            //    if (c.DataType == typeof(String)) {
            //        foreach (DataRow r in tTrasmesso.Rows) {
            //            if (r[c] == DBNull.Value) continue;
            //            r[c] = removeZero(r[c].ToString().Trim());
            //        }
            //    }
            //}


            tTrasmesso.CaseSensitive = false;
            tEsito.CaseSensitive = false;

            AssociaNomiAColonne(tTrasmesso, tEsito);

            //Controlliamo che i due DataTable siano uguali
            if (!IsFileEqual(tTrasmesso, tEsito)) {
                if (!acceptDiff(tTrasmesso, tEsito))
                    return;
            }

            tTrasmesso.RejectChanges();
            foreach (DataColumn c in DS.pccexpenseview.Columns) {
                c.ReadOnly = false;
                if (c.DataType == typeof(String)) {
                    foreach (DataRow r in DS.pccexpenseview.Rows) {
                        if (r[c] == DBNull.Value) continue;
                        r[c] = r[c].ToString().Trim();
                    }
                }
            }
            DS.pccexpenseview.AcceptChanges();

            //Se siamo arrivati qui, vuol dire che i due file sono uguali, e quindi stiamo importando il file corretto.
            //string colonnaAL = "";//descrizione errore


            //Ora tEsito contiene solo le righe errate, e quindi le fatture scartate.
            //A seconda che si tratti di Invio o CO, COF, CP, CS chiamare un metodo per cancellare dal db la riga relativa.
            // Nella colonna E troviamo il tipo operazione 

            string colonnaG = "";
            for (int i = 0; i < tEsito.Rows.Count; i++) {
                DataRow R = tEsito.Rows[i];
                string colonnaErr = "";
                if (KindEsito == "O") {
                    colonnaErr = R[21].ToString();  //colonna esito file OPERAZIONI
                }if (KindEsito == "P") {
                    colonnaErr = R[19].ToString();  //colonna esito file PAGAMENTO
                }
                if ((colonnaErr == "")|| (colonnaErr == "OK")) {
                    R.Delete();
                    continue;
                }
                colonnaG = R[6].ToString();
				//if ((colonnaG == "CO") || (colonnaG == "COF")) {
				//	// Deve cancellare da pccexpense
				//	if (!CancellazioneRigaPccexpenseEseguita(R)) {
				//		return;//C'è stato un errore e interrompe l'operazione
				//	}
				//}
				if (colonnaG == "CS") {
					// Deve cancellare da pccexpiring
					if (!CancellazioneRigaPccexpiringEseguita(R)) {
						return;
					}
				}
				if (colonnaG == "IP") {
					// Deve cancellare da pccpayment
					if (!CancellazioneRigaPccpaymentEseguita(R)) {
						return;
					}
				}
				if (colonnaG == "SID") {
					// Deve cancellare da pccdocamountvar
					if (!CancellazioneRigaPccdocamountvarEseguita(R)) {
						return;
					}
				}
				if (colonnaG == "MI") {
					// Deve cancellare da pccsplitpayment
					if (!CancellazioneRigaPccsplitpaymentEseguita(R)) {
						return;
					}
				}
			}
			tEsito.AcceptChanges();
            if (tEsito.Rows.Count > 0) {
                MostraOperazionieliminate(tEsito);
            }
			Meta.DoMainCommand("mainsave");
			if (!DS.HasChanges()) {
				show(this, "Salvataggio effettuato correttamente", "Informazione");
			}
		}

        private void MostraOperazionieliminate(DataTable T) {
            ImpostaCaptionDettaglioOp(T);
            DataSet DSunified = new DataSet();
            DSunified.Tables.Add(T);
            FrmDettaglioRisultati X = new FrmDettaglioRisultati(T);
            X.Text = "Operazioni scartate";
            createForm(X, this);
            X.ShowDialog(this);
        }

        bool acceptDiff(DataTable trasmesso, DataTable esito) {
            DataTable myTrasmesso = trasmesso.Copy();
            myTrasmesso.TableName = "trasmesso";
            DataTable myEsito = esito.Copy();
            myEsito.TableName = "esito";
            DataSet d = new DataSet();
            d.Tables.Add(myTrasmesso);
            d.Tables.Add(myEsito);
            ImpostaCaptionDettaglioDiff(myTrasmesso);
            ImpostaCaptionDettaglioDiff(myEsito);

            foreach (var r1 in myTrasmesso.Select()) {
                campiSkeleton s1 = new campiSkeleton(r1);
                foreach (var r2 in myEsito.Select()) {
                    campiSkeleton s2 = new campiSkeleton(r2);
                    if (s1.Equals(s2)) {
                        r1.Delete();
                        r2.Delete();
                        break;
                    }
                }
            }
            myTrasmesso.AcceptChanges();
            myEsito.AcceptChanges();
            frmDifferenze fDiff = new frmDifferenze(myTrasmesso, myEsito);
            createForm(fDiff, this);
            if (fDiff.ShowDialog(this) == DialogResult.OK) {
                return true;
            }
            return false;
        }
        void ImpostaCaptionDettaglioOp(DataTable dt) {
            foreach (DataColumn C in dt.Columns) {
                C.Caption = "";
            }
            dt.Columns["c0"].Caption = "identificativo 1";
            dt.Columns["c1"].Caption = "identificativo 2a";
            dt.Columns["c2"].Caption = "identificativo 2b";
            dt.Columns["c3"].Caption = "identificativo 3a";
            dt.Columns["c4"].Caption = "identificativo 3b";
            dt.Columns["c5"].Caption = "identificativo 3c";
            dt.Columns["c6"].Caption = "azione";
            if ((dt != null) && (dt.Rows[0]["c6"].ToString() == "IP")) {
                dt.Columns["c19"].Caption = "Errore";
                dt.Columns["c20"].Caption = "Descrizione Errore";
            }
            else {
                dt.Columns["c20"].Caption = "Errore";
                dt.Columns["c21"].Caption = "Descrizione Errore";
            }
        }
        void ImpostaCaptionDettaglioDiff(DataTable dt) {
            foreach (DataColumn C in dt.Columns) {
                C.Caption = "";
            }
            dt.Columns["c0"].Caption = "identificativo 1";
            dt.Columns["c1"].Caption = "identificativo 2a";
            dt.Columns["c2"].Caption = "identificativo 2b";
            dt.Columns["c3"].Caption = "identificativo 3a";
            dt.Columns["c4"].Caption = "identificativo 3b";
            dt.Columns["c5"].Caption = "identificativo 3c";
            dt.Columns["c6"].Caption = "azione";
            
        }
        // SID
        private bool CancellazioneRigaPccdocamountvarEseguita(DataRow R) {
            string filtro = "";
            if (R["c1"].ToString() != "") {
                filtro = QHC.AppAnd(QHC.CmpEq("IDENTIFICATIVO_2_a", R["c1"]), QHC.CmpEq("IDENTIFICATIVO_2_b", R["c2"]));
            }
            if (R["c3"].ToString() != "") {
                filtro = QHC.AppAnd(QHC.CmpEq("IDENTIFICATIVO_3_a", R["c3"]), QHC.CmpEq("IDENTIFICATIVO_3_b", R["c4"]), QHC.CmpEq("IDENTIFICATIVO_3_c", R["c5"]));
            }

            string filterAll = QHC.AppAnd(filtro,
            QHC.CmpEq("importononcommerciale", R["c9"]),
            QHC.CmpEq("imp_sosp_contenzioso", R["c10"]),    QHC.CmpEq("start_sosp_contenzioso", R["c11"]),          QHC.CmpEq("imp_sosp_contestazione", R["c12"]),
            QHC.CmpEq("start_sosp_contestazione", R["c13"]),    QHC.CmpEq("imp_sosp_regolareverifica", R["c14"]),   QHC.CmpEq("start_sosp_regolareverifica", R["c15"]),
            QHC.CmpEq("importo_nonliquidabile", R["c16"]));    

            DataRow[] Rows = DS.pccdocamountvarview.Select(filterAll, null);
            // AGGIUNGERE GLI IMPORTI AL MESSAGGIO
            if (Rows.Length == 0) {
                show(this, "Non è stato trovata la riga di operazione SID avente:\r\n" +
                        "Identificativo 2 :" + R["c1"] + " " + R["c2"] + ", \n Identificativo 3:" + R["c3"] + " " + R["c4"] + " " + R["c5"] +
                         ", \nData scadenza " + R["c18"]);
                return false;
            }
            if (Rows.Length > 1) {
                show(this, "Non è stato trovata la riga di operazione SID avente:\r\n" +
                            "Identificativo 2 :" + R["c1"] + " " + R["c2"] + ", \n Identificativo 3:" + R["c3"] + " " + R["c4"] + " " + R["c5"] );
                return false;
            }
            if (Rows.Length == 1) {
                Rows[0].Delete();
            }
            return true;
        }

        private bool CancellazioneRigaPccsplitpaymentEseguita(DataRow R) {
            string filtro = "";
            if (R["c1"].ToString() != "") {
                filtro = QHC.AppAnd(QHC.CmpEq("IDENTIFICATIVO_2_a", R["c1"]), QHC.CmpEq("IDENTIFICATIVO_2_b", R["c2"]));
            }
            if (R["c3"].ToString() != "") {
                filtro = QHC.AppAnd(QHC.CmpEq("IDENTIFICATIVO_3_a", R["c3"]), QHC.CmpEq("IDENTIFICATIVO_3_b", R["c4"]), QHC.CmpEq("IDENTIFICATIVO_3_c", R["c5"]));
            }

            //  17-Split payment   >>>   Sezione Split Payment
            string filterAll = QHC.AppAnd(QHC.CmpEq("flag_enable_split_payment", R["c17"]), filtro);


            DataRow[] Rows = DS.pccsplitpaymentview.Select(filterAll, null);
            if (Rows.Length == 0) {
                show(this, "Non è stato trovata la riga di Split Payment avente:\r\n" +
                        "Identificativo 2 :" + R["c1"] + " " + R["c2"] + ", \n Identificativo 3:" + R["c3"] + " " + R["c4"] + " " + R["c5"] +
                          ", \nFlag split (S/N) " + R["c17"]);
                return false;
            }
            if (Rows.Length > 1) {
                show(this, "Non è stato trovata la riga di Scadenza avente:\r\n" +
                            "Identificativo 2 :" + R["c1"] + " " + R["c2"] + ", \n Identificativo 3:" + R["c3"] + " " + R["c4"] + " " + R["c5"] +
                             ", \nFlag split (S/N) " + R["c17"]);
                return false;
            }
            if (Rows.Length == 1) {
                Rows[0].Delete();
            }
            return true;
        }

        private bool CancellazioneRigaPccexpiringEseguita(DataRow R) {
            string filtro = "";
            if (R["c1"].ToString() != "") {
                filtro = QHC.AppAnd(QHC.CmpEq("IDENTIFICATIVO_2_a", R["c1"]), QHC.CmpEq("IDENTIFICATIVO_2_b", R["c2"]));
            }
            if (R["c3"].ToString() != "") {
                filtro = QHC.AppAnd(QHC.CmpEq("IDENTIFICATIVO_3_a", R["c3"]), QHC.CmpEq("IDENTIFICATIVO_3_b", R["c4"]), QHC.CmpEq("IDENTIFICATIVO_3_c", R["c5"]));
            }
            //  18-data scadenza   >>>   Sezione SCADENZA
            string filterAll = QHC.AppAnd( QHC.CmpEq("expiringdate", R["c18"]), filtro);


            DataRow[] Rows = DS.pccexpiringview.Select(filterAll, null);
            if (Rows.Length == 0) {
                show(this, "Non è stato trovata la riga di Scadenza avente:\r\n" +
                        "Identificativo 2 :" + R["c1"] + " " + R["c2"] + ", \n Identificativo 3:" + R["c3"] +" "+ R["c4"] + " " + R["c5"] + 
                         ", \nData scadenza " + R["c18"]);
                return false;
            }
            if (Rows.Length > 1) {
                show(this, "Non è stato trovata la riga di Scadenza avente:\r\n" +
                            "Identificativo 2 :" + R["c1"] + " " + R["c2"] + ", \n Identificativo 3:" + R["c3"] + " " + R["c4"] + " " + R["c5"] +
                             ", \nData scadenza " + R["c18"]);
                return false;
                            }
            if (Rows.Length == 1) {
                Rows[0].Delete();
            }
            return true;
        }
        private bool CancellazioneRigaPccpaymentEseguita(DataRow R) {
            string filtro = "";
            if (R["c1"].ToString() != "") {
                filtro = QHC.AppAnd(QHC.CmpEq("IDENTIFICATIVO_2_a", R["c1"]), QHC.CmpEq("IDENTIFICATIVO_2_b", R["c2"]));
            }
            if (R["c3"].ToString() != "") {
                filtro = QHC.AppAnd(QHC.CmpEq("IDENTIFICATIVO_3_a", R["c3"]), QHC.CmpEq("IDENTIFICATIVO_3_b", R["c4"]), QHC.CmpEq("IDENTIFICATIVO_3_c", R["c5"]));
            }
            filtro = QHC.AppAnd(filtro, QHC.CmpEq("npay", R["c11"]), QHC.CmpEq("cigcode", R["c14"]), QHC.CmpEq("cupcode", R["c15"]));

            DataRow[] Rows = DS.pccpaymentview.Select(filtro, null);
            if (Rows.Length == 0) {
                show(this, "Non è stato trovata la riga di Pagamento avente:\r\n" +
                        "Identificativo 2 :" + R["c1"] + " " + R["c2"] + ", \n Identificativo 3:" + R["c3"] + " " + R["c4"] + " " + R["c5"] );
                return false;
            }
            if (Rows.Length > 1) {
                show(this, "Non è stato trovata la riga di Pagamento avente:\r\n" +
                            "Identificativo 2 :" + R["c1"] + " " + R["c2"] + ", \n Identificativo 3:" + R["c3"] + " " + R["c4"] + " " + R["c5"] );
                return false;
            }
            if (Rows.Length == 1) {
                Rows[0].Delete();
            }
            return true;
        }

        private bool CancellazioneRigaPccexpenseEseguita(DataRow R) {
            object p_iva = R["c3"];
            if (p_iva.ToString() == "") p_iva = DBNull.Value;
            //if (p_iva.StartsWith("IT")) {
            //    p_iva = p_iva.Substring(2);
            //}

            string filterNA = null;
            object kindToCompare = R["c15"];
            if (kindToCompare.ToString() != "") {
                //kindToCompare = "NA";
                filterNA = QHC.CmpEq("expensekind", kindToCompare);
            }
            string filtro = QHC.AppAnd(
                //3-IdFiscaleIvaFornitore,2-CFfornitore
                QHC.CmpEq("IdFiscaleIvaFornitore", p_iva), QHC.CmpEq("CFfornitore", R["c2"]),
                //      6-num.fattura, 7-data emissione, 8-Importo tot.doc.,   >>>>>     Sono indentificativi della fattura 
                QHC.CmpEq("numerodocumento", R["c6"]), QHC.CmpEq("dataemissione", (DateTime)R["c7"]), QHC.CmpEq("ImportoTotaleDocumento", CfgFn.GetNoNullDecimal(R["c8"])),
                //     14-Importo del mov., 15-natura, 17-stato del debito, 19-descrizione, 30-num.impegno, 21-cig, 22-cup, >>>>> Sezione CONTABILIZZAZIONE
                //QHC.CmpEq("amount", CfgFn.GetNoNullDecimal(R["c14"])),  Togliamo il confronto con l'importo perchè in fase di trasmissione i dettagli sono stati ragguppati, 
                //per cui può capitare di avere un dettaglio nel file di esito e due o tre dettagli nel DB/pccexpense.
                filterNA,
                //QHC.CmpEq("expensetaxkind", R["c17"]),
                // 18 - Causale
                QHC.CmpEq("motive", R["c18"]), QHC.CmpEq("description", R["c19"]), QHC.CmpEq("nmov", R["c20"]),
                QHC.CmpEq("cigcode", R["c21"]), QHC.CmpEq("cupcode", R["c22"]));

            DataRow[] Rows = DS.pccexpenseview.Select(filtro, null);
            if (Rows.Length == 0) {
                show(this, "Non è stata trovata la riga di Contabilizzazione avente:\r\n" +
                        "P.iva: " + p_iva + ",\nCF:" + R["c2"] + ",\nNum.Documento " + R["c6"] +
                        "\nData emissione:" + R["c7"] +
                        //"\nnatura:"+R["c15"]+"\nstato debito:"+R["c17"]+
                        "\nCausale:" + R["c18"] + "\ncig:" + R["c21"] + "\ncup:" + R["c22"] +
                        ",\nImportoTotaleDocumento " + R["c8"] + "\nDescrizione " + R["c19"] +
                        ".\r\n Filtro utilizzato : " + filtro);
                return false;
            }
            if (Rows.Length > 1) {
                // Controlla che la somma dell'importo delle righe che sto cancellando sia uguale all'importo della riga del file di esito. Se è uguale, cancella le righe, altrimenti comunica l'errore.
                decimal amountEsito = CfgFn.GetNoNullDecimal(R["c14"]);
                decimal amountPccexpense = 0;
                foreach (DataRow r in Rows) {
                    amountPccexpense = amountPccexpense + CfgFn.GetNoNullDecimal(r["amount"]);
                }
                if (amountPccexpense == amountEsito) {
                    foreach (DataRow r in Rows) {
                        r.Delete();
                    }
                }
                else {
                    show(this, "Sono state trovare più righe di Contabilizzazione aventi:\r\n" +
                            "P.iva: " + p_iva + ",\nCF:" + R["c2"] + ",\nNum.Documento " + R["c6"] +
                        "\nData emissione:" + R["c7"] +
                        //"\nnatura:" + R["c15"] + "\nstato debito:" + R["c17"] +
                        "\nCausale:" + R["c18"] + "\ncig:" + R["c21"] + "\ncup:" + R["c22"] +
                        ",\nImportoTotaleDocumento " + R["c8"] + "\nDescrizione " + R["c19"] +
                        ".\r\n Filtro utilizzato : " + filtro);
                    return false;
                }

            }
            if (Rows.Length == 1) {
                Rows[0].Delete();
            }
            return true;
        }

        string getExcelType(DataColumn c) {
            if (c.ExtendedProperties["ExcelType"] != null) return c.ExtendedProperties["ExcelType"].ToString();
            if (c.DataType == typeof(Int32)) return "Integer";
            if (c.DataType == typeof(String)) return "Text";
            if (c.DataType == typeof(Decimal)) return "Currency";
            if (c.DataType == typeof(Double)) return "Double";
            if (c.DataType == typeof(Single)) return "Single";
            if (c.DataType == typeof(DateTime)) return "DateTime";
            show("Tipo " + c.DataType.ToString() + " non trovato");
            return "Text";
        }

        string[] tracciato_esito_op = new string[] {
            "IDENTIFICATIVO_1;Numero progressivo registrazione; stringa;20;",
            "IDENTIFICATIVO_2_a;Lotto SDI; stringa;100;",
            "IDENTIFICATIVO_2_b;Numero fattura; stringa;20;",
            "IDENTIFICATIVO_3_a;Data documento;Data;8;",
            "IDENTIFICATIVO_3_b;CF fornitore; stringa;16;",
            "IDENTIFICATIVO_3_c;Codice ufficio; stringa;6;",
            "azione;azione;stringa;2;",
            "imponibile;imponibile; numero;22;",
            "imposta;imposta; numero;22;",
            "importononcommerciale;importononcommerciale; numero;22;",
            "importo_sosp_contenzioso;importo_sosp_contenzioso; numero;22;",
            "start_sosp_contenzioso;start_sosp_contenzioso;data;8",
            "importo_sosp_contestazione;importo_sosp_contestazione; numero;22;",
            "start_sosp_contestazione;start_sosp_contestazione;data;8",
            "importo_sosp_regolareverifica;importo_sosp_regolareverifica; numero;22;",
            "start_sosp_regolareverifica;start_sosp_regolareverifica;data;8",
            "importo_nonliquidabile;importo_nonliquidabile; numero;22;",
            "flagsplit;flagsplit;stringa;2",
            "datascadenza;data scadenza;data;8",
            "NmeroProcotolloEntrata;NmeroProcotolloEntrata;stinga;20;",

            "new1",
            "new2"
            };

        string[] tracciato_esito_pag = new string[] {
            "IDENTIFICATIVO_1;Numero progressivo registrazione; stringa;20;",
            "IDENTIFICATIVO_2_a;Lotto SDI; stringa;100;",
            "IDENTIFICATIVO_2_b;Numero fattura; stringa;20;",
            "IDENTIFICATIVO_3_a;Data documento;Data;8;",
            "IDENTIFICATIVO_3_b;CF fornitore; stringa;16;",
            "IDENTIFICATIVO_3_c;Codice ufficio; stringa;6;",
            "azione;azione;stringa;2;",
            "IdPagamento;idpagamento; numero;22;",
            "Tipodebito;tipodebito;stringa;2;",
            "importopagato;importopagato;numero;22;",
            "naturadispesa;naturadispesa;stringa;2;",
            "npay;npay;numero;22;",
            "paymentdate;datamandato;data;8",
            "IdFiscaleIvaFornitore; IdFiscaleIvaFornitore;stringa;16",
            "codicecig;codicecig;stringa;10",
            "codicecup;codicecup;stringa;10",
            "PagamentoOPI;PagamentoOPI; stringa;1;",
            "PagamentoIVA;PagamentoIVA; stringa;1;",
            "Giornidisospensioneeffettivi;Giornidisospensioneeffettivi;numero;22",
            "new1",
            "new2"
            };
        //elabora il file CSV avente come separatore di stringhe il ';'
        private DataTable ReadCurrentSheetCSVNew(string filename, DataTable model) {

            DataTable t = new DataTable();
            t = model.Clone();
            string[] tracciato_esito;
            string kind = getTipoFile();
            tracciato_esito = kind =="P" ? tracciato_esito_pag : tracciato_esito_op;

            int indice = tracciato_esito.Length;
            if (t.Columns.Contains("codicesegnalazione")) {
                t.Columns["codicesegnalazione"].DataType = typeof(string);
                t.Columns["descrizionesegnalazione"].DataType = typeof(string);
                tracciato_esito[indice - 2] = "codicesegnalazione;codice segnalazione; Stringa;50;";
                tracciato_esito[indice - 1] = "descrizionesegnalazione;descrizione segnalazione; Stringa;50;";
            }
            else {
                t.Columns.Add("col_esito1");
                t.Columns.Add("col_esito2");
                tracciato_esito[indice - 2] = "col_esito1;col_esito1; Stringa;50;";
                tracciato_esito[indice - 1] = "col_esito2;col_esito2; Stringa;50;";
            }

            LeggiFile Reader = new LeggiFile();
            //Rimuove le prime 6 righe
            int counter = 0;
            Hashtable Hlen = new Hashtable();
            int j = 0;
            string line;
            string fileTemp = Path.GetTempFileName();
            StreamWriter sw = new StreamWriter(fileTemp, false, System.Text.Encoding.GetEncoding(1252));
            System.IO.StreamReader fileToread = new System.IO.StreamReader(filename);
            while ((line = fileToread.ReadLine()) != null) {
                if (counter > 7) {
                    sw.WriteLine(line);
                    Hlen[j] = line.Length;
                    j++;
                }
                counter++;
            }
            fileToread.Close();
            sw.Close();
            sw.Dispose();
            //Legge il file CSV fileTemp e lo memorizza in una lista di array
            TextReader reader = File.OpenText(fileTemp);
            var parser = new CsvParser(reader);
            string[] row;
            List<string[]> result = new List<string[]>();
            while (true) {
                row = parser.Read();
                if (row == null) {
                    break;
                }
                result.Add(row);
            }

            //Ora lavora col file fileTemp, depurato delle prime sette righe.
            if (!Reader.Init(tracciato_esito)) return null;

            //importa(nuova modifica)
            Reader.Skip();
            //riempie la tabella t, scandendo result riga per riga.

            result = result.Where(item => item.Any(field => !string.IsNullOrWhiteSpace(field))).ToList();

            for(int i=0;i<result.Count; i++) {
                string[] SS = result[i];
                Reader.GetNextCSV(SS);
                DataRow r = t.NewRow();
                foreach (DataColumn c in t.Columns) {
                    object o = Reader.getCurrField(c.ColumnName);
                    r[c.ColumnName] = o;
                }
                t.Rows.Add(r);
            }
            t.AcceptChanges();

            Reader.Close();

            // Rinomina le colonne
            for (int i = 0; i < t.Columns.Count; i++) {
                t.Columns[i].ColumnName = "c" + i;
            }
            // pulizia nomi colonne da eventuali spazi
            foreach (DataColumn C in t.Columns) {
                C.ColumnName = C.ColumnName.Trim();
            }
            if (t.Rows.Count == 0) return null;
            if (File.Exists(fileTemp)) {
                reader.Close();
                reader.Dispose();
                File.Delete(fileTemp);
            }
            return t;
        }

        private DataTable ReadCurrentSheet(string fileName, DataTable model, int rowsToSkip, string extension) {
            DataTable dtEsito = null;
            if (extension == "csv") {
                dtEsito = ReadCurrentSheetCSVNew(fileName, model);
                return dtEsito;
            }
			// Parte vecchia
			// Cancella le prime 7 righe di intestazione, sia che sia I sia che sia O
			//if (extension == "csv") {
			//    string pathOnly = Path.GetDirectoryName(fileName);
			//    string ConnectionString = ExcelImport.CsvConnString(pathOnly, false);
			//    string OnlyfileName = Path.GetFileName(fileName);
			//    string inicontent = "[" + OnlyfileName + "]\r\n" +
			//                        "Format = Delimited(;)\r\n" +
			//                        "MaxScanRows=0\r\n" +
			//                        "DecimalSymbol=.\r\n" +
			//               "CurrencyThousandSymbol=\r\n" +
			//               "CurrencyDecimalSymbol=.\r\n" +
			//               "CurrencyDigits=2\r\n" +
			//               "CurrencySymbol= €\r\n" +
			//                        "ColNameHeader = False";
			//    dtEsito = model.Clone();
			//    if (dtEsito.Columns.Contains("codicesegnalazione")) {
			//        dtEsito.Columns["codicesegnalazione"].DataType = typeof(string);
			//        dtEsito.Columns["descrizionesegnalazione"].DataType = typeof(string);
			//    }
			//    else {
			//        dtEsito.Columns.Add("col_esito1");
			//        dtEsito.Columns.Add("col_esito2");

			//    }
			//    for (int i = 0; i < dtEsito.Columns.Count; i++) {
			//        int nCol = i + 1;
			//        DataColumn c = dtEsito.Columns[i];
			//        string colDef;
			//        if (i == 14 || i==26) {
			//            //trattiamo diversamente la colonna 14
			//             colDef= "Col" + nCol + "=" + c.ColumnName + " " + "Currency";
			//            inicontent += "\r\n" + colDef;
			//            continue;
			//        }

			//        colDef = "Col" + nCol + "=" + c.ColumnName + " " + getExcelType(c);


			//        inicontent += "\r\n" + colDef;
			//    }

			//    string fNameIni = Path.Combine(pathOnly, "schema.ini");
			//    File.WriteAllText(fNameIni, inicontent);

			//    try {
			//        // open the connection to the file
			//        using (OleDbConnection connection =
			//                   new OleDbConnection(ConnectionString)) {
			//            connection.Open();
			//            string sql = "SELECT * FROM [" + OnlyfileName + "]";

			//            // create an adapter
			//            using (OleDbDataAdapter adapter =
			//                       new OleDbDataAdapter(sql, connection)) {
			//                // clear the datatable to avoid old data persistance

			//                dtEsito = new DataTable();
			//                dtEsito.Locale = CultureInfo.CurrentCulture;
			//                dtEsito.Clear();
			//                adapter.Fill(dtEsito);
			//            }
			//            connection.Close();
			//        }
			//    }
			//    catch (Exception ex) {
			//        show(this, ex.Message);
			//        File.Delete(fNameIni);
			//        return null;
			//    }
			//    File.Delete(fNameIni);
			//    for (int i = 0; i < dtEsito.Columns.Count; i++) {
			//        dtEsito.Columns[i].ColumnName = "c" + i;
			//    }
			//    // pulizia nomi colonne da eventuali spazi
			//    foreach (DataColumn C in dtEsito.Columns) {
			//        C.ColumnName = C.ColumnName.Trim();
			//    }
			//    for (int i = 0; i <= rowsToSkip; i++) {
			//        if (dtEsito.Rows.Count <= i) continue;
			//        dtEsito.Rows[i].Delete();
			//    }
			//    dtEsito.AcceptChanges();
			//    if (dtEsito.Rows.Count == 0) return null;
			//}

			if (extension == "xlsx") {
				show(@"Importo file xlsx", @"Avviso");
				dtEsito = model.Clone();
				if (dtEsito.Columns.Contains("progressivoregistrazione")) {
					dtEsito.Columns["progressivoregistrazione"].DataType = typeof(Int64);
				}
				if (dtEsito.Columns.Contains("codicesegnalazione")) {
					dtEsito.Columns["codice segnalazione"].DataType = typeof(string);
					dtEsito.Columns["descrizione segnalazione"].DataType = typeof(string);
				}
				else {
					dtEsito.Columns.Add("col_esito1").DataType = typeof(string);
                    dtEsito.Columns.Add("col_esito2").DataType = typeof(string);

                }

				try {
					bool res = exportclass.importXlsx(dtEsito, fileName, rowsToSkip);
					if (!res) return null;
					//ExcelImport c = new ExcelImport();
					//c.ImportTable(fileName, dtEsito, false, rowsToSkip + 1);
				}
				catch (System.IO.IOException e) {
					show(this, @"Errore nell'apertura del file:\n\r" + e, @"Errore");
					return null;
				}

				for (int i = 0; i < dtEsito.Columns.Count; i++) {
					dtEsito.Columns[i].ColumnName = "c" + i;
				}
				//File.Delete(fNameIni);
				// pulizia nomi colonne da eventuali spazi
				foreach (DataColumn C in dtEsito.Columns) {
					C.ColumnName = C.ColumnName.Trim();
				}
				if (dtEsito.Rows.Count == 0) return null;
			}

			if (extension == "excel") {
                dtEsito = model.Clone();
                if (dtEsito.Columns.Contains("progressivoregistrazione")) {
                    dtEsito.Columns["progressivoregistrazione"].DataType = typeof(Int64);
                }
                    if (dtEsito.Columns.Contains("codicesegnalazione")) {
                    dtEsito.Columns["codicesegnalazione"].DataType = typeof(string);
                    dtEsito.Columns["descrizionesegnalazione"].DataType = typeof(string);
                }
                else {
                    dtEsito.Columns.Add("col_esito1");
                    dtEsito.Columns.Add("col_esito2");

                }
                ExcelImport c = new ExcelImport();
                c.ImportTable(fileName, dtEsito, false, rowsToSkip + 1);

                for (int i = 0; i < dtEsito.Columns.Count; i++) {
                    dtEsito.Columns[i].ColumnName = "c" + i;
                }
                //File.Delete(fNameIni);
                // pulizia nomi colonne da eventuali spazi
                foreach (DataColumn C in dtEsito.Columns) {
                    C.ColumnName = C.ColumnName.Trim();
                }
                if (dtEsito.Rows.Count == 0) return null;
            }

            foreach (DataRow dr in dtEsito.Select()) {
                if (dr.ItemArray.All(field => string.IsNullOrEmpty(field.ToString()))) {
                    dr.Delete();
                }
            }
            dtEsito.AcceptChanges();

            return dtEsito;
        }

        decimal getImportoFromStringa(string importo) {
            if (importo.EndsWith(".") || importo.EndsWith(",")) importo = importo.Substring(0, importo.Length - 1);
            importo = importo.Replace("€", "");
            importo = importo.Trim();
            int dotPos = importo.IndexOf('.');
            int lastDotPos = importo.LastIndexOf('.');
            if (lastDotPos != dotPos) {
                //rimuove la prima occorrenza del punto  se ce ne sono due o più
                return getImportoFromStringa(importo.Remove(dotPos, 1));
            }

            int commaPos = importo.IndexOf(',');
            int lastCommaPos = importo.LastIndexOf(',');
            if (lastCommaPos != commaPos) {
                //rimuove la prima occorrenza della virgola  se ce ne sono due o più
                return getImportoFromStringa(importo.Remove(commaPos, 1));
            }


            if (dotPos < 0 && commaPos < 0) {
                return Convert.ToDecimal(importo, new CultureInfo("en-US"));
            }
            //se ci sono tutti e due, il primo non serve comunque
            if (dotPos >= 0 && commaPos >= 0) {
                if (dotPos < commaPos) return getImportoFromStringa(importo.Replace(".", ""));
                return getImportoFromStringa(importo.Replace(",", ""));
            }

            //c'è uno solo dei due, normalizza la stringa con solo il punto decimale (che  potrebbe essere anche un punto di separazione delle migliaia)
            if (commaPos >= 0) return getImportoFromStringa(importo.Replace(',', '.'));

            //A questo punto c'è solo un punto, e dobbiamo decidere se cancellarlo o considerarlo un punto decimale o delle migliaia
            //Lo consideriamo un punto decimale se seguito da 1 o due cifre numeriche
            if (dotPos < importo.Length - 3) {
                //Altrimenti è un punto/virgola delle migliaia e lo togliamo
                importo = importo.Replace(".", "");
            }


            return Convert.ToDecimal(importo, new CultureInfo("en-US"));
        }


        private void btnSalvaFile_Click(object sender, EventArgs e) {
            if (Meta.IsEmpty) return;
            DataRow Curr = DS.pcc.Rows[0];
            if (Curr["attachment"] == DBNull.Value) return;
            if (saveFileDialog1.ShowDialog(this) != DialogResult.OK) return;

            byte[] ByteArray = (byte[])Curr["attachment"];

            try {
                FileStream FS = new FileStream(saveFileDialog1.FileName, FileMode.Create, FileAccess.Write);
                FS.Write(ByteArray, 0, ByteArray.Length);
                FS.Flush();
                FS.Close();
            }
            catch (Exception E) {
                QueryCreator.ShowException("Errore nel salvataggio del file " + saveFileDialog1.FileName, E);
            }

        }

        private void btnRigenera_Click(object sender, EventArgs e) {
            if (Meta.IsEmpty) return;
            DataRow Curr = DS.pcc.Rows[0];
            if (Curr["attachment"] == DBNull.Value) return;
            if (saveFileDialog1.ShowDialog(this) != DialogResult.OK) return;

            RigeneraFile(true);
            GeneraFile(saveFileDialog1.FileName);
        }

		private void btnEliminaCS_Click(object sender, EventArgs e) {

		}

	}
}


