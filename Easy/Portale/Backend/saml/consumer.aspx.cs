
/*
Easy
Copyright (C) 2022 Universit� degli Studi di Catania (www.unict.it)
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
    public partial class consumer : System.Web.UI.Page
    {
        public const string AttributeUID = "urn:oid:0.9.2342.19200300.100.1.1";
        public const string AttributeEmail = "urn:oid:0.9.2342.19200300.100.1.3";

        public const string AttributeAffiliation = "urn:oid:1.3.6.1.4.1.5923.1.1.1.1";
        public const string AttributePrincipalName = "urn:oid:1.3.6.1.4.1.5923.1.1.1.6";
        public const string AttributeEntitlement = "urn:oid:1.3.6.1.4.1.5923.1.1.1.7";
        public const string AttributeAffiliationEmail = "urn:oid:1.3.6.1.4.1.5923.1.1.1.9";
        public const string AttributePersistentID = "urn:oid:1.3.6.1.4.1.5923.1.1.1.10";
        //public const string AttributeUnknown = "urn:oid:1.3.6.1.4.1.5923.1.5.1.1";

        //public const string AttributeUnknown = "urn:oid:1.3.6.1.4.1.25178.1.2.9";
        //public const string AttributeUnknown = "urn:oid:1.3.6.1.4.1.25178.1.2.10";

        public const string AttributeCN = "urn:oid:2.5.4.3";
        public const string AttributeSurname = "urn:oid:2.5.4.4";
        //public const string AttributeUnknown1 = "urn:oid:2.5.4.41";
        public const string AttributeGivenName = "urn:oid:2.5.4.42";

        public const string AttributeDisplayName = "urn:oid:2.16.840.1.113730.3.1.241";

        public const string AttributeCF = "urn:oid:1.3.6.1.4.1.5923.1.1.1.13";
        public const string AttributeEmployeeNumber = "urn:oid:2.16.840.1.113730.3.1.3";


        protected void Page_Load(object sender, EventArgs e)
        {
            bool isInResponseTo = false;
            string partnerIdP = null;
            string userName = null;
            IDictionary<string, string> attributes = null;
            string targetUrl = null;

            // Processa la risposta SAML dall'identity provider
            SAMLServiceProvider.ReceiveSSO(Request, out isInResponseTo, out partnerIdP, out userName, out attributes, out targetUrl);

            String uname = "";
            String name = "";
            String surname = "";
            String email = "";
            String cf = "";
            String matricola = "";

            // Imposta l'identificativo utente nelle variabili di sessione.
            if (attributes.ContainsKey(AttributeUID)){
                Session["samluser"] = attributes[AttributeUID];
                uname = attributes[AttributeUID];
            }

            if (attributes.ContainsKey(AttributeEmail)){
                Session["samlemail"] = attributes[AttributeEmail];
                email = attributes[AttributeEmail];
            }

            if (attributes.ContainsKey(AttributeSurname)){
                surname = attributes[AttributeSurname];
            }

            if (attributes.ContainsKey(AttributeCN)){
                name = attributes[AttributeCN];
            }
            if (attributes.ContainsKey(AttributeCF)){
                cf = attributes[AttributeCF];
            }
            if (attributes.ContainsKey(AttributeEmployeeNumber)){
                matricola = attributes[AttributeEmployeeNumber];
            }


            // login automatica token
            // ridireziona al sito segreterie per il login automatico

            // creo una sessione temporanea che ver� scambiata con il client
            String guidSession = Guid.NewGuid().ToString();
           
            SessionMDLW.createSessionSSO(guidSession, uname, name, surname, email, cf, matricola);
            String parameters = "?session=" + guidSession + "&username=" + uname;
            var frontendSSO = WebConfigurationManager.AppSettings.Get("frontendSSO") + parameters;
           
            // Redireziona il browser dell'utente verso il frontend per la login automatica
            Response.Redirect(frontendSSO);
        }
    }
}