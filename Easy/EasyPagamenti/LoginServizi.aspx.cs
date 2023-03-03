
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


using System;
using System.Data;
using System.Web;
using metadatalibrary;
using metaeasylibrary;
using HelpWeb;
using EasyPagamentiDataSet;
using EasyPagamenti;
using EasyPagamenti.Extensions;
using EasyPagamenti.Extra;
using System.Web.UI;
using System.IO;
using meta_registry;
using meta_registryaddress;
using meta_registryreference;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using funzioni_configurazione;
using pagoPaService;
using System.Collections.Generic;
using Security;
using System.DirectoryServices;
using System.DirectoryServices.Protocols;
using System.Security.Cryptography.X509Certificates;
using q = metadatalibrary.MetaExpression;

namespace EasyPagamenti {
    /// <summary>
    /// Summary description for LoginServizi
    /// </summary>
    /// 
    // nome ente | txtDSN
    //Server | txtServer
    public partial class LoginServizi : System.Web.UI.Page {
        private void PulisciCampi() {
            txtPassword.Text = "";
            txtNomeUtente.Text = "";
            txtCodiceDipartimento.Text = "";
            Session["Utente"] = "";
            Session["PasswordUtente"] = "";
        }
        private void MostraPasswordDimenticata() {
            PasswordDimenticata.Style.Add(HtmlTextWriterStyle.Display, "block");
        }
        private DataAccess ConnectToDepartment(string codice, string user, string pwd, DateTime datacontabile) {
            string error;
            DataAccess UsrConn;
            DataAccess Conn = GetVars.GetSystemDataAccess(this, out error);

            if (codice.Trim().Length == 0) {
                labExtMessage.Text = "Non è stato selezionato alcun dipartimento";
                return null;
            }
            //Attenzione: leggere da XML IP del server e NomeDB
            //Inserire da codice NomeUtente e Password
            string filterdip = "(codicedipartimento=" + QueryCreator.quotedstrvalue(codice, true) + ")";
            DataTable CodDip = Conn.RUN_SELECT("codicidipartimenti", "*", null, filterdip, null, true);

            if ((CodDip == null) || (CodDip.Rows.Count == 0)) {
                //Dati non corretti
                WebLog.Log(this, codice + ": Codice non corretto");
                labExtMessage.Text = "Il codice inserito non è corretto.";
                return null;
            }
            if (CodDip.Rows.Count > 1) {
                //Attenzione nel DB non è garantita l'unicità dei dati.
                labExtMessage.Text = "Chiedere al Responsabile del servizio " +
                    "l'assegnazione di un nuovo Codice";
                WebLog.Log(this, "Attenzione !!! Duplicazione di codici per " + codice);
                return null;
            }

            string err = "";
            DataRow myDr = CodDip.Rows[0];
            Session["Dipartimento"] = myDr["Dipartimento"].ToString();


            //Creo la connessione.
            UsrConn = GetVars.CreateUserConn(this, myDr, user, pwd, datacontabile, out err);
            if (UsrConn == null) {
                err = "Connessione per l'utente '" + user + "' rifiutata. <br/> Controllare Nome Utente e/o Password";
                string err2 = "Connessione al db del dipartimento " + codice +
                    " non riuscita. <br/>" + err;
                labExtMessage.Text = err2;
                WebLog.Log(this, err2);
                return null;
            }
            return UsrConn;
        }

        public void RidirezionaSuWebPayment(string logParam) {
            string utente = "";
            string dipartimento = "";
            DateTime datascadenza = DateTime.MinValue;
            object idwebpayment = null;

            ////"?logParam=username|dipartimento|expiringdate|curr_idwebpayment|";
            object[] logParams = logParam.Split('|');
            utente = logParams[0].ToString();
            dipartimento = logParams[1].ToString();
            string scadenza_str = logParams[2].ToString();
            datascadenza = DateTime.ParseExact(scadenza_str, "dd/MM/yyyy HH.mm.ss.ffffff", System.Globalization.CultureInfo.InvariantCulture);

            idwebpayment = logParams[3].ToString();

            if (DateTime.Now > datascadenza) //Test SARA
                return;
            Session["comebackpaymentrow"] = idwebpayment;
            ApplicationState APS = ApplicationState.GetApplicationState(this);
            MetaData M = APS.Dispatcher.Get("webpayment");
            M.edit_type = "defaultpagamenti";
            APS.CallPage(this, M, false);
        }


