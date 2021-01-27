
/*
Easy
Copyright (C) 2021 Università degli Studi di Catania (www.unict.it)
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
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using metadatalibrary;
using metaeasylibrary;
using System.Collections;
using System.Collections.Generic;



namespace mainform //MenuMaker//
{
    //Classe utilizzata per salvare elementi nella HastTable
    public class Element : MenuItem {
        string title;
        public string metadata;
        public string menucode;
        public object parameter;
        public bool modal=false;
        public string edittype;
        
        
        int NoNullInt(object o) {
            if (o == DBNull.Value) return 0;
            return Convert.ToInt32(o);
        }
        public Element(DataRow R) : base(R["title"].ToString()) {
            //ordernumber = NoNullInt(R["ordernumber"]);
            title = R["title"].ToString();
            metadata=R["metadata"].ToString().Trim().ToLower();
            edittype = R["edittype"].ToString().Trim().ToLower();
            menucode = R["menucode"].ToString().Trim().ToLower();
            parameter = R["parameter"];
            modal = R["modal"].ToString().Trim().ToLower()=="s";                        
        }
        public void setTitle(string title) {
            this.title = title;
            this.Text = title;
        }
        public Element(string title)
            : base(title) {
            this.title = title;
        }
    } //Fine classe Element 


    /// <summary>
    /// Classe per la costruzione del Menu di un Form
    /// </summary>
    public class menuMaker : IDisposable {
        private Easy_DataAccess DA;
        private Form form;
        QueryHelper QHS;
        private EntityDispatcher Dispatcher;
        private DataTable DT_Menu;
        private bool MenuIsCharged;
        private string TableName; //Nome della tabella del DB che contiene le voci di menu
        Dictionary<string, Element> MenuByMenuCode = new Dictionary<string, Element>();
        //public DataTable tConfig;
        //public DataTable tSorKind;
        //public DataTable tSAV;
        int NoNullInt(object o) {
            if (o == DBNull.Value) return 0;
            return Convert.ToInt32(o);
        }
        private EventHandler menuEvent;
        //Costruttore

   
        vistaMenu DS;

        public menuMaker(Easy_DataAccess mainDA, Form F, EntityDispatcher D) {

            //Si crea un clone del DataAccess, potrebbe diventare superfluo se non deve scrivere
            this.DA = mainDA.Duplicate() as Easy_DataAccess;
            foreach (string k in mainDA.EnumSysKeys()) {
                DA.SetSys(k, mainDA.GetSys(k));
            }
            foreach (string k in mainDA.EnumUsrKeys()) {
                DA.SetUsr(k, mainDA.GetUsr(k));
            }
            DA.RecalcUserEnvironment(DA.GetSys("idflowchart"), DA.GetSys("ndetail"));
            DA.ReadAllGroupOperations();

            QHS = DA.GetQueryHelper();
            form = F;
            Dispatcher = D;
            MenuIsCharged = false;
            menuEvent = new System.EventHandler(this.menuItem_Click);
            DS = new vistaMenu();

            List<SelectBuilder> SelList = new List<SelectBuilder>();
            SelList.Add( new SelectBuilder("appname,electronictrasmission,electronicimport,importappname").IntoTable(DS.config).Where(QHS.CmpEq("ayear", DA.GetEsercizio())));
            SelList.Add(new SelectBuilder("idsorkind,description").IntoTable(DS.sortingkind).Where(QHS.CmpEq("active", "S")));
            SelList.Add(new SelectBuilder("idsorkind,description").IntoTable(DS.sortingapplicabilityview));
            SelList.Add(new SelectBuilder("*").IntoTable(DS.incomephase));
            SelList.Add(new SelectBuilder("*").IntoTable(DS.expensephase));
            SelList.Add(new SelectBuilder("flag").IntoTable(DS.uniconfig));
            SelList.Add(new SelectBuilder("modulename,groupname,description").IntoTable(DS.report).Where(
                    QHS.AppAnd(DA.GetSys("filterrule") as string, QHS.CmpEq("active", "S"))));
            SelList.Add(new SelectBuilder("procedurename ,description,modulename").IntoTable(DS.exportfunction).Where(
                QHS.NullOrEq("active","S")));
            SelList.Add(new SelectBuilder("*").IntoTable(DS.menu).OrderBy("paridmenu,ordernumber"));
            SelList.Add(new SelectBuilder("*").IntoTable(DS.flowchartmodulegroup).Where(QHS.CmpEq("idflowchart", DA.GetSys("idflowchart"))));
            SelList.Add(new SelectBuilder("*").IntoTable(DS.flowchartexportmodule).Where(QHS.CmpEq("idflowchart", DA.GetSys("idflowchart"))));
            SelList.Add(new SelectBuilder("*").IntoTable(DS.menuvisibility));

            DA.MULTI_RUN_SELECT(SelList);


          
      


        }

        public void Dispose() {
            DA.Destroy();
        }
        Dictionary<string, bool> stampeConsentite = null;
        Dictionary<string, bool> esportazioniConsentite = null;
        DataTable tMenu;
        bool voceFormConsentita(string metadata, string edittype) {
            if (tMenu == null) {
                tMenu = DA.CreateTableByName("menu", "*", false);
            }
            tMenu.Clear();
            DataRow r = tMenu.NewRow();
            r["idmenu"] = 1;
            r["title"] = "aa";
            r["metadata"] = metadata;
            r["edittype"] = edittype;
            tMenu.Rows.Add(r);
            return DA.Security.CanSelect(r);
        }
        bool stampaConsentita(string modulo, string gruppo) {
            if (stampeConsentite == null) return true;
            return stampeConsentite.ContainsKey(modulo.Trim().ToLower() + "." + gruppo.Trim().ToLower());
        }
        bool esportazioneConsentita(string modulo) {
            if (esportazioniConsentite == null) return true;
            return esportazioniConsentite.ContainsKey(modulo.Trim().ToLower());
        }
        /// <summary>
        /// Crea il menu a partire dalla tabella menu che trova sul db, filtrando in base alla sicurezza e rimuovendo le voci che 
        ///  non hanno corrispondenza nelle stampe o nelle esportazioni accessibili. Non scrive sul db.
        /// </summary>
        /// <param name="Menu"></param>
        /// <param name="TableName"></param>
        /// <param name="Myfilter"></param>
        public void CreateMenu(MainMenu Menu, string TableName, string Myfilter) {
            if (MenuIsCharged) return;
            stampeConsentite = null;
            esportazioniConsentite = null;
            this.TableName = TableName;
            int h1 = metaprofiler.StartTimer("Menu - sezione Stampe");

            //Legge tutte le righe della tabella menu dal db
            //DT_Menu = DA.RUN_SELECT(TableName, "*", "paridmenu, ordernumber", Myfilter, null, false);
            DT_Menu = DS.menu;
            DA.DeleteAllUnselectable(DT_Menu);
            QueryHelper QHS = DA.GetQueryHelper();
            CQueryHelper QHC = new CQueryHelper();
            object idflowchart = DA.GetSys("idflowchart");

            //Cancella tutte le stampe che ha trovato nella tabella del menu e per cui non esista (o non sia accessibile)
            // una corrispondente riga in resultparameter
            if (idflowchart != null && idflowchart != DBNull.Value) {
                stampeConsentite = new  Dictionary<string, bool>();

                //Applica filtro su stampe in base a flowchart
                //DataTable MyMod = DA.RUN_SELECT("flowchartmodulegroup", "*", null, QHS.CmpEq("idflowchart", idflowchart), null, false);
                DataTable MyMod = DS.flowchartmodulegroup;
                foreach (DataRow r in MyMod.Rows) {
                    string coppia = r["modulename"].ToString().Trim().ToLower() + "." + r["groupname"].ToString().Trim().ToLower();
                    stampeConsentite[coppia] = true;
                }               
            }
            DT_Menu.AcceptChanges();
            metaprofiler.StopTimer(h1);

            //Cancella tutte le esportazioni che non ci sono o  non sono accessibili su exportfunction
            int h2 = metaprofiler.StartTimer("Menu - sezione Esportazioni");
            if (idflowchart != null && idflowchart != DBNull.Value) {
                esportazioniConsentite = new Dictionary<string, bool>();
                //Applica filtro su stampe in base a flowchart
                //DataTable MyMod = DA.RUN_SELECT("flowchartexportmodule", "*", null, 
                //QHS.CmpEq("idflowchart", idflowchart), null, false);
                DataTable MyMod = DS.flowchartexportmodule;
                foreach (DataRow r in MyMod.Rows) {
                    string coppia = r["modulename"].ToString().Trim().ToLower();
                    esportazioniConsentite[coppia] = true;
                }
               
            }
            DT_Menu.AcceptChanges();
            metaprofiler.StopTimer(h2);

            Dictionary<string, bool> toHide = new Dictionary<string, bool>();
            //DataTable menuVisibility = DA.RUN_SELECT("menuvisibility", "*", null, null, null, false);
            DataTable menuVisibility = DS.menuvisibility;

            foreach (DataRow r in menuVisibility.Select()) {
                if (r["visible"].ToString().ToUpper() == "N") toHide.Add(r["menucode"].ToString().ToLower(), true);
            }
            

            //Se la tabella è vuota esci
            if ((DT_Menu == null) || (DT_Menu.Rows.Count == 0)) return;


            int h3 = metaprofiler.StartTimer("Menu - sezione Terza");

            //costruisce una hash di liste ove ogni elemento è una lista di datarow ed HMenu[idmenu] punta alla lista 
            // dei datarow aventi quell'idmenu come paridmenu
            Dictionary<int, List<DataRow>> HMenu = new Dictionary<int, List<DataRow>>();
            foreach (DataRow RMenu in DT_Menu.Rows) {
                int idMenu = RMenu["paridmenu"] == DBNull.Value ? 0: Convert.ToInt32(RMenu["paridmenu"]);
                if (!HMenu.ContainsKey(idMenu)) {
                    HMenu[idMenu] = new List<DataRow>();
                }
                HMenu[idMenu].Add(RMenu);
            }

            List<DataRow> AL = new List<DataRow>();
            if (HMenu.ContainsKey(0)) AL = HMenu[0];

            //Per ogni riga della tabella Menu del Database, ordinata per supid e ordernumber, aggiunge la voce stessa
            // e le sotto voci al  menu
            foreach (DataRow DR in AL) {
                Element childElement = createMenuItem(HMenu, toHide, DR);
                if (childElement == null) continue;
                Menu.MenuItems.Add(Menu.MenuItems.Count - 1, childElement); //Aggiunge la voce di menu al  menu principale                
            }
         
            metaprofiler.StopTimer(h3);
            ControllaConfigurazioni(Menu, DA);

            MenuIsCharged = true;
        }
     

        void DisableMenu(Menu mainMenu, string menutext) {
            foreach (MenuItem MI in mainMenu.MenuItems) {
                if (MI.Text == menutext) {
                    MI.Enabled = false;
                    break;
                }
            }
        }

        void EnableMenu(Menu mainMenu, string menutext) {
            foreach (MenuItem MI in mainMenu.MenuItems) {
                if (MI.Text == menutext) {
                    MI.Enabled = true;
                    break;
                }
            }
        }

        private void ControllaConfigurazioni(Menu mainMenu, DataAccess Conn) {
            //bool BilancioEnabled=true;
            QueryHelper QHS = Conn.GetQueryHelper();
            string filteresercizio = QHS.CmpEq("ayear", Conn.GetSys("esercizio"));
            DataTable tConfig = DS.config;
            if (tConfig.Rows.Count == 0) {
                MessageBox.Show("NON ESISTE ALCUNA CONFIGURAZIONE PER L'ESERCIZIO CORRENTE!", "Attenzione",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                DisableMenu(mainMenu, "Compensi");
                DisableMenu(mainMenu, "Entrate");
                DisableMenu(mainMenu, "Spese");
                DisableMenu(mainMenu, "Cespiti");
                DisableMenu(mainMenu, "Bilancio");
                DisableMenu(mainMenu, "Tesoriere");

                return;
            }

            DataRow rConfig = tConfig.Rows[0];

            bool SpeseEntrateEnabled = true;
            bool abilitaBilancio = false;
            string[] fieldBilancio = new string[] {"appropriationphasecode", "assessmentphasecode"};
            foreach (string colName in fieldBilancio) {
                if (rConfig[colName] == DBNull.Value) continue;
                abilitaBilancio = true;
            }
            if (!abilitaBilancio) {
                MessageBox.Show("La configurazione del BILANCIO non è stata definita per l'esercizio corrente. " +
                                "Non sarà possibile accedere ai menu Bilancio/Entrate/Spese", "Attenzione",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                DisableMenu(mainMenu, "Bilancio");
                //BilancioEnabled=false;
                SpeseEntrateEnabled = false;
            }
            else
                EnableMenu(mainMenu, "Bilancio");

            bool abilitaMiss = false;
            string[] fieldMissione = new string[] {"idfinexpense", "idclawback", "foreignhours"};
            foreach (string colName in fieldMissione) {
                if (rConfig[colName] == DBNull.Value) continue;
                abilitaMiss = true;
            }

            if (!abilitaMiss) {
                MessageBox.Show("La configurazione delle MISSIONI non è stata definita per l'esercizio corrente!",
                    "Attenzione",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                DisableMenu(mainMenu, "Compensi");
            }
            else {
                EnableMenu(mainMenu, "Compensi");
            }

            bool abilitaEntrata = false;
            string[] fieldEntrata = new string[] {
                "proceeds_finlevel", "income_expiringdays", "proceeds_flagautoprintdate",
                "flagautoproceeds", "flagfruitful"
            };
            foreach (string colName in fieldEntrata) {
                if (rConfig[colName] == DBNull.Value) continue;
                abilitaEntrata = true;
            }

            if ((SpeseEntrateEnabled == true) && (!abilitaEntrata)) {
                MessageBox.Show("La configurazione delle ENTRATE non è stata definita per l'esercizio corrente. " +
                                "Non sarà possibile accedere ai menu Entrate/Spese", "Attenzione",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                SpeseEntrateEnabled = false;
            }

            bool abilitaSpesa = false;
            string[] fieldSpesa = new string[] {
                "payment_finlevel", "expense_expiringdays", "payment_flagautoprintdate",
                "flagautopayment", "taxvaliditykind"
            };
            foreach (string colName in fieldSpesa) {
                if (rConfig[colName] == DBNull.Value) continue;
                abilitaSpesa = true;
            }

            if ((SpeseEntrateEnabled == true) && (!abilitaSpesa)) {
                MessageBox.Show("La configurazione delle SPESE non è stata definita per l'esercizio corrente. " +
                                "Non sarà possibile accedere ai menu Entrate/Spese", "Attenzione",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                SpeseEntrateEnabled = false;
            }

            if (SpeseEntrateEnabled) {
                EnableMenu(mainMenu, "Entrate");
                EnableMenu(mainMenu, "Spese");
            }
            else {
                DisableMenu(mainMenu, "Entrate");
                DisableMenu(mainMenu, "Spese");
            }

            bool abilitaPatrimonio = false;
            string[] fieldPatrimonio = new string[] {"linktoinvoice", "asset_flagrestart", "assetload_flag"};
            foreach (string colName in fieldPatrimonio) {
                if (rConfig[colName] == DBNull.Value) continue;
                abilitaPatrimonio = true;
            }

            if (!abilitaPatrimonio) {
                //MessageBox.Show("La configurazione del PATRIMONIO non è stata definita per l'esercizio corrente!", "Attenzione",
                //	MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                DisableMenu(mainMenu, "Cespiti");
            }
            else
                EnableMenu(mainMenu, "Cespiti");

        }

        /// <summary>
        /// Creates menuitem corrisponding to DR (of table Menu) (including all subMenuItems)
        /// </summary>
        /// <param name="hashMenu"></param>
        /// <param name="toHide"></param>
        /// <param name="DR"></param>
        /// <returns></returns>
        Element createMenuItem(Dictionary<int, List<DataRow>> hashMenu, Dictionary<string, bool> toHide, DataRow DR) {
            string menucode = DR["menucode"].ToString().Trim().ToLower();
            string metadata = DR["metadata"].ToString().Trim().ToLower();
            string edittype = DR["edittype"].ToString().Trim().ToLower();
            if (menucode != "" && toHide.ContainsKey(menucode)) {
                return null; //ignora la voce
            }
            if (metadata != "" && toHide.ContainsKey(metadata)) {
                return null; //ignora la voce
            }
            int idMenu = Convert.ToInt32(DR["idmenu"]);
            Element MyItem = new Element(DR); //nuova voce di menu     

            //Verifica che non sia associato ad una gestione dinamica
            if (pre_addSpecialChilds(MyItem)) {
                if (MyItem.MenuItems.Count == 0 && (MyItem.metadata == ""||MyItem.metadata==null)) return null;
                return MyItem;
            }

            if (menucode != "" && metadata == "") {
                MenuByMenuCode[menucode] = MyItem;
                //Caso di elemento contenitore
                bool firstElement = true;
                if (hashMenu.ContainsKey(idMenu)) {
                    DataRow lastDash = null;
                    foreach (DataRow rChild in hashMenu[idMenu]) {
                        if (rChild["title"].ToString().Trim() == "-") {
                            lastDash = rChild;
                            continue;
                        }
                        //non deve restituire contenitori vuoti
                        Element childMenu = createMenuItem(hashMenu, toHide, rChild); //se è una voce contenitore, aggiunge le voci figlie
                        if (childMenu == null) continue;
                        if (lastDash != null && firstElement == false) {
                            MyItem.MenuItems.Add(new Element(lastDash));
                            lastDash = null;
                        }
                        MyItem.MenuItems.Add(childMenu);
                        firstElement = false;
                    }
                }
                post_addSpecialChilds(MyItem);
                if (MyItem.MenuItems.Count==0) return null; //non ha aggiunto nulla, è un contenitore vuoto che non va restituito
                return MyItem;
            }            
            if ((edittype != "") && (metadata != "")) {
                MyItem.Click += menuEvent;
                return MyItem; //voce semplice
            }
            return null; //non dovrebbe passare di qua            

        }
        
        //Inserire nella sezione PRE le gestioni che devono SOSTITUIRE INTEGRALMENTE i nodi dinamici eventualmente presenti ignorandoli
        // nel qual caso la funzione restituirà TRUE
        bool pre_addSpecialChilds(Element parent) {
            if (parent.menucode == null) return false;
            string menucode = parent.menucode;
            CQueryHelper QHC = new CQueryHelper();

            if (menucode== "codtipoclassmoviment") {
                createSubMenu(parent, "sortingkind", null, null,
                    "idsorkind", "description", "default", "sortinglevel", true);
                return true;
            }
            if (menucode == "codclassmov") {
                createSubMenu(parent, "sortingkind", null, null, 
                    "idsorkind", "description", "default", "sorting", false);
                return true;
            }
            if (menucode == "traduzioneclassifica") {
                parent.setTitle( "Configurazione classificazioni indirette");
                createSubMenu(parent, "sortingkind", null, null,
                    "idsorkind", "description", "traduzione", "sorting", false);
                return true;
            }
            if (menucode == "varclassmoven") {
                parent.setTitle("Variazione previsione entrate");
                createSubMenu(parent, "sortingkind", null, "(nphaseincome is not null)", 
                    "idsorkind", "description", "default", "sortingprevincomevar", false);
                return true;
            }
            if (menucode == "varclassmovsp") {
                parent.setTitle("Variazione previsione spese");
                createSubMenu(parent, "sortingkind", null, "(nphaseexpense  is not null)",
                    "idsorkind", "description", "default", "sortingprevexpensevar", false);
                return true;
            }
            if (menucode == "impmoven") {
                parent.setTitle("Imputazione movimento di entrata");
                createSubMenu(parent, "sortingkind", null, "(nphaseincome is not null)",
                    "idsorkind", "description", "main", "incomesorted", false);
                return true;
            }
            if (menucode == "impmovsp") {
                parent.setTitle("Imputazione movimento di spesa");
                createSubMenu(parent, "sortingkind", null, "(nphaseexpense  is not null)",
                    "idsorkind", "description", "main", "expensesorted", false);
                return true;
            }
			if (menucode == "classaccount") {
				parent.setTitle("Classificazione piano dei conti");
				createSubMenu(parent, "sortingapplicabilityview", null, "(tablename='account')",
				"idsorkind", "description", "default", "accountsorting", false);
				return true;
			}
			if (menucode == "classhist") {
                parent.setTitle("Classificazioni");
                createSubMenu(parent, "sortingkind", null,null,
                    "idsorkind", "description", "history", "sorting", false);
                return true;
            }
            if (menucode == "classbila") {
                parent.setTitle("Classificazioni Bilancio");
                createSubMenu(parent, "sortingapplicabilityview", null, "(tablename='fin')", 
                    "idsorkind", "description", "imputazione", "finsorting", false);
                return true;
            }

            if (menucode == "classcred") {
                parent.setTitle("Classificazioni Anagrafica");
                createSubMenu(parent, "sortingapplicabilityview", null, "(tablename='registry')", 
                    "idsorkind", "description", "imputazione", "registrysorting", false);
                return true;
            }
            if (menucode == "classupb") {
                parent.setTitle("Classificazioni U.P.B.");
                createSubMenu(parent, "sortingapplicabilityview", null, "(tablename='upb')", 
                    "idsorkind", "description", "imputazione", "upbsorting", false);
                return true;
            }
            if (menucode == "variazionibudget") {
                parent.setTitle("Variazioni di Budget");
                createSubMenu(parent, "sortingkind", null, QHC.BitSet("flag", 2),
                    "idsorkind", "description", "default", "budgetvar", false);
                return true;
            }
            if (menucode == "dettvariazionibudget") {
                parent.setTitle("Dettagli Variazioni di Budget");
                createSubMenu(parent, "sortingkind", null, QHC.BitSet("flag", 2),
                    "idsorkind", "description", "default", "budgetvardetail", false);
                return true;
            }
            if (menucode == "transfprevinbudget") {
                parent.setTitle("Trasferimento Previsioni in Budget");
                createSubMenu(parent, "sortingkind", null, QHC.BitSet("flag", 2),
                    "idsorkind", "description", "transfprevinbudget", "no_table", false);
                return true;
            }
            if (menucode == "codstampe") {
                updateStampeMenu(parent);
                return true;
            }
            return false;
        }

        void updateStampeMenu(Element parent) {
            //string filter = DA.GetSys("filterrule") as string;
            //filter = GetData.MergeFilters(filter, "(active='S')");
            DataTable ModuleReports = DS.report;
            ModuleReports.CaseSensitive = false;
            //if (ModuleReports == null) ModuleReports = DA.RUN_SELECT("report", "*", "modulename,reportname", null, null, null, false);

            DataRow[] AllModules = ModuleReports.Select(null, "modulename");
            string lastmodule = "";

            foreach (DataRow Module2 in AllModules) {
                if (lastmodule.Trim().ToLowerInvariant() == Module2["modulename"].ToString().Trim().ToLowerInvariant()) continue; //modulo già aggiunto
                
                lastmodule = Module2["modulename"].ToString();
                AddModuleStampe(parent, ModuleReports, lastmodule);
            }
            Element ExportElement = new Element("Esportazioni");
            ExportElement.menucode = "codprocesportazione"; //non che serva

            DataTable ExpStoredProcedure = DS.exportfunction;
            ExpStoredProcedure.CaseSensitive = false;

            AllModules = ExpStoredProcedure.Select(null, "modulename");
            lastmodule = "";
            foreach (DataRow Module2 in AllModules) {                
                if (lastmodule.Trim().ToLowerInvariant() == Module2["modulename"].ToString().Trim().ToLowerInvariant()) continue;
                lastmodule = Module2["modulename"].ToString();
                if (!esportazioneConsentita(lastmodule)) continue;
                AddModuleEsportazioni(ExportElement, ExpStoredProcedure, lastmodule);
            }
            if (ExportElement.MenuItems.Count > 0) {
                parent.MenuItems.Add(ExportElement);
            }
        }

        void AddModuleEsportazioni(Element parent, DataTable ExpStoredProcedure, string ModuleName) {
            Element moduleElement = new Element(ModuleName);
            moduleElement.menucode = ModuleName;

            CQueryHelper qhc = new CQueryHelper();
            string filtermodule = qhc.CmpEq("modulename", ModuleName);
            DataRow[] Exports = ExpStoredProcedure.Select(filtermodule, "description");
            foreach (DataRow Export in Exports) {                
                Element exportElement = new Element(Export["description"].ToString());
                exportElement.metadata = "export";
                exportElement.edittype = "default";
                exportElement.parameter = Export["procedurename"];
                exportElement.modal = false;
                exportElement.Click += menuEvent;
                moduleElement.MenuItems.Add(exportElement);
            }
            if (moduleElement.MenuItems.Count > 0) {
                parent.MenuItems.Add(moduleElement);
            }
            
        }

        /// <summary>
        /// Aggiunge le voci di menu (stampe) relative ad un modulename, come figlie 
        ///  della voce di menu di IDMenuStampe
        /// </summary>
        /// <param name="ModuleReport"></param>
        /// <param name="ModuleName"></param>
        void AddModuleStampe(Element parent, DataTable TReport, string ModuleName) {
            Element moduleElement = new Element(ModuleName);
            moduleElement.menucode = ModuleName;

            CQueryHelper qhc = new CQueryHelper();

            string filtermodule = qhc.CmpEq("modulename", ModuleName);            
            DataRow[] Reports = TReport.Select(filtermodule, "groupname,description");
            int groupNum = 0;
            string lastgroup = "";
            Element groupElement=null;
            foreach (DataRow Report in Reports) {
                //Sceglie il Gruppo in cui aggiungere la voce di menu, se non esiste lo crea
                string groupname = Report["groupname"].ToString();
                if (!stampaConsentita(ModuleName, groupname)) continue;
                if (groupname.ToLowerInvariant() != lastgroup.ToLowerInvariant()) {
                    lastgroup = groupname;
                    groupNum += 10;
                    groupElement = new Element(groupname);
                    groupElement.menucode = groupname;
                    moduleElement.MenuItems.Add(groupElement);
                }

                //Aggiunge il report al gruppo
                string parameter = Report["modulename"].ToString().Replace(".", "") + "." + Report["reportname"];

                Element reportElement = new Element(Report["description"].ToString());
                reportElement.metadata = "resultparameter";
                reportElement.edittype = "default";
                reportElement.parameter = parameter;
                reportElement.modal = false;
                reportElement.Click += menuEvent;
                groupElement.MenuItems.Add(reportElement);
            }
            if (moduleElement.MenuItems.Count > 0) {
                parent.MenuItems.Add(moduleElement);
            }
            
        }



        void updateMovimentoMenu(Element parent,string meta,string edittype) {
            List<MenuItem> listaDaCancellare = new List<MenuItem>();
            foreach (MenuItem m in parent.MenuItems) {
                Element e = m as Element;
                if (e == null) continue;
                if (e.metadata == meta && e.edittype == edittype) listaDaCancellare.Add(m);
            }
            foreach (MenuItem m in listaDaCancellare) {
                parent.MenuItems.Remove(m);
            }
            if (!voceFormConsentita(meta, edittype)) return;
            parent.MenuItems.Add(new Element("-"));
            DataTable phase = DS.Tables[meta + "phase"];
            foreach(DataRow r in phase.Select(null, "nphase")) {
                Element c1 = new Element(r["nphase"] + " - " + r["description"]);
                c1.metadata = meta;
                c1.edittype = edittype;
                c1.parameter = r["nphase"].ToString();
                c1.modal = false;
                c1.Click += menuEvent;
                parent.MenuItems.Add(c1);
            }
        }
        /// <summary>
        /// Cancella sdi_vendita default in determinate condizioni
        /// </summary>
        /// <param name="parent"></param>
        void updateVarious(Element parent) {
            
            DataTable UniCfg =DS.uniconfig;
            if (UniCfg.Rows.Count == 0) return;
            int flag = NoNullInt(UniCfg.Rows[0]["flag"]);
            if ((flag & 2) == 0 || !voceFormConsentita("sdi_vendita", "default")) {
                List <MenuItem> listaDaCancellare = new List<MenuItem>();
                foreach (MenuItem m in parent.MenuItems) {
                    Element e = m as Element;
                    if (e == null) continue;
                    if (e.metadata == "sdi_vendita" && e.edittype == "default") listaDaCancellare.Add(m);
                }
                foreach (MenuItem m in listaDaCancellare) {
                    parent.MenuItems.Remove(m);
                }
            }

                //if ((flag & 2) != 0) {
                //    Element c1 = new Element("Fatture di vendita selezionate per la trasmissione");
                //    c1.metadata = "sdi_vendita";
                //    c1.edittype = "default";                
                //    c1.modal = false;
                //    parent.MenuItems.Add(c1);
                //}
            }
            //Inserire nella sezione POST le gestioni che devono SOSTITUIRE PARZIALMENTE i nodi dinamici eventualmente presenti         
            void post_addSpecialChilds(Element parent) {
            if (parent.menucode == null) return ;
            string menucode = parent.menucode;
            if (menucode == "codcassiere") {
                UpdateCassiere(parent);                
            }
            if (menucode == "codentrate") {
                updateMovimentoMenu(parent,"income","levels");
            }
            if (menucode == "codspese") {
                updateMovimentoMenu(parent, "expense", "levels");
            }
            if (menucode == "codflussife") {
                updateVarious(parent);
            }
            
        }


        /// <summary>
        /// codcassiere
        /// </summary>
        /// <returns></returns>
        private void UpdateCassiere(Element parent) {
            List<MenuItem> listaDaCancellare = new List<MenuItem>();
            foreach(MenuItem m in parent.MenuItems) {
                Element e = m as Element;
                if (e == null) continue;
                if (e.metadata == "bankdispositionsetup" && e.edittype == "trasmissione") listaDaCancellare.Add(m);
                if (e.metadata == "no_table" && e.edittype == "expbank") listaDaCancellare.Add(m);
                if (e.metadata == "bankdispositionsetup" && e.edittype == "importazione") listaDaCancellare.Add(m);
            }
            foreach(MenuItem m in listaDaCancellare) {
                parent.MenuItems.Remove(m);
            }
            if (DS.config.Rows.Count == 0) return;

            var rConfig =DS.config.Rows[0];

            string appname = rConfig["appname"].ToString().Trim();
            string etrasm = rConfig["electronictrasmission"].ToString().Trim().ToLower();
            if (etrasm == "s") {
                if (appname != "" && voceFormConsentita("no_table","expbank")) {
                    Element c1 = new Element("Trasmissione distinte");
                    c1.metadata= "no_table";
                    c1.edittype = "expbank";
                    c1.parameter = appname;
                    c1.modal = false;
                    c1.Click += menuEvent;
                    parent.MenuItems.Add(c1);
                }

            }
            else {
                if (appname != "" && voceFormConsentita("bankdispositionsetup", "trasmissione")) {
                    Element c1 = new Element("Trasmissione distinte");
                    c1.metadata = "bankdispositionsetup";
                    c1.edittype = "trasmissione";
                    c1.parameter = appname;
                    c1.modal = false;
                    c1.Click += menuEvent;
                    parent.MenuItems.Add(c1);
                }                
            }
            

            if (rConfig["electronicimport"].ToString().ToLower() != "s") return ;
            if (rConfig["importappname"].ToString().Trim() == "") return ;
            if (!voceFormConsentita("bankdispositionsetup", "importazione")) return;
            Element c2 = new Element("Trasmissione e Importazione esiti");
            c2.metadata = "bankdispositionsetup";
            c2.edittype = "importazione";
            c2.parameter = rConfig["importappname"].ToString().Trim();
            c2.modal = false;
            c2.Click += menuEvent;
            parent.MenuItems.Add(c2);
		
        }


        private bool createSubMenu(Element parent,
            string tablename,
            string sqlFilter,
            string cFilter,            
            string f_parameter,
            string f_text,
            string edittype,
            string metadata,
            bool modal
            ) {
            if (!voceFormConsentita(metadata, edittype)) return true;
            DataTable t = null;
            
            if (tablename == "sortingkind") {
                t = DS.sortingkind;
            }
            if (tablename== "sortingapplicabilityview") {
                t = DS.sortingapplicabilityview;
            }
            if (t == null) {
                t = DA.RUN_SELECT(tablename, "*", null, sqlFilter, null, false);
            }


            foreach (DataRow R in t.Select(cFilter, f_text)) {
                Element child = new Element(R[f_text].ToString());
                child.parameter = R[f_parameter].ToString();
                child.edittype = edittype;
                child.metadata = metadata;
                child.modal = modal;
                child.Click += menuEvent;
                parent.MenuItems.Add(child);
            }
            return true;
        }

        //Evento Click di tutte le voci di menu
        private void menuItem_Click(object sender, System.EventArgs e) {
            if (Dispatcher == null) return;
            if (Dispatcher.Conn == null) return;
            if (Dispatcher.Conn.openError) {
                MessageBox.Show("La connessione col db è stata interrotta. E' necessario ricollegarsi.", "Errore");
                return;
            }
            object dbversion = Dispatcher.GetSys("dbversion");
            if (dbversion == null) {
                dbversion = Dispatcher.Conn.DO_READ_VALUE("updatedbversion", null, "max(versionname)") as string;               
            }
            if (dbversion != null && dbversion.ToString()!="" && dbversion.ToString().CompareTo("2.4.100")<0) {
                MessageBox.Show("Attendere che il db si aggiorni per continuare ad usare il programma.", "Avviso");
                return;
            }
            Dispatcher.SetSys("dbversion", dbversion);

            Element MyElement = sender as Element;
            if (MyElement == null) return;
            
            
            //DataRow DR = (DataRow)(MyHash[(((MenuItem)sender).GetHashCode())]);
            string MyMetaName = MyElement.metadata;
            string MyEditType = MyElement.edittype;
            if (MyMetaName == null || MyMetaName == "") return;
            if (MyEditType == null || MyEditType == "") return;
            if (MyMetaName == "" || MyEditType == "") return;             
            Dispatcher.Edit(form, MyMetaName, MyEditType, MyElement.modal, MyElement.parameter);
        }

        /// <summary>
        /// Cancella tutte le voci di menu aggiunte da questa classe lasciando solo quelle create a Design Time.
        /// Opera solo sul controllo Menu, non sul db
        /// </summary>
        /// <param name="M"></param>
        public void ClearMenu(MainMenu M) {
            if (!MenuIsCharged) return;
            int i = 0;
            while (i < M.MenuItems.Count) {
                Element E = M.MenuItems[i] as Element;
                if (E == null) { //se non è convertibile in Element allora è di tipo design time
                    MenuItem MM = M.MenuItems[i]; //prende l'elemento considerato
                    if (MM.MenuItems.Count > 0 || MM.Text == "?") { //se ha figli o è la guida non lo cancella
                        i = i + 1;
                    }
                    else {
                        M.MenuItems.RemoveAt(i);
                    }
                }
                else {
                    M.MenuItems.RemoveAt(i);
                    //Application.DoEvents();
                }
            }

            ////leggo solo le righe padri
            //DataRow[] MyRowsByLevel = DT_Menu.Select("!level = 1");
            //foreach(DataRow DR in MyRowsByLevel)
            //{	
            //    if ((DR["!hashcode"]==null)||(DR["!hashcode"]==DBNull.Value))continue;				
            //    MenuItem MyItem = ((Element)MyHash[DR["!hashcode"]]).MyItem;
            //    if (MyItem==null)continue;
            //    //Elimino la collection dei figli
            //    MyItem.MenuItems.Clear();
            //    Menu Parent = MyItem.Parent;
            //    if (Parent==null)continue;
            //    //Elimino il padre corrente
            //    if(!MyItem.IsParent) Parent.MenuItems.Remove(MyItem);
            //}	
            MenuIsCharged = false;
        }

    } //fine classe MenuMaker


} //fine namespace
