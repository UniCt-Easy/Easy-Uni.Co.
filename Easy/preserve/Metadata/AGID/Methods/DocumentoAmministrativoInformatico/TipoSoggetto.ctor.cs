namespace preserve.Metadata.AGID.DocumentoAmministrativoInformatico {

    partial class TipoSoggetto1Type {

        public TipoSoggetto1Type(Soggetto s) : this() {

            PAI = new PAIType() {
                IPAAmm = new CodiceIPAType() {
                    CodiceIPA = s.IPAAmm,
                    Denominazione = s.denominazione,
                },
                IPAAOO = new CodiceIPAType() {
                    CodiceIPA = s.IPAAOO,
                    Denominazione = string.Join(".", s.denominazione, s.IPAAOO),
                },
                IPAUOR = new CodiceIPAType() {
                    CodiceIPA = s.IPAUOR,
                    Denominazione = string.Join(".", s.denominazione, s.IPAAOO, s.IPAUOR),
                },
                IndirizziDigitaliDiRiferimento = s.IndirizziDigitali,
            };
        }
    }

    partial class TipoSoggetto5Type {

        public TipoSoggetto5Type(string name) : this() {

            SW = new SWType() { DenominazioneSistema = name, };
        }
    }
}