        private void mostraLinkResend() {
            LinkResend.Style.Add(HtmlTextWriterStyle.Display, "block");
            //LinkResend.Style.Add(HtmlTextWriterStyle.Width, "150px");
            LinkResend.Style.Add(HtmlTextWriterStyle.MarginRight, "auto");
            LinkResend.Style.Add(HtmlTextWriterStyle.MarginTop, "0px");
        }

        private void mostraLinkActivate() {
            LinkActivate.Style.Add(HtmlTextWriterStyle.Display, "block");
            //LinkResend.Style.Add(HtmlTextWriterStyle.Width, "150px");
            LinkActivate.Style.Add(HtmlTextWriterStyle.MarginRight, "auto");
            LinkActivate.Style.Add(HtmlTextWriterStyle.MarginTop, "0px");
        }

        protected void Page_Load(object sender, System.EventArgs e) {
            
            string errorNomeUniversita = "";
            DataTable t = GetDataSystemDb.GetConfigConn("config", "nome_universita", "", this.Page, out errorNomeUniversita);
            if (t != null && t.Rows.Count > 0) {
                Session["nome_universita"] = t.Rows[0]["nome_universita"].ToString();
            }

            mostraLinkResend();
            mostraLinkActivate();
            // Controlla se è' una callback da Pagamento immediato
            if (Request.Params["logParam"] != null && Request.Params["logParam"].ToString() != "") {
                //Controlla il codice, se non è coerente esce.
                //= "?logParam=logparamCript|&code";
                string logParam = Request.Params["logParam"].ToString();
                object[] logParams = logParam.Split('|');
                string logparamCript = logParams[0].ToString();
                string codice_comeback = Request.Params["code"].ToString();
                string codicepercontrollo = configManager.getCfg("codicepercontrollo").ToString();
                string codice_curr = PagoPaService.SecurityCode(logparamCript, codicepercontrollo);
                if (codice_comeback != codice_curr)
                    return;

                byte[] B = QueryCreator.StringToByteArray(logparamCript);
                string logparamDecript = DataAccess.DecryptString(B);
                RidirezionaSuWebPayment(logparamDecript);
            }

            lblMessaggio.Text = "";
            labExtMessage.Text = "";
            DateTime D = DateTime.Now;
            DataAccess DepConn = null;
            string depcode_given = configManager.getCfg("codicedipartimento").ToString();
            txtCodiceDipartimento.Text = depcode_given;
            string ErroreDepConn = string.Empty;

            if (!IsPostBack) {
                txtDataContabile.Text = DateTime.Now.ToShortDateString();
            }
            DepConn = AccessKit.GetDepartmentConn(depcode_given, this.Page, out ErroreDepConn);
            if (!string.IsNullOrEmpty(ErroreDepConn)) {
                lblMessaggio.Text = ErroreDepConn;
                return;
            }

            string errorNascondiVoce = "";
            t = GetDataSystemDb.GetConfigConn("config", "nascondi_voce_class_merc", "", this.Page, out errorNascondiVoce);
            if (t != null && t.Rows.Count > 0) {
                Session["nascondi_voce_class_merc"] = t.Rows[0]["nascondi_voce_class_merc"].ToString();
            }

            if (Session["DoLogon"] == null || !((bool)Session["DoLogon"])) {
                if (IsPostBack) {
                    MetaPage.SessionTimeOut(this);
                    return;
                } else {
                    lblMessaggio.Text = "Applicazione non inizializzata correttamente.";
                    Response.Redirect("Default.aspx");
                    return;
                }
            }

            if (IsPostBack) {
                if (txtNomeUtente.Text == "") {
                    lblMessaggio.Text = "Il nome utente è un campo obbligatorio.";
                    return;
                }
                if (txtPassword.Text == "") {
                    lblMessaggio.Text = "La password è un campo obbligatorio.";
                    return;
                }
            }

            if (IsPostBack && Request != null) {

                //istanziazione SecurityManager a livello di applicazione nella pagina
                /*if (this.Application.Get("securityManager") == null) {
                    this.Application.Add("securityManager", new SecurityManager());
                }*/

                //l'istanziazione è avvenuta una sola volta in Global.asax
                SecurityManager securityManager = (SecurityManager)Application.Get("securityManager");

                string NomeUtente = txtNomeUtente.Text;
                string PasswordC = txtPassword.Text;

                SecurityManager.LoginState loginState = securityManager.loginState(NomeUtente);

                //login disabilitata per tentativi eccessivi
                if (loginState == SecurityManager.LoginState.Denied) {
                    //MostraPasswordDimenticata();
                    lblMessaggio.Text = "Utenza disabilitata, contattare l'amministratore.";
                    return;
                }
                //login temporaneamente disabilitata
                if (loginState == SecurityManager.LoginState.Delayed) {
                    //MostraPasswordDimenticata();
                    lblMessaggio.Text = "Utenza temporaneamente disabilitata, riprovare più tardi.";
                    return;
                }

                Meta_EasyDispatcher dispatcher = new Meta_EasyDispatcher(DepConn);

                var metaRegistry = dispatcher.Get("registry");
                var metaReference = dispatcher.Get("registryreference");

                var ds = new dsmeta_registry();

                var getData = new GetData();
                getData.InitClass(ds, dispatcher.Conn, "registryreference");
                CQueryHelper QHC = new CQueryHelper();
                var filterByUsername = QHC.CmpEq("userweb", NomeUtente);
                getData.GET_PRIMARY_TABLE(filterByUsername);

                var referenceRow = ds.registryreference.First();
                if (referenceRow == null) {
                    //MostraPasswordDimenticata();
                    lblMessaggio.Text = "Credenziali non valide.";
                    return;
                } else {
                    getData.DO_GET(false, referenceRow);
                }

                var email = referenceRow.email;
                var iterations = referenceRow.iterweb;
                var salt = referenceRow.saltweb.ToBytes();
                var hash = referenceRow.passwordweb.ToBytes();
                var idreg = referenceRow.idreg;
                string cf = DepConn.readValue("registry", q.eq("idreg", idreg), "cf").ToString();
                if (!Password.Verify(PasswordC, salt, hash, iterations ?? 0)) {
                    //segnalazione fallimento a SecurityManager
                    securityManager.loginFailure(NomeUtente);
                    PulisciCampi();
                    //MostraPasswordDimenticata();
                    lblMessaggio.Text = "Credenziali non valide.";
                    return;
                }

                //segnalazione successo a SecurityManager
                securityManager.loginSuccess(NomeUtente);
                //rigenerazione token di sessione
                securityManager.regenSessionID();

                if (referenceRow.activeweb != "S") {
                    lblMessaggio.Text = "L'utenza non è stata ancora attivata.";
                    return;
                }

                //*******************************************************************************
                //** blocco di codice che serve ad impostare l'identità nel token che in origine
                //** veniva passato al client
                //** viene impostata anche l'identità per l'applicazione che potrebbe essere usata
                //** in altre occasioni, per cui non rimuovere fino al completamento dell'applicazione


                //var registryRow = referenceRow.GetParentRow("FK_registryreference_registry");
                //var denominazione = registryRow.Field<string>("title");

                //var clientaddress = HttpContext.Current.Request.UserHostAddress;
                //var userdata = new Identity(clientaddress, NomeUtente, email, denominazione);
                //var token = Token.Encode(userdata);

                //return Content(HttpStatusCode.OK, token);
                //********************************************************************************


                //DataAccess newConn = ConnectToDepartment("amministrazione", "amministrazione", "**********", DateTime.Now);

                DataAccess newConn = ConnectToDepartment(depcode_given, null, null, D);
                //** Autenticazione avvenuta con successo
                //**
                //**
                ApplicationState APS = new ApplicationState(dispatcher, newConn);
                APS.SaveApplicationState(this);

                /**/
                string error;
                DataAccess sysConn = GetVars.GetSystemDataAccess(this, out error);
                if (sysConn == null) {
                    lblMessaggio.Text = "Connessione al DB di sistema non riuscita.";
                    WebLog.Log(this, "Connessione al db di sistema non riuscita.");
                    return;
                }
                //Connessione al Server.Database privato del software.
                Easy_DataAccess UsrConn = GetVars.GetUserConn(this);
                if (UsrConn == null) {
                    sysConn.Close();
                    return; //Messaggio già viualizzato da ConnectToDepartment()
                }
                QueryHelper QHS = UsrConn.GetQueryHelper();

                DataTable Contatto = UsrConn.RUN_SELECT("registryreferenceview", "*", null, QHS.CmpEq("userweb", NomeUtente), null, false);
                if (Contatto.Rows.Count == 0) {
                    //Dati non corretti
                    labExtMessage.Text = "Nome utente non corretto";
                    WebLog.Log(this, "Nome :" + NomeUtente + " non corretto");
                    return;
                }
                // Controllo pagamenti_ldap di web_config
                /**/

                DataTable webconfig = UsrConn.RUN_SELECT("web_config", "*", null, null, null, false);
                DataRow rwebconf = webconfig.Rows[0];
                bool pagamenti_ldap = (rwebconf["payment_ldap"].ToString().ToUpper() == "S");
                if (pagamenti_ldap) {
                    //int nShowcaseForLDAP = UsrConn.RUN_SELECT_COUNT("showcase", QHS.CmpEq("userldapvisible", "S"), true);
                    //Se esiste almeno una vetrina con userldapvisible a true, allora interrogo il server LDAP usando il codice fiscale dell'utente loggato
                    // e controllo se questo è presente in active directory.
                    // Memorizzo questa informazion(presente/assente) in una variabile di sessione
                    // if (nShowcaseForLDAP == 0) return;
                    VerifyActivedirectory(UsrConn, cf);
                }

                lblMessaggio.Text = "Connesso";
                labExtMessage.Text = "Connessione al server effettuata.";

                Session["TipoUtente"] = "utente";
                Session["Utente"] = NomeUtente;
                Session["CodiceUtente"] = Contatto.Rows[0]["idreg"];
                Session["PasswordUtente"] = PasswordC;
                Session["SavedFlowChart"] = null;
                Session["SavedHomePage"] = "LoginServizi.aspx";
                Response.Redirect("IndiceReport.aspx");
            }

        }


