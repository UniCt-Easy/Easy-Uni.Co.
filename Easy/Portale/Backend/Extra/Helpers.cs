/*
Easy
Copyright (C) 2026 Università degli Studi di Catania (www.unict.it)
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
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;

using Backend.CommonBackend;
using Backend.Extra;

namespace Backend {

    /// <summary>
    /// Risultato di una richiesta di accesso al servizio.
    /// </summary>
    public class AuthenticationResult : IHttpActionResult {

        /// <summary>
        /// Codice di stato della risposta.
        /// </summary>
        public HttpStatusCode statusCode { get; set; }

        /// <summary>
        /// Messaggio della risposta.
        /// </summary>
        public string reason { get; private set; }

        /// <summary>
        /// Richiesta legata alla risposta.
        /// </summary>
        public HttpRequestMessage request { get; private set; }

        /// <summary>
        /// Costruttore primario.
        /// </summary>
        /// <param name="request">La richiesta HTTP.</param>
        /// <param name="statusCode">Il codice di stato della risposta.</param>
        /// <param name="reason">Il messaggio della risposta.</param>
        public AuthenticationResult(HttpRequestMessage request, HttpStatusCode statusCode, string reason) {
            this.request = request;
            this.statusCode = statusCode;
            this.reason = reason;
        }

        /// <summary>
        /// Esegue l'elaborazione della richiesta di autenticazione in modo asincrono.
        /// </summary>
        /// <param name="cancellationToken">Token per l'annullamento del thread.</param>
        /// <returns>Task di preparazione della risposta.</returns>
        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken) {
            return Task.FromResult(execute());
        }

        /// <summary>
        /// Esegue l'elaborazione della richiesta di autenticazione.
        /// </summary>
        /// <returns>Il messaggio di risposta HTTP.</returns>
        private HttpResponseMessage execute() {
            var response = new HttpResponseMessage(statusCode);
            response.RequestMessage = request;
            response.ReasonPhrase = "Unauthorized";
            response.Content = new StringContent(reason);
            return response;
        }

    }

    /// <summary>
    /// Risultato di una richiesta fallita di accesso al servizio.
    /// </summary>
    public class ChallengeResult : IHttpActionResult {

        /// <summary>
        /// Il parametro dell'header per il challenge.
        /// </summary>
        /// <remarks>WWW-Authenticate: Bearer</remarks>
        public AuthenticationHeaderValue challenge { get; private set; }

        /// <summary>
        /// Risultato dell'elaborazione della richiesta.
        /// </summary>
        public IHttpActionResult innerResult { get; private set; }

        /// <summary>
        /// Costruttore primario.
        /// </summary>
        /// <param name="innerResult">Il risultato dell'elaborazione della richiesta.</param>
        public ChallengeResult(IHttpActionResult innerResult) {
            challenge = new AuthenticationHeaderValue("Bearer");
            this.innerResult = innerResult;
        }

        /// <summary>
        /// Esegue l'elaborazione della richiesta di autenticazione in modo asincrono.
        /// </summary>
        /// <param name="cancellationToken">Token per l'annullamento del thread.</param>
        /// <returns>Task di preparazione della risposta.</returns>
        public async Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken) {
            HttpResponseMessage response = await innerResult.ExecuteAsync(cancellationToken);

            if (response.StatusCode == HttpStatusCode.Unauthorized) {
                if (!response.Headers.WwwAuthenticate.Any((h) => h.Scheme == challenge.Scheme)) {
                    response.Headers.WwwAuthenticate.Add(challenge);
                }
            }

            return response;
        }
    }

    /// <summary>
    /// Metodi di utilità per il parsing di stringhe di configurazione impostate sul DB di Easy.
    /// </summary>
    public static class EasyConfigReader {

        /// <summary>
        /// Nome della tabella di configurazione
        /// </summary>
        public static string ConfigTableName = "app_config";

        // magari in futuro usiamo il JSON per i valori di configurazione

        /// <summary>
        /// Estrae le coppie di chiavi e valori di configurazione da una stringa di in formato "key":"value","key2":"value2"
        /// sia con chiavi e valori quotati che non quotati.
        /// </summary>
        /// <param name="input">Stringa di configurazione.</param>
        /// <returns>Coppie di chiavi-valore.</returns>
        /// <exception cref="ArgumentException"></exception>
        public static Dictionary<string, string> Parse(string input) {

            if (string.IsNullOrWhiteSpace(input))
                throw new ArgumentException("Input cannot be null or empty.", nameof(input));

            var result = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

            // Regex: key:"value" or key:value, with support for quoted/unquoted keys and values
            var regex = new Regex(@"(?:""([^""]+)""|(\w+))\s*:\s*(?:""((?:\\.|[^""])*)""|(\w+))");

            foreach (Match match in regex.Matches(input)) {
                string key = match.Groups[1].Success ? match.Groups[1].Value : match.Groups[2].Value;
                string value = match.Groups[3].Success ? match.Groups[3].Value : match.Groups[4].Value;

                // Unescape \" → "
                value = value.Replace("\\\"", "\"");

                result[key] = value;
            }

            return result;
        }

        /// <summary>
        /// Recupera la configurazione dal database di Easy.
        /// </summary>
        /// <param name="d">Dispatcher.</param>
        /// <param name="code">Identificativo della riga di configurazione.</param>
        /// <returns>Coppie di chiavi-valore di configurazione.</returns>
        /// <exception cref="Exception"></exception>
        public static Dictionary<string, string> Read(Dispatcher d, string code) {

            string configString;

            try {

                configString = d.Connection.DO_READ_VALUE(ConfigTableName, $"code = '{code}'", "param").ToString();
            }
            catch (Exception e) {

                BackendLoggerService.Logger.logException(new Exception($"Could not read configuration from table '{ConfigTableName}' and code '{code}'", e));
                return new Dictionary<string, string>();
            }

            return Parse(configString);
        }
    }
}