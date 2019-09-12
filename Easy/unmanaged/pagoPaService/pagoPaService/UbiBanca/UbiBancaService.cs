/*
    Easy
    Copyright (C) 2019 Universit� degli Studi di Catania (www.unict.it)

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

﻿using System;
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
            return Create(null, null, null);

        }

        public static gestorePosizioni Create(string userName, string password, string URL) {
            if (userName == null) userName = "WSINSPOS0600101B";
            if (password == null) password = "PASSWORD";
            if (URL == null) URL = "https://cuniba.ubibanca.it/gestoreposizioni/services/soap/gestorePosizioni​";
            var binding = new BasicHttpsBinding();

            var address = new EndpointAddress(URL);

            var factory = new ChannelFactory<gestorePosizioni>(binding, address);

            factory.Credentials.UserName.UserName = userName;
            factory.Credentials.UserName.Password = password;

            factory.Endpoint.Behaviors.Add(new CleanNameSpacesBehavior("xsi", "xsd"));
            var vs = factory.Endpoint.EndpointBehaviors.FirstOrDefault((i) => i.GetType().Namespace == "Microsoft.VisualStudio.Diagnostics.ServiceModelSink");
            if (vs != null) {
                factory.Endpoint.Behaviors.Remove(vs);
            }

            return factory.CreateChannel(address);
        }

    }
}
