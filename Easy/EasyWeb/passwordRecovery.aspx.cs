/*
    Easy
    Copyright (C) 2020 Università degli Studi di Catania (www.unict.it)
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

﻿using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using metadatalibrary;
using metaeasylibrary;
using HelpWeb;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using funzioni_configurazione;

namespace EasyWebReport {

    public partial class passwordRecovery : System.Web.UI.Page {
        int myRandom = 0;
        bool StopAnything = false;
        void ConnectToDepartment(string codice, string user, string pwd, DateTime datacontabile) {
            string error;
            labExtMessage.Text = "";
            DataAccess Conn = GetVars.GetSystemDataAccess(this, out error);
            StopAnything = false;

            if (codice.Trim().Length == 0) {
                labExtMessage.Text = "Non è stato selezionato alcun dipartimento";
                StopAnything = true;
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
                StopAnything = true;
                return;
            }
            if (CodDip.Rows.Count > 1) {
                //Attenzione nel DB non è garantita l'unicità dei dati.
                labExtMessage.Text = "Chiedere al Responsabile del servizio " +
                    "l'assegnazione di un nuovo Codice";
                WebLog.Log(this, "Attenzione !!! Duplicazione di codici per " + codice);
                StopAnything = true;
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
                StopAnything = true;
                return;
            }

        }

        string depcode_given = "";
        string user = null;
        string forename = null;
        string lastname = null;
        string cf = null;
        string email = null;
        string login = null;

        protected void Page_Load(object sender, System.EventArgs e) {
            //Master.SetTitle("WebEasy - Accesso Servizi Dipartimento  ");
            lblMessaggio.Text = "";
            labExtMessage.Text = "";

            if (!Page.IsPostBack) {
                Session["utente"] = "";
                Session["Responsabile"] = "";
                Session["Fornitore"] = "";
                Session["CodiceResponsabile"] = null;
                Session["CodiceFornitore"] = null;
                Session["TipoUtente"] = null;
                Random r = new Random();
                myRandom = r.Next();
                Session["myRandom"] = myRandom;
            }
            else {
                myRandom = (int)Session["myRandom"];
            }

          

            DataSet Cfg = GetVars.GetConfigDataSet(this);
            if (Cfg.Tables[0].Rows.Count == 0) {
                lblMessaggio.Text = "Servizio non installato correttamente. Manca il file di configurazione.";
                WebLog.Log(this, "Connessione al db di sistema non riuscita.");
                StopAnything = true;
                return;
            }
            MetaMaster MM = Master as MetaMaster;
            //if (MM != null) MM.ShowClientMessage("NINO", false);

            string error;

            DataAccess sysConn = GetVars.GetSystemDataAccess(this, out error);
            if (sysConn == null) {
                //lblMessaggio.Text = "Connessione al DB di sistema non riuscita." + error;
                //Attenzione qui l'errore contiene la password del Database !
                lblMessaggio.Text = "Connessione al DB di sistema non riuscita.";
                WebLog.Log(this, "Connessione al db di sistema non riuscita.");
                StopAnything = true;
                return;
            }
            MetaMaster master = Page.Master as MetaMaster;
            master?.setUniversita(Session["system_config_nome_universita"] as string);

            lblMessaggio.Text = "Il servizio Web è attivo";
            GetVars.ClearUserConn(this);
            depcode_given = "";

            if (Request != null) {
                if (Request.Params["dep"] != null && Request.Params["dep"].ToString() != "") {
                    depcode_given = Request.Params["dep"];
                    Label3.Visible = false;
                    txtCodiceDipartimento.Visible = false;
                }
                else {
                    depcode_given = txtCodiceDipartimento.Text;
                }
            }






            DateTime D = DateTime.Now;

            if (IsPostBack) {
                if (txtNomeUtente.Text == "") {
                    lblMessaggio.Text = "Il nome utente è un campo obbligatorio.";
                    StopAnything = true;
                    return;
                }

            }


            if (depcode_given == null) {
                lblMessaggio.Text = "Il nome codice dipartimento è un campo obbligatorio.";
                StopAnything = true;
                return;
            }

            if (IsPostBack) {
                //Cerco prima nella tabella contatto e poi nella tabella responsabile.
                string NomeUtente = txtNomeUtente.Text;

                ConnectToDepartment(depcode_given, null, null, D);


                bool ldapauthok = false;


                //Connessione al Server.Database privato del software.
                Easy_DataAccess UsrConn = GetVars.GetUserConn(this);

                if (UsrConn == null) {
                    sysConn.Close();
                    return; //Messaggio già viualizzato da ConnectToDepartment()
                }
                QueryHelper QHS = UsrConn.GetQueryHelper();



                user = null;
                forename = null;
                lastname = null;
                cf = null;
                email = null;

                sysConn.Close();


                if (UsrConn.Open() == false) {
                    //Il Server del Dipartimento non è in rete. 
                    //Il servizio non è disponibile in quanto il computer potrebbe essere spento.
                    labExtMessage.Text = "Il Server del Dipartimento non risponde.\r" +
                        "Potrebbe essere spento o momentaneamente fuori rete. \r" +
                        "Provi in seguito";
                    txtNomeUtente.ReadOnly = true;
                    WebLog.Log(this, "Il Server del dipartimento non risponde.");
                    StopAnything = true;
                    return;
                }

                UsrConn.Close();

                labExtMessage.Text = "Connessione al server effettuata.";

                if (rbTipuUtente.SelectedValue == "1") {
                    int countresp = UsrConn.RUN_SELECT_COUNT("manager",
                            QHS.CmpEq("userweb", NomeUtente), false);
                    if (countresp > 1) {
                        labExtMessage.Text = "Chiedere al Segreterio Amministrativo l'assegnazione di una nuova login";
                        WebLog.Log(this, "Attenzione !!! Login assegnata a piu responsabili");
                        StopAnything = true;
                        return;
                    }
                    // tabella manager, campi userweb e passwordweb
                    DataTable Responsabile = UsrConn.RUN_SELECT("manager", "*", null, QHS.CmpEq("userweb", NomeUtente), null, false);
                    if (Responsabile.Rows.Count == 0) {
                        //Dati non corretti
                        labExtMessage.Text = "Nome utente non corretto.";
                        WebLog.Log(this, "Nome Resp:" + NomeUtente + " non corretto");
                        StopAnything = true;
                        return;
                    }

                    WebLog.Log(this, "Riconosciuto responsabile: " + NomeUtente);

                }

                if (rbTipuUtente.SelectedValue == "2") {
                    int countforn = UsrConn.RUN_SELECT_COUNT("registryreferenceview",
                            QHS.CmpEq("userweb", NomeUtente), false);
                    if (countforn > 1) {
                        labExtMessage.Text = "Chiedere al Segreterio Amministrativo l'assegnazione di una nuova login";
                        WebLog.Log(this, "Attenzione !!! Login assegnata a piu fornitori");
                        StopAnything = true;
                        return;
                    }
                    // tabella registryreference, campi userweb e passwordweb
                    DataTable Contatto = UsrConn.RUN_SELECT("registryreferenceview", "*", null,
                         QHS.CmpEq("userweb", NomeUtente), null, false);
                    if (Contatto.Rows.Count == 0) {
                        //Dati non corretti
                        labExtMessage.Text = "Nome utente non corretto.";
                        WebLog.Log(this, "Nome Fornitore:" + NomeUtente + " non corretto");
                        StopAnything = true;
                        return;
                    }

                    WebLog.Log(this, "Riconosciuto fornitore: " + NomeUtente);
                }



                int userkind = Convert.ToInt32(rbTipuUtente.SelectedValue);
                string filter = QHS.AppAnd(QHS.CmpEq("username", NomeUtente),
                    QHS.CmpEq("codicedipartimento", depcode_given),
                    QHS.CmpEq("userkind", userkind)
                    );
                // prelevare l'idflowchart e poi fare la connecttodepartment
                DataTable virtualuser = sysConn.RUN_SELECT("virtualuser", "*", null, filter, null, false);
                if (virtualuser != null && virtualuser.Rows.Count != 0) {
                    user = virtualuser.Rows[0]["sys_user"].ToString();
                    forename = virtualuser.Rows[0]["forename"].ToString();
                    lastname = virtualuser.Rows[0]["surname"].ToString();
                    email = virtualuser.Rows[0]["email"].ToString();
                    cf = virtualuser.Rows[0]["cf"].ToString();
                    login = NomeUtente;
                }
                else {
                    labExtMessage.Text = "Nome utente non corretto.";
                    StopAnything = true;
                }


                UsrConn.Close();
            }

        }

        public static string getHashSha256(string text) {
            byte[] bytes = Encoding.Unicode.GetBytes(text);
            SHA256Managed hashstring = new SHA256Managed();
            byte[] hash = hashstring.ComputeHash(bytes);
            string hashString = string.Empty;
            foreach (byte x in hash) {
                hashString += String.Format("{0:x2}", x);
            }
            return hashString;
        }

        string calculateChecksum() {
            int userkind = Convert.ToInt32(rbTipuUtente.SelectedValue);
            string s = depcode_given + "-" + userkind.ToString() + "-" + user + "-"
                + DateTime.Now.Year.ToString() + "-" + DateTime.Now.DayOfYear.ToString() + "#" + myRandom.ToString();
            return getHashSha256(s);

        }


        protected void btnSend_Click(object sender, EventArgs e) {
            if (StopAnything)
                return;

            if (email == null || email == "") {
                labExtMessage.Text = "Nel profilo non è stata inserita l'email, non è possibile reimpostare la password.";
                return;
            }
            Easy_DataAccess UsrConn = GetVars.GetUserConn(this);
            if (UsrConn == null)
                return;
            if (!UsrConn.Open())
                return;

            SendMail SM = new SendMail();
            SM.UseSMTPLoginAsFromField = true;
            SM.Conn = UsrConn;

            SM.To = email;
            string MsgBody = "";
            MsgBody = "Sulla pagina di easy Web sembra che lei abbia richiesto la reimpostazione della password.\r\n";
            MsgBody += "Se non l'ha fatto, può ignorare questa mail.\r\n";
            MsgBody += "Se invece l'ha richiesta davvero, può copiare questo codice per portare a termine l'operazione: .\r\n";
            MsgBody += calculateChecksum().Trim();

            SM.Subject = "Richiesta di reimpostazione password";
            SM.MessageBody = MsgBody;

            if (!SM.Send()) {
                if (SM.ErrorMessage.Trim() != "")
                    labExtMessage.Text = SM.ErrorMessage;
            }
            else {
                labExtMessage.Text = "Mail inviata. Copiare il codice ricevuto nell'opportuna casella.";
            }
            UsrConn.Close();


        }


        protected void btnResetPwd_Click(object sender, EventArgs e) {
            if (StopAnything)
                return;
            string error = null;
            if (txtPwd.Text == "") {
                labExtMessage.Text = "La password è un campo obbligatorio.";
                return;
            }
            string Password = txtPwd.Text;
            string Password2 = txtPwd2.Text;
            if (Password != Password2) {
                labExtMessage.Text = "Le due password inserite sono diverse.";
                return;
            }
            string code = txtToken.Text.Trim();
            if (code != calculateChecksum()) {
                labExtMessage.Text = "Il codice inserito è errato.";
                return;
            }
            DataAccess sysConn = GetVars.GetSystemDataAccess(this, out error);
            if (sysConn == null)
                return;
            Easy_DataAccess UsrConn = GetVars.GetUserConn(this);
            if (!UsrConn.Open())
                return;
            QueryHelper q = UsrConn.GetQueryHelper();
            string newPwd = txtPwd.Text;
            int userkind = Convert.ToInt32(rbTipuUtente.SelectedValue);
            if (userkind == 1) {
                //responsabili
                // tabella manager, campi userweb e passwordweb
                string res = UsrConn.DO_UPDATE("manager", q.CmpEq("userweb", login), new string[] { "passwordweb" }, new string[] { q.quote(newPwd) }, 1);
                if (res != null) {
                    labExtMessage.Text = res;
                }
                else {
                    labExtMessage.Text = "Password reimpostata con successo.";
                }
            }
            if (userkind == 2) {
                //fornitori
                // tabella registryreference, campi userweb e passwordweb
                string res = UsrConn.DO_UPDATE("registryreference", q.CmpEq("userweb", login), new string[] { "passwordweb" }, new string[] { q.quote(txtPwd.Text) }, 1);
                if (res != null) {
                    labExtMessage.Text = res;
                }
                else {
                    labExtMessage.Text = "Password reimpostata con successo.";
                }
            }

            if (userkind == 3) {
                string detail;
                string oldpwd = Easy_DataAccess.INITIAL_PASSWORD;
                //utenti easy
                string sql = " alter login [" + login + "] with password = " + q.quote(oldpwd);
                object res = UsrConn.DO_SYS_CMD(sql, out error);
                if (error != null) {
                    labExtMessage.Text = "Errore di db: \r\n" + error;
                }
                else {


                    UsrConn.linkUserToDepartment(login, out error);                   

                    if (error != null) {
                        labExtMessage.Text = "Errore durante l'impostazione della password: \r\n" + error;                      
                    }
                    else {
                        Easy_DataAccess Try = Easy_DataAccess.getEasyDataAccess("temp",
                        UsrConn.GetSys("server").ToString(), UsrConn.GetSys("database").ToString(),
                        user, oldpwd, UsrConn.GetSys("userdb").ToString(), DateTime.Now.Year, DateTime.Now, out error, out detail);
                        if (Try == null) {
                            labExtMessage.Text = "Errore collegandomi al db con l'utente indicato: \r\n" + error + "\r\n" + detail;
                            return;
                        }
                        byte[] oldalfa = Easy_DataAccess.getAlfaFromPassword(oldpwd);
                        byte[] newalfa = Easy_DataAccess.getAlfaFromPassword(newPwd);
                        if (Try.changeUserPassword(oldalfa, newalfa)) {
                            labExtMessage.Text = "Password reimpostata con successo.";
                        }
                        else {
                            labExtMessage.Text = "Errore nella reimpostazione della password (metodo changeUserPassword).";
                        }
                        sql = " alter login [" + login + "] with password = " + q.quote(newPwd);
                        object O = UsrConn.DO_SYS_CMD(sql, out error);
                          
                        
                        Try.Destroy();
                    }
                  

                }
                UsrConn.Close();
            }
        }
    }
}

