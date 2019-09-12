/*
    Easy
    Copyright (C) 2019 Universit� degli Studi di Catania (www.unict.it)

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

namespace EasyWebReport {
    public partial class CambioPassword : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            labError.Visible = false;

        }
        bool CheckPassword(string S,DataAccess Conn) {
            if (Session["TipoUtente"] == "utente") {
                if (Session["PasswordUtente"].ToString() == S) return true;
            }
            if (Session["TipoUtente"] == "fornitore") {
                if (Session["PasswordFornitore"].ToString() == S) return true;
            }
            if (Session["TipoUtente"] == "responsabile") {
                if (Session["PasswordResponsabile"].ToString() == S) return true;
            }
            return false;
        }


        bool Do_ChangePassword() {
            Easy_DataAccess DepConn = GetVars.GetUserConn(this);
            string old = txtOldPwd.Text;
            labError.Text = "";
            string user = DepConn.GetSys("user").ToString();
            if (!CheckPassword(old,DepConn)) {
                labError.Text="La vecchia password inserita non è corretta";
                labError.Visible = true;
                return false;
            }
            string new1 = txtNewPwd.Text;
            string new2 = txtNewPwd2.Text;
            if (new1 != new2) {
                labError.Text=  "La password inserita come conferma era diversa";
                labError.Visible = true;
                return false;
            }

            if (new1 == "" || new2 == "")
            {
                labError.Text = "Password non inserita";
                labError.Visible = true;
                return false;
            }
            if (Session["TipoUtente"] == "utente") {
                return DoChangePassword_DBUser(DepConn,old,new1);
            }
            if (Session["TipoUtente"] == "responsabile") {
                return DoChangePassword_Responsabile(DepConn,new1);
            }
            if (Session["TipoUtente"] == "fornitore") {
                return DoChangePassword_Fornitore(DepConn,new1);
            }
            return true;
        }

        bool DoChangePassword_Responsabile(DataAccess DepConn, string NewPassword) {
            QueryHelper QHS= DepConn.GetQueryHelper();
            string err= DepConn.DO_UPDATE("manager",
                QHS.CmpEq("userweb", Session["LoginResponsabile"]),
                new string[] { "passwordweb" }, new string[] { "'"+NewPassword+"'" },
                1);
            if (err == null) return true;
            labError.Text = err;
            labError.Visible = true;
            return false;
        }

        bool DoChangePassword_Fornitore(DataAccess DepConn, string NewPassword) {
            QueryHelper QHS = DepConn.GetQueryHelper();
            string err = DepConn.DO_UPDATE("registryreference",
                QHS.CmpEq("userweb", Session["LoginFornitore"]),
                new string[] { "passwordweb" }, new string[] { "'"+NewPassword+"'" },
                1);
            if (err == null) return true;
            labError.Text = err;
            labError.Visible = true;
            return false;
        }

        bool DoChangePassword_DBUser(Easy_DataAccess DepConn,string oldpwd, string newpwd) {
            string user = DepConn.GetSys("user").ToString();

            DataAccess Try = new DataAccess("temp",
                            DepConn.GetSys("server").ToString(), DepConn.GetSys("database").ToString(),
                            user, oldpwd, DateTime.Now.Year, DateTime.Now);
            Try.Open();
            if (Try.OpenError) {
                 labError.Text =   "La vecchia password inserita non è corretta!";
                labError.Visible = true;
                Try.Destroy();
                return false;
            }


            byte[] oldalfa = Easy_DataAccess.getAlfaFromPassword(oldpwd);
            byte[] newalfa = Easy_DataAccess.getAlfaFromPassword(newpwd);
            if (DepConn.changeUserPassword(oldalfa, newalfa)) {
                object PWDOLD = (oldpwd == "") ? DBNull.Value : (object)oldpwd;
                object PWDNEW = (newpwd == "") ? DBNull.Value : (object)newpwd;
                string err;
                string sql = "sp_password " +
                    QueryCreator.quotedstrvalue(PWDOLD, true) + "," +
                    QueryCreator.quotedstrvalue(PWDNEW, true);
                object O = Try.DO_SYS_CMD(sql, out err);
                Try.Destroy();

                if (err != null) {
                    labError.Text =  "Errore nell'impostazione della password: "+ err;
                    labError.Visible = true;
                    DepConn.changeUserPassword(oldalfa, newalfa);//Annulla l'azione del precedente!!                    
                    return false;
                }
                DepConn.SetSys("password", newpwd);
                return true;
            }
            else {
                labError.Text= "Non è stato possibile cambiare la password";
                labError.Visible = true;
            }
            return false;
        }

        protected void btnCancel_Click(object sender, EventArgs e) {
            Response.Redirect("IndiceReport.aspx");
        }

        protected void  btnOk_Click(object sender, EventArgs e)
        {
            if (Do_ChangePassword())
            {
                Session["Messaggio"] = "Password impostata con successo";
                Response.Redirect("Messaggio.aspx");
                return;
            }

        }
    }
}
