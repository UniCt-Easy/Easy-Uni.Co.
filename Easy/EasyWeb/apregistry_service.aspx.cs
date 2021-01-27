
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


using funzioni_configurazione;
using metadatalibrary;
using Newtonsoft.Json;
using System;
using System.Data;
using System.IO;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Xml;

namespace EasyWebReport {

    public partial class apregistry_service : System.Web.UI.Page {
        public static  string xmlparams = "?[kind=[C|D]][&year=anno][&json=1|&xml=1][&dep=dipartimento]";

        bool IsDataRequest() {
            if (Request.Params["json"] != null) return true;
            if (Request.Params["xml"] != null) return true;
            return false;
        }
        DataAccess DepConn = null;
        void GestisciDataRequest(DataAccess DepConn,string dep) {
            int ayear = DateTime.Now.Year;
            string kind = "";

            if (Request.Params["year"] != null && Request.Params["year"].ToString() != "") {
                int aa = CfgFn.GetNoNullInt32(Request.Params["year"]);
                if (aa != 0) ayear = aa;
            }
            if (Request.Params["kind"] != null && Request.Params["kind"].ToString() != "") {
                kind = Request.Params["kind"];
            }
            else {
                Error("Manca il parametro Tipo incaricato [?kind=C/D]. Indicare C per i consulenti o D per i dipendenti.\n\r"+
                    "In dettaglio, la pagina si chiama con la forma: " +
                    HttpContext.Current.Request.Url.AbsoluteUri +xmlparams+"\n\r"+
                    "Ad esempio: "+HttpContext.Current.Request.Url.AbsoluteUri +"?kind=D&year="+DateTime.Now.Year.ToString()+ " per i dipendenti \n\r"+
                    "o  "+HttpContext.Current.Request.Url.AbsoluteUri +"?kind=C&year="+DateTime.Now.Year.ToString()+ " per i cosnulenti \n\r"
                    );
                return;
            }

            DataTable Res = GetMainData(DepConn, ayear, kind,dep);

            if (Request.Params["json"] != null) {
                WriteJson(Res);
                return;
            }
            if (Request.Params["xml"] != null) {
                WriteXmlOutput(Res);
                return;
            }
            
        }

        void GestisciRichiestaCurriculum(DataAccess DepConn) {
            QueryHelper QHS = DepConn.GetQueryHelper();
            int idreg = CfgFn.GetNoNullInt32(Request.Params["idreg"]);
            if (idreg == 0) {
                Error("Formato di richiesta errato.");
                return;
            }
            int idcv = 0;
            if (Request.Params["idcv"] != null && Request.Params["idcv"].ToString() != "") {
                idcv = CfgFn.GetNoNullInt32(Request.Params["idcv"]);
            }
            else {
                Error("Formato di richiesta errato.");
                return;
            }
            DataTable T = DepConn.RUN_SELECT("registrycvattachment", "*", null,
                                QHS.AppAnd(QHS.CmpEq("idreg", idreg),
                                QHS.CmpEq("idregistrycvattachment", idcv)), null, false);
            if (T.Rows.Count == 0) {
                Error("Curriculum non trovato");
                return;
            }
            DataRow R = T.Rows[0];
            if (R["attachment"] == DBNull.Value) {
                Error("Curriculum non trovato");
                return;
            }
            WriteBinary(R["filename"].ToString(), (byte []) R["attachment"]);
        }

        string GetAlignForColumn(DataColumn C) {
            System.Windows.Forms.HorizontalAlignment H = HelpForm.GetAlignForColumn(C);
            if (H == System.Windows.Forms.HorizontalAlignment.Center) return " align='center' ";
            if (H == System.Windows.Forms.HorizontalAlignment.Right) return " align='right' ";
            return "";            
        }

        string GetClassForData(DataColumn C,string baseclass) {
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
                SB.Append("<th"+GetAlignForColumn(C)+">" + C.Caption + "</th>");
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
                }
                else {
                    SB.Append("\r\n<tr>\r\n");
                }

                
                foreach (DataColumn C in T.Columns) {
                    SB.Append("<td " + GetClassForData(C,"") + GetAlignForColumn(C) + ">" + 
                        HelpForm.StringValue(R[C],null) + "</td>");
                }
                SB.Append("\r\n</tr>\r\n");
            }

