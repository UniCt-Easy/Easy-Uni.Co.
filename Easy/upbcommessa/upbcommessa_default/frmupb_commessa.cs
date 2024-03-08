
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
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using metadatalibrary;
using metaeasylibrary;
using funzioni_configurazione;
using ep_functions;

namespace upbcommessa_default {
    public partial class frmupb_commessa : MetaDataForm {
        MetaData Meta;
        DataAccess Conn;
        CQueryHelper QHC = new CQueryHelper();
        QueryHelper QHS;
        EntityDispatcher Dispatcher;
        int esercizio;
        bool risconta_ammortamenti_futuri = false;
        private EP_Manager EPM;
        public frmupb_commessa() {
            InitializeComponent();
        }
        public void MetaData_AfterLink() {
            Meta = MetaData.GetMetaData(this);
            Dispatcher = Meta.Dispatcher as EntityDispatcher;
            Conn = Meta.Conn;
            esercizio = Conn.GetEsercizio();
         
            QHS = Conn.GetQueryHelper();
            //bool isAdmin = (bool)Meta.GetSys("IsSystemAdmin");
            DataAccess.SetTableForReading(DS.accmotive_accruals,"accmotive");
            DataAccess.SetTableForReading(DS.accmotive_accruals_original, "accmotive");
            DataAccess.SetTableForReading(DS.accmotive_cost, "accmotive");
            DataAccess.SetTableForReading(DS.accmotive_cost_original, "accmotive");
            DataAccess.SetTableForReading(DS.accmotive_deferredcost, "accmotive");
            DataAccess.SetTableForReading(DS.accmotive_deferredcost_original, "accmotive");
            DataAccess.SetTableForReading(DS.accmotive_revenue, "accmotive");
            DataAccess.SetTableForReading(DS.accmotive_revenue_original, "accmotive");
            DataAccess.SetTableForReading(DS.account_accruals, "account");
            DataAccess.SetTableForReading(DS.account_accruals_original, "account");
            DataAccess.SetTableForReading(DS.account_cost, "account");
            DataAccess.SetTableForReading(DS.account_cost_original, "account");
            DataAccess.SetTableForReading(DS.account_deferredcost, "account");
            DataAccess.SetTableForReading(DS.account_deferredcost_original, "account");
            DataAccess.SetTableForReading(DS.account_revenue, "account");
            DataAccess.SetTableForReading(DS.account_revenue_original, "account");
            DataAccess.SetTableForReading(DS.epupbkind_original, "epupbkind");
            
            GetData.SetStaticFilter(DS.upbcommessa, QHS.CmpEq("ayear", esercizio));
            GetData.SetStaticFilter(DS.epupbkindyear, QHS.CmpEq("ayear", esercizio));

            EPM = new EP_Manager(Meta, btnGeneraEpExp, btnVisualizzaEpExp, btnGeneraPreimpegni, btnVisualizzaPreimpegni,
                btnGeneraEP, btnVisualizzaEP,

                labEP, null, "upbcommessa");

           object risconta_ammortamenti_futuriObj = Conn.DO_READ_VALUE("config", QHS.CmpEq("ayear", esercizio), "risconta_ammortamenti_futuri");
           if (risconta_ammortamenti_futuriObj == DBNull.Value) risconta_ammortamenti_futuriObj = "N";
           risconta_ammortamenti_futuri = risconta_ammortamenti_futuriObj.ToString().ToUpper() == "S";
            

        }

