
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
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Linq;
using System.IO;
using System.Text;
using System.Globalization;
using metadatalibrary;
using metaeasylibrary;
using funzioni_configurazione;
using System.Diagnostics;
using movimentofunctions;
using ep_functions;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Drawing.Imaging;

namespace csa_import_default {

    public class QuoteCsa {
        Dictionary<int, List<quotaMovimento>> listaMovimenti= new Dictionary<int, List<quotaMovimento>>();
        private string sourceKeyField;
        private string destKeyField;  //
        public QuoteCsa(string sourceKeyField,string destKeyField) {
            this.sourceKeyField = sourceKeyField;
            this.destKeyField = destKeyField;
        }

        //public void unlinkMov(DataRow fromRow, quotaMovimento quotaCsa) {
        //    int nriga = CfgFn.GetNoNullInt32(fromRow[idfield]);
        //    if (!listaMovimenti.ContainsKey(nriga)) return;
        //    var listaCollegata = listaMovimenti[nriga];
        //    listaCollegata.Remove(quotaCsa);    //Primo dubbio: non è che non sta funzionando e rimane sempre tutto dov'è??        
        //}

        /// <summary>
        /// Collega una riga csa ad una riga di spesa
        /// </summary>
        /// <param name="expenseRow"></param>
        /// <param name="rCsa"></param>
        public void linkToMov(DataRow destRow, DataRow sourceRow, decimal amount) {
            int nriga = CfgFn.GetNoNullInt32(destRow[destKeyField]);
            if (!listaMovimenti.ContainsKey(nriga)) listaMovimenti[nriga]=new List<quotaMovimento>();
            var linked = listaMovimenti[nriga];
            int IdToLink = CfgFn.GetNoNullInt32(sourceRow[sourceKeyField]);//sempre quello originale della riga della tabella csa
            foreach (var r in linked) {
                int currId = CfgFn.GetNoNullInt32(r.mov[sourceKeyField]);
                if (currId == IdToLink) {
                    r.quota += amount;
                    return;
                }
            }
            linked.Add(new quotaMovimento(sourceRow,amount));
        }

        /// <summary>
        /// Collega una riga csa ad una riga di spesa, con l'importo della quota CSA
        /// </summary>
        /// <param name="expenseRow"></param>
        /// <param name="rCsa"></param>
        public void linkToMov(DataRow movRow, DataRow rCsa) {
            linkToMov(movRow, rCsa, CfgFn.GetNoNullDecimal(rCsa["amount"]));
        }



        /// <summary>
        ///  Restituisce le righe di csa collegate ad un movimento elaborato
        /// </summary>
        /// <param name="incomeRow"></param>
        /// <returns></returns>
        public List<quotaMovimento> getLinkedToMov(DataRow destRow) {
            int nriga = CfgFn.GetNoNullInt32(destRow[destKeyField]);
            if (listaMovimenti.ContainsKey((nriga))) return listaMovimenti[nriga];
            return new List<quotaMovimento>();
        }

        /// <summary>
        /// Sposta in dest una serie di righe per coprire l'importo indicato, prendendole da quelle collegate a movRow
        /// </summary>
        /// <param name="movRow">Movimento finanziario</param>
        /// <param name="dest">lookup destinazione</param>
        public void MoveQuoteTo(DataRow movRow, QuoteCsa dest) {
            decimal amountToCover = CfgFn.GetNoNullDecimal(movRow["amount"]);
            while (amountToCover>0) {
                var linked = getLinkedToMov(movRow);
                if (linked.Count == 0) throw new Exception("Errore interno, c'è un movimento che non ha abbastanza righe csa collegate");
                var first = linked[0];
                decimal amountCsa = first.quota;
                if (amountCsa <= amountToCover) {
                    dest.linkToMov(movRow, first.mov, amountCsa);
                    linked.RemoveAt(0);                   //unlinkMov(movRow,first);
                    amountToCover -= amountCsa;
                    continue;
                }
                //importo amountCsa superiore, prende l'importo amountToCover
                dest.linkToMov(movRow, first.mov, amountToCover);
                first.quota -= amountToCover;
                amountToCover = 0;
            }
        }

    }

    public class quotaMovimento {
        public DataRow mov;		//movimento finanziario
        public decimal quota;
        public quotaMovimento(DataRow mov,decimal quota) {
            this.mov = mov;
            this.quota = quota;
        }

