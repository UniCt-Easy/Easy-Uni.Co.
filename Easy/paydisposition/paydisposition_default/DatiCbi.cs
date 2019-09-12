/*
    Easy
    Copyright (C) 2019 Università degli Studi di Catania (www.unict.it)

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
using metadatalibrary;


namespace paydisposition_default
{
    class DatiCbiRiba
    {
        private string mCodiceSia = string.Empty;
        private string mAbiAzienda = string.Empty;
        private string mCabAzienda = string.Empty;
        private string mContoAzienda = string.Empty;
        private DateTime mDataCreazione;
        private string mNomeSupporto = string.Empty;
        private int mNumeroDisposizioni = 0;
        private decimal mImportoDisposizioni = 0;
        private int mNumeroRecord = 0;
        private DateTime mDataScadenza;
        private DateTime mDataValuta;
        private decimal mImporto = 0;
        private string mAbiCliente = string.Empty;
        private string mCabCliente = string.Empty;
        private string mCinCliente = string.Empty;
        private string mCCCliente = string.Empty;
        private string mIBANCliente = string.Empty;
        private string mPagamentoPerBonifico = string.Empty;
        private string mPagamentoPerCassa = string.Empty;
        private string mPagamentoPerAssegnoCircolare = string.Empty;
        private string mPagamentoPerAssegnoCircolareNonTrasf = string.Empty;
        private string mPagamentoPerAssegnoQuietanza = string.Empty;
        private int mTipoCodice = 4;
        private string mCodiceBeneficiario = string.Empty;
        private string mDescrizioneAzienda = string.Empty;
        private string mLocalitaAzienda = string.Empty;
        private string mIndirizzoAzienda = string.Empty;
        private string mDescrizioneBeneficiario = string.Empty;
        private string mCodiceFiscaleBeneficiario = string.Empty;
        private string mIndirizzoBeneficiario = string.Empty;
        private string mCapBeneficiario = string.Empty;
        private string mLocalitaBeneficiario = string.Empty;
        private string mSportelloBeneficiario = string.Empty;
        private string mRiferimentoCredito = string.Empty;
        private string mCodificaFiscale = string.Empty;
        private int mNumeroRicevuta = 0;
        private string mRagioneSociale = string.Empty;
        private string mProvinciaFinanza = string.Empty;
        private string mNumeroAutorizzazione = string.Empty;
        private DateTime mDataAutorizzazione;
        private int mTipoDocBeneficiario = 0;
        private int mRichiestaEsito = 0;
        private int mStampaAvviso = 0;
        private string mChiaveControllo = string.Empty;
        private string mCausale = string.Empty;
        private string mCausaleDescrittiva = string.Empty;
        private const int Length = 120;
        bool[] admitted_char = new bool[256];
        public DatiCbiRiba() {
            for (int i = 0; i < 0xFF; i++) admitted_char[i] = false;
            for (int i = 0x20; i <= 0x7A; i++) admitted_char[i] = true;
            admitted_char[0x21] = false;
            admitted_char[0x23] = false;
            admitted_char[0x40] = false; //chiocciola
            admitted_char[0x5B] = false;
            admitted_char[0x5C] = false;
            admitted_char[0x5D] = false;
            admitted_char[0x5E] = false;
            admitted_char[0x60] = false;
        }

        # region properties
        public string Causale{
            get{
                return mCausale;
            }
            set{
                mCausale = value;
            }
        }

        public string CausaleDescrittiva{
            get{
                return mCausaleDescrittiva;
            }
            set{
                mCausaleDescrittiva = value;
            }
        }

        public string ChiaveControllo{
            get{
                return mChiaveControllo;
            }
            set{
                mChiaveControllo = value;
            }
        }
        public int StampaAvviso {
            get{
                return mStampaAvviso;
            }
            set{
                mStampaAvviso = value;
            }
        }

        public int RichiestaEsito {
            get{
                return mRichiestaEsito;
            }
            set{
                mRichiestaEsito = value;
            }
        }

        public int TipoDocBeneficiario {
            get{
                return mTipoDocBeneficiario;
            }
            set {
                mTipoDocBeneficiario = value;
            }
        }

        public DateTime DataAutorizzazione  {
            get{
                return mDataAutorizzazione;
            }
            set{
                mDataAutorizzazione = value;
            }

        }
        public string NumeroAutorizzazione {
            get{
                return mNumeroAutorizzazione;
            }
            set{
                mNumeroAutorizzazione = value;
            }
        }
        public string ProvinciaFinanza{
            get{
                return mProvinciaFinanza;
            }
            set{
                mProvinciaFinanza = value;
            }
        }
        public string RagioneSociale{
            get {
                return mRagioneSociale;
            }
            set{
                mRagioneSociale = value;
            }
        }

        public int NumeroRicevuta{
            get{
                return mNumeroRicevuta;
            }
            set {
                mNumeroRicevuta = value;
            }
        }
        public string CodificaFiscale{
            get{
                return mCodificaFiscale;
            }
            set {
                mCodificaFiscale = value;
            }
        }
        public string RiferimentoCredito
        {
            get
            {
                return mRiferimentoCredito;
            }
            set
            {
                mRiferimentoCredito = value;
            }

        }
        public string IndirizzoBeneficiario
        {
            get
            {
                return mIndirizzoBeneficiario;
            }
            set
            {
                mIndirizzoBeneficiario = value;
            }

        }
        public string CapBeneficiario   {
            get
            {
                return mCapBeneficiario;
            }
            set
            {
                mCapBeneficiario = value;
            }

        }

        public string LocalitaBeneficiario  {
            get
            {
                return mLocalitaBeneficiario;
            }
            set
            {
                mLocalitaBeneficiario = value;
            }

        }

        public string SportelloBeneficiario   {
            get
            {
                return mSportelloBeneficiario;
            }
            set
            {
                mSportelloBeneficiario = value;
            }

        }

        public string CodiceSia {
            get
            {
                return mCodiceSia;
            }
            set
            {
                mCodiceSia = value;
            }

        }
        public string AbiAzienda {
            get
            {
                return mAbiAzienda;
            }
            set
            {
                mAbiAzienda = value;
            }
        }

        public string CabAzienda  {
            get
            {
                return mCabAzienda;
            }
            set
            {
                mCabAzienda = value;
            }
        }
        public string ContoAzienda  {
            get
            {
                return mContoAzienda;
            }
            set
            {
                mContoAzienda = value;
            }

        }
        public DateTime DataCreazione  {
            get
            {
                return mDataCreazione;
            }
            set
            {
                mDataCreazione = value;
            }
        }

        public string NomeSupporto  {
            get
            {
                if (mNomeSupporto == string.Empty)
                    mNomeSupporto = string.Format("{0} {1}", "CIB", DataCreazione);
                return mNomeSupporto;
            }
            set
            {
                mNomeSupporto = value;
            }
        }

        public int NumeroDisposizioni  {
            get
            {
                return mNumeroDisposizioni;
            }
            set
            {
                mNumeroDisposizioni = value;
            }
        }

        public decimal ImportoDisposizioni {
            get
            {
                return mImportoDisposizioni;
            }
            set
            {
                mImportoDisposizioni = value;
            }
        }

        public int NumeroRecord
        {
            get
            {
                return mNumeroRecord;
            }
            set
            {
                mNumeroRecord = value;
            }
        }
        public DateTime DataScadenza   {
            get
            {
                return mDataScadenza;
            }
            set
            {
                mDataScadenza = value;
            }
        }
        public DateTime DataValuta {
            get {
            return mDataValuta;
            }
            set {
                mDataValuta = value;
            }
        }
        public decimal Importo  {
            get
            {
                return mImporto;
            }
            set
            {
                mImporto = value;
            }
        }
        public string AbiCliente {
            get
            {
                return mAbiCliente;
            }
            set
            {
                mAbiCliente = value;
            }
        }

        public string CabCliente  {
            get
            {
                return mCabCliente;
            }
            set
            {
                mCabCliente = value;
            }
        }

        public string CCCliente{
            get
            {
                return mCCCliente;
            }
            set
            {
                mCCCliente = value;
            }
        }
        public string CinCliente
        {
            get
            {
                return mCinCliente;
            }
            set
            {
                mCinCliente = value;
            }
        }
        public string PagamentoPerCassa
        {
            get
            {
                return mPagamentoPerCassa;
            }
            set
            {
                mPagamentoPerCassa = value;
            }
        }

        public string PagamentoPerBonifico
        {
            get
            {
                return mPagamentoPerBonifico;
            }
            set
            {
                mPagamentoPerBonifico = value;
            }
        }

        public string PagamentoPerAssegnoCircolare
        {
            get
            {
                return mPagamentoPerAssegnoCircolare;
            }
            set
            {
                mPagamentoPerAssegnoCircolare = value;
            }
        }

        public string PagamentoPerAssegnoCircolareNonTrasf
        {
            get
            {
                return mPagamentoPerAssegnoCircolareNonTrasf;
            }
            set
            {
                mPagamentoPerAssegnoCircolareNonTrasf = value;
            }
        }

        public string PagamentoPerAssegnoQuietanza
        {
            get
            {
                return mPagamentoPerAssegnoQuietanza;
            }
            set
            {
                mPagamentoPerAssegnoQuietanza = value;
            }
        }


        public string IBANCliente
        {
            get
            {
                return mIBANCliente;
            }
            set
            {
                mIBANCliente = value;
            }
        }


        public int TipoCodice
        {
            get
            {
                return mTipoCodice;
            }
            set
            {
                mTipoCodice = value;
            }
        }
        public string CodiceBeneficiario  {
            get
            {
                return mCodiceBeneficiario;
            }
            set
            {
                mCodiceBeneficiario = value;
            }

        }

        public string DescrizioneBeneficiario
        {
            get
            {
                return mDescrizioneBeneficiario;
            }
            set
            {
                mDescrizioneBeneficiario = value;
            }

        }

        public string DescrizioneAzienda   {
            get {
                return mDescrizioneAzienda;
            }
            set {
                mDescrizioneAzienda = value;
            }
        }

        public string LocalitaAzienda
        {
            get
            {
                return mLocalitaAzienda;
            }
            set
            {
                mLocalitaAzienda = value;
            }
        }
        public string IndirizzoAzienda
        {
            get
            {
                return mIndirizzoAzienda;
            }
            set
            {
                mIndirizzoAzienda = value;
            }
        }
        public string CodiceFiscaleBeneficiario {
            get
            {
                return mCodiceFiscaleBeneficiario;
            }
            set
            {
                mCodiceFiscaleBeneficiario = value;
            }

        }
        #endregion
        /// <summary>
        /// Controllo della corretta lunghezza della stringa restituita 
        /// da ciascun "RecordXX" (XX è il tipo di record)
        /// </summary>
        /// <param name="sb">StringBuilder</param>
        /// <returns>Stringa</returns>
        public string ControllaFormato(StringBuilder sb)  {
            string s = sb.ToString();
            if (s.Length != Length)
                return sb.ToString() + "***";
            else
                return s;
        }

        /// <summary>
        /// Generazione record Header
        /// </summary>
        /// <returns>Stringa record Header</returns>
        public string RecordPC()
        {
            // impostiamo numero record
            NumeroRecord = 1;
            NumeroDisposizioni = 0;
            ImportoDisposizioni = 0;
            StringBuilder sb = new StringBuilder();
            sb.Append(" ");                                 // Filler
            sb.Append("PC");                                // Tipo record
            sb.Append(FormattaStringa(CodiceSia, 5));        // codice Sia Azienda
            sb.Append(FormattaNumero(AbiAzienda.ToString(), 5));          // codice abi banca
            sb.Append(DataCreazione.ToString("ddMMyy"));    // data creazione
            sb.Append(FormattaStringa(NomeSupporto, 20));   // nome supporto
            sb.Append(FormattaStringa("", 6));              // campo a disposizione
            sb.Append(FormattaStringa("", 59));             // filler
            sb.Append(FormattaStringa("", 7));              // Qualificatore flusso
            sb.Append(FormattaStringa("", 2));              // blank
            sb.Append("E");                                 // E: Euro, valore fisso
            sb.Append(" ");                                 // Filler
            sb.Append(FormattaStringa("", 5));              // Filler a 120
            return ControllaFormato(sb);
        }

        /// <summary>
        /// Generazione record Footer
        /// </summary>
        /// <returns>Stringa</returns>
        public string RecordEF()
        {
            NumeroRecord += 1;      // incremento numero record
            StringBuilder sb = new StringBuilder();
            sb.Append(" ");                                     // Filler
            sb.Append("EF");                                    // Tipo record
            sb.Append(FormattaNumero(CodiceSia, 5));            // codice Sia Azienda
            sb.Append(FormattaNumero(AbiAzienda.ToString(), 5));  // codice abi banca
            sb.Append(DataCreazione.ToString("ddMMyy"));        // data creazione
            sb.Append(FormattaStringa(NomeSupporto, 20));       // nome supporto
            sb.Append(FormattaStringa("", 6));                  // campo a disposizione
            sb.Append(FormattaNumero(NumeroDisposizioni.ToString(), 7));   // Numero Disposizioni
            sb.Append(FormattaNumero("", 15));                  // totale importo negativi zeri
            sb.Append(FormattaDecimal(ImportoDisposizioni, 15)); // Importo Disposizioni (positivi)
            sb.Append(FormattaNumero(NumeroRecord.ToString(), 7)); // numero records
            sb.Append(FormattaStringa("", 24));                 // filler
            sb.Append("E");                                     // E
            sb.Append(FormattaStringa("", 6));                  // Filler a 120
            return ControllaFormato(sb);
        }

        /// <summary>
        /// Generazione record Tipo 10
        /// </summary>
        /// <returns>Stringa</returns>
        public string Record10()
        {
            StringBuilder sb = new StringBuilder();
            NumeroRecord += 1;                                  // incremento numero record
            NumeroDisposizioni += 1;                            // numero disposizione all'interno del flusso, inizia da 1, ed è progessivo di 1: 
            ImportoDisposizioni += Importo;                     // importo disposizioni
            sb.Append(" ");                                     // filler
            sb.Append("10");                                    // tipo record
            sb.Append(FormattaNumero(NumeroDisposizioni.ToString(), 7)); // numero disposizione
            sb.Append(FormattaStringa("", 6));                   // filler
            sb.Append(FormattaNumero(0, 6));                     // data esecuzione disposizione facoltativa, non la valorizziamo  
            if (DataValuta!=QueryCreator.EmptyDate())
                 sb.Append(DataValuta.ToString("ddMMyy"));       // la data valuta facoltativa nello specifico formato, se richiesta
            else sb.Append(FormattaNumero(0, 6));               
            sb.Append(FormattaStringa(Causale, 5));              // causale
            sb.Append(FormattaDecimal(Importo, 13));             // importo 
            sb.Append("+");                                      // segno +
            sb.Append(FormattaNumero(AbiAzienda.ToString(), 5)); // abi azienda
            sb.Append(FormattaNumero(CabAzienda.ToString(), 5)); // cab azienda
            sb.Append(FormattaStringa(ContoAzienda, 12));        // conto corrente azienda

            sb.Append(FormattaNumero(AbiCliente.ToString(), 5)); // Abi cliente
            sb.Append(FormattaNumero(CabCliente.ToString(), 5)); // cab cliente
            sb.Append(FormattaStringa(CCCliente, 12));           // cc cliente

            sb.Append(FormattaStringa(CodiceSia, 5));            // codice sia
            sb.Append(FormattaNumero(TipoCodice.ToString(), 1)); // tipo codice
            sb.Append(FormattaStringa(CodiceBeneficiario, 16));  // codice beneficiario
            // modalità di pagamento
            if (PagamentoPerAssegnoCircolare == "S")
            {
                sb.Append("2");
            }
            else
            {
                
                if (PagamentoPerAssegnoCircolareNonTrasf == "S")
                {
                    sb.Append("3");
                }
                else
                {
                    if (PagamentoPerAssegnoQuietanza == "S")
                    {
                        sb.Append("4");
                    }
                    else
                    {
                        sb.Append("1"); //Bonifico o cassa
                    }
                }
            }
                                       
            sb.Append(FormattaStringa("", 5));                   // filler
            sb.Append("E");                                      // Simbolo euro
            return ControllaFormato(sb);
        }
        public string sanitize(string S) {

            string SS =  S.Replace('’', '\'').Replace('´', '\'').Replace('Ç', 'c').Replace('ç', 'c').Replace('€', 'e').Replace('|', ' ').Replace('\\', ' ').Replace('£', ' ').Replace('§', ' ').Replace('[', ' ').Replace('#', ' ').Replace('!', ' ').Replace('Ù', 'U').Replace(
                'Ö', 'o').Replace('Ü', 'u').Replace('Ñ', 'N').Replace('Ð', 'D').Replace('Ê', 'E').Replace('Ë', 'e').Replace('Î', 'i').Replace('Ï', 'i').Replace('Ô', 'O').Replace('Õ', 'O').Replace('Û', 'U').Replace('Ý', 'Y').Replace(
                ']', ' ').Replace('`', ' ').Replace('{', ' ').Replace('}', ' ').Replace('~', ' ').Replace('ü', 'u').Replace('â', 'a').Replace('ä', 'a').Replace('å', 'a').Replace('ê', 'e').Replace('ë', 'e').Replace('ï', 'i').Replace(
                'î', 'i').Replace('Ä', 'A').Replace('Å', 'A').Replace('ô', 'o').Replace('ö', 'o').Replace('û', 'u').Replace('ÿ', 'y').Replace('ñ', 'n').Replace('Â', 'A').Replace('¥', 'y').Replace('ã', 'a').Replace('Ã', 'A').Replace(
                'õ', 'o').Replace('ý', 'y').Replace('é', 'e').Replace('à', 'a').Replace('è', 'e').Replace('ì', 'i').Replace('ò', 'o').Replace('ù', 'u').Replace('á', 'a').Replace('í', 'i').Replace('ó', 'o').Replace('É', 'E').Replace(
                'Á', 'A').Replace('À', 'A').Replace('È', 'E').Replace('Í', 'I').Replace('Ì', 'I').Replace('Ó', 'O').Replace('Ò', 'O').Replace('Ú', 'u').Replace('\t', ' ').Replace('\n', ' ').Replace('\r', ' ').Replace('°', ' ');
            string s="";
            for (int i = 0; i < SS.Length; i++) {
               int c = SS[i];
                if (c<256 && admitted_char[c]) {
                    s += SS[i];
                }
                else {
                    s += ' ';
                }
            }
            return s;
        }
        /// <summary>
        /// Generazione record 17
        /// </summary>
        /// <returns>Stringa</returns>
        public string Record17()
        {
            NumeroRecord += 1;                                  // incremento numero record
            StringBuilder sb = new StringBuilder();
            sb.Append(" ");                                     // filler
            sb.Append("17");                                    // tipo record
            sb.Append(FormattaNumero(NumeroDisposizioni.ToString(), 7)); // numero disposizione
            sb.Append(FormattaStringa(IBANCliente, 27));// IBAN = codice paese IT o SM + check digit + CIN + ABI + CAB + CC
            sb.Append(FormattaStringa("", 83));                  // filler
            return ControllaFormato(sb);
        }

        /// <summary>
        /// Generazione record 20
        /// </summary>
        /// <returns>Stringa</returns>
        public string Record20()
        {
            NumeroRecord += 1;                                  // incremento numero record
            StringBuilder sb = new StringBuilder();
            sb.Append(" ");                                     // filler
            sb.Append("20");                                    // tipo record
            sb.Append(FormattaNumero(NumeroDisposizioni.ToString(), 7)); // numero disposizione

            sb.Append(sanitize(FormattaStringa(DescrizioneAzienda, 30))); // Denominazione o Ragione sociale dell'Azienda
            sb.Append(sanitize(FormattaStringa(IndirizzoAzienda, 30))); // indirizzo
            sb.Append(sanitize(FormattaStringa(LocalitaAzienda, 30))); // localita
            sb.Append(FormattaStringa(CodificaFiscale, 16)); // CF o Piva dell'ordinante
            sb.Append(FormattaStringa("", 4));                 // filler
            return ControllaFormato(sb);
        }

        /// <summary>
        /// Generazione record 30
        /// </summary>
        /// <returns>Stringa</returns>
        public string Record30()
        {
            NumeroRecord += 1;                                          // incremento numero record
            StringBuilder sb = new StringBuilder();
            sb.Append(" ");                                             // filler
            sb.Append("30");                                            // tipo record
            sb.Append(FormattaNumero(NumeroDisposizioni.ToString(), 7)); // numero disposizione
            sb.Append(sanitize(FormattaStringa(DescrizioneBeneficiario, 30)));        // denominazione
            sb.Append(FormattaStringa("", 60));                         // due segmenti di 30 caratteri
            sb.Append(FormattaStringa(CodiceFiscaleBeneficiario, 16));      // codifica fiscale
            sb.Append(FormattaStringa("", 4));                          // Filler 
            return ControllaFormato(sb);
        }

        /// <summary>
        /// Generazione Record 40
        /// </summary>
        /// <returns>Stringa</returns>
        public string Record40()
        {
            NumeroRecord += 1;                                  // incremento numero record
            StringBuilder sb = new StringBuilder();
            sb.Append(" ");                                     // filler
            sb.Append("40");                                    // tipo record
            sb.Append(FormattaNumero(NumeroDisposizioni.ToString(), 7)); // numero disposizione
            sb.Append(sanitize(FormattaStringa(IndirizzoBeneficiario, 30)));  // indirizzo beneficiario
            sb.Append(FormattaStringa(CapBeneficiario, 5));         // cap beneficiario
            sb.Append(sanitize(FormattaStringa(LocalitaBeneficiario, 25)));   // località provincia beneficiario
            sb.Append(sanitize(FormattaStringa(SportelloBeneficiario, 50)));  // sportello beneficiario
            return ControllaFormato(sb);
        }

        /// <summary>
        /// Generazione record 50
        /// </summary>
        /// <returns>Stringa</returns>
        public string Record50()
        {
            NumeroRecord += 1;                                  // incremento numero record
            StringBuilder sb = new StringBuilder();
            sb.Append(" ");                                     // filler
            sb.Append("50");                                    // tipo record
            sb.Append(FormattaNumero(NumeroDisposizioni.ToString(), 7)); // numero disposizione
            sb.Append(sanitize(FormattaStringa(RiferimentoCredito, 90)));  // 3 segmenti da 30 di cui il 1° obbligatorio
            sb.Append(FormattaStringa("", 20));                 // filler
            return ControllaFormato(sb);
        }


        /// <summary>
        /// Generazione Recorrd 70
        /// </summary>
        /// <returns>Stringa</returns>
        public string Record70()
        {
            NumeroRecord += 1;                                  // incremento numero record
            StringBuilder sb = new StringBuilder();
            sb.Append(" ");                                     // filler
            sb.Append("70");                                    // tipo record
            sb.Append(FormattaNumero(NumeroDisposizioni.ToString(), 7)); // numero disposizione
            sb.Append(FormattaStringa("", 100));                 // filler o facoltativi
            sb.Append(FormattaStringa(CinCliente, 1));          // cin cliente
            sb.Append(FormattaStringa("", 9));                 // filler
            return ControllaFormato(sb);
        }

        public string FormattaStringa(string valore, int lunghezza){
            return (valore + "".PadLeft(lunghezza)).Substring(0, lunghezza);
        }
        public string FormattaNumero(string valore, int lunghezza) {
            string retValue = valore;
            if (valore.Length < lunghezza)
                retValue = retValue.PadLeft(lunghezza, '0');
            return retValue.Substring(0, lunghezza);
        }
        public string FormattaNumero(int valore, int lunghezza) {
            return FormattaNumero(valore.ToString(), lunghezza);
        }
        public string FormattaDecimal(decimal valore, int lunghezza){
            valore = Math.Round(valore, 2) * 100;
            string s = "".PadLeft(lunghezza, '0');
            return valore.ToString(s);
        }
        

    }
}
