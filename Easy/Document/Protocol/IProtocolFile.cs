using System.IO;
using System.Security.Cryptography;

namespace Document.Protocol {
    /// <summary>
    /// Definisce un allegato da utilizzare nell'operazione di protocollazione.
    /// </summary>
    public interface IProtocolFile {
        /// <summary>
        /// Descrittore su filesystem del file.
        /// </summary>
        FileInfo FileDescriptor { get; }
        /// <summary>
        /// Contenuto del file.
        /// </summary>
        byte[] Contents { get; }
        /// <summary>
        /// Algoritmo di hash utilizzato per calcolare l'hash del contenuto.
        /// </summary>
        HashAlgorithm HashAlgorithm { get; }
        /// <summary>
        /// Hash del contenuto. Su DB abbiamo una descrizione incompleta di questo valore,
        /// non è descritto l'algoritmo utilizzato, è un varbinary e in generale assumiamo che l'algoritmo di hashing sia SHA-256.
        /// </summary>
        byte[] Hash { get; }
    }
}
