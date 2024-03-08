
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


using Backend.CommonBackend;
using Backend.Data;
using Backend.Extensions;
using Backend.Models;
using Backend.Security;
using MailKit.Net.Smtp;
using MailKit.Security;
using metadatalibrary;
using metaeasylibrary;
using MimeKit;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Web;
using System.Web.Configuration;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Script.Serialization;
using static Backend.CommonBackend.DBLogger;
using Backend.LDAP;
using System.Runtime.Caching;
using System.Linq;
using System.Threading;

namespace Backend.Controllers {

	/// <summary>
	/// Gestisce  lo stato di autenticazione  e di registrazione
	/// </summary>
	public interface IAuthController {
		IHttpActionResult GetToken(LoginFormData data);

		/// <summary>
		/// Registra un nuovo utente per l'accesso al servizio.
		/// </summary>
		/// <remarks>
		/// Il metodo può essere invocato indistintamente per la registrazione di un utente privato oppure di una azienda.
		/// Nel primo caso è obbligatorio specificare un codice fiscale valido mentre nel secondo è obbligatorio
		/// specificare la partita IVA dell'azienda.
		/// La procedura di registrazione cerca nel database di Easy se l'e-mail specificata è già associata ad un'anagrafica
		/// attiva ed eventualmente le associa le credenziali di accesso al servizio. In alternativa viene generata una nuova
		/// anagrafica, contestualmente alla registrazione dell'account.
		/// Al termine della procedura di registrazione, verrà inviata una e-mail all'utente, contenente un codice
		/// per l'attivazione dell'account, mediante l'uso del metodo <see cref="AuthController.activate"/>.
		/// </remarks>
		/// <param name="data">Contenuto del form di registrazione (vedi <see cref="RegistrationFormData"/>).</param>
		/// <returns>Il risultato dell'elaborazione.</returns>
		IHttpActionResult register(RegistrationFormData data);

		/// <summary>
		/// Invia un codice di attivazione.
		/// </summary>
		/// <remarks>
		/// Questo metodo controlla che l'account associato alla e-mail specificata esista e non sia stato già attivato
		/// per l'accesso al servizio.
		/// Se la procedura va a buon fine, verrà inviata una e-mail all'utente, contenente un nuovo codice di attivazione.
		/// Se esiste già un codice nella cache, questo viene sovrascritto quindi solo l'ultimo codice generato è valido.
		/// </remarks>
		/// <param name="email">Indirizzo e-mail utilizzatao per la registrazione.</param>
		/// <returns>Risultato dell'elaborazione.</returns>
		IHttpActionResult sendActivationCode([Required, EmailAddress] string email);

		/// <summary>
		/// Attiva un account precedentemente registrato.
		/// </summary>
		/// <remarks>
		/// Questo metodo controlla che l'account associato alla e-mail specificata esista e non sia stato già attivato
		/// per l'accesso al servizio.
		/// Se la procedura va a buon fine, l'account viene attivato e può essere utilizzato per accedere la servizio.
		/// </remarks>
		/// <param name="email">Indirizzo e-mail utilizzatao per la registrazione.</param>
		/// <param name="code">Codice di attivazione.</param>
		/// <returns>Risultato dell'elaborazione.</returns>
		IHttpActionResult activate([Required, EmailAddress] string email, [Required] string code);

		/// <summary>
		/// Fornisce al client un token per l'accesso al servizio.
		/// </summary>
		/// <remarks>
		/// Questo metodo controlla che l'account associato alle credenziali specificate esista e sia stato attivato.
		/// Se la procedura va a buon fine, il metodo restituisce il token per l'accesso al servizio, contenente
		/// le informazioni relative all'identità dell'utente.
		/// </remarks>
		/// <param name="data">Contenuto del form di accesso (vedi <see cref="LoginFormData"/>).</param>
		/// <returns>Risultato dell'elaborazione.</returns>
		IHttpActionResult login(LoginFormData data);

		/// <summary>
		/// Reimposta la password di accesso al servizio.
		/// </summary>
		/// <remarks>
		/// Questo metodo controlla che l'account associato alle credenziali specificate esista e sia stato attivato.
		/// Se la procedura va a buon fine, viene generata una nuova password ed impostata all'account associato
		/// all'indirizzo e-mail specificato. Una e-mail viene inviata all'utente per notificargli la nuova password.
		/// </remarks>
		/// <param name="email">Indirizzo e-mail utilizzatao per la registrazione.</param>
		/// <returns>Risultato dell'elaborazione.</returns>
		IHttpActionResult resetPassword([Required, EmailAddress] string email);

		/// <summary>
		/// Ritorna le informazioni relative all'identità dell'utente.
		/// </summary>
		/// <remarks>
		/// Usare questo metodo esclusivamente per operazioni di debug. Il token restituito dal metodo
		/// <see cref="AuthController.login"/> è decodificabile dal client.
		/// </remarks>
		/// <returns>Le informazioni contenute nel token di autenticazione.</returns>
		IHttpActionResult userData();


	}

	public static class memCache
	{
		public static MemoryCache _authCache = new MemoryCache("authCache");
	}

	/// <summary>
	/// Controller contenente le primitive necessarie alla gestione dell'autenticazione.
	/// </summary>
	/// <remarks>
	/// Il percorso (URL) per accedere ai metodi contenuti in questo controller devono avere il prefisso "/auth".
	/// I metodi contenuti in questo controller sono accessibili senza necessità di specificare il token di autenticazione.
	/// I metodi contenuti in questo controller sono accessibili da qualsiasi client (CORS attivati per ogni richiesta).
	/// </remarks>
	[RoutePrefix("auth"), AllowAnonymous, EnableCors("*", "*", "*")]
	public class AuthController : ApiController, IAuthController {

		private const int RegistryClassCompany = 21;
		private const int RegistryClassPrivate = 22;

		/// <summary>
		/// /Auth/GetToken
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>
		[HttpPost, Route("GetToken")]
		public IHttpActionResult GetToken(LoginFormData data)
		{
			if (data?.userName == null)
			{
				return base.Content(HttpStatusCode.BadRequest, LoginFailedStatus.NoCredential);
			}

			if (data.password == null)
			{
				return base.Content(HttpStatusCode.BadRequest, LoginFailedStatus.NoCredential);
			}

			if (data.datacontabile == null || data.datacontabile == DateTime.MinValue)
			{
				return base.Content(HttpStatusCode.BadRequest, LoginFailedStatus.DataContabileMissing);
			}

			int userkind = Convert.ToInt32(WebConfigurationManager.AppSettings["userkindUserPassw"]);
			IHttpActionResult loginResult = _doLogin(data?.userName, data.password, data.datacontabile, null, userkind);
			HttpResponseMessage response = loginResult.ExecuteAsync(CancellationToken.None).Result;

			// Get the status code from the HttpResponseMessage
			HttpStatusCode statusCode = response.StatusCode;

			if (statusCode == HttpStatusCode.OK)
			{
				JObject content = ((System.Web.Http.Results.NegotiatedContentResult<Newtonsoft.Json.Linq.JObject>)loginResult).Content;

                string token = ((Newtonsoft.Json.Linq.JValue)content.Properties().Where(w => w.Name == "token").Select(s => s.Value).FirstOrDefault()).Value.ToString();
				memCache._authCache.Set(token, token, DateTimeOffset.Now.AddHours(2));

				return Ok(token);
			}

			return loginResult;
		}

