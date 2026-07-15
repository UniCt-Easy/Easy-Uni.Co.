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

// Sso/ConsumeToken.aspx.cs (WebForms)
using Microsoft.IdentityModel.Tokens;
using System;
using System.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Web;
using System.Web.Security;

namespace EasyWebReport
{
    public partial class Sso_ConsumeToken : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var token = Request.QueryString["token"];

            if (string.IsNullOrEmpty(token))
            {
                // Read from Web.config instead of hardcoding
                var issueUrl = ConfigurationManager.AppSettings["SsoIssueUrl"];

                if (string.IsNullOrEmpty(issueUrl))
                    throw new Exception("Missing SsoIssueUrl in Web.config <appSettings>");

                // If no token, start the dance by redirecting to App1 issuer
                var returnUrl = $"{Request.Url.Scheme}://{Request.Url.Authority}/Sso/ConsumeToken.aspx";
                var redirect = issueUrl + "?returnUrl=" + HttpUtility.UrlEncode(returnUrl);
                Response.Redirect(redirect, endResponse: true);

                return;
            }

            try
            {
                var principal = ValidateJwt(token);
                if (principal == null)
                    throw new Exception("Invalid token");

                var nameClaim = principal.FindFirst(ClaimTypes.Name);
                var subClaim = principal.FindFirst(JwtRegisteredClaimNames.Sub);
                var emailClaim = principal.FindFirst(ClaimTypes.Email);

                var name = nameClaim?.Value ?? subClaim?.Value ?? principal.Identity?.Name ?? "user";
                var email = emailClaim?.Value ?? "";

                // Create a FormsAuth ticket (or set a custom principal)
                FormsAuthentication.SetAuthCookie(name, true);

                // OPTIONAL: store extra info in Session
                Session["Email"] = email;

                // Redirect to your home page (or originally requested url)
                Response.Redirect("~/Default.aspx", endResponse: true);
            }
            catch (Exception ex)
            {
                // Log and show a friendly message
                Response.Write("SSO error: " + HttpUtility.HtmlEncode(ex.Message));
                Response.End();
            }
        }

        private ClaimsPrincipal ValidateJwt(string token)
        {
            var issuer = ConfigurationManager.AppSettings["JwtIssuer"];
            var audience = ConfigurationManager.AppSettings["JwtAudience"];
            var signingKey = ConfigurationManager.AppSettings["JwtSigningKey"];

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(signingKey));
            var parameters = new TokenValidationParameters
            {
                ValidIssuer = issuer,
                ValidAudience = audience,
                IssuerSigningKey = key,
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateIssuerSigningKey = true,
                RequireExpirationTime = true,
                ValidateLifetime = true,
                ClockSkew = TimeSpan.FromSeconds(30)
            };

            var handler = new JwtSecurityTokenHandler();
            SecurityToken validatedToken;
            return handler.ValidateToken(token, parameters, out validatedToken);
        }
    }
}