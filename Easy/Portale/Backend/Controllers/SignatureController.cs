
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
using System;
using FirmaRemotaAruba;

namespace Backend.Controllers
{

    /// <summary>
    /// Controller contenente le primitive necessarie per la gestione delle funzioni di admin
    /// </summary>
    /// <remarks>
    /// Il percorso (URL) per accedere ai metodi contenuti in questo controller devono avere il prefisso "/admin".
    /// </remarks>
    [RoutePrefix("signature"), AllowAnonymous, EnableCors("*", "*", "*")]
    public class SignatureController : ApiController
    {
        public class SignData
        {
            public Byte[] byteStream { get; set; }
            public string username { get; set; }
            public string password { get; set; }
            public string otp { get; set; }
            public string type { get; set; }
        }

        /// <summary>
        /// stream: byte array of the file
        /// username: aruba username
        /// password: aruba password
        /// otp: aruba otp
        /// type: "P" = PAdES (pdf), "C" = CAdES (p7m)=
        /// </summary>
        /// <param name="byteStream"></param>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="otp"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        [HttpPost, Route("signFile")]
        public IHttpActionResult signFile([FromBody] SignData prms)
        {
            byte[] outStream = SignService.signFile(prms.byteStream, prms.username, prms.password, prms.otp, prms.type, out string error);

            // System.IO.File.WriteAllBytes(@"D:\doc_01.pdf", outStream);

            if (!string.IsNullOrEmpty(error))
                return Content(HttpStatusCode.OK, error);

            return Content<byte[]>(HttpStatusCode.OK, outStream);
        }
    }
}
