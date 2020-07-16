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
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xceed.Ftp;
using System.Data;
using metadatalibrary;

namespace funzioni_configurazione {

    public class TreasurerPutFile {
        private DataRow cfg;
        public TreasurerPutFile(DataAccess conn, object idtreasurer) {
            QueryHelper q = conn.GetQueryHelper();
            DataTable t = conn.RUN_SELECT("treasurer", "*", null, q.CmpEq("idtreasurer", idtreasurer), null, false);
            cfg = t.Rows[0];
        }

        public string putFile(string localFileName, string remoteFileName) {
            if (cfg["ftpaddress"].ToString() == "") return null;

            FtpHelp ftp = new FtpHelp(cfg["ftpaddress"].ToString(), 
                                    cfg["ftpuser"].ToString(),
                                    cfg["ftppassword"].ToString(),
                                    CfgFn.GetNoNullInt32(cfg["ftpport"]),
                                    cfg["pasvmode"].ToString().ToUpper()=="S"
                
                );
            if (ftp.putFile(cfg["ftpdir"].ToString(), remoteFileName, localFileName)) {
                ftp.logout();
                return null;
            }

            string errors = "";
            foreach (string s in ftp.errors) {
                errors += s + "\n\r";
            }

            ftp.logout();
             QueryCreator.ShowError(null, "Errori nel trasferimento del file nella cartella del server.",errors);
            return "Errori nel trasferimento del file";
        }
        
    }

    class FtpHelp {
        FtpClient myFtp;
        public int nMaxRetry = 2;
        public int nMaxRetryLogin = 2;
        public int timeBaseLogin = 2000;
        public List<string> errors = new List<string>();
        string lastFolder = "";

        string address;
        string user;
        string pwd;
        bool pasv;
        int port;

        static FtpHelp() {
            
        }

        public FtpHelp(string address, string user, string pwd, int port = 21, bool pasv = true) {
            this.address = address;
            this.pwd = pwd;
            this.user = user;
            this.port = port;
            this.pasv = pasv;
         
        }

        private string rootPath;

        private bool Reconnect() {
            if (myFtp.State != FtpClientState.Connected) {
                myFtp.Abort();
            }


            Thread.Sleep(1000);
            logout();
            Thread.Sleep(1000);
            Connect();
            Thread.Sleep(1000);
            return login();
        }

        public bool login() {
            int retry = nMaxRetryLogin;
            int delay = timeBaseLogin;
            while (retry > 0) {
                retry--;
                try {
                    if (!myFtp.Connected) {
                        string prefFtps = "ftps://";
                        if (address.ToLower().StartsWith(prefFtps)) {
                            myFtp.Connect(address.Substring(prefFtps.Length), port, AuthenticationMethod.Tls,
                                VerificationFlags.AllFlags, null);
                        }
                        else {
                            myFtp.Connect(address, port);
                        }

                    }

                    myFtp.Login(user, pwd);
                    rootPath = myFtp.GetCurrentFolder();
                    lastFolder = rootPath;

                    //lastFolder = "";
                    errors.Clear();
                    return true;
                }
                catch (Exception e) {
                    logout();
                    Connect();
                    Thread.Sleep(delay);
                    delay = delay * 2;
                    errors.Add(e.Message + "\r\n" + e.StackTrace);
                }
            }
            return false;
        }

        public void logout() {
            if (myFtp != null && myFtp.Connected) {
                myFtp.Disconnect();
            }
            myFtp = null;
            lastFolder = "";
            errors.Clear();
        }

        private void Connect() {
            int retry = nMaxRetryLogin;
            int retryDelay = timeBaseLogin;
            while (retry > 0) {
                retry--;
                myFtp = new FtpClient();
                try {
                    myFtp.UseRemoteAddress = true;
                    myFtp.Timeout = 30;
                    myFtp.KeepAliveInterval = 2;
                    myFtp.PassiveTransfer = pasv;
                    //myFtp.Connect(cfg.address, cfg.port);
                    string prefFtps = "ftps://";
                    if (address.ToLower().StartsWith(prefFtps)) {
                        myFtp.Connect(address.Substring(prefFtps.Length), port, AuthenticationMethod.Tls,
                            VerificationFlags.AllFlags, null);
                    }
                    else {
                        myFtp.Connect(address, port);
                    }

                    myFtp.RepresentationType = RepresentationType.Binary;
                    errors.Clear();
                    lastFolder = "";
                    return;
                }
                catch (Exception e) {
                    errors.Add(e.Message + "\r\n" + e.StackTrace);
                    System.Threading.Thread.Sleep(retryDelay);
                    retryDelay = retryDelay * 2;
                }
            }
            lastFolder = "";

        }

        public bool putFile(string remotedirectory, string remoteFilename, string localFilename) {
            int retry = nMaxRetry;
            while (retry > 0) {
                retry--;
                if (putFileAndCheck(remotedirectory, remoteFilename, localFilename)) {
                    return true;
                }
            }
            return false;
        }


        private bool putFileAndCheck(string remotedirectory, string remoteFilename, string localFilename) {
            bool res1 = putFileSimple(remotedirectory, remoteFilename, localFilename);
            if (!res1) {
                return false;
            }
            string fileTemp = Path.GetTempFileName();
            bool res2 = getFileSimple(remotedirectory, remoteFilename, fileTemp);
            if (!res2) {
                File.Delete(fileTemp);
                return false;
            }
            bool res = FileCompare(fileTemp, localFilename);
            File.Delete(fileTemp);
            return res;
        }


