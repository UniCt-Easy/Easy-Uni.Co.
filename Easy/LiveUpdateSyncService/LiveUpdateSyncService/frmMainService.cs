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
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using metadatalibrary;
using download;
using utility;
using System.IO;
using System.Collections;
using System.Net;

namespace LiveUpdateSyncService {
    public partial class frmMainService :Form {
        private const string C_FILESYNC = "syncservice.xml";
        private string C_INDEXDLL =  "servicefileindex.xml";
        private string C_INDEXDLLZIP = "servicefileindex.xml.zip";
        private string C_INDEXREPORT = "servicereportindex.xml";
        private string C_INDEXREPORTZIP= "servicereportindex.xml.zip";
        private const string C_INDEXONDEMAND = "remoteondemandindex.xml";
        private const string C_INDEXONDEMANDZIP = "remoteondemandindex.zip";
        private string m_IndexFileName = "";
        private string m_IndexFileZip = "";
        private string m_IndexFileDir = "";
        private string m_Log = null;
        private enum eStato {
            READ,
            INSERT
        }
        private eStato Stato = eStato.READ;
        private DataRow m_CurrentMasterRow = null;
        private bool modified = false;
        frmLogService LogFormService;

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

        public frmMainService() {
            InitializeComponent();

            initLicenses();
            //
            // TODO: Add any constructor code after InitializeComponent call
            //
            AbilitaSync(false);
            m_IndexFileName = Application.StartupPath + @"\" + C_FILESYNC;
            m_IndexFileDir = Application.StartupPath;
            m_IndexFileZip = m_IndexFileName.Remove(m_IndexFileName.Length - 3, 3) + "zip";
            Init();
        }
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
            Application.Run(new frmMainService());
        }
        private bool Fill = false;
        private void Init() {
            Fill = true;
            DS.Clear();
            if (!File.Exists(m_IndexFileName)) Archivia();
            DS.ReadXml(m_IndexFileName);
            ImpostaRigaMaster();
            ImpostaGridMaster();
            ImpostaControlliMaster();
            AbilitaBottoniMaster();
            Fill = false;
        }
        private bool FromStringToBoolean(string valore) {
            return (valore.ToUpper() == "S");
        }

        private string FromBooleanToString(bool valore) {
            return (valore ? "S" : "N");
        }
        private void ImpostaRigaMaster() {
            if (DS.master.Rows.Count == 0) {
                DS.master.Rows.Add(DS.master.NewRow());
            }
            txtSource.Text = DS.master.Rows[0][0].ToString();
            txtUserMaster.Text = DS.master.Rows[0]["user"].ToString();
            txtPwdMaster.Text = DS.master.Rows[0]["pwd"].ToString();
            chkLocale.Checked = FromStringToBoolean(DS.master.Rows[0]["flaglocale"].ToString());
            //chkPasV.Checked = !FromStringToBoolean(DS.master.Rows[0]["active"].ToString());
            DisabilitaCampi(chkLocale.Checked);
        }

        private DataRow CurrentMasterRow {
            get {
                return m_CurrentMasterRow;
            }
            set {
                m_CurrentMasterRow = value;
                HelpForm.SetLastSelected(DS.sync, m_CurrentMasterRow);
            }
        }

        private void AbilitaBottoniMaster() {
            DataRow[] rows = DS.sync.Select(null, null, DataViewRowState.CurrentRows);
            btnInsertMaster.Enabled = (Stato == eStato.READ);
            btnDeleteMaster.Enabled = ((Stato == eStato.READ) && (rows.Length > 0));
            //btnUpdateMaster.Enabled=((Stato==eStato.INSERT) || (rows.Length>0));
            btnCancelMaster.Enabled = (Stato != eStato.READ);
            btnSalva.Enabled = (rows.Length > 0);
            btnSync.Enabled = (rows.Length > 0);
        }

        private bool IsValidGrid(DataRow R) {
            if (R["indirizzo"].ToString() == "") {
                ShowMsg("Specificare l'indirizzo del sito da sincronizzare");
                txtIndirizzo.Focus();
                return false;
            }
            if (R["descrizione"].ToString() == "") {
                ShowMsg("Specificare la descrizione");
                txtDescrizione.Focus();
                return false;
            }
            if (R["user"].ToString() == "" || R["pwd"].ToString() == "") {
                ShowMsg("Specificare Utente/Password per sito da sincronizzare");
                txtUser.Focus();
                return false;
            }
            return true;
        }

