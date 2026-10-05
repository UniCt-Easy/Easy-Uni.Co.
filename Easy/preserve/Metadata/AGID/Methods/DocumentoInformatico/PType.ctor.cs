namespace preserve.Metadata.AGID.DocumentoInformatico {
    partial class PFType {

        private PFType() { }

        public PFType(Soggetto s) {
            CodiceFiscale = s.codicefiscale;
            Cognome = s.cognome;
            Nome = s.nome;
        }
    }

    partial class PGType {

        private PGType() { }

        public PGType(Soggetto s) {
            CodiceFiscale_PartitaIva = s.partitaiva;
            DenominazioneOrganizzazione = s.denominazione;
        }
    }
}
