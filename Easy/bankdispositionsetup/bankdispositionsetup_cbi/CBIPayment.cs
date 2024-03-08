
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
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.ComponentModel;
using System.Xml.Serialization;

namespace bankdispositionsetup_cbi
{
    [GeneratedCodeAttribute("xsd", "4.6.1590.0")]
    [SerializableAttribute()]
    [DebuggerStepThroughAttribute()]
    [DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(TypeName = "CBIBdyPaymentRequest.00.04.01", Namespace = "urn:CBI:xsd:CBIBdyPaymentRequest.00.04.01")]
    [XmlRootAttribute("CBIBdyPaymentRequest", Namespace = "urn:CBI:xsd:CBIBdyPaymentRequest.00.04.01", IsNullable = false)]
    public partial class CBIBdyPayment
    {
        /// <remarks/>
        public CBIEnvelPayment CBIEnvelPaymentRequest { get; set; }
    }

    [GeneratedCodeAttribute("xsd", "4.6.1590.0")]
    [SerializableAttribute()]
    [DebuggerStepThroughAttribute()]
    [DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(TypeName = "CBIEnvelPaymentRequest.00.04.01", Namespace = "urn:CBI:xsd:CBIEnvelPaymentRequest.00.04.01")]
    [XmlRootAttribute("CBIEnvelPaymentRequest", Namespace = "urn:CBI:xsd:CBIEnvelPaymentRequest.00.04.01", IsNullable = false)]
    public partial class CBIEnvelPayment
    {
        /// <remarks/>
        public CBIPayment CBIPaymentRequest { get; set; }
    }

    [GeneratedCodeAttribute("xsd", "4.6.1590.0")]
    [SerializableAttribute()]
    [DebuggerStepThroughAttribute()]
    [DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(TypeName = "CBIPaymentRequest.00.04.01", Namespace = "urn:CBI:xsd:CBIPaymentRequest.00.04.01")]
    [XmlRootAttribute("CBIPaymentRequest", Namespace = "urn:CBI:xsd:CBIPaymentRequest.00.04.01", IsNullable = false)]
    public partial class CBIPayment
    {
        /// <remarks/>
        public CBIGroupHeader GrpHdr { get; set; }

        /// <remarks/>
        public CBIPaymentInstructionInformation PmtInf { get; set; }

        public CBIPayment()
        {
            this.GrpHdr = new CBIGroupHeader();
            this.PmtInf = new CBIPaymentInstructionInformation();

        }
    }


    /// <remarks/>
    [GeneratedCodeAttribute("xsd", "4.6.1590.0")]
    [SerializableAttribute()]
    [DebuggerStepThroughAttribute()]
    [DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(Namespace = "urn:CBI:xsd:CBIPaymentRequest.00.04.01")]
    public partial class CBIGroupHeader
    {

        /// <remarks/>
        public string MsgId { get; set; }

        /// <remarks/>
        public System.DateTime CreDtTm { get; set; }

        /// <remarks/>
        public string NbOfTxs { get; set; }

        /// <remarks/>
        public decimal CtrlSum { get; set; }

        /// <remarks/>
        public CBIPartyIdentification1 InitgPty { get; set; }

    }

    /// <remarks/>
    [GeneratedCodeAttribute("xsd", "4.6.1590.0")]
    [SerializableAttribute()]
    [DebuggerStepThroughAttribute()]
    [DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(Namespace = "urn:CBI:xsd:CBIPaymentRequest.00.04.01")]
    public partial class CBIPartyIdentification1
    {

        /// <remarks/>
        public string Nm { get; set; }

        /// <remarks/>
        public CBIIdType1 Id { get; set; }
    }

    /// <remarks/>
    [GeneratedCodeAttribute("xsd", "4.6.1590.0")]
    [SerializableAttribute()]
    [DebuggerStepThroughAttribute()]
    [DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(Namespace = "urn:CBI:xsd:CBIPaymentRequest.00.04.01")]
    public partial class CBIIdType1
    {

        /// <remarks/>
        public CBIOrganisationIdentification1 OrgId { get; set; }
    }

    /// <remarks/>
    [GeneratedCodeAttribute("xsd", "4.6.1590.0")]
    [SerializableAttribute()]
    [DebuggerStepThroughAttribute()]
    [DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(Namespace = "urn:CBI:xsd:CBIPaymentRequest.00.04.01")]
    public partial class CBIOrganisationIdentification1
    {
        /// <remarks/>
        public CBIGenericIdentification1 Othr { get; set; }
    }
    /// <remarks/>
    [GeneratedCodeAttribute("xsd", "4.6.1590.0")]
    [SerializableAttribute()]
    [DebuggerStepThroughAttribute()]
    [DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(Namespace = "urn:CBI:xsd:CBIPaymentRequest.00.04.01")]
    public partial class CBIGenericIdentification1
    {

        /// <remarks/>
        public string Id { get; set; }

        /// <remarks/>
        public string Issr { get; set; }
    }

    /// <remarks/>
    [GeneratedCodeAttribute("xsd", "4.6.1590.0")]
    [SerializableAttribute()]
    [DebuggerStepThroughAttribute()]
    [DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(Namespace = "urn:CBI:xsd:CBIPaymentRequest.00.04.01")]
    public partial class ContactDetails2
    {

        /// <remarks/>
        public NamePrefix1Code NmPrfx { get; set; }

        /// <remarks/>
        [XmlIgnoreAttribute()]
        public bool NmPrfxSpecified { get; set; }

        /// <remarks/>
        public string Nm { get; set; }

        /// <remarks/>
        public string PhneNb { get; set; }

        /// <remarks/>
        public string MobNb { get; set; }

        /// <remarks/>
        public string FaxNb { get; set; }

        /// <remarks/>
        public string EmailAdr { get; set; }

        /// <remarks/>
        public string Othr { get; set; }
    }

    /// <remarks/>
    [GeneratedCodeAttribute("xsd", "4.6.1590.0")]
    [SerializableAttribute()]
    [XmlTypeAttribute(Namespace = "urn:CBI:xsd:CBIPaymentRequest.00.04.01")]
    public enum NamePrefix1Code
    {

        /// <remarks/>
        DOCT,

        /// <remarks/>
        MIST,

        /// <remarks/>
        MISS,

        /// <remarks/>
        MADM,
    }

    /// <remarks/>
    [GeneratedCodeAttribute("xsd", "4.6.1590.0")]
    [SerializableAttribute()]
    [DebuggerStepThroughAttribute()]
    [DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(Namespace = "urn:CBI:xsd:CBIPaymentRequest.00.04.01")]
    public partial class PersonIdentificationSchemeName1Choice
    {