        public quotaMovimento splittaQuota(decimal splitAmount) {
            var newQuota = new quotaMovimento(mov,splitAmount);
            quota -= splitAmount;
            return newQuota;
        }
    }


    public class MovimentoRaggruppato {

        public int nMaxReversali=30;
        public MovimentoRaggruppato(quotaMovimento spesa) {
            quotaSpesa = spesa;
            netto = spesa.quota;
        }

        /// <summary>
        /// Aggiunge una entrata collegata e aggiorna il netto
        /// </summary>
        /// <param name="entrata"></param>
        /// <param name="quota"></param>
        public void addEntrata(quotaMovimento entrata) {
            quoteEntrata.Add(entrata);
            netto -= entrata.quota;
        }
        /// <summary>
        /// Movimento di spesa principale
        /// </summary>
        public  quotaMovimento quotaSpesa;


        /// <summary>
        /// Lista incassi collegati
        /// </summary>
        public List<quotaMovimento> quoteEntrata = new List<quotaMovimento>();

        decimal netto = 0;

        public int nReversali() {
            return quoteEntrata.Count;
        }

        //Verifica se il n. di incassi collegati  non sia già pari al massimo possibile
        public bool saturoReversali() {
            return quoteEntrata.Count == nMaxReversali;
        }

        //Verifica che il raggruppamento abbia un residuo sufficiente per l'entrata
        public bool collegamentoPossibileSenzaSplit(quotaMovimento entrata) {
            return quotaSpesaResiduaPerReversali() >= entrata.quota;
        }

        public decimal importoNetto() {
            return netto;
        }
        /// <summary>
        /// Restituisce la quota disponibile per agganciare nuove reversali. Tiene conto del numero massimo incassi collegabili.
        /// </summary>
        /// <returns></returns>
        public decimal quotaSpesaResiduaPerReversali() {
            if (netto == 0) return 0;
            if (nReversali() >= nMaxReversali) return 0;
            return netto;
        }

        /// <summary>
        /// Splitta il raggruppamento in due. Il netto del corrente viene portato a zero e posto in un nuovo raggruppamento, restituito in output
        /// </summary>
        /// <returns></returns>
        public MovimentoRaggruppato splittaResiduo() {
            if (netto == 0) return null;
            quotaMovimento spesaSplit = quotaSpesa.splittaQuota(netto);
            var nuovo= new MovimentoRaggruppato(spesaSplit);
            netto = 0;
            return nuovo;
        }



    }

    class RigheAnagrafica {
        private decimal totaleNetto = 0;
        public RigheAnagrafica() {

        }
        public string registry;
        //Elenco dei movimenti di spesa collegati ad una certa anagrafica
        public List<MovimentoRaggruppato> movimenti = new List<MovimentoRaggruppato>();

        private List<quotaMovimento> entrateDaCollegare = new List<quotaMovimento>();

        public void addSpesa(DataRow r,decimal importo) { 
            var quotaSpesa = new quotaMovimento(r,importo);           
            movimenti.Add(new MovimentoRaggruppato(quotaSpesa));
            totaleNetto += importo;
        }

        public void addEntrata(DataRow r,decimal importo) {
            entrateDaCollegare.Add(new quotaMovimento(r,importo));
            totaleNetto -= importo;
        }

        /// <summary>
        /// Cerca il raggruppamento di spesa con massimo residuo collegabile
        /// </summary>
        /// <returns></returns>
        MovimentoRaggruppato movConMassimoResiduo() {
            MovimentoRaggruppato movConMassimoDisponibile = null;
            foreach (var mov in movimenti) {//cerca il movimento con massimo residuo tra quelli in movimenti
                decimal residuoCorrente = mov.quotaSpesaResiduaPerReversali();
                if (residuoCorrente == 0) continue;
                if (movConMassimoDisponibile == null) {
                    movConMassimoDisponibile = mov;
                    continue;                    
                }
                if (movConMassimoDisponibile.quotaSpesaResiduaPerReversali() < residuoCorrente) {
                    movConMassimoDisponibile = mov;
                }
            }

            return movConMassimoDisponibile;
        }

    

