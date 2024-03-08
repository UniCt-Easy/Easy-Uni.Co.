
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


using ServizioRendicontazione.ApiModels;
using ServizioRendicontazione.Models;
using Newtonsoft.Json;

namespace ServizioRendicontazione
{
	public static class ApiManager
	{
		// ==============================================================
		// GENERIC API REQUEST
		// ==============================================================
		public static T GetApi<T>(out string msg, out bool success, object[] param = null, string qryString = "") where T : IApiModel<T>, new()
		{
			success = true;

			string error = "";
			T api = new T();

			// offerte/{aaOffId}/{cdsOffId}/attivita
			// offerte/{0}/{1}/attivita
			string apiMethod = api.getMethod();

			// e3rest/api/offerta-service-v1
			string service = api.getService();

			bool needAuthorize = false;

			// Authorization Type
			if (!common.auth_type_basic)
				needAuthorize = api.needAuthorize();

			// +diarioId,+aaId,+docenteId
			string fields = api.getField();

			// +diarioId,+aaId,+docenteId
			string order = api.getOrder();

			// offerte/{0}/{1}/attivita
			string method = apiMethod;

			// [2023,10]
			// offerte/2023/10/attivita
			if (param != null)
				method = string.Format(apiMethod, param);

			// offerte/{0}/{1}/attivita?start={start}&limit={limit}
			// offerte/2023/10/attivita?start=0&limit=50
			method += $"?limit={common.limit}";

			if (fields != "")
				method += $"&fields={fields}";

			// aaId=2022
			// offerte/2023/10/attivita?start=0&limit=50&aaId=2022
			if (qryString != "")
				method += qryString;

			// offerte/2023/10/attivita?start=0&limit=50&aaId=2022&order=+diarioId,+aaId,+docenteId
			if (order != "")
				method += $"&order={order}";

			msg = method + "<br />";
			string remote = service + method;
			string clientUrl = common.api_url + service + method;

			int cnt = 0;

			using (HttpClient client = new HttpClient())
			{
				// =========================
				// HEADER
				// =========================
				if (common.auth_type_basic)
				{
					// =========================
					// BASIC AUTHENTICATION
					// =========================
					// Header
					//   - Authorization: Token **************************************
					// =========================
					client.DefaultRequestHeaders.Add("Authorization", "Token " + common.auth_basic_token);
				}
				else if (needAuthorize)
				{
					// =========================
					// API-KEY AUTHENTICATION
					// =========================
					// Header
					//   - X-API-REMOTE-SERVICE: https://studenti.unisalento.it/e3rest/api/offerta-service-v1/offerte/attivita
					//   - X-API-KEY: 670da5dc6722e7eb4f1251c5edbcdfd7ea8278748bf2da42f80b93b5bf8a51af511c00b6eff071927c54cefd8b6628ad6a35f1e32cb8bb42e80aafa5dc08a6ef
					// =========================
					client.DefaultRequestHeaders.Add(common.auth_api_remote, remote);
					client.DefaultRequestHeaders.Add(common.auth_api_key, common.auth_api_key_value);
					clientUrl = common.auth_api_url;
				}

				// =========================
				// GET
				// =========================
				try
				{
					var taskResponse = Task.Run(async () => await client.GetAsync(clientUrl));
					HttpResponseMessage response = taskResponse.GetAwaiter().GetResult();

					// Success ?
					if (response.IsSuccessStatusCode)
					{
						// Response
						var taskResponseBody = Task.Run(async () => await response.Content.ReadAsStringAsync());
						string responseBody = taskResponseBody.GetAwaiter().GetResult();
						if (responseBody.Contains("errDetails"))
						{
							try
							{
								DettaglioErrore? err = JsonConvert.DeserializeObject<DettaglioErrore>(responseBody);

								// Update Info
								if (err != null)
									error = err.retErrMsg;
								else
									error = $"{"Failed to call API: " + responseBody}";
							}
							catch (Exception Ex)
							{
								// Update Info
								error = Ex.Message;
							}

							// something wrong
							success = false;
						}
						else
						{
							if (responseBody.StartsWith("["))
							{
								// Convert from Json to List<T>
								List<T> list = JsonConvert.DeserializeObject<List<T>>(responseBody);

								// Get one
								if (list.Count() > 0)
								{
									cnt = 1;
									api = list[0];
								}
								else
								{
									api = default(T);
								}
							}
							else
							{
								api = JsonConvert.DeserializeObject<T>(responseBody);
							}
						}
					}
					else
					{
						// something wrong
						success = false;

						// Update Info
						error = $"{"Failed to call API: " + response.ReasonPhrase}";
					}
				}
				catch (Exception Ex)
				{
					success = false;

					// Update Info
					error = Ex.Message;
				}
			}

			msg += (error == "" ? $"Result Count: {cnt}" : error) + "<br/>";

			return api;
		}

		public static List<T> GetApiList<T>(out string msg, out bool success, object[] param = null, string qryString = "") where T : IApiModel<T>, new()
		{
			string error = "";
			T api = new T();

			// offerte/{aaOffId}/{cdsOffId}/attivita
			// offerte/{0}/{1}/attivita
			string apiMethod = api.getMethod();

			// e3rest/api/offerta-service-v1
			string service = api.getService();

			bool needAuthorize = false;

			// Authorization Type
			if (!common.auth_type_basic)
				needAuthorize = api.needAuthorize();

			// +diarioId,+aaId,+docenteId
			string fields = api.getField();

			// +diarioId,+aaId,+docenteId
			string order = api.getOrder();

			// Init List
			bool doIt = true;
			success = true;
			int start = 0;
			List<T> fullList = new List<T>();

			msg = "";

			try
			{

				while (doIt)
				{
					// offerte/{0}/{1}/attivita
					string method = apiMethod;

					// [2023,10]
					// offerte/2023/10/attivita
					if (param != null)
						method = string.Format(apiMethod, param);

					// offerte/{0}/{1}/attivita?start={start}&limit={limit}
					// offerte/2023/10/attivita?start=0&limit=50
					method += $"?start={start}&limit={common.limit}";

					if (fields != "")
						method += $"&fields={fields}";

					// aaId=2022
					// offerte/2023/10/attivita?start=0&limit=50&aaId=2022
					if (qryString != "")
						method += qryString;

					// offerte/2023/10/attivita?start=0&limit=50&aaId=2022&order=+diarioId,+aaId,+docenteId
					if (order != "")
						method += $"&order={order}";

					msg = method + "<br />";
					string remote = service + method;
					string clientUrl = common.api_url + service + method;

					using (HttpClient client = new HttpClient())
					{
						// =========================
						// HEADER
						// =========================
						if (common.auth_type_basic)
						{
							// =========================
							// BASIC AUTHENTICATION
							// =========================
							// Header
							//   - Authorization: Token **************************************
							// =========================
							client.DefaultRequestHeaders.Add("Authorization", "Token " + common.auth_basic_token);
						}
						else if (needAuthorize)
						{
							// =========================
							// API-KEY AUTHENTICATION
							// =========================
							// Header
							//   - X-API-REMOTE-SERVICE: https://studenti.unisalento.it/e3rest/api/offerta-service-v1/offerte/attivita
							//   - X-API-KEY: 670da5dc6722e7eb4f1251c5edbcdfd7ea8278748bf2da42f80b93b5bf8a51af511c00b6eff071927c54cefd8b6628ad6a35f1e32cb8bb42e80aafa5dc08a6ef
							// =========================
							client.DefaultRequestHeaders.Add(common.auth_api_remote, remote);
							client.DefaultRequestHeaders.Add(common.auth_api_key, common.auth_api_key_value);
							clientUrl = common.auth_api_url;
						}
						// =========================
						// GET
						// =========================
						var taskResponse = Task.Run(async () => await client.GetAsync(clientUrl));
						HttpResponseMessage response = taskResponse.GetAwaiter().GetResult();

						// Success ?
						if (response.IsSuccessStatusCode)
						{
							// Response
							var taskResponseBody = Task.Run(async () => await response.Content.ReadAsStringAsync());
							string responseBody = taskResponseBody.GetAwaiter().GetResult();
							if (responseBody.Contains("errDetails"))
							{
								try
								{
									DettaglioErrore? err = JsonConvert.DeserializeObject<DettaglioErrore>(responseBody);

									// Update Info
									if (err != null)
										error = err.retErrMsg;
									else
										error = $"{"Failed to call API: " + responseBody}";
								}
								catch (Exception Ex)
								{
									// Update Info
									error = Ex.Message;
								}

								// something wrong
								doIt = false;
								success = false;
							}
							else
							{
								try
								{
									// Convert from Json to List<T>
									List<T>? list = JsonConvert.DeserializeObject<List<T>>(responseBody);

									if (list != null)
									{
										// If Any
										if (list.Any())
										{
											// if not equal to limit (50 o 100) then exit while
											if (list.Count != common.limit)
												doIt = false;

											// add to list
											fullList.AddRange(list);
										}
										else
										{
											// something wrong
											success = false;
											doIt = false;
										}
									}
									else
									{
										// something wrong
										success = false;
										doIt = false;
									}
								}
								catch (Exception Ex)
								{
									// something wrong
									success = false;
									doIt = false;

									// Update Info
									error = Ex.Message;
								}
							}
						}
						else
						{
							// something wrong
							success = false;
							doIt = false;

							// Update Info
							error = $"{"Failed to call API: " + response.ReasonPhrase}";
						}
					}

					start += common.limit;

					if (!common.all)
						doIt = false;
				}
			}
			catch (Exception Ex)
			{
				success = false;

				error = Ex.Message + Ex.InnerException?.Message;
			}

			msg += (error == "" ? $"Result Count: {fullList.Count}" : error) + "<br/>";

			return fullList;
		}
	}
}
