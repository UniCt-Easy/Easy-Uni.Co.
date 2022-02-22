
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


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Xml;
using System.Xml.Serialization;
using System.Globalization;
using genericSerializer;
//using Xceed.Zip;
//using Xceed.Compression;
using System.IO.Compression;
using System.ServiceModel.Configuration;
using Newtonsoft.Json.Linq;
//using Xceed.FileSystem;
using metadatalibrary;
using pagoPaService;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;
using funzioni_configurazione;
using System.Net.Security;

//using Xceed.Zip.ReaderWriter;

namespace SiopePlus {

    
    class MyWebClient : WebClient
    {
        public static void  SetCertificatePolicy()
        {
            ServicePointManager.ServerCertificateValidationCallback += ValidateRemoteCertificate;
        }

        internal MyWebClient(PagoPaService.OpiSiopeplusConfig cfg) {
            if (!string.IsNullOrEmpty(cfg.cert_filename) && !string.IsNullOrEmpty(cfg.cert_thumbprint)) {
                cert=PagoPaService.checkPfxByThumbPrint(StoreName.My, StoreLocation.CurrentUser, cfg.cert_filename,cfg.cert_thumbprint,cfg.cert_pwd);

            }
            System.Net.ServicePointManager.ServerCertificateValidationCallback = delegate(Object obj, X509Certificate X509certificate, X509Chain chain, System.Net.Security.SslPolicyErrors errors)
            {
                QueryCreator.MarkEvent("ServerCertificateValidationCallback called");
                return true;
            };
        }

        /// <summary>
        /// Certificate validation callback 
        /// </summary>
        public static bool ValidateRemoteCertificate(object sender, X509Certificate cert, X509Chain chain, SslPolicyErrors error)
        {
            QueryCreator.MarkEvent("ValidateRemoteCertificate called");
            return true;
        }



        private X509Certificate2 cert;
      


        protected override WebRequest GetWebRequest(Uri address)
        {
            HttpWebRequest request = (HttpWebRequest)base.GetWebRequest(address);
            if (cert != null) {
                QueryCreator.MarkEvent("Accettato richiesta utilizzando il certificato "+cert.SubjectName.Name);
                request.ClientCertificates.Add(cert);
            }
            else {
                QueryCreator.MarkEvent("Accettato richiesta senza certificato");
            }
            
            return request;
        }
    }

   

    public class SiopePlusREST {
        
        private string endPoint { get; }

        private string user { get; }

        private string password { get; }
        private PagoPaService.OpiSiopeplusConfig cfg;

        private string codiceIpa { get; }
        //Default Constructor
        public SiopePlusREST(string urlRest, PagoPaService.OpiSiopeplusConfig cfg, string user = null, string password = null, string codiceIpa = null) {

            endPoint = urlRest;
            this.user = user;
            this.password = password;
            this.codiceIpa = codiceIpa;
            this.cfg = cfg;

            }

