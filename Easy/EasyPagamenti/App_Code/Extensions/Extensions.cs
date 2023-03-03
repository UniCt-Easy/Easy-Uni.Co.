
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



using EasyPagamenti.Data;
using EasyPagamenti.Extra;
using metadatalibrary;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace EasyPagamenti.Extensions {

    /// <summary>
    /// Metodi di estensione per ASP.NET WebAPI.
    /// </summary>
    public static class Extensions {

        /// <summary>
        /// Ottiene il dispatcher dei dati dal contesto HTTP.
        /// </summary>
        /// <param name="context">Contesto HTTP.</param>
        /// <returns>Il dispatcher dei dati.</returns>
        public static Dispatcher GetDataDispatcher(this HttpContext context) {
            return context.Items["DataDispatcher"] as Dispatcher;
        }

        /// <summary>
        /// Genera un'istanza di ActionResult contenente un codice di stato e un messaggio.
        /// </summary>
        /// <param name="request">La richiesta HTTP.</param>
        /// <param name="statusCode">Il codice di stato.</param>
        /// <param name="reason">Il messaggio.</param>
        /// <returns>Un'istanza di ActionResult.</returns>
        public static AuthenticationResult ActionResult(this HttpRequestMessage request, HttpStatusCode statusCode, string reason) {
            return new AuthenticationResult(request, statusCode, reason);
        }

        /// <summary>
        /// Genera un'istanza di ChallengeResult contenente la risposta ad una richiesta HTTP.
        /// </summary>
        /// <param name="innerResult">Il risultato della richiesta HTTP.</param>
        /// <returns>Un'istanza di ChallengeResult.</returns>
        public static ChallengeResult ChallengeResult(this IHttpActionResult innerResult) {
            return new ChallengeResult(innerResult);
        }

        private static string GetPartialFilter(Type dataType, string key, string value) {
            var dispatcher = HttpContext.Current.GetDataDispatcher();

            string partial;
            if (dataType == typeof(string)) {
                var obj = string.Format("%{0}%", value.Replace("%", ""));
                partial = dispatcher.QueryHelper.Like(key, obj);
            }
            else {
                var obj = HelpForm.GetObjectFromString(dataType, value, "x.y");
                partial = dispatcher.QueryHelper.CmpEq(key, obj);
            }

            return partial;
        }

        /// <summary>
        /// Restituisce un filtro compatibile con GetData, derivato dalla query string nell'URL della richiesta.
        /// </summary>
        /// <remarks>
        /// Questo metodo prende in considerazione tutte le coppie chiave/valore presenti nella query string e
        /// costruisce un filtro compatibile con GetData. Nel filtro vengono inclusi solo ed esclusivamente i campi
        /// disponibili nella tabella passata come riferimento, le altre chiavi vengono scartate.
        /// </remarks>
        /// <param name="request">Richiesta HTTP.</param>
        /// <param name="dt">Tabella da filtrare.</param>
        /// <returns>Filtro compatibile con GetData.</returns>
        public static string GetFilter(this HttpRequestMessage request, DataTable dt) {
            var query = request.GetQueryNameValuePairs().ToDictionary(pair => pair.Key, pair => pair.Value);

            var partials = new List<string>();
            foreach (var key in query.Keys) {
                if (dt.Columns.Contains(key)) {
                    var dataType = dt.Columns[key].DataType;

                    string partial = GetPartialFilter(dataType, key, query[key]);
                    partials.Add(partial);
                }
            }

            if (partials.Count > 1) {
                var dispatcher = HttpContext.Current.GetDataDispatcher();

                return dispatcher.QueryHelper.AppAnd(partials.ToArray());
            }

            return partials.FirstOrDefault();
        }

        /// <summary>
        /// Restituisce il filtro compatibile con GetData e derivata dalla chiave primaria della tabella.
        /// </summary>
        /// <remarks>
        /// Questo metodo prende in considerazione tutte le coppie chiave/valore presenti nella query string e
        /// costruisce un filtro compatibile con GetData. Nel filtro vengono inclusi tutti i campi della chiave primaria
        /// della tabella passata come riferimento. Se nella query string manca anche un solo campo della chiave
        /// la generazione del filtro fallisce.
        /// </remarks>
        /// <param name="request">Richiesta HTTP.</param>
        /// <param name="dt">Tabella da filtrare.</param>
        /// <returns>Filtro compatibile con GetData.</returns>
        public static string GetFilterByKey(this HttpRequestMessage request, DataTable dt) {
            var query = request.GetQueryNameValuePairs().ToDictionary(pair => pair.Key, pair => pair.Value);

            var partials = new List<string>();
            foreach (var column in dt.PrimaryKey) {
                if (!query.ContainsKey(column.ColumnName)) return null;

                string partial = GetPartialFilter(column.DataType, column.ColumnName, query[column.ColumnName]);
                partials.Add(partial);
            }

            if (partials.Count > 1) {
                var dispatcher = HttpContext.Current.GetDataDispatcher();

                return dispatcher.QueryHelper.AppAnd(partials.ToArray());
            }

            return partials.FirstOrDefault();
        }

    }

}
