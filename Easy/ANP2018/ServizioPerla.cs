using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using System.Text;
using System.Xml;
using servicetrasmission_default.service;
using servicetrasmission_default.ServicePerla;

namespace ANP2018 {
	public class EServizioNew {
        private static string URL = "https://servizi.perlapa.gov.it/wsanp2018/ws/anp2018.asmx";

     
        public  anp2018Soap Create(string user, string password) {
            //con TLS12 da Could not establish secure channel for SSL/TLS with authority 'solutionpa-coll.intesasanpaolo.com'.
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

         
            var binding = new BasicHttpsBinding();


            var address = new EndpointAddress(new Uri(URL ?? URL));

            var factory = new ChannelFactory<anp2018Soap>(binding, address);

            var defaultCredentials = factory.Endpoint.EndpointBehaviors[typeof(ClientCredentials)];
            factory.Endpoint.Behaviors.Remove(defaultCredentials); //remove default ones

            factory.Endpoint.Behaviors.Clear();
            factory.Endpoint.Behaviors.Add(new AuthenticationHeaderBehavior( user, password ));
            //factory.Endpoint.Behaviors.Add(new CleanNameSpacesBehavior("i"));
            var channel = factory.CreateChannel();

            return channel;

        }


    }

    public class EServizio {
        private static string URL = "http://www.perlapa.gov.it/AnagrafePrestazioni";

     
        public static AnagrafePrestazioni Create(string user, string password) {
            //con TLS12 da Could not establish secure channel for SSL/TLS with authority 'solutionpa-coll.intesasanpaolo.com'.
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

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



            var factory = new ChannelFactory<AnagrafePrestazioni>( new BasicHttpBinding(BasicHttpSecurityMode.Transport), address);

            factory.Endpoint.Behaviors.Add(new CleanNameSpacesBehavior("xsi","xsd","iuv"));//"xsi", "xsd","xsd1"


            //var defaultCredentials = factory.Endpoint.EndpointBehaviors[typeof(ClientCredentials)];
            //factory.Endpoint.Behaviors.Remove(defaultCredentials); //remove default ones
            //factory.Endpoint.Behaviors.Clear();
            //factory.Endpoint.Behaviors.Add(cred); //add required ones
            //factory.Endpoint.Behaviors.Add(new AuthenticationHeaderBehavior(user ?? USERNAME, password ?? PASSWORD));
            //factory.Endpoint.Behaviors.Add(new CleanNameSpacesBehavior("i"));
            return factory.CreateChannel(address);
        }


    }
	public class CleanNameSpaces : IClientMessageInspector {
        string[] _ns;
        private bool cleanAction = false;
        public CleanNameSpaces(bool cleanAction, params string[] ns) {
            _ns = ns;
            this.cleanAction = cleanAction;

        }
        public string LastRequestXML { get; private set; }
        public string LastProcessedRequestXML { get; private set; }

        private string method=null;
        private Dictionary<string, string> replace=null;
        public void doCleanResponse(string method, Dictionary<string, string> replace) {
            cleanResponse = true;
            this.method = method;
            this.replace = replace;
        }

        private bool cleanResponse = false;

        public void AfterReceiveReply(ref Message reply, object correlationState) {
            if (!cleanResponse)return;

            var xmlDocument = new XmlDocument();
            var memoryStream = new MemoryStream();
            var xmlWriter = XmlWriter.Create(memoryStream);


            var buffer = reply.CreateBufferedCopy(Int32.MaxValue);
            var newMessage = buffer.CreateMessage();

            
            // Write the xml request message into the memory stream
            newMessage.WriteMessage(xmlWriter);

            // Clear the xmlWriter
            xmlWriter.Flush();

            // Place the pointer in the memoryStream to the beginning 
            memoryStream.Position = 0;

            // Load the memory stream into the xmlDocument
            xmlDocument.Load(memoryStream);
            string newReplyStr = Encoding.UTF8.GetString(memoryStream.ToArray());

            if (!newReplyStr.Contains(method)) {                
                reply = buffer.CreateMessage();           
                return;
            }

            foreach (string k in replace.Keys) {
                newReplyStr = newReplyStr.Replace(k, replace[k]);
            }
            
            //xmlns:ns1="http://pmpay.it/ws/payPA/"
            byte[] b = Encoding.UTF8.GetBytes(newReplyStr);

            memoryStream = new MemoryStream(b);
            var xmlReader = XmlReader.Create(memoryStream);

            // Create a new request message with the modified xmlDocument
            var request2 = Message.CreateMessage(xmlReader, int.MaxValue, reply.Version);
            //request2.Headers.CopyHeadersFrom(request);
            buffer = request2.CreateBufferedCopy(Int32.MaxValue);
            reply = buffer.CreateMessage();   


        }

