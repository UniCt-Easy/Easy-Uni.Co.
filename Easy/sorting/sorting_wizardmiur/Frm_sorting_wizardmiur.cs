
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

namespace sorting_wizardmiur {
    public partial class Frm_sorting_wizardmiur : MetaDataForm {
        DataTable dataTableExpenseOrIncome;
        DataTable dataTableExpensesortedOrIncomesorted;
        string tabellaEntrataOSpesa;
        string chiaveEntrataOSpesa;
        object vecchiaClassificazione;
        object nuovaClassificazione;

        object codFaseImpegno;
        MetaData Meta;
        string CustomTitle;

        public Frm_sorting_wizardmiur() {
            InitializeComponent();
            this.tabController.HideTabsMode = Crownwood.Magic.Controls.TabControl.HideTabsModes.HideAlways;
        }
        QueryHelper QHS;
        CQueryHelper QHC;
        DataAccess Conn;
        int esercizio;
        public void MetaData_AfterLink() {
            Meta = MetaData.GetMetaData(this);
            Meta.CanInsert = false;
            Meta.CanSave = false;
            Meta.SearchEnabled = false;
            Conn = Meta.Conn;
            QHC= new CQueryHelper();
            QHS = Meta.Conn.GetQueryHelper();
            string filterfinpart = null;

           
            esercizio = (int)Meta.GetSys("esercizio");
            if (Meta.ExtraParameter == null) Meta.ExtraParameter = "SIOPE_SPESA";

            switch (Meta.ExtraParameter.ToString()) {
                case "SIOPE_SPESA": 
                    //tipoForm = TipoForm.SIOPE_SPESA;
                    dataTableExpenseOrIncome = DS.expenseview;
                    dataTableExpensesortedOrIncomesorted = DS.expensesorted;
                    tabellaEntrataOSpesa = "expense";
                    chiaveEntrataOSpesa = "idexp";
                    vecchiaClassificazione = esercizio<2007 
                        ? Meta.Conn.DO_READ_VALUE("sortingkind", QHS.CmpEq("codesorkind", "SIOPE"), "idsorkind") 
                        : Meta.Conn.DO_READ_VALUE("sortingkind", QHS.CmpEq("codesorkind", "07U_SIOPE"), "idsorkind");
                    nuovaClassificazione = esercizio<2007
                        ? Meta.Conn.DO_READ_VALUE("sortingkind", QHS.CmpEq("codesorkind", "06_MIUR"), "idsorkind")
                        : Meta.Conn.DO_READ_VALUE("sortingkind", QHS.CmpEq("codesorkind", "07U_MIUR"), "idsorkind");
                    codFaseImpegno = Meta.Conn.DO_READ_VALUE("sortingkind",
                        QHS.CmpEq("idsorkind",nuovaClassificazione), "nphaseexpense");
                    filterfinpart = QHS.CmpEq("finpart", "S");
                    break;
                case "SIOPE_ENTRATA": 
                    //tipoForm = TipoForm.SIOPE_ENTRATA;
                    dataTableExpenseOrIncome = DS.incomeview;
                    dataTableExpensesortedOrIncomesorted = DS.incomesorted;
                    tabellaEntrataOSpesa = "income";
                    chiaveEntrataOSpesa = "idinc";
                    vecchiaClassificazione = esercizio < 2007
                        ? Meta.Conn.DO_READ_VALUE("sortingkind", QHS.CmpEq("codesorkind", "SIOPE"), "idsorkind")
                        : Meta.Conn.DO_READ_VALUE("sortingkind", QHS.CmpEq("codesorkind", "07E_SIOPE"), "idsorkind");
                    nuovaClassificazione = esercizio < 2007
                        ? Meta.Conn.DO_READ_VALUE("sortingkind", QHS.CmpEq("codesorkind", "06_MIUR"), "idsorkind")
                        : Meta.Conn.DO_READ_VALUE("sortingkind", QHS.CmpEq("codesorkind", "07E_MIUR"), "idsorkind");
                    codFaseImpegno = Meta.Conn.DO_READ_VALUE("sortingkind",
                            QHS.CmpEq("idsorkind", nuovaClassificazione), "nphaseincome");
                    filterfinpart = QHS.CmpEq("finpart", "E"); break;
                case "FUNZIONI_SPESA":
                    object miurFunz1 = getMiurFunz();
                    //tipoForm = TipoForm.FUNZIONI_SPESA;
                    dataTableExpenseOrIncome = DS.expenseview;
                    dataTableExpensesortedOrIncomesorted = DS.expensesorted;
                    tabellaEntrataOSpesa = "expense";
                    chiaveEntrataOSpesa = "idexp";
                    vecchiaClassificazione = miurFunz1;
                    nuovaClassificazione = Meta.Conn.DO_READ_VALUE("sortingkind", QHS.CmpEq("codesorkind", "07_MIURFUNZ"), "idsorkind");
                    codFaseImpegno = Meta.Conn.DO_READ_VALUE("sortingkind",
                        QHS.CmpEq("idsorkind", nuovaClassificazione), "nphaseexpense");
                    filterfinpart = QHS.CmpEq("finpart", "S");
                    break;
                case "FUNZIONI_ENTRATA":
                    object miurFunz2 = getMiurFunz();
                    //tipoForm = TipoForm.FUNZIONI_ENTRATA;
                    dataTableExpenseOrIncome = DS.incomeview;
                    dataTableExpensesortedOrIncomesorted = DS.incomesorted;
                    tabellaEntrataOSpesa = "income";
                    chiaveEntrataOSpesa = "idinc";
                    vecchiaClassificazione = miurFunz2;
                    nuovaClassificazione = Meta.Conn.DO_READ_VALUE("sortingkind", QHS.CmpEq("codesorkind", "07_MIURFUNZ"), "idsorkind");
                    codFaseImpegno = Meta.Conn.DO_READ_VALUE("sortingkind",
                        QHS.CmpEq("idsorkind", nuovaClassificazione), "nphaseincome");
                    filterfinpart = QHS.CmpEq("finpart", "E");
                    break;
            }
            CustomTitle = "Da '"
                + Meta.Conn.DO_READ_VALUE("sortingkind", QHS.CmpEq("idsorkind", vecchiaClassificazione), "description")
                + "' a '"
                + Meta.Conn.DO_READ_VALUE("sortingkind", QHS.CmpEq("idsorkind", nuovaClassificazione), "description")
                + "' su "
                + Meta.Conn.DO_READ_VALUE(tabellaEntrataOSpesa + "phase", QHS.CmpEq("nphase", codFaseImpegno), "description");
            Meta.Name = Text = CustomTitle + " (Pagina 1 di " + tabController.TabPages.Count + ")";
            descriviColonneExpenseview();
            descriviColonneExpensesorted();

            if (tabellaEntrataOSpesa == "income") {
                this.chkTotPagati.Text = "Movimenti totalmente incassati (da classificare in base ai codici siope imputati in " +
                             "ultima fase)";
                this.rbtSoloSiope.Text = "Il movimento sarà classificato solo per l\'importo già incassato";
                this.chkNonPagati.Text = "Movimenti non incassati (da classificare in base ai codici siope sulla voce di bilan" +
    "cio)";
                this.rbtSiopeEBilancio.Text = "Il movimento sarà interamente classificato (in base ai codici siope in ultima fas" +
                    "e per l\'importo incassato ed in base alla voce di bilancio per la parte rimanente)";

                this.chkAnniSuccessivi.Text = "Trasferisci  anche le classificazioni effettuate sugli incassi degli anni success" +
         "ivi a quello corrente";
                this.chkParzPagati.Text = "Movimenti parzialmente incassati";

            }
            GetData.SetStaticFilter(DS.finview, QHS.AppAnd(QHS.CmpEq("ayear", esercizio),filterfinpart));
        }

