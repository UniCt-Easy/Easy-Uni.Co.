
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


using ReportGen;
using ReportGen.Models;
using RestSharp;
using System;
using System.Data;


namespace ReportGenClient {

    /// <summary>
    /// Client per il servizio di generazione report.
    /// </summary>
    public class WebClient {

        private readonly Uri endpoint;
        private readonly TimeSpan timeout;

        /// <summary>
        /// Istanzia un client per il servizio di generazione report.
        /// </summary>
        /// <param name="endpointUrl">Endpoint del servizio di generazione report</param>
        /// <param name="timeoutSeconds">Timeout della richiesta in secondi, il client non accetterà risposte oltre questo intervallo di tempo.</param>
        public WebClient(string endpointUrl, int timeoutSeconds) {
            try {
                endpoint = new Uri(endpointUrl);
                timeout = TimeSpan.FromSeconds(timeoutSeconds);
            }
            catch (Exception e) {
                throw new FormatException("argomenti non validi", e);
            }
        }

        /// <summary>
        /// Richiede al servizio di generazione report la creazione di un report generato in pdf.
        /// </summary>
        /// <param name="moduleReport">DataRow che descrive il report richiesto.</param>
        /// <param name="parameters">DataRow che descrive i parametri del report richiesto.</param>
        /// <returns>Contenuto del report generato.</returns>
        public byte[] Generate(DataRow moduleReport, DataRow parameters) {

            // creazione del body richiesta
            ReportRequest rr = new ReportRequest() {
                Report = moduleReport.ToHashtable(), // conversione della DataRow in Hashtable
                ReportParameter = parameters.ToHashtable(), // conversione della DataRow in Hashtable
            };

            RestRequest request;

            try {
                string jsonData = Newtonsoft.Json.JsonConvert.SerializeObject(rr); // serializzazione del body richiesta

                request = new RestRequest("generate") { // richiesta della route /generate sull'endpoint
                    Timeout = timeout.Milliseconds,
                };
                request.AddJsonBody(jsonData); // aggiunta del contenuto del body della richiesta
            }
            catch (Exception e) {
                throw new Exception("errore durante la creazione della richiesta", e);
            }

            RestClient client = new RestClient(endpoint);   // istanziazione del client di RestSharp
            IRestResponse response = client.Post(request);  // ricezione della risposta alla richiesta

            if (!response.IsSuccessful()) {
                throw new Exception(string.Join(": ", "esito negativo sulla chiamata al server", response.StatusDescription, response.Content), response.ErrorException);
            }

            return response.RawBytes; // lettura del contenuto del body della risposta e passaggio al chiamante
        }
    }
}
