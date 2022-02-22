
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


using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using System.Diagnostics;
using System.Xml.Serialization;
using System.Collections;
using System.Xml.Schema;
using System.ComponentModel;
using System.Xml;
using funzioni_configurazione;

namespace BancaSondrioFlusso {

    public class FlussoIncassi {

        public RecordTesta Testa { get; private set; }
        public RecordCoda Coda { get; private set; }
        public SortedList<int, Disposizione> Disposizioni { get; private set; }

        private FlussoIncassi() {
            Disposizioni = new SortedList<int, Disposizione>();
        }

        public static string Elabora(string filename, out FlussoIncassi flusso) {
            if (File.Exists(filename)) {
                flusso = new FlussoIncassi();
                return flusso.Elabora(filename);
            }

            flusso = null;
            return "Il file selezionato non esiste o non è accessibile.";
        }

        private string Elabora(string filename) {
            int nriga = 0;
            using (var reader = File.OpenText(filename)) {
                while (!reader.EndOfStream) {
                    nriga++;
                    char[] buffer = new char[121];
                    reader.Read(buffer, 0, 121); //reader.ReadLine();
                    if (buffer[120] != 0x0A) return $"Lunghezza riga {nriga} non valida ";
                    var riga = new string(buffer, 0, 120);

                    var tipo = riga.Substring(1, 2);

                    if (tipo.Equals("IM")) {
                        Testa = new RecordTesta();

                        Testa.Mittente = ElaboraAlfanumerico(riga, 3, 5);
                        Testa.Ricevente = ElaboraAlfanumerico(riga, 8, 5);
                        var dataCreazione = ElaboraDataCorta(riga, 13, 6);
                        if (!dataCreazione.HasValue) {
                            return "Data creazione non valida.";
                        }
                        Testa.DataCreazione = dataCreazione.Value;
                        Testa.NomeSupporto = ElaboraAlfanumerico(riga, 19, 20);
                        Testa.CodiceServizio = ElaboraAlfanumerico(riga, 69, 7);
                        Testa.CodiceSottoservizio = ElaboraAlfanumerico(riga, 76, 7);
                        Testa.NumeroLista = ElaboraAlfanumerico(riga, 83, 13);
                        Testa.SoggettoVeicolatore = ElaboraAlfanumerico(riga, 106, 5);
                        Testa.CodiceDivisa = ElaboraAlfanumerico(riga, 113, 1);

                        continue;
                    }

                    if (tipo.Equals("EF")) {
                        Coda = new RecordCoda();

                        Coda.Mittente = riga.Substring(3, 5).Trim();
                        Coda.Ricevente = riga.Substring(8, 5).Trim();
                        var dataCreazione = ElaboraDataCorta(riga, 13, 6);
                        if (!dataCreazione.HasValue) {
                            return "Data creazione non valida.";
                        }
                        Coda.DataCreazione = dataCreazione.Value;
                        Coda.NomeSupporto = riga.Substring(19, 20).Trim();
                        Coda.NumeroDisposizioni = int.Parse(riga.Substring(45, 7));
                        Coda.TotaleImportiNegativi = decimal.Parse(riga.Substring(52, 15)) / 100;
                        Coda.TotaleImportiPositivi = decimal.Parse(riga.Substring(67, 15)) / 100;
                        Coda.NumeroRecord = int.Parse(riga.Substring(82, 7));
                        Coda.CodiceDivisa = riga.Substring(113, 1);

                        continue;
                    }

                    var progressivo = int.Parse(riga.Substring(3, 7));

                    Disposizione disposizione;
                    if (!Disposizioni.ContainsKey(progressivo)) {
                        disposizione = new Disposizione();
                        Disposizioni.Add(progressivo, disposizione);
                    }
                    else {
                        disposizione = Disposizioni[progressivo];
                    }

                    switch (tipo) {
                        case "14":
                        var dataQuietanza = ElaboraDataCorta(riga, 10, 6);
                        if (!dataQuietanza.HasValue) {
                            return "Data quietanza non valida.";
                        }
                        disposizione.DataQuietanza = dataQuietanza.Value;
                        disposizione.DataValuta = ElaboraDataCorta(riga, 16, 6);
                        var dataPagamento = ElaboraDataCorta(riga, 22, 6);
                        if (!dataPagamento.HasValue) {
                            return "Data pagamento non valida.";
                        }
                        disposizione.DataPagamento = dataPagamento.Value;
                        disposizione.Causale = ElaboraAlfanumerico(riga, 28, 5);
                        var importo = ElaboraValuta(riga, 33, 13);
                        if (!importo.HasValue) {
                            return "Importo non valido.";
                        }
                        disposizione.Importo = importo.Value;
                        disposizione.Segno = ElaboraAlfanumerico(riga, 46, 1);
                        disposizione.BancaEsattrice.CodiceABI = ElaboraAlfanumerico(riga, 47, 5);
                        disposizione.BancaEsattrice.CodiceCAB = ElaboraAlfanumerico(riga, 52, 5);
                        disposizione.BancaAssuntrice.CodiceABI = ElaboraAlfanumerico(riga, 69, 5);
                        disposizione.BancaAssuntrice.CodiceCAB = ElaboraAlfanumerico(riga, 74, 5);
                        disposizione.Conto = ElaboraAlfanumerico(riga, 79, 12);
                        disposizione.CodiceAzienda = ElaboraAlfanumerico(riga, 91, 5);
                        disposizione.TipoCodiceDebitore = ElaboraAlfanumerico(riga, 96, 1);
                        disposizione.CodiceDebitore = ElaboraAlfanumerico(riga, 97, 16);
                        var dataAccredito = ElaboraDataCorta(riga, 113, 6);
                        if (!dataAccredito.HasValue) {
                            return "Data accredito non valida.";
                        }
                        disposizione.DataAccredito = dataAccredito.Value;
                        disposizione.CodiceDivisa = ElaboraAlfanumerico(riga, 119, 1);

                        break;

                        case "16":
                        disposizione.IBAN = ElaboraAlfanumerico(riga, 10, 34);

                        break;

                        case "20":
                        disposizione.EnteCreditore = ElaboraAlfanumerico(riga, 10, 110);
                        break;

                        case "30":
                        disposizione.Debitore.RagioneSociale = ElaboraAlfanumerico(riga, 10, 60);
                        disposizione.Debitore.CodiceFiscale = ElaboraAlfanumerico(riga, 70, 16);

                        break;

                        case "40":
                        disposizione.Debitore.Indirizzo1 = ElaboraAlfanumerico(riga, 10, 30);
                        disposizione.Debitore.CAP = ElaboraAlfanumerico(riga, 40, 5);
                        disposizione.Debitore.Località = ElaboraAlfanumerico(riga, 45, 25);
                        disposizione.Debitore.Indirizzo2 = ElaboraAlfanumerico(riga, 70, 28);
                        disposizione.Debitore.Nazione = ElaboraAlfanumerico(riga, 98, 2);

                        break;

                        case "50":
                        disposizione.RiferimentoDebito = ElaboraAlfanumerico(riga, 10, 80);

                        break;

                        case "51":
                        disposizione.NumeroDisposizione = ElaboraAlfanumerico(riga, 10, 10);    //identificativo_disposizione
                        disposizione.CodiceIdentificativoUnivoco = ElaboraAlfanumerico(riga, 74, 12);
                        disposizione.IdentificativoTransazione = ElaboraAlfanumerico(riga, 95, 25); //nostro id_transazione

                        break;

                        case "59":
                        var builder = new StringBuilder();
                        builder.Append(disposizione.RiferimentoDebito);
                        builder.Append(ElaboraAlfanumerico(riga, 10, 110));
                        disposizione.RiferimentoDebito = builder.ToString();

                        break;

                        case "70":
                        disposizione.NumeroProvvisorio = ElaboraAlfanumerico(riga, 20, 7);
                        disposizione.CodiceAvviso = ElaboraAlfanumerico(riga, 30, 18);
                        disposizione.TipoBollettino = ElaboraAlfanumerico(riga, 93, 1);
                        disposizione.ChiaviControllo = ElaboraAlfanumerico(riga, 100, 20);
                        disposizione.DataInizioValidità = ElaboraDataLunga(riga, 104, 8);
                        disposizione.DataFineValidità = ElaboraDataLunga(riga, 112, 8);

                        break;
                    }
                }
            }

            return null;
        }

