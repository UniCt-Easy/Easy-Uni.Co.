
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
using funzioni_configurazione;
using ep_functions;

namespace import_flow_default {
    public partial class FrmImportFlow_default : MetaDataForm {
        public IOpenFileDialog openInputFileDlg;
        string CustomTitle;
        MetaData Meta;
        MetaData MetaIncomeSorted;
        MetaData MetaExpenseSorted;
        MetaData MetaPayment;
        MetaData MetaProceeds;
        CQueryHelper QHC;
        QueryHelper QHS;
        int esercizio;
        DataAccess Conn;
        ContextMenu ExcelMenu;
        bool GoodData;
        int maxfasespesa;

        DataTable TrattamentoBollo;
        DataTable Cassiere;


        public FrmImportFlow_default() {
            InitializeComponent();
            tabController.HideTabsMode =
                Crownwood.Magic.Controls.TabControl.HideTabsModes.HideAlways;
            openInputFileDlg = createOpenFileDialog(_openInputFileDlg);
        }        

        void FormInit() {
            CustomTitle = "Importazione flusso movimenti.";
            //Selects first tab
            DisplayTabs(0);
            Meta.Name = Text;
        }
        
        public void MetaData_AfterLink() {
            Meta = MetaData.GetMetaData(this);
            QHC = new CQueryHelper();
            QHS = Meta.Conn.GetQueryHelper();

            foreach (DataTable T in DS.Tables) {
                RowChange.SetOptimized(T, true);
            }
            this.Conn = Meta.Conn;
            esercizio = CfgFn.GetNoNullInt32( Meta.GetSys("esercizio"));
            GetData.CacheTable(DS.config, QHS.CmpEq("ayear", esercizio), null, false);
            GetData.CacheTable(DS.sortingkind, null, null, false);
            GetData.CacheTable(DS.expensephase,null,"nphase asc",false);
            GetData.CacheTable(DS.incomephase, null, "nphase asc", false);
            GetData.SetSorting(DS.expenseview, "ymov desc, nmov desc");
            GetData.SetSorting(DS.incomeview, "ymov desc, nmov desc");
            GetData.CacheTable(DS.paymethod);
            GoodData = false;
            Meta.CanSave = false;
            Meta.CanInsert = false;
            Meta.CanInsertCopy = false;
            Meta.CanCancel = false;

            MetaExpenseSorted = Meta.Dispatcher.Get("expensesorted");
            MetaIncomeSorted = Meta.Dispatcher.Get("incomesorted");
            MetaIncomeSorted.SetDefaults(DS.incomesorted);
            MetaExpenseSorted.SetDefaults(DS.expensesorted);

            MetaPayment = Meta.Dispatcher.Get("payment");
            MetaProceeds = Meta.Dispatcher.Get("proceeds");
            MetaPayment.SetDefaults(DS.payment);
            MetaProceeds.SetDefaults(DS.proceeds);

            Cassiere = Conn.RUN_SELECT("treasurer", "*", null, null, null, true);
            if (Cassiere.Select(QHC.CmpEq("flagdefault", "S")).Length == 1) {
                idtreasurer_default = Cassiere.Select(QHC.CmpEq("flagdefault", "S"))[0]["idtreasurer"];
            }
            else {
                if (Cassiere.Rows.Count == 1) {
                    idtreasurer_default = Cassiere.Rows[0]["idtreasurer"];
                }
            }
            if (idtreasurer_default == DBNull.Value) {
                show("Non è stato configurato il tesoriere predefinito.", "Errore");
            }
            TrattamentoBollo = Conn.RUN_SELECT("stamphandling", "*", null, null, null, true);
            if (TrattamentoBollo.Select(QHC.CmpEq("flagdefault", "S")).Length == 1) {
                idstamphandling_default = TrattamentoBollo.Select(QHC.CmpEq("flagdefault", "S"))[0]["idstamphandling"];
            }
            else {
                if (TrattamentoBollo.Rows.Count == 1) {
                    idstamphandling_default = Cassiere.Rows[0]["idstamphandling"];
                }
            }
            if (idstamphandling_default == DBNull.Value) {
                show("Non è stato configurato il trattamento bollo predefinito.", "Errore");
            }
            ExcelMenu = new ContextMenu();
            ExcelMenu.MenuItems.Add("Excel", new EventHandler(Excel_Click));
			
        }

        private void Excel_Click(object menusender, EventArgs e) {
            if (menusender == null) return;
            if (!(typeof(MenuItem).IsAssignableFrom(menusender.GetType()))) return;
            object sender = ((MenuItem)menusender).Parent.GetContextMenu().SourceControl;
            if (!(typeof(DataGrid).IsAssignableFrom(sender.GetType()))) return;
            DataGrid G = (DataGrid)sender;
            object DDS = G.DataSource;
            if (DDS == null) return;
            if (!typeof(DataSet).IsAssignableFrom(DDS.GetType())) return;
            string DDT = G.DataMember;
            if (DDT == null) return;
            DataTable T = ((DataSet)DDS).Tables[DDT];
            if (T == null) return;
            exportclass.DataTableToExcel(T, true);
        }

        object idtreasurer_default = DBNull.Value;
        object idstamphandling_default = DBNull.Value;
        DataRow rConfig;

        public void MetaData_AfterActivation() {
            FormInit();
            maxfasespesa = CfgFn.GetNoNullInt32(Meta.GetSys("maxexpensephase"));
            
            rConfig = DS.config.Rows[0];
        }
        public void MetaData_AfterClear() {
            DisplayCounts();
            DisplayCountsDetail();
            Text = CustomTitle + " (Pagina " + (tabController.SelectedIndex + 1)
                        + " di " + tabController.TabPages.Count + ")";
        }
        string getExpPhaseName(object nphase) {
            if (nphase == DBNull.Value) return "";
            return DS.expensephase.Rows[CfgFn.GetNoNullInt32(nphase)]["description"].ToString();
        }
        string getIncPhaseName(object nphase) {
            if (nphase == DBNull.Value) return "";
            return DS.incomephase.Rows[CfgFn.GetNoNullInt32(nphase)]["description"].ToString();
        }

        
        /// <summary>
        /// Displays tab n. NewTab and updates buttons
        /// </summary>
        /// <param name="newTab"></param>
        void DisplayTabs(int newTab) {
            tabController.SelectedIndex = newTab;
            //Evaluates Buttons Appearance
            btnBack.Visible = (newTab > 0 && newTab<4);
            if (newTab == tabController.TabPages.Count - 1)
                btnNext.Text = "Fine.";
            else
                btnNext.Text = "Avanti >";
            if (newTab == 5) {
                btnNext.Text = "Salva";
            }
            Text = CustomTitle + " (Pagina " + (newTab + 1) + " di " + tabController.TabPages.Count + ")";
        }


        /// <summary>
        /// Changes tab backward/forward
        /// </summary>
        /// <param name="step"></param>
        void StandardChangeTab(int step) {
            int oldTab = tabController.SelectedIndex;
            int newTab = oldTab + step;
            if ((newTab < 0) || (newTab > tabController.TabPages.Count)) return;
            if (!CustomChangeTab(oldTab, newTab)) return;
            if (newTab == tabController.TabPages.Count) {
                DialogResult = DialogResult.OK;
                return;
            }
            DisplayTabs(newTab);
        }

        /// <summary>
        /// Must return true if operation is possible, and do any
        ///  operation related to change from tab oldTab to newTab
        /// </summary>
        /// <param name="oldTab"></param>
        /// <param name="newTab"></param>
        /// <returns></returns>
        bool CustomChangeTab(int oldTab, int newTab) {
            if (oldTab == 6) {
                return false;
            }
            //if (oldTab==0) 	return true ; // 0->1: nothing to do
            if (newTab == 0) {
                btnNext.Visible = false;
                DisplayCounts();
                btnNext.Visible = true;
            }
            if (newTab == 1) {
                btnNext.Visible = false;
                CheckInputData();
                btnNext.Visible = true;
            }
            if (newTab == 2) {
                btnNext.Visible = false;
                ClearMov();
                CallVarStoredProcedure();
                btnNext.Visible = true;
            }

            if (newTab == 3) {
                btnBack.Visible = false;
                btnNext.Visible = false;
                GeneraMovimenti();
                VisualizzaMovimenti();
                btnNext.Visible = true;
            }
            if (newTab == 4) {
                btnBack.Visible = false;
                btnNext.Visible = false;
                GeneraScritture();
                VisualizzaScritture();
                btnNext.Visible = true;
            }

            if (newTab == 5) {
                btnBack.Visible = false;
                btnNext.Visible = true;
            }


            if (oldTab==5 && newTab == 6) {
                btnBack.Visible = false;
                btnNext.Visible = false;
                SaveData();
            }

            if (newTab == 0) {//lettura dati
                btnNext.Enabled = true;
                return true; 
            }
            if (newTab == 1) {               
                return true;
            }
            if (newTab == 2) {
                return GoodData;
            }
            return true;
        }

