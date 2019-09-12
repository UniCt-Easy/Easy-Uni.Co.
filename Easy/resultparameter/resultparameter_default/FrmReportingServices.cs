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

ï»¿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using System.IO;
using metadatalibrary;
using metaeasylibrary;
using System.Drawing.Printing;
using System.Security.Cryptography;

using System.Security;
using System.Security.Permissions;
using System.Data.SqlClient;


namespace resultparameter_default {
    public partial class FrmReportingServices :Form {
        private MetaData meta;
        private DataRow Params;
        private DataRow ModuleReport;
        Easy_DataAccess Conn;
        private bool Preview;
        public FrmReportingServices(Easy_DataAccess MyDA,
            DataRow Params,
            DataRow ModuleReport,
            MetaData meta,
            bool Preview) {
            InitializeComponent();
            this.Params = Params;
            this.ModuleReport = ModuleReport;
            Conn = MyDA;
            this.meta = meta;
            this.Preview = Preview;
        }
        internal static string DecryptKey(byte[] B) {
            if (B == null) return null;
            MemoryStream MS = new MemoryStream();
            CryptoStream CryptoS = new CryptoStream(MS,
                new TripleDESCryptoServiceProvider().CreateDecryptor(
                    new byte[] { 75, 12, 0, 215, 93, 89, 45, 11, 171, 96, 4, 64, 13, 158, 36, 190 },
                    new byte[] { 61, 13, 99, 42, 149, 123, 145, 48, 83, 20, 238, 57, 128, 38, 12, 4 }
                ), CryptoStreamMode.Write);
            CryptoS.Write(B, 0, B.Length);
            CryptoS.FlushFinalBlock();
            string key = Encoding.Default.GetString(MS.ToArray()).TrimEnd();
            return key;
        }
        public void StampaLocalReport() {

            LocalReport localReport = reportViewer1.LocalReport;
            reportViewer1.Reset();
            reportViewer1.ProcessingMode = ProcessingMode.Local;
            string reportname = null;
            foreach (DataColumn c in Params.Table.Columns) {
                if (c.ColumnName == "reportname") {
                    reportname = Params[c.ColumnName].ToString();
                    break;
                }
            }
            // Set the report Path
            reportViewer1.LocalReport.ReportPath = AppDomain.CurrentDomain.BaseDirectory + reportname+".rdlc";
            localReport.ReportPath = AppDomain.CurrentDomain.BaseDirectory + reportname+".rdlc";


            ReportParameter param = null;
            //DataSource Connection string
            param = new ReportParameter();
            param.Name = "conn_string";
            param.Values.Add("Data Source=" + meta.GetSys("server").ToString() + "; Initial Catalog=" + meta.GetSys("database").ToString());//="Data Source="+Parameters!DatabaseServerName.Value+";Initial Catalog="&Parameters!DatabaseName.Value
            reportViewer1.LocalReport.SetParameters(new ReportParameter[] { param });

            string passwordDB = DecryptKey((byte[])Conn.GetSys("passworddb"));
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString =
                "Data Source="+ meta.GetSys("server").ToString() + ";"+
                "Initial Catalog=" + meta.GetSys("database").ToString() + ";" +
                "User="+ meta.GetSys("userdb").ToString() +";" +
                "Password=" + passwordDB + ";";

            conn.Open();
            localReport.Refresh();

            reportViewer1.ShowParameterPrompts = false;
            //Parametri della SP
            foreach (DataColumn c in Params.Table.Columns) {
                if (c.ColumnName == "reportname") {
                    continue;
                }
                param = new ReportParameter();
                param.Name = c.ColumnName;
                param.Values.Add(Params[c.ColumnName].ToString());
                reportViewer1.LocalReport.SetParameters(new ReportParameter[] { param });
            }

            this.Text = ModuleReport["description"].ToString();// Titolo stampa
                                                               // Refresh the report  

 
            reportViewer1.RefreshReport();


        }
        public void FrmReportingServices_Load(object sender, EventArgs e) {
            //StampaLocalReport();
            //return;
            // Set the processing mode for the ReportViewer to Remote  
            reportViewer1.ProcessingMode = ProcessingMode.Remote;

            ServerReport serverReport = reportViewer1.ServerReport;

            DataTable config_reportingservices = Conn.RUN_SELECT("config_reportingservices", "*", null, null, null, false);
            if (config_reportingservices.Rows.Count == 0) {
                return;
            }
            //// Get a reference to the default credentials  
            string networkusername = config_reportingservices.Rows[0]["networkusername"].ToString();
            string networkpwd = config_reportingservices.Rows[0]["networkpwd"].ToString();

            System.Net.ICredentials credentials = new System.Net.NetworkCredential(networkusername, networkpwd);//System.Net.CredentialCache.DefaultCredentials; //

            //// Get a reference to the report server credentials  
            ReportServerCredentials rsCredentials = serverReport.ReportServerCredentials;

            ////// Set the credentials for the server report  
            rsCredentials.NetworkCredentials = credentials;

            string MyReportServerUrl = config_reportingservices.Rows[0]["reportserverurl"].ToString();
            // Set the report server URL and report path  
            serverReport.ReportServerUrl = new Uri(MyReportServerUrl);//new Uri("http://ufficio1.temposrl.it:8085/ReportServer");// new Uri("http://<Server Name>/reportserver");  

            string reportname = null;
            foreach (DataColumn c in Params.Table.Columns) {
                if (c.ColumnName == "reportname") {
                    reportname = Params[c.ColumnName].ToString();
                    break;
                }
            }
            string MyReportPath = config_reportingservices.Rows[0]["reportpath"].ToString();
            // Set the report Path
            serverReport.ReportPath =  MyReportPath +  reportname;    //"/ReportAll/" + reportname;

            ReportParameter param = null;
            //DataSource Connection string
            param = new ReportParameter(); 
            param.Name = "conn_string";
            param.Values.Add("Data Source="+ meta.GetSys("server").ToString()+"; Initial Catalog="+ meta.GetSys("database").ToString() );//="Data Source="+Parameters!DatabaseServerName.Value+";Initial Catalog="&Parameters!DatabaseName.Value
            serverReport.SetParameters(new ReportParameter[] { param });

            //SqlConnection conn = new SqlConnection();
            //conn.ConnectionString = "Data Source=ufficio1.temposrl.it;Initial Catalog=unirc_easy;";

            ///DataSource Credentials
            DataSourceCredentials cred = new DataSourceCredentials();
            ReportDataSourceInfoCollection dataSource = serverReport.GetDataSources();
            cred.Name = dataSource.First().Name;
            cred.UserId = meta.GetSys("userdb").ToString();
            string passwordDB = DecryptKey((byte[])Conn.GetSys("passworddb"));
            cred.Password = passwordDB; 
            serverReport.SetDataSourceCredentials(new DataSourceCredentials[] { cred });
            serverReport.Refresh();


            reportViewer1.ShowParameterPrompts = false;
            //Parametri della SP
            foreach (DataColumn c in Params.Table.Columns) {
                if (c.ColumnName == "reportname") {
                    continue;
                }
                param = new ReportParameter();
                param.Name = c.ColumnName;
                if (Params[c.ColumnName].ToString()=="") {
                    param.Values.Add(null);
                }
                else {
                    param.Values.Add(Params[c.ColumnName].ToString());
                }
                reportViewer1.ServerReport.SetParameters(new ReportParameter[] { param });
            }

            this.Text = ModuleReport["description"].ToString();// Titolo stampa
            // Refresh the report  
            if (Preview) {
                reportViewer1.RefreshReport();
            }
            else{
                string exp = ExportReport("PDF", ".pdf"); System.Diagnostics.Process.Start(exp);
                    //string exp2 = ExportReport("Excel", ".xls"); System.Diagnostics.Process.Start(exp2);
                //    //string exp3 = ExportReport("Image", ".png"); System.Diagnostics.Process.Start(exp3);
                //    //string exp4 = ExportReport("CSV", ".csv"); System.Diagnostics.Process.Start(exp4);
                //    //string exp5 = ExportReport("WORD", ".doc"); System.Diagnostics.Process.Start(exp5);
                //    //string exp6 = ExportReport("XML", ".xml"); System.Diagnostics.Process.Start(exp6);
                //    //string exp7 = ExportReport("Image", ".tif"); System.Diagnostics.Process.Start(exp7);
            }
        }
        private string ExportReport(string format, string extension) {
            Warning[] warnings;
            string[] streamids;
            string mimeType;
            string encoding;
            string filenameExtension;


            ReportParameterInfoCollection pInfo = reportViewer1.ServerReport.GetParameters();
            string tempdir = System.IO.Path.GetTempPath();
            if (!tempdir.EndsWith("\\")) tempdir += "\\";
            var tempfilename = tempdir + Guid.NewGuid();
            string filenameParams = tempfilename;


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
    }
}
