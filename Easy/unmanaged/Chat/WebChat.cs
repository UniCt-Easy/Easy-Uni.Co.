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
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;

using Microsoft.Web.WebView2.Core;

using metadatalibrary;

using Chat.Extensions;
using Chat.Client.Rocketchat;
using Chat.Rocketchat.Exceptions;


namespace Chat.Client {

    /// <summary>
    /// Modalità di embedding.
    /// </summary>
    public enum TEmbeddingMode {
        /// <summary>
        /// Canale.
        /// </summary>
        Channel,
        /// <summary>
        /// Conversazione privata.
        /// </summary>
        Direct
    }

    public partial class WebChat : MetaDataForm {

        //https://developer.rocket.chat/chat-engine/chat-engine-in-iframe
        //https://developer.rocket.chat/customize-and-embed/iframe-integration/configuring-iframe-auth

        /// <summary>
        /// Client dell'API Rest del server di chat.
        /// </summary>
        private readonly Api client;  // potrebbe diventare un'interfaccia o una classe astratta

        /// <summary>
        /// Utenti del server di chat (cache).
        /// </summary>
        public List<string> Users { get; } // "cache" solo sul form
        /// <summary>
        /// Canali del server di chat (cache).
        /// </summary>
        public List<string> Channels { get; } // "cache" solo sul form

        /// <summary>
        /// Nome dell'utente della chat.
        /// </summary>
        private readonly string username;

        /// <summary>
        /// Token per il login dell'utente.
        /// </summary>
        private PersonalAccessToken user;

        /// <summary>
        /// Modalità di embedding.
        /// </summary>
        private TEmbeddingMode Mode = TEmbeddingMode.Channel;

        /// <summary>
        /// Nome della risorsa da mostrare sulla versione embedded.
        /// </summary>
        private string resource = "general";

        /// <summary>
        /// Getter del token per il login dell'utente.
        /// </summary>
        public PersonalAccessToken User => user;

        /// <summary>
        /// Indica se l'utente è loggato sulla chat.
        /// </summary>
        public bool UserIsLoggedIn => user != null;

        /// <summary>
        /// Indirizzo target del frame embedded.
        /// </summary>
        public Uri EmbeddedTarget => new Uri(client.Endpoint, $"/{Mode}/{resource}?layout=embedded");

        /// <summary>
        /// Estrae il nome dell'utente nel formato "<Nome> <Cognome>" da uno username con formato "<cfente>.<nome>.<cognome>" impostando le maiuscole per Nome e Cognome.
        /// </summary>
        public static Func<string, string> EasyNameInferrer = username => string.Join(" ", username.Split('.').Skip(1).Select(word => word.FirstCharToUpper()));

        /// <summary>
        /// Inizializza il form per la chat web. Crea l'utente sul server di chat, inizializza il frame dell'applicazione, logga l'utente sull'applicazione.
        /// </summary>
        /// <param name="usr">Username dell'utente.</param>
        /// <param name="endpoint">Indirizzo del server di chat.</param>
        /// <param name="options">Opzioni.</param>
        public WebChat(string usr, Uri endpoint, string adminId, string adminToken, params Action<WebChat>[] options) {

            InitializeComponent();

            Size = new Size(1280, 900);

            username = usr.ToLowerInvariant();

            client = new Api(endpoint, adminId, adminToken);

            Users = client.UsersList().Select(user => user.username.ToLowerInvariant()).ToList();
            Channels = client.ChannelsList().Select(channel => channel.name.ToLowerInvariant()).ToList();

            if (!Users.Contains(username)) {

                try {
                    var userDetails = client.UserDetails(username);
                }
                catch (ApiException) {
                    client.UsersCreate(username, EasyNameInferrer);
                }
                catch (Exception e) {
                    throw new Exception($"Could not initialize \"{GetType().Name}\": {e.Message}", e);
                }
            }

            FormClosing += WebChat_FormClosing;

            rocketchat.Location = new Point(0, 0);
            rocketchat.Size = ClientSize;
            rocketchat.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            foreach (var option in options) {

                try {
                    option.Invoke(this);    // chiamata alla Invoke della Action che opera sul nostro oggetto (equivale a option(this), usiamo la Invoke per maggiore chiarezza)
                }
                catch (Exception e) {
                    throw new ArgumentException($"Could not initialize \"{GetType().Name}\" with \"{option.Method.Name}\": {e.Message}", e);
                }
            }

            InitializeAsync();
        }