        bool collegaEntrataMatchEsatto(quotaMovimento entrata) {
            //Cerca prima un match "pulito" e nel mentre cerca il movimento con massimo disponibile
            foreach (var mov in movimenti) {
                decimal residuoCorrente = mov.quotaSpesaResiduaPerReversali();
                if (residuoCorrente == 0) continue;
                if (residuoCorrente == entrata.quota) {
                    collegaEntrataAGruppo(entrata, mov);
                    return true;
                }
            }
            return false;
        }

        void splittaNettoSeSaturoReversali(MovimentoRaggruppato mov) {
            if(mov.importoNetto()==0)return;
            if (mov.saturoReversali()) {
                var nuovoMov = mov.splittaResiduo();
                movimenti.Add(nuovoMov);
            }
        }

        //Collega l'entrata sul movimento con massima capienza ove ce ne sia uno capiente
        bool collegaEntrataMatchMassimaCapienza(quotaMovimento entrata) {
            MovimentoRaggruppato maxDisp = movConMassimoResiduo();
            if (maxDisp == null) {
                return false;
            }

            if (maxDisp.collegamentoPossibileSenzaSplit(entrata)) {
                collegaEntrataAGruppo(entrata, maxDisp);
                return true;
            }

            return false;            
        }

        public void collegaEntrataAGruppo(quotaMovimento entrata, MovimentoRaggruppato mov) {
            mov.addEntrata(entrata);
            splittaNettoSeSaturoReversali(mov);
        }
   

        /// <summary>
        /// Può variare la collezione dei movimenti raggruppati ma non varia quella delle entrate
        /// </summary>
        /// <param name="entrata"></param>
        /// <returns></returns>
        bool collegaEntrata(quotaMovimento entrata) {
            if (totaleNetto < 0) return false;

            if (collegaEntrataMatchEsatto(entrata)) return true;
            if (collegaEntrataMatchMassimaCapienza(entrata)) return true;
            
            //Dato che ogni volta che colleghiamo un'entrata splittiamo il netto ove ci siano 30 reversali,
            // non è possibile che vi sia un movimento con disponibile sufficiente ma 30 reversali
            //Quindi vi devono essere movimenti di spesa con disponibilità insufficiente e meno di 30 reversali
            //A questo punto ad ognuno di loro associamo una quota dell'entrata data
            while (entrata.quota > 0) {
                MovimentoRaggruppato movimentoConMaxDisp = movConMassimoResiduo();
                if (movimentoConMaxDisp == null) return false; //non dovrebbe accadere
                decimal residuo = movimentoConMaxDisp.importoNetto();
                if (residuo >= entrata.quota) {
                    //il movimento considerato è capiente per quel che rimane dell'entrata
                    collegaEntrataAGruppo(entrata, movimentoConMaxDisp);
                    return true;
                }
                //mette su quel movimento quello che può, usandone il residuo
                var quotaEntrata = entrata.splittaQuota(residuo);
                movimentoConMaxDisp.addEntrata(quotaEntrata);
            }

            return true;
        }


        public bool collegaTutteEntrate() {
            foreach (quotaMovimento entrata in entrateDaCollegare) {
                if (!collegaEntrata(entrata)) return false;
            }
            return true;
        }

        public void creaNetti() {
            List<MovimentoRaggruppato> toAdd= new List<MovimentoRaggruppato>();
            foreach (MovimentoRaggruppato mov in movimenti) {
                decimal netto = mov.importoNetto();
                if (netto == 0) continue;
                if (mov.nReversali() == 0) continue; //è già Netto
                MovimentoRaggruppato nuovo= mov.splittaResiduo();
                toAdd.Add(nuovo);
            }

            foreach (var r in toAdd) {
                movimenti.Add(r);
            }
        }

        public void ottieniMovimentiAZero(List<MovimentoRaggruppato> spese) {
            foreach (var mov in movimenti) {
                if (mov.importoNetto()==0)spese.Add(mov);
            }
        }
        public void ottieniMovimentiNetti(List<MovimentoRaggruppato> spese) {
            foreach (var mov in movimenti) {
                if (mov.nReversali()==0)spese.Add(mov);
            }
        }
    }