        void cascadeDeleteAttribute(XmlNode x, string attribute) {
            if (x.Attributes!=null) x.Attributes.RemoveNamedItem("xmlns:"+attribute);
            foreach (XmlNode c in x.ChildNodes) cascadeDeleteAttribute(c, attribute);


            //if (x.Attributes != null) {
            //    var n = x.Attributes.RemoveNamedItem("xmlns:"+attribute);
            //    if (n != null) {
            //        foreach (XmlNode c in x.ChildNodes) {
            //            cascadeDeleteAttribute(c, attribute);
            //        }
            //    }
            //}
            
        }
        public object BeforeSendRequest(ref Message request, IClientChannel channel) {
            LastRequestXML = request.ToString();
            if (cleanAction) {
                int headerIndexOfAction = request.Headers.FindHeader("Action",
                    "http://schemas.microsoft.com/ws/2005/05/addressing/none");
                if (headerIndexOfAction >= 0) request.Headers.RemoveAt(headerIndexOfAction);
            }

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
            string s = xmlDocument.InnerXml;
            // Remove the attributes from the second node down form the top
            foreach (string nn in _ns) cascadeDeleteAttribute(xmlDocument.ChildNodes[1], nn);
            
            

            // Reset the memoryStream object - essentially nulls it out
            memoryStream.SetLength(0);

            // ReInitialize the xmlWriter
            xmlWriter = XmlWriter.Create(memoryStream);

            // Write the modified xml request message (xmlDocument) to the memoryStream in the xmlWriter
            xmlDocument.WriteTo(xmlWriter);

            // Clear the xmlWriter
            xmlWriter.Flush();

            // Place the pointer in the memoryStream to the beginning 
            memoryStream.Position = 0;
            s = xmlDocument.InnerXml;
            // Create a new xmlReader with the memoryStream that contains the xmlDocument
            var xmlReader = XmlReader.Create(memoryStream);

            // Create a new request message with the modified xmlDocument
            var request2 = Message.CreateMessage(xmlReader, int.MaxValue, request.Version);
            //request2.Headers.CopyHeadersFrom(request);
            buffer = request2.CreateBufferedCopy(Int32.MaxValue);
            request = buffer.CreateMessage();
            LastProcessedRequestXML = s;
            return null;
        }

       
    }

    public class CleanNameSpacesBehavior : IEndpointBehavior {
	    private readonly string [] _ns;
	    private CleanNameSpaces clean = null;
	    public  bool cleanAction = false;
	    public CleanNameSpacesBehavior(params string []ns) {
		    this._ns = ns;
		    clean = new CleanNameSpaces(false,_ns);
	    }

	    public CleanNameSpacesBehavior(bool cleanAction, params string []ns) {
		    this._ns = ns;
		    clean = new CleanNameSpaces(cleanAction,_ns);
	    }

	    public void doCleanResponse(string method, Dictionary<string, string> replace) {
		    clean.doCleanResponse(method,replace);
	    }

	    public void AddBindingParameters(ServiceEndpoint endpoint, BindingParameterCollection bindingParameters) {
	    }

	    public void ApplyClientBehavior(ServiceEndpoint endpoint, ClientRuntime clientRuntime) {
		    clientRuntime.MessageInspectors.Add(clean);
	    }

	    public void ApplyDispatchBehavior(ServiceEndpoint endpoint, EndpointDispatcher endpointDispatcher) {
	    }

	    public void Validate(ServiceEndpoint endpoint) {
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
