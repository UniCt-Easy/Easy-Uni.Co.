using Document.IPA;

using preserve.UniStorage.Logic;

namespace preserve.Metadata.AGID.DocumentoInformatico {
    public partial class RuoloType {

        private RuoloType() { }

        public RuoloType(TSoggetto ts, Soggetto s) {
            Item = Mappings.DocumentoInformaticoSoggettoTypeConstructors[ts].Invoke(s);
        }
    }
}
