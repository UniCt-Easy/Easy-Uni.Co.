
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
using metaeasylibrary;
using funzioni_configurazione;
using System.IO;
using System.Threading;
using System.Diagnostics;
using System.Security;
using System.Globalization;
using System.Collections;

namespace pccsid_wizard_calcolo {
    public partial class Frm_pccsid_wizard_calcolo : MetaDataForm {
        private MetaData Meta;
        private DataAccess Conn;
        private string CustomTitle;
        private object esercizio;
        MetaDataDispatcher Disp;
        CQueryHelper QHC;
        QueryHelper QHS;
        private DataTable myRiepilogoaliquote = null;
        private DataTable myRiepilogoCigCup = null;
        private DataTable Invio = null;
        private DataTable Inviocopy = null;
        private DataTable Operazioni = null;
        private DataTable OperazioniPagamento = null;
        private DataTable Operazionicopy = null;
        private DataTable OperazioniPagamentocopy = null;
        private DataTable TfileInvio = null;
        private DataTable TfileOperazioni = null;
        private DataTable TfileOperazioniPagamento = null;
        object idsor01 = "";
        object idsor02 = "";
        object idsor03 = "";
        object idsor04 = "";
        object idsor05 = "";
        string CFTrasmittente = "";
        private object idreg = DBNull.Value;
        //private string cartellaFile = "";
        private string NomeCompletoFileCSV = "";
        private string NomeFile = "";

        public IFolderBrowserDialog folderBrowserDialog1;

        public Frm_pccsid_wizard_calcolo() {
            InitializeComponent();
            folderBrowserDialog1 = createFolderBrowserDialog(_folderBrowserDialog1);
            tabController.HideTabsMode =
                Crownwood.Magic.Controls.TabControl.HideTabsModes.HideAlways;
        }

        public void MetaData_AfterLink() {

            Meta = MetaData.GetMetaData(this);
            this.Conn = Meta.Conn;
            this.Disp = Meta.Dispatcher;
            QHC = new CQueryHelper();
            QHS = Meta.Conn.GetQueryHelper();

            Meta.CanCancel = false;
            Meta.CanInsert = false;
            Meta.CanInsertCopy = false;
            Meta.CanSave = false;
            Meta.SearchEnabled = false;
            chkInvio.Checked = false;
            chkSID.Checked = false;
            chkMI.Checked = false;
            chkScadenza.Checked = false;
            chkIP.Checked = false;

            esercizio = Meta.GetSys("esercizio").ToString();
            string filteresercizio = QHS.CmpEq("ayear", esercizio);
        }

        private void DisplayTabs(int newTab) {
            tabController.SelectedIndex = newTab;
            //Evaluates Buttons Appearance
            btnBack.Visible = (newTab > 0) && (AllDisabled == false);
            if (newTab == tabController.TabPages.Count - 1)
                btnNext.Text = "Fine.";
            else
                btnNext.Text = "Avanti >";
            Text = CustomTitle + " (Pagina " + (newTab + 1) + " di " + tabController.TabPages.Count + ")";
            btnNext.Enabled = (AllDisabled == false);
        }

        bool AllDisabled = false;

        /// <summary>
        /// Changes tab backward/forward
        /// </summary>
        /// <param name="step"></param>
        private void StandardChangeTab(int step) {
            int oldTab = tabController.SelectedIndex;
            int newTab = oldTab + step;
            if ((newTab < 0) || (newTab > tabController.TabPages.Count))
                return;
            if (!CustomChangeTab(oldTab, newTab))
                return;
            if (newTab == tabController.TabPages.Count) {
                btnNext.Visible = false;
                btnBack.Visible = false;
                btnAnnulla.Text = "Chiudi";
                lblFinale.Text = "File salvato in " + NomeCompletoFileCSV;
                AllDisabled = true;
                return;
            }
            DisplayTabs(newTab);
        }

        /// <summary>
        /// Must return true if operation is possible, and do any
        ///  operation related to change from tab oldTab to newTab
        /// </summary>
        /// <param name="oldTab"></param>
        /// <param name="newTab"></param>
        /// <returns></returns>
        bool CustomChangeTab(int oldTab, int newTab) {
            if (AllDisabled)
                return false;
            if ((oldTab == 0) && (newTab == 1)) {
                if (txtAnagrafica.Text != "") {
                    string filteridreg = QHS.AppAnd(QHS.CmpEq("title", txtAnagrafica.Text), QHS.CmpEq("active", "S"));
                    DataAccess.RUN_SELECT_INTO_TABLE(Meta.Conn, DS.registry, null, filteridreg, null, true);
                    if (DS.registry.Rows.Count == 0) {
                        show("Anagrafica di nome " + txtAnagrafica.Text + " non trovata o non attiva.", "Errore");
                        return false;
                    }
                    idreg = DS.registry.Rows[0]["idreg"];
                }
                else {
                    show(this, "Selezionare il Responsabile");
                    return false;
                }

                if (txtPercorso.Text == "") {
                    show(this, "Occorre specificare la cartella in cui salvare il file", "errore");
                    return false;
                }

                if(!chkInvio.Checked 
                    && !chkSID.Checked && !chkScadenza.Checked && !chkMI.Checked 
                    && !chkIP.Checked) {
                    show(this, "Occorre specificare l' operazione da trasmettere", "errore");
                    return false;
                }
                if (chkInvio.Checked) {
                    EseguiSPInvio();
                }
                
                if (chkSID.Checked || chkScadenza.Checked || chkMI.Checked ||chkIP.Checked) {
                   EseguiSPOperazioni();
                }
            }
            if ((oldTab == 1) && (newTab == 2)) {
                if (chkInvio.Checked) {
                    RiempiTabellaInvio();
                }
                if (chkSID.Checked || chkScadenza.Checked || chkMI.Checked || chkIP.Checked) {
                    RiempiTabellaOperazioni();
                }

            }
            if ((oldTab == 2) && (newTab == 3)) {
                SaveData();
            }
            return true;
        }

        private void SvuotaTabella(string kind) {
            if (kind == "O") {
                if ((Tpccsendoperation != null) && (Tpccsendoperation.Rows.Count != 0))
                    Tpccsendoperation.Clear();
            }
            else {
                if ((Tpccsend != null) && (Tpccsend.Rows.Count != 0))
                    Tpccsend.Clear();
            }

        }

        private void SaveData() {
            // Salva le operazioni nelle varie tabelle
            if ((Tpccsend == null || Tpccsend.Rows.Count == 0)
                &&
                (Tpccsendoperation == null || Tpccsendoperation.Rows.Count == 0)
                && (TpccsendPayment==null || TpccsendPayment.Rows.Count==0))
                return;

            Meta.SetDefaults(DS.pcc);
            DataRow Rpcc = Meta.Get_New_Row(null, DS.pcc);
            Rpcc["idsor01"] = idsor01;
            Rpcc["idsor02"] = idsor02;
            Rpcc["idsor03"] = idsor03;
            Rpcc["idsor04"] = idsor04;
            Rpcc["idsor05"] = idsor05;
            //Salva dati Invio
            if (chkInvio.Checked) {
                //crea righe di pccsend 
                MetaData MetaPccsend = Meta.Dispatcher.Get("pccsend");
                MetaPccsend.SetDefaults(DS.pccsend);

                foreach (DataRow R in Inviocopy.Select()) {
                    DataRow Rpccsend = MetaPccsend.Get_New_Row(Rpcc, DS.pccsend);
                    Rpccsend["idpcc"] = Rpcc["idpcc"];
                    Rpccsend["yinv"] = R["yinv"];
                    Rpccsend["ninv"] = R["ninv"];
                    Rpccsend["idinvkind"] = R["idinvkind"];
                    Rpccsend["ycon"] = R["ycon"];
                    Rpccsend["ncon"] = R["ncon"];
                    Rpccsend["yman"] = R["yman"];
                    Rpccsend["nman"] = R["nman"];
                    Rpccsend["idmankind"] = R["idmankind"];
                    Rpccsend["idreg"] = R["idreg"];
                    Rpccsend["taxabletotal"] = R["imponibiletotaledocumento"];
                    Rpccsend["taxtotal"] = R["ivatotaledocumento"];
                    Rpccsend["rate"] = R["aliquotaiva"];
                    Rpccsend["idfenature"] = R["natura"];

                    Rpccsend["taxabletotalbyiva"] = R["imponibile"];
                    Rpccsend["taxtotalbyiva"] = R["imposta"];
                    Rpccsend["amountcigcup"] = R["importopercigcup"];
                    Rpccsend["cigcode"] = R["codicecig"];
                    Rpccsend["cupcode"] = R["codicecup"];
                    Rpccsend["idreg"] = R["idreg"];
                }

                foreach (DataRow R in Inviocopy.Select()) {
                    string filterFatturaC = QHC.AppAnd(QHC.CmpEq("idinvkind", R["idinvkind"]),
                        QHC.CmpEq("yinv", R["yinv"]), QHC.CmpEq("ninv", R["ninv"]));
                    if (DS.invoice.Select(filterFatturaC).Length == 0) {
                        string filterFatturaS = QHS.AppAnd(QHS.CmpEq("idinvkind", R["idinvkind"]),
                            QHS.CmpEq("yinv", R["yinv"]), QHS.CmpEq("ninv", R["ninv"]));
                        DataAccess.RUN_SELECT_INTO_TABLE(Conn, DS.invoice, null, filterFatturaS, null, true);
                    }

                }
                foreach (DataRow Rinv in DS.invoice.Select())
                    Rinv["resendingpcc"] = "N";
            }

            //Salva dati Operazioni
            if (chkSID.Checked || chkScadenza.Checked || chkMI.Checked || chkIP.Checked) {

                if (Operazionicopy!=null && Operazionicopy.Select(QHC.CmpEq("azione", "SID")).Length > 0) {
                    MetaData MetaPccDocamountvar = Meta.Dispatcher.Get("pccdocamountvar");
                    MetaPccDocamountvar.SetDefaults(DS.pccdocamountvar);
                    foreach (DataRow R in Operazionicopy.Select(QHC.CmpEq("azione", "SID"))) {
                        DataRow RpccDocamountvar = MetaPccDocamountvar.Get_New_Row(Rpcc, DS.pccdocamountvar);
                        RpccDocamountvar["idpcc"] = Rpcc["idpcc"];
                        RpccDocamountvar["yinv"] = R["yinv"];
                        RpccDocamountvar["ninv"] = R["ninv"];
                        RpccDocamountvar["idinvkind"] = R["idinvkind"];
                        RpccDocamountvar["idpccdebitstatusdetail"] = R["idpccdebitstatusdetail"];

                        string filterPCCdebit = QHS.AppAnd(QHS.CmpEq("idpccdebitstatusdetail", R["idpccdebitstatusdetail"]),
                            QHS.CmpEq("idinvkind", R["idinvkind"]), QHS.CmpEq("yinv", R["yinv"]), QHS.CmpEq("ninv", R["ninv"]));
                        DataAccess.RUN_SELECT_INTO_TABLE(Conn, DS.pccdebitstatusdetail, null, filterPCCdebit, null, true);
                    }
                    foreach (DataRow Rpccdebit in DS.pccdebitstatusdetail.Select())
                        Rpccdebit["idpcc"] = Rpcc["idpcc"];

                }

                if (Operazionicopy != null && Operazionicopy.Select(QHC.CmpEq("azione", "CS")).Length > 0) {
                    MetaData MetaPccExpiring = Meta.Dispatcher.Get("pccexpiring");
                    MetaPccExpiring.SetDefaults(DS.pccexpiring);
                    foreach (DataRow R in Operazionicopy.Select(QHC.CmpEq("azione", "CS"))) {
                        DataRow RpccExpiring = MetaPccExpiring.Get_New_Row(Rpcc, DS.pccexpiring);
                        RpccExpiring["idpcc"] = Rpcc["idpcc"];
                        RpccExpiring["yinv"] = R["yinv"];
                        RpccExpiring["ninv"] = R["ninv"];
                        RpccExpiring["idinvkind"] = R["idinvkind"];
                        RpccExpiring["ycon"] = DBNull.Value;
                        RpccExpiring["ncon"] = DBNull.Value;
                        RpccExpiring["yman"] = DBNull.Value;
                        RpccExpiring["nman"] = DBNull.Value;
                        RpccExpiring["idmankind"] = DBNull.Value;
                        RpccExpiring["amount"] = DBNull.Value;
                        RpccExpiring["expiringdate"] = R["datascadenza"];
                        RpccExpiring["manrownum"] = DBNull.Value;
                        RpccExpiring["invrownum"] = DBNull.Value;
                    }
                }
                if (Operazionicopy != null && Operazionicopy.Select(QHC.CmpEq("azione", "MI")).Length > 0) {
                    MetaData MetaPccSplitPayment = Meta.Dispatcher.Get("pccsplitpayment");
                    MetaPccSplitPayment.SetDefaults(DS.pccsplitpayment);
                    foreach (DataRow R in Operazionicopy.Select(QHC.CmpEq("azione", "MI"))) {
                        DataRow RpccSplitPayment = MetaPccSplitPayment.Get_New_Row(Rpcc, DS.pccsplitpayment);
                        RpccSplitPayment["idpcc"] = Rpcc["idpcc"];
                        RpccSplitPayment["yinv"] = R["yinv"];
                        RpccSplitPayment["ninv"] = R["ninv"];
                        RpccSplitPayment["idinvkind"] = R["idinvkind"];
                        RpccSplitPayment["flag_enable_split_payment"] = R["flagsplit"];
                    }
                }
				if (OperazioniPagamentocopy!=null && OperazioniPagamentocopy.Select(QHC.CmpEq("azione", "IP")).Length > 0) {
					MetaData MetaPccPayment = Meta.Dispatcher.Get("pccpayment");
					MetaPccPayment.SetDefaults(DS.pccpayment);
					foreach (DataRow R in OperazioniPagamentocopy.Select(QHC.CmpEq("azione", "IP"))) {
						DataRow RpccPayment = MetaPccPayment.Get_New_Row(Rpcc, DS.pccpayment);
						RpccPayment["idpcc"] = Rpcc["idpcc"];
						RpccPayment["yinv"] = R["yinv"];
						RpccPayment["ninv"] = R["ninv"];
						RpccPayment["idinvkind"] = R["idinvkind"];
						RpccPayment["ycon"] = DBNull.Value;
                        RpccPayment["ncon"] = DBNull.Value;
                        RpccPayment["yman"] = DBNull.Value;
                        RpccPayment["nman"] = DBNull.Value;
                        RpccPayment["idmankind"] = DBNull.Value;
                        RpccPayment["description"] = R["descrizione"];
                        RpccPayment["expensekind"] = R["naturadispesa"];
						RpccPayment["idfin"] = DBNull.Value; 
						RpccPayment["idexp"] = DBNull.Value;
                        RpccPayment["kpay"] = R["kpay"];
                        RpccPayment["idpettycash"] = R["idpettycash"];
						RpccPayment["yoperation"] = R["yoperation"];
						RpccPayment["noperation"] = R["noperation"];
						RpccPayment["amount"] = R["importopagato"];
						RpccPayment["cigcode"] = R["codicecig"];
						RpccPayment["cupcode"] = R["codicecup"];
					}
				}
			}

            Easy_PostData EP = new Easy_PostData();
            EP.InitClass(DS, Conn);
            bool res = EP.DO_POST();
            if (res) {
                GeneraFile(Rpcc["idpcc"]);
                ScriviFileNelDB();
                //Process.Start(NomeCompletoFileCSV);//Apre il file creato. L'ho commentato perchè non piace 
                return;
            }
        }


