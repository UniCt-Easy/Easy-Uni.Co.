using Document.IPA;

namespace Document.Protocol {
    /// <summary>
    /// Soggetto da utilizzare per la protocollazione.
    /// </summary>
    public class ProtocolSoggetto : ISoggetto {
        public string Cognome { get; set; }
        public string Denominazione { get; set; }
        public string CodiceFiscale { get; set; }
        public string PartitaIVA { get; set; }
        public string Nome { get; set; }
        public string IPAAmm { get; set; }
        public string IPAAOO { get; set; }
        public string IPAUOR { get; set; }
        public string[] IndirizziDigitali { get; set; }
    }
}
