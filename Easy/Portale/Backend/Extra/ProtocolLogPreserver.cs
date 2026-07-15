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
using System.Data;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Xml.Linq;

using metadatalibrary;

using Document.Protocol;

using preserve;
using preserve.Metadata.AGID.DocumentoAmministrativoInformatico;
using preserve.Storage;
using preserve.Tenancy;
using preserve.UniStorage;

using Backend.CommonBackend;
using Backend.Controllers;

namespace Backend.Extra {

    // questo servizio dovrebbe diventare come dice il nome ProtocolLogPreserver 3 servizi:
    // 1. creazione del registro (Log)
    // 2. protocollazione (Protocol) (e usare quindi ProtocollerService)
    // 3. conservazione (Preserver)

    /// <summary>
    /// Risultato di una operazione di protocollazione di un Registro giornaliero di protocollo.
    /// </summary>
    public class ProtocolLogResult {

        /// <summary>
        /// Identificativi delle protocollazioni incluse nel Registro giornaliero di protocollo.
        /// </summary>
        public List<ProtocolID> ReferencedIDs { get; }
        /// <summary>
        /// Risultato della protocollazione del Registro giornaliero di protocollo.
        /// </summary>
        public ProtocolResult LogResult { get; }

        /// <summary>
        /// Costruisce il risultato di una protocollazione di un Registro giornaliero di protocollo.
        /// </summary>
        /// <param name="referencedIDs">Identificativi delle protocollazioni incluse nel Registro giornaliero di protocollo.</param>
        /// <param name="logResult">Risultato della protocollazione del Registro giornaliero di protocollo.</param>
        public ProtocolLogResult(List<ProtocolID> referencedIDs, ProtocolResult logResult) {
            
            ReferencedIDs = referencedIDs;
            LogResult = logResult;
        }
    }

    /// <summary>
    /// Rappresenta un file di un Registro giornaliero di protocollo
    /// e contiene i suoi dati.
    /// </summary>
    public class DailyLogFile : IProtocolFile {
        /// <summary>
        /// Data di riferimento del file di un Registro giornaliero di protocollo.
        /// </summary>
        public DateTime ReferenceDate { get; }
        /// <summary>
        /// Descrittore su filesystem del file di un Registro giornaliero di protocollo.
        /// </summary>
        public FileInfo FileDescriptor { get; }
        /// <summary>
        /// Contenuto del file di un Registro giornaliero di protocollo.
        /// </summary>
        public byte[] Contents { get; }
        /// <summary>
        /// Algoritmo di hash utilizzato per calcolare l'hash del file di segnatura.
        /// </summary>
        public HashAlgorithm HashAlgorithm { get; } = SHA256.Create();
        /// <summary>
        /// Hash del contenuto. Su DB abbiamo una descrizione incompleta di questo valore,
        /// non è descritto l'algoritmo utilizzato, è un varbinary.
        /// </summary>
        public byte[] Hash => HashAlgorithm.ComputeHash(Contents);

        /// <summary>
        /// Costruisce un  file di un Registro giornaliero di protocollo.
        /// </summary>
        /// <param name="refDate">Data di riferimento del file.</param>
        /// <param name="contents">Contenuto del file.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public DailyLogFile(DateTime refDate, byte[] contents) {

