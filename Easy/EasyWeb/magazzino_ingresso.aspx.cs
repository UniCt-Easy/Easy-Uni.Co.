/*
    Easy
    Copyright (C) 2020 Universit√† degli Studi di Catania (www.unict.it)
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
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using metadatalibrary;
using metaeasylibrary;
using HelpWeb;
using System.IO;

namespace EasyWebReport {
    public partial class magazzino_ingresso : System.Web.UI.Page {

        void ConnectToDepartment(string codice, string user, string pwd, DateTime datacontabile) {
            string error;
            DataAccess Conn = GetVars.GetSystemDataAccess(this, out error);

            if (codice.Trim().Length == 0) {
                labExtMessage.Text = "Non Ë stato selezionato alcun dipartimento";
                return;
            }
            //Attenzione: leggere da XML IP del server e NomeDB
            //Inserire da codice NomeUtente e Password
            string filterdip = "(codicedipartimento=" + QueryCreator.quotedstrvalue(codice, true) + ")";
            DataTable CodDip = Conn.RUN_SELECT("codicidipartimenti", "*", null, filterdip, null, true);

            if ((CodDip == null) || (CodDip.Rows.Count == 0)) {
                //Dati non corretti
                WebLog.Log(this, codice + ": Codice non corretto");
                labExtMessage.Text = "Il codice inserito non Ë corretto.";
                return;
            }
            if (CodDip.Rows.Count > 1) {
                //Attenzione nel DB non Ë garantita l'unicit‡ dei dati.
                labExtMessage.Text = "Chiedere al Responsabile del servizio " +
                    "l'assegnazione di un nuovo Codice";
                WebLog.Log(this, "Attenzione !!! Duplicazione di codici per " + codice);
                return;
            }

            string err = "";
            DataRow myDr = CodDip.Rows[0];
            Session["Dipartimento"] = myDr["Dipartimento"].ToString();


            //Creo la connessione.
            DataAccess UsrConn = GetVars.CreateUserConn(this, myDr, user, pwd, datacontabile, out err);
            if (UsrConn == null) {
                err = "Connessione per l'utente '" + user + "' rifiutata. Controllare Nome Utente e/o Password";
                string err2 = "Connessione al db del dipartimento " + codice +
                    " non riuscita. <br/>" + err;
                labExtMessage.Text = err2;
                WebLog.Log(this, err2);
                return;
            }

        }

        protected void Page_Load(object sender, EventArgs e) {
            //Master.SetTitle("WebEasy - Accesso Servizi Dipartimento  ");
            lblMessaggio.Text = "";
            labExtMessage.Text = "";

          

            if (!Page.IsPostBack || Page.Session.IsNewSession) {
                Session["utente"] = "";
                Session["Responsabile"] = "";
                Session["Fornitore"] = "";
                Session["CodiceResponsabile"] = null;
                Session["CodiceFornitore"] = null;

            }

            if (Request != null) {
                if (Request.Params["x"] != null && Request.Params["x"].ToString() != "") {
                    Session["DepCode"] = Request.Params["x"];
                }
            }

            if (Session["DepCode"] == null || Session["DepCode"].ToString() == "") {
                lblMessaggio.Text = "E' necessario chiamare la pagina magazzino_in.aspx con il parametro dep=codice dipartimento";
                WebLog.Log(this, "Parametro dep non fornito.");
                return;

            }

            //if (Session["DoLogon"] == null || !((bool)Session["DoLogon"])) {
            //    lblMessaggio.Text = "Applicazione non inizializzata correttamente.";
            //    WebLog.Log(this, "Applicazione non inizializzata correttamente.");
            //    return;
            //}

            DataSet Cfg = GetVars.GetConfigDataSet(this);
            if (Cfg.Tables[0].Rows.Count == 0) {
                lblMessaggio.Text = "Servizio non installato correttamente. Manca il file di configurazione.";
                WebLog.Log(this, "Connessione al db di sistema non riuscita.");
                return;
            }
            MetaMaster MM = Master as MetaMaster;
            //if (MM != null) MM.ShowClientMessage("NINO", false);

            string error;

            DataAccess Conn = GetVars.GetSystemDataAccess(this, out error);
            if (Conn == null) {
                //lblMessaggio.Text = "Connessione al DB di sistema non riuscita." + error;
                //Attenzione qui l'errore contiene la password del Database !
                lblMessaggio.Text = "Connessione al DB di sistema non riuscita.";
                WebLog.Log(this, "Connessione al db di sistema non riuscita.");
                return;
            }
            lblMessaggio.Text = "Il servizio Web Ë attivo";
            GetVars.ClearUserConn(this);
            MetaMaster master = Page.Master as MetaMaster;
            master?.setUniversita(Session["system_config_nome_universita"] as string);

            if (!Page.IsPostBack) {
                ldapauth ldpauth = new ldapauth(Conn);
                if (!ldpauth.getconfig()) {
                    rbTipuUtente.Items.RemoveAt(3);
                }
            }

            //WebLog.Log(this, "Visualizza Login_Servizi");

            DateTime D = DateTime.Now;

            if (IsPostBack) {
                if (txtNomeUtente.Text == "") {
                    lblMessaggio.Text = "Il nome utente Ë un campo obbligatorio.";
                    //MM.ShowClientMessage("Il nome utente Ë un campo obbligatorio.", "Errore",
                    //          System.Windows.Forms.MessageBoxButtons.OK);

                    return;
                }
                if (txtPassword.Text == "") {
                    lblMessaggio.Text = "La password Ë un campo obbligatorio.";
                    //MM.ShowClientMessage("La password Ë un campo obbligatorio.", "Errore",
                    //        System.Windows.Forms.MessageBoxButtons.OK);

                    return;
                }
            }

            if (IsPostBack && Request != null) {
                //Cerco prima nella tabella contatto e poi nella tabella responsabile.
                string NomeUtente = txtNomeUtente.Text;
                string Password = txtPassword.Text; // Request.Form["txtPassword"].ToString();

                if (rbTipuUtente.SelectedValue == "1" || rbTipuUtente.SelectedValue == "2") {
                    //Responsabile o Fornitore
                    ConnectToDepartment(Session["DepCode"].ToString(), null, null, D);
                }

                if (rbTipuUtente.SelectedValue == "3") {//Utente dell'applicazione
                    ConnectToDepartment(Session["DepCode"].ToString(), NomeUtente, txtPassword.Text, D);

                }

                bool ldapauthok = false;

                if (rbTipuUtente.SelectedValue == "4") { // Utente LDAP
                    ldapauth lauth = new ldapauth(Conn);
                    if (!lauth.getconfig()) {
                        // Nessuna configurazione LDAP
                        lblMessaggio.Text = lauth.ErrorMsg;
                        return;
                    }
                    else {
                        if (!lauth.Authenticate(NomeUtente, txtPassword.Text)) {
                            // autenticazione fallita
                            lblMessaggio.Text = lauth.ErrorMsg;
                            return;
                        }
                        else {
                            // autenticazione LDAP riuscita
                            NomeUtente = lauth.user_decoded;
                            ConnectToDepartment(Session["DepCode"].ToString(), null, null, D);
                            ldapauthok = true;
                        }
                    }


                }



                //Connessione al Server.Database privato del software.
                Easy_DataAccess UsrConn = GetVars.GetUserConn(this);

                if (UsrConn == null) return; //Messaggio gi‡ viualizzato da ConnectToDepartment()
                QueryHelper QHS = UsrConn.GetQueryHelper();



                string user = null;
                string forename = null;
                string lastname = null;
                string cf = null;
                string email = null;



                if (rbTipuUtente.SelectedValue == "3") {
                    if (!CambioDataConsentita(UsrConn, D)) {
                        UsrConn.Close();
                        labExtMessage.Text = "Accesso non consentito in tale data \rin base alla gestione della sicurezza.";
                        //                        MM.ShowClientMessage("Accesso non consentito in tale data in base alla gestione della sicurezza.", "Errore",
                        //                                  System.Windows.Forms.MessageBoxButtons.OK);
                        lblMessaggio.Text = "Accesso negato";
                        return;
                    }
                }
                if (UsrConn.Open() == false) {
                    //Il Server del Dipartimento non Ë in rete. 
                    //Il servizio non Ë disponibile in quanto il computer potrebbe essere spento.
                    labExtMessage.Text = "Il Server del Dipartimento non risponde.\r" +
                        "Potrebbe essere spento o momentaneamente fuori rete. \r" +
                        "Provi in seguito";
                    txtNomeUtente.ReadOnly = true;
                    WebLog.Log(this, "Il Server del dipartimento non risponde.");
                    return;
                }

                UsrConn.Close();
                Meta_EasyDispatcher Disp = new Meta_EasyDispatcher(UsrConn);
                ApplicationState APS = new ApplicationState(Disp, UsrConn);

                string path = this.MapPath(".");
                string filename = Path.Combine(path, "proxyserver.html");
                if (File.Exists(filename)) {
                    StreamReader SR = new StreamReader(filename);
                    string webauth = SR.ReadToEnd();
                    webauth = webauth.Replace("\n", "").Replace("\r", "").Trim();
                    APS.webautorithy = webauth;
                    SR.Close();
                }


                APS.SaveApplicationState(this);
                labExtMessage.Text = "Connessione al server effettuata.";

                if (rbTipuUtente.SelectedValue == "1") {
                    int countresp = UsrConn.RUN_SELECT_COUNT("manager",
                            QHS.CmpEq("userweb", NomeUtente), false);
                    if (countresp > 1) {
                        lblMessaggioPass.Text = "Chiedere al Segreterio Amministrativo l'assegnazione di una nuova login";
                        WebLog.Log(this, "Attenzione !!! Login assegnata a piu responsabili");
                        return;
                    }
                    DataTable Responsabile = UsrConn.RUN_SELECT("manager", "*", null,
                         QHS.AppAnd(QHS.CmpEq("userweb", NomeUtente), QHS.CmpEq("passwordweb", Password)), null, false);
                    if (Responsabile.Rows.Count == 0) {
                        //Dati non corretti
                        labExtMessage.Text = "Nome utente o password non sono corretti.";
                        WebLog.Log(this, "Nome Resp:" + NomeUtente + " e password:" + Password + " non corretti");
                        return;
                    }
                    Session["LoginResponsabile"] = NomeUtente;
                    Session["PasswordResponsabile"] = Password;
                    Session["Responsabile"] = Responsabile.Rows[0]["title"].ToString();
                    Session["CodiceResponsabile"] = Responsabile.Rows[0]["idman"];
                    Session["TipoUtente"] = "responsabile";
                    WebLog.Log(this, "Riconosciuto responsabile: " + Session["Responsabile"].ToString());

                }

                if (rbTipuUtente.SelectedValue == "2") {
                    int countforn = UsrConn.RUN_SELECT_COUNT("registryreferenceview",
                            QHS.CmpEq("userweb", NomeUtente), false);
                    if (countforn > 1) {
                        lblMessaggioPass.Text = "Chiedere al Segreterio Amministrativo l'assegnazione di una nuova login";
                        WebLog.Log(this, "Attenzione !!! Login assegnata a piu fornitori");
                        return;
                    }
                    DataTable Contatto = UsrConn.RUN_SELECT("registryreferenceview", "*", null,
                         QHS.AppAnd(QHS.CmpEq("userweb", NomeUtente), QHS.CmpEq("passwordweb", Password)), null, false);
                    if (Contatto.Rows.Count == 0) {
                        //Dati non corretti
                        labExtMessage.Text = "Nome utente o password non sono corretti.";
                        WebLog.Log(this, "Nome Fornitore:" + NomeUtente + " e password:" + Password + " non corretti");
                        return;
                    }

                    Session["LoginFornitore"] = NomeUtente;
                    Session["Fornitore"] = Contatto.Rows[0]["registry"];
                    Session["CodiceFornitore"] = Contatto.Rows[0]["idreg"];
                    Session["PasswordFornitore"] = Password;
                    Session["TipoUtente"] = "fornitore";
                    WebLog.Log(this, "Riconosciuto fornitore: " + Session["Fornitore"].ToString());
                }

                if (rbTipuUtente.SelectedValue == "3") {
                    Session["TipoUtente"] = "utente";
                    Session["Utente"] = NomeUtente;
                    Session["PasswordUtente"] = Password;

                }

                if (ldapauthok || (rbTipuUtente.SelectedValue == "1") ||
                        (rbTipuUtente.SelectedValue == "2") || (rbTipuUtente.SelectedValue == "3")) {
                    int userkind = Convert.ToInt32(rbTipuUtente.SelectedValue);
                    string filter = QHS.AppAnd(QHS.CmpEq("username", NomeUtente),
                        QHS.CmpEq("codicedipartimento", Session["DepCode"].ToString()),
                        QHS.CmpEq("userkind", userkind)
                        );
                    // prelevare l'idflowchart e poi fare la connecttodepartment
                    DataTable virtualuser = Conn.RUN_SELECT("virtualuser", "*", null, filter, null, false);
                    if (virtualuser != null && virtualuser.Rows.Count != 0) {
                        user = virtualuser.Rows[0]["sys_user"].ToString();
                        forename = virtualuser.Rows[0]["forename"].ToString();
                        lastname = virtualuser.Rows[0]["surname"].ToString();
                        email = virtualuser.Rows[0]["email"].ToString();
                        cf = virtualuser.Rows[0]["cf"].ToString();

                        UsrConn.SetUsr("HasVirtualUser", "S");
                        // Controllare se Ë anche un responsabile 
                        // Vediamo se esiste un manager il cui login="username"
                        // se si, assegnamo le due variabili di responsabile come 
                        // nel caso "2"
                        filter = QHS.CmpEq("userweb", virtualuser.Rows[0]["username"].ToString());
                        DataTable manager = UsrConn.RUN_SELECT("manager", "*", null, filter, null, false);
                        if (manager != null && manager.Rows.Count != 0) {
                            Session["Responsabile"] = manager.Rows[0]["title"].ToString();
                            Session["CodiceResponsabile"] = manager.Rows[0]["idman"];
                        }

                        EasySecurity sec = UsrConn.Security as EasySecurity;
                        UsrConn.externalUser = NomeUtente;
                        sec.SetSys("user", user);
                        sec.SetUsr("usergrouplist", null);
                        sec.CalculateGroupList();
                        sec.RecalcUserEnvironment();
                        sec.ReadAllGroupOperations();
                        sec.SetUsr("forename", forename);
                        sec.SetUsr("surname", lastname);
                        sec.SetUsr("email", email);
                        sec.SetUsr("cf", cf);
                        if (!CambioDataConsentita(UsrConn, D)) {
                            labExtMessage.Text = "Accesso non consentito in tale data \rin base alla gestione della sicurezza.";
                            lblMessaggio.Text = "Accesso negato";
                            return;
                        }


                    }
                    else {
                        if (ldapauthok) {
                            lblMessaggio.Text = "Utente non valido.";
                            return;
                        }
                    }
                }



                if (rbTipuUtente.SelectedValue == "4") {
                    Session["TipoUtente"] = "Utente LDAP";
                    Session["Utente"] = forename + " " + lastname;
                    Session["PasswordUtente"] = Password;

                }

                StampaReport(UsrConn, cf);


                //Response.Redirect("IndiceReport.aspx");
            }
            

        }

        void StampaReport(DataAccess Conn, string cf) {
            //Crea un datatable con i parametri per la stampa
            
            DataTable T = new DataTable("tabella");
            T.Columns.Add("cf", typeof(string));
            DataRow R = T.NewRow();
            R["cf"] = cf;
            T.Rows.Add(R);
            QueryHelper QHS= Conn.GetQueryHelper();
            DataTable Modulereport = Conn.RUN_SELECT("report", "*", null, QHS.CmpEq("reportname", "rpt_ingressomagazzino"), null, true);
            

            /*
            DataTable T = new DataTable("tabella");
            T.Columns.Add("ayear", typeof(int));
            DataRow R = T.NewRow();
            R["ayear"] = 2011;
            T.Rows.Add(R);
            QueryHelper QHS = Conn.GetQueryHelper();
            DataTable Modulereport = Conn.RUN_SELECT("report", "*", null, QHS.CmpEq("reportname", "avanzocassapresunto"), null, true);
            */



            Session["UserPar"] = T;
            Session["ModuleReportRow"] = Modulereport.Rows[0];
            Session["PageToCameBack"] = this.Request.Url;

            string F = "window.open('WebPDFView.aspx');";
            if (!Page.ClientScript.IsClientScriptBlockRegistered(typeof(Page), "openwin"))
                this.Page.ClientScript.RegisterClientScriptBlock(
                        typeof(Page), "openwin", F, true);
            txtNomeUtente.Text = "";
            txtPassword.Text = "";
            

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
}