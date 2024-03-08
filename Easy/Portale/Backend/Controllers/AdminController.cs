
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
using System.Web.UI.WebControls;
using metadatalibrary;
using Backend.Data;
using Token = Backend.Security.Token;
using MailKit.Security;
using MimeKit;
using SmtpClient = MailKit.Net.Smtp.SmtpClient;
using Castle.Core.Internal;
using funzioni_configurazione;

namespace Backend.Controllers
{

    /// <summary>
    /// Controller contenente le primitive necessarie per la gestione delle funzioni di admin
    /// </summary>
    /// <remarks>
    /// Il percorso (URL) per accedere ai metodi contenuti in questo controller devono avere il prefisso "/admin".
    /// </remarks>
    [RoutePrefix("admin"), Authorize, EnableCors("*", "*", "*")]
    public class AdminController : ApiController
    {

        private const int RegistryClassCompany = 21;
        private const int RegistryClassPrivate = 22;

        [HttpPost, Route("adminregisteruser")]
        public IHttpActionResult adminregister([FromBody] AdminRegistrationFormData data)
        {
            if (data == null)
            {
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

            if (userkind == "3" && String.IsNullOrEmpty(passwordweb))
            {
                var resultErr = new JObject {
                    {"err", 1},
                    {"msg", "Per utenti di tipo 3, bisogna inserire una passwordweb"}
                };
                return Content(HttpStatusCode.OK, resultErr);
            }

            List<string> listCodeflowChart = codesflowchart.Split(';').ToList();
            int error = 0;
            List<string> messages = new List<string>();
            foreach (String codeflowchart in listCodeflowChart)
            {
                AdminRegistrationFormData dataSingleFlowChart = data;
                dataSingleFlowChart.codeflowchart = codeflowchart;
                JObject message = adminregisterSingleCodeflowchart(dataSingleFlowChart);

                if (message["err"]?.ToObject<int>() == 1)
                {
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

        private JObject adminregisterSingleCodeflowchart(AdminRegistrationFormData data)
        {

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
            if (password != null)
            {
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
            if (!String.IsNullOrEmpty(lastError))
            {
                return new JObject {
                    {"err", 1},
                    {"msg", "c# exception: " + lastError}
                };
            }
            else
            {

                // check su registry e registryReference
                string query = "select r.idreg from registry r, registryreference rr where r.cf = '" + cf +
                               "' and rr.idreg = r.idreg";
                DataTable dtReg = dispatcher.conn.SQLRunner(query);

                if (dtReg == null)
                {
                    return new JObject {
                        {"err", 1},
                        {"msg", "c'è stato un problema nella registrazione"}
                    };
                }

                if (dtReg.Rows.Count == 0)
                {
                    return new JObject {
                        {"err", 1},
                        {"msg", "c'è stato un problema nella registrazione"}
                    };
                }

                if (idregistrationuser != null)
                {
                    // update dello stato
                    String[] columns = { "idregistrationuserstatus" };
                    String[] values = { "2" };
                    dispatcher.conn.DO_UPDATE("registrationuser", "idregistrationuser=" + idregistrationuser, columns,
                        values, 1);
                }

                if (DSout == null)
                {
                    return new JObject {
                        {"err", 1},
                        {"msg", "procedure returned empty result"}
                    };
                }
                else
                {

                    string error = "";
                    ((Easy_DataAccess)dispatcher.conn).linkUserToDepartment(login, out error);

                    if (!String.IsNullOrEmpty(error))
                    {
                        return new JObject {
                            {"err", 1},
                            {"msg", "error in linkUserToDepartment: " + error}
                        };
                    }


                    // recupero stringa di messaggio calcolata dalla SP.
                    DataTable dt = DSout.Tables[0];
                    string msg = "";
                    if (dt != null && dt.Rows.Count > 0)
                    {
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
        public IHttpActionResult clearCache()
        {
            CacheMDLW.clearCache();
            return Content(HttpStatusCode.OK, "success");
        }

        /// <summary>
        /// Svuota la cache.
        /// </summary>
        /// <remarks>       
        /// </remarks>         
        [HttpGet, Route("clearSessions")]
        public IHttpActionResult clearSessions()
        {
            SessionMDLW.clearSessions();
            return Content(HttpStatusCode.OK, "success");
        }


        public class generaPasswordPrm
        {
            [Required]
            public string password { get; set; }
        }

        /// <summary>
        /// Svuota la cache.
        /// </summary>
        /// <remarks>       
        /// </remarks>         
        [HttpPost, Route("cryptSystemConfig")]
        public IHttpActionResult generatePassword([FromBody] generaPasswordPrm prms)
        {
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
        public IHttpActionResult getCaricoDidattico([FromBody] CaricodidatticoPrm prms)
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

            HttpWebRequest req = getSoapRequest("LogonUser");

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
                              <AnnoAccademico/>" + prms.aa + @"<AnnoAccademico/>
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

        public class InserisciTimbraturePrm
        {
            [Required]
            public string dateFrom { get; set; }
            [Required]
            public string dateTo { get; set; }
            [Required]
            public string matricola { get; set; }
        }


        private class Lavoratore
        {
            public int matricola { get; set; }
            public int idreg { get; set; }
            public DateTime giorno { get; set; }
            public int minuti { get; set; }
            public string convalida { get; set; }
        }

        /// <summary>
        /// Web services per reperire le timbrature per UNISALENTO
        /// </summary>
        /// <param name="prms"></param>
        /// <returns></returns>
        [HttpPost, Route("getTimbrature")]
        public string getTimbrature([FromBody] InserisciTimbraturePrm prms)
        {
            // Tls12 è necessario per il WebService chiamato
            // Se si omette questa chiamata ritorna non riesce a fare l'hand-shake
            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            // Usr, Pwd, Company e Url da Settings
            string usernameWs = WebConfigurationManager.AppSettings["uniSalentoWS_username"];
            string passwordWs = WebConfigurationManager.AppSettings["uniSalentoWS_password"];
            string compagniaWs = WebConfigurationManager.AppSettings["uniSalentoWS_compagnia"];
            string url = WebConfigurationManager.AppSettings["uniSalentoWS_urlTimbratura"];

            // XML Raw per richiesta in POST
            string body = $@"<?xml version=""1.0"" encoding=""utf-8""?>  
            <soapenv:Envelope xmlns:soapenv=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:ren=""http://rendprofinale.ws.localhost/"">
                <soapenv:Body>
                    <ren:rendprofinale_Query>
                    <ren:m_UserName>{usernameWs}</ren:m_UserName>
                    <ren:m_Password>{passwordWs}</ren:m_Password>
                    <ren:m_Company>{compagniaWs}</ren:m_Company>
                    <ren:pMATRICOLA>{prms.matricola}</ren:pMATRICOLA>
                    <ren:pDTFROM>{prms.dateFrom}</ren:pDTFROM>
                    <ren:pDTTO>{prms.dateTo}</ren:pDTTO>
                    </ren:rendprofinale_Query>
                </soapenv:Body>
            </soapenv:Envelope>";

            // Envelop
            XmlDocument soapEnvelopeXml = new XmlDocument();
            soapEnvelopeXml.LoadXml(body);

            // Request
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(url);
            webRequest.ContentType = "text/xml;charset=\"utf-8\"";
            webRequest.Accept = "text/xml";
            webRequest.Method = "POST";

            // Get Request
            using (Stream stream = webRequest.GetRequestStream())
            {
                soapEnvelopeXml.Save(stream);
            }

            try
            {
                // Get Response
                using (WebResponse webResponse = webRequest.GetResponse())
                {
                    // Get Stream
                    using (StreamReader rd = new StreamReader(webResponse.GetResponseStream()))
                    {
                        // Get Result
                        string soapResult = rd.ReadToEnd();

                        // Prendo Xml dei dati dalla result
                        XmlDocument doc = new XmlDocument();
                        doc.LoadXml(soapResult);
                        doc.LoadXml(doc.ChildNodes[0].ChildNodes[0].ChildNodes[0].InnerXml);
                        doc.LoadXml(doc.ChildNodes[0].InnerText);
                        XmlNodeList nodeList = doc.ChildNodes[1].ChildNodes[2].ChildNodes;

                        // List dei dati
                        List<Lavoratore> lavoratori = new List<Lavoratore>();

                        foreach (XmlNode node in nodeList)
                        {
                            string data = node.InnerText;
                            string[] info = data.Split('#');
                            lavoratori.Add(
                                new Lavoratore()
                                {
                                    matricola = int.Parse(info[0]),
                                    giorno = DateTime.Parse(info[1]),
                                    minuti = int.Parse(info[2]),
                                    convalida = info[3] == "1" ? "S" : "N"
                                }
                            );
                        }

                        // Connection
                        Dispatcher dispatcher = new Dispatcher();
                        dispatcher.createDbConnection();
                        //QueryHelper QH = dispatcher.QueryHelper;
                        var ds = new dsmeta_registry_anagrafica();
                        var getData = new GetData();
                        getData.InitClass(ds, dispatcher.Connection, "registry");

                        // Filtro
                        string filter = String.Join(" or ", lavoratori.Select(s => "extmatricula='" + s.matricola + "'").Distinct().ToList());
                        getData.GET_PRIMARY_TABLE(filter);
                        var registryRow = ds.registry.ToList();

                        // Check timbratura per data e matricola già presente

                        // ================================================================================
                        // Elenco matricole non presenti in anagrafica
                        // ================================================================================

                        List<int> matricoleNonInAnagrafica = new List<int>();

                        // Cerca matricole non presenti in anagrafica
                        foreach (Lavoratore lav in lavoratori)
                        {
                            if (!registryRow.Any(w => w["extmatricula"].ToString() == lav.matricola.ToString()))
                            {
                                matricoleNonInAnagrafica.Add(lav.matricola);
                            }
                        }

                        string mailBody = "";

                        // Invio Email Log lavoratori non presenti in anagrafica
                        if (matricoleNonInAnagrafica.Count() > 0)
                            mailBody = $"Le matricole {String.Join(", ", matricoleNonInAnagrafica.Distinct())} non corrispondono a nessuna anagrafica";

                        // Rimuovo i lavoratori non presenti in anagrafica
                        foreach (int mat in matricoleNonInAnagrafica)
                        {
                            Lavoratore lav = lavoratori.FirstOrDefault(w => w.matricola == mat);
                            if (lav != null)
                                lavoratori.Remove(lav);
                        }

                        // Collego matricola e idreg
                        foreach (Lavoratore lav in lavoratori)
                            lav.idreg = int.Parse(registryRow.FirstOrDefault(w => w["extmatricula"].ToString() == lav.matricola.ToString())["idreg"].ToString());

                        // Prendo le timbrature con idreg e data
                        string filterGiaTimbrato = String.Join(" or ", lavoratori.Select(s => "idreg=" + s.idreg + $" and data='{s.giorno.Year}-{s.giorno.Month}-{s.giorno.Day}'").Distinct().ToList());
                        string filterMatricolaGiaTimbrato = filterGiaTimbrato + "<br />";

                        var giaTimbrati = ds.timbratura.getFromDb(dispatcher.conn, filterGiaTimbrato).ToList();
                        List<int> matricoleGiaTimbrate = new List<int>();

                        // Cerca timbrature già presenti (data - idreg) ed invia eventualmente e-mail
                        foreach (var tim in giaTimbrati)
                        {
                            int idreg = int.Parse(tim["idreg"].ToString());
                            int mat = lavoratori.FirstOrDefault(w => w.idreg == idreg).matricola;
                            matricoleGiaTimbrate.Add(mat);

                            filterMatricolaGiaTimbrato = filterMatricolaGiaTimbrato
                                .Replace($"idreg={idreg} and data='", $"<br />{mat} - ")
                                .Replace("' or ", "");

                            Lavoratore lav = lavoratori.FirstOrDefault(w => w.matricola == mat);
                            if (lav != null)
                                lavoratori.Remove(lav);
                        }
                        filterMatricolaGiaTimbrato = filterMatricolaGiaTimbrato.Replace("'", "");

                        // Invio Email Log lavoratori già timbrati
                        if (matricoleGiaTimbrate.Count() > 0)
                            mailBody += (mailBody == "" ? "" : "<br /><br />") + $"Le timbrature (matricola in data) {filterMatricolaGiaTimbrato} sono già state effettuate";

                        // Mail eventuali errori
                        if (!string.IsNullOrEmpty(mailBody))
                            sendLogEmail("Timbratura Matricole", mailBody);

                        // Inserisco le ore lavorate
                        foreach (Lavoratore lavoratore in lavoratori)
                        {
                            var metaTimbratura = dispatcher.GetMeta("timbratura");
                            metaTimbratura.SetDefaults(ds.timbratura);

                            var timbraturaRow = ds.timbratura.First();
                            RowChange.MarkAsAutoincrement(ds.timbratura.Columns["idtimbratura"], null, null, 0);
                            timbraturaRow = metaTimbratura.Get_New_Row(null, ds.timbratura) as MetaRow;
                            timbraturaRow["idreg"] = lavoratore.idreg;
                            timbraturaRow["data"] = lavoratore.giorno;
                            timbraturaRow["minuti"] = lavoratore.minuti;
                            timbraturaRow["convalida"] = lavoratore.convalida;
                        }

                        // Commit
                        var postData = new Easy_PostData();
                        postData.initClass(ds, dispatcher.Connection);
                        var pmc = postData.DO_POST_SERVICE();
                        if (pmc.Count > 0)
                            return "Errore del server dati.";
                    }
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return "OK";
        }


        
        public class InserisciCostoOrarioPrm
        {
            [Required]
            public string dataElab { get; set; }
            public string dataStop { get; set; }
            [Required]
            public string matricola { get; set; } 
        }

        private class LavoratoreCostoOrario
        {
            public int matricola { get; set; }
            public int idreg { get; set; }
            public DateTime giornoValidita { get; set; }
            public DateTime? giornoStop { get; set; }
            public decimal? costoOrario { get; set; }
            public decimal? oneri { get; set; }
            public decimal? irap { get; set; }
            public decimal? costoOrarioTotale { get; set; }
        }

        private class resultCostoOrario
        {
            public List<LavoratoreCostoOrario> lavoratori { get; set; }
            public string mailBody { get; set; }
            public string newDataElab {get; set;} = "";
            public string newMatricola {get; set;} = "";
            public string esitoMsg {get; set;}
        }

        /// <summary>
        /// Web services per reperire il costo orario per UNISALENTO
        /// </summary>
        /// <param name="prms"></param>
        /// <returns></returns>
        [HttpPost, Route("getCostoOrario")]
        public string getCostoOrario([FromBody] InserisciCostoOrarioPrm prms)
        {
            // List dei dati da inserire alla fine su tabella
            List<LavoratoreCostoOrario> lavoratori = new List<LavoratoreCostoOrario>();
            string mailBody = "";

            resultCostoOrario result = new resultCostoOrario();
            DateTime dataStart = DateTime.Parse(prms.dataElab);
            DateTime dataRicCorrente  = (prms.dataStop != null && prms.dataStop != "") ? DateTime.Parse(prms.dataStop) : dataStart; // Se non passata data fine utilizza quella inizio per la ricerca

            bool isConsecutiveCall = false;
            prms.dataElab = dataRicCorrente.Day + "/" + dataRicCorrente.Month + "/" + dataRicCorrente.Year; //Parto dalla data di fine del periodo

            while (prms.matricola.Length > 0 && dataRicCorrente >= dataStart) { // Cerco finché ho delle matricole in anagrafica && la data di ricerca è >= di quella di inizio
                result = this._getCostoOrario(prms, isConsecutiveCall);

                mailBody += (mailBody == "" ? "" : "<br /><br />") + result.mailBody;

                if (result.lavoratori != null && result.lavoratori.Count() > 0) //Se torna delle righe da inserire su db
                    lavoratori.AddRange(result.lavoratori); // Appendo il risultato

                prms.matricola = result.newMatricola; // Stringa di matricole per prossima richiesta
                prms.dataElab = result.newDataElab; //Ritorna il giorno prima alla data di inizio del periodo appena estratto dal ws
                if (prms.dataElab != null && prms.dataElab.Length > 0)
                    dataRicCorrente = DateTime.Parse(prms.dataElab);

                isConsecutiveCall = true;
            }
            
            // Mail eventuali errori
            if (!string.IsNullOrEmpty(mailBody))
                sendLogEmail("Costo orario Matricole", mailBody);

            if (lavoratori.Count() > 0 && result.esitoMsg == "OK") {
                // Connection
                Dispatcher dispatcher = new Dispatcher();
                dispatcher.createDbConnection();
                dsmeta_registry_anagrafica ds = new dsmeta_registry_anagrafica();

                // Inserisco le ore lavorate
                foreach (LavoratoreCostoOrario lavoratore in lavoratori)
                {
                    var metaCostoOrario = dispatcher.GetMeta("costoorario");
                    metaCostoOrario.SetDefaults(ds.costoorario);

                    var costoOrarioRow = ds.costoorario.First();
                    RowChange.MarkAsAutoincrement(ds.costoorario.Columns["idcostoorario"], null, null, 0);
                    costoOrarioRow = metaCostoOrario.Get_New_Row(null, ds.costoorario) as MetaRow;

                    costoOrarioRow["idreg"] = lavoratore.idreg;
                    costoOrarioRow["start"] = lavoratore.giornoValidita;
                    if (lavoratore.giornoStop == null)
                        costoOrarioRow["stop"] = DBNull.Value;
                    else
                        costoOrarioRow["stop"] = lavoratore.giornoStop;

                    costoOrarioRow["netto"] = lavoratore.costoOrario;
                    costoOrarioRow["oneri"] = lavoratore.oneri;
                    costoOrarioRow["irap"] = lavoratore.irap;
                    costoOrarioRow["totale"] = lavoratore.costoOrarioTotale;
                }

                // Commit
                var postData = new Easy_PostData();
                postData.initClass(ds, dispatcher.Connection);
                var pmc = postData.DO_POST_SERVICE();
                if (pmc.Count > 0)
                    result.esitoMsg = "Errore: server dati, errore nella scrittura del commit.";

                // Query per sistemazione righe con data stop = NULL, imposta la data stop se presente una riga successiva
                string qryUpdateStop = @"
                    UPDATE a
                    SET stop = DATEADD(day,-1,(SELECT TOP(1) start FROM costoorario WHERE idreg = a.idreg AND start > DATEADD(day,1,a.start) ORDER BY start ASC))
                    FROM costoorario a
                    WHERE
                    	stop IS NULL
                    AND start < (SELECT MAX(start) FROM costoorario WHERE idreg = a.idreg);
                ";
                
                dispatcher.Connection.SQLRunner(qryUpdateStop);
            }

            return result.esitoMsg;
        }

        // isConsecutiveCall: indica che è una chiamata successiva al ws per estrarre l'intero periodo (start-stop) richiesto
        private resultCostoOrario _getCostoOrario(InserisciCostoOrarioPrm prms, bool isConsecutiveCall)
        {
            resultCostoOrario result = new resultCostoOrario();
            result.esitoMsg = "OK";

            string baseUrl = WebConfigurationManager.AppSettings["uniSalentoWS_urlCostoOrario"];
            //I parametri sono aggiunti direttamente sulla querystring della URL
            string url = baseUrl + $@"?elenco_matricole={prms.matricola}&data={prms.dataElab}";
            string responseBody = string.Empty;

            // Request
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(url);
            webRequest.ContentType = "text/xml;charset=\"utf-8\"";
            webRequest.Method = "GET";

            using (HttpWebResponse response = (HttpWebResponse)webRequest.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                responseBody = reader.ReadToEnd();
            }

            // List dei dati
            List<LavoratoreCostoOrario> lavoratori = new List<LavoratoreCostoOrario>();
            string[] righe = responseBody.Split('\n'); // Separo le righe restituite (una per ogni matricola)
            if (righe.Length > 0)
            {
                foreach (string riga in righe)
                {
                    if (string.IsNullOrEmpty(riga)) continue;
                    string[] campi = riga.Split(','); //Separo le celle
                    if (campi.Length == 6) //Se la riga è malformattata (o vuota) viene ignorata
                    {
                        int _matricola = 0;
                        int.TryParse(campi[0], out _matricola);
                        if (_matricola > 0)
                        {
                            decimal? _costoOrario = null;
                            if (!string.IsNullOrEmpty(campi[2]))
                                _costoOrario = decimal.Parse(campi[2].Replace(".", ","));

                            decimal? _oneri = null;
                            if (!string.IsNullOrEmpty(campi[3]))
                                _oneri = decimal.Parse(campi[3].Replace(".", ","));

                            decimal? _irap = null;
                            if (!string.IsNullOrEmpty(campi[4]))
                                _irap = decimal.Parse(campi[4].Replace(".", ","));

                            decimal? _costoOrarioTotale = null;
                            if (!string.IsNullOrEmpty(campi[5]))
                                _costoOrarioTotale = decimal.Parse(campi[5].Replace(".", ","));

                            lavoratori.Add(
                                new LavoratoreCostoOrario()
                                {
                                    matricola = _matricola,
                                    giornoStop = null,
                                    giornoValidita = DateTime.Parse(campi[1]),
                                    costoOrario = _costoOrario,
                                    oneri = _oneri,
                                    irap = _irap,
                                    costoOrarioTotale = _costoOrarioTotale
                                }
                            );
                        }
                    }
                }

                if (lavoratori.Count > 0)
                {
                    // Imposto subito la prossima data da controllare (precedente)
                    DateTime dateBefore = lavoratori[0].giornoValidita.AddDays(-1);
                    result.newDataElab = dateBefore.Day + "/" + dateBefore.Month + "/" + dateBefore.Year;

                    // Connection
                    Dispatcher dispatcher = new Dispatcher();
                    dispatcher.createDbConnection();
                    //QueryHelper QH = dispatcher.QueryHelper;
                    var ds = new dsmeta_registry_anagrafica();
                    var getData = new GetData();
                    getData.InitClass(ds, dispatcher.Connection, "registry");

                    // Filtro
                    string filter = String.Join(" or ", lavoratori.Select(s => "extmatricula='" + s.matricola + "'").Distinct().ToList());
                    getData.GET_PRIMARY_TABLE(filter);
                    var registryRow = ds.registry.ToList();

                    // Check timbratura per data e matricola già presente

                    // ================================================================================
                    // Elenco matricole non presenti in anagrafica
                    // ================================================================================
                    result.mailBody = "";
                    if(!isConsecutiveCall){ // Non controllo se le matricole esistono se è il secondo giro, ho già controllato e preparato e-mail da inviare
                        List<int> matricoleNonInAnagrafica = new List<int>();

                        // Cerca matricole non presenti in anagrafica
                        foreach (LavoratoreCostoOrario lav in lavoratori)
                        {
                            if (!registryRow.Any(w => w["extmatricula"].ToString() == lav.matricola.ToString()))
                            {
                                matricoleNonInAnagrafica.Add(lav.matricola);
                            }
                        }

                        // Invio Email Log lavoratori non presenti in anagrafica
                        if (matricoleNonInAnagrafica.Count() > 0)
                            result.mailBody += $"Le matricole {String.Join(", ", matricoleNonInAnagrafica.Distinct())} non corrispondono a nessuna anagrafica";

                        // Rimuovo i lavoratori non presenti in anagrafica
                        foreach (int mat in matricoleNonInAnagrafica)
                        {
                            LavoratoreCostoOrario lav = lavoratori.FirstOrDefault(w => w.matricola == mat);
                            if (lav != null)
                                lavoratori.Remove(lav);
                        }
                    }
                    
                    if (lavoratori.Count > 0) {
                        List<string> matricoleLista = new List<string>();

                        // Collego matricola e idreg
                        foreach (LavoratoreCostoOrario lav in lavoratori) {
                            lav.idreg = int.Parse(registryRow.FirstOrDefault(w => w["extmatricula"].ToString() == lav.matricola.ToString())["idreg"].ToString());

                            matricoleLista.Add(lav.matricola.ToString());
                        }
                        result.newMatricola = String.Join(",", matricoleLista);


                        // Prendo i costi orari con idreg e dataStart
                        string filterGiaInserito = String.Join(" or ", lavoratori.Select(s => "idreg=" + s.idreg + $" and start='{s.giornoValidita.Year}-{s.giornoValidita.Month}-{s.giornoValidita.Day}'").Distinct().ToList());
                        string filterGiaInseritoForMail = String.Join(" <br /> ", lavoratori.Select(s => "idreg=" + s.idreg + $" and start='{s.giornoValidita.Day}/{s.giornoValidita.Month}/{s.giornoValidita.Year}").Distinct().ToList()) + "<br />";
                        string filterMatricolaGiaInserito = filterGiaInserito + "<br />";
                        string filterMatricolaGiaInseritoForMail = filterGiaInseritoForMail + "<br />";

                        var giaInseriti = ds.costoorario.getFromDb(dispatcher.conn, filterGiaInserito).ToList();
                        List<int> matricoleGiaInserite = new List<int>();

                        // Cerca costi orari già inseriti
                        foreach (var tim in giaInseriti)
                        {
                            int idreg = int.Parse(tim["idreg"].ToString());
                            int mat = lavoratori.FirstOrDefault(w => w.idreg == idreg).matricola;
                            matricoleGiaInserite.Add(mat);

                            filterMatricolaGiaInseritoForMail = filterMatricolaGiaInseritoForMail
                                .Replace($"idreg={idreg} and start='", $"{mat} - ");

                            filterMatricolaGiaInserito = filterMatricolaGiaInserito
                                .Replace($"idreg={idreg} and start='", $"<br />{mat} - ")
                                .Replace("' or ", "");

                            LavoratoreCostoOrario lav = lavoratori.FirstOrDefault(w => w.matricola == mat);
                            if (lav != null)
                                lavoratori.Remove(lav);
                        }
                        filterMatricolaGiaInserito = filterMatricolaGiaInserito.Replace("'", "");

                        // Inserisco messaggio su Email Log per costi orari già inseriti
                        if (matricoleGiaInserite.Count() > 0)
                            result.mailBody += (result.mailBody == "" ? "" : "<br /><br />") + $"I costi orari per (matricola in data) <br />{filterMatricolaGiaInseritoForMail} sono già stati inseriti.<br />";

                        ds.costoorario.Clear(); // Pulisco il dataset perché non accetta duplicati

                        if (lavoratori.Count() > 0)
                        {
                            foreach (LavoratoreCostoOrario lav in lavoratori)
                            {
                                string filterDaStoppare = $"idreg= {lav.idreg} and start > '{lav.giornoValidita.Year}-{lav.giornoValidita.Month}-{lav.giornoValidita.Day}'";
                                var daStoppare = ds.costoorario.getFromDb(dispatcher.conn, filterDaStoppare).ToList().OrderBy(o => o["start"]).FirstOrDefault();
                                if (daStoppare != null) //Prima determino data stop per le righe correnti
                                {
                                    if (DateTime.Parse(daStoppare["start"].ToString()) > lav.giornoValidita)
                                    {
                                        lav.giornoStop = DateTime.Parse(daStoppare["start"].ToString()).AddDays(-1);
                                    }
                                }

                                filterDaStoppare = $"idreg= {lav.idreg} and start < '{lav.giornoValidita.Year}-{lav.giornoValidita.Month}-{lav.giornoValidita.Day}'";
                                daStoppare = ds.costoorario.getFromDb(dispatcher.conn, filterDaStoppare).ToList().OrderByDescending(o => o["start"]).FirstOrDefault();
                                if (daStoppare != null)
                                {
                                    daStoppare["stop"] = lav.giornoValidita.AddDays(-1);
                                }
                            }
                            result.lavoratori = lavoratori;
                        }
                    } else
                    {
                        result.esitoMsg = "Nessuna delle matricoli richieste è presente nell'anagrafica (vedere e-mail di avviso).";
                    }
                }
                else
                {
                    result.esitoMsg = "Nessuna riga VALIDA restituita dal webservice (verificare se la matricola esiste).";
                }
            }
            else
            {
                result.esitoMsg = "Nessuna riga restituita dal webservice.";
            }

            return result;
        }

        private static void sendLogEmail(string subject, string body)
        {
            string smtpserver = WebConfigurationManager.AppSettings["smtpserver"];
            int smtpport = Convert.ToInt32(WebConfigurationManager.AppSettings["smtpport"]);
            string smtpuser = WebConfigurationManager.AppSettings["smtpuser"];
            string smtppwd = WebConfigurationManager.AppSettings["smtppwd"];
            string smtpTo = WebConfigurationManager.AppSettings["smtpTo"];
            SystemConfig systemConfig = Security.Token.decodeSystemConfig(smtppwd);
            smtppwd = systemConfig.password;

            BodyBuilder builder = new BodyBuilder();
            builder.HtmlBody = body;

            MimeMessage mail = new MimeMessage();
            mail.From.Add(new MailboxAddress("", smtpuser));
            mail.To.Add(new MailboxAddress("", smtpTo));
            mail.Subject = subject;
            mail.Body = builder.ToMessageBody();

            using (var client = new SmtpClient())
            {
                SecureSocketOptions useSsl = SecureSocketOptions.Auto;
                if (smtpport == 25)
                {
                    useSsl = SecureSocketOptions.None;
                }
                client.Connect(smtpserver, smtpport, useSsl);
                client.AuthenticationMechanisms.Remove("XOAUTH2");
                client.Authenticate(smtpuser, smtppwd);
                client.Send(mail);
                client.Disconnect(true);
            }
        }


        private string getPrmdocenteCaricodidattico(CaricodidatticoPrm prms)
        {
            string res = "";
            if (prms.docenteCF != null)
            {
                res += "<DocenteCF>" + prms.docenteCF + @"</DocenteCF>";
            }
            if (prms.docenteCognome != null)
            {
                res += "<DocenteCognome>" + prms.docenteCognome + @"</DocenteCognome>";
            }

            return res;
        }

        public class AllocationPrm
        {

            public string docenteNome { get; set; }


            public string docenteCognome { get; set; }

            [Required]
            public string dataInizio { get; set; }

            [Required]
            public string dataFine { get; set; }
        }

        [HttpPost, Route("getAllocations")]
        public IHttpActionResult getAllocations([FromBody] AllocationPrm prms)
        {

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
            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                streamWriter.Write(myJsonString);
            }

            var response = (HttpWebResponse)httpWebRequest.GetResponse();

            string content = string.Empty;

            using (var stream = response.GetResponseStream())
            {
                using (var sr = new StreamReader(stream))
                {
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
