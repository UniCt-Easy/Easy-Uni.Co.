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
using System.IO;

namespace EasyWebReport {

    public partial class AttachmentView : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            string FileName;
            string cmd = Session["AttachmentCommand"] as string;
            string fname = Session["AttachmentFileName"] as string;
            object AttachmentFile = Session["AttachmentFile"];
            
            if ((cmd == null) && (AttachmentFile == null)) return;
            byte[] ByteArray = (byte[])AttachmentFile;

            string MyGuid = Session.SessionID.ToString();
            string str;
            str = DateTime.Now.ToString();
            str = str.Replace("/", "");
            str = str.Replace(".", "");
            str = str.Replace(" ", "");
            //Costruisce il nome del File (AnnoMeseGiornoOraMinutiSecondi)
            //FileName = str.Substring(4,4) + str.Substring(2,2) + str.Substring(0,2) + "h" + str.Substring(8,str.Length - 8);
            string prefix = Session["TipoUtente"] as String;
            if (prefix == "fornitore") {
                prefix += "-" + Session["CodiceFornitore"].ToString();
            }
            if (prefix == "responsabile") {
                prefix += "-" + Session["CodiceResponsabile"].ToString();
            }


            prefix = GetVars.GetUsrVar(this, "CodiceDipartimento").ToString() + "-" + prefix + "-";
            prefix = prefix.Replace("\\", "");
            prefix = prefix.Replace("/", "");
            prefix = prefix.Replace("*", "");
            prefix = prefix.Replace("?", "");
            prefix = prefix.Replace("$", "");
            prefix = prefix.Replace("%", "");


            FileName = prefix +  "-" + System.Guid.NewGuid().ToString() + fname;

            string errmess;

            Easy_DataAccess Conn = GetVars.GetUserConn(this);
            if (cmd != null){
                object doc = Conn.DO_SYS_CMD(cmd, true);


                if (doc == null || doc == DBNull.Value){
                    Session["Messaggio"] = "Documento non trovato";
                    Session["CloseWindow"] = true;
                    Session["AttachmentCommand"] = null;
                    Session["AttachmentFileName"] = null;
                    Response.Redirect("Messaggio.aspx");
                    return;
                }
                ByteArray = (byte[])doc;
            }

            // Restituisce il percorso fisico locale della cartella ReportPDF  ex: c:\inetpub\wwwroot\.....
            string FilePath = this.MapPath("ReportPDF");
            if (!FilePath.EndsWith("\\")) FilePath += "\\";

            string filenametodelete = FilePath + prefix + "*.*";
            string[] existingreports = System.IO.Directory.GetFiles(
                FilePath, prefix + "*.*");
            foreach (string filename in existingreports) {
                System.IO.File.Delete(filename);
            }

            string PDFfilePathRedir =	//FilePath +
                "ReportPDF/" +
                FileName;

            string sw = Path.Combine(FilePath, FileName);
            FileStream FS = new FileStream(sw, FileMode.Create, FileAccess.Write);

            //byte[] ByteArray = (byte[])doc;

            int n = ByteArray.Length;
            if (n == 0) {
                Session["Messaggio"] = "Documento non trovato";
                Session["CloseWindow"] = true;
                Session["AttachmentCommand"] = null;
                Session["AttachmentFileName"] = null;
                Response.Redirect("Messaggio.aspx");
                return;
            }

            try {
                FS.Write(ByteArray, 0, n);//<<<<<<<<<
                FS.Flush();
                FS.Close();
            }
            catch { 
                string mym = "Non Ë stato possibile completare il salvataggio del file. \r";
                Session["CloseWindow"] = true;
                Session["Messaggio"] = mym;
                Response.Redirect("Messaggio.aspx");
                return;
            }
            //Visualizza il Report in formato PDF
            //WebLog.Log(this,"Visualizza il file in formato PDF");
            Session["AttachmentCommand"] = null;
            Session["AttachmentFileName"] = null;

            Response.Redirect(PDFfilePathRedir);


        }
    }
}