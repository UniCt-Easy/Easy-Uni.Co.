namespace preserve.UniStorage.Logic {

    /// <summary>
    /// Tipo di servizio di conservazione.
    /// </summary>
    public enum TService {
        Single,
        Multi
    }

    /// <summary>
    /// Tipo di verifica del documento (firma).
    /// </summary>
    public enum TVerifica {
        Firmato,
        NonFirmato,
        RegistroProtocollo,
    }
}
