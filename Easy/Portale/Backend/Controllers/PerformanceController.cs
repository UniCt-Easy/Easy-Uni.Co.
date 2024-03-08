
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
using Backend.Extensions;
using System;
using System.Data;
using System.Web;

namespace Backend.Controllers
{



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
            public string idAfferenza { get; set; }
            public string year { get; set; }
        }

        /// <summary>
        /// Called by Client, calls a generic custom method for a specific business logic. Implement the switch case!
        /// </summary>
        /// <param name="prms">customEventQueryParameters</param>
        /// <returns></returns>
        [HttpPost, Route("calcolaComportamenti")]
		public IHttpActionResult calcolaComportamenti([FromBody] comportamentiPrms prms) {

			var dispatcher = HttpContext.Current.getDataDispatcher();
			var conn = dispatcher.conn;
			var ds = new DataSet();


			string queryComportamenti = String.Format(@"select distinct c.idperfcomportamento, c.title
				from afferenza a
				join mansionekindcomportamento m on m.idmansionekind = a.idmansionekind
				join perfcomportamento c on c.idperfcomportamento = m.idperfcomportamento
				where a.idafferenza = {0} AND ISNULL(m.year_start,2000) <= {1} AND ISNULL(m.year_stop,2100) >= {1}", prms.idAfferenza, prms.year);

			DataTable dtPerfcomportamento = conn.SQLRunner(queryComportamenti);
			if ((dtPerfcomportamento != null) && (dtPerfcomportamento.Rows.Count > 0)) {
				dtPerfcomportamento.TableName = "perfcomportamento";
				ds.Tables.Add(dtPerfcomportamento);
			}

			string queryPesi = String.Format(@"select distinct m.* 
				from afferenza a
				join mansionekind m on m.idmansionekind = a.idmansionekind
				where a.idafferenza = {0}", prms.idAfferenza);

			DataTable dtMansionekind = conn.SQLRunner(queryPesi);
			if ((dtMansionekind != null) && (dtMansionekind.Rows.Count > 0)) {
				dtMansionekind.TableName = "mansionekind";
				ds.Tables.Add(dtMansionekind);
			}

			return Content(HttpStatusCode.OK, DataUtils.dataSetToJSon(ds,false));
		}



	}

}