        /// <remarks/>
        [XmlElementAttribute("Cd", typeof(string))]
        [XmlElementAttribute("Prtry", typeof(string))]
        [XmlChoiceIdentifierAttribute("ItemElementName")]
        public string Item { get; set; }

        /// <remarks/>
        [XmlIgnoreAttribute()]
        public ItemChoiceType4 ItemElementName { get; set; }
    }

    /// <remarks/>
    [GeneratedCodeAttribute("xsd", "4.6.1590.0")]
    [SerializableAttribute()]
    [XmlTypeAttribute(Namespace = "urn:CBI:xsd:CBIPaymentRequest.00.04.01", IncludeInSchema = false)]
    public enum ItemChoiceType4
    {

        /// <remarks/>
        Cd,

        /// <remarks/>
        Prtry,
    }

    /// <remarks/>
    [GeneratedCodeAttribute("xsd", "4.6.1590.0")]
    [SerializableAttribute()]
    [DebuggerStepThroughAttribute()]
    [DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(Namespace = "urn:CBI:xsd:CBIPaymentRequest.00.04.01")]
    public partial class GenericPersonIdentification1
    {

        /// <remarks/>
        public string Id { get; set; }

        /// <remarks/>
        public PersonIdentificationSchemeName1Choice SchmeNm { get; set; }

        /// <remarks/>
        public string Issr { get; set; }
    }

    /// <remarks/>
    [GeneratedCodeAttribute("xsd", "4.6.1590.0")]
    [SerializableAttribute()]
    [DebuggerStepThroughAttribute()]
    [DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(Namespace = "urn:CBI:xsd:CBIPaymentRequest.00.04.01")]
    public partial class DateAndPlaceOfBirth
    {
        /// <remarks/>
        [XmlElementAttribute(DataType = "date")]
        public System.DateTime BirthDt { get; set; }

        /// <remarks/>
        public string PrvcOfBirth { get; set; }

        /// <remarks/>
        public string CityOfBirth { get; set; }

        /// <remarks/>
        public string CtryOfBirth { get; set; }
    }

    /// <remarks/>
    [GeneratedCodeAttribute("xsd", "4.6.1590.0")]
    [SerializableAttribute()]
    [DebuggerStepThroughAttribute()]
    [DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(Namespace = "urn:CBI:xsd:CBIPaymentRequest.00.04.01")]
    public partial class PersonIdentification5
    {

        /// <remarks/>
        public DateAndPlaceOfBirth DtAndPlcOfBirth { get; set; }

        /// <remarks/>
        [XmlElementAttribute("Othr")]
        public GenericPersonIdentification1[] Othr { get; set; }
    }

    /// <remarks/>
    [GeneratedCodeAttribute("xsd", "4.6.1590.0")]
    [SerializableAttribute()]
    [DebuggerStepThroughAttribute()]
    [DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(Namespace = "urn:CBI:xsd:CBIPaymentRequest.00.04.01")]
    public partial class OrganisationIdentificationSchemeName1Choice
    {

        /// <remarks/>
        [XmlElementAttribute("Cd", typeof(string))]
        [XmlElementAttribute("Prtry", typeof(string))]
        [XmlChoiceIdentifierAttribute("ItemElementName")]
        public string Item { get; set; }

        /// <remarks/>
        [XmlIgnoreAttribute()]
        public ItemChoiceType3 ItemElementName { get; set; }
    }

    /// <remarks/>
    [GeneratedCodeAttribute("xsd", "4.6.1590.0")]
    [SerializableAttribute()]
    [XmlTypeAttribute(Namespace = "urn:CBI:xsd:CBIPaymentRequest.00.04.01", IncludeInSchema = false)]
    public enum ItemChoiceType3
    {

        /// <remarks/>
        Cd,

        /// <remarks/>
        Prtry,
    }

    /// <remarks/>
    [GeneratedCodeAttribute("xsd", "4.6.1590.0")]
    [SerializableAttribute()]
    [DebuggerStepThroughAttribute()]
    [DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(Namespace = "urn:CBI:xsd:CBIPaymentRequest.00.04.01")]
    public partial class GenericOrganisationIdentification1
    {

        /// <remarks/>
        public string Id { get; set; }

        /// <remarks/>
        public OrganisationIdentificationSchemeName1Choice SchmeNm { get; set; }

        /// <remarks/>
        public string Issr { get; set; }
    }

    /// <remarks/>
    [GeneratedCodeAttribute("xsd", "4.6.1590.0")]
    [SerializableAttribute()]
    [DebuggerStepThroughAttribute()]
    [DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(Namespace = "urn:CBI:xsd:CBIPaymentRequest.00.04.01")]
    public partial class OrganisationIdentification4
    {

        public string BICOrBEI { get; set; }

        /// <remarks/>
        [XmlElementAttribute("Othr")]
        public GenericOrganisationIdentification1[] Othr { get; set; }
    }

    /// <remarks/>
    [GeneratedCodeAttribute("xsd", "4.6.1590.0")]
    [SerializableAttribute()]
    [DebuggerStepThroughAttribute()]
    [DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(Namespace = "urn:CBI:xsd:CBIPaymentRequest.00.04.01")]
    public partial class Party6Choice
    {

        /// <remarks/>
        [XmlElementAttribute("OrgId", typeof(OrganisationIdentification4))]
        [XmlElementAttribute("PrvtId", typeof(PersonIdentification5))]
        public object Item { get; set; }
    }

    /// <remarks/>
    [GeneratedCodeAttribute("xsd", "4.6.1590.0")]
    [SerializableAttribute()]
    [DebuggerStepThroughAttribute()]
    [DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(Namespace = "urn:CBI:xsd:CBIPaymentRequest.00.04.01")]
    public partial class PartyIdentification32
    {

        /// <remarks/>
        public string Nm { get; set; }

        /// <remarks/>
        public CBIPostalAddress6 PstlAdr { get; set; }

        /// <remarks/>
        public Party6Choice Id { get; set; }

        /// <remarks/>
        public string CtryOfRes { get; set; }

        /// <remarks/>
        public ContactDetails2 CtctDtls { get; set; }
    }
    [GeneratedCodeAttribute("xsd", "4.6.1590.0")]
    [SerializableAttribute()]
    [DebuggerStepThroughAttribute()]
    [DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(Namespace = "urn:CBI:xsd:CBIPaymentRequest.00.04.01")]
    public partial class GenericIdentification30 {

        public string id { get; set; }

        public string issrField { get; set; }

        public string schmeNmField { get; set; }
    }
        /// <remarks/>
    [GeneratedCodeAttribute("xsd", "4.6.1590.0")]
    [SerializableAttribute()]
    [DebuggerStepThroughAttribute()]
    [DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(Namespace = "urn:CBI:xsd:CBIPaymentRequest.00.04.01")]

