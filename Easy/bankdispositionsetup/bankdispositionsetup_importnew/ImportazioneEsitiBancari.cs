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
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using metadatalibrary;
using System.Collections.Generic;
using System.IO;
using funzioni_configurazione;
using System.Globalization;
using System.Text;
using pagoPaService;

namespace bankdispositionsetup_importnew {


  

    /// <summary>
    /// Classe base per righe di importazione mandati e reversali
    /// </summary>
    public  class RigaDocumento {
        public string objName;

        public static readonly DateTime MinDate = new DateTime(1900, 1, 1);
        public int y;
        public int ndoc;
        public int kdoc;
        public int progressivo;
        public int idmov;
        /// <summary>
        /// Importo da esitare
        /// </summary>
        public decimal amount;

        /// <summary>
        /// Data operazione
        /// </summary>
        public object transactiondate=DBNull.Value;

        /// <summary>
        /// Data valuta
        /// </summary>
        public object valuedate= DBNull.Value;

        /// <summary>
        /// Causale
        /// </summary>
        public string causale="";

        /// <summary>
        /// Beneficiario o versante
        /// </summary>
        public string registry="";

 
        /// <summary>
        /// Numero bolletta, è memorizzata di solito in bankreference di banktransaction
        /// </summary>
        public object nbill=DBNull.Value;

        private Dictionary<string,object> I = null;

        public void Set(string field, string value) {
            if (I == null) I = new Dictionary<string,object>();
            I.Add(field, value);
        }

        public object Get(string field) {
            if (I == null) I = new Dictionary<string, object>();
            if (!I.ContainsKey(field)) return DBNull.Value;
            return I[field];
        }

        public static string truncate(string S, int len) {
            if (S == null) return S;
            if (S.Length < len) return S;
            return S.Substring(0, len);
        }

        public RigaDocumento(int y, int ndoc, decimal amount, object data_operazione, object data_valuta,
                        string anagrafica, string causale, object nbolletta,int progressivo) {
            this.y = y;
            this.ndoc = ndoc;
            this.amount = amount;
            this.valuedate = data_valuta;
            this.transactiondate = data_operazione;
            this.registry = truncate(anagrafica,150);
            this.causale = truncate(causale,150);
            this.nbill = nbolletta;
            this.progressivo = progressivo;
        }
        internal static int GetHashForDoc(int y, int n){
            return   y*1000000+n;
        }
        public override int GetHashCode() {
            return GetHashForDoc(y,ndoc);
        }
        internal void ResetInfoMovimenti() {
            I = null;
        }



        /// <summary>
        /// Aggiunge le info di questo documento alla tabella in ingresso
        /// </summary>
        /// <param name="T"></param>
        public virtual void AddToTable(DataTable T) {
            DataRow R = T.NewRow();
            R["ydoc"] = y;
            R["ndoc"] = ndoc;
            R["amount"] = amount;
            R["causale"] = truncate(causale.ToString(),150);
            R["registry"] = truncate(registry.ToString(),150);
            R["transactiondate"] = transactiondate;
            R["nbill"] = nbill.ToString();
            R["prodoc"] = progressivo;
            T.Rows.Add(R);
        }
      
   

    }

    public  class RigaMandato : RigaDocumento {
        
        public RigaMandato(int esercmandato, int nummandato, decimal amount, object data_operazione, object data_valuta,
                        string beneficiario, string causale, object nbolletta,int progressivo)
            : base(esercmandato, nummandato, amount, data_operazione, data_valuta, beneficiario, causale,
            nbolletta,progressivo) {
                objName = "Mandato";
        }
        public override string ToString() {
            string s = "Mandato " + ndoc + "/" + y + progressivo;
            if (nbill!=DBNull.Value) s+=" bolletta:"+nbill.ToString();
            s+= " Importo:"+amount.ToString("c");
            if (causale!=null) s+=" Causale:"+causale;
            if (registry!=null) s+= " Beneficiario:"+registry;
            return s;
        }

