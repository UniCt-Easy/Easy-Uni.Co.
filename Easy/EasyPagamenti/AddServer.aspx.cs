
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
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using metadatalibrary;
using metaeasylibrary;
using EasyPagamenti;
using EasyPagamentiDataSet;

namespace EasyWebReport
{
	/// <summary>
	/// Summary description for AddServer.
	/// </summary>
	public partial class AddServer : System.Web.UI.Page
	{
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
            string error = "";
            DataAccess sys = GetVars.GetSystemDataAccess(this, out error);
            if (sys == null) {
                labMsg.Text = "Servizio Web non installato correttamente.";
                if (error != null) labMsg.Text += error;
                return;
            }
            if (Session["pwd_system"] != null) {
                LabelPasswordCfg.Visible = false;                
            }
			// Put user code to initialize the page here
			if (IsPostBack){
				
				

				string pwdsys = Request.Form["txtPwdSystem"].ToString();
                if (Session["pwd_system"] == null) {
                    if (pwdsys != "web report fc-hires") {
                        labMsg.Text = "Password di sistema non accettata.";
                        return;
                    }
                    Session["pwd_system"] = "1";
                }
				string dip= txtDip.Text;
				string codice = txtCodice.Text;
				string ip = txtIP.Text;
				string db = txtDB.Text;
				string user = txtUser.Text;
				string pwd = Request.Form["txtPWD"].ToString();
				Easy_DataAccess Conn = new Easy_DataAccess(
					"mydsn",ip,db,user,pwd,user,pwd,DateTime.Now.Year,DateTime.Now);
				if (Conn==null){
					labMsg.Text= "Non è stato possibile collegarsi al server.";
					return;
				}
				Conn.Open();
				if (Conn.openError){
					labMsg.Text= "Non è stato possibile collegarsi al server.";
					return;
				}
				Conn.Close();
				DataSet DS = new Dipartimenti();
                QueryHelper QHS = sys.GetQueryHelper();
                string searchdip = QHS.CmpEq("CodiceDipartimento",codice);
                if (sys.RUN_SELECT_COUNT("CodiciDipartimenti",searchdip, true) > 0) {
                    labMsg.Text = "Codice dipartimento già esistente, sarà aggiornato.";
                    DataTable T = DS.Tables[0];
                    sys.RUN_SELECT_INTO_TABLE(T, null, searchdip, null, false);
                    DataRow R = T.Rows[0];
                    R["CodiceDipartimento"] = codice;
                    R["dipartimento"] = dip;
                    R["IPserver"] = GetVars.CryptPassword(ip);
                    R["NomeDB"] = GetVars.CryptPassword(db);
                    R["UserDB"] = GetVars.CryptPassword(user);
                    R["PassDB"] = GetVars.CryptPassword(pwd);
                }
                else {
                    DataTable T = DS.Tables[0];
                    DataRow R = T.NewRow();
                    R["CodiceDipartimento"] = codice;
                    R["dipartimento"] = dip;
                    R["IPserver"] = GetVars.CryptPassword(ip);
                    R["NomeDB"] = GetVars.CryptPassword(db);
                    R["UserDB"] = GetVars.CryptPassword(user);
                    R["PassDB"] = GetVars.CryptPassword(pwd);
                    T.Rows.Add(R);
                }
				var CP = new Easy_PostData_NoBL();
				CP.InitClass(DS,sys);
				ProcedureMessageCollection  MCOLL = CP.DO_POST_SERVICE();
                if (!MCOLL.CanIgnore){
					labMsg.Text="Delle regole di sicurezza impediscono l'update del db di sistema!!";
					return;
				}

			    if (MCOLL.Count > 0) {
			        MCOLL = CP.DO_POST_SERVICE();
			        if (MCOLL.Count>0) {
			            labMsg.Text = "Delle regole di sicurezza hanno impedito l'update del db di sistema!!";
			            return;
			        }
			    }

			    labMsg.Text="DB DI SISTEMA Aggiornato correttamente.";

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
