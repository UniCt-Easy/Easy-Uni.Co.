
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
using Crownwood.Magic.Controls;
using funzioni_configurazione;
using System.Globalization;
using movimentofunctions;

namespace expense_wizardexpensefinvardetail {
    public partial class Frm_expense_wizardexpensefinvardetail : MetaDataForm {
        string CustomTitle;
        MetaData Meta;
        int fasebilancio;
        int faseimpegno;


        public Frm_expense_wizardexpensefinvardetail() {
            InitializeComponent();
            FormInit();
            tabControllerMagic.HideTabsMode =
                Crownwood.Magic.Controls.TabControl.HideTabsModes.HideAlways;
        }
        void FormInit() {
            CustomTitle = "Wizard Creazione prenotazioni da richieste di previsione";
        }

        string filterBilancio;
        DataAccess Conn;
        QueryHelper QHS;
        CQueryHelper QHC;
        public void MetaData_AfterLink() {
            Meta = MetaData.GetMetaData(this);
            QHC = new CQueryHelper();
            Conn = Meta.Conn;
            QHS = Meta.Conn.GetQueryHelper();

            inizializzaVar();
            visualizzaEtichetta();
            DisplayTabs(0);
            Meta.CanInsert = false;
            Meta.CanSave = false;
            Meta.SearchEnabled = false;
            ClearDataSet.RemoveConstraints(DS2);
            filterBilancio = QHS.AppAnd(QHS.CmpEq("ayear", Meta.GetSys("esercizio")),
                                        QHS.BitSet("flag", 0)); //finpart=S
            GetData.SetStaticFilter(DS.fin, filterBilancio);
            GetData.SetStaticFilter(DS.finview, filterBilancio);

            string filtersercizio = QHS.CmpEq("ayear", Meta.GetSys("esercizio"));
            DataAccess.RUN_SELECT_INTO_TABLE(Meta.Conn, DS2.sortingkind, null, null, null, true);
            DataAccess.RUN_SELECT_INTO_TABLE(Meta.Conn, DS2.config, null, filtersercizio, null, true);



        }
        void inizializzaVar() {
            string filteresercizio = QHS.CmpEq("ayear", Meta.GetSys("esercizio"));
            object app = Meta.GetSys("expensefinphase");
            fasebilancio = Convert.ToInt32(app);
            app = Meta.GetSys("appropriationphase");
            faseimpegno = Convert.ToInt32(app);
        }

        void visualizzaEtichetta() {
            object nomefase = Conn.DO_READ_VALUE("expensephase",
                            QHS.CmpEq("nphase", Meta.GetSys("expensefinphase")), "description");
            lblTitolo.Text = "Creazione dei movimenti di spesa di fase: " + nomefase.ToString().ToUpper()+ " a partire dalle richieste di previsione";
        }


        void StandardChangeTab(int step) {
            int oldTab = tabControllerMagic.SelectedIndex;
            int newTab = oldTab + step;
            if ((newTab < 0) || (newTab > tabControllerMagic.TabPages.Count - 1)) return;

            if (newTab == 1) { riempiGrid(); }
            if (newTab == tabControllerMagic.TabPages.Count - 1) {
                btnAvanti.DialogResult = DialogResult.OK;
            }
            else {
                btnAvanti.DialogResult = DialogResult.None;
            }
            DisplayTabs(newTab);
        }

        void DisplayTabs(int newTab) {
            tabControllerMagic.SelectedIndex = newTab;
            btnIndietro.Enabled = (newTab > 0);
            if (newTab == tabControllerMagic.TabPages.Count - 1)
                btnAvanti.Text = "Fine.";
            else
                btnAvanti.Text = "Avanti >";
            Text = CustomTitle + " (Pagina " + (newTab + 1) + " di " + tabControllerMagic.TabPages.Count + ")";
        }

        private void btnIndietro_Click(object sender, System.EventArgs e) {
            AbilitaDisabilita(false);
            StandardChangeTab(-1);
            AbilitaDisabilita(true);
        }

        private void btnAvanti_Click(object sender, System.EventArgs e) {
            AbilitaDisabilita(false);
            StandardChangeTab(+1);
            AbilitaDisabilita(true);
        }

        void AbilitaDisabilita(bool disponibile) {
            if (disponibile) {
                Cursor.Current = Cursors.Default;
            }
            else {
                Cursor.Current = Cursors.WaitCursor;
            }

            btnAvanti.Enabled = disponibile;
            btnIndietro.Enabled = disponibile;
            btnAnnulla.Enabled = disponibile;
        }

        private void aggiornaDataGrid() {
            DS.Clear();
            riempiGrid();
        }