    public partial class DateAndDateTime2Choice {

        /// <remarks/>
        [XmlElementAttribute(DataType = "date")]
        public System.DateTime Dt{ get; set; }

        [XmlIgnoreAttribute()]
        public System.DateTime DtTm { get; set; }
    }

    /// <remarks/>
    [GeneratedCodeAttribute("xsd", "4.6.1590.0")]
    [SerializableAttribute()]
    [DebuggerStepThroughAttribute()]
    [DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(Namespace = "urn:CBI:xsd:CBIPaymentRequest.00.04.01")]
    public partial class AddressType3Choice {
        public AddressType2Code Cd { get; set; }
        public GenericIdentification30 Prtry { get; set; }
    }

    /// <remarks/>
    [GeneratedCodeAttribute("xsd", "4.6.1590.0")]
    [SerializableAttribute()]
    [DebuggerStepThroughAttribute()]
    [DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(Namespace = "urn:CBI:xsd:CBIPaymentRequest.00.04.01")]
    public partial class CBIPostalAddress24 {

        public AddressType3Choice adrTp { get; set; }

        public string dept { get; set; }

        public string subDept { get; set; }

        public string strtNm { get; set; }

        public string bldgNb { get; set; }

        public string bldgNm { get; set; }

        public string flr { get; set; }

        public string pstBx { get; set; }

        public string room { get; set; }

        public string pstCd { get; set; }

        public string twnNm { get; set; }

        public string twnLctnNm { get; set; }

        public string dstrctNm { get; set; }

        public string ctrySubDvsn { get; set; }

        public string ctry { get; set; }

        public string[] adrLine { get; set; }
    }

        /// <remarks/>
    [GeneratedCodeAttribute("xsd", "4.6.1590.0")]
    [SerializableAttribute()]
    [DebuggerStepThroughAttribute()]
    [DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(Namespace = "urn:CBI:xsd:CBIPaymentRequest.00.04.01")]
    public partial class CBIPostalAddress6
    {

        /// <remarks/>
        public AddressType2Code AdrTp { get; set; }

        /// <remarks/>
        [XmlIgnoreAttribute()]
        public bool AdrTpSpecified { get; set; }

        /// <remarks/>
        public string Dept { get; set; }

        /// <remarks/>
        public string SubDept { get; set; }

        /// <remarks/>
        public string StrtNm { get; set; }

        /// <remarks/>
        public string BldgNb { get; set; }

        /// <remarks/>
        public string PstCd { get; set; }

        /// <remarks/>
        public string TwnNm { get; set; }

        /// <remarks/>
        public string CtrySubDvsn { get; set; }

        /// <remarks/>
        public string Ctry { get; set; }

        /// <remarks/>
        [XmlElementAttribute("AdrLine")]
        public string[] AdrLine { get; set; }
    }

    /// <remarks/>
    [GeneratedCodeAttribute("xsd", "4.6.1590.0")]
    [SerializableAttribute()]
    [XmlTypeAttribute(Namespace = "urn:CBI:xsd:CBIPaymentRequest.00.04.01")]
    public enum AddressType2Code
    {

        /// <remarks/>
        ADDR,

        /// <remarks/>
        PBOX,

        /// <remarks/>
        HOME,

        /// <remarks/>
        BIZZ,

        /// <remarks/>
        MLTO,

        /// <remarks/>
        DLVY,
    }

    /// <remarks/>
    [GeneratedCodeAttribute("xsd", "4.6.1590.0")]
    [SerializableAttribute()]
    [DebuggerStepThroughAttribute()]
    [DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(Namespace = "urn:CBI:xsd:CBIPaymentRequest.00.04.01")]
    public partial class CreditorReferenceType1Choice
    {

        /// <remarks/>
        [XmlElementAttribute("Cd", typeof(DocumentType3Code))]
        [XmlElementAttribute("Prtry", typeof(string))]
        public object Item { get; set; }
    }

    /// <remarks/>
    [GeneratedCodeAttribute("xsd", "4.6.1590.0")]
    [SerializableAttribute()]
    [XmlTypeAttribute(Namespace = "urn:CBI:xsd:CBIPaymentRequest.00.04.01")]
    public enum DocumentType3Code
    {

        /// <remarks/>
        RADM,

        /// <remarks/>
        RPIN,

        /// <remarks/>
        FXDR,

        /// <remarks/>
        DISP,

        /// <remarks/>
        PUOR,

        /// <remarks/>
        SCOR,
    }

    /// <remarks/>
    [GeneratedCodeAttribute("xsd", "4.6.1590.0")]
    [SerializableAttribute()]
    [DebuggerStepThroughAttribute()]
    [DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(Namespace = "urn:CBI:xsd:CBIPaymentRequest.00.04.01")]
    public partial class CreditorReferenceType2
    {
        /// <remarks/>
        public CreditorReferenceType1Choice CdOrPrtry { get; set; }

        /// <remarks/>
        public string Issr { get; set; }
    }

    /// <remarks/>
    [GeneratedCodeAttribute("xsd", "4.6.1590.0")]
    [SerializableAttribute()]
    [DebuggerStepThroughAttribute()]
    [DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(Namespace = "urn:CBI:xsd:CBIPaymentRequest.00.04.01")]
    public partial class CreditorReferenceInformation2
    {

        /// <remarks/>
        public CreditorReferenceType2 Tp { get; set; }

        /// <remarks/>
        public string Ref { get; set; }
    }

    /// <remarks/>
    [GeneratedCodeAttribute("xsd", "4.6.1590.0")]
    [SerializableAttribute()]
    [DebuggerStepThroughAttribute()]
    [DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(Namespace = "urn:CBI:xsd:CBIPaymentRequest.00.04.01")]
    public partial class DocumentAdjustment1
    {

        /// <remarks/>
        public ActiveOrHistoricCurrencyAndAmount Amt { get; set; }

        /// <remarks/>
        public CreditDebitCode CdtDbtInd { get; set; }

        /// <remarks/>
        [XmlIgnoreAttribute()]
        public bool CdtDbtIndSpecified { get; set; }

        /// <remarks/>
        public string Rsn { get; set; }

        /// <remarks/>
        public string AddtlInf { get; set; }
    }

    /// <remarks/>
    [GeneratedCodeAttribute("xsd", "4.6.1590.0")]
    [SerializableAttribute()]
    [DebuggerStepThroughAttribute()]
    [DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(Namespace = "urn:CBI:xsd:CBIPaymentRequest.00.04.01")]
    public partial class ActiveOrHistoricCurrencyAndAmount
    {

        /// <remarks/>
        [XmlAttributeAttribute()]
        public string Ccy { get; set; }

