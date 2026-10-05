using Document.IPA;

using preserve.UniStorage.Logic;

namespace preserve.Metadata.AGID.DocumentoInformatico {

    partial class TipoSoggetto11Type {

        public TipoSoggetto11Type(Soggetto s) : this() {

            TPersona tp = string.IsNullOrWhiteSpace(s.denominazione) ? TPersona.Fisica : TPersona.Giuridica;

            Item = Mappings.PersonaTypeConstructorsMapper(tp).Invoke(s);
        }
    }

    partial class TipoSoggetto12Type {

        public TipoSoggetto12Type(Soggetto s) : this() {

            TPersona tp = string.IsNullOrWhiteSpace(s.denominazione) ? TPersona.Fisica : TPersona.Giuridica;

            Item = Mappings.PersonaTypeConstructorsMapper(tp).Invoke(s);
        }
    }

    partial class TipoSoggetto4Type {

        public TipoSoggetto4Type(string name) : this() {

            SW = new SWType() { DenominazioneSistema = name, };
        }
    }
}