        public void VerifyActivedirectory(DataAccess UsrConn, object cf) {
            //Se esiste almeno una vetrina con userldapvisible a true, allora interrogo il server LDAP usando il codice fiscale dell'utente loggato
            // e controllo se questo è presente in active directory.
            // Memorizzo questa informazion(presente/assente) in una variabile di sessione
            Session["ldap_maschera"] = 0;
            if (UsrConn.count("ldapmulticonfig", null) == 0) return;

            //ldapmultiauth lauth = new ldapmultiauth(UsrConn);
            DataTable T = UsrConn.RUN_SELECT("ldapmulticonfig", "*", null, null, null, false);

            foreach (DataRow R in T.Rows) {
                //getconfig(R); 
                bool userexistsinAd = false;
                if (!Authenticate(R, cf, UsrConn, out userexistsinAd)) {
                    // autenticazione fallita
                    WebLog.Log(this, "NON Autenticato");
                    continue;
                }
                //L'utente è associato a quel servizio
                if (userexistsinAd) {
                    Session["ldap_maschera"] = CfgFn.GetNoNullInt32(Session["ldap_maschera"]) | CfgFn.GetNoNullInt32(R["mask"]);// si crea la mashera OR con i codici
                    WebLog.Log(this, "Autenticato");
                }
            }
        }