        DataTable importflow = null;
        DataTable importflow_coge = null;

        /// <summary>
        /// Crea una corrispondenza tra la idimportflow e il numero di riga che corrisponde a quell'id
        /// Quindi dato il codice ID iflow[ID]= i dove importflow.Rows[i] è la riga avente idimporflow=ID
        /// </summary>
        Dictionary<string, int> iflow = new Dictionary<string, int>();
        void FillIFlow() {
            iflow = new Dictionary<string, int>();
            DS.import_flow.Clear();
            for (int i = 0; i < importflow.Rows.Count; i++) {
                DataRow s= importflow.Rows[i];
                iflow[s["idimportflow"].ToString().ToUpper()] = i;
                DataRow d = DS.import_flow.NewRow();
                foreach (DataColumn c in DS.import_flow.Columns)
                    d[c.ColumnName] = s[c.ColumnName];
                DS.import_flow.Rows.Add(d);
                AddVociCollegate(s);
            }
            DS.import_flow.AcceptChanges();
        }

        /// <summary>
        /// Cerca una riga nel dictionary avente un certo idimportflow, restituisce una riga di DS.import_flow
        /// </summary>
        /// <param name="idimportflow"></param>
        /// <returns></returns>         
        DataRow getFlowRow(string idimportflow) {
            string k =idimportflow.ToUpper();
            if(!iflow.ContainsKey(k)) return null;
            return DS.import_flow.Rows[iflow[k]];
        }

        DataRow getFlowViewRow(string idimportflow) {
            string k = idimportflow.ToUpper();
            if (!iflow.ContainsKey(k)) return null;
            return importflow.Rows[iflow[k]];
        }


        void DisplayCounts() {
            importflow = Conn.RUN_SELECT("import_flowview", "*", null,
                    QHS.AppAnd(QHS.CmpEq("esercizio", esercizio),
                                QHS.IsNull("id_liq"), QHS.IsNull("id_inc")), null, false);
            FillIFlow();
            int nliq = CfgFn.GetNoNullInt32(importflow.Compute("count(idimportflow)", QHC.CmpEq("E_S", "S")));
            int ninc = importflow.Rows.Count - nliq;
            labpagamenti.Text = nliq.ToString();
            labincassi.Text = ninc.ToString();
            if (importflow.Rows.Count == 0) {
                btnNext.Enabled = false;
            }
            else {
                btnNext.Enabled = true;
            }
        }
        bool movimentigenerati = false;
        

        void ClearMov() {
            movimentigenerati = false;
            scritturegenerate = false;
            
            DS.expense.Clear();
            RowChange.ClearMaxCache(DS.expense);

            DS.expenseyear.Clear();
            RowChange.ClearMaxCache(DS.expenseyear);
            DS.expenselast.Clear();
            RowChange.ClearMaxCache(DS.expenselast);
            DS.expensesorted.Clear();
            RowChange.ClearMaxCache(DS.expensesorted);

            DS.income.Clear();
            RowChange.ClearMaxCache(DS.income);
            DS.incomeyear.Clear();
            RowChange.ClearMaxCache(DS.incomeyear);
            DS.incomelast.Clear();
            RowChange.ClearMaxCache(DS.incomelast);
            DS.incomesorted.Clear();
            RowChange.ClearMaxCache(DS.incomesorted);

            DS.finvardetail.Clear();
            RowChange.ClearMaxCache(DS.finvardetail);
            DS.finvar.Clear();
            RowChange.ClearMaxCache(DS.finvar);

            DS.payment.Clear();
            RowChange.ClearMaxCache(DS.payment);
            DS.proceeds.Clear();
            RowChange.ClearMaxCache(DS.proceeds);

            DS.entry.Clear();
            RowChange.ClearMaxCache(DS.entry);
            DS.entrydetail.Clear();
            RowChange.ClearMaxCache(DS.entrydetail);

            DS.paymenttransmission.Clear();
            RowChange.ClearMaxCache(DS.paymenttransmission);
            DS.proceedstransmission.Clear();
            RowChange.ClearMaxCache(DS.proceedstransmission);

        }

        void CheckInputData() {
            if (!CallErrStoredProcedure()) {
                lblMessaggi.Text = "Errori nella tabella di impotazione del flusso impediscono il proseguimento " +
                    "della procedura. Correggerli e riprovare.";
                GoodData = false;
            }
            else {
                lblMessaggi.Text = "La tabella del flusso è ben configurata, si può procedere alla creazione " +
                    "dei movimenti finanziari.";
                GoodData = true;
            }
            btnNext.Enabled = GoodData;
        }
        private void btnBack_Click(object sender, System.EventArgs e) {
            StandardChangeTab(-1);
        }

        private void btnNext_Click(object sender, System.EventArgs e) {
            StandardChangeTab(+1);
        }

        bool CallErrStoredProcedure() {
            DataSet Out = Conn.CallSP("compute_importflow_errors",
                new object[] { esercizio },false,3600);
            if (Out == null) return false;
            if (Out.Tables.Count == 0) return false; //no answer from sp
            if (Out.Tables[0].Rows.Count == 0) return true;
            //TO DO:   display errors
            DataTable T=   Out.Tables[0];         

            foreach (DataColumn C in T.Columns)
                MetaData.DescribeAColumn(T, C.ColumnName, "", -1);

            int nPos = 0;
            MetaData.DescribeAColumn(T, "idriga", "ID", nPos++); 
            MetaData.DescribeAColumn(T, "errordescr", "Errore", nPos++);

            setgrid(gridProblemi, T);
            return false;
        }
        void setgrid(DataGrid g, DataTable t) {
            g.SetDataBinding(t.DataSet, t.TableName);
            HelpForm.SetGridStyle(g, t);
            metadatalibrary.formatgrids fg = new formatgrids(g);
            fg.AutosizeColumnWidth();

            //HelpForm.SetDataGrid(gridProblemi, T);
            g.ContextMenu = ExcelMenu;

        }
        

        void CallVarStoredProcedure() {
            MetaData mfinvar = Meta.Dispatcher.Get("finvar");
            MetaData mfinvarDetail = Meta.Dispatcher.Get("finvardetail");
            //crea la variazione
            mfinvar.SetDefaults(DS.finvar);
            mfinvarDetail.SetDefaults(DS.finvardetail);
            DateTime elab = DateTime.Now;
            RowChange.SetSelector(DS.finvar, "yvar");
            RowChange.MarkAsAutoincrement(DS.finvar.Columns["nofficial"], null, null, 7);
            DataSet Out = Conn.CallSP("compute_importflow_variation",
                new object[] { esercizio }, false, 300);
            if (Out == null) return ;
            if (Out.Tables.Count == 0) return ; //no answer from sp
            if (Out.Tables[0].Rows.Count > 0) {
               
                DataRow rFinVar = mfinvar.Get_New_Row(null, DS.finvar);
                rFinVar["official"] = "S";
                rFinVar["description"] = "Variazione automatica in aumento generata con l'importazione del " +
                                         elab.ToShortDateString();
                rFinVar["flagprevision"] = "S";
                rFinVar["variationkind"] = 1; //var. normale
                rFinVar["idfinvarstatus"] = 5;
                foreach (DataRow rvardet in Out.Tables[0].Rows) {
                    DataRow r = mfinvarDetail.Get_New_Row(rFinVar, DS.finvardetail);
                    r["idfin"] = rvardet["idfin"];
                    r["idupb"] = rvardet["idupb"];
                    r["amount"] = rvardet["amount"];
                }
            }

            DataSet Out2 = Conn.CallSP("compute_importflow_assign",
               new object[] { esercizio }, false, 300);
            if (Out2 != null) {
                if (Out2.Tables.Count > 0 && Out2.Tables[0].Rows.Count>0) {
                    DataRow rFinVar2 = mfinvar.Get_New_Row(null, DS.finvar);
                    rFinVar2["official"] = "S";
                    rFinVar2["description"] = "Variazione di storno automatica generata con l'importazione del " + elab.ToShortDateString();
                    rFinVar2["flagprevision"] = "S";
                    rFinVar2["variationkind"] = 4; //var. storno
                    rFinVar2["idfinvarstatus"] = 5;
                    foreach (DataRow rvardet2 in Out2.Tables[0].Rows) {
                        DataRow r = mfinvarDetail.Get_New_Row(rFinVar2, DS.finvardetail);
                        r["idfin"] = rvardet2["idfin"];
                        r["idupb"] = rvardet2["idupb"];
                        r["amount"] = rvardet2["amount"];
                    }

                 

                }
            }

            //TO DO:   display variation rows
            ImpostaCaptionVarBilancio(Out.Tables[0]);
            setgrid(dataGridVarBilancio, Out.Tables[0]);


            ImpostaCaptionStorni(Out2.Tables[0]);
            setgrid(gridstorni, Out2.Tables[0]);


        }


