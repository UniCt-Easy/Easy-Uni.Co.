using System.ComponentModel;

namespace Document.SDI {

    /// <summary>
    /// Direzione del documento, incoming (E) per entrata, outgoing (U) per uscita
    /// </summary>
    public enum Direction {
        /// <summary>
        /// Per i documenti in arrivo associamo (l'anagrafica del) CedentePrestatore.
        /// </summary>
        [Description("CedentePrestatore")]
        incoming = 'E',
        /// <summary>
        /// Per i documenti in uscita associamo (l'anagrafica del) CessionarioCommittente.
        /// </summary>
        [Description("CessionarioCommittente")]
        outgoing = 'U'
    }

    /// <summary>
    /// Estensioni per l'enum Direction
    /// </summary>
    public static class DirectionExtensions {
        /// <summary>
        /// Restituisce il decorator "Description" per l'enum.
        /// </summary>
        /// <param name="d">Valore dell'enumerazione.</param>
        /// <returns>Descrizione dell'enumerazione.</returns>
        public static string ToRole(this Direction d) {
            DescriptionAttribute[] attributes = (DescriptionAttribute[])d
               .GetType()
               .GetField(d.ToString())
               .GetCustomAttributes(typeof(DescriptionAttribute), false);
            return attributes.Length > 0 ? attributes[0].Description : string.Empty;
        }
    }

    public enum TMessage {
        NS,
        MC,
        RC,
        NE,
        AT,
        DT,
        MT,
        EC,
        SE,
    }

    public enum MessageType {

        //RC fatture di vendita - sdi all'ente per dire che è stata consegnata
        //NS fattura di vendita - sdi non l'accetta
        //MC fatture di vendita - sdi non è riuscito a mandarla --> AT
        //AT fatture di vendita - definitiva non consegna
        //EC fatture di acquisto - accettazione o rifiuto (generato da easy)
        //DT scadenza termini accettazione implicita
        //NE fatture di vendita - accettazione o rifiuto
        //MT fatture di acquisto - arriva solo al destinatario
        //SE fatture di acquisto - EC non valido (generato da sdi)
        //DT fatture di acquisto e vendita - arriva a prescindere diversamente da SE

        [Description("RicevutaConsegna")]
        RC,
        [Description("NotificaMancataConsegna")]
        MC,
        [Description("NotificaScarto")]
        NS,
        [Description("NotificaEsito")] // accettazione/rifiuto
        NE,
        [Description("MetadatiInvioFile")]
        MT,
        [Description("NotificaEsitoCommittente")] // accettazione/rifiuto
        EC,
        [Description("ScartoEsitoCommittente")]
        SE,
        [Description("NotificaDecorrenzaTermini")]
        DT,
        [Description("AttestazioneTrasmissioneFattura")]
        AT
    }
}
