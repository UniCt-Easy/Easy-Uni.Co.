
/*
Easy
Copyright (C) 2022 Universit� degli Studi di Catania (www.unict.it)
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
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using System.Text;
using Newtonsoft.Json.Linq;
using System.Xml;
using System.IO;
using XmlFormatter;
using System.Threading.Tasks;
using genericSerializer;
using funzioni_configurazione;
using metadatalibrary;

namespace pagoPaService {

	class MyWebClient : WebClient {
		public static void SetCertificatePolicy() {
			ServicePointManager.ServerCertificateValidationCallback += ValidateRemoteCertificate;
		}

		internal MyWebClient(PagoPaService.OpiSiopeplusConfig cfg) {
			if (!string.IsNullOrEmpty(cfg.cert_filename) && !string.IsNullOrEmpty(cfg.cert_thumbprint)) {
				cert = PagoPaService.checkPfxByThumbPrint(StoreName.My, StoreLocation.CurrentUser, cfg.cert_filename,
					cfg.cert_thumbprint, cfg.cert_pwd);

			}

			System.Net.ServicePointManager.ServerCertificateValidationCallback = delegate(Object obj,
				X509Certificate X509certificate, X509Chain chain, System.Net.Security.SslPolicyErrors errors) {
				QueryCreator.MarkEvent("ServerCertificateValidationCallback called");
				return true;
			};
		}

		/// <summary>
		/// Certificate validation callback 
		/// </summary>
		public static bool ValidateRemoteCertificate(object sender, X509Certificate cert, X509Chain chain,
			SslPolicyErrors error) {
			QueryCreator.MarkEvent("ValidateRemoteCertificate called");
			return true;
		}



		private X509Certificate2 cert;



		protected override WebRequest GetWebRequest(Uri address) {
			HttpWebRequest request = (HttpWebRequest) base.GetWebRequest(address);
			if (cert != null) {
				QueryCreator.MarkEvent("Accettato richiesta utilizzando il certificato " + cert.SubjectName.Name);
				request.ClientCertificates.Add(cert);
			}
			else {
				QueryCreator.MarkEvent("Accettato richiesta senza certificato");
			}

			return request;
		}
	}


	public class UnicreditREST {
		private string endPoint { get; }

		private string user { get; }

		private string password { get; }

		//Default Constructor
		public UnicreditREST(string urlRest, string user = null, string password = null) {

			endPoint = urlRest; // https://tst.pasemplice.eu/connettorenodo/services          
			this.user = user;
			this.password = password;
		}



		//	Per ottenere un token di sicurezza per l�accesso ai servizi, � necessario possedere le seguenti informazioni:
		//�	Utenza tecnica
		//�	Password tecnica
		//�	Codice ABI col quale � stato convenzionato il fruitore del servizio
		//�	Codice ente interno alla procedura EasyPA
		//�	Identificativo univoco dell�ente (chiave univoca calcolata dalla procedura EasyPA)
		//�	Dominio dell�ente (codifica AgID)

		//Tutte le informazioni sopra elencate dovranno essere richieste a UniCredit S.p.A.

		//�	Richiesta del token per la gestione della sicurezza
		//URL da invocare: https://tst.pasemplice.eu/connettorenodo/services/oauth/token
		//Http-Method: POST
		//Request Content-Type: application/x-www-form-urlencoded
		//Response Content-Type: application/json


		// parametri INPUT TUTTI OBBLIGATORI
		//grant_type	    Alfanumerico(8)	 Tipologia di autenticazione (valorizzare fisso a password)
		//codiceIstituto	Alfanumerico(5)	 Codice ABI col quale � stato convenzionato il fruitore del servizio
		//codiceEnte	    Alfanumerico(7)	 Codice ente interno alla procedura EasyPA. Deve essere sempre preceduto da zeri fino a raggiungere i 7 bytes.
		//idEnte	        Alfanumerico(35) Identificativo interno generato da UniCredit Services S.C.p.A. ed assegnato all�ente per la gestione della sicurezza
		//idDominio	        Alfanumerico(35) Dominio dell�ente (codifica AgID)


		//OUTPUT
		//Response JSON
		//Payload:
		//{"access_token":"ed778aeda2903046aeaa372cbd318fa3",
		// "token_type":"bearer",
		// "expires_in":3600  Il parametro di output expires_in indica la validit� temporale del token espressa in secondi.
		//}

		/// <summary>
		/// Certificate validation callback.
		/// </summary>
		private static bool ValidateRemoteCertificate(object sender, X509Certificate cert, X509Chain chain, SslPolicyErrors error)
		{
			// If the certificate is a valid, signed certificate, return true.
			if (error == System.Net.Security.SslPolicyErrors.None)
			{
				return true;
			}

			Console.WriteLine("X509Certificate [{0}] Policy Error: '{1}'",
				cert.Subject,
				error.ToString());

			return false;
		}

		public string GetToken(string grant_type, string codiceIstituto,
			string codiceEnte, string idEnte, string idDominio, out string error, out string esito) {
			error = null;
			var wc = new WebClient();
			ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
			ServicePointManager.ServerCertificateValidationCallback += ValidateRemoteCertificate;
			wc.Headers.Add(HttpRequestHeader.Authorization,
				"Basic " + Convert.ToBase64String(Encoding.ASCII.GetBytes(user + ":" + password)));
			wc.Headers["Content-Type"] = "application/x-www-form-urlencoded";
			wc.Headers.Add("Accept", " application/json");
			string addr = endPoint + "/oauth/token?grant_type=" + grant_type + "&codiceIstituto=" + codiceIstituto +
			              "&codiceEnte=" + codiceEnte + "&idEnte=" + idEnte + "&idDominio=" + idDominio;

			try {
				//var response = wc.UploadFile(addr, "POST", file);
				var responseData = wc.DownloadData(addr);

				string textResponse = System.Text.Encoding.UTF8.GetString(responseData);

				var access_token = "";
				var errore = "";

				var objMessage = JObject.Parse(textResponse);
				access_token = ((JValue) objMessage["access_token"]).Value.ToString();

				errore = ((JValue) objMessage["error"]).Value.ToString();
				esito = access_token != "" ? "OK" : "KO";
				return access_token != "" ? access_token : null;
			}

			catch (Exception e) {
				esito = "KO";
				error = e.ToString();
				return null;
			}

		}

		public string GetTokenNew(string codiceIstituto, string codiceEnte, string idEnte, string idDominio, out string error, out string esito)
		{
			var wc = new WebClient();
			ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
			ServicePointManager.ServerCertificateValidationCallback += ValidateRemoteCertificate;
			wc.Headers.Add(HttpRequestHeader.Authorization, "Basic " + Convert.ToBase64String(Encoding.ASCII.GetBytes(user + ":" + password)));
			wc.Headers["Content-Type"] = "application/x-www-form-urlencoded";
			wc.Headers.Add("Accept", " application/json");

			try
			{
				var input = "grant_type=password" +
							"&codiceIstituto=" + Uri.EscapeDataString(codiceIstituto) +
							"&codiceEnte=" + Uri.EscapeDataString(codiceEnte) +
							"&idEnte=" + Uri.EscapeDataString(idEnte) +
							"&idDominio=" + Uri.EscapeDataString(idDominio);
				var data = Encoding.ASCII.GetBytes(input);

				var responseData = wc.UploadData(endPoint, "POST", data);

				string textResponse = Encoding.UTF8.GetString(responseData);

				var objMessage = JObject.Parse(textResponse);
				string access_token = ((JValue)objMessage["access_token"]).Value.ToString();
				if (access_token != "")
				{
					esito = "OK";
					error = null;
					return access_token;
				}
				else
				{
					esito = "KO";
					error = "Void Access Token";
					return null;
				}
			}
			catch (Exception e)
			{
				esito = "KO";
				error = e.ToString();
				return null;
			}
		}

		/*
		 * �	Elenco RPT associate all�ente creditore
		  URL da invocare: 
		  https://tst.pasemplice.eu/connettorenodo/services/rest/rpt/lista/
		  Http-Method: POST
		  Request Content-Type: application/x-www-form-urlencoded; charset=UTF-8
		  Response Content-Type: application/json
  
		  HEADER
		  Parametri di input	Descrizione
		  Authorization	Impostare il parametro Authorization come segue: 
		  Bearer 645272c974a86081352a3a5ce9ad70ff
  
		  Bearer = valore costante
		  645272c974a86081352a3a5ce9ad70ff = token di sicurezza generato dal servizio descritto nel paragrafo 3.1
  
  
		  INPUT
		  Parametri	Formato	Obbligatorio	Descrizione
		  pageNumber	Numerico	NO	Numero di pagina desiderata
		  rowForPage	Numerico	NO	Numero di righe per pagina
		  orderCriteria	Alfanumerico	NO	Nome della colonna sulla quale si desidera effettuare l�ordinamento
		  orderDirection	Alfanumerico(4)	NO	Di default � impostato ad �asc� altrimenti impostare �desc�
		  identificativoUnivocoVersamento	Alfanumerico(35)	NO	IUV
		  stato	Alfanumerico(45)	NO	Stato dell�RPT. Pu� valere: RPT_ACCETTATA, RPT_RIFIUTATA, RPT_DA_VERIFICARE, RPT_DA_INVIARE, RT_ACCETTATA_PA
		  dataCreazioneDa	Data(dd/MM/yyyy)	NO	Data creazione dell�RPT
		  dataCreazioneA	Data(dd/MM/yyyy)	NO	Data creazione dell�RPT
  
		  OUTPUT
		  Response JSON
		  Payload: 
		  {"resultList":
			  [
				  {"id":9,
				   "dataCreazione":"09/10/2015 12:01:59.579",
				   "xmlRpt":null,
				   "dataUltimoAggiornamento":null,
				   "stato":"RPT_DA_INVIARE",
				   "versione":null,
				   "identificativoMessaggio":null,
				   "identificativoDominio":null,
				   "identificativoStazioneRichiedente":null,
				   "codiceContestoPagamento":"n/a",
				   "identificativoUnivocoVersamento":"000111106651216"
		               }
			  ],
			  "rowFind":1,
			  "rowForPage":20,
			  "pageResponse":1,
			  "pageFind":1
		  }
  
		  ERRORI
		  Status code	Code	Message 	Descrizione
		  401	NA	NA	Token non valido o scaduto
		  500	VALIDATION_ERROR	Errore nella validazione dei campi di ricerca	Parametri di input non corretti (formato errato etc.)
		  500	PAGE_NOT_FOUND	Pagina non trovata	Nessun elemento trovato
		  500	GENERIC_ERROR	Errore Generico	Parametri di input non corretti (formato errato etc.) o errore interno
  
  
		 * */

		public string GetElencoRPT(string accessToken, int pageNumber, int rowForPage,
			string orderCriteria, string orderDirection, string identificativoUnivocoVersamento,
			string stato, DateTime dataCreazioneDa, DateTime dataCreazioneA,
			out string error, out string esito) {
			error = null;
			var wc = new WebClient();
			//string accessToken = "645272c974a86081352a3a5ce9ad70ff";


			wc.Headers["Content-Type"] = "application/x-www-form-urlencoded; charset=UTF-8";
			wc.Headers.Add("Authorization", "Bearer " + accessToken);
			string addr = endPoint + "/rest/rpt/lista?" +
			              "pageNumber" + pageNumber + "&rowForPage" + rowForPage +
			              "&orderCriteria=" + orderCriteria + "&orderDirection=" + orderDirection +
			              "&identificativoUnivocoVersamento" + identificativoUnivocoVersamento + "&stato" + stato +
			              "&dataCreazioneDa" + dataCreazioneDa + "&dataCreazioneA" + dataCreazioneA;
			wc.Headers.Add("Accept", " application/json");
			try {
				//var response = wc.UploadFile(addr, "POST", file);
				var responseData = wc.DownloadData(addr);

				string textResponse = System.Text.Encoding.UTF8.GetString(responseData);
				string elenco = "";
				var access_token = "";
				var errore = "";

				var objMessage = JObject.Parse(textResponse);

				JObject sel = JObject.Parse(textResponse);
				JArray arr = JArray.FromObject(sel["resultList"]);
				// Valutare se restituire l'intero array senza estrapolare i dati, demandando l'elaborazione al chiamante
				foreach (var objSelBuild in arr) {
					var d = objSelBuild["dataCreazione"];
					var c = objSelBuild["stato"];
					var m = objSelBuild["identificativoUnivocoVersamento"];
					elenco = d.ToString() + "-" + c.ToString() + "-" + m.ToString() + "\r\n";
				}

				esito = "OK";
				return elenco;

			}

			catch (Exception e) {
				esito = "KO";
				error = e.ToString();
				return error;
			}

		}

		/*
		 * �	Elenco RT associate all�ente creditore
		    URL da invocare: https://tst.pasemplice.eu/connettorenodo/services/rest/rt/lista/
		    Http-Method: POST
		    Request Content-Type: application/x-www-form-urlencoded; charset=UTF-8
		    Response Content-Type: application/json

		    HEADER
		    Parametri di input	Descrizione
		    Authorization	Impostare il parametro Authorization come segue: 
		    Bearer 645272c974a86081352a3a5ce9ad70ff

		    Bearer = valore costante
		    645272c974a86081352a3a5ce9ad70ff = token di sicurezza generato dal servizio descritto nel paragrafo 3.1

		    INPUT
		    Parametri	Formato	Obbligatorio	Descrizione
		    pageNumber	Numerico	NO	Numero di pagina desiderata (Es. Se impostato a 2 e parametro �rowForPage� = 10 verranno restituiti i records dall�11� al 20�)
		    rowForPage	Numerico	NO	Numero di righe per pagina
		    orderCriteria	Alfanumerico	NO	Nome del campo sul quale si desidera effettuare l�ordinamento (Es. �identificativoUnivocoVersamento�). L�ordinamento pu� essere effettuato su tutti i campi restituiti in output
		    orderDirection	Alfanumerico(4)	NO	Tipo di ordinamento che si intende effettuare sulla colonna indicata nel parametro �orderCriteria�. Pu� valere �asc� oppure �desc�
		    iuv	Alfanumerico(35)	NO	Identificativo univoco del versamento
		    stato	Alfanumerico(45)	NO	Stato dell�RT. Pu� valere: RT_RICEVUTA, RT_REVOCATA, RT_STORNATA
		    dataCreazioneDa	Data(dd/MM/yyyy)	NO	Data creazione, da parte del PSP, dell�XML RT
		    dataCreazioneA	Data(dd/MM/yyyy)	NO	Data creazione, da parte del PSP, dell�XML RT
		    dataInserimentoDa	Data(dd/MM/yyyy HH:mm:ss)	NO	Data inserimento dell�RT su database EasyPA
		    dataInserimentoA	Data(dd/MM/yyyy HH:mm:ss)	NO	Data inserimento dell�RT su database EasyPA
		    codiceEsitoPagamento	Alfanumerico(1)	NO	Codice esito del pagamento. Pu� valere:
		    0 Pagamento eseguito 
		    1 Pagamento non eseguito 
		    2 Pagamento parzialmente eseguito 
		    3 Decorrenza termini 
		    4 Decorrenza termini parziale 


		    OUTPUT
		    Response JSON
		    Payload: 
		    {"resultList":
			    [
				    {"id":2,
				     "idRpt":2,
				     "dataCreazione":"21/01/2015 17:12:34.000",
				     "identificativoMessaggio":"MSGRT20150120161234103",
				     "importoPagato":"60.00",
				     "rtXml":null,
				     "stato":"RT_RICEVUTA",
				     "tipoFirmaXml":"\u0000",
				     "identificativoDominio":"80022230371",
				     "identificativoUnivocoVersamento":"RF57201531700000010000000003",
		                  "codiceEsitoPagamento": "0"
				    }
			    ],
			    "rowFind":1,
			    "rowForPage":20,
			    "pageResponse":1,
			    "pageFind":1
		    }

		    ERRORI
		    Status code	Code	Message 	Descrizione
		    401	NA	NA	Token non valido o scaduto
		    500	VALIDATION_ERROR	Errore nella validazione dei campi di ricerca	Parametri di input non corretti (formato errato etc.)
		    500	PAGE_NOT_FOUND	Pagina non trovata	Nessun elemento trovato
		    500	GENERIC_ERROR	Errore Generico	Parametri di input non corretti (formato errato etc.) o errore interno

		 * */


		public string GetElencoRT(string accessToken, int pageNumber, int rowForPage,
			string orderCriteria, string orderDirection, string iuv,
			string stato, DateTime dataCreazioneDa, DateTime dataCreazioneA,
			DateTime dataInserimentoDa, DateTime dataInserimentoA,
			string codiceEsitoPagamento /*  
                                    0 Pagamento eseguito 
                                    1 Pagamento non eseguito 
                                    2 Pagamento parzialmente eseguito 
                                    3 Decorrenza termini 
                                    4 Decorrenza termini parziale */, out string error, out string esito) {
			error = null;
			var wc = new WebClient();
			//string accessToken = "645272c974a86081352a3a5ce9ad70ff";


			wc.Headers["Content-Type"] = "application/x-www-form-urlencoded; charset=UTF-8";
			wc.Headers.Add("Authorization", "Bearer " + accessToken);
			string addr = endPoint + "/rest/rt/lista?" +
			              "pageNumber" + pageNumber + "&rowForPage" + rowForPage +
			              "&orderCriteria=" + orderCriteria + "&&orderDirection=" + orderDirection +
			              "&iuv" + iuv + "&stato" + stato +
			              "&dataCreazioneDa" + dataCreazioneDa + "&dataCreazioneA" + dataCreazioneA +
			              "&dataInserimentoDa" + dataInserimentoDa + "&dataInserimentoA" + dataInserimentoA +
			              "&codiceEsitoPagamento" + codiceEsitoPagamento
				;
			wc.Headers.Add("Accept", " application/json");
			try {
				//var response = wc.UploadFile(addr, "POST", file);
				var responseData = wc.DownloadData(addr);

				string textResponse = System.Text.Encoding.UTF8.GetString(responseData);
				string elenco = "";


				var objMessage = JObject.Parse(textResponse);

				JObject sel = JObject.Parse(textResponse);
				JArray arr = JArray.FromObject(sel["resultList"]);
				// Valutare se restituire l'intero array senza estrapolare i dati, demandando l'elaborazione al chiamante

				foreach (var objSelBuild in arr) {
					var r1 = objSelBuild["identificativoMessaggio"];
					var r2 = objSelBuild["importoPagato"];
					var r3 = objSelBuild["rtXml"];
					var r4 = objSelBuild["codiceEsitoPagamento"];
					var r5 = objSelBuild["stato"];
					var r6 = objSelBuild["identificativoUnivocoVersamento"];
					var r7 = objSelBuild["idRpt"];
					elenco = r1.ToString() + "-" + r2.ToString() + "-" + r3.ToString() +
					         r4.ToString() + "-" + r5.ToString() + "-" + r6.ToString() +
					         r7.ToString() + "\r\n";
				}

				esito = "OK";
				return elenco;

			}

			catch (Exception e) {
				esito = "KO";
				error = e.ToString();
				return error;
			}

		}

		/*
		 * �	Download RT per IUV
		        URL da invocare: 
		        https://tst.pasemplice.eu/connettorenodo/services/rest/rt/iuv/download
		        Http-Method: POST
		        Request Content-Type: application/x-www-form-urlencoded
		        Response Content-Type: application/xml
		        Content-Disposition=[attachment; filename=Rt_dominioIuv.xml]

		        N.B. Il servizio �Download RT per IUV� restituisce l�unica RT di eseguito. Per ottenere tutte le RT � necessario invocare i servizi �Elenco RT associate all�ente creditore� e �Download RT per id�.

		        HEADER
		        Parametri di input	Descrizione
		        Authorization	Impostare il parametro Authorization come segue: 
		        Bearer 645272c974a86081352a3a5ce9ad70ff

		        Bearer = valore costante
		        645272c974a86081352a3a5ce9ad70ff = token di sicurezza generato dal servizio descritto nel paragrafo 3.1

		        INPUT
		        Parametri	Formato	Obbligatorio	Descrizione
		        iuv	Alfanumerico(35)	SI	Identificativo Univoco Versamento
		        filename	Alfanumerico(50)	NO	Tramite questo parametro � possibile indicare il nome file da assegnare all�XML da scaricare. Se non specificato il servizio assegner� un nome di default
		        OUTPUT
		        Response XML
		        --- Binary Content ---

		        ERRORI
		        Status code	Code	Message 	Descrizione
		        401	NA	NA	Token non valido o scaduto
		        500	RT_NOT_FOUND	Nessuna RT trovata	RT non trovata. Verificare la presenza/correttezza del parametro di input iuv
		        500	GENERIC_ERROR	Errore Generico	Errore interno. Contattare il supporto tecnico
		 * */

		public FileStream GetRTByIUV(string accessToken, string IUV, string filename, out string error,
			out string esito) {
			error = null;
			var wc = new WebClient();
			//string accessToken = "645272c974a86081352a3a5ce9ad70ff";


			wc.Headers["Content-Type"] = "application/x-www-form-urlencoded";
			wc.Headers.Add("Authorization", "Bearer " + accessToken);
			string addr = endPoint + "/rest/rt/iuv/download?" +
			              "iuv" + IUV + "&filename" + filename;
			wc.Headers.Add("Accept", " application/xml");
			try {

				var response =
					wc.DownloadData(new Uri(addr));
				var memStream = new MemoryStream(response);
				// Il metodo potrebbe restituire o un file XML oppure una stringa di errore


				FileStream file = new FileStream(filename, FileMode.Create, FileAccess.Write);
				memStream.WriteTo(file);
				file.Close();
				memStream.Close();

				esito = "OK";
				return file;

			}

			catch (Exception e) {
				esito = "KO";
				FileStream fileError = new FileStream(filename, FileMode.Create, FileAccess.Write);

				error = e.ToString();

				Byte[] info =
					new UTF8Encoding(true).GetBytes(error);

				// Add some information to the file.
				fileError.Write(info, 0, info.Length);

				return fileError;
			}

		}

		public byte[] GetRTByIUVNew(string urlRest, string accessToken, string IUV, out string error, out string esito)
		{
			esito = "KO";
			error = null;

			WebClient wc = new WebClient();
			wc.Headers["Content-Type"] = "application/x-www-form-urlencoded";
			wc.Headers.Add("Authorization", "Bearer " + accessToken);
			wc.Headers.Add("Accept", "application/xml");

			try
			{
				var input = "iuv=" + IUV;
				var data = Encoding.ASCII.GetBytes(input);

				byte[] responseData = wc.UploadData(urlRest, "POST", data);

				esito = "OK";
				return responseData;
			}
			catch (Exception Ex)
			{
				esito = "KO";
				error = Ex.Message;
				return null;
			}
		}

		public byte[] GetRTLista(string urlRest, string accessToken, int? pageNumber, int? rowForPage, string orderCriteria, string orderDirection, string iuv, string stato,
			string dataCreazioneDa, string dataCreazioneA, string dataInserimentoDa, string dataInserimentoA, int? codiceEsitoPagamento,
			out string error, out string esito)
		{
			error = null;

			WebClient wc = new WebClient();
			wc.Headers["Content-Type"] = "application/x-www-form-urlencoded";
			wc.Headers.Add("Authorization", "Bearer " + accessToken);
			wc.Headers.Add("Accept", "application/json");

			try
			{
				var input = ""; // "iuv=" + IUV;
				var data = Encoding.ASCII.GetBytes(input);

				byte[] responseData = wc.UploadData(urlRest, "POST", data);

				esito = "OK";
				return responseData;
			}
			catch (Exception Ex)
			{
				esito = "KO";
				error = Ex.Message;
				return null;
			}
		}

		private string RT_RICEVUTA = "RT_RICEVUTA";
		private string RT_REVOCATA = "RT_REVOCATA";
		private string RT_STORNATA = "RT_STORNATA";

		private enum codiceEsitoPagamentoUnicredit
		{
			PAGAMENTO_ESEGUITO,
			PAGAMENTO_NON_ESEGUITO,
			PAGAMENTO_PARZIALMENTE_ESEGUITO,
			DECORRENZA_TERMINI,
			DECORRENZA_TERMINI_PARZIALE
		}
	}
}

