using System;
using System.Collections.Generic;
using eventLog;

namespace preserve.Storage {

    /// <summary>
    /// Spazio di memorizzazione di archivi. L'indice dell'archivio è accompagnato da una collezione di riferimenti a file allegati.<br/>
    /// Lo storage esprime un container di riferimenti a file da elaborare (Work), un container di riferimenti a file
    /// elaborati con successo (OK) e un container di riferimenti a file elaborati senza successo (KO).<br/>
    /// Inoltre lo storage è in grado di esprimere riferimenti ai file indice degli archivi memorizzati.<br/>
    /// Lo storage permette di memorizzare e recuperare degli archivi, e di spostare nei container previsti gli archivi in base
    /// al risultato di una elaborazione.
    /// </summary>
    public interface IStorage {

        /// <summary>
        /// Logger delle operazioni effettuate sullo storage.
        /// </summary>
        IPreserveLogger Logger { get; }

        /// <summary>
        /// Container dei file memorizzati.
        /// </summary>
        IFileReferenceContainer Work { get; }

        /// <summary>
        /// Container dei file elaborati correttamente.
        /// </summary>
        IFileReferenceContainer OK { get; }

        /// <summary>
        /// Container dei file elaborati con errori.
        /// </summary>
        IFileReferenceContainer KO { get; }

        /// <summary>
        /// File contenenti gli indici degli archivi.
        /// </summary>
        IEnumerable<IFileReference> Indexes { get; }

        /// <summary>
        /// Memorizza sullo storage i dati ed i metadati creati a partire da essi in una collezione di archivi.
        /// </summary>
        /// <typeparam name="TMetadata">Tipo dei metadati.</typeparam>
        /// <param name="data">Dati da memorizzare.</param>
        /// <param name="metadataFactory">Creatore di metadati.</param>
        /// <param name="profile">Nome profilo del tenant.</param>
        /// <returns>Archivi memorizzati.</returns>
        List<IArchiveInfo> Store<TMetadata>(IEnumerable<IPreserveData> data,
            Func<PreserveData, TMetadata> metadataFactory,
            string profile = null)
            where TMetadata : class;

        /// <summary>
        /// Memorizza sullo storage i dati ed i metadati in una collezione di archivi.
        /// </summary>
        /// <typeparam name="TMetadata">Tipo dei metadati.</typeparam>
        /// <param name="data">Dati da memorizzare associati ai rispettivi metadati.</param>
        /// <param name="profile">Nome profilo del tenant.</param>
        /// <returns>Archivi memorizzati.</returns>
        List<IArchiveInfo> Store<TMetadata>(IEnumerable<KeyValuePair<IPreserveData, TMetadata>> dataWithMetadata,
            string profile = null)
            where TMetadata : class;

        /// <summary>
        /// Carica gli archivi dallo storage.
        /// </summary>
        /// <returns>Archivi caricati.</returns>
        List<IArchiveInfo> Load();

        /// <summary>
        /// Sposta un file sul container di memorizzazione per i file elaborati in base al risultato di un'elaborazione indicato
        /// e dell'estrattore dell'esito indicato.
        /// </summary>
        /// <typeparam name="TResult">Tipo di risultato dell'elaborazione.</typeparam>
        /// <param name="r">Risultato dell'elaborazione.</param>
        /// <param name="f">Riferimento al file da spostare.</param>
        /// <param name="successEvaluator">Valuta il successo dell'elaborazione a partire dal risultato.</param>
        void Move<TResult>(IFileReference f, TResult r, Predicate<TResult> successEvaluator);
    }
}
