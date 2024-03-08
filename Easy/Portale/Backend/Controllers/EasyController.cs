
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
using Backend.Extensions;
using metadatalibrary;
using metaeasylibrary;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Backend.Controllers {



    /// <summary>
    /// Controller contenente le primitive necessarie per la manipolazione dei dati con MetaDataLibrary.
    /// </summary>
    /// <remarks>
    /// Il percorso (URL) per accedere ai metodi contenuti in questo controller devono avere il prefisso "/meta".
    /// I metodi contenuti in questo controller sono accessibili solo se viene specificato un token di autenticazione valido.
    /// I metodi contenuti in questo controller sono accessibili da qualsiasi client (CORS attivati per ogni richiesta).
    /// </remarks>
    [RoutePrefix("easy"), Authorize, EnableCors("*", "*", "*")]
    public class EasyController : ApiController {


        public class computeComunePrms {
            public string codicefiscale { get; set; }
        }


        /// <summary>
        /// Called by Client, calls a generic custom method for a specific business logic. Implement the switch case!
        /// </summary>
        /// <param name="prms">customEventQueryParameters</param>
        /// <returns></returns>
        [HttpPost, Route("computeComune")]
        public IHttpActionResult computeComune([FromBody] computeComunePrms prms) {
            string idcomune = comune(prms.codicefiscale);
            return Content(HttpStatusCode.OK, idcomune);

        }

        private string comune(string codicefiscale) {
            var dispatcher = HttpContext.Current.getDataDispatcher();

            if (codicefiscale.Length != 16)
                return null;
            string codicecomune = codicefiscale.Substring(11, 4);
            string[] param = new string[] {"@codecity", "@idcity"};
            SqlDbType[] types = new SqlDbType[] {SqlDbType.VarChar, SqlDbType.Int};
            int[] typelen = new int[] {4, 0};
            ParameterDirection[] dir = new ParameterDirection[] {ParameterDirection.Input, ParameterDirection.Output};
            object[] values = new object[2] {codicecomune, null};
            bool res = dispatcher.conn.CallSPParameter("compute_idcity_from_cf", param, types, typelen, dir, ref values,
                true, -1);
            if (!res) return null;
            return values[1].ToString();
        }

        /// <summary>
        /// Called by Client, calls a generic custom method for a specific business logic. Implement the switch case!
        /// </summary>
        /// <param name="prms">customEventQueryParameters</param>
        /// <returns></returns>
        [HttpPost, Route("computeNazione")]
        public IHttpActionResult computeNazione([FromBody] computeComunePrms prms) {
            string idnazione = nazione(prms.codicefiscale);
            return Content(HttpStatusCode.OK, idnazione);

        }

        private string nazione(string codicefiscale) {
            var dispatcher = HttpContext.Current.getDataDispatcher();
            if (codicefiscale.Length != 16)
                return null;
            string codicecomune = codicefiscale.Substring(11, 4);
            string[] param = new string[] {"@codenation", "@idnation"};
            SqlDbType[] types = new SqlDbType[] {SqlDbType.VarChar, SqlDbType.Int};
            int[] typelen = new int[] {4, 0};
            ParameterDirection[] dir = new ParameterDirection[] {ParameterDirection.Input, ParameterDirection.Output};
            object[] values = new object[2] {codicecomune, null};
            bool res = dispatcher.conn.CallSPParameter("compute_idnation_from_cf", param, types, typelen, dir,
                ref values, true, -1);
            if (!res) return null;
            return values[1].ToString();
        }

        public class computeHistoryCityPrms {
            public string idcomune { get; set; }
        }

        /// <summary>
        /// Called by Client, calls a generic custom method for a specific business logic. Implement the switch case!
        /// </summary>
        /// <param name="prms">customEventQueryParameters</param>
        /// <returns></returns>
        [HttpPost, Route("computeHistoryCity")]
        public IHttpActionResult computeHistoryCity([FromBody] computeHistoryCityPrms prms) {
            var jsonDataSet = computeGeoHistory("compute_history_city", prms.idcomune);
            return Content(HttpStatusCode.OK, jsonDataSet);

        }

        public class computeHistoryNationPrms {
            public string idstatoestero { get; set; }
        }

        /// <summary>
        /// Called by Client, calls a generic custom method for a specific business logic. Implement the switch case!
        /// </summary>
        /// <param name="prms">customEventQueryParameters</param>
        /// <returns></returns>
        [HttpPost, Route("computeHistoryNation")]
        public IHttpActionResult computeHistoryNation([FromBody] computeHistoryNationPrms prms) {
            var jsonDataSet = computeGeoHistory("compute_history_nation", prms.idstatoestero);
            return Content(HttpStatusCode.OK, jsonDataSet);
        }

        /// <summary>
        /// Computes the gei history.
        /// idcity or idnation
        /// </summary>
        /// <param name="spName"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        private JObject computeGeoHistory(string spName, string id) {
            var dispatcher = HttpContext.Current.getDataDispatcher();
            object[] list = new object[] {id, "S"};
            DataSet DSout = dispatcher.conn.CallSP(spName, list, true, -1);
            var jsonResDataSet = DataUtils.dataSetToJSon(DSout,true);
            return jsonResDataSet;
        }

    }

}