        /// <remarks/>
        [XmlTextAttribute()]
        public string Value { get; set; }
    }

    /// <remarks/>
    [GeneratedCodeAttribute("xsd", "4.6.1590.0")]
    [SerializableAttribute()]
    [XmlTypeAttribute(Namespace = "urn:CBI:xsd:CBIPaymentRequest.00.04.01")]
    public enum CreditDebitCode
    {

        /// <remarks/>
        CRDT,

        /// <remarks/>
        DBIT,
    }

    /// <remarks/>
    [GeneratedCodeAttribute("xsd", "4.6.1590.0")]
    [SerializableAttribute()]
    [DebuggerStepThroughAttribute()]
    [DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(Namespace = "urn:CBI:xsd:CBIPaymentRequest.00.04.01")]
    public partial class RemittanceAmount1
    {

        /// <remarks/>
        public ActiveOrHistoricCurrencyAndAmount DuePyblAmt { get; set; }

        /// <remarks/>
        public ActiveOrHistoricCurrencyAndAmount DscntApldAmt { get; set; }

        /// <remarks/>
        public ActiveOrHistoricCurrencyAndAmount CdtNoteAmt { get; set; }

        /// <remarks/>
        public ActiveOrHistoricCurrencyAndAmount TaxAmt { get; set; }

        /// <remarks/>
        [XmlElementAttribute("AdjstmntAmtAndRsn")]
        public DocumentAdjustment1[] AdjstmntAmtAndRsn { get; set; }

        /// <remarks/>
        public ActiveOrHistoricCurrencyAndAmount RmtdAmt { get; set; }
    }

    /// <remarks/>
    [GeneratedCodeAttribute("xsd", "4.6.1590.0")]
    [SerializableAttribute()]
    [DebuggerStepThroughAttribute()]
    [DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(Namespace = "urn:CBI:xsd:CBIPaymentRequest.00.04.01")]
    public partial class ReferredDocumentType1Choice
    {
        /// <remarks/>
        [XmlElementAttribute("Cd", typeof(DocumentType5Code))]
        [XmlElementAttribute("Prtry", typeof(string))]
        public object Item { get; set; }
    }

    /// <remarks/>
    [GeneratedCodeAttribute("xsd", "4.6.1590.0")]
    [SerializableAttribute()]
    [XmlTypeAttribute(Namespace = "urn:CBI:xsd:CBIPaymentRequest.00.04.01")]
    public enum DocumentType5Code
    {

        /// <remarks/>
        MSIN,

        /// <remarks/>
        CNFA,

        /// <remarks/>
        DNFA,

        /// <remarks/>
        CINV,

        /// <remarks/>
        CREN,

        /// <remarks/>
        DEBN,

        /// <remarks/>
        HIRI,

        /// <remarks/>
        SBIN,

        /// <remarks/>
        CMCN,

        /// <remarks/>
        SOAC,

        /// <remarks/>
        DISP,

        /// <remarks/>
        BOLD,

        /// <remarks/>
        VCHR,

        /// <remarks/>
        AROI,

        /// <remarks/>
        TSUT,
    }

    /// <remarks/>
    [GeneratedCodeAttribute("xsd", "4.6.1590.0")]
    [SerializableAttribute()]
    [DebuggerStepThroughAttribute()]
    [DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(Namespace = "urn:CBI:xsd:CBIPaymentRequest.00.04.01")]
    public partial class ReferredDocumentType2
    {

        /// <remarks/>
        public ReferredDocumentType1Choice CdOrPrtry { get; set; }

        /// <remarks/>
        public string Issr { get; set; }
    }

    /// <remarks/>
    [GeneratedCodeAttribute("xsd", "4.6.1590.0")]
    [SerializableAttribute()]
    [DebuggerStepThroughAttribute()]
    [DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(Namespace = "urn:CBI:xsd:CBIPaymentRequest.00.04.01")]
    public partial class ReferredDocumentInformation3
    {

        /// <remarks/>
        public ReferredDocumentType2 Tp { get; set; }

        /// <remarks/>
        public string Nb { get; set; }

        /// <remarks/>
        [XmlElementAttribute(DataType = "date")]
        public System.DateTime RltdDt { get; set; }

        /// <remarks/>
        [XmlIgnoreAttribute()]
        public bool RltdDtSpecified { get; set; }
    }

    /// <remarks/>
    [GeneratedCodeAttribute("xsd", "4.6.1590.0")]
    [SerializableAttribute()]
    [DebuggerStepThroughAttribute()]
    [DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(Namespace = "urn:CBI:xsd:CBIPaymentRequest.00.04.01")]
    public partial class StructuredRemittanceInformation7
    {
        /// <remarks/>
        [XmlElementAttribute("RfrdDocInf")]
        public ReferredDocumentInformation3[] RfrdDocInf { get; set; }

        /// <remarks/>
        public RemittanceAmount1 RfrdDocAmt { get; set; }

        /// <remarks/>
        public CreditorReferenceInformation2 CdtrRefInf { get; set; }

        /// <remarks/>
        public PartyIdentification32 Invcr { get; set; }

        /// <remarks/>
        public PartyIdentification32 Invcee { get; set; }

        /// <remarks/>
        [XmlElementAttribute("AddtlRmtInf")]
        public string[] AddtlRmtInf { get; set; }
    }

    /// <remarks/>
    [GeneratedCodeAttribute("xsd", "4.6.1590.0")]
    [SerializableAttribute()]
    [DebuggerStepThroughAttribute()]
    [DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(Namespace = "urn:CBI:xsd:CBIPaymentRequest.00.04.01")]
    public partial class RemittanceInformation5
    {

        /// <remarks/>
        [XmlElementAttribute("Ustrd")]
        public string Ustrd { get; set; }

        /// <remarks/>
        [XmlElementAttribute("Strd")]
        public StructuredRemittanceInformation7 Strd { get; set; }
    }

    /// <remarks/>
    [GeneratedCodeAttribute("xsd", "4.6.1590.0")]
    [SerializableAttribute()]
    [DebuggerStepThroughAttribute()]
    [DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(Namespace = "urn:CBI:xsd:CBIPaymentRequest.00.04.01")]
    public partial class CBIRemittanceLocation1
    {

        /// <remarks/>
        public string RmtId { get; set; }

        /// <remarks/>
        public CBIRemittanceLocationMethod1Code RmtLctnMtd { get; set; }

        /// <remarks/>
        [XmlIgnoreAttribute()]
        public bool RmtLctnMtdSpecified { get; set; }

        /// <remarks/>
        public string RmtLctnElctrncAdr { get; set; }
    }

