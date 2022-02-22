
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
using System.Data;
using LiveUpdate;//LiveUpdate
using System.IO;
using utility;//utility
using System.Text;
using metadatalibrary;
using download;
using Xceed.Compression;
//using Xceed.Ftp;
using Xceed.Zip;
using Xceed.Utils;
using Xceed.FileSystem;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;

namespace GeneraLiveUpdate //GeneraLiveUpdate//
{


	/// <summary>
	/// Summary description for frmGeneraLiveUpdate.
	/// </summary>
	public class frmGeneraLiveUpdate : MetaDataForm {
		[STAThread]
		static void Main(string[] args) {
			//Thread.CurrentThread.CurrentCulture = new CultureInfo("en-EN");
			//Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-EN");
			//Application.EnableVisualStyles();
			//Application.SetCompatibleTextRenderingDefault(false);
			initLicenses();
			var F = new frmGeneraLiveUpdate();
			try {
				Application.Run(F);
			}
			catch (Exception e) {
				ErrorLogger.Logger.logException("Errore non gestito nell'esecuzione dell'applicazione.", e);
			}

			F.Dispose(true);
		}

		static void initLicenses() {
			string txtFile = "";
			string licFileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "licenses.dat");
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

		private Label label2;
		private Label label1;
		private GroupBox groupBox1;
		private RadioButton radioDLL;

		private RadioButton radioReport;

		//EntityDispatcher E;
		private IContainer components;
		private CheckBox chkFiltraGiornalieri;
		private Button btnCalcolaNuova;
		private Label NFileSelected;

		private enum eTipoLiveUpdate {
			DLL_EXE,
			REPORT,
			UNKNOWN
		};

		private eTipoLiveUpdate m_TipoLiveUpdate = eTipoLiveUpdate.UNKNOWN;

		public static bool IsNet45OrNewer() {
			var result =
				Environment.Version.Major.Equals(4) &&
				Environment.Version.Minor.Equals(0) &&
				Environment.Version.Build.Equals(30319) &&
				Environment.Version.Revision >= 34000;

			return result;
		}

		public string C_XMLFileDLL = (IsNet45OrNewer() ? "fileindex4.xml" : "fileindex.xml");
		const string C_XMLFileReport = "reportindex.xml";
		public string C_WebDirDLL = (IsNet45OrNewer() ? "zip4" : "zip");
		const string C_WebDirReport = "report";
		const string C_TmpDir = "tmp";
		const string C_SLASH = @"\";


		public string C_SQLFileIndex = "scriptindex.xml";
		public string m_SQLFile;
		public string m_SQLWebDir;


		/// <summary>
		/// indirizzo web per l'indice remoto
		/// </summary>
		private string m_WebDir;

		/// <summary>
		/// Percorsi locale per l'indice 
		/// </summary>
		private string m_XMLFile;

		/// <summary>
		/// Cartella locale per l'aggiornamento
		/// </summary>
		private string m_LocalDir;

		/// <summary>
		/// Filtro per i file da aggiornare
		/// </summary>
		private string m_Filter = "*.dll";


		private TextBox txtWeb;
		private Button btnDiff;
		private Label lblDiff;
		private Label lblFileXML;
		private Button btnSelAll;
		private Button btnDeselAll;
		private CheckedListBox checkList;
		private Button btnXMLFile;
		private Label lblNumero;
		private CheckBox chkSP;
		private Label label3;
		private Button btnDirUff;
		private TextBox txtDirUff;
		private Button btnDirTemp;
		private vistaForm DS;

		private TextBox txtDirDiff;
		private Button btnCopia;
		private GroupBox groupBox2;
		private Label label4;
		private Label label5;
		private Label label6;
		private Button btnDirDLL;
		private TextBox txtLocalDLL;
		private Button btnDirReport;
		private TextBox txtLocalReport;
		private Button btnDirSP;
		private TextBox txtLocalSP;
		private Button btnSync;
		private TextBox txtVerSWNew;
		private TextBox txtVerSWOld;
		private Label labVersioneSW;
		private GroupBox groupBox3;
		private Label labVersioneReport;
		private TextBox txtVerReportNew;
		private TextBox txtVerReportOld;
		private Button btnVersioni;
		private Label labNewVerRpt;
		private Label labNewVerSw;
		private TextBox txtNThread;
		private TabControl tabControl1;
		private TabPage tabPage1;
		private TabPage tabPage2;
		private TreeView tree;
		private ImageList icons;
		private TextBox txtSQLLocale;
		private TextBox txtSQLProduzione;
		private Label label12;
		private Label label11;
		private Button btnAnalizza;
		private Button btnUpdate;
		private Button btnNewVer;
		private TextBox txtNuovaVersione;
		private Label label13;
		private TextBox txtLocalSQL;
		private ContextMenuStrip contextMenuStrip1;
		private ToolStripMenuItem menuRinomina;
		private ToolStripMenuItem menuElimina;
		private ToolStripMenuItem menuDescrizione;
		private TextBox txtMinVersioneSw;
		private Label label14;
		private TextBox txtDescription;
		private Label label15;
		private Button btnScegli;
		private OpenFileDialog openFile;
		private TabPage tabPage3;
		private CheckedListBox nonaggiornati;
		private string m_IndexFileName = "";


		public frmGeneraLiveUpdate() {

			var mCI = new CultureInfo("en");

			Thread.CurrentThread.CurrentCulture = mCI;
			Thread.CurrentThread.CurrentUICulture = mCI;

			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			MetaData.SetColor(this);


			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			init();
		}

		private void init() {
			m_IndexFileName = Application.StartupPath + @"\genliveupdate.xml";
			m_XMLFile = null;
			m_WebDir = null;
			m_LocalDir = null;
			MetaData.SetColor(this, true);
			DS.Clear();
			if (!File.Exists(m_IndexFileName)) archivia();
			DS.ReadXml(m_IndexFileName, XmlReadMode.IgnoreSchema);
			txtWeb.Text = DS.config.Rows[0]["dirweb"].ToString();
			txtDirDiff.Text = DS.config.Rows[0]["dirdiff"].ToString();
			txtDirUff.Text = DS.config.Rows[0]["diruff"].ToString();
			txtLocalDLL.Text = DS.config.Rows[0]["dirdll"].ToString();
			txtLocalReport.Text = DS.config.Rows[0]["dirreport"].ToString();
			txtLocalSP.Text = DS.config.Rows[0]["dirsp"].ToString();
			txtLocalSQL.Text = DS.config.Rows[0]["diruff"].ToString() + "sql\\";
			XDir.CheckCreate(txtLocalDLL.Text);
			XDir.CheckCreate(txtLocalReport.Text);
			XDir.CheckCreate(txtLocalSP.Text);
			XDir.CheckCreate(txtDirUff.Text);
			XDir.Svuota(txtDirDiff.Text, true);
			XDir.CheckCreate(txtDirDiff.Text + "zip");
			XDir.CheckCreate(txtDirDiff.Text + "report");
			XDir.CheckCreate(txtDirDiff.Text + "sp");
			radioDLL.Checked = true;
			radioDLL_CheckedChanged(null, null);
			pulisciCampi();
			aggiornaLabel();
			caricaVersioni();
		}



		void aggiornaVersioneDb(string newdbversion) {
			if (txtDirUff.Text == "") return;
			string dir = XDir.CheckFinalSlash(txtDirUff.Text);
			var wr = new StreamWriter(dir + "versionedb.txt", false);
			wr.WriteLine(newdbversion);
			wr.Close();

		}

		private void caricaVersioni() {
			try {
				txtVerSWNew.Text = "";
				txtVerReportNew.Text = "";
				if (txtDirUff.Text == "") return;
				string dir = XDir.CheckFinalSlash(txtDirUff.Text);
				string versionDllName = (IsNet45OrNewer() ? "versionesw4.txt" : "versionesw.txt");

				var read = new StreamReader(dir + versionDllName);
				txtVerSWOld.Text = read.ReadLine();
				read.Close();
				read.Dispose();

				read = new StreamReader(dir + "versionereport.txt");
				txtVerReportOld.Text = read.ReadLine();
				read.Close();
				read.Dispose();

				read = new StreamReader(dir + "versionedb.txt");
				txtSQLLocale.Text = read.ReadLine();
				read.Close();
				read.Dispose();
				calcolaNuovaVersione(txtSQLLocale.Text);

				string[] rempath = new string[1];
				rempath[0] = txtWeb.Text.Trim();
				var h = new LiveUpdate.Http(rempath, AppDomain.CurrentDomain.BaseDirectory);
				string sql_rem = h.DownloadData("versionedb.txt");
				txtSQLProduzione.Text = sql_rem;
			}
			catch (Exception E) {
				System.Diagnostics.Debug.WriteLine("CaricaVersioni() - Msg: " + E.Message);
			}
		}