        private void ImpostaGridMaster() {
            DataTable T = DS.sync;
            foreach (DataColumn C in T.Columns) {
                C.Caption = "";
            }
            T.Columns["id"].Caption = "ID";
            T.Columns["indirizzo"].Caption = "URL / Path locale";
            T.Columns["port"].Caption = "Porta";
            T.Columns["descrizione"].Caption = "Descrizione";
            HelpForm.SetDataGrid(gridMaster, T);
        }

        private void ImpostaValoriControlliMaster(DataRow R) {
            txtProgressivo.Text = (R == null ? "" : R["id"].ToString());
            txtIndirizzo.Text = (R == null ? "" : R["indirizzo"].ToString());
            txtPort.Text = (R == null ? "21" : R["port"].ToString());
            txtDescrizione.Text = (R == null ? "" : R["descrizione"].ToString());
            txtUser.Text = (R == null ? "" : R["user"].ToString());
            txtPwd.Text = (R == null ? "" : R["pwd"].ToString());
            chkPasV.Checked = (R == null || R["active"].ToString().ToUpper() == "S") ? false : true;
        }

        private void ImpostaControlliMaster() {
            DataRow R = GetCurrentGridRow(gridMaster, "sync");
            if (CurrentMasterRow == R) return;
            CurrentMasterRow = R;
            ImpostaValoriControlliMaster(R);
            AbilitaBottoniMaster();
        }
        private void AbilitaSync(bool enable) {
            btnSync.Enabled = enable;
        }

        private DataRow GetCurrentGridRow(DataGrid G, string tablename) {
            if (tablename == null) return null;
            DataTable T = DS.Tables[tablename];
            DataSet DSV = (DataSet)G.DataSource;
            if (DSV == null) return null;
            DataTable TV = DSV.Tables[G.DataMember];
            if (TV == null) return null;
            if (TV.Rows.Count == 0) return null;
            DataRowView DV = null;
            try {
                DV = (DataRowView)G.BindingContext[DSV, TV.TableName].Current;
            }
            catch {
                DV = null;
            }
            if (DV == null) return null;
            DataRow R = DV.Row;
            HelpForm.SetLastSelected(T, R);
            return HelpForm.FindExternalRow(T, R);
        }