        /// <summary>
        /// Crea una tabella adatta per visualizzare le informazioni
        /// </summary>
        /// <returns></returns>
        public static DataTable CreaTableForDisplay() {
            DataTable T = new DataTable("mandato");
            T.Columns.Add(new DataColumn("ydoc", typeof(int)));
            T.Columns.Add(new DataColumn("ndoc", typeof(int)));
            T.Columns.Add(new DataColumn("prodoc", typeof(int)));
            T.Columns.Add(new DataColumn("amount", typeof(decimal)));
            T.Columns.Add(new DataColumn("causale", typeof(string)));
            T.Columns.Add(new DataColumn("registry", typeof(string)));
            T.Columns.Add(new DataColumn("transactiondate", typeof(DateTime)));
            T.Columns.Add(new DataColumn("nbill", typeof(string)));

            foreach (DataColumn C in T.Columns) C.Caption = null;

            T.Columns["ydoc"].Caption = "Esercizio";
            T.Columns["ndoc"].Caption = "Numero";
            T.Columns["prodoc"].Caption = "prog.";
            T.Columns["amount"].Caption = "Importo";
            T.Columns["causale"].Caption = "Causale";
            T.Columns["registry"].Caption = "Beneficiario";
            T.Columns["transactiondate"].Caption = "Data";
            T.Columns["nbill"].Caption = "Bolletta";

            return T;
        } 
       
        
    }

   
    public  class RigaReversale : RigaDocumento {

        public RigaReversale(int esercreve, int numreve, decimal amount, object data_operazione, object data_valuta,
                        string versante, string causale, object nbolletta, int progressivo)
            : base(esercreve, numreve, amount, data_operazione, data_valuta, versante, causale, nbolletta, progressivo) {
        }        

       
        public override string ToString() {
            string s = "Reversale " + ndoc + "/" + y+" #"+progressivo;
            if (nbill != DBNull.Value) s += " bolletta:" + nbill.ToString();
            s += " Importo:" + amount.ToString("c");
            if (causale != null) s += " Causale:" + causale;
            if (registry != null) s += " Versante:" + registry;
            return s;
        }

        /// <summary>
        /// Crea una tabella adatta per visualizzare le informazioni
        /// </summary>
        /// <returns></returns>
        public static DataTable CreaTableForDisplay() {
            DataTable T = new DataTable("reversale");
            T.Columns.Add(new DataColumn("ydoc", typeof(int)));
            T.Columns.Add(new DataColumn("ndoc", typeof(int)));
            T.Columns.Add(new DataColumn("prodoc", typeof(int)));
            T.Columns.Add(new DataColumn("amount", typeof(decimal)));
            T.Columns.Add(new DataColumn("causale", typeof(string)));
            T.Columns.Add(new DataColumn("registry", typeof(string)));
            T.Columns.Add(new DataColumn("transactiondate", typeof(DateTime)));
            T.Columns.Add(new DataColumn("nbill", typeof(string)));

            foreach (DataColumn C in T.Columns) C.Caption = null;

            T.Columns["ydoc"].Caption = "Esercizio";
            T.Columns["ndoc"].Caption = "Numero";
            T.Columns["prodoc"].Caption = "prog.";
            T.Columns["amount"].Caption = "Importo";
            T.Columns["causale"].Caption = "Causale";
            T.Columns["registry"].Caption = "Versante";
            T.Columns["transactiondate"].Caption = "Data";
            T.Columns["nbill"].Caption = "Bolletta";

            return T;
        }
     
    }

    
    public class Provvisorio  { //<T> where T : Provvisorio<T> {  //: Compensabile<T>  {
        /// <summary>
        /// Anno bolletta
        /// </summary>
        public int y;

        /// <summary>
        /// Numero bolletta BANCA, NON QUELLO DEL PROGRAMMA DI PARI NOME
        /// </summary>
        public int nbill;

        /// <summary>
        /// Causale della bolletta (campo motive di bill)
        /// </summary>
        public string causale;

        /// <summary>
        /// Anagrafica beneficiario  o versante (campo registry di bill)
        /// </summary>
        public string registry;

        /// <summary>
        /// Data  operazione (campo adate di bill)
        /// </summary>
        public object data;

        /// <summary>
        /// Campo sotto conto per identificare il tesoriere
        /// </summary>
        public object numeroconto;

        public decimal amount;

        public static string truncate(string S, int len) {
            if (S == null) return S;
            if (S.Length < len) return S;
            return S.Substring(0, len);
        }


        public Provvisorio(int annobolletta, int numbolletta, decimal amount, string causale, string anagrafica,
                    object dataoperazione, object numeroconto) {
            this.y = annobolletta;
            this.nbill = numbolletta;
            this.amount = amount;

