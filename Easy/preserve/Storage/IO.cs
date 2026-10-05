using System;
using System.IO;
using System.Text;
using System.Xml.Serialization;
using System.Linq;
using System.Collections.Generic;
using System.Collections.Concurrent;

using ApiClient;    // Questa dipendenza è necessaria per ReadDocumentWithMetadata. Forse potremmo definirlo altrove, magari in una dipendenza comune.
                    // Per ora la lasciamo in ApiClient.

using preserve.Storage.Adapters;

// queste dipendenze dovremmo astrarle da UniStorage in futuro
using preserve.UniStorage.Storage;
using preserve.UniStorage.Serialization;
using preserve.UniStorage.Serialization.Metadata.Unimatica.Documento;

namespace preserve.Storage {

    /// <summary>
    /// Contiene i metodi per la memorizzazione/caricamento dei dati su/da filesystem.
    /// </summary>
    public static class IO {

        // Questa classe si potrebbe rendere generica eliminando la creazione dei literal sugli oggetti di tipo
        // Documento (metodo WriteArchive - UnimaticaMetadata - manca costruttore), DocumentoInformaticoType (metodo WriteArchive - AGIDMetadata) e Index (metodo WriteArchive - index).
        // Questo permetterebbe di farla emergere sull'interfaccia (IStorage).

        /// <summary>
        /// Crea un path relativo da un path radice ed un path figlio.
        /// </summary>
        /// <param name="relativeTo">Radice del path relativo.</param>
        /// <param name="path">Path figlio.</param>
        /// <returns>Il path relativo alla radice o <c>path</c> se i path non sono correlati.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="UriFormatException"></exception>
        /// <exception cref="InvalidOperationException"></exception>
        public static string GetRelativePath(string relativeTo, string path) {

            if (string.IsNullOrEmpty(relativeTo)) throw new ArgumentNullException("relativeTo");
            if (string.IsNullOrEmpty(path)) throw new ArgumentNullException("path");

            var dirPath = !relativeTo.EndsWith(Path.DirectorySeparatorChar.ToString()) ? relativeTo + Path.DirectorySeparatorChar : relativeTo;

            Uri fromUri = new Uri(dirPath);
            Uri toUri = new Uri(path);

            if (fromUri.Scheme != toUri.Scheme) {
                return path;
            }

            Uri relativeUri = fromUri.MakeRelativeUri(toUri);
            string relativePath = Uri.UnescapeDataString(relativeUri.ToString());

            if (toUri.Scheme.Equals("file", StringComparison.InvariantCultureIgnoreCase)) {
                relativePath = relativePath.Replace(Path.AltDirectorySeparatorChar, Path.DirectorySeparatorChar);
            }

            return relativePath;
        }

        /// <summary>
        /// Serializza in XML e scrive su un file un oggetto di tipo T.
        /// </summary>
        /// <typeparam name="T">Tipo dell'oggetto da serializzare in XML.</typeparam>
        /// <param name="xmlObject">Oggetto da serializzare e scrivere su file.</param>
        /// <param name="f">File su cui scrivere l'oggetto serializzato.</param>
        /// <returns>Output scritto su file.</returns>
        public static byte[] WriteXML<T>(T xmlObject, FileInfo f) {

            byte[] serializedContents;
            string xmlString;

            try {
                MemoryStream metadataMemoryStream = new MemoryStream();
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                serializer.Serialize(metadataMemoryStream, xmlObject);
                xmlString = Encoding.UTF8.GetString(metadataMemoryStream.ToArray());
                serializedContents = metadataMemoryStream.ToArray();
            }
            catch (Exception e) {
                throw new Exception($"Could not serialize {f.FullName}: {e.Message}", e); ;
            }

            try {
                File.WriteAllText(f.FullName, xmlString);
            }
            catch (Exception e) {
                throw new Exception($"Could not write \"{f.FullName}\": {e.Message}", e);
            }

            return serializedContents;
        }

