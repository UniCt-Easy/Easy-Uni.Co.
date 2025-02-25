
/*
Easy
Copyright (C) 2025 Università degli Studi di Catania (www.unict.it)
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
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Configuration;
using Jose;
using Newtonsoft.Json;
using LiveUpdate;
using metadatalibrary;
using metaeasylibrary;
using System.Net;
using Xceed.Zip;
using Xceed.Compression;
using Xceed.FileSystem;
using System.IO;
using System.Reflection;

namespace DailyMaintenanceService
{
    public partial class ServiceMaintenance : ServiceBase
    {

        private string _logFileName = "__WindowsServiceLog.txt";
        string connectionString = "";
        Easy_DataAccess MyDataAccess = null;
        EntityDispatcher Dispatcher = null;

        //Live Update DB ------------------------------------------------------------
        private bool LiveUpdateDBModuleEnabled = false;
        private string LiveUpdateDBHourStart = "18:54";
        private int LiveUpdateDBTimer_hh = 0;
        private int LiveUpdateDBTimer_mm = 0;
        private Timer LiveUpdateDBTimer = new Timer();

        //PROGETTI ------------------------------------------------------------
        private bool progettiModuleEnabled = false;
        private string progettiHourStart = "4:00";
        private bool enableCalcProgetti = false;
        private bool enableCalcStipendiByEasy = false;
        private int ProgettiTimer_hh = 0;
        private int ProgettiTimer_mm = 0;
        private Timer ProgettiTimer = new Timer();

        //SEGRETERIE ------------------------------------------------------------
        private bool segreterieModuleEnabled = false;
        //private string segreterieHourStart = "4:00";
        //private bool enableCalcEnrollmentHash = false;

        //private int SegreterieTimer_hh = 0;
        //private int SegreterieTimer_mm = 0;
        //private Timer SegreterieTimer = new Timer();


        public ServiceMaintenance()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            logInfo("Service Started");

            //ottengo la stringa di connessione con la password decodificata--------------------------------------------
            connectionString = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
            var key = ConfigurationManager.AppSettings.Get("MasterKey");
            var MasterKey = Convert.FromBase64String(key);
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(connectionString);
            var json = JWT.Decode(builder.Password, MasterKey);
            SystemConfig o = JsonConvert.DeserializeObject<SystemConfig>(json);
            builder.Password = o.password;
            connectionString = builder.ConnectionString;

            //preparo data access e dispatcher
            MyDataAccess = Easy_DataAccess.getEasyDataAccess("EasyPay", builder.DataSource, builder.InitialCatalog, builder.UserID, builder.Password, "amministrazione", DateTime.Now.Year, DateTime.Now, out string error, out string detail);
            Dispatcher = new EntityDispatcher(MyDataAccess);

            Directory.SetCurrentDirectory(AppDomain.CurrentDomain.BaseDirectory);
            logInfo($"Setto la current directory a : {AppDomain.CurrentDomain.BaseDirectory}");


            getConf();

            //Live Update DB ------------------------------------------------------------
            logInfo($"{(LiveUpdateDBModuleEnabled ? $"Live Update DB Start at {LiveUpdateDBHourStart}" : "Live Update DB Disabled")} ");
            if (LiveUpdateDBModuleEnabled)
            {
                LiveUpdateDBTimer_hh = int.Parse(LiveUpdateDBHourStart.Split(':')[0]);
                LiveUpdateDBTimer_mm = int.Parse(LiveUpdateDBHourStart.Split(':')[1]);
                double interval = CalcInterval(LiveUpdateDBTimer_hh, LiveUpdateDBTimer_mm, 0);
                LiveUpdateDBTimer.Elapsed += new ElapsedEventHandler(LiveUpdateDBOnTimerElapsed);
                LiveUpdateDBTimer.Interval = interval;
                LiveUpdateDBTimer.Enabled = LiveUpdateDBModuleEnabled;
            }


            //PROGETTI ------------------------------------------------------------
            logInfo($"{(progettiModuleEnabled ? $"Maintenance progetti Start at {progettiHourStart}" : "Modulo progetti Disabled")} ");
            if (progettiModuleEnabled)
            {
                ProgettiTimer_hh = int.Parse(progettiHourStart.Split(':')[0]);
                ProgettiTimer_mm = int.Parse(progettiHourStart.Split(':')[1]);
                double interval = CalcInterval(ProgettiTimer_hh, ProgettiTimer_mm, 0);
                ProgettiTimer.Elapsed += new ElapsedEventHandler(ProgettiOnTimerElapsed);
                ProgettiTimer.Interval = interval;
                ProgettiTimer.Enabled = progettiModuleEnabled;
            }

            ////SEGRETERIE ------------------------------------------------------------
            //logInfo($"{(segreterieModuleEnabled ? $"Maintenance segreterie Start at {segreterieHourStart}" : "Modulo segreterie Disabled")} ");
            //if (segreterieModuleEnabled)
            //{
            //    SegreterieTimer_hh = int.Parse(segreterieHourStart.Split(':')[0]);
            //    SegreterieTimer_mm = int.Parse(segreterieHourStart.Split(':')[1]);
            //    double interval = CalcInterval(SegreterieTimer_hh, SegreterieTimer_mm, 0);
            //    SegreterieTimer.Elapsed += new ElapsedEventHandler(SegreterieOnTimerElapsed);
            //    SegreterieTimer.Interval = interval;
            //    SegreterieTimer.Enabled = segreterieModuleEnabled;
            //}

        }

        protected override void OnStop()
        {
            //Live Update DB ------------------------------------------------------------
            LiveUpdateDBTimer.Enabled = false;
            LiveUpdateDBTimer.Dispose();

            //PROGETTI ------------------------------------------------------------
            ProgettiTimer.Enabled = false;
            ProgettiTimer.Dispose();

            ////SEGRETERIE ------------------------------------------------------------
            //SegreterieTimer.Enabled = false;
            //SegreterieTimer.Dispose();


            logInfo("Service Stopped");
        }

        private void logInfo(string s)
        {
            try { System.IO.File.AppendAllText($"{AppDomain.CurrentDomain.BaseDirectory}{_logFileName}", DateTime.Now.ToString("yy-MM-dd HH:mm:ss") + " - " + s + "\r\n"); } catch { }
        }

        private void getConf()
        {
            try
            {
                string script = "select * from confsegreterie";
                DataTable T = MyDataAccess.SQLRunner(script, true);
                progettiModuleEnabled = T.Rows[0]["progettimoduleenabled"].ToString() == "S";
                segreterieModuleEnabled = T.Rows[0]["segreteriemoduleenabled"].ToString() == "S";
                LiveUpdateDBModuleEnabled = T.Rows[0]["liveupdatedbmoduleenabled"].ToString() == "S";
                LiveUpdateDBHourStart = T.Rows[0]["starttimeliveupdatedb"].ToString();

                //PROGETTI ------------------------------------------------------------
                if (progettiModuleEnabled)
                {
                    script = "select * from confprogetti";
                    T = MyDataAccess.SQLRunner(script, true);
                    progettiHourStart = T.Rows[0]["starttimecalcprogetti"].ToString();
                    enableCalcProgetti = T.Rows[0]["enablecalcprogetti"].ToString() == "S";
                    enableCalcStipendiByEasy = T.Rows[0]["getstipendibyeasy"].ToString() == "S";
                }
            }
            catch (Exception ex)
            {
                logInfo("Error reading confprogetti: " + ex.Message);

            }
        }

        private double CalcInterval(int hh, int mm, int ss)
        {
            DateTime now = DateTime.Now;
            DateTime scheduledTime = new DateTime(now.Year, now.Month, now.Day, hh, mm, ss);
            if (now > scheduledTime)
            {
                scheduledTime = scheduledTime.AddDays(1);
            }
            return (scheduledTime - now).TotalMilliseconds;
        }

        #region Live Update DB

        private string[] GetLiveUpdateAddress()
        {
            string[] siti = new string[3];
            try
            {
                siti[0] = ConfigurationManager.AppSettings.Get("httpupdatepath");
                siti[1] = ConfigurationManager.AppSettings.Get("httpupdatepath2");
                siti[2] = ConfigurationManager.AppSettings.Get("httpupdatepath3");
            }
            catch(Exception ex) {
                logInfo("Error reading App Settings: " + ex.Message);
            }
            return siti;
        }

        private void DeleteOldLog(DataAccess Conn)
        {
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

        void initLicenses()
        {
            string txtFile = "";
            string currdir = AppDomain.CurrentDomain.BaseDirectory;
            if (!currdir.EndsWith("\\")) currdir += "\\";
            string licFileName = Path.Combine(currdir, "licenses.dat");
            if (File.Exists(licFileName))
            {
                var b = File.ReadAllBytes(licFileName);
                var c = DataAccess.DecryptBytes(b);
                txtFile = UTF32Encoding.UTF8.GetString(c).Trim();
            }

            var couples = txtFile.Split('|');
            foreach (var cc in couples)
            {
                var kv = cc.Split(';');
                //if (kv[0] == "Grid") Xceed.Grid.Licenser.LicenseKey = kv[1];
                //if (kv[0] == "Editors") Xceed.Editors.Licenser.LicenseKey = kv[1];
                if (kv[0] == "Zip") Xceed.Zip.Licenser.LicenseKey = kv[1];
                //if (kv[0] == "Ftp") Xceed.Ftp.Licenser.LicenseKey = kv[1];
            }

        }

        private void LiveUpdateDBOnTimerElapsed(object sender, ElapsedEventArgs e)
        {
            LiveUpdateDBTimer.Interval = CalcInterval(LiveUpdateDBTimer_hh, LiveUpdateDBTimer_mm, 0);

            try
            {

                //------------------preparazione contesto uguale a quello di mainForm
                initLicenses();
                string C_FILEINDEXNAME =  "fileindex4.xml" ;

                //------------------aggiornamento vero e proprio come mainform.frmMain.UpdateDB()

                if (MyDataAccess == null) return;
                string[] rempath = GetLiveUpdateAddress();
                //Forzo la creazione perché posso aver aggiornato
                //la configurazione locale
                Download MyDownloadDB = new Download(Dispatcher, rempath, C_FILEINDEXNAME, AppDomain.CurrentDomain.BaseDirectory);
                if (!string.IsNullOrEmpty(MyDownloadDB.GetLastErrorDB()))
                {
                    logInfo("Inizializzazione: " + MyDownloadDB.GetLastErrorDB());
                    logInfo("Indirizzi chiamati:");
                    foreach (var r in rempath) {
                        logInfo(r);
                    }
                }

                var http = new Http(rempath, AppDomain.CurrentDomain.BaseDirectory);

                //Si può verififcare quando durante l'attesa per la connessione
                //al server web ci si disconnette dal Database
                if (MyDataAccess == null) return;
                DataAccess DownloadDBConnection = MyDataAccess.Duplicate();
                DeleteOldLog(DownloadDBConnection);
                if (MyDownloadDB == null) return;
                MyDownloadDB.Connessione = DownloadDBConnection;
                MyDownloadDB.IsAdmin = true;// Convert.ToBoolean(Dispatcher.GetSys("IsSystemAdmin"));
                MyDownloadDB.GetNewDBVersion();

                if (MyDownloadDB != null)
                    if (!string.IsNullOrEmpty(MyDownloadDB.GetLastErrorDB()))
                    {
                        var res = MyDownloadDB.GetLastErrorDB();
                        if (res.StartsWith("Versione "))
                            logInfo("Aggiornamento del database avvenuto o non necessario: " + res);
                        else
                            logInfo("Errore eseguendo L'aggiornamento del database: " + res);
                    }

                //se non è connesso non faccio nessun controllo di versione e/o aggiornamento
                if ( MyDownloadDB != null &&
                    !MyDownloadDB.Connected)
                {
                    MyDownloadDB.Connessione.Destroy();
                    MyDownloadDB.Connessione = null;
                    DownloadDBConnection = null;
                    return;
                }

                //terminato l'aggiornamento controllo la compatibilità della versione
                if (MyDownloadDB == null)
                {
                    QueryCreator.MarkEvent("ERRORE : MyDownloadDB == null alla riga 294 di ServiceMaintenance");
                    return;
                }
                MyDownloadDB.Connessione.Destroy();
                MyDownloadDB.Connessione = null;
            }
            catch (Exception ex)
            {
                logInfo("Errore eseguendo L'aggiornamento del database: " + ex.Message);
            }


        }

        #endregion

        private void ProgettiOnTimerElapsed(object sender, ElapsedEventArgs e)
        {
            ProgettiTimer.Interval = CalcInterval(ProgettiTimer_hh, ProgettiTimer_mm, 0);

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                //calcola gli stipendi da Easy in automatico
                if (enableCalcStipendiByEasy)
                {
                    try
                    {
                        using (SqlCommand command = new SqlCommand("amministrazione.sp_import_stipendi_da_viste_csa", connection))
                        {
                            command.CommandType = CommandType.StoredProcedure;
                            command.Parameters.Add(new SqlParameter("year", DateTime.Today.Year));
                            command.CommandTimeout = 300; //timeout di 5 minuti

                            // Esegui la stored procedure
                            int rowsAffected = command.ExecuteNonQuery();
                            logInfo($"sp_import_stipendi_da_viste_csa eseguita con successo.");
                        }
                    }
                    catch (Exception ex)
                    {
                        logInfo("Errore eseguendo sp_import_stipendi_da_viste_csa: " + ex.Message);

                    }
                }

                //calcola costi progetto automatico
                if (enableCalcProgetti)
                {
                    try
                    {
                        using (SqlCommand command = new SqlCommand("amministrazione.calcola_costi_progetti", connection))
                        {
                            command.CommandType = CommandType.StoredProcedure;
                            command.CommandTimeout = 300; //timeout di 5 minuti

                            // Esegui la stored procedure
                            int rowsAffected = command.ExecuteNonQuery();
                            logInfo($"calcola_costi_progetti eseguita con successo.");
                        }
                    }
                    catch (Exception ex)
                    {
                        logInfo("Errore eseguendo calcola_costi_progetti: " + ex.Message);

                    }
                }

                //aggiorno il costo orario per periodo per persona per progetto
                try
                {
                    using (SqlCommand command = new SqlCommand("amministrazione.sp_calcola_costi_periodi_persona_progetto", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add(new SqlParameter("idreg", string.Empty));
                        command.Parameters.Add(new SqlParameter("idprogetto", string.Empty));
                        command.Parameters.Add(new SqlParameter("idprogettokind", string.Empty));
                        command.CommandTimeout = 300; //timeout di 5 minuti

                        // Esegui la stored procedure
                        int rowsAffected = command.ExecuteNonQuery();
                        logInfo($"sp_calcola_costi_periodi_persona_progetto eseguita con successo.");
                    }
                }
                catch (Exception ex)
                {
                    logInfo("Errore eseguendo sp_calcola_costi_periodi_persona_progetto: " + ex.Message);

                }
            }

        }

        //private void SegreterieOnTimerElapsed(object sender, ElapsedEventArgs e)
        //{
        //    //calcola costi progetto automatico
        //    if (enableCalcEnrollmentHash)
        //    {
        //        using (SqlConnection connection = new SqlConnection(connectionString))
        //        {
        //            try
        //            {
        //                connection.Open();
        //                using (SqlCommand command = new SqlCommand("amministrazione.calcola_costi_segreterie", connection))
        //                {
        //                    command.CommandType = CommandType.StoredProcedure;
        //                    command.CommandTimeout = 300; //timeout di 5 minuti

        //                    // Esegui la stored procedure
        //                    int rowsAffected = command.ExecuteNonQuery();
        //                    logInfo($"calcola_costi_segreterie eseguita con successo.");
        //                }
        //            }
        //            catch (Exception ex)
        //            {
        //                logInfo("Errore eseguendo calcola_costi_segreterie: " + ex.Message);

        //            }
        //        }
        //    }

        //    SegreterieTimer.Interval = CalcInterval(SegreterieTimer_hh, SegreterieTimer_mm, 0);
        //    //logInfo(SegreterieTimer.Interval.ToString());
        //}

        // Metodi pubblici per il debug
        public void StartDebug()
        {
            OnStart(null);
        }

        public void StopDebug()
        {
            OnStop();
        }

    }

    public sealed class SystemConfig
    {
        /// <summary>
        /// Data e ora di scadenza dell'autorizzazione all'accesso.
        /// </summary>
        [JsonProperty("dbPassword")]
        public String password { get; private set; }

        [JsonConstructor]
        public SystemConfig(String password)
        {
            this.password = password;
        }
    }
}
