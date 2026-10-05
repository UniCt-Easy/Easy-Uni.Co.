using System.Collections.Generic;
using System.Xml;

using Document.IPA;

namespace Document.SDI {

    /// <summary>
    /// Funzioni di utilità per la manipolazione di documenti XML.
    /// </summary>
    public static class XMLUtils {
        public static string getXmlText(XmlDocument x, string xpath, XmlNamespaceManager ns) {
            if (ns == null) {
                try {
                    XmlNode n = x.SelectSingleNode(xpath);
                    if (n != null) {
                        return n.InnerText;
                    }
                }
                catch {
                }
                return null;
            }

            try {
                XmlNode n = x.SelectSingleNode(xpath, ns);
                if (n != null) {
                    return n.InnerText;
                }
            }
            catch {
            }
            return null;
        }

        public static string getXmlTextNso(XmlNode x, string xpath) {
            // x: <Order>
            // xpath: cac:SellerSupplierParty/cac:Party/cac:Contact/cbc:Name
            try {
                int levelFound = 0;

                string[] paths = xpath.Split('/');
                foreach (string path in paths) {
                    string[] parts = path.Split(':');
                    string part = parts.Length == 1 ? parts[0] : parts[1];
                    // part = SellerSupplierParty

                    // ChildNodes: <CustomizationID>, <ProfileID>, ..., <ns3:SellerSupplierParty>
                    foreach (XmlNode c in x.ChildNodes) {
                        string[] names = c.Name.Split(':');
                        string name = names.Length == 1 ? names[0] : names[1];

                        if (name == part) {
                            x = c;
                            levelFound++;
                            break;
                        }
                    }
                }

                if (levelFound == paths.Length) return x.InnerText;
            }
            catch { }

            return "";
        }

        public static string getP_IVACedentePrestatore(XmlDocument x) {
            XmlNode IdFiscaleIVA = x.SelectSingleNode("//FatturaElettronicaHeader/CedentePrestatore/DatiAnagrafici/IdFiscaleIVA");
            return IdFiscaleIVA["IdPaese"].InnerText + IdFiscaleIVA["IdCodice"].InnerText;
        }

        public static string getCodiceFiscaleCedentePrestatore(XmlDocument x) {
            string cf = getXmlText(x, "//FatturaElettronicaHeader/CedentePrestatore/DatiAnagrafici/CodiceFiscale", null);
            if (cf == "")
                return null;
            return cf;
        }

