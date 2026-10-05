using System;
using System.Reflection;
using System.Collections.Generic;

using Document;
using Document.IPA;

using preserve.Metadata.AGID;

namespace preserve.UniStorage.Logic {

    /// Questa logica è stata introdotta per modificare il meno possibile le classi autogenerate ottenute dall'XSD

    /// <summary>
    /// Enumerazione condivisa per unificare le enumerazioni specifiche usate sui tipi di documento.
    /// </summary>
    public enum TipologiaDiFlusso {
        E,  // entrata
        U,  // uscita
        I,  // interno
    }

    /// <summary>
    /// Logica statica per la mappatura tra il nostro formato di descrizione dei documenti e quello di UniStorage.
    /// </summary>
    public static class Mappings {

        /// <summary>
        /// Riporta L'enumerazione condivisa al valore di quella specifica TEnum
        /// </summary>
        /// <typeparam name="TEnum">Tipo dell'enumerazione specifica per la serializzazione del tipo di documento.</typeparam>
        /// <param name="value">Valore dell'enumerazione condivisa.</param>
        /// <returns>Valore dell'enumerazione specifica.</returns>
        public static TEnum ToOriginal<TEnum>(TipologiaDiFlusso value) where TEnum : Enum {
            return (TEnum)Enum.Parse(typeof(TEnum), value.ToString());
        }

        /// <summary>
        /// Associa al tipo di documento la direzione del flusso.
        /// </summary>
        public static Dictionary<TDocument, TipologiaDiFlusso> TipologiaDiFlusso =
            new Dictionary<TDocument, TipologiaDiFlusso>() {

                { TDocument.documentoInformatico,           Logic.TipologiaDiFlusso.I},

                { TDocument.ordVen,                         Logic.TipologiaDiFlusso.U },
                { TDocument.fattAcq,                        Logic.TipologiaDiFlusso.E },
                { TDocument.fattVen,                        Logic.TipologiaDiFlusso.U },
                { TDocument.fattAcquEstere,                 Logic.TipologiaDiFlusso.U },
                { TDocument.messOrdVen,                     Logic.TipologiaDiFlusso.E },
                { TDocument.messAcq,                        Logic.TipologiaDiFlusso.E },
                { TDocument.messVen,                        Logic.TipologiaDiFlusso.E },
                { TDocument.messAcquEstere,                 Logic.TipologiaDiFlusso.E },

                { TDocument.registroProtocollo,             Logic.TipologiaDiFlusso.I },
                
                { TDocument.Mandato,                        Logic.TipologiaDiFlusso.I },
                { TDocument.Mandato_Stampa,                 Logic.TipologiaDiFlusso.I },
                { TDocument.DURC_Anagr,                     Logic.TipologiaDiFlusso.E },
                { TDocument.DURC_Autocertificazione_Anagr,  Logic.TipologiaDiFlusso.E },
                { TDocument.CCdedicato_Anagr,               Logic.TipologiaDiFlusso.E },
                { TDocument.CCdedicato_CF_Anagr,            Logic.TipologiaDiFlusso.E },
                { TDocument.Contratto_Occas,                Logic.TipologiaDiFlusso.I },
                { TDocument.Contratto_Profes,               Logic.TipologiaDiFlusso.I },

                { TDocument.Reversale,                      Logic.TipologiaDiFlusso.I },
                { TDocument.Reversale_Stampa,               Logic.TipologiaDiFlusso.I },

                { TDocument.Missione,                       Logic.TipologiaDiFlusso.I },
                { TDocument.Missione_Stampa_Prospetto,      Logic.TipologiaDiFlusso.I },
                { TDocument.Missione_Stampa_Modulo,         Logic.TipologiaDiFlusso.I },
                { TDocument.Missione_Spesa,                 Logic.TipologiaDiFlusso.E },
            };


        /// <summary>
        /// XPath della causale del documento.
        /// </summary>
        private readonly static string subjectPath = "//FatturaElettronicaBody/DatiGenerali/DatiGeneraliDocumento/Causale";

