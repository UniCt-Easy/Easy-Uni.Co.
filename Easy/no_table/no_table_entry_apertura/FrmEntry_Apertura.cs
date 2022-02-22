
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
using funzioni_configurazione;
using metadatalibrary;
using metaeasylibrary;

namespace no_table_entry_apertura {
    public partial class Frmno_table_entry_apertura : MetaDataForm {
        MetaData Meta;
        DataTable tAccountLookUp;
        CQueryHelper QHC;
        QueryHelper QHS;
        DataAccess Conn;
        string idacc_risultatoesercizio_PREC;
        string idacc_risultatoesercizio;
        string idacc_risultatoesercizioprec;
        int esercizio;
        MetaData metaEntry;
        MetaData metaEntryDetail;
        public Frmno_table_entry_apertura() {
            InitializeComponent();
        }
        /*
                     <xs:element name="idacc_economic_result" type="xs:string" minOccurs="0" />
             <xs:element name="idacc_previous_economic_result" type="xs:string" minOccurs="0" />

       */
        public void MetaData_AfterLink() {
            Meta = MetaData.GetMetaData(this);
            Conn = Meta.Conn;
            QHC = new CQueryHelper();
            QHS = Meta.Conn.GetQueryHelper();

            esercizio = Conn.GetEsercizio();
            metaEntry = Meta.Dispatcher.Get("entry");
            metaEntryDetail = Meta.Dispatcher.Get("entrydetail");

            idacc_risultatoesercizio_PREC = Conn.DO_READ_VALUE("config", QHS.CmpEq("ayear", esercizio - 1), "idacc_economic_result").ToString();
            idacc_risultatoesercizio = Conn.DO_READ_VALUE("config", QHS.CmpEq("ayear", esercizio), "idacc_economic_result").ToString();
            idacc_risultatoesercizioprec = Conn.DO_READ_VALUE("config", QHS.CmpEq("ayear", esercizio), "idacc_previous_economic_result").ToString();
            tAccountLookUp = Meta.Conn.RUN_SELECT("accountlookupview","oldidacc,newidacc", null, QHS.CmpEq("newayear", Meta.GetSys("esercizio")), null, false);


            if (Meta.edit_type == "apertura") {
                btnOperazione.Text = "Effettua apertura";
                txtDescrizione.Text =
                    "L'apertura effettua l'inverso delle operazioni di epilogo effettuate nell'anno precedente";
            }
            else {
                btnOperazione.Text = "Riparto risultato di esercizio";
                txtDescrizione.Text =
                    "Questa operazione usa le eventuali riserve assocate a dei progetti per coprirne le perdite. " +
                    "E' creata una scrittura per ogni progetto che si è chiuso in perdita e che possiede delle riserve.  " +
                    "Se c'è un utile questo è ripartito secondo le impostazioni del progetto oppure stornato sul conto " +
                    "\"risultato esercizio precedente\". Se c'è una perdita, questa è stornata sul conto \"risultato esercizio precedente\".";
            }
        }

        public void MetaData_AfterActivation() {
            this.Text = Meta.Name;
        }

        public void MetaData_AfterClear() {
            this.Text = Meta.Name;           
        }

        private void btnApertura_Click(object sender, EventArgs e) {
            if (Meta.edit_type == "apertura") {
                if (!doApertura()) {
                    show(this, "Errore nel processo di apertura dei conti", "Errore");
                }
            }
            if (Meta.edit_type == "riparto") {
                doRipartisciRisultato();
            }
        }

