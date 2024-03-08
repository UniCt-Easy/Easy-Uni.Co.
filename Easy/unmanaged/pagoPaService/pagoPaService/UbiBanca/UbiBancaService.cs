
/*
Easy
Copyright (C) 2024 Università degli Studi di Catania (www.unict.it)
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


namespace UbiBancaService {
    public class Servizio {
        public static global::UbiBancaService.gestorePosizioni Create() {
            return Create(null, null, null, true);

        }

        public static gestorePosizioni Create(string userName, string password, string URL, bool test) {
            if (URL == null) URL = "https://cuniba.ubibanca.it/gestoreposizioni/services/soap/gestorePosizioni?";
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            ServicePointManager.ServerCertificateValidationCallback +=
                (sender, certificate, chain, sslPolicyErrors) =>
                {
                    String rootCAThumbprint =
                        "786A74AC76AB147F9C6A3050BA9EA87EFE9ACE3C"; // write your code to get your CA's thumbprint
                                                                    // CN=[DESARROLLO] Global Chambersign Root - 2008, O=AC Camerfirma S.A.,...
                                                                    // remove this line if commercial CAs are not allowed to issue certificate for your service.
                    if ((sslPolicyErrors & (SslPolicyErrors.None)) > 0) {
                        return true;
                    }

                    if (
                        (sslPolicyErrors & (SslPolicyErrors.RemoteCertificateNameMismatch)) > 0 ||
                        (sslPolicyErrors & (SslPolicyErrors.RemoteCertificateNotAvailable)) > 0
                    ) {
                        return false;
                    }

                    //X509Certificate2 projectedRootCert = chain.ChainElements[chain.ChainElements.Count - 1].Certificate;
                    //if (projectedRootCert.Thumbprint != rootCAThumbprint) {
                    //    return false;
                    //}
                    return true;
                };
            var binding = new CustomBinding(
                new TextMessageEncodingBindingElement(MessageVersion.Soap12, Encoding.UTF8),
                new HttpsTransportBindingElement() {
                    AuthenticationScheme = AuthenticationSchemes.Basic,
                    MaxBufferSize = int.MaxValue,
                    MaxReceivedMessageSize = int.MaxValue
                }
            );

            //var hPwd = AddressHeader.CreateAddressHeader("Authorization", "", "Basic " +
            //                                                      Convert.ToBase64String(
            //                                                          Encoding.ASCII.GetBytes(
            //                                                              (userName) + ":" +
            //                                                              (password))));
            //var binding = new BasicHttpBinding(BasicHttpSecurityMode.Transport);
            //binding.Security.Transport.ClientCredentialType = HttpClientCredentialType.Certificate;

            var address = new EndpointAddress(new Uri(URL));
            var cred = new ClientCredentials();
            cred.UserName.UserName = userName;
            cred.UserName.Password = password;
            
            var factory = new ChannelFactory<gestorePosizioni>(binding, address);
            var defaultCredentials = factory.Endpoint.EndpointBehaviors[typeof(ClientCredentials)];
            factory.Endpoint.Behaviors.Remove(defaultCredentials); //remove default ones
            factory.Endpoint.Behaviors.Clear();
            factory.Endpoint.Behaviors.Add(cred); //add required ones
            factory.Endpoint.Behaviors.Add(new CleanNameSpacesBehavior("xsi", "xsd", "iuv"));//"xsi", "xsd","xsd1"

            if (test) {
                factory.Credentials.ServiceCertificate.DefaultCertificate = pagoPaService.PagoPaService.getCertificateByThumbPrint(StoreName.My, StoreLocation.CurrentUser, "6b9233c509e2d2a4d0dafa6207bc5c07720716a7");
                factory.Credentials.ClientCertificate.Certificate = pagoPaService.PagoPaService.getCertificateByThumbPrint(StoreName.My, StoreLocation.CurrentUser, "3ed8765d55f336bc43f08e0decd9573c64866049");
            }
            else {
                factory.Credentials.ServiceCertificate.DefaultCertificate = pagoPaService.PagoPaService.getCertificateByThumbPrint(StoreName.My, StoreLocation.CurrentUser, "a32787f1f3d287c96030cd2ad17492344af5c575");
                factory.Credentials.ClientCertificate.Certificate = pagoPaService.PagoPaService.getCertificateByThumbPrint(StoreName.My, StoreLocation.CurrentUser, "3ed8765d55f336bc43f08e0decd9573c64866049");
            }
            factory.Endpoint.Behaviors.Add(new AuthenticationHeaderBehavior(userName, password));

            var vs = factory.Endpoint.EndpointBehaviors.FirstOrDefault((i) => i.GetType().Namespace == "Microsoft.VisualStudio.Diagnostics.ServiceModelSink");
            if (vs != null) {
                factory.Endpoint.Behaviors.Remove(vs);
            }

            //return factory.CreateChannel(address);


            var channel = factory.CreateChannel(address);

            return channel;
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
}
