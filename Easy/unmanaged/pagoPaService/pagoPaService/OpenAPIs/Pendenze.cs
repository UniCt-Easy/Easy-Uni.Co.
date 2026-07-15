/*
Easy
Copyright (C) 2026 Università degli Studi di Catania (www.unict.it)
This program is free software: you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.
This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.
You should have received a copy of the GNU General Public License
along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace pagoPaService
{
    // -----------------------------
    // Primitive aliases
    // -----------------------------
    public class Pagina
    {
        public int value { get; set; } = 1;
    }

    public class RisultatiPerPagina
    {
        [Range(1, 200)]
        public int value { get; set; } = 25;
    }

    // -----------------------------
    // Schemi base
    // -----------------------------
    public class AllegatoPendenza
    {
        [Required, MinLength(1), MaxLength(255)]
        public string nome { get; set; }

        [MinLength(1), MaxLength(255)]
        public string tipo { get; set; } = "application/octet-stream";

        [MinLength(1), MaxLength(255)]
        public string descrizione { get; set; }

        // path /allegati/{id}
        [Required]
        public string contenuto { get; set; }
    }

    public class NuovoAllegatoPendenza
    {
        [Required, MinLength(1), MaxLength(255)]
        public string nome { get; set; }

        [MinLength(1), MaxLength(255)]
        public string tipo { get; set; } = "application/octet-stream";

        [MinLength(1), MaxLength(255)]
        public string descrizione { get; set; }

        // base64 bytes
        [Required]
        public string contenuto { get; set; }
    }

    public class MapEntry
    {
        [Required, MinLength(1), MaxLength(140)]
        public string key { get; set; }

        [Required, MinLength(1), MaxLength(140)]
        public string value { get; set; }
    }

    public class Metadata
    {
        [MinLength(1), MaxLength(5)]
        public List<MapEntry> mapEntries { get; set; }
    }

    public class QuotaContabilita
    {
        [Required, MaxLength(64)]
        public string capitolo { get; set; }

        [Required]
        public int annoEsercizio { get; set; }

        [Required]
        public double importo { get; set; }

        [MaxLength(64)]
        public string accertamento { get; set; }

        public object proprietaCustom { get; set; }

        [MaxLength(64)]
        public string titolo { get; set; }

        [MaxLength(64)]
        public string tipologia { get; set; }

        [MaxLength(64)]
        public string categoria { get; set; }

        [MaxLength(64)]
        public string articolo { get; set; }
    }

    public class Contabilita
    {
        public List<QuotaContabilita> quote { get; set; }
        public object proprietaCustom { get; set; }
    }

    public class FaultBean
    {
        // enum: AUTORIZZAZIONE, RICHIESTA, OPERAZIONE, PAGOPA, EC, INTERNO
        [Required]
        public string categoria { get; set; }

        [Required]
        public string codice { get; set; }

        [Required]
        public string descrizione { get; set; }

        public string dettaglio { get; set; }
    }

    public class Segnalazione
    {
        public string data { get; set; }

        [Required]
        public string codice { get; set; }

        [Required]
        public string descrizione { get; set; }

        public string dettaglio { get; set; }
    }

    public class Dominio
    {
        [Required, MinLength(1), MaxLength(35)]
        public string idDominio { get; set; }

        [Required, MinLength(1), MaxLength(70)]
        public string ragioneSociale { get; set; }
    }

    public class UnitaOperativa
    {
        [MinLength(1), MaxLength(35)]
        public string idUnita { get; set; }

        [Required, MinLength(1), MaxLength(70)]
        public string ragioneSociale { get; set; }

        [MinLength(1), MaxLength(70)]
        public string indirizzo { get; set; }

        [MinLength(1), MaxLength(16)]
        public string civico { get; set; }

        [MinLength(1), MaxLength(16)]
        public string cap { get; set; }

        [MinLength(1), MaxLength(35)]
        public string localita { get; set; }

        [MinLength(1), MaxLength(35)]
        public string provincia { get; set; }

        [RegularExpression("[A-Z]{2,2}")]
        public string nazione { get; set; }

        [RegularExpression("[A-Za-z0-9_]+([\\-\\+\\.'][A-Za-z0-9_]+)*@[A-Za-z0-9_]+([\\-\\.][A-Za-z0-9_]+)*\\.[A-Za-z0-9_]+([\\-\\.][A-Za-z0-9_]+)*")]
        public string email { get; set; }

        [RegularExpression("[A-Za-z0-9_]+([\\-\\+\\.'][A-Za-z0-9_]+)*@[A-Za-z0-9_]+([\\-\\.][A-Za-z0-9_]+)*\\.[A-Za-z0-9_]+([\\-\\.][A-Za-z0-9_]+)*")]
        public string pec { get; set; }

        public string tel { get; set; }
        public string fax { get; set; }
        public string web { get; set; }
        public string area { get; set; }
    }

    public class Soggetto
    {
        // enum: G / F
        [Required]
        public string tipo { get; set; }

        [Required, MinLength(2), MaxLength(16)]
        public string identificativo { get; set; }

        [MinLength(1), MaxLength(70)]
        public string anagrafica { get; set; }

        [MinLength(1), MaxLength(70)]
        public string indirizzo { get; set; }

        [MinLength(1), MaxLength(16)]
        public string civico { get; set; }

        [MinLength(1), MaxLength(16)]
        public string cap { get; set; }

        [MinLength(1), MaxLength(35)]
        public string localita { get; set; }

        [MinLength(1), MaxLength(35)]
        public string provincia { get; set; }

        [RegularExpression("[A-Z]{2,2}")]
        public string nazione { get; set; }

        [RegularExpression("[A-Za-z0-9_]+([\\-\\+\\.'][A-Za-z0-9_]+)*@[A-Za-z0-9_]+([\\-\\.][A-Za-z0-9_]+)*\\.[A-Za-z0-9_]+([\\-\\.][A-Za-z0-9_]+)*")]
        public string email { get; set; }

        [RegularExpression("\\+[0-9]{2,2}\\s[0-9]{3,3}\\-[0-9]{7,7}")]
        public string cellulare { get; set; }
    }

    // -----------------------------
    // Documento + oneOf TipoRiferimentoDocumento
    // -----------------------------
    public class RataDocumento
    {
        [Required, Range(1, int.MaxValue)]
        public int rata { get; set; }
    }

    public class VincoloPagamento
    {
        [Required, Range(1, int.MaxValue)]
        public int giorni { get; set; }

        // enum: ENTRO / OLTRE
        [Required]
        public string tipo { get; set; }
    }

    public class VincoloDocumento
    {
        [Required]
        public VincoloPagamento soglia { get; set; }
    }

    /// <summary>
    /// YAML: TipoRiferimentoDocumento oneOf (RataDocumento | VincoloDocumento)
    /// Implementato come proprietà opzionali + validazione "exactly one".
    /// </summary>
    public abstract class TipoRiferimentoDocumentoBase : IValidatableObject
    {
        public int? rata { get; set; }
        public VincoloPagamento soglia { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var hasRata = rata.HasValue;
            var hasSoglia = soglia != null;

            if (hasRata == hasSoglia) // entrambi true o entrambi false
            {
                yield return new ValidationResult(
                    "TipoRiferimentoDocumento: valorizzare esattamente uno tra 'rata' e 'soglia'.",
                    new[] { "rata", "soglia" });
            }
        }
    }

    public class Documento : TipoRiferimentoDocumentoBase
    {
        [Required, MinLength(1), MaxLength(35)]
        public string identificativo { get; set; }

        [Required, MinLength(1), MaxLength(80)]
        public string descrizione { get; set; }
    }

    public class NuovoDocumento : TipoRiferimentoDocumentoBase
    {
        [Required, MinLength(1), MaxLength(35)]
        public string identificativo { get; set; }

        [Required, MinLength(1), MaxLength(80)]
        public string descrizione { get; set; }
    }

    // -----------------------------
    // oneOf TipoRiferimentoVocePendenza
    // -----------------------------
    public class RiferimentoEntrata
    {
        [Required]
        [RegularExpression("(^[a-zA-Z0-9\\-_\\.]{1,35}$)")]
        public string codEntrata { get; set; }
    }

    public class Entrata
    {
        [Required]
        [RegularExpression("[a-zA-Z]{2,2}[0-9]{2,2}[a-zA-Z0-9]{1,30}")]
        public string ibanAccredito { get; set; }

        [RegularExpression("[a-zA-Z]{2,2}[0-9]{2,2}[a-zA-Z0-9]{1,30}")]
        public string ibanAppoggio { get; set; }

        // enum: CAPITOLO, SPECIALE, SIOPE, ALTRO
        [Required]
        public string tipoContabilita { get; set; }

        [Required, MinLength(1), MaxLength(135)]
        public string codiceContabilita { get; set; }
    }

    public class Bollo
    {
        // enum: '01'
        [Required]
        public string tipoBollo { get; set; }

        [Required, MaxLength(70)]
        public string hashDocumento { get; set; }

        [Required]
        [RegularExpression("[A-Z]{2,2}")]
        public string provinciaResidenza { get; set; }
    }

    /// <summary>
    /// YAML: TipoRiferimentoVocePendenza oneOf (RiferimentoEntrata | Entrata | Bollo)
    /// Implementato come proprietà opzionali + validazione oneOf.
    /// </summary>
    public abstract class TipoRiferimentoVocePendenzaBase : IValidatableObject
    {
        // Variante 1: RiferimentoEntrata
        [RegularExpression("(^[a-zA-Z0-9\\-_\\.]{1,35}$)")]
        public string codEntrata { get; set; }

        // Variante 2: Entrata
        [RegularExpression("[a-zA-Z]{2,2}[0-9]{2,2}[a-zA-Z0-9]{1,30}")]
        public string ibanAccredito { get; set; }

        [RegularExpression("[a-zA-Z]{2,2}[0-9]{2,2}[a-zA-Z0-9]{1,30}")]
        public string ibanAppoggio { get; set; }

        public string tipoContabilita { get; set; }

        [MinLength(1), MaxLength(135)]
        public string codiceContabilita { get; set; }

        // Variante 3: Bollo
        public string tipoBollo { get; set; }

        [MaxLength(70)]
        public string hashDocumento { get; set; }

        [RegularExpression("[A-Z]{2,2}")]
        public string provinciaResidenza { get; set; }

        protected bool IsRiferimentoEntrata()
            => !string.IsNullOrWhiteSpace(codEntrata);

        protected bool IsEntrata()
            => !string.IsNullOrWhiteSpace(ibanAccredito)
               && !string.IsNullOrWhiteSpace(tipoContabilita)
               && !string.IsNullOrWhiteSpace(codiceContabilita);

        protected bool IsBollo()
            => !string.IsNullOrWhiteSpace(tipoBollo)
               && !string.IsNullOrWhiteSpace(hashDocumento)
               && !string.IsNullOrWhiteSpace(provinciaResidenza);

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var matches = 0;
            if (IsRiferimentoEntrata()) matches++;
            if (IsEntrata()) matches++;
            if (IsBollo()) matches++;

            if (matches != 1)
            {
                yield return new ValidationResult(
                    "TipoRiferimentoVocePendenza: il JSON deve corrispondere a UNO SOLO tra {RiferimentoEntrata, Entrata, Bollo}.",
                    new[]
                    {
                        "codEntrata",
                        "ibanAccredito","tipoContabilita","codiceContabilita",
                        "tipoBollo","hashDocumento","provinciaResidenza"
                    });
            }
        }
    }

    // -----------------------------
    // Voci / Pendenze
    // -----------------------------
    public class VoceDescrizioneImporto
    {
        public string voce { get; set; }
        public double? importo { get; set; }
    }

    public class NuovaVocePendenza : TipoRiferimentoVocePendenzaBase
    {
        [Required, MinLength(1), MaxLength(35)]
        public string idVocePendenza { get; set; }

        [Required, Range(0.00, 9999999999999999.99)]
        public double importo { get; set; }

        [Required, MinLength(1), MaxLength(140)]
        public string descrizione { get; set; }

        public object datiAllegati { get; set; }

        [MinLength(1), MaxLength(140)]
        public string descrizioneCausaleRPT { get; set; }

        public Contabilita contabilita { get; set; }
        public Metadata metadata { get; set; }

        [MinLength(1), MaxLength(35)]
        [RegularExpression("(^[0-9]{11}$)")]
        public string idDominio { get; set; }
    }

    public class VocePendenza : TipoRiferimentoVocePendenzaBase
    {
        [Required, MinLength(1), MaxLength(35)]
        public string idVocePendenza { get; set; }

        [Required, Range(0.00, 9999999999999999.99)]
        public double importo { get; set; }

        [Required, MinLength(1), MaxLength(140)]
        public string descrizione { get; set; }

        public object datiAllegati { get; set; }

        [MinLength(1), MaxLength(140)]
        public string descrizioneCausaleRPT { get; set; }

        public Contabilita contabilita { get; set; }
        public Metadata metadata { get; set; }

        [Required, Range(1, 5)]
        public int indice { get; set; }

        // enum: Eseguito, Non eseguito, Anomalo
        [Required]
        public string stato { get; set; }

        public Dominio dominio { get; set; }
    }

    public class ProprietaPendenza
    {
        // enum: 'false', 'de','en','fr','sl'
        public string linguaSecondaria { get; set; }

        public List<VoceDescrizioneImporto> descrizioneImporto { get; set; }

        public string lineaTestoRicevuta1 { get; set; }
        public string lineaTestoRicevuta2 { get; set; }

        public string linguaSecondariaCausale { get; set; }

        [MaxLength(255)]
        public string informativaImportoAvviso { get; set; }

        [MaxLength(255)]
        public string linguaSecondariaInformativaImportoAvviso { get; set; }

        // nel YAML c'è un refuso: dataScandenzaAvviso
        public string dataScandenzaAvviso { get; set; }
    }

    public class NuovaPendenza
    {
        [Required]
        [RegularExpression("(^[a-zA-Z0-9\\-_\\.]{1,35}$)")]
        public string idTipoPendenza { get; set; }

        [Required, MinLength(1), MaxLength(35)]
        [RegularExpression("^[0-9]{11}$")]
        public string idDominio { get; set; }

        [MinLength(1), MaxLength(35)]
        [RegularExpression("(^[a-zA-Z0-9\\-_]{1,35}$)")]
        public string idUnitaOperativa { get; set; }

        [Required, MaxLength(140)]
        public string causale { get; set; }

        [Required]
        public Soggetto soggettoPagatore { get; set; }

        [Required, Range(0.00, 9999999999999999.99)]
        public double importo { get; set; }

        [RegularExpression("^[0-9]{18}$")]
        public string numeroAvviso { get; set; }

        [MaxLength(35)]
        public string tassonomia { get; set; }

        public string tassonomiaAvviso { get; set; }

        [MinLength(1), MaxLength(35)]
        public string direzione { get; set; }

        [MinLength(1), MaxLength(35)]
        public string divisione { get; set; }

        public string dataValidita { get; set; }
        public string dataScadenza { get; set; }

        public int? annoRiferimento { get; set; }

        [MinLength(1), MaxLength(35)]
        public string cartellaPagamento { get; set; }

        public object datiAllegati { get; set; }

        public NuovoDocumento documento { get; set; }

        public string dataNotificaAvviso { get; set; }
        public string dataPromemoriaScadenza { get; set; }

        public ProprietaPendenza proprieta { get; set; }

        [Required, MinLength(1), MaxLength(5)]
        public List<NuovaVocePendenza> voci { get; set; }

        public List<NuovoAllegatoPendenza> allegati { get; set; }
    }

    public class PendenzaCreata
    {
        [Required]
        public string idDominio { get; set; }

        [Required]
        public string numeroAvviso { get; set; }

        public string UUID { get; set; }

        // base64 pdf
        public string pdf { get; set; }
    }

    public class PendenzaBase
    {
        [Required]
        public string idA2A { get; set; }

        [Required]
        public string idPendenza { get; set; }

        public string idTipoPendenza { get; set; }

        [Required]
        public Dominio dominio { get; set; }

        public UnitaOperativa unitaOperativa { get; set; }

        // enum StatoPendenza
        [Required]
        public string stato { get; set; }

        public string descrizioneStato { get; set; }

        public List<Segnalazione> segnalazioni { get; set; }

        public string iuvAvviso { get; set; }
        public string iuvPagamento { get; set; }

        public string dataPagamento { get; set; }

        [MaxLength(140)]
        public string causale { get; set; }

        [Required]
        public Soggetto soggettoPagatore { get; set; }

        [Required, Range(0.00, 9999999999999999.99)]
        public double importo { get; set; }

        [RegularExpression("^[0-9]{18}$")]
        public string numeroAvviso { get; set; }

        [Required]
        public DateTime dataCaricamento { get; set; }

        public string dataValidita { get; set; }
        public string dataScadenza { get; set; }

        public int? annoRiferimento { get; set; }

        public string cartellaPagamento { get; set; }
        public object datiAllegati { get; set; }

        public string tassonomia { get; set; }
        public string tassonomiaAvviso { get; set; }

        [MinLength(1), MaxLength(35)]
        public string direzione { get; set; }

        [MinLength(1), MaxLength(35)]
        public string divisione { get; set; }

        public Documento documento { get; set; }

        // enum: spontaneo / dovuto
        [Required]
        public string tipo { get; set; }

        public string UUID { get; set; }

        public ProprietaPendenza proprieta { get; set; }
    }

    public class Pendenza : PendenzaBase
    {
        [Required, MinLength(1), MaxLength(5)]
        public List<VocePendenza> voci { get; set; }

        [Required]
        public List<RppIndex> rpp { get; set; }

        public List<AllegatoPendenza> allegati { get; set; }
    }

    public class PendenzaIndex : PendenzaBase
    {
        [Required]
        public string rpp { get; set; }

        [Required]
        public string pagamenti { get; set; }
    }

    public class Lista
    {
        [Required]
        public int numRisultati { get; set; }

        [Required]
        public int numPagine { get; set; }

        [Required]
        public int risultatiPerPagina { get; set; }

        [Required]
        public int pagina { get; set; }

        public string prossimiRisultati { get; set; }
    }

    public class Pendenze : Lista
    {
        public List<PendenzaIndex> risultati { get; set; }
    }

    // -----------------------------
    // Avviso / Documento stampe
    // -----------------------------
    public class Avviso
    {
        // enum StatoAvviso
        [Required]
        public string stato { get; set; }

        public double? importo { get; set; }

        public string idDominio { get; set; }
        public string numeroAvviso { get; set; }

        public string dataValidita { get; set; }
        public string dataScadenza { get; set; }
        public string dataPagamento { get; set; }

        public string descrizione { get; set; }

        // enum TassonomiaAvviso (testo con spazi) => string
        public string tassonomiaAvviso { get; set; }

        public string qrcode { get; set; }
        public string barcode { get; set; }
    }

    // -----------------------------
    // RPP
    // -----------------------------
    public class RppBase
    {
        [Required]
        public string stato { get; set; }

        public string dettaglioStato { get; set; }

        public List<Segnalazione> segnalazioni { get; set; }

        [Required]
        public object rpt { get; set; }

        public object rt { get; set; }
    }

    public class Rpp : RppBase
    {
        [Required]
        public PendenzaIndex pendenza { get; set; }
    }

    public class RppIndex : RppBase
    {
        [Required]
        public PendenzaIndex pendenza { get; set; }
    }

    public class Rpps : Lista
    {
        public List<RppIndex> risultati { get; set; }
    }

    // -----------------------------
    // Profilo / ACL
    // -----------------------------
    public class Acl
    {
        public string ruolo { get; set; }
        public string principal { get; set; }

        // enum TipoServizio (valori con spazi) => string
        [Required]
        public string servizio { get; set; }

        // array di enum: Lettura/Scrittura
        [Required]
        public List<string> autorizzazioni { get; set; }
    }

    public class TipoPendenzaIndex
    {
        [Required]
        public string idTipoPendenza { get; set; }

        [Required]
        public string descrizione { get; set; }
    }

    public class TipoPendenza : TipoPendenzaIndex
    {
        // nel YAML: allOf solo TipoPendenzaIndex, quindi uguale
    }

    public class Profilo
    {
        [Required]
        public string nome { get; set; }

        [Required]
        public List<Dominio> domini { get; set; }

        [Required]
        public List<TipoPendenza> tipiPendenza { get; set; }

        [Required]
        public List<Acl> acl { get; set; }

        public Soggetto anagrafica { get; set; }

        public object identityData { get; set; }
    }

    // -----------------------------
    // PATCH (application/json-patch+json)
    // -----------------------------
    public class PatchOp
    {
        // enum: ADD / DELETE / REPLACE
        [Required]
        public string op { get; set; }

        [Required]
        public string path { get; set; }

        [Required]
        public object value { get; set; }
    }
}
