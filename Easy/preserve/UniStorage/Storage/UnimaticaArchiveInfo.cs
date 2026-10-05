using System.Linq;
using System.Collections.Concurrent;

using ApiClient;

using preserve.Storage;
using preserve.Tenancy;

namespace preserve.UniStorage.Storage {

    /// <summary>
    /// Archivio memorizzato su storage.
    /// </summary>
    public class UnimaticaArchiveInfo : IArchiveInfo {

        /// <summary>
        /// Indice dall'archivio nel formato di UniStorage.
        /// </summary>
        public ITenantIndex ApiIndex { get; }

        /// <summary>
        /// Riferimento al file su storage che contiene l'indice dell'archivio serializzato.
        /// </summary>
        public IFileReference ApiIndexFileReference { get; }

        /// <summary>
        /// Riferimenti ai file inclusi nell'archivio e loro contenuto.
        /// </summary>
        public ConcurrentDictionary<IFileReference, Attachment> Attachments { get; }

        /// <summary>
        /// Inizializza un archivio vuoto con indice i e riferimento al file indice f.
        /// </summary>
        /// <param name="i"></param>
        /// <param name="f"></param>
        public UnimaticaArchiveInfo(ITenantIndex i, IFileReference f) {

            ApiIndex = i;
            ApiIndexFileReference = f;

            Attachments = new ConcurrentDictionary<IFileReference, Attachment>();
        }

        /// <summary>
        /// Proprietà espresse in formato human-readable, utile per i log.
        /// </summary>
        public object StringReferences => new {

            ApiIndex.TenantID,
            Index = ApiIndexFileReference.FullName,

            Files = Attachments.Keys.Select(f => f.FullName),
        };
    }
}
