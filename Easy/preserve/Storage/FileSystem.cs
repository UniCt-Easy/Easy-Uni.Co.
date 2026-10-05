using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Collections.Concurrent;
using eventLog;

using preserve.Storage.Adapters;

namespace preserve.Storage {

    /// <summary>
    /// Storage su filesystem.
    /// </summary>
    public class FileSystem : IStorage {

        /// <summary>
        /// Sorgenti per il caricamento dei file indice.
        /// </summary>
        public enum LoadSource {



            /// <summary>
            /// Directory di lavoro.
            /// </summary>
            Work,
            /// <summary>
            /// Directory per elaborazioni effettuate con successo.
            /// </summary>
            OK,
            /// <summary>
            /// Directory per elaborazioni effettuate senza successo
            /// </summary>
            KO
        }

        /// <summary>
        /// Logger delle operazioni effettuate sullo storage.
        /// </summary>
        public IPreserveLogger Logger { get; set; }

        /// <summary>
        /// Container dei file memorizzati.
        /// </summary>
        public IFileReferenceContainer Work { get; }

        /// <summary>
        /// Container dei file elaborati correttamente.
        /// </summary>
        public IFileReferenceContainer OK { get; }

        /// <summary>
        /// Container dei file elaborati con errori.
        /// </summary>
        public IFileReferenceContainer KO { get; }

        /// <summary>
        /// Container da cui caricare i file indice.
        /// </summary>
        private List<IFileReferenceContainer> loadSources = new List<IFileReferenceContainer>();

        /// <summary>
        /// Pattern utilizzato sull'enumeratore dei file indice.
        /// </summary>
        private string indexEnumeratorSearchPattern = "*.index";

        /// <summary>
        /// Indica se l'enumeratore deve enumerare ricorsivamente.
        /// </summary>
        private SearchOption indexEnumeratorRecursive = SearchOption.AllDirectories;

        /// <summary>
        /// File indice gestiti.
        /// </summary>
        public IEnumerable<IFileReference> Indexes =>
            loadSources.SelectMany(src => src.EnumerateFiles(indexEnumeratorSearchPattern, indexEnumeratorRecursive));

        /// <summary>
        /// Inizializza uno storage su filesystem che utilizza il logger indicato per loggare gli errori. Lo storage utilizza le directory eventualmente indicate per memorizzare
        /// i file elaborati, caricarli, e spostarli dopo un'ulteriore elaborazione.
        /// </summary>
        /// <param name="l">Logger da utilizzare.</param>
        /// <param name="work">Riferimento alla directory da utilizzare per memorizzare e caricare i file.</param>
        /// <param name="ok">Riferimento alla directory da utilizzare per i file elaborati correttamente.</param>
        /// <param name="ko">Riferimento alla directory da utilizzare per i file elaborati non correttamente.</param>
        public FileSystem(DirectoryInfo work, IPreserveLogger l, DirectoryInfo ok = null, DirectoryInfo ko = null, params Action<FileSystem>[] options) {

            Logger = l;

            try {
                work.Create();
                Work = new DirectoryInfoAdapter(work);
            }
            catch (Exception e) {

                throw new Exception($"Can't access work directory {work.FullName}: {e.Message}", e);
            }

            try {
                ok?.Create();
            }
            catch (Exception e) {

                throw new Exception($"Can't access ok directory {ok.FullName}: {e.Message}", e);
            }

            try {
                ko?.Create();
            }
            catch (Exception e) {

                throw new Exception($"Can't access ko directory {ko.FullName}: {e.Message}", e);
            }

            OK = ok != null ? new DirectoryInfoAdapter(ok) : null;
            KO = ko != null ? new DirectoryInfoAdapter(ko) : null;

            loadSources.Add(Work);

            foreach (var option in options) {

                try {
                    option.Invoke(this);
                }
                catch (Exception e) {

                    throw new ArgumentException($"Could not initialize \"{GetType().Name}\": {e.Message}", e);
                }
            }
        }

