using System;
using System.Data;
using System.Net;
using System.Threading;
using System.Collections.Generic;
using System.Windows.Forms;

using Newtonsoft.Json;
using Polly;

using metadatalibrary;
using ANP2018;
using ADPv2.Translator;
using Translator;

namespace ADPv2 {
	/// <summary>
	/// Wrapper che chiama i metodi di un client autogenerato secondo le specifiche OpenAPI.
	/// Le chiamate ai metodi del wrapper sono sincrone per compatibilità col passato, 
	/// mentre quelle del client sono asincrone. 
	/// https://adp-api-coll.dfp.gov.it/swagger/index.html
	/// https://adp-api.perlapa.gov.it/swagger/index.html
	/// </summary>
	public class Wrapper {

		/// <summary>
		/// Client autogenerato secondo il formato OpenAPI.
		/// </summary>
		private readonly Client apiClient;

		///// <summary>
		///// Client per chiamata all'anagrafe centralizzata
		///// </summary>
		//private readonly HttpClient client = new HttpClient();

		/// <summary>
		/// Parametri per le politiche di retry.
		/// </summary>
		private readonly int baseWait;
		private readonly int baseBackoff;
		private readonly Random jitterer = new Random();
		private TimeSpan jitter { get { return TimeSpan.FromMilliseconds(jitterer.Next(0, 1000)); } }
		private void throttle() { // non ancora utilizzato
			Thread.Sleep(TimeSpan.FromSeconds(baseWait) + jitter);
		}

		/// <summary>
		/// Politica di retry
		/// </summary>
		private Policy WebPolicy {
			get {
				return Policy.Handle<ApiException>().WaitAndRetry(
					5,                                                              // numero di tentativi
					attempt => TimeSpan.FromSeconds(Math.Pow(baseBackoff, attempt)) // back-off
					+ jitter                                                        // jitter
				);
			}
		}

		/// <summary>
		/// Token per l'esecuzione di metodi autenticati sul client.
		/// </summary>
		private string token;

		/// <summary>
		/// Oggetto che traduce i nostri valori nel corrispondente valore richiesto dall'API.
		/// </summary>
		private readonly Translator<FieldName, TRole> translator;

		/// <summary>
		/// Inizializza l'istanza del Wrapper.
		/// </summary>
		/// <param name="apiEndpoint">Indirizzo dell'API</param>
		/// <param name="baseWaitSeconds">Attesa tra le richieste</param>
		/// <param name="baseBackoffSeconds">Attesa minima tra i retry, incrementata esponenzialmente</param>
		/// <param name="conn">Connessione al database</param>
		public Wrapper(Uri apiEndpoint, int baseWaitSeconds, int baseBackoffSeconds, DataAccess conn) {
			ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

			apiClient = new Client(apiEndpoint.ToString(), new System.Net.Http.HttpClient());

			//client.BaseAddress = new Uri("https://ac-api.perlapa.gov.it");
			//client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

			baseWait = (1 < baseWaitSeconds && baseWaitSeconds < 10) ? baseWait : 1;
			baseBackoff = (2 < baseBackoffSeconds && baseBackoffSeconds < 7) ? baseBackoffSeconds : 2;

			var fieldNames = (FieldName[])Enum.GetValues(typeof(FieldName));
			var roles = (TRole[])Enum.GetValues(typeof(TRole));

			translator = new Translator<FieldName, TRole>(fieldNames, roles, conn, (int)conn.GetSys("esercizio"));

			// aggiungiamo le associazioni al traduttore, indicate nel dizionario statico
			foreach (var tableMapping in Mappings.Tables) translator.AddTableAssociation(tableMapping.Key, tableMapping.Value);
			foreach (var columnMapping in Mappings.Columns) translator.AddColumnAssociation(new KeyValuePair<FieldName, TRole>(columnMapping.Key.Key, columnMapping.Key.Value), columnMapping.Value); 

			translator.Refresh();
		}

