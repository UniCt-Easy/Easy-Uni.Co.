
/*
Easy
Copyright (C) 2024 Università degli Studi di Catania (www.unict.it)
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


using funzioni_configurazione;
using metadatalibrary;
using Newtonsoft.Json;
using System;
using System.Data;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Xml;

namespace EasyWebReport {
    public partial class rilevazionianac_service : System.Web.UI.Page {
        public static string xmlparams = "?[&year=anno][&cigcode=cig][&json=1|&xml=1][&dep=dipartimento]";

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
            string cigcode = null;
            if (Request.Params["cigcode"] != null && Request.Params["cigcode"].ToString() != "") {
                cigcode = Request.Params["cigcode"];
            }
            DataTable Res = GetMainData(DepConn, ayear, cigcode);

            if (Request.Params["json"] != null) {
                WriteJson(Res);
                return;
            }
            if (Request.Params["xml"] != null) {
                WriteXmlOutput(Res);
                return;
            }
        }

        void GestisciRichiestaAllegato(DataAccess DepConn) {
            QueryHelper QHS = DepConn.GetQueryHelper();

            string idmankind = Request.Params["idmankind"];
            int yman = CfgFn.GetNoNullInt32(Request.Params["yman"]);
            int nman = CfgFn.GetNoNullInt32(Request.Params["nman"]);
            int idattachment = CfgFn.GetNoNullInt32(Request.Params["idattachment"]);

            if (string.IsNullOrEmpty(idmankind) || yman == 0 || nman == 0 || idattachment == 0) {
                Error("Formato di richiesta errato.");
                return;
            }

            string filter = QHS.AppAnd(
                QHS.CmpEq("idmankind", idmankind),
                QHS.CmpEq("yman", yman),
                QHS.CmpEq("nman", nman),
                QHS.CmpEq("idattachment", idattachment)
            );

            DataTable tAttachments = DepConn.RUN_SELECT("mandateattachment", "filename, attachment", null, filter, "1", false);
            if (tAttachments.Rows.Count == 0) {
                Error("L'allegato specificato non è presente in archivio.");
                return;
            }

            DataRow rAttachment = tAttachments.Rows[0];
            if (DBNull.Value.Equals(rAttachment["attachment"])) {
                Error("L'allegato specificato non è presente in archivio.");
                return;
            }

            string filename = rAttachment["filename"].ToString();
            byte[] attachment = (byte[])rAttachment["attachment"];

            WriteBinary(filename, attachment);
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

                if (i%2 == 0) {
                    SB.Append("\r\n<tr class='odd'>\r\n");
                }
                else {
                    SB.Append("\r\n<tr>\r\n");
                }

                foreach (DataColumn C in T.Columns) {
                    if (C.Caption.Equals("Allegati")) {
                        SB.AppendFormat("<td {0} {1}>", GetClassForData(C, ""), GetAlignForColumn(C));

                        if (DBNull.Value.Equals(R[C])) {
                            SB.Append("N/D");
                        }
                        else {
                            XmlDocument doc = new XmlDocument();
                            doc.LoadXml(R[C].ToString());

                            string[] fields = R["ID"].ToString().Split('§');

                            foreach (XmlElement allegato in doc.DocumentElement.ChildNodes) {
                                string idattachment = allegato.Attributes["id"].Value;
                                string filename = allegato.ChildNodes[0].InnerText;

                                SB.AppendFormat("<a href='rilevazionianac_service.aspx?dep={0}&idmankind={1}&yman={2}&nman={3}&idattachment={4}' target='_blank'>{5}</a><br>",
                                    dep, fields[1], fields[2], fields[3], idattachment, filename
                                );
                            }
                        }

                        SB.Append("</td>");
                    }
                    else {
                        SB.Append("<td " + GetClassForData(C, "") + GetAlignForColumn(C) + ">" +
                                  HelpForm.StringValue(R[C], null) + "</td>");
                    }
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
            string cigcode = HelpForm.GetObjectFromString(typeof(string), cig.Text, null).ToString();
            DataTable dt = GetMainData(DepConn, n_anno, cigcode);

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

            // Se c'è il parametro idattachment allora è una richiesta di allegato
            if (Request.Params["idattachment"] != null && Request.Params["idattachment"] != "") {
                GestisciRichiestaAllegato(DepConn);
                return;
            }

            if (!IsPostBack) {
                anno.Text = DateTime.Now.Year.ToString();
                return;
            }

            RenderHtmlPage(DepConn);
            DepConn.Close();
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
            var res = GetDepAccess(Conn, dep);
            Conn.Destroy();
            return res;
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

            JsonTextWriter writer = new JsonTextWriter(new StreamWriter(Page.Response.OutputStream));
            writer.WriteStartArray();

            foreach (DataRow r in T.Rows) {
                string[] idField = r["ID"].ToString().Split('§');

                writer.WriteStartObject();

                foreach (DataColumn c in T.Columns) {
                    if (DBNull.Value.Equals(r[c])) continue;

                    string name = c.Caption;
                    string content = r[c].ToString();

                    writer.WritePropertyName(name);

                    if (c.Caption.Equals("Allegati")) {
                        if (!string.IsNullOrEmpty(content)) {
                            XmlDocument docAllegati = new XmlDocument();
                            docAllegati.LoadXml(content);

                            writer.WriteStartArray();

                            foreach (XmlElement child in docAllegati.DocumentElement.ChildNodes) {
                                string idattachment = child.Attributes["id"].Value;
                                string filename = child.ChildNodes[0].InnerText;

                                string link = string.Format("rilevazionianac_service.aspx?dep={0}&idmankind={1}&yman={2}&nman={3}&idattachment={4}",
                                    dep, idField[1], idField[2], idField[3], idattachment
                                );

                                writer.WriteStartObject();
                                writer.WritePropertyName(filename);
                                writer.WriteValue(link);
                                writer.WriteEndObject();
                            }

                            writer.WriteEndArray();
                        }
                    }
                    else {
                        writer.WriteValue(content);
                    }
                }

                writer.WriteEndObject();
            }

            writer.WriteEndArray();

            writer.Flush();
            writer.Close();

            Page.Response.End();
        }

        void WriteXmlOutput(DataTable T) {
            Page.Response.ContentType = "application/xml";
            Page.Response.Charset = "UTF-8";

            Page.Response.ClearContent();

            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Encoding = Encoding.UTF8;
            settings.CheckCharacters = true;
            //settings.Indent = true;

            XmlWriter writer = XmlWriter.Create(Page.Response.OutputStream, settings);

            XmlDocument doc = new XmlDocument();
            XmlElement rilevazioni = doc.CreateElement("Rilevazioni");

            foreach (DataRow r in T.Rows) {
                XmlElement rilevazione = doc.CreateElement("Rilevazione");

                string[] idField = r["ID"].ToString().Split('§');

                foreach (DataColumn c in T.Columns) {
                    if (DBNull.Value.Equals(r[c])) continue;

                    string name = XmlConvert.EncodeName(c.Caption);
                    string content = r[c].ToString();

                    // Pulisce la stringa
                    content = Regex.Replace(content, @"[\u0000-\u0008\u000B\u000C\u000E-\u001F]", "");

                    if (c.Caption.Equals("Allegati")) {
                        if (!string.IsNullOrEmpty(content)) {
                            XmlElement allegati = doc.CreateElement("Allegati");

                            XmlDocument docAllegati = new XmlDocument();
                            docAllegati.LoadXml(content);

                            foreach (XmlElement child in docAllegati.DocumentElement.ChildNodes) {
                                string idattachment = child.Attributes["id"].Value;
                                string filename = child.ChildNodes[0].InnerText;

                                string link = string.Format("rilevazionianac_service.aspx?dep={0}&idmankind={1}&yman={2}&nman={3}&idattachment={4}",
                                    dep, idField[1], idField[2], idField[3], idattachment
                                );

                                XmlElement allegato = doc.CreateElement("Allegato");
                                allegato.SetAttribute("link", link);
                                allegato.InnerText = filename;

                                allegati.AppendChild(allegato);
                            }

                            rilevazione.AppendChild(allegati);
                        }
                    }
                    else {
                        XmlElement child = doc.CreateElement(name);
                        child.InnerText = content;

                        rilevazione.AppendChild(child);
                    }
                }

                rilevazioni.AppendChild(rilevazione);
            }

            doc.AppendChild(rilevazioni);
            doc.WriteTo(writer);

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

        DataTable GetMainData(DataAccess Conn, int ayear, string cigcode) {
            QueryHelper QHS = Conn.GetQueryHelper();
            object[] parametri = new object[] {ayear, cigcode};
            DataSet result = Conn.CallSP("compute_rilevazioni_anac", parametri, true, 3000);
            if ((result == null) || (result.Tables.Count == 0)) {
                Error("Errore nell'estrazione dei dati");
                return null;
            }

            DataTable tAnac = result.Tables[0];
            if (tAnac == null) {
                Error("Errore nell'estrazione dei dati");
                return null;
            }

            string path = HttpContext.Current.Request.Url.OriginalString;
            //"http://localhost:2826/EasyWebReport_2009/rilevazionianac_service.aspx?dep=amm?json=1"	
            int pos = path.IndexOf("rilevazionianac_service");
            path = path.Substring(0, pos);

            return tAnac;
        }

        protected override void SavePageStateToPersistenceMedium(object state) {
            Session["VSTATE"] = state;
        }

        protected override object LoadPageStateFromPersistenceMedium() {
            return Session["VSTATE"];
        }
    }
}