    public class nuovaGestionOutTable {
        public static DataTable calcola(DataTable movimentiCsa, DataAccess conn, out QuoteCsa quote) {
            //Raggruppa tutti i movimenti di uscita netti in base a capitolo, upb, anagrafica, siope?, movimento parent
            //Sin qui la struttura prevede che ogni movimento abbia in se l'idriep e l'idver,  ove lo stesso idriep e ver possono essere collegati a più movimenti, sebbene 
            // ogni movimento sia associato unicamenteo ad un idriep o idver. La quota assegnata a quell'idriep è dunque l'intero movimento

            //Ora dobbiamo raggruppare i movimenti in base alle coordinate finanziarie, ci serve quindi una tabella di corrispondenza 1 a N tra movimenti finanziari e 
            // idriep / idver collegati, con relative quote

            decimal totSpeseIniziale = 0;
            decimal totEntrateIniziale = 0;
            foreach (DataRow r in movimentiCsa.Rows) {
                decimal amount = CfgFn.GetNoNullDecimal(r["amount"]);
                if (r["kind"].ToString() == "Spesa") {
                    totSpeseIniziale += amount;
                }
                else {
                    totEntrateIniziale += amount;
                }
            }

            // Si crea una chiave per distinguere le righe 
            movimentiCsa.Columns.Add(new DataColumn("id_privato_temp", typeof(Int32)));            

            //Raggruppa i movimenti in base al finanziario, segnandosi le righe originarie csa da collegare
            movGrouped grouper = new movGrouped(movimentiCsa,"id_privato_temp");

           

            decimal totSpeseIntermedio = 0;
            decimal totEntrateIntermedio = 0;
            foreach (DataRow r in movimentiCsa.Rows) {
                decimal amount = CfgFn.GetNoNullDecimal(r["amount"]);
                if (r["kind"].ToString() == "Spesa") {
                    totSpeseIntermedio += amount;
                }
                else {
                    totEntrateIntermedio += amount;
                }
            }

            QuoteCsa lookupQuote;
            var groupedMovs = grouper.elabora(out lookupQuote);
			//formtest frm = new formtest(groupedMovs , movimentiCsa);

			//DialogResult dr = frm.ShowDialog();

			//lookupQuote = elenco di associazioni "nuova riga"(int) a "elenco righe csa originali, pro quota"
			//  "nuova riga" è proprio l'indice in groupedMovs 


			//Effettua i collegamenti entrate-spese sui movimenti raggruppati
			var linkedMovs = collegaEntrateASpese(groupedMovs, conn);
            if (linkedMovs == null) {
                quote = null;
                return null;
            }

            //In linkedMovs il valore di idfield non è univoco

            linkedMovs.Columns.Add(new DataColumn("id_definitivo", typeof(Int32)));            
            for (int i = 0; i < linkedMovs.Rows.Count; i++) linkedMovs.Rows[i]["id_definitivo"] = i;

            quote = new QuoteCsa("id_privato_temp","id_definitivo");
         
            //Associa le righe originarie csa ai movimenti raggruppati
            //Ad ogni riga in linkedMovs associa una parte delle righe associate in quote
            // linkedMovs ha gli id_privato_temp ripetuti 
            // lookupQuote collega id_privato_temp  a   N righe Csa
            foreach (DataRow r in linkedMovs.Rows) {
                //decimal importoMovimento = CfgFn.GetNoNullDecimal(r);                
                //il movimento collegato può avere un importo minore di quello originariamente collegato, per via di split a causa delle nettizzazioni, suddivisione incassi e varie
                //Ossia r[idfield] può avere valori ripetuti in linkedMovs.Rows
                lookupQuote.MoveQuoteTo(r,quote);
            }

            decimal totSpeseFinale = 0;
            decimal totEntrateFinale = 0;
            //linkedMovs.Columns.Remove("id_privato_temp");      
            foreach (DataRow r in linkedMovs.Rows) {
                decimal amount = CfgFn.GetNoNullDecimal(r["amount"]);
                if (r["kind"].ToString() == "Spesa") {
                    totSpeseFinale += amount;
                }
                else {
                    totEntrateFinale += amount;
                }
            }

            //MessageBox.Show(
            //    $"Totale spese: iniziale: {totSpeseIniziale}  intermedio:{totSpeseIntermedio}  finale:{totSpeseFinale} \n\r" +
            //    $"Totale entrate: iniziale: {totEntrateIniziale}  intermedio:{totEntrateIntermedio}  finale:{totEntrateFinale} \n\r");

            return linkedMovs;
        }


