using Document.IPA;

using preserve.UniStorage.Logic;

namespace preserve.Metadata.AGID.DocumentoAmministrativoInformatico {
    public partial class RuoloType {

        private RuoloType() { }

        public RuoloType(TSoggetto ts, Soggetto s) {
            Item = Mappings.RegistroGiornalieroProtocolloSoggettoTypeConstructors[ts].Invoke(s);
        }
    }
}
