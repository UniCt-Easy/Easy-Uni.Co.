
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


using System.Net;
using System.Web.Http;
using System.Web.Http.Cors;
using Backend.CommonBackend;
using System;
using System.Data;
using Backend.Security;
using System.Web.Configuration;
using Newtonsoft.Json.Linq;
using metaeasylibrary;
using q = metadatalibrary.MetaExpression;
using Newtonsoft.Json;
using metadatalibrary;
using System.Collections.Generic;
using System.Web;
using Backend.Models;
using System.Linq;
using Backend.Extensions;
using Microsoft.Win32;
using System.IO;
using System.Globalization;

namespace Backend.Controllers
{

    /// <summary>
    /// Controller contenente le primitive necessarie per la gestione delle funzioni di admin
    /// </summary>
    /// <remarks>
    /// Il percorso (URL) per accedere ai metodi contenuti in questo controller devono avere il prefisso "/admin".
    /// </remarks>
    [RoutePrefix("besmart"), AllowAnonymous, EnableCors("*", "*", "*")]
    public class BesmartController : ApiController {

        /// <summary>
        /// Parametri della chiamata
        /// </summary>
        public class getProjectWorkpackagePrms {
            /// <summary>
            /// anno solare
            /// </summary>
            public string anno { get; set; }
            /// <summary>
            /// Codice fiscale
            /// </summary>
            public string codiceFiscale { get; set; }
            /// <summary>
            /// Username
            /// </summary>
            public string username { get; set; }
            /// <summary>
            /// Password
            /// </summary>
            public string password { get; set; }

        }

