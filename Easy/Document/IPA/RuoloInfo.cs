
namespace Document.IPA {

    /// <summary>
    /// Associa un Soggetto al suo Tipo.
    /// </summary>
    public class RuoloInfo {
        public TSoggetto Tipo { get; }
        public ISoggetto Soggetto { get; }

        public TPersona Persona => string.IsNullOrWhiteSpace(Soggetto.Denominazione) ? TPersona.Fisica : TPersona.Giuridica;
        public string Name {

            get {

                if (Persona == TPersona.Giuridica)
                    return Soggetto.Denominazione;

                var cognome = Soggetto.Cognome?.Trim();
                var nome = Soggetto.Nome?.Trim();

                if (!string.IsNullOrWhiteSpace(cognome) && !string.IsNullOrWhiteSpace(nome))
                    return $"{cognome} {nome}";

                return cognome ?? nome ?? string.Empty;
            }
        }

        /// <summary>
        /// Crea l'associazione tra Soggetto e Tipo.
        /// </summary>
        /// <param name="tipo">Tipo da associare.</param>
        /// <param name="soggetto">Soggetto da associare</param>
        public RuoloInfo(TSoggetto tipo, ISoggetto soggetto) {

            Tipo = tipo;
            Soggetto = soggetto;
        }
    }
}