        private object getMiurFunz() {
            object objMiurFunz = Meta.Conn.DO_READ_VALUE("miursetup", QHS.CmpEq("internalcode","MIURFUNZ"),
                "sortcode");
            if (objMiurFunz!=null) return objMiurFunz;

            objMiurFunz = Meta.Conn.DO_READ_VALUE("miursetup",QHS.CmpEq("internalcode","FUNZ"), "sortcode");
            if (objMiurFunz!=null) return objMiurFunz;

            objMiurFunz = Meta.Conn.DO_READ_VALUE("sortingkind", QHS.CmpEq("codesorkind", "MIURFUNZ"), "idsorkind");
            if (objMiurFunz != null) return objMiurFunz;

            objMiurFunz = Meta.Conn.DO_READ_VALUE("sortingkind", QHS.CmpEq("codesorkind", "FUNZ"), "idsorkind");
            if (objMiurFunz != null) return objMiurFunz;

            Cursor = null;
            show(this, "Impossibile trovare il codice della FUNZIONE MIUR");

            return null;
        }

        private void btnUPBCode_Click(object sender, EventArgs e) {
            if (!Meta.InsertMode) {
                Meta.DoMainCommand("manage.upb.tree");
                return;
            }
            string filter = QHS.AppAnd(QHS.CmpEq("active","S"),QHS.CmpEq("ayear",esercizio));
            MetaData MetaUpb = MetaData.GetMetaData(this, "upbyearview");
            MetaUpb.DS = new DataSet();
            MetaUpb.linkedForm = this;
            MetaUpb.FilterLocked = true;
            DataRow Upb = MetaUpb.SelectOne(tabellaEntrataOSpesa, filter, "upbyearview", null);
            if (Upb == null) return;
            object idupb = Upb["idupb"];
            HelpForm.SetComboBoxValue(SubEntity_comboUPB, idupb);

            //Resto della gestione in AfterRowSelect di upbyearview
        }

        private void btnBilancio_Click(object sender, EventArgs e) {
            string filter = "";

            int esercizio = (int)Meta.GetSys("esercizio");
            string filteridfin;
            if (tabellaEntrataOSpesa=="expense")
                filteridfin= QHS.AppAnd(QHS.CmpEq("ayear", esercizio), QHS.BitSet("flag", 0));
            else
                filteridfin = QHS.AppAnd(QHS.CmpEq("ayear", esercizio), QHS.BitClear("flag", 0));

            //Il filtro sull'UPB c'è sempre a meno che non ricerco per responsabile!!!
                if (SubEntity_comboUPB.SelectedIndex > 0) {
                    filter = QHS.CmpEq("idupb", SubEntity_comboUPB.SelectedValue);
                }
                else {
                    filter = QHS.CmpEq("idupb", "0001");
                }
            filter = GetData.MergeFilters(filteridfin, filter);
            string filteroperativo = QHS.FieldInList("idfin",
                "SELECT idfin from finusable where " + QHS.CmpEq("ayear",esercizio));
            DS.finview.ExtendedProperties[MetaData.ExtraParams] = filter;
            MetaData.DoMainCommand(this, "manage.finview.treesupb");
        }
        #region Gestione Tabs

        /// <summary>
        /// Displays tab n. NewTab and updates buttons
        /// </summary>
        /// <param name="newTab"></param>
        void DisplayTabs(int newTab) {
            tabController.SelectedIndex = newTab;
            //Evaluates Buttons Appearance
            btnBack.Visible = (newTab > 0);
            if (newTab == tabController.TabPages.Count - 1)
                btnNext.Text = "Esegui.";
            else
                btnNext.Text = "Avanti >";
            Text = CustomTitle + " (Pagina " + (newTab + 1) + " di " + tabController.TabPages.Count + ")";
        }
        void StandardChangeTab(int step) {
            int oldTab = tabController.SelectedIndex;
            int newTab = oldTab + step;
            if ((newTab < 0) || (newTab > tabController.TabPages.Count)) return;
            if (!CustomChangeTab(oldTab, newTab)) return;
            if (newTab == tabController.TabPages.Count) {
                Cursor = null;
                if (show(this, "Si desidera eseguire ancora la procedura",
                    "Conferma", MessageBoxButtons.YesNo) == DialogResult.Yes) {
                    newTab = 1;
                    ResetWizard();
                }
                else {
                    DialogResult = DialogResult.OK;
                    Close();
                    return;
                }
            }
            if ((oldTab == 4) && (newTab == 3)) {
                newTab = 1;
                ResetWizard();
            }
            DisplayTabs(newTab);
        }

