using System;
using System.Xml.Serialization;

namespace preserve.UniStorage.Serialization.Metadata.Unimatica.Documento {

	// using System.Xml.Serialization;
	// XmlSerializer serializer = new XmlSerializer(typeof(Documento));
	// using (StringReader reader = new StringReader(xml))
	// {
	//    var test = (Documento)serializer.Deserialize(reader);
	// }

	[XmlRoot(ElementName = "Intestazione")]
	public class Intestazione {

		[XmlElement(ElementName = "IdFile")]
		public Guid IdFile { get; set; }

		[XmlElement(ElementName = "NomeFile")]
		public string NomeFile { get; set; }

		[XmlElement(ElementName = "Principale")]
		public bool Principale { get; set; }
	}

	[XmlRoot(ElementName = "MetadatiSpecifici")]
	public class MetadatiSpecifici {

		[XmlElement(ElementName = "metadatoCustom")]
		public string MetadatoCustom { get; set; }
	}

	[XmlRoot(ElementName = "Profilo")]
	public partial class Profilo {

		[XmlElement(ElementName = "MetadatiSpecifici")]
		public MetadatiSpecifici MetadatiSpecifici { get; set; }

		private string agid { get; set; }
		[XmlElement(ElementName = "MetadatiAGID")]
		public System.Xml.XmlCDataSection MetadatiAGIDCDataSection {
			get {
				return new System.Xml.XmlDocument().CreateCDataSection(agid);
			}
			set {
				agid = value.Value;
			}
		}
	}

	[XmlRoot(ElementName = "Documento")]
	public class Documento {

		[XmlElement(ElementName = "Intestazione")]
		public Intestazione Intestazione { get; set; }

		[XmlElement(ElementName = "Profilo")]
		public Profilo Profilo { get; set; }

		[XmlAttribute(AttributeName = "xsd")]
		public string Xsd { get; set; }

		[XmlAttribute(AttributeName = "xsi")]
		public string Xsi { get; set; }

		[XmlText]
		public string Text { get; set; }

	}
}
