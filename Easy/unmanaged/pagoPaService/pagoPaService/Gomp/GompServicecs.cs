
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
using pagoPaService.GompEasyService;

namespace GompService {
	public class GompService {
		

		private string URL = "https://unitus-ws.gomp.it/Contabilita/easy/";

		//Default Constructor
		public static gompPerEasySoap create(string url, string user , string password ) {

			var address = new EndpointAddress(url);
			var cred = new ClientCredentials();
			cred.UserName.UserName = user;
			cred.UserName.Password = password;

			//var binding = new BasicHttpsBinding();
			var binding = new CustomBinding(
				new TextMessageEncodingBindingElement(MessageVersion.Soap11, Encoding.UTF8),
				new HttpsTransportBindingElement() {
					AuthenticationScheme = AuthenticationSchemes.Anonymous,
					MaxBufferSize = Int32.MaxValue,
					MaxReceivedMessageSize = Int32.MaxValue
				}
			);

			var factory = new ChannelFactory<gompPerEasySoap>(binding, address);
			
			factory.Endpoint.Behaviors.Clear();

			//factory.Endpoint.Behaviors.Add(new CleanNameSpacesBehavior("xsi","xsd","iuv"));//"xsi", "xsd","xsd1"
			var vs = factory.Endpoint.EndpointBehaviors.FirstOrDefault((i) => i.GetType().Namespace == "Microsoft.VisualStudio.Diagnostics.ServiceModelSink");
			if (vs != null) {
				factory.Endpoint.Behaviors.Remove(vs);
			}


			return factory.CreateChannel(address);

		}

	}

}

    