        public string inviaOrdinativi(string file) {

            var wc = new MyWebClient(cfg);
            
            MyWebClient.SetCertificatePolicy();
            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12 | SecurityProtocolType.Tls | SecurityProtocolType.Ssl3;
          

            wc.Headers.Add(HttpRequestHeader.Authorization, "Basic " + Convert.ToBase64String(Encoding.ASCII.GetBytes(user + ":" + password)));
            wc.Headers.Remove("Expect");
            wc.Headers.Remove("Content-Type");
            wc.Headers["Content-Type"] = "text/xml"; 
            //wc.Headers["Content-Transfer-Encoding"]= "binary";
            //wc.Headers.Add("Content-Type", "application/raw");
            int hostStart = endPoint.IndexOf("//");
            int hostStop = endPoint.IndexOf("/", hostStart + 2);
            string host = endPoint.Substring(hostStart + 2, hostStop - hostStart - 2);
            wc.Headers["Host"] = host;
          
            wc.Headers[HttpRequestHeader.Accept] = "*/*";
            wc.Headers[HttpRequestHeader.AcceptEncoding] = "gzip, deflate, br";
            wc.Headers[HttpRequestHeader.AcceptLanguage] = "it-IT,it;q=0.9,en-US;q=0.8,en;q=0.7";
            string onlyfilename = Path.GetFileNameWithoutExtension(file);
            wc.Headers.Remove("Content-Disposition");
            wc.Headers["Content-Disposition"] = onlyfilename + ".xml";
            //wc.Headers["Content-Disposition"] = "form-data; name = " + QueryCreator.quotedstrvalue("attachment",false) + "; filename = " + onlyfilename + ".xml";

            //https://siopeplus-tst.vaservices.eu:444/te/easysiopeente/ext-rest/flussi-opi/{codiceIpa}            
            //string EndPoint = "https://siopeplus-tst.vaservices.eu:444/te/easysiopeente/ext-rest/flussi-opi/";

  
            

            var uri = new Uri(endPoint);
            var servicePoint = ServicePointManager.FindServicePoint(uri);
            servicePoint.Expect100Continue = false;

            //PagoPaService.removeCertificateByThumbPrint(StoreName.AuthRoot, StoreLocation.CurrentUser, cfg.cert_thumbprint);
            //PagoPaService.getCertificateByThumbPrint(StoreName.My, StoreLocation.CurrentUser, cfg.cert_thumbprint);
            var cert = PagoPaService.checkPfxByThumbPrint(StoreName.My, StoreLocation.CurrentUser, cfg.cert_filename,cfg.cert_thumbprint, cfg.cert_pwd);
            if (cert == null) {
                return $"Certificato {cfg.cert_filename} non installato";
            }
            
            string addr = endPoint + codiceIpa;
            byte[] responseOpBinary;

            try {
                //var response = wc.UploadFile(addr, "POST", file);
                byte[] filebytes = File.ReadAllBytes(file);
                responseOpBinary = wc.UploadData(addr, "POST", filebytes);

                //string FileString = System.Text.Encoding.UTF8.GetString(filebytes, 0, filebytes.Length);
                //var response3 = wc.UploadString(addr,"POST", FileString);

                string textResponse = System.Text.Encoding.UTF8.GetString(responseOpBinary, 0, responseOpBinary.Length);
				if (!textResponse.StartsWith("{\n")){
                
	                var responseStream = new GZipStream(new MemoryStream(responseOpBinary), CompressionMode.Decompress);
	                var reader = new StreamReader(responseStream);
	                textResponse = reader.ReadToEnd();
				}

                var esito = "";
                var errore = "";

                var objMessage = JObject.Parse(textResponse);
                esito = ((JValue)objMessage["esito"]).Value.ToString();
                //if (esito.ToString() == "OK") {
                //    return "UploadFile eseguito";
                //}
                JObject sel =  JObject.Parse(textResponse);
                JArray arr = JArray.FromObject(sel["errori"]);

                foreach (var objSelBuild in arr) {
                    var c = objSelBuild["messageCode"];
                    var m = objSelBuild["message"];
                    errore =errore + c.ToString() +"-"+ m.ToString() + "\r\n";
                }
                return esito.ToUpper() == "OK" ? null : errore;
                //return "Risposta malformata";

                //var prms = (JObject)objMessage["prm"];


            }
            catch (Exception ex) {
                //We catch non Http 200 responses here.
                
                QueryCreator.MarkEvent("Reinstallo certificato");
                PagoPaService.removeCertificateByThumbPrint(StoreName.My, StoreLocation.CurrentUser,cfg.cert_thumbprint);
                PagoPaService.checkPfxByThumbPrint(StoreName.My, StoreLocation.CurrentUser, cfg.cert_filename,cfg.cert_thumbprint, cfg.cert_pwd);
                ErrorLogger.Logger.logException("inviaOrdinativi:",ex);
                return ex.ToString();
            }


        }

