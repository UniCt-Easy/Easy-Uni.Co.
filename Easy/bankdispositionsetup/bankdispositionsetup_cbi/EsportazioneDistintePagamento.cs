
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
using System.Text;
using System.Data;
using funzioni_configurazione;
using metadatalibrary;
using metaeasylibrary;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Xsl;
using System.Collections;

namespace bankdispositionsetup_cbi {
	public class EsportazioneDistintePagamento {
        DataAccess Conn;
        bool isbonificoEstero;
        QueryHelper QHS;
        CQueryHelper QHC;

        public EsportazioneDistintePagamento(DataAccess Conn, bool bonificoEstero) {
            this.Conn = Conn;
            this.isbonificoEstero = bonificoEstero;
            QHS = Conn.GetQueryHelper();
            QHC = new CQueryHelper();
        }
        public XmlDocument GeneraFileXMLXXXXXXXXXXXX() {
           
            XmlDocument X = new XmlDocument();
            X.CreateXmlDeclaration("1.0", "UTF - 8", null);

            X.CreateElement("BODY:CBIBdyPaymentRequest");
            XmlAttribute attributeNode = X.CreateAttribute("xmlns", "PMRQ",null);
            attributeNode.Value = "urn:CBI:xsd:CBIPaymentRequest.00.04.01";
            X.DocumentElement.SetAttributeNode(attributeNode);

            attributeNode = X.CreateAttribute("xmlns", "SGNT", null);
            attributeNode.Value = "urn:CBI:xsd:CBISgnInf.001.04";
            X.DocumentElement.SetAttributeNode(attributeNode);

            attributeNode = X.CreateAttribute("xmlns", "BODY", null);
            attributeNode.Value = "urn:CBI:xsd:CBIBdyPaymentRequest.00.04.01";
            X.DocumentElement.SetAttributeNode(attributeNode);

            return X;

        }
        public string GetStringValue(object V) {
            if ((V == DBNull.Value) || V.ToString() == "") return null;
            if (V.ToString().Trim() == "") return null;
            return V.ToString();
        }
        private string sostituiscivirgolaconpunto(decimal importo) {
            string group = System.Globalization.NumberFormatInfo.CurrentInfo.NumberGroupSeparator;
            string dec = System.Globalization.NumberFormatInfo.CurrentInfo.NumberDecimalSeparator;
            string s1 = importo.ToString("g").Replace(group, "");
            return s1.Replace(dec, ".");
        }
        public CBICreditTransferTransactionInformation get_informazioni_beneficiario(DataRow R) {
            CBICreditTransferTransactionInformation _CdtTrfTxInf = new CBICreditTransferTransactionInformation();

            // 2.12.1    PmtId - Payment Identification - ID Transazione
            PaymentIdentification1 _PmtId = new PaymentIdentification1();
            _PmtId.InstrId= R["InstrId"].ToString().Replace("_", "-");
            _PmtId.EndToEndId = R["Credit_EndToEndId"].ToString();
            _CdtTrfTxInf.PmtId = _PmtId;
            if (!isbonificoEstero) {
                //2.12.2   	PmtTpInf - Payment Type Information	 - Informazioni sul tipo di transazione
                CBIPaymentTypeInformation2 _PmtTpInf = new CBIPaymentTypeInformation2();
                //2.12.2.3    CtgyPurp Category Purpose Causale bancaria CategoryPurpose1Choice
                CategoryPurpose1Choice _CtgyPurp = new CategoryPurpose1Choice();
                _CtgyPurp.Cd = R["Credit_Cd"].ToString();

                _PmtTpInf.CtgyPurp = _CtgyPurp;

                _CdtTrfTxInf.PmtTpInf = _PmtTpInf;
            }
            //2.12.3          Amt Amount  Importo CBIAmountType1
            CBIAmountType1 _Amt = new CBIAmountType1();
            //_Amt.InstdAmt = R["Creditor_InstdAmt"];
            //2.12.3.1    InstdAmt Instructed Amount Divisa e importo    ActiveOrHistoricCurrencyAndAmount
            ActiveOrHistoricCurrencyAndAmount _InstdAmt = new ActiveOrHistoricCurrencyAndAmount();
            _InstdAmt.Ccy = "EUR";
            _InstdAmt.Value = sostituiscivirgolaconpunto(CfgFn.GetNoNullDecimal(R["Creditor_InstdAmt"]));
            _Amt.InstdAmt = _InstdAmt;

            _CdtTrfTxInf.Amt = _Amt;
			if (isbonificoEstero) {
                //2.12.7    CdtrAgt	Creditor Agent	Banca titolare del c/c di accredito	CBIBranchAndFinancialInstitutionIdentification3
                CBIBranchAndFinancialInstitutionIdentification3 CdtrAgt = new CBIBranchAndFinancialInstitutionIdentification3();
                //2.12.7.1	FinInstnId	FinancialInstitutionIdentification	Identificativi Istituto finanziario	CBIFinancialInstitutionIdentification2
                CBIFinancialInstitutionIdentification2 FinInstnId = new CBIFinancialInstitutionIdentification2();
                //2.12.7.1.1  BICFI  BICFIDec2014Identifier

                FinInstnId.BICFI = R["Creditor_BICOrBEI"].ToString();
                CdtrAgt.FinInstnId = FinInstnId;
                _CdtTrfTxInf.CdtrAgt = CdtrAgt;
            }
            //2.12.8	Cdtr	Creditor 	Titolare c/c accredito / Beneficiario	CBIPartyIdentification3
            CBIPartyIdentification3 Cdtr = new CBIPartyIdentification3();
            Cdtr.Nm = R["Creditor_Nm"].ToString();
            //2.12.8.2	PstlAdr	Postal Address	Indirizzo Postale	CBIPostalAddress6
            CBIPostalAddress6 _PstlAdr = new CBIPostalAddress6();
            _PstlAdr.StrtNm = R["Creditor_StrtNm"].ToString();
            if (R["Creditor_PstCd"].ToString() != "") {
                _PstlAdr.PstCd = R["Creditor_PstCd"].ToString();
            }
            _PstlAdr.TwnNm = R["Creditor_TwnNm"].ToString();
            _PstlAdr.Ctry = R["Creditor_Ctry"].ToString();

            Cdtr.PstlAdr = _PstlAdr;
            if (!isbonificoEstero) {
                //2.12.8.3	Id	Identification	Identificativi	CBIParty1Choice
                CBIParty1Choice _Id = new CBIParty1Choice();

                // PERSONA GIURIDICA    ----------------------------------------
                //2.12.8.3.1	OrgId	OrganisationIdentification	Identificativo dell'organizzazione	CBIOrganisationIdentification2
                CBIOrganisationIdentification2 _OrgId = new CBIOrganisationIdentification2();
                if (R["Creditor_BICOrBEI"].ToString() != "") {
                    _OrgId.AnyBIC = R["Creditor_BICOrBEI"].ToString();
                }
                if (R["Creditor_BICOrBEI"].ToString() == "") {
                    // Dobbiamo valorizzare o il BIC o Creditor id e Creditor Issuer.
                    //2.12.8.3.1.2    Othr Other   Identificativo Proprietario CBIGenericIdentification1
                    GenericOrganisationIdentification1 _PF_Othr = new GenericOrganisationIdentification1();
                    _PF_Othr.Id = R["Creditor_OrganisationIdentification_Id"].ToString();
                    _PF_Othr.Issr = R["Creditor_OrganisationIdentification_Issuer"].ToString();

                    _OrgId.Othr = _PF_Othr;
                }
                // PERSONA FISICA   ---------------------------------------------
                //2.12.8.3.2  PrvtId Private Identification Identificativo soggetto privato CBIPersonIdentification1
                CBIPersonIdentification1 _PrvtId = new CBIPersonIdentification1();
                //2.12.8.3.2.1    Othr Other   Identificativo Proprietario CBIGenericIdentification1
                CBIGenericIdentification1 _PG_Othr = new CBIGenericIdentification1();
                _PG_Othr.Id = R["Creditor_PrivateIdentification_Id"].ToString();
                _PG_Othr.Issr = R["Creditor_PrivateIdentification_Issuer"].ToString();
                _PrvtId.Othr = _PG_Othr;

                if (R["Creditor_kind"].ToString() == "F") {
                    _Id.PrvtId = _PrvtId;
                }
                else {
                    _Id.OrgId = _OrgId;
                }
                Cdtr.Id = _Id;
            }
            _CdtTrfTxInf.Cdtr = Cdtr;

            //2.12.9	CdtrAcct	Creditor Account 	Conto del Creditore	CBICashAccount2
            CBICashAccount1 _CdtrAcct = new CBICashAccount1();
            //_CdtrAcct.Id
            //2.12.9.1    Id Identification  ID Conto    CBIAccountIdentification1
            CBIAccountIdentification1 IdCdtrAcct = new CBIAccountIdentification1();
            IdCdtrAcct.IBAN = R["Creditor_IBAN"].ToString();
            _CdtrAcct.Id = IdCdtrAcct;
            _CdtTrfTxInf.CdtrAcct = _CdtrAcct;
            if (!isbonificoEstero) {
                //2.12.10	UltmtCdtr	Ultimate Creditor	Creditore effettivo	CBIPartyIdentification3
                CBIPartyIdentification3 _UltimateCreditor = new CBIPartyIdentification3();
                if (R["UltimateCreditor_Nm"] != DBNull.Value) {
                    _UltimateCreditor.Nm = R["UltimateCreditor_Nm"].ToString();

                    CBIPostalAddress6 _UltmtPstlAdr = new CBIPostalAddress6();
                    _UltmtPstlAdr.StrtNm = R["UltimateCreditor_StrtNm"].ToString();
                    if (R["UltimateCreditor_PstCd"].ToString() != "") {
                        _UltmtPstlAdr.PstCd = R["UltimateCreditor_PstCd"].ToString();
                    }
                    _UltmtPstlAdr.TwnNm = R["UltimateCreditor_TwnNm"].ToString();
                    _UltmtPstlAdr.Ctry = R["UltimateCreditor_Ctry"].ToString();

                    _UltimateCreditor.PstlAdr = _UltmtPstlAdr;


                    //2.12.8.3.1	OrgId - OrganisationIdentification	- Identificativo dell'organizzazione

                    // PERSONA GIURIDICA    ----------------------------------------
                    //2.12.8.3.1	OrgId	OrganisationIdentification	Identificativo dell'organizzazione	CBIOrganisationIdentification2
                    CBIOrganisationIdentification2 _UltmtOrgId = new CBIOrganisationIdentification2();
                    _UltmtOrgId.AnyBIC = R["UltimateCreditor_BICOrBEI"].ToString();
                    if (R["UltimateCreditor_BICOrBEI"].ToString() == "") {
                        // Dobbiamo valorizzare o il BIC o PrivateIdentification_Id e Issuer.
                        //2.12.8.3.1.2    Othr Other   Identificativo Proprietario CBIGenericIdentification1
                        GenericOrganisationIdentification1 _UltmtPF_Othr = new GenericOrganisationIdentification1();
                        _UltmtPF_Othr.Id = R["Ultimate_PrivateIdentification_Id"].ToString();
                        _UltmtPF_Othr.Issr = R["Ultimate_PrivateIdentification_Issuer"].ToString();

                        _UltmtOrgId.Othr = _UltmtPF_Othr;
                    }
                    // PERSONA FISICA   ---------------------------------------------
                    CBIParty1Choice _UltmtId = new CBIParty1Choice();
                    //2.12.8.3.2  PrvtId Private Identification Identificativo soggetto privato CBIPersonIdentification1
                    CBIPersonIdentification1 _UltmtPrvtId = new CBIPersonIdentification1();
                    //2.12.8.3.2.1    Othr Other   Identificativo Proprietario CBIGenericIdentification1
                    CBIGenericIdentification1 _UltmtPG_Othr = new CBIGenericIdentification1();
                    _UltmtPG_Othr.Id = R["Ultimate_OrganisationIdentification_Id"].ToString();
                    _UltmtPG_Othr.Issr = R["Ultimate_OrganisationIdentification_Issuer"].ToString();
                    _UltmtPrvtId.Othr = _UltmtPG_Othr;

                    if (R["UltimateCreditor_kind"].ToString() == "F") {
                        _UltmtId.PrvtId = _UltmtPrvtId;
                    }
                    else {
                        _UltmtId.OrgId = _UltmtOrgId;
                    }
                    Cdtr.Id = _UltmtId;

                    _CdtTrfTxInf.UltmtCdtr = _UltimateCreditor;
                }
            }

            //2.12.15 RmtInf Remittance Information Informazioni di riconciliazione RemittanceInformation5
            RemittanceInformation5 _RmtInf = new RemittanceInformation5();
            _RmtInf.Ustrd = R["Unstructured"].ToString();
            _CdtTrfTxInf.RmtInf = _RmtInf;

            return _CdtTrfTxInf;
        }
        