		/// <summary>
		/// OBSOLETO, la registrazione avvine sul metodo savedataset. Registra un nuovo utente per l'accesso al servizio.
		/// </summary>
		/// <remarks>
		/// Il metodo può essere invocato indistintamente per la registrazione di un utente privato oppure di una azienda.
		/// Nel primo caso è obbligatorio specificare un codice fiscale valido mentre nel secondo è obbligatorio
		/// specificare la partita IVA dell'azienda.
		/// La procedura di registrazione cerca nel database di Easy se l'e-mail specificata è già associata ad un'anagrafica
		/// attiva ed eventualmente le associa le credenziali di accesso al servizio. In alternativa viene generata una nuova
		/// anagrafica, contestualmente alla registrazione dell'account.
		/// Al termine della procedura di registrazione, verrà inviata una e-mail all'utente, contenente un codice
		/// per l'attivazione dell'account, mediante l'uso del metodo <see cref="activate"/>.
		/// </remarks>
		/// <param name="data">Contenuto del form di registrazione (vedi <see cref="RegistrationFormData"/>).</param>
		/// <returns>Il risultato dell'elaborazione.</returns>
		[HttpPost, Route("register")]
		public IHttpActionResult register([FromBody] RegistrationFormData data) {
			if (data == null) {
				return base.Content(HttpStatusCode.BadRequest, "Dati non specificati.");
			}

			string errori;

			int idregistryclass;

			// Controlla la partita IVA
			var piva = data.partitaIva?.ToUpper();
			if (!string.IsNullOrEmpty(piva)) {
				errori = PartitaIva.controllaPartitaIva(piva);
				if (!string.IsNullOrEmpty(errori)) {
					return Content(HttpStatusCode.BadRequest, "Partita IVA non valida.");
				}

				idregistryclass = RegistryClassCompany;
			}
			else {
				idregistryclass = RegistryClassPrivate;
			}

			// Controlla il codice fiscale
			var cf = data.codiceFiscale?.ToUpper();
			if (idregistryclass == RegistryClassPrivate) {
				errori = CodiceFiscale.checkCf(cf);
				if (!string.IsNullOrEmpty(errori)) {
					return Content(HttpStatusCode.BadRequest, "Codice fiscale non valido.");
				}
			}

			// creo connessione di sistema per il codice della register
			var dispatcher = new Dispatcher();
			dispatcher.createDbConnection();
			var QH = dispatcher.QueryHelper;

			var metaRegistry = dispatcher.GetMeta("registry");
			var metaReference = dispatcher.GetMeta("registryreference");

			var ds = new dsmeta_registry_anagrafica();
			metaRegistry.SetDefaults(ds.registry);
			metaReference.SetDefaults(ds.registryreference);

			var getData = new GetData();
			getData.InitClass(ds, dispatcher.Connection, "registry");

			var filterRegistry = QH.CmpEq("active", "S");
			if (idregistryclass == RegistryClassPrivate) {
				filterRegistry = QH.AppAnd(filterRegistry, QH.CmpEq("cf", cf));
			}
			else if (idregistryclass == RegistryClassCompany) {
				filterRegistry = QH.AppAnd(filterRegistry, QH.CmpEq("p_iva", piva));
			}

			//Cerca un'anagrafica con specificato codice fiscale o partita iva
			getData.GET_PRIMARY_TABLE(filterRegistry);

			// Crea l'anagrafica o carica dettagli ed indirizzi di quella esistente
			var registryRow = ds.registry.First();

			if (registryRow == null) {
				//L'anagrafica non esiste, la crea
				//Causale credito e debito da configurazione
				var idaccmotivecredit = WebConfigurationManager.AppSettings["CausaleCredito"];
				var idaccmotivedebit = WebConfigurationManager.AppSettings["CausaleDebito"];

				registryRow = metaRegistry.Get_New_Row(null, ds.registry) as MetaRow;
				registryRow["idregistryclass"] = idregistryclass;
				registryRow["idaccmotivecredit"] = idaccmotivecredit;
				registryRow["idaccmotivedebit"] = idaccmotivedebit;
				registryRow["cf"] = cf;
				registryRow["title"] = data.denominazione;

				if (idregistryclass == RegistryClassCompany) {
					registryRow["p_iva"] = piva;
				}
				else {
					registryRow["surname"] = data.cognome;
					registryRow["forename"] = data.nome;
					registryRow["birthdate"] = data.dataNascita;
					registryRow["gender"] = InfoDaCodiceFiscale.sesso(cf);
				}
			}
			else {
				getData.DO_GET(false, registryRow);
			}

			// Crea un nuovo contatto o riutilizza quello già esistente
			var filterByEmail = dispatcher.CQueryHelper.CmpEq("email", data.email);
			var referenceRow = ds.registryreference.First(filterByEmail);
			if (referenceRow == null) {
				referenceRow = metaReference.Get_New_Row(registryRow, ds.registryreference) as MetaRow;
				referenceRow["email"] = data.email;
			}
			else if (!referenceRow.IsNull("passwordweb")) {
				return Content(HttpStatusCode.BadRequest, "Utente già registrato.");
			}

			// Imposta il contatto di default in caso non ce ne sia già uno
			var filterDefault = dispatcher.CQueryHelper.CmpEq("flagdefault", "S");
			var defaultReferenceRow = ds.registryreference.First(filterDefault);
			if (defaultReferenceRow == null) {
				referenceRow["flagdefault"] = "S";
			}

			Random rnd = new Random();
			var iterations = rnd.Next(20, 100);
			var salt = KeyChain.generateSalt();
			var hash = Password.generateHash(data.password, salt, iterations);

			//sovrascrive eventuale password presenti
			referenceRow["userweb"] = data.userName;
			referenceRow["iterweb"] = iterations;
			referenceRow["saltweb"] = salt.toHexString();
			referenceRow["passwordweb"] = hash.toHexString();

			var postData = new Easy_PostData();
			postData.initClass(ds, dispatcher.Connection);

			// *************************************************************************************
			// 1. TODO Devo associare qui il virtualuser, a seconda del tipo di utente
			// Es. 0 Admin, 1 studente, 2. docente rappresentato dallo "usekind" su virtual user.
			// Quindi inserire una entry per quel virtual user che ho configurato , inserisco la username.
			// mentre il sys_user è quello che utilizzo per andare in join con idcustomer su flowchartuser, che a sua volta vain join con flowchart tramite idflowchart
			// Sono tutte tab di configurazione quindi tranne l'inserimento della entry per username su virtual user, che va fatta qui alla registrazione.
			// Vedi punto 2 su login()
			string sys_user = "nino";
			string userkind = "3";
			string[] columns = new[] { "forename", "codicedipartimento", "surname", "sys_user", "userkind", "username" };
			string[] values = new[] {
				(string) registryRow["forename"], "amm", (string) registryRow["surname"], sys_user, userkind,
				data.userName
			}; // TODO userkind e sys-user capire da dove prendere
			dispatcher.conn.DO_INSERT("virtualuser", columns, values, 6);
			// *************************************************************************************

			var pmc = postData.DO_POST_SERVICE();
			if (pmc.Count > 0) {
				return Content(HttpStatusCode.InternalServerError, "Errore del server dati.");
			}

			try {
				// invoca metodo classe Activation xhe si trova sotto security.cs
				Activation.sendEmail(data.email);
			}
			catch (Exception ex) {
#if DEBUG
				Debug.WriteLine(ex.Message);
				Debug.WriteLine(ex.StackTrace);

				if (ex.InnerException != null) {
					Debug.WriteLine(ex.InnerException.Message);
					Debug.WriteLine(ex.InnerException.StackTrace);
				}
#endif

				return Content(HttpStatusCode.InternalServerError, "Invio dell'e-mail di attivazione fallito.");
			}

			return Content(HttpStatusCode.Created, "Registrazione completata.");
		}

