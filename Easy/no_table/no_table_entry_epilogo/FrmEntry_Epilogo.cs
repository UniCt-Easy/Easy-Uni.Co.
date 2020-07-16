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
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using funzioni_configurazione;
using metadatalibrary;

namespace no_table_entry_epilogo {
    public partial class Frmno_table_entry_epilogo : Form {
        MetaData Meta;
        CQueryHelper QHC;
        QueryHelper QHS;
        DataAccess Conn;
        int esercizio;
        string idacc_risultatoesercizio;

        public Frmno_table_entry_epilogo() {
            InitializeComponent();
        }
        object idaccPAT;
        object idaccPL;
        public void MetaData_AfterLink() {
            Meta = MetaData.GetMetaData(this);
            Conn = Meta.Conn;
            esercizio = Conn.GetEsercizio();
            QHC = new CQueryHelper();
            QHS = Meta.Conn.GetQueryHelper();
            string f = QHS.CmpEq("ayear", esercizio);
            idacc_risultatoesercizio = Conn.DO_READ_VALUE("config", f, "idacc_economic_result").ToString();


            idaccPAT = Meta.Conn.DO_READ_VALUE("config", f, "idacc_patrimony");


            if ((idaccPAT == null) || (idaccPAT == DBNull.Value)) {
                MessageBox.Show(this, "Non Ë stato selezionato il conto che pareggia l'epilogo dei conti patrimoniali", "Errore");
            }

            idaccPL = Meta.Conn.DO_READ_VALUE("config", f, "idacc_pl");

            if ((idaccPL == null) || (idaccPL == DBNull.Value)) {
                MessageBox.Show(this, "Non Ë stato selezionato il conto che pareggia l'epilogo dei conti economici", "Errore");
            }



        }

        public void MetaData_AfterActivation() {
            if (this.Text.EndsWith("(Ricerca)")) {
                this.Text = this.Text.Replace("(Ricerca)", "");
            }
            doVerify();
        }

        public void MetaData_AfterClear() {
            if (this.Text.EndsWith("(Ricerca)")) {
                this.Text = this.Text.Replace("(Ricerca)", "");
            }
        }

        private bool doVerify() {
            bool EsisteContoEconomicoAperto = false;
            labAllDone.Visible = false;
            //vede se ci sono conti economici non pareggiati
            string query = " Select ED.idacc,  "+
                            " case when flag&2 = 0 and flagupb = 'S'  then ED.idupb else null end as idupb , " +
                            " case when flag&1 = 0 and flagregistry='S'  then ED.idreg else null end as idreg, " +
                            " SUM(ED.amount) from entrydetail ED " +
                            " join account A on ED.idacc=A.idacc " +
                            " WHERE " + QHS.AppAnd(QHS.CmpEq("ED.yentry", esercizio), QHS.IsNotNull("A.idplaccount")) +
                            " group by ED.idacc,(case when flag&2 =0 and flagupb = 'S' then ED.idupb else null end), " +
                            "( case when flag&1 =0 and flagregistry='S' then ED.idreg else null end) " +
                            " having SUM(ED.amount)<>0 ";

            DataTable t = Conn.SQLRunner(query, false, 0);
            if (t.Rows.Count > 0) EsisteContoEconomicoAperto = true;
            if (EsisteContoEconomicoAperto) {
                btnEpilogoEconomico.Visible = true;
                btnRisultatoEconomico.Visible = false;
                btnEpilogoStatoPatrimoniale.Visible = false;
                return true;
            }
            btnEpilogoEconomico.Visible = false;

            bool epilogoEconomicoAperto = false;
            query = " Select ED.idacc,  " +
                            " case when flag&2 = 0 and flagupb = 'S' then ED.idupb else null end as idupb , " +
                            " case when flag&1 =0 and flagregistry='S'  then ED.idreg else null end as idreg,  " +
                            " SUM(ED.amount) from entrydetail ED " +
                            " join account A on ED.idacc=A.idacc " +
                            " WHERE " + QHS.AppAnd(QHS.CmpEq("ED.yentry", esercizio), QHS.CmpEq("ED.idacc", idaccPL)) +
                            " group by ED.idacc,(case when flag&2 = 0 and flagupb = 'S' then ED.idupb else null end)," +
                            " ( case when flag&1 =0 and flagregistry='S' then ED.idreg else null end) " +
                            " having SUM(ED.amount)<>0 ";
            t = Conn.SQLRunner(query, false, 0);
            if (t.Rows.Count > 0) epilogoEconomicoAperto = true;

            if (epilogoEconomicoAperto) {
                btnRisultatoEconomico.Visible = true;
                btnEpilogoStatoPatrimoniale.Visible = false;
                return true;
            }
            btnRisultatoEconomico.Visible = false;

            bool EsisteStatoPatrimonialeAperto = false;
            query = " Select ED.idacc, SUM(ED.amount) from entrydetail ED " +
                            " join account A on ED.idacc=A.idacc " +
                            " WHERE " + QHS.AppAnd(QHS.CmpEq("ED.yentry", esercizio), QHS.IsNotNull("A.idpatrimony")) +
                            " group by ED.idacc " +
                            " having SUM(ED.amount)<>0 ";

            t = Conn.SQLRunner(query, false, 0);
            if (t.Rows.Count > 0) EsisteStatoPatrimonialeAperto = true;


            if (EsisteStatoPatrimonialeAperto) {
                btnEpilogoStatoPatrimoniale.Visible = true;
                return true;
            }

            btnEpilogoStatoPatrimoniale.Visible = false;
            labAllDone.Visible = true;
            return false;
            
        }

