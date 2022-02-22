
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


using ComponentSpace.SAML2;
using System;
using System.Web.Configuration;

public partial class saml_logout : System.Web.UI.Page {

    protected void Page_Load(object sender, EventArgs e) {
        bool isRequest = false;
        string logoutReason = null;
        string partnerIdP = null;
        string relayState = null;

        // Riceve una richiesta o una conferma di logout dal sistema.
        SAMLServiceProvider.ReceiveSLO(Request, out isRequest, out logoutReason, out partnerIdP, out relayState);

        if (isRequest) {
            // Risponde alla richiesta di logout dell'identity provider
            SAMLServiceProvider.SendSLO(Response, null);
        } else {
            // Logout completato, ritorno alla pagina di default
            var frontendSSO = WebConfigurationManager.AppSettings.Get("frontendSSO");
            Response.Redirect(frontendSSO);
        }

    }

}