        /// <summary>
        /// Scrive su file il documento, i metadati e l'indice, e prepara una collezione di archivi.
        /// Il file sarà scritto in una directory figlia della directory di destinazione.
        /// </summary>
        /// <typeparam name="TMetadata">Tipo di metadati da creare.</typeparam>
        /// <param name="tenantID">Nome del tenant.</param>
        /// <param name="root">Directory di destinazione.</param>
        /// <param name="pd">Dati.</param>
        /// <param name="archiveInfos">Collezione di archivi elaborati correttamente.</param>
        /// <param name="metadataFactory">Creatore di metadati.</param>
        public static void WriteArchive<TMetadata>(
        string tenantID,
        IFileReferenceContainer root,
        IPreserveData pd,
        ConcurrentBag<IArchiveInfo> archiveInfos,
        Func<PreserveData, TMetadata> metadataFactory) where TMetadata : class {

            var opID = Guid.NewGuid();

            DirectoryInfo dstDir = new DirectoryInfo(Path.Combine(root.FullName, opID.ToString()));

            try {

                try {
                    dstDir.Create();
                }
                catch (Exception e) {
                    throw new ArchiveWriteException($"Could not access destination directory \"{dstDir.FullName}\": {e.Message}", e);
                }

                FileInfo documentFile = new FileInfo(Path.Combine(dstDir.FullName, pd.Filename));
                try {
                    File.WriteAllBytes(documentFile.FullName, pd.Contents);
                }
                catch (Exception e) {
                    throw new ArchiveWriteException($"Could not write data for document \"{pd.Filename}\" into \"{documentFile.FullName}\": {e.Message}", e);
                }

                // Construct metadata using factory
                TMetadata metadata;
                try {
                    metadata = metadataFactory(new PreserveData(pd));
                }
                catch (Exception e) {
                    throw new ArchiveWriteException($"Could not construct \"{typeof(TMetadata).Name}\" metadata for document \"{pd.Filename}\": {e.Message}", e);
                }

                FileInfo metadataFile = new FileInfo(
                    Path.Combine(dstDir.FullName,
                    Path.ChangeExtension(documentFile.Name, $".metadata.{typeof(TMetadata).Name}")));

                byte[] serializedMetadata;
                try {
                    serializedMetadata = WriteXML(metadata, metadataFile);
                }
                catch (Exception e) {
                    throw new ArchiveWriteException($"Could not write \"{typeof(TMetadata).Name}\" metadata for document \"{pd.Filename}\" into \"{metadataFile.FullName}\": {e.Message}", e);
                }

                // Build Unimatica metadata
                Documento unimaticaMetadata = new Documento() {
                    Intestazione = new Intestazione() {
                        IdFile = opID,
                        NomeFile = documentFile.Name,
                        Principale = true,
                    },
                    Profilo = new UniStorage.Serialization.Metadata.Unimatica.Documento.Profilo(
                        Encoding.UTF8.GetString(serializedMetadata)),
                };

                FileInfo unimaticaMetadataFile = new FileInfo(
                    Path.Combine(dstDir.FullName, Path.ChangeExtension(opID.ToString(), "xml")));

                byte[] serializedUnimaticaMetadata;
                try {
                    serializedUnimaticaMetadata = WriteXML(unimaticaMetadata, unimaticaMetadataFile);
                }
                catch (Exception e) {
                    throw new ArchiveWriteException($"Could not write \"{unimaticaMetadata.GetType().Name}\" metadata for document \"{pd.Filename}\" into \"{unimaticaMetadataFile.FullName}\": {e.Message}", e);
                }

                // Build index
                var index = new UniStorageIndex() {
                    profilo = new UniStorage.Serialization.Profilo() {
                        tenant = tenantID,
                        // Use reflection or interface to extract TipologiaDocumentale
                        classeDocumentale = (string)typeof(TMetadata)
                            .GetProperty("TipologiaDocumentale")?
                            .GetValue(metadata),
                    },
                    documenti = new List<Documenti>
                    {
                        new Documenti(opID, pd.IDOffice, documentFile, pd.Contents, unimaticaMetadataFile, serializedUnimaticaMetadata)
                    },
                };

                var indexFile = new FileInfoAdapter(
                    new FileInfo(Path.Combine(dstDir.FullName, Path.ChangeExtension(opID.ToString(), ".index"))));

                try {
                    index.Store(indexFile);
                }
                catch (Exception e) {
                    throw new ArchiveWriteException($"Could not write \"{index.GetType().Name}\" index for document {pd.Filename} into \"{indexFile.FullName}\": {e.Message}", e);
                }

                archiveInfos.Add(new UnimaticaArchiveInfo(index, indexFile));
            }
            catch (ArchiveWriteException awe) {

                if (awe.ArchivePath == null) awe.ArchivePath = dstDir.FullName;   // contestualizziamo sull'archivio se non già fatto
                throw;
            }
            catch (Exception e) {

                // qualsiasi altro errore non previsto (es. lanciato fuori dai blocchi sopra) viene comunque
                // associato all'archivio in elaborazione, così da non perdere mai l'identità della directory.
                throw new ArchiveWriteException($"Unexpected error while writing archive \"{dstDir.FullName}\": {e.Message}", e, dstDir.FullName);
            }
        }

