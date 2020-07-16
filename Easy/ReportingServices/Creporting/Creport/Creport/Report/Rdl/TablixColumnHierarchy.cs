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
    public class TablixColumnHierarchy {
        private readonly TablixMembers tablixMembers;


        public TablixColumnHierarchy(TablixMembers tablixMembers) {
            this.tablixMembers = tablixMembers;
        }



        public Inch Height {
            get {
                return this.tablixMembers.Size;
            }
        }

        public XElement Element {
            get {
                return this.Build();
            }
        }

        private XElement Build() {
            return new XElement(typeof(TablixColumnHierarchy).GetShortName(), this.tablixMembers.Element);
        }

        /// <summary>
        /// Non genera alcuna gerarchia sulle colonne
        /// </summary>
        /// <returns></returns>
        public static TablixColumnHierarchy CreateTablixColumnHierarchy() {
            return new TablixColumnHierarchy(new TablixMembers(new TablixMember()));
        }


        /// <summary>
        /// Istanzia N colonne nuove pronte per essere aggiunte nel body. Non genera alcuna gerarchia sulle colonne
        /// </summary>
        /// <returns></returns>
        public static TablixColumnHierarchy CreateTablixColumnHierarchy(int nrighe) {
            var tablixColumnMembers = new TablixMembers();
            for (int i = 0; i < nrighe; i++) { tablixColumnMembers.Add(new TablixMember()); }
            return new TablixColumnHierarchy(tablixColumnMembers);
        }



        /// <summary>
        /// Genera una gerarchia sulle colonne in base all'elemento passato
        /// </summary>
        /// <param name="Element">ElementProperty.Id1</param>
        /// <returns></returns>
        public static TablixColumnHierarchy CreateTablixColumnHierarchy(string Element) {
            var group =
                new Group(
                    new GroupExpressions(new GroupExpression("=" + Expression.FieldsValue(Element, false))));

            var sortExpression =
                new SortExpression(new Value("=" + Expression.FieldsValue(Element, false)));
            var sortExpressions = new SortExpressions(sortExpression);

            var textRun = new TextRun {
                Value = "=" + Expression.FieldsValue(Element, false)
            };
            var paragraph = new Paragraph(new TextRuns(textRun)) { TextAlign = TextAlign.Center };
            var textbox = new Textbox(paragraph) { TextboxStyle = new TextboxStyle() };
            var header = new TablixHeader(new Inch(0.4), new CellContents(textbox));

            return new TablixColumnHierarchy(new TablixMembers(new TablixMember(group, sortExpressions, header)));
        }



        /// <summary>
        /// Genera una gerarchia sulle colonne in base all'elemento passato (accetta anche null)
        /// </summary>
        /// <param name="GroupByElement">ElementProperty.Id1</param>
        /// <param name="SortByElement">ElementProperty.Id1</param>
        /// <param name="ShowElement">ElementProperty.Id1</param>
        /// <returns></returns>
        public static TablixColumnHierarchy CreateTablixColumnHierarchy(string GroupByElement,string SortByElement, string ShowElement) {

            var group =new Group(new GroupExpressions(new GroupExpression("")));

            if (GroupByElement != null) {
                 group =
                    new Group(
                        new GroupExpressions(new GroupExpression("=" + Expression.FieldsValue(GroupByElement, false))));
            }


            var sortExpression =
                   new SortExpression(new Value(""));

            if (SortByElement != null) {
                sortExpression =
                    new SortExpression(new Value("=" + Expression.FieldsValue(SortByElement, false)));
            }

            var sortExpressions = new SortExpressions(sortExpression);

            var textRun = new TextRun {
            };

            if (ShowElement != null) {
                textRun = new TextRun {
                    Value = "=" + Expression.FieldsValue(ShowElement, false)
                };
            }

            var paragraph = new Paragraph(new TextRuns(textRun)) { TextAlign = TextAlign.Center };
            var textbox = new Textbox(paragraph) { TextboxStyle = new TextboxStyle() };
            var header = new TablixHeader(new Inch(0.4), new CellContents(textbox));

            return new TablixColumnHierarchy(new TablixMembers(new TablixMember(group, sortExpressions, header)));
        }



        /// <summary>
        /// Genera una gerarchia sulle colonne in base all'elemento passato. inch = distanza tra le colonne
        /// </summary>
        /// <param name="GroupByElement">ElementProperty.Id1 or null</param>
        /// <param name="SortByElement">ElementProperty.Id1 or null</param>
        /// <param name="ShowElement">ElementProperty.Id1 or null</param>
        /// <param name="inch">0.4</param>
        /// <returns></returns>
        public static TablixColumnHierarchy CreateTablixColumnHierarchy(string GroupByElement, string SortByElement, string ShowElement, double inch) {

            var group = new Group(new GroupExpressions(new GroupExpression("")));

            if (GroupByElement != null) {
                group =
                   new Group(
                       new GroupExpressions(new GroupExpression("=" + Expression.FieldsValue(GroupByElement, false))));
            }


            var sortExpression =
                   new SortExpression(new Value(""));

            if (SortByElement != null) {
                sortExpression =
                    new SortExpression(new Value("=" + Expression.FieldsValue(SortByElement, false)));
            }

            var sortExpressions = new SortExpressions(sortExpression);

            var textRun = new TextRun {
            };

            if (ShowElement != null) {
                textRun = new TextRun {
                    Value = "=" + Expression.FieldsValue(ShowElement, false)
                };
            }

            var paragraph = new Paragraph(new TextRuns(textRun)) { TextAlign = TextAlign.Center };
            var textbox = new Textbox(paragraph) { TextboxStyle = new TextboxStyle() };
            var header = new TablixHeader(new Inch(inch), new CellContents(textbox));

            return new TablixColumnHierarchy(new TablixMembers(new TablixMember(group, sortExpressions, header)));
        }




        /// <summary>
        /// Genera una gerarchia sulle colonne in base all'elemento passato. inch = distanza tra le colonne. Personalizzabile il valore da visualizzare font = dimensione del font ,fontweight = spessore, color = colore, format = formato
        /// </summary>
        /// <param name="GroupByElement">ElementProperty.Id1 or null</param>
        /// <param name="SortByElement">ElementProperty.Id1 or null</param>
        /// <param name="ShowElement">ElementProperty.Id1 or null</param>
        /// <param name="inch">0.4</param>
        /// <param name="font">9</param>
        /// <param name="fontweight">FontWeight.Default</param>
        /// <param name="color">RdlColor.Black.ToString()</param>
        /// <param name="format">"n"</param>
        /// <returns></returns>
        public static TablixColumnHierarchy CreateTablixColumnHierarchy(string GroupByElement, string SortByElement, string ShowElement, double inch, int font, FontWeight fontweight, string color, string format) {

            var group = new Group(new GroupExpressions(new GroupExpression("")));

            if (GroupByElement != null) {
                group =
                   new Group(
                       new GroupExpressions(new GroupExpression("=" + Expression.FieldsValue(GroupByElement, false))));
            }


            var sortExpression =
                   new SortExpression(new Value(""));

            if (SortByElement != null) {
                sortExpression =
                    new SortExpression(new Value("=" + Expression.FieldsValue(SortByElement, false)));
            }

            var sortExpressions = new SortExpressions(sortExpression);

            var textRun = new TextRun {
            };

            if (ShowElement != null) {
                textRun = new TextRun {
                    Value = "=" + Expression.FieldsValue(ShowElement, false),
                    FontSize = new Point(font),
                    FontWeight = fontweight,
                    Color = color,
                    Format = format
                };
            }

            var paragraph = new Paragraph(new TextRuns(textRun)) { TextAlign = TextAlign.Center };
            var textbox = new Textbox(paragraph) { TextboxStyle = new TextboxStyle() };
            var header = new TablixHeader(new Inch(inch), new CellContents(textbox));

            return new TablixColumnHierarchy(new TablixMembers(new TablixMember(group, sortExpressions, header)));
        }


    }
}
