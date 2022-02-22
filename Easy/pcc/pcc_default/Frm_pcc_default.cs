
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

namespace pcc_default {
    public partial class Frm_pcc_default : MetaDataForm {
        private MetaData Meta;
        private DataAccess Conn;
        string CFTrasmittente = "";
        private object idreg = DBNull.Value;
        //private string cartellaFile = "";
        private string NomeCompletoFileCSV = "";
        public IOpenFileDialog openFileDialog1;

        public Frm_pcc_default() {
            InitializeComponent();
            QueryCreator.SetTableForPosting(DS.pccsendview, "pccsend");
            QueryCreator.SetTableForPosting(DS.pccexpenseview, "pccexpense");
            QueryCreator.SetTableForPosting(DS.pccpaymentview, "pccpayment");
            QueryCreator.SetTableForPosting(DS.pccexpiringview, "pccexpiring");

            openFileDialog1 = createOpenFileDialog(_openFileDialog1);
        }

        //DataAccess Conn;
        QueryHelper QHS;
        CQueryHelper QHC;
        public void MetaData_AfterLink() {
            QueryCreator.SetTableForPosting(DS.pccsendview, "pccsend");
            QueryCreator.SetTableForPosting(DS.pccexpenseview, "pccexpense");
            QueryCreator.SetTableForPosting(DS.pccpaymentview, "pccpayment");
            QueryCreator.SetTableForPosting(DS.pccexpiringview, "pccexpiring");
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
        }

        public void MetaData_AfterFill() {
            txtFilename.Enabled = false;
            btnImportaFileEsito.Enabled = Meta.EditMode;
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
                DataSet DSpccsendOperation = Conn.CallSP("compute_resendpccoperation", param, true, 900);
                if (DSpccsendOperation == null || DSpccsendOperation.Tables.Count == 0)
                    return;
                Tpccsendoperation = DSpccsendOperation.Tables[0];
            }
            if (!importazione) {
                //Solo in caso di vera rigenerazione deve generare il file e scriverlo sul db, se siamo in fase di importazione ci servono solo i DataTale Tpccsend o Tpccsendoperation
                GeneraFile();
                ScriviFileNelDB(NomeCompletoFileCSV);
            }
        }

