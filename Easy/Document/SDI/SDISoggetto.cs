using Document.IPA;

namespace Document.SDI {
    /// <summary>
    /// Soggetto identificato su IPA e identificato dal Sistema di Interscambio.
    /// </summary>
    public class SDISoggetto : ISoggetto {
        public string Cognome { get; set; }
        public string Denominazione { get; set; }
        public string CodiceFiscale { get; set; }
        public string PartitaIVA { get; set; }
        public string Nome { get; set; }
        public string IPAAmm { get; set; }
        public string IPAAOO { get; set; }
        public string IPAUOR { get; set; }
        public string[] IndirizziDigitali { get; set; } = new string[] { };
    }
}
