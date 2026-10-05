using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Threading;
using System.Reflection;

using Newtonsoft.Json;

using sdiLog;
using ApiClient;

using preserve.Tenancy;
using preserve.Storage;
using preserve.Storage.Adapters;

using preserve.Metadata.AGID.DocumentoInformatico;

using preserve.UniStorage.Serialization;
using eventLog;

namespace preserve.UniStorage {

    /// <summary>
    /// Gestisce i tenant della conservazione verso UniStorage, la memorizzazione su storage locale degli archivi,
    /// il caricamento dallo storage locale e l'invio verso l'API rest di UniStorage.
    /// </summary>
    public partial class Manager { // resto della definizione in Options.cs

        /// <summary>
        /// Tenants gestiti con UniStorage.
        /// </summary>
        public List<Tenant> Tenants { get; set; } = new List<Tenant>();

        /// <summary>
        /// Modalità di ricerca degli uffici dei tenant.
        /// </summary>
        TMode OfficeSearchMode = TMode.Multi;

        /// <summary>
        /// Radice dello spazio di archiviazione locale.
        /// </summary>
        public FileSystem Storage { get; }

        /// <summary>
        /// Logger.
        /// </summary>
        public IPreserveLogger Logger => Storage.Logger;

        /// <summary>
        /// Client REST per l'API di conservazione remota.
        /// </summary>
        private readonly Client rest;

        /// <summary>
        /// Tempo di attesa minimo tra la ricezione di una risposta e l'invio di una richiesta.
        /// </summary>
        private TimeSpan minRequestWait = TimeSpan.FromMilliseconds(177);

        /// <summary>
        /// Tempo massimo usato come limite superiore per la selezione del jitter casuale.
        /// </summary>
        private TimeSpan maxRequestJitter = TimeSpan.FromMilliseconds(1000);

        /// <summary>
        /// Generatore di numeri casuali.
        /// </summary>
        private readonly Random jitterer = new Random();

        /// <summary>
        /// Intervallo di tempo di durata casuale tra 0 e 1000 ms.
        /// </summary>
        private TimeSpan Jitter => TimeSpan.FromMilliseconds(jitterer.Next(0, (int)maxRequestJitter.TotalMilliseconds));

        /// <summary>
        /// Tempo di attesa tra la ricezione di una risposta e l'invio di una richiesta.
        /// </summary>
        private TimeSpan RequestWait => minRequestWait + Jitter;

        /// <summary>
        /// Valuta se considerare una risposta positiva o negativa.
        /// </summary>
        /// <param name="r">Risposta da valutare.</param>
        /// <returns>True per una valutazione positiva, false per una negativa.</returns>
        private static Predicate<Response> Evaluator =
            response => response.esitoComplessivo == TEsito.OK; // questo valutatore potrebbe essere configurato da una opzione, specialmente se generalizzeremo la classe
                                                                // per l'uso con altri fornitori di conservazione

        /// <summary>
        /// Istanzia un client per l'API di UniStorage per la conservazione di file che utilizza il filesystem come storage locale.
        /// </summary>
        /// <param name="endpoint">Endpoint dell'API di conservazione.</param>
        /// <param name="storage">Spazio di archiviazione da utilizzare per la coda di invio / memorizzazione locale.</param>
        /// <param name="options">Opzioni.</param>
        public Manager(string endpoint, FileSystem storage, params Action<Manager>[] options) { // l'endpoint potrebbe diventare associato al tenant se si implementerà il multisourcing
                                                                                                // della conservazione

            try {
                Storage = storage ?? new FileSystem(
                    new DirectoryInfo(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "work")),
                    new Mlogger("UniStorage") 
                );
            }
            catch (Exception e) {

                throw new Exception($"Could not initialize storage: {e.Message}", e);
            }

            try {
                rest = new Client(
                    new Uri(endpoint),
                    Client.OptionConverters(Converters.Json)
                );
            }
            catch (Exception e) {

                Logger.logErrorToRegistry($"Could not instantiate API client, sending requests will fail: {e.Message}");
            }

            foreach (var option in options) {

                try {
                    option.Invoke(this);    // chiamata alla Invoke della Action che opera sul nostro oggetto (equivale a option(this), usiamo la Invoke per maggiore chiarezza)
                }
                catch (Exception e) {

                    throw new ArgumentException($"Could not initialize \"{GetType().Name}\" with option \"{option.GetType().Name}\": {e.Message}", e);
                }
            }

            var executingAssembly = Assembly.GetExecutingAssembly();
            Logger.logWarnToRegistry($"Client initialization completed ({executingAssembly.GetName()} {executingAssembly.GetName().Version}), office search mode is \"{OfficeSearchMode}\", {Tenants.Count()} tenants configured: {JsonConvert.SerializeObject(Tenants.ToList().Select(t => t.StringReferences))}");
        }

