
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
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.IO;

namespace EasyWebReport
{
	/// <summary>
	/// Summary description for WebPDFView.
	/// </summary>
	public partial class WebPDFView : System.Web.UI.Page
	{
		
		protected void Page_Load(object sender, System.EventArgs e) {
			string FileName;
			DataRow Rep = Session["ModuleReportRow"] as DataRow;
			if (Rep==null) return;

			string MyGuid = Session.SessionID.ToString();
			string str;
			str = DateTime.Now.ToString();
			str = str.Replace("/","");
			str = str.Replace(".","");
			str = str.Replace(" ","");
			//Costruisce il nome del File (AnnoMeseGiornoOraMinutiSecondi)
			//FileName = str.Substring(4,4) + str.Substring(2,2) + str.Substring(0,2) + "h" + str.Substring(8,str.Length - 8);
			string prefix = Session["TipoUtente"] as String;
			if (prefix=="fornitore"){
				prefix+="-"+Session["CodiceFornitore"].ToString();
			}
			if (prefix=="responsabile"){
				prefix+="-"+Session["CodiceResponsabile"].ToString();
			}
			prefix = GetVars.GetUsrVar(this,"CodiceDipartimento").ToString()+"-"+prefix+"-";
			prefix= prefix.Replace("\\","");
			prefix= prefix.Replace("/","");
			prefix= prefix.Replace("*","");
			prefix= prefix.Replace("?","");
			prefix= prefix.Replace("$","");
			prefix= prefix.Replace("%","");


			FileName = prefix+Rep["reportname"].ToString()+"-"+ System.Guid.NewGuid().ToString();
			
			DataTable UserPar= (DataTable)Session["UserPar"];
			if (UserPar==null) return;
			DataRow Par = UserPar.Rows[0];
			string errmess;
			
			Easy_DataAccess Conn = GetVars.GetUserConn(this);
            ReportDocument myRptDoc = Easy_DataAccess.GetReport(Conn,Rep, Par, out errmess);
			
			if  (myRptDoc==null){
				Session["Messaggio"] = errmess;
                Session["CloseWindow"] = true;
                Session["UserPar"] = null;
                Session["ModuleReportRow"] = null;

				Response.Redirect("Messaggio.aspx");
				return;
			}
		

			// Restituisce il percorso fisico locale della cartella ReportPDF  ex: c:\inetpub\wwwroot\.....
			string FilePath = this.MapPath("ReportPDF");
			if (!FilePath.EndsWith("\\")) FilePath+="\\";

			string filenametodelete = FilePath+prefix+"*.*";
			string  []existingreports= System.IO.Directory.GetFiles(
				FilePath,prefix+"*.*");
			foreach (string filename in existingreports){
				System.IO.File.Delete(filename);
			}

			string PDFfilePathRedir =	//FilePath +
				"ReportPDF/" + 
				FileName + ".pdf";
			string myFilePdf = ExportToPdf(myRptDoc, FileName,FilePath);
		    myRptDoc.Close();
		    myRptDoc.Dispose();
			if(myFilePdf == null) {
				string mym = "Non è stato possibile completare l'esportazione in formato PDF. \r";
				mym += "E' probabile che i parametri inseriti non siano corretti. \r";
				mym += "Qualora avesse bisogno di assistenza può contattare il servizio assistenza ";
                Session["CloseWindow"] = true;
                Session["Messaggio"] = mym;
				Response.Redirect("Messaggio.aspx");
				return;
			}
			//Visualizza il Report in formato PDF
			//WebLog.Log(this,"Visualizza il file in formato PDF");
            Session["UserPar"] = null;
            Session["ModuleReportRow"] = null;
		    GC.Collect();
			Response.Redirect(PDFfilePathRedir);
			
		}

		/// <summary>
		/// Restituisce il percorso del report in formato PDF a cui puntare con Response.Redirect
		/// </summary>
		/// <param name="FileName"></param>
		/// <param name="RelativePath"></param>
		/// <returns></returns>
		public string ExportToPdf( ReportDocument RD, string FileName,string RelativePath) {
			// Declare variables and get the export options.
			//ExportOptions exportOpts = new ExportOptions();
			//PdfRtfWordFormatOptions pdfRtfWordOpts = new PdfRtfWordFormatOptions ();

			// Set the export format.
			//pdfRtfWordOpts.FirstPageNumber = 1;
			//pdfRtfWordOpts.LastPageNumber = 2;
			//pdfRtfWordOpts.UsePageRange = true;
			//RD.ExportOptions.FormatOptions = pdfRtfWordOpts;
			RD.ExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;
			RD.ExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
			
			DiskFileDestinationOptions diskOpts = new DiskFileDestinationOptions();
			diskOpts.DiskFileName =  RelativePath + FileName + ".pdf";		
			RD.ExportOptions.DestinationOptions = diskOpts;
		
			// Export the report
			RD.Export();
			//WebLog.Log(this,"E' stato creato il file " + FileName + " del report.");
			//Ritorna il percorso del Report in formato PDF
			return(RelativePath + FileName + ".pdf");
		}


        public string ExportToWord(ReportDocument RD, string FileName, string RelativePath) {
            RD.ExportOptions.ExportFormatType = ExportFormatType.WordForWindows;
            RD.ExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;

            DiskFileDestinationOptions diskOpts = new DiskFileDestinationOptions();
            diskOpts.DiskFileName = RelativePath + FileName + ".doc";
            RD.ExportOptions.DestinationOptions = diskOpts;

            // Export the report
            RD.Export();
            return (RelativePath + FileName + ".doc");
        }

        public string ExportToExcel(ReportDocument RD, string FileName, string RelativePath) {
            RD.ExportOptions.ExportFormatType = ExportFormatType.Excel;
            RD.ExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;

            DiskFileDestinationOptions diskOpts = new DiskFileDestinationOptions();
            diskOpts.DiskFileName = RelativePath + FileName + ".xls";
            RD.ExportOptions.DestinationOptions = diskOpts;

            // Export the report
            RD.Export();
            return (RelativePath + FileName + ".xls");
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
