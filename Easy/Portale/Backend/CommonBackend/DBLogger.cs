
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


using metadatalibrary;
using metaeasylibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using QHS = metadatalibrary.QueryHelper;

namespace Backend.CommonBackend
{
    public static class DBLogger
    {

        public class BEError
        {
            public string error { get; set; }
            public string methodInfo { get; set; }
            public string metadata { get; set; }
            public IEasyDataAccess conn { get; set; }
        }

        /// <summary>
        /// Scrive log a database su tabella applogging
        /// </summary>
        /// <param name="error"></param>
        /// <param name="methodInfo"></param>
        /// <param name="conn"></param>
        public static void log(BEError beError)
        {
            try
            {
                string id = "1";
                string[] columns = new[] { "id", "message", "date", "username", "method", "server", "metadata" };
                // recupero alcuni parametri globali
                string server = WebConfigurationManager.AppSettings["DBServer"];
                string username = (string)beError.conn.Security.GetUsr("userweb");
                // definisco input per la funz. DO_INSERT
                QueryHelper qhs = beError.conn.GetQueryHelper();
                string[] values = new[] { id ,
                    qhs.quote(beError.error),
                    qhs.quote(DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss")),
                    qhs.quote(username),
                    qhs.quote(beError.methodInfo),
                    qhs.quote(server),
                    qhs.quote(beError.metadata)
                };
                beError.conn.DO_INSERT("applogging", columns, values, 7);
            }
            catch (Exception e)
            {
                var a = 0;
            }
        }
    }
}
