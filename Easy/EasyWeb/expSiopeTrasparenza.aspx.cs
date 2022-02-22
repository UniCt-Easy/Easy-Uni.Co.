
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


using EasyWebReport;
using funzioni_configurazione;
using metadatalibrary;
using Newtonsoft.Json;
using System;
using System.Data;
using System.IO;
using System.Text;
using System.Web.UI;
using System.Xml;

public partial class expSiopeTrasparenza : System.Web.UI.Page {
    public static string xmlparams = "?[&year=anno][&json=1|&xml=1][&dep=dipartimento]";

    bool IsDataRequest() {
        if (Request.Params["json"] != null) return true;
        if (Request.Params["xml"] != null) return true;
        return false;
    }

    DataAccess DepConn = null;

    void GestisciDataRequest(DataAccess DepConn) {
        int ayear = DateTime.Now.Year;

        if (Request.Params["year"] != null && Request.Params["year"].ToString() != "") {
            int aa = CfgFn.GetNoNullInt32(Request.Params["year"]);
            if (aa != 0) ayear = aa;
        }

        DataTable Res = GetMainData(DepConn, ayear);

        if (Request.Params["json"] != null) {
            WriteJson(Res);
            return;
        }
        if (Request.Params["xml"] != null) {
            WriteXmlOutput(Res);
            return;
        }

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
            if (i%2 == 0) {
                SB.Append("\r\n<tr class='odd'>\r\n");
            }
            else {
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
        int n_anno = CfgFn.GetNoNullInt32(HelpForm.GetObjectFromString(typeof(int), anno.Text, null));
        if (n_anno == 0) n_anno = DateTime.Now.Year;       
        DataTable dt = GetMainData(DepConn, n_anno);

        string xml = getHtmlForTable(dt);
        mydata.InnerHtml = xml;
    }

    string dep = "amministrazione";

    protected void Page_Load(object sender, EventArgs e) {
        DataAccess DepConn = null;


        if (Request != null) {
            if (Request.Params["dep"] != null && Request.Params["dep"].ToString() != "") {
                dep = Request.Params["dep"];
            }
        }

        DepConn = GetDepartmentConn(dep);
        if (DepConn == null) return;

        if (IsDataRequest()) {
            GestisciDataRequest(DepConn);
            return;
        }

        if (!IsPostBack) {
            anno.Text = DateTime.Now.Year.ToString();
            return;
        }

        RenderHtmlPage(DepConn);
        DepConn.Close();
        GetVars.clearSystemDataAccess(this);
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

    void WriteJson(DataTable T) {
        Page.Response.ContentType = "application/json";
        Page.Response.Charset = "UTF-8";

        Page.Response.ClearContent();

        JsonSerializerSettings settings = new JsonSerializerSettings();
        string json = JsonConvert.SerializeObject(T, settings);

        Page.Response.Write(json);
        Page.Response.End();
    }

    void WriteXmlOutput(DataTable T) {
        Page.Response.ContentType = "application/xml";
        Page.Response.Charset = "UTF-8";

        XmlWriterSettings settings = new XmlWriterSettings();
        settings.Encoding = Encoding.UTF8;
        settings.CheckCharacters = true;
        //settings.Indent = true;

        XmlWriter writer = XmlWriter.Create(Page.Response.OutputStream, settings);
        T.WriteXml(writer);
        writer.Flush();
        writer.Close();

        Page.Response.End();
    }

    void WriteBinary(string filename, Byte[] B) {
        string ext = Path.GetExtension(filename);
        Response.Buffer = false;
        Response.Clear();
        Response.ClearContent();
        Response.ClearHeaders();
        Response.AppendHeader("Content-Disposition", "attachment; filename=\"" + filename+"\"");
        if (ext != null && ext != "") {
            Response.ContentType = "image/" + ext;
        }
        else {
            Response.ContentType = "application/octet-stream";
        }
        Response.BinaryWrite(B);
        Response.Flush();
        Response.End();
    }

    DataTable GetMainData(DataAccess Conn, int ayear) {
        QueryHelper QHS = Conn.GetQueryHelper();
        object[] parametri = new object[] {ayear};
        DataSet result = Conn.CallSP("compute_export_siope", parametri, true, 3000);
        if ((result == null) || (result.Tables.Count == 0)) {
            Error("Errore nell'estrazione dei dati");
            return null;
        }

        DataTable tAnac = result.Tables[0];
        if (tAnac == null) {
            Error("Errore nell'estrazione dei dati");
            return null;
        }

        //string path = HttpContext.Current.Request.Url.OriginalString;
        ////"http://localhost:2826/EasyWebReport_2009/expSiopeTrasparenza.aspx?dep=amm?json=1"	
        //int pos = path.IndexOf("rilevazionianac_service");
        //path = path.Substring(0, pos);

        return tAnac;
    }

    protected override void SavePageStateToPersistenceMedium(object state) {
        Session["VSTATE"] = state;
    }

    protected override object LoadPageStateFromPersistenceMedium() {
        return Session["VSTATE"];
    }
}
