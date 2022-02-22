
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


using System.Net;
using System.Web.Http;
using System.Web.Http.Cors;
using Backend.CommonBackend;
using Backend.Extensions;
using System;
using System.Data;
using System.Web;
using Backend.Models;
using Backend.Security;
using System.Web.Configuration;
using DA = metaeasylibrary.Easy_DataAccess;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json.Linq;
using System.Xml;
using System.IO;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.Text;
using System.Web.Script.Serialization;
using metaeasylibrary;
using System.Linq;

namespace Backend.Controllers {

    /// <summary>
    /// Controller contenente le primitive necessarie per la gestione delle funzioni di admin
    /// </summary>
    /// <remarks>
    /// Il percorso (URL) per accedere ai metodi contenuti in questo controller devono avere il prefisso "/admin".
    /// </remarks>
    [RoutePrefix("admin"), Authorize, EnableCors("*", "*", "*")]
    public class AdminController : ApiController {

        private const int RegistryClassCompany = 21;
        private const int RegistryClassPrivate = 22;

        [HttpPost, Route("adminregisteruser")]
        public IHttpActionResult adminregister(AdminRegistrationFormData data) {
            if (data == null) {
                return base.Content(HttpStatusCode.BadRequest, "Dati non specificati.");
            }

            // legge i prm in input    
            String login = data.login;
            String password = data.password;
            String passwordweb = data.passwordweb;
            String surname = data.surname;
            String forename = data.forename;
            String cf = data.cf;
            String codesflowchart = data.codeflowchart;
            String esercizio = data.esercizio;
            String email = data.email;
            String usertype = data.usertype;
            String matricola = data.matricola;
            String userkind = data.userkind;
            String idregistrationuser = data.idregistrationuser;

            List<string> listCodeflowChart = codesflowchart.Split(';').ToList();
            String msg = "";
            int error = 0;
            List<string> messages = new List<string>();
            foreach (String codeflowchart in listCodeflowChart) {
                AdminRegistrationFormData dataSingleFlowChart = data;
                dataSingleFlowChart.codeflowchart = codeflowchart;
                JObject message = adminregisterSingleCodeflowchart(dataSingleFlowChart);

                if (message["err"]?.ToObject<int>() == 1) {
                    error = 1;
                }
                messages.Add("(profilo " + codeflowchart + ") " + message["msg"]?.ToObject<string>());
            }

            var result = new JObject {
                    {"err", error},
                    {"msg", String.Join(" <br><br> ", messages)}
                };
            return Content(HttpStatusCode.OK, result);

        }