        private void Archivia() {
            DS.WriteXml(m_IndexFileName);
            //			XZip.AddFiles(m_IndexFileZip,m_IndexFileDir,C_FILESYNC,true,true);
        }
        private void btnChiudi_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void btnSync_Click(object sender, EventArgs e) {
            if (txtSource.Text.Trim() == "") {
                ShowMsg("E' necessario specificare il sito da replicare");
                return;
            }
            if (modified) {
                ShowMsg("Ci sono modifiche in corso, è necessario salvare prima di effettuare il sync");
                return;
            }
            DataTable T = GetTableMemory();
            if (T == null || T.Rows.Count == 0) {
                ShowMsg("Specificare almeno un sito da sincronizzare");
                return;
            }
            m_Log = null;
            this.Cursor = Cursors.WaitCursor;
            VisualizzaLog();

            DO_SYNC(T, chkLocale.Checked);
            this.Cursor = Cursors.Default;
        }
        private void ShowMsg(string msg) {
            MessageBox.Show(msg, "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
        private DialogResult ShowQuestion(string msg) {
            return MessageBox.Show(msg, "Domanda",
                MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
        }
        private bool IsValidRigaMaster() {
            if (txtSource.Text.Trim() == "") {
                ShowMsg("Specificare il sito da replicare");
                txtSource.Focus();
                return false;
            }
            //			if (!chkLocale.Checked && (txtUserMaster.Text.Trim()=="" || txtPwdMaster.Text.Trim()=="")) {
            //				ShowMsg("Specificare Utente/Password per sito da replicare");
            //				txtUserMaster.Focus();
            //				return false;
            //			}
            return true;
        }

        private void SalvaRigaMaster() {
            DS.master.Rows[0]["indirizzo"] = txtSource.Text.Trim();
            DS.master.Rows[0]["user"] = txtUserMaster.Text.Trim();
            DS.master.Rows[0]["pwd"] = txtPwdMaster.Text.Trim();
            DS.master.Rows[0]["flaglocale"] = FromBooleanToString(chkLocale.Checked);

        }

        private void gridMaster_Click(object sender, EventArgs e) {
            ImpostaControlliMaster();
        }


        void Aggiorna() {
            DataRow R = null;
            if (Stato == eStato.INSERT) {
                R = DS.sync.NewRow();
                DataTable TV = GetTableMemory();
                int max = 0;
                if (TV != null) {
                    DataRow[] rows = TV.Select(null, "id DESC", DataViewRowState.CurrentRows);
                    if (rows.Length > 0)
                        max = (int)rows[0]["id"];
                }
                R["id"] = max + 1;
            }
            else {
                R = CurrentMasterRow;
                R["id"] = Convert.ToInt32(txtProgressivo.Text);
            }
            R["indirizzo"] = txtIndirizzo.Text.Trim();
            R["descrizione"] = txtDescrizione.Text;
            R["user"] = txtUser.Text.Trim();
            R["pwd"] = txtPwd.Text.Trim();
            R["port"] = (txtPort.Text.Trim() != "" ? txtPort.Text.Trim() : "21");
            R["active"] = chkPasV.Checked ? "N" : "S";
            if (!IsValidGrid(R))
                return;
            if (Stato == eStato.INSERT)
                DS.sync.Rows.Add(R);
            R.AcceptChanges();
            Stato = eStato.READ;
            modified = true;
            CurrentMasterRow = R;
            ImpostaValoriControlliMaster(R);
            AbilitaBottoniMaster();
        }
        private void btnInsertMaster_Click(object sender, EventArgs e) {
            ImpostaValoriControlliMaster(null);
            Stato = eStato.INSERT;
            AbilitaBottoniMaster();
        }

        private void btnDeleteMaster_Click(object sender, EventArgs e) {
            Stato = eStato.READ;
            if (CurrentMasterRow == null) {
                ShowMsg("Selezionare una riga");
                return;
            }
            DialogResult res = ShowQuestion("Sei sicuro di voler cancellare la riga?");
            if (res != DialogResult.Yes) return;
            CurrentMasterRow.Delete();
            DS.sync.AcceptChanges();
            ImpostaControlliMaster();
            AbilitaBottoniMaster();
            modified = true;
        }

        private void btnCancelMaster_Click(object sender, EventArgs e) {
            CurrentMasterRow = null;
            Stato = eStato.READ;
            ImpostaControlliMaster();
            AbilitaBottoniMaster();
            modified = false;
        }

        void Salva() {
            if (!IsValidRigaMaster())
                return;
            if (modified) {
                SalvaRigaMaster();
                DS.AcceptChanges();
                Archivia();
            }
            Stato = eStato.READ;
            modified = false;
        }
        private void btnSalva_Click(object sender, EventArgs e) {
            Aggiorna();
            Salva();
        }

        private bool Chiudi() {
            if (modified) {
                DialogResult res = MessageBox.Show("Ci sono modifche, vuoi salvare?", "Attenzione",
                    MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (res == DialogResult.Cancel) return true;
                if (res == DialogResult.Yes) btnSalva_Click(null, null);
            }
            return false;
        }

        private void frmMainService_Closing(object sender, System.ComponentModel.CancelEventArgs e) {
            e.Cancel = Chiudi();
        }
        private DataTable GetTableMemory() {
            DataSet DSV = (DataSet)gridMaster.DataSource;
            if (DSV == null) return null;
            return DSV.Tables[gridMaster.DataMember];
        }

        private void txtSource_TextChanged(object sender, EventArgs e) {
            if (Fill) return;
            modified = true;
        }

        private void txtUserMaster_TextChanged(object sender, EventArgs e) {
            if (Fill) return;
            modified = true;
        }

        private void txtPwdMaster_TextChanged(object sender, EventArgs e) {
            if (Fill) return;
            modified = true;
        }

        private void txtPort_TextChanged(object sender, EventArgs e) {
            if (Fill) return;
            modified = true;
        }

        private void chkLocale_CheckedChanged(object sender, EventArgs e) {
            if (Fill) return;
            modified = true;
            DisabilitaCampi(chkLocale.Checked);
        }
        private void DisabilitaCampi(bool disable) {
            txtUserMaster.ReadOnly = disable;
            txtPwdMaster.ReadOnly = disable;
            btnDirBrowse.Visible = disable;
            if (disable) {
                txtUserMaster.Text = "";
                txtPwdMaster.Text = "";
            }
        }

        private void VisualizzaLog() {
            //if (m_Log==null) return;
            if (m_Log == null) m_Log = "";
            LogFormService = new frmLogService(QueryCreator.GetPrintable(m_Log));
            LogFormService.Show();

        }

        private void DO_SYNC(DataTable T, bool IsLocal) {
   
            //Al momento è gestito solo da locale
            DO_SYNC_LOCALE(T);
        }

        private void btnDirBrowse_Click(object sender, EventArgs e) {
            FolderBrowserDialog F = new FolderBrowserDialog();
            if (txtSource.Text.Trim() != "") F.SelectedPath = txtSource.Text.Trim();
            F.Description = "Selezionare la cartella radice del LiveUpdate";
            if (F.ShowDialog() != DialogResult.OK) return;
            txtSource.Text = F.SelectedPath;
        }

        
        FtpFileNameRewriter rewriter = new FtpFileNameRewriter();
        
        /// <summary>
        /// Questo metodo viene utilizzato quando il sito da replicare è una cartella locale
        /// </summary>
        /// <param name="source">indirizzo da replicare</param>
        /// <param name="T">Tabella che contiene i siti da sincronizzare</param>
        private void DO_SYNC_LOCALE(DataTable T) {
            try {
                string cartellaTrasferimento = Path.Combine(Application.StartupPath, "sync"); //D:\\Easy\\output\\sync\\
                string cartellaTemporanea = Path.Combine(cartellaTrasferimento,"slave"); //cartella temporanea D:\\Easy\\output\\sync\\slave\\

                //Cartella locale da replicare
                string cartellaLocaleDaReplicare = XDir.CheckFinalSlash(txtSource.Text.Trim()); //Y:\\services\\

                //check per ogni sito da sincronizzare
                foreach (DataRow R in T.Rows) {
                    string indirizzo = R["indirizzo"].ToString();// ftp.temposrl.it/temposrl.it/easyservices
                    int port = GetPort(R["port"].ToString());
                    string user = R["user"].ToString();
                    string pwd = R["pwd"].ToString();
                    //inizializza e sposta la directory corrente in  temposrl.it/easyservices
                    Ftp ftpSlave = InitServerFTP(indirizzo, port, user, pwd, (R["active"].ToString().ToUpper() == "S"),
                        false);
                    if (R["active"].ToString().ToUpper() == "S") {
                        ftpSlave.SetActiveMode(true);
                    }
                    else {
                        ftpSlave.SetActiveMode(false);
                    }

                    string webAddress = "http://www." + indirizzo.Substring(indirizzo.IndexOf("/")+1);
                    ftpSlave.rewriter.getRewriteList(Ftp.Combine(webAddress,"rewritelist.txt"));
                    if (ftpSlave == null) continue;
                    if (chkDirectory.Checked) CheckLiveUpdateStructure(ftpSlave);
                    //cartellaDaReplicare       = Y:\\services\\
                    //cartellaTemporanea        = D:\\Easy\\output\\sync\\slave
                    //cartellaTrasferimento     = D:\\Easy\\output\\sync
                    Sincronizza_LOCALE(indirizzo, cartellaLocaleDaReplicare, ftpSlave, cartellaTemporanea, cartellaTrasferimento);
                    ftpSlave.Close();
                }



            }
            catch (Exception E) {
                ShowMsg("Elaborazione interrotta\r\r" + E.Message);
            }

            LogFormService.btnChiudi.Visible = true;
        }

        private int GetPort(string testo) {
            //default = 21
            if (testo == null || testo == "") return 21;
            try {
                int port = Convert.ToInt32(testo);
                if (port < 0) return 21;
                return port;
            }
            catch {
                return 21;
            }
        }
        /// <summary>
        /// Controlla la struttura della cartella LiveUpdate
        /// Presenza delle cartelle ondemand - report - sp - sql - zip
        /// </summary>
        /// <param name="ftpDest">Istanza ftp da aggiornare</param>
        private void CheckLiveUpdateStructure(Ftp ftpDest) {
            foreach(var service in serviceNames) ftpDest.CheckDir(service);

        }

        private static string[] serviceNames = new[]
            {"easyweb", "portale", "reportingservices", "sdi", "webprot", "payment","multisdi"};
        /// <summary>
        /// Sincronizzazione ddl/report/sp del server ftp destinazione
        /// </summary>
        /// <param name="officialMainFolder">path locale del liveupdate (non quello dei servizi)</param>
        /// <param name="ftpDest">server ftp destinazione</param>
        /// <param name="tempdir">cartella di appoggio per download file</param>
        private void Sincronizza_LOCALE(string webRoot,
            string officialFolder,
            Ftp ftpDest,
            string cartellaAppoggio,
            string folderTrasferimento) {
            //ftpDest.ChangeDir(webRoot);//Si sposta sulla cartella root del sito - rimosso, al momento sta già in easyservices
            bool res = true;
            foreach (string serviceName in serviceNames ) {
                AggiungiLog(ftpDest.Host, "---------------------------------------------");
                AggiungiLog(ftpDest.Host, "              "+serviceName);
                AggiungiLog(ftpDest.Host, "---------------------------------------------");
                XDir.CheckCreate(folderTrasferimento);
                XDir.Svuota(folderTrasferimento, true);
                XDir.CheckCreate(cartellaAppoggio);


                string pathLocale = Path.Combine(officialFolder, serviceName);  //  = Y:\\services\\easyweb
                //scarica l'indice locale in D:\\Easy\\output\\sync
                DataSet dsFileDiff = GetDSIndex_LOCALE(pathLocale, folderTrasferimento);    // trasf.=D:\\Easy\\output\\sync
                //bool res = SincronizzaDLLReport_LOCALE(localdir, SourceDLL, ftpDest, tempdirslave, tempdirmaster, "D");
                //officialFolder = Y:\\services\\, serviceName=easyweb  , folderTrasferimento=D:\\Easy\\output\\sync
                if (res) res = SincronizzaAllFile_LOCALE(officialFolder, serviceName, dsFileDiff, ftpDest,  folderTrasferimento);
                AggiungiLog(ftpDest.Host, "---------------------------------------------");
            }
         

            //Aggiorno file siti.txt nella root
            if (res) res = AggiornaFile_LOCALE(ftpDest, "easyservicessiti.txt", Path.Combine(officialFolder,"easyservicessiti.txt"));
            AggiungiLog(ftpDest.Host, "---------------------------------------------");
        }

        string webRelativePath(string serviceName,string windowFilePath) {
            return Ftp.CheckReverseFinalSlash(serviceName)+Ftp.removeStartReverseSlash(windowFilePath.Replace("\\","/"));
        }
        /// <summary>
        /// Esegue sincronizzazione tra cartella locale e server ftp di dll/report
        /// </summary>
        /// <param name="officialFolder">cartella ufficiale locale liveupdate (root)</param>
        /// <param name="serviceName"></param>
        /// <param name="Source">Dataset index sorgente DLL/Report</param>
        /// <param name="ftpDest">server ftp destinazione</param>
        /// <param name="folderTrasferimento">cartella di appoggio per download file</param>
        /// <returns>True se va a buon fine o se non ci sono file da aggiornare</returns>
        private bool SincronizzaAllFile_LOCALE(string officialFolder, string serviceName, DataSet Source, Ftp ftpDest,string folderTrasferimento) {

            string versionfilename= "versionesw4.txt";
            //La sincronizzazione viene ignorata se il DS sorgente è null
            if (Source == null) return true;
            //risultato del metodo
            bool risultato = true;

            string indexFilename = C_INDEXDLLZIP;  //nome del file indice da usare (serviceindex.xml.zip )
            string remotedir = serviceName; //cartella in cui saranno copiati i singoli file (easyweb / sdi / .. )
            

            //Leggo la versione del file locale in Y:\\services\\ serviceName \ versionesw4.txt
            StreamReader read = new StreamReader(Path.Combine(officialFolder,serviceName,versionfilename)); //versione locale nella cartella root ufficiale
            string localversion = read.ReadLine();
            read.Close();
            string remoteversion;
            string folderTrasferimentoServizio =  serviceName;

            //D:\\Easy\\output\\sync\\~tmp_versionesw4.txt
            string tempname = Path.Combine(folderTrasferimento , "~tmp_" + versionfilename);

            if (!ftpDest.GetFile(tempname, Ftp.Combine(serviceName,versionfilename))) {//la versione si trova nella root LU del sito ftp
                AggiungiLog(ftpDest.Host, "Impossibile leggere il file remoto " + versionfilename + " - " + ftpDest.GetLastError());
                if (MessageBox.Show("Proseguo riscaricando tutti i file (si) o salto questa fase (no)?", "Avviso",
                            MessageBoxButtons.YesNo) == DialogResult.No) {
                    return false;
                }
                remoteversion = "0.0.000";
                //return false;
            }
            else {
                read = new StreamReader(tempname);
                remoteversion = read.ReadLine();
                read.Close();
            }
            if (localversion.CompareTo(remoteversion) <= 0) return true;

            //Si posiziona nella root del servizio
            //ftpDest.ChangeToRelativeDir(serviceName);
            string folderTrasferimentoTemp = Path.Combine(folderTrasferimento, "slave");
          
            //se non ho file nell'indice aggiornamenti copio il file index e la versione (e nessun file) 
            if (Source.Tables.Count == 0) {
                bool res = AggiornaFile_LOCALE( ftpDest, Ftp.Combine(folderTrasferimentoServizio,indexFilename),  
                                                Path.Combine(serviceName,indexFilename));
                if (res) res = AggiornaFile_LOCALE( ftpDest, Ftp.Combine(folderTrasferimentoServizio,versionfilename),  
                                                Path.Combine(serviceName,versionfilename));
                return res;
            }

            DataTable Tsource = Source.Tables["DLL"];
            DataTable Tdest = null;
            DataSet Dest = GetDSIndex_REMOTO(ftpDest, folderTrasferimentoTemp, serviceName);
            if (Dest != null && Dest.Tables.Count > 0) Tdest = Dest.Tables["DLL"];
            foreach (DataRow Rsource in Tsource.Rows) {
                if (Tdest != null) {
                    DataRow[] Rdest = Tdest.Select("dllname=" + QueryCreator.quotedstrvalue(Rsource["dllname"], false));
                    //se il file è nuovo o da aggiornare
                    if (Rdest.Length == 0 || IsFileToUpdate(Rsource, Rdest[0])) {
                        string relativePath = "";
                        string fileName = "";
                        if (!AggiornaFile_LOCALE(ftpDest, Ftp.Combine(folderTrasferimentoServizio,"zip",Rsource["dllname"].ToString()+".zip"),
                                        Path.Combine(officialFolder,serviceName, "zip",Rsource["dllname"].ToString() + ".zip"))) {
                            risultato = false;
                            break;
                        }
                            
                    }
                }
                else {
                    //caso in cui non esiste il file index sul server destinazione
                    if (!AggiornaFile_LOCALE(ftpDest, Ftp.Combine(folderTrasferimentoServizio,"zip",Rsource["dllname"].ToString()+ ".zip"),
                             Path.Combine(officialFolder,serviceName, "zip", Rsource["dllname"].ToString() + ".zip"))) {
                        risultato = false;
                        break;
                    }
                        
                }
            }
            //se è tutto ok  aggiorno pure l'index dei file (nella directory principale dello slave)
            if (risultato) risultato = AggiornaFile_LOCALE( ftpDest, Ftp.Combine(folderTrasferimentoServizio,indexFilename),  
                                                Path.Combine(officialFolder,serviceName,indexFilename));


            //Aggiorna l'indice versionesw.txt/versionereport.txt (nella directory principale dello slave)
            if (risultato) risultato = AggiornaFile_LOCALE( ftpDest, Ftp.Combine(folderTrasferimentoServizio,versionfilename),  
                                                Path.Combine(officialFolder,serviceName,versionfilename));


            return risultato;
        }



    



    


        /// <summary>
        /// Aggiorna il file versione specificato se la versione locale risulta maggiore di quella remota
        /// </summary>
        /// <param name="localdir">root cartella live update</param>
        /// <param name="ftpDest">ftp Server destinazione</param>
        /// <param name="tempdir">cartella temporanea</param>
        /// <param name="filename">file versione da aggiornare</param>
        //		private void SincronizzaVersione_LOCALE(string localdir, Ftp ftpDest, string tempdir, string filename) {
        //			//Leggo la versione del file locale
        //			StreamReader read=new StreamReader(localdir+@"\"+filename);
        //			string localversion=read.ReadLine();
        //			string tempname=tempdir+@"\~tmp_"+filename;
        //			if (!ftpDest.GetFile(tempname, filename)) {
        //				AggiungiLog(ftpDest.Host, "Impossibile leggere il file "+filename+ " - "+ftpDest.GetLastError());
        //				return;
        //			}
        //			read=new StreamReader(tempname);
        //			string remoteversion=read.ReadLine();
        //			if (localversion.CompareTo(remoteversion)<=0) return;
        //			AggiornaFile_LOCALE(localdir, ftpDest, tempdir, "", filename);
        //		}

        /// <summary>
        /// Esegue una Put del file sorgente nella cartella indicata del server ftp 
        /// </summary>
        /// <param name="localdir">root cartella live update</param>
        /// <param name="ftpDest">server ftp destinazione</param>
        /// <param name="DestFolderName">percorso remoto </param>
        /// <param name="fullSourceFileName">percorso file origine completo</param>
        /// <returns>True se va a buon fine l'aggiornamento</returns>
        private bool AggiornaFile_LOCALE(Ftp ftpDest, string completeRemoteDestFolder, string fullSourceFileName) {

            if (!ftpDest.PutFile(fullSourceFileName, completeRemoteDestFolder)) {                
                AggiungiLog(ftpDest.Host, "Non ho potuto copiare il file " + Path.GetFileName(fullSourceFileName) + " sul sito.");
                AggiungiLog(ftpDest.Host, ftpDest.GetLastError());
                return false;
            }
            else {
                AggiungiLog(ftpDest.Host, "Copiato il file " + completeRemoteDestFolder.Replace("\\","/") + " sul sito.");
            }
            //Application.DoEvents();
            return true;
        }

    

        /// <summary>
        /// Utilizzata per aggiornare intere versioni (cartelle) di script SQL / on demand
        /// </summary>
        /// <param name="officialFolder">root cartella live update</param>
        /// <param name="ftpDest">server ftp destinazione</param>
        /// <param name="tranferFolder">Cartella di trasferimento per gli invii</param>
        /// <param name="remotedir">root path indirizzo remoto</param>
        /// <param name="serviceName">Nome servizio da aggiornare</param>
        /// <returns>True se va a buon fine l'operazione</returns>
        private bool AggiornaDir_LOCALE(string officialFolder, Ftp ftpDest, string tranferFolder, string remotedir, string serviceName) {
            string officialFolderServizio = XDir.Concat(officialFolder, serviceName); // root liveupdate / nome servizio

            string transferFolderServizio = XDir.Concat(tranferFolder,  serviceName);  // cartella temp / servizio
            if (!XDir.CheckCreate(transferFolderServizio)) return false;
            
            //Svuota la cartella di trasferimento
            XDir.Svuota(transferFolderServizio, true);
            
            //Copia i file nella cartella di trasferimento
            if (XDir.Copia(officialFolderServizio, transferFolderServizio) != null) return false;            
            
            //Check remote dir
            string remotedirService = XDir.CheckFinalSlash( remotedir) + serviceName; // es. www. 
            string[] files = ftpDest.DirFull(remotedirService);
            //null or 0 files <-> dir inesistente o cartella esistente ma vuota. E' un errore perchè dovrebbe contenere almeno un indice
            if (files == null || files.Length == 0) {
                if (!ftpDest.CheckDir(remotedirService)) {
                    AggiungiLog(ftpDest.Host, ftpDest.GetLastError());
                    return false;
                }               
            }
            DirectoryInfo D = new DirectoryInfo(transferFolderServizio);
            ftpDest.rootDirectory = remotedirService; //root servizio
            ftpDest.ChangeDir(remotedirService);
            foreach (FileInfo F in D.GetFiles("*.zip",SearchOption.AllDirectories)) {
                string relativeName = F.FullName.Substring(D.Name.Length);
                string relativeWebName = relativeName.Replace("/","\\");//ottiene il path relativo, la root verrà accodata in fase di put Fisico
                if (!AggiornaFile_LOCALE( ftpDest,  relativeWebName,   F.FullName)) return false;
            }
            return true;
        }

        /// <summary>
        /// Restituisce il dataset relativo all'indice richiesto (Dll/Report) copiandolo dalla cartella sourceFolder e  mettendolo in destFolder
        /// </summary>
        /// <param name="sourceFolder">path della cartella liveupdate di riferimento</param>
        /// <param name="destFolder">cartella locale di trasferimento</param>
        private DataSet GetDSIndex_LOCALE(string sourceFolder, //Y:\\services\\easyweb
                                          string destFolder    //D:\\Easy\\output\\sync
            ) {
            string filename = C_INDEXDLL;       // "servicefileindex.xml";
            string filenamezip = C_INDEXDLLZIP; // "servicefileindex.xml.zip";
            string fileziptocopy = "";
          
            fileziptocopy = filenamezip;        // servicefileindex.xml.zip
            string s = XFile.Copia(Path.Combine(sourceFolder, fileziptocopy), Path.Combine(destFolder , filenamezip), true);
            if (s != null) {
                AggiungiLog(sourceFolder, s);
                return null;
            }
            //lo estraggo
            XZip.ExtractFiles(Path.Combine(destFolder , filenamezip), destFolder, filename, true, true);
            //ottengo la lista
            DataSet DSindex = new DataSet();
            DSindex.ReadXml(Path.Combine(destFolder , filename));
            return DSindex;
        }

        /// <summary>
        /// Restituisce il dataset relativo all'indice richiesto (Dll/Report) leggendolo in destDir
        /// </summary>
        /// <param name="server">server ftp</param>
        /// <param name="tempdir">cartella locale</param>        
        private DataSet GetDSIndex_REMOTO(Ftp server, string destDir,string servicename) {
            string filename = C_INDEXDLL; //"servicefileindex.xml";
            string filenamezip = C_INDEXDLLZIP; //"servicefileindex.xml.zip";
            string fileziptocopy = "";
            XDir.CheckCreate(destDir);
            fileziptocopy = Ftp.Combine(servicename, filenamezip);
            if (!server.GetFile(Path.Combine(destDir , filenamezip), fileziptocopy)) {
                AggiungiLog(server.Host, server.GetLastError());
                return null;
            }
            //lo estraggo
            XZip.ExtractFiles(Path.Combine(destDir, filenamezip), destDir, filename, true, true);
            //ottengo la lista
            DataSet DSindex = new DataSet();
            DSindex.ReadXml(Path.Combine(destDir , filename));
            return DSindex;
        }
        private void chkPasV_CheckStateChanged(object sender, EventArgs e) {
            if (Fill) return;
            modified = true;
        }
        #region Metodi Comuni
        private bool IsFileToUpdate(DataRow Rsource, DataRow Rdest) {
            int major1 = Convert.ToInt32(Rsource["major"]);
            int minor1 = Convert.ToInt32(Rsource["minor"]);
            int build1 = Convert.ToInt32(Rsource["build"]);
            int major2 = Convert.ToInt32(Rdest["major"]);
            int minor2 = Convert.ToInt32(Rdest["minor"]);
            int build2 = Convert.ToInt32(Rdest["build"]);
            if ((major1 > major2) ||
                (major1 == major2 && minor1 > minor2) ||
                (major1 == major2 && minor1 == minor2 && build1 > build2)) {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Esegue le operazioni di inizializzazione per operare su un server ftp
        /// </summary>
        /// <param name="address">indirizzo server ftp</param>
        /// <param name="user">utente</param>
        /// <param name="pwd">password</param>
        /// <param name="IsMaster">True se riguarda il server da replicare</param>
        /// <returns>Istanza ftp se OK altrimenti null</returns>
        private Ftp InitServerFTP(string address, int port, string user, string pwd, bool active, bool IsMaster) {
            string host = GetHostByAddress(address);    //ftp.temposrl.it
            Ftp server = GetFtpInstance(host, port, user, pwd, active, IsMaster);
            if (server == null) return null;    
            string dir = GetPathByAddress(address); //   temposrl.it/easyservices
            if (!server.ChangeDir(dir)) {
                AggiungiLog(server.Host, server.GetLastError());
                return null;
            }
            return server;
        }

        /// <summary>
        /// A partire da ftp://ciccio.pippo.it/cartella1/cartella2/ restituisce ciccio.pippo.it
        /// </summary>
        /// <param name="address">indirizzo ftp</param>
        private string GetHostByAddress(string address) {
            if (address == null || address == "") return null;
            //elimino eventuale prefisso
            if (address.IndexOf("//", 0) > 0) address = address.Substring(address.IndexOf("//", 0) + 2);
            //ricavo l'host
            int pos = address.IndexOf("/");
            //non contiene path relativi
            if (pos == -1) return address;
            //restituisco host senza cartelle
            return address.Substring(0, pos);
        }

        /// <summary>
        /// A partire da ftp://ciccio.pippo.it/cartella1/cartella2/ restituisce cartella1/cartella2
        /// </summary>
        /// <param name="address">indirizzo ftp</param>
        private string GetPathByAddress(string address) {
            if (address == null || address == "") return null;
            //elimino eventuale prefisso
            if (address.IndexOf("//", 0) > 0) address = address.Substring(address.IndexOf("//", 0) + 2);
            //elimino host
            int pos = address.IndexOf("/");
            //non contiene path relativi
            if (pos == -1 || pos == address.Length - 1) return ".";
            //restituisco host senza cartelle
            return address.Substring(pos+ 1);
        }
        /// <summary>
        /// A partire da ftp://ciccio.pippo.it/cartella1/cartella2/fname restituisce fname
        /// </summary>
        /// <param name="address">indirizzo ftp</param>
        private string GetNameByAddress(string address) {
            if (address == null || address == "") return null;
            var pieces = address.Split('/');
            return pieces[pieces.Length - 1];
         
        }

        /// <summary>
        /// Apre una connessione ftp ed esegue il login
        /// </summary>
        /// <param name="host">server ftp</param>
        /// <param name="user">utente</param>
        /// <param name="pwd">password</param>
        /// <param name="master">True se riguarda il server da replicare</param>
        /// <returns>Istanza FtpClient se va a buon fine</returns>
        private Ftp GetFtpInstance(string host, int port, string user, string pwd, bool activeMode, bool master) {
            Ftp client = null;
            try {
                client = new Ftp(host, port);
                client.SetActiveMode(activeMode);
                if (!client.IsConnected) throw new Exception(client.GetLastError());
                if (client.Login(user, pwd)) return client;
                throw new Exception(client.GetLastError());
            }
            catch (Exception E) {
                AggiungiLog(host, (client != null ? E.Message : "Impossibile connettersi"));
                return null;
            }
        }
        private void AggiungiLog(string host, string msg) {
            m_Log = "# Server ftp [" + host + "] -  " + msg + "\r\n" + m_Log;
            LogFormService.txtLog.Text = QueryCreator.GetPrintable(m_Log);
            LogFormService.Refresh();
            //Application.DoEvents();
        }

        #endregion

       
    }
}