            ReferenceDate = refDate;
            FileDescriptor = new FileInfo($"registrogiornalieroprotocollo-{refDate:yyyyMMdd}.html");
            Contents = contents ?? throw new ArgumentNullException(nameof(contents));
        }
    }

    /// <summary>
    /// Gestisce la creazione e la conservazione del Registro giornaliero di protocollo.
    /// </summary>
    public class ProtocolLogPreserver {

        // su preserve dovremmo creare una interfaccia per Manager implementata su UniStorage
        // per il futuro, per quando avremo la Dependency Injection sul backend.

        /// <summary>
        /// Dispatcher.
        /// </summary>
        private static Dispatcher _dispatcher;
        /// <summary>
        /// Scheduler per la creazione del Registro giornaliero di protocollo.
        /// </summary>
        private static Timer _scheduler;
        /// <summary>
        /// Logger.
        /// </summary>
        private static BackendLogger _logger;
        /// <summary>
        /// Gestore della conservazione su UniStorage.
        /// </summary>
        private static Manager _unistorage;
        /// <summary>
        /// Protocollatore.
        /// </summary>
        private static Protocoller _protocoller;
        /// <summary>
        /// Amministrazione che effettua la conservazione.
        /// </summary>
        private static Administration _owner;
        /// <summary>
        /// Istanziatore del dataset di protocollo.
        /// </summary>
        private static ProtocolDSCreator _protocolDSCreator;

        /// <summary>
        /// Filtro per recuperare i dati del Registro giornaliero di protocollo.
        /// </summary>
        private static readonly Func<DateTime, string> logFilter =
            d => $"{_protocolDSCreator.DateFieldname} = '{d:yyyy-MM-dd}'";

        /// <summary>
        /// Nomi delle colonne da includere nel Registro giornaliero di protocollo.
        /// </summary>
        private static string[] _logTableColumnNames = new string[] {

            "protnumero",
            "codiceregistro",
            "idprotocollokind",
            "idclassificazioneprotocollo",
            "idclassificazioneprotocollo_2",
            "oggetto",
            
            //"!anteprima",
            //"annullato",
            //"codiceammipa",
            //"ct",
            //"cu",
            //"dataannullamento",
            //"idaoo",
            //"idreg_origine",
            //"lt",
            //"lu",
            //"motivoann",
            //"originecodiceaoo",
            //"origineidamm",
            //"originemail",
            //"protanno",
            //"protdata",
            //"testo",
            //"testosegnatura",
        };

        // se in futuro ci servissero altri mimetype, i title su tabella mimetype però non sono unici (teoricamente dovrebbero esserlo)
        // quindi non c'è corrispondenza biunivoca tra title e id => no dictionary
        ///// <summary>
        ///// Cache degli ID dei mimetypes registrati su database.
        ///// </summary>
        //private static Dictionary<string, int> _mimeTypesIDCache = new Dictionary<string, int>();

        /// <summary>
        /// ID protocollokind per Registro giornaliero di protocollo su tabella protocollokind.
        /// </summary>
        private static int _protocollokindID = 3; // Interno
        /// <summary>
        /// ID MimeType per text/html su tabella mimetype.
        /// </summary>
        private static int _mimetypeID = 17;
        /// <summary>
        /// ID protocollodockind per Registro giornaliero di protocollo su tabella protocollodockind.
        /// </summary>
        private static int _protocollodockindID = 5; // Interno - Documento
        /// <summary>
        /// Directory di lavoro per preserve.UniStorage.Manager.
        /// </summary>
        private readonly static DirectoryInfo _preserveDir =
            new DirectoryInfo(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, FileController.UploadPath, "preserve"));
        /// <summary>
        /// Istanza condivisa.
        /// </summary>
        private static ProtocolLogPreserver _instance;
        /// <summary>
        /// Valore dell'istanza.
        /// </summary>
        public static ProtocolLogPreserver Instance {
            get {
                if (_instance == null) {
                    _logger?.Log($"{nameof(ProtocolLogPreserver)}.Instance accessed before initialization.",
                                 BackendLogger.LogLevel.Warning);

                    return null;
                }

                return _instance;
            }
        }

        /// <summary>
        /// Istanzia il singleton.
        /// </summary>
        /// <param name="dispatcher">Dispatcher.</param>
        /// <param name="logger">Logger da utilizzare.</param>
        /// <param name="scheduler">Schedulatore per la protocollazione.</param>
        /// <param name="logTableColumnNames">Nomi delle colonne della tabella principale del dataset di protocollo.</param>
        private ProtocolLogPreserver(Dispatcher dispatcher, BackendLogger logger, Timer scheduler, string[] logTableColumnNames) {

            _dispatcher = dispatcher ?? throw new ArgumentException("Dispatcher non valido.");
            _logger = logger ?? throw new ArgumentException("Logger non valido.");

            _protocoller = new Protocoller(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, FileController.UploadPath));
            _scheduler = scheduler; // accettiamo uno scheduler nullo per disabilitare la schedulazione.

            _protocolDSCreator = new ProtocolDSCreator();
            _logTableColumnNames = logTableColumnNames ?? throw new ArgumentException("Le colonne del Registro giornaliero di protocollo devono essere specificate.");

            // recuperiamo da DB tutto il necessario per inizializzare l'istanza
            try {

                var id = _dispatcher.Connection.DO_READ_VALUE("mimetype", $"title = 'text/html'", "idmimetype");

                _mimetypeID = Convert.ToInt32(id);
            }
            catch (Exception e) {

                throw new Exception("Mimetype per il Registro giornaliero di protocollo e 'text/html' non configurato.", e);
            }

            try {

                var id = _dispatcher.Connection.DO_READ_VALUE("protocollodockind", $"title = 'Documento' and kind = 'Interno'", "idprotocollodockind");

                _protocollodockindID = Convert.ToInt32(id);
            }
            catch (Exception e) {

                throw new Exception("Classificazioni del Registro giornaliero di protocollo 'Documento' e 'Interno' non configurate.", e);
            }

            DataRow istituto;
            try {

                istituto = _dispatcher.Connection.RUN_SELECT("istitutoprinc", "*", null, null, "1", false).First();
            }
            catch (Exception e) {

                throw new Exception("Impossibile recuperare i dati dell'amministrazione.", e);
            }

            try {

                var denominazione = $"{_dispatcher.Connection.GetSys("agency")}";
                var partitaiva = $"{_dispatcher.Connection.GetSys("cfagency")}";
                var cf = $"{_dispatcher.Connection.GetSys("p_ivaagency")}";

                var codiceammipa = istituto["codiceammipa"].ToString();                                                     // codice IPA Amministrazione principale
                var codiceaooipa = _dispatcher.Connection.DO_READ_VALUE("aoo", null, "codiceaooipa").ToString();            // codice IPA AOO principale (prima riga mi dicono)
                var strutturacodiceipa = _dispatcher.Connection.DO_READ_VALUE("struttura", null, "codiceipa").ToString();   // codice IPA UOR principale (prima riga mi dicono)

                var administrativeSubject = new ProtocolSoggetto() {
                    Denominazione = denominazione,
                    PartitaIVA = partitaiva,
                    CodiceFiscale = cf,
                    IPAAmm = codiceammipa,
                    IPAAOO = codiceaooipa,
                    IPAUOR = strutturacodiceipa,
                };

                //    if (dsRegIstitutiPrinc.Tables["registryreference"].Rows.Count > 0)
                //        rowProtocolloDestinatario["destmail"] = dsRegIstitutiPrinc.Tables["registryreference"].Rows[0]["email"];

                var idreg = Convert.ToInt32(istituto["idreg"]);
                var email = _dispatcher.Connection.DO_READ_VALUE("registryreference", $"idreg = {idreg}", "email").ToString();

                _owner = new Administration(administrativeSubject, idreg, email);
            }
            catch (Exception e) {

                throw new Exception("Impossibile inizializzare i dati dell'amministrazione.", e);
            }

            var uniStorageConfig = EasyConfigReader.Read(_dispatcher, "UNISTORAGE");

            IStorage protocolLogFS;
            try {

                var tenantDir = new DirectoryInfo(Path.Combine(_preserveDir.FullName, _owner.AdministrativeSubject.CodiceFiscale));
                var TenantWorkDir = tenantDir.CreateSubdirectory("work");
                var TenantOKDir = tenantDir.CreateSubdirectory("ok");
                var TenantKODir = tenantDir.CreateSubdirectory("ko");

                var optionLoadFrom = FileSystem.OptionLoadFrom(FileSystem.LoadSource.Work, FileSystem.LoadSource.KO);

                protocolLogFS = new FileSystem(TenantWorkDir, _logger, TenantOKDir, TenantKODir, optionLoadFrom);
            }
            catch (Exception e) {

                throw new Exception("Impossibile inizializzare lo storage.", e);
            }

            var offices = new List<Office>() {

                new Office(_owner.AdministrativeSubject.IPAAmm, protocolLogFS)
            };

            // prendiamo il primo valore valido con un default di fallback nel caso la configurazione sia carente
            var identifier = new[] {
                _owner.AdministrativeSubject.PartitaIVA,
                _owner.AdministrativeSubject.CodiceFiscale
            }
            .FirstOrDefault(id => !string.IsNullOrWhiteSpace(id))
            ?? "ID_ENTE";

            var tenant = new Tenant(
                identifier,
                uniStorageConfig.TryGetValue("username", out string username) ? username : "",
                uniStorageConfig.TryGetValue("password", out string password) ? password : "",
                _owner.AdministrativeSubject.IPAAmm,
                protocolLogFS,
                offices
            );

            try {

                _unistorage = new Manager(
                    uniStorageConfig.TryGetValue("endpoint", out string endpoint) ? endpoint : throw new Exception("Endpoint UniStorage non configurato."),
                    protocolLogFS as FileSystem,
                    Manager.OptionRequestWait(TimeSpan.FromMilliseconds(100), TimeSpan.FromMilliseconds(77)),
                    Manager.OptionTenant(tenant)
                );
            }
            catch (Exception e) {

                throw new Exception($"Impossibile inizializzare il client per la conservazione.", e);
            }

            _logger.Log("Inizializzazione completata.", BackendLogger.LogLevel.Information);
        }

        /// <summary>
        /// Imposta il dispatcher, il logger e un timer di esecuzione sul servizio.
        /// </summary>
        /// <param name="dispatcher">Dispatcher utilizzato sul servizio.</param>
        public static void Initialize(Dispatcher dispatcher) {

            if (_dispatcher != null || _logger != null)
                throw new InvalidOperationException($"'{nameof(ProtocolLogPreserver)}' già inizializzato.");

            _dispatcher = dispatcher;

            var cfg = EasyConfigReader.Read(_dispatcher, "PROTOCOLLOGPRESERVER");

            // logger
            BackendLogger.LogLevel logLevel;
            if (cfg.TryGetValue("loglevel", out string logLevelStr) &&
                Enum.TryParse(logLevelStr, ignoreCase: true, out BackendLogger.LogLevel parsedLevel)) {
                logLevel = parsedLevel;
            }
            else {
                logLevel = BackendLogger.LogLevel.Error;
            }

            _logger = new BackendLogger(dispatcher, logLevel, nameof(ProtocolLogPreserver));

            // instance
            try {

                _instance = new ProtocolLogPreserver(_dispatcher, _logger, _scheduler, _logTableColumnNames);
            }
            catch (Exception e) {

                _logger.Log($"Impossibile inizializzare l'istanza: {e.Message}", BackendLogger.LogLevel.Critical);
            }

            // scheduler
            bool schedulerEnabled = false;
            if (cfg.TryGetValue("enabled", out string enabledStr) &&
                bool.TryParse(enabledStr, out bool enabledParsed)) {
                schedulerEnabled = enabledParsed;
            }

            if (!schedulerEnabled) {
                _logger.Log("Schedulazione disabilitata.", BackendLogger.LogLevel.Warning);
                return; // non inizializziamo il timer
            }

            // ora di esecuzione (default 00:30)
            int hour = 0;
            if (cfg.TryGetValue("hours", out string hourStr) &&
                int.TryParse(hourStr, out int parsedHour)) {
                hour = parsedHour;
            }

            int minute = 30;
            if (cfg.TryGetValue("minutes", out string minuteStr) &&
                int.TryParse(minuteStr, out int parsedMinute)) {
                minute = parsedMinute;
            }

            int seconds = 0;
            if (cfg.TryGetValue("seconds", out string secondsStr) &&
                int.TryParse(secondsStr, out int parsedSeconds)) {
                seconds = parsedSeconds;
            }

            var runTime = new TimeSpan(hour, minute, seconds);
            _logger.Log($"Schedulazione abilitata alle ore {runTime}.", BackendLogger.LogLevel.Information);

            // calcoliamo l'orario della prima esecuzione
            var now = DateTime.Now;
            var scheduledTime = DateTime.Today.Add(runTime);
            if (now > scheduledTime)
                scheduledTime = scheduledTime.AddDays(1);

            var timeToGo = scheduledTime - now;

            // inizializziamo il timer con una funzione che esegue l'handler e reimposta il timer
            _scheduler = new Timer(x => {

                try {

                    // elaboriamo il giorno precedente
                    Instance.HandleDailyLog(DateTime.Today.AddDays(-1));
                }
                catch (Exception e) {

                    _logger.logException(e);
                }

                // calcoliamo il prossimo orario di esecuzione
                var nextRun = DateTime.Today.Add(runTime);
                _logger.Log($"Prossima esecuzione schedulata per le ore {nextRun}.", BackendLogger.LogLevel.Information);

                if (DateTime.Now > nextRun)
                    nextRun = nextRun.AddDays(1);

                // calcoliamo il tempo di attesa
                var delay = nextRun - DateTime.Now;

                // riprogrammiamo il timer
                _scheduler.Change(delay, Timeout.InfiniteTimeSpan);

            }, null, timeToGo, Timeout.InfiniteTimeSpan);
        }

        /// <summary>
        /// Gestisce la creazione, la protocollazione e l'invio in conservazione del Registro giornaliero di protocollo.
        /// </summary>
        /// <param name="referenceDate">Data del Registro giornaliero di protocollo da gestire.</param>
        public void HandleDailyLog(DateTime referenceDate) {

            DataSet logData = null;
            try {

                logData = RetrieveLogData(logFilter(referenceDate));
            }
            catch (Exception e) {

                _logger.logException(new Exception($"Impossibile recuperare i dati per formare il Registro giornaliero di protocollo del {referenceDate:dd/MM/yyyy}", e));
            }

            DailyLogFile logFile = null;
            try {
                logFile = CreateDailyLog(logData, referenceDate);
            }
            catch (Exception e) {
                _logger.logException(new Exception($"Impossibile creare il Registro giornaliero di protocollo del {referenceDate:dd/MM/yyyy}", e));
                return;
            }

            _logger.Log($"Registro giornaliero di protocollo del {logFile.ReferenceDate:dd/MM/yyyy} creato correttamente con nome '{logFile.FileDescriptor.Name}'.", BackendLogger.LogLevel.Information);

            ProtocolLogResult res = null;
            try {
                var protocolIDs = logData.Tables[_protocolDSCreator.Tablename].AsEnumerable().Select(row => new ProtocolID(row)).ToList();
                res = ProtocolDailyLog(protocolIDs, logFile);
            }
            catch (Exception e) {
                _logger.logException(new Exception($"Impossibile protocollare il Registro giornaliero di protocollo del {logFile.ReferenceDate:dd/MM/yyyy}", e));
                return;
            }

            _logger.Log($"Registro giornaliero di protocollo del {logFile.ReferenceDate:dd/MM/yyyy} " +
                $"protocollato correttamente il {res.LogResult.ID.Date:dd/MM/yyyy} " +
                $"con numero di protocollo {res.LogResult.ID.Number} " +
                $"e memorizzato in '{Path.Combine(_protocoller.AttachmentDir.FullName, res.LogResult.AttachmentPath)}'.", BackendLogger.LogLevel.Information);

            string protIDsString = string.Join(", ", res.ReferencedIDs.Select(rid => $"({rid.Year}, {rid.Number})"));
            try {
                MarkDataAsLogged(res);
            }
            catch (Exception e) {
                _logger.logException(new Exception($"Impossibile marcare le protocollazioni con identificativi {protIDsString} incluse nel Registro di protocollo del {referenceDate:dd/MM/yyyy}.", e));
            }

            _logger.Log($"Protocollazioni con identificativi {protIDsString} marcate per il Registro di protocollo del {referenceDate:dd/MM/yyyy}.", BackendLogger.LogLevel.Information);

            IArchiveInfo logArchiveInfo = null;
            try {
                logArchiveInfo = StoreDailyLog(logFile, res.LogResult);
            }
            catch (Exception e) {
                _logger.logException(new Exception($"Impossibile archiviare il Registro di protocollo del {referenceDate:dd/MM/yyyy}.", e));
                return;
            }

            _logger.Log($"Registro giornaliero di protocollo archiviato correttamente in '{logArchiveInfo.ApiIndexFileReference.Container.FullName}'.", BackendLogger.LogLevel.Information);

            List<IArchiveInfo> archives = new List<IArchiveInfo>();
            try {
                archives = _unistorage.LoadLocal();
            }
            catch (Exception e) {
                _logger.logException(new Exception($"Impossibile caricare i Registri giornalieri di protocollo.", e));
                return;
            }

            _logger.Log($"Trovati {archives.Count} Registri giornalieri di protocollo da inviare in conservazione.", BackendLogger.LogLevel.Information);

            try {
                _unistorage.Send(archives);
            }
            catch (Exception e) {
                _logger.logException(new Exception($"Impossibile inviare i Registri giornalieri di protocollo.", e));
                return;
            }

            _logger.Log($"{archives.Count} registr{(archives.Count == 1 ? "o" : "i")} giornalieri di protocollo inviati in conservazione.", BackendLogger.LogLevel.Information);
        }

        /// <summary>
        /// Recupera i dati per la costruzione del registro di protocollo
        /// </summary>
        /// <param name="filter">Filtro da applicare alla tabella principale del dataset di protocollo.</param>
        /// <returns>Dataset di protocollo filtrato.</returns>
        private static DataSet RetrieveLogData(string filter) {

            //var logData = DataUtils.createDataSet(_protocolDSCreator.Tablename, _protocolDSCreator.Edittype);
            var logData = _protocolDSCreator.CreateDataSet(_dispatcher);
            if (logData == null) return null;

            var getData = new GetData();
            getData.InitClass(logData, _dispatcher.Connection, _protocolDSCreator.Tablename);
            getData.GET_PRIMARY_TABLE(filter);

            var dt = logData.Tables[_protocolDSCreator.Tablename];
            if (dt.Rows.Count > 0) {

                foreach (DataRow mainRow in dt.Rows) {

                    getData.DO_GET(false, mainRow);
                }
            }

            var descrFilter = _dispatcher.Connection.GetQueryHelper().CmpEq("tablename", _protocolDSCreator.Tablename);
            var colDescr = _dispatcher.Connection.RUN_SELECT("coldescr", "*", null, descrFilter, null, false);

            foreach (DataColumn c in logData.Tables[_protocolDSCreator.Tablename].Columns) {
                string expr = "colname ='" + c.ColumnName + "'";
                DataRow[] rows = colDescr.Select(expr);
                if (rows.Length > 0) {
                    var caption = rows[0]["caption"];
                    if (caption != DBNull.Value) {
                        c.Caption = caption.ToString();
                    }
                }
            }

            return logData;
        }

        /// <summary>
        /// Crea il Registro giornaliero di protocollo per la data di riferimento specificata.
        /// </summary>
        /// <param name="logData">Dati per la creazione del Registro giornaliero di protocollo.</param>
        /// <param name="referenceDate">Data di riferimento per la creazione del Registro giornaliero di protocollo.</param>
        /// <returns>Registro giornaliero di protocollo.</returns>
        private static DailyLogFile CreateDailyLog(DataSet logData, DateTime referenceDate) {

            string logHtmlString = BuildDailyLogHtml(logData, referenceDate, _logTableColumnNames);
            byte[] logContents = Encoding.UTF8.GetBytes(logHtmlString);

            return new DailyLogFile(referenceDate, logContents);
        }

        /// <summary>
        /// Crea l'archivio di conservazione contenente il Registro giornaliero di protocollo.
        /// </summary>
        /// <param name="logFile">File del Registro giornaliero di protocollo.</param>
        /// <param name="pr">Dati di protocollazione per il Registro giornaliero di protocollo.</param>
        /// <returns>Archivio contenente il Registro giornaliero di protocollo.</returns>
        private IArchiveInfo StoreDailyLog(DailyLogFile logFile, ProtocolResult pr) {

            var logFileSignature = Components.Signature.CreaSegnatura(
                _owner.AdministrativeSubject.IPAAmm,
                _owner.AdministrativeSubject.IPAAOO,
                pr.ProtocolCode,
                pr.ID.Number.ToString(),
                $"{pr.ID.Date:yyyy-MM-dd}",
                pr.Subject,
                "", // classificaDenominazione
                _owner.AdministrativeSubject.Denominazione,
                _owner.AdministrativeSubject.IPAAmm,
                _owner.AdministrativeSubject.Denominazione,
                _owner.AdministrativeSubject.IPAAmm,
                logFile.FileDescriptor.Name,
                logFile.Contents
            );

            var preserveProtocolOwner = new Soggetto() {
                denominazione = _owner.AdministrativeSubject.Denominazione,
                partitaiva = _owner.AdministrativeSubject.PartitaIVA,
                codicefiscale = _owner.AdministrativeSubject.CodiceFiscale,
                IPAAmm = _owner.AdministrativeSubject.IPAAmm,
                IPAAOO = _owner.AdministrativeSubject.IPAAOO,
                IPAUOR = _owner.AdministrativeSubject.IPAUOR,
            };

            var logArchive = new PreserveProtocol(
                pr.ID.Date,
                pr.ID.Number.ToString(),
                logFile.FileDescriptor.Name,
                logFile.Contents,
                logFileSignature,
                preserveProtocolOwner);

            var archiveInfos = _unistorage.StoreLocal(new PreserveData[] { logArchive }, DocumentoAmministrativoInformaticoType.ProtocolLogFactory, _owner.AdministrativeSubject.IPAAmm);

            return archiveInfos.First();
        }

        /// <summary>
        /// Protocolla il Registro di protocollo giornaliero.
        /// </summary>
        /// <param name="referencedProtocolIDs"></param>
        /// <param name="logFile">Descrittore del file del Registro di protocollo giornaliero.</param>
        /// <returns>Riga di risultato della protocollazione.</returns>
        private ProtocolLogResult ProtocolDailyLog(List<ProtocolID> referencedProtocolIDs, DailyLogFile logFile) {

            // dataset vuoto
            //var requestDS = DataUtils.createDataSet(_protocolDSCreator.Tablename, _protocolDSCreator.Edittype);
            var requestDS = _protocolDSCreator.CreateDataSet(_dispatcher);

            //var requestDS = _protocolDSCreator.CreateDataSet(_dispatcher);

            DataTable protocollo = requestDS.Tables["protocollo"];
            DataTable protocollodestinatario = requestDS.Tables["protocollodestinatario"];
            DataTable protocollodoc = requestDS.Tables["protocollodoc"];
            DataTable protocollodocelement = requestDS.Tables["protocollodocelement"];

            // caricamento metadati
            var metaProtocollo = _dispatcher.GetMeta("protocollo");
            var metaProtocolloDestinatario = _dispatcher.GetMeta("protocollodestinatario");
            var metaProtocolloDoc = _dispatcher.GetMeta("protocollodoc");
            var metaProtocollodocElement = _dispatcher.GetMeta("protocollodocelement");

            // creazione nuove righe con default
            DataRow rowProtocollo = metaProtocollo.Get_New_Row(null, protocollo);
            DataRow rowProtocolloDestinatario = metaProtocolloDestinatario.Get_New_Row(rowProtocollo, protocollodestinatario);
            DataRow rowProtocolloDoc = metaProtocolloDoc.Get_New_Row(rowProtocollo, protocollodoc);
            DataRow rowProtocolloDocElement = metaProtocollodocElement.Get_New_Row(rowProtocolloDoc, protocollodocelement);

            // riga protocollo
            rowProtocollo["originemail"] = _owner.EmailAddress;
            rowProtocollo["originecodiceaoo"] = _owner.AdministrativeSubject.IPAAOO;
            rowProtocollo["origineidamm"] = _owner.AdministrativeSubject.IPAUOR;
            rowProtocollo["idreg_origine"] = _owner.IDRegistry;

            rowProtocollo["idprotocollokind"] = _protocollokindID;
            rowProtocollo["oggetto"] = DocumentoAmministrativoInformaticoType.ProtocolLogSubject(logFile.ReferenceDate);
            rowProtocollo["protdata"] = DateTime.Now;
            rowProtocollo["testo"] = ""; //testo;
            rowProtocollo["codiceammipa"] = _owner.AdministrativeSubject.IPAAmm; //dsRegIstitutiPrinc.Tables["istitutoprinc"].Rows[0]["codiceammipa"];
            rowProtocollo["idaoo"] = 1; // (prima riga mi dicono)  //dsRegIstitutiPrinc.Tables["aoo"].Rows[0]["idaoo"];
            rowProtocollo["codiceregistro"] = ""; //codiceregistro;
            rowProtocollo["annullato"] = "N";

            // riga destinatario
            rowProtocolloDestinatario["destmail"] = _owner.EmailAddress;
            rowProtocolloDestinatario["destcodiceaoo"] = _owner.AdministrativeSubject.IPAAOO;
            rowProtocolloDestinatario["destidamm"] = _owner.AdministrativeSubject.IPAUOR;
            rowProtocolloDestinatario["idreg_dest"] = _owner.IDRegistry;

            // riga documento
            rowProtocolloDoc["idprotocollorifkind"] = 3;    //  Riferimento a un documento informatico contenuto nella struttura MIME che costituisce il messaggio
            rowProtocolloDoc["idmimetype"] = _mimetypeID;

            rowProtocolloDoc["fileName"] = logFile.FileDescriptor.Name;
            rowProtocolloDoc["datadoc"] = DateTime.Now;

            // riga elemento documento
            rowProtocolloDocElement["idprotocollodockind"] = _protocollodockindID;
            rowProtocolloDocElement["oggetto"] = DocumentoAmministrativoInformaticoType.ProtocolLogSubject(logFile.ReferenceDate);
            rowProtocolloDocElement["telematicohash"] = logFile.Hash;

            DataSet res;

            try {

                res = _protocoller.Protocol(_dispatcher, requestDS, logFile);
            }
            catch (Exception e) {

                throw new Exception("Errore durante la protocollazione.", e);
            }

            var logResult = new ProtocolResult(res);

            return new ProtocolLogResult(referencedProtocolIDs, logResult);
        }

        /// <summary>
        /// Costruisce il contenuto html del Registro giornaliero di protocollo.
        /// </summary>
        /// <param name="logData">Dataset dei dati di protocollo.</param>
        /// <param name="date">Data di riferimento per la creazione del Registro giornaliero di protocollo.</param>
        /// <param name="ColumnNames">Nomi delle colonne da includere nel Registro giornaliero di protocollo.</param>
        /// <returns>Contenuto html del Registro giornaliero di protocollo.</returns>
        private static string BuildDailyLogHtml(DataSet logData, DateTime date, IEnumerable<string> ColumnNames) {
            var table = logData.Tables[_protocolDSCreator.Tablename];

            var selectedColumns = ColumnNames
                .Select(name => table.Columns[name])
                .Where(c => c != null)
                .ToList();

            var docKindTable = _dispatcher.Connection.CreateTableByName("protocollokind", "*");
            _dispatcher.Connection.RUN_SELECT_INTO_TABLE(docKindTable, null, null, null, false);

            var docKindLookup = docKindTable.Rows
                .Cast<DataRow>()
                .ToDictionary(
                    r => r.Field<int>("idprotocollokind"),
                    r => r.Field<string>("title")
                );

            var classificazioneProtocolloTable = _dispatcher.Connection.CreateTableByName("classificazioneprotocollo", "*");
            _dispatcher.Connection.RUN_SELECT_INTO_TABLE(classificazioneProtocolloTable, null, null, null, false);

            var classificazioneProtocolloLookup = classificazioneProtocolloTable.Rows
                .Cast<DataRow>()
                .ToDictionary(
                    r => r.Field<int>("idclassificazioneprotocollo"),
                    r => r.Field<string>("title")
                );

            // Build HTML
            var html =
                new XElement("html",
                    new XAttribute("lang", "it"),
                    new XElement("head",
                        new XElement("meta", new XAttribute("charset", "UTF-8")),
                        new XElement("title", "Registro giornaliero di protocollo"),
                        new XElement("style", @"
                    body { font-family: Arial, sans-serif; margin: 20px; }
                    header { text-align: center; margin-bottom: 20px; }
                    table { width: 100%; border-collapse: collapse; }
                    thead { background-color: #f2f2f2; }
                    th, td { border: 1px solid #ccc; padding: 8px; text-align: left; }
                ")
                    ),
                    new XElement("body",
                        new XElement("header",
                            new XElement("h1", "Registro di protocollo giornaliero"),
                            new XElement("p", "Data: " + date.ToString("dd/MM/yyyy"))
                        ),
                        new XElement("table",
                            new XElement("thead",
                                new XElement("tr",
                                    selectedColumns.Select(c =>
                                        new XElement("th",
                                            !string.IsNullOrWhiteSpace(c.Caption) ? c.Caption : c.ColumnName
                                        )
                                    )
                                )
                            ),
                            new XElement("tbody",
                                table.Rows.Cast<DataRow>()
                                    .Select(r =>
                                        new XElement("tr",
                                            selectedColumns.Select(c =>
                                                new XElement("td", GetCellValue(r, c, docKindLookup, classificazioneProtocolloLookup))
                                            )
                                        )
                                    )
                            )
                        )
                    )
                );

            return "<!DOCTYPE html>\n" + html.ToString();
        }

        /// <summary>
        /// Recupera un valore dai dizionari forniti.
        /// </summary>
        /// <param name="r">Riga.</param>
        /// <param name="c">Colonna.</param>
        /// <param name="docKindLookup">Dizionario dei tipi documento.</param>
        /// <param name="classificazioneProtocolloLookup">Dizionario delle classificazioni.</param>
        /// <returns>Valore da utilizzare.</returns>
        private static object GetCellValue(
            DataRow r,
            DataColumn c,
            Dictionary<int, string> docKindLookup,
            Dictionary<int, string> classificazioneProtocolloLookup) {
            var value = r[c];

            if (value == DBNull.Value)
                return "";

            var colName = c.ColumnName;

            if (colName == "idprotocollokind") {
                if (int.TryParse(value.ToString(), out int key)) {
                    return docKindLookup.TryGetValue(key, out string desc) ? desc : "";
                }
                return "";
            }

            if (colName == "idclassificazioneprotocollo" || colName == "idclassificazioneprotocollo_2") {
                if (int.TryParse(value.ToString(), out int key)) {
                    return classificazioneProtocolloLookup.TryGetValue(key, out string desc) ? desc : "";
                }
                return "";
            }

            return value;
        }

        /// <summary>
        /// Valorizza anno e numero di protocollo sulle protocollazioni incluse in una operazione di creazione del Registro giornaliero di protocollo.
        /// </summary>
        /// <param name="plr">Risultato dell'operazione di creazione del Registro giornaliero di protocollo.</param>
        private static void MarkDataAsLogged(ProtocolLogResult plr) {

            // da effettuare in futuro con una postdata

            string protAnnoFieldname = ProtocolID.AnnoFieldname;
            string protNumeroFieldname = ProtocolID.NumeroFieldname;

            string protAnnoRegistroFieldname = "protannoregistro";
            string protNumeroRegistroFieldname = "protregistro";

            var allIDs = new List<ProtocolID>(plr.ReferencedIDs) {
                plr.LogResult.ID
            };

            var filter = $"{protAnnoFieldname} = {plr.LogResult.ID.Year}" +
                $" and {protNumeroFieldname} in ({string.Join(",", allIDs.Select(id => $"{id.Number}"))})" +
                $" and {protAnnoRegistroFieldname} is null and {protNumeroRegistroFieldname} is null";

            var query = $"update {_protocolDSCreator.Tablename}" +
                $" set {protAnnoRegistroFieldname} = {plr.LogResult.ID.Year}, {protNumeroRegistroFieldname} = {plr.LogResult.ID.Number}" +
                $" where {filter}";

            var res = _dispatcher.Connection.SQLRunner(query);
        }
    }
}