        /// <summary>
        /// Individua i tenant in base all'identificativo dell'ufficio.
        /// </summary>
        /// <param name="officeID">Identificativo dell'ufficio.</param>
        /// <returns>Collezione di Tenant associati solamente all'ufficio indicato.</returns>
        private List<Tenant> FindAll(string officeID) {

            // materializziamo il risultato: i chiamanti lo enumerano più volte (Any/First/Count/log) e la versione
            // lazy ricostruirebbe i Tenant ad ogni enumerazione.
            switch (OfficeSearchMode) {

                case TMode.Multi:
                default:
                    return Tenants.Select(t => new Tenant(t, t.Offices.Where(o => o.ID == officeID))).Where(t => t.Offices.Any()).ToList();

                case TMode.Single:
                    return Tenants;
            }
        }

        /// <summary>
        /// Memorizza documenti sullo storage. Se viene indicato un identificativo ufficio sarà utilizzato quello per tutti i documenti.
        /// </summary>
        /// <typeparam name="TMetadata">Tipo dei metadati.</typeparam>
        /// <param name="preserveDatas">Descrittori dei documenti da memorizzare.</param>
        /// <param name="metadataFactory">Funzione per la creazione dei metadati per la conservazione a partire dai dati di ingresso.</param>
        /// <param name="officeID">Identificativo dell'ufficio per cui memorizzare i documenti.</param> 
        /// <returns>Archivi memorizzati.</returns>
        public List<IArchiveInfo> StoreLocal<TMetadata>(
            IEnumerable<IPreserveData> preserveDatas,
            Func<PreserveData, TMetadata> metadataFactory,
            string officeID = null)
            where TMetadata : class {

            var data = new ConcurrentBag<IArchiveInfo>();

            var GroupedIPAPreserveDatas = string.IsNullOrWhiteSpace(officeID) ? // se officeID non è specificato dal chiamante
                preserveDatas.GroupBy(pd => pd.IDOffice) :                      // raggruppiamo per IPA (multi)
                preserveDatas.GroupBy(pd => officeID);                          // altrimenti assegniamo a tutti quello fornito dal chiamante (singolo)

            GroupedIPAPreserveDatas.AsParallel().ForAll(IPAPreserveDataGroup => {

                var matchingTenants = FindAll(IPAPreserveDataGroup.Key);  // individuiamo i tenant relativi

                if (!matchingTenants.Any()) {
                    Logger.logErrorToRegistry($"Could not store data for office \"{IPAPreserveDataGroup.Key}\", no matching tenant found. " +
                        $"Those files will not be stored: {string.Join(", ", IPAPreserveDataGroup.Select(ipdg => ipdg.Filename))}");

                    return;
                }

                var storingTenant = matchingTenants.First();   // scegliamo il primo tenant. Potremmo anche farlo su tutti i risultati, se ci interessa che un IPA sia figlio di più tenant

                // l'identificativo del tenant viene passato esplicitamente perchè le implementazioni
                // di IPreserveDataLegacy (interfaccia che è stata costruita appositamente per unificare i formati
                // presenti sul codice preesistente) non prevedono una multitenancy "implicita".
                // In poche parole il codice preesistente richiede anche esso l'esplicitazione del tenant e
                // per compatibilità questo è stato mantenuto. Al passaggio verso il multi si sarebbe dovuta implementare una
                // multitenancy con specificazione del tenant sugli archivi e non specificata dal chiamante.
                var storedIPAPreserveDatas = storingTenant.Offices.First().Storage
                    .Store(IPAPreserveDataGroup, metadataFactory, storingTenant.Name);

                storedIPAPreserveDatas.AsParallel().ForAll(storedIPAPreserveData => data.Add(storedIPAPreserveData));

            });

            var archiveInfos = data.ToList();

            Logger.logWarnToRegistry($"Received {preserveDatas.Count()} documents, stored {archiveInfos.Count()} archives: {JsonConvert.SerializeObject(archiveInfos.ToList().Select(ai => ai.StringReferences))}");

            return archiveInfos;
        }

