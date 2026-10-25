/*
Easy
Copyright (C) 2026 Università degli Studi di Catania (www.unict.it)
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
using metaeasylibrary;
using funzioni_configurazione;
using System.Collections;
using System.IO;

namespace no_table_wizardmerge {
    public partial class FrmNoTable_wizardmerge : MetaDataForm {
        MetaData Meta;
        DataAccess Conn;
        CQueryHelper QHC;
        QueryHelper QHS;


        public FrmNoTable_wizardmerge() {
            InitializeComponent();
            tabController.HideTabsMode =
    Crownwood.Magic.Controls.TabControl.HideTabsModes.HideAlways;

        }

        #region Gestione Tabs

        string CustomTitle;
        void DisplayTabs(int newTab) {
            tabController.SelectedIndex = newTab;
            btnBack.Visible = (newTab > 0);
            if (newTab == tabController.TabPages.Count - 1)
                btnNext.Text = "Ricomincia.";
            else
                btnNext.Text = "Next >";
            Text = CustomTitle + " (Pagina " + (newTab + 1) + " di " + tabController.TabPages.Count + ")";
            if (newTab > 0) ShowPage(newTab);
        }
        void StandardChangeTab(int step) {
            int oldTab = tabController.SelectedIndex;
            int newTab = oldTab + step;
            if ((newTab < 0) || (newTab > tabController.TabPages.Count)) return;
            if (!CustomChangeTab(oldTab, newTab)) return;
            if (newTab == tabController.TabPages.Count) {
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
            DisplayTabs(newTab);
        }
        private void btnBack_Click(object sender, System.EventArgs e) {
            StandardChangeTab(-1);
        }
        private void btnNext_Click(object sender, System.EventArgs e) {
            StandardChangeTab(+1);
        }

        bool CustomChangeTab(int oldTab, int newTab) {
            if (oldTab == 0) {
                return CheckStandard();
            }
            if ((oldTab == 1) && (newTab == 0)) return true;
            if (oldTab == 1 && newTab == 2) {
                string errore;
                string errore2;
                string dettaglio;
                string dettaglio2;
                Source = Easy_DataAccess.getEasyDataAccess("Source DB", txtSourceServer.Text.Trim(),
                                    txtSourceDataBase.Text.Trim(), txtSourceUser.Text.Trim(), txtSourcePwd.Text.Trim(),
                                    txtSourceDip.Text.Trim(),
                                    Convert.ToInt32(Conn.GetSys("esercizio")),
                                    Convert.ToDateTime(Conn.GetSys("datacontabile")), out errore,out dettaglio);
                DestDip = Easy_DataAccess.getEasyDataAccess("Source DB", 
                                    Conn.GetSys("server").ToString(),
                                    Conn.GetSys("database").ToString(),
                                   txtDestUser.Text.Trim(), 
                                    txtDestPwd.Text.Trim(),
                                  txtDipDestinazione.Text.Trim(),
                                  Convert.ToInt32(Conn.GetSys("esercizio")),
                                  Convert.ToDateTime(Conn.GetSys("datacontabile")), out errore2, out dettaglio2);
                if (Source == null  || errore != null) {
                    QueryCreator.ShowError(this, errore, dettaglio);
                    if (DestDip!=null) DestDip.Destroy();
                    return false;
                }
                if (DestDip == null || errore2 != null) {
                    QueryCreator.ShowError(this, errore2, dettaglio2);
                    Source.Destroy();
                    return false;
                }


                if (!Source.Open()) {
                    Source.Destroy();
                    Source = null;
                    show(this, "Non è stato possibile collegarsi al database " + txtSourceDataBase.Text);
                    return false;
                }

            }
            currindice_DBO = 1;
            return true;
        }
   
        #endregion
        private DataRow[] GetGridSelectedRows(DataGrid G) {
            if (G.DataMember == null) return null;
            if (G.DataSource == null) return null;
            string TableName = G.DataMember.ToString();
            DataSet MyDS = (DataSet)G.DataSource;
            DataTable MyTable = MyDS.Tables[TableName];
            int numrighetemp = MyTable.Rows.Count;
            int numrighe = 0;
            int i;
            for (i = 0; i < numrighetemp; i++) {
                if (G.IsSelected(i)) {
                    numrighe++;
                }
            }

            DataRow[] Res = new DataRow[numrighe];
            int count = 0;
            for (i = 0; i < numrighetemp; i++) {
                if (G.IsSelected(i)) {
                    Res[count++] = GetGridRow(G, i);
                }
            }
            return Res;
        }
        DataRow GetGridRow(DataGrid G, int index) {
            string TableName = G.DataMember.ToString();
            DataSet MyDS = (DataSet)G.DataSource;
            DataTable MyTable = MyDS.Tables[TableName];
            string filter = QHC.CmpEq("idreg", G[index, 0]);
            DataRow[] selectresult = MyTable.Select(filter);
            return selectresult[0];
        }
        void GridSelectRow(DataGrid G, int I) {
            DataRow R = GetGridRow(G, I);
            if (R == null) return;
            MetaData Registry = Meta.Dispatcher.Get("registry");

            Registry.ContextFilter = QHS.CmpEq("idreg", R["idreg"]);
            Registry.Edit(this.ParentForm, "anagrafica", false);
            string listtype = Registry.DefaultListType;
            DataRow RR = Registry.SelectOne(listtype, QHS.CmpEq("idreg", R["idreg"]), null, null);
            if (RR != null) Registry.SelectRow(RR, listtype);
        }

        void EditRegistry(object sender, EventArgs e) {
            int passo = tabController.SelectedIndex;
            DataGrid G = dgridB[passo];
            if (G == null) return;
            int i = G.CurrentRowIndex;
            if (i < 0) return;

            GridSelectRow(G, i);

        }

        DateTime LastGridClick;
        private void GRID_MouseDown(object sender, MouseEventArgs e) {
            if (sender == null) return;
            if (!typeof(DataGrid).IsAssignableFrom(sender.GetType())) return;
            DataGrid G = (DataGrid)sender;
            LastGridClick = DateTime.Now;

        }
        void SimpleSelect(DataGrid G, int R) {
            try {
                G.Select(R);
            }
            catch {
            }
        }
        private void GRID_MouseUp(object sender, MouseEventArgs e) {
            if (sender == null) return;
            if (!typeof(DataGrid).IsAssignableFrom(sender.GetType())) return;
            DataGrid G = (DataGrid)sender;
            DataSet D = G.DataSource as DataSet;
            if (D == null) return;
            DataTable T = D.Tables[G.DataMember];
            if (T == null) return;

            System.Windows.Forms.DataGrid.HitTestInfo myHitTest = G.HitTest(e.X, e.Y);
            if (myHitTest.Type == System.Windows.Forms.DataGrid.HitTestType.Cell) {
                int Row = myHitTest.Row;
                if (!G.IsSelected(Row)) {
                    SimpleSelect(G, Row);
                }
                else {
                    G.UnSelect(Row);
                }
            }
            else {
                int Row = myHitTest.Row;
            }


        }

        void ResetWizard() {
        }
        public void MetaData_AfterClear() {
            DisplayTabs(0);
        }

        public void MetaData_AfterActivation() {
            CustomTitle = "Wizard Consolidamento Database";
            DisplayTabs(0);
        }

        bool CheckStandard() {
            return true;
        }




        string []dbototranslate= 
            new string[]{"csa_agency","csa_agencypaymethod","csa_contractkind",
                        "csa_contractkindrules","csa_contractregistry","csapaymethodlookup",
                        "csapositionlookup",
                        "inventorytreemultifieldkind", 
                        "parasubcontractlist",
                        "accmotivedetail","accmotiveepoperation",
                        "accountlookup","patrimonylookup","placcountlookup",
                        "dbuseradvice"};
                    
        DataGrid[] dgridA;
        DataGrid[] dgridB;
        DataGrid[] dgridC;
        string[] tabledata =
            new string[]{"account;ayear,codeacc",
                        "accountkind;description", 
                        "accountlevel;ayear,nlevel;description",
                        "accmotive;codemotive;title",
                        "address;codeaddress;description;description",
                        "assetusagekind;codeassetusagekind;description;description",
                        "bank;idbank",
                        "cab;idbank,idcab",
                        "category;description;*",
                        "centralizedcategory;description;*",
                        "currency;codecurrency;description;description",
                        "ddt_in_motive;description;*",
                        "ddt_out_motive;description;*",
                        "inventorysortinglevel;nlevel;description",
                        "inventorytree;codeinv",
                        "inventorytreemultifieldkind;codeinv;description",
                        "itinerationrefundkind;codeitinerationrefundkind;description;description",
                        "ivapayperiodicity;description;*,periodicday,periodicity,periodicmonth",
                        "listclass;codelistclass;title",  
                        "list;description;*",
                        "maintenancekind;codemaintenancekind;description;description",
                        "maritalstatus;description;*",
                        "multifieldkind;fieldcode;fieldname",
                        "package;description;*",
                        "patrimony;ayear,codepatrimony",
                        "patrimonylevel;ayear,nlevel;description",
                        "paymethod;description;methodbankcode,allowdeputy;description",
                        "placcount;ayear,codeplaccount",
                        "placcountlevel;ayear,nlevel;description",
                        "position;codeposition;description",
                        "service;codeser;description,certificatekind,rec770kind,allowedit;description",
                        "stamphandling;description",
                        "storeload_motive;description;*",
                        "storeunload_motive;description;*", 
                        "unit;description;*", 
                        "tax;taxref;description,taxkind,fiscaltaxcode,appliancebasis;description",
                        "title;description"};
       

        public void MetaData_AfterLink() {
            Meta = MetaData.GetMetaData(this);
            Meta.CanSave = false;
            Meta.SearchEnabled = false;
            Meta.CanInsert = false;
            Meta.CanInsertCopy = false;
            Meta.CanCancel = false;

            Conn = Meta.Conn;
            QHC = new CQueryHelper();
            QHS = Conn.GetQueryHelper();

            txtIntro.Text =
                "Questa procedura vi guiderà ad importare il contenuto di un database di Easy (secondario) in questo a cui siete collegati (principale).\r\n" +
                "In particolare, ove ci siano delle incoerenze su dati presenti in entrambi i database sarà data " +
                "la scelta di procedere mantendendo i dati del database principale oppure fermarsi per correggere " +
                "i dati del database secondario e poi procedere.";

            txt2.Text = "Premere Inizia per procedere con la verifica delle tabelle.";
            txt3.Text= "E' importante che le tabelle del bilancio siano uguali dal livello selezionato in su "+
              "per una corretta gestione del consolidato. Il livello da selezionare è il capitolo o "+
              "la categoria in base al proprio regolamento";
            dgridA = new DataGrid[tabController.TabPages.Count];
            dgridB = new DataGrid[tabController.TabPages.Count];
            dgridC = new DataGrid[tabController.TabPages.Count];
            dgridA[1] = dgridA1;
            dgridB[1] = dgridB1;
            dgridC[1] = dgridC1;
            dgridA[2] = dgridA2;
            dgridB[2] = dgridB2;
        }

        DataAccess Source;
        DataAccess DestDip;
        public int CheckTable(string tablename, string[] mergekey, string[] checkfield,string []unique, int NStep) {

            DataTable TS = Source.RUN_SELECT(tablename, "*", null, null, null, false);
            DataTable TC = Source.CreateTableByName(tablename,"*");
            DataTable TD = Conn.RUN_SELECT(tablename, "*", null, null, null, false);
            TS.CaseSensitive = false;
            TD.CaseSensitive = false;
            TC.CaseSensitive = false;
            
            MetaData M = MetaData.GetMetaData(this, tablename);
            DataSet DDA = new DataSet("A");
            DDA.CaseSensitive = false;
            DDA.Tables.Add(TS);
            DataSet DDB = new DataSet("B");
            DDB.CaseSensitive = false;
            DDB.Tables.Add(TD);
            M.DescribeColumns(TS, "checkimport");
            M.DescribeColumns(TD, "checkimport");

            if (checkfield.Length == 0) return 0;


            DataTable TTS = TS.Copy();
            TTS.CaseSensitive = false;
            if (unique.Length > 0) {
                bool grave = false;
                foreach (DataRow RS in TTS.Select()) {
                    string uqfilter = QHC.MCmp(RS, unique);
                    if (TD.Select(uqfilter).Length == 0) {
                        string qus = QHS.MCmp(RS, unique);
                        Source.RUN_SELECT_INTO_TABLE(TC, null, qus, null, false);
                        RS.Delete();
                        continue;
                    }
                    DataRow RD=TD.Select(uqfilter)[0];
                    bool ok=true;
                    foreach (string field in mergekey) {
                        if (RS[field].ToString().ToUpper() != RD[field].ToString().ToUpper()) ok = false;
                    }
                    if (ok) {
                        RS.Delete();
                        continue;
                    }
                    string mkfilter = QHC.MCmp(RS, mergekey);
                    if (TD.Select(mkfilter).Length == 0 || tablename == "inventorytree" || tablename == "account" || 
                                    tablename == "patrimony" || tablename == "placcount") {
                        grave = true;
                    }
                }
                TTS.AcceptChanges();
                if (TTS.Rows.Count > 0) {
                    DataSet DD = new DataSet();
                    DD.CaseSensitive = false;
                    DD.Tables.Add(TTS);
                    TTS.CaseSensitive = false;
                    string msg= "La tabella " + tablename + " in corrispondenza di valori diversi della chiave " +
                                        "alternativa presenta alcuni valori del db principale che sono " +
                                        "vincolati da unicità.\r\n";
                    if (grave) msg += " In particolare, ci sono valori vincolati uguali, ma non corrispondenti " +
                        "alle chiavi alternative ad essi associate.\r\n ";
                    msg += "Una soluzione potrebbe essere adeguare la chiave alternativa del db secondario " +
                        "ponendola uguale a quella del db principale, oppure modificarne la descrizione.";
                    txt2.Text = msg;

                    dgridA[NStep].DataSource = null;
                    dgridA[NStep].TableStyles.Clear();
                    HelpForm.SetDataGrid(dgridA[NStep], TTS);

                    DataTable TTD = TD.Copy();
                    TTD.CaseSensitive = false;
                    foreach (DataRow RRD in TTD.Select()) {
                        string filter1 = QHC.MCmp(RRD, unique);
                        string filter2 = QHC.MCmp(RRD, mergekey);
                        if (TTS.Select(filter1).Length == 0 && TTS.Select(filter2).Length==0) RRD.Delete();
                    }
                    TTD.AcceptChanges();
                    DataSet DD2 = new DataSet();
                    DD2.Tables.Add(TTD);
                    dgridB[NStep].DataSource = null;
                    dgridB[NStep].TableStyles.Clear();
                    HelpForm.SetDataGrid(dgridB[NStep], TTD);

                    if (grave) return 5;
                    return 4;
                }
            }

            if ((checkfield.Length > 0) && (checkfield[0] == "*")) {
               

                foreach (DataRow RS in TS.Select()) {
                    string mkfilter = QHC.MCmp(RS, mergekey);
                    if (TS.Select(mkfilter).Length > 1) {
                        dgridA[NStep].DataSource = null;
                        dgridA[NStep].TableStyles.Clear();
                        HelpForm.SetDataGrid(dgridA[NStep], TS);
                        dgridB[NStep].DataSource = null;
                        dgridB[NStep].TableStyles.Clear();
                        txt2.Text = "La chiave alternativa della tabella " + tablename +
                            " nel db da importare presenta  valori duplicati";
                        return 2;
                    }
                }
                foreach (DataRow RD in TD.Select()) {
                    string mkfilter = QHC.MCmp(RD, mergekey);
                    if (TD.Select(mkfilter).Length > 1) {
                        dgridA[NStep].DataSource = null;
                        dgridB[NStep].DataSource = null;
                        dgridA[NStep].TableStyles.Clear();
                        dgridB[NStep].TableStyles.Clear();
                        HelpForm.SetDataGrid(dgridB[NStep], TD);
                        txt2.Text = "La chiave alternativa della tabella " + tablename +
                                " nel db da importare presenta  valori duplicati";
                        return 3;

                    }
                }
                

            }
            if ((checkfield.Length == 1) && (checkfield[0] == "*")) return 0;

            foreach (DataRow RS in TS.Select()) {
                string filter = QHC.MCmp(RS, mergekey);
                DataRow[] found = TD.Select(filter);
                string []lookupfields=null;
                if (tablename == "inventorytree") {
                    lookupfields = new string[] { "lookupcode" };
                }
                if (lookupfields != null) {
                    bool do_lookup=true;
                    foreach (string field in lookupfields) {
                        if (RS[field] == DBNull.Value) do_lookup = false;
                    }
                    if (do_lookup){
                        filter= QHC.MCmp(RS,lookupfields);
                        found = TD.Select(filter);
                    }
                }

                if (tablename == "inventorytree" || tablename == "account" || tablename == "patrimony" || tablename == "placcount") {
                    if (found.Length == 0 && TD.Rows.Count==0) {
                        RS.Delete();
                        string sqlfilt = QHS.MCmp(RS, mergekey);
                        Source.RUN_SELECT_INTO_TABLE(TC, null, sqlfilt, null, false);
                        continue;
                    }

                    if (found.Length == 0 && TD.Rows.Count >0) {
                        RS.Delete();
                        string sqlfilt = QHS.MCmp(RS, mergekey);
                        Source.RUN_SELECT_INTO_TABLE(TC, null, sqlfilt, null, false);
                        txt2.Text = "La tabella " + tablename + " contiene righe che non hanno corrispondenza nel db principale";
                        return 5;
                    }


                }
                else {
                    if (found.Length == 0) {
                        RS.Delete();
                        string sqlfilt = QHS.MCmp(RS, mergekey);
                        Source.RUN_SELECT_INTO_TABLE(TC, null, sqlfilt, null, false);
                        continue;
                    }

                }

               
                DataRow RD = found[0];
                bool ok = true;
                foreach (string fname in checkfield) {
                    if (fname == "*") continue;
                    if (RS[fname].ToString().ToUpper() != RD[fname].ToString().ToUpper()) ok = false;
                }
                if (ok) {
                    RS.Delete();
                    RD.Delete();
                    continue;
                }
            }

            foreach (DataRow RD in TD.Select()) {
                string filter = QHC.MCmp(RD, mergekey);
                if (TS.Select(filter).Length== 0) RD.Delete();
            }

            TS.AcceptChanges();
            TD.AcceptChanges();
            TC.AcceptChanges();
            if (TS.Rows.Count == 0 && TC.Rows.Count==0) return 0;

            dgridA[NStep].DataSource = null;
            dgridA[NStep].TableStyles.Clear();
            HelpForm.SetDataGrid(dgridA[NStep],TS);

            dgridC[NStep].DataSource = null;
            dgridC[NStep].TableStyles.Clear();
            HelpForm.SetDataGrid(dgridC[NStep], TC);

            dgridB[NStep].DataSource = null;
            dgridB[NStep].TableStyles.Clear();
            HelpForm.SetDataGrid(dgridB[NStep], TD);

            if (TS.Rows.Count == 0) return 0;

            txt2.Text = "La tabella " + tablename + " in corrispondenza di valori uguali della chiave " +
                "alternativa presenta informazioni importanti diverse.";
            if (tablename == "inventorytree" || tablename == "account" || tablename == "patrimony" || tablename == "placcount") {
                txt2.Text += "\r\nTrattandosi di una gerarchia è necessario correggere manualmente la situazione.";
                return 2;
            }
            return 1;

        }

        bool VerificaFinEffettuata = false;

        void ShowPage(int NPasso) {
            btnBack.Enabled = false;
            btnNext.Enabled = false;
            btnRefresh.Enabled = (NPasso==2);
            if (NPasso == 2) {
                ShowCheckDBO();
                EnableDisableButtons_CheckDBO();
                return;
            }
            if (NPasso == 3) {
                VerificaFinEffettuata = false;
                ShowCheckFin();
                EnableDisableButtons_CheckFin();
                return;
            }
            if (NPasso == 4) {
                CopyDBO_Done = false;
                EnableDisableButtons_CopyDBO();
                return;
            }
            if (NPasso == 5) {
                CopyNonDBO_Done = false;
                EnableDisableButtons_CopyNonDBO();
                return;
            }
            btnRefresh.Visible = (NPasso > 0);
            btnBack.Enabled = true;
            btnNext.Enabled = true;
            btnRefresh.Enabled = false;

        }

        int currindice_DBO = 0;
        int lasterr_DBO = 0;
        void EnableDisableButtons_CheckDBO() {
            btnBack.Enabled = true;
            if (currindice_DBO < tabledata.Length) {
                btnNext.Enabled = false;
            }
            else {
                btnNext.Enabled = true;
            }
            btnRefresh.Enabled = true;
            btnProcedi.Visible = (currindice_DBO < tabledata.Length && (lasterr_DBO <= 1 || lasterr_DBO == 4));
            btnAssumi.Visible = (currindice_DBO < tabledata.Length && lasterr_DBO <= 1);

        }
        void ShowCheckDBO() {
            labDBPrinc.Text = Conn.GetSys("database").ToString() + " su " + Conn.GetSys("server").ToString();
            labDBSec.Text = Source.GetSys("database").ToString() + " su " + Source.GetSys("server").ToString();

            btnProcedi.Visible = false;
            btnAssumi.Visible = false;
            EnableDisableButtons_CheckDBO();
            Cursor = Cursors.WaitCursor;
            Application.DoEvents();
            while (currindice_DBO < tabledata.Length) {
                btnProcedi.Visible = false;
                btnAssumi.Visible = false;
                string[] parametri = tabledata[currindice_DBO].Split(';');
                 string tablename = parametri[0];
                txt2.Text = "Esamino la tabella " + tablename;
                Application.DoEvents();

                string[] mkey = parametri[1].Split(',');
                string[] checkfield = new string[0];
                if (parametri.Length>=3) checkfield=   parametri[2].Split(',');
                string[] unique = new string[0];
                if (parametri.Length >= 4) unique = parametri[3].Split(',');

                lasterr_DBO = CheckTable(tablename, mkey, checkfield, unique, 1);
                if (lasterr_DBO > 1) {
                    EnableDisableButtons_CheckDBO();
                    Cursor = Cursors.Default;
                    return;
                }
                if (lasterr_DBO == 0) {
                    currindice_DBO++;
                    continue;
                }
                Cursor = Cursors.Default;
                EnableDisableButtons_CheckDBO();
                return;
            }
            txt2.Text = "Elaborazione delle tabelle terminata. E' possibile andare avanti.";
            btnProcedi.Visible = false;
            btnAssumi.Visible = false;
            EnableDisableButtons_CheckDBO();
            Cursor = Cursors.Default;
        }

        private void btnRefresh_Click(object sender, EventArgs e) {
            if (tabController.SelectedIndex == 1) {
                if (currindice_DBO < tabledata.Length) ShowCheckDBO();
                return;
            }
            ShowPage(tabController.SelectedIndex);
        }

        private void btnProcedi_Click(object sender, EventArgs e) {
            currindice_DBO++;
            dgridA[1].DataSource = null;
            dgridB[1].DataSource = null;
            dgridC[1].DataSource = null;
            ShowCheckDBO();
        }

        private void btnAssumi_Click(object sender, EventArgs e) {
            string[] parametri = tabledata[currindice_DBO].Split(';');
            string tablename = parametri[0];

            string[] mkey = parametri[1].Split(',');
            string[] checkfield = new string[0];
            if (parametri.Length >= 3) checkfield = parametri[2].Split(',');

            if (checkfield.Length == 0) return;
            if ((checkfield.Length == 1) && (checkfield[0] == "*")) return ;

            DataTable TS = Source.RUN_SELECT(tablename, "*", null, null, null, false);
            DataTable TD = Conn.RUN_SELECT(tablename, "*", null, null, null, false);

            MetaData M = MetaData.GetMetaData(this, tablename);
            DataSet DDA = new DataSet("A");
            DDA.Tables.Add(TS);
            DataSet DDB = new DataSet("B");
            DDB.Tables.Add(TD);


            foreach (DataRow RS in TS.Select()) {
                string filter = QHC.MCmp(RS, mkey);
                DataRow[] found = TD.Select(filter);
                if (found.Length == 0) {
                    continue;
                }
                DataRow RD = found[0];
                foreach (string fname in checkfield) {
                    if (fname == "*") continue;
                    if (RS[fname].ToString() != RD[fname].ToString())
                        RD[fname] = RS[fname];
                }
            }
            PostData P = M.Get_PostData();
            P.InitClass(DDB, Conn);
            if (P.DO_POST()) {
                btnAssumi.Visible = false;
                btnProcedi.Visible = false;
                currindice_DBO++;
                dgridA[1].DataSource = null;
                dgridB[1].DataSource = null;
                dgridC[1].DataSource = null;
                ShowCheckDBO();
            }
            return;

        }

        private void btnCancel_Click(object sender, EventArgs e) {
            this.Close();
        }

        int lasterr_FIN = 0;
        void EnableDisableButtons_CheckFin() {
            btnBack.Enabled = true;
            if (VerificaFinEffettuata == true && lasterr_FIN == 0) {
                btnNext.Enabled = true;
            }
            else {
                btnNext.Enabled = false;
            }
            btnRefresh.Enabled = false;
        }
        void ShowCheckFin() {
            labDBCorrente.Text = Conn.GetSys("database").ToString() + " su " + Conn.GetSys("server").ToString();
            labDBOrigine.Text = Source.GetSys("database").ToString() + " su " + Source.GetSys("server").ToString();

            string filtereserc= QHS.CmpEq("ayear",Conn.GetSys("esercizio"));
            DataTable FinLink = Conn.CreateTableByName("finlevel", "*");
            GetData.MarkToAddBlankRow(FinLink);
            GetData.Add_Blank_Row(FinLink);
            DataAccess.RUN_SELECT_INTO_TABLE(Conn, FinLink, "nlevel", filtereserc,null, false);
            cmbFinLevel.DataSource = FinLink;
            cmbFinLevel.DisplayMember = "description";
            cmbFinLevel.ValueMember = "nlevel";
            cmbFinLevel.SelectedIndex = -1;

        }

        private void btnCheckFin_Click(object sender, EventArgs e) {
            if (cmbFinLevel.SelectedIndex < 1) {
                VerificaFinEffettuata = true;
                lasterr_FIN = 0;
                EnableDisableButtons_CheckFin();
                return;
            }
            btnCheckFin.Visible = false;
            dgridA[2].DataSource = null;
            dgridB[2].DataSource = null;

            int nlev = CfgFn.GetNoNullInt32(cmbFinLevel.SelectedValue);
            string filter = QHS.AppAnd(QHS.CmpEq("ayear", Conn.GetSys("esercizio")),
                                    QHS.CmpLe("nlevel",nlev),QHS.CmpEq("idupb","0001"));
            DataTable CurrFin = Conn.RUN_SELECT("finview", "*", "finpart asc, codefin asc", filter, null, false);
            DataTable SourceFin = Source.RUN_SELECT("finview", "*", "finpart asc, codefin asc", filter, null, false);
            CurrFin.CaseSensitive = false;
            SourceFin.CaseSensitive = false;
            DataSet DA = new DataSet();
            DA.CaseSensitive = false;
            DataSet DB = new DataSet();
            DB.CaseSensitive = false;
            DB.Tables.Add(CurrFin);
            DA.Tables.Add(SourceFin);

            foreach (DataRow RC in CurrFin.Select()) {
                int flag= CfgFn.GetNoNullInt32(RC["flag"]);
                string cmpcode;
                if ((flag & 0x01) == 1)
                    cmpcode = QHC.AppAnd(QHC.CmpEq("codefin", RC["codefin"]), QHC.BitSet("flag", 0));
                else
                    cmpcode = QHC.AppAnd(QHC.CmpEq("codefin", RC["codefin"]), QHC.BitClear("flag", 0));
                DataRow[] found = SourceFin.Select(cmpcode);
                if (found.Length == 0) {
                    RC.Delete();
                    continue;
                }
                if (found[0]["title"].ToString().ToUpper() != RC["title"].ToString().ToUpper()) continue;
                RC.Delete();
                found[0].Delete();
            }
            CurrFin.AcceptChanges();
            SourceFin.AcceptChanges();

            foreach (DataRow RC in SourceFin.Select()) {
                int flag = CfgFn.GetNoNullInt32(RC["flag"]);
                string cmpcode;
                if ((flag & 0x01) == 1)
                    cmpcode = QHC.AppAnd(QHC.CmpEq("codefin", RC["codefin"]), QHC.BitSet("flag", 0));
                else
                    cmpcode = QHC.AppAnd(QHC.CmpEq("codefin", RC["codefin"]), QHC.BitClear("flag", 0));
                DataRow[] found = CurrFin.Select(cmpcode);
                if (found.Length == 0) continue;
                if (found[0]["title"].ToString().ToUpper() != RC["title"].ToString().ToUpper()) continue;
                RC.Delete();
                found[0].Delete();
            }
            CurrFin.AcceptChanges();
            SourceFin.AcceptChanges();
            if (CurrFin.Rows.Count == 0 && SourceFin.Rows.Count == 0) {
                lasterr_FIN = 0;
            }
            else {
                lasterr_FIN = 1;
            }
            VerificaFinEffettuata = true;

            MetaData M = MetaData.GetMetaData(this, "finview");
            M.DescribeColumns(CurrFin, "default");
            M.DescribeColumns(SourceFin, "default");
            dgridA[2].DataSource = null;
            dgridA[2].TableStyles.Clear();
            HelpForm.SetDataGrid(dgridA[2], SourceFin);
            dgridB[2].DataSource = null;
            dgridB[2].TableStyles.Clear();
            HelpForm.SetDataGrid(dgridB[2], CurrFin);
            btnCheckFin.Visible = true;
            EnableDisableButtons_CheckFin();
        }
        Hashtable GetTableFromField = null;


        int CreateHashTable(DataTable Source, DataTable Dest) {
            Hashtable lookup = new Hashtable();
            bool hasAyear = false;
            string kfield = "";
            string codefield="";
            string table = Dest.TableName;
            int notfound = 0;
            string lookupfield="";
            if (table=="account"){
                hasAyear=true;
                kfield="idacc";
                codefield="codeacc";
            }
            if (table=="patrimony"){
                hasAyear=true;
                kfield="idpatrimony";
                codefield="codepatrimony";
            }
            if (table=="placcount"){
                hasAyear=true;
                kfield="idplaccount";
                codefield="codeplaccount";
            }
            if (table=="inventorytree"){
                hasAyear=false;
                kfield="idinv";
                codefield="codeinv";
                lookupfield = "lookupcode";
            }

            foreach (DataRow RS in Source.Select()) {
                string filter;
                object code = RS[codefield];
                if (lookupfield != "" && RS[lookupfield] != DBNull.Value) code = RS[lookupfield];

                if (hasAyear)
                    filter = QHC.AppAnd(QHC.CmpEq("ayear", RS["ayear"]), QHC.CmpEq(codefield, code));
                else
                    filter = QHC.CmpEq(codefield, code);

                DataRow[] found = Dest.Select(filter);
                if (found.Length == 0) {
                    notfound++;
                    continue;
                }

                object newkey = found[0][kfield];
                lookup[RS[kfield]] = newkey;


            }


            lookups[table] = lookup;
            GetTableFromField[kfield] = lookup;

            if (notfound > 0) {
                show("Di " + notfound.ToString() + " righe della tabella " + table + " non è stata trovata una corrispondenza nel db consolidato","Errore");
            }

            return notfound;

        }

        public int CopyDBOTable(string tablename, string[] mergekey, string[] checkfield,  int NStep) {
             DataTable TS = Source.RUN_SELECT(tablename, "*", null, null, null, false);
            DataTable TD = Conn.RUN_SELECT(tablename, "*", null, null, null, false);

            if (TD.Rows.Count> 0 && TS.Rows.Count>0) {
                if (tablename == "account" || tablename == "placcount" || tablename == "patrimony") {
                    return CreateHashTable(TS, TD);
                }
            if (tablename == "inventorytree"){
                CreateHashTable(TS, TD);
                return 0;
            }
            }


            Hashtable lookup = new Hashtable();

            DataTable TNew = Conn.CreateTableByName(tablename, "*");
            TS.CaseSensitive = false;
            TD.CaseSensitive = false;
            int nfield=0;
            string kfield="";
            bool multikey = false;
            foreach (DataColumn CK in TD.Columns) {
                if (!QueryCreator.IsPrimaryKey(TD, CK.ColumnName)) continue;
                if (CK.ColumnName == "ayear") continue;
                kfield = CK.ColumnName;
                nfield++;
            }
            if (nfield > 1) {
                multikey = true;
            }

            if (!multikey) {                
                foreach (DataRow RD in TD.Rows) {
                    lookup[RD[kfield]] = RD[kfield];
                }
            }
            MetaData M = MetaData.GetMetaData(this, tablename);
            DataSet DDA = new DataSet("A");
            DDA.CaseSensitive = false;
            DDA.Tables.Add(TS);
            DataSet DDB = new DataSet("B");
            DDB.CaseSensitive = false;
            DDB.Tables.Add(TD);

            DataSet DNew = new DataSet();
            DNew.Tables.Add(TNew);
            M.SetDefaults(TNew);

           

            foreach (DataRow RS in TS.Select()) {
                string mkfilter = QHC.CmpMulti(RS, mergekey);
                if (TD.Select(mkfilter).Length > 0) {
                    DataRow DestRow = TD.Select(mkfilter)[0];
                    lookup[RS[kfield]] = DestRow[kfield];
                    continue;
                }
                if (TS.Columns.Contains("active")) {
                    RS["active"] = "N";
                }
                DataRow RNew = M.Get_New_Row(null, TNew);

                foreach (DataColumn C in TNew.Columns) {
                    if (RowChange.IsAutoIncrement(C)) continue;
                    RNew[C.ColumnName] = RS[C.ColumnName];
                }
            }
            PostData P = M.Get_PostData();
            P.InitClass(DNew, Conn);
            if (!P.DO_POST()) return 1;
            if (!multikey) {
                foreach (DataRow RN in TNew.Rows) {
                    string mkfilter = QHC.CmpMulti(RN, mergekey);
                    DataRow Old = TS.Select(mkfilter)[0];
                    lookup[Old[kfield]] = RN[kfield];
                }
                lookups[tablename] = lookup;
                GetTableFromField[kfield] = lookup;
            }
            return 0;
        }

        Hashtable lookups = null;
        bool CopyDBO_Done = false;
        int displace_idreg = 0;


        private void btnCopyDBO_Click(object sender, EventArgs e) {
           

            CopyDBO_Done = false;
            btnCopyDBO.Enabled = false;
            int N_Base = CfgFn.GetNoNullInt32(Conn.DO_READ_VALUE("registry", null, "max(idreg)"));
            int N_New = CfgFn.GetNoNullInt32(Source.DO_READ_VALUE("registry", null, "max(idreg)"));
            displace_idreg = N_Base;
            prgBarDBO.Maximum = tabledata.Length;
            prgBarRegistry.Maximum = N_New;
            prgBarRegistry.Value = 0;
            prgBarDBO.Value = 0;

            lookups = new Hashtable();
            GetTableFromField = new Hashtable();
            Cursor = Cursors.WaitCursor;
            Application.DoEvents();
            int currindice_CopyDBO = 0;
            lasterr_DBO = 0;
            Hashtable lookup= new Hashtable();
            while (currindice_CopyDBO < tabledata.Length) {
                string[] parametri = tabledata[currindice_CopyDBO].Split(';');
                string tablename = parametri[0];
                prgBarDBO.Increment(1);
                Application.DoEvents();


                string[] mkey = parametri[1].Split(',');
                string[] checkfield = new string[0];
                if (parametri.Length >= 3) checkfield = parametri[2].Split(',');
                string[] unique = new string[0];
                if (parametri.Length >= 4) unique = parametri[3].Split(',');

                int res = 0;
                try {
                    res = CopyDBOTable(tablename, mkey, checkfield, 1);
                }
                catch (Exception E) {
                    QueryCreator.ShowException(E);
                    res = 1;
                }
                if (res != 0) {
                    Cursor = Cursors.Default;
                    show("Errore nella copia della tabella " + tablename);
                    return;
                }
                if (lasterr_DBO == 0) {
                    currindice_CopyDBO++;
                    continue;
                }
                Cursor = Cursors.Default;
                EnableDisableButtons_CheckDBO();
                btnCopyDBO.Enabled = true;
                return;
            }
            
            for (int idreg = 1; idreg <= N_New; idreg++) {
                if (!CopyRegistry(idreg,  Source, Conn)) {
                    show("Errore nella copia dell'anagrafica n." + idreg);
                    Cursor = Cursors.Default;
                    return;
                }
                prgBarRegistry.Increment(1);

                Application.DoEvents();
            }
            


            txt2.Text = "Importazione delle tabelle comuni terminata. E' possibile andare avanti.";
            CopyDBO_Done = true;
            EnableDisableButtons_CopyDBO();
            Cursor = Cursors.Default;




        }
        void EnableDisableButtons_CopyDBO() {
            btnBack.Enabled = !CopyDBO_Done;
            btnNext.Enabled = CopyDBO_Done;
            btnRefresh.Enabled = false;
        }

        bool CopyRegistry(int idreg_source, DataAccess Source, DataAccess Dest) {
            string filter= QHS.CmpEq("idreg",idreg_source);
            DataSet DD = new DataSet();
            foreach (string tabname in new string[] {"registry","registryaddress","registrycf",
                        "registrylegalstatus","registrypaymethod","registrypiva","registryreference",
                        "registrytaxablestatus","registrydurc" }) {
                DataTable ToCopy = Source.RUN_SELECT(tabname, "*", null, filter, null, false);
                if (ToCopy.Rows.Count == 0) {
                    if (tabname == "registry") return true;
                    continue;
                }


                DataTable NewTable = Dest.CreateTableByName(tabname, "*");
                foreach (DataRow R in ToCopy.Rows) {
                    DataRow NewRow = NewTable.NewRow();
                    foreach (DataColumn C in NewTable.Columns) {
                            NewRow[C.ColumnName] = CopyColumn(tabname, C.ColumnName, R[C.ColumnName]);
                    }
                    if (tabname == "registry") {
                        NewRow["cu"] = txtDipDestinazione.Text.Trim();
                    }
                    NewTable.Rows.Add(NewRow);
                }
                DD.Tables.Add(NewTable);

            }
            PostData Post = new PostData();
            if (Post.InitClass(DD, Dest)!=null) return false;
            return Post.DO_POST();

        }
        object CopyColumn(string tablename, string field, object valore) {
            if ((valore == DBNull.Value) || (valore.ToString().Trim() == "")) return valore;
            if (field == "nlevel") return valore;
            
            if (tablename == "registry" && field == "idregistrykind") return DBNull.Value;
            
            if (field == "idreg"|| field=="iddeputy" || field=="idsorreg" ||
                 field== "registrymanager" || field== "idregauto" || field =="toredirect" ||
                 field== "paymentagency" || field=="refundagency"
                ) return displace_idreg + CfgFn.GetNoNullInt32(valore);
             
            if ((tablename == "taxregionsetup") && (field == "regionalagency")) {
                  return displace_idreg + CfgFn.GetNoNullInt32(valore);
              }
              
            if ((tablename == "wageadditionyear") && (field == "idposition")) return valore; 

            string newField = field;
            if (tablename == "registryaddress" && field == "idaddresskind") newField = "idaddress";

            if (field == "idaccdebit" || field == "idacccredit" || field.StartsWith("idacc_")) 
                        newField = "idacc";

            if (field.StartsWith("idaccmotive")) newField = "idaccmotive";
 
            if (field == "idinv_allow" || field=="idinv_deny") newField = "idinv";

            object O = GetTableFromField[newField];
            if (O == null) return valore;
            Hashtable lookup = (Hashtable)O;
            if (lookup[valore] == null) {
                show("Non è stata trovata corrispondenza per il valore " + 
                valore.ToString() + " del campo " + field + " della tabella " + tablename +
                    " nel campo "+newField+" a cui si riferisce");
                return valore;
            }
            return lookup[valore];
        }
        bool CopyNonDBO_Done = false;

        void EnableDisableButtons_CopyNonDBO() {
            btnBack.Enabled = false;
            btnNext.Enabled = CopyNonDBO_Done;
            btnRefresh.Enabled = false;
        }
        

        private void btnCopyNonDBO_Click(object sender, EventArgs e) {
            CopyNonDBO_Done = false;
            btnCopyNonDBO.Enabled = false;
            Cursor = Cursors.WaitCursor;
           
            DestDip.CallSP("enable_disable_triggers",
                                       new object[2]{txtDipDestinazione.Text.Trim(),
			                          'D'},
                                       false,
                                       500);

            DataTable TName = Conn.SQLRunner("select name from sysobjects where  xtype='U' and uid=user_id() order by name", false);

            for (int i = 0; i < tabledata.Length;i++ ) {
                string[] a = tabledata[i].Split(';');
                string filt = QHC.CmpEq("name", a[0]);
                if (TName.Select(filt).Length == 0) continue;
                TName.Select(filt)[0].Delete();
            }

            TName.AcceptChanges();

            pbarAllNonDBO.Maximum = TName.Rows.Count + dbototranslate.Length; ;
            pbarAllNonDBO.Value = 0;

            Application.DoEvents();

            Hashtable lookup = new Hashtable();
            foreach(DataRow RT in TName.Rows) {
                string tablename = RT["name"].ToString().ToLower();
                pbarAllNonDBO.Increment(1);
                if (tablename == "inventorysortingamortizationyear")    continue;
                Application.DoEvents();
                bool res = CopyAndTranslateTable( tablename, true,false);
                if (!res) {
                    Cursor = Cursors.Default;
                    DestDip.CallSP("enable_disable_triggers",
                                      new object[2]{txtDipDestinazione.Text.Trim(),
			                          'E'},
                                      false,
                                      500);
                    EnableDisableButtons_CopyNonDBO();
                    return;
                }
            }

            foreach (string tname in dbototranslate) {
                string tablename = tname;
                pbarAllNonDBO.Increment(1);
                Application.DoEvents();
                bool res = CopyAndTranslateTable(tablename, false,true);
                if (!res) {
                    Cursor = Cursors.Default;
                    DestDip.CallSP("enable_disable_triggers",
                                      new object[2]{txtDipDestinazione.Text.Trim(),
			                          'E'},
                                      false,
                                      500);
                    EnableDisableButtons_CopyNonDBO();
                    return;
                }
            }

            DestDip.CallSP("enable_disable_triggers",
                                      new object[2]{txtDipDestinazione.Text.Trim(),
			                          'E'},
                                      false,
                                      500);

            DestDip.SQLRunner("update dbdepartment set description=(select top 1 paramvalue from " +
                " generalreportparameter where idparam='DenominazioneDipartimento' order by start desc) where " +
                " iddbdepartment=" + QHS.quote(txtDipDestinazione.Text.Trim()), false);
            CopyNonDBO_Done = true;
            EnableDisableButtons_CopyNonDBO();
            Cursor = Cursors.Default;            

        }

        bool CopyAndTranslateTable(string tablename,bool clear,bool DBO) {
            string dest_owner = txtDipDestinazione.Text.Trim();
            if (DBO) dest_owner = "DBO";

            DataTable TT = Source.RUN_SELECT(tablename, "*", null, null, null, false);
            if (TT.Rows.Count == 0) return true;
            DataTable T = Source.CreateTableByName(tablename, "*");
            foreach (DataRow R in TT.Rows) {
                try {
                    DataRow RRT = T.NewRow();
                    foreach (DataColumn C in T.Columns)
                        RRT[C.ColumnName] = CopyColumn(T.TableName, C.ColumnName, R[C.ColumnName]);
                    T.Rows.Add(RRT);
                }
                catch (Exception E){
                    if (tablename == "inventorysortingamortizationyear" || tablename=="inventorytreesorting"
                                || tablename=="inventorytreemultifieldkind"
                            ) {
                        continue;
                    }
                    throw E;
                }
            }
            Hashtable taxHash = (Hashtable)GetTableFromField["taxcode"];

            if (tablename == "expense" || tablename == "income") {
                foreach (DataRow ToCrg in T.Rows) {
                    if (ToCrg["autocode"].ToString() == "") continue;
                    string idautokind = ToCrg["autokind"].ToString();
                    if (idautokind != "2" && idautokind != "4") continue;
                    object idtaxdest = taxHash[ToCrg["autocode"]];
                    if (idtaxdest == null) {
                        idtaxdest = DBNull.Value;
                        show("Non è stata trovata corrispondenza per il valore " +
                            idautokind.ToString() + " del campo autocode della tabella " + tablename);

                    }
                    ToCrg["autocode"] = idtaxdest;
                }
            }

            DataTable Exists = DestDip.SQLRunner("SELECT * FROM SYSOBJECTS WHERE NAME = "
                                + QueryCreator.quotedstrvalue(tablename, true) + " and xtype='U' and uid=user_id( "
                                + QueryCreator.quotedstrvalue(dest_owner, true) + ")", false);
            if (Exists.Rows.Count == 0) {
                show("Tabella " + tablename +
                                        " non trovata nel nuovo dipartimento. Questa tabella sarà saltata. ",
                                        "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            bool DO_ADD = false;
            if (tablename == "dbuseradvice" || tablename=="parasubcontractlist") {
                DataTable DestTable = DestDip.RUN_SELECT(tablename,"*",null,null,null,false);
                foreach (DataRow ToDel in DestTable.Rows) {
                    string fk = QHC.CmpKey(ToDel);
                    if (T.Select(fk).Length > 0) {
                        T.Select(fk)[0].Delete();
                    }
                }
                DO_ADD = true;
            }


            if (clear) {
                DestDip.SQLRunner("DELETE FROM " + tablename, false);
            }
            else {
                int Num = DestDip.RUN_SELECT_COUNT(tablename, null, false);
                if (Num > 0 && (DO_ADD==false)) {
                    show("La tabella " + tablename + " sarà saltata perché contiene già " +
                        Num.ToString() + " righe nel db di destinazione.", "Avviso");
                    return true;
                }
            }
            bool res = CopyTable(T, DestDip);
            if (!res) {
                show("Errore nella copia della tabella " + tablename);
                return false;
            }
 
            return true;
        }

        public  DataTable eseguiQuery(DataAccess sourceConn, string command, Form form) {
            string errMsg;
            DataTable t = sourceConn.SQLRunner(command, 0, out errMsg);
            if (errMsg != null) {
                QueryCreator.ShowError(null, errMsg, command);
                show(form, errMsg);
            }
            return t;
        }

        private  string GetSQLDataValues(DataRow row, DataTable Cols) {
            string s = "";
            int colcount = Cols.Rows.Count;
            for (int i = 0; i < colcount; i++) {
                string valore = "";
                string colname = Cols.Rows[i]["COLUMN_NAME"].ToString();
                if (row.Table.Columns.Contains(colname))
                    valore = QueryCreator.quotedstrvalue(row[colname], true);
                else
                    valore = "NULL";
                s += valore + ",";
            }
            s = s.Remove(s.Length - 1, 1);
            return s + ")\r\n";
        }

         bool CopyTable( DataTable TT, DataAccess Dest) {
            try {
                DataTable Cols = Dest.SQLRunner("sp_columns " + TT.TableName + ",'" + (Dest.GetSys("schema") ?? Dest.GetSys("userdb")).ToString() + "'");
                if (Cols.Rows.Count==0)
                    Cols = Dest.SQLRunner("sp_columns " + TT.TableName + ",'dbo'");


                if (TT.Rows.Count == 0) return true;
                string insert = "INSERT INTO " + TT.TableName + " VALUES(";
                int count = 0;
                string s = "";
                string err;

                labCurrTable.Text = "Stato di avanzamento della tabella " + TT.TableName;
                pBarCurrTab.Maximum = TT.Rows.Count;
                Application.DoEvents();

                foreach (DataRow row in TT.Rows) {
                    pBarCurrTab.Increment(1);
                    count++;
                    string values = GetSQLDataValues(row, Cols);
                    s += insert + values;
                    if (count == 10) {
                        Dest.SQLRunner(s, 0, out err);
                        Application.DoEvents();
                        if (err != null) {
                            QueryCreator.ShowError(this, "Errore", err);
                            StreamWriter fsw = new StreamWriter("temp.sql", false, Encoding.Default);
                            fsw.Write(s.ToString());
                            fsw.Close();
                            show(this, "Errore durante la copia della tabella " + TT.TableName + "\r\nLo script lanciato si trova nel file 'temp.sql'");

                            return false;
                        }
                        s = "";
                        count = 0;
                    }
                }
                if (s != "") {
                    Dest.SQLRunner(s, 0, out err);
                    if (err != null) {
                        QueryCreator.ShowError(this, "Errore", err);
                        StreamWriter fsw = new StreamWriter("temp.sql", false, Encoding.Default);
                        fsw.Write(s.ToString());
                        fsw.Close();
                        show(this, "Errore durante la copia di " + TT.TableName + "\r\nLo script lanciato si trova nel file 'temp.sql'");

                        return false;
                    }

                    s = "";
                }
                Application.DoEvents();
                return true;
            }
            catch {
                return false;
            }

        }

       
    }
}