        /// <summary>
        /// Associa al tipo di documento il metodo da utilizzare per ricavare l'Oggetto.
        /// </summary>
        public static Dictionary<TDocument, Func<IPreserveDataLegacy, string>> Oggetto = new Dictionary<TDocument, Func<IPreserveDataLegacy, string>>() {
            { TDocument.ordVen,                         (IPreserveDataLegacy pd) => PreserveFile.getXmlText(pd.Xml, subjectPath, null) ?? string.Join(", ", Functions.MessaggioSubjectFallback(pd)) },
            { TDocument.fattAcq,                        (IPreserveDataLegacy pd) => PreserveFile.getXmlText(pd.Xml, subjectPath, null) ?? string.Join(", ", Functions.FatturaSubjectFallback(pd))   },
            { TDocument.fattVen,                        (IPreserveDataLegacy pd) => PreserveFile.getXmlText(pd.Xml, subjectPath, null) ?? string.Join(", ", Functions.FatturaSubjectFallback(pd))   },
            { TDocument.fattAcquEstere,                 (IPreserveDataLegacy pd) => PreserveFile.getXmlText(pd.Xml, subjectPath, null) ?? string.Join(", ", Functions.FatturaSubjectFallback(pd))   },
            { TDocument.messOrdVen,                     (IPreserveDataLegacy pd) => string.Join(", ", Functions.MessaggioSubjectFallback(pd)) },
            { TDocument.messAcq,                        (IPreserveDataLegacy pd) => string.Join(", ", Functions.MessaggioSubjectFallback(pd)) },
            { TDocument.messVen,                        (IPreserveDataLegacy pd) => string.Join(", ", Functions.MessaggioSubjectFallback(pd)) },
            { TDocument.messAcquEstere,                 (IPreserveDataLegacy pd) => string.Join(", ", Functions.MessaggioSubjectFallback(pd)) },

            { TDocument.registroProtocollo,             (IPreserveDataLegacy pd) => "" },
        };

        /// <summary>
        /// Associa al tipo di verifica il costruttore da utilizzare per VerificaType.
        /// </summary>
        public static Dictionary<TVerifica, IVerificaType> VerificaTypeConstructors = new Dictionary<TVerifica, IVerificaType>() {

            { TVerifica.Firmato, new Metadata.AGID.DocumentoInformatico.VerificaType() {
                ConformitaCopieImmagineSuSupportoInformatico = false,
                FirmatoDigitalmente = true,
                MarcaturaTemporale = false,
                SigillatoElettronicamente = false,
            } },

            { TVerifica.NonFirmato, new Metadata.AGID.DocumentoInformatico.VerificaType() {
                ConformitaCopieImmagineSuSupportoInformatico = false,
                FirmatoDigitalmente = false,
                MarcaturaTemporale = false,
                SigillatoElettronicamente = false,
            } },

            { TVerifica.RegistroProtocollo, new Metadata.AGID.DocumentoAmministrativoInformatico.VerificaType() {
                ConformitaCopieImmagineSuSupportoInformatico = false,
                FirmatoDigitalmente = false,
                MarcaturaTemporale = false,
                SigillatoElettronicamente = true,
            } },
        };