        private void RemoveColumns(DataTable TfileInvio, string kind) {
            if (kind == "I") {
                if ((TfileInvio != null) && (TfileInvio.Rows.Count == 0))
                    return;
                List<string> colonne_da_non_esportare = new List<string>(
                    new string[] {
                        "idinvkind", "yinv", "ninv", "rownuminv", "invoicekind",
                        "idmankind", "yman", "nman", "rownumman", "mandatekind",
                        "ycon", "ncon",
                        "idreg","datacontabiledocumento"
                    });

                foreach (string S in colonne_da_non_esportare) {
                    if (TfileInvio.Columns.Contains(S))
                        TfileInvio.Columns.Remove(S);
                }
            }
            if (kind == "O") {
                if ((TfileOperazioni != null) && (TfileOperazioni.Rows.Count == 0))
                    return;
                List<string> colonne_da_non_esportare = new List<string>(
                    new string[] {
                        "idinvkind", "yinv", "ninv", "invrownum", "invoicekind",
                        "idmankind", "yman", "nman", "manrownum", "mandatekind",
                        "ycon", "ncon",
                        "idreg", "DenominazioneFornitore", "idfin", "idexp", "kpay",
                        "idpettycash", "yoperation", "noperation","datacontabiledocumento"
                    });

                foreach (string S in colonne_da_non_esportare) {
                    if (TfileOperazioni.Columns.Contains(S))
                        TfileOperazioni.Columns.Remove(S);
                }
            }
			if (kind == "P") {
                if ((TfileOperazioniPagamento != null) && (TfileOperazioniPagamento.Rows.Count == 0))
                    return;
                List<string> colonne_da_non_esportare = new List<string>(
                    new string[] {
                        "idinvkind", "yinv", "ninv", "invrownum", "invoicekind",
                        "idmankind", "yman", "nman", "manrownum", "mandatekind",
                        "ycon", "ncon",
                        "descrizione",
                        "idreg", "DenominazioneFornitore", "idfin", "idexp", "kpay",
                        "idpettycash", "yoperation", "noperation","datacontabiledocumento"
                    });

                foreach (string S in colonne_da_non_esportare) {
                    if (TfileOperazioniPagamento.Columns.Contains(S))
                        TfileOperazioniPagamento.Columns.Remove(S);
                }
            }
        }

        private void RiempiTabellaOperazioni() {
			if (chkIP.Checked) {
                if (TpccsendPayment == null || TpccsendPayment.Rows.Count == 0)
                    return;
                TfileOperazioniPagamento = Dati_OperazioniPagamento();
                //rimuove colonne non presenti nel tracciato
                RemoveColumns(TfileOperazioni, "P");

            }
            else {
                if (Tpccsendoperation == null || Tpccsendoperation.Rows.Count == 0)
                      return;

                TfileOperazioni = Dati_Operazioni();
                //rimuove colonne non presenti nel tracciato
                RemoveColumns(TfileOperazioni, "O");
            }

        }

        private void RiempiTabellaInvio() {
            if (Tpccsend == null || Tpccsend.Rows.Count == 0)
                return;
            TfileInvio = Dati_Invio();

            //rimuove colonne non presenti nel tracciato
            RemoveColumns(TfileInvio, "I");
        }

