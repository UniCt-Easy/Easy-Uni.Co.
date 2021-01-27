
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


using EasyWebReport;
using metadatalibrary;
using System;
using System.Data;
using System.Text;
using System.Web.UI;
using System.Xml;
using Newtonsoft.Json;
using System.IO;

public partial class expNextFm : System.Web.UI.Page
{
	DataAccess DepConn = null;

	string dep = "amministrazione";  
	//string dep = "AMM";  //per rettorato_ok

	bool IsDataRequest() {
	    if (Request.Params["json"] != null) return true;
		if (Request.Params["xml"] != null) return true;
		return false;
	}

	protected void Page_Load(object sender, EventArgs e) {
		DataAccess DepConn = null;


		if (Request != null) {
			if (Request.Params["dep"] != null)
				dep = Request.Params["dep"];
		}

		DepConn = GetDepartmentConn(dep);
		if (DepConn == null) return;

		if (IsDataRequest()) {
			GestisciDataRequest(DepConn);
			return;
		}

		RenderHtmlPage(DepConn);
		DepConn.Close();
		GetVars.clearSystemDataAccess(this);
	}


	void GestisciDataRequest(DataAccess DepConn) {
		string rfid = "";

		if (Request.Params["rfid"] != null && Request.Params["rfid"] != "") {
			rfid = Request.Params["rfid"].ToString();
			if (rfid.ToString().ToUpper() == "ALL") rfid = "";
		}
		DataTable Res = GetMainData(DepConn, rfid);

	    if (Request.Params["json"] != null) {
	        WriteJson(Res);
	        return;
	    }
	    if (Request.Params["xml"] != null) {
	        WriteXmlOutput(Res);
	        return;
	    }
		
	}

    void WriteJson(DataTable T) {
        Page.Response.ContentType = "application/json";
        Page.Response.Charset = "UTF-8";

        Page.Response.ClearContent();

        JsonSerializerSettings settings = new JsonSerializerSettings();
        string json = JsonConvert.SerializeObject(T, settings);

        Page.Response.Write(json);
        Page.Response.End();
    }

	string GetAlignForColumn(DataColumn C) {
		System.Windows.Forms.HorizontalAlignment H = HelpForm.GetAlignForColumn(C);
		if (H == System.Windows.Forms.HorizontalAlignment.Center) return " align='center' ";
		if (H == System.Windows.Forms.HorizontalAlignment.Right) return " align='right' ";
		return "";
	}

	string GetClassForData(DataColumn C, string baseclass) {
		if (C.DataType == typeof(decimal)) baseclass += " t_decimal ";
		if (C.DataType == typeof(DateTime)) baseclass += " t_date ";
		if (baseclass != "") {
			baseclass = baseclass.Trim();
			return " class='" + baseclass + "' ";
		}
		return "";
	}

	string getHtmlForTable(DataTable T) {
		StringBuilder SB = new StringBuilder();

		SB.Append("\r\n<table id='table-contratti' class='apreg_table'>\r\n");
		SB.Append("<thead>\r\n");
		SB.Append("<tr>\r\n");
		foreach (DataColumn C in T.Columns) {
			SB.Append("<th" + GetAlignForColumn(C) + ">" + C.Caption + "</th>");
		}
		SB.Append("\r\n</tr>\r\n");

		SB.Append("</thead>\r\n");
		SB.Append("<tbody>\r\n");

		int i = 0;

		foreach (DataRow R in T.Rows) {
			i++;
			string odd = "";
			if (i % 2 == 0) {
				SB.Append("\r\n<tr class='odd'>\r\n");
			} else {
				SB.Append("\r\n<tr>\r\n");
			}


			foreach (DataColumn C in T.Columns) {
				SB.Append("<td " + GetClassForData(C, "") + GetAlignForColumn(C) + ">" +
						  HelpForm.StringValue(R[C], null) + "</td>");
			}
			SB.Append("\r\n</tr>\r\n");
		}

		SB.Append("</tbody>\r\n");

		SB.Append("</table>\r\n");
		return SB.ToString();
	}

	void RenderHtmlPage(DataAccess DepConn) {
		string rfid = "";

		if (Request.Params["rfid"] != null && Request.Params["rfid"] != "") {
			rfid = Request.Params["rfid"].ToString();
			if (rfid.ToString().ToUpper() == "ALL") rfid = "";
		} else {
			return;
		}
		DataTable Res = GetMainData(DepConn, rfid);

		string xml = getHtmlForTable(Res);
		mydata.InnerHtml = xml;
	}

