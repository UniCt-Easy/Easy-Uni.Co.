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

﻿namespace Creport.Report.Rdl {
    public class TablixCell :ParentOf<CellContents> {
        public TablixCell(CellContents item)
            : base(item) {
        }

        protected sealed override string GetRdlName() {
            return typeof(TablixCell).GetShortName();
        }

        /// <summary>
        /// Crea una cella da inserire in una row in una tablix. Element = campo da visualizzare, subtotal = indica se è subtotale, fontFamily = tipo font, font = dimensione del font, fontweight = spessore, color = colore, format = formato, textAlign allieamento testo
        /// </summary>
        /// <param name="Element">ElementProperty.Name</param>
        /// <param name="subtotal">false</param>
        /// <param name="fontFamily">System.Drawing.FontFamily.GenericSerif.Name</param>
        /// <param name="font">9</param>
        /// <param name="fontweight">FontWeight.Default</param>
        /// <param name="color">RdlColor.Black.ToString()</param>
        /// <param name="format">"n"</param>
        /// <param name="textAlign">TextAlign.Center</param>
        /// <returns></returns>
        public static TablixCell Create(string Element, bool subtotal, string fontFamily, int font, FontWeight fontweight, string color, string format,TextAlign textAlign) {
            var textRun = new TextRun {
                Value = "=" + Expression.FieldsValue(Element, subtotal),
                FontFamily = fontFamily,
                FontSize = new Point(font),
                FontWeight = fontweight,
                Color = color,
                Format = format,
            };

            var paragraph = new Paragraph(new TextRuns(textRun)) { TextAlign = textAlign };
            var textbox = new Textbox(paragraph) { TextboxStyle = new TextboxStyle() };
            return (new TablixCell(new CellContents(textbox)));
        }



        /// <summary>
        /// Crea una cella con drilldown da inserire in una row in una tablix. Element = campo da visualizzare, subtotal = indica se è subtotale, fontFamily = tipo font, font = dimensione del font, fontweight = spessore, color = colore, format = formato, textAlign allieamento testo, visibility = espressione di visibilità, ToggleItem oggetto del drilldown
        /// </summary>
        /// <param name="Element">ElementProperty.Name</param>
        /// <param name="subtotal">false</param>
        /// <param name="fontFamily">System.Drawing.FontFamily.GenericSerif.Name</param>
        /// <param name="font">9</param>
        /// <param name="fontweight">FontWeight.Default</param>
        /// <param name="color">RdlColor.Black.ToString()</param>
        /// <param name="format">"n"</param>
        /// <param name="textAlign">TextAlign.Center</param>
        /// <param name="visibility">IIF(1=1,true,false)</param>
        /// <param name="ToggleItem">"Texbox1"</param>
        /// <returns></returns>
        public static TablixCell Create(string Element, bool subtotal, string fontFamily, int font, FontWeight fontweight, string color, string format, TextAlign textAlign, string visibility, string ToggleItem) {
            var textRun = new TextRun {
                Value = "=" + Expression.FieldsValue(Element, subtotal),
                FontFamily = fontFamily,
                FontSize = new Point(font),
                FontWeight = fontweight,
                Color = color,
                Format = format,
            };

            var paragraph = new Paragraph(new TextRuns(textRun)) { TextAlign = textAlign };
            var textbox = new Textbox(paragraph) { Visibility = new Visibility("=" + visibility, ToggleItem), TextboxStyle = new TextboxStyle()};
            return (new TablixCell(new CellContents(textbox)));
        }


        /// <summary>
        /// Crea una cella con drilldown da inserire in una row in una tablix, con elemento stringa. Element = stringa da visualizzare, fontFamily = tipo font, font = dimensione del font, fontweight = spessore, color = colore, format = formato, textAlign allieamento testo, hidde = true nascondi, ToggleItem oggetto del drilldown
        /// </summary>
        /// <param name="Element">"Totale"</param>
        /// <param name="subtotal">false</param>
        /// <param name="fontFamily">System.Drawing.FontFamily.GenericSerif.Name</param>
        /// <param name="font">9</param>
        /// <param name="fontweight">FontWeight.Default</param>
        /// <param name="color">RdlColor.Black.ToString()</param>
        /// <param name="format">"n"</param>
        /// <param name="textAlign">TextAlign.Center</param>
        /// <param name="hidden">true</param>
        /// <param name="ToggleItem">"Texbox1"</param>
        /// <returns></returns>
        public static TablixCell CreateString(string Element, string fontFamily, int font, FontWeight fontweight, string color, string format, TextAlign textAlign, bool hidden, string ToggleItem) {
            var textRun = new TextRun {
                Value = "=" + Element.ConvertInReportString(),
                FontFamily = fontFamily,
                FontSize = new Point(font),
                FontWeight = fontweight,
                Color = color,
                Format = format,
            };

            var paragraph = new Paragraph(new TextRuns(textRun)) { TextAlign = textAlign };
            var textbox = new Textbox(paragraph) { Visibility = new Visibility(hidden, ToggleItem), TextboxStyle = new TextboxStyle() };
            return (new TablixCell(new CellContents(textbox)));
        }



        /// <summary>
        /// Crea una cella con drilldown da inserire in una row in una tablix. Element = campi da visualizzare, operand = operando,subtotal = indica se è subtotale, fontFamily = tipo font, font = dimensione del font, fontweight = spessore, color = colore, format = formato, textAlign allieamento testo, visibility = espressione di visibilità, ToggleItem oggetto del drilldown
        /// </summary>
        /// <param name="Element">new string[]{ ElementProperty.Id1, ElementProperty.Id2 }</param>
        /// <param name="operand">"+"</param>
        /// <param name="subtotal">false</param>
        /// <param name="fontFamily">System.Drawing.FontFamily.GenericSerif.Name</param>
        /// <param name="font">9</param>
        /// <param name="fontweight">FontWeight.Default</param>
        /// <param name="color">RdlColor.Black.ToString()</param>
        /// <param name="format">"n"</param>
        /// <param name="textAlign">TextAlign.Center</param>
        /// <param name="visibility">"IIF(1=1,true,false)"</param>
        /// <param name="ToggleItem">"Texbox1"</param>
        /// <returns></returns>
        public static TablixCell Create(string[] Element, string operand,bool subtotal, string fontFamily, int font, FontWeight fontweight, string color, string format, TextAlign textAlign, string visibility, string ToggleItem) {
            var textRun = new TextRun {
                Value = "=" + Expression.FieldsValue(Element, operand,subtotal),
                FontFamily = fontFamily,
                FontSize = new Point(font),
                FontWeight = fontweight,
                Color = color,
                Format = format,
            };

            var paragraph = new Paragraph(new TextRuns(textRun)) { TextAlign = textAlign };
            var textbox = new Textbox(paragraph) { Visibility = new Visibility("=" + visibility, ToggleItem), TextboxStyle = new TextboxStyle() };
            return (new TablixCell(new CellContents(textbox)));
        }





        /// <summary>
        /// Crea una cella con drilldown da inserire in una row in una tablix. Element = campo da visualizzare, subtotal = indica se è subtotale, fontFamily = tipo font, font = dimensione del font, fontweight = spessore, color = colore, format = formato, textAlign allieamento testo, hidde = true nascondi, ToggleItem oggetto del drilldown
        /// </summary>
        /// <param name="Element">ElementProperty.Name</param>
        /// <param name="subtotal">false</param>
        /// <param name="fontFamily">System.Drawing.FontFamily.GenericSerif.Name</param>
        /// <param name="font">9</param>
        /// <param name="fontweight">FontWeight.Default</param>
        /// <param name="color">RdlColor.Black.ToString()</param>
        /// <param name="format">"n"</param>
        /// <param name="textAlign">TextAlign.Center</param>
        /// <param name="hidden">true</param>
        /// <param name="ToggleItem">"Texbox1"</param>
        /// <returns></returns>
        public static TablixCell Create(string Element, bool subtotal, string fontFamily, int font, FontWeight fontweight, string color, string format, TextAlign textAlign, bool hidden, string ToggleItem) {
            var textRun = new TextRun {
                Value = "=" + Expression.FieldsValue(Element, subtotal),
                FontFamily = fontFamily,
                FontSize = new Point(font),
                FontWeight = fontweight,
                Color = color,
                Format = format,
            };

            var paragraph = new Paragraph(new TextRuns(textRun)) { TextAlign = textAlign };
            var textbox = new Textbox(paragraph) { Visibility = new Visibility(hidden, ToggleItem), TextboxStyle = new TextboxStyle() };
            return (new TablixCell(new CellContents(textbox)));
        }

    }
}