        private void faiScegliereCartella() {
            DialogResult dr = folderBrowserDialog1.ShowDialog(this);
            if (dr == DialogResult.OK) {
                txtPercorso.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void GeneraFile(object idpcc) {
            // Crea il file .CSV contenente le fatture/contratti da trasmettere
            DataTable DT = null;
            string headerKind = "";
            if (chkInvio.Checked) {
                //DT = TfileInvio;
                DT = CalcTFileGrouped(TfileInvio, "I");
                foreach (DataRow R in DT.Select()) {
                    R["lotto"] = idpcc;
                }
                headerKind = "I";
            }
            else {
                    if (chkIP.Checked) {
                        DT = CalcTFileGrouped(TfileOperazioniPagamento, "P");
                        headerKind = "P";
                }
                    if (chkSID.Checked || chkScadenza.Checked || chkMI.Checked) {
                        DT = CalcTFileGrouped(TfileOperazioni, "O");
                        headerKind = "O";
                }
            }

            //  FGTFRT76S26H501J_YYYYMMGG.CSV
            string DataNow = DateTime.Now.Millisecond.ToString();
                // .ToString("yyyyMMdd");non va bene se in un gg generano 2 file

            CFTrasmittente = Conn.DO_READ_VALUE("registry", QHS.CmpEq("idreg", idreg), "cf").ToString();
            string suffisso = "";
            if (chkInvio.Checked) {
                suffisso = "I";
            }
            else {
                suffisso = "O";
            }
            NomeFile = CFTrasmittente + "_" + DataNow + suffisso + ".csv";
            NomeCompletoFileCSV = Path.Combine(txtPercorso.Text, NomeFile);
            try {
                File.Copy(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, NomeFile), NomeCompletoFileCSV, true);
            }
            catch {
            }
            txtPercorso.Text = NomeCompletoFileCSV;

            try {
                string S = MyDataTableToCSV(DT, false, headerKind);
                    // il secondo parametro è l'header, ma impostato a false
                StreamWriter SWR = new StreamWriter(NomeCompletoFileCSV, false, Encoding.Default);
                SWR.Write(S);
                SWR.Close();
                SWR.Dispose();
            }
            catch (Exception E) {
                QueryCreator.ShowException(E);
            }
        }

        private static string format(object o) {
            if (o == null || o == DBNull.Value)
                return "";
            if (o.GetType() == typeof(DateTime)) return FormatData((DateTime) o);
            if (o.GetType() == typeof(Decimal)) return FormatDecimal((Decimal) o);
            string val = o.ToString();
            if (val.IndexOf("\"") >= 0 || val.IndexOf(";") >= 0 || val.IndexOf("\r") >= 0 || val.IndexOf("\n") >= 0) {
                val = "\"" + val.Replace("\"", "\"\"") + "\"";
            }
            return val;
        }

        private static string FormatData(DateTime Data) {
            return Data.Day.ToString().PadLeft(2, '0') + "/" + Data.Month.ToString().PadLeft(2, '0') + "/" +
                   Data.Year.ToString();
        }

        private static string FormatDecimal(Decimal d) {
            return d.ToString("F2", CultureInfo.InvariantCulture);
        }

        public string ScriviIntestazione(string HeaderKind) {
            //string CFTrasmittente0 = Conn.DO_READ_VALUE("registry", QHS.CmpEq("idreg", idreg), "cf").ToString();
            string valore = "";
            if (HeaderKind == "I") {
                valore = "0;0;0;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;" + "\r\n" +
                         "Codice del modello;002 - UTENTE PA - RICEZIONE FATTURE;;i campi contrassegnati da * sono obbligatori;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;" +
                         "\r\n" +
                         "Versione del modello;1;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;" + "\r\n" +
                         "Utente che trasmette il file (Codice Fiscale);" + CFTrasmittente +
                         ";;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;" + "\r\n" +
                         "DATI AMMINISTRAZIONE (SDI 1.4 CessionarioCommittente);;;DATI FORNITORE (SDI 1.2 CedentePrestatore);;;LOTTO;DATI FATTURA;;;;;;;;;;;;;;;;;;;;;;ESITO ELABORAZIONE;;;;;;;;;;;;;;;;;;;;;;" +
                         "\r\n" +
                         "Codice Fiscale* - Specificare il Codice Fiscale della Amministrazione destinataria del documento (SDI 1.4.1.2 CodiceFiscale);Codice Ufficio* - Specificare il Codice Univoco Ufficio di IPA oppure il Codice Ufficio PCC (SDI   1.1.4 CodiceDestinatario);Denominazione Amministrazione* - Specificare la denominazione dell'Amministrazione destinataria del documento (SDI 1.4.1.3 Anagrafica); Codice Fiscale* - Specificare il Codice Fiscale del Fornitore che ha emesso il documento (SDI  1.2.1.2 CodiceFiscale);Id Fiscale IVA* - Specificare il numero di identificazione fiscale ai fini IVA nel formato IT12345678901  (SDI  1.2.1.1 IdFiscaleIVA);Denominazione Fornitore* - Specificare la denominazione del Fornitore che ha emesso il documento (SDI 1.2.1.3 Anagrafica);Descrizione distinta o lotto* - Specificare una descrizione o numero relativo all'invio  (SDI 1.1.2 ProgressivoInvio);DATI GENERALI (SDI 2.1 DatiGenerali);;;;;;;;RIEPILOGO ALIQUOTE (SDI 2.2.2 DatiRiepilogo);;;;DISTRIBUZIONE PER CIG/CUP (SDI 2.2.1 DettaglioLinee);;;DETTAGLIO PAGAMENTO (SDI 2.4.2 DettaglioPagamento);;;;RICEZIONE;;;Forzatura immissione - Consente di specificare l'azione da eseguire nei casi di segnalazione di sospetto duplicato.  AG: Aggiungi la fattura come nuova /  SO: Sovrascivi la fattura già presente;Codice segnalazione;Descrizione segnalazione;;;;;;;;;;;;;;;;;;;;" +
                         "\r\n" +
                         ";;;;;;;Tipo Documento* - Specificare TD01: fattura /  TD02: acconto/anticipo su fattura /  TD03: acconto/anticipo su parcella /  TD04: nota di credito /  TD05: nota di debito /  TD06: parcella (SDI 2.1.1.1 TipoDocumento);Numero fattura* (SDI 2.1.1.4 Numero);Data emissione* (SDI 2.1.1.3 Data);Importo totale documento* (SDI 2.1.1.9 ImportoTotaleDocumento);Descrizione / Causale* (SDI 2.1.1.11 Causale);Art. 73 - Specificare SI  - Documento emesso secondo le modalità stabilite con DM ai sensi dell'art. 73 DPR 633/72 (SDI  2.1.1.12 Art73);Totale imponibile della fattura* (SDI  somma di 2.2.2.5 ImponibileImporto);Totale imposta della fattura* (SDI  somma di 2.2.2.6 Imposta);Aliquota IVA (SDI 2.2.2.1 AliquotaIVA);Codice Esenzione IVA (SDI 2.2.2.2 Natura);Totale Imponibile per aliquota (SDI 2.2.2.5 Imposta);Totale Imposta per aliquota (SDI 2.2.2.6 Imposta);Importo per CIG/CUP (SDI Somma di 2.2.1.11 PrezzoTotale + applicazione 2.2.1.12 AliquotaIVA);Codice CIG - Codice Identificativo della gara (SDI  2.1.2.7 CIG);Codice CUP - Codice Unitario Progetto (SDI 2.1.2.6 CUP);Data riferimento termini di pagamento - Specificare la data dalla quale decorrono i termini di pagamento (SDI 2.4.2.3 DataRiferimentoTerminiPagamento);Giorni termini pagamento - Specificare il numero di giorni entro i quali sarà effettuato il pagamento  (SDI 2.4.2.4 GiorniTerminiPagamento);Data scadenza pagamento (SDI 2.4.2.5 DataScadenzaPagamento);Importo Pagamento (SDI 2.4.2.6 ImportoPagamento);Numero Protocollo in Entrata;Data ricezione - Specificare la data di ricezione da parte della PA. Se omessa, viene assunta come data di ricezione quella in cui viene caricato il file;Note;;;;;;;;;;;;;;;;;;;;;;;" +
                         "\r\n";
            }
            if (HeaderKind == "O") {
                valore =
                    ";;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;" + "\r\n" +
                    "Codice del modello;GESTIONE IMPORTI DOCUMENTI;;i campi contrassegnati da * sono obbligatori;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;" + "\r\n" +
                    "Versione del modello;1;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;" + "\r\n" +
                    "Utente che trasmette il file (Codice Fiscale);" + CFTrasmittente + ";;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;" + "\r\n" +
                    "DATI IDENTIFICATIVI FATTURA*;;;;;;TIPO OPERAZIONE*;VARIAZIONE IMPORTI DOCUMENTI Tutti i campi sono obbligatori Sezione da compilare solo per le righe del modello per le quali Azione = 'SID';;;;;;;;;;REGIME IVA Sezione da compilare solo per le righe del modello per le quali Azione = 'MI';RICEZIONE / RIFIUTO / COMUNICAZIONE SCADENZA Sezione da compilare solo per le righe del modello per le quali Azione = 'RC' Azione = 'RF' Azione = 'CS';;ESITO ELABORAZIONE;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;" + "\r\n" +
                    "IDENTIFICATIVO 1;;IDENTIFICATIVO 3 ;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;" + "\r\n" +
                    "Numero progressivo di registrazione;IDENTIFICATIVO 2 ;;Data documento (SDI 2.1.1.3 Data);Codice fiscale fornitore;Codice ufficio;Azione ;Imponibile;Imposta;Importo non commerciale*;Importo sospeso in Contenzioso*;Data inizio sospesione in Contenzioso*;Importo sospeso in contestazione/adempimenti normativi*;Data inizio sospesione in contestazione /adempimenti normativi*;Importo sospeso per data esito regolare verifica di conformità*;Data inizio sospensione per data esito regolare verifica di conformità*;Importo non liquidabile*;Flag split (S/N);Data;Numero protocollo di entrata;Codice segnalazione;Descrizione segnalazione;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;" + "\r\n" +
                    ";Lotto SDI;Numero fattura(SDI 2.1.1.4 Numero);;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;" + "\r\n";
            }
            if (HeaderKind == "P") {
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

        public string MyDataTableToCSV( System.Data.DataTable DT, bool Header, string HeaderKind) {
            if (DT.Rows.Count == 0)
                return "";
            string separator = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ListSeparator;

            DataRow[] Rows = DT.Select(null,
                (string) DT.ExtendedProperties["ExcelSort"]);

            string crlf = "\r\n";
            StringBuilder SB = new StringBuilder();
            string Intestazione = ScriviIntestazione(HeaderKind);
            SB.Append(Intestazione);

            string variabile = "";
            foreach (DataRow r in DT.Rows) {
                foreach (DataColumn C in DT.Columns) {
                    if ((C.ColumnName == "nriga") || (C.ColumnName == "idinvkind")|| (C.ColumnName == "yinv")|| (C.ColumnName == "D.ninv")) {
                        continue;
					}
                        //if (C.ColumnName == "npay") {
                        //    //se è valorizzata Piccolaspesa allora comunicheramo il numero dlela piccola spesa, altrimenti il numero del mandato
                        //    if (r["piccolaspesa"].ToString() != "") {
                        //        variabile = format(r["piccolaspesa"]);
                        //    }
                        //    else {
                        //        variabile = format(r[C]);
                        //    }
                        //    SB.Append(variabile + separator);
                        //    continue;
                        //}

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

        private void ScriviFileNelDB() {
            DataRow Curr = DS.pcc.Rows[0];

            FileStream FS = new FileStream(NomeCompletoFileCSV, FileMode.Open, FileAccess.Read);
            int n = (int) FS.Length;
            if (n == 0) {
                //Curr["attachment"] = DBNull.Value;
                return;
            }
            byte[] ByteArray = new byte[n];
            FS.Read(ByteArray, 0, n);
            if (FS.Length == 0) {
                //Curr["attachment"] = DBNull.Value;
            }

            FS.Close();
            //Curr["attachment"] = ByteArray;
            //string script = "update pcc set attachment = " + QHS.quote(ByteArray) + " where " + QHS.CmpEq("idpcc", Curr["idpcc"]);
            string script = "update pcc set attachment = " + QHS.quote(ByteArray) + " , filename = " +
                            QHS.quote(NomeFile) + " where " + QHS.CmpEq("idpcc", Curr["idpcc"]);

            Meta.Conn.SQLRunner(script);
        }

        private DataRow[] GetGridSelectedRows() {
            string TableName = gridDettagli.DataMember.ToString();
            DataSet MyDS = (DataSet) gridDettagli.DataSource;
            DataTable MyTable = MyDS.Tables[TableName];
            int numrighetemp = MyTable.Rows.Count;
            int numrighe = 0;
            int i;
            for (i = 0; i < numrighetemp; i++) {
                if (gridDettagli.IsSelected(i)) {
                    numrighe++;
                }
            }

            DataRow[] Res = new DataRow[numrighe];
            int count = 0;
            for (i = 0; i < numrighetemp; i++) {
                if (gridDettagli.IsSelected(i)) {
                    Res[count++] = GetDetailRow(i);
                }
            }
            return Res;
        }

        DataRow GetDetailRow(int index) {
            string TableName = gridDettagli.DataMember.ToString();
            DataSet MyDS = (DataSet) gridDettagli.DataSource;
            DataTable MyTable = MyDS.Tables[TableName];
            string filter = QHC.CmpEq("nriga", gridDettagli[index, 0]);
            DataRow[] selectresult = MyTable.Select(filter);
            return selectresult[0];
        }

        private void creaTableRiepilogoAliquota() {
            myRiepilogoaliquote = new DataTable();
            myRiepilogoaliquote.TableName = "riepilogoaliquote";

            myRiepilogoaliquote.Columns.Add("idinvkind");
            myRiepilogoaliquote.Columns.Add("yinv");
            myRiepilogoaliquote.Columns.Add("ninv");
            myRiepilogoaliquote.Columns.Add("aliquotaiva", typeof(decimal));
            myRiepilogoaliquote.Columns.Add("natura");
            myRiepilogoaliquote.Columns.Add("imponibile", typeof(decimal));
            myRiepilogoaliquote.Columns.Add("imposta", typeof(decimal));
        }

        private void creaTableRiepilogoCigcup() {
            myRiepilogoCigCup = new DataTable();
            myRiepilogoCigCup.TableName = "riepilogocigcup";

            myRiepilogoCigCup.Columns.Add("idinvkind");
            myRiepilogoCigCup.Columns.Add("yinv");
            myRiepilogoCigCup.Columns.Add("ninv");
            myRiepilogoCigCup.Columns.Add("importopercigcup", typeof(decimal));
            myRiepilogoCigCup.Columns.Add("codicecig");
            myRiepilogoCigCup.Columns.Add("codicecup");
        }

        private void creaTableInvio() {
            Invio = new DataTable();
            Invio.CaseSensitive = false;
            Invio.TableName = "invio";

            Invio.Columns.Add("CFAmmin");
            //Invio.Columns.Add("PivaAmmin");
            Invio.Columns.Add("IPA");
            Invio.Columns.Add("agencyname");
            Invio.Columns.Add("idinvkind");
            Invio.Columns.Add("idmankind");
            Invio.Columns.Add("idreg");

            Invio.Columns.Add("CFfornitore");
            Invio.Columns.Add("IdFiscaleIvaFornitore");
            Invio.Columns.Add("DenominazioneFornitore");
            Invio.Columns.Add("invoicekind");
            Invio.Columns.Add("yinv");
            Invio.Columns.Add("ninv");
            Invio.Columns.Add("rownuminv");
            Invio.Columns.Add("mandatekind");
            Invio.Columns.Add("yman");
            Invio.Columns.Add("nman");
            Invio.Columns.Add("rownumman");
            Invio.Columns.Add("ycon");
            Invio.Columns.Add("ncon");

            Invio.Columns.Add("lotto");
            Invio.Columns.Add("tipodocumento");
            Invio.Columns.Add("numerodocumento");
            Invio.Columns.Add("dataemissione", typeof(DateTime));
            Invio.Columns.Add("importototaledocumento", typeof(decimal));
            Invio.Columns.Add("causale");
            Invio.Columns.Add("Art73");
            Invio.Columns.Add("Imponibiletotaledocumento", typeof(decimal));
            Invio.Columns.Add("ivatotaledocumento", typeof(decimal));
            Invio.Columns.Add("aliquotaiva", typeof(decimal));
            Invio.Columns.Add("natura");
            Invio.Columns.Add("imponibile", typeof(decimal));
            Invio.Columns.Add("imposta", typeof(decimal));
            Invio.Columns.Add("importopercigcup", typeof(decimal));
            Invio.Columns.Add("codicecig");
            Invio.Columns.Add("codicecup");
            Invio.Columns.Add("datariferimentopagamento", typeof(DateTime));
            Invio.Columns.Add("giorniterminipagamento");
            Invio.Columns.Add("datascadenzapagamento", typeof(DateTime));
            Invio.Columns.Add("importopagamento", typeof(decimal));
            Invio.Columns.Add("numprotocolloentrata");
            Invio.Columns.Add("dataricezione", typeof(DateTime));
            Invio.Columns.Add("note");
            Invio.Columns.Add("forzaturaimissione");
            Invio.Columns.Add("codicesegnalazione");
            Invio.Columns.Add("descrizionesegnalazione");
        }

        private void creaTableOperazioni() {
            Operazioni = new DataTable();
            Operazioni.TableName = "operazioni";

            Operazioni.Columns.Add("nriga");
            Operazioni.Columns.Add("invoicekind"); // to del
            Operazioni.Columns.Add("idinvkind"); // to del
            Operazioni.Columns.Add("yinv"); // to del
            Operazioni.Columns.Add("ninv"); // to del
            Operazioni.Columns.Add("idpccdebitstatusdetail");
            //IDENTIFICATIVO 1
            Operazioni.Columns.Add("IDENTIFICATIVO_1");

            //IDENTIFICATIVO 2
            Operazioni.Columns.Add("IDENTIFICATIVO_2_a");   //  identificativo Sdi
            Operazioni.Columns.Add("IDENTIFICATIVO_2_b");  //  2.1.1.4   <Numero> 

            //IDENTIFICATIVO 3
            Operazioni.Columns.Add("IDENTIFICATIVO_3_a", typeof(DateTime));
            Operazioni.Columns.Add("IDENTIFICATIVO_3_b");	//Codice fiscale fornitore
            Operazioni.Columns.Add("IDENTIFICATIVO_3_c");   //Codice ufficio

            // SID
            Operazioni.Columns.Add("azione");
            Operazioni.Columns.Add("imponibile", typeof(decimal)); //NON LO STRASMETTIAMO
            Operazioni.Columns.Add("imposta", typeof(decimal)); //NON La STRASMETTIAMO
            Operazioni.Columns.Add("importononcommerciale", typeof(decimal));
            
            Operazioni.Columns.Add("imp_sosp_contenzioso", typeof(decimal));
            Operazioni.Columns.Add("iva_sosp_contenzioso", typeof(decimal));
            Operazioni.Columns.Add("importo_sosp_contenzioso", typeof(decimal));
            Operazioni.Columns.Add("start_sosp_contenzioso", typeof(DateTime));
            
            Operazioni.Columns.Add("imp_sosp_contestazione", typeof(decimal));
            Operazioni.Columns.Add("iva_sosp_contestazione", typeof(decimal));
            Operazioni.Columns.Add("importo_sosp_contestazione", typeof(decimal));
            Operazioni.Columns.Add("start_sosp_contestazione", typeof(DateTime));
            
            Operazioni.Columns.Add("imp_sosp_regolareverifica", typeof(decimal));
            Operazioni.Columns.Add("iva_sosp_regolareverifica", typeof(decimal));
            Operazioni.Columns.Add("importo_sosp_regolareverifica", typeof(decimal));
            Operazioni.Columns.Add("start_sosp_regolareverifica", typeof(DateTime));

            Operazioni.Columns.Add("imp_nonliquidabile", typeof(decimal));
            Operazioni.Columns.Add("iva_nonliquidabile", typeof(decimal));
            Operazioni.Columns.Add("importo_nonliquidabile", typeof(decimal));

            //REGIME IVA
            Operazioni.Columns.Add("flagsplit");

            //SCADENZA
            Operazioni.Columns.Add("datascadenza", typeof(DateTime));
            Operazioni.Columns.Add("NmeroProcotolloEntrata");
            //Sezione Esito Eleborazione
            Operazioni.Columns.Add("codicesegnalazione");
            Operazioni.Columns.Add("descrizionesegnalazione");
     
        }

        private void creaTableOperazioniPagamenti() {
            //NUOVO
            OperazioniPagamento = new DataTable();
            OperazioniPagamento.TableName = "pagamenti";

            OperazioniPagamento.Columns.Add("nriga");
            OperazioniPagamento.Columns.Add("invoicekind"); // to del
            OperazioniPagamento.Columns.Add("idinvkind"); // to del
            OperazioniPagamento.Columns.Add("yinv"); // to del
            OperazioniPagamento.Columns.Add("ninv"); // to del
            //IDENTIFICATIVO 1
            OperazioniPagamento.Columns.Add("IDENTIFICATIVO_1");

            //IDENTIFICATIVO 2
            OperazioniPagamento.Columns.Add("IDENTIFICATIVO_2_a");   //  identificativo Sdi
            OperazioniPagamento.Columns.Add("IDENTIFICATIVO_2_b");  //  2.1.1.4   <Numero> 

            //IDENTIFICATIVO 3
            OperazioniPagamento.Columns.Add("IDENTIFICATIVO_3_a", typeof(DateTime));
            OperazioniPagamento.Columns.Add("IDENTIFICATIVO_3_b");	//Codice fiscale fornitore
            OperazioniPagamento.Columns.Add("IDENTIFICATIVO_3_c");   //Codice ufficio

            // IP
            OperazioniPagamento.Columns.Add("azione");
            //
            OperazioniPagamento.Columns.Add("IdPagamento");
            OperazioniPagamento.Columns.Add("Tipodebito");
            OperazioniPagamento.Columns.Add("descrizione");
            OperazioniPagamento.Columns.Add("importopagato", typeof(decimal));
            OperazioniPagamento.Columns.Add("naturadispesa");
            OperazioniPagamento.Columns.Add("kpay");
            OperazioniPagamento.Columns.Add("idpettycash"); // to del
            OperazioniPagamento.Columns.Add("yoperation"); // to del
            OperazioniPagamento.Columns.Add("noperation"); // to del
            OperazioniPagamento.Columns.Add("npay", typeof(int));
            OperazioniPagamento.Columns.Add("paymentdate", typeof(DateTime));
            OperazioniPagamento.Columns.Add("IdFiscaleIvaFornitore");
            OperazioniPagamento.Columns.Add("codicecig");
            OperazioniPagamento.Columns.Add("codicecup");
            OperazioniPagamento.Columns.Add("PagamentoOPI");
            OperazioniPagamento.Columns.Add("PagamentoIVA");
            OperazioniPagamento.Columns.Add("Giornidisospensioneeffettivi");

            //Sezione Esito Eleborazione
            OperazioniPagamento.Columns.Add("codicesegnalazione");
            OperazioniPagamento.Columns.Add("descrizionesegnalazione");
        }


        private DataTable CalcTFileGrouped(DataTable TFile, string kind) {
            if ((TFile == null) && (TFile.Rows.Count == 0)) return TFile;
            //1) Scorro le righe dettagliate restituite dalla stored procedure
            DataTable TFileGrouped = TFile.Clone();
            List<string> colonne_da_non_esportare = new List<string>();
            if (kind == "I") {
                colonne_da_non_esportare = new List<string>(
                    new string[] {
                        "idinvkind", "yinv", "ninv", "rownuminv", "invoicekind",
                        "idmankind", "yman", "nman", "rownumman", "mandatekind",
                        "ycon", "ncon",
                        "idreg"
                    });
            }
            if (kind == "O") {
                colonne_da_non_esportare = new List<string>(
                    new string[] {
                        "nriga","idinvkind", "yinv", "ninv", "invoicekind",
                        "idreg", "idpccdebitstatusdetail",
                        "imp_sosp_contenzioso","iva_sosp_contenzioso",
                        "imp_sosp_contestazione","iva_sosp_contestazione",
                        "imp_sosp_regolareverifica","iva_sosp_regolareverifica",
                        "imp_nonliquidabile","iva_nonliquidabile" , "kpay",
                        "idpettycash", "yoperation", "noperation","descrizione"
                    });
            }
            if (kind == "P") {
                colonne_da_non_esportare = new List<string>(
                    new string[] {
                        "nriga","idinvkind", "yinv", "ninv", "invoicekind",
                        "idreg", "kpay",
                        "idpettycash", "yoperation", "noperation","descrizione"
                    });
            }
            foreach (string S in colonne_da_non_esportare) {
                if (TFileGrouped.Columns.Contains(S))
                    TFileGrouped.Columns.Remove(S);
            }


            //Riempio una seconda tabella  
            //raggruppando le righe 
            //TFile.Columns.Add("indice", typeof (Int32));
            //TFile.Columns.Add("nriga", typeof(Int32)); 

            //Crea le righe     raggruppate
            for (int i = 0; i < TFile.Rows.Count; i++) {
                DataRow R = TFile.Rows[i];

                string filter = "";
                if (kind == "I") {
                    filter = QHC.MCmp(R, "CFAmmin", "IPA", "agencyname", "CFfornitore",
                        "IdFiscaleIvaFornitore", "DenominazioneFornitore",
                        "lotto", "tipodocumento",
                        "numerodocumento", "dataemissione", "causale",
                        "importototaledocumento", "Imponibiletotaledocumento", "ivatotaledocumento",
                        "Art73", "aliquotaiva", "natura", "codicecig", "codicecup", "datariferimentopagamento",
                        "giorniterminipagamento", "datascadenzapagamento", "numprotocolloentrata", "dataricezione",
                        "note", "forzaturaimissione", "codicesegnalazione", "descrizionesegnalazione"
                        );
                }
                if (kind == "O") {
                    filter = QHC.MCmp(R, "IDENTIFICATIVO_2_a","IDENTIFICATIVO_2_b",
                            "IDENTIFICATIVO_3_a",    "IDENTIFICATIVO_3_b",        "IDENTIFICATIVO_3_c",
                            "azione"
                        );
                }
                if (kind == "P") {
                    filter = QHC.MCmp(R, "IDENTIFICATIVO_2_a", "IDENTIFICATIVO_2_b",
                            "IDENTIFICATIVO_3_a", "IDENTIFICATIVO_3_b", "IDENTIFICATIVO_3_c",
                            "azione","npay","codicecig", "codicecup"
                        );
                }
                DataRow[] RGrouped = TFileGrouped.Select(filter);
                if (RGrouped.Length == 0) {
                    DataRow NewR = AddRowToTableGrouped(R, TFileGrouped);
                }
                else {
                    if (kind == "I") {
                        RGrouped[0]["imponibile"] = CfgFn.GetNoNullDecimal(RGrouped[0]["imponibile"]) +
                                                    CfgFn.GetNoNullDecimal(R["imponibile"]);
                        RGrouped[0]["imposta"] = CfgFn.GetNoNullDecimal(RGrouped[0]["imposta"]) +
                                                 CfgFn.GetNoNullDecimal(R["imposta"]);
                        RGrouped[0]["importopercigcup"] = CfgFn.GetNoNullDecimal(RGrouped[0]["importopercigcup"]) +
                                                          CfgFn.GetNoNullDecimal(R["importopercigcup"]);
                        RGrouped[0]["importopagamento"] = CfgFn.GetNoNullDecimal(RGrouped[0]["importopagamento"]) +
                                                          CfgFn.GetNoNullDecimal(R["importopagamento"]);
                    }
                    //else {
                    //    RGrouped[0]["importodelmovimento"] =
                    //        CfgFn.GetNoNullDecimal(RGrouped[0]["importodelmovimento"]) +
                    //        CfgFn.GetNoNullDecimal(R["importodelmovimento"]);
                    //    RGrouped[0]["importopagato"] = CfgFn.GetNoNullDecimal(RGrouped[0]["importopagato"]) +
                    //                                   CfgFn.GetNoNullDecimal(R["importopagato"]);
                    //    RGrouped[0]["importoscadenza"] = CfgFn.GetNoNullDecimal(RGrouped[0]["importoscadenza"]) +
                    //                                     CfgFn.GetNoNullDecimal(R["importoscadenza"]);
                    //}
                }
            }

            return TFileGrouped;
        }

        private DataRow AddRowToTableGrouped(DataRow R, DataTable T) {
            DataRow NewR = T.NewRow();
            foreach (DataColumn C in T.Columns) {
                NewR[C.ColumnName] = R[C.ColumnName];
            }
            T.Rows.Add(NewR);
            return NewR;
        }
        private DataTable Dati_OperazioniPagamento() {
            //NUOVO
            DataRow[] selectedrows = GetGridSelectedRows();
            if ((selectedrows == null) || (selectedrows.Length == 0)) {
                selezionaTuttiIDettagli();
                selectedrows = GetGridSelectedRows();
            }
            creaTableOperazioniPagamenti();
            for (int i = 0; i < selectedrows.Length; i++) {
                DataRow Ri = selectedrows[i];
                AggiungiRigaOperazioniPagamento(Ri, OperazioniPagamento);
            }

            OperazioniPagamentocopy = OperazioniPagamento.Copy();

            return OperazioniPagamento;
        }
        private DataTable Dati_Operazioni() {

            DataRow[] selectedrows = GetGridSelectedRows();
            if ((selectedrows == null) || (selectedrows.Length == 0)) {
                selezionaTuttiIDettagli();
                selectedrows = GetGridSelectedRows();
            }
            creaTableOperazioni();
            // Le operazioni devono seguire un ordine preciso, perchè il sistema PCC processa le righe nell'ordine in cui vengono inserite
            // quindi CO-> CS->CP
            // non è possibile seguire un ordine alfabetico, quindi facciamo 3 cicli
            for (int i = 0; i < selectedrows.Length; i++) {
                DataRow Ri = selectedrows[i];
                if (Ri["azione"].ToString() != "SID") 
                    continue;
                AggiungiRigaOperazioni(Ri, Operazioni);
            }
            for (int i = 0; i < selectedrows.Length; i++) {
                DataRow Ri = selectedrows[i];
                if (Ri["azione"].ToString() != "CS")
                    continue;
                AggiungiRigaOperazioni(Ri, Operazioni);
            }
            for (int i = 0; i < selectedrows.Length; i++) {
                DataRow Ri = selectedrows[i];
                if (Ri["azione"].ToString() != "MI")
                    continue;
                AggiungiRigaOperazioni(Ri, Operazioni);
            }
            //for (int i = 0; i < selectedrows.Length; i++) {
            //    DataRow Ri = selectedrows[i];
            //    if (Ri["azione"].ToString() != "CP")
            //        continue;
            //    AggiungiRigaOperazioni(Ri, Operazioni);
            //}
            Operazionicopy = Operazioni.Copy();

            return Operazioni;

        }

        /// <summary>
        /// Metodo che calcola le righe da inserire nel file
        /// </summary>
        /// <param name="TableSPInvio">Tabella con tutti i documenti, rappresentati per dettaglio, da trasmettere</param>
        /// <returns>DataTable delle righe da trasmettere</returns>
        private DataTable Dati_Invio() {
            DataRow[] selectedrows = GetGridSelectedRows();
            if ((selectedrows == null) || (selectedrows.Length == 0)) {
                selezionaTuttiIDettagli();
                selectedrows = GetGridSelectedRows();
            }

            creaTableInvio();
            //foreach (DataColumn C in TableInvio.Columns) {
            //    if (!Invio.Columns.Contains(C.ColumnName))
            //        Invio.Columns.Add(C);
            //}

            string filterAliquotaDoc = "";
            string filterCigCupDoc = "";

            creaTableRiepilogoAliquota();
            creaTableRiepilogoCigcup();
            for (int i = 0; i < selectedrows.Length; i++) {
                DataRow Ri = selectedrows[i];

                //Riepilogo aliquota
                filterAliquotaDoc = QHC.AppAnd(QHC.CmpEq("idinvkind", Ri["idinvkind"]), QHC.CmpEq("yinv", Ri["yinv"]),
                    QHC.CmpEq("ninv", Ri["ninv"]),
                    QHC.CmpEq("aliquotaiva", Ri["aliquotaiva"]), QHC.CmpEq("natura", Ri["natura"]));
                DataRow Raliquota = null;
                if (!esisteRiga(filterAliquotaDoc, Invio)) {
                    Raliquota = RriepilogoAliquota(Ri, selectedrows);
                }

                //Distribuzione per CIG/CUP
                DataRow Rcigcup = null;
                if ((Ri["codicecig"] != DBNull.Value) || (Ri["codicecup"] != DBNull.Value)) {
                    filterCigCupDoc = QHC.AppAnd(QHC.CmpEq("idinvkind", Ri["idinvkind"]), QHC.CmpEq("yinv", Ri["yinv"]),
                        QHC.CmpEq("ninv", Ri["ninv"]),
                        QHC.CmpEq("codicecig", Ri["codicecig"]), QHC.CmpEq("codicecup", Ri["codicecup"]));
                    if (!esisteRiga(filterCigCupDoc, Invio)) {
                        Rcigcup = RriepilogoCigcup(Ri, selectedrows);
                    }
                }

                if (Raliquota != null || Rcigcup != null) {
                    AggiungiRigaInvio(Ri, Raliquota, Rcigcup, Invio);
                }

            }
            //DataTable Inviocopy;
            Inviocopy = Invio.Copy();

            return Invio;
        }

        private void AggiungiRigaOperazioniPagamento(DataRow Ri, DataTable OperazioniPagamento) {
            // NUOVO
            DataRow R = OperazioniPagamento.NewRow();
            R["nriga"] = Ri["nriga"];
            R["idinvkind"] = Ri["idinvkind"];
            R["yinv"] = Ri["yinv"];
            R["ninv"] = Ri["ninv"];
            R["invoicekind"] = Ri["invoicekind"];
            //IDENTIFICATIVO 1
            R["IDENTIFICATIVO_1"] = Ri["IDENTIFICATIVO_1"];

            //IDENTIFICATIVO 2
            R["IDENTIFICATIVO_2_a"] = Ri["IDENTIFICATIVO_2_a"];   //  identificativo Sdi
            R["IDENTIFICATIVO_2_b"] = Ri["IDENTIFICATIVO_2_b"];  //  2.1.1.4   <Numero> 

            //IDENTIFICATIVO 3
            R["IDENTIFICATIVO_3_a"] = Ri["IDENTIFICATIVO_3_a"];
            R["IDENTIFICATIVO_3_b"] = Ri["IDENTIFICATIVO_3_b"];	//Codice fiscale fornitore
            R["IDENTIFICATIVO_3_c"] = Ri["IDENTIFICATIVO_3_c"];   //Codice ufficio
            R["azione"] = Ri["azione"];
            R["IdPagamento"] = DBNull.Value; //Non lo valorizziamo
            R["Tipodebito"] = Ri["Tipodebito"];
            R["importopagato"] = Ri["importopagato"];
            R["naturadispesa"] = Ri["naturadispesa"];
            R["kpay"] = Ri["kpay"];
            R["npay"] = Ri["npay"];
            R["paymentdate"] = Ri["paymentdate"];
            R["IdFiscaleIvaFornitore"] = Ri["IdFiscaleIvaFornitore"];
            R["codicecig"] = Ri["codicecig"];
            R["codicecup"] = Ri["codicecup"];
            R["PagamentoOPI"] = DBNull.Value; //Non lo valorizziamo
            R["PagamentoIVA"] = DBNull.Value; //Non lo valorizziamo
            R["Giornidisospensioneeffettivi"] = DBNull.Value; //Non lo valorizziamo
            //Sezione Esito Eleborazione
            R["codicesegnalazione"] = DBNull.Value;
            R["descrizionesegnalazione"] = DBNull.Value;

            OperazioniPagamento.Rows.Add(R);
            OperazioniPagamento.AcceptChanges();
        }

        private void AggiungiRigaOperazioni(DataRow Ri, DataTable Operazioni) {
            DataRow R = Operazioni.NewRow();
            R["nriga"] = Ri["nriga"];
            R["idinvkind"] = Ri["idinvkind"];
            R["yinv"] = Ri["yinv"];
            R["ninv"] = Ri["ninv"];
            R["invoicekind"] = Ri["invoicekind"];
            R["idpccdebitstatusdetail"] = Ri["idpccdebitstatusdetail"];
            //IDENTIFICATIVO 1
            R["IDENTIFICATIVO_1"] = Ri["IDENTIFICATIVO_1"];
            
            //IDENTIFICATIVO 2
            R["IDENTIFICATIVO_2_a"] = Ri["IDENTIFICATIVO_2_a"];   //  identificativo Sdi
            R["IDENTIFICATIVO_2_b"] = Ri["IDENTIFICATIVO_2_b"];  //  2.1.1.4   <Numero> 

            //IDENTIFICATIVO 3
            R["IDENTIFICATIVO_3_a"] = Ri["IDENTIFICATIVO_3_a"];
            R["IDENTIFICATIVO_3_b"] = Ri["IDENTIFICATIVO_3_b"];	//Codice fiscale fornitore
            R["IDENTIFICATIVO_3_c"] = Ri["IDENTIFICATIVO_3_c"];   //Codice ufficio

            R["azione"] = Ri["azione"];
            // SID
            if (Ri["azione"].ToString() == "SID") {
                R["imponibile"] = DBNull.Value; //NON LO STRASMETTIAMO
                R["imposta"] = DBNull.Value; //NON La STRASMETTIAMO
                R["importononcommerciale"] = Ri["importononcommerciale"];
                //R["imp_sosp_contenzioso"] = Ri["imp_sosp_contenzioso"];
                //R["iva_sosp_contenzioso"] = Ri["iva_sosp_contenzioso"];
                R["importo_sosp_contenzioso"] = Ri["importo_sosp_contenzioso"];
                R["start_sosp_contenzioso"] = Ri["start_sosp_contenzioso"];
                //R["imp_sosp_contestazione"] = Ri["imp_sosp_contestazione"];
                //R["iva_sosp_contestazione"] = Ri["iva_sosp_contestazione"];
                R["importo_sosp_contestazione"] = Ri["importo_sosp_contestazione"];
                R["start_sosp_contestazione"] = Ri["start_sosp_contestazione"];
                //R["imp_sosp_regolareverifica"] = Ri["imp_sosp_regolareverifica"];
                //R["iva_sosp_regolareverifica"] = Ri["iva_sosp_regolareverifica"];
                R["importo_sosp_regolareverifica"] = Ri["importo_sosp_regolareverifica"];
                R["start_sosp_regolareverifica"] = Ri["start_sosp_regolareverifica"];
                //R["imp_nonliquidabile"] = Ri["imp_nonliquidabile"];
                //R["iva_nonliquidabile"] = Ri["iva_nonliquidabile"];
                R["importo_nonliquidabile"] = Ri["importo_nonliquidabile"];
            }
			else {
                R["imponibile"] = DBNull.Value; //NON LO STRASMETTIAMO
                R["imposta"] = DBNull.Value; //NON La STRASMETTIAMO
                R["importononcommerciale"] = DBNull.Value;
                //R["imp_sosp_contenzioso"] = DBNull.Value;
                //R["iva_sosp_contenzioso"] = DBNull.Value;
                R["importo_sosp_contenzioso"] = DBNull.Value;
                R["start_sosp_contenzioso"] = DBNull.Value;
                //R["imp_sosp_contestazione"] = DBNull.Value;
                //R["iva_sosp_contestazione"] = DBNull.Value;
                R["importo_sosp_contestazione"] = DBNull.Value;
                R["start_sosp_contestazione"] = DBNull.Value;
                //R["imp_sosp_regolareverifica"] = DBNull.Value;
                //R["iva_sosp_regolareverifica"] = DBNull.Value;
                R["importo_sosp_regolareverifica"] = DBNull.Value;
                R["start_sosp_regolareverifica"] = DBNull.Value;
                //R["imp_nonliquidabile"] = DBNull.Value;
                //R["iva_nonliquidabile"] = DBNull.Value;
                R["importo_nonliquidabile"] = DBNull.Value;
            }
            //REGIME IVA
            if (Ri["azione"].ToString() == "MI") {
                R["flagsplit"] = Ri["flagsplit"];
            }
            else {
                R["flagsplit"] = DBNull.Value;
            }

            //SCADENZA
            if (Ri["azione"].ToString() == "CS") {
                R["datascadenza"] = Ri["datascadenza"];
                R["NmeroProcotolloEntrata"] = Ri["NmeroProcotolloEntrata"];
            }
            else {
                R["datascadenza"] = DBNull.Value;
                R["NmeroProcotolloEntrata"] = DBNull.Value;
            }

            //Sezione Esito Eleborazione
            R["codicesegnalazione"] = DBNull.Value;
            R["descrizionesegnalazione"] = DBNull.Value;


            Operazioni.Rows.Add(R);
            Operazioni.AcceptChanges();

        }

        private void AggiungiRigaInvio(DataRow Ri, DataRow Raliquota, DataRow Rcigcup, DataTable Invio) {
            DataRow R = Invio.NewRow();
            if (Ri["idinvkind"] != DBNull.Value) {
                R["idinvkind"] = Ri["idinvkind"];
                R["yinv"] = Ri["yinv"];
                R["ninv"] = Ri["ninv"];
            }
            if (Ri["idmankind"] != DBNull.Value) {
                R["idmankind"] = Ri["idmankind"];
                R["yman"] = Ri["yman"];
                R["nman"] = Ri["nman"];
            }
            if (Ri["ycon"] != DBNull.Value) {
                R["ycon"] = Ri["ycon"];
                R["ncon"] = Ri["ncon"];
            }
            string filterFattura = QHC.AppAnd(QHC.CmpEq("idinvkind", Ri["idinvkind"]), QHC.CmpEq("yinv", Ri["yinv"]),
                QHC.CmpEq("ninv", Ri["ninv"]));
            string filterContrattopassivo = QHC.AppAnd(QHC.CmpEq("idmankind", Ri["idmankind"]),
                QHC.CmpEq("yman", Ri["yman"]), QHC.CmpEq("nman", Ri["nman"]));
            string filterOccasionale = QHC.AppAnd(QHC.CmpEq("ycon", Ri["ycon"]), QHC.CmpEq("ncon", Ri["ncon"]));
            string filterDoc = "";
            if (Ri["idinvkind"] != DBNull.Value) {
                filterDoc = filterFattura;
            }
            if (Ri["idmankind"] != DBNull.Value) {
                filterDoc = filterContrattopassivo;
            }
            if (Ri["ycon"] != DBNull.Value) {
                filterDoc = filterOccasionale;
            }
            //Inserisci RiepilogoAliquota
            //string filterAliquotaDoc = QHC.AppAnd(filterDoc, QHC.CmpEq("aliquotaiva", Ri["aliquotaiva"]), QHC.CmpEq("natura", Ri["natura"]));
            if (Raliquota != null) {
                valorizzaRiepilogoAliquota(R, Raliquota);
            }

            //Inserisci distribuzione per Cig/Cup
            //string filterCigCupDoc = QHC.AppAnd(filterDoc, QHC.CmpEq("codicecig", Ri["codicecig"]), QHC.CmpEq("codicecup", Ri["codicecup"]));
            if (Rcigcup != null) {
                valorizzaDistribuzioneCigCup(R, Rcigcup);
            }

            //Inserisci Intestazione, per ogni riga
            valorizzaIntestazione(R, Ri);

            // Inserisci Termini pagamento:solo una volta
            string filterPagamento = QHC.AppAnd(filterDoc, QHC.CmpEq("importopagamento", Ri["importopagamento"]));
            if (!esisteRiga(filterPagamento, Invio)) {
                valorizzaTerminiPagamento(R, Ri);
            }

            // Inserisci Info Ricezione: solo una volta
            string filterRicezione = QHC.AppAnd(filterDoc, QHC.CmpEq("numprotocolloentrata", Ri["numprotocolloentrata"]));
            if (!esisteRiga(filterRicezione, Invio)) {
                valorizzaInfoRicezione(R, Ri);
            }

            Invio.Rows.Add(R);
            Invio.AcceptChanges();
        }

        private void valorizzaRiepilogoAliquota(DataRow R, DataRow Raliquota) {
            R["aliquotaiva"] = Raliquota["aliquotaiva"];
            R["natura"] = Raliquota["natura"];
            R["imponibile"] = Raliquota["imponibile"];
            R["imposta"] = Raliquota["imposta"];
        }

        private void valorizzaDistribuzioneCigCup(DataRow R, DataRow Rcigcup) {
            R["importopercigcup"] = Rcigcup["importopercigcup"];
            R["codicecig"] = Rcigcup["codicecig"];
            R["codicecup"] = Rcigcup["codicecup"];
        }

        private void valorizzaIntestazione(DataRow Rnew, DataRow Rselected) {
            // Dati amministrazione
            Rnew["CFAmmin"] = Rselected["CFAmmin"];
            Rnew["ipa"] = Rselected["ipa"];
            Rnew["agencyname"] = Rselected["agencyname"];
            //Dati fornitore
            Rnew["idreg"] = Rselected["idreg"];
            Rnew["CFfornitore"] = Rselected["CFfornitore"];
            Rnew["IdFiscaleIvaFornitore"] = Rselected["IdFiscaleIvaFornitore"];
            Rnew["DenominazioneFornitore"] = Rselected["DenominazioneFornitore"];
            // Dati Fattuta
            Rnew["tipodocumento"] = Rselected["tipodocumento"];
            Rnew["numerodocumento"] = Rselected["numerodocumento"];
            Rnew["dataemissione"] = Rselected["dataemissione"];
            Rnew["importototaledocumento"] = Rselected["importototaledocumento"];
            Rnew["causale"] = Rselected["causale"];
            Rnew["Imponibiletotaledocumento"] = Rselected["Imponibiletotaledocumento"];
            Rnew["ivatotaledocumento"] = Rselected["ivatotaledocumento"];

        }

        private void valorizzaTerminiPagamento(DataRow Rnew, DataRow Rselected) {
            Rnew["datariferimentopagamento"] = Rselected["datariferimentopagamento"];
            Rnew["giorniterminipagamento"] = Rselected["giorniterminipagamento"];
            Rnew["datascadenzapagamento"] = Rselected["datascadenzapagamento"];
            Rnew["importopagamento"] = Rselected["importopagamento"];
        }

        private void valorizzaInfoRicezione(DataRow Rnew, DataRow Rselected) {
            Rnew["numprotocolloentrata"] = Rselected["numprotocolloentrata"];
            Rnew["dataricezione"] = Rselected["dataricezione"];
            Rnew["note"] = Rselected["note"];

            Rnew["forzaturaImissione"] = Rselected["forzaturaImissione"];
            Rnew["codicesegnalazione"] = Rselected["codicesegnalazione"];
            Rnew["descrizionesegnalazione"] = Rselected["descrizionesegnalazione"];
        }

        //Restituisce la riga del raggruppamento Aliquota per la fattura in oggetto
        private DataRow RriepilogoAliquota(DataRow Ri, DataRow[] selectedrows) {
            decimal taxable = 0;
            decimal tax = 0;
            DataRow Rj = null;
            for (int j = 0; j < selectedrows.Length; j++) {
                Rj = selectedrows[j];
                if (CfgFn.GetNoNullInt32(Rj["idinvkind"]) == CfgFn.GetNoNullInt32(Ri["idinvkind"])
                    && CfgFn.GetNoNullInt32(Rj["yinv"]) == CfgFn.GetNoNullInt32(Ri["yinv"])
                    && CfgFn.GetNoNullInt32(Rj["ninv"]) == CfgFn.GetNoNullInt32(Ri["ninv"])
                    && CfgFn.GetNoNullDecimal(Rj["aliquotaiva"]) == CfgFn.GetNoNullDecimal(Ri["aliquotaiva"])
                    && Rj["natura"].ToString() == Ri["natura"].ToString()) {
                    taxable = taxable + CfgFn.GetNoNullDecimal(Rj["imponibile"]);
                    tax = tax + CfgFn.GetNoNullDecimal(Rj["imposta"]);
                }
            }
            DataRow R = myRiepilogoaliquote.NewRow();
            R["idinvkind"] = Ri["idinvkind"];
            R["yinv"] = Ri["yinv"];
            R["ninv"] = Ri["ninv"];
            R["aliquotaiva"] = Ri["aliquotaiva"];
            R["natura"] = Ri["natura"];
            R["imponibile"] = taxable;
            R["imposta"] = tax;
            myRiepilogoaliquote.Rows.Add(R);
            return R;
        }

        private bool esisteRiga(string filterAliquotaDoc, DataTable Invio) {
            if ((Invio == null) || (Invio.Rows.Count == 0))
                return false;
            if (Invio.Select(filterAliquotaDoc).Length == 0)
                return false;
            else
                return true;
        }

        private DataRow RriepilogoCigcup(DataRow Ri, DataRow[] selectedrows) {
            decimal amount = 0;
            DataRow Rj = null;
            if (Ri["codicecig"].ToString() == "" && Ri["codicecup"].ToString() == "")
                return null;
            string filterFattura = QHS.AppAnd(QHS.CmpEq("idinvkind", Ri["idinvkind"]),
                        QHS.CmpEq("yinv", Ri["yinv"]), QHS.CmpEq("ninv", Ri["ninv"]));
            string flag_enable_split_payment = "N";
            if (Ri["idinvkind"] !=DBNull.Value)
                    flag_enable_split_payment = Conn.DO_READ_VALUE("invoice", filterFattura, "flag_enable_split_payment").ToString();

            for (int j = 0; j < selectedrows.Length; j++) {
                Rj = selectedrows[j];
                if (CfgFn.GetNoNullInt32(Rj["idinvkind"]) == CfgFn.GetNoNullInt32(Ri["idinvkind"])
                    && CfgFn.GetNoNullInt32(Rj["yinv"]) == CfgFn.GetNoNullInt32(Ri["yinv"])
                    && CfgFn.GetNoNullInt32(Rj["ninv"]) == CfgFn.GetNoNullInt32(Ri["ninv"])
                    &&
                    (Rj["codicecig"].ToString() == Ri["codicecig"].ToString() &&
                     Rj["codicecup"].ToString() == Ri["codicecup"].ToString()
                     ||
                     Rj["codicecig"].ToString() == Ri["codicecig"].ToString() && Rj["codicecup"].ToString() == "" &&
                     Ri["codicecup"].ToString() == ""
                     ||
                     Rj["codicecig"].ToString() == "" && Ri["codicecig"].ToString() == "" &&
                     Rj["codicecup"].ToString() == Ri["codicecup"].ToString()
                        )
                    ) {
                    if (flag_enable_split_payment == "S") {
                        amount = amount + CfgFn.GetNoNullDecimal(Rj["imponibile"]);
                    }
                    else {
                        amount = amount + CfgFn.GetNoNullDecimal(Rj["imponibile"]) + CfgFn.GetNoNullDecimal(Rj["imposta"]);
                    }
                }
            }
            DataRow R = myRiepilogoCigCup.NewRow();
            R["idinvkind"] = Ri["idinvkind"];
            R["yinv"] = Ri["yinv"];
            R["ninv"] = Ri["ninv"];
            R["importopercigcup"] = amount;
            R["codicecig"] = Ri["codicecig"];
            R["codicecup"] = Ri["codicecup"];
            myRiepilogoCigCup.Rows.Add(R);
            return R;
        }

        public void MetaData_AfterActivation() {
            FormInit();
        }

        private void FormInit() {
            CustomTitle = "Genera file trasmissione AreaRGS ";

            DateTime data = ((DateTime) Meta.GetSys("datacontabile"));
            DateTime DataDal = new DateTime(2014, 7, 1); //La trasmissione parte dal 01/07/2014
            DateTime DataAl = data;

            txtDal.Text = HelpForm.StringValue(DataDal, null);
            txtAl.Text = HelpForm.StringValue(DataAl, null);

            //Selects first tab
            DisplayTabs(0);
        }

        private object calcola_idsor0i(string idsor0i) {
            object defaultValue = DBNull.Value;

            string NtoS = idsor0i.Substring(5, 2);

            object idflowchart = Conn.GetSys("idflowchart");
            object ndetail = Conn.GetSys("ndetail");
            object idcustomuser = Conn.GetSys("idcustomuser");

            object as_filter = Conn.DO_READ_VALUE("uniconfig", null, "sorkind" + NtoS + "asfilter");
            if (as_filter == null || as_filter == DBNull.Value)
                as_filter = "N";
            object all_value = "S";

            if (as_filter.ToString().ToUpper() == "S") {
                all_value = Conn.DO_READ_VALUE("flowchartuser",
                    QHS.AppAnd(QHS.CmpEq("idcustomuser", idcustomuser),
                        QHS.CmpEq("idflowchart", idflowchart),
                        QHS.CmpEq("ndetail", ndetail)),
                    " isnull(all_sorkind" + NtoS + ",'S')");
                if (all_value == null || all_value == DBNull.Value) {
                    all_value = "S";
                }
            }

            if (all_value.ToString().ToUpper() == "S") {
                defaultValue = DBNull.Value;
                return defaultValue;
            }

            object idsor = Conn.GetSys("idsor" + NtoS);
            defaultValue = idsor;
            return defaultValue;
        }

        DataTable Tpccsend = null;

        bool EseguiSPInvio() {
            SvuotaTabella("O");
            idsor01 = calcola_idsor0i("idsor01");
            idsor02 = calcola_idsor0i("idsor02");
            idsor03 = calcola_idsor0i("idsor03");
            idsor04 = calcola_idsor0i("idsor04");
            idsor05 = calcola_idsor0i("idsor05");
            object DataAl = HelpForm.GetObjectFromString(typeof(DateTime), txtAl.Text, null);
            object[] param = new object[] {DataAl, idsor01, idsor02, idsor03, idsor04, idsor05};
            DataSet DSpccsend = Conn.CallSP("compute_pccsend", param, true, 900);
            if (DSpccsend == null || DSpccsend.Tables.Count == 0)
                return false;
            Tpccsend = DSpccsend.Tables[0];

            //foreach (DataColumn C in TableInvio.Columns) {
            //    C.Caption = "";
            //}
            Tpccsend.Columns["CFAmmin"].Caption = "";
            //Tpccsend.Columns["PivaAmmin"].Caption = "";
            Tpccsend.Columns["IPA"].Caption = "";
            Tpccsend.Columns["agencyname"].Caption = "";
            Tpccsend.Columns["idinvkind"].Caption = "";
            Tpccsend.Columns["idmankind"].Caption = "";
            Tpccsend.Columns["idreg"].Caption = "";

            Tpccsend.Columns["DenominazioneFornitore"].Caption = "Fornitore";
            Tpccsend.Columns["CFfornitore"].Caption = "CFfornitore";
            Tpccsend.Columns["IdFiscaleIvaFornitore"].Caption = "IdFiscaleIvaFornitore";
            Tpccsend.Columns["invoicekind"].Caption = "TipoFattura";
            Tpccsend.Columns["yinv"].Caption = "Es.Fattura";
            Tpccsend.Columns["ninv"].Caption = "Num.Fattura";
        
            Tpccsend.Columns["rownuminv"].Caption = "Dett.Fattura";
            Tpccsend.Columns["identificativo_sdi"].Caption = "Identificativo SDI";
            Tpccsend.Columns["mandatekind"].Caption = "ContrattoPassivo";
            Tpccsend.Columns["yman"].Caption = "Es.ContrattoPassivo";
            Tpccsend.Columns["nman"].Caption = "Num.ContrattoPassivo";
            Tpccsend.Columns["rownumman"].Caption = "Dett.ContrattoPassivo";
            Tpccsend.Columns["ycon"].Caption = "Es.ContrattoOccasionale";
            Tpccsend.Columns["ncon"].Caption = "Num.ContrattoOccasionale";

            //Questa Caption restano invariate
            Tpccsend.Columns["tipodocumento"].Caption = "Tipodocumento";
            Tpccsend.Columns["numerodocumento"].Caption = "NumeroDocumento";
            Tpccsend.Columns["dataemissione"].Caption = "DataEmissione";
            Tpccsend.Columns["importototaledocumento"].Caption = "ImportoTotaleDocumento";
            Tpccsend.Columns["causale"].Caption = "Causale";
            Tpccsend.Columns["Imponibiletotaledocumento"].Caption = "ImponibileTotaleDocumento";
            Tpccsend.Columns["ivatotaledocumento"].Caption = "IvaTotaleDocumento";
            Tpccsend.Columns["aliquotaiva"].Caption = "AliquotaIva";
            Tpccsend.Columns["natura"].Caption = "Natura";
            Tpccsend.Columns["imponibile"].Caption = "Imponibile";
            Tpccsend.Columns["imposta"].Caption = "Imposta";
            Tpccsend.Columns["codicecig"].Caption = "CodiceCIG";
            Tpccsend.Columns["codicecup"].Caption = "CodiceCUP";
            Tpccsend.Columns["datacontabiledocumento"].Caption = "Data Contabile Documento";
            Tpccsend.Columns["datariferimentopagamento"].Caption = "DataRiferimentoPagamento";
            Tpccsend.Columns["giorniterminipagamento"].Caption = "GiorniTerminiPagamento";
            Tpccsend.Columns["datascadenzapagamento"].Caption = "DataScadenzaPagamento";
            Tpccsend.Columns["importopagamento"].Caption = "ImportoPagamento";
            Tpccsend.Columns["numprotocolloentrata"].Caption = "NumProtocolloEentrata";
            Tpccsend.Columns["dataricezione"].Caption = "DataRicezione";
            Tpccsend.Columns["note"].Caption = "Note";

            Tpccsend.AcceptChanges();
            gridDettagli.DataSource = null;
            gridDettagli.TableStyles.Clear();
            HelpForm.SetDataGrid(gridDettagli, Tpccsend);
            selezionaTuttiIDettagli();

            return true;
        }

        private void selezionaTuttiIDettagli() {
            object dataSource = gridDettagli.DataSource;
            if (dataSource == null)
                return;

            CurrencyManager cm = (CurrencyManager)
                gridDettagli.BindingContext[dataSource, gridDettagli.DataMember];

            DataView view = cm.List as DataView;

            if (view != null) {
                for (int i = 0; i < view.Count; i++) {
                    gridDettagli.Select(i);
                }
            }
        }

        DataTable Tpccsendoperation = null;
        DataTable TpccsendPayment = null;

        bool EseguiSPOperazioni() {
            SvuotaTabella("I");
            idsor01 = calcola_idsor0i("idsor01");
            idsor02 = calcola_idsor0i("idsor02");
            idsor03 = calcola_idsor0i("idsor03");
            idsor04 = calcola_idsor0i("idsor04");
            idsor05 = calcola_idsor0i("idsor05");
            object SID = "N";
            object CS = "N";
            object MI = "N";
            object IP = "N";
            if (chkSID.Checked)
                SID = "S";
            if (chkScadenza.Checked)
                CS = "S";
            if (chkMI.Checked)
                MI = "S";
            if (chkIP.Checked)
                IP = "S";
            
            object DataAl = HelpForm.GetObjectFromString(typeof(DateTime), txtAl.Text, null);
            object EsercizioDal = HelpForm.GetObjectFromString(typeof(int), txtEsercizio.Text, null);
            if (IP == "S") {
                object[] param = new object[] { EsercizioDal, DataAl, idsor01, idsor02, idsor03, idsor04, idsor05};
                DataSet DSpccsendPayment = Conn.CallSP("compute_pccoperation_pagamenti", param, true, 900);
                if (DSpccsendPayment == null || DSpccsendPayment.Tables.Count == 0)
                    return false;
                TpccsendPayment = DSpccsendPayment.Tables[0];

                TpccsendPayment.Columns["nriga"].Caption = "nriga";
                TpccsendPayment.Columns["invoicekind"].Caption = "Tipo Fattura";
                TpccsendPayment.Columns["idinvkind"].Caption = "";
                TpccsendPayment.Columns["yinv"].Caption = "Es.Fattura";
                TpccsendPayment.Columns["ninv"].Caption = "Num.Fattura";

                TpccsendPayment.Columns["IDENTIFICATIVO_1"].Caption = "NumeroProgressivoRegistrazione";
                TpccsendPayment.Columns["IDENTIFICATIVO_2_a"].Caption = "LottoSDI";
                TpccsendPayment.Columns["IDENTIFICATIVO_2_b"].Caption = "NumeroFattura";
                TpccsendPayment.Columns["IDENTIFICATIVO_3_a"].Caption = "DataDocumento";
                TpccsendPayment.Columns["IDENTIFICATIVO_3_b"].Caption = "CF_Fornitore";
                TpccsendPayment.Columns["IDENTIFICATIVO_3_c"].Caption = "CodiceUfficio";
                TpccsendPayment.Columns["azione"].Caption = "azione";
                TpccsendPayment.Columns["idpettycash"].Caption = "";
                TpccsendPayment.Columns["yoperation"].Caption = "";
                TpccsendPayment.Columns["noperation"].Caption = "";
                TpccsendPayment.Columns["IdPagamento"].Caption = "";
                TpccsendPayment.Columns["Tipodebito"].Caption = "";
                TpccsendPayment.Columns["importopagato"].Caption = "ImportoPagato";
                TpccsendPayment.Columns["naturadispesa"].Caption = "NaturaSpesa";
                TpccsendPayment.Columns["kpay"].Caption = "";
                TpccsendPayment.Columns["npay"].Caption = "Mandato";
                TpccsendPayment.Columns["paymentdate"].Caption = "DataTrasmissioneMandato";
                TpccsendPayment.Columns["IdFiscaleIvaFornitore"].Caption = "IdFiscaleIvaFornitore";
                TpccsendPayment.Columns["codicecig"].Caption = "CIG";
                TpccsendPayment.Columns["codicecup"].Caption = "CUP";
                TpccsendPayment.Columns["PagamentoOPI"].Caption = "";
                TpccsendPayment.Columns["PagamentoIVA"].Caption = "";
                TpccsendPayment.Columns["Giornidisospensioneeffettivi"].Caption = "";
                TpccsendPayment.AcceptChanges();
                //gridDettagli.TableStyles.Clear();
                gridDettagli.DataSource = null;

                HelpForm.SetDataGrid(gridDettagli, TpccsendPayment);

                gridDettagli.TableStyles.Clear();
                HelpForm.SetGridStyle(gridDettagli, TpccsendPayment);
                gridDettagli.TableStyles[0].GridColumnStyles[0].Width = 0;
            }
            else {
                object[] param = new object[] { DataAl, idsor01, idsor02, idsor03, idsor04, idsor05, SID, CS, MI };
                DataSet DSpccsendOperation = Conn.CallSP("compute_pccoperation_sid", param, true, 900);
                if (DSpccsendOperation == null || DSpccsendOperation.Tables.Count == 0)
                    return false;
                Tpccsendoperation = DSpccsendOperation.Tables[0];

                Tpccsendoperation.Columns["nriga"].Caption = "nriga";
                Tpccsendoperation.Columns["invoicekind"].Caption = "Tipo Fattura";
                Tpccsendoperation.Columns["idinvkind"].Caption = "";
                Tpccsendoperation.Columns["yinv"].Caption = "Es.Fattura";
                Tpccsendoperation.Columns["ninv"].Caption = "Num.Fattura";

                Tpccsendoperation.Columns["IDENTIFICATIVO_1"].Caption = "NumeroProgressivoRegistrazione";
                Tpccsendoperation.Columns["IDENTIFICATIVO_2_a"].Caption = "LottoSDI";
                Tpccsendoperation.Columns["IDENTIFICATIVO_2_b"].Caption = "NumeroFattura";
                Tpccsendoperation.Columns["IDENTIFICATIVO_3_a"].Caption = "DataDocumento";
                Tpccsendoperation.Columns["IDENTIFICATIVO_3_b"].Caption = "CF_Fornitore";
                Tpccsendoperation.Columns["IDENTIFICATIVO_3_c"].Caption = "CodiceUfficio";
                Tpccsendoperation.Columns["idpccdebitstatusdetail"].Caption = "Npccdebitstatus";
                Tpccsendoperation.Columns["azione"].Caption = "azione";
                Tpccsendoperation.Columns["imponibile"].Caption = "";
                Tpccsendoperation.Columns["imposta"].Caption = "";
                Tpccsendoperation.Columns["importononcommerciale"].Caption = "importononcommerciale";

                Tpccsendoperation.Columns["imp_sosp_contenzioso"].Caption = "imp_sosp_contenzioso";
                Tpccsendoperation.Columns["iva_sosp_contenzioso"].Caption = "iva_sosp_contenzioso";
                Tpccsendoperation.Columns["importo_sosp_contenzioso"].Caption = "importo_sosp_contenzioso";
                Tpccsendoperation.Columns["start_sosp_contenzioso"].Caption = "start_sosp_contenzioso";

                Tpccsendoperation.Columns["imp_sosp_contestazione"].Caption = "imp_sosp_contestazione";
                Tpccsendoperation.Columns["iva_sosp_contestazione"].Caption = "iva_sosp_contestazione";
                Tpccsendoperation.Columns["importo_sosp_contestazione"].Caption = "importo_sosp_contestazione";
                Tpccsendoperation.Columns["start_sosp_contestazione"].Caption = "start_sosp_contestazione";

                Tpccsendoperation.Columns["imp_sosp_regolareverifica"].Caption = "imp_sosp_regolareverifica";
                Tpccsendoperation.Columns["iva_sosp_regolareverifica"].Caption = "iva_sosp_regolareverifica";
                Tpccsendoperation.Columns["importo_sosp_regolareverifica"].Caption = "importo_sosp_regolareverifica";
                Tpccsendoperation.Columns["start_sosp_regolareverifica"].Caption = "start_sosp_regolareverifica";

                Tpccsendoperation.Columns["imp_nonliquidabile"].Caption = "imp_nonliquidabile";
                Tpccsendoperation.Columns["iva_nonliquidabile"].Caption = "iva_nonliquidabile";
                Tpccsendoperation.Columns["importo_nonliquidabile"].Caption = "importo_nonliquidabile";

                Tpccsendoperation.Columns["flagsplit"].Caption = "Split";
                Tpccsendoperation.Columns["datascadenza"].Caption = "DataScadenza";
                Tpccsendoperation.Columns["NmeroProcotolloEntrata"].Caption = "NmeroProcotolloEntrata";

                Tpccsendoperation.AcceptChanges();
                //gridDettagli.TableStyles.Clear();
                gridDettagli.DataSource = null;

                HelpForm.SetDataGrid(gridDettagli, Tpccsendoperation);

                gridDettagli.TableStyles.Clear();
                HelpForm.SetGridStyle(gridDettagli, Tpccsendoperation);
                gridDettagli.TableStyles[0].GridColumnStyles[0].Width = 0;
            }



            selezionaTuttiIDettagli();

            return true;
        }

        private void btnSelezionaTutto_Click(object sender, EventArgs e) {
            selezionaTuttiIDettagli();
        }

        private void btnNext_Click(object sender, EventArgs e) {
            StandardChangeTab(+1);
        }

        private void btnBack_Click(object sender, EventArgs e) {
            StandardChangeTab(-1);
        }

        private void panel1_Paint(object sender, PaintEventArgs e) {

        }

        bool InsidePaint = false;

        private void gridDettagli_Paint(object sender, PaintEventArgs e) {
            if (gridDettagli.DataMember == null || gridDettagli.DataMember == "")
                return;
            if (InsidePaint)
                return;

            InsidePaint = true;
            int i;

            string TableName = gridDettagli.DataMember.ToString();
            DataSet MyDS = (DataSet) gridDettagli.DataSource;
            DataTable MyTable = MyDS.Tables[TableName];

            int numrighetemp = MyTable.Rows.Count;

            //lookup associa al valore del campo nriga la riga avente quel valore
            Dictionary<string, DataRow> lookup = new Dictionary<string, DataRow>();

            //Elenca le righe associate allo stesso ordine
            Dictionary<string, List<DataRow>> sameMandate = new Dictionary<string, List<DataRow>>();

            //Elenca le righe relative alla stessa fattura
            Dictionary<string, List<DataRow>> sameInvoice = new Dictionary<string, List<DataRow>>();

            //Associa ad ogni "nriga" la posizione della riga nel grid
            Dictionary<string, int> getIndex = new Dictionary<string, int>();


            foreach (DataRow r in MyTable.Select()) {
                lookup[r["nriga"].ToString()] = r;
                if (r["invoicekind"].ToString() != "") {
                    string lookInvoice = r["invoicekind"].ToString() + "§" + r["yinv"].ToString() + "§" +
                                         r["ninv"].ToString();
                    if (!sameInvoice.ContainsKey(lookInvoice)) {
                        sameInvoice.Add(lookInvoice, new List<DataRow>());
                    }
                    sameInvoice[lookInvoice].Add(r);

                }
            }

            for (i = 0; i < numrighetemp; i++) {
                string nRiga = gridDettagli[i, 0].ToString();
                getIndex[nRiga] = i;
            }

            for (i = 0; i < numrighetemp; i++) {
                string nRiga = gridDettagli[i, 0].ToString();
                DataRow r = lookup[nRiga];
                List<DataRow> linked;
                string lookInvoice = r["invoicekind"].ToString() + "§" + r["yinv"].ToString() + "§" +
                                        r["ninv"].ToString();
                linked = sameInvoice[lookInvoice];
                sameInvoice[lookInvoice] = new List<DataRow>();

                if (linked.Count > 0) {
                    if (chkInvio.Checked) {
                        SelectGridRowsSameDocInvio(gridDettagli, gridDettagli.IsSelected(i), linked, getIndex);
                    }
                    //if (rdbOperazioni.Checked) {
                    //    SelectGridRowsSameDocOperazioni(gridDettagli, gridDettagli.IsSelected(i), linked, getIndex,
                    //        r["azione"].ToString());
                    //}
                }
            }


            InsidePaint = false;
        }

        //Consente di fare la seleziona automatica dei dettagli di una stessa fattura o contratto passivo
        void SelectGridRowsSameDocInvio(DataGrid G, bool select,
            List<DataRow> linked,
            Dictionary<string, int> getIndex) {
            foreach (DataRow r in linked) {
                string nriga = r["nriga"].ToString();
                int pos = getIndex[nriga];
                if (select && !G.IsSelected(pos)) {
                    G.Select(pos);
                }
                if (!select && G.IsSelected(pos)) {
                    G.UnSelect(pos);
                }
            }
        }

        void SelectGridRowsSameDocOperazioni(DataGrid G, bool select,
            List<DataRow> linked,
            Dictionary<string, int> getIndex, string azioneMain
            ) {
            foreach (DataRow r in linked) {
                string nriga = r["nriga"].ToString();
                int pos = getIndex[nriga];
                if (select && !G.IsSelected(pos)) {
                    G.Select(pos);
                }
                if (!select && G.IsSelected(pos)) {
                    G.UnSelect(pos);
                }
            }
            //// Se stiamo trasmettendo le Operazioni, quando selezioniamo CP, deve selezionare anche CO
            //foreach (DataRow r in linked) {
            //    string nriga = r["nriga"].ToString();
            //    int pos = getIndex[nriga];
            //    string azione = r["azione"].ToString();
            //    if ((azioneMain == "CP" && (azione == "CO" || azione == "COF")) || (azione == azioneMain)) {
            //        if (select && !G.IsSelected(pos)) {
            //            G.Select(pos);
            //        }
            //        if (!select && G.IsSelected(pos)) {
            //            G.UnSelect(pos);
            //        }
            //    }
            //}
        }


        private bool alreadyselected(DataRow curr_rowgrid, DataRow[] RrowSelected) {
            foreach (DataRow R in RrowSelected)
                if (R == curr_rowgrid)
                    return true;
            return false;

        }

        DataRow GetGridRow(DataGrid G, int index) {
            string TableName = G.DataMember.ToString();
            DataSet MyDS = (DataSet) G.DataSource;
            DataTable MyTable = MyDS.Tables[TableName];
            string filter = "";
            //  usiamo nriga come chiave del grid per comodità, perchè altrimenti dovremmo usare idinvkind,yinv,ninv,idmankind,nman,yman,ycon,ncon come chiave
            filter = QHC.CmpEq("nriga", G[index, 0]);
            DataRow[] selectresult = MyTable.Select(filter);
            if (selectresult.Length == 0)
                return null;
            return selectresult[0];
        }


        private DataRow[] GetGridSelectedRows(DataGrid G) {
            if (G.DataMember == null)
                return null;
            if (G.DataSource == null)
                return null;
            string TableName = G.DataMember.ToString();
            DataSet MyDS = (DataSet) G.DataSource;
            DataTable MyTable = MyDS.Tables[TableName];
            int numrighetemp = MyTable.Rows.Count;
            int numrighe = 0;
            int i;
            for (i = 0; i < numrighetemp; i++) {
                if (G.IsSelected(i)) {
                    numrighe++;
                }
            }

            DataRow[] Res = new DataRow[numrighe];
            int count = 0;
            for (i = 0; i < numrighetemp; i++) {
                if (G.IsSelected(i)) {
                    Res[count++] = GetGridRow(G, i);
                }
            }
            return Res;
        }

        private void btnCartella_Click(object sender, EventArgs e) {
            txtPercorso.Text = "";
            faiScegliereCartella();
            if (txtPercorso.Text == "") {
                show(this, "Occorre specificare la cartella in cui salvare il file", "errore");
                return;
            }
        }

        private void btnAnnulla_Click(object sender, EventArgs e) {
            Close();
        }

		private void tabController_SelectionChanged(object sender, EventArgs e) {

		}

        private void FormattaDataDelTexBox(TextBox TB) {
            if (!TB.Modified) return;
            HelpForm.FormatLikeYear(TB);
        }
        private void txtEsercizio_Leave(object sender, EventArgs e) {
            if (txtEsercizio.ReadOnly) return;
            if (!Meta.DrawStateIsDone) return;
            FormattaDataDelTexBox(txtEsercizio);
        }

		private void checkBox1_CheckedChanged(object sender, EventArgs e) {
                chkSID.Enabled = !chkInvio.Checked;
                chkScadenza.Enabled = !chkInvio.Checked;
                chkMI.Enabled = !chkInvio.Checked;
                chkIP.Enabled = !chkInvio.Checked;
		}

		private void chkIP_CheckedChanged(object sender, EventArgs e) {
            chkInvio.Enabled = !chkIP.Checked;
            chkSID.Enabled = !chkIP.Checked;
            chkScadenza.Enabled = !chkIP.Checked;
            chkMI.Enabled = !chkIP.Checked;
        }

		private void chkSID_CheckedChanged(object sender, EventArgs e) {
            bool abilita = true;
            if(chkSID.Checked || chkMI.Checked || chkScadenza.Checked) {
                abilita = false;
			}
            chkInvio.Enabled = abilita;
            chkIP.Enabled = abilita;
        }

		private void chkScadenza_CheckedChanged(object sender, EventArgs e) {
            bool abilita = true;
            if (chkSID.Checked || chkMI.Checked || chkScadenza.Checked) {
                abilita = false;
            }
            chkInvio.Enabled = abilita;
            chkIP.Enabled = abilita;
        }

		private void chkMI_CheckedChanged(object sender, EventArgs e) {
            bool abilita = true;
            if (chkSID.Checked || chkMI.Checked || chkScadenza.Checked) {
                abilita = false;
            }
            chkInvio.Enabled = abilita;
            chkIP.Enabled = abilita;
        }
	}
}