        private bool doVerify () {
            
            string filter = QHS.AppAnd(QHS.CmpEq("identrykind", 7),  //apertura
                                QHS.CmpEq("Year(adate)", Meta.GetSys("esercizio")));
            int num = Conn.RUN_SELECT_COUNT("entry", filter, false);
            
            if (num>0) {
                if (show("Le scritture di Apertura relative all''esercizio corrente risultano già generate. Si desidera proseguire comunque?", "Avviso",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                    return false;
            }
            return true;
        }


        private bool doVerifyRiserve() {
            string filter = QHS.AppAnd(QHS.CmpEq("identrykind", 9),  //apertura
                                QHS.CmpEq("Year(adate)", Meta.GetSys("esercizio")));

            int num = Conn.RUN_SELECT_COUNT("entry", filter, false);

            if (num > 0) {
                if (show("Le scritture di ribaltamento relative all''esercizio corrente risultano già generate. Si desidera proseguire comunque?", "Avviso",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                    return false;
            }
            return true;
        }
        /*
    Estrae tutti i dettagli scrittura associati allo stato patrimoniale, della scrittura di epilogo dell'anno precedente.
    TODO
    Deve fare questo calcolo distinguendo per idupb, idreg
    */

        private bool doApertura() {
            if (!doVerify()) return false;
         
            DataTable tEntry = DataAccess.CreateTableByName(Meta.Conn, "entry", "*");
            DataTable tEntryDetail = DataAccess.CreateTableByName(Meta.Conn, "entrydetail", "*");
            DataSet ds = new DataSet();
            ds.Tables.Add(tEntry);
            metaEntry.SetDefaults(tEntry);

            ds.Tables.Add(tEntryDetail);
            metaEntryDetail.SetDefaults(tEntryDetail);

            tEntry.setOptimized(true);
            RowChange.ClearMaxCache(tEntry);

            tEntryDetail.setOptimized(true);
            RowChange.ClearMaxCache(tEntryDetail);


            ds.Relations.Add(new DataRelation("x", new[] { tEntry.Columns["yentry"], tEntry.Columns["nentry"] },
                                                    new[] { tEntryDetail.Columns["yentry"], tEntryDetail.Columns["nentry"] },
                                                    false
                ));

            int lastEsercizio = esercizio - 1;
            string query = "SELECT ED.amount, ACC.codeacc as olcodeacc, LKP.newidacc as idacc,  LKACC.codeacc, LKACC.title as account,"
            + " ED.idupb, UPB.codeupb , UPB.title as upb, " 
            + " ED.idreg, REGISTRY.title as registry, "
            + " ED.competencystart, ED.competencystop, " 
            + " ED.idaccmotive, ACCMOTIVE.codemotive, ACCMOTIVE.title as accmotive,ED.idepexp,ED.idepacc,ED.idrelated "
            + " FROM entrydetail ED "
            + " JOIN entry E  ON E.yentry = ED.yentry AND E.nentry = ED.nentry "
            + " LEFT OUTER JOIN accountlookup LKP  ON " + QHS.CmpEq("ED.idacc", QHS.Field("LKP.oldidacc"))
            + " LEFT OUTER JOIN account LKACC  ON " + QHS.CmpEq("LKP.newidacc", QHS.Field("LKACC.idacc"))
            + " JOIN account ACC  ON " + QHS.CmpEq("ED.idacc", QHS.Field("ACC.idacc"))
            + " LEFT OUTER JOIN UPB  ON " + QHS.CmpEq("ED.idupb", QHS.Field("UPB.idupb"))
            + " LEFT OUTER JOIN REGISTRY ON " + QHS.CmpEq("ED.idreg", QHS.Field("REGISTRY.idreg"))
            + " LEFT OUTER JOIN ACCMOTIVE ON " + QHS.CmpEq("ED.idaccmotive", QHS.Field("ACCMOTIVE.idaccmotive"))
            + " WHERE " + QHS.AppAnd(QHS.CmpEq("ED.yentry", lastEsercizio),
            QHS.CmpEq("ACC.ayear", lastEsercizio), QHS.CmpEq("E.identrykind", 12)
                ,QHS.IsNotNull("ACC.idpatrimony")   // non saltiamo nulla e ribaltiamo semplicemente tutti i conti attualizzandoli nell'anno successivo
                );
            string errMsg;
            DataTable tSaldo = Meta.Conn.SQLRunner(query,300, out errMsg);
             
            if (tSaldo == null) {
                show(this, "Errore nella query che estrae i conti da aprire " + errMsg, "Errore");
                return false;
            }

            if (tSaldo.Rows.Count == 0) {
                show(this, "La tabella dei saldi risulta vuota, procedura di apertura non eseguita", "Avvertimento");
                return true;
            }

            DataRow rEntry = fillEntryApertura(tEntry);

            if (rEntry == null) {
                show(this, "Errore nella creazione della scrittura", "Errore");
                return false;
            }

            //decimal sumSP = 0;
            //bool addedSP = false;

            string f = QHS.CmpEq("ayear", esercizio);
            object idaccPat = Meta.Conn.DO_READ_VALUE("config", f, "idacc_patrimony");

            if ((idaccPat == null) || (idaccPat == DBNull.Value)) {
                show(this, "Non è stato selezionato il conto che pareggia l'epilogo dei conti patrimoniali", "Errore");
                return false;
            }

            foreach (DataRow rSaldo in tSaldo.Rows) {
                

                //if (!addedSP) addedSP = true;
                //sumSP += CfgFn.GetNoNullDecimal(rSaldo["amount"]);

                if (!calcolaDettaglioApertura(tEntryDetail, rEntry, rSaldo, idaccPat)) return false;
            }

          

            FrmEntryPreSave frm = new FrmEntryPreSave(ds.Tables["entrydetail"], Meta.Conn, tSaldo);
            DialogResult dr = frm.ShowDialog();
            if (dr != DialogResult.OK) {
                show(this, "Operazione Annullata!");
                return true;
            }

            MetaData MetaEntry = MetaData.GetMetaData(this, "entry");
            var Post = new Easy_PostData_NoBL();

        

            Post.InitClass(ds, Meta.Conn);
            if (Post.DO_POST()) {
                DataRow rEntryPosted = tEntry.Rows[0];
                EditEntry(rEntryPosted);
                show(this, "Apertura dei conti effettuata");
            }
            else {
                show(this, "Errore nel salvataggio della scrittura di apertura!", "Errore");
                return false;
            }

            return true;
        }

        void EditEntry(DataRow R) {
            if (R == null) return;
            EditRelatedEntryByKey(R);
        }

        public void EditRelatedEntryByKey(DataRow rEntry) {
            if (rEntry == null) return;
            object yentry = rEntry["yentry"];
            object nentry = rEntry["nentry"];
            if ((yentry == DBNull.Value) || (nentry == DBNull.Value)) return;
            MetaData ToMeta = Meta.Dispatcher.Get("entry");
            if (ToMeta == null) return;
            string checkfilter = QHS.AppAnd(QHS.CmpEq("yentry", yentry), QHS.CmpEq("nentry", nentry));
            ToMeta.ContextFilter = checkfilter;
            Form F = null;
            if (Meta.linkedForm != null) F = Meta.linkedForm.ParentForm;
            bool result = ToMeta.Edit(F, "default", false);
            string listtype = ToMeta.DefaultListType;
            DataRow R = ToMeta.SelectOne(listtype, checkfilter, null, null);
            if (R != null) ToMeta.SelectRow(R, listtype);
        }

        private object attualizzaAccount(string oldidacc) {
            if (oldidacc == idacc_risultatoesercizio_PREC) {
                return idacc_risultatoesercizio;
            }
            int currYear = (int)Meta.GetSys("esercizio");
            string fAcc = QHC.CmpEq("oldidacc", oldidacc);

            if (tAccountLookUp.Select(fAcc).Length > 0) {
                return tAccountLookUp.Select(fAcc)[0]["newidacc"];
            }

            DataAccess.RUN_SELECT_INTO_TABLE(Meta.Conn, tAccountLookUp, null, fAcc, null, true);

            if (tAccountLookUp.Select(fAcc).Length > 0) {
                return tAccountLookUp.Select(fAcc)[0]["newidacc"];
            }
            DataRow rAccountLookUp = tAccountLookUp.NewRow();
            rAccountLookUp["oldidacc"] = oldidacc;
            rAccountLookUp["newidacc"] = currYear.ToString().Substring(2, 2) + oldidacc.Substring(2, oldidacc.Length - 2);
            tAccountLookUp.Rows.Add(rAccountLookUp);
            return rAccountLookUp["newidacc"];
        }

        private DataRow fillEntryApertura(DataTable tEntry) {
            //string filter = QHS.CmpEq("yentry", esercizio);

            //object nEntry = Meta.Conn.DO_READ_VALUE("entry", filter, "MAX(nentry)");
            //if (nEntry == null) {
            //    show(this, "Errore nel calcolo dell'ultima scrittura", "Errore");
            //    return null;
            //}
            //int freeN = 1 + CfgFn.GetNoNullInt32(nEntry);
            metaEntry.SetDefaults(tEntry);
            DataRow rEntry = metaEntry.Get_New_Row(null, tEntry);            
            DateTime primogen = new DateTime(esercizio, 1, 1);
            rEntry["yentry"] = esercizio;
            ////rEntry["nentry"] = freeN;
            rEntry["identrykind"] = "7";
            rEntry["adate"] = primogen;
            rEntry["description"] = "Scrittura di apertura esercizio " + esercizio;
            //rEntry["ct"] = DateTime.Now;
            rEntry["cu"] = "APERTURA";
            rEntry["lt"] = DateTime.Now;
            rEntry["lu"] = "'APERTURA'";
            rEntry["official"] = "S";
            //tEntry.Rows.Add(rEntry);

            return rEntry;
        }

        private bool calcolaDettaglioApertura(DataTable tEntryDetail, DataRow rEntry, DataRow rSaldo, object idaccPat) {
            object newidAcc = rSaldo["idacc"];
            decimal amount = CfgFn.GetNoNullDecimal(rSaldo["amount"]);
            decimal reverseAmount = -amount ;
            if ((newidAcc == null)|| (newidAcc == DBNull.Value)) {
                show(this, "Errore nell'attualizzazione del conto " + rSaldo["olcodeacc"].ToString() + " nell'esercizio corrente.\n" + 
                    "Inserire la configurazione nell'esercizio precedente da Opzioni - Chiusura - Converti voci del piano dei conti annuale, " + 
                    "per poter generare la scrittura di apertura", "Errore");
                return false;
            }
            object idaccmotive = DBNull.Value;
            object idepexp = DBNull.Value;
            object idepacc = DBNull.Value;

            if (rSaldo.Table.Columns.Contains("idaccmotive"))
                idaccmotive = rSaldo["idaccmotive"];

            if (rSaldo.Table.Columns.Contains("idepexp"))
                idepexp = rSaldo["idepexp"];

            if (rSaldo.Table.Columns.Contains("idepexp"))
                idepacc = rSaldo["idepacc"];

            DataRow rEntry1 = fillEntryDetail(tEntryDetail, rEntry, newidAcc, idaccmotive, idepexp, idepacc, reverseAmount,rSaldo["idrelated"]);
            rEntry1["competencystart"] = rSaldo["competencystart"];
            rEntry1["competencystop"] = rSaldo["competencystop"];
            rEntry1["idreg"] = rSaldo["idreg"];
            rEntry1["idupb"] = rSaldo["idupb"];

            DataRow rEntry2 = fillEntryDetail(tEntryDetail, rEntry, idaccPat,idaccmotive, idepexp, idepacc, amount,DBNull.Value);
            rEntry2["competencystart"] = rSaldo["competencystart"];
            rEntry2["competencystop"] = rSaldo["competencystop"];
            rEntry2["idreg"] = rSaldo["idreg"];
            rEntry2["idupb"] = rSaldo["idupb"];

            return true;
        }

        private DataRow getEntryRibaltamento(DataTable tEntry) {          
            DataRow rEntry = metaEntry.Get_New_Row(null, tEntry);
            DateTime primogen = new DateTime(esercizio, 1, 1);
            rEntry["yentry"] = esercizio;
            rEntry["identrykind"] = "9";
            rEntry["adate"] = primogen;
            rEntry["official"] = "S";
            rEntry["description"] = "Riparto Risultato Economico";

            //tEntry.Rows.Add(rEntry);

            return rEntry;
        }
       
        protected DataRow fillEntryDetail(DataTable tEntryDetail, DataRow rEntry, object idacc, object idaccmotive, object idepexp, object idepacc, decimal amount,object idrelated) {
            metaEntryDetail.SetDefaults(tEntryDetail);

            DataRow rEntryDetail = metaEntryDetail.Get_New_Row(rEntry, tEntryDetail);
            //object nDetMax = tEntryDetail.Compute("MAX(ndetail)", null);
            //int freeDetail = 1 + CfgFn.GetNoNullInt32(nDetMax);
            //rEntryDetail["yentry"] = rEntry["yentry"];
            //rEntryDetail["nentry"] = rEntry["nentry"];
            //rEntryDetail["ndetail"] = freeDetail;
            rEntryDetail["amount"] = amount;
            rEntryDetail["idacc"] = idacc;
            rEntryDetail["idaccmotive"] = idaccmotive;
            rEntryDetail["idepexp"] = idepexp;
            rEntryDetail["idepacc"] = idepacc;
            rEntryDetail["ct"] = DateTime.Now;
            rEntryDetail["cu"] = "APERTURA";
            rEntryDetail["lt"] = DateTime.Now;
            rEntryDetail["lu"] = "'APERTURA'";
            rEntryDetail["idrelated"] = idrelated;

            //tEntryDetail.Rows.Add(rEntryDetail);
            return rEntryDetail;
        }

        //protected override DataRow fillEntryDetail(DataTable tEntryDetail, DataRow rEntry, object idacc, decimal amount) {
        //    DataRow rEntryDetail = fillEntryDetail(tEntryDetail, rEntry, idacc, null, null, amount);
        //    return rEntryDetail;
        //}



        bool doRipartisciRisultato() {
            //eventuali controlli di applicabilità
            if (!doVerifyRiserve()) return false;

            DataTable tEntry = DataAccess.CreateTableByName(Meta.Conn, "entry", "*");
            DataTable tEntryDetail = DataAccess.CreateTableByName(Meta.Conn, "entrydetail", "*");
            DataSet ds = new DataSet();
            ds.Tables.Add(tEntry);
            metaEntry.SetDefaults(tEntry);

            ds.Tables.Add(tEntryDetail);
            metaEntryDetail.SetDefaults(tEntryDetail);

            RowChange.SetOptimized(tEntry, true);
            RowChange.ClearMaxCache(tEntry);
            RowChange.SetOptimized(tEntryDetail, true);
            RowChange.ClearMaxCache(tEntryDetail);


            ds.Relations.Add(new DataRelation("x", new [] { tEntry.Columns["yentry"], tEntry.Columns["nentry"] },
                                                    new [] { tEntryDetail.Columns["yentry"], tEntryDetail.Columns["nentry"] },
                                                    false
                ));


            string query = "select U.idupb,U.codeupb, U.title as upb, sum(amount) as amount from entrydetail ED " +
                            " LEFT OUTER JOIN UPB U ON ED.idupb=U.idupb "+
                           " WHERE " + QHS.AppAnd(QHS.CmpEq("ED.yentry", esercizio), QHS.CmpEq("idacc", idacc_risultatoesercizio)) +
                           " group by U.idupb,U.codeupb, U.title " +
                           " having sum(amount)<>0 ";
            string errMsg;
            DataTable t = Meta.Conn.SQLRunner(query, 300, out errMsg);
          
            if (t == null) {
                show(this, "Errore nella query che estrae i risultati da ripartire  " + errMsg, "Errore");
                return false;
            }

            if (t.Rows.Count == 0) {
                show(this, "Nessun risultato economico da ripartire", "Avvertimento");
                return true;
            }

            DataRow rEntry = getEntryRibaltamento(tEntry);
            if (rEntry == null) {
                show(this, "Errore nella creazione della scrittura", "Errore");
                return false;
            }

            foreach (DataRow r in t.Rows) {                
                if (!calcolaDettaglioRibaltamento(tEntryDetail, rEntry, r)) return false;
            }


           

            FrmEntryPreSave frm = new FrmEntryPreSave(ds.Tables["entrydetail"], Meta.Conn, t);
            DialogResult dr = frm.ShowDialog();
            if (dr != DialogResult.OK) {
                show(this, "Operazione Annullata!");
                return true;
            }

            
            PostData post = metaEntry.Get_PostData();

            post.InitClass(ds, Meta.Conn);
            if (post.DO_POST()) {
                DataRow rEntryPosted = tEntry.Rows[0];
                EditEntry(rEntryPosted);
                show(this, "Ripartimento del risultato economico completato con successo!");
            }
            else {
                show(this, "Errore nel salvataggio della scrittura di ripartimento", "Errore");
                return false;
            }
            return true;
        }

        /**
            R ha le colonne: idupb, amount ove amount è il risultato economico dell'upb ribaltato dall'apertura

        **/

        Dictionary<string, decimal> ripartisciUtileInBaseATabella(decimal utile, DataTable quote) {
            decimal sommaQuote = MetaData.SumColumn(quote, "quota");
            Dictionary<string, decimal> q = new Dictionary<string, decimal>();
            decimal sommaDaRipartire = utile;
            if (sommaQuote < 1) {
                foreach (DataRow r in quote.Rows) {
                    string idupb = r["idupb_dest"].ToString();
                    decimal quotaPerc = CfgFn.GetNoNullDecimal(r["quota"]);
                    decimal quota = sommaDaRipartire * quotaPerc;
                    q[idupb] = quota;
                }
            }

            foreach (DataRow r in quote.Rows) {
                string idupb = r["idupb_dest"].ToString();
                decimal quotaPerc = CfgFn.GetNoNullDecimal(r["quota"]);
                decimal quota = sommaDaRipartire * (quotaPerc / sommaQuote);
                q[idupb] = quota;
                sommaQuote -= quotaPerc;
                sommaDaRipartire -= quota;
            }
            return q;
        }

        Dictionary<string, decimal> ripartisciPerditaInBaseARiserve(decimal perdita, DataTable riserve) {
            decimal sommaRiserve = CfgFn.GetNoNullDecimal(riserve.Compute("sum(amount)",QHC.CmpGt("amount",0)));
            
            Dictionary<string, decimal> q = new Dictionary<string, decimal>();
            decimal sommaDaRipartire = perdita;
            if (sommaRiserve == sommaDaRipartire) {
                foreach (DataRow r in riserve.Rows) {
                    string idacc = r["idacc"].ToString();
                    q[idacc] =  CfgFn.GetNoNullDecimal(r["amount"]);
                }
                return q;
            }

            foreach (DataRow r in riserve.Select(QHC.CmpGt("amount",0),"amount desc")) {
                string idacc = r["idacc"].ToString();
                decimal riserva = CfgFn.GetNoNullDecimal(r["amount"]);
                decimal quota = 0;
                if (riserva != 0) {
                    quota = CfgFn.RoundValuta(sommaDaRipartire * (riserva / sommaRiserve));
                }
                q[idacc] = quota;
                sommaRiserve -= riserva;
                sommaDaRipartire -= quota;
            }
            return q;
        }


        private bool calcolaDettaglioRibaltamento(DataTable tEntryDetail, DataRow rEntry, DataRow r) {

            
            

            decimal risultatoEconomico = CfgFn.GetNoNullDecimal(r["amount"]);
            //risultatoEconomico negativo indica una perdita, positivo un utile 
            if (risultatoEconomico > 0) {
                decimal distribuito = 0;
                //UTILE
                // sarà generata una scrittura 
                //  risultato economico  A riserva
                // sul progetto di destinazione scelto nel progetto chiuso, nel conto di riserva predefinito del progetto di destinazione, 
                // con l'indicazione delle due upb distinte. Sempre che sia stato indicato un progetto di destinazione, altrimenti sarà usato 
                //  un conto predefinito "RISULTATO ECONOMICO ANNI PRECEDENTI" presente in config 
                if (r["idupb"] != DBNull.Value) {
                    DataTable quote =
                        Conn.SQLRunner("select UP.idupb_dest,UP.quota,UK.idacc_reserve from upbprofitpartition UP " +
                                       " left outer join upb U on UP.idupb=U.idupb " +
                                       " join epupbkindyear UK on  UK.idepupbkind=U.idepupbkind " +
                                       " where " +
                                       QHS.AppAnd(QHS.CmpEq("UP.idupb", r["idupb"]), QHS.CmpEq("UK.ayear", esercizio)),
                            false);

                    Dictionary<string, decimal> quotes = ripartisciUtileInBaseATabella(risultatoEconomico, quote);

                    foreach (DataRow  rr in quote.Rows) {
                        var idupb = rr["idupb_dest"].ToString();
                        var ripartizione = quotes[idupb];
                        distribuito += ripartizione;
                        // task 7518
                        //calcola idacc di destinazione come conto di riserva dell'upb di destinazione oppure usa risultato economico anni prec.
                        //La scrittura ha come origine (negativo) l'idupb in questione, mentre come destinazione (positivo) idupb_dest
                        //il  nuovo campo lo chiamiamo epupbkindyear.idacc_reserve
                        var idaccDest = rr["idacc_reserve"];
                        if (idaccDest == DBNull.Value) idaccDest = idacc_risultatoesercizioprec;

                        DataRow rDetFrom = metaEntryDetail.Get_New_Row(rEntry, tEntryDetail);
                        rDetFrom["idacc"] = idacc_risultatoesercizio;
                        rDetFrom["idupb"] = r["idupb"];
                        rDetFrom["amount"] = -ripartizione;


                        var rDetDest = metaEntryDetail.Get_New_Row(rEntry, tEntryDetail);
                        rDetDest["idacc"] = idaccDest;
                        rDetDest["idupb"] = idupb;
                        rDetDest["amount"] = ripartizione;
                    }
                }
                decimal utileResiduo = risultatoEconomico - distribuito;
                if (utileResiduo > 0) {
                    // task 7518
                    //scrittura del residuo come storno dal conto RISULTATO ECONOMICO ANNI PRECEDENTI sullo stesso UPB
                    var rDetFrom = metaEntryDetail.Get_New_Row(rEntry, tEntryDetail);
                    rDetFrom["idacc"] = idacc_risultatoesercizio;
                    rDetFrom["idupb"] = r["idupb"];
                    rDetFrom["amount"] = -utileResiduo;


                    var rDetDest = metaEntryDetail.Get_New_Row(rEntry, tEntryDetail);
                    rDetDest["idacc"] = idacc_risultatoesercizioprec;
                    rDetDest["idupb"] = r["idupb"];
                    rDetDest["amount"] = utileResiduo;


                }

            }
            else {
                // task 7518
                //PERDITA
                // Se invece il progetto si è chiuso in perdita, bisognerà scegliere delle riserve a copertura. La parte in eccesso sarà coperta con lo stesso conto "risultato economico anni precedenti".I casi sono:
                //      RISERVA a   Risultato economico
                // e per la parte in eccesso alle riserve:
                //    Risultato economico esercizi precedenti    a Risultato economico
                decimal perdita = -risultatoEconomico;                
                decimal riserveImpiegate = 0;
                if (r["idupb"] != DBNull.Value) {
                    DataTable riserve = getRiserve(r["idupb"]);
                    decimal totaleRiserve  = MetaData.SumColumn(riserve, "amount");
                    
                    if (totaleRiserve > 0) {
                        if (totaleRiserve <= perdita) {
                            //tutte le riserve  vanno impiegate, scrittura   RISERVA a   Risultato economico
                            foreach (DataRow r1 in riserve.Rows) {
                                decimal riserva = CfgFn.GetNoNullDecimal(r1["amount"]);
                                var rDetFrom = metaEntryDetail.Get_New_Row(rEntry, tEntryDetail);
                                rDetFrom["idacc"] = r1["idacc"];
                                rDetFrom["idupb"] = r["idupb"];
                                rDetFrom["amount"] = -riserva;


                                var rDetDest = metaEntryDetail.Get_New_Row(rEntry, tEntryDetail);
                                rDetDest["idacc"] = idacc_risultatoesercizio;
                                rDetDest["idupb"] = r["idupb"];
                                rDetDest["amount"] = riserva;

                            }
                            riserveImpiegate = totaleRiserve;
                        }
                        if (totaleRiserve > perdita) {
                            //solo una parte delle riserve va impiegata, ossia va usata la proporzione
                            var quotes = ripartisciPerditaInBaseARiserve(perdita, riserve);

                            foreach (DataRow r1 in riserve.Rows) {
                                if (!quotes.ContainsKey(r1["idacc"].ToString()))continue;
                                decimal riserva = quotes[r1["idacc"].ToString()];
                                DataRow rDetFrom = metaEntryDetail.Get_New_Row(rEntry, tEntryDetail);
                                rDetFrom["idacc"] = r1["idacc"];
                                rDetFrom["idupb"] = r["idupb"];
                                rDetFrom["amount"] = -riserva;

                                DataRow rDetDest = metaEntryDetail.Get_New_Row(rEntry, tEntryDetail);
                                rDetDest["idacc"] = idacc_risultatoesercizio;
                                rDetDest["idupb"] = r["idupb"];
                                rDetDest["amount"] = riserva;

                            }
                            riserveImpiegate = perdita;
                        }
                    }
                }
                decimal perditaResidua = perdita - riserveImpiegate;
                if (perditaResidua > 0) {
                    //questa parte va riportata nel Risultato economico esercizi precedenti dell'upb stesso
                    //  Risultato economico esercizi precedenti    a Risultato economico
                    DataRow rDetFrom = metaEntryDetail.Get_New_Row(rEntry, tEntryDetail);
                    rDetFrom["idacc"] = idacc_risultatoesercizioprec;
                    rDetFrom["idupb"] = r["idupb"];
                    rDetFrom["amount"] = -perditaResidua;

                    DataRow rDetDest = metaEntryDetail.Get_New_Row(rEntry, tEntryDetail);
                    rDetDest["idacc"] = idacc_risultatoesercizio;
                    rDetDest["idupb"] = r["idupb"];
                    rDetDest["amount"] = perditaResidua;
                }

            }

            return true;
        }

        DataTable getRiserve(object idupb) {
            return Conn.SQLRunner(
                "SELECT ED.idacc, sum(ED.amount) as amount from entrydetail ED "+
                " join account AC on ED.idacc=AC.idacc "+
                " where "+QHS.AppAnd(QHS.CmpEq("ED.yentry",esercizio), QHS.CmpEq("ED.idupb",idupb),QHS.BitSet("AC.flagaccountusage",11))+
                " group by ED.idacc "+
                " having sum(ED.amount)<>0"
                , false);
        }
    }
}
