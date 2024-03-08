
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


using System.Xml.Linq;

namespace Creport.Report.Rdl {
    public class ReportSection :IElement {
        private readonly Body body = new Body();
        private readonly Inch width = new Inch(2.5);
        private readonly Page page = new Page() {
            LeftMargin = new Inch(1),
            RightMargin = new Inch(1),
            TopMargin = new Inch(1),
            BottomMargin = new Inch(1)
        };
        private readonly PageHeader pageHeader;
        private readonly PageFooter pageFooter;

        public ReportSection() {
        }

        public ReportSection(Body body) {
            this.body = body;
        }

        public ReportSection(Body body, PageHeader pageHeader) {
            this.body = body;
            this.pageHeader = pageHeader;
        }

        public ReportSection(Body body, PageFooter pageFooter) {
            this.body = body;
            this.pageFooter = pageFooter;
        }

        public ReportSection(Body body, PageHeader pageHeader, PageFooter pageFooter) {
            this.body = body;
            this.pageHeader = pageHeader;
            this.pageFooter = pageFooter;
        }


        public XElement Element {
            get {

                if (this.pageHeader != null && this.pageFooter != null) return this.Build4();
                else if (this.pageFooter != null) return this.Build3();
                else if (this.pageHeader != null) return this.Build2();
                else return this.Build();
            }
        }

        private XElement Build() {
            return new XElement(
                typeof(ReportSection).GetShortName(),
                this.body.Element,
                this.page.Element,
                new XElement("Width", this.width));
        }

        private XElement Build2() {
            return new XElement(
                typeof(ReportSection).GetShortName(),
                this.body.Element,
                this.page.Elementh(pageHeader),
                new XElement("Width", this.width));
        }

        private XElement Build3() {
            return new XElement(
                typeof(ReportSection).GetShortName(),
                this.body.Element,
                this.page.Elementf(pageFooter),
                new XElement("Width", this.width));
        }

        private XElement Build4() {
            return new XElement(
                typeof(ReportSection).GetShortName(),
                this.body.Element,
                this.page.Elementhf(pageHeader, pageFooter),
                new XElement("Width", this.width));
        }
    }
}