        bool CustomChangeTab(int oldTab, int newTab) {
            if (oldTab == 0) {
                return true; // 0->1: nothing to do
            }
            if ((oldTab == 1) && (newTab == 0)) return true; //1->0:nothing to do!
            if ((oldTab == 1) && (newTab == 2)) {
                Cursor = Cursors.WaitCursor;
                Application.DoEvents();
                dataTableExpenseOrIncome.Clear();
                string filtroImpegni = getFiltroSugliImpegni();
                DataAccess.RUN_SELECT_INTO_TABLE(Meta.Conn, dataTableExpenseOrIncome, null, filtroImpegni, null, false);

                string filtroClassif = QueryCreator.ColumnValues(dataTableExpenseOrIncome, null, chiaveEntrataOSpesa, true);
                string query = "";
                if (filtroClassif != "") {
                    if (!chkAnniSuccessivi.Checked) {
                        query = "select idexp=expenselink.idparent, amount=sum(amount) "
                           + "from expensesorted "
                           + "join expenselink on expenselink.idparent in ("
                           + filtroClassif
                           + ") and expenselink.idchild = expensesorted.idexp "
                           + "join sorting on sorting.idsor = expensesorted.idsor where "
                           + QHS.AppAnd(QHS.CmpEq("ayear", Meta.GetSys("esercizio")),
                           QHS.CmpEq("idsorkind", vecchiaClassificazione))
                           + " group by expenselink.idparent";
                    }
                    else {
                        query = "select idexp=expenselink.idparent, amount=sum(amount) "
                         + "from expensesorted "
                         + "join expenselink on expenselink.idparent in ("
                         + filtroClassif
                         + ") and expenselink.idchild = expensesorted.idexp "
                         + "join sorting on sorting.idsor = expensesorted.idsor where "
                         + QHS.AppAnd(QHS.CmpGe("ayear",Meta.GetSys("esercizio")),
                         QHS.CmpEq("idsorkind",vecchiaClassificazione),
                         QHS.NullOrLe("sorting.start",Meta.GetSys("esercizio")))
                         + " group by expenselink.idparent";
                    }

                    if (tabellaEntrataOSpesa == "income") {
                        query = query.Replace("expense", "income").Replace("idexp", "idinc");
                    }

                    DataTable t = Meta.Conn.SQLRunner(query);

                    foreach (DataRow rExp in dataTableExpenseOrIncome.Rows) {
                        DataRow[] r = t.Select(chiaveEntrataOSpesa+"='"+rExp[chiaveEntrataOSpesa]+"'");
                        rExp["!sortedamount"] = (r.Length > 0) ? r[0]["amount"] : 0;
                        decimal currAmount = (decimal)rExp["curramount"];
                        decimal sortedAmount = (decimal)rExp["!sortedamount"];
                        rExp["!notsortedamount"] = currAmount - sortedAmount;
                        rExp["!howmuchsorted"] = sortedAmount == currAmount ? "Totale"
                            : sortedAmount == 0 ? "Non classificato" : "Parziale";
                    }
                }
                HelpForm.SetDataGrid(gridImpegni, dataTableExpenseOrIncome);
                selezionaTutto();
                Cursor = null;
                return true;
            }
            if ((oldTab == 2) && (newTab == 1)) {
                return true;
            };
            if ((oldTab == 2) && (newTab == 3)) {
                Cursor = Cursors.WaitCursor;
                Application.DoEvents();
                CurrencyManager cm = (CurrencyManager)gridImpegni.BindingContext[DS, gridImpegni.DataMember];
                DataView view = cm.List as DataView;
                if (view != null) {
                    bool ok = creaNuoveClassificazioni(view);
                    Cursor = null;
                    return ok;
                }
                return true;
            }
            if ((oldTab == 3) && (newTab == 4)) {
                if (dataTableExpensesortedOrIncomesorted.Rows.Count == 0) {
                    show(this, "Nessuna nuova classificazione inserita.");
                    return true;
                }
                PostData post = Meta.Get_PostData();
                post.InitClass(DS, Meta.Conn);
                bool res = post.DO_POST();
                if (res) {
                    show("Aggiunta delle classificazioni eseguita con successo.");
                }
                return res;
            }
            if ((oldTab == 4) && (newTab == 5)) {
                return true;
            }
            return true;
        }

        #endregion

        private string getFiltroIn(string nomeCampo, List<int> lista) {
            IEnumerator<int> enumerator = lista.GetEnumerator();
            if (!enumerator.MoveNext()) return "(0=1)";
            string elenco = "(" + nomeCampo + " in (" + QHS.quote(enumerator.Current);
            while (enumerator.MoveNext()) {
                elenco += "," + enumerator.Current;
            }
            return elenco + "))";
        }