        string getTipoFile() {
            if (DS.pccsendview.Rows.Count > 0) return "I";
            return "O";
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
            else {
                valore = "0;0;0;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;" + "\r\n" +
            "Codice del modello;003 - UTENTE PA - OPERAZIONI SU FATTURE ESISTENTI;;i campi contrassegnati da * sono obbligatori;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;" + "\r\n" +
            "Versione del modello;1;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;" + "\r\n" +
            "Utente che trasmette il file (Codice Fiscale);" + CFTrasmittente + ";;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;" + "\r\n" +
            "DATI AMMINISTRAZIONE (SDI 1.4 CessionarioCommittente);;DATI FORNITORE (SDI 1.2 CedentePrestatore);;TIPO OPERAZIONE;DATI IDENTIFICATIVI FATTURA* (SDI 2.1 DatiGenerali);;;;RICEZIONE (i campi con * sono da ritenersi obbligatori solo per TIPO OPERAZIONE = RC);;;COMUNICAZIONE RIFIUTO (i campi con * sono da ritenersi obbligatori solo per TIPO OPERAZIONE = RF);;CONTABILIZZAZIONE (i campi con * sono da ritenersi obbligatori solo per TIPO OPERAZIONE = CO);;;;;;;;;COMUNICAZIONE SCADENZA (i campi con * sono da ritenersi obbligatori solo per TIPO OPERAZIONE = CS);;;COMUNICAZIONE PAGAMENTO  (i campi con * sono da ritenersi obbligatori solo per TIPO OPERAZIONE = CP);;;;;;;;;;ESITO ELABORAZIONE;;;;;;;;;;;;;;;;;;;;;;;;" + "\r\n" +
            "Codice Fiscale* - Specificare il Codice Fiscale della Amministrazione destinataria del documento (SDI 1.4.1.2 CodiceFiscale);Codice Ufficio* - Specificare il Codice Univoco Ufficio di IPA oppure il Codice Ufficio PCC (SDI   1.1.4 CodiceDestinatario); Codice Fiscale* - Specificare il Codice Fiscale del Fornitore che ha emesso il documento (SDI  1.2.1.2 CodiceFiscale);Id Fiscale IVA* - Specificare il numero di identificazione fiscale ai fini IVA nel formato IT12345678901  (SDI  1.2.1.1 IdFiscaleIVA);Azione* - Specificare RC: Ricezione /  RF: Rifiuto / CO: Contabilizzazione / CS: Comunicazione scadenza /CP: Comunicazione pagamento;IDENTIFICATIVO 1;IDENTIFICATIVO 2 (da compilare solo se IDENTIFICATIVO 1 = NA);;;Numero Protocollo di Entrata;Data ricezione - Specificare la data di ricezione da parte della PA. Se omessa, viene assunta come data di ricezione quella in cui viene caricato il file;Note;Data rifiuto - Se omessa, viene assunta come data di rifiuto quella in cui viene caricato il file;Descrizione* - Indicare le motivazioni da associare all'azione di rifiuto ;Importo del movimento*;Natura di spesa* - Specificare CO: Spesa Corrente / CA: Conto Capitale / NA: Non Applicabile;Capitoli di spesa / Conto - Specificare i Capitoli di spesa o Conti separati da vigola;OPERAZIONE;;Descrizione - Indicare una descrizione del movimento ;Estremi Impegno;Codice CIG* - Codice Identificativo della gara;Codice CUP* - Codice Unitario Progetto;Comunica scadenza* - Specificare SI;Importo - Specificare l'importo a cui si riferisce la scadenza. Se omesso, s'intende l'importo totale della fattura;Data scadenza - Se non specificata sarà assunta la data di scadenza riportata nella fattura;Importo pagato*;Natura di spesa* - Specificare CO: Spesa Corrente / CA: Conto Capitale;Capitoli di spesa / Conto - Specificare i Capitoli di spesa o Conti separati da vigola;Estremi Impegno;Mandato di pagamento*;;Id Fiscale IVA del Beneficiario* - Specificare il numero di identificazione fiscale del beneficiario ai fini IVA nel formato IT12345678901;Codice CIG* - Codice Identificativo della gara;Codice CUP* - Codice Unitario Progetto;Descrizione - Indicare una descrizione aggiuntiva del movimento ;Codice segnalazione;Descrizione segnalazione;;;;;;;;;;;;;;;;;;;;;;;" + "\r\n" +
            ";;;;;Numero Progressivo di Registrazione - attribuito dal sistema PCC in fase di Ricezione (se non disponibile specificare NA);Numero fattura (SDI 2.1.1.4 Numero);Data emissione (SDI 2.1.1.3 Data);Importo totale documento (SDI 2.1.1.9 ImportoTotaleDocumento);;;;;;;;;Stato del debito* -Indicare un codice valido tra i seguenti (v. Istruzioni): LIQ, SOSP, NOLIQ, LIQdaSOSP, LIQdaNL, SOSPdaLIQ, SOSPdaNL, NLdaLIQ, NLdaSOSP;Causale - Indicare un codice valido per il tipo di movimento;;;;;;;;;;;;Numero;Data;;;;;;;;;;;;;;;;;;;;;;;;;;;;;" + "\r\n";
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
            return "O";//Per il momento sarà solo O
            //Prendiamo la prima riga con i dati
            /*DataRow R = T.Rows[7];
            string colonnaC = R[2].ToString();
            if (colonnaC.Length <= 16) {
                //è un Cf quindi siamo nel file O
                return "O";
            }
            else {
                return "I";
            }*/
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
                campi["cf"] = standardize(r[2].ToString());
                campi["tipooperazione"] = standardize(r[4].ToString());
                campi["numdocumento"] = standardize(r[6].ToString());
                campi["importodoc"] = CfgFn.RoundValuta(CfgFn.GetNoNullDecimal(r[8]));
                campi["importomov"] = CfgFn.RoundValuta(CfgFn.GetNoNullDecimal(r[14]));
                campi["statodeldebito"] = standardize(r[17].ToString());
                campi["impegno"] = standardize(r[20].ToString());
                campi["cig"] = standardize(r[21].ToString());
                campi["cup"] = standardize(r[22].ToString());
                campi["importopagato"] = CfgFn.RoundValuta(CfgFn.GetNoNullDecimal(r[26]));
                campi["numpagamento"] = standardize(r[30].ToString());
                campi["cfbeneficiario"] = standardize(r[32].ToString());
                campi["cigpagamento"] = standardize(r[33].ToString());
                campi["cuppagamento"] = standardize(r[34].ToString());
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
                                "\n CF (colonna C): " + c.campi["cf"].ToString().ToUpperInvariant()
                                + "\n Tipo Operazione (col. E): " + c.campi["tipooperazione"].ToString().ToUpperInvariant()
                                + "\n Num. documento (col. G): " + c.campi["numdocumento"].ToString().ToUpperInvariant()
                                + "\n Importo documento (col. I): " + c.campi["importodoc"].ToString().ToUpperInvariant()
                                + "\n Importo contabilizzazione (colonna O): " + c.campi["importomov"].ToString().ToUpperInvariant()
                                + "\n Stato del debito (col. R): " + c.campi["statodeldebito"].ToString().ToUpperInvariant()
                                + "\n Num.Impegno (col. U): " + c.campi["impegno"].ToString().ToUpperInvariant()
                                + "\n CIG contab. (col. V): " + c.campi["cig"].ToString().ToUpperInvariant()
                                + "\n CUP contab. (col. W): " + c.campi["cup"].ToString().ToUpperInvariant()
                                + "\n Importo Pagato (col.AA): " + c.campi["importopagato"].ToString().ToUpperInvariant()
                                + "\n N.Mandato: (col.AE)" + c.campi["numpagamento"].ToString().ToUpperInvariant()
                                + "\n CF beneficiario (col.AG): " + c.campi["cfbeneficiario"].ToString().ToUpperInvariant()
                                + "\n CIG pagamento (col.AH): " + c.campi["cigpagamento"].ToString().ToUpperInvariant()
                                + "\n CUP pagamento: (col.AI) " + c.campi["cuppagamento"].ToString().ToUpperInvariant()
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
            RigeneraFile(true);

            //Da ora in poi lavoreremo con Ttrasmesso
            DataTable tTrasmesso = (getTipoFile() == "I") ? Tpccsend : Tpccsendoperation;
            string fileName = openFileDialog1.FileName;
            string extension = Path.GetExtension(fileName);
            DataTable tEsito = null;
            if (extension.ToLower() == ".csv") {
                tEsito = ReadCurrentSheet(fileName, tTrasmesso, 6, "csv");// Salta le prime 6 righe sia per il .CSV che per l'Excel.
            }
            else {
                if (extension.ToLower() == ".xlsx") {
                    tEsito = ReadCurrentSheet(fileName, tTrasmesso, 7, "xlsx");// >>> come in disposizioni di pagamento
                }
                else {
                    tEsito = ReadCurrentSheet(fileName, tTrasmesso, 7, "excel");// >>> come in disposizioni di pagamento
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

            string colonnaE = "";
            for (int i = 0; i < tEsito.Rows.Count; i++) {
                DataRow R = tEsito.Rows[i];
                string colonnaAK = R[36].ToString();  //colonna esito
                if (colonnaAK == "") {
                    R.Delete();
                    continue;
                }
                colonnaE = R[4].ToString();
                if ((colonnaE == "CO") || (colonnaE == "COF")) {
                    // Deve cancellare da pccexpense
                    if (!CancellazioneRigaPccexpenseEseguita(R)) {
                        return;//C'è stato un errore e interrompe l'operazione
                    }
                }
                if (colonnaE == "CS") {
                    // Deve cancellare da pccexpiring
                    if (!CancellazioneRigaPccexpiringEseguita(R)) {
                        return;
                    }
                }
                if (colonnaE == "CP") {
                    // Deve cancellare da pccpayment
                    if (!CancellazioneRigaPccpaymentEseguita(R)) {
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
            if (fDiff.ShowDialog(this) == DialogResult.OK) {
                return true;
            }
            return false;
        }
        void ImpostaCaptionDettaglioOp(DataTable dt) {
            foreach (DataColumn C in dt.Columns) {
                C.Caption = "";
            }
            dt.Columns["c2"].Caption = "CF Fornitore";
            dt.Columns["c4"].Caption = "Azione";
            dt.Columns["c6"].Caption = "Num.Fattura";
            dt.Columns["c7"].Caption = "Data emissione";
            dt.Columns["c8"].Caption = "Importo Tot.documento";
            dt.Columns["c14"].Caption = "Importo del mov.";
            dt.Columns["c15"].Caption = "Natura";
            dt.Columns["c36"].Caption = "Errore";
            dt.Columns["c37"].Caption = "Descrizione Errore";
        }
        void ImpostaCaptionDettaglioDiff(DataTable dt) {
            foreach (DataColumn C in dt.Columns) {
                C.Caption = "";
            }
            dt.Columns["c2"].Caption = "CF Fornitore";
            dt.Columns["c4"].Caption = "Azione";
            dt.Columns["c6"].Caption = "Num.Fattura";
            dt.Columns["c7"].Caption = "Data emissione";
            dt.Columns["c8"].Caption = "Importo Tot.documento";
            dt.Columns["c14"].Caption = "Importo del mov.";
            dt.Columns["c15"].Caption = "Natura";
            dt.Columns["c25"].Caption = "Data scadenza";
            dt.Columns["c26"].Caption = "Importo pagato";
            dt.Columns["c27"].Caption = "Natura di spesa";
            dt.Columns["c30"].Caption = "n.mandato";
            dt.Columns["c33"].Caption = "cig";
            dt.Columns["c34"].Caption = "cup";
            dt.Columns["c35"].Caption = "Descrizione pagamento";
            dt.Columns["c36"].Caption = "Errore";
            dt.Columns["c37"].Caption = "Descrizione Errore";
        }
        private bool CancellazioneRigaPccexpiringEseguita(DataRow R) {
            object p_iva = R["c3"];
            if (p_iva.ToString() == "") p_iva = DBNull.Value;
            //if (p_iva.StartsWith("IT")) {
            //    p_iva = p_iva.Substring(2);
            //}

            string filtro = QHC.AppAnd(
                //3-IdFiscaleIvaFornitore,2-CFfornitore
                QHC.CmpEq("IdFiscaleIvaFornitore", p_iva), QHC.CmpEq("CFfornitore", R["c2"]),
                //  6-num.fattura, 7-data emissione, 8-Importo tot.doc.,  >>>>> Sono indentificativi della fattura 
                QHC.CmpEq("numerodocumento", R["c6"]), QHC.CmpEq("dataemissione", R["c7"]), QHC.CmpEq("ImportoTotaleDocumento", R["c8"]),
                 //  24-Importoscadenza, 25-data scadenza   >>>   Sezione SCADENZA
                 QHC.CmpEq("expiringdate", R["c25"]));  //QHC.CmpEq("amount", R["c24"]),
            DataRow[] Rows = DS.pccexpiringview.Select(filtro, null);
            if (Rows.Length == 0) {
                show(this, "Non è stato trovata la riga di Scadenza avente:\r\n" +
                        "P.iva: " + p_iva + ",\nCF:" + R["c2"] + ",\nNum.Documento " + R["c6"]
                        + ",\n DataEmissione " + R["c7"] + "\nData scadenza " + R["c25"]
                        + ",\n ImportoTotaleDocumento " + R["c8"]);
                return false;
            }
            if (Rows.Length > 1) {
                decimal amountEsito = CfgFn.GetNoNullDecimal(R["c24"]);
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
                    show(this, "Sono state trovare più righe di Pagamenti aventi:\r\n" +
                                          "P.iva: " + p_iva + ",\nCF:" + R["c2"] + ",\nNum.Documento " + R["c6"]
                                          + ",\n DataEmissione " + R["c7"] + "\nData scadenza " + R["c25"]
                                          + ",\n ImportoTotaleDocumento " + R["c8"]);

                    return false;
                }
            }
            if (Rows.Length == 1) {
                Rows[0].Delete();
            }
            return true;
        }
        private bool CancellazioneRigaPccpaymentEseguita(DataRow R) {
            object p_iva = R["c3"];
            if (p_iva.ToString() == "") p_iva = DBNull.Value;
            //if (p_iva.StartsWith("IT")) {
            //    p_iva = p_iva.Substring(2);
            //}            
            string filterNA = null;
            object kindToCompare = R["c27"];
            if (kindToCompare.ToString() != "") {
                //kindToCompare = "NA";
                filterNA = QHC.CmpEq("expensekind", kindToCompare);
            }

            string filtro = QHC.AppAnd(
                //3-IdFiscaleIvaFornitore,2-CFfornitore
                QHC.CmpEq("IdFiscaleIvaFornitore", p_iva), QHC.CmpEq("CFfornitore", R["c2"]),
                //      6-num.fattura, 7-data emissione, 8-Importo tot.doc.,   >>>>> Sono indentificativi della fattura 
                QHC.CmpEq("numerodocumento", R["c6"]), QHC.CmpEq("dataemissione", R["c7"]), QHC.CmpEq("ImportoTotaleDocumento", R["c8"]),
                //26-importo pagato, 27-natura di spesa, 30-n.mandato, 31-data mandato, 33-cig, 34-cup,35-descrizione  >>>>> Sezione PAGAMENTO
                QHC.CmpEq("amount", R["c26"]), QHC.CmpEq("npay", R["C30"]),
                filterNA,
                QHC.CmpEq("cigcode", R["c33"]),
                QHC.CmpEq("cupcode", R["c34"]), QHC.CmpEq("description", R["c35"]));

            DataRow[] Rows = DS.pccpaymentview.Select(filtro, null);
            if (Rows.Length == 0) {
                show(this, "Non è stato trovata la riga di Pagamento avente:\r\n" +
                        "P.iva: " + p_iva + ",\nCF:" + R["c2"] + ",\nNum.Documento " + R["c6"] +
                        "\ndataemissione:" + R["c7"] + "\nImporto:" + R["c26"] +
                        "\nN.mandato:" + R["c30"] + "\nCIG:" + R["c33"] + "\ncup:" + R["c34"] +
                        ",\nImportoTotaleDocumento " + R["c8"] + "\nDescrizione " + R["c35"]);
                return false;
            }
            if (Rows.Length > 1) {
                show(this, "Sono state trovare più righe di Pagamenti aventi:\r\n" +
                        "P.iva: " + p_iva + ",\nCF:" + R["c2"] + ",\nNum.Documento " + R["c6"] +
                        "dataemissione:" + R["c7"] + "\nImporto:" + R["c26"] +
                        "\nN.mandato:" + R["c30"] + "\nCIG:" + R["c33"] + "\ncup:" + R["c34"] +
                        ",\nImportoTotaleDocumento " + R["c8"] + "\nDescrizione " + R["c35"]);
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

        string[] tracciato_esito = new string[] {
            "CFAmmin;Cf amministrazione; stringa;11;",
            "IPA;ipa;stringa;6;",
            "CFfornitore;CF fornitore; stringa;16;",
            "IdFiscaleIvaFornitore_co;IdFiscaleIva;stringa;30;",
            "azione;tipo azione; stringa;3;",
            "progressivoregistrazione;progressivoregistrazione;intero;4;",
            "numerodocumento;numero documento; stringa;20;",
            "dataemissione; data emissione;Data;8;",
            "importototaledocumento;importo documento; numero;22;",
            "numeroprotocolloentrata;numeroprotocolloentrata;stringa;100",
            "dataricezione;data ricezione;data;8",
            "note;note;stinga;200;",
            "datarifiuto;data rifiuto;data;8",
            "descrizione;descrizione;stringa;100",
            "importodelmovimento;importo movimento; numero;22;",
            "naturadispesa_co;natuta di spesa;stringa;2;",
            "codefin_co;codice bilancio; stringa;50;",
            "statodeldebito;stato del debito;stringa;9;",
            "causale;causale;Stringa;20;",
            "description_co;descrizione;stringa;100;",
            "numimpegno_co;num impegno; intero;4;",
            "cigcode_co;CIG;Stringa;10;",
            "cupcode_co;CUP;Stringa;15;",
            "comunicazionescadenza;comunicazione scadenza; Stringa;2;",
            "importononpagallascadenza;Importo scadenza; numero;22;",
            "datascadenza;Data scadenza; Data;8;",
            "importopagato;importo pagato;Numero;22;",
            "naturadispesa_cp;natuta di spesa;stringa;2;",
            "codefin_cp;codice bilancio; stringa;50;",
            "numimpegno_cp;num impegno; intero;4;",
            "npay;numero mandato; Intero;4;",
            "paymentdate;Data pagamento; Data;8;",
            "IdFiscaleIvaFornitore_cp;IdFiscaleIva;stringa;30;",
            "cigcode_cp;CIG;Stringa;10;",
            "cupcode_cp;CUP;Stringa;15;",
            "description_cp;descrizione;stringa;100;",
            "new1",
            "new2"
            };

        //elabora il file CSV avente come separatore di stringhe il ';'
        private DataTable ReadCurrentSheetCSV(string filename, DataTable model) {

            DataTable t = new DataTable();
            t = model.Clone();
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
                if (counter > 6) {
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

            //Ora lavora col file fileTemp, depurato delle prime tre righe.
            if (!Reader.Init(tracciato_esito)) return null;

            //importa(nuova modifica)
            Reader.Skip();
            //riempie la tabella t, scandendo result riga per riga. 
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
                dtEsito = ReadCurrentSheetCSV(fileName, model);
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
                if (dtEsito.Columns.Contains("codicesegnalazione")) {
                    dtEsito.Columns["codicesegnalazione"].DataType = typeof(string);
                    dtEsito.Columns["descrizionesegnalazione"].DataType = typeof(string);
                }
                else {
                    dtEsito.Columns.Add("col_esito1");
                    dtEsito.Columns.Add("col_esito2");

                }

                try {
                    bool res = exportclass.importXlsx(dtEsito, fileName, rowsToSkip);
                    if (!res) return null;
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


            return dtEsito;
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

    }
}


