
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
using System.Linq;
using System.Web.Security;
using System.Collections.Generic;

using RestSharp;
using Newtonsoft.Json;

using Chat.Rocketchat.Exceptions;
// ci sarebbe da unire i namespace e i modelli
using Chat.Client.Rocketchat.Serialization.UsersCreate;
using Chat.Client.Rocketchat.Serialization.UsersCreatetoken;
using Chat.Client.Rocketchat.Serialization.UsersList;
using Chat.Client.Rocketchat.Serialization.ChannelsList;

namespace Chat.Client.Rocketchat {
    public class Api {  // la classe potrebbe essere probabilmente generalizzata per alcuni metodi

        /// <summary>
        /// Client REST per l'API di Rocketchat.
        /// </summary>
        private readonly RestClient api;
        /// <summary>
        /// Endpoint dell'API.
        /// </summary>
        public Uri Endpoint => api.BaseUrl;
        /// <summary>
        /// Token di accesso dell'utente primario.
        /// </summary>
        private readonly PersonalAccessToken primaryUser;

        /// <summary>
        /// Gestore dei metodi per la creazione e l'autenticazione degli utenti sull'API di Rocketchat.
        /// </summary>
        /// <param name="endpoint">Indirizzo dell'API.</param>
        /// <param name="adminId">ID dell'utente primario.</param>
        /// <param name="adminToken">Token dell'utente primario.</param>
        public Api(Uri endpoint, string adminId, string adminToken) {

            api = new RestClient(endpoint);
            primaryUser = new PersonalAccessToken(adminId, adminToken);

            foreach (var header in primaryUser) {
                api.AddDefaultHeader(header.Key, header.Value);
            }
        }

        /// <summary>
        /// Crea un utente.
        /// </summary>
        /// <param name="username">Nome dell'utente.</param>
        /// <param name="NameInferrer">Funzione che estrae il nome da visualizzare dallo username dell'utente.</param>
        /// <returns>Utente.</returns>
        public Serialization.UsersCreate.User UsersCreate(string username, Func<string, string> NameInferrer = null) {

            var request = new RestRequest("/api/v1/users.create", Method.POST) { RequestFormat = DataFormat.Json };

            request.AddJsonBody(new {
                name = NameInferrer?.Invoke(username) ?? username,
                email = $"{username}@placeholder.com",
                password = Membership.GeneratePassword(16, 1),
                username = username,
                roles = new string[] { "user" } // potremmo reperire la lista dei ruoli dall'API e farla diventare un parametro https://developer.rocket.chat/reference/api/rest-api/endpoints/user-management/roles-endpoints/list-roles
            });

            var response = api.Execute(request);

            switch (response.StatusCode) {
                case System.Net.HttpStatusCode.OK:
                    break;
                default:
                    throw new ApiException($"Creation request for user \"{username}\" failed: {response.Content}");
            }

            var result = new UsersCreateResult();

            try {
                result = JsonConvert.DeserializeObject<UsersCreateResult>(response.Content);
            }
            catch (Exception e) {
                new FormatException($"Unexpected response while requesting creation for user \"{username}\": {e.Message}", e);
            }

            return result.user;
        }

        /// <summary>
        /// Crea un token per un utente.
        /// </summary>
        /// <param name="username">Nome dell'utente.</param>
        /// <returns>Token per l'utente.</returns>
        public PersonalAccessToken UsersCreateToken(string username) {

            var request = new RestRequest("/api/v1/users.createToken", Method.POST) { RequestFormat = DataFormat.Json };

            request.AddJsonBody(new { username = username });

            var response = api.Execute(request);

            switch (response.StatusCode) {
                case System.Net.HttpStatusCode.OK:
                    break;
                default:
                    throw new Exception($"Token creation request for user \"{username}\" failed: {response.Content}");
            }

            UsersCreatetokenResult result;

            try {
                result = JsonConvert.DeserializeObject<UsersCreatetokenResult>(response.Content);
            }
            catch (Exception e) {
                throw new FormatException($"Unexpected response while requesting token creation for user \"{username}\": {e.Message}", e);
            }

            return new PersonalAccessToken(result.data.userId, result.data.authToken);
        }

        /// <summary>
        /// Recupera la lista degli User dal server.
        /// </summary>
        /// <returns>Lista di User.</returns>
        public IEnumerable<Serialization.UsersList.User> UsersList() {

            var request = new RestRequest("/api/v1/users.list", Method.GET) { RequestFormat = DataFormat.Json };
            request.AddQueryParameter("count", "10000");

            var response = api.Execute(request);

            switch (response.StatusCode) {
                case System.Net.HttpStatusCode.OK:
                    break;
                default:
                    throw new Exception($"Users listing failed: {response.Content}");
            }

            UsersListResult result;

            try {
                result = JsonConvert.DeserializeObject<UsersListResult>(response.Content);
            }
            catch (Exception e) {
                throw new FormatException($"Unexpected response while requesting users list: {e.Message}", e);
            }

            return result.users;
        }

        /// <summary>
        /// Recupera uno User dal server.
        /// </summary>
        /// <param name="username">Username dell'utente</param>
        /// <returns>Dettagli dell'utente.</returns>
        public Serialization.UsersList.User UserDetails(string username) {

            var request = new RestRequest("/api/v1/users.info", Method.GET) { RequestFormat = DataFormat.Json };
            request.AddQueryParameter("username", username);

            var response = api.Execute(request);

            switch (response.StatusCode) {
                case System.Net.HttpStatusCode.OK:
                    break;
                default:
                    throw new Exception($"User not found: {response.Content}");
            }

            Serialization.UsersList.User result;

            try {
                result = JsonConvert.DeserializeObject<Serialization.UsersList.User>(response.Content);
            }
            catch (Exception e) {
                throw new FormatException($"Unexpected response while requesting users list: {e.Message}", e);
            }

            return result;
        }

        /// <summary>
        /// Recupera la lista dei Channel dal server.
        /// </summary>
        /// <returns>Lista di Channel.</returns>
        public IEnumerable<Channel> ChannelsList() {

            var request = new RestRequest("/api/v1/channels.list", Method.GET) { RequestFormat = DataFormat.Json };

            var response = api.Execute(request);

            switch (response.StatusCode) {
                case System.Net.HttpStatusCode.OK:
                    break;
                default:
                    throw new Exception($"Channels listing failed: {response.Content}");
            }

            ChannelsListResult result;

            try {
                result = JsonConvert.DeserializeObject<ChannelsListResult>(response.Content);
            }
            catch (Exception e) {
                throw new FormatException($"Unexpected response while requesting channels list: {e.Message}", e);
            }

            return result.channels;
        }
    }
}