        void riempiGrid() {
            //DS2.Clear();    

            // CONTROLLARE CHE IL Clear() DI QUESTE TABELLE SIA CORRETTO !!!! 
            DS2.expense.Clear();
            DS2.expenseyear.Clear();
            DS2.expensetotal.Clear();
            DS2.expensesorted.Clear();
            DS2.expenseview.Clear(); 
            DS2.finvardetailview.Clear();
            // Filtro tutti i mov. di spesa che hanno una variazione 
            // con tipoautomatismo ECONO e che non sono presenti in alcun idparent
            int ayear = CfgFn.GetNoNullInt32( Meta.Conn.GetSys("esercizio"));
            string filterDettVar = QHS.AppAnd(QHS.CmpEq("yvar", ayear), 
                                QHS.IsNull("idexp"),QHS.CmpEq("createexpense","S"));

            DataAccess.RUN_SELECT_INTO_TABLE(Meta.Conn, DS2.finvardetailview, null, filterDettVar, null, true);
            foreach (DataColumn C in DS2.finvardetailview.Columns) {
                C.Caption = "";
            }
            int n=1;
            MetaData.DescribeAColumn(DS2.finvardetailview, "nvar", "N.var", n++);
            MetaData.DescribeAColumn(DS2.finvardetailview, "amount", "Importo", n++);
            MetaData.DescribeAColumn(DS2.finvardetailview, "manager", "Responsabile", n++);
            MetaData.DescribeAColumn(DS2.finvardetailview, "finance", "Bilancio", n++);
            MetaData.DescribeAColumn(DS2.finvardetailview, "codefin", "Codice Bil.", n++);
            MetaData.DescribeAColumn(DS2.finvardetailview, "codeupb", "Codice UPB", n++);
            MetaData.DescribeAColumn(DS2.finvardetailview, "upb", "UPB", n++);
            MetaData.DescribeAColumn(DS2.finvardetailview, "underwriting", "Finanziamento", n++);
            MetaData.DescribeAColumn(DS2.finvardetailview, "description", "Descrizione", n++);
       

            if (dgMovSpesa.DataSource == null) {
                HelpForm.SetDataGrid(dgMovSpesa, DS2.finvardetailview);
                new formatgrids(dgMovSpesa).AutosizeColumnWidth();
            }
        }

        DataRow[] GetRigheSelezionate() {
            string dataMember = dgMovSpesa.DataMember;
            CurrencyManager cm = (CurrencyManager)dgMovSpesa.BindingContext[DS2, dataMember];
            DataView view = cm.List as DataView;
            if (view == null) return new DataRow[] { };
            int n = 0;
            for (int i = 0; i < view.Count; i++) {
                if (dgMovSpesa.IsSelected(i)) n++;
            }
            DataRow []res = new DataRow[n];
            int found = 0;
            for (int i = 0; i < view.Count; i++) {
                if (dgMovSpesa.IsSelected(i)) {
                    res[found] = view[i].Row;
                    found++;
                }
            }
            return res;
            
        }

        void ViewAutomatismi(DataSet DS) {
            string spesa = null;
            if (DS.Tables["expense"] != null) {
                DataTable Var = DS.Tables["expense"];
                spesa = QHS.FieldIn("idexp", Var.Select(), "idexp");
            }

            Form F = ShowAutomatismi.Show(Meta, spesa, null, null, null);
            createForm(F, this);
            F.ShowDialog(this);
        }


        private void btnCrea_Click(object sender, System.EventArgs e) {
            DataRow[] sel = GetRigheSelezionate();
            if (sel==null || sel.Length == 0) {
                show(this, "Nessuna riga selezionata");
                return;
            }
           
            foreach (DataRow R in sel) {
                creaMovSpesa(R);
            }


            int fasespesamax = CfgFn.GetNoNullInt32(Meta.GetSys("maxexpensephase"));



            GestioneAutomatismi ga = new GestioneAutomatismi(this, Meta.Conn, Meta.Dispatcher, DS2.Copy(),
                         1, fasespesamax, "expense", true);
            ga.GeneraClassificazioniAutomatiche(ga.DSP, true);

            bool res = ga.GeneraAutomatismiAfterPost(true);
            if (!res) {
                show(this, "Si è verificato un errore o si è deciso di non salvare! L'operazione sarà terminata");
                Resetta();
                return;
            }

            res = ga.doPost(Meta.Dispatcher);
            if (res) ViewAutomatismi(ga.DSP);
            Resetta();

        }

        void Resetta() {
            // CONTROLLARE CHE IL Clear() DI QUESTE TABELLE SIA CORRETTO !!!! (Sara)
            DS2.expense.Clear();
            DS2.expenseyear.Clear();
            DS2.expensetotal.Clear();
            DS2.expensesorted.Clear();
            DS2.expenseview.Clear();
            DS2.underwritingappropriation.Clear();
            DS2.finvardetail.Clear();

            DS2.AcceptChanges();
            dgMovSpesa.DataSource = null;
            aggiornaDataGrid();
        }