		/// <summary>
		/// Invia un codice di attivazione.
		/// </summary>
		/// <remarks>
		/// Questo metodo controlla che l'account associato alla e-mail specificata esista e non sia stato già attivato
		/// per l'accesso al servizio.
		/// Se la procedura va a buon fine, verrà inviata una e-mail all'utente, contenente un nuovo codice di attivazione.
		/// Se esiste già un codice nella cache, questo viene sovrascritto quindi solo l'ultimo codice generato è valido.
		/// </remarks>
		/// <param name="email">Indirizzo e-mail utilizzatao per la registrazione.</param>
		/// <returns>Risultato dell'elaborazione.</returns>
		[HttpGet, Route("sendcode")]
		public IHttpActionResult sendActivationCode([Required, EmailAddress] string email) {
			var dispatcher = HttpContext.Current.getDataDispatcher();

			var metaRegistry = dispatcher.GetMeta("registry");
			var metaReference = dispatcher.GetMeta("registryreference");

			var ds = new dsmeta_registry_anagrafica();

			var getData = new GetData();
			getData.InitClass(ds, dispatcher.Connection, "registryreference");

			var filterByEmail = dispatcher.QueryHelper.CmpEq("email", email);
			getData.GET_PRIMARY_TABLE(filterByEmail);

			var referenceRow = ds.registryreference.First();
			if (referenceRow == null) {
				return Content(HttpStatusCode.NotFound, "E-mail non registrata.");
			}
			else if (referenceRow.Field<string>("activeweb").Equals("S")) {
				return Content(HttpStatusCode.Forbidden, "Account già attivato.");
			}

			try {
				Activation.sendEmail(email);
			}
			catch (Exception ex) {
#if DEBUG
				Debug.WriteLine(ex.Message);
				Debug.WriteLine(ex.StackTrace);

				if (ex.InnerException != null) {
					Debug.WriteLine(ex.InnerException.Message);
					Debug.WriteLine(ex.InnerException.StackTrace);
				}
#endif

				return Content(HttpStatusCode.InternalServerError, "Invio dell'e-mail di attivazione fallito.");
			}

			return Content(HttpStatusCode.OK, "E-mail di attivazione inviata.");

		}

		/// <summary>
		/// Attiva un account precedentemente registrato.
		/// </summary>
		/// <remarks>
		/// Questo metodo controlla che l'account associato alla e-mail specificata esista e non sia stato già attivato
		/// per l'accesso al servizio.
		/// Se la procedura va a buon fine, l'account viene attivato e può essere utilizzato per accedere la servizio.
		/// </remarks>
		/// <param name="email">Indirizzo e-mail utilizzatao per la registrazione.</param>
		/// <param name="code">Codice di attivazione.</param>
		/// <returns>Risultato dell'elaborazione.</returns>
		[HttpGet, Route("activate")]
		public IHttpActionResult activate([Required, EmailAddress] string email, [Required] string code) {
			if (!Activation.verify(email, code)) {
				return Content(HttpStatusCode.Forbidden, "Codice non valido o scaduto.");
			}

			var dispatcher = HttpContext.Current.getDataDispatcher();


			var ds = new dsmeta_registry_anagrafica();

			var getData = new GetData();
			getData.InitClass(ds, dispatcher.Connection, "registryreference");

			var filterByEmail = dispatcher.QueryHelper.CmpEq("email", email);
			getData.GET_PRIMARY_TABLE(filterByEmail);

			var referenceRow = ds.registryreference.First();
			if (referenceRow == null) {
				return Content(HttpStatusCode.NotFound, "E-mail non registrata.");
			}
			else if (referenceRow.Field<string>("activeweb").Equals("S")) {
				return Content(HttpStatusCode.Forbidden, "Account già attivato.");
			}

			referenceRow.SetField("activeweb", "S");

			var postData = new Easy_PostData();
			postData.initClass(ds, dispatcher.Connection);

			var pmc = postData.DO_POST_SERVICE();
			if (pmc.Count > 0) {
				return Content(HttpStatusCode.InternalServerError, "Errore del server dati.");
			}

			return Content(HttpStatusCode.OK, "Account attivato");
		}

		[HttpPost, Route("loginSSO")]
		public IHttpActionResult loginSSO([FromBody] LoginFormDataSSO data) {

			if (data?.userName == null) {
				return base.Content(HttpStatusCode.BadRequest, LoginFailedStatus.NoCredential);
			}

			if (data.session == null) {
				return base.Content(HttpStatusCode.BadRequest, LoginFailedStatus.NoCredential);
			}

			if (data.datacontabile == null || data.datacontabile == DateTime.MinValue) {
				return base.Content(HttpStatusCode.BadRequest, LoginFailedStatus.DataContabileMissing);
			}

			// check sulla sessione
			// recupera la session dal server e vede se è scaduta
			// questa viene creata su saml/consumer.aspx.cs
			SessionInfoSSO authenticatedSSO = SessionMDLW.validSessionSSO(data.session, data.userName);

			// scommentare per debug senza SSO attivo . ci entra se EnableSSORegistraton=true e se uso una username inesistente nella login normale
			// ** DEBUG ---> 
			// authenticatedSSO = new SessionInfoSSO(data.userName, "forename" + data.userName, "surname" + data.userName, "email" + data.userName, "cf" + data.userName, "matricola" + data.userName);
			// ** END DEBUG ROW

			if (authenticatedSSO != null) {
				int userkind = Convert.ToInt32(WebConfigurationManager.AppSettings["userkindSSO"]);
				return _doLogin(data?.userName, "", data.datacontabile, authenticatedSSO, userkind);
			}

			return base.Content(HttpStatusCode.BadRequest, LoginFailedStatus.NoCredential);
		}