        /// <summary>
        /// Esegue una inizializzazione asincrona dell'environment del frame, degli eventi e navigazione verso il target.
        /// </summary>
        async void InitializeAsync() {

            CoreWebView2Environment env = await CoreWebView2Environment.CreateAsync(null, AppDomain.CurrentDomain.BaseDirectory);

            await rocketchat.EnsureCoreWebView2Async(env);

            rocketchat.CoreWebView2.DOMContentLoaded += CoreWebView2_DOMContentLoaded;
            rocketchat.NavigationCompleted += Rocketchat_NavigationCompleted;

            rocketchat.CoreWebView2.Navigate(EmbeddedTarget.ToString());
        }

        /// <summary>
        /// Esegue azioni al completamento del caricamento della pagina sul frame.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Rocketchat_NavigationCompleted(object sender, CoreWebView2NavigationCompletedEventArgs e) {
            MetaFactory.factory.getSingleton<IFormCreationListener>().refresh();
        }

        /// <summary>
        /// Esegue azioni al caricamento del DOM del frame.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CoreWebView2_DOMContentLoaded(object sender, CoreWebView2DOMContentLoadedEventArgs e) {
            
            if (!UserIsLoggedIn) {

                if (!Users.Contains(username)) {
                    Thread.Sleep(TimeSpan.FromSeconds(1)); // aspettiamo che il server abbia completato tutte le operazioni di creazione dell'utente, valore speculativo
                }

                try {
                    user = client.UsersCreateToken(username);
                    Thread.Sleep(TimeSpan.FromSeconds(1)); //aspettiamo che il server abbia completato le operazioni di creazione del token, valore speculativo
                }
                catch (Exception ex) {
                    throw new ApiException($"Could not create token for \"{username}\": {ex.Message}", ex);
                }

                string loginScript =
                    $@"window.postMessage({{
                        externalCommand: 'login-with-token',
                        token: '{User["X-Auth-Token"]}'
                    }});";

                rocketchat.CoreWebView2.ExecuteScriptAsync(loginScript);
            }
        }

        /// <summary>
        /// Azioni da eseguire alla chiusura del form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WebChat_FormClosing(object sender, FormClosingEventArgs e) {

            if (UserIsLoggedIn) {
                string logoutScript =
                    $@"window.postMessage({{
                        externalCommand: 'logout'
                    }});";

                rocketchat.CoreWebView2.ExecuteScriptAsync(logoutScript);
            }

            user = null;
        }

        /// <summary>
        /// Imposta la modalità di embedding.
        /// </summary>
        /// <param name="m">Modalità di embedding.</param>
        /// <param name="resourceName">Nome della risorsa da mostrare sulla versione embedded, il significato dipende dalla modalità di embedding.</param>
        /// <returns>Action che imposta la modalità di embedding.</returns>
        public static Action<WebChat> OptionEmbeddingMode(TEmbeddingMode m, string resourceName) {

            if (string.IsNullOrWhiteSpace(resourceName)) {
                throw new ArgumentException($"Invalid resource name for \"{m}\"");
            }

            return (WebChat c) => {

                string name = resourceName.ToLowerInvariant();

                switch (m) {
                    case TEmbeddingMode.Channel:
                        if (!c.Channels.Contains(name)) {
                            throw new Exception($"Channel \"{name}\" does not exist on the server");
                        }
                        break;
                    case TEmbeddingMode.Direct:
                        // potremmo anche verificare che lo user sia online. In questo modo comunque permettiamo all'utente di vedere la history.
                        //var botUserExists = c.Users.Contains(resourceName);
                        try {
                            var botUser = c.client.UserDetails(resourceName);
                        }
                        catch (Exception e) {
                            throw new Exception($"Bot user \"{name}\" does not exist on the server: {e.Message}");
                        }
                        break;
                    default:
                        throw new ArgumentException($"Invalid mode \"{m}\"");
                }

                c.Mode = m;
                c.resource = name;
            };
        }
    }
}