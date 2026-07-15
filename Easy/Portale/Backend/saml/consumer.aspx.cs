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
using System;
using System.Collections.Generic;
using System.Web.Configuration;
using Backend.CommonBackend;

namespace Backend.saml
{
    /// <summary>
    /// Rappresenta le chiavi degli attributi SAML
    /// </summary>
    public static class SamlAttributeKeys {
        /// <summary>
        /// Rappresenta l'attributo uid
        /// </summary>
        public static readonly string UID =
            WebConfigurationManager.AppSettings["Saml.Attribute.UID"] ?? "urn:oid:0.9.2342.19200300.100.1.1";
        /// <summary>
        /// Rappresenta l'attributo email
        /// </summary>
        public static readonly string Email =
            WebConfigurationManager.AppSettings["Saml.Attribute.Email"] ?? "urn:oid:0.9.2342.19200300.100.1.3";
        /// <summary>
        /// Rappresenta l'attributo di affiliazione
        /// </summary>
        public static readonly string Affiliation =
            WebConfigurationManager.AppSettings["Saml.Attribute.Affiliation"] ?? "urn:oid:1.3.6.1.4.1.5923.1.1.1.1";
        /// <summary>
        /// Rappresenta il nome principale
        /// </summary>
        public static readonly string PrincipalName =
            WebConfigurationManager.AppSettings["Saml.Attribute.PrincipalName"] ?? "urn:oid:1.3.6.1.4.1.5923.1.1.1.6";
        /// <summary>
        /// Rappresenta l'attributo di appartenenza
        /// </summary>
        public static readonly string Entitlement =
            WebConfigurationManager.AppSettings["Saml.Attribute.Entitlement"] ?? "urn:oid:1.3.6.1.4.1.5923.1.1.1.7";
        /// <summary>
        /// Rappresenta l'email di affiliazione
        /// </summary>
        public static readonly string AffiliationEmail =
            WebConfigurationManager.AppSettings["Saml.Attribute.AffiliationEmail"] ?? "urn:oid:1.3.6.1.4.1.5923.1.1.1.9";
        /// <summary>
        /// Rappresenta l'identificativo persistente
        /// </summary>
        public static readonly string PersistentID =
            WebConfigurationManager.AppSettings["Saml.Attribute.PersistentID"] ?? "urn:oid:1.3.6.1.4.1.5923.1.1.1.10";
        /// <summary>
        /// Rappresenta il nome comune
        /// </summary>
        public static readonly string CN =
            WebConfigurationManager.AppSettings["Saml.Attribute.CN"] ?? "urn:oid:2.5.4.3";
        /// <summary>
        /// Rappresenta il cognome
        /// </summary>
        public static readonly string Surname =
            WebConfigurationManager.AppSettings["Saml.Attribute.Surname"] ?? "urn:oid:2.5.4.4";
        /// <summary>
        /// Rappresenta il nome di battesimo
        /// </summary>
        public static readonly string GivenName =
            WebConfigurationManager.AppSettings["Saml.Attribute.GivenName"] ?? "urn:oid:2.5.4.42";
        /// <summary>
        /// Rappresenta il nome completo visualizzato
        /// </summary>
        public static readonly string DisplayName =
            WebConfigurationManager.AppSettings["Saml.Attribute.DisplayName"] ?? "urn:oid:2.16.840.1.113730.3.1.241";
        /// <summary>
        /// Rappresenta il codice fiscale
        /// </summary>
        public static readonly string CF =
            WebConfigurationManager.AppSettings["Saml.Attribute.CF"] ?? "urn:oid:1.3.6.1.4.1.5923.1.1.1.13";
        /// <summary>
        /// Rappresenta la matricola o numero di dipendente
        /// </summary>
        public static readonly string EmployeeNumber =
            WebConfigurationManager.AppSettings["Saml.Attribute.EmployeeNumber"] ?? "urn:oid:2.16.840.1.113730.3.1.3";
    }

    public partial class consumer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            bool isInResponseTo = false;
            string partnerIdP = null;
            string userName = null;
            string authnContext = null;
            IDictionary<string, string> attributes = null;
            string targetUrl = null;

            // Processa la risposta SAML dall'identity provider
            SAMLServiceProvider.ReceiveSSO(Request, out isInResponseTo, out partnerIdP, out userName, out attributes, out targetUrl);

            String uname = "NOTRETRIEVED";
            String name = "";
            String surname = "";
            String email = "";
            String cf = "";
            String matricola = "";

            string ssoUsernameKey = WebConfigurationManager.AppSettings["ssoUsernameKey"];
            //string frontendSSOBase = WebConfigurationManager.AppSettings["frontendSSO"];

            string tmp;
            if (attributes != null) {
                if (attributes.TryGetValue(SamlAttributeKeys.UID, out tmp) && string.IsNullOrEmpty(ssoUsernameKey)) {
                    Session["samluser"] = tmp;
                    uname = tmp;
                }

                if (attributes.TryGetValue(SamlAttributeKeys.Email, out tmp) && string.Equals(ssoUsernameKey, "email", StringComparison.OrdinalIgnoreCase)) {
                    Session["samluser"] = tmp;
                    uname = tmp;
                }

                if (attributes.TryGetValue(SamlAttributeKeys.Email, out tmp)) {
                    Session["samlemail"] = tmp;
                    email = tmp;
                }

                if (attributes.TryGetValue(SamlAttributeKeys.Surname, out tmp)) {
                    surname = tmp;
                }

                if (attributes.TryGetValue(SamlAttributeKeys.CN, out tmp)) {
                    name = tmp;
                }

                if (attributes.TryGetValue(SamlAttributeKeys.GivenName, out tmp) && !string.IsNullOrWhiteSpace(tmp)) {
                    name = tmp;
                }

                if (attributes.TryGetValue(SamlAttributeKeys.CF, out tmp)) {
                    cf = tmp;
                }

                if (attributes.TryGetValue(SamlAttributeKeys.EmployeeNumber, out tmp)) {
                    matricola = tmp;
                }
            }

            // login automatica token
            // ridireziona al sito segreterie per il login automatico

            // creo una sessione temporanea che verà scambiata con il client
            String guidSession = Guid.NewGuid().ToString();
           
            SessionMDLW.createSessionSSO(guidSession, uname, name, surname, email, cf, matricola);
            String parameters = "?session=" + guidSession + "&username=" + uname;
            var frontendSSO = WebConfigurationManager.AppSettings.Get("frontendSSO") + parameters;
           
            // Redireziona il browser dell'utente verso il frontend per la login automatica
            Response.Redirect(frontendSSO);
        }
    }
}