        public string ErrorMsg = String.Empty;

        public bool Authenticate(DataRow rLDAPmulticonfig, object cf, DataAccess conn, out bool userexistsinAd) {
            string username = rLDAPmulticonfig["username"].ToString();
            string password = rLDAPmulticonfig["userpwd"].ToString();
            string servername = rLDAPmulticonfig["servername"].ToString();
            int port = CfgFn.GetNoNullInt32(rLDAPmulticonfig["port"]);
            int ldapversion = CfgFn.GetNoNullInt32(rLDAPmulticonfig["version"]);
            string userpath = rLDAPmulticonfig["userpath"].ToString();
            string json_authentication = rLDAPmulticonfig["json_authentication"].ToString();
            bool usessl = false;
            bool verifyservercertificate = false;
            bool use_ntlm = false;

            if (rLDAPmulticonfig["usessl"].ToString() == "S")
                usessl = true;
            else
                usessl = false;
            if (rLDAPmulticonfig["verifyservercertificate"].ToString() == "S")
                verifyservercertificate = true;
            else
                verifyservercertificate = false;

            if (userpath.IndexOf("<%USE_NTLM%>") >= 0) {
                use_ntlm = true;
            } else {
                use_ntlm = false;
            }

            userexistsinAd = false;
            //userpath:     uid=<%USERID%>|ou=STUDENTI,ou=studenti,dc=unipmn,dc=it
            string userDN = userpath.Replace("<%USERID%>", username).Replace("<%USE_NTLM%>", "");
            QueryHelper QHS = conn.GetQueryHelper();
            //Esegue prima la login in Username e Userpwd
            ErrorMsg = "";
            string[] parts = userDN.Split('|');
            DirectoryEntry DEroot = null;
            string filterroot = "";
            string filteruid = "";
            if (parts.Length > 1) {
                try {
                    filteruid = parts[0];
                    filterroot = parts[1];
                } catch (Exception E) {
                    ErrorMsg = E.ToString();
                    return false;
                }
            }

            LdapConnection ldapconn = new LdapConnection(new LdapDirectoryIdentifier(servername, port), new System.Net.NetworkCredential(username, password));

            string ldaproot_ = "LDAP://" + servername + ":" + port + "/" + filterroot; //equivale alla stringa di sotto
            //ldaproot_ = "LDAP://172.25.1.94:389/ou=STUDENTI,ou=studenti,dc=unipmn,dc=it";

            DEroot = new DirectoryEntry(ldaproot_, username, password);
            DEroot.AuthenticationType = AuthenticationTypes.FastBind;
            ldapconn.SessionOptions.SecureSocketLayer = usessl;
            ldapconn.SessionOptions.ProtocolVersion = ldapversion;

            if (use_ntlm) {
                ldapconn.AuthType = AuthType.Ntlm;
            } else {
                ldapconn.AuthType = AuthType.Basic;
            }

            if (verifyservercertificate)
                ldapconn.SessionOptions.VerifyServerCertificate = new VerifyServerCertificateCallback(ServerCallback);

            try {
                ldapconn.Bind();
                if ((cf != null) && (DEroot != null)) {
                    //Controlla la presenza in Active directory
                    DirectorySearcher Dsearch = new DirectorySearcher(DEroot);
                    Dsearch.SearchScope = System.DirectoryServices.SearchScope.Subtree;
                    Dsearch.Filter = json_authentication.Replace("<%CF%>", cf.ToString()); //Deve leggere il campo json_authentication dalla tabella ldapmulticonfig.
                    SearchResult result = Dsearch.FindOne();

                    if (result != null) {
                        WebLog.Log(this, "CF presente in Active directory");
                        //CF presente in Active directory
                        userexistsinAd = true;
                    }
                }
                return true;
            } catch (Exception ex) {
                WebLog.Log(this, "catch:" + ex.Message + ". ");
                ErrorMsg = "Nome utente o password errati. Account (multi)LDAP non trovato.";
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

        public bool DatiValidi(DateTime T, DataAccess DA) {
            int esercizio = T.Year;
            string filteresercizio = "(ayear=" + QueryCreator.quotedstrvalue(esercizio, true) + ")";
            DataTable EsercizioTable =
                DA.RUN_SELECT("accountingyear", "*", null, filteresercizio, null, true);

            if (EsercizioTable.Rows.Count == 0)
                return false;
            return true;
        }
        bool CambioDataConsentita(DataAccess DA, DateTime newDate) {
            object idcustomuser = DA.GetSys("idcustomuser");
            object ayear = newDate.Year;
            if (idcustomuser == DBNull.Value) return true;
            QueryHelper QHS = DA.GetQueryHelper();
            string filterall = QHS.CmpEq("idcustomuser", idcustomuser);
            if (DA.RUN_SELECT_COUNT("flowchartuser", filterall, false) == 0) return true; //fuori dall'organigramma
            string filteranno = QHS.Like("idflowchart", ayear.ToString().Substring(2) + "%");
            string filterdate = QHS.AppAnd(filterall,
                filteranno,
                QHS.NullOrLe("start", newDate), QHS.NullOrGe("stop", newDate));
            if (DA.RUN_SELECT_COUNT("flowchartuser", filterdate, false) == 0) return false;
            object oggi = DA.DO_SYS_CMD("select getdate()");
            string filternow = QHS.AppAnd(filterall, filteranno,
                        QHS.NullOrLe("start", oggi), QHS.NullOrGe("stop", newDate));
            if (DA.RUN_SELECT_COUNT("flowchartuser", filternow, false) == 0) return false;
            return true;
        }
    }
}