        /// <summary>
        /// Scrive su file il documento, i metadati e l'indice, e prepara una collezione di archivi.
        /// Il file sarà scritto in una directory figlia della directory di destinazione.
        /// </summary>
        /// <typeparam name="TMetadata">Tipo di metadati forniti.</typeparam>
        /// <param name="tenantID">Nome del tenant.</param>
        /// <param name="root">Directory di destinazione.</param>
        /// <param name="pd">Dati.</param>
        /// <param name="archiveInfos">Collezione di archivi elaborati correttamente.</param>
        /// <param name="metadata">Metadati.</param>
        public static void WriteArchive<TMetadata>(
        string tenantID,
        IFileReferenceContainer root,
        IPreserveData pd,
        ConcurrentBag<IArchiveInfo> archiveInfos,
        TMetadata metadata) where TMetadata : class {

            var opID = Guid.NewGuid();

            DirectoryInfo dstDir = new DirectoryInfo(Path.Combine(root.FullName, opID.ToString()));

            try {

                try {
                    dstDir.Create();
                }
                catch (Exception e) {
                    throw new ArchiveWriteException($"Could not access destination directory \"{dstDir.FullName}\": {e.Message}", e);
                }

                FileInfo documentFile = new FileInfo(Path.Combine(dstDir.FullName, pd.Filename));
                try {
                    File.WriteAllBytes(documentFile.FullName, pd.Contents);
                }
                catch (Exception e) {
                    throw new ArchiveWriteException($"Could not write data for document \"{pd.Filename}\" into \"{documentFile.FullName}\": {e.Message}", e);
                }

                FileInfo metadataFile = new FileInfo(
                    Path.Combine(dstDir.FullName,
                    Path.ChangeExtension(documentFile.Name, $".metadata.{typeof(TMetadata).Name}")));

                byte[] serializedMetadata;
                try {
                    serializedMetadata = WriteXML(metadata, metadataFile);
                }
                catch (Exception e) {
                    throw new ArchiveWriteException($"Could not write \"{typeof(TMetadata).Name}\" metadata for document \"{pd.Filename}\" into \"{metadataFile.FullName}\": {e.Message}", e);
                }

                // Build Unimatica metadata
                Documento unimaticaMetadata = new Documento() {
                    Intestazione = new Intestazione() {
                        IdFile = opID,
                        NomeFile = documentFile.Name,
                        Principale = true,
                    },
                    Profilo = new UniStorage.Serialization.Metadata.Unimatica.Documento.Profilo(
                        Encoding.UTF8.GetString(serializedMetadata)),
                };

                FileInfo unimaticaMetadataFile = new FileInfo(
                    Path.Combine(dstDir.FullName, Path.ChangeExtension(opID.ToString(), "xml")));

                byte[] serializedUnimaticaMetadata;
                try {
                    serializedUnimaticaMetadata = WriteXML(unimaticaMetadata, unimaticaMetadataFile);
                }
                catch (Exception e) {
                    throw new ArchiveWriteException($"Could not write \"{unimaticaMetadata.GetType().Name}\" metadata for document \"{pd.Filename}\" into \"{unimaticaMetadataFile.FullName}\": {e.Message}", e);
                }

                // Build index
                var index = new UniStorageIndex() {
                    profilo = new UniStorage.Serialization.Profilo() {
                        tenant = tenantID,
                        // Use reflection or interface to extract TipologiaDocumentale
                        classeDocumentale = (string)typeof(TMetadata)
                            .GetProperty("TipologiaDocumentale")?
                            .GetValue(metadata),
                    },
                    documenti = new List<Documenti>
                    {
                        new Documenti(opID, pd.IDOffice, documentFile, pd.Contents, unimaticaMetadataFile, serializedUnimaticaMetadata)
                    },
                };

                var indexFile = new FileInfoAdapter(
                    new FileInfo(Path.Combine(dstDir.FullName, Path.ChangeExtension(opID.ToString(), ".index"))));

                try {
                    index.Store(indexFile);
                }
                catch (Exception e) {
                    throw new ArchiveWriteException($"Could not write \"{index.GetType().Name}\" index for document {pd.Filename} into \"{indexFile.FullName}\": {e.Message}", e);
                }

                archiveInfos.Add(new UnimaticaArchiveInfo(index, indexFile));
            }
            catch (ArchiveWriteException awe) {

                if (awe.ArchivePath == null) awe.ArchivePath = dstDir.FullName;   // contestualizziamo sull'archivio se non già fatto
                throw;
            }
            catch (Exception e) {

                // qualsiasi altro errore non previsto (es. lanciato fuori dai blocchi sopra) viene comunque
                // associato all'archivio in elaborazione, così da non perdere mai l'identità della directory.
                throw new ArchiveWriteException($"Unexpected error while writing archive \"{dstDir.FullName}\": {e.Message}", e, dstDir.FullName);
            }
        }

