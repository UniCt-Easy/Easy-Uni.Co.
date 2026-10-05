using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using metadatalibrary;
using sdiDbConnection;
using sdiConfig;
using System.Data;
using sdiLog;
using Xceed.FileSystem;
using Xceed.Zip;
using System.IO;
using System.Net.Mail;
using eventLog;
using sdipassword;
using AegisImplicitMail;
using ftpfun;

using Document;
using Document.IPA;
using Document.SDI;

namespace preserve {
    public static class SingleMetaData {
        public static XElement getXml(string nameSpace, string name, string value) {
            XElement singleM = new XElement("singlemetadata");
            if (nameSpace != null) {
                singleM.Add(new XElement("namespace", nameSpace));
            }
            singleM.Add(new XElement("name", name));
            singleM.Add(new XElement("value", value));
            return singleM;
        }
    }

    public static class ComplexMetaData {

        public static XElement getXml(string nameSpace, string name, string nameSpaceNode, string nodeName) {
            XElement complexM = new XElement("complexmetadata");
            if (nameSpaceNode != null) {
                complexM.Add(new XAttribute("namespace", nameSpace));
            }
            if (name != null) {
                complexM.Add(new XAttribute("name", name));
            }
            if (nameSpaceNode != null) {
                complexM.Add(new XAttribute("namespaceNode", nameSpaceNode));
            }
            if (nodeName != null) {
                complexM.Add(new XAttribute("nodeName", nodeName));
            }
            return complexM;
        }
    }

    /// <summary>
    /// Classe per produrre xelement per destinatario, soggettotributario, soggettoproduttore
    /// </summary>
    public class Soggetto : ISoggetto {
        public string cognome;
        public string denominazione;
        public string codicefiscale;
        public string partitaiva;
        public string nome;
        public string IPAAmm = null;
        public string IPAAOO = null;
        public string IPAUOR = null;
        public string[] IndirizziDigitali = null;

        public string Cognome => cognome;

        public string Denominazione => denominazione;

        public string CodiceFiscale => codicefiscale;

        public string PartitaIVA => partitaiva;

        public string Nome => nome;

        string ISoggetto.IPAAmm => IPAAmm;

        string ISoggetto.IPAAOO => IPAAOO;

        string ISoggetto.IPAUOR => IPAUOR;

        string[] ISoggetto.IndirizziDigitali => IndirizziDigitali;

        public Soggetto() { }   // ci serve per literal

        public Soggetto(string denominazione, string partitaiva, string cf) {
            this.denominazione = denominazione;
            this.partitaiva = partitaiva;
            this.codicefiscale = cf;
        }
        public Soggetto(string nome, string cognome, string cf, string partitaiva) {
            this.nome = nome;
            this.cognome = cognome;
            this.codicefiscale = cf;
            this.partitaiva = partitaiva;
        }

        public XElement getXml(string tipoSoggetto, string nameSpace, string nameSpaceNode) {
            XElement e = ComplexMetaData.getXml(nameSpace, tipoSoggetto, nameSpaceNode, "soggetto");
            if (this.cognome != null) {
                e.Add(SingleMetaData.getXml(nameSpaceNode, "cognome", this.cognome));
            }
            else {
                e.Add(SingleMetaData.getXml(nameSpaceNode, "cognome", ""));
            }
            if (this.denominazione != null) {
                e.Add(SingleMetaData.getXml(nameSpaceNode, "denominazione", this.denominazione));
            }
            else {
                e.Add(SingleMetaData.getXml(nameSpaceNode, "denominazione", ""));
            }
            if (this.codicefiscale != null) {
                e.Add(SingleMetaData.getXml(nameSpaceNode, "codicefiscale", this.codicefiscale));
            }
            else {
                e.Add(SingleMetaData.getXml(nameSpaceNode, "codicefiscale", ""));
            }

            if (this.partitaiva != null) {
                e.Add(SingleMetaData.getXml(nameSpaceNode, "partitaiva", this.partitaiva));
            }
            else {
                e.Add(SingleMetaData.getXml(nameSpaceNode, "partitaiva", ""));
            }

            if (this.nome != null) {
                e.Add(SingleMetaData.getXml(nameSpaceNode, "nome", this.nome));
            }
            else {
                e.Add(SingleMetaData.getXml(nameSpaceNode, "nome", ""));
            }

            return e;
        }

        public static Soggetto getFromEnte(string codIpa = null) {
			if (codIpa != null) return getFromEnteMulti(codIpa);
			serviceconfig s = SdiConfigManager.getServiceConfig();
            DataRow r = s.Tables["cfg"].Rows[0];
            return new Soggetto(r["cons_denom"].ToString(), r["cons_p_iva"].ToString(), r["cons_cf"].ToString());
        }
		private static Soggetto getFromEnteMulti(string codIpa) {
			serviceconfig s = SdiConfigManager.getMultiServiceConfig(codIpa);
			DataRow r = s.Tables["cfg"].Rows[0];
			return new Soggetto(r["cons_denom"].ToString(), r["cons_p_iva"].ToString(), r["cons_cf"].ToString());
		}
		public static Soggetto getFromProduttore(string codIpa = null) {
			if (codIpa != null) return getMultiFromProduttore(codIpa);
			serviceconfig s = SdiConfigManager.getServiceConfig();
            DataRow r = s.Tables["cfg"].Rows[0];
            return new Soggetto(r["cons_denomProduttore"].ToString(), r["cons_p_ivaProduttore"].ToString(), r["cons_cfProduttore"].ToString());
        }
		private static Soggetto getMultiFromProduttore(string codIpa) {
			serviceconfig s = SdiConfigManager.getMultiServiceConfig(codIpa);
			DataRow r = s.Tables["cfg"].Rows[0];
			return new Soggetto(r["cons_denomProduttore"].ToString(), r["cons_p_ivaProduttore"].ToString(), r["cons_cfProduttore"].ToString());
		}
	}


    public class PreserveFile {
        string docid; //un identificativo univoco, dal lato di chi versa, al singolo documento. 
        public string fileName; //indica il nome del documento, comprensivo di eventuale estensione, così come viene memorizzato su file system
        public byte[] content;
        string mimeType;   //indica il tipo di documento, nel senso informatico del termine   RFC 20463
        DateTime closingDate; //la data di ultima modifica , la possiamo assumere pari alla data versamento
        string hash; // : hash in SHA256 codificato in base64. Check con http://www.webutils.pl/index.php?idx=sha1

        List<XElement> extraInfo = new List<XElement>();
        DateTime dataDocumento;
        DateTime dataDocumentoTributario; //lo lascerei vuoto
        string oggettodocumento;
        string nameSpaceEsterno;
        string nameSpaceInterno;

        string pdvidref = null;//al momento non sono mai assegnati
        string docidref = null; //al momento non sono mai assegnati


        public int id_sdi;
        public string identificativo_sdi;
        public string codIpa;
        public string protocollo;

        Soggetto destinatario;
        Soggetto soggettotributario;
        Soggetto soggettoproduttore;
        /// <summary>
        /// Aggiunge un extra info
        /// </summary>
        /// <param name="name">tipologia tipoNotifica progressivo idOrigine applicativoProduzione esito
        /// nomeSezionale allegato1  cfTitolareFirma note2 soggettoImposta 	numeroFattura  notaAccredito  idSistemaVersante idDocumentoOriginale
        /// allegato2 note1 condizioniAccesso codiceTipologia livelloRiservatezza sezionale	ddt        
        /// </param>
        /// <param name="value"></param>
        public void setExtraInfo(string name, string value) {
            extraInfo.Add(SingleMetaData.getXml(nameSpaceInterno, name, value));
        }


        public string formatClosingDate(DateTime d) {
            return d.Year.ToString() + "-" + d.Month.ToString().PadLeft(2, '0') + "-" + d.Day.ToString().PadLeft(2, '0');
        }

        public PreserveFile(string nameSpaceEsterno, string nameSpaceInterno) {
            this.nameSpaceEsterno = nameSpaceEsterno;
            this.nameSpaceInterno = nameSpaceInterno;
        }
        public XElement getXml(string codIpa=null) {
            XElement e = new XElement("file");
            e.Add(new XElement("docid", docid));
            e.Add(new XElement("filename", fileName));
            e.Add(new XElement("mimetype", mimeType));
            e.Add(new XElement("closingDate", formatClosingDate(closingDate)));

            XElement Xalgo = new XElement("hash", new XElement("value", hash));
            Xalgo.Add(new XAttribute("algorithm", "SHA-256"));
            e.Add(Xalgo);

            XElement XmetaData = new XElement("metadata");
            e.Add(XmetaData);

            XElement mandatory = new XElement("mandatory");
            XmetaData.Add(mandatory);


            bool scrivi_conservazione_doc = true;
            serviceconfig s;
            if (codIpa == null) {
                s = SdiConfigManager.getServiceConfig();
            }
            else {
                s = SdiConfigManager.getMultiServiceConfig(codIpa);
            }
            DataRow r = s.Tables["cfg"].Rows[0];
            if (r["cons_classedocumentale"].ToString() != "") {
                var docClass = r["cons_classedocumentale"].ToString();
                if(docClass == "fattura") {
                    scrivi_conservazione_doc = false;
                }
            }

            if (scrivi_conservazione_doc) {
                mandatory.Add(SingleMetaData.getXml(nameSpaceInterno, "dataDocumento",
                    XmlConvert.ToString(dataDocumento, XmlDateTimeSerializationMode.Unspecified)));
            }
            mandatory.Add(SingleMetaData.getXml(nameSpaceInterno, "dataDocumentoTributario",
                XmlConvert.ToString(dataDocumentoTributario, XmlDateTimeSerializationMode.Unspecified)));
            mandatory.Add(SingleMetaData.getXml(nameSpaceInterno, "oggettodocumento",
                oggettodocumento));
            
            if (destinatario != null) {
                mandatory.Add(destinatario.getXml("destinatario", nameSpaceInterno, "conservazione.soggetti"));
            }
            if (destinatario != null) {
                mandatory.Add(soggettotributario.getXml("soggettotributario", nameSpaceInterno, "conservazione.soggetti"));
            }
            if (soggettoproduttore != null) {
                mandatory.Add(soggettoproduttore.getXml("soggettoproduttore", nameSpaceInterno, "conservazione.soggetti"));
            }

            if (extraInfo.Count > 0) {
                XElement xInfo = new XElement("extrainfos");
                foreach (XElement eInfo in extraInfo) {
                    xInfo.Add(eInfo);
                }
                XmetaData.Add(xInfo);
            }

            if (pdvidref != null || docidref != null) {
                XElement xRef = new XElement("riferimento");
                if (pdvidref != null) {
                    xRef.Add(new XElement("pdvidref", pdvidref));
                }
                if (docidref != null) {
                    xRef.Add(new XElement("docidref", docidref));
                }
                e.Add(xRef);
            }

            return e;
        }