        /// <summary>
        /// Memorizza documenti sullo storage. Se viene indicato un identificativo ufficio sarà utilizzato quello per tutti i documenti.
        /// </summary>
        /// <typeparam name="TMetadata">Tipo dei metadati.</typeparam>
        /// <param name="preserveDatasWithMetadatas">Descrittori dei documenti da memorizzare associati ai metadati.</param>
        /// <param name="officeID">Identificativo dell'ufficio per cui memorizzare i documenti.</param>
        /// <returns>Archivi memorizzati.</returns>
        public List<IArchiveInfo> StoreLocal<TMetadata>(
            IEnumerable<KeyValuePair<IPreserveData, TMetadata>> preserveDatasWithMetadatas,
            string officeID = null)
            where TMetadata : class {

            var data = new ConcurrentBag<IArchiveInfo>();

            var GroupedIPAPreserveDatasWithMetadatas = string.IsNullOrWhiteSpace(officeID) ? // se officeID non è specificato dal chiamante
                preserveDatasWithMetadatas.GroupBy(pdwm => pdwm.Key.IDOffice) :              // raggruppiamo per IPA (multi)
                preserveDatasWithMetadatas.GroupBy(pdwm => officeID);                        // altrimenti assegniamo a tutti quello fornito dal chiamante (singolo)

            GroupedIPAPreserveDatasWithMetadatas.AsParallel().ForAll(IPAPreserveDatasWithMetadatasGroup => {

                var matchingTenants = FindAll(IPAPreserveDatasWithMetadatasGroup.Key);  // individuiamo i tenant relativi

                if (!matchingTenants.Any()) {
                    Logger.logErrorToRegistry($"Could not store data for office \"{IPAPreserveDatasWithMetadatasGroup.Key}\", no matching tenant found. " +
                        $"Those files will not be stored: {string.Join(", ", IPAPreserveDatasWithMetadatasGroup.Select(ipdwmg => ipdwmg.Key.Filename))}");

                    return;
                }

                var storingTenant = matchingTenants.First();   // scegliamo il primo tenant. Potremmo anche farlo su tutti i risultati, se ci interessa che un IPA sia figlio di più tenant

                // l'identificativo del tenant viene passato esplicitamente perchè le implementazioni
                // di IPreserveDataLegacy (interfaccia che è stata costruita appositamente per unificare i formati
                // presenti sul codice preesistente) non prevedono una multitenancy "implicita".
                // In poche parole il codice preesistente richiede anche esso l'esplicitazione del tenant e
                // per compatibilità questo è stato mantenuto. Al passaggio verso il multi si sarebbe dovuta implementare una
                // multitenancy con specificazione del tenant sugli archivi e non specificata dal chiamante.
                var storedIPAPreserveDatas = storingTenant.Offices.First().Storage
                    .Store(IPAPreserveDatasWithMetadatasGroup.ToDictionary(kvp => kvp.Key, kvp => kvp.Value), storingTenant.Name);

                storedIPAPreserveDatas.AsParallel().ForAll(storedIPAPreserveData => data.Add(storedIPAPreserveData));

            });

            var archiveInfos = data.ToList();

            Logger.logWarnToRegistry($"Received {preserveDatasWithMetadatas.Count()} documents, stored {archiveInfos.Count()} archives: {JsonConvert.SerializeObject(archiveInfos.ToList().Select(ai => ai.StringReferences))}");

            return archiveInfos;
        }

        /// <summary>
        /// Carica dallo storage locale gli archivi memorizzati precedentemente.
        /// </summary>
        /// <param name="officeID">Identificativo dell'ufficio per cui caricare gli archivi.</param>
        /// <returns>Archivi caricati.</returns>
        public List<IArchiveInfo> LoadLocal(string officeID = null) {
            
            var data = new ConcurrentBag<IArchiveInfo>();

            var matchingTenants = FindAll(officeID);

            matchingTenants
                .SelectMany(t => t.Offices)
                .AsParallel()
                .ForAll(office => office.Storage.Load().AsParallel().ForAll(archiveInfo => data.Add(archiveInfo))); // carichiamo gli archivi da tutti gli uffici dei tenant

            var archiveInfos = data.ToList();

            Logger.logWarnToRegistry($"Loaded {archiveInfos.Count()} archives for office '{officeID}', found {matchingTenants.Count()} matching tenants: {JsonConvert.SerializeObject(matchingTenants.Select(mt => mt.StringReferences))}");

            return archiveInfos;
        }

