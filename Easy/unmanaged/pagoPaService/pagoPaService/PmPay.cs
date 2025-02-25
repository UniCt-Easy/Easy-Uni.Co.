
/*
Easy
Copyright (C) 2025 Università degli Studi di Catania (www.unict.it)
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
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.IO;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using funzioni_configurazione;
using metadatalibrary;
using System.Net.Http;
using System.Xml;
using System.Xml.Serialization;
using System.Runtime.Serialization;

namespace pagoPaService {
    public class PmPay {
        public string endPoint { get; }

        public string user { get; }

        public string password { get; }

        public PmPay(string urlRest, string user = null, string password = null) {

            endPoint = urlRest;
            this.user = user;
            this.password = password;
        }

        [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.1.0 (Newtonsoft.Json v11.0.0.0)")]
        public partial class Credenziali {
            [Newtonsoft.Json.JsonProperty("username", Required = Newtonsoft.Json.Required.Always)]
            public string Username { get; set; }

            [Newtonsoft.Json.JsonProperty("password", Required = Newtonsoft.Json.Required.Always)]
            public string Password { get; set; }

            public System.Collections.Generic.IDictionary<string, object> _additionalProperties = new System.Collections.Generic.Dictionary<string, object>();

            [Newtonsoft.Json.JsonExtensionData]
            public System.Collections.Generic.IDictionary<string, object> AdditionalProperties {
                get { return _additionalProperties; }
                set { _additionalProperties = value; }
            }

        }

        //public string inviaCrediti()

        //------------------------------------------------------------------------------------------------
        //  Autenticazione
        //  https://secure.pmpay.it/pagoparest/autenticazione
        //------------------------------------------------------------------------------------------------

        public string GetToken(string urlAuth, out string error) {
            error = "";
            if (urlAuth == null) {
                error = "URL non configurato.";
                return "";
			}
            urlAuth = "https://secure.pmpay.it/pagoparest/autenticazione";
            string token = "";
            string responseBody = string.Empty;
            //var binding = new BasicHttpsBinding();
            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;

            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(urlAuth);
            webRequest.ContentType = "application/json";
            webRequest.Method = "POST";

            Credenziali currCred = new Credenziali() {
                Username = user,
                Password = password
            };
            string json = JsonConvert.SerializeObject(currCred);

            // ... e li decodifica in una array di byte
            byte[] byteArray = Encoding.UTF8.GetBytes(json);
            // Imposta la ContentLength property della WebRequest.
            webRequest.ContentLength = byteArray.Length;

            // Acquisisce lo stream della richiesta 
            Stream dataStream = webRequest.GetRequestStream();

            // Scrive i dati nella request stream.
            dataStream.Write(byteArray, 0, byteArray.Length);

            // Chiude l'oggetto
            dataStream.Close();

            try {
                using (HttpWebResponse response = (HttpWebResponse)webRequest.GetResponse())
                using (Stream stream = response.GetResponseStream())
                using (StreamReader reader = new StreamReader(stream)) {
                    responseBody = reader.ReadToEnd();

                    JObject sel = JObject.Parse(responseBody);
                    //token: "4d0cab9566be41ee9780967f7081d1df",
                    //expiration: "2024-07-29T14:46:40.994529228Z"
                    string token_ricevuto = sel["token"].ToString();
                    string expiration_ricevuto = sel["expiration"].ToString();
                    return token_ricevuto;

                }
            }
            catch (Exception Ex) {
                string s = Ex.Message;
                error =  "Errore nell'ottenimento del token :\n" + s;
            }
            return token;
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <summary>Calcolo di un nuovo identificativo univoco</summary>
        /// <param name="codiceEnte">Codice dell'ente</param>
        /// <returns>IUV generato</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>

        //--------------------------------------------------------------------------
        //  Rilascio IUV
        //  https://secure.pmpay.it/pagoparest/ente/PMP43/genera-iuv
        //--------------------------------------------------------------------------
        public string GenerateIUV(string codiceEnte, object token, BodyIuv currBodyIuv) {
            if (codiceEnte == null)
                throw new System.ArgumentNullException("codiceEnte");
            string iuv_ricevuto = "";
            string responseBody = string.Empty;
            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(endPoint != null ? endPoint.TrimEnd('/') : "").Append("/ente/{codiceEnte}/genera-iuv");
            urlBuilder_.Replace("{codiceEnte}", System.Uri.EscapeDataString(ConvertToString(codiceEnte, System.Globalization.CultureInfo.InvariantCulture)));

            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(urlBuilder_.ToString());
            webRequest.ContentType = "application/json";
            webRequest.Method = "POST";
            webRequest.Headers["Authorization"] = "Bearer " + token;


            string json = JsonConvert.SerializeObject(currBodyIuv);
            // ... e li decodifica in una array di byte
            byte[] byteArray = Encoding.UTF8.GetBytes(json);
            // Imposta la ContentLength property della WebRequest.
            webRequest.ContentLength = byteArray.Length;

            // Acquisisce lo stream della richiesta 
            Stream dataStream = webRequest.GetRequestStream();

            // Scrive i dati nella request stream.
            dataStream.Write(byteArray, 0, byteArray.Length);

            // Chiude l'oggetto
            dataStream.Close();
                try {
                using (HttpWebResponse response = (HttpWebResponse)webRequest.GetResponse())
                using (Stream stream = response.GetResponseStream())
                using (StreamReader reader = new StreamReader(stream)) {
                    responseBody = reader.ReadToEnd();

                    JObject sel = JObject.Parse(responseBody);
                    //    "iuv": "01000000000003376"
                    iuv_ricevuto = sel["iuv"].ToString();
                }
            }
            catch (Exception Ex) {
                string s = Ex.Message;
            }
            return iuv_ricevuto;
        }

        //--------------------------------------------------------------------------
        //  Genera una lista di IUV
        //  https://secure.pmpay.it/pagoparest/ente/PMP43/genera-multi-iuv
        //--------------------------------------------------------------------------
        public string[] GenerateMultiIUV(string codiceEnte, object token, BodyMultiIuv currBodyMultiIuv, out string error) {
            error = "";
            if (codiceEnte == null)
                throw new System.ArgumentNullException("codiceEnte");
            string[] listaIuv = null;
            string responseBody = string.Empty;
            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(endPoint != null ? endPoint.TrimEnd('/') : "").Append("/ente/{codiceEnte}/genera-multi-iuv");
            urlBuilder_.Replace("{codiceEnte}", System.Uri.EscapeDataString(ConvertToString(codiceEnte, System.Globalization.CultureInfo.InvariantCulture)));

            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(urlBuilder_.ToString());
            webRequest.ContentType = "application/json";
            webRequest.Method = "POST";
            webRequest.Headers["Authorization"] = "Bearer " + token;


            string json = JsonConvert.SerializeObject(currBodyMultiIuv);
            // ... e li decodifica in una array di byte
            byte[] byteArray = Encoding.UTF8.GetBytes(json);
            // Imposta la ContentLength property della WebRequest.
            webRequest.ContentLength = byteArray.Length;

            // Acquisisce lo stream della richiesta 
            Stream dataStream = webRequest.GetRequestStream();

            // Scrive i dati nella request stream.
            dataStream.Write(byteArray, 0, byteArray.Length);

            // Chiude l'oggetto
            dataStream.Close();

            try {
                using (HttpWebResponse response = (HttpWebResponse)webRequest.GetResponse())
                using (Stream stream = response.GetResponseStream())
                using (StreamReader reader = new StreamReader(stream)) {
                    responseBody = reader.ReadToEnd();

                    JObject sel = JObject.Parse(responseBody);
                    //    "iuv": "01000000000003376"
                    string codiceServizio = sel["codiceServizio"].ToString();
                    string numeroIuvRichiesti = sel["numeroIuvRichiesti"].ToString();
                    string StrIuv_ricevuti = sel["iuv"].ToString();
                    listaIuv = JsonConvert.DeserializeObject<string[]>(StrIuv_ricevuti);
                }
            }
            catch (Exception Ex) {
                error = Ex.Message;
            }
            return listaIuv;
        }

        // TODO
        public string InserimentoNuovoPagamentoPmpay(string codiceEnte, object token, Pagamento currPagamento, out string errorPagamento) {
            errorPagamento = "";
            string codeEsito = "";
            if (codiceEnte == null)
                throw new System.ArgumentNullException("codiceEnte");
            string[] listaIuv = null;
            string iuv = currPagamento.Iuv;
            string responseBody = string.Empty;
            var urlBuilder_ = new System.Text.StringBuilder();

            urlBuilder_.Append(endPoint != null ? endPoint.TrimEnd('/') : "").Append("/ente/{codiceEnte}/pagamento");
            urlBuilder_.Replace("{codiceEnte}", System.Uri.EscapeDataString(ConvertToString(codiceEnte, System.Globalization.CultureInfo.InvariantCulture)));
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(urlBuilder_.ToString());
            webRequest.ContentType = "application/json";
            webRequest.Method = "POST";
            webRequest.Headers["Authorization"] = "Bearer " + token;


            string json = JsonConvert.SerializeObject(currPagamento);
            // ... e li decodifica in una array di byte
            byte[] byteArray = Encoding.UTF8.GetBytes(json);
            // Imposta la ContentLength property della WebRequest.
            webRequest.ContentLength = byteArray.Length;

            // Acquisisce lo stream della richiesta 
            Stream dataStream = webRequest.GetRequestStream();

            // Scrive i dati nella request stream.
            dataStream.Write(byteArray, 0, byteArray.Length);

            // Chiude l'oggetto
            dataStream.Close();
            ////try {
            ////    ErrorResponseInsertPagamento err = JsonConvert.DeserializeObject<ErrorResponseInsertPagamento>((new StreamReader(((HttpWebResponse)webRequest.GetResponse()).GetResponseStream())).ReadToEnd());
            ////}
            ////catch (Exception Ex) {
            ////    errorPagamento += Ex.Message;
            ////}

            try {
                using (var response = webRequest.GetResponse()) {

                    var x = ((HttpWebResponse)response).StatusCode;
                    using (Stream stream = response.GetResponseStream()) {
                        using (StreamReader reader = new StreamReader(stream)) {
                            responseBody = reader.ReadToEnd();
                            if (responseBody.Contains("errors")) {
                                try {
                                    ErrorResponseInsertPagamento err = JsonConvert.DeserializeObject<ErrorResponseInsertPagamento>(responseBody);
                                    // Update Info
                                    if (err != null)
                                        errorPagamento = err.Message + "" + err.Errors;
                                    else
                                        errorPagamento += $"{"Failed to call API: " + responseBody}";
                                }
                                catch (Exception Ex) {
                                    errorPagamento += Ex.Message;
                                }
                            }
                            else {
                                try {
                                    JObject sel = JObject.Parse(responseBody);
                                    codeEsito = sel["code"].ToString();
                                    if (codeEsito != null) {
                                        return codeEsito;
                                    }
                                }
                                catch (Exception Ex) {
                                    // something wrong
                                    errorPagamento += Ex.Message;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception Ex) {
                errorPagamento = Ex.Message;
                
            }
            return errorPagamento;

        }

        public FlussoRiversamento GetRendicontazionePmpay(string codiceEnte, string token, string id_Rendicontazione, out string errore) {
            errore = null;

            //L’operazione restituisce il file XML di rendicontazione come ricevuto da nodo SPC o messaggio di errore nel caso di operazione non andata a buon fine.

            errore = null;

            var wc = new WebClient();
            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;

            wc.Headers["Authorization"] = "Bearer " + token;
            string addr = endPoint + "ente/"+codiceEnte+"/rendicontazione/"+id_Rendicontazione;

            try {
                var response = wc.DownloadData(new Uri(addr));
                var memStream = new MemoryStream(response);
                // Controllare se XML oppure generica stringa errore

                try {
                    var xmlDoc = new XmlDocument();
                    xmlDoc.Load(memStream);
                    //XmlElement xmlDoc = xmlDoc.GetElementById("identificativoFlusso");
                    if (xmlDoc.InnerXml.ToString().Contains("identificativoFlusso")) {
                        memStream.Position = 0;

                        var serializer = new XmlSerializer(typeof(FlussoRiversamento));
                        var reader = XmlReader.Create(memStream);
                        try {
                            var rendiconto = (FlussoRiversamento)serializer.Deserialize(reader);
                            return rendiconto;
                        }
                        catch (Exception ex) {
                            //var ricevuta = new FlussoRiversamento();
                            //errore = ex.ToString();
                            //rendiconto.codiceBicBancaDiRiversamento = "123";
                            //rendiconto.dataOraFlusso = DateTime.Now;
                            //rendiconto.identificativoFlusso = "12345";
                            //rendiconto = GenericSerializer.toXml<FlussoRiversamento>(ricevuta);
                            errore = ex.ToString();
                        }
                    }
                    else {
                        errore = xmlDoc.ToString();
                    }
                }
                catch (Exception ex) {
                    // Lettura della stringa di errore
                    StreamReader sr = new StreamReader(memStream);
                    long pos = memStream.Position;
                    memStream.Position = 0;

                    string data = sr.ReadToEnd();
                    errore = data;

                }
            }
            catch (Exception ex) {
                //We catch non Http 200 responses here.
                errore = ex.ToString();

            }

            return null;

        }

        public List<string> PostElencoPagamentiPmpay(string codiceEnte, object token, int esercizio, PmPay rClient, DateTime start, DateTime stop, out string errore) {

            DateTime inizioperiodo = new DateTime();
            DateTime fineperiodoprecedente = new DateTime();

            List<DateTime> dateinizio = new List<DateTime>();
            List<DateTime> datefine = new List<DateTime>();
            for (DateTime d = start;
                    d <= stop; // 
                    d = d.AddMonths(1)) {
                inizioperiodo = d;
                fineperiodoprecedente = d.AddDays(-1);
                dateinizio.Add(inizioperiodo.Date);
                if ((fineperiodoprecedente < stop) && (fineperiodoprecedente > start))
                    datefine.Add(fineperiodoprecedente.Date);

            }
            datefine.Add(stop.Date);
            List<string> elencoRendiconti = new List<string>();

            //--https://service.pmpay.it/pagoparest/ente/PMP43/pagamento/ricerca
            List<string> listId_Rendicontazione = new List<string>();
            errore = "";
            var wc = new WebClient();
            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;

            wc.Headers.Add(HttpRequestHeader.Authorization,
                "Basic " + Convert.ToBase64String(Encoding.ASCII.GetBytes(user + ":" + password)));

            for (int i = 0; i <= dateinizio.Count - 1; i++) {
            
                RichiestaPaginazione CurrPaginazione = new RichiestaPaginazione {
                    DimensionePagina = 1000,
                    PaginaCorrente = 1
                };
                RicercaPagamento CurrRicercaPagamento = new RicercaPagamento() {
                    Paginazione = CurrPaginazione,
                    DataOperazioneDa = dateinizio[i],
                    DataOperazioneA = datefine[i],
                    StatoPagamento = StatoPagamento.CON,
                    TipoEsecuzionePagamento = TipoEsecuzionePagamento.PO,
                    StatoRendicontato = true

                };
                string responseBody = string.Empty;
                var urlBuilder_ = new System.Text.StringBuilder();

                urlBuilder_.Append(endPoint != null ? endPoint.TrimEnd('/') : "").Append("/ente/{codiceEnte}/pagamento/ricerca");
                urlBuilder_.Replace("{codiceEnte}", System.Uri.EscapeDataString(ConvertToString(codiceEnte, System.Globalization.CultureInfo.InvariantCulture)));

                HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(urlBuilder_.ToString());
                webRequest.ContentType = "application/json";
                webRequest.Method = "POST";
                webRequest.Headers["Authorization"] = "Bearer " + token;


                string json = JsonConvert.SerializeObject(CurrRicercaPagamento);
                // ... e li decodifica in una array di byte
                byte[] byteArray = Encoding.UTF8.GetBytes(json);
                // Imposta la ContentLength property della WebRequest.
                webRequest.ContentLength = byteArray.Length;

                // Acquisisce lo stream della richiesta 
                Stream dataStream = webRequest.GetRequestStream();

                // Scrive i dati nella request stream.
                dataStream.Write(byteArray, 0, byteArray.Length);

                // Chiude l'oggetto
                dataStream.Close();
                try {
                    using (HttpWebResponse response = (HttpWebResponse)webRequest.GetResponse())
                    using (Stream stream = response.GetResponseStream())
                    using (StreamReader reader = new StreamReader(stream)) {
                        responseBody = reader.ReadToEnd();
                        if (responseBody.Contains("errors")) {
                            try {
                                ErrorResponse err = JsonConvert.DeserializeObject<ErrorResponse>(responseBody);
                                // Update Info
                                if (err != null)
                                    errore = err.Message + "" + err.Errors;
                                else
                                    errore += $"{"Failed to call API: " + responseBody}";
                            }
                            catch (Exception Ex) {
                                errore += Ex.Message;
                            }
                        }
                        else {
                            try {
                                RicercaPagamentoRisposta Risp = JsonConvert.DeserializeObject<RicercaPagamentoRisposta>(responseBody);
                                List<Pagamento> Items = Risp.Items;
                                // è stato scritto solo per test della response
                                //Pagamento Items_0 = Items[0];
                                //List<Versamento> VV = Items_0.Versamenti;
                                //Versamento V_0 = VV[0];
                                //object id = V_0.IdFlussoRendicontazione;

                                foreach (var I in Items) {
                                    List<Versamento> listaVersamenti = I.Versamenti;
                                    foreach (var V in listaVersamenti) {
                                        string id_rendicontazione = V.IdFlussoRendicontazione;
                                        listId_Rendicontazione.Add(id_rendicontazione);
                                    }
                                }

                            }
                            catch (Exception Ex) {
                                // something wrong
                                errore += Ex.Message;
                            }
                        }
                    }
                }
                catch (Exception Ex) {
                    errore = Ex.Message;
                }

            }

            return listId_Rendicontazione;

        }



        //------------------------------------------------------------------------------------------------------------------------------------------------
        //------------------------------------------------------------------------------------------------------------------------------------------------
        //------------------------------------------------------------------------------------------------------------------------------------------------

        public class cMultiIuv {
            public string iuv { get; set; }
        }
        private string ConvertToString(object value, System.Globalization.CultureInfo cultureInfo) {
            if (value == null) {
                return null;
            }

            if (value is System.Enum) {
                var name = System.Enum.GetName(value.GetType(), value);
                if (name != null) {
                    var field = System.Reflection.IntrospectionExtensions.GetTypeInfo(value.GetType()).GetDeclaredField(name);
                    if (field != null) {
                        var attribute = System.Reflection.CustomAttributeExtensions.GetCustomAttribute(field, typeof(System.Runtime.Serialization.EnumMemberAttribute))
                            as System.Runtime.Serialization.EnumMemberAttribute;
                        if (attribute != null) {
                            return attribute.Value != null ? attribute.Value : name;
                        }
                    }

                    return System.Convert.ToString(System.Convert.ChangeType(value, System.Enum.GetUnderlyingType(value.GetType()), cultureInfo));
                }
            }
            else if (value is bool) {
                return System.Convert.ToString((bool)value, cultureInfo).ToLowerInvariant();
            }
            else if (value is byte[]) {
                return System.Convert.ToBase64String((byte[])value);
            }
            else if (value.GetType().IsArray) {
                var array = System.Linq.Enumerable.OfType<object>((System.Array)value);
                return string.Join(",", System.Linq.Enumerable.Select(array, o => ConvertToString(o, cultureInfo)));
            }

            var result = System.Convert.ToString(value, cultureInfo);
            return (result is null) ? string.Empty : result;
        }




    }

    public class BodyIuv {
        public string codiceServizio { get; set; }
    }
    public class BodyMultiIuv {
        public string codiceServizio { get; set; }
        public int numeroIuvRichiesti { get; set; }
    }
    public partial class RicercaPagamento {
        [Newtonsoft.Json.JsonProperty("paginazione", Required = Newtonsoft.Json.Required.Always)]
        public RichiestaPaginazione Paginazione { get; set; }

        [Newtonsoft.Json.JsonProperty("ordinamento", Required = Newtonsoft.Json.Required.AllowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public Ordinamento Ordinamento { get; set; }

        [Newtonsoft.Json.JsonProperty("importoDa", Required = Newtonsoft.Json.Required.AllowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string ImportoDa { get; set; }

        [Newtonsoft.Json.JsonProperty("importoA", Required = Newtonsoft.Json.Required.AllowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string ImportoA { get; set; }

        //[Newtonsoft.Json.JsonProperty("dataInserimentoDa", Required = Newtonsoft.Json.Required.AllowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        //public System.DateTime DataInserimentoDa { get; set; }

        //[Newtonsoft.Json.JsonProperty("dataInsermentoA", Required = Newtonsoft.Json.Required.AllowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]

        //public System.DateTime DataInsermentoA { get; set; }

        [Newtonsoft.Json.JsonProperty("dataOperazioneDa", Required = Newtonsoft.Json.Required.AllowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]

        public System.DateTime DataOperazioneDa { get; set; }

        [Newtonsoft.Json.JsonProperty("dataOperazioneA", Required = Newtonsoft.Json.Required.AllowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]

        public System.DateTime DataOperazioneA { get; set; }

        //[Newtonsoft.Json.JsonProperty("dataScadenzaDa", Required = Newtonsoft.Json.Required.AllowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]

        //public System.DateTime DataScadenzaDa { get; set; }

        //[Newtonsoft.Json.JsonProperty("dataScadenzaA", Required = Newtonsoft.Json.Required.AllowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]

        //public System.DateTime DataScadenzaA { get; set; }

        //[Newtonsoft.Json.JsonProperty("dataRendicontazioneDa", Required = Newtonsoft.Json.Required.AllowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]

        //public System.DateTime DataRendicontazioneDa { get; set; }

        //[Newtonsoft.Json.JsonProperty("dataRendicontazioneA", Required = Newtonsoft.Json.Required.AllowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        //public System.DateTime DataRendicontazioneA { get; set; }

        [Newtonsoft.Json.JsonProperty("servizio", Required = Newtonsoft.Json.Required.AllowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Servizio { get; set; }

        [Newtonsoft.Json.JsonProperty("idFiscale", Required = Newtonsoft.Json.Required.AllowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string IdFiscale { get; set; }

        [Newtonsoft.Json.JsonProperty("statoPagamento", Required = Newtonsoft.Json.Required.AllowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public StatoPagamento StatoPagamento { get; set; }

        [Newtonsoft.Json.JsonProperty("statoRendicontato", Required = Newtonsoft.Json.Required.AllowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool StatoRendicontato { get; set; }

        [Newtonsoft.Json.JsonProperty("canaleInsermentoPagamento", Required = Newtonsoft.Json.Required.AllowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string CanaleInsermentoPagamento { get; set; }

        [Newtonsoft.Json.JsonProperty("tipoEsecuzionePagamento", Required = Newtonsoft.Json.Required.AllowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public TipoEsecuzionePagamento TipoEsecuzionePagamento { get; set; }

        [Newtonsoft.Json.JsonProperty("iuv", Required = Newtonsoft.Json.Required.AllowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Iuv { get; set; }

        [Newtonsoft.Json.JsonProperty("idDebito", Required = Newtonsoft.Json.Required.AllowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string IdDebito { get; set; }

        [Newtonsoft.Json.JsonProperty("idFlussoRendicontazione", Required = Newtonsoft.Json.Required.AllowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string IdFlussoRendicontazione { get; set; }

        [Newtonsoft.Json.JsonProperty("numeroAvviso", Required = Newtonsoft.Json.Required.AllowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string NumeroAvviso { get; set; }
    }
    public enum TipoEsecuzionePagamento {
        [System.Runtime.Serialization.EnumMember(Value = @"ON")]
        ON = 0,

        [System.Runtime.Serialization.EnumMember(Value = @"PO")]
        PO = 1,

        [System.Runtime.Serialization.EnumMember(Value = @"POS")]
        POS = 2,

    }
    public partial class RicercaPagamentoRisposta {
        [Newtonsoft.Json.JsonProperty("paginazione", Required = Newtonsoft.Json.Required.AllowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public Paginazione Paginazione { get; set; }

        [Newtonsoft.Json.JsonProperty("ordinamento", Required = Newtonsoft.Json.Required.AllowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public Ordinamento Ordinamento { get; set; }

        [Newtonsoft.Json.JsonProperty("items", Required = Newtonsoft.Json.Required.AllowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public List<Pagamento> Items { get; set; }

        private System.Collections.Generic.IDictionary<string, object> _additionalProperties = new System.Collections.Generic.Dictionary<string, object>();

        [Newtonsoft.Json.JsonExtensionData]
        public System.Collections.Generic.IDictionary<string, object> AdditionalProperties {
            get { return _additionalProperties; }
            set { _additionalProperties = value; }
        }
    }
    public partial class Paginazione : RichiestaPaginazione {
        [Newtonsoft.Json.JsonProperty("numeroPagineTotali", Required = Newtonsoft.Json.Required.AllowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int NumeroPagineTotali { get; set; }

        [Newtonsoft.Json.JsonProperty("numeroElementiTotali", Required = Newtonsoft.Json.Required.AllowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int NumeroElementiTotali { get; set; }

        [Newtonsoft.Json.JsonProperty("numeroElementiPagina", Required = Newtonsoft.Json.Required.AllowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int NumeroElementiPagina { get; set; }

        private System.Collections.Generic.IDictionary<string, object> _additionalProperties = new System.Collections.Generic.Dictionary<string, object>();

        [Newtonsoft.Json.JsonExtensionData]
        public System.Collections.Generic.IDictionary<string, object> AdditionalProperties {
            get { return _additionalProperties; }
            set { _additionalProperties = value; }
        }
    }
    public partial class RichiestaPaginazione {
        [Newtonsoft.Json.JsonProperty("dimensionePagina", Required = Newtonsoft.Json.Required.Always)]
        public int DimensionePagina { get; set; }

        [Newtonsoft.Json.JsonProperty("paginaCorrente", Required = Newtonsoft.Json.Required.Always)]
        public int PaginaCorrente { get; set; }

        private System.Collections.Generic.IDictionary<string, object> _additionalProperties = new System.Collections.Generic.Dictionary<string, object>();

        [Newtonsoft.Json.JsonExtensionData]
        public System.Collections.Generic.IDictionary<string, object> AdditionalProperties {
            get { return _additionalProperties; }
            set { _additionalProperties = value; }
        }


    }
    public partial class Ordinamento : System.Collections.ObjectModel.Collection<CampoOrdinamento> {

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.1.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class CampoOrdinamento {
        [Newtonsoft.Json.JsonProperty("campo", Required = Newtonsoft.Json.Required.AllowNull)]
        public CampoOrdinamentoCampo Campo { get; set; }

        [Newtonsoft.Json.JsonProperty("ascDesc", Required = Newtonsoft.Json.Required.AllowNull)]
        public CampoOrdinamentoAscDesc AscDesc { get; set; }

        private System.Collections.Generic.IDictionary<string, object> _additionalProperties = new System.Collections.Generic.Dictionary<string, object>();

        [Newtonsoft.Json.JsonExtensionData]
        public System.Collections.Generic.IDictionary<string, object> AdditionalProperties {
            get { return _additionalProperties; }
            set { _additionalProperties = value; }
        }
    }
    public enum CampoOrdinamentoAscDesc {
        [System.Runtime.Serialization.EnumMember(Value = @"ASC")]
        ASC = 0,

        [System.Runtime.Serialization.EnumMember(Value = @"DESC")]
        DESC = 1,

    }
    public enum CampoOrdinamentoCampo {
        [System.Runtime.Serialization.EnumMember(Value = @"importo")]
        Importo = 0,

        [System.Runtime.Serialization.EnumMember(Value = @"dataInserimento")]
        DataInserimento = 1,

        [System.Runtime.Serialization.EnumMember(Value = @"dataOperazione")]
        DataOperazione = 2,

        [System.Runtime.Serialization.EnumMember(Value = @"dataScadenza")]
        DataScadenza = 3,

        [System.Runtime.Serialization.EnumMember(Value = @"dataRendicontazione")]
        DataRendicontazione = 4,

        [System.Runtime.Serialization.EnumMember(Value = @"servizio")]
        Servizio = 5,

        [System.Runtime.Serialization.EnumMember(Value = @"idFiscale")]
        IdFiscale = 6,

        [System.Runtime.Serialization.EnumMember(Value = @"statoPagamento")]
        StatoPagamento = 7,

        [System.Runtime.Serialization.EnumMember(Value = @"statoRendicontato")]
        StatoRendicontato = 8,

        [System.Runtime.Serialization.EnumMember(Value = @"canaleInsermentoPagamento")]
        CanaleInsermentoPagamento = 9,

        [System.Runtime.Serialization.EnumMember(Value = @"tipoEsecuzionePagamento")]
        TipoEsecuzionePagamento = 10,

        [System.Runtime.Serialization.EnumMember(Value = @"iuv")]
        Iuv = 11,

        [System.Runtime.Serialization.EnumMember(Value = @"idDebito")]
        IdDebito = 12,

        [System.Runtime.Serialization.EnumMember(Value = @"dataInizioValidita")]
        DataInizioValidita = 13,

        [System.Runtime.Serialization.EnumMember(Value = @"dataFineValidita")]
        DataFineValidita = 14,

        [System.Runtime.Serialization.EnumMember(Value = @"iur")]
        Iur = 15,

        [System.Runtime.Serialization.EnumMember(Value = @"causale")]
        Causale = 16,

        [System.Runtime.Serialization.EnumMember(Value = @"idFlussoRendicontazione")]
        IdFlussoRendicontazione = 17,

        [System.Runtime.Serialization.EnumMember(Value = @"numeroAvviso")]
        NumeroAvviso = 18,

    }

    public partial class Pagamento {
        [Newtonsoft.Json.JsonProperty("iuv", Required = Newtonsoft.Json.Required.AllowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Iuv { get; set; }

        [Newtonsoft.Json.JsonProperty("numeroAvviso", Required = Newtonsoft.Json.Required.AllowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string NumeroAvviso { get; set; }

        [Newtonsoft.Json.JsonProperty("idDebito", Required = Newtonsoft.Json.Required.AllowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string IdDebito { get; set; }

        [Newtonsoft.Json.JsonProperty("importo", Required = Newtonsoft.Json.Required.AllowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Importo { get; set; }

        [Newtonsoft.Json.JsonProperty("dataScadenza", Required = Newtonsoft.Json.Required.AllowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]

        public System.DateTime DataScadenza { get; set; }

        //[Newtonsoft.Json.JsonProperty("dataInizioValidita", Required = Newtonsoft.Json.Required.AllowNull )]

        //public System.DateTime DataInizioValidita { get; set; }

        //[Newtonsoft.Json.JsonProperty("dataFineValidita", Required = Newtonsoft.Json.Required.AllowNull)]

        //public System.DateTime DataFineValidita { get; set; }

        /// <summary>Per eseguire pagamenti anonimi `idFiscaleDebitore` deve essere valorizzato con il valore: XYZXYZ80A01H501C</summary>
        [Newtonsoft.Json.JsonProperty("idFiscaleDebitore", Required = Newtonsoft.Json.Required.Always)]
        public string IdFiscaleDebitore { get; set; }

        /// <summary>specificando questo campo è possibile definire e salvare l'anagrafica proprio come avviene chiamando /ente/{codiceEnte}/anagrafica</summary>
        [Newtonsoft.Json.JsonProperty("anagrafica", Required = Newtonsoft.Json.Required.AllowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public Anagrafica Anagrafica { get; set; }

        /// <summary>Identifica i pagamenti costituenti lo stesso pacchetto rate</summary>
        //[Newtonsoft.Json.JsonProperty("idRata", Required = Newtonsoft.Json.Required.AllowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        //public string IdRata { get; set; }

        ///// <summary>Identifica l'ordine dei pagamenti all'interno del pacchetto di rate. 0 = rata unica. Considerato solo in presenza di idRata</summary>
        //[Newtonsoft.Json.JsonProperty("idxRata", Required = Newtonsoft.Json.Required.AllowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        //public int IdxRata { get; set; }

        [Newtonsoft.Json.JsonProperty("versamenti", Required = Newtonsoft.Json.Required.Always)]
        public System.Collections.Generic.List<Versamento> Versamenti { get; set; }

        //[Newtonsoft.Json.JsonProperty("datiAggiuntiviADisposizione", Required = Newtonsoft.Json.Required.AllowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        //public DatiAggiuntivi DatiAggiuntiviADisposizione { get; set; }

        //[Newtonsoft.Json.JsonProperty("dataInsermento", Required = Newtonsoft.Json.Required.AllowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        //public System.DateTime DataInsermento { get; set; }

        //[Newtonsoft.Json.JsonProperty("dataOperazione", Required = Newtonsoft.Json.Required.AllowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]

        //public System.DateTime DataOperazione { get; set; }

        //[Newtonsoft.Json.JsonProperty("numeroVersamenti", Required = Newtonsoft.Json.Required.AllowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        //public int NumeroVersamenti { get; set; }

        //[Newtonsoft.Json.JsonProperty("iur", Required = Newtonsoft.Json.Required.AllowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        //public string Iur { get; set; }

        /// <summary>
        /// * ON indica un pagamento effettuato tramite modello 1
        /// * PO indica un pagamento effettuato tramite modello 3
        /// * POS indica un pagamento effettuato tramite POS
        /// </summary>
        [Newtonsoft.Json.JsonProperty("tipoEsecuzionePagamento", Required = Newtonsoft.Json.Required.AllowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string TipoEsecuzionePagamento { get; set; }

        [Newtonsoft.Json.JsonProperty("statoPagamento", Required = Newtonsoft.Json.Required.AllowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public StatoPagamento StatoPagamento { get; set; }

        [Newtonsoft.Json.JsonProperty("canaleInserimentoPagamento", Required = Newtonsoft.Json.Required.AllowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string CanaleInserimentoPagamento { get; set; }

        /// <summary>in caso di pagamento concluso (stato CON) viene riportato l'iban su cui è stato accreditato l'importo, si consiglia di usare quello contenuto nei versamenti</summary>
        [Newtonsoft.Json.JsonProperty("iban", Required = Newtonsoft.Json.Required.AllowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Iban { get; set; }

        /// <summary>Contiene i dati realitivi all'attualizzazione del pagamento</summary>
        [Newtonsoft.Json.JsonProperty("datiAttualizzazione", Required = Newtonsoft.Json.Required.AllowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public DatiAttualizzazione DatiAttualizzazione { get; set; }

        private System.Collections.Generic.IDictionary<string, object> _additionalProperties = new System.Collections.Generic.Dictionary<string, object>();

        [Newtonsoft.Json.JsonExtensionData]
        public System.Collections.Generic.IDictionary<string, object> AdditionalProperties {
            get { return _additionalProperties; }
            set { _additionalProperties = value; }
        }
    }

    public partial class ErrorResponseInsertPagamento {
        [Newtonsoft.Json.JsonProperty("status", Required = Newtonsoft.Json.Required.AllowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int Status { get; set; }

        [Newtonsoft.Json.JsonProperty("reason", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Reason { get; set; }

        [Newtonsoft.Json.JsonProperty("message", Required = Newtonsoft.Json.Required.AllowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Message { get; set; }

        [Newtonsoft.Json.JsonProperty("errors", Required = Newtonsoft.Json.Required.AllowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<string> Errors { get; set; }

        private System.Collections.Generic.IDictionary<string, object> _additionalProperties = new System.Collections.Generic.Dictionary<string, object>();

        [Newtonsoft.Json.JsonExtensionData]
        public System.Collections.Generic.IDictionary<string, object> AdditionalProperties {
            get { return _additionalProperties; }
            set { _additionalProperties = value; }
        }


    }
    internal class DateFormatConverter : Newtonsoft.Json.Converters.IsoDateTimeConverter {
        public DateFormatConverter() {
            DateTimeFormat = "yyyy-MM-dd";
        }
    }
    public partial class Anagrafica {
        [Newtonsoft.Json.JsonProperty("codiceEnte", Required = Newtonsoft.Json.Required.Always)]
        public string CodiceEnte { get; set; }

        [Newtonsoft.Json.JsonProperty("idFiscale", Required = Newtonsoft.Json.Required.Always)]
        public IdFiscale IdFiscale { get; set; }

        [Newtonsoft.Json.JsonProperty("anagrafica", Required = Newtonsoft.Json.Required.Always)]
        public string AnagraficaDenominazione { get; set; }

        [Newtonsoft.Json.JsonProperty("indirizzo", Required = Newtonsoft.Json.Required.AllowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Indirizzo { get; set; }

        [Newtonsoft.Json.JsonProperty("cap", Required = Newtonsoft.Json.Required.AllowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Cap { get; set; }

        [Newtonsoft.Json.JsonProperty("localita", Required = Newtonsoft.Json.Required.AllowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Localita { get; set; }

        [Newtonsoft.Json.JsonProperty("provincia", Required = Newtonsoft.Json.Required.AllowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Provincia { get; set; }

        [Newtonsoft.Json.JsonProperty("nazione", Required = Newtonsoft.Json.Required.AllowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Nazione { get; set; }

        [Newtonsoft.Json.JsonProperty("email", Required = Newtonsoft.Json.Required.AllowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string Email { get; set; }

        private System.Collections.Generic.IDictionary<string, object> _additionalProperties = new System.Collections.Generic.Dictionary<string, object>();

        [Newtonsoft.Json.JsonExtensionData]
        public System.Collections.Generic.IDictionary<string, object> AdditionalProperties {
            get { return _additionalProperties; }
            set { _additionalProperties = value; }
        }
    }

    public partial class Versamento {
        [Newtonsoft.Json.JsonProperty("importo", Required = Newtonsoft.Json.Required.Always)]
        public string Importo { get; set; }

        [Newtonsoft.Json.JsonProperty("causale", Required = Newtonsoft.Json.Required.AllowNull)]
        public string Causale { get; set; }

        [Newtonsoft.Json.JsonProperty("servizio", Required = Newtonsoft.Json.Required.AllowNull)]

        public string Servizio { get; set; }

        [Newtonsoft.Json.JsonProperty("vociVersamento", Required = Newtonsoft.Json.Required.AllowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string VociVersamento { get; set; }

        [Newtonsoft.Json.JsonProperty("datiBollo", Required = Newtonsoft.Json.Required.AllowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public DatiBollo DatiBollo { get; set; }

        [Newtonsoft.Json.JsonProperty("datiAggiuntiviADisposizione", Required = Newtonsoft.Json.Required.AllowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public DatiAggiuntivi DatiAggiuntiviADisposizione { get; set; }

        [Newtonsoft.Json.JsonProperty("idFlussoRendicontazione", Required = Newtonsoft.Json.Required.AllowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string IdFlussoRendicontazione { get; set; }

        /// <summary>codice identificativo del psp</summary>
        [Newtonsoft.Json.JsonProperty("identificativoPsp", Required = Newtonsoft.Json.Required.AllowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string IdentificativoPsp { get; set; }

        [Newtonsoft.Json.JsonProperty("ibanAccredito", Required = Newtonsoft.Json.Required.AllowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string IbanAccredito { get; set; }

        private System.Collections.Generic.IDictionary<string, object> _additionalProperties = new System.Collections.Generic.Dictionary<string, object>();

        [Newtonsoft.Json.JsonExtensionData]
        public System.Collections.Generic.IDictionary<string, object> AdditionalProperties {
            get { return _additionalProperties; }
            set { _additionalProperties = value; }
        }
    }

    public partial class DatiAggiuntivi {
        private System.Collections.Generic.IDictionary<string, object> _additionalProperties = new System.Collections.Generic.Dictionary<string, object>();

        [Newtonsoft.Json.JsonExtensionData]
        public System.Collections.Generic.IDictionary<string, object> AdditionalProperties {
            get { return _additionalProperties; }
            set { _additionalProperties = value; }
        }
    }

    /// <summary>* DAD indica un pagamento in stato "da definire"
    /// * ATT indica un pagamento "in attesa esito"
    /// * NCO indica un pagamento in stato "non confermato"
    /// * CON indica un pagamento in stato "confermato"
    /// * RAT indica un pagamento rateale
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.1.0 (Newtonsoft.Json v11.0.0.0)")]
    public enum StatoPagamento {
        [System.Runtime.Serialization.EnumMember(Value = @"DAD")]
        DAD = 0,

        [System.Runtime.Serialization.EnumMember(Value = @"ATT")]
        ATT = 1,

        [System.Runtime.Serialization.EnumMember(Value = @"NCO")]
        NCO = 2,

        [System.Runtime.Serialization.EnumMember(Value = @"CON")]
        CON = 3,

        [System.Runtime.Serialization.EnumMember(Value = @"RAT")]
        RAT = 4,
    }
    public partial class DatiAttualizzazione {
        /// <summary>flag per forzare attualizzazione ad ogni tentativo di pagamento</summary>
        [Newtonsoft.Json.JsonProperty("flagAttualizzaSempre", Required = Newtonsoft.Json.Required.Always)]
        public bool FlagAttualizzaSempre { get; set; }

        /// <summary>url al quale inoltrare la richiesta di attualizzazione</summary>
        [Newtonsoft.Json.JsonProperty("urlAttualizzaSempre", Required = Newtonsoft.Json.Required.AllowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string UrlAttualizzaSempre { get; set; }

        private System.Collections.Generic.IDictionary<string, object> _additionalProperties = new System.Collections.Generic.Dictionary<string, object>();

        [Newtonsoft.Json.JsonExtensionData]
        public System.Collections.Generic.IDictionary<string, object> AdditionalProperties {
            get { return _additionalProperties; }
            set { _additionalProperties = value; }
        }
    }
    public partial class IdFiscale {
        /// <summary>* F se persona fisica
        /// * G persona giuridica
        /// </summary>
        [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public IdFiscaleTipo tipo { get; set; }

        [Newtonsoft.Json.JsonProperty("codice", Required = Newtonsoft.Json.Required.Always)]
        public string Codice { get; set; }

        private System.Collections.Generic.IDictionary<string, object> _additionalProperties = new System.Collections.Generic.Dictionary<string, object>();

        [Newtonsoft.Json.JsonExtensionData]
        public System.Collections.Generic.IDictionary<string, object> AdditionalProperties {
            get { return _additionalProperties; }
            set { _additionalProperties = value; }
        }
    }

    public partial class DatiBollo {
        /// <summary>01 – valore fisso</summary>
        [Newtonsoft.Json.JsonProperty("tipoBollo", Required = Newtonsoft.Json.Required.AllowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public DatiBolloTipoBollo TipoBollo { get; set; }

        /// <summary>Hash SHA256 del documento informatico rappresentato in base64, 44 caratteri ( es. test= n4bQgYhMfWWaL+qgxVrQFaO/TxsrC4Is0V1sFbDwCgg= )</summary>
        [Newtonsoft.Json.JsonProperty("impronta", Required = Newtonsoft.Json.Required.AllowNull)]

        public string Impronta { get; set; }

        /// <summary>sigla identificativa della provincia di residenza</summary>
        [Newtonsoft.Json.JsonProperty("provinciaResidenza", Required = Newtonsoft.Json.Required.AllowNull)]

        public string ProvinciaResidenza { get; set; }

        private System.Collections.Generic.IDictionary<string, object> _additionalProperties = new System.Collections.Generic.Dictionary<string, object>();

        [Newtonsoft.Json.JsonExtensionData]
        public System.Collections.Generic.IDictionary<string, object> AdditionalProperties {
            get { return _additionalProperties; }
            set { _additionalProperties = value; }
        }
    }
    public enum IdFiscaleTipo {
        [System.Runtime.Serialization.EnumMember(Value = @"F")]
        F = 0,

        [System.Runtime.Serialization.EnumMember(Value = @"G")]
        G = 1,
    }

    public enum DatiBolloTipoBollo {
        [System.Runtime.Serialization.EnumMember(Value = @"01")]
        _01 = 0,
    }

    public partial class ErrorResponse {
        [Newtonsoft.Json.JsonProperty("status", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int Status { get; set; }

        [Newtonsoft.Json.JsonProperty("reason", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Reason { get; set; }

        [Newtonsoft.Json.JsonProperty("message", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Message { get; set; }

        [Newtonsoft.Json.JsonProperty("errors", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<string> Errors { get; set; }

        private System.Collections.Generic.IDictionary<string, object> _additionalProperties = new System.Collections.Generic.Dictionary<string, object>();

        [Newtonsoft.Json.JsonExtensionData]
        public System.Collections.Generic.IDictionary<string, object> AdditionalProperties {
            get { return _additionalProperties; }
            set { _additionalProperties = value; }
        }


    }




}
