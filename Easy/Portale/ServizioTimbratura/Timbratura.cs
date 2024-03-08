
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
using System.Data;
using System.Collections.Generic;
using System.Linq;
using metaeasylibrary;
using metadatalibrary;
using System.IO;
using System.Net;
using System.Xml;
using System.Web.UI.WebControls;
using System.Configuration;

namespace ServizioTimbratura
{
	public partial class Timbratura
    {
		public Timbratura()
		{
			DoInit();
        }

		private string Server;
		private string Database;
		private string Dipartimento;
		private string User;
		private string Password;

		string usernameWs;
		string passwordWs;
		string compagniaWs;
		string urlTimbratura;
        string urlCostoOrario;

		// =======================================================================================================================================
		// INIT, READ CONFIG FILE
		// =======================================================================================================================================
		private void DoInit()
		{
            try
			{
				// Custom Config File
				string customConfigFileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "AppServizioTimbratura.config");
				ExeConfigurationFileMap configFileMap = new ExeConfigurationFileMap { ExeConfigFilename = customConfigFileName };
                Configuration config = ConfigurationManager.OpenMappedExeConfiguration(configFileMap, ConfigurationUserLevel.None);

                // Connection
                Server = config.AppSettings.Settings["server"].Value;
                Database = config.AppSettings.Settings["database"].Value;
				Dipartimento = config.AppSettings.Settings["dipartimento"].Value;
				User = config.AppSettings.Settings["username"].Value;
				Password = config.AppSettings.Settings["password"].Value;

				// Services
				usernameWs = config.AppSettings.Settings["uniSalentoWS_username"].Value;
				passwordWs = config.AppSettings.Settings["uniSalentoWS_password"].Value;
				compagniaWs = config.AppSettings.Settings["uniSalentoWS_compagnia"].Value;
                urlTimbratura = config.AppSettings.Settings["uniSalentoWS_urlTimbratura"].Value;
                urlCostoOrario = config.AppSettings.Settings["uniSalentoWS_urlCostoOrario"].Value;

				inf($"Init Timbratura OK");
            }
			catch (Exception Ex)
			{
                inf($"Error Init Timbratura: {Ex.Message}, {Ex.InnerException?.Message}");
			}
		}

		public static void getInfo(out bool enableCostoOrario, out bool enableTimbratura, out string hourStartCostoOrario, out string hourStartTimbratura)
		{
			string customConfigFileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "AppServizioTimbratura.config");
			ExeConfigurationFileMap configFileMap = new ExeConfigurationFileMap { ExeConfigFilename = customConfigFileName };
			Configuration config = ConfigurationManager.OpenMappedExeConfiguration(configFileMap, ConfigurationUserLevel.None);

			enableCostoOrario = config.AppSettings.Settings["enableCostoOrario"].Value == "Y";
			enableTimbratura = config.AppSettings.Settings["enableTimbratura"].Value == "Y";

			hourStartCostoOrario = config.AppSettings.Settings["hourStartCostoOrario"].Value;
			hourStartCostoOrario = string.IsNullOrEmpty(hourStartCostoOrario) ? "7:00" : hourStartCostoOrario;