        public static DataTable collegaEntrateASpese(DataTable movimentiCsa, DataAccess conn) {
            var righePerAnagrafica = new Dictionary<int, RigheAnagrafica>();

            //Raggruppa tutte le righe per anagrafica
            foreach (DataRow r in movimentiCsa.Rows) {
                var importo = CfgFn.GetNoNullDecimal(r["amount"]);

                var idreg = CfgFn.GetNoNullInt32(r["idreg"]);
                RigheAnagrafica rA;
                if (righePerAnagrafica.ContainsKey(idreg)) {
                    rA = righePerAnagrafica[idreg];
                }
                else {
                    rA = new RigheAnagrafica();
                    rA.registry = r["registry"].ToString();
                    righePerAnagrafica[idreg] = rA;
                }

                if (r["kind"].ToString() == "Spesa") {
                    rA.addSpesa(r, importo);
                }
                else {
                    rA.addEntrata(r, importo);
                }
            }

            bool someError = false;
            //Per ogni raggruppamento per anagrafica effettua le netizzazioni ed i collegamenti tra entrate e spese
            foreach (var rAnag in righePerAnagrafica.Values) {
                if (!rAnag.collegaTutteEntrate()) {
                    MessageBox.Show(
                        $"L'importo del movimento netto verso l'Anagrafica {rAnag.registry} è negativo"
                        , "Errore");
                    someError=true;
                }
            }

            if (someError) {
                MessageBox.Show("Poichè sono stati riscontrati problemi, l'elaborazione sarà annullata.", "Avviso");
                return null;
            }
            //Per ogni raggruppamento rimanente avente un netto maggiore di zero e con reversali, ne prende il netto
            foreach (var rAnag in righePerAnagrafica.Values) {
                rAnag.creaNetti();
            }

            var listaMov = new List<MovimentoRaggruppato>();
            foreach (var rAnag in righePerAnagrafica.Values) {
                rAnag.ottieniMovimentiAZero(listaMov);
                rAnag.ottieniMovimentiNetti(listaMov);
            }


            //listaMovNetti contiene i movimenti raggruppati ognuno formato da un insieme di quote di movimenti di spesa da ottenere 

            //listaMovAZero contiene i movimenti raggruppati ognuno formato da un insieme di quote di movimenti di spesa collegati
            //  ad un insieme di incassi di pari importo

            DataTable nuoviMovimenti = movimentiCsa.Clone();

            nuoviMovimenti.Columns.Add("indice", typeof(int));          //indice in nuoviMovimenti della spesa collegata (solo per le entrate)
            nuoviMovimenti.Columns.Add("nriga", typeof(int));           //indice della riga nella tabella stessa
            nuoviMovimenti.Columns.Add("idmovimento", typeof(string));  //valorizzato nel calcolo dei mov fin.
            nuoviMovimenti.Columns.Add("netto", typeof(decimal));


            // Ogni movimento raggruppato ha un campo quotaSpesa che contiene i dati del movimento di spesa da generare
            //  ed il campo quoteEntrata con tutti i movimenti di entrata da collegare allo stesso

            var currIndice = 0;
            foreach (var m in listaMov) {
                //creare in nuoviMovimenti una copia di m.quotaSpesa.mov avente però importo m.quotaSpesa.quota 
                var rSpesa = nuoviMovimenti.NewRowAs(m.quotaSpesa.mov);
                rSpesa["amount"] = m.quotaSpesa.quota;
                int currIndiceSpesa = currIndice;
                rSpesa["indice"] = currIndiceSpesa; //indice in nuoviMovimenti
                rSpesa["nriga"] = currIndiceSpesa;  //indice della riga nella tabella stessa
                currIndice++;
                nuoviMovimenti.Rows.Add(rSpesa);
                rSpesa["netto"] = m.importoNetto();
                foreach (var qEntrata in m.quoteEntrata) {
                    var rEntrata = nuoviMovimenti.NewRowAs(qEntrata.mov);
                    rEntrata["amount"] = qEntrata.quota;
                    rEntrata["indice"] = currIndiceSpesa; //indice in nuoviMovimenti della spesa collegata
                    rEntrata["nriga"] = currIndice;       //indice della riga nella tabella stessa
                    currIndice++;
                    nuoviMovimenti.Rows.Add(rEntrata);
                }
            }

            nuoviMovimenti.AcceptChanges();

            return nuoviMovimenti;
        
        }
    }