        // ==================================================================
        //                             FATTURE
        // ==================================================================
        public static string getXmlText(XmlNode x, string xpath, XmlNamespaceManager ns) {
            if (ns == null) {
                try {
                    XmlNode n = x.SelectSingleNode(xpath);
                    if (n != null) {
                        return n.InnerText;
                    }
                }
                catch {
                }
                return null;
            }

            try {
                XmlNode n = x.SelectSingleNode(xpath, ns);
                if (n != null) {
                    return n.InnerText;
                }
            }
            catch {
            }
            return null;
        }

        //// ==================================================================
        ////                              NSO
        //// ==================================================================
        //public static string getXmlTextNso(XmlNode x, string xpath)
        //{
        //    // x: <Order>
        //    // xpath: cac:SellerSupplierParty/cac:Party/cac:Contact/cbc:Name
        //    try
        //    {
        //        int levelFound = 0;

        //        string[] paths = xpath.Split('/');
        //        foreach (string path in paths)
        //        {
        //            string[] parts = path.Split(':');
        //            string part = parts.Length == 1 ? parts[0] : parts[1];
        //            // part = SellerSupplierParty

        //            // ChildNodes: <CustomizationID>, <ProfileID>, ..., <ns3:SellerSupplierParty>
        //            foreach (XmlNode c in x.ChildNodes)
        //            {
        //                string[] names = c.Name.Split(':');
        //                string name = names.Length == 1 ? names[0] : names[1];

        //                if (name == part)
        //                {
        //                    x = c;
        //                    levelFound++;
        //                    break;
        //                }
        //            }
        //        }

        //        if (levelFound == paths.Length) return x.InnerText;
        //    }
        //    catch { }

        //    return "";
        //}

        public static XmlNode getXmlNodeNso(XmlDocument x, string xpath)
        {
            // x: <Order>
            // xpath: cac:SellerSupplierParty/cac:Party/cac:Contact/cbc:Name
            XmlNode node = null;

            try
            {
                int levelFound = 0;

                string[] paths = xpath.Split('/');

                string lastnode = paths[paths.Length - 1];  // ultimo nodo da cercare
                string[] lastnodeparts = lastnode.Split(':'); // elimino il prefisso del namespace
                string lastnodepart = lastnodeparts.Length == 1 ? lastnodeparts[0] : lastnodeparts[1];

                foreach (string path in paths)
                {
                    // ChildNodes: <CustomizationID>, <ProfileID>, ..., <ns3:SellerSupplierParty>
                    foreach (XmlNode c in x.ChildNodes)
                    {
                        string[] names = c.Name.Split(':');
                        string name = names.Length == 1 ? names[0] : names[1];

                        if (name == "xml") continue;

                        if (name == lastnodepart)
                        {
                            node = c;
                            levelFound++;
                            break;
                        }
                    }
                }

                if (levelFound == paths.Length) return node;
            }
            catch { }

            return node;
        }

        public static XmlNode getXmlNodeNso(XmlNode x, string xpath)
        {
            // x: <Order>
            // xpath: cac:SellerSupplierParty/cac:Party/cac:Contact/cbc:Name
            XmlNode node = null;

            try
            {
                int levelFound = 0;

                string[] paths = xpath.Split('/');
                foreach (string path in paths)
                {
                    string[] parts = path.Split(':');
                    string part = parts.Length == 1 ? parts[0] : parts[1];
                    // part = SellerSupplierParty

                    // ChildNodes: <CustomizationID>, <ProfileID>, ..., <ns3:SellerSupplierParty>
                    foreach (XmlNode c in x.ChildNodes)
                    {
                        string[] names = c.Name.Split(':');
                        string name = names.Length == 1 ? names[0] : names[1];

                        if (name == part)
                        {
                            node = c;
                            levelFound++;
                            break;
                        }
                    }
                }

                if (levelFound == paths.Length) return node;
            }
            catch { }

            return node;
        }

        public static string sha256(string txt) {
            System.Security.Cryptography.SHA256Managed crypt = new System.Security.Cryptography.SHA256Managed();
            System.Text.StringBuilder hash = new System.Text.StringBuilder();
            byte[] crypto = crypt.ComputeHash(Encoding.UTF8.GetBytes(txt), 0, Encoding.UTF8.GetByteCount(txt));
            foreach (byte bit in crypto) {
                hash.Append(bit.ToString("x2"));
            }
            string x = System.Convert.ToBase64String(crypto);//hash.ToString();
            return x;
        }
        public static string sha256(byte[] document) {
            System.Security.Cryptography.SHA256Managed crypt = new System.Security.Cryptography.SHA256Managed();
            System.Text.StringBuilder hash = new System.Text.StringBuilder();
            byte[] crypto = crypt.ComputeHash(document, 0, document.Length);
            foreach (byte bit in crypto) {
                hash.Append(bit.ToString("x2"));
            }
            string x = System.Convert.ToBase64String(crypto);//hash.ToString();
            return x;
        }

