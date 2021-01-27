
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
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using System.Xml;
using System.Text;
using System.Collections.Generic;
using System.ServiceModel;
using System.IO;
using Microsoft.Win32;
using System.Linq;
using System.Xml.Linq;

//using UnicreditService;

namespace XmlFormatter {

    public class EnvelopeNamespaceMessageFormatter :IClientMessageFormatter {
        private readonly IClientMessageFormatter formatter;

        public string[] EnvelopeNamespaces { get; set; }
        public bool cleanAction = false;

        public EnvelopeNamespaceMessageFormatter(IClientMessageFormatter formatter) {
            this.formatter = formatter;
        }

        public Message SerializeRequest(MessageVersion messageVersion, object[] parameters) {
                var message = this.formatter.SerializeRequest(messageVersion, parameters);
                return new EnvelopeNamespaceMessage(message) { EnvelopeNamespaces = EnvelopeNamespaces,cleanAction=cleanAction };
        }

        public object DeserializeReply(Message message, object[] parameters) {
            return this.formatter.DeserializeReply(message, parameters);
        }
    }

    [AttributeUsage(AttributeTargets.Method)]
    public class EnvelopeNamespacesAttribute :Attribute, IOperationBehavior {

        public string[] EnvelopeNamespaces { get; set; }
        public bool cleanAction  { get; set; } = false;
        public void AddBindingParameters(OperationDescription operationDescription,
            BindingParameterCollection bindingParameters) {
        }

        public void ApplyClientBehavior(OperationDescription operationDescription, ClientOperation clientOperation) {
            //var serializerBehavior = operationDescription.Behaviors.Find<DataContractSerializerOperationBehavior>();
            IOperationBehavior serializerBehavior = operationDescription.Behaviors.Find<XmlSerializerOperationBehavior>();
            if (serializerBehavior == null)
                serializerBehavior = operationDescription.Behaviors.Find<DataContractSerializerOperationBehavior>();

            if (clientOperation.Formatter == null)
                serializerBehavior.ApplyClientBehavior(operationDescription, clientOperation);

            IClientMessageFormatter innerClientFormatter = clientOperation.Formatter;
            clientOperation.Formatter = new EnvelopeNamespaceMessageFormatter(innerClientFormatter) {
                EnvelopeNamespaces = EnvelopeNamespaces,
                cleanAction = cleanAction
            };
        }

        public void ApplyDispatchBehavior(OperationDescription operationDescription, DispatchOperation dispatchOperation) {
        }

        public void Validate(OperationDescription operationDescription) {
        }
    }

    public class EnvelopeNamespaceMessageHeader : MessageHeader {
        public XmlDocument x;
        string _Name;
        string _ns;
        public EnvelopeNamespaceMessageHeader(string name, string ns) {
            this._Name = name;
            this._ns = ns;
        }

        public override string Name
        {
            get
            {
                return _Name;
            }
        }

        public override string Namespace
        {
            get
            {
                return _ns;
            }
        }

        protected override void OnWriteHeaderContents(XmlDictionaryWriter writer, MessageVersion messageVersion) {
            //writer.WriteStartElement(x.Name, _ns);
            foreach (XmlNode node in x.ChildNodes[0].ChildNodes)
                writer.WriteNode(node.CreateNavigator(), false);
            //writer.WriteEndElement();
        }

    }

    public class EnvelopeNamespaceMessage :Message {
        private readonly Message message;
        //private inserimentoPosizione req;

        public string[] EnvelopeNamespaces { get; set; }
        public bool cleanAction = false;

        string envelopeHeader;
        public EnvelopeNamespaceMessage(Message message) {
            this.message = message;

            if (cleanAction) {
                int headerIndexOfAction = message.Headers.FindHeader("Action",
                    "http://schemas.microsoft.com/ws/2005/05/addressing/none");
                if (headerIndexOfAction >= 0) message.Headers.RemoveAt(headerIndexOfAction);
            }


            envelopeHeader = "http://schemas.xmlsoap.org/soap/envelope/";
            if (this.Version == MessageVersion.Soap12) {
                envelopeHeader = "http://www.w3.org/2003/05/soap-envelope";
            }
        }

        //public EnvelopeNamespaceMessage(inserimentoPosizione req) {
        //    this.req = req;
        //}

        public override MessageHeaders Headers {
            get { return this.message.Headers; }
        }


        public override MessageProperties Properties {
            get { return this.message.Properties; }
        }

        public override MessageVersion Version {
            get { return this.message.Version; }
        }

        protected override void OnWriteStartHeaders(XmlDictionaryWriter writer) {

            if (EnvelopeNamespaces != null) {
                foreach (string ns in EnvelopeNamespaces) {
                    var tokens = ns.Split(new char[] { ':' }, 2);
                    MessageHeaderInfo oldH=null;
                    if (tokens[0] == "head" || tokens[0]=="h") {
                        for (int i = 0; i < Headers.Count; i++) {
                            if (Headers[i].Namespace == tokens[1]) {
                                oldH = Headers[i];
                                Headers.RemoveAt(i);
                                break;
                            }
                        }
                        if (oldH != null) {
                            var x = new XmlDocument();
                            x.LoadXml(oldH.ToString());
                            var root = x.ChildNodes[0];
                            EnvelopeNamespaceMessageHeader em = new EnvelopeNamespaceMessageHeader(oldH.Name, oldH.Namespace);
                            em.x = x;
                            Headers.Add(em);
                        }
                    }
                    
                }
            }

            writer.WriteStartElement("Header", envelopeHeader);
           
            
        }


        protected override void OnWriteStartBody(XmlDictionaryWriter writer) {          
            writer.WriteStartElement("Body", envelopeHeader);
            
        }

        protected override void OnWriteBodyContents(XmlDictionaryWriter writer) {
            this.message.WriteBodyContents(writer);
        }

        


        protected override void OnWriteStartEnvelope(XmlDictionaryWriter writer) {
            string prefix = "soapenv";
            foreach (string ns in EnvelopeNamespaces) {
                var tokens = ns.Split(new char[] { ':' }, 2);
                if (tokens[1]== envelopeHeader) {
                    prefix = tokens[0];
                }                
            }
            writer.WriteStartElement(prefix, "Envelope", envelopeHeader);

            if (EnvelopeNamespaces != null) {
                foreach (string ns in EnvelopeNamespaces) {
                    var tokens = ns.Split(new char[] { ':' }, 2);
                    writer.WriteAttributeString("xmlns", tokens[0], null, tokens[1]);
                }
            }
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
}
