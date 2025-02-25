
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


using System.Net;
using System.Web.Http;
using System.Web.Http.Cors;
using System;
using System.Threading.Tasks;
using FirmaRemotaUsign;

namespace Backend.Controllers
{
    /// <summary>
    /// Controller contenente le primitive necessarie per la gestione delle funzioni di admin
    /// </summary>
    /// <remarks>
    /// Il percorso (URL) per accedere ai metodi contenuti in questo controller devono avere il prefisso "/admin".
    /// </remarks>
    [RoutePrefix("signature"), AllowAnonymous, EnableCors("*", "*", "*")]
    public class SignatureController : ApiController
    {
		// ========================================================================================================================
		//                                       ¦¦¦¦¦   ¦¦¦¦¦¦   ¦¦   ¦¦  ¦¦¦¦¦¦    ¦¦¦¦¦
		//                                      ¦¦   ¦¦  ¦¦   ¦¦  ¦¦   ¦¦  ¦¦   ¦¦  ¦¦   ¦¦
		//                                      ¦¦¦¦¦¦¦  ¦¦¦¦¦¦   ¦¦   ¦¦  ¦¦¦¦¦¦   ¦¦¦¦¦¦¦
		//                                      ¦¦   ¦¦  ¦¦   ¦¦  ¦¦   ¦¦  ¦¦   ¦¦  ¦¦   ¦¦
		//                                      ¦¦   ¦¦  ¦¦   ¦¦   ¦¦¦¦¦   ¦¦¦¦¦¦   ¦¦   ¦¦
		// ========================================================================================================================
		public class SignData
        {
            public Byte[] byteStream { get; set; }
            public string username { get; set; }
            public string password { get; set; }
            public string otp { get; set; }
            public string type { get; set; }
            public string signServer { get; set; }
        }

        /// <summary>
        /// stream: byte array of the file
        /// username: aruba username
        /// password: aruba password
        /// otp: aruba otp
        /// type: "P" = PAdES (pdf), "C" = CAdES (p7m)=
        /// </summary>
        /// <param name="byteStream"></param>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="otp"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        [HttpPost, Route("signFileAruba")]
        public IHttpActionResult signFileAruba([FromBody] SignData prms)
        {
            string error = "";

            byte[] outStream = FirmaRemotaAruba.SignService.signFileAruba(prms.byteStream, prms.username, prms.password, prms.otp, prms.type, out error);
            
            if (!string.IsNullOrEmpty(error))
                return Content(HttpStatusCode.OK, error);

            return Content<byte[]>(HttpStatusCode.OK, outStream);
		}

		// ========================================================================================================================
		//                                      ¦¦   ¦¦  ¦¦¦¦¦¦¦  ¦¦   ¦¦¦¦¦¦   ¦¦   ¦¦
		//                                      ¦¦   ¦¦  ¦¦       ¦¦  ¦¦      	¦¦¦	 ¦¦
		//                                      ¦¦   ¦¦  ¦¦¦¦¦¦¦  ¦¦  ¦¦   ¦¦¦	¦¦ ¦ ¦¦
		//                                      ¦¦   ¦¦       ¦¦  ¦¦  ¦¦    ¦¦	¦¦  ¦¦¦
		//                                       ¦¦¦¦¦   ¦¦¦¦¦¦¦  ¦¦   ¦¦¦¦¦¦ 	¦¦	 ¦¦
		// ========================================================================================================================

		// ===========================================
		// FASE 1 - CREATE PROCESS
		// ===========================================
		public class CreateProcessDataUsign
		{
			public string email { get; set; }
		}

		[HttpPost, Route("createProcessUSign")]
		public async Task<IHttpActionResult> createProcessUSign([FromBody] CreateProcessDataUsign prms)
		{			
			FirmaRemotaUsign.UsignCreateProcessInfo usignCreateProcessInfo = await FirmaRemotaUsign.SignService.createProcessUSign(prms.email);

			return Content<FirmaRemotaUsign.UsignCreateProcessInfo>(HttpStatusCode.OK, usignCreateProcessInfo);
		}

		// ===========================================
		// FASE 2 - UPLOAD FILE
		// ===========================================
		public class UploadFileDataUSign
		{
			public string token { get; set; }
			public string fileName { get; set; }
			public byte[] byteStream { get; set; }
		}

