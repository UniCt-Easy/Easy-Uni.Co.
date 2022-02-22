
/*
Easy
Copyright (C) 2022 Università degli Studi di Catania (www.unict.it)
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


using Microsoft.Reporting.WinForms;
using System;
using System.IO;

namespace Creport {
    public class ReportGenerator {
        protected readonly Report.Rdl.Report Report = new Report.Rdl.Report();
        protected readonly ReportDataSourceCollection DataSources;

        private readonly LocalReport localReport;

        public ReportGenerator(LocalReport localReport) {
            if (localReport == null) {
                throw new ArgumentNullException("localReport");
            }

            this.localReport = localReport;
            this.DataSources = localReport.DataSources;
        }

        public virtual void Run() {
            ////this.Report.Element.Save(Console.Out);  // Utile per il debug se si vuole vedere il report il console.
            ////Console.WriteLine(Report.Element);      // Utile per il debug se si vuole vedere il report il console.
            this.Report.Element.Save("x.rdlc"); //Ti salva il report in D:\Easy\ReportingServices\Creporting\Creport\Creport\bin\Debug
            this.LoadReportDefinition();
        }

        private void LoadReportDefinition() {
            using (var stream = new MemoryStream()) {
                this.Report.Element.Save(stream);
                stream.Position = 0;
                this.localReport.LoadReportDefinition(stream);
            }
        }
    }
}