    /// <remarks/>
    [GeneratedCodeAttribute("xsd", "4.6.1590.0")]
    [SerializableAttribute()]
    [XmlTypeAttribute(Namespace = "urn:CBI:xsd:CBIPaymentRequest.00.04.01")]
    public enum CBIRemittanceLocationMethod1Code
    {

        /// <remarks/>
        FAXI,

        /// <remarks/>
        EMAL,

        /// <remarks/>
        SMSM,
    }

    /// <remarks/>
    [GeneratedCodeAttribute("xsd", "4.6.1590.0")]
    [SerializableAttribute()]
    [DebuggerStepThroughAttribute()]
    [DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(Namespace = "urn:CBI:xsd:CBIPaymentRequest.00.04.01")]
    public partial class CBIStructuredRegulatoryReporting1
    {

        /// <remarks/>
        public CBIStructuredRegulatoryReporting1CD Cd { get; set; }

        /// <remarks/>
        public ActiveOrHistoricCurrencyAndAmount Amt { get; set; }

        /// <remarks/>
        public string Inf { get; set; }
    }

    /// <remarks/>
    [GeneratedCodeAttribute("xsd", "4.6.1590.0")]
    [SerializableAttribute()]
    [XmlTypeAttribute(AnonymousType = true, Namespace = "urn:CBI:xsd:CBIPaymentRequest.00.04.01")]
    public enum CBIStructuredRegulatoryReporting1CD
    {

        /// <remarks/>
        INF,

        /// <remarks/>
        SNR,

        /// <remarks/>
        CVA,
    }

    /// <remarks/>
    [GeneratedCodeAttribute("xsd", "4.6.1590.0")]
    [SerializableAttribute()]
    [DebuggerStepThroughAttribute()]
    [DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(Namespace = "urn:CBI:xsd:CBIPaymentRequest.00.04.01")]
    public partial class CBIRegulatoryReporting1
    {

        /// <remarks/>
        public CBIRegulatoryReportingType1Code DbtCdtRptgInd { get; set; }

        /// <remarks/>
        public CBIStructuredRegulatoryReporting1 Dtls { get; set; }
    }

    /// <remarks/>
    [GeneratedCodeAttribute("xsd", "4.6.1590.0")]
    [SerializableAttribute()]
    [XmlTypeAttribute(Namespace = "urn:CBI:xsd:CBIPaymentRequest.00.04.01")]
    public enum CBIRegulatoryReportingType1Code
    {

        /// <remarks/>
        DEBT,
    }

    /// <remarks/>
    [GeneratedCodeAttribute("xsd", "4.6.1590.0")]
    [SerializableAttribute()]
    [DebuggerStepThroughAttribute()]
    [DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(Namespace = "urn:CBI:xsd:CBIPaymentRequest.00.04.01")]
    public partial class Purpose1Choice
    {

        /// <remarks/>
        [XmlElementAttribute("Cd", typeof(string))]
        [XmlElementAttribute("Prtry", typeof(string))]
        [XmlChoiceIdentifierAttribute("ItemElementName")]
        public string Item { get; set; }

        /// <remarks/>
        [XmlIgnoreAttribute()]
        public ItemChoiceType2 ItemElementName { get; set; }
    }

    /// <remarks/>
    [GeneratedCodeAttribute("xsd", "4.6.1590.0")]
    [SerializableAttribute()]
    [XmlTypeAttribute(Namespace = "urn:CBI:xsd:CBIPaymentRequest.00.04.01", IncludeInSchema = false)]
    public enum ItemChoiceType2
    {

        /// <remarks/>
        Cd,

        /// <remarks/>
        Prtry,
    }

    /// <remarks/>
    [GeneratedCodeAttribute("xsd", "4.6.1590.0")]
    [SerializableAttribute()]
    [DebuggerStepThroughAttribute()]
    [DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(Namespace = "urn:CBI:xsd:CBIPaymentRequest.00.04.01")]
    public partial class CBIGenericIdentification2
    {

        /// <remarks/>
        public string Id { get; set; }

        /// <remarks/>
        public string Issr { get; set; }
    }

    /// <remarks/>
    [GeneratedCodeAttribute("xsd", "4.6.1590.0")]
    [SerializableAttribute()]
    [DebuggerStepThroughAttribute()]
    [DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(Namespace = "urn:CBI:xsd:CBIPaymentRequest.00.04.01")]
    public partial class CBIOrganisationIdentification4
    {

        /// <remarks/>
        public CBIGenericIdentification2 Othr { get; set; }
    }

    /// <remarks/>
    [GeneratedCodeAttribute("xsd", "4.6.1590.0")]
    [SerializableAttribute()]
    [DebuggerStepThroughAttribute()]
    [DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(Namespace = "urn:CBI:xsd:CBIPaymentRequest.00.04.01")]
    public partial class CBIIdType3
    {

        /// <remarks/>
        public CBIOrganisationIdentification4 OrgId { get; set; }
    }

    /// <remarks/>
    [GeneratedCodeAttribute("xsd", "4.6.1590.0")]
    [SerializableAttribute()]
    [DebuggerStepThroughAttribute()]
    [DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(Namespace = "urn:CBI:xsd:CBIPaymentRequest.00.04.01")]
    public partial class CBIPartyIdentification5
    {

        /// <remarks/>
        public string Nm { get; set; }

        /// <remarks/>
        public CBIIdType3 Id { get; set; }
    }

    /// <remarks/>
    [GeneratedCodeAttribute("xsd", "4.6.1590.0")]
    [SerializableAttribute()]
    [DebuggerStepThroughAttribute()]
    [DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(Namespace = "urn:CBI:xsd:CBIPaymentRequest.00.04.01")]
    public partial class CBIPersonIdentification1
    {

        /// <remarks/>
        public CBIGenericIdentification1 Othr { get; set; }
    }

    /// <remarks/>
    [GeneratedCodeAttribute("xsd", "4.6.1590.0")]
    [SerializableAttribute()]
    [DebuggerStepThroughAttribute()]
    [DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(Namespace = "urn:CBI:xsd:CBIPaymentRequest.00.04.01")]
    public partial class CBIOrganisationIdentification2
    {

        public string AnyBIC { get; set; }

        /// <remarks/>
        [XmlElementAttribute("Othr")]
        public GenericOrganisationIdentification1 Othr { get; set; }
    }

    /// <remarks/>
    [GeneratedCodeAttribute("xsd", "4.6.1590.0")]
    [SerializableAttribute()]
    [DebuggerStepThroughAttribute()]
    [DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(Namespace = "urn:CBI:xsd:CBIPaymentRequest.00.04.01")]
    public partial class CBIParty1Choice
    {
        /// <remarks/>
        [XmlElementAttribute("OrgId", typeof(CBIOrganisationIdentification2))]
        public CBIOrganisationIdentification2 OrgId { get; set; }