		[HttpPost, Route("loginLDAP")]
		public IHttpActionResult loginLDAP([FromBody] LoginFormData data) {

			if (data?.userName == null) {
				return base.Content(HttpStatusCode.BadRequest, LoginFailedStatus.NoCredential);
			}

			if (data.password == null) {
				return base.Content(HttpStatusCode.BadRequest, LoginFailedStatus.NoCredential);
			}

			if (data.datacontabile == null || data.datacontabile == DateTime.MinValue) {
				return base.Content(HttpStatusCode.BadRequest, LoginFailedStatus.DataContabileMissing);
			}


            //// connessione al DB webreport dove c'è il mapping tra username e utente ldap
            //string Server = WebConfigurationManager.AppSettings["DBServer"];
            //string Database = "webreport_unisalento";
            //string User = "webuser_unisalento";
            //SystemConfig systemConfig = Security.Token.decodeSystemConfig(WebConfigurationManager.AppSettings["DBPassword"]);
            //string Password = "#read__only_for_webreport_unisalento#";
            //string DIPARTIMENTO = WebConfigurationManager.AppSettings["DBDipartimento"]; ;
            //int Esercizio = DateTime.Now.Year;


            //DataAccess Conn = new DataAccess("myDsn",
            // Server, Database,
            // User, Password,
            // DateTime.Now.Year, DateTime.Now);

            // 1. richiede una connessione di sistema
            var dispatcher = new Dispatcher();
            dispatcher.createDbConnection();
            IEasyDataAccess usrConn = dispatcher.conn;

			// 2. ripulisco la security della connessione ne caso in cui sia stata riciclata una già esistente
            EasySecurity sec = usrConn.Security as EasySecurity;
            sec.Clear();

			// 3. ricavo i parametri dell'LDAP dal db
            ldapauth ldpauth = new ldapauth((DataAccess)usrConn);
			if (!ldpauth.getconfig()) {
                BEError bEError = new BEError();
                bEError.conn = usrConn;
                bEError.error = "Configurazione mancante";
                bEError.methodInfo = "loginLDAP";
                bEError.metadata = "esercizio: " + data.datacontabile.Year + ", sys_user: " + data?.userName + ", userName: " + data?.userName;
                DBLogger.log(bEError); return base.Content(HttpStatusCode.BadRequest, "Errore LA.getconfig: " + ldpauth.ErrorMsg);
			}

			// 4. eseguo l'autenticazione sul sistema LDAP
			if (!ldpauth.Authenticate(data?.userName, data?.password)) {
				if (!string.IsNullOrWhiteSpace(ldpauth.ErrorMsg))
				{
					BEError bEError = new BEError();
					bEError.conn = usrConn;
					bEError.error = ldpauth.ErrorMsg;
					bEError.methodInfo = "loginLDAP";
					bEError.metadata = "esercizio: " + data.datacontabile.Year + ", sys_user: " + data?.userName + ", userName: " + data?.userName;
					DBLogger.log(bEError);
				}
				return base.Content(HttpStatusCode.BadRequest, "Errore LDAP.Authenticate: " + ldpauth.ErrorMsg);
			}

			// 5. eseguo l'autenticazione sul sistema
			// costruisco un sessionInfo così esegue stessi passi di sso, quindi no check password
			int userkind = Convert.ToInt32(WebConfigurationManager.AppSettings["userkindLDAP"]);
			SessionInfoSSO sessionInfoSSO = new SessionInfoSSO(data.userName, "", "", data.userName, "", "");
			return _doLogin(ldpauth.user_decoded, "", data.datacontabile, sessionInfoSSO, userkind);

		}

		/// <summary>
		/// Fornisce al client un token per l'accesso al servizio.
		/// </summary>
		/// <remarks>
		/// Questo metodo controlla che l'account associato alle credenziali specificate esista e sia stato attivato.
		/// Se la procedura va a buon fine, il metodo restituisce il token per l'accesso al servizio, contenente
		/// le informazioni relative all'identità dell'utente.
		/// </remarks>
		/// <param name="data">Contenuto del form di accesso (vedi <see cref="LoginFormData"/>).</param>
		/// <returns>Risultato dell'elaborazione.</returns>
		[HttpPost, Route("login")]
		public IHttpActionResult login([FromBody]  LoginFormData data) {
			if (data?.userName == null) {
				return base.Content(HttpStatusCode.BadRequest, LoginFailedStatus.NoCredential);
			}

			if (data.password == null) {
				return base.Content(HttpStatusCode.BadRequest, LoginFailedStatus.NoCredential);
			}

			if (data.datacontabile == null || data.datacontabile == DateTime.MinValue) {
				return base.Content(HttpStatusCode.BadRequest, LoginFailedStatus.DataContabileMissing);
			}

			int userkind = Convert.ToInt32(WebConfigurationManager.AppSettings["userkindUserPassw"]);
			return _doLogin(data?.userName, data.password, data.datacontabile, null, userkind);

		}

		private bool isEmptyVirtualUser(DataTable virtualuser) {
			if (virtualuser == null) {
				return true;
			}

			if (virtualuser.Rows.Count == 0) {
				return true;
			}

			return false;
		}

