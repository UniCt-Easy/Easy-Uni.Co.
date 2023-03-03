
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
using EasyPagamenti;
using EasyPagamenti.Extra;
using EasyPagamenti.Extensions;

public partial class CambioPassword :System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            labError.Visible = false;

        }
        bool CheckPassword(string S, DataAccess Conn) {
                if (Session["PasswordUtente"].ToString() == S) return true;
            return false;
        }


        bool Do_ChangePassword() {
            Easy_DataAccess DepConn = GetVars.GetUserConn(this);
            string old = txtOldPwd.Text;
            labError.Text = "";
            string user = DepConn.GetSys("user").ToString();
            if (!CheckPassword(old, DepConn)) {
                labError.Text = "La vecchia password inserita non è corretta";
                labError.Visible = true;
                return false;
            }
            string new1 = txtNewPwd.Text;
            string new2 = txtNewPwd2.Text;
            if (new1 != new2) {
                labError.Text = "La password inserita come conferma era diversa";
                labError.Visible = true;
                return false;
            }

            if (new1 == "" || new2 == "") {
                labError.Text = "Password non inserita";
                labError.Visible = true;
                return false;
            }
            return DoChangePassword_Fornitore(DepConn, new1);
     
            return true;
        }

        bool DoChangePassword_Fornitore(DataAccess DepConn, string NewPassword) {

        QueryHelper QHS = DepConn.GetQueryHelper();
        var iterations = DateTime.Now.Millisecond * DateTime.Now.Second + 1;//iterweb
        var salt = KeyChain.GenerateSalt();//saltweb
        var hash = Password.GenerateHash(NewPassword, salt, iterations);//passwordweb

        string err = DepConn.DO_UPDATE("registryreference",
            QHS.CmpEq("userweb", Session["Utente"]),
            new string[] { "iterweb" , "saltweb" , "passwordweb" },
            new[] { QHS.quote(iterations), QHS.quote(salt.ToHexString()), QHS.quote(hash.ToHexString()) },
            3);

        if (err == null) return true;
            labError.Text = err;
            labError.Visible = true;
            return false;
        }



        protected void btnCancel_Click(object sender, EventArgs e) {
            Response.Redirect("IndiceReport.aspx");
        }

        protected void btnOk_Click(object sender, EventArgs e) {
            if (Do_ChangePassword()) {
                Session["Messaggio"] = "Password impostata con successo";
                Response.Redirect("Messaggio.aspx");
                return;
            }

        }
    }