		[HttpPost, Route("uploadFileUSign")]
        public async Task<IHttpActionResult> uploadFileUSign([FromBody] UploadFileDataUSign prms)
        {
			
			FirmaRemotaUsign.UsignUploadFileInfo usignUploadFileInfo = await FirmaRemotaUsign.SignService.uploadFileUSign(prms.token, prms.byteStream, prms.fileName.Replace(".xlsx", ".pdf"), true);
			
			return Content<FirmaRemotaUsign.UsignUploadFileInfo>(HttpStatusCode.OK, usignUploadFileInfo);
		}

		// ===========================================
		// FASE 3 - SEND OTP
		// ===========================================
		public class SendOtpDataUSign
		{
			public string token { get; set; }
		}

		[HttpPost, Route("sendOtpUSign")]
		public async Task<IHttpActionResult> sendOtpUSign([FromBody] SendOtpDataUSign prms)
		{

			FirmaRemotaUsign.UsignSendOtpInfo usignSendOtpInfo = await FirmaRemotaUsign.SignService.sendOtpUSign(prms.token);

			return Content<FirmaRemotaUsign.UsignSendOtpInfo>(HttpStatusCode.OK, usignSendOtpInfo);
		}

		// ===========================================
		// FASE 4 - DOWNLOAD SIGNED FILE
		// ===========================================
		public class SignDataUsign
		{
			public string token { get; set; }
			public string fileId { get; set; }
			public string pin { get; set; }
			public string otp { get; set; }
		}

		[HttpPost, Route("downloadSignedFileUSign")]
		public async Task<IHttpActionResult> downloadSignedFileUSign([FromBody] SignDataUsign usignInfo)
		{
			FirmaRemotaUsign.DownloadSignedFileInfo downloadSignedFileInfo = await FirmaRemotaUsign.SignService.downloadSignedFileUSign(usignInfo.token, usignInfo.fileId, usignInfo.pin, usignInfo.otp);

			return Content<FirmaRemotaUsign.DownloadSignedFileInfo>(HttpStatusCode.OK, downloadSignedFileInfo);
		}

		//[HttpPost, Route("uploadFileUSign")]
		//public async Task<IHttpActionResult> uploadFileUSign([FromBody] uploadFileUSignParams prms)
		//{
		//	// ===========================================
		//	// FASE 1 - CREATE PROCESS
		//	// ===========================================
		//	FirmaRemotaUsign.UsignCreateProcessInfo usignCreateProcessInfo = await FirmaRemotaUsign.SignService.createProcessUSign(prms.email);

		//	// Check
		//	if (!string.IsNullOrEmpty(usignCreateProcessInfo.error))
		//		return Content(HttpStatusCode.OK, usignCreateProcessInfo.error);

		//	// ===========================================
		//	// FASE 2 - UPLOAD FILE
		//	// ===========================================
		//	FirmaRemotaUsign.UsignUploadFileInfo usignUploadFileInfo = await FirmaRemotaUsign.SignService.uploadFileUSign(usignCreateProcessInfo.token, prms.byteStream, prms.fileName.Replace(".xlsx", ".pdf"), true);

		//	// Check
		//	if (!string.IsNullOrEmpty(usignUploadFileInfo.error))
		//		return Content(HttpStatusCode.OK, usignUploadFileInfo.error);

		//	// ===========================================
		//	// FASE 3 - SEND OTP
		//	// ===========================================
		//	FirmaRemotaUsign.UsignSendOtpInfo usignSendOtpInfo = await FirmaRemotaUsign.SignService.sendOtpUSign(usignCreateProcessInfo.token);

		//	// Check
		//	if (!string.IsNullOrEmpty(usignSendOtpInfo.error))
		//		return Content(HttpStatusCode.OK, usignSendOtpInfo.error);

		//	return Content<string>(HttpStatusCode.OK, usignUploadFileInfo.fileId);
		//}
	}

 //   public class uploadFileUSignParams
	//{
 //       public string fileName { get; set; }
 //       public byte[] byteStream { get; set; }
 //       public string email { get; set; }
 //   }
}
