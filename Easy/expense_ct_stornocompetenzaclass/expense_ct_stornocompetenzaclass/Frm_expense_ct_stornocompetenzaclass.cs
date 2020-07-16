/*
    Easy
    Copyright (C) 2020 Università degli Studi di Catania (www.unict.it)
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

﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using metadatalibrary;
using funzioni_configurazione;
using System.Collections;

namespace expense_ct_stornocompetenzaclass {
    public partial class Frm_expense_ct_stornocompetenzaclass :Form {
        MetaData Meta;
        DataAccess Conn;
        public Frm_expense_ct_stornocompetenzaclass() {
            InitializeComponent();
        }
        QueryHelper QHS;
        CQueryHelper QHC;
        string filter_capitolo = "";
        decimal disponibile = 0;
        decimal importoassegnato = 0;
        string descrizione = "";
        object idexp_selezionato = null;
        object curr_idarticolo = null;
        object curr_idupb = null;
        DataTable tClassFase1 = null;
        DataTable tClassFase4 = null;
        DataTable tClassKindFase1 = null;
        public void MetaData_AfterLink() {
            Meta = MetaData.GetMetaData(this);
            Conn = Meta.Conn;
            Meta = MetaData.GetMetaData(this);
            QHC = new CQueryHelper();
            QHS = Meta.Conn.GetQueryHelper();
            Meta.CanInsert = false;
            Meta.CanSave = false;
            Meta.SearchEnabled = false;
            string filterBilancio = QHS.AppAnd(QHS.CmpEq("ayear", Meta.GetSys("esercizio")),
                                        QHS.BitSet("flag", 0)); //finpart=S
            GetData.SetStaticFilter(DS.finview, filterBilancio);
            string filtersercizio = QHS.CmpEq("ayear", Meta.GetSys("esercizio"));
            DataAccess.SetTableForReading(DS.upb_new, "upb");
            object nomefase = Conn.DO_READ_VALUE("expensephase",
                            QHS.CmpEq("nphase", Meta.GetSys("appropriationphase")), "description");
            gboxMovimento.Text = nomefase.ToString() + "(Classificato Provenienza)";
            grpBilancioNew.Enabled = false;
            txtEsercizioMovimento.Text = Meta.GetSys("esercizio").ToString();
        }

        string GetFasePrecFilter(bool FiltraNumMovimento) {
            string ffase = "";
            ffase = QHS.CmpEq("nphase", Meta.GetSys("appropriationphase"));
            string MyFilter = QHS.AppAnd(ffase, QHS.CmpEq("ayear", Meta.GetSys("esercizio")));
            if (txtEsercizioMovimento.Text.Trim() != "")
                MyFilter = QHS.AppAnd(MyFilter, QHS.CmpEq("ymov", txtEsercizioMovimento.Text.Trim()));
            if ((FiltraNumMovimento) && (txtNumeroMovimento.Text.Trim() != ""))
                MyFilter = QHS.AppAnd(MyFilter, QHS.CmpEq("nmov", txtNumeroMovimento.Text.Trim()));

            return MyFilter;
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
        private void btnSelectMov_Click(object sender, EventArgs e) {
            string MyFilter;

            if (((Control)sender).Name == "txtNumeroMovimento")
                MyFilter = GetFasePrecFilter(true);
            else
                MyFilter = GetFasePrecFilter(false);

            MetaData MFase = MetaData.GetMetaData(this, "expense");
            MFase.FilterLocked = true;
            MFase.DS = DS;
            MyFilter = QHS.AppAnd(MyFilter, QHS.CmpGt("available", 0), QHS.CmpEq("flagarrear", "C"));
            int esercizio = (int)Meta.GetSys("esercizio");
            // Solo gli impegni classificati con la Class. PROVENIENZA
            MyFilter = QHS.AppAnd(MyFilter, "  ( select count(S.idexp) from expensesortedview S where S.ymov = "+esercizio + " and S.codesorkind='provenienza' and S.nphase = 1 and S.flagarrear = 'C' and S.IDEXP = expenseview.idexp)>0 ");
            DataRow MyDR = MFase.SelectOne("default", MyFilter, null, null);

            if (MyDR == null) {
                if (Meta.InsertMode) {
                    if (typeof(TextBox).IsAssignableFrom(sender.GetType())) {
                        if (((TextBox)sender).Text.Trim() != "")
                            ((TextBox)sender).Focus();
                    }
                }
                return;
            }
            idexp_selezionato = MyDR["idexp"];
            txtEsercizioMovimento.Text = MyDR["ymov"].ToString();
            txtNumeroMovimento.Text = MyDR["nmov"].ToString();
            txtDescrizione.Text = MyDR["description"].ToString();
            SubEntity_txtImportoMovimento.Text = CfgFn.GetNoNullDecimal(MyDR["amount"]).ToString("c");
            txtCodiceBilancio.Text = MyDR["codefin"].ToString();
            txtDenominazioneBilancio.Text = MyDR["finance"].ToString();
            txtCodeUPB.Text = MyDR["codeupb"].ToString();
            txtDenominazioneUPB.Text = MyDR["upb"].ToString();
            txtImportoCorrente.Text = CfgFn.GetNoNullDecimal(MyDR["curramount"]).ToString("c");
            //ImportoCorrente = CfgFn.GetNoNullDecimal(MyDR["curramount"]);
            txtImportoDisponibile.Text = CfgFn.GetNoNullDecimal(MyDR["available"]).ToString("c");
            disponibile = CfgFn.GetNoNullDecimal(MyDR["available"]);
            importoassegnato = disponibile;
            txtImportoDaStornare.Text = CfgFn.GetNoNullDecimal(MyDR["available"]).ToString("c");
            int fase = CfgFn.GetNoNullInt32(MyDR["nphase"]);
            curr_idarticolo = MyDR["idfin"];
            curr_idupb = MyDR["idupb"];
            filter_capitolo = FiltroPerCapitolo(curr_idarticolo);
            grpBilancioNew.Enabled = true;
        }
        private string FiltroPerCapitolo(object id_articolo) {
            object idfin_capitolo = Conn.DO_READ_VALUE("fin", QHS.CmpEq("idfin", id_articolo), "paridfin");
            filter_capitolo = QHC.AppAnd(QHC.CmpEq("paridfin", idfin_capitolo), QHC.CmpEq("idupb", "0001"));
            return filter_capitolo;
        }

        //Restituisce il tipo classificazione di fase 4 , associata a @idsorkind, ossia al tipo classificazione di fase 1.
        /* Al momento la situazione delle classificazioni è la seguente:
         *7	    COAN_U	    COAN Impegni
         *8	    COAN_U3	    COAN Liquidazioni
         *11	07U_MIUR	MIUR 2007 Spese
         *12	07U_SIOPE	Siope Uscite
         * ove COAN Liquidazioni ha come tipo class. fase precente COAN Impegni
         * mentre in sortingtranslation troviamo
         * 7 master, 11 child
         * 8 master, 12 child
         * */
        private int GetIdSortkindDest(int idsorkind) {
            //Controlla che esiste un tipo Class. avente R1 idsorkind, come class. fase precedente
            /*object f4_idsorkind = Conn.DO_READ_VALUE("sortingkind", QHS.CmpEq("idparentkind", idsorkind), "idsorkind");
            if ((f4_idsorkind != null) && (f4_idsorkind != DBNull.Value)) {
                return CfgFn.GetNoNullInt32(f4_idsorkind);
            }*/
            //Col codice precendete riusciamo a associare  COAN Impegni a COAN Liquidazioni, pa l'associazione MIUR Spese con SIOPE Uscite, diventa troppo ingarbugliata,
            //tanto vale usare i codice per tutte.
            object codesorkindF1 = Conn.DO_READ_VALUE("sortingkind", QHS.CmpEq("idsorkind", idsorkind), "codesorkind");
            if (codesorkindF1.ToString() == "COAN_U") {
                object idsorkind_COANLiquidazioni = Conn.DO_READ_VALUE("sortingkind", QHS.CmpEq("codesorkind", "COAN_U3"), "idsorkind");
                return CfgFn.GetNoNullInt32(idsorkind_COANLiquidazioni);
            }
            if (codesorkindF1.ToString() == "07U_MIUR") {
                object idsorkind_07U_SIOPE = Conn.DO_READ_VALUE("sortingkind", QHS.CmpEq("codesorkind", "07U_SIOPE"), "idsorkind");
                return CfgFn.GetNoNullInt32(idsorkind_07U_SIOPE);
            }
            return 0;
        }

        private void doStorno() {
            Conn.RUN_SELECT_INTO_TABLE(DS.expense, null,
                    QHS.CmpEq("idexp", idexp_selezionato), null, false);
            DataRow Curr = DS.expense.Rows[0];
            MetaData ExpVar = MetaData.GetMetaData(this, "expensevar");
            MetaData ExpSorted = MetaData.GetMetaData(this, "expensesorted");

            MetaData ExpNew = MetaData.GetMetaData(this, "expense");
            MetaData ExpYeayNew = MetaData.GetMetaData(this, "expenseyear");
            MetaData ExpVarNew = MetaData.GetMetaData(this, "expensevar");
            MetaData ExpSortedNew = MetaData.GetMetaData(this, "expensesorted");

            ExpVar.SetDefaults(DS.expensevar);
            ExpSorted.SetDefaults(DS.expensesorted);

            ExpNew.SetDefaults(DS.expense);
            ExpYeayNew.SetDefaults(DS.expenseyear);
            ExpVarNew.SetDefaults(DS.expensevar);
            ExpSortedNew.SetDefaults(DS.expensesorted);

            MetaData.SetDefault(DS.expensevar, "idexp", idexp_selezionato);
            MetaData.SetDefault(DS.expensesorted, "idexp", idexp_selezionato);

            if (txtCodeUPBnew.Text == "") {
                descrizione = "Storno da " + txtCodiceBilancio.Text + " a " + txtCodiceBilancioNew.Text + ".";
            }
            if (txtCodiceBilancioNew.Text == "") {
                descrizione = "Storno da " + txtCodeUPB.Text + " a " + txtCodeUPBnew.Text + ".";
            }
            if ((txtCodeUPBnew.Text != "") && (txtCodiceBilancioNew.Text != "")) {
                descrizione = "Storno da (" + txtCodeUPB.Text + ", " + txtCodiceBilancio.Text + " ) a (" + txtCodeUPBnew.Text + ", " + txtCodiceBilancioNew.Text + ").";
            }

            DataTable dtExpVar = DS.expensevar;
            DataTable dtExpSorted = DS.expensesorted;

            DataTable dtExpNew = DS.expense;
            DataTable dtExpYearNew = DS.expenseyear;
            DataTable dtExpVarNew = DS.expensevar;
            DataTable dtExpSortedNew = DS.expensesorted;

            // Nuova riga in expensevar: crea la variazione in diminuzione al movimento scelto
            DataRow rExpVar = ExpVar.Get_New_Row(Curr, dtExpVar);
            string fltmovS = QHS.CmpEq("idexp", idexp_selezionato);
            object nvar = null;
            if (Conn.RUN_SELECT_COUNT("expensevar", fltmovS, false) > 0) {
                object max_nvar = Conn.DO_READ_VALUE("expensevar", QHS.CmpEq("idexp", idexp_selezionato), "max(nvar)");
                nvar = CfgFn.GetNoNullInt32(max_nvar) + 1;
            }
            else {
                nvar = 1;
            }
            RowChange.ClearAutoIncrement(dtExpVar.Columns["nvar"]);
            rExpVar["nvar"] = nvar;
            rExpVar["yvar"] = Meta.GetSys("esercizio");
            rExpVar["description"] = descrizione;
            rExpVar["amount"] = -(CfgFn.GetNoNullDecimal(HelpForm.GetObjectFromString(typeof(Decimal), txtImportoDaStornare.Text, "x.y.c")));
            rExpVar["autokind"] = 29;// Storno disponibile Impegno Provenienza Competenza(Catania)
            rExpVar["adate"] = Meta.GetSys("datacontabile");

            //Ottengo un DataTable con gli importi di classificazione raggruppati per codice, così non considero la class. parziali
            int esercizio = (int)Meta.GetSys("esercizio");
            string queryF1 = "select es1.idsor, s1.sortcode, s1.idsorkind, sum(es1.amount) as amountsorted "
           + " from expenseview "
           + " join expensesorted es1 on es1.idexp = expenseview.idexp and es1.ayear = expenseview.ayear "
           + " join sorting s1 on s1.idsor = es1.idsor "
           + " where expenseview.idexp  =" + idexp_selezionato
           + " and expenseview.ayear = " + esercizio
           + " group by es1.idsor,  s1.sortcode, s1.idsorkind ";
            tClassFase1 = Meta.Conn.SQLRunner(queryF1);

            string queryF1_sortingkind = "select distinct s1.idsorkind "
           + " from expenseview "
           + " join expensesorted es1 on es1.idexp = expenseview.idexp and es1.ayear = expenseview.ayear "
           + " join sorting s1 on s1.idsor = es1.idsor "
           + " where expenseview.idexp  =" + idexp_selezionato
           + " and expenseview.ayear = " + esercizio;
            tClassKindFase1 = Meta.Conn.SQLRunner(queryF1_sortingkind);

            string queryF4 = "  select s4.sortcode, s4.idsorkind, sum(es4.amount) as amountsorted "
                    + " from expense e1 "
                    + " join expenselink ON expenselink.idparent = e1.idexp "
                    + " join expenselast on expenselast.idexp = expenselink.idchild   "
                    + " join expenseview e4  on expenselast.idexp = e4.idexp "
                    + " join expensesorted es4  on es4.idexp = expenselast.idexp  and es4.ayear = e4.ayear "
                    + " join sorting s4  on s4.idsor = es4.idsor "
                    + " where e1.idexp =  " + idexp_selezionato
                    + " and e4.ayear = " + esercizio
                    + " and (select count(*) "
                                 + " from expensesorted es1 "
                                 + " join sorting s1 on s1.idsor = es1.idsor "
                                 + " where es1.idexp = " + idexp_selezionato + "  and es1.ayear =  " + esercizio + " and s4.sortcode = s1.sortcode)>0 "
                    + " group by s4.sortcode, s4.idsorkind";
            tClassFase4 = Meta.Conn.SQLRunner(queryF4);

            string queryDisponiiblePagare = " select e1.curramount - isnull((select sum(e4.curramount) "
                + "     from expenseview e4 "
                + "     join expenselast on expenselast.idexp = e4.idexp "
                + "     join expenselink on expenselast.idexp = expenselink.idchild "
                + " 	    where expenselink.idparent = e1.idexp and e4.ayear = " + esercizio + " ),0)   as amount"
                + " from expenseview e1 "
                + " where e1.idexp = " + idexp_selezionato + " and e1.ayear =   " + esercizio;
            DataTable tDisponibileAPagare = Meta.Conn.SQLRunner(queryDisponiiblePagare);
            decimal disponibileAPagare = 0;
            if (tDisponibileAPagare.Select().Length > 0) {
                DataRow R = tDisponibileAPagare.Select()[0];
                disponibileAPagare = CfgFn.GetNoNullDecimal(R["amount"]);
            }
            //RiempiExpSorted(ExpSorted, Curr, dtExpSorted, -1, importoassegnato, disponibileAPagare);
            //Cicla per ogni tipo classificazione di Fase 1
            foreach (DataRow Rsortkind in tClassKindFase1.Select()) {
                int idsorkindF1 = CfgFn.GetNoNullInt32(Rsortkind["idsorkind"]);
                int idsorkindF4 = GetIdSortkindDest(idsorkindF1);
                if (idsorkindF4 != 0) {
                    RiempiExpSorted(ExpSorted, Curr, dtExpSorted, -1, importoassegnato, disponibileAPagare, idsorkindF1, idsorkindF4);
                }
                else {
                    RiempiExpSorted(ExpSorted, Curr, dtExpSorted, -1, importoassegnato, disponibileAPagare, idsorkindF1, idsorkindF1);
                }

            }
            // Nuova riga di EXPENSE NEW
            Hashtable saveddefaults_ExpNew = new Hashtable();
            foreach (DataColumn C in dtExpNew.Columns) {
                saveddefaults_ExpNew[C.ColumnName] = C.DefaultValue;
            }

            string descrizionenewexpense_completa = "(ex imp.N." + Curr["nmov"] + "/Eserc." + Curr["ymov"] + ") " + Curr["description"];
            string descrizionenewexpense = "";
            if (descrizionenewexpense_completa.Length > 150) {
                descrizionenewexpense = descrizionenewexpense_completa.Substring(1, 150);
            }
            else {
                descrizionenewexpense = descrizionenewexpense_completa;
            }
            MetaData.SetDefault(dtExpNew, "nphase", 1);
            //DateTime datacontabile = new DateTime(CfgFn.GetNoNullInt32(Curr["ymov"]), 12, 31);
            MetaData.SetDefault(dtExpNew, "ymov", Curr["ymov"]);
            MetaData.SetDefault(dtExpNew, "adate", Meta.GetSys("datacontabile"));
            MetaData.SetDefault(dtExpNew, "description", descrizionenewexpense);
            MetaData.SetDefault(dtExpNew, "docdate", Curr["docdate"]);
            MetaData.SetDefault(dtExpNew, "paridexp", Curr["idexp"]);
            DataRow rNewExp = ExpNew.Get_New_Row(null, dtExpNew);
            int idexp = CfgFn.GetNoNullInt32(rNewExp["idexp"]);
            if (idexp < 10000000)
                idexp = 10000000;
            rNewExp["idexp"] = idexp;

            foreach (DataColumn CC in dtExpNew.Columns) {
                CC.DefaultValue = saveddefaults_ExpNew[CC.ColumnName];
            }

            // Nuova riga in expenseyear: crea la riga di imputazione del nuovo movimento creato
            Hashtable saveddefaults_ExpYearNew = new Hashtable();
            foreach (DataColumn C in dtExpYearNew.Columns) {
                saveddefaults_ExpYearNew[C.ColumnName] = C.DefaultValue;
            }
            object new_idarticolo = curr_idarticolo;
            object new_idupb = curr_idupb;
            if (txtCodeUPBnew.Text != "") {
                new_idupb = Conn.DO_READ_VALUE("upb", QHS.CmpEq("codeupb", txtCodeUPBnew.Text.ToString()), "idupb");
            }
            if (txtCodiceBilancioNew.Text != "") {
                new_idarticolo = Conn.DO_READ_VALUE("fin", QHS.AppAnd(QHS.CmpEq("codefin", txtCodiceBilancioNew.Text.ToString()),
                                QHS.CmpEq("ayear", Meta.GetSys("esercizio")), QHS.BitSet("flag", 0)), "idfin");
            }
            MetaData.SetDefault(dtExpYearNew, "amount", 0);
            MetaData.SetDefault(dtExpYearNew, "ayear", Meta.GetSys("esercizio"));
            MetaData.SetDefault(dtExpYearNew, "idfin", new_idarticolo);
            MetaData.SetDefault(dtExpYearNew, "idupb", new_idupb);
            MetaData.SetDefault(dtExpYearNew, "idexp", idexp);
            DataRow rExpyearNew = ExpYeayNew.Get_New_Row(rNewExp, dtExpYearNew);

            foreach (DataColumn CC in dtExpYearNew.Columns) {
                CC.DefaultValue = saveddefaults_ExpYearNew[CC.ColumnName];
            }

            // Nuova riga in expensevar: crea la variazione in aumento al movimento creato
            DataRow rExpVarNew = ExpVarNew.Get_New_Row(rNewExp, dtExpVarNew);
            RowChange.ClearAutoIncrement(dtExpVarNew.Columns["nvar"]);
            rExpVarNew["nvar"] = 1;
            rExpVarNew["yvar"] = Meta.GetSys("esercizio");
            rExpVarNew["description"] = descrizione;
            rExpVarNew["amount"] = CfgFn.GetNoNullDecimal(HelpForm.GetObjectFromString(typeof(Decimal), txtImportoDaStornare.Text, "x.y.c"));
            rExpVarNew["autokind"] = 29;//Storno disponibile Impegno Provenienza Competenza(Catania)
            rExpVarNew["adate"] = Meta.GetSys("datacontabile");
            rExpVarNew["idpayment"] = idexp_selezionato;

            // Nuove righe in expensesorted: crea le classificazioni per il movimento creato
            foreach (DataRow Rsortkind in tClassKindFase1.Select()) {
                int idsorkindF1 = CfgFn.GetNoNullInt32(Rsortkind["idsorkind"]);
                int idsorkindF4 = GetIdSortkindDest(idsorkindF1);
                if (idsorkindF4 != 0) {
                    RiempiExpSorted(ExpSortedNew, rNewExp, dtExpSortedNew, +1, importoassegnato, disponibileAPagare, idsorkindF1, idsorkindF4);
                }
                else {
                    RiempiExpSorted(ExpSortedNew, rNewExp, dtExpSortedNew, +1, importoassegnato, disponibileAPagare, idsorkindF1, idsorkindF1);
                }
            }

            //Effettua il post
            PostData Post = Meta.Get_PostData();
            Post.InitClass(DS, Conn);
            bool res = Post.DO_POST();
            if (res) {
                object nomefase = Conn.DO_READ_VALUE("expensephase", QHS.CmpEq("nphase", Meta.GetSys("appropriationphase")), "description");
                string mess = "Operazione Eseguita con successo.\r\n"
                        + "E' stato creato il movimento " + nomefase.ToString() + " Eserc." + Curr["ymov"] + " N." + rNewExp["nmov"] + ".";
                MessageBox.Show(mess);
                btnEsegui.Visible = false;
                btnAnnulla.Text = "Chiudi";
            }
            else {
                DS.expense.Clear();
                DS.expensevar.Clear();
                DS.expensesorted.Clear();
                DS.expenseyear.Clear();
                return;
            }
        }

        private void RiempiExpSorted(MetaData M, DataRow ParentRow, DataTable Currdt, int segno,
            decimal importoVariatoOriginale, decimal disponibileAPagareOriginale, int idsorkindF1, int idsorkindF4) {
            string filterCodClass = "";
            DataTable tExpensesorted = Conn.RUN_SELECT("expensesorted", "*", null, QHS.CmpEq("idexp", idexp_selezionato),
                null, false);
            //Cicla per ogni tipo classificazione di Fase 1
            //foreach (DataRow Rsortkind in tClassKindFase1.Select()) {
            decimal disponibileAPagare = disponibileAPagareOriginale;
            decimal importoVariato = importoVariatoOriginale;
            foreach (DataRow R1 in tClassFase1.Select(QHC.CmpEq("idsorkind", idsorkindF1))) {
                if (disponibileAPagare == 0) return;
                //idsorkind = CfgFn.GetNoNullInt32(R1["idsorkind"]);
                DataRow rExpSorted = M.Get_New_Row(ParentRow, Currdt);
                filterCodClass = QHC.AppAnd(QHC.CmpEq("idsorkind", idsorkindF4), QHC.CmpEq("sortcode", R1["sortcode"]));
                //Se esiste un pagamento con lo stesso codice di classificazione, allora il nuovo importo viee calcolato in base ad esso
                decimal importoClassificato;
                decimal importoDaConsiderare;

                if (tClassFase4.Select(filterCodClass).Length > 0) {
                    DataRow R4 = tClassFase4.Select(filterCodClass)[0];
                    //Nuovo importo classificazione Ci-esimo= (Ci Fase1 - Ci Fase4)* disponibile Fase 1 / (Imp.Corrente F1-Imp.CorrenteF4)
                    importoDaConsiderare = CfgFn.GetNoNullDecimal(R1["amountsorted"]) -
                                           CfgFn.GetNoNullDecimal(R4["amountsorted"]);
                    importoClassificato = segno * importoDaConsiderare * importoVariato / disponibileAPagare;
                }
                else {
                    importoDaConsiderare = CfgFn.GetNoNullDecimal(R1["amountsorted"]);
                    importoClassificato = segno * importoDaConsiderare * importoVariato / disponibileAPagare;
                }


                rExpSorted["amount"] = importoClassificato;
                importoVariato -= segno * importoClassificato;
                disponibileAPagare -= importoDaConsiderare;

                int idsubclass = tExpensesorted.Select(QHC.CmpEq("idsor", R1["idsor"])).Length + 1;
                rExpSorted["idsubclass"] = idsubclass;
                rExpSorted["idexp"] = ParentRow["idexp"];
                rExpSorted["ayear"] = Meta.GetSys("esercizio");
                rExpSorted["description"] = descrizione;
                rExpSorted["idsor"] = R1["idsor"];
            }

            //}
        }

        void ClearMovimento() {
            idexp_selezionato = null;
            txtNumeroMovimento.Text = "";
            txtEsercizioMovimento.Text = "";
            txtDescrizione.Text = "";
            SubEntity_txtImportoMovimento.Text = "";
            txtCodiceBilancio.Text = "";
            txtDenominazioneBilancio.Text = "";
            txtCodeUPB.Text = "";
            txtDenominazioneUPB.Text = "";
            txtImportoCorrente.Text = "";
            txtImportoDisponibile.Text = "";
        }
        private void txtNumeroMovimento_Leave(object sender, EventArgs e) {
            int NMov = CfgFn.GetNoNullInt32(txtNumeroMovimento.Text);
            if (NMov <= 0) {
                ClearMovimento();
                return;
            }
            if (txtEsercizioMovimento.Text.Trim() != "") {
                btnSelectMov_Click(sender, e);
                return;
            }
        }

        private void btnBilancio_Click(object sender, EventArgs e) {
            //filter_capitolo lo ha determinato in FiltroPerCapitolo (), dopo aver scelto il movimento
            string allfilter = QHC.AppAnd(filter_capitolo, QHC.CmpEq("idupb", "0001"));
            MetaData.DoMainCommand(this, "choose.finview.manager." + allfilter);

        }

        private void txtCodiceBilancioNew_Leave(object sender, EventArgs e) {
            //if (txtCodiceBilancioNew.Text == "") {
            //    txtDenominazioneBil.Text = "";
            //}
            //else {
            //    string allfilter = QHC.AppAnd(filter_capitolo, QHC.CmpEq("idupb", "0001"));
            //    allfilter = QHC.AppAnd(allfilter, QHC.Like("codefin", txtCodiceBilancioNew.Text + "%"));
            //    MetaData.DoMainCommand(this, "choose.finview.manager." + allfilter);
            //}

            if (txtCodiceBilancioNew.Text == "") {
                txtDenominazioneBil.Text = "";
                return;
            }
            string allfilter = QHC.AppAnd(filter_capitolo, QHC.CmpEq("idupb", "0001"));
            allfilter = QHC.AppAnd(allfilter, QHC.Like("codefin", txtCodiceBilancioNew.Text + "%"));

            MetaData MBilancio = MetaData.GetMetaData(this, "finview");
            MBilancio.FilterLocked = true;
            MBilancio.DS = DS.Clone();

            DataRow Choosen = MBilancio.SelectOne("articolifratelli", allfilter, "finview", null);
            if (Choosen == null) {
                txtCodiceBilancioNew.Focus();
                return;
            }
            txtCodiceBilancioNew.Text = Choosen["codefin"].ToString();
            txtDenominazioneBil.Text = Choosen["title"].ToString();
        }

        private void btnEsegui_Click(object sender, EventArgs e) {
            if (idexp_selezionato == null) {
                MessageBox.Show("Selezionare un movimento.");
                return;
            }
            if ((txtCodeUPBnew.Text == "") && (txtCodiceBilancioNew.Text == "")) {
                MessageBox.Show("Indicare una U.P.B o una voce di Bilancio");
                return;
            }
            doStorno();
        }

        private void txtImportoDaStornare_Leave(object sender, EventArgs e) {
            //Controlla che l'importo indicato, sia compreso tra 0 e il disponibile.
            importoassegnato = CfgFn.GetNoNullDecimal(HelpForm.GetObjectFromString(typeof(Decimal), txtImportoDaStornare.Text, "x.y.c"));
            if ((importoassegnato > disponibile) || (importoassegnato <= 0)) {
                MessageBox.Show("L'importo da stornare deve essere compreso tra 0 il disponibile del movimento scelto.");
            }
        }
    }
}
