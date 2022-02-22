
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



using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
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
using System.Drawing.Imaging;

namespace csa_import_inail_maxphase {

    public class quotaMovimento {
        public DataRow mov;
        public decimal quota;
        public quotaMovimento(DataRow mov, decimal quota) {
            this.mov = mov;
            this.quota = quota;
        }

        public quotaMovimento splittaQuota(decimal splitAmount) {
            var newQuota = new quotaMovimento(mov, splitAmount);
            quota -= splitAmount;
            return newQuota;
        }
    }


    public class MovimentoRaggruppato {

        public int nMaxReversali = 30;
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
        public quotaMovimento quotaSpesa;


        /// <summary>
        /// Lista incassi collegati
        /// </summary>
        public List<quotaMovimento> quoteEntrata = new List<quotaMovimento>();

        decimal netto = 0;

        public int nReversali() {
            return quoteEntrata.Count;
        }

        public bool saturoReversali() {
            return quoteEntrata.Count == nMaxReversali;
        }
        public bool collegamentoPossibileSenzaSplit(quotaMovimento entrata) {
            return quotaSpesaResiduaPerReversali() >= entrata.quota;
        }

        public decimal importoNetto() {
            return netto;
        }
        /// <summary>
        /// Restituisce la quota disponibile per agganciare nuove reversali
        /// </summary>
        /// <returns></returns>
        public decimal quotaSpesaResiduaPerReversali() {
            if (netto == 0) return 0;
            if (nReversali() >= nMaxReversali) return 0;
            return netto;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public MovimentoRaggruppato splittaResiduo() {
            if (netto == 0) return null;
            quotaMovimento spesaSplit = quotaSpesa.splittaQuota(netto);
            var nuovo = new MovimentoRaggruppato(spesaSplit);
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

        public void addSpesa(DataRow r, decimal importo) {
            var quotaSpesa = new quotaMovimento(r, importo);
            movimenti.Add(new MovimentoRaggruppato(quotaSpesa));
            totaleNetto += importo;
        }

        public void addEntrata(DataRow r, decimal importo) {
            entrateDaCollegare.Add(new quotaMovimento(r, importo));
            totaleNetto -= importo;
        }

        /// <summary>
        /// Cerca il raggruppamento di spesa con massimo residuo collegabile
        /// </summary>
        /// <returns></returns>
        MovimentoRaggruppato movConMassimoResiduo() {
            MovimentoRaggruppato movConMassimoDisponibile = null;
            foreach (var mov in movimenti) {
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
            if (mov.importoNetto() == 0) return;
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
            if (totaleNetto < entrata.quota) return false;

            if (collegaEntrataMatchEsatto(entrata)) return true;
            if (collegaEntrataMatchMassimaCapienza(entrata)) return true;

            //Dato che ogni volta che colleghiamo un'entrata splittiamo il netto ove ci siano 30 reversali,
            // non è possibile che vi sia un movimento con disponibile sufficiente ma 30 reversali
            //Quindi vi devono essere movimenti di spesa con disponibilità insufficiente e meno di 30 reversali
            //A questo punto ad ognuno di loro associamo una quota dell'entrata data
            while (entrata.quota > 0) {
                MovimentoRaggruppato maxDisp = movConMassimoResiduo();
                if (maxDisp == null) return false; //non dovrebbe accadere
                decimal residuo = maxDisp.importoNetto();
                if (residuo >= entrata.quota) {
                    //il movimento considerato è capiente per quel che rimane dell'entrata
                    collegaEntrataAGruppo(entrata, maxDisp);
                    return true;
                }

                var quotaEntrata = entrata.splittaQuota(residuo);
                maxDisp.addEntrata(quotaEntrata);
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
            List<MovimentoRaggruppato> toAdd = new List<MovimentoRaggruppato>();
            foreach (MovimentoRaggruppato mov in movimenti) {
                decimal netto = mov.importoNetto();
                if (netto == 0) continue;
                if (mov.nReversali() == 0) continue; //è già Netto
                MovimentoRaggruppato nuovo = mov.splittaResiduo();
                toAdd.Add(nuovo);
            }

            foreach (var r in toAdd) {
                movimenti.Add(r);
            }
        }

        public void ottieniMovimentiAZero(List<MovimentoRaggruppato> spese) {
            foreach (var mov in movimenti) {
                if (mov.importoNetto() == 0) spese.Add(mov);
            }
        }
        public void ottieniMovimentiNetti(List<MovimentoRaggruppato> spese) {
            foreach (var mov in movimenti) {
                if (mov.nReversali() == 0) spese.Add(mov);
            }
        }
    }

    public class nuovaGestionOutTable {
        public static DataTable calcola(string kind, DataTable OutTable, DataAccess conn,
            out List<MovimentoRaggruppato> mov) {
            mov = null;
            var righePerAnagrafica = new Dictionary<int, RigheAnagrafica>();

            //Raggruppa tutte le righe per anagrafica
            foreach (DataRow r in OutTable.Rows) {
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
            //Per ogni raggruppamento per anagrafica effettua le nettizzazioni ed i collegamenti tra entrate e spese
            foreach (var rAnag in righePerAnagrafica.Values) {
                if (!rAnag.collegaTutteEntrate()) {
                    MetaFactory.factory.getSingleton<IMessageShower>().Show(
                        $"L'importo del movimento netto verso l'Anagrafica {rAnag.registry} è negativo"
                        , "Errore");
                    someError = true;
                }
            }

            if (someError) {
                MetaFactory.factory.getSingleton<IMessageShower>().Show("Poichè sono stati riscontrati problemi, l'elaborazione sarà annullata.", "Avviso");
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

            DataTable nuoviMovimenti = OutTable.Clone();

            nuoviMovimenti.Columns.Add("indice", typeof(int));
            nuoviMovimenti.Columns.Add("nriga", typeof(int));
            nuoviMovimenti.Columns.Add("idmovimento", typeof(string));
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
                rSpesa["nriga"] = currIndiceSpesa;
                currIndice++;
                nuoviMovimenti.Rows.Add(rSpesa);
                rSpesa["netto"] = m.importoNetto();
                foreach (var qEntrata in m.quoteEntrata) {
                    var rEntrata = nuoviMovimenti.NewRowAs(qEntrata.mov);
                    rEntrata["amount"] = qEntrata.quota;
                    rEntrata["indice"] = currIndiceSpesa; //indice in nuoviMovimenti della spesa collegate
                    rEntrata["nriga"] = currIndice;
                    currIndice++;
                    nuoviMovimenti.Rows.Add(rEntrata);
                }
            }

            nuoviMovimenti.AcceptChanges();

            foreach (MovimentoRaggruppato m in listaMov) {
                //creare in nuoviMovimenti una copia di m.quotaSpesa.mov avente però importo m.quotaSpesa.quota  (1)
                //creare in nuoviMovimenti una copia di tutti gli incassi presenti in m.quoteEntrata
                // ognuno pari alla campo mov dell'elemento considerato e importo quota
                //   ognuno collegato al movimento (1)

            }

            var qhs = conn.GetQueryHelper();
            var qhc = new CQueryHelper();
            // esce fuori una specie di SP_Result rispetto alla gestione precedente
            var spResult = nuoviMovimenti;





            return spResult;
        }
    }
}
