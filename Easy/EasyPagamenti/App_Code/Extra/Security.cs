
/*
Easy
Copyright (C) 2023 Universita' degli Studi di Catania (www.unict.it)
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


using Jose;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Linq;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Threading.Tasks;
using System.Web.Configuration;
using EasyPagamenti.Extensions;
using System.Runtime.Caching;

using funzioni_configurazione;
using metadatalibrary;
using System.Web.UI;
using System.Text;

namespace EasyPagamenti.Extra {

    /// <summary>
    /// Ruolo degli utenti.
    /// </summary>
    public static class Role {

        /// <summary>
        /// Amministratore.
        /// </summary>
        public static readonly string Administrator = "admin";

        /// <summary>
        /// Utente semplice.
        /// </summary>
        public static readonly string User = "user";

    }

    /// <summary>
    /// Implementazione dell'interfaccia IPrincipal per gli utenti di Easy.
    /// </summary>
    public sealed class Principal :IPrincipal {

        /// <summary>
        /// Identità dell'utente.
        /// </summary>
        public IIdentity Identity { get; private set; }

        /// <summary>
        /// Costruttore primario.
        /// </summary>
        /// <param name="identity">Identità dell'utente.</param>
        public Principal(Identity identity) {
            Identity = identity;
        }

        /// <summary>
        /// Controlla se l'utente può svolgere un determinato ruolo.
        /// </summary>
        /// <param name="role">Il ruolo.</param>
        /// <returns>Vero se l'utente può svolgere un determinato ruolo.</returns>
        public bool IsInRole(string role) {
            var identity = (Identity)Identity;
            return identity.Roles.Contains(role);
        }

    }

    /// <summary>
    /// Implementazione dell'interfaccia IIdentity per gli utenti Easy.
    /// </summary>
    public sealed class Identity :IIdentity {

        private const string ISSUER = "MetaWebLibrary";
        private const string AUTH_TYPE = "bearer";

        /// <summary>
        /// Costruttore primario.
        /// </summary>
        /// <param name="clientAddress">Indirizzo IP del computer dell'utente.</param>
        /// <param name="name">Nome dell'utente.</param>
        /// <param name="email">Email dell'utente.</param>
        /// <param name="title">Denominazione dell'utente.</param>
        public Identity(string clientAddress, string name, string email, string title) {
            LoggedOn = DateTime.Now;
            ExpiresOn = LoggedOn.AddMinutes(30); // 30 minuti di validità

            Issuer = ISSUER;
            ClientAddress = clientAddress;
            Name = name;
            Email = email;
            Title = title;

            AuthenticationType = AUTH_TYPE;
            IsAuthenticated = true;
            Roles = new HashSet<string> { Role.User };
        }

        /// <summary>
        /// Costruttore per il deserializzatore JSON.
        /// </summary>
        /// <param name="loggedOn">Data e ora di accesso.</param>
        /// <param name="expiresOn">Data e ora di scadenza del'autorizzazione all'accesso.</param>
        /// <param name="clientAddress">Indirizzo IP del computer dell'utente.</param>
        /// <param name="name">Nome dell'utente.</param>
        /// <param name="email">Email dell'utente.</param>
        /// <param name="title">Denominazione dell'utente.</param>
        /// <param name="roles">Ruoli dell'utente.</param>
        [JsonConstructor]
        public Identity(DateTime loggedOn, DateTime expiresOn, string clientAddress, string name, string email, string title, IEnumerable<string> roles) {
            LoggedOn = loggedOn;
            ExpiresOn = expiresOn;

            Issuer = ISSUER;
            ClientAddress = clientAddress;
            Name = name;
            Email = email;
            Title = title;

            AuthenticationType = AUTH_TYPE;
            IsAuthenticated = true;
            Roles = new HashSet<string>(roles);
        }

        /// <summary>
        /// Ente che ha generato il token.
        /// </summary>
        [JsonProperty("iss")]
        public string Issuer { get; private set; }

        /// <summary>
        /// Data e ora di accesso.
        /// </summary>
        [JsonProperty("iat")]
        public DateTime LoggedOn { get; private set; }

        /// <summary>
        /// Data e ora di scadenza dell'autorizzazione all'accesso.
        /// </summary>
        [JsonProperty("exp")]
        public DateTime ExpiresOn { get; private set; }

        /// <summary>
        /// Nome dell'utente.
        /// </summary>
        [JsonProperty("sub")]
        public string Name { get; private set; }

        /// <summary>
        /// Indirizzo IP del computer dell'utente. 
        /// </summary>
        [JsonProperty("aud")]
        public string ClientAddress { get; private set; }

        /// <summary>
        /// E-mail dell'utente.
        /// </summary>
        [EmailAddress, JsonProperty("email")]
        public string Email { get; private set; }

        /// <summary>
        /// Denominazione dell'utente.
        /// </summary>
        [JsonProperty("title")]
        public string Title { get; private set; }

        /// <summary>
        /// Tipo di autenticazione.
        /// </summary>
        [JsonIgnore]
        public string AuthenticationType { get; private set; }

        /// <summary>
        /// Utente autenticato?
        /// </summary>
        [JsonProperty("isAuthenticated")]
        public bool IsAuthenticated { get; private set; }

        /// <summary>
        /// Ruoli dell'utente.
        /// </summary>
        [JsonProperty("roles")]
        public IEnumerable<string> Roles { get; private set; }

    }

    /// <summary>
    /// Utilità per la creazione di chiavi di sicurezza.
    /// </summary>
    public static class KeyChain {

        private static readonly int LENGTH_SALT = 10;       // Numero di byte da generare per il "sale"
        private static readonly int LENGTH_PASSWORD = 5;    // Numero di byte da generare per le password
        private static readonly int LENGTH_CODE = 3;        // Numero di byte da generare per i codici di attivazione

        /// <summary>
        /// Genera una chiave crittografica della dimensione specificata.
        /// </summary>
        /// <param name="length">Lunghezza della chiave.</param>
        /// <returns>Chiave crittografica.</returns>
        private static byte[] GenerateKey(int length) {
            var key = new byte[length];

            using (RNGCryptoServiceProvider csprng = new RNGCryptoServiceProvider()) {
                csprng.GetBytes(key);
            }

            return key;
        }

        /// <summary>
        /// Genera il sale per una password.
        /// </summary>
        /// <returns>Il sale.</returns>
        public static byte[] GenerateSalt() {
            return GenerateKey(LENGTH_SALT);
        }

        /// <summary>
        /// Genera una password casuale.
        /// </summary>
        /// <returns>Una password.</returns>
        public static string GeneratePassword() {
            return GenerateKey(LENGTH_PASSWORD).ToHexString();
        }

        /// <summary>
        /// Genera un codice di attivazione.
        /// </summary>
        /// <returns>Un codice di attivazione.</returns>
        public static string GenerateCode() {
            return GenerateKey(LENGTH_CODE).ToHexString();
        }

    }

    /// <summary>
    /// Utilità per la gestione delle password.
    /// </summary>
    public static class Password {

        private static readonly int LENGTH_HASH = 20; // Numero di byte da generare per gli hash

        private static readonly string EMAIL_SUBJECT = "Password di accesso";
        private static readonly string EMAIL_BODY = "Il tuo nome è utente è '{1}'. " + "\r\n"
            + "La tua nuova password per l'accesso ai servizi Easy Pagamenti è '{0}'. " + "\r\n"
            + "La password è sensibile al maiuscolo/minuscolo.";

		/// <summary>
		/// Genera l'hash di una password.
		/// </summary>
		/// <param name="password">La password.</param>
		/// <param name="salt">Il sale.</param>
		/// <param name="iterations">Il numero di iterazioni da effettuare.</param>
		/// <returns>L'hash della password.</returns>
		public static byte[] GenerateHash(string password, byte[] salt, int iterations, string secureHashAlgorithm = "SHA256")
		{
			if (string.IsNullOrEmpty(password) || salt == null || iterations < 1) return null;
			if (salt.Length < 8) return null;
			var hash = new byte[LENGTH_HASH];

			if (string.IsNullOrWhiteSpace(secureHashAlgorithm))
				secureHashAlgorithm = "SHA256";

			switch (secureHashAlgorithm)
			{
				case "SHA1":
					using (Rfc2898DeriveBytes pbkdf2 = new Rfc2898DeriveBytes(password, salt, iterations))
					{
						hash = pbkdf2.GetBytes(LENGTH_HASH);
					}
					break;

				case "SHA256":
					hash = new byte[32];
					using (SHA256 mySHA256 = SHA256.Create())
					{
						var psw = Encoding.UTF8.GetBytes(password);
						var pswAndSalt = new byte[psw.Length + salt.Length];
						System.Buffer.BlockCopy(psw, 0, pswAndSalt, 0, psw.Length);
						System.Buffer.BlockCopy(salt, 0, pswAndSalt, psw.Length, salt.Length);
						for (int i = 0; i < iterations; i++)
							hash = mySHA256.ComputeHash(pswAndSalt);
					}
					break;

			}

			return hash;
		}

		/// <summary>
		/// Verifica la correttezza di una password confrontandola con l'hash registrato.
		/// </summary>
		/// <param name="password">La password.</param>
		/// <param name="salt">Il sale.</param>
		/// <param name="secureHash">L'hash registrato.</param>
		/// <param name="iterations">Il numero di iterazioni da effettuare.</param>
		/// <returns>Vero se le password coincidono.</returns>
		public static bool Verify(string password, byte[] salt, byte[] secureHash, int iterations)
		{
			if (string.IsNullOrEmpty(password) || secureHash == null || salt == null || iterations < 1) return false;
			if (salt.Length < 8) return false;
			var insecureHash = GenerateHash(password, salt, iterations);

			if (Enumerable.SequenceEqual(secureHash, insecureHash))
				return true;

			insecureHash = GenerateHash(password, salt, iterations, "SHA1");
			if (Enumerable.SequenceEqual(secureHash, insecureHash))
				return true;

			return false;

		}

		/// <summary>
		/// Invia un'e-mail contenente la password in chiaro dell'utente.
		/// </summary>
		/// <remarks>
		/// Da utilizzare solo per la procedura di reset della password.
		/// </remarks>
		/// <param name="recipient">L'e-mail dell'utente.</param>
		/// <param name="password">La password.</param>
		/// <returns>Il task di invio asincrono.</returns>
		public static Task SendEmail(string recipient, string password, string userweb, DataAccess DepConn) {
            var address = new MailAddress(recipient);

            //using (var client = new SmtpClient())
            //using (var message = new MailMessage()) {
            //    message.To.Add(address);
            //    message.Subject = EMAIL_SUBJECT;
            //    message.Body = string.Format(EMAIL_BODY, password);

            //    client.Send(message);
            //}
            funzioni_configurazione.SendMail SM = new funzioni_configurazione.SendMail();
            //SM.LogMessage = false;
            //SM.LogHiddenMessageBody = "Testo della mail non riportato su log";
            SM.To = recipient;
            SM.UseSMTPLoginAsFromField = true;
            SM.Subject = EMAIL_SUBJECT;
            SM.MessageBody = string.Format(EMAIL_BODY, password, userweb);
            SM.Conn = DepConn;
            if (!SM.Send()) {
                if (SM.ErrorMessage.Trim() != "")
                    throw new Exception(SM.ErrorMessage);
            }

            return null;
        }

    }



    

    /// <summary>
    /// Utilità per la gestione dell'attivazione degli account.
    /// </summary>
    public static class Activation {

        private static readonly short CODE_TTL = 15; // Numero di minuti di validità del codice generato

        private static readonly string EMAIL_SUBJECT = "Attivazione account";
        private static readonly string EMAIL_BODY = "Il codice di attivazione del tuo account per i servizi EasyPagamenti è '{0}'.";

        private static MemoryCache codeCache;

        static Activation() {
            codeCache = new MemoryCache("ActivationCodes");
        }

        public static string addLoginParam(string logParam, int minutes) {
            var code = KeyChain.GenerateCode();
            codeCache.Set("logParam:"+logParam,code, DateTimeOffset.Now.AddMinutes(minutes));
            return code;
        }

        public static bool checkLoginParam(string logParam, string code) {
            return codeCache.Contains("logParam:" + logParam) && 
                codeCache.Get("logParam:" + logParam).Equals(code);
        }

        /// <summary>
        /// Invia un'e-mail di attivazione.
        /// </summary>
        /// <param name="recipient">L'e-mail dell'utente.</param>
        /// <returns>Il task di invio asincrono.</returns>
        public static Task SendEmail(string recipient, DataAccess DepConn) {
            var code = KeyChain.GenerateCode();

            codeCache.Set(recipient, code, DateTimeOffset.Now.AddMinutes(CODE_TTL));

            //var address = new MailAddress(recipient);

            //using (var client = new SmtpClient())
            //using (var message = new MailMessage()) {
            //    message.To.Add(address);
            //    message.Subject = EMAIL_SUBJECT;
            //    message.Body = string.Format(EMAIL_BODY, code);
            //    client.Send(message);
            //}
            funzioni_configurazione.SendMail SM = new funzioni_configurazione.SendMail();
            SM.To = recipient;
            SM.UseSMTPLoginAsFromField = true;
            SM.Subject = EMAIL_SUBJECT;
            SM.MessageBody = string.Format(EMAIL_BODY, code);
            SM.Conn = DepConn;
            if (!SM.Send()) {
                if (SM.ErrorMessage.Trim() != "")
                    throw new Exception(SM.ErrorMessage);
            }
            return null;
        }

        /// <summary>
        /// Verifica che il codice di attivazione sia valido.
        /// </summary>
        /// <param name="recipient">L'e-mail dell'utente.</param>
        /// <param name="code">Il codice di attivazione.</param>
        /// <returns>Vero se il codice di attivazione è valido.</returns>
        public static bool Verify(string recipient, string code) {
            return codeCache.Contains(recipient) && codeCache.Get(recipient).Equals(code);
        }

    }

    /// <summary>
    /// Utilità per la gestione dei token di autenticazione.
    /// </summary>
    public static class Token {

        private static readonly JwsAlgorithm SIGNATURE_ALGORITHM = JwsAlgorithm.HS512;
        private static readonly int KEY_BYTES = 64; // 64 = HS512, 48 = HS384, 32 = HS256

        private static readonly byte[] masterKey;

        static Token() {
            var config = WebConfigurationManager.OpenWebConfiguration("~");

            var key = config.AppSettings.Settings["MasterKey"].Value;

            if (string.IsNullOrEmpty(key)) {
                masterKey = GenerateMasterKey();

                config.AppSettings.Settings["MasterKey"].Value = Convert.ToBase64String(masterKey);
                config.Save(ConfigurationSaveMode.Modified);
            }
            else {
                masterKey = Convert.FromBase64String(key);
            }
        }

        /// <summary>
        /// Genera la chiave master per la firma dei token.
        /// </summary>
        /// <remarks>
        /// Questa funzione dovrebbe essere chiamata solo durante il primo avvio dell'applicazione.
        /// Cambiando la chiave master tutti i token precedentemente generati vengono di fatto invalidati.
        /// </remarks>
        /// <returns>La chiave per la firma.</returns>
        private static byte[] GenerateMasterKey() {
            var key = new byte[KEY_BYTES];

            using (RNGCryptoServiceProvider csprng = new RNGCryptoServiceProvider()) {
                csprng.GetBytes(key);
            }

            return key;
        }

        /// <summary>
        /// Codifica i dati dell'utente in un token.
        /// </summary>
        /// <param name="data">I dati dell'utente.</param>
        /// <returns>Un token firmato.</returns>
        public static string Encode(Identity data) {
            var json = JsonConvert.SerializeObject(data);
            if (json == null) return null;

            return JWT.Encode(json, masterKey, SIGNATURE_ALGORITHM);
        }

        /// <summary>
        /// Decodifica i dati dell'utente
        /// </summary>
        /// <param name="token">Il token firmato.</param>
        /// <returns>I dati dell'utente.</returns>
        public static Identity Decode(string token) {
            var json = JWT.Decode(token, masterKey);
            if (json == null) return null;

            return JsonConvert.DeserializeObject<Identity>(json);
        }

    }


}
