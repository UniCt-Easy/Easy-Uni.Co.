
/*
Easy
Copyright (C) 2021 Università degli Studi di Catania (www.unict.it)
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
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.ServiceModel;
using System.Xml.Serialization;

namespace TesseraSanitaria {

    [ServiceContract(Name = "DocumentoSpesa730pPort", Namespace = "http://documentospesap730.sanita.finanze.it", ConfigurationName = "DocumentoSpesa730pPort")]
    public interface IServizio {

        [OperationContract(Action = "inserimento.documentospesap730.sanita.finanze.it", ReplyAction = "*")]
        [XmlSerializerFormat]
        InserimentoResponse Inserimento(InserimentoRequest request);

        [OperationContract(Action = "variazione.documentospesap730.sanita.finanze.it", ReplyAction = "*")]
        [XmlSerializerFormat]
        VariazioneResponse Variazione(VariazioneRequest request);

        [OperationContract(Action = "rimborso.documentospesap730.sanita.finanze.it", ReplyAction = "*")]
        [XmlSerializerFormat]
        RimborsoResponse Rimborso(RimborsoRequest request);

        [OperationContract(Action = "cancellazione.documentospesap730.sanita.finanze.it", ReplyAction = "*")]
        [XmlSerializerFormat]
        CancellazioneResponse Cancellazione(CancellazioneRequest request);

    }

    public static class Servizio {

        //private static readonly string URL = "https://invioss730p.sanita.finanze.it/enti/DocumentoSpesa730pWeb/DocumentoSpesa730pPort";
        private static readonly string URL = "https://invioss730ptest.sanita.finanze.it/enti/DocumentoSpesa730pWeb/DocumentoSpesa730pPort"; // solo per test
        private static readonly string THUMBPRINT = "";

        public static IServizio Create(out string errore) {
            try {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls11;

                var binding = new BasicHttpBinding(BasicHttpSecurityMode.Transport);
                binding.Security.Transport.ClientCredentialType = HttpClientCredentialType.Certificate;

                var address = new EndpointAddress(URL);

                var factory = new ChannelFactory<IServizio>(binding, address);
                factory.Credentials.ClientCertificate.SetCertificate(
                    StoreLocation.CurrentUser,
                    StoreName.My,
                    X509FindType.FindByThumbprint,
                    THUMBPRINT
                );

                errore = null;
                return factory.CreateChannel();
            }
            catch (Exception ex) {
                errore = ex.Message;
                return null;
            }
        }

    }

    #region "Messaggi SOAP"

    [MessageContract(IsWrapped = false)]
    public class InserimentoRequest {

        [MessageBodyMember(Name = "inserimentoDocumentoSpesaRequest", Namespace = "http://documentospesap730.sanita.finanze.it", Order = 0)]
        public InserimentoRequestBody body;

        public InserimentoRequest() { }

        public InserimentoRequest(InserimentoRequestBody body) {
            this.body = body;
        }

    }

    [MessageContract(IsWrapped = false)]
    public class InserimentoResponse {

        [MessageBodyMember(Name = "inserimentoDocumentoSpesaResponse", Namespace = "http://documentospesap730.sanita.finanze.it", Order = 0)]
        public ResponseBody body;

        public InserimentoResponse() { }

        public InserimentoResponse(ResponseBody body) {
            this.body = body;
        }

    }

    [MessageContract(IsWrapped = false)]
    public class VariazioneRequest {

        [MessageBodyMember(Name = "variazioneDocumentoSpesaRequest", Namespace = "http://documentospesap730.sanita.finanze.it", Order = 0)]
        public VariazioneRequestBody body;

        public VariazioneRequest() { }

        public VariazioneRequest(VariazioneRequestBody body) {
            this.body = body;
        }

    }

    [MessageContract(IsWrapped = false)]
    public class VariazioneResponse {

        [MessageBodyMember(Name = "variazioneDocumentoSpesaResponse", Namespace = "http://documentospesap730.sanita.finanze.it", Order = 0)]
        public ResponseBody body;

        public VariazioneResponse() { }

        public VariazioneResponse(ResponseBody body) {
            this.body = body;
        }

    }

    [MessageContract(IsWrapped = false)]
    public class RimborsoRequest {

        [MessageBodyMember(Name = "rimborsoDocumentoSpesaRequest", Namespace = "http://documentospesap730.sanita.finanze.it", Order = 0)]
        public RimborsoRequestBody body;

        public RimborsoRequest() { }

        public RimborsoRequest(RimborsoRequestBody body) {
            this.body = body;
        }

    }

    [MessageContract(IsWrapped = false)]
    public class RimborsoResponse {

        [MessageBodyMember(Name = "rimborsoDocumentoSpesaResponse", Namespace = "http://documentospesap730.sanita.finanze.it", Order = 0)]
        public ResponseBody body;

        public RimborsoResponse() { }

        public RimborsoResponse(ResponseBody body) {
            this.body = body;
        }

    }

    [MessageContract(IsWrapped = false)]
    public class CancellazioneRequest {

        [MessageBodyMember(Name = "cancellazioneDocumentoSpesaRequest", Namespace = "http://documentospesap730.sanita.finanze.it", Order = 0)]
        public CancellazioneRequestBody body;

        public CancellazioneRequest() { }

        public CancellazioneRequest(CancellazioneRequestBody body) {
            this.body = body;
        }

    }

    [MessageContract(IsWrapped = false)]
    public class CancellazioneResponse {

        [MessageBodyMember(Name = "cancellazioneDocumentoSpesaResponse", Namespace = "http://documentospesap730.sanita.finanze.it", Order = 0)]
        public ResponseBody body;

        public CancellazioneResponse() { }

        public CancellazioneResponse(ResponseBody body) {
            this.body = body;
        }

    }

    #endregion

    #region "Strutture dati (messaggi SOAP)"

    [Serializable]
    [XmlType(AnonymousType = true, Namespace = "http://documentospesap730.sanita.finanze.it")]
    public enum EsitoChiamata {

        [XmlEnum("0")]
        Completata,

        [XmlEnum("1")]
        Fallita

    }

    [Serializable]
    [XmlType(AnonymousType = true, Namespace = "http://documentospesap730.sanita.finanze.it")]
    public enum TipoMessaggio {

        /// <summary>
        /// Statistica.
        /// </summary>
        [XmlEnum("S")]
        Statistica = 0,

        /// <summary>
        /// Segnalazione.
        /// </summary>
        [XmlEnum("W")]
        Avviso = 1,

        /// <summary>
        /// Errore scartante.
        /// </summary>
        [XmlEnum("E")]
        Errore = 2

    }

    [Serializable]
    [XmlType(AnonymousType = true, Namespace = "http://documentospesap730.sanita.finanze.it")]
    public class Messaggio {

        /// <summary>
        /// Codice della chiamata al servizio.
        /// </summary>
        [XmlElement("codice", Order = 0)]
        public string Codice { get; set; }

        /// <summary>
        /// Descrizione della chiamata al servizio.
        /// </summary>
        [XmlElement("descrizione", Order = 1)]
        public string Descrizione { get; set; }

        /// <summary>
        /// Tipo di messaggio.
        /// </summary>
        [XmlElement("tipo", Order = 2)]
        public TipoMessaggio Tipo { get; set; }

    }

    [Serializable]
    [XmlType(Namespace = "http://documentospesap730.sanita.finanze.it")]
    public class ResponseBody {

        /// <summary>
        /// Esito di invocazione del servizio.
        /// </summary>
        [XmlElement("esitoChiamata", Order = 0)]
        public EsitoChiamata Esito { get; set; }

        /// <summary>
        /// Identificativo univoco dell'operazione effettuata.
        /// </summary>
        /// <remarks>
        /// Valorizzato solo se l'operazione è stata effettuata con successo.
        /// </remarks>
        [XmlElement("protocollo", Order = 1)]
        public string Protocollo { get; set; }

        /// <summary>
        /// Messaggi d'errore.
        /// </summary>
        /// <remarks>
        /// Valorizzato solo se l'operazione è fallita.
        /// </remarks>
        [XmlArray(Order = 2)]
        [XmlArrayItem("messaggio", IsNullable = false)]
        public List<Messaggio> Messaggi { get; set; }

    }

    [Serializable]
    [XmlType(Namespace = "http://documentospesap730.sanita.finanze.it")]
    public class InserimentoRequestBody {

        /// <summary>
        /// Codice identificativo o credenziali Entratel.
        /// </summary>
        [XmlElement("opzionale1", Order = 0)]
        public string Opzionale1 { get; set; }

        /// <summary>
        /// Non utilizzato.
        /// </summary>
        [XmlElement("opzionale2", Order = 1)]
        public string Opzionale2 { get; set; }

        /// <summary>
        /// Non utilizzato.
        /// </summary>
        [XmlElement("opzionale3", Order = 2)]
        public string Opzionale3 { get; set; }

        /// <summary>
        /// Codice pin.
        /// </summary>
        [XmlElement("pincode", Order = 3)]
        public string PinCode { get; set; }

        /// <summary>
        /// Dati del proprietario.
        /// </summary>
        [XmlElement("Proprietario", Order = 4)]
        public Proprietario Proprietario { get; set; }

        /// <summary>
        /// Documento fiscale da inserire.
        /// </summary>
        [XmlElement("idInserimentoDocumentoFiscale", Order = 5)]
        public DocumentoSpesa DocumentoSpesa { get; set; }

    }

    [Serializable]
    [XmlType(Namespace = "http://documentospesap730.sanita.finanze.it")]
    public class VariazioneRequestBody {

        /// <summary>
        /// Non utilizzato.
        /// </summary>
        [XmlElement("opzionale1", Order = 0)]
        public string Opzionale1 { get; set; }

        /// <summary>
        /// Non utilizzato.
        /// </summary>
        [XmlElement("opzionale2", Order = 1)]
        public string Opzionale2 { get; set; }

        /// <summary>
        /// Non utilizzato.
        /// </summary>
        [XmlElement("opzionale3", Order = 2)]
        public string Opzionale3 { get; set; }

        /// <summary>
        /// Codice pin.
        /// </summary>
        [XmlElement("pincode", Order = 3)]
        public string PinCode { get; set; }

        /// <summary>
        /// Dati del proprietario.
        /// </summary>
        [XmlElement("Proprietario", Order = 4)]
        public Proprietario Proprietario { get; set; }

        /// <summary>
        /// Documento fiscale da modificare.
        /// </summary>
        [XmlElement("idVariazioneDocumentoFiscale", Order = 5)]
        public DocumentoSpesa DocumentoSpesa { get; set; }

    }

    [Serializable]
    [XmlType(Namespace = "http://documentospesap730.sanita.finanze.it")]
    public class RimborsoRequestBody {

        /// <summary>
        /// Non utilizzato.
        /// </summary>
        [XmlElement("opzionale1", Order = 0)]
        public string Opzionale1 { get; set; }

        /// <summary>
        /// Non utilizzato.
        /// </summary>
        [XmlElement("opzionale2", Order = 1)]
        public string Opzionale2 { get; set; }

        /// <summary>
        /// Non utilizzato.
        /// </summary>
        [XmlElement("opzionale3", Order = 2)]
        public string Opzionale3 { get; set; }

        /// <summary>
        /// Codice pin.
        /// </summary>
        [XmlElement("pincode", Order = 3)]
        public string PinCode { get; set; }

        /// <summary>
        /// Dati del proprietario.
        /// </summary>
        [XmlElement("Proprietario", Order = 4)]
        public Proprietario Proprietario { get; set; }

        /// <summary>
        /// Documento fiscale da rimborsare.
        /// </summary>
        [XmlElement("idRimborsoDocumentoFiscale", Order = 5)]
        public DocumentoFiscale DocumentoFiscale { get; set; }

        /// <summary>
        /// Documento fiscale del rimborso.
        /// </summary>
        [XmlElement("DocumentoSpesa", Order = 6)]
        public DocumentoSpesa DocumentoSpesa { get; set; }

    }

    [Serializable]
    [XmlType(Namespace = "http://documentospesap730.sanita.finanze.it")]
    public class CancellazioneRequestBody {

        /// <summary>
        /// Non utilizzato.
        /// </summary>
        [XmlElement("opzionale1", Order = 0)]
        public string Opzionale1 { get; set; }

        /// <summary>
        /// Non utilizzato.
        /// </summary>
        [XmlElement("opzionale2", Order = 1)]
        public string Opzionale2 { get; set; }

        /// <summary>
        /// Non utilizzato.
        /// </summary>
        [XmlElement("opzionale3", Order = 2)]
        public string Opzionale3 { get; set; }

        /// <summary>
        /// Codice pin.
        /// </summary>
        [XmlElement("pincode", Order = 3)]
        public string PinCode { get; set; }

        /// <summary>
        /// Dati del proprietario.
        /// </summary>
        [XmlElement("Proprietario", Order = 4)]
        public Proprietario Proprietario { get; set; }

        /// <summary>
        /// Documento fiscale da cancellare.
        /// </summary>
        [XmlElement("idCancellazioneDocumentoFiscale", Order = 5)]
        public DocumentoFiscale DocumentoFiscale { get; set; }

    }

    #endregion

    #region "Strutture dati"

    [Serializable]
    [XmlType(Namespace = "http://documentospesap730.sanita.finanze.it")]
    public class Proprietario {

        /// <summary>
        /// Codice regione.
        /// </summary>
        /// <remarks>
        /// Codice regione della farmacia/struttura che emette il documento fiscale.
        /// </remarks>
        [XmlElement("codiceRegione", Order = 0)]
        public string CodiceRegione { get; set; }

        /// <summary>
        /// Codice ASL.
        /// </summary>
        /// <remarks>
        /// Codice della ASL della farmacia/struttura che emette il documento fiscale.
        /// </remarks>
        [XmlElement("codiceAsl", Order = 1)]
        public string CodiceASL { get; set; }

        /// <summary>
        /// Codice struttura.
        /// </summary>
        /// <remarks>
        /// Codice farmacia/struttura che emette il documento fiscale.
        /// </remarks>
        [XmlElement("codiceSSA", Order = 2)]
        public string CodiceSSA { get; set; }

        /// <summary>
        /// Codice fiscale del proprietario.
        /// </summary>
        /// <remarks>
        /// Codice fiscale del soggetto indicato come titolare/direttore della struttura/farmacia
        /// o responsabile all'invio dei dati al sistema "tessera sanitaria".
        /// </remarks>
        [XmlElement("cfProprietario", Order = 3)]
        public string CodiceFiscale { get; set; }

    }

    [Serializable]
    [XmlType(AnonymousType = true, Namespace = "http://documentospesap730.sanita.finanze.it")]
    public class NumeroDocumentoFiscale {

        /// <summary>
        /// Numero progressivo del dispositivo che genera il documento.
        /// </summary>
        /// <remarks>
        /// Numero del registratore di cassa utilizzato dalla farmacia.
        /// Per l'emissione di fatture o ricevute fiscali il campo assume valore 1.
        /// </remarks>
        [XmlElement("dispositivo", Order = 0)]
        public int Dispositivo { get; set; }

        /// <summary>
        /// Numero identificativo del documento emesso.
        /// </summary>
        /// <remarks>
        /// Il codice dev'essere univoco nell'ambito della data.
        /// Solitamente è univoco per giornata (scontrini) oppure per anno (fattura).
        /// </remarks>
        [XmlElement("numDocumento", Order = 1)]
        public string NumeroDocumento { get; set; }

    }

    [Serializable]
    [XmlType(Namespace = "http://documentospesap730.sanita.finanze.it")]
    public class DocumentoFiscale {

        /// <summary>
        /// Partita IVA della farmacia/struttura o medico che emette il documento fiscale.
        /// </summary>
        [XmlElement("pIva", DataType = "integer", Order = 0)]
        public string PartitaIVA { get; set; }

        /// <summary>
        /// Data di emissione del documento fiscale relativo alla spesa sostenuta dal cittadino.
        /// </summary>
        [XmlElement("dataEmissione", DataType = "date", Order = 1)]
        public DateTime DataEmissione { get; set; }

        /// <summary>
        /// Estremi del documento fiscale.
        /// </summary>
        [XmlElement("numDocumentoFiscale", Order = 2)]
        public NumeroDocumentoFiscale NumeroDocumentoFiscale { get; set; }

    }

    [Serializable]
    [XmlType(AnonymousType = true, Namespace = "http://documentospesap730.sanita.finanze.it")]
    public class VoceSpesa {

        /// <summary>
        /// Tipologia di spesa.
        /// </summary>
        [XmlElement("tipoSpesa", Order = 0)]
        public TipoSpesa TipoSpesa { get; set; }

        /// <summary>
        /// Dettaglio tipologia di spesa.
        /// </summary>
        [XmlElement("flagTipoSpesa", Order = 1)]
        public FlagTipoSpesa? FlagTipoSpesa { get; set; }

        /// <summary>
        /// Importo della singola spesa sostenuta o del rimborso riconosciuto al cittadino.
        /// </summary>
        /// <remarks>
        /// Il campo deve assumere sempre valori positivi, anche in caso di rimborso.
        /// </remarks>
        [XmlElement("importo", Order = 2)]
        public double Importo { get; set; }

    }

    [Serializable]
    [XmlType(AnonymousType = true, Namespace = "http://documentospesap730.sanita.finanze.it")]
    public enum TipoSpesa {

        /// <summary>
        /// Ticket. Quota fissa e/o differenza con il prezzo di riferimento.
        /// Franchigia. Pronto Soccorso e accesso diretto.
        /// </summary>
        [XmlEnum("TK")]
        Ticket,

        /// <summary>
        /// Farmaco, anche omeopatico. Dispositivi medici CE.
        /// </summary>
        [XmlEnum("FC")]
        Farmaco,

        /// <summary>
        /// Farmaco per uso veterinario.
        /// </summary>
        [XmlEnum("FV")]
        FarmacoVeterinario,

        /// <summary>
        /// Acquisto o noleggio di un dispositivo medico CE.
        /// </summary>
        [XmlEnum("AD")]
        DispositivoMedico,

        /// <summary>
        /// Spese sanitarie relative ad ECG, spirometria, Holter pressorio e cardiaco,
        /// test per la glicemia, colesterolo e trigliceridi o misurazione della pressione sanguigna,
        /// prestazioni previste dalla farmacia dei servizi e simili sangugna.
        /// </summary>
        [XmlEnum("AS")]
        Servizi,

        /// <summary>
        /// Spese prestazioni assistenza specialistica ambulatoriale esclusi interventi di chirurgia esterica.
        /// Visita medica generica e specialistica o prestazioni diagnostiche e strumentali.
        /// Prestazione chirurgica ad esclusione della chirurgia estetica.
        /// Ricorveri ospedalieri, al netto del comfort. Certificazione medica.
        /// </summary>
        [XmlEnum("SR")]
        AssistenzaSpecialistica,

        /// <summary>
        /// Cure termali.
        /// </summary>
        [XmlEnum("CT")]
        CureTermali,

        /// <summary>
        /// Protesica ed integrativa.
        /// </summary>
        [XmlEnum("PI")]
        ProtesicaIntegrativa,

        /// <summary>
        /// Intervento di chirurgia estetica ambulatoriale o ospedaliero.
        /// </summary>
        [XmlEnum("IC")]
        ChirurgiaEstetica,

        /// <summary>
        /// Altre spese.
        /// </summary>
        [XmlEnum("AA")]
        Altro

    }

    [Serializable]
    [XmlType(AnonymousType = true, Namespace = "http://documentospesap730.sanita.finanze.it")]
    public enum FlagTipoSpesa {

        /// <summary>
        /// Ticket di pronto soccorso.
        /// </summary>
        /// <remarks>
        /// Specifico in caso <see cref="VoceSpesa.TipoSpesa"/> = <see cref="TipoSpesa.Ticket"/>.
        /// </remarks>
        [XmlEnum("1")]
        ProntoSoccorso,

        /// <summary>
        /// Visita in intramoenia.
        /// </summary>
        /// <remarks>
        /// Specifico in caso <see cref="VoceSpesa.TipoSpesa"/> = <see cref="TipoSpesa.AssistenzaSpecialistica"/>.
        /// </remarks>
        [XmlEnum("2")]
        Intramoenia

    }

    [Serializable]
    [XmlType(Namespace = "http://documentospesap730.sanita.finanze.it")]
    public class DocumentoSpesa {

        /// <summary>
        /// Estremi del documento fiscale emesso.
        /// </summary>
        [XmlElement("idSpesa", Order = 0)]
        public DocumentoFiscale DocumentoFiscale { get; set; }

        /// <summary>
        /// Data di pagamento afferente al documento fiscale emesso.
        /// </summary>
        [XmlElement("dataPagamento", DataType = "date", Order = 1)]
        public DateTime DataPagamento { get; set; }

        /// <summary>
        /// Indica che la spesa è stat sostenuta dal cittadino in data antecedente
        /// alla data di emissione del documento fiscale.
        /// </summary>
        [XmlElement("flagPagamentoAnticipato", Order = 2)]
        public int PagamentoAnticipato { get; set; }

        [XmlIgnore]
        public bool PagamentoAnticipatoSpecified {
            get {
                return PagamentoAnticipato.Equals(1);
            }
        }

        /// <summary>
        /// Codice fiscale del cittadino, rilevato dalla tessera sanitaria.
        /// </summary>
        [XmlElement("cfCittadino", Order = 3)]
        public string CodiceFiscale { get; set; }

        /// <summary>
        /// Lista delle spese sostenute dal cittadino.
        /// </summary>
        [XmlElement("voceSpesa", Order = 4)]
        public List<VoceSpesa> Spesa { get; set; }

    }

    #endregion

}
