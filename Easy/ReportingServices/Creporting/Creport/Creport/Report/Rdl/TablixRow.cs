/*
    Easy
    Copyright (C) 2020 Università degli Studi di Catania (www.unict.it)
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

﻿using System.Xml.Linq;

namespace Creport.Report.Rdl {
    public class TablixRow :IElement {
        private readonly TablixCells tablixCells;

        public TablixRow(Inch height, TablixCells tablixCells) {
            this.Height = height;
            this.tablixCells = tablixCells;
        }

        public Inch Height { get; private set; }

        public XElement Element {
            get {
                return this.Build();
            }
        }

        private XElement Build() {
            return new XElement(
                typeof(TablixRow).GetShortName(),
                new XElement("Height", this.Height),
                this.tablixCells.Element);
        }

        /// <summary>
        /// Crea una riga Tablix con N celle
        /// </summary>
        /// <param name="tablixcell"></param>
        /// <returns></returns>
        public static TablixRow CreateTablixRow(TablixCell[] tablixcell) {

            TablixCells tablixCells = new TablixCells();
            foreach (var item in tablixcell) { tablixCells.Add(item); }

            return new TablixRow(new Inch(0.4), tablixCells);
        }


        /// <summary>
        /// Crea una riga Tablix con drilldown in una Tablix con Element stringa. Element = stringa da visualizzare, font = dimensione del font, fontFamily = tipo font,fontweight = spessore, color = colore, format = formato, textAlign = allieamento testo, inch = distanza tra le righe, hidde = true nascondi, ToggleItem oggetto del drilldown
        /// </summary>
        /// <param name="Element">"Totale"</param>
        /// <param name="subtotal">false</param>
        /// <param name="font">9</param>
        /// <param name="fontFamily">System.Drawing.FontFamily.GenericSerif.Name</param>
        /// <param name="fontweight">FontWeight.Default</param>
        /// <param name="color">RdlColor.Black.ToString()</param>
        /// <param name="format">"n"</param>
        /// <param name="textAlign">TextAlign.Center</param>
        /// <param name="inch">0.4</param>
        /// <param name="Hidden">true</param>
        /// <param name="ToggleItem">"Texbox1"</param>
        /// <returns></returns>
        public static TablixRow CreateTablixRow(string Element, string fontFamily, int font, FontWeight fontweight, string color, string format, TextAlign textAlign, double inch, bool Hidden, string ToggleItem) {
            var textRun = new TextRun {
                Value = "=" + Element.ConvertInReportString(),
                FontFamily = fontFamily,
                FontSize = new Point(font),
                FontWeight = fontweight,
                Color = color,
                Format = format
            };

            var paragraph = new Paragraph(new TextRuns(textRun)) { TextAlign = textAlign };
            var textbox = new Textbox(paragraph) { Visibility = new Visibility(true, "Textbox1"), TextboxStyle = new TextboxStyle() };
            var tablixCells = new TablixCells(new TablixCell(new CellContents(textbox)));
            return new TablixRow(new Inch(inch), tablixCells);
        }




        /// <summary>
        /// Crea una riga Tablix con drilldown in una Tablix. Element = campi da visualizzare, operand = operando, subtotal = indica se è subtotale, font = dimensione del font, fontFamily = tipo font,fontweight = spessore, color = colore, format = formato, textAlign = allieamento testo, inch = distanza tra le righe, visibility = espressione di visibilità, ToggleItem oggetto del drilldown
        /// </summary>
        /// <param name="Element">new string[]{ ElementProperty.Id1, ElementProperty.Id2 }</param>
        /// <param name="operand">"+"</param>
        /// <param name="subtotal">false</param>
        /// <param name="font">9</param>
        /// <param name="fontFamily">System.Drawing.FontFamily.GenericSerif.Name</param>
        /// <param name="fontweight">FontWeight.Default</param>
        /// <param name="color">RdlColor.Black.ToString()</param>
        /// <param name="format">"n"</param>
        /// <param name="textAlign">TextAlign.Center</param>
        /// <param name="inch">0.4</param>
        /// <param name="visibility">"IIF(1=1,true,false)"</param>
        /// <param name="ToggleItem">"Texbox1"</param>
        /// <returns></returns>
        public static TablixRow CreateTablixRow(string[] Element, string operand, bool subtotal, string fontFamily, int font, FontWeight fontweight, string color, string format, TextAlign textAlign, double inch, string visibility, string ToggleItem) {
            var textRun = new TextRun {
                Value = "=" + Expression.FieldsValue(Element, operand, subtotal),
                FontFamily = fontFamily,
                FontSize = new Point(font),
                FontWeight = fontweight,
                Color = color,
                Format = format
            };

            var paragraph = new Paragraph(new TextRuns(textRun)) { TextAlign = textAlign };
            var textbox = new Textbox(paragraph) { Visibility = new Visibility("=" + visibility, "Textbox1"), TextboxStyle = new TextboxStyle() };
            var tablixCells = new TablixCells(new TablixCell(new CellContents(textbox)));
            return new TablixRow(new Inch(inch), tablixCells);
        }





        /// <summary>
        /// Crea una riga Tablix con drilldown in una Tablix. Element = campo da visualizzare, subtotal = indica se è subtotale, font = dimensione del font, fontFamily = tipo font,fontweight = spessore, color = colore, format = formato, textAlign = allieamento testo, inch = distanza tra le righe, hidde = true nascondi, ToggleItem oggetto del drilldown
        /// </summary>
        /// <param name="Element">ElementProperty.Name</param>
        /// <param name="subtotal">false</param>
        /// <param name="font">9</param>
        /// <param name="fontFamily">System.Drawing.FontFamily.GenericSerif.Name</param>
        /// <param name="fontweight">FontWeight.Default</param>
        /// <param name="color">RdlColor.Black.ToString()</param>
        /// <param name="format">"n"</param>
        /// <param name="textAlign">TextAlign.Center</param>
        /// <param name="inch">0.4</param>
        /// <param name="Hidden">true</param>
        /// <param name="ToggleItem">"Texbox1"</param>
        /// <returns></returns>
        public static TablixRow CreateTablixRow(string Element, bool subtotal, string fontFamily, int font, FontWeight fontweight, string color, string format, TextAlign textAlign, double inch, bool Hidden, string ToggleItem) {
            var textRun = new TextRun {
                Value = "=" + Expression.FieldsValue(Element, subtotal),
                FontFamily = fontFamily,
                FontSize = new Point(font),
                FontWeight = fontweight,
                Color = color,
                Format = format
            };

            var paragraph = new Paragraph(new TextRuns(textRun)) { TextAlign = textAlign };
            var textbox = new Textbox(paragraph) { Visibility = new Visibility(Hidden, "Textbox1"), TextboxStyle = new TextboxStyle() };
            var tablixCells = new TablixCells(new TablixCell(new CellContents(textbox)));
            return new TablixRow(new Inch(inch), tablixCells);
        }




        /// <summary>
        /// Crea una riga Tablix in una Tablix. Element = campo da visualizzare, subtotal = indica se è subtotale, font = dimensione del font, fontFamily = tipo font,fontweight = spessore, color = colore, format = formato, textAlign = allieamento testo, inch = distanza tra le righe
        /// </summary>
        /// <param name="Element">ElementProperty.Name</param>
        /// <param name="subtotal">false</param>
        /// <param name="font">9</param>
        /// <param name="fontFamily">System.Drawing.FontFamily.GenericSerif.Name</param>
        /// <param name="fontweight">FontWeight.Default</param>
        /// <param name="color">RdlColor.Black.ToString()</param>
        /// <param name="format">"n"</param>
        /// <param name="textAlign">TextAlign.Center</param>
        /// <param name="inch">0.4</param>
        /// <returns></returns>
        public static TablixRow CreateTablixRow(string Element, bool subtotal, string fontFamily, int font, FontWeight fontweight, string color, string format, TextAlign textAlign, double inch) {
            var textRun = new TextRun {
                Value = "=" + Expression.FieldsValue(Element, subtotal),
                FontFamily = fontFamily,
                FontSize = new Point(font),
                FontWeight = fontweight,
                Color = color,
                Format = format
            };

            var paragraph = new Paragraph(new TextRuns(textRun)) { TextAlign = textAlign };
            var textbox = new Textbox(paragraph) { TextboxStyle = new TextboxStyle() };
            var tablixCells = new TablixCells(new TablixCell(new CellContents(textbox)));
            return new TablixRow(new Inch(inch), tablixCells);
        }


        /// <summary>
        /// Crea una riga Tablix in una Tablix. Element = campo da visualizzare, subtotal = indica se è subtotale, fontFamily = tipo font, font = dimensione del font, ,fontweight = spessore, color = colore, format = formato, textAlign allieamento testo
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
        public static TablixRow CreateTablixRow(string Element, bool subtotal,string fontFamily, int font, FontWeight fontweight, string color, string format, TextAlign textAlign) {
            var textRun = new TextRun {
                Value = "=" + Expression.FieldsValue(Element, subtotal),
                FontFamily = fontFamily,
                FontSize = new Point(font),
                FontWeight = fontweight,
                Color = color,
                Format = format
            };

            var paragraph = new Paragraph(new TextRuns(textRun)) { TextAlign = textAlign };
            var textbox = new Textbox(paragraph) { TextboxStyle = new TextboxStyle() };
            var tablixCells = new TablixCells(new TablixCell(new CellContents(textbox)));
            return new TablixRow(new Inch(0.4), tablixCells);
        }


        /// <summary>
        /// Crea una riga Tablix in una Tablix. Element = campo da visualizzare
        /// </summary>
        /// <param name="Element">ElementProperty.Name</param>
        /// <returns></returns>
        public static TablixRow CreateTablixRow(string Element) {
            var textRun = new TextRun {
                Value = "=" + Expression.FieldsValue(Element, false)
            };

            var paragraph = new Paragraph(new TextRuns(textRun)) { TextAlign = TextAlign.Default };
            var textbox = new Textbox(paragraph) { TextboxStyle = new TextboxStyle() };
            var tablixCells = new TablixCells(new TablixCell(new CellContents(textbox)));
            return new TablixRow(new Inch(0.4), tablixCells);
        }


        /// <summary>
        /// Crea una riga Tablix in una Tablix. Element = campo da visualizzare, subtotal = indica se è subtotale
        /// </summary>
        /// <param name="Element">ElementProperty.Name</param>
        /// <param name="subtotal">false</param>
        /// <returns></returns>
        public static TablixRow CreateTablixRow(string Element, bool subtotal) {
            var textRun = new TextRun {
                Value = "=" + Expression.FieldsValue(Element, subtotal)
            };

            var paragraph = new Paragraph(new TextRuns(textRun)) { TextAlign = TextAlign.Default };
            var textbox = new Textbox(paragraph) { TextboxStyle = new TextboxStyle() };
            var tablixCells = new TablixCells(new TablixCell(new CellContents(textbox)));
            return new TablixRow(new Inch(0.4), tablixCells);
        }


        /// <summary>
        /// Crea una riga Tablix in una Tablix. Element = campo da visualizzare, subtotal = indica se è subtotale, format = formato
        /// </summary>
        /// <param name="Element">ElementProperty.Name</param>
        /// <param name="subtotal">false</param>
        /// <param name="format">"n"</param>
        /// <returns></returns>
        public static TablixRow CreateTablixRow(string Element, bool subtotal, string format) {
            var textRun = new TextRun {
                Value = "=" + Expression.FieldsValue(Element, subtotal),
                Format = format
            };

            var paragraph = new Paragraph(new TextRuns(textRun)) { TextAlign = TextAlign.Default };
            var textbox = new Textbox(paragraph) { TextboxStyle = new TextboxStyle() };
            var tablixCells = new TablixCells(new TablixCell(new CellContents(textbox)));
            return new TablixRow(new Inch(0.4), tablixCells);
        }


        /// <summary>
        /// Crea una riga Tablix in una Tablix. Element = campo da visualizzare, subtotal = indica se è subtotale, font = dimensione del font, format = formato, textAlign allieamento testo
        /// </summary>
        /// <param name="Element">ElementProperty.Name</param>
        /// <param name="subtotal">false</param>
        /// <param name="font">9</param>
        /// <param name="format">"n"</param>
        /// <param name="textAlign">TextAlign.Center</param>
        /// <returns></returns>
        public static TablixRow CreateTablixRow(string Element,bool subtotal ,int font, string format, TextAlign textAlign) {
            var textRun = new TextRun {
                Value = "=" + Expression.FieldsValue(Element, subtotal),
                FontSize = new Point(font),
                Format = format
            };

            var paragraph = new Paragraph(new TextRuns(textRun)) { TextAlign = textAlign };
            var textbox = new Textbox(paragraph) { TextboxStyle = new TextboxStyle() };
            var tablixCells = new TablixCells(new TablixCell(new CellContents(textbox)));
            return new TablixRow(new Inch(0.4), tablixCells);
        }



    }
}