        public void RicalcolaDatiCorrenti( out DataRow rTotAssetAmortization) {
            labelNoCommessaCompletata.Text = "";
            rTotAssetAmortization = null;
            if (Meta.IsEmpty) return; //return null;

            var curr = DS.upbcommessa[0];
            // CASO 1) Upb ancora aperto
            // year(U.yearstop) = > + esercizio  
            if (CfgFn.GetNoNullInt32(curr["yearstop"]) > esercizio) { 
            var tEntryDetail1 = ottieniDettagliAssestamentoCommessaCompletata(curr["idupb"]);
            if (tEntryDetail1 == null) {
                show(this, "Errore nel calcolo scritture pluriennali aperti di tipo Commessa Completata", "Errore");
            }
            else {
                string noRows = "Progetto pluriennale ancora APERTO: nessun importo da rettificare.";
                if (tEntryDetail1.Rows.Count == 0) {
                    show(this, noRows,
                        "Avvertimento");
                }
                else {
                    labelNoCommessaCompletata.Text = "Elaborazione progetto pluriennale ancora APERTO";
                    if (!DoAssestamentoCommessaCompletata(tEntryDetail1, noRows, false)) {
                        //La seguene show si potrebbe anche omettere perchè nella DoAssestamentoCommessaCompletata i "return false"
                        // sono corredati di messaggio che giustifica il false
                        show(this, "ERRORE nel processo di rettifica per il progetti pluriennali ancora APERTO", "Errore");
                    }
                    labelNoCommessaCompletata.Text = "";
                }
            }
            }
            //2) CASO Upb in chiusura
            // year(U.stop) = " + esercizio + // UPB in scadenza quest'anno
            if (CfgFn.GetNoNullInt32(curr["yearstop"]) == esercizio) {
                var tEntryDetail2 = ottieniRateiApertiProgettiInChiusura(curr["idupb"]);
                if (tEntryDetail2 == null) {
                    show(this, "ERRORE nel calcolo scritture pluriennali ratei aperti progetto in CHIUSURA", "Errore");
                }
                else {
                    string noRows = "Progetto pluriennale in CHIUSURA: nessun importo da rettificare.";
                    if (tEntryDetail2.Rows.Count == 0) {
                        show(this, noRows, "Avvertimento");
                    }
                    else {
                        labelNoCommessaCompletata.Text = "Elaborazione progetti pluriennali in chiusura";
                        if (!DoAssestamentoCommessaCompletata(tEntryDetail2, noRows, true)) {
                            //La seguente show si potrebbe anche omettere perchè nella DoAssestamentoCommessaCompletata i "return false"
                            // sono corredati di messaggio che giustifica il false
                            show(this,
                                "ERRORE nel processo di rettifica per il progetto pluriennale in CHIUSURA", "Errore");
                        }
                        labelNoCommessaCompletata.Text = "";

                    }
                }
            }
            // se in configurazione annuale ho deciso di riscontare gli ammortamenti futuri
            // per i progetti in chiusura senza ratei aperti
            // leggo i relativi dettagli scritture per ottenere i dati su costi e ricavi 
            if (risconta_ammortamenti_futuri) {
                var tEntryDetail3 = ottieniProgettiInChiusuraNoRateiAperti(curr["idupb"]);
                if (tEntryDetail3 == null) {
                    show(this, "Errore nel calcolo scritture pluriennali per progetto in SCADENZA", "Errore");
                }
                else {
                    string noRows = "Progetto pluriennali in CHIUSURA - Risconti su Ammortamenti futuri: nessun importo da rettificare";
                    DataRow rAmmortamentiFuturi = ottieniAmmmortamentiFuturiUPB(curr["idupb"]);
                    if ((tEntryDetail3.Rows.Count == 0) || (rAmmortamentiFuturi != null)) {
                        show(this, noRows, "Avvertimento");
                    }
                    else {
                        labelNoCommessaCompletata.Text = "Elaborazione progetto pluriennale in CHIUSURA: Risconti su Ammortamenti futuri";

                        if (!DoAssestamentoCommessaCompletata(tEntryDetail3, noRows, true)) {
                            show(this,
                                "Errore nel processo di rettifica per il progetto pluriennale in CHIUSURA", "Errore");
                        }
                        labelNoCommessaCompletata.Text = "";

                    }
                }
            }
            // NB: Per il momento commento l'Else perchè solo il PO esegue l'elaborazione ottieniAmmmortamentiFuturiUPB() per cui gli altri utenti,
            // non avendolo configurato vedranno sempre questo messaggio, che potrebbe risulare noiso ed equivoco.

            //else {
            //    string noRows = "Progetti pluriennali in chiusura - Risconti su Ammortamenti futuri: si è scelto di non rettificare " +
            //                    "(vedere Configurazione annuale EP di Ratei e Risconti)";
            //    show(this, noRows, "Avvertimento");
            //}
            //btnRicalcola.Enabled = false;
            return; //return t.Rows[0];
        }

     
        private bool DoAssestamentoCommessaCompletata(DataTable tEntryDetailSource, string messageNoRows, bool chiusura) {
            risconta_ammortamenti_futuri = false;
            if (DS.upbcommessa.Rows.Count == 0) return false;
      
            int currYear = (int)Meta.GetSys("esercizio");
            //object risconta_ammortamenti_futuriObj = Conn.DO_READ_VALUE("config", QHS.CmpEq("ayear", currYear), "risconta_ammortamenti_futuri");
            //task 15894, momentaneamente disattivo la gestione degli ammortamenti futuri 
            chkRiscontaAmmortamentiFuturi.Checked = false; //per ora lo rendo non checkato per tutti
            chkRiscontaAmmortamentiFuturi.Visible = false; //per ora lo rendo invisibile per tutti
  
            MetaData.SetDefault(DS.Tables["upbcommessa"], "ayear", currYear);

          
            string campoRicavo = "idacc_revenue";
            string campoCosto = "idacc_cost";
            string campoRateoAttivo = "idacc_accruals";
            string campoRiscontoPassivo = "idacc_deferredcost";

            string causaleRicavo = "idaccmotive_revenue";
            string causaleCosto = "idaccmotive_cost";
            string causaleRateoAttivo = "idaccmotive_accruals";
            string causaleRiscontoPassivo = "idaccmotive_deferredcost";
 
            //progBar.Maximum = tEntryDetailSource.Rows.Count;
            //progBar.Value = 0;
            // IN REALTA' tEntryDetailSource CONTIENE SOLO UNA RIGA, PER CUI POTREMMO ANCHE LAVORARE DIRETTAMENTE COL Rows[0]  *[TODO]*
            foreach (DataRow Curr in tEntryDetailSource.Rows) {
                //progBar.Increment(1);
                //progBar.Update();
                Application.DoEvents();
                string idupb = Curr["idupb"].ToString();
                // in modalità modifica non 
                DataRow rCommessa = DS.upbcommessa.Rows[0];
                rCommessa["idacc_revenue"] = Curr["idacc_revenue"];
                rCommessa["idacc_cost"] = Curr["idacc_cost"];
                rCommessa["idacc_accruals"] = Curr["idacc_accruals"];
                rCommessa["idacc_deferredcost"] = Curr["idacc_deferredcost"];
                rCommessa["idaccmotive_revenue"] = Curr["idaccmotive_revenue"];
                rCommessa["idaccmotive_cost"] = Curr["idaccmotive_cost"];
                rCommessa["idaccmotive_accruals"] = Curr["idaccmotive_accruals"];
                rCommessa["idaccmotive_deferredcost"] = Curr["idaccmotive_deferredcost"];
                rCommessa["accruals"] =  CfgFn.GetNoNullDecimal(Curr["accruals"]);

                rCommessa["yearstart"] = Curr["yearstart"];
                rCommessa["yearstop"] = Curr["yearstop"];
                rCommessa["idepupbkind"] = Curr["idepupbkind"];
                rCommessa["title"] = Curr["title"];
                rCommessa["codeupb"] = Curr["codeupb"];

                if (!chiusura) {
                    rCommessa["revenue"] = Curr["revenue"];
                    rCommessa["cost"] = Curr["cost"];
                    rCommessa["reserve"] = Curr["reserve"];
                }
                if (rCommessa.Table.Columns.Contains("assetamortization")) {
                    rCommessa["assetamortization"] = 0;
                }
        
                // Dettaglio COSTO - RICAVO (Non ho il problema di controllare l'esistenza di una riga pregressa
             
                bool annoFine = (CfgFn.GetNoNullInt32(Curr["yearstop"]) == currYear);

                //DataRow rDetail = null;

                if (annoFine) {
                    #region anno fine


                    decimal rateo = CfgFn.GetNoNullDecimal(Curr["accruals"]);
                    decimal importo_risconto = 0;
                    if ((rateo == 0) && (risconta_ammortamenti_futuri)) {
                        // Se siamo nelle condizioni (Ricavi > Costi) e siamo in presenza di ammortamenti futuri cespiti
                        if (DoGeneraRiscontiUPBsuAmmmortamentiFuturi(Curr,out importo_risconto)) {
                            if (rCommessa.Table.Columns.Contains("assetamortization")) {
                                rCommessa["assetamortization"] = importo_risconto;
                            }
                            rCommessa["revenue"] = Curr["revenue"];
                            rCommessa["cost"] = Curr["cost"];
                        }
                    }

                    if ((rateo != 0)) {
                        // gestisce il rateo aperto rateo >0)
                        if (Curr[campoCosto] == DBNull.Value) {
                            string codeupb = "(non trovato)";
                            object c = Conn.DO_READ_VALUE("upb", QHS.CmpEq("idupb", Curr["idupb"]), "codeupb");
                            if (c != null) codeupb = c.ToString();
                            show(this, "Campo Costo non trovato per upb " + codeupb, "Errore");
                            return false;
                        }

                        if (Curr[campoRateoAttivo] == DBNull.Value) {
                            string codeupb = "(non trovato)";
                            object c = Conn.DO_READ_VALUE("upb", QHS.CmpEq("idupb", Curr["idupb"]), "codeupb");
                            if (c != null) codeupb = c.ToString();
                            show(this, "Campo Rateo Attivo non trovato per upb " + codeupb, "Errore");
                            return false;
                        }


                        //genera scrittura COSTO A RATEO ATTIVO  
                        // Questo perchè tutti i ratei attivi di un progetto chiuso devono essere portati a costo nell'anno di chiusura
               
                        #endregion
                    }
                }
                else {

                    #region altri anni

                    decimal costi = CfgFn.GetNoNullDecimal(Curr["cost"]);
                    decimal ricavi = CfgFn.GetNoNullDecimal(Curr["revenue"]);
                    decimal riserve = CfgFn.GetNoNullDecimal(Curr["reserve"]);
                    //deve considerare anche le riserve
                    //poi confrontare costi con ricavi+riserve 
                    // la scrittura eventuale deve essere fatta sulla parte (ricavi+riserve)- costi ove positivo

                    // Se costi sono compresi tra ricavi e ricavi+ riserve : non faccio nulla
                    if (costi >= ricavi && costi <= ricavi + riserve) continue;

                    if (costi > ricavi + riserve) {
                        //costi > ricavi+riserve
                        //      e in questo caso utilizzo il conto di default per i ricavi del tipo upb (come da task..)
                        // task 7515 Se costi superano ricavi +riserve, devono essere  create delle scritture:
                        //      RATEO ATTIVO a RICAVO
                        //  per la parte di costo che supera ricavi +riserve
                        //  Il conto di ricavo sarà un conto predefinito per quel progetto, 
                        //                  idem il rateo ma il rateo attivo ove assente prendere il rateo di config
                        decimal importoRateo = costi - (ricavi + riserve);
 

                        var idacc = Curr[campoRateoAttivo]; // r["idacc"];
                        var amount = importoRateo;// CfgFn.GetNoNullDecimal(r["amount"]);
                        var idreg = DBNull.Value; // r["idreg"];

                        if (Curr[campoRicavo] == DBNull.Value) {
                            string codeupb = "(non trovato)";
                            object c = Conn.DO_READ_VALUE("upb", QHS.CmpEq("idupb", Curr["idupb"]), "codeupb");
                            if (c != null) codeupb = c.ToString();
                            show(this, "Campo Ricavo non trovato per upb " + codeupb, "Errore");
                            return false;
                        }

                        if (Curr[campoRateoAttivo] == DBNull.Value) {
                            string codeupb = "(non trovato)";
                            object c = Conn.DO_READ_VALUE("upb", QHS.CmpEq("idupb", Curr["idupb"]), "codeupb");
                            if (c != null) codeupb = c.ToString();
                            show(this, "Campo Rateo Attivo non trovato per upb " + codeupb, "Errore");
                            return false;
                        }

                        //genera scrittura RATEO ATTIVO A RICAVI
                    
                        
                    }
                    else {
                        //se i costi sono inferiori ai ricavi
                        decimal importo_risconto = ricavi - costi;
                        //genera scrittura RICAVI A RISCONTI PASSIVI
                        // in questo caso vanno utilizzati i conti di ricavo, in proporzione
                        //  invece come conto di risconto passivo, quello dell'upb
                        // task 7515 Se i ricavi superano i costi, devono essere create delle scritture 
                        //  RICAVO a RISCONTO PASSIVO
                        //  Il conto di RISCONTO PASSIVO va preso dal tipo UPB o, ove non configurato, da CONFIG
                        //  ripartiti proporzionalmente in base ai ricavi dell'anno
                        //  Ossia detto RIS = somma ricavi dell'anno - somma costi dell'anno, ed Rt la somma dei ricavi dell'anno,
                        //    i vari importi da riscontare ripartiti per ricavo saranno pari a RIS *(ricavo / Rt)

 
                        DataTable tRicavi = ottieniRicaviUPB(Curr["idupb"], false, false); //amount / idacc / idreg
                        ripartisciSommaInBaseARicavi(importo_risconto, tRicavi);
                        foreach (DataRow r in tRicavi.Select()) {

                            var idacc = r["idacc"]; //Curr[campoRicavo]; 
                            var idaccmotive = r["idaccmotive"];//Curr[causaleRicavo]; 
                            var amount = CfgFn.GetNoNullDecimal(r["amount"]);//importo_risconto; 
                            var idreg = r["idreg"]; //DBNull.Value; 
                            if (amount == 0) continue;

                            if (idacc == DBNull.Value) {
                                string codeupb = "(non trovato)";
                                object c = Conn.DO_READ_VALUE("upb", QHS.CmpEq("idupb", Curr["idupb"]), "codeupb");
                                if (c != null) codeupb = c.ToString();
                                show(this, "Campo Ricavo non trovato per upb " + codeupb, "Errore");
                                return false;
                            }

                            if (Curr[campoRiscontoPassivo] == DBNull.Value) {
                                string codeupb = "(non trovato)";
                                object c = Conn.DO_READ_VALUE("upb", QHS.CmpEq("idupb", Curr["idupb"]), "codeupb");
                                if (c != null) codeupb = c.ToString();
                                show(this, "Campo Risconto Passivo non trovato per upb " + codeupb, "Errore");
                                return false;
                            }
                          
                        }
                    }

                    #endregion

                }
                // cancello la riga di UPB commessa in mancanza di dati affinchè non sia salvata su DB
                // non cancello... deve farlo l'utente in modo esplicito cliccando elimina
                if ((CfgFn.GetNoNullDecimal(rCommessa["accruals"]) == 0) &&
                    (CfgFn.GetNoNullDecimal(rCommessa["cost"]) == 0) &&
                    (CfgFn.GetNoNullDecimal(rCommessa["revenue"]) == 0) &&
                    (CfgFn.GetNoNullDecimal(rCommessa["reserve"]) == 0) &&
                    (CfgFn.GetNoNullDecimal(rCommessa["assetamortization"]) == 0)) {
                    //hCommessa.Remove(idupb.ToString());
                    //rCommessa.Delete();       QUESTA CANCELLAZIONE DOVREBBE FARLA L'UTENTE *[TODO]*
                }
            }


            DataRow Rcommessa = DS.upbcommessa.Rows[0];
           
            PostData pd = Meta.Get_PostData();
            pd.InitClass(DS, Meta.Conn);
            if (pd.DO_POST()) {
				show(this, "Ricalcolo completato.");
			}
			else {
				show(this, "Errore nel salvataggio dei dati di assestamento!", "Errore");
			}


			return true;
        }

