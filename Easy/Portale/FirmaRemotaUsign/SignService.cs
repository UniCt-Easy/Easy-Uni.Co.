
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
using System;
using System.Configuration;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace FirmaRemotaUsign
{
    public class UsignCreateProcessInfo
	{
		public string token { get; set; }
		public string error { get; set; }
	}

	public class UsignUploadFileInfo
	{
		public string fileId { get; set; }
		public string error { get; set; }
	}

	public class UsignSendOtpInfo
	{
		public string error { get; set; }
	}

	public class DownloadSignedFileInfo
	{
		public byte[] outStream { get; set; }
		public string error { get; set; }
	}

	public static class SignService
    {
        private static ApiManager apiManager = new ApiManager();

		// ===========================================
		// FASE 1 - CREATE PROCESS
		// ===========================================
		public static async Task<UsignCreateProcessInfo> createProcessUSign(string email)
		{
			UsignCreateProcessInfo usignCreateProcessInfo = new UsignCreateProcessInfo()
			{
				token = "",
				error = ""
			};

			try
			{
				// API
				common.api_url = ConfigurationManager.AppSettings.Get("usign_api_url");

				// Authorize
				common.auth_username = ConfigurationManager.AppSettings.Get("usign_auth_username");
				common.auth_password = ConfigurationManager.AppSettings.Get("usign_auth_password");

				if (string.IsNullOrEmpty(common.api_url) || string.IsNullOrEmpty(common.auth_username) || string.IsNullOrEmpty(common.auth_password))
				{
					usignCreateProcessInfo.error = $"Configurazione firma u-sign mancante";
					return usignCreateProcessInfo;
				}

				// ===========================================
				// Params
				// ===========================================
				string process_name = $"S{DateTime.Now.ToString("yyMMddHHmmss")}";
				string createProcessContentBody = GetCreateProcessContentBody(email, process_name);

				// ===========================================
				// Call
				// ===========================================
				string msg = "";
				bool success = false;
				CreateProcess createProcess = Get<CreateProcess>(out msg, out success, null, createProcessContentBody);

				// ===========================================
				// Check
				// ===========================================
				if (createProcess.code == 200)
				{
					// Token
					usignCreateProcessInfo.token = createProcess.message;
				}
				else
				{
					// error
					usignCreateProcessInfo.error = createProcess.message + "\r\n" + msg;					
				}
			}
			catch (Exception Ex)
			{
				usignCreateProcessInfo.error = $"\r\n{Ex.Message}\r\n{Ex.InnerException?.Message}\r\n{Ex.StackTrace}";
			}

			return usignCreateProcessInfo;
		}

		// ===========================================
		// FASE 2 - UPLOAD FILE
		// ===========================================
		public static async Task<UsignUploadFileInfo> uploadFileUSign(string token, byte[] byteStream, string pdfName, bool isPdf)
		{
			UsignUploadFileInfo usignUploadFileInfo = new UsignUploadFileInfo()
			{
				fileId = "",
				error = ""
			};

			try
			{
				// ===========================================
				// Sign position
				// ===========================================
				int? page = null;
				double? bottom = null;
				double? left = null;
				double? w = null;
				double? h = null;

				// ===========================================
				// Params
				// ===========================================
				string process_name = $"S{DateTime.Now.ToString("yyMMddHHmmss")}";
				bool isChild = false;
				bool flMarcaTemporale = false;
				bool isNote = false;
				TipoFirma tipoFirma = TipoFirma.PADES;
				string document_type = isPdf ? "“COD_TYPE_PDF" : "ALTRO";
				string uploadQryString = GetUploadQueryString(tipoFirma, isChild, flMarcaTemporale, isNote, page, bottom, left, w, h);

				// ===========================================
				// Call
				// ===========================================
				string fileId = await UploadPDFFileAsync(uploadQryString, token, byteStream, pdfName);

				// ===========================================
				// Check
				// ===========================================
				if (!string.IsNullOrEmpty(fileId))
				{
					// fileId
					usignUploadFileInfo.fileId = fileId;
				}
				else
				{
					// error
					usignUploadFileInfo.error = "Cannot upload file";
				}
			}
			catch (Exception Ex)
			{
				usignUploadFileInfo.error = $"\r\n{Ex.Message}\r\n{Ex.InnerException?.Message}\r\n{Ex.StackTrace}";
			}

			return usignUploadFileInfo;
		}

		// ===========================================
		// FASE 3 - SEND OTP
		// ===========================================
		public static async Task<UsignSendOtpInfo> sendOtpUSign(string token)
		{
			UsignSendOtpInfo usignSendOtpInfo = new UsignSendOtpInfo()
			{
				error = ""
			};

			try
			{
				string msg = "";
				bool success = false;

				// ===========================================
				// Call
				// ===========================================
				SendOtp sendOtp = Get<SendOtp>(out msg, out success, new object[1] { token }, null);

				// ===========================================
				// Check
				// ===========================================
				if (sendOtp.code != 200)
				{
					usignSendOtpInfo.error = sendOtp.message + "\r\n" + msg;
				}
			}
			catch (Exception Ex)
			{
				usignSendOtpInfo.error = $"\r\n{Ex.Message}\r\n{Ex.InnerException?.Message}\r\n{Ex.StackTrace}";
			}

			return usignSendOtpInfo;
		}

		public static async Task<DownloadSignedFileInfo> downloadSignedFileUSign(string token, string fileId, string pin, string otp)
        {
			DownloadSignedFileInfo downloadSignedFileInfo = new DownloadSignedFileInfo()
			{
				outStream = null,
				error = ""
			};

			try
			{
				string msg = "";
				bool success = false;

				// ===========================================
				// FASE 4 - SIGN PROCESS
				// ===========================================
				string qryString = $"pin={pin}&otp={otp}";
                SignProcess signProcess = Get<SignProcess>(out msg, out success, new object[2] { token, qryString });

                if (signProcess.code != 200)
                {
					downloadSignedFileInfo.error = signProcess.message + "\r\n" + msg;
                    return downloadSignedFileInfo;
                }


                // ===========================================
                // FASE 5 - DOWNLOAD SINGLE FILE
                // ===========================================
                qryString = $"fileId={fileId}";
                DownloadSingleFile downloadFile = Get<DownloadSingleFile>(out msg, out success, new object[2] { token, qryString });

                if (downloadFile.code != 200)
                {
					downloadSignedFileInfo.error = downloadFile.message + "\r\n" + msg;
                    return downloadSignedFileInfo;
                }

				// ===========================================
				// Return File Byte Array
				// ===========================================
				downloadSignedFileInfo.outStream = Convert.FromBase64String(downloadFile.message);
            }
            catch (Exception Ex)
            {
				downloadSignedFileInfo.error = $"\r\n{Ex.Message}\r\n{Ex.InnerException?.Message}\r\n{Ex.StackTrace}";
            }

            return downloadSignedFileInfo;
        }

        private static string GetCreateProcessContentBody(string email, string process_name)
        {
            return string.Format(@"
				{{
					""email"":		   ""{0}"",
					""process_name"":  ""{1}""
				}}",
                email,
                process_name);
        }

        private static string GetUploadQueryString(TipoFirma typeFirma, bool isChild, bool flMarcaTemporale, bool isNote, int? page, double? bottom, double? left, double? w, double? h)
        {
            // file				(obbligatorio)	che non può essere nullo, deve essere un oggetto di tipo MultipartFile che corrisponde al documento che si vuole allegare al processo.
            // typeFirma		(obbligatorio)	i valori possibili sono: “PADES”, "GRAPHIC", "REQUIRED", “XADES”, “CADES” (default nel caso in cui il valore specificato non sia ritenuto valido)
            // isChild			(obbligatorio)	Se il valore è settato a "true" il file viene inserito come figlio del primo file caricato nel processo. Il primo file caricato quindi deve essere sempre il padre (se esiste) e non potrà mai avere isChild =true.
            // flMarcaTemporale (obbligatorio)	Se il valore è settato a “true” il documento verrà firmato apponendo una marca temporale.
            // isNote							Da settare a true se si intende caricare il file come "file nota". Questo tipo di file serve solamente per dare indicazioni all'utente firmatario, ma non viene firmato all'interno del processo. Ogni processo di firma può avere uno e uno solo file di nota, ogni nuovo "file  nota" sovrascrive quello caricato precedentemente.
            // signature_page					Il valore indica la pagina dove apporre la nuova firma grafica (valido solo se vengono valorizzati tutti i seguenti campi: signature_page, signature_bottom, signature_left, signature_width, signature_height)
            // signature_bottom					Il valore indica la posizione a partire dal fondo della pagina dove apporre la nuova firma grafica (valido solo se vengono valorizzati tutti i seguenti campi: signature_page, signature_bottom, signature_left, signature_width, signature_height)
            // signature_left					Il valore indica la posizione a partire dal lato sinistro della pagina dove apporre la nuova firma grafica (valido solo se vengono valorizzati tutti i seguenti campi: signature_page, signature_bottom, signature_left, signature_width, signature_height)
            // signature_width					Il valore indica la larghezza della nuova firma grafica (valido solo se vengono valorizzati tutti i seguenti campi: signature_page, signature_bottom, signature_left, signature_width, signature_height)
            // signature_height					Il valore indica la altezza della nuova firma grafica  (valido solo se vengono valorizzati tutti i seguenti campi: signature_page, signature_bottom, signature_left, signature_width, signature_heigh

            // es: 'https://unina2.webfirma.pp.cineca.it:443/my-web-firma/api/public/upload/asdadad?typeFirma=PADES&isChild=true&flMarcaTemporale=true&isNote=true&signature_page=1&signature_bottom=10&signature_left=10&signature_width=100&signature_height=100'

            string ret = $"typeFirma={typeFirma.ToString()}&isChild={(isChild ? "true" : "false")}&flMarcaTemporale={(flMarcaTemporale ? "true" : "false")}&isNote={(isNote ? "true" : "false")}";

            if (page != null)
                ret += $"&signature_page={page.ToString()}";

            if (bottom != null)
                ret += $"&signature_bottom={bottom.ToString()}";

            if (left != null)
                ret += $"&signature_left={left.ToString()}";

            if (w != null)
                ret += $"&signature_width={w.ToString()}";

            if (h != null)
                ret += $"&signature_height={h.ToString()}";

            return ret;
        }

        // ==============================================================
        // GET
        // ==============================================================
        private static T Get<T>(out string msg, out bool success, object[] param = null, string contentBody = null) where T : IApiModel<T>, new()
        {
            // Get List form Api of Type T
            T api = apiManager.GetApi<T>(out msg, out success, param, contentBody);

            // Return the list
            return api;
        }

        public static async Task<string> UploadPDFFileAsync(string uploadQryString, string processToken, byte[] byteStream, string pdfName)
        {
            Upload api = new Upload();
            string service = api.getService();
            string apiMethod = api.getMethod();
            string method = string.Format(apiMethod, processToken, uploadQryString);
            string clientUrl = common.api_url + service + method;

            string multipartBoundary = MultipartUtility.GenerateBoundary();

            var request = WebRequest.CreateHttp(new Uri(clientUrl));
            request.Method = "POST";
            request.ContentType = $"multipart/form-data; boundary={multipartBoundary}";
            request.Headers["Authorization"] = $"Basic {Convert.ToBase64String(Encoding.ASCII.GetBytes($"{common.auth_username}:{common.auth_password}"))}";
            request.Accept = "application/json";

            ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };

            bool sendResult = await MultipartUtility.SendFileAsync(byteStream, pdfName, request, multipartBoundary);

            if (!sendResult)
                return null;

            try
            {
                var response = (HttpWebResponse)await request.GetResponseAsync();
                var reader = new StreamReader(response.GetResponseStream());
                var resultString = await reader.ReadToEndAsync();

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    api = JsonConvert.DeserializeObject<Upload>(resultString);
                    return api.message;
                }
            }
            catch (Exception Ex)
            {
                return null;
            }

            return null;
        }
    }

    static class MultipartUtility
    {
        private const string LINE_FEED = "\r\n";

        public static string GenerateBoundary()
        {
            return Guid.NewGuid().ToString();
        }

        public static async Task<bool> SendFileAsync(byte[] byteStream, string pdfName, HttpWebRequest request, string boundary)
        {
            try
            {
                var requestStream = await request.GetRequestStreamAsync();
                var writer = new StreamWriter(requestStream, Encoding.UTF8);

                // Write file metadata
                writer.Write($"--{boundary}{LINE_FEED}");
                writer.Write($"Content-Disposition: form-data; name=\"file\"; filename=\"{pdfName}\"{LINE_FEED}");
                writer.Write($"Content-Type: application/pdf{LINE_FEED}");
                writer.Write($"Content-Transfer-Encoding: binary{LINE_FEED}{LINE_FEED}");
                writer.Flush();

				// Write file content
				string fileName = AppDomain.CurrentDomain.BaseDirectory + "Uploads\\" + Guid.NewGuid().ToString() + "_" + pdfName;
				using (FileStream fileStreamWrite = new FileStream(fileName, FileMode.Create, FileAccess.Write))
				{
					fileStreamWrite.Write(byteStream, 0, byteStream.Length);
				}

				var fileInfo = new FileInfo(fileName);
				var fileStream = fileInfo.OpenRead();
                await fileStream.CopyToAsync(requestStream);

                // Close file part
                writer.Write(LINE_FEED);
                writer.Write($"--{boundary}--{LINE_FEED}");
                writer.Flush();

                return true;
            }
            catch (Exception Ex)
            {
                return false;
            }
        }
    }
}
