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

using ComponentSpace.SAML2;
using ComponentSpace.SAML2.Utility;
using EasyWebReport;
using System;
using System.Configuration;
using System.Web;
using System.Web.Configuration;

public partial class DefaultSAML : System.Web.UI.Page {
	
	
	
    protected void Page_Load(object sender, EventArgs e) {
		string args = Request.Params["popup"] ?? "";
        string token = Request.QueryString["token"] ?? "";
        
        Session["FromSso"] = "saml";

        if (args.Equals("ok") || !string.IsNullOrEmpty(token)) {
        	if (Session["samlemail"] == null) {
				// ==========================================================
				//						CHECK TOKEN
				// ==========================================================
				if (!string.IsNullOrEmpty(token))
				{
        			string email = "";
					string name = "";

					JwtTokenValidator.HandleTokenLogin(token, out email, out name);

					Session["samlemail"] = email;
					Session["samluser"] = name;
					//Session["FromSso"] = "saml";
					
					Response.Redirect("LoginSAML.aspx");
				}

				// ==========================================================
				// 					DASHBOARD SSO ISSUE URL
				// ==========================================================
				else
				{
					// From Sso, Check once
					string ssoFlag = (Session["sso"] ?? "").ToString();
					
					if (!string.Equals(ssoFlag, "tried", StringComparison.OrdinalIgnoreCase))
					{
						var issueUrl = ConfigurationManager.AppSettings["SsoIssueUrl"];

						if (!string.IsNullOrEmpty(issueUrl))
						{
							// ==========================================================
							// NO TOKEN -> REDIRECT TU DASHBOARD ISSUER
							// ==========================================================
							Session["sso"] = "tried";
							string returnUrl = ConfigurationManager.AppSettings["JwtReturnUrl"];
							string redirect = issueUrl + "?returnUrl=" + HttpUtility.UrlEncode(returnUrl);
							
							Response.Redirect(redirect, true);
						}
					}
				}
				
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