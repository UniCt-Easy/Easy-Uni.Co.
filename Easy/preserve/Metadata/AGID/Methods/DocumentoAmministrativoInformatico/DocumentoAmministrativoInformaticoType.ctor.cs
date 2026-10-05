using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;

using Document;

using preserve.UniStorage.Logic;

namespace preserve.Metadata.AGID.DocumentoAmministrativoInformatico {
    public partial class DocumentoAmministrativoInformaticoType {

        /// <summary>
        /// Oggetto da utilizzare per il Registro di protocollo.
        /// </summary>
        public static Func<DateTime, string> ProtocolLogSubject =
            refDate => $"Registro di protocollo del {refDate:dd-MM-yyyy}";

        /// <summary>
        /// ProtocolLogFactory per creare un Registro di protocollo.
        /// </summary>
        public static Func<PreserveData, DocumentoAmministrativoInformaticoType> ProtocolLogFactory =
            pp => new DocumentoAmministrativoInformaticoType(pp, DateTime.Now);

        /// <summary>
        /// Costruttore vuoto per serializzazione XML.
        /// </summary>
        public DocumentoAmministrativoInformaticoType() { }

        /// <summary>
        /// Istanzia un DocumentoAmministrativoInformaticoType per il Registro di protocollo.
        /// </summary>
        /// <param name="pd">Registro di protocollo.</param>
        /// <param name="dataRiferimentoRegistro">Data di riferimento del Registro di protocollo.</param>
        public DocumentoAmministrativoInformaticoType(PreserveData pd, DateTime dataRiferimentoRegistro) {

            idDocField = new IdDocType() {
                Identificativo = pd.ID,
                ImprontaCrittograficaDelDocumento = new ImprontaCrittograficaDelDocumentoType {
                    Algoritmo = "SHA-256",
                    Impronta = new SHA256Managed().ComputeHash(pd.Contents),
                },
                Segnatura = pd.Signature,
            };

            modalitaDiFormazioneField = ModalitaDiFormazioneType.generazioneoraggruppamentoancheinviaautomaticadiuninsiemedidatioregistrazioniprovenientidaunaopiùbanchedatiancheappartenentiapiùsoggettiinteroperantisecondounastrutturalogicapredeterminataememorizzatainformastatica;
            
            tipologiaDocumentaleField = HumanReadable.TDocuments[TDocument.registroProtocollo];

            datiDiRegistrazioneField = new DatiDiRegistrazioneType() {
                TipologiaDiFlusso = Mappings.ToOriginal<TipologiaDiFlussoType>(Mappings.TipologiaDiFlusso[TDocument.registroProtocollo]),
                TipoRegistro = new TipoRegistroType() {
                    Item = new ProtocolloType() {
                        CodiceRegistro = "RG",
                        DataProtocollazioneDocumento = pd.Timestamp.Date,
                        NumeroProtocolloDocumento = pd.ID,
                        OraProtocollazioneDocumento = pd.Timestamp,
                        OraProtocollazioneDocumentoSpecified = true,
                        TipoRegistro = "Giornaliero",
                    }
                }
            };

            soggettiField = Functions.RegistroRuoloTypes(pd.Owner).ToArray();

            chiaveDescrittivaField = new ChiaveDescrittivaType() {
                Oggetto = ProtocolLogSubject(dataRiferimentoRegistro),
                ParoleChiave = new string[] { "registro", "protocollo", $"{ dataRiferimentoRegistro:dd-MM-yyyy}" },
            };

            // AGGIUNGERE LA SEGNATURA COME ALLEGATO
            //AllegatiType allegatiField;

            classificazioneField = new ClassificazioneType() {
                Descrizione = "Registro di protocollo",
                IndiceDiClassificazione = $"{99999}",
                PianoDiClassificazione = $"{99999}",
            };

            riservatoField = false;

            identificativoDelFormatoField = new IdentificativoDelFormatoType() {
                Formato = Path.GetExtension(pd.Filename).TrimStart('.'),
                ProdottoSoftware = new ProdottoSoftwareType() {
                    NomeProdotto = $"{Assembly.GetExecutingAssembly().GetName().Name}",
                    Produttore = "Tempo S.r.l.",
                    VersioneProdotto = $"{Assembly.GetExecutingAssembly().GetName().Version}",
                }
            };

            verificaField = Mappings.VerificaTypes[TDocument.registroProtocollo] as VerificaType;

            //IdAggType[] aggField;
            //IdDocType idIdentificativoDocumentoPrimarioField;

            nomeDelDocumentoField = Path.GetFileName(pd.Filename);

            versioneDelDocumentoField = "v1.0";

            //TracciatureModificheDocumentoType tracciatureModificheDocumentoField;
            //string tempoDiConservazioneField;
            //string noteField;
        }
    }
}