		/// <summary>
		/// Inizializza il token di autenticazione all'API se non già valorizzato.
		/// </summary>
		/// <param name="appId">Credenziale pubblica per l'accesso all'API</param>
		/// <param name="secret">Credenziale privata per l'accesso all'API</param>
		public void Login(string appId, string secret) {

			if (string.IsNullOrEmpty(token)) {
				// TODO: retry per login e scadenza token
				token = WebPolicy.Execute(
					() => AsyncHelpers.RunSync(
						() => apiClient.LoginAsyncFixed(new CredentialWs { AppId = appId, Secret = secret })
					)
				);
			}
		}

		/// <summary>
		/// Inserisce un incarico consulente chiamando il relativo metodo del client.
		/// </summary>
		/// <param name="data">Oggetto che contiene i dati per la chiamata</param>
		/// <param name="payments">Enumerabile di DataRow che contiene i pagamenti relativi all'incarico</param>
		/// <param name="input">TextBox nel quale sarà serializzato l'oggetto dei dati per la chiamata</param>
		/// <param name="output">TextBox nel quale sarà serializzato l'oggetto tradotto e inviato all'API</param>
		/// <returns>Id dell'incarico inserito sull'API</returns>
		public string InserimentoIncarico_Consulente(inserimento_incarico_consulente data, IEnumerable<DataRow> payments = null, TextBox input = null, TextBox output = null) {
			
			//Dictionary<string, string> anagrafeCentralizzata = ResponseAnagrafeCentralizzata(data.amministrazionedichiarante.codiceFiscalePa);

			var newInc = new NewIncaricoConsulenteWsDto(translator, data, payments);

			if (input != null) input.Text = JsonConvert.SerializeObject(data, Formatting.Indented);
			if (output != null) output.Text = JsonConvert.SerializeObject(newInc.WithoutAttachments(), Formatting.Indented);

			string id = null;
			WebPolicy.Execute(() => {
				try {
					id = AsyncHelpers.RunSync(
						() => apiClient.Consulente2AsyncFixed(token, newInc)
					);
				}
				catch (Exception e) {
					if (e.InnerException != null && e.InnerException is ApiException<ProblemDetails> exception) {
						var message = JsonConvert.SerializeObject(((ApiException<ProblemDetails>)e.InnerException).Result, Formatting.Indented);
						throw new Exception(message);
					}

					throw new WebException();
				}
			});

			return id.Replace("\"", ""); //dobbiamo ripulire la risposta da caratteri spuri rispetto alle specifiche,
										 //lo facciamo nel wrapper invece che sul client autogenerato
		}

		/// <summary>
		/// Inserisce un incarico dipendente chiamando il relativo metodo del client.
		/// </summary>
		/// <param name="data">Oggetto che contiene i dati per la chiamata</param>
		/// <param name="payments">Enumerabile di DataRow che contiene i pagamenti relativi all'incarico</param>
		/// <param name="input">TextBox nel quale sarà serializzato l'oggetto dei dati per la chiamata</param>
		/// <param name="output">TextBox nel quale sarà serializzato l'oggetto tradotto e inviato all'API</param>
		/// <returns>Id dell'incarico inserito sull'API</returns>
		public string InserimentoIncarico_Dipendente(inserimentoincaricodipendente data, IEnumerable<DataRow> payments = null, TextBox input = null, TextBox output = null) {

			//Dictionary<string, string> anagrafeCentralizzata = ResponseAnagrafeCentralizzata(data.amministrazionedichiarante.codiceFiscalePa);

			var newInc = new NewIncaricoDipendenteWsDto(translator, data, payments);

			if (input != null) input.Text = JsonConvert.SerializeObject(data, Formatting.Indented);
			if (output != null) output.Text = JsonConvert.SerializeObject(newInc, Formatting.Indented);

			string id = null;
			WebPolicy.Execute(() => {
				try {
					id = AsyncHelpers.RunSync(
						() => apiClient.Dipendente2AsyncFixed(token, newInc)
					);
				}
				catch (Exception e) {
					if (e.InnerException != null) {
						if (e.InnerException is ApiException<ProblemDetails>) {
							var message = JsonConvert.SerializeObject(((ApiException<ProblemDetails>)e.InnerException).Result, Formatting.Indented);
							throw new Exception(message);
						}

						throw new WebException(e.InnerException.Message);
					}

					throw new WebException();
				}
			});

			return id.Replace("\"", ""); //dobbiamo ripulire la risposta da caratteri spuri rispetto alle specifiche,
										 //lo facciamo nel wrapper invece che sul client autogenerato
		}

