
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


using LiveUpdate;//LiveUpdate
using metadatalibrary;
using metaeasylibrary;
using System;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace mainform {

	///TODO: Svuotare i dati della statusbar sul disconnect
	///TODO: Rendere modificabile l'esercizio  / datacontabile 

	/// <summary>
	/// Summary description for frmMain.
	/// </summary>
	/// <summary>
	/// The main entry point for the application.
	/// </summary>




	public class frmMain : System.Windows.Forms.Form {

        #region Dichiarazione Variabili
        public Easy_DataAccess MyDataAccess;
        public EntityDispatcher Dispatcher;
        public menuMaker MainMenuMaker;

        private System.Windows.Forms.MenuItem menuItem5;
        private System.Windows.Forms.MenuItem menuItem8;
        private System.Windows.Forms.MenuItem menuItem9;
        private System.Windows.Forms.ImageList images;
        private System.Windows.Forms.ToolBarButton inserisci;
        private System.Windows.Forms.ToolBarButton elimina;
        private System.Windows.Forms.ToolBarButton Salva;
        private System.Windows.Forms.ToolBarButton impostaricerca;
        private System.Windows.Forms.ToolBarButton effettuaricerca;
        private System.Windows.Forms.StatusBar SBAR;
        private System.Windows.Forms.StatusBarPanel Operator;
        private System.Windows.Forms.StatusBarPanel Esercizio;
        private System.Windows.Forms.StatusBarPanel DB;
        private System.Windows.Forms.ToolBarButton inseriscicopia;
        private System.Windows.Forms.OpenFileDialog FilePicker;
        private System.Windows.Forms.SaveFileDialog FileSaver;
        private System.Windows.Forms.MenuItem menuItem4;
        private System.Windows.Forms.MenuItem menuItem7;
        private System.Windows.Forms.MenuItem menuItem59;
        private System.Windows.Forms.MenuItem menuItem60;
        private System.Windows.Forms.MenuItem menuItem61;
        private System.Windows.Forms.MenuItem menuItem2;
        private System.Windows.Forms.MenuItem menuItem10;
        private System.Windows.Forms.MenuItem ConnectItem;
        private System.Windows.Forms.MenuItem DisconnectItem;
        private System.Windows.Forms.MenuItem menuAdmin;
        private System.Windows.Forms.Timer Updatetimer1;
        private System.Windows.Forms.StatusBarPanel DataCont;
        private System.Windows.Forms.StatusBarPanel LiveUpdate;
        private System.Windows.Forms.MenuItem mnuComprimi;
        private System.Windows.Forms.StatusBarPanel DBUpdate;

        #endregion
        private System.Windows.Forms.MenuItem mnuGenSQLTabella;
        private System.Windows.Forms.MenuItem mnuGenRelDir;
        private System.Windows.Forms.MenuItem mnuGenRelIndir;
        private System.Windows.Forms.MenuItem mnuInstallazione;
        private System.Windows.Forms.MenuItem mnuGenereLiveUpdate;
        private System.Windows.Forms.MenuItem mnuAbilitaAdmin;
        private System.Windows.Forms.MenuItem mnuAzzeraVerSW;
        private System.Windows.Forms.MenuItem mnuBackup;
        private System.Windows.Forms.MenuItem mnuUpdatedbversion;
        private System.Windows.Forms.MenuItem mnuBigAdmin;
        private System.Windows.Forms.ToolBarButton btnGotoNext;
        private System.Windows.Forms.ToolBarButton btnGotoPrev;
        private System.Windows.Forms.ToolBarButton btnAffianca;
        private System.Windows.Forms.MenuItem menuItem22;
        bool MustDisplayConnect = true;
        private System.Windows.Forms.MenuItem mnuEstraiFile;
        private System.Windows.Forms.ToolBarButton btnEditNotes;
        private System.Windows.Forms.MenuItem menuItem35;
        private System.Windows.Forms.MenuItem mnuLocalConfig;
        private System.Windows.Forms.MenuItem mnuLiveUpdateOnDemand;
        private System.Windows.Forms.MenuItem menuItem25;
        private System.Windows.Forms.MenuItem menuItem37;
        private System.Windows.Forms.MenuItem mnuLiveUpdateSync;
        private System.Windows.Forms.MenuItem menuItem38;
        private System.Windows.Forms.MenuItem mnuCambiaPassword;
        private System.Windows.Forms.MenuItem menuHelp;
        MyListener TS;
        private System.Windows.Forms.MenuItem menuItem6;
        private System.Windows.Forms.MenuItem mnuCfgTECNICA;
        private System.Windows.Forms.MenuItem mnuCfgCONTABILE;
        private System.Windows.Forms.MenuItem CreaCodiceTabSistema;
        bool InTicker1 = false;
        private System.Windows.Forms.MenuItem mnuCambiaPasswordDipart;
        private System.Windows.Forms.MenuItem menuItem12;
        private System.Windows.Forms.MenuItem menuItem14;
        private MenuItem menuItem13;
        private MenuItem menuItem15;
        private MenuItem ChangeRoleItem;
        private MenuItem menuItem16;
        private MenuItem menuItem17;
        private MenuItem menuItem18;
        private MenuItem menuItem19;
        private FolderBrowserDialog openDir;
        private MenuItem menuItem20;
        private MenuItem menuItem21;
        private MenuItem menuItem26;
        private MenuItem menuItem27;
        private ToolBarButton brnEmptyList;
        private MenuItem menuItem28;
        private MenuItem mnuCheckDll;
        private MenuItem menuItem29;
        private MenuItem menuVarie;
        private MenuItem menuItem30;
        private MenuItem menuItem31;
        private MenuItem mnuConsolida;
        private MenuItem mnuConfignotifiche;
        private MenuItem menuItemConvert;
        private MenuItem menuItemMacroarea;
        private MenuItem menuItemMacroareaVitto;
        private MenuItem menuItem36;
        private MenuItem menuItem39;
        private System.Windows.Forms.Timer timer1;
        private StatusBarPanel lastLoadTime;
        private MenuItem menuItem40;
        public ToolBar MetaDataToolBar;
        private MenuItem menuItem41;
        private MenuItem menuItem42;
        private MenuItem menuTicket;
        private MenuItem menuItem44;
        private MenuItem menuDescrTabelle;
        private MenuItem menuItem45;
        private StatusBarPanel currentRole;
        private MenuItem menuItem43;
        bool MustClose = false;
        private MenuItem menuTeamViewer;
        private MenuItem menuItem11;
        private MenuItem mnuCreaStruttura;
        private MenuItem menuItem23;
        public static string[] argCopy;
        private MenuItem mnuIndiceGuida;
        private MenuItem menuTeamViewer2;
        private MenuItem menuItem24;
        static public frmMain F;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args) {
            Application.ThreadException += Application_ThreadException;
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.DoEvents();

            try {
                ConfigurationManager.AppSettings.Set("EnableWindowsFormsHighDpiAutoResizing", "true");
            }
            catch (Exception) { /* Ignora l'eccezione */ }

            argCopy = args;
            F = new frmMain();
            F.SetVisibleCore(false);
            signalCreateForm(F, null);
            try {
                Application.Run(F);
            }
            catch(Exception e) {
	            ErrorLogger.Logger.logException( $"Errore non gestito nell'esecuzione dell'applicazione.", e);
            }
            F.Dispose(true);
        }

        internal static void signalCreateForm(Form f, Form parent) {
	        MetaFactory.factory.getSingleton<IFormCreationListener>().create(f,parent);
        }

        private static void Application_ThreadException(object sender, ThreadExceptionEventArgs e) {
            if (F != null && !F.IsDisposed) {
                try {
                    IDataAccess conn = null;
                    if (F.Dispatcher != null) {
                        conn = F.getInstance<IDataAccess>();
                        string forms = "Application.Run(Disp)\r\n";
                        bool found = false;
                        foreach (Form child in F.OwnedForms) {
                            string form = "Form: " + child.Name + ";";
                            form += "Text:" + child.Text;
                            MetaData mchild = MetaData.GetMetaData(child);
                            if (mchild != null) {
	                            var controller = mchild.formController;
                                form += "Metadata:" + mchild.Name;
                                if (controller != null) {
	                                if (controller.IsEmpty) form += "(empty)\r\n;";
	                                if (controller.EditMode) form += "(modifica)\r\n;";
	                                if (controller.InsertMode) form += "(insert)\r\n;";
	                                if (controller.isClosing) form += "[IN CHIUSURA]\r\n;";
	                                form += "currop:" + controller.curroperation + "\r\n;";
	                                form += "drawstate:" + controller.DrawState + "\r\n;";
	                                form += "edittype:" + mchild.edit_type + "\r\n;";
                                }

                                form += "ErroreIrrecuperabile:" + mchild.ErroreIrrecuperabile + "\r\n;";
                                form += "Data contabile:" + mchild.security.GetSys("datacontabile") + "\r\n;";
                                form += "---------------------------\r\n";
                                found = true;
                            }
                            forms += form;
                        }
                        if (!found) forms += "No child forms\r\n";
                        ErrorLogger.Logger.logException(forms,e.Exception,conn?.Security, conn );
                    }
                    else {
                        ErrorLogger.Logger.logException("Application.Run(noDispatcher)", e.Exception,conn?.Security,conn);
                    }
                }
                catch (Exception ee) {                    
                    ErrorLogger.Logger.logException("Errore non gestito catturato" ,ee);
                    QueryCreator.ShowException(F, "Errore non gestito interno", ee);
                }
                QueryCreator.ShowException(F, "Errore non gestito (*)", e.Exception);
            }
            else {
                ErrorLogger.Logger.logException("Errore non gestito" ,e.Exception);
                QueryCreator.ShowException(F, "Errore non gestito", e.Exception);
            }
            
            Application.Exit();
        }

        private System.Windows.Forms.MainMenu mainMenu1;
        private System.Windows.Forms.MenuItem menuItem1;
        private System.Windows.Forms.MenuItem menuItem3;
        private System.Windows.Forms.MenuItem logbtn;
        private System.ComponentModel.IContainer components;

        private Download MyDownloadSW;
        private Thread threadDownloadSW;
        private Download MyDownloadDB;
        private Thread threadDownloadDB;
        private static frmWait FormAttesa;
        private bool FormAttesaVisualizzato;
        bool WrongDomain = false;


        bool CambioDataConsentita(DataAccess DA, DateTime newDate) {
            object idcustomuser = DA.Security.GetSys("idcustomuser");
            object ayear = newDate.Year;
            if (idcustomuser == DBNull.Value) return true;
            QueryHelper QHS = DA.GetQueryHelper();
            string filterall = QHS.CmpEq("idcustomuser", idcustomuser);
            if (DA.RUN_SELECT_COUNT("flowchartuser", filterall, false) == 0) return true; //fuori dall'organigramma

            if (DA.GetSys("idflowchart") is string & !(DA.GetSys("ndetail") is int)) return false;

            string f1 = QHS.AppAnd(QHS.CmpEq("FU.idcustomuser", idcustomuser),
                                QHS.NullOrLe("FU.start", newDate), QHS.NullOrGe("FU.stop", newDate));
            f1 = QHS.AppAnd(f1, QHS.CmpEq("F.ayear", ayear));

            var TT = DA.SQLRunner(
                "SELECT F.idflowchart,FU.flagdefault,FU.ndetail from " +
                "flowchart F join flowchartuser FU ON F.idflowchart=FU.idflowchart " +
                "WHERE " + f1 + " ORDER BY FU.flagdefault DESC");

            if ((TT == null) || (TT.Rows.Count == 0)) {
                return false;
            }

            var Oggi = DateTime.Now;
            f1 = QHS.AppAnd(QHS.CmpEq("FU.idcustomuser", idcustomuser),
                               QHS.NullOrLe("FU.start", Oggi), QHS.NullOrGe("FU.stop", Oggi));
            f1 = QHS.AppAnd(f1, QHS.CmpEq("F.ayear", ayear));

            TT = DA.SQLRunner(
                "SELECT F.idflowchart,FU.flagdefault,FU.ndetail from " +
                "flowchart F join flowchartuser FU ON F.idflowchart=FU.idflowchart " +
                "WHERE " + f1 + " ORDER BY FU.flagdefault DESC");

            if ((TT == null) || (TT.Rows.Count == 0)) {
                return false;
            }



            return true;
        }

        void CheckForCustomColors() {
            string currdir = AppDomain.CurrentDomain.BaseDirectory;
            if (!currdir.EndsWith("\\"))
                currdir += "\\";
            if (File.Exists(currdir + "customcolor.xml")) {
                metadatalibrary.ColorPalette CP = frmPalette.LoadFromFilename(currdir + "customcolor.xml");
                formcolors.metaPalette.SetTo(CP);            
            }
            else {
                //Crea il file se possibile
                frmPalette.SaveToFilename(formcolors.metaPalette, currdir + "customcolor.xml");
            }
        }
        bool isInited = false;

        void initLicenses() {
            string txtFile = "";
            string currdir = AppDomain.CurrentDomain.BaseDirectory;
            if (!currdir.EndsWith("\\"))currdir += "\\";
            string licFileName = Path.Combine(currdir, "licenses.dat");
            if (File.Exists(licFileName)) {
                var b = File.ReadAllBytes(licFileName);
                var c = DataAccess.DecryptBytes(b);
                txtFile = UTF32Encoding.UTF8.GetString(c).Trim();
            }
            else {
                //txtFile ="Grid;GGGG-GGGG-GGGG-GGGG|Editors;EEEE-EEEE-EEEE-EEEE|Zip;ZZZZZZZZZZZZZZZZZZZ|Ftp;FFFFFFFFFFFFFFFFFFF";
                //var c = DataAccess.CryptBytes(UTF32Encoding.UTF8.GetBytes(txtFile));
                //File.WriteAllBytes(licFileName, c);
            }

            var couples = txtFile.Split('|');
            foreach (var cc in couples) {
                var kv = cc.Split(';');
                if (kv[0] == "Grid") Xceed.Grid.Licenser.LicenseKey = kv[1];
                if (kv[0] == "Editors") Xceed.Editors.Licenser.LicenseKey = kv[1];
                if (kv[0] == "Zip") Xceed.Zip.Licenser.LicenseKey = kv[1];
                if (kv[0] == "Ftp") Xceed.Ftp.Licenser.LicenseKey = kv[1];
            }

        }

        bool checkExecutionPath() {
           
            if ((!Debugger.IsAttached) && (AppDomain.CurrentDomain.FriendlyName != "MetaDataDomain") && (isUnderTest==false)
                && ( !isBlazor)) {
                MetaFactory.factory.getSingleton<IMessageShower>().Show("E' necessario eseguire il programma tramite loader.exe. Non è possibile aprire direttamente mainform.exe");
                return false;
            }

            string currDir = Environment.CurrentDirectory;
            string appDomain = AppDomain.CurrentDomain.BaseDirectory;
            if (!File.Exists(Path.Combine(appDomain, "mainform.exe"))) {
                MetaFactory.factory.getSingleton<IMessageShower>().Show("Il programma non è installato bene o è eseguito da cartelle errate.");
                return false;
            }

            if (!Directory.Exists("zip")) {
                MetaFactory.factory.getSingleton<IMessageShower>().Show("Il programma non è installato bene o è eseguito da cartelle errate.");
                return false;
            }

            try {
                var f=File.CreateText(Path.Combine("zip", "testwrite"));
                f.WriteLine("test");
                f.Flush();
                f.Close();
                File.Delete(Path.Combine("zip", "testwrite"));
            }
            catch (Exception) {
                MetaFactory.factory.getSingleton<IMessageShower>().Show("Si prega di non eseguire il programma da cartelle compresse o prive di permessi in scrittura.");
            }



            string dir = Path.GetDirectoryName(Application.ExecutablePath);
            if (dir.Contains("\\zip\\"))
            {
                MetaFactory.factory.getSingleton<IMessageShower>().Show("Si prega di non eseguire il programma da cartelle compresse.");
                return false;

            }
            string exePath = Application.ExecutablePath;
            string tempPath = Path.GetTempPath();
            if (exePath.StartsWith(tempPath)) {
                MetaFactory.factory.getSingleton<IMessageShower>().Show("Non è consentita l'esecuzione dell'applicazione da cartelle temporanee o compresse.","Errore");
                return false;
            }

            return true;
        }
        
        /// <summary>
        /// 
        /// </summary>
        public frmMain() {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
            initLicenses();
            isBlazor = Thread.CurrentThread.Name == "Main Form Blazor Thread";
            CheckForIllegalCrossThreadCalls = false;

            CheckForCustomColors();

            //this.BackColor = formcolors.MainBackColor();
            //this.ForeColor = formcolors.MainForeColor();

            foreach (Control control in this.Controls) {
				// #2
				MdiClient client = control as MdiClient;
				if (!(client == null)) {
					// #3
					client.BackColor = formcolors.MainFormBackColor();
					// 4#
					break;
				}
			}
            BackColor = formcolors.MainBackColor();
            ForeColor = formcolors.MainForeColor();
            AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);

            AutoScaleMode = AutoScaleMode.Dpi;


            Refresh();
            
            MetaData.LastLoadTimeChanged += MyLogger;
            MyDataAccess = null;
            Dispatcher = null;
            MyDownloadSW = null;
            MyDownloadDB = null;
            SetMenu(false,true);

            //            AppDomainSetup setup = new AppDomainSetup();
            //            setup.ApplicationBase = "..\\DLL\\";
            //            setup.PrivateBinPath = AppDomain.CurrentDomain.BaseDirectory;
            //            setup.ApplicationName = "metacampuslibrary";
            //            AppDomain App = AppDomain.CreateDomain("metalibrary");
            var TM = MainToolBarManager.GetToolBarManager(MetaDataToolBar);
            TM.unlink(null);

            string currdir = AppDomain.CurrentDomain.BaseDirectory;
            if (!currdir.EndsWith("\\")) currdir += "\\";

            ///AVVIO AUTOMATICO DELL'INSTALLAZIONE RIMOSSO			
            //			if (!File.Exists(currdir+"updateconfig.xml")){
            //				Form F =  MetaData.GetFormByDllName("Install");
            //				F.ShowDialog(this);
            //			}

            if (TS == null) {
                TS = new MyListener();
                Trace.Listeners.Add(TS);
            }

            UpdateDll();
            isInited = true;
           
           
        }

       


        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing) {
            if (MyDataAccess != null) {
                try {
                    DataAccess OO = MyDataAccess;
                    MyDataAccess = null;
                    OO.Destroy();
                    if (threadDownloadSW != null && MyDownloadSW != null) {
                        var XX = MyDownloadSW;
                        MyDownloadSW = null;
                        XX.StopThread();
                    }
                    if (threadDownloadDB != null && MyDownloadDB != null) {
                        var YY = MyDownloadDB;
                        MyDownloadDB = null;
                        YY.StopThread();
                    }
                }
                catch { }
            }
            if (disposing) {
                if (components != null) {
                    components.Dispose();
                }
            }
            MetaData.LastLoadTimeChanged -= MyLogger;
            base.Dispose(disposing);
        }

       

        #region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
			this.mainMenu1 = new System.Windows.Forms.MainMenu(this.components);
			this.menuItem5 = new System.Windows.Forms.MenuItem();
			this.ConnectItem = new System.Windows.Forms.MenuItem();
			this.DisconnectItem = new System.Windows.Forms.MenuItem();
			this.ChangeRoleItem = new System.Windows.Forms.MenuItem();
			this.menuItem40 = new System.Windows.Forms.MenuItem();
			this.mnuIndiceGuida = new System.Windows.Forms.MenuItem();
			this.menuTeamViewer2 = new System.Windows.Forms.MenuItem();
			this.menuItem37 = new System.Windows.Forms.MenuItem();
			this.menuItem6 = new System.Windows.Forms.MenuItem();
			this.mnuCfgTECNICA = new System.Windows.Forms.MenuItem();
			this.mnuCfgCONTABILE = new System.Windows.Forms.MenuItem();
			this.menuItem41 = new System.Windows.Forms.MenuItem();
			this.mnuLocalConfig = new System.Windows.Forms.MenuItem();
			this.mnuLiveUpdateOnDemand = new System.Windows.Forms.MenuItem();
			this.mnuCambiaPassword = new System.Windows.Forms.MenuItem();
			this.mnuCambiaPasswordDipart = new System.Windows.Forms.MenuItem();
			this.mnuBackup = new System.Windows.Forms.MenuItem();
			this.menuTicket = new System.Windows.Forms.MenuItem();
			this.menuItem42 = new System.Windows.Forms.MenuItem();
			this.menuItem44 = new System.Windows.Forms.MenuItem();
			this.menuTeamViewer = new System.Windows.Forms.MenuItem();
			this.menuItem25 = new System.Windows.Forms.MenuItem();
			this.mnuAbilitaAdmin = new System.Windows.Forms.MenuItem();
			this.menuAdmin = new System.Windows.Forms.MenuItem();
			this.menuItem28 = new System.Windows.Forms.MenuItem();
			this.mnuAzzeraVerSW = new System.Windows.Forms.MenuItem();
			this.mnuCheckDll = new System.Windows.Forms.MenuItem();
			this.mnuConfignotifiche = new System.Windows.Forms.MenuItem();
			this.mnuBigAdmin = new System.Windows.Forms.MenuItem();
			this.mnuGenereLiveUpdate = new System.Windows.Forms.MenuItem();
			this.mnuLiveUpdateSync = new System.Windows.Forms.MenuItem();
			this.mnuCreaStruttura = new System.Windows.Forms.MenuItem();
			this.menuItem38 = new System.Windows.Forms.MenuItem();
			this.mnuGenSQLTabella = new System.Windows.Forms.MenuItem();
			this.mnuGenRelDir = new System.Windows.Forms.MenuItem();
			this.mnuGenRelIndir = new System.Windows.Forms.MenuItem();
			this.menuItem24 = new System.Windows.Forms.MenuItem();
			this.mnuComprimi = new System.Windows.Forms.MenuItem();
			this.menuItem20 = new System.Windows.Forms.MenuItem();
			this.mnuEstraiFile = new System.Windows.Forms.MenuItem();
			this.menuItem22 = new System.Windows.Forms.MenuItem();
			this.menuItem35 = new System.Windows.Forms.MenuItem();
			this.menuItem23 = new System.Windows.Forms.MenuItem();
			this.menuItem21 = new System.Windows.Forms.MenuItem();
			this.menuItem29 = new System.Windows.Forms.MenuItem();
			this.menuItem30 = new System.Windows.Forms.MenuItem();
			this.menuItem31 = new System.Windows.Forms.MenuItem();
			this.menuItemConvert = new System.Windows.Forms.MenuItem();
			this.menuItemMacroarea = new System.Windows.Forms.MenuItem();
			this.menuItemMacroareaVitto = new System.Windows.Forms.MenuItem();
			this.menuItem36 = new System.Windows.Forms.MenuItem();
			this.menuItem11 = new System.Windows.Forms.MenuItem();
			this.menuItem45 = new System.Windows.Forms.MenuItem();
			this.menuItem14 = new System.Windows.Forms.MenuItem();
			this.menuItem12 = new System.Windows.Forms.MenuItem();
			this.menuItem26 = new System.Windows.Forms.MenuItem();
			this.menuItem13 = new System.Windows.Forms.MenuItem();
			this.menuItem10 = new System.Windows.Forms.MenuItem();
			this.menuItem2 = new System.Windows.Forms.MenuItem();
			this.menuItem15 = new System.Windows.Forms.MenuItem();
			this.mnuConsolida = new System.Windows.Forms.MenuItem();
			this.menuDescrTabelle = new System.Windows.Forms.MenuItem();
			this.menuItem43 = new System.Windows.Forms.MenuItem();
			this.menuVarie = new System.Windows.Forms.MenuItem();
			this.menuItem16 = new System.Windows.Forms.MenuItem();
			this.menuItem17 = new System.Windows.Forms.MenuItem();
			this.menuItem18 = new System.Windows.Forms.MenuItem();
			this.menuItem19 = new System.Windows.Forms.MenuItem();
			this.mnuUpdatedbversion = new System.Windows.Forms.MenuItem();
			this.menuItem27 = new System.Windows.Forms.MenuItem();
			this.mnuInstallazione = new System.Windows.Forms.MenuItem();
			this.menuItem39 = new System.Windows.Forms.MenuItem();
			this.menuItem8 = new System.Windows.Forms.MenuItem();
			this.menuItem9 = new System.Windows.Forms.MenuItem();
			this.menuItem4 = new System.Windows.Forms.MenuItem();
			this.menuItem7 = new System.Windows.Forms.MenuItem();
			this.menuItem59 = new System.Windows.Forms.MenuItem();
			this.menuItem60 = new System.Windows.Forms.MenuItem();
			this.menuItem61 = new System.Windows.Forms.MenuItem();
			this.menuHelp = new System.Windows.Forms.MenuItem();
			this.CreaCodiceTabSistema = new System.Windows.Forms.MenuItem();
			this.menuItem1 = new System.Windows.Forms.MenuItem();
			this.logbtn = new System.Windows.Forms.MenuItem();
			this.menuItem3 = new System.Windows.Forms.MenuItem();
			this.MetaDataToolBar = new System.Windows.Forms.ToolBar();
			this.impostaricerca = new System.Windows.Forms.ToolBarButton();
			this.effettuaricerca = new System.Windows.Forms.ToolBarButton();
			this.inserisci = new System.Windows.Forms.ToolBarButton();
			this.inseriscicopia = new System.Windows.Forms.ToolBarButton();
			this.elimina = new System.Windows.Forms.ToolBarButton();
			this.Salva = new System.Windows.Forms.ToolBarButton();
			this.btnGotoPrev = new System.Windows.Forms.ToolBarButton();
			this.btnGotoNext = new System.Windows.Forms.ToolBarButton();
			this.btnAffianca = new System.Windows.Forms.ToolBarButton();
			this.btnEditNotes = new System.Windows.Forms.ToolBarButton();
			this.brnEmptyList = new System.Windows.Forms.ToolBarButton();
			this.images = new System.Windows.Forms.ImageList(this.components);
			this.SBAR = new System.Windows.Forms.StatusBar();
			this.Operator = new System.Windows.Forms.StatusBarPanel();
			this.currentRole = new System.Windows.Forms.StatusBarPanel();
			this.DataCont = new System.Windows.Forms.StatusBarPanel();
			this.Esercizio = new System.Windows.Forms.StatusBarPanel();
			this.DB = new System.Windows.Forms.StatusBarPanel();
			this.LiveUpdate = new System.Windows.Forms.StatusBarPanel();
			this.DBUpdate = new System.Windows.Forms.StatusBarPanel();
			this.lastLoadTime = new System.Windows.Forms.StatusBarPanel();
			this.FilePicker = new System.Windows.Forms.OpenFileDialog();
			this.FileSaver = new System.Windows.Forms.SaveFileDialog();
			this.Updatetimer1 = new System.Windows.Forms.Timer(this.components);
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.openDir = new System.Windows.Forms.FolderBrowserDialog();
			((System.ComponentModel.ISupportInitialize)(this.Operator)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.currentRole)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.DataCont)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.Esercizio)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.DB)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.LiveUpdate)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.DBUpdate)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lastLoadTime)).BeginInit();
			this.SuspendLayout();
			// 
			// mainMenu1
			// 
			this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem5,
            this.menuItem8,
            this.menuHelp});
			// 
			// menuItem5
			// 
			this.menuItem5.Index = 0;
			this.menuItem5.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.ConnectItem,
            this.DisconnectItem,
            this.ChangeRoleItem,
            this.menuItem40,
            this.mnuIndiceGuida,
            this.menuTeamViewer2,
            this.menuItem37,
            this.menuItem6,
            this.menuItem41,
            this.mnuLocalConfig,
            this.mnuLiveUpdateOnDemand,
            this.mnuCambiaPassword,
            this.mnuCambiaPasswordDipart,
            this.mnuBackup,
            this.menuTicket,
            this.menuItem25,
            this.mnuAbilitaAdmin,
            this.menuAdmin});
			this.menuItem5.ShowShortcut = false;
			this.menuItem5.Text = "File";
			// 
			// ConnectItem
			// 
			this.ConnectItem.Index = 0;
			this.ConnectItem.Text = "Connect";
			this.ConnectItem.Click += new System.EventHandler(this.menuItem2_Click);
			// 
			// DisconnectItem
			// 
			this.DisconnectItem.Enabled = false;
			this.DisconnectItem.Index = 1;
			this.DisconnectItem.Text = "Disconnect";
			this.DisconnectItem.Click += new System.EventHandler(this.menuItem12_Click);
			// 
			// ChangeRoleItem
			// 
			this.ChangeRoleItem.Enabled = false;
			this.ChangeRoleItem.Index = 2;
			this.ChangeRoleItem.Text = "Cambia ruolo";
			this.ChangeRoleItem.Click += new System.EventHandler(this.menuItem16_Click_1);
			// 
			// menuItem40
			// 
			this.menuItem40.Index = 3;
			this.menuItem40.Text = "-";
			// 
			// mnuIndiceGuida
			// 
			this.mnuIndiceGuida.Index = 4;
			this.mnuIndiceGuida.Text = "Guida al programma";
			this.mnuIndiceGuida.Click += new System.EventHandler(this.mnuIndiceGuida_Click);
			// 
			// menuTeamViewer2
			// 
			this.menuTeamViewer2.Index = 5;
			this.menuTeamViewer2.Text = "TeamViewer";
			this.menuTeamViewer2.Click += new System.EventHandler(this.menuTeamViewer2_Click);
			// 
			// menuItem37
			// 
			this.menuItem37.Index = 6;
			this.menuItem37.Text = "-";
			// 
			// menuItem6
			// 
			this.menuItem6.Index = 7;
			this.menuItem6.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mnuCfgTECNICA,
            this.mnuCfgCONTABILE});
			this.menuItem6.Text = "Configurazione";
			// 
			// mnuCfgTECNICA
			// 
			this.mnuCfgTECNICA.Index = 0;
			this.mnuCfgTECNICA.Text = "Configurazione TECNICA";
			this.mnuCfgTECNICA.Click += new System.EventHandler(this.mnuCfgTECNICA_Click);
			// 
			// mnuCfgCONTABILE
			// 
			this.mnuCfgCONTABILE.Index = 1;
			this.mnuCfgCONTABILE.Text = "Configurazione CONTABILE";
			this.mnuCfgCONTABILE.Click += new System.EventHandler(this.mnuCfgCONTABILE_Click);
			// 
			// menuItem41
			// 
			this.menuItem41.Index = 8;
			this.menuItem41.Text = "Personalizza colori";
			this.menuItem41.Click += new System.EventHandler(this.menuItem41_Click);
			// 
			// mnuLocalConfig
			// 
			this.mnuLocalConfig.Index = 9;
			this.mnuLocalConfig.Text = "Configurazione locale";
			this.mnuLocalConfig.Click += new System.EventHandler(this.menuItem25_Click);
			// 
			// mnuLiveUpdateOnDemand
			// 
			this.mnuLiveUpdateOnDemand.Index = 10;
			this.mnuLiveUpdateOnDemand.Text = "Aggiornamenti a richiesta";
			this.mnuLiveUpdateOnDemand.Click += new System.EventHandler(this.mnuLiveUpdateOnDemand_Click);
			// 
			// mnuCambiaPassword
			// 
			this.mnuCambiaPassword.Index = 11;
			this.mnuCambiaPassword.Text = "Cambia Password dell\'utente";
			this.mnuCambiaPassword.Click += new System.EventHandler(this.mnuCambiaPassword_Click);
			// 
			// mnuCambiaPasswordDipart
			// 
			this.mnuCambiaPasswordDipart.Index = 12;
			this.mnuCambiaPasswordDipart.Text = "Cambia Password del dipartimento";
			this.mnuCambiaPasswordDipart.Click += new System.EventHandler(this.mnuCambiaPasswordDipart_Click);
			// 
			// mnuBackup
			// 
			this.mnuBackup.Index = 13;
			this.mnuBackup.Text = "Backup / Restore Database";
			this.mnuBackup.Click += new System.EventHandler(this.mnuBackup_Click);
			// 
			// menuTicket
			// 
			this.menuTicket.Index = 14;
			this.menuTicket.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem42,
            this.menuItem44,
            this.menuTeamViewer});
			this.menuTicket.Text = "Ticket";
			// 
			// menuItem42
			// 
			this.menuItem42.Index = 0;
			this.menuItem42.Text = "Registrazione all\'Helpdesk";
			this.menuItem42.Click += new System.EventHandler(this.menuItem42_Click);
			// 
			// menuItem44
			// 
			this.menuItem44.Index = 1;
			this.menuItem44.Text = "Storico ticket";
			this.menuItem44.Click += new System.EventHandler(this.menuItem44_Click);
			// 
			// menuTeamViewer
			// 
			this.menuTeamViewer.Index = 2;
			this.menuTeamViewer.Text = "TeamViewer";
			this.menuTeamViewer.Click += new System.EventHandler(this.menuTeamViewer_Click);
			// 
			// menuItem25
			// 
			this.menuItem25.Index = 15;
			this.menuItem25.Text = "-";
			// 
			// mnuAbilitaAdmin
			// 
			this.mnuAbilitaAdmin.Index = 16;
			this.mnuAbilitaAdmin.Text = "Abilita Admin";
			this.mnuAbilitaAdmin.Click += new System.EventHandler(this.mnuAbilitaAdmin_Click);
			// 
			// menuAdmin
			// 
			this.menuAdmin.Index = 17;
			this.menuAdmin.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem28,
            this.mnuAzzeraVerSW,
            this.mnuCheckDll,
            this.mnuConfignotifiche,
            this.mnuBigAdmin,
            this.menuDescrTabelle,
            this.menuItem43,
            this.menuVarie,
            this.menuItem39});
			this.menuAdmin.Text = "Admin";
			// 
			// menuItem28
			// 
			this.menuItem28.Index = 0;
			this.menuItem28.Text = "Azzera versione report (scarica di nuovo tutti i report)";
			this.menuItem28.Click += new System.EventHandler(this.menuItem28_Click);
			// 
			// mnuAzzeraVerSW
			// 
			this.mnuAzzeraVerSW.Index = 1;
			this.mnuAzzeraVerSW.Text = "Azzera versione software (scarica di nuovo tutte le DLL)";
			this.mnuAzzeraVerSW.Click += new System.EventHandler(this.mnuAzzeraVerSW_Click);
			// 
			// mnuCheckDll
			// 
			this.mnuCheckDll.Index = 2;
			this.mnuCheckDll.Text = "Verifica coerenza DLL (per problemi di proxy etc.)";
			this.mnuCheckDll.Click += new System.EventHandler(this.mnuCheckDll_Click);
			// 
			// mnuConfignotifiche
			// 
			this.mnuConfignotifiche.Index = 3;
			this.mnuConfignotifiche.Text = "Configura Notifiche";
			this.mnuConfignotifiche.Click += new System.EventHandler(this.mnuConfignotifiche_Click);
			// 
			// mnuBigAdmin
			// 
			this.mnuBigAdmin.Index = 4;
			this.mnuBigAdmin.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mnuGenereLiveUpdate,
            this.mnuLiveUpdateSync,
            this.mnuCreaStruttura,
            this.menuItem38,
            this.mnuGenSQLTabella,
            this.mnuGenRelDir,
            this.mnuGenRelIndir,
            this.menuItem24,
            this.mnuComprimi,
            this.menuItem20,
            this.mnuEstraiFile,
            this.menuItem22,
            this.menuItem35,
            this.menuItem23,
            this.menuItem21,
            this.menuItem29,
            this.menuItem30,
            this.menuItem31,
            this.menuItemConvert,
            this.menuItemMacroarea,
            this.menuItemMacroareaVitto,
            this.menuItem36,
            this.menuItem11,
            this.menuItem45});
			this.mnuBigAdmin.Text = "Non Usare (riservate al settore SVILUPPO)";
			// 
			// mnuGenereLiveUpdate
			// 
			this.mnuGenereLiveUpdate.Index = 0;
			this.mnuGenereLiveUpdate.Text = "LiveUpdate - Generazione";
			this.mnuGenereLiveUpdate.Click += new System.EventHandler(this.mnuGenereLiveUpdate_Click);
			// 
			// mnuLiveUpdateSync
			// 
			this.mnuLiveUpdateSync.Index = 1;
			this.mnuLiveUpdateSync.Text = "LiveUpdate - Sincronizza server";
			this.mnuLiveUpdateSync.Click += new System.EventHandler(this.mnuLiveUpdateSync_Click);
			// 
			// mnuCreaStruttura
			// 
			this.mnuCreaStruttura.Index = 2;
			this.mnuCreaStruttura.Text = "LiveUpdate - Crea struttura";
			this.mnuCreaStruttura.Click += new System.EventHandler(this.mnuCreaStruttura_Click);
			// 
			// menuItem38
			// 
			this.menuItem38.Index = 3;
			this.menuItem38.Text = "-";
			// 
			// mnuGenSQLTabella
			// 
			this.mnuGenSQLTabella.Index = 4;
			this.mnuGenSQLTabella.Text = "Generazione script SQL per tabella";
			this.mnuGenSQLTabella.Click += new System.EventHandler(this.mnuGenSQLTabella_Click);
			// 
			// mnuGenRelDir
			// 
			this.mnuGenRelDir.Index = 5;
			this.mnuGenRelDir.Text = "Generazione relazioni dirette";
			this.mnuGenRelDir.Click += new System.EventHandler(this.mnuGenRelDir_Click);
			// 
			// mnuGenRelIndir
			// 
			this.mnuGenRelIndir.Index = 6;
			this.mnuGenRelIndir.Text = "Generazione relazioni indirette";
			this.mnuGenRelIndir.Click += new System.EventHandler(this.mnuGenRelIndir_Click);
			// 
			// menuItem24
			// 
			this.menuItem24.Index = 7;
			this.menuItem24.Text = "Tool Aggiorna Comuni";
			this.menuItem24.Click += new System.EventHandler(this.menuItem24_Click);
			// 
			// mnuComprimi
			// 
			this.mnuComprimi.Index = 8;
			this.mnuComprimi.Text = "Comprimi tutti i file";
			this.mnuComprimi.Click += new System.EventHandler(this.mnuComprimi_Click);
			// 
			// menuItem20
			// 
			this.menuItem20.Index = 9;
			this.menuItem20.Text = "Merge Files";
			this.menuItem20.Click += new System.EventHandler(this.menuItem20_Click_1);
			// 
			// mnuEstraiFile
			// 
			this.mnuEstraiFile.Index = 10;
			this.mnuEstraiFile.Text = "Estrai file";
			this.mnuEstraiFile.Click += new System.EventHandler(this.mnuEstraiFile_Click);
			// 
			// menuItem22
			// 
			this.menuItem22.Index = 11;
			this.menuItem22.Text = "Output Viewer";
			this.menuItem22.Click += new System.EventHandler(this.menuItem22_Click);
			// 
			// menuItem35
			// 
			this.menuItem35.Index = 12;
			this.menuItem35.Text = "Diagnostica";
			this.menuItem35.Click += new System.EventHandler(this.menuItem35_Click);
			// 
			// menuItem23
			// 
			this.menuItem23.Index = 13;
			this.menuItem23.Text = "fix FileInfo";
			this.menuItem23.Click += new System.EventHandler(this.menuItem23_Click);
			// 
			// menuItem21
			// 
			this.menuItem21.Index = 14;
			this.menuItem21.Text = "Check Rule Messages";
			this.menuItem21.Click += new System.EventHandler(this.menuItem21_Click_1);
			// 
			// menuItem29
			// 
			this.menuItem29.Index = 15;
			this.menuItem29.Text = "-";
			// 
			// menuItem30
			// 
			this.menuItem30.Index = 16;
			this.menuItem30.Text = "Applica sicurezza su tutti i dipartimenti";
			this.menuItem30.Click += new System.EventHandler(this.menuItem30_Click);
			// 
			// menuItem31
			// 
			this.menuItem31.Index = 17;
			this.menuItem31.Text = "Trasferisci organigramma";
			this.menuItem31.Click += new System.EventHandler(this.menuItem31_Click_1);
			// 
			// menuItemConvert
			// 
			this.menuItemConvert.Index = 18;
			this.menuItemConvert.Text = "Conversione Forms Windows=>Web";
			this.menuItemConvert.Click += new System.EventHandler(this.menuItemConvert_Click);
			// 
			// menuItemMacroarea
			// 
			this.menuItemMacroarea.Index = 19;
			this.menuItemMacroarea.Text = "Macroarea Rimborsi forfettari";
			this.menuItemMacroarea.Click += new System.EventHandler(this.menuItemMacroarea_Click);
			// 
			// menuItemMacroareaVitto
			// 
			this.menuItemMacroareaVitto.Index = 20;
			this.menuItemMacroareaVitto.Text = "Macroarea Vitto";
			this.menuItemMacroareaVitto.Click += new System.EventHandler(this.menuItemMacroareaVitto_Click);
			// 
			// menuItem36
			// 
			this.menuItem36.Index = 21;
			this.menuItem36.Text = "Unifica dipartimenti";
			this.menuItem36.Click += new System.EventHandler(this.menuItem36_Click);
			// 
			// menuItem11
			// 
			this.menuItem11.Index = 22;
			this.menuItem11.Text = "Lancia script su tutti i dipartimenti";
			this.menuItem11.Click += new System.EventHandler(this.LanciaScriptTuttiDip);
			// 
			// menuItem45
			// 
			this.menuItem45.Index = 23;
			this.menuItem45.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem14,
            this.menuItem12,
            this.menuItem26,
            this.menuItem13,
            this.menuItem10,
            this.menuItem2,
            this.menuItem15,
            this.mnuConsolida});
			this.menuItem45.Text = "varie";
			// 
			// menuItem14
			// 
			this.menuItem14.Index = 0;
			this.menuItem14.Text = "GetSys()";
			this.menuItem14.Click += new System.EventHandler(this.menuItem14_Click);
			// 
			// menuItem12
			// 
			this.menuItem12.Index = 1;
			this.menuItem12.Text = "Riassegna utente al db";
			this.menuItem12.Click += new System.EventHandler(this.menuItem12_Click_2);
			// 
			// menuItem26
			// 
			this.menuItem26.Index = 2;
			this.menuItem26.Text = "Migra DB Campus ";
			this.menuItem26.Click += new System.EventHandler(this.menuItem26_Click);
			// 
			// menuItem13
			// 
			this.menuItem13.Index = 3;
			this.menuItem13.Text = "TryException()";
			this.menuItem13.Click += new System.EventHandler(this.menuItem13_Click_1);
			// 
			// menuItem10
			// 
			this.menuItem10.Index = 4;
			this.menuItem10.Text = "Disabilita il Prepare (RENDE LE SELECT LEGGIBILI)";
			this.menuItem10.Click += new System.EventHandler(this.menuItem10_Click);
			// 
			// menuItem2
			// 
			this.menuItem2.Index = 5;
			this.menuItem2.Text = "Abilita il Prepare delle  SELECT SQL (li rende illeggibili ma efficienti)";
			this.menuItem2.Click += new System.EventHandler(this.menuItem2_Click_2);
			// 
			// menuItem15
			// 
			this.menuItem15.Index = 6;
			this.menuItem15.Text = "Imposta oggetti del patrimonio come trasmessi";
			this.menuItem15.Click += new System.EventHandler(this.menuItem15_Click_1);
			// 
			// mnuConsolida
			// 
			this.mnuConsolida.Index = 7;
			this.mnuConsolida.Text = "Consolidamento DataBase";
			this.mnuConsolida.Click += new System.EventHandler(this.mnuConsolida_Click);
			// 
			// menuDescrTabelle
			// 
			this.menuDescrTabelle.Index = 5;
			this.menuDescrTabelle.Text = "Descrizione tabelle";
			this.menuDescrTabelle.Click += new System.EventHandler(this.menuDescrTabelle_Click);
			// 
			// menuItem43
			// 
			this.menuItem43.Index = 6;
			this.menuItem43.Text = "Descrizione colonne";
			this.menuItem43.Click += new System.EventHandler(this.menuItem43_Click);
			// 
			// menuVarie
			// 
			this.menuVarie.Index = 7;
			this.menuVarie.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem16,
            this.mnuUpdatedbversion,
            this.menuItem27,
            this.mnuInstallazione});
			this.menuVarie.Text = "varie";
			// 
			// menuItem16
			// 
			this.menuItem16.Index = 0;
			this.menuItem16.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem17,
            this.menuItem18,
            this.menuItem19});
			this.menuItem16.Text = "Gestione della Sicurezza";
			// 
			// menuItem17
			// 
			this.menuItem17.Index = 0;
			this.menuItem17.Text = "Funzioni di Restrizione";
			this.menuItem17.Click += new System.EventHandler(this.menuItem17_Click);
			// 
			// menuItem18
			// 
			this.menuItem18.Index = 1;
			this.menuItem18.Text = "Variabili di Sicurezza";
			this.menuItem18.Click += new System.EventHandler(this.menuItem18_Click);
			// 
			// menuItem19
			// 
			this.menuItem19.Index = 2;
			this.menuItem19.Text = "Condizioni di Sicurezza";
			this.menuItem19.Click += new System.EventHandler(this.menuItem19_Click_1);
			// 
			// mnuUpdatedbversion
			// 
			this.mnuUpdatedbversion.Index = 1;
			this.mnuUpdatedbversion.Text = "Versione Database";
			this.mnuUpdatedbversion.Click += new System.EventHandler(this.mnuUpdatedbversion_Click);
			// 
			// menuItem27
			// 
			this.menuItem27.Index = 2;
			this.menuItem27.Text = "Configurazione avvisi";
			this.menuItem27.Click += new System.EventHandler(this.menuItem27_Click_1);
			// 
			// mnuInstallazione
			// 
			this.mnuInstallazione.Index = 3;
			this.mnuInstallazione.Text = "Installazione del software";
			this.mnuInstallazione.Click += new System.EventHandler(this.mnuInstallazione_Click);
			// 
			// menuItem39
			// 
			this.menuItem39.Index = 8;
			this.menuItem39.Text = "Importa utenti database";
			this.menuItem39.Click += new System.EventHandler(this.menuItem39_Click);
			// 
			// menuItem8
			// 
			this.menuItem8.Index = 1;
			this.menuItem8.MdiList = true;
			this.menuItem8.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem9,
            this.menuItem4,
            this.menuItem7});
			this.menuItem8.Text = "Finestre";
			// 
			// menuItem9
			// 
			this.menuItem9.Index = 0;
			this.menuItem9.Text = "Chiudi tutte";
			this.menuItem9.Click += new System.EventHandler(this.menuItem9_Click);
			// 
			// menuItem4
			// 
			this.menuItem4.Index = 1;
			this.menuItem4.Text = "Chiudi";
			this.menuItem4.Click += new System.EventHandler(this.menuItem4_Click_1);
			// 
			// menuItem7
			// 
			this.menuItem7.Index = 2;
			this.menuItem7.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem59,
            this.menuItem60,
            this.menuItem61});
			this.menuItem7.Text = "Disponi";
			// 
			// menuItem59
			// 
			this.menuItem59.Index = 0;
			this.menuItem59.Text = "Allinea Orizzontale";
			this.menuItem59.Click += new System.EventHandler(this.menuItem59_Click);
			// 
			// menuItem60
			// 
			this.menuItem60.Index = 1;
			this.menuItem60.Text = "Allinea Verticale";
			this.menuItem60.Click += new System.EventHandler(this.menuItem60_Click);
			// 
			// menuItem61
			// 
			this.menuItem61.Index = 2;
			this.menuItem61.Text = "Cascata";
			this.menuItem61.Click += new System.EventHandler(this.menuItem61_Click);
			// 
			// menuHelp
			// 
			this.menuHelp.Index = 2;
			this.menuHelp.MergeOrder = 1000;
			this.menuHelp.Text = "?";
			this.menuHelp.Click += new System.EventHandler(this.menuHelp_Click);
			// 
			// CreaCodiceTabSistema
			// 
			this.CreaCodiceTabSistema.Index = -1;
			this.CreaCodiceTabSistema.Text = "";
			// 
			// menuItem1
			// 
			this.menuItem1.Index = -1;
			this.menuItem1.Text = "";
			// 
			// logbtn
			// 
			this.logbtn.Index = -1;
			this.logbtn.Text = "";
			this.logbtn.Click += new System.EventHandler(this.menuItem2_Click);
			// 
			// menuItem3
			// 
			this.menuItem3.Index = -1;
			this.menuItem3.Text = "";
			// 
			// MetaDataToolBar
			// 
			this.MetaDataToolBar.Appearance = System.Windows.Forms.ToolBarAppearance.Flat;
			this.MetaDataToolBar.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
            this.impostaricerca,
            this.effettuaricerca,
            this.inserisci,
            this.inseriscicopia,
            this.elimina,
            this.Salva,
            this.btnGotoPrev,
            this.btnGotoNext,
            this.btnAffianca,
            this.btnEditNotes,
            this.brnEmptyList});
			this.MetaDataToolBar.ButtonSize = new System.Drawing.Size(32, 32);
			this.MetaDataToolBar.DropDownArrows = true;
			this.MetaDataToolBar.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.MetaDataToolBar.ImageList = this.images;
			this.MetaDataToolBar.Location = new System.Drawing.Point(0, 0);
			this.MetaDataToolBar.Name = "MetaDataToolBar";
			this.MetaDataToolBar.ShowToolTips = true;
			this.MetaDataToolBar.Size = new System.Drawing.Size(992, 59);
			this.MetaDataToolBar.TabIndex = 1;
			this.MetaDataToolBar.Tag = "";
			this.MetaDataToolBar.Visible = false;
			this.MetaDataToolBar.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.MetaDataToolBar_ButtonClick);
			// 
			// impostaricerca
			// 
			this.impostaricerca.ImageKey = "view.png";
			this.impostaricerca.Name = "impostaricerca";
			this.impostaricerca.Tag = "mainsetsearch";
			this.impostaricerca.Text = "Imposta ricerca";
			this.impostaricerca.ToolTipText = "Imposta una nuova ricerca";
			// 
			// effettuaricerca
			// 
			this.effettuaricerca.ImageKey = "find.png";
			this.effettuaricerca.Name = "effettuaricerca";
			this.effettuaricerca.Tag = "maindosearch";
			this.effettuaricerca.Text = "Effettua ricerca";
			this.effettuaricerca.ToolTipText = "Cerca in base ai dati immessi";
			// 
			// inserisci
			// 
			this.inserisci.ImageKey = "add2.png";
			this.inserisci.Name = "inserisci";
			this.inserisci.Tag = "maininsert";
			this.inserisci.Text = "Inserisci";
			this.inserisci.ToolTipText = "Inserisci un nuovo elemento";
			// 
			// inseriscicopia
			// 
			this.inseriscicopia.ImageKey = "windows.png";
			this.inseriscicopia.Name = "inseriscicopia";
			this.inseriscicopia.Tag = "maininsertcopy";
			this.inseriscicopia.Text = "Inserisci copia";
			this.inseriscicopia.ToolTipText = "Inserisci un nuovo elemento copiando i dati da quello attuale";
			// 
			// elimina
			// 
			this.elimina.ImageKey = "delete2.png";
			this.elimina.Name = "elimina";
			this.elimina.Tag = "maindelete";
			this.elimina.Text = "Elimina";
			this.elimina.ToolTipText = "Elimina l\'elemento selezionato";
			// 
			// Salva
			// 
			this.Salva.ImageKey = "floppy_disk.png";
			this.Salva.Name = "Salva";
			this.Salva.Tag = "mainsave";
			this.Salva.Text = "Salva";
			this.Salva.ToolTipText = "Salva le modifiche effettuate";
			// 
			// btnGotoPrev
			// 
			this.btnGotoPrev.ImageKey = "arrow2_left.png";
			this.btnGotoPrev.Name = "btnGotoPrev";
			this.btnGotoPrev.Tag = "gotoprev";
			this.btnGotoPrev.Text = "Precedente";
			this.btnGotoPrev.ToolTipText = "Vai al precedente";
			// 
			// btnGotoNext
			// 
			this.btnGotoNext.ImageKey = "arrow2_right.png";
			this.btnGotoNext.Name = "btnGotoNext";
			this.btnGotoNext.Tag = "gotonext";
			this.btnGotoNext.Text = "Successivo";
			this.btnGotoNext.ToolTipText = "Vai al successivo";
			// 
			// btnAffianca
			// 
			this.btnAffianca.ImageKey = "window_split_ver.png";
			this.btnAffianca.Name = "btnAffianca";
			this.btnAffianca.Tag = "horizwin";
			this.btnAffianca.Text = "Affianca";
			this.btnAffianca.ToolTipText = "Affianca in verticale";
			// 
			// btnEditNotes
			// 
			this.btnEditNotes.ImageKey = "edit.png";
			this.btnEditNotes.Name = "btnEditNotes";
			this.btnEditNotes.Tag = "editnotes";
			this.btnEditNotes.Text = "Appunti";
			this.btnEditNotes.ToolTipText = "Modifica gli appunti associati all\'oggetto selezionato";
			// 
			// brnEmptyList
			// 
			this.brnEmptyList.ImageKey = "document_notebook.png";
			this.brnEmptyList.Name = "brnEmptyList";
			this.brnEmptyList.Tag = "emptylist";
			this.brnEmptyList.Text = "Crea elenco";
			this.brnEmptyList.ToolTipText = "Crea nuovo elenco";
			// 
			// images
			// 
			this.images.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("images.ImageStream")));
			this.images.TransparentColor = System.Drawing.Color.Transparent;
			this.images.Images.SetKeyName(0, "add2.png");
			this.images.Images.SetKeyName(1, "arrow2_left.png");
			this.images.Images.SetKeyName(2, "arrow2_right.png");
			this.images.Images.SetKeyName(3, "delete2.png");
			this.images.Images.SetKeyName(4, "document_notebook.png");
			this.images.Images.SetKeyName(5, "edit.png");
			this.images.Images.SetKeyName(6, "error.png");
			this.images.Images.SetKeyName(7, "find.png");
			this.images.Images.SetKeyName(8, "floppy_disk.png");
			this.images.Images.SetKeyName(9, "garbage.png");
			this.images.Images.SetKeyName(10, "ok.png");
			this.images.Images.SetKeyName(11, "refresh.png");
			this.images.Images.SetKeyName(12, "sign_warning.png");
			this.images.Images.SetKeyName(13, "view.png");
			this.images.Images.SetKeyName(14, "window_split_hor.png");
			this.images.Images.SetKeyName(15, "window_split_ver.png");
			this.images.Images.SetKeyName(16, "windows.png");
			// 
			// SBAR
			// 
			this.SBAR.Location = new System.Drawing.Point(0, 651);
			this.SBAR.Name = "SBAR";
			this.SBAR.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
            this.Operator,
            this.currentRole,
            this.DataCont,
            this.Esercizio,
            this.DB,
            this.LiveUpdate,
            this.DBUpdate,
            this.lastLoadTime});
			this.SBAR.ShowPanels = true;
			this.SBAR.Size = new System.Drawing.Size(992, 22);
			this.SBAR.TabIndex = 2;
			this.SBAR.PanelClick += new System.Windows.Forms.StatusBarPanelClickEventHandler(this.SBAR_PanelClick);
			// 
			// Operator
			// 
			this.Operator.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Contents;
			this.Operator.Name = "Operator";
			this.Operator.ToolTipText = "Operatore";
			this.Operator.Width = 10;
			// 
			// currentRole
			// 
			this.currentRole.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Contents;
			this.currentRole.Name = "currentRole";
			this.currentRole.Width = 10;
			// 
			// DataCont
			// 
			this.DataCont.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Contents;
			this.DataCont.Name = "DataCont";
			this.DataCont.ToolTipText = "Data Contabile";
			this.DataCont.Width = 10;
			// 
			// Esercizio
			// 
			this.Esercizio.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Contents;
			this.Esercizio.Name = "Esercizio";
			this.Esercizio.ToolTipText = "Esercizio";
			this.Esercizio.Width = 10;
			// 
			// DB
			// 
			this.DB.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Contents;
			this.DB.Name = "DB";
			this.DB.ToolTipText = "DataBase";
			this.DB.Width = 10;
			// 
			// LiveUpdate
			// 
			this.LiveUpdate.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Contents;
			this.LiveUpdate.Name = "LiveUpdate";
			this.LiveUpdate.Width = 10;
			// 
			// DBUpdate
			// 
			this.DBUpdate.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Contents;
			this.DBUpdate.Name = "DBUpdate";
			this.DBUpdate.Width = 10;
			// 
			// lastLoadTime
			// 
			this.lastLoadTime.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
			this.lastLoadTime.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Contents;
			this.lastLoadTime.Name = "lastLoadTime";
			this.lastLoadTime.Width = 10;
			// 
			// FilePicker
			// 
			this.FilePicker.RestoreDirectory = true;
			this.FilePicker.Title = "Selezione file";
			// 
			// FileSaver
			// 
			this.FileSaver.FileName = "doc1";
			this.FileSaver.RestoreDirectory = true;
			this.FileSaver.Title = "Salva su File";
			// 
			// Updatetimer1
			// 
			this.Updatetimer1.Enabled = true;
			this.Updatetimer1.Interval = 3600000;
			this.Updatetimer1.Tick += new System.EventHandler(this.Updatetimer1_Tick);
			// 
			// timer1
			// 
			this.timer1.Enabled = true;
			this.timer1.Interval = 5000;
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// openDir
			// 
			this.openDir.ShowNewFolderButton = false;
			// 
			// frmMain
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.BackColor = System.Drawing.SystemColors.Control;
			this.ClientSize = new System.Drawing.Size(992, 673);
			this.Controls.Add(this.MetaDataToolBar);
			this.Controls.Add(this.SBAR);
			this.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.IsMdiContainer = true;
			this.Menu = this.mainMenu1;
			this.Name = "frmMain";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Tag = "";
			this.Text = "Easy - Gestione Contabile Integrata";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Activated += new System.EventHandler(this.frmMain_Activated);
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmMain_FormClosed);
			((System.ComponentModel.ISupportInitialize)(this.Operator)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.currentRole)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.DataCont)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.Esercizio)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.DB)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.LiveUpdate)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.DBUpdate)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lastLoadTime)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }


    
        #endregion

        /// <summary>
        /// Imposta il menu in base alla tabella menu e al parametro in ingresso
        /// </summary>
        /// <param name="ShowAdminMenu"></param>
        void SetMenu(bool ShowAdminMenu,bool **********) {
            if (this.IsDisposed) return;

            if (MyDataAccess != null) {
                if (MyDataAccess.LocalToDB && !MyDataAccess.SSPI) {
                    mnuCambiaPassword.Enabled = true;
                }
                else {
                    mnuCambiaPassword.Enabled = false;
                }
                menuTicket.Visible = true;
                MainMenuMaker = new menuMaker(MyDataAccess, this, Dispatcher);
                int hmenu = metaprofiler.StartTimer("CreateMenu()");
                MainMenuMaker.CreateMenu(mainMenu1, "menu", null);
                metaprofiler.StopTimer(hmenu);
                //menuMenu.Enabled = true;
                menuVarie.Enabled = !********** & ShowAdminMenu;
                mnuBigAdmin.Enabled = !********** & ShowAdminMenu;
                //ReadMenu.Enabled = true;
                menuAdmin.Enabled = ShowAdminMenu;
                if (MyDataAccess.Security.GetSys("IsSystemAdmin")!=null)
                    mnuCambiaPasswordDipart.Enabled = (bool)MyDataAccess.Security.GetSys("IsSystemAdmin");
                else
                    mnuCambiaPasswordDipart.Enabled = false;
                //mnuCfgCONTABILE.Enabled = false;
                mnuCfgTECNICA.Enabled = false;
                return;
            }
            menuTicket.Visible = false;
            menuVarie.Enabled = false;
            mnuBigAdmin.Enabled = false;
            //if MyDataAccess = null:
            mnuCambiaPasswordDipart.Enabled = false;
            mnuLiveUpdateOnDemand.Enabled = false;
            //menuMenu.Enabled = false;
            menuAdmin.Enabled = false;
            mnuCambiaPassword.Enabled = false;
            mnuCfgCONTABILE.Enabled = false;
            mnuCfgTECNICA.Enabled = true;

            if (MainMenuMaker != null) {
                int cmenu = metaprofiler.StartTimer("ClearMenu()");
                MainMenuMaker.ClearMenu(mainMenu1);
                MainMenuMaker = null;
                metaprofiler.StopTimer(cmenu);
            }
        }
        /// <summary>
        /// Disabilita una voce di menu. Validi valori per menutext sono  Entrate/Spese/Bilancio/Missioni
        /// </summary>
        /// <param name="code"></param>
        void disableMenu(string menutext) {
            int cmenu = metaprofiler.StartTimer("DisableMenu()");
            foreach (MenuItem MI in mainMenu1.MenuItems) {
                if (MI.Text == menutext) {
                    MI.Enabled = false;
                    break;
                }
            }
            metaprofiler.StopTimer(cmenu);
        }
        void enableMenu(string menutext) {
            int cmenu = metaprofiler.StartTimer("EnableMenu()");
            foreach (MenuItem MI in mainMenu1.MenuItems) {
                if (MI.Text == menutext) {
                    MI.Enabled = true;
                    break;
                }
            }
            metaprofiler.StopTimer(cmenu);
        }

        bool MessageDisplayed = false;
        /// <summary>
        /// Disabilita alcune parti del menu se non ci sono le configurazioni corrispondenti. 
        /// Se l'esercizio è chiuso imposta la connessione a 'read-only'
        /// </summary>
        /// <param name="filteresercizio"></param>
        private void controllaConfigurazioni(string filteresercizio) {
            //bool BilancioEnabled=true;
            var tConfig = MyDataAccess.CreateTableByName("config", "*");
            MyDataAccess.RUN_SELECT_INTO_TABLE(tConfig, null, filteresercizio, null, true);
            if (tConfig.Rows.Count == 0 ) {
                if (MessageDisplayed==false)
                    MetaFactory.factory.getSingleton<IMessageShower>().Show("NON ESISTE ALCUNA CONFIGURAZIONE PER L'ESERCIZIO CORRENTE!", "Attenzione",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                disableMenu("Compensi");
                disableMenu("Entrate");
                disableMenu("Spese");
                disableMenu("Cespiti");
                disableMenu("Bilancio");
                disableMenu("Tesoriere");

                MessageDisplayed = true;
                return;
            }

            var rConfig = tConfig.Rows[0];

            bool SpeseEntrateEnabled = true;
            bool abilitaBilancio = false;
            string[] fieldBilancio = new string[] { "appropriationphasecode", "assessmentphasecode" };
            foreach (string colName in fieldBilancio) {
                if (rConfig[colName] == DBNull.Value) continue;
                abilitaBilancio = true;
            }
            if (!abilitaBilancio) {
                MetaFactory.factory.getSingleton<IMessageShower>().Show("La configurazione del BILANCIO non è stata definita per l'esercizio corrente. " +
                    "Non sarà possibile accedere ai menu Bilancio/Entrate/Spese", "Attenzione",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                disableMenu("Bilancio");
                //BilancioEnabled=false;
                SpeseEntrateEnabled = false;
            }
            else
                enableMenu("Bilancio");

            bool abilitaMiss = false;
            string [] fieldMissione = new string [] {"idfinexpense", "idclawback", "foreignhours"};
            foreach(string colName in fieldMissione) {
                if (rConfig[colName] == DBNull.Value) continue;
                abilitaMiss = true;
            }

            if (!abilitaMiss) {
                //MetaFactory.factory.getSingleton<IMessageShower>().Show("La configurazione delle MISSIONI non è stata definita per l'esercizio corrente!", "Attenzione",
                //    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                disableMenu("Compensi");                
            }
            else {
                enableMenu("Compensi");
            }

            bool abilitaEntrata = false;
            string[] fieldEntrata = new string[] { "proceeds_finlevel", "income_expiringdays", "proceeds_flagautoprintdate",
            "flagautoproceeds", "flagfruitful"};
            foreach (string colName in fieldEntrata) {
                if (rConfig[colName] == DBNull.Value) continue;
                abilitaEntrata = true;
            }

            if ((SpeseEntrateEnabled == true) && (!abilitaEntrata)) {
                MetaFactory.factory.getSingleton<IMessageShower>().Show("La configurazione delle ENTRATE non è stata definita per l'esercizio corrente. " +
                    "Non sarà possibile accedere ai menu Entrate/Spese", "Attenzione",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                SpeseEntrateEnabled = false;
            }

            bool abilitaSpesa = false;
            string[] fieldSpesa = new string[] { "payment_finlevel", "expense_expiringdays", "payment_flagautoprintdate",
            "flagautopayment", "taxvaliditykind"};
            foreach (string colName in fieldSpesa) {
                if (rConfig[colName] == DBNull.Value) continue;
                abilitaSpesa = true;
            }

            if ((SpeseEntrateEnabled == true) && (!abilitaSpesa)) {
                MetaFactory.factory.getSingleton<IMessageShower>().Show("La configurazione delle SPESE non è stata definita per l'esercizio corrente. " +
                        "Non sarà possibile accedere ai menu Entrate/Spese", "Attenzione",
                                       MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                SpeseEntrateEnabled = false;
            }

            if (SpeseEntrateEnabled) {
                enableMenu("Entrate");
                enableMenu("Spese");
            }
            else {
                disableMenu("Entrate");
                disableMenu("Spese");
            }

            bool abilitaPatrimonio = false;
            string[] fieldPatrimonio = new string[] { "linktoinvoice", "asset_flagrestart", "assetload_flag"};
            foreach (string colName in fieldPatrimonio) {
                if (rConfig[colName] == DBNull.Value) continue;
                abilitaPatrimonio = true;
            }

            if (!abilitaPatrimonio) {
                //MetaFactory.factory.getSingleton<IMessageShower>().Show("La configurazione del PATRIMONIO non è stata definita per l'esercizio corrente!", "Attenzione",
                //	MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                disableMenu("Cespiti");
            }
            else
                enableMenu("Cespiti");

        }


        bool verifyQuickAdmin() {
            //IsSystemAdmin manage_prestazioni FlagMenuAdmin
            if (!File.Exists(AppDomain.CurrentDomain.BaseDirectory+"quickadmin.sys")) return false;
            string S = File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + "quickadmin.sys");
            if (S == "Gaetano|Lazzo") return true;
            return false;

        }
        private bool connecting = false;
        void connect() {

            if (!Disconnect()) return;
            DialogResult res;
            frmEasyConnect frm = null;
            var Measure = new crono(null);
            try {
                frm = new frmEasyConnect();
                frm.Tag = argCopy;
                argCopy = null;
                signalCreateForm(frm,null);
                res = frm.ShowDialog();
            }
            catch (Exception e) {
                return;
            }

            if (res != DialogResult.OK) {
				frm.Dispose();
	            return;
            }
            long len = Measure.GetDuration();

            connecting = true;
            MyDataAccess = frm.MyDataAccess;

            if (MyDataAccess == null || MyDataAccess.openError) {
                connecting = false;
                frm.Dispose();
                return;
            }
            Dispatcher = new Meta_EasyDispatcher(MyDataAccess as IDataAccess);
            this.attachInstance(Dispatcher, typeof(IMetaDataDispatcher));
            this.attachInstance(MyDataAccess, typeof(IDataAccess));
            this.attachInstance(MyDataAccess.Security, typeof(ISecurity));
            this.attachInstance(ErrorLogger.Logger, typeof(IErrorLogger));

            QueryHelper QHS = MyDataAccess.GetQueryHelper();

            Operator.Text = $"{MyDataAccess.externalUser} su {Dispatcher.security.GetSys("userdb")}";
            DB.Text = $"{Dispatcher.security.GetSys("database")} su {Dispatcher.GetSys("server")}";
            QueryCreator.MarkEvent($"Connesso come {Operator.Text} sul db {DB.Text}");
            string filterGRP = QHS.AppAnd(QHS.IsNull("stop"), QHS.CmpEq("idparam", "DenominazioneDipartimento"));
            DataTable generalReportParameterTable =
                MyDataAccess.RUN_SELECT("generalreportparameter", "paramvalue", null, filterGRP, null, true);
            if (generalReportParameterTable != null && generalReportParameterTable.Rows.Count > 0) {
                this.Text += " ( " + generalReportParameterTable.Rows[0]["paramvalue"] + " )";
            }

            var security = MyDataAccess.Security;

            bool manageprest = false;
            if (MyDataAccess.GetUsr("usergrouplist") != null) {
                manageprest = security.GetUsr("usergrouplist").ToString().ToLower().IndexOf("manage_prestazioni") >= 0;
            }
            if (manageprest == false && MyDataAccess.Security.GetUsr("manage_prestazioni") != null) {
                manageprest = security.GetUsr("manage_prestazioni").ToString().ToUpper() == "S";
            }
            if (MyDataAccess.Is_Member("manage_prestazioni")) {
                manageprest = true;
            }
            if (manageprest) security.SetSys("manage_prestazioni", "S");

            bool consolidamento = false;
            if (security.GetUsr("usergrouplist") != null) {
                consolidamento = security.GetUsr("usergrouplist").ToString().ToLower().IndexOf("consolidamento") >= 0;
            }

            if (consolidamento == false && security.GetUsr("consolidamento") != null) {
                consolidamento = security.GetUsr("consolidamento").ToString().ToUpper() == "S";
            }
            if (MyDataAccess.Is_Member("consolidamento")) {
                consolidamento = true;
            }
            if (consolidamento)
	            security.SetUsr("consolidamento", "S");

            bool IsAdmin = MyDataAccess.Is_Member("sysadmin");
            bool QuickAdmin = verifyQuickAdmin();
            if (QuickAdmin) ********** = false;
            //********** = !QuickAdmin;
            if (!IsAdmin) IsAdmin = QuickAdmin;
            if (IsAdmin) Dispatcher.SetSys("IsSystemAdmin", true);
            else Dispatcher.SetSys("IsSystemAdmin", false);
            MustClose = false;


            string esercizio = Dispatcher.GetSys("esercizio").ToString();
            //controllo validità esercizio
            string filteresercizio = "(ayear=" + QueryCreator.quotedstrvalue(esercizio, true) + ")";
            DataTable EsercizioTable =
                MyDataAccess.RUN_SELECT("accountingyear", "*", null, filteresercizio, null, true);

            if (EsercizioTable == null || EsercizioTable.Rows.Count == 0) {
                if (MyDataAccess.RUN_SELECT_COUNT("SYSOBJECTS", "XTYPE='U'", false) == 0) {
                    Disconnect();
                    MetaFactory.factory.getSingleton<IMessageShower>().Show("Installare il programma", "Errore");
                    return;
                }

                if (MyDataAccess.RUN_SELECT_COUNT("accountingyear", null, false) == 0) {
                    Dispatcher.Edit(this, "accountingyear", "confcontabile", true, null);
                    Disconnect();
                    return;
                }
                else {
                    int curres = DateTime.Now.Year;
                    DateTime DateToSet = DateTime.Now;
                    int esmax = Convert.ToInt32(MyDataAccess.DO_READ_VALUE("accountingyear", null, "max(ayear)"));
                    Dispatcher.SetSys("esercizio", esmax);
                    if (curres < esmax) {
                        DateToSet = new DateTime(esmax, 12, 31);
                    }
                    if (curres > esmax) {
                        DateToSet = new DateTime(esmax, 12, 31);
                    }

                    if (!CambioDataConsentita(MyDataAccess, DateToSet)) {
                        MetaFactory.factory.getSingleton<IMessageShower>().Show("Accesso non consentito in tale data in base alla gestione della sicurezza");
                        Disconnect();
                        return;
                    }
                    Dispatcher.SetSys("datacontabile", DateToSet);
                    MyDataAccess.SetSys("esercizio", esmax);
                    MyDataAccess.SetSys("datacontabile", DateToSet);

                    MyDataAccess.RecalcUserEnvironment();
                    if (MyDataAccess.openError) {
	                    MetaFactory.factory.getSingleton<IMessageShower>().Show("Errore in fase di calcolo dell'ambiente");
	                    Disconnect();
	                    return;
                    }
                    
                    MyDataAccess.ReadAllGroupOperations();
                    MetaFactory.factory.getSingleton<IMessageShower>().Show("L'esercizio " + esercizio + " non è stato definito per questo Ente", "Attenzione",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    MetaFactory.factory.getSingleton<IMessageShower>().Show("Avvertimento: la data contabile è stata automaticamente impostata al \n" +
                                    ((DateTime)Dispatcher.GetSys("datacontabile")).ToShortDateString());

                    foreach (string k in new[] { "server", "database", "FlagMenuAdmin", "IsSystemAdmin", "esercizio", "user", "ndetail",
                    "userdb", "dsn", "computername", "MetaDataVersion", "datacontabile", "idflowchart",
                    "dbversion", "idcustomuser", "computeruser"}) {
                        object o = MyDataAccess.GetSys(k);
                        if (o == null) o = "<null>";
                        if (o.ToString().Length > 100) o = o.ToString().Substring(0, 100);
                        QueryCreator.MarkEvent("sys[" + k + "]=" + o);
                    }

                    //Disconnect();
                    //return;
                }
            }
            esercizio = security.GetEsercizio().ToString();
            filteresercizio = "(ayear=" + QueryCreator.quotedstrvalue(esercizio, true) + ")";
            Esercizio.Text = esercizio;
            DataCont.Text = ((DateTime)Dispatcher.GetSys("datacontabile")).ToShortDateString();
            currentRole.Text = getRole(MyDataAccess);

            if (!CambioDataConsentita(MyDataAccess, (DateTime)security.GetSys("datacontabile"))) {
                MetaFactory.factory.getSingleton<IMessageShower>().Show("Accesso non consentito in tale data in base alla gestione della sicurezza");
                Disconnect();
                return;
            }
            if (MyDataAccess.GetSys("idflowchart")is string & !( MyDataAccess.GetSys("ndetail")is int)) {
                MetaFactory.factory.getSingleton<IMessageShower>().Show("Sicurezza non ben configurata nell'anno");
	            Disconnect();
                return;
			}

            var sec = MyDataAccess.SelectCondition("menu",true);
            var usrMenu = MyDataAccess.GetUsr("menu")?.ToString();
            if (!string.IsNullOrEmpty(sec) && string.IsNullOrEmpty(usrMenu)) {
	            MetaFactory.factory.getSingleton<IMessageShower>().Show("Sicurezza non ben configurata nell'anno");
	            Disconnect();
	            return;
            }
            ConnectItem.Enabled = false;
            AddLiveUpdateConfig(MyDataAccess);

            bool ShowAdminMenu = (bool)Dispatcher.GetSys("IsSystemAdmin");

            ApplyCustomSecurity();
            reenableMenu();
            SetMenu(ShowAdminMenu, **********);

            // Se siamo in DEBUG ci consideriamo amministratori e quindi la barra degli strumenti deve uscire completa
            // e non limitata come per gli utenti normali
            if ((Debugger.IsAttached) && (AppDomain.CurrentDomain.FriendlyName != "MetaDataDomain")) {
	            security.SetSys("FlagMenuAdmin", "S");
	            security.SetSys("manage_prestazioni", "S");
	            security.SetUsr("consolidamento", "S");
	            security.SetSys("IsSystemAdmin", true);
            }

            if (QuickAdmin) {
	            security.SetSys("FlagMenuAdmin", "S");
	            security.SetSys("manage_prestazioni", "S");
	            security.SetUsr("consolidamento", "S");
	            security.SetSys("IsSystemAdmin", true);

            }


            ////GESTIONE DELLE LICENZE RIMOSSA
            //if (!CheckForLicenseValidity()) {
            //    if (!VerifyQuickAdmin()) RestrictMenu();
            //}
            MessageDisplayed = false;

            try {
                controllaConfigurazioni(filteresercizio);
            }
            catch {
            }

            //Separatore decimali, migliaia, etc...
            ControlloImpostazioniInternazionali();

            //Modifica campo della tabella updatedbscript
            //				AlterUpdatedbscript(); 			

            //Controllo abilitazione trigger ricorsivi
            //AbilitaTriggerRicorsivi();

            //Elimina vecchi log
            //DeleteOldLog();

            //in debug mode è sempre abilitato
            menuAdmin.Enabled = Debugger.IsAttached || verifyQuickAdmin();
            security.SetSys("FlagMenuAdmin", menuAdmin.Enabled ? "S" : "N");


            // Avvia il live update del DB
            if (threadDownloadDB == null || !threadDownloadDB.IsAlive) {
	            if (!isBlazor) {
		            threadDownloadDB = new Thread(new ThreadStart(UpdateDB));
		            threadDownloadDB.Name = "UpdateDB";
		            threadDownloadDB.Priority = ThreadPriority.BelowNormal;
		            threadDownloadDB.Start();
	            }
            }
            if (TS == null) {
                TS = new MyListener();
                Trace.Listeners.Add(TS);
            }

            object dbver = MyDataAccess.DO_READ_VALUE("updatedbversion", null, "max(versionname)");
            if (dbver != null) {
                if (dbver.ToString().CompareTo("2.5.570") < 0) {
                    string msg = "Il software installato richiede un db aggiornato. E' indispensabile " +
                   "ATTENDERE l'aggiornamento del DATABASE e poi chiudere e riaprire" +
                   " il programma. Fino a quel momento NON SARA' POSSIBILE SALVARE ALCUN DATO.";
                    MyDataAccess.readOnly = true;
                    MustClose = true; //Disabilita il cambio di esercizio o cambio data
                    MetaFactory.factory.getSingleton<IMessageShower>().Show(F, msg, "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    DisconnectItem.Enabled = true;
                    ChangeRoleItem.Enabled = false;
                    connecting = false;

                    return;
                }
            }

            //Verifica se ci sono regole da ricompilare
            try {
                mainformfun.MakeRules(Dispatcher);
            }
            catch { }


            if (MyDataAccess==null)return;
            
            if (ciSonoAvvisi(MyDataAccess)) {
                Dispatcher.Edit(this, "no_table", "alert", true, null);
            }
            if (MyDataAccess == null) return;
            if (ciSonoComunicazioni(MyDataAccess)) {
                Dispatcher.Edit(this, "no_table", "advice", true, null);
            }

            string pwdset = MyDataAccess.GetSys("initial_password_set") as string;
            while (pwdset == "S") {
                var m1 = Dispatcher.Get("changepassword");
                if (m1.EditTypes.Count == 0) {
                    pwdset = "S";
                    MetaFactory.factory.getSingleton<IMessageShower>().Show(this, "Attendere l'aggiornamento del programma e poi cambiare la password.");
                }
                else {
                    m1.Edit(this, "default", true);
                    pwdset = MyDataAccess.GetSys("initial_password_set") as string;
                }
            }
            DisconnectItem.Enabled = true;
            ChangeRoleItem.Enabled = true;
            connecting = false;

        }
        private void menuItem2_Click(object sender, System.EventArgs e) {
            if (!checkExecutionPath()) return;
            try {
                connect();
            }
            catch (Exception ee) {
                QueryCreator.showException(ee,null);
            }
        }

        public bool isUnderTest = false;

        private bool ciSonoAvvisi(DataAccess Conn) {
            QueryHelper QHS = Conn.GetQueryHelper();
            string filtroLogin = QHS.CmpEq("login", Conn.GetSys("user"));
            DataTable tUserAlert = Conn.RUN_SELECT("dbuseralert", null, null, filtroLogin, null, true);
            string filtroAlert = QHS.AppAnd(
                QHS.FieldIn("idalert", tUserAlert.Select()),
                QHS.CmpNe("query", ""));
            DataTable tAlert = Conn.RUN_SELECT("alert", null, null, filtroAlert, null, true);
            foreach (DataRow r in tAlert.Rows) {                
                string query = Conn.Security.Compile(r["query"].ToString(), true);
                if (query == "(1=2)") continue;
                DataTable t = Conn.SQLRunner(query);
                if ((t != null) && (t.Rows.Count > 0)) {
                    return true;
                }
            }
            return false;
        }

        private bool ciSonoComunicazioni (DataAccess conn) {
            if (conn == null) return false;
            var QHS = conn.GetQueryHelper();
            string filtroLogin = QHS.CmpEq("dbuseradvice.login", conn.GetSys("user"));

            /*
            select alert.idalert from alert  
                left outer join dbuseralert
                on dbuseralert.idalert = alert.idalert
                AND dbuseralert.login = 'SARA'
                WHERE dbuseralert.idalert is null*/

            string query = " SELECT advice.codeadvice from advice  " +
                           " LEFT OUTER JOIN dbuseradvice ON " +
                           " dbuseradvice.codeadvice = advice.codeadvice " +
                           " AND " + filtroLogin +
                           " WHERE " + QHS.IsNull("dbuseradvice.codeadvice");
            DataTable tAdvice = conn.SQLRunner(query);
            if ((tAdvice != null) && (tAdvice.Rows.Count > 0)) {
                return true;
            }
   
            return false;
        }
        

        void reenableMenu() {
            if (MustClose) return;
            if (this.IsDisposed) return;
            mnuBackup.Visible = true;
            mnuCambiaPassword.Visible = true;
            mnuLocalConfig.Visible = true;
            mnuLiveUpdateOnDemand.Visible = true;
            //mnuAbilitaAdmin.Visible=false;
            menuAdmin.Visible = true;
            //menuMenu.Visible = true;
            menuVarie.Visible = true;
            mnuBigAdmin.Visible = true;
            menuTicket.Visible = true;

        }

        /// <summary>
        /// Abilita/Disabilita le operazioni di backup/config/ondemand in base alle regole di sicurezza 
        ///	 (possibilità di selezionare da adminoperation una riga con il corrisp.valore)
        /// </summary>
        void ApplyCustomSecurity() {
            if (MyDataAccess == null) return;
            QueryHelper QHS = MyDataAccess.GetQueryHelper();            
            mnuLocalConfig.Enabled = true;
            mnuBackup.Enabled = true;
            mnuLiveUpdateOnDemand.Enabled = true;
            //ReadMenu.Enabled = true;
            mnuCfgCONTABILE.Enabled = true;
            menuTicket.Enabled = true;
            DataTable Ops = MyDataAccess.RUN_SELECT("adminoperation", "*", null, null, null, null, true);
            if (Ops == null) return;

            Ops.Clear();
            
            if (Ops.Columns.Count < 2) return;
            DataSet DD = new DataSet();
            DD.Tables.Add(Ops);
            DataRow Test = Ops.NewRow();
            Test["opname"] = "backup";
            Ops.Rows.Add(Test);
            if (!MyDataAccess.Security.CanSelect(Ops, 0)) mnuBackup.Enabled = false;
            Test["opname"] = "localconfig";
            if (!MyDataAccess.Security.CanSelect(Ops, 0)) mnuLocalConfig.Enabled = false;
            Test["opname"] = "ondemand";
            if (!MyDataAccess.Security.CanSelect(Ops, 0)) mnuLiveUpdateOnDemand.Enabled = false;
            Test["opname"] = "menuupdate";
            //if (!MyDataAccess.CanSelect(Ops, 0)) ReadMenu.Enabled = false;

            if (MyDataAccess.GetUsr("configurazione") != null && MyDataAccess.GetUsr("configurazione").ToString().ToUpper() != "S") {
                mnuCfgCONTABILE.Enabled = false;
            }

            //DataTable Conf = MyDataAccess.RUN_SELECT("config", "*", null,
            //        QHS.CmpEq("ayear", MyDataAccess.GetSys("esercizio")), null, false);
            //if (!MyDataAccess.CanPost(Conf.Rows[0])) mnuCfgCONTABILE.Enabled = false;
        }


        /// <summary>
        /// Verifica che l'utente abbia come impostazioni valuta 2 decimali
        /// e il separatore dei decimali diverso da quello delle migliaia
        /// </summary>
        private void ControlloImpostazioniInternazionali() {
            try {
                NumberFormatInfo info = Thread.CurrentThread.CurrentCulture.NumberFormat;
                string msg = "";
                bool show = false;
                if (info.CurrencyDecimalDigits < 2) {
                    msg = "Il numero dei decimali non è impostato almeno a 2\r";
                    show = true;
                }
                if (info.CurrencyDecimalSeparator == info.CurrencyGroupSeparator) {
                    msg += "Il separatore dei decimali è uguale al separatore delle migliaia\r";
                    show = true;
                }
                if (info.NumberDecimalSeparator == info.NumberGroupSeparator) {
                    msg += "Il separatore dei decimali è uguale al separatore delle migliaia\r";
                    show = true;
                }

                if (show) {
                    msg += "\rQuesto può causare mal funzionamenti del programma. Modificare tali proprietà dal menu\r" +
                        "Avvio (Start)\\Impostazioni\\Pannello di Controllo\\Opzioni Internazionali e della lingua\r" +
                        "Dopo chiudere e riaprire il programma.";
                    MetaFactory.factory.getSingleton<IMessageShower>().Show(msg, "Attenzione",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }


            }
            catch (Exception E) {
                QueryCreator.MarkEvent("ERRORE - ControlloImpostazioniInternazionali() - " + E.Message);
            }

        }


      

      

        /// <summary>
        /// Elimina i vecchi log
        /// </summary>
        /// <param name="Conn"></param>
        private void DeleteOldLog(DataAccess Conn) {
            //QueryCreator.MarkEvent("Cancellazione vecchi log");
            //string db=QueryCreator.quotedstrvalue(Dispatcher.GetSys("database"),true);
            string script = "delete from  updatedbscript where  versionname <= " +
                "(select top 1 versionname from updatedbscript where not " +
                "versionname in (select top 20 versionname from updatedbscript group by versionname order by versionname desc) " +
                "group by versionname order by versionname desc " +
                ")";
            DataTable T = Conn.SQLRunner(script, true);
            script = "delete from  updatedbversion where  versionname <= " +
                "(select top 1 versionname from updatedbversion where not " +
                "versionname in (select top 20 versionname from updatedbversion group by versionname order by versionname desc) " +
                "group by versionname order by versionname desc " +
                ")";
            T = Conn.SQLRunner(script, true);
        }

        /// <summary>
        /// Questo metodo è eseguito in un THREAD SECONDARIO!!!!! Non usare la conn.principale!!
        /// </summary>
        private void UpdateDB() {
            if (MyDataAccess == null) return;
            string[] rempath = GetLiveUpdateAddress();
            //Forzo la creazione perché posso aver aggiornato
            //la configurazione locale
            MyDownloadDB = new Download(Dispatcher, rempath, C_FILEINDEXNAME,
                AppDomain.CurrentDomain.BaseDirectory);

            //Si può verififcare quando durante l'attesa per la connessione
            //al server web ci si disconnette dal Database
            if (MyDataAccess == null) return;
            DataAccess DownloadDBConnection = MyDataAccess.Duplicate();
            DeleteOldLog(DownloadDBConnection);
            if (MyDownloadDB == null) return;
            MyDownloadDB.Connessione = DownloadDBConnection;
            if (Dispatcher == null) return;
            MyDownloadDB.IsAdmin = Convert.ToBoolean(Dispatcher.GetSys("IsSystemAdmin"));
            MyDownloadDB.GetNewDBVersion();
            
            if (MyDownloadDB == null) return;

            

            bool SWSupported = MyDownloadDB.IsSoftwareSupported();
            if (!SWSupported) {
                //se sono qua vuol dire che è necessario un aggiornamento sw
                //il db ne richiede una nuova versione in seguito ad aggiornamento
                string msg = "La versione del database corrente richiede una versione successiva del software. E' indispensabile " +
                    "ATTENDERE l'aggiornamento SOFTWARE e poi chiudere e riaprire" +
                    " il programma. Fino a quel momento NON SARA' POSSIBILE SALVARE ALCUN DATO.";                
                MyDataAccess.readOnly = true;
                MustClose = true; //Disabilita il cambio di esercizio o cambio data
                MetaFactory.factory.getSingleton<IMessageShower>().Show(msg, "Attenzione",MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            //se non è connesso non faccio nessun controllo di versione e/o aggiornamento
            if (//MyDownloadSW == null || 
                //!MyDownloadSW.Connected || 
                MyDownloadDB!=null &&
                !MyDownloadDB.Connected) {
                MyDownloadDB.Connessione.Destroy();
                MyDownloadDB.Connessione = null;
                DownloadDBConnection = null;
                return;
            }

            //ControlloAggiornamentoMenu(DownloadDBConnection);

            //terminato l'aggiornamento controllo la compatibilità della versione
            if (MyDownloadDB == null) {
                QueryCreator.MarkEvent("ERRORE : MyDownloadDB == null alla riga 2175 del form main");
                return;
            }
            MyDownloadDB.Connessione.Destroy();
            MyDownloadDB.Connessione = null;

            /*
            if (MyDownloadDB.IsDBUpdated && !SWSupported) {
                //se sono qua vuol dire che è stato effettuato un aggiornamento
                //al DB che richiede una nuova versione del sw
                string msg = "E' sconsigliabile l'utilizzo del programma " +
                    "con una versione software non aggiornata. NON SARA' POSSIBILE SALVARE ALCUN DATO fino al momento dell'aggiornamento.";
                MyDataAccess.ReadOnly=true;			
                MustClose=true; //Disabilita il cambio di esercizio o cambio data
                MetaFactory.factory.getSingleton<IMessageShower>().Show(msg, "Attenzione",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            */
        }

      
        private void menuItem9_Click(object sender, System.EventArgs e) {
            foreach (Form F in MdiChildren) {
                F.Close();
            }
        }

        private void MenuExport_Click(object sender, System.EventArgs e) {
            if (MyDataAccess == null) return;
            DialogResult Res = FileSaver.ShowDialog(this);
            if (Res != DialogResult.OK) return;
            dbanalyzer.ExportTableToXML(FileSaver.FileName, "menu", MyDataAccess, null);
        }

        

        private void menuItem4_Click_1(object sender, System.EventArgs e) {
            if (ActiveMdiChild == null) return;
            ActiveMdiChild.Close();

        }

        private void menuItem59_Click(object sender, System.EventArgs e) {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void menuItem60_Click(object sender, System.EventArgs e) {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void menuItem61_Click(object sender, System.EventArgs e) {
            LayoutMdi(MdiLayout.Cascade);
        }

       
    

        

        //
        //		private void MergeMenu_Click(object sender, System.EventArgs e) {
        //			//Merge With Replace (clear=false, replace=true)
        //			ReadMenuFromXML(false,true);
        //		}
        //
        //	

        private void menuItem2_Click_2(object sender, System.EventArgs e) {
            if (MyDataAccess == null) return;
            MyDataAccess.PrepareEnabled = true;
        }

        private void menuItem10_Click(object sender, System.EventArgs e) {
            if (MyDataAccess == null) return;
            MyDataAccess.PrepareEnabled = false;
        }

   


        bool Disconnect() {
            if (IsDisposed) return true;
            if ((OwnedForms.Length > 0) ||
                (MdiChildren.Length > 0)) {
                MetaFactory.factory.getSingleton<IMessageShower>().Show("Per collegarsi ad un nuovo DB è necessario chiudere prima tutte le finestre.");
                return false;
            }
            QueryCreator.MarkEvent("Disconnesso");
            MyDataAccess?.Destroy();
            Operator.Text = "";
            DataCont.Text = "";
            DB.Text = "";
            Esercizio.Text = "";
            currentRole.Text = "";
            Text = "Easy - Gestione Contabile Integrata";
            ConnectItem.Enabled = true;
            DisconnectItem.Enabled = false;
            ChangeRoleItem.Enabled = false;
            MyDataAccess = null;
            Dispatcher = null;
            SetMenu(false,true);
            if (threadDownloadDB != null) {
                MyDownloadDB?.StopThread();
            }
            this.attachInstance(null, typeof(IMetaDataDispatcher));
            this.attachInstance(null, typeof(IDataAccess));
            this.attachInstance(null, typeof(ISecurity));
            this.attachInstance(null, typeof(IErrorLogger));

            connecting = false;
            return true;
        }

        private void menuItem12_Click(object sender, System.EventArgs e) {
            if (operating) {
                MetaFactory.factory.getSingleton<IMessageShower>().Show("Attendere il completamento dell'operazione in corso prima di scollegarsi", "Avviso");
                return;
            }
            Disconnect();
        }
        

        private void Updatetimer1_Tick(object sender, System.EventArgs e) {
            UpdateDll();
        }

        /// <summary>
        /// Legge da updateconfig.xml gli indirizzi dal quale scaricare gli aggiornamenti
        /// </summary>
        /// <returns></returns>
        private string[] GetLiveUpdateAddress() {
            string filename = AppDomain.CurrentDomain.BaseDirectory;
            if (!filename.EndsWith("\\")) filename += "\\";
            filename += "updateconfig.xml";

            string[] siti = new string[3];
            try {
                //string filename = "updateconfig.xml";
                DataSet DS = new DataSet();
                DS.ReadXml(filename);
                siti[0] = DS.Tables["configtable"].Rows[0]["httpupdatepath"].ToString();
                siti[1] = DS.Tables["configtable"].Rows[0]["httpupdatepath2"].ToString();
                siti[2] = DS.Tables["configtable"].Rows[0]["httpupdatepath3"].ToString();
            }
            catch { }
            return siti;
        }
       

        private string C_FILEINDEXNAME = (IsNet45OrNewer() ? "fileindex4.xml": "fileindex.xml");
        private const string C_REPORTINDEXNAME = "reportindex.xml";
        private bool isBlazor = false;
        void UpdateDll() {
	        if (isBlazor ) return;
            threadDownloadSW = new Thread(new ThreadStart(UpdateDllThread));
            threadDownloadSW.Name = "UpdateDll";
            threadDownloadSW.Priority = ThreadPriority.BelowNormal;
            threadDownloadSW.Start();
        }

        void UpdateDllThread() {
            if ((MyDownloadSW != null) && (MyDownloadSW.is_alive)) return;
            string[] rempath = GetLiveUpdateAddress();
            MyDownloadSW = new Download(Dispatcher,rempath,C_FILEINDEXNAME,AppDomain.CurrentDomain.BaseDirectory);
            if (MyDownloadSW != null) MyDownloadSW.GetNewSWVersion();
            if (MyDownloadSW!=null) MyDownloadSW.GetNewReportVersion(C_REPORTINDEXNAME);
        }


        /// <summary>
        /// Imposta le variabili d'ambiente (Usr) relative alla configurazione locale
        /// </summary>
        /// <param name="Conn"></param>
        private void AddLiveUpdateConfig(DataAccess Conn) {

            //MODIFICHE TASK 10587
            DataSet DS = new DataSet();

            //string filename ="updateconfig.xml"

            string currdir = AppDomain.CurrentDomain.BaseDirectory;
            if (!currdir.EndsWith("\\")) currdir += "\\";
            currdir += "updateconfig.xml";

            try {
                DS.ReadXml(currdir);
                //DS.ReadXml(filename)
                Dispatcher.SetUsr("httpupdatepath", "http://www.temposrl.com/easy2/");
                if (Conn.LocalToDB)
                    Dispatcher.SetUsr("localreportdir", DS.Tables["configtable"].Rows[0]["localreportdir"].ToString());
                Dispatcher.SetUsr("httpupdatepath", DS.Tables["configtable"].Rows[0]["httpupdatepath"].ToString());
                Dispatcher.SetUsr("httpupdatepath2", DS.Tables["configtable"].Rows[0]["httpupdatepath2"].ToString());
                Dispatcher.SetUsr("httpupdatepath3", DS.Tables["configtable"].Rows[0]["httpupdatepath3"].ToString());
            }
            catch {
                return;
            }
        }
     

        Form getFormConfigLiveUpdate() {
            Assembly a = System.Reflection.Assembly.Load("ConfigLiveUpdate");
            foreach (System.Type FormType in a.GetTypes()) {
                if (FormType.Name == "Frm_ConfigLiveUpdate") {
                    ConstructorInfo FormBuilder = FormType.GetConstructor(new System.Type[] { });
                    Form F = (Form)FormBuilder.Invoke(new object[0]);
                    return F;
                }
            }
            return null;
        }

        private void menuItem25_Click(object sender, System.EventArgs e) {
            Form F = getFormConfigLiveUpdate();
            signalCreateForm(F,null);
            F.ShowDialog();
            AddLiveUpdateConfig(MyDataAccess);
        }

        

        private void timer1_Tick(object sender, System.EventArgs e) {
            if (InTicker1) return;
            InTicker1 = true;
            //QueryCreator.MarkEvent("Sono le "+DateTime.Now.ToShortTimeString());
            if (MyDownloadSW != null) {
                LiveUpdate.Text = MyDownloadSW.GetStatusSW();
                LiveUpdate.ToolTipText = MyDownloadSW.GetLastErrorSW();
            }
            if (MyDownloadDB != null) {
                if (MyDataAccess != null) {
                    DBUpdate.Text = MyDownloadDB.GetStatusDB();
                    DBUpdate.ToolTipText = MyDownloadDB.GetLastErrorDB();
                }
                else {
                    DBUpdate.Text = "";
                    DBUpdate.ToolTipText = "";
                }
                switch (Download.UpdateDbInCorso) {
                    case "0":	//stato iniziale
                    break;
                    case "1":	//download e esecuzione script in corso
                    if (!FormAttesaVisualizzato) {
                        FormAttesaVisualizzato = true;
                        FormAttesa = new frmWait();
                        signalCreateForm(FormAttesa, null);
                        FormAttesa.Show();
                    }
                    try {
                        FormAttesa.txtDetail.Text = Dispatcher.GetSys("dbliveupdatedescription").ToString();
                    }
                    catch {
                    }
                    break;
                    default:	//aggiornamento terminato
                    if (FormAttesaVisualizzato) {
                        FormAttesaVisualizzato = false;
                        FormAttesa.Close();
                    }
                    break;
                }
            }

            if (MyDataAccess == null) {
                InTicker1 = false;
                return;
            }
           
            object OO = Dispatcher.GetUsr("mustchecksptocompile");
            if (OO != null) {
                if (OO.ToString() != "1") {
                    InTicker1 = false;
                    return;
                }
                Dispatcher.SetUsr("mustchecksptocompile", null);
                mainformfun.MakeRules(Dispatcher);
            }
            InTicker1 = false;
        }

        public void MyLogger(long ms) {            
            if (ms <= 0) {
                return;
            }
            if (ms < 1000) {
                lastLoadTime.Text = "Fetched in " + ms.ToString() + " ms";
            }
            else {
                double N = Convert.ToDouble(ms) / 1000;
                lastLoadTime.Text = String.Format("Fetched in {0} ms", N); ;
            }
            
        }

        private void mnuComprimi_Click(object sender, System.EventArgs e) {
            string currdir = AppDomain.CurrentDomain.BaseDirectory;
            FolderBrowserDialog folderDlg = new FolderBrowserDialog();
            folderDlg.Description = "Seleziona la cartella in cui si trovano i file da zippare";
            folderDlg.SelectedPath = currdir;
            if (folderDlg.ShowDialog() != DialogResult.OK) return;
            currdir = folderDlg.SelectedPath;
            string zipdir = currdir + @"\zip\";
            DirectoryInfo D = new DirectoryInfo(currdir);
            DirectoryInfo Dzip = new DirectoryInfo(zipdir);
            if (!Dzip.Exists) D.CreateSubdirectory("zip");
            Cursor.Current = Cursors.WaitCursor;
            foreach (FileInfo f in D.GetFiles("*.*")) {
                if (f.Extension.ToLower() == ".pdb") continue;
                string filename = f.Name;
                XZip.AddFiles(zipdir + filename + ".zip", currdir, filename, true, true);
            }
            Cursor.Current = Cursors.Default;
            MetaFactory.factory.getSingleton<IMessageShower>().Show("File compressi in " + zipdir, "Compressione file",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void SBAR_PanelClick(object sender, System.Windows.Forms.StatusBarPanelClickEventArgs e) {

            if (e.Clicks < 2) return;

            if (e.StatusBarPanel == LiveUpdate) {
                string msg = e.StatusBarPanel.Text + "\r" + e.StatusBarPanel.ToolTipText;
                MetaFactory.factory.getSingleton<IMessageShower>().Show(msg, "Informazioni", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MyDataAccess == null) return;

            if (e.StatusBarPanel == DBUpdate) {
                string msg = e.StatusBarPanel.Text + "\r" + e.StatusBarPanel.ToolTipText;
                MetaFactory.factory.getSingleton<IMessageShower>().Show(msg, "Informazioni", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }


            if (this.MdiChildren.Length > 0) {
                MetaFactory.factory.getSingleton<IMessageShower>().Show(this, "Per eseguire l'operazione richiesta è necessario prima\n" +
                    "chiudere tutte le finestre aperte.");
                return;
            }
            object oldEsercizio = Dispatcher.GetSys("esercizio").ToString();            

            if (e.StatusBarPanel == DataCont) {
                if (MustClose) {
                    MetaFactory.factory.getSingleton<IMessageShower>().Show("Funzione disabilitata. Aggiornare il software, chiudere e riaprire il programma.");
                    return;
                }
                frmCambiaDataContabile CambiaDataCont = new frmCambiaDataContabile(Dispatcher);
                signalCreateForm(CambiaDataCont,this);
                if (CambiaDataCont.ShowDialog(this) != DialogResult.OK) return;

               

                MessageDisplayed = false;
                MyDataAccess.RecalcUserEnvironment();
                if (MyDataAccess.openError) {
	                MetaFactory.factory.getSingleton<IMessageShower>().Show("Errore in fase di calcolo dell'ambiente");
	                Disconnect();
	                return;
                }
                MyDataAccess.ReadAllGroupOperations();
                ApplyCustomSecurity();

                DataCont.Text = ((DateTime)Dispatcher.GetSys("datacontabile")).ToShortDateString();
                Esercizio.Text = Dispatcher.GetSys("esercizio").ToString();
                currentRole.Text = getRole(MyDataAccess);
                string newEsercizio = Dispatcher.GetSys("esercizio").ToString();
                if (oldEsercizio.ToString() != newEsercizio)
                    controllaConfigurazioni("(ayear=" + QueryCreator.quotedstrvalue(newEsercizio, true) + ")");
               
                if (MainMenuMaker != null) MainMenuMaker.ClearMenu(mainMenu1);
                reenableMenu();
                SetMenu(false, **********);
            }

            if (e.StatusBarPanel == Esercizio) {
                if (MustClose) {
                    MetaFactory.factory.getSingleton<IMessageShower>().Show("Funzione disabilitata. Aggiornare il software, chiudere e riaprire il programma.");
                    return;
                }
                frmCambiaEsercizio CambiaEsercizio = new frmCambiaEsercizio(Dispatcher);
                signalCreateForm(CambiaEsercizio,this);
                if (CambiaEsercizio.ShowDialog(this) != DialogResult.OK) return;
                MessageDisplayed = false;
                MyDataAccess.RecalcUserEnvironment();
                if (MyDataAccess.openError) {
	                MetaFactory.factory.getSingleton<IMessageShower>().Show("Errore in fase di calcolo dell'ambiente");
	                Disconnect();
	                return;
                }
                MyDataAccess.ReadAllGroupOperations();
                ApplyCustomSecurity();

                string new_esercizio = Dispatcher.GetSys("esercizio").ToString();
                if (oldEsercizio.ToString() == new_esercizio) return;
                DataCont.Text = ((DateTime)Dispatcher.GetSys("datacontabile")).ToShortDateString();
                Esercizio.Text = Dispatcher.GetSys("esercizio").ToString();
                currentRole.Text = getRole(MyDataAccess);
                controllaConfigurazioni("(ayear=" + QueryCreator.quotedstrvalue(new_esercizio, true) + ")");

                MainMenuMaker?.ClearMenu(mainMenu1);
                reenableMenu();
                SetMenu(false, **********);


            }
        }

        private void frmMain_Activated(object sender, System.EventArgs e) {
            //MetaData.SetColor(this,true);
            if (WrongDomain) {
                return;
            }
            if (MustDisplayConnect) {
                MustDisplayConnect = false;
                menuItem2_Click(null, null); //Simula una "Connect"
            }
            
        }
        
        private void mnuGenRelDir_Click(object sender, EventArgs e) {
            if (Dispatcher == null)
                return;
            MetaData M1 = Dispatcher.Get("customdirectrel");
            M1.Edit(this, "default", false);
        }

        private void mnuGenRelIndir_Click(object sender, EventArgs e) {
            if (Dispatcher == null)
                return;
            MetaData M1 = Dispatcher.Get("customindirectrel");
            M1.Edit(this, "default", false);
        }


        private void mnuGenSQLTabella_Click(object sender, System.EventArgs e) {
            if (MyDataAccess == null) return;
            Assembly a = System.Reflection.Assembly.Load("generaSQL");
            foreach (System.Type FormType in a.GetTypes()) {
                if (FormType.Name == "frmScriptByTable") {
                    ConstructorInfo FormBuilder = FormType.GetConstructor(new System.Type[] {typeof(DataAccess) });
                    Form F = (Form)FormBuilder.Invoke(new object[] { MyDataAccess });
                    signalCreateForm(F, null);
                    F.ShowDialog();
                    return;
                }
            }

            //frmScriptByTable f = new frmScriptByTable(MyDataAccess);
            //f.ShowDialog();
        }



        private DialogResult ShowMsg(string msg) {
            return MetaFactory.factory.getSingleton<IMessageShower>().Show(msg, "Processo di installazione",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
        }

        private void mnuInstallazione_Click(object sender, System.EventArgs e) {
            string passo = "Attesa LiveUpdate";
            try {
                //Attesa aggiornamento Liveupdate
                string msg = "Attendere l'aggiornamento Software e DB," +
                    "poi premere OK per continuare l'installazione";
                if (ShowMsg(msg) != DialogResult.OK) {
                    MetaFactory.factory.getSingleton<IMessageShower>().Show("Installazione annullata.", "Attenzione",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                if (LiveUpdate.Text != "Aggiornamento software OK" ||
                    DBUpdate.Text != "Aggiornamento DB OK") {
                    msg = "Aggiornamento software e/o DB non terminato, ripetere il " +
                        "processo di installazione più tardi";
                    MetaFactory.factory.getSingleton<IMessageShower>().Show(msg, "Attenzione",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                passo = "Analizza struttura";
                //Esecuzione Analizza struttura
                msg = "Premere OK per eseguire Analizza Struttura";
                if (ShowMsg(msg) != DialogResult.OK) {
                    MetaFactory.factory.getSingleton<IMessageShower>().Show("Installazione annullata.", "Attenzione",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                Cursor.Current = Cursors.WaitCursor;
                MyDataAccess.Reset();
                MyDataAccess.GenerateCustomObjects();
                MyDataAccess.SaveStructure();
                Cursor.Current = Cursors.Default;

                passo = "Aggiornamento menu";
                //Aggiornamento menu
                msg = "Premere OK per aggiornare il menu";
                if (ShowMsg(msg) != DialogResult.OK) {
                    MetaFactory.factory.getSingleton<IMessageShower>().Show("Installazione annullata.", "Attenzione",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                //menuItem2_Click_3(sender, e);

                passo = "Inserimento Ente";
                //Inserimento Ente
                msg = "Premere OK per inserire l'Ente";
                if (ShowMsg(msg) != DialogResult.OK) {
                    MetaFactory.factory.getSingleton<IMessageShower>().Show("Installazione annullata.", "Attenzione",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                if (!Dispatcher.Edit(this, "license", "default", true, null)) {
                    msg = "Attenzione, non è stato inserito l'Ente, l'installazione " +
                        "verrà terminata.";
                    MetaFactory.factory.getSingleton<IMessageShower>().Show(msg, "Attenzione",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                passo = "Configurazione report";
                //Configurazione report e LiveUpdate
                msg = "Premere OK per impostare la cartella dei report";
                if (ShowMsg(msg) != DialogResult.OK) return;
                Form f = getFormConfigLiveUpdate();
                signalCreateForm(f, null);
                if (f.ShowDialog() != DialogResult.OK) {
                    msg = "Attenzione, non è stata impostata la cartella dei report, " +
                        "l'installazione verrà terminata.";
                    MetaFactory.factory.getSingleton<IMessageShower>().Show(msg, "Attenzione",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                msg = "Installazione terminata con successo";
                MetaFactory.factory.getSingleton<IMessageShower>().Show(msg, "Informazioni",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception E) {
                MetaFactory.factory.getSingleton<IMessageShower>().Show("Errore durante l'installazione - PASSO: " + passo +
                    "\r\rDetail: " + E.Message, "Errore",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mnuGenereLiveUpdate_Click(object sender, System.EventArgs e) {
            string file = Application.StartupPath + @"\GeneraLiveUpdate.exe";
            if (!File.Exists(file)) return;
            System.Diagnostics.Process.Start(file);
        }

        bool ********** = true;
        private void mnuAbilitaAdmin_Click(object sender, System.EventArgs e) {
            FrmAdmin f = new FrmAdmin();
            signalCreateForm(f, null);
            if (f.ShowDialog() != DialogResult.OK) return;
            ********** = f.**********;
            menuAdmin.Enabled = true;
            //menuMenu.Enabled = true;
            menuVarie.Enabled = !f.**********;
            mnuBigAdmin.Enabled = !f.**********;
            if (TS == null) {
                TS = new MyListener();
                Trace.Listeners.Add(TS);
            }
            if (Dispatcher == null) return;
            if (**********) return;
            Dispatcher.SetSys("FlagMenuAdmin", "S");
            Dispatcher.SetSys("manage_prestazioni", "S");
            Dispatcher.SetUsr("consolidamento", "S");

            Dispatcher.SetSys("IsSystemAdmin", true);
        }

        public static bool IsNet45OrNewer() {
            var result =
                Environment.Version.Major.Equals(4) &&
                Environment.Version.Minor.Equals(0) &&
                Environment.Version.Build.Equals(30319) &&
                Environment.Version.Revision >= 34000;

            return result;
        }
        
        private void mnuAzzeraVerSW_Click(object sender, System.EventArgs e) {
            string currdir = AppDomain.CurrentDomain.BaseDirectory;
            string indexfile = currdir + (IsNet45OrNewer() ? "fileindex4.xml":"fileindex.xml");
            string indexfilezip = currdir + (IsNet45OrNewer() ? "fileindex4.xml.zip": "fileindex.xml.zip");
            string versionfile = currdir + (IsNet45OrNewer() ? "versionesw4.txt":"versionesw.txt");
            try {
                if (File.Exists(indexfile)) File.Delete(indexfile);
                if (File.Exists(indexfilezip)) File.Delete(indexfilezip);
                if (File.Exists(versionfile)) File.Delete(versionfile);
            }
            catch { }
        }

        private void mnuBackup_Click(object sender, System.EventArgs e) {
            if (Dispatcher == null) return;
            if (MyDataAccess == null) return;
            var a = Assembly.Load("BackupRestore");
            foreach (var formType in a.GetTypes()) {
                if (formType.Name == "frmDB") {
                    var formBuilder = formType.GetConstructor(new[] { typeof(EntityDispatcher) });
                    var F = (Form)formBuilder.Invoke(new object[] { Dispatcher });
                    signalCreateForm(F, null);
                    F.ShowDialog();
                    return;
                }
            }

            //frmDB F = new frmDB(Dispatcher);
            //F.Show();
        }

        private void mnuUpdatedbversion_Click(object sender, System.EventArgs e) {
            if (MyDataAccess == null) return;
            Dispatcher.Edit(this, "updatedbversion", "default", false, null);
        }

        /// <summary>
        /// Output Viewer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuItem22_Click(object sender, System.EventArgs e) {
            if (TS == null) {
                TS = new MyListener();                
                Trace.Listeners.Add(TS);
                
            }
            TS.ShowErrors();
        }

        private void mnuEstraiFile_Click(object sender, System.EventArgs e) {
            FolderBrowserDialog folderDlg = new FolderBrowserDialog {
                Description = "Seleziona la cartella in cui si trovano i file (*.zip) da estrarre",
                ShowNewFolderButton = false
            };
            
            if (folderDlg.ShowDialog() != DialogResult.OK) return;
            string currdir = folderDlg.SelectedPath;
            string extractdir = currdir + @"\extract\";
            var D = new DirectoryInfo(currdir);
            var dextract = new DirectoryInfo(extractdir);
            if (!dextract.Exists) D.CreateSubdirectory("extract");
            Cursor.Current = Cursors.WaitCursor;
            foreach (FileInfo f in D.GetFiles("*.zip")) {
                string filename = f.Name.Remove(f.Name.Length - f.Extension.Length, f.Extension.Length);
                XZip.ExtractFiles(f.FullName, extractdir, filename, true, false);
            }
            Cursor.Current = Cursors.Default;
            MetaFactory.factory.getSingleton<IMessageShower>().Show("File estratti in " + extractdir, "Estrazione file",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
        
        private void MetaDataToolBar_ButtonClick(object sender, ToolBarButtonClickEventArgs e) {

        }

       
        private void menuItem35_Click(object sender, System.EventArgs e) {
            Dispatcher.Edit(this, "checkup", "default", true, null);
        }

        private void mnuLiveUpdateOnDemand_Click(object sender, System.EventArgs e) {
            if (MyDataAccess == null) return;
            Dispatcher.Edit(this, "ondemand", "default", true, null);
        }

     
        private void mnuLiveUpdateSync_Click(object sender, System.EventArgs e) {
            string file = Application.StartupPath + @"\LiveUpdateSync.exe";
            if (!File.Exists(file)) return;
            System.Diagnostics.Process.Start(file);
        }

        private void mnuCambiaPassword_Click(object sender, System.EventArgs e) {
            if (Dispatcher == null) return;
            MetaData M1 = Dispatcher.Get("changepassword");
            M1.Edit(this, "default", true);
        }

        private void menuHelp_Click(object sender, System.EventArgs e) {
            if (ActiveMdiChild == null) return;
            Form form = ActiveMdiChild;
            string codebase = form.GetType().Assembly.CodeBase;
            string nomedll = Path.GetFileNameWithoutExtension(codebase);
            string filename = nomedll + ".mht";
            if (!File.Exists(filename)) return;
            Help.ShowHelp(this, filename);
        
        }

        private void mnuCfgTECNICA_Click(object sender, System.EventArgs e) {
            Updatetimer1.Stop();
            timer1.Stop();
            Form F = MetaData.GetFormByDllName("Install");
            signalCreateForm(F,this);
            if (F != null) {
                F.ShowDialog(this);
            }
            Updatetimer1.Start();
            timer1.Start();
        }


        private void mnuCfgCONTABILE_Click(object sender, System.EventArgs e) {
            if (Dispatcher != null) {
                try {
                    Updatetimer1.Stop();
                    timer1.Stop();
                    Dispatcher.Edit(this, "accountingyear", "confcontabile", true, null);
                }
                catch { }
                Updatetimer1.Start();
                timer1.Start();
            }
        }

        
        private void mnuCambiaPasswordDipart_Click(object sender, System.EventArgs e) {
            if (Dispatcher == null) return;
            MetaData M1 = Dispatcher.Get("changepassword");
            M1.Edit(this, "dipartimento", true);
        }

        private void menuItem12_Click_2(object sender, System.EventArgs e) {
            FrmLinkUser F = new FrmLinkUser(MyDataAccess);
            signalCreateForm(F,this);
            F.ShowDialog(this);
            return;
        }

        private void menuItem14_Click(object sender, System.EventArgs e) {
            FrmAdmin F = new FrmAdmin();
            signalCreateForm(F,this);
            F.ShowDialog(this);
            if (F.txtPwd.Text == "") return;
            if (MyDataAccess == null) return;
            string S = MyDataAccess.GetSys(F.txtPwd.Text) as string;
            if (S == null) return;
            MetaFactory.factory.getSingleton<IMessageShower>().Show(S);
        }

        private void menuItem13_Click_1(object sender, EventArgs e) {
            MetaData M = Dispatcher.Get("expense");
            M.LogError("ciao", new Exception("AH AH"));
        }

        private void menuItem15_Click_1(object sender, EventArgs e) {
            if (Dispatcher == null) return;
            MetaData M = Dispatcher.Get("assetsetup");
            M.Edit(this, "settransmitted", true);
        }

        private void menuItem16_Click_1(object sender, EventArgs e) {
            if ((this.OwnedForms.Length > 0) ||
                (MdiChildren.Length > 0)) {
                MetaFactory.factory.getSingleton<IMessageShower>().Show("Per poter cambiare ruolo è necessario chiudere prima tutte le finestre.");
                return ;
            }

            if (MyDataAccess == null) return;
            if (MyDataAccess.ChangeFlowChart()) {
                try {
                    operating = true;
                    bool ShowAdminMenu = (bool) Dispatcher.GetSys("IsSystemAdmin");
                    if (MainMenuMaker != null) MainMenuMaker.ClearMenu(mainMenu1);
                    ApplyCustomSecurity();
                    reenableMenu();
                    SetMenu(ShowAdminMenu, **********);
                    currentRole.Text = getRole(MyDataAccess);
                }
                finally {
                    operating = false;
                }
            }
        }

        string getRole(DataAccess conn) {
            object idcustomuser = conn.GetSys("idcustomuser");
            object idflowchart = conn.GetSys("idflowchart");
            if (idflowchart == null) return "";
            if (idflowchart == DBNull.Value) return "";
            if (idflowchart.ToString() == "") return "";

            object ndetail = conn.GetSys("ndetail");
            object currdate = conn.GetSys("datacontabile");
            QueryHelper QHS = conn.GetQueryHelper();
            string f1 = QHS.AppAnd(QHS.CmpEq("U.idcustomuser", idcustomuser),
                      QHS.CmpEq("U.idflowchart", idflowchart),
                       QHS.CmpEq("U.ndetail", ndetail),
                       QHS.CmpEq("F.ayear", conn.GetEsercizio()));
            
            DataTable T = conn.SQLRunner("select isnull(U.title,F.title) as title " +
                   "  from flowchartuser U join " +
                    " flowchart F on U.idflowchart=F.idflowchart where " + f1, true, -1);

            if (T == null || T.Rows.Count == 0) return "Non in organigramma";
            return T.Rows[0]["title"].ToString();

        }

        private void menuItem17_Click(object sender, EventArgs e) {
            if (Dispatcher == null) return;
            MetaData M = Dispatcher.Get("restrictedfunction");
            M.Edit(this, "default", false);
        }

        private void menuItem18_Click(object sender, EventArgs e) {
            if (Dispatcher == null) return;
            MetaData M = Dispatcher.Get("securityvar");
            M.Edit(this, "default", false);
        }

        private void menuItem19_Click_1(object sender, EventArgs e) {
            if (Dispatcher == null) return;
            MetaData M = Dispatcher.Get("securitycondition");
            M.Edit(this, "default", false);
        }

        
        const string crlf = "\r\n";
      


      

        private void menuItem20_Click_1(object sender, EventArgs e) {
            string currdir = AppDomain.CurrentDomain.BaseDirectory;
            FolderBrowserDialog folderDlg = new FolderBrowserDialog();
            folderDlg.Description = "Seleziona la cartella in cui si trovano i file da unire";
            folderDlg.SelectedPath = currdir;
            if (folderDlg.ShowDialog() != DialogResult.OK) return;
            currdir = folderDlg.SelectedPath;
            string zipdir = currdir + @"\zip\";
            DirectoryInfo D = new DirectoryInfo(currdir);
            DirectoryInfo Dzip = new DirectoryInfo(zipdir);
            if (!Dzip.Exists) D.CreateSubdirectory("zip");
            Cursor.Current = Cursors.WaitCursor;
            StringBuilder SB = new StringBuilder();
            int N = 0;
            foreach (FileInfo f in D.GetFiles("*.*")) {
                if (f.Extension.ToLower() == ".pdb") continue;
                N++;
                string filename = f.Name;
                SB.AppendLine();
                SB.AppendLine("--File " + f.FullName);
                SB.AppendLine();

                StreamReader STR = new StreamReader(f.FullName, Encoding.Default);
                SB.Append(STR.ReadToEnd());
                SB.AppendLine();
                SB.AppendLine();

                STR.Close();
                STR.Dispose();
            }
            StreamWriter SWR = new StreamWriter(folderDlg.SelectedPath + "\\allfiles", false, Encoding.Default);
            SWR.Write(SB.ToString());
            SWR.Close();
            SWR.Dispose();
            Cursor.Current = Cursors.Default;
            MetaFactory.factory.getSingleton<IMessageShower>().Show(N.ToString() + " file compressi in " + zipdir + "\\allfiles", "Unione file",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private string getCampoSuccessivo(string message, ref int inizio) {
            inizio = message.IndexOf("%<", inizio) + 2;
            if (inizio < 2) return null;
            int fine = message.IndexOf(">%", inizio);
            if (fine < 0) return null;
            string campo = message.Substring(inizio, fine - inizio);
            inizio = fine;
            return campo;
        }
        private void menuItem21_Click_1(object sender, EventArgs e) {
            DataTable t = MyDataAccess.RUN_SELECT("auditcheck", null, null, null, null, true);
            DataTable tCol = MyDataAccess.RUN_SELECT("syscolumns", "object_name(id), name", null, null, null, false);
            foreach (DataRow r in t.Rows) {
                string message = (string)r["message"];
                string rule = r["idaudit"].ToString() + "-" +
                                r["tablename"].ToString() + "-" +
                                r["opkind"].ToString() + "-" +
                                r["idcheck"].ToString();
                int posizione = 0;
                string campo = null;
                while ((campo = getCampoSuccessivo(message, ref posizione)) != null) {
                    if ((campo != "esercizio") && (campo != "sys_esercizio")) {
                        int punto = campo.IndexOf('.');
                        string tabella = punto < 0 ? r["tablename"].ToString() : campo.Substring(0, punto);
                        string colonna = punto < 0 ? campo : campo.Substring(punto + 1);
                        //Console.WriteLine(campo + " " + tabella + "." + colonna);
                        DataRow[] rCol = tCol.Select("column1='" + tabella + "' and name='" + colonna + "'");
                        if (rCol.Length != 1) {
                            Console.WriteLine(rule + " " + campo + " " + tabella + "." + colonna);
                        }
                    }
                }
            }
        }

        private void menuItem26_Click(object sender, EventArgs e) {
            Updatetimer1.Stop();
            timer1.Stop();
            Form F = MetaData.GetFormByDllName("MigraCampus");
            F.ShowDialog(this);
            Updatetimer1.Start();
            timer1.Start();
        }

        private void menuItem27_Click_1(object sender, EventArgs e) {
            Dispatcher.Edit(this, "alert", "default", false, null); 
        }

        private void menuItem28_Click(object sender, EventArgs e) {
            string reportdir="";
			try {
				DataSet DS = new DataSet();
				DS.ReadXml(AppDomain.CurrentDomain.BaseDirectory+"updateconfig.xml");
				reportdir = DS.Tables["configtable"].Rows[0]["localreportdir"].ToString();
				if (!reportdir.EndsWith(@"\") && reportdir!="") reportdir+=@"\";
			}
			catch {
			}


            string indexfile = reportdir + "reportindex.xml";
            string indexfilezip = reportdir + "reportindex.xml.zip";
            string versionfile = reportdir + "versionereport.txt";
            try {
                if (File.Exists(indexfile)) File.Delete(indexfile);
                if (File.Exists(indexfilezip)) File.Delete(indexfilezip);
                if (File.Exists(versionfile)) File.Delete(versionfile);
            }
            catch { }

        }

        private void mnuCheckDll_Click(object sender, EventArgs e) {
            string currdir = AppDomain.CurrentDomain.BaseDirectory;
            string indexfile = currdir + (IsNet45OrNewer() ? "fileindex4.xml" : "fileindex.xml");
            string indexfilezip = currdir + (IsNet45OrNewer() ? "fileindex4.xml.zip" : "fileindex.xml.zip");
            string versionfile = currdir + (IsNet45OrNewer() ? "versionesw4.txt" : "versionesw.txt");
            try {
                if (!File.Exists(indexfile)) {
                    MetaFactory.factory.getSingleton<IMessageShower>().Show("Non esiste " + indexfile);
                    return;
                }
                if (!File.Exists(versionfile)) {
                    MetaFactory.factory.getSingleton<IMessageShower>().Show("Non esiste " + versionfile);
                    return;
                }
            }
            catch { }
            // Legge localVersion dal file versionesw.txt
            FileInfo f = new FileInfo(versionfile);
            StreamReader read1 = f.OpenText();
            string localVersion = read1.ReadLine();
            read1.Close();
            MetaFactory.factory.getSingleton<IMessageShower>().Show("La versione locale ricavata dal file " + versionfile + " è " + localVersion);


            DataSet locindex = new DataSet();
            locindex.ReadXml(indexfile);

            GenXML.GeneraFileXML(currdir, "checkdll.tmp", "*.dll");
            DataSet tempindex = new DataSet();
            tempindex.ReadXml("checkdll.tmp");
            File.Delete("checkdll.tmp");

            string res="";
            CQueryHelper QHC= new CQueryHelper();
            //Confronta le versioni locali con quelle del fileindex locale
            DataTable Loc = locindex.Tables[0];
            DataTable Real = tempindex.Tables[0];
            foreach (DataRow R in Loc.Select()) {
                //Cerca la riga tra quelle reali
                DataRow[] r = Real.Select(QHC.CmpEq("dllname", R["dllname"]));
                if (r == null || r.Length == 0) {
                    res += "File " + R["dllname"].ToString() + " non trovato nella directory locale.";
                    res+="\n";
                    continue;
                }
                DataRow rr = r[0];
                if (!rr["dllname"].ToString().ToLower().EndsWith("dll")) {
                    rr["minor"] = Convert.ToInt32(rr["minor"]) + 1; //per arrotondamenti sui secondi!!
                }
                if (Convert.ToInt32(R["major"]) > Convert.ToInt32(rr["major"]) ||

                    (Convert.ToInt32(R["major"]) == Convert.ToInt32(rr["major"]) &&
                     Convert.ToInt32(R["minor"]) > Convert.ToInt32(rr["minor"])) ||

                    (Convert.ToInt32(R["major"]) == Convert.ToInt32(rr["major"]) &&
                     Convert.ToInt32(R["minor"]) == Convert.ToInt32(rr["minor"]) &&
                     Convert.ToInt32(R["build"]) > Convert.ToInt32(rr["build"])
                     )
                    ) {
                    res += "La dll " + R["dllname"] + " ha la versione " +
                        rr["major"].ToString() + "/" + rr["minor"].ToString() + "/" + rr["build"].ToString() +
                        " inferiore a " +
                        R["major"].ToString() + "/" + R["minor"].ToString() + "/" + R["build"].ToString();
                    res += "\n";
                }
            }
            if (res != "") {
                QueryCreator.ShowError(this, "Differenze trovate", res);
            }
            else {
                MetaFactory.factory.getSingleton<IMessageShower>().Show("Non sono state trovate incoerenze nel file " + indexfile +
                    " rispetto alle versioni delle dll");

            }
        }

        //trasferisci organigramma
        private void menuItem31_Click_1(object sender, EventArgs e) {
            Dispatcher?.Edit(this, "no_table", "flowchartcopy", true, null);

        }

        //Consolida Database
        private void mnuConsolida_Click (object sender, EventArgs e) {
            Dispatcher?.Edit(this, "no_table", "wizardmerge", true, null);

        }

        //Configura Notifiche
        private void mnuConfignotifiche_Click(object sender, EventArgs e){
            Dispatcher?.Edit(this, "configsmtp", "default", true, null);

        }


        //applica sicurezza
        private void menuItem30_Click (object sender, EventArgs e) {
            Dispatcher?.Edit(this, "flowchart", "applicaforall", true, null);

        }


        private void menuItemConvert_Click(object sender, EventArgs e)
        {
            Dispatcher?.Edit(this, "no_table", "formconverter", true, null);
        }

        private void menuItemMacroarea_Click(object sender, EventArgs e){
            Dispatcher?.Edit(this, "macroarea", "lista",  true, null);
        }
        private void menuItemMacroareaVitto_Click(object sender, EventArgs e){
            Dispatcher?.Edit(this, "macroareaboard", "lista", true, null);
        }

        
      
        private void menuItem32_Click(object sender, EventArgs e) {
            Updatetimer1.Stop();
            timer1.Stop();
            Form F = MetaData.GetFormByDllName("CopyTables");
            F.ShowDialog(this);
            Updatetimer1.Start();
            timer1.Start();
        }

        private void LanciaScriptTuttiDip(object sender, EventArgs e) {
            frmScriptLauncher Frm = new frmScriptLauncher(MyDataAccess);
            Frm.Show(this);
            signalCreateForm(Frm, this);

        }

        private void menuItem36_Click(object sender, EventArgs e) {
            Dispatcher?.Edit(this, "no_table", "unifydip", true, null);
        }

        private void menuItem39_Click(object sender, EventArgs e) {
            Dispatcher?.Edit(this, "no_table", "flowchart_massive", true, null);
        }

        private void mnuIndiceGuida_Click(object sender, EventArgs e) {
            string currdir = AppDomain.CurrentDomain.BaseDirectory;
            if (!currdir.EndsWith("\\")) currdir += "\\";
            Process.Start(currdir+"indice_mht.mht");
            
        }

        private void menuItem41_Click(object sender, EventArgs e) {
            try {
                throw new Exception("eccezione di prova con throw", new Exception("eccezione interna"));
            }
            catch {
                // ignored
            }

            frmPalette p = new frmPalette(1);
            p.Show();
            signalCreateForm(p, null);

        }

        private void menuItem42_Click(object sender, EventArgs e) {
            if (Dispatcher == null)
                return;
            var m1 = Dispatcher.Get("webuser");
            m1.Edit(this, "default", true);
        }

        private void menuItem44_Click(object sender, EventArgs e) {
            if (Dispatcher == null)
                return;
            MetaData m1 = Dispatcher.Get("ticket");
            m1.Edit(this, "default", false);
        }

        private void menuDescrTabelle_Click(object sender, EventArgs e) {
            if (Dispatcher == null)
                return;
            MetaData M1 = Dispatcher.Get("tabledescr");
            M1.Edit(this, "default", false);
        }

        private void menuItem43_Click(object sender, EventArgs e) {
            if (Dispatcher == null)
                return;
            MetaData M1 = Dispatcher.Get("coldescr");
            M1.Edit(this, "default", false);
        }

        private void menuTeamViewer_Click(object sender, EventArgs e) {
            string path = System.IO.Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath);

            Process.Start(Path.Combine(path , "TeamViewerQS_it-idcbh5dn2z.exe"),"");
        }

        private void mnuCreaStruttura_Click(object sender, EventArgs e) {
            LiveUpdate.frmPath frmXML = new LiveUpdate.frmPath();
            signalCreateForm(frmXML,null);
            frmXML.ShowDialog();
        }

        private void menuItem23_Click(object sender, EventArgs e) {
            FrmSetAssInfo f = new FrmSetAssInfo();
            signalCreateForm(f,this);
            f.ShowDialog(this);
        }

       

        private bool operating = false;

        private void frmMain_FormClosed(object sender, FormClosedEventArgs e) {
            if (MyDataAccess != null) {
                DataAccess OO = MyDataAccess;
                MyDataAccess = null;
                OO.Destroy();
            }
            if (threadDownloadSW != null && MyDownloadSW != null) {
                Download XX = MyDownloadSW;
                MyDownloadSW = null;
                XX.StopThread();
            }
            if (threadDownloadDB != null && MyDownloadDB != null) {
                Download YY = MyDownloadDB;
                MyDownloadDB = null;
                YY.StopThread();
            }
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e) {
            if ((MyDownloadSW != null) && (MyDownloadSW.is_alive)) {
                MetaFactory.factory.getSingleton<IMessageShower>().Show("Attendere il completamento dell'aggiornamento del software prima di chiudere il programma", "Avviso");
                e.Cancel = true;
                return;
            }
            if ((MyDownloadDB != null) && (MyDownloadDB.is_alive)) {
                MetaFactory.factory.getSingleton<IMessageShower>().Show("Attendere il completamento dell'aggiornamento del db prima di chiudere il programma", "Avviso");
                e.Cancel = true;
                return;
            }
            if (!isInited) {
                MetaFactory.factory.getSingleton<IMessageShower>().Show("Attendere il completamento dell'apertura del programma prima di chiuderlo", "Errore");
                e.Cancel = true;
                return;
            }
            if (connecting) {
                MetaFactory.factory.getSingleton<IMessageShower>().Show("Attendere il completamento della connessione", "Errore");
                e.Cancel = true;
                return;
            }
            if (operating) {
                MetaFactory.factory.getSingleton<IMessageShower>().Show("Attendere il completamento dell'operazione in corso", "Errore");
                e.Cancel = true;
                return;
            }

           
        }

        private void menuTeamViewer2_Click(object sender, EventArgs e) {
            menuTeamViewer_Click(sender, e);
        }

        private void menuItem24_Click(object sender, EventArgs e) {
	        if (Dispatcher == null) return;
	        MetaData M1 = Dispatcher.Get("no_table");
	        M1.Edit(this, "scriptcomuni", false);
        }
    }

    public class MyListener : TraceListener {
        public StringBuilder Errors=new StringBuilder();
        public Form Err;               //FrmViewError
        //		public override void Write(string message, string category) {
        //			base.Write (message, category);
        //		}

        string GetPrintable(string msg) {
            string S = msg.Replace("\r", "\n");
            S = S.Replace("\n\n", "\n");
            S = S.Replace("\n", "\r\n");
            return S;
        }

        Form getViewError(string s) {
            Assembly a = System.Reflection.Assembly.Load("ViewError");
            foreach (System.Type FormType in a.GetTypes()) {
                if (FormType.Name == "frmViewError") {
                    ConstructorInfo FormBuilder = FormType.GetConstructor(new System.Type[] {typeof(string) });
                    Form F = (Form)FormBuilder.Invoke(new object[] {s});
                    return F;
                }
            }
            return null;
        }
        
        void updateViewError() {
            if (Err != null) {
                FieldInfo dataInfo = Err.GetType().GetField("txtMsg");
                TextBox tt = (TextBox)dataInfo.GetValue(Err);
                tt.Text = Errors.ToString();
                tt.SelectionLength = 0;
            }
        }

        public MyListener() {
            Errors = new StringBuilder();
            
        }

        public void CheckForNewErr() {
            if ((Err == null) || (Err.IsDisposed)) {
                Err = getViewError("");
                Err.TopMost = false;
            }
        }
        public override void WriteLine(object o) {
            Errors.AppendLine( GetPrintable(o.ToString()));
            updateViewError();
        }

        public override void WriteLine(string message) {
            Errors.AppendLine(GetPrintable(message));
            updateViewError();
        }

        public override void Write(string message) {
            Errors.Append(GetPrintable(message));
            updateViewError();
        }
        public void ShowErrors() {
            if ((Err == null) || (Err.IsDisposed)) {
                Err = getViewError(Errors.ToString());
                Err.TopMost = false;
            }
            updateViewError();
            Err.Show();
            
        }

    }

    class MyRelation {
        public int nfield;
        public string name;
        public string[] parent;
        public string[] child;
        string partable;
        string childtable;
        public MyRelation(DataRelation REL) {
            this.name = REL.RelationName;
            nfield = REL.ParentColumns.Length;
            parent = new string[nfield];
            child = new string[nfield];
            for (int i = 0; i < nfield; i++) {
                parent[i] = REL.ParentColumns[i].ColumnName;
                child[i] = REL.ChildColumns[i].ColumnName;
            }
            partable = REL.ParentTable.TableName;
            childtable = REL.ChildTable.TableName;
        }
        public bool AddToDataSet(DataSet D) {
            int N = 0;
            for (int i = 0; i < nfield; i++) {
                if (D.Tables[childtable].Columns[child[i]] == null) continue;
                N++;
            }
            if (N == 0) {
                return false;
            }
            DataColumn[] ParCol = new DataColumn[N];
            DataColumn[] ChildCol = new DataColumn[N];
            int M = 0;
            for (int i = 0; i < nfield; i++) {
                if (D.Tables[childtable].Columns[child[i]] == null) continue;                
                ParCol[M] = D.Tables[partable].Columns[parent[i]];
                ChildCol[M] = D.Tables[childtable].Columns[child[i]];
                M++;
            }
            DataRelation REL = new DataRelation(name,ParCol,ChildCol);
            D.Relations.Add(REL);
            return true;
        }
    }

}