        private bool creaNuoveClassificazioni(DataView view) {
            dataTableExpensesortedOrIncomesorted.Clear();
            List<int> listaSpese = new List<int>();
            List<int> listaBilanci = new List<int>();

            for (int i = 0; i < view.Count; i++) {
                if (gridImpegni.IsSelected(i)) {
                    listaSpese.Add((int)view[i][chiaveEntrataOSpesa]);
                    decimal sortedAmount = (decimal)view[i]["!sortedamount"];
                    decimal currAmount = (decimal)view[i]["curramount"];
                    if ((((sortedAmount<currAmount) && rbtSiopeEBilancio.Checked
                        || (sortedAmount == 0))&&(view[i]["idfin"] != DBNull.Value))
                        && !listaBilanci.Contains((int)view[i]["idfin"]))
                    {
                        listaBilanci.Add((int)view[i]["idfin"]);
                    }
                }
            }

            string queryMovSorted = "";
            if (!chkAnniSuccessivi.Checked) {
                queryMovSorted = "select newidsor=s2.idsor, newsortcode=s2.sortcode, newsorting=s2.description, expensesorted.*, idparent from expensesorted "
                     + "join expenselink on expenselink.idchild = expensesorted.idexp "
                     + "join sorting s1 on s1.idsor = expensesorted.idsor and s1.idsorkind="
                     + QHS.quote(vecchiaClassificazione)
                     + "join sorting s2 on s1.sortcode = s2.sortcode and s2.idsorkind="
                     + QHS.quote(nuovaClassificazione)
                     + " where  "
                     + QHS.CmpEq("ayear", Meta.GetSys("esercizio"))
                     + " and "
                     + getFiltroIn("idparent", listaSpese);
                 
            }
            else {
                queryMovSorted = "select newidsor=s2.idsor, newsortcode=s2.sortcode, newsorting=s2.description, expensesorted.*, idparent from expensesorted "
                      + "join expenselink on expenselink.idchild = expensesorted.idexp "
                      + "join sorting s1 on s1.idsor = expensesorted.idsor and s1.idsorkind="
                      + QHS.quote(vecchiaClassificazione)
                      + " join sorting s2 on s1.sortcode = s2.sortcode and s2.idsorkind="
                      + QHS.quote(nuovaClassificazione)
                      + " where  "
                      + QHS.AppAnd(QHS.CmpGe("ayear", Meta.GetSys("esercizio")),
                        QHS.NullOrGe("s1.start", Meta.GetSys("esercizio")))
                      + " and "
                      + getFiltroIn("idparent", listaSpese);
                 
            }
            if (tabellaEntrataOSpesa == "income") {
                queryMovSorted = queryMovSorted.Replace("expense", "income").Replace("idexp", "idinc");
            }
            DataTable tMovSorted = Meta.Conn.SQLRunner(queryMovSorted);
            tMovSorted.Columns["idsor"].ColumnName = "oldidsor";

            DataTable tFinLink = Meta.Conn.RUN_SELECT("finlink", null, null, getFiltroIn("idchild", listaBilanci), null, true);

            string queryFinSorting = "select * from finsorting "
                + "join sorting on sorting.idsor = finsorting.idsor where "
                + QHS.AppAnd(QHS.CmpEq("idsorkind", vecchiaClassificazione),//era vecchiaClassificazione
                    QHS.FieldIn("idparent", tFinLink.Select()).Replace("idparent","idfin"));
            DataTable tFinSorting = Meta.Conn.SQLRunner(queryFinSorting);

            copiaClassificazioniEsistenti(tMovSorted);

            FrmMeter FM2 = new FrmMeter("Imputazione della Classificazione");

            FM2.pBar.Maximum = view.Count;
            FM2.Show();
            Cursor.Current = Cursors.WaitCursor;

            for (int i = 0; i < view.Count; i++) {
                
                FM2.pBar.Increment(1);
                if ((i % 10) == 0) {
                    Application.DoEvents();
                }

                if (gridImpegni.IsSelected(i)) {
                    decimal sortedAmount = (decimal)view[i]["!sortedamount"];
                    object objAmount = tMovSorted.Compute("sum(amount)", 
                        QHS.CmpEq("idparent", view[i][chiaveEntrataOSpesa]));
                    decimal sumAmount = objAmount == DBNull.Value ? 0 : (decimal)objAmount;
                    decimal currAmount = (decimal)view[i]["curramount"];
                    if (sumAmount != sortedAmount) {
                        Cursor = null;
                        show(this, "Errore interno: "
                            + chiaveEntrataOSpesa +"='" + view[i][chiaveEntrataOSpesa] 
                            + "'; sortedAmount=" + sortedAmount 
                            + "; objAmount=" + objAmount);
                    }
                    if ((sortedAmount<currAmount)&& rbtSiopeEBilancio.Checked || (sortedAmount == 0)) 
                    {
                        classificaInBaseAlBilancio(tFinLink, tFinSorting, view[i]);
                    }
                    if ((sortedAmount < currAmount) && rbtProporzione.Checked) {
                        proporzionaClassificazioniEsistenti(view[i][chiaveEntrataOSpesa], currAmount);
                    }
                }
            }

            Cursor.Current = Cursors.Default;
            FM2.Close();

            if (!correggiArrotondamenti(listaSpese)) {
                return false;
            }
            riempiGridImpClassSpesa();
            return true;
        }

        private void copiaClassificazioniEsistenti(DataTable tExpenseSorted) {
            FrmMeter FM = new FrmMeter("Ricopiatura classificazioni esistenti");

            FM.pBar.Maximum = tExpenseSorted.Rows.Count;
            FM.Show();
            Cursor.Current = Cursors.WaitCursor;

            MetaData metaExpensesorted = MetaData.GetMetaData(this, tabellaEntrataOSpesa + "sorted");
            int nRow = 0;
            foreach (DataRow rSiope in tExpenseSorted.Rows) {
                metaExpensesorted.SetDefaults(dataTableExpensesortedOrIncomesorted);
                DataRow r = metaExpensesorted.Get_New_Row(null, dataTableExpensesortedOrIncomesorted);
                foreach (DataColumn c in tExpenseSorted.Columns) {
                    FM.pBar.Increment(1);
                    nRow++;
                    if ((nRow % 10) == 0) {
                        Application.DoEvents();
                    }
                    switch (c.ColumnName) {
                        case "idparent":
                        case "oldidsor":
                            break;
                        case "newidsor":
                            r["idsor"] = rSiope["newidsor"];
                            break;
                        case "newsortcode":
                            r["!sortcode"] = rSiope["newsortcode"];
                            break;
                        case "ayear": {
                                r["ayear"] = Meta.GetSys("esercizio");
                                break;
                            }
                        case "newsorting":
                            r["!sorting"] = rSiope["newsorting"];
                            break;
                        default:
                            if (c.ColumnName == chiaveEntrataOSpesa) {
                                r[c.ColumnName] = rSiope["idparent"];
                            }
                            else {
                                r[c.ColumnName] = rSiope[c];
                            }
                            break;
                    }
                }
            }

            Cursor.Current = Cursors.Default;
            FM.Close();
            Application.DoEvents();
        }

