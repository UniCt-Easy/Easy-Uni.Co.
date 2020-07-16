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

﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace genericSerializer {

    public static class GenericSerializer {
        public static string toXml<T>(this T value) {
            if (value == null) {
                return string.Empty;
            }
            XmlWriterSettings settings = new XmlWriterSettings() {                
                Indent = true,
                OmitXmlDeclaration = true,
                Encoding = Encoding.UTF8
            };
            var xmlserializer = new XmlSerializer(typeof(T));
            var stringWriter = new StringWriter();
            using (var writer = XmlWriter.Create(stringWriter, settings)) {
                xmlserializer.Serialize(writer, value);
                return stringWriter.ToString();
            }

        }

        public static T fromXml<T>(string xml) {
            if (xml == null) return default(T);
            var serializer = new XmlSerializer(typeof(T));
            MemoryStream memStream = new MemoryStream(Encoding.UTF8.GetBytes(xml));
            return (T)serializer.Deserialize(memStream);
        }

    }
}
