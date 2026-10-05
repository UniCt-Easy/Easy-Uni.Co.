using System;
using System.IO;
using System.Security.Cryptography;

using Document.Protocol;

namespace Document.Segreterie {
    /// <summary>
    /// Definisce un allegato da utilizzare nell'operazione di protocollazione.
    /// per i documenti SDI.
    /// </summary>
    public class SDIProtocolFile : IProtocolFile {
        /// <summary>
        /// Descrittore su filesystem del file.
        /// </summary>
        public FileInfo FileDescriptor { get; }
        /// <summary>
        /// Contenuto del file.
        /// </summary>
        public byte[] Contents { get; }
        /// <summary>
        /// Algoritmo di hash utilizzato per calcolare l'hash del contenuto.
        /// </summary>
        public HashAlgorithm HashAlgorithm { get; }
        /// <summary>
        /// Hash del contenuto. Su DB abbiamo una descrizione incompleta di questo valore,
        /// non è descritto l'algoritmo utilizzato, è un varbinary e in generale assumiamo che l'algoritmo di hashing sia SHA-256.
        /// </summary>
        public byte[] Hash => HashAlgorithm.ComputeHash(Contents);

        /// <summary>
        /// Costruisce la definizione per un allegato da utilizzare nell'operazione di protocollazione
        /// </summary>
        /// <param name="fileName">Nome del file.</param>
        /// <param name="contents">Contenuto.</param>
        /// <param name="ha">Algoritmo di hashing da utilizzare.</param>
        public SDIProtocolFile(string fileName, byte[] contents, HashAlgorithm ha = null) {

            FileDescriptor = !string.IsNullOrWhiteSpace(fileName) ? new FileInfo(fileName) : throw new Exception("Name of file must be provided.");

            Contents = contents;

            HashAlgorithm = ha ?? SHA256.Create(); // default SHA256
        }
    }
}
