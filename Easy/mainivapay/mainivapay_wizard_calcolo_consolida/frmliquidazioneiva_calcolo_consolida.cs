
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
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using metadatalibrary;
using metaeasylibrary;
using System.Data;
using funzioni_configurazione;
using ep_functions;
using movimentofunctions;

namespace mainivapay_wizard_calcolo_consolida {
    public partial class frmliquidazioneiva_calcolo_consolida : MetaDataForm {
        MetaData Meta;
        QueryHelper QHS;
        CQueryHelper QHC;
        MetaDataDispatcher Disp;
        private Hashtable errmsg = null;
        private string CustomTitle;
        private DataAccess Conn;
        private object esercizio;
        private string tag_perc = "tabella.campo.fixed.2..%.100";
        private object maxfasespesa;
        private object maxfaseentrata;
        private Hashtable RighePadriEntrata;
        private Hashtable RighePadriSpesa;
        private DataTable TAutomatismi;
        private DateTime m_ToDate;
        private int m_PeriodicitaGiorno = 1;
        private int m_PeriodicitaMese = 1;
        private int periodo = 1;// <-- Assegniamo un default mensile
        bool ModoCalcolo_RigaPerRiga = true;
        bool GeneraTuttelafasi = true;


        public frmliquidazioneiva_calcolo_consolida() {
            InitializeComponent();
            tabController.HideTabsMode =
            Crownwood.Magic.Controls.TabControl.HideTabsModes.HideAlways;
            //GetData.CacheTable(DS.ivapayperiodicity);
            GetData.CacheTable(DS.config);
            GetData.CacheTable(DS.incomephase);
            GetData.CacheTable(DS.expensephase);
            GetData.SetSorting(DS.incomeview, "ymov DESC,nmov DESC");
            GetData.SetSorting(DS.expenseview, "ymov DESC,nmov DESC");
        }

