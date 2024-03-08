
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


using Newtonsoft.Json.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Cors;
using metadatalibrary;
using System.Threading.Tasks;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Collections.Generic;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Net.Http.Headers;
using Backend.Components;
using Backend.CommonBackend;
using Backend.Extensions;
using metaeasylibrary;
using System.Data;

namespace Backend.Controllers {

    /// <inheritdoc />
    /// <summary>  Authorize or AllowAnonymous
    /// Controller per data
    /// </summary>
    [RoutePrefix("file"), Authorize, EnableCors("*", "*", "*")]
    public class FileController : ApiController {
        public static readonly string UploadPath = "Uploads/";

        ///// <summary>
        ///// Upload multiplefile in one call
        ///// <returns></returns>
        //[HttpPost, Route("upload")]
        //public IHttpActionResult upload() {

        //    var httpRequest = HttpContext.Current.Request;
        //    if (httpRequest.Files.Count > 0) {
        //        var docfiles = new List<string>();
        //        foreach (string file in httpRequest.Files) {
        //            var postedFile = httpRequest.Files[file];
        //            var filePath =
        //                AppDomain.CurrentDomain.BaseDirectory + UploadPath +
        //                postedFile.FileName; // HttpContext.Current.Server.MapPath("~/Uploads/" + postedFile.FileName);
        //            postedFile.SaveAs(filePath);
        //            docfiles.Add(filePath);
        //        }

        //        string json = JsonConvert.SerializeObject(docfiles, Formatting.Indented);
        //        return Content(HttpStatusCode.OK, json);
        //    }

        //    return Content(HttpStatusCode.BadRequest, "no file");
        //}

        /// <summary>
        /// Downloads a file, read from file system
        /// </summary>
        /// <returns></returns>
        [HttpGet, Route("download")]
        public HttpResponseMessage download(string idattach) {
            HttpResponseMessage result = null;
            var dispatcher = HttpContext.Current.getDataDispatcher();
            try {
                string fileName = "";
                var conn = dispatcher.conn;
                var filter = MetaExpression.eq("idattach", idattach);
                Dictionary<string, object> objFileName = conn.readObject("attach", filter, "filename");

                if (objFileName.Count == 1) {
                    fileName = (string) objFileName["filename"];
                    // Dato l'id recupero il nome del file
                    string path = AppDomain.CurrentDomain.BaseDirectory + UploadPath;
                    byte[] fileBytes = System.IO.File.ReadAllBytes(path + fileName);
                    result = Request.CreateResponse(HttpStatusCode.OK);
                    result.Content = new ByteArrayContent(fileBytes);
                    result.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
                    result.Content.Headers.ContentDisposition =
                        new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment");
                    result.Content.Headers.ContentDisposition.FileName = fileName;
                    result.Content.Headers.Add("Access-Control-Expose-Headers", "Content-Disposition");

                }

                return result;

            }
            catch (Exception ex) {
                return Request.CreateResponse(HttpStatusCode.Gone,
                    "Errore interno del server nel recupero file: " + ex.Message);
            }
        }

        /// <summary>
        /// Downloads logo file, read from "logo" table
        /// </summary>
        /// <returns></returns>
        [HttpGet, Route("downloadLogo")]
        public IHttpActionResult downloadLogo() {
            var dispatcher = HttpContext.Current.getDataDispatcher();
            try {
                var conn = dispatcher.conn;
                var filter = MetaExpression.eq("idlogo", "UNIV");
                Dictionary<string, object> objFileName = conn.readObject("logo", filter, "logo");

                if (objFileName.Count == 1) {
                    byte[] fileBytes = (byte[]) objFileName["logo"];
                    var res = Convert.ToBase64String(fileBytes);
                    return Content(HttpStatusCode.OK, res);
                }

                return Content(HttpStatusCode.NotFound, "");

            }
            catch (Exception ex) {
                return Content(HttpStatusCode.NotFound, ex);
            }
        }

        /// <summary>
        /// Downloads a file, read from byte[] field on table. Method compliant with windows client.
        /// </summary>
        /// <returns></returns>
        [HttpGet, Route("downloadDbField")]
        public HttpResponseMessage downloadDbField(string tableName, string filter, string columnAttach) {
            HttpResponseMessage result = null;
            var dispatcher = HttpContext.Current.getDataDispatcher();
            try {


                DataTable dt = dispatcher.conn.CreateTableByName(tableName, "*");
                var sFilter = DataUtils.getfilterFromJsDataQuery(JToken.Parse(filter), dispatcher);
                dispatcher.conn.RUN_SELECT_INTO_TABLE(dt, null, sFilter, null, true);
                if (dt.Rows.Count == 0) return result;
                DataRow row = dt.Rows[0];
                byte[] ByteArray = (byte[]) row[columnAttach];

                // write a temporary file with filename and extension
                string FilePath = AppDomain.CurrentDomain.BaseDirectory + UploadPath;
                string prefix = "SWATTACH";
                DateTime oggi_dt = DateTime.Now;
                string oggi = oggi_dt.Ticks.ToString();


                int offset = 0;
                FileStream FS = null;
                int n = 0;
                string fname = "";
                string estensione = "";
                string sw = "";
                byte[] fileBytes = null;

                try {

                    fname = AttachmentUtils.GetFileName(ByteArray);
                    estensione = Path.GetExtension(fname).Trim();
                    sw = Path.Combine(FilePath, prefix + fname + oggi.ToString() + estensione);
                    FS = new FileStream(sw, FileMode.Create, FileAccess.Write);
                    offset = AttachmentUtils.GetOffsetForData(ByteArray);
                    n = ByteArray.Length - offset;
                    if (n == 0) return result;
                }
                catch (Exception ex) {
                    if (dt.Columns.Contains("filename")) {
                        fname = (string) row["filename"];
                        estensione = fname.Substring(fname.IndexOf("."));
                        sw = Path.Combine(FilePath, prefix + fname + oggi.ToString() + estensione);
                        FS = new FileStream(sw, FileMode.Create, FileAccess.Write);
                        n = ByteArray.Length;
                    }
                    else {
                        return Request.CreateResponse(HttpStatusCode.Gone,
                            "Errore interno del server nel recupero file: " + ex.Message);
                    }

                }


                FS.Write(ByteArray, offset, n);
                FS.Close();
                fileBytes = System.IO.File.ReadAllBytes(sw);
                result = Request.CreateResponse(HttpStatusCode.OK);
                result.Content = new ByteArrayContent(fileBytes);

                // elimino file temporaneo
                System.IO.File.Delete(sw);

                result.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
                result.Content.Headers.ContentDisposition =
                    new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment");
                result.Content.Headers.ContentDisposition.FileName = fname;
                result.Content.Headers.Add("Access-Control-Expose-Headers", "Content-Disposition");
                return result;


            }
            catch (Exception ex) {
                return Request.CreateResponse(HttpStatusCode.Gone,
                    "Errore interno del server nel recupero file: " + ex.Message);
            }
        }

      

        /// <summary>
        /// Uploads a single chunck of the file sent by the client.
        /// It merges and checks if the upload is completed. if upload is terminated retrunsthe dsattach with some info on attach, manly the id assigned
        /// If the chunck is not the last and the file is not completed , then it returns empty string
        /// </summary>
        /// <returns></returns>
        [HttpPost, Route("uploadchunk")]
        public IHttpActionResult uploadChunk() {
            var httpRequest = HttpContext.Current.Request;
            var fileNameAttachOnServer = "";
            var pathFile =
                AppDomain.CurrentDomain.BaseDirectory + UploadPath; // HttpContext.Current.Server.MapPath("~/Uploads/");

            if (httpRequest.Files.Count > 0) {
                var docfiles = new List<string>();
                foreach (string file in httpRequest.Files) {
                    var FileDataContent = httpRequest.Files[file];

                    if (FileDataContent != null && FileDataContent.ContentLength > 0) {
                        // take the input stream, and save it to a temp folder using  
                        // the original file.part name posted  
                        var stream = FileDataContent.InputStream;
                        var fileName = Path.GetFileName(FileDataContent.FileName);

                        Directory.CreateDirectory(pathFile);
                        string path = Path.Combine(pathFile, fileName);
                        try {
                            if (System.IO.File.Exists(path))
                                System.IO.File.Delete(path);
                            using (var fileStream = System.IO.File.Create(path)) {
                                stream.CopyTo(fileStream);
                            }

                            // quando il pezzo di file è salvato lo unisce al  resto inviato  
                            UtilsFile UT = new UtilsFile();
                            // fileNameAttachOnServer sarà deltipo c://.../../nomefile.ext oopure vuoto se è caricamento parziale
                            fileNameAttachOnServer = UT.MergeFile(path);
                        }
                        catch (IOException ex) {
                            return Content(HttpStatusCode.BadRequest, "Error upload:" + ex.Message);
                        }
                    }
                }

                // se non ha ricevuto fileNameAttachOnServer significa che l'upload non è terminato
                if (String.IsNullOrEmpty(fileNameAttachOnServer)) {
                    return Content(HttpStatusCode.OK, "");
                }
                else {
                    // se ha ricevuto fileNameAttachOnServer significa che l'upload è completo
                    var attachTableName = "attach";
                    var dispatcher = HttpContext.Current.getDataDispatcher();
                    // creo ds attach in cui inserirò la nuova riga sulla tabella attach
                    var dsattach = DataUtils.createEmptyDataSet(attachTableName, "default");
                    var mainMeta = dispatcher.GetMeta(attachTableName);
                    // nuova riga 
                    var rattach = mainMeta.Get_New_Row(null, dsattach.Tables[attachTableName]);
                    // inserisco filename calcolato
                    rattach["filename"] = Path.GetFileName(fileNameAttachOnServer);
                    rattach["size"] = new System.IO.FileInfo(fileNameAttachOnServer).Length;

                    // salvo su DB tale informazione. counter sarà null
                    var postData = mainMeta.Get_PostData();
                    postData.initClass(dsattach, dispatcher.Connection);
                    var myMessages = postData.DO_POST_SERVICE();
                    // check se è andata male, anche se non dovrebbe mai essere
                    if (myMessages.Count > 0) {
                        EasyProcedureMessage msg = (EasyProcedureMessage) myMessages[0];
                        return Content(HttpStatusCode.BadRequest, "Error upload: " + msg.LongMess);
                    }

                    // Se invece è andata bene invio dataset con nuova riga al client.
                    // Tale riga avrà l'idattach vero, che dovrò collegare alla tabella custom con il riferimento all'allegato 
                    var jsonResDataSet = DataUtils.dataSetToJSon(dsattach, false);
                    // invio json con ds serializzato
                    return Content(HttpStatusCode.OK, jsonResDataSet);
                }
            }

            return Content(HttpStatusCode.BadRequest, "No File sent by client");

        }
    }
}