        public XmlDocument Crea_flusso_ordinativi_pag(DataTable T)
        {
            string selettore = "(kind='GroupHeader')";
            DataRow[] Header = T.Select(selettore);
            if (Header.Length == 0)
            {
                MetaFactory.factory.getSingleton<IMessageShower>().Show("Riga flusso_ordinativi non trovata, filtro utilizzato = " + selettore, "Errore");
                return null;
            }
            // 1.0 Header
            DataRow rHeader = Header[0];

            // ====================================================================
            // BODY:CBIBdyPaymentRequest
            // ====================================================================
            CBIBdyPayment BdyPayment = new CBIBdyPayment();

            // ====================================================================
            // BODY:CBIEnvelPaymentRequest
            // ====================================================================
            CBIEnvelPayment EnvelPayment = new CBIEnvelPayment();

            // ====================================================================
            // BODY:CBIPaymentRequest
            // ====================================================================
            CBIPayment Payment = new CBIPayment();

            // ====================================================================
            // PMRQ:GrpHdr
            // ====================================================================
            CBIGroupHeader GroupHeader = new CBIGroupHeader();

            // ====================================================================
            // PMRQ:Id
            // ====================================================================
            CBIIdType1 idField = new CBIIdType1();

            // ====================================================================
            // PMRQ:OrgId
            // ====================================================================
            CBIOrganisationIdentification1 _OrgId = new CBIOrganisationIdentification1();

            // ====================================================================
            // PMRQ:OrgId
            // ====================================================================
            CBIGenericIdentification1 _Othr = new CBIGenericIdentification1();

            // ====================================================================
            // PMRQ:InitgPty
            // ====================================================================
            CBIPartyIdentification1 InitgPty = new CBIPartyIdentification1();


            _Othr.Id = rHeader["InitgPty_Id"].ToString();                                       // B.E.P.1.5.2.1.1.1    Body\Envelop\Payment > Header > InitgPty > Id > OrgId > Othr > Id
            _Othr.Issr = rHeader["InitiatingParty_Issuer"].ToString();                          // B.E.P.1.5.2.1.1.2    Body\Envelop\Payment > Header > InitgPty > Id > OrgId > Othr > Issr

            _OrgId.Othr = _Othr;                                                                // B.E.P.1.5.2.1.1      Body\Envelop\Payment > Header > InitgPty > Id > OrgId > Othr

            idField.OrgId = _OrgId;                                                             // B.E.P.1.5.2.1        Body\Envelop\Payment > Header > InitgPty > Id > OrgId

            InitgPty.Id = idField;                                                              // B.E.P.1.5.2          Body\Envelop\Payment > Header > InitgPty > Id
            InitgPty.Nm = rHeader["InitiatingParty_Nm"].ToString();                             // B.E.P.1.5.1          Body\Envelop\Payment > Header > InitgPty > Nm

            GroupHeader.InitgPty = InitgPty;                                                    // B.E.P.1.5            Body\Envelop\Payment > Header > InitgPty
            GroupHeader.CtrlSum = CfgFn.GetNoNullDecimal(rHeader["GroupHeader_CtrlSum"]);       // B.E.P.1.4            Body\Envelop\Payment > Header > CtrlSum
            GroupHeader.NbOfTxs = GetStringValue(rHeader["NbOfTxs"]);                           // B.E.P.1.3            Body\Envelop\Payment > Header > NbOfTxs
            GroupHeader.CreDtTm = (DateTime)rHeader["CreDtTm"];                                 // B.E.P.1.2            Body\Envelop\Payment > Header > CreDtTm
            GroupHeader.MsgId = GetStringValue(rHeader["MsgId"]).Replace("_", "-");             // B.E.P.1.1            Body\Envelop\Payment > Header > MsgId

            Payment.GrpHdr = GroupHeader;                                                       // B.E.P.1              Body\Envelop\Payment > Header


            // ==========================================================
            // Crea PaymentInformation
            // ==========================================================
            var rPagamenti = T.Select("(kind='PaymentInformation')");
            if (rPagamenti.Length == 0)
            {
                MetaFactory.factory.getSingleton<IMessageShower>().Show("Nessun mandato trovato.");
                return null;
            }
            Dictionary<string, CBIPaymentInstructionInformation> PaymentInformation = new Dictionary<string, CBIPaymentInstructionInformation>();

            foreach (var mandato in rPagamenti)
            {
                var m = Crea_PaymentInformation(mandato, T);
                if (m == null) return null;
                PaymentInformation[mandato["PmtMtd"].ToString()] = m;

                Payment.PmtInf = m;                                                             // B.E.P.2              Body\Envelop\Payment > PaymentInfo
            }

            // ==========================================================
            // Payment
            // ==========================================================
            EnvelPayment.CBIPaymentRequest = Payment;                                           // B.E.P                Body\Envelop\Payment

            // ==========================================================
            // Envelop
            // ==========================================================
            BdyPayment.CBIEnvelPaymentRequest = EnvelPayment;

            //XmlAttribute attr = x.CreateAttribute("xmlns", "xsi", "http://www.w3.org/2001/XMLSchema-instance");
            ////attr.Value = "http://www.w3.org/2001/XMLSchema-instance";
            //x.DocumentElement.SetAttributeNode(attr);// B.E                  Body\Envelop

            // ==========================================================
            // Envelop
            // ==========================================================
            string xml = BdyPayment.toXml(Encoding.GetEncoding("utf-8"));                         // B                    Body

            if (string.IsNullOrEmpty(xml))
                return null;

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(xml);

            removeAttributes(xmlDoc, xmlDoc.ChildNodes);
            setPrefix(xmlDoc.ChildNodes);
            if (isbonificoEstero) {
                setNameSpaces_pagamentoestero(xmlDoc, xmlDoc.ChildNodes);
            }
            else {
                setNameSpaces_pagamento(xmlDoc, xmlDoc.ChildNodes);
            }
            if (isbonificoEstero) {
                xmlDoc.InnerXml = xmlDoc.InnerXml
                    .Replace("CBIBdyPaymentRequest", "CBIBdyCrossBorderPaymentRequest");

                xmlDoc.InnerXml = xmlDoc.InnerXml
                    .Replace("CBIEnvelPaymentRequest", "CBIEnvelCBICrossBorderPaymentRequest");
                xmlDoc.InnerXml = xmlDoc.InnerXml
                    .Replace("<BODY:CBIEnvelCBICrossBorderPaymentRequest xmlns:BODY=\"urn:CBI:xsd:CBIBdyCrossBorderPaymentRequest.00.04.01\">", "<BODY:CBIEnvelCBICrossBorderPaymentRequest>");



                xmlDoc.InnerXml = xmlDoc.InnerXml
                    .Replace("CBIPaymentRequest", "CBICrossBorderPaymentRequestLogMsg");

                xmlDoc.InnerXml = xmlDoc.InnerXml
                    .Replace("<BODY:CBICrossBorderPaymentRequestLogMsg xmlns:BODY=\"urn:CBI:xsd:CBIEnvelCBICrossBorderPaymentRequest.00.04.01\">", "<BODY:CBICrossBorderPaymentRequestLogMsg>");
    
                xmlDoc.InnerXml = xmlDoc.InnerXml
                    .Replace("<PMRQ:GrpHdr xmlns:PMRQ=\"urn:CBI:xsd:CBICrossBorderPaymentRequestLogMsg.00.04.01\">", "<PMRQ:GrpHdr>")
                    .Replace("iso-8859-1", "UTF-8");

            }
            else {
                xmlDoc.InnerXml = xmlDoc.InnerXml
                    .Replace("<BODY:CBIPaymentRequest xmlns:BODY=\"urn:CBI:xsd:CBIEnvelPaymentRequest.00.04.01\">", "<BODY:CBIPaymentRequest>")
                    .Replace("iso-8859-1", "UTF-8");
            }
            return xmlDoc;
        }