        public void MetaData_AfterLink(){
            txtMese.Visible = false;
            errmsg = new Hashtable();
            errmsg.Add("err_persiva", "Impossibile proseguire. Non è stata definita la configurazione " +
                "del modulo IVA relativa all'esercizio corrente");
            // La periodicità nella liquidazione consolidata è mensile. Il periodo è stato valorizzato a 1 per defualt.
            //errmsg.Add("err_codicetipoper", "Impossibile proseguire. Non è stato associato nessun tipo di " +
            //    "liquidazione periodica nella configurazione IVA relativo all'esercizio corrente");
            //errmsg.Add("err_periodo", "Impossibile proseguire. Non è stato configurato correttamente il tipo di periodicità " +
            //    "della liquidazione IVA");
            errmsg.Add("err_mainpaymentagency", "Impossibile proseguire. Non è stata configurata l'anagrafica per i movimenti finanziari di spesa " +
                "della liquidazione IVA");
            errmsg.Add("err_mainrefundagency", "Impossibile proseguire. Non è stata configurata l'anagrafica per i movimenti finanziari di entrata " +
               "della liquidazione IVA");
            errmsg.Add("err_mainpaymentfin", "Impossibile proseguire. Non è stata configurata la voce di bilancio per i movimenti finanziari di spesa " +
               "della liquidazione IVA");
            errmsg.Add("err_mainrefundfin", "Impossibile proseguire. Non è stata configurata la voce di bilancio per i movimenti finanziari di entrata " +
               "della liquidazione IVA");

            errmsg.Add("err_paymentagency12", "Impossibile proseguire. Non è stata configurata l'anagrafica per i movimenti finanziari di spesa " +
                "della liquidazione IVA istituzionale Intra e Extra-UE");
            errmsg.Add("err_refundagency12", "Impossibile proseguire. Non è stata configurata l'anagrafica per i movimenti finanziari di entrata " +
               "della liquidazione IVA istituzionale Intra e Extra-UE");
            errmsg.Add("err_paymentfin12", "Impossibile proseguire. Non è stata configurata la voce di bilancio per i movimenti finanziari di spesa " +
               "della liquidazione IVA istituzionale Intra e Extra-UE");
            errmsg.Add("err_refundfin12", "Impossibile proseguire. Non è stata configurata la voce di bilancio per i movimenti finanziari di entrata " +
               "della liquidazione IVA istituzionale Intra e Extra-UE");

            errmsg.Add("err_paymentagencysplit", "Impossibile proseguire. Non è stata configurata l'anagrafica per i movimenti finanziari di spesa " +
                "della liquidazione IVA istituzionale Split Payment");
            errmsg.Add("err_paymentfinsplit", "Impossibile proseguire. Non è stata configurata la voce di bilancio per i movimenti finanziari di spesa " +
               "della liquidazione IVA istituzionale Split Payment");
    

            Meta = MetaData.GetMetaData(this);
            this.Conn = Meta.Conn;
            this.Disp = Meta.Dispatcher;
            QHC = new CQueryHelper();
            QHS = Meta.Conn.GetQueryHelper();

            Meta.CanCancel = false;
            Meta.CanInsert = false;
            Meta.CanInsertCopy = false;
            Meta.CanSave = false;
            Meta.SearchEnabled = false;
            esercizio = Meta.GetSys("esercizio");
            string filterEsercizio = QHS.CmpEq("ayear", esercizio);
            GetData.SetStaticFilter(DS.config, filterEsercizio);
            GetData.CacheTable(DS.invoicekind);
            GetData.CacheTable(DS.invoicekindyear, filterEsercizio, null, false);

            bool IsAmministrazione = false;
            if (Meta.GetSys("userdb") != null){
                IsAmministrazione = (Meta.GetSys("userdb").ToString().ToLower() == "amministrazione");
            }
            btnNext.Visible = IsAmministrazione;
            if (!IsAmministrazione){
                show("Questa procedura può essere eseguita solo dall'Amministrazione Centrale", "Attenzione",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        public void MetaData_AfterActivation()
        {
            FormInit();

            maxfaseentrata = Meta.GetSys("maxincomephase");
            maxfasespesa = Meta.GetSys("maxexpensephase");
            DataRow CfgRow = DS.config.Rows[0];
            if (CfgRow["flagivapaybyrow"].ToString().ToUpper() == "S")
                ModoCalcolo_RigaPerRiga = true;
            else
                ModoCalcolo_RigaPerRiga = false;
            if (CfgRow["mainflagivaregphase"].ToString().ToUpper() == "S")
                GeneraTuttelafasi = false;
            else
                GeneraTuttelafasi = true;
            startivabalance = CfgFn.GetNoNullDecimal(CfgRow["mainstartivabalance"]);
            startivabalance12 = CfgFn.GetNoNullDecimal(CfgRow["mainstartivabalance12"]);
            startivabalancesplit = CfgFn.GetNoNullDecimal(CfgRow["mainstartivabalancesplit"]);
        }

        private void FormInit()
        {
            CustomTitle = "Calcola liquidazione periodica";
            txtProrata.Enter += new EventHandler(txtProrata_Enter);
            txtProrata.Leave += new EventHandler(txtProrata_Leave);
            txtPromiscuo.Enter += new EventHandler(txtPromiscuo_Enter);
            txtPromiscuo.Leave += new EventHandler(txtPromiscuo_Leave);
            CheckInit();
            //Selects first tab
            DisplayTabs(0);
            // Se il mese della data corrente è dicembre,
            // visualizza il checkbox che consente di
            // cambiare il periodo di riferimento
            // forzando la liquidazione relativa a tale mese 
            // invece del periodo precedente come avviene di norma
            //calcolo periodo
            DateTime data = ((DateTime)Meta.GetSys("datacontabile"));
            int month = data.Month;
            if (month == 12) chkEndOfYear.Visible = true;
            else chkEndOfYear.Visible = false;
            chkEndOfYear.Text = chkEndOfYear.Text + "" + HelpForm.StringValue(data.Year, null);
        }

        /// <summary>
        /// Controlla la presenza di righe di configurazione, persiva e tipoliquidperiodiva
        /// </summary>
        private void CheckInit(){
            if (DS.config.Rows.Count == 0) {
                ShowMsg(errmsg["err_persiva"].ToString());
                btnNext.Enabled = false;
                AllDisabled = true;
                return;
            }
            // Nella liquidazione consolidata no n abbiamo la peridocità, o meglio le periodicità è mensile.
            //if (DS.config.Rows[0]["idivapayperiodicity"].ToString() == ""){
            //    ShowMsg(errmsg["err_codicetipoper"].ToString());
            //    btnNext.Enabled = false;
            //    return;
            //}

            if ((DS.config.Rows[0]["mainflagpayment"].ToString().ToUpper() == "S") &&
                    (DS.config.Rows[0]["mainpaymentagency"] == DBNull.Value)) {
                ShowMsg(errmsg["err_mainpaymentagency"].ToString());
                btnNext.Enabled = false;
                AllDisabled = true;
                return;
            }
            if ((DS.config.Rows[0]["mainflagrefund"].ToString().ToUpper() == "S") &&
                    (DS.config.Rows[0]["mainrefundagency"] == DBNull.Value)){
                ShowMsg(errmsg["err_mainrefundagency"].ToString());
                btnNext.Enabled = false;
                AllDisabled = true;
                return;
            }

            if ((DS.config.Rows[0]["mainflagpayment"].ToString().ToUpper() == "S") &&
                    (DS.config.Rows[0]["mainidfinivapayment"] == DBNull.Value)) {
                ShowMsg(errmsg["err_mainpaymentfin"].ToString());
                btnNext.Enabled = false;
                AllDisabled = true;
                return;
            }
            if ((DS.config.Rows[0]["mainflagrefund"].ToString().ToUpper() == "S") &&
                    (DS.config.Rows[0]["mainidfinivarefund"] == DBNull.Value))  {
                ShowMsg(errmsg["err_mainrefundfin"].ToString());
                btnNext.Enabled = false;
                AllDisabled = true;
                return;
            }
            if ((DS.config.Rows[0]["flagpayment12"].ToString().ToUpper() == "S") &&
                    (DS.config.Rows[0]["paymentagency12"] == DBNull.Value)){
                ShowMsg(errmsg["err_paymentagency12"].ToString());
                btnNext.Enabled = false;
                AllDisabled = true;
                return;
            }
            if ((DS.config.Rows[0]["flagrefund12"].ToString().ToUpper() == "S") &&
                    (DS.config.Rows[0]["refundagency12"] == DBNull.Value)){
                ShowMsg(errmsg["err_refundagency12"].ToString());
                btnNext.Enabled = false;
                AllDisabled = true;
                return;
            }
            if ((DS.config.Rows[0]["flagpayment12"].ToString().ToUpper() == "S") &&
                  (DS.config.Rows[0]["idfinivapayment12"] == DBNull.Value)){
                ShowMsg(errmsg["err_paymentfin12"].ToString());
                btnNext.Enabled = false;
                AllDisabled = true;
                return;
            }

            if ((DS.config.Rows[0]["flagrefund12"].ToString().ToUpper() == "S") &&
                    (DS.config.Rows[0]["idfinivarefund12"] == DBNull.Value)){
                ShowMsg(errmsg["err_refundfin12"].ToString());
                btnNext.Enabled = false;
                AllDisabled = true;
                return;
            }
            if ((DS.config.Rows[0]["flagpaymentsplit"].ToString().ToUpper() == "S") &&
                    (DS.config.Rows[0]["paymentagencysplit"] == DBNull.Value)) {
                ShowMsg(errmsg["err_paymentagencysplit"].ToString());
                btnNext.Enabled = false;
                AllDisabled = true;
                return;
            }
            if ((DS.config.Rows[0]["flagpaymentsplit"].ToString().ToUpper() == "S") &&
                 (DS.config.Rows[0]["idfinivapaymentsplit"] == DBNull.Value)) {
                ShowMsg(errmsg["err_paymentfinsplit"].ToString());
                btnNext.Enabled = false;
                AllDisabled = true;
                return;
            }


            //DataRow Rperiodo = DS.config.Rows[0].GetParentRow("ivapayperiodicity_config");
            //if (Rperiodo == null ||
            //    Rperiodo["periodicity"].ToString() == "" ||
            //    Rperiodo["periodicday"].ToString() == "" ||
            //    Rperiodo["periodicmonth"].ToString() == "")  {
            //    ShowMsg(errmsg["err_periodo"].ToString());
            //    btnNext.Enabled = false;
            //    return;
            //}
            //m_PeriodicitaGiorno = CfgFn.GetNoNullInt32(Rperiodo["periodicday"]);
            //if (m_PeriodicitaGiorno < 0) m_PeriodicitaGiorno = 1;
            //m_PeriodicitaMese = CfgFn.GetNoNullInt32(Rperiodo["periodicmonth"]);
            //if (m_PeriodicitaMese < 0) m_PeriodicitaMese = 1;

            //txtPeriodicita.Text = Rperiodo["description"].ToString();
            //periodo = CfgFn.GetNoNullInt32(Rperiodo["periodicity"]);
            //if (periodo <= 0)  {
            //    ShowMsg(errmsg["err_periodo"].ToString());
            //    btnNext.Enabled = false;
            //    return;
            //}

            //calcolo periodo
            ComputePeriod(periodo);

            int anno_rif = m_ToDate.Year;
            string f_anno = QHS.CmpEq("ayear", anno_rif);

            //default
            txtProrata.Text = "100,00 %";
            DataAccess.RUN_SELECT_INTO_TABLE(Meta.Conn, DS.iva_prorata, null, f_anno, null, true);
            if (DS.iva_prorata.Rows.Count > 0)
            {
                txtProrata.Text = HelpForm.StringValue(DS.iva_prorata.Rows[0]["prorata"], tag_perc);
            }
            //default
            txtPromiscuo.Text = "100,00 %";
            DataAccess.RUN_SELECT_INTO_TABLE(Meta.Conn, DS.iva_mixed, null, f_anno, null, true);
            if (DS.iva_mixed.Rows.Count > 0)
            {
                txtPromiscuo.Text = HelpForm.StringValue(DS.iva_mixed.Rows[0]["mixed"], tag_perc);
            }
            chkCommerciale.Checked = true;
            chkIstituzionale.Checked = true;
        }

        private void txtProrata_Enter(object sender, EventArgs e)
        {
            HelpForm.ExtEnterNumTextBox(txtProrata, tag_perc);
        }
        private void txtProrata_Leave(object sender, EventArgs e)
        {
            HelpForm.ExtLeaveNumTextBox(txtProrata, tag_perc);
        }
        private void txtPromiscuo_Enter(object sender, EventArgs e)
        {
            HelpForm.ExtEnterNumTextBox(txtPromiscuo, tag_perc);
        }
        private void txtPromiscuo_Leave(object sender, EventArgs e)
        {
            HelpForm.ExtLeaveNumTextBox(txtPromiscuo, tag_perc);
        }

        /// <summary>
        /// Messaggi di warning
        /// </summary>
        private void ShowMsg(string msg)
        {
            ShowMsg(msg, null);
        }
        /// <summary>
        /// Errori
        /// </summary>
        private void ShowMsg(string msg, string error)
        {
            if (error == null || error == "")
                show(msg, "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            else
                QueryCreator.ShowError(this, msg, error);
        }

        private void btnBack_Click(object sender, EventArgs e) {
            StandardChangeTab(-1);

        }

        private void btnNext_Click(object sender, EventArgs e) {
            StandardChangeTab(+1);
        }
        /// <summary>
        /// Displays tab n. NewTab and updates buttons
        /// </summary>
        /// <param name="newTab"></param>
        private void DisplayTabs(int newTab)
        {
            tabController.SelectedIndex = newTab;
            //Evaluates Buttons Appearance
            btnBack.Visible = (newTab > 0) && (AllDisabled == false);
            if (newTab == tabController.TabPages.Count - 1)
                btnNext.Text = "Fine.";
            else
                btnNext.Text = "Avanti >";
            Text = CustomTitle + " (Pagina " + (newTab + 1) + " di " + tabController.TabPages.Count + ")";
            btnNext.Enabled = (AllDisabled == false);
        }
        bool AllDisabled = false;
        /// <summary>
        /// Changes tab backward/forward
        /// </summary>
        /// <param name="step"></param>
        private void StandardChangeTab(int step)  {
            int oldTab = tabController.SelectedIndex;
            int newTab = oldTab + step;
            if ((newTab < 0) || (newTab > tabController.TabPages.Count)) return;
            if (!CustomChangeTab(oldTab, newTab)) return;
            if (newTab == tabController.TabPages.Count)
            {
                btnNext.Visible = false;
                btnBack.Visible = false;
                btnCancel.Text = "Chiudi";
                AllDisabled = true;
                return;
            }
            DisplayTabs(newTab);
        }
        private void CheckDefault()
        {
            object obj = HelpForm.GetObjectFromString(typeof(decimal), txtProrata.Text, tag_perc);
            if (obj == DBNull.Value) txtProrata.Text = "100,00 %";
            obj = HelpForm.GetObjectFromString(typeof(decimal), txtPromiscuo.Text, tag_perc);
            if (obj == DBNull.Value) txtPromiscuo.Text = "100,00 %";
        }

        /// <summary>
        /// Must return true if operation is possible, and do any
        ///  operation related to change from tab oldTab to newTab
        /// </summary>
        /// <param name="oldTab"></param>
        /// <param name="newTab"></param>
        /// <returns></returns>
        /// 
        bool CustomChangeTab(int oldTab, int newTab) {
            if (AllDisabled) return false;
            if ((oldTab == 0) && (newTab == 1))
            {
                CheckDefault();
                if (!((chkCommerciale.Checked) || (chkIstituzionale.Checked)))
                {
                    show(this, "Selezionare il Tipo liquidazione");
                    return false;
                }
                if (!CalcolaLiquidazione()) return false;
                if (!EsistenzaMappaturaUnifiedRegister()) return false;
                CalcolaTotali();
                CalcolaIVA();
                return true;
            }

            if ((oldTab == 1) && (newTab == 2))
            {
                AbilitaCollegaMovEsistente();
                return GeneraMovimenti();
            }
            if ((oldTab == 2) && (newTab == 3))
            {
                SaveData();
            }
            return true;
        }

        private void AbilitaCollegaMovEsistente(){
            int faselastI = (GeneraTuttelafasi) ? getIntSys("maxincomephase") : getIntSys("incomeregphase");
            if (faselastI == 1)
                btnCollegaE.Enabled = false;
            else
                btnCollegaE.Enabled = true;

            int faselastE = (GeneraTuttelafasi) ? getIntSys("maxexpensephase") : getIntSys("expenseregphase");
            if (faselastE == 1)
                btnCollegaS.Enabled = false;
            else
                btnCollegaS.Enabled = true;
        }

        private int getIntSys(string nome)
        {
            int s = CfgFn.GetNoNullInt32(Meta.GetSys(nome));
            if (s == 0) return 99;
            return s;
        }

        private bool GeneraMovimenti(){
            DataTable movimentiIVA = CalcolaMovFinanziari(TableIva);
            if (movimentiIVA == null) return false;
            if (movimentiIVA.Rows.Count == 0) return true;
            TAutomatismi = movimentiIVA;
            RighePadriEntrata = new Hashtable();
            RighePadriSpesa = new Hashtable();
            FillTables(TAutomatismi.Select());
            return true;
        }

        private void FillTables(DataRow[] Automatismi)   {
            DS.expenseview.Clear();
            DS.incomeview.Clear();
            for (int i = 0; i < Automatismi.Length; i++){
                DataRow R = Automatismi[i];
                switch (R["movkind"].ToString().ToLower()){
                    case "spesa":{
                            AddRowToTable(R, DS.expenseview, i);
                            break;
                        }
                    case "entrata":{
                            AddRowToTable(R, DS.incomeview, i);
                            break;
                        }
                }
            }
            MetaData MSpesaView = Disp.Get("expenseview");
            MSpesaView.DescribeColumns(DS.expenseview, "autogeneratips");

            MetaData MEntrataView = Disp.Get("incomeview");
            MEntrataView.DescribeColumns(DS.incomeview, "autogeneratips");

            HelpForm.SetDataGrid(gridEntrata, DS.incomeview);
            HelpForm.SetDataGrid(gridSpesa, DS.expenseview);

            RicalcolaCampiCalcolati();
        }

        private void RicalcolaCampiCalcolati(){
            string denominazioneFasi = "";
            string faseDA ="", faseA ="";

            if (GeneraTuttelafasi){
                denominazioneFasi = "Tutte";
            }
            else{
                faseDA = DS.expensephase.Select(QHC.CmpEq("nphase", 1))[0]["description"].ToString();
                faseA = DS.expensephase.Select(QHC.CmpEq("nphase", getIntSys("expenseregphase")))[0]["description"].ToString();
                denominazioneFasi = (faseDA!=faseA) ? ("Da " + faseDA + " a " + faseA) : (faseDA);
            }

            foreach (DataRow RS in DS.expenseview.Rows){
                object livsup = RS["parentidexp"];
                int nfasesup = CfgFn.GetNoNullInt32(Conn.DO_READ_VALUE("expense", QHS.CmpEq("idexp", livsup), "nphase"));
                if (livsup != DBNull.Value){
                    DataRow Sup = (DataRow)RighePadriSpesa[livsup];
                    string nomefasesup = DS.expensephase.Select(QHC.CmpEq("nphase", nfasesup))[0]["description"].ToString();
                    string nomefasesup2 = DS.expensephase.Select(QHC.CmpEq("nphase", nfasesup + 1))[0]["description"].ToString();
                    RS["!livprecedente"] = nomefasesup + " " +
                        Sup["ymov"].ToString() + "/" +
                        Sup["nmov"].ToString();
                    string nomefasemax = DS.expensephase.Select(QHC.CmpEq("nphase", maxfasespesa))[0]["description"].ToString();
                    if (nomefasesup2 != nomefasemax)
                        RS["phase"] = "Da " + nomefasesup2 + " a " + nomefasemax;
                    else
                        RS["phase"] = nomefasemax;
                }
                else{
                    RS["!livprecedente"] = "";
                    RS["phase"] = denominazioneFasi;
                }
            }

            if (GeneraTuttelafasi){
                denominazioneFasi = "Tutte";
            }
            else{
                faseDA = DS.incomephase.Select(QHC.CmpEq("nphase", 1))[0]["description"].ToString();
                faseA = DS.incomephase.Select(QHC.CmpEq("nphase", getIntSys("incomeregphase")))[0]["description"].ToString();
                denominazioneFasi = (faseDA != faseA) ? ("Da " + faseDA + " a " + faseA) : (faseDA);
            }

            foreach (DataRow RS in DS.incomeview.Rows){
                object livsup = RS["parentidinc"];
                int nfasesup = CfgFn.GetNoNullInt32(Conn.DO_READ_VALUE("income", QHS.CmpEq("idinc", livsup), "nphase"));
                if (livsup != DBNull.Value){
                    DataRow Sup = (DataRow)RighePadriEntrata[livsup];
                    string nomefasesup = DS.incomephase.Select(QHC.CmpEq("nphase", nfasesup))[0]["description"].ToString();
                    string nomefasesup2 = DS.incomephase.Select(QHC.CmpEq("nphase", nfasesup + 1))[0]["description"].ToString();
                    RS["!livprecedente"] = nomefasesup + " " +
                        Sup["ymov"].ToString() + "/" +
                        Sup["nmov"].ToString();
                    string nomefasemax = DS.incomephase.Select(QHC.CmpEq("nphase", maxfaseentrata))[0]["description"].ToString();
                    if (nomefasesup2 != nomefasemax)
                        RS["phase"] = "Da " + nomefasesup2 + " a " + nomefasemax;
                    else
                        RS["phase"] = nomefasesup2;
                }
                else{
                    RS["!livprecedente"] = "";
                    RS["phase"] = denominazioneFasi;
                }
            }
            formatgrids FGSpesa = new formatgrids(gridSpesa);
            FGSpesa.AutosizeColumnWidth();
            formatgrids FGEntrata = new formatgrids(gridEntrata);
            FGEntrata.AutosizeColumnWidth();
            DS.expenseview.AcceptChanges();
            DS.incomeview.AcceptChanges();
        }

        private void AddRowToTable(DataRow R, DataTable T, int i)
        {
            Meta.SetDefaults(T);
            DataRow NewR = T.NewRow();
            if (T.TableName == "incomeview"){
                NewR["idinc"] = i;
            }
            if (T.TableName == "expenseview"){
                NewR["idexp"] = i;
            }
            string descr = "Liquidazione periodica IVA";
            bool intra12 = false;
            if (R["autokind"].ToString() == "17") intra12 = true;
            if (intra12) descr = "Liquidazione periodica IVA Istituzionale Intra e Extra-UE";

            NewR["description"] = descr + "- Mese " + txtMeseNome.Text + " / " + txtEsercizio.Text;
                
            foreach (DataColumn C in R.Table.Columns){
                if (C.ColumnName == "movkind") continue;
                if (T.Columns[C.ColumnName] == null) continue;
                NewR[C.ColumnName] = R[C.ColumnName];
            }
            T.Rows.Add(NewR);
        }

        /// <summary>
        /// Metodo che calcola i movimenti finanziari inerenti la liquidazione IVA
        /// </summary>
        /// <param name="dettagliLiquidazione">Tabella con tutti i documenti IVA che vengono liquidati</param>
        /// <returns>DataTable dei movimenti finanziari</returns>

        private DataTable CalcolaMovFinanziari(DataTable dettagliLiquidazione){
            DataTable movimentiIVA = new DataTable();
            movimentiIVA.TableName = "movimentiiva";
            movimentiIVA.Columns.Add("movkind", typeof(string));
            movimentiIVA.Columns.Add("idreg", typeof(decimal));
            movimentiIVA.Columns.Add("idfin", typeof(int));
            movimentiIVA.Columns.Add("idupb", typeof(string));
            movimentiIVA.Columns.Add("amount", typeof(decimal));
            movimentiIVA.Columns.Add("registry", typeof(string));
            movimentiIVA.Columns.Add("codefin", typeof(string));
            movimentiIVA.Columns.Add("codeupb", typeof(string));
            movimentiIVA.Columns.Add("idmovimento", typeof(int));
            movimentiIVA.Columns.Add("parentidmov", typeof(int));
            movimentiIVA.Columns.Add("sourcekind", typeof(string));
            movimentiIVA.Columns.Add("autokind", typeof(int));

            DataRow rConfIVA = DS.config.Rows[0];
            // ENTE del versamento/rimborso della config. iva consolidata dell'amminisrazione.
            object mainidregpayment = rConfIVA["mainpaymentagency"];
            object mainpaymentagencytitle = Meta.Conn.DO_READ_VALUE("registry", QHS.CmpEq("idreg", mainidregpayment), "title");

            object mainidregrefund = rConfIVA["mainrefundagency"];
            object mainrefundagencytitle = Meta.Conn.DO_READ_VALUE("registry", QHS.CmpEq("idreg", mainidregrefund), "title");

            // ENTE del versamento/rimborso della config. iva INTRA consolidata dell'amminisrazione.
            object mainidregpayment12 = rConfIVA["mainpaymentagency12"];
            object mainpaymentagencytitle12 = Meta.Conn.DO_READ_VALUE("registry", QHS.CmpEq("idreg", mainidregpayment12), "title");

            object mainidregrefund12 = rConfIVA["mainrefundagency12"];
            object mainrefundagencytitle12 = Meta.Conn.DO_READ_VALUE("registry", QHS.CmpEq("idreg", mainidregrefund12), "title");

            // BILANCIO per il versamento/rimborso della config. iva consolidata dell'amminisrazione.
            object mainidfinpayment = rConfIVA["mainidfinivapayment"];
            object maincodefinivapayment = Meta.Conn.DO_READ_VALUE("fin", QHS.CmpEq("idfin", mainidfinpayment), "codefin");

            object mainidfinrefund = rConfIVA["mainidfinivarefund"];
            object maincodefinivarefund = Meta.Conn.DO_READ_VALUE("fin", QHS.CmpEq("idfin", mainidfinrefund), "codefin");

            // BILANCIO per il versamento/rimborso della config. iva INTRA consolidata dell'amminisrazione.
            object mainidfinpayment12 = rConfIVA["mainidfinivapayment12"];
            object maincodefinivapayment12 = Meta.Conn.DO_READ_VALUE("fin", QHS.CmpEq("idfin", mainidfinpayment12), "codefin");

            object mainidfinrefund12 = rConfIVA["mainidfinivarefund12"];
            object maincodefinivarefund12 = Meta.Conn.DO_READ_VALUE("fin", QHS.CmpEq("idfin", mainidfinrefund12), "codefin");

            // BILANCIO del versamento/rimborso dalla config. iva dipartimentale dell'amministrazione, non la config. consolidata.
            object idfinpayment = rConfIVA["idfinivapayment"];
            object codefinivapayment = Meta.Conn.DO_READ_VALUE("fin", QHS.CmpEq("idfin", idfinpayment), "codefin");

            object idfinrefund = rConfIVA["idfinivarefund"];
            object codefinivarefund = Meta.Conn.DO_READ_VALUE("fin", QHS.CmpEq("idfin", idfinrefund), "codefin");

            // BILANCIO del versamento/rimborso dalla config. iva INTRA dipartimentale dell'amministrazione, non la config. consolidata.
            object idfinpayment12 = rConfIVA["idfinivapayment12"];
            object codefinivapayment12 = Meta.Conn.DO_READ_VALUE("fin", QHS.CmpEq("idfin", idfinpayment12), "codefin");

            object idfinrefund12 = rConfIVA["idfinivarefund12"];
            object codefinivarefund12 = Meta.Conn.DO_READ_VALUE("fin", QHS.CmpEq("idfin", idfinrefund12), "codefin");

            // ENTE per il versamento/rimborso della config. iva INTRA dipartimentale dell'amministrazione, non la config. consolidata.
            object idregpayment12 = rConfIVA["paymentagency12"];
            object paymentagencytitle12 = Meta.Conn.DO_READ_VALUE("registry", QHS.CmpEq("idreg", idregpayment12), "title");

            object idregrefund12 = rConfIVA["refundagency12"];
            object refundagencytitle12 = Meta.Conn.DO_READ_VALUE("registry", QHS.CmpEq("idreg", idregrefund12), "title");


            string idUpb = "0001";
            object codeUpb = Meta.Conn.DO_READ_VALUE("upb",QHS.CmpEq("idupb", "0001"),"codeupb");

            //liquidazionecorrente è l'importo da liquidare, positivo se a debito
            if (MovimentiFinanziariConfigurati()){
                if (liquidazionecorrente > 0){
                    DataRow rMov = movimentiIVA.NewRow();
                    rMov["movkind"] = "Spesa";
                    rMov["idreg"] = mainidregpayment;
                    rMov["registry"] = mainpaymentagencytitle;
                    rMov["idfin"] = mainidfinpayment;
                    rMov["codefin"] = maincodefinivapayment;
                    rMov["idupb"] = idUpb;
                    rMov["codeupb"] = codeUpb;
                    rMov["amount"] = liquidazionecorrente;
                    rMov["sourcekind"] = "C";
                    rMov["autokind"] = 16;
                    movimentiIVA.Rows.Add(rMov);
                }

                if (liquidazionecorrente < 0){
                    DataRow rMov = movimentiIVA.NewRow();
                    rMov["movkind"] = "Entrata";
                    rMov["idreg"] = mainidregrefund;
                    rMov["registry"] = mainrefundagencytitle;
                    rMov["idfin"] = mainidfinrefund;
                    rMov["codefin"] = maincodefinivarefund;
                    rMov["idupb"] = idUpb;
                    rMov["codeupb"] = codeUpb;
                    rMov["amount"] = -liquidazionecorrente;
                    rMov["sourcekind"] = "C";
                    rMov["autokind"] = 16;
                    movimentiIVA.Rows.Add(rMov);
                }
            }
            if (MovimentiFinanziariConfigurati12()){
                if (liquidazionecorrente12 > 0){
                    DataRow rMov = movimentiIVA.NewRow();
                    rMov["movkind"] = "Spesa";
                    rMov["idreg"] = mainidregpayment12;
                    rMov["registry"] = mainpaymentagencytitle12;
                    rMov["idfin"] = mainidfinpayment12;
                    rMov["codefin"] = maincodefinivapayment12;
                    rMov["idupb"] = idUpb;
                    rMov["codeupb"] = codeUpb;
                    rMov["amount"] = liquidazionecorrente12;
                    rMov["sourcekind"] = "C";
                    rMov["autokind"] = 19;
                    movimentiIVA.Rows.Add(rMov);
                }

                if (liquidazionecorrente12 < 0){
                    DataRow rMov = movimentiIVA.NewRow();
                    rMov["movkind"] = "Entrata";
                    rMov["idreg"] = mainidregrefund12;
                    rMov["registry"] = mainrefundagencytitle12;
                    rMov["idfin"] = mainidfinrefund12;
                    rMov["codefin"] = maincodefinivarefund12;
                    rMov["idupb"] = idUpb;
                    rMov["codeupb"] = codeUpb;
                    rMov["amount"] = -liquidazionecorrente12;
                    rMov["sourcekind"] = "C";
                    rMov["autokind"] = 19;
                    movimentiIVA.Rows.Add(rMov);
                }
            }

            // AGGIUNGE I MOV. VERSO I DIPARTIMENTI 

            object ayear = HelpForm.GetObjectFromString(typeof(int), txtEsercizio.Text, null);
            object nmonth = HelpForm.GetObjectFromString(typeof(int), txtMese.Text, null);
            byte flag = calcolaFlag();
            object[] param = new object[] { ayear, nmonth,flag };
            DataSet DSiva_dipartimenti = Conn.CallSP("compute_ivapaydepartment", param, true);
            if (DSiva_dipartimenti == null || DSiva_dipartimenti.Tables.Count == 0) {
                TableIva_dipartimenti = null;
            }
            else{
                TableIva_dipartimenti = DSiva_dipartimenti.Tables[0];
            }

            object idregistry_dipartimenti;
            object registry_dipartimenti;

            foreach (DataRow R in TableIva_dipartimenti.Rows){
                idregistry_dipartimenti = R["idregauto"];
                registry_dipartimenti = R["regautotitle"];
                if (MovimentiFinanziariConfigurati()){
                    // dalla sp ritorna:	ISNULL(paymentamount, -refundamount) AS ivapay
                    if (CfgFn.GetNoNullDecimal(R["ivapay"]) < 0){
                        // vuol dire che il dipartimento ha fatto un rimborso = entrata, quindi ora generiamo una spesa
                        DataRow rMov = movimentiIVA.NewRow();
                        rMov["movkind"] = "Spesa";
                        rMov["idreg"] = idregistry_dipartimenti;
                        rMov["registry"] = registry_dipartimenti;
                        rMov["idfin"] = idfinpayment;
                        rMov["codefin"] = codefinivapayment;
                        rMov["idupb"] = idUpb;
                        rMov["codeupb"] = codeUpb;
                        rMov["amount"] = -CfgFn.GetNoNullDecimal(R["ivapay"]);
                        rMov["sourcekind"] = "D";
                        rMov["autokind"] = 15;
                        movimentiIVA.Rows.Add(rMov);
                    }

                    if (CfgFn.GetNoNullDecimal(R["ivapay"]) > 0){
                        // vuol dire che il dipartimento ha fatto un versamento= spesa, quindi ora generiamo una entrata
                        DataRow rMov = movimentiIVA.NewRow();
                        rMov["movkind"] = "Entrata";
                        rMov["idreg"] = idregistry_dipartimenti;
                        rMov["registry"] = registry_dipartimenti;
                        rMov["idfin"] = idfinrefund;
                        rMov["codefin"] = codefinivarefund;
                        rMov["idupb"] = idUpb;
                        rMov["codeupb"] = codeUpb;
                        rMov["amount"] = R["ivapay"];
                        rMov["sourcekind"] = "D";
                        rMov["autokind"] = 15;
                        movimentiIVA.Rows.Add(rMov);
                    }
                }

                if (MovimentiFinanziariConfigurati12()){
                    // dalla sp ritorna:	ISNULL(paymentamount12, -refundamount12) AS ivapay12
                    if (CfgFn.GetNoNullDecimal(R["ivapay12"]) < 0){
                        // vuol dire che il dipartimento ha fatto un rimborso = entrata, quindi ora generiamo una spesa
                        DataRow rMov = movimentiIVA.NewRow();
                        rMov["movkind"] = "Spesa";
                        rMov["idreg"] = idregistry_dipartimenti;
                        rMov["registry"] = registry_dipartimenti;
                        rMov["idfin"] = idfinpayment12;
                        rMov["codefin"] = codefinivapayment12;
                        rMov["idupb"] = idUpb;
                        rMov["codeupb"] = codeUpb;
                        rMov["amount"] = -CfgFn.GetNoNullDecimal(R["ivapay12"]);
                        rMov["sourcekind"] = "D";
                        rMov["autokind"] = 18;
                        movimentiIVA.Rows.Add(rMov);
                    }

                    if (CfgFn.GetNoNullDecimal(R["ivapay12"]) > 0){
                        // vuol dire che il dipartimento ha fatto un versamento= spesa, quindi ora generiamo una entrata
                        DataRow rMov = movimentiIVA.NewRow();
                        rMov["movkind"] = "Entrata";
                        rMov["idreg"] = idregistry_dipartimenti;
                        rMov["registry"] = registry_dipartimenti;
                        rMov["idfin"] = idfinrefund12;
                        rMov["codefin"] = codefinivarefund12;
                        rMov["idupb"] = idUpb;
                        rMov["codeupb"] = codeUpb;
                        rMov["amount"] = R["ivapay12"];
                        rMov["sourcekind"] = "D";
                        rMov["autokind"] = 18;
                        movimentiIVA.Rows.Add(rMov);
                    }
                }
            }
            return movimentiIVA;
        }


        private void ViewAutomatismi(DataSet DS) {
            bool automatismi = false;
            string spesa = null;
            if (DS.Tables["expense"] != null)
            {
                DataTable Var = DS.Tables["expense"];
                spesa = QHC.FieldIn("idexp", Var.Select(), "idexp");
                if (Var.Select().Length > 0) automatismi = true;
            }
            string entrata = null;
            if (DS.Tables["income"] != null)
            {
                DataTable Var = DS.Tables["income"];
                entrata = QHC.FieldIn("idinc", Var.Select(), "idinc");
                if (Var.Select().Length > 0) automatismi = true;
            }
            if (!automatismi) return;

            Form F = ShowAutomatismi.Show(Meta, spesa, entrata, null, null);
            F.ShowDialog(this);
        }

        private void SaveData(){
            object prorata = HelpForm.GetObjectFromString(typeof(decimal), txtProrata.Text, tag_perc);
            object promiscuo = HelpForm.GetObjectFromString(typeof(decimal), txtPromiscuo.Text, tag_perc);

            int month = m_ToDate.Month;
            int year = m_ToDate.Year;
            if (month + m_PeriodicitaMese > 12){
                year++;
                month = month + m_PeriodicitaMese - 12;
            }
            DateTime dtGiornoPeriodo = new DateTime(year, month, m_PeriodicitaGiorno);

            //riga di liquidazioneivaconsolidata = mainivapay
            Meta.SetDefaults(DS.mainivapay);
            DataRow Rliquidazione = Meta.Get_New_Row(null, DS.mainivapay);
            Rliquidazione["paymentkind"] = "C";
            Rliquidazione["nmonth"] = HelpForm.GetObjectFromString(typeof(int), txtMese.Text, null);
            Rliquidazione["referenceyear"] = HelpForm.GetObjectFromString(typeof(int), txtEsercizio.Text, null);
            Rliquidazione["prorata"] = prorata;
            Rliquidazione["mixed"] = promiscuo;
            Rliquidazione["creditamount"] = credito_immediato;
            Rliquidazione["creditamountdeferred"] = credito_differito;
            Rliquidazione["debitamount"] = vendite_immediata;
            Rliquidazione["debitamountdeferred"] = vendite_deferred;
            Rliquidazione["totalcredit"] = totale_iva_credito;
            Rliquidazione["totaldebit"] = totale_iva_debito;
            Rliquidazione["creditamount12"] = credito_immediato12;
            Rliquidazione["creditamountdeferred12"] = credito_differito12;
            Rliquidazione["debitamount12"] = debito_immediato12;
            Rliquidazione["debitamountdeferred12"] = debito_differito12;
            Rliquidazione["totalcredit12"] = totale_iva_credito12;
            Rliquidazione["totaldebit12"] = totale_iva_debito12;
            Rliquidazione["taxableintrastat12"] = taxableintrastat12;
            Rliquidazione["ivaintrastat12"] = ivaintrastat12;
            Rliquidazione["flag"] = calcolaFlag();

            //crea righe di mainivapaydetail (debito) (REGISTRI DI VENDITA)
            foreach (DataRow R in TableIva.Select(QHC.CmpEq("registerclass", "V"))){
                string filtroDett = QHC.AppAnd(QHC.CmpMulti(Rliquidazione, "ymainivapay", "nmainivapay"),
                                    QHC.CmpMulti(R, "idivaregisterkind"), QHC.CmpMulti(R, "iddbdepartment"));

                bool istituzionale = false;
                if (CfgFn.GetNoNullInt32(R["flagactivity"]) == 1) istituzionale = true;

                DataRow[] rDett = DS.mainivapaydetail.Select(filtroDett);
                decimal imponibile_imm = 0;// Valorizziamo il campo 'imponibile' della tabella solo se il registro è istituzionale.
                decimal imponibile_diff = 0;
                if (istituzionale){
                    imponibile_imm = CfgFn.GetNoNullDecimal(R["taxable12_imm"]);
                    imponibile_diff = CfgFn.GetNoNullDecimal(R["taxable12_diff"]);
                }
                if (rDett.Length == 0){
                    DataRow Rdettaglio = DS.mainivapaydetail.NewRow();
                    Rdettaglio["ymainivapay"] = Rliquidazione["ymainivapay"];
                    Rdettaglio["nmainivapay"] = Rliquidazione["nmainivapay"];
                    Rdettaglio["idivaregisterkind"] = R["idivaregisterkind"];
                    Rdettaglio["iddbdepartment"] = R["iddbdepartment"];

                    Rdettaglio["ivadeferred"] = R["iva_diff"];
                    Rdettaglio["ivanetdeferred"] = R["iva_diff"];
                    Rdettaglio["iva"] = R["iva_imm"];
                    Rdettaglio["ivanet"] = R["iva_imm"];

                    Rdettaglio["taxable12"] = imponibile_imm;
                    Rdettaglio["taxabledeferred12"] = imponibile_diff;

                    Rdettaglio["cu"] = "AUTO";
                    Rdettaglio["ct"] = DateTime.Now;
                    Rdettaglio["lu"] = "AUTO";
                    Rdettaglio["lt"] = DateTime.Now;
                    DS.mainivapaydetail.Rows.Add(Rdettaglio);
                }
                else{
                    rDett[0]["ivadeferred"] = CfgFn.GetNoNullDecimal(rDett[0]["ivadeferred"])
                        + CfgFn.GetNoNullDecimal(R["iva_diff"]);
                    rDett[0]["ivanetdeferred"] = CfgFn.GetNoNullDecimal(rDett[0]["ivanetdeferred"])
                        + CfgFn.GetNoNullDecimal(R["iva_diff"]);
                    rDett[0]["iva"] = CfgFn.GetNoNullDecimal(rDett[0]["iva"])
                        + CfgFn.GetNoNullDecimal(R["iva_imm"]);
                    rDett[0]["ivanet"] = CfgFn.GetNoNullDecimal(rDett[0]["ivanet"])
                        + CfgFn.GetNoNullDecimal(R["iva_imm"]);
                    rDett[0]["taxable12"] = CfgFn.GetNoNullDecimal(rDett[0]["taxable12"])
                        + imponibile_imm;
                    rDett[0]["taxabledeferred12"] = CfgFn.GetNoNullDecimal(rDett[0]["taxabledeferred12"])
                        + imponibile_diff;
                }

            }
            //crea righe di ivapaydetail (credito)        (REGISTRI DI ACQUISTO)
            foreach (DataRow R in TableIva.Select(QHC.CmpEq("registerclass", "A"))){
                string filtroDett = QHC.AppAnd(QHC.CmpMulti(Rliquidazione, "ymainivapay", "nmainivapay"),
                                    QHC.CmpMulti(R, "idivaregisterkind"), QHC.CmpMulti(R, "iddbdepartment"));

                bool istituzionale = false;
                if (CfgFn.GetNoNullInt32(R["flagactivity"]) == 1) istituzionale = true;

                DataRow[] rDett = DS.mainivapaydetail.Select(filtroDett);
                decimal imponibile_imm = 0;// Valorizziamo il campo 'imponibile' della tabella solo se il registro è istituzionale.
                decimal imponibile_diff = 0;
                if (istituzionale){
                    imponibile_imm = CfgFn.GetNoNullDecimal(R["taxable12_imm"]);
                    imponibile_diff = CfgFn.GetNoNullDecimal(R["taxable12_diff"]);
                }
                if (rDett.Length == 0)
                {
                    DataRow Rdettaglio = DS.mainivapaydetail.NewRow();
                    Rdettaglio["ymainivapay"] = Rliquidazione["ymainivapay"];
                    Rdettaglio["nmainivapay"] = Rliquidazione["nmainivapay"];
                    Rdettaglio["idivaregisterkind"] = R["idivaregisterkind"];
                    Rdettaglio["iddbdepartment"] = R["iddbdepartment"];

                    Rdettaglio["ivadeferred"] = CfgFn.GetNoNullDecimal(R["iva_diff"]);//ivatotal;
                    Rdettaglio["unabatabledeferred"] = CfgFn.GetNoNullDecimal(R["unabatable_diff"]);//unabatable;
                    Rdettaglio["ivanetdeferred"] = CfgFn.GetNoNullDecimal(R["singola_diff"]);//abatable;
                    Rdettaglio["taxabledeferred12"] = imponibile_diff;

                    Rdettaglio["iva"] = CfgFn.GetNoNullDecimal(R["iva_imm"]);//ivatotal;
                    Rdettaglio["unabatable"] = CfgFn.GetNoNullDecimal(R["unabatable_imm"]);//unabatable;
                    Rdettaglio["ivanet"] = CfgFn.GetNoNullDecimal(R["singola_imm"]);//abatable;
                    Rdettaglio["taxable12"] = imponibile_imm;

                    Rdettaglio["prorata"] = Rliquidazione["prorata"];
                    Rdettaglio["mixed"] = (R["flagmixed"].ToString().ToUpper() == "S") ? Rliquidazione["mixed"] : DBNull.Value;
                    Rdettaglio["cu"] = "AUTO";
                    Rdettaglio["ct"] = DateTime.Now;
                    Rdettaglio["lu"] = "AUTO";
                    Rdettaglio["lt"] = DateTime.Now;
                    DS.mainivapaydetail.Rows.Add(Rdettaglio);
                }
                else{
                    rDett[0]["ivadeferred"] = CfgFn.GetNoNullDecimal(rDett[0]["ivadeferred"]) + CfgFn.GetNoNullDecimal(R["iva_diff"]);// +ivatotal;
                        rDett[0]["unabatabledeferred"] = CfgFn.GetNoNullDecimal(rDett[0]["unabatabledeferred"])
                            + CfgFn.GetNoNullDecimal(R["unabatable_diff"]);//+ unabatable;
                        rDett[0]["ivanetdeferred"] = CfgFn.GetNoNullDecimal(rDett[0]["ivanetdeferred"])
                            + CfgFn.GetNoNullDecimal(R["singola_diff"]);// + abatable;
                        rDett[0]["iva"] = CfgFn.GetNoNullDecimal(rDett[0]["iva"]) + CfgFn.GetNoNullDecimal(R["iva_imm"]);// +ivatotal;
                        rDett[0]["unabatable"] = CfgFn.GetNoNullDecimal(rDett[0]["unabatable"])
                             + CfgFn.GetNoNullDecimal(R["unabatable_imm"]);//+ unabatable;
                        rDett[0]["ivanet"] = CfgFn.GetNoNullDecimal(rDett[0]["ivanet"])
                             + CfgFn.GetNoNullDecimal(R["singola_imm"]);// + abatable;
                        rDett[0]["taxable12"] = CfgFn.GetNoNullDecimal(rDett[0]["taxable12"])
                            + imponibile_imm;
                        rDett[0]["taxabledeferred12"] = CfgFn.GetNoNullDecimal(rDett[0]["taxabledeferred12"])
                            + imponibile_diff;

                }
            }

            //creaRigheInvoiceDeferred(Rliquidazione);// Per la Lx Consolidata non è stata creata questa tabella, perchè non si è reputata utile.

            // Queste Clear() prima erano nel metodo insertMov().
            DS.Tables["income"].Clear();
            DS.Tables["incomeyear"].Clear();
            DS.Tables["incomelast"].Clear();

            DS.Tables["expense"].Clear();
            DS.Tables["expenseyear"].Clear();
            DS.Tables["expenselast"].Clear();

            if ((TAutomatismi!=null) && (TAutomatismi.Rows.Count > 0)&& (liquidazionecorrente!=0) ){
                insertMov(Rliquidazione, dtGiornoPeriodo,false, "C");
            }
            // I campi refundamount e paymentamount vengono riempiti solo dopo aver creato i movimenti di entrata e spesa
            bool assegnaData = false;
            if (liquidazionecorrente < 0){
                Rliquidazione["refundamount"] = -liquidazionecorrente;
                assegnaData = true;
            }

            if (liquidazionecorrente12 < 0){
                Rliquidazione["refundamount12"] = -liquidazionecorrente12;
                assegnaData = true;
            }

            if (liquidazionecorrente > 0){
                Rliquidazione["paymentamount"] = liquidazionecorrente;
                assegnaData = true;
            }
            if (liquidazionecorrente12 > 0){
                Rliquidazione["paymentamount12"] = liquidazionecorrente12;
                assegnaData = true;
            }
            if (assegnaData){
                Rliquidazione["assesmentdate"] = dtGiornoPeriodo;
            }

           if ((TAutomatismi!=null) && (TAutomatismi.Rows.Count > 0)){
                insertMov(Rliquidazione, dtGiornoPeriodo, false,"D");
            }

            if (((liquidazionecorrente != 0) && MovimentiFinanziariConfigurati())
            || ((liquidazionecorrente12 != 0) && MovimentiFinanziariConfigurati12())){                

                int fasespesamax = CfgFn.GetNoNullInt32(Meta.GetSys("maxexpensephase"));
                GestioneAutomatismi ga = new GestioneAutomatismi(this, Meta.Conn, Meta.Dispatcher, DS.Copy(),
                    fasespesamax, fasespesamax, "mainivapay", true);
                ga.GeneraClassificazioniAutomatiche(ga.DSP, true);
                bool res = ga.GeneraAutomatismiAfterPost(true);
                if (!res) {
                    show(this, "Si è verificato un errore o si è deciso di non salvare! L'operazione sarà terminata");
                    return;
                }
                res = ga.doPost(Meta.Dispatcher);
                if (res){
                    ViewAutomatismi(ga.DSP);
                    DataRow rLiq = ga.DSP.Tables["mainivapay"].Rows[0];
                    GeneraScritture(rLiq);
                    return;
                }
            }
            else{
                Easy_PostData EP = new Easy_PostData();
                EP.InitClass(DS, Conn);
                bool res = EP.DO_POST();
                if (res)
                {
                    DataRow rLiq = DS.Tables["mainivapay"].Rows[0];
                    GeneraScritture(rLiq);
                    return;
                }
            }
        }

        void GeneraScritture(DataRow Curr) {
            if (DS.mainivapay.Rows.Count == 0) return; //It was an insert-cancel

            //			DataRow Curr=DS.ivapay.Rows[0];											
            if (Curr.RowState == DataRowState.Deleted) {
                //Should delete the related entries 
                return;
            }


            if (DS.config.Rows.Count == 0) return;
            DataRow currInvSetup = DS.config.Rows[0];
            object idregVersamento = currInvSetup["mainpaymentagency"];
            object idregRimborso = currInvSetup["mainrefundagency"];

            object idregVersamento12 = currInvSetup["mainpaymentagency12"];
            object idregRimborso12 = currInvSetup["mainrefundagency12"];
            
            object idupb = "0001";
            object idaccunabatable = currInvSetup["mainidacc_unabatable"];
            object idaccunabatable_refund = currInvSetup["mainidacc_unabatable_refund"];

            EP_functions EP = new EP_functions(Meta.Dispatcher);
            if (!EP.attivo) return;

            //Nel caso in cui i mov. NON debbano essere genearati liquidazionecorrene e  ivadelperiodo assumo lo stesso valore. 
            //Quindi si modifica la condizione da: 
            //if (liquidazionecorrente == 0 && ( MovimentiFinanziariConfigurati() == false )  &&  (ivadelperiodo !=  0 ) ) 
            //in
            //if (  MovimentiFinanziariConfigurati() == false   &&  ivadelperiodo !=  0  ) 
            if ((MovimentiFinanziariConfigurati() == false) && (MovimentiFinanziariConfigurati12() == false) && (ivadelperiodo != 0))
            {
                show(this, "Non avendo generato alcuna movimentazione finanziaria non sarà generata alcuna scrittura E.P.", "Avviso");
                return;
            }

            EP.GetEntryForDocument(Curr);
            if (DS.config.Rows.Count == 0) {
                string messaggio = "Non è stata impostata la configurazione per la liquidazione IVA dell'anno in corso"
                    + "\nAndare dal menu CONFIGURAZIONE - ECONOMICO PATRIMONIALE - CONFIGURAZIONE ed impostare tale configurazione";
                show(this, messaggio);
                return;
            }
            DataRow tEntrySetup = DS.config.Rows[0];

            object doc = "Liquidazione IVA Consolidata" + Curr["ymainivapay"] + "/" + Curr["nmainivapay"];


            object idacc_refund = EP.GetAccountForMainIvaRefund();
            object idacc_payment = EP.GetAccountForMainIvaPayment();
            object idacc_refund_internal = EP.GetAccountForMainIvaRefundInternal();
            object idacc_payment_internal = EP.GetAccountForMainIvaPaymentInternal();

            object idacc_refund12 = EP.GetAccountForMainIvaRefund12();
            object idacc_payment12 = EP.GetAccountForMainIvaPayment12();
            object idacc_refund_internal12 = EP.GetAccountForMainIvaRefundInternal12();
            object idacc_payment_internal12 = EP.GetAccountForMainIvaPaymentInternal12();
            
            
            if (idacc_refund == DBNull.Value && totale_iva_credito > 0) {
                string msg = "Non è stato configurato alcun conto per il rimborso dell'IVA"
                    + "\nAndare dal menu CONFIGURAZIONE - ECONOMICO PATRIMONIALE - CONFIGURAZIONE ed impostare il conto Crediti v/Clienti o il conto Rimborso IVA"
                    + "\nLe scritture non verranno generate";
                show(this, msg);
                return;
            }

            if (idacc_payment == DBNull.Value && totale_iva_debito > 0) {
                string msg = "Non è stato configurato alcun conto per il pagamento dell'IVA"
                    + "\n Andare dal menu CONFIGURAZIONE - ECONOMICO PATRIMONIALE - CONFIGURAZIONE ed impostare il conto Debiti v/Fornitori o il conto Versamento IVA";
                show(this, msg);
                return;
            }
            // INTRA
            if (idacc_refund12 == DBNull.Value && totale_iva_credito12 > 0) {
                string msg = "Non è stato configurato alcun conto per il rimborso dell'IVA Intra e Extra-UE"
                    + "\nAndare dal menu CONFIGURAZIONE - ECONOMICO PATRIMONIALE - CONFIGURAZIONE ed impostare il conto Crediti v/Clienti o il conto Rimborso IVA"
                    + "\nLe scritture non verranno generate";
                show(this, msg);
                return;
            }

            if (idacc_payment12 == DBNull.Value && totale_iva_debito12 > 0) {
                string msg = "Non è stato configurato alcun conto per il pagamento dell'IVA Intra e Extra-UE"
                    + "\n Andare dal menu CONFIGURAZIONE - ECONOMICO PATRIMONIALE - CONFIGURAZIONE ed impostare il conto Debiti v/Fornitori o il conto Versamento IVA";
                show(this, msg);
                return;
            }

            object dataLiquidazione = Meta.GetSys("datacontabile");
            DataRow r = EP.SetEntry(doc, dataLiquidazione,
                doc, dataLiquidazione, EP_functions.GetIdForDocument(Curr));

            EP.ClearDetails(r);
            decimal ivaCredito = 0;
            decimal ivaDebito = 0;
            decimal ivaCredito12 = 0;
            decimal ivaDebito12 = 0;

            foreach (DataRow rFattura in TableIva_dipartimenti.Rows) {
                decimal amount = CfgFn.GetNoNullDecimal(rFattura["ivapay"]);
                decimal amount12 = CfgFn.GetNoNullDecimal(rFattura["ivapay12"]); 
                if (amount == 0) continue;// DA RIVEDERE

                string idepcontext = "";
                string idepcontext12 = "";

                if (amount>0) {
                    idepcontext = "LIQIVADEB";
                    ivaDebito += amount;
                }
                else {
                    idepcontext = "LIQIVACRED";
                    ivaCredito -= amount;
                }

                // INTRA 
                if (amount12 > 0){
                    idepcontext12 = "LIQIVADEB";
                    ivaDebito12 += amount12;
                }
                else{
                    idepcontext12 = "LIQIVACRED";
                    ivaCredito12 -= amount12;
                }

                object idreg = rFattura["idregauto"];

                if (amount > 0) {
                    //iva a debito, credito da dip, debito verso erario
                    // cambio di segno per movimentare il conto di credito in DARE
                    EP.EffettuaScrittura(idepcontext, -amount, idacc_refund_internal, idreg, null,null);
                    //EP.EffettuaScrittura(idepcontext, amount, idacc_payment, idregVersamento, null, null);
                }
                else {
                    //iva a credito, debito vs dip, credito da erario
                    //non cambio di segno perché voglio movimentare il conto di debito in AVERE
                    EP.EffettuaScrittura(idepcontext, amount, idacc_payment_internal, idreg, null, null);
                    //EP.EffettuaScrittura(idepcontext, -amount, idacc_refund, idregRimborso, null, null);
                }
                // Speculare per INTRA
                if (amount12 > 0){
                    EP.EffettuaScrittura(idepcontext12, -amount12, idacc_refund_internal12, idreg, null, null);
                }
                else{
                    EP.EffettuaScrittura(idepcontext12, amount12, idacc_payment_internal12, idreg, null, null);

                }
            }
            decimal totale_da_dip = ivaDebito - ivaCredito;
            decimal totale_mio = totale_iva_debito - totale_iva_credito;

            decimal totale_da_dip12 = ivaDebito12 - ivaCredito12;
            decimal totale_mio12 = totale_iva_debito12 - totale_iva_credito12;

            if (totale_mio > 0) {
                //era ivaDebito
                EP.EffettuaScrittura("LIQIVADEB", totale_mio, idacc_payment, idregVersamento, idupb, null);
            }
            else {
                //era totale_iva_credito
                EP.EffettuaScrittura("LIQIVACRED", -totale_mio, idacc_refund, idregRimborso, idupb, null);
            }

            // INTRA 
            if (totale_mio12 > 0){
                //era ivaDebito 
                EP.EffettuaScrittura("LIQIVADEB", totale_mio12, idacc_payment12, idregVersamento12, idupb, null);
            }
            else{
                //era totale_iva_credito
                EP.EffettuaScrittura("LIQIVACRED", -totale_mio12, idacc_refund12, idregRimborso12, idupb, null);
            }


            //ivaCredito: somma delle iva detraibili riga per riga (se modo non è "riga per riga" non applica il prorata)
            //totale_iva_credito: importo che tiene conto del tipo calcolo (di solito è quindi minore di  ivaCredito)
            decimal costodetr = totale_da_dip - totale_mio;

            if (costodetr > 0 && idaccunabatable == DBNull.Value) {
                string msg = "Attenzione il conto generale per l'imputazione dell'iva indetrabile (Costi)" +
                    "non è stato configurato." +
                    "\nAndare dal menu CONFIGURAZIONE - Configurazione Annuale - EP - Iva e configurare il conto";
                show(this, msg);
                return;
            }

            if (costodetr < 0 && idaccunabatable_refund == DBNull.Value) {
                string msg = "Attenzione il conto generale per l'imputazione dell'iva indetrabile (Ricavi)" +
                    "non è stato configurato." +
                    "\nAndare dal menu CONFIGURAZIONE - Configurazione Annuale - EP - Iva e configurare il conto";
                show(this, msg);
                return;
            }

            if (costodetr > 0) EP.EffettuaScrittura("LIQIVACRED", costodetr, idaccunabatable_refund, null, idupb, null);
            if (costodetr < 0) EP.EffettuaScrittura("LIQIVADEB", -costodetr, idaccunabatable, null, idupb, null);

            EP.RemoveEmptyDetails();

            MetaData MetaEntry = MetaData.GetMetaData(this, "entry");
            PostData Post = MetaEntry.Get_PostData();

            Post.InitClass(EP.D, Meta.Conn);
            if (Post.DO_POST()) {
                EditEntry(Curr);
            }

        }
        void AddVoceBilancio(object ID, string codbil){
            if (ID == DBNull.Value) return;
            if (DS.fin.Select(QHC.CmpEq("idfin", ID)).Length > 0) return;
            DataRow NewBil = DS.fin.NewRow();
            NewBil["idfin"] = ID;
            NewBil["codefin"] = codbil;
            DS.fin.Rows.Add(NewBil);
            NewBil.AcceptChanges();
        }

        void AddVoceUpb(object ID, string codupb){
            if (ID == DBNull.Value) return;
            if (DS.upb.Select(QHC.CmpEq("idupb", ID)).Length > 0) return;

            DataRow NewUpb = DS.upb.NewRow();
            NewUpb["idupb"] = ID;
            NewUpb["codeupb"] = codupb;
            DS.upb.Rows.Add(NewUpb);
            NewUpb.AcceptChanges();
        }

        void AddVoceCreditore(object codice, string denominazione){
            if (codice == DBNull.Value) return;
            if (DS.registry.Select(QHC.CmpEq("idreg", codice)).Length > 0) return;

            DataRow NewCred = DS.registry.NewRow();
            NewCred["idreg"] = codice;
            NewCred["title"] = denominazione;
            DS.registry.Rows.Add(NewCred);
            NewCred.AcceptChanges();
        }

        void AddVociCollegate(DataRow SP_Row)
        {
            AddVoceBilancio(SP_Row["idfin"], SP_Row["codefin"].ToString());
            AddVoceUpb(SP_Row["idupb"], SP_Row["codeupb"].ToString());
            AddVoceCreditore(SP_Row["idreg"], SP_Row["registry"].ToString());
        }

        private void FillMovimento(DataRow E_S, DataRow Auto)
        {
            int esercizio = Convert.ToInt32(Meta.GetSys("esercizio"));
            DateTime DataCont = Convert.ToDateTime(Meta.GetSys("datacontabile"));
            E_S.BeginEdit();
            E_S["ymov"] = esercizio;
            //E_S["ycreation"]= esercizio;
            E_S["adate"] = DataCont;
            //E_S["fulfilled"]="N";
            ////if (E_S.Table.Columns.Contains("autotaxflag"))E_S["autotaxflag"]="N";
            ////if (E_S.Table.Columns.Contains("autoclawbackflag"))E_S["autoclawbackflag"]="N";

            string[] fields_to_copy = new string[] { 
													  "idman","idreg","description","autokind"};
            foreach (string field in fields_to_copy){
                if (Auto.Table.Columns[field] == null) continue;
                if (E_S.Table.Columns[field] == null) continue;
                E_S[field] = Auto[field];
            }
            //E_S["amount"] = CfgFn.RoundValuta(CfgFn.GetNoNullDecimal(Auto["amount"]));
            E_S.EndEdit();
        }



        void FillImputazioneMovimento(DataRow ImpMov, DataRow Auto){
            string[] fields_to_copy = new string[] { "idfin", "idupb", "codefin", "codeupb" };
            foreach (string field in fields_to_copy)
            {
                if (Auto.Table.Columns[field] == null) continue;
                if (ImpMov.Table.Columns[field] == null) continue;
                ImpMov[field] = Auto[field];
            }
            ImpMov["amount"] = CfgFn.RoundValuta(CfgFn.GetNoNullDecimal(Auto["amount"]));
        }

        private void insertMov(DataRow rIvaPay, DateTime scadenza, bool intrastat, string sourcekind){
            if ((!MovimentiFinanziariConfigurati()) && (!MovimentiFinanziariConfigurati12())) return;

            int fasemax = 0;
            int faseCreditoreDebitore = 0;
            int faseBilancio = 0;
            int faselast = 0;

            DS.Tables["expenseview"].AcceptChanges();
            DS.Tables["incomeview"].AcceptChanges();
            // Spostati nel metodo chiamante.
            //DS.Tables["expense"].Clear();
            //DS.Tables["income"].Clear();
            //DS.Tables["expenseview"].Clear();
            //DS.Tables["incomeview"].Clear();
            //DS.Tables["incomelast"].Clear();
            //DS.Tables["expenselast"].Clear();

            string parentIdField;
            string movIdField;
            string filterMovKind = "";
            filterMovKind =  QHC.CmpEq("sourcekind", sourcekind);
            DataRow[] Auto = TAutomatismi.Select(filterMovKind); 
            foreach (DataRow R in Auto){
                string mov = "";
                if (R["movkind"].ToString().ToLower() == "spesa")
                    mov = "expense";
                else
                    mov = "income";
                string view = mov + "view";
                string impMov = mov + "year";
                string lastMov = mov + "last";

                DataTable Mov = DS.Tables[mov];
                DataTable ImpMov = DS.Tables[impMov];
                DataTable LastMov = DS.Tables[lastMov];

                if (mov == "expense"){
                    movIdField = "idexp";
                    parentIdField = "parentidexp";
                }
                else{
                    movIdField = "idinc";
                    parentIdField = "parentidinc";
                }

                MetaData MetaM = Meta.Dispatcher.Get(mov);
                MetaM.SetDefaults(DS.Tables[mov]);
                MetaData MetaImputazioneM = Meta.Dispatcher.Get(impMov);
                MetaImputazioneM.SetDefaults(DS.Tables[impMov]);
                MetaData MetaMovLast = Meta.Dispatcher.Get(lastMov);
                MetaMovLast.SetDefaults(DS.Tables[lastMov]);

                if (mov == "expense"){
                    fasemax = getIntSys("maxexpensephase");
                    faseCreditoreDebitore = getIntSys("expenseregphase");
                    faseBilancio = getIntSys("expensefinphase");
                    faselast = (GeneraTuttelafasi) ? getIntSys("maxexpensephase") : getIntSys("expenseregphase");
                }
                else{
                    fasemax = getIntSys("maxincomephase");
                    faseCreditoreDebitore = getIntSys("incomeregphase");
                    faseBilancio = getIntSys("incomefinphase");
                    faselast = (GeneraTuttelafasi) ? getIntSys("maxincomephase") : getIntSys("incomeregphase");
                }

                AddVociCollegate(R);
                DataRow ParentR = null;

                for (int faseCorrente = 1; faseCorrente <= faselast; faseCorrente++){
                    Mov.Columns["nphase"].DefaultValue = faseCorrente;

                    DataRow NewMovRow = MetaM.Get_New_Row(ParentR, Mov);
                    ParentR = NewMovRow;

                    FillMovimento(NewMovRow, R);
                    R["idmovimento"] = NewMovRow[movIdField];
                    NewMovRow["nphase"] = faseCorrente;

                    if (faseCorrente < faseCreditoreDebitore){
                        NewMovRow["idreg"] = DBNull.Value;
                    }

                    if ((faseCorrente == fasemax) && (mov == "expense")){
                        object codicecreddeb = R["idreg"];
                        DataRow ModPagam = CfgFn.ModalitaPagamentoDefault(Meta.Conn, codicecreddeb);
                        if (ModPagam == null){
                            show(this,
                                "E' necessario che sia definita almeno una modalità di pagamento per il percipiente " +
                                "\"" + R["registry"].ToString() + "\"\n\n" +
                                "Dati non salvati", "Errore", MessageBoxButtons.OK);
                            return;
                        }
                        DataRow NewLastMov = MetaMovLast.Get_New_Row(NewMovRow, LastMov);
                        NewLastMov["idregistrypaymethod"] = ModPagam["idregistrypaymethod"];
                        NewLastMov["idpaymethod"] = ModPagam["idpaymethod"];
                        NewLastMov["iban"] = ModPagam["iban"];
                        NewLastMov["cin"] = ModPagam["cin"];
                        NewLastMov["idbank"] = ModPagam["idbank"];
                        NewLastMov["idcab"] = ModPagam["idcab"];
                        NewLastMov["cc"] = ModPagam["cc"];
                        NewLastMov["paymentdescr"] = ModPagam["paymentdescr"];
                        NewLastMov["iddeputy"] = ModPagam["iddeputy"];
                        NewLastMov["refexternaldoc"] = ModPagam["refexternaldoc"];
                        NewLastMov["biccode"] = ModPagam["biccode"];
                        NewLastMov["extracode"] = ModPagam["extracode"];
                        object idpaymethod = ModPagam["idpaymethod"];
                        string filterpaymethod = QHS.CmpEq("idpaymethod", idpaymethod);

                        DataTable TPaymethod = Conn.RUN_SELECT("paymethod", "*", null, filterpaymethod, null, true);

                        if ((TPaymethod != null) && (TPaymethod.Rows.Count > 0))
                        {
                            object paymethod_allowdeputy = TPaymethod.Rows[0]["allowdeputy"];
                            object paymethod_flag = TPaymethod.Rows[0]["flag"];
                            NewLastMov["paymethod_allowdeputy"] = paymethod_allowdeputy;
                            NewLastMov["paymethod_flag"] = paymethod_flag;
                        }
                    }
                    if ((faseCorrente == fasemax) && (mov == "income")){
                        DataRow NewLastMov = MetaMovLast.Get_New_Row(NewMovRow, LastMov);
                    }
                    DataRow NewImpMov = ImpMov.NewRow();

                    FillImputazioneMovimento(NewImpMov, R);
                    NewImpMov[movIdField] = NewMovRow[movIdField];
                    NewImpMov["ayear"] = esercizio;

                    if (faseCorrente < faseBilancio){
                        NewImpMov["idfin"] = DBNull.Value;
                        NewImpMov["idupb"] = DBNull.Value;
                    }
                    ImpMov.Rows.Add(NewImpMov);
                }
            }

            //Imposta il livsupid di tutte le righe per cui è necessario
            foreach (DataRow R in Auto){
                string mov = "";
                if (R["movkind"].ToString().ToLower() == "spesa")
                    mov = "expense";
                else
                    mov = "income";
                string lastMov = mov + "last";

                string view = mov + "view";
                string impMov = mov + "year";
                lastMov = mov + "last";

                DataTable Mov = DS.Tables[mov];
                DataTable ImpMov = DS.Tables[impMov];
                DataTable LastMov = DS.Tables[lastMov];

                if (mov == "expense"){
                    movIdField = "idexp";
                    parentIdField = "parentidexp";
                }
                else{
                    movIdField = "idinc";
                    parentIdField = "parentidinc";
                }

                if (R["parentidmov"] == DBNull.Value) continue;

                object idtolink = R["parentidmov"];
                object idmov = R["idmovimento"];
                int nfasetolink = 0;
                if (R["movkind"].ToString().ToLower() == "spesa"){
                    nfasetolink = CfgFn.GetNoNullInt32(Meta.Conn.DO_READ_VALUE("expense", QHS.CmpEq(movIdField, idtolink), "nphase"));
                }
                else{
                    nfasetolink = CfgFn.GetNoNullInt32(Meta.Conn.DO_READ_VALUE("income", QHS.CmpEq(movIdField, idtolink), "nphase"));
                }

                DataRow MovSel = Mov.Select(QHC.CmpEq(movIdField, idmov))[0];
                int currfase = CfgFn.GetNoNullInt32(MovSel["nphase"]);

                while (currfase > (nfasetolink + 1)){
                    idmov = MovSel[parentIdField];
                    MovSel = Mov.Select(QHC.CmpEq(movIdField, idmov))[0];
                    currfase--;
                }
                MovSel[parentIdField] = idtolink;
            }
            //Cancella tutto ciò che non ha figli e non è di ultima fase* sino a che non trova + nulla,
            // (*)non è necessariamente la maxphase, ma è l'ultima fase che si è generata, che può essere la maxphase o quella del creditore
            faselast = (GeneraTuttelafasi) ? getIntSys("maxexpensephase") : getIntSys("expenseregphase");
            bool keep = true;
            while (keep){
                keep = false;
                string filternolastphase = QHC.CmpNe("nphase", faselast);
                foreach (DataRow Parent in DS.Tables["expense"].Select(filternolastphase))
                {
                    object idpar = Parent["idexp"];
                    string filterchild = QHC.CmpEq("parentidexp", idpar);
                    if (DS.Tables["expense"].Select(filterchild).Length == 0)
                    {
                        string filterimp = QHC.CmpEq("idexp", Parent["idexp"]);
                        DataRow Imp = DS.Tables["expenseyear"].Select(filterimp)[0];
                        Imp.Delete();
                        Parent.Delete();
                        keep = true;
                    }
                }
            }
            faselast = (GeneraTuttelafasi) ? getIntSys("maxincomephase") : getIntSys("incomeregphase");
            keep = true;
            while (keep){
                keep = false;
                string filternolastphase = QHC.CmpNe("nphase", faselast);
                foreach (DataRow Parent in DS.Tables["income"].Select(filternolastphase)){
                    object idpar = Parent["idinc"];
                    string filterchild = QHC.CmpEq("parentidinc", idpar);
                    if (DS.Tables["income"].Select(filterchild).Length == 0){
                        string filterimp = QHC.CmpEq("idinc", Parent["idinc"]);
                        DataRow Imp = DS.Tables["incomeyear"].Select(filterimp)[0];
                        Imp.Delete();
                        Parent.Delete();
                        keep = true;
                    }
                }
            }

            //15 - Lx IVA consolidata interna
            //18 - Lx IVA intrastat consolidata interna
            //16 - Lx IVA consolidata esterna
            //19 - Lx IVA intrastat consolidata esterna
            string filter = "";
            if (sourcekind == "C"){
                filter = "(autokind = 16 or autokind = 19) ";
            }
            else{
                filter = " (autokind = 15 or autokind = 18) ";
            }

            string ivapaymov = "mainivapay" + "expense";
            string idfield = "idexp";
            foreach (DataRow R in DS.Tables["expense"].Select(filter)){
                DataRow NewIvaPay_MovRow = DS.Tables[ivapaymov].NewRow();
                NewIvaPay_MovRow["ymainivapay"] = rIvaPay["ymainivapay"];
                NewIvaPay_MovRow["nmainivapay"] = rIvaPay["nmainivapay"];
                NewIvaPay_MovRow[idfield] = R[idfield];
                NewIvaPay_MovRow["cu"] = "AAAA";
                NewIvaPay_MovRow["ct"] = DateTime.Now;
                NewIvaPay_MovRow["lu"] = "AAAAA";
                NewIvaPay_MovRow["lt"] = DateTime.Now;
                DS.Tables[ivapaymov].Rows.Add(NewIvaPay_MovRow);
            }

            ivapaymov = "mainivapay" + "income";
            idfield = "idinc";
            foreach (DataRow R in DS.Tables["income"].Select(filter)){
                DataRow NewIvaPay_MovRow = DS.Tables[ivapaymov].NewRow();
                NewIvaPay_MovRow["ymainivapay"] = rIvaPay["ymainivapay"];
                NewIvaPay_MovRow["nmainivapay"] = rIvaPay["nmainivapay"];
                NewIvaPay_MovRow[idfield] = R[idfield];
                NewIvaPay_MovRow["cu"] = "AAAA";
                NewIvaPay_MovRow["ct"] = DateTime.Now;
                NewIvaPay_MovRow["lu"] = "AAAAA";
                NewIvaPay_MovRow["lt"] = DateTime.Now;
                DS.Tables[ivapaymov].Rows.Add(NewIvaPay_MovRow);
            }

            foreach (DataRow R in DS.Tables["expense"].Rows){
                R["expiration"] = scadenza;
                string descr = "Liquidazione periodica IVA ";
                if ((R["autokind"].ToString() == "18") || (R["autokind"].ToString() == "19")){
                    descr = "Liquidazione periodica IVA Istituzionale INTRA e Extra-UE";
                }
                R["description"] = descr + " - Mese " + txtMeseNome.Text + " / " + txtEsercizio.Text; 
            }
            foreach (DataRow R in DS.Tables["income"].Rows){
                R["expiration"] = scadenza;
                string descr = "Liquidazione periodica IVA ";
                if ((R["autokind"].ToString() == "18") || (R["autokind"].ToString() == "19")){
                    descr = "Liquidazione periodica IVA Istituzionale INTRA e Extra-UE";
                }
                R["description"] = descr + " - Mese " + txtMeseNome.Text + " / " + txtEsercizio.Text; 

            }

        }

        bool MovimentiFinanziariConfigurati() {
            DataRow rConfIVA = DS.config.Rows[0];
            if ((rConfIVA["mainflagpayment"].ToString().ToUpper() == "S") &&
                (rConfIVA["mainpaymentagency"] != DBNull.Value))
                return true;
            if ((rConfIVA["mainflagrefund"].ToString().ToUpper() == "S") &&
               (rConfIVA["mainrefundagency"] != DBNull.Value)) return true;
            return false;
        }

        bool MovimentiFinanziariConfigurati12(){
            DataRow rConfIVA = DS.config.Rows[0];
            if ((rConfIVA["mainflagpayment12"].ToString().ToUpper() == "S") &&
                (rConfIVA["mainpaymentagency12"] != DBNull.Value))
                return true;
            if ((rConfIVA["mainflagrefund12"].ToString().ToUpper() == "S") &&
               (rConfIVA["mainrefundagency12"] != DBNull.Value)) return true;
            return false;
        }

        /// <summary>
        /// se importo negativo --> iva a credito
        /// </summary>
        /// <param name="importo"></param>
        /// <param name="E_S"></param>
        /// <returns></returns>
        private bool controllaSeCreareAutomatismi(decimal importo){
            if (importo == 0) return false;
            DataRow rConfIVA = DS.config.Rows[0];
            decimal minImporto = 0;
            string generaMov = "";
            if (importo < 0)
            {
                minImporto = CfgFn.GetNoNullDecimal(rConfIVA["mainminrefund"]);
                generaMov = rConfIVA["mainflagrefund"].ToString().ToUpper();
                importo = -importo;

            }
            else
            {
                minImporto = CfgFn.GetNoNullDecimal(rConfIVA["mainminpayment"]);
                generaMov = rConfIVA["mainflagpayment"].ToString().ToUpper();
            }
            return ((importo > minImporto) && (generaMov == "S"));
        }
        private bool controllaSeCreareAutomatismi12(decimal importo){
            if (importo == 0) return false;
            DataRow rConfIVA = DS.config.Rows[0];
            decimal minImporto = 0;
            string generaMov = "";
            if (importo < 0)
            {
                minImporto = CfgFn.GetNoNullDecimal(rConfIVA["mainminrefund12"]);
                generaMov = rConfIVA["mainflagrefund12"].ToString().ToUpper();
                importo = -importo;

            }
            else
            {
                minImporto = CfgFn.GetNoNullDecimal(rConfIVA["mainminpayment12"]);
                generaMov = rConfIVA["mainflagpayment12"].ToString().ToUpper();
            }
            return ((importo > minImporto) && (generaMov == "S"));
        }

        private void ImpostaLabel(decimal importo, Label lbl)   {
            if (importo > 0)
                lbl.Text = "a debito";
            else {
                if (importo < 0)
                    lbl.Text = "a credito";
                else
                    lbl.Text = "";
            }
        }

        DataTable TableIva = null;
        DataTable TableIva_dipartimenti = null;

        bool EsistenzaMappaturaUnifiedRegister(){
            object ayear = HelpForm.GetObjectFromString(typeof(int), txtEsercizio.Text, null);
            object nmonth = HelpForm.GetObjectFromString(typeof(int), txtMese.Text, null);
            object[] param = new object[] { ayear, nmonth };
            DataSet DSiva = Conn.CallSP("check_unified_totivapay", param, true);
            if (DSiva == null || DSiva.Tables.Count == 0 || DSiva.Tables[0].Rows.Count==0){
                return true;
            }
            else{
                string errore = "Esistono dei Dipartimenti i cui registri IVA non hanno il codice Consoidamento:";
                foreach (DataRow r in DSiva.Tables[0].Rows){
                    errore += "\n Dipartimento: " + r["department"] + ". Registro: " + r["description"] + ";";
                }
                errore += "\n\nImpostare il codice di Consolidamento.";
                show(this, errore);
                return false;
            }
        }

        byte calcolaFlag()
        {
            bool comm_promiscua_kind = chkCommerciale.Checked;
            bool istituzionale_kind = chkIstituzionale.Checked;
            byte flag = 0;
            flag = 0;
            if (comm_promiscua_kind) flag += 1;
            if (istituzionale_kind) flag += 2;
            return flag;
        }

        bool CalcolaLiquidazione() {
            object ayear = HelpForm.GetObjectFromString(typeof(int), txtEsercizio.Text, null);
            object nmonth = HelpForm.GetObjectFromString(typeof(int), txtMese.Text, null);

            bool comm_promiscua_kind = chkCommerciale.Checked;
            bool istituzionale_kind = chkIstituzionale.Checked;
            byte flag = calcolaFlag();
            object[] param = new object[] { ayear, nmonth, flag };
            DataSet DSiva = Conn.CallSP("compute_unified_totivapay", param, true);
            if (DSiva == null || DSiva.Tables.Count == 0) return false;
            TableIva = DSiva.Tables[0];
            return true;
        }
        private void CalcolaTotali() {

            CalcolaTabPageIva();

            txtIvaPeriodo.Text = Math.Abs(ivadelperiodo).ToString("c");
            ImpostaLabel(ivadelperiodo, lblcredito2);

            txtIvaPeriodo12.Text = Math.Abs(ivadelperiodo12).ToString("c");
            ImpostaLabel(ivadelperiodo12, lab_credito2_12);

            bool movfinanziariConfig = false;
            if (!MovimentiFinanziariConfigurati()){
                liquidazionecorrente = ivadelperiodo;
                movfinanziariConfig = false;
                //return;
            }
            else{
                movfinanziariConfig = true;
            }

            bool movfinanziariConfig12 = false;
            if (!MovimentiFinanziariConfigurati12()){
                liquidazionecorrente12 = ivadelperiodo12;
                movfinanziariConfig12 = false;
                //return;
            }
            else{
                movfinanziariConfig12 = true;
            }

            object esercizio = Meta.GetSys("esercizio");

            string sql = "SELECT SUM(paymentamount) AS paymentamount, SUM(paymentamount12) as paymentamount12,"
                + "SUM(refundamount) AS refundamount, SUM(refundamount12) as refundamount12, "
                + "SUM(totaldebit) AS totaldebit, SUM(totaldebit12) as totaldebit12,"
                + "SUM(totalcredit) AS totalcredit, SUM(totalcredit12) as totalcredit12 "
                + "FROM mainivapay ";
            string filter = "WHERE " + QHS.CmpEq("ymainivapay", esercizio);
            DataTable T = Conn.SQLRunner(sql + filter, false);

            decimal saldoiniziale = 0;
            if (chkCommerciale.Checked)
            {
                saldoiniziale = -startivabalance;
            }

            decimal saldoiniziale12 = 0;
            if (chkIstituzionale.Checked)
            {
                saldoiniziale12 = -startivabalance12;
            }

            saldo_precedente = saldoiniziale;
            saldo_precedente12 = saldoiniziale12;
            if (T != null && T.Rows.Count > 0)
            {
                DataRow R = T.Rows[0];
                if (chkCommerciale.Checked)
                {
                    saldo_precedente = saldo_precedente
                                       + CfgFn.GetNoNullDecimal(R["totaldebit"])
                                       - CfgFn.GetNoNullDecimal(R["paymentamount"])

                                       - CfgFn.GetNoNullDecimal(R["totalcredit"])
                                       + CfgFn.GetNoNullDecimal(R["refundamount"]);
                }
                if (chkIstituzionale.Checked)
                {
                    saldo_precedente12 = saldo_precedente12
                                   + CfgFn.GetNoNullDecimal(R["totaldebit12"])
                                   - CfgFn.GetNoNullDecimal(R["paymentamount12"])

                                   - CfgFn.GetNoNullDecimal(R["totalcredit12"])
                                   + CfgFn.GetNoNullDecimal(R["refundamount12"]);
                }
            }

            if ((movfinanziariConfig) && (chkCommerciale.Checked))
            {
                txtSaldoPrec.Text = Math.Abs(saldo_precedente).ToString("c");
                ImpostaLabel(saldo_precedente, lblcredito1);
                totaleiva = ivadelperiodo + saldo_precedente;
                txtTotaleIva.Text = Math.Abs(totaleiva).ToString("c");
                ImpostaLabel(totaleiva, labCredito3);

                liquidazionecorrente = 0;
                if (controllaSeCreareAutomatismi(totaleiva))
                {
                    liquidazionecorrente = totaleiva;
                }

                txtLiquidMese.Text = Math.Abs(liquidazionecorrente).ToString("c");
                ImpostaLabel(liquidazionecorrente, labCredito4);
                nuovosaldo = totaleiva - liquidazionecorrente;
                txtNuovoSaldo.Text = Math.Abs(nuovosaldo).ToString("c");
                ImpostaLabel(nuovosaldo, lblcredito5);
            }
            else
            {
                txtSaldoPrec.Text = "";
                txtTotaleIva.Text = "";
                txtLiquidMese.Text = "";
                txtNuovoSaldo.Text = "";
                lblcredito1.Text = "";
                labCredito3.Text = "";
                labCredito4.Text = "";
                lblcredito5.Text = "";
            }

            if ((movfinanziariConfig12) && (chkIstituzionale.Checked))
            {
                txtSaldoPrec12.Text = Math.Abs(saldo_precedente12).ToString("c");
                ImpostaLabel(saldo_precedente12, lab_credito1_12);
                totaleiva12 = ivadelperiodo12 + saldo_precedente12;
                txtTotaleIva12.Text = Math.Abs(totaleiva12).ToString("c");
                ImpostaLabel(totaleiva12, lab_credito3_12);

                liquidazionecorrente12 = 0;
                if (controllaSeCreareAutomatismi12(totaleiva12))
                {
                    liquidazionecorrente12 = totaleiva12;
                }

                txtLiquidMese12.Text = Math.Abs(liquidazionecorrente12).ToString("c");
                ImpostaLabel(liquidazionecorrente12, lab_credito4_12);
                nuovosaldo12 = totaleiva12 - liquidazionecorrente12;
                txtNuovoSaldo12.Text = Math.Abs(nuovosaldo12).ToString("c");
                ImpostaLabel(nuovosaldo12, lab_credito5_12);
            }
            else
            {
                txtSaldoPrec12.Text = "";
                txtTotaleIva12.Text = "";
                txtLiquidMese12.Text = "";
                txtNuovoSaldo12.Text = "";
                lab_credito1_12.Text = "";
                lab_credito3_12.Text = "";
                lab_credito4_12.Text = "";
            }

        }

        decimal totale_iva_debito = 0;
        decimal totale_iva_credito = 0;
        decimal totale_iva_debito12 = 0;
        decimal totale_iva_credito12 = 0;

        decimal vendite_immediata = 0;
        decimal vendite_deferred = 0;

        decimal acqcomm_immediata = 0;
        decimal acqcomm_immediata_indetr = 0;
        decimal acqcomm_deferred = 0;
        decimal acqcomm_deferred_indetr = 0;

        decimal acqprom_immediata = 0;
        decimal acqprom_immediata_indetr = 0;
        decimal acqprom_deferred = 0;
        decimal acqprom_deferred_indetr = 0;

    

        decimal saldo_precedente = 0;    //si intende come IVA A DEBITO
        decimal saldo_precedente12 = 0;    //si intende come IVA A DEBITO

        decimal startivabalance;
        decimal startivabalance12;
        decimal startivabalancesplit;

      
        decimal ivadelperiodo = 0;
        decimal ivadelperiodo12 = 0;

        decimal totaleiva = 0;
        decimal totaleiva12 = 0;
        decimal liquidazionecorrente = 0;
        decimal liquidazionecorrente12 = 0;
        decimal nuovosaldo = 0;
        decimal nuovosaldo12 = 0;

        decimal credito_immediato = 0;
        decimal credito_differito = 0;
        decimal debito_immediato12 = 0;
        decimal debito_differito12 = 0;
        decimal credito_immediato12 = 0;
        decimal credito_differito12 = 0;


        decimal impdebito_immediato12 = 0;
        decimal impdebito_differito12 = 0;
        decimal impcredito_immediato12 = 0;
        decimal impcredito_differito12 = 0;

        decimal taxableintrastat12 = 0;
        decimal ivaintrastat12 = 0;

        decimal getProrata() {
            return (decimal)HelpForm.GetObjectFromString(typeof(decimal), txtProrata.Text, tag_perc);
        }

        decimal getPromiscuo(){
            return (decimal)HelpForm.GetObjectFromString(typeof(decimal), txtPromiscuo.Text, tag_perc);
        }

        void CalcolaTabPageIva() {
            decimal perc_promiscuo = getPromiscuo();
            decimal perc_prorata = getProrata();

            credito_immediato = 0;//calcolati riga per riga
            credito_differito = 0;//calcolati riga per riga

            totale_iva_credito = 0;  //somma definitiva del  prorata riga per riga oppure sul totale
            //in base alla configuraazione

            vendite_immediata = 0;
            vendite_deferred = 0;

            debito_immediato12 = 0;
            debito_differito12 = 0;
            credito_immediato12 = 0;
            credito_differito12 = 0;

            impdebito_immediato12 = 0;
            impdebito_differito12 = 0;
            impcredito_immediato12 = 0;
            impcredito_differito12 = 0;

            acqcomm_immediata = 0;
            acqcomm_immediata_indetr = 0;
            acqcomm_deferred = 0;
            acqcomm_deferred_indetr = 0;

            acqprom_immediata = 0;
            acqprom_immediata_indetr = 0;
            acqprom_deferred = 0;
            acqprom_deferred_indetr = 0;

        
            decimal imposta_imm = 0;
            decimal imposta_diff = 0;
            decimal taxable_imm = 0;
            decimal taxable_diff = 0;

            TableIva.Columns.Add("singola_imm", typeof(Decimal));
            TableIva.Columns.Add("singola_diff", typeof(Decimal));

            foreach (DataRow R in TableIva.Rows){

                bool acquisto = R["registerclass"].ToString().ToUpper() == "A";
                //bool promiscuo = R["flagmixed"].ToString().ToUpper() == "S";
                bool istituzionale = false;
                bool commerciale = false;
                bool promiscuo = false;
                // Non è necessario interrogare il flgaintracom, perchè attingiamo direttamente dalla sp, quindi l'iva
                // istituzionale è solo INTRA.
                if (CfgFn.GetNoNullInt32(R["flagactivity"]) == 1) istituzionale = true;
                if (CfgFn.GetNoNullInt32(R["flagactivity"]) == 2) commerciale = true;
                if (CfgFn.GetNoNullInt32(R["flagactivity"]) == 3) promiscuo = true;
                if (!istituzionale){
                    imposta_imm = CfgFn.GetNoNullDecimal(R["iva_imm"]);// txt 'Totale' di Immediata
                    imposta_diff = CfgFn.GetNoNullDecimal(R["iva_diff"]);// txt 'Totale' di Differita
                }
                else{
                    imposta_imm = CfgFn.GetNoNullDecimal(R["iva12_imm"]);
                    imposta_diff = CfgFn.GetNoNullDecimal(R["iva12_diff"]);
                }
                if (acquisto) {
                        decimal indetraibile_singolo_imm = 0, indetraibile_singolo_diff = 0;
                        if (!istituzionale){
                            if (ModoCalcolo_RigaPerRiga){
                                // Sono valori al netto del promiscuo e prorata.
                                R["singola_imm"] = CfgFn.GetNoNullDecimal(R["ivanet_imm"]);
                                indetraibile_singolo_imm = CfgFn.GetNoNullDecimal(R["unabatablenet_imm"]);
                                R["singola_diff"] = CfgFn.GetNoNullDecimal(R["ivanet_diff"]);
                                indetraibile_singolo_diff = CfgFn.GetNoNullDecimal(R["unabatablenet_diff"]);
                            }
                            else{
                                // Il promiscuo e il prorata li applicheremo dopo, sul totale complessivo.
                                R["singola_imm"] = CfgFn.GetNoNullDecimal(R["iva_imm"]) - CfgFn.GetNoNullDecimal(R["unabatable_imm"]);
                                indetraibile_singolo_imm = CfgFn.GetNoNullDecimal(R["unabatable_imm"]);
                                R["singola_diff"] = CfgFn.GetNoNullDecimal(R["iva_diff"]) - CfgFn.GetNoNullDecimal(R["unabatable_diff"]);
                                indetraibile_singolo_diff = CfgFn.GetNoNullDecimal(R["unabatable_diff"]);
                            }
                        }
                        else {
                                R["singola_imm"] = CfgFn.GetNoNullDecimal(R["iva12_imm"]);
                                R["singola_diff"] = CfgFn.GetNoNullDecimal(R["iva12_diff"]);
                                indetraibile_singolo_imm = CfgFn.GetNoNullDecimal(R["iva12_imm"]);
                                indetraibile_singolo_diff = CfgFn.GetNoNullDecimal(R["iva12_diff"]);
                                taxable_imm = CfgFn.GetNoNullDecimal(R["taxable12_imm"]);
                                taxable_diff = CfgFn.GetNoNullDecimal(R["taxable12_diff"]);
                           }

                        if (promiscuo) {
                            acqprom_immediata += imposta_imm;
                            acqprom_immediata_indetr += indetraibile_singolo_imm;
                            acqprom_deferred += imposta_diff;
                            acqprom_deferred_indetr += indetraibile_singolo_diff;
                        }
                        if(commerciale){
                            acqcomm_immediata += imposta_imm;
                            acqcomm_immediata_indetr += indetraibile_singolo_imm;
                            acqcomm_deferred += imposta_diff;
                            acqcomm_deferred_indetr += indetraibile_singolo_diff;
                        }
                        if (istituzionale){
                            debito_immediato12 += imposta_imm;
                            impdebito_immediato12 += taxable_imm;

                            debito_differito12 += imposta_diff;
                            impdebito_differito12 += taxable_diff;
                        }

                    // Il totale_iva_credito viene ricalcolo dopo, per chi calcola sul totale.
                        if (!istituzionale){
                            totale_iva_credito += CfgFn.GetNoNullDecimal(R["ivanet_imm"]) + CfgFn.GetNoNullDecimal(R["ivanet_diff"]);

                            credito_immediato += CfgFn.GetNoNullDecimal(R["ivanet_imm"]); //E' comunque calcolato sulla base riga per riga
                            credito_differito += CfgFn.GetNoNullDecimal(R["ivanet_diff"]);
                        }
                }
                else{ 
                    //vendita
                    if (istituzionale) {
                        credito_immediato12 += imposta_imm;
                        impcredito_immediato12 += taxable_imm;
                        credito_differito12 += imposta_diff;
                        impcredito_differito12 += taxable_diff;
                    }
                    else{
                        vendite_immediata += imposta_imm;
                        vendite_deferred += imposta_diff;
                    }
                    R["singola_imm"] = imposta_imm;
                    R["singola_diff"] = imposta_diff;
                }

            } //foreach

            txtIvaDebitoImmediata.Text = vendite_immediata.ToString("c");
            txtIvaDebitoDifferita.Text = vendite_deferred.ToString("c");

            txtIvaCreditoTotaleImmediata.Text = acqcomm_immediata.ToString("c");
            txtIndetraibileImmediata.Text = acqcomm_immediata_indetr.ToString("c");
            decimal detraibile_immediata_comm = acqcomm_immediata - acqcomm_immediata_indetr;
            txtIvaCreditoImmediata.Text = detraibile_immediata_comm.ToString("c");

            txtIvaCreditoTotaleDifferita.Text = acqcomm_deferred.ToString("c");
            txtIndetraibileDifferita.Text = acqcomm_deferred_indetr.ToString("c");
            decimal detraibile_differita_comm = acqcomm_deferred - acqcomm_deferred_indetr;
            txtIvaCreditoDifferita.Text = detraibile_differita_comm.ToString("c");


            decimal detraibile_commerciale = detraibile_immediata_comm + detraibile_differita_comm;
            txtIvaCreditoTotaleCommerciale.Text = detraibile_commerciale.ToString("c");


            txtIvaCreditoTotaleImmediataPromiscui.Text = acqprom_immediata.ToString("c");
            txtIndetraibileImmediataPromiscui.Text = acqprom_immediata_indetr.ToString("c");
            decimal detraibile_immediata_prom = acqprom_immediata - acqprom_immediata_indetr;
            txtIvaCreditoImmediataPromiscui.Text = detraibile_immediata_prom.ToString("c");

            txtIvaCreditoTotaleDifferitaPromiscui.Text = acqprom_deferred.ToString("c");
            txtIndetraibileDifferitaPromiscui.Text = acqprom_deferred_indetr.ToString("c");
            decimal detraibile_differita_prom = acqprom_deferred - acqprom_deferred_indetr;
            txtIvaCreditoDifferitaPromiscui.Text = detraibile_differita_prom.ToString("c");


            decimal detraibile_promiscui = detraibile_immediata_prom + detraibile_differita_prom;
            txtIvaCreditoTotalePromiscui.Text = detraibile_promiscui.ToString("c");

            decimal detraibile_promiscuiPOST = detraibile_promiscui;
            if (!ModoCalcolo_RigaPerRiga){
                labTotIvaPromPOST.Visible = true;
                txtIvaCreditoTotalePromiscuiPOST.Visible = true;
                detraibile_promiscuiPOST = CfgFn.Round(
                    detraibile_promiscui * perc_promiscuo, 2);
                txtIvaCreditoTotalePromiscuiPOST.Text = detraibile_promiscuiPOST.ToString("c");
            }
            else{
                labTotIvaPromPOST.Visible = false;
                txtIvaCreditoTotalePromiscuiPOST.Visible = false;
            }



            totale_iva_debito = vendite_immediata + vendite_deferred;
            txtIvaDebito.Text = totale_iva_debito.ToString("c");

            decimal ivacredito = detraibile_commerciale + detraibile_promiscuiPOST;
            txtIvaCredito.Text = ivacredito.ToString("c");

            if (!ModoCalcolo_RigaPerRiga)
            {
                labTotDopoProrata.Visible = true;
                txtIvaCreditoProrata.Visible = true;
                totale_iva_credito = CfgFn.Round(ivacredito * perc_prorata, 2);
                txtIvaCreditoProrata.Text = totale_iva_credito.ToString("c");
            }
            else
            {
                labTotDopoProrata.Visible = false;
                txtIvaCreditoProrata.Visible = false;
            }

            ivadelperiodo = totale_iva_debito - totale_iva_credito;

            // Parte nuova relativa all'iva INTRA-12
            decimal netto_ivadeb_imm = debito_immediato12 - credito_immediato12;
            decimal netto_impdeb_imm = impdebito_immediato12 - impcredito_immediato12;
            txtImpIstituzImmed.Text = netto_impdeb_imm.ToString("c");
            txtIvaIstituzImmed.Text = netto_ivadeb_imm.ToString("c");

            decimal netto_ivadeb_def = debito_differito12 - credito_differito12;
            decimal netto_impdeb_def = impdebito_differito12 - impcredito_differito12;
            txtImpIstituzDeferr.Text = netto_impdeb_def.ToString("c");
            txtIvaIstituzDeferr.Text = netto_ivadeb_def.ToString("c");


            decimal netto_iva12 = netto_ivadeb_imm + netto_ivadeb_def;
            decimal netto_impo12 = netto_impdeb_imm + netto_impdeb_def;
            taxableintrastat12 = netto_impo12;
            ivaintrastat12 = netto_iva12;

            totale_iva_debito12 = debito_immediato12 + debito_differito12;
            totale_iva_credito12 = credito_immediato12 + credito_differito12;

            txtTotImpIstituz.Text = netto_impo12.ToString("c");
            txtTotIvaIstituz.Text = netto_iva12.ToString("c");

            txtTotIvaIstituzIntrastat.Text = netto_iva12.ToString("c");
            ivadelperiodo12 = netto_iva12;
        }


        private void CalcolaIVA()     {
            DataSet DSRegistry = new DataSet();
            DataTable AcquistiComm = new DataTable();
            DataTable AcquistiProm = new DataTable();
            DataTable Vendite = new DataTable();
            DataTable AcquistiIst = new DataTable();

            AcquistiComm.Columns.Add("codeivaregisterkind", typeof(string));
            AcquistiProm.Columns.Add("codeivaregisterkind", typeof(string));
            Vendite.Columns.Add("codeivaregisterkind", typeof(string));
            AcquistiIst.Columns.Add("codeivaregisterkind", typeof(string));

            AcquistiComm.Columns.Add("description", typeof(string));
            AcquistiProm.Columns.Add("description", typeof(string));
            Vendite.Columns.Add("description", typeof(string));
            AcquistiIst.Columns.Add("description", typeof(string));

            AcquistiIst.Columns.Add("taxable_imm", typeof(decimal));
            AcquistiIst.Columns.Add("taxable_diff", typeof(decimal));

            AcquistiComm.Columns.Add("iva_imm", typeof(decimal));
            AcquistiProm.Columns.Add("iva_imm", typeof(decimal));
            Vendite.Columns.Add("iva_imm", typeof(decimal));
            AcquistiIst.Columns.Add("iva_imm", typeof(decimal));

            AcquistiComm.Columns.Add("iva_diff", typeof(decimal));
            AcquistiProm.Columns.Add("iva_diff", typeof(decimal));
            Vendite.Columns.Add("iva_diff", typeof(decimal));
            AcquistiIst.Columns.Add("iva_diff", typeof(decimal));

            AcquistiComm.Columns.Add("unabatable_imm", typeof(decimal));
            AcquistiProm.Columns.Add("unabatable_imm", typeof(decimal));

            AcquistiComm.Columns.Add("unabatable_diff", typeof(decimal));
            AcquistiProm.Columns.Add("unabatable_diff", typeof(decimal));

            AcquistiComm.Columns.Add("department", typeof(string));
            AcquistiProm.Columns.Add("department", typeof(string));
            Vendite.Columns.Add("department", typeof(string));
            AcquistiIst.Columns.Add("department", typeof(string));

            DSRegistry.Tables.Add(AcquistiComm);
            DSRegistry.Tables.Add(AcquistiProm);
            DSRegistry.Tables.Add(Vendite);
            DSRegistry.Tables.Add(AcquistiIst);

            foreach (DataRow R in TableIva.Rows) {
                string searchreg = QHC.AppAnd(QHC.CmpEq("codeivaregisterkind", R["codeivaregisterkind"]),
                            QHC.CmpEq("department", R["department"]));
                bool istituzionale = (CfgFn.GetNoNullInt32(R["flagactivity"]) == 1);
                bool commerciale = false;
                bool promiscuo = false;
                if (CfgFn.GetNoNullInt32(R["flagactivity"]) == 2) commerciale = true;
                if (CfgFn.GetNoNullInt32(R["flagactivity"]) == 3) promiscuo = true;
                bool acquisto = R["registerclass"].ToString().ToUpper() == "A";

                DataRow RRegistro = null;
                DataTable TRegistro = null;
                if (acquisto) {
                    if (promiscuo) TRegistro = AcquistiProm;
                    if (commerciale) TRegistro = AcquistiComm;
                    if (istituzionale) TRegistro = AcquistiIst;
                }
                else{
                    TRegistro = Vendite;
                }

                DataRow[] Regs = TRegistro.Select(searchreg);
                if (Regs.Length > 0){
                    RRegistro = Regs[0];
                }
                else{
                    RRegistro = TRegistro.NewRow();

                    RRegistro["iva_imm"] = 0;
                    RRegistro["iva_diff"] = 0;
                    if (acquisto && !istituzionale){
                        RRegistro["unabatable_imm"] = 0;
                        RRegistro["unabatable_diff"] = 0;
                    }
                }
                RRegistro["department"] = R["department"];
                RRegistro["codeivaregisterkind"] = R["codeivaregisterkind"];
                RRegistro["description"] = R["description"];

                if (!istituzionale){
                    // Continua a fare ciò che faceva prima
                    decimal ivatotale_imm = CfgFn.GetNoNullDecimal(R["iva_imm"]);
                    decimal ivatotale_diff = CfgFn.GetNoNullDecimal(R["iva_diff"]);
                    decimal ivadetraibile_imm = CfgFn.GetNoNullDecimal(R["singola_imm"]);
                    decimal ivadetraibile_diff = CfgFn.GetNoNullDecimal(R["singola_diff"]);
                    decimal ivaindetraibile_imm = CfgFn.GetNoNullDecimal(R["unabatable_imm"]);
                    decimal ivaindetraibile_diff = CfgFn.GetNoNullDecimal(R["unabatable_diff"]);
                    RRegistro["iva_imm"] = CfgFn.GetNoNullDecimal(RRegistro["iva_imm"]) + ivatotale_imm;
                    RRegistro["iva_diff"] = CfgFn.GetNoNullDecimal(RRegistro["iva_diff"]) + ivatotale_diff;
                    if (acquisto){
                        RRegistro["unabatable_imm"] = CfgFn.GetNoNullDecimal(RRegistro["unabatable_imm"]) +
                            ivaindetraibile_imm;
                        RRegistro["unabatable_diff"] = CfgFn.GetNoNullDecimal(RRegistro["unabatable_diff"]) +
                            ivaindetraibile_diff;
                    }
                    if (Regs.Length == 0){
                        TRegistro.Rows.Add(RRegistro);
                    }
                }
                else{
                    // Elabora la parte istituzionale INTRA
                    decimal ivatotale_imm = CfgFn.GetNoNullDecimal(R["iva12_imm"]);
                    decimal ivatotale_diff = CfgFn.GetNoNullDecimal(R["iva12_diff"]);
                    decimal taxabletotale_imm = CfgFn.GetNoNullDecimal(R["taxable12_imm"]);
                    decimal taxabletotale_diff = CfgFn.GetNoNullDecimal(R["taxable12_diff"]);
                    RRegistro["iva_imm"] = CfgFn.GetNoNullDecimal(RRegistro["iva_imm"]) + ivatotale_imm;
                    RRegistro["iva_diff"] = CfgFn.GetNoNullDecimal(RRegistro["iva_diff"]) + ivatotale_diff;
                    RRegistro["taxable_imm"] = CfgFn.GetNoNullDecimal(RRegistro["taxable_imm"]) + taxabletotale_imm;
                    RRegistro["taxable_diff"] = CfgFn.GetNoNullDecimal(RRegistro["taxable_diff"]) + taxabletotale_diff;

                    if (Regs.Length == 0){
                        TRegistro.Rows.Add(RRegistro);
                    }
                }
            }

            AcquistiComm.AcceptChanges();
            AcquistiProm.AcceptChanges();
            Vendite.AcceptChanges();
            AcquistiIst.AcceptChanges();

            ImpostaIVADebito(Vendite);
            ImpostaIVACreditoCommerciale(AcquistiComm);
            ImpostaIVACreditoPromiscui(AcquistiProm);
            ImpostaIVADebitoIstituzionale(AcquistiIst);
        }

        private void ImpostaIVADebito(DataTable T){
            if (T == null) return;
            T.Columns["codeivaregisterkind"].Caption = "Codice";
            T.Columns["description"].Caption = "Registro";
            T.Columns["iva_imm"].Caption = "Iva totale Imm.";
            T.Columns["iva_diff"].Caption = "Iva totale Diff.";
            T.Columns["department"].Caption = "Dipartimento";

            HelpForm.SetFormatForColumn(T.Columns["iva_imm"], "c");
            HelpForm.SetFormatForColumn(T.Columns["iva_diff"], "c");
            gridDebito.DataSource = null;
            HelpForm.SetDataGrid(gridDebito, T);
        }

        private void ImpostaIVADebitoIstituzionale(DataTable T){
            if (T == null) return;
            T.Columns["codeivaregisterkind"].Caption = "Codice";
            T.Columns["description"].Caption = "Registro";
            T.Columns["taxable_imm"].Caption = "Imponibile netto Imm.";
            T.Columns["taxable_diff"].Caption = "Imponibile netto Diff.";
            T.Columns["iva_imm"].Caption = "Iva totale Imm.";
            T.Columns["iva_diff"].Caption = "Iva totale Diff.";
            T.Columns["taxable_imm"].Caption = "Imponibile totale Imm.";
            T.Columns["taxable_diff"].Caption = "Imponibile totale Diff.";
            T.Columns["department"].Caption = "Dipartimento";

            HelpForm.SetFormatForColumn(T.Columns["iva_imm"], "c");
            HelpForm.SetFormatForColumn(T.Columns["iva_diff"], "c");
            HelpForm.SetFormatForColumn(T.Columns["taxable_imm"], "c");
            HelpForm.SetFormatForColumn(T.Columns["taxable_diff"], "c");

            gridacquistiistituzionaliINTRA.DataSource = null;
            HelpForm.SetDataGrid(gridacquistiistituzionaliINTRA, T);
        }

        private void ImpostaIVACreditoCommerciale(DataTable T){
            if (T == null) return;
            T.Columns["codeivaregisterkind"].Caption = "Codice";
            T.Columns["description"].Caption = "Registro";
            T.Columns["iva_imm"].Caption = "Iva totale Imm.";
            T.Columns["iva_diff"].Caption = "Iva totale Diff.";
            T.Columns["unabatable_imm"].Caption = "Iva Indetraibile Imm.";
            T.Columns["unabatable_diff"].Caption = "Iva Indetraibile Diff.";
            T.Columns["department"].Caption = "Dipartimento";

            HelpForm.SetFormatForColumn(T.Columns["iva_imm"], "c");
            HelpForm.SetFormatForColumn(T.Columns["iva_diff"], "c");
            HelpForm.SetFormatForColumn(T.Columns["unabatable_imm"], "c");
            HelpForm.SetFormatForColumn(T.Columns["unabatable_diff"], "c");
            gridAcquisti.DataSource = null;
            HelpForm.SetDataGrid(gridAcquisti, T);
        }

        private void ImpostaIVACreditoPromiscui(DataTable T) {
            if (T == null) return;
            T.Columns["codeivaregisterkind"].Caption = "Codice";
            T.Columns["description"].Caption = "Registro";
            T.Columns["iva_imm"].Caption = "Iva totale Imm.";
            T.Columns["iva_diff"].Caption = "Iva totale Diff.";
            T.Columns["unabatable_imm"].Caption = "Iva Indetraibile Imm.";
            T.Columns["unabatable_diff"].Caption = "Iva Indetraibile Diff.";
            T.Columns["department"].Caption = "Dipartimento";

            HelpForm.SetFormatForColumn(T.Columns["iva_imm"], "c");
            HelpForm.SetFormatForColumn(T.Columns["iva_diff"], "c");
            HelpForm.SetFormatForColumn(T.Columns["unabatable_imm"], "c");
            HelpForm.SetFormatForColumn(T.Columns["unabatable_diff"], "c");
            gridacquistipromiscui.DataSource = null;
            HelpForm.SetDataGrid(gridacquistipromiscui, T);
        }


        private void ComputePeriod(int periodo) {
            // DA RIMUOVERE CIO' CHE RIGUARDA LA PERIODICITA' PERCHE' NON SERVE. CONTA SOLO IL MESE. 
            // Abbiamo valorizzato periodo a 1, ossia ogni mese.
            //calcolo periodo default (periodo precedente)
            if (periodo <= 0) return;
            DateTime data = ((DateTime)Meta.GetSys("datacontabile"));
            int year = data.Year;
            int month = (data.Month - periodo > 0 ? data.Month - periodo : 12 + data.Month - periodo);
            //se sono a cavallo dell'anno nuovo la liquidazione cade nell'anno prima
            if ((month + periodo) > 12)   {
                month = month - periodo + 1;
                year--;
            }
            DateTime FromDate = new DateTime(year, month, 1);
            m_ToDate = FromDate.AddMonths(periodo - 1);
            m_ToDate = m_ToDate.AddDays(DateTime.DaysInMonth(year, m_ToDate.Month) - 1);
            //forza la liquidazione del periodo corrente per il solo mese di dicembre
            //se è stata scelta tale opzione
            if ((chkEndOfYear.Checked) && (data.Month == 12))
            {
                FromDate = m_ToDate.AddDays(1);
                m_ToDate = new DateTime(data.Year, 12, 31);
            }

            txtEsercizio.Text = HelpForm.StringValue(FromDate.Year, null);
            txtMese.Text = HelpForm.StringValue(m_ToDate.Month, null);

            object mese = Meta.Conn.DO_READ_VALUE("monthname", QHS.CmpEq("code", m_ToDate.Month), "title");
            txtMeseNome.Text = mese.ToString();
        }

        private void chkEndOfYear_CheckedChanged(object sender, EventArgs e){
            ComputePeriod(periodo);
        }
        void EditEntry(DataRow Curr_ivapay) {
            //			if (DS.ivapay.Rows.Count==0) return;
            //			EP_functions EP= new EP_functions(Meta.Dispatcher);
            //			EP.EditRelatedEntry(Meta,DS.ivapay.Rows[0]);	

            EP_functions EP = new EP_functions(Meta.Dispatcher);
            EP.EditRelatedEntry(Meta, Curr_ivapay);
        }

        int nvaloridiversi(string column, DataRow[] ROWS){
            string outstring = "";
            int diversi = 0;
            foreach (DataRow R in ROWS){
                //if (R[column]==DBNull.Value) continue;
                string quoted = QueryCreator.quotedstrvalue(R[column], false);
                if (outstring.IndexOf(quoted) >= 0) continue;
                if (outstring != "") outstring += ",";
                outstring += quoted;
                diversi++;
            }
            return diversi;
        }

        string GetFilterForSelection(DataRow[] Selected, string table, int livello){
            string filter = "";
            int minfasecred = 99;
            int minfasebil = 99;
            if (table == "expense"){
                minfasecred = Convert.ToInt32(Conn.GetSys("expenseregphase"));
                minfasebil = Convert.ToInt32(Conn.GetSys("expensefinphase"));
            }
            if (table == "income"){
                minfasecred = Convert.ToInt32(Conn.GetSys("incomeregphase"));
                minfasebil = Convert.ToInt32(Conn.GetSys("incomefinphase"));
            }

            if (livello >= minfasebil){
                object O = Selected[0]["idfin"];
                if (O != DBNull.Value){
                    filter = QHS.AppAnd(filter, QHS.CmpEq("idfin", O));
                }
            }

            if (livello >= minfasecred){
                object O = Selected[0]["idreg"];
                if (O != DBNull.Value)
                {
                    filter = QHS.AppAnd(filter, QHS.CmpEq("idreg", O));
                }
            }

            if (livello >= minfasebil){
                object O = Selected[0]["idupb"];
                if (O != DBNull.Value)
                {
                    filter = QHS.AppAnd(filter, QHS.CmpEq("idupb", O));
                }
            }
            return filter;
        }

        DataRow GetGridRow(DataGrid G, int index){
            string TableName = G.DataMember.ToString();
            DataSet MyDS = (DataSet)G.DataSource;
            DataTable MyTable = MyDS.Tables[TableName];
            string filter;
            if (MyTable.TableName == "expenseview")
                filter = QHC.CmpEq("idexp", G[index, 0]);
            else
                filter = QHC.CmpEq("idinc", G[index, 0]);
            DataRow[] selectresult = MyTable.Select(filter);
            return selectresult[0];
        }

        private DataRow[] GetGridSelectedRows(DataGrid G){
            string TableName = G.DataMember.ToString();
            DataSet MyDS = (DataSet)G.DataSource;
            DataTable MyTable = MyDS.Tables[TableName];
            int numrighetemp = MyTable.Rows.Count;
            int numrighe = 0;
            int i;
            for (i = 0; i < numrighetemp; i++){
                if (G.IsSelected(i)){
                    numrighe++;
                }
            }

            DataRow[] Res = new DataRow[numrighe];
            int count = 0;
            for (i = 0; i < numrighetemp; i++){
                if (G.IsSelected(i)){
                    Res[count++] = GetGridRow(G, i);
                }
            }
            return Res;
        }
        int GetMaxFaseForSelection(DataRow[] Selected, string table){
            int minfasecred = 99;
            int minfasebil = 99;
            if (table == "expense"){
                minfasecred = Convert.ToInt32(Conn.GetSys("expenseregphase"));
                minfasebil = Convert.ToInt32(Conn.GetSys("expensefinphase"));
            }
            if (table == "income"){
                minfasecred = Convert.ToInt32(Conn.GetSys("incomeregphase"));
                minfasebil = Convert.ToInt32(Conn.GetSys("incomefinphase"));
            }

            int fasecurr = 99;
            if (table == "income"){
                fasecurr = (GeneraTuttelafasi) ? getIntSys("maxincomephase") : getIntSys("incomeregphase");
                fasecurr = fasecurr - 1;
            }
            else{
                fasecurr = (GeneraTuttelafasi) ? getIntSys("maxexpensephase") : getIntSys("expenseregphase");
                fasecurr = fasecurr - 1;
            }
            if (nvaloridiversi("idfin", Selected) > 1){
                if (fasecurr >= minfasebil) fasecurr = minfasebil - 1;
            }
            if (nvaloridiversi("idreg", Selected) > 1){
                if (fasecurr >= minfasecred) fasecurr = minfasecred - 1;
            }
            if (nvaloridiversi("idupb", Selected) > 1){
                if (fasecurr >= minfasebil) fasecurr = minfasebil - 1;
            }
            return fasecurr;
        }

        private void btnCollegaE_Click(object sender, EventArgs e){
            DataRow[] RigheSelezionate = GetGridSelectedRows(gridEntrata);
            if (RigheSelezionate == null) return;
            if (RigheSelezionate.Length == 0) return;
            string rowfilter;

            int maxfase = GetMaxFaseForSelection(RigheSelezionate, "income");
            if (maxfase < 1){
                show("Non è possibile collegare tutte le righe selezionate ad uno stesso movimento.\n" +
                    "Le informazioni di U.P.B., bilancio e versante sono troppo diverse tra loro.", "Errore");
                return;
            }
            int selectedfase = maxfase;
            if (maxfase > 1){
                DataTable Fasi2 = DS.incomephase.Copy();
                foreach (DataRow ToDel in Fasi2.Select(
                    QHC.CmpGt("nphase", maxfase))){
                    ToDel.Delete();
                }
                Fasi2.AcceptChanges();
                FrmAskFase F = new FrmAskFase(Fasi2);
                if (F.ShowDialog() != DialogResult.OK) return;
                selectedfase = Convert.ToInt32(F.cmbFasi.SelectedValue);
            }
            rowfilter = GetFilterForSelection(RigheSelezionate, "income", selectedfase);
            rowfilter = QHS.AppAnd(rowfilter, QHS.CmpEq("nphase", selectedfase));
            decimal tot = 0;
            foreach (DataRow R in RigheSelezionate){
                tot += CfgFn.GetNoNullDecimal(R["amount"]);
            }
            rowfilter = QHS.AppAnd(rowfilter, QHS.CmpGe("available", tot));
            MetaData E = Disp.Get("income");
            E.DS = DS.Clone();
            E.FilterLocked = true;
            DataRow Choosen = E.SelectOne("default", rowfilter, "income", null);
            if (Choosen == null) return;
            RighePadriEntrata[Choosen["idinc"]] = Choosen;
            foreach (DataRow R in RigheSelezionate){
                R["parentidinc"] = Choosen["idinc"];
                int I = Convert.ToInt32(R["idinc"]);
                TAutomatismi.Rows[I]["parentidmov"] = Choosen["idinc"];
            }
            RicalcolaCampiCalcolati();
        }

        private void btnCollegaS_Click(object sender, EventArgs e){
            DataRow[] RigheSelezionate = GetGridSelectedRows(gridSpesa);
            if (RigheSelezionate == null) return;
            if (RigheSelezionate.Length == 0) return;
            string rowfilter;
            int maxfase = GetMaxFaseForSelection(RigheSelezionate, "expense");
            if (maxfase < 1){
                show("Non è possibile collegare tutte le righe selezionate ad uno stesso movimento.\n" +
                    "Le informazioni di U.P.B., bilancio e versante sono troppo diverse tra loro.", "Errore");
                return;
            }
            int selectedfase = maxfase;
            if (maxfase > 1){
                DataTable Fasi2 = DS.expensephase.Copy();
                foreach (DataRow ToDel in Fasi2.Select(
                    QHC.CmpGt("nphase", maxfase))){
                    ToDel.Delete();
                }
                Fasi2.AcceptChanges();
                FrmAskFase F = new FrmAskFase(Fasi2);
                if (F.ShowDialog() != DialogResult.OK) return;
                selectedfase = Convert.ToInt32(F.cmbFasi.SelectedValue);
            }
            rowfilter = GetFilterForSelection(RigheSelezionate, "expense", selectedfase);
            rowfilter = QHS.AppAnd(rowfilter, QHS.CmpEq("nphase", selectedfase));
            decimal tot = 0;
            foreach (DataRow R in RigheSelezionate){
                tot += CfgFn.GetNoNullDecimal(R["amount"]);
            }
            rowfilter = QHS.AppAnd(rowfilter, QHS.CmpGe("available", tot));
            MetaData S = Disp.Get("expense");
            S.DS = DS.Clone();
            S.FilterLocked = true;
            DataRow Choosen = S.SelectOne("default", rowfilter, "expense", null);
            if (Choosen == null) return;
            RighePadriSpesa[Choosen["idexp"]] = Choosen;
            foreach (DataRow R in RigheSelezionate){
                R["parentidexp"] = Choosen["idexp"];
                int I = Convert.ToInt32(R["idexp"]);
                TAutomatismi.Rows[I]["parentidmov"] = Choosen["idexp"];
            }
            RicalcolaCampiCalcolati();
        }

        private void btnScollegaE_Click(object sender, EventArgs e){
            DataRow[] RigheSelezionate = GetGridSelectedRows(gridEntrata);
            if (RigheSelezionate == null) return;
            if (RigheSelezionate.Length == 0) return;
            foreach (DataRow R in RigheSelezionate){
                R["parentidinc"] = DBNull.Value;
                int I = Convert.ToInt32(R["idinc"]);
                TAutomatismi.Rows[I]["parentidmov"] = DBNull.Value;
            }
            RicalcolaCampiCalcolati();
        }

        private void btnScollegaS_Click(object sender, EventArgs e){
            DataRow[] RigheSelezionate = GetGridSelectedRows(gridSpesa);
            if (RigheSelezionate == null) return;
            if (RigheSelezionate.Length == 0) return;
            foreach (DataRow R in RigheSelezionate){
                R["parentidexp"] = DBNull.Value;
                int I = Convert.ToInt32(R["idexp"]);
                TAutomatismi.Rows[I]["parentidmov"] = DBNull.Value;
            }
            RicalcolaCampiCalcolati();
        }

    }
}