        private void ImpostaCaptionStorni(DataTable T) {
            foreach (DataColumn C in T.Columns)
                MetaData.DescribeAColumn(T, C.ColumnName, "", -1);

            int nPos = 0;
            MetaData.DescribeAColumn(T, "finpart", "E/S", nPos++);
            MetaData.DescribeAColumn(T, "codefin", "Cod.Bilancio", nPos++);
            MetaData.DescribeAColumn(T, "fin", "Bilancio", nPos++);
            MetaData.DescribeAColumn(T, "codeupb", "Cod.UPB", nPos++);
            MetaData.DescribeAColumn(T, "upb", "U.P.B.", nPos++);
            MetaData.DescribeAColumn(T, "amount", "Importo", nPos++);
        }





        private void ImpostaCaptionVarBilancio(DataTable T) {
            foreach (DataColumn C in T.Columns)
                MetaData.DescribeAColumn(T, C.ColumnName, "", -1);

            int nPos = 0;
            MetaData.DescribeAColumn(T, "finpart", "E/S", nPos++); 
            MetaData.DescribeAColumn(T, "codefin", "Cod.Bilancio", nPos++);
            MetaData.DescribeAColumn(T, "fin", "Bilancio", nPos++);
            MetaData.DescribeAColumn(T, "codeupb", "Cod.UPB", nPos++);
            MetaData.DescribeAColumn(T, "upb", "U.P.B.", nPos++);
            MetaData.DescribeAColumn(T, "amount", "Importo", nPos++);
         }

        Dictionary<string, string> dicFin = new Dictionary<string, string>();
        void AddVoceBilancio(object ID, string codbil) {
            if (ID == DBNull.Value) return;
            if (dicFin.ContainsKey(ID.ToString())){
                return;
            }
            dicFin[ID.ToString()] = codbil;
            DataRow NewBil = DS.fin.NewRow();
            NewBil["idfin"] = ID;
            NewBil["codefin"] = codbil;
            DS.fin.Rows.Add(NewBil);
            NewBil.AcceptChanges();
        }


        Dictionary<string, string> dicUpb = new Dictionary<string, string>();
        void AddVoceUpb(object ID, string codupb) {
            if (ID == DBNull.Value) return;
            if (dicUpb.ContainsKey(ID.ToString())) {
                return;
            }
            dicUpb[ID.ToString()] = codupb;

            DataRow NewUpb = DS.upb.NewRow();
            NewUpb["idupb"] = ID;
            NewUpb["codeupb"] = codupb;
            DS.upb.Rows.Add(NewUpb);
            NewUpb.AcceptChanges();
        }

        Dictionary<string, string> dicReg = new Dictionary<string, string>();
        void AddVoceCreditore(object codice, string denominazione) {
            if (codice == DBNull.Value) return;
            if (dicReg.ContainsKey(codice.ToString())) {
                return;
            }
            dicReg[codice.ToString()] = denominazione;

            DataRow NewCred = DS.registry.NewRow();
            NewCred["idreg"] = codice;
            NewCred["title"] = denominazione;
            DS.registry.Rows.Add(NewCred);
            NewCred.AcceptChanges();
        }

        Dictionary<int, int> sorIncPhase = new Dictionary<int, int>();
        void AddSorIncomePhase(object idsor, object nphase) {
            if (idsor == DBNull.Value) return;
            if (nphase == DBNull.Value) return;
            int id = CfgFn.GetNoNullInt32(idsor);
            if (sorIncPhase.ContainsKey(id)) {
                return;
            }
            sorIncPhase[id] = CfgFn.GetNoNullInt32(nphase); 
        }
        int getIncomePhase(object idsor) {
            int id = CfgFn.GetNoNullInt32(idsor);
            if (sorIncPhase.ContainsKey(id)) return sorIncPhase[id];
            return 0;
        }

        Dictionary<int, int> sorExpPhase = new Dictionary<int, int>();
        void AddSorExpensePhase(object idsor, object nphase) {
            if (idsor == DBNull.Value) return;
            if (nphase == DBNull.Value) return;
            int id = CfgFn.GetNoNullInt32(idsor);
            if (sorExpPhase.ContainsKey(id)) {
                return;
            }
            sorExpPhase[id] = CfgFn.GetNoNullInt32(nphase);
        }
        int getExpensePhase(object idsor) {
            int id = CfgFn.GetNoNullInt32(idsor);
            if (sorExpPhase.ContainsKey(id)) return sorExpPhase[id];
            return 0;
        }

        void AddVociCollegate(DataRow SP_Row) {
            AddVoceBilancio(SP_Row["idfin"],
                SP_Row["codefin"].ToString());
            AddVoceBilancio(SP_Row["acc_idfin"],
                SP_Row["acc_codefin"].ToString());
            AddVoceBilancio(SP_Row["imp_idfin"],
                            SP_Row["imp_codefin"].ToString());

            AddVoceUpb(SP_Row["idupb"],
                SP_Row["codeupb"].ToString());
            AddVoceUpb(SP_Row["acc_idupb"],
                SP_Row["acc_codeupb"].ToString());
            AddVoceUpb(SP_Row["imp_idupb"],
                SP_Row["imp_codeupb"].ToString());

            AddVoceCreditore(SP_Row["idreg"],
                SP_Row["registry"].ToString());

            for (int i = 1; i <= 5; i++) {
                if (SP_Row["E_S"].ToString().ToUpper() == "S") {
                    AddSorExpensePhase(SP_Row["idsor" + i.ToString()], SP_Row["idsor" + i.ToString()]);
                }
                else {
                    AddSorIncomePhase(SP_Row["idsor" + i.ToString()], SP_Row["idsor" + i.ToString()]);
                }
            }
        }

    
        /// <summary>
        /// Da chiamare per ogni riga di movimento generata con la corrisp. del flusso
        /// </summary>
        /// <param name="rImportView"></param>
        /// <param name="rMov"></param>
        void ClassificaRiga(DataRow rImportView, DataRow rMov) {
            int movphase = CfgFn.GetNoNullInt32(rMov["nphase"]);
            decimal amount = CfgFn.GetNoNullDecimal(rImportView["importo"]);
            for (int i = 1; i <= 5; i++) {
                object idsor = rImportView["idsor" + i.ToString()];
                if (idsor == DBNull.Value) continue;
                int nphase = CfgFn.GetNoNullInt32(rImportView["nphase" + i.ToString()]);
                if (movphase != nphase) continue;
                if (rMov.Table.TableName == "expense") {
                    MetaData.SetDefault(DS.expensesorted, "idsor", idsor);
                    MetaData.SetDefault(DS.expensesorted, "idexp", rMov["idexp"]);
                    DataRow s = MetaExpenseSorted.Get_New_Row(rMov, DS.expensesorted);
                    s["amount"] = amount;
                    //Se i vale 1 llora sta valorizzando il siope ( idsor1 nella nphase 3)
                    string idupb = rImportView["sel_idupb"].ToString();
                    if ((i == 1)&& UpbUsed.ContainsKey(idupb)) {
                        DataRow rUpb = UpbUsed[idupb];
                        if (rUpb == null) continue;
                        s["values1"] = rUpb["uesiopecode"];
                        s["values2"] = rUpb["cofogmpcode"];
                    }
                }
                else {
                    MetaData.SetDefault(DS.incomesorted, "idsor", idsor);
                    MetaData.SetDefault(DS.incomesorted, "idinc", rMov["idinc"]);
                    DataRow s = MetaIncomeSorted.Get_New_Row(rMov, DS.incomesorted);
                    s["amount"] = amount;

                }
            }
        }



        void VisualizzaMovimenti() {
            if (!movimentigenerati) {
                //svuota grids
                gridEntrata.SetDataBinding(null, "");
                gridSpesa.SetDataBinding(null, "");

                return;
            }

            //riempie incomeview ed expenseview
            DS.incomeview.Clear();
            Riempi("E");//incomeview
            setgrid(gridEntrata, DS.incomeview);

            DS.expenseview.Clear();
            Riempi("S");//expnseview
            setgrid(gridSpesa, DS.expenseview);
        }

