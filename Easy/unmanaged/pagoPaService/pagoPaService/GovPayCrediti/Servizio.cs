
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
using System.ServiceModel;
using System.Xml.Schema;
using System.Xml.Serialization;
using System.Net;
using System.ServiceModel.Channels;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel.Description;
using System.Xml;
using System.IO;
using XmlFormatter;
using System.Security.Cryptography.X509Certificates;
using funzioni_configurazione;
using System.Net.Security;
using metadatalibrary;
using System.ServiceModel.Dispatcher;

namespace pagoPaService.govPayReference {
	//public interface PagamentiTelematiciGPApp invece di IServizio
	class MyWebClient : WebClient {
		public static void SetCertificatePolicy() {
			ServicePointManager.ServerCertificateValidationCallback += ValidateRemoteCertificate;
		}

		internal MyWebClient(PagoPaService.OpiSiopeplusConfig cfg) {
			if (!string.IsNullOrEmpty(cfg.cert_filename) && !string.IsNullOrEmpty(cfg.cert_thumbprint)) {
				cert = PagoPaService.checkPfxByThumbPrint(StoreName.My, StoreLocation.CurrentUser, cfg.cert_filename,
					cfg.cert_thumbprint, cfg.cert_pwd);

			}

			System.Net.ServicePointManager.ServerCertificateValidationCallback = delegate(Object obj,
				X509Certificate X509certificate, X509Chain chain, System.Net.Security.SslPolicyErrors errors) {
				QueryCreator.MarkEvent("ServerCertificateValidationCallback called");
				return true;
			};
		}

		/// <summary>
		/// Certificate validation callback 
		/// </summary>
		public static bool ValidateRemoteCertificate(object sender, X509Certificate cert, X509Chain chain,
			SslPolicyErrors error) {
			QueryCreator.MarkEvent("ValidateRemoteCertificate called");
			return true;
		}



		private X509Certificate2 cert;



		protected override WebRequest GetWebRequest(Uri address) {
			HttpWebRequest request = (HttpWebRequest) base.GetWebRequest(address);
			if (cert != null) {
				QueryCreator.MarkEvent("Accettato richiesta utilizzando il certificato " + cert.SubjectName.Name);
				request.ClientCertificates.Add(cert);
			}
			else {
				QueryCreator.MarkEvent("Accettato richiesta senza certificato");
			}

			return request;
		}
	}

