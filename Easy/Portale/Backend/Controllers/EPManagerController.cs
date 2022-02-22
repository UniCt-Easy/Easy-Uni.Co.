
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



using Backend.Components;
using Backend.Extensions;

using Newtonsoft.Json.Linq;

using System.Net;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using ep_functions;
using QHS = metadatalibrary.QueryHelper;

namespace Backend.Controllers {


    /// <summary>
    /// Controller contenente le primitive necessarie per la manipolazione dei dati con MetaDataLibrary.
    /// </summary>
    /// <remarks>
    /// Il percorso (URL) per accedere ai metodi contenuti in questo controller devono avere il prefisso "/meta".
    /// I metodi contenuti in questo controller sono accessibili solo se viene specificato un token di autenticazione valido.
    /// I metodi contenuti in questo controller sono accessibili da qualsiasi client (CORS attivati per ogni richiesta).
    /// </remarks>
    [RoutePrefix("ep"), Authorize, EnableCors("*", "*", "*")]
    public class EPManagerController : ApiController {

        public class getNRateiParameters {
            public string dt { get; set; }
            public string rownum { get; set; }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="prms">getNRatei</param>
        /// <returns></returns>
        [HttpPost, Route("getNRatei")]
        public IHttpActionResult getNRatei(getNRateiParameters prms) {
            var dt = prms.dt;
            var rownum = prms.rownum;
            var dispatcher = HttpContext.Current.getDataDispatcher();
            var dtSerialized = DataSetSerializer.jTokenToTable(JObject.Parse(dt), dispatcher);
            var drParent = dtSerialized.Rows[0];
            string idrelated = EP_functions.GetIdForDocument(drParent);
            var QHS = dispatcher.conn.GetQueryHelper();
            idrelated = idrelated + "§" + rownum;
            var nRatei = dispatcher.conn.RUN_SELECT_COUNT("entrydetail", QHS.CmpEq("idrelated", idrelated), false);

            return Content(HttpStatusCode.OK, (nRatei > 0).ToString());

        }

    }

}