        private void classificaInBaseAlBilancio(DataTable tFinLink, DataTable tFinSorting, DataRowView drv) {
            string filtroIdChild = QHC.CmpEq("idchild", drv["idfin"]);
            DataRow[] rFinLink = tFinLink.Select(QHC.AppAnd(filtroIdChild, QHC.CmpEq("idparent", drv["idfin"])));
            if (rFinLink.Length == 0) return;
            DataRow[] rFinSorting = new DataRow[0];
            int nlevel = 0;
            if (rFinLink.Length > 0) {
                rFinSorting = tFinSorting.Select(QHC.CmpEq("idfin", rFinLink[0]["idparent"]));
                nlevel = CfgFn.GetNoNullInt32(rFinLink[0]["nlevel"]);
            }
            while ((nlevel>1) && (rFinSorting.Length == 0)) {
                nlevel--;
                rFinLink = tFinLink.Select(QHC.AppAnd(filtroIdChild, QHC.CmpEq("nlevel", nlevel)));
                rFinSorting = tFinSorting.Select(QHC.CmpEq("idfin", rFinLink[0]["idparent"]));
            }
            if (rFinSorting.Length == 0) {
                return;
            }
            object idExp = drv[chiaveEntrataOSpesa];
            decimal currAmount = (decimal)drv["curramount"];
            decimal sortedAmount = (decimal)drv["!sortedamount"];
            MetaData metaExpensesorted = MetaData.GetMetaData(this, tabellaEntrataOSpesa + "sorted");
                //"idfin='" + idFin + "' and idsorkind='" + vecchiaClassificazione + "'";
            //DataRow[] rFinSortingQuotaNotNull = tFinSorting.Select(filtroFinSorting + " and quota is not null");
            DataRow[] rFinSortingQuotaNull = tFinSorting.Select(QHC.AppAnd(QHC.CmpEq("idfin", rFinSorting[0]["idfin"]), QHC.IsNull("quota")));
            //double totQuota = calcolaTotaleDouble("quota", rFinSortingQuotaNotNull);
            object objQuota = tFinSorting.Compute("sum(quota)", QHC.AppAnd(QHC.CmpEq("idfin", rFinSorting[0]["idfin"]), QHC.IsNotNull("quota")));
            double totQuota = objQuota is DBNull ? 0 : (double)objQuota;
            if ((totQuota != 0) || (rFinSortingQuotaNull.Length > 0)) {
                foreach (DataRow rFS in rFinSorting) {
                    double quota = rFS["quota"] is DBNull
                        ? (1 - totQuota) / rFinSortingQuotaNull.Length
                        : ((double)rFS["quota"]);
                    if (rFinSortingQuotaNull.Length == 0) {
                        quota /= totQuota;
                    }
                    decimal amount = (decimal)quota * (currAmount - sortedAmount);
                    DataTable t = Meta.Conn.SQLRunner("select s2.idsor from sorting s1 join sorting s2 on s1.sortcode=s2.sortcode and s1.idsorkind="
                        + QHS.quote(vecchiaClassificazione) + " and s2.idsorkind=" + QHS.quote(nuovaClassificazione)+
                        " and (s1.idsor="+QHS.quote(rFS["idsor"])+")");
                    object idsor = t.Rows[0]["idsor"];



                    DataRow[] rExpSort = dataTableExpensesortedOrIncomesorted.Select(chiaveEntrataOSpesa + "="
                        + idExp + " and idsor=" + QHS.quote(idsor)); //era rFS["idsor"]
                    if (rExpSort.Length == 0) {
                        DataRow r = metaExpensesorted.Get_New_Row(null, dataTableExpensesortedOrIncomesorted);
                        r["idsor"] = idsor;
                        r[chiaveEntrataOSpesa] = idExp;
                        //r["idsubclass"] = 1;
                        r["amount"] = CfgFn.RoundValuta(amount);
                        r["ayear"] = Meta.GetSys("esercizio");
                    }
                    else {
                        rExpSort[0]["amount"] = CfgFn.RoundValuta((decimal)rExpSort[0]["amount"] + (decimal)amount);
                    }
                }
            }
        }

        private void proporzionaClassificazioniEsistenti(object idExp, decimal currAmount) {
            DataRow[] rExpSort = dataTableExpensesortedOrIncomesorted.Select(chiaveEntrataOSpesa + "='" + idExp + "'");
            object objAmount = dataTableExpensesortedOrIncomesorted.Compute("sum(amount)", chiaveEntrataOSpesa + "='" + idExp + "'");
            decimal totAmount = objAmount is DBNull ? 0 : (decimal)objAmount;
            if (totAmount != 0) {
                decimal proporzione = currAmount / totAmount;
                foreach (DataRow rExSo in rExpSort) {
                    decimal amount = CfgFn.Round((decimal)rExSo["amount"] * proporzione, 2);
                    rExSo["amount"] = CfgFn.RoundValuta(amount);
                }
            }
        }

        private bool correggiArrotondamenti(List<int> listaSpese) {
            foreach (int idExp in listaSpese) {
                string filtro = chiaveEntrataOSpesa + "=" + idExp;
                DataRow[] rICS = dataTableExpensesortedOrIncomesorted.Select(filtro);
                DataRow[] rSpesa = dataTableExpenseOrIncome.Select(filtro);
                decimal giaClassificato = (decimal)rSpesa[0]["!sortedamount"];
                decimal currAmount = (decimal) rSpesa[0]["curramount"];
                if ((giaClassificato < currAmount) && !rbtSoloSiope.Checked) {
                    switch (rICS.Length) {
                        case 0: break;
                        case 1: rICS[0]["amount"] = currAmount; break;
                        default: {
                            decimal sortedAmount = 0;
                            for (int ii = 0; ii < rICS.Length ; ii++) {
                                sortedAmount += CfgFn.RoundValuta((decimal)rICS[ii]["amount"]);
                            }
                            
                            decimal diff = currAmount - sortedAmount;
                            decimal onecent = 0.01M;
                            int i = 0;
                            while (diff < 0) {
                                if ((decimal)rICS[i]["amount"] > 0) {
                                    rICS[i]["amount"] = (decimal)rICS[i]["amount"] - onecent;
                                    diff += onecent;
                                }
                                i = i + 1;
                                if (i == rICS.Length) i = 0;
                            }
                            i = 0;
                            while (diff > 0) {
                                rICS[i]["amount"] = (decimal)rICS[i]["amount"] + onecent;
                                diff -= onecent;
                                i = i + 1;
                                if (i == rICS.Length) i = 0;
                            }
                            break;
                        }
                    }
                }
            }
            return true;
        }

        void ResetWizard() {
            //if (DS.mandate.Rows.Count > 0)
            //    SetComboCausaleOrdine(DS.mandate.Rows[0]);
            //gridDetails.DataSource = null;
            //AggiornaGridDettagliOrdine();
        }



