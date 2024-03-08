
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


using Creport.Report.Rdl;
using Microsoft.Reporting.WinForms;


namespace Creport {
    public class DataGridReportGenerator :ReportGenerator {
        public DataGridReportGenerator(LocalReport localReport)
            : base(localReport) {
        }


        public void Run(bool Annodecrescente, bool Numerodecrescente) {
            var dataSetForMainTable = CreateDataSet();
            var mainTable = MainTable.Create(dataSetForMainTable.Name, Annodecrescente, Numerodecrescente);
            var body = new Body();
            body.AddReportItem(mainTable);
            mainTable = MainTable.Create2(dataSetForMainTable.Name, Annodecrescente);
            body.AddReportItem(mainTable);

            //var pageHeader = new PageHeader(new Inch(0.5), true, true);
            //var textRuns1 = new TextRuns(new TextRun { Value = "Prova Header" });
            //var textbox = new Textbox(new Paragraph(textRuns1)) { TextboxStyle = new TextboxStyle() };
            //pageHeader.AddReportItem(textbox);

            //var pageFooter = new PageFooter(new Inch(0.5), true, true);
            //textRuns1 = new TextRuns(new TextRun { Value = "Prova Footer" });
            //textbox = new Textbox(new Paragraph(textRuns1)) { TextboxStyle = new TextboxStyle() };
            //pageFooter.AddReportItem(textbox);
            //this.Report.AddReportSection(new ReportSection(body, pageHeader, pageFooter));

            this.Report.AddReportSection(new ReportSection(body));
            this.Report.AddDataSet(dataSetForMainTable);
            this.DataSources.Add(new ReportDataSource(dataSetForMainTable.Name, MainTableDataSource.Create()));
            base.Run();
        }

        private static DataSet CreateDataSet() {
            var dataSet = new DataSet();
            dataSet.AddField(ElementProperty.Id1);
            dataSet.AddField(ElementProperty.Id2);
            dataSet.AddField(ElementProperty.Name);
            dataSet.AddField(ElementProperty.Tipo);
            return dataSet;
        }
    }
}