        private JObject adminregisterSingleCodeflowchart(AdminRegistrationFormData data) {

            String login = data.login;
            String password = data.password;
            String passwordweb = data.passwordweb;
            String surname = data.surname;
            String forename = data.forename;
            String cf = data.cf.ToUpper();
            String codeflowchart = data.codeflowchart;
            String esercizio = data.esercizio;
            String email = data.email;
            String usertype = data.usertype;
            String matricola = data.matricola;
            String userkind = data.userkind;
            String idregistrationuser = data.idregistrationuser;


            // 1. genera password web criptata
            Random rnd = new Random();
            var iterations = rnd.Next(20, 100);
            var salt = KeyChain.generateSalt();
            var hash = Password.generateHash(passwordweb, salt, iterations);
            int iterweb = iterations;
            String saltweb = salt.toHexString();
            String passwordwebHash = hash.toHexString();


            // 2. invoca procedura custom per inserimento utente su contatti e gestione di sicurezza

            var dispatcher = HttpContext.Current.getDataDispatcher();
            String db = WebConfigurationManager.AppSettings.Get("DBName");
            String executor = (String)dispatcher.conn.Security.GetUsr("userweb");
            String dipartimento = WebConfigurationManager.AppSettings.Get("DBDipartimento");
            String passwordalpha = "";
            if (password != null) {
                passwordalpha = DA.getAlfaFromPassword(password).toHexString();
            }

            object[] list = new object[] {
                login,
                password,
                db,
                executor,
                dipartimento,
                passwordalpha,
                passwordwebHash,
                iterweb,
                saltweb,
                surname,
                forename,
                cf,
                email,
                codeflowchart,
                esercizio,
                usertype,
                matricola,
                userkind
            };
            string spName = "GenerateUser";

            DataSet DSout = dispatcher.conn.CallSP(spName, list, true, -1);
            string lastError = dispatcher.conn.LastError;
            if (!String.IsNullOrEmpty(lastError)) {
               return new JObject {
                    {"err", 1},
                    {"msg", "c# exception: " + lastError}
                };
            } else {

                // check su registry e registryReference
                string query = "select r.idreg from registry r, registryreference rr where r.cf = '" + cf +
                               "' and rr.idreg = r.idreg";
                DataTable dtReg = dispatcher.conn.SQLRunner(query);

                if (dtReg == null) {
                    return new JObject {
                        {"err", 1},
                        {"msg", "c'è stato un problema nella registrazione"}
                    };  
                }

                if (dtReg.Rows.Count == 0) {
                    return new JObject {
                        {"err", 1},
                        {"msg", "c'è stato un problema nella registrazione"}
                    };
                }

                if (idregistrationuser != null) {
                    // update dello stato
                    String[] columns = { "idregistrationuserstatus" };
                    String[] values = { "2" };
                    dispatcher.conn.DO_UPDATE("registrationuser", "idregistrationuser=" + idregistrationuser, columns,
                        values, 1);
                }

                if (DSout == null) {
                    return new JObject {
                        {"err", 1},
                        {"msg", "procedure returned empty result"}
                    };
                } else {

                    string error = "";
                    ((Easy_DataAccess)dispatcher.conn).linkUserToDepartment(login, out error);

                    if (!String.IsNullOrEmpty(error)) {
                            return new JObject {
                            {"err", 1},
                            {"msg", "error in linkUserToDepartment: " + error}
                        };
                    }


                    // recupero stringa di messaggio calcolata dalla SP.
                    DataTable dt = DSout.Tables[0];
                    string msg = "";
                    if (dt != null && dt.Rows.Count > 0) {
                        DataRow dtrow = dt.Rows[0];
                        msg = (String)dtrow[0];
                    }

                    return new JObject {
                        {"err", 0},                 
                        {"msg", "Dettagli operazioni: " + msg}
                    };
                }

            }
 
        }

        /// <summary>
        /// Svuota la cache.
        /// </summary>
        /// <remarks>       
        /// </remarks>         
        [HttpGet, Route("clearCache")]
        public IHttpActionResult clearCache() {
            CacheMDLW.clearCache();
            return Content(HttpStatusCode.OK, "success");
        }

        /// <summary>
        /// Svuota la cache.
        /// </summary>
        /// <remarks>       
        /// </remarks>         
        [HttpGet, Route("clearSessions")]
        public IHttpActionResult clearSessions() {
            SessionMDLW.clearSessions();
            return Content(HttpStatusCode.OK, "success");
        }


        public class generaPasswordPrm {
            [Required]
            public string password { get; set; }
        }

        /// <summary>
        /// Svuota la cache.
        /// </summary>
        /// <remarks>       
        /// </remarks>         
        [HttpPost, Route("cryptSystemConfig")]
        public IHttpActionResult generatePassword(generaPasswordPrm prms) {
            string cleanPwd = prms.password;
            SystemConfig systemConfig = new SystemConfig(cleanPwd);
            string crypted = Token.encodeSystemConfig(systemConfig);
            return Content(HttpStatusCode.OK, crypted);
        }


        public class CaricodidatticoPrm
        {
            public string docenteCognome { get; set; }

            public string docenteCF { get; set; }
            [Required]
            public string aa { get; set; }
        }
        