        // ====================================================================
        // REMOVE ATTRIBUTE FROM MAIN NODES
        // ====================================================================
        
        private static void removeAttributes(XmlDocument xmlDoc, XmlNodeList nodeList)
        {
            foreach (XmlNode node in nodeList)
            {
                if (node.Attributes != null)
                {
                    switch (node.Name)
                    {
                        case "CBIBdyPaymentRequest":
                        case "CBIEnvelPaymentRequest":
                        case "CBIPaymentRequest":
                        case "PmtInf":
                        case "GrpHdr":
                        case "CBIBdyPCrossBorderPaymentRequest":
                        case "CBIEnvelCrossBorderPaymentRequest":
                        case "CBICrossBorderPaymentRequestLogMsg":
                            node.Attributes.RemoveAll();
                            break;
                    }
                }

                if (node.HasChildNodes)
                    removeAttributes(xmlDoc, node.ChildNodes);
            }
        }

        // ====================================================================
        // SET PREFIX FOR ALL NODES
        // ====================================================================
        private void setPrefix(XmlNodeList nodeList){
                foreach (XmlNode node in nodeList) {
                    switch (node.Name) {
                        case "CBIBdyPaymentRequest":
                        case "CBIEnvelPaymentRequest":
                        case "CBIPaymentRequest":
                        case "CBIBdyPCrossBorderPaymentRequest":
                        case "CBIEnvelCrossBorderPaymentRequest":
                        case "CBICrossBorderPaymentRequestLogMsg":
                        node.Prefix = "BODY";
                            break;

                        default:
                            node.Prefix = "PMRQ";
                            break;
                    }

                    if (node.HasChildNodes)
                    setPrefix(node.ChildNodes);
                }

        }