        /// <summary>
        /// Carica gli archivi dallo storage.
        /// </summary>
        /// <returns>Archivi caricati.</returns>
        public List<IArchiveInfo> Load() {

            var parallelCollection = new ConcurrentBag<IArchiveInfo>();

            try {
                Indexes.AsParallel().ForAll(indexFile => IO.ReadArchive(indexFile, parallelCollection));   // parallelizziamo la lettura degli archivi (indici, documenti e metadati)
            }
            catch (AggregateException ae) {

                ae.Handle(e => {

                    // ReadArchive garantisce che ogni eccezione sia una ArchiveReadException contestualizzata sull'archivio.
                    var are = e as ArchiveReadException;
                    Logger.logErrorToRegistry($"Could not load archive \"{are?.ArchivePath}\": {e.Message}");
                    return true;
                });
            }

            return parallelCollection.ToList(); // punto di convergenza della parallelizzazione
        }

        /// <summary>
        /// Memorizza sullo storage i dati ed i metadati creati a partire da essi in una collezione di archivi.
        /// </summary>
        /// <typeparam name="TMetadata">Tipo dei metadati.</typeparam>
        /// <param name="preserveDatas">Dati da memorizzare.</param>
        /// <param name="metadataFactory">Creatore di metadati.</param>
        /// <param name="profile">Nome profilo del tenant.</param>
        /// <returns>Archivi memorizzati.</returns>
        public List<IArchiveInfo> Store<TMetadata>(
            IEnumerable<IPreserveData> preserveDatas,
            Func<PreserveData, TMetadata> metadataFactory,
            string profile = null)
            where TMetadata : class {

            var parallelCollection = new ConcurrentBag<IArchiveInfo>();

            try {
                preserveDatas.AsParallel().ForAll(preserveData => IO.WriteArchive(profile, Work, preserveData, parallelCollection, metadataFactory));
            }
            catch (AggregateException ae) {

                ae.Handle(e => {

                    // WriteArchive garantisce che ogni eccezione sia una ArchiveWriteException contestualizzata sull'archivio.
                    var awe = e as ArchiveWriteException;
                    Logger.logErrorToRegistry($"Could not write archive \"{awe?.ArchivePath}\": {e.Message}");
                    return true;
                });
            }

            return parallelCollection.ToList(); // punto di convergenza della parallelizzazione
        }

        /// <summary>
        /// Memorizza sullo storage i dati ed i metadati in una collezione di archivi.
        /// </summary>
        /// <typeparam name="TMetadata">Tipo dei metadati.</typeparam>
        /// <param name="preserveDatasWithMetadatas">Dati con metadati da memorizzare.</param>
        /// <param name="profile">Nome profilo del tenant.</param>
        /// <returns>Archivi memorizzati.</returns>
        public List<IArchiveInfo> Store<TMetadata>(
            IEnumerable<KeyValuePair<IPreserveData, TMetadata>> preserveDatasWithMetadatas,
            string profile = null)
            where TMetadata : class {

            var parallelCollection = new ConcurrentBag<IArchiveInfo>();

            try {

                preserveDatasWithMetadatas.AsParallel()
                    .ForAll(preserveDatasWithMetadata => IO.WriteArchive(profile, Work, preserveDatasWithMetadata.Key, parallelCollection, preserveDatasWithMetadata.Value));
            }
            catch (AggregateException ae) {

                ae.Handle(e => {

                    // WriteArchive garantisce che ogni eccezione sia una ArchiveWriteException contestualizzata sull'archivio.
                    var awe = e as ArchiveWriteException;
                    Logger.logErrorToRegistry($"Could not write archive \"{awe?.ArchivePath}\": {e.Message}");
                    return true;
                });
            }

            return parallelCollection.ToList(); // punto di convergenza della parallelizzazione
        }

