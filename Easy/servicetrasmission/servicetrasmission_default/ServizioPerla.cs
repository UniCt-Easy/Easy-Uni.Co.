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
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using System.Text;
using System.Threading.Tasks;
using servicetrasmission_default.service;


namespace servicetrasmission_default {
    public class EServizio {
        private static string URL = "http://www.perlapa.gov.it/AnagrafePrestazioni";

     
        public static AnagrafePrestazioni Create(string user, string password) {
            //con TLS12 da Could not establish secure channel for SSL/TLS with authority 'solutionpa-coll.intesasanpaolo.com'.
            //ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls;

            //ServicePointManager.ServerCertificateValidationCallback += new RemoteCertificateValidationCallback(
            //    (object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) => {
            //        if (sslPolicyErrors == SslPolicyErrors.None) return true;
            //        return false;
            //    }
            //);
            //var binding = new CustomBinding(
            //    new TextMessageEncodingBindingElement(MessageVersion.Soap12, Encoding.UTF8),
            //    new HttpsTransportBindingElement() {
            //        AuthenticationScheme = AuthenticationSchemes.Basic,
            //        MaxBufferSize = Int32.MaxValue,
            //        MaxReceivedMessageSize = Int32.MaxValue
            //    }
            //);


            //AddressHeader hPwd = AddressHeader.CreateAddressHeader("Authorization", "", "Basic " +
            //    Convert.ToBase64String(ASCIIEncoding.ASCII.GetBytes(user ?? USERNAME + ":" + password ?? PASSWORD)));
            var address = new EndpointAddress(URL);

            //ClientCredentials cred = new ClientCredentials();
            //cred.UserName.UserName = user ?? USERNAME;
            //cred.UserName.Password = password ?? PASSWORD;



            var factory = new ChannelFactory<AnagrafePrestazioni>();

            //var defaultCredentials = factory.Endpoint.EndpointBehaviors[typeof(ClientCredentials)];
            //factory.Endpoint.Behaviors.Remove(defaultCredentials); //remove default ones
            //factory.Endpoint.Behaviors.Clear();
            //factory.Endpoint.Behaviors.Add(cred); //add required ones
            //factory.Endpoint.Behaviors.Add(new AuthenticationHeaderBehavior(user ?? USERNAME, password ?? PASSWORD));
            //factory.Endpoint.Behaviors.Add(new CleanNameSpacesBehavior("i"));
            return factory.CreateChannel(address);
        }


    }
    public class AuthenticationHeader :IClientMessageInspector {
        string authValue;
        public AuthenticationHeader(string user, string password) {
            authValue = "Basic " + Convert.ToBase64String(ASCIIEncoding.ASCII.GetBytes(user + ":" + password));
        }
        public void AfterReceiveReply(ref Message reply, object correlationState) {
        }

        public object BeforeSendRequest(ref Message request, IClientChannel channel) {
            object httpRequestMessageObject;
            if (request.Properties.TryGetValue(
                HttpRequestMessageProperty.Name, out httpRequestMessageObject)) {
                var httpRequestMessage = httpRequestMessageObject as HttpRequestMessageProperty;

                if (string.IsNullOrWhiteSpace(httpRequestMessage.Headers["Authorization"])) {
                    httpRequestMessage.Headers["Authorization"] = authValue;
                }
            }
            else {
                var httpRequestMessage = new HttpRequestMessageProperty();
                httpRequestMessage.Headers.Add("Authorization", authValue);

                request.Properties.Add(HttpRequestMessageProperty.Name, httpRequestMessage);
            }
            return null;
        }
    }

    public class AuthenticationHeaderBehavior :IEndpointBehavior {
        private readonly string user;
        private readonly string password;
        public AuthenticationHeaderBehavior(string usr, string pwd) {
            this.user = usr;
            this.password = pwd;
        }

        public void AddBindingParameters(ServiceEndpoint endpoint, BindingParameterCollection bindingParameters) {
        }

        public void ApplyClientBehavior(ServiceEndpoint endpoint, ClientRuntime clientRuntime) {
            clientRuntime.MessageInspectors.Add(new AuthenticationHeader(user, password));
        }

        public void ApplyDispatchBehavior(ServiceEndpoint endpoint, EndpointDispatcher endpointDispatcher) {
        }

        public void Validate(ServiceEndpoint endpoint) {
        }
    }
}