            this.causale = causale;
            this.registry = anagrafica;
            this.data = dataoperazione;
            this.numeroconto = numeroconto;
        }

        public static DataTable CreateTableForDisplay() {
            DataTable TT = new DataTable("provvisorio");
            TT.Columns.Add(new DataColumn("y", typeof(int)));
            TT.Columns.Add(new DataColumn("nbill", typeof(int)));
            TT.Columns.Add(new DataColumn("causale", typeof(string)));
            TT.Columns.Add(new DataColumn("registry", typeof(string)));
            TT.Columns.Add(new DataColumn("data", typeof(string)));
            TT.Columns.Add(new DataColumn("numeroconto", typeof(string)));
            TT.Columns.Add(new DataColumn("importo", typeof(decimal)));

            foreach (DataColumn C in TT.Columns) C.Caption = null;

            TT.Columns["y"].Caption = "Esercizio";
            TT.Columns["nbill"].Caption = "N.bolletta";
            TT.Columns["importo"].Caption = "Importo";           
            TT.Columns["causale"].Caption = "Causale";
            TT.Columns["registry"].Caption = "Beneficiario";
            TT.Columns["data"].Caption = "Data";
            TT.Columns["nbill"].Caption = "Bolletta";
            TT.Columns["numeroconto"].Caption = "conto tesoreria";
            return TT;
        }

        public void AddToTable(DataTable TT) {
            DataRow R = TT.NewRow();
            R["y"] = y;
            R["nbill"] = nbill;
            R["causale"] = truncate(causale,150);
            R["registry"] = truncate(registry,150);
            R["data"] = data;
            R["numeroconto"] = numeroconto;
            R["importo"] = amount;            
            TT.Rows.Add(R);
        }
    }

    public class ProvvisorioEntrata : Provvisorio {

        public ProvvisorioEntrata(int annobolletta, int numbolletta, decimal amount, string causale, string versante,
                    object dataoperazione, object numeroconto)
            : base(annobolletta, numbolletta, amount,causale,versante,dataoperazione,numeroconto) {
        }
        
        public override string ToString() {
            return "Provvisorio di entrata " + nbill.ToString() + "/" + y.ToString();
        }
    }

    public class ProvvisorioSpesa : Provvisorio {
        public ProvvisorioSpesa(int annobolletta, int numbolletta, decimal amount, string causale, string beneficiario,
                    object dataoperazione, object numeroconto)
            : base(annobolletta, numbolletta, amount, causale, beneficiario, dataoperazione, numeroconto) {
        }

        public override string ToString() {
            return "Provvisorio di spesa " + nbill.ToString() + "/" + y.ToString();
        }
    }


    public class EsitoProvvisorio {
         /// <summary>
        /// Anno bolletta
        /// </summary>
        public int y;

        /// <summary>
        /// Numero bolletta nostro
        /// </summary>
        public int nbill;

        /// <summary>
        /// Data  operazione (campo adate di bill)
        /// </summary>
        public object data;


        public decimal amount;



        public static string truncate(string S, int len) {
            if (S == null) return S;
            if (S.Length < len) return S;
            return S.Substring(0, len);
        }


        public EsitoProvvisorio(int annobolletta, int numbolletta, decimal amount,
                    object dataoperazione) {
            this.y = annobolletta;
            this.nbill = numbolletta;
            this.amount = amount;
            this.data = dataoperazione;
        }

        public static DataTable CreateTableForDisplay() {
            DataTable TT = new DataTable("esitoprovvisorio");
            TT.Columns.Add(new DataColumn("y", typeof(int)));
            TT.Columns.Add(new DataColumn("nbill", typeof(int)));
            TT.Columns.Add(new DataColumn("data", typeof(string)));
            TT.Columns.Add(new DataColumn("importo", typeof(decimal)));

            foreach (DataColumn C in TT.Columns) C.Caption = null;

            TT.Columns["y"].Caption = "Esercizio";
            TT.Columns["nbill"].Caption = "N.bolletta";
            TT.Columns["importo"].Caption = "Importo";           
            TT.Columns["data"].Caption = "Data";
            return TT;
        }

        public void AddToTable(DataTable TT) {
            DataRow R = TT.NewRow();
            R["y"] = y;
            R["nbill"] = nbill;
            R["data"] = data;
            R["importo"] = amount;            
            TT.Rows.Add(R);
        }
    }

