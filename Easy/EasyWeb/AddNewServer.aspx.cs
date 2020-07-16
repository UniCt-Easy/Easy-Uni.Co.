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
using AllDataSet;

namespace EasyWebReport
{
    public partial class AddNewServer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnVerifica_Click(object sender, EventArgs e)
        {
            string pwdsys = Request.Form["txtPwdSystem"].ToString();

            if (pwdsys != "web report fc-hires")
            {
                lblmessages.Text = "Password di abilitazione alla configurazione <b>non</b> accettata.";
                return;
            }
            lblmessages.Text = "Password di abilitazione alla configurazione accettata.";
            Session["SysPasswordOk"] = true;
        }


        protected void brnAdd_Click(object sender, EventArgs e) {
            if (Session["SysPasswordOk"] == null) {
                lblmessages.Text =
                    "Prima di procedere alla configurazione, inserire la Password di abilitazione alla configurazione.";
                return;
            }
            string error = "";
            DataAccess sys = GetVars.GetSystemDataAccess(this, out error);
            if (sys == null) {
                lblmessages.Text = "Servizio Web non installato correttamente.";
                if (error != null) lblmessages.Text += error;
                return;
            }

            string dip = txtDip.Text;
            string codice = txtCodice.Text;
            string ip = txtIP.Text;
            string db = txtDB.Text;
            string user = txtUser.Text;
            string pwd = txtPWD.Text;
            Easy_DataAccess Conn = new Easy_DataAccess(
                "mydsn", ip, db, user, pwd, user, pwd, DateTime.Now.Year, DateTime.Now);
            if (Conn == null) {
                lblmessages.Text = "Non Ë stato possibile collegarsi al server.";
                return;
            }
            Conn.Open();
            if (Conn.openError) {
                lblmessages.Text = "Non Ë stato possibile collegarsi al server.";
                return;
            }
            Conn.Close();
            DataSet DS = new Dipartimenti();
            if (sys.RUN_SELECT_COUNT("CodiciDipartimenti",
                "(CodiceDipartimento=" +
                QueryCreator.quotedstrvalue(codice, true) + ")", true) > 0) {
                lblmessages.Text = "Codice dipartimento gi‡ esistente.";
                return;
            }
            DataTable T = DS.Tables[0];
            DataRow R = T.NewRow();
            R["CodiceDipartimento"] = codice;
            R["dipartimento"] = dip;
            R["IPserver"] = GetVars.CryptPassword(ip);
            R["NomeDB"] = GetVars.CryptPassword(db);
            R["UserDB"] = GetVars.CryptPassword(user);
            R["PassDB"] = GetVars.CryptPassword(pwd);
            T.Rows.Add(R);
            PostData CP = new PostData();
            CP.InitClass(DS, sys);

            ProcedureMessageCollection MCOLL = CP.DO_POST_SERVICE();
            if (!MCOLL.CanIgnore) {
                lblmessages.Text = "Delle regole di sicurezza hanno impedito l'update del db di sistema!!";
                return;
            }
            else {
                if (MCOLL.Count>0)  CP.DO_POST_SERVICE();
            }
        

        lblmessages.Text = "DB DI SISTEMA Aggiornato correttamente.";

        }
    }
}