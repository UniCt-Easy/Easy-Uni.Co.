
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
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using System.Text;
using System.Xml;
using System.IO;
using XmlFormatter;
using System.Threading.Tasks;
using System.Xml.Serialization;
using genericSerializer;
using auth=pagoPaService.AuthPASoap;
using pay =pagoPaService.PayPA;
using ticket = pagoPaService.TicketWebSoap;

namespace Valtellinese {
    public class Servizio {
       

        public static pay.PayPA CreatePayPa() {
            return CreatePayPa(null, null, null);
        }
        public static ticket.TicketWebSoap CreateTicketWebSoap() {
            return CreateTicketWebSoap(null, null, null);
        }
        public static auth.AuthPASoap CreateAuthPaSoap() {
            return CreateAuthPaSoap(null, null, null);
        }
      
        public static pay.PayPA CreatePayPa(string userName, string password, string URL) {
            if (URL == null) URL = "https://service.pmpay.it/";
            URL += "payPA/services/PayPA";
            //https://<ADDR>/authPA/services/AuthPASoap?wsdl   reale https://service.pmpay.it/ticketWeb/services/TicketWebSoap?wsdl
            //https://<ADDR>/payPA/services/PayPA?wsdl          reale https://service.pmpay.it/pagoPMPAY/services/PagoPMPAY?wsdl
            var binding = new BasicHttpsBinding();

            var address = new EndpointAddress(URL);

            var factory =
                new ChannelFactory<pay.PayPA>(binding, address) {
                    Credentials = {
                        UserName = {
                            UserName = userName,
                            Password = password
                        }
                    }
                };
            var cleaner = new CleanNameSpacesBehavior("xsi", "xsd");
            var repl =
                new Dictionary<string, string> {
                    [" xmlns:ns1=\"http://pmpay.it/ws/payPA/\""] = "",
                    ["ns1:response"] = "response"
                };
            
            cleaner.doCleanResponse("<ns1:response xmlns:ns1=\"http://pmpay.it/ws/payPA/\">", repl);

            factory.Endpoint.Behaviors.Add(cleaner);
            var vs = factory.Endpoint.EndpointBehaviors.FirstOrDefault((i) => i.GetType().Namespace == "Microsoft.VisualStudio.Diagnostics.ServiceModelSink");
            if (vs != null) {
                factory.Endpoint.Behaviors.Remove(vs);
            }

            return factory.CreateChannel(address);
        }

        public static ticket.TicketWebSoap CreateTicketWebSoap(string userName, string password, string URL) {
            if (URL == null) URL = "https://service.pmpay.it/";  
            URL += "payPA/services/PayPA";
            //https://<ADDR>/authPA/services/AuthPASoap?wsdl   reale https://service.pmpay.it/ticketWeb/services/TicketWebSoap?wsdl
            //https://<ADDR>/payPA/services/PayPA?wsdl          reale https://service.pmpay.it/pagoPMPAY/services/PagoPMPAY?wsdl
            var binding = new BasicHttpsBinding();
            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
            var address = new EndpointAddress(URL);

            var factory =
                new ChannelFactory<ticket.TicketWebSoap>(binding, address) {
                    Credentials = {
                        UserName = {
                            UserName = userName,
                            Password = password
                        }
                    }
                };

            factory.Endpoint.Behaviors.Add(new CleanNameSpacesBehavior("xsi", "xsd"));
            var vs = factory.Endpoint.EndpointBehaviors.FirstOrDefault((i) => i.GetType().Namespace == "Microsoft.VisualStudio.Diagnostics.ServiceModelSink");
            if (vs != null) {
                factory.Endpoint.Behaviors.Remove(vs);
            }

            return factory.CreateChannel(address);
        }

