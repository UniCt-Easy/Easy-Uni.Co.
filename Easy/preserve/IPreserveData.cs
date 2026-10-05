using System;
using System.Xml;

using Document;

namespace preserve {

    /// <summary>
    /// Descrive un documento da mandare in conservazione.
    /// </summary>
    public interface IPreserveData {

        /// <summary>
        /// Dati da conservare.
        /// </summary>
        byte[] Contents { get; }
        /// <summary>
        /// Tipo di documento da conservare.
        /// </summary>
        TDocument Type { get; }
        /// <summary>
        /// Identificativo del documento da conservare.
        /// </summary>
        string ID { get; }
        /// <summary>
        /// Nome file su storage contenente i dati da conservare.
        /// </summary>
        string Filename { get; }
        /// <summary>
        /// Marcatore temporale per i dati da conservare
        /// </summary>
        DateTime Timestamp { get; }
        /// <summary>
        /// Identificativo dell'ufficio di riferimento per i dati da conservare.
        /// </summary>
        string IDOffice { get; }
        /// <summary>
        /// Proprietario dei dati da conservare.
        /// </summary>
        Soggetto Owner { get; }
        /// <summary>
        /// Firma dei dati da conservare.
        /// </summary>
        string Signature { get; }
    }

    /// <summary>
    /// Descrive un documento da mandare in conservazione. (Interfaccia legacy, usare IPreserveData)
    /// </summary>
    [Obsolete("Use IPreserveData instead")]
    public interface IPreserveDataLegacy : IPreserveData {
        [Obsolete("Use Contents instead")]
        byte[] Bytes { get; }

        XmlDocument Xml { get; }

        [Obsolete("Use Filename instead")]
        string IDSdiFileName { get; }

        [Obsolete("Use ID instead")]
        string IDSdi { get; }
    }

    /// <summary>
    /// Implementazione di IPreserveDataLegacy. (Usare IPreserveData dove possibile)
    /// </summary>
    public class PreserveData : IPreserveDataLegacy {

        // Campi moderni
        public virtual byte[] Contents { get; set; }
        public virtual TDocument Type { get; set; }
        public virtual string ID { get; set; }
        public virtual string Filename { get; set; }
        public virtual DateTime Timestamp { get; set; }
        public virtual Soggetto Owner { get; set; }
        public virtual string IDOffice { get; set; }
        public virtual string Signature { get; set; }

        // Campo legacy
        public virtual XmlDocument Xml { get; set; }

        // Campi legacy redirezionati
        [Obsolete("Use Contents instead")]
        byte[] IPreserveDataLegacy.Bytes => Contents;

        [Obsolete("Use Filename instead")]
        string IPreserveDataLegacy.IDSdiFileName => Filename;

        [Obsolete("Use ID instead")]
        string IPreserveDataLegacy.IDSdi => ID;

        /// <summary>
        /// Converte i dati da interfaccia a tipo concreto.
        /// </summary>
        /// <param name="ipd">Interfaccia.</param>
        public PreserveData(IPreserveData ipd) {

            Contents = ipd.Contents;
            Type = ipd.Type;
            ID = ipd.ID;
            Filename = ipd.Filename;
            Timestamp = ipd.Timestamp;
            Owner = ipd.Owner;
            IDOffice = ipd.IDOffice;
            Signature = ipd.Signature;
        }

        public PreserveData() { }
    }
}