	public static class InvioCreditiGPAppService {
		public static PagamentiTelematiciGPApp Create(string user, string pwd, string url, bool test = false) {
			ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
			//ServicePointManager.SetTcpKeepAlive(true,5000,100);
			ServicePointManager.ServerCertificateValidationCallback +=
				(sender, certificate, chain, sslPolicyErrors) => {
					String rootCAThumbprint = "3B2A396315D0209990A9AFC29B07E16B1931F30F";
					// "0563B8630D62D75ABBC8AB1E4BDFB5A899B24D43"; // write your code to get your CA's thumbprint
					//3B2A396315D0209990A9AFC29B07E16B1931F30F  
					// CN=[DESARROLLO] Global Chambersign Root - 2008, O=AC Camerfirma S.A.,...
					// remove this line if commercial CAs are not allowed to issue certificate for your service.
					if ((sslPolicyErrors & (SslPolicyErrors.None)) > 0) {
						return true;
					}

					//if (
					//    (sslPolicyErrors & (SslPolicyErrors.RemoteCertificateNameMismatch)) > 0 ||
					//    (sslPolicyErrors & (SslPolicyErrors.RemoteCertificateNotAvailable)) > 0
					//) {
					//    return false;
					//}

					//// get last chain element that should contain root CA certificate
					//// but this may not be the case in partial chains
					//X509Certificate2 projectedRootCert = chain.ChainElements[chain.ChainElements.Count - 1].Certificate;
					//if (projectedRootCert.Thumbprint != rootCAThumbprint) {
					//    return true;
					//}


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
			System.Net.ServicePointManager.Expect100Continue = false;

			//var binding = new CustomBinding(
			// new TextMessageEncodingBindingElement(MessageVersion.Soap12, Encoding.UTF8),
			// new HttpsTransportBindingElement() {
			//  AuthenticationScheme = AuthenticationSchemes.Basic,
			//  MaxBufferSize = int.MaxValue,
			//  MaxReceivedMessageSize = int.MaxValue,
			// }
			//);

			var binding = new BasicHttpBinding(BasicHttpSecurityMode.Transport);
			binding.Security.Transport.ClientCredentialType = HttpClientCredentialType.Certificate;
			

			binding.SendTimeout = new TimeSpan(0, 60, 0);
			binding.MaxReceivedMessageSize = 65536 * 1000;
			

			//var binding0 = new BasicHttpBinding(BasicHttpSecurityMode.TransportWithMessageCredential);
			//binding0.Security.Transport.ClientCredentialType = HttpClientCredentialType.Basic;
			//binding0.MaxReceivedMessageSize = 65536 * 100;

			//var trBinding = new HttpsTransportBindingElement();
			//trBinding.AuthenticationScheme = AuthenticationSchemes.Basic;

			//var binding = new CustomBinding(
			//    new CustomTextMessageBindingElement("iso-8859-1", "text/xml", MessageVersion.Soap11),
			//    trBinding);


			//binding.TextEncoding = binding2;
			//var hPwd = AddressHeader.CreateAddressHeader("Authorization", "http://easybridge.eu/bridge/", "Basic " +
			//                                                                                              Convert.ToBase64String(
			//	                                                                                              Encoding.ASCII.GetBytes(
			//		                                                                                              (user ?? Username) + ":" +
			//		                                                                                              (password ?? Password))));

			var address = new EndpointAddress(url);
			
			
			var factory = new ChannelFactory<PagamentiTelematiciGPApp>(binding, address);
			factory.Credentials.UserName.UserName = user;
			factory.Credentials.UserName.Password = pwd;


			factory.Endpoint.Behaviors.Clear();

		

			//var defaultCredentials = factory.Endpoint.EndpointBehaviors[typeof(ClientCredentials)];
			//factory.Endpoint.Behaviors.Remove(defaultCredentials); //remove default ones
			factory.Endpoint.Behaviors.Add(new CleanNameSpacesBehavior("xsi", "xsd"));
			

			if (test) {
				//CN = solutionpa-coll.intesasanpaolo.com
				factory.Credentials.ServiceCertificate.DefaultCertificate =
					pagoPaService.PagoPaService.getCertificateByThumbPrint(StoreName.My, StoreLocation.CurrentUser,
						"8a653ab1eb3f30341baa7e442a81d22e42751e46");//8a653ab1eb3f30341baa7e442a81d22e42751e46
				factory.Credentials.ClientCertificate.Certificate =
					pagoPaService.PagoPaService.getCertificateByThumbPrint(StoreName.My, StoreLocation.CurrentUser,
						"218fff5ce170503dae33fde182d2b22f5457f391");//218fff5ce170503dae33fde182d2b22f5457f391
			}
			else {
				factory.Credentials.ServiceCertificate.DefaultCertificate =
					pagoPaService.PagoPaService.getCertificateByThumbPrint(StoreName.My, StoreLocation.CurrentUser,
						"3e92d9b2dc6d2afaad4c52bd6aa24b76d63c44ab");

				factory.Credentials.ClientCertificate.Certificate =
					pagoPaService.PagoPaService.getCertificateByThumbPrint(StoreName.My, StoreLocation.CurrentUser,
						"218fff5ce170503dae33fde182d2b22f5457f391");
			}

			


			

			//factory.Endpoint.Behaviors.Add(new CleanNameSpacesBehavior("xsi", "xsd"));

			//var vs = factory.Endpoint.EndpointBehaviors.FirstOrDefault((i) => i.GetType().Namespace == "Microsoft.VisualStudio.Diagnostics.ServiceModelSink");
			//if (vs != null) {
			//	factory.Endpoint.Behaviors.Remove(vs);
			//}
			//factory.Endpoint.Behaviors.Remove(defaultCredentials); //remove default ones

			factory.Endpoint.Behaviors.Add(new AuthenticationHeaderBehavior(user ?? user, pwd ?? pwd));

			return factory.CreateChannel();
		}
	}


public class AuthenticationHeader :IClientMessageInspector {
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
			} else {
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



