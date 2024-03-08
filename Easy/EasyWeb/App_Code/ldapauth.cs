
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


using System;
using System.Data;
using System.Configuration;
using System.DirectoryServices;
using System.DirectoryServices.Protocols;
using System.Security.Cryptography.X509Certificates;
using metadatalibrary;
using metaeasylibrary;
using funzioni_configurazione;

/// <summary>
/// Classe per l'autenticazione LDAP
/// 
/// </summary>
/// 

namespace EasyWebReport {
    public class ldapauth {
        public string servername;
        public int port;
        public bool usessl;
        public int ldapversion;
        public bool use_ntlm;
        public string userpath;
        public bool verifyservercertificate;
        public string user_decoded;
        public bool usesmail = false;
        private DataAccess conn;
        public string ErrorMsg;

        public ldapauth(DataAccess Connection) {
            /// <summary>
            /// Costruttore con unico parametro DataAccess Connection
            /// </summary>
            conn = Connection;

        }

        public bool getconfig() {
            if (conn.count("ldapconfig", null) == 0) {
                ErrorMsg = "Configurazione LDAP mancante";
                return false;
            }

            /// <summary>
            /// Legge la configurazione dalla tabella ldapconfig
            /// utilizzando i campi seguenti:
            /// servername: nome del server LDAP o suo indirizzo ip
            /// port: porta TCP del server LDAP
            /// version: versione LDAP
            /// usessl: utilizza SSL
            /// verifyservercertificate: verifica il certificato del server
            /// </summary>
            DataTable T = conn.RUN_SELECT("ldapconfig", "*", null, null, null, false);
            if (T != null && T.Rows.Count != 0) {
                servername = T.Rows[0]["servername"].ToString();
                port = CfgFn.GetNoNullInt32(T.Rows[0]["port"]);
                ldapversion = CfgFn.GetNoNullInt32(T.Rows[0]["version"]);
                userpath = T.Rows[0]["userpath"].ToString();

                if (T.Rows[0]["usessl"].ToString() == "S")
                    usessl = true;
                else
                    usessl = false;
                if (T.Rows[0]["verifyservercertificate"].ToString() == "S")
                    verifyservercertificate = true;
                else
                    verifyservercertificate = false;

                usesmail = false;
                if (userpath.IndexOf("<%USERID_FROMEMAIL%>") >= 0) {
                    usesmail = true;
                }


                if (userpath.IndexOf("<%USE_NTLM%>") >= 0) {
                    use_ntlm = true;
                }
                else {
                    use_ntlm = false;
                }

                return true;
            }
            else {
                ErrorMsg = "Configurazione LDAP mancante";
                return false;
            }
        }


        public bool ServerCallback(LdapConnection connection, X509Certificate certificate) {
            /// <summary>
            /// Se verifyservercertificate è true (ossia sulla tabella ldapconfig è posto ad "S")
            /// viene invocato questo metodo di callback che ritorna sempre true.
            /// è servito nel caso specifico di OpenLDAP su LE in cui usano l'SSL, ma il certificato
            /// va letto e non verificato (quindi è sufficiente far ritornare sempre true). 
            /// Se si deve implementare una verifica è necessario fare override di questo metodo.            
            /// </summary>

            return true;
        }

        /// <summary>
        /// Ritorna true se l'utente LDAP avente username e password è autenticato
        /// false altrimenti. Se verifyservercertificate è true assegna la funzione di callback
        /// </summary>
        public bool Authenticate(string username, string password) {
            user_decoded = username;
            //return true;

            string userDN = userpath.Replace("<%USERID%>", username).Replace("<%USE_NTLM%>", "");
            QueryHelper QHS = conn.GetQueryHelper();
            if (userDN.IndexOf("<%USERID_FROMEMAIL%>") >= 0) {
                DataTable users = conn.RUN_SELECT("virtualuser", "*", null, QHS.CmpEq("email", username), null, true);
                if (users.Rows.Count > 0) {
                    user_decoded = users.Rows[0]["username"].ToString().Trim();
                    userDN = userDN.Replace("<%USERID_FROMEMAIL%>", user_decoded);
                }
            }


            ErrorMsg = "";
            string[] parts = userDN.Split('|');
            if (parts.Length > 1) {
                try {
                    //ldapconn.AuthType = AuthType.Anonymous;

                    string filteruid = parts[0];
                    string filterroot = parts[1];
                    string ldaproot = "LDAP://" + servername + ":" + port + "/" + filterroot;
                    DirectoryEntry DEroot = new DirectoryEntry(ldaproot);
                    DEroot.AuthenticationType = AuthenticationTypes.FastBind;

                    DirectorySearcher DSE = new DirectorySearcher(DEroot);
                    DSE.SearchScope = System.DirectoryServices.SearchScope.Subtree;

                    DSE.Filter = filteruid;
                    SearchResultCollection SRC = DSE.FindAll();
                    if (SRC.Count != 1) {
                        ErrorMsg = "User LDap non trovato";
                        return false;
                    }

                    userDN = SRC[0].Path.Replace("LDAP://" + servername + ":" + port + "/", "");
                }
                catch (Exception E) {
                    ErrorMsg = E.ToString();
                    return false;
                }
            }


            LdapConnection ldapconn = new LdapConnection(new LdapDirectoryIdentifier(servername, port));
            ldapconn.Credential = new System.Net.NetworkCredential();



            ldapconn.Credential = new System.Net.NetworkCredential(userDN, password);

            ldapconn.SessionOptions.SecureSocketLayer = usessl;
            ldapconn.SessionOptions.ProtocolVersion = ldapversion;

            if (use_ntlm) {
                ldapconn.AuthType = AuthType.Ntlm;
            }
            else {
                ldapconn.AuthType = AuthType.Basic;
            }


            if (verifyservercertificate)
                ldapconn.SessionOptions.VerifyServerCertificate = new VerifyServerCertificateCallback(ServerCallback);

            try {
                ldapconn.Bind();
                return true;
            }
            catch (Exception ex) {
                ErrorMsg = "Nome utente o password errati. Account LDAP non trovato.";
                return false;
            }

        }
    }
}