    public class DatiImportati {
        public bool DatiValidi = true;
        public List<RigaMandato> Mandati = new List<RigaMandato>();
        public List<RigaReversale> Reversali = new List<RigaReversale>();
        public List<ProvvisorioEntrata> BolletteEntrata = new List<ProvvisorioEntrata>();
        public List<ProvvisorioSpesa> BolletteSpesa = new List<ProvvisorioSpesa>();
        public List<EsitoProvvisorio> EsitiBolletteSpesa = new List<EsitoProvvisorio>();
        public List<EsitoProvvisorio> EsitiBolletteEntrata = new List<EsitoProvvisorio>();
        public string identificativo_flusso_BT = "";
        public string idbank = "";

        public DataTable GetTabellaMandati(DataTable T) {
            foreach (RigaMandato P in Mandati) {
                P.AddToTable(T);
            } 
            return T;
        }
        public DataTable GetTabellaReversali(DataTable T) {
            foreach (RigaReversale P in Reversali) {
                P.AddToTable(T);
            }
            return T;
        }


        public DataTable GetTabellaBolletteEntrata(DataTable T) {
            foreach (ProvvisorioEntrata P in BolletteEntrata) {
                P.AddToTable(T);
            }
            return T;
        }
        public DataTable GetTabellaBolletteSpesa(DataTable T) {
            foreach (ProvvisorioSpesa P in BolletteSpesa) {
                P.AddToTable(T);
            }
            return T;
        }
        public DataTable GetTabellaEsitiBolletteSpesa(DataTable T) {
            foreach (EsitoProvvisorio P in EsitiBolletteSpesa) {
                P.AddToTable(T);
            }
            return T;
        }
        public DataTable GetTabellaEsitiBolletteEntrata(DataTable T) {
            foreach (EsitoProvvisorio P in EsitiBolletteEntrata) {
                P.AddToTable(T);
            }
            return T;
        }

     
        /// <summary>
        /// Calcola kdoc in base a ndoc, dei mandati, reversali ed esiti dei sospesi. Eventualente anche la chiave interna nbill
        /// </summary>
        /// <param name="Conn"></param>
        public bool CalcolaChiaviDocumenti(DataAccess Conn){
            bool res = true;
            QueryHelper Q=Conn.GetQueryHelper();
            TableCache tPayment= new TableCache(Conn,"npay","payment",new string[]{"kpay"},
                            Q.CmpEq("ypay",Conn.GetSys("esercizio")));
            TableCache tProceeds = new TableCache(Conn, "npro", "proceeds", new string[] { "kpro" },
                            Q.CmpEq("ypro", Conn.GetSys("esercizio")));

            object[] npay = new object[Mandati.Count];
            for (int i = 0; i < Mandati.Count; i++) {
                npay[i] = Mandati[i].ndoc;
            }
            object[] npro = new object[Reversali.Count];
            for (int i = 0; i < Reversali.Count; i++) {
                npro[i] = Reversali[i].ndoc;
            }

            tPayment.ReadValuesRelatedTo(npay,"npay");
            tProceeds.ReadValuesRelatedTo(npro, "npro");
            List<string> msgs = new List<string>();
            foreach (RigaMandato rp in Mandati) {
                int k=CfgFn.GetNoNullInt32(tPayment.getField(rp.ndoc, "kpay"));
                if (k==0){
                    string msg="Non esiste il mandato numero "+rp.ndoc.ToString()+" nell'esercizio corrente.";
                    if (!msgs.Contains(msg)) {
                        MessageBox.Show(msg, "Errore");
                        msgs.Add(msg);
                    }
                    
                    res = false;
                }
                if (rp.progressivo == 0) {
                    string msg = "Non è ammissibile il progressivo zero per il mandato numero " + rp.ndoc.ToString() + ".";
                    if (!msgs.Contains(msg)) {
                        MessageBox.Show(msg, "Errore");
                        msgs.Add(msg);
                    }
                    res = false;
                }
                rp.kdoc = k;
            }

            foreach (RigaReversale rr in Reversali) {
                int k = CfgFn.GetNoNullInt32(tProceeds.getField(rr.ndoc, "kpro"));
                if (k == 0) {
                    string msg = "Non esiste la reversale numero " + rr.ndoc.ToString() + " nell'esercizio corrente.";
                    if (!msgs.Contains(msg)) {
                        MessageBox.Show(msg, "Errore");
                        msgs.Add(msg);
                    }                    
                    res = false;
                }
                if (rr.progressivo == 0) {
                    string msg = "Non è ammissibile il progressivo zero per la reversale numero " + rr.ndoc.ToString() + ".";
                    if (!msgs.Contains(msg)) {
                        MessageBox.Show(msg, "Errore");
                        msgs.Add(msg);
                    }
                    res = false;
                }
                rr.kdoc = k;
            }




            return res;
        }

    }

