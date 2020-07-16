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
    public class Report {
        private readonly DataSources datasources = new DataSources();
        private readonly DataSets dataSets = new DataSets();
        private readonly ReportSections reportSections = new ReportSections();
        private readonly EmbeddedImages embeddedImages = new EmbeddedImages();

        public XElement Element {
            get {
                return this.Build();
            }
        }

        public void AddDataSet(DataSet dataSet) {
            this.dataSets.Add(dataSet);
        }

        public void AddReportSection(ReportSection reportSection) {
            this.reportSections.Add(reportSection);
        }

        public void AddEmbeddedImage(EmbeddedImage embeddedImage) {
            this.embeddedImages.Add(embeddedImage);
        }

        private static void AddNamespace(XElement report) {
            XNamespace ns = "http://schemas.microsoft.com/sqlserver/reporting/2010/01/reportdefinition";

            //Volendo si può anche usare il 2008, non ho avuto grossi problemi, ma meglio il 2010 essendo più recente
            //In ogni caso deve essere coerente con la versione dei report usati in generale, server e locali
            //http://schemas.microsoft.com/sqlserver/reporting/2008/01/reportdefinition
            //Quando uscirà in modo ufficiale il 2016 bisogna provare ad usarlo, l'url dovrebbe essere 
            //http://schemas.microsoft.com/sqlserver/reporting/2016/01/reportdefinition

            foreach (var e in report.DescendantsAndSelf()) {
                if (e.Name != null && e.Name.NamespaceName == string.Empty) {
                    e.Name = ns + e.Name.LocalName;
                }
            }
        }

        private XElement Build() {
            var result = new XElement(
                typeof(Report).GetShortName(),
                this.datasources.Element,
                this.dataSets.Element,
                this.reportSections.Element,
                this.embeddedImages.Element);
            AddNamespace(result);
            return result;
        }
    }
}
