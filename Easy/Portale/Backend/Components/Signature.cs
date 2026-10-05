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

using Spire.Pdf;
using Spire.Pdf.Graphics;
using Spire.Pdf.License;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Security.Cryptography;
using System.Xml.Linq;

namespace Backend.Components
{
    public static class Signature
    {
        public static byte[] PdfAggiungiFincatura(out string error,
                                                      string spirePdfLicenseKey,                // chiave di licenza Spire.PDF
                                                      byte[] Pdf,                               // pdf originale
                                                      string Text,                              // "Fincatura Eseguita da ..."
                                                 BoxPosition Position,                          // BoxPosition.TopRight
                                                       float margin,                            // 20f
                                                      string baseFont,                          // 12f
                                                       float fontSize,                          // 12f
                                                         int putOnPageNumber)                   // 1
        {
            error = null;

            LicenseProvider.SetLicenseKey(spirePdfLicenseKey);

            try
            {
                using (var input = new MemoryStream(Pdf))
                using (var output = new MemoryStream())
                {
                    // Doc
                    PdfDocument doc = new PdfDocument();
                    doc.LoadFromStream(input);

                    // Pagina Fincatura
                    if (putOnPageNumber < 1 || putOnPageNumber > doc.Pages.Count)
                        throw new ArgumentOutOfRangeException(nameof(putOnPageNumber), "putOnPageNumber exceeds number of pages.");
                    PdfPageBase page = doc.Pages[putOnPageNumber - 1];

                    // Font
                    string fontName = string.IsNullOrWhiteSpace(baseFont) ? "Arial" : baseFont;
                    PdfTrueTypeFont font = new PdfTrueTypeFont(
                        new Font(fontName, fontSize, FontStyle.Regular),
                        true
                    );

                    // Spire è 0-based
                    PdfCanvas canvas = page.Canvas;

                    string text = Text ?? string.Empty;

                    // Misura testo
                    SizeF textSize = font.MeasureString(text);

                    float padding = 4f;
                    float rectWidth = textSize.Width + padding * 2f;
                    float rectHeight = textSize.Height + padding * 2f;

                    float pageWidth = canvas.ClientSize.Width;
                    float pageHeight = canvas.ClientSize.Height;

                    float x = 0f, y = 0f;
                    float rotation = 0f;

                    switch (Position)
                    {
                        case BoxPosition.TopLeft:
                            x = margin;
                            y = margin;
                            break;

                        case BoxPosition.TopRight:
                            x = pageWidth - margin - rectWidth;
                            y = margin;
                            break;

                        case BoxPosition.BottomLeft:
                            x = margin;
                            y = pageHeight - margin - rectHeight;
                            break;

                        case BoxPosition.BottomRight:
                            x = pageWidth - margin - rectWidth;
                            y = pageHeight - margin - rectHeight;
                            break;

                        case BoxPosition.LeftMiddle:
                            x = margin - (rectWidth / 2f);
                            y = (pageHeight / 2f) - (rectHeight / 2f);
                            rotation = 270f;
                            break;

                        case BoxPosition.RightMiddle:
                            x = pageWidth - margin - (rectWidth / 2f);
                            y = (pageHeight / 2f) - (rectHeight / 2f);
                            rotation = 90f;
                            break;
                    }

                    PdfGraphicsState state = canvas.Save();

                    // Testo centrato con rotazione opzionale
                    float centerX = x + rectWidth / 2f;
                    float centerY = y + rectHeight / 2f;

                    if (Math.Abs(rotation) > 0.001f)
                    {
                        canvas.TranslateTransform(centerX, centerY);
                        canvas.RotateTransform(rotation);
                        canvas.TranslateTransform(-centerX, -centerY);
                    }

                    // Rettangolo (non ruotato)
                    var pen = new PdfPen(PdfBrushes.Red, 1f);
                    canvas.DrawRectangle(pen, x, y, rectWidth, rectHeight);

                    var format = new PdfStringFormat(PdfTextAlignment.Center, PdfVerticalAlignment.Middle);
                    var rect = new RectangleF(x, y, rectWidth, rectHeight);

                    page.Canvas.DrawString(
                        Text,
                        font,
                        PdfBrushes.Red,
                        rect,
                        format
                    );

                    canvas.Restore(state);


                    doc.SaveToStream(output);
                    doc.Close();

                    return output.ToArray();
                }
            }
            catch (Exception ex)
            {
                error = ex.Message + "\r\n" + ex.InnerException?.Message + "\r\n" + ex.StackTrace;
                return null;
            }
        }