        private void Riempi(string EoS) {
            string vName = (EoS == "E") ? "incomeview" : "expenseview";
            string prefix= (EoS == "E") ? "acc_" : "imp_";
            string filerMov = QHS.CmpEq("E_S", EoS);
            DataTable T = DS.Tables[vName];

            foreach (DataRow rImportflow in importflow.Rows) {
                if (rImportflow["E_S"].ToString().ToUpper() != EoS) continue;
                DataRow rIEview = DS.Tables[vName].NewRow();
                if (rImportflow["numero_accimp"] != DBNull.Value) {
                    string phase = EoS == "E" ? getIncPhaseName(rImportflow["parent_phase"]) :
                                        getExpPhaseName(rImportflow["parent_phase"]);
                    phase += rImportflow["numero_accimp"].ToString() + "/" + rImportflow["anno_accimp"].ToString();
                    rIEview["!livprecedente"] = phase;
                }
                rIEview["codefin"] = isnull(rImportflow["codefin"],rImportflow[prefix+"codefin"]);
                rIEview["codeupb"] = isnull(rImportflow["codeupb"], rImportflow[prefix + "codeupb"]);
                rIEview["registry"] = rImportflow["registry"];
                rIEview["amount"] = rImportflow["importo"];
                rIEview["description"] = rImportflow["descrizione_liq"];
                DS.Tables[vName].Rows.Add(rIEview);
            }
            DS.Tables[vName].AcceptChanges();

            //Imposta Caption
            foreach (DataColumn C in T.Columns)
                MetaData.DescribeAColumn(T, C.ColumnName, "", -1);

            int nPos = 0;
            MetaData.DescribeAColumn(T, "!livprecedente", "Fase prec.", nPos++);
            MetaData.DescribeAColumn(T, "codefin", "Cod.Bilancio", nPos++);
            MetaData.DescribeAColumn(T, "codeupb", "Cod.UPB", nPos++);
            MetaData.DescribeAColumn(T, "amount", "Importo", nPos++);
            MetaData.DescribeAColumn(T, "description", "Descrizione", nPos++);


         }





        bool SaveData() {
            if (!GeneraMovimenti()) return false;
            if (!GeneraScritture()) return false;
            if (!DS.HasChanges()) return true;
            PostData p = Meta.Get_PostData();
            p.InitClass(DS, Conn);
            if (!p.DO_POST()) {
                labFinalMsg.Text="Movimenti NON creati.";
            }
            else {
                foreach (DataRow rPay in DS.payment.Select()) {
                    Meta.Conn.CallSP("compute_payment_bank", new object[] { rPay["kpay"] });
                }
                foreach (DataRow rPro in DS.proceeds.Select()) {
                    Meta.Conn.CallSP("compute_proceeds_bank", new object[] { rPro["kpro"] });
                }

                labFinalMsg.Text = "Movimenti creati correttamente.";
            }
            DS.Clear();
            return true;
        }

        /// <summary>
        /// restituisce valori positivi per id entrate, negativi per spese
        /// </summary>
        /// <param name="rImportflow"></param>
        /// <returns></returns>
        int getIdLiqInc(DataRow rImportflow) {
            if (rImportflow["E_S"].ToString().ToUpper().Trim() == "E")
                return  CfgFn.GetNoNullInt32( rImportflow["id_inc"]);
            else
                return  -CfgFn.GetNoNullInt32(rImportflow["id_liq"]);
        }

        Dictionary<string, int> parentid = new Dictionary<string, int>();
        int getIdMov(string idimportflow) {
            string k=idimportflow.ToUpper().Trim();
            DataRow rimp = getFlowRow(k);
            if (rimp != null) return getIdLiqInc(rimp);
            if (parentid.ContainsKey(idimportflow)) return parentid[k];
            int r =CfgFn.GetNoNullInt32( Conn.DO_READ_VALUE("import_flow", QHS.CmpEq("idimportflow", k),
                            "isnull(-id_liq,id_inc)"));
            parentid[k] = r;
            return r;

        }

        //da riempire in fase digenerazione movimenti con le ultime fasi di entrata o spesa di ogni riga del flusso
        Dictionary<string, DataRow> lastRow = new Dictionary<string, DataRow>();
        void CollegaMovimenti() {
            //Collega le entrate alle spese e viceversa
            foreach (DataRow r in DS.import_flow.Rows) {
                object linkedid = r["idimportflow_parent"];
                if (linkedid == DBNull.Value) continue;
                string E_S = r["E_S"].ToString().ToUpper();
                int idlinkedmov = getIdMov(linkedid.ToString());
                if (idlinkedmov==0){
                    show("Movimento collegato alla riga di codice "+linkedid.ToString()+
                        " non trovato.");
                    continue;
                }
                DataRow rLast = lastRow[r["idimportflow"].ToString().ToUpper()];
                if (E_S == "E") {
                    if (idlinkedmov < 0) {
                        rLast["idpayment"] = -idlinkedmov;
                        rLast["autokind"] = 14;
                    }
                    else {
                        show("Non è possibile collegare la riga di codice "+
                            r["idimportflow"].ToString()+" alla riga "+
                            idlinkedmov+ " trattandosi di due entrate.");
                    }
                }
                else {
                    if (idlinkedmov < 0) {
                        rLast["idpayment"] = -idlinkedmov;
                        rLast["autokind"]= 14;
                    }
                    //else {
                    //    rLast["idproceeds"] = idlinkedmov;
                    //}
                }
            }
        }

        bool GeneraMovimenti() {
            if (movimentigenerati) return true;
            if (!GeneraMovimenti("E")) return false;
            if (!GeneraMovimenti("I")) return false;
            CollegaMovimenti();
            movimentigenerati = true;
            return true;
        }
        private int getIntSys(string nome) {
            int s = CfgFn.GetNoNullInt32(Meta.GetSys(nome));
            if (s == 0) return 99;
            return s;
        }

        object isnull(object a, object b) {
            if (a == DBNull.Value) return b;
            if (a.ToString() == "") return b;
            return a;
        }
        static DataTable callSp(DataAccess Conn, List<string> idUpbList) {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("DECLARE @lista AS string_list;");
            int currblockLen = 0;
            foreach (string id in idUpbList) {
                if (currblockLen == 0) {
                    sb.Append($"insert into @lista values ('{id}')");
                }
                else {
                    sb.Append($",('{id}')");
                }

                currblockLen++;
                if (currblockLen == 20) {
                    sb.AppendLine(";");
                    currblockLen = 0;
                }
            }
            if (currblockLen > 0) sb.AppendLine(";");
            sb.AppendLine($"exec  get_upb_info @lista");
            return Conn.SQLRunner(sb.ToString());
        }
        Dictionary<string, DataRow> UpbUsed = new Dictionary<string, DataRow>();

