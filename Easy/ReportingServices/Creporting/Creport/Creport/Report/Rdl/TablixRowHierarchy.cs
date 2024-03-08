
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


namespace Creport.Report.Rdl {
    public class TablixRowHierarchy :ParentOf<TablixMembers> {
        public TablixRowHierarchy(TablixMembers item)
            : base(item) {
        }

        public Inch Width {
            get {
                return this.Item.Size;
            }
        }

        protected sealed override string GetRdlName() {
            return typeof(TablixRowHierarchy).GetShortName();
        }

        /// <summary>
        /// Non genera alcuna gerarchia sulle righe
        /// </summary>
        /// <returns></returns>
        public static TablixRowHierarchy CreateTablixRowHierarchy() {
            return new TablixRowHierarchy(new TablixMembers(new TablixMember()));
        }

        /// <summary>
        /// Istanzia N righe nuove pronte per essere aggiunte nel body. Non genera alcuna gerarchia sulle righe
        /// </summary>
        /// <returns></returns>
        public static TablixRowHierarchy CreateTablixRowHierarchy(int nrighe) {
            var tablixRowMembers = new TablixMembers();
            for (int i = 0; i < nrighe; i++) {tablixRowMembers.Add(new TablixMember());}
            return new TablixRowHierarchy(tablixRowMembers);
        }

        /// <summary>
        /// Genera una gerarchia sulle righe in base all'elemento passato E mostra una stringa come valore.descending=true= Z -> A inch = distanza tra le righe. Personalizzabile il valore da visualizzare font = dimensione del font, ,fontweight = spessore, color = colore, format = formato
        /// </summary>
        /// <param name="GroupByElement">ElementProperty.Id1 or null</param>
        /// <param name="SortByElement">ElementProperty.Id1 or null</param>
        /// <param name="ShowElement">Totale</param>
        /// <param name="descending">true</param>
        /// <param name="inch">0.4</param>
        /// <param name="font">9</param>
        /// <param name="fontweight">FontWeight.Default</param>
        /// <param name="color">RdlColor.Black.ToString()</param>
        /// <param name="format">"n"</param>
        /// <returns></returns>
        public static TablixRowHierarchy CreateTablixRowHierarchyString(string GroupByElement, string SortByElement, string ShowElement, bool descending, double inch, int font, FontWeight fontweight, string color, string format) {

            var group = new Group(new GroupExpressions(new GroupExpression("")));

            if (GroupByElement != null) {
                group =
                   new Group(
                       new GroupExpressions(new GroupExpression("=" + Expression.FieldsValue(GroupByElement, false))));
            }


            var sortExpression =
                   new SortExpression(new Value(""));

            if (SortByElement != null) {
                if (descending == true) {
                    sortExpression = new SortExpression(new Value("=" + Expression.FieldsValue(SortByElement, false)), new Direction("Descending"));
                }
                else {
                    sortExpression = new SortExpression(new Value("=" + Expression.FieldsValue(SortByElement, false)));
                }
            }

            var sortExpressions = new SortExpressions(sortExpression);

            var textRun = new TextRun {
            };

            if (ShowElement != null) {
                textRun = new TextRun {
                    Value = "=" + ShowElement.ConvertInReportString(),
                    FontSize = new Point(font),
                    FontWeight = fontweight,
                    Color = color,
                    Format = format
                };
            }

            var paragraph = new Paragraph(new TextRuns(textRun)) { TextAlign = TextAlign.Center };
            var textbox = new Textbox(paragraph) { TextboxStyle = new TextboxStyle() };
            var header = new TablixHeader(new Inch(inch), new CellContents(textbox));


            if (GroupByElement != null) { return new TablixRowHierarchy(new TablixMembers(new TablixMember(group, sortExpressions, header))); }
            else { return new TablixRowHierarchy(new TablixMembers(new TablixMember(null, null, header))); }

        }



