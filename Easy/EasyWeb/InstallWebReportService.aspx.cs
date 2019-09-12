/*
    Easy
    Copyright (C) 2019 Università degli Studi di Catania (www.unict.it)

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
using System.Security;
using System.Security.Cryptography;
using System.IO;
using metadatalibrary;
using metaeasylibrary;
namespace EasyWebReport
{
    public partial class InstallWebReportService : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnVerifica_Click(object sender, EventArgs e)
        {
            string pwdsys = Request.Form["txtPwdSystem"].ToString();

            if (pwdsys != "web report fc-hires")
            {
                lblmessages.Text = "Password di abilitazione alla configurazione non accettata.";
                return;
            }
            lblmessages.Text = "";
            string msg = "L'utente impersonato è : " + System.Environment.UserName;
            lblImpUser.Text = msg;
            Session["SysPasswordOk"] = true;
        }



        protected void btnSalva_Click(object sender, EventArgs e)
        {
            if (Session["SysPasswordOk"] == null)
            {
                lblmessages.Text = "Prima di procedere alla configurazione, inserire la Password di abilitazione alla configurazione.";
                return;
            }
            string pwd = txtPWD.Text;
            string server = txtServer.Text;
            string db = txtDB.Text;
            string user = txtUser.Text;

            string report = txtReport.Text;
            if (!System.IO.Directory.Exists(report))
            {
                lblmessages.Text = "La Directory specificata per i report è inesistente.";
                return;
            }

            string path = MapPath("cfg");
            string filename = Path.Combine(path, "config.xml");
            FileStream FileS = new FileStream(filename, FileMode.OpenOrCreate);
            CryptoStream CryptoS = new CryptoStream(FileS,
                new TripleDESCryptoServiceProvider().CreateEncryptor(
                new byte[] { 75, 12, 0, 215, 93, 89, 45, 11, 171, 96, 4, 64, 13, 158, 36, 190 },
                new byte[] { 68, 13, 99, 43, 149, 192, 145, 43, 83, 19, 238, 57, 128, 38, 12, 4 }
                ), CryptoStreamMode.Write);
            DataSet DS = new AllDataSet.LastConnection();
            DataTable T = DS.Tables[0];
            DataRow R = T.NewRow();
            R["Server"] = server;
            R["DataBase"] = db;
            R["user"] = user;
            R["Password"] = pwd;
            R["Report"] = report;
            T.Rows.Add(R);
            DS.WriteXml(CryptoS, XmlWriteMode.WriteSchema);
            CryptoS.Flush();
            CryptoS.Close();
            CryptoS.Dispose();
            FileS.Close();
            FileS.Dispose();
            lblmessages.Text = "File di configurazione Creato correttamente";
            lblmessages.Text += " Aggiungere le autorizzazioni <b>CONTROLLO COMPLETO</b> " +
                " all'utente impersonato per la cartella ReportPDF <br/>, e rimuovere le autorizzazioni in" +
                " scrittura per la cartella cfg.";





        }
    }
}