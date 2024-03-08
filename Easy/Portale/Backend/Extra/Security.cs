
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


using Jose;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Mail;
using System.Runtime.Caching;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Threading.Tasks;
using System.Web.Configuration;
using Backend.Components;
using System.Web;
using System.Text;
using Backend.CommonBackend;
using Backend.LDAP;
using static Backend.CommonBackend.DBLogger;

namespace Backend.Security {

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
    public sealed class Principal : IPrincipal {

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
            return identity.roles.Contains(role);
        }

    }

    /// <summary>
    /// Implementazione dell'interfaccia IIdentity per gli utenti Easy.
    /// </summary>
    public sealed class Identity : IIdentity {

        private const string ISSUER = "MetaWebLibrary";
        private const string AuthType = "bearer";

        /// <summary>
        /// Costruttore primario.
        /// </summary>
        /// <param name="guidsession">guidsession</param>
        /// <param name="clientAddress">Indirizzo IP del computer dell'utente.</param>
        /// <param name="name">Nome dell'utente.</param>
        /// <param name="email">Email dell'utente.</param>
        /// <param name="title">Denominazione dell'utente.</param>
        /// <param name="idFlowChart">idFlowChart dell'utente.</param>
        /// <param name="nDetail">nDetail dell'utente.</param>
        public Identity(Guid guidsession, 
            string clientAddress,
            string name, string email, 
            string title,
            string idFlowChart,
            string nDetail) {
            loggedOn = DateTime.Now;
            expiresOn = loggedOn.AddHours(24); // 1 giorno di validità

            issuer = ISSUER;
            this.clientAddress = clientAddress;
            Name = name;
            this.email = email;
            this.title = title;

            this.guidsession = guidsession;
            this.idFlowChart = idFlowChart;
            this.nDetail = nDetail;

            AuthenticationType = AuthType;
            IsAuthenticated = true;
            IsAnonymous = false;
            roles = new HashSet<string> { Role.User };
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
        public Identity(DateTime loggedOn, 
            DateTime expiresOn,
            string clientAddress, 
            string name, 
            string email, 
            string title,
            IEnumerable<string> roles) {
            this.loggedOn = loggedOn;
            this.expiresOn = expiresOn;

            issuer = ISSUER;
            this.clientAddress = clientAddress;
            Name = name;
            this.email = email;
            this.title = title;

            AuthenticationType = AuthType;
            IsAuthenticated = true;
            IsAnonymous = false;
            this.roles = new HashSet<string>(roles);
        }

        /// <summary>
        /// Ente che ha generato il token.
        /// </summary>
        [JsonProperty("iss")]
        public string issuer { get; private set; }

        /// <summary>
        /// Data e ora di accesso.
        /// </summary>
        [JsonProperty("iat")]
        public DateTime loggedOn { get; private set; }

        /// <summary>
        /// Data e ora di scadenza dell'autorizzazione all'accesso.
        /// </summary>
        [JsonProperty("exp")]
        public DateTime expiresOn { get; private set; }

        /// <summary>
        /// Nome dell'utente.
        /// </summary>
        [JsonProperty("sub")]
        public string Name { get; private set; }

        /// <summary>
        /// Indirizzo IP del computer dell'utente. 
        /// </summary>
        [JsonProperty("aud")]
        public string clientAddress { get; private set; }

        /// <summary>
        /// E-mail dell'utente.
        /// </summary>
        [EmailAddress, JsonProperty("email")]
        public string email { get; private set; }

        /// <summary>
        /// Denominazione dell'utente.
        /// </summary>
        [JsonProperty("title")]
        public string title { get; private set; }

        /// <summary>
        /// idFlowChart dell'utente.
        /// </summary>
        [JsonProperty("idFlowChart")]
        public string idFlowChart { get; private set; }

        /// <summary>
        /// nDetail dell'utente.
        /// </summary>
        [JsonProperty("nDetail")]
        public string nDetail { get; private set; }

        /// <summary>
        /// guidsession
        /// </summary>
        [JsonProperty("guidsession")]
        public Guid guidsession { get; private set; }

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
        public IEnumerable<string> roles { get; private set; }

        /// <summary>
        /// true se è una connessione con utente anonimo
        /// </summary>
        [JsonProperty("IsAnonymous")]
        public bool IsAnonymous { get; set; }

    }

    /// <summary>
    /// Utilità per la creazione di chiavi di sicurezza.
    /// </summary>
    public static class KeyChain {

        private static readonly int LengthSalt = 10;       // Numero di byte da generare per il "salt"
        private static readonly int LengthPassword = 12;    // Numero di byte da generare per le password
        private static readonly int LengthCode = 12;        // Numero di byte da generare per i codici di attivazione

        /// <summary>
        /// Genera una chiave crittografica della dimensione specificata.
        /// </summary>
        /// <param name="length">Lunghezza della chiave.</param>
        /// <returns>Chiave crittografica.</returns>
        private static byte[] generateKey(int length) {
            var key = new byte[length];

            using (RNGCryptoServiceProvider csprng = new RNGCryptoServiceProvider()) {
                csprng.GetBytes(key);
            }

            return key;
        }

        /// <summary>
        /// Genera il sale per una password, come sequenza di LengthSalt bytes casuali
        /// </summary>
        /// <returns>Il sale.</returns>
        public static byte[] generateSalt() {
            return generateKey(LengthSalt);
        }

        /// <summary>
        /// Genera una password casuale.
        /// </summary>
        /// <returns>Una password.</returns>
        public static string generatePassword() {
            return  Convert.ToBase64String(generateKey(LengthPassword));
        }

        /// <summary>
        /// Genera un codice di attivazione.
        /// </summary>
        /// <returns>Un codice di attivazione.</returns>
        public static string generateCode() {
            return Convert.ToBase64String(generateKey(LengthCode));
        }

    }

    /// <summary>
    /// Utilità per la gestione delle password.
    /// </summary>
    public static class Password {

        private static readonly int LengthHash = 20; // Numero di byte da generare per gli hash

        private static readonly string EmailSubject = "Password di accesso";
        private static readonly string EmailBody = "La tua nuova password per l'accesso ai servizi EasyPay è '{0}'.";

        /// <summary>
        /// Genera l'hash di una password.
        /// </summary>
        /// <param name="password">La password.</param>
        /// <param name="salt">Il sale.</param>
        /// <param name="iterations">Il numero di iterazioni da effettuare.</param>
        /// <param name="secureHashAlgorithm">Algoritmo di sicurezza Hash.</param>
        /// <returns>L'hash della password.</returns>
        public static byte[] generateHash(string password, byte[] salt, int iterations, string secureHashAlgorithm = "SHA256")
        {
            if (string.IsNullOrEmpty(password) || salt == null || iterations < 1) return null;
            if (salt.Length < 8) return null;
            var hash = new byte[LengthHash];

            if (string.IsNullOrWhiteSpace(secureHashAlgorithm))
                secureHashAlgorithm = "SHA256";

            switch (secureHashAlgorithm)
            {
                case "SHA1":
                    using (Rfc2898DeriveBytes pbkdf2 = new Rfc2898DeriveBytes(password, salt, iterations))
                    {
                        hash = pbkdf2.GetBytes(LengthHash);
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
        /// Verifica la correttezza di una password confrontandone l'hash calcolato con quello dato.
        /// </summary>
        /// <param name="password">La password.</param>
        /// <param name="salt">Il sale.</param>
        /// <param name="secureHash">L'hash registrato.</param>
        /// <param name="iterations">Il numero di iterazioni da effettuare.</param>
        /// <returns>Vero se le password coincidono.</returns>
        public static bool verify(string password, byte[] salt, byte[] secureHash, int iterations)
        {
            if (string.IsNullOrEmpty(password) || secureHash == null || salt == null || iterations < 1) return false;
            if (salt.Length < 8) return false;
            var insecureHash = generateHash(password, salt, iterations);

            if (Enumerable.SequenceEqual(secureHash, insecureHash))
                return true;

            insecureHash = generateHash(password, salt, iterations, "SHA1");
            if (Enumerable.SequenceEqual(secureHash, insecureHash))
                return true;

            return false;

        }

        ///// <summary>
        ///// Genera l'hash di una password.
        ///// </summary>
        ///// <param name="password">La password.</param>
        ///// <param name="salt">Il sale.</param>
        ///// <param name="iterations">Il numero di iterazioni da effettuare.</param>
        ///// <returns>L'hash della password.</returns>
        //public static byte[] generateHash(string password, byte[] salt, int iterations)
        //{
        //    if (string.IsNullOrEmpty(password) || salt == null || iterations < 1) return null;
        //    if (salt.Length < 8) return null;
        //    var hash = new byte[LengthHash];

        //    using (Rfc2898DeriveBytes pbkdf2 = new Rfc2898DeriveBytes(password, salt, iterations))
        //    {
        //        hash = pbkdf2.GetBytes(LengthHash);
        //    }

        //    return hash;
        //}

        ///// <summary>
        ///// Verifica la correttezza di una password confrontandone l'hash calcolato con quello dato.
        ///// </summary>
        ///// <param name="password">La password.</param>
        ///// <param name="salt">Il sale.</param>
        ///// <param name="secureHash">L'hash registrato.</param>
        ///// <param name="iterations">Il numero di iterazioni da effettuare.</param>
        ///// <returns>Vero se le password coincidono.</returns>
        //public static bool verify(string password, byte[] salt, byte[] secureHash, int iterations)
        //{
        //    if (string.IsNullOrEmpty(password) || secureHash == null || salt == null || iterations < 1) return false;
        //    if (salt.Length < 8) return false;
        //    var insecureHash = generateHash(password, salt, iterations);

        //    return Enumerable.SequenceEqual(secureHash, insecureHash);
        //}


        /// <summary>
        /// Invia un'e-mail contenente la password in chiaro dell'utente.
        /// </summary>
        /// <remarks>
        /// Da utilizzare solo per la procedura di reset della password.
        /// </remarks>
        /// <param name="recipient">L'e-mail dell'utente.</param>
        /// <param name="password">La password.</param>
        /// <returns>Il task di invio asincrono.</returns>
        public static Task sendEmail(string recipient, string password) {
            var address = new MailAddress(recipient);

            using (var client = new SmtpClient())
            using (var message = new MailMessage()) {
                message.To.Add(address);
                message.Subject = EmailSubject;
                message.Body = string.Format(EmailBody, password);

                client.Send(message);
            }

            return null;
        }

    }

    /// <summary>
    /// Utilità per la gestione dell'attivazione degli account.
    /// </summary>
    public static class Activation {

        private static readonly short CodeTtl = 15; // Numero di minuti di validità del codice generato

        private static readonly string EmailSubject = "Attivazione account";
        private static readonly string EmailBody = "Il codice di attivazione del tuo account per i servizi EasyPay è '{0}'.";

        private static MemoryCache _codeCache;

        static Activation() {
            _codeCache = new MemoryCache("ActivationCodes");
        }

        /// <summary>
        /// Attiva una determinata email e restituisce il codice di attivazione (che scadrà dopo un po')
        /// </summary>
        /// <param name="recipient"></param>
        /// <returns></returns>
        public static string activate(string recipient) {
            var code = KeyChain.generateCode();

            _codeCache.Set(recipient, code, DateTimeOffset.Now.AddMinutes(CodeTtl));
            return code;
        }
        /// <summary>
        /// Invia un'e-mail di attivazione.
        /// </summary>
        /// <param name="recipient">L'e-mail dell'utente.</param>
        /// <returns>Il task di invio asincrono.</returns>
        public static Task sendEmail(string recipient) {
            var code = activate(recipient);

            var address = new MailAddress(recipient);

            using (var client = new SmtpClient())
            using (var message = new MailMessage()) {
                message.To.Add(address);
                message.Subject = EmailSubject;
                message.Body = string.Format(EmailBody, code);

                client.Send(message);
            }

            return null;
        }

        /// <summary>
        /// Verifica che il codice di attivazione sia valido.
        /// </summary>
        /// <param name="recipient">L'e-mail dell'utente.</param>
        /// <param name="code">Il codice di attivazione.</param>
        /// <returns>Vero se il codice di attivazione è valido.</returns>
        public static bool verify(string recipient, string code) {
            return _codeCache.Contains(recipient) && _codeCache.Get(recipient).Equals(code);
        }

    }

    public sealed class SystemConfig
    {
        /// <summary>
        /// Data e ora di scadenza dell'autorizzazione all'accesso.
        /// </summary>
        [JsonProperty("dbPassword")]
        public String password { get; private set; }

        [JsonConstructor]
        public SystemConfig(String password)
        {
            this.password = password;
        }
    }

    /// <summary>
    /// Utility class for token validation
    /// </summary>
    public static class Token {

        private static readonly JwsAlgorithm SignatureAlgorithm = JwsAlgorithm.HS512;
        private static readonly int KeyBytes = 64; // 64 = HS512, 48 = HS384, 32 = HS256

        private static byte[] MasterKey;
        private static IConfigurationManager configurationManager;

        public static void Init(IConfigurationManager configurationManager) {
            Token.configurationManager = configurationManager;
        }

        static void assureMasterKey() {

            if (MasterKey!=null)return;

            //Creates o reads the master key from config
            var key = WebConfigurationManager.AppSettings.Get("MasterKey");

            if (string.IsNullOrEmpty(key)) {
                MasterKey = generateMasterKey();
                WebConfigurationManager.AppSettings.Add("MasterKey", Convert.ToBase64String(MasterKey));
            }
            else {
                MasterKey = Convert.FromBase64String(key);
            }
        }

        /// <summary>
        /// Imposta una master key o ne genera una random ove null
        /// </summary>
        /// <param name="base64MasterKey"></param>
        public static void setMasterkey(string base64MasterKey=null) {
            if (base64MasterKey == null) {
                MasterKey = generateMasterKey();
            }
            else {
                MasterKey = Convert.FromBase64String(base64MasterKey);
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
        private static byte[] generateMasterKey() {
            var key = new byte[KeyBytes];

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
        public static string encode(Identity data) {
            var json = JsonConvert.SerializeObject(data);
            if (json == null) return null;
            assureMasterKey();
        
            return JWT.Encode(json, MasterKey, SignatureAlgorithm);
          
        }

        /// <summary>
        /// Decodifica i dati dell'utente
        /// </summary>
        /// <param name="token">Il token firmato.</param>
        /// <returns>I dati dell'utente.</returns>
        public static Identity decode(string token, HttpContextWrapper requestContext) {

            assureMasterKey();
            var anonymousToken = WebConfigurationManager.AppSettings["AnonymousToken"];

            // se ho il token anonimo torno una identity particolare
            if (token == anonymousToken) {
                string clientAddress = requestContext.Request.UserHostAddress;
                var identity = new Identity(Guid.NewGuid(), clientAddress, anonymousToken, null, anonymousToken, null,null);
                identity.IsAnonymous = true;
                return identity;
            } else {
                string json;
                try {
                    json = JWT.Decode(token, MasterKey);
                    if (json == null)
                        return null;
                }
                catch (Exception ex) {
                    return null;
                }
                return JsonConvert.DeserializeObject<Identity>(json);
            }
            
        }

        /// <summary>
        /// Codifica i dati della configurazione. Per ora solo la password del db
        /// </summary>
        /// <param name="data">I dati dell'utente.</param>
        /// <returns>Un token firmato.</returns>
        public static string encodeSystemConfig(SystemConfig systemConfig)
        {
            var json = JsonConvert.SerializeObject(systemConfig);
            if (json == null) return null;
            assureMasterKey();
            return JWT.Encode(json, MasterKey, SignatureAlgorithm);

        }


        /// <summary>
        /// Decodifica i dati della configurazione
        /// </summary>
        /// <param name="sistemConfig">Il token firmato.</param>
        /// <returns>I dati dell'utente.</returns>
        public static SystemConfig decodeSystemConfig(string sistemConfig)
        {

            assureMasterKey();
            var json = JWT.Decode(sistemConfig, MasterKey);
            if (json == null) return null;

          return JsonConvert.DeserializeObject<SystemConfig>(json);

        }

    }

}