        /// <summary>
        /// Carica ed aggiunge ad una collezione di archivi i dati letti da un file di indice e dai file referenziati in esso.
        /// </summary>
        /// <param name="indexFile">File dell'indice dell'archivio serializzato.</param>
        /// <param name="archiveInfos">Collezione di archivi caricati.</param>
        public static void ReadArchive(IFileReference indexFile, ConcurrentBag<IArchiveInfo> archiveInfos) {

            try {

                UnimaticaArchiveInfo a;

                try {
                    a = new UnimaticaArchiveInfo(UniStorageIndex.Load(indexFile), indexFile);
                }
                catch (Exception e) {

                    throw new ArchiveReadException($"Could not read index from \"{indexFile.FullName}\", archive not loaded: {e.Message}", e);
                }

                try {
                    (a.ApiIndex as UniStorageIndex).documenti.AsParallel().ForAll(document => ReadDocumentWithMetadata(indexFile.Container, document, a.Attachments));  // parallelizziamo la lettura del documento e dei metadati
                }
                catch (Exception e) {

                    throw new ArchiveReadException($"Could not map data for \"{indexFile.FullName}\": { e.Message }", e);
                }

                archiveInfos.Add(a);
            }
            catch (ArchiveReadException are) {

                if (are.ArchivePath == null) are.ArchivePath = indexFile.FullName;   // contestualizziamo sull'archivio se non già fatto
                throw;
            }
            catch (Exception e) {

                // qualsiasi altro errore non previsto (es. lanciato fuori dai blocchi sopra) viene comunque
                // associato all'archivio in elaborazione, così da non perdere mai l'identità del file indice.
                throw new ArchiveReadException($"Unexpected error while loading archive \"{indexFile.FullName}\": {e.Message}", e, indexFile.FullName);
            }
        }

        /// <summary>
        /// Carica da una directory ed aggiunge ad una collezione di archivi i dati contenuti in un documento e i relativi metadati.
        /// </summary>
        /// <param name="container">Directory in cui sono memorizzati i file ed i metadati relativi.</param>
        /// <param name="d">Descrittore del documento.</param>
        /// <param name="attachments">Collezione di riferimenti ai file.</param>
        private static void ReadDocumentWithMetadata(IFileReferenceContainer container, Documenti d, ConcurrentDictionary<IFileReference, Attachment> attachments) {

            var documentFile = new FileInfoAdapter(new FileInfo(Path.Combine(container.FullName, d.nomeFile)));
            var metadataFile = new FileInfoAdapter(new FileInfo(Path.Combine(container.FullName, d.metadati.nomeFile)));

            if (!documentFile.Exists) {
                throw new Exception($"Could not find \"{documentFile.FullName}\".");
            }

            if (!metadataFile.Exists) {
                throw new Exception($"Could not find \"{metadataFile.FullName}\".");
            }

            try {
                attachments[documentFile] = new Attachment() {
                    parameterName = "documenti",
                    contents = File.ReadAllBytes(documentFile.FullName),
                    filename = documentFile.Name,
                };
            }
            catch (Exception e) {
                throw new Exception($"Could not load contents from file \"{documentFile.FullName}\": {e.Message}");
            }

            try {
                attachments[metadataFile] = new Attachment() {
                    parameterName = "metadati",
                    contents = File.ReadAllBytes(metadataFile.FullName),
                    filename = metadataFile.Name,
                };
            }
            catch (Exception e) {
                throw new Exception($"Could not load contents from metadata \"{metadataFile.FullName}\": {e.Message}");
            }
        }
    }
}
