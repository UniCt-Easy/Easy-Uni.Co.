using System.Collections.Generic;

using Document.SDI;

namespace Document {
    /// <summary>
    /// Descrizioni human-readable dei tipi.
    /// </summary>
    public static class HumanReadable {

        /// <summary>
        /// Associa al tipo di sorgente di documenti la sua descrizione.
        /// </summary>
        public static readonly Dictionary<TDocumentsSource, string> TDocumentsSources = new Dictionary<TDocumentsSource, string>() {
            { TDocumentsSource.Itineration,             "Missione" },
            { TDocumentsSource.Payment,                 "Mandato di Pagamento" },
            { TDocumentsSource.Proceeds,                "Reversale di Incasso" },
        };

        /// <summary>
        /// Associa al tipo di documento la sua descrizione.
        /// </summary>
        public static readonly Dictionary<TDocument, string> TDocuments = new Dictionary<TDocument, string>() {
            { TDocument.documentoInformatico,           "Documento" },
            { TDocument.ordVen,                         "Ordine di vendita" },
            { TDocument.fattAcq,                        "Fattura di acquisto" },
            { TDocument.fattVen,                        "Fattura di vendita" },
            { TDocument.fattAcquEstere,                 "Fattura di acquisto estera" },
            { TDocument.messOrdVen,                     "Messaggio Ordine di vendita" },
            { TDocument.messAcq,                        "Messaggio Fattura di acquisto" },
            { TDocument.messVen,                        "Messaggio Fattura di vendita" },
            { TDocument.messAcquEstere,                 "Messaggio Fattura di acquisto estera" },
            { TDocument.registroProtocollo,             "Registro di protocollo" },
            { TDocument.Mandato,                        "Documento Mandato" },
            { TDocument.Mandato_Stampa,                 "Stampa Mandato" },
            { TDocument.DURC_Anagr,                     "DURC" },
            { TDocument.DURC_Autocertificazione_Anagr,  "DURC Autocertificazione" },
            { TDocument.Cedolino_Stampa,                "Stampa Cedolino" },
            { TDocument.CCdedicato_Anagr,               "Dichiarazione CC dedicato" },
            { TDocument.CCdedicato_CF_Anagr,            "Documento identita CC dedicato" },
            { TDocument.Contratto,                      "Contratto"},
            { TDocument.Contratto_Occas,                "Documento Contratto Occasionale" },
            { TDocument.Contratto_Profes,               "Documento Contratto Professionale" },
            { TDocument.Contratto_Parasub,              "Documento Contratto Parasubordinato" },
            { TDocument.Altri_Compensi,                 "Documento Altri Compensi" },
            { TDocument.Reversale,                      "Documento Reversale" },
            { TDocument.Reversale_Stampa,               "Stampa Reversale" },
            { TDocument.Missione,                       "Documento Missione" },
            { TDocument.Missione_Stampa_Prospetto,      "Stampa prospetto calcolo Missione" },
            { TDocument.Missione_Stampa_Modulo,         "Stampa modulo Missione" },
            { TDocument.Missione_Spesa,                 "Documento spesa Missione" },
        };

        /// <summary>
        /// Associa al tipo di messaggio la sua descrizione.
        /// </summary>
        public static readonly Dictionary<TMessage, string> TMessages = new Dictionary<TMessage, string>() {
            { TMessage.NS, "Notifica di scarto" },
            { TMessage.MC, "Notifica di mancata consegna" },
            { TMessage.RC, "Ricevuta di consegna" },
            { TMessage.NE, "Notifica di esito" },
            { TMessage.AT, "Attestazione impossibilità di recapito" },
            { TMessage.DT, "Notifica di decorrenza dei termini" },
            { TMessage.MT, "Notifica di mancata trasmissione" },
            { TMessage.EC, "Notifica di esito cedente" },
            { TMessage.SE, "Notifica di scarto esito committente" },
        };
    }

}
