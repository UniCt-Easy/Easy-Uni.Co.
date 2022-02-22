
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
using System.Diagnostics;
using System.Security;
using System.Web.Configuration;
using Backend.Components;

namespace Backend.Controllers {



    /// <summary>
    /// Controller contenente le primitive necessarie per la manipolazione dei dati con MetaDataLibrary.
    /// </summary>
    /// <remarks>
    /// Il percorso (URL) per accedere ai metodi contenuti in questo controller devono avere il prefisso "/meta".
    /// I metodi contenuti in questo controller sono accessibili solo se viene specificato un token di autenticazione valido.
    /// I metodi contenuti in questo controller sono accessibili da qualsiasi client (CORS attivati per ogni richiesta).
    /// </remarks>
    [RoutePrefix("performance"), Authorize, EnableCors("*", "*", "*")]
    public class PerformanceController : ApiController {


        public class comportamentiPrms {
            public string idRegValutato { get; set; }
            public string year { get; set; }
            public string idRegResp { get; set; }
            public string idRuolo { get; set; }
        }


        /// <summary>
        /// Called by Client, calls a generic custom method for a specific business logic. Implement the switch case!
        /// </summary>
        /// <param name="prms">customEventQueryParameters</param>
        /// <returns></returns>
        [HttpPost, Route("calcolaComportamenti")]
        public IHttpActionResult calcolaComportamenti(comportamentiPrms prms) {


            var dispatcher = HttpContext.Current.getDataDispatcher();
            var conn = dispatcher.conn;


            string query = String.Format(@"select distinct c.* from afferenza a
                            join strutturaparentresponsabiliafferenzaview s on a.idstruttura = s.idstruttura
                            join mansionekindcomportamento m on m.idmansionekind = a.idmansionekind
                            join perfcomportamento c on c.idperfcomportamento = m.idperfcomportamento
                            where a.idreg = {0} and(s.start >= convert(date, '1/1/{1}',103)) and (s.stop <= convert(date, '31/12/{1}',103))  and s.idreg = {2} and s.idperfruolo = '{3}'", prms.idRegValutato, prms.year, prms.idRegResp, prms.idRuolo);          

            DataTable dtPaged = conn.SQLRunner(query);
        
            return Content(HttpStatusCode.OK, DataUtils.dataTableToJSon(dtPaged));

        }



    }

}