        string getFiltroSugliImpegni() {
            string filtro;
            if (tabellaEntrataOSpesa=="expense")
                filtro= "(nphase=" 
                + codFaseImpegno 
                + ") and (ayear=" 
                + Meta.GetSys("esercizio")
                + ") and ((select isnull(sum(amount),0) from expensesorted join sorting on sorting.idsor = expensesorted.idsor where idsorkind="
                + QHS.quote(nuovaClassificazione)
                + " and ayear=expenseview.ayear and idexp=expenseview.idexp)=0)";
            else
                filtro = "(nphase="
                                + codFaseImpegno
                                + ") and (ayear="
                                + Meta.GetSys("esercizio")
                                + ") and ((select isnull(sum(amount),0) from incomesorted join sorting on sorting.idsor = incomesorted.idsor where idsorkind="
                                + QHS.quote(nuovaClassificazione)
                                + " and ayear=incomeview.ayear and idinc=incomeview.idinc)=0)";

            DataRowView drv = SubEntity_comboUPB.SelectedItem as DataRowView;
            if ((drv!=null)&&(drv["idupb"] != DBNull.Value)) {
                filtro = QHS.AppAnd(filtro,QHC.CmpEq("idupb",drv["idupb"]));
            }

            //sommaPNP = somma delle class. su pagamenti corrispondenti a determinati impegni 
            string sommaPNP  = "";
            if (!chkAnniSuccessivi.Checked) {
                sommaPNP = "(select isnull(sum(amount),0) from expensesorted join sorting on sorting.idsor = expensesorted.idsor " +
                " join expenselink ON expenselink.idchild = expensesorted.idexp" +
                " where " + QHS.AppAnd(QHS.CmpEq("idsorkind", vecchiaClassificazione),
                    QHS.CmpEq("ayear", QHS.Field("expenseview.ayear")),
                    QHS.CmpEq("expenselink.idparent",
                    QHS.Field("expenseview.idexp"))) + ")";
            }
            else {
                sommaPNP = "(select isnull(sum(amount),0) from expensesorted join sorting on sorting.idsor = expensesorted.idsor " +
                " join expenselink ON expenselink.idchild = expensesorted.idexp" +
                  " where " + QHS.AppAnd(QHS.CmpEq("idsorkind", vecchiaClassificazione),
                QHS.CmpGe("ayear", QHS.Field("expenseview.ayear")),
                QHS.NullOrLe("sorting.start",QHS.Field("expenseview.ayear")),
                QHS.CmpEq("expenselink.idparent",
                QHS.Field("expenseview.idexp"))) + ")";
            }
            if (txtCodiceBilancio.Text.Trim() != "") {
                string code = txtCodiceBilancio.Text.Trim();
                filtro = QHS.AppAnd(filtro, QHS.CmpEq("codefin", code));
                //object idfin;
                //if (tabellaEntrataOSpesa == "expense")
                //    idfin = Conn.DO_READ_VALUE("fin", QHS.AppAnd(
                //                    QHS.CmpEq("codefin", code), QHS.CmpEq("ayear", Conn.GetSys("esercizio")),
                //                       QHS.BitSet("flag", 0)), "idfin");
                //else
                //    idfin = Conn.DO_READ_VALUE("fin", QHS.AppAnd(
                //                    QHS.CmpEq("codefin", code), QHS.CmpEq("ayear", Conn.GetSys("esercizio")),
                //                       QHS.BitClear("flag", 0)), "idfin");

                //filtro = QHS.AppAnd(filtro, QHS.CmpEq("idfin", idfin));
            }
            if (txtFiltroDenBilancio.Text != "") {
                filtro = QHS.AppAnd(filtro, QHS.Like("finance", "%" + txtFiltroDenBilancio.Text + "%"));
            }

            int check = 0;
            if (chkTotPagati.Checked) {
                check += 4;
            }
            if (chkParzPagati.Checked) {
                check += 2;
            }
            if (chkNonPagati.Checked) {
                check += 1;
            }
            if (tabellaEntrataOSpesa == "income") {
                filtro = filtro.Replace("expense", "income").Replace("idexp", "idinc");
                sommaPNP = sommaPNP.Replace("expense", "income").Replace("idexp", "idinc");
            }
            switch (check) {
                case 0: return "0=1";
                //prende solo i non pagati, ossia quelli la cui somma dei pagamenti è zero.
                case 1: return QHS.AppAnd(filtro, QHS.CmpEq(sommaPNP,0)) ;

                //prende solo i parz.pagati, ossia quelli la cui somma dei pag. è maggiore di 0 e minore di curramount
                case 2: return QHS.AppAnd(filtro, QHS.FieldNotInList(sommaPNP,QHS.List(0,QHS.Field("curramount"))));

                //prende sia i non pagati che quelli parz.pagati
                case 3: return QHS.AppAnd(filtro, QHS.CmpLt(sommaPNP, QHS.Field("curramount")));

                //prende solo i totalmente pagati
                case 4: return QHS.AppAnd(filtro, QHS.CmpEq(sommaPNP, 
                               QHS.Field("curramount")), QHS.CmpNe("curramount",0) );

                //prende i tot. pagati ed i non pagati
                case 5: return QHS.AppAnd(filtro, QHS.FieldNotInList(sommaPNP, QHS.List(0, QHS.Field("curramount"))));

                //prende tot.pagati e parz. pagati
                case 6: return QHS.AppAnd(filtro, QHS.CmpGt(sommaPNP, 0));
            }
            return filtro;
        }

        private void btnBack_Click(object sender, System.EventArgs e) {
            StandardChangeTab(-1);
        }

        private void btnNext_Click(object sender, System.EventArgs e) {
            StandardChangeTab(+1);
        }

        private void selezionaTutto() {
            string dataMember = gridImpegni.DataMember;
            CurrencyManager cm = (CurrencyManager)gridImpegni.BindingContext[DS, dataMember];
            DataView view = cm.List as DataView;
            if (view != null) {
                for (int i = 0; i < cm.Count; i++) {
                    gridImpegni.Select(i);
                }
            }
        }