        void ripartisciSommaInBaseARicavi(decimal somma, DataTable ricavi) {
            decimal sommaRicavi = MetaData.SumColumn(ricavi, "amount");
            decimal sommaDaRipartire = somma;
            foreach (DataRow r in ricavi.Rows) {
                //string idacc = r["idacc"].ToString();
                decimal amount = CfgFn.GetNoNullDecimal(r["amount"]);
                if (amount == 0) {
                    r["amount"] = 0;
                    continue;
                }
                if (sommaRicavi == 0) {
                    r["amount"] = 0;
                    continue;
                }
                decimal quota = CfgFn.RoundValuta(sommaDaRipartire * (amount / sommaRicavi));
                r["amount"] = quota;
                sommaRicavi -= amount;
                sommaDaRipartire -= quota;
            }
        }

        DataTable ottieniRicaviUPB(object idupb, bool totali, bool leggiIdEpAcc) {
            int currAyear = (int)Meta.GetSys("esercizio");
            string strYear = QHS.quote(currAyear);
            string filter = totali ? QHS.CmpLe("ED.yentry", currAyear) : QHS.CmpEq("ED.yentry", currAyear);
            string strIdepacc = leggiIdEpAcc ? ",ED.idepacc" : "";
            string query = "select  sum(ed.amount) as amount, ed.idacc, ed.idreg,ed.idaccmotive, " +
                    " ed.idsor1,ed.idsor2,ed.idsor3 " + strIdepacc  +
                    " from entrydetail ED " +
                    " join account A on ED.idacc=A.idacc " +
                    " WHERE " +
                    " (A.flagaccountusage & 128 <> 0) " +  //ricavo
                    " AND (A.flagaccountusage & 524288 = 0) " +  // Escludi da calcolo Commessa completata . Task 15404
                    " AND " + filter +  //scritture di quest'anno o tutte le prec. a seconda del par. di input
                    " AND ED.idupb= " + QHS.quote(idupb) +
                    " group by  ed.idreg, ed.idacc,ed.idaccmotive,ed.idsor1,ed.idsor2,ed.idsor3" + strIdepacc;//ed.idepacc,
            DataTable t = Conn.SQLRunner(query, false, 600);
            return t;
        }
        private bool DoGeneraRiscontiUPBsuAmmmortamentiFuturi(DataRow Curr,   out decimal riscontocalcolato) {
            riscontocalcolato = 0;
            string idupb = Curr["idupb"].ToString();
            string codeupb = Curr["codeupb"].ToString();
            if ((tAmmortamentiFuturi == null) || (tAmmortamentiFuturi.Rows.Count == 0)) return false;

            // Questo metodo vale solo per UPB in chiusura (in corso d'anno) a commessa completata ed effettua un calcolo opzionale.
            // Se vi sono ammortamenti futuri genera risconti sulla base degli ammortamenti futuri
            // Questo vale SOLO per le UPB i cui RICAVI sono superiori ai COSTI. 
            // Questo calcolo è opzionale, diversamente gli UPB in questione 
            // genereranno utile o perdita, se non hanno ratei aperti.

            int currYear = (int)Meta.GetSys("esercizio");


            decimal costi = CfgFn.GetNoNullDecimal(Curr["cost"]);
            decimal ricavi = CfgFn.GetNoNullDecimal(Curr["revenue"]);

            // Dettaglio COSTO - RICAVO (Non ho il problema di controllare l'esistenza di una riga pregressa
 
            bool annoFine = (CfgFn.GetNoNullInt32(Curr["yearstop"]) == currYear);

 
            //se i costi sono inferiori ai ricavi

            if ((ricavi - costi) <= 0) return false;
            DataRow RAmmortamentiFuturi = tAmmortamentiFuturi.Rows[0]; 
            decimal importo_ammortamenti = CfgFn.GetNoNullDecimal(RAmmortamentiFuturi["amm_futuricespiti"]); // importo positivo
            if (importo_ammortamenti == 0) return false;
            decimal importo_risconto = 0;

            if ((ricavi - costi) <= importo_ammortamenti) importo_risconto = ricavi;
            else importo_risconto = importo_ammortamenti;

            if (importo_risconto == 0) return false;

            //genera ulteriori dettagli scrittura  RICAVI A RISCONTI PASSIVI
            //in questo caso vanno utilizzati i conti di ricavo, in proporzione
            //invece come conto di risconto passivo, quello dell'upb

            string campoRiscontoPassivo = "idacc_deferredcost";

            string causaleRiscontoPassivo = "idaccmotive_deferredcost";

            DataTable tRicavi = ottieniRicaviUPB(Curr["idupb"], false, false); //amount / idacc / idreg
            ripartisciSommaInBaseARicavi(importo_risconto, tRicavi);
            foreach (DataRow r in tRicavi.Select()) {

                var idacc = r["idacc"]; //Curr[campoRicavo]; 
                var idaccmotive = r["idaccmotive"];//Curr[causaleRicavo]; 
                var amount = CfgFn.GetNoNullDecimal(r["amount"]);//importo_risconto; 
                var idreg = r["idreg"]; //DBNull.Value; 
                if (amount == 0) continue;

                if (idacc == DBNull.Value) {
                    show(this, "Campo Ricavo non trovato per upb " + codeupb, "Errore");
                    return false;
                }

                if (Curr[campoRiscontoPassivo] == DBNull.Value) {
                    show(this, "Campo Risconto Passivo non trovato per upb " + codeupb, "Errore");
                    return false;
                }
 
            }
            riscontocalcolato = importo_risconto;
            return true;

        }
        private void btnRicalcola_Click(object sender, EventArgs e) {
             // Ricalcola i dati ai fini del calcolo della commessa completata
            DataRow rAmmFuturi ;
            RicalcolaDatiCorrenti(out rAmmFuturi);
        
            var r = DS.upbcommessa[0];
            

                if (rAmmFuturi != null) // la stima degli ammortamenti futuri cespiti è calcolata a parte
                {
                    r["assetamortization"] = CfgFn.GetNoNullDecimal(rAmmFuturi["amm_futuricespiti"]);
                }
            //}
            Meta.FreshForm();            
        }
 
