
/*
Easy
Copyright (C) 2021 Universit� degli Studi di Catania (www.unict.it)
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


//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace pagoPaService.AuthPASoap {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://pmPay.it/ws/authPA/", ConfigurationName="AuthPASoap.AuthPASoap")]
    public interface AuthPASoap {
        
        // CODEGEN: Generating message contract since element name content from namespace http://pmPay.it/ws/authPA/ is not marked nillable
        [System.ServiceModel.OperationContractAttribute(Action="http://pmPay.it/ws/authPA/GetTicket", ReplyAction="*")]
        pagoPaService.AuthPASoap.GetTicketResponse GetTicket(pagoPaService.AuthPASoap.GetTicketRequest request);
        
        // CODEGEN: Generating message contract since element name content from namespace http://pmPay.it/ws/authPA/ is not marked nillable
        [System.ServiceModel.OperationContractAttribute(Action="http://pmPay.it/ws/authPA/GetIUV", ReplyAction="*")]
        pagoPaService.AuthPASoap.GetIUVResponse GetIUV(pagoPaService.AuthPASoap.GetIUVRequest request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class GetTicketRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="GetTicket", Namespace="http://pmPay.it/ws/authPA/", Order=0)]
        public pagoPaService.AuthPASoap.GetTicketRequestBody Body;
        
        public GetTicketRequest() {
        }
        
        public GetTicketRequest(pagoPaService.AuthPASoap.GetTicketRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://pmPay.it/ws/authPA/")]
    public partial class GetTicketRequestBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string content;
        
        public GetTicketRequestBody() {
        }
        
        public GetTicketRequestBody(string content) {
            this.content = content;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class GetTicketResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="GetTicketResponse", Namespace="http://pmPay.it/ws/authPA/", Order=0)]
        public pagoPaService.AuthPASoap.GetTicketResponseBody Body;
        
        public GetTicketResponse() {
        }
        
        public GetTicketResponse(pagoPaService.AuthPASoap.GetTicketResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://pmPay.it/ws/authPA/")]
    public partial class GetTicketResponseBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string GetTicketResult;
        
        public GetTicketResponseBody() {
        }
        
        public GetTicketResponseBody(string GetTicketResult) {
            this.GetTicketResult = GetTicketResult;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class GetIUVRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="GetIUV", Namespace="http://pmPay.it/ws/authPA/", Order=0)]
        public pagoPaService.AuthPASoap.GetIUVRequestBody Body;
        
        public GetIUVRequest() {
        }
        
        public GetIUVRequest(pagoPaService.AuthPASoap.GetIUVRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://pmPay.it/ws/authPA/")]
    public partial class GetIUVRequestBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string content;
        
        public GetIUVRequestBody() {
        }
        
        public GetIUVRequestBody(string content) {
            this.content = content;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class GetIUVResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="GetIUVResponse", Namespace="http://pmPay.it/ws/authPA/", Order=0)]
        public pagoPaService.AuthPASoap.GetIUVResponseBody Body;
        
        public GetIUVResponse() {
        }
        
        public GetIUVResponse(pagoPaService.AuthPASoap.GetIUVResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://pmPay.it/ws/authPA/")]
    public partial class GetIUVResponseBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string GetIUVResult;
        
        public GetIUVResponseBody() {
        }
        
        public GetIUVResponseBody(string GetIUVResult) {
            this.GetIUVResult = GetIUVResult;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface AuthPASoapChannel : pagoPaService.AuthPASoap.AuthPASoap, System.ServiceModel.IClientChannel {
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class AuthPASoapClient : System.ServiceModel.ClientBase<pagoPaService.AuthPASoap.AuthPASoap>, pagoPaService.AuthPASoap.AuthPASoap {
        
        public AuthPASoapClient() {
        }
        
        public AuthPASoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public AuthPASoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public AuthPASoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public AuthPASoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        pagoPaService.AuthPASoap.GetTicketResponse pagoPaService.AuthPASoap.AuthPASoap.GetTicket(pagoPaService.AuthPASoap.GetTicketRequest request) {
            return base.Channel.GetTicket(request);
        }
        
        public string GetTicket(string content) {
            pagoPaService.AuthPASoap.GetTicketRequest inValue = new pagoPaService.AuthPASoap.GetTicketRequest();
            inValue.Body = new pagoPaService.AuthPASoap.GetTicketRequestBody();
            inValue.Body.content = content;
            pagoPaService.AuthPASoap.GetTicketResponse retVal = ((pagoPaService.AuthPASoap.AuthPASoap)(this)).GetTicket(inValue);
            return retVal.Body.GetTicketResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        pagoPaService.AuthPASoap.GetIUVResponse pagoPaService.AuthPASoap.AuthPASoap.GetIUV(pagoPaService.AuthPASoap.GetIUVRequest request) {
            return base.Channel.GetIUV(request);
        }
        
        public string GetIUV(string content) {
            pagoPaService.AuthPASoap.GetIUVRequest inValue = new pagoPaService.AuthPASoap.GetIUVRequest();
            inValue.Body = new pagoPaService.AuthPASoap.GetIUVRequestBody();
            inValue.Body.content = content;
            pagoPaService.AuthPASoap.GetIUVResponse retVal = ((pagoPaService.AuthPASoap.AuthPASoap)(this)).GetIUV(inValue);
            return retVal.Body.GetIUVResult;
        }
    }
}