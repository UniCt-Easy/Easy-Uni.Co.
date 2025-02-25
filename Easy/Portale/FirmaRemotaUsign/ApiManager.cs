
/*
Easy
Copyright (C) 2025 Università degli Studi di Catania (www.unict.it)
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


using FirmaRemotaUsign.ApiModels;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Http.Headers;

namespace FirmaRemotaUsign
{
	public class ApiManager
	{
		// ==============================================================
		// GENERIC API REQUEST
		// ==============================================================
		public T GetApi<T>(out string msg, out bool success, object[] param = null, string contentBody = null) where T : IApiModel<T>, new()
		{
            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            success = true;

			string error = "";
			T api = new T();

			bool isPost = api.isPost();

			// createProcess
			// downloadFile/{token}
			string apiMethod = api.getMethod();

			// api/public/
			string service = api.getService();

			// Authorization Type
			bool needAuthorize = api.needAuthorize();

			// downloadFile/{token}
			string method = apiMethod;

			// {token}
			// downloadFile/{token}
			if (param != null)
				method = string.Format(apiMethod, param);

			msg = method + "\r\n";
			string clientUrl = common.api_url + service + method;

			int cnt = 0;

			using (HttpClient client = new HttpClient())
			{
				if (needAuthorize)
				{
                    // =========================
                    //			HEADER
                    // =========================
                    //  - username: easy_unina2
                    //  - password: ***********
                    // =========================
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.ASCII.GetBytes($"{common.auth_username}:{common.auth_password}")));
                }
                
                try
				{
					if (isPost)
					{
                        // =========================
                        // POST
                        // =========================
                        Task<HttpResponseMessage> taskResponseBody;
						
						var request = new HttpRequestMessage(HttpMethod.Post, clientUrl);

						if (!string.IsNullOrEmpty(contentBody))
						{
							var content = new StringContent(contentBody, null, "application/json");
							request.Content = content;
						}

						taskResponseBody = Task.Run(async () => await client.SendAsync(request));

                        HttpResponseMessage responseMsg = taskResponseBody.GetAwaiter().GetResult();

						if (responseMsg.IsSuccessStatusCode)
						{
							string responseContent = responseMsg.Content.ReadAsStringAsync().GetAwaiter().GetResult();

							cnt = 1;
                            api = JsonConvert.DeserializeObject<T>(responseContent);
                        }
                        else
                        {
                            // Read error response
                            var errorResponse = responseMsg.Content.ReadAsStringAsync();

                            error = errorResponse.GetAwaiter().GetResult();
                        }
                    }
					else
					{
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
									DettaglioErrore err = JsonConvert.DeserializeObject<DettaglioErrore>(responseBody);

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
				}
				catch (Exception Ex)
				{
					success = false;

					// Update Info
					error = Ex.Message;
				}
			}

			msg += (error == "" ? $"Result Count: {cnt}" : error) + "\r\n";

			return api;
		}
	}
}