        /// <summary>
        /// Associa al tipo di documento il tipo di firma utilizzato.
        /// </summary>
        public static Dictionary<TDocument, IVerificaType> VerificaTypes = new Dictionary<TDocument, IVerificaType>() {

            { TDocument.documentoInformatico,           VerificaTypeConstructors[TVerifica.NonFirmato] },

            { TDocument.ordVen,                         VerificaTypeConstructors[TVerifica.NonFirmato] },
            { TDocument.fattAcq,                        VerificaTypeConstructors[TVerifica.Firmato] },
            { TDocument.fattVen,                        VerificaTypeConstructors[TVerifica.NonFirmato] },
            { TDocument.fattAcquEstere,                 VerificaTypeConstructors[TVerifica.Firmato] },
            { TDocument.messOrdVen,                     VerificaTypeConstructors[TVerifica.NonFirmato] },
            { TDocument.messAcq,                        VerificaTypeConstructors[TVerifica.NonFirmato] },
            { TDocument.messVen,                        VerificaTypeConstructors[TVerifica.NonFirmato] },
            { TDocument.messAcquEstere,                 VerificaTypeConstructors[TVerifica.NonFirmato] },

            { TDocument.registroProtocollo,             VerificaTypeConstructors[TVerifica.RegistroProtocollo] },

            { TDocument.Mandato,                        VerificaTypeConstructors[TVerifica.NonFirmato] },
            { TDocument.Mandato_Stampa,                 VerificaTypeConstructors[TVerifica.NonFirmato] },
            { TDocument.DURC_Anagr,                     VerificaTypeConstructors[TVerifica.NonFirmato] },
            { TDocument.DURC_Autocertificazione_Anagr,  VerificaTypeConstructors[TVerifica.NonFirmato] },
            { TDocument.CCdedicato_Anagr,               VerificaTypeConstructors[TVerifica.NonFirmato] },
            { TDocument.CCdedicato_CF_Anagr,            VerificaTypeConstructors[TVerifica.NonFirmato] },
            { TDocument.Contratto_Occas,                VerificaTypeConstructors[TVerifica.NonFirmato] },
            { TDocument.Contratto_Profes,               VerificaTypeConstructors[TVerifica.NonFirmato] },

            { TDocument.Reversale,                      VerificaTypeConstructors[TVerifica.NonFirmato] },
            { TDocument.Reversale_Stampa,               VerificaTypeConstructors[TVerifica.NonFirmato] },

            { TDocument.Missione,                       VerificaTypeConstructors[TVerifica.NonFirmato] },
            { TDocument.Missione_Stampa_Prospetto,      VerificaTypeConstructors[TVerifica.NonFirmato] },
            { TDocument.Missione_Stampa_Modulo,         VerificaTypeConstructors[TVerifica.NonFirmato] },
            { TDocument.Missione_Spesa,                 VerificaTypeConstructors[TVerifica.NonFirmato] },
        };

        //[System.Xml.Serialization.XmlElementAttribute("Altro", typeof(TipoSoggetto13Type))]
        //[System.Xml.Serialization.XmlElementAttribute("Assegnatario", typeof(TipoSoggetto22Type))]
        //[System.Xml.Serialization.XmlElementAttribute("Autore", typeof(TipoSoggetto31Type))]
        //[System.Xml.Serialization.XmlElementAttribute("Destinatario", typeof(TipoSoggetto11Type))]
        //[System.Xml.Serialization.XmlElementAttribute("Mittente", typeof(TipoSoggetto12Type))]
        //[System.Xml.Serialization.XmlElementAttribute("Operatore", typeof(TipoSoggetto32Type))]
        //[System.Xml.Serialization.XmlElementAttribute("Produttore", typeof(TipoSoggetto4Type))]
        //[System.Xml.Serialization.XmlElementAttribute("ResponsabileGestioneDocumentale", typeof(TipoSoggetto33Type))]
        //[System.Xml.Serialization.XmlElementAttribute("ResponsabileServizioProtocollo", typeof(TipoSoggetto34Type))]
        //[System.Xml.Serialization.XmlElementAttribute("SoggettoCheEffettuaLaRegistrazione", typeof(TipoSoggetto21Type))]

        /// <summary>
        /// Associa al tipo di soggetto il costruttore da utilizzare per SoggettoType su DocumentoInformatico.
        /// </summary>
        public static Dictionary<TSoggetto, Func<Soggetto, object>> DocumentoInformaticoSoggettoTypeConstructors = new Dictionary<TSoggetto, Func<Soggetto, object>>() {
            { TSoggetto.Mittente,       (Soggetto s) => new Metadata.AGID.DocumentoInformatico.TipoSoggetto12Type(s) },
            { TSoggetto.Destinatario,   (Soggetto s) => new Metadata.AGID.DocumentoInformatico.TipoSoggetto11Type(s) },
            { TSoggetto.Produttore,     (Soggetto s) => new Metadata.AGID.DocumentoInformatico.TipoSoggetto4Type($"{Assembly.GetExecutingAssembly().GetName().Name}") },
        };