    /// <summary>
    /// Summary description for ImportazioneEsitiBancari.
    /// </summary>
    public  class ImportazioneEsitiBancari {
       

        public static DatiImportati ImportFile(DataAccess Conn,string fname, object idbank) {
            if (idbank == null || idbank == DBNull.Value) {
                   MessageBox.Show("E' necessario selezionare una banca","Errore");
                return null;
            }
            DatiImportati I = null;
            List<string> abi = new List<string>();
            abi.AddRange(new string[] { "05696", "03067", "03111", "01030",
                                        "02008", "05372", "01010", "08661", "01010",
                                        "06065", "03069", "05262", "08553", "03019","05216","03599" });
            if (!abi.Contains(idbank.ToString())) {
                MessageBox.Show("La banca selezionata non è al momento gestita dall'applicazione", "Errore");
                return null;
            }

            if (idbank.ToString() == "05696") I = import_sondrio.ImportaFile(Conn,fname);
            if ((idbank.ToString() == "03067")|| (idbank.ToString() == "03111")) I = import_carime.ImportaFile(Conn, fname); //Carime / Ubi Banca
            if (idbank.ToString() == "01030") I = import_mps.ImportaFile(Conn, fname); // DA RIMUOVERE
            if (idbank.ToString() == "02008") I = import_unicredit.ImportaFile(Conn, fname);
            if (idbank.ToString() == "05372") I = import_bpcassinate.ImportaFile(Conn, fname);
            //if (idbank.ToString() == "08661") I = import_bccirpina.ImportaFile(Conn, fname);
            if (idbank.ToString() == "01010") I = import_intesasanpaolo.ImportaFile(Conn, fname);  // Banco di Napoli
            //if (idbank.ToString() == "06065") I = import_intesasanpaolo.ImportaFile(Conn, fname);  // IntesaSanPaolo
            if (idbank.ToString() == "03069") I = import_intesasanpaolo.ImportaFile(Conn, fname);  // IntesaSanPaolo
            if (idbank.ToString() == "05262") I = import_bppugliese.ImportaFile(Conn, fname);  // Banca Popolare Pugliese
            //if (idbank.ToString() == "05262") I =  import_bppugliese_2.ImportaFile(Conn, fname);  // Banca Popolare Pugliese
            if ((idbank.ToString() == "08553") || (idbank.ToString() == "03599")) I = import_bccflumeri.ImportaFile(Conn, fname);  // Banca Credito Cooperativo Flumeri
            if (idbank.ToString() == "03019") I = import_creditosiciliano.ImportaFile(Conn, fname);  // Credito Siciliano
            if (idbank.ToString() == "05216") I = import_creditosiciliano.ImportaFile(Conn, fname);  // Credito Valtellinese
            //if (idbank.ToString() == "01030") I = import_mps_abi36.ImportaFile(Conn, fname); //Monte dei Paschi di Siena ABI 36
            if (I == null) return null;
            if (!verificaDoppiaImportazioneNonOpi(Conn,I,idbank)) I.DatiValidi=false;
            if (!I.CalcolaChiaviDocumenti(Conn)) I.DatiValidi=false;
            return I;
        }