        public static auth.AuthPASoap CreateAuthPaSoap(string userName, string password, string URL) {
            if (URL == null) URL = "https://service.pmpay.it/"; 
            URL += "authPA/services/AuthPASoap";
            //https://<ADDR>/authPA/services/AuthPASoap?wsdl   reale https://service.pmpay.it/ticketWeb/services/TicketWebSoap?wsdl
            //https://<ADDR>/payPA/services/PayPA?wsdl          reale https://service.pmpay.it/pagoPMPAY/services/PagoPMPAY?wsdl
            //
            //WSHttpBinding binding = new WSHttpBinding();
            //binding.Security.Mode = SecurityMode.Transport;
            //binding.Security.Transport.ClientCredentialType =
            //HttpClientCredentialType.Basic;
            var binding = new BasicHttpsBinding();
            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls11|SecurityProtocolType.Tls12;
            var address = new EndpointAddress(URL);

            var factory =
                new ChannelFactory<auth.AuthPASoap>(binding, address) {
                    Credentials = {
                        UserName = {
                            UserName = userName,
                            Password = password
                        }
                    }
                };


            factory.Endpoint.Behaviors.Add(new CleanNameSpacesBehavior("xsi", "xsd"));
            var vs = factory.Endpoint.EndpointBehaviors.FirstOrDefault((i) => i.GetType().Namespace == "Microsoft.VisualStudio.Diagnostics.ServiceModelSink");
            if (vs != null) {
                factory.Endpoint.Behaviors.Remove(vs);
            }

            return factory.CreateChannel(address);
        }

        public static WSLOGIN_RESPONSE authGetTicket(auth.AuthPASoap authService, WSLOGIN_REQUEST req) {
            var ticketReq = new auth.GetTicketRequest(req);
            var result = authService.GetTicket(ticketReq);
            var resBody = result.Body;
            return GenericSerializer.fromXml<WSLOGIN_RESPONSE>(resBody.GetTicketResult);
        }

        public static RICHIEDI_IUV_RESPONSE authGetIuv(auth.AuthPASoap authService, richiestaIUV req, headerRichiestaIUV head) {
         
            var getIuvReq = new auth.GetIUVRequest(req,head);
            var result = authService.GetIUV(getIuvReq);
            var resBody = result.Body;
            return GenericSerializer.fromXml<RICHIEDI_IUV_RESPONSE>(resBody.GetIUVResult);
        }

        public static PAGAMENTO_RESPONSE PayPAPagamento(pay.PayPA Service, PAGAMENTO_REQUEST req, out string error) {
            error = "";
            try {
                var getPagamentoReq = new pay.PagamentoRequest(req) ;
                var result = Service.Pagamento(getPagamentoReq);
                var resBody = result.response;
                if (resBody != null)
                    return GenericSerializer.fromXml<PAGAMENTO_RESPONSE>(resBody.PagamentoResult);
            }
            catch (FaultException exception) {
                error = exception.ToString();
                return null;
            }
            return null;
        }

        public static PAGAMENTO_RESPONSE PayPAPagamentoEsistente(pay.PayPA Service, PAGAMENTOESISTENTE_REQUEST req, out string error) {
            error = "";
            try {
                var getPagamentoReq = new pay.PagamentoEsistenteRequest(req);
                var result = Service.PagamentoEsistente(getPagamentoReq);
                var resBody = result.response;
                if (resBody!=null)
                 return GenericSerializer.fromXml<PAGAMENTO_RESPONSE>(resBody.PagamentoResult);
            }
            catch (FaultException exception) {
                error = exception.ToString();
                return null;
            }
            return null;
        }

    }




}

namespace pagoPaService.AuthPASoap {
    using Valtellinese;
    using genericSerializer;
    public partial class GetTicketRequest {
        public GetTicketRequest(WSLOGIN_REQUEST req) {
            Body= new GetTicketRequestBody(req.toXml());
        }
    }
    public partial class GetIUVRequest {
        public GetIUVRequest(richiestaIUV req, headerRichiestaIUV head) {
            var iuvReq = new RICHIEDI_IUV_REQUEST {
                richiestaIUV = req,
                headerRichiestaIUV = head
            };
            Body= new GetIUVRequestBody(iuvReq.toXml());  
        }
    }
}



namespace pagoPaService.PayPA {
    using Valtellinese;
    using genericSerializer;
    public partial class PagamentoRequest {

        public PagamentoRequest(PAGAMENTO_REQUEST req) {
           Body = new PagamentoRequestBody(req.toXml());
        }
    }


    public partial class PagamentoEsistenteRequest {

        public PagamentoEsistenteRequest(PAGAMENTOESISTENTE_REQUEST req) {
            Body = new PagamentoEsistenteRequestBody(req.toXml());
        }
    }
}