        private void btnEpilogo_Click(object sender, EventArgs e) {

            if (!doEpilogo(true)) {
                MessageBox.Show(this, "Errore nel processo di epilogo", "Errore");
            }
        }

        bool doRisultatoEconomico() {

            DataTable tEntry = DataAccess.CreateTableByName(Meta.Conn, "entry", "*");
            DataTable tEntryDetail = DataAccess.CreateTableByName(Meta.Conn, "entrydetail", "*");


            if ((idaccPL == null) || (idaccPL == DBNull.Value)) {
                MessageBox.Show(this, "Non Ë stato selezionato il conto che pareggia l'epilogo dei conti economici", "Errore");
                return false;
            }

            string filter = QHS.AppAnd(QHS.CmpEq("ED.yentry", esercizio),
                                        QHS.CmpEq("ACC.ayear", esercizio)
                                        );
            filter = QHS.AppAnd(filter, QHS.CmpEq("ED.idacc", idaccPL));

            if ((idaccPL == null) || (idaccPL == DBNull.Value)) {
                MessageBox.Show(this, "Non Ë stato selezionato il conto che pareggia l'epilogo dei conti economici", "Errore");
                return false;
            }

            if ((idacc_risultatoesercizio == null) || (idacc_risultatoesercizio == "")) {
                MessageBox.Show(this, "Non Ë stato selezionato il conto di risultato esercizio", "Errore");
                return false;
            }
            Conn.BeginTransaction(IsolationLevel.ReadCommitted);
            string errMess;
            DataSet ds = Conn.CallSP("compute_epilogo",
            new object[] { Meta.GetSys("esercizio"), 'R', Conn.GetSys("idsor01"), Conn.GetSys("idsor02"), Conn.GetSys("idsor03"), Conn.GetSys("idsor04"), Conn.GetSys("idsor05") },
                600, out errMess);
            if (errMess != null) {
                Conn.RollBack();
                MessageBox.Show(this, "Errore nella query che estrae i conti da epilogare, la transazione Ë stata interrotta\r\rContattare il servizio assistenza"
                    + "\r\rDettaglio dell'errore :\r\r" + errMess, "Errore");
                doVerify();
                return false;
            }
            Conn.Commit();
            MessageBox.Show(this, "Risultato economico completato con successo!", "Informazione", MessageBoxButtons.OK, MessageBoxIcon.Information);
            doVerify();
            Meta.FreshForm();
            return true;

            //string query = "SELECT -SUM(ED.amount) AS amount, ED.idacc, " +
            //               " case when flag&2 =0 and flagupb = 'S' then ED.idupb else null end as idupb , " +
            //               " case when flag&1 =0 and flagregistry = 'S' then ED.idreg else null end as idreg  "
            //               + " FROM entrydetail ED "
            //               + " JOIN account ACC "
            //               + " ON " + QHS.CmpEq("ED.idacc", QHS.Field("ACC.idacc"))
            //               + " WHERE " + filter
            //               + " GROUP BY ED.idacc, (case when flag&2 =0 and flagupb = 'S' then ED.idupb else null end), " 
            //               + "( case when flag&1 =0 and flagregistry = 'S' then ED.idreg else null end)"
            //               + " having SUM(ED.amount)<>0 ";

            //DataTable tSaldo = Meta.Conn.SQLRunner(query);

            //if (tSaldo == null) {
            //    MessageBox.Show(this, "Errore nella query che estrae i conti da epilogare", "Errore");
            //    return false;
            //}

            //if (tSaldo.Rows.Count == 0) {
            //    MessageBox.Show(this, "Non ci sono conti del tipo selezionato da epilogare", "Avvertimento");
            //    return true;
            //}


            //DataRow rEntry;
            //rEntry = fillEntry(tEntry, " (rilevazione risultato economico)", 10);
            

            //if (rEntry == null) {
            //    MessageBox.Show(this, "Errore nella creazione della scrittura", "Errore");
            //    return false;
            //}
            //var useIdReg =
            //    Conn.DO_READ_VALUE("account", QHS.CmpEq("idacc", idacc_risultatoesercizio), "flagregistry")
            //        .ToString()
            //        .ToUpper() == "S";
            //if (useIdReg) {
            //    int flag =
            //        CfgFn.GetNoNullInt32(Conn.DO_READ_VALUE("account", QHS.CmpEq("idacc", idacc_risultatoesercizio),
            //            "flag"));
            //    if ((flag & 1) != 0) useIdReg = false;
            //}
            //var useIdUpb =
            //    Conn.DO_READ_VALUE("account", QHS.CmpEq("idacc", idacc_risultatoesercizio), "flagupb")
            //        .ToString()
            //        .ToUpper() == "S";
            //if (useIdUpb) {
            //    int flag =
            //        CfgFn.GetNoNullInt32(Conn.DO_READ_VALUE("account", QHS.CmpEq("idacc", idacc_risultatoesercizio),
            //            "flag"));
            //    if ((flag & 2) != 0) useIdUpb = false;
            //}
            //bool useIdAccMotive = false;
            //bool useIdEpexp= false;
            //foreach (DataRow rSaldo in tSaldo.Rows) {
            //        fillEntryDetail(tEntryDetail, rEntry, rSaldo, useIdAccMotive, useIdEpexp);
            //        fillEntryDetail(tEntryDetail, rEntry, idacc_risultatoesercizio, rSaldo,useIdReg, useIdUpb,useIdAccMotive, useIdEpexp);
            //}

            //DataSet ds = new DataSet();
            //ds.Tables.Add(tEntry);
            //ds.Tables.Add(tEntryDetail);

            //tEntry.setOptimized(true);
            //RowChange.ClearMaxCache(tEntry);

            //tEntryDetail.setOptimized(true);
            //RowChange.ClearMaxCache(tEntryDetail);

            //FrmEntryPreSave frm = new FrmEntryPreSave(ds.Tables["entrydetail"], Meta.Conn);
            //DialogResult dr = frm.ShowDialog();
            //if (dr != DialogResult.OK) {
            //    MessageBox.Show(this, "Operazione Annullata!");
            //    return true;
            //}

            //MetaData MetaEntry = MetaData.GetMetaData(this, "entry");
            //PostData Post = MetaEntry.Get_PostData();

            //Post.InitClass(ds, Meta.Conn);
            //if (Post.DO_POST()) {
            //    DataRow rEntryPosted = tEntry.Rows[0];
            //    EditEntry(rEntryPosted);
            //    MessageBox.Show(this, "Epilogo completato con successo!");
            //    doVerify();
            //    return true;
            //}
            //else {
            //    MessageBox.Show(this, "Errore nel salvataggio dell'epilogo", "Errore");
            //    doVerify();
            //    return false;
            //}
        }

