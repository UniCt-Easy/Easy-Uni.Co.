/*
    Easy
    Copyright (C) 2019 Università degli Studi di Catania (www.unict.it)

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

ï»¿using System;
using System.IO;
using System.Net;
using System.Net.Security;
using System.Runtime.Serialization;
using System.Security.Cryptography.X509Certificates;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using System.Xml;
namespace IntesaSanPaolo {

    [ServiceContract(Namespace = "http://easybridge.eu/bridge/", ConfigurationName = "IService2", Name = "WEBS_DataProviderInterfacePort")]
    public interface IServizio {

        [OperationContract(Action = "http://easybridge.eu/bridge/WEBS_DataProviderInterfacePort/pdpChiediElencoFlussiRendicontazione", ReplyAction = "http://easybridge.eu/bridge/WEBS_DataProviderInterfacePort/pdpChiediElencoFlussiRendicontazioneResponse")]
        pdpChiediElencoFlussiRendicontazioneResponse pdpChiediElencoFlussiRendicontazione(pdpChiediElencoFlussiRendicontazione request);

        [OperationContract(Action = "http://easybridge.eu/bridge/WEBS_DataProviderInterfacePort/pdpGeneraIUV", ReplyAction = "http://easybridge.eu/bridge/WEBS_DataProviderInterfacePort/pdpGeneraIUVResponse")]
        pdpGeneraIUVResponse pdpGeneraIUV(pdpGeneraIUV request);

        [OperationContract(Action = "http://easybridge.eu/bridge/WEBS_DataProviderInterfacePort/dpInviaEsitoPagamento", ReplyAction = "http://easybridge.eu/bridge/WEBS_DataProviderInterfacePort/dpInviaEsitoPagamentoResponse")]
        dpInviaEsitoPagamentoResponse dpInviaEsitoPagamento(dpInviaEsitoPagamento request);

        [OperationContract(Action = "http://easybridge.eu/bridge/WEBS_DataProviderInterfacePort/pdpCancellaPagamentoInAttesa", ReplyAction = "http://easybridge.eu/bridge/WEBS_DataProviderInterfacePort/pdpCancellaPagamentoInAttesaResponse")]
        pdpCancellaPagamentoInAttesaResponse pdpCancellaPagamentoInAttesa(pdpCancellaPagamentoInAttesa request);

        [OperationContract(Action = "http://easybridge.eu/bridge/WEBS_DataProviderInterfacePort/pdpCaricaPagamentoInAttesa", ReplyAction = "http://easybridge.eu/bridge/WEBS_DataProviderInterfacePort/pdpCaricaPagamentoInAttesaResponse")]

        [XmlFormatter.EnvelopeNamespaces(EnvelopeNamespaces = new string[] {
            //"ser:http://easybridge.eu/bridge/",
            "s:http://www.w3.org/2003/05/soap-envelope"
        })]
        pdpCaricaPagamentoInAttesaResponse pdpCaricaPagamentoInAttesa(pdpCaricaPagamentoInAttesa request);

        [OperationContract(Action = "http://easybridge.eu/bridge/WEBS_DataProviderInterfacePort/pdpRecuperaRT", ReplyAction = "http://easybridge.eu/bridge/WEBS_DataProviderInterfacePort/pdpRecuperaRTResponse")]
        pdpRecuperaRTResponse pdpRecuperaRT(pdpRecuperaRT request);

        [OperationContract(Action = "http://easybridge.eu/bridge/WEBS_DataProviderInterfacePort/pdpEsitiRT", ReplyAction = "http://easybridge.eu/bridge/WEBS_DataProviderInterfacePort/pdpEsitiRTResponse")]
        pdpEsitiRTResponse pdpEsitiRT(pdpEsitiRT request);

        [OperationContract(Action = "http://easybridge.eu/bridge/WEBS_DataProviderInterfacePort/pdpAttivaRpt", ReplyAction = "http://easybridge.eu/bridge/WEBS_DataProviderInterfacePort/pdpAttivaRptResponse")]
        pdpAttivaRptResponse pdpAttivaRpt(pdpAttivaRpt request);

        [OperationContract(Action = "http://easybridge.eu/bridge/WEBS_DataProviderInterfacePort/pdpChiediFlussoRendicontazione", ReplyAction = "http://easybridge.eu/bridge/WEBS_DataProviderInterfacePort/pdpChiediFlussoRendicontazioneResponse")]
        pdpChiediFlussoRendicontazioneResponse pdpChiediFlussoRendicontazione(pdpChiediFlussoRendicontazione request);

        [OperationContract(Action = "http://easybridge.eu/bridge/WEBS_DataProviderInterfacePort/pdpRecuperaRPT", ReplyAction = "http://easybridge.eu/bridge/WEBS_DataProviderInterfacePort/pdpRecuperaRPTResponse")]
        pdpRecuperaRPTResponse pdpRecuperaRPT(pdpRecuperaRPT request);

        [OperationContract(Action = "http://easybridge.eu/bridge/WEBS_DataProviderInterfacePort/pdpRichiediStornoRT", ReplyAction = "http://easybridge.eu/bridge/WEBS_DataProviderInterfacePort/pdpRichiediStornoRTResponse")]
        pdpRichiediStornoRTResponse pdpRichiediStornoRT(pdpRichiediStornoRT request);

        [OperationContract(Action = "http://easybridge.eu/bridge/WEBS_DataProviderInterfacePort/pdpChiediSceltaWISP", ReplyAction = "http://easybridge.eu/bridge/WEBS_DataProviderInterfacePort/pdpChiediSceltaWISPResponse")]
        pdpChiediSceltaWISPResponse pdpChiediSceltaWISP(pdpChiediSceltaWISP request);

        [OperationContract(Action = "http://easybridge.eu/bridge/WEBS_DataProviderInterfacePort/pdpChiediStatoRPT", ReplyAction = "http://easybridge.eu/bridge/WEBS_DataProviderInterfacePort/pdpChiediStatoRPTResponse")]
        pdpChiediStatoRPTResponse pdpChiediStatoRPT(pdpChiediStatoRPT request);

        [OperationContract(Action = "http://easybridge.eu/bridge/WEBS_DataProviderInterfacePort/dpVerificaPagamentoInAttesa", ReplyAction = "http://easybridge.eu/bridge/WEBS_DataProviderInterfacePort/dpVerificaPagamentoInAttesaResponse")]
        dpVerificaPagamentoInAttesaResponse dpVerificaPagamentoInAttesa(dpVerificaPagamentoInAttesa request);

        [OperationContract(Action = "http://easybridge.eu/bridge/WEBS_DataProviderInterfacePort/pdpInviaRPT", ReplyAction = "http://easybridge.eu/bridge/WEBS_DataProviderInterfacePort/pdpInviaRPTResponse")]
        pdpInviaRPTResponse pdpInviaRPT(pdpInviaRPT request);

        [OperationContract(Action = "http://easybridge.eu/bridge/WEBS_DataProviderInterfacePort/pdpVerificaMarcaDaBolloDigitale", ReplyAction = "http://easybridge.eu/bridge/WEBS_DataProviderInterfacePort/pdpVerificaMarcaDaBolloDigitaleResponse")]
        pdpVerificaMarcaDaBolloDigitaleResponse pdpVerificaMarcaDaBolloDigitale(pdpVerificaMarcaDaBolloDigitale request);

        [OperationContract(Action = "http://easybridge.eu/bridge/WEBS_DataProviderInterfacePort/pdpRichiediAvviso", ReplyAction = "http://easybridge.eu/bridge/WEBS_DataProviderInterfacePort/pdpRichiediAvvisoResponse")]
        pdpRichiediAvvisoResponse pdpRichiediAvviso(pdpRichiediAvviso request);

        [OperationContract(Action = "http://easybridge.eu/bridge/WEBS_DataProviderInterfacePort/pdpGeneraRPT", ReplyAction = "http://easybridge.eu/bridge/WEBS_DataProviderInterfacePort/pdpGeneraRPTResponse")]
        pdpGeneraRPTResponse pdpGeneraRPT(pdpGeneraRPT request);

    }

    [MessageContract(IsWrapped = false)]
    public class pdpChiediElencoFlussiRendicontazione {

        [MessageBodyMember(Name = "pdpChiediElencoFlussiRendicontazione", Namespace = "http://easybridge.eu/bridge/", Order = 0)]
        public pdpChiediElencoFlussiRendicontazioneBody Body;

        public pdpChiediElencoFlussiRendicontazione() { }

        public pdpChiediElencoFlussiRendicontazione(pdpChiediElencoFlussiRendicontazioneBody Body) {
            this.Body = Body;
        }

    }

    [DataContract(Namespace = "http://easybridge.eu/bridge/")]
    public class pdpChiediElencoFlussiRendicontazioneBody {

        [DataMember(EmitDefaultValue = false, Order = 0)]
        public string identificativoDominio;

        [DataMember(EmitDefaultValue = false, Order = 1)]
        public byte[] param;

        public pdpChiediElencoFlussiRendicontazioneBody() { }

        public pdpChiediElencoFlussiRendicontazioneBody(string identificativoDominio, byte[] param) {
            this.identificativoDominio = identificativoDominio;
            this.param = param;
        }

    }

    [MessageContract(IsWrapped = false)]
    public class pdpChiediElencoFlussiRendicontazioneResponse {

        [MessageBodyMember(Name = "pdpChiediElencoFlussiRendicontazioneResponse", Namespace = "http://easybridge.eu/bridge/", Order = 0)]
        public pdpChiediElencoFlussiRendicontazioneResponseBody Body;

        public pdpChiediElencoFlussiRendicontazioneResponse() { }

        public pdpChiediElencoFlussiRendicontazioneResponse(pdpChiediElencoFlussiRendicontazioneResponseBody Body) {
            this.Body = Body;
        }

    }

    [DataContract(Namespace = "http://easybridge.eu/bridge/")]
    public class pdpChiediElencoFlussiRendicontazioneResponseBody {

        [DataMember(EmitDefaultValue = false, Order = 0)]
        public EasyBridge.Output pdpChiediElencoFlussiRendicontazioneResult;

        public pdpChiediElencoFlussiRendicontazioneResponseBody() { }

        public pdpChiediElencoFlussiRendicontazioneResponseBody(EasyBridge.Output pdpChiediElencoFlussiRendicontazioneResult) {
            this.pdpChiediElencoFlussiRendicontazioneResult = pdpChiediElencoFlussiRendicontazioneResult;
        }

    }

    [MessageContract(IsWrapped = false)]
    public class pdpGeneraIUV {

        [MessageBodyMember(Name = "pdpGeneraIUV", Namespace = "http://easybridge.eu/bridge/", Order = 0)]
        public pdpGeneraIUVBody Body;

        public pdpGeneraIUV() { }

        public pdpGeneraIUV(pdpGeneraIUVBody Body) {
            this.Body = Body;
        }

    }

    [DataContract(Namespace = "http://easybridge.eu/bridge/")]
    public class pdpGeneraIUVBody {

        [DataMember(EmitDefaultValue = false, Order = 0)]
        public string identificativoDominio;

        [DataMember(EmitDefaultValue = false, Order = 1)]
        public string identificativoBU;

        [DataMember(EmitDefaultValue = false, Order = 2)]
        public string idTributo;

        public pdpGeneraIUVBody() { }

        public pdpGeneraIUVBody(string identificativoDominio, string identificativoBU, string idTributo) {
            this.identificativoDominio = identificativoDominio;
            this.identificativoBU = identificativoBU;
            this.idTributo = idTributo;
        }

    }

    [MessageContract(IsWrapped = false)]
    public class pdpGeneraIUVResponse {

        [MessageBodyMember(Name = "pdpGeneraIUVResponse", Namespace = "http://easybridge.eu/bridge/", Order = 0)]
        public pdpGeneraIUVResponseBody Body;

        public pdpGeneraIUVResponse() { }

        public pdpGeneraIUVResponse(pdpGeneraIUVResponseBody Body) {
            this.Body = Body;
        }

    }

    [DataContract(Namespace = "http://easybridge.eu/bridge/")]
    public class pdpGeneraIUVResponseBody {

        [DataMember(EmitDefaultValue = false, Order = 0)]
        public EasyBridge.Output pdpGeneraIUVResult;

        public pdpGeneraIUVResponseBody() { }

        public pdpGeneraIUVResponseBody(EasyBridge.Output pdpGeneraIUVResult) {
            this.pdpGeneraIUVResult = pdpGeneraIUVResult;
        }

    }

    [MessageContract(IsWrapped = false)]
    public class dpInviaEsitoPagamento {

        [MessageBodyMember(Name = "dpInviaEsitoPagamento", Namespace = "http://easybridge.eu/bridge/", Order = 0)]
        public dpInviaEsitoPagamentoBody Body;

        public dpInviaEsitoPagamento() { }

        public dpInviaEsitoPagamento(dpInviaEsitoPagamentoBody Body) {
            this.Body = Body;
        }

    }

    [DataContract(Namespace = "http://easybridge.eu/bridge/")]
    public class dpInviaEsitoPagamentoBody {

        [DataMember(EmitDefaultValue = false, Order = 0)]
        public string identificativoDominio;

        [DataMember(EmitDefaultValue = false, Order = 1)]
        public string identificativoBU;

        [DataMember(EmitDefaultValue = false, Order = 2)]
        public byte[] param;

        public dpInviaEsitoPagamentoBody() { }

        public dpInviaEsitoPagamentoBody(string identificativoDominio, string identificativoBU, byte[] param) {
            this.identificativoDominio = identificativoDominio;
            this.identificativoBU = identificativoBU;
            this.param = param;
        }

    }

    [MessageContract(IsWrapped = false)]
    public class dpInviaEsitoPagamentoResponse {

        [MessageBodyMember(Name = "dpInviaEsitoPagamentoResponse", Namespace = "http://easybridge.eu/bridge/", Order = 0)]
        public dpInviaEsitoPagamentoResponseBody Body;

        public dpInviaEsitoPagamentoResponse() { }

        public dpInviaEsitoPagamentoResponse(dpInviaEsitoPagamentoResponseBody Body) {
            this.Body = Body;
        }

    }

    [DataContract(Namespace = "http://easybridge.eu/bridge/")]
    public class dpInviaEsitoPagamentoResponseBody {

        [DataMember(EmitDefaultValue = false, Order = 0)]
        public EasyBridge.Output dpInviaEsitoPagamentoResult;

        public dpInviaEsitoPagamentoResponseBody() { }

        public dpInviaEsitoPagamentoResponseBody(EasyBridge.Output dpInviaEsitoPagamentoResult) {
            this.dpInviaEsitoPagamentoResult = dpInviaEsitoPagamentoResult;
        }

    }

    [MessageContract(IsWrapped = false)]
    public class pdpCancellaPagamentoInAttesa {

        [MessageBodyMember(Name = "pdpCancellaPagamentoInAttesa", Namespace = "http://easybridge.eu/bridge/", Order = 0)]
        public pdpCancellaPagamentoInAttesaBody Body;

        public pdpCancellaPagamentoInAttesa() { }

        public pdpCancellaPagamentoInAttesa(pdpCancellaPagamentoInAttesaBody Body) {
            this.Body = Body;
        }

    }

    [DataContract(Namespace = "http://easybridge.eu/bridge/")]
    public class pdpCancellaPagamentoInAttesaBody {

        [DataMember(EmitDefaultValue = false, Order = 0)]
        public string identificativoDominio;

        [DataMember(EmitDefaultValue = false, Order = 1)]
        public string identificativoBU;

        [DataMember(EmitDefaultValue = false, Order = 2)]
        public byte[] param;

        public pdpCancellaPagamentoInAttesaBody() { }

        public pdpCancellaPagamentoInAttesaBody(string identificativoDominio, string identificativoBU, byte[] param) {
            this.identificativoDominio = identificativoDominio;
            this.identificativoBU = identificativoBU;
            this.param = param;
        }

    }

    [MessageContract(IsWrapped = false)]
    public class pdpCancellaPagamentoInAttesaResponse {

        [MessageBodyMember(Name = "pdpCancellaPagamentoInAttesaResponse", Namespace = "http://easybridge.eu/bridge/", Order = 0)]
        public pdpCancellaPagamentoInAttesaResponseBody Body;

        public pdpCancellaPagamentoInAttesaResponse() { }

        public pdpCancellaPagamentoInAttesaResponse(pdpCancellaPagamentoInAttesaResponseBody Body) {
            this.Body = Body;
        }

    }

    [DataContract(Namespace = "http://easybridge.eu/bridge/")]
    public class pdpCancellaPagamentoInAttesaResponseBody {

        [DataMember(EmitDefaultValue = false, Order = 0)]
        public EasyBridge.Output pdpCancellaPagamentoInAttesaResult;

        public pdpCancellaPagamentoInAttesaResponseBody() { }

        public pdpCancellaPagamentoInAttesaResponseBody(EasyBridge.Output pdpCancellaPagamentoInAttesaResult) {
            this.pdpCancellaPagamentoInAttesaResult = pdpCancellaPagamentoInAttesaResult;
        }

    }

    [MessageContract(IsWrapped = false)]
    public class pdpCaricaPagamentoInAttesa {

        [MessageBodyMember(Name = "pdpCaricaPagamentoInAttesa", Namespace = "http://easybridge.eu/bridge/", Order = 0)]
        public pdpCaricaPagamentoInAttesaBody Body;

        public pdpCaricaPagamentoInAttesa() { }

        public pdpCaricaPagamentoInAttesa(pdpCaricaPagamentoInAttesaBody Body) {
            this.Body = Body;
        }

    }

    [DataContract(Namespace = "http://easybridge.eu/bridge/")]
    [MessageContract(IsWrapped = false)]
    public class pdpCaricaPagamentoInAttesaBody {

        [DataMember(EmitDefaultValue = false, Order = 0)]
        public string identificativoDominio;

        [DataMember( EmitDefaultValue = false, Order = 1)]
        public string identificativoBU;

        [DataMember(EmitDefaultValue = false, Order = 2)]
        public byte[] param;

        public pdpCaricaPagamentoInAttesaBody() { }

        public pdpCaricaPagamentoInAttesaBody(string identificativoDominio, string identificativoBU, byte[] param) {
            this.identificativoDominio = identificativoDominio;
            this.identificativoBU = identificativoBU;
            this.param = param;
        }

        public pdpCaricaPagamentoInAttesaBody(string identificativoDominio, string identificativoBU, InfoGroup.ct0000000003_pdpCaricaPagamentoInAttesa pagamento) {
            this.identificativoDominio = identificativoDominio;
            this.identificativoBU = identificativoBU;

            if (pagamento != null) {
                XmlWriterSettings settings = new XmlWriterSettings() { Indent = true, OmitXmlDeclaration = true };
                DataContractSerializer serializer = new DataContractSerializer(typeof(InfoGroup.ct0000000003_pdpCaricaPagamentoInAttesa),
                        "param", "http://generatedsource.dp.webservice.intermediariopa.infogroup.it/");

                using (MemoryStream stream = new MemoryStream()) {
                    serializer.WriteObject(stream, pagamento);
                    this.param = stream.ToArray();
                }

            }
        }

    }

    [MessageContract(IsWrapped = false)]
    public class pdpCaricaPagamentoInAttesaResponse {

        [MessageBodyMember(Name = "pdpCaricaPagamentoInAttesaResponse", Namespace = "http://easybridge.eu/bridge/", Order = 0)]
        public pdpCaricaPagamentoInAttesaResponseBody Body;

        public pdpCaricaPagamentoInAttesaResponse() { }

        public pdpCaricaPagamentoInAttesaResponse(pdpCaricaPagamentoInAttesaResponseBody Body) {
            this.Body = Body;
        }

    }

    [DataContract(Namespace = "http://easybridge.eu/bridge/")]
    public class pdpCaricaPagamentoInAttesaResponseBody {

        [DataMember(EmitDefaultValue = false, Order = 0)]
        public EasyBridge.Output pdpCaricaPagamentoInAttesaResult;

        public pdpCaricaPagamentoInAttesaResponseBody() { }

        public pdpCaricaPagamentoInAttesaResponseBody(EasyBridge.Output pdpCaricaPagamentoInAttesaResult) {
            this.pdpCaricaPagamentoInAttesaResult = pdpCaricaPagamentoInAttesaResult;
        }

        public InfoGroup.ct0000000004_pdpCaricaPagamentoInAttesaResult Result {
            get {
                if (pdpCaricaPagamentoInAttesaResult == null || pdpCaricaPagamentoInAttesaResult.param == null) return null;
                var serializer = new DataContractSerializer(typeof(EasyBridge.pdpCaricaPagamentoInAttesaResult));

                object obj;
                using (var stream = new MemoryStream(pdpCaricaPagamentoInAttesaResult.param)) {
                    obj = serializer.ReadObject(stream);
                }

                return obj as InfoGroup.ct0000000004_pdpCaricaPagamentoInAttesaResult;
            }
        }

    }

    [MessageContract(IsWrapped = false)]
    public class pdpRecuperaRT {

        [MessageBodyMember(Name = "pdpRecuperaRT", Namespace = "http://easybridge.eu/bridge/", Order = 0)]
        public pdpRecuperaRTBody Body;

        public pdpRecuperaRT() { }

        public pdpRecuperaRT(pdpRecuperaRTBody Body) {
            this.Body = Body;
        }

    }

    [DataContract(Namespace = "http://easybridge.eu/bridge/")]
    public class pdpRecuperaRTBody {

        [DataMember(EmitDefaultValue = false, Order = 0)]
        public string identificativoDominio;

        [DataMember(EmitDefaultValue = false, Order = 1)]
        public string identificativoBU;

        [DataMember(EmitDefaultValue = false, Order = 2)]
        public byte[] param;

        public pdpRecuperaRTBody() { }

        public pdpRecuperaRTBody(string identificativoDominio, string identificativoBU, byte[] param) {
            this.identificativoDominio = identificativoDominio;
            this.identificativoBU = identificativoBU;
            this.param = param;
        }

    }

    [MessageContract(IsWrapped = false)]
    public class pdpRecuperaRTResponse {

        [MessageBodyMember(Name = "pdpRecuperaRTResponse", Namespace = "http://easybridge.eu/bridge/", Order = 0)]
        public pdpRecuperaRTResponseBody Body;

        public pdpRecuperaRTResponse() { }

        public pdpRecuperaRTResponse(pdpRecuperaRTResponseBody Body) {
            this.Body = Body;
        }

    }

    [DataContract(Namespace = "http://easybridge.eu/bridge/")]
    public class pdpRecuperaRTResponseBody {

        [DataMember(EmitDefaultValue = false, Order = 0)]
        public EasyBridge.Output pdpRecuperaRTResult;

        public pdpRecuperaRTResponseBody() { }

        public pdpRecuperaRTResponseBody(EasyBridge.Output pdpRecuperaRTResult) {
            this.pdpRecuperaRTResult = pdpRecuperaRTResult;
        }

    }

    [MessageContract(IsWrapped = false)]
    public class pdpEsitiRT {

        [MessageBodyMember(Name = "pdpEsitiRT", Namespace = "http://easybridge.eu/bridge/", Order = 0)]
        public pdpEsitiRTBody Body;

        public pdpEsitiRT() { }

        public pdpEsitiRT(pdpEsitiRTBody Body) {
            this.Body = Body;
        }

    }

    [DataContract(Namespace = "http://easybridge.eu/bridge/")]
    public class pdpEsitiRTBody {

        [DataMember(EmitDefaultValue = false, Order = 0)]
        public string identificativoDominio;

        [DataMember(EmitDefaultValue = false, Order = 1)]
        public string identificativoBU;

        [DataMember(EmitDefaultValue = false, Order = 2)]
        public byte[] param;

        public pdpEsitiRTBody() { }

        public pdpEsitiRTBody(string identificativoDominio, string identificativoBU, byte[] param) {
            this.identificativoDominio = identificativoDominio;
            this.identificativoBU = identificativoBU;
            this.param = param;
        }
        public pdpEsitiRTBody(string identificativoDominio, string identificativoBU, string identificativoServizio,
            DateTime inizio, DateTime fine, string idoperazione= "RTPOSITIVE", string iuv=null, string cf=null) {
            this.identificativoDominio = identificativoDominio;
            this.identificativoBU = identificativoBU;
            var filtro = new InfoGroup.ct0000000006_pdpEsitiRTType() {
                identificativoServizio = identificativoServizio,
                idOperazione = idoperazione, // default: solo RT incassate
                 IUV = iuv,
                CF = cf

            };
            if (iuv != null) {
                filtro = new InfoGroup.ct0000000006_pdpEsitiRTType() {
                    identificativoServizio = identificativoServizio,
                    idOperazione = idoperazione, // default: solo RT incassate
                    dataInizio = inizio,
                    dataFine = fine,
                    IUV = iuv
                };
            }

            //qui
            //DataContractSerializer serializer = new DataContractSerializer(typeof(InfoGroup.ct0000000006_pdpEsitiRTType));

            XmlWriterSettings settings = new XmlWriterSettings() { Indent = true, OmitXmlDeclaration = true };
            DataContractSerializer serializer = new DataContractSerializer(typeof(InfoGroup.ct0000000006_pdpEsitiRTType),
                "param", "http://generatedsource.dp.webservice.intermediariopa.infogroup.it/");

            using (MemoryStream stream = new MemoryStream()) {
                serializer.WriteObject(stream, filtro);

                this.param = stream.ToArray();
            }
        }

        public pdpEsitiRTBody(string identificativoDominio, string identificativoBU, string identificativoServizio,
            DateTime inizio, DateTime fine) {
            this.identificativoDominio = identificativoDominio;
            this.identificativoBU = identificativoBU;

            var filtro = new InfoGroup.ct0000000006_pdpEsitiRTType() {
                identificativoServizio = identificativoServizio,
                idOperazione = "RTPOSITIVE", // default: solo RT incassate
                dataInizio = inizio,
                dataFine = fine,
                               
            };

            //qui
            //DataContractSerializer serializer = new DataContractSerializer(typeof(InfoGroup.ct0000000006_pdpEsitiRTType));

            XmlWriterSettings settings = new XmlWriterSettings() { Indent = true, OmitXmlDeclaration = true };
            DataContractSerializer serializer = new DataContractSerializer(typeof(InfoGroup.ct0000000006_pdpEsitiRTType),
                    "param", "http://generatedsource.dp.webservice.intermediariopa.infogroup.it/");

            using (MemoryStream stream = new MemoryStream()) {
                serializer.WriteObject(stream, filtro);

                this.param = stream.ToArray();
            }
        }

        public pdpEsitiRTBody(string identificativoDominio, string identificativoBU, string identificativoServizio, string iuv) {
            this.identificativoDominio = identificativoDominio;
            this.identificativoBU = identificativoBU;

            var filtro = new InfoGroup.ct0000000006_pdpEsitiRTType() { 
                identificativoServizio = identificativoServizio,
                idOperazione = "RTPOSITIVE", // default: solo RT incassate                
                IUV = iuv
            };
            //qui
            //DataContractSerializer serializer = new DataContractSerializer(typeof(InfoGroup.ct0000000006_pdpEsitiRTType));

            XmlWriterSettings settings = new XmlWriterSettings() { Indent = true, OmitXmlDeclaration = true };
            DataContractSerializer serializer = new DataContractSerializer(typeof(InfoGroup.ct0000000006_pdpEsitiRTType),
                    "param", "http://generatedsource.dp.webservice.intermediariopa.infogroup.it/");

            using (MemoryStream stream = new MemoryStream()) {
                serializer.WriteObject(stream, filtro);

                this.param = stream.ToArray();
            }
        }

    }

    [MessageContract(IsWrapped = false)]
    public class pdpEsitiRTResponse {

        [MessageBodyMember(Name = "pdpEsitiRTResponse", Namespace = "http://easybridge.eu/bridge/", Order = 0)]
        public pdpEsitiRTResponseBody Body;

        public pdpEsitiRTResponse() { }

        public pdpEsitiRTResponse(pdpEsitiRTResponseBody Body) {
            this.Body = Body;
        }

    }

   
    [DataContract(Namespace = "http://easybridge.eu/bridge/")]
    public class pdpEsitiRTResponseBody {

        [DataMember(EmitDefaultValue = false, Order = 0)]
        public EasyBridge.Output pdpEsitiRTResult;

        public pdpEsitiRTResponseBody() { }

        public pdpEsitiRTResponseBody(EasyBridge.Output pdpEsitiRTResult) {
            this.pdpEsitiRTResult = pdpEsitiRTResult;
        }

        private static void WrapElement(XmlDocument doc, string elementName, string wrapperName, string nameSpace) {
            var names = new XmlNamespaceManager(doc.NameTable);
            names.AddNamespace("a", nameSpace);

            var Nodes = doc.SelectNodes("//a:" + elementName, names);

            if (Nodes.Count > 0) {
                var newBorrower = doc.CreateElement(Nodes.Item(0).Prefix, wrapperName, Nodes.Item(0).NamespaceURI);

                foreach (XmlElement node in Nodes) {
                    newBorrower.AppendChild(node.Clone());
                }

                Nodes.Item(0).ParentNode.ReplaceChild(newBorrower, Nodes.Item(0));

                for (int i = 1; i <= Nodes.Count - 1; i++) {
                    Nodes.Item(i).ParentNode.RemoveChild(Nodes.Item(i));
                }
            }
        }

        public InfoGroup.ct0000000007_pdpEsitiRTResultType Result {
            get {
                if (pdpEsitiRTResult == null || pdpEsitiRTResult.param == null) return null;

                var serializer = new DataContractSerializer(typeof(EasyBridge.pdpEsitiRTResultType));
                string tmp = System.Text.ASCIIEncoding.ASCII.GetString(pdpEsitiRTResult.param);

                object obj;
                using (var stream = new MemoryStream(pdpEsitiRTResult.param)) {
                    XmlDocument doc = new XmlDocument();
                    doc.Load(stream);
                    //trasformazione di doc
                    
                    WrapElement(doc, "ricevutaTelematica", "listaRicevutaTelematica", "http://generatedsource.dp.webservice.intermediariopa.infogroup.it/");
                    MemoryStream m = new MemoryStream();
                    doc.Save(m);
                    m.Seek(0,SeekOrigin.Begin);
                    obj = serializer.ReadObject(m);
                }

                return obj as InfoGroup.ct0000000007_pdpEsitiRTResultType;
            }
        }

    }

    [MessageContract(IsWrapped = false)]
    public class pdpAttivaRpt {

        [MessageBodyMember(Name = "pdpAttivaRpt", Namespace = "http://easybridge.eu/bridge/", Order = 0)]
        public pdpAttivaRptBody Body;

        public pdpAttivaRpt() { }

        public pdpAttivaRpt(pdpAttivaRptBody Body) {
            this.Body = Body;
        }

    }

    [DataContract(Namespace = "http://easybridge.eu/bridge/")]
    [MessageContract(IsWrapped = false)]
    public class pdpAttivaRptBody {

        [DataMember(EmitDefaultValue = false, Order = 0)]
        public string identificativoDominio;

        [DataMember(EmitDefaultValue = false, Order = 1)]
        public string identificativoBU;

        [DataMember(EmitDefaultValue = false, Order = 2)]
        public byte[] param;

        public pdpAttivaRptBody() { }

        public pdpAttivaRptBody(string identificativoDominio, string identificativoBU, byte[] param) {
            this.identificativoDominio = identificativoDominio;
            this.identificativoBU = identificativoBU;
            this.param = param;
        }

        // Inserito da Nunzio
        public pdpAttivaRptBody(string identificativoDominio, string identificativoBU, InfoGroup.ct0000000027_pdpAttivaRpt datiPagamento) {
            this.identificativoDominio = identificativoDominio;
            this.identificativoBU = identificativoBU;

            if (datiPagamento != null) {
                XmlWriterSettings settings = new XmlWriterSettings() { Indent = true, OmitXmlDeclaration = true };
                DataContractSerializer serializer = new DataContractSerializer(typeof(InfoGroup.ct0000000027_pdpAttivaRpt),
                       "param", "http://generatedsource.dp.webservice.intermediariopa.infogroup.it/");

                using (MemoryStream stream = new MemoryStream()) {
                    serializer.WriteObject(stream, datiPagamento);
                    this.param = stream.ToArray();
                }
            }

        }
    }

    [MessageContract(IsWrapped = false)]
    public class pdpAttivaRptResponse {

        [MessageBodyMember(Name = "pdpAttivaRptResponse", Namespace = "http://easybridge.eu/bridge/", Order = 0)]
        public pdpAttivaRptResponseBody Body;

        public pdpAttivaRptResponse() { }

        public pdpAttivaRptResponse(pdpAttivaRptResponseBody Body) {
            this.Body = Body;
        }

    }

    [DataContract(Namespace = "http://easybridge.eu/bridge/")]
    public class pdpAttivaRptResponseBody {

        [DataMember(EmitDefaultValue = false, Order = 0)]
        public EasyBridge.Output pdpAttivaRptResult;

        public pdpAttivaRptResponseBody() { }

        public pdpAttivaRptResponseBody(EasyBridge.Output pdpAttivaRptResult) {
            this.pdpAttivaRptResult = pdpAttivaRptResult;
        }

        public InfoGroup.ct0000000027_pdpAttivaRptResult Result
        {
            get
            {
                if (pdpAttivaRptResult == null || pdpAttivaRptResult.param == null) return null;
                var serializer = new DataContractSerializer(typeof(EasyBridge.pdpAttivaRptResult));

                object obj;
                using (var stream = new MemoryStream(pdpAttivaRptResult.param)) {
                    obj = serializer.ReadObject(stream);
                }

                return obj as InfoGroup.ct0000000027_pdpAttivaRptResult;
            }
        }
    }

    [MessageContract(IsWrapped = false)]
    public class pdpChiediFlussoRendicontazione {

        [MessageBodyMember(Name = "pdpChiediFlussoRendicontazione", Namespace = "http://easybridge.eu/bridge/", Order = 0)]
        public pdpChiediFlussoRendicontazioneBody Body;

        public pdpChiediFlussoRendicontazione() { }

        public pdpChiediFlussoRendicontazione(pdpChiediFlussoRendicontazioneBody Body) {
            this.Body = Body;
        }

    }

    [DataContract(Namespace = "http://easybridge.eu/bridge/")]
    public class pdpChiediFlussoRendicontazioneBody {

        [DataMember(EmitDefaultValue = false, Order = 0)]
        public string identificativoDominio;

        [DataMember(EmitDefaultValue = false, Order = 1)]
        public byte[] param;

        public pdpChiediFlussoRendicontazioneBody() { }

        public pdpChiediFlussoRendicontazioneBody(string identificativoDominio, byte[] param) {
            this.identificativoDominio = identificativoDominio;
            this.param = param;
        }

    }

    [MessageContract(IsWrapped = false)]
    public class pdpChiediFlussoRendicontazioneResponse {

        [MessageBodyMember(Name = "pdpChiediFlussoRendicontazioneResponse", Namespace = "http://easybridge.eu/bridge/", Order = 0)]
        public pdpChiediFlussoRendicontazioneResponseBody Body;

        public pdpChiediFlussoRendicontazioneResponse() { }

        public pdpChiediFlussoRendicontazioneResponse(pdpChiediFlussoRendicontazioneResponseBody Body) {
            this.Body = Body;
        }

    }

    [DataContract(Namespace = "http://easybridge.eu/bridge/")]
    public class pdpChiediFlussoRendicontazioneResponseBody {

        [DataMember(EmitDefaultValue = false, Order = 0)]
        public EasyBridge.Output pdpChiediFlussoRendicontazioneResult;

        public pdpChiediFlussoRendicontazioneResponseBody() { }

        public pdpChiediFlussoRendicontazioneResponseBody(EasyBridge.Output pdpChiediFlussoRendicontazioneResult) {
            this.pdpChiediFlussoRendicontazioneResult = pdpChiediFlussoRendicontazioneResult;
        }

    }

    [MessageContract(IsWrapped = false)]
    public class pdpRecuperaRPT {

        [MessageBodyMember(Name = "pdpRecuperaRPT", Namespace = "http://easybridge.eu/bridge/", Order = 0)]
        public pdpRecuperaRPTBody Body;

        public pdpRecuperaRPT() { }

        public pdpRecuperaRPT(pdpRecuperaRPTBody Body) {
            this.Body = Body;
        }

    }

    [DataContract(Namespace = "http://easybridge.eu/bridge/")]
    public class pdpRecuperaRPTBody {

        [DataMember(EmitDefaultValue = false, Order = 0)]
        public string identificativoDominio;

        [DataMember(EmitDefaultValue = false, Order = 1)]
        public string identificativoBU;

        [DataMember(EmitDefaultValue = false, Order = 2)]
        public byte[] param;

        public pdpRecuperaRPTBody() { }

        public pdpRecuperaRPTBody(string identificativoDominio, string identificativoBU, byte[] param) {
            this.identificativoDominio = identificativoDominio;
            this.identificativoBU = identificativoBU;
            this.param = param;
        }

    }

    [MessageContract(IsWrapped = false)]
    public class pdpRecuperaRPTResponse {

        [MessageBodyMember(Name = "pdpRecuperaRPTResponse", Namespace = "http://easybridge.eu/bridge/", Order = 0)]
        public pdpRecuperaRPTResponseBody Body;

        public pdpRecuperaRPTResponse() { }

        public pdpRecuperaRPTResponse(pdpRecuperaRPTResponseBody Body) {
            this.Body = Body;
        }

    }

    [DataContract(Namespace = "http://easybridge.eu/bridge/")]
    public class pdpRecuperaRPTResponseBody {

        [DataMember(EmitDefaultValue = false, Order = 0)]
        public EasyBridge.Output pdpRecuperaRPTResult;

        public pdpRecuperaRPTResponseBody() { }

        public pdpRecuperaRPTResponseBody(EasyBridge.Output pdpRecuperaRPTResult) {
            this.pdpRecuperaRPTResult = pdpRecuperaRPTResult;
        }

    }

    [MessageContract(IsWrapped = false)]
    public class pdpRichiediStornoRT {

        [MessageBodyMember(Name = "pdpRichiediStornoRT", Namespace = "http://easybridge.eu/bridge/", Order = 0)]
        public pdpRichiediStornoRTBody Body;

        public pdpRichiediStornoRT() { }

        public pdpRichiediStornoRT(pdpRichiediStornoRTBody Body) {
            this.Body = Body;
        }

    }

    [DataContract(Namespace = "http://easybridge.eu/bridge/")]
    public class pdpRichiediStornoRTBody {

        [DataMember(EmitDefaultValue = false, Order = 0)]
        public string identificativoDominio;

        [DataMember(EmitDefaultValue = false, Order = 1)]
        public string identificativoBU;

        [DataMember(EmitDefaultValue = false, Order = 2)]
        public byte[] param;

        public pdpRichiediStornoRTBody() { }

        public pdpRichiediStornoRTBody(string identificativoDominio, string identificativoBU, byte[] param) {
            this.identificativoDominio = identificativoDominio;
            this.identificativoBU = identificativoBU;
            this.param = param;
        }

    }

    [MessageContract(IsWrapped = false)]
    public class pdpRichiediStornoRTResponse {

        [MessageBodyMember(Name = "pdpRichiediStornoRTResponse", Namespace = "http://easybridge.eu/bridge/", Order = 0)]
        public pdpRichiediStornoRTResponseBody Body;

        public pdpRichiediStornoRTResponse() { }

        public pdpRichiediStornoRTResponse(pdpRichiediStornoRTResponseBody Body) {
            this.Body = Body;
        }

    }

    [DataContract(Namespace = "http://easybridge.eu/bridge/")]
    public class pdpRichiediStornoRTResponseBody {

        [DataMember(EmitDefaultValue = false, Order = 0)]
        public EasyBridge.Output pdpRichiediStornoRTResult;

        public pdpRichiediStornoRTResponseBody() { }

        public pdpRichiediStornoRTResponseBody(EasyBridge.Output pdpRichiediStornoRTResult) {
            this.pdpRichiediStornoRTResult = pdpRichiediStornoRTResult;
        }

    }

    [MessageContract(IsWrapped = false)]
    public class pdpChiediSceltaWISP {

        [MessageBodyMember(Name = "pdpChiediSceltaWISP", Namespace = "http://easybridge.eu/bridge/", Order = 0)]
        public pdpChiediSceltaWISPBody Body;

        public pdpChiediSceltaWISP() { }

        public pdpChiediSceltaWISP(pdpChiediSceltaWISPBody Body) {
            this.Body = Body;
        }

    }

    [DataContract(Namespace = "http://easybridge.eu/bridge/")]
    public class pdpChiediSceltaWISPBody {

        [DataMember(EmitDefaultValue = false, Order = 0)]
        public string identificativoDominio;

        [DataMember(EmitDefaultValue = false, Order = 1)]
        public string identificativoBU;

        [DataMember(EmitDefaultValue = false, Order = 2)]
        public byte[] param;

        public pdpChiediSceltaWISPBody() { }

        public pdpChiediSceltaWISPBody(string identificativoDominio, string identificativoBU, byte[] param) {
            this.identificativoDominio = identificativoDominio;
            this.identificativoBU = identificativoBU;
            this.param = param;
        }

    }

    [MessageContract(IsWrapped = false)]
    public class pdpChiediSceltaWISPResponse {

        [MessageBodyMember(Name = "pdpChiediSceltaWISPResponse", Namespace = "http://easybridge.eu/bridge/", Order = 0)]
        public pdpChiediSceltaWISPResponseBody Body;

        public pdpChiediSceltaWISPResponse() { }

        public pdpChiediSceltaWISPResponse(pdpChiediSceltaWISPResponseBody Body) {
            this.Body = Body;
        }

    }

    [DataContract(Namespace = "http://easybridge.eu/bridge/")]
    public class pdpChiediSceltaWISPResponseBody {

        [DataMember(EmitDefaultValue = false, Order = 0)]
        public EasyBridge.Output pdpChiediSceltaWISPResult;

        public pdpChiediSceltaWISPResponseBody() { }

        public pdpChiediSceltaWISPResponseBody(EasyBridge.Output pdpChiediSceltaWISPResult) {
            this.pdpChiediSceltaWISPResult = pdpChiediSceltaWISPResult;
        }

    }

    [MessageContract(IsWrapped = false)]
    public class pdpChiediStatoRPT {

        [MessageBodyMember(Name = "pdpChiediStatoRPT", Namespace = "http://easybridge.eu/bridge/", Order = 0)]
        public pdpChiediStatoRPTBody Body;

        public pdpChiediStatoRPT() { }

        public pdpChiediStatoRPT(pdpChiediStatoRPTBody Body) {
            this.Body = Body;
        }

    }

    [DataContract(Namespace = "http://easybridge.eu/bridge/")]
    public class pdpChiediStatoRPTBody {

        [DataMember(EmitDefaultValue = false, Order = 0)]
        public string identificativoDominio;

        [DataMember(EmitDefaultValue = false, Order = 1)]
        public string identificativoBU;

        [DataMember(EmitDefaultValue = false, Order = 2)]
        public byte[] param;

        public pdpChiediStatoRPTBody() { }

        public pdpChiediStatoRPTBody(string identificativoDominio, string identificativoBU, byte[] param) {
            this.identificativoDominio = identificativoDominio;
            this.identificativoBU = identificativoBU;
            this.param = param;
        }

    }

    [MessageContract(IsWrapped = false)]
    public class pdpChiediStatoRPTResponse {

        [MessageBodyMember(Name = "pdpChiediStatoRPTResponse", Namespace = "http://easybridge.eu/bridge/", Order = 0)]
        public pdpChiediStatoRPTResponseBody Body;

        public pdpChiediStatoRPTResponse() { }

        public pdpChiediStatoRPTResponse(pdpChiediStatoRPTResponseBody Body) {
            this.Body = Body;
        }

    }

    [DataContract(Namespace = "http://easybridge.eu/bridge/")]
    public class pdpChiediStatoRPTResponseBody {

        [DataMember(EmitDefaultValue = false, Order = 0)]
        public EasyBridge.Output pdpChiediStatoRPTResult;

        public pdpChiediStatoRPTResponseBody() { }

        public pdpChiediStatoRPTResponseBody(EasyBridge.Output pdpChiediStatoRPTResult) {
            this.pdpChiediStatoRPTResult = pdpChiediStatoRPTResult;
        }

    }

    [MessageContract(IsWrapped = false)]
    public class dpVerificaPagamentoInAttesa {

        [MessageBodyMember(Name = "dpVerificaPagamentoInAttesa", Namespace = "http://easybridge.eu/bridge/", Order = 0)]
        public dpVerificaPagamentoInAttesaBody Body;

        public dpVerificaPagamentoInAttesa() { }

        public dpVerificaPagamentoInAttesa(dpVerificaPagamentoInAttesaBody Body) {
            this.Body = Body;
        }

    }

    [DataContract(Namespace = "http://easybridge.eu/bridge/")]
    public class dpVerificaPagamentoInAttesaBody {

        [DataMember(EmitDefaultValue = false, Order = 0)]
        public string identificativoDominio;

        [DataMember(EmitDefaultValue = false, Order = 1)]
        public byte[] param;

        public dpVerificaPagamentoInAttesaBody() { }

        public dpVerificaPagamentoInAttesaBody(string identificativoDominio, byte[] param) {
            this.identificativoDominio = identificativoDominio;
            this.param = param;
        }

    }

    [MessageContract(IsWrapped = false)]
    public class dpVerificaPagamentoInAttesaResponse {

        [MessageBodyMember(Name = "dpVerificaPagamentoInAttesaResponse", Namespace = "http://easybridge.eu/bridge/", Order = 0)]
        public dpVerificaPagamentoInAttesaResponseBody Body;

        public dpVerificaPagamentoInAttesaResponse() { }

        public dpVerificaPagamentoInAttesaResponse(dpVerificaPagamentoInAttesaResponseBody Body) {
            this.Body = Body;
        }

    }

    [DataContract(Namespace = "http://easybridge.eu/bridge/")]
    public class dpVerificaPagamentoInAttesaResponseBody {

        [DataMember(EmitDefaultValue = false, Order = 0)]
        public EasyBridge.OutputVerificaPagamentoInAttesa dpVerificaPagamentoInAttesaResult;

        public dpVerificaPagamentoInAttesaResponseBody() { }

        public dpVerificaPagamentoInAttesaResponseBody(EasyBridge.OutputVerificaPagamentoInAttesa dpVerificaPagamentoInAttesaResult) {
            this.dpVerificaPagamentoInAttesaResult = dpVerificaPagamentoInAttesaResult;
        }

    }

    [MessageContract(IsWrapped = false)]
    public class pdpInviaRPT {

        [MessageBodyMember(Name = "pdpInviaRPT", Namespace = "http://easybridge.eu/bridge/", Order = 0)]
        public pdpInviaRPTBody Body;

        public pdpInviaRPT() { }

        public pdpInviaRPT(pdpInviaRPTBody Body) {
            this.Body = Body;
        }

    }

    [DataContract(Namespace = "http://easybridge.eu/bridge/")]
    public class pdpInviaRPTBody {

        [DataMember(EmitDefaultValue = false, Order = 0)]
        public string identificativoDominio;

        [DataMember(EmitDefaultValue = false, Order = 1)]
        public string identificativoBU;

        [DataMember(EmitDefaultValue = false, Order = 2)]
        public byte[] param;

        public pdpInviaRPTBody() { }

        public pdpInviaRPTBody(string identificativoDominio, string identificativoBU, byte[] param) {
            this.identificativoDominio = identificativoDominio;
            this.identificativoBU = identificativoBU;
            this.param = param;
        }

    }

    [MessageContract(IsWrapped = false)]
    public class pdpInviaRPTResponse {

        [MessageBodyMember(Name = "pdpInviaRPTResponse", Namespace = "http://easybridge.eu/bridge/", Order = 0)]
        public pdpInviaRPTResponseBody Body;

        public pdpInviaRPTResponse() { }

        public pdpInviaRPTResponse(pdpInviaRPTResponseBody Body) {
            this.Body = Body;
        }

    }

    [DataContract(Namespace = "http://easybridge.eu/bridge/")]
    public class pdpInviaRPTResponseBody {

        [DataMember(EmitDefaultValue = false, Order = 0)]
        public EasyBridge.Output pdpInviaRPTResult;

        public pdpInviaRPTResponseBody() { }

        public pdpInviaRPTResponseBody(EasyBridge.Output pdpInviaRPTResult) {
            this.pdpInviaRPTResult = pdpInviaRPTResult;
        }

    }

    [MessageContract(IsWrapped = false)]
    public class pdpVerificaMarcaDaBolloDigitale {

        [MessageBodyMember(Name = "pdpVerificaMarcaDaBolloDigitale", Namespace = "http://easybridge.eu/bridge/", Order = 0)]
        public pdpVerificaMarcaDaBolloDigitaleBody Body;

        public pdpVerificaMarcaDaBolloDigitale() { }

        public pdpVerificaMarcaDaBolloDigitale(pdpVerificaMarcaDaBolloDigitaleBody Body) {
            this.Body = Body;
        }

    }

    [DataContract(Namespace = "http://easybridge.eu/bridge/")]
    public class pdpVerificaMarcaDaBolloDigitaleBody {

        [DataMember(EmitDefaultValue = false, Order = 0)]
        public string identificativoDominio;

        [DataMember(EmitDefaultValue = false, Order = 1)]
        public string identificativoBU;

        [DataMember(EmitDefaultValue = false, Order = 2)]
        public byte[] param;

        public pdpVerificaMarcaDaBolloDigitaleBody() { }

        public pdpVerificaMarcaDaBolloDigitaleBody(string identificativoDominio, string identificativoBU, byte[] param) {
            this.identificativoDominio = identificativoDominio;
            this.identificativoBU = identificativoBU;
            this.param = param;
        }

    }

    [MessageContract(IsWrapped = false)]
    public class pdpVerificaMarcaDaBolloDigitaleResponse {

        [MessageBodyMember(Name = "pdpVerificaMarcaDaBolloDigitaleResponse", Namespace = "http://easybridge.eu/bridge/", Order = 0)]
        public pdpVerificaMarcaDaBolloDigitaleResponseBody Body;

        public pdpVerificaMarcaDaBolloDigitaleResponse() { }

        public pdpVerificaMarcaDaBolloDigitaleResponse(pdpVerificaMarcaDaBolloDigitaleResponseBody Body) {
            this.Body = Body;
        }

    }

    [DataContract(Namespace = "http://easybridge.eu/bridge/")]
    public class pdpVerificaMarcaDaBolloDigitaleResponseBody {

        [DataMember(EmitDefaultValue = false, Order = 0)]
        public EasyBridge.Output pdpVerificaMarcaDaBolloDigitaleResult;

        public pdpVerificaMarcaDaBolloDigitaleResponseBody() { }

        public pdpVerificaMarcaDaBolloDigitaleResponseBody(EasyBridge.Output pdpVerificaMarcaDaBolloDigitaleResult) {
            this.pdpVerificaMarcaDaBolloDigitaleResult = pdpVerificaMarcaDaBolloDigitaleResult;
        }

    }

    [MessageContract(IsWrapped = false)]
    public class pdpRichiediAvviso {

        [MessageBodyMember(Name = "pdpRichiediAvviso", Namespace = "http://easybridge.eu/bridge/", Order = 0)]
        public pdpRichiediAvvisoBody Body;

        public pdpRichiediAvviso() { }

        public pdpRichiediAvviso(pdpRichiediAvvisoBody Body) {
            this.Body = Body;
        }

    }

    [DataContract(Namespace = "http://easybridge.eu/bridge/")]
    public class pdpRichiediAvvisoBody {

        [DataMember(EmitDefaultValue = false, Order = 0)]
        public string identificativoDominio;

        [DataMember(EmitDefaultValue = false, Order = 1)]
        public string identificativoBU;

        [DataMember(EmitDefaultValue = false, Order = 2)]
        public byte[] param;

        public pdpRichiediAvvisoBody() { }

        public pdpRichiediAvvisoBody(string identificativoDominio, string identificativoBU, byte[] param) {
            this.identificativoDominio = identificativoDominio;
            this.identificativoBU = identificativoBU;
            this.param = param;
        }

        public pdpRichiediAvvisoBody(string identificativoDominio, string identificativoBU, string iuv) {
            this.identificativoDominio = identificativoDominio;
            this.identificativoBU = identificativoBU;

            var obj = new InfoGroup.ct0000000028_pdpRichiediAvviso() {
                identificativoUnivocoVersamento = iuv
            };

            DataContractSerializer serializer = new DataContractSerializer(typeof(InfoGroup.ct0000000028_pdpRichiediAvviso));

            using (MemoryStream stream = new MemoryStream()) {
                serializer.WriteObject(stream, obj);

                this.param = stream.ToArray();
            }
        }

    }

    [MessageContract(IsWrapped = false)]
    public class pdpRichiediAvvisoResponse {

        [MessageBodyMember(Name = "pdpRichiediAvvisoResponse", Namespace = "http://easybridge.eu/bridge/", Order = 0)]
        public pdpRichiediAvvisoResponseBody Body;

        public pdpRichiediAvvisoResponse() { }

        public pdpRichiediAvvisoResponse(pdpRichiediAvvisoResponseBody Body) {
            this.Body = Body;
        }

    }

    [DataContract(Namespace = "http://easybridge.eu/bridge/")]
    public class pdpRichiediAvvisoResponseBody {

        [DataMember(EmitDefaultValue = false, Order = 0)]
        public EasyBridge.Output pdpRichiediAvvisoResult;

        public pdpRichiediAvvisoResponseBody() { }

        public pdpRichiediAvvisoResponseBody(EasyBridge.Output pdpRichiediAvvisoResult) {
            this.pdpRichiediAvvisoResult = pdpRichiediAvvisoResult;
        }

        public InfoGroup.ct0000000028_pdpRichiediAvvisoResult Result {
            get {
                if (pdpRichiediAvvisoResult == null || pdpRichiediAvvisoResult.param == null) return null;

                var serializer = new DataContractSerializer(typeof(EasyBridge.pdpRichiediAvvisoResult));

                object obj;
                using (var stream = new MemoryStream(pdpRichiediAvvisoResult.param)) {
                    obj = serializer.ReadObject(stream);
                }

                return obj as InfoGroup.ct0000000028_pdpRichiediAvvisoResult;
            }
        }

    }

    [MessageContract(IsWrapped = false)]
    public class pdpGeneraRPT {

        [MessageBodyMember(Name = "pdpGeneraRPT", Namespace = "http://easybridge.eu/bridge/", Order = 0)]
        public pdpGeneraRPTBody Body;

        public pdpGeneraRPT() { }

        public pdpGeneraRPT(pdpGeneraRPTBody Body) {
            this.Body = Body;
        }

    }

    [DataContract(Namespace = "http://easybridge.eu/bridge/")]
    public class pdpGeneraRPTBody {

        [DataMember(EmitDefaultValue = false, Order = 0)]
        public string identificativoDominio;

        [DataMember(EmitDefaultValue = false, Order = 1)]
        public string identificativoBU;

        [DataMember(EmitDefaultValue = false, Order = 2)]
        public byte[] param;

        public pdpGeneraRPTBody() { }

        public pdpGeneraRPTBody(string identificativoDominio, string identificativoBU, byte[] param) {
            this.identificativoDominio = identificativoDominio;
            this.identificativoBU = identificativoBU;
            this.param = param;
        }
 
    }

    [MessageContract(IsWrapped = false)]
    public class pdpGeneraRPTResponse {

        [MessageBodyMember(Name = "pdpGeneraRPTResponse", Namespace = "http://easybridge.eu/bridge/", Order = 0)]
        public pdpGeneraRPTResponseBody Body;

        public pdpGeneraRPTResponse() { }

        public pdpGeneraRPTResponse(pdpGeneraRPTResponseBody Body) {
            this.Body = Body;
        }

    }

    [DataContract(Namespace = "http://easybridge.eu/bridge/")]
    public class pdpGeneraRPTResponseBody {

        [DataMember(EmitDefaultValue = false, Order = 0)]
        public EasyBridge.Output pdpGeneraRPTResult;

        public pdpGeneraRPTResponseBody() { }

        public pdpGeneraRPTResponseBody(EasyBridge.Output pdpGeneraRPTResult) {
            this.pdpGeneraRPTResult = pdpGeneraRPTResult;
        }

    }


}