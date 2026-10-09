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
using System.Windows.Forms;
using System.Linq;

using Microsoft.Web.WebView2.Core;

using metadatalibrary;

using Chat.Extensions;
using Chat.EasyGenius;
using Chat.EasyGenius.Serialization;


namespace Chat.Client {

    /// <summary>
    /// Modalità di embedding. Mantenuta per compatibilità con la configurazione "CHAT" (non usata da EasyGenius).
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

        // Assistente virtuale AI (EasyGenius) con login SSO tramite token monouso.
        // Configurazione app_config "CHAT": serverUrl|<non usato>|serviceApiKey|<embeddingMode>|<resourceName>
        // (i campi non usati restano per compatibilità con il formato letto dal mainform)

        /// <summary>
        /// Client dell'API Rest di EasyGenius.
        /// </summary>
        private readonly Api client;

        /// <summary>
        /// Identificativo dell'utente su EasyGenius.
        /// </summary>
        private readonly string username;

        /// <summary>
        /// Token SSO monouso per il login dell'utente.
        /// </summary>
        private SsoTokenResult sso;

        /// <summary>
        /// Indirizzo target del frame, con il token SSO per il login trasparente.
        /// </summary>
        public Uri Target => new Uri(client.Endpoint, $"/?ssoToken={Uri.EscapeDataString(sso.ssoToken)}");

        /// <summary>
        /// Estrae il nome dell'utente nel formato "<Nome> <Cognome>" da uno username con formato "<cfente>.<nome>.<cognome>" impostando le maiuscole per Nome e Cognome.
        /// </summary>
        public static Func<string, string> EasyNameInferrer = username => string.Join(" ", username.Split('.').Skip(1).Where(word => word.Length > 0).Select(word => word.FirstCharToUpper()));

        /// <summary>
        /// Inizializza il form dell'assistente virtuale. Richiede il token SSO per l'utente, inizializza il frame dell'applicazione e naviga sul target.
        /// </summary>
        /// <param name="usr">Username dell'utente.</param>
        /// <param name="endpoint">Indirizzo di EasyGenius.</param>
        /// <param name="adminId">Non usato, mantenuto per compatibilità.</param>
        /// <param name="adminToken">API Key di servizio di EasyGenius.</param>
        /// <param name="options">Opzioni.</param>
        public WebChat(string usr, Uri endpoint, string adminId, string adminToken, params Action<WebChat>[] options) {

            InitializeComponent();

            Size = new Size(1280, 900);

            username = usr.ToLowerInvariant();

            client = new Api(endpoint, adminToken);

            foreach (var option in options) {

                try {
                    option.Invoke(this);    // chiamata alla Invoke della Action che opera sul nostro oggetto (equivale a option(this), usiamo la Invoke per maggiore chiarezza)
                }
                catch (Exception e) {
                    throw new ArgumentException($"Could not initialize \"{GetType().Name}\" with \"{option.Method.Name}\": {e.Message}", e);
                }
            }

            // il token scade dopo 60 secondi: lo richiediamo qui per far emergere subito gli errori di comunicazione, la navigazione avviene poco dopo
            sso = client.SsoToken(username, EasyNameInferrer(username));

            easygenius.Location = new Point(0, 0);
            easygenius.Size = ClientSize;
            easygenius.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            InitializeAsync();
        }

        /// <summary>
        /// Esegue una inizializzazione asincrona dell'environment del frame, degli eventi e navigazione verso il target.
        /// </summary>
        async void InitializeAsync() {

            CoreWebView2Environment env = await CoreWebView2Environment.CreateAsync(null, AppDomain.CurrentDomain.BaseDirectory);

            await easygenius.EnsureCoreWebView2Async(env);

            easygenius.NavigationCompleted += Easygenius_NavigationCompleted;

            easygenius.CoreWebView2.Navigate(Target.ToString());

            sso = null; // il token è monouso
        }

        /// <summary>
        /// Esegue azioni al completamento del caricamento della pagina sul frame.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Easygenius_NavigationCompleted(object sender, CoreWebView2NavigationCompletedEventArgs e) {
            MetaFactory.factory.getSingleton<IFormCreationListener>().refresh();
        }

        /// <summary>
        /// Imposta la modalità di embedding. Mantenuta per compatibilità con la configurazione "CHAT": EasyGenius non la usa.
        /// </summary>
        /// <param name="m">Modalità di embedding.</param>
        /// <param name="resourceName">Nome della risorsa (non usato).</param>
        /// <returns>Action che non modifica il form.</returns>
        public static Action<WebChat> OptionEmbeddingMode(TEmbeddingMode m, string resourceName) {
            return (WebChat c) => { };
        }
    }
}