        /// <summary>
        /// Genera una gerarchia sulle righe in base all'elemento passato E mostra una stringa come valore. inch = distanza tra le righe. Personalizzabile il valore da visualizzare font = dimensione del font, ,fontweight = spessore, color = colore, format = formato
        /// </summary>
        /// <param name="GroupByElement">ElementProperty.Id1 or null</param>
        /// <param name="SortByElement">ElementProperty.Id1 or null</param>
        /// <param name="ShowElement">Totale</param>
        /// <param name="inch">0.4</param>
        /// <param name="font">9</param>
        /// <param name="fontweight">FontWeight.Default</param>
        /// <param name="color">RdlColor.Black.ToString()</param>
        /// <param name="format">"n"</param>
        /// <returns></returns>
        public static TablixRowHierarchy CreateTablixRowHierarchyString(string GroupByElement, string SortByElement, string ShowElement, double inch, int font, FontWeight fontweight, string color, string format) {

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
                    Value = "=" + ShowElement.ConvertInReportString(),
                    FontSize = new Point(font),
                    FontWeight = fontweight,
                    Color = color,
                    Format = format
                };
            }

            var paragraph = new Paragraph(new TextRuns(textRun)) { TextAlign = TextAlign.Center };
            var textbox = new Textbox(paragraph) { TextboxStyle = new TextboxStyle() };
            var header = new TablixHeader(new Inch(inch), new CellContents(textbox));