        /// <summary>
        /// Invia all'API di conservazione gli archivi indicati e gestisce lo spostamento sullo Storage.
        /// </summary>
        /// <param name="archiveInfos">Archivi da inviare.</param>
        public void Send(IEnumerable<IArchiveInfo> archiveInfos) {

            var archives = archiveInfos.ToList();   // materializziamo: la collezione viene enumerata dal ciclo e dai conteggi finali

            var processedTenants = new List<Tenant>();
            var numSkippedArchives = 0;

            foreach (var archiveInfo in archives) { // se volessimo potremmo parallelizzare anche gli invii ma solo con una policy con rateo di invio e sliding window
                
                var matchingTenants = FindAll(archiveInfo.ApiIndex.OfficeID);

                if (!matchingTenants.Any()) {

                    numSkippedArchives++;

                    Logger.logErrorToRegistry($"Could not send archive for tenant \"{archiveInfo.ApiIndex.TenantID }\" and office \"{archiveInfo.ApiIndex.OfficeID}\", no matching offices found. Those files will not be sent: {string.Join(", ", (archiveInfo.ApiIndex as UniStorageIndex).documenti.Select(d => d.nomeFile))}");

                    continue;
                }

                var sendingTenant = matchingTenants.First();    // scegliamo il primo tenant. Potremmo anche farlo su tutti i risultati, se ci interessa che un IPA sia figlio di più tenant

                if (!sendingTenant.SendEnabled) {

                    Logger.logWarnToRegistry($"Tenant \"{sendingTenant.Name}\" (\"{sendingTenant.ID}\") is not enabled, archive \"{archiveInfo.ApiIndexFileReference.FullName}\" will not be sent ...");
                    continue;
                }

                processedTenants.Add(sendingTenant);

                OptionAuth(sendingTenant.Username, sendingTenant.Password).Invoke(this);    // impostiamo le credenziali del tenant sul client dell'API

                foreach (var office in sendingTenant.Offices) {

                    Dictionary<string, Attachment> attachments = archiveInfo.Attachments.ToDictionary(afr => afr.Key.Name, afr => afr.Value);

                    Response result = new Response() { esitoComplessivo = TEsito.KO };  // TODO: default, lo settiamo qua perchè serializzeremo su file anche nel caso non avessimo risposta
                                                                                        // per avere un archivio delle risposte che non sia solo su log. La gestione della risposta andrebbe
                                                                                        // modificata ne caso non si usasse il filesystem, al momento è un "hack" possibile perchè
                                                                                        // si usa il filesystem

                    try {
                        Thread.Sleep(Convert.ToInt32(RequestWait.TotalMilliseconds));   // TODO: se volessimo andrebbe usata una policy e le request possibilmente inviate in maniera asincrona:
                                                                                        // in questo modo diventerebbe veramente il tempo tra gli invii.
                                                                                        // Inoltre potremmo creare un'unica pipeline di invio + gestione della risposta.
                                                                                        // Insomma andrebbe usata una sliding window con un rateo di invio per ottimizzare il tutto

                        result = rest.PostEntity<UniStorageIndex, Response>("/consegna/pdv", archiveInfo.ApiIndex as UniStorageIndex, attachments);
                    }
                    catch (Exception e) {

                        office.Logger.logErrorToRegistry($"Communication error while sending archive \"{archiveInfo.ApiIndexFileReference.Name}\": {e.Message}");
                    }

                    // file metadati temporanei
                    var metadataFiles = archiveInfo.Attachments.Keys
                        .Where(file => Path.GetFileNameWithoutExtension(file.Name) != Path.GetFileNameWithoutExtension(archiveInfo.ApiIndexFileReference.Name))
                        .Select(file => new FileInfoAdapter(new FileInfo(Path.ChangeExtension(file.FullName, $".metadata.{typeof(DocumentoInformaticoType).Name}"))));

                    // file risposta
                    FileInfo responseFile = new FileInfo(Path.ChangeExtension(archiveInfo.ApiIndexFileReference.FullName, ".response"));
                    try {
                        File.WriteAllText(responseFile.FullName, JsonConvert.SerializeObject(result, Formatting.Indented));
                    }
                    catch (Exception e) {

                        office.Logger.logErrorToRegistry($"Can't store response for {archiveInfo.ApiIndexFileReference.Name} into {responseFile.FullName}: {e.Message}");
                    }

                    var archiveFiles = archiveInfo.Attachments.Keys     // aggiungiamo ai file dell'archivio inviati:
                        .Concat(new IFileReference[] {
                            archiveInfo.ApiIndexFileReference,          // riferimento al file dell'indice
                            new FileInfoAdapter(responseFile),          // riferimento al file della risposta
                        });

                    office.Logger.logWarnToRegistry($"Archive sent: {JsonConvert.SerializeObject(archiveInfo.StringReferences)}");

                    foreach (var archiveFile in archiveFiles) { // spostiamo i file dell'archivio - la versione parallela non sta funzionando, ci sono errori allo spostamento
                        office.Storage.Move(archiveFile, result, Evaluator);
                    }
                }
            }

            var numSentArchives = archives.Count - numSkippedArchives;

            Logger.logWarnToRegistry($"Received {archives.Count} documents, sent {numSentArchives} ({numSkippedArchives} skipped) archives: {JsonConvert.SerializeObject(processedTenants.Select(pt => pt.StringReferences))}");
        }
    }
}