        /// <summary>
        /// Svuota la cache.
        /// </summary>
        /// <remarks>       
        /// </remarks>         
        [HttpPost, Route("getCaricoDidattico")]
        public IHttpActionResult getCaricoDidattico(CaricodidatticoPrm prms)
        {

           String body = @"<?xml version=""1.0"" encoding=""utf-8""?>  
            <soap:Envelope xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" xmlns:soap=""http://schemas.xmlsoap.org/soap/envelope/"">  
             <soap:Body>  
                <LogonUser xmlns=""http://www.besmart.it/"">
                  <request>
                      <UserName>webService.GetCaricoDidattico</UserName>
                      <Password>BE222761-927B-4B4E-9C08-EC67806EDEAF</Password>
                  </request>
                </LogonUser>
              </soap:Body>
            </soap:Envelope>";

            HttpWebRequest req  = getSoapRequest("LogonUser");

            XmlDocument SOAPReqBody = new XmlDocument();
            //SOAP Body Request  
            SOAPReqBody.LoadXml(body);

            using (Stream stream = req.GetRequestStream())
            {
                SOAPReqBody.Save(stream);
            }
            //Geting response from request  
            using (WebResponse serviceRes = req.GetResponse())
            {
                using (StreamReader rd = new StreamReader(serviceRes.GetResponseStream()))
                {
                    //reading stream  
                    var serviceResult = rd.ReadToEnd();
                    //writting stream result on console  
                    XmlDocument xmlDocument = new XmlDocument();
                    xmlDocument.LoadXml(serviceResult);
                    var newToken = xmlDocument.GetElementsByTagName("NewToken")[0];

                    string a = Newtonsoft.Json.JsonConvert.SerializeXmlNode(xmlDocument);
                    string token = newToken.InnerXml;

                    return getCaricoDidatticoDocente(token, prms);
                   
                }
            }

        }

        private HttpWebRequest getSoapRequest(String method)
        {
            //Making Web Request    
            HttpWebRequest Req = (HttpWebRequest)WebRequest.Create(@"https://webservices.smartedu.unict.it/service2/didattica/didatticaservice2.asmx");
            //SOAPAction    
            Req.Headers.Add(@"SOAPAction:http://www.besmart.it/" + method);
            //Content_type    
            Req.ContentType = "text/xml;charset=\"utf-8\"";
            Req.Accept = "text/xml";
            //HTTP method    
            Req.Method = "POST";

            return Req;
        }

        private IHttpActionResult getCaricoDidatticoDocente(String token, CaricodidatticoPrm prms)
        {

            String body = @"<?xml version=""1.0"" encoding=""utf-8""?>
               <soap:Envelope xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" xmlns:soap=""http://schemas.xmlsoap.org/soap/envelope/"">
                 <soap:Body>
                   <GetCaricoDidattico xmlns=""http://www.besmart.it/"">
                     <request>
                       <RequestToken>" + token + @"</RequestToken>
                       <SearchParameters>"
                            + getPrmdocenteCaricodidattico(prms) + 
                            @"<AnniAccademici> 
                              <AnnoAccademico/>"+ prms.aa + @"<AnnoAccademico/>
                          </AnniAccademici>    
                       </SearchParameters>
                     </request>
                   </GetCaricoDidattico>
                 </soap:Body>
               </soap:Envelope>";
         

            HttpWebRequest req = getSoapRequest("GetCaricoDidattico");

            XmlDocument SOAPReqBody = new XmlDocument();
            //SOAP Body Request  
            SOAPReqBody.LoadXml(body);

            using (Stream stream = req.GetRequestStream())
            {
                SOAPReqBody.Save(stream);
            }
            //Geting response from request  
            using (WebResponse serviceRes = req.GetResponse())
            {
                using (StreamReader rd = new StreamReader(serviceRes.GetResponseStream()))
                {
                    //reading stream  
                    var serviceResult = rd.ReadToEnd();
                    //writting stream result on console  
                    XmlDocument xmlDocument = new XmlDocument();
                    xmlDocument.LoadXml(serviceResult);
                    string datajson = Newtonsoft.Json.JsonConvert.SerializeXmlNode(xmlDocument);
                    return Content(HttpStatusCode.OK, datajson);

                }
            }
           
        }

