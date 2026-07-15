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

using Backend.CommonBackend;
using Backend.Components;
using Backend.Extensions;
using Newtonsoft.Json.Linq;
using System;
using System.Data;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Configuration;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Backend.Controllers
{
    public class AggiungiFincaturaRequest
    {
        public string NomeFile { get; set; }                            // PDF originale
        public byte[] Pdf { get; set; }                                 // PDF originale
        public string Text { get; set; }                                // Testo da scrivere nel riquadro
        public string codiceAmministrazioneIPA { get; set; }            // Codice Amministrazione IPA
        public string codiceAooIPA { get; set; }                        // Codice Aoo IPA
        public string CodiceRegistro { get; set; }                      // Codice Registro
        public string NumeroRegistrazione { get; set; }                 // Numero Registrazione
        public string oggetto { get; set; }                             // Oggetto
        public string classificaDenominazione { get; set; }             // Classificazione
        public string mittDenominazione { get; set; }                   // Mittente Denominazione
        public string mittCodiceIpaAmministrazione { get; set; }        // Mittente Codice Ipa Amministrazione
        public string destDenominazione { get; set; }                   // Destinatario Denominazione
        public string destCodiceIpaAmministrazione { get; set; }        // Destinatario Codice Ipa Amministrazione
        public BoxPosition? fincaturaPosition { get; set; }             // Posizione Fincatura
        public int? fincaturaPutOnPageNumber { get; set; }              // Pagina su cui mettere la fincatura
    }

    /// </remarks>
    [RoutePrefix("pdfutil"), EnableCors("*", "*", "*")]
    public class PdfUtilController : ApiController
    {

        [HttpPost, Route("FincHashSign")]
        public HttpResponseMessage FincHashSign([FromBody] AggiungiFincaturaRequest request)
        {
            if (request == null || request.Pdf == null || request.Pdf.Length == 0)
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "PDF non valido.");

            if (string.IsNullOrWhiteSpace(request.NomeFile))
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Nome File mancante.");

            if (string.IsNullOrWhiteSpace(request.Text))
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Testo Fincatura mancante.");

            // ==============================================================================
            // Parametri Fincatura from web.config
            // ==============================================================================
            BoxPosition fincaturaPosition = BoxPosition.TopRight;
            float fincaturaMargin = 20f;
            string fincaturaBaseFont = "Helvetica";
            float fincaturaFontSize = 12f;
            int fincaturaPutOnPageNumber = 1;

            if (request.fincaturaPosition.HasValue)
                fincaturaPosition = request.fincaturaPosition.Value;

            if (request.fincaturaPutOnPageNumber.HasValue)
                fincaturaPutOnPageNumber = request.fincaturaPutOnPageNumber.Value;

            // ==============================================================================
            // Parametri Segnatura from web.config
            // ==============================================================================
            string codiceAmministrazioneIPA =       request.codiceAmministrazioneIPA;
            string codiceAooIPA =                   request.codiceAooIPA;

            string codiceRegistro =                 request.CodiceRegistro;
            string numeroRegistrazione =            request.NumeroRegistrazione;

            // Data Registrazione
            string dataRegistrazione =              DateTime.Now.Date.ToString("yyyy-MM-dd");

            // Intestazione
            string oggetto =                        request.oggetto;
            string classificaDenominazione =        request.classificaDenominazione;

            // Mittente/Destinatari (qui modello minimo: Amministrazione)
            string mittDenominazione =              request.mittDenominazione;
            string mittCodiceIpaAmministrazione =   request.mittCodiceIpaAmministrazione;
            string destDenominazione =              request.destDenominazione;
            string destCodiceIpaAmministrazione =   request.destCodiceIpaAmministrazione;

            // ==============================================================================
            // Parametri Segnatura from istituto princ
            // ==============================================================================
            var dispatcher = HttpContext.Current.getDataDispatcher();
            DataTable virtualuser = dispatcher.conn.RUN_SELECT("virtualuser", "*", null, null, null, false);
            if (virtualuser.Rows.Count > 0)
                codiceAmministrazioneIPA = virtualuser.Rows[0]["codiceammipa"].ToString();

            string error = "";

            if (string.IsNullOrWhiteSpace(codiceAmministrazioneIPA))        error += "codiceAmministrazioneIPA obbligatorio. ";
            if (string.IsNullOrWhiteSpace(codiceAooIPA))                    error += "codiceAooIPA obbligatorio. ";
            if (string.IsNullOrWhiteSpace(codiceRegistro))                  error += "codiceRegistro obbligatorio. ";
            if (string.IsNullOrWhiteSpace(numeroRegistrazione))             error += "numeroRegistrazione obbligatorio. ";
            if (string.IsNullOrWhiteSpace(oggetto))                         error += "oggetto obbligatorio. ";
            if (string.IsNullOrWhiteSpace(classificaDenominazione))         error += "classificaDenominazione obbligatoria. ";
            if (string.IsNullOrWhiteSpace(mittDenominazione))               error += "mittDenominazione obbligatoria. ";
            if (string.IsNullOrWhiteSpace(mittCodiceIpaAmministrazione))    error += "mittCodiceIpaAmministrazione obbligatorio. ";
            if (string.IsNullOrWhiteSpace(destDenominazione))               error += "destDenominazione obbligatoria. ";
            if (string.IsNullOrWhiteSpace(destCodiceIpaAmministrazione))    error += "destCodiceIpaAmministrazione obbligatorio. ";

            if (error != "")
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, error);

            // ==============================================================================
            // FINCATURA - Aggiungo la fincatura grafica al PDF
            // ==============================================================================
            string spirePdfLicenseKey = "";
            DataTable conf_pdf = dispatcher.conn.RUN_SELECT("app_config", "param", null, "code = 'SPIRE_PDF_LICENSE_KEY'", null, false);
            if (conf_pdf.Rows.Count > 0)
                spirePdfLicenseKey = conf_pdf.Rows[0]["param"].ToString();

            byte[] pdfFincato = Signature.PdfAggiungiFincatura(out error,
                                                                   spirePdfLicenseKey,
                                                                   request.Pdf,
                                                                   request.Text,
                                                                   fincaturaPosition,
                                                                   fincaturaMargin,
                                                                   fincaturaBaseFont,
                                                                   fincaturaFontSize,
                                                                   fincaturaPutOnPageNumber);

            // Check error
            if (!string.IsNullOrEmpty(error))
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, error);

            // ==============================================================================
            // Segnatura XML
            // ==============================================================================
            string segnaturaXml = Signature.CreaSegnatura(
                codiceAmministrazioneIPA,
                codiceAooIPA,
                codiceRegistro,
                numeroRegistrazione,
                dataRegistrazione,
                oggetto,
                classificaDenominazione,
                mittDenominazione,
                mittCodiceIpaAmministrazione,
                destDenominazione,
                destCodiceIpaAmministrazione,
                request.NomeFile,
                pdfFincato);

            return Request.CreateResponse(HttpStatusCode.OK, segnaturaXml, "application/xml");
        }
    }
}