        private void setPrefix_pagamentoestero(XmlNodeList nodeList) {
                foreach (XmlNode node in nodeList) {
                    switch (node.Name) {
                        case "CBIBdyPCrossBorderPaymentRequest":
                        case "CBIEnvelCrossBorderPaymentRequest":
                        case "CBICrossBorderPaymentRequestLogMsg":
                            node.Prefix = "BODY";
                            break;

                        default:
                            node.Prefix = "PMRQ";
                            break;
                    }

                    if (node.HasChildNodes)
                        setPrefix_pagamentoestero(node.ChildNodes);
                }
        }
        // ====================================================================
        // SET NAMESPACES
        // ====================================================================
        private static void setNameSpaces_pagamento(XmlDocument xmlDoc, XmlNodeList nodeList)
        {
            XmlAttribute rootAttrib;

            foreach (XmlNode node in nodeList)
            {
                if (node.Attributes != null)
                {
                    switch (node.Name)
                    {
                        case "BODY:CBIBdyPaymentRequest":

                            // xmlns:PMRQ="urn:CBI:xsd:CBIPaymentRequest.00.04.01"
                            rootAttrib = xmlDoc.CreateAttribute("xmlns:PMRQ");
                            rootAttrib.Value = "urn:CBI:xsd:CBIPaymentRequest.00.04.01";
                            node.Attributes.Append(rootAttrib);

                            // xmlns:SGNT="urn:CBI:xsd:CBISgnInf.001.04" 
                            rootAttrib = xmlDoc.CreateAttribute("xmlns:SGNT");
                            rootAttrib.Value = "urn:CBI:xsd:CBISgnInf.001.04";
                            node.Attributes.Append(rootAttrib);

                            // xmlns:BODY="urn:CBI:xsd:CBIBdyPaymentRequest.00.04.01"
                            rootAttrib = xmlDoc.CreateAttribute("xmlns:BODY");
                            rootAttrib.Value = "urn:CBI:xsd:CBIBdyPaymentRequest.00.04.01";
                            node.Attributes.Append(rootAttrib);

                            break;
                    }
                }

                if (node.HasChildNodes)
                    setNameSpaces_pagamento(xmlDoc, node.ChildNodes);
            }
        }
        private static void setNameSpaces_pagamentoestero(XmlDocument xmlDoc, XmlNodeList nodeList) {
            XmlAttribute rootAttrib;

            foreach (XmlNode node in nodeList) {
                if (node.Attributes != null) {
                    switch (node.Name) {
                        //CBIBdyCrossBorderPaymentRequest
                        case "BODY:CBIBdyPaymentRequest":

                            rootAttrib = xmlDoc.CreateAttribute("xmlns:BOE");
                            rootAttrib.Value = "urn:CBI:xsd:CBICrossBorderPaymentRequestPhyMsg.00.01.01";
                            node.Attributes.Append(rootAttrib);

                            // xmlns:PMRQ="urn:CBI:xsd:CBIPaymentRequest.00.04.01"
                            rootAttrib = xmlDoc.CreateAttribute("xmlns:PMRQ");
                            rootAttrib.Value = "urn:CBI:xsd:CBICrossBorderPaymentRequestLogMsg.00.01.01";
                            node.Attributes.Append(rootAttrib);

                            // xmlns:SGNT="urn:CBI:xsd:CBISgnInf.001.04" 
                            rootAttrib = xmlDoc.CreateAttribute("xmlns:SGNT");
                            rootAttrib.Value = "urn:CBI:xsd:CBISgnInf.001.04";
                            node.Attributes.Append(rootAttrib);

                            // xmlns:BODY="urn:CBI:xsd:CBIBdyPaymentRequest.00.04.01"
                            rootAttrib = xmlDoc.CreateAttribute("xmlns:BODY");
                            rootAttrib.Value = "urn:CBI:xsd:CBIBdyPCrossBorderPaymentRequest.00.01.01";
                            node.Attributes.Append(rootAttrib);

                            break;
                    }
                }

                if (node.HasChildNodes)
                    setNameSpaces_pagamentoestero(xmlDoc, node.ChildNodes);
            }
        }

