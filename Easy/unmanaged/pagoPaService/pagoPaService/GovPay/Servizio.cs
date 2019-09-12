/*
    Easy
    Copyright (C) 2019 Universit� degli Studi di Catania (www.unict.it)

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

﻿using System;
using System.ServiceModel;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace GovPay {

    [ServiceContract(Namespace = "http://www.govpay.it/servizi/")]
    public interface IServizio {

        [OperationContract(Action = "gpGeneraIuv", ReplyAction = "*")]
        [XmlSerializerFormat]
        gpGeneraIuvResponse gpGeneraIuv(gpGeneraIuvRequest request);

        [OperationContract(Action = "gpCaricaIuv", ReplyAction = "*")]
        [XmlSerializerFormat]
        gpCaricaIuvResponse gpCaricaIuv(gpCaricaIuvRequest request);

        [OperationContract(Action = "gpCaricaVersamento", ReplyAction = "*")]
        [XmlSerializerFormat]
        [XmlFormatter.EnvelopeNamespaces(EnvelopeNamespaces = new string[] {
            "h:http://www.govpay.it/servizi"
           ,"ser:http://www.govpay.it/servizi/commons/"
           ,"xsi:http://www.w3.org/2001/XMLSchema-instance"
           ,"xsd:http://www.w3.org/2001/XMLSchema"
        })]
        gpCaricaVersamentoResponse gpCaricaVersamento(gpCaricaVersamentoRequest request);

        [OperationContract(Action = "gpAnnullaVersamento", ReplyAction = "*")]
        [XmlSerializerFormat]
        gpAnnullaVersamentoResponse gpAnnullaVersamento(gpAnnullaVersamentoRequest request);

        [OperationContract(Action = "gpNotificaPagamento", ReplyAction = "*")]
        [XmlSerializerFormat]
        gpNotificaPagamentoResponse gpNotificaPagamento(gpNotificaPagamentoRequest request);

        [OperationContract(Action = "gpChiediStatoVersamento", ReplyAction = "*")]
        [XmlSerializerFormat]
        gpChiediStatoVersamentoResponse gpChiediStatoVersamento(gpChiediStatoVersamentoRequest request);

        [OperationContract(Action = "gpChiediListaFlussiRendicontazione", ReplyAction = "*")]
        [XmlSerializerFormat]
        gpChiediListaFlussiRendicontazioneResponse gpChiediListaFlussiRendicontazione(gpChiediListaFlussiRendicontazioneRequest request);

        [OperationContract(Action = "gpChiediFlussoRendicontazione", ReplyAction = "*")]
        [XmlSerializerFormat]
        gpChiediFlussoRendicontazioneResponse gpChiediFlussoRendicontazione(gpChiediFlussoRendicontazioneRequest request);

    }

    public static class Servizio {

        //private static readonly string URL = "http://192.168.159.129:8080/govpay/PagamentiTelematiciGPAppService";
        //private static readonly string USERNAME = "gpadmin";
        //private static readonly string PASSWORD = "govpay";

        public static IServizio Create(string user, string pwd, string url) {
            var binding = new BasicHttpBinding(BasicHttpSecurityMode.Message);

            var address = new EndpointAddress(url);

            var factory = new ChannelFactory<IServizio>(binding, address);
            factory.Credentials.UserName.UserName = user;
            factory.Credentials.UserName.Password = pwd;

            return factory.CreateChannel();
        }

    }

    #region "Strutture comuni"

    [XmlInclude(typeof(FlussoRendicontazione))]
    [Serializable]
    [XmlType(Namespace = "http://www.govpay.it/servizi/commons/")]
    public class EstremiFlussoRendicontazione {

        [XmlElement("codFlusso", Form = XmlSchemaForm.Unqualified, Order = 0)]
        public string codFlusso { get; set; }

        [XmlElement("codBicRiversamento", Form = XmlSchemaForm.Unqualified, Order = 1)]
        public string codBicRiversamento { get; set; }

        [XmlElement("annoRiferimento", Form = XmlSchemaForm.Unqualified, DataType = "gYear", Order = 2)]
        public string annoRiferimento { get; set; }

        [XmlElement("codPsp", Form = XmlSchemaForm.Unqualified, Order = 3)]
        public string codPsp { get; set; }

        [XmlElement("dataFlusso", Form = XmlSchemaForm.Unqualified, Order = 4)]
        public DateTime dataFlusso { get; set; }

        [XmlElement("dataRegolamento", Form = XmlSchemaForm.Unqualified, DataType = "date", Order = 5)]
        public DateTime dataRegolamento { get; set; }

        [XmlElement("iur", Form = XmlSchemaForm.Unqualified, Order = 6)]
        public string iur { get; set; }

        [XmlElement("numeroPagamenti", Form = XmlSchemaForm.Unqualified, Order = 7)]
        public long numeroPagamenti { get; set; }

        [XmlElement("importoTotale", Form = XmlSchemaForm.Unqualified, Order = 8)]
        public decimal importoTotale { get; set; }

    }

    [Serializable]
    [XmlType(Namespace = "http://www.govpay.it/servizi/commons/")]
    public class FlussoRendicontazione : EstremiFlussoRendicontazione {

        [Serializable]
        [XmlType(AnonymousType = true, Namespace = "http://www.govpay.it/servizi/commons/")]
        public class DatiPagamento {

            [Serializable]
            [XmlType(Namespace = "http://www.govpay.it/servizi/commons/")]
            public enum EsitoRendicontazione {

                ESEGUITO,
                REVOCATO,
                ESEGUITO_SENZA_RPT

            }

            [XmlElement("codApplicazione", Form = XmlSchemaForm.Unqualified, Order = 0)]
            public string codApplicazione { get; set; }

            [XmlElement("codSingoloVersamentoEnte", Form = XmlSchemaForm.Unqualified, Order = 1)]
            public string codSingoloVersamentoEnte { get; set; }

            [XmlElement("codDominio", Form = XmlSchemaForm.Unqualified, Order = 2)]
            public string codDominio { get; set; }

            [XmlElement("iuv", Form = XmlSchemaForm.Unqualified, Order = 3)]
            public string iuv { get; set; }

            [XmlElement("importoRendicontato", Form = XmlSchemaForm.Unqualified, Order = 4)]
            public decimal importoRendicontato { get; set; }

            [XmlElement("iur", Form = XmlSchemaForm.Unqualified, Order = 5)]
            public string iur { get; set; }

            [XmlElement("dataRendicontazione", Form = XmlSchemaForm.Unqualified, Order = 6)]
            public DateTime dataRendicontazione { get; set; }

            [XmlElement("esitoRendicontazione", Form = XmlSchemaForm.Unqualified, Order = 7)]
            public EsitoRendicontazione esitoRendicontazione { get; set; }
        }

        [XmlElement("pagamento", Form = XmlSchemaForm.Unqualified, Order = 0)]
        public DatiPagamento[] pagamento { get; set; }
    }

    [Serializable]
    [XmlType(Namespace = "http://www.govpay.it/servizi/commons/")]
    public class RichiestaStorno {

        [Serializable]
        [XmlType(Namespace = "http://www.govpay.it/servizi/commons/")]
        public enum StatoRevoca {

            RR_ATTIVATA,
            RR_ERRORE_INVIO_A_NODO,
            RR_ACCETTATA_NODO,
            RR_RIFIUTATA_NODO,
            ER_ACCETTATA_PA,
            ER_RIFIUTATA_PA

        }

        [XmlElement("codRichiesta", Form = XmlSchemaForm.Unqualified, Order = 0)]
        public string codRichiesta { get; set; }

        [XmlElement("dataRichiesta", Form = XmlSchemaForm.Unqualified, Order = 1)]
        public DateTime dataRichiesta { get; set; }

        [XmlElement("stato", Form = XmlSchemaForm.Unqualified, Order = 2)]
        public StatoRevoca stato { get; set; }

        [XmlElement("descrizioneStato", Form = XmlSchemaForm.Unqualified, Order = 3)]
        public string descrizioneStato { get; set; }

        [XmlElement("rr", Form = XmlSchemaForm.Unqualified, DataType = "base64Binary", Order = 4)]
        public byte[] rr { get; set; }

        [XmlElement("er", Form = XmlSchemaForm.Unqualified, DataType = "base64Binary", Order = 5)]
        public byte[] er { get; set; }

        [XmlElement("importoStornato", Form = XmlSchemaForm.Unqualified, Order = 6)]
        public decimal importoStornato { get; set; }

    }

    [Serializable]
    [XmlType(Namespace = "http://www.govpay.it/servizi/commons/")]
    public class Transazione {

        [Serializable]
        [XmlType(Namespace = "http://www.govpay.it/servizi/commons/")]
        public enum ModelloPagamento {

            IMMEDIATO,
            IMMEDIATO_MULTIBENEFICIARIO,
            DIFFERITO,
            ATTIVATO_PRESSO_PSP

        }

        [Serializable]
        [XmlType(Namespace = "http://www.govpay.it/servizi/commons/")]
        public enum StatoTransazione {

            RPT_ATTIVATA,
            RPT_ERRORE_INVIO_A_NODO,
            RPT_RICEVUTA_NODO,
            RPT_RIFIUTATA_NODO,
            RPT_ACCETTATA_NODO,
            RPT_RIFIUTATA_PSP,
            RPT_ACCETTATA_PSP,
            RPT_ERRORE_INVIO_A_PSP,
            RPT_INVIATA_A_PSP,
            RPT_DECORSI_TERMINI,
            RT_RICEVUTA_NODO,
            RT_RIFIUTATA_NODO,
            RT_ACCETTATA_NODO,
            RT_ACCETTATA_PA,
            RT_RIFIUTATA_PA,
            RT_ESITO_SCONOSCIUTO_PA

        }

        [Serializable]
        [XmlType(Namespace = "http://www.govpay.it/servizi/commons/")]
        public enum EsitoTransazione {

            PAGAMENTO_ESEGUITO,
            PAGAMENTO_NON_ESEGUITO,
            PAGAMENTO_PARZIALMENTE_ESEGUITO,
            DECORRENZA_TERMINI,
            DECORRENZA_TERMINI_PARZIALE

        }

        [Serializable]
        [XmlType(Namespace = "http://www.govpay.it/servizi/commons/")]
        public class Canale {

            [Serializable]
            [XmlType(Namespace = "http://www.govpay.it/servizi/commons/")]
            public enum TipoVersamento {

                BBT,
                BP,
                AD,
                CP,
                OBEP,
                PO

            }

            [XmlElement("codPsp", Form = XmlSchemaForm.Unqualified, Order = 0)]
            public string codPsp { get; set; }

            [XmlElement("codCanale", Form = XmlSchemaForm.Unqualified, Order = 1)]
            public string codCanale { get; set; }

            [XmlElement("tipoVersamento", Form = XmlSchemaForm.Unqualified, Order = 2)]
            public TipoVersamento tipoVersamento { get; set; }

        }

        [Serializable]
        [XmlType(Namespace = "http://www.govpay.it/servizi/commons/")]
        public class Pagamento {

            [Serializable]
            [XmlType(AnonymousType = true, Namespace = "http://www.govpay.it/servizi/commons/")]
            public class Allegato {

                [Serializable]
                [XmlType(Namespace = "http://www.govpay.it/servizi/commons/")]
                public enum TipoAllegato {

                    ES,
                    BD

                }

                [XmlElement("tipo", Form = XmlSchemaForm.Unqualified, Order = 0)]
                public TipoAllegato tipo { get; set; }

                [XmlElement("testo", Form = XmlSchemaForm.Unqualified, DataType = "base64Binary", Order = 1)]
                public byte[] testo { get; set; }
            }

            [XmlElement("codSingoloVersamentoEnte", Form = XmlSchemaForm.Unqualified, Order = 0)]
            public string codSingoloVersamentoEnte { get; set; }

            [XmlElement("importoPagato", Form = XmlSchemaForm.Unqualified, Order = 1)]
            public decimal importoPagato { get; set; }

            [XmlElement("iur", Form = XmlSchemaForm.Unqualified, Order = 2)]
            public string iur { get; set; }

            [XmlElement("dataPagamento", Form = XmlSchemaForm.Unqualified, DataType = "date", Order = 3)]
            public DateTime dataPagamento { get; set; }

            [XmlElement("dataAcquisizione", Form = XmlSchemaForm.Unqualified, DataType = "date", Order = 4)]
            public DateTime dataAcquisizione { get; set; }

            [XmlElement("commissioniPsp", Form = XmlSchemaForm.Unqualified, Order = 5)]
            public decimal commissioniPsp { get; set; }

            [XmlElement("allegato", Form = XmlSchemaForm.Unqualified, Order = 6)]
            public Allegato allegato { get; set; }

            [XmlElement("dataAcquisizioneRevoca", Form = XmlSchemaForm.Unqualified, DataType = "date", Order = 7)]
            public DateTime dataAcquisizioneRevoca { get; set; }

            [XmlElement("causaleRevoca", Form = XmlSchemaForm.Unqualified, Order = 8)]
            public string causaleRevoca { get; set; }

            [XmlElement("datiRevoca", Form = XmlSchemaForm.Unqualified, Order = 9)]
            public string datiRevoca { get; set; }

            [XmlElement("importoRevocato", Form = XmlSchemaForm.Unqualified, Order = 10)]
            public decimal importoRevocato { get; set; }

            [XmlElement("esitoRevoca", Form = XmlSchemaForm.Unqualified, Order = 11)]
            public string esitoRevoca { get; set; }

            [XmlElement("datiEsitoRevoca", Form = XmlSchemaForm.Unqualified, Order = 12)]
            public string datiEsitoRevoca { get; set; }

        }

        [XmlElement("data", Form = XmlSchemaForm.Unqualified, DataType = "date", Order = 0)]
        public DateTime data { get; set; }

        [XmlElement("modello", Form = XmlSchemaForm.Unqualified, Order = 1)]
        public ModelloPagamento modello { get; set; }

        [XmlElement("codDominio", Form = XmlSchemaForm.Unqualified, Order = 2)]
        public string codDominio { get; set; }

        [XmlElement("iuv", Form = XmlSchemaForm.Unqualified, Order = 3)]
        public string iuv { get; set; }

        [XmlElement("ccp", Form = XmlSchemaForm.Unqualified, Order = 4)]
        public string ccp { get; set; }

        [XmlElement("canale", Form = XmlSchemaForm.Unqualified, Order = 5)]
        public Canale canale { get; set; }

        [XmlElement("stato", Form = XmlSchemaForm.Unqualified, Order = 6)]
        public StatoTransazione stato { get; set; }

        [XmlElement("descrizioneStato", Form = XmlSchemaForm.Unqualified, Order = 7)]
        public string descrizioneStato { get; set; }

        [XmlElement("esito", Form = XmlSchemaForm.Unqualified, Order = 8)]
        public EsitoTransazione esito { get; set; }

        [XmlElement("rpt", Form = XmlSchemaForm.Unqualified, DataType = "base64Binary", Order = 9)]
        public byte[] rpt { get; set; }

        [XmlElement("rt", Form = XmlSchemaForm.Unqualified, DataType = "base64Binary", Order = 10)]
        public byte[] rt { get; set; }

        [XmlElement("richiestaStorno", Form = XmlSchemaForm.Unqualified, Order = 11)]
        public RichiestaStorno[] richiestaStorno { get; set; }

        [XmlElement("pagamento", Form = XmlSchemaForm.Unqualified, Order = 12)]
        public Pagamento[] pagamento { get; set; }
    }

    [XmlInclude(typeof(Versamento))]
    [Serializable]
    [XmlType(Namespace = "http://www.govpay.it/servizi/commons/")]
    public class EstremiVersamento {

        [XmlElement("codApplicazione", Form = XmlSchemaForm.Unqualified, Order = 0)]
        public string codApplicazione { get; set; }

        [XmlElement("codVersamentoEnte", Form = XmlSchemaForm.Unqualified, Order = 1)]
        public string codVersamentoEnte { get; set; }

        [XmlElement("iuv", Form = XmlSchemaForm.Unqualified, Order = 2)]
        public string iuv { get; set; }
    }

    [Serializable]
    [XmlType(Namespace = "http://www.govpay.it/servizi/commons/")]
    public class Versamento : EstremiVersamento {

        [Serializable]
        [XmlType(Namespace = "http://www.govpay.it/servizi/commons/")]
        public class Anagrafica {

            [XmlElement("codUnivoco", Form = XmlSchemaForm.Unqualified, Order = 0)]
            public string codUnivoco { get; set; }

            [XmlElement("ragioneSociale", Form = XmlSchemaForm.Unqualified, Order = 1)]
            public string ragioneSociale { get; set; }

            [XmlElement("indirizzo", Form = XmlSchemaForm.Unqualified, Order = 2)]
            public string indirizzo { get; set; }

            [XmlElement("civico", Form = XmlSchemaForm.Unqualified, Order = 3)]
            public string civico { get; set; }

            [XmlElement("cap", Form = XmlSchemaForm.Unqualified, Order = 4)]
            public string cap { get; set; }

            [XmlElement("localita", Form = XmlSchemaForm.Unqualified, Order = 5)]
            public string localita { get; set; }

            [XmlElement("provincia", Form = XmlSchemaForm.Unqualified, Order = 6)]
            public string provincia { get; set; }

            [XmlElement("nazione", Form = XmlSchemaForm.Unqualified, Order = 7)]
            public string nazione { get; set; }

            [XmlElement("email", Form = XmlSchemaForm.Unqualified, Order = 8)]
            public string email { get; set; }

            [XmlElement("telefono", Form = XmlSchemaForm.Unqualified, Order = 9)]
            public string telefono { get; set; }

            [XmlElement("cellulare", Form = XmlSchemaForm.Unqualified, Order = 10)]
            public string cellulare { get; set; }

            [XmlElement("fax", Form = XmlSchemaForm.Unqualified, Order = 11)]
            public string fax { get; set; }
        }

        [Serializable]
        [XmlType(AnonymousType = true)]
        public class SpezzoneCausaleStrutturata {

            [XmlElement("causale", Form = XmlSchemaForm.Unqualified, Order = 0)]
            public string causale { get; set; }

            [XmlElement("importo", Form = XmlSchemaForm.Unqualified, Order = 1)]
            public decimal importo { get; set; }
        }

        [Serializable]
        [XmlType(AnonymousType = true, Namespace = "http://www.govpay.it/servizi/commons/")]
        public class SingoloVersamento {

            [Serializable]
            [XmlType(AnonymousType = true)]
            public class BolloTelematico {

                [Serializable]
                [XmlType(Namespace = "http://www.govpay.it/servizi/commons/")]
                public enum TipoBollo {

                    [XmlEnum("01")]
                    BolloDigitale

                }

                [XmlElement("tipo", Form = XmlSchemaForm.Unqualified, Order = 0)]
                public TipoBollo tipo { get; set; }

                [XmlElement("hash", Form = XmlSchemaForm.Unqualified, Order = 1)]
                public string hash { get; set; }

                [XmlElement("provincia", Form = XmlSchemaForm.Unqualified, Order = 2)]
                public string provincia { get; set; }
            }

            [Serializable]
            [XmlType(AnonymousType = true)]
            public class Tributo {

                [Serializable]
                [XmlType(Namespace = "http://www.govpay.it/servizi/commons/")]
                public enum TipoContabilità {

                    CAPITOLO,
                    SPECIALE,
                    SIOPE,
                    ALTRO

                }

                [XmlElement("ibanAccredito", Form = XmlSchemaForm.Unqualified, Order = 0)]
                public string ibanAccredito { get; set; }

                [XmlElement("tipoContabilita", Form = XmlSchemaForm.Unqualified, Order = 1)]
                public TipoContabilità tipoContabilita { get; set; }

                [XmlElement("codContabilita", Form = XmlSchemaForm.Unqualified, Order = 2)]
                public string codContabilita { get; set; }

            }

            [XmlElement("codSingoloVersamentoEnte", Form = XmlSchemaForm.Unqualified, Order = 0)]
            public string codSingoloVersamentoEnte { get; set; }

            [XmlElement("importo", Form = XmlSchemaForm.Unqualified, Order = 1)]
            public decimal importo { get; set; }

            [XmlElement("note", Form = XmlSchemaForm.Unqualified, Order = 2)]
            public string note { get; set; }

            [XmlElement("codTributo", Form = XmlSchemaForm.Unqualified, Order = 3)]
            public string codTributo { get; set; }

            [XmlElement("bolloTelematico", Form = XmlSchemaForm.Unqualified, Order = 3)]
            public BolloTelematico bolloTelematico { get; set; }

            [XmlElement("tributo", Form = XmlSchemaForm.Unqualified, Order = 3)]
            public Tributo tributo { get; set; }

        }

        [XmlElement("codDominio", Form = XmlSchemaForm.Unqualified, Order = 0)]
        public string codDominio { get; set; }

        [XmlElement("codUnitaOperativa", Form = XmlSchemaForm.Unqualified, Order = 1)]
        public string codUnitaOperativa { get; set; }

        [XmlElement("debitore", Form = XmlSchemaForm.Unqualified, Order = 2)]
        public Anagrafica debitore { get; set; }

        [XmlElement("importoTotale", Form = XmlSchemaForm.Unqualified, Order = 3)]
        public decimal importoTotale { get; set; }

        [XmlElement("dataScadenza", Form = XmlSchemaForm.Unqualified, Order = 4)]
        public DateTime dataScadenza { get; set; }

        [XmlElement("aggiornabile", Form = XmlSchemaForm.Unqualified, Order = 5)]
        public bool aggiornabile { get; set; }

        [XmlElement("codDebito", Form = XmlSchemaForm.Unqualified, Order = 6)]
        public string codDebito { get; set; }

        [XmlElement("annoTributario", Form = XmlSchemaForm.Unqualified, Order = 7)]
        public int annoTributario { get; set; }

        [XmlElement("bundlekey", Form = XmlSchemaForm.Unqualified, Order = 8)]
        public string bundlekey { get; set; }

        [XmlElement("causale", typeof(string), Form = XmlSchemaForm.Unqualified, Order = 9)]
        public string causale { get; set; }

        [XmlElement("spezzoneCausale", typeof(string), Form = XmlSchemaForm.Unqualified, Order = 9)]
        public string[] spezzoneCausale { get; set; }

        [XmlElement("spezzoneCausaleStrutturata", typeof(SpezzoneCausaleStrutturata), Form = XmlSchemaForm.Unqualified, Order = 9)]
        public SpezzoneCausaleStrutturata[] spezzoneCausaleStrutturata { get; set; }
        
        [XmlElement("singoloVersamento", Form = XmlSchemaForm.Unqualified, Order = 10)]
        public SingoloVersamento[] singoloVersamento { get; set; }
    }

    [Serializable]
    [XmlType(Namespace = "http://www.govpay.it/servizi/commons/")]
    public class IUVGenerato {

        [XmlElement("codApplicazione", Form = XmlSchemaForm.Unqualified, Order = 0)]
        public string codApplicazione { get; set; }

        [XmlElement("codVersamentoEnte", Form = XmlSchemaForm.Unqualified, Order = 1)]
        public string codVersamentoEnte { get; set; }

        [XmlElement("codDominio", Form = XmlSchemaForm.Unqualified, Order = 2)]
        public string codDominio { get; set; }

        [XmlElement("iuv", Form = XmlSchemaForm.Unqualified, Order = 3)]
        public string iuv { get; set; }

        [XmlElement("qrCode", Form = XmlSchemaForm.Unqualified, DataType = "base64Binary", Order = 4)]
        public byte[] qrCode { get; set; }

        [XmlElement("barCode", Form = XmlSchemaForm.Unqualified, DataType = "base64Binary", Order = 5)]
        public byte[] barCode { get; set; }

    }

    [Serializable]
    [XmlType(Namespace = "http://www.govpay.it/servizi/commons/")]
    public class gpResponseBody {

        [Serializable]
        [XmlType(Namespace = "http://www.govpay.it/servizi/commons/")]
        public enum EsitoOperazione {

            /// <summary>
            /// Eseguita
            /// </summary>
            [XmlEnum("OK")]
            Eseguita,

            /// <summary>
            /// Errore non atteso
            /// </summary>
            [XmlEnum("INTERNAL")]
            ErroreInterno,

            /// <summary>
            /// Principal non fornito
            /// </summary>
            [XmlEnum("AUT_000")]
            AUT_000,

            /// <summary>
            /// Principal non associato ad alcuna Applicazione
            /// </summary>
            [XmlEnum("AUT_001")]
            AUT_001,

            /// <summary>
            /// Principal non associato ad alcun Portale
            /// </summary>
            [XmlEnum("AUT_002")]
            AUT_002,

            /// <summary>
            /// Applicazione inesistente
            /// </summary>
            [XmlEnum("APP_000")]
            APP_000,

            /// <summary>
            /// Applicazione disabilitata
            /// </summary>
            [XmlEnum("APP_001")]
            APP_001,

            /// <summary>
            /// Applicazione autenticata diversa dalla chiamante
            /// </summary>
            [XmlEnum("APP_002")]
            APP_002,

            /// <summary>
            /// Dominio inesistente
            /// </summary>
            [XmlEnum("DOM_000")]
            DOM_000,

            /// <summary>
            /// Dominio disabilitato
            /// </summary>
            [XmlEnum("DOM_001")]
            DOM_001,

            /// <summary>
            /// Dominio configurato per la generazione personalizzata degli IUV
            /// </summary>
            [XmlEnum("DOM_002")]
            DOM_002,

            /// <summary>
            /// Dominio configurato per la generazione automatica degli IUV
            /// </summary>
            [XmlEnum("DOM_003")]
            DOM_003,

            /// <summary>
            /// Errore di comunicazione con il Nodo dei Pagamenti
            /// </summary>
            [XmlEnum("NDP_000")]
            NDP_000,

            /// <summary>
            /// Ricevuto FAULT dal Nodo dei Pagamenti
            /// </summary>
            [XmlEnum("NDP_001")]
            NDP_001,

            /// <summary>
            /// I versamenti di una richiesta di pagamento devono afferire alla stessa stazione intermediario
            /// </summary>
            [XmlEnum("PAG_000")]
            PAG_000,

            /// <summary>
            /// Il canale indicato non supporta il pagamento di più versamenti
            /// </summary>
            [XmlEnum("PAG_001")]
            PAG_001,

            /// <summary>
            /// Il canale indicato non può eseguire pagamenti ad iniziativa Ente
            /// </summary>
            [XmlEnum("PAG_002")]
            PAG_002,

            /// <summary>
            /// Il canale indicato non supporta il pagamento di Marca da Bollo Telematica
            /// </summary>
            [XmlEnum("PAG_003")]
            PAG_003,

            /// <summary>
            /// Il tipo di pagamento "Addebito Diretto" richiede di specificare un IBAN di Addebito
            /// </summary>
            [XmlEnum("PAG_004")]
            PAG_004,

            /// <summary>
            /// Il tipo di pagamento "On-line Banking e-Payment" consente il pagamento di versamenti con al più un singolo versamento
            /// </summary>
            [XmlEnum("PAG_005")]
            PAG_005,

            /// <summary>
            /// Non è possibile pagare un versamento in stato diverso da "non eseguito"
            /// </summary>
            [XmlEnum("PAG_006")]
            PAG_006,

            /// <summary>
            /// Non è possibile pagare un versamento scaduto
            /// </summary>
            [XmlEnum("PAG_007")]
            PAG_007,

            /// <summary>
            /// Transazione di pagamento inesistente
            /// </summary>
            [XmlEnum("PAG_008")]
            PAG_008,

            /// <summary>
            /// Pagamento già stornato
            /// </summary>
            [XmlEnum("PAG_009")]
            PAG_009,

            /// <summary>
            /// Richiesta di storno inesistente
            /// </summary>
            [XmlEnum("PAG_010")]
            PAG_010,

            /// <summary>
            /// Nessun pagamento da stornare
            /// </summary>
            [XmlEnum("PAG_011")]
            PAG_011,

            /// <summary>
            /// Portale inesistente
            /// </summary>
            [XmlEnum("PRT_000")]
            PRT_000,

            /// <summary>
            /// Portale disabilitato
            /// </summary>
            [XmlEnum("PRT_001")]
            PRT_001,

            /// <summary>
            /// Portale autenticato diverso dal chiamante
            /// </summary>
            [XmlEnum("PRT_002")]
            PRT_002,

            /// <summary>
            /// Portale non autorizzato a pagare i versamenti dell'applicazione indicata
            /// </summary>
            [XmlEnum("PRT_003")]
            PRT_003,

            /// <summary>
            /// Portale non autorizzato a visualizzare l'esito della transazione indicata
            /// </summary>
            [XmlEnum("PRT_004")]
            PRT_004,

            /// <summary>
            /// Portale non autorizzato all'operazione richiesta
            /// </summary>
            [XmlEnum("PRT_005")]
            PRT_005,

            /// <summary>
            /// Il canale non esiste
            /// </summary>
            [XmlEnum("PSP_000")]
            PSP_000,

            /// <summary>
            /// Il canale è disabilitato
            /// </summary>
            [XmlEnum("PSP_001")]
            PSP_001,

            /// <summary>
            /// Il flusso di rendicontazione cercato non esiste
            /// </summary>
            [XmlEnum("RND_000")]
            RND_000,

            /// <summary>
            /// Applicazione non abilitata all'acquisizione del flusso indicato
            /// </summary>
            [XmlEnum("RND_001")]
            RND_001,

            /// <summary>
            /// Stazione inesistente
            /// </summary>
            [XmlEnum("STA_000")]
            STA_000,

            /// <summary>
            /// Stazione disabilitata
            /// </summary>
            [XmlEnum("STA_001")]
            STA_001,

            /// <summary>
            /// Tributo inesistente
            /// </summary>
            [XmlEnum("TRB_000")]
            TRB_000,

            /// <summary>
            /// Unità operativa inesistente
            /// </summary>
            [XmlEnum("UOP_000")]
            UOP_000,

            /// <summary>
            /// Unità operativa disabilitata
            /// </summary>
            [XmlEnum("UOP_001")]
            UOP_001,

            /// <summary>
            /// Versamento non pagabile ad iniziativa PSP
            /// </summary>
            [XmlEnum("VER_000")]
            VER_000,

            /// <summary>
            /// Il versamento presenta singoli versamenti con codSingoloVersamento non univoci
            /// </summary>
            [XmlEnum("VER_001")]
            VER_001,

            /// <summary>
            /// La somma degli importi dei singoli versamenti non corrisponde all'importo totale del versamento
            /// </summary>
            [XmlEnum("VER_002")]
            VER_002,

            /// <summary>
            /// Non è possibile aggiornare un versamento in stato diverso da "non eseguito" o "annullato"
            /// </summary>
            [XmlEnum("VER_003")]
            VER_003,

            /// <summary>
            /// Non è possibile aggiornare un versamento cambiando l'unità operativa beneficiaria
            /// </summary>
            [XmlEnum("VER_004")]
            VER_004,

            /// <summary>
            /// Non è possibile aggiornare un versamento cambiando il numero di singoli importi
            /// </summary>
            [XmlEnum("VER_005")]
            VER_005,

            /// <summary>
            /// Non è possibile aggiornare un versamento modificando i codici dei singoli versamenti
            /// </summary>
            [XmlEnum("VER_006")]
            VER_006,

            /// <summary>
            /// Non è possibile aggiornare un versamento modificando la tipologia di tributo dei singoli versamenti
            /// </summary>
            [XmlEnum("VER_007")]
            VER_007,

            /// <summary>
            /// Versamento inesistente
            /// </summary>
            [XmlEnum("VER_008")]
            VER_008,

            /// <summary>
            /// Non è possibile annullare un versamento in stato diverso da "non eseguito"
            /// </summary>
            [XmlEnum("VER_009")]
            VER_009,

            /// <summary>
            /// L'aggiornamento del versamento dall'applicazione ha dato esito "pagamento scaduto"
            /// </summary>
            [XmlEnum("VER_010")]
            VER_010,

            /// <summary>
            /// L'aggiornamento del versamento dall'applicazione ha dato esito "pagamento sconosciuto"
            /// </summary>
            [XmlEnum("VER_011")]
            VER_011,

            /// <summary>
            /// L'aggiornamento del versamento dall'applicazione ha dato esito "pagamento duplicato"
            /// </summary>
            [XmlEnum("VER_012")]
            VER_012,

            /// <summary>
            /// L'aggiornamento del versamento dall'applicazione ha dato esito "pagamento annullato"
            /// </summary>
            [XmlEnum("VER_013")]
            VER_013,

            /// <summary>
            /// L'aggiornamento del versamento dall'applicazione è fallito
            /// </summary>
            [XmlEnum("VER_014")]
            VER_014,

            /// <summary>
            /// Aggiornamento non consentito su questo versamento
            /// </summary>
            /// <remarks>
            /// AggiornaSeEsiste = false
            /// </remarks>
            [XmlEnum("VER_015")]
            VER_015,

            /// <summary>
            /// Non è possibile notificare un pagamento per un versamento in stato diverso da "non eseguito" o "annullato"
            /// </summary>
            [XmlEnum("VER_016")]
            VER_016,

            /// <summary>
            /// IUV da caricare non conforme alle specifiche AgID
            /// </summary>
            [XmlEnum("VER_017")]
            VER_017,

            /// <summary>
            /// IUV da caricare gia' associato ad un diverso Versamento
            /// </summary>
            [XmlEnum("VER_018")]
            VER_018,

            /// <summary>
            /// Applicazione non autorizzata all'autodeterminazione dei tributi
            /// </summary>
            [XmlEnum("VER_019")]
            VER_019,

            /// <summary>
            /// IBAN di accredito non censito
            /// </summary>
            [XmlEnum("VER_020")]
            VER_020,

            /// <summary>
            /// Applicazione non autorizzata all'autodeterminazione dei tributi per il dominio indicato
            /// </summary>
            [XmlEnum("VER_021")]
            VER_021,

            /// <summary>
            /// Applicazione non autorizzata alla gestione del tributo indicato
            /// </summary>
            [XmlEnum("VER_022")]
            VER_022,

            /// <summary>
            /// Non è possibile aggiornare un versamento modificando l'IBAN di accredito
            /// </summary>
            [XmlEnum("VER_023")]
            VER_023,

            /// <summary>
            /// Sessione di scelta sconosciuta al WISP
            /// </summary>
            [XmlEnum("WISP_000")]
            WISP_000,

            /// <summary>
            /// Sessione di scelta scaduta per timeout al WISP
            /// </summary>
            [XmlEnum("WISP_001")]
            WISP_001,

            /// <summary>
            /// Canale scelto non presente in anagrafica
            /// </summary>
            [XmlEnum("WISP_002")]
            WISP_002,

            /// <summary>
            /// Il debitore non ha operato alcuna scelta sul WISP
            /// </summary>
            [XmlEnum("WISP_003")]
            WISP_003,

            /// <summary>
            /// Il debitore ha scelto di pagare dopo tramite avviso di pagamento
            /// </summary>
            [XmlEnum("WISP_004")]
            WISP_004

        }

        [XmlElement("codOperazione", Form = XmlSchemaForm.Unqualified, Order = 0)]
        public string codOperazione { get; set; }

        [XmlElement("codEsitoOperazione", Form = XmlSchemaForm.Unqualified, Order = 1)]
        public EsitoOperazione codEsitoOperazione { get; set; }

        [XmlElement("descrizioneEsitoOperazione", Form = XmlSchemaForm.Unqualified, Order = 2)]
        public string descrizioneEsitoOperazione { get; set; }
    }

    #endregion

    #region "Strutture dedicate (applicazioni)"

    [Serializable]
    [XmlType(AnonymousType = true, Namespace = "http://www.govpay.it/servizi/gpApp/")]
    public class gpGeneraIuvRequestBody {

        [Serializable]
        [XmlType(AnonymousType = true, Namespace = "http://www.govpay.it/servizi/gpApp/")]
        public class IUVRichiesto {

            [XmlElement("codVersamentoEnte", Form = XmlSchemaForm.Unqualified, Order = 0)]
            public string codVersamentoEnte { get; set; }

            [XmlElement("importoTotale", Form = XmlSchemaForm.Unqualified, Order = 1)]
            public decimal importoTotale { get; set; }
        }

        [XmlElement("codApplicazione", Form = XmlSchemaForm.Unqualified, Order = 0)]
        public string codApplicazione { get; set; }

        [XmlElement("codDominio", Form = XmlSchemaForm.Unqualified, Order = 1)]
        public string codDominio { get; set; }

        [XmlElement("iuvRichiesto", Form = XmlSchemaForm.Unqualified, Order = 2)]
        public IUVRichiesto[] iuvRichiesto { get; set; }
    }

    [Serializable]
    [XmlType(AnonymousType = true, Namespace = "http://www.govpay.it/servizi/gpApp/")]
    public class gpGeneraIuvResponseBody : gpResponseBody {

        [XmlElement("iuvGenerato", Form = XmlSchemaForm.Unqualified, Order = 0)]
        public IUVGenerato[] iuvGenerato { get; set; }
    }

    [Serializable]
    [XmlType(AnonymousType = true, Namespace = "http://www.govpay.it/servizi/gpApp/")]
    public class gpCaricaIuvRequestBody {

        [Serializable]
        [XmlType(AnonymousType = true, Namespace = "http://www.govpay.it/servizi/gpApp/")]
        public class IUVGenerato {

            [XmlElement("iuv", Form = XmlSchemaForm.Unqualified, Order = 0)]
            public string iuv { get; set; }

            [XmlElement("codVersamentoEnte", Form = XmlSchemaForm.Unqualified, Order = 1)]
            public string codVersamentoEnte { get; set; }

            [XmlElement("importoTotale", Form = XmlSchemaForm.Unqualified, Order = 2)]
            public decimal importoTotale { get; set; }
        }

        [XmlElement("codApplicazione", Form = XmlSchemaForm.Unqualified, Order = 0)]
        public string codApplicazione { get; set; }

        [XmlElement("codDominio", Form = XmlSchemaForm.Unqualified, Order = 1)]
        public string codDominio { get; set; }

        [XmlElement("iuvGenerato", Form = XmlSchemaForm.Unqualified, Order = 2)]
        public IUVGenerato[] iuvGenerato { get; set; }
    }

    [Serializable]
    [XmlType(AnonymousType = true, Namespace = "http://www.govpay.it/servizi/gpApp/")]
    public class gpCaricaIuvResponseBody : gpResponseBody {

        [XmlElement("iuvCaricato", Form = XmlSchemaForm.Unqualified, Order = 0)]
        public IUVGenerato[] iuvCaricato { get; set; }
    }

    [Serializable]
    [XmlType(AnonymousType = true, Namespace = "http://www.govpay.it/servizi/gpApp/")]
    public class gpCaricaVersamentoRequestBody {

        [XmlElement("generaIuv", Form = XmlSchemaForm.Unqualified, Order = 0)]
        public bool generaIuv { get; set; }

        [XmlElement(Form = XmlSchemaForm.Unqualified, Order = 1)]
        [System.ComponentModel.DefaultValueAttribute(true)]
        public bool aggiornaSeEsiste { get; set; }

        [XmlElement("versamento", Form = XmlSchemaForm.Unqualified, Order = 2)]
        public Versamento versamento { get; set; }

    }

    [Serializable]
    [XmlType(AnonymousType = true, Namespace = "http://www.govpay.it/servizi/gpApp/")]
    public class gpCaricaVersamentoResponseBody : gpResponseBody {

        [XmlElement("iuvGenerato", Form = XmlSchemaForm.Unqualified, Order = 0)]
        public IUVGenerato iuvGenerato { get; set; }
    }

    [Serializable]
    [XmlType(AnonymousType = true, Namespace = "http://www.govpay.it/servizi/gpApp/")]
    public class gpAnnullaVersamento {

        [XmlElement("codApplicazione", Form = XmlSchemaForm.Unqualified, Order = 0)]
        public string codApplicazione { get; set; }

        [XmlElement("codVersamentoEnte", Form = XmlSchemaForm.Unqualified, Order = 1)]
        public string codVersamentoEnte { get; set; }
    }

    [Serializable]
    [XmlType(AnonymousType = true, Namespace = "http://www.govpay.it/servizi/gpApp/")]
    public class gpNotificaPagamentoRequestBody {

        [XmlElement("codApplicazione", Form = XmlSchemaForm.Unqualified, Order = 0)]
        public string codApplicazione { get; set; }

        [XmlElement("codVersamentoEnte", Form = XmlSchemaForm.Unqualified, Order = 1)]
        public string codVersamentoEnte { get; set; }
    }

    [Serializable]
    [XmlType(AnonymousType = true, Namespace = "http://www.govpay.it/servizi/gpApp/")]
    public class gpChiediStatoVersamentoRequestBody {

        [XmlElement("codApplicazione", Form = XmlSchemaForm.Unqualified, Order = 0)]
        public string codApplicazione { get; set; }

        [XmlElement("codVersamentoEnte", Form = XmlSchemaForm.Unqualified, Order = 1)]
        public string codVersamentoEnte { get; set; }
    }

    [Serializable]
    [XmlType(AnonymousType = true, Namespace = "http://www.govpay.it/servizi/gpApp/")]
    public class gpChiediStatoVersamentoResponseBody : gpResponseBody {

        [Serializable]
        [XmlType(Namespace = "http://www.govpay.it/servizi/commons/")]
        public enum StatoVersamento {

            NON_ESEGUITO,
            ESEGUITO,
            PARZIALMENTE_ESEGUITO,
            ANNULLATO,
            ANOMALO,
            ESEGUITO_SENZA_RPT

        }

        [XmlElement("codApplicazione", Form = XmlSchemaForm.Unqualified, Order = 0)]
        public string codApplicazione { get; set; }

        [XmlElement("codVersamentoEnte", Form = XmlSchemaForm.Unqualified, Order = 1)]
        public string codVersamentoEnte { get; set; }

        [XmlElement("stato", Form = XmlSchemaForm.Unqualified, Order = 2)]
        public StatoVersamento stato { get; set; }

        [XmlElement("transazione", Form = XmlSchemaForm.Unqualified, Order = 3)]
        public Transazione[] transazione { get; set; }
    }

    [Serializable]
    [XmlType(AnonymousType = true, Namespace = "http://www.govpay.it/servizi/gpApp/")]
    public class gpChiediListaFlussiRendicontazioneRequestBody {

        [XmlElement("codApplicazione", Form = XmlSchemaForm.Unqualified, Order = 0)]
        public string codApplicazione { get; set; }
    }

    [Serializable]
    [XmlType(AnonymousType = true, Namespace = "http://www.govpay.it/servizi/gpApp/")]
    public class gpChiediListaFlussiRendicontazioneResponseBody : gpResponseBody {

        [XmlElement("codApplicazione", Form = XmlSchemaForm.Unqualified, Order = 0)]
        public string codApplicazione { get; set; }

        [XmlElement("flussoRendicontazione", Form = XmlSchemaForm.Unqualified, Order = 1)]
        public EstremiFlussoRendicontazione[] flussoRendicontazione { get; set; }
    }

    [Serializable]
    [XmlType(AnonymousType = true, Namespace = "http://www.govpay.it/servizi/gpApp/")]
    public class gpChiediFlussoRendicontazioneRequestBody {

        [XmlElement("codApplicazione", Form = XmlSchemaForm.Unqualified, Order = 0)]
        public string codApplicazione { get; set; }

        [XmlElement("annoRiferimento", Form = XmlSchemaForm.Unqualified, DataType = "gYear", Order = 1)]
        public string annoRiferimento { get; set; }

        [XmlElement("codFlusso", Form = XmlSchemaForm.Unqualified, Order = 2)]
        public string codFlusso { get; set; }
    }

    [Serializable]
    [XmlType(AnonymousType = true, Namespace = "http://www.govpay.it/servizi/gpApp/")]
    public class gpChiediFlussoRendicontazioneResponseBody : gpResponseBody {

        [XmlElement("codApplicazione", Form = XmlSchemaForm.Unqualified, Order = 0)]
        public string codApplicazione { get; set; }

        [XmlElement("flussoRendicontazione", Form = XmlSchemaForm.Unqualified, Order = 1)]
        public FlussoRendicontazione flussoRendicontazione { get; set; }
    }

    #endregion

    #region "Messaggi SOAP"

    [MessageContract(IsWrapped = false)]
    public class gpGeneraIuvRequest {

        [MessageBodyMember(Name = "gpGeneraIuv", Namespace = "http://www.govpay.it/servizi/gpApp/", Order = 0)]
        public gpGeneraIuvRequestBody body;

        public gpGeneraIuvRequest() { }

        public gpGeneraIuvRequest(gpGeneraIuvRequestBody body) {
            this.body = body;
        }
    }

    [MessageContract(IsWrapped = false)]
    public class gpGeneraIuvResponse {

        [MessageBodyMember(Name = "gpGeneraIuvResponse", Namespace = "http://www.govpay.it/servizi/gpApp/", Order = 0)]
        public gpGeneraIuvResponseBody body;

        public gpGeneraIuvResponse() { }

        public gpGeneraIuvResponse(gpGeneraIuvResponseBody body) {
            this.body = body;
        }
    }

    [MessageContract(IsWrapped = false)]
    public class gpCaricaIuvRequest {

        [MessageBodyMember(Name = "gpCaricaIuv", Namespace = "http://www.govpay.it/servizi/gpApp/", Order = 0)]
        public gpCaricaIuvRequestBody body;

        public gpCaricaIuvRequest() { }

        public gpCaricaIuvRequest(gpCaricaIuvRequestBody body) {
            this.body = body;
        }
    }

    [MessageContract(IsWrapped = false)]
    public class gpCaricaIuvResponse {

        [MessageBodyMember(Name = "gpCaricaIuvResponse", Namespace = "http://www.govpay.it/servizi/gpApp/", Order = 0)]
        public gpCaricaIuvResponseBody body;

        public gpCaricaIuvResponse() { }

        public gpCaricaIuvResponse(gpCaricaIuvResponseBody body) {
            this.body = body;
        }
    }

    [MessageContract(IsWrapped = false)]
    public class gpCaricaVersamentoRequest {

        [MessageBodyMember(Name = "gpCaricaVersamento", Namespace = "http://www.govpay.it/servizi/gpApp/", Order = 0)]
        public gpCaricaVersamentoRequestBody body;

        public gpCaricaVersamentoRequest() { }

        public gpCaricaVersamentoRequest(gpCaricaVersamentoRequestBody body) {
            this.body = body;
        }
    }

    [MessageContract(IsWrapped = false)]
    public class gpCaricaVersamentoResponse {

        [MessageBodyMember(Name = "gpCaricaVersamentoResponse", Namespace = "http://www.govpay.it/servizi/gpApp/", Order = 0)]
        public gpCaricaVersamentoResponseBody body;

        public gpCaricaVersamentoResponse() { }

        public gpCaricaVersamentoResponse(gpCaricaVersamentoResponseBody body) {
            this.body = body;
        }
    }

    [MessageContract(IsWrapped = false)]
    public class gpAnnullaVersamentoRequest {

        [MessageBodyMember(Namespace = "http://www.govpay.it/servizi/gpApp/", Order = 0)]
        public gpAnnullaVersamento gpAnnullaVersamento;

        public gpAnnullaVersamentoRequest() { }

        public gpAnnullaVersamentoRequest(gpAnnullaVersamento gpAnnullaVersamento) {
            this.gpAnnullaVersamento = gpAnnullaVersamento;
        }
    }

    [MessageContract(IsWrapped = false)]
    public class gpAnnullaVersamentoResponse {

        [MessageBodyMember(Name = "gpAnnullaVersamentoResponse", Namespace = "http://www.govpay.it/servizi/gpApp/", Order = 0)]
        public gpResponseBody body;

        public gpAnnullaVersamentoResponse() { }

        public gpAnnullaVersamentoResponse(gpResponseBody body) {
            this.body = body;
        }
    }

    [MessageContract(IsWrapped = false)]
    public class gpNotificaPagamentoRequest {

        [MessageBodyMember(Name = "gpNotificaPagamento", Namespace = "http://www.govpay.it/servizi/gpApp/", Order = 0)]
        public gpNotificaPagamentoRequestBody body;

        public gpNotificaPagamentoRequest() { }

        public gpNotificaPagamentoRequest(gpNotificaPagamentoRequestBody body) {
            this.body = body;
        }
    }

    [MessageContract(IsWrapped = false)]
    public class gpNotificaPagamentoResponse {

        [MessageBodyMember(Name = "gpNotificaPagamentoResponse", Namespace = "http://www.govpay.it/servizi/gpApp/", Order = 0)]
        public gpResponseBody body;

        public gpNotificaPagamentoResponse() { }

        public gpNotificaPagamentoResponse(gpResponseBody body) {
            this.body = body;
        }
    }

    [MessageContract(IsWrapped = false)]
    public class gpChiediStatoVersamentoRequest {

        [MessageBodyMember(Name = "gpChiediStatoVersamento", Namespace = "http://www.govpay.it/servizi/gpApp/", Order = 0)]
        public gpChiediStatoVersamentoRequestBody body;

        public gpChiediStatoVersamentoRequest() { }

        public gpChiediStatoVersamentoRequest(gpChiediStatoVersamentoRequestBody body) {
            this.body = body;
        }
    }

    [MessageContract(IsWrapped = false)]
    public class gpChiediStatoVersamentoResponse {

        [MessageBodyMember(Namespace = "http://www.govpay.it/servizi/gpApp/", Order = 0)]
        public gpChiediStatoVersamentoResponseBody body;

        public gpChiediStatoVersamentoResponse() { }

        public gpChiediStatoVersamentoResponse(gpChiediStatoVersamentoResponseBody body) {
            this.body = body;
        }
    }

    [MessageContract(IsWrapped = false)]
    public class gpChiediListaFlussiRendicontazioneRequest {

        [MessageBodyMember(Name = "gpChiediListaFlussiRendicontazione", Namespace = "http://www.govpay.it/servizi/gpApp/", Order = 0)]
        public gpChiediListaFlussiRendicontazioneRequestBody body;

        public gpChiediListaFlussiRendicontazioneRequest() { }

        public gpChiediListaFlussiRendicontazioneRequest(gpChiediListaFlussiRendicontazioneRequestBody body) {
            this.body = body;
        }
    }

    [MessageContract(IsWrapped = false)]
    public class gpChiediListaFlussiRendicontazioneResponse {

        [MessageBodyMember(Name = "gpChiediListaFlussiRendicontazioneResponse", Namespace = "http://www.govpay.it/servizi/gpApp/", Order = 0)]
        public gpChiediListaFlussiRendicontazioneResponseBody body;

        public gpChiediListaFlussiRendicontazioneResponse() { }

        public gpChiediListaFlussiRendicontazioneResponse(gpChiediListaFlussiRendicontazioneResponseBody body) {
            this.body = body;
        }
    }

    [MessageContract(IsWrapped = false)]
    public class gpChiediFlussoRendicontazioneRequest {

        [MessageBodyMember(Name = "gpChiediFlussoRendicontazione", Namespace = "http://www.govpay.it/servizi/gpApp/", Order = 0)]
        public gpChiediFlussoRendicontazioneRequestBody body;

        public gpChiediFlussoRendicontazioneRequest() { }

        public gpChiediFlussoRendicontazioneRequest(gpChiediFlussoRendicontazioneRequestBody body) {
            this.body = body;
        }
    }

    [MessageContract(IsWrapped = false)]
    public class gpChiediFlussoRendicontazioneResponse {

        [MessageBodyMember(Name = "gpChiediFlussoRendicontazioneResponse", Namespace = "http://www.govpay.it/servizi/gpApp/", Order = 0)]
        public gpChiediFlussoRendicontazioneResponseBody body;

        public gpChiediFlussoRendicontazioneResponse() { }

        public gpChiediFlussoRendicontazioneResponse(gpChiediFlussoRendicontazioneResponseBody body) {
            this.body = body;
        }
    }

    #endregion

}