        public void MetaData_AfterClear() {
            txtEsercizio.Text = esercizio.ToString();
            txtAnnoInizio.ReadOnly = false;
            txtAnnoFine.ReadOnly = false;
            
            cmbEPUPBKind.Enabled = true;
            btnRicalcola.Visible = false;
            EPM.mostraEtichette();
          
            labelNoCommessaCompletata.Text = "";
             
            btnRicalcola.Enabled = false;

        }
 

        public void MetaData_AfterFill() {
  
            txtAnnoInizio.ReadOnly = true;
            txtAnnoFine.ReadOnly = true;
     
            if (EPM.esistonoScrittureCollegate()) Meta.CanCancel = false;
            EPM.mostraEtichette();
            btnRicalcola.Visible = true;
            btnRicalcola.Enabled = true;
            cmbEPUPBKind.Enabled = false;
      
        }
        public void MetaData_AfterRowSelect(DataTable T, DataRow R) {
            //if (Meta.IsEmpty) return;
            if (T.TableName == "upb") {
                if ((Meta.DrawStateIsDone) && (R!=null)) {
                    txtAnnoInizio.Text = (R["start"] == DBNull.Value) ? "" : ((DateTime)R["start"]).Year.ToString();
                    txtAnnoFine.Text = (R["stop"] == DBNull.Value) ? "" : ((DateTime)R["stop"]).Year.ToString();
                }
            }
        }
        public void MetaData_BeforePost() {
             EPM.beforePost();
        }