        /// </summary>
        private void selezioneRigheCambiata() {
            CurrencyManager cm = (CurrencyManager)gridImpegni.BindingContext[DS, gridImpegni.DataMember];
            DataView view = cm.List as DataView;
            if (view == null) {
                return;
            }
            string elenco = "";
            for (int i = 0; i < view.Count; i++) {
                if (gridImpegni.IsSelected(i)) {
                    elenco += "," + view[i]["nmov"];
                }
            }

            if (elenco != "") elenco = elenco.Remove(0, 1);

            //txtDocumentiSelezionati.Text = elenco;
        }

        private void gridImpegni_CurrentCellChanged(object sender, EventArgs e) {
            selezioneRigheCambiata();
        }

        private void gridImpegni_MouseClick(object sender, MouseEventArgs e) {
            selezioneRigheCambiata();
        }

        //private void btnSeleziona_Click(object sender, EventArgs e) {
        //    selezionaIDocumentiInBaseATextBox();
        //}

        //private void selezionaIDocumentiInBaseATextBox() {
        //     string dataMember = gridImpegni.DataMember;
        //     CurrencyManager cm = (CurrencyManager)gridImpegni.BindingContext[DS, dataMember];
        //     DataView view = cm.List as DataView;
        //     if (view == null) return;

        //     if (txtSelezione.Text == "") {
        //         txtDocumentiSelezionati.Text = null;
        //         for (int i = 0; i < cm.Count; i++) {
        //             gridImpegni.UnSelect(i);
        //         }
        //         return;
        //     }
        //     int max = int.MinValue;
        //     int min = int.MaxValue;
        //     foreach (DataRowView r in view) {
        //         int numDoc = (int)r["nmov"];
        //         if (numDoc < min) {
        //             min = numDoc;
        //         }
        //         if (numDoc > max) {
        //             max = numDoc;
        //         }
        //     }

        //     List<int> al = new List<int>();
        //     string[] valori = txtSelezione.Text.Split(new char[] { ',' });
        //     foreach (string valore in valori) {
        //         int pos = valore.IndexOf('-');
        //         try {
        //             if (pos == -1) {
        //                 int numDoc = Int32.Parse(valore);
        //                 al.Add(numDoc);
        //             }
        //             else {
        //                 string valore1 = valore.Substring(0, pos);
        //                 string valore2 = valore.Substring(pos + 1);
        //                 int doc1 = (valore1 == "") ? min : Int32.Parse(valore1);
        //                 int doc2 = (valore2 == "") ? max : Int32.Parse(valore2);
        //                 if (doc1 > doc2) {
        //                     int h = doc1;
        //                     doc1 = doc2;
        //                     doc2 = h;
        //                 }
        //                 for (int i = doc1; i <= doc2; i++) {
        //                     al.Add(i);
        //                 }
        //             }
        //         }
        //         catch (FormatException) {
        //             show(this, "Errore nella selezione desiderata: " + valore + "\nImmettere i numeri dei movimenti e/o gli intervalli dei movimenti separati da virgole.");
        //             return;
        //         }
        //     }
        //     for (int i = 0; i < cm.Count; i++) {
        //         int numDoc = (int)view[i]["nmov"];
        //         int pos = al.IndexOf(numDoc);
        //         if (pos != -1) {
        //             gridImpegni.Select(i);
        //         }
        //         else {
        //             gridImpegni.UnSelect(i);
        //         }
        //     }
        //     selezioneRigheCambiata();
        // }

         private void descriviColonneExpensesorted() {
            DataColumnCollection dcc = dataTableExpensesortedOrIncomesorted.Columns;
            DataTable TipoClassMov = Meta.Conn.RUN_SELECT("sortingkind", "*", null,
                        QHS.CmpEq("idsorkind",nuovaClassificazione),
                null, true);
            if (TipoClassMov.Rows.Count != 1) return;
            DataRow CaptionsRow = TipoClassMov.Rows[0];
            foreach (DataColumn C in dcc) C.Caption = "";

            dcc[chiaveEntrataOSpesa].Caption = "#";
            dcc["!idfin"].Caption = "";// "#Bil";
            dcc["!phase"].Caption = "Fase";//expensephase.description AS phase
            dcc["!ymov"].Caption = "Eserc. mov.";//expense.ymov
            dcc["!nmov"].Caption = "Num. mov.";//expense.nmov
            dcc["!sortcode"].Caption = "Cod. class.";//sorting.sortcode
            dcc["!sorting"].Caption = "Descr. class.";//sorting.description AS sorting
            dcc["amount"].Caption = "Importo";
            dcc["description"].Caption = "Descrizione";
            dcc["!codefin"].Caption = "Codice bilancio";//fin.codefin
            dcc["!finance"].Caption = "Bilancio";//fin.title as finance
            dcc["!codeupb"].Caption = "Cod. U.P.B.";//upb.codeupb
            dcc["!upb"].Caption = "U.P.B.";//upb.title AS upb
            dcc["valuen1"].Caption = CaptionsRow["labeln1"].ToString();
            dcc["valuen2"].Caption = CaptionsRow["labeln2"].ToString();
            dcc["valuen3"].Caption = CaptionsRow["labeln3"].ToString();
            dcc["valuen4"].Caption = CaptionsRow["labeln4"].ToString();
            dcc["valuen5"].Caption = CaptionsRow["labeln5"].ToString();
            dcc["values1"].Caption = CaptionsRow["labels1"].ToString();
            dcc["values2"].Caption = CaptionsRow["labels2"].ToString();
            dcc["values3"].Caption = CaptionsRow["labels3"].ToString();
            dcc["values4"].Caption = CaptionsRow["labels4"].ToString();
            dcc["values5"].Caption = CaptionsRow["labels5"].ToString();
        }

