
/*
Easy
Copyright (C) 2024 UniversitÓ degli Studi di Catania (www.unict.it)
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


// ------------------------------------------------------------------------------
//  <auto-generated>
//    Generated by Xsd2Code. Version 3.4.1.34438 Microsoft Reciprocal License (Ms-RL) 
//    <NameSpace>pagoPaService</NameSpace><Collection>List</Collection><codeType>CSharp</codeType><EnableDataBinding>False</EnableDataBinding><EnableLazyLoading>False</EnableLazyLoading><TrackingChangesEnable>False</TrackingChangesEnable><GenTrackingClasses>False</GenTrackingClasses><HidePrivateFieldInIDE>False</HidePrivateFieldInIDE><EnableSummaryComment>False</EnableSummaryComment><VirtualProp>False</VirtualProp><IncludeSerializeMethod>True</IncludeSerializeMethod><UseBaseClass>False</UseBaseClass><GenBaseClass>False</GenBaseClass><GenerateCloneMethod>False</GenerateCloneMethod><GenerateDataContracts>False</GenerateDataContracts><CodeBaseTag>Net40</CodeBaseTag><SerializeMethodName>Serialize</SerializeMethodName><DeserializeMethodName>Deserialize</DeserializeMethodName><SaveToFileMethodName>SaveToFile</SaveToFileMethodName><LoadFromFileMethodName>LoadFromFile</LoadFromFileMethodName><GenerateXMLAttributes>False</GenerateXMLAttributes><OrderXMLAttrib>False</OrderXMLAttrib><EnableEncoding>False</EnableEncoding><AutomaticProperties>True</AutomaticProperties><GenerateShouldSerialize>False</GenerateShouldSerialize><DisableDebug>False</DisableDebug><PropNameSpecified>Default</PropNameSpecified><Encoder>UTF8</Encoder><CustomUsings></CustomUsings><ExcludeIncludedTypes>False</ExcludeIncludedTypes><EnableInitializeFields>True</EnableInitializeFields>
//  </auto-generated>
// ------------------------------------------------------------------------------
namespace pagoPaService {
    using System;
    using System.Diagnostics;
    using System.Xml.Serialization;
    using System.Collections;
    using System.Xml.Schema;
    using System.ComponentModel;
    using System.IO;
    using System.Text;
    using System.Collections.Generic;


    public partial class allineamentopendenze {

        private static System.Xml.Serialization.XmlSerializer serializer;

        public string CREDITORE { get; set; }

        public string CODICE_PARTITARIO { get; set; }

        public string DEBITORE { get; set; }

        public string ID_DEBITO { get; set; }

        public string ID_PAGAMENTO { get; set; }

        public System.DateTime DATA_SCADENZA { get; set; }

        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool DATA_SCADENZASpecified { get; set; }

        public System.DateTime DATA_INIZIO_VALIDITA { get; set; }

        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool DATA_INIZIO_VALIDITASpecified { get; set; }

        public System.DateTime DATA_FINE_VALIDITA { get; set; }

        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool DATA_FINE_VALIDITASpecified { get; set; }

        public string CAUSALE_PAGAMENTO { get; set; }

        public string STATO_PAGAMENTO { get; set; }

        public decimal IMPORTO_PAGAMENTO { get; set; }

        public string VOCI_PAGAMENTO { get; set; }

        public int ANNO_RIFERIMENTO { get; set; }

        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ANNO_RIFERIMENTOSpecified { get; set; }

        public string NOTE_DEBITO { get; set; }

        public string CAUSALE_DEBITO { get; set; }

        public decimal IMPORTO_PAGATO { get; set; }

        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool IMPORTO_PAGATOSpecified { get; set; }

        public System.DateTime DATA_VALUTA_ACCREDITO { get; set; }

        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool DATA_VALUTA_ACCREDITOSpecified { get; set; }

        public string CANALE_PAGAMENTO { get; set; }

        public System.DateTime DATA_PAGAMENTO { get; set; }

        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool DATA_PAGAMENTOSpecified { get; set; }

        public string NOTE_PAGAMENTO { get; set; }

        public string PAGATO_PIATTAFORMA { get; set; }


        private static System.Xml.Serialization.XmlSerializer Serializer {
            get {
                if ((serializer == null)) {
                    serializer = new System.Xml.Serialization.XmlSerializer(typeof(allineamentopendenze));
                }
                return serializer;
            }
        }

        #region Serialize/Deserialize
        /// <summary>
        /// Serializes current allineamentopendenze object into an XML document
        /// </summary>
        /// <returns>string XML value</returns>
        public virtual string Serialize() {
            System.IO.StreamReader streamReader = null;
            System.IO.MemoryStream memoryStream = null;
            try {
                memoryStream = new System.IO.MemoryStream();
                Serializer.Serialize(memoryStream, this);
                memoryStream.Seek(0, System.IO.SeekOrigin.Begin);
                streamReader = new System.IO.StreamReader(memoryStream);
                return streamReader.ReadToEnd();
            }
            finally {
                if ((streamReader != null)) {
                    streamReader.Dispose();
                }
                if ((memoryStream != null)) {
                    memoryStream.Dispose();
                }
            }
        }

        /// <summary>
        /// Deserializes workflow markup into an allineamentopendenze object
        /// </summary>
        /// <param name="xml">string workflow markup to deserialize</param>
        /// <param name="obj">Output allineamentopendenze object</param>
        /// <param name="exception">output Exception value if deserialize failed</param>
        /// <returns>true if this XmlSerializer can deserialize the object; otherwise, false</returns>
        public static bool Deserialize(string xml, out allineamentopendenze obj, out System.Exception exception) {
            exception = null;
            obj = default(allineamentopendenze);
            try {
                obj = Deserialize(xml);
                return true;
            }
            catch (System.Exception ex) {
                exception = ex;
                return false;
            }
        }

        public static bool Deserialize(string xml, out allineamentopendenze obj) {
            System.Exception exception = null;
            return Deserialize(xml, out obj, out exception);
        }

        public static allineamentopendenze Deserialize(string xml) {
            System.IO.StringReader stringReader = null;
            try {
                stringReader = new System.IO.StringReader(xml);
                return ((allineamentopendenze)(Serializer.Deserialize(System.Xml.XmlReader.Create(stringReader))));
            }
            finally {
                if ((stringReader != null)) {
                    stringReader.Dispose();
                }
            }
        }

        /// <summary>
        /// Serializes current allineamentopendenze object into file
        /// </summary>
        /// <param name="fileName">full path of outupt xml file</param>
        /// <param name="exception">output Exception value if failed</param>
        /// <returns>true if can serialize and save into file; otherwise, false</returns>
        public virtual bool SaveToFile(string fileName, out System.Exception exception) {
            exception = null;
            try {
                SaveToFile(fileName);
                return true;
            }
            catch (System.Exception e) {
                exception = e;
                return false;
            }
        }

        public virtual void SaveToFile(string fileName) {
            System.IO.StreamWriter streamWriter = null;
            try {
                string xmlString = Serialize();
                System.IO.FileInfo xmlFile = new System.IO.FileInfo(fileName);
                streamWriter = xmlFile.CreateText();
                streamWriter.WriteLine(xmlString);
                streamWriter.Close();
            }
            finally {
                if ((streamWriter != null)) {
                    streamWriter.Dispose();
                }
            }
        }

        /// <summary>
        /// Deserializes xml markup from file into an allineamentopendenze object
        /// </summary>
        /// <param name="fileName">string xml file to load and deserialize</param>
        /// <param name="obj">Output allineamentopendenze object</param>
        /// <param name="exception">output Exception value if deserialize failed</param>
        /// <returns>true if this XmlSerializer can deserialize the object; otherwise, false</returns>
        public static bool LoadFromFile(string fileName, out allineamentopendenze obj, out System.Exception exception) {
            exception = null;
            obj = default(allineamentopendenze);
            try {
                obj = LoadFromFile(fileName);
                return true;
            }
            catch (System.Exception ex) {
                exception = ex;
                return false;
            }
        }

        public static bool LoadFromFile(string fileName, out allineamentopendenze obj) {
            System.Exception exception = null;
            return LoadFromFile(fileName, out obj, out exception);
        }

        public static allineamentopendenze LoadFromFile(string fileName) {
            System.IO.FileStream file = null;
            System.IO.StreamReader sr = null;
            try {
                file = new System.IO.FileStream(fileName, FileMode.Open, FileAccess.Read);
                sr = new System.IO.StreamReader(file);
                string xmlString = sr.ReadToEnd();
                sr.Close();
                file.Close();
                return Deserialize(xmlString);
            }
            finally {
                if ((file != null)) {
                    file.Dispose();
                }
                if ((sr != null)) {
                    sr.Dispose();
                }
            }
        }
        #endregion
    }
}