		/// <summary>
		/// Verifica che l'utente possa avere accesso al programma, lo decodifica tramite la tabella virtualuser ai fini della determinazione dell'utente di
		///  organigramma. Se non è SSO, verifica la password in registryreference.
		/// </summary>
		/// <param name="userName"></param>
		/// <param name="password">sarà vuota nel caso di login SSO</param> 
		/// <param name="datacontabile"></param>
		/// <param name="sessionInfoSSO">obj se è chiamata da login  SSO, null altrimenti</param>
		/// <param name="userkind"></param> 
		/// <returns></returns>
		private IHttpActionResult _doLogin(String userName, String password, DateTime datacontabile, SessionInfoSSO sessionInfoSSO, int userkind) {
			// 1. richiede una connessione di sistema
			var dispatcher = new Dispatcher();
			dispatcher.createDbConnection();
			IEasyDataAccess usrConn = dispatcher.conn;
			var QH = dispatcher.QueryHelper;
			EasySecurity sec = usrConn.Security as EasySecurity;
			// svuota usr + sys environment
			string[] uks = sec.EnumUsrKeys();
			foreach (object o in uks) {
				object k = sec.GetUsr(o.ToString());
				sec.SetUsr(o.ToString(), null);
			}
			sec.SetSys("user", null);
			sec.SetSys("usergrouplist", null);
			sec.SetSys("idcustomuser", null);

			// cerco virtual user associato
			var coddip = WebConfigurationManager.AppSettings["DBDipartimento"].ToString();
			string filter = QH.AppAnd(QH.CmpEq("username", userName),
				QH.CmpEq("codicedipartimento", coddip),
				QH.CmpEq("userkind", userkind)
			);
			DataTable virtualuser = dispatcher.conn.RUN_SELECT("virtualuser", "*", null, filter, null, false);
			string sys_user;

			/**********************************************************************************************/
			// 2. imposto sicurezza 
			// Devo recuperare il virtualuser, e utilizzo il sys_user del virtual user come  sec.SetSys("user", sys_user);
			// in modo tale che prendo i privilegi del virtual user, l'associazione con l'utente corrente è fatta nella registrazione a seconda del tipo
			// cioè se studente, docente etc... Dal virtual user poi il sistema associa il flowchartid e ndetail giusti, prendendoli da flowchartuser 
			// che sta in join con flowchart tramite idflowchart

			string email = "";

			//Calcola l'utente effettivo da utilizzare, anche ai fini della sicurezza, e lo mette in usrConn.externalUser
			if (!isEmptyVirtualUser(virtualuser)) {
				sys_user = virtualuser.Rows[0]["sys_user"].ToString();
				var forename = virtualuser.Rows[0]["forename"].ToString();
				var lastname = virtualuser.Rows[0]["surname"].ToString();
				email = virtualuser.Rows[0]["email"].ToString();
				var cf = virtualuser.Rows[0]["cf"].ToString();
				//external user è il nome con cui l'utente si logga, che non è necessariamente quello ai fini dell'organigramma
				usrConn.externalUser = userName;
				sec.SetUsr("HasVirtualUser", "S");
				sec.SetSys("user", sys_user);
				sec.SetSys("usergrouplist", null);
				sec.SetUsr("forename", forename);
				sec.SetUsr("surname", lastname);
				sec.SetUsr("email", email);
				sec.SetUsr("cf", cf);
			}
			else {
				// NON è associato ad external user
				var ext_user = userName;
				sys_user = userName;
				usrConn.externalUser = ext_user;
				sec.SetSys("user", sys_user);
				sec.SetSys("usergrouplist", null);
			}

			// Cerca su registryreference la userweb pari allo username
			// 4. eseguo logica di business per l'utente che si trova su registry reference
			var ds = new dsmeta_registry_anagrafica();

			var getData = new GetData();
			getData.InitClass(ds, dispatcher.Connection, "registryreference");

			var filterByUsername = dispatcher.QueryHelper.CmpEq("userweb", userName);
			getData.GET_PRIMARY_TABLE(filterByUsername);

			var referenceRow = ds.registryreference.First();

			bool enableSSORegistration = Convert.ToBoolean(WebConfigurationManager.AppSettings["EnableSSORegistraton"]);

			// se non trovo utente su virtual user ed è abilitata la richiesta di registarzione allora proviamo con la richeista di registrazione
			if (isEmptyVirtualUser(virtualuser) && enableSSORegistration) {


				if (sessionInfoSSO != null) {
					// è richiesta registrazione. 

					var resultSSO = new JObject {
						{"login", sessionInfoSSO.userName},
						{"forename", sessionInfoSSO.name},
						{"surname", sessionInfoSSO.surname},
						{"email", sessionInfoSSO.email},
						{"cf", sessionInfoSSO.cf},
						{"matricola", sessionInfoSSO.matricola},
						{"userkind", userkind},
					};
					return Content(HttpStatusCode.OK, resultSSO);
				}

                BEError bEError = new BEError();
                bEError.conn = usrConn;
                bEError.error = LoginFailedStatus.BadCredential;
                bEError.methodInfo = "login";
                bEError.metadata = "esercizio: " + usrConn.Security.GetSys("esercizio") + ", sys_user: " + sys_user + 
                    ", idcustomuser: " + usrConn.Security.GetSys("idcustomuser") + ", userName: " + userName;
                DBLogger.log(bEError);

                return Content(HttpStatusCode.Unauthorized, LoginFailedStatus.BadCredential);
			}

			if (referenceRow == null) {

                BEError bEError = new BEError();
                bEError.conn = usrConn;
                bEError.error = LoginFailedStatus.UserNotSecurity + " - registryreference non trovata";
                bEError.methodInfo = "login";
                bEError.metadata = "esercizio: " + usrConn.Security.GetSys("esercizio") + ", sys_user: " + sys_user + 
                    ", idcustomuser: " + usrConn.Security.GetSys("idcustomuser") + ", userName: " + userName;
                DBLogger.log(bEError);

                return Content(HttpStatusCode.Unauthorized, LoginFailedStatus.BadCredential);
			}

			if (referenceRow["email"] != null)
				email = referenceRow["email"].ToString();

            // 5. prendo idreg e lo metto nel token
            var idreg = referenceRow["idreg"] != null ? referenceRow["idreg"].ToString() : string.Empty;

            // se non si tratta di SSO verifico la password
            if (sessionInfoSSO == null) {
				var iterations = referenceRow["iterweb"] != null ?
					!string.IsNullOrWhiteSpace(referenceRow["iterweb"].ToString()) ?
						(int?)referenceRow["iterweb"]
						: null
					: null;
				var salt = !string.IsNullOrWhiteSpace(referenceRow["saltweb"].ToString()) ?
					((String)referenceRow["saltweb"]).toBytes() : null;
				var hash = !string.IsNullOrWhiteSpace(referenceRow["passwordweb"].ToString()) ?
					((String)referenceRow["passwordweb"]).toBytes() : null;

				if (!iterations.HasValue) {

                    BEError bEError = new BEError();
                    bEError.conn = usrConn;
                    bEError.error = LoginFailedStatus.BadCredential;
                    bEError.methodInfo = "login";
                    bEError.metadata = "esercizio: " + usrConn.Security.GetSys("esercizio") + ", sys_user: " + sys_user + ", idreg: " + idreg +
                        ", idcustomuser: " + usrConn.Security.GetSys("idcustomuser") + ", userName: " + userName;
                    DBLogger.log(bEError);

                    return Content(HttpStatusCode.Unauthorized, LoginFailedStatus.BadCredential);
				}

				if (!Password.verify(password, salt, hash, iterations.Value)) {

                    BEError bEError = new BEError();
                    bEError.conn = usrConn;
                    bEError.error = LoginFailedStatus.BadCredential;
                    bEError.methodInfo = "login";
                    bEError.metadata = "esercizio: " + usrConn.Security.GetSys("esercizio") + ", sys_user: " + sys_user + ", idreg: " + idreg +
                        ", idcustomuser: " + usrConn.Security.GetSys("idcustomuser") + ", userName: " + userName;
                    DBLogger.log(bEError);

                    return Content(HttpStatusCode.Unauthorized, LoginFailedStatus.BadCredential);
				}
			}



			//var registryRow = referenceRow.GetParentRow("FK_registryreference_registry");
			var filterDenominazione = "idreg=" + idreg; //  q.eq("idreg", referenceRow.idreg.ToString());
			string denominazione = (string)usrConn.DO_READ_VALUE("registry", filterDenominazione, "title");


			// 6. profilo la sicurezza. TODO capire se devo mettere in cache.
			sec.CalculateGroupList();
			sec.RecalcUserEnvironment();
			// osservo se le groupOperation sono  in cache
			// il sys_user corrisponde al customuser
			var groupOperations = CacheMDLW.getGroupOperations(sys_user);
			if (groupOperations == null) {
				// se non trovo nella cache lo calcolo, altrimeni lo ricavo dalla cache
				sec.ReadAllGroupOperations();
			}
			else {
				sec.groupOperations = groupOperations;
			}

			// aggiungo eventuale utente con groupOperations nella cache
			CacheMDLW.addUtilizer(sys_user, idreg, sec.groupOperations);

			// 7. memorizzo idflowchart e nDetail, che individuano il ruolo dell'utente. Saranno passati nel token
			// sul metodo "AuthenticateAsync" che gestisce l'autenticazione su WebApiconfig.cs; recupererò la sicurezza prendendo idflowcahrt e nDetail che 
			// mettiamo nel token di autenticazione durante la fase di login
			object idflowchart = usrConn.Security.GetSys("idflowchart");
			object nDetail = usrConn.Security.GetSys("ndetail");

			// check su utente sotto controllo di sicurezza 
			if ((idflowchart.ToString() == "" || nDetail.ToString() == "")) {

				BEError bEError = new BEError();
				bEError.conn = usrConn;
				bEError.error = LoginFailedStatus.UserNotSecurity;
				bEError.methodInfo = "login";
				bEError.metadata = "esercizio: " + usrConn.Security.GetSys("esercizio") + ", sys_user: " + sys_user + ", idreg: " + idreg +
					", idcustomuser: " + usrConn.Security.GetSys("idcustomuser") + ", userName: " + userName;
				DBLogger.log(bEError);

				return Content(HttpStatusCode.Unauthorized, LoginFailedStatus.UserNotSecurity);
			}

			if (!CambioDataConsentita(usrConn, datacontabile)) {

                BEError bEError = new BEError();
                bEError.conn = usrConn;
                bEError.error = LoginFailedStatus.DataNotPermitted;
                bEError.methodInfo = "login";
                bEError.metadata = "esercizio: " + usrConn.Security.GetSys("esercizio") + ", sys_user: " + sys_user + ", idreg: " + idreg +
                    ", idcustomuser: " + usrConn.Security.GetSys("idcustomuser") + ", userName: " + userName;
                DBLogger.log(bEError);

                return Content(HttpStatusCode.Unauthorized, LoginFailedStatus.DataNotPermitted);
			}


			// 8 + 9. Salvo un nuovo sessionInfo. Lo utilizzo come cache e lo invio al client la prima volta.
			// Creo un guid, che è la chiave per la specifica sessione

			// inserisco la username
			sec.SetUsr("userweb", userName);

			// inserisce tra le var di sistema di segreterie idreg_istituto
			var idreg_istituto = dispatcher.conn.DO_READ_VALUE("istitutoprinc", null, "idreg", null);
			sec.SetUsr("idreg_istituto", idreg_istituto);

			sec.SetUsr("idreg", idreg);

            //inserisco l'eventuale idman corrispondente alle variabili di ambiente
            int? idman = (int?)usrConn.DO_READ_VALUE("manager", filterByUsername, "idman");
            sec.SetUsr("idman", idman);


            Guid guidSession = Guid.NewGuid();
			// calcolo le hashtable con l'environment
			Hashtable usr = AuthUtils.getUsr(sec);
			Hashtable sys = AuthUtils.getSys(sec);

			// 9. salvo sessione con usr sys e groupOperations  e sys_user che è
			// la chiave tramite cui accederò alla cache per i privilegi di sicurezza
			SessionMDLW.createSession(guidSession, usr, sys, sys_user, idreg);

			// 9.1 Calcola ruoli
			//TODO: se la data contabile non è quella di oggi dare come ruoli l'intersezione tra
			//quello che ha oggi con quello che aveva nella data contabile
			DataTable dtRoles = getRolesDataTable(DateTime.Today, sys_user, dispatcher);

			// 10. costruisco token da mandare all'utente
			String clientAddress = HttpContext.Current.Request.UserHostAddress;
			var userdata = new Identity(guidSession, clientAddress, userName, email, denominazione,
				idflowchart.ToString(), nDetail.ToString());
			var token = Security.Token.encode(userdata);

			var dbversion = dispatcher.conn.DO_READ_VALUE("updatedbversion", null, "max(versionname)");

            Hashtable sysClient = new Hashtable();
			sysClient.Add("dbversion", dbversion);
			sysClient.Add("backendversion", System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString());
			sysClient.Add("idcustomuser", usrConn.Security.GetSys("idcustomuser"));
			sysClient.Add("ndetail", usrConn.Security.GetSys("ndetail"));
			sysClient.Add("usergrouplist", usrConn.Security.GetSys("usergrouplist"));
			sysClient.Add("ayear", datacontabile.Year);
			sysClient.Add("esercizio", datacontabile.Year);
			sysClient.Add("idflowchart",idflowchart);
			sysClient.Add("user", userName);
			

			// 11. distruggo connessione di sistema
			if (dispatcher != null) {
				dispatcher.Dispose();
			}

			dispatcher = null;

			//eseguo il LOG degli accessi
            BEError logOK = new BEError();
            logOK.conn = usrConn;
            logOK.error = "Login avvenuto con successo";
            logOK.methodInfo = "login";
            logOK.metadata = 
				"esercizio: " + usrConn.Security.GetSys("esercizio") + 
				", sys_user: " + sys_user + 
				", idreg: " + idreg +
                ", idcustomuser: " + usrConn.Security.GetSys("idcustomuser") +
                ", userName: " + userName +
                ", dbversion: " + dbversion.ToString() +
                ", backendversion: " + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString() +
                ", idflowchart: " + idflowchart 
                ;
            DBLogger.log(logOK);

            // 12. invio al client le informazioni dopo la login, cioè il token più l'environment (le system per questioni di sicurezza non le invio)
            // expiresOn serve al client nel check per non mostrare amschera di login se + già connesso.
            // torna al js un obj 'new Date(xxxxxxxx)'
            var result = new JObject {
				{"usr", JToken.FromObject(usr)},
				{"sys", JToken.FromObject(sysClient)},
				{"token", token},
				{"dtRoles", DataUtils.dataTableToJSon(dtRoles,false,true)},
				{"expiresOn", JsonConvert.SerializeObject(userdata.expiresOn, new JavaScriptDateTimeConverter())}
			};


			// 13. torno risposta al client con token
			return Content(HttpStatusCode.OK, result);

		}

