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

using metadatalibrary;
using System;
using System.Data;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace metaeasylibrary
{
    public static class HttpFileStorage
    {
        public static async Task<byte[]> DownloadFile(IDataAccess conn, string bucketName, string idfilestorage)
        {
            try
            {
                QueryHelper qhs = conn.GetQueryHelper();
                DataTable dt = conn.RUN_SELECT("app_config", "param", null, qhs.CmpEq("code", "FILESTORAGE"), "1", false);
                if (dt.Rows.Count == 0)
                    return null;

                string serviceParams = dt.Rows[0]["param"].ToString();

                if (string.IsNullOrEmpty(serviceParams))
                    return null;

                string[] paramList = serviceParams.Split('§');
                if (paramList.Length != 2)
                    return null;

                string baseUrl = paramList[0];
                if (string.IsNullOrEmpty(baseUrl))
                    return null;

                string token = paramList[1];
                if (string.IsNullOrEmpty(token))
                    return null;

                if (string.IsNullOrEmpty(bucketName))
                    return null;

                if (string.IsNullOrEmpty(idfilestorage))
                    return null;

                using (HttpRequestMessage requestMessage = new HttpRequestMessage())
                {
                    requestMessage.Method = new HttpMethod("GET");
                    requestMessage.Headers.Add("token", token);
                    requestMessage.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("text/plain"));

                    string slash = baseUrl.EndsWith("/") ? "" : "/";

                    string url = $"{baseUrl}{slash}api/Files/download/{conn.sqlConnection.Database.ToLower()}/{bucketName}/{idfilestorage}";
                    requestMessage.RequestUri = new Uri(url);

                    HttpClient httpClient = new HttpClient();
                    HttpResponseMessage httpResponseMessage = await httpClient.SendAsync(requestMessage, HttpCompletionOption.ResponseHeadersRead).ConfigureAwait(false);
                    if (httpResponseMessage.StatusCode != HttpStatusCode.OK)
                        return null;

                    Stream stream = await httpResponseMessage.Content.ReadAsStreamAsync().ConfigureAwait(false);
                    using (MemoryStream ms = new MemoryStream())
                    {
                        stream.CopyTo(ms);
                        return ms.ToArray();
                    }
                }
            }
            catch
            {
                return null;
            }            
        }
    }
}
