namespace Document {

    // teoricamente alcuni tipi di documento si potrebbero sfoltire e decomporre
    // data l'esistenza del tipo documento e della direzione del documento.
    // Lasciamo le tipologie presenti per compatibilità.

    /// <summary>
    /// Tipi di sorgenti di documenti.
    /// </summary>
    public enum TDocumentsSource {
        /// <summary>
        /// Pagamento.
        /// </summary>
        Payment,
        /// <summary>
        /// Incasso.
        /// </summary>
        Proceeds,
        /// <summary>
        /// Missione.
        /// </summary>
        Itineration
    }

    /// <summary>
    /// Tipo di documento.
    /// </summary>
    public enum TDocument {
        /// <summary>
        /// Documento generico.
        /// </summary>
        documentoInformatico,

        /// <summary>
        /// Ordine di vendita.
        /// </summary>
        ordVen,
        /// <summary>
        /// Fattura di acquisto.
        /// </summary>
        fattAcq,
        /// <summary>
        /// Fattura di vendita.
        /// </summary>
        fattVen,
        /// <summary>
        /// Fattura di acquisto estera.
        /// </summary>
        fattAcquEstere,
        /// <summary>
        /// Messaggio relativo a ordine di vendita.
        /// </summary>
        messOrdVen,
        /// <summary>
        /// Messaggio relativo a fattura di acquisto.
        /// </summary>
        messAcq,
        /// <summary>
        /// Messaggio relativo a fattura di vendita.
        /// </summary>
        messVen,
        /// <summary>
        /// Messaggio relativo a fattura di acquisto estera.
        /// </summary>
        messAcquEstere,

        /// <summary>
        /// Registro di protocollo.
        /// </summary>
        registroProtocollo,

        /// <summary>
        /// Documento per mandato.
        /// </summary>
        Mandato,
        /// <summary>
        /// Stampa per mandato.
        /// </summary>
        Mandato_Stampa,
        /// <summary>
        /// DURC.
        /// </summary>
        DURC_Anagr,
        /// <summary>
        /// Autocertificazione DURC.
        /// </summary>
        DURC_Autocertificazione_Anagr,
        /// <summary>
        /// Stampa per cedolino.
        /// </summary>
        Cedolino_Stampa,
        /// <summary>
        /// Dichiarazione C.C. dedicato.
        /// </summary>
        CCdedicato_Anagr,
        /// <summary>
        /// Documento di identità C.C. dedicato.
        /// </summary>
        CCdedicato_CF_Anagr,
        /// <summary>
        /// Documento per contratto.
        /// </summary>
        Contratto,
        /// <summary>
        /// Documento per contratto occasionale.
        /// </summary>
        Contratto_Occas,
        /// <summary>
        /// Documento per contratto professionale.
        /// </summary>
        Contratto_Profes,
        /// <summary>
        /// Documento per contratto parasubordinato.
        /// </summary>
        Contratto_Parasub,
        /// <summary>
        /// Documento per altri compensi.
        /// </summary>
        Altri_Compensi,

        /// <summary>
        /// Documento per reversale.
        /// </summary>
        Reversale,
        /// <summary>
        /// Stampa per reversale.
        /// </summary>
        Reversale_Stampa,

        /// <summary>
        /// Documento per missione.
        /// </summary>
        Missione,
        /// <summary>
        /// Stampa prospetto di calcolo per missione.
        /// </summary>
        Missione_Stampa_Prospetto,
        /// <summary>
        /// Stampa modulo per missione.
        /// </summary>
        Missione_Stampa_Modulo,
        /// <summary>
        /// Documento di spesa per missione.
        /// </summary>
        Missione_Spesa,
    }

    /// <summary>
    /// Tipo di direzione.
    /// </summary>
    public enum TDirection {
        /// <summary>
        /// Entrata.
        /// </summary>
        Entrata = 1,
        /// <summary>
        /// Uscita.
        /// </summary>
        Uscita = 2,
        /// <summary>
        /// Interno.
        /// </summary>
        Interno = 3,
    }
}