        public void MetaData_AfterPost() {
            labelNoCommessaCompletata.Text = "Elaborazione scritture Assestamento pluriennale a Commessa Completata";
            EPM.afterPost();
            labelNoCommessaCompletata.Text = "";
        }

        DataTable tAmmortamentiFuturi = new DataTable();

        private DataRow ottieniAmmmortamentiFuturiUPB( object idupb  ) {
            

            DataSet Out = Meta.Conn.CallSP("calcola_ammortamenti_futuri_cespiti",
                new Object[3] {Meta.GetSys("esercizio"),
                                Meta.GetSys("datacontabile"),
                                idupb 
							  }, false, 600
                );

            if (Out == null) return null;
            if (Out.Tables.Count == 0) {
                return null;
            }
            tAmmortamentiFuturi = Out.Tables[0];
            if (tAmmortamentiFuturi.Rows.Count == 0) {
                return null;
            }
            return tAmmortamentiFuturi?.Rows[0];
            // Lancio sp calcolo ammortamenti futuri
        }


        private DataRow ottieniTotaleGenerale(object idupb) {
            int currAyear = (int)Meta.GetSys("esercizio");
            string query =
                "select " +
                "sum(case when A.flagaccountusage & 8 <> 0 then ED.amount else 0 end) as risconti, " +
                "-sum(case when A.flagaccountusage & (64+131072) <> 0 then ED.amount else 0 end) as cost, " +
                "sum(case when A.flagaccountusage & 128 <> 0 then ED.amount else 0 end) as revenue, " +
                "-sum(case when A.idacc = EU.idacc_accruals then ED.amount else 0 end) as accruals, " +
                " ed.idsor1,ed.idsor2,ed.idsor3  " +
                " from entrydetail ed (nolock) " +
                " join entry e (nolock) on e.yentry=ed.yentry and e.nentry=ed.nentry " +
                " join upb u (nolock) on ed.idupb = u.idupb " +
                " join epupbkindyear EU (nolock)  on EU.idepupbkind = U.idepupbkind " +
                " join account A (nolock) on A.idacc = ed.idacc " +
                " where " +
                QHS.AppAnd(QHS.NullOrLe("year(U.start)", currAyear),
                    QHS.CmpGe("year(U.stop)", currAyear), QHS.CmpEq("EU.ayear", currAyear),
                    QHS.CmpEq("EU.adjustmentkind", "C"), QHS.CmpEq("ED.yentry", currAyear),
                    QHS.CmpEq("e.identrykind", 8),
                    QHS.CmpEq("U.idupb", idupb)
                ) +
                " AND A.flagaccountusage & 524288 = 0 ";  // Escludi da calcolo Commessa completata . Task 15404;

            DataTable result = Meta.Conn.SQLRunner(query, false, 600);
            return result?.Rows[0];
        }