        bool GeneraMovimenti(string IoE) {

            string tMain = (IoE == "I") ? "income" : "expense";
            string tMainYear = (IoE == "I") ? "incomeyear" : "expenseyear";
            string tMainLast = (IoE == "I") ? "incomelast" : "expenselast";
            string tMainSorted = (IoE == "I") ? "incomesorted" : "expensesorted";
            string document = (IoE == "I") ? "proceeds" : "payment";
            string kdocument = (IoE == "I") ? "kpro" : "kpay";
            string idmov_flow = (IoE == "I") ? "id_inc" : "id_liq";
            string tManReve = (IoE == "I") ? "proceeds" : "payment";
            string tEletrasm = (IoE == "I") ? "proceedstransmission" : "paymenttransmission";

            MetaData MetaM = Meta.Dispatcher.Get(tMain);
            MetaM.SetDefaults(DS.Tables[tMain]);

            MetaData MetaL = Meta.Dispatcher.Get(tMainLast);
            MetaL.SetDefaults(DS.Tables[tMainLast]);

            MetaData MetaImputazioneMov = Meta.Dispatcher.Get(tMainYear);
            MetaImputazioneMov.SetDefaults(DS.Tables[tMainYear]);


            MetaData MetaManReve = Meta.Dispatcher.Get(tManReve);
            MetaManReve.SetDefaults(DS.Tables[tManReve]);

            MetaData MetaEletrasm = Meta.Dispatcher.Get(tEletrasm);
            MetaEletrasm.SetDefaults(DS.Tables[tEletrasm]);

            string maxPhaseName = (IoE == "I") ? "maxincomephase" : "maxexpensephase";
            int fasemax = getIntSys(maxPhaseName);

            string regPhaseName = (IoE == "I") ? "incomeregphase" : "expenseregphase";
            int faseCreditoreDebitore = getIntSys(regPhaseName);

            string finPhaseName = (IoE == "I") ? "incomefinphase" : "expensefinphase";
            int faseBilancio = getIntSys(finPhaseName);

            string idMovField = (IoE == "I") ? "idinc" : "idexp";
            string idParMovField = (IoE == "I") ? "parentidinc" : "parentidexp";

            string idAcc = (IoE == "I") ? "idacccredit" : "idaccdebit";
            int esercizio = getIntSys("esercizio");

            DataTable Mov = DS.Tables[tMain];
            DataTable ImpMov = DS.Tables[tMainYear];            

            DataTable AllPaymethod = Conn.RUN_SELECT("paymethod", "*", null, null, null, true);

            DateTime DataCont = Convert.ToDateTime(Meta.GetSys("datacontabile"));
            int flag;
            bool flagrespons;
            bool flagbilancio;
            bool flagcreddeb;
            bool flagresidui;
            object flagautostampa;

            if (IoE == "I") {
                flag = CfgFn.GetNoNullInt32(rConfig["proceeds_flag"]);
                flagautostampa = rConfig["proceeds_flagautoprintdate"];
            }
            else {
                flag = CfgFn.GetNoNullInt32(rConfig["payment_flag"]);
                flagautostampa = rConfig["payment_flagautoprintdate"];
            }
            flagrespons = ((flag & 16) == 16);
            flagbilancio = ((flag & 2) == 2);
            flagcreddeb = ((flag & 4) == 4);
            flagresidui = ((flag & 8) == 8);
            Dictionary<int, DataRow> manrev = new Dictionary<int, DataRow>();
            Dictionary<int, DataRow> eletrasm = new Dictionary<int, DataRow>();
            
            var listaUpbMancanti = new List<string>();

            for (int i = 0; i < importflow.Rows.Count; i++) {
                DataRow R = importflow.Rows[i];
                object idUpbObj = R["sel_idupb"];
                string idupb = idUpbObj.ToString();
                if (!UpbUsed.ContainsKey(idupb)) {
                    UpbUsed[idupb] = null;
                    listaUpbMancanti.Add(idupb);
                }
            }
            if (listaUpbMancanti.Count > 0) {
                DataTable T = callSp(Meta.Conn, new List<string>(listaUpbMancanti));
                if (T != null && T.Columns.Contains("codeupb")) {
                    foreach (DataRow row in T.Rows) {
                        string idupb = row["idupb"].ToString();
                        UpbUsed[idupb] = row;
                    }
                }
            }

            for (int i = 0; i < importflow.Rows.Count; i++) {
                DataRow rv = importflow.Rows[i];
                DataRow r= DS.import_flow.Rows[i];
                string myIoE = r["E_S"].ToString().ToUpper() == "E" ? "I" : "E";
                if (myIoE != IoE) continue;
                decimal amount = CfgFn.RoundValuta(CfgFn.GetNoNullDecimal(rv["importo"]));
                object parentidmov  = isnull(rv["acc_idinc"], rv["imp_idexp"]);
                int parentphase = CfgFn.GetNoNullInt32(rv["parent_phase"]);
                object sel_idreg = rv["sel_idreg"];
                object sel_idfin = rv["sel_idfin"];
                object sel_idman = rv["sel_idman"];
                object sel_idupb = rv["sel_idupb"];

                for (int faseCorrente = parentphase+1; faseCorrente <= fasemax; faseCorrente++) {
                    Mov.Columns["nphase"].DefaultValue = faseCorrente;
                    Mov.Columns[idParMovField].DefaultValue = parentidmov;
                    Mov.Columns["ymov"].DefaultValue = esercizio;

                    DataRow NewMovRow = MetaM.Get_New_Row(null, Mov);

                    //Imposta il movimento parent tramite il livsupid. Il movimento parent è quello generato nella fase precedente
                    NewMovRow[idParMovField] = parentidmov;

                    parentidmov = NewMovRow[idMovField];

                    NewMovRow["ymov"] = esercizio;
                    NewMovRow["adate"] = DataCont; //isnull(r["data_liquidazione"], DataCont);
                    NewMovRow["idman"] = sel_idman;
                    NewMovRow["description"] = isnull(r["descrizione_liq"], "movimento automatico");
                    NewMovRow["doc"] = rv["doc"];
                    NewMovRow["docdate"] = rv["datadoc"];
                    NewMovRow["nphase"] = faseCorrente;
                    NewMovRow["external_reference"] = rv["external_reference"].ToString();


                    if (faseCorrente < faseCreditoreDebitore) {
                        NewMovRow["idreg"] = DBNull.Value;
                    }
                    else {
                        NewMovRow["idreg"] = sel_idreg;
                    }

                    ClassificaRiga(rv, NewMovRow);

                    if (faseCorrente == fasemax) {
                        r[idmov_flow] = NewMovRow[idMovField];
                        lastRow[r["idimportflow"].ToString().ToUpper()] = NewMovRow;

                        DataRow NewLastRow = MetaL.Get_New_Row(NewMovRow, DS.Tables[tMainLast]);
                        if (IoE == "E") {

                            //aggiungere le informazioni della modalità di pagamento
                            NewLastRow["idregistrypaymethod"] = rv["idregistrypaymethod"];
                            NewLastRow["idpaymethod"] = rv["idpaymethod"];
                            NewLastRow["iban"] = rv["iban"];
                            NewLastRow["cin"] = rv["cin"];
                            NewLastRow["idbank"] = rv["idbank"];
                            NewLastRow["idcab"] = rv["idcab"];
                            NewLastRow["cc"] = rv["cc"];
                            NewLastRow["iddeputy"] = rv["iddeputy"];
                            NewLastRow["refexternaldoc"] = rv["refexternaldoc"];
                            NewLastRow["paymentdescr"] = rv["paymentdescr"];
                            NewLastRow["biccode"] = rv["biccode"];
                            NewLastRow["extracode"] = rv["extracode"];
                            object idpaymethod = rv["idpaymethod"];
                            string filterpaymethod = QHC.CmpEq("idpaymethod", idpaymethod);

                            //DataTable TPaymethod = Conn.RUN_SELECT("paymethod", "*", null, filterpaymethod, null, true);
                            DataRow[] pmethods = AllPaymethod.Select(filterpaymethod);

                            if (pmethods.Length > 0) {
                                object paymethod_allowdeputy = pmethods[0]["allowdeputy"];
                                object paymethod_flag = pmethods[0]["flag"];
                                NewLastRow["paymethod_allowdeputy"] = paymethod_allowdeputy;
                                NewLastRow["paymethod_flag"] = paymethod_flag;
                            }
                        }
                        
                        NewLastRow[idAcc] = rv["idacc"];
                        NewLastRow["nbill"]=rv["nbill"];
                        if (rv["nbill"] == DBNull.Value) {
                            NewLastRow["flag"] = 0;
                        }
                        else {
                            NewLastRow["flag"] = 1;
                        }
                        int nmanreve = CfgFn.GetNoNullInt32(r["nmanreve"]);
                        int neletrasm = CfgFn.GetNoNullInt32(r["neletrasm"]);

                        if (faseCorrente == fasemax && r["manrev"].ToString().ToUpper() != "N") {
                            if (IoE == "I") {
                                if (nmanreve > 0 && manrev.ContainsKey(nmanreve)) {
                                    NewLastRow["kpro"] = manrev[nmanreve]["kpro"];
                                }
                                else {
                                    DataRow pro = MetaProceeds.Get_New_Row(null, DS.proceeds);
                                    NewLastRow["kpro"] = pro["kpro"];
                                    pro["idtreasurer"] = isnull(rv["idtreasurer"], idtreasurer_default);
                                    pro["idstamphandling"] = isnull(rv["idstamphandling"], idstamphandling_default);
                                    pro["adate"] = isnull(rv["datacont_manreve"], DataCont);
                                    int iflag = 0;
                                    if (rv["natura_mandato_CMR"].ToString().ToUpper() == "C")
                                        iflag = 1;
                                    if (rv["natura_mandato_CMR"].ToString().ToUpper() == "R")
                                        iflag = 2;
                                    if (rv["natura_mandato_CMR"].ToString().ToUpper() == "M")
                                        iflag = 4;
                                    if (rv["fruttifero"].ToString().ToUpper() == "S")
                                        iflag += 8;
                                    pro["flag"] = iflag;
                                    if (flagcreddeb)
                                        pro["idreg"] = sel_idreg;
                                    if (flagbilancio)
                                        pro["idfin"] = sel_idfin;
                                    if (flagrespons)
                                        pro["idman"] = rv["idman"];

                                    //if ((flagautostampa != null) && (flagautostampa.ToString().ToUpper() == "S")) {
                                    pro["printdate"] = pro["adate"];
                                    //}
                                    manrev[nmanreve] = pro;

                                    if (neletrasm > 0) {
                                        if (eletrasm.ContainsKey(neletrasm)) {
                                            pro["kproceedstransmission"] = eletrasm[neletrasm]["kproceedstransmission"];
                                        }
                                        else {
                                            DataRow trasmPro = MetaEletrasm.Get_New_Row(null, DS.proceedstransmission);
                                            trasmPro["transmissiondate"] = pro["adate"];
                                            trasmPro["idtreasurer"] = isnull(rv["idtreasurer"], idtreasurer_default);
                                            trasmPro["noep"] = "S";
                                            //if (flagrespons)
                                            //    trasmPro["idman"] = rv["idman"];
                                            trasmPro["flagtransmissionenabled"] = "S";
                                            eletrasm[neletrasm] = trasmPro;
                                            pro["kproceedstransmission"] = trasmPro["kproceedstransmission"];
                                        }
                                    }

                                }
                            }
                            else {
                                if (nmanreve > 0 && manrev.ContainsKey(nmanreve)) {
                                    NewLastRow["kpay"] = manrev[nmanreve]["kpay"];
                                }
                                else {
                                    DataRow pay = MetaPayment.Get_New_Row(null, DS.payment);
                                    NewLastRow["kpay"] = pay["kpay"];
                                    pay["idtreasurer"] = isnull(rv["idtreasurer"], idtreasurer_default);
                                    pay["idstamphandling"] = isnull(rv["idstamphandling"], idstamphandling_default);
                                    pay["adate"] = isnull(rv["datacont_manreve"], DataCont);
                                    if (rv["natura_mandato_CMR"].ToString().ToUpper() == "C")
                                        pay["flag"] = 1;
                                    if (rv["natura_mandato_CMR"].ToString().ToUpper() == "R")
                                        pay["flag"] = 2;
                                    if (rv["natura_mandato_CMR"].ToString().ToUpper() == "M")
                                        pay["flag"] = 4;
                                    if (flagcreddeb)
                                        pay["idreg"] = sel_idreg;
                                    if (flagbilancio)
                                        pay["idfin"] = sel_idfin;
                                    if (flagrespons)
                                        pay["idman"] = rv["idman"];
                                    //if ((flagautostampa != null) && (flagautostampa.ToString().ToUpper() == "S")) {
                                    pay["printdate"] = pay["adate"];
                                    //}
                                    manrev[nmanreve] = pay;

                                    if (neletrasm > 0) {
                                        if (eletrasm.ContainsKey(neletrasm)) {
                                            pay["kpaymenttransmission"] = eletrasm[neletrasm]["kpaymenttransmission"];
                                        }
                                        else {
                                            DataRow trasmPro = MetaEletrasm.Get_New_Row(null, DS.paymenttransmission);
                                            trasmPro["transmissiondate"] = pay["adate"];
                                            trasmPro["idtreasurer"] = isnull(rv["idtreasurer"], idtreasurer_default);
                                            trasmPro["noep"] = "S";
                                            //if (flagrespons)
                                            //    trasmPro["idman"] = rv["idman"];
                                            trasmPro["flagtransmissionenabled"] = "S";
                                            eletrasm[neletrasm] = trasmPro;
                                            pay["kpaymenttransmission"] = trasmPro["kpaymenttransmission"];
                                        }
                                    }
                                }
                            }
                        }

                    }

                    DataRow NewImpMov = ImpMov.NewRow();

                    NewImpMov["amount"] = amount;
                    NewImpMov[idMovField] = NewMovRow[idMovField];
                    NewImpMov["ayear"] = esercizio;

                    if (faseCorrente < faseBilancio) {
                        NewImpMov["idfin"] = DBNull.Value;
                        NewImpMov["idupb"] = DBNull.Value;
                    }
                    else {
                        NewImpMov["idfin"] = sel_idfin;
                        NewImpMov["idupb"] = sel_idupb;
                    }
                    ImpMov.Rows.Add(NewImpMov);

                    r["data_elaborazione"] = DateTime.Now;
                }
 
            }

            return true;
        }