            if (GroupByElement != null) { return new TablixRowHierarchy(new TablixMembers(new TablixMember(group, sortExpressions, header))); }
            else { return new TablixRowHierarchy(new TablixMembers(new TablixMember(null, null, header))); }
            
        }




        /// <summary>
        /// Genera una gerarchia sulle righe in base all'elemento passato Con funzione di visiblità. inch = distanza tra le righe. Personalizzabile il valore da visualizzare font = dimensione del font, ,fontweight = spessore, color = colore, format = formato, hide = true nascondi
        /// </summary>
        /// <param name="GroupByElement">ElementProperty.Id1 or null</param>
        /// <param name="SortByElement">ElementProperty.Id1 or null</param>
        /// <param name="ShowElement">ElementProperty.Id1 or null</param>
        /// <param name="inch">0.4</param>
        /// <param name="font">9</param>
        /// <param name="fontweight">FontWeight.Default</param>
        /// <param name="color">RdlColor.Black.ToString()</param>
        /// <param name="format">"n"</param>
        /// <param name="hide">true</param>
        /// <returns></returns>
        public static TablixRowHierarchy CreateTablixRowHierarchy(string GroupByElement, string SortByElement, string ShowElement, double inch, int font, FontWeight fontweight, string color, string format, bool hide) {

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
            var textbox = new Textbox(paragraph) { Visibility = new Visibility(hide, null), TextboxStyle = new TextboxStyle() };
            var header = new TablixHeader(new Inch(inch), new CellContents(textbox));

            return new TablixRowHierarchy(new TablixMembers(new TablixMember(group, sortExpressions, header)));
        }




        /// <summary>
        /// DA PROBLEMI :Genera una gerarchia sulle righe in base all'elemento passato con funzione di drilldown e gestione del numero righe. inch = distanza tra le righe. Personalizzabile il valore da visualizzare font = dimensione del font, ,fontweight = spessore, color = colore, format = formato, hide = true nascondi, itemtoggle = oggetto del drilldown, nrighe = numero righe
        /// </summary>
        /// <param name="GroupByElement">ElementProperty.Id1 or null</param>
        /// <param name="SortByElement">ElementProperty.Id1 or null</param>
        /// <param name="ShowElement">ElementProperty.Id1 or null</param>
        /// <param name="inch">0.4</param>
        /// <param name="font">9</param>
        /// <param name="fontweight">FontWeight.Default</param>
        /// <param name="color">RdlColor.Black.ToString()</param>
        /// <param name="format">"n"</param>
        /// <param name="hide">true</param>
        /// <param name="itemtoggle">"Texbox1"</param>
        /// <param name="nrighe">2</param>
        /// <returns></returns>
        public static TablixRowHierarchy CreateTablixRowHierarchy(string GroupByElement, string SortByElement, string ShowElement, double inch, int font, FontWeight fontweight, string color, string format, bool hide, string itemtoggle,int nrighe) {

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
            var textbox = new Textbox(paragraph) { Visibility = new Visibility(hide, itemtoggle), TextboxStyle = new TextboxStyle() };
            var header = new TablixHeader(new Inch(inch), new CellContents(textbox));

            var tablixRowMembers = new TablixMembers();

            tablixRowMembers.Add(new TablixMember(group, sortExpressions, header));

            textRun = new TextRun { };
            paragraph = new Paragraph(new TextRuns(textRun)) { TextAlign = TextAlign.Center };

            for (int i = 0; i < nrighe-1; i++) {
                textbox = new Textbox(paragraph) {  TextboxStyle = new TextboxStyle() };
                header = new TablixHeader(new Inch(inch), new CellContents(textbox));
                tablixRowMembers.Add(new TablixMember(null,null,header));
            }

            return new TablixRowHierarchy(tablixRowMembers);
        }




        /// <summary>
        /// Genera una gerarchia sulle righe in base all'elemento passato Con funzione di drilldown. inch = distanza tra le colonne. Personalizzabile il valore da visualizzare,inch distanza tra le righe font = dimensione del font, ,fontweight = spessore, color = colore, format = formato, visibility = espressione di visibilità, itemtoggle = oggetto del drilltown
        /// </summary>
        /// <param name="GroupByElement">ElementProperty.Id1 or null</param>
        /// <param name="SortByElement">ElementProperty.Id1 or null</param>
        /// <param name="ShowElement">ElementProperty.Id1 or null</param>
        /// <param name="inch">0.4</param>
        /// <param name="font">9</param>
        /// <param name="fontweight">FontWeight.Default</param>
        /// <param name="color">RdlColor.Black.ToString()</param>
        /// <param name="format">"n"</param>
        /// <param name="visibility">"IIF(1=1,true,false)"</param>
        /// <param name="itemtoggle">"Texbox1"</param>
        /// <returns></returns>
        public static TablixRowHierarchy CreateTablixRowHierarchy(string GroupByElement, string SortByElement, string ShowElement, double inch, int font, FontWeight fontweight, string color, string format, string visibility, string itemtoggle) {

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
            var textbox = new Textbox(paragraph) { Visibility = new Visibility("="+visibility, itemtoggle), TextboxStyle = new TextboxStyle() };
            var header = new TablixHeader(new Inch(inch), new CellContents(textbox));

            return new TablixRowHierarchy(new TablixMembers(new TablixMember(group, sortExpressions, header)));
        }




        /// <summary>
        /// Genera una gerarchia sulle righe in base all'elemento passato Con funzione di drilldown. inch = distanza tra le colonne. Personalizzabile il valore da visualizzare,inch distanza tra le righe font = dimensione del font, ,fontweight = spessore, color = colore, format = formato, hide = true nascondi, itemtoggle = oggetto del drilltown
        /// </summary>
        /// <param name="GroupByElement">ElementProperty.Id1 or null</param>
        /// <param name="SortByElement">ElementProperty.Id1 or null</param>
        /// <param name="ShowElement">ElementProperty.Id1 or null</param>
        /// <param name="inch">0.4</param>
        /// <param name="font">9</param>
        /// <param name="fontweight">FontWeight.Default</param>
        /// <param name="color">RdlColor.Black.ToString()</param>
        /// <param name="format">"n"</param>
        /// <param name="hide">true</param>
        /// <param name="itemtoggle">"Texbox1"</param>
        /// <returns></returns>
        public static TablixRowHierarchy CreateTablixRowHierarchy(string GroupByElement, string SortByElement, string ShowElement, double inch, int font, FontWeight fontweight, string color, string format,bool hide,string itemtoggle) {

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
            var textbox = new Textbox(paragraph) { Visibility=new Visibility(hide,itemtoggle), TextboxStyle = new TextboxStyle() };
            var header = new TablixHeader(new Inch(inch), new CellContents(textbox));

            return new TablixRowHierarchy(new TablixMembers(new TablixMember(group, sortExpressions, header)));
        }


        /// <summary>
        /// Genera una gerarchia sulle righe in base all'elemento passato. inch = distanza tra le colonne. Personalizzabile il valore da visualizzare inch distanza tra le righe, font = dimensione del font, ,fontweight = spessore, color = colore, format = formato
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
        public static TablixRowHierarchy CreateTablixRowHierarchy(string GroupByElement, string SortByElement, string ShowElement, double inch, int font, FontWeight fontweight, string color, string format) {

            var group = new Group(new GroupExpressions(new GroupExpression("")));

            if (GroupByElement != null) {
                group =
                   new Group(
                       new GroupExpressions(new GroupExpression("=" + Expression.FieldsValue(GroupByElement, false))));
            }


            var sortExpression =
                   new SortExpression(new Value(""));

            if (SortByElement != null) {
                    sortExpression = new SortExpression(new Value("=" + Expression.FieldsValue(SortByElement, false)));
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

            return new TablixRowHierarchy(new TablixMembers(new TablixMember(group, sortExpressions, header)));
        }



        /// <summary>
        /// Genera una gerarchia sulle righe in base all'elemento passato. inch = distanza tra le colonne. Personalizzabile il valore da visualizzare descending=true= Z -> A, inch distanza tra le righe, font = dimensione del font, ,fontweight = spessore, color = colore, format = formato
        /// </summary>
        /// <param name="GroupByElement">ElementProperty.Id1 or null</param>
        /// <param name="SortByElement">ElementProperty.Id1 or null</param>
        /// <param name="ShowElement">ElementProperty.Id1 or null</param>
        /// <param name="descending">true</param>
        /// <param name="inch">0.4</param>
        /// <param name="font">9</param>
        /// <param name="fontweight">FontWeight.Default</param>
        /// <param name="color">RdlColor.Black.ToString()</param>
        /// <param name="format">"n"</param>
        /// <returns></returns>
        public static TablixRowHierarchy CreateTablixRowHierarchy(string GroupByElement, string SortByElement, string ShowElement, bool descending,double inch, int font, FontWeight fontweight, string color, string format) {

            var group = new Group(new GroupExpressions(new GroupExpression("")));

            if (GroupByElement != null) {
                group =
                   new Group(
                       new GroupExpressions(new GroupExpression("=" + Expression.FieldsValue(GroupByElement, false))));
            }


            var sortExpression =
                   new SortExpression(new Value("")); 

            if (SortByElement != null) {
                if (descending == true) { sortExpression = new SortExpression(new Value("=" + Expression.FieldsValue(SortByElement, false)),new Direction("Descending"));
                }
                else {sortExpression = new SortExpression(new Value("=" + Expression.FieldsValue(SortByElement, false)));
                }
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
            var textbox = new Textbox(paragraph) {TextboxStyle = new TextboxStyle() };
            var header = new TablixHeader(new Inch(inch), new CellContents(textbox));

            return new TablixRowHierarchy(new TablixMembers(new TablixMember(group, sortExpressions, header)));
        }




        /// <summary>
        /// Genera una gerarchia sulle righe in base all'elemento passato
        /// </summary>
        /// <param name="Element">ElementProperty.Id1</param>
        /// <returns></returns>
        public static TablixRowHierarchy CreateTablixRowHierarchy(string Element) {
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

            return new TablixRowHierarchy(new TablixMembers(new TablixMember(group, sortExpressions, header)));
        }



        /// <summary>
        /// Genera una gerarchia sulle righe in base all'elemento passato (accetta anche null)
        /// </summary>
        /// <param name="GroupByElement">ElementProperty.Id1</param>
        /// <param name="SortByElement">ElementProperty.Id1</param>
        /// <param name="ShowElement">ElementProperty.Id1</param>
        /// <returns></returns>
        public static TablixRowHierarchy CreateTablixRowHierarchy(string GroupByElement, string SortByElement, string ShowElement) {

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
            var header = new TablixHeader(new Inch(0.4), new CellContents(textbox));

            return new TablixRowHierarchy(new TablixMembers(new TablixMember(group, sortExpressions, header)));
        }



        /// <summary>
        /// Genera una gerarchia sulle righe in base all'elemento passato. inch = distanza tra le colonne
        /// </summary>
        /// <param name="GroupByElement">ElementProperty.Id1 or null</param>
        /// <param name="SortByElement">ElementProperty.Id1 or null</param>
        /// <param name="ShowElement">ElementProperty.Id1 or null</param>
        /// <param name="inch">0.4</param>
        /// <returns></returns>
        public static TablixRowHierarchy CreateTablixRowHierarchy(string GroupByElement, string SortByElement, string ShowElement, double inch) {

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

            return new TablixRowHierarchy(new TablixMembers(new TablixMember(group, sortExpressions, header)));
        }

    }
}