        private DataTable ottieniDettagliAssestamentoCommessaCompletata(object idupb) {
            int currAyear = (int)Meta.GetSys("esercizio");

            string query =
                "select U.idupb,  " +
                "-sum(case when A.flagaccountusage & (64+131072) <> 0 then ED.amount else 0 end) as cost," +
                "sum(case when A.flagaccountusage & 128 <> 0 then ED.amount else 0 end) as revenue," +
                "sum(case when A.flagaccountusage & 2048 <> 0 then ED.amount else 0 end) as reserve," +
                "-sum(case when A.idacc = EU.idacc_accruals then ED.amount else 0 end) as accruals," +
                "EU.idacc_cost, EU.idacc_revenue, 	EU.idacc_deferredcost,EU.idacc_accruals," +
                "EU.idaccmotive_cost, EU.idaccmotive_revenue, 	EU.idaccmotive_deferredcost,EU.idaccmotive_accruals," +
                "year(U.stop) as yearstop, year(U.start) as yearstart,   EU.adjustmentkind,U.idepupbkind,U.codeupb,U.title  " +

                "from entrydetail ed (nolock) " +
                " join entry e (nolock) on e.yentry=ed.yentry and e.nentry=ed.nentry " +
                " join UPB UPB_associati (nolock)  on ed.idupb = UPB_associati.idupb " +
                " join UPB U (nolock)  on U.idupb=ISNULL(UPB_associati.idupb_capofila,UPB_associati.idupb) " +
                "join epupbkindyear EU (nolock)  on EU.idepupbkind = U.idepupbkind " +
                "join account A (nolock) on A.idacc = ed.idacc " +
                " where " +
                QHS.AppAnd(QHS.NullOrLe("year(U.start)", currAyear),
                            QHS.CmpGt("year(U.stop)", currAyear), QHS.CmpEq("EU.ayear", currAyear),
                    QHS.CmpEq("EU.adjustmentkind", "C"), QHS.CmpEq("ED.yentry", currAyear),
                    QHS.FieldNotIn("e.identrykind", new Object[] { 8, 11, 12 }),
                    QHS.CmpEq("U.idupb", idupb)
                    ) +
                " AND A.flagaccountusage & 524288 = 0 " +  // Escludi da calcolo Commessa completata . Task 15404"
                " group by U.idupb,EU.idacc_cost, EU.idacc_revenue, 	EU.idacc_deferredcost,EU.idacc_accruals, " +
                " EU.idaccmotive_cost, EU.idaccmotive_revenue, 	EU.idaccmotive_deferredcost,EU.idaccmotive_accruals," +
                " EU.adjustmentkind,year(U.stop),year(U.start),U.idepupbkind,U.codeupb,U.title   ";


            DataTable tPluri = DataAccess.SQLRunner(Meta.Conn, query, false, 600);
            return tPluri;
        }


