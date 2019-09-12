/*
    Easy
    Copyright (C) 2019 Universit� degli Studi di Catania (www.unict.it)

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
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using System.Windows.Forms;
using LiveUpdate;//LiveUpdate
using System.IO;
using System.Xml.XPath;
using utility;
using metadatalibrary;
using download;
using Xceed.Compression;
//using Xceed.Ftp;
using Xceed.Zip;
using Xceed.Utils;
using Xceed.FileSystem;


namespace GeneraLiveUpdateForServices {

  

    /*
    switch (m_TipoLiveUpdate) {
 
    break;
    case eTipoLiveUpdate.EASYWEB_DLL_FILE:
  
    break;
    case eTipoLiveUpdate.REPORTING_SERVICES:
   
    break;
    default:
    break;
}

    */



    //m_XMLFile = C_XMLFileDLL;
    //m_WebDir = txtWeb_SDI.Text + "/" + C_WebDirDLL;
    //m_LocalDir = txtLocalDLL_sdi.Text;
   

    public partial class Frm_GeneraLiveUpdateForServices :Form {

        [STAThread]
        static void Main(string[] args) {
            Frm_GeneraLiveUpdateForServices F = new Frm_GeneraLiveUpdateForServices();
            try {
                Application.Run(F);
            }
            catch (Exception e) {
                //Impossibile trovare una parte del percorso 'D:\software\tempLuServices\zip\tmp\App_Code\AssemblyInfo.cs.zip'.
                MetaData.mainLogError(null, null, "Errore non gestito nell'esecuzione dell'applicazione.\r\n" + e.Message, e);
            }
            F.Dispose(true);
        }


        //m_Filter = "*.dll";

        public configLiveUpdate getConfig() {
            var lu = currLuType();
            switch (lu) {
                case Frm_GeneraLiveUpdateForServices.eTipoLiveUpdate.EASYWEB:return new EasyWebConfig(getWebAddress());
                case Frm_GeneraLiveUpdateForServices.eTipoLiveUpdate.PAYMENT:return new EasyPaymentConfig(getWebAddress());
                case Frm_GeneraLiveUpdateForServices.eTipoLiveUpdate.MULTISDI:return new EasyMultiSdiConfig(getWebAddress());
                case Frm_GeneraLiveUpdateForServices.eTipoLiveUpdate.PORTALE:return new PortaleConfig(getWebAddress());
                case Frm_GeneraLiveUpdateForServices.eTipoLiveUpdate.REPORTING_SERVICES:return new ReportingServicesConfig(getWebAddress());
                case Frm_GeneraLiveUpdateForServices.eTipoLiveUpdate.SDI: return new SdiConfig(getWebAddress());
                case Frm_GeneraLiveUpdateForServices.eTipoLiveUpdate.WEBPROT:return new WebProtConfig(getWebAddress());
                default: return null;

            }
        }


        private IContainer components;

        private Dictionary<eTipoLiveUpdate, string> serviceName = new Dictionary<eTipoLiveUpdate, string>() {
            { eTipoLiveUpdate.PORTALE , "portale"},
            { eTipoLiveUpdate.SDI , "sdi"},
            { eTipoLiveUpdate.WEBPROT , "webprot"},
            { eTipoLiveUpdate.EASYWEB , "easyweb"},
            { eTipoLiveUpdate.PAYMENT , "payment"},
            { eTipoLiveUpdate.REPORTING_SERVICES , "reportingservices"},
            {  eTipoLiveUpdate.MULTISDI , "multisdi"}
        };

        public enum eTipoLiveUpdate {
            PORTALE,
            SDI,
            WEBPROT,
            EASYWEB,
            PAYMENT,
            REPORTING_SERVICES,
            MULTISDI,
            UNKNOWN
        };
        //private eTipoLiveUpdate m_TipoLiveUpdate = eTipoLiveUpdate.UNKNOWN;

        //public string C_XMLFileDLL = "servicefileindex.xml";
        //const string C_XMLFileReport = "servicereportindex.xml";
        //public string C_WebDirDLL = "zip";
        //const string C_WebDirReport = "report";
        const string C_TmpDir = "tmp";
        const string C_SLASH = @"\";

        public string C_SQLFileIndex = "scriptindex.xml";
        public string m_SQLFile;
        public string m_SQLWebDir;

        /// <summary>
        /// indirizzo web per l'indice remoto
        /// </summary>
		//private string m_WebDir;

        /// <summary>
        /// Percorsi locale per l'indice 
        /// </summary>
		//private string m_XMLFile;

        /// <summary>
        /// Cartella locale per l'aggiornamento
        /// </summary>
		//private string m_LocalDir;

        /// <summary>
        /// Filtro per i file da aggiornare
        /// </summary>
		//private string m_Filter = "*.rdl";
        private string m_IndexFileName = "";

        public Frm_GeneraLiveUpdateForServices() {
            InitializeComponent();
            //
            // TODO: Add any constructor code after InitializeComponent call
            //
            Init();
        }

        Dictionary<string, eTipoLiveUpdate> tipoPerNome = new Dictionary<string, eTipoLiveUpdate>();
        private void Init() {
            m_IndexFileName = Application.StartupPath + @"\genliveupdateforservices.xml";
            //m_XMLFile = null;
            //m_WebDir = null;
            //m_LocalDir = null;
            currConfig = null;
            MetaData.SetColor(this, true);
            DS.Clear();
            foreach (string service in serviceName.Values) {
                string colName = "dir_" + service;           
                if (!DS.config.Columns.Contains(colName)) DS.config.Columns.Add(colName, typeof(string));
            }

            if (!File.Exists(m_IndexFileName)) Archivia();
            DS.ReadXml(m_IndexFileName);
            txtWeb_main.Text = DS.config.Rows[0]["dirweb_main"].ToString();

            txtDirDiff.Text = DS.config.Rows[0]["dirdiff"].ToString();

            txtDirUff_main.Text = DS.config.Rows[0]["diruff_main"].ToString();

            foreach (string service in serviceName.Values) {
                var txtFolder = getTextBoxFolderByServiceName(service);
                string colName = "dir_" + service;              
                txtFolder.Text = DS.config.Rows[0][colName].ToString();
                XDir.CheckCreate(txtFolder.Text);
            }
            
            foreach (string service in serviceName.Values) {
                XDir.CheckCreate(Path.Combine(txtDirUff_main.Text,service));
            }

            XDir.Svuota(txtDirDiff.Text, true);
            XDir.CheckCreate(txtDirDiff.Text + "zip");

            radio_Dummy.Checked = true;
            foreach (RadioButton R in gboxTipoAggiornamento.Controls) {
                R.CheckedChanged += radio_CheckedChanged;
            }
            foreach (object O in gboxCartelle.Controls) {
                Button b=  O as Button;
                if (b==null)continue;
                b.Click += folderBottonClick;
            }
            radio_CheckedChanged(null,null);
            foreach (var x in serviceName) tipoPerNome[x.Value] = x.Key;
        }


        private void Archivia() {
            if (DS.config.Rows.Count == 0) {
                DS.config.Rows.Add(DS.config.NewRow());
            }
            DS.config.Rows[0]["dirweb_main"] = txtWeb_main.Text;
            foreach (string service in serviceName.Values) {
                var txtFolder = getTextBoxFolderByServiceName(service);
                DS.config.Rows[0]["dir_" + service]=txtFolder.Text;                
            }

            DS.config.Rows[0]["dirdiff"] = txtDirDiff.Text;
            DS.config.Rows[0]["diruff_main"] = txtDirUff_main.Text;


            //DS.config.Rows[0]["dirsp"] = txtLocalSP.Text;
            DS.WriteXml(m_IndexFileName);
        }
        private void frmGeneraLiveUpdateForService_Closing(object sender, System.ComponentModel.CancelEventArgs e) {
            Archivia();
        }
        public static object TXTlock = new object();


        private void UpdateTxt(object sender, EventArgs e) {
            UpdateDLLThread.NThreadsDLL NN = sender as UpdateDLLThread.NThreadsDLL;
            if (NN == null) return;
            lock (TXTlock) {
                txtNThread.Text = NN.N.ToString() + "/" + UpdateDLLThread.NMaxThread.ToString();
                txtNThread.Update();

            }
        }

        eTipoLiveUpdate currLuType() {
            foreach (RadioButton r in gboxTipoAggiornamento.Controls) {
                if (r == null) continue;
                if (!r.Checked)continue;
                if (r.Tag==null)   return eTipoLiveUpdate.UNKNOWN;;
                return tipoPerNome[r.Tag.ToString()];
            }
            return eTipoLiveUpdate.UNKNOWN;
        }
        private configLiveUpdate currConfig = null;
        /// <summary>
        /// Imposta le variabili di ambiente per il filtro, la cartella locale e per il sito web di riferimento in base
        ///   al tipo di live update (dll/report)
        /// </summary>
        private void ImpostaAmbiente() {
            currConfig = getConfig();
          
        }

        
        private void PulisciCampi() {
            //bool report = !software;
            checkList.Items.Clear();
            lblNumero.Text = "";
            btnDiff.Visible = true;
            btnXMLFile.Visible = false;
            btnCopia.Visible = false;
            btnVersioni.Visible = false;
            btnCalcolaNuova.Visible = false;

            //labVersioneReport.Visible = report;
            //labNewVerRpt.Visible = report;
            //txtVerReportNew.Visible = report;
            //txtVerReportOld.Visible = report;

            labVersioneSW.Visible = true;
            labNewVerSw.Visible = true;
            txtVerSWNew.Visible = true;
            txtVerSWOld.Visible = true;

            GenXML.AzzeraIndicelocale();
        }

        Hashtable ListaDiff = new Hashtable();

        private void btnDiff_Click(object sender, EventArgs e) {
            if (currLuType() == eTipoLiveUpdate.UNKNOWN) {
                MessageBox.Show("Selezionare il tipo di aggiornamento", "Attenzione",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            //Cartella remota specifica di quel servizio
            string webAddr = getWebAddress(); //http://www.temposrl.it/easyservices/reportingservices/
            if(webAddr== "") {
                MessageBox.Show($"Impostare l'indirizzo web per il servizio {currLuType()}", "Attenzione",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
         

            //Azzera la cache per l'indice locale generato dalla funzione GenXML.GeneraFileXML
            GenXML.AzzeraIndicelocale();
            bool filtraOggi = chkFiltraGiornalieri.Checked;
            btnDiff.Visible = false;
            Application.DoEvents();
            UpdateDLLThread.EH += this.UpdateTxt;
            ImpostaAmbiente(); //Crea una configurazione pulita, inclusa quella dei file da saltare (filesToSkip)

            Cursor.Current = Cursors.WaitCursor;
            txtNThread.Visible = true;

            //Genero il nuovo file indice  locale m_XMLFile nella cartella locale
            // Per dll: m_LocalDir= "E:\easy\mainform\bin\debug\"
            //          m_XMLFile = "fileindex.xml"
            //          m_Filter	"*.dll"	

            int K = metaprofiler.StartTimer("GeneraFileXML");
            string error;
            //genera l'indice dei file nella cartella di riferimento (per es. d:\easy\output o Y:\reportnonzippati\ )
            bool res = GenXML.GeneraFileIndiceGenerico(getLocalDirectory(), currConfig.xmlFile, currConfig.subDirectories,
                currConfig.filesToSkip, currConfig.filter, currConfig.allowedExtensions, filtraOggi, out error);
            metaprofiler.StopTimer(K);
            txtNThread.Visible = false;
            string[] rempath = new string[1];
            rempath[0] = txtWeb_main.Text.Trim();

         
            
            ///Legge i numeri di versione dll e report remoti e sceglie il sito di liveupdate di riferimento come il più veloce
            int K2 = metaprofiler.StartTimer("new Download");
            Download download = new Download(null, rempath, currConfig.xmlFile, getLocalDirectory(), serviceName[currLuType()]);//localDir diventa la TargetDir per la creazione dei file differenze
            metaprofiler.StopTimer(K2);
            
            ListaDiff = new Hashtable(); ;
            // per dll:     dirdiff	"F:\\templiveupdateeasy\\zip\\"	
            // servizi:         D:\\software\\tempLuServices\\zip\\
            string dirdiff = getDestDiffDir();
            int K3 = metaprofiler.StartTimer("GenDLLDiff");

            //genera un file locale delle differenze chiamato come il file dell'indice ossia currConfig.xmlFile
            // nella cartella dirDiff = D:\\software\\tempLuServices\\zip\\
            download.GenDLLDiff("dummy,unused", dirdiff, null,  out ListaDiff);
            //if (File.Exists(Path.Combine(dirdiff, currConfig.xmlFile + ".zip"))) {
            //    File.Copy(Path.Combine(dirdiff,currConfig.xmlFile+".zip"),Path.Combine(getDirUff(),currConfig.xmlFile+".zip"),true);
            //}
            
            metaprofiler.StopTimer(K3);
            Cursor.Current = Cursors.Default;


            if (download.Connected) PopolaListView(ListaDiff);
            UpdateDLLThread.EH -= this.UpdateTxt;
            btnXMLFile.Visible = true;
            btnCopia.Visible = false;
            btnVersioni.Visible = false;
            btnCalcolaNuova.Visible = false;
        }

        /// <summary>
        /// Popola la listview con l'elenco dei file, e nella cartella diff\temp tutti i file presenti in diff
        /// </summary>
        /// <param name="listafile"></param>
        private void PopolaListView(Hashtable listafile) {
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
                MessageBox.Show("Mancano file nella directory attuale, verificare attentamente prima di procedere", "Avviso");
            }
            int tot = checkList.Items.Count;
            if (tot == 1)
                lblNumero.Text = "Trovata 1 differenza";
            else
                lblNumero.Text = "Trovate " + tot + " differenze";
            Application.DoEvents();
            //copia dei file da \diff in \diff\tmp
            
            string dirdiff = getDestDiffDir();// Dir.Concat(txtDirDiff.Text, zipLocalDir);// (radioDLL_sdi.Checked ? zipLocalDir : "report"));
            string folderDifferenzeTemporaneo = getSourceDiffDir();//XDir.Concat(dirdiff, C_TmpDir);
            DirectoryInfo d = new DirectoryInfo(dirdiff);

            //dirdiff	                    "F:\\templiveupdateeasy\\zip\\"	
            //folderDifferenzeTemporaneo    "F:\\templiveupdateeasy\\zip\\tmp\\"
            if (!Directory.Exists(folderDifferenzeTemporaneo)) Directory.CreateDirectory(folderDifferenzeTemporaneo);
            SvuotaCartella(folderDifferenzeTemporaneo);

            foreach (FileInfo f in d.GetFiles("*.*", SearchOption.AllDirectories)) {
                if (f.Name == currConfig.xmlFile + ".zip") continue;//salta l'indice
                //f.Name è il nome semplice ma a noi serve il folder relativo almeno
                //Dobbiamo sottrarre da f.FullName la parte relativa alla cartella folderDifferenzeTemporaneo
                string relativeFileName = f.FullName.Substring(dirdiff.Length);
                string diffPath= relativeFileName.Substring(0,relativeFileName.Length-Path.GetFileName(relativeFileName).Length);
                try {
                    string destPath=Path.Combine(folderDifferenzeTemporaneo, diffPath);
                    if (!Directory.Exists(destPath)) Directory.CreateDirectory(destPath);
                    File.Copy(f.FullName,
                        Path.Combine(destPath, Path.GetFileName(relativeFileName)),
                        true); //f.Name
                }
                catch (Exception e) {
                    //Impossibile trovare una parte del percorso 'D:\\software\\tempLuServices\\zip\\tmp\\App_Code\\AssemblyInfo.cs.zip'."}
                    Console.WriteLine(e.ToString());
                }
                
                Application.DoEvents();
            }
        }
        private void SvuotaCartella(string path) {
            DirectoryInfo d = new DirectoryInfo(path);  //D:\\software\\tempLuServices\\zip\\tmp\\
            foreach (FileInfo f in d.GetFiles()) {
                File.Delete(f.FullName);
            }
            foreach (var dir in d.GetDirectories()) {
                SvuotaCartella(dir.FullName);
                Directory.Delete(dir.FullName);
            }
        }
        private void btnSelAll_Click(object sender, EventArgs e) {
            for (int j = 0; j < checkList.Items.Count; j++) {
                checkList.SetItemChecked(j, true);
            }
        }

        /// <summary>
        /// Ottiene una hashtable con i nomi dei file non selezionati nell'elenco selezionato, associati alle versioni vecchie
        /// </summary>
        /// <returns></returns>
        private Hashtable GetSkipList() {
            Hashtable list = new Hashtable();
            for (int i = 0; i < checkList.Items.Count; i++) {
                if (!checkList.GetItemChecked(i)) {
                    string[] item = checkList.Items[i].ToString().Split('\t');
                    //ignoro la nuova versione
                    list.Add(item[0].Trim(), item[1].Trim());
                }
            }
            return list;
        }

        string getDestDiffDir() {
            return XDir.Concat(txtDirDiff.Text, "zip");     //  diffDir / zip
        }

        string getSourceDiffDir() {
            return XDir.Concat(getDestDiffDir(), C_TmpDir); //   diffDir / zip / tmp
        }
        /// <summary>
        /// Crea una cartella con tutti i file selezionati nel listbox, e relativo indice, prendendoli dalla cartella temporanea (temp) in essa contenuta
        /// </summary>
        private void AggiornaCartellaDiff(string destDir,   //D:\\software\\tempLuServices\\zip\\
            string sourceDir                                //D:\\software\\tempLuServices\\zip\\tmp\\
            ) {
            string lasttemp = "";
            string zipLocalDir = "zip";
            //Directory in cui copiare i file zippati
            string dirdiff = destDir;

            //Directory origine da cui prendere i file
            string dirtemp =sourceDir;

            try {
                for (int i = 0; i < checkList.Items.Count; i++) {
                    string[] item = checkList.Items[i].ToString().Split('\t');
                    string fname = Path.Combine(dirdiff,item[0]) + ".zip";    //percorso in cui copiare i file  D:\\software\\tempLuServices\\zip\\_SessionTimeOut.aspx.zip
                    string fnametmp = Path.Combine(dirtemp, item[0]) + ".zip";//percorso origine da cui prendere i file, che devono già essere presenti
                                                                    //es. D:\\software\\tempLuServices\\zip\\tmp\\_SessionTimeOut.aspx.zip
                    if (checkList.GetItemChecked(i)) {
                        //se è selezionato copio il file da tmp in diff
                        lasttemp = "Copio " + fname + " in " + dirtemp;
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
                        //e lo sposto in tmp (non vedo lo scopo di questo spostamento, chi se ne importa di cosa rimane in diff/temp?)
                        File.Move(fname, fnametmp);
                    }
                    Application.DoEvents();
                }

                lasttemp = "Copia del fileindex appena generato in " + dirdiff;
                //	File.Copy(m_LocalDir+@"\"+m_XMLFile+".zip",dirdiff+m_XMLFile+".zip", true);
                //copia l'indice dalla cartella di produzione alla cartella delle differenze ufficiale
                File.Copy(Path.Combine(getLocalDirectory() ,currConfig.xmlFile) + ".zip",Path.Combine( dirdiff , currConfig.xmlFile) + ".zip", true);
            }
            catch (Exception e) {
                MessageBox.Show(lasttemp + " - " + "Errore: " + e.Message, "Errore",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnXMLFile_Click(object sender, EventArgs e) {
            this.Cursor = Cursors.WaitCursor;
            btnXMLFile.Visible = false;
            Hashtable skiplist = GetSkipList();
            string errori;
            ImpostaAmbiente();
            currConfig.mergeFilesToSkip(skiplist);
            //ricrea l'indice  locale nella directory di produzione, es D:\\progetti\\EasyWebReport_2009\\
            if (!GenXML.GeneraFileIndiceGenerico(getLocalDirectory(), currConfig.xmlFile, currConfig.subDirectories,
                    skiplist,
                    currConfig.filter,currConfig.allowedExtensions, chkFiltraGiornalieri.Checked, out errori))
                //    MessageBox.Show("File XML generato con successo", "Generazione file XML",
                //        MessageBoxButtons.OK, MessageBoxIcon.Information);
                //else
                MessageBox.Show("Sono stati riscontrati i seguenti errori nella generazione:\r"
                    + errori, "Generazione file XML", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            this.Cursor = Cursors.Default;

            AggiornaCartellaDiff(getDestDiffDir(),getSourceDiffDir());

            btnCopia.Visible = false;
            btnVersioni.Visible = true;
            btnCalcolaNuova.Visible = true;
            return;
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
            // DA RIVEDERE
            //string vecchiaVersione = radioDLL_sdi.Checked ? txtVerSWNew.Text : txtVerReportNew.Text;
            string vecchiaVersione = txtVerSWNew.Text;
            if (vecchiaVersione == "") {
                vecchiaVersione = txtVerSWOld.Text;
            }
            //if (radioDLL_sdi.Checked) {
                txtVerSWNew.Text = getNuovaVersione(vecchiaVersione);
            //}
            btnCalcolaNuova.Visible = false;
        }
        private void AggiornaVersione(string newVersion) {
            if (newVersion.Trim() == "") return;
            TextBox txtNew = null;
             
            string oldversion = "";
            var tipo = currLuType();
            if (tipo==eTipoLiveUpdate.UNKNOWN)return;

            string dir = XDir.Concat(txtDirUff_main.Text, serviceName[tipo]);
            string filename  = dir + "versionesw4.txt";
            string tipoversione = null;

            txtNew = txtVerSWNew;
            oldversion = txtVerSWOld.Text;
            
            tipoversione = " service";
            //switch (tipo.ToUpper()) {
            //    case "S":
            //        txtNew = txtVerSWNew;
            //        oldversion = txtVerSWOld.Text;
            //        filename = dir + (IsNet45OrNewer() ? "versionesw4.txt" : "versionesw.txt");
            //        tipoversione = " software";
            //        break;
            //    case "R":
            //        txtNew = txtVerReportNew;
            //        oldversion = txtVerReportOld.Text;
            //        filename = dir + "versionereport.txt";
            //        tipoversione = "dei report";
            //        break;
            //}
            if (filename == null) return;
            XFile.EliminaSolaLettura(filename);
            if (oldversion.CompareTo(newVersion) >= 0) {
                if (MessageBox.Show("La versione " + newVersion + tipoversione + " risulta minore o uguale di quella corrente. Continuare?",
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
            StreamWriter write = new StreamWriter(filename, false, Encoding.ASCII);
            write.WriteLine(newVersion);
            write.Close();
            CaricaVersioni();
        }

        string getVersionFileName() {
            if (!radio_Dummy.Checked)return"versionesw4.txt";
            return "";
        }

        string getDirUff() {
            if (currLuType() == eTipoLiveUpdate.UNKNOWN) return "";
            return Path.Combine(txtDirUff_main.Text.Trim(), serviceName[currLuType()]);
        }

        string getWebAddress() {
            if (currLuType() == eTipoLiveUpdate.UNKNOWN) return "";
            return Ftp.ConcatFtpDir(txtWeb_main.Text.Trim(), serviceName[currLuType()]);
        }

        /// <summary>
        /// Cartella di produzione (i file ultimi creati in locale)
        /// </summary>
        /// <returns></returns>
        string getLocalDirectory() { //es.D:\\Easy\\_reportingServices\\
            if (currLuType() == eTipoLiveUpdate.UNKNOWN) return "";
            return getTextBoxFolderByServiceName(serviceName[currLuType()]).Text.Trim();
        }

        private void CaricaVersioni() {
            string DirUff = getDirUff();
            string Web = getWebAddress();
            string versionDllName = getVersionFileName();

            try {
                txtVerSWNew.Text = "";
                txtVerSWOld.Text = $"not found";
                //txtVerReportNew.Text = "";
                if (DirUff == "") return;
                string dir = XDir.CheckFinalSlash(DirUff);
                

                StreamReader read = new StreamReader(dir + versionDllName);
                txtVerSWOld.Text = read.ReadLine();
                read.Close();
                read.Dispose();

      
            }
            catch (Exception E) {
                System.Diagnostics.Debug.WriteLine("CaricaVersioni() - Msg: " + E.Message);
                
            }
        }
        private void btnVersioni_Click(object sender, EventArgs e) {
            AggiornaVersione(txtVerSWNew.Text);
            //AggiornaVersione(txtVerReportNew.Text, "R");
            btnCopia.Visible = true;
            btnDiff.Visible = false;
            btnXMLFile.Visible = false;
            btnVersioni.Visible = false;
            btnCalcolaNuova.Visible = false;
        }

        /// <summary>
        /// Copia i file generati
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCopia_Click(object sender, EventArgs e) {
            
            if (txtDirDiff.Text.Trim() == "") {
                MessageBox.Show("Specificare la cartella temporanea", "Copia",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            string dirDiff = txtDirDiff.Text.Trim();//D:\\software\\tempLuServices\\

            string dirUff = getDirUff();            //Y:\\services\\easyweb

            if (dirUff == "") {
                MessageBox.Show("Specificare la cartella ufficiale", "Copia",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (dirUff.ToLower() == dirDiff.ToLower()) {
                MessageBox.Show("Le cartelle sorgente/destinazioni sono uguali", "Copia",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            
            //Copia la sotto cartella zip dalla cartella delle differenze a quella ufficiale
            // ossia da tempDiff/zip a dirUff/zip
            // copia anche l'indice da   tempDiff/zip  a dirUff
            string errori = CopiaCartellaDifferenze();
            if (errori == null || errori == "") {
                btnCopia.Visible = false;
                return;
            }
            MessageBox.Show("Errori riscontrati durante la copia:\r\r", "Attenzione",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
        /// <summary>
        /// Copia la sotto cartella zip dalla cartella delle differenze a quella ufficiale
        /// </summary>
        /// <returns></returns>
        private string CopiaCartellaDifferenze() {
            string msg = null;

            string dllFileIndex = "servicefileindex.xml.zip";
            
            //di regola nella cartella c'è l'indice  e nelle sottocartelle zip ci sono i file zippati
            string sourcedir = txtDirDiff.Text;//XDir.Concat(txtDirDiff.Text, (radioDLL_sdi.Checked ? dllDir : reportDir)); D:\\software\\tempLuServices\\
            string destdir = getDirUff();//XDir.Concat(txtDirUff_RS.Text, (radioDLL_sdi.Checked ? dllDir : reportDir));     Y:\\services\\easyweb
            string index = dllFileIndex;// (radioDLL_sdi.Checked ? dllFileIndex : reportFileIndex);                         servicefileindex.xml.zip

            //Copia tutti i file dalla sottocartella zip delle differenze alla sottocartella zip della cartella ufficiale 
            msg = DO_COPY(sourcedir, destdir, index);
            
            return msg;
        }

        public static string CopyDirectory(string sourceDirectory, string targetDirectory,string mask) {
            
            DirectoryInfo diSource = new DirectoryInfo(sourceDirectory);
            DirectoryInfo diTarget = new DirectoryInfo(targetDirectory);

            var res= CopyAll(diSource, diTarget, mask);
            if (res == "") return null;
            return res;
        }

        public static string CopyAll(DirectoryInfo source, DirectoryInfo target, string mask) {
            var result = "";
            Directory.CreateDirectory(target.FullName);

            // Copy each file into the new directory.
            foreach (FileInfo fi in source.GetFiles(mask)) {
                //Console.WriteLine(@"Copying {0}\{1}", target.FullName, fi.Name);
                try {
                    fi.CopyTo(Path.Combine(target.FullName, fi.Name), true);
                }
                catch (Exception e) {
                    result += "Impossibile copiare il file " + fi.Name + " - Msg: " + e.ToString();
                }

                Application.DoEvents();
            }

            // Copy each subdirectory using recursion.
            foreach (DirectoryInfo diSourceSubDir in source.GetDirectories()) {
                DirectoryInfo nextTargetSubDir = target.CreateSubdirectory(diSourceSubDir.Name);
                result += CopyAll(diSourceSubDir, nextTargetSubDir, mask);
            }

            return result;
        }


        /// <summary>
        /// Copia tutti gli zip da una cartella windows ad un'altra e anche il file index nella root
        /// </summary>
        /// <param name="sourcedir"></param>
        /// <param name="destdir"></param>
        /// <param name="indexname"></param>
        /// <returns></returns>
        private string DO_COPY(string sourcedir, string destdir, string indexname) {
            string msg = null;
            XDir.CheckCreate(Path.Combine(destdir,"zip"));
            //XDir.Svuota(Path.Combine(destdir,"zip"));
            //da        D:\\software\\tempLuServices\\zip    A      Y:\\services\\easyweb\zip  tutti i file zip
            msg = CopyDirectory(Path.Combine(sourcedir,"zip"), Path.Combine(destdir,"zip"), "*.zip");

            XFile.Copia(Path.Combine(sourcedir,"zip",indexname)  , Path.Combine(destdir, indexname), true);
            return msg;
        }

        private void btnSync_Click(object sender, EventArgs e) {
            //D:\\Easy\\output\\LiveUpdateSyncService.exe
            string file = Path.Combine(Application.StartupPath , "LiveUpdateSyncService.exe");// DA RIVEDERE!!!
            if (!File.Exists(file)) return;
            System.Diagnostics.Process.Start(file);
        }

        private void btnDeselAll_Click(object sender, EventArgs e) {
            for (int j = 0; j < checkList.Items.Count; j++) {
                checkList.SetItemChecked(j, false);
            }
        }

        

      

        private void btnDirTemp_Click(object sender, EventArgs e) {
            string path = GetFolder("Selezionare la cartella temporanea in cui verranno generati i file", txtDirDiff.Text);
            if (path == null) return;
            txtDirDiff.Text = path;     
        }

  
        private string GetFolder(string descrizione, string proposed) {
            FolderBrowserDialog fd = new FolderBrowserDialog();
            fd.SelectedPath = proposed;
            fd.Description = descrizione;
            if (fd.ShowDialog() != DialogResult.OK) return null;
            return fd.SelectedPath + C_SLASH;
        }

      
        
        

     
        private void radio_CheckedChanged(object sender, EventArgs e) {
            PulisciCampi();
            CaricaVersioni();
        }

        TextBox getTextBoxFolderByServiceName(string serviceName) {
            foreach (Control o in gboxCartelle.Controls) {
                TextBox t = o as TextBox;
                if (t==null)continue;
                if (t.Tag.ToString().ToLower()!=serviceName.ToLower())continue;
                return t;
            }

            return null;
        }

        void folderBottonClick(object sender, EventArgs e) {
            string serviceName = ((Button) sender).Tag.ToString();
            var t = getTextBoxFolderByServiceName(serviceName);
            if (t==null)return;
            string path = GetFolder($"Selezionare la cartella ufficiale del Live Update ({serviceName})", t.Text);
            if (path == null) return;
            t.Text = path;
        }

    
    }

    public class configLiveUpdate {
     


        public List<string> allowedExtensions = new List<string>();
        /// <summary>
        /// Cartella root remota sul server 
        /// </summary>
        public string webRootDir;

        /// <summary>
        /// Cartella SPECIFICA remota sul server 
        /// </summary>
        public string webSubDir;

        /// <summary>
        /// Cartella in cui sono memorizzati i file quando scaricati dal client
        /// </summary>
        public string tempDestinationDir;

        /// <summary>
        /// Sottocartelle da considerare (escluso nome root)
        /// </summary>
        public IEnumerable<string> subDirectories;

        /// <summary>
        /// Singoli file da escludere (solo il nome), ogni item contiene la versione da saltare (o simili)
        /// </summary>
        public Hashtable filesToSkip= new Hashtable();

        /// <summary>
        /// Filtro da usare per cercare i file
        /// </summary>
        public List<string> filter = new List<string>();   //m_Filter = "*.dll";

        /// <summary>
        /// Nome indice xml
        /// </summary>
        public string xmlFile; //= C_XMLFileDLL;


        public string webDir() {
            return webRootDir + "/" + webSubDir;
        } //= txtWeb_SDI.Text + "/" + C_WebDirDLL;

        public configLiveUpdate(string webRootDir) {
            this.webRootDir = webRootDir;
            xmlFile = "servicefileindex.xml";//default = C_XMLFileDLL;
        }

        public void addFilterExtension(params string []extensions) {
            foreach (string extension in extensions) {
                filter.Add("*."+extension);
                allowedExtensions.Add("."+extension);
            }
        }
        public void mergeFilesToSkip(Hashtable skipHash) {
            foreach (var s in skipHash.Keys) filesToSkip[s] = skipHash[s];
        }
    }

    public class EasyPaymentConfig : configLiveUpdate {
        public EasyPaymentConfig(string webRootDir):base(webRootDir) {
            addFilterExtension("dll","exe","cer","pfx");
            subDirectories = new List<string>() { };
        }
    }
    
    public class EasyMultiSdiConfig : configLiveUpdate {
        public EasyMultiSdiConfig(string webRootDir):base(webRootDir) {
            addFilterExtension("dll","exe","cer","pfx");
            subDirectories = new List<string>() { };
        }
    }

    public class EasyWebConfig : configLiveUpdate {
        public EasyWebConfig(string webRootDir):base(webRootDir) {
            addFilterExtension("html", "dll","aspx","cs","js","css","jpg","exe","ico","png","gif","cer","pfx");
            subDirectories = new List<string>() {"App_Code", "js","css","bin","img",
                "immagini","Immagini_CheckBox","saml" };
        }
    }
    public class SdiConfig : configLiveUpdate {
        public SdiConfig(string webRootDir):base(webRootDir) {
            addFilterExtension("dll", "exe");
            subDirectories = new List<string>() { };
            
        }
    }
    public class ReportingServicesConfig : configLiveUpdate {
        public ReportingServicesConfig(string webRootDir):base(webRootDir) {
            addFilterExtension("rdl");  
        }
    }
    public class WebProtConfig : configLiveUpdate {
        public WebProtConfig(string webRootDir):base(webRootDir) {
            addFilterExtension("html", "dll","aspx","cs","js","css","jpg","exe","ico","png","gif","wsdl","cer","pfx");
            subDirectories = new List<string>() {"WebApp", "WebApp\\App_Code","WebApp\\Bin","WebApp\\Dll"};
        }
    }
    public class PortaleConfig : configLiveUpdate {
        public PortaleConfig(string webRootDir):base(webRootDir) {
            addFilterExtension("html", "dll","aspx","cs","js","css","jpg","exe","ico","png","gif","wsdl","cer","pfx");
            subDirectories = new List<string>() {"App_Code","App_Code\\Data","App_Code\\Extensions","App_Code\\Extra",
                "js","css","Bin","immagini","Immagini_CheckBox" };
        }
    }
}