		public void CancellazioneIncarico_Consulente(string id) {

			if (!Guid.TryParse(id, out Guid idIncarico))
				idIncarico = GuidFromOldId_Consulente(Convert.ToInt64(id));

			WebPolicy.Execute(() => {
				try {
					AsyncHelpers.RunSync(
						() => apiClient.Consulente4Async(token, idIncarico)
					);
				}
				catch (Exception e) {
					if (e.InnerException != null) {
						if (e.InnerException is ApiException<ProblemDetails>) {
							var message = JsonConvert.SerializeObject(((ApiException<ProblemDetails>)e.InnerException).Result, Formatting.Indented);
							throw new Exception(message);
						}

						throw new WebException(e.InnerException.Message);
					}

					throw new WebException();
				}
			});
		}

		public void CancellazioneIncarico_Dipendente(string id) {
			
			if (!Guid.TryParse(id, out Guid idIncarico))
				idIncarico = GuidFromOldId_Dipendente(Convert.ToInt64(id));

			WebPolicy.Execute(() => {
				try {
					AsyncHelpers.RunSync(
						() => apiClient.Dipendente4Async(token, idIncarico)
					);
				}
				catch (Exception e) {
					if (e.InnerException != null) {
						if (e.InnerException is ApiException<ProblemDetails>) {
							var message = JsonConvert.SerializeObject(((ApiException<ProblemDetails>)e.InnerException).Result, Formatting.Indented);
							throw new Exception(message);
						}

						throw new WebException(e.InnerException.Message);
					}

					throw new WebException();
				}
			});
		}

		public void ModificaIncarico_Dipendente(variazione_incarico_dipendente data, DataRow service, IEnumerable<DataRow> payments = null, TextBox input = null, TextBox output = null) {

			//Dictionary<string, string> anagrafeCentralizzata = ResponseAnagrafeCentralizzata(data.amministrazionedichiarante.codiceFiscalePa);
			
			var updateIncarico = new UpdateIncaricoDipendenteWsDto(translator, data, service, payments);

			if (input != null) input.Text = JsonConvert.SerializeObject(data, Formatting.Indented);
			if (output != null) output.Text = JsonConvert.SerializeObject(updateIncarico, Formatting.Indented);

			if (!Guid.TryParse(service["id_service"].ToString(), out Guid idIncarico))
				idIncarico = GuidFromOldId_Dipendente(Convert.ToInt64(service["id_service"]));

			WebPolicy.Execute(() => {
				try {
					AsyncHelpers.RunSync(
						() => apiClient.Dipendente3Async(token, idIncarico, updateIncarico)
					);
				}
				catch (Exception e) {
					if (e.InnerException != null) {
						if (e.InnerException is ApiException<ProblemDetails>) {
							var message = JsonConvert.SerializeObject(((ApiException<ProblemDetails>)e.InnerException).Result, Formatting.Indented);
							throw new Exception(message);
						}

						throw new WebException(e.InnerException.Message);
					}

					throw new WebException();
				}
			});
		}

		public void ModificaIncarico_Consulente(variazione_incarico_consulente data, DataRow service, string comuneNascita, IEnumerable<DataRow> payments = null, TextBox input = null, TextBox output = null) {

			//Dictionary<string, string> anagrafeCentralizzata = ResponseAnagrafeCentralizzata(data.amministrazionedichiarante.codiceFiscalePa);

			var updateIncarico = new UpdateIncaricoConsulenteWsDto(translator, data, service, comuneNascita, payments);

			if (input != null) input.Text = JsonConvert.SerializeObject(data, Formatting.Indented);
			if (output != null) output.Text = JsonConvert.SerializeObject(updateIncarico, Formatting.Indented);

			if (!Guid.TryParse(service["id_service"].ToString(), out Guid idIncarico))
				idIncarico = GuidFromOldId_Consulente(Convert.ToInt64(service["id_service"]));

			WebPolicy.Execute(() => {
				try {
					AsyncHelpers.RunSync(
						() => apiClient.Consulente3Async(token, idIncarico, updateIncarico)
					);
				}
				catch (Exception e) {
					if (e.InnerException != null) {
						if (e.InnerException is ApiException<ProblemDetails>) {
							var message = JsonConvert.SerializeObject(((ApiException<ProblemDetails>)e.InnerException).Result, Formatting.Indented);
							throw new Exception(message);
						}

						throw new WebException(e.InnerException.Message);
					}

					throw new WebException();
				}
			});
		}