            SB.Append("</tbody>\r\n");

            SB.Append("</table>\r\n");
            return SB.ToString();
        }
        void RenderHtmlPage(DataAccess DepConn) {
            int n_anno = CfgFn.GetNoNullInt32( HelpForm.GetObjectFromString(typeof(int), anno.Text, null));
            if (n_anno == 0) n_anno = DateTime.Now.Year;
            string kind = rdbTipo.SelectedValue;
            if (kind==null) kind="C";
            kind = kind.ToUpper();
            if (kind != "D") kind = "C";
            DataTable dt = GetMainData(DepConn, n_anno, kind, dep);

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
            if (DepConn == null) {
                GetVars.clearSystemDataAccess(this);
                return;
            }

            if (IsDataRequest()){
                GestisciDataRequest(DepConn,dep);
                DepConn.Close();
                DepConn.Destroy();
                GetVars.clearSystemDataAccess(this);
                return;
            }

            //Se c'è il parametro idreg si tratta di una richiesta di curriculum--> invia il file
            if (Request.Params["idreg"] != null && Request.Params["idreg"] != "") {
                GestisciRichiestaCurriculum(DepConn);
                DepConn.Close();
                DepConn.Destroy();
                GetVars.clearSystemDataAccess(this);
                return;
            }


            if (!IsPostBack) {
                anno.Text = DateTime.Now.Year.ToString();
                rdbTipo.SelectedValue = "C";
                GetVars.clearSystemDataAccess(this);
                return;
            }

            RenderHtmlPage(DepConn);
            DepConn.Close();
            DepConn.Destroy();
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
            Response.AppendHeader("Content-Disposition", "attachment; filename=\""+filename+"\"");
            if (ext!=null && ext != "") {
                Response.ContentType = "image/" + ext;
            }
            else {
                Response.ContentType = "application/octet-stream" ;
            }
            Response.BinaryWrite(B);
            Response.Flush();
            Response.End();
        }
        string getlinkto(string address) {
            string res = "<a href='" + address + "' target='_blank' >link</a>";
            return res;
        }
        DataTable GetMainData(DataAccess Conn, int ayear, string kind, string dep) {
            QueryHelper QHS = Conn.GetQueryHelper();
            object[] parametri = new object[] { ayear, kind };
            DataSet result = Conn.CallSP("compute_serviceregistrytopublish", parametri, true, 3000);
            if ((result == null) || (result.Tables.Count == 0)) {
                Error("Errore nell'estrazione dei dati");
                return null;
            }

            DataTable tServiceregistry = result.Tables[0];
            if (tServiceregistry == null) {
                Error("Errore nell'estrazione dei dati");
                return null;
            }

            //Valorizza il CV leggendo dalla tabelle "registrycvattachment"
            string path = HttpContext.Current.Request.Url.OriginalString;
                    //"http://localhost:2826/EasyWebReport_2009/apregistry_service.aspx?dep=amm?json=1"	
            int pos = path.IndexOf("apregistry_service");
            path = path.Substring(0, pos);


            tServiceregistry.Columns.Add("curriculum_link", typeof(string));
            foreach (DataRow R in tServiceregistry.Rows) {
                
                string nomepaginaCV = "apregistry_service.aspx";
                
                object idcv = R["idcv"];
                if (idcv == null || idcv == DBNull.Value) {
                    R["curriculum_link"] = DBNull.Value;
                }
                else {
                    string req = nomepaginaCV + "?idreg=" + R["idreg"].ToString() + "&idcv=" + idcv.ToString()
                                +"&dep="+dep;
                    R["curriculum_link"] = getlinkto( Path.Combine(path, req));
                }
            }                

            tServiceregistry.TableName = "incarichi";
            if (tServiceregistry.Columns.Contains("idcv")) {
                tServiceregistry.Columns.Remove("idcv");
            }
            if (tServiceregistry.Columns.Contains("idreg")) {
                tServiceregistry.Columns.Remove("idreg");
            }
            return tServiceregistry;
        }
        protected override void SavePageStateToPersistenceMedium(object state) {
            Session["VSTATE"] = state;
        }

        protected override object LoadPageStateFromPersistenceMedium() {
            return Session["VSTATE"];
        }
    }
}
