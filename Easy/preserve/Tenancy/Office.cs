using System;

using sdiLog;

using preserve.Storage;
using eventLog;

namespace preserve.Tenancy {

    /// <summary>
    /// Ufficio di un tenant.
    /// </summary>
    public class Office {

        /// <summary>
        /// Identificativo.
        /// </summary>
        public string ID;

        /// <summary>
        /// Spazio di memorizzazione locale.
        /// </summary>
        public IStorage Storage { get; }

        /// <summary>
        /// Logger.
        /// </summary>
        public IPreserveLogger Logger => Storage.Logger;

        /// <summary>
        /// Inizializza un oggetto che rappresenta una sottoentità di una entità che effettua la conservazione
        /// con un identificativo, e uno spazio di memorizzazione locale.
        /// </summary>
        /// <param name="id">Identificativo del tenant.</param>
        /// <param name="s">Spazio di memorizzazione locale.</param>
        public Office(string id, IStorage s) {

            ID = !string.IsNullOrWhiteSpace(id) ? id : throw new ArgumentException("Invalid parameter", "id");

            Storage = s ?? throw new ArgumentException("Invalid parameter", "s");
        }
    }
}
