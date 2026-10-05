using System;

namespace preserve.Storage {

    /// <summary>
    /// Sollevata in caso di errore durante la scrittura su archivio.
    /// </summary>
    public class ArchiveWriteException : Exception {

        /// <summary>
        /// Path della directory dell'archivio che ha generato l'errore.
        /// </summary>
        public string ArchivePath { get; internal set; }

        public ArchiveWriteException(string message, Exception e, string archivePath = null) : base(message, e) {
            ArchivePath = archivePath;
        }
    }

    /// <summary>
    /// Sollevata in caso di errore durante la lettura da archivio.
    /// </summary>
    public class ArchiveReadException : Exception {

        /// <summary>
        /// Path del file indice dell'archivio che ha generato l'errore.
        /// </summary>
        public string ArchivePath { get; internal set; }

        public ArchiveReadException(string message, Exception e, string archivePath = null) : base(message, e) {
            ArchivePath = archivePath;
        }
    }
}