		private byte[] GetObjectToBytes(object obj) {

			byte[] bytes;
			using (var _MemoryStream = new MemoryStream()) {
				IFormatter _BinaryFormatter = new BinaryFormatter();
				_BinaryFormatter.Serialize(_MemoryStream, obj);
				bytes = _MemoryStream.ToArray();
			}

			return bytes;

		}



		/// <summary>
		/// Restituisce un datatable con le righe dei ruoli "flowchart" per l'utente idcustomuser
		/// </summary>
		/// <param name="currdate"></param>
		/// <param name="idcustomuser"></param>
		/// <param name="dispatcher"></param>
		/// <returns></returns>
		private DataTable getRolesDataTable(object currdate, object idcustomuser, Dispatcher dispatcher) {
			var qh = dispatcher.QueryHelper;
			var conn = dispatcher.conn;
			string f1 = qh.AppAnd(qh.CmpEq("U.idcustomuser", idcustomuser),
				qh.NullOrLe("U.start", currdate), qh.NullOrGe("U.stop", currdate));

			f1 = qh.AppAnd(f1, qh.CmpEq("F.ayear", conn.GetSys("esercizio")));

			DataTable T = conn.SQLRunner("select U.idflowchart, isnull(U.title,F.title) as title, " +
										 "U.ndetail from flowchartuser U join " +
										 " flowchart F on U.idflowchart=F.idflowchart where " + f1, true, -1);

			if (T == null) {

				T = conn.SQLRunner("select U.idflowchart, F.title, " +
								   "U.ndetail from flowchartuser U join " +
								   " flowchart F on U.idflowchart=F.idflowchart where " + f1, true, -1);

				T.PrimaryKey = new DataColumn[] { T.Columns["idflowchart"] };

				T.Columns.Add(new DataColumn("k", typeof(String)));
				foreach (DataRow R in T.Rows) {
					R["k"] = R["idflowchart"].ToString() + "§" + R["ndetail"].ToString();
				}
			}
			else {
				T.Columns.Add(new DataColumn("k", typeof(String)));
				foreach (DataRow R in T.Rows) {
					R["k"] = R["idflowchart"].ToString() + "§" + R["ndetail"].ToString();
				}
			}

			T.PrimaryKey = new DataColumn[] { T.Columns["k"] };
			return T;
		}


