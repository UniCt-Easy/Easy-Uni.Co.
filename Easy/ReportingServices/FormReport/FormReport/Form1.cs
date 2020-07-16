/*
    Easy
    Copyright (C) 2020 Università degli Studi di Catania (www.unict.it)
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

﻿using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.SqlServer;
using System.IO;

namespace FormReport {
    public partial class Form1 :Form {
        public Form1() {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) {
        


        }

        private string ExportReport(string format,string extension) {
            Warning[] warnings;
            string[] streamids;
            string mimeType;
            string encoding;
            string filenameExtension;


            ReportParameterInfoCollection pInfo = reportViewer1.ServerReport.GetParameters();
            string filenameParams = "output";


            byte[] bytes;
            if (reportViewer1.ProcessingMode == ProcessingMode.Local) {
                bytes = reportViewer1.LocalReport.Render(format, null, out mimeType,
                 out encoding, out filenameExtension, out streamids, out warnings);
            }
            else {
                bytes = reportViewer1.ServerReport.Render(format, null, out mimeType,
                 out encoding, out filenameExtension, out streamids, out warnings);
            }


            string filename = Path.Combine(Path.GetTempPath(), filenameParams + extension);
            using (FileStream fs = new FileStream(filename, FileMode.Create)) { fs.Write(bytes, 0, bytes.Length); }

            return filename;
        }

		private void BtnCalcola_Click(object sender, EventArgs e) {
			    // Set the processing mode for the ReportViewer to Remote  
            reportViewer1.ProcessingMode = ProcessingMode.Remote;

            ServerReport serverReport = reportViewer1.ServerReport;

            // Get a reference to the default credentials  
            System.Net.ICredentials credentials =
                new System.Net.NetworkCredential(txtUser.Text,txtPassword.Text);

            // Get a reference to the report server credentials  
            ReportServerCredentials rsCredentials =
                serverReport.ReportServerCredentials;

            
            // Set the credentials for the server report  
            rsCredentials.NetworkCredentials = credentials;
           


            // Set the report server URL and report path  
            serverReport.ReportServerUrl =
                new Uri("http://ufficio1.temposrl.it:8085/ReportServer");
            serverReport.ReportPath = 
                "/Verifica saldo/Report1";

            string[] stringarr = new string[] { "ayear", "2017", "date", "20/06/2017" };


            for (int i = 0; i < stringarr.Length; i++) {
                ReportParameter param = new ReportParameter();
                param.Name = stringarr[i];
                i++;
                param.Values.Add(stringarr[i]);

                reportViewer1.ServerReport.SetParameters(new ReportParameter[] {param});

            }

            reportViewer1.ShowParameterPrompts= false;
            reportViewer1.Name = "Verifica Saldo";

            // Refresh the report  
            reportViewer1.RefreshReport();


           

            //System.Diagnostics.Process.Start(@"C:\Users\Utente\AppData\Local\Temp\tmp.pdf");
            //if (false) { string pdf = ExportReportPDF(); System.Diagnostics.Process.Start(pdf); }
            //if (false) { string excel = ExportReportExcel(); System.Diagnostics.Process.Start(excel); }

            if (true) {
                string exp = ExportReport("PDF", ".pdf"); System.Diagnostics.Process.Start(exp);
                string exp2 = ExportReport("Excel", ".xls"); System.Diagnostics.Process.Start(exp2);
                string exp3 = ExportReport("Image", ".png"); System.Diagnostics.Process.Start(exp3);
                string exp4 = ExportReport("CSV", ".csv"); System.Diagnostics.Process.Start(exp4);
                string exp5 = ExportReport("WORD", ".doc"); System.Diagnostics.Process.Start(exp5);
                string exp6 = ExportReport("XML", ".xml"); System.Diagnostics.Process.Start(exp6);
                string exp7 = ExportReport("Image", ".tif"); System.Diagnostics.Process.Start(exp7);
            }
		}








		//private string ExportReportPDF() {
		//    Warning[] warnings;
		//    string[] streamids;
		//    string mimeType;
		//    string encoding;
		//    string filenameExtension;


		//    ReportParameterInfoCollection pInfo = reportViewer1.ServerReport.GetParameters();
		//    string filenameParams = "";


		//    byte[] bytes;
		//    if (reportViewer1.ProcessingMode == ProcessingMode.Local) {
		//        bytes = reportViewer1.LocalReport.Render("PDF", null, out mimeType,
		//         out encoding, out filenameExtension, out streamids, out warnings);
		//    }
		//    else {
		//        bytes = reportViewer1.ServerReport.Render("PDF", null, out mimeType,
		//         out encoding, out filenameExtension, out streamids, out warnings);
		//    }


		//    string filename = Path.Combine(Path.GetTempPath(), filenameParams + ".pdf");
		//    using (FileStream fs = new FileStream(filename, FileMode.Create)) { fs.Write(bytes, 0, bytes.Length); }

		//    return filename;
		//}


		//private string ExportReportExcel() {
		//    Warning[] warnings;
		//    string[] streamids;
		//    string mimeType;
		//    string encoding;
		//    string filenameExtension;


		//    ReportParameterInfoCollection pInfo = reportViewer1.ServerReport.GetParameters();
		//    string filenameParams = "";


		//    byte[] bytes;
		//    if (reportViewer1.ProcessingMode == ProcessingMode.Local) {
		//        bytes = reportViewer1.LocalReport.Render(
		//               "Excel", null, out mimeType, out encoding,
		//                out filenameExtension,
		//               out streamids, out warnings);

		//    }
		//    else {
		//        bytes = reportViewer1.ServerReport.Render(
		//               "Excel", null, out mimeType, out encoding,
		//                out filenameExtension,
		//               out streamids, out warnings);

		//    }

		//    string filename = Path.Combine(Path.GetTempPath(), filenameParams + "output.xls");

		//    FileStream fss = new FileStream(filename,
		//    FileMode.Create);
		//    fss.Write(bytes, 0, bytes.Length);
		//    fss.Close();

		//    return filename;
		//}


	}
}
