using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text.RegularExpressions;

using Document;

using preserve.UniStorage.Logic;

namespace preserve.Metadata.AGID.DocumentoInformatico {
    public partial class DocumentoInformaticoType {

        public static Func<PreserveData, DocumentoInformaticoType> Factory = pd => new DocumentoInformaticoType(pd);

        public static Func<IPreserveData, DocumentoInformaticoType> IFactory = pd => new DocumentoInformaticoType(pd);

        public DocumentoInformaticoType() { }

        public DocumentoInformaticoType(IPreserveData pd) {

            idDocField = new IdDocType() {
                Identificativo = pd.ID,
                ImprontaCrittograficaDelDocumento = new ImprontaCrittograficaDelDocumentoType() {
                    Algoritmo = "SHA-256",
                    Impronta = new SHA256Managed().ComputeHash(pd.Contents),
                }
            };

            modalitaDiFormazioneField = ModalitaDiFormazioneType.acquisizionediundocumentoinformaticoperviatelematicaosusupportoinformaticoacquisizionedellacopiaperimmaginesusupportoinformaticodiundocumentoanalogicoacquisizionedellacopiainformaticadiundocumentoanalogico;

            tipologiaDocumentaleField = HumanReadable.TDocuments[pd.Type];

            datiDiRegistrazioneField = new DatiDiRegistrazioneType() {
                TipologiaDiFlusso = Mappings.ToOriginal<TipologiaDiFlussoType>(Mappings.TipologiaDiFlusso[pd.Type]),
                TipoRegistro = new TipoRegistroType() {
                    Item = new NoProtocolloType() {
                        CodiceRegistro = "",
                        DataRegistrazioneDocumento = pd.Timestamp,
                        NumeroRegistrazioneDocumento = "",              // COMPILARE
                        OraRegistrazioneDocumento = pd.Timestamp,
                        OraRegistrazioneDocumentoSpecified = true,
                        TipoRegistro = "Nessuno",
                    }
                }
            };

            //Soggetto amministrazione = new Soggetto() {
            //    IPAAmm = pd.IDOffice,
            //};

            //string subject = "documento di test";   //Mappings.Oggetto[pd.Type].Invoke(pd);
            //string[] parts = Regex.Split(subject, @"[\s,;|:.!?_\-\/\[\](){}\""]");

            //chiaveDescrittivaField = new ChiaveDescrittivaType() {
            //    Oggetto = subject,
            //    ParoleChiave = parts
            //        .Where(part => !string.IsNullOrWhiteSpace(part) && part.Length > 1)
            //        .OrderByDescending(part => part.Length)
            //        .Take(5)
            //        .ToArray(),
            //};

            //allegatiField = new AllegatiType() { IndiceAllegati = new List<IndiceAllegatiType>().ToArray() };

            //classificazioneField = new ClassificazioneType() {
            //    Descrizione = "",
            //    IndiceDiClassificazione = "",
            //    PianoDiClassificazione = ""
            //};

            riservatoField = false;

            identificativoDelFormatoField = new IdentificativoDelFormatoType() {
                Formato = Path.GetExtension(pd.Filename),
                ProdottoSoftware = new ProdottoSoftwareType() {
                    NomeProdotto = Assembly.GetExecutingAssembly().GetName().Name,
                    Produttore = "Tempo S.r.l.",
                    VersioneProdotto = Assembly.GetExecutingAssembly().GetName().Version.ToString(),
                }
            };

            verificaField = Mappings.VerificaTypes[pd.Type] as VerificaType;

            //aggField = new List<IdAggType>().ToArray();

            //idIdentificativoDocumentoPrimarioField = new IdDocType() {
            //    Identificativo = "",
            //    ImprontaCrittograficaDelDocumento = new ImprontaCrittograficaDelDocumentoType() {
            //        Algoritmo = "",
            //        Impronta = new byte[] { 0x20, },
            //    }
            //};

            nomeDelDocumentoField = pd.Filename;

            versioneDelDocumentoField = "v1.0";

            //tracciatureModificheDocumentoField = new TracciatureModificheDocumentoType() {
            //    DataModifica = DateTime.Now,
            //    IdDocVersionePrecedente = null,
            //    OraModifica = DateTime.Now,
            //    OraModificaSpecified = true,
            //    SoggettoAutoreDellaModifica = new PFType() {
            //        CodiceFiscale = "",
            //        Cognome = "",
            //        IndirizziDigitaliDiRiferimento = new string[] { "ciao" },
            //        Nome = "",
            //    }
            //};

            tempoDiConservazioneField = "";

            noteField = "";

        }

