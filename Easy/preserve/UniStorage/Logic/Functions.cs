using System;
using System.Xml;
using System.Collections.Generic;
using System.Linq;

using Document;
using Document.SDI;
using Document.IPA;

namespace preserve.UniStorage.Logic {

    /// Questa logica è stata introdotta per modificare il meno possibile le classi autogenerate ottenute dall'XSD

    public static class Functions {

        // I metodi statici per l'estrazione di elementi dall'XML potrebbero essere generalizzati ed unificati
        // passando un filtro Func<IEnumerable<XmlNode>, IEnumerable<string>> come argomento.
        // Inoltre essi potrebbero eventualmente diventare metodi di IPreserveDataLegacy.

        // Si potrebbe pensare di utilizzare una classe statica come Behaviour per unificare i dictionary statici,
        // e di conseguenza utilizzare un unico dizionario che associ al tipo di documento un Behaviour.
        // Per ora utilizziamo dizionari multipli, probabilmente la definizione di Logic risulta più modulare ed espandibile in questo modo.
        //public class Behaviour {
        //    public Func<XmlNode, string> Oggetto;
        //    public Func<IPreserveDataLegacy, IEnumerable<RuoloType>> Soggetti;
        //    public Func<VerificaType> Verifica;
        //}
        //public static Dictionary<TDocument, Behaviour> DocumentBehaviours = new Dictionary<TDocument, Behaviour>() {
        //    { TDocument.ordVen, new Behaviour {
        //        Oggetto = (XmlNode doc) => PreserveFile.getXmlText(doc, "//FatturaElettronicaBody/DatiGenerali/DatiGeneraliDocumento/Causale", null) ?? string.Join(", ", MessaggioSubjectFallback(doc)),
        //        Soggetti = (IPreserveDataLegacy data) => RuoloTypesOrdine(data),
        //        Verifica = () => VerificaTypeConstructors[TVerifica.NonFirmato],
        //    } }
        //};

        /// <summary>
        /// Fornisce l'oggetto di una fattura elettronica dato un descrittore di un documento da mandare in conservazione.
        /// </summary>
        /// <param name="pd">Descrittore di un documento da mandare in conservazione.</param>
        /// <returns>Oggetto della fattura.</returns>
        public static IEnumerable<string> FatturaSubjectFallback(IPreserveDataLegacy pd) {

            IEnumerable<string> descriptions = pd.Xml.Nodes("//FatturaElettronicaBody/DatiBeniServizi/DettaglioLinee")      // dettagli
                .Where(detailNode => detailNode.Nodes("NumeroLinea").Any())                                                 // che abbiano un "Numero Linea"
                .SelectMany(detailNode => detailNode.Nodes("Descrizione"), (detailNode, descNode) => descNode.InnerText)    // ne prendiamo le descrizioni
                .Where(descrizione => !string.IsNullOrWhiteSpace(descrizione));                                             // che siano valorizzate

            string[] paths = {
                "//FatturaElettronicaHeader/CedentePrestatore/Anagrafica/Denominazione",
                "//FatturaElettronicaBody/DatiGenerali/DatiGeneraliDocumento/Numero"
            };

            IEnumerable<string> subjectParts = paths.Select(path => PreserveFile.getXmlText(pd.Xml, path, null))    // denominazione dell'anagrafica e numero di fattura
                .Where(xmlText => !string.IsNullOrWhiteSpace(xmlText));                                             // che siano valorizzati


            return descriptions.Any() ? descriptions :  // descrizioni dei dettagli
                subjectParts.Any() ? subjectParts :     // identificativo della fattura lato fornitore
                new string[] { "Nessun Oggetto" };      // default
        }

        /// <summary>
        /// Fornisce l'oggetto di un messaggio SDI dato un descrittore di un documento da mandare in conservazione.
        /// </summary>
        /// <param name="pd">Descrittore di un documento da mandare in conservazione.</param>
        /// <returns>Oggetto del messaggio.</returns>
        public static IEnumerable<string> MessaggioSubjectFallback(IPreserveDataLegacy pd) {

            TMessage messageType;
            IEnumerable<string> subjectParts = Enumerable.Empty<string>();

            try {

                messageType = (TMessage)Enum.Parse(typeof(TMessage), pd.IDSdiFileName.Split('_')[2].ToLower(), true);
                subjectParts = new string[] { HumanReadable.TMessages[messageType] };
            }
            catch (Exception) {

                subjectParts = !string.IsNullOrWhiteSpace(pd.IDSdiFileName) ? new string[] { pd.IDSdiFileName } : subjectParts;
            }

            return subjectParts.Any() ?
                subjectParts : 
                new string[] { "Nessun Oggetto" };
        }

        /// <summary>
        /// Determina i ruoli del documento fattura.
        /// </summary>
        /// <param name="documentType">Tipo di documento da cui estrarre i ruoli.</param>
        /// <param name="x">Documento XML da cui estrarre i ruoli.</param>
        /// <param name="ipa">Codice IPA dell'amministrazione che sta gestendo il documento.</param>
        /// <returns>Ruoli estratti.</returns>
        public static IEnumerable<Metadata.AGID.DocumentoInformatico.RuoloType> FatturaRuoloTypes(TDocument documentType, XmlDocument x, ISoggetto amministrazione /*string ipa*/) {

            var ruoloInfos = XMLUtils.ExtractRoleInfos(documentType, x, amministrazione /*ipa*/);

            var tmp = ruoloInfos.Select(roleInfo => new Metadata.AGID.DocumentoInformatico.RuoloType(roleInfo.Tipo, new Soggetto() {
                denominazione = roleInfo.Soggetto.Denominazione,
                codicefiscale = roleInfo.Soggetto.CodiceFiscale,
                partitaiva = roleInfo.Soggetto.PartitaIVA,
            }));

            return tmp;
        }

        public static IEnumerable<Metadata.AGID.DocumentoAmministrativoInformatico.RuoloType> RegistroRuoloTypes(Soggetto s) {

            List<Metadata.AGID.DocumentoAmministrativoInformatico.RuoloType> roles = new List<Metadata.AGID.DocumentoAmministrativoInformatico.RuoloType> {
                new Metadata.AGID.DocumentoAmministrativoInformatico.RuoloType(TSoggetto.Amministrazione, s),
                new Metadata.AGID.DocumentoAmministrativoInformatico.RuoloType(TSoggetto.Autore, s),
                new Metadata.AGID.DocumentoAmministrativoInformatico.RuoloType(TSoggetto.Produttore, s)
            };

            return roles;
        }
    }
}