        public static DatiImportati[] ImportFileSiopePlus(DataAccess Conn, /*object idbank,*/ DateTime inizio, DateTime fine) {
            //if (idbank == null || idbank == DBNull.Value) {
            //    MessageBox.Show("E' necessario selezionare una banca", "Errore");
            //    return null;
            //}
            //Chiamata GET per chiedere il file del Giornale di Cassa
            string errore;
            var Giornaledicassa = PagoPaService.LeggiGiornaledicassa(Conn, inizio, fine, out errore);
            if (errore != null) {
                MessageBox.Show(errore, "Errore");
                ErrorLogger.Logger.logException("Errore - PagoPaService.LeggiGiornaledicassa()[WS OPI]");
                return null;
            }
            if (Giornaledicassa == null) {
                MessageBox.Show("Nessun file ricevuto", "Errore");
                ErrorLogger.Logger.logException("Avviso - Nessun file ricevuto[WS OPI]");
                return null;
            }
            int nDoc = Giornaledicassa.Length;
            DatiImportati[] allDatiImportati = new DatiImportati[nDoc];
            int i = 0;
            
            string idbank = null;
            foreach (Stream Giornale in Giornaledicassa) {
                
                var I = import_siopeplus.ImportaFile(Conn, Giornale, out idbank);//Da valutare un'eventuale condizione
                Giornale.Close();
                Giornale.Dispose();
                if (I == null) return null;
                if (GiornaleGiaImportato(Conn, I, idbank)) I.DatiValidi = false;
                //if (!verificaDoppiaImportazioneNonOpi(Conn, I, idbank)) I.DatiValidi = false;
                if (!I.CalcolaChiaviDocumenti(Conn)) I.DatiValidi = false;
                allDatiImportati[i] = I;
                i++;
            }
            return allDatiImportati; 
        }

        private static DateTime CalcolaData(string data) {
            int Anno = CfgFn.GetNoNullInt32(data.Substring(0, 4));
            int Mese = CfgFn.GetNoNullInt32(data.Substring(4, 2));
            int Giorno = CfgFn.GetNoNullInt32(data.Substring(6, 2));
            DateTime dataDt = new DateTime(Anno, Mese, Giorno);
            return dataDt;

        }
        /// <summary>
        /// Cerca di capire se il file in esame è stato già oggetto di elaborazione, nel qual caso avvisa e restituisce false
        /// </summary>
        /// <param name="Conn"></param>
        /// <param name="M"></param>
        /// <param name="idbank"></param>
        /// <returns></returns>
        

        public static DatiImportati ImportFileManualeSiopePlus(DataAccess Conn, string fname) {
            //if (idbank == null || idbank == DBNull.Value) {
            //    MessageBox.Show("E' necessario selezionare una banca", "Errore");
            //    return null;
            //}
            //Chiamata GET per chiedere il file del Giornale di Cassa

            DatiImportati I = null;
            string idbank = null;

            I = import_siopeplus.ImportaFileManuale(Conn, fname, out idbank);
            if (I == null) return null;
            if (GiornaleGiaImportato(Conn, I, idbank)) I.DatiValidi = false;
            //if (!verificaDoppiaImportazione(Conn, I, idbank)) I.DatiValidi = false;
            if (!I.CalcolaChiaviDocumenti(Conn)) I.DatiValidi = false;
           
            return I;
        }



