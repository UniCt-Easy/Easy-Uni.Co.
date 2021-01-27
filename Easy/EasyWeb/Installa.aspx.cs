
/*
Easy
Copyright (C) 2021 Università degli Studi di Catania (www.unict.it)
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
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Security;
using System.Security.Cryptography;
using System.IO;
using metadatalibrary;
using metaeasylibrary;

namespace EasyWebReport
{
	/// <summary>
	/// Summary description for Installa.
	/// </summary>
	public partial class Installa : System.Web.UI.Page
	{
	
		protected void Page_Load(object sender, System.EventArgs e) {
			// Put user code to initialize the page here
            string msg = "Utente impersonato è :" + System.Environment.UserName;
            labUsr.Text = msg;


			if (IsPostBack){
				string pwdsys = Request.Form["txtPwdSystem"].ToString();
                string pwd = Request.Form["txtPWD"].ToString();

                if (Session["pwd_system"] == null) {
                    if (pwdsys != "web report fc-hires") {
                        labMsg.Text = "Password di sistema non accettata.";
                        return;
                    }
                    Session["pwd_system"] = "1";
                }



				string server= txtServer.Text;
				string db = txtDB.Text;
				string user = txtUser.Text;

                Easy_DataAccess Conn = new Easy_DataAccess(
                    "mydsn", server, db, user, pwd, user, pwd, DateTime.Now.Year, DateTime.Now);
                if (Conn == null) {
                    labMsg.Text = "Non è stato possibile collegarsi al server.";
                    return;
                }
                Conn.Open();
                if (Conn.openError) {
                    labMsg.Text = "Non è stato possibile collegarsi al server.";
                    return;
                }
                Conn.Close();


                string report = txtReport.Text;
				if (!System.IO.Directory.Exists(report)){
					labMsg.Text="Il percorso specificato per i report non esiste";
					return;
				}
				
				string path = MapPath("cfg");
				string filename = Path.Combine(path,"config.xml");
				FileStream FileS = new FileStream(filename,FileMode.Create);
                CryptoStream CryptoS = new CryptoStream(FileS,
                    new TripleDESCryptoServiceProvider().CreateEncryptor(
                    new byte[]{75,12,0,215,   93,89,45,11,   171,96,4,64,13,  158,36,190},
                    new byte[]{68,13,99,43, 149,192,145,43, 83,19,238,57, 128,38,12,4}
                    ), CryptoStreamMode.Write);

                DataSet DS = new AllDataSet.LastConnection();
				DataTable T = DS.Tables[0];
				DataRow R = T.NewRow();
				R["Server"]= server;
				R["DataBase"]= db;
				R["user"]= user;
				R["Password"]= pwd;				
				R["Report"]= report;
				T.Rows.Add(R);
				DS.WriteXml(CryptoS,XmlWriteMode.WriteSchema);
                //DS.WriteXml(FileS, XmlWriteMode.WriteSchema);
                CryptoS.FlushFinalBlock();
                CryptoS.Close();
                CryptoS.Dispose();
                //FileS.Flush();
				FileS.Close();
                FileS.Dispose();
				labMsg.Text="File di configurazione Creato correttamente nella cartella"+path;
				labMsg.Text+=" Ricordarsi ora di aggiungere le autorizzazioni di CONTROLLO COMPLETO "+
					" all'utente impersonato per la cartella ReportPDF, e rimuovere le autorizzazioni in"+
					" scrittura per la cartella cfg.";

 



			}
		}

		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
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
		private void InitializeComponent()
		{    

		}
		#endregion
	}
}