        //static ManualResetEvent evnts = new ManualResetEvent(false);
        //static void Main(string[] args) {
        //    byte[] data = null;
        //    WebClient client = new WebClient();
        //    client.DownloadDataCompleted +=
        //        delegate (object sender, DownloadDataCompletedEventArgs e) {
        //            data = e.Result;
        //            evnts.Set();
        //        };
        //    //Console.WriteLine("starting...");
        //    evnts.Reset();
        //    client.DownloadDataAsync(new Uri("http://stackoverflow.com/questions/"));
        //    evnts.WaitOne(); // wait to download complete

        //    int x = data.Length;
        //}

        //static async void MioDownload(string addr, WebClient wc) {
        //    byte[] myBuffer = await wc.DownloadDataTaskAsync(addr);
        //    var responseStream = new GZipStream(new MemoryStream(myBuffer), CompressionMode.Decompress);
        //    var reader = new StreamReader(responseStream);
        //}


        public Stream[] GetGiornaledicassa(DateTime inizio, DateTime fine, bool salvaFile, out string errore) {
            errore = null;
            var wc = new MyWebClient(cfg);
            MyWebClient.SetCertificatePolicy();
            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12 | SecurityProtocolType.Tls | SecurityProtocolType.Ssl3;

            wc.Headers.Add(HttpRequestHeader.Authorization, "Basic " + Convert.ToBase64String(Encoding.ASCII.GetBytes(user + ":" + password)));
            wc.Headers.Remove("Expect");
            wc.Headers.Remove("Content-Type");
            wc.Headers[HttpRequestHeader.Accept] = "*/*";
            wc.Headers[HttpRequestHeader.AcceptEncoding] = "deflate";
            //https://oil.uniit.it/rest/ricevute-sistema-contabile/{codice_mif}?
            //tipo ={ gdc | rpc | ricsisc}
            //&da ={ data_inizio}
            //&a ={ data_fne}
            string dataDa = inizio.Year.ToString("0000") +"-"+ inizio.Month.ToString("00") + "-" + inizio.Day.ToString("00");
            string dataA = fine.Year.ToString("0000") + "-" + fine.Month.ToString("00") + "-" + fine.Day.ToString("00");
            string addr = endPoint + codiceIpa + "?tipo=gdc&da=" + dataDa + "&a=" + dataA;

            var uri = new Uri(endPoint);
            var servicePoint = ServicePointManager.FindServicePoint(uri);
            servicePoint.Expect100Continue = false;

            var cert = PagoPaService.checkPfxByThumbPrint(StoreName.My, StoreLocation.CurrentUser, cfg.cert_filename, cfg.cert_thumbprint, cfg.cert_pwd);
            if (cert == null) {
                errore=  $"Certificato {cfg.cert_filename} non installato";
                return null;
            }

            try {
                //var response = wc.DownloadData(addr);

                //MioDownload(addr, wc);

                var responseStr = wc.DownloadData(addr); 
                byte[] response = responseStr;

                if (salvaFile) {
	                File.WriteAllBytes(Path.GetTempFileName()+".zip",responseStr);
                }
                //
                //var responseStream = new GZipStream(new MemoryStream(response), CompressionMode.Decompress);
                //MemoryStream ms = new MemoryStream();
                //responseStream.CopyTo(ms);
                var mm = new MemoryStream(response);
                ZipArchive arch = new ZipArchive(mm,ZipArchiveMode.Update);
                //var entry = arch.Entries;// .First();
                int nS = arch.Entries.Count;
                Stream[] documenti = new Stream[nS]; 
                int i = 0;
                foreach (var entry in arch.Entries) {
                    Stream EntryStream = entry.Open();
                    var EntryReader = new StreamReader(EntryStream);
                    string EntryStr = EntryReader.ReadToEnd();
                    documenti[i]= new MemoryStream(Encoding.UTF8.GetBytes(EntryStr));
                    i++;
                }
                //return entry.Open();
                return documenti;
                //var responseStream = new DeflateStream(new MemoryStream(response), CompressionMode.Decompress);
                //var reader = new StreamReader(responseStream);
                //var textResponse = reader.ReadToEnd();
              

            }
            catch (Exception ex) {
                //We catch non Http 200 responses here.
                errore = ex.ToString();
            }
            return null;

        }


    }
   
}