        /// <summary>
        /// Cerca di capire se il file in esame è stato già oggetto di elaborazione, nel qual caso avvisa e restituisce false
        /// </summary>
        /// <param name="dataGrid1"></param>
        /// <param name="txtInizioElaborazione"></param>
        /// <param name="txtFineElaborazione"></param>
        /// <returns></returns>
        private static bool verificaDoppiaImportazioneNonOpi(DataAccess Conn, DatiImportati M, object idbank) {
            QueryHelper QHS = Conn.GetQueryHelper();
            DateTime lastpayment = new DateTime(1900, 1, 1);
            DateTime lastproceeds = new DateTime(1900, 1, 1);
            DateTime lastbillincome = new DateTime(1900, 1, 1);
            DateTime lastbillexpense = new DateTime(1900, 1, 1);
            decimal totalpayment = 0;
            decimal totalproceeds = 0;
            decimal totalbillincome_plus = 0;
            decimal totalbillincome_minus = 0;
            decimal totalbillexpense_plus = 0;
            decimal totalbillexpense_minus = 0;

            foreach (RigaMandato R in M.Mandati) {
                totalpayment += R.amount;
                if (R.transactiondate == DBNull.Value) continue;
                if (lastpayment < (DateTime)R.transactiondate) lastpayment = (DateTime) R.transactiondate;
            }
            foreach (RigaReversale R in M.Reversali) {
                totalproceeds += R.amount;
                if (R.transactiondate == DBNull.Value) continue;
                if (lastproceeds < (DateTime)R.transactiondate) lastproceeds = (DateTime)R.transactiondate;
            }
            foreach (ProvvisorioEntrata R in M.BolletteEntrata) {
                totalbillincome_plus += R.amount > 0 ? R.amount : 0;
                totalbillincome_minus += R.amount < 0 ? -R.amount : 0;
                if (R.data == DBNull.Value) continue;
                if (lastbillincome < (DateTime)R.data) lastbillincome = (DateTime)R.data;
            }
            foreach (ProvvisorioSpesa R in M.BolletteSpesa) {
                totalbillexpense_plus += R.amount > 0 ? R.amount : 0;
                totalbillexpense_minus += R.amount < 0 ? -R.amount : 0;
                if (R.data == DBNull.Value) continue;
                if (lastbillexpense < (DateTime)R.data) lastbillexpense = (DateTime)R.data;
            }

            string cond = QHS.AppAnd(
                        QHS.CmpEq("idbank",idbank), QHS.CmpEq("ayear",Conn.GetEsercizio()),
                        QHS.CmpEq("lastpayment", lastpayment), QHS.CmpEq("lastproceeds", lastproceeds),
                        QHS.CmpEq("lastbillincome", lastbillincome), QHS.CmpEq("lastbillexpense", lastbillexpense),
                        QHS.CmpEq("totalpayment", totalpayment), QHS.CmpEq("totalproceeds", totalproceeds),
                        QHS.CmpEq("totalbillincome_plus", totalbillincome_plus), QHS.CmpEq("totalbillincome_minus", totalbillincome_minus),
                        QHS.CmpEq("totalbillexpense_plus", totalbillexpense_plus), QHS.CmpEq("totalbillexpense_minus", totalbillexpense_minus)
            );

            if (Conn.RUN_SELECT_COUNT("bankimport", cond, false) > 0) {
                if (M.Mandati.Count == 0 && M.Reversali.Count == 0) {
                    if (verificaDoppiaImportazioneSospesi(Conn, M)) {//caso speciale solo bollette
                        return true;
                    }                   
                }
                MessageBox.Show(
                    "Il file selezionato è stato già IN PASSATO importato nel db. Operazione non consentita.",
                    "Errore");
                return false;
            }

            //if (!verificaDoppiaImportazioneSolodate(Conn, M,idbank, lastbillexpense, lastbillincome, lastpayment, lastproceeds)) {
            //    MessageBox.Show("Il file selezionato è stato già IN PASSATO importato nel db. Operazione non consentita.", "Errore");
            //    return false;
            //}

            return true;
        }

        /// Cerca di capire se il file in esame è stato già oggetto di elaborazione, nel qual caso avvisa e restituisce false
        /// </summary>
        /// <param name="Conn"></param>
        /// <param name="M"></param>
        /// <param name="idbank"></param>
        /// <returns></returns>
        private static bool GiornaleGiaImportato(DataAccess Conn, DatiImportati M, object idbank) {
            QueryHelper QHS = Conn.GetQueryHelper();
            string identificativo_flusso_BT = M.identificativo_flusso_BT;
            if (identificativo_flusso_BT == null) {
                MessageBox.Show(
                    "Il flusso non ha l'identificativo, non è possibile importarlo.",
                    "Errore");
                return true;
            }
            //GDC-2019011720190117185938720#001#001
            //GDC - 2019 01 17 2019 01 17 185938720#001#001
            string datainizio = identificativo_flusso_BT.Substring(4, 8);
            string datafine = identificativo_flusso_BT.Substring(13, 8);

            //Non serve, essendo il formato AAAAMMDD possiamo confrontare direttamente le stringhe
            //DateTime datainizioDt = CalcolaData(datainizio);
            //DateTime datafineDt = CalcolaData(datafine);

            string cond = QHS.AppAnd(
                //QHS.CmpEq("idbank", idbank),
                QHS.CmpEq("ayear",Conn.GetEsercizio()),
                QHS.CmpEq("identificativo_flusso_BT", identificativo_flusso_BT));
            //    QHS.IsNotNull("identificativo_flusso_BT"),
            //    QHS.DoPar(QHS.AppOr(
            //        QHS.Between("substring(identificativo_flusso_bt,5,8)",datainizio, datafine),
            //        QHS.Between("substring(identificativo_flusso_bt, 14,8)", datainizio, datafine)))

            //);

            if (Conn.RUN_SELECT_COUNT("bankimport", cond, false) > 0) {
                MessageBox.Show(
                    "Il file selezionato è stato già IN PASSATO importato nel db. Operazione non consentita(flusso_BT)."+ identificativo_flusso_BT,
                    "Errore");
                return true;
            }

            return false;
        }