			hourStartTimbratura = config.AppSettings.Settings["hourStartTimbratura"].Value;
			hourStartTimbratura = string.IsNullOrEmpty(hourStartTimbratura) ? "7:00" : hourStartTimbratura;
		}

		// =======================================================================================================================================
		// CONNECTION
		// =======================================================================================================================================
		private Easy_DataAccess CreateConnection(out string error, out string detail)
        {
            error = string.Empty;
			detail = string.Empty;

            DateTime DataContabile = DateTime.Now;
            int Esercizio = DataContabile.Year;

            Easy_DataAccess easy_DataAccess = null;
            try
			{
				// =======================================================
				// CONNESSIONE
				// =======================================================
				easy_DataAccess = Easy_DataAccess.getEasyDataAccess("DSN", Server, Database, User, Password, Dipartimento, Esercizio, DataContabile, out error, out detail);
            
                if (!string.IsNullOrEmpty(error) || !string.IsNullOrEmpty(detail))
					inf($"Error CreateConnection: {error}\r\n{detail}");
            }
			catch (Exception Ex)
			{
                inf($"Error CreateConnection: {Ex.Message}, {Ex.InnerException?.Message}");
            }

            return easy_DataAccess;
        }

		// =======================================================================================================================================
		// TIMBRATURE
		// =======================================================================================================================================
		public void DoUpdateTimbrature()
		{
			inf("DoUpdateTimbrature Started");

			try
			{
				string error = "";
				string detail = "";

				Easy_DataAccess easy_DataAccess = CreateConnection(out error, out detail);

				if (string.IsNullOrEmpty(error))
				{
					// =======================================================
					// ELENCO DEGLI IDREG/MATRICOLA
					// =======================================================
					List<utente> idRegMatricole = easy_DataAccess.SQLRunner(QryMatricolePerTimbratura())
						.Select()
						.Select(s => new utente() { idreg = s["idreg"].ToString(), matricola = s["extmatricula"].ToString() })
						.ToList();

					// =======================================================
					// UTENTI SENZA MATRICOLA
					// =======================================================
					string[] utentiSenzaMatricola = idRegMatricole.Where(w => string.IsNullOrEmpty(w.matricola)).Select(s => s.idreg).ToArray();
					if (utentiSenzaMatricola.Length > 0)
						inf($"Gli utenti con idreg [{String.Join(", ", utentiSenzaMatricola)}] non anno la matricola");

					// =======================================================
					// UTENTI CON MATRICOLA
					// =======================================================
					string matrList = string.Join(",", idRegMatricole.Where(w => !string.IsNullOrEmpty(w.matricola)).Select(s => s.matricola).ToArray());

					// =======================================================
					// ELENCO DELLE DATE MANCATI
					// =======================================================
					string sqlMissingDates = @"DECLARE @StartDate DATE = (SELECT MIN([data]) FROM timbratura);
											DECLARE @EndDate DATE = (SELECT CAST(DATEADD(DAY, -1, GETDATE()) AS DATE));
											WITH Dates AS (
												SELECT @StartDate AS [Date]
												UNION ALL
												SELECT DATEADD(day, 1, [Date]) FROM Dates WHERE [Date] < @EndDate
											)
											SELECT [Date] FROM Dates
											OPTION (MAXRECURSION 0);";

					// Elenco date mancati
					DateTime[] missingDates = easy_DataAccess.SQLRunner(sqlMissingDates).Select().Select(s => (DateTime)s["Date"]).ToArray();

					// =======================================================
					// ELABORO LE DATE MANCATI
					// =======================================================
					if (missingDates.Length > 0)
					{
						// Elenco di range di date mancanti
						List<Tuple<DateTime, DateTime>> rangeList = new List<Tuple<DateTime, DateTime>>();

						DateTime from = missingDates[0];
						DateTime curr = from;

						for (int i = 1; i < missingDates.Length; i++)
						{
							DateTime to = missingDates[i];
							if ((to - curr).Days > 1)
							{
								rangeList.Add(new Tuple<DateTime, DateTime>(from, curr));
								if (i < missingDates.Length - 1)
									from = missingDates[i];
							}
							curr = to;
						}
						rangeList.Add(new Tuple<DateTime, DateTime>(from, missingDates[missingDates.Length - 1]));

						rangeList.Add(new Tuple<DateTime, DateTime>(DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-1)));

						// =======================================================
						// PER OGNI RANGE DI DATE
						// =======================================================
						foreach (Tuple<DateTime, DateTime> range in rangeList)
						{
							// Creo il parametro del WS
							InserisciTimbraturePrm periodAndMatricole = new InserisciTimbraturePrm()
							{
								dateFrom = range.Item1.ToString("yyyyMMdd"),
								dateTo = range.Item2.ToString("yyyyMMdd"),
								matricola = matrList
							};

							// Prendo le timbrature
							string result = SalvaTimbratureSuDb(easy_DataAccess, periodAndMatricole);
						}
					}
					else
					{
						inf("Nessuna Timbratura da aggiornare");
					}
				}
			}
            catch (Exception Ex)
            {
                inf($"Error DoUpdateTimbrature: {Ex.Message}, {Ex.InnerException?.Message}");
            }

            inf("DoUpdateTimbrature End");
		}

		private string SalvaTimbratureSuDb(Easy_DataAccess easy_DataAccess, InserisciTimbraturePrm prms)
        {
            try
            {
                // Tls12 è necessario per il WebService chiamato
                // Se si omette questa chiamata ritorna non riesce a fare l'hand-shake
                System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

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

				HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(urlTimbratura);
				webRequest.ContentType = "text/xml;charset=\"utf-8\"";
				webRequest.Accept = "text/xml";
				webRequest.Method = "POST";

				// Get Request
				using (Stream stream = webRequest.GetRequestStream())
				{
					soapEnvelopeXml.Save(stream);
				}

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
									matricola = info[0],
									giorno = DateTime.Parse(info[1]),
									minuti = int.Parse(info[2]),
									convalida = info[3] == "1" ? "S" : "N"
								}
							);
						}

						inf($"Lavoratori: {lavoratori.Count}");

						// Connection
						Dispatcher dispatcher = new Dispatcher();
						dispatcher.Connection = easy_DataAccess;

						var ds = new dsmeta_registry_anagrafica();
						var getData = new GetData();
						getData.InitClass(ds, easy_DataAccess, "registry");

						// Filtro
						//string filter = String.Join(" or ", lavoratori.Select(s => "format(CAST(extmatricula as int) ,'0000000000000000') = '" + s.matricola.PadLeft(16, '0') + "'").Distinct().ToList());
						string filter = String.Join(" or ", lavoratori.Select(s => "(REPLICATE('0', 16 - isnull(len(extmatricula), 0)) + isnull(extmatricula, '')) = '" + s.matricola.PadLeft(16, '0') + "'").Distinct().ToList());
						getData.GET_PRIMARY_TABLE(filter);
						var registryRow = ds.registry.ToList();

						// ================================================================================
						// Elenco matricole non presenti in anagrafica
						// ================================================================================
						List<string> matricoleNonInAnagrafica = new List<string>();

						// Cerca matricole non presenti in anagrafica
						foreach (Lavoratore lav in lavoratori)
						{
							if (!registryRow.Any(w => w["extmatricula"].ToString().Trim().PadLeft(16, '0') == lav.matricola.ToString().PadLeft(16, '0')))
							{
								matricoleNonInAnagrafica.Add(lav.matricola);
							}
						}

						string mailBody = "";

						// Invio Email Log lavoratori non presenti in anagrafica
						if (matricoleNonInAnagrafica.Any())
							mailBody = $"Le matricole {String.Join(", ", matricoleNonInAnagrafica.Distinct())} non corrispondono a nessuna anagrafica";

						// Rimuovo i lavoratori non presenti in anagrafica
						foreach (string mat in matricoleNonInAnagrafica)
						{
							Lavoratore lav = lavoratori.FirstOrDefault(w => w.matricola == mat);
							if (lav != null)
								lavoratori.Remove(lav);
						}

						// Collego matricola e idreg
						foreach (Lavoratore lav in lavoratori)
							lav.idreg = int.Parse(registryRow.FirstOrDefault(w => w["extmatricula"].ToString().Trim().PadLeft(16, '0') == lav.matricola.ToString().PadLeft(16, '0'))["idreg"].ToString());

						// Mail eventuali errori
						if (!string.IsNullOrEmpty(mailBody))
							inf(mailBody);

						// Inserisco le ore lavorate
						foreach (Lavoratore lavoratore in lavoratori)
						{
							try
							{
								easy_DataAccess.SQLRunner(INStimbratura(lavoratore.idreg, lavoratore.convalida, lavoratore.giorno, lavoratore.minuti));
							}
							catch (Exception Ex)
							{
								inf("Error SQLRunner INStimbratura: " + Ex.Message + "\r\n" + Ex.StackTrace);
							}
						}
					}
				}
			}
			catch (Exception Ex)
			{
				inf($"Error SalvaTimbratureSuDb: {Ex.Message}, {Ex.InnerException?.Message}\r\n{Ex.StackTrace}");
            }

            return "OK";
		}

        // =======================================================================================================================================
        // COSTO ORARIO
        // =======================================================================================================================================
        public void DoUpdateCostoOrario()
        {
            inf("DoUpdateCostoOrario Start");

            try
            {
				string error = "";
				string detail = "";

				Easy_DataAccess easy_DataAccess = CreateConnection(out error, out detail);

				if (string.IsNullOrEmpty(error))
				{
					// =======================================================
					// ELENCO DEGLI IDREG/MATRICOLA
					// =======================================================
					List<Costi> listaCosti = new List<Costi>();

					try
					{
						listaCosti = easy_DataAccess.SQLRunner(QryMatricolePerCostoOrario())
						.Select()
						.Select(s => new Costi() { start = DateTime.Parse(s["start"].ToString()), matricole = s["matricole"].ToString() })
						.ToList();
					}
					catch (Exception Ex)
					{
						inf(Ex.Message + "\r\n" + Ex.StackTrace);
					}

					if (listaCosti.Any())
					{
						foreach (Costi costo in listaCosti)
						{
							// Creo il parametro del WS
							InserisciCostoOrarioPrm period = new InserisciCostoOrarioPrm()
							{
								dataElab = costo.start.ToString("dd/MM/yyyy"),
								dataStop = "",
								matricola = costo.matricole
							};

							// Prendo le timbrature
							getCostoOrario(easy_DataAccess, period);
						}
					}
					else
					{
						inf("Nessun costo orario da aggiornare");
					}
				}
            }
            catch (Exception Ex)
            {
                inf($"Error DoUpdateCostoOrario: {Ex.Message}, {Ex.InnerException?.Message}\r\n{Ex.StackTrace}");
            }

            inf("DoUpdateCostoOrario End");
        }

		private void getCostoOrario(Easy_DataAccess easy_DataAccess, InserisciCostoOrarioPrm prms)
		{
			try
			{
				// List dei dati da inserire alla fine su tabella
				List<LavoratoreCostoOrario> lavoratori = new List<LavoratoreCostoOrario>();
				string mailBody = "";

				resultCostoOrario result = new resultCostoOrario();
				DateTime dataStart = DateTime.Parse(prms.dataElab);
				DateTime dataRicCorrente = (prms.dataStop != null && prms.dataStop != "") ? DateTime.Parse(prms.dataStop) : dataStart; // Se non passata data fine utilizza quella inizio per la ricerca

				bool isConsecutiveCall = false;
				prms.dataElab = dataRicCorrente.Day + "/" + dataRicCorrente.Month + "/" + dataRicCorrente.Year; //Parto dalla data di fine del periodo

                // Cerco finché ho delle matricole in anagrafica && la data di ricerca è >= di quella di inizio
                while (prms.matricola.Length > 0 && dataRicCorrente >= dataStart)
				{
					result = this._getCostoOrario(easy_DataAccess, prms, isConsecutiveCall);

					if (result.esitoMsg != "OK")
						inf(result.esitoMsg);

					mailBody += (mailBody == "" ? "" : "<br /><br />") + result.mailBody;

					if (result.lavoratori != null && result.lavoratori.Any()) //Se torna delle righe da inserire su db
						lavoratori.AddRange(result.lavoratori); // Appendo il risultato

					prms.matricola = result.newMatricola; // Stringa di matricole per prossima richiesta
					prms.dataElab = result.newDataElab; //Ritorna il giorno prima alla data di inizio del periodo appena estratto dal ws
					if (prms.dataElab != null && prms.dataElab.Length > 0)
						dataRicCorrente = DateTime.Parse(prms.dataElab);

					isConsecutiveCall = true;
				}

				// Mail eventuali errori
				if (!string.IsNullOrEmpty(mailBody))
					inf("Costo orario Matricole: " + mailBody);

				if (lavoratori.Any() && result.esitoMsg == "OK")
				{
					// Connection
					Dispatcher dispatcher = new Dispatcher();
					dispatcher.Connection = easy_DataAccess;
					dsmeta_registry_anagrafica ds = new dsmeta_registry_anagrafica();

					// Inserisco le ore lavorate
					foreach (LavoratoreCostoOrario lavoratore in lavoratori)
					{
						try
						{
							easy_DataAccess.SQLRunner(
								INScostoorario(
									lavoratore.idreg,
									lavoratore.giornoValidita,
									lavoratore.giornoStop,
									lavoratore.costoOrario,
									lavoratore.oneri,
									lavoratore.irap,
									lavoratore.costoOrarioTotale));
						}
						catch (Exception Ex)
						{
							result.esitoMsg = "Errore: server dati, errore nella scrittura del commit.";
							inf(Ex.Message + "\r\n" + Ex.StackTrace);
						}
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
				else
				{
					inf("Nessun lavoratore");
                }
            }
            catch (Exception Ex)
            {
                inf($"Error getCostoOrario: {Ex.Message}, {Ex.InnerException?.Message}\r\n{Ex.StackTrace}");
            }
        }

		private resultCostoOrario _getCostoOrario(Easy_DataAccess easy_DataAccess, InserisciCostoOrarioPrm prms, bool isConsecutiveCall)
		{
			resultCostoOrario result = new resultCostoOrario();
			result.esitoMsg = "OK";
			
			//I parametri sono aggiunti direttamente sulla querystring della URL
			string url = urlCostoOrario + $@"?elenco_matricole={prms.matricola}&data={prms.dataElab}";
			string responseBody = string.Empty;

			// Request
			HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(url);
			webRequest.ContentType = "text/xml;charset=\"utf-8\"";
			webRequest.Method = "GET";

			try
			{
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
						dispatcher.Connection = easy_DataAccess;
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
						if (!isConsecutiveCall)
						{ // Non controllo se le matricole esistono se è il secondo giro, ho già controllato e preparato e-mail da inviare
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
							if (matricoleNonInAnagrafica.Any())
								result.mailBody += $"Le matricole {String.Join(", ", matricoleNonInAnagrafica.Distinct())} non corrispondono a nessuna anagrafica";

							// Rimuovo i lavoratori non presenti in anagrafica
							foreach (int mat in matricoleNonInAnagrafica)
							{
								LavoratoreCostoOrario lav = lavoratori.FirstOrDefault(w => w.matricola == mat);
								if (lav != null)
									lavoratori.Remove(lav);
							}
						}

						if (lavoratori.Count > 0)
						{
							List<string> matricoleLista = new List<string>();

							// Collego matricola e idreg
							foreach (LavoratoreCostoOrario lav in lavoratori)
							{
								lav.idreg = int.Parse(registryRow.FirstOrDefault(w => w["extmatricula"].ToString() == lav.matricola.ToString())["idreg"].ToString());

								matricoleLista.Add(lav.matricola.ToString());
							}
							result.newMatricola = String.Join(",", matricoleLista);

							// Prendo i costi orari con idreg e dataStart
							string filterGiaInserito = String.Join(" or ", lavoratori.Select(s => "idreg=" + s.idreg + $" and start='{s.giornoValidita.Year}-{s.giornoValidita.Month}-{s.giornoValidita.Day}'").Distinct().ToList());
							string filterGiaInseritoForMail = String.Join(" <br /> ", lavoratori.Select(s => "idreg=" + s.idreg + $" and start='{s.giornoValidita.Day}/{s.giornoValidita.Month}/{s.giornoValidita.Year}").Distinct().ToList()) + "<br />";
							string filterMatricolaGiaInserito = filterGiaInserito + "<br />";
							string filterMatricolaGiaInseritoForMail = filterGiaInseritoForMail + "<br />";

							//var giaInseriti = ds.costoorario.getFromDb(dispatcher.conn, filterGiaInserito).ToList();
							DataRow[] giaInseriti = easy_DataAccess.SQLRunner(QryCostoOrario(filterGiaInserito)).Select();

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
							if (matricoleGiaInserite.Any())
								result.mailBody += (result.mailBody == "" ? "" : "<br /><br />") + $"I costi orari per (matricola in data) <br />{filterMatricolaGiaInseritoForMail} sono già stati inseriti.<br />";

							ds.costoorario.Clear(); // Pulisco il dataset perché non accetta duplicati

							if (lavoratori.Any())
							{
								foreach (LavoratoreCostoOrario lav in lavoratori)
								{
									string filterDaStoppare = $"idreg= {lav.idreg} and start > '{lav.giornoValidita.Year}-{lav.giornoValidita.Month}-{lav.giornoValidita.Day}'";
									DataRow daStoppare = easy_DataAccess.SQLRunner(QryCostoOrario(filterDaStoppare)).Select().OrderBy(o => o["start"]).FirstOrDefault();


									//var daStoppare = ds.costoorario.getFromDb(dispatcher.conn, filterDaStoppare).ToList().OrderBy(o => o["start"]).FirstOrDefault();
									if (daStoppare != null) //Prima determino data stop per le righe correnti
									{
										if (DateTime.Parse(daStoppare["start"].ToString()) > lav.giornoValidita)
										{
											lav.giornoStop = DateTime.Parse(daStoppare["start"].ToString()).AddDays(-1);
										}
									}

									filterDaStoppare = $"idreg= {lav.idreg} and start < '{lav.giornoValidita.Year}-{lav.giornoValidita.Month}-{lav.giornoValidita.Day}'";
									daStoppare = easy_DataAccess.SQLRunner(QryCostoOrario(filterDaStoppare)).Select().OrderBy(o => o["start"]).FirstOrDefault();
									//daStoppare = ds.costoorario.getFromDb(dispatcher.conn, filterDaStoppare).ToList().OrderByDescending(o => o["start"]).FirstOrDefault();
									if (daStoppare != null)
									{
										daStoppare["stop"] = lav.giornoValidita.AddDays(-1);
									}
								}
								result.lavoratori = lavoratori;
							}
						}
						else
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

                inf("GetCostoOrario OK");
            }
			catch (Exception Ex)
			{
				inf(Ex.Message + "\r\n" + Ex.StackTrace);
			}

            return result;
		}

        // =======================================================================================================================================
        // QUERY COSTO ORARIO
        // =======================================================================================================================================
        private string QryMatricolePerCostoOrario()
		{
			return @"select start, STRING_AGG(extmatricula, ', ') as matricole from costoorario c
						inner join registry r on c.idreg = r.idreg
						where c.stop is null
						group by start";
		}

		private string QryCostoOrario(string filter)
		{
			return $@"select * from costoorario where {filter}";
		}

		private string INScostoorario(int idreg, DateTime start, DateTime? stop, decimal? netto, decimal? oneri, decimal? irap, decimal? totale)
		{
			return $@"INSERT INTO costoorario (idreg,start,stop,ct,cu,lt,lu,netto,oneri,irap,totale)
						VALUES (
							(select max(idcostoorario) + 1 from costoorario),
							{idreg},
							{start},
							{(stop == null ? "NULL" : stop?.ToString("dd/MM/yyyy"))},
							getdate(),
							'ServizioTimbratura',
							getdate(),
							'ServizioTimbratura',
							{(netto == null ? "NULL" : netto.ToString())},
							{(oneri == null ? "NULL" : oneri.ToString())},
							{(irap == null ? "NULL" : irap.ToString())},
							{(totale == null ? "NULL" : totale.ToString())})";
        }

        // =======================================================================================================================================
		// QUERY TIMBRATURE
        // =======================================================================================================================================
        private string QryMatricolePerTimbratura()
        {
            return @"declare @dateStart as datetime
					set @dateStart = dateadd(day, 1, (select min(data) from timbratura));

					declare @dateStop as datetime
					set @dateStop = dateadd(day, -1, getdate());

					select idreg, extmatricula from (
							select r.idreg, isnull(r.extmatricula, '') as extmatricula
							from progetto p
							inner join progettoudrmembro pm on p.idprogetto = pm.idprogetto
							inner join registry r on pm.idreg = r.idreg
							where p.start <= @dateStop and p.stop >= @dateStart
							-- and p.idprogettostatuskind = 8
							
						union

							select r.idreg, isnull(r.extmatricula, '') as extmatricula
							from progetto p
							inner join progettoregistry_docenti pm on p.idprogetto = pm.idprogetto
							inner join registry r on pm.idreg_docenti = r.idreg
							where p.start <= @dateStop and p.stop >= @dateStart
							-- and p.idprogettostatuskind = 8
						union

							select r.idreg, isnull(r.extmatricula, '') as extmatricula
							from progetto p
							inner join progettoregistry_amministrativi pm on p.idprogetto = pm.idprogetto
							inner join registry r on pm.idreg_amministrativi = r.idreg
							where p.start <= @dateStop and p.stop >= @dateStart
							-- and p.idprogettostatuskind = 8
					) a";
        }

        private string INStimbratura(int idreg, string convalida, DateTime data, int minuti)
        {
            string ret = $@"IF EXISTS (SELECT * FROM TIMBRATURA WHERE IDREG={idreg} AND DATA='{data.Year}-{(data.Month < 10 ? "0" : "")}{data.Month}-{(data.Day < 10 ? "0" : "")}{data.Day}')
					  BEGIN
						UPDATE timbratura 
						SET minuti={minuti}, convalida='{convalida}', lt=getdate()
						WHERE IDREG={idreg} AND CONVALIDA='N' AND DATA='{data.Year}-{(data.Month < 10 ? "0" : "")}{data.Month}-{(data.Day < 10 ? "0" : "")}{data.Day}';
					  END
					  ELSE BEGIN
						INSERT INTO timbratura (idtimbratura,idreg,convalida,ct,cu,data,lt,lu,minuti)
						VALUES (
							(select max(idtimbratura) + 1 from timbratura),
							{idreg},
							'{convalida}',
							getdate(),
							'ServizioTimbratura',
							'{data.Year}-{(data.Month < 10 ? "0" : "")}{data.Month}-{(data.Day < 10 ? "0" : "")}{data.Day}',
							getdate(),
							'ServizioTimbratura',
							{minuti});
						END
					";
            return ret;
        }

        // =======================================================================================================================================
        // PRINT LOG
        // =======================================================================================================================================
        private void inf(string s)
        {
            try { System.IO.File.AppendAllText($"{AppDomain.CurrentDomain.BaseDirectory}__log.txt", DateTime.Now.ToString("yy-MM-dd hh:mm:ss") + " - " + s + "\r\n"); } catch { }
        }
    }
}