        private void btnImport_Click(object sender, EventArgs e) {
            DialogResult dr = openInputFileDlg.ShowDialog();
            if (dr != DialogResult.OK) {
                return;
            }

            string fileName = openInputFileDlg.FileName;
            DataTable T = new DataTable();

            //Aggiungere a T le colonne del foglio excel
            T.Columns.Add(new DataColumn("id_riga",typeof(decimal)));
            T.Columns.Add(new DataColumn("id_ruolo", typeof(decimal)));
            T.Columns.Add(new DataColumn("categoria_ruolo", typeof(decimal)));
            T.Columns.Add(new DataColumn("idreg", typeof(int)));
            T.Columns.Add(new DataColumn("idregistrypaymethod", typeof(int)));
            T.Columns.Add(new DataColumn("data_liquidazione", typeof(DateTime)));
            T.Columns.Add(new DataColumn("causale", typeof(string)));
            T.Columns.Add(new DataColumn("importo", typeof(decimal)));
            T.Columns.Add(new DataColumn("descrizione_liq", typeof(string)));
            T.Columns.Add(new DataColumn("esercizio", typeof(int)));
            T.Columns.Add(new DataColumn("e_s", typeof(string)));
            T.Columns.Add(new DataColumn("codefin", typeof(string)));
            T.Columns.Add(new DataColumn("codeupb", typeof(string)));
            T.Columns.Add(new DataColumn("numero_accimp", typeof(int)));
            T.Columns.Add(new DataColumn("anno_accimp", typeof(int)));
            T.Columns.Add(new DataColumn("nfase_accimp", typeof(int)));
            T.Columns.Add(new DataColumn("codice_siope", typeof(string)));
            T.Columns.Add(new DataColumn("cod_prodotto", typeof(string)));
            T.Columns.Add(new DataColumn("numero_liqinc", typeof(int)));
            T.Columns.Add(new DataColumn("anno_liqinc", typeof(int)));
            T.Columns.Add(new DataColumn("numero_manrev", typeof(int)));
            T.Columns.Add(new DataColumn("anno_manrev", typeof(int)));
            T.Columns.Add(new DataColumn("data_elaborazione", typeof(DateTime)));
            T.Columns.Add(new DataColumn("manrev", typeof(string)));
            T.Columns.Add(new DataColumn("variazione", typeof(string)));
            T.Columns.Add(new DataColumn("partite_giro", typeof(string)));
            T.Columns.Add(new DataColumn("id_riga_padre", typeof(decimal)));
            T.Columns.Add(new DataColumn("regtime", typeof(DateTime)));
            T.Columns.Add(new DataColumn("assegnazione", typeof(string)));
            T.Columns.Add(new DataColumn("codice_trattamento_bollo", typeof(string)));
            T.Columns.Add(new DataColumn("codice_cassiere", typeof(string)));
            T.Columns.Add(new DataColumn("data_contabile_manrev", typeof(DateTime)));
            T.Columns.Add(new DataColumn("documento", typeof(string)));
            T.Columns.Add(new DataColumn("data_documento", typeof(DateTime)));
            T.Columns.Add(new DataColumn("n_bolletta", typeof(int)));
            T.Columns.Add(new DataColumn("natura_mandato", typeof(string)));
            T.Columns.Add(new DataColumn("codice_responsabile", typeof(int)));
            T.Columns.Add(new DataColumn("codiceclass3", typeof(string)));
            T.Columns.Add(new DataColumn("codiceclass4", typeof(string)));
            T.Columns.Add(new DataColumn("codiceclass5", typeof(string)));
            T.Columns.Add(new DataColumn("codicetipoclass3", typeof(string)));
            T.Columns.Add(new DataColumn("codicetipoclass4", typeof(string)));
            T.Columns.Add(new DataColumn("codicetipoclass5", typeof(string)));
            T.Columns.Add(new DataColumn("external_reference", typeof(string)));
            T.Columns.Add(new DataColumn("nmanreve", typeof(int)));
            T.Columns.Add(new DataColumn("neletrasm", typeof(int)));
            
            ExcelImport x = new ExcelImport();
            x.ImportTable(fileName, T);
            SaveImport(T);
            DisplayCounts();

        }
        void SaveImport(DataTable T) {
            esercizio = CfgFn.GetNoNullInt32(Meta.GetSys("esercizio"));
            object codesorSiopeE = Meta.GetSys("codesorkind_siopespese");
            object codesorSiopeS = Meta.GetSys("codesorkind_siopeentrate");
             
            object code001 = Conn.DO_READ_VALUE("upb", QHS.CmpEq("idupb", "0001"), "codeupb");
            DS.import_flow.Clear();
            foreach (DataRow r in T.Rows) {
                DataRow n = DS.import_flow.NewRow();
                foreach (DataColumn C in T.Columns) {
                    if (C.ColumnName == "id_riga") continue;
                    if (C.ColumnName == "manrev") continue;
                    if (C.ColumnName == "variazione") continue;
                    if (C.ColumnName == "assegnazione") continue; 
                    if (C.ColumnName == "id_riga_padre") continue;
                    if (C.ColumnName == "partite_giro") continue;
                    if (C.ColumnName == "causale") continue;
                    if (C.ColumnName == "codice_siope") continue;
                    if (C.ColumnName == "codice_trattamento_bollo") continue;
                    if (C.ColumnName == "codice_cassiere") continue;
                    if (C.ColumnName == "data_contabile_manrev") continue;
                    if (C.ColumnName == "documento") continue;
                    if (C.ColumnName == "data_documento") continue;
                    if (C.ColumnName == "codice_responsabile") continue;
                    if (C.ColumnName == "n_bolletta") continue;
                    if (C.ColumnName == "natura_mandato") continue;
                    if (C.ColumnName == "e_s") continue;
                    if (!DS.import_flow.Columns.Contains(C.ColumnName)) continue;
                    
                    n[C.ColumnName] = r[C.ColumnName];
                }
                n["E_S"]=r["e_s"];
                n["natura_mandato_CMR"] = r["natura_mandato"];
                n["idman"] = r["codice_responsabile"];
                n["nbill"] = r["n_bolletta"];
                n["doc"] = r["documento"];
                n["datadoc"] = r["data_documento"];
                n["datacont_manreve"] = r["data_contabile_manrev"];
                n["cod_cassiere"] = r["codice_cassiere"];
                n["handlingbankcode"] = r["codice_trattamento_bollo"];
                n["idimportflow"] = r["id_riga"];
                n["idimportflow_parent"] = r["id_riga_padre"];
                n["manrev"] = isnull(r["manrev"].ToString().ToUpper(), "S").ToString().Substring(0, 1);
                n["partite_giro"] = isnull(r["partite_giro"].ToString().ToUpper(), "S").ToString().Substring(0, 1);
                n["variazione"] = isnull(r["variazione"].ToString().ToUpper(), "N").ToString().Substring(0, 1);
                n["assegnazione"] = isnull(r["assegnazione"].ToString().ToUpper(), "N").ToString().Substring(0, 1);
                n["sortcode2"] = r["causale"];
                n["sortcode1"] = r["codice_siope"];
                if (n["E_S"].ToString().ToUpper() == "E") {
                    n["codtipoclass1"] = codesorSiopeE;
                    n["codtipoclass2"] = "COAN_E";
                }
                else {
                    n["codtipoclass1"] = codesorSiopeS;
                    n["codtipoclass2"] = "COAN_U";
                }
                n["sortcode3"] = r["codiceclass3"];
                n["sortcode4"] = r["codiceclass4"];
                n["sortcode5"] = r["codiceclass5"];
                n["codtipoclass3"] = r["codicetipoclass3"];
                n["codtipoclass4"] = r["codicetipoclass4"];
                n["codtipoclass5"] = r["codicetipoclass5"];
                if (n["partite_giro"].ToString() == "S" && n["codeupb"] == DBNull.Value &&
                                n["anno_accimp"]==DBNull.Value) {
                                    n["codeupb"] = code001;
                }
                n["nmanreve"] = r["nmanreve"];
                n["neletrasm"] = r["neletrasm"];
                DS.import_flow.Rows.Add(n);
            }
            PostData P = Meta.Get_PostData();
            P.InitClass(DS, Conn);
            P.DO_POST();


        }