        /// <summary>
        /// Sposta un file sul container di memorizzazione per i file elaborati in base al risultato di un'elaborazione indicato
        /// e dell'estrattore dell'esito indicato.
        /// </summary>
        /// <typeparam name="TResult">Tipo di risultato dell'elaborazione.</typeparam>
        /// <param name="r">Risultato dell'elaborazione.</param>
        /// <param name="f">Riferimento al file da spostare.</param>
        /// <param name="successEvaluator">Valuta il successo dell'elaborazione a partire dal risultato.</param>
        public void Move<TResult>(IFileReference f, TResult r, Predicate<TResult> successEvaluator) {

            bool success = successEvaluator.Invoke(r);

            var destDir = success ? OK : KO;

            // gli archivi sono memorizzati nella forma <radice>/<opID>/<file> (vedi IO.WriteArchive): spostare un file
            // significa scambiare la sola radice (Work -> OK / KO) mantenendo la directory <opID>. Ricaviamo quest'ultima
            // direttamente dal container del file in modo da gestire correttamente anche i file caricati da OK / KO con
            // OptionLoadFrom, senza dover dedurre la sorgente di provenienza.
            var finalDir = new DirectoryInfoAdapter(new DirectoryInfo(Path.Combine(destDir.FullName, f.Container.Name)));

            if (!finalDir.Exists) {

                try {
                    finalDir.Create();
                }
                catch (Exception e) {

                    Logger.logErrorToRegistry($"Could not create \"{destDir.FullName}\": {e.Message}");
                    return;
                }
            }

            string finalPath = Path.Combine(finalDir.FullName, f.Name);

            if (string.Equals(Path.GetFullPath(finalPath), Path.GetFullPath(f.FullName), StringComparison.OrdinalIgnoreCase)) {   // il file è già nella destinazione corretta (es. caricato da OK ed inviato con successo): nessuno spostamento necessario
                return;
            }

            try {
                f.MoveTo(finalPath);
            }
            catch (Exception e) {

                Logger.logErrorToRegistry($"Could not move {f.FullName} to {finalPath}: {e.Message}");
                return;
            }
        }

        /// <summary>
        /// Imposta l'enumeratore per individuare i file indice.
        /// </summary>
        /// <param name="searchPattern">Pattern per l'individuazione dei file indice.</param>
        /// <param name="recursive">Indica se i file indice devono essere individuati ricorsivamente.</param>
        /// <returns>Action che modifica la configurazione dello storage.</returns>
        public static Action<FileSystem> OptionIndexesEnumerator(string searchPattern, bool recursive) {

            return storage => {

                storage.indexEnumeratorSearchPattern = searchPattern;
                storage.indexEnumeratorRecursive = recursive ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly;

            };
        }

        /// <summary>
        /// Imposta le directory da cui caricare i file indice.
        /// </summary>
        /// <param name="sources">Sorgenti da cui caricare i file indice.</param>
        /// <returns>Action che modifica la configurazione dello storage.</returns>
        public static Action<FileSystem> OptionLoadFrom(params LoadSource[] sources) {

            // potremmo in futuro usare l'enum per indicizzare ed accedere ad una lista/array di IFileReferenceContainer
            // e slegarci dalle dir definite sulla classe e disaccoppiare ancora di più i concetti ed i metodi ma per ora
            // usiamo uno switch sulla opzione che lo utilizza.

            return storage => {

                storage.loadSources.Clear();

                foreach (var s in sources.Distinct()) {

                    switch (s) {

                        case LoadSource.Work:
                            storage.loadSources.Add(storage.Work);
                            break;

                        case LoadSource.OK:
                            if (storage.OK != null)
                                storage.loadSources.Add(storage.OK);
                            break;

                        case LoadSource.KO:
                            if (storage.KO != null)
                                storage.loadSources.Add(storage.KO);
                            break;
                    }
                }
            };
        }
    }
}
