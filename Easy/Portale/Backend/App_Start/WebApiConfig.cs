
/*
Easy
Copyright (C) 2022 Università degli Studi di Catania (www.unict.it)
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
using Backend.Security;
using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Configuration;
using System.Web.Http;
using System.Web.Http.Filters;
using System.Web.Http.Controllers;
using System.Linq;
using System.Net.Http;
using Backend.Extensions;
using metaeasylibrary;
using System.Collections;
using Backend.Data;
using System.Data;
using metadatalibrary;
using System.Collections.Generic;

namespace Backend {

    /// <summary>
    /// 
    /// </summary>

    public static class LoginFailedStatus
    {
        public const string NoCredential = "NoCredential";
        public const string ExpiredCredentialSSO = "ExpiredCredentialSSO";
        public const string ExpiredCredential = "ExpiredCredential";
        public const string ExpiredSession = "ExpiredSession";
        public const string BadCredential = "BadCredential";
        public const string DataNotPermitted = "DataNotPermitted";
        public const string TokenEmpty = "TokenEmpty";
        public const string UserNotSecurity = "UserNotSecurity";
        public const string DataContabileMissing = "DataContabileMissing";
        public const string AnonymousNotPermitted = "AnonymousNotPermitted";
        public const string FilterWithUndefined = "FilterWithUndefined";
    }

    /// <summary>
    /// Configurazione del servizio web.
    /// </summary>
    public static class WebApiConfig {

        /// <summary>
        /// Configura il servizio web.
        /// </summary>
        /// <param name="config">Configurazione del servizio</param>
        public static void register(HttpConfiguration config) {
            // Web API configuration and services
            //Disable IIS authentication in order to use token based authentication
            config.SuppressHostPrincipal();

            config.Filters.Add(new EasyAuthenticationFilter());
            config.Filters.Add(new ModelValidationFilter());

            //Enable Cross Origin Resource Sharing. Using CORS, a server can explicitly allow some cross-origin requests while rejecting others. 
            config.EnableCors();

            // Web API routes
            config.MapHttpAttributeRoutes();    //attiva il routing tramite gli attributi 

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );


            //Di questo non c'è bisogno se si usa il routing tramite gli attributi   (attributi Route dei controllers)
            // config.Routes.MapHttpRoute(
            //    name: "Default",
            //    routeTemplate: "static/{filename}",
            //    defaults: new {
            //        controller = "TestController",
            //        action = "servefile",
            //    }
            //);

           
            var dispatcher = new Dispatcher();
            dispatcher.createPoolConnection();
            dispatcher.createDbConnection();
            IEasyDataAccess usrConn = dispatcher.conn;
            //----> DECOMMENTARE IN PROD. Operazione lenta. in sviluppo viene calcolata man mano
            // viene cachata ogni volta sulla release della connessione nel pool
            //----> usrConn.readStructuresFromDb();
            var dbs = usrConn.getStructures();
            CacheMDLW.dbStructureCache = dbs;

            // popola le strutture dati per i metadati gestiti centralizzati da portale
            CacheMDLW.manageMetaDataPortaleCache(usrConn);
         
        }

    }

    /// <summary>
    /// Filtro per l'autenticazione personalizzata di Easy.
    /// </summary>
    public class EasyAuthenticationFilter : IAuthenticationFilter {

        /// <summary>
        /// Indica se è possibile avere più istanze del filtro nella stessa applicazione.
        /// </summary>
        public bool AllowMultiple { get { return false; } }

        /// <summary>
        /// Gestisce l'autenticazione.
        /// </summary>
        /// <param name="context">Contesto dell'autenticazione HTTP.</param>
        /// <param name="cancellationToken">Token per l'annullamento del thread.</param>
        /// <returns>Task nullo.</returns>
        public Task AuthenticateAsync(HttpAuthenticationContext context, CancellationToken cancellationToken) {
            var requestMessage = context.Request;
           
            //Authorization header value, must contain a Bearer scheme
            var authorization = requestMessage.Headers.Authorization;
            if (authorization == null || 
                !authorization.Scheme.Equals("Bearer", StringComparison.OrdinalIgnoreCase) || 
                string.IsNullOrEmpty(authorization.Parameter)) {
                if (authorization != null && string.IsNullOrEmpty(authorization.Parameter)) {
                    context.ErrorResult = requestMessage.actionResult(HttpStatusCode.Unauthorized, LoginFailedStatus.TokenEmpty);
                }
                return Task.FromResult(0);
            }
           
            var requestContext = requestMessage.Properties["MS_HttpContext"] as HttpContextWrapper;
            // nella decode del token osservo se si tratta di connessione anonima.
            var identity = Security.Token.decode(authorization.Parameter, requestContext);
               
            if (identity == null) {
                context.ErrorResult = requestMessage.actionResult(HttpStatusCode.Unauthorized,  LoginFailedStatus.NoCredential );
                return Task.FromResult(0);
            }

            //Check token expiration
            if (identity.expiresOn < DateTime.Now) {
                context.ErrorResult = requestMessage.actionResult(HttpStatusCode.Unauthorized, LoginFailedStatus.ExpiredCredential); 
                return Task.FromResult(0);
            }
            //Check token validity
            if (!identity.clientAddress.Equals(requestContext.Request.UserHostAddress)) {
                context.ErrorResult = requestMessage.actionResult(HttpStatusCode.Unauthorized, LoginFailedStatus.BadCredential);
                return Task.FromResult(0);
            }

            // recuperare il guid per la sessione e  popolare le var di ambiente 
            // a partire dalla cache. Troverò qui anche idreg, aggiunta in fase di login
            var gsession = identity.guidsession;
            var sessionInfo = SessionMDLW.getAndUseSessionFromGuid(gsession);

            if (sessionInfo == null && !identity.IsAnonymous) {
                context.ErrorResult = requestMessage.actionResult(HttpStatusCode.Unauthorized, LoginFailedStatus.ExpiredSession);
                return Task.FromResult(0);
            }

            // 1. prendo connessione di sistema
            var dispatcher = new Dispatcher();
            dispatcher.createDbConnection();
            IEasyDataAccess conn = dispatcher.conn;

            // 2. imposto sicurezza
            EasySecurity sec = conn.Security as EasySecurity;

            // cicla e popola sec.usr e sec.sys solo se esiste un sessionInfo
            if (sessionInfo != null) {
                foreach (DictionaryEntry pair in sessionInfo.sys) {
                    sec.SetSys(pair.Key.ToString(), pair.Value);
                }

                foreach (DictionaryEntry pair in sessionInfo.usr) {
                    sec.SetUsr(pair.Key.ToString(), pair.Value);
                }

                // leggo da cache sessione il GroupOperations che è preso dalla cache e lo applico alla sicurezza
                sec.groupOperations = CacheMDLW.getGroupOperations(sessionInfo.sys_user);
            }

            // set della var anonymous. dovrò configurare su user e flowchart un identity.Name = Security.Role.Anonymous
            sec.SetUsr("anonymous", identity.IsAnonymous);
                                    
            // 3. salvo sul contesto http il dispatcher per la connessione, così lo posso utilizzare per la logica di business del metodo
            HttpContext.Current.Items["DataDispatcher"] = dispatcher;
            HttpContext.Current.Items["SessionInfo"] = sessionInfo;
            HttpContext.Current.Items["Identity"] = identity;

            context.Principal = new Principal(identity);

            // lancio check per la pulizia dei sessionInfo
            SessionMDLW.cleanSession();
                    
            return Task.FromResult(0);
        }

        /// <summary>
        /// Contesta la richiesta se l'autenticazione non è stata completata correttamente. 
        /// </summary>
        /// <param name="context">Contesto dell'autenticazione HTTP.</param>
        /// <param name="cancellationToken">Token per l'annullamento del thread.</param>
        /// <returns>Task nullo.</returns>
        public Task ChallengeAsync(HttpAuthenticationChallengeContext context, CancellationToken cancellationToken) {
            context.Result = context.Result.challengeResult();
            return Task.FromResult(0);
        }

    }

    /// <summary>
    /// Filtro per la validazione statica dello stato del modello dati.
    /// </summary>
    public class ModelValidationFilter : ActionFilterAttribute {

        /// <summary>
        /// Prima di eseguire l'azione definita dal controller, controlla lo stato del modello dati.
        /// </summary>
        /// <param name="context"></param>
        public override void OnActionExecuting(HttpActionContext context) {
            var modelState = context.ModelState;
            if (!modelState.IsValid) {
                var firstState = modelState.Values.First();
                var firstError = firstState.Errors.First();

                context.Response = context.Request.CreateErrorResponse(HttpStatusCode.BadRequest, firstError.ErrorMessage);
            }
        }

    }

    /// <summary>
    /// Modulo per la gestione del dispatcher dei dati nel contesto della richiesta HTTP.
    /// </summary>
    public class DataModule : IHttpModule {

        /// <summary>
        /// Rilascia le risorse gestite dal modulo.
        /// </summary>
        public void Dispose() { }

        /// <summary>
        /// Inizializza il modulo.
        /// </summary>
        /// <param name="context">Applicazione HTTP.</param>
        public void Init(HttpApplication context) {
            context.BeginRequest += Context_BeginRequest;
            context.EndRequest += Context_EndRequest;
        }

        /// <summary>
        /// Gestisce l'evento di apertura di una richiesta HTTP.
        /// </summary>
        /// <param name="sender">Istanza dell'applicazione HTTP.</param>
        /// <param name="e">Argomenti dell'evento.</param>
        private void Context_BeginRequest(object sender, EventArgs e) {

            // DEPRECATO non lo fa più qua, ma sulla login , calcola la sicurezza e mette sul token i prm nDetail e idflowChart

          /*  var dispatcher = new Dispatcher(
                    "EasyPay",
                    WebConfigurationManager.AppSettings["DBServer"],
                    WebConfigurationManager.AppSettings["DBName"],
                    WebConfigurationManager.AppSettings["DBUser"],
                    WebConfigurationManager.AppSettings["DBPassword"],
                    DateTime.Now.Year,
                    DateTime.Now
            );

            HttpContext.Current.Items["DataDispatcher"] = dispatcher;
            */
        }

        /// <summary>
        /// Gestisce l'evento di chiusura di una richiesta HTTP.
        /// </summary>
        /// <param name="sender">Istanza dell'applicazione HTTP.</param>
        /// <param name="e">Argomenti dell'evento.</param>
        private void Context_EndRequest(object sender, EventArgs e) {
           
            var dispatcher = HttpContext.Current.Items["DataDispatcher"] as Dispatcher;

            if (dispatcher != null) {
                HttpContext.Current.Items.Remove(dispatcher);

                dispatcher.Dispose();
            }

            dispatcher = null;
            
        }

    }

}
