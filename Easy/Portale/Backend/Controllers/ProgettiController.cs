
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


using System.Net;
using System.Web.Http;
using System.Web.Http.Cors;
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
using progettocosto_functions;
using progettoricavo_functions;

namespace Backend.Controllers {



    /// <summary>
    /// Controller contenente le primitive necessarie per la manipolazione dei dati con MetaDataLibrary.
    /// </summary>
    /// <remarks>
    /// Il percorso (URL) per accedere ai metodi contenuti in questo controller devono avere il prefisso "/meta".
    /// I metodi contenuti in questo controller sono accessibili solo se viene specificato un token di autenticazione valido.
    /// I metodi contenuti in questo controller sono accessibili da qualsiasi client (CORS attivati per ogni richiesta).
    /// </remarks>
    [RoutePrefix("progetti"), Authorize, EnableCors("*", "*", "*")]
    public class ProgettiController : ApiController {


        public class calcolaProgettoCostoPrms {
            public string idProgetto { get; set; }
            public string userweb { get; set; }
        }


        /// <summary>
        /// Called by Client, calls a generic custom method for a specific business logic. Implement the switch case!
        /// </summary>
        /// <param name="prms">customEventQueryParameters</param>
        /// <returns></returns>
        [HttpPost, Route("calculateAmmortamento")]
        public IHttpActionResult calculateAmmortamento(calcolaProgettoCostoPrms prms) {
            var dispatcher = HttpContext.Current.getDataDispatcher();
            progettocosto_function pf = new progettocosto_function(dispatcher.conn);

            DateTime now = DateTime.Now;
            DateTime d2 = now.AddMonths(-1);
            var idProgetto = prms.idProgetto;
            var mese = d2.Month;
            var esercizio = d2.Year;
            string error = "";
            object result = null;

            // prima chiamata
            DataSet ds1 = pf.CalcolaDiarioUso(idProgetto, mese, esercizio, out error);
            if (error != "") {

                result = new JObject {
                    {"error", error},
                    {"ds", null}
                };

                return Content(HttpStatusCode.OK, result);
            }

            var jsonResDataSet = DataUtils.dataSetToJSon(ds1);
            result = new JObject {
                {"error", null},
                {"ds", jsonResDataSet}
            };
            return Content(HttpStatusCode.OK, result);
        }


        /// <summary>
        /// Called by Client, calls a generic custom method for a specific business logic. Implement the switch case!
        /// </summary>
        /// <param name="prms">customEventQueryParameters</param>
        /// <returns></returns>
        [HttpPost, Route("calculateCostiProgetto")]
        public IHttpActionResult calculateCostiProgetto(calcolaProgettoCostoPrms prms) {
            var dispatcher = HttpContext.Current.getDataDispatcher();
            progettocosto_function pf = new progettocosto_function(dispatcher.conn);
            progettoricavo_function pfr = new progettoricavo_function(dispatcher.conn);

            DateTime now = DateTime.Now;
            DateTime d2 = now.AddMonths(-1);
            var idProgetto = prms.idProgetto;
            string error = "";
            string error2 = "";
            object result = null;


            DataSet ds = pf.popolaprogettoCosto(idProgetto, out error);

            if (error != "") {
                result = new JObject {
                    {"error", error},
                    {"ds", null}
                };
                return Content(HttpStatusCode.OK, result);
            }

            DataSet dsr = pfr.popolaprogettoricavo(idProgetto, out error2);

            if (error2 != "") {
                result = new JObject {
                    {"error", error2},
                    {"ds", null}
                };
                return Content(HttpStatusCode.OK, result);
            }

            ds.Tables.Add(dsr.Tables[0].Copy());

            var jsonResDataSet = DataUtils.dataSetToJSon(ds);
            result = new JObject {
                {"error", null},
                {"ds", jsonResDataSet}
            };
            return Content(HttpStatusCode.OK, result);
        }

    }

}