        private string ElaboraAlfanumerico(string riga, int startIndex, int length) {
            string alfanumerico = riga.Substring(startIndex, length).TrimEnd();
            if (string.IsNullOrEmpty(alfanumerico)) {
                return null;
            }
            return alfanumerico;
        }

        private int? ElaboraNumero(string riga, int startIndex, int length) {
            int numero;
            if (int.TryParse(riga.Substring(startIndex, length), out numero)) {
                return numero;
            }
            return null;
        }

        private decimal? ElaboraValuta(string riga, int startIndex, int length) {
            decimal importo;
            if (decimal.TryParse(riga.Substring(startIndex, length), out importo)) {
                return importo / 100;
            }
            return null;
        }

        private DateTime? ElaboraDataCorta(string riga, int startIndex, int length) {
            DateTime data;
            if (DateTime.TryParseExact(riga.Substring(startIndex, length), "ddMMyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out data)) {
                return data;
            }
            return null;
        }

        private DateTime? ElaboraDataLunga(string riga, int startIndex, int length) {
            DateTime data;
            if (DateTime.TryParseExact(riga.Substring(startIndex, length), "ddMMyyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out data)) {
                return data;
            }
            return null;
        }

    }

    public class RecordTesta {

        /// <summary>
        /// Codice assegnato dalla SIA all'azienda mittente.
        /// </summary>
        public string Mittente { get; set; }

        /// <summary>
        /// Codice ABI della banca assuntrice cui devono essere inviate le disposizioni.
        /// </summary>
        public string Ricevente { get; set; }

        /// <summary>
        /// Data di creazione del flusso da parte dell'azienda mittente.
        /// </summary>
        public DateTime DataCreazione { get; set; }

        /// <summary>
        /// Campo di libera composizione da parte dell'Azienda Mittente
        /// </summary>
        /// <remarks>
        /// Dev'essere univoco nell'ambito della data di creazione e a parità di mittente e ricevente.
        /// </remarks>
        public string NomeSupporto { get; set; }

        /// <summary>
        /// Codice servizio.
        /// </summary>
        public string CodiceServizio { get; set; }

        /// <summary>
        /// Codice sottoservizio.
        /// </summary>
        public string CodiceSottoservizio { get; set; }

        /// <summary>
        /// Numero lista.
        /// </summary>
        public string NumeroLista { get; set; }

        /// <summary>
        /// Codice ABI della Banca Gateway Market Place.
        /// </summary>
        public string SoggettoVeicolatore { get; set; }

        /// <summary>
        /// Codice divisa.
        /// </summary>
        /// <remarks>
        /// Assume il valore fisso "E" (Euro).
        /// </remarks>
        public string CodiceDivisa { get; set; }

    }

    public class RecordCoda {

        /// <summary>
        /// Codice assegnato dalla SIA all'azienda mittente.
        /// </summary>
        public string Mittente { get; set; }

        /// <summary>
        /// Codice ABI della banca assuntrice cui devono essere inviate le disposizioni.
        /// </summary>
        public string Ricevente { get; set; }

        /// <summary>
        /// Data di creazione del flusso da parte dell'azienda mittente.
        /// </summary>
        public DateTime DataCreazione { get; set; }

        /// <summary>
        /// Campo di libera composizione da parte dell'Azienda Mittente
        /// </summary>
        /// <remarks>
        /// Dev'essere univoco nell'ambito della data di creazione e a parità di mittente e ricevente.
        /// </remarks>
        public string NomeSupporto { get; set; }

        /// <summary>
        /// Numero delle disposizioni.
        /// </summary>
        public int NumeroDisposizioni { get; set; }

        /// <summary>
        /// Importo totale delle disposizioni contenute nel flusso.
        /// </summary>
        public decimal TotaleImportiNegativi { get; set; }

        /// <summary>
        /// Importo totale delle disposizioni contenute nel flusso.
        /// </summary>
        public decimal TotaleImportiPositivi { get; set; }

        /// <summary>
        /// Numero dei record che compongono il flusso (comprensivo anche dei record di testa e di coda).
        /// </summary>
        public int NumeroRecord { get; set; }

        /// <summary>
        /// Codice divisa.
        /// </summary>
        /// <remarks>
        /// Deve assumere lo stesso valore del campo omonimo presente sul record di testa.
        /// </remarks>
        public string CodiceDivisa { get; set; }

    }

    public class InformazioniBanca {

        public string CodiceABI { get; set; }
        public string CodiceCAB { get; set; }

    }

    public class InformazioniDebitore {

        public string RagioneSociale { get; set; }
        public string CodiceFiscale { get; set; }
        public string Indirizzo1 { get; set; }
        public string Indirizzo2 { get; set; }
        public string CAP { get; set; }
        public string Località { get; set; }
        public string Nazione { get; set; }

    }

    public class Disposizione {

        public DateTime DataPagamento { get; set; }
        public string Causale { get; set; }
        public decimal Importo { get; set; }
        public string Segno { get; set; }
        public InformazioniBanca BancaEsattrice { get; set; }
        public InformazioniBanca BancaAssuntrice { get; set; }
        public string Conto { get; set; }
        public string CodiceAzienda { get; set; }
        public string TipoCodiceDebitore { get; set; }
        public string CodiceDebitore { get; set; }
        public string CodiceDivisa { get; set; }
        public DateTime DataQuietanza { get; set; }
        public DateTime? DataValuta { get; set; }
        public DateTime DataAccredito { get; set; }
        public string IBAN { get; set; }
        public string EnteCreditore { get; set; }
        public InformazioniDebitore Debitore { get; set; }
        public string RiferimentoDebito { get; set; }
        public string NumeroDisposizione { get; set; }
        public string CodiceIdentificativoUnivoco { get; set; }
        //public decimal ImportoSpese { get; set; }
        //public DateTime DataValutaAddebito { get; set; }
        //public string RiferimentoContabile { get; set; }
        //public DateTime DataPagamentoEffettivo { get; set; }
        public string IdentificativoTransazione { get; set; }
        public string TipoBollettino { get; set; }
        public string ChiaviControllo { get; set; }
        public string NumeroProvvisorio { get; set; }
        public string CodiceAvviso { get; set; }
        public DateTime? DataInizioValidità { get; set; }
        public DateTime? DataFineValidità { get; set; }

        public string IUV {
            get {
                if (string.IsNullOrEmpty(CodiceAvviso)) return null;
                return CodiceAvviso.Substring(3);
            }
        }

        public Disposizione() {
            BancaEsattrice = new InformazioniBanca();
            BancaAssuntrice = new InformazioniBanca();
            Debitore = new InformazioniDebitore();
        }

    }


    public class RicevutaTelematica {

        #region public fields
        public sbyte _versioneOggetto;
        public RTDominio _dominio;
        public string _identificativoMessaggioRicevuta;
        public System.DateTime _dataOraMessaggioRicevuta;
        public string _riferimentoMessaggioRichiesta;
        public System.DateTime _riferimentoDataRichiesta;
        public RTIstitutoAttestante _istitutoAttestante;
        public RTEnteBeneficiario _enteBeneficiario;
        public RTSoggettoPagatore _soggettoPagatore;
        public RTDatiPagamento _datiPagamento;
        #endregion

        public RicevutaTelematica() {
        }


    public class RTDominio {

        #region public fields
        public string _identificativoDominio;
        public string _identificativoStazioneRichiedente;
        #endregion
    }

    public class RTIstitutoAttestante {

        #region public fields
        public RTIstitutoAttestanteIdentificativoUnivocoAttestante _identificativoUnivocoAttestante;
        public string _denominazioneAttestante;
        public string _codiceUnitOperAttestante;
        public string _denomUnitOperAttestante;
        public string _indirizzoAttestante;
        public sbyte _civicoAttestante;
        public string _capAttestante;
        public string _localitaAttestante;
        public string _provinciaAttestante;
        public string _nazioneAttestante;
        #endregion

    }

    public class RTIstitutoAttestanteIdentificativoUnivocoAttestante {

        #region public fields
        public string _tipoIdentificativoUnivoco;
        public string _codiceIdentificativoUnivoco;
        #endregion

    }

    public class RTEnteBeneficiario {

        #region public fields
        public RTEnteBeneficiarioIdentificativoUnivocoBeneficiario _identificativoUnivocoBeneficiario;
        public string _denominazioneBeneficiario;
        public string _indirizzoBeneficiario;
        public string _capBeneficiario;
        public string _localitaBeneficiario;
        public string _provinciaBeneficiario;
        public string _nazioneBeneficiario;
        #endregion
    }

    public class RTEnteBeneficiarioIdentificativoUnivocoBeneficiario {

        #region public fields
        public string _tipoIdentificativoUnivoco;
        public string _codiceIdentificativoUnivoco;
        #endregion
    }

    public class RTSoggettoVersante {

        #region public fields
        public RTSoggettoVersanteIdentificativoUnivocoVersante _identificativoUnivocoVersante;
        public string _anagraficaVersante;
        #endregion
    }

    public class RTSoggettoVersanteIdentificativoUnivocoVersante {

        #region public fields
        public string _tipoIdentificativoUnivoco;
        public string _codiceIdentificativoUnivoco;
        #endregion
    }

    public class RTSoggettoPagatore {

        #region public fields
        public RTSoggettoPagatoreIdentificativoUnivocoPagatore _identificativoUnivocoPagatore;
        public string _anagraficaPagatore;
        #endregion
    }

    public class RTSoggettoPagatoreIdentificativoUnivocoPagatore {

        #region public fields
        public string _tipoIdentificativoUnivoco;
        public string _codiceIdentificativoUnivoco;
        #endregion
    }

    public class RTDatiPagamento {
        #region public fields
        public string _codiceEsitoPagamento;
        public decimal _importoTotalePagato;
        public string _identificativoUnivocoVersamento;
        public string _codiceContestoPagamento;
        public List<RTDatiPagamentoDatiSingoloPagamento> _datiSingoloPagamento = new List<RTDatiPagamentoDatiSingoloPagamento>();
        #endregion
    }

    public class RTDatiPagamentoDatiSingoloPagamento {
        #region public fields
        public decimal _singoloImportoPagato;
        public string _esitoSingoloPagamento;
        public System.DateTime _dataEsitoSingoloPagamento;
        public string _identificativoUnivocoRiscossione;
        public string _causaleVersamento;
        public string _datiSpecificiRiscossione;
        #endregion
    }
    }

    public class import_RicevutaTelematica {

        public static string ImportaFile_RT(string filename, out RicevutaTelematica RT) {
            RT = new RicevutaTelematica();
            if (!(File.Exists(filename))) {
                return "Il file selezionato non esiste o non è accessibile.";
            }
            XmlDocument X = new XmlDocument();
            try {
                X.Load(filename);
            }
            catch (Exception e2) {
                return e2.Message + " " + e2.ToString();
            }
            try {
                RT = ElaboraXml_RT(X);
            }
            catch (Exception e) {
                return e.Message + " " + e.ToString();
                //QueryCreator.ShowException(null, "Errore!", e);
            }
            return null;

        }


        static string getXmlText(XmlNode x, string xpath) {
            try {
                XmlNode n = x.SelectSingleNode(xpath);
                if (n != null) {
                    return n.InnerText;
                }
            }
            catch (Exception e) {
                string errore = e.Message + " " + e.ToString();
            }
            return null;
        }

        static string getXmlText(XmlNode x, string xpath, XmlNamespaceManager ns) {
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
        public static object LeggiDecimale(string sImportoTotale) {
            object importoTotale;
            if (sImportoTotale != "" && sImportoTotale != null) {
                importoTotale =
                    XmlConvert.ToDecimal(
                        sImportoTotale);
            }
            else {
                importoTotale = DBNull.Value;
            }
            return importoTotale;
        }

        public static RicevutaTelematica ElaboraXml_RT(XmlDocument Xdoc) {
            RicevutaTelematica M = new RicevutaTelematica();
            string PreRoot = "";
            XmlNode nodoRT = Xdoc.GetElementsByTagName("RT")[0];
            if (nodoRT == null) {
                nodoRT = Xdoc.GetElementsByTagName("pay_i:RT")[0];
                PreRoot = "pay_i:";
            }

            M._identificativoMessaggioRicevuta = nodoRT[PreRoot + "identificativoMessaggioRicevuta"].InnerText;
            M._riferimentoMessaggioRichiesta = nodoRT[PreRoot + "riferimentoMessaggioRichiesta"].InnerText;

            //Scorre l'elenco dei flussi 
            foreach (XmlNode CurrNode in nodoRT.ChildNodes) {
                //XmlNodeList listOfsoggettoPagatore = singleRT.ChildNodes;// ["soggettoPagatore"];
                if (CurrNode.Name== PreRoot+"soggettoPagatore") {
                    RicevutaTelematica.RTSoggettoPagatore SP = new RicevutaTelematica.RTSoggettoPagatore();
                    SP._anagraficaPagatore = CurrNode[PreRoot+"anagraficaPagatore"].InnerText;
                    foreach (XmlNode XidentificativoUnivocoPagatore in CurrNode.ChildNodes) {
                        if (XidentificativoUnivocoPagatore.Name == PreRoot + "identificativoUnivocoPagatore") {
                            RicevutaTelematica.RTSoggettoPagatoreIdentificativoUnivocoPagatore IUP = new RicevutaTelematica.RTSoggettoPagatoreIdentificativoUnivocoPagatore();
                            IUP._tipoIdentificativoUnivoco = XidentificativoUnivocoPagatore[PreRoot + "tipoIdentificativoUnivoco"].InnerText;
                            IUP._codiceIdentificativoUnivoco = XidentificativoUnivocoPagatore[PreRoot + "codiceIdentificativoUnivoco"].InnerText;
                            SP._identificativoUnivocoPagatore = IUP;
                        }
                    }
                    M._soggettoPagatore = SP;
                }
                if (CurrNode.Name == PreRoot + "datiPagamento") {
                    List<RicevutaTelematica.RTDatiPagamentoDatiSingoloPagamento> Pagamenti = new List<RicevutaTelematica.RTDatiPagamentoDatiSingoloPagamento>();
                    //0 Pagamento eseguito, 1 Pagamento non eseguito, 2 Pagamento parzialmente eseguito, 3 Decorrenza termini, 4 Decorrenza termini parziale 
                    RicevutaTelematica.RTDatiPagamento DP = new RicevutaTelematica.RTDatiPagamento();
                    DP._codiceEsitoPagamento = CurrNode[PreRoot + "codiceEsitoPagamento"].InnerText;
                    DP._importoTotalePagato = XmlHelper.AsDecimal(CurrNode, PreRoot + "importoTotalePagato");// CfgFn.GetNoNullDecimal(CurrNode["importoTotalePagato"].InnerText);
                    DP._identificativoUnivocoVersamento = CurrNode[PreRoot + "identificativoUnivocoVersamento"].InnerText;
                    DP._codiceContestoPagamento = CurrNode[PreRoot + "CodiceContestoPagamento"].InnerText;
                    DateTime empyDate = new DateTime(1900, 1, 1);
                    DateTime MAXdataEsitoSingoloPagamento = empyDate;
                    foreach (XmlNode Xinfo_datiSingoloPagamento in CurrNode.ChildNodes) {
                        if (Xinfo_datiSingoloPagamento.Name == PreRoot + "datiSingoloPagamento") {
                            //Prendiamo la max date laddove vi fossero più pagamenti
                            DateTime dataEsitoSingoloPagamento = XmlHelper.AsDate(Xinfo_datiSingoloPagamento, PreRoot + "dataEsitoSingoloPagamento");
                            if (MAXdataEsitoSingoloPagamento < dataEsitoSingoloPagamento) {
                                MAXdataEsitoSingoloPagamento = dataEsitoSingoloPagamento;
                            }
                        }
                    }//Fine scansione datiSingoloPagamento
                    var PP = new RicevutaTelematica.RTDatiPagamentoDatiSingoloPagamento();
                    PP._dataEsitoSingoloPagamento = MAXdataEsitoSingoloPagamento;
                    Pagamenti.Add(PP);

                    DP._datiSingoloPagamento = Pagamenti;
                    M._datiPagamento = DP;
                }
            }
            
            return M;
        }




    }
}
