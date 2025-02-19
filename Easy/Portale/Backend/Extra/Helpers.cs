
/*
Easy
Copyright (C) 2024 UniversitÓ degli Studi di Catania (www.unict.it)
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


using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;

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

}