        public DocumentoInformaticoType(IPreserveData pd, ChiaveDescrittivaType cdt) : this(pd) {

            chiaveDescrittivaField = cdt;
        }

        public DocumentoInformaticoType(PreserveData pd) {

            idDocField = new IdDocType() {
                Identificativo = pd.ID,
                ImprontaCrittograficaDelDocumento = new ImprontaCrittograficaDelDocumentoType() {
                    Algoritmo = "SHA-256",
                    Impronta = new SHA256Managed().ComputeHash(pd.Contents),
                }
            };

            modalitaDiFormazioneField = ModalitaDiFormazioneType.acquisizionediundocumentoinformaticoperviatelematicaosusupportoinformaticoacquisizionedellacopiaperimmaginesusupportoinformaticodiundocumentoanalogicoacquisizionedellacopiainformaticadiundocumentoanalogico;

            tipologiaDocumentaleField = HumanReadable.TDocuments[pd.Type];
            
            datiDiRegistrazioneField = new DatiDiRegistrazioneType() {
                TipologiaDiFlusso = Mappings.ToOriginal<TipologiaDiFlussoType>(Mappings.TipologiaDiFlusso[pd.Type]),
                TipoRegistro = new TipoRegistroType() {
                    Item = new NoProtocolloType() {
                        CodiceRegistro = "",
                        DataRegistrazioneDocumento = DateTime.Now,
                        NumeroRegistrazioneDocumento = "",              // COMPILARE
                        OraRegistrazioneDocumento = DateTime.Now,
                        OraRegistrazioneDocumentoSpecified = true,
                        TipoRegistro = "Nessuno",
                    }
                }
            };

            Soggetto amministrazione = new Soggetto() {
                IPAAmm = pd.IDOffice,
            };
            soggettiField = Functions.FatturaRuoloTypes(pd.Type, pd.Xml, amministrazione /*pd.IDOffice*/).ToArray();

            string subject = Mappings.Oggetto[pd.Type].Invoke(pd);
            string[] parts = Regex.Split(subject, @"[\s,;|:.!?_\-\/\[\](){}\""]");

            chiaveDescrittivaField = new ChiaveDescrittivaType() {
                Oggetto = subject,
                ParoleChiave = parts
                    .Where(part => !string.IsNullOrWhiteSpace(part) && part.Length > 1)
                    .OrderByDescending(part => part.Length)
                    .Take(5)
                    .ToArray(),
            };

            //allegatiField = new AllegatiType() { IndiceAllegati = new List<IndiceAllegatiType>().ToArray() };

            //classificazioneField = new ClassificazioneType() {
            //    Descrizione = "",
            //    IndiceDiClassificazione = "",
            //    PianoDiClassificazione = ""
            //};

            riservatoField = false;

            identificativoDelFormatoField = new IdentificativoDelFormatoType() {
                Formato = Path.GetExtension(pd.Filename),
                ProdottoSoftware = new ProdottoSoftwareType() {
                    NomeProdotto = Assembly.GetEntryAssembly().GetName().Name,
                    Produttore = "Tempo S.r.l.",
                    VersioneProdotto = Assembly.GetEntryAssembly().GetName().Version.ToString(),
                }
            };

            verificaField = Mappings.VerificaTypes[pd.Type] as VerificaType;

            //aggField = new List<IdAggType>().ToArray();

            //idIdentificativoDocumentoPrimarioField = new IdDocType() {
            //    Identificativo = "",
            //    ImprontaCrittograficaDelDocumento = new ImprontaCrittograficaDelDocumentoType() {
            //        Algoritmo = "",
            //        Impronta = new byte[] { 0x20, },
            //    }
            //};

            nomeDelDocumentoField = pd.Filename;

            versioneDelDocumentoField = "v1.0";

            //tracciatureModificheDocumentoField = new TracciatureModificheDocumentoType() {
            //    DataModifica = DateTime.Now,
            //    IdDocVersionePrecedente = null,
            //    OraModifica = DateTime.Now,
            //    OraModificaSpecified = true,
            //    SoggettoAutoreDellaModifica = new PFType() {
            //        CodiceFiscale = "",
            //        Cognome = "",
            //        IndirizziDigitaliDiRiferimento = new string[] { "ciao" },
            //        Nome = "",
            //    }
            //};

            tempoDiConservazioneField = "";

            noteField = "";
        
        }
    }
}
