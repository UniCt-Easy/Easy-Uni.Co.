
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
using System.Runtime.Serialization;
using System.Collections.ObjectModel;

#region "Strutture dati (InfoGroup)"

namespace InfoGroup {

    [DataContract(Name = "ct0000000028_pdpRichiediAvviso", Namespace = "http://generatedsource.dp.webservice.intermediariopa.infogroup.it/")]
    public class ct0000000028_pdpRichiediAvviso {
        [DataMember(IsRequired = true, EmitDefaultValue = false)]
        public string identificativoUnivocoVersamento { get; set; }
    }

    [DataContract(Name = "ct0000000028_pdpRichiediAvvisoResult", Namespace = "http://generatedsource.dp.webservice.intermediariopa.infogroup.it/")]
    public class ct0000000028_pdpRichiediAvvisoResult {
        [DataMember(IsRequired = true, EmitDefaultValue = false)]
        public string esitoOperazione { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 1)]
        public string codiceErrore { get; set; }

        [DataMember(IsRequired = true, EmitDefaultValue = false, Order = 2)]
        public string identificativoUnivocoVersamento { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 3)]
        public string codiceContestoPagamento { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 4)]
        public ct0000000028_datiRestituiti datiRestituiti { get; set; }
    }

    [DataContract(Name = "ct0000000028_datiRestituiti", Namespace = "http://generatedsource.dp.webservice.intermediariopa.infogroup.it/")]
    public class ct0000000028_datiRestituiti {
        [DataMember(IsRequired = true, EmitDefaultValue = false)]
        public string pdfFile { get; set; }
    }

    [DataContract(Name = "ct0000000002_pdpGeneraIUVResult", Namespace = "http://generatedsource.dp.webservice.intermediariopa.infogroup.it/")]
    public class ct0000000002_pdpGeneraIUVResult {
        [DataMember(IsRequired = true, EmitDefaultValue = false)]
        public string esitoOperazione { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 1)]
        public string codiceErrore { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 2)]
        public ct0000000002_datiRestituiti datiRestituiti { get; set; }
    }

    [DataContract(Name = "ct0000000002_datiRestituiti", Namespace = "http://generatedsource.dp.webservice.intermediariopa.infogroup.it/")]
    public class ct0000000002_datiRestituiti {
        [DataMember(IsRequired = true, EmitDefaultValue = false)]
        public string identificativoUnivocoVersamento { get; set; }
    }

    [DataContract(Name = "ct0000000003_datiMarcaBolloDigitale", Namespace = "http://generatedsource.dp.webservice.intermediariopa.infogroup.it/")]
    public class ct0000000003_datiMarcaBolloDigitale {

        [DataMember(IsRequired = true, EmitDefaultValue = false)]
        public string hashDocumento { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string provinciaResidenzaPagatore { get; set; }
    }


 

    [DataContract(Name = "ct0000000003_soggettoPagatore", Namespace = "http://generatedsource.dp.webservice.intermediariopa.infogroup.it/")]
    public class ct0000000003_soggettoPagatore {

        [DataMember(EmitDefaultValue = false)]
        public string tipoIdentificativoUnivocoPagatore { get; set; }

        [DataMember(IsRequired = true, EmitDefaultValue = false, Order = 1)]
        public string codiceIdentificativoUnivocoPagatore { get; set; }

        [DataMember(IsRequired = true, EmitDefaultValue = false, Order = 2)]
        public string anagraficaPagatore { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 3)]
        public string indirizzoPagatore { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 4)]
        public string civicoPagatore { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 5)]
        public string capPagatore { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 6)]
        public string localitaPagatore { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 7)]
        public string provinciaPagatore { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 8)]
        public string nazionePagatore { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 9)]
        public string emailPagatore { get; set; }
    }

    [DataContract(Name = "ct0000000003_datiSingoloVersamento", Namespace = "http://generatedsource.dp.webservice.intermediariopa.infogroup.it/")]
    public class ct0000000003_datiSingoloVersamento {
        [DataMember(IsRequired = true, EmitDefaultValue = false)]
        public string identificativoServizio { get; set; }

        [DataMember(IsRequired = true)]
        public decimal importoSingoloVersamento { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 2)]
        public string credenzialiPagatore { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 3)]
        public string descrizioneTestualeCausaleVersamento { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 4)]
        public ct0000000003_datiMarcaBolloDigitale datiMarcaBolloDigitale { get; set; }
    }

    [DataContract(Name = "ct0000000003_notificaCallback", Namespace = "http://generatedsource.dp.webservice.intermediariopa.infogroup.it/")]
    public class ct0000000003_notificaCallback {
        [DataMember(IsRequired = true, EmitDefaultValue = false)]
        public string callbackURL { get; set; }

        [DataMember(IsRequired = true, EmitDefaultValue = false)]
        public string callbackUsername { get; set; }

        [DataMember(IsRequired = true, EmitDefaultValue = false, Order = 2)]
        public string callbackPassword { get; set; }
    }


    [DataContract(Name = "ct0000000003_datiPagamentoInAttesaPagabileSeScaduto", Namespace = "http://generatedsource.dp.webservice.intermediariopa.infogroup.it/")]
    public enum ct0000000003_datiPagamentoInAttesaPagabileSeScaduto {

        [EnumMember]
        Item0,

        [EnumMember]
        Item1,
    }

    [DataContract(Name = "ct0000000003_datiPagamentoInAttesa", Namespace = "http://generatedsource.dp.webservice.intermediariopa.infogroup.it/")]
    public class ct0000000003_datiPagamentoInAttesa {
        [DataMember(EmitDefaultValue = false)]
        public DateTime dataScadenzaPagamento { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public ct0000000003_datiPagamentoInAttesaPagabileSeScaduto pagabileSeScaduto { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 2)]
        public string identificativoUnivocoVersamento { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 3)]
        public string id_tenant { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 4)]
        public ct0000000003_notificaCallback notificaCallback { get; set; }

        [DataMember(IsRequired = true, EmitDefaultValue = false, Order = 5)]
        public ct0000000003_soggettoPagatore soggettoPagatore { get; set; }

        [DataMember(IsRequired = true, Order = 6)]
        public decimal importoTotaleDaVersare { get; set; }

        [DataMember(IsRequired = true, EmitDefaultValue = false, Order = 7)]
        public string causaleVersamentoEsplicitaPSP { get; set; }

        [DataMember(IsRequired = true, EmitDefaultValue = false, Order = 8)]
        public ct0000000003_datiSingoloVersamento datiSingoloVersamento { get; set; } //Gestiamo un solo versamento per pagamento
    }

    [DataContract(Name = "ct0000000003_pdpCaricaPagamentoInAttesaModalita", Namespace = "http://generatedsource.dp.webservice.intermediariopa.infogroup.it/")]
    public enum ct0000000003_pdpCaricaPagamentoInAttesaModalita {

        [EnumMember]
        INS,

        [EnumMember]
        MOD,

        [EnumMember]
        INV,
    }


    [DataContract(Name = "ct0000000003_pdpCaricaPagamentoInAttesa", Namespace = "http://generatedsource.dp.webservice.intermediariopa.infogroup.it/")]
    public class ct0000000003_pdpCaricaPagamentoInAttesa {

        [DataMember(IsRequired = true, EmitDefaultValue = true)]
        public ct0000000003_pdpCaricaPagamentoInAttesaModalita modalita { get; set; }

        [DataMember(IsRequired = true, EmitDefaultValue = false, Order = 1)]
        public ct0000000003_datiPagamentoInAttesa datiPagamentoInAttesa { get; set; }
    }

    [DataContract(Name = "ct0000000004_pdpCaricaPagamentoInAttesaResult", Namespace = "http://generatedsource.dp.webservice.intermediariopa.infogroup.it/")]
    public class ct0000000004_pdpCaricaPagamentoInAttesaResult {
        [DataMember(IsRequired = true, EmitDefaultValue = false)]
        public string esitoOperazione { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 1)]
        public string codiceErrore { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 2)]
        public ct0000000004_datiRestituiti datiRestituiti { get; set; }
    }

    [DataContract(Name = "ct0000000004_datiRestituiti", Namespace = "http://generatedsource.dp.webservice.intermediariopa.infogroup.it/")]
    public class ct0000000004_datiRestituiti {

        [DataMember(IsRequired = true, EmitDefaultValue = false)]
        public string identificativoUnivocoVersamento { get; set; }

        [DataMember(IsRequired = true, EmitDefaultValue = false, Order = 1)]
        public string idTenant { get; set; }
    }

    [DataContract(Name = "ct0000000005_pdpCancellaPagamentoInAttesa", Namespace = "http://generatedsource.dp.webservice.intermediariopa.infogroup.it/")]
    public class ct0000000005_pdpCancellaPagamentoInAttesa {
        [DataMember(IsRequired = true, EmitDefaultValue = false)]
        public string identificativoUnivocoVersamento { get; set; }
    }

    [DataContract(Name = "ct0000000006_pdpCancellaPagamentoInAttesaResult", Namespace = "http://generatedsource.dp.webservice.intermediariopa.infogroup.it/")]
    public class ct0000000006_pdpCancellaPagamentoInAttesaResult {

        [DataMember(IsRequired = true, EmitDefaultValue = false)]
        public string esitoOperazione { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 1)]
        public string codiceErrore { get; set; }
    }

    [DataContract(Name = "ct0000000007_datiMarcaBolloDigitale", Namespace = "http://generatedsource.dp.webservice.intermediariopa.infogroup.it/")]
    public class ct0000000007_datiMarcaBolloDigitale {

        [DataMember(IsRequired = true, EmitDefaultValue = false)]
        public string hashDocumento { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string provinciaResidenzaPagatore { get; set; }
    }

    [DataContract(Name = "ct0000000007_soggettoPagatore", Namespace = "http://generatedsource.dp.webservice.intermediariopa.infogroup.it/")]
    public class ct0000000007_soggettoPagatore {

        [DataMember(EmitDefaultValue = false)]
        public string tipoIdentificativoUnivocoPagatore { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 1)]
        public string codiceIdentificativoUnivocoPagatore { get; set; }

        [DataMember(IsRequired = true, EmitDefaultValue = false, Order = 2)]
        public string anagraficaPagatore { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 3)]
        public string indirizzoPagatore { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 4)]
        public string civicoPagatore { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 5)]
        public string capPagatore { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 6)]
        public string localitaPagatore { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 7)]
        public string provinciaPagatore { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 8)]
        public string nazionePagatore { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 9)]
        public string emailPagatore { get; set; }
    }

    [DataContract(Name = "ct0000000007_soggettoVersante", Namespace = "http://generatedsource.dp.webservice.intermediariopa.infogroup.it/")]
    public class ct0000000007_soggettoVersante {

        [DataMember(EmitDefaultValue = false)]
        public string tipoIdentificativoUnivocoVersante { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 1)]
        public string codiceIdentificativoUnivocoVersante { get; set; }

        [DataMember(IsRequired = true, EmitDefaultValue = false, Order = 2)]
        public string anagraficaVersante { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 3)]
        public string indirizzoVersante { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 4)]
        public string civicoVersante { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 5)]
        public string capVersante { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 6)]
        public string localitaVersante { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 7)]
        public string provinciaVersante { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 8)]
        public string nazioneVersante { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 9)]
        public string emailVersante { get; set; }
    }

    [DataContract(Name = "ct0000000007_datiSingoloVersamento", Namespace = "http://generatedsource.dp.webservice.intermediariopa.infogroup.it/")]
    public class ct0000000007_datiSingoloVersamento {
        [DataMember(IsRequired = true)]
        public long identificativoServizio { get; set; }

        [DataMember(IsRequired = true)]
        public decimal importoSingoloVersamento { get; set; }

        [DataMember(Order = 2)]
        public decimal commissioneCaricoPA { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 3)]
        public string credenzialiPagatore { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 4)]
        public string descrizioneTestualeCausaleVersamento { get; set; }

        [DataMember(IsRequired = true, EmitDefaultValue = false, Order = 5)]
        public string causaleVersamentoEsplicitaPSP { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 6)]
        public ct0000000007_datiMarcaBolloDigitale datiMarcaBolloDigitale { get; set; }
    }

    [DataContract(Name = "ct0000000007_notificaCallback", Namespace = "http://generatedsource.dp.webservice.intermediariopa.infogroup.it/")]
    public class ct0000000007_notificaCallback {
        [DataMember(IsRequired = true, EmitDefaultValue = false)]
        public string callbackURL { get; set; }

        [DataMember(IsRequired = true, EmitDefaultValue = false)]
        public string callbackUsername { get; set; }

        [DataMember(IsRequired = true, EmitDefaultValue = false, Order = 2)]
        public string callbackPassword { get; set; }
    }

    [DataContract(Name = "ct0000000007_parametriPSP", Namespace = "http://generatedsource.dp.webservice.intermediariopa.infogroup.it/")]
    public class ct0000000007_parametriPSP {
        [DataMember(IsRequired = true, EmitDefaultValue = false)]
        public string identificativoPSP { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 1)]
        public string identificativoIntermediarioPSP { get; set; }

        [DataMember(IsRequired = true, EmitDefaultValue = false, Order = 2)]
        public string identificativoCanale { get; set; }
    }

    [DataContract(Name = "ct0000000007_datiPagamentoInAttesa", Namespace = "http://generatedsource.dp.webservice.intermediariopa.infogroup.it/")]
    public class ct0000000007_datiPagamentoInAttesa {
        [DataMember(EmitDefaultValue = false)]
        public string dataScadenzaPagamento { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string identificativoUnivocoVersamento { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 2)]
        public string codiceContestoPagamento { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 3)]
        public string ibanAddebito { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 4)]
        public string bicAddebito { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 5)]
        public ct0000000007_notificaCallback notificaCallback { get; set; }

        [DataMember(IsRequired = true, EmitDefaultValue = false, Order = 6)]
        public ct0000000007_soggettoPagatore soggettoPagatore { get; set; }

        [DataMember(IsRequired = true, Order = 7)]
        public decimal importoTotaleDaVersare { get; set; }

        [DataMember(IsRequired = true, EmitDefaultValue = false, Order = 8)]
        public string autenticazioneSoggetto { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 9)]
        public ct0000000007_soggettoVersante soggettoVersante { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 10)]
        public ct0000000007_datiSingoloVersamento datiSingoloVersamento { get; set; }
    }

    [DataContract(Name = "ct0000000007_pdpGeneraRPT", Namespace = "http://generatedsource.dp.webservice.intermediariopa.infogroup.it/")]
    public class ct0000000007_pdpGeneraRPT {

        [DataMember(EmitDefaultValue = false)]
        public string identificativoStazioneRichiedente { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string tipoVersamento { get; set; }

        [DataMember(IsRequired = true, EmitDefaultValue = false, Order = 2)]
        public ct0000000007_parametriPSP parametriPSP { get; set; }

        [DataMember(IsRequired = true, EmitDefaultValue = false, Order = 3)]
        public ct0000000007_datiPagamentoInAttesa datiPagamentoInAttesa { get; set; }
    }

    [DataContract(Name = "ct0000000008_pdpGeneraRPTResult", Namespace = "http://generatedsource.dp.webservice.intermediariopa.infogroup.it/")]
    public class ct0000000008_pdpGeneraRPTResult {
        [DataMember(IsRequired = true, EmitDefaultValue = false)]
        public string esitoOperazione { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 1)]
        public string codiceErrore { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 2)]
        public ct0000000008_datiRestituiti datiRestituiti { get; set; }
    }

    [DataContract(Name = "ct0000000008_datiRestituiti", Namespace = "http://generatedsource.dp.webservice.intermediariopa.infogroup.it/")]
    public class ct0000000008_datiRestituiti {
        [DataMember(IsRequired = true, EmitDefaultValue = false)]
        public string identificativoUnivocoVersamento { get; set; }

        [DataMember(IsRequired = true)]
        public long pspSupportaRedirect { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string redirectURL { get; set; }
    }

    [DataContract(Name = "ct0000000009_soggettoVersante", Namespace = "http://generatedsource.dp.webservice.intermediariopa.infogroup.it/")]
    public class ct0000000009_soggettoVersante {

        [DataMember(EmitDefaultValue = false)]
        public string tipoIdentificativoUnivocoVersante { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 1)]
        public string codiceIdentificativoUnivocoVersante { get; set; }

        [DataMember(IsRequired = true, EmitDefaultValue = false, Order = 2)]
        public string anagraficaVersante { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 3)]
        public string indirizzoVersante { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 4)]
        public string civicoVersante { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 5)]
        public string capVersante { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 6)]
        public string localitaVersante { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 7)]
        public string provinciaVersante { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 8)]
        public string nazioneVersante { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 9)]
        public string emailVersante { get; set; }
    }

    [DataContract(Name = "ct0000000009_datiSingoloVersamento", Namespace = "http://generatedsource.dp.webservice.intermediariopa.infogroup.it/")]
    public class ct0000000009_datiSingoloVersamento {
        [DataMember()]
        public decimal commissioneCaricoPA { get; set; }
    }

    [DataContract(Name = "ct0000000009_notificaCallback", Namespace = "http://generatedsource.dp.webservice.intermediariopa.infogroup.it/")]
    public class ct0000000009_notificaCallback {
        [DataMember(IsRequired = true, EmitDefaultValue = false)]
        public string callbackURL { get; set; }

        [DataMember(IsRequired = true, EmitDefaultValue = false)]
        public string callbackUsername { get; set; }

        [DataMember(IsRequired = true, EmitDefaultValue = false, Order = 2)]
        public string callbackPassword { get; set; }
    }

    [DataContract(Name = "ct0000000009_parametriPSP", Namespace = "http://generatedsource.dp.webservice.intermediariopa.infogroup.it/")]
    public class ct0000000009_parametriPSP {
        [DataMember(IsRequired = true, EmitDefaultValue = false)]
        public string identificativoPSP { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 1)]
        public string identificativoIntermediarioPSP { get; set; }

        [DataMember(IsRequired = true, EmitDefaultValue = false, Order = 2)]
        public string identificativoCanale { get; set; }
    }

    [DataContract(Name = "ct0000000009_datiPagamentoInAttesa", Namespace = "http://generatedsource.dp.webservice.intermediariopa.infogroup.it/")]
    public class ct0000000009_datiPagamentoInAttesa {
        [DataMember(IsRequired = true, EmitDefaultValue = false)]
        public string autenticazioneSoggetto { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string codiceContestoPagamento { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string ibanAddebito { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 3)]
        public string bicAddebito { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 4)]
        public ct0000000009_notificaCallback notificaCallback { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 5)]
        public ct0000000009_soggettoVersante soggettoVersante { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 6)]
        public ct0000000009_datiSingoloVersamento datiSingoloVersamento { get; set; }
    }

    [DataContract(Name = "ct0000000009_pdpInviaRPT", Namespace = "http://generatedsource.dp.webservice.intermediariopa.infogroup.it/")]
    public class ct0000000009_pdpInviaRPT {
        [DataMember(IsRequired = true, EmitDefaultValue = false)]
        public string identificativoUnivocoVersamento { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 1)]
        public string identificativoStazioneRichiedente { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 2)]
        public string tipoVersamento { get; set; }

        [DataMember(IsRequired = true, EmitDefaultValue = false, Order = 3)]
        public ct0000000009_parametriPSP parametriPSP { get; set; }

        [DataMember(IsRequired = true, EmitDefaultValue = false, Order = 4)]
        public ct0000000009_datiPagamentoInAttesa datiPagamentoInAttesa { get; set; }
    }

    [DataContract(Name = "ct0000000010_pdpInviaRPTResult", Namespace = "http://generatedsource.dp.webservice.intermediariopa.infogroup.it/")]
    public class ct0000000010_pdpInviaRPTResult {
        [DataMember(IsRequired = true, EmitDefaultValue = false)]
        public string esitoOperazione { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 1)]
        public string codiceErrore { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 2)]
        public string datiResituiti { get; set; }
    }

    [DataContract(Name = "ct0000000010_datiResituiti", Namespace = "http://generatedsource.dp.webservice.intermediariopa.infogroup.it/")]
    public class ct0000000010_datiResituiti {

        [DataMember(IsRequired = true)]
        public long pspSupportaRedirect { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string redirectURL { get; set; }
    }

    [DataContract(Name = "ct0000000011_pdpChiediStatoRPT", Namespace = "http://generatedsource.dp.webservice.intermediariopa.infogroup.it/")]
    public class ct0000000011_pdpChiediStatoRPT {

        [DataMember(IsRequired = true, EmitDefaultValue = false)]
        public string identificativoUnivocoVersamento { get; set; }

        [DataMember(IsRequired = true, EmitDefaultValue = false, Order = 1)]
        public string codiceContestoPagamento { get; set; }
    }

    [DataContract(Name = "ct0000000012_pdpChiediStatoRPTResult", Namespace = "http://generatedsource.dp.webservice.intermediariopa.infogroup.it/")]
    public class ct0000000012_pdpChiediStatoRPTResult {
        [DataMember(IsRequired = true, EmitDefaultValue = false)]
        public string esitoOperazione { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 1)]
        public string codiceErrore { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 2)]
        public string datiRestituiti { get; set; }
    }

    [DataContract(Name = "ct0000000012_datiRestituiti", Namespace = "http://generatedsource.dp.webservice.intermediariopa.infogroup.it/")]
    public class ct0000000012_datiRestituiti {
        [DataMember(IsRequired = true, EmitDefaultValue = false)]
        public string stato { get; set; }
    }

    [DataContract(Name = "ct0000000013_pdpRecuperaRPT", Namespace = "http://generatedsource.dp.webservice.intermediariopa.infogroup.it/")]
    public class ct0000000013_pdpRecuperaRPT {

        [DataMember(IsRequired = true, EmitDefaultValue = false)]
        public string identificativoUnivocoVersamento { get; set; }

        [DataMember(IsRequired = true, EmitDefaultValue = false, Order = 1)]
        public string codiceContestoPagamento { get; set; }
    }

    [DataContract(Name = "ct0000000014_datiMarcaBolloDigitale", Namespace = "http://generatedsource.dp.webservice.intermediariopa.infogroup.it/")]
    public class ct0000000014_datiMarcaBolloDigitale {
        [DataMember(EmitDefaultValue = false)]
        public string tipoBollo { get; set; }

        [DataMember(IsRequired = true, EmitDefaultValue = false, Order = 1)]
        public string hashDocumento { get; set; }

        [DataMember(IsRequired = true, EmitDefaultValue = false, Order = 2)]
        public string provinciaResidenzaPagatore { get; set; }
    }

    [DataContract(Name = "ct0000000014_datiSingoloVersamento", Namespace = "http://generatedsource.dp.webservice.intermediariopa.infogroup.it/")]
    public class ct0000000014_datiSingoloVersamento {
        [DataMember(IsRequired = true)]
        public long identificativoServizio { get; set; }

        [DataMember(IsRequired = true)]
        public decimal importoSingoloVersamento { get; set; }

        [DataMember(Order = 2)]
        public decimal commissioneCaricoPA { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 3)]
        public string ibanAccredito { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 4)]
        public string bicAccredito { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 5)]
        public string ibanAppoggio { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 6)]
        public string bicAppoggio { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 7)]
        public string credenzialiPagatore { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 8)]
        public string causaleVersamento { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 9)]
        public string descrizioneTestualeCausaleVersamento { get; set; }

        [DataMember(IsRequired = true, EmitDefaultValue = false, Order = 10)]
        public string causaleVersamentoEsplicitaPSP { get; set; }

        [DataMember(IsRequired = true, EmitDefaultValue = false, Order = 11)]
        public string datiSpecificiRiscossione { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 12)]
        public ct0000000014_datiMarcaBolloDigitale datiMarcaBolloDigitale { get; set; }
    }

    [DataContract(Name = "ct0000000014_soggettoVersante", Namespace = "http://generatedsource.dp.webservice.intermediariopa.infogroup.it/")]
    public class ct0000000014_soggettoVersante {

        [DataMember(IsRequired = true, EmitDefaultValue = false)]
        public string tipoIdentificativoUnivocoVersante { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 1)]
        public string codiceIdentificativoUnivocoVersante { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 2)]
        public string anagraficaVersante { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 3)]
        public string indirizzoVersante { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 4)]
        public string civicoVersante { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 5)]
        public string capVersante { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 6)]
        public string localitaVersante { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 7)]
        public string provinciaVersante { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 8)]
        public string nazioneVersante { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 9)]
        public string emailVersante { get; set; }
    }

    [DataContract(Name = "ct0000000014_soggettoPagatore", Namespace = "http://generatedsource.dp.webservice.intermediariopa.infogroup.it/")]
    public class ct0000000014_soggettoPagatore {

        [DataMember(IsRequired = true, EmitDefaultValue = false)]
        public string tipoIdentificativoUnivocoPagatore { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 1)]
        public string codiceIdentificativoUnivocoPagatore { get; set; }

        [DataMember(IsRequired = true, EmitDefaultValue = false, Order = 2)]
        public string anagraficaPagatore { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 3)]
        public string indirizzoPagatore { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 4)]
        public string civicoPagatore { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 5)]
        public string capPagatore { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 6)]
        public string localitaPagatore { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 7)]
        public string provinciaPagatore { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 8)]
        public string nazionePagatore { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 9)]
        public string emailPagatore { get; set; }
    }

    [DataContract(Name = "ct0000000014_datiVersamento", Namespace = "http://generatedsource.dp.webservice.intermediariopa.infogroup.it/")]
    public class ct0000000014_datiVersamento {
        [DataMember(IsRequired = true, EmitDefaultValue = false)]
        public string dataEsecuzionePagamento { get; set; }

        [DataMember(IsRequired = true)]
        public decimal importoTotaleDaVersare { get; set; }

        [DataMember(IsRequired = true, EmitDefaultValue = false)]
        public string tipoVersamento { get; set; }

        [DataMember(IsRequired = true, EmitDefaultValue = false, Order = 3)]
        public string identificativoUnivocoVersamento { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 4)]
        public string codiceContestoPagamento { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 5)]
        public string ibanAddebito { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 6)]
        public string bicAddebito { get; set; }

        [DataMember(IsRequired = true, EmitDefaultValue = false, Order = 7)]
        public string firmaRicevuta { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 8)]
        public ct0000000014_datiSingoloVersamento datiSingoloVersamento { get; set; }
    }

    [DataContract(Name = "ct0000000014_enteBeneficiario", Namespace = "http://generatedsource.dp.webservice.intermediariopa.infogroup.it/")]
    public class ct0000000014_enteBeneficiario {
        [DataMember(IsRequired = true, EmitDefaultValue = false)]
        public string tipoIdentificativoUnivocoBeneficiario { get; set; }

        [DataMember(IsRequired = true, EmitDefaultValue = false, Order = 1)]
        public string codiceIdentificativoUnivocoBeneficiario { get; set; }

        [DataMember(IsRequired = true, EmitDefaultValue = false, Order = 2)]
        public string denominazioneBeneficiario { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 3)]
        public string codiceUnitOperBeneficiario { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 4)]
        public string denomUnitOperBeneficiario { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 5)]
        public string indirizzoBeneficiario { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 6)]
        public string civicoBeneficiario { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 7)]
        public string capBeneficiario { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 8)]
        public string localitaBeneficiario { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 9)]
        public string provinciaBeneficiario { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 10)]
        public string nazioneBeneficiario { get; set; }
    }

    [DataContract(Name = "ct0000000014_parametriPSP", Namespace = "http://generatedsource.dp.webservice.intermediariopa.infogroup.it/")]
    public class ct0000000014_parametriPSP {
        [DataMember(IsRequired = true, EmitDefaultValue = false)]
        public string identificativoPSP { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 1)]
        public string identificativoIntermediarioPSP { get; set; }

        [DataMember(IsRequired = true, EmitDefaultValue = false, Order = 2)]
        public string identificativoCanale { get; set; }
    }

    [DataContract(Name = "ct0000000014_datiRestituiti", Namespace = "http://generatedsource.dp.webservice.intermediariopa.infogroup.it/")]
    public class ct0000000014_datiRestituiti {
        [DataMember(EmitDefaultValue = false)]
        public string identificativoStazioneRichiedente { get; set; }

        [DataMember(IsRequired = true, EmitDefaultValue = false, Order = 1)]
        public string identificativoMessaggioRichiesta { get; set; }

        [DataMember(IsRequired = true, Order = 2)]
        public System.DateTime dataOraMessaggioRichiesta { get; set; }

        [DataMember(IsRequired = true, EmitDefaultValue = false, Order = 3)]
        public ct0000000014_parametriPSP parametriPSP { get; set; }

        [DataMember(IsRequired = true, EmitDefaultValue = false, Order = 4)]
        public string autenticazioneSoggetto { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 5)]
        public ct0000000014_soggettoVersante soggettoVersante { get; set; }

        [DataMember(IsRequired = true, EmitDefaultValue = false, Order = 6)]
        public ct0000000014_soggettoPagatore soggettoPagatore { get; set; }

        [DataMember(IsRequired = true, EmitDefaultValue = false, Order = 7)]
        public ct0000000014_enteBeneficiario enteBeneficiario { get; set; }

        [DataMember(IsRequired = true, EmitDefaultValue = false, Order = 8)]
        public ct0000000014_datiVersamento datiVersamento { get; set; }
    }

    [DataContract(Name = "ct0000000014_pdpRecuperaRPTResult", Namespace = "http://generatedsource.dp.webservice.intermediariopa.infogroup.it/")]
    public class ct0000000014_pdpRecuperaRPTResult {
        [DataMember(IsRequired = true, EmitDefaultValue = false)]
        public string esitoOperazione { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 1)]
        public string codiceErrore { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 2)]
        public ct0000000014_datiRestituiti datiRestituiti { get; set; }
    }

    [DataContract(Name = "ct0000000015_pdpRecuperaRT", Namespace = "http://generatedsource.dp.webservice.intermediariopa.infogroup.it/")]
    public class ct0000000015_pdpRecuperaRT {

        [DataMember(IsRequired = true, EmitDefaultValue = false)]
        public string identificativoUnivocoVersamento { get; set; }

        [DataMember(IsRequired = true, EmitDefaultValue = false, Order = 1)]
        public string codiceContestoPagamento { get; set; }
    }

    [DataContract(Name = "ct0000000016_allegatoRicevuta", Namespace = "http://generatedsource.dp.webservice.intermediariopa.infogroup.it/")]
    public class ct0000000016_allegatoRicevuta {

        [DataMember(IsRequired = true, EmitDefaultValue = false)]
        public string tipoAllegatoRicevuta { get; set; }

        [DataMember(IsRequired = true, EmitDefaultValue = false, Order = 1)]
        public string testoAllegato { get; set; }
    }

    [DataContract(Name = "ct0000000016_datiSingoloPagamento", Namespace = "http://generatedsource.dp.webservice.intermediariopa.infogroup.it/")]
    public class ct0000000016_datiSingoloPagamento {
        [DataMember(EmitDefaultValue = false)]
        public string parametriAggiuntiviSingoloVersamento { get; set; }

        //[DataMember(EmitDefaultValue = false, Order = 1)]
        //public string identificativoFlusso { get; set; }

        //[DataMember(Order = 2)]
        //public System.DateTime dataOraFlusso { get; set; }

        //[DataMember(EmitDefaultValue = false, Order = 3)]
        //public string identificativoUnivocoRegolamento { get; set; }

        //[DataMember(EmitDefaultValue = false, Order = 4)]
        //public string dataRegolamento { get; set; }
    }

    [DataContract(Name = "ct0000000016_istitutoAttestante", Namespace = "http://generatedsource.dp.webservice.intermediariopa.infogroup.it/")]
    public class ct0000000016_istitutoAttestante {
        [DataMember(IsRequired = true, EmitDefaultValue = false)]
        public string tipoIdentificativoUnivocoAttestante { get; set; }

        [DataMember(IsRequired = true, EmitDefaultValue = false, Order = 1)]
        public string codiceIdentificativoUnivocoAttestante { get; set; }

        [DataMember(IsRequired = true, EmitDefaultValue = false, Order = 2)]
        public string denominazioneAttestante { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 3)]
        public string codiceUnitOperAttestante { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 4)]
        public string denomUnitOperAttestante { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 5)]
        public string indirizzoAttestante { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 6)]
        public string civicoAttestante { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 7)]
        public string capAttestante { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 8)]
        public string localitaAttestante { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 9)]
        public string provinciaAttestante { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 10)]
        public string nazioneAttestante { get; set; }
    }

    [DataContract(Name = "ct0000000016_enteBeneficiario", Namespace = "http://generatedsource.dp.webservice.intermediariopa.infogroup.it/")]
    public class ct0000000016_enteBeneficiario {
        [DataMember(IsRequired = true, EmitDefaultValue = false)]
        public string tipoIdentificativoUnivocoBeneficiario { get; set; }

        [DataMember(IsRequired = true, EmitDefaultValue = false, Order = 1)]
        public string codiceIdentificativoUnivocoBeneficiario { get; set; }

        [DataMember(IsRequired = true, EmitDefaultValue = false, Order = 2)]
        public string denominazioneBeneficiario { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 3)]
        public string codiceUnitOperBeneficiario { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 4)]
        public string denomUnitOperBeneficiario { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 5)]
        public string indirizzoBeneficiario { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 6)]
        public string civicoBeneficiario { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 7)]
        public string capBeneficiario { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 8)]
        public string localitaBeneficiario { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 9)]
        public string provinciaBeneficiario { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 10)]
        public string nazioneBeneficiario { get; set; }
    }

    [DataContract(Name = "ct0000000016_soggettoVersante", Namespace = "http://generatedsource.dp.webservice.intermediariopa.infogroup.it/")]
    public class ct0000000016_soggettoVersante {

        [DataMember(IsRequired = true, EmitDefaultValue = false)]
        public string tipoIdentificativoUnivocoVersante { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 1)]
        public string codiceIdentificativoUnivocoVersante { get; set; }

        [DataMember(IsRequired = true, EmitDefaultValue = false, Order = 2)]
        public string anagraficaVersante { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 3)]
        public string indirizzoVersante { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 4)]
        public string civicoVersante { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 5)]
        public string capVersante { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 6)]
        public string localitaVersante { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 7)]
        public string provinciaVersante { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 8)]
        public string nazioneVersante { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 9)]
        public string emailVersante { get; set; }
    }

    [DataContract(Name = "ct0000000016_soggettoPagatore", Namespace = "http://generatedsource.dp.webservice.intermediariopa.infogroup.it/")]
    public class ct0000000016_soggettoPagatore {

        [DataMember(IsRequired = true, EmitDefaultValue = false)]
        public string tipoIdentificativoUnivocoPagatore { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 1)]
        public string codiceIdentificativoUnivocoPagatore { get; set; }

        [DataMember(IsRequired = true, EmitDefaultValue = false, Order = 2)]
        public string anagraficaPagatore { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 3)]
        public string indirizzoPagatore { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 4)]
        public string civicoPagatore { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 5)]
        public string capPagatore { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 6)]
        public string localitaPagatore { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 7)]
        public string provinciaPagatore { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 8)]
        public string nazionePagatore { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 9)]
        public string emailPagatore { get; set; }
    }

    [DataContract(Name = "ct0000000016_datiPagamento", Namespace = "http://generatedsource.dp.webservice.intermediariopa.infogroup.it/")]
    public class ct0000000016_datiPagamento {

        [DataMember(IsRequired = true, EmitDefaultValue = false)]
        public string tipoVersamento { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 1)]
        public string parametriAggiuntivi { get; set; }

        [DataMember(IsRequired = true, EmitDefaultValue = false, Order = 2)]
        public string causaleVersamentoEsplicitaPSP { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 3)]
        public ct0000000016_datiSingoloPagamento datiSingoloPagamento { get; set; }
    }

    [DataContract(Name = "ct0000000016_parametriPSP", Namespace = "http://generatedsource.dp.webservice.intermediariopa.infogroup.it/")]
    public class ct0000000016_parametriPSP {
        [DataMember(IsRequired = true, EmitDefaultValue = false)]
        public string identificativoPSP { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 1)]
        public string identificativoIntermediarioPSP { get; set; }

        [DataMember(IsRequired = true, EmitDefaultValue = false, Order = 2)]
        public string identificativoCanale { get; set; }
    }

    [DataContract(Name = "ct0000000016_datiRestituiti", Namespace = "http://generatedsource.dp.webservice.intermediariopa.infogroup.it/")]
    public class ct0000000016_datiRestituiti {

        [DataMember(IsRequired = true, EmitDefaultValue = false)]
        public string xmlRT { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 1)]
        public string pdfRT { get; set; }

        [DataMember(IsRequired = true, EmitDefaultValue = false, Order = 2)]
        public ct0000000016_parametriPSP parametriPSP { get; set; }

        [DataMember(IsRequired = true, EmitDefaultValue = false, Order = 3)]
        public ct0000000016_datiPagamento datiPagamento { get; set; }

        [DataMember(IsRequired = true, EmitDefaultValue = false, Order = 4)]
        public string identificativoMessaggioRicevuta { get; set; }

        [DataMember(IsRequired = true, EmitDefaultValue = false, Order = 5)]
        public string codiceEsitoPagamento { get; set; }

        [DataMember(IsRequired = true, EmitDefaultValue = false, Order = 6)]
        public decimal importoTotalePagato { get; set; }

        [DataMember(IsRequired = true, EmitDefaultValue = false, Order = 7)]
        public string identificativoUnivocoVersamento { get; set; }

        [DataMember(IsRequired = true, EmitDefaultValue = false, Order = 8)]
        public string codiceContestoPagamento { get; set; }

        [DataMember(IsRequired = true, EmitDefaultValue = false, Order = 9)]
        public DateTime dataCreazioneRicevuta { get; set; }
    }

    [DataContract(Name = "ct0000000016_pdpRecuperaRTResult", Namespace = "http://generatedsource.dp.webservice.intermediariopa.infogroup.it/")]
    public class ct0000000016_pdpRecuperaRTResult {
        [DataMember(IsRequired = true, EmitDefaultValue = false)]
        public string esitoOperazione { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 1)]
        public string codiceErrore { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 2)]
        public ct0000000016_datiRestituiti datiRestituiti { get; set; }
    }

    [DataContract(Name = "ct0000000017_pdpRichiediStornoRT", Namespace = "http://generatedsource.dp.webservice.intermediariopa.infogroup.it/")]
    public class ct0000000017_pdpRichiediStornoRT {
        [DataMember(IsRequired = true, EmitDefaultValue = false)]
        public string identificativoUnivocoVersamento { get; set; }
    }

    [DataContract(Name = "ct0000000018_pdpRichiediStornoRTResult", Namespace = "http://generatedsource.dp.webservice.intermediariopa.infogroup.it/")]
    public class ct0000000018_pdpRichiediStornoRTResult {

        [DataMember(IsRequired = true, EmitDefaultValue = false)]
        public string esitoOperazione { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 1)]
        public string codiceErrore { get; set; }
    }

    [DataContract(Name = "ct0000000019_pdpChiediSceltaWISP", Namespace = "http://generatedsource.dp.webservice.intermediariopa.infogroup.it/")]
    public class ct0000000019_pdpChiediSceltaWISP {

        [DataMember(IsRequired = true, EmitDefaultValue = false)]
        public string keyPA { get; set; }

        [DataMember(IsRequired = true, EmitDefaultValue = false)]
        public string keyWISP { get; set; }
    }

    [DataContract(Name = "ct0000000020_pdpChiediSceltaWISPResult", Namespace = "http://generatedsource.dp.webservice.intermediariopa.infogroup.it/")]
    public class ct0000000020_pdpChiediSceltaWISPResult {
        [DataMember(IsRequired = true, EmitDefaultValue = false)]
        public string esitoOperazione { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 1)]
        public string codiceErrore { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 2)]
        public ct0000000020_datiRestituiti datiRestituiti { get; set; }
    }

    [DataContract(Name = "ct0000000020_datiRestituiti", Namespace = "http://generatedsource.dp.webservice.intermediariopa.infogroup.it/")]
    public class ct0000000020_datiRestituiti {
        [DataMember(IsRequired = true, EmitDefaultValue = false)]
        public string effettuazioneScelta { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string identificativoPSP { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 2)]
        public string identificativoIntermediarioPSP { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 3)]
        public string identificativoCanale { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 4)]
        public string tipoVersamento { get; set; }
    }

    [DataContract(Name = "ct0000000021_pdpVerificaMarcaDaBolloDigitale", Namespace = "http://generatedsource.dp.webservice.intermediariopa.infogroup.it/")]
    public class ct0000000021_pdpVerificaMarcaDaBolloDigitale {

        [DataMember(IsRequired = true, EmitDefaultValue = false)]
        public string documentoAbbinato { get; set; }

        [DataMember(IsRequired = true, EmitDefaultValue = false)]
        public string marcaDaBolloDigitale { get; set; }
    }

    [DataContract(Name = "ct0000000022_pdpVerificaMarcaDaBolloDigitaleResult", Namespace = "http://generatedsource.dp.webservice.intermediariopa.infogroup.it/")]
    public class ct0000000022_pdpVerificaMarcaDaBolloDigitaleResult {

        [DataMember(IsRequired = true, EmitDefaultValue = false)]
        public string esitoOperazione { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 1)]
        public string codiceErrore { get; set; }
    }

    [DataContract(Name = "ct0000000023_dpVerificaPagamentoInAttesa", Namespace = "http://generatedsource.dp.webservice.intermediariopa.infogroup.it/")]
    public class ct0000000023_dpVerificaPagamentoInAttesa {

        [DataMember(IsRequired = true, EmitDefaultValue = false)]
        public string identificativoUnivocoVersamento { get; set; }

        [DataMember(IsRequired = true, EmitDefaultValue = false, Order = 1)]
        public string contestoDiRichiesta { get; set; }
    }

    [DataContract(Name = "ct0000000024_soggettoPagatore", Namespace = "http://generatedsource.dp.webservice.intermediariopa.infogroup.it/")]
    public class ct0000000024_soggettoPagatore {

        [DataMember(EmitDefaultValue = false)]
        public string tipoIdentificativoUnivocoPagatore { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 1)]
        public string codiceIdentificativoUnivocoPagatore { get; set; }

        [DataMember(IsRequired = true, EmitDefaultValue = false, Order = 2)]
        public string anagraficaPagatore { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 3)]
        public string indirizzoPagatore { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 4)]
        public string civicoPagatore { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 5)]
        public string capPagatore { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 6)]
        public string localitaPagatore { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 7)]
        public string provinciaPagatore { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 8)]
        public string nazionePagatore { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 9)]
        public string emailPagatore { get; set; }
    }

    [DataContract(Name = "ct0000000024_datiSingoloVersamento", Namespace = "http://generatedsource.dp.webservice.intermediariopa.infogroup.it/")]
    public class ct0000000024_datiSingoloVersamento {

        [DataMember(IsRequired = true)]
        public long identificativoServizio { get; set; }

        [DataMember(IsRequired = true)]
        public decimal importoSingoloVersamento { get; set; }

        [DataMember(Order = 2)]
        public decimal commissioneCaricoPA { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 3)]
        public string credenzialiPagatore { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 4)]
        public string descrizioneTestualeCausaleVersamento { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 5)]
        public string parametriAggiuntiviSingoloVersamento { get; set; }
    }

    [DataContract(Name = "ct0000000024_notificaCallback", Namespace = "http://generatedsource.dp.webservice.intermediariopa.infogroup.it/")]
    public class ct0000000024_notificaCallback {
        [DataMember(IsRequired = true, EmitDefaultValue = false)]
        public string callbackURL { get; set; }

        [DataMember(IsRequired = true, EmitDefaultValue = false)]
        public string callbackUsername { get; set; }

        [DataMember(IsRequired = true, EmitDefaultValue = false, Order = 2)]
        public string callbackPassword { get; set; }
    }

    [DataContract(Name = "ct0000000024_datiPagamentoInAttesa", Namespace = "http://generatedsource.dp.webservice.intermediariopa.infogroup.it/")]
    public class ct0000000024_datiPagamentoInAttesa {

        [DataMember(EmitDefaultValue = false)]
        public string dataScadenzaPagamento { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string parametriAggiuntivi { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 2)]
        public ct0000000024_notificaCallback notificaCallback { get; set; }

        [DataMember(IsRequired = true, EmitDefaultValue = false, Order = 3)]
        public ct0000000024_soggettoPagatore soggettoPagatore { get; set; }

        [DataMember(IsRequired = true, EmitDefaultValue = false, Order = 4)]
        public string causaleVersamentoEsplicitaPSP { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 5)]
        public ct0000000024_datiSingoloVersamento datiSingoloVersamento { get; set; }
    }

    [DataContract(Name = "ct0000000024_dpVerificaPagamentoInAttesaResult", Namespace = "http://generatedsource.dp.webservice.intermediariopa.infogroup.it/")]
    public class ct0000000024_dpVerificaPagamentoInAttesaResult {
        [DataMember(IsRequired = true, EmitDefaultValue = false)]
        public string esitoOperazione { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 1)]
        public string codiceErrore { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 2)]
        public ct0000000024_datiRestituiti datiRestituiti { get; set; }
    }

    [DataContract(Name = "ct0000000024_datiRestituiti", Namespace = "http://generatedsource.dp.webservice.intermediariopa.infogroup.it/")]
    public class ct0000000024_datiRestituiti {
        [DataMember(IsRequired = true, EmitDefaultValue = false)]
        public string identificativoBU { get; set; }

        [DataMember(IsRequired = true, EmitDefaultValue = false)]
        public string identificativoUnivocoVersamento { get; set; }

        [DataMember(IsRequired = true, EmitDefaultValue = false, Order = 2)]
        public ct0000000024_datiPagamentoInAttesa datiPagamentoInAttesa { get; set; }
    }

    [DataContract(Name = "ct0000000025_dpInviaEsitoPagamento", Namespace = "http://generatedsource.dp.webservice.intermediariopa.infogroup.it/")]
    public class ct0000000025_dpInviaEsitoPagamento {
        [DataMember(IsRequired = true, EmitDefaultValue = false)]
        public string identificativoUnivocoVersamento { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 1)]
        public string codiceContestoPagamento { get; set; }

        [DataMember(IsRequired = true, EmitDefaultValue = false, Order = 2)]
        public string esitoPagamento { get; set; }
    }

    [DataContract(Name = "ct0000000026_dpInviaEsitoPagamentoResult", Namespace = "http://generatedsource.dp.webservice.intermediariopa.infogroup.it/")]
    public class ct0000000026_dpInviaEsitoPagamentoResult {
        [DataMember(IsRequired = true, EmitDefaultValue = false)]
        public string esitoOperazione { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 1)]
        public string codiceErrore { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 2)]
        public ct0000000026_datiRestituiti datiRestituiti { get; set; }
    }

    [DataContract(Name = "ct0000000026_datiRestituiti", Namespace = "http://generatedsource.dp.webservice.intermediariopa.infogroup.it/")]
    public class ct0000000026_datiRestituiti {
        [DataMember(IsRequired = true, EmitDefaultValue = false)]
        public string identificativoUnivocoVersamento { get; set; }
    }

    [DataContract(Name = "ct0000000001_pdpChiediFlussoRendicontazioneType", Namespace = "http://generatedsource.dp.webservice.intermediariopa.infogroup.it/")]
    public class ct0000000001_pdpChiediFlussoRendicontazione {

        [DataMember(IsRequired = true, EmitDefaultValue = false)]
        public string identificativoFlusso { get; set; }

        [DataMember(IsRequired = true, EmitDefaultValue = false, Order = 1)]
        public string idServizio { get; set; }
    }

    [DataContract(Name = "ct0000000002_pdpChiediFlussoRendicontazioneResultType", Namespace = "http://generatedsource.dp.webservice.intermediariopa.infogroup.it/")]
    public class ct0000000002_pdpChiediFlussoRendicontazioneResult {
        [DataMember(IsRequired = true, EmitDefaultValue = false)]
        public string esitoOperazione { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 1)]
        public string codiceErrore { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 2)]
        public string flussoXml { get; set; }
    }

    [DataContract(Name = "ct0000000003_pdpChiediElencoFlussiRendicontazioneType", Namespace = "http://generatedsource.dp.webservice.intermediariopa.infogroup.it/")]
    public class ct0000000003_pdpChiediElencoFlussiRendicontazione {
        [DataMember(IsRequired = true)]
        public DateTime dataOraFlusso { get; set; }
    }

    [DataContract(Name = "ct0000000004_pdpChiediElencoFlussiRendicontazioneResultType", Namespace = "http://generatedsource.dp.webservice.intermediariopa.infogroup.it/")]
    public class ct0000000004_pdpChiediElencoFlussiRendicontazioneResult {

        [DataMember(IsRequired = true, EmitDefaultValue = false)]
        public string esitoOperazione { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 1)]
        public string codiceErrore { get; set; }

        [DataMember(IsRequired = true, Order = 2)]
        public long totRestituiti { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 3)]
        public ct0000000005_flusso flusso { get; set; }
    }

    [DataContract(Name = "ct0000000005_flussoType", Namespace = "http://generatedsource.dp.webservice.intermediariopa.infogroup.it/")]
    public class ct0000000005_flusso {

        [DataMember(IsRequired = true, EmitDefaultValue = false)]
        public string identificativoFlusso { get; set; }

        [DataMember(IsRequired = true, Order = 1)]
        public System.DateTime dataOraFlusso { get; set; }
    }

    [DataContract(Name = "ct0000000006_pdpEsitiRTType", Namespace = "http://generatedsource.dp.webservice.intermediariopa.infogroup.it/")]
    public class ct0000000006_pdpEsitiRTType {

        [DataMember(EmitDefaultValue = false)]
        public string idServizio { get; set; }

        [DataMember(IsRequired = false, EmitDefaultValue = false, Order = 1)]
        public string idOperazione { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 2)]
        public DateTime? dataInizio { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 3)]
        public DateTime? dataFine { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 4)]
        public string identificativoUnivocoVersamento { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 5)]
        public string CF { get; set; }
    }

    [DataContract(Name = "ct0000000016_pdpRecuperaRTType", Namespace = "http://generatedsource.dp.webservice.intermediariopa.infogroup.it/")]
    public class ct0000000016_pdpRecuperaRTType
    {

        [DataMember(EmitDefaultValue = false)]
        public string identificativoUnivocoVersamento { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 1)]
        public string codiceContestoPagamento { get; set; }
    }

    [CollectionDataContract(Name= "listaRicevutaTelematica", ItemName ="ricevutaTelematica", Namespace = "http://generatedsource.dp.webservice.intermediariopa.infogroup.it/")]
    public class listaRicevute : Collection<ct0000000008_ricevutaTelematicaType> { }

    [DataContract(Name = "ct0000000007_pdpEsitiRTResultType", Namespace = "http://generatedsource.dp.webservice.intermediariopa.infogroup.it/")]
    public class ct0000000007_pdpEsitiRTResultType {


        [DataMember(EmitDefaultValue = false, Order = 1)]
        public ct0000000007_pdpEsitiRTResultTypeEsitoOperazione esitoOperazione { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 2)]
        public ct0000000007_pdpEsitiRTResultTypeCodiceErrore codiceErrore { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 3)]
        public string identificativoDominio { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 4)]
        public string identificativoUB { get; set; }


        [DataMember(EmitDefaultValue = false, Order = 5)]
        public string denominazoneUB { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 6)]        
        public listaRicevute listaRicevutaTelematica { get; set; }

    }

    [DataContract(Name = "ct0000000007_pdpEsitiRTResultTypeEsitoOperazione", Namespace = "http://generatedsource.dp.webservice.intermediariopa.infogroup.it/")]
    public enum ct0000000007_pdpEsitiRTResultTypeEsitoOperazione {

        [EnumMember]
        OK,

        [EnumMember]
        KO,
    }



    [DataContract(Name = "ct0000000007_pdpEsitiRTResultTypeCodiceErrore", Namespace = "http://generatedsource.dp.webservice.intermediariopa.infogroup.it/")]
    public enum ct0000000007_pdpEsitiRTResultTypeCodiceErrore {

        [EnumMember]
        OK,

        [EnumMember]
        WS_PARAMETRI_MANCANTI,

        [EnumMember]
        WS_ERRORE_INTERNO,

        [EnumMember]
        WS_ESITI_RT_NESSUN_RISULTATO,

        [EnumMember]
        WS_ESITI_RT_TROPPI_RISULTATI,
    }


    [DataContract(Name = "ct0000000008_ricevutaTelematicaType", Namespace = "http://generatedsource.dp.webservice.intermediariopa.infogroup.it/")]
    public class ct0000000008_ricevutaTelematicaType {

        [DataMember(IsRequired = true, EmitDefaultValue = false, Order = 1)]
        public string identificativoUnivocoVersamento { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 2)]
        public string idTenant { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 3)]
        public System.DateTime dataEsecuzionePagamento { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 4)]
        public System.DateTime dataInvioRt { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 5)]
        public string firmaRicevuta { get; set; }

        [DataMember(IsRequired = true, EmitDefaultValue = false, Order = 6)]
        public string codiceContestoPagamento { get; set; }

        [DataMember(Order = 7)]
        public int codiceEsitoPagamento { get; set; }

        [DataMember(IsRequired = true, EmitDefaultValue = false, Order = 8)]
        public string tipoIdentificativoUnivocoAttestante { get; set; }

        [DataMember(IsRequired = true, EmitDefaultValue = false, Order = 9)]
        public string codiceIdentificativoUnivocoAttestante { get; set; }

        [DataMember(IsRequired = true, EmitDefaultValue = false, Order = 10)]
        public string denominazioneAttestante { get; set; }

        [DataMember(IsRequired = true, EmitDefaultValue = true, Order = 11)]
        public ct0000000008_ricevutaTelematicaTypeTipoIdentificativoUnivocoPagatore tipoIdentificativoUnivocoPagatore { get; set; }

        [DataMember(IsRequired = true, EmitDefaultValue = false, Order = 12)]
        public string codiceIdentificativoUnivocoPagatore { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 13)]
        public string anagraficaPagatore { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 14)]
        public string capPagatore { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 15)]
        public string civicoPagatore { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 16)]
        public string emailPagatore { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 17)]
        public string indirizzoPagatore { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 18)]
        public string localitaPagatore { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 19)]
        public string nazionePagatore { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 20)]
        public string provinciaPagatore { get; set; }



        [DataMember(EmitDefaultValue = false, Order = 21)]
        public ct0000000009_datiSingoloPagamentoType datiSingoloPagamento { get; set; }
    }


    [DataContract(Name = "ct0000000008_ricevutaTelematicaTypeTipoIdentificativoUnivocoPagatore", Namespace = "http://generatedsource.dp.webservice.intermediariopa.infogroup.it/")]
    public enum ct0000000008_ricevutaTelematicaTypeTipoIdentificativoUnivocoPagatore {

        [EnumMemberAttribute]
        F,

        [EnumMemberAttribute]
        G,
    }

    [DataContract(Name = "ct0000000009_datiSingoloPagamentoType", Namespace = "http://generatedsource.dp.webservice.intermediariopa.infogroup.it/")]
    public partial class ct0000000009_datiSingoloPagamentoType {
        [DataMember(EmitDefaultValue = false, Order = 1)]
        public string idServizio { get; set; }

        [DataMember(IsRequired = true, Order = 2)]
        public decimal importoSingoloVersamento { get; set; }

        [DataMember(IsRequired = true, EmitDefaultValue = false, Order = 3)]
        public string causaleVersamento { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 4)]
        public string tipoDatiSpecificiRiscossione { get; set; }

        [DataMember(IsRequired = true, EmitDefaultValue = false, Order = 5)]
        public string datiSpecificiRiscossione { get; set; }

        [DataMember(IsRequired = true, EmitDefaultValue = false, Order = 6)]
        public string identUnivocoRiscossione { get; set; }

        [DataMember(IsRequired = true, Order = 7)]
        public int ordinePagamento { get; set; }

        /// <summary>
        /// Codice identificativo flusso rendicontazione standard PagoPA 
        /// </summary>
        [DataMember(EmitDefaultValue = false, Order = 8)]
        public string idFlusso { get; set; }

        /// <summary>
        /// Identificativo Bonifico Sepa (Transaction Reference Number” (TRN) ) del Bonifico cumulative 
        /// effettuato dal PSP, presente nel flusso di rendicontazione standard AgID 
        /// </summary>
        [DataMember(EmitDefaultValue = false, Order = 9)]                        
        public string identificativoUnivocoRegolamento { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 10)]
        public string dataRegolamento { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 11)]
        public string capitoloDiBilancio { get; set; }

        /// <summary>
        /// Informazione reperita sul Giornale di Cassa di Tesoreria, presente solo nel caso di attivazione
        ///  del modulo di Riconciliazione e se rispettati i tempi tecnici necessari. 
        /// </summary>
        [DataMember(EmitDefaultValue = false, Order = 12)]
        public string provvisorioEntrata { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 13)]
        public string ibanAccredito { get; set; }
    }



    [DataContract(Name = "ct0000000027_pdpAttivaRpt", Namespace = "http://generatedsource.dp.webservice.intermediariopa.infogroup.it/")]
    public class ct0000000027_pdpAttivaRpt {

        [DataMember(IsRequired = true, EmitDefaultValue = false)]
        public ct0000000027_datiPagamentoInAttesa datiPagamentoInAttesa { get; set; }

        [DataMember(IsRequired = true, EmitDefaultValue = false, Order = 1)]
        public string callbackURL { get; set; }
    }

    [DataContract(Name = "ct0000000027_datiPagamentoInAttesa", Namespace = "http://generatedsource.dp.webservice.intermediariopa.infogroup.it/")]
    public class ct0000000027_datiPagamentoInAttesa {
        /// <summary>
        /// IUV  Obbligatorio nel caso di modifica di un pagamento in attesa 
        /// </summary>
        [DataMember(IsRequired = true, EmitDefaultValue = false)]
        public string identificativoUnivocoVersamento { get; set; }
    }

    [DataContract(Name = "ct0000000027_pdpAttivaRptResultType", Namespace = "http://generatedsource.dp.webservice.intermediariopa.infogroup.it/")]
    public class ct0000000027_pdpAttivaRptResult {
        [DataMember(IsRequired = true, EmitDefaultValue = false)]
        public string esitoOperazione { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 1)]
        public string codiceErrore { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 2)]
        public ct0000000027_datiRestituiti datiRestituiti { get; set; }
    }

    [DataContract(Name = "ct0000000027_datiRestituiti", Namespace = "http://generatedsource.dp.webservice.intermediariopa.infogroup.it/")]
    public class ct0000000027_datiRestituiti {
        [DataMember(EmitDefaultValue = false)]
        public string identificativoUnivocoVersamento { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string redirectURL { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 2)]
        public string codiceContestoPagamento { get; set; }
    }
}

#endregion
