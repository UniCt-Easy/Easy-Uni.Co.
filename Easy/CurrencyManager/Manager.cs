using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Net;
using System.Threading;

using metadatalibrary;
using metaeasylibrary;
using CurrencyManager.Serialization;
using ApiClient;

namespace CurrencyManager
{
	// https://www.bancaditalia.it/compiti/operazioni-cambi/Nuove_Istruzioni_tecnico-operative.pdf

	public enum ReferenceCurrency {
		EUR,
		USD
    }

	public class Manager : IDisposable
    {
        private readonly Client apiClient;
		public string Id { get { return apiClient.Id; } }

        private readonly int baseWait = 2;
        private readonly Random jitterer = new Random();
        private TimeSpan jitter { get { return TimeSpan.FromMilliseconds(jitterer.Next(0, 1000)); } }
        private void throttle() {
            Thread.Sleep(TimeSpan.FromSeconds(baseWait) + jitter);
        }

        private readonly DataAccess conn;
		private DataAccess dbConnection { 
			get {
				try { conn.Close(); }
				catch { }

				conn.Open();
				return conn;
            }
		}
		private readonly Meta_EasyDispatcher metaDispatcher;
		private readonly DataSet dataSet = new DataSet();

		QueryHelper QHS;

		private readonly ReferenceCurrency referenceCurrency = ReferenceCurrency.EUR;
		public ReferenceCurrency ReferenceCurrency { get { return referenceCurrency; } }
		
		public IEnumerable<DateTime> StoredDates {
			get {
				var storedDates = dbConnection.RUN_SELECT("currencyexchange", "referencedate", null, null, null, "referencedate", true).AsEnumerable()
				.Select(sd => sd.Field<DateTime>("referencedate").Date);

				dbConnection.Close();
				return storedDates;
			}
		}
		public bool AnyStoredRate(params DateTime[] dates) { return StoredDates.Any(sd => dates.Select(d => d.Date).Contains(sd)); }

		private DBCommit lastCurrenciesSync = new DBCommit();
		private DBCommit lastRatesCommit = new DBCommit();

		#region Caches
		public ApiResponse<Currency> lastCurrenciesApiResponse;
		public ApiResponse<Rate> lastRatesApiResponse;

		private DBResponse<DBCurrency, string, int> dbCurrencies { 
			get {
				if (lastCurrenciesApiResponse.Stale) {
					RequestCurrencies();
					SyncCurrencies();

					ReadDBCurrencies();
				}

				return dbCurrencies;
			} 
		}
		public DBResponse<DBCurrency, string, int> DBCurrencies;
		#endregion

		public int? GetIdCurrency(string codeCurrency) {
			
			if (DBCurrencies.TryGetValue(codeCurrency, out int idCurrency))	// verifichiamo che la cache delle valute su database contenga il codeCurrency richiesto
				return idCurrency;
			else
				return null;
		}

		public string GetCodeCurrency(int idCurrency) {
			
			string codeCurrency = DBCurrencies.FirstOrDefault(dbc => dbc.Value == idCurrency).Key;	// verifichiamo che la cache delle valute su database contenga l'idCurrency richiesto
			if (codeCurrency != string.Empty)
				return codeCurrency;
			else
				return null;
		}

		public Manager(DataAccess connection, Uri apiEndpoint, int baseWaitSeconds, int baseBackoffSeconds, ReferenceCurrency rc, string id = null) {

			ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

			apiClient = new Client(apiEndpoint, Client.OptionId(id), Client.OptionRetry());
			referenceCurrency = rc;

			conn = connection;
			metaDispatcher = new Meta_EasyDispatcher(dbConnection);
			QHS = dbConnection.GetQueryHelper();

			lastCurrenciesApiResponse = new ApiResponse<Currency>(new TimeSpan(1, 0, 0, 0)); // validità di un giorno per la cache delle valute
			lastRatesApiResponse = new ApiResponse<Rate>();

			DataTable currency = DataAccess.CreateTableByName(dbConnection, "currency", "*");
			DataTable currencyexchange = DataAccess.CreateTableByName(dbConnection, "currencyexchange", "*");
			dataSet.Tables.Add(currency);
			dataSet.Tables.Add(currencyexchange);
			dataSet.Relations.Add(currency.Columns["idcurrency"], currencyexchange.Columns["idcurrency"]);
			metaDispatcher.Get(currency.TableName).SetDefaults(currency);
			metaDispatcher.Get(currencyexchange.TableName).SetDefaults(currencyexchange);

			ReadDBCurrencies();

			conn.Close();
			dbConnection.Close();
		}

		public void Dispose() {
			dbConnection.Destroy();
        }

		public void RequestCurrencies() {
			throttle();

			var now = DateTime.Now;

			var currencies = apiClient.RequestEntity<Currency>("currencies", "currencies");

			if (currencies.Any()) lastCurrenciesApiResponse = new ApiResponse<Currency>(currencies);
		}