		/// <summary>
		/// Verifica se l'utente può effettuare il cambio data alla data specificata
		/// </summary>
		/// <param name="DA"></param>
		/// <param name="newDate"></param>
		/// <returns></returns>
		private bool CambioDataConsentita(IDataAccess DA, DateTime newDate) {
			object idcustomuser = DA.Security.GetSys("idcustomuser");
			object ayear = newDate.Year;
			if (idcustomuser == DBNull.Value) return true;
			QueryHelper QHS = DA.GetQueryHelper();
			string filterall = QHS.CmpEq("idcustomuser", idcustomuser);
			if (DA.RUN_SELECT_COUNT("flowchartuser", filterall, false) == 0) return true; //fuori dall'organigramma
			string filteranno = QHS.Like("idflowchart", ayear.ToString().Substring(2) + "%");
			string filterdate = QHS.AppAnd(filterall,
				filteranno,
				QHS.NullOrLe("start", newDate), QHS.NullOrGe("stop", newDate));
			if (DA.RUN_SELECT_COUNT("flowchartuser", filterdate, false) == 0) return false;
			object oggi = DA.DO_SYS_CMD("select getdate()");
			string filternow = QHS.AppAnd(filterall, filteranno,
				QHS.NullOrLe("start", oggi), QHS.NullOrGe("stop", oggi));
			if (DA.RUN_SELECT_COUNT("flowchartuser", filternow, false) == 0) return false;
			return true;
		}

		/// <summary>
		/// Reimposta la password di accesso al servizio.
		/// </summary>
		/// <remarks>
		/// Questo metodo controlla che l'account associato alle credenziali specificate esista e sia stato attivato.
		/// Se la procedura va a buon fine, viene generata una nuova password ed impostata all'account associato
		/// all'indirizzo e-mail specificato. Una e-mail viene inviata all'utente per notificargli la nuova password.
		/// </remarks>
		/// <param name="email">Indirizzo e-mail utilizzato per la registrazione.</param>
		/// <returns>Risultato dell'elaborazione.</returns>
		[HttpGet, Route("resetPassword")]
		public IHttpActionResult resetPassword([Required, EmailAddress] string email) {
			var dispatcher = new Dispatcher();
			dispatcher.createDbConnection();
			var qh = dispatcher.QueryHelper;

			// 1. da virtual user ricerco per mail e recupero username
			string filterVirtualuser = qh.CmpEq("email", email);
			DataTable DT = dispatcher.conn.RUN_SELECT("virtualuser", "*", null, filterVirtualuser, null, false);
			if (DT.Rows.Count > 0) {
				DataRow DR = DT.Rows[0];
				string username = DR["username"].ToString();

				//2. tramite username recupero riga su registryreference, sulla quale dovrò aggiornare nuova pwd

				var dsAnagrafica = new dsmeta_registry_anagrafica();

				var getData = new GetData();
				getData.InitClass(dsAnagrafica, dispatcher.Connection, "registryreference");
				var filterByEmail = qh.CmpEq("userweb", username);
				getData.GET_PRIMARY_TABLE(filterByEmail);

				var referenceRow = dsAnagrafica.registryreference.First();
				if (referenceRow == null) {
					BEError bEError = new BEError();
					bEError.conn = dispatcher.conn;
					bEError.error = "email non presente: " + email;
					bEError.methodInfo = "resetPassword";
					bEError.metadata = "email non presente: " + email;
					DBLogger.log(bEError);
					// per questioni di sicurezza NON dico email non presente! ma confermo comunque invio mail
					return Content(HttpStatusCode.OK, "Invio mail completato.");
				}

				// 3. creo token . inserisco su tabella dei token

				var iterations = DateTime.Now.Millisecond * DateTime.Now.Second + 1;
				var password = KeyChain.generatePassword();
				var salt = KeyChain.generateSalt();
				var hash = Password.generateHash(password, salt, iterations);

				var dsResetPassword = new dsmeta_resetpassword_admin();
				string tname = "resetpassword";
				DataRow dtRow = dsResetPassword.Tables[tname].NewRow();
                dtRow["idreg"] = referenceRow["idreg"];
                dtRow["idregistryreference"] = referenceRow["idregistryreference"];
                dtRow["token"] = hash.toHexString();
				dtRow["date"] = DateTime.Now;
				dtRow["status"] = 0;
				dsResetPassword.Tables[tname].Rows.Add(dtRow);
				var postData = new Easy_PostData();
				postData.initClass(dsResetPassword, dispatcher.Connection);

				var pmc = postData.DO_POST_SERVICE();

				if (pmc.Count > 0) {

					string error = "";
					foreach (EasyProcedureMessage pm in pmc) {
						if (pm.LongMess != null) {
							error = error + pm.LongMess + " ";
						}
					}

					BEError bEError = new BEError();
					bEError.conn = dispatcher.conn;
					bEError.error = error;
					bEError.methodInfo = "resetPassword";
					bEError.metadata = "email: " + email;
					DBLogger.log(bEError);

					return Content(HttpStatusCode.InternalServerError, "Errore del server dati. " + error);
				}

				// 4. preparo link ed invio mail
				try {
					String parameters = "?redirect=n&tokenresetpwd=" + hash.toHexString();
					var frontendSSO = WebConfigurationManager.AppSettings.Get("frontendSSO") + parameters;
					sendEmail(email, frontendSSO);
				}
				catch (Exception ex) {
#if DEBUG
					Debug.WriteLine(ex.Message);
					Debug.WriteLine(ex.StackTrace);

					if (ex.InnerException != null) {
						Debug.WriteLine(ex.InnerException.Message);
						Debug.WriteLine(ex.InnerException.StackTrace);
					}
#endif
					BEError bEError = new BEError();
					bEError.conn = dispatcher.conn;
					bEError.error = ex.StackTrace;
					bEError.methodInfo = "resetPassword";
					bEError.metadata = ex.Message;
					DBLogger.log(bEError);
					return Content(HttpStatusCode.InternalServerError, "Invio dell'e-mail di attivazione fallito.");
				}
			}

			// se non trovo mail, mando ad ogni modo messaggio. per sicurezza non possiamo dire mail non esistente
			return Content(HttpStatusCode.OK, "Invio mail completato");
		}

		private void sendEmail(string email, string link) {

			string smtpserver = WebConfigurationManager.AppSettings["smtpserver"];
			int smtpport = Convert.ToInt32(WebConfigurationManager.AppSettings["smtpport"]);
			string smtpuser = WebConfigurationManager.AppSettings["smtpuser"];
			string smtppwd = WebConfigurationManager.AppSettings["smtppwd"];
			if (!string.IsNullOrWhiteSpace(smtppwd))
			{
				SystemConfig systemConfig = Security.Token.decodeSystemConfig(smtppwd);
				smtppwd = systemConfig.password;
			}

			BodyBuilder builder = new BodyBuilder();
			MimeMessage mail = new MimeMessage();
			mail.From.Add(new MailboxAddress("", smtpuser));
			mail.To.Add(new MailboxAddress("", email));
			mail.Subject = "Portale - crea Nuova Password";
			builder.HtmlBody = "<html><body><p>Hai richiesto il reset della password per Portale</p><br>";
			builder.HtmlBody = "<p>Per eseguire il reset della password vai al seguente link: </p><a href=\" " + link + "\">Crea nuova password</a>";
			builder.HtmlBody += "</body></html>";
			mail.Body = builder.ToMessageBody();

			using (var client = new SmtpClient()) {
				SecureSocketOptions useSsl = SecureSocketOptions.Auto;
				if (smtpport == 25) {
					useSsl = SecureSocketOptions.None;
				}
				client.Connect(smtpserver, smtpport, useSsl);
				client.AuthenticationMechanisms.Remove("XOAUTH2");
                if (!string.IsNullOrWhiteSpace(smtppwd))
                    client.Authenticate(smtpuser, smtppwd);
				client.Send(mail);
				client.Disconnect(true);
			}
		}

