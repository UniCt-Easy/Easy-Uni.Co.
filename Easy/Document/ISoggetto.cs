namespace Document.IPA {
    /// <summary>
    /// Soggetto identificato su IPA.
    /// </summary>
    public interface ISoggetto {
        string Cognome { get; }
        string Denominazione { get; }
        string CodiceFiscale { get; }
        string PartitaIVA { get; }
        string Nome { get; }
        string IPAAmm { get; }
        string IPAAOO { get; }
        string IPAUOR { get; }
        string[] IndirizziDigitali { get; }
    }
}
