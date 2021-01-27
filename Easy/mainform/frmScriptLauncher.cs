
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
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using metaeasylibrary;
using metadatalibrary;
using LiveUpdate;

namespace mainform {
    public partial class frmScriptLauncher : Form {
        DataAccess Conn;
        public frmScriptLauncher(DataAccess Conn ) {
            InitializeComponent();
            this.Conn = Conn;
        }

        private void btnRun_Click(object sender, EventArgs e) {
            StringBuilder sql = new StringBuilder(txtScript.Text+ "\n");
            DataTable dip = Conn.RUN_SELECT("dbdepartment", "iddbdepartment", null, null, null, false);
            int N=0;
            int NErr = 0;
            foreach (DataRow R in dip.Rows) {
                DataAccess DC = new DataAccess("dsn",
                            Conn.GetSys("server").ToString(),
                             Conn.GetSys("database").ToString(),
                             txtUser.Text, txtPassword.Text,
                              ((DateTime)Conn.GetSys("datacontabile")).Year, ((DateTime)Conn.GetSys("datacontabile")));
                if (!DC.Open()) {
                    QueryCreator.ShowError(this, "Errore", DC.LastError);
                    DC.Destroy();
                    continue;
                }
                DC.SQLRunner("setuser '" + R["iddbdepartment"].ToString() + "'",false,-1);
                string err = DC.LastError;
                if (err != "" && err != null) {
                    NErr++;
                    DC.Destroy();
                    continue;
                }
                //Easy_DataAccess DC = Easy_DataAccess.getEasyDataAccess("DSN",
                //        Conn.GetSys("server").ToString(),
                //        Conn.GetSys("database").ToString(),
                //    txtUser.Text, txtPassword.Text, "",
                //    R["iddbdepartment"].ToString(),
                //    ((DateTime)Conn.GetSys("datacontabile")).Year, ((DateTime)Conn.GetSys("datacontabile")),
                //    out msg, out dettaglio);
                //if (msg == "") msg = null;
                //bool res = msg == null;
                //if (res) {
                //    res = DC.Open();
                //    msg = "Non è stato possibile effettuare il collegamento al dipartimento.";
                //    dettaglio = DC.LastError;
                //}
                //if (!res) {
                //    QueryCreator.ShowError(this, msg, dettaglio);
                //    DC.Destroy();
                //    continue;
                //}
                Download.RUN_SCRIPT(DC, sql, "Esecuzione script");
                err = DC.LastError;
                if (err == null || err == "") N++;
                else NErr++;
                DC.Destroy();
            }
            if (NErr==0)
                MessageBox.Show("Script eseguito correttamente  su " + N.ToString() + " dipartimenti.");
            else
                MessageBox.Show("Script eseguito con errori su " + NErr.ToString() + " dipartimenti.");
        }

        private string UpdateDB(DataAccess DepConn) {

            string[] rempath = GetLiveUpdateAddress();
            EntityDispatcher Disp = new EntityDispatcher(DepConn);
            //Forzo la creazione perché posso aver aggiornato
            //la configurazione locale
            Download MyDownloadDB = new Download(Disp, rempath, C_FILEINDEXNAME,
                AppDomain.CurrentDomain.BaseDirectory);

            //Si può verififcare quando durante l'attesa per la connessione
            //al server web ci si disconnette dal Database
            DataAccess DownloadDBConnection = DepConn.Duplicate();
            MyDownloadDB.Connessione = DownloadDBConnection;
            MyDownloadDB.IsAdmin = Convert.ToBoolean(Disp.GetSys("IsSystemAdmin"));
            MyDownloadDB.GetNewDBVersion();
            string res = MyDownloadDB.GetLastErrorDB();
            DownloadDBConnection.Destroy();
            return res;

        }

        private string[] GetLiveUpdateAddress() {
            string[] siti = new string[3];
            try {
                string filename = AppDomain.CurrentDomain.BaseDirectory + "updateconfig.xml";
                //string filename="updateconfig.xml";
                DataSet DS = new DataSet();
                DS.ReadXml(filename);
                siti[0] = DS.Tables["configtable"].Rows[0]["httpupdatepath"].ToString();
                siti[1] = DS.Tables["configtable"].Rows[0]["httpupdatepath2"].ToString();
                siti[2] = DS.Tables["configtable"].Rows[0]["httpupdatepath3"].ToString();
            }
            catch { }
            return siti;
        }

        public static bool IsNet45OrNewer() {
            var result =
                Environment.Version.Major.Equals(4) &&
                Environment.Version.Minor.Equals(0) &&
                Environment.Version.Build.Equals(30319) &&
                Environment.Version.Revision >= 34000;

            return result;
        }

        private string C_FILEINDEXNAME = (IsNet45OrNewer() ? "fileindex4.xml" : "fileindex.xml");

        private void button1_Click(object sender, EventArgs e) {
            DataTable dip = Conn.RUN_SELECT("dbdepartment", "iddbdepartment", null, null, null, false);            
            foreach (DataRow R in dip.Rows) {
                txtScript.Text += "Aggiorno il dipartimento: " + R["iddbdepartment"].ToString() + "...";
                string msg;
                string dettaglio;
                Easy_DataAccess DC = Easy_DataAccess.getEasyDataAccess("DSN",
                        Conn.GetSys("server").ToString(),
                        Conn.GetSys("database").ToString(),
                    txtUser.Text, txtPassword.Text,
                    R["iddbdepartment"].ToString(),
                    ((DateTime)Conn.GetSys("datacontabile")).Year, ((DateTime)Conn.GetSys("datacontabile")),
                    out msg, out dettaglio);
                if (DC == null) {
                    txtScript.Text += "Impossibile collegarsi al dipartimento\r\n";
                    continue;
                }
                if (msg == "") msg = null;
                bool res = msg == null;
                if (res) {
                    res = DC.Open();
                    msg = "Non è stato possibile effettuare il collegamento al dipartimento.\r\n";
                    dettaglio = DC.LastError;
                }
                if (!res) {
                    txtScript.Text += "\r\nErrore: "+msg+"\r\n"+dettaglio+"nel collegamento al dipartimento\r\n";
                    QueryCreator.ShowError(this, msg, dettaglio);
                    DC.Destroy();
                    continue;
                }
                string o = UpdateDB(DC);
                txtScript.Text += "Esito:" + o+"\r\n";
                DC.Destroy();
                txtScript.Text += "Aggiornamento effettuato.\r\n";

            }
        }

        private void btnRunOne_Click(object sender, EventArgs e) {
            StringBuilder sql = new StringBuilder(txtScript.Text + "\n");
            int N = 0;
            int NErr = 0;

            Download.RUN_SCRIPT(Conn, sql, "Esecuzione script");
            string err = Conn.LastError;
            if (err == null || err == "") N++;
            else NErr++;
            if (NErr == 0)
                MessageBox.Show("Script eseguito correttamente  su " + N.ToString() + " dipartimenti.");
            else
                MessageBox.Show("Script eseguito con errori su " + NErr.ToString() + " dipartimenti.");

        }

        
    }
}