		[HttpGet, Route("nuovaPassword")]
		public IHttpActionResult nuovaPassword([Required] string token, [Required] string password) {
			var dispatcher = new Dispatcher();
			dispatcher.createDbConnection();
			var dsResetPassword = new dsmeta_resetpassword_admin();
			string tname = "resetpassword";
			var qh = dispatcher.QueryHelper;

			// recupero riga da tabella del resetpassword
			var getData = new GetData();
			getData.InitClass(dsResetPassword, dispatcher.Connection, tname);
			var filterByToken = qh.AppAnd(
				qh.CmpEq("token", token),
				qh.CmpEq("status", 0));
			getData.GET_PRIMARY_TABLE(filterByToken);
			var resetPasswordRow = dsResetPassword.resetpassword.First();
			if (resetPasswordRow == null) {
				return Content(HttpStatusCode.BadRequest, "token non valido, oppure potrebbe essere scaduto");
			}

			// check su scadenza del token
			DateTime date = (DateTime)resetPasswordRow["date"];
			DateTime now = DateTime.Now;
			int diff = (now - date).Minutes;
			if (diff > 15) {
				return Content(HttpStatusCode.BadRequest, "token non valido, oppure potrebbe essere scaduto");
			}

			// GENERO NUOVA PASSWORD  salvo su registryreference
			Random rnd = new Random();
			var iterations = rnd.Next(20, 100);
			var salt = KeyChain.generateSalt();
			var hash = Password.generateHash(password, salt, iterations);


			// aggiorno lo stato del token
			string[] cols = new string[] { "status" };
			object[] values = new object[] { 1 };
			MetaExpression metaFilterByToken = MetaExpression.and(
			   MetaExpression.eq("token", token),
			   MetaExpression.eq("status", 0));
			string lastError = dispatcher.conn.doUpdate("resetpassword", metaFilterByToken, cols, values);
			if (!String.IsNullOrEmpty(lastError)) {
				return Content(HttpStatusCode.InternalServerError, "Errore salvataggio nuova password");
			}

			// aggiorno la password
			cols = new string[] { "iterweb", "saltweb", "passwordweb" };
			values = new object[] { iterations, salt.toHexString(), hash.toHexString() };
			MetaExpression metaFilterByIdreference = 
				MetaExpression.and(
                    MetaExpression.eq("idregistryreference", (int)resetPasswordRow["idregistryreference"]),
                    MetaExpression.eq("idreg", (int)resetPasswordRow["idreg"])
					);
            lastError = dispatcher.conn.doUpdate("registryreference", metaFilterByIdreference, cols, values);

            if (!String.IsNullOrEmpty(lastError)) {
                BEError bEError = new BEError();
                bEError.conn = dispatcher.Connection;
                bEError.error = "Pasword reset fallito";
                bEError.methodInfo = "nuovaPassword";
                bEError.metadata = "esercizio: " + dispatcher.Connection.Security.GetSys("esercizio") + ", idreg: " +
                    resetPasswordRow["idreg"] + ", idcustomuser: " + dispatcher.Connection.Security.GetSys("idcustomuser");
                DBLogger.log(bEError);

                return Content(HttpStatusCode.InternalServerError, "Errore salvataggio nuova password");

			}
            BEError bEErrorOK = new BEError();
            bEErrorOK.conn = dispatcher.Connection;
            bEErrorOK.error = "Pasword reset avvenuto con successo";
            bEErrorOK.methodInfo = "nuovaPassword";
            bEErrorOK.metadata = "esercizio: " + dispatcher.Connection.Security.GetSys("esercizio") + ", idreg: " +
                resetPasswordRow["idreg"] + ", idcustomuser: " + dispatcher.Connection.Security.GetSys("idcustomuser");
            DBLogger.log(bEErrorOK);

            return Content(HttpStatusCode.Created, "Password cambiata correttamente");
		}

		//#if DEBUG

		/// <summary>
		/// Ritorna le informazioni relative all'identità dell'utente.
		/// </summary>
		/// <remarks>
		/// Usare questo metodo esclusivamente per operazioni di debug. Il token restituito dal metodo
		/// <see cref="login"/> è decodificabile dal client.
		/// </remarks>
		/// <returns>Le informazioni contenute nel token di autenticazione.</returns>
		[HttpPost, Route("user"), Authorize]
		public IHttpActionResult userData() {
			return Content(HttpStatusCode.OK, User.Identity);
		}

		//#endif

	}

	/// <summary>
	/// Controller per test
	/// </summary>
	[RoutePrefix("static"), AllowAnonymous, EnableCors("*", "*", "*")]
	public class TestController : ApiController {

		/// <summary>
		/// Invia un file avente un dato nome
		/// </summary>
		/// <param name="fileName"></param>
		/// <returns></returns>
		[HttpGet, Route("send/{fileName}")]
		public HttpResponseMessage serveFile(string fileName) {
			var folder = HttpContext.Current.Server.MapPath("~/folder/");
			var path = Path.Combine(folder, fileName);

			HttpResponseMessage result = new HttpResponseMessage(HttpStatusCode.OK);
			var stream = new FileStream(path, FileMode.Open, FileAccess.Read);
			result.Content = new StreamContent(stream);
			result.Content.Headers.ContentType =
				new MediaTypeHeaderValue("text/html");
			return result;

		}

		/// <summary>
		/// Controller che prende in input un oggetto json e lo converte in stringa
		/// </summary>
		/// <remarks>       
		/// Deserializzazione di un oggetto json
		/// </remarks>       
		/// <returns>ritorna una stringa</returns>        
		[HttpPost, Route("Deserialize")]
		public IHttpActionResult test_DeSerialize([FromBody] JObject o) {
			return Content(HttpStatusCode.OK, new DataSet().deSerializeData(o));
		}

		/// <summary>
		/// Controller che legge dati dal dataset e li restituisce in formato json alla richiesta
		/// </summary>
		/// <remarks>       
		/// Lettura da Dataset e serializzazione risultato in formato json
		/// </remarks>       
		/// <returns>Righe lette dal dataset in formato json</returns>        
		[HttpPost, Route("read")]
		public IHttpActionResult test_read() {


			var dispatcher = HttpContext.Current.getDataDispatcher();

			var ds1 = new dsmeta_registry_anagrafica();
			var getData = new GetData();

			getData.InitClass(ds1, dispatcher.Connection, "registryreference");
			var filterByEmail = dispatcher.QueryHelper.CmpEq("cu", "assistenza");
			getData.GET_PRIMARY_TABLE(filterByEmail);

			var datat = ds1.registryreference;
			var r = datat[0];
			r["flagdefault"] = "N";
			r["referencename"] = "Luigi";

			//AGGIUNGO UNA NUOVA RIGA ALLA TABELLA 

			DataRow row = datat.NewRow();

			row["idreg"] = 10000;
			row["idregistryreference"] = 100;
			row["cu"] = "assistenza";
			datat.Rows.Add(row);


			//RIMUOVO UNA RIGA DALLA TABELLA
			datat.Rows[2].Delete();


			//stringa in formato json contenente le righe del dataset

			var json = ds1.backupData();
			//var x = JsonConvert.SerializeObject(ds1);
			string x = json.ToString();

			//ora posso richiamare una funzione che mi deserializza la striga json, posso restituire il risultato in base ad un input

			var result = ds1.deSerializeData(json);

			var y = JsonConvert.DeserializeObject(result);



			return Content(HttpStatusCode.OK, y);

		}

	}

}
