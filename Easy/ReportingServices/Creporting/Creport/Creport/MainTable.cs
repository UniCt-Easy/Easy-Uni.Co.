
/*
Easy
Copyright (C) 2021 Università degli Studi di Catania (www.unict.it)
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


using Creport.Report.Rdl;

namespace Creport {
    public class MainTable {
        

      public static ReportItem Create(string dataSetName,bool Annodecrescente, bool Numerodecrescente) {
            return new Tablix(
                TablixColumnHierarchy.CreateTablixColumnHierarchy(),
                TablixRowHierarchy.CreateTablixRowHierarchy(ElementProperty.Id1, ElementProperty.Id1, ElementProperty.Id1, Annodecrescente, 0.7,9,FontWeight.Bold,RdlColor.Red.ToString(),null), 
                CreateTablixBody(dataSetName, Numerodecrescente), 
                dataSetName) {
                Top = new Inch(0.025),
                Left = new Inch(0.025),
                Style = TablixStyle.CreateTablixStyle(RdlColor.Black.ToString(), BorderStyle.Solid.ToString(), 2, System.Drawing.Color.AliceBlue.Name)
            };
        }

        private static TablixBody CreateTablixBody(string dataSetName, bool Numerodecrescente) {
            var rectangle = new Rectangle();
            rectangle.AddReportItem(MainTable.CreateDrillDown(dataSetName, Numerodecrescente));
            var tablixCells = new TablixCells(new TablixCell(new CellContents(rectangle)));
            var tablixRows = new TablixRows(new TablixRow(new Inch(0.4), tablixCells));
            var tablixColumns = new TablixColumns(new TablixColumn(new Width(new Inch(1.05))));
            return new TablixBody(tablixColumns, tablixRows);
        }

        public static ReportItem CreateDrillDown(string dataSetName,bool Numerodecrescente) {

            int column_number = 1;

            return new Tablix(
                TablixColumnHierarchy.CreateTablixColumnHierarchy(column_number),
                TablixRowHierarchy.CreateTablixRowHierarchy(ElementProperty.Id2, ElementProperty.Id2, ElementProperty.Id2, Numerodecrescente,1, 9, FontWeight.Bold, RdlColor.Red.ToString(), null),
                CreateTablixBodyDrillD(column_number),
                dataSetName) {
                Top = new Inch(0.025),
                Left = new Inch(0.025),
                Style = TablixStyle.CreateTablixStyle(RdlColor.Black.ToString(), BorderStyle.Solid.ToString(), 1, System.Drawing.Color.AliceBlue.Name)
            };
        }



        private static TablixBody CreateTablixBodyDrillD(int column_number) {
            var tablixRows = new TablixRows();

            tablixRows.Add(TablixRow.CreateTablixRow(new TablixCell[] {
                //TablixCell.Create(ElementProperty.Id2, false, null, 9, FontWeight.SemiBold, RdlColor.Red.ToString(), null, TextAlign.Center),
                TablixCell.Create(ElementProperty.Name, true, null, 9, FontWeight.Normal, RdlColor.Black.ToString(), "n", TextAlign.Center)
                //TablixCell.Create(ElementProperty.Id2, false, null, 9, FontWeight.SemiBold, RdlColor.Red.ToString(), null, TextAlign.Center, true, "Textbox1"),
                //TablixCell.Create(ElementProperty.Name, true, null, 9, FontWeight.Normal, RdlColor.Black.ToString(), "n", TextAlign.Center, true, "Textbox1")
            }));
            
            var tablixColumns = TablixColumns.CreateColumn(column_number);
            return new TablixBody(tablixColumns, tablixRows);
        }













        public static ReportItem Create2(string dataSetName,bool decrescente) {
            return new Tablix(
                TablixColumnHierarchy.CreateTablixColumnHierarchy(2),
                TablixRowHierarchy.CreateTablixRowHierarchyString(ElementProperty.Id1, ElementProperty.Id1,"Totale", decrescente,0.73, 11, FontWeight.ExtraBold, RdlColor.Red.ToString(), null),
                //TablixRowHierarchy.CreateTablixRowHierarchy(ElementProperty.Id1, ElementProperty.Id1, ElementProperty.Id1, 0.7, 11, FontWeight.ExtraBold, RdlColor.Red.ToString(), null),
                CreateTablixBody2(),
                dataSetName) {
                Top = new Inch(0.025),
                Left = new Inch(0.025),
                Style = TablixStyle.CreateTablixStyle(RdlColor.Black.ToString(), BorderStyle.Double.ToString(), 2, System.Drawing.Color.LightGreen.Name)
            };
        }



        private static TablixBody CreateTablixBody2() {
            var tablixRows = new TablixRows();
            tablixRows.Add(TablixRow.CreateTablixRow(new TablixCell[] {
                TablixCell.Create(ElementProperty.Id1, false, null, 9, FontWeight.SemiBold, RdlColor.Red.ToString(), null, TextAlign.Center),
                CreateC()//TablixCell.Create(ElementProperty.Name, true, null, 9, FontWeight.SemiBold, RdlColor.Black.ToString(), "n", TextAlign.Center)
            }));
            TablixColumns tablixColumns = TablixColumns.CreateColumn(2);
            return new TablixBody(tablixColumns, tablixRows);
        }



        private static TablixCell CreateC() {

            var textRun = new TextRun {
                Value = "=" + Expression.FieldsValue(ElementProperty.Name, true),
                FontSize = new Point(9),
                FontWeight = FontWeight.SemiBold,
                Color = RdlColor.Black.ToString(),
                Format = "n",
            };

            var paragraph = new Paragraph(new TextRuns(textRun)) { TextAlign = TextAlign.Center };
            
            var textbox = new Textbox(paragraph) { TextboxStyle = new TextboxStyle(), ActionInfo = new ActionInfo(new Action("report.rdlc")) };

            return (new TablixCell(new CellContents(textbox)));
        }













        //private static TablixBody CreateTablixBody(string dataSetName) {
        //    var rectangle = new Rectangle();
        //    rectangle.AddReportItem(ElementCell.Create(dataSetName));
        //    var tablixColumns = new TablixColumns(new TablixColumn(new Width(new Inch(1.05))));
        //    var tablixCells = new TablixCells(new TablixCell(new CellContents(rectangle)));
        //    var tablixRows = new TablixRows(new TablixRow(new Inch(0.4), tablixCells));
        //    return new TablixBody(tablixColumns, tablixRows);
        //}





        //private static TablixColumnHierarchy CreateTablixColumnHierarchy() {
        //    //var group =
        //    //    new Group(
        //    //        new GroupExpressions(new GroupExpression("=" + Expression.FieldsValue(ElementProperty.Id1, false))));

        //    //var sortExpression =
        //    //    new SortExpression(new Value("=" + Expression.FieldsValue(ElementProperty.Id1, false)));
        //    //var sortExpressions = new SortExpressions(sortExpression);

        //    //var textRun = new TextRun {
        //    //    Value = "=" + Expression.FieldsValue(ElementProperty.Id1, false),
        //    //    FontWeight = FontWeight.Default,
        //    //    Color = RdlColor.Red.ToString()
        //    //};
        //    //var paragraph = new Paragraph(new TextRuns(textRun)) { TextAlign = TextAlign.Center };
        //    //var textbox = new Textbox(paragraph) { TextboxStyle = new TextboxStyle() };
        //    //var header = new TablixHeader(new Inch(0.4), new CellContents(textbox));

        //    return new TablixColumnHierarchy(new TablixMembers(new TablixMember()));
        //}

        //private static TablixRowHierarchy CreateTablixRowHierarchy() {
        //    var tablixRowMembers = new TablixMembers();
        //    tablixRowMembers.Add(new TablixMember());
        //    //tablixRowMembers.Add(new TablixMember());
        //    return new TablixRowHierarchy(tablixRowMembers);
        //}


        //SE SI DECOMMENTA VERRA' USATA ElementCell oltre al codice quì sotto. SE SI VUOLE DECOMMENTARE QUESTO, COMMENTARE IL CODICE SOPRASTANTE!!!!!

        //public static ReportItem Create(string dataSetName) {
        //    return new Tablix(
        //        CreateTablixCorner(),
        //        CreateTablixColumnHierarchy(),
        //        CreateTablixRowHierarchy(),
        //        CreateTablixBody(dataSetName),
        //        dataSetName);
        //}

        //private static TablixCorner CreateTablixCorner() {
        //    var textRuns1 = new TextRuns(new TextRun { Value = "", FontWeight = FontWeight.Bold });
        //    textRuns1.Add(new TextRun { Value = "", FontFamily = "Wingdings" });
        //    //var textRuns2 = new TextRuns(new TextRun { Value = "", FontFamily = "Wingdings" });
        //    //textRuns2.Add(new TextRun { Value = "", FontWeight = FontWeight.Bold });

        //    var textbox = new Textbox(new Paragraph(textRuns1)) { TextboxStyle = new TextboxStyle() };
        //    textbox.AddParagraph(new Paragraph(textRuns2));
        //    return
        //        new TablixCorner(
        //            new TablixCornerRows(new TablixCornerRow(new TablixCornerCell(new CellContents(textbox)))));
        //}

        //private static TablixColumnHierarchy CreateTablixColumnHierarchy() {
        //    var group =
        //        new Group(
        //            new GroupExpressions(new GroupExpression("=" + Expression.FieldsValue(ElementProperty.Id1))));

        //    var sortExpression =
        //        new SortExpression(new Value("=" + Expression.FieldsValue(ElementProperty.Id1)));
        //    var sortExpressions = new SortExpressions(sortExpression);

        //    var textRun = new TextRun {
        //        Value = "=" + Expression.FieldsValue(ElementProperty.Id1),
        //        FontWeight = FontWeight.Default,
        //        Color = RdlColor.Red.ToString()
        //    };
        //    var paragraph = new Paragraph(new TextRuns(textRun)) { TextAlign = TextAlign.Center };
        //    var textbox = new Textbox(paragraph) { TextboxStyle = new TextboxStyle() };
        //    var header = new TablixHeader(new Inch(0.4), new CellContents(textbox));

        //    return new TablixColumnHierarchy(new TablixMembers(new TablixMember(group, sortExpressions, header)));
        //}

        //private static TablixRowHierarchy CreateTablixRowHierarchy() {
        //    var group =
        //        new Group(
        //            new GroupExpressions(new GroupExpression("=" + Expression.FieldsValue(ElementProperty.Id2))));

        //    var sortExpression =
        //        new SortExpression(new Value("=" + Expression.FieldsValue(ElementProperty.Id2)));
        //    var sortExpressions = new SortExpressions(sortExpression);

        //    var textRun = new TextRun {
        //        Value = "=" + Expression.FieldsValue(ElementProperty.Id2),
        //        FontWeight = FontWeight.Default,
        //        Color = RdlColor.Red.ToString()
        //    };
        //    var paragraph = new Paragraph(new TextRuns(textRun)) { TextAlign = TextAlign.Center };
        //    var textbox = new Textbox(paragraph) {
        //        TextboxStyle = new TextboxStyle { VerticalAlign = VerticalAlign.Middle }
        //    };
        //    var header = new TablixHeader(new Inch(0.7), new CellContents(textbox));

        //    return new TablixRowHierarchy(new TablixMembers(new TablixMember(group, sortExpressions, header)));
        //}


        //private static TablixRowHierarchy CreateTablixRowHierarchy() {
        //    var tablixRowMembers = new TablixMembers();
        //    tablixRowMembers.Add(new TablixMember());
        //    //tablixRowMembers.Add(new TablixMember());
        //    return new TablixRowHierarchy(tablixRowMembers);
        //}



        //private static TablixBody CreateTablixBody(string dataSetName) {
        //    var rectangle = new Rectangle();
        //    rectangle.AddReportItem(ElementCell.Create(dataSetName));
        //    var tablixColumns = new TablixColumns(new TablixColumn(new Width(new Inch(1.05))));
        //    var tablixCells = new TablixCells(new TablixCell(new CellContents(rectangle)));
        //    var tablixRows = new TablixRows(new TablixRow(new Inch(0.4), tablixCells));
        //    return new TablixBody(tablixColumns, tablixRows);
        //}
    }
}
