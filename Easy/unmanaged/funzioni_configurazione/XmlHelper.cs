/*
    Easy
    Copyright (C) 2020 Universit√† degli Studi di Catania (www.unict.it)
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
using System.Text;
using System.Data;
using System.Collections;
using System.Windows.Forms;
using metadatalibrary;
using System.Xml;
using System.Globalization;
using System.Xml.Xsl;
using System.IO;
using System.Xml.Schema;
using funzioni_configurazione;
using System.Web;

namespace funzioni_configurazione {
    public class XmlHelper {

        public static bool IsNullable(DataTable TSchema, XmlElement Xparent) {
            string field = TSchema.TableName;
            string parentName= Xparent.Name;
            if (parentName=="" || parentName==null) return true;
            if (!TSchema.DataSet.Tables.Contains(parentName)) return true;
            DataTable ParentTable = TSchema.DataSet.Tables[parentName];
            if (!ParentTable.Columns.Contains(field)) return true;
            if (ParentTable.Columns[field].AllowDBNull) return true;
            foreach (XmlNode ParField in Xparent.ChildNodes) {
                if (ParField.InnerText != "") return false;
            }
            return true;
        }
        /// <summary>
        /// Crea una riga figlia di un elemento dato con le colonne presenti in TChild e i valori presenti in Rsp_Data, eventualmente con un nome di colonna diverso
        ///  in base alla Hashtable H
        /// </summary>
        /// <param name="x">Elemento parent</param>
        /// <param name="TSchema">Tabella con le colonne dell'elemento da creare</param>
        /// <param name="Rsp_data">Riga con i valori da prendere. Ogni valore Ë preso dalla colonna di pari nome oppure da Rsp_data[H[nome colonna]] se presente</param>
        /// <param name="H">Traslazione dei nomi di colonna ove necessario, per prendere i dati da Rsp_data</param>
        /// <returns>Elemento creato o null se i campi erano tutti vuoti e nessun elemento Ë stato aggiunto</returns>
        public static XmlElement CreaRigaChild(XmlDocument x, DataTable TSchema, DataRow Rsp_data, Hashtable H) {
            bool Nullable = false;
            XmlElement child = x.CreateElement(TSchema.TableName);
            XmlElement toadd = fillRigaChild(child, TSchema, Rsp_data, H,Nullable);
            if (toadd != null) x.AppendChild(toadd);
            return toadd;
        }

        /// <summary>
        /// Crea una riga figlia di un elemento dato con le colonne presenti in TChild e i valori presenti in Rsp_Data, eventualmente con un nome di colonna diverso
        ///  in base alla Hashtable H
        /// </summary>
        /// <param name="x">Elemento parent</param>
        /// <param name="TChild">Tabella con le colonne dell'elemento da creare</param>
        /// <param name="Rsp_data">Riga con i valori da prendere. Ogni valore Ë preso dalla colonna di pari nome oppure da Rsp_data[H[nome colonna]] se presente</param>
        /// <param name="H">Traslazione dei nomi di colonna ove necessario, per prendere i dati da Rsp_data</param>
        /// <returns>Elemento creato o null se i campi erano tutti vuoti e nessun elemento Ë stato aggiunto</returns>
        public static XmlElement CreaRigaChild(XmlElement x, DataTable TSchema, DataRow Rsp_data, Hashtable H) {
            bool Nullable = IsNullable(TSchema, x) ;
            XmlDocument xdoc = x.OwnerDocument;
            XmlElement child = xdoc.CreateElement(TSchema.TableName);
            XmlElement toadd = fillRigaChild(child, TSchema, Rsp_data, H,Nullable);
            if (toadd != null) x.AppendChild(toadd);
            return toadd;
        }


        
        /// <summary>
        /// Riempie i campi di un elemento dato con le colonne presenti in TChild e i valori presenti in Rsp_Data, eventualmente con un nome di colonna diverso
        ///  in base alla Hashtable H
        /// </summary>
        /// <param name="x">Elemento da riempire </param>
        /// <param name="TSchema">Tabella con le colonne dell'elemento da creare</param>
        /// <param name="Rsp_data">Riga con i valori da prendere. Ogni valore Ë preso dalla colonna di pari nome oppure da Rsp_data[H[nome colonna]] se presente</param>
        /// <param name="H">Traslazione dei nomi di colonna ove necessario, per prendere i dati da Rsp_data</param>
        /// <returns>Elemento creato o null se i campi erano tutti vuoti</returns>
        private static XmlElement fillRigaChild(XmlElement child, 
                    DataTable TSchema, DataRow Rsp_data, Hashtable H, bool AllowSkip) {
            XmlDocument xdoc = child.OwnerDocument;
            bool somethingNotNull = false;
            foreach (DataColumn C in TSchema.Columns) {
                string field = C.ColumnName;
                string source_field = field;
                if (H != null) {
                    if (H.Contains(field)) {
                        if (H[field].ToString() == "") continue; //non copiare questo campo
                        source_field = H[field].ToString();
                    }
                }
                if (!Rsp_data.Table.Columns.Contains(source_field)) {
                    if (!source_field.EndsWith("_Id")) {
                        MessageBox.Show("La riga prodotta dalla sp di esportazione per la tabella "+
                            TSchema.TableName+
                            " non contiene il campo " + source_field, "Errore");
                    }
                    continue;
                }
                bool data_present=  (Rsp_data[source_field].ToString().Trim() != "");

                if (data_present){
                    somethingNotNull = true;
                }

                if ((data_present==false) && (TSchema.Columns[field].AllowDBNull==false)   ) {
                    string XX = "";
                    foreach (DataColumn CC in Rsp_data.Table.Columns) {
                        if (Rsp_data[CC.ColumnName].ToString().Trim() != "") {
                            XX += CC.ColumnName + ":" + Rsp_data[CC.ColumnName].ToString()+"\r\n";
                        }
                    }
                    //QueryCreator.MarkEvent("Campo "+field+ " not nullable trovato vuoto in sezione "+TSchema.TableName+
                    //            ". Altri valori presenti:"+XX);

                    if (AllowSkip == false) {
                        MessageBox.Show("La colonna " + field + " della sezione " + TSchema.TableName +
                            " non contiene alcun valore. Valori presenti:" + XX, "Errore");
                    }
                }

                if (data_present) {
                    XmlElement xel = xdoc.CreateElement(field);
                    XmlText val = xdoc.CreateTextNode(FormatXmlString(C,Rsp_data[source_field]));
                    xel.AppendChild(val);
                    child.AppendChild(xel);
                }
                //Rchild[field] = Rsp_data[source_field];
            }
            if (!somethingNotNull) {                
                return null;
            }
            
            return child;
        }

        private static string FormatXmlString(DataColumn C, object val) {
            if (val == DBNull.Value) return "";
            if (C.DataType == typeof(decimal)) {
                decimal dval = Convert.ToDecimal(val);
                return dval.ToString(CultureInfo.InvariantCulture.NumberFormat);
            }
            if (C.DataType == typeof(DateTime) && val.GetType()==typeof(DateTime)) {
                Console.WriteLine(C.ColumnName);
                foreach (object A in C.ExtendedProperties) Console.WriteLine(A.ToString());
                Console.WriteLine("----------");
                
            }
            //if (C.DataType == typeof(string)) {
            //    string res = HttpUtility.HtmlEncode(val.ToString());
            //    if (res != val.ToString()) {
            //        Console.WriteLine("Converted {0} into {1}", val,res);
            //    }
            //    return res;
            //}
            return val.ToString().Replace(Convert.ToChar((byte)0x1F), ' ');
        }

        public static  object isNull(object x, object y) {
            if (x == null || x == DBNull.Value) return y;
            return x;
        }

        public static DateTime AsDate(XmlNode X, string field) {
            if (X == null) throw new Exception("Sezione assente per campo data " + field);
            if (X[field] == null) throw new Exception("Campo data " + field + " non trovato nel nodo XML "+X.OuterXml);
            DateTime T;
            try {
                T = DateTime.Parse(X[field].InnerText);
            }
            catch {
                throw new Exception("Formato errato nel campo data " + field + " nel nodo XML " + X.OuterXml);
            }
            return T;
        }

        public static object AsOptionalDate(XmlNode X, string field)
        {
            if (X == null) throw new Exception("Sezione assente per campo data " + field);
            if (X[field] == null) return DBNull.Value ;
            DateTime T;
            try
            {
                T = DateTime.Parse(X[field].InnerText);
            }
            catch
            {
                throw new Exception("Formato errato nel campo data " + field + " nel nodo XML " + X.OuterXml);
            }
            return T;
        }

        public static Decimal AsDecimal(XmlNode X, string field) {
            if (X == null) throw new Exception("Sezione assente per campo decimal " + field);
            if (X[field] == null) throw new Exception("Campo decimal " + field + " non trovato nel nodo XML " + X.OuterXml);
            decimal d;
            try {
                d = Decimal.Parse(X[field].InnerText, System.Globalization.CultureInfo.InvariantCulture);
            }
            catch {
                throw new Exception("Formato errato nel campo decimal " + field + " nel nodo XML " + X.OuterXml);
            }
            return d;
        }

        public static object AsOptionalInt(XmlNode X, string field) {
            if (X == null) throw new Exception("Sezione assente per campo intero " + field);
            if (X[field] == null) return DBNull.Value;
            int d;
            try {
                d = Int32.Parse(X[field].InnerText);
            }
            catch {
                return DBNull.Value;
            }
            return d;
        }

        public static int AsInt(XmlNode X, string field) {
            if (X == null) throw new Exception("Sezione assente per campo intero " + field);
            if (X[field] == null) throw new Exception("Campo intero " + field + " non trovato nel nodo XML " + X.OuterXml);
            int d;
            try {
                d = Int32.Parse(X[field].InnerText);
            }
            catch {
                throw new Exception("Formato errato nel campo intero " + field + " nel nodo XML " + X.OuterXml);
            }
            return d;
        }


        public static string AsString(XmlNode X, string field) {
            if (X == null) throw new Exception("Sezione assente per campo stringa " + field);
            if (X[field] == null) throw new Exception("Campo stringa " + field + " non trovato nel nodo XML " + X.OuterXml);
            return X[field].InnerText;
        }

        public static void SortElement(XmlElement E, string[] elnames) {
            if (E == null) return;
            XmlDocument xdoc = E.OwnerDocument;
            XmlElement N = xdoc.CreateElement(E.Name);

            foreach (string elname in elnames) {
                XmlNodeList l = E.GetElementsByTagName(elname);
                if (l.Count == 0) continue;
                List<XmlNode> lista_nodi = new List<XmlNode>();
                foreach (XmlNode node in l) lista_nodi.Add(node);
                foreach (XmlNode node in lista_nodi) {
                    XmlNode ncopy = node.Clone();

                    N.AppendChild(ncopy);
                }
            }
            E.ParentNode.ReplaceChild(N, E);
        }
    }

    public static class XML_XSD_Validator {
        static int numErrors = 0;
        static string msgError = "";

        //public static bool Validate(Stream xml, string xsdFilename) {
        //    return Validate(xml, GetFileStream(xsdFilename));
        //}
        public static bool Validate(string xmlFilename, Stream xsd) {
            return Validate(GetFileStream(xmlFilename), xsd);
        }

        public static bool Validate(string xmlFilename, string xsdFilename) {
            return Validate(GetFileStream(xmlFilename), xsdFilename);
        }

        static Dictionary<string,XmlReaderSettings> allXmlReaderSettings = new Dictionary<string, XmlReaderSettings>();

        public static bool Validate(Stream xml, string xsdFileName) {
            ClearErrorMessage();
            XmlReaderSettings settings;
            try {
                if (!allXmlReaderSettings.ContainsKey(xsdFileName)) {
                    var xmlSchema = XmlSchema.Read(GetFileStream(xsdFileName), null);
                    var xmlSchemaSet = new XmlSchemaSet();
                    xmlSchemaSet.Add(xmlSchema);
                    xmlSchemaSet.Compile();

                    settings = new XmlReaderSettings();
                    settings.ValidationType = ValidationType.Schema;
                    settings.Schemas.Add(xmlSchema);
                    settings.ValidationFlags |= XmlSchemaValidationFlags.ReportValidationWarnings;
                    settings.ValidationEventHandler += new ValidationEventHandler(ErrorHandler);

                    allXmlReaderSettings[xsdFileName] = settings;
                }
                else {
                    settings = allXmlReaderSettings[xsdFileName];
                }
                
                XmlReader reader = XmlReader.Create(xml, settings);

                // Validate XML data
                while (reader.Read());
                reader.Close();

                // exception if validation failed
                if (numErrors > 0)
                    throw new Exception(msgError);
                xml.Close();
                return true;
            }
            catch (Exception E) {
                xml.Close();

                msgError = "Validation failed\r\n" + E.ToString()+"\r\n"+ msgError;
                return false;
            }
        }

        public static bool Validate(Stream xml, Stream xsd) {
            ClearErrorMessage();
            try {
                XmlTextReader tr = new XmlTextReader(xsd);
                XmlSchemaSet schema = new XmlSchemaSet();
                schema.Add(null, tr);

                XmlReaderSettings settings = new XmlReaderSettings();
                settings.ValidationType = ValidationType.Schema;
                settings.Schemas.Add(schema);
                settings.ValidationFlags |= XmlSchemaValidationFlags.ReportValidationWarnings;
                settings.ValidationEventHandler += new ValidationEventHandler(ErrorHandler);


                XmlReader reader = XmlReader.Create(xml, settings);

                // Validate XML data
                while (reader.Read());
                reader.Close();

                // exception if validation failed
                if (numErrors > 0)
                    throw new Exception(msgError);
                xml.Close();
                xsd.Close();

                return true;
            }
            catch (Exception E) {
                xml.Close();
                xsd.Close();

                msgError = "Validation failed\r\n" + E.ToString()+"\r\n"+ msgError;
                return false;
            }
        }

        private static void ErrorHandler(object sender, ValidationEventArgs args) {
            msgError = msgError + "\r\n" + args.Message;
            numErrors++;
        }

        // if a validation error occurred, this will return the message
        public static string GetError() {
            return msgError;
        }

        private static void ClearErrorMessage() {
            msgError = "";
            numErrors = 0;
        }

        // returns a stream of the contents of the given filename
        private static Stream GetFileStream(string filename) {
            try {
                var b = File.ReadAllBytes(filename);
                return new MemoryStream(b);
            }
            catch {
                return null;
            }
        }
    }
}