		private void archivia() {
			if (DS.config.Rows.Count == 0) {
				DS.config.Rows.Add(DS.config.NewRow());
			}

			DS.config.Rows[0]["dirweb"] = txtWeb.Text;
			DS.config.Rows[0]["dirdiff"] = txtDirDiff.Text;
			DS.config.Rows[0]["diruff"] = txtDirUff.Text;
			DS.config.Rows[0]["dirdll"] = txtLocalDLL.Text;
			DS.config.Rows[0]["dirreport"] = txtLocalReport.Text;
			DS.config.Rows[0]["dirsp"] = txtLocalSP.Text;
			DS.WriteXml(m_IndexFileName);
		}

		private void pulisciCampi() {
			bool software = (m_TipoLiveUpdate == eTipoLiveUpdate.DLL_EXE);
			bool report = !software;
			checkList.Items.Clear();
			lblNumero.Text = "";
			btnDiff.Visible = true;
			btnXMLFile.Visible = false;
			btnCopia.Visible = false;
			btnVersioni.Visible = false;
			btnCalcolaNuova.Visible = false;

			labVersioneReport.Visible = report;
			labNewVerRpt.Visible = report;
			txtVerReportNew.Visible = report;
			txtVerReportOld.Visible = report;

			labVersioneSW.Visible = software;
			labNewVerSw.Visible = software;
			txtVerSWNew.Visible = software;
			txtVerSWOld.Visible = software;

			GenXML.AzzeraIndicelocale();
			NFileSelected.Text = checkList.CheckedItems.Count.ToString() + " file selezionati";
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose(bool disposing) {
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}

			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.components = new Container();
			var resources = new ComponentResourceManager(typeof(frmGeneraLiveUpdate));
			this.label2 = new Label();
			this.label1 = new Label();
			this.groupBox1 = new GroupBox();
			this.radioReport = new RadioButton();
			this.radioDLL = new RadioButton();
			this.txtWeb = new TextBox();
			this.btnDiff = new Button();
			this.btnXMLFile = new Button();
			this.lblDiff = new Label();
			this.lblFileXML = new Label();
			this.checkList = new CheckedListBox();
			this.btnSelAll = new Button();
			this.btnDeselAll = new Button();
			this.lblNumero = new Label();
			this.chkSP = new CheckBox();
			this.btnDirUff = new Button();
			this.txtDirUff = new TextBox();
			this.label3 = new Label();
			this.btnDirTemp = new Button();
			this.txtDirDiff = new TextBox();
			this.DS = new vistaForm();
			this.btnCopia = new Button();
			this.groupBox2 = new GroupBox();
			this.label6 = new Label();
			this.btnDirSP = new Button();
			this.txtLocalSP = new TextBox();
			this.label5 = new Label();
			this.btnDirReport = new Button();
			this.txtLocalReport = new TextBox();
			this.label4 = new Label();
			this.btnDirDLL = new Button();
			this.txtLocalDLL = new TextBox();
			this.btnSync = new Button();
			this.txtVerSWNew = new TextBox();
			this.txtVerSWOld = new TextBox();
			this.labVersioneSW = new Label();
			this.groupBox3 = new GroupBox();
			this.btnCalcolaNuova = new Button();
			this.labNewVerRpt = new Label();
			this.labNewVerSw = new Label();
			this.btnVersioni = new Button();
			this.txtVerReportNew = new TextBox();
			this.txtVerReportOld = new TextBox();
			this.labVersioneReport = new Label();
			this.txtNThread = new TextBox();
			this.tabControl1 = new TabControl();
			this.tabPage1 = new TabPage();
			this.NFileSelected = new Label();
			this.chkFiltraGiornalieri = new CheckBox();
			this.tabPage2 = new TabPage();
			this.btnScegli = new Button();
			this.txtDescription = new TextBox();
			this.label15 = new Label();
			this.txtMinVersioneSw = new TextBox();
			this.label14 = new Label();
			this.label13 = new Label();
			this.txtLocalSQL = new TextBox();
			this.txtNuovaVersione = new TextBox();
			this.btnNewVer = new Button();
			this.btnAnalizza = new Button();
			this.btnUpdate = new Button();
			this.tree = new TreeView();
			this.contextMenuStrip1 = new ContextMenuStrip(this.components);
			this.menuDescrizione = new ToolStripMenuItem();
			this.menuRinomina = new ToolStripMenuItem();
			this.menuElimina = new ToolStripMenuItem();
			this.icons = new ImageList(this.components);
			this.txtSQLLocale = new TextBox();
			this.txtSQLProduzione = new TextBox();
			this.label12 = new Label();
			this.label11 = new Label();
			this.tabPage3 = new TabPage();
			this.nonaggiornati = new CheckedListBox();
			this.openFile = new OpenFileDialog();
			this.groupBox1.SuspendLayout();
			((ISupportInitialize) (this.DS)).BeginInit();
			this.groupBox2.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.tabPage2.SuspendLayout();
			this.contextMenuStrip1.SuspendLayout();
			this.tabPage3.SuspendLayout();
			this.SuspendLayout();
			// 
			// label2
			// 
			resources.ApplyResources(this.label2, "label2");
			this.label2.Name = "label2";
			// 
			// label1
			// 
			resources.ApplyResources(this.label1, "label1");
			this.label1.Name = "label1";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.radioReport);
			this.groupBox1.Controls.Add(this.radioDLL);
			resources.ApplyResources(this.groupBox1, "groupBox1");
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.TabStop = false;
			// 
			// radioReport
			// 
			resources.ApplyResources(this.radioReport, "radioReport");
			this.radioReport.Name = "radioReport";
			this.radioReport.CheckedChanged += new EventHandler(this.radioReport_CheckedChanged);
			// 
			// radioDLL
			// 
			resources.ApplyResources(this.radioDLL, "radioDLL");
			this.radioDLL.Name = "radioDLL";
			this.radioDLL.CheckedChanged += new EventHandler(this.radioDLL_CheckedChanged);
			// 
			// txtWeb
			// 
			resources.ApplyResources(this.txtWeb, "txtWeb");
			this.txtWeb.Name = "txtWeb";
			// 
			// btnDiff
			// 
			resources.ApplyResources(this.btnDiff, "btnDiff");
			this.btnDiff.Name = "btnDiff";
			this.btnDiff.Click += new EventHandler(this.btnDiff_Click);
			// 
			// btnXMLFile
			// 
			resources.ApplyResources(this.btnXMLFile, "btnXMLFile");
			this.btnXMLFile.Name = "btnXMLFile";
			this.btnXMLFile.Click += new EventHandler(this.btnXMLFile_Click);
			// 
			// lblDiff
			// 
			resources.ApplyResources(this.lblDiff, "lblDiff");
			this.lblDiff.Name = "lblDiff";
			// 
			// lblFileXML
			// 
			resources.ApplyResources(this.lblFileXML, "lblFileXML");
			this.lblFileXML.Name = "lblFileXML";
			// 
			// checkList
			// 
			resources.ApplyResources(this.checkList, "checkList");
			this.checkList.CheckOnClick = true;
			this.checkList.Name = "checkList";
			this.checkList.Sorted = true;
			this.checkList.ThreeDCheckBoxes = true;
			this.checkList.Click += new EventHandler(this.checkList_Click);
			this.checkList.SelectedValueChanged += new EventHandler(this.checkList_SelectedValueChanged);
			// 
			// btnSelAll
			// 
			resources.ApplyResources(this.btnSelAll, "btnSelAll");
			this.btnSelAll.Name = "btnSelAll";
			this.btnSelAll.Click += new EventHandler(this.btnSelAll_Click);
			// 
			// btnDeselAll
			// 
			resources.ApplyResources(this.btnDeselAll, "btnDeselAll");
			this.btnDeselAll.Name = "btnDeselAll";
			this.btnDeselAll.Click += new EventHandler(this.btnDeselAll_Click);
			// 
			// lblNumero
			// 
			resources.ApplyResources(this.lblNumero, "lblNumero");
			this.lblNumero.Name = "lblNumero";
			// 
			// chkSP
			// 
			resources.ApplyResources(this.chkSP, "chkSP");
			this.chkSP.Name = "chkSP";
			// 
			// btnDirUff
			// 
			resources.ApplyResources(this.btnDirUff, "btnDirUff");
			this.btnDirUff.Name = "btnDirUff";
			this.btnDirUff.Click += new EventHandler(this.btnDirUff_Click);
			// 
			// txtDirUff
			// 
			resources.ApplyResources(this.txtDirUff, "txtDirUff");
			this.txtDirUff.Name = "txtDirUff";
			this.txtDirUff.ReadOnly = true;
			// 
			// label3
			// 
			resources.ApplyResources(this.label3, "label3");
			this.label3.Name = "label3";
			// 
			// btnDirTemp
			// 
			resources.ApplyResources(this.btnDirTemp, "btnDirTemp");
			this.btnDirTemp.Name = "btnDirTemp";
			this.btnDirTemp.Click += new EventHandler(this.btnDirTemp_Click);
			// 
			// txtDirDiff
			// 
			resources.ApplyResources(this.txtDirDiff, "txtDirDiff");
			this.txtDirDiff.Name = "txtDirDiff";
			this.txtDirDiff.ReadOnly = true;
			// 
			// DS
			// 
			this.DS.DataSetName = "vistaForm";
			this.DS.Locale = new CultureInfo("en-US");
			// 
			// btnCopia
			// 
			resources.ApplyResources(this.btnCopia, "btnCopia");
			this.btnCopia.ForeColor = System.Drawing.Color.Red;
			this.btnCopia.Name = "btnCopia";
			this.btnCopia.Click += new EventHandler(this.btnCopia_Click);
			// 
			// groupBox2
			// 
			resources.ApplyResources(this.groupBox2, "groupBox2");
			this.groupBox2.Controls.Add(this.label6);
			this.groupBox2.Controls.Add(this.btnDirSP);
			this.groupBox2.Controls.Add(this.txtLocalSP);
			this.groupBox2.Controls.Add(this.label5);
			this.groupBox2.Controls.Add(this.btnDirReport);
			this.groupBox2.Controls.Add(this.txtLocalReport);
			this.groupBox2.Controls.Add(this.label4);
			this.groupBox2.Controls.Add(this.btnDirDLL);
			this.groupBox2.Controls.Add(this.txtLocalDLL);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.TabStop = false;
			// 
			// label6
			// 
			resources.ApplyResources(this.label6, "label6");
			this.label6.Name = "label6";
			// 
			// btnDirSP
			// 
			resources.ApplyResources(this.btnDirSP, "btnDirSP");
			this.btnDirSP.Name = "btnDirSP";
			this.btnDirSP.Click += new EventHandler(this.btnDirSP_Click);
			// 
			// txtLocalSP
			// 
			resources.ApplyResources(this.txtLocalSP, "txtLocalSP");
			this.txtLocalSP.Name = "txtLocalSP";
			this.txtLocalSP.ReadOnly = true;
			// 
			// label5
			// 
			resources.ApplyResources(this.label5, "label5");
			this.label5.Name = "label5";
			// 
			// btnDirReport
			// 
			resources.ApplyResources(this.btnDirReport, "btnDirReport");
			this.btnDirReport.Name = "btnDirReport";
			this.btnDirReport.Click += new EventHandler(this.btnDirReport_Click);
			// 
			// txtLocalReport
			// 
			resources.ApplyResources(this.txtLocalReport, "txtLocalReport");
			this.txtLocalReport.Name = "txtLocalReport";
			this.txtLocalReport.ReadOnly = true;
			// 
			// label4
			// 
			resources.ApplyResources(this.label4, "label4");
			this.label4.Name = "label4";
			// 
			// btnDirDLL
			// 
			resources.ApplyResources(this.btnDirDLL, "btnDirDLL");
			this.btnDirDLL.Name = "btnDirDLL";
			this.btnDirDLL.Click += new EventHandler(this.btnDirDLL_Click);
			// 
			// txtLocalDLL
			// 
			resources.ApplyResources(this.txtLocalDLL, "txtLocalDLL");
			this.txtLocalDLL.Name = "txtLocalDLL";
			this.txtLocalDLL.ReadOnly = true;
			// 
			// btnSync
			// 
			resources.ApplyResources(this.btnSync, "btnSync");
			this.btnSync.Name = "btnSync";
			this.btnSync.Click += new EventHandler(this.btnSync_Click);
			// 
			// txtVerSWNew
			// 
			resources.ApplyResources(this.txtVerSWNew, "txtVerSWNew");
			this.txtVerSWNew.Name = "txtVerSWNew";
			this.txtVerSWNew.ReadOnly = true;
			// 
			// txtVerSWOld
			// 
			resources.ApplyResources(this.txtVerSWOld, "txtVerSWOld");
			this.txtVerSWOld.Name = "txtVerSWOld";
			this.txtVerSWOld.ReadOnly = true;
			// 
			// labVersioneSW
			// 
			resources.ApplyResources(this.labVersioneSW, "labVersioneSW");
			this.labVersioneSW.Name = "labVersioneSW";
			// 
			// groupBox3
			// 
			resources.ApplyResources(this.groupBox3, "groupBox3");
			this.groupBox3.Controls.Add(this.btnCalcolaNuova);
			this.groupBox3.Controls.Add(this.labNewVerRpt);
			this.groupBox3.Controls.Add(this.labNewVerSw);
			this.groupBox3.Controls.Add(this.btnVersioni);
			this.groupBox3.Controls.Add(this.txtVerReportNew);
			this.groupBox3.Controls.Add(this.txtVerReportOld);
			this.groupBox3.Controls.Add(this.labVersioneReport);
			this.groupBox3.Controls.Add(this.txtVerSWNew);
			this.groupBox3.Controls.Add(this.txtVerSWOld);
			this.groupBox3.Controls.Add(this.labVersioneSW);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.TabStop = false;
			// 
			// btnCalcolaNuova
			// 
			resources.ApplyResources(this.btnCalcolaNuova, "btnCalcolaNuova");
			this.btnCalcolaNuova.Name = "btnCalcolaNuova";
			this.btnCalcolaNuova.Click += new EventHandler(this.btnCalcolaNuova_Click);
			// 
			// labNewVerRpt
			// 
			resources.ApplyResources(this.labNewVerRpt, "labNewVerRpt");
			this.labNewVerRpt.Name = "labNewVerRpt";
			// 
			// labNewVerSw
			// 
			resources.ApplyResources(this.labNewVerSw, "labNewVerSw");
			this.labNewVerSw.Name = "labNewVerSw";
			// 
			// btnVersioni
			// 
			resources.ApplyResources(this.btnVersioni, "btnVersioni");
			this.btnVersioni.Name = "btnVersioni";
			this.btnVersioni.Click += new EventHandler(this.btnVersioni_Click);
			// 
			// txtVerReportNew
			// 
			resources.ApplyResources(this.txtVerReportNew, "txtVerReportNew");
			this.txtVerReportNew.Name = "txtVerReportNew";
			this.txtVerReportNew.ReadOnly = true;
			// 
			// txtVerReportOld
			// 
			resources.ApplyResources(this.txtVerReportOld, "txtVerReportOld");
			this.txtVerReportOld.Name = "txtVerReportOld";
			this.txtVerReportOld.ReadOnly = true;
			// 
			// labVersioneReport
			// 
			resources.ApplyResources(this.labVersioneReport, "labVersioneReport");
			this.labVersioneReport.Name = "labVersioneReport";
			// 
			// txtNThread
			// 
			resources.ApplyResources(this.txtNThread, "txtNThread");
			this.txtNThread.Name = "txtNThread";
			this.txtNThread.ReadOnly = true;
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Controls.Add(this.tabPage2);
			this.tabControl1.Controls.Add(this.tabPage3);
			resources.ApplyResources(this.tabControl1, "tabControl1");
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.NFileSelected);
			this.tabPage1.Controls.Add(this.chkFiltraGiornalieri);
			this.tabPage1.Controls.Add(this.groupBox1);
			this.tabPage1.Controls.Add(this.label1);
			this.tabPage1.Controls.Add(this.btnSync);
			this.tabPage1.Controls.Add(this.groupBox3);
			this.tabPage1.Controls.Add(this.btnCopia);
			this.tabPage1.Controls.Add(this.label2);
			this.tabPage1.Controls.Add(this.btnDiff);
			this.tabPage1.Controls.Add(this.groupBox2);
			this.tabPage1.Controls.Add(this.chkSP);
			this.tabPage1.Controls.Add(this.btnXMLFile);
			this.tabPage1.Controls.Add(this.label3);
			this.tabPage1.Controls.Add(this.lblNumero);
			this.tabPage1.Controls.Add(this.btnDirUff);
			this.tabPage1.Controls.Add(this.btnDeselAll);
			this.tabPage1.Controls.Add(this.btnDirTemp);
			this.tabPage1.Controls.Add(this.btnSelAll);
			this.tabPage1.Controls.Add(this.txtWeb);
			this.tabPage1.Controls.Add(this.checkList);
			this.tabPage1.Controls.Add(this.lblDiff);
			this.tabPage1.Controls.Add(this.txtDirDiff);
			this.tabPage1.Controls.Add(this.txtDirUff);
			resources.ApplyResources(this.tabPage1, "tabPage1");
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// NFileSelected
			// 
			resources.ApplyResources(this.NFileSelected, "NFileSelected");
			this.NFileSelected.Name = "NFileSelected";
			// 
			// chkFiltraGiornalieri
			// 
			resources.ApplyResources(this.chkFiltraGiornalieri, "chkFiltraGiornalieri");
			this.chkFiltraGiornalieri.Name = "chkFiltraGiornalieri";
			this.chkFiltraGiornalieri.UseVisualStyleBackColor = true;
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.btnScegli);
			this.tabPage2.Controls.Add(this.txtDescription);
			this.tabPage2.Controls.Add(this.label15);
			this.tabPage2.Controls.Add(this.txtMinVersioneSw);
			this.tabPage2.Controls.Add(this.label14);
			this.tabPage2.Controls.Add(this.label13);
			this.tabPage2.Controls.Add(this.txtLocalSQL);
			this.tabPage2.Controls.Add(this.txtNuovaVersione);
			this.tabPage2.Controls.Add(this.btnNewVer);
			this.tabPage2.Controls.Add(this.btnAnalizza);
			this.tabPage2.Controls.Add(this.btnUpdate);
			this.tabPage2.Controls.Add(this.tree);
			this.tabPage2.Controls.Add(this.txtSQLLocale);
			this.tabPage2.Controls.Add(this.txtSQLProduzione);
			this.tabPage2.Controls.Add(this.label12);
			this.tabPage2.Controls.Add(this.label11);
			resources.ApplyResources(this.tabPage2, "tabPage2");
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.UseVisualStyleBackColor = true;
			// 
			// btnScegli
			// 
			resources.ApplyResources(this.btnScegli, "btnScegli");
			this.btnScegli.Name = "btnScegli";
			this.btnScegli.UseVisualStyleBackColor = true;
			this.btnScegli.Click += new EventHandler(this.btnScegli_Click);
			// 
			// txtDescription
			// 
			resources.ApplyResources(this.txtDescription, "txtDescription");
			this.txtDescription.Name = "txtDescription";
			this.txtDescription.Leave += new EventHandler(this.txtDescription_Leave);
			// 
			// label15
			// 
			resources.ApplyResources(this.label15, "label15");
			this.label15.Name = "label15";
			// 
			// txtMinVersioneSw
			// 
			resources.ApplyResources(this.txtMinVersioneSw, "txtMinVersioneSw");
			this.txtMinVersioneSw.Name = "txtMinVersioneSw";
			// 
			// label14
			// 
			resources.ApplyResources(this.label14, "label14");
			this.label14.Name = "label14";
			// 
			// label13
			// 
			resources.ApplyResources(this.label13, "label13");
			this.label13.Name = "label13";
			// 
			// txtLocalSQL
			// 
			resources.ApplyResources(this.txtLocalSQL, "txtLocalSQL");
			this.txtLocalSQL.Name = "txtLocalSQL";
			this.txtLocalSQL.ReadOnly = true;
			// 
			// txtNuovaVersione
			// 
			resources.ApplyResources(this.txtNuovaVersione, "txtNuovaVersione");
			this.txtNuovaVersione.Name = "txtNuovaVersione";
			// 
			// btnNewVer
			// 
			resources.ApplyResources(this.btnNewVer, "btnNewVer");
			this.btnNewVer.Name = "btnNewVer";
			this.btnNewVer.UseVisualStyleBackColor = true;
			this.btnNewVer.Click += new EventHandler(this.btnNewVer_Click);
			// 
			// btnAnalizza
			// 
			resources.ApplyResources(this.btnAnalizza, "btnAnalizza");
			this.btnAnalizza.Name = "btnAnalizza";
			this.btnAnalizza.UseVisualStyleBackColor = true;
			this.btnAnalizza.Click += new EventHandler(this.btnAnalizza_Click);
			// 
			// btnUpdate
			// 
			resources.ApplyResources(this.btnUpdate, "btnUpdate");
			this.btnUpdate.Name = "btnUpdate";
			this.btnUpdate.UseVisualStyleBackColor = true;
			this.btnUpdate.Click += new EventHandler(this.btnUpdate_Click);
			// 
			// tree
			// 
			this.tree.AllowDrop = true;
			resources.ApplyResources(this.tree, "tree");
			this.tree.ContextMenuStrip = this.contextMenuStrip1;
			this.tree.ImageList = this.icons;
			this.tree.Name = "tree";
			this.tree.AfterSelect += new TreeViewEventHandler(this.tree_AfterSelect);
			this.tree.DragDrop += new DragEventHandler(this.treeView1_DragDrop);
			this.tree.DragEnter += new DragEventHandler(this.treeView1_DragEnter);
			// 
			// contextMenuStrip1
			// 
			this.contextMenuStrip1.Items.AddRange(new ToolStripItem[] {
				this.menuDescrizione,
				this.menuRinomina,
				this.menuElimina
			});
			this.contextMenuStrip1.Name = "contextMenuStrip1";
			resources.ApplyResources(this.contextMenuStrip1, "contextMenuStrip1");
			// 
			// menuDescrizione
			// 
			this.menuDescrizione.Name = "menuDescrizione";
			resources.ApplyResources(this.menuDescrizione, "menuDescrizione");
			this.menuDescrizione.Click += new EventHandler(this.menuDescrizione_Click);
			// 
			// menuRinomina
			// 
			this.menuRinomina.Name = "menuRinomina";
			resources.ApplyResources(this.menuRinomina, "menuRinomina");
			this.menuRinomina.Click += new EventHandler(this.menuRinomina_Click);
			// 
			// menuElimina
			// 
			this.menuElimina.Name = "menuElimina";
			resources.ApplyResources(this.menuElimina, "menuElimina");
			this.menuElimina.Click += new EventHandler(this.menuElimina_Click);
			// 
			// icons
			// 
			this.icons.ImageStream = ((ImageListStreamer) (resources.GetObject("icons.ImageStream")));
			this.icons.TransparentColor = System.Drawing.Color.Transparent;
			this.icons.Images.SetKeyName(0, "");
			this.icons.Images.SetKeyName(1, "");
			// 
			// txtSQLLocale
			// 
			resources.ApplyResources(this.txtSQLLocale, "txtSQLLocale");
			this.txtSQLLocale.Name = "txtSQLLocale";
			this.txtSQLLocale.ReadOnly = true;
			// 
			// txtSQLProduzione
			// 
			resources.ApplyResources(this.txtSQLProduzione, "txtSQLProduzione");
			this.txtSQLProduzione.Name = "txtSQLProduzione";
			this.txtSQLProduzione.ReadOnly = true;
			// 
			// label12
			// 
			resources.ApplyResources(this.label12, "label12");
			this.label12.Name = "label12";
			// 
			// label11
			// 
			resources.ApplyResources(this.label11, "label11");
			this.label11.Name = "label11";
			// 
			// tabPage3
			// 
			this.tabPage3.Controls.Add(this.nonaggiornati);
			resources.ApplyResources(this.tabPage3, "tabPage3");
			this.tabPage3.Name = "tabPage3";
			this.tabPage3.UseVisualStyleBackColor = true;
			// 
			// nonaggiornati
			// 
			resources.ApplyResources(this.nonaggiornati, "nonaggiornati");
			this.nonaggiornati.CheckOnClick = true;
			this.nonaggiornati.Name = "nonaggiornati";
			this.nonaggiornati.Sorted = true;
			this.nonaggiornati.ThreeDCheckBoxes = true;
			// 
			// openFile
			// 
			this.openFile.DefaultExt = "sql";
			resources.ApplyResources(this.openFile, "openFile");
			this.openFile.Multiselect = true;
			// 
			// frmGeneraLiveUpdate
			// 
			resources.ApplyResources(this, "$this");
			this.Controls.Add(this.tabControl1);
			this.Controls.Add(this.txtNThread);
			this.Controls.Add(this.lblFileXML);
			this.Name = "frmGeneraLiveUpdate";
			this.Closing += new CancelEventHandler(this.frmGeneraLiveUpdate_Closing);
			this.groupBox1.ResumeLayout(false);
			((ISupportInitialize) (this.DS)).EndInit();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			this.tabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tabPage1.PerformLayout();
			this.tabPage2.ResumeLayout(false);
			this.tabPage2.PerformLayout();
			this.contextMenuStrip1.ResumeLayout(false);
			this.tabPage3.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		/// <summary>
		/// Imposta le variabili di ambiente per il filtro, la cartella locale e per il sito web di riferimento in base
		///   al tipo di live update (dll/report)
		/// </summary>
		private void impostaAmbiente() {
			switch (m_TipoLiveUpdate) {
				case eTipoLiveUpdate.DLL_EXE:
					m_XMLFile = C_XMLFileDLL;
					m_WebDir = txtWeb.Text + "/" + C_WebDirDLL;
					m_LocalDir = txtLocalDLL.Text;
					m_Filter = "*.dll";
					break;
				case eTipoLiveUpdate.REPORT:
					m_XMLFile = C_XMLFileReport;
					m_WebDir = txtWeb.Text + "/" + C_WebDirReport;
					m_LocalDir = txtLocalReport.Text;
					m_Filter = "*.rpt";
					break;
				default:
					break;
			}
		}

		private void radioDLL_CheckedChanged(object sender, EventArgs e) {
			m_TipoLiveUpdate = eTipoLiveUpdate.DLL_EXE;
			pulisciCampi();
		}

		private void radioReport_CheckedChanged(object sender, EventArgs e) {
			m_TipoLiveUpdate = eTipoLiveUpdate.REPORT;
			pulisciCampi();
		}

		Hashtable ListaDiff = new Hashtable();

		private void btnDiff_Click(object sender, EventArgs e) {
			if (m_TipoLiveUpdate == eTipoLiveUpdate.UNKNOWN) {
				show("Selezionare il tipo di aggiornamento", "Attenzione",
					MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}

			if (txtWeb.Text.Trim() == "") {
				show("Impostare l'indirizzo web", "Attenzione",
					MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}

			//Azzera la cache per l'indice locale generato dalla funzione GenXML.GeneraFileXML
			GenXML.AzzeraIndicelocale();
			bool filtraOggi = chkFiltraGiornalieri.Checked;
			btnDiff.Visible = false;
			Application.DoEvents();
			UpdateDLLThread.EH += this.updateTxt;
			impostaAmbiente();

			Cursor.Current = Cursors.WaitCursor;
			txtNThread.Visible = true;

			//Genero il nuovo file indice  locale m_XMLFile nella cartella locale
			// Per dll: m_LocalDir= "E:\easy\mainform\bin\debug\"
			//          m_XMLFile = "fileindex.xml"
			//          m_Filter	"*.dll"	

			int K = metaprofiler.StartTimer("GeneraFileXML");
			//Crea easy\output\fileindex4.xml
			GenXML.GeneraFileXML(m_LocalDir, m_XMLFile, m_Filter, filtraOggi); // localDir= D:\\easy\\output\\
			metaprofiler.StopTimer(K);
			txtNThread.Visible = false;
			string[] rempath = new string[1];
			rempath[0] = txtWeb.Text.Trim();

			///Legge i numeri di versione dll e report remoti e sceglie il sito di liveupdate di riferimento come il più veloce
			int K2 = metaprofiler.StartTimer("new Download");

			var download = new Download(null, rempath, m_XMLFile, m_LocalDir);
			metaprofiler.StopTimer(K2);

			ListaDiff = new Hashtable();
			;
			// per dll:     dirdiff	"F:\\templiveupdateeasy\\zip\\"	
			string zipDirName = (IsNet45OrNewer() ? "zip4" : "zip");
			string dirdiff =
				XDir.Concat(txtDirDiff.Text, (radioDLL.Checked ? zipDirName : "report")); //D:\\software\\tempLU\\zip4\\
			int K3 = metaprofiler.StartTimer("GenDLLDiff");
			download.GenDLLDiff("differenze.xml", dirdiff, m_Filter, out ListaDiff);
			metaprofiler.StopTimer(K3);
			Cursor.Current = Cursors.Default;


			if (download.Connected) popolaListView(ListaDiff);
			UpdateDLLThread.EH -= this.updateTxt;
			btnXMLFile.Visible = true;
			btnCopia.Visible = false;
			btnVersioni.Visible = false;
			btnCalcolaNuova.Visible = false;
			NFileSelected.Text = checkList.CheckedItems.Count.ToString() + " file selezionati";
		}

		/// <summary>
		/// Popola la listview con l'elenco dei file, e nella cartella diff\temp tutti i file presenti in diff
		/// </summary>
		/// <param name="listafile"></param>
		private void popolaListView(Hashtable listafile) {
			checkList.Items.Clear();
			nonaggiornati.Items.Clear();
			if (!(listafile.Count > 0)) return;
			foreach (object obj in listafile.Keys) {
				string tipo = listafile[obj].ToString();
				if (tipo.StartsWith("!VECCHIO") || tipo.StartsWith("!MANCA")) {
					nonaggiornati.Items.Add(obj.ToString() + "\t" + tipo, true);
				}
				else {
					checkList.Items.Add(obj.ToString() + "\t" + tipo, true);
				}
			}

			if (nonaggiornati.Items.Count > 0) {
				show("Mancano file nella directory attuale, verificare attentamente prima di procedere",
					"Avviso");
			}

			int tot = checkList.Items.Count;
			if (tot == 1)
				lblNumero.Text = "Trovata 1 differenza";
			else
				lblNumero.Text = "Trovate " + tot + " differenze";

			//copia dei file da \diff in \diff\tmp
			string zipLocalDir = (IsNet45OrNewer() ? "zip4" : "zip");
			string dirdiff = XDir.Concat(txtDirDiff.Text, (radioDLL.Checked ? zipLocalDir : "report"));
			string dirtemp = XDir.Concat(dirdiff, C_TmpDir);
			var d = new DirectoryInfo(dirdiff);

			//dirdiff	"F:\\templiveupdateeasy\\zip\\"	
			//dirtemp  "F:\\templiveupdateeasy\\zip\\tmp\\"
			if (!Directory.Exists(dirtemp)) Directory.CreateDirectory(dirtemp);
			svuotaCartella(dirtemp);
			foreach (var f in d.GetFiles()) {
				if (f.Name == m_XMLFile + ".zip") continue;
				File.Copy(f.FullName, dirtemp + f.Name, true);
				Application.DoEvents();
			}
		}

		private void svuotaCartella(string path) {
			var d = new DirectoryInfo(path);
			foreach (var f in d.GetFiles()) {
				File.Delete(f.FullName);
			}
		}

		private void btnDirDLL_Click(object sender, EventArgs e) {
			string path = getFolder("Seleziona la cartella in cui si trovano le DLL da confrontare", txtLocalDLL.Text);
			if (path == null) return;
			txtLocalDLL.Text = path;
		}

		private void btnDirReport_Click(object sender, EventArgs e) {
			string path = getFolder("Seleziona la cartella in cui si trovano i report da confrontare",
				txtLocalReport.Text);
			if (path == null) return;
			txtLocalReport.Text = path;
		}

		private void btnDirSP_Click(object sender, EventArgs e) {
			string path = getFolder("Seleziona la cartella in cui si trovano le stored procedure da confrontare",
				txtLocalSP.Text);
			if (path == null) return;
			txtLocalSP.Text = path;
		}

		private void btnDirTemp_Click(object sender, EventArgs e) {
			string path = getFolder("Selezionare la cartella temporanea in cui verranno generati i file",
				txtDirDiff.Text);
			if (path == null) return;
			txtDirDiff.Text = path;
			aggiornaLabel();
		}

		private void btnDirUff_Click(object sender, EventArgs e) {
			string path = getFolder("Selezionare la cartella ufficiale del Live Update", txtDirUff.Text);
			if (path == null) return;
			txtDirUff.Text = path;
			txtLocalSQL.Text = txtDirUff.Text + "sql\\";
		}

		private string getFolder(string descrizione, string proposed) {
			var fd = new FolderBrowserDialog {
				SelectedPath = proposed,
				Description = descrizione
			};
			if (fd.ShowDialog() != DialogResult.OK) {
				fd.Dispose();
				return null;
			}

			var res = fd.SelectedPath + C_SLASH;
			fd.Dispose();
			return res;
		}

		private void aggiornaLabel() {
			lblDiff.Text = txtDirDiff.Text;
			lblFileXML.Text = txtDirDiff.Text;
		}

		/// <summary>
		/// Ottiene una hashtable con i nomi dei file non selezionati, associati alle versioni vecchie
		/// </summary>
		/// <returns></returns>
		private Hashtable getSkipList() {
			var list = new Hashtable();
			for (int i = 0; i < checkList.Items.Count; i++) {
				if (!checkList.GetItemChecked(i)) {
					string[] item = checkList.Items[i].ToString().Split('\t');
					//ignoro la nuova versione
					list.Add(item[0].Trim(), item[1].Trim());
				}
			}

			return list;
		}


		//private bool SPProcessed=false;
		private void btnXMLFile_Click(object sender, EventArgs e) {
			Cursor = Cursors.WaitCursor;
			btnXMLFile.Visible = false;
			var skiplist = getSkipList();
			string errori;
			impostaAmbiente();
			if (!GenXML.GeneraFileXML(m_LocalDir, m_XMLFile, m_Filter, skiplist, chkFiltraGiornalieri.Checked,
					out errori))
				//    MessageBox.Show("File XML generato con successo", "Generazione file XML",
				//        MessageBoxButtons.OK, MessageBoxIcon.Information);
				//else
				show($"Sono stati riscontrati i seguenti errori nella generazione:\r\n{errori}",
					"Generazione file XML",
					MessageBoxButtons.OK,
					MessageBoxIcon.Information);
			Cursor = Cursors.Default;

			aggiornaCartellaDiff();

			btnCopia.Visible = false;
			btnVersioni.Visible = true;
			btnCalcolaNuova.Visible = true;
			return;
		}

		private void aggiornaCartellaDiff() {
			string lasttemp = "";
			string zipLocalDir = (IsNet45OrNewer() ? "zip4" : "zip");

			string dirdiff = XDir.Concat(txtDirDiff.Text, (radioDLL.Checked ? zipLocalDir : "report"));
			string dirtemp = XDir.Concat(dirdiff, C_TmpDir);
			try {
				for (int i = 0; i < checkList.Items.Count; i++) {
					string[] item = checkList.Items[i].ToString().Split('\t');
					string fname = dirdiff + item[0] + ".zip";
					string fnametmp = dirtemp + item[0] + ".zip";
					if (checkList.GetItemChecked(i)) {
						//se è selezionato copio il file da tmp in diff
						lasttemp = "Sposto " + fnametmp + " in " + fname;
						File.Copy(fnametmp, fname, true);
					}
					else {
						//altrimenti lo rimuovo dalla cartella diff
						lasttemp = "Sposto " + fname + " in " + fnametmp;
						//se il sorgente non esiste vuol dire che è stato
						//deselezionato in precedenza
						if (!File.Exists(fname)) continue;
						//è stato deselezionato, lo elimino da diff
						if (File.Exists(fnametmp)) File.Delete(fnametmp);
						//e lo sposto in tmp
						File.Move(fname, fnametmp);
					}

					Application.DoEvents();
				}

				lasttemp = "Copia del fileindex appena generato in " + dirdiff;
				File.Copy(m_LocalDir + @"\" + m_XMLFile + ".zip", dirdiff + m_XMLFile + ".zip", true);
			}
			catch (Exception e) {
				show(lasttemp + " - " + "Errore: " + e.Message, "Errore",
					MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		//seleziona tutto
		private void btnSelAll_Click(object sender, EventArgs e) {
			for (int j = 0; j < checkList.Items.Count; j++) {
				checkList.SetItemChecked(j, true);
			}

			NFileSelected.Text = checkList.CheckedItems.Count.ToString() + " file selezionati";
		}

		//deseleziona tutto
		private void btnDeselAll_Click(object sender, EventArgs e) {
			for (int j = 0; j < checkList.Items.Count; j++) {
				checkList.SetItemChecked(j, false);
			}

			NFileSelected.Text = checkList.CheckedItems.Count.ToString() + " file selezionati";
		}

		private void frmGeneraLiveUpdate_Closing(object sender, CancelEventArgs e) {
			archivia();
		}

		private void btnCopia_Click(object sender, EventArgs e) {
			if (txtDirDiff.Text.Trim() == "") {
				show("Specificare la cartella temporanea", "Copia",
					MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}

			if (txtDirUff.Text.Trim() == "") {
				show("Specificare la cartella ufficiale", "Copia",
					MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}

			if (txtDirDiff.Text.Trim().ToLower() == txtDirUff.Text.Trim().ToLower()) {
				show("Le cartelle sorgente/destinazioni sono uguali", "Copia",
					MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}

			////if (MessageBox.Show("Confermi la copia dei file generati?","Copia",
			////    MessageBoxButtons.YesNoCancel,MessageBoxIcon.Question)!=DialogResult.Yes) 
			////    return;
			string errori = copia();
			if (errori == null || errori == "") {
				btnCopia.Visible = false;
				return;
			}

			show("Errori riscontrati durante la copia:\r\r", "Attenzione",
				MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
		}

		private string doCopy(string sourcedir, string destdir, string indexname) {
			string msg = null;
			XDir.CheckCreate(destdir);
			var D = new DirectoryInfo(sourcedir);
			foreach (var F in D.GetFiles("*.zip")) {
				if (F.Name.StartsWith(indexname)) continue;
				string s = XFile.Copia(F.FullName, destdir + F.Name, true);
				Application.DoEvents();
				if (s == null) continue;
				//errore....
				msg += "Impossibile copiare il file " + F.Name + " - Msg: " + s;
			}

			XFile.Copia(sourcedir + indexname, txtDirUff.Text + indexname, true);
			return msg;
		}

		private string copia() {
			string dllFileIndex, dllDir;
			if (IsNet45OrNewer()) {
				dllDir = @"zip4";
				dllFileIndex = @"fileindex4.xml.zip";
			}
			else {
				dllDir = @"zip";
				dllFileIndex = @"fileindex.xml.zip";
			}

			string reportFileIndex = @"reportindex.xml.zip", reportDir = @"report\";

			//copio dll o report
			string sourcedir = XDir.Concat(txtDirDiff.Text, (radioDLL.Checked ? dllDir : reportDir));
			string destdir = XDir.Concat(txtDirUff.Text, (radioDLL.Checked ? dllDir : reportDir));
			string index = (radioDLL.Checked ? dllFileIndex : reportFileIndex);

			var msg = doCopy(sourcedir, destdir, index);

			//if (chkSP.Checked) {
			//    //copio stored procedure
			//    sourcedir=XDir.Concat(txtDirDiff.Text,"sp");
			//    destdir=XDir.Concat(txtDirUff.Text,"sp");
			//    index="spindex.xml.zip";
			//    msg+=doCopy(sourcedir,destdir,index);
			//}
			return msg;
		}

		private void btnSync_Click(object sender, EventArgs e) {
			string file = Application.StartupPath + @"\LiveUpdateSync.exe";
			if (!File.Exists(file)) return;
			runProcess(file, true);
		}


		private void aggiornaVersione(string newVersion, string tipo) {
			if (newVersion.Trim() == "") return;
			TextBox txtNew = null;
			string filename = null;
			string oldversion = "";
			string dir = XDir.CheckFinalSlash(txtDirUff.Text);
			string tipoversione = null;
			switch (tipo.ToUpper()) {
				case "S":
					txtNew = txtVerSWNew;
					oldversion = txtVerSWOld.Text;
					filename = dir + (IsNet45OrNewer() ? "versionesw4.txt" : "versionesw.txt");
					tipoversione = " software";
					break;
				case "R":
					txtNew = txtVerReportNew;
					oldversion = txtVerReportOld.Text;
					filename = dir + "versionereport.txt";
					tipoversione = "dei report";
					break;
			}

			if (filename == null) return;
			XFile.EliminaSolaLettura(filename);
			if (oldversion.CompareTo(newVersion) >= 0) {
				if (show(
					    "La versione " + newVersion + tipoversione +
					    " risulta minore o uguale di quella corrente. Continuare?",
					    "Attenzione", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) != DialogResult.Yes) {
					txtNew.Text = "";
					return;
				}
			}

			//else {
			//    if (MessageBox.Show("La versione "+tipoversione+" verrà aggiornata. Continuare?",
			//        "Attenzione",MessageBoxButtons.YesNoCancel,MessageBoxIcon.Question)!=DialogResult.Yes) {
			//        txtNew.Text="";
			//        return;
			//    }
			//}
			var write = new StreamWriter(filename, false, Encoding.ASCII);
			write.WriteLine(newVersion);
			write.Close();
			caricaVersioni();
		}

		string createNewPiece(int n, int size) {
			return n.ToString("D" + size);
		}

		int getIntFromPiece(string piece) {
			string removeStartingZeroes = piece.TrimStart('0');
			if (removeStartingZeroes == "" || removeStartingZeroes == "0") return 0;
			return Convert.ToInt32(piece);
		}

		bool isMaxForPiece(string piece) {
			for (int i = 0; i < piece.Length; i++) {
				if (piece[i] != '9') return false;
			}

			return true;
		}

		string getNuovaVersione(string versione) {
			string[] pieces = versione.Split('.');
			string[] newpieces = versione.Split('.');
			for (int i = pieces.Length - 1; i >= 0; i--) {
				string piece = pieces[i];
				int pieceSize = piece.Length;
				if (isMaxForPiece(piece)) {
					newpieces[i] = createNewPiece(1, pieceSize);
				}
				else {
					newpieces[i] = createNewPiece(getIntFromPiece(piece) + 1, pieceSize);
					break;
				}

			}

			return String.Join(".", newpieces);
		}

		private void btnCalcolaNuova_Click(object sender, EventArgs e) {
			string vecchiaVersione = radioDLL.Checked ? txtVerSWNew.Text : txtVerReportNew.Text;
			if (vecchiaVersione == "") {
				vecchiaVersione = radioDLL.Checked ? txtVerSWOld.Text : txtVerReportOld.Text;
			}

			if (radioDLL.Checked) {
				txtVerSWNew.Text = getNuovaVersione(vecchiaVersione);
			}
			else {
				txtVerReportNew.Text = getNuovaVersione(vecchiaVersione);
			}

			btnCalcolaNuova.Visible = false;
		}

		private void btnVersioni_Click(object sender, EventArgs e) {
			aggiornaVersione(txtVerSWNew.Text, "S");
			aggiornaVersione(txtVerReportNew.Text, "R");
			btnCopia.Visible = true;
			btnDiff.Visible = false;
			btnXMLFile.Visible = false;
			btnVersioni.Visible = false;
			btnCalcolaNuova.Visible = false;
		}

		public static object TXTlock = new object();


		private void updateTxt(object sender, EventArgs e) {
			var NN = sender as UpdateDLLThread.NThreadsDLL;
			if (NN == null) return;
			lock (TXTlock) {
				txtNThread.Text = NN.N.ToString() + "/" + UpdateDLLThread.NMaxThread.ToString();
				txtNThread.Update();

			}
		}

		private void checkList_Click(object sender, EventArgs e) {
			btnXMLFile.Visible = true;
			NFileSelected.Text = checkList.CheckedItems.Count.ToString() + " file selezionati";
		}



		private void treeView1_DragDrop(object sender, DragEventArgs e) {
			if (tree.SelectedNode == null) return;
			var tn = tree.SelectedNode;
			if (tn.Level > 0) tn = tn.Parent;
			string fdest = txtLocalSQL.Text + "\\" + tn.Text;
			if (e.Data.GetDataPresent(DataFormats.FileDrop)) {
				string[] filePaths = (string[]) (e.Data.GetData(DataFormats.FileDrop));
				foreach (string fileLoc in filePaths) {
					// Code to read the contents of the text file
					if (File.Exists(fileLoc)) {
						var IF = new FileInfo(fileLoc);
						File.Move(fileLoc, fdest + "\\" + IF.Name);
						tn.Nodes.Add(IF.Name);
					}

				}
			}

		}

		private void treeView1_DragEnter(object sender, DragEventArgs e) {
			if (e.Data.GetDataPresent(DataFormats.FileDrop)) {
				e.Effect = DragDropEffects.Copy;
			}
			else {
				e.Effect = DragDropEffects.None;
			}
		}

		private void btnAnalizza_Click(object sender, EventArgs e) {
			btnAnalizza.Visible = false;
			Application.DoEvents();
			var toSkip = new List<string>();

			string[] rempath = new string[1];
			rempath[0] = txtWeb.Text.Trim();
			var h = new LiveUpdate.Http(rempath, AppDomain.CurrentDomain.BaseDirectory);
			string sql_rem = h.DownloadData("versionedb.txt");
			h.DownloadFile("sql\\scriptindex.xml.zip", "localscriptindex.xml.zip");
			LiveUpdate.XZip.ExtractFiles("localscriptindex.xml.zip",
				AppDomain.CurrentDomain.BaseDirectory + "\\remote\\", "*", true, true);

			var Drem = new DataSet();
			Drem.ReadXml(AppDomain.CurrentDomain.BaseDirectory + "\\remote\\scriptindex.xml");

			var Dloc = new DataSet();
			Dloc.ReadXml(txtLocalSQL.Text + "scriptindex.xml");

			var tloc = Dloc.Tables["updatedbversion"];
			var trem = Drem.Tables["updatedbversion"];
			var QHC = new CQueryHelper();
			tree.Nodes.Clear();

			foreach (DataRow rRem in trem.Rows) {
				toSkip.Add(rRem["versionname"].ToString());
			}

			foreach (var r in tloc.Select(null, "versionname asc")) {
				if (toSkip.Contains(r["versionname"].ToString())) continue;
				//if (trem.Select(QHC.CmpEq("versionname",r["versionname"])).Length>0) continue;
				var n = tree.Nodes.Add(r["versionname"].ToString());
				n.ToolTipText = r["description"].ToString();
				string[] script = r["scriptlist"].ToString().Split(new char[] {';'});
				foreach (string scrname in script) {
					var x = n.Nodes.Add(scrname);
				}

				toSkip.Add(n.Text);
				Application.DoEvents();
			}

			string vermax = tloc.Compute("max(versionname)", null).ToString();
			string maxswversion = tloc.Compute("max(swversion)", null).ToString();
			txtMinVersioneSw.Text = maxswversion;


			//Aggiunge le directory presenti in più
			var DI = new DirectoryInfo(txtLocalSQL.Text);
			foreach (var D in DI.GetDirectories()) {
				string dirname = D.Name;
				if (toSkip.Contains(dirname)) continue;
				if (dirname.StartsWith("_")) continue;
				var d = tree.Nodes.Add(dirname);
				foreach (var f in D.GetFiles("*.sql")) {
					d.Nodes.Add(f.Name);
				}

				if (dirname.CompareTo(vermax) > 0) vermax = dirname;
			}

			calcolaNuovaVersione(vermax);
			btnAnalizza.Visible = true;
			Dloc.Dispose();
			Drem.Dispose();
		}

		int maxformodel(string model) {
			int len = model.Length;
			string rr = "9".PadLeft(len, '9');
			return int.Parse(rr);
		}

		string calcolaNuovaVersione(string vermax) {
			string[] c_123 = vermax.Split(new char[] {'.'});
			int c1 = Convert.ToInt32(c_123[0].TrimStart(new char[] {'0'}));
			int c2 = Convert.ToInt32(c_123[1].TrimStart(new char[] {'0'}));
			int c3 = Convert.ToInt32(c_123[2].TrimStart(new char[] {'0'}));
			if (c3 < maxformodel(c_123[2])) {
				c3++;
			}
			else {
				c3 = 1;
				if (c2 < maxformodel(c_123[1])) {
					c2++;
				}
				else {
					c2 = 1;
					c1++;
				}
			}

			string newver = c1.ToString().PadLeft(c_123[0].Length, '0') + "."
			                                                            + c2.ToString().PadLeft(c_123[1].Length, '0') +
			                                                            "."
			                                                            + c3.ToString().PadLeft(c_123[2].Length, '0');
			txtNuovaVersione.Text = newver;
			return newver;
		}

		List<string> versionsToDeleteInXml = new List<string>();

		private void menuRinomina_Click(object sender, EventArgs e) {
			var tn = tree.SelectedNode;
			if (tn == null) return;
			var f = new FrmAskName(tn.Text);
			if (f.ShowDialog(this) != DialogResult.OK) {
				f.Dispose();
				return;
			}

			if (tn.Level == 0) {
				Directory.Move(txtLocalSQL.Text + "\\" + tn.Text, txtLocalSQL.Text + "\\" + f.txtName.Text);
				versionsToDeleteInXml.Add(tn.Text);
				tn.Text = f.txtName.Text;
			}
			else {
				var tpar = tn.Parent;
				string dir = txtLocalSQL.Text + "\\" + tpar.Text;
				File.Move(dir + "\\" + tn.Text, dir + "\\" + f.txtName.Text);
				tn.Text = f.txtName.Text;
			}

			f.Dispose();
		}



		private void menuElimina_Click(object sender, EventArgs e) {
			var tn = tree.SelectedNode;
			if (tn == null) return;

			if (tn.Level == 0) {
				if (show("Cancello la cartella " + tn.Text + "?", "Conferma", MessageBoxButtons.OKCancel) !=
				    DialogResult.OK) return;
				Directory.Delete(txtLocalSQL.Text + "\\" + tn.Text, true);
				versionsToDeleteInXml.Add(tn.Text);
				tree.Nodes.Remove(tn);
			}
			else {
				if (show("Cancello il file " + tn.Text + "?", "Conferma", MessageBoxButtons.OKCancel) !=
				    DialogResult.OK) return;
				var tpar = tn.Parent;
				string dir = txtLocalSQL.Text + "\\" + tpar.Text;
				File.Delete(dir + "\\" + tn.Text);
				tpar.Nodes.Remove(tn);
			}
		}

		string rigeneraXmlIndex() {
			var Dloc = new DataSet();
			try {
				Dloc.ReadXml(txtLocalSQL.Text + "scriptindex.xml");
			}
			catch (Exception e) {
				QueryCreator.ShowException(this, "Errore nella lettura di scriptindex.xml", e);
				Dloc.Dispose();
				return null;
			}

			Application.DoEvents();
			var tloc = Dloc.Tables["updatedbversion"];

			var QHC = new CQueryHelper();

			//Elimina da tloc le versioni rinominate o cancellate
			foreach (string toDel in versionsToDeleteInXml) {
				DataRow[] rr = tloc.Select(QHC.CmpEq("versionname", toDel));
				if (rr.Length == 0) continue;
				rr[0].Delete();
			}

			//Aggiunge  o aggiorna i nodi presenti nel tree a tloc
			foreach (TreeNode tn in tree.Nodes) {
				DataRow[] rr = tloc.Select(QHC.CmpEq("versionname", tn.Text));
				DataRow r;
				if (rr.Length == 0) {
					r = tloc.NewRow();
					r["versionname"] = tn.Text;
					tloc.Rows.Add(r);
				}
				else {
					r = rr[0];
				}

				string scrlist = "";
				var ls = new List<string>();
				foreach (TreeNode tc in tn.Nodes) {
					ls.Add(tc.Text);
				}

				ls.Sort();
				scrlist = string.Join(";", ls.ToArray());
				r["scriptlist"] = scrlist;
				r["description"] = tn.ToolTipText;
				r["flagadmin"] = 0;
				r["swversion"] = txtMinVersioneSw.Text;
			}

			try {
				Dloc.WriteXml(txtLocalSQL.Text + "scriptindex.xml", XmlWriteMode.IgnoreSchema);
			}
			catch (Exception e) {
				Dloc.Dispose();
				QueryCreator.ShowException(this, "Errore nella scrittura di scriptindex.xml", e);
				return null;
			}

			Dloc.Dispose();
			Application.DoEvents();
			updateZippedSqlFiles();
			return tloc.Compute("max(versionname)", null).ToString();

		}

		private void menuDescrizione_Click(object sender, EventArgs e) {
			var tn = tree.SelectedNode;
			if (tn == null) return;
			var f = new FrmAskName(tn.ToolTipText);
			if (f.ShowDialog(this) != DialogResult.OK) {
				f.Dispose();
				return;
			}

			if (tn.Level == 0) {
				tn.ToolTipText = f.txtName.Text;
			}

			f.Dispose();
		}

		private bool updatingScript = false;

		private void btnUpdate_Click(object sender, EventArgs e) {
			if (updatingScript) return;
			updatingScript = true;
			btnUpdate.Visible = false;
			string newver = rigeneraXmlIndex();
			aggiornaVersioneDb(newver);
			updatingScript = false;
			btnUpdate.Visible = true;
		}

		private void tree_AfterSelect(object sender, TreeViewEventArgs e) {
			var tn = e.Node;
			if (tn.Level > 0) tn = tn.Parent;
			txtDescription.Text = tn.ToolTipText;
		}

		private void txtDescription_Leave(object sender, EventArgs e) {
			var tn = tree.SelectedNode;
			if (tn == null) return;
			if (tn.Level > 0) tn = tn.Parent;
			tn.ToolTipText = txtDescription.Text;
		}

		private void btnNewVer_Click(object sender, EventArgs e) {
			btnNewVer.Visible = false;
			var n = tree.Nodes.Add(txtNuovaVersione.Text);
			tree.SelectedNode = n;
			Directory.CreateDirectory(txtLocalSQL.Text + "\\" + txtNuovaVersione.Text);
			calcolaNuovaVersione(txtNuovaVersione.Text);
			btnNewVer.Visible = true;
		}

		void updateZippedSqlFiles() {
			foreach (TreeNode tn in tree.Nodes) {
				string dir = txtLocalSQL.Text + "\\" + tn.Text;
				foreach (TreeNode ts in tn.Nodes) {
					string fname = dir + "\\" + ts.Text;
					string fzip = fname.Replace(".sql", ".zip");

					var f_info = new FileInfo(fname);
					var z_info = new FileInfo(fzip);

					if (z_info.Exists && z_info.LastWriteTime > f_info.LastWriteTime) continue;
					utility.XZip.AddFiles(fzip, dir, ts.Text, true, false);
					Application.DoEvents();
				}
			}

			try {
				utility.XZip.AddFiles(txtLocalSQL.Text + "\\scriptindex.xml.zip", txtLocalSQL.Text, "scriptindex.xml",
					true, false);
			}
			catch (Exception e) {
				QueryCreator.ShowException(this, "Errore nella scrittura di scriptindex.xml.zip", e);
			}
		}

		private void btnScegli_Click(object sender, EventArgs e) {
			if (tree.SelectedNode == null) return;
			if (openFile.ShowDialog(this) != DialogResult.OK) return;
			var tn = tree.SelectedNode;
			if (tn.Level > 0) tn = tn.Parent;
			string fdest = txtLocalSQL.Text + "\\" + tn.Text;

			foreach (string fileLoc in openFile.FileNames) {
				var IF = new FileInfo(fileLoc);
				File.Move(fileLoc, fdest + "\\" + IF.Name);
				tn.Nodes.Add(IF.Name);
			}
		}

		private void checkList_SelectedValueChanged(object sender, EventArgs e) {
			NFileSelected.Text = checkList.CheckedItems.Count.ToString() + " file selezionati";
		}
	}

}
