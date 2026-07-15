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

using System.Net;
using System.Web.Http;
using System.Web.Http.Cors;
using System;

namespace Backend.Controllers
{
    /// <summary>
    /// Controller contenente le primitive necessarie per la gestione delle funzioni di e-signature tramite servizi di firma remota openapi
    /// </summary>
    [RoutePrefix("esignature"), AllowAnonymous, EnableCors("*", "*", "*")]
    public class SigilloElettronicoController : ApiController
    {
        // ========================================================================================================================
        //                                  ███████  ██   █████   ██  ██       ██        █████          
        //                                  ██       ██  ██       ██  ██       ██       ██   ██         
        //                                  ███████  ██  ██  ███  ██  ██       ██       ██   ██         
        //                                       ██  ██  ██   ██  ██  ██       ██       ██   ██         
        //                                  ███████  ██   █████   ██  ███████  ███████   █████          
        //
        //              ███████  ██       ███████  ██████  ██████  ██████    █████   ██   ██  ██   ██████   █████ 
        //              ██       ██       ██         ██      ██    ██   ██  ██   ██  ███  ██  ██  ██       ██   ██
        //              █████    ██       █████      ██      ██    █████    ██   ██  ██ █ ██  ██  ██       ██   ██
        //              ██       ██       ██         ██      ██    ██   █   ██   ██  ██  ███  ██  ██       ██   ██
        //              ███████  ███████  ███████    ██      ██    ██   ██   █████   ██   ██  ██   ██████   █████ 
        // ========================================================================================================================
        

        /// <summary>
        /// 
        /// </summary>
        /// <param name="prms"></param>
        /// <returns></returns>
        [HttpPost, Route("signFileAruba")]
        public IHttpActionResult signFileOpenApi([FromBody] SignData prms)
        {
            string error = "";

            byte[] outStream = FirmaRemotaAruba.SignService.signFileAruba(prms.byteStream, prms.username, prms.password, prms.otp, prms.type, out error);
            
            if (!string.IsNullOrEmpty(error))
                return Content(HttpStatusCode.OK, error);

            return Content<byte[]>(HttpStatusCode.OK, outStream);
		}
	}
}