		// TODO: si potrebbe aggiungere un metodo refresh sulla cache e trasformare quella classe in una "interfaccia" col db,
		// ma andrebbe fatta una implementazione generica
		public void ReadDBCurrencies() {

			DataTable currency = dataSet.Tables["currency"];
			dbConnection.RUN_SELECT_INTO_TABLE(currency, null, null, null, true);

			var currencies = currency.AsEnumerable().Select(c => new DBCurrency(c));

			if (currencies.Any()) DBCurrencies = new DBResponse<DBCurrency, string, int>(currencies, "codecurrency", "idcurrency");

			dbConnection.Close();
		}

		public void ReadApiDailyRates(DateTime date) {
			throttle();

			var parameters = new Dictionary<string, string>{
				{ "referenceDate", date.ToString("yyyy-MM-dd") },
				{ "currencyIsoCode", referenceCurrency.ToString() }
			}.ToArray();

			var rates = apiClient.RequestEntity<Rate>("dailyRates", "rates", parameters);

			if (rates.Any()) lastRatesApiResponse = new ApiResponse<Rate>(rates);
		}

		public IEnumerable<Rate> RequestDailyRates(DateTime date, string codeCurrency) {
			throttle();

			var parameters = new Dictionary<string, string>{
				{ "referenceDate", date.ToString("yyyy-MM-dd") },
				{ "currencyIsoCode", referenceCurrency.ToString() },
				{ "baseCurrencyIsoCode", codeCurrency }
			}.ToArray();

			return apiClient.RequestEntity<Rate>("dailyRates", "rates", parameters);
		}

		public IEnumerable<DataRow> QueryDailyRates(DateTime date, int idCurrency, uint previousDays = 0) {

			DataTable currencyexchange = dataSet.Tables["currencyexchange"];

			string dateFilter = previousDays != 0 ? 
				QHS.AppAnd(QHS.CmpGt("referencedate", date.AddDays(-previousDays)), QHS.CmpLt("referencedate", date.Date)) : QHS.CmpEq("referencedate", date.Date);

			string filter = QHS.AppAnd(dateFilter, QHS.CmpEq("idcurrency", idCurrency));

			var dailyRates = dbConnection.RUN_SELECT(currencyexchange.TableName, "*", null, filter, null, true).AsEnumerable();
			dbConnection.Close();

			return dailyRates;
        }

		public double? GetDailyEuroCurrencyRate(DateTime mainDate, int idCurrency, uint previousDays) {

			var minDate = mainDate.Date.AddDays(-previousDays);

			var rangeDays = Enumerable.Range(0, 1 + mainDate.Date.Subtract(minDate).Days)
				.Select(offset => minDate.Date.AddDays(offset))
				.Where(d => d < DateTime.Now); // consideriamo solo le date passate

			var dbResponse = QueryDailyRates(mainDate, idCurrency, previousDays);

			foreach (var day in rangeDays.OrderBy(d => d.Date).Reverse()) {

				var dbDailyRates = dbResponse.Where(rate => rate.Field<DateTime>("referencedate") == day);

				if (dbDailyRates.Any()) {
					return dbDailyRates.First().Field<double>("eurocurrencyrate");
                }
				// se non abbiamo risultati da DB
				else {
					// prendiamo i risultati dell'API
					string codeCurrency = GetCodeCurrency(idCurrency);
					if (codeCurrency == null)
						return null;
					var apiResponse = RequestDailyRates(day, codeCurrency);

					if (apiResponse.Any() && double.TryParse(apiResponse.First().avgRate.Replace(".", ","), out double currencyeurorate))
						return 1/currencyeurorate;
				}
			}

			return null;
		}

		public void StoreMissingRates(DateTime start, DateTime end, bool excludeWeekEnds) {

			var rangeWeekDays = Enumerable.Range(0, 1 + end.Date.Subtract(start).Days)
				.Select(offset => start.Date.AddDays(offset))
				.Where(day => excludeWeekEnds && day.DayOfWeek != DayOfWeek.Saturday && day.DayOfWeek != DayOfWeek.Sunday);

			var missingWeekDays = rangeWeekDays.Where(d => !StoredDates.Contains(d));	// ricaviamo solamente le date senza risultati


			foreach (var missingWeekDay in missingWeekDays) {
				ReadApiDailyRates(missingWeekDay);
				CommitApiDailyRates(false);
            }
		}