        private void btnImportDetail_Click(object sender, EventArgs e) {
            DialogResult dr = openInputFileDlg.ShowDialog();
            if (dr != DialogResult.OK) {
                return;
            }

            string fileName = openInputFileDlg.FileName;
            DataTable T = new DataTable();

            //Aggiungere a T le colonne del foglio excel
            T.Columns.Add(new DataColumn("id_riga", typeof(decimal)));
            T.Columns.Add(new DataColumn("prog_riga", typeof(decimal)));
            T.Columns.Add(new DataColumn("cod_tipopers_ca", typeof(string)));
            T.Columns.Add(new DataColumn("cod_tipofisc_ca", typeof(string)));
            T.Columns.Add(new DataColumn("cod_tipoliq_ca", typeof(string)));
            T.Columns.Add(new DataColumn("idcolonna_ca", typeof(string)));
            T.Columns.Add(new DataColumn("importo", typeof(decimal)));
            T.Columns.Add(new DataColumn("fasi_array", typeof(string)));

            ExcelImport x = new ExcelImport();
            x.ImportTable(fileName, T);
            SaveImportDetail(T);
            DisplayCountsDetail();

        }

        void SaveImportDetail(DataTable T) {
            DS.import_flow_coge.Clear();
            foreach (DataRow r in T.Rows) {
                DataRow n = DS.import_flow_coge.NewRow();
                
                foreach (DataColumn C in T.Columns) {
                    string field = C.ColumnName.ToLower();
                    if (!DS.import_flow_coge.Columns.Contains(C.ColumnName)) continue;

                    n[C.ColumnName] = r[C.ColumnName];
                }
                n["idimportflow"] = r["id_riga"];
                n["idimportflow_prog"] = r["prog_riga"];
                DS.import_flow_coge.Rows.Add(n);
            }
            PostData P = Meta.Get_PostData();
            P.InitClass(DS, Conn);
            P.DO_POST();
        }

        public void DisplayCountsDetail() {            
            importflow_coge = Conn.SQLRunner("SELECT IC.* from import_flow_coge IC join import_flowview I on I.idimportflow=IC.idimportflow WHERE " +
                QHS.AppAnd(QHS.CmpEq("I.esercizio", esercizio),
                               QHS.IsNull("I.id_liq"), QHS.IsNull("I.id_inc")), false, 600);
            importflow_coge.TableName = "import_flow_coge";
            FillIFlowDetail();
            int nentry = importflow_coge.Rows.Count;

            labScritture.Text = nentry.ToString();
        }

        void FillIFlowDetail() {
            DS.import_flow_coge.Clear();
            for (int i = 0; i < importflow_coge.Rows.Count; i++) {
                DataRow s = importflow_coge.Rows[i];
                DataRow d = DS.import_flow_coge.NewRow();
                foreach (DataColumn c in DS.import_flow_coge.Columns)
                    d[c.ColumnName] = s[c.ColumnName];
                DS.import_flow_coge.Rows.Add(d);
            }
            DS.import_flow_coge.AcceptChanges();
        }
   
        class EntryToProcess : IComparable {
            public DataRow rFlow;
            public DataRow rCoge;
            public scritturaInfo i;

            public EntryToProcess(DataRow rFlow, DataRow rCoge,scritturaInfo i, string quintupla) {
                this.rFlow = rFlow;
                this.rCoge = rCoge;
                this.i = i;
                this.quintupla = quintupla;
            }

            public string quintupla;
            public int prog {
                get { return (rCoge != null) ? CfgFn.GetNoNullInt32(rCoge["idimportflow_prog"]) : 0; }
            }
            public int idimportflow {
                get { return (rFlow != null) ? CfgFn.GetNoNullInt32(rFlow["idimportflow"]) : 0; }
            }

            public string entryDescription {
                get {
                    if (i.r == null) return null;
                    string s = "RUOLO ";
                    s += rFlow["id_ruolo"].ToString();
                    s += i.r["des_tipopers"].ToString();
                    s += i.r["descrizione_fase"].ToString();
                    s += " - ";
                    s += i.r["fase"].ToString();
                    s += "-regola ";
                    string RR = i.r["regola"].ToString();
                    if (RR.Length > 5) RR = RR.Substring(0, 5);
                    s += RR;
                    return s;
                }
            }
            public int CompareTo(object obj) {
                if (obj is EntryToProcess) {
                    EntryToProcess t = (EntryToProcess)obj;
                    int res = this.i.fase.CompareTo(t.i.fase);
                    if (res != 0) return res;
                    res = this.i.regola.CompareTo(t.i.regola);
                    if (res != 0) return res;
                    if (this.i.id != t.i.id) return this.i.id - t.i.id;
                    if (this.idimportflow != t.idimportflow) return this.idimportflow - t.idimportflow;
                    return this.prog - t.prog;
                }

                throw new ArgumentException("object is not a scritturaInfo");
            }
        }
        class scritturaInfo  {
          
            public string error;

            public DataRow r;
            public scritturaInfo(DataRow r) {
                this.r = r;
            }
            public string dare {
                get { return (r != null) ? r["idacc_dare"].ToString() : null; }
            }
            public string avere {
                get { return (r != null) ? r["idacc_avere"].ToString() : null; }
            }


            public string causale {
                get { return (r != null) ? r["idaccmotive"].ToString() : null; }
            }
            public int regola {
                get { return (r != null) ? CfgFn.GetNoNullInt32( r["regola"]) : 0; }
            }
            public string fase {
                get { return (r != null) ? r["fase"].ToString() : ""; }
            }
            public int id {
                get { return (r != null) ? CfgFn.GetNoNullInt32( r["ID_ECO_FASE_FLUSSO"]) : 0; }
            }
            
            
            
        }

        Dictionary<string, List<scritturaInfo>> cfgContiDareAvere = new Dictionary<string, List<scritturaInfo>>();
        Dictionary<string, string[]> conti = new Dictionary<string, string[]>();

        void GetContiDare(object cod_tipopers_ca, object cod_tipofisc_ca, object cod_tipoliq_ca, object idcolonna_ca, string fase,
             out List<scritturaInfo> scrInfo, out string quintupla) {
                string key = cod_tipopers_ca.ToString() + cod_tipofisc_ca.ToString() + cod_tipoliq_ca.ToString() + idcolonna_ca.ToString() + fase;
                quintupla = key;
            if (cfgContiDareAvere.ContainsKey(key)) {
                scrInfo = cfgContiDareAvere[key];
                
                return;
            }
            string code2 = cod_tipopers_ca.ToString() + "-" + cod_tipofisc_ca.ToString() + "-" + cod_tipoliq_ca.ToString() + "-" +
                idcolonna_ca.ToString() + "-" + fase;
            scritturaInfo x = new scritturaInfo(null);
            x.error = "Non trovata associazione conti per " + code2;
            scrInfo = new List<scritturaInfo>();
            scrInfo.Add(x);
        }
        
