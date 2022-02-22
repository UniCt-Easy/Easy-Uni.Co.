
/*
Easy
Copyright (C) 2022 Università degli Studi di Catania (www.unict.it)
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


using System.Runtime.Serialization;

#region "Strutture dati (EasyBridge)"

namespace EasyBridge {
    using InfoGroup;
   
    [DataContract(Name = "Output", Namespace = "http://easybridge.eu/bridge/")]
    public class Output {

        [DataMember(EmitDefaultValue = false)]
        public byte[] param { get; set; }

    }

    [DataContract(Name = "OutputVerificaPagamentoInAttesa", Namespace = "http://easybridge.eu/bridge/")]
    public class OutputVerificaPagamentoInAttesa {

        [DataMember(IsRequired = true, EmitDefaultValue = false)]
        public string identificativoBU { get; set; }

        [DataMember(IsRequired = true, EmitDefaultValue = false)]
        public byte[] param { get; set; }
    }

    [DataContract(Name = "pdpRichiediAvviso", Namespace = "http://easybridge.eu/bridge/")]
    [KnownType(typeof(ct0000000028_pdpRichiediAvviso))]
    public class pdpRichiediAvviso :ct0000000028_pdpRichiediAvviso { }

    [DataContract(Name = "pdpRichiediAvvisoResult", Namespace = "http://easybridge.eu/bridge/")]
    [KnownType(typeof(ct0000000028_pdpRichiediAvvisoResult))]
    public class pdpRichiediAvvisoResult :ct0000000028_pdpRichiediAvvisoResult { }

    [DataContract(Name = "pdpGeneraIUVResult", Namespace = "http://easybridge.eu/bridge/")]
    [KnownType(typeof(ct0000000002_pdpGeneraIUVResult))]
    public class pdpGeneraIUVResult :ct0000000002_pdpGeneraIUVResult { }

    [DataContract(Name = "pdpCaricaPagamentoInAttesa", Namespace = "http://easybridge.eu/bridge/")]
    [KnownType(typeof(ct0000000003_pdpCaricaPagamentoInAttesa))]
    public class pdpCaricaPagamentoInAttesa :ct0000000003_pdpCaricaPagamentoInAttesa { }

    [DataContract(Name = "pdpCaricaPagamentoInAttesaResult", Namespace = "http://easybridge.eu/bridge/")]
    [KnownType(typeof(ct0000000004_pdpCaricaPagamentoInAttesaResult))]
    [KnownType(typeof(pdpCaricaPagamentoInAttesaResult))]
    public class pdpCaricaPagamentoInAttesaResult :ct0000000004_pdpCaricaPagamentoInAttesaResult { }

    [DataContract(Name = "pdpCancellaPagamentoInAttesa", Namespace = "http://easybridge.eu/bridge/")]
    [KnownType(typeof(ct0000000005_pdpCancellaPagamentoInAttesa))]
    public class pdpCancellaPagamentoInAttesa :ct0000000005_pdpCancellaPagamentoInAttesa { }

    [DataContract(Name = "pdpCancellaPagamentoInAttesaResult", Namespace = "http://easybridge.eu/bridge/")]
    [KnownType(typeof(ct0000000006_pdpCancellaPagamentoInAttesaResult))]
    public class pdpCancellaPagamentoInAttesaResult :ct0000000006_pdpCancellaPagamentoInAttesaResult { }

    [DataContract(Name = "pdpGeneraRPT", Namespace = "http://easybridge.eu/bridge/")]
    [KnownType(typeof(ct0000000007_pdpGeneraRPT))]
    public class pdpGeneraRPT :ct0000000007_pdpGeneraRPT { }

    [DataContract(Name = "pdpGeneraRPTResult", Namespace = "http://easybridge.eu/bridge/")]
    [KnownType(typeof(ct0000000008_pdpGeneraRPTResult))]
    public class pdpGeneraRPTResult :ct0000000008_pdpGeneraRPTResult { }

    [DataContract(Name = "pdpInviaRPT", Namespace = "http://easybridge.eu/bridge/")]
    [KnownType(typeof(ct0000000009_pdpInviaRPT))]
    public class pdpInviaRPT :ct0000000009_pdpInviaRPT { }

    [DataContract(Name = "pdpInviaRPTResult", Namespace = "http://easybridge.eu/bridge/")]
    [KnownType(typeof(ct0000000010_pdpInviaRPTResult))]
    public class pdpInviaRPTResult :ct0000000010_pdpInviaRPTResult { }

    [DataContract(Name = "pdpChiediStatoRPT", Namespace = "http://easybridge.eu/bridge/")]
    [KnownType(typeof(ct0000000011_pdpChiediStatoRPT))]
    public class pdpChiediStatoRPT :ct0000000011_pdpChiediStatoRPT { }

    [DataContract(Name = "pdpChiediStatoRPTResult", Namespace = "http://easybridge.eu/bridge/")]
    [KnownType(typeof(ct0000000012_pdpChiediStatoRPTResult))]
    public class pdpChiediStatoRPTResult :ct0000000012_pdpChiediStatoRPTResult { }

    [DataContract(Name = "pdpRecuperaRPTResult", Namespace = "http://easybridge.eu/bridge/")]
    [KnownType(typeof(ct0000000014_pdpRecuperaRPTResult))]
    public class pdpRecuperaRPTResult :ct0000000014_pdpRecuperaRPTResult { }

    [DataContract(Name = "pdpRecuperaRT", Namespace = "http://easybridge.eu/bridge/")]
    [KnownType(typeof(ct0000000015_pdpRecuperaRT))]
    public class pdpRecuperaRT :ct0000000015_pdpRecuperaRT { }

    [DataContract(Name = "pdpRecuperaRTResult", Namespace = "http://easybridge.eu/bridge/")]
    [KnownType(typeof(ct0000000016_pdpRecuperaRTResult))]
    public class pdpRecuperaRTResult :ct0000000016_pdpRecuperaRTResult { }

    [DataContract(Name = "pdpRichiediStornoRT", Namespace = "http://easybridge.eu/bridge/")]
    [KnownType(typeof(ct0000000017_pdpRichiediStornoRT))]
    public class pdpRichiediStornoRT :ct0000000017_pdpRichiediStornoRT { }

    [DataContract(Name = "pdpRichiediStornoRTResult", Namespace = "http://easybridge.eu/bridge/")]
    [KnownType(typeof(ct0000000018_pdpRichiediStornoRTResult))]
    public class pdpRichiediStornoRTResult :ct0000000018_pdpRichiediStornoRTResult { }

    [DataContract(Name = "pdpChiediSceltaWISP", Namespace = "http://easybridge.eu/bridge/")]
    [KnownType(typeof(ct0000000019_pdpChiediSceltaWISP))]
    public class pdpChiediSceltaWISP :ct0000000019_pdpChiediSceltaWISP { }

    [DataContract(Name = "pdpChiediSceltaWISPResult", Namespace = "http://easybridge.eu/bridge/")]
    [KnownType(typeof(ct0000000020_pdpChiediSceltaWISPResult))]
    public class pdpChiediSceltaWISPResult :ct0000000020_pdpChiediSceltaWISPResult { }

    [DataContract(Name = "pdpVerificaMarcaDaBolloDigitale", Namespace = "http://easybridge.eu/bridge/")]
    [KnownType(typeof(ct0000000021_pdpVerificaMarcaDaBolloDigitale))]
    public class pdpVerificaMarcaDaBolloDigitale :ct0000000021_pdpVerificaMarcaDaBolloDigitale { }

    [DataContract(Name = "pdpVerificaMarcaDaBolloDigitaleResult", Namespace = "http://easybridge.eu/bridge/")]
    [KnownType(typeof(ct0000000022_pdpVerificaMarcaDaBolloDigitaleResult))]
    public class pdpVerificaMarcaDaBolloDigitaleResult :ct0000000022_pdpVerificaMarcaDaBolloDigitaleResult { }

    [DataContract(Name = "dpVerificaPagamentoInAttesa", Namespace = "http://easybridge.eu/bridge/")]
    [KnownType(typeof(ct0000000023_dpVerificaPagamentoInAttesa))]
    public class dpVerificaPagamentoInAttesa :ct0000000023_dpVerificaPagamentoInAttesa { }

    [DataContract(Name = "dpVerificaPagamentoInAttesaResult", Namespace = "http://easybridge.eu/bridge/")]
    [KnownType(typeof(ct0000000024_dpVerificaPagamentoInAttesaResult))]
    public class dpVerificaPagamentoInAttesaResult :ct0000000024_dpVerificaPagamentoInAttesaResult { }

    [DataContract(Name = "dpInviaEsitoPagamento", Namespace = "http://easybridge.eu/bridge/")]
    [KnownType(typeof(ct0000000025_dpInviaEsitoPagamento))]
    public class dpInviaEsitoPagamento :ct0000000025_dpInviaEsitoPagamento { }

    [DataContract(Name = "dpInviaEsitoPagamentoResult", Namespace = "http://easybridge.eu/bridge/")]
    [KnownType(typeof(ct0000000026_dpInviaEsitoPagamentoResult))]
    public class dpInviaEsitoPagamentoResult :ct0000000026_dpInviaEsitoPagamentoResult { }

    [DataContract(Name = "pdpChiediFlussoRendicontazione", Namespace = "http://easybridge.eu/bridge/")]
    [KnownType(typeof(ct0000000001_pdpChiediFlussoRendicontazione))]
    public class pdpChiediFlussoRendicontazione :ct0000000001_pdpChiediFlussoRendicontazione { }

    [DataContract(Name = "pdpChiediFlussoRendicontazioneResult", Namespace = "http://easybridge.eu/bridge/")]
    [KnownType(typeof(ct0000000002_pdpChiediFlussoRendicontazioneResult))]
    public class pdpChiediFlussoRendicontazioneResult :ct0000000002_pdpChiediFlussoRendicontazioneResult { }

    [DataContract(Name = "pdpChiediElencoFlussiRendicontazione", Namespace = "http://easybridge.eu/bridge/")]
    [KnownType(typeof(ct0000000003_pdpChiediElencoFlussiRendicontazione))]
    public class pdpChiediElencoFlussiRendicontazione :ct0000000003_pdpChiediElencoFlussiRendicontazione { }

    [DataContract(Name = "pdpChiediElencoFlussiRendicontazioneResult", Namespace = "http://easybridge.eu/bridge/")]
    [KnownType(typeof(ct0000000004_pdpChiediElencoFlussiRendicontazioneResult))]
    public class pdpChiediElencoFlussiRendicontazioneResult :ct0000000004_pdpChiediElencoFlussiRendicontazioneResult { }

    [DataContract(Name = "pdpEsitiRT", Namespace = "http://easybridge.eu/bridge/")]
    [KnownType(typeof(ct0000000006_pdpEsitiRTType))]//aggiunto Type
    public class pdpEsitiRT :ct0000000006_pdpEsitiRTType { }

    [DataContract(Name = "pdpEsitiRTResult", Namespace = "http://easybridge.eu/bridge/")]
    [KnownType(typeof(ct0000000007_pdpEsitiRTResultType))]
    [KnownType(typeof(pdpEsitiRTResult))]
    public class pdpEsitiRTResult :ct0000000007_pdpEsitiRTResultType { }

    [DataContract(Name = "pdpEsitiRTResultType", Namespace = "http://easybridge.eu/bridge/")]
    [KnownType(typeof(ct0000000007_pdpEsitiRTResultType))]
    [KnownType(typeof(listaRicevute))]
    public class pdpEsitiRTResultType :ct0000000007_pdpEsitiRTResultType { }

    [DataContract(Name = "pdpAttivaRpt", Namespace = "http://easybridge.eu/bridge/")]
    [KnownType(typeof(ct0000000027_pdpAttivaRpt))]
    public class pdpAttivaRpt :ct0000000027_pdpAttivaRpt { }

    [DataContract(Name = "pdpAttivaRptResultType", Namespace = "http://easybridge.eu/bridge/")]
    [KnownType(typeof(ct0000000027_pdpAttivaRptResult))]
    [KnownType(typeof(pdpAttivaRptResult))]
    public class pdpAttivaRptResult : ct0000000027_pdpAttivaRptResult { }

}

#endregion