        /// <summary>
        /// Estrae le associazioni tra Soggetti e loro Tipi da un documento.
        /// </summary>
        /// <param name="documentType">Tipo di documento.</param>
        /// <param name="x">Documento XML.</param>
        /// <param name="amministrazione">Amministrazione mittente o destinataria relativa al documento.</param>
        /// <returns>Associazioni tra Soggetti e loro Tipi relativi al documento.</returns>
        public static IEnumerable<RuoloInfo> ExtractRoleInfos(TDocument documentType, XmlDocument x, ISoggetto amministrazione /*string ipa*/) {

            var roles = new List<RuoloInfo>();

            switch (documentType) {
                case TDocument.ordVen: {
                        string denominazione = getXmlTextNso(x, "BuyerCustomerParty/Party/PartyName/Name");

                        if (!string.IsNullOrWhiteSpace(denominazione)) {
                            roles.Add(new RuoloInfo(
                                TSoggetto.Destinatario,
                                new SDISoggetto() {
                                    Denominazione = denominazione,
                                    PartitaIVA = getP_IVACedentePrestatore(x),
                                    CodiceFiscale = getCodiceFiscaleCedentePrestatore(x),
                                }
                            ));
                        }

                        roles.Add(new RuoloInfo(TSoggetto.Mittente, amministrazione /*Soggetto.getFromEnte(ipa)*/));
                        //roles.Add(new RuoloInfo(TSoggetto.Produttore, null));
                    }
                    break;

                case TDocument.fattAcq: {
                        string denominazione = getXmlText(x, "//FatturaElettronicaHeader/CedentePrestatore/DatiAnagrafici/Anagrafica/Denominazione", null);
                        string nome = getXmlText(x, "//FatturaElettronicaHeader/CedentePrestatore/DatiAnagrafici/Anagrafica/Nome", null);
                        string cognome = getXmlText(x, "//FatturaElettronicaHeader/CedentePrestatore/DatiAnagrafici/Anagrafica/Cognome", null);

                        roles.Add(new RuoloInfo(TSoggetto.Destinatario, amministrazione /*Soggetto.getFromEnte(ipa)*/));

                        if (!string.IsNullOrWhiteSpace(denominazione)) {
                            roles.Add(new RuoloInfo(
                                TSoggetto.Mittente,
                                new SDISoggetto() {
                                    Denominazione = denominazione,
                                    PartitaIVA = getP_IVACedentePrestatore(x),
                                    CodiceFiscale = getCodiceFiscaleCedentePrestatore(x),
                                }
                            ));
                        }
                        else {
                            roles.Add(new RuoloInfo(
                                TSoggetto.Mittente,
                                new SDISoggetto() {
                                    Nome = nome,
                                    Cognome = cognome,
                                    CodiceFiscale = getCodiceFiscaleCedentePrestatore(x),
                                    PartitaIVA = getP_IVACedentePrestatore(x),
                                }
                                //new Soggetto(
                                //    nome,
                                //    cognome,
                                //    getCodiceFiscaleCedentePrestatore(x),
                                //    string.Empty
                                //)
                            ));
                        }
                    }
                    break;

                case TDocument.fattVen:
                case TDocument.fattAcquEstere: {
                        string denominazione = getXmlText(x, "//FatturaElettronicaHeader/CessionarioCommittente/DatiAnagrafici/Anagrafica/Denominazione", null);
                        string nome = getXmlText(x, "//FatturaElettronicaHeader/CessionarioCommittente/DatiAnagrafici/Anagrafica/Nome", null);
                        string cognome = getXmlText(x, "//FatturaElettronicaHeader/CessionarioCommittente/DatiAnagrafici/Anagrafica/Cognome", null);
                        string piva = getXmlText(x, "//FatturaElettronicaHeader/CessionarioCommittente/DatiAnagrafici/IdFiscaleIVA/CodiceFiscale", null);
                        string cf = getXmlText(x, "//FatturaElettronicaHeader/CessionarioCommittente/DatiAnagrafici/CodiceFiscale", null);

                        if (!string.IsNullOrWhiteSpace(denominazione)) {
                            roles.Add(new RuoloInfo(
                                TSoggetto.Destinatario,
                                new SDISoggetto() {
                                    Denominazione = denominazione,
                                    PartitaIVA = piva,
                                    CodiceFiscale = cf,
                                }));
                        }
                        else {
                            roles.Add(new RuoloInfo(
                                TSoggetto.Mittente,
                                new SDISoggetto() {
                                    Nome = nome,
                                    Cognome = cognome,
                                    CodiceFiscale = getCodiceFiscaleCedentePrestatore(x),
                                    PartitaIVA = getP_IVACedentePrestatore(x),
                                }
                                //new Soggetto(
                                //    nome,
                                //    cognome,
                                //    getCodiceFiscaleCedentePrestatore(x),
                                //    string.Empty
                                //)
                            ));
                        }

                        roles.Add(new RuoloInfo(TSoggetto.Mittente, amministrazione /*Soggetto.getFromEnte(ipa)*/));
                        //roles.Add(new RuoloInfo(TSoggetto.Produttore, null));
                    }
                    break;

                case TDocument.messOrdVen:
                case TDocument.messAcq:
                case TDocument.messVen:
                case TDocument.messAcquEstere: {
                        roles.Add(new RuoloInfo(
                            TSoggetto.Mittente,
                            new SDISoggetto() {
                                Denominazione = "Agenzia delle Entrate",
                                PartitaIVA = "06363391001",
                                CodiceFiscale = "06363391001",
                            }
                        ));

                        roles.Add(new RuoloInfo(
                            TSoggetto.Destinatario,
                            amministrazione //Soggetto.getFromEnte(ipa)
                        ));
                    }
                    break;
            }

            return roles;
        }
    }
}
