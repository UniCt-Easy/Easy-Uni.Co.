/*
Easy
Copyright (C) 2026 Università degli Studi di Catania (www.unict.it)
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

using System;
using System.Net;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;

using Backend.CommonBackend;
using Backend.Extensions;
using Backend.Extra;

using Document.Protocol;

namespace Backend.Controllers {

    /// <summary>
    /// Gestisce le richieste di protocollazione usando il servizio di protocollazione.
    /// </summary>
    [RoutePrefix("protocol"), Authorize, EnableCors("*", "*", "*")]
    public class ProtocolController : ApiController {

        /// <summary>
        /// Richiede al servizio di protocollazione la protocollazione di un documento SDI.
        /// </summary>
        /// <param name="spr">Richiesta di protocollazione SDI.</param>
        /// <returns>Numero di protocollo o errore.</returns>
        [HttpPost, Route("sdi")]
        public IHttpActionResult ProtocolSdi(SDIProtocolRequest spr) {

            Dispatcher d = HttpContext.Current.getDataDispatcher();

            ProtocolResult res;
            try {

                res = ProtocollerService.Instance.ProtocolSdi(d, spr);
            }
            catch (Exception e) {

                var wrappingException = new Exception($"Errore imprevisto sul Controller '{nameof(ProtocolController)}'" +
                    $" e metodo '{nameof(ProtocolSdi)}' per la protocollazione del documento : '{spr.SerializedDocumentID}'", e);

                BackendLoggerService.Logger.logException(wrappingException);

                return Content(HttpStatusCode.OK, new {
                    Error = "Errore di protocollazione.",
                    nProt = (string)null,
                });
            }

            return Content(HttpStatusCode.OK, new {
                Error = (string)null,
                nProt = res.ID.Number.ToString(),
            });
        }
    }
}
