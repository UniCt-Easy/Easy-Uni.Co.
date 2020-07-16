/*
    Easy
    Copyright (C) 2020 Università degli Studi di Catania (www.unict.it)
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

﻿using System.Security.Cryptography.X509Certificates;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using System.Text;
using System.Xml;
using System.IO;
using XmlFormatter;
using System.Threading.Tasks;
using unicredit_b;
using UnicreditService;

namespace unicredit_b {
    public class Servizio {

        //TODO: rendere parametrici questi valori
        //private static readonly string basic_USERNAME = "unicredit_consumer";
        //private static readonly string basic_PASSWORD = "9628d4a735aacb9";

        public static PaInviaCarrelloPosizioni Create() {
            return Create(null, null, null);

        }

        public static PaInviaCarrelloPosizioni Create(string userName, string password, string URL) {
            if (userName == null) userName = "WSCAR02008U";
            if (password == null) password = "c20d3d5fac14a42";
            if (URL == null) URL = "https://tst.pasemplice.eu/connettorenodo/services/soap/paInviaCarrelloPosizioni";
            var binding = new BasicHttpsBinding();

            var address = new EndpointAddress(URL);

            var factory = new ChannelFactory<PaInviaCarrelloPosizioni>(binding, address);

            factory.Credentials.UserName.UserName = userName;
            factory.Credentials.UserName.Password = password;

            factory.Endpoint.Behaviors.Add(new CleanNameSpacesBehavior("xsi", "xsd"));

            return factory.CreateChannel(address);
        }

    }
}
