using System.Collections.Concurrent;

using ApiClient;

using preserve.Tenancy;

namespace preserve.Storage {

    /// <summary>
    /// Descrittore di un archivio di file.
    /// </summary>
    public interface IArchiveInfo {

        /// <summary>
        /// Indice serializzato dall'archivio.
        /// </summary>
        ITenantIndex ApiIndex { get; }

        /// <summary>
        /// Riferimento al file su storage che contiene l'indice dell'archivio serializzato.
        /// </summary>
        IFileReference ApiIndexFileReference { get; }

        /// <summary>
        /// Riferimenti ai file inclusi nell'archivio e loro contenuto.
        /// </summary>
        ConcurrentDictionary<IFileReference, Attachment> Attachments { get; }

        /// <summary>
        /// Proprietà espresse in formato human-readable, utile per i log.
        /// </summary>
        object StringReferences { get; }
    }
}