        [XmlElementAttribute("PrvtId", typeof(CBIPersonIdentification1))]
        public CBIPersonIdentification1 PrvtId { get; set; }
        public object Item { get; set; }
    }
    /// <remarks/>
    [GeneratedCodeAttribute("xsd", "4.6.1590.0")]
    [SerializableAttribute()]
    [DebuggerStepThroughAttribute()]
    [DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(Namespace = "urn:CBI:xsd:CBIPaymentRequest.00.04.01")]
    public partial class CBIPartyIdentification3
    {
        /// <remarks/>
        public string Nm { get; set; }

        /// <remarks/>
        public CBIPostalAddress6 PstlAdr { get; set; }

        /// <remarks/>
        public CBIParty1Choice Id { get; set; }

        /// <remarks/>
        public string CtryOfRes { get; set; }
    }

    /// <remarks/>
    [GeneratedCodeAttribute("xsd", "4.6.1590.0")]
    [SerializableAttribute()]
    [DebuggerStepThroughAttribute()]
    [DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(Namespace = "urn:CBI:xsd:CBIPaymentRequest.00.04.01")]
    public partial class CBIFinancialInstitutionIdentification2
    {

        /// <remarks/>
        public string BICFI { get; set; }
    }

    /// <remarks/>
    [GeneratedCodeAttribute("xsd", "4.6.1590.0")]
    [SerializableAttribute()]
    [DebuggerStepThroughAttribute()]
    [DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(Namespace = "urn:CBI:xsd:CBIPaymentRequest.00.04.01")]
    public partial class CBIBranchAndFinancialInstitutionIdentification3
    {

        /// <remarks/>
        public CBIFinancialInstitutionIdentification2 FinInstnId { get; set; }
    }

    /// <remarks/>
    [GeneratedCodeAttribute("xsd", "4.6.1590.0")]
    [SerializableAttribute()]
    [DebuggerStepThroughAttribute()]
    [DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(Namespace = "urn:CBI:xsd:CBIPaymentRequest.00.04.01")]
    public partial class CBICheque1
    {

        /// <remarks/>
        public CBIChequeType1Code ChqTp { get; set; }

        /// <remarks/>
        [XmlIgnoreAttribute()]
        public bool ChqTpSpecified { get; set; }
    }

    /// <remarks/>
    [GeneratedCodeAttribute("xsd", "4.6.1590.0")]
    [SerializableAttribute()]
    [XmlTypeAttribute(Namespace = "urn:CBI:xsd:CBIPaymentRequest.00.04.01")]
    public enum CBIChequeType1Code
    {

        /// <remarks/>
        CCCH,

        /// <remarks/>
        BCHQ,
    }

    /// <remarks/>
    [GeneratedCodeAttribute("xsd", "4.6.1590.0")]
    [SerializableAttribute()]
    [DebuggerStepThroughAttribute()]
    [DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(Namespace = "urn:CBI:xsd:CBIPaymentRequest.00.04.01")]
    public partial class CBIAmountType1
    {

        /// <remarks/>
        public ActiveOrHistoricCurrencyAndAmount InstdAmt { get; set; }
    }

    /// <remarks/>
    [GeneratedCodeAttribute("xsd", "4.6.1590.0")]
    [SerializableAttribute()]
    [DebuggerStepThroughAttribute()]
    [DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(Namespace = "urn:CBI:xsd:CBIPaymentRequest.00.04.01")]
    public partial class CategoryPurpose1Choice
    {

        /// <remarks/>
        public string Cd { get; set; }

        [XmlIgnoreAttribute()]
        public string Prtry { get; set; }
    }

    /// <remarks/>
    [GeneratedCodeAttribute("xsd", "4.6.1590.0")]
    [SerializableAttribute()]
    [XmlTypeAttribute(Namespace = "urn:CBI:xsd:CBIPaymentRequest.00.04.01", IncludeInSchema = false)]
    public enum ItemChoiceType1
    {

        /// <remarks/>
        Cd,

        /// <remarks/>
        Prtry,
    }

    /// <remarks/>
    [GeneratedCodeAttribute("xsd", "4.6.1590.0")]
    [SerializableAttribute()]
    [DebuggerStepThroughAttribute()]
    [DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(Namespace = "urn:CBI:xsd:CBIPaymentRequest.00.04.01")]
    public partial class CBILocalInstrument1
    {

        /// <remarks/>
        public string Prtry { get; set; }
    }

    /// <remarks/>
    [GeneratedCodeAttribute("xsd", "4.6.1590.0")]
    [SerializableAttribute()]
    [DebuggerStepThroughAttribute()]
    [DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(Namespace = "urn:CBI:xsd:CBIPaymentRequest.00.04.01")]
    public partial class CBIServiceLevel2
    {

        /// <remarks/>
        public string Prtry { get; set; }
    }

    /// <remarks/>
    [GeneratedCodeAttribute("xsd", "4.6.1590.0")]
    [SerializableAttribute()]
    [DebuggerStepThroughAttribute()]
    [DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(Namespace = "urn:CBI:xsd:CBIPaymentRequest.00.04.01")]
    public partial class CBIPaymentTypeInformation2
    {

        /// <remarks/>
        public CBIServiceLevel2 SvcLvl { get; set; }

        /// <remarks/>
        public CBILocalInstrument1 LclInstrm { get; set; }

        /// <remarks/>
        public CategoryPurpose1Choice CtgyPurp { get; set; }
    }

    /// <remarks/>
    [GeneratedCodeAttribute("xsd", "4.6.1590.0")]
    [SerializableAttribute()]
    [DebuggerStepThroughAttribute()]
    [DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(Namespace = "urn:CBI:xsd:CBIPaymentRequest.00.04.01")]
    public partial class PaymentIdentification1
    {

        /// <remarks/>
        public string InstrId { get; set; }

        /// <remarks/>
        public string EndToEndId { get; set; }
    }

    /// <remarks/>
    [GeneratedCodeAttribute("xsd", "4.6.1590.0")]
    [SerializableAttribute()]
    [DebuggerStepThroughAttribute()]
    [DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(Namespace = "urn:CBI:xsd:CBIPaymentRequest.00.04.01")]
    public partial class CBICreditTransferTransactionInformation
    {

        /// <remarks/>
        public PaymentIdentification1 PmtId { get; set; }

        /// <remarks/>
        public CBIPaymentTypeInformation2 PmtTpInf { get; set; }

        /// <remarks/>
        public CBIAmountType1 Amt { get; set; }

        /// <remarks/>
        public CBICheque1 ChqInstr { get; set; }

        /// <remarks/>
        public CBIPartyIdentification2 UltmtDbtr { get; set; }

