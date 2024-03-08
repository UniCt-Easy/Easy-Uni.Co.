
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


using PdfSharp.Drawing;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using ZXing;
using pagoPaService.Utils;

namespace BancaSondrio {

    public class Bollettino {

        private MemoryStream template;
        private string _template;

        public Bollettino(string template) {
            this.template = new MemoryStream();
            this._template = template;

            if (File.Exists(template)) {
                using (var src = new FileStream(template, FileMode.Open)) {
                    src.CopyTo(this.template);
                }
            }
            else {
                throw new ArgumentException($"Il file del modello specificato ({template}) non esiste");
            }
        }

       
     
        public byte[] Genera(string ente, string destinatario, string iuv,string causaleBollettino, string note,
                        string codiceBollettino, string codicesia,  string codiceFiscaleEnte, decimal importo, DateTime scadenza, string descrizioneEnte,
                        byte []logo,string valoreCodiceBarre,string valoreCodiceQr,string Debitore, string idregDebitore, out string errore
                        ) {
            string dettErrore = "";
            try {
                errore = null;
                
                var document = PdfReader.Open(this.template);
                

                if (document.AcroForm != null) {
                    var form = document.AcroForm;

                    if (form.Elements.ContainsKey("/NeedAppearances")) {
                        form.Elements["/NeedAppearances"] = new PdfBoolean(true);
                    }
                    else {
                        form.Elements.Add("/NeedAppearances", new PdfBoolean(true));
                    }

                    var items = new Dictionary<string, string> {
                        ["dati_finestra"] = destinatario,
                        ["causale_ente"] = note,
                        ["dati_creditore"] = ente,
                        ["dati_debitore"] = Debitore,
                        ["IUV"] = iuv,
                        ["causale_RPT"] = causaleBollettino,
                        ["codice_avviso"] = codiceBollettino,
                        ["cf_creditore"] = codiceFiscaleEnte,
                        ["importo"] = $"{importo:0.00} EURO",
                        ["data_scadenza"] = $"{scadenza:dd/MM/yyyy}",
                        ["codice_debitore"] = idregDebitore,
                        ["codice_interbancario"] = codicesia
                    };
                    // GetDestinatario(debitore);
                    // Nunzio 27.03.2017 - Modificato in attesa di info.
                    //items["TestoLibero"] = "<testo libero>";
                    //string.Format("\n{0}",ente);//faccio precedere da un ritorno a capo per evitare sovrapposizione con la label
                    // string.Format("\n{0}",Debitore);  //faccio precedere da un ritorno a capo per evitare sovrapposizione con la label

                    // Nunzio 27.03.2017 - Modificato in attesa di info.
                    // items["CodiceAvviso"] = "<codice avviso>"  ;
                    // items["DescrizioneEnte"] = ente. "<campo descrittivo ente>";
                    //items["DescrizioneEnte"] = DescrizioneEnte;

                    foreach (var name in items.Keys)
                    {
                        var field = document.AcroForm.Fields[name];
                        if (field == null)
                        {
                            errore = "template: " + this._template + " - document.AcroForm.Fields[name] is null with name = " + name;
                            return null;
                        }
                        field.Value = new PdfString(items[name]);
                        field.ReadOnly = true;
                    }
                }

                using (var gfx = XGraphics.FromPdfPage(document.Pages[0], XPageDirection.Upwards)) {
                    float dpiPdf = 300;
                    
                                        
                    //7mm = 19.84251968504 point
                    //12mm = 34.0157480315 point
                    //22mm = 62.36220472441 point =  83.149 pixel
                    //var dimLogoPoint = gfx.pointsFromMm(22);// 62.36220472441;
                    //   pixel = points * dpiX / 72                 points = pixels * 72 / g.DpiX;
                    // mm = pixel * 25.4 / dpi
                    
                    // Disegna un riquadro di colore bianco (24 X 78 mm) atto a contenere il logo e il relativo testo con indirizzo con un margine di due pixel
                    var xRiquadroLogo= gfx.pointsFromMm(11);
                    var mmA4 = BollettiniPdf.mmFromPoints(dpiPdf, Convert.ToSingle(gfx.PageSize.Height));
                    var yRiquadroLogo = gfx.pointsFromMm(mmA4 - 22 - 7 - 1);
                    var pixelswidth = BollettiniPdf.pixelsFromMm(dpiPdf, 78);
                    var pixelsheight = BollettiniPdf.pixelsFromMm(dpiPdf, 24);


                    var riquadro = new Bitmap(pixelswidth, pixelsheight);
                    riquadro.SetResolution(dpiPdf, dpiPdf);
                    var grRiquadroLogo= Graphics.FromImage(riquadro);
                   
                 
                    grRiquadroLogo.FillRectangle(Brushes.White, new Rectangle(0, 0, pixelswidth, pixelsheight));
                    grRiquadroLogo.Flush();
                    var riquadroLogoPosition = new XPoint(xRiquadroLogo, yRiquadroLogo);
                    gfx.DrawImage(riquadro, riquadroLogoPosition);

                    // Disegna il logo dell'ente (22 X 22 mm)
                    var marginePollici15Mm = gfx.pointsFromMm(15);                    
                    var logoImage = BollettiniPdf.GetLogo(logo,22, 22);
                    var xLogoEnte = gfx.pointsFromMm(12);
                    // var mmA4 = BollettiniPdf.mmFromPoints(dpiPDF, Convert.ToSingle(gfx.PageSize.Height));
                    var yLogoEnte = gfx.pointsFromMm(mmA4 -22-7);
                    var logoPosition = new XPoint(xLogoEnte, yLogoEnte);                    
                    gfx.DrawImage(logoImage, logoPosition);

                    //Disegna la scritta con l'indirizzo dell'ente, per la scritta abbiamo 54x22mm
                    var enteHeigthPoint = BollettiniPdf.pointsFromMm(dpiPdf, 22);//62.362; //= 22mm 
                    int enteHeigthPixel = BollettiniPdf.pixelsFromMm(dpiPdf, 22);
                    var enteWidthPoint = BollettiniPdf.pointsFromMm(dpiPdf, 54);// 153.07;   //54mm
                    int enteWidthPixel = BollettiniPdf.pixelsFromMm(dpiPdf, 54);//sommato al logo deve fare 76mm
                    var txtEnteImage = new Bitmap(enteWidthPixel, enteHeigthPixel); //moltiplico per 8 presupponendo max 4 righe
                    txtEnteImage.SetResolution(dpiPdf, dpiPdf);
                 
                    var grTextEnte = Graphics.FromImage(txtEnteImage);                    
                    grTextEnte.SmoothingMode = SmoothingMode.AntiAlias;
                    grTextEnte.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    grTextEnte.PixelOffsetMode = PixelOffsetMode.HighQuality;
                    grTextEnte.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
          
                    StringFormat format = new StringFormat() {
                        //Alignment = StringAlignment.Center
                        LineAlignment = StringAlignment.Near,
                        
                    };
                    var textEntePosition = new XPoint(xLogoEnte + logoImage.PointWidth, 
                                yLogoEnte);
                    grTextEnte.DrawString(ente, new Font("Times New Roman", 10), //12  è il font in point
                            Brushes.Black, new Rectangle(0, 0, txtEnteImage.Width, txtEnteImage.Height),
                            format);
                    grTextEnte.Flush();
                    gfx.DrawImage(txtEnteImage, textEntePosition);
                  
                    // posizionamento del codice a barre
                    //int height = 53;        // Le dimensioni sono espresse in pixel, 14 mm = 52.913386  pixel
                    // MA ESSENDO QUESTE LE DIMENSIONI MASSIME FACCIAMO 50
                    //int width = 302;        // Le dimensioni sono espresse in pixel, 80 mm = 302.362205 pixel
                    // MA ESSENDO QUESTE LE DIMENSIONI MASSIME FACCIAMO 290
                    //int margin = 37;        // Le dimensioni sono espresse in pixel, 10 mm = 37.795276 pixel
                    //  GenerateEAN(string text, int height, int width, int margin)
                    // 14mm= 39 points
                    var barcodeImage = BollettiniPdf.GenerateEAN(valoreCodiceBarre, 39);     // Genera l'immagine del codice a barre

                    // Verifica che il barCode sia stato generato correttamente
                    if (barcodeImage == null) {
                        errore = "Errore nella generazione del bar code.";
                        return null;
                    }
                    int textHeight = 7;

                    //barcodeImage.SetResolution(dpiPDF, dpiPDF);
                    var barcodePosition = new XPoint(marginePollici15Mm, marginePollici15Mm+textHeight);
                    gfx.DrawImage(barcodeImage, barcodePosition);

                 
                    int heigthtextBarCode = Convert.ToInt32(textHeight * dpiPdf / 72.0); //pixel
                    int heigthtextBarCodeExternal = Convert.ToInt32(textHeight * 96.0f / 72.0); //pixel
                    var txtImage = new Bitmap(Convert.ToInt32(barcodeImage.Width * dpiPdf / 96.0), heigthtextBarCode);
                    txtImage.SetResolution(dpiPdf, dpiPdf);
                    var grTextBarCode = Graphics.FromImage(txtImage);
                    grTextBarCode.SmoothingMode = SmoothingMode.AntiAlias;
                    grTextBarCode.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    grTextBarCode.PixelOffsetMode = PixelOffsetMode.HighQuality;
                    grTextBarCode.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
                    var textPosition = new XPoint(marginePollici15Mm, barcodePosition.Y - heigthtextBarCodeExternal);
                    //Create string formatting options(used for alignment)
                    format = new StringFormat() {
                        Alignment = StringAlignment.Center
                        //,LineAlignment = StringAlignment.Center
                    };

                    grTextBarCode.DrawString(BollettiniPdf.GetHintCodiceBarre(valoreCodiceBarre, importo), new Font("Arial", textHeight),
                            Brushes.Black, new Rectangle(0, 0, txtImage.Width, txtImage.Height), format);
                    grTextBarCode.Flush();


                    gfx.DrawImage(txtImage, textPosition);

                    Bitmap qrcodeImage = BollettiniPdf.GenerateQR(valoreCodiceQr);
                  
                    // Verifica che il qrCode sia stato generato correttmente, in quel caso la funzione torna un valore null
                    if (qrcodeImage == null) {
                        errore ="Errore nella generazione del QR code.";
                        return null;
                    }
                    double modelLeftMargin = marginePollici15Mm; // 15 mm dal bordo sinistro
                    //qrcodeImage.Width = 100 pixels che corrispondono a 75 points                    
                    var qrcodePosition = new XPoint(gfx.PageSize.Width - qrcodeImage.Width - modelLeftMargin, marginePollici15Mm);       // 
                    gfx.DrawImage(qrcodeImage, qrcodePosition);

                    gfx.Save();
                }
                //stampaDocumento(document, "prova_bollettino_bancasondrio", null, null, null, null);

                var ms = new MemoryStream();
                document.Save(ms);
                return ms.ToArray();
            }
            catch (Exception ex) {
                errore = dettErrore + " - " + ex.Message + " Stack: " + ex.StackTrace;
            }

            return null;
        }


        private void stampaDocumento(PdfDocument doc, string nomeFile, string cf, string progr, string modulo, string denominazione) {
            var invalid = new string(Path.GetInvalidFileNameChars()) + new string(Path.GetInvalidPathChars());
            //string nomeFile = denominazione + cf;
            foreach (var c in invalid) {
                nomeFile = nomeFile.Replace(c.ToString(), "");
            }

            var nomeCompletoFilePdf = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, nomeFile + ".pdf");
            // string pathCompleto = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, NomeCompletoFilePDF);

            try {
                doc.Save(nomeCompletoFilePdf);
                //MetaFactory.factory.getSingleton<IMessageShower>().Show("Salvataggio effettuato");
            }
            catch (Exception e) {
                /* QueryCreator.ShowError(this, "E*/
                // rrore salvando il file, probabilmente il file è già aperto.", e.ToString());
            }

            //Process p = new Process();
            //p.StartInfo.FileName = nomeFile;
            //p.Start();
        }
     



       

       

    

      

    }

 

}