    public class movGrouped {
        Dictionary<string,int> lookupEntrate = new Dictionary<string, int>();   //dall'hash al n. riga del NUOVO movimento
        Dictionary<string,int> lookupSpese = new Dictionary<string, int>();     //dall'hash al n. riga del NUOVO movimento
        private QuoteCsa quote =null;
        private DataTable mov;

        
        string getHash(DataRow r) {
            string []fields = null;
            if (r["movkind"].ToString() == "Spesa") {
                fields = new[] { "parentidexp", "idman","idreg","idfin","idupb","idsor","idacc","idunderwriting"};
            }
            else {
                fields = new[] { "parentidexp", "idman","idreg","idfin","idupb","idsor","idacc","idunderwriting"};
            }
             
			string keytemp =string.Join("§", (from field in fields select r[field].ToString()).ToArray());
			if (r["idver"] != DBNull.Value) return keytemp + "ver";
			else return keytemp + "riep";

		}

        int createNewMovAs(DataRow sample) {
            int currIndice = mov.Rows.Count;
            DataRow r = mov.NewRowAs(sample);
            r[idfield] = currIndice;       //indice in nuoviMovimenti della spesa collegata
            mov.Rows.Add(r);
            return currIndice;
        }

      

        DataRow getMov(int nRiga) {
            return mov.Rows[nRiga];
        }

        /// <summary>
        /// Aggiunge una spesa raggruppando sulle coord. finanziarie, collegandola alla sua riga CSA in quote
        /// </summary>
        /// <param name="ripartizione"></param>
        /// <returns></returns>
        void addSpesaGrouped(DataRow ripartizione) {
            string h = getHash(ripartizione);
            int rigaCorrente = 0;
            if (!lookupSpese.ContainsKey(h)) {
                rigaCorrente = createNewMovAs(ripartizione);
                lookupSpese[h] = rigaCorrente;
            }
            else {
                rigaCorrente = lookupSpese[h];
                DataRow currRow = mov.Rows[rigaCorrente];
                currRow["amount"] = CfgFn.GetNoNullDecimal(currRow["amount"]) + CfgFn.GetNoNullDecimal(ripartizione["amount"]); //aumenta il valore della riga
            }

            //aggiunge alla riga corrente la ripartizione data in input
            quote.linkToMov(getMov(rigaCorrente), ripartizione);
        }

       
        /// <summary>
        /// Aggiunge un'entrata raggruppando sulle coord. finanziarie, collegandola alla sua riga CSA in quote
        /// </summary>
        /// <param name="ripartizione"></param>
        /// <returns></returns>
        void addEntrataGrouped(DataRow ripartizione) {
            string h = getHash(ripartizione);

            //Riga di entrata collegata alla ripartizione
            int rigaCorrente = 0;
            DataRow currRow;

            if (!lookupEntrate.ContainsKey(h)) {
                rigaCorrente = createNewMovAs(ripartizione);
                lookupEntrate[h] = rigaCorrente;
            }
            else {
                rigaCorrente = lookupEntrate[h];
                currRow   = getMov(rigaCorrente);
                currRow["amount"] = CfgFn.GetNoNullDecimal(currRow["amount"]) + CfgFn.GetNoNullDecimal(ripartizione["amount"]); //aumenta il valore della riga
            }
            //aggiunge alla riga corrente la ripartizione data in input
            quote.linkToMov(getMov(rigaCorrente), ripartizione);

        }

      

       

        private string idfield;

        private DataTable sourceTable;
        public movGrouped(DataTable sourceMov, string idfield) {
            for (int i = 0; i < sourceMov.Rows.Count; i++) sourceMov.Rows[i][idfield] = i;
            this.mov = sourceMov.Clone();   //solo struttura
            sourceTable = sourceMov;    
            this.idfield = idfield;
            quote =new QuoteCsa(idfield,idfield);

        }


        public DataTable elabora(out QuoteCsa q) {
            foreach (DataRow r in sourceTable.Rows) {
                if (r["kind"].ToString()=="Spesa") {
                    addSpesaGrouped(r);
                }
                else {
                    addEntrataGrouped(r);
                }
            }
         
            q = quote;
            return mov;
        }
        

    }
}