        /// <remarks/>
        public CBISrvInf1 SrvInf { get; set; }

        /// <remarks/>
        [XmlIgnoreAttribute()]
        public bool SrvInfSpecified { get; set; }

        /// <remarks/>
        public CBIBranchAndFinancialInstitutionIdentification3 CdtrAgt { get; set; }

        /// <remarks/>
        public CBIPartyIdentification3 Cdtr { get; set; }

        /// <remarks/>
        public CBICashAccount1 CdtrAcct { get; set; }

        /// <remarks/>
        public CBIPartyIdentification3 UltmtCdtr { get; set; }

        /// <remarks/>
        public CBIPartyIdentification5 DestCdtrRsp { get; set; }

        /// <remarks/>
        public Purpose1Choice Purp { get; set; }

        /// <remarks/>
        [XmlElementAttribute("RgltryRptg")]
        public CBIRegulatoryReporting1[] RgltryRptg { get; set; }

        /// <remarks/>
        [XmlElementAttribute("RltdRmtInf")]
        public CBIRemittanceLocation1[] RltdRmtInf { get; set; }

        /// <remarks/>
        public RemittanceInformation5 RmtInf { get; set; }
    }

    /// <remarks/>
    [GeneratedCodeAttribute("xsd", "4.6.1590.0")]
    [SerializableAttribute()]
    [DebuggerStepThroughAttribute()]
    [DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(Namespace = "urn:CBI:xsd:CBIPaymentRequest.00.04.01")]
    public partial class CBIPartyIdentification2
    {

        /// <remarks/>
        public string Nm { get; set; }

        /// <remarks/>
        public CBIPostalAddress6 PstlAdr { get; set; }

        /// <remarks/>
        public CBIIdType2 Id { get; set; }

        /// <remarks/>
        public string CtryOfRes { get; set; }
    }

    /// <remarks/>
    [GeneratedCodeAttribute("xsd", "4.6.1590.0")]
    [SerializableAttribute()]
    [DebuggerStepThroughAttribute()]
    [DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(Namespace = "urn:CBI:xsd:CBIPaymentRequest.00.04.01")]
    public partial class CBIIdType2
    {
        /// <remarks/>
        public CBIOrganisationIdentification3 OrgId { get; set; }
    }

    /// <remarks/>
    [GeneratedCodeAttribute("xsd", "4.6.1590.0")]
    [SerializableAttribute()]
    [DebuggerStepThroughAttribute()]
    [DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(Namespace = "urn:CBI:xsd:CBIPaymentRequest.00.04.01")]
    public partial class CBIOrganisationIdentification3
    {

        /// <remarks/>
        public CBIGenericIdentification1 Othr { get; set; }
    }

    /// <remarks/>
    [GeneratedCodeAttribute("xsd", "4.6.1590.0")]
    [SerializableAttribute()]
    [XmlTypeAttribute(Namespace = "urn:CBI:xsd:CBIPaymentRequest.00.04.01")]
    public enum CBISrvInf1
    {

        /// <remarks/>
        ESBEN,
    }

    /// <remarks/>
    [GeneratedCodeAttribute("xsd", "4.6.1590.0")]
    [SerializableAttribute()]
    [DebuggerStepThroughAttribute()]
    [DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(Namespace = "urn:CBI:xsd:CBIPaymentRequest.00.04.01")]
    public partial class CBICashAccount1
    {
        /// <remarks/>
        public CBIAccountIdentification1 Id { get; set; }
    }

    /// <remarks/>
    [GeneratedCodeAttribute("xsd", "4.6.1590.0")]
    [SerializableAttribute()]
    [DebuggerStepThroughAttribute()]
    [DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(Namespace = "urn:CBI:xsd:CBIPaymentRequest.00.04.01")]
    public partial class CBIAccountIdentification1
    {

        /// <remarks/>
        public string IBAN { get; set; }
    }

    /// <remarks/>
    [GeneratedCodeAttribute("xsd", "4.6.1590.0")]
    [SerializableAttribute()]
    [DebuggerStepThroughAttribute()]
    [DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(Namespace = "urn:CBI:xsd:CBIPaymentRequest.00.04.01")]
    public partial class CBIFinancialInstitutionIdentification3
    {
        /// <remarks/>
        public string BIC { get; set; }

        /// <remarks/>
        public CBIClearingSystemMemberIdentification1 ClrSysMmbId { get; set; }
    }

    /// <remarks/>
    [GeneratedCodeAttribute("xsd", "4.6.1590.0")]
    [SerializableAttribute()]
    [DebuggerStepThroughAttribute()]
    [DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(Namespace = "urn:CBI:xsd:CBIPaymentRequest.00.04.01")]
    public partial class CBIClearingSystemMemberIdentification1
    {

        /// <remarks/>
        public string MmbId { get; set; }
    }

    /// <remarks/>
    [GeneratedCodeAttribute("xsd", "4.6.1590.0")]
    [SerializableAttribute()]
    [DebuggerStepThroughAttribute()]
    [DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(Namespace = "urn:CBI:xsd:CBIPaymentRequest.00.04.01")]
    public partial class CBIBranchAndFinancialInstitutionIdentification2
    {

        /// <remarks/>
        public CBIFinancialInstitutionIdentification3 FinInstnId { get; set; }
    }

    /// <remarks/>
    [GeneratedCodeAttribute("xsd", "4.6.1590.0")]
    [SerializableAttribute()]
    [DebuggerStepThroughAttribute()]
    [DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(Namespace = "urn:CBI:xsd:CBIPaymentRequest.00.04.01")]
    public partial class CashAccountType2Choice
    {

        /// <remarks/>
        [XmlElementAttribute("Cd", typeof(string))]
        [XmlElementAttribute("Prtry", typeof(string))]
        [XmlChoiceIdentifierAttribute("ItemElementName")]
        public string Item { get; set; }

        /// <remarks/>
        [XmlIgnoreAttribute()]
        public ItemChoiceType ItemElementName { get; set; }
    }

    /// <remarks/>
    [GeneratedCodeAttribute("xsd", "4.6.1590.0")]
    [SerializableAttribute()]
    [XmlTypeAttribute(Namespace = "urn:CBI:xsd:CBIPaymentRequest.00.04.01", IncludeInSchema = false)]
    public enum ItemChoiceType
    {

        /// <remarks/>
        Cd,

        /// <remarks/>
        Prtry,
    }

    /// <remarks/>
    [GeneratedCodeAttribute("xsd", "4.6.1590.0")]
    [SerializableAttribute()]
    [DebuggerStepThroughAttribute()]
    [DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(Namespace = "urn:CBI:xsd:CBIPaymentRequest.00.04.01")]
    public partial class CBICashAccount2
    {

