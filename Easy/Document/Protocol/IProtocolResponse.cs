namespace Document.Protocol {

    /// <summary>
    /// Risposta di un servizio di protocollazione.
    /// </summary>
    public interface IProtocolResponse {
        /// <summary>
        /// Numero di protocollo.
        /// </summary>
        string ProtocolNum { get; }
        /// <summary>
        /// Errore avvenuto durate l'operazione di protocollazione.
        /// </summary>
        string Error { get; }
    }
}