        /// <summary>
        /// Restituisce true se ci sono bollette nel flusso non ancora importate
        /// </summary>
        /// <param name="Conn"></param>
        /// <param name="M"></param>
        /// <returns></returns>
        private static bool verificaDoppiaImportazioneSospesi(DataAccess Conn, DatiImportati M) {
            QueryHelper Q = Conn.GetQueryHelper();
            CQueryHelper QHC = new CQueryHelper();
            DataTable billDebit = Conn.RUN_SELECT("bill", "ybill, nbill, billkind", null,
                Q.AppAnd(Q.CmpEq("ybill", Conn.GetSys("esercizio")),
                    Q.CmpEq("billkind", "D")), null, null, true);
            // Verifica presenza sospesi uscita salvati su DB
            foreach (ProvvisorioSpesa R in M.BolletteSpesa) {
                string filter = QHC.AppAnd(QHC.CmpEq("ybill", R.y), QHC.CmpEq("nbill", R.nbill));
                if (billDebit.Select(filter).Length == 0) {
                    return true;
                }
            }

            DataTable billCredit = Conn.RUN_SELECT("bill", "ybill, nbill, billkind", null,
                Q.AppAnd(Q.CmpEq("ybill", Conn.GetSys("esercizio")),
                    Q.CmpEq("billkind", "C")), null, null, true);
            // Verifica presenza sospesi entrata salvati su DB
            foreach (ProvvisorioEntrata R in M.BolletteEntrata) {
                string filter = QHC.AppAnd(QHC.CmpEq("ybill", R.y), QHC.CmpEq("nbill", R.nbill));
                if (billCredit.Select(filter).Length == 0) {
                    return true;
                }
            }

            return false;
        }

        // Cerca di capire se il file in esame è stato già oggetto di elaborazione verificando che non esista una riga
        // in bankimport con Data ultimo mandato > della Data ultimo mandato presente nel flusso 
        // OR Data ultima reversale  > della Data ultima reversale presente nel flusso 
        // OR Data ultimo provvisorio di entrata/uscita > della Data ultimo provvisorio di entrata/uscita  presente nel flusso
        private static bool verificaDoppiaImportazioneSolodate(DataAccess Conn, DatiImportati M, object idbank,
            DateTime lastbillexpense, DateTime lastbillincome, DateTime lastpayment, DateTime lastproceeds) {
            QueryHelper QHS = Conn.GetQueryHelper();
            string cond2 = "";
            if (M.Mandati.Count > 0) {
                cond2 = QHS.AppAnd(
                        QHS.CmpEq("idbank", idbank), QHS.CmpGt("lastpayment", lastpayment));
            }
            if (M.Reversali.Count > 0) {
                if (cond2 == "") {
                    cond2 = QHS.AppAnd(QHS.CmpEq("idbank", idbank), QHS.CmpGt("lastproceeds", lastproceeds));
                }
                cond2 = GetData.MergeWithOperator(cond2, QHS.AppAnd(
                        QHS.CmpEq("idbank", idbank), QHS.CmpGt("lastproceeds", lastproceeds)), "OR");
            }
            if (M.BolletteSpesa.Count > 0) {
                if (cond2 == "") {
                    cond2 = QHS.AppAnd(
                        QHS.CmpEq("idbank", idbank), QHS.CmpGt("lastbillincome", lastbillincome));
                }
                else {
                    cond2 = GetData.MergeWithOperator(cond2, QHS.AppAnd(
                        QHS.CmpEq("idbank", idbank), QHS.CmpGt("lastbillincome", lastbillincome)), "OR");
                }
            }
            if (M.EsitiBolletteEntrata.Count > 0) {
                if (cond2 == "") {
                    cond2 = QHS.AppAnd(
                        QHS.CmpEq("idbank", idbank), QHS.CmpGt("lastbillexpense", lastbillexpense));
                }
                else {
                    cond2 = GetData.MergeWithOperator(cond2, QHS.AppAnd(
                        QHS.CmpEq("idbank", idbank), QHS.CmpGt("lastbillexpense", lastbillexpense)), "OR");
                }
            }
            if (Conn.RUN_SELECT_COUNT("bankimport", cond2, false) > 0) {
                return false;
            }
            return true;
        }

        }
}