        public static string getCig(XmlDocument x) {
            string cig = null;
            foreach (XmlNode d in x.SelectNodes("//FatturaElettronicaBody/DatiGenerali/DatiOrdineAcquisto")) {
                if (d["CodiceCIG"] != null) {
                    cig = d["CodiceCIG"].InnerText;
                    if (cig != null && cig != "")
                        return cig;
                }
            }
            foreach (XmlNode d in x.SelectNodes("//FatturaElettronicaBody/DatiGenerali/DatiContratto")) {
                if (d["CodiceCIG"] != null) {
                    cig = d["CodiceCIG"].InnerText;
                    if (cig != null && cig != "")
                        return cig;
                }
            }
            foreach (XmlNode d in x.SelectNodes("//FatturaElettronicaBody/DatiGenerali/DatiConvenzione")) {
                if (d["CodiceCIG"] != null) {
                    cig = d["CodiceCIG"].InnerText;
                    if (cig != null && cig != "")
                        return cig;
                }
            }
            foreach (XmlNode d in x.SelectNodes("//FatturaElettronicaBody/DatiGenerali/DatiRicezione")) {
                if (d["CodiceCIG"] != null) {
                    cig = d["CodiceCIG"].InnerText;
                    if (cig != null && cig != "")
                        return cig;
                }
            }
            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="Conn">Connessione all'ente</param>
        /// <returns></returns>
        public static string getRiferimentoAmministrazione(XmlDocument x,DataAccess Conn) {            
            QueryHelper q = Conn.GetQueryHelper();

            string riferimentoAmministrazione = getXmlText(x, "//FatturaElettronicaHeader/CedentePrestatore/RiferimentoAmministrazione", null);
            if (riferimentoAmministrazione != null && riferimentoAmministrazione.ToString().Trim() != "") {

                if (Conn.RUN_SELECT_COUNT("sdi_rifamm", q.CmpEq("idsdi_rifamm", riferimentoAmministrazione), false) == 1) {
                    return riferimentoAmministrazione;
                }
            }
            string cig = getCig(x);
            if (cig == null)
                return null;
            object rifamm = Conn.DO_SYS_CMD("select top 1 MK.riferimento_amministrazione from " +
                        " mandatekind MK join mandatedetail MD on MD.idmankind=MK.idmankind " +
                        " where " + q.CmpEq("MD.cigcode", cig), true);
            if (rifamm != null && rifamm.ToString().Trim() != "") {
                if (Conn.RUN_SELECT_COUNT("sdi_rifamm", q.CmpEq("idsdi_rifamm", rifamm), false) == 1) {
                    return rifamm.ToString();
                }
            }

            string p_iva = XMLUtils.getP_IVACedentePrestatore(x);
            if (p_iva != null) {
                if (p_iva.StartsWith("IT"))
                    p_iva = p_iva.Substring(2);
                rifamm = Conn.DO_SYS_CMD("select top 1 R.sdi_defrifamm from registry R where p_iva  = " + q.quote(p_iva) + " and sdi_defrifamm is not null", true);
                if (rifamm != null && rifamm.ToString().Trim() != "") {
                    if (Conn.RUN_SELECT_COUNT("sdi_rifamm", q.CmpEq("idsdi_rifamm", rifamm), false) == 1) {
                        return rifamm.ToString();
                    }
                }
            }

            string cf = XMLUtils.getCodiceFiscaleCedentePrestatore(x);
            if (cf != null) {
                rifamm = Conn.DO_SYS_CMD("select top 1 R.sdi_defrifamm from registry R where cf  = " + q.quote(cf) + " and sdi_defrifamm is not null", true);
                if (rifamm != null && rifamm.ToString().Trim() != "") {
                    if (Conn.RUN_SELECT_COUNT("sdi_rifamm", q.CmpEq("idsdi_rifamm", rifamm), false) == 1) {
                        return rifamm.ToString();
                    }
                }
            }

            return null;
        }

        /// <summary>
        /// Per le fatture di acquisto:
        /// docid = 
        /// </summary>
        /// <param name="f"></param>
        public void getDataFromFatturaAcquisto(byte[] document, XmlDocument x, string filenameOriginale,DataAccess conn, ISoggetto s = null /*, string codIpa = null*/) {
            XmlNode xHead = x.GetElementsByTagName("FatturaElettronicaHeader")[0];
            XmlNodeList xBody = x.GetElementsByTagName("FatturaElettronicaBody");
            string Denominazione = getXmlText(x, "//FatturaElettronicaHeader/CedentePrestatore/DatiAnagrafici/Anagrafica/Denominazione", null);
            string Nome = getXmlText(x, "//FatturaElettronicaHeader/CedentePrestatore/DatiAnagrafici/Anagrafica/Nome", null);
            string Cognome = getXmlText(x, "//FatturaElettronicaHeader/CedentePrestatore/DatiAnagrafici/Anagrafica/Cognome", null);
            string numeroDocumento = getXmlText(x, "//FatturaElettronicaBody/DatiGenerali/DatiGeneraliDocumento/Numero", null);
            string Causale = getXmlText(x, "//FatturaElettronicaBody/DatiGenerali/DatiGeneraliDocumento/Causale", null);
            //string ddt = getXmlText(x, "//FatturaElettronicaBody/DatiGenerali/DatiDDT/NumeroDDT", null);
            string sData = getXmlText(x, "//FatturaElettronicaBody/DatiGenerali/DatiGeneraliDocumento/Data", null);
            DateTime dData = XmlConvert.ToDateTime(sData, XmlDateTimeSerializationMode.Unspecified);

            string p_iva = XMLUtils.getP_IVACedentePrestatore(x);
            string cf = XMLUtils.getCodiceFiscaleCedentePrestatore(x);
            if (Denominazione != null) {
                soggettotributario = new Soggetto(Denominazione, p_iva, cf);
            }
            else {
                soggettotributario = new Soggetto(Nome, Cognome, cf, p_iva);
            }

            this.destinatario = Soggetto.getFromEnte(codIpa);
            this.soggettoproduttore = Soggetto.getFromProduttore(codIpa);
            this.docid = this.protocollo;
            if (this.docid == null || this.docid.ToString() == "") {
                this.docid = this.id_sdi.ToString();
            }
            this.fileName = filenameOriginale;
            this.content = document; //Encoding.UTF8.GetBytes(x.OuterXml);
            this.mimeType = "application/xml";
            this.closingDate = DateTime.Now;
            this.hash = sha256(document);// sha256(x.OuterXml);

            this.dataDocumento = dData;
            this.dataDocumentoTributario = dData;
            this.oggettodocumento = Causale;

            setExtraInfo("tipologia", "Fattura di acquisto");
            //setExtraInfo("tipoNotifica", "Fattura di acquisto");
            setExtraInfo("progressivo", this.id_sdi.ToString()); //idsdi_acquisto
            //setExtraInfo("idOrigine", null); //idsdi_acquisto
            setExtraInfo("applicativoProduzione", "Easy"); //idsdi_acquisto
            //setExtraInfo("idOrigine", identificativo_sdi.ToString());
            if (identificativo_sdi != null) {
                setExtraInfo("idDocumentoOriginale", identificativo_sdi.ToString());
            }
            setExtraInfo("numeroFattura", numeroDocumento);
            setExtraInfo("nomeSezionale", getRiferimentoAmministrazione(x,conn));
            //setExtraInfo("sezionale", null);

            //setExtraInfo("ddt", ddt);


        }

        public void getDataFromOrdineVendita(byte[] document, XmlDocument xml, string filenameOriginale, DataAccess conn, string codIpa = null) {

            // ===============================================================
            // DOCUMENT
            // ===============================================================
            XmlNode x = getXmlNodeNso(xml, "StandardBusinessDocument");

            // ===============================================================
            // ORDER
            // ===============================================================
            if (x == null)
                x = getXmlNodeNso(xml, "Order");
            else
                x = getXmlNodeNso(x, "Order");

            if (x == null)
                return;

            string Denominazione = XMLUtils.getXmlTextNso(x, "BuyerCustomerParty/Party/PartyName/Name");
            
            string sData = XMLUtils.getXmlTextNso(x, "IssueDate");
            DateTime dData = XmlConvert.ToDateTime(sData, XmlDateTimeSerializationMode.Unspecified);

            string p_iva = XMLUtils.getXmlTextNso(x, "BuyerCustomerParty/Party/PartyTaxScheme/CompanyID");
            string cf = p_iva;
            if (Denominazione != null) {
                destinatario = new Soggetto(Denominazione, p_iva, cf);
            }

            this.soggettotributario = Soggetto.getFromEnte(codIpa);
            this.soggettoproduttore = Soggetto.getFromProduttore(codIpa);

            this.docid = this.protocollo;
            if (this.docid == null || this.docid.ToString() == "") {
                this.docid = filenameOriginale;
            }
            this.fileName = filenameOriginale;
            this.content = document; //Encoding.UTF8.GetBytes(x.OuterXml);
            this.mimeType = "application/xml";
            this.closingDate = DateTime.Now;
            this.hash = sha256(document); //sha256(x.OuterXml);

            this.dataDocumento = dData;
            this.dataDocumentoTributario = dData;

            setExtraInfo("tipologia", "Ordine di vendita");
            setExtraInfo("progressivo", this.id_sdi.ToString()); 
            setExtraInfo("applicativoProduzione", "Easy"); 

            if (identificativo_sdi != null) {
                setExtraInfo("idDocumentoOriginale", identificativo_sdi.ToString());
            }

            setExtraInfo("nomeSezionale", getRiferimentoAmministrazione(xml, conn));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="xMess"></param>
        /// <param name="filenameOriginale"></param>
        /// <param name="conn">Connessione all'ENTE</param>
        /// <param name="codIpa"></param>
        /// <returns></returns>
        public bool getDataFromMessaggioFatturaAcquisto(XmlDocument xMess, string filenameOriginale,DataAccess conn, string codIpa=null) {
            XmlDocument x = getFatturaAcquisto(this.id_sdi,conn);
            if (x == null)
                return false;
            XmlNode xHead = x.GetElementsByTagName("FatturaElettronicaHeader")[0];
            XmlNodeList xBody = x.GetElementsByTagName("FatturaElettronicaBody");
            string Denominazione = getXmlText(x, "//FatturaElettronicaHeader/CedentePrestatore/DatiAnagrafici/Anagrafica/Denominazione", null);
            string Nome = getXmlText(x, "//FatturaElettronicaHeader/CedentePrestatore/DatiAnagrafici/Anagrafica/Nome", null);
            string Cognome = getXmlText(x, "//FatturaElettronicaHeader/CedentePrestatore/DatiAnagrafici/Anagrafica/Cognome", null);
            string numeroDocumento = getXmlText(x, "//FatturaElettronicaBody/DatiGenerali/DatiGeneraliDocumento/Numero", null);
            string Causale = getXmlText(x, "//FatturaElettronicaBody/DatiGenerali/DatiGeneraliDocumento/Causale", null);
            //string ddt = getXmlText(x, "//FatturaElettronicaBody/DatiGenerali/DatiDDT/NumeroDDT", null);
            string sData = getXmlText(x, "//FatturaElettronicaBody/DatiGenerali/DatiGeneraliDocumento/Data", null);
            DateTime dData = XmlConvert.ToDateTime(sData, XmlDateTimeSerializationMode.Unspecified);
            this.identificativo_sdi = getXmlText(xMess, "//IdentificativoSdI", null);

            string p_iva = XMLUtils.getP_IVACedentePrestatore(x);
            string cf = XMLUtils.getCodiceFiscaleCedentePrestatore(x);
            if (Denominazione != null) {
                soggettotributario = new Soggetto(Denominazione, p_iva, cf);
            }
            else {
                soggettotributario = new Soggetto(Nome, Cognome, cf, p_iva);
            }

            this.destinatario = Soggetto.getFromEnte(codIpa);
            this.soggettoproduttore = Soggetto.getFromProduttore(codIpa);
            this.docid = this.protocollo;
            if (this.docid == null || this.docid.ToString() == "") {
                this.docid = this.id_sdi.ToString();
            }
            this.docid += "-" + filenameOriginale;
            this.fileName = filenameOriginale;
            this.content = Encoding.UTF8.GetBytes(xMess.OuterXml);
            this.mimeType = "application/xml";
            this.closingDate = DateTime.Now;
            this.hash = sha256(xMess.OuterXml);

            this.dataDocumento = dData;
            this.dataDocumentoTributario = dData;
            this.oggettodocumento = Causale;

            setExtraInfo("tipologia", "Messaggio Fattura di acquisto");
            //setExtraInfo("tipoNotifica", "Fattura di acquisto");
            setExtraInfo("progressivo", this.id_sdi.ToString()); //idsdi_acquisto
            //setExtraInfo("idOrigine", null); //idsdi_acquisto
            setExtraInfo("applicativoProduzione", "Easy"); //idsdi_acquisto
            //setExtraInfo("idOrigine", identificativo_sdi.ToString());

            if (identificativo_sdi != null) {
                setExtraInfo("idDocumentoOriginale", identificativo_sdi.ToString());
            }
            setExtraInfo("numeroFattura", numeroDocumento);
            setExtraInfo("nomeSezionale", getRiferimentoAmministrazione(x,conn));
            //setExtraInfo("sezionale", null);

            //setExtraInfo("ddt", ddt);
            return true;

        }

        public void getDataFromFatturaVendita(byte[] document, XmlDocument x, string filenameOriginale,DataAccess conn, string codIpa = null) {
            XmlNode xHead = x.GetElementsByTagName("FatturaElettronicaHeader")[0];
            XmlNodeList xBody = x.GetElementsByTagName("FatturaElettronicaBody");
            string Denominazione = getXmlText(x, "//FatturaElettronicaHeader/CedentePrestatore/DatiAnagrafici/Anagrafica/Denominazione", null);
            string Nome = getXmlText(x, "//FatturaElettronicaHeader/CedentePrestatore/DatiAnagrafici/Anagrafica/Nome", null);
            string Cognome = getXmlText(x, "//FatturaElettronicaHeader/CedentePrestatore/DatiAnagrafici/Anagrafica/Cognome", null);
            string numeroDocumento = getXmlText(x, "//FatturaElettronicaBody/DatiGenerali/DatiGeneraliDocumento/Numero", null);
            string Causale = getXmlText(x, "//FatturaElettronicaBody/DatiGenerali/DatiGeneraliDocumento/Causale", null);
            //string ddt = getXmlText(x, "//FatturaElettronicaBody/DatiGenerali/DatiDDT/NumeroDDT", null);
            string sData = getXmlText(x, "//FatturaElettronicaBody/DatiGenerali/DatiGeneraliDocumento/Data", null);
            DateTime dData = XmlConvert.ToDateTime(sData, XmlDateTimeSerializationMode.Unspecified);

            string p_iva = XMLUtils.getP_IVACedentePrestatore(x);
            string cf = XMLUtils.getCodiceFiscaleCedentePrestatore(x);
            if (Denominazione != null) {
                destinatario = new Soggetto(Denominazione, p_iva, cf);
            }
            else {
                destinatario = new Soggetto(Nome, Cognome, cf, p_iva);
            }

            this.soggettotributario = Soggetto.getFromEnte(codIpa);
            this.soggettoproduttore = Soggetto.getFromProduttore(codIpa);

            this.docid = this.protocollo;
            if (this.docid == null || this.docid.ToString() == "") {
                this.docid = filenameOriginale;
            }
            this.fileName = filenameOriginale;
            this.content = document; //Encoding.UTF8.GetBytes(x.OuterXml);
            this.mimeType = "application/xml";
            this.closingDate = DateTime.Now;
            this.hash = sha256(document); //sha256(x.OuterXml);

            this.dataDocumento = dData;
            this.dataDocumentoTributario = dData;
            this.oggettodocumento = Causale;

            setExtraInfo("tipologia", "Fattura di vendita");
            //setExtraInfo("tipoNotifica", "Fattura di acquisto");
            setExtraInfo("progressivo", this.id_sdi.ToString()); //idsdi_vendita
            //setExtraInfo("idOrigine", null); //idsdi_acquisto
            setExtraInfo("applicativoProduzione", "Easy"); //idsdi_acquisto
            //setExtraInfo("idOrigine", identificativo_sdi.ToString());

            if (identificativo_sdi != null) {
                setExtraInfo("idDocumentoOriginale", identificativo_sdi.ToString());
            }
            setExtraInfo("numeroFattura", numeroDocumento);
            setExtraInfo("nomeSezionale", getRiferimentoAmministrazione(x,conn));
            //setExtraInfo("sezionale", null);

            //setExtraInfo("ddt", ddt);


        }
        public void getDataFromFatturaAcquistoEstere(byte[] document, XmlDocument x, string filenameOriginale, DataAccess conn, string codIpa = null) {
            XmlNode xHead = x.GetElementsByTagName("FatturaElettronicaHeader")[0];
            XmlNodeList xBody = x.GetElementsByTagName("FatturaElettronicaBody");
            string Denominazione = getXmlText(x, "//FatturaElettronicaHeader/CedentePrestatore/DatiAnagrafici/Anagrafica/Denominazione", null);
            string Nome = getXmlText(x, "//FatturaElettronicaHeader/CedentePrestatore/DatiAnagrafici/Anagrafica/Nome", null);
            string Cognome = getXmlText(x, "//FatturaElettronicaHeader/CedentePrestatore/DatiAnagrafici/Anagrafica/Cognome", null);
            string numeroDocumento = getXmlText(x, "//FatturaElettronicaBody/DatiGenerali/DatiGeneraliDocumento/Numero", null);
            string Causale = getXmlText(x, "//FatturaElettronicaBody/DatiGenerali/DatiGeneraliDocumento/Causale", null);
            //string ddt = getXmlText(x, "//FatturaElettronicaBody/DatiGenerali/DatiDDT/NumeroDDT", null);
            string sData = getXmlText(x, "//FatturaElettronicaBody/DatiGenerali/DatiGeneraliDocumento/Data", null);
            DateTime dData = XmlConvert.ToDateTime(sData, XmlDateTimeSerializationMode.Unspecified);

            string p_iva = XMLUtils.getP_IVACedentePrestatore(x);
            string cf = XMLUtils.getCodiceFiscaleCedentePrestatore(x);
            if (Denominazione != null) {
                destinatario = new Soggetto(Denominazione, p_iva, cf);
            }
            else {
                destinatario = new Soggetto(Nome, Cognome, cf, p_iva);
            }

            this.soggettotributario = Soggetto.getFromEnte(codIpa);
            this.soggettoproduttore = Soggetto.getFromProduttore(codIpa);

            this.docid = this.protocollo;
            if (this.docid == null || this.docid.ToString() == "") {
                this.docid = filenameOriginale;
            }
            this.fileName = filenameOriginale;
            this.content = document; //Encoding.UTF8.GetBytes(x.OuterXml);
            this.mimeType = "application/xml";
            this.closingDate = DateTime.Now;
            this.hash = sha256(document); //sha256(x.OuterXml);

            this.dataDocumento = dData;
            this.dataDocumentoTributario = dData;
            this.oggettodocumento = Causale;

            setExtraInfo("tipologia", "Fattura di acquisto estera");
            //setExtraInfo("tipoNotifica", "Fattura di acquisto");
            setExtraInfo("progressivo", this.id_sdi.ToString()); //idsdi_acquistoestere
            //setExtraInfo("idOrigine", null); //idsdi_acquisto
            setExtraInfo("applicativoProduzione", "Easy"); //idsdi_acquisto
            //setExtraInfo("idOrigine", identificativo_sdi.ToString());

            if (identificativo_sdi != null) {
                setExtraInfo("idDocumentoOriginale", identificativo_sdi.ToString());
            }
            setExtraInfo("numeroFattura", numeroDocumento);
            setExtraInfo("nomeSezionale", getRiferimentoAmministrazione(x, conn));
            //setExtraInfo("sezionale", null);

            //setExtraInfo("ddt", ddt);


        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="xMess"></param>
        /// <param name="filenameOriginale"></param>
        /// <param name="conn">Connessione all'ente</param>
        /// <param name="codIpa"></param>
        /// <returns></returns>
        public bool getDataFromMessaggioFatturaVendita(XmlDocument xMess, string filenameOriginale,DataAccess conn, string codIpa = null) {
            XmlDocument x = getFatturaVendita(this.id_sdi,conn);
            if (x == null)
                return false;
            XmlNode xHead = x.GetElementsByTagName("FatturaElettronicaHeader")[0];
            XmlNodeList xBody = x.GetElementsByTagName("FatturaElettronicaBody");
            string Denominazione = getXmlText(x, "//FatturaElettronicaHeader/CedentePrestatore/DatiAnagrafici/Anagrafica/Denominazione", null);
            string Nome = getXmlText(x, "//FatturaElettronicaHeader/CedentePrestatore/DatiAnagrafici/Anagrafica/Nome", null);
            string Cognome = getXmlText(x, "//FatturaElettronicaHeader/CedentePrestatore/DatiAnagrafici/Anagrafica/Cognome", null);
            string numeroDocumento = getXmlText(x, "//FatturaElettronicaBody/DatiGenerali/DatiGeneraliDocumento/Numero", null);
            string Causale = getXmlText(x, "//FatturaElettronicaBody/DatiGenerali/DatiGeneraliDocumento/Causale", null);
            //string ddt = getXmlText(x, "//FatturaElettronicaBody/DatiGenerali/DatiDDT/NumeroDDT", null);
            string sData = getXmlText(x, "//FatturaElettronicaBody/DatiGenerali/DatiGeneraliDocumento/Data", null);
            DateTime dData = XmlConvert.ToDateTime(sData, XmlDateTimeSerializationMode.Unspecified);
            this.identificativo_sdi = getXmlText(xMess, "//IdentificativoSdI", null);

            string p_iva = XMLUtils.getP_IVACedentePrestatore(x);
            string cf = XMLUtils.getCodiceFiscaleCedentePrestatore(x);
            if (Denominazione != null) {
                destinatario = new Soggetto(Denominazione, p_iva, cf);
            }
            else {
                destinatario = new Soggetto(Nome, Cognome, cf, p_iva);
            }

            this.soggettotributario = Soggetto.getFromEnte(codIpa);
            this.soggettoproduttore = Soggetto.getFromProduttore(codIpa);

            this.docid = this.protocollo;
            if (this.docid == null || this.docid.ToString() == "") {
                this.docid = filenameOriginale;
            }

            this.fileName = filenameOriginale;
            this.content = Encoding.UTF8.GetBytes(xMess.OuterXml);
            this.mimeType = "application/xml";
            this.closingDate = DateTime.Now;
            this.hash = sha256(xMess.OuterXml);

            this.dataDocumento = dData;
            this.dataDocumentoTributario = dData;
            this.oggettodocumento = Causale;

            setExtraInfo("tipologia", "Messaggio Fattura di vendita");
            //setExtraInfo("tipoNotifica", "Fattura di acquisto");
            setExtraInfo("progressivo", this.id_sdi.ToString()); //idsdi_vendita
            //setExtraInfo("idOrigine", null); //idsdi_vendita
            setExtraInfo("applicativoProduzione", "Easy"); //idsdi_vendita
            //setExtraInfo("idOrigine", identificativo_sdi.ToString());

            if (identificativo_sdi != null) {
                setExtraInfo("idDocumentoOriginale", identificativo_sdi.ToString());
            }
            setExtraInfo("numeroFattura", numeroDocumento);
            setExtraInfo("nomeSezionale", getRiferimentoAmministrazione(x, conn));
            //setExtraInfo("sezionale", null);

            //setExtraInfo("ddt", ddt);

            return true;
        }
        public bool getDataFromMessaggioFatturaAcquistoEstere(XmlDocument xMess, string filenameOriginale, DataAccess conn, string codIpa = null) {
            XmlDocument x = getFatturaAcquistoEstere(this.id_sdi, conn);
            if (x == null)
                return false;
            XmlNode xHead = x.GetElementsByTagName("FatturaElettronicaHeader")[0];
            XmlNodeList xBody = x.GetElementsByTagName("FatturaElettronicaBody");
            string Denominazione = getXmlText(x, "//FatturaElettronicaHeader/CedentePrestatore/DatiAnagrafici/Anagrafica/Denominazione", null);
            string Nome = getXmlText(x, "//FatturaElettronicaHeader/CedentePrestatore/DatiAnagrafici/Anagrafica/Nome", null);
            string Cognome = getXmlText(x, "//FatturaElettronicaHeader/CedentePrestatore/DatiAnagrafici/Anagrafica/Cognome", null);
            string numeroDocumento = getXmlText(x, "//FatturaElettronicaBody/DatiGenerali/DatiGeneraliDocumento/Numero", null);
            string Causale = getXmlText(x, "//FatturaElettronicaBody/DatiGenerali/DatiGeneraliDocumento/Causale", null);
            //string ddt = getXmlText(x, "//FatturaElettronicaBody/DatiGenerali/DatiDDT/NumeroDDT", null);
            string sData = getXmlText(x, "//FatturaElettronicaBody/DatiGenerali/DatiGeneraliDocumento/Data", null);
            DateTime dData = XmlConvert.ToDateTime(sData, XmlDateTimeSerializationMode.Unspecified);
            this.identificativo_sdi = getXmlText(xMess, "//IdentificativoSdI", null);

            string p_iva = XMLUtils.getP_IVACedentePrestatore(x);
            string cf = XMLUtils.getCodiceFiscaleCedentePrestatore(x);
            if (Denominazione != null) {
                destinatario = new Soggetto(Denominazione, p_iva, cf);
            }
            else {
                destinatario = new Soggetto(Nome, Cognome, cf, p_iva);
            }

            this.soggettotributario = Soggetto.getFromEnte(codIpa);
            this.soggettoproduttore = Soggetto.getFromProduttore(codIpa);

            this.docid = this.protocollo;
            if (this.docid == null || this.docid.ToString() == "") {
                this.docid = filenameOriginale;
            }

            this.fileName = filenameOriginale;
            this.content = Encoding.UTF8.GetBytes(xMess.OuterXml);
            this.mimeType = "application/xml";
            this.closingDate = DateTime.Now;
            this.hash = sha256(xMess.OuterXml);

            this.dataDocumento = dData;
            this.dataDocumentoTributario = dData;
            this.oggettodocumento = Causale;

            setExtraInfo("tipologia", "Messaggio Fattura di acquisto estera");
            //setExtraInfo("tipoNotifica", "Fattura di acquisto");
            setExtraInfo("progressivo", this.id_sdi.ToString()); //idsdi_acquistoestere
            //setExtraInfo("idOrigine", null); //idsdi_vendita
            setExtraInfo("applicativoProduzione", "Easy"); //idsdi_vendita
            //setExtraInfo("idOrigine", identificativo_sdi.ToString());

            if (identificativo_sdi != null) {
                setExtraInfo("idDocumentoOriginale", identificativo_sdi.ToString());
            }
            setExtraInfo("numeroFattura", numeroDocumento);
            setExtraInfo("nomeSezionale", getRiferimentoAmministrazione(x, conn));
            //setExtraInfo("sezionale", null);

            //setExtraInfo("ddt", ddt);

            return true;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="xMess"></param>
        /// <param name="filenameOriginale"></param>
        /// <param name="conn">Connessione all'ente</param>
        /// <param name="codIpa"></param>
        /// <returns></returns>
        public bool getDataFromMessaggioOrdineVendita(XmlDocument xMess, string filenameOriginale, DataAccess conn, string codIpa = null) {
            XmlDocument xml = getOrdineVendita(this.id_sdi, conn);

            // ===============================================================
            // DOCUMENT
            // ===============================================================
            XmlNode x = getXmlNodeNso(xml, "StandardBusinessDocument");

            // ===============================================================
            // ORDER
            // ===============================================================
            if (x == null)
                x = getXmlNodeNso(xml, "Order");
            else
                x = getXmlNodeNso(x, "Order");

            if (x == null)
                return false;

            string Denominazione = XMLUtils.getXmlTextNso(x, "BuyerCustomerParty/Party/PartyName/Name");

            string sData = XMLUtils.getXmlTextNso(x, "IssueDate");
            DateTime dData = XmlConvert.ToDateTime(sData, XmlDateTimeSerializationMode.Unspecified);

            string p_iva = XMLUtils.getXmlTextNso(x, "BuyerCustomerParty/Party/PartyTaxScheme/CompanyID");
            string cf = p_iva;
            if (Denominazione != null) {
                destinatario = new Soggetto(Denominazione, p_iva, cf);
            }

            this.soggettotributario = Soggetto.getFromEnte(codIpa);
            this.soggettoproduttore = Soggetto.getFromProduttore(codIpa);

            this.docid = this.protocollo;
            if (this.docid == null || this.docid.ToString() == "") {
                this.docid = filenameOriginale;
            }

            this.fileName = filenameOriginale;
            this.content = Encoding.UTF8.GetBytes(xMess.OuterXml);
            this.mimeType = "application/xml";
            this.closingDate = DateTime.Now;
            this.hash = sha256(xMess.OuterXml);

            this.dataDocumento = dData;
            this.dataDocumentoTributario = dData;

            setExtraInfo("tipologia", "Messaggio Fattura di vendita");
            setExtraInfo("progressivo", this.id_sdi.ToString()); //idsdi_vendita
            setExtraInfo("applicativoProduzione", "Easy"); //idsdi_vendita

            if (identificativo_sdi != null) {
                setExtraInfo("idDocumentoOriginale", identificativo_sdi.ToString());
            }

            setExtraInfo("nomeSezionale", getRiferimentoAmministrazione(xMess, conn));

            return true;
        }

        public static XmlDocument getFatturaAcquisto(int idsdi_acquisto, DataAccess Conn) {
            
            QueryHelper Q = Conn.GetQueryHelper();
            string cond = Q.CmpEq("idsdi_acquisto", idsdi_acquisto);
            object o = Conn.DO_READ_VALUE("sdi_acquisto", cond, "xml");
            if (o == null || o == DBNull.Value)
                return null;
            XmlDocument x = new XmlDocument();
            x.LoadXml(o.ToString());
            return x;
        }
        public static XmlDocument getOrdineVendita(int idsdi_acquisto, DataAccess Conn) {

            QueryHelper Q = Conn.GetQueryHelper();
            string cond = Q.CmpEq("idnso_vendita", idsdi_acquisto);
            object o = Conn.DO_READ_VALUE("nso_vendita", cond, "xml");
            if (o == null || o == DBNull.Value)
                return null;
            XmlDocument x = new XmlDocument();
            x.LoadXml(o.ToString());
            return x;
        }

        public static XmlDocument getFatturaVendita(int idsdi_vendita, DataAccess Conn) {
            QueryHelper Q = Conn.GetQueryHelper();
            string cond = Q.CmpEq("idsdi_vendita", idsdi_vendita);
            object o = Conn.DO_READ_VALUE("sdi_vendita", cond, "xml");
            if (o == null || o == DBNull.Value)
                return null;
            XmlDocument x = new XmlDocument();
            x.LoadXml(o.ToString());
            return x;
        }
        public static XmlDocument getFatturaAcquistoEstere(int idsdi_acquistoestere, DataAccess Conn) {
            QueryHelper Q = Conn.GetQueryHelper();
            string cond = Q.CmpEq("idsdi_acquistoestere", idsdi_acquistoestere);
            object o = Conn.DO_READ_VALUE("sdi_acquistoestere", cond, "xml");
            if (o == null || o == DBNull.Value)
                return null;
            XmlDocument x = new XmlDocument();
            x.LoadXml(o.ToString());
            return x;
        }
    }

    public class ArchiveData : PreserveData {

        public byte[] document;
        public string kind;
        public XmlDocument x;
        public string fNameOrig;
        public string identificativo_sdi;
        public int id_sdi;
        public string ipa;

        public override byte[] Contents => document;
        public byte[] Bytes => document;
        public override string ID => identificativo_sdi;
        public string IDSdi => identificativo_sdi;
        public override string IDOffice {
            get {
                switch (Type) {
                    case TDocument.fattAcq:
                    case TDocument.fattVen:
                    case TDocument.messAcq:
                    case TDocument.registroProtocollo:
                        return !string.IsNullOrWhiteSpace(ipa) ? ipa : null;
                    default:
                        return null;
                }
            }
        }
        public override string Filename => fNameOrig;
        public string IDSdiFileName => fNameOrig;
        //public override TDocument Type => Enum.TryParse(kind, out TDocument documentType) ? documentType : throw new Exception("Invalid document type specified");

        public override TDocument Type {
            get {
                if (string.IsNullOrWhiteSpace(kind))
                    throw new InvalidOperationException("Document type not set.");

                if (Enum.TryParse<TDocument>(kind, ignoreCase: true, out var documentType))
                    return documentType;

                throw new InvalidOperationException("Invalid document type specified.");
            }
            set {
                // Optional: validate value is defined in the enum
                if (!Enum.IsDefined(typeof(TDocument), value))
                    throw new ArgumentException("Value is not a valid enum member.", nameof(value));

                kind = value.ToString();
            }
        }

        public override XmlDocument Xml => x;
    }

    public class DeferredArchiver {
        public List<ArchiveData> toArchive = new List<ArchiveData>();
        public void ordVen(byte[] document, XmlDocument x, string fNameOrig, string identificativo_sdi, int id_sdi, string ipa = null) {
            if (ipa != null && !PreserveArchive.conservazioneEnabled(ipa)) return;
            ArchiveData a = new ArchiveData();
            a.document = document;
            a.x = x;
            a.fNameOrig = fNameOrig;
            a.identificativo_sdi = identificativo_sdi;
            a.id_sdi = id_sdi;
            a.kind = "ordAcq";
            a.ipa = ipa;
            toArchive.Add(a);
        }
        public void fattAcq(byte[] document, XmlDocument x, string fNameOrig, string identificativo_sdi, int id_sdi,string ipa=null) {
            if (ipa != null && !PreserveArchive.conservazioneEnabled(ipa)) return;
            ArchiveData a = new ArchiveData();
            a.document = document;
            a.x = x;
            a.fNameOrig = fNameOrig;
            a.identificativo_sdi = identificativo_sdi;
            a.id_sdi = id_sdi;
            a.kind = "fattAcq";
            a.ipa = ipa;
            toArchive.Add(a);
        }
        public void fattVen(byte[] document, XmlDocument x, string fNameOrig, string identificativo_sdi, int id_sdi,string ipa=null) {
            if (ipa != null && !PreserveArchive.conservazioneEnabled(ipa)) return;
            ArchiveData a = new ArchiveData();
            a.document = document;
            a.x = x;
            a.fNameOrig = fNameOrig;
            a.identificativo_sdi = identificativo_sdi;
            a.id_sdi = id_sdi;
            a.kind = "fattVen";
            a.ipa = ipa;
            toArchive.Add(a);
        }
        public void fattAcquEstere(byte[] document, XmlDocument x, string fNameOrig, string identificativo_sdi, int id_sdi, string ipa = null) {
            if (ipa != null && !PreserveArchive.conservazioneEnabled(ipa)) return;
            ArchiveData a = new ArchiveData();
            a.document = document;
            a.x = x;
            a.fNameOrig = fNameOrig;
            a.identificativo_sdi = identificativo_sdi;
            a.id_sdi = id_sdi;
            a.kind = "fattAcquEstere";
            a.ipa = ipa;
            toArchive.Add(a);
        }
        public void messOrdVen(XmlDocument x, string fNameOrig, int id_sdi,string ipa=null) {
            if (ipa != null && !PreserveArchive.conservazioneEnabled(ipa)) return;
            ArchiveData a = new ArchiveData();
            a.document = Encoding.UTF8.GetBytes(x.OuterXml);
            a.x = x;
            a.fNameOrig = fNameOrig;
            a.id_sdi = id_sdi;
            a.kind = "messAcq";
            a.ipa = ipa;
            toArchive.Add(a);
        }
        public void messAcq(XmlDocument x, string fNameOrig, int id_sdi, string ipa = null) {
            if (ipa != null && !PreserveArchive.conservazioneEnabled(ipa)) return;
            ArchiveData a = new ArchiveData();
            a.document = Encoding.UTF8.GetBytes(x.OuterXml);
            a.x = x;
            a.fNameOrig = fNameOrig;
            a.id_sdi = id_sdi;
            a.kind = "messAcq";
            a.ipa = ipa;
            toArchive.Add(a);
        }
        public void messVen(XmlDocument x, string fNameOrig, int id_sdi,string ipa=null) {
            if (ipa != null && !PreserveArchive.conservazioneEnabled(ipa)) return;
            ArchiveData a = new ArchiveData();
            a.document = Encoding.UTF8.GetBytes(x.OuterXml);
            a.x = x;
            a.fNameOrig = fNameOrig;
            a.id_sdi = id_sdi;
            a.kind = "messVen";
            a.ipa = ipa;
            toArchive.Add(a);
        }

        public void messAcquEstere(XmlDocument x, string fNameOrig, int id_sdi, string ipa = null) {
            if (ipa != null && !PreserveArchive.conservazioneEnabled(ipa)) return;
            ArchiveData a = new ArchiveData();
            a.document = Encoding.UTF8.GetBytes(x.OuterXml);
            a.x = x;
            a.fNameOrig = fNameOrig;
            a.id_sdi = id_sdi;
            a.kind = "messAcquEstere";
            a.ipa = ipa;
            toArchive.Add(a);
        }
        public void ArchiveAll(DataAccess conn) {
            foreach (ArchiveData a in toArchive) {
                if (a.kind == "ordVen") {
                    PreserveArchive.conservaOrdineVendita(a.document, a.x, a.fNameOrig, a.identificativo_sdi, a.id_sdi, conn);
                }
                if (a.kind == "fattAcq") {
                    PreserveArchive.conservaFatturaAcquisto(a.document, a.x, a.fNameOrig, a.identificativo_sdi, a.id_sdi, conn);
                }
                if (a.kind == "fattVen") {
                    PreserveArchive.conservaFatturaVendita(a.document, a.x, a.fNameOrig, a.identificativo_sdi, a.id_sdi, conn);
                }
                if (a.kind == "fattAcquEstere") {
                    PreserveArchive.conservaFatturaAcquistoEstere(a.document, a.x, a.fNameOrig, a.identificativo_sdi, a.id_sdi, conn);
                }
                if (a.kind == "messOrdVen") {
                    PreserveArchive.conservaMessaggioOrdineVendita(a.x, a.fNameOrig, a.id_sdi, conn);
                }
                if (a.kind == "messAcq") {
                    PreserveArchive.conservaMessaggioFatturaAcquisto(a.x, a.fNameOrig, a.id_sdi, conn);
                }
                if (a.kind == "messVen") {
                    PreserveArchive.conservaMessaggioFatturaVendita(a.x, a.fNameOrig, a.id_sdi, conn);
                }
                if (a.kind == "messAcquEstere") {
                    PreserveArchive.conservaMessaggioFatturaAcquistoEstere(a.x, a.fNameOrig, a.id_sdi, conn);
                }
            }
        }

		public void ArchiveAll_multi(DataAccess conn, ISoggetto amministrazione /*string codIpa*/) {
            foreach (ArchiveData a in toArchive) {
                if (a.ipa != amministrazione.IPAAmm /*codIpa*/) continue;
                if (a.kind == "ordVen") {
                    PreserveArchive.conservaOrdineVendita(a.document, a.x, a.fNameOrig, a.identificativo_sdi, a.id_sdi, conn, amministrazione.IPAAmm /*codIpa*/);
                }
                if (a.kind == "fattAcq") {
                    PreserveArchive.conservaFatturaAcquisto(a.document, a.x, a.fNameOrig, a.identificativo_sdi, a.id_sdi, conn, amministrazione /*codIpa*/);
                }
                if (a.kind == "fattVen") {
                    PreserveArchive.conservaFatturaVendita(a.document, a.x, a.fNameOrig, a.identificativo_sdi, a.id_sdi, conn, amministrazione.IPAAmm /*codIpa*/);
                }
                if (a.kind == "fattAcquEstere") {
                    PreserveArchive.conservaFatturaAcquistoEstere(a.document, a.x, a.fNameOrig, a.identificativo_sdi, a.id_sdi, conn);
                }
                if (a.kind == "messOrdVen") {
                    PreserveArchive.conservaMessaggioOrdineVendita(a.x, a.fNameOrig, a.id_sdi, conn, amministrazione.IPAAmm /*codIpa*/);
                }
                if (a.kind == "messAcq") {
                    PreserveArchive.conservaMessaggioFatturaAcquisto(a.x, a.fNameOrig, a.id_sdi, conn, amministrazione.IPAAmm /*codIpa*/);
                }
                if (a.kind == "messVen") {
                    PreserveArchive.conservaMessaggioFatturaVendita(a.x, a.fNameOrig, a.id_sdi, conn, amministrazione.IPAAmm /*codIpa*/);
                }
                if (a.kind == "messAcquEstere") {
                    PreserveArchive.conservaMessaggioFatturaAcquistoEstere(a.x, a.fNameOrig, a.id_sdi, conn);
                }
            }
        }
	}


    public class PreserveArchive {

        List<PreserveFile> files = new List<PreserveFile>();

        public SdiLog logger = new sdiLog.SdiLog("PreserveArchive");
        static PreserveArchive currArchive;
		public static void sendArchive(string nomeSupporto) {
            if (currArchive == null)
                return;
            if (nomeSupporto.ToLowerInvariant().EndsWith(".zip")) {
                //rimuove il .zip dal nome supporto
                nomeSupporto = nomeSupporto.Substring(0, nomeSupporto.Length - 4);
            }

            currArchive.preparaConservazione(nomeSupporto);

        }

        /// <summary>
        /// Copia il supporto indicato in una cartella che poi sarà usata per l'invio in conservazione
        /// </summary>
        /// <param name="nomeSupporto"></param>
        /// <param name="codIpa"></param>
		public static void sendArchive_multi(string nomeSupporto, string codIpa) {
            if (currArchive == null) return;
            if (nomeSupporto.ToLowerInvariant().EndsWith(".zip")) {
                //rimuove il .zip dal nome supporto
                nomeSupporto = nomeSupporto.Substring(0, nomeSupporto.Length - 4);
            }

            currArchive.preparaConservazione_multi(nomeSupporto, codIpa);

        }

        public static PreserveArchive getArchive(bool clear, SdiLog logger) {
            if (clear) {
                currArchive = null;
            }
            if (currArchive != null) {
                currArchive.logger = logger;
                return currArchive;
            }

            var sc = SdiConfigManager.getServiceConfig(sdiPassword.getPassword());
            if (sc == null)
                return null;

            var c = sc.cfg.Rows[0];

            if (c.Table.Columns.Contains("cons_archivio") && c["cons_archivio"].ToString() != "") {
                currArchive = new PreserveArchive { logger = logger };
            }

            return currArchive;
        }

        public static string namespaceEsterno(string codIpa = null) {
			if (codIpa != null) { return namespaceMultiEsterno(codIpa);  }
			serviceconfig sc = SdiConfigManager.getServiceConfig(sdiPassword.getPassword());
            if (sc == null) return "conservazione.docExt";
            if (!sc.cfg.Columns.Contains("cons_namespaceEsterno")) return "conservazione.docExt";
            DataRow c = sc.cfg.Rows[0];
            return c["cons_namespaceEsterno"].ToString();
        }
		private static string namespaceMultiEsterno(string codIpa) {
			serviceconfig sc = SdiConfigManager.getMultiServiceConfig(codIpa, sdiPassword.getPassword());
			if (sc == null) return "conservazione.docExt";
			if (!sc.Tables["cfg"].Columns.Contains("cons_namespaceEsterno")) return "conservazione.docExt";
			DataRow c = sc.Tables["cfg"].Rows[0];
			return c["cons_namespaceEsterno"].ToString();
		}

		public static string namespaceInterno(string codIpa = null) {
			if (codIpa != null) { return namespaceMultiInterno(codIpa); }
			serviceconfig sc = SdiConfigManager.getServiceConfig(sdiPassword.getPassword());
			if (sc == null) return "conservazione.doc";
            if (!sc.cfg.Columns.Contains("cons_namespaceInterno")) return "conservazione.doc";
            DataRow c = sc.cfg.Rows[0];
            return c["cons_namespaceInterno"].ToString();
        }
		private static string namespaceMultiInterno(string codIpa) {
			serviceconfig sc = SdiConfigManager.getMultiServiceConfig(codIpa, sdiPassword.getPassword());
			if (sc == null) return "conservazione.doc";
			if (!sc.Tables["cfg"].Columns.Contains("cons_namespaceInterno")) return "conservazione.doc";
			DataRow c = sc.Tables["cfg"].Rows[0];
			return c["cons_namespaceInterno"].ToString();
		}

		public static void conservaFatturaAcquisto(byte[] document, XmlDocument x, string filenameOriginale, 
                string identificativo_sdi, int id_sdiacquisto, DataAccess ConnEnte, ISoggetto amministrazione = null /*, string codIpa = null*/) {
            if (currArchive == null) return;

            //PreserveFile pf = new PreserveFile(namespaceEsterno(codIpa), namespaceInterno(codIpa));
            PreserveFile pf = new PreserveFile(namespaceEsterno(amministrazione.IPAAmm), namespaceInterno(amministrazione.IPAAmm));

            pf.identificativo_sdi = identificativo_sdi;
            pf.id_sdi = id_sdiacquisto;
            pf.getDataFromFatturaAcquisto(document, x, filenameOriginale,ConnEnte, amministrazione /*codIpa*/);
            pf.codIpa = amministrazione.IPAAmm; //codIpa;
            currArchive.files.Add(pf);

        }
        public static void conservaFatturaVendita(byte[] document, XmlDocument x, string filenameOriginale, 
                string identificativo_sdi, int id_sdivendita,DataAccess conn, string codIpa = null) {
            if (currArchive == null) return;
            PreserveFile pf = new PreserveFile(namespaceEsterno(codIpa), namespaceInterno(codIpa));
            pf.identificativo_sdi = identificativo_sdi;
            pf.id_sdi = id_sdivendita;
            pf.getDataFromFatturaVendita(document, x, filenameOriginale,conn,codIpa);
            pf.codIpa = codIpa;
            currArchive.files.Add(pf);
        }
        
         public static void conservaFatturaAcquistoEstere(byte[] document, XmlDocument x, string filenameOriginale,
               string identificativo_sdi, int idsdi_acquistoestere, DataAccess conn, string codIpa = null) {
            if (currArchive == null) return;
            PreserveFile pf = new PreserveFile(namespaceEsterno(codIpa), namespaceInterno(codIpa));
            pf.identificativo_sdi = identificativo_sdi;
            pf.id_sdi = idsdi_acquistoestere;
            pf.getDataFromFatturaAcquistoEstere(document, x, filenameOriginale, conn, codIpa);
            pf.codIpa = codIpa;
            currArchive.files.Add(pf);
        }
        public static void conservaOrdineVendita(byte[] document, XmlDocument x, string filenameOriginale,
                string identificativo_sdi, int id_nsovendita, DataAccess conn, string codIpa = null) {
            if (currArchive == null) return;
            PreserveFile pf = new PreserveFile(namespaceEsterno(codIpa), namespaceInterno(codIpa));
            pf.identificativo_sdi = identificativo_sdi;
            pf.id_sdi = id_nsovendita;

            pf.getDataFromOrdineVendita(document, x, filenameOriginale, conn, codIpa);
            pf.codIpa = codIpa;
            currArchive.files.Add(pf);
        }

        /// <summary>
        /// Conserva la fattura di acquisto, richiede che ci sia un archivio corrente impostato
        /// </summary>
        /// <param name="x"></param>
        /// <param name="filenameOriginale"></param>
        /// <param name="idsdi_acquisto"></param>
        /// <param name="conn">CONNESSIONE ALL'ENTE</param>
        /// <param name="codIpa"></param>
        public static void conservaMessaggioFatturaAcquisto(XmlDocument x, string filenameOriginale, int idsdi_acquisto
                , DataAccess conn, string codIpa = null) {
            if (currArchive == null) return;
            PreserveFile pf = new PreserveFile(namespaceEsterno(codIpa), namespaceInterno(codIpa));
            pf.id_sdi = idsdi_acquisto;
            pf.codIpa = codIpa;
            if (!pf.getDataFromMessaggioFatturaAcquisto(x, filenameOriginale,conn, codIpa)) return;
            currArchive.files.Add(pf);
        }

        public static void conservaMessaggioFatturaVendita(XmlDocument x, string filenameOriginale, int idsdi_vendita, DataAccess conn, string codIpa = null) {
            if (currArchive == null)
                return;
            PreserveFile pf = new PreserveFile(namespaceEsterno(codIpa), namespaceInterno(codIpa));
            pf.id_sdi = idsdi_vendita;
            pf.codIpa = codIpa;
            if (!pf.getDataFromMessaggioFatturaVendita(x, filenameOriginale,conn,codIpa)) return;
            currArchive.files.Add(pf);
        }
        
        public static void conservaMessaggioFatturaAcquistoEstere(XmlDocument x, string filenameOriginale, int idsdi_acquistoestere, DataAccess conn, string codIpa = null) {
            if (currArchive == null)
                return;
            PreserveFile pf = new PreserveFile(namespaceEsterno(codIpa), namespaceInterno(codIpa));
            pf.id_sdi = idsdi_acquistoestere;
            pf.codIpa = codIpa;
            if (!pf.getDataFromMessaggioFatturaAcquistoEstere(x, filenameOriginale, conn, codIpa)) return;
            currArchive.files.Add(pf);
        }
        public static void conservaMessaggioOrdineVendita(XmlDocument x, string filenameOriginale, int idnso_vendita, DataAccess conn, string codIpa = null) {
            if (currArchive == null)
                return;
            PreserveFile pf = new PreserveFile(namespaceEsterno(codIpa), namespaceInterno(codIpa));
            pf.id_sdi = idnso_vendita;
            pf.codIpa = codIpa;
            if (!pf.getDataFromMessaggioOrdineVendita(x, filenameOriginale, conn, codIpa)) return;
            currArchive.files.Add(pf);
        }

        public byte[] getXml(string nomeSupporto, string docClass,string codiceIpa=null) {
            var settings = new XmlWriterSettings() {
                Encoding = Encoding.UTF8,
                CloseOutput = true,
                Indent = true
            };

            byte[] result = null;
            using (var stream = new MemoryStream()) {
                var writer = XmlWriter.Create(stream, settings);
                writer.WriteStartDocument();

                var root = new XElement("PDV");

                var Xpdvid = new XElement("pdvid", codiceIpa+"-"+nomeSupporto);
                root.Add(Xpdvid);

                // <docClass namespace="conservazione.docExt">803__Fattura_PA</docClass>
                var XdocClass = new XElement("docClass", docClass);
                XdocClass.SetAttributeValue("namespace", namespaceEsterno());
                root.Add(XdocClass);

                var Xfiles = new XElement("files");
                foreach (PreserveFile file in files) {
                    if (codiceIpa!=null && file.codIpa!=codiceIpa)continue;
                    Xfiles.Add(file.getXml(codiceIpa));
                }
                root.Add(Xfiles);

                root.WriteTo(writer);
                writer.Flush();

                result = stream.ToArray();
            }

            return result;
        }

        static string localAppDataPath {
            get {
                return Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                    "Tempo Srl", "sdiftp");
            }
        }

		static string localAppDataPath_multi
		{
			get
			{
				return Path.Combine(
					Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
					"Tempo Srl", "sdiftp_multi");
			}
		}

		public bool preparaConservazione(string nomeSupporto) {
            if (files.Count == 0)
                return false;

            serviceconfig s = SdiConfigManager.getServiceConfig();
            DataRow r = s.Tables["cfg"].Rows[0];

            if (r["cons_classedocumentale"].ToString() == "") {
                logger.addWarn("Classe documentale non presente");
                return false;
            }

            var docClass = r["cons_classedocumentale"].ToString();

            //Il nome cartella inizia con l'identificativo dell'archivio di destinazione del file. 
            if (r["cons_archivio"].ToString() == "") {
                logger.addWarn("Nome archivio per conservazione non presente");
                return false;
            }

            //I documenti da inviare in conservazione devono essere allegati alla PEC con le seguenti convenzioni:
            //   tutti i documenti devono essere contenuti all'interno di un unico file compresso

            //  il nome del file compresso mandato in allegato indica al sistema il nome che il versante intende dare al PdA risultante
            // il file compresso lo assumo pari a nomeSupporto

            string cartella = string.Format("{0}-IPDV-{1}", r["cons_archivio"].ToString(), nomeSupporto);
            string localPath = localAppDataPath;
            if (s.cfg.Columns.Contains("cons_localpath")) localPath = r["cons_localpath"].ToString();
            if (!Directory.Exists(localPath)) Directory.CreateDirectory(localPath);
            string basePath = Path.Combine(localPath, cartella);
            if (File.Exists(basePath)) File.Delete(basePath);
            if (!Directory.Exists(basePath)) Directory.CreateDirectory(basePath);

            var FileExists = new Dictionary<string, bool>();
            foreach (PreserveFile file in files) {
                if (FileExists.ContainsKey(file.fileName)) continue;
                FileExists[file.fileName] = true;

                string nomeFile = Path.Combine(basePath, file.fileName);
                FileStream S = new FileStream(nomeFile, FileMode.Create);
                S.Write(file.content, 0, file.content.Length);
                S.Flush();
                S.Close();
            }

            string nomeFilePDV = string.Format("IPDV-{0}.xml", nomeSupporto);
            string pdvLocale = Path.Combine(basePath, nomeFilePDV);
            FileStream SPdv = new FileStream(pdvLocale, FileMode.Create);
            byte[] byteIPDV = getXml(nomeSupporto, docClass);
            SPdv.Write(byteIPDV, 0, byteIPDV.Length);
            SPdv.Flush();
            SPdv.Close();

            return true;
        }

        /// <summary>
        /// ARCHIVIA dal supporto solo le fatture / messaggi relativi al codIpa
        ///  (è anche da capire come gestire i doppi invii messaggio DT su emissione fatture tra enti gestiti)
        /// I file  sono messi nella sotto cartella di cons_localpath in una cartella che si chiama con codIpa-[cons_archivio]-nomeSupporto
        /// </summary>
        /// <param name="nomeSupporto"></param>
        /// <param name="codIpa"></param>
        /// <returns></returns>
		public bool preparaConservazione_multi(string nomeSupporto, string codIpa) {
            if (files.Count == 0) return false;

            serviceconfig s = SdiConfigManager.getMultiServiceConfig(codIpa);
            DataRow r = s.Tables["cfg"].Rows[0];

            //Il nome cartella inizia con l'identificativo dell'archivio di destinazione del file. 
            if (r["cons_archivio"].ToString() == "") {
                //logger.addWarn("Nome archivio per conservazione non presente");
                return false;
            }


            if (r["cons_classedocumentale"].ToString() == "") {
                logger.addWarn("Classe documentale non presente");
                return false;
            }

            var docClass = r["cons_classedocumentale"].ToString();


            //I documenti da inviare in conservazione devono essere allegati alla PEC con le seguenti convenzioni:
            //   tutti i documenti devono essere contenuti all'interno di un unico file compresso

            //  il nome del file compresso mandato in allegato indica al sistema il nome che il versante intende dare al PdA risultante
            // il file compresso lo assumo pari a nomeSupporto

            string cartella = string.Format("{0}-{1}-IPDV-{2}", codIpa, r["cons_archivio"].ToString(), nomeSupporto);
            string localPath = localAppDataPath_multi;
            if (s.cfg.Columns.Contains("cons_localpath")) localPath = r["cons_localpath"].ToString();

            if (!Directory.Exists(localPath)) Directory.CreateDirectory(localPath);

            string basePath = Path.Combine(localPath, cartella);
            if (File.Exists(basePath)) File.Delete(basePath);


            int countReal = 0;
            var FileExists = new Dictionary<string, bool>();
            foreach (PreserveFile file in files) {
                if (file.codIpa != codIpa) continue;

                if (FileExists.ContainsKey(file.fileName)) continue;
                FileExists[file.fileName] = true;
                if (countReal == 0) {//solo ora fa questo controllo
                    if (!Directory.Exists(basePath)) Directory.CreateDirectory(basePath);
                }

                string nomeFile = Path.Combine(basePath, file.fileName);
                FileStream S = new FileStream(nomeFile, FileMode.Create);
                S.Write(file.content, 0, file.content.Length);
                S.Flush();
                S.Close();
                countReal++;
            }
            if (countReal == 0) return false;

            //string nomeFilePDV = string.Format("IPDV-{0}.xml", nomeSupporto);
            string nomeFilePDV = string.Format("IPDV-{0}-{1}.xml", codIpa, nomeSupporto);
            string pdvLocale = Path.Combine(basePath, nomeFilePDV);
            FileStream SPdv = new FileStream(pdvLocale, FileMode.Create);

            byte[] byteIPDV = getXml(nomeSupporto, docClass, codIpa);
            SPdv.Write(byteIPDV, 0, byteIPDV.Length);
            SPdv.Flush();
            SPdv.Close();

            return true;
		}

		public static bool inviaConservazione(SdiLog logger) {
			//string localPath = localAppDataPath;

   //         serviceconfig s = SdiConfigManager.getServiceConfig();
   //         DataRow r = s.Tables["cfg"].Rows[0];
   //         if (s.cfg.Columns.Contains("cons_localpath")) localPath = r["cons_localpath"].ToString();
   //         if (localPath == "") return true;

   //         IEnumerable<string> cartelle = Directory.EnumerateDirectories(localPath);
   //         if (!cartelle.Any()) return true; //non fa nulla se non ci sono cartelle (inutile connettersi all'ftp etc.)

   //         FtpCfgBase cfg = FtpFun.getCfgConservazione();
   //         ftpHelper fh = new ftpHelper(cfg,logger);
   //         bool res = fh.login();
   //         if (!res) {
   //             logger.addErrorList(fh.errors);
   //             return false;
   //         }

   //         // Carica tutto quello che trova nella cartella dati

   //         foreach (string cartella in cartelle) {
   //             if (fh.UploadFolder(cartella, cfg.remote_dir)) {
   //                 Directory.Delete(cartella, true);
   //             }
   //         }

   //         fh.logout();

            return true;
        }

        public static bool conservazioneEnabled(string codIpa) {
            serviceconfig s = SdiConfigManager.getMultiServiceConfig(codIpa);
            if (s == null) return false;
            if (!s.Tables["cfg"].Columns.Contains("cons_archivio")) return false;
            DataRow r = s.Tables["cfg"].Rows[0];
            return r["cons_archivio"].ToString() != "";
        }
        /// <summary>
        /// Invia i file dalla cartella cons_localpath configurata per l'ipa indicato a quella remota e poi cancella i file locali
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="codIpa"></param>
        /// <returns></returns>
		public static bool inviaConservazione_multi(SdiLog logger, string codIpa = null) {

            //serviceconfig s = SdiConfigManager.getMultiServiceConfig(codIpa);
            //if (!s.Tables["cfg"].Columns.Contains("cons_archivio")) return false;

            //DataRow r = s.Tables["cfg"].Rows[0];

            //if (r["cons_archivio"].ToString() == "") return false;

            ///*             
            //    string cartella = string.Format("{0}-{1}-IPDV-{2}", codIpa, r["cons_archivio"].ToString(), nomeSupporto);
            //    string localPath = localAppDataPath_multi;
            //    if (s.cfg.Columns.Contains("cons_localpath")) localPath = r["cons_localpath"].ToString();
            //    if (!Directory.Exists(localPath)) Directory.CreateDirectory(localPath);
            //*/

            //string localPath = localAppDataPath_multi;
            //if (s.cfg.Columns.Contains("cons_localpath")) localPath = r["cons_localpath"].ToString();
            //if (localPath == "") return true;

            ////prende solo le cartelle indirizzate a quell'ipa
            //IEnumerable<string> cartelle = Directory.EnumerateDirectories(localPath, codIpa + "-*"); //non invia tutto a uno anche se la cartella dovesse essere unica
            //if (!cartelle.Any()) return true; //non fa nulla se non ci sono cartelle (inutile connettersi all'ftp etc.)

            //FtpCfgBase cfg = FtpFun.getCfgConservazione_multi(codIpa);
            //ftpHelper fh = new ftpHelper(cfg, logger);
            //bool res = fh.login();
            //if (!res) {
            //    logger.addErrorList(fh.errors);
            //    return false;
            //}

            //// Carica tutto quello che trova nella cartella dati

            //foreach (string cartella in cartelle) {
            //    //fh.createFolder("", cfg.remote_dir);
            //    if (fh.UploadFolder(cartella, cfg.remote_dir)) {
            //        Directory.Delete(cartella, true);
            //    }
            //}

            //fh.logout();

            return true;
		}

		/*
        public bool inviaMailConservazione(string nomeSupporto) {
            if (files.Count == 0)
                return false;
            this.nomeSupporto = nomeSupporto;
            serviceconfig s = SdiConfigManager.getServiceConfig();
            DataRow r= s.Tables["cfg"].Rows[0];
            string nomeArchivio = Path.ChangeExtension(r["cons_archivio"].ToString() + "-" + nomePDV(),"zip");
            //Il subject della mail deve contenere l'identificativo dell'archivio di destinazione del file. 
            if (nomeArchivio == "") {
                logger.addWarn("Nome archivio per conservazione non presente");
                return false;
            }

            //I documenti da inviare in conservazione devono essere allegati alla PEC con le seguenti convenzioni:
            //   tutti i documenti devono essere contenuti all'interno di un unico file compresso
            
            //  il nome del file compresso mandato in allegato indica al sistema il nome che il versante intende dare al PdA risultante
            // il file compresso lo assumo pari a nomeSupporto
            string tempDirName = Path.GetTempFileName();
            File.Delete(tempDirName);
            Directory.CreateDirectory(tempDirName);
            string tempFileName = Path.Combine(tempDirName, nomeArchivio );
            //MemoryFile f = new Xceed.FileSystem.MemoryFile("RAM_File", nomeArchivio + ".zip");
            DiskFile f = new DiskFile(tempFileName);
            ZipArchive zip = new ZipArchive(f);
            
            AbstractFile fIndex = zip.CreateFile(nomePDV()+".xml", true);
            Stream pdvStream = fIndex.OpenWrite(true);
            byte[] byteIPDV = Encoding.UTF8.GetBytes(getXml());
            pdvStream.Write(byteIPDV, 0, byteIPDV.Length);
            pdvStream.Close();
            Dictionary<string, bool> FileExists = new Dictionary<string, bool>();
            foreach (PreserveFile ff in files) {
                if (FileExists.ContainsKey(ff.fileName))
                    continue;
                FileExists[ff.fileName] = true;
                AbstractFile fc = zip.CreateFile(ff.fileName, false);
                //XmlDocument xmlSigned = CryptoFun.XadesSign(fSdi.xml, signCert);
                Stream S = fc.OpenWrite(true);
                S.Write(ff.content, 0, ff.content.Length);
                S.Close();
            }

            SendMailConservazione sm = new SendMailConservazione();
            sm.From  = r["cons_email_from"].ToString();
            sm.To = r["cons_email_dest"].ToString();
            sm.MessageBody = "Mail di conservazione per il supporto " + nomeSupporto + ".\r\\n";
            sm.Subject = nomeArchivio;
            //sm.listaAllegati.Add(new Attachment(f.OpenRead(),nomeArchivio+".zip",)); 
            MimeAttachment m = new MimeAttachment(tempFileName, new System.Net.Mime.ContentType("application/zip"), AttachmentLocation.Attachmed);
            sm.listaAllegati.Add(m);
            bool res= sm.Send();
            //File.Delete(tempFileName);
            //Directory.Delete(tempDirName);
            return res;
        }
        */
	}

    public class SendMailConservazione {
        public string From;
        public string To;
        public string Cc;
        public string Bcc;
        public string Subject;
        public string MessageBody;
        public bool UseSMTPLoginAsFromField = false;
        public string ErrorMessage;
        public List<MimeAttachment> listaAllegati = new List<MimeAttachment>();

        private string SMTPAddress;
        private string SMTPLogin;
        private string SMTPPassword;
        private int SMTPPort;
        public bool NoConfig = false;

        public static string ServiceName = "SdiService";
        public static BaseSysLogger sysLogger = new BaseSysLogger(ServiceName); 

        public bool Send() {
            if (!GetSMTPConnData()) {
                //ErrorMessage = "Nessuna connessione SMTP presente nel Database.";
                ErrorMessage = "";
                return false;
            }

            string EffectiveFrom;
            if (!UseSMTPLoginAsFromField)
                EffectiveFrom = From;
            else
                EffectiveFrom = SMTPLogin;

            if (To == null || To == "") {
                ErrorMessage = "Nessun destinatario specificato.";
                return false;
            }
            MimeMailMessage message = null;
            try {
                message = new MimeMailMessage();
                message.From = new MailAddress(EffectiveFrom);
                string[] any = To.Replace(';', ',').Split(',');
                foreach (string dest in any) {
                    message.To.Add(new MailAddress(dest));
                }
                message.Subject = Subject;
                message.Body = MessageBody;
            }
            catch (Exception e) {
                ErrorMessage = "Errore nell'invio del messaggio " + " DA: " + EffectiveFrom + "\r\n" + "A: " + To.Replace(';', ',') +
                               "\r\n\r\n" + e.Message + "\r\n" + e.StackTrace;
                sysLogger.logError(ErrorMessage);
                sysLogger.logWarn("Testo del messaggio :\n\r" + MessageBody);
                return false;
            }
            if (!string.IsNullOrEmpty(Bcc)) {
                string[] anyBCC = To.Replace(';', ',').Split(',');
                foreach (string toBCC in anyBCC) {
                    message.Bcc.Add(new MailAddress(toBCC));
                }
                //message.Bcc.Add(Bcc.Replace(';', ','));
            }
            if (!string.IsNullOrEmpty(Cc)) {
                string[] anyCC = To.Replace(';', ',').Split(',');
                foreach (string toCC in anyCC) {
                    message.CC.Add(new MailAddress(toCC));
                }
                //message.Bcc.Add(Bcc.Replace(';', ','));
            }


            message.BodyEncoding = System.Text.Encoding.Default;


            foreach (MimeAttachment a in listaAllegati) {
                message.Attachments.Add(a);
            }


            MimeMailer mailer = new MimeMailer(SMTPAddress, SMTPPort);

            mailer.User = SMTPLogin;
            mailer.Password = SMTPPassword;
            mailer.SslType = SslMode.Ssl;
            mailer.AuthenticationMode = AuthenticationType.Base64;



            try {
                mailer.Send(message);
                return true;
            }
            catch (System.Net.Mail.SmtpFailedRecipientException F) {
                ErrorMessage = "Errore nell'invio del messaggio (SmtpFailedRecipientException) " + " DA: " + EffectiveFrom + "\r\n" + "A: " + To.Replace(';', ',') +
                               "\r\n\r\n" + F.Message + "\r\n" + F.StackTrace;
                sysLogger.logError(ErrorMessage);
                sysLogger.logWarn("Testo del messaggio :\n\r" + MessageBody);
                return false;
            }
            catch (System.Net.Mail.SmtpException E) {
                sysLogger.logException(E);
                ErrorMessage = "Impossibile Contattare il server SMTP.Invio messaggio fallito.";
                sysLogger.logError(ErrorMessage);
                return false;
            }
            catch (Exception e) {
                sysLogger.logException(e);
                ErrorMessage = e.Message + "\r\n" + e.StackTrace;
                return false;
            }
        }



        private bool GetSMTPConnData() {
            NoConfig = true;
            serviceconfig sc = SdiConfigManager.getServiceConfig(sdiPassword.getPassword());
            if (sc == null)
                return false;

            DataRow cfg = sc.cfg.Rows[0];
            SMTPAddress = cfg["cons_smtp_address"].ToString();
            SMTPLogin = cfg["cons_smtp_user"].ToString();
            SMTPPassword = cfg["cons_smtp_password"].ToString();
            SMTPPort = Convert.ToInt32(cfg["cons_smtp_port"]);
            NoConfig = false;
            return true;
        }
    }



}
