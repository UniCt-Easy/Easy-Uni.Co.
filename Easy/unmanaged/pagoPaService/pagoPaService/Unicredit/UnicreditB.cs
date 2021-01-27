
/*
Easy
Copyright (C) 2021 UniversitÃ  degli Studi di Catania (www.unict.it)
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
using System.ServiceModel;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;           
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;
using System.Security.Cryptography.X509Certificates;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using System.Xml;
using System.IO;
using XmlFormatter;
using genericSerializer;
using funzioni_configurazione;
using metadatalibrary;
 
using pay =pagoPaService.PayPA;
using ticket = pagoPaService.TicketWebSoap;
 
namespace unicredit_b {
    public class Servizio {
       
 
        public static PaInviaCarrelloPosizioni Create() {
            return Create(null, null, null);

        }

        public static PaInviaCarrelloPosizioni Create(string userName, string password, string URL) {
	        //con TLS12 da Could not establish secure channel for SSL/TLS with authority 'solutionpa-coll.intesasanpaolo.com'.
	        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls;

	        if (userName == null) userName = "**********"; // unicampania
	        if (password == null) password = "**********";
	        if (URL == null) URL = "https://tst.pasemplice.eu/connettorenodo/services/soap/paInviaCarrelloPosizioni";

	        var binding = new CustomBinding(
		        new TextMessageEncodingBindingElement(MessageVersion.Soap11, Encoding.UTF8),
		        new HttpsTransportBindingElement() {
			        AuthenticationScheme = AuthenticationSchemes.Basic,
			        MaxBufferSize = int.MaxValue,
			        MaxReceivedMessageSize = int.MaxValue
		        }
	        );

            
	        var hPwd = AddressHeader.CreateAddressHeader("Authorization", "http://easybridge.eu/bridge/", 
					"Basic " +Convert.ToBase64String(Encoding.ASCII.GetBytes(userName + ":" +password)));
	        var address = new EndpointAddress(new Uri(URL), hPwd);



	        var cred = new ClientCredentials();
	        cred.UserName.UserName = userName;
	        cred.UserName.Password = password;

	        var factory = new ChannelFactory<PaInviaCarrelloPosizioni>(binding, address);

	        var defaultCredentials = factory.Endpoint.EndpointBehaviors[typeof(ClientCredentials)];
	        factory.Endpoint.Behaviors.Remove(defaultCredentials); //remove default ones

	        factory.Endpoint.Behaviors.Clear();
	        factory.Endpoint.Behaviors.Add(cred); //add required ones
	        factory.Endpoint.Behaviors.Add(new AuthenticationHeaderBehavior(userName, password ));
	        //factory.Endpoint.Behaviors.Add(new CleanNameSpacesBehavior("xsi", "xsd"));
	        
	        var channel = factory.CreateChannel();
	        return channel;
        }

 
    }

    public class AuthenticationHeader : IClientMessageInspector {
        private readonly string _authValue;

        public AuthenticationHeader(string user, string password) {
            _authValue = "Basic " + Convert.ToBase64String(Encoding.ASCII.GetBytes(user + ":" + password));
        }

        public void AfterReceiveReply(ref Message reply, object correlationState) {
        }

        public object BeforeSendRequest(ref Message request, IClientChannel channel) {
            object httpRequestMessageObject;
            if (request.Properties.TryGetValue(
                HttpRequestMessageProperty.Name, out httpRequestMessageObject)) {
                var httpRequestMessage = httpRequestMessageObject as HttpRequestMessageProperty;

                if (string.IsNullOrWhiteSpace(httpRequestMessage.Headers["Authorization"])) {
                    httpRequestMessage.Headers["Authorization"] = _authValue;
                }
            }
            else {
                var httpRequestMessage = new HttpRequestMessageProperty();
                httpRequestMessage.Headers.Add("Authorization", _authValue);

                request.Properties.Add(HttpRequestMessageProperty.Name, httpRequestMessage);
            }

            return null;
        }
    }

    public class AuthenticationHeaderBehavior : IEndpointBehavior {
        private readonly string _user;
        private readonly string _password;

        public AuthenticationHeaderBehavior(string usr, string pwd) {
            _user = usr;
            _password = pwd;
        }

        public void AddBindingParameters(ServiceEndpoint endpoint, BindingParameterCollection bindingParameters) {
        }

        public void ApplyClientBehavior(ServiceEndpoint endpoint, ClientRuntime clientRuntime) {
            clientRuntime.MessageInspectors.Add(new AuthenticationHeader(_user, _password));
        }

        public void ApplyDispatchBehavior(ServiceEndpoint endpoint, EndpointDispatcher endpointDispatcher) {
        }

        public void Validate(ServiceEndpoint endpoint) {
        }
    }
}