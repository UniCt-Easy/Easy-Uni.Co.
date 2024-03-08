
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


using ComponentSpace.SAML2;
using ComponentSpace.SAML2.Utility;
using System;
using System.Web.Configuration;

public partial class DefaultSAML : System.Web.UI.Page {

    protected void Page_Load(object sender, EventArgs e) {
        string args = Request.Params["popup"];

        if (string.IsNullOrEmpty(args)) return;

        if (args.Equals("ok")) {
            if (Session["samlemail"] == null) {
                if (License.IsLicensed()) {
                    var partnerIdP = WebConfigurationManager.AppSettings.Get("partnerIdP");
                    SAMLServiceProvider.InitiateSSO(Response, null, partnerIdP);
                }
            }
            else {
                Response.Redirect("LoginSAML.aspx");
            }
        }
    }

}