        private bool getFileSimple(string remotedirectory, string remoteFilename, string localFilename) {
            EnsureLogged();
            if (!myFtp.Connected) {
                errors.Add("Connessione al sito ftp non riuscita. La ricezione del file " + localFilename + " è stata annullata");
                return false;
            }
            int retry = nMaxRetry;
            while (retry > 0) {
                retry--;
                try {
                    ensureFolder(remotedirectory);
                    myFtp.ReceiveFile(remoteFilename, localFilename);
                    errors.Clear();
                    return true;
                }
                catch (Exception e) {
                    RestoreConnection();
                    errors.Add(e.Message + "\r\n" + e.StackTrace);
                }
            }
            return false;

        }

        private bool FileCompare(string file1, string file2) {
            int file1byte;
            int file2byte;
            FileStream fs1;
            FileStream fs2;

            // Determine if the same file was referenced two times.
            if (file1 == file2) {
                // Return true to indicate that the files are the same.
                return true;
            }

            // Open the two files.
            fs1 = new FileStream(file1, FileMode.Open, FileAccess.Read);
            fs2 = new FileStream(file2, FileMode.Open, FileAccess.Read);

            // Check the file sizes. If they are not the same, the files 
            // are not the same.
            if (fs1.Length != fs2.Length) {
                // Close the file
                fs1.Close();
                fs2.Close();

                // Return false to indicate files are different
                return false;
            }

            // Read and compare a byte from each file until either a
            // non-matching set of bytes is found or until the end of
            // file1 is reached.
            do {
                // Read one byte from each file.
                file1byte = fs1.ReadByte();
                file2byte = fs2.ReadByte();
            }
            while ((file1byte == file2byte) && (file1byte != -1));

            // Close the files.
            fs1.Close();
            fs2.Close();

            // Return the success of the comparison. "file1byte" is 
            // equal to "file2byte" at this point only if the files are 
            // the same.
            return ((file1byte - file2byte) == 0);
        }

        string cleanRootPath(string folder) {
            if (rootPath == "") {
                return folder;
            }
            if (!folder.StartsWith(rootPath)) {
                return folder;
            }
            if (folder == rootPath) {
                return "";
            }
            return folder.Substring(rootPath.Length);
        }


        void EnsureLogged() {

            if (myFtp == null) {
                Connect();
            }
            if (myFtp.State != FtpClientState.Connected) {
                RestoreConnection();
            }
        }


        void RestoreConnection() {

            string saveConn = lastFolder;
            logout();
            System.Threading.Thread.Sleep(1000);
            Connect();
            System.Threading.Thread.Sleep(1000);
            login();
            if (myFtp.Connected) {
                ensureFolder(saveConn);
            }
        }

        public void ensureFolder(string folder) {
            lastFolder = folder;
            string currFolder = myFtp.GetCurrentFolder();
            char sep = myFtp.ServerFolderSeparator;

            string targetFolder = cleanRootPath(folder.Replace('\\', myFtp.ServerFolderSeparator));
            //myFtp.ChangeCurrentFolder(targetFolder);

            //Risale tante volte quante sin quando non è alla radice oppure folder è sottoramo di currentfolder
            while (cleanRootPath(currFolder) != cleanRootPath(rootPath) && !cleanRootPath(targetFolder).StartsWith(cleanRootPath(currFolder))) {
                myFtp.ChangeToParentFolder();
                currFolder = myFtp.GetCurrentFolder();
            }

            //Scende tante volte quante  serve per arrivare alla directory desiderata
            string[] destFolderParts = cleanRootPath(targetFolder).Split(sep);
            string[] currFolderParts = cleanRootPath(currFolder).Split(sep);
            int i = 0;
            if (cleanRootPath(currFolder) != "") {
                i = currFolderParts.Length;
            }
            while (i < destFolderParts.Length) {
                myFtp.ChangeCurrentFolder("." + myFtp.ServerFolderSeparator + destFolderParts[i]);
                i += 1;
            }
            currFolder = myFtp.GetCurrentFolder();
            //SdiSysLogger.logWarn("Richiesta cartella " + folder + " spostato su " + currFolder);
        }

        private bool putFileSimple(string remotedirectory, string remoteFilename, string localFilename) {
            EnsureLogged();
            if (!myFtp.Connected) {
                errors.Add("Connessione al sito ftp non riuscita. L'invio del file " + localFilename +
                           " alla directory remota " + remotedirectory +
                           " è stata annullato");
                return false;
            }
            int retry = nMaxRetry;
            while (retry > 0) {
                retry--;
                try {
                    ensureFolder(remotedirectory);
                    myFtp.SendFile(localFilename, remoteFilename);
                    errors.Clear();
                    return true;
                }
                catch (Exception e) {
                    string err = "Inviando il file " + localFilename + " nel file " + remoteFilename +
                                 " nella cartella remota " + remotedirectory + " ho avuto il seguente errore:\r\n" +
                                 e.Message + "\r\n" + e.StackTrace;
                    RestoreConnection();
                    errors.Add(err);
                }
            }
            return false;

        }
    }
}
