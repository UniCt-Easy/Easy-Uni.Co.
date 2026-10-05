using System.IO;
using System.Collections.Generic;

namespace preserve.Storage {

    /// <summary>
    /// Riferimento ad un container di riferimenti a file.
    /// </summary>
    public interface IFileReferenceContainer {

        /// <summary>
        /// Nome del riferimento al container di riferimenti a file.
        /// </summary>
        string Name { get; }
        /// <summary>
        /// Nome completo del riferimento al container di riferimenti a file.
        /// </summary>
        string FullName { get; }
        /// <summary>
        /// Indica se il riferimento al container esista.
        /// </summary>
        bool Exists { get; }

        /// <summary>
        /// Crea il riferimento al container di riferimenti a file.
        /// </summary>
        void Create();

        /// <summary>
        /// Individua sul container i riferimenti ai file in base ad un pattern di ricerca sul nome e ad opzioni di ricerca.
        /// </summary>
        /// <param name="searchPattern">Pattern wildcard per la ricerca sul nome del file.</param>
        /// <param name="searchOption">Opzioni di ricerca.</param>
        /// <returns>Riferimenti ai file individuati.</returns>
        IEnumerable<IFileReference> EnumerateFiles(string searchPattern, SearchOption searchOption);
    }
}