        public static void info(string s)
        {
            try { System.IO.File.AppendAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "__log.txt"), DateTime.Now.ToString("yy-MM-dd hh:mm:ss") + " - " + s + "\r\n\r\n"); } catch { }
        }

        /// <summary>
        /// Rendicontazione Docenti
        /// </summary>
        /// <param name="rd"></param>
        /// <returns></returns>
        [HttpPost, Route("rendicontadocenti")]
        public IHttpActionResult rendicontaDocenti(List<RendicontazioneDocente> rendicontazioneDocenteList)
        {
            // Prendo il token dall'header della chiamata
            string token = HttpContext.Current.Request.Headers["token"].ToString();

            // Se Esiste
            if (string.IsNullOrEmpty(token))
				return Content(HttpStatusCode.OK, "Missing Token");

			// Controllo sia stata creata la cache
			if (!memCache._authCache.Any())
				return Content(HttpStatusCode.Unauthorized, LoginFailedStatus.BadCredential);

            //  Controllo esista il token
			if (memCache._authCache.Get(token) == null)
				return Content(HttpStatusCode.Unauthorized, LoginFailedStatus.BadCredential);

            // Controllo il token non sia scaduto
			if (string.IsNullOrEmpty(memCache._authCache.Get(token).ToString()))
				return Content(HttpStatusCode.Unauthorized, LoginFailedStatus.BadCredential);

            // Creo la connessione
			var dispatcher = new Dispatcher();
			dispatcher.createDbConnection();
			IEasyDataAccess conn = dispatcher.conn;

			if (rendicontazioneDocenteList == null)
				return Content(HttpStatusCode.OK, "No Data");

			if (rendicontazioneDocenteList.Count == 0)
				return Content(HttpStatusCode.OK, "No Data");

            info($"rendicontaDocenti\r\nJson: {JsonConvert.SerializeObject(rendicontazioneDocenteList)}");

            string error = "";

            int docenti = rendicontazioneDocenteList.Count;
			int docentiFound = 0;

			// Rendicontazioni ricevute
			foreach (RendicontazioneDocente rendicontazioneDocente in rendicontazioneDocenteList)
            {
                // Codice Fiscale
                string CF = rendicontazioneDocente.docente.codiceFiscale;

                // Controllo la lunghezza
				if (CF.Length != 16)
                {
					error += $" - Docente con CF '{CF}' not valid\r\n";
                }
                else
                {
                    // Docente con quel CF
					int idreg = GetIdRegDocente(conn, CF);

                    // Se l'ho trovato
                    if (idreg > 0)
                    {
                        bool isOk = true;

                        // ============================================================================================================
                        // Check stringhe non troppo lunghe
                        // ============================================================================================================
                        foreach (DidatticaFrontale df in rendicontazioneDocente.didatticheFrontali)
                        {
                            if (df.erogazioneDescrizione.Length > 4000)
                            {
                                error += $" - CF '{CF}': didatticheFrontali.erogazioneDescrizione too long (max 4000 char)\r\n";
                                isOk = false;
                            }
                        }

                        // Salvo le didattiche integrative
                        foreach (Erogazione di in rendicontazioneDocente.didatticheIntegrative)
                        {
                            if (di.erogazioneTipoAttivita.Length > 128) { 
                                error += $" - CF '{CF}': didatticheIntegrative.erogazioneTipoAttivita too long (max 128 char)\r\n";
                                isOk = false;
                            }
                        }

                        // Salvo le didattiche altre attività
                        foreach (Erogazione di in rendicontazioneDocente.altreAttivita)
                        {
                            if (di.erogazioneTipoAttivita.Length > 128) { 
                                error += $" - CF '{CF}': altreAttivita.erogazioneTipoAttivita too long (max 128 char)\r\n";
                                isOk = false;
                            }
                        }

                        // Check
                        if (isOk)
                        {
                            // ============================================================================================================
                            // Inserisco le didattiche
                            // ============================================================================================================
                            docentiFound++;

                            // Salvo le didattiche frontati
                            foreach (DidatticaFrontale df in rendicontazioneDocente.didatticheFrontali)
                            {
                                string result = AddDidatticaFrontale(conn, df, idreg);

                                if (result != "")
                                    error += $" - Errore di inserimento Didattica Frontale, CF: {CF}, Data: {df.erogazioneDataOraInizio}-{df.erogazioneDataOraFine}. Errore: {result}\r\n";
                            }

                            // Salvo le didattiche integrative
                            foreach (Erogazione di in rendicontazioneDocente.didatticheIntegrative)
                            {
                                string result = AddErogazione(conn, di, idreg);

                                if (result != "")
                                    error += $" - Errore di inserimento Didattica Integrativa, CF: {CF}, Data: {di.erogazioneData}, Ore: {di.erogazioneOreComplessive}. Errore: {result}\r\n";
                            }

                            // Salvo le didattiche altre attività
                            foreach (Erogazione di in rendicontazioneDocente.altreAttivita)
                            {
                                string result = AddErogazione(conn, di, idreg);

                                if (result != "")
                                    error += $" - Errore di inserimento Altre attività, CF: {CF}, Data: {di.erogazioneData}, Ore: {di.erogazioneOreComplessive}. Errore: {result}\r\n";
                            }
                        }
                    }
                    else
                    {
                        error += $" - Docente con CF '{CF}' inesistente\r\n";
                    }
				}
			}

            if (docentiFound < docenti)
			    error += $" - Docenti elaborati: {docentiFound} di {docenti}\r\n";

			if (!string.IsNullOrEmpty(error))
				return Content(HttpStatusCode.OK, error);

			return Content(HttpStatusCode.OK, "OK");
        }

        /// <summary>
        /// Rendicontazione Docenti
        /// </summary>
        /// <param name="rd"></param>
        /// <returns></returns>
        [HttpPost, Route("eliminarendicontadocenti")]
        public IHttpActionResult eliminaRendicontaDocenti(List<EliminaRendicontazioneDocente> eliminaRendicontazioneDocenteList)
        {
            // Prendo il token dall'header della chiamata
            string token = HttpContext.Current.Request.Headers["token"].ToString();

            // Se Esiste
            if (string.IsNullOrEmpty(token))
                return Content(HttpStatusCode.OK, "Missing Token");

            // Controllo sia stata creata la cache
            if (!memCache._authCache.Any())
                return Content(HttpStatusCode.Unauthorized, LoginFailedStatus.BadCredential);

            //  Controllo esista il token
            if (memCache._authCache.Get(token) == null)
                return Content(HttpStatusCode.Unauthorized, LoginFailedStatus.BadCredential);

            // Controllo il token non sia scaduto
            if (string.IsNullOrEmpty(memCache._authCache.Get(token).ToString()))
                return Content(HttpStatusCode.Unauthorized, LoginFailedStatus.BadCredential);

            // Creo la connessione
            var dispatcher = new Dispatcher();
            dispatcher.createDbConnection();
            IEasyDataAccess conn = dispatcher.conn;

            if (eliminaRendicontazioneDocenteList == null)
                return Content(HttpStatusCode.OK, "No Data");

            if (eliminaRendicontazioneDocenteList.Count == 0)
                return Content(HttpStatusCode.OK, "No Data");

            info($"eliminaRendicontazioneDocenti\r\nJson: {JsonConvert.SerializeObject(eliminaRendicontazioneDocenteList)}");

            string error = "";

            int docenti = eliminaRendicontazioneDocenteList.Count;
            int docentiFound = 0;

            // Rendicontazioni ricevute
            foreach (EliminaRendicontazioneDocente eliminaRendicontazioneDocente in eliminaRendicontazioneDocenteList)
            {
                // Codice Fiscale
                string CF = eliminaRendicontazioneDocente.docente.codiceFiscale;

                // Controllo la lunghezza
                if (CF.Length != 16)
                {
                    error += $" - Docente con CF '{CF}' not valid\r\n";
                }
                else
                {
                    // Docente con quel CF
                    int idreg = GetIdRegDocente(conn, CF);

                    // Se l'ho trovato
                    if (idreg > 0)
                    {
                        // ============================================================================================================
                        // Elimino le didattiche
                        // ============================================================================================================
                        docentiFound++;

                        // Salvo le didattiche frontati
                        foreach (DelDidatticaFrontale df in eliminaRendicontazioneDocente.didatticheFrontali)
                        {
                            string result = DelDidatticaFrontale(conn, df, idreg);

                            if (result != "")
                                error += $" - Errore di eliminazione Didattica Frontale, CF: {CF}, Data: {df.erogazioneDataOraInizio}-{df.erogazioneDataOraFine}. Errore: {result}\r\n";
                        }

                        // Salvo le didattiche integrative
                        foreach (DelErogazione di in eliminaRendicontazioneDocente.didatticheIntegrative)
                        {
                            string result = DelErogazione(conn, di, idreg);

                            if (result != "")
                                error += $" - Errore di eliminazione Didattica Integrativa, CF: {CF}, Data: {di.erogazioneData}, Ore: {di.erogazioneOreComplessive}. Errore: {result}\r\n";
                        }

                        // Salvo le didattiche altre attività
                        foreach (DelErogazione di in eliminaRendicontazioneDocente.altreAttivita)
                        {
                            string result = DelErogazione(conn, di, idreg);

                            if (result != "")
                                error += $" - Errore di eliminazione Altre attività, CF: {CF}, Data: {di.erogazioneData}, Ore: {di.erogazioneOreComplessive}. Errore: {result}\r\n";
                        }
                    }
                    else
                    {
                        error += $" - Docente con CF '{CF}' inesistente\r\n";
                    }
                }
            }

            if (docentiFound < docenti)
                error += $" - Docenti elaborati: {docentiFound} di {docenti}\r\n";

            if (!string.IsNullOrEmpty(error))
                return Content(HttpStatusCode.OK, error);

            return Content(HttpStatusCode.OK, "OK");
        }

        private string AddDidatticaFrontale(IDataAccess conn, DidatticaFrontale df, int idreg)
        {
            try
            {
                // Dati Didattica Frontale
                string title = df.erogazioneDescrizione;
                int idsede = GetSede(conn, df.erogazioneLuogo, idreg);                

                DateTime.TryParse(df.erogazioneDataOraInizio, out DateTime start);
                DateTime.TryParse(df.erogazioneDataOraFine, out DateTime stop);

                // Controllo che non sia già stata inserita
                string qry = string.Format(CountRendicontdidattica, start.ToString("dd/MM/yyyy HH:mm:ss"), stop.ToString("dd/MM/yyyy HH:mm:ss"), idreg);
                DataTable count = conn.SQLRunner(qry);
                int cnt = 0;
                if (count.Rows.Count > 0)
                    int.TryParse(count.Rows[0][0].ToString(), out cnt);

                // Se è stata già inserita restituisco errore
                if (cnt != 0)
                    return "già inserita";

                // Se non è stata già inserita la inserisco
                qry = string.Format(InsRendicontdidattica, start.ToString("dd/MM/yyyy HH:mm:ss"), stop.ToString("dd/MM/yyyy HH:mm:ss"), title, idreg, idsede);
                conn.SQLRunner(qry);
            }
            catch (Exception Ex)
            {
                return Ex.Message;
            }

            return "";
        }

        private string AddErogazione(IDataAccess conn, Erogazione di, int idreg)
        {
            try
            {
                // Dati Erogazione
                DateTime.TryParse(di.erogazioneData, out DateTime dataErogazione);

                string aa = GetAa(dataErogazione);
                int ore = di.erogazioneOreComplessive;
                int idrendicontaltrokind = GetRendicontAltroKind(conn, di.erogazioneTipoAttivita);

                // Controllo che non sia già stata inserita
                string qry = string.Format(CountRendicontaltro, aa, idreg, dataErogazione.ToString("dd/MM/yyyy HH:mm:ss"), idrendicontaltrokind);
                DataTable count = conn.SQLRunner(qry);
                int cnt = 0;
                if (count.Rows.Count > 0)
                    int.TryParse(count.Rows[0][0].ToString(), out cnt);

                // Se è stata già inserita restituisco errore
                if (cnt != 0)
                    return "già inserita";

                // Se non è stata già inserita la inserisco
                qry = string.Format(InsRendicontaltro, aa, idreg, dataErogazione, idrendicontaltrokind, ore);
                conn.SQLRunner(qry);
            }
            catch (Exception Ex)
            {
                return Ex.Message;
            }

            return "";
        }

        private string DelDidatticaFrontale(IDataAccess conn, DelDidatticaFrontale df, int idreg)
        {
            try
            {
                // Dati Didattica Frontale
                DateTime.TryParse(df.erogazioneDataOraInizio, out DateTime start);
                DateTime.TryParse(df.erogazioneDataOraFine, out DateTime stop);

                // Controllo che non sia già stata inserita
                string qry = string.Format(CountRendicontdidattica, start.ToString("dd/MM/yyyy HH:mm:ss"), stop.ToString("dd/MM/yyyy HH:mm:ss"), idreg);
                DataTable count = conn.SQLRunner(qry);
                int cnt = 0;
                if (count.Rows.Count > 0)
                    int.TryParse(count.Rows[0][0].ToString(), out cnt);

                // Non esiste restituisco errore
                if (cnt == 0)
                    return "inesistente";

                // Se esiste la elimino
                qry = string.Format(DelRendicontdidattica, idreg, start.ToString("dd/MM/yyyy HH:mm:ss"), stop.ToString("dd/MM/yyyy HH:mm:ss"));
                conn.SQLRunner(qry);
            }
            catch (Exception Ex)
            {
                return Ex.Message;
            }

            return "";
        }

        private string DelErogazione(IDataAccess conn, DelErogazione di, int idreg)
        {
            try
            {
                // Dati Erogazione
                DateTime.TryParse(di.erogazioneData, out DateTime dataErogazione);

                string aa = GetAa(dataErogazione);
                int ore = di.erogazioneOreComplessive;

                // Controllo che esista
                string qry = string.Format(CountDelRendicontaltro, aa, idreg, dataErogazione.ToString("dd/MM/yyyy HH:mm:ss"));
                DataTable count = conn.SQLRunner(qry);
                int cnt = 0;
                if (count.Rows.Count > 0)
                    int.TryParse(count.Rows[0][0].ToString(), out cnt);

                // Non esiste restituisco errore
                if (cnt == 0)
                    return "inesistente";

                // Se esiste la elimino
                qry = string.Format(DelRendicontaltro, idreg, dataErogazione, ore);
                conn.SQLRunner(qry);
            }
            catch (Exception Ex)
            {
                return Ex.Message;
            }

            return "";
        }

        private string GetAa(DateTime dataErogazione)
		{
			// Ricavo anno solare attuale: dal 1 gen al 31 set = anno corrente, altrimenti anno corrente + 1
			int anno = dataErogazione.Year;
			DateTime primoOttobre = new DateTime(dataErogazione.Year, 10, 1);

			if (dataErogazione < primoOttobre)
				anno--;

            return $"{anno}/{anno + 1}";
		}

		private int GetIdRegDocente(IDataAccess conn, string CF)
        {
			return (int)(conn.DO_READ_VALUE("registry", $"cf='{CF}'", "idreg") ?? 0);
		}

		private int GetSede(IDataAccess conn, ErogazioneLuogo erogazioneLuogo, int idreg)
		{
            int idsede = (int)(conn.DO_READ_VALUE("sede", $"title = '{erogazioneLuogo.luogoNome}'", "idsede") ?? 0);

            if (idsede == 0)
            {
                
                int idcity = 0;
                string cap = "";
				string title = "";

				if (!string.IsNullOrEmpty(erogazioneLuogo.luogoNome))
				{
					DataTable geo = conn.SQLRunner($"select idcity, cap, title from geo_city_codeview where title = '{erogazioneLuogo.luogoNome}'");
					if (geo.Rows.Count > 0)
					{
						idcity = (int)geo.Rows[0][0];
						cap = geo.Rows[0][1].ToString();
						title = geo.Rows[0][2].ToString();
					}
				}
                else if (!string.IsNullOrEmpty(erogazioneLuogo.luogoCodiceIstat))
				{
					DataTable geo = conn.SQLRunner($"select idcity, cap, title from geo_city_codeview where istat = '{erogazioneLuogo.luogoCodiceIstat}'");
					if (geo.Rows.Count > 0)
					{
						idcity = (int)geo.Rows[0][0];
						cap = geo.Rows[0][1].ToString();
						title = geo.Rows[0][2].ToString();
					}
				}
                else if (!string.IsNullOrEmpty(erogazioneLuogo.luogoCodiceCatastale))
				{
					DataTable geo = conn.SQLRunner($"select idcity, cap, title from geo_city_codeview where nazionale = '{erogazioneLuogo.luogoCodiceCatastale}'");
					if (geo.Rows.Count > 0)
					{
						idcity = (int)geo.Rows[0][0];
						cap = geo.Rows[0][1].ToString();
						title = geo.Rows[0][2].ToString();
					}
				}

                if (idcity != 0)
                {
                    string qry = string.Format(InsSede, idcity, cap, title, idreg);
					DataTable newSede = conn.SQLRunner(qry);
                    if (newSede.Rows.Count > 0)
                    {
                        int.TryParse(newSede.Rows[0][0].ToString(), out idsede);
					}
				}
			}

			return idsede;
		}

		private int GetRendicontAltroKind(IDataAccess conn, string tipoAttivita)
		{
			int idrendicontaltrokind = (int)(conn.DO_READ_VALUE("rendicontaltrokind", $"title = '{tipoAttivita}'", "idrendicontaltrokind") ?? 0);

			if (idrendicontaltrokind == 0)
            {
				string qry = string.Format(InsRendicontaltroKind, tipoAttivita);
				DataTable newRendicontAltroKind = conn.SQLRunner(qry);
				if (newRendicontAltroKind.Rows.Count > 0)
					int.TryParse(newRendicontAltroKind.Rows[0][0].ToString(), out idrendicontaltrokind);
			}
			return idrendicontaltrokind;
		}


		/// <summary>
		/// Returns json with rows and err keys. Rows are filtererd on anno e codicefsicale
		/// If codiceFiscale is null retruns all the rows for anno
		/// </summary>
		/// <param name="prms">customEventQueryParameters</param>
		/// <returns></returns>
		[HttpPost, Route("projectWorkpackageDict")]
        public IHttpActionResult getProjectWorkpackage(getProjectWorkpackagePrms prms) {
            var dispatcher = new Dispatcher();
            dispatcher.createDbConnection();
            IEasyDataAccess conn = dispatcher.conn;
            var codiceFiscale = prms.codiceFiscale;
            var anno = prms.anno;
            var username = prms.username;
            var password = prms.password;

            JObject result;

            // Controllo credenziali
            string bismartUsername = WebConfigurationManager.AppSettings["bismartUsername"];
            string bismartPassword = WebConfigurationManager.AppSettings["bismartPassword"];
            SystemConfig systemConfig = Security.Token.decodeSystemConfig(bismartPassword);
            bismartPassword = systemConfig.password;

            if (username == null || password == null) {
                result = new JObject {
                    {"rows", ""},
                    {"err", "wrong credential"}
                 };
                return Content(HttpStatusCode.OK, result);
            }

            if (!(username.Equals(bismartUsername) && password.Equals(bismartPassword))) {
                result = new JObject {
                    {"rows", ""},
                    {"err", "wrong credential"}
                 };
                return Content(HttpStatusCode.OK, result);
            }

           
            string tableName = "getattivitaprogettoview";

            if (string.IsNullOrEmpty(anno)) {
                result = new JObject {
                    {"rows", ""},
                    {"err", "anno parameter is mandatory"}
                 };
                return Content(HttpStatusCode.OK, result);
            }

            MetaExpression filter = q.eq("year", anno);
            // se non passa codicefiscale ritorna tutti i dati per l'anno
            if (!string.IsNullOrEmpty(codiceFiscale)) {
                MetaExpression filterCodiceFiscale = q.eq("codicefiscale", codiceFiscale);
                filter = q.and(filter, filterCodiceFiscale);
            }

            DataTable dt = conn.readTable(tableName, filter, "*", null, null);
            string lastError = conn.LastError;
            // check su eventuale errore
            if (!String.IsNullOrEmpty(lastError)) {
                result = new JObject {
                    {"rows", ""},
                    {"err", lastError}
                 };
                return Content(HttpStatusCode.OK, result);
            }

            string rows = JsonConvert.SerializeObject(dt);
            // la SerializeObject crea "\chiave"\:"\valore"\, con gli slash. La parse toglie gli slash
            // così al client arriva un json "pulito" cioè { "chiave": "valore"} senza gli slash prima dei doppi apici
            var rowsParsed = JToken.Parse(rows);
            result = new JObject {
                    {"rows", rowsParsed},
                    {"err", ""}
                 };

            //invio risposta al client
            return Content(HttpStatusCode.OK, result);
		}

		// ========================================================================================================================
		// Rendicontdidattica
		// ========================================================================================================================
		string CountRendicontdidattica = "SET DATEFORMAT dmy; select count(idrendicontdidattica) from rendicontdidattica where start = '{0}' AND stop = '{1}' AND idreg = {2}";

		string InsRendicontdidattica = "SET DATEFORMAT dmy; INSERT INTO rendicontdidattica (idrendicontdidattica, start, stop, ct, cu, lt, lu, title, idreg, idsede) " +
									   "VALUES ((select isnull(max(idrendicontdidattica), 0) + 1 from rendicontdidattica), '{0}', '{1}', getdate(), 'ApiBesmart', getdate(), 'ApiBesmart', '{2}', {3}, {4})";

        string DelRendicontdidattica = "SET DATEFORMAT dmy; DELETE rendicontdidattica WHERE idreg = {0} AND start = {1} AND stop = {2}";

        // ========================================================================================================================
        // Erogazione
        // ========================================================================================================================
        string CountRendicontaltro = "SET DATEFORMAT dmy; select count(idrendicontaltro) from rendicontaltro where aa = '{0}' AND idreg_docenti = '{1}' AND data = '{2}' AND idrendicontaltrokind = {3}";

		string InsRendicontaltro = "SET DATEFORMAT dmy; INSERT INTO rendicontaltro (idrendicontaltro, aa, idreg_docenti, ct, cu, data, idrendicontaltrokind, lt, lu, ore) " +
									"VALUES ((select isnull(max(idrendicontaltro), 0) + 1 from rendicontaltro), '{0}', {1}, getdate(), 'ApiBesmart', '{2}', {3}, getdate(), 'ApiBesmart', {4})";

        string CountDelRendicontaltro = "SET DATEFORMAT dmy; select count(idrendicontaltro) from rendicontaltro where aa = '{0}' AND idreg_docenti = '{1}' AND data = '{2}'";

        string DelRendicontaltro = "SET DATEFORMAT dmy; DELETE rendicontaltro WHERE idreg_docenti = {0} AND data = {1} AND ore = {2}";

        // ========================================================================================================================
        // RendicontaltroKind
        // ========================================================================================================================
        string InsRendicontaltroKind = $@"declare @newidrendicontaltrokind integer
                                          set @newidrendicontaltrokind = (select isnull(max(idrendicontaltrokind),  0) + 1 from rendicontaltrokind)
                                          INSERT INTO rendicontaltrokind (idrendicontaltrokind, active, ct, cu, description, lt, lu, sortcode, title)
									      VALUES (@newidrendicontaltrokind, 'S', getdate(), 'ApiBesmart', '', getdate(), 'ApiBesmart', (select isnull(max(sortcode), 0) + 1 from rendicontaltrokind), '{{0}}')
                                          select @newidrendicontaltrokind";

		// ========================================================================================================================
		// Sede
		// ========================================================================================================================
		string InsSede = $@"declare @newidsede integer
                            set @newidsede = (select isnull(max(idsede),  0) + 1 from sede)
                            INSERT INTO sede (idsede, address, annotations, cap, ct, cu, idcity, idnation, idreg, idsedemiur, latitude, longitude, lt, lu, title)
                            VALUES (@newidsede, null, null, {{1}}, getdate(), 'ApiBesmart', {{0}}, 1, {{3}}, null, null, null, getdate(), 'ApiBesmart', '{{2}}')
                            SELECT @newidsede";
	}
}