        private string getPrmdocenteCaricodidattico(CaricodidatticoPrm prms) {
            string res = "";
            if (prms.docenteCF != null) {
                res += "<DocenteCF>" + prms.docenteCF + @"</DocenteCF>";
            }
            if (prms.docenteCognome != null) {
                res += "<DocenteCognome>" + prms.docenteCognome + @"</DocenteCognome>";
            }

            return res;
        }

        public class AllocationPrm {
          
            public string docenteNome { get; set; }

           
            public string docenteCognome { get; set; }

            [Required]
            public string dataInizio { get; set; }

            [Required]
            public string dataFine { get; set; }
        }

        [HttpPost, Route("getAllocations")]
        public IHttpActionResult getAllocations(AllocationPrm prms) {

            String url = WebConfigurationManager.AppSettings["bismartGetAllocationsUrl"];
            String username = WebConfigurationManager.AppSettings["bismartGetAllocationsUsername"];
            String password = WebConfigurationManager.AppSettings["bismartGetAllocationsPassword"];
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            // request.UserAgent = "Mozilla/5.0 (Windows NT 6.1; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/58.0.3029.110 Safari/537.36";
            httpWebRequest.Method = "POST";
            httpWebRequest.ContentType = "application/json";

            // costruisce dictionary con i parametri
            Dictionary<String, Object> prmDict = new Dictionary<String, Object>();
            prmDict.Add("DocenteNome", prms.docenteNome);
            prmDict.Add("DocenteCognome", prms.docenteCognome);
            prmDict.Add("DataInizio", prms.dataInizio);
            prmDict.Add("DataFine", prms.dataFine);
            prmDict.Add("DocenteCF", null);
            prmDict.Add("PartialDocenteNome", false);
            prmDict.Add("PartialDocenteCognome", false);
            prmDict.Add("StrutturaDidattica", null);
            prmDict.Add("Edificio", null);
            prmDict.Add("Sede", null);
            prmDict.Add("PartialDenominazione", false);
            prmDict.Add("Denominazione", null);
            prmDict.Add("CodiceInterno", null);
            prmDict.Add("TypesNames", null);
            prmDict.Add("Owner", null);
            prmDict.Add("Status", null);
            prmDict.Add("ProgrammazioneVirtuale", null);
            prmDict.Add("ProgrammazioneAnnoAccademico", null);
            prmDict.Add("ProgrammazioneCodiceInterno", null);
            prmDict.Add("Programmazione", null);
            prmDict.Add("UID", null);
            prmDict.Add("CodiceInsegnamentoExtended", null);
            prmDict.Add("CodiceInsegnamento", null);
            prmDict.Add("PrenotabileStudente", null);
            prmDict.Add("UserReference", null);
            prmDict.Add("ChangeSet", null);

            Dictionary<String, Object> mainDict = new Dictionary<String, Object>();
            mainDict.Add("fParams", prmDict);
            mainDict.Add("Logon", username);
            mainDict.Add("Password", password);
            string myJsonString = (new JavaScriptSerializer()).Serialize(mainDict);

            // scrivo json
            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream())) {
                streamWriter.Write(myJsonString);
            }

            var response = (HttpWebResponse)httpWebRequest.GetResponse();

            string content = string.Empty;

            using (var stream = response.GetResponseStream()) {
                 using (var sr = new StreamReader(stream)) {
                    content = sr.ReadToEnd();
                }
            }
            return Content(HttpStatusCode.OK, content);
        }

    }

 

    [XmlRoot("LogonUserResponse")]
    public class LogonUserResponse
    {
        [XmlAttribute]
        public string xmlns { get; set; }
        [XmlElement("LogonUserResult")]
        public LogonUserResult logonUserResult { get; set; }
    }
    [XmlRoot("LogonUserResult")]
    public class LogonUserResult
    {
        [XmlElement("NewToken")]
        public String newToken { get; set; }
        [XmlElement("ResponseType")]
        public String responseType { get; set; }
    }

}
