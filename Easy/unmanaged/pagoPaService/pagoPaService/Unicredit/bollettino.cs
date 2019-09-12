/*
    Easy
    Copyright (C) 2019 Universit� degli Studi di Catania (www.unict.it)

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

﻿using PdfSharp.Drawing;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using ZXing;
using pagoPaService.Utils;
using PdfSharp.Pdf.Advanced;

namespace UnicreditService {

    public class Bollettino {

        private MemoryStream template;

        public Bollettino(string template) {
            this.template = new MemoryStream();

            if (File.Exists(template)) {
                using (var src = new FileStream(template, FileMode.Open)) {
                    src.CopyTo(this.template);
                }
            }
            else {
                throw new ArgumentException($"Il file del modello specificato ({template}) non esiste");
            }
        }



       public byte[] generaBollettino_versione_2018(string Oggetto_Pagamento, string Cf_Ente, string Cf_Destinatario, string Ente_Creditore, string Settore_Ente, string Info_Ente, string Nome_Cognome_Destinatario, string Indirizzo_Destinatario,
                             string Pagamento_Rateale, DateTime dData, decimal decImporto, string  Del_Tuo_Ente, string Oggetto_PagamentoRid, string Cbill, string Codice_Avviso,
                             byte[] logo, string ValoreCodiceQR, out string errore
                        ) {

             try {
                errore = null;
                var document = PdfReader.Open(this.template);

                //var options = new XPdfFontOptions(PdfFontEmbedding.Always);
                //var font = new XFont("Titillium Web", 16, XFontStyle.Bold, options);

                if (document.AcroForm != null) {
                    var form = document.AcroForm;

                    if (form.Elements.ContainsKey("/NeedAppearances")) {
                        form.Elements["/NeedAppearances"] = new PdfBoolean(true);
                    }
                    else {
                        form.Elements.Add("/NeedAppearances", new PdfBoolean(true));
                    }

                    var items = new Dictionary<string, string>();
                    // Attenzione deve esserci corrispondenza perfetta con i nomi usati nel modello
                    // (case sensitive)
                    // Oggetto_Pagamento[60] Logo_Ente Cf_Ente Cf_Destinatario Ente_Creditore[37] Settore_Ente[37] Info_Ente[55] Nome_Cognome_Destinatario[37] Indirizzo_Destinatario[37]
                    // Pagamento_Rateale[28] Data[10] Importo[8] Del_Tuo_Ente[20] Nome_Cognome_DestinatarioRid[30] Oggetto_PagamentoRid[50] Cbill[8] Codice_Avviso[30]
                    items["Oggetto_Pagamento"] = Oggetto_Pagamento.Substring(0, Math.Min(60,Oggetto_Pagamento.Length));
                    //Logo_Ente 
                    items["Cf_Ente"] = Cf_Ente;
                    items["Cf_Ente_2"] = Cf_Ente;
                    items["Cf_Destinatario"] = Cf_Destinatario;
                    items["Ente_Creditore"] = Ente_Creditore.Substring(0, Math.Min(50,Ente_Creditore.Length));
                    items["Ente_Creditore_2"] = Ente_Creditore.Substring(0, Math.Min(50,Ente_Creditore.Length));

                    items["Settore_Ente"] = Settore_Ente.Substring(0,Math.Min(37,Settore_Ente.Length));
                    items["Info_Ente"] = Info_Ente.Substring(0,Math.Min(55, Info_Ente.Length));
                    items["Nome_Cognome_Destinatario"] = Nome_Cognome_Destinatario.Substring(0,Math.Min(37,Nome_Cognome_Destinatario.Length));
                    items["Indirizzo_Destinatario"] = Indirizzo_Destinatario.Substring(0,Math.Min(37,Indirizzo_Destinatario.Length));
                    items["Pagamento_Rateale"] = Pagamento_Rateale.Substring(0,Math.Min(28,Pagamento_Rateale.Length));
                    //Data[10] Importo[8] 
                    items["Data"] = dData.ToString().Substring(0,Math.Min(10,dData.ToString().Length));
                    items["Data_2"] = dData.ToString().Substring(0,Math.Min(10,dData.ToString().Length));
                    items["Importo"] =  string.Format("{0:0.00}", decImporto); 
                    items["Importo_2"] = string.Format("{0:0.00}", decImporto); 

                    items["Del_Tuo_Ente"] = Del_Tuo_Ente.Substring(0,Math.Min(28,Del_Tuo_Ente.Length));
                    items["Nome_Cognome_DestinatarioRid"] = Nome_Cognome_Destinatario.Substring(0,Math.Min(30,Nome_Cognome_Destinatario.Length));
                    items["Oggetto_PagamentoRid"] = Oggetto_Pagamento.Substring(0,Math.Min(50,Oggetto_Pagamento.Length));
                    items["Cbill"] = Cbill.Substring(0,Math.Min(8,Cbill.Length));
                    items["Codice_Avviso"] = Codice_Avviso.Substring(0,Math.Min(30,Codice_Avviso.Length));

                    foreach (var name in items.Keys) {
                        var field = document.AcroForm.Fields[name];
                        if (field != null) { // per non generare eccezione in caso di nomi errati
                            field.Value = new PdfString(items[name]);
                            
                            field.ReadOnly = true;
                            
                        }
                        //else
                        //    MessageBox.Show("Errore nella scrittura del campo " + name);
                    }
                    
                }

                using (var gfx = XGraphics.FromPdfPage(document.Pages[0], XPageDirection.Upwards)) { 
                    gfx.MFEH = PdfFontEmbedding.Always; 
                      
                    float dpiPDF = 300;
                    var marginePollici15MM = gfx.pointsFromMm(15);
                    var logoImage = BollettiniPdf.GetLogo(logo, 30, 30);
                    var xLogoEnte = gfx.pointsFromMm(170.2f);

                    var mmA4 = BollettiniPdf.mmFromPoints(dpiPDF, Convert.ToSingle(gfx.PageSize.Height));
                    var yLogoEnte = gfx.pointsFromMm(mmA4-41); 
 
                    var logoPosition = new XPoint(xLogoEnte, yLogoEnte);

                    
                    gfx.DrawImage(logoImage, logoPosition);
 
                    Bitmap qrcodeImage = BollettiniPdf.GenerateQR(ValoreCodiceQR);

                    // Verifica che il qrCode sia stato generato correttmente, in quel caso la funzione torna un valore null
                    if (qrcodeImage == null) {
                        errore = "Errore nella generazione del QR code.";
                        return null;
                    }

                    var qrcodePosition = new XPoint(179, 285);
                    gfx.DrawImage(qrcodeImage, qrcodePosition);
                }

                MemoryStream ms = new MemoryStream();
                document.Save(ms);
                return ms.ToArray();
            }
            catch (Exception ex) {
                errore = ex.Message;
            }

            return null;

        }

        public byte[] Genera(string ente, string descrizioneEnte,  
                             string indirizzoEnte, string capEnte, string comuneEnte, string provinciaEnte, string codiceFiscaleEnte,
                             string debitore,
                             string codiceAvviso, string codiceSia, string tipologiaServizio, string urlSitoIstituzionale,string urlServizioPagamento, string codiceBollettino, decimal importo, DateTime scadenza, string iuv,string causaleBollettino,
                             byte []logo,string valoreCodiceBarre,string ValoreCodiceQR, out string errore
                        ) {
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

                    var items = new Dictionary<string, string>();
                    // Attenzione deve esserci corrispondenza perfetta con i nomi usati nel modello
                    // (case sensitive)
                    //items["IndirizzoLogo"] =  
                    items["Ente"] = string.Format("{0}\n{1}\n{2} {3} ({4})\nCF: {5}\n{6}",
                    descrizioneEnte, indirizzoEnte,capEnte, comuneEnte,provinciaEnte,codiceFiscaleEnte, urlSitoIstituzionale /*UrlSitoIstituzionaleEnte*/ );
                    items["Debitore"] = debitore;
                    items["CodiceSia"] = codiceSia; //siacodecbi in treasurer
                    items["CodiceAvviso"] = codiceAvviso;
                    items["Importo"] = string.Format("{0:0.00}", importo);
                    items["DataScadenza"] = string.Format("{0:dd/MM/yyyy}", scadenza);
                    items["Iuv"] = iuv;
                    items["TipologiaServizio"] = tipologiaServizio;
                    items["Causale"] = causaleBollettino;
                    items["Importo_1"] = string.Format("{0:0.00}", importo);
                    items["EnteUrl"] = descrizioneEnte + " " + urlServizioPagamento;
       
                    foreach (var name in items.Keys) {
                        var field = document.AcroForm.Fields[name];
                        if (field != null) { // per non generare eccezione in caso di nomi errati
                            field.Value = new PdfString(items[name]);
                       
                            field.ReadOnly = true;
                        }
                        //else
                        //    MessageBox.Show("Errore nella scrittura del campo " + name);
                    }
                    
                }

                using (var gfx = XGraphics.FromPdfPage(document.Pages[0], XPageDirection.Upwards)) {
                    float dpiPDF = 300;


                    //7mm = 19.84251968504 point
                    //12mm = 34.0157480315 point
                    //22mm = 62.36220472441 point =  83.149 pixel
                    //var dimLogoPoint = gfx.pointsFromMm(22);// 62.36220472441;
                    //   pixel = points * dpiX / 72                 points = pixels * 72 / g.DpiX;
                    // mm = pixel * 25.4 / dpi
                    var marginePollici15MM = gfx.pointsFromMm(15);
                    var logoImage = BollettiniPdf.GetLogo(logo, 22, 22);
                    var xLogoEnte = gfx.pointsFromMm(12);

                    var mmA4 = BollettiniPdf.mmFromPoints(dpiPDF, Convert.ToSingle(gfx.PageSize.Height));
                    var yLogoEnte = gfx.pointsFromMm(mmA4 - 22 -5);
 
                    var logoPosition = new XPoint(xLogoEnte, yLogoEnte);
                    gfx.DrawImage(logoImage, logoPosition);

                    //Per la scritta abbiamo 54x22mm
                    var enteHeigthPoint = BollettiniPdf.pointsFromMm(dpiPDF, 22);//62.362; //= 22mm 
                    int enteHeigthPixel = BollettiniPdf.pixelsFromMm(dpiPDF, 22);
                    var enteWidthPoint = BollettiniPdf.pointsFromMm(dpiPDF, 54);// 153.07;   //54mm
                    int enteWidthPixel = BollettiniPdf.pixelsFromMm(dpiPDF, 54);
                    var txtEnteImage = new Bitmap(enteWidthPixel, enteHeigthPixel); //moltiplico per 8 presupponendo max 4 righe
                    txtEnteImage.SetResolution(dpiPDF, dpiPDF);
                    var grTextEnte = Graphics.FromImage(txtEnteImage);
                    grTextEnte.SmoothingMode = SmoothingMode.AntiAlias;
                    grTextEnte.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    grTextEnte.PixelOffsetMode = PixelOffsetMode.HighQuality;
                    grTextEnte.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
                    StringFormat format = new StringFormat() {
                        //Alignment = StringAlignment.Center
                        LineAlignment = StringAlignment.Near
                    };
                    var textEntePosition = new XPoint(xLogoEnte + logoImage.PointWidth,
                                yLogoEnte);
                    grTextEnte.DrawString(ente, new Font("Times New Roman", 10), //10  è il font in point
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
                    var barcodePosition = new XPoint(marginePollici15MM, marginePollici15MM+ textHeight);
                    gfx.DrawImage(barcodeImage, barcodePosition);

                    
                    int heigthtextBarCode = Convert.ToInt32(textHeight * dpiPDF / 72.0); //pixel
                    int heigthtextBarCodeExternal = Convert.ToInt32(textHeight * 96.0f / 72.0); //pixel
                    var txtImage = new Bitmap(Convert.ToInt32(barcodeImage.Width * dpiPDF / 96.0), heigthtextBarCode);
                    txtImage.SetResolution(dpiPDF, dpiPDF);
                    var grTextBarCode = Graphics.FromImage(txtImage);
                    grTextBarCode.SmoothingMode = SmoothingMode.AntiAlias;
                    grTextBarCode.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    grTextBarCode.PixelOffsetMode = PixelOffsetMode.HighQuality;
                    grTextBarCode.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
                    var textPosition = new XPoint(marginePollici15MM, barcodePosition.Y - heigthtextBarCodeExternal);
                    //Create string formatting options(used for alignment)
                     format = new StringFormat() {
                        Alignment = StringAlignment.Center
                        //,LineAlignment = StringAlignment.Center
                    };

                    grTextBarCode.DrawString(BollettiniPdf.GetHintCodiceBarre(valoreCodiceBarre, importo), new Font("Arial", textHeight),
                            Brushes.Black, new Rectangle(0, 0, txtImage.Width, txtImage.Height), format);
                    grTextBarCode.Flush();


                    gfx.DrawImage(txtImage, textPosition);

 
                    Bitmap qrcodeImage = BollettiniPdf.GenerateQR(ValoreCodiceQR);

                    // Verifica che il qrCode sia stato generato correttmente, in quel caso la funzione torna un valore null
                    if (qrcodeImage == null) {
                        errore = "Errore nella generazione del QR code.";
                        return null;
                    }
                    double modelLeftMargin = marginePollici15MM; // 15 mm dal bordo sinistro
                    //qrcodeImage.Width = 100 pixels che corrispondono a 75 points                    
                    var qrcodePosition = new XPoint(gfx.PageSize.Width - gfx.pointsFromPixels(qrcodeImage.Width)
                                                                    - modelLeftMargin, marginePollici15MM);       // 
                    gfx.DrawImage(qrcodeImage, qrcodePosition);
                }
                //stampaDocumento(document, "prova_bollettino_unicredit", null, null, null, null);

                MemoryStream ms = new MemoryStream();
                document.Save(ms);
                return ms.ToArray();
            }
            catch (Exception ex) {
                errore = ex.Message;
            }

            return null;
        }
        private void stampaDocumento(PdfDocument doc, string nomeFile, string cf, string progr, string modulo, string denominazione) {
            string invalid = new string(Path.GetInvalidFileNameChars()) + new string(Path.GetInvalidPathChars());
            //string nomeFile = denominazione + cf;
            foreach (char c in invalid) {
                nomeFile = nomeFile.Replace(c.ToString(), "");
            }

            string NomeCompletoFilePDF = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, nomeFile + ".pdf");
            // string pathCompleto = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, NomeCompletoFilePDF);

            try {
                doc.Save(NomeCompletoFilePDF);
                //MessageBox.Show("Salvataggio effettuato");
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
    public class InformazioniEnte {

        public byte[] Logo;
        public string CodiceFiscale;
        public string Denominazione;
        public string Indirizzo1;
        public string Indirizzo2;
        public string CAP;
        public string Località;
        public string Provincia;

    }

}