        void ConfigContiDareAvere() {
            cfgContiDareAvere = new Dictionary<string, List<scritturaInfo>>();
            
            DataTable Cfg = Conn.SQLRunner("SELECT U.id_eco_fase_flusso, "+
                            "U.cod_tipopers_ca+U.cod_tipofisc_ca+U.cod_tipoliq_ca+U.idcolonna_ca+U.fase as k,U.idacc_dare,"+
                            "U.idacc_avere,U.dare_codice,U.dare_descrizione,U.avere_codice,U.avere_descrizione,"+
                            " DARE.flagregistry as flagregistry_dare, DARE.flagupb as flagupb_dare," +
                            " substring(U.descrizione_fase,1,80) as descrizione_fase,"+
                            " substring(U.fase,1,2) as fase, "+
                            " U.regola,"+
                            " substring(U.DES_TIPOPERS,1,30) as des_tipopers, " +
                            " AVERE.flagregistry as flagregistry_avere, AVERE.flagupb as flagupb_avere, idaccmotive" +
                            " FROM UNICT_ECO_EMOLUMENTI_PD U "+
                            " left outer join account DARE on U.idacc_dare=DARE.idacc "+
                            " left outer join account AVERE on U.idacc_avere=AVERE.idacc "+
                            " order by fase, regola", false, 300);
            foreach (DataRow r in Cfg.Rows) {
                string key = r["k"].ToString().Trim();
                List<scritturaInfo> info;

                if (cfgContiDareAvere.ContainsKey(key)) {
                    info = cfgContiDareAvere[key];
                }
                else {
                    info = new List<scritturaInfo>();
                    cfgContiDareAvere[key] = info;
                }
                scritturaInfo sc = new scritturaInfo(r);
                info.Add(sc);
                if (!conti.ContainsKey(r["idacc_dare"].ToString())) {
                    conti[r["idacc_dare"].ToString()] = new string[] { r["dare_codice"].ToString(), r["dare_descrizione"].ToString(), 
                                r["flagregistry_dare"].ToString(), r["flagupb_dare"].ToString() };
                }
                if (!conti.ContainsKey(r["idacc_avere"].ToString())) {
                    conti[r["idacc_avere"].ToString()] = new string[] { r["avere_codice"].ToString(), r["avere_descrizione"].ToString(), 
                                r["flagregistry_avere"].ToString(), r["flagupb_avere"].ToString() };
                }
            }
        }

        bool scritturegenerate = false;
        bool GeneraScritture() {
            if (scritturegenerate) return true;
            if (!IGeneraScritture()) return false;
            scritturegenerate = true;
            return true;
        }





        bool IGeneraScritture() {
            if (importflow_coge == null) return true;
            if (importflow_coge.Rows.Count == 0) return true;
            MetaData MetaE = Meta.Dispatcher.Get("entry");
            DataTable Entry = DS.Tables["entry"];
            MetaE.SetDefaults(Entry);

            MetaData MetaED = Meta.Dispatcher.Get("entrydetail");
            DataTable EntryDetail = DS.Tables["entrydetail"];
            MetaE.SetDefaults(EntryDetail);

            ConfigContiDareAvere();
            //Importo positivo: AVERE
            EP_functions ep = new EP_functions(Meta.Dispatcher);
            List<EntryToProcess> all = new List<EntryToProcess>();
            foreach (DataRow r in importflow_coge.Rows) {
                string idimportflow = r["idimportflow"].ToString();
                string idimportflow_prog = r["idimportflow_prog"].ToString();
                DataRow rFlow = getFlowViewRow(idimportflow);

                string[] fasi = r["fasi_array"].ToString().Split(' ');
                foreach (string faseout in fasi) {
                    string fase = faseout.Trim();
                    if (fase == "") continue;

                    List<scritturaInfo> dareavere;
                    string quintupla;

                    GetContiDare(r["cod_tipopers_ca"], r["cod_tipofisc_ca"], r["cod_tipoliq_ca"], r["idcolonna_ca"], fase,
                       out dareavere, out quintupla);

                    if (dareavere.Count == 0) {
                        continue;
                    }
                    foreach (scritturaInfo sc in dareavere) {
                        EntryToProcess d = new EntryToProcess(rFlow, r, sc, quintupla);
                        all.Add(d);
                    }
                }

            }

            all.Sort();

            DataRow rEntry = null;
            string lastQuintupla = null;
            int lastIdImportFlow = -1;
            int lastRegola = -12;
            foreach (EntryToProcess i in all) {
                DataRow r = i.rFlow;
                DataRow rCoge = i.rCoge;
                string codice, conto;
                bool flagRegistry, flagUpb;
                decimal importo = CfgFn.GetNoNullDecimal(rCoge["importo"]);

                if (lastQuintupla != i.quintupla || lastRegola != i.i.regola || lastIdImportFlow != i.idimportflow) {
                    lastQuintupla = i.quintupla;
                    lastRegola = i.i.regola;
                    lastIdImportFlow = i.idimportflow;
                    rEntry = MetaE.Get_New_Row(null, Entry);
                    string idrelated = EP_functions.GetIDForDocumentChild(r, i.i.fase);
                    rEntry["idrelated"] = idrelated;
                    rEntry["description"] = i.entryDescription;
                }

                string idacc = i.i.dare;
                if (idacc != null && idacc != "") {
                    DataRow det = MetaED.Get_New_Row(rEntry, EntryDetail);
                    det["importcode"] = i.quintupla;
                    det["amount"] = -importo;
                    det["idacc"] = idacc;
                    if (i.i.causale != null) {
                        det["idaccmotive"] = i.i.causale;
                    }
                    getCodiceDescrizioneConto(idacc, i.idimportflow + "/" + i.prog, out codice, out conto, out flagRegistry, out flagUpb);
                    det["!codice"] = codice;
                    det["!conto"] = conto;
                    det["!dare"] = importo;
                    if (flagRegistry) det["idreg"] = i.rFlow["sel_idreg"];
                    if (flagUpb) det["idupb"] = i.rFlow["sel_idupb"];
                    //det["description"] = "idimportflow:" + i.idimportflow.ToString() + ", prog:" + i.prog.ToString() + " quintupla:"+i.quintupla;
                }

                
                idacc = i.i.avere;
                if (idacc != null && idacc != "") {
                    DataRow det = MetaED.Get_New_Row(rEntry, EntryDetail);
                    det["importcode"] = i.quintupla;
                    det["amount"] = importo;
                    det["idacc"] = idacc;
                    if (i.i.causale != null) {
                        det["idaccmotive"] = i.i.causale;
                    }
                    getCodiceDescrizioneConto(idacc, i.idimportflow + "/" + i.prog, out codice, out conto, out flagRegistry, out flagUpb);
                    det["!codice"] = codice;
                    det["!conto"] = conto;
                    det["!avere"] = importo;
                    //det["description"] = "idimportflow:" + i.idimportflow.ToString() + ", prog:" + i.prog.ToString() + " quintupla:" + i.quintupla;
                    if (flagRegistry) det["idreg"] = i.rFlow["sel_idreg"];
                    if (flagUpb) det["idupb"] = i.rFlow["sel_idupb"];
                }


            }


            return true;
        }
        bool getCodiceDescrizioneConto(string idacc, string idimportflow, out string code, out string conto, out bool registry, out bool upb) {
            registry = false;
            upb = false;
            if (conti.ContainsKey(idacc)){
                string[] x = conti[idacc];
                code = x[0];
                conto = x[1];
                registry = x[2].ToString().ToUpper() == "S";
                upb = x[3].ToString().ToUpper() == "S";
                return true;
            }
            code = "-";
            conto = "NOT FOUND:" + idacc + "(tipopers-tipofisc-tipoliq-colonna_ca-fase) alla riga:" + idimportflow;
            return false;
        }

        void VisualizzaScritture() {
            if (DS.entrydetail.Rows.Count==0) {
                //svuota grids
                dgridScritture.SetDataBinding(null, "");
                return;
            }
            //Imposta Caption
            DataTable T = DS.entrydetail;
            foreach (DataColumn C in T.Columns)
                MetaData.DescribeAColumn(T, C.ColumnName, "", -1);

            int nPos = 0;
            MetaData.DescribeAColumn(T, "!codice", "Codice", nPos++);
            MetaData.DescribeAColumn(T, "!conto", "Conto", nPos++);
            MetaData.DescribeAColumn(T, "!dare", "Dare", nPos++);
            MetaData.DescribeAColumn(T, "!avere", "Avere", nPos++);
            //riempie incomeview ed expenseview
            setgrid(dgridScritture, DS.entrydetail);

        }

    }
}
