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

using Microsoft.IdentityModel.Tokens;
using System;
using System.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace EasyWebReport
{
    public static class JwtTokenValidator
    {
        public static ClaimsPrincipal ValidateJwt(string token)
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

        public static void HandleTokenLogin(string token, out string email, out string name)
        {
            email = "";
            name = "";

            try
            {
                var principal = ValidateJwt(token);
                if (principal == null)
                    throw new Exception("Invalid token");

                var nameClaim = principal.FindFirst(ClaimTypes.Name);
                var subClaim = principal.FindFirst(JwtRegisteredClaimNames.Sub);
                var emailClaim = principal.FindFirst(ClaimTypes.Email);

                email = emailClaim?.Value ?? "";
                name = nameClaim?.Value ?? subClaim?.Value ?? principal.Identity?.Name ?? "";
                if (string.IsNullOrEmpty(name))
                    name = email.Split('@')[0];
            }
            catch { }
        }
    }
}