
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


 using System.Collections;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Xml.Serialization;
    
    


namespace IntesaSanPaolo
{
    [System.CodeDom.Compiler.GeneratedCodeAttribute("XmlSchemaClassGenerator", "2.0.210.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute("RendicontaPlus", Namespace = "", AnonymousType = true)]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlRootAttribute("RendicontaPlus", Namespace = "")]
    public class RendicontaPlus
	{
        [System.Xml.Serialization.XmlElementAttribute("identificativoDominio", Namespace = "")]
        public string IdentificativoDominio { get; set; }

        [System.Xml.Serialization.XmlElementAttribute("identificativoUB", Namespace = "")]
        public string IdentificativoUB { get; set; }

        [System.Xml.Serialization.XmlElementAttribute("denominazioneUB", Namespace = "")]
        public string DenominazioneUB { get; set; }

        [System.Xml.Serialization.XmlIgnoreAttribute()]
        private System.Collections.ObjectModel.Collection<RendicontaPlusRicevutaTelematica> _ricevutaTelematica;

        [System.Xml.Serialization.XmlElementAttribute("ricevutaTelematica", Namespace = "")]
        public System.Collections.ObjectModel.Collection<RendicontaPlusRicevutaTelematica> RicevutaTelematica {
            get
            {
                return this._ricevutaTelematica;
            }
            private set
            {
                this._ricevutaTelematica = value;
            }
        }

        public RendicontaPlus() {
            this._ricevutaTelematica = new System.Collections.ObjectModel.Collection<RendicontaPlusRicevutaTelematica>();
        }
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("XmlSchemaClassGenerator", "2.0.210.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute("RendicontaPlusRicevutaTelematica", Namespace = "", AnonymousType = true)]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class RendicontaPlusRicevutaTelematica
    {

        [System.Xml.Serialization.XmlElementAttribute("identificativoUnivocoVersamento", Namespace = "")]
        public string IdentificativoUnivocoVersamento { get; set; }

        [System.Xml.Serialization.XmlElementAttribute("idTenant", Namespace = "")]
        public string IdTenant { get; set; }

        [System.Xml.Serialization.XmlElementAttribute("dataEsecuzionePagamento", Namespace = "")]
        public System.DateTime DataEsecuzionePagamento { get; set; }

        [System.Xml.Serialization.XmlElementAttribute("dataInvioRt", Namespace = "")]
        public System.DateTime DataInvioRt { get; set; }

        [System.Xml.Serialization.XmlElementAttribute("firmaRicevuta", Namespace = "")]
        public string FirmaRicevuta { get; set; }

        [System.Xml.Serialization.XmlElementAttribute("codiceContestoPagamento", Namespace = "")]
        public string CodiceContestoPagamento { get; set; }

        [System.Xml.Serialization.XmlElementAttribute("codiceEsitoPagamento", Namespace = "")]
        public string CodiceEsitoPagamento { get; set; }

        [System.Xml.Serialization.XmlElementAttribute("tipoIdentificativoUnivocoAttestante", Namespace = "")]
        public string TipoIdentificativoUnivocoAttestante { get; set; }

        [System.Xml.Serialization.XmlElementAttribute("codiceIdentificativoUnivocoAttestante", Namespace = "")]
        public string CodiceIdentificativoUnivocoAttestante { get; set; }

        [System.Xml.Serialization.XmlElementAttribute("denominazioneAttestante", Namespace = "")]
        public string DenominazioneAttestante { get; set; }

        [System.Xml.Serialization.XmlElementAttribute("tipoIdentificativoUnivocoPagatore", Namespace = "")]
        public string TipoIdentificativoUnivocoPagatore { get; set; }

        [System.Xml.Serialization.XmlElementAttribute("codiceIdentificativoUnivocoPagatore", Namespace = "")]
        public string CodiceIdentificativoUnivocoPagatore { get; set; }

        [System.Xml.Serialization.XmlElementAttribute("anagraficaPagatore", Namespace = "")]
        public string AnagraficaPagatore { get; set; }

        [System.Xml.Serialization.XmlElementAttribute("capPagatore", Namespace = "")]
        public string CapPagatore { get; set; }

        [System.Xml.Serialization.XmlElementAttribute("civicoPagatore", Namespace = "")]
        public string CivicoPagatore { get; set; }

        [System.Xml.Serialization.XmlElementAttribute("emailPagatore", Namespace = "")]
        public string EmailPagatore { get; set; }

        [System.Xml.Serialization.XmlElementAttribute("indirizzoPagatore", Namespace = "")]
        public string IndirizzoPagatore { get; set; }

        [System.Xml.Serialization.XmlElementAttribute("localitaPagatore", Namespace = "")]
        public string LocalitaPagatore { get; set; }

        [System.Xml.Serialization.XmlElementAttribute("nazionePagatore", Namespace = "")]
        public string NazionePagatore { get; set; }

        [System.Xml.Serialization.XmlElementAttribute("provinciaPagatore", Namespace = "")]
        public string ProvinciaPagatore { get; set; }

        [System.Xml.Serialization.XmlElementAttribute("codiceIdentificativoUnivocoBeneficiario", Namespace = "")]
        public string CodiceIdentificativoUnivocoBeneficiario { get; set; }

        [System.Xml.Serialization.XmlElementAttribute("tipoIdentificativoUnivocoBeneficiario", Namespace = "")]
        public string TipoIdentificativoUnivocoBeneficiario { get; set; }

        [System.Xml.Serialization.XmlElementAttribute("denominazioneBeneficiario", Namespace = "")]
        public string DenominazioneBeneficiario { get; set; }

        [System.Xml.Serialization.XmlElementAttribute("importoTotaleDaVersare", Namespace = "")]
        public decimal ImportoTotaleDaVersare { get; set; }

        [System.Xml.Serialization.XmlElementAttribute("dataMulta", Namespace = "")]
        public string DataMulta { get; set; }

        [System.Xml.Serialization.XmlElementAttribute("oraMulta", Namespace = "")]
        public string OraMulta { get; set; }

        [System.Xml.Serialization.XmlElementAttribute("targa", Namespace = "")]
        public string Targa { get; set; }

        [System.Xml.Serialization.XmlElementAttribute("codiceViolazione", Namespace = "")]
        public string CodiceViolazione { get; set; }

        [System.Xml.Serialization.XmlElementAttribute("tipoVerbale", Namespace = "")]
        public string TipoVerbale { get; set; }

        [System.Xml.Serialization.XmlElementAttribute("numeroVerbale", Namespace = "")]
        public string NumeroVerbale { get; set; }

        [System.Xml.Serialization.XmlIgnoreAttribute()]
        private System.Collections.ObjectModel.Collection<RendicontaPlusRicevutaTelematicaDatiSingoloPagamento> _datiSingoloPagamento;

        [System.Xml.Serialization.XmlElementAttribute("datiSingoloPagamento", Namespace = "")]
        public System.Collections.ObjectModel.Collection<RendicontaPlusRicevutaTelematicaDatiSingoloPagamento> DatiSingoloPagamento {
            get
            {
                return this._datiSingoloPagamento;
            }
            private set
            {
                this._datiSingoloPagamento = value;
            }
        }

        public RendicontaPlusRicevutaTelematica() {
            this._datiSingoloPagamento = new System.Collections.ObjectModel.Collection<RendicontaPlusRicevutaTelematicaDatiSingoloPagamento>();
        }
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("XmlSchemaClassGenerator", "2.0.210.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute("RendicontaPlusRicevutaTelematicaDatiSingoloPagamento", Namespace = "", AnonymousType = true)]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class RendicontaPlusRicevutaTelematicaDatiSingoloPagamento
    {

        [System.Xml.Serialization.XmlElementAttribute("importoSingoloVersamento", Namespace = "")]
        public decimal ImportoSingoloVersamento { get; set; }

        [System.Xml.Serialization.XmlElementAttribute("causaleVersamento", Namespace = "")]
        public string CausaleVersamento { get; set; }

        [System.Xml.Serialization.XmlElementAttribute("tipoDatiSpecificiRiscossione", Namespace = "")]
        public string TipoDatiSpecificiRiscossione { get; set; }

        [System.Xml.Serialization.XmlElementAttribute("datiSpecificiRiscossione", Namespace = "")]
        public string DatiSpecificiRiscossione { get; set; }

        [System.Xml.Serialization.XmlElementAttribute("identUnivocoRiscossione", Namespace = "")]
        public string IdentUnivocoRiscossione { get; set; }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Xml.Serialization.XmlElementAttribute("ordinePagamento", Namespace = "")]
        public int OrdinePagamentoValue { get; set; }

        [System.Xml.Serialization.XmlIgnoreAttribute()]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public bool OrdinePagamentoValueSpecified { get; set; }

        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public System.Nullable<int> OrdinePagamento {
            get
            {
                if (this.OrdinePagamentoValueSpecified) {
                    return this.OrdinePagamentoValue;
                }
                else {
                    return null;
                }
            }
            set
            {
                this.OrdinePagamentoValue = value.GetValueOrDefault();
                this.OrdinePagamentoValueSpecified = value.HasValue;
            }
        }

        [System.Xml.Serialization.XmlElementAttribute("idFlusso", Namespace = "")]
        public string IdFlusso { get; set; }

        [System.Xml.Serialization.XmlElementAttribute("identificativoUnivocoRegolamento", Namespace = "")]
        public string IdentificativoUnivocoRegolamento { get; set; }

        [System.Xml.Serialization.XmlElementAttribute("dataRegolamento", Namespace = "")]
        public System.DateTime DataRegolamento { get; set; }

        [System.Xml.Serialization.XmlElementAttribute("capitoloDiBilancio", Namespace = "")]
        public string CapitoloDiBilancio { get; set; }

        [System.Xml.Serialization.XmlElementAttribute("provvisorioEntrata", Namespace = "")]
        public string ProvvisorioEntrata { get; set; }

        [System.Xml.Serialization.XmlElementAttribute("ibanAccredito", Namespace = "")]
        public string IbanAccredito { get; set; }

        [System.Xml.Serialization.XmlElementAttribute("tipoVersamento", Namespace = "")]
        public string TipoVersamento { get; set; }

        [System.Xml.Serialization.XmlElementAttribute("codiceTributo", Namespace = "")]
        public string CodiceTributo { get; set; }
    }
}