        /// <remarks/>
        public CBIAccountIdentification1 Id { get; set; }

        /// <remarks/>
        public CashAccountType2Choice Tp { get; set; }
    }

    /// <remarks/>
    [GeneratedCodeAttribute("xsd", "4.6.1590.0")]
    [SerializableAttribute()]
    [DebuggerStepThroughAttribute()]
    [DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(Namespace = "urn:CBI:xsd:CBIPaymentRequest.00.04.01")]
    public partial class CBIPartyIdentification4
    {

        /// <remarks/>
        public string Nm { get; set; }

        /// <remarks/>
        public CBIPostalAddress24 PstlAdr { get; set; }

        /// <remarks/>
        public CBIIdType2 Id { get; set; }

        /// <remarks/>
        public string CtryOfRes { get; set; }
    }

    /// <remarks/>
    [GeneratedCodeAttribute("xsd", "4.6.1590.0")]
    [SerializableAttribute()]
    [DebuggerStepThroughAttribute()]
    [DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(Namespace = "urn:CBI:xsd:CBIPaymentRequest.00.04.01")]
    public partial class CBILocalInstrument2
    {

        /// <remarks/>
        public string Cd { get; set; }
    }

    /// <remarks/>
    [GeneratedCodeAttribute("xsd", "4.6.1590.0")]
    [SerializableAttribute()]
    [DebuggerStepThroughAttribute()]
    [DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(Namespace = "urn:CBI:xsd:CBIPaymentRequest.00.04.01")]
    public partial class CBIServiceLevel1
    {
        /// <remarks/>
        public CBIServiceLevel1Code Cd { get; set; }
    }

    /// <remarks/>
    [GeneratedCodeAttribute("xsd", "4.6.1590.0")]
    [SerializableAttribute()]
    [XmlTypeAttribute(Namespace = "urn:CBI:xsd:CBIPaymentRequest.00.04.01")]
    public enum CBIServiceLevel1Code
    {

        /// <remarks/>
        SEPA,

        /// <remarks/>
        URGP,

        /// <remarks/>
        FAST,

        /// <remarks/>
        PGPA,

        /// <remarks/>
        PGSP,
    }

    /// <remarks/>
    [GeneratedCodeAttribute("xsd", "4.6.1590.0")]
    [SerializableAttribute()]
    [DebuggerStepThroughAttribute()]
    [DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(Namespace = "urn:CBI:xsd:CBIPaymentRequest.00.04.01")]
    public partial class CBIPaymentTypeInformation1
    {
        /// <remarks/>
        public Priority2Code InstrPrty { get; set; }

        /// <remarks/>
        [XmlIgnoreAttribute()]
        public bool InstrPrtySpecified { get; set; }

        /// <remarks/>
        public CBIServiceLevel1 SvcLvl { get; set; }

        /// <remarks/>
        public CBILocalInstrument2 LclInstrm { get; set; }
    }

    /// <remarks/>
    [GeneratedCodeAttribute("xsd", "4.6.1590.0")]
    [SerializableAttribute()]
    [XmlTypeAttribute(Namespace = "urn:CBI:xsd:CBIPaymentRequest.00.04.01")]
    public enum Priority2Code
    {

        /// <remarks/>
        HIGH,

        /// <remarks/>
        NORM,
    }

    /// <remarks/>
    [GeneratedCodeAttribute("xsd", "4.6.1590.0")]
    [SerializableAttribute()]
    [DebuggerStepThroughAttribute()]
    [DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(Namespace = "urn:CBI:xsd:CBIPaymentRequest.00.04.01")]
    public partial class CBIPaymentInstructionInformation
    {

        /// <remarks/>
        public string PmtInfId { get; set; }

        /// <remarks/>
        public PaymentMethod3Code PmtMtd { get; set; }

        /// <remarks/>
        public bool BtchBookg { get; set; }

        /// <remarks/>
        [XmlIgnoreAttribute()]
        public bool BtchBookgSpecified { get; set; }

        /// <remarks/>
        public CBIPaymentTypeInformation1 PmtTpInf { get; set; }

        /// <remarks/>
        public DateAndDateTime2Choice ReqdExctnDt { get; set; }

        /// <remarks/>
        public CBIPartyIdentification4 Dbtr { get; set; }

        /// <remarks/>
        public CBICashAccount2 DbtrAcct { get; set; }

        /// <remarks/>
        public CBIBranchAndFinancialInstitutionIdentification2 DbtrAgt { get; set; }

        /// <remarks/>
        public CBIPartyIdentification2 UltmtDbtr { get; set; }

        /// <remarks/>
        public CBIChargeBearerTypeCode ChrgBr { get; set; }

        /// <remarks/>
        public CBICashAccount1 ChrgsAcct { get; set; }

        /// <remarks/>
        [XmlElementAttribute("CdtTrfTxInf")]
        public CBICreditTransferTransactionInformation[] CdtTrfTxInf { get; set; }
    }

    /// <remarks/>
    [GeneratedCodeAttribute("xsd", "4.6.1590.0")]
    [SerializableAttribute()]
    [XmlTypeAttribute(Namespace = "urn:CBI:xsd:CBIPaymentRequest.00.04.01")]
    public enum PaymentMethod3Code
    {

        /// <remarks/>
        CHK,

        /// <remarks/>
        TRF,

        /// <remarks/>
        TRA,
    }

    /// <remarks/>
    [GeneratedCodeAttribute("xsd", "4.6.1590.0")]
    [SerializableAttribute()]
    [XmlTypeAttribute(Namespace = "urn:CBI:xsd:CBIPaymentRequest.00.04.01")]
    public enum CBIChargeBearerTypeCode
    {

        /// <remarks/>
        SLEV,
        /// <remarks/>
        SHAR,
        /// <remarks/>
        XXXX,
    }

    /// <remarks/>
    [GeneratedCodeAttribute("xsd", "4.6.1590.0")]
    [SerializableAttribute()]
    [DebuggerStepThroughAttribute()]
    [DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(Namespace = "urn:CBI:xsd:CBIPaymentRequest.00.04.01")]
    public partial class CBIFinancialInstitutionIdentification1
    {

        /// <remarks/>
        public CBIClearingSystemMemberIdentification1 ClrSysMmbId { get; set; }
    }

    /// <remarks/>
    [GeneratedCodeAttribute("xsd", "4.6.1590.0")]
    [SerializableAttribute()]
    [DebuggerStepThroughAttribute()]
    [DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(Namespace = "urn:CBI:xsd:CBIPaymentRequest.00.04.01")]
    public partial class CBIBranchAndFinancialInstitutionIdentification1
    {

        /// <remarks/>
        public CBIFinancialInstitutionIdentification1 FinInstnId { get; set; }
    }

}
