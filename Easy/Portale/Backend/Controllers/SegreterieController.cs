/*
Easy
Copyright (C) 2026 Università degli Studi di Catania (www.unict.it)
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

using Backend.CommonBackend;
using Backend.Components;
using Backend.Data;
using Backend.Extensions;
using Backend.Extra;
using metadatalibrary;
using metaeasylibrary;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using pagoPaService;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Configuration;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Windows.Forms.VisualStyles;
using static Backend.CommonBackend.DBLogger;
using q = metadatalibrary.MetaExpression;

namespace Backend.Controllers
{
    public class InformazioniEnteGenerico {
        public byte[] Logo;
        public string Denominazione;
        public string CodiceFiscale;
        public string Indirizzo1;
        public string Indirizzo2;
        public string CAP;
        public string Località;
        public string Provincia;
    }

    /// <summary>
    /// Controller contenente le primitive necessarie per la manipolazione dei dati con MetaDataLibrary.
    /// </summary>
    /// <remarks>
    /// Il percorso (URL) per accedere ai metodi contenuti in questo controller devono avere il prefisso "/meta".
    /// I metodi contenuti in questo controller sono accessibili solo se viene specificato un token di autenticazione valido.
    /// I metodi contenuti in questo controller sono accessibili da qualsiasi client (CORS attivati per ogni richiesta).
    /// </remarks>
    [RoutePrefix("segreterie"), Authorize, EnableCors("*", "*", "*")]
    public class SegreterieController : ApiController
    {

        #region Debiti e Pagamenti

        /// <summary>
        /// Called by Client, get a new IUV from IUV service
        /// </summary>
        /// <returns></returns>
        [HttpPost, Route("getiuv")]
        public IHttpActionResult getiuv(){
            var dispatcher = HttpContext.Current.getDataDispatcher();
            try
            {
                // Definizione del Codice Fiscale dell'Ente Creditore (11 cifre fisse)
                // Sostituire con il codice reale, se necessario.
                var conn = dispatcher.conn;
                string query = "select cf from license";
                DataTable dtPaged = conn.SQLRunner(query);
                DataRow dtrow = dtPaged.Rows[0];
                string codiceFiscaleEnte = dtrow[0] == DBNull.Value ? "" : (string)dtrow["cf"];


                // Generazione di un identificativo interno casuale (ad esempio, 10 cifre)
                // In un sistema reale, questo sarebbe un ID progressivo/univoco persistente.
                Random random = new Random();
                long identificativoInterno = (long)(random.NextDouble() * 9000000000L) + 1000000000L; // Numero tra 1.000.000.000 e 9.999.999.999

                // Calcolo della cifra di controllo (CdC) per lo IUV
                // Questo è un placeholder per la logica di calcolo del CdC,
                // che è complessa e si basa sull'algoritmo Modulo 33 per garantire l'integrità.
                // Per questo esempio *fake*, useremo una cifra fissa.
                // In una implementazione reale, qui andrebbe la funzione di calcolo Modulo 33.
                string cifraDiControllo = "33"; // Cifra fissa fittizia per il Modulo 33 

                // Composizione dello IUV nel formato standard: [Codice Fiscale Ente] + [Identificativo] + [CdC]
                // Formato standard pagoPA: 11 (CF Ente) + 10 (ID Versamento) + 2 (CdC) = 23 cifre
                // Attenzione: lo IUV può avere diverse lunghezze, qui usiamo una lunghezza comune di 23 cifre.
                var iuvCompleto = codiceFiscaleEnte + identificativoInterno.ToString() + cifraDiControllo;

                //invio risposta al client
                var iuv = iuvCompleto;

                LogOperationAndData(null, dispatcher.conn, iuv, "getiuv", "Web service: getiuv;");

                return Content(HttpStatusCode.OK, iuv);
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.InternalServerError, GetAndLogErrorMessage(null, dispatcher.conn, ex.Message, "getiuv", "Web service: getiuv;"));
            }
        }
        [HttpPost, Route("scaricaAvvisoPagamento")]
        public IHttpActionResult scaricaAvvisoPagamento([FromBody] InfoAvviso prms) {
            //Arriva il dsmeta_debito_stu
            var x = 1;
            // Inizializzo GetData
            Dispatcher dispatcher = HttpContext.Current.getDataDispatcher();
            var iddebito = prms.iddebito;
            //DataSet ds = prms.ds;
            var primaryTableName = prms.primaryTableName;
            //var filter = //prms.filter;
            var conn = dispatcher.conn;

            var QHS = conn.GetQueryHelper();
            var QHC = new CQueryHelper();
            try {
                //myds = DataSetSerializer.deserialize(ds, true, dispatcher); //JObject.Parse(ds)
                var getData = new GetData();
                //getData.InitClass(ds, conn, primaryTableName);

                // trasformo il json dataquery in metaExpression 
                string filterdb_debito = QHS.AppAnd(QHC.CmpEq("iddebito", iddebito));
                //MetaExpression metaExprDeserialized = DataUtils.getMetaExpressionFromJsonDataQuery(filterdb_debito);

                //MetaTable dt = (MetaTable)ds.Tables[primaryTableName];
                // recupero la riga tramite la tabella e il filtro su di essa, passato dal client
                //DataRow rdebito = getDataRowFromTableFiltered(dt, metaExprDeserialized);

                
                DataTable tdebitodettaglio = conn.RUN_SELECT("debitodettaglio", " * ", null, filterdb_debito, null, false);

                var listaErrori = new List<string>();
                //Reperimento degli avvisi di pagamento dal partner tecnologico
                var cert = new Dictionary<string, AvvisoPagamento>();
                foreach (DataRow r in tdebitodettaglio.Select()) {
                    if (cert.ContainsKey(r["iuv"].ToString())) continue;
                    string result;
                    cert[r["iuv"].ToString()] =
                        PagoPaService.ottieniAvvisoPagamento((DataAccess)conn, r["iuv"].ToString(), out result);
                    if (result != null) {
                        string err = "(ScaricaPdf .ottieniAvvisoPagamento) " + result;
                        err += "- idflusso=" + r["idflussocrediti"] + " iddetail=" + r["idflussocreditidetail"];
                        err += " - IUV=" + r["iuv"].ToString() + " - ";

                        listaErrori.Add(err);
                    }
                }

                byte[] allegatoPdf = null;
                //Scarica il pdf
                    foreach (var avviso in cert.Keys) {
                        var avvPag = cert[avviso];
                        if (avvPag == null) continue;
                        allegatoPdf = avvPag.pdf;
                        //if (error != null) listaErrori.Add(error);
                    }

                if (listaErrori.Count > 0)
                {
					return Content(HttpStatusCode.BadRequest, listaErrori + "(.scaricaAvvisoPagamento)");
                }

                LogOperationAndData(null, dispatcher.conn, "ok", "scaricaAvvisoPagamento", "Web service: scaricaAvvisoPagamento;");
				
                return Content(HttpStatusCode.OK, allegatoPdf);
			}
            catch (Exception ex) {

				return Content(HttpStatusCode.BadRequest, GetAndLogErrorMessage(null, dispatcher.conn, ex.Message, "scaricaAvvisoPagamento", "Web service: scaricaAvvisoPagamento;"));
            }
        }

        [HttpPost, Route("ProcediPagamento")]
        public IHttpActionResult ProcediPagamento([FromBody] InfoAvviso prms) {
            //Arriva il dsmeta_debito_stu

			// Inizializzo GetData
			Dispatcher dispatcher = HttpContext.Current.getDataDispatcher();
			var iddebito = prms.iddebito;

            var primaryTableName = prms.primaryTableName;
            var conn = dispatcher.conn;
            
            var QHS = conn.GetQueryHelper();
            var QHC = new CQueryHelper();
            try {

                var getData = new GetData();
                string filterdb_debito = QHS.AppAnd(QHC.CmpEq("iddebito", iddebito));
                // trasformo il json dataquery in metaExpression 

                string username = (String)dispatcher.conn.Security.GetUsr("userweb");
                string dip = WebConfigurationManager.AppSettings.Get("DBDipartimento");
                string expiringdate = DateTime.Now.AddMinutes(15).ToString("dd/MM/yyyy HH.mm.ss.ffffff");

                //string currIdwebpayment = rdebito["iddebito"].ToString();
                //"?logParam=username|dipartimento|expiringdate|curr_idwebpayment|";
                var logParam = username + '|' + dip + '|' + expiringdate + '|' + iddebito + '|';
                var b = DataAccess.CryptString(logParam);
                var logparamCript = QueryCreator.ByteArrayToString(b);
                var codicepercontrollo = WebConfigurationManager.AppSettings.Get("codicepercontrollo");
                var codice = PagoPaService.SecurityCode(logparamCript, codicepercontrollo);

                var paramsforcallabck = $"?logParam={logparamCript}|&code={codice}";

                var strPathAndQuery = HttpContext.Current.Request.Url.PathAndQuery;
                var strUrl = HttpContext.Current.Request.Url.AbsoluteUri.Replace(strPathAndQuery, "/");
                //string urlForCallback =
                //    $"{strUrl}LoginServizi.aspx{paramsforcallabck}"; //http://localhost:2826/LoginServizi.aspx?... 52850
                // Logout completato, ritorno alla pagina di default
                var urlForCallback = WebConfigurationManager.AppSettings.Get("frontendSSO");
                //var iddebito = rdebito["iddebito"].ToString();
                urlForCallback = urlForCallback + "?tablename=debito&edittype=stu&id=" + iddebito ;

                var iuv = "";
                DataTable tdebito= conn.RUN_SELECT("debito", "*", null, filterdb_debito, null, false);
                DataTable tdebitodettaglio = conn.RUN_SELECT("debitodettaglio", "*", null, filterdb_debito, null, false);
                DataTable tflussocreditidetail = null;
				foreach (DataRow row in tdebitodettaglio.Rows){
                    int idflussocrediti = Convert.ToInt32(row["idflussocrediti"]);
                    int idflussocreditidetail = Convert.ToInt32(row["idflussocreditidetail"]);

                    // Costruzione filtro DB
                    string filterdb_flussodetail = QHS.AppAnd(
                        QHS.CmpEq("idflusso", idflussocrediti),
                        QHS.CmpEq("iddetail", idflussocreditidetail)
                    );

					// Lettura dal DB e riempimento dataset per flussocreditidetail
					tflussocreditidetail = conn.RUN_SELECT("flussocreditidetail", "*", null, filterdb_flussodetail, null, false);
					

                    // Lettura dal DB e riempimento dataset per flussocrediti
                    //string filterdb_ds = QHS.AppAnd(QHS.CmpEq("idflusso", idflussocrediti));
                    //DataTable tflussocrediti=conn.RUN_SELECT("flussocrediti", "*", null, filterdb_ds, null, false);
				
                }
                if (tflussocreditidetail!=null && tflussocreditidetail.Rows.Count > 0) {
                    DataRow rflussocreditidetail = tflussocreditidetail.First();
                    iuv = rflussocreditidetail["iuv"].ToString();
                }

                string url;
                var errore = PagoPaService.AttivaCredito((DataAccess)conn, iuv, urlForCallback, out url);
                if (url == null) {
                    url = PagoPaService.getUrlSitoIstituzionale((DataAccess)conn);
                }
                //url per il pagamento

                if (errore != null && errore != "") {
                        LogOperationAndData(null, dispatcher.conn, errore, "ProcediPagamento", "Web service: ProcediPagamento; ");
                    return Content(HttpStatusCode.InternalServerError, errore);
                }

                LogOperationAndData(null, dispatcher.conn, "ok", "ProcediPagamento", "Web service: ProcediPagamento;");
                return Content(HttpStatusCode.OK, url);

            }
            catch (Exception ex) {
                var x = ex.Message;
				//return Content(HttpStatusCode.InternalServerError, GetAndLogErrorMessage(null, dispatcher.conn, ex.Message, "ProcediPagamento", "Web service: ProcediPagamento;"));
				return Content(HttpStatusCode.OK, GetAndLogErrorMessage(null, dispatcher.conn, ex.Message, "ProcediPagamento", "Web service: ProcediPagamento;"));
			}
        
        }
        /// <summary>
        /// Returns the first DataRow of the Table dt, filtered on  filter
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="filter"></param>
        /// <returns></returns>
        private DataRow getDataRowFromTableFiltered(MetaTable dt, MetaExpression filter) {
            DataRow dr = null;
            if ((filter != null) && (dt != null)) {
                var rows = dt.Filter(filter);
                if (rows.Length > 0) {
                    dr = rows[0];
                }
            }

            return dr;
        }

        private bool doInviaCrediti(DataAccess conn, string idreg, string idistanza, out string iuv, out string erroreCopiaIuv, out List<string> listaErrori) {
            erroreCopiaIuv = "";
            listaErrori = null;
            iuv = "";
            // Connection
            var getData = new GetData();
            var ds = new dsmeta_flussocrediti();
            getData.InitClass(ds, conn, "flussocrediti");

            Dispatcher dispatcher = new Dispatcher();
            dispatcher.createDbConnection();

            var QHS = conn.GetQueryHelper();
            var QHC = new CQueryHelper();
            try {
                string filterdb_debito = QHS.AppAnd(QHS.CmpEq("idistanza", idistanza), QHS.CmpEq("idreg", idreg));
                conn.RUN_SELECT_INTO_TABLE(ds.debito, null, filterdb_debito, null, false);
                string listadebito = QHC.DistinctVal(ds.debito.Select(), "iddebito");
                string Filterdetaildebito = QHS.AppAnd(QHS.FieldInList("iddebito", listadebito), QHS.IsNull("iuv"));

				conn.RUN_SELECT_INTO_TABLE(ds.debitodettaglio, null, Filterdetaildebito, null, false);

                foreach (DataRow row in ds.debitodettaglio.Rows) {
                    int idflussocrediti = Convert.ToInt32(row["idflussocrediti"]);
                    int idflussocreditidetail = Convert.ToInt32(row["idflussocreditidetail"]);

                    // Costruzione filtro DB
                    string filterdb_flussodetail = QHS.AppAnd(
                        QHS.CmpEq("idflusso", idflussocrediti),
                        QHS.CmpEq("iddetail", idflussocreditidetail),
                        QHS.IsNull("iuv")
                    );

                    // Lettura dal DB e riempimento dataset per flussocreditidetail
                    conn.RUN_SELECT_INTO_TABLE(ds.flussocreditidetail,null, filterdb_flussodetail, null,false);

                    // Lettura dal DB e riempimento dataset per flussocrediti
                    string filterdb_ds = QHC.AppAnd(QHC.CmpEq("idflusso", idflussocrediti), QHC.CmpEq("istransmitted", "N"));
                    if ((ds.flussocrediti!= null) && (ds.flussocrediti.Select(filterdb_ds).Length==0)) {
                        conn.RUN_SELECT_INTO_TABLE(ds.flussocrediti, null, filterdb_ds, null, false);
                    }
                }

				if (ds.flussocrediti.Rows.Count == 0) {
                    listaErrori = new List<string>() { "Nessun credito da inviare" };
                    return false;
                }


                //Dobbiamo passare un ds che abbia le tabelle flussocredito e fluissocreditodetail riempite opportunamente
                listaErrori = PagoPaService.InviaCrediti(conn, ds);
                if (listaErrori != null && listaErrori.Count > 0){
                    return false;
                }


                if (!CopiaIUVinDebito(ds, conn, out iuv, out erroreCopiaIuv)){
                    LogOperationAndData(null, dispatcher.conn, "errore", "AllineaIuvDebito", "Web service: doInviaCrediti; ");
                    return false;
                }
                string filteristanza = QHS.AppAnd(QHS.CmpEq("idistanza", idistanza), QHS.CmpEq("idreg_studenti", idreg));
                conn.RUN_SELECT_INTO_TABLE(ds.istanza, null, filteristanza, null, false);

                if (!PoniIstanzaInviata(ds, conn, out erroreCopiaIuv)){
                    LogOperationAndData(null, dispatcher.conn, "errore", "PoniIstanzaInviata", "Web service: doInviaCrediti; ");
                    return false;
                }
                //LogOperationAndData(null, dispatcher.conn, esito, "inviaCrediti", "Web service: inviaCrediti;");
                //return Content(HttpStatusCode.OK, esito);
                return true;
            }
            catch (Exception ex) {
                //return Content(HttpStatusCode.InternalServerError, GetAndLogErrorMessage(null, dispatcher.conn, ex.Message, "inviaCrediti", "Web service: inviaCrediti;"));
                erroreCopiaIuv = erroreCopiaIuv + "" + ex.Message;
                return false;
            }
        }

        [HttpPost, Route("generaCrediti")]
        public IHttpActionResult generaCrediti([FromBody] InfoCrediti prms) {
            Dispatcher dispatcher = new Dispatcher();
            dispatcher.createDbConnection();
            try {
				//TODO: implementare la generazione dei crediti
				// 1. recupero parametri dalla richiesta 
				string idreg_studenti = prms.idreg_studenti;//verrà passato anche a doInviaCrediti
				string idistanza = prms.idistanza;//verrà passato anche a doInviaCrediti
				string aa = prms.aa;
				string user = prms.user;

                // 2. eseguo la stored procedure e ottengo il DataSet
                object[] list = new object[] {
                idreg_studenti,
                idistanza,
                aa,
                user
                };
                string spName = "sp_settax";
                var esito = "ok";
                string errore = "";
                string iuv = "";

                DataSet DSout = dispatcher.conn.CallSP(spName, list, true, -1);
                if (DSout == null || DSout.Tables.Count == 0 || DSout.Tables[0].Rows.Count == 0) {
                    //return Content(HttpStatusCode.BadRequest, "Nessun dato restituito dalla stored procedure.");
                    //------------------------------------------------------------------------------------------
                    //---------------------------------------- INVIO -------------------------------------------
                    //------------------------------------------------------------------------------------------
                    //Prova a fare direttamente l'invio
                    if (!doInviaCrediti((Easy_DataAccess)dispatcher.conn, idreg_studenti, idistanza, out iuv, out string erroreCopiaIuv, out List<string> listaErrori)) {
                        esito = "ok";
                        if (listaErrori != null && listaErrori.Count > 0) {
                            esito = "ko";
                            var msgBody = "";
                            foreach (var e in listaErrori) {
                                msgBody += e;
                                msgBody += "\r\n";
                            }
                            LogOperationAndData(null, dispatcher.conn, esito + ": " + erroreCopiaIuv + "Lista errori:" + msgBody, "doInviaCrediti", "Web service: doInviaCrediti;");
                            return Content(HttpStatusCode.InternalServerError, erroreCopiaIuv + "lista errori(doInviaCrediti):" + msgBody);
                        }
                    }
                }
                else{
                    DataTable dt = DSout.Tables[0];
                    // 3. Genero flussocrediti e (scrivo in) debiti partendo dal DataTable della SP
                    esito = "ok";
                    errore = "";
                    //---------------------------------------------------------------------------------------------------
                    //---------------------------------------- GENERA CREDITI -------------------------------------------
                    //---------------------------------------------------------------------------------------------------
                    if (!doGeneraCrediti(dt, (Easy_DataAccess)dispatcher.conn, out errore)) {
                        esito = "ko";
                        LogOperationAndData(null, dispatcher.conn, esito + ": " + errore, "doGeneraCrediti", "Web service: doGeneraCrediti;");
                        return Content(HttpStatusCode.InternalServerError, errore);
                    }

                    iuv = "";
                    //------------------------------------------------------------------------------------------
                    //---------------------------------------- INVIO -------------------------------------------
                    //------------------------------------------------------------------------------------------
                    // Esegue l'invio, allo stesso modo scritto sopra
                    if (!doInviaCrediti((Easy_DataAccess)dispatcher.conn, idreg_studenti, idistanza, out iuv, out string erroreCopiaIuv, out List<string> listaErrori)){
                        esito = "ok";
                        if (listaErrori != null && listaErrori.Count > 0){
                            esito = "ko";
							var msgBody = "";
                            foreach (var e in listaErrori){
                                msgBody += e;
                                msgBody += "\r\n";
                            }
                            LogOperationAndData(null, dispatcher.conn, esito + ": " + erroreCopiaIuv + "Lista errori:" + msgBody, "doInviaCrediti", "Web service: doInviaCrediti;");
							return Content(HttpStatusCode.InternalServerError, erroreCopiaIuv + "lista errori(doInviaCrediti):" + msgBody);
						}
                    }

                }
                //Se tutto va ben, restituisce StatusCode = OK
                LogOperationAndData(null, dispatcher.conn, esito, "generaCrediti", "Web service: generaCrediti;");
                return Content(HttpStatusCode.OK, esito);
            }
            catch (Exception ex){
                return Content(HttpStatusCode.InternalServerError, GetAndLogErrorMessage(null, dispatcher.conn, ex.Message, "generaCrediti", "Web service: generaCrediti;"));
            }
        }
        private bool PoniIstanzaInviata(dsmeta_flussocrediti ds, DataAccess conn, out string errore) {
            // 1) Leggo tutti i record di FlussoCreditiDetail
            var listaistanza = ds.istanza.ToList();

            foreach (var c in listaistanza) {
                c.idstatuskind = 2;
            }
            // 3. POST verso database
            MetaData meta = new MetaData();
            var postData = meta.Get_PostData();
            postData.initClass(ds, conn);
            var myMessages = new ProcedureMessageCollection();
            myMessages = postData.DO_POST_SERVICE();
            if (myMessages.Count > 0) {
                ProcedureMessage msg1 = (ProcedureMessage)myMessages[0];
                string err = msg1.LongMess;
                //return Content(HttpStatusCode.OK, "Errore durante il salvataggio dei Crediti " + err);
                errore = "Errore durante il cambio stato dell'Istanza " + err;
                return false;
            }
            errore = null;
            return true;
        }
		private bool CopiaIUVinDebito(dsmeta_flussocrediti ds, DataAccess conn, out string iuv, out string errore){
			// 1) Leggo tutti i record di FlussoCreditiDetail
			var listaCrediti = ds.flussocreditidetail.ToList();
			iuv = "";
			foreach (var credito in listaCrediti)
			{
				// Chiavi della riga corrente
				int idFlusso = credito.idflusso;
				int idDetail = credito.iddetail;

				// 2) Cerco i record corrispondenti in DebitoDettaglio
				var debiti = ds.debitodettaglio
							   .Where(x => x.idflussocrediti == idFlusso
										&& x.idflussocreditidetail == idDetail)
							   .ToList();

				// 3) Copio l’IUV
				foreach (var debito in debiti)
				{
					debito.iuv = credito.iuv;
					iuv = credito.iuv;
				}
			}
			// 3. POST verso database
			MetaData meta = new MetaData();
			var postData = meta.Get_PostData();
			postData.initClass(ds, conn);
			var myMessages = new ProcedureMessageCollection();
			myMessages = postData.DO_POST_SERVICE();
			if (myMessages.Count > 0)
			{
				ProcedureMessage msg1 = (ProcedureMessage)myMessages[0];
				string err = msg1.LongMess;
				//return Content(HttpStatusCode.OK, "Errore durante il salvataggio dei Crediti " + err);
				errore = "Errore durante il salvataggio di CopiaIUVinDebito " + err;
				return false;
			}
			errore = null;
			return true;
		}
		private bool doGeneraCrediti(DataTable dt, DataAccess conn, out string errore) {
            // Connection
            var getData = new GetData();
            var ds = new dsmeta_flussocrediti();
            getData.InitClass(ds, conn, "flussocrediti");

            var QHS = conn.GetQueryHelper();
            var QHC = new CQueryHelper();

            // 1. Creo flusso crediti
            //var dispatcher = HttpContext.Current.getDataDispatcher();
            Dispatcher dispatcher = new Dispatcher();
            dispatcher.createDbConnection();

            var metaFlussoCrediti = dispatcher.GetMeta("flussocrediti");
            metaFlussoCrediti.SetDefaults(ds.flussocrediti);

            var metaFlussoCreditiDetail = dispatcher.GetMeta("flussocreditidetail");
            metaFlussoCreditiDetail.ComputeRowsAs(ds.flussocreditidetail, "easysegr");
            metaFlussoCreditiDetail.SetDefaults(ds.flussocreditidetail);

            var metaDebito = dispatcher.GetMeta("debito");
            metaDebito.SetDefaults(ds.debito);
            
            var metaDebitodettaglio = dispatcher.GetMeta("debitodettaglio");
            metaDebitodettaglio.ComputeRowsAs(ds.debitodettaglio, "easysegr");
            metaDebitodettaglio.SetDefaults(ds.debitodettaglio);


            // 1.Crea un dizionario con i dettagli raggruppati per iddebito
            var dict = dt.AsEnumerable()
                  .GroupBy(r => r.Field<int>("iddebito"))
                  .ToDictionary(
                      g => g.Key,           // iddebito
                      g => g.ToList()       // tutte le n righe del dettaglio
                  );
            // 2.Cicla il dizionario per creare le righe di flussocredito e flussocreditodetail
            foreach (var kvp in dict) {
                int iddebito = kvp.Key;
                List<DataRow> dettagli = kvp.Value;

                // Crea la riga del Flussocredito
                var rFlussoCrediti = metaFlussoCrediti.Get_New_Row(null, ds.flussocrediti);
                rFlussoCrediti["flusso"] = DBNull.Value;
                rFlussoCrediti["istransmitted"] = "N";
                rFlussoCrediti["filename"] = "Segreterie Studenti";
                rFlussoCrediti["docdate"] = DateTime.Now;

				rFlussoCrediti["ct"] = DateTime.Now;
                rFlussoCrediti["cu"] = "apiSegreterieController";
                rFlussoCrediti["lt"] = DateTime.Now;
                rFlussoCrediti["lu"] = "apiSegreterieController";

                // Crea la riga di Debito 
                var rDebito = metaDebito.Get_New_Row(null, ds.debito);
                DataRow firstRow = dettagli.First();

                //rDebito["iddebito"] = iddebito;
                rDebito["idreg"] = firstRow["idreg"];
                rDebito["title"] = firstRow["title"];
                rDebito["scadenza"] = firstRow["scadenza"];
                rDebito["idiscrizione"] = firstRow["idiscrizione"];
                rDebito["idistanza"] = firstRow["idistanza"];
                rDebito["idnullaosta"] = firstRow["idnullaosta"];
                rDebito["idtassaconf"] = DBNull.Value;
                rDebito["idfasciaiseedef"] = firstRow["idfasciaiseedef"];
                rDebito["idratadef"] = firstRow["idratadef"];
                rDebito["idiscrizioneanno"] = DBNull.Value;
                rDebito["ct"] = DateTime.Now;
                rDebito["cu"] = "apiSegreterieController";
                rDebito["lt"] = DateTime.Now;
                rDebito["lu"] = "apiSegreterieController";

                // Dettagli
                foreach (var r in dettagli) {
                    // dettagli flussocrediti
                    var rFlussoCreditidetail = metaFlussoCreditiDetail.Get_New_Row(rFlussoCrediti, ds.flussocreditidetail);
                    rFlussoCreditidetail["idflusso"] = rFlussoCrediti["idflusso"];
                    rFlussoCreditidetail["importoversamento"] = r["importo"];
                    rFlussoCreditidetail["idreg"] = r["idreg"];
                    var cf = conn.readValue("registry", q.eq("idreg", r["idreg"]), "cf");
                    var pIva = conn.readValue("registry", q.eq("idreg", r["idreg"]), "p_iva");
                    rFlussoCreditidetail["cf"] = cf;
                    rFlussoCreditidetail["p_iva"] = pIva;
                    rFlussoCreditidetail["description"] = r["title"];
                    rFlussoCreditidetail["importoversamento"] = Convert.ToDecimal(r["importo"]);

                    //det["competencystart"] = r["competencystart"];
                    //det["competencystop"] = r["competencystop"];
                    //rFlussoCreditidetail["iduniqueformcode"] = $"easysegr_{rFlussoCrediti["idflusso"]}_{rFlussoCreditidetail["iddetail"]}";
                    rFlussoCreditidetail["nform"] = DBNull.Value;
                    rFlussoCreditidetail["idfinmotive"] = r["idfinmotive"];
                    rFlussoCreditidetail["idfinmotive_iva"] = r["idfinmotive_iva"];
                    rFlussoCreditidetail["idaccmotiverevenue"] = r["idaccmotiverevenue"];
                    rFlussoCreditidetail["idaccmotivecredit"] = r["idaccmotivecredit"];
                    rFlussoCreditidetail["idaccmotiveundotax"] = DBNull.Value;
                    rFlussoCreditidetail["idaccmotiveundotaxpost"] = DBNull.Value;
                    rFlussoCreditidetail["stop"] = DBNull.Value;
                    rFlussoCreditidetail["codicetassonomia"] = r["tassonomia_pagopa"];

                    // scadenza
                    if ((r["scadenza"] != DBNull.Value) && (r["scadenza"] != null)) {
                        rFlussoCreditidetail["expirationdate"] =
                            DateTime.Now.AddDays(Convert.ToInt32(r["scadenza"]));
                    }
                    else {
                        DateTime oggi = DateTime.Now;
                        int ngiorni = 30;
                        rFlussoCreditidetail["expirationdate"] = oggi.AddDays(ngiorni);
                    }

                    // idupb
                    rFlussoCreditidetail["idupb"] = r["idupb"];// E' stato letto dal tipo CA
                    rFlussoCrediti["idestimkind"] = r["idestimkind"];
					rFlussoCrediti["docdate"] = DateTime.Now;
					object idestimkind = r["idestimkind"];
                    //Recupera gli attributi:
                    string E1 = "";
					DataRow attrs = null;
					if (idestimkind != null && idestimkind != DBNull.Value) {
						attrs = getAttributiTipoContrattoAttivo(conn, idestimkind, out E1);
					}
                    if (attrs == null) {
                        errore = $"Attenzione. '{E1}";
                        rFlussoCrediti["idsor01"] = DBNull.Value;
                        rFlussoCrediti["idsor02"] = DBNull.Value;
                        rFlussoCrediti["idsor03"] = DBNull.Value;
                        rFlussoCrediti["idsor04"] = DBNull.Value;
                        rFlussoCrediti["idsor05"] = DBNull.Value;
                    }
                    else {
                        rFlussoCrediti["idsor01"] = attrs["idsor01"];
                        rFlussoCrediti["idsor02"] = attrs["idsor02"];
                        rFlussoCrediti["idsor03"] = attrs["idsor03"];
                        rFlussoCrediti["idsor04"] = attrs["idsor04"];
                        rFlussoCrediti["idsor05"] = attrs["idsor05"];
                    }
                    rFlussoCreditidetail["ct"] = DateTime.Now;
                    rFlussoCreditidetail["cu"] = "apiSegreterieController";
                    rFlussoCreditidetail["lt"] = DateTime.Now;
                    rFlussoCreditidetail["lu"] = "apiSegreterieController";

                    //debitodettaglio 
                    var rDebitodettaglio = metaDebitodettaglio.Get_New_Row(rDebito, ds.debitodettaglio);

                    rDebitodettaglio["idflussocrediti"] = rFlussoCreditidetail["idflusso"]; // -> chiave di flussocreditidetail
                    rDebitodettaglio["idflussocreditidetail"] = rFlussoCreditidetail["iddetail"]; // -> chiave di flussocreditidetail
                    rDebitodettaglio["idcostoscontodefdettaglio"] = r["idcostoscontodefdettaglio"];
                    rDebitodettaglio["idcostoscontodef"] = r["idcostoscontodefdettaglio"];
                    rDebitodettaglio["importo"] = r["importo"];
                    rDebitodettaglio["idreg"] = r["idreg"];
                    //rDebitodettaglio["cf"] = cf;
                    //rDebitodettaglio["p_iva"] = pIva;
                    //rDebitodettaglio["description"] = r["descrizione"];
                    rDebitodettaglio["importo"] = Convert.ToDecimal(r["importo"]);

                    //rDebitodettaglio["iduniqueformcode"] = $"easysegr_{rFlussoCrediti["idflusso"]}_{rFlussoCreditidetail["iddetail"]}";
                    //rDebitodettaglio["nform"] = DBNull.Value;
                    //rDebitodettaglio["stop"] = DBNull.Value;

                    // scadenza
                    //if ((r["scadenza"] != DBNull.Value) && (r["scadenza"] != null)) {
                    //    rDebitodettaglio["expirationdate"] =
                    //        DateTime.Now.AddDays(Convert.ToInt32(r["scadenza"]));
                    //}
                    //else {
                    //    DateTime oggi = DateTime.Now;
                    //    int ngiorni = 30;
                    //    rDebitodettaglio["expirationdate"] = oggi.AddDays(ngiorni);
                    //}

                    rDebitodettaglio["ct"] = DateTime.Now;
                    rDebitodettaglio["cu"] = "apiSegreterieController";
                    rDebitodettaglio["lt"] = DateTime.Now;
                    rDebitodettaglio["lu"] = "apiSegreterieController";
                }
             }

            // 3. POST verso database
            MetaData meta = new MetaData();
            var postData = meta.Get_PostData();
            postData.initClass(ds, dispatcher.Connection);
            var myMessages = new ProcedureMessageCollection();
            myMessages = postData.DO_POST_SERVICE();
            if (myMessages.Count > 0) {
                ProcedureMessage msg1 = (ProcedureMessage)myMessages[0];
                string err = msg1.LongMess;
                //return Content(HttpStatusCode.OK, "Errore durante il salvataggio dei Crediti " + err);
                errore = "Errore durante il salvataggio dei Crediti " + err;
                return false;
            }
            //// Valorizza iduniqueformcode"
            //string erroreIduniqueformcode = "";
            //if(!ValorizzaIduniqueformcode(ds,conn, out erroreIduniqueformcode)) {
            //    errore = "Errore durante il salvataggio dei Crediti " + erroreIduniqueformcode;
            //    return false;
            //}
            errore = null;
            return true;
        }

        //private bool ValorizzaIduniqueformcode(string idistanza, string idreg, DataAccess conn, out string errore) {
        //    // Connection
        //    var getData = new GetData();
        //    var ds = new dsmeta_flussocrediti();
        //    getData.InitClass(ds, conn, "flussocrediti");

        //    var QHS = conn.GetQueryHelper();
        //    var QHC = new CQueryHelper();

        //    Dispatcher dispatcher = new Dispatcher();
        //    dispatcher.createDbConnection();

        //    string filterdb_debito = QHS.AppAnd(QHS.CmpEq("idistanza", idistanza), QHS.CmpEq("idreg", idreg));
        //    conn.RUN_SELECT_INTO_TABLE(ds.debito, null, filterdb_debito, null, false);

        //    conn.RUN_SELECT_INTO_TABLE(ds.debitodettaglio, null, QHS.CmpEq("iddebito", ds.debito.Rows[0]["iddebito"]), null, false);

        //    foreach (DataRow row in ds.debitodettaglio.Rows) {
        //        int idflussocrediti = Convert.ToInt32(row["idflussocrediti"]);
        //        int idflussocreditidetail = Convert.ToInt32(row["idflussocreditidetail"]);

        //        // Costruzione filtro DB
        //        string filterdb_flussodetail = QHS.AppAnd(
        //            QHS.CmpEq("idflussocrediti", idflussocrediti),
        //            QHS.CmpEq("idflussocreditidetail", idflussocreditidetail)
        //        );

        //        // Lettura dal DB e riempimento dataset per flussocreditidetail
        //        conn.RUN_SELECT_INTO_TABLE(ds.flussocreditidetail, null, filterdb_flussodetail, null, false);

        //        // Lettura dal DB e riempimento dataset per flussocrediti
        //        string filterdb_ds = QHC.AppAnd(QHC.CmpEq("idflusso", idflussocrediti));
        //        if ((ds.flussocrediti != null) && (ds.flussocrediti.Select(filterdb_ds).Length == 0)) {
        //            conn.RUN_SELECT_INTO_TABLE(ds.flussocrediti, null, filterdb_ds, null, false);
        //        }
        //    }
        //    ////////////////////

        //    DataTable flussoDetail = ds.Tables["flussocreditidetail"];
        //    DataTable debitoDettaglio = ds.Tables["debitodettaglio"];

        //    foreach (DataRow rFlussoDetail in flussoDetail.Rows) {
        //        var idFlusso = rFlussoDetail["idflusso"];
        //        var idDetail = rFlussoDetail["iddetail"];

        //        string idUniqueFormCode = $"easysegr_{idFlusso}_{idDetail}";

        //        // valorizzo flussocreditidetail
        //        rFlussoDetail["iduniqueformcode"] = idUniqueFormCode;

        //        // seleziono le righe collegate in debitodettaglio
        //        string filter = QHC.AppAnd(QHC.CmpEq("idflussocrediti", idFlusso), QHC.CmpEq("idflussocreditidetail", idDetail));
        //        DataRow[] righeDebito = debitoDettaglio.Select(filter);

        //        foreach (DataRow rDebito in righeDebito) {
        //            rDebito["iduniqueformcode"] = idUniqueFormCode;
        //        }
        //    }

        //    MetaData meta = new MetaData();
        //    var postData = meta.Get_PostData();
        //    postData.initClass(ds, dispatcher.Connection);
        //    var myMessages = new ProcedureMessageCollection();
        //    myMessages = postData.DO_POST_SERVICE();
        //    if (myMessages.Count > 0) {
        //        ProcedureMessage msg1 = (ProcedureMessage)myMessages[0];
        //        string err = msg1.LongMess;
        //        errore = "Errore durante il salvataggio dei Crediti(iduniqueformcode) " + err;
        //        return false;
        //    }
        //    errore = null;
        //    return true;
        //}
            
        private DataRow getAttributiTipoContrattoAttivo(DataAccess Conn, object idestimkind, out string errore) {
            errore = "";
            if (idestimkind == null || idestimkind == DBNull.Value) {
                errore = "Il tipo di contratto attivo dev'essere specificato.";
                return null;
            }

            var QHS = Conn.GetQueryHelper();
            string filter = QHS.CmpEq("idestimkind", idestimkind);

            DataTable dt = Conn.RUN_SELECT("estimatekind", "idsor01, idsor02, idsor03, idsor04, idsor05", null, filter,
                null, false);
            if (dt == null || dt.Rows.Count == 0) {
                errore = $"Il tipo contratto attivo '{idestimkind}' non è stato trovato.";
                return null;
            }

            return dt.Rows[0];
        }
        private DataRow getAttributiTipoFattura(DataAccess Conn, object idinvkind, out string errore) {
            errore = "";
            if (idinvkind == null || idinvkind == DBNull.Value) {
                errore = "Il tipo di fattura dev'essere specificato.";
                return null;
            }

            var QHS = Conn.GetQueryHelper();
            string filter = QHS.CmpEq("idinvkind", idinvkind);

            DataTable dt = Conn.RUN_SELECT("invoicekind", "idsor01, idsor02, idsor03, idsor04, idsor05", null, filter,
                null, false);
            if (dt == null || dt.Rows.Count == 0) {
                errore = $"Il tipo fatturao '{idinvkind}' non è stato trovato.";
                return null;
            }

            return dt.Rows[0];
        }

        #endregion

        #region Protocollo

        /// <summary>
        /// parameters for protocolla method
        /// </summary>
        public class protcollaPrms
        {
            public JToken dsProtocolloSeg { get; set; }
            public string tableName { get; set; }
            public bool sendmail { get; set; }
        }

        public class Destinatari
        {
            public int idreg_dest { get; set; }
            public string destmail { get; set; }

        }

        /// <summary>
        /// Retrieves a list of email addresses based on the specified query string identifier.
        /// </summary>
        /// <remarks>This method executes a database query to retrieve email addresses associated with the
        /// provided query string identifier. If the identifier does not correspond to a valid query, or if an error
        /// occurs during execution, an appropriate error response is returned.</remarks>
        /// <param name="idquerystring">The identifier of the query string used to retrieve the email addresses.</param>
        /// <returns>An <see cref="IHttpActionResult"/> containing a list of email addresses if the operation is successful,  or
        /// an error message with a status code of <see cref="HttpStatusCode.InternalServerError"/> if an exception
        /// occurs.</returns>
        [HttpGet, Route("getMailList")]
        public IHttpActionResult getMailList(int idqueryregistry)
        {
            List<Destinatari> mails = new List<Destinatari> ();

            try
            {
                Dispatcher dispatcher = HttpContext.Current.getDataDispatcher();

                DataRow queryregistry = dispatcher.Connection.RUN_SELECT("queryregistry", "query", null, $"idqueryregistry = {idqueryregistry}", "1", false).First();
                
                // Non esiste ka riga
                if (queryregistry == null)
                    return Content(HttpStatusCode.InternalServerError, $"Nessuna riga con idqueryregistry '{idqueryregistry}' trovata in Queryregistry");

                string qry = queryregistry["query"].ToString();

                if (string.IsNullOrEmpty(qry))
                    return Content(HttpStatusCode.InternalServerError, $"Queryregistry con 'query' vuota per idqueryregistry '{idqueryregistry}'");

                DataTable dt = dispatcher.Connection.SQLRunner(qry);
                if (dt == null)
                    return Content(HttpStatusCode.InternalServerError, $"La query '{qry}' è andata in errore");
                
                if (dt.Columns.Count != 2)
                    return Content(HttpStatusCode.InternalServerError, $"La query deve restituire due colonne: int, string (per idreg, email)");

                foreach (DataRow dr in dt.Rows)
                    mails.Add(new Destinatari()
                    {
                        idreg_dest = (int)dr[0],
                        destmail = dr[1].ToString()
                    }
                );
            }
            catch (Exception e)
            {
                return Content(HttpStatusCode.InternalServerError, e.Message);
            }

            return Content(HttpStatusCode.OK, mails);
        }

        /// <summary>
        /// Called by Client, calls a generic custom method for a specific business logic. Implement the switch case!
        /// </summary>
        /// <param name="prms">customEventQueryParameters</param>
        /// <returns></returns>
        [HttpPost, Route("protocolla")]
        public IHttpActionResult protocolla(protcollaPrms prms)
        {
            Dispatcher dispatcher = HttpContext.Current.getDataDispatcher();

            try
            {
                return doProtocolla(dispatcher, prms, false);
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.InternalServerError, GetAndLogErrorMessage(null, dispatcher.conn, ex.Message, "protocolla", "Web service: protocolla; Parameters: " + JsonConvert.SerializeObject(prms, Formatting.Indented)));
            }

        }

        /// <summary>
        /// Called by Client, calls a generic custom method for a specific business logic. Implement the switch case!
        /// </summary>
        /// <param name="prms">customEventQueryParameters</param>
        /// <returns></returns>
        [HttpPost, Route("aggiornaprotocollo")]
        public IHttpActionResult aggiornaprotocollo(protcollaPrms prms)
        {
            var dispatcher = HttpContext.Current.getDataDispatcher();
            try
            {
                return doProtocolla(dispatcher, prms, true);
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.InternalServerError, GetAndLogErrorMessage(null, dispatcher.conn, ex.Message, "protocolla", "Web service: protocolla; Parameters: " + JsonConvert.SerializeObject(prms, Formatting.Indented)));
            }

        }

        private IHttpActionResult doProtocolla(Dispatcher dispatcher, protcollaPrms prms, bool update)
        {
            string tProtocollo = "protocollo";
            string tProtocollodestinatario = "protocollodestinatario";
            string tProtocollodoc = "protocollodoc";
            string tProtocollodocelement = "protocollodocelement";
            string tProtKind = "protocollokinddefaultview";
            string protnumeroField = "protnumero";
            string protannoField = "protanno";
            string dataannullamentoField = "dataannullamento";
            string testosegnaturaField = "testosegnatura";

            // Table Protocol & DataSet
            var tableName = prms.tableName;
            var ds = prms.dsProtocolloSeg;
            DataSet myds = DataSetSerializer.deserialize(ds, true, dispatcher);

            // Anno & Numero
            int protanno = 0;
            int protnumero = 0;

            if (!update)
            {
                protanno = Protocoller.getProtAnno();
                protnumero = Protocoller.getProtNumber(dispatcher, protanno);

                myds.Tables[tableName].Rows[0][protnumeroField] = protnumero;
                myds.Tables[tableName].Rows[0][protannoField] = protanno;

                var metaP = dispatcher.GetMeta(tProtocollo);
                var postDataP = metaP.Get_PostData();
                postDataP.initClass(myds, dispatcher.Connection);

                //salva i dati ed ottiene un eventuale elenco di messaggi
                postDataP.autoIgnore = true;
                ProcedureMessageCollection myMessagesP = postDataP.DO_POST_SERVICE();
                
                var successP = myMessagesP.Count == 0;

                if (!successP)
                {
                    var canIgnoreP = successP;
                    var dsSerializedP = DataUtils.dataSetToJSon(myds, false);
                    var messagesSerializedP = DataSetSerializer.serializeMessages(myMessagesP);

                    // costruisco risposta da mandare al client con il ds e i messaggi eventuali più altre info utili
                    var resultP = DataUtils.getJsonSaveDataSetAnswer(dsSerializedP, messagesSerializedP, successP, canIgnoreP);

                    // Log
                    LogOperationAndData(null, dispatcher.conn, "OK", "protocolla", "Web service: protocolla; Parameters: " + JsonConvert.SerializeObject(prms, Formatting.Indented));

                    //invio risposta al client
                    return Json(resultP);
                }
            }

            // Table attach
            var tableAttach = myds.Tables["attach"];

            // Table ProtocolloDoc
            var tableProtocollodoc = myds.Tables[tProtocollodoc];

            string stringFilter = null;

            //string[] idattachs = tableProtocollodoc.Rows.Cast<DataRow>().Select(r => r["idattach"].ToString()).ToArray();

            string[] idattachs = tableProtocollodoc?.Rows
                                    .Cast<DataRow>()
                                    .Where(r => r.RowState != DataRowState.Deleted &&
                                                r.RowState != DataRowState.Detached)
                                    .Select(r => r.Field<object>("idattach"))
                                    .Where(v => v != null && v != DBNull.Value)
                                    .Select(v => v.ToString())
                                    .Where(s => !string.IsNullOrWhiteSpace(s))
                                    .ToArray()
                                    ?? new string[0];


            if (idattachs.Length > 0)
            {
                stringFilter = $"idattach IN ({string.Join(", ", idattachs)})";
                dispatcher.Connection.RUN_SELECT_INTO_TABLE(tableAttach, null, stringFilter, null, true);
            }

            int idProtKind = 0;
            int.TryParse(myds.Tables[tProtocollo].Rows[0]["idprotocollokind"].ToString(), out idProtKind);

            if (update)
            {
                int.TryParse(myds.Tables[tProtocollo].Rows[0]["protnumero"].ToString(), out protnumero);
                int.TryParse(myds.Tables[tProtocollo].Rows[0]["protanno"].ToString(), out protanno);
            }

            DateTime dataProtocollo = DateTime.Now;
            DateTime.TryParse(myds.Tables[tProtocollo].Rows[0]["protdata"].ToString(), out dataProtocollo);

            DataRow istituto = dispatcher.Connection.RUN_SELECT("istitutoprinc", "*", null, null, "1", false).First();
            string testo = istituto["acronimo"].ToString();

            string tipoProtocollo = "";
            if (idProtKind != 0)
                tipoProtocollo = myds.Tables[tProtKind].Rows.Cast<DataRow>().FirstOrDefault(w => int.Parse(w["idprotocollokind"].ToString()) == idProtKind)["title"].ToString().Substring(0, 1);

            string fincaturaText = Signature.fincText(protnumero, testo, tipoProtocollo, dataProtocollo);

            string fileNameFincato = "";
            bool firstDoc = true;
            byte[] pdfFincato = null;

            // Valori di default fincatura
            BoxPosition fincaturaPosition = BoxPosition.TopRight;
            float fincaturaMargin = 20f;
            string fincaturaBaseFont = "Helvetica";
            float fincaturaFontSize = 12f;
            int fincaturaPutOnPageNumber = 1;

            string originalFileName = "";
            string fincatoFileName = "";

            // Documenti
            foreach (DataRow row in tableProtocollodoc.Rows.Cast<DataRow>().Where(r => r.RowState != DataRowState.Deleted && r.RowState != DataRowState.Detached))
            {
                // Position
                if (row["idfincaturaposition"] != DBNull.Value)
                    fincaturaPosition = (BoxPosition)(int.Parse(row["idfincaturaposition"].ToString()) - 1);
                else
                    row["idfincaturaposition"] = fincaturaPosition + 1;

                // Margin
                if (row["fincaturamargin"] != DBNull.Value)
                    fincaturaMargin = float.Parse(row["fincaturamargin"].ToString());
                else
                    row["fincaturamargin"] = fincaturaMargin;

                // Id Attach
                int.TryParse(row["idattach"].ToString(), out int docIDattach);

                if (docIDattach > 0)
                {
                    // Row
                    var attachRow = tableAttach.Rows.Cast<DataRow>().Where(r => r.RowState != DataRowState.Deleted && r.RowState != DataRowState.Detached).FirstOrDefault(r => int.Parse(r["idattach"].ToString()) == docIDattach);

                    // Dir
                    var uploadDir = new DirectoryInfo(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, FileController.UploadPath));

                    // CHECK FILE NULL
                    var attachPath = Path.Combine(uploadDir.FullName, attachRow["filename"].ToString().Replace("_fincato", ""));

                    fincatoFileName = Path.Combine(uploadDir.FullName, attachRow["filename"].ToString());
                    originalFileName = attachRow["filename"].ToString().Replace("_fincato", "").Substring(attachRow["filename"].ToString().IndexOf("$__$") + 4);
                    if (row["filename"] == DBNull.Value)
                        row["filename"] = originalFileName;

                    if (File.Exists(attachPath))
                    {
                        string outAttachPath = Path.GetFileNameWithoutExtension(attachPath) + "_fincato" + Path.GetExtension(attachPath);

                        byte[] contents = File.ReadAllBytes(attachPath);

                        string spirePdfLicenseKey = "";
                        DataTable conf_pdf = dispatcher.conn.RUN_SELECT("app_config", "param", null, "code = 'SPIRE_PDF_LICENSE_KEY'", null, false);
                        if (conf_pdf.Rows.Count > 0)
                            spirePdfLicenseKey = conf_pdf.Rows[0]["param"].ToString();

                        string error = "";
                        var newContent = Signature.PdfAggiungiFincatura(out error,
                                                                            spirePdfLicenseKey,
                                                                            contents,
                                                                            fincaturaText,
                                                                            fincaturaPosition,
                                                                            fincaturaMargin,
                                                                            fincaturaBaseFont,
                                                                            fincaturaFontSize,
                                                                            fincaturaPutOnPageNumber);

                        if (!string.IsNullOrWhiteSpace(error))
                        {
                            BackendLoggerService.Logger.Log(error, BackendLogger.LogLevel.Error);
                            continue;
                        }

                        // Scrivo pdf_fincato
                        File.WriteAllBytes(Path.Combine(uploadDir.FullName, outAttachPath), newContent);

                        // Salvo il nome del file fincato in attach
                        attachRow["filename"] = outAttachPath;

                        if (firstDoc == true)
                        {
                            // File Name
                            fileNameFincato = attachRow["filename"].ToString();

                            // Hash 
                            pdfFincato = newContent;

                            firstDoc = false;
                        }
                    }
                }
            }

            if (!update)
            {
                // INSERT
                foreach (DataRow r in myds.Tables[tProtocollo].Rows)
                {
                    if (r.RowState != DataRowState.Deleted && r.RowState != DataRowState.Detached)
                        if (r[dataannullamentoField] == DBNull.Value)
                        {
                            r[protnumeroField] = protnumero;
                            r[protannoField] = protanno;
                        }
                }

                foreach (DataRow r in myds.Tables[tProtocollodestinatario].Rows)
                {
                    if(r.RowState != DataRowState.Deleted && r.RowState != DataRowState.Detached)
                        if ((int)r[protnumeroField] == 99990002)
                        {
                            r[protnumeroField] = protnumero;
                            r[protannoField] = protanno;
                        }
                }

                foreach (DataRow r in myds.Tables[tProtocollodoc].Rows)
                {
                    if (r.RowState != DataRowState.Deleted && r.RowState != DataRowState.Detached)
                        if ((int)r[protnumeroField] == 99990002)
                    {
                        r[protnumeroField] = protnumero;
                        r[protannoField] = protanno;
                    }
                }

                foreach (DataRow r in myds.Tables[tProtocollodocelement].Rows)
                {
                    if (r.RowState != DataRowState.Deleted && r.RowState != DataRowState.Detached)
                        if ((int)r[protnumeroField] == 99990002)
                    {
                        r[protnumeroField] = protnumero;
                        r[protannoField] = protanno;
                    }
                }

                var rT = myds.Tables[tableName].Rows[0];
                if (rT.RowState != DataRowState.Deleted && rT.RowState != DataRowState.Detached)
                {
                    rT[protnumeroField] = protnumero;
                    rT[protannoField] = protanno;
                }
            }

            // ====================================================================================================
            // codiceAmministrazioneIPA
            // ====================================================================================================
            string codiceAmministrazioneIPA =       myds.Tables[tableName].Rows[0]["codiceammipa"].ToString();

            // ====================================================================================================
            // codiceAooIPA
            // ====================================================================================================
            string codiceAooIPA = "";
            try
            {
                if (myds.Tables["aoodefaultview"].Rows.Count > 0)
                    codiceAooIPA = myds.Tables["aoodefaultview"].Rows[0]["aoo_codiceaooipa"].ToString();
            }
            catch { }

            // ====================================================================================================
            // codiceRegistro
            // ====================================================================================================
            string codiceRegistro =                 myds.Tables[tableName].Rows[0]["codiceregistro"].ToString();

            // ====================================================================================================
            // numeroRegistrazione
            // ====================================================================================================
            string numeroRegistrazione =            codiceRegistro;

            // ====================================================================================================
            // Data Registrazione
            // ====================================================================================================
            string dataRegistrazione =              myds.Tables[tableName].Rows[0]["protdata"].ToString();

            // ====================================================================================================
            // Oggetto
            // ====================================================================================================
            string oggetto =                        myds.Tables[tableName].Rows[0]["oggetto"].ToString();

            // ====================================================================================================
            // classificaDenominazione
            // ====================================================================================================
            string classificaDenominazione = "";
            try
            {
                int idclassificazioneprotocollo = 0;
                int.TryParse(myds.Tables[tableName].Rows[0]["idclassificazioneprotocollo"].ToString(), out idclassificazioneprotocollo);
                if (idclassificazioneprotocollo > 0)
                    if (myds.Tables["classificazioneprotocollodefaultview"].Rows.Count > 0)
                        classificaDenominazione = myds.Tables["classificazioneprotocollodefaultview"].Rows.Cast<DataRow>().FirstOrDefault(w => int.Parse(w["idclassificazioneprotocollo"].ToString()) == idclassificazioneprotocollo)["title"].ToString();
            }
            catch { }

            // ====================================================================================================
            // mittDenominazione
            // mittCodiceIpaAmministrazione
            // ====================================================================================================
            string mittDenominazione = "";
            string mittCodiceIpaAmministrazione = "";
            try
            {
                string idreg_origine = myds.Tables[tableName].Rows[0]["idreg_origine"].ToString();
                if (!string.IsNullOrEmpty(idreg_origine))
                {
                    DataTable mitt = dispatcher.Connection.RUN_SELECT("registry", "title, ipa_fe", null, $"idreg = {idreg_origine}", null, false);
                    if (mitt.Rows.Count > 0)
                    {
                        mittDenominazione = mitt.Rows[0]["title"].ToString();
                        mittCodiceIpaAmministrazione = mitt.Rows[0]["ipa_fe"].ToString();
                    }
                }
            }
            catch { }

            // ====================================================================================================
            // destDenominazione
            // destCodiceIpaAmministrazione
            // ====================================================================================================
            string destDenominazione = "";
            string destCodiceIpaAmministrazione = "";
            try
            {
                var dests = myds.Tables["protocollodestinatario"].Rows.Cast<DataRow>().Where(r => r.RowState != DataRowState.Deleted && r.RowState != DataRowState.Detached).ToList();
                if (dests.Count > 0)
                {
                    string idreg_dest = dests[0]["idreg_dest"].ToString();
                    DataTable mitt = dispatcher.Connection.RUN_SELECT("registry", "title, ipa_fe", null, $"idreg = {idreg_dest}", null, false);
                    if (mitt.Rows.Count > 0)
                    {
                        destCodiceIpaAmministrazione = mitt.Rows[0]["ipa_fe"].ToString();
                        destDenominazione = mitt.Rows[0]["title"].ToString();
                    }
                }
            }
            catch { }

            if (File.Exists(fincatoFileName))
            {
                byte[] pdfFincatoForSegnature = File.ReadAllBytes(fincatoFileName);

                // Segnature
                myds.Tables[tableName].Rows[0][testosegnaturaField] = Signature.CreaSegnatura(
                    codiceAmministrazioneIPA,
                    codiceAooIPA,
                    codiceRegistro,
                    numeroRegistrazione,
                    dataRegistrazione,
                    oggetto,
                    classificaDenominazione,
                    mittDenominazione,
                    mittCodiceIpaAmministrazione,
                    destDenominazione,
                    destCodiceIpaAmministrazione,
                    originalFileName,
                    pdfFincatoForSegnature);
            }

            var QHS = dispatcher.conn.GetQueryHelper();

            // notificationqueue
            string idrelated = protanno + "|" + protnumero;
            string filterNotificationQueue = QHS.AppAnd(QHS.CmpEq("sourceTableName", "protocollo"), QHS.AppAnd(QHS.CmpEq("sourceEditType", "seg"), QHS.CmpEq("idrelated", idrelated)));
            stringFilter = $"idattach IN ({string.Join(", ", idattachs)})";
            DataTable notifQueue = dispatcher.Connection.RUN_SELECT("notificationqueue", "*", null, filterNotificationQueue, null, true);

            // Se non c'è inserisci
            if (prms.sendmail && notifQueue.Rows.Count == 0)
            {
                dispatcher.conn.SQLRunner($@"
                    INSERT INTO dbo.notificationqueue
                        (idnotificationqueue,ct,cu,idrelated,lt,lu,senttimestamp,sourceedittype,sourcetablename)
                    VALUES
                        ((select isnull(max(idnotificationqueue), 0) + 1 from notificationqueue), getdate(), 'apiSegreterieController', '{idrelated}', getdate(), 'apiSegreterieController', null, 'seg', 'protocollo')"
                );
            }
            // Se c'è elimina
            else if (!prms.sendmail && notifQueue.Rows.Count > 0)
            {
                dispatcher.conn.SQLRunner($@"
                    DELETE dbo.notificationqueue
                    WHERE sourcetablename = 'protocollo' AND sourceedittype = 'seg' AND idrelated = '{idrelated}' and senttimestamp IS NULL"
                );
            }

            var meta = dispatcher.GetMeta(tProtocollo);
            var postData = meta.Get_PostData();
            postData.initClass(myds, dispatcher.Connection);

            //salva i dati ed ottiene un eventuale elenco di messaggi
            ProcedureMessageCollection myMessages = postData.DO_POST_SERVICE();

            var success = myMessages.Count == 0;

            var canIgnore = success;
            var dsSerialized = DataUtils.dataSetToJSon(myds, false);
            var messagesSerialized = DataSetSerializer.serializeMessages(myMessages);

            // costruisco risposta da mandare al client con il ds e i messaggi eventuali più altre info utili
            var result = DataUtils.getJsonSaveDataSetAnswer(dsSerialized, messagesSerialized, success, canIgnore);

            // Log
            LogOperationAndData(null, dispatcher.conn, "OK", "protocolla", "Web service: protocolla; Parameters: " + JsonConvert.SerializeObject(prms, Formatting.Indented));

            //invio risposta al client
            return Json(result);
        }

        #endregion
    }

    public class InfoAvviso {
        public string iddebito { get; set; }
        //public DataSet ds { get; set; }

        public string primaryTableName { get; set; }
    }

    public class InfoCrediti {
        public string idistanza { get; set; }
        public string idreg_studenti { get; set; }
        public string aa { get; set; }
        public string user { get; set; }
    }

}