        /// <summary>
        /// Associa al tipo di soggetto il costruttore da utilizzare per SoggettoType su RegistroProtocollo.
        /// </summary>
        public static Dictionary<TSoggetto, Func<Soggetto, object>> RegistroGiornalieroProtocolloSoggettoTypeConstructors = new Dictionary<TSoggetto, Func<Soggetto, object>>() {
            { TSoggetto.Amministrazione,    (Soggetto s) => new Metadata.AGID.DocumentoAmministrativoInformatico.TipoSoggetto1Type(s) },
            { TSoggetto.Autore,             (Soggetto s) => new Metadata.AGID.DocumentoAmministrativoInformatico.TipoSoggetto41Type() { TipoRuolo = "PAI" } },
            { TSoggetto.Produttore,         (Soggetto s) => new Metadata.AGID.DocumentoAmministrativoInformatico.TipoSoggetto5Type($"{Assembly.GetExecutingAssembly().GetName().Name}") },
        };

        /// <summary>
        /// Associa al tipo di persona il costruttore da utilizzare per PersonaType su DocumentoInformatico.
        /// </summary>
        private static readonly Dictionary<TPersona, Func<Soggetto, object>> DocumentoInformaticoPersonaTypeConstructors = new Dictionary<TPersona, Func<Soggetto, object>>() {
            { TPersona.Fisica,      (Soggetto s) => new Metadata.AGID.DocumentoInformatico.PFType(s) },
            { TPersona.Giuridica,   (Soggetto s) => new Metadata.AGID.DocumentoInformatico.PGType(s) },
        };

        /// <summary>
        /// Associa al tipo di persona il costruttore da utilizzare per PersonaType su RegistroProtocollo.
        /// </summary>
        private static readonly Dictionary<TPersona, Func<Soggetto, object>> RegistroGiornalieroProtocolloPersonaTypeConstructors = new Dictionary<TPersona, Func<Soggetto, object>>() {
            { TPersona.Fisica,      (Soggetto s) => new Metadata.AGID.DocumentoAmministrativoInformatico.PFType(s) },
            { TPersona.Giuridica,   (Soggetto s) => new Metadata.AGID.DocumentoAmministrativoInformatico.PGType(s) },
        };

        /// <summary>
        /// Restituisce un costruttore dell'oggetto specifico associato alla coppia di valori per il
        /// tipo di Documento ed il tipo di Persona.
        /// Se il tipo documento non è specificato sarà assunto come tipologia relativa a DocumentoInformatico.
        /// </summary>
        /// <param name="tp">Tipo persona.</param>
        /// <param name="td">Tipo documento.</param>
        /// <returns>Costruttore associato.</returns>
        public static Func<Soggetto, object> PersonaTypeConstructorsMapper(TPersona tp, TDocument? td = null) {

            Dictionary<TPersona, Func<Soggetto, object>> dictionary = null;

            if (td == null) {

                dictionary = DocumentoInformaticoPersonaTypeConstructors;
            }
            else {

                switch (td.Value) {
                    case TDocument.ordVen:
                    case TDocument.fattAcq:
                    case TDocument.fattVen:
                    case TDocument.fattAcquEstere:
                    case TDocument.messOrdVen:
                    case TDocument.messAcq:
                    case TDocument.messVen:
                    case TDocument.messAcquEstere:
                        dictionary = DocumentoInformaticoPersonaTypeConstructors;
                        break;

                    case TDocument.registroProtocollo:
                        dictionary = RegistroGiornalieroProtocolloPersonaTypeConstructors;
                        break;
                }
            }

            if (dictionary != null && dictionary.TryGetValue(tp, out var constructor))
                return constructor;

            throw new InvalidOperationException(
                $"No constructor mapping found for PersonaType '{tp}' in DocumentType '{td?.ToString() ?? "null"}'. " +
                $"Check that '{tp}' is registered in the appropriate dictionary for '{td?.ToString() ?? "null"}'.");
        }
    }
}
