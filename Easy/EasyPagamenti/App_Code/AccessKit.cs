
/*
Easy
Copyright (C) 2023 Universita' degli Studi di Catania (www.unict.it)
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
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
namespace EasyPagamenti {
    public static class AccessKit {

        public static DataAccess GetDepartmentConn(string dep,out string Errore) {
            Errore = string.Empty;
            DataSet Cfg = GetVars.GetAppConfigDataSet();
            if (Cfg.Tables[0].Rows.Count == 0) {
                Errore ="Servizio non installato correttamente. Manca il file di configurazione.";
                return null;
            }
            string error;
            DataAccess SysConn = GetVars.GetAppSystemDataAccess(out error);
            if (SysConn == null) {
                Errore = "Connessione al db di sistema non riuscita.";
                return null;
            }
            var result= GetAppDepAccess(SysConn, dep, out Errore);
            SysConn.Destroy();
            return result;
        }

        //public AccessKit() { }
        //public static void Error(string message, Page page) {
        //    page.Response.ContentType = "text/plain";
        //    page.Response.ClearContent();
        //    page.Response.Write(message);
        //    page.Response.End();
        //}
        public static DataAccess GetDepartmentConn(string dep, Page page, out string Errore) {
            Errore = string.Empty;
            DataSet Cfg = GetVars.GetConfigDataSet(page);
            if (Cfg.Tables[0].Rows.Count == 0) {
                Errore ="Servizio non installato correttamente. Manca il file di configurazione.";
                return null;
            }
            string error;
            DataAccess Conn = GetVars.GetSystemDataAccess(page, out error);
            if (Conn == null) {
                Errore = "Connessione al db di sistema non riuscita.";
                return null;
            }
            return GetDepAccess(Conn, dep, page, out Errore);
        }

        public static DataAccess GetDepAccess(DataAccess SystemConn, string dep, Page page, out string Errore) {
            QueryHelper QHS = SystemConn.GetQueryHelper();
            Errore = string.Empty;
            string filterdip = QHS.CmpEq("codicedipartimento", dep);
            DataTable CodDip = SystemConn.RUN_SELECT("codicidipartimenti", "*", null, filterdip, null, true);

            if ((CodDip == null) || (CodDip.Rows.Count == 0)) {
                //Dati non corretti
                Errore = dep + ": Codice non corretto";
                return null;
            }
            if (CodDip.Rows.Count > 1) {
                //Attenzione nel DB non è garantita l'unicità dei dati.
                Errore = "Attenzione !!! Duplicazione di codici per " + dep;
                return null;
            }

            string err = "";
            DataRow myDr = CodDip.Rows[0];
            //Session["Dipartimento"] = myDr["Dipartimento"].ToString();


            //Creo la connessione.
            DataAccess UsrConn = GetVars.CreateUserConn(page, myDr, null, null, DateTime.Now, out err);
            if (UsrConn == null) {
                Errore ="Connessione al db del dipartimento " + dep + " non riuscita. ";
                return null;
            }

            return UsrConn;
        }

        public static DataAccess GetAppDepAccess(DataAccess SystemConn, string dep,  out string Errore) {
            QueryHelper QHS = SystemConn.GetQueryHelper();
            Errore = string.Empty;
            string filterdip = QHS.CmpEq("codicedipartimento", dep);
            DataTable CodDip = SystemConn.RUN_SELECT("codicidipartimenti", "*", null, filterdip, null, true);

            if ((CodDip == null) || (CodDip.Rows.Count == 0)) {
                //Dati non corretti
                Errore = dep + ": Codice non corretto";
                return null;
            }
            if (CodDip.Rows.Count > 1) {
                //Attenzione nel DB non è garantita l'unicità dei dati.
                Errore = "Attenzione !!! Duplicazione di codici per " + dep;
                return null;
            }

            string err = "";
            DataRow myDr = CodDip.Rows[0];
            //Session["Dipartimento"] = myDr["Dipartimento"].ToString();


            //Creo la connessione.
            DataAccess UsrConn = GetVars.CreateAppUserConn(myDr, null, null, DateTime.Now, out err);
            if (UsrConn == null) {
                Errore ="Connessione al db del dipartimento " + dep + " non riuscita. ";
                return null;
            }

            return UsrConn;
        }

    }
}