          //La scrittura sui ratei va fatta comunque prima di capire se i costi hanno superato  i ricavi, ossia bisogna portare i ratei attivi a costo
        // Infatti questa scrittura è fatta nell'anno della chiusura, mentre l'utile/perdita sarà valutato l'anno successivo
        DataTable ottieniRateiApertiProgettiInChiusura(object idupb) {
            int currAyear = (int)Meta.GetSys("esercizio");
            string strYear = QHS.quote(currAyear);

            string query = "select  -sum(ed.amount) as accruals ,year(U.stop) as yearstop, year(U.start) as yearstart,U.idupb, ed.idacc as idacc_accruals,  " +
                                "EU.idacc_deferredcost, 	EU.idaccmotive_deferredcost, EU.idacc_revenue,EU.idaccmotive_revenue,U.idepupbkind,U.title,U.codeupb ," +
                                "EU.idacc_cost,EU.idaccmotive_cost,EU.idacc_accruals, EU.idaccmotive_accruals  " +//ed.idepexp, commentato con task 11624
                                " from entrydetail ed " +
                                " join entry e (nolock) on e.yentry=ed.yentry and e.nentry=ed.nentry " +
                                " join account A on ED.idacc=A.idacc " +
                                " join UPB UPB_associati on ED.idupb = UPB_associati.idupb " +
                                " join UPB U on U.idupb=ISNULL(UPB_associati.idupb_capofila,UPB_associati.idupb) " +
                                " join epupbkindyear EU on EU.idepupbkind = U.idepupbkind " +
                                " WHERE " +
                                " ED.yentry= " + strYear +  //scritture di quest'anno
                                " AND E.identrykind not in (8,11,12) " +
                                " AND ED.idacc=EU.idacc_accruals " +
                                " and EU.ayear =" + strYear +    // prende la configurazione tipo UPB di quest'anno
                                " AND " + QHS.CmpEq("U.idupb", idupb) +
                                " AND year(U.stop) = " + strYear + // UPB in scadenza quest'anno
                                " AND A.flagaccountusage & 524288 = 0 " +  // Escludi da calcolo Commessa completata . Task 15404
                                " group by U.idupb, ed.idacc, EU.idacc_cost,EU.idaccmotive_cost," +
                                " EU.idacc_deferredcost, EU.idaccmotive_deferredcost, EU.idacc_revenue,EU.idaccmotive_revenue," +
                                " EU.idacc_accruals, EU.idacc_deferredcost,EU.idaccmotive_accruals,year(U.stop),year(U.start),U.idepupbkind,U.title,U.codeupb " +
                                " having " +
                                " -sum(ed.amount) <> 0 ";

            DataTable t = Conn.SQLRunner(query, false,600);
            return t;
        }

 
        DataTable ottieniProgettiInChiusuraNoRateiAperti(object idupb) {
            int currAyear = (int)Meta.GetSys("esercizio");
            string strYear = QHS.quote(currAyear);

            string query = "select  -sum(case when A.flagaccountusage & (64+131072) <> 0 then ED.amount else 0 end) as cost," +
                           "sum(case when A.flagaccountusage & 128 <> 0 then ED.amount else 0 end) as revenue," +
                           "sum(case when A.flagaccountusage & 2048 <> 0 then ED.amount else 0 end) as reserve,"  +
                           "-sum(case when A.idacc = EU.idacc_accruals then ED.amount else 0 end) as accruals ," +
                           "year(U.stop) as yearstop, year(U.start) as yearstart,U.idupb, ed.idacc as idacc_accruals,  " +
                           "EU.idacc_deferredcost, 	EU.idaccmotive_deferredcost, EU.idacc_revenue,EU.idaccmotive_revenue,U.idepupbkind,U.title,U.codeupb ," +
                           "EU.idacc_cost,EU.idaccmotive_cost,EU.idacc_accruals, EU.idaccmotive_accruals  " +//ed.idepexp, commentato con task 11624
                           " from entrydetail ed " +
                           " join entry e (nolock) on e.yentry=ed.yentry and e.nentry=ed.nentry " +
                           " join UPB UPB_associati (nolock)  on ED.idupb = UPB_associati.idupb " +
                           " join UPB U (nolock)  on U.idupb=ISNULL(UPB_associati.idupb_capofila,UPB_associati.idupb) " +
                           " join account A on ED.idacc=A.idacc " +
                           " join epupbkindyear EU on EU.idepupbkind = U.idepupbkind " +
                           " WHERE " +
                           " ed.yentry= " + strYear +  //scritture di quest'anno
                           " AND E.identrykind not in (8,11,12) "+
                           " and EU.ayear =" + strYear+    // prende la configurazione tipo UPB di quest'anno
                           " AND "+QHS.CmpEq("U.idupb",idupb) +
                           " AND year(U.stop) = " + strYear + // UPB in scadenza quest'anno
                           " AND A.flagaccountusage & 524288 = 0 " +  // Escludi da calcolo Commessa completata . Task 15404
                           " group by U.idupb, ed.idacc, EU.idacc_cost,EU.idaccmotive_cost," +
                           " EU.idacc_deferredcost, EU.idaccmotive_deferredcost, EU.idacc_revenue,EU.idaccmotive_revenue," +
                           " EU.idacc_accruals, EU.idacc_deferredcost,EU.idaccmotive_accruals,year(U.stop),year(U.start),U.idepupbkind,U.title,U.codeupb  " +
                           " having " +  // COSTI < RICAVI
                           "  -sum(case when A.flagaccountusage & (64+131072) <> 0 then ED.amount else 0 end)  <" +
                           "   sum(case when A.flagaccountusage & 128 <> 0 then ED.amount else 0 end) AND " + // NON HANNO RATEI APERTI
                           "  -sum(case when A.idacc = EU.idacc_accruals then ED.amount else 0 end) =  0";  
            DataTable t = Conn.SQLRunner(query, false,600);
            return t;
        }

    }
}
