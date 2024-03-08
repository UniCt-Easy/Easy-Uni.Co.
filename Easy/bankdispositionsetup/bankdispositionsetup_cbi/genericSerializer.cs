
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
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace bankdispositionsetup_cbi {

    public static class GenericSerializer {
        public static void writeXmlToFile(this XmlDocument document, string filePath, Encoding e) {
            if (e == null) e = Encoding.Unicode;

       
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.CheckCharacters = false;
            settings.Encoding = e;
            //settings.ConformanceLevel = ConformanceLevel.Document;

            StringBuilder sb= new StringBuilder();
            XmlWriter writer = XmlWriter.Create(filePath, settings);        
            document.WriteTo(writer);
            writer.Flush();
            writer.Close();

			XmlDocument xmldoc = new XmlDocument();
            xmldoc.Load(filePath);
            
            string xml = RemoveInvalidXmlChars(xmldoc.InnerXml);
            File.WriteAllBytes(filePath, e.GetBytes(xml));
        }

        public static string RemoveInvalidXmlChars(string xmlContent)
        {
            return Regex.Replace(xmlContent, @"[^a-zA-Z0-9.,<>:;=_?\x27\x2d\x5c\x2f\x22\s]+", "");
        }

        public static string toXml<T>(this T value, Encoding e= null) {
            if (e == null) e = Encoding.Unicode;
            if (value == null) {
                return string.Empty;
            }
            XmlWriterSettings settings = new XmlWriterSettings() {                
                Indent = false,
                OmitXmlDeclaration = true,
                Encoding =e,
                CheckCharacters=false
            };
            var xmlserializer = new XmlSerializer(typeof(T));
            var stringWriter = new StringWriter();
            using (var writer = XmlWriter.Create(stringWriter, settings)) {
                xmlserializer.Serialize(writer, value);
                return RemoveInvalidXmlChars(stringWriter.ToString());
                
            }

        }

        public static T fromXml<T>(string xml, Encoding e=null) {
            if (e == null) e = Encoding.Unicode;
            if (xml == null) return default(T);
            var serializer = new XmlSerializer(typeof(T));
            MemoryStream memStream = new MemoryStream(e.GetBytes(xml));
            return (T)serializer.Deserialize(memStream);
        }

    }
}