        public CBIPaymentInstructionInformation Crea_PaymentInformation(DataRow Rflusso, DataTable TT) {
            var RPaymentInfo = new CBIPaymentInstructionInformation();
            // E' un Enum, va trattato in modo dedicato
            PaymentMethod3Code Tipo_ModPagamento = PaymentMethod3Code.TRA;
            if (Rflusso["PmtMtd"].ToString().Equals("TRF")) {
                Tipo_ModPagamento = PaymentMethod3Code.TRF;
            }
            if (Rflusso["PmtMtd"].ToString().Equals("CHK")) {
                Tipo_ModPagamento = PaymentMethod3Code.CHK;
            }
            // 2.1	PmtInfId	Payment Information Identification
            RPaymentInfo.PmtInfId = Rflusso["PmtInfId"].ToString().Replace("_", "-");

            // 2.2 PmtMtd Payment Method

            RPaymentInfo.PmtMtd = Tipo_ModPagamento;
            if (RPaymentInfo == null) {
                MetaFactory.factory.getSingleton<IMessageShower>().Show("Salta" + Rflusso["PmtInfId"].ToString() + " per errore di dati");
                return null;
            }
            if (!isbonificoEstero) {
                //2.4 PmtTpInf    Informazioni tipo di pagamento  CBIPaymentTypeInformation1
                CBIPaymentTypeInformation1 _PmtTpInf = new CBIPaymentTypeInformation1();
                _PmtTpInf.InstrPrty = Priority2Code.NORM;

                //2.4.2	SvcLvl  	Livelli di servizio specifici	CBIServiceLevel1

                CBIServiceLevel1 _SvcLvl = new CBIServiceLevel1();

                //2.4.2.1	Cd 	Code	Codifica di servizio
                CBIServiceLevel1Code _Cd = CBIServiceLevel1Code.SEPA;
                if (Rflusso["PaymentTypeInformation_Cd"].ToString().Equals("PGPA")) {
                    _Cd = CBIServiceLevel1Code.PGPA;
                }
                if (Rflusso["PaymentTypeInformation_Cd"].ToString().Equals("PGSP")) {
                    _Cd = CBIServiceLevel1Code.PGSP;
                }
                _SvcLvl.Cd = _Cd;
                _PmtTpInf.SvcLvl = _SvcLvl;
                RPaymentInfo.PmtTpInf = _PmtTpInf;
            }
            //2.5 ReqdExctnDt Requested Execution Date    Data richiesta dal mittente
            //2.5.1   Dt Date    Data
            //2.5.2   DtTm Date Time Data e Ora

            DateAndDateTime2Choice _ReqdExctnDt = new DateAndDateTime2Choice();
            _ReqdExctnDt.Dt = (DateTime)Rflusso["Debtor_ReqdExctnDt"];
            RPaymentInfo.ReqdExctnDt = _ReqdExctnDt;

            //2.6 Dbtr Debtor  Titolare c/ c addebito CBIPartyIdentification4
            CBIPartyIdentification4 _Dbtr = new CBIPartyIdentification4();
            _Dbtr.Nm = Rflusso["Debtor_Nm"].ToString();

            //2.6.2   PstlAdr PostalAddress   Indirizzo Postale   CBIPostalAddress6
            CBIPostalAddress24 _PstlAdr = new CBIPostalAddress24();

            //_PstlAdr.AdrTp = Rflusso["Debtor_AdrTp"].ToString();
            //2.6.2.1	AdrTp	AddressType	Tipo Indirizzo	AddressType2Code
            AddressType3Choice _AdrTp = new AddressType3Choice();
            _AdrTp.Cd = AddressType2Code.ADDR;
            _PstlAdr.adrTp = _AdrTp;
            //2.6.2.4	StrtNm	StreetName

            _PstlAdr.strtNm = Rflusso["Debtor_StrtNm"].ToString();
            //2.6.2.10	PstCd	PostalCode	Codice postale
            if (Rflusso["Debtor_PstCd"].ToString() != "") {
                _PstlAdr.pstCd = Rflusso["Debtor_PstCd"].ToString();
            }
        
            RPaymentInfo.Dbtr = _Dbtr;
            RPaymentInfo.Dbtr.PstlAdr = _PstlAdr;

            //2.7	DbtrAcct	Debtor Account	Coordinate bancarie di addebito	CBICashAccount1
            CBICashAccount2 _DbtrAcct = new CBICashAccount2();

            //2.7.1	Id	Identification	ID Conto	CBIAccountIdentification1
            CBIAccountIdentification1 _Id = new CBIAccountIdentification1();
            _Id.IBAN = Rflusso["Debtor_IBAN"].ToString();
            _DbtrAcct.Id = _Id;
            RPaymentInfo.DbtrAcct = _DbtrAcct;

            //2.8 DbtrAgt Debtor Agent Banca del Debitore  
            CBIBranchAndFinancialInstitutionIdentification2 _DbtrAgt =
                new CBIBranchAndFinancialInstitutionIdentification2();

            //2.8.1	FinInstnId	Financial Institution Identification	Identificativi Istituto finanziario	CBIFinancialInstitutionIdentification3
            CBIFinancialInstitutionIdentification3 _FinInstnId =
                 new CBIFinancialInstitutionIdentification3();

            //2.8.1.2	ClrSysMmbId	Clearing System Member Identification	ID Istituto nel Sistema di Clearing	CBIClearingSystemMemberIdentification1
            CBIClearingSystemMemberIdentification1 _ClrSysMmbId = new CBIClearingSystemMemberIdentification1();
            _ClrSysMmbId.MmbId = Rflusso["Debtor_MmbId"].ToString();

            _FinInstnId.ClrSysMmbId = _ClrSysMmbId;
            _DbtrAgt.FinInstnId = _FinInstnId;
            RPaymentInfo.DbtrAgt = _DbtrAgt;

			//2.10    ChrgBr Charge Bearer Tipologia Commissioni CBIChargeBearerTypeCode
			if (isbonificoEstero) {
                CBIChargeBearerTypeCode _ChrgBr = CBIChargeBearerTypeCode.SHAR;
                RPaymentInfo.ChrgBr = _ChrgBr;
            }
            else {
                CBIChargeBearerTypeCode _ChrgBr = CBIChargeBearerTypeCode.SLEV;
                RPaymentInfo.ChrgBr = _ChrgBr;

            }

            CBICreditTransferTransactionInformation _CdtTrfTxInf = new CBICreditTransferTransactionInformation();
            DataRow[] rCred = TT.Select("kind = 'CreditTransferTransactionInformation'");
            int n = TT.Rows.Count;
            if (n > 0) {
                CBICreditTransferTransactionInformation[] iCdtTrfTxInf = new CBICreditTransferTransactionInformation[n];
                int i = 0;
                foreach (DataRow R in rCred) {
                    var benef = get_informazioni_beneficiario(R);
                    iCdtTrfTxInf[i]= benef;
                    
                    i++;
                }
                RPaymentInfo.CdtTrfTxInf = iCdtTrfTxInf;
            }
            return RPaymentInfo;
        }

    }
}
