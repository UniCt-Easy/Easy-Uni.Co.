
/*
Easy
Copyright (C) 2022 Università degli Studi di Catania (www.unict.it)
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
using System.IO;
using System.Linq.Expressions;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.ServiceModel;
using System.Xml.Schema;
using System.Xml.Serialization;
using pagoPaService.bsondrio1_1;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using genericSerializer;
using XmlFormatter;
using System.Xml;
using System.ServiceModel.Channels;
using System.Text;
using System.Linq;

namespace BancaSondrio {
    public class InspectorBehavior : IEndpointBehavior {
        public string LastRequestXML {
            get { return myMessageInspector.LastRequestXML; }
        }

        public string LastResponseXML {
            get { return myMessageInspector.LastResponseXML; }
        }


        private MyMessageInspector myMessageInspector = new MyMessageInspector();

        public void AddBindingParameters(ServiceEndpoint endpoint,
            System.ServiceModel.Channels.BindingParameterCollection bindingParameters) {

        }

        public void ApplyDispatchBehavior(ServiceEndpoint endpoint, EndpointDispatcher endpointDispatcher) {

        }

        public void Validate(ServiceEndpoint endpoint) {

        }


        public void ApplyClientBehavior(ServiceEndpoint endpoint, ClientRuntime clientRuntime) {
            clientRuntime.MessageInspectors.Add(myMessageInspector);
        }
    }





    public class MyMessageInspector : IClientMessageInspector
    {
        public string LastRequestXML { get; private set; }
        public string LastResponseXML { get; private set; }
        public void AfterReceiveReply(ref System.ServiceModel.Channels.Message reply, object correlationState)
        {
            LastResponseXML = reply.ToString();
        }
        
        void cascadeDeleteEmptyAttribute(XmlNode x) {
            if (x.Attributes != null) {
                XmlAttribute n = x.Attributes.GetNamedItem("xmlns") as XmlAttribute;
                if (n != null) {
                    if (n.Value == "") {
                        x.Attributes.Remove(n);
                        x.ParentNode.ReplaceChild(x, x);
                    }
                }
            }

            var cc = (from XmlNode c in x.ChildNodes select c).ToArray();
            foreach (XmlNode c in cc) {
                cascadeDeleteEmptyAttribute(c);
                x.ReplaceChild(c, c);
            }

        }

        void processRequest(ref Message request) {
           
            MessageBuffer buffer = request.CreateBufferedCopy(Int32.MaxValue);
            request = buffer.CreateMessage();

            var xmlDocument = new XmlDocument();
            var memoryStream = new MemoryStream();
            var xmlWriter = XmlWriter.Create(memoryStream);

            // Write the xml request message into the memory stream
            request.WriteMessage(xmlWriter);

            // Clear the xmlWriter
            xmlWriter.Flush();
            // Place the pointer in the memoryStream to the beginning 
            memoryStream.Position = 0;

            // Load the memory stream into the xmlDocument
            xmlDocument.Load(memoryStream);
            //string s = xmlDocument.InnerXml;
            // Remove the attributes from the second node down form the top

            cascadeDeleteEmptyAttribute(xmlDocument.ChildNodes[1]);
            xmlDocument.ReplaceChild(xmlDocument.ChildNodes[1], xmlDocument.ChildNodes[1]);
            
            string s2 = xmlDocument.toXml();
            //s2 = s2.Replace(" xmlns=\"\"", "");
            //s2 = s2.Replace("iuv:testata", "testata");
            //s2 = s2.Replace("iuv:IUVOnlineCreateRequestData", "IUVOnlineCreateRequestData");

            // Reset the memoryStream object - essentially nulls it out
            memoryStream.SetLength(0);
            var b = UTF8Encoding.UTF8.GetBytes(s2);
            memoryStream.Write(b,0,b.Length);
            
            //// ReInitialize the xmlWriter
            //xmlWriter = XmlWriter.Create(memoryStream);

            //// Write the modified xml request message (xmlDocument) to the memoryStream in the xmlWriter
            //xmlDocument.WriteTo(xmlWriter);

            //// Clear the xmlWriter
            xmlWriter.Flush();

            // Place the pointer in the memoryStream to the beginning 
            memoryStream.Position = 0;
            // Create a new xmlReader with the memoryStream that contains the xmlDocument
            var xmlReader = XmlReader.Create(memoryStream);

            // Create a new request message with the modified xmlDocument
            var request2 = Message.CreateMessage(xmlReader, int.MaxValue, request.Version);
            //request2.Headers.CopyHeadersFrom(request);
            
         
            buffer = request2.CreateBufferedCopy(Int32.MaxValue);
            request = buffer.CreateMessage();
            LastRequestXML = Encoding.UTF8.GetString(memoryStream.ToArray());
            
        }

        
        public object BeforeSendRequest(ref System.ServiceModel.Channels.Message request, System.ServiceModel.IClientChannel channel)
        {
            LastRequestXML = request.ToString();
            int headerIndexOfAction = request.Headers.FindHeader("Action","http://schemas.microsoft.com/ws/2005/05/addressing/none");
            if (headerIndexOfAction>=0)     request.Headers.RemoveAt(headerIndexOfAction);
            processRequest(ref request);
            return request;
        }
    }

    //http://scrittura.iuvonline.nodospcit.ws.popso.it/v1
    //http://scrittura.iuvonline.nodospcit.ws.popso.it/v1
    //[ServiceContract(Namespace = "http://scrittura.iuvonline.nodospcit.ws.popso.it/v1", ConfigurationName = "IService2")]
    //  [ServiceContract(Namespace = "http://easybridge.eu/bridge/", ConfigurationName = "IService2", Name = "WEBS_DataProviderInterfacePort")]
    // http://localhost/IUVOnlineService_v1/scrittura/IUVOnlineService.ws
    //http://schema.iuvonline.nodospcit.ws.popso.it/v1
    // http://scrittura.iuvonline.nodospcit.ws.popso.it/v1/IUVOnlineCreate      http://schema.iuvonline.nodospcit.ws.popso.it/v1


    [ServiceContract(Namespace="http://schema.iuvonline.nodospcit.ws.popso.it/v1", ConfigurationName="bancasondrio1_1.IUVOnlineServiceScritturaPortType_v1")]
    [XmlSerializerFormat(SupportFaults=true)]
    public interface IServizio1_1 {
        [OperationContract(Name = "IUVOnlineCreateRequest", Action = "http://scrittura.iuvonline.nodospcit.ws.popso.it/v1/IUVOnlineCreate",  ReplyAction = "*")]
        [FaultContract(typeof(ApplicationFault), Action="http://scrittura.iuvonline.nodospcit.ws.popso.it/v1/IUVOnlineCreate", Name="applicationFault", Namespace="http://schema.fault.testata.common.ws.popso.it/v8")]
        [FaultContract(typeof(SystemFault), Action="http://scrittura.iuvonline.nodospcit.ws.popso.it/v1/IUVOnlineCreate", Name="systemFault", Namespace="http://schema.fault.testata.common.ws.popso.it/v8")]
        [FaultContract(typeof(DatiTestataFault), Action="http://scrittura.iuvonline.nodospcit.ws.popso.it/v1/IUVOnlineCreate", Name="datiTestataFault", Namespace="http://schema.fault.testata.common.ws.popso.it/v8")]
        [FaultContract(typeof(InputFault), Action="http://scrittura.iuvonline.nodospcit.ws.popso.it/v1/IUVOnlineCreate", Name="inputFault", Namespace="http://schema.fault.testata.common.ws.popso.it/v8")]
        [FaultContract(typeof(ServizioNonDisponibileFault), Action="http://scrittura.iuvonline.nodospcit.ws.popso.it/v1/IUVOnlineCreate", Name="servizioNonDisponibileFault", Namespace="http://schema.fault.testata.common.ws.popso.it/v8")]
        [XmlSerializerFormat(SupportFaults=true)]
        [XmlFormatter.EnvelopeNamespaces(EnvelopeNamespaces = new string[] {
            "xsi:http://www.w3.org/2001/XMLSchema-instance",
            "xsd:http://www.w3.org/2001/XMLSchema"
            ,"iuv:http://schema.iuvonline.nodospcit.ws.popso.it/v1"
        })]
        IUVOnlineCreateResponse1 IUVOnlineCreate(IUVOnlineCreateRequest1 request);

    }

 
    /// <summary>
    /// Classe utilizzata per la creazione del canale di comunicazione con WebService di Banca Popolare di Sondrio
    /// </summary>
    public static class Servizio1_1 {

        public static InspectorBehavior ispettore;

        private static readonly string URL = "https://wsdev.popso.it:18003/IUVOnlineService_v1/scrittura/IUVOnlineService.ws";
        private static readonly string THUMBPRINT = "46 7f 06 bb f8 18 b4 6b 2f 48 bf e8 41 fc 12 e9 8d 81 f9 a2";

        public static IServizio1_1 Create(string url,string thumb) {
            //ServicePointManager.SecurityProtocol =SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            ServicePointManager.CheckCertificateRevocationList = false;                      
            String rootCAThumbprint =
                "67BC2F778867F73D887A69018FF3CC108AD5C465"; // write your code to get your CA's thumbprint

              //ServicePointManager.ServerCertificateValidationCallback +=
              //  (sender, certificate, myChain, sslPolicyErrors) => {
                    
              //          // CN=[DESARROLLO] Global Chambersign Root - 2008, O=AC Camerfirma S.A.,...
              //      // remove this line if commercial CAs are not allowed to issue certificate for your service.
              //      if ((sslPolicyErrors & (SslPolicyErrors.None)) > 0) {
              //          return true;
              //      }

              //      if (
              //          (sslPolicyErrors & (SslPolicyErrors.RemoteCertificateNameMismatch)) > 0 ||
              //          (sslPolicyErrors & (SslPolicyErrors.RemoteCertificateNotAvailable)) > 0
              //      ) {
              //          return false;
              //      }

              //      return true;
              //      // get last chain element that should contain root CA certificate
              //      // but this may not be the case in partial chains
              //      //X509Certificate2 projectedRootCert = myChain.ChainElements[myChain.ChainElements.Count - 1].Certificate;
              //      //if (projectedRootCert.Thumbprint != rootCAThumbprint) {
              //      //    return false;
              //      //}

              //      //X509Certificate2 firstRootCert = chain.ChainElements[0].Certificate;
              //      //if (firstRootCert.Thumbprint != "3ED8765D55F336BC43F08E0DECD9573C64866049") {//"CN=solutionpa-coll.intesasanpaolo.com, O=Intesa Sanpaolo S.p.A. - Test SSL, S=Italia, C=IT"
              //      //    return false;
              //      //}

              //      // execute certificate chaining engine and ignore only "UntrustedRoot" error
              //      //X509Chain customChain = new X509Chain {
              //      //    ChainPolicy = {
              //      //        VerificationFlags = X509VerificationFlags.AllFlags
              //      //    }
              //      //};
              //      //Boolean retValue = customChain.Build(chain.ChainElements[0].Certificate);
              //      //// RELEASE unmanaged resources behind X509Chain class.
              //      //customChain.Reset();
              //      //return true;

              //      //return sslPolicyErrors == SslPolicyErrors.None;
              //  };

            url = url ?? URL;
            thumb = thumb ?? THUMBPRINT;
            var binding = new BasicHttpBinding(BasicHttpSecurityMode.Transport);
            binding.Security.Transport.ClientCredentialType = HttpClientCredentialType.Certificate;

            var address = new EndpointAddress(url);
            
            // EndpointAddress adress = new EndpointAddress(URL);

            var factory = new ChannelFactory<IServizio1_1>(binding, address);
            factory.Endpoint.Behaviors.Add(new CleanNameSpacesBehavior("xsi","xsd","iuv"));//"xsi", "xsd","xsd1"

            ispettore = ispettore?? new InspectorBehavior();
           

            if (url.Contains("wsdev")) {
               
                //in test:d34e1f8c01a911110145142dbb8fb32358b8a725

                //2019 "f158cb0b33b0ea1d219d192862086ff6730b2c9b".ToUpperInvariant()

                factory.Credentials.ServiceCertificate.DefaultCertificate = pagoPaService.PagoPaService.getCertificateByThumbPrint(StoreName.My, StoreLocation.CurrentUser, "d34e1f8c01a911110145142dbb8fb32358b8a725");
                factory.Credentials.ClientCertificate.Certificate = pagoPaService.PagoPaService.getCertificateByThumbPrint(StoreName.My, StoreLocation.CurrentUser,
                    "C36663D47D8C70B2B9D40BA9174529DDD23A952A");
            }
            else {
                // po2018_intermedio_bsondrio; 1fb86b1168ec743154062e8c9cc5b171a4b7ccb4
                string currCert;
                if (DateTime.Now.CompareTo(new DateTime(2019, 1, 14,11,0,0)) >= 0) {
	                currCert = "1fb86b1168ec743154062e8c9cc5b171a4b7ccb4".ToUpperInvariant();
                }
                else {
	                currCert = "1FB86B1168EC743154062E8C9CC5B171A4B7CCB4";
                }

                factory.Credentials.ServiceCertificate.DefaultCertificate = pagoPaService.PagoPaService.getCertificateByThumbPrint(StoreName.My, StoreLocation.CurrentUser, currCert);
                factory.Credentials.ClientCertificate.Certificate = pagoPaService.PagoPaService.getCertificateByThumbPrint(StoreName.My, StoreLocation.CurrentUser,thumb);
            }
            // C36663D47D8C70B2B9D40BA9174529DDD23A952A certificato fpx;   3EB5D4157096C386F9F9EBB90F0B166EE38849D6


            return factory.CreateChannel();
        }

        public static string searchCertificateByThumb(StoreName storeName, StoreLocation storeLocation, string thumb) {
            X509Store store = new X509Store(storeName, storeLocation);
            store.Open(OpenFlags.ReadOnly);

            var certificates = store.Certificates.Find(
                X509FindType.FindByThumbprint, //
                thumb, 
                false);
            store.Close();
           

            if (certificates.Count > 1) {
                X509Store store2 = new X509Store(storeName, storeLocation);
                store2.Open(OpenFlags.ReadWrite);

                certificates = store2.Certificates.Find(
                    X509FindType.FindByThumbprint, 
                    thumb, 
                    false);

                foreach(var c in certificates)store2.Remove(c);
                store2.Close();
                return null;
            }

            if (certificates.Count == 0) return null;
            return certificates[0].Thumbprint;
        }

    }

    [ServiceContract(Namespace = "http://IUVOnlineService/IuvOnlineOldService_v1", ConfigurationName = "IService3")]
    public interface IServizio {

        [OperationContract(Name = "pagamento", Action = "http://IUVOnlineService/IuvOnlineOldService_v1/pagamento", ReplyAction = "*")]
        [XmlSerializerFormat]
        [XmlFormatter.EnvelopeNamespaces(EnvelopeNamespaces = new string[] {
            "xsi:http://www.w3.org/2001/XMLSchema-instance"
           ,"xsd:http://www.w3.org/2001/XMLSchema"
        })]
        InviaPagamentoResponse InviaPagamento(InviaPagamentoRequest request);

    }

    /// <summary>
    /// Classe utilizzata per la creazione del canale di comunicazione con WebService di Banca Popolare di Sondrio
    /// </summary>
    public static class Servizio {

        private static readonly string URL = "https://wsdev.popso.it:16002/IUVOnlineService_v1/IuvOnlineOldService";
        private static readonly string THUMBPRINT = "46 7f 06 bb f8 18 b4 6b 2f 48 bf e8 41 fc 12 e9 8d 81 f9 a2";

        public static IServizio Create(string url,string thumb) {
            //ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls11;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
            url = url ?? URL;
            thumb = thumb ?? THUMBPRINT;
            var binding = new BasicHttpBinding(BasicHttpSecurityMode.Transport);
            binding.Security.Transport.ClientCredentialType = HttpClientCredentialType.Certificate;

            var address = new EndpointAddress(url);
            // EndpointAddress adress = new EndpointAddress(URL);

            var factory = new ChannelFactory<IServizio>(binding, address);
            factory.Credentials.ClientCertificate.SetCertificate(
                StoreLocation.CurrentUser,
                StoreName.My,
                X509FindType.FindByThumbprint,
                thumb
            );

            return factory.CreateChannel();
        }

    }

    #region "Messaggi SOAP"

    [MessageContract(IsWrapped = false)]
    public partial class InviaPagamentoRequest {

        [MessageBodyMember(Name = "pagamento", Namespace = "http://IUVOnlineService/IuvOnlineOldService_v1")]
        public InviaPagamentoRequestBody body;

        public InviaPagamentoRequest() { }

        public InviaPagamentoRequest(InviaPagamentoRequestBody body) {
            this.body = body;
        }

    }

    [MessageContract(IsWrapped = false)]
    public partial class InviaPagamentoResponse {

        [MessageBodyMember(Name = "pagamentoResponse", Namespace = "http://IUVOnlineService/IuvOnlineOldService_v1")]
        public InviaPagamentoResponseBody body;

        public InviaPagamentoResponse() { }

        public InviaPagamentoResponse(InviaPagamentoResponseBody body) {
            this.body = body;
        }

    }

    #endregion

    #region "Strutture dati (messaggi SOAP)"

    [Serializable]
    [XmlType(AnonymousType = true, Namespace = "http://IUVOnlineService/IuvOnlineOldService_v1")]
    public partial class InviaPagamentoRequestBody {

        [XmlElement("idTransazione", Form = XmlSchemaForm.Unqualified, IsNullable = true)]
        public string IdTransazione { get; set; }

        [XmlElement("codice_servizio", Form = XmlSchemaForm.Unqualified, IsNullable = true)]
        public string CodiceServizio { get; set; }

        [XmlElement("codice_sottoservizio", Form = XmlSchemaForm.Unqualified, IsNullable = true)]
        public string CodiceSottoservizio { get; set; }

        [XmlElement("xmlInp", Form = XmlSchemaForm.Unqualified, DataType = "base64Binary", IsNullable = true)]
        public byte[] xml { get; set; }


        [XmlIgnore]
        public AcquisizioneAvviso Avviso {
            get {
                if (xml == null) return null;

                var serializer = new XmlSerializer(typeof(AcquisizioneAvviso));

                object obj;
                using (var stream = new MemoryStream(xml)) {
                    obj = serializer.Deserialize(stream);
                }

                return obj as AcquisizioneAvviso;
            }
            set {
                var serializer = new XmlSerializer(typeof(AcquisizioneAvviso));

                using (var stream = new MemoryStream()) {
                    serializer.Serialize(stream, value);
                    stream.Flush();
                    xml = stream.ToArray();
                }
            }
        }

    }

    [Serializable]
    [XmlType(AnonymousType = true, Namespace = "http://IUVOnlineService/IuvOnlineOldService_v1")]
    public partial class InviaPagamentoResponseBody {

        [XmlElement("messagecode", Form = XmlSchemaForm.Unqualified, IsNullable = true)]
        public string Messaggio { get; set; }

        [XmlElement("returncode", Form = XmlSchemaForm.Unqualified, IsNullable = true)]
        public string Codice { get; set; }

        [XmlElement("xmlresponse", Form = XmlSchemaForm.Unqualified, DataType = "base64Binary", IsNullable = true)]
        public byte[] xml { get; set; }

        [XmlIgnore]
        public RicevutaAcquisizioneAvviso Ricevuta {
            get {
                if (xml == null) return null;

                var serializer = new XmlSerializer(typeof(RicevutaAcquisizioneAvviso));

                object obj;
                using (var stream = new MemoryStream(xml)) {
                    obj = serializer.Deserialize(stream);
                }

                return obj as RicevutaAcquisizioneAvviso;
            }
            set {
                var serializer = new XmlSerializer(typeof(RicevutaAcquisizioneAvviso));

                using (var stream = new MemoryStream()) {
                    serializer.Serialize(stream, value);
                    stream.Flush();
                    xml = stream.ToArray();
                }
            }
        }

    }

    #endregion

    #region "Strutture dati"

    [Serializable]
    [XmlType(AnonymousType = true)]
    [XmlRoot("acquisizione_avviso", IsNullable = false, Namespace = "")]
    public class AcquisizioneAvviso {

        [XmlElement("numero_disposizioni", DataType = "nonNegativeInteger", Order = 0)]
        public string NumeroDisposizioni {
            get { return Pagamenti.Count.ToString(); }
            set { throw new NotSupportedException("Questo è un campo calcolato"); }
        }

        [XmlElement("informazioni_banca", Order = 1)]
        public InformazioniBanca Banca;

        [XmlElement("informazioni_debitore", Order = 2)]
        public InformazioniDebitore Debitore;

        [XmlElement("informazioni_pagamento", Order = 3)]
        public List<InformazioniPagamento> Pagamenti;

    }

    [Serializable]
    [XmlType(AnonymousType = true)]
    public class InformazioniBanca {

        [XmlElement("codice_servizio")]
        public string CodiceServizio;

        [XmlElement("codice_sottoservizio")]
        public string CodiceSottoservizio;

        [XmlElement("numero_lista")]
        public string NumeroLista;
    }

    [Serializable]
    public enum Identificativo {

        [XmlEnum(Name = "F")]
        PersonaFisica,

        [XmlEnum(Name = "G")]
        PersonaGiuridica

    }

    [Serializable]
    [XmlType(AnonymousType = true)]
    public class InformazioniDebitore {

        [XmlElement("tipo_identificativo_univoco", IsNullable = false)]
        public Identificativo Identificativo;

        [XmlElement("codice_fiscale_debitore", IsNullable = false)]
        public string CodiceFiscale;

        [XmlElement("codice_debitore", IsNullable = false)]
        public string CodiceDebitore;

        [XmlElement("anagrafica_debitore", IsNullable = false)]
        public string RagioneSociale;

        [XmlElement("indirizzo_debitore", IsNullable = false)]
        public string Indirizzo;

        [XmlElement("cap_debitore", IsNullable = false)]
        public string CAP;

        [XmlElement("localita_debitore", IsNullable = false)]
        public string Località;

        [XmlElement("provincia_debitore", IsNullable = false)]
        public string Provincia;

        [XmlElement("email_debitore", IsNullable = false)]
        public string Email;

        [XmlElement("pec_debitore", IsNullable = false)]
        public string PEC;

    }

    [Serializable]
    [XmlType(AnonymousType = true)]
    public class InformazioniPagamento {

        [XmlElement("progressivo", DataType = "nonNegativeInteger")]
        public string Progressivo;

        [XmlElement("codice_identificativo_bollettino")]
        public string CodiceBollettino;

        [XmlElement("importo")]
        public decimal Importo;

        [XmlElement("dettaglio_voci")]
        public List<DettaglioVoce> DettaglioVoci;

        [XmlElement("scadenza", DataType = "date")]
        public DateTime Scadenza;

        [XmlElement("data_inizio_validita", DataType = "date")]
        public DateTime? InizioValidità;

        public bool ShouldSerializeInizioValidità() {
            return InizioValidità.HasValue;
        }

        [XmlElement("data_fine_validita", DataType = "date")]
        public DateTime? FineValidità;

        public bool ShouldSerializeFineValidità() {
            return FineValidità.HasValue;
        }

        [XmlElement("anno_riferimento")]
        public string AnnoRiferimento;

        [XmlElement("identificativo_disposizione")]
        public string IdDisposizione;

        [XmlElement("causale_bollettino")]
        public string CausaleBollettino;

        [XmlElement("dati_specifici_riscossione")]
        public DatiRiscossione DatiSpecificiRiscossione;

        [XmlElement("causale_RPT")]
        public Causale CausaleRPT;

    }

    [Serializable]
    [XmlType(AnonymousType = true)]
    public class DettaglioVoce {

        [XmlElement("codice_voce")]
        public string Codice;

        [XmlElement("importo_voce")]
        public decimal Importo;

    }

    [Serializable]
    [XmlType(AnonymousType = true)]
    public class DatiRiscossione {

        [XmlElement("tipo_contabilita")]
        public string TipoContabilità;

        [XmlElement("codice_contabilita")]
        public string CodiceContabilità;

    }

    [Serializable]
    [XmlType(AnonymousType = true)]
    public class Causale {

        [XmlElement("causaleVersamento", IsNullable = false)]
        public string CausaleVersamento;

        [XmlElement("spezzoniCausaleVersamento", IsNullable = false)]
        public List<SpezzoneCausale> SpezzoniCausaleVersamento;

    }

    [Serializable]
    [XmlType(AnonymousType = true)]
    public class SpezzoneCausale {

        [XmlElement("spezzoneCausaleVersamento", IsNullable = false)]
        public string CausaleVersamento;

        [XmlElement("spezzoneStrutturatoCausaleVersamento", IsNullable = false)]
        public List<CausaleStrutturata> CausaleVersamentoStrutturata;

    }

    [Serializable]
    [XmlType(AnonymousType = true)]
    public class CausaleStrutturata {

        [XmlElement("causaleSpezzone")]
        public string Descrizione;

        [XmlElement("importoSpezzone")]
        public decimal Importo;

    }

    [Serializable]
    [XmlType(AnonymousType = true)]
    [XmlRoot("ricevuta_acquisizione_avviso", IsNullable = false, Namespace = "")]
    public partial class RicevutaAcquisizioneAvviso {

        [XmlElement("id_transazione")]
        public string IdTransazione;

        [XmlElement("numero_disposizioni", DataType = "nonNegativeInteger")]
        public string NumeroDisposizioni;

        [XmlElement("informazioni_banca")]
        public InformazioniBanca Banca;

        [XmlElement("informazioni_debitore")]
        public InformazioniDebitore Debitore;

        [XmlElement("informazioni_pagamento")]
        public List<InformazioniPagamento> Pagamenti;

        [XmlElement("esito")]
        public List<Esito> Esito;

        [XmlElement("PDF_bollettino", DataType = "base64Binary", IsNullable = false)]
        public byte[] Bollettino;

    }

    [Serializable]
    [XmlType(AnonymousType = true)]
    public class Esito {

        [XmlElement("acquisito", IsNullable = false)]
        public EsitoAcquisito Acquisito;

        [XmlElement("non_acquisito", IsNullable = false)]
        public EsitoNonAcquisito NonAcquisito;

    }

    [Serializable]
    [XmlType(AnonymousType = true)]
    public partial class EsitoAcquisito {

        [XmlElement("progressivo_richiesta", DataType = "nonNegativeInteger")]
        public string Progressivo;

        [XmlElement("valore_codice_barre")]
        public string ValoreCodiceBarre;

        [XmlElement("immagine_codice_barre", DataType = "base64Binary")]
        public byte[] CodiceBarre;

        [XmlElement("valore_QR_code")]
        public string ValoreCodiceQR;

        [XmlElement("immagine_QR_code", DataType = "base64Binary")]
        public byte[] CodiceQR;

        [XmlElement("codice_identificativo_bollettino")]
        public string CodiceBollettino;

        [XmlIgnore]
        public string IUV {
            get { return CodiceBollettino?.Substring(3); }
        }

    }

    [Serializable]
    [XmlType(AnonymousType = true)]
    public partial class EsitoNonAcquisito {

        [XmlElement("progressivo_richiesta", DataType = "nonNegativeInteger")]
        public string Progressivo;

        [XmlElement("codice_errore", DataType = "nonNegativeInteger")]
        public string CodiceErrore;

        [XmlElement("descrizione_errore")]
        public string DescrizioneErrore;

    }

    #endregion

}
