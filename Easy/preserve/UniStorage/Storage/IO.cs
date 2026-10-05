using System;
using System.IO;
using System.Text;
using System.Xml.Serialization;
using System.Linq;
using System.Collections.Generic;
using System.Collections.Concurrent;

using ApiClient;    // Questa dipendenza è necessaria per ReadDocumentWithMetadata. Forse potremmo definirlo altrove, magari in una dipendenza comune.
                    // Per ora la lasciamo in ApiClient.

using preserve.Storage;
using preserve.Storage.Adapters;

using preserve.UniStorage.Serialization;
using preserve.UniStorage.Serialization.Metadata.Unimatica.Documento;
using preserve.UniStorage.Serialization.Metadata.AGID.DocumentoInformatico;

namespace preserve.UniStorage.Storage {

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
        /// <param name="tenantID">Nome del tenant.</param>
        /// <param name="root">Directory di destinazione.</param>
        /// <param name="pd">Dati.</param>
        /// <param name="archiveInfos">Collezione di archivi elaborati correttamente.</param>
        public static void WriteArchive(string tenantID, IFileReferenceContainer root, IPreserveData pd, ConcurrentBag<IArchiveInfo> archiveInfos) {

            // eccezioni bloccanti per l'archivio ma non per la collezione di archivi, le gestiamo sul chiamante
            var opID = Guid.NewGuid();

            DirectoryInfo dstDir = new DirectoryInfo(Path.Combine(root.FullName, opID.ToString()));
            try {
                dstDir.Create();
            }
            catch (Exception e) {
                throw new ArchiveWriteException($"Could not access destination directory \"{dstDir.FullName}\": {e.Message}", e);
            }
            
            FileInfo documentFile = new FileInfo(Path.Combine(dstDir.FullName, pd.IDSdiFileName));

            try {
                File.WriteAllBytes(documentFile.FullName, pd.Bytes);
            }
            catch (Exception e) {
                throw new ArchiveWriteException($"Could not write data for document \"{pd.IDSdiFileName}\" into \"{documentFile.FullName}\": {e.Message}", e);
            }

            DocumentoInformaticoType AGIDMetadata;
            try {
                AGIDMetadata = new DocumentoInformaticoType(pd);
            }
            catch (Exception e) {
                throw new ArchiveWriteException($"Could not construct \"{typeof(DocumentoInformaticoType).Name}\" metadata for document \"{pd.IDSdiFileName}\": {e.Message}", e);
            }
            
            FileInfo AGIDMetadataFile = new FileInfo(Path.Combine(dstDir.FullName, Path.ChangeExtension(documentFile.Name, $".metadata.{typeof(DocumentoInformaticoType).Name}")));

            byte[] serializedAGIDMetadata;

            try {
                serializedAGIDMetadata = WriteXML(AGIDMetadata, AGIDMetadataFile);
            }
            catch (Exception e) {
                throw new ArchiveWriteException($"Could not write \"{typeof(DocumentoInformaticoType).Name}\" metadata for document \"{pd.IDSdiFileName}\" into \"{AGIDMetadataFile.FullName}\": {e.Message}", e);
            }

            Documento UnimaticaMetadata = new Documento() {
                Intestazione = new Intestazione() {
                    IdFile = opID,
                    NomeFile = documentFile.Name,
                    Principale = true,
                },
                Profilo = new Serialization.Metadata.Unimatica.Documento.Profilo(Encoding.UTF8.GetString(serializedAGIDMetadata)),
            };
            FileInfo UnimaticaMetadataFile = new FileInfo(Path.Combine(dstDir.FullName, Path.ChangeExtension(opID.ToString(), "xml")));

            byte[] serializedUnimaticaMetadata;

            try {
                serializedUnimaticaMetadata = WriteXML(UnimaticaMetadata, UnimaticaMetadataFile);
            }
            catch (Exception e) {
                throw new ArchiveWriteException($"Could not write  \"{UnimaticaMetadata.GetType().Name}\" metadata for document \"{pd.IDSdiFileName}\" into \"{UnimaticaMetadataFile.FullName}\": {e.Message}", e);
            }

            var index = new UniStorageIndex() {
                profilo = new Serialization.Profilo() {
                    tenant = tenantID,
                    classeDocumentale = AGIDMetadata.TipologiaDocumentale,
                },
                documenti = new List<Documenti> { new Documenti(opID, pd.IDOffice, documentFile, pd.Bytes, UnimaticaMetadataFile, serializedUnimaticaMetadata) },
            };
            var indexFile = new FileInfoAdapter(new FileInfo(Path.Combine(dstDir.FullName, Path.ChangeExtension(opID.ToString(), ".index"))));

            try {
                index.Store(indexFile);
            }
            catch (Exception e) {
                throw new ArchiveWriteException($"Could not write \"{index.GetType().Name}\" index for document {pd.IDSdiFileName} into \"{indexFile.FullName}\": {e.Message}", e);
            }

            archiveInfos.Add(new UnimaticaArchiveInfo(index, indexFile));
        }

        /// <summary>
        /// Carica ed aggiunge ad una collezione di archivi i dati letti da un file di indice e dai file referenziati in esso.
        /// </summary>
        /// <param name="indexFile">File dell'indice dell'archivio serializzato.</param>
        /// <param name="archiveInfos">Collezione di archivi caricati.</param>
        public static void ReadArchive(IFileReference indexFile, ConcurrentBag<IArchiveInfo> archiveInfos) {

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
