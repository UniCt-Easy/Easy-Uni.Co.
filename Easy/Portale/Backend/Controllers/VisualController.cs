
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

namespace Backend.Controllers {



    /// <summary>
    /// Controller contenente le primitive necessarie per la manipolazione dei dati con MetaDataLibrary.
    /// </summary>
    /// <remarks>
    /// Il percorso (URL) per accedere ai metodi contenuti in questo controller devono avere il prefisso "/meta".
    /// I metodi contenuti in questo controller sono accessibili solo se viene specificato un token di autenticazione valido.
    /// I metodi contenuti in questo controller sono accessibili da qualsiasi client (CORS attivati per ogni richiesta).
    /// </remarks>
    [RoutePrefix("visual"), Authorize, EnableCors("*", "*", "*")]
    public class VisualController : ApiController {


        public class generaPagesPrms {
            public string idApplicazione { get; set; }
            public string idPagina { get; set; }
        }


        /// <summary>
        /// Called by Client, calls a generic custom method for a specific business logic. Implement the switch case!
        /// </summary>
        /// <param name="prms">customEventQueryParameters</param>
        /// <returns></returns>
        [HttpPost, Route("generaPages")]
        public IHttpActionResult generaPages(generaPagesPrms prms) {
            var dispatcher = HttpContext.Current.getDataDispatcher();

            string pathGenerator = WebConfigurationManager.AppSettings["pathGenerator"];
            string machineusername = WebConfigurationManager.AppSettings["machineusername"];
            string machinepassword = WebConfigurationManager.AppSettings["machinepassword"];

            ProcessStartInfo process = new ProcessStartInfo();
            process.CreateNoWindow = false;
            process.UseShellExecute = false;
            process.FileName = "cmd.exe";
            process.Arguments = @"/c " + pathGenerator + "\\Segreterie.Generator.exe " + prms.idApplicazione + " " +
                                prms.idPagina;
            process.UserName = machineusername;
            string initString = machinepassword;
            SecureString spsw = new SecureString();
            foreach (char ch in initString)
                spsw.AppendChar(ch);
            process.Password = spsw;
            process.RedirectStandardOutput = true;
            process.UseShellExecute = false;
            process.WorkingDirectory = pathGenerator;
            process.CreateNoWindow = true;

            var msg = "";
            try {
                using (Process ProcessoExe = Process.Start(process)) {
                    msg = ProcessoExe.StandardOutput.ReadToEnd();
                    ProcessoExe.WaitForExit();
                }

                msg += "OK GeneratePages " + prms.idApplicazione.ToString() + " " + prms.idPagina.ToString();
            }
            catch (Exception e) {
                msg += "KO GeneratePages " + prms.idApplicazione.ToString() + " " + prms.idPagina.ToString() + "\r\n" +
                       e.Message;
            }

            return Content(HttpStatusCode.OK, msg);
        }


    }

}