		public void SyncCurrencies() {

			if (lastCurrenciesApiResponse.Timestamp < lastCurrenciesSync.Timestamp		// se l'ultima richiesta di valute all'API è precedente all'ultimo commit delle valute
				|| !lastCurrenciesApiResponse.Items.Any())								// o l'ultima richiesta di valute non contiene dati
				return;																	// usciamo

			DataTable DTCurrency = dataSet.Tables["currency"];

			IEnumerable<Currency> responseCurrencies = lastCurrenciesApiResponse.Items.Distinct(new IsoCodeEqualityComparer());

            IEnumerable<Currency> newCurrencies = responseCurrencies	// prendiamo le valute dell'API
				.Where(vc => !DBCurrencies.ContainsKey(vc.isoCode));	// il cui isoCode non è presente sul db (in cache)

			foreach (Currency c in newCurrencies) {

				var row = metaDispatcher.Get(DTCurrency.TableName).Get_New_Row(null, DTCurrency);
				row["codecurrency"] = c.isoCode;
				row["description"] = string.Format("{0} - {1}", c.name, c.isoCode);
				//row["active"] = 'S';
				row["cu"] = Id;
				row["lu"] = Id;
			}

			IEnumerable<Currency> validCurrencies = responseCurrencies	// valute in vigore: consideriamo le valute che abbiano scadenza di validità nulla o futura in almeno uno Stato
				.Where(
					currency => currency.countries
					.Where(country => country.validityEndDate == null || country.validityEndDate > DateTime.Now)
					.Any()
				)
				.Distinct(new IsoCodeEqualityComparer());

			IEnumerable<Currency> currenciesToDisable = responseCurrencies.Except(validCurrencies);

            DTCurrency.AsEnumerable()																					// sulla tabella delle valute nel dataset
				.Where(row => currenciesToDisable.Select(ctd => ctd.isoCode).Contains(row["codecurrency"].ToString()))	// sulle righe con isoCode da disabilitare
				._forEach(row => row["active"] = 'N');																	// impostiamo a 'N' il campo 'active'

			//dataSet.AcceptChanges();

			var postData = new Easy_PostData_NoBL();
			postData.InitClass(dataSet, dbConnection);

			var messages = postData.DO_POST_SERVICE();
			if (messages == null) {
				throw new Exception("severe errors in DO_POST_SERVICE");
			}

			if (messages.Count != 0) {
				throw new Exception(string.Join("\r\n\r\n", messages.Cast<ProcedureMessage>().Select(pm => pm.LongMess)));
			}

			lastCurrenciesSync = new DBCommit(messages);

			ReadDBCurrencies();
			dbConnection.Close();
		}

		public void CommitApiDailyRates(bool checkExisting = true) {

			if (lastRatesApiResponse.Timestamp < lastRatesCommit.Timestamp  // se l'ultima richiesta di tassi all'API è precedente all'ultimo commit dei tassi
				|| !lastRatesApiResponse.Items.Any())						// o l'ultima richiesta di tassi non contiene dati
				return;														// usciamo

			if (checkExisting) {
				var resultsDates = new HashSet<DateTime>(lastRatesApiResponse.Items.Select(r => r.referenceDate)).ToArray();
				if (AnyStoredRate(resultsDates)) return;
			}

			DataTable currency = dataSet.Tables["currency"];
			DataTable currencyexchange = dataSet.Tables["currencyexchange"];

			var rates = lastRatesApiResponse.Items.GroupBy(r => r.isoCode).Select(r => r.First())   // prendiamo solo il primo tasso, anche se una valuta è usata in più Stati (First) dato che il tasso è lo stesso
				.Where(rate =>																		 
					DBCurrencies.ContainsKey(rate.isoCode) &&                                       // prendiamo i tassi i cui codici valuta siano presenti in cache
					decimal.TryParse(rate.avgRate.Replace(".", ","), out decimal tmp) &&			// e ci assicuriamo che il tasso sia un valore numerico
					tmp != 0                                                                        // diverso da zero
				);

			foreach (Rate r in rates) {
				if (DBCurrencies.ContainsKey(r.isoCode)) {
					var parentRow = currency.AsEnumerable().Where(c => c.Field<string>("codecurrency") == r.isoCode).First();
					var row = metaDispatcher.Get(currencyexchange.TableName).Get_New_Row(parentRow, currencyexchange);

					decimal avgRate = decimal.Parse(r.avgRate.Replace(".", ","));

					row["currencyeurorate"] = avgRate;
					row["eurocurrencyrate"] = 1 / avgRate;
					row["referencedate"] = r.referenceDate;
					row["cu"] = Id;
					row["lu"] = Id;
				}
            }

			//dataSet.AcceptChanges();

			var postData = new Easy_PostData_NoBL();
			postData.InitClass(dataSet, dbConnection);

			var messages = postData.DO_POST_SERVICE();
			if (messages == null) {
				throw new Exception("severe errors in DO_POST_SERVICE");
			}

			if (messages.Count != 0) {
				throw new Exception(string.Join("\r\n\r\n", messages.Cast<ProcedureMessage>().Select(pm => pm.LongMess)));
			}

			lastRatesCommit = new DBCommit(messages);

			dbConnection.Close();
		}
	}
}