		private void descriviColonneExpenseview()
		{
            DataColumnCollection dcc = dataTableExpenseOrIncome.Columns;
            foreach (DataColumn C in dcc) {
				C.Caption = "";
			}
            dcc[chiaveEntrataOSpesa].Caption = "#";
            dcc["!sortedamount"].Caption = "classificato";
            dcc["!howmuchsorted"].Caption = "totale/parziale";
            dcc["!notsortedamount"].Caption = "da classificare";
			dcc["phase"].Caption = "Fase";//
			dcc["ymov"].Caption = "Eserc.Mov.";//
			dcc["nmov"].Caption = "Num.Mov.";//
			dcc["codefin"].Caption = "Voce Bil.";//
			dcc["finance"].Caption = "Denom. Bil.";//
			dcc["codeupb"].Caption = "Cod. U.P.B.";//
			dcc["upb"].Caption = "U.P.B.";//
			dcc["registry"].Caption = "Percipiente";//
			dcc["manager"].Caption = "Responsabile";//
			dcc["doc"].Caption = "Documento";//
			dcc["docdate"].Caption = "Data Doc.";//
			dcc["description"].Caption = "Descrizione";//
			dcc["amount"].Caption = "Importo Originale";//
			dcc["ayearstartamount"].Caption = "Imp.Esercizio";//
			dcc["curramount"].Caption = "Imp.Corrente";//
			dcc["available"].Caption = "Disponibile";//
			dcc["adate"].Caption = "Data Contabile";//
            //dcc["fulfilled"].Caption = ".Mov.Cop.";//
			dcc["autokind"].Caption = ".Tipo Auto";//
			dcc["flagarrear"].Caption = "Competenza";//
			dcc["expiration"].Caption = ".Data Scadenza";//
            if (tabellaEntrataOSpesa == "expense") {
                //dcc["ypay"].Caption = "Eserc.Mand.";
                //dcc["npay"].Caption = "Num.Mand.";
                //dcc["paymentadate"].Caption = "Data Cont. Mand.";
                //dcc["regmodcode"].Caption = ".Tipo Modalità";
                dcc["idregistrypaymethod"].Caption = ".#";
                dcc["idpaymethod"].Caption = ".Codice Mod.Pag.";
                dcc["cin"].Caption = ".Cin";
                dcc["idbank"].Caption = ".Cod.ABI";
                dcc["idcab"].Caption = ".CAB";
                dcc["cc"].Caption = ".Conto";
                dcc["paymentdescr"].Caption = ".Desc.Pag.";
                dcc["service"].Caption = ".Prestazione";
                dcc["servicestart"].Caption = ".Data Inizio Prest.";
                dcc["servicestop"].Caption = ".Data Fine Prest.";
                dcc["ivaamount"].Caption = ".Iva";
                //dcc["autotaxflag"].Caption = ".Auto Rit.";
                //dcc["autoclawbackflag"].Caption = ".Auto rec.";
            }
            else {
                    //dcc["ypro"].Caption = "Eserc. Reversale";
                    //dcc["npro"].Caption = "Num. Reversale";
                    dcc["unpartitioned"].Caption = "Da assegnare";
            }
            dcc["nphase"].Caption = ".Codice fase";
            //dcc["ycreation"].Caption = ".Eserc.creazione";
            dcc["ayear"].Caption = ".Esercizio";
            dcc["idfin"].Caption = "";// ".Id.bilancio";
            dcc["idupb"].Caption = "";// ".Id.upb";
            dcc["idreg"].Caption = "";// ".Codice cred/deb";
            dcc["idman"].Caption = ""; // ".Codice responsabile";
            dcc["autocode"].Caption = ""; // ".Codice automatismo";
            //dcc["idproceeds"].Caption = ".Id.incasso";
            dcc["idpayment"].Caption = "";// ".Id.pagamento";
            dcc["nbill"].Caption = ".Num.bolletta";
        }



        private void completaExpensesortedConUnaTabellaPadre(
            string nomeCampo, string nomeTabella, string ulterioreFiltro,
            string altriCampiDaLeggere) 
        {
            string campoSullaTabella = dataTableExpensesortedOrIncomesorted.Columns.Contains(nomeCampo) ? 
                            nomeCampo : "!" + nomeCampo;
            DataRow[] righe = dataTableExpensesortedOrIncomesorted.Select(QHC.IsNotNull(campoSullaTabella));
            string valori = QHS.DistinctVal(righe, campoSullaTabella);
            if (righe.Length>0) {
                DataTable t = DataAccess.RUN_SELECT(Meta.Conn, nomeTabella,
                    nomeCampo+","+altriCampiDaLeggere, null,
                    QHS.AppAnd(QHS.FieldInList(nomeCampo,valori),ulterioreFiltro),
                    null, null, true);
                foreach (DataRow rEP in t.Rows) {
                    foreach (DataRow r in dataTableExpensesortedOrIncomesorted.Select(
                        QHC.CmpEq(campoSullaTabella,rEP[nomeCampo])
                        )) {
                        for (int i = 1; i < t.Columns.Count; i++) {
                            DataColumn c = t.Columns[i];
                            r["!"+c.ColumnName] = rEP[c];
                        }
                    }
                }
            }
        }

        private void riempiGridImpClassSpesa() {
            foreach (DataRow rICS in dataTableExpensesortedOrIncomesorted.Rows) {
                DataRow rSpesa = rICS.GetParentRow(tabellaEntrataOSpesa+"view_"+tabellaEntrataOSpesa+"sorted");
                rICS["!phase"] = rSpesa["phase"];
                rICS["!ymov"] = rSpesa["ymov"];
                rICS["!nmov"] = rSpesa["nmov"];
                rICS["!idfin"] = rSpesa["idfin"];
                rICS["!codefin"] = rSpesa["codefin"];
                rICS["!finance"] = rSpesa["finance"];
                rICS["!codeupb"] = rSpesa["codeupb"];
                rICS["!upb"] = rSpesa["upb"];
            }
            completaExpensesortedConUnaTabellaPadre("idsor", "sorting", 
                QHS.CmpEq("idsorkind", nuovaClassificazione),
                "sortcode, description AS sorting");
            HelpForm.SetDataGrid(gridImpClassSpesa, dataTableExpensesortedOrIncomesorted);
        }

        private void btnSelezionaTutto_Click(object sender, EventArgs e) {
            selezionaTutto();
        }

        private void btnDeselezionaTutto_Click(object sender, EventArgs e) {
            string dataMember = gridImpegni.DataMember;
            CurrencyManager cm = (CurrencyManager)gridImpegni.BindingContext[DS, dataMember];
            DataView view = cm.List as DataView;
            if (view != null) {
                for (int i = 0; i < cm.Count; i++) {
                    gridImpegni.UnSelect(i);
                }
            }
        }

        private void btnCancel_Click(object sender, System.EventArgs e) {
            DS.AcceptChanges();
            Close();
        }
    }
}