        /// <summary>
        /// Crea la SegnaturaInformatica (v3.0) secondo segnatura_protocollo.xsd.
        /// Nota: la firma (ds:Signature) viene lasciata come placeholder; verrà generata dal componente di firma XAdES.
        /// </summary>
        public static string CreaSegnatura(
            // Identificatore
            string codiceAmministrazioneIPA,        // il codice IPA dell'amministrazione
            string codiceAooIPA,                    // il codice IPA dell'AOO
            string codiceRegistro,                  // il codice del Registro
            string numeroRegistrazione,             // il progressivo di protocollo
            string dataRegistrazione,               // la data di registrazione

            // Intestazione
            string oggetto,                         // sintesi dei contenuti di carattere giuridico, amministrativo e narrativo di un documento 
            string classificaDenominazione,         // una descrizione della classificazione attribuita

            // Mittente
            string mittDenominazione,               // Denominazione Amministrazione Mittente
            string mittCodiceIpaAmministrazione,    // Codice IPA Amministrazione Mittente

            // Destinatari
            string destDenominazione,               // Denominazione Amministrazione Destinatario
            string destCodiceIpaAmministrazione,    // Codice IPA Amministrazione Destinatario

            // Documento primario
            string nomeFilePdf,                     // nome del file PDF
            byte[] pdfFincato                   // contenuto del file PDF fincato
        )
        {
            XNamespace prot = "http://www.agid.gov.it/protocollo/";
            XNamespace ds = "http://www.w3.org/2000/09/xmldsig#";

            string hashPdfFincatoString = "";
            if (pdfFincato != null)
            {
                byte[] hashPdfFincato = CalcolaSha256(pdfFincato);
                hashPdfFincatoString = hashPdfFincato == null ? "" : Convert.ToBase64String(hashPdfFincato);
            }

            var doc = new XDocument(
                new XDeclaration("1.0", "UTF-8", null),
                new XElement(prot + "SegnaturaInformatica",                                                                 // SegnaturaInformatica
                    new XAttribute("versione", "3.0"),                                                                      //   ├── Versione
                    new XElement(prot + "Intestazione",                                                                     //   ├── Intestazione
                        new XElement(prot + "Identificatore",                                                               //   │     ├── Identificatore
                            new XElement(prot + "CodiceAmministrazione",                codiceAmministrazioneIPA),          //   │     │     ├── CodiceAmministrazione
                            new XElement(prot + "CodiceAOO",                            codiceAooIPA),                      //   │     │     ├── CodiceAOO
                            new XElement(prot + "CodiceRegistro",                       codiceRegistro),                    //   │     │     ├── CodiceRegistro
                            new XElement(prot + "NumeroRegistrazione",                  numeroRegistrazione),               //   │     │     ├── NumeroRegistrazione
                            new XElement(prot + "DataRegistrazione",                    dataRegistrazione)                  //   │     │     └── DataRegistrazione
                        ),                                                                                                  //   │     │
                        new XElement(prot + "Oggetto",                                  oggetto),                           //   │     ├── Oggetto
                        new XElement(prot + "Classifica",                                                                   //   │     └── Classifica
                            new XElement(prot + "Denominazione",                        classificaDenominazione)            //   │            └── Denominazione
                        )                                                                                                   //   │
                    ),                                                                                                      //   │
                    new XElement(prot + "Descrizione",                                                                      //   ├── Descrizione
                        new XElement(prot + "Mittente",                                                                     //   │     ├── Mittente
                            new XElement(prot + "Amministrazione",                                                          //   │     │     └── Amministrazione
                                new XElement(prot + "DenominazioneAmministrazione",     mittDenominazione),                 //   │     │           ├── DenominazioneAmministrazione
                                new XElement(prot + "CodiceIPAAmministrazione",         mittCodiceIpaAmministrazione)       //   │     │           └── CodiceIPAAmministrazione
                            )                                                                                               //   │     │
                        ),                                                                                                  //   │     │
                        new List<XElement>() {                                                                              //   │     │
                            new XElement(prot + "Destinatario",                                                             //   │     ├── Destinatario
                                new XElement(prot + "Amministrazione",                                                      //   │     │     └── Amministrazione
                                    new XElement(prot + "DenominazioneAmministrazione", destDenominazione),                 //   │     │           ├── DenominazioneAmministrazione
                                    new XElement(prot + "CodiceIPAAmministrazione",     destCodiceIpaAmministrazione)       //   │     │           └── CodiceIPAAmministrazione
                                )                                                                                           //   │     │
                            )                                                                                               //   │     │
                        },                                                                                                  //   │     │
                        new XElement(prot + "DocumentoPrimario",                                                            //   │     └── DocumentoPrimario
                            new XAttribute("nomeFile", nomeFilePdf),                                                        //   │           ├── nomeFile
                            new XAttribute("mimeType", "application/pdf"),                                                  //   │           ├── mimeType
                            new XElement(prot + "Impronta",                                                                 //   │           └── Impronta
                                new XAttribute("algoritmo", "SHA-256"),                                                     //   │                 ├── algoritmo
                                hashPdfFincatoString                                                                            //   │                 └── pdfFincato
                            )                                                                                               //   │
                        )                                                                                                   //   │
                    ),                                                                                                      //   │
                    new XElement(ds + "Signature")                                                                          //   └── Signatura (Placeholder)
                )
            );

            return doc.ToString(SaveOptions.DisableFormatting);
        }

        public static byte[] CalcolaSha256(byte[] data)
        {
            using (SHA256 sha = SHA256.Create())
            {
                return sha.ComputeHash(data);
            }
        }

        public static string fincText(int numprot, string testo, string protkind, DateTime dataProtocollazione)
        {
            return $"Prot. num {numprot} del {(dataProtocollazione.ToString("d"))}{(string.IsNullOrEmpty(testo) ? "" : ", " + testo)}{(string.IsNullOrEmpty(protkind) ? "" : ", " + protkind)}";
        }
    }

    public enum BoxPosition
    {
        TopLeft,
        TopRight,
        BottomLeft,
        BottomRight,
        LeftMiddle,   // lato lungo sinistro, testo verticale
        RightMiddle   // lato lungo destro, testo verticale
    }
}