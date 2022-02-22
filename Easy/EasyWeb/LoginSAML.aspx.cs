
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


using HelpWeb;
using metadatalibrary;
using metaeasylibrary;
using System;
using System.Data;
using System.IO;
using System.Web.UI;

namespace EasyWebReport {

    public partial class LoginSAML : Page {

        /// <summary>
        /// Si collega al dipartimento "codice" con un determinato user e pwd.
        /// Se user e pwd sono nulle accede con un utente predefinito.
        /// </summary>
        /// <param name="codice">Codice dipartimento.</param>
        /// <param name="user">Nome utente.</param>
        /// <param name="pwd">Password.</param>
        /// <param name="datacontabile">Data contabile.</param>
        void ConnectToDepartment(string codice, string user, string pwd, DateTime datacontabile) {
            string error;
            DataAccess Conn = GetVars.GetSystemDataAccess(this, out error);

            if (codice.Trim().Length == 0) {
                labExtMessage.Text = "Non è stato selezionato alcun dipartimento";
                return;
            }

            //Attenzione: leggere da XML IP del server e NomeDB
            //Inserire da codice NomeUtente e Password
            string filterdip = "(codicedipartimento=" + QueryCreator.quotedstrvalue(codice, true) + ")";
            DataTable CodDip = Conn.RUN_SELECT("codicidipartimenti", "*", null, filterdip, null, true);

            if ((CodDip == null) || (CodDip.Rows.Count == 0)) {
                //Dati non corretti
                WebLog.Log(this, codice + ": Codice non corretto");
                labExtMessage.Text = "Il codice inserito non è corretto.";
                return;
            }

            if (CodDip.Rows.Count > 1) {
                //Attenzione nel DB non è garantita l'unicità dei dati.
                labExtMessage.Text = "Chiedere al Responsabile del servizio " +
                    "l'assegnazione di un nuovo Codice";
                WebLog.Log(this, "Attenzione!!! Duplicazione di codici per " + codice);
                return;
            }

            string err = "";
            DataRow myDr = CodDip.Rows[0];
            Session["Dipartimento"] = myDr["Dipartimento"].ToString();

            //Creo la connessione.
            DataAccess UsrConn = GetVars.CreateUserConn(this, myDr, user, pwd, datacontabile, out err);
            if (UsrConn == null) {
                err = "Connessione per l'utente '" + user + "' rifiutata. <br/> Controllare Nome Utente e/o Password";
                string err2 = "Connessione al db del dipartimento " + codice +
                    " non riuscita. <br/>" + err;
                labExtMessage.Text = err2;
                WebLog.Log(this, err2);
                return;
            }
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
                        QHS.NullOrLe("start", oggi), QHS.NullOrGe("stop", oggi));
            if (DA.RUN_SELECT_COUNT("flowchartuser", filternow, false) == 0) return false;
            return true;
        }

        DataAccess Conn;

        protected void Page_Load(object sender, EventArgs e) {
            lblMessaggio.Text = "";
            labExtMessage.Text = "";

            // Imposta il nome dell'utente identificato dall'intentity provider.
            if (Session["samlemail"] == null) {
                lblMessaggio.Text = "Autenticazione fallita.";
                WebLog.Log(this, "Autenticazione fallita.");
                //Response.Redirect("DefaultSAML.aspx");
                return;
            }
         
            txtNomeUtente.Text = Session["samlemail"]?.ToString();         

            if (!Page.IsPostBack) {
                Session["utente"] = "";
                Session["Responsabile"] = "";
                Session["Fornitore"] = "";
                Session["CodiceResponsabile"] = null;
                Session["CodiceFornitore"] = null;
                Session["TipoUtente"] = null;

                txtDataContabile.Text = HelpForm.StringValue(DateTime.Now, "x.y");
            }

            DataSet Cfg = GetVars.GetConfigDataSet(this);
            if (Cfg.Tables[0].Rows.Count == 0) {
                lblMessaggio.Text = "Servizio non installato correttamente. Manca il file di configurazione.";
                WebLog.Log(this, "Connessione al db di sistema non riuscita.");
                return;
            }

            string error;
            Conn = GetVars.GetSystemDataAccess(this, out error);
            if (Conn == null) {
                lblMessaggio.Text = "Connessione al DB di sistema non riuscita.";
                WebLog.Log(this, "Connessione al db di sistema non riuscita.");
                return;
            }
            else {
                lblMessaggio.Text = "Il servizio Web è attivo.";
            }

            GetVars.ClearUserConn(this);

            if (Request != null) {
                string dep = Request.Params["dep"];
                if (!string.IsNullOrEmpty(dep)) {
                    Label3.Visible = false;
                    cmbDipartimento.Visible = false;
                }
            }

            AggiornaElencoDipartimenti();
        }

        #region Web Form Designer generated code
        override protected void OnInit(EventArgs e) {
            //
            // CODEGEN: This call is required by the ASP.NET Web Form Designer.
            //
            InitializeComponent();
            base.OnInit(e);

        }

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {

        }
        #endregion

        public bool DatiValidi(DateTime T, DataAccess DA) {
            QueryHelper QHS = DA.GetQueryHelper();

            string filteresercizio = QHS.CmpEq("ayear", T.Year);
            DataTable EsercizioTable = DA.RUN_SELECT("accountingyear", "*", null, filteresercizio, null, true);

            return EsercizioTable.Rows.Count != 0;
        }

        protected void btnOk_Click(object sender, ImageClickEventArgs e) {
            if (Conn == null) return;

            DateTime D;

            try {
                D = (DateTime)HelpForm.GetObjectFromString(typeof(DateTime), txtDataContabile.Text, "x.y");
            }
            catch {
                lblMessaggio.Text = "La data contabile è un campo obbligatorio.";
                return;
            }

            string codicedipartimento = null;
            if (Request != null) {
                codicedipartimento = Request.Params["dep"];
                if (!string.IsNullOrEmpty(codicedipartimento)) {
                    Label3.Visible = false;
                    cmbDipartimento.Visible = false;
                }
            }

            if (string.IsNullOrEmpty(codicedipartimento)) {
                if (cmbDipartimento.SelectedValue != "" && cmbDipartimento.SelectedValue != null) {
                    codicedipartimento = cmbDipartimento.SelectedValue;
                }
            }

            if (string.IsNullOrEmpty(codicedipartimento)) {
                lblMessaggio.Text = "E' obbligatorio scegliere un dipartimento";
            }

            //Cerco prima nella tabella contatto e poi nella tabella responsabile.
            string NomeUtente = txtNomeUtente.Text;

            //rbTipuUtente.SelectedValue == "5" IMPLICITAMENTE

            // Connessione al dipartimento.
            ConnectToDepartment(codicedipartimento, null, null, D);

            //Connessione al Server.Database privato del software.
            Easy_DataAccess UsrConn = GetVars.GetUserConn(this);

            if (UsrConn == null) return; //Messaggio già viualizzato da ConnectToDepartment()
            QueryHelper QHS = UsrConn.GetQueryHelper();

            if (!DatiValidi(D, UsrConn)) {
                lblMessaggio.Text = string.Format("L'esercizio {0} non è stato creato!", D.Year);
                return;
            }

            if (UsrConn.Open() == false) {
                //Il Server del Dipartimento non è in rete. 
                //Il servizio non è disponibile in quanto il computer potrebbe essere spento.
                labExtMessage.Text = "Il Server del Dipartimento non risponde.\r" +
                    "Potrebbe essere spento o momentaneamente fuori rete. \r" +
                    "Provi in seguito.";
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

            int userkind = 5; // utente SSO (SAML/Shibboleth)
            string user = null;
            string forename = null;
            string lastname = null;
            string cf = null;
            string email = null;

            string filter = QHS.AppAnd(
                QHS.CmpEq("username", NomeUtente),
                QHS.CmpEq("codicedipartimento", codicedipartimento),
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
                // Controllare se è anche un responsabile 
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
                sec.SetSys("usergrouplist", null);
                sec.CalculateGroupList();
                sec.RecalcUserEnvironment();
                sec.ReadAllGroupOperations();
                sec.SetUsr("forename", forename);
                sec.SetUsr("surname", lastname);
                sec.SetUsr("email", email);
                sec.SetUsr("cf", cf);
                if (!CambioDataConsentita(UsrConn, D)) {
                    UsrConn.Close();
                    labExtMessage.Text = "Accesso non consentito in tale data \rin base alla gestione della sicurezza.";
                    lblMessaggio.Text = "Accesso negato";
                    return;
                }
            }
            else {
                lblMessaggio.Text = "Utente non valido.";
                return;
            }

            Session["TipoUtente"] = "Utente SSO";
            Session["Utente"] = string.Format("{0} {1}", forename, lastname);
            Session["PasswordUtente"] = null; // non la conosciamo

            Session["SavedFlowChart"] = null;
            object idflowchart = UsrConn.GetSys("idflowchart");
            if (idflowchart != null && idflowchart != DBNull.Value) {
                object title = UsrConn.DO_READ_VALUE("flowchart", QHS.CmpEq("idflowchart", idflowchart), "title");
                if (title != null && title != DBNull.Value) Session["SavedFlowChart"] = title;
            }

            Session["SavedHomePage"] = "LoginSAML.aspx";
            Response.Redirect("IndiceReport.aspx");
        }

        void AggiornaElencoDipartimenti() {
            if (Conn == null) return;

            int userkind = 5;
            string NomeUtente = txtNomeUtente.Text;

            QueryHelper QHS = Conn.GetQueryHelper();

            /*
            this.SetFocus(txtPassword);
            txtPassword.Attributes.Add("value", txtPassword.Text);
            */

            /*
            ldapauth lauth = new ldapauth(Conn);
            if (!lauth.getconfig()) return;
            */

            //Deve riempire il combo dei dipartimenti in base al nome dell'utente filtrando anche userkind=4
            string filter = QHS.AppAnd(
                //QHS.CmpEq("email", NomeUtente),
                QHS.CmpEq("username", NomeUtente),
                QHS.CmpEq("userkind", userkind)
            );

            // prelevare l'idflowchart e poi fare la connecttodepartment
            DataTable virtualuser = Conn.RUN_SELECT("virtualuser", "*", null, filter, null, false);
            if (virtualuser == null || virtualuser.Rows.Count == 0) {
                cmbDipartimento.DataSource = null;
                cmbDipartimento.Items.Clear();
                return;
            }

            string filterdip = QHS.FieldIn("CodiceDipartimento", virtualuser.Select(), "codicedipartimento");
            DataTable Dip = Conn.RUN_SELECT("CodiciDipartimenti", "*", null, filterdip, null, true);
            cmbDipartimento.DataSource = Dip;
            cmbDipartimento.DataTextField = "Dipartimento";
            cmbDipartimento.DataValueField = "CodiceDipartimento";
            cmbDipartimento.DataBind();

            if (virtualuser.Rows.Count == 1) {
                cmbDipartimento.SelectedIndex = 0;
            }
        }

    }

}