		public Guid GuidFromOldId_Dipendente(long oldId) {

			Guid newId = Guid.Empty;

			WebPolicy.Execute(() => {
				try {
					newId = AsyncHelpers.RunSync(
						() => apiClient.DipendenteAsync(token, oldId)	
					);
				}
				catch (Exception e) {
					if (e.InnerException != null) {
						if (e.InnerException is ApiException<ProblemDetails>) {
							var message = JsonConvert.SerializeObject(((ApiException<ProblemDetails>)e.InnerException).Result, Formatting.Indented);
							throw new Exception(message);
						}

						throw new WebException(e.InnerException.Message);
					}

					throw new WebException();
				}
			});

			return newId;
		}

		public Guid GuidFromOldId_Consulente(long oldId) {

			Guid newId = Guid.Empty;

			WebPolicy.Execute(() => {
				try {
					newId = AsyncHelpers.RunSync(
						() => apiClient.ConsulenteAsync(token, oldId)
					);
				}
				catch (Exception e) {
					if (e.InnerException != null) {
						if (e.InnerException is ApiException<ProblemDetails>) {
							var message = JsonConvert.SerializeObject(((ApiException<ProblemDetails>)e.InnerException).Result, Formatting.Indented);
							throw new Exception(message);
						}

						throw new WebException(e.InnerException.Message);
					}

					throw new WebException();
				}
			});

			return newId;
		}

		//public Dictionary<string, string> ResponseAnagrafeCentralizzata(string fiscalCode) {			

		//	string requestString = $"{{\"fiscalCode\": \"{fiscalCode}\"}}";

		//	HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, $"/api/Public");

		//	request.Content = new StringContent(requestString, System.Text.Encoding.UTF8, "application/json");

		//	HttpResponseMessage response = null;
			
		//	WebPolicy.Execute(() => {
		//		try {
		//			response = AsyncHelpers.RunSync(
		//				() => client.SendAsync(request)	
		//			);
		//		}
		//		catch (Exception e) {
		//			if (e.InnerException != null) {
		//				if (e.InnerException is ApiException<ProblemDetails>) {
		//					var message = JsonConvert.SerializeObject(((ApiException<ProblemDetails>)e.InnerException).Result, Formatting.Indented);
		//					throw new Exception(message);
		//				}

		//				throw new WebException(e.InnerException.Message);
		//			}

		//			throw new WebException();
		//		}
		//	});

		//	if (response.StatusCode != HttpStatusCode.OK) return null;

		//	string responseString = AsyncHelpers.RunSync(
		//		() => response.Content.ReadAsStringAsync()	
		//	);
			
		//	int s1 = responseString.IndexOf("\"areeOrganizzativeOmogenee\"");
		//	int s2 = responseString.IndexOf("\"codiceAoo\"", s1);
		//	int s3 = responseString.IndexOf("\"", s2 + 13);
		//	int s4 = responseString.IndexOf("\"", s3 + 1);

		//	string codiceAoo = responseString.Substring(s3 + 1, s4 - s3 - 1);

		//	s1 = responseString.IndexOf("\"unitaOrganizzative\"", s4 + 10);
		//	s2 = responseString.IndexOf("\"codiceUnivocoUo\"", s1);
		//	s3 = responseString.IndexOf("\"", s2 + 19);
		//	s4 = responseString.IndexOf("\"", s3 + 1);

		//	string codiceUnivocoUo = responseString.Substring(s3 + 1, s4 - s3 - 1);

		//	return new Dictionary<string, string>
		//	{
		//		{ "codiceAoo", codiceAoo },
		//		{ "codiceUnivocoUo", codiceUnivocoUo }
		//	};
		//}

	}
}
