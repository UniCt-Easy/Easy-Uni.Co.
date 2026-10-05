namespace preserve.Tenancy {

    /// <summary>
    /// Indice di un archivio relativo ad un ufficio di un tenant. Contiene gli identificativi del tenant necessari per la serializzazione e la memorizzazione
    /// dei dati.
    /// Questa interfaccia è il punto di contatto tra una logica che utilizza l'ufficio (IPA) come unità minima di tenancy (sdiftp) e una logica che raggruppa
    /// gli uffici appartenenti ad un tenant (UniStorage).
    /// Per maggiori dettagli consultare le classi che implementano l'interfaccia.
    /// </summary>
    public interface ITenantIndex { // In futuro si potrebbe pensare di utilizzare il boxing piuttosto che l'ereditarietà per implementare le classi derivate

        /// <summary>
        /// Identificativo del tenant.
        /// </summary>
        string TenantID { get; }

        /// <summary>
        /// Identificativo dell'ufficio.
        /// </summary>
        string OfficeID { get; }
    }
}
    