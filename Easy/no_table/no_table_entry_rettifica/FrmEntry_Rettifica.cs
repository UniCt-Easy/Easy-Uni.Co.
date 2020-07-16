/*
    Easy
    Copyright (C) 2020 UniversitÃ  degli Studi di Catania (www.unict.it)
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
using ep_functions;
using funzioni_configurazione;

namespace no_table_entry_rettifica {
    public partial class Frmno_table_entry_rettifica : Form {
        MetaData Meta;
        DataTable tPlAccount;
        DataTable tAccount;
        CQueryHelper QHC;
        QueryHelper QHS;
        DataAccess Conn;

        public Frmno_table_entry_rettifica() {
            InitializeComponent();
        }

        private int identrykindToGenerate = 0;
        MetaData m;
        private EP_Manager ep;
       

        public void MetaData_AfterLink() {
            Meta = MetaData.GetMetaData(this);
            Conn = Meta.Conn;
            QHC = new CQueryHelper();
            QHS = Conn.GetQueryHelper();
            tPlAccount = DataAccess.CreateTableByName(Conn, "placcount", "idplaccount, placcpart");
            tAccount = DataAccess.CreateTableByName(Conn, "account", "idacc, idplaccount");
            if (Meta.edit_type == "rettifica_pluriennale") {
                labelDescrizione.Text = "PROCEDURA ASSESTAMENTO PROGETTI PLURIENNALI a Commessa Completata";
                btnOperazione.Text = "Inizia assestamento";
                chkCommerciale.Visible = false;
                identrykindToGenerate = 8;
            }
            if (Meta.edit_type == "rettifica_pluriennale_percentuale") {
                labelDescrizione.Text = "PROCEDURA ASSESTAMENTO PROGETTI PLURIENNALI a percentuale di completamento";
                btnOperazione.Text = "Inizia assestamento";
                chkCommerciale.Visible = false;
                identrykindToGenerate = 13;
            }
            if (Meta.edit_type == "rettifica") {
                labelDescrizione.Text =
                    "PROCEDURA CHE RETTIFICA I COSTI/RICAVI CON COMPETENZA OLTRE L'ESERCIZIO CORRENTE";
                btnOperazione.Text = "Inizia Rettifica";
                identrykindToGenerate = 3;
            }
            m = Meta.Dispatcher.Get("upbcommessa");
            ep = new EP_Manager(m, null, null, null, null, null, null, null, null, "upbcommessa");
        }

        public void MetaData_AfterActivation() {
            this.Text = Meta.Name;
        }

        public void MetaData_AfterClear() {
            this.Text = Meta.Name;
        }

        bool AnnoCommerciale = false;

        private void btnRettifica_Click(object sender, EventArgs e) {
            if (Meta.edit_type == "rettifica") {
                // Caricamento delle tabelle entry e entrydetail che devono essere integrate
                int currAyear = (int) Meta.GetSys("esercizio");
                DateTime dec31 = new DateTime(currAyear, 12, 31);

                DataTable tEntryDetail = ottieniDettagliScrittura();
                if (tEntryDetail == null) return;

                AnnoCommerciale = chkCommerciale.Checked;

                if (!doRettifica(tEntryDetail)) {
                    MessageBox.Show(this, "Errore nel processo di rettifica dei risconti", "Errore");
                }
            }
            if (Meta.edit_type == "rettifica_pluriennale") {        
                //      Assestamento Commessa Completata
                DataTable tEntryDetail = ottieniDettagliAssestamentoCommessaCompletata();
                if (tEntryDetail == null) {
                    MessageBox.Show(this, "Errore nel calcolo scritture pluriennali aperti di tipo Commessa Completata","Errore");
                }
                else {
                    string noRows = "Progetti pluriennali ancora aperti: nessun importo da rettificare";
                    if (tEntryDetail.Rows.Count == 0) {
                        MessageBox.Show(this, noRows,
                            "Avvertimento");
                    }
                    else {
                        labelFase.Text = "Elaborazione progetti pluriennali ancora aperti";
                        if (!DoAssestamentoCommessaCompletata(tEntryDetail, noRows,false)) {
                            MessageBox.Show(this, "Errore nel processo di rettifica per i progetti pluriennali ancora aperti", "Errore");
                        }
                    }
                }
                tEntryDetail = ottieniRateiApertiProgettiInChiusura();
                if (tEntryDetail == null) {
                    MessageBox.Show(this, "Errore nel calcolo scritture pluriennali aperti", "Errore");
                }
                else {
                    string noRows = "Progetti pluriennali in chiusura: nessun importo da rettificare";
                    if (tEntryDetail.Rows.Count == 0) {
                        MessageBox.Show(this, noRows, "Avvertimento");
                    }
                    else {
                        labelFase.Text = "Elaborazione progetti pluriennali in chiusura";
                        if (!DoAssestamentoCommessaCompletata(tEntryDetail, noRows,true)) {
                            MessageBox.Show(this,
                                "Errore nel processo di rettifica per i progetti pluriennali in chiusura", "Errore");
                        }
                    }
                }


                btnOperazione.Enabled = false;
            }
            if (Meta.edit_type == "rettifica_pluriennale_percentuale") {       //a percentuale di completamento
                DataTable tEntryDetail = ottieniDettagliScritturaProgettiPluriennaliPercentuale();
                string noRows = "Progetti pluriennali ancora aperti: nessun importo da rettificare";
                if (tEntryDetail == null) {
                    MessageBox.Show(this, "Errore nel calcolo scritture pluriennali aperti a percentuale di completamento",
                        "Errore");
                }
                else {
                    if (tEntryDetail.Rows.Count == 0) {
                        MessageBox.Show(this, noRows,"Avvertimento");
                    }
                    else {
                        if (!doRettificaPluriennalePercentuale(tEntryDetail,noRows)) {
                            MessageBox.Show(this,
                                "Errore nel processo di rettifica per i progetti pluriennali ancora aperti", "Errore");
                        }
                    }
                }
            }
        }

        private DataTable ottieniDettagliScrittura() {
            int currAyear = (int)Meta.GetSys("esercizio");
            DateTime dec31 = new DateTime(currAyear, 12, 31);

            string queryED = "SELECT d.amount, d.description,d.idacc, d.idreg, d.idupb, d.idsor1, d.idsor2, d.idsor3,"+
                "A.codeacc, A.title as account, ACCM.codemotive, ACCM.title as accmotive,reg.title as registry, "+
                "U.codeupb, "

            + " d.competencystart, d.competencystop, d.idaccmotive, d.idepexp,d.idepacc,P.placcpart " + // 
            " FROM entrydetail d "
            + "LEFT OUTER JOIN accmotive ACCM on ACCM.idaccmotive = d.idaccmotive "
            + "LEFT OUTER JOIN registry REG on REG.idreg = d.idreg "
            + "LEFT OUTER JOIN UPB U on U.idupb = d.idupb "
            + " JOIN entry e ON " + QHS.AppAnd(QHS.CmpEq("e.yentry", QHS.Field("d.yentry")),
            QHS.CmpEq("e.nentry", QHS.Field("d.nentry")))
            + " JOIN ACCOUNT A ON " + QHS.CmpEq("A.idacc", QHS.Field("d.idacc"))
            + " JOIN PLACCOUNT P ON " + QHS.CmpEq("P.idplaccount", QHS.Field("A.idplaccount"))
            + " WHERE " + QHS.AppAnd(QHS.FieldIn("e.identrykind", new object[] { 1, 5 }),
            QHS.CmpEq("e.yentry", currAyear), QHS.CmpGt("d.competencystop", dec31));
            //+ " GROUP BY d.idepexp, d.idepacc,d.idacc, d.idreg, d.idupb, d.idsor1, d.idsor2, "+
            //    "d.idsor3, d.competencystart, d.competencystop, d.idaccmotive ";

            DataTable tEntryDetail = DataAccess.SQLRunner(Conn, queryED,false,600);
            if (tEntryDetail == null) {
                MessageBox.Show(this, "Errore nell'estrazione dei dati da ENTRYDETAIL", "Errore");
                return null;
            }

            tEntryDetail.TableName = "entrydetail";

            return tEntryDetail;
        }

        private bool doVerify() {
            string filter = QHS.AppAnd(QHS.CmpEq("identrykind", identrykindToGenerate), 
                                QHS.CmpEq("Year(adate)", Meta.GetSys("esercizio")));

            string sqlCmd = " SELECT *" +
                     " FROM entry " +
                     " WHERE  " + filter;

            DataTable T = Conn.SQLRunner(sqlCmd,false,600);
            if ((T != null) && (T.Rows.Count > 0)) {
                if (MessageBox.Show("Le scritture di Rettifica relative all''esercizio corrente risultano già generate. Si desidera proseguire comunque?", "Avviso",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                    return false;
            }
            return true;
        }

        private bool doRettifica(DataTable tEntryDetailSource) {
            if (tEntryDetailSource == null) {
                MessageBox.Show(this, "La tabella dei dettagli scritture non è definita", "Errore");
                return false;
            }

            if (tEntryDetailSource.Rows.Count == 0) {
                MessageBox.Show(this, "Nessun risconto da effettuare", "Avvertimento");
                return true;
            }

            DataTable tEntry = DataAccess.CreateTableByName(Conn, "entry", "*");
            DataTable tEntryDetail = DataAccess.CreateTableByName(Conn, "entrydetail", "*");
            tEntryDetail.Columns.Add("!valoreoriginale", typeof(decimal));

            DataSet ds = new DataSet();
            ds.Tables.Add(tEntry);
            ds.Tables.Add(tEntryDetail);

            tEntry.setOptimized(true);
            RowChange.ClearMaxCache(tEntry);

            tEntryDetail.setOptimized(true);
            RowChange.ClearMaxCache(tEntryDetail);


            ds.Relations.Add("entryentrydetail",
                    new DataColumn[] { tEntry.Columns["yentry"], tEntry.Columns["nentry"] },
                    new DataColumn[] { tEntryDetail.Columns["yentry"], tEntryDetail.Columns["nentry"] }, false);

            int currYear = (int)Meta.GetSys("esercizio");

            MetaData MEntry = MetaData.GetMetaData(this, "entry");
            MEntry.SetDefaults(ds.Tables["entry"]);
            MetaData.SetDefault(ds.Tables["entry"], "yentry", currYear);
            
            DateTime dec31 = new DateTime(currYear, 12, 31);
            string descr = "Rettifica costi/ricavi in risconti";
            if (!doVerify()) return false;
            DataRow rEntry = MEntry.Get_New_Row(null, ds.Tables["entry"]);

            rEntry["identrykind"] = "3";
            rEntry["adate"] = dec31;
            rEntry["description"] = descr;

            DateTime jan01 = new DateTime(1 + currYear, 1, 1);

            string campoRiscontoAttivo = "idacc_deferredrevenue";
            string campoRiscontoPassivo = "idacc_deferredcost";

            object idacc_riscontoA = Conn.DO_READ_VALUE("config", QHS.CmpEq("ayear", currYear), campoRiscontoAttivo);
            if ((idacc_riscontoA == null) || (idacc_riscontoA == DBNull.Value)) {
                MessageBox.Show(this, "Attenzione non è stato specificato il conto del risconto attivo", "Errore");
                return false;
            }

            object idacc_riscontoP = Conn.DO_READ_VALUE("config", QHS.CmpEq("ayear", currYear), campoRiscontoPassivo);
            if ((idacc_riscontoP == null) || (idacc_riscontoP == DBNull.Value)) {
                MessageBox.Show(this, "Attenzione non è stato specificato il conto del risconto passivo", "Errore");
                return false;
            }

            MetaData MEntryDetail = MetaData.GetMetaData(this, "entrydetail");
            MEntryDetail.SetDefaults(ds.Tables["entrydetail"]);

            foreach (DataRow Curr in tEntryDetailSource.Rows) {

                decimal importoDettaglio = CfgFn.GetNoNullDecimal(Curr["amount"]);
                if (importoDettaglio == 0) continue;

                object idAcc = Curr["idacc"];
                string placcpart = Curr["placcpart"].ToString().ToUpper();

                if ((placcpart != "C") && (placcpart != "R")) continue;

                if ((idAcc.Equals(idacc_riscontoA)) || (idAcc.Equals(idacc_riscontoP))) continue;

                if ((Curr["competencystart"] == null) || (Curr["competencystart"] == DBNull.Value)) continue;
                DateTime inizioCompetenza = (DateTime)Curr["competencystart"];
                DateTime fineCompetenza = (DateTime)Curr["competencystop"];

                decimal importoRisconto = calcolaRisconto(AnnoCommerciale, (int)Meta.GetSys("esercizio"),
                                    importoDettaglio, inizioCompetenza, fineCompetenza);
                if (importoRisconto == 0) continue;


                // Dettaglio COSTO - RICAVO (Non ho il problema di controllare l'esistenza di una riga pregressa
                // perché per come è costruita la tabella le righe sono tutte diverse tra di loro
                MetaData.SetDefault(ds.Tables["entrydetail"], "yentry", currYear);
                MetaData.SetDefault(ds.Tables["entrydetail"], "nentry", rEntry["nentry"]);

                DataRow rEntryDetailCR = MEntryDetail.Get_New_Row(rEntry, ds.Tables["entrydetail"]);
                rEntryDetailCR["amount"] = -importoRisconto;
                rEntryDetailCR["idacc"] = Curr["idacc"];
                rEntryDetailCR["idreg"] = Curr["idreg"];
                rEntryDetailCR["idupb"] = Curr["idupb"];
                rEntryDetailCR["idsor1"] = Curr["idsor1"];
                rEntryDetailCR["idsor2"] = Curr["idsor2"];
                rEntryDetailCR["idsor3"] = Curr["idsor3"];
                rEntryDetailCR["idepexp"] = Curr["idepexp"];
                rEntryDetailCR["idepacc"] = Curr["idepacc"];
                rEntryDetailCR["idaccmotive"] = Curr["idaccmotive"];
                rEntryDetailCR["description"] = Curr["description"];
                if (inizioCompetenza.CompareTo(jan01) < 0) {
                    rEntryDetailCR["competencystart"] = jan01;
                }
                else {
                    rEntryDetailCR["competencystart"] = inizioCompetenza;
                }

                rEntryDetailCR["competencystop"] = fineCompetenza;
                rEntryDetailCR["!valoreoriginale"] = Math.Abs(importoDettaglio);


                //EP.EffettuaScrittura(idepcontext, importoRisconto, idAcc, Curr["idreg"], Curr["idupb"],
                //    jan01, Curr["competencystop"], null, Curr["idaccmotive"]);
                object riscontoChoosen = "";
                if (placcpart == "C") {
                    riscontoChoosen = idacc_riscontoA;
                    //EP.EffettuaScrittura(idepcontext, importoRisconto, idacc_riscontoA.ToString(), null, null, null, null);
                }
                else {
                    riscontoChoosen = idacc_riscontoP;
                    //EP.EffettuaScrittura(idepcontext, importoRisconto, idacc_riscontoP.ToString(), null, null, null, null);
                }
                // Dettaglio RISCONTO               
                //string filter = costruisciFiltro(riscontoChoosen, Curr);
                //if (tEntryDetail.Select(filter).Length > 0) {
                //    DataRow rFound = tEntryDetail.Select(filter)[0];
                //    rFound["amount"] = CfgFn.GetNoNullDecimal(rFound["amount"]) + importoRisconto;
                //}
                //else {
                MetaData.SetDefault(ds.Tables["entrydetail"], "yentry", currYear);
                MetaData.SetDefault(ds.Tables["entrydetail"], "nentry", rEntry["nentry"]);

                DataRow rEntryDetailRis = MEntryDetail.Get_New_Row(rEntry, ds.Tables["entrydetail"]);
                rEntryDetailRis["amount"] = importoRisconto;
                rEntryDetailRis["idacc"] = riscontoChoosen;
                rEntryDetailRis["idreg"] = Curr["idreg"];
                rEntryDetailRis["idupb"] = Curr["idupb"];
                rEntryDetailRis["idsor1"] = Curr["idsor1"];
                rEntryDetailRis["idsor2"] = Curr["idsor2"];
                rEntryDetailRis["idsor3"] = Curr["idsor3"];
                rEntryDetailRis["idepexp"] = Curr["idepexp"];
                rEntryDetailRis["idepacc"] = Curr["idepacc"];
                rEntryDetailRis["idaccmotive"] = Curr["idaccmotive"];
                rEntryDetailRis["description"] = Curr["description"];
                if (inizioCompetenza.CompareTo(jan01) < 0) {
                    rEntryDetailRis["competencystart"] = jan01;
                }
                else {
                    rEntryDetailRis["competencystart"] = inizioCompetenza;
                }
                rEntryDetailRis["competencystop"] = fineCompetenza;


                rEntryDetailRis["!valoreoriginale"] = Math.Abs(importoDettaglio);


                //}
            }

            if (ds.Tables["entrydetail"].Rows.Count == 0) {
                MessageBox.Show(this, "Nessun risconto da effettuare", "Avvertimento");
                return true;
            }

            FrmEntryPreSave frm = new FrmEntryPreSave(ds.Tables["entrydetail"], Meta.Conn, AnnoCommerciale,tEntryDetailSource);
            DialogResult dr = frm.ShowDialog();
            if (dr != DialogResult.OK) {
                MessageBox.Show(this, "Operazione Annullata!");
                return true;
            }
            PostData Post = MEntry.Get_PostData();
            Post.InitClass(ds, Meta.Conn);

            if (Post.DO_POST()) {
                DataRow rEntryPosted = ds.Tables["entry"].Rows[0];
                EditRelatedEntryByKey(rEntryPosted);
                MessageBox.Show(this, "Integrazione dei residui completata con successo!");
            }
            else {
                MessageBox.Show(this, "Errore nel salvataggio della scrittura di integrazione!", "Errore");
            }

            return true;
        }

        public static int ngiorniCommerciali(DateTime inizio, DateTime fine) {
            int giorni_primomese = inizio.Day > 30 ? 0 : 31 - inizio.Day;
            if ((fine.Year == inizio.Year) && (fine.Month == inizio.Month)) giorni_primomese =-(inizio.Day- 1 );
            
            int giorni_ultimomese = fine.Day == 31 ? 30 : fine.Day;
            int n_anni_inmezzo = 0;
            if (fine.Year - inizio.Year > 1) n_anni_inmezzo = (fine.Year - inizio.Year) - 1;
            int n_mesi_inmezzo = 0;
            if (fine.Year > inizio.Year) {
                n_mesi_inmezzo = (12 - inizio.Month) + (fine.Month - 1);
            }
            else {
                if (fine.Month - inizio.Month > 1) {
                    n_mesi_inmezzo = fine.Month - inizio.Month - 1;
                }
            }
          
            return giorni_primomese + n_anni_inmezzo * 360 + n_mesi_inmezzo * 30 + giorni_ultimomese;
        }

        public static int NgiorniTotali(DateTime inizio, DateTime Fine, bool commerciale) {
            if (commerciale) {
                return ngiorniCommerciali(inizio, Fine);
            }
            else {
                return 1 + (Fine - inizio).Days;
            }

        }
        public static int NGiorniDaTrascorrere(DateTime Fine, int currAyear, bool commerciale) {            
            if (commerciale) {
                DateTime gen1 = new DateTime(currAyear + 1, 1, 1);
                return ngiorniCommerciali(gen1, Fine);
            }
            else {
                DateTime dec31 = new DateTime(currAyear, 12, 31);
                return (Fine - dec31).Days;
            }
        }

        public static decimal calcolaRisconto(bool ConsideraAnnoCommerciale, int currAyear,
                    decimal importo, DateTime inizioCompetenza, DateTime fineCompetenza) {
            if (inizioCompetenza.Year > currAyear) return importo;
            int tot_giorni = NgiorniTotali(inizioCompetenza, fineCompetenza, ConsideraAnnoCommerciale);
            int tot_datrascorrere = NGiorniDaTrascorrere(fineCompetenza, currAyear, ConsideraAnnoCommerciale);
            decimal importoRisconto = (importo / tot_giorni) * tot_datrascorrere;
            return CfgFn.RoundValuta(importoRisconto);
        }



        /// <summary>
        /// Metodo che costruisce un filtro per C#
        /// </summary>
        /// <param name="risconto"></param>
        /// <param name="rEntryDetail"></param>
        /// <returns></returns>
        private string costruisciFiltro(object risconto, DataRow rEntryDetail) {
            string filter = QHC.CmpEq("idacc", risconto);
            string f2 = QHC.MCmp(rEntryDetail, new string[] {"idreg", "idupb", "idsor1", "idsor2",
                "idsor3", "competencystop", "idaccmotive","idepexp","idepacc"});

            filter = QHC.AppAnd(filter, f2);
            return filter;
        }

   

        public void EditRelatedEntryByKey(DataRow rEntry) {
            if (rEntry == null) return;
            if ((rEntry["yentry"] == DBNull.Value) || (rEntry["nentry"] == DBNull.Value)) return;
            MetaData ToMeta = Meta.Dispatcher.Get("entry");
            if (ToMeta == null) return;
            string checkfilter = QHS.MCmp(rEntry, new string[] { "yentry", "nentry" });
            ToMeta.ContextFilter = checkfilter;
            Form F = null;
            if (Meta.linkedForm != null) F = Meta.linkedForm.ParentForm;
            bool result = ToMeta.Edit(F, "default", false);
            string listtype = ToMeta.DefaultListType;
            DataRow R = ToMeta.SelectOne(listtype, checkfilter, null, null);
            if (R != null) ToMeta.SelectRow(R, listtype);
        }

       
        DataTable ottieniRicaviUPB(object idupb, bool totali,bool leggiIdEpAcc) {
            int currAyear = (int)Meta.GetSys("esercizio");
            string strYear = QHS.quote(currAyear);
            string filter = totali ? QHS.CmpLe("ED.yentry", currAyear) : QHS.CmpEq("ED.yentry", currAyear);
            string strIdepacc = leggiIdEpAcc ? ",ed.idepacc" : "";
            string query = "select  sum(ed.amount) as amount, ed.idacc, ed.idreg,ed.idaccmotive" + strIdepacc+
                    " from entrydetail ed " +
                    " join account A on ED.idacc=A.idacc " +
                    " WHERE " +
                    " A.flagaccountusage & 128 <> 0 " +  //ricavo
                    " AND " + filter +  //scritture di quest'anno o tutte le prec. a seconda del par. di input
                    " AND ED.idupb= " + QHS.quote(idupb) +
                    " group by  ed.idreg, ed.idacc,ed.idaccmotive"+ strIdepacc ;//ed.idepacc,
            DataTable t = Conn.SQLRunner(query, false,600);
            return t;
        }

        //DataTable ottieniCostiUPB(object idupb) {
        //    int currAyear = (int)Meta.GetSys("esercizio");
        //    string strYear = QHS.quote(currAyear);
        //    string query = "select  sum(ed.amount) as amount,  ed.idreg " +//,ed.idepexp,ed.idacc,
        //            " from entrydetail ed " +
        //            " join account A on ED.idacc=A.idacc " +
        //            " WHERE " +
        //            " A.flagaccountusage & 64 <> 0 " +  //costi
        //            " AND ED.yentry= " + strYear +  //scritture di quest'anno
        //            " AND ED.idupb= " + QHS.quote(idupb) +
        //            " group by  ed.idreg"; //,ed.idepexp,ed.idacc
        //    DataTable t = Conn.SQLRunner(query, false,600);
        //    return t;
        //}


        void ripartisciSommaInBaseARicavi(decimal somma, DataTable ricavi) {
            decimal sommaRicavi = MetaData.SumColumn(ricavi, "amount");
            decimal sommaDaRipartire = somma;
            foreach(DataRow r in ricavi.Rows) {
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

        //La scrittura sui ratei va fatta comunque prima di capire se i costi hanno superato  i ricavi, ossia bisogna portare i ratei attivi a costo
        // Infatti questa scrittura è fatta nell'anno della chiusura, mentre l'utile/perdita sarà valutato l'anno successivo
        DataTable ottieniRateiApertiProgettiInChiusura() {
            int currAyear = (int)Meta.GetSys("esercizio");
            string strYear = QHS.quote(currAyear);

            string query = "select  -sum(ed.amount) as accruals ,year(U.stop) as yearstop, year(U.start) as yearstart,ed.idupb,ed.idacc as idacc_accruals,  " +
                "EU.idacc_deferredcost, 	EU.idaccmotive_deferredcost, EU.idacc_revenue,EU.idaccmotive_revenue,U.idepupbkind,U.title,U.codeupb ," +
                "EU.idacc_cost,EU.idaccmotive_cost,EU.idacc_accruals, EU.idaccmotive_accruals " +//, ed.idepacced.idepexp, commentato con task 11624
                    " from entrydetail ed " +
                    " join entry e (nolock) on e.yentry=ed.yentry and e.nentry=ed.nentry "+
                    " join account A on ED.idacc=A.idacc " +
                    " join UPB U on ED.idupb=U.idupb " +
                    " join epupbkindyear EU on EU.idepupbkind = U.idepupbkind " +
                    " WHERE " +
                    " ED.yentry= " + strYear +  //scritture di quest'anno
                    " AND E.identrykind not in (8,11,12) "+
                    " AND ED.idacc=EU.idacc_accruals "+
                    " and EU.ayear =" + strYear+    // prende la configurazione tipo UPB di quest'anno
                    " AND year(U.stop) = " + strYear + // UPB in scadenza quest'anno
                    " AND EU.adjustmentkind='C'  "+        
                    " group by ed.idupb, ed.idacc, EU.idacc_cost,EU.idaccmotive_cost,"+
                     "EU.idacc_deferredcost, 	EU.idaccmotive_deferredcost, EU.idacc_revenue,EU.idaccmotive_revenue," +
                    " EU.idacc_accruals, EU.idacc_deferredcost,EU.idaccmotive_accruals,year(U.stop),year(U.start),U.idepupbkind,U.title,U.codeupb   "; // ed.idepacc,ed.idepexp,
            DataTable t = Conn.SQLRunner(query, false,600);
            return t;
        }
        private DataTable ottieniDettagliAssestamentoCommessaCompletata() {
            int currAyear = (int)Meta.GetSys("esercizio");
            string strYear = QHS.quote(currAyear);
            string query =
                "select U.idupb,  " +
                "-sum(case when A.flagaccountusage & (64+131072) <> 0 then ED.amount else 0 end) as cost," +
                "sum(case when A.flagaccountusage & 128 <> 0 then ED.amount else 0 end) as revenue," +
                "sum(case when A.flagaccountusage & 2048 <> 0 then ED.amount else 0 end) as reserve," +
                "-sum(case when A.idacc = EU.idacc_accruals then ED.amount else 0 end) as accruals," +
                "EU.idacc_cost, EU.idacc_revenue, 	EU.idacc_deferredcost,EU.idacc_accruals," +
                "EU.idaccmotive_cost, EU.idaccmotive_revenue, 	EU.idaccmotive_deferredcost,EU.idaccmotive_accruals," +
                "year(U.stop) as yearstop, year(U.start) as yearstart,   EU.adjustmentkind,U.idepupbkind,U.codeupb,U.title " +
                "from entrydetail ed (nolock) " +
                " join entry e (nolock) on e.yentry=ed.yentry and e.nentry=ed.nentry "+
                "join upb u (nolock) on ed.idupb = u.idupb " +
                "join epupbkindyear EU (nolock)  on EU.idepupbkind = U.idepupbkind " +
                "join account A (nolock) on A.idacc = ed.idacc " +
                " where " +
                QHS.AppAnd(QHS.NullOrLe("year(U.start)", currAyear),
                            QHS.CmpGt("year(U.stop)", currAyear), QHS.CmpEq("EU.ayear", currAyear),
                    QHS.FieldNotIn("e.identrykind",new object[] {8,11,12} ),
                    QHS.CmpEq("EU.adjustmentkind", "C"), QHS.CmpEq("ED.yentry", currAyear)) +
                " group by U.idupb,EU.idacc_cost, EU.idacc_revenue, 	EU.idacc_deferredcost,EU.idacc_accruals, " +
                " EU.idaccmotive_cost, EU.idaccmotive_revenue, 	EU.idaccmotive_deferredcost,EU.idaccmotive_accruals," +
                " EU.adjustmentkind,year(U.stop),year(U.start),U.idepupbkind,U.codeupb,U.title  ";
            

            DataTable tPluri = DataAccess.SQLRunner(Meta.Conn, query,false,600);
            return tPluri;
        }

        private DataTable ottieniDettagliScritturaProgettiPluriennaliPercentuale() {
            int currAyear = (int)Meta.GetSys("esercizio");
            string strYear = QHS.quote(currAyear);
                        
            string query =
                "select U.idupb,  " +
                // costo totale effettivo, inclusivo di quello degli anni precedenti
                "-sum(case when A.flagaccountusage & 64 <> 0 and E.identrykind <> 11 and E.identrykind <> 12 then ED.amount else 0 end) as cost," +
                // ricavo totale effettivo, inclusivo di quello degli anni precedenti
                "sum(case when A.flagaccountusage & 128 <> 0 and E.identrykind <> 11 and E.identrykind <> 12 then ED.amount else 0 end) as revenue," +
                // riserva  totale effettivo, inclusivo di quello degli anni precedenti
                "sum(case when A.flagaccountusage & 2048 <> 0 then ED.amount else 0 end) as reserve," +
                "-sum(case when A.idacc = EU.idacc_accruals then ED.amount else 0 end) as accruals," + // ratei attivi totali, al momento non usati
                "EU.idacc_cost, EU.idacc_revenue, 	EU.idacc_deferredcost,EU.idacc_accruals, " +
                "EU.idaccmotive_cost, EU.idaccmotive_revenue, 	EU.idaccmotive_deferredcost,EU.idaccmotive_accruals," +
                " year(U.stop) as yearstop,    EU.adjustmentkind, " +
                " UY.costprevision, UY.revenueprevision "+
                " from entrydetail ed " +
                " join entry E (nolock) on E.yentry=ED.yentry and E.nentry=ED.nentry "+
                "join upb u (nolock)on ed.idupb = u.idupb " +
                " LEFT OUTER JOIN upbyear UY (nolock) on UY.idupb = U.idupb " +
                "join epupbkindyear EU (nolock) on EU.idepupbkind = U.idepupbkind " +
                "join account A (nolock) on A.idacc = ed.idacc " +
                " where " +
                QHS.AppAnd(QHS.CmpGt("year(U.stop)", currAyear), QHS.CmpEq("UY.ayear", currAyear), QHS.CmpEq("EU.ayear", currAyear),
                    QHS.CmpEq("EU.adjustmentkind", "P"), QHS.CmpLe("ED.yentry", currAyear)) +
                " group by U.idupb,EU.idacc_cost, EU.idacc_revenue, 	EU.idacc_deferredcost,EU.idacc_accruals,year(U.stop)," +
                " EU.idaccmotive_cost, EU.idaccmotive_revenue, 	EU.idaccmotive_deferredcost,EU.idaccmotive_accruals," +
                " EU.adjustmentkind, " +
                 "UY.costprevision, UY.revenueprevision";

            DataTable tPluri = DataAccess.SQLRunner(Meta.Conn, query,false,600);
            return tPluri;
        }
        /**
        integrare i calcoli con le riserve come da task 7516,
             e differenziare comportamento in base al saldo del risultato economico
        
            per quel che riguarda gli anni intermedi, bisogna considerare i vari conti di ricavo come da task 7515
        **/
        // tEntryDetailSource: idupb, cost,revenue,accruals,idacc_cost,idacc_revenue,idacc_deferredcost,idacc_accruals,yearstop
        private bool DoAssestamentoCommessaCompletata(DataTable tEntryDetailSource,string messageNoRows,bool chiusura) {

            DataTable tCommessaCompletata = Conn.RUN_SELECT("upbcommessa","*",null,QHS.CmpEq("ayear",Conn.GetEsercizio()),null,false);
            DataTable tEntry = DataAccess.CreateTableByName(Meta.Conn, "entry", "*");
            DataTable tEntryDetail = DataAccess.CreateTableByName(Meta.Conn, "entrydetail", "*");
            tEntryDetail.Columns.Add("!costi", typeof(decimal));
            tEntryDetail.Columns.Add("!ricavi", typeof(decimal));
            tEntryDetail.Columns.Add("!riserve", typeof(decimal));
            tEntryDetail.Columns.Add("!rateoattivo", typeof(decimal));            
            tEntryDetail.Columns.Add("!scadenza", typeof(int));

         

            Dictionary<string, DataRow> hCommessa = new Dictionary<string, DataRow>();
            foreach (DataRow r in tCommessaCompletata.Rows) hCommessa[r["idupb"].ToString()] = r;
            DataSet ds = new DataSet();
            ds.Tables.Add(tCommessaCompletata);
            ds.Tables.Add(tEntry);
            ds.Tables.Add(tEntryDetail);

            ds.Relations.Add("entryentrydetail",
                    new DataColumn[] { tEntry.Columns["yentry"], tEntry.Columns["nentry"] },
                    new DataColumn[] { tEntryDetail.Columns["yentry"], tEntryDetail.Columns["nentry"] }, false);

            int currYear = (int)Meta.GetSys("esercizio");

            MetaData MEntry = MetaData.GetMetaData(this, "entry");
            MetaData MUpbCommessa = MetaData.GetMetaData(this, "upbcommessa");
            MUpbCommessa.SetDefaults(ds.Tables["upbcommessa"]);
            MetaData.SetDefault(ds.Tables["upbcommessa"], "ayear", currYear);

            MEntry.SetDefaults(ds.Tables["entry"]);
            MetaData.SetDefault(ds.Tables["entry"], "yentry", currYear);

            DateTime dec31 = new DateTime(currYear, 12, 31);
            string descr = "Assestamento Commessa Completata"; //"Rettifica costi/ricavi per progetti pluriennali"; task 8769

            DataRow rEntry = MEntry.Get_New_Row(null, ds.Tables["entry"]);

            rEntry["identrykind"] = 8;
            rEntry["adate"] = dec31;
            rEntry["description"] = descr;

            DateTime jan01 = new DateTime(1 + currYear, 1, 1);

            string campoRicavo = "idacc_revenue";
            string campoCosto = "idacc_cost";
            string campoRateoAttivo = "idacc_accruals";
            string campoRiscontoPassivo = "idacc_deferredcost";

            string causaleRicavo = "idaccmotive_revenue";
            string causaleCosto = "idaccmotive_cost";
            string causaleRateoAttivo = "idaccmotive_accruals";
            string causaleRiscontoPassivo = "idaccmotive_deferredcost";

            RowChange.SetOptimized(ds.Tables["entry"], true);
            RowChange.ClearMaxCache(ds.Tables["entry"]);
            RowChange.SetOptimized(ds.Tables["entrydetail"], true);
            RowChange.ClearMaxCache(ds.Tables["entrydetail"]);


            MetaData MEntryDetail = MetaData.GetMetaData(this, "entrydetail");
            MEntryDetail.SetDefaults(ds.Tables["entrydetail"]);

            progBar.Maximum = tEntryDetailSource.Rows.Count;
            progBar.Value = 0;
            foreach (DataRow Curr in tEntryDetailSource.Rows) {
                progBar.Increment(1);
                progBar.Update();
                Application.DoEvents();
                string idupb = Curr["idupb"].ToString();
                DataRow rCommessa;
                if (hCommessa.ContainsKey(idupb)) {
                    rCommessa = hCommessa[idupb];
                }
                else {
                    MetaData.SetDefault(ds.Tables["upbcommessa"], "idupb", idupb);
                    rCommessa = MUpbCommessa.Get_New_Row(null, ds.Tables["upbcommessa"]);
           

                    hCommessa[idupb] = rCommessa;
                }
                         
                rCommessa["idacc_revenue"] = Curr["idacc_revenue"];
                rCommessa["idacc_cost"] = Curr["idacc_cost"];
                rCommessa["idacc_accruals"] = Curr["idacc_accruals"];
                rCommessa["idacc_deferredcost"] = Curr["idacc_deferredcost"];
                rCommessa["idaccmotive_revenue"] = Curr["idaccmotive_revenue"];
                rCommessa["idaccmotive_cost"] = Curr["idaccmotive_cost"];
                rCommessa["idaccmotive_accruals"] = Curr["idaccmotive_accruals"];
                rCommessa["idaccmotive_deferredcost"] = Curr["idaccmotive_deferredcost"];
                rCommessa["accruals"] = CfgFn.GetNoNullDecimal(rCommessa["accruals"])+CfgFn.GetNoNullDecimal( Curr["accruals"]);
                    
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



                // Dettaglio COSTO - RICAVO (Non ho il problema di controllare l'esistenza di una riga pregressa
                // perché per come è costruita la tabella le righe sono tutte diverse tra di loro
                MetaData.SetDefault(ds.Tables["entrydetail"], "yentry", currYear);
                MetaData.SetDefault(ds.Tables["entrydetail"], "nentry", rEntry["nentry"]);

                bool annoFine = (CfgFn.GetNoNullInt32(Curr["yearstop"]) == currYear);
             
                DataRow rDetail = null;

                if (annoFine) {
                    #region anno fine

                    decimal rateo = CfgFn.GetNoNullDecimal(Curr["accruals"]);
                    if (rateo == 0) continue;

                    if (Curr[campoCosto] == DBNull.Value) {
                        string codeupb = "(non trovato)";
                        object c = Conn.DO_READ_VALUE("upb", QHS.CmpEq("idupb", Curr["idupb"]), "codeupb");
                        if (c != null) codeupb = c.ToString();
                        MessageBox.Show(this, "Campo Costo non trovato per upb " + codeupb, "Errore");
                        return false;
                    }

                    if (Curr[campoRateoAttivo] == DBNull.Value) {
                        string codeupb = "(non trovato)";
                        object c = Conn.DO_READ_VALUE("upb", QHS.CmpEq("idupb", Curr["idupb"]), "codeupb");
                        if (c != null) codeupb = c.ToString();
                        MessageBox.Show(this, "Campo Rateo Attivo non trovato per upb " + codeupb, "Errore");
                        return false; 
                    }


                    //genera scrittura COSTO A RATEO ATTIVO  
                    // Questo perchè tutti i ratei attivi di un progetto chiusto devono essere portati a costo nell'anno di chiusura

                    rDetail = MEntryDetail.Get_New_Row(rEntry, ds.Tables["entrydetail"]);
                    rDetail["!scadenza"] = CfgFn.GetNoNullInt32(Curr["yearstop"]);
                    rDetail["!rateoattivo"] = rateo;
                    rDetail["!costi"] = rateo;
                    rDetail["amount"] = -rateo; //costo in dare (rateo è positivo)
                    //rDetail["idepexp"] = Curr["idepexp"];  commento per task 11624
                    rDetail["idacc"] = Curr[campoCosto];
                    rDetail["idupb"] = Curr["idupb"];
                    rDetail["idaccmotive"] = Curr[causaleCosto];
                    //rDetail["idsor1"] = Curr["idsor1"];
                    //rDetail["idsor2"] = Curr["idsor2"];
                    //rDetail["idsor3"] = Curr["idsor3"];
                    //rEntryDetailCR["idaccmotive"] = Curr["idaccmotive"];
                    rDetail["competencystart"] = DBNull.Value;
                    rDetail["competencystop"] = DBNull.Value;

                    rDetail = MEntryDetail.Get_New_Row(rEntry, ds.Tables["entrydetail"]);
                    rDetail["!scadenza"] = CfgFn.GetNoNullInt32(Curr["yearstop"]);
                    rDetail["!rateoattivo"] = rateo;         
                    rDetail["!costi"] = rateo;
                    rDetail["amount"] = rateo;        //rateo in avere  (rateo è positivo)
                    //rDetail["idepexp"] = Curr["idepexp"]; commento per task 11624
                    rDetail["idacc"] = Curr[campoRateoAttivo];
                    //rDetail["idreg"] = Curr["idreg"];
                    rDetail["idupb"] = Curr["idupb"];
                    rDetail["idaccmotive"] = Curr[causaleRateoAttivo];
                    //rDetail["idsor1"] = Curr["idsor1"];
                    //rDetail["idsor2"] = Curr["idsor2"];
                    //rDetail["idsor3"] = Curr["idsor3"];
                    //rEntryDetailCR["idaccmotive"] = Curr["idaccmotive"];
                    rDetail["competencystart"] = DBNull.Value;
                    rDetail["competencystop"] = DBNull.Value;

                    #endregion

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

                        //DataTable tCosti = ottieniCostiUPB(Curr["idupb"]); //raggruppa su idreg
                        //ripartisciSommaInBaseARicavi(importoRateo, tCosti);

                        //foreach (DataRow r in tCosti.Select()) {

                            var idacc = Curr[campoRateoAttivo]; // r["idacc"];
                            var amount = importoRateo; //CfgFn.GetNoNullDecimal(r["amount"]);
                            var idreg = DBNull.Value; // r["idreg"];

                            if (Curr[campoRicavo] == DBNull.Value) {
                                string codeupb = "(non trovato)";
                                object c = Conn.DO_READ_VALUE("upb", QHS.CmpEq("idupb", Curr["idupb"]), "codeupb");
                                if (c != null) codeupb = c.ToString();
                                MessageBox.Show(this, "Campo Ricavo non trovato per upb " + codeupb, "Errore");
                                return false;
                            }

                            if (Curr[campoRateoAttivo] == DBNull.Value) {
                                string codeupb = "(non trovato)";
                                object c = Conn.DO_READ_VALUE("upb", QHS.CmpEq("idupb", Curr["idupb"]), "codeupb");
                                if (c != null) codeupb = c.ToString();
                                MessageBox.Show(this, "Campo Rateo Attivo non trovato per upb " + codeupb, "Errore");
                                return false;
                            }

                            //genera scrittura RATEO ATTIVO A RICAVI
                            //Deve  
                            rDetail = MEntryDetail.Get_New_Row(rEntry, ds.Tables["entrydetail"]);
                            rDetail["!scadenza"] = CfgFn.GetNoNullInt32(Curr["yearstop"]);
                            rDetail["!ricavi"] = ricavi;
                            rDetail["!costi"] = costi;
                            rDetail["amount"] = amount;
                            rDetail["idacc"] = Curr[campoRicavo];
                            rDetail["idreg"] = idreg;
                            rDetail["idupb"] = Curr["idupb"];
                            //rDetail["idepexp"] = r["idepexp"];
                            rDetail["idaccmotive"] = Curr[causaleRicavo];
                            //rDetail["idsor1"] = Curr["idsor1"];
                            //rDetail["idsor2"] = Curr["idsor2"];
                            //rDetail["idsor3"] = Curr["idsor3"];
                            //rEntryDetailCR["idaccmotive"] = Curr["idaccmotive"];
                            rDetail["competencystart"] = DBNull.Value;
                            rDetail["competencystop"] = DBNull.Value;

                            rDetail = MEntryDetail.Get_New_Row(rEntry, ds.Tables["entrydetail"]);
                            rDetail["!ricavi"] = ricavi;
                            rDetail["!costi"] = costi;
                            rDetail["amount"] = -amount;
                            rDetail["idacc"] = idacc; // era Curr[campoRateoAttivo];
                            //rDetail["idepexp"] = r["idepexp"];   commento per task 11624
                            rDetail["idreg"] = idreg;
                            rDetail["idupb"] = Curr["idupb"];
                            rDetail["idaccmotive"] = Curr[causaleRateoAttivo];
                            //rDetail["idsor1"] = Curr["idsor1"];
                            //rDetail["idsor2"] = Curr["idsor2"];
                            //rDetail["idsor3"] = Curr["idsor3"];
                            //rEntryDetailCR["idaccmotive"] = Curr["idaccmotive"];
                            rDetail["competencystart"] = DBNull.Value;
                            rDetail["competencystop"] = DBNull.Value;
                        //}
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

                        //DataTable tRicavi = ottieniRicaviUPB(Curr["idupb"], false,false); //amount / idacc / idreg
                        //ripartisciSommaInBaseARicavi(importo_risconto, tRicavi);
                        //foreach (DataRow r in tRicavi.Select()) {

                        var idacc = Curr[campoRicavo]; // r["idacc"];
                        var idaccmotive = Curr[causaleRicavo]; //r["idaccmotive"];
                        var amount = importo_risconto; //CfgFn.GetNoNullDecimal(r["amount"]);
                            var idreg = DBNull.Value; // r["idreg"];
                            if (amount == 0) continue;

                            if (idacc == DBNull.Value) {
                                string codeupb = "(non trovato)";
                                object c = Conn.DO_READ_VALUE("upb", QHS.CmpEq("idupb", Curr["idupb"]), "codeupb");
                                if (c != null) codeupb = c.ToString();
                                MessageBox.Show(this, "Campo Ricavo non trovato per upb " + codeupb, "Errore");
                                return false;
                            }

                            if (Curr[campoRiscontoPassivo] == DBNull.Value) {
                                string codeupb = "(non trovato)";
                                object c = Conn.DO_READ_VALUE("upb", QHS.CmpEq("idupb", Curr["idupb"]), "codeupb");
                                if (c != null) codeupb = c.ToString();
                                MessageBox.Show(this, "Campo Risconto Passivo non trovato per upb " + codeupb, "Errore");
                                return false;
                            }

                            rDetail = MEntryDetail.Get_New_Row(rEntry, ds.Tables["entrydetail"]);
                            rDetail["!scadenza"] = CfgFn.GetNoNullInt32(Curr["yearstop"]);
                            rDetail["!ricavi"] = CfgFn.RoundValuta( ricavi*(amount/importo_risconto));
                            rDetail["!costi"] = CfgFn.RoundValuta(costi*(amount/importo_risconto));

                            rDetail["amount"] = -amount;
                            rDetail["idacc"] = idacc; //Curr[campoRicavo];
                            //rDetail["idepacc"] = r["idepacc"];    commento per task 11624
                            rDetail["idreg"] = idreg; //DBNull.Value;
                            rDetail["idupb"] = Curr["idupb"];
                            //rDetail["idsor1"] = Curr["idsor1"];
                            //rDetail["idsor2"] = Curr["idsor2"];
                            //rDetail["idsor3"] = Curr["idsor3"];
                            //rEntryDetailCR["idaccmotive"] = Curr["idaccmotive"];
                            rDetail["idaccmotive"] = idaccmotive;
                            rDetail["competencystart"] = DBNull.Value;
                            rDetail["competencystop"] = DBNull.Value;

                            rDetail = MEntryDetail.Get_New_Row(rEntry, ds.Tables["entrydetail"]);
                            rDetail["amount"] = amount;
                            rDetail["idacc"] = Curr[campoRiscontoPassivo];
                            //rDetail["idepacc"] = r["idepacc"];    commento per task 11624
                            rDetail["idreg"] = DBNull.Value;
                            rDetail["idupb"] = Curr["idupb"];
                            rDetail["idaccmotive"] = Curr[causaleRiscontoPassivo];
                            //rDetail["idsor1"] = Curr["idsor1"];
                            //rDetail["idsor2"] = Curr["idsor2"];
                            //rDetail["idsor3"] = Curr["idsor3"];
                            //rEntryDetailCR["idaccmotive"] = Curr["idaccmotive"];
                            rDetail["competencystart"] = DBNull.Value;
                            rDetail["competencystop"] = DBNull.Value;

                        //}
                    }

                    #endregion

                }

            }

            if (ds.Tables["entrydetail"].Rows.Count == 0 && tCommessaCompletata.Rows.Count==0) {
                MessageBox.Show(this, messageNoRows,@"Avviso");
                return true;
            }
            FrmEntryPreSavePluriennale frm = new FrmEntryPreSavePluriennale(ds.Tables["entrydetail"], Meta.Conn);
            DialogResult dr = frm.ShowDialog();
            if (dr != DialogResult.OK) {
                MessageBox.Show(this, @"Operazione Annullata!");
                return true;
            }
            tEntryDetail.Clear();
            tEntry.Clear();

            PostData Post = MUpbCommessa.Get_PostData();
            Post.InitClass(ds, Meta.Conn);
            if (Post.DO_POST()) {
                MessageBox.Show(this, "Dati di assestamento salvati.");
            }
            else {
                MessageBox.Show(this, "Errore nel salvataggio della scrittura di assestamento!", "Errore");
            }

            int n = tCommessaCompletata.Rows.Count;
            progBar.Maximum = n;
            progBar.Value = 0;
            bool anyError = false;
            foreach (DataRow r in tCommessaCompletata.Rows) {               
                txtCurrent.Text = $@"UPB {r["codeupb"]} {r["title"]}";
                if (!rigeneraScrittura(r)) anyError=true;
                progBar.Increment(1);
                progBar.Update();
                Application.DoEvents();
            }
            txtCurrent.Text = "";
            progBar.Value = 0;
            progBar.Update();
            if (anyError) {
	            MessageBox.Show(this, "Generazione scritture completata con ERRORI.");
            }
            else {
	            MessageBox.Show(this, "Generazione scritture completata.");
            }
            
            return true;
        }

        bool rigeneraScrittura(DataRow curr) {
            try { 
                
                m.DS = curr.Table.DataSet;             
                ep.update(curr.Table.DataSet);
                ep.setForcedCurrentRow(curr);
                ep.etichetteAbilitate = false;
                ep.autoIgnore = true;
                ep.chiediMovimentiParent = false;
                ep.mostraDatiSalvati = false;
                ep.beforePost();
                ep.afterPost(false);
                if (!ep.ultimaGenerazioneRiuscita) {
	                return false;
                }
            }
            catch (Exception e) {
                string msg =
                    $"Errore generando la scrittura per {txtCurrent.Text}, tabella {curr.Table.TableName} nella riga di chiave {QHC.CmpKey(curr)}";
                Meta.LogError(msg, e);
                QueryCreator.ShowException(msg, e);
                return false;
            }

            return true;
        }



        private bool doRettificaPluriennalePercentuale(DataTable tEntryDetailSource, string messageNoRows) {


            DataTable tEntry = DataAccess.CreateTableByName(Meta.Conn, "entry", "*");
            DataTable tEntryDetail = DataAccess.CreateTableByName(Meta.Conn, "entrydetail", "*");
            tEntryDetail.Columns.Add("!costi", typeof(decimal));
            tEntryDetail.Columns.Add("!ricavi", typeof(decimal));
            tEntryDetail.Columns.Add("!rateoattivo", typeof(decimal));
            tEntryDetail.Columns.Add("!scadenza", typeof(int));
            tEntryDetail.Columns.Add("!ricavoteorico", typeof(decimal));
            tEntryDetail.Columns.Add("!riserve", typeof(decimal));

            DataSet ds = new DataSet();
            ds.Tables.Add(tEntry);
            ds.Tables.Add(tEntryDetail);

            ds.Relations.Add("entryentrydetail",
                    new DataColumn[] { tEntry.Columns["yentry"], tEntry.Columns["nentry"] },
                    new DataColumn[] { tEntryDetail.Columns["yentry"], tEntryDetail.Columns["nentry"] }, false);

            int currYear = (int)Meta.GetSys("esercizio");

            MetaData MEntry = MetaData.GetMetaData(this, "entry");
            MEntry.SetDefaults(ds.Tables["entry"]);
            MetaData.SetDefault(ds.Tables["entry"], "yentry", currYear);

            DateTime dec31 = new DateTime(currYear, 12, 31);
            string descr = "Assestamento Percentuale di Completamento"; //"Rettifica costi/ricavi per progetti pluriennali"; task 8769

            DataRow rEntry = MEntry.Get_New_Row(null, ds.Tables["entry"]);

            rEntry["identrykind"] = 13;     //nuovo tipo di rettifica per avanzamento percentuale
            rEntry["adate"] = dec31;
            rEntry["description"] = descr;

            DateTime jan01 = new DateTime(1 + currYear, 1, 1);

            string campoRicavo = "idacc_revenue";
            //string campoCosto = "idacc_cost";
            string campoRateoAttivo = "idacc_accruals";
            string campoRiscontoPassivo = "idacc_deferredcost";

            string causaleRicavo = "idaccmotive_revenue";
            //string causaleCosto = "idaccmotive_cost";
            string causaleRateoAttivo = "idaccmotive_accruals";
            string causaleRiscontoPassivo = "idaccmotive_deferredcost";

            MetaData MEntryDetail = MetaData.GetMetaData(this, "entrydetail");
            MEntryDetail.SetDefaults(ds.Tables["entrydetail"]);


            foreach (DataRow Curr in tEntryDetailSource.Rows) {
                // Dettaglio COSTO - RICAVO (Non ho il problema di controllare l'esistenza di una riga pregressa
                // perché per come è costruita la tabella le righe sono tutte diverse tra di loro
                MetaData.SetDefault(ds.Tables["entrydetail"], "yentry", currYear);
                MetaData.SetDefault(ds.Tables["entrydetail"], "nentry", rEntry["nentry"]);

                bool annoFine = (CfgFn.GetNoNullInt32(Curr["yearstop"]) == currYear);

                DataRow rDetail = null;

                decimal costi = CfgFn.GetNoNullDecimal(Curr["cost"]);       //valore totale complessivo
                decimal ricavi = CfgFn.GetNoNullDecimal(Curr["revenue"]);   //valore totale complessivo

                decimal riserve = CfgFn.GetNoNullDecimal(Curr["reserve"]);  //valore totale complessivo

                //deve considerare anche le riserve
                //poi confrontare costi con ricavi+riserve 
                // la scrittura eventuale deve essere fatta sulla parte (ricavi+riserve)- costi ove positivo

                riserve = 0; //NON CONSIDERA LE RISERVE in base ad aggiornamento task

                decimal ricaviTeorici = ricavi;
                if (!annoFine) {
                    decimal costiPrevisti = CfgFn.GetNoNullDecimal(Curr["costprevision"]);
                    decimal ricaviPrevisti = CfgFn.GetNoNullDecimal(Curr["revenueprevision"]);
                    if (costiPrevisti == 0) {
                        ricaviTeorici = 0;
                    }
                    else {
                        ricaviTeorici = CfgFn.RoundValuta( ricaviPrevisti*(costi/costiPrevisti));
                    }
                }

                //Se ricavo teorico incluso tra ricavo effettivo e ricavo effettivo  + riserve non faccio nulla
                if (ricaviTeorici >= ricavi && ricaviTeorici <= ricavi + riserve) continue;

                if (ricaviTeorici > ricavi + riserve) {
                    //analogo a costi > ricavi+riserve
                    //      e in questo caso utilizzo il conto di default per i ricavi del tipo upb (come da task..)
                    // task 8719 Se ricaviTeorici superano ricavi effettivi +riserve, devono essere  create delle scritture:
                    //      RICAVO a RATEO ATTIVO 
                    //  per la parte di ricaviTeorici che supera ricavi effettivi +riserve
                    //  Il conto di ricavo sarà un conto predefinito per quel progetto, 
                    //                  idem il rateo ma il rateo attivo ove assente prendere il rateo di config
                    decimal importo_rateo = ricaviTeorici - (ricavi + riserve);

                    //DataTable tRicavi = ottieniRicaviUPB(Curr["idupb"], true); //amount / idacc / idreg
                    //ripartisciSommaInBaseARicavi(importo_rateo, tRicavi);

                    //foreach (DataRow r in tRicavi.Select()) {
                    var amount = importo_rateo; //CfgFn.GetNoNullDecimal(r["amount"]); //importo_rateo ripartito
                    var idreg = DBNull.Value;// r["idreg"];

                        //genera scrittura RATEO ATTIVO A RICAVI
                        //Deve  
                        rDetail = MEntryDetail.Get_New_Row(rEntry, ds.Tables["entrydetail"]);
                        rDetail["!scadenza"] = CfgFn.GetNoNullInt32(Curr["yearstop"]);
                        rDetail["!ricavi"] = ricavi;
                        rDetail["!costi"] = costi; // * amount / importo_rateo;
                        rDetail["!ricavoteorico"] = ricaviTeorici; //*amount/importo_rateo;
                        rDetail["amount"] = amount;
                        rDetail["idacc"] = Curr[campoRicavo]; // r["idacc"]; 
                        rDetail["idreg"] = idreg;
                        rDetail["idupb"] = Curr["idupb"];
                        rDetail["idaccmotive"] = Curr[causaleRicavo]; 
                        rDetail["idepexp"] = DBNull.Value; //r["idepexp"];
                        rDetail["competencystart"] = DBNull.Value;
                        rDetail["competencystop"] = DBNull.Value;

                        rDetail = MEntryDetail.Get_New_Row(rEntry, ds.Tables["entrydetail"]);
                        rDetail["!ricavi"] = ricavi;
                        rDetail["!costi"] = costi; // * amount / importo_rateo;
                        rDetail["amount"] = -amount;
                        rDetail["!ricavoteorico"] = ricaviTeorici; // * amount / importo_rateo;
                        rDetail["idacc"] = Curr[campoRateoAttivo];
                        rDetail["idepexp"] = DBNull.Value; //r["idepexp"];
                        rDetail["idreg"] = idreg;
                        rDetail["idupb"] = Curr["idupb"];
                        rDetail["idaccmotive"] = Curr[causaleRateoAttivo];
                        rDetail["competencystart"] = DBNull.Value;
                        rDetail["competencystop"] = DBNull.Value;
                    //}
                }
                else {
                    //  per la parte di ricavi effettivi +riserve che supera  ricaviTeorici 
                    //se i costi sono inferiori ai ricavi
                    decimal importo_risconto = ricavi - ricaviTeorici;

                    //genera scrittura RICAVI A RISCONTI PASSIVI
                    // in questo caso vanno utilizzati i conti di ricavo, in proporzione
                    //  invece come conto di risconto passivo, quello dell'upb
                    // task 7515 Se i ricavi superano i costi, devono essere create delle scritture 
                    //  RICAVO a RISCONTO PASSIVO
                    //  Il conto di RISCONTO PASSIVO va preso dal tipo UPB o, ove non configurato, da CONFIG
                    //  ripartiti proporzionalmente in base ai ricavi dell'anno
                    //  Ossia detto RIS = somma ricavi dell'anno - somma costi dell'anno, ed Rt la somma dei ricavi dell'anno,
                    //    i vari importi da riscontare ripartiti per ricavo saranno pari a RIS *(ricavo / Rt)

                    DataTable tRicavi = ottieniRicaviUPB(Curr["idupb"],true,true); //amount / idacc / idreg
                    ripartisciSommaInBaseARicavi(importo_risconto, tRicavi);
                    foreach (DataRow r in tRicavi.Select()) {
                        var idacc =  r["idacc"]; // Curr[campoRicavo]; 
                        var idaccmotive = r["idaccmovtive"];
                        var amount = CfgFn.GetNoNullDecimal(r["amount"]); // importo_risconto
                        var idreg = r["idreg"];  //DBNull.Value; 

                        rDetail = MEntryDetail.Get_New_Row(rEntry, ds.Tables["entrydetail"]);
                        rDetail["!scadenza"] = CfgFn.GetNoNullInt32(Curr["yearstop"]);
                        rDetail["!ricavi"] = ricavi*(importo_risconto/amount);
                        rDetail["!costi"] = costi*(importo_risconto/amount);
                        rDetail["!ricavoteorico"] = ricaviTeorici;

                        rDetail["amount"] = -amount;
                        rDetail["idacc"] = idacc;
                        rDetail["idepacc"] = r["idepacc"]; //DBNull.Value;
                        rDetail["idreg"] = idreg; //DBNull.Value;
                        rDetail["idupb"] = Curr["idupb"];
                        rDetail["idaccmotive"] = idaccmotive;
                        rDetail["competencystart"] = DBNull.Value;
                        rDetail["competencystop"] = DBNull.Value;

                        rDetail = MEntryDetail.Get_New_Row(rEntry, ds.Tables["entrydetail"]);
                        rDetail["amount"] = amount;
                        rDetail["idacc"] = Curr[campoRiscontoPassivo];
                        rDetail["idepacc"] = r["idepacc"]; //DBNull.Value; 
                        rDetail["idreg"] = idreg; //DBNull.Value;
                        rDetail["idupb"] = Curr["idupb"];
                        rDetail["idaccmotive"] = Curr[causaleRiscontoPassivo];
                        rDetail["competencystart"] = DBNull.Value;
                        rDetail["competencystop"] = DBNull.Value;

                    }

                }
            }

            if (ds.Tables["entrydetail"].Rows.Count == 0) {
                MessageBox.Show(this, messageNoRows, "Avviso");
                return true;
            }
            FrmEntryPreSavePluriennale frm = new FrmEntryPreSavePluriennale(ds.Tables["entrydetail"], Meta.Conn);
            DialogResult dr = frm.ShowDialog();
            if (dr != DialogResult.OK) {
                MessageBox.Show(this, "Operazione Annullata!");
                return true;
            }
            PostData Post = MEntry.Get_PostData();
            Post.InitClass(ds, Meta.Conn);

            if (Post.DO_POST()) {
                DataRow rEntryPosted = ds.Tables["entry"].Rows[0];
                EditRelatedEntryByKey(rEntryPosted);
                MessageBox.Show(this, "Assestamento completato con successo!");
            }
            else {
                MessageBox.Show(this, "Errore nel salvataggio della scrittura di assestamento!", "Errore");
            }

            return true;
        }
	}
}