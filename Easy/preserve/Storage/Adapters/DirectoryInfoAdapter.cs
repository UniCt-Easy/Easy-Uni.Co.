using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace preserve.Storage.Adapters {

    /// <summary>
    /// Adapter per il tipo builtin di riferimento ad un container di riferimenti a file su filesystem.
    /// </summary>
    public class DirectoryInfoAdapter : IFileReferenceContainer {

        /// <summary>
        /// Istanza di tipo builtin del riferimento ad un container di riferimenti a file.
        /// </summary>
        private readonly DirectoryInfo D;

        /// <summary>
        /// Nome del riferimento ad un container di riferimenti a file.
        /// </summary>
        public string Name => D.Name;
        /// <summary>
        /// Nome completo del riferimento ad un container di riferimenti a file.
        /// </summary>
        public string FullName => D.FullName;
        /// <summary>
        /// Indica se il riferimento al container esista.
        /// </summary>
        public bool Exists => D.Exists;

        /// <summary>
        /// Crea il riferimento al container di riferimenti a file.
        /// </summary>
        public void Create() => D.Create();

        /// <summary>
        /// Individua sul container i riferimenti ai file in base ad un pattern di ricerca sul nome e ad opzioni di ricerca.
        /// </summary>
        /// <param name="searchPattern">Pattern wildcard per la ricerca sul nome del file.</param>
        /// <param name="searchOption">Opzioni di ricerca.</param>
        /// <returns>Riferimenti ai file individuati.</returns>
        public IEnumerable<IFileReference> EnumerateFiles(string searchPattern, SearchOption searchOption) => D.EnumerateFiles(searchPattern, searchOption).Select(f => new FileInfoAdapter(f));

        /// <summary>
        /// Crea un'istanza dell'adapter per il riferimento ad un container di riferimenti a file da un'istanza di tipo builtin.
        /// </summary>
        /// <param name="d">Istanza del riferimento a file su filesystem.</param>
        public DirectoryInfoAdapter(DirectoryInfo d) {
            D = d ?? throw new ArgumentException("Invalid parameter", "d");
        }
    }
}