        void creaMovSpesa(DataRow Rvar) {
            int esercizio = (int)Meta.GetSys("esercizio");


            object newidbilancio = Rvar["idfin"];
            object newidupb = Rvar["idupb"];

            
            MetaData metaSpesa = MetaData.GetMetaData(this, "expense");
            MetaData metaImpuSpesa = MetaData.GetMetaData(this, "expenseyear");
            MetaData metaAppropriation = MetaData.GetMetaData(this, "underwritingappropriation");
            metaSpesa.SetDefaults(DS2.expense);
            metaImpuSpesa.SetDefaults(DS2.expenseyear);
            metaAppropriation.SetDefaults(DS2.underwritingappropriation);

            MetaData.SetDefault(DS2.expenseyear, "ayear", esercizio);
            
            DataRow DRSpesa = metaSpesa.Get_New_Row(null, DS2.expense);

            //DRSpesa["amount"] = -(decimal)Mov["variationamount"];
            //DRSpesa["autokind"] = 5;
            if (Rvar["description"]==DBNull.Value)
                DRSpesa["description"] = Rvar["variationdescription"];
            else
                DRSpesa["description"] = Rvar["description"];

            DRSpesa["idman"] = Rvar["idman"];
            AddVociCollegate(Rvar);

            object Fase1 = Conn.DO_READ_VALUE("expensephase", QHS.CmpEq("nphase", 1), "description");
            AddVoceFase(1, Fase1);

            DataRow DRImpuSpesa = metaImpuSpesa.Get_New_Row(DRSpesa, DS2.expenseyear);
            //DRImpuSpesa["nphase"] = DRSpesa["nphase"];
            DRImpuSpesa["idfin"] = newidbilancio;
            DRImpuSpesa["idupb"] = newidupb;
            DRImpuSpesa["amount"] = Rvar["amount"];

            if (Rvar["idunderwriting"] != DBNull.Value) {
                DataRow DRUA = metaAppropriation.Get_New_Row(DRSpesa, DS2.underwritingappropriation);
                //DRImpuSpesa["nphase"] = DRSpesa["nphase"];
                DRUA["idunderwriting"] = Rvar["idunderwriting"];
                DRUA["amount"] = Rvar["amount"];
            }
            Conn.RUN_SELECT_INTO_TABLE(DS2.finvardetail, null, QHS.MCmp(Rvar, "yvar", "nvar", "rownum"), null, false);
            DataRow[] r = DS2.finvardetail.Select(QHC.MCmp(Rvar, "yvar", "nvar", "rownum"));
            r[0]["idexp"] = DRSpesa["idexp"];




            
        }

        void AddVociCollegate(DataRow Rvar) {
            

            if (Rvar["idfin"]!=DBNull.Value) {
                AddVoceBilancio(Rvar["idfin"],Rvar["codefin"]);
            }
            if (Rvar["idupb"] != DBNull.Value) {
                AddVoceUPB(Rvar["idupb"],Rvar["codeupb"]);
            }

            if (Rvar["idman"] != DBNull.Value) {
                AddVoceResponsabile(Rvar["idman"], Rvar["manager"]);
            }

            if (Rvar["idunderwriting"] != DBNull.Value) {
                AddVoceUnderwriting(Rvar["idunderwriting"], Rvar["underwriting"]);
            }

        }

        void AddVoceFase(object codice, object descr) {
            if (codice == DBNull.Value) return;
            if (DS2.Tables["expensephase"] == null) return;
            if (DS2.Tables["expensephase"].Select(QHC.CmpEq("nphase", codice)).Length > 0) return;
            DataRow NewFase = DS2.Tables["expensephase"].NewRow();
            NewFase["nphase"] = codice;
            NewFase["description"] = descr;
            DS2.Tables["expensephase"].Rows.Add(NewFase);
            NewFase.AcceptChanges();
        }

        void AddVoceBilancio(object ID,object code) {
            if (ID == DBNull.Value) return;
            if (DS2.Tables["fin"].Select(QHC.CmpEq("idfin", ID)).Length > 0) return;
            DataRow NewBil = DS2.Tables["fin"].NewRow();
            NewBil["idfin"] = ID;
            NewBil["codefin"] = code;
            DS2.Tables["fin"].Rows.Add(NewBil);
            NewBil.AcceptChanges();
        }

        void AddVoceUnderwriting(object ID, object code) {
            if (ID == DBNull.Value) return;
            if (DS2.Tables["underwriting"].Select(QHC.CmpEq("idunderwriting", ID)).Length > 0) return;
            DataRow NewBil = DS2.Tables["underwriting"].NewRow();
            NewBil["idunderwriting"] = ID;
            NewBil["title"] = code;
            DS2.Tables["underwriting"].Rows.Add(NewBil);
            NewBil.AcceptChanges();
        }

        void AddVoceUPB(object ID, object code) {
            if (ID == DBNull.Value) return;
            if (DS2.Tables["upb"].Select(QHC.CmpEq("idupb", ID)).Length > 0) return;
            DataRow NewUPB = DS2.Tables["upb"].NewRow();
            NewUPB["idupb"] = ID;
            NewUPB["codeupb"] = code;
            DS2.Tables["upb"].Rows.Add(NewUPB);
            NewUPB.AcceptChanges();
        }

        void AddVoceResponsabile(object ID, object descr) {
            if (ID == DBNull.Value) return;
            if (DS2.Tables["manager"].Select(QHC.CmpEq("idman", ID)).Length > 0) return;
            DataRow NewResp = DS2.Tables["manager"].NewRow();
            NewResp["idman"] = ID;
            NewResp["title"] = descr;
            DS2.Tables["manager"].Rows.Add(NewResp);
            NewResp.AcceptChanges();
        }

      
    }
}