        /*
         Deve discriminare  idupb/idreg nel pareggio conti patrimmoniali ed economici.

         Se il saldo del epilogo del conto economico Ë diverso da zero, lo devo pareggiare con una scrittura che coinvolga il conto di config
         risultato economico
         In entry kind aggiungere "Risultato economico - Saldo"
         e la scrittura suddetta sar‡ di questo tipo

         Ordine delle operazioni:
         epilogo conto economico suddiviso per upb - anagrafica        identykind 6	        Epilogo

         risultato economico suddiviso per upb - anagrafica            identrykind 10	    Rilevazione Risultato Economico

         epilogo stato patrimoniale suddiviso per upb - anagrafica     identykind 6	        Epilogo
        */

        private bool doEpilogo(bool economico) {    
            DataTable tEntry = DataAccess.CreateTableByName(Meta.Conn, "entry", "*");
            DataTable tEntryDetail = DataAccess.CreateTableByName(Meta.Conn, "entrydetail", "*");

            int esercizio = (int)Meta.GetSys("esercizio");

            string filter = QHS.AppAnd(QHS.CmpEq("ED.yentry", esercizio),
                                        QHS.CmpEq("ACC.ayear", esercizio));
            if (economico) {
                filter = QHS.AppAnd(filter, QHS.IsNotNull("ACC.idplaccount"));

                if ((idaccPL == null) || (idaccPL == DBNull.Value)) {
                    MessageBox.Show(this, "Non Ë stato selezionato il conto che pareggia l'epilogo dei conti economici", "Errore");
                    return false; 
                }
            }
            else {
                filter = QHS.AppAnd(filter, QHS.IsNotNull("ACC.idpatrimony"));
                if ((idaccPAT == null) || (idaccPAT == DBNull.Value)) {
                    MessageBox.Show(this, "Non Ë stato selezionato il conto che pareggia l'epilogo dei conti patrimoniali", "Errore");
                    return false;
                }
            }

            Conn.BeginTransaction(IsolationLevel.ReadCommitted);
            string errMess;

            object kind;
            if (economico) {
                kind = 'E';
            }
            else {
                kind = 'P';
            }
            DataSet ds = Conn.CallSP("compute_epilogo",
                new object[] { Meta.GetSys("esercizio"), kind, Conn.GetSys("idsor01"), Conn.GetSys("idsor02"), Conn.GetSys("idsor03"), Conn.GetSys("idsor04"), Conn.GetSys("idsor05") },
                3600, out errMess);
            if (errMess != null) {
                Conn.RollBack();
                MessageBox.Show(this, "Errore nella query che estrae i conti da epilogare, la transazione Ë stata interrotta\r\rContattare il servizio assistenza"
                    + "\r\rDettaglio dell'errore :\r\r" + errMess, "Errore");
                doVerify();
                return false;
            }
            Conn.Commit();
            doVerify();
            Meta.FreshForm();
           
            if (!economico) {
                object ayear = Conn.GetEsercizio(); 
                Conn.CallSP("rebuild_epexptotal", new[] { ayear },false,0);
                Conn.CallSP("rebuild_epacctotal", new[] { ayear },false,0);
                Conn.CallSP("rebuild_epexpyear", new[] { ayear },false,0);
                Conn.CallSP("rebuild_epaccyear", new[] { ayear },false,0);
            }
            MessageBox.Show(this, "Epilogo completato con successo!", "Informazione", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return true;

            //string query = null;

            //if (economico) {
            //    // Nel caso dell'Epilogo del Risultato Economico, non dobbiamo valorizzare idaccmotive, idepexp nei dettagli scritture
            //    query = "SELECT -SUM(ED.amount) AS amount, ED.idacc, null as idaccmotive, null as idepexp, " +
            //           " case when flag&2 =0 and flagupb = 'S' then ED.idupb else null end as idupb , " +
            //           " case when flag&1 =0 and flagregistry = 'S' then ED.idreg else null end as idreg  "
            //           + " FROM entrydetail ED "
            //           + " JOIN account ACC "
            //           + " ON " + QHS.CmpEq("ED.idacc", QHS.Field("ACC.idacc"))
            //           + " WHERE " + filter
            //           + " GROUP BY ED.idacc, " 
            //           + " (case when flag&2 =0 and flagupb = 'S' then ED.idupb else null end),"
            //           + " (case when flag&1 =0 and flagregistry = 'S' then ED.idreg else null end)"
            //           + " having SUM(ED.amount)<>0 ";
            //}
            //    // Nell'epilogo dei conti patrimoniali dobbiamo valorizzare idaccmotive(solo se idepexp Ë valorizzato) e idepexp dai dettagli scritture
            //    else {
            //    query = "SELECT -SUM(ED.amount) AS amount, ED.idacc, CASE WHEN (ED.idepexp is not null OR ED.idepacc is not null ) THEN ED.idaccmotive ELSE null END as idaccmotive, " +
            //           " ED.idepexp, ED.idepacc, " +
            //           " case when flag&2 =0 and flagupb = 'S' then ED.idupb else null end as idupb , " +
            //           " case when flag&1 =0 and flagregistry = 'S' then ED.idreg else null end as idreg  "
            //           + " FROM entrydetail ED "
            //           + " JOIN account ACC "
            //           + " ON " + QHS.CmpEq("ED.idacc", QHS.Field("ACC.idacc"))
            //           + " WHERE " + filter
            //           + " GROUP BY ED.idacc,  CASE WHEN (ED.idepexp is not null OR ED.idepacc is not null )  THEN ED.idaccmotive ELSE null END, ED.idepexp, ED.idepacc,"
            //           + " (case when flag&2 =0 and flagupb = 'S' then ED.idupb else null end),"
            //           + " (case when flag&1 =0 and flagregistry = 'S' then ED.idreg else null end)"         
            //               + " having SUM(ED.amount)<>0 ";
            //}

            //DataTable tSaldo = Meta.Conn.SQLRunner(query);

            //if (tSaldo == null) {
            //    MessageBox.Show(this, "Errore nella query che estrae i conti da epilogare", "Errore");
            //    return false;
            //}

            //if (tSaldo.Rows.Count == 0) {
            //    MessageBox.Show(this, "Non ci sono conti del tipo selezionato da epilogare", "Avvertimento");
            //    return true;
            //}

            
            //DataRow rEntry;
            //if (economico) {
            //    rEntry = fillEntry(tEntry, " (conto economico)", 11);
            //}
            //else {
            //    rEntry = fillEntry(tEntry, " (stato patrimoniale)", 12);
            //}
           

            //if (rEntry == null) {
            //    MessageBox.Show(this, "Errore nella creazione della scrittura", "Errore");
            //    return false;
            //}
            //object idaccToUse = economico ? idaccPL : idaccPAT;

            //var useIdReg =
            //    Conn.DO_READ_VALUE("account", QHS.CmpEq("idacc", idaccToUse), "flagregistry")
            //        .ToString()
            //        .ToUpper() == "S";
            //if (useIdReg) {
            //    int flag =
            //        CfgFn.GetNoNullInt32(Conn.DO_READ_VALUE("account", QHS.CmpEq("idacc", idaccToUse),
            //            "flagregistry"));
            //    if ((flag & 1) != 0) useIdReg = false;
            //}
            //var useIdUpb =
            //    Conn.DO_READ_VALUE("account", QHS.CmpEq("idacc", idaccToUse), "flagupb")
            //        .ToString()
            //        .ToUpper() == "S";
            //if (useIdUpb) {
            //    int flag =
            //        CfgFn.GetNoNullInt32(Conn.DO_READ_VALUE("account", QHS.CmpEq("idacc", idaccToUse),
            //            "flagregistry"));
            //    if ((flag & 1) != 0) useIdUpb = false;
            //}

            //bool useIdAccMotive = true;
            //bool useIdEpExp = true;
            //// Nell'Epilogo dei conti economici non dobbiamo valorizzare causale e impegno di budget
            //if (economico) {
            //    useIdAccMotive = false;
            //    useIdEpExp = false;
            //};

            //foreach (DataRow rSaldo in tSaldo.Rows) {
            //    object currIdAcc = rSaldo["idacc"];
            //    if (currIdAcc == idaccToUse) continue;
            //    fillEntryDetail(tEntryDetail, rEntry, rSaldo, useIdAccMotive, useIdEpExp);
            //    fillEntryDetail(tEntryDetail, rEntry, idaccToUse, rSaldo,useIdReg, useIdUpb, useIdAccMotive, useIdEpExp);
            //}

            //DataSet ds = new DataSet();
            //ds.Tables.Add(tEntry);
            //ds.Tables.Add(tEntryDetail);

            //FrmEntryPreSave frm = new FrmEntryPreSave(ds.Tables["entrydetail"], Meta.Conn);
            //DialogResult dr = frm.ShowDialog();
            //if (dr != DialogResult.OK) {
            //    MessageBox.Show(this, "Operazione Annullata!");
            //    return true;
            //}

            //MetaData MetaEntry = MetaData.GetMetaData(this, "entry");
            //PostData Post = MetaEntry.Get_PostData();

            //Post.InitClass(ds, Meta.Conn);
            //if (Post.DO_POST()) {
            //    DataRow rEntryPosted = tEntry.Rows[0];
            //    EditEntry(rEntryPosted);
            //    MessageBox.Show(this, "Epilogo completato con successo!");
            //    doVerify();
            //    return true;
            //}
            //else {
            //    MessageBox.Show(this, "Errore nel salvataggio dell'epilogo", "Errore");
            //    doVerify();
            //    return false;
            //}
            
            
        }

        void EditEntry(DataRow R) {
            if (R == null) return;
            EditRelatedEntryByKey(R);
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

        private DataRow fillEntry(DataTable tEntry, string description, int identrykind) {
            int esercizio = (int)Meta.GetSys("esercizio");
            string filter = QHS.CmpEq("yentry", esercizio);

            object nEntry = Meta.Conn.DO_READ_VALUE("entry", filter, "MAX(nentry)");
            if (nEntry == null) {
                MessageBox.Show(this, "Errore nel calcolo dell'ultima scrittura", "Errore");
                return null;
            }
            int freeN = 1 + CfgFn.GetNoNullInt32(nEntry);

            DataRow rEntry = tEntry.NewRow();
            DateTime dec31 = new DateTime(esercizio, 12, 31);
            rEntry["yentry"] = esercizio;
            rEntry["nentry"] = freeN;
            rEntry["identrykind"] = identrykind;
            rEntry["adate"] = dec31;
            string descr = "Scrittura di epilogo esercizio " + esercizio;
            rEntry["description"] = descr+ description;
            rEntry["ct"] = DateTime.Now;
            rEntry["cu"] = "EPILOGO";
            rEntry["lt"] = DateTime.Now;
            rEntry["lu"] = "'EPILOGO'";
            rEntry["official"] = "S";
            rEntry["locked"] = "N";
            rEntry["idsor01"] = Conn.GetSys("idsor01");
            rEntry["idsor02"] = Conn.GetSys("idsor02");
            rEntry["idsor03"] = Conn.GetSys("idsor03");
            rEntry["idsor04"] = Conn.GetSys("idsor04");
            rEntry["idsor05"] = Conn.GetSys("idsor05");
            tEntry.Rows.Add(rEntry);

            return rEntry;
        }

        private bool fillEntryDetail(DataTable tEntryDetail, DataRow rEntry, DataRow rSaldo, bool useidAccMotive, bool useidEpexp) {
            DataRow rEntryDetail = tEntryDetail.NewRow();
            object nDetMax = tEntryDetail.Rows.Count;              //tEntryDetail.Compute("MAX(ndetail)", null);
            int freeDetail = 1 + CfgFn.GetNoNullInt32(nDetMax);
            rEntryDetail["yentry"] = rEntry["yentry"];
            rEntryDetail["nentry"] = rEntry["nentry"];
            rEntryDetail["ndetail"] = freeDetail;
            rEntryDetail["amount"] = rSaldo["amount"];
            rEntryDetail["idacc"] = rSaldo["idacc"];
            rEntryDetail["idreg"] = rSaldo["idreg"];
            rEntryDetail["idupb"] = rSaldo["idupb"];
           
            if ((rSaldo.Table.Columns.Contains("idepexp")) && (useidEpexp)) {
                rEntryDetail["idepexp"] = rSaldo["idepexp"];
                if ((rSaldo.Table.Columns.Contains("idaccmotive")) && (useidAccMotive)) {
                    rEntryDetail["idaccmotive"] = rSaldo["idaccmotive"];
                }
            }
            if ((rSaldo.Table.Columns.Contains("idepacc")) && (useidEpexp)) {
                rEntryDetail["idepacc"] = rSaldo["idepacc"];
                if ((rSaldo.Table.Columns.Contains("idaccmotive")) && (useidAccMotive)) {
                    rEntryDetail["idaccmotive"] = rSaldo["idaccmotive"];
                }
            }
            rEntryDetail["ct"] = DateTime.Now;
            rEntryDetail["cu"] = "EPILOGO";
            rEntryDetail["lt"] = DateTime.Now;
            rEntryDetail["lu"] = "'EPILOGO'";

            tEntryDetail.Rows.Add(rEntryDetail);
            return true;
        }

        private bool fillEntryDetail(DataTable tEntryDetail, DataRow rEntry, object idacc, DataRow rSaldo, bool useIdReg, bool useidUpb, bool useidAccMotive, bool useidEpexp) {
            decimal amount = CfgFn.GetNoNullDecimal(rSaldo["amount"]);
            DataRow rEntryDetail = tEntryDetail.NewRow();            
            object nDetMax = tEntryDetail.Rows.Count; //tEntryDetail.Compute("MAX(ndetail)", null);
            int freeDetail = 1 + CfgFn.GetNoNullInt32(nDetMax);
            rEntryDetail["yentry"] = rEntry["yentry"];
            rEntryDetail["nentry"] = rEntry["nentry"];
            rEntryDetail["ndetail"] = freeDetail;
            if (useIdReg) {
                rEntryDetail["idreg"] = rSaldo["idreg"];
            }
            if (useidUpb) {
                rEntryDetail["idupb"] = rSaldo["idupb"];
            }
            if ((rSaldo.Table.Columns.Contains("idaccmotive")) && (useidAccMotive)) {
                rEntryDetail["idaccmotive"] = rSaldo["idaccmotive"];
            }

            if ((rSaldo.Table.Columns.Contains("idepexp")) && (useidEpexp)) {
                rEntryDetail["idepexp"] = rSaldo["idepexp"];                         
                rEntryDetail["idaccmotive"] = rSaldo["idaccmotive"];
            }

            if ((rSaldo.Table.Columns.Contains("idepacc")) && (useidEpexp)) {
                rEntryDetail["idepacc"] = rSaldo["idepacc"];
                if ((rSaldo.Table.Columns.Contains("idaccmotive")) && (useidAccMotive)) {
                    rEntryDetail["idaccmotive"] = rSaldo["idaccmotive"];
                }
            }

            rEntryDetail["amount"] = -amount;
            rEntryDetail["idacc"] = idacc;
            rEntryDetail["ct"] = DateTime.Now;
            rEntryDetail["cu"] = "EPILOGO";
            rEntryDetail["lt"] = DateTime.Now;
            rEntryDetail["lu"] = "'EPILOGO'";

            tEntryDetail.Rows.Add(rEntryDetail);
            return true;
        }

        private void btnEpilogoStatoPatrimoniale_Click(object sender, EventArgs e) {
            if (!doEpilogo(false)) {
                MessageBox.Show(this, "Errore nel processo di epilogo", "Errore");
            }

        }

        private void btnRisultatoEconomico_Click(object sender, EventArgs e) {
            if (!doRisultatoEconomico()) {
                MessageBox.Show(this, "Errore nella rilevazione del risultato economico", "Errore");
            }
        }
    }
}