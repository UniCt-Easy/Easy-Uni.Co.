
/*
Easy
Copyright (C) 2022 Università degli Studi di Catania (www.unict.it)
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


using PdfSharp.Drawing;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;
using System.Drawing.Drawing2D;
using ZXing;

namespace pagoPaService.Utils {

    public static class BollettiniPdf {
        /// <summary>
        /// Adatta l'immagine alle dimensioni richieste
        /// </summary>
        /// <remarks>Massimo 33x33mm.</remarks>
        /// <param name="codice">Codice QR.</param>
        public static Bitmap resizeBitmap(Bitmap src, int dpi, int widthMM, int heightMM) {

            var width = BollettiniPdf.pixelsFromMm(dpi, widthMM);
            var height = BollettiniPdf.pixelsFromMm(dpi, heightMM);

            var dest = new Bitmap(width, height);
            dest.SetResolution(dpi, dpi);
            using (var gfx = Graphics.FromImage(dest)) {
                gfx.InterpolationMode = InterpolationMode.HighQualityBicubic;
                gfx.SmoothingMode = SmoothingMode.HighQuality;
                gfx.PixelOffsetMode = PixelOffsetMode.HighQuality;
                gfx.CompositingQuality = CompositingQuality.HighQuality;
                gfx.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
                var srcRect = new Rectangle(0, 0, src.Width, src.Height);
                var destRect = new Rectangle(0, 0, dest.Width, dest.Height);
                gfx.DrawImage(src, destRect, srcRect, GraphicsUnit.Pixel);

                gfx.Save();
            }            

            return dest;
        }


        /// <summary>
        /// Adatta l'immagine del logo alle specifiche.
        /// </summary>
        /// <remarks>Massimo 76x22mm.</remarks>
        /// <param name="logo">Logo.</param>
        /// <param name="widthMm">width mm</param>
        /// <param name="heightMm">height mm</param>
        public static XImage GetLogo(byte[] logo, int widthMm, int heightMm) {
            var stream = new MemoryStream(logo);
            var src = Image.FromStream(stream);

            var width = pixelsFromMm(300, widthMm);
            var height = pixelsFromMm(300, heightMm);
            //L'immagine che voglio creare deve avere questa dimensione 
            var dest = new Bitmap(width, height);
            dest.SetResolution(300, 300);

            var ratio = Math.Min((double)dest.Width / (double)src.Width, (double)dest.Height / (double)src.Height);

            using (var gfx = Graphics.FromImage(dest)) {
                gfx.InterpolationMode = InterpolationMode.HighQualityBicubic;
                gfx.SmoothingMode = SmoothingMode.AntiAlias;
                gfx.PixelOffsetMode = PixelOffsetMode.HighQuality;
                gfx.CompositingQuality = CompositingQuality.HighQuality;
                gfx.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
                var srcRect = new Rectangle(0, 0, src.Width, src.Height);
                var destRect = new Rectangle(0, 0, (int)(src.Width * ratio), (int)(src.Height * ratio));
                gfx.DrawImage(src, destRect, srcRect, GraphicsUnit.Pixel);

                gfx.Save();
            }

            stream.Close();
               
            return XImage.FromGdiPlusImage(dest);
        }

        

        /// <summary>
        /// Rendering del codice EAN immesso nel parametro text. Altezza e Larghezza del codice QR sono definiti
        /// nei parametri height e width. 
        /// La stringa di input text viene formattata secondo le specifiche derivate dal documento 
        /// http://www.agid.gov.it/sites/default/files/regole_tecniche/guidatecnica_avvisoanalogico_1_0_1_0.pdf
        /// 
        /// Per la rappresentazione del bar-code legato a questa tipologia di pagamenti si potrà fare
        /// riferimento alla codifica C del Codice 128 che presuppone la presenza di soli dati numerici.
        /// 
        /// Gli AI richiesti dal documento sono:
        /// 415     - Identifica il GS1 Global Location Number (GLN) dell’amministrazione. [Formato n3+n13]
        /// 8002    - Numero dell'avviso di pagamento. [Formato n4+n18]
        /// 3902    - Identifica l’importo da pagare, espresso nella valuta di riferimento, riportato
        ///           sull’avviso di pagamento emesso dall’amministrazione.
        ///           L'ultima cifra dell'AI (2) esprime il numero di cifre decimali. [Formato n4+n10]
        /// </summary>
        /// <param name="width">Larghezza del barcode</param>
        /// <param name="height">Altezza del barcode</param>
        /// <param name="text">Stringa del barcode da esporre</param>
        /// <returns></returns>
        public static Bitmap GenerateEAN(string text, int height) {
            try {

                //int height = 53;        // Le dimensioni sono espresse in pixel, 14 mm = 52.913386  pixel
                //int width = 302;        // Le dimensioni sono espresse in pixel, 80 mm = 302.362205 pixel
                //int margin = 37;        // Le dimensioni sono espresse in pixel, 10 mm = 37.795276 pixel

                // Definizione delle opzioni di codifica per barcode
                ZXing.OneD.Code128EncodingOptions eanEncodOp = new ZXing.OneD.Code128EncodingOptions {
                    Margin = 0,//margin
                    ForceCodesetB = false,
                    PureBarcode = true,
                    Height = height
                    //,Width = width
                };
                eanEncodOp.Hints.Add(EncodeHintType.CHARACTER_SET, "UTF-8");


                ZXing.BarcodeWriter eanCodeWr = new BarcodeWriter();
                eanCodeWr.Format = BarcodeFormat.CODE_128;
                eanCodeWr.Options = eanEncodOp;


                return eanCodeWr.Write(text);

            }
            catch {
                return null;
            };
        }
       
        /// <param name="codiceBarre"></param>
        /// <param name="importo"></param>
        /// <returns></returns>
        public static string GetHintCodiceBarre(string codiceBarre, decimal importo) {
            string GLN = codiceBarre.Substring(3, 13);
            string iuv = codiceBarre.Substring(20, 18);
            //string importo = codiceBarre.Substring(42);
            string simporto = FormattaImportoCodiceABarre(importo); 
            return $"(415){GLN}(8020){iuv}(3902){simporto}";
        }

        public static string FormattaImportoQRCode(decimal importo) {
            var amountNoDecimal = decimal.ToInt64(importo*100);
            //if (importo<1) return amountNoDecimal.ToString();
            string result = amountNoDecimal.ToString();
            return result;            
        }
  
        public static string FormattaImportoCodiceABarre(decimal importo) {
            var amountNoDecimal = decimal.ToInt64(importo*100);
            //if (importo<1) return amountNoDecimal.ToString();
            string result = amountNoDecimal.ToString();
            if (result.Length >= 4) return result;
            return result.PadLeft(4, '0');
        }

        /// <summary>
        /// Rendering del codice QR immesso nel parametro text. Altezza e Larghezza del codice QR sono definiti
        /// nei parametri height e width. 
        /// Nella funzione sono definite anche le Encoding Option derivate dal documento ministeriale
        /// http://www.agid.gov.it/sites/default/files/regole_tecniche/guidatecnica_avvisoanalogico_1_0_1_0.pdf
        /// </summary>
        /// <param name="width">Larghezza del codice QR</param>
        /// <param name="height">Altezza del codice QR</param>
        /// <param name="text">Testo da esporre nel codice QR</param>
        /// <returns>Bitmap contenente il codice QR se i valori sono immessi correttamente, altrimenti ritorna null </returns>
        public static Bitmap GenerateQR(string text) {

            // Parametri per la generazione del QRcode da specifiche pagoPA
            // 
            //  Symbol Version: 4
            //  Modules:        33x33
            //  Mudules width:  3 pixels
            //  ECC level:      M (correzione errore max 15 %)
            //  Character set:  UTF - 8

            try {

                //int height = 33; //;    // Le dimensioni sono espresse in pixel, 0.33 mm = 124.724409 pixel
                //int width = 33; // BollettiniPdf.pixelsFromMm(96, 33);

                // Definizione delle opzioni di codifica per QRcode
                ZXing.QrCode.QrCodeEncodingOptions qrEncodeOp = new ZXing.QrCode.QrCodeEncodingOptions {

                    QrVersion = 4,   //Symbol Version 4, imposto da AGID
                    ErrorCorrection = ZXing.QrCode.Internal.ErrorCorrectionLevel.M,  //ECC level M (correzione errore max 15%) (AGID)
                    CharacterSet = "UTF-8",             //AGID
                    Margin = 0,
                    Height = 33*3,
                    Width = 33*3,
                    PureBarcode = true
                };

                ZXing.BarcodeWriter qrCodeWr = new BarcodeWriter();
                qrCodeWr.Format = BarcodeFormat.QR_CODE;
                
                qrCodeWr.Options = qrEncodeOp;

                var qrCode = qrCodeWr.Write(text);
                return qrCode;

            }
            catch (Exception ee){

                return null;
            };
        }



        public static int pixelsFromPoints(float dpi, float points) {
            return Convert.ToInt32( Math.Round(points * dpi / 72.0f));
        }
        public static float pointsFromPixels(float dpi, int pixel) {
            return pixel * 72.0f / dpi;
        }
        public static int pixelsFromMm(float dpi, float mm) {
            return Convert.ToInt32(Math.Round(mm * dpi / 25.4f));
        }
        public static float mmFromPixels(float dpi, int pixel) {
            return pixel * 25.4f / dpi;
        }
        public static float mmFromPoints(float dpi, float points) {
            return mmFromPixels(dpi, pixelsFromPoints(dpi, points));
        }
        public static float pointsFromMm(float dpi, float mm) {
            return pointsFromPixels(dpi, pixelsFromMm(dpi, mm));
        }






        public static int pixelsFromPoints(this Graphics g, float points) {
            return Convert.ToInt32(Math.Round(points * g.DpiX / 72.0f));
        }
        public static float pointsFromPixels(this Graphics g, int pixel) {
            return pixel * 72.0f / g.DpiX;
        }
        public static int pixelsFromMm(this Graphics g, float mm) {
            return Convert.ToInt32(Math.Round(mm * g.DpiX /25.4f));
        }
        public static float mmFromPixels(this Graphics g, int pixel) {
            return pixel * 25.4f / g.DpiX;
        }
        public static float mmFromPoints(this Graphics g, float points) {
            return mmFromPixels(g, pixelsFromPoints(g,points));
        }
        public static float pointsFromMm(this Graphics g, float mm) {
            return pointsFromPixels(g,pixelsFromMm(g,mm));
        }

        public static int pixelsFromPoints(this XGraphics g, float points) {
            return Convert.ToInt32(Math.Round(points * g.Graphics.DpiX / 72.0f));
        }
        public static float pointsFromPixels(this XGraphics g, int pixel) {
            return pixel * 72.0f / g.Graphics.DpiX;
        }
        public static int pixelsFromMm(this XGraphics g, float mm) {
            return Convert.ToInt32(Math.Round(mm * g.Graphics.DpiX / 25.4f));
        }
        public static float mmFromPixels(this XGraphics g, int pixel) {
            return pixel * 25.4f / g.Graphics.DpiX;
        }
        public static float mmFromPoints(this XGraphics g, float points) {
            return mmFromPixels(g, pixelsFromPoints(g, points));
        }
        public static float pointsFromMm(this XGraphics g, float mm) {
            return pointsFromPixels(g, pixelsFromMm(g, mm));
        }
    }
    /// <summary>
    /// Utilità per la gestione degli IUV.
    /// </summary>
    public static class IUV {

        private const string PatternIso11649 = "^RF(?<checkCode>[a-zA-Z0-9]{2})(?<reference>[a-zA-Z0-9]{1,21})$";
        private const string PatternSanp = "^(?<reference>[0-9]{1,13})(?<checkCode>[0-9]{2})$";

        private static Dictionary<char, string> checkReference = new Dictionary<char, string>()
        {
            { '0', "0" },
            { '1', "1" },
            { '2', "2" },
            { '3', "3" },
            { '4', "4" },
            { '5', "5" },
            { '6', "6" },
            { '7', "7" },
            { '8', "8" },
            { '9', "9" },
            { 'A', "10" },
            { 'B', "11" },
            { 'C', "12" },
            { 'D', "13" },
            { 'E', "14" },
            { 'F', "15" },
            { 'G', "16" },
            { 'H', "17" },
            { 'I', "18" },
            { 'J', "19" },
            { 'K', "20" },
            { 'L', "21" },
            { 'M', "22" },
            { 'N', "23" },
            { 'O', "24" },
            { 'P', "25" },
            { 'Q', "26" },
            { 'R', "27" },
            { 'S', "28" },
            { 'T', "29" },
            { 'U', "30" },
            { 'V', "31" },
            { 'W', "32" },
            { 'X', "33" },
            { 'Y', "34" },
            { 'Z', "35" }
        };

        /// <summary>
        /// Calcola il check-code di una stringa secondo l'algoritmo ISO/IEC 7064
        /// </summary>
        /// <param name="reference">Stringa sulla quale effettuare il calcolo</param>
        /// <returns>Il check-code della stringa</returns>
        private static string CalcolaCheckCode(string reference) {
            StringBuilder buffer = new StringBuilder();
            reference.ToUpper().ToList().ForEach(c => buffer.Append(checkReference[c]));
            buffer.Append("271500");

            long checkCode = 98 - (long.Parse(buffer.ToString()) % 97);

            return checkCode.ToString("D2");
        }

        /// <summary>
        /// Calcola il check-code (due cifre) di uno IUV numerico secondo la SANP 1.7.0, par. 7.4.1
        /// </summary>
        /// <param name="reference">Codice di riferimento di 13 caratteri</param>
        /// <param name="auxDigit">Codice numerico ausiliario 1 carattere</param>
        /// <param name="applicationCode">Codice dell'archivio dei pagamenti in attesa  (2 caratteri)</param>
        /// <returns></returns>
        private static string CalcolaCheckCode(string reference, int auxDigit, int applicationCode) {
            StringBuilder buffer = new StringBuilder();
            reference.ToUpper().ToList().ForEach(c => buffer.Append(checkReference[c]));
            //buffer.Append("271500");

            string checkString = $"{auxDigit,1:D1}{applicationCode,2:D2}{buffer}";

            long checkCode = long.Parse(checkString) % 93;

            return checkCode.ToString("D2");
        }

        /// <summary>
        /// Effettua il controllo di un IUV secondo le specifiche ISO 11649/2009
        /// </summary>
        /// <param name="iuv">IUV da controllare</param>
        /// <returns>Vero se lo IUV è formalmente valido</returns>
        public static bool Convalida(string iuv) {
            Regex re = new Regex(PatternIso11649);

            if (re.IsMatch(iuv)) {
                Match match = re.Match(iuv);

                string checkCode = match.Groups["checkCode"].Value;
                string reference = match.Groups["reference"].Value;

                return checkCode.Equals(CalcolaCheckCode(reference));
            }

            return false;
        }

        /// <summary>
        /// Controlla un IUV secondo la SANP 1.7.0, par. 7.4.1
        /// </summary>
        /// <param name="iuv">IUV da controllare</param>
        /// <param name="auxDigit">Codice numerico ausiliario</param>
        /// <param name="applicationCode">Codice dell'archivio dei pagamenti in attesa</param>
        /// <returns></returns>
        public static bool Convalida(string iuv, int auxDigit, int applicationCode) {
            Regex re = new Regex(PatternSanp);

            if (re.IsMatch(iuv)) {
                var match = re.Match(iuv);

                var reference = match.Groups["reference"].Value;
                var checkCode = match.Groups["checkCode"].Value;

                return checkCode.Equals(CalcolaCheckCode(reference, auxDigit, applicationCode));
            }

            return false;
        }

        ///// <summary>
        ///// Genera uno IUV secondo le specifiche ISO 11649/2009
        ///// </summary>
        ///// <param name="progressivo">Numero progressivo associato allo IUV</param>
        ///// <returns>Lo IUV generato</returns>
        //public static string Genera(long progressivo) {
        //    string reference = progressivo.ToString("D15");
        //    string checkCode = CalcolaCheckCode(reference);

        //    return string.Format("RF{0}{1}", checkCode, reference);
        //}

        /// <summary>
        /// Genera uno IUV numerico secondo la specifica della SANP 1.7.0, par. 7.4.1
        /// </summary>
        /// <param name="progressivo">Numero progressivo associato allo IUV</param>
        /// <param name="auxDigit">Codice numerico ausiliario di 1 carattere</param>
        /// <param name="applicationCode">Codice dell'archivio dei pagamenti in attesa 2 caratteri</param>
        /// <returns>13 cifre del progressivo + 2 cifre di check digit</returns>
        public static string Genera(long progressivo, int auxDigit, int applicationCode) {
            string reference = progressivo.ToString("D13");
            string checkCode = CalcolaCheckCode(reference, auxDigit, applicationCode);

            return $"{reference}{checkCode}";
        }


        /// <summary>
        /// Genera uno IUV ( Numero Avviso)  numerico secondo la specifica della SANP 1.7.0, par. 7.4.1
        /// Restituisce  13 cifre del progressivo + 2 cifre di check digit
        /// </summary>
        /// <param name="progressivo">Numero progressivo associato allo IUV 13 cifre</param>
        /// <param name="auxDigit">Codice numerico ausiliario</param>
        /// <param name="applicationCode">Codice dell'archivio dei pagamenti in attesa</param>
        /// <returns>13 cifre del progressivo + 2 cifre di check digit</returns>
        public static string Genera(string reference, int auxDigit, int applicationCode) {
            string checkCode = CalcolaCheckCode(reference, auxDigit, applicationCode);
            return $"{reference}{checkCode}";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="gln">identifica il GS1 Global Location Number (GLN) dell’amministrazione. Il GLN ha
        ///    lunghezza fissa di 13 caratteri numerici ed è assegnato da Indicod-ECR.Il tredicesimo numero è un
        ///    Check-digit.
        /// </param>
        /// <param name="iuvwithchecks">massimo 18 cifre numeriche Contiene il Numero Avviso composto dalla -- DEVE essere lungo 18
        ///     concatenazione dei dati: aux,digit, application
        ///             code, codice IUV(vedi § 7.4.1 delle SANP).</param>
        /// <param name="amount">importo da pagare</param>
        /// <returns></returns>
        public static string getCodiceBarre(string gln,string iuvwithchecks, decimal amount) {
            var amountNoDecimal = BollettiniPdf.FormattaImportoCodiceABarre(amount); //decimal.ToInt64(amount*100); // amount * 100;
            return $"415{gln}8020{iuvwithchecks}3902{amountNoDecimal}";
        }

        public static string getCodiceQR(string codiceFiscaleEnte,string IUVWITHCHECKS, decimal amount) {
            var amountNoDecimal = BollettiniPdf.FormattaImportoQRCode(amount); //decimal.ToInt64(amount * 100); // amount * 100;
            return  $"PAGOPA|002|{IUVWITHCHECKS}|{codiceFiscaleEnte}|{amountNoDecimal}";
        }

    }

}
