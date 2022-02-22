
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
using XmlFormatter;
using serviceBancaIntesa;
	//WEBS_DataProviderInterfacePort

namespace serviceBancaIntesa {
	  public class EServizio {
        private string URL =
            "https://solutionpa-coll.intesasanpaolo.com/IntermediarioPAWebService/WEBSDataProviderInterface";

        private static readonly string Username = "nodoInfogroup";
        private static readonly string Password = "%r6bv#D@pIn";

        public WEBS_DataProviderInterfacePort Create(string user, string password, string url) {
            return Create(user, password, url, false);
        }

        public WEBS_DataProviderInterfacePort Create(string user, string password, string url, bool test) {
            //con TLS12 da Could not establish secure channel for SSL/TLS with authority 'solutionpa-coll.intesasanpaolo.com'.
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            ServicePointManager.ServerCertificateValidationCallback +=
                (sender, certificate, chain, sslPolicyErrors) => {
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

                    // get last chain element that should contain root CA certificate
                    // but this may not be the case in partial chains
                    X509Certificate2 projectedRootCert = chain.ChainElements[chain.ChainElements.Count - 1].Certificate;
                    if (projectedRootCert.Thumbprint != rootCAThumbprint) {
                        return false;
                    }

                    //X509Certificate2 firstRootCert = chain.ChainElements[0].Certificate;
                    //if (firstRootCert.Thumbprint != "3ED8765D55F336BC43F08E0DECD9573C64866049") {//"CN=solutionpa-coll.intesasanpaolo.com, O=Intesa Sanpaolo S.p.A. - Test SSL, S=Italia, C=IT"
                    //    return false;
                    //}

                    // execute certificate chaining engine and ignore only "UntrustedRoot" error
                    //X509Chain customChain = new X509Chain {
                    //    ChainPolicy = {
                    //        VerificationFlags = X509VerificationFlags.AllFlags
                    //    }
                    //};
                    //Boolean retValue = customChain.Build(chain.ChainElements[0].Certificate);
                    //// RELEASE unmanaged resources behind X509Chain class.
                    //customChain.Reset();
                    return true;

                    //return sslPolicyErrors == SslPolicyErrors.None;
                };
            var binding = new CustomBinding(
                new TextMessageEncodingBindingElement(MessageVersion.Soap12, Encoding.UTF8),
                new HttpsTransportBindingElement() {
                    AuthenticationScheme = AuthenticationSchemes.Basic,
                    MaxBufferSize = int.MaxValue,
                    MaxReceivedMessageSize = int.MaxValue
                }
            );

            var hPwd = AddressHeader.CreateAddressHeader("Authorization", "", "Basic " +
                                                                              Convert.ToBase64String(
                                                                                  Encoding.ASCII.GetBytes(
                                                                                      (user ?? Username) + ":" +
                                                                                      (password ?? Password))));
            var address = new EndpointAddress(new Uri(url ?? URL), hPwd);

            var cred = new ClientCredentials();
            cred.UserName.UserName = user ?? Username;
            cred.UserName.Password = password ?? Password;



            //srv.ClientCertificates.Add(new System.Security.Cryptography.X509Certificates.X509Certificate2(@"c:\Andy74cert.pfx", "password"));

            //cred.ServiceCertificate.SetDefaultCertificate("solutionpa-coll.intesasanpaolo.com",StoreLocation.CurrentUser,StoreName.My);
            //CN = System Test Intesa Sanpaolo S.p.A. - CA Root Interna 02 O = Intesa Sanpaolo S.p.A. C = IT
            //CN = solutionpa-coll.intesasanpaolo.com   O = Intesa Sanpaolo S.p.A. - Test SSL S = Italia C = IT 
            //string cert = "CN=solutionpa-coll.intesasanpaolo.com, O=Intesa Sanpaolo S.p.A. - Test SSL, S=Italia, C=IT";                 //3ed8765d55f336bc43f08e0decd9573c64866049
            //string defaultCert = "CN=System Test ISP - CA Servizi Esterni enhanced, DC=syssede, DC=systest, DC=sanpaoloimi, DC=com";    //6b9233c509e2d2a4d0dafa6207bc5c07720716a7

            var factory = new ChannelFactory<WEBS_DataProviderInterfacePort>(binding, address);

            if (test) {
                //CN = solutionpa-coll.intesasanpaolo.com
                factory.Credentials.ServiceCertificate.DefaultCertificate = pagoPaService.PagoPaService.getCertificateByThumbPrint(StoreName.My, StoreLocation.CurrentUser, "6b9233c509e2d2a4d0dafa6207bc5c07720716a7");
                // se test 6b9233c509e2d2a4d0dafa6207bc5c07720716a7 altrimenti a32787f1f3d287c96030cd2ad17492344af5c575 
                factory.Credentials.ClientCertificate.Certificate = pagoPaService.PagoPaService.getCertificateByThumbPrint(StoreName.My, StoreLocation.CurrentUser,"3ed8765d55f336bc43f08e0decd9573c64866049");
            }
            else {                
                factory.Credentials.ServiceCertificate.DefaultCertificate = pagoPaService.PagoPaService.getCertificateByThumbPrint(StoreName.My, StoreLocation.CurrentUser, "a32787f1f3d287c96030cd2ad17492344af5c575");

                factory.Credentials.ClientCertificate.Certificate = pagoPaService.PagoPaService.getCertificateByThumbPrint(StoreName.My, StoreLocation.CurrentUser,"3ed8765d55f336bc43f08e0decd9573c64866049");
            }


            //factory.Credentials.ClientCertificate.SetCertificate(cert, StoreLocation.CurrentUser, StoreName.My);
            //factory.Credentials.ServiceCertificate.SetDefaultCertificate(defaultCert, StoreLocation.CurrentUser,StoreName.My);

            var defaultCredentials = factory.Endpoint.EndpointBehaviors[typeof(ClientCredentials)];
            factory.Endpoint.Behaviors.Remove(defaultCredentials); //remove default ones

            factory.Endpoint.Behaviors.Clear();
            factory.Endpoint.Behaviors.Add(cred); //add required ones
            factory.Endpoint.Behaviors.Add(new AuthenticationHeaderBehavior(user ?? Username, password ?? Password));
            //factory.Endpoint.Behaviors.Add(new CleanNameSpacesBehavior("i"));
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