	DataAccess GetDepartmentConn(string dep) {
		DataSet Cfg = GetVars.GetConfigDataSet(this);
		if (Cfg.Tables[0].Rows.Count == 0) {
			Error("Servizio non installato correttamente. Manca il file di configurazione.");
			return null;
		}
		string error;
		DataAccess Conn = GetVars.GetSystemDataAccess(this, out error);
		if (Conn == null) {
			Error("Connessione al db di sistema non riuscita.");
			return null;
		}
		return GetDepAccess(Conn, dep);
	}

	protected override void OnUnload(EventArgs e) {
		if (DepConn != null) {
			DepConn.Destroy();
		}
		GetVars.clearSystemDataAccess(this);
		base.OnUnload(e);


	}

	DataAccess GetDepAccess(DataAccess Conn, string dep) {
		QueryHelper QHS = Conn.GetQueryHelper();

		string filterdip = QHS.CmpEq("codicedipartimento", dep);
		DataTable CodDip = Conn.RUN_SELECT("codicidipartimenti", "*", null, filterdip, null, true);

		if ((CodDip == null) || (CodDip.Rows.Count == 0)) {
			//Dati non corretti
			Error(dep + ": Codice non corretto");
			return null;
		}
		if (CodDip.Rows.Count > 1) {
			//Attenzione nel DB non è garantita l'unicità dei dati.
			Error("Attenzione !!! Duplicazione di codici per " + dep);
			return null;
		}

		string err = "";
		DataRow myDr = CodDip.Rows[0];
		//Session["Dipartimento"] = myDr["Dipartimento"].ToString();


		//Creo la connessione.
		DataAccess UsrConn = GetVars.CreateUserConn(this, myDr, null, null, DateTime.Now, out err);
		if (UsrConn == null) {
			Error("Connessione al db del dipartimento " + dep + " non riuscita. ");
			return null;
		}

		return UsrConn;
	}

	void Error(string message) {
		Page.Response.ContentType = "text/plain";
		Page.Response.ClearContent();
		Page.Response.Write(message);
		Page.Response.End();
	}

	void SetValueForNull(DataTable dt) {
		int i, j;
		for (i = 0; i < dt.Columns.Count; i++) {
			for (j = 0; j < dt.Rows.Count; j++) {
				if (dt.Columns[i].DataType.ToString() == "System.Int32" || dt.Columns[i].DataType.ToString() == "System.Single" || dt.Columns[i].DataType.ToString() == "System.Double" || dt.Columns[i].DataType.ToString() == "System.Decimal") {
					if (dt.Rows[j][i] == DBNull.Value)
						dt.Rows[j][i] = 0;


				} else if (dt.Columns[i].DataType.ToString() == "System.String") {


					if (dt.Rows[j][i] == DBNull.Value || dt.Rows[j][i].ToString().Trim() == "")
						dt.Rows[j][i] = "";
				}
			}
		}
	}

	void WriteXmlOutput(DataTable T) {
		Page.Response.ContentType = "application/xml";
		Page.Response.Charset = "UTF-8";

		XmlWriterSettings settings = new XmlWriterSettings();
		settings.Encoding = Encoding.UTF8;
		settings.CheckCharacters = true;
		//settings.Indent = true;

		SetValueForNull(T);
		StringWriter sw = new StringWriter();
		T.WriteXml(sw);
		string result = sw.ToString();

		//si vuole che i campi null abbiano comunque i rispettivi tag e WriteXml(writer) non lo consente
		//l'unica alternativa possibile sarebbe di trasformare tutte le colonne numeriche in string

		result = result.Replace(">0<", "><");
		result = result.Replace(">0.00<", "><");
		result = result.Replace(">0,00<", "><");
		byte[] bytes = Encoding.UTF8.GetBytes(result);

		Response.OutputStream.Write(bytes, 0, bytes.Length);

		//XmlWriter writer = XmlWriter.Create(Page.Response.OutputStream, settings);

		//T.WriteXml(writer);
		//writer.Flush();
		//writer.Close();

		Page.Response.End();
	}

	DataTable GetMainData(DataAccess Conn, string rfid) {
		QueryHelper QHS = Conn.GetQueryHelper();
		string all = "N";
		if (rfid == "") {
			all = "S";
		}
			
		object[] parametri = new object[] {rfid, all};
		DataSet result = Conn.CallSP("compute_export_datipatrim", parametri, false, 3000);
		if ((result == null) || (result.Tables.Count == 0)) {
			Error("Errore nell'estrazione dei dati");
			return null;
		}

		DataTable tAnac = result.Tables[0];
		if (tAnac == null) {
			Error("Errore nell'estrazione dei dati");
			return null;
		}

		return tAnac;
	}

}
