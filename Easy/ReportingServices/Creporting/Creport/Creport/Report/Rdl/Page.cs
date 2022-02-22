
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


using System.Xml.Linq;

namespace Creport.Report.Rdl {
    public class Page :IElement {

        public Inch LeftMargin { get; set; }

        public Inch RightMargin { get; set; }

        public Inch TopMargin { get; set; }

        public Inch BottomMargin { get; set; }

        public XElement Element {
            get {
                return this.Build();
            }
        }

        public XElement Elementh(PageHeader PageHeader) {
                return this.Build(PageHeader);
        }

        public XElement Elementf(PageFooter PageFooter) {
            return this.Build(PageFooter);
        }

        public XElement Elementhf(PageHeader PageHeader,PageFooter PageFooter) {
            return this.Build(PageHeader,PageFooter);
        }


        public Page() {
        }

        private XElement Build(PageHeader PageHeader, PageFooter PageFooter) {
            return new XElement(
                typeof(Page).GetShortName(),
                PageHeader.Element,
                PageFooter.Element,
                new XElement("LeftMargin", this.LeftMargin),
                new XElement("RightMargin", this.RightMargin),
                new XElement("TopMargin", this.TopMargin),
                new XElement("BottomMargin", this.BottomMargin));
        }


        private XElement Build(PageFooter PageFooter) {
            return new XElement(
                typeof(Page).GetShortName(),
                PageFooter.Element,
                new XElement("LeftMargin", this.LeftMargin),
                new XElement("RightMargin", this.RightMargin),
                new XElement("TopMargin", this.TopMargin),
                new XElement("BottomMargin", this.BottomMargin));
        }


        private XElement Build(PageHeader PageHeader) {
            return new XElement(
                typeof(Page).GetShortName(),
                PageHeader.Element,
                new XElement("LeftMargin", this.LeftMargin),
                new XElement("RightMargin", this.RightMargin),
                new XElement("TopMargin", this.TopMargin),
                new XElement("BottomMargin", this.BottomMargin));
        }



        private XElement Build() {
            return new XElement(
                typeof(Page).GetShortName(),
                //new XElement("PageHeader", this.pageHeader),
                //new PageHeader(new Inch(2), true,true).Element,
                new XElement("LeftMargin", this.LeftMargin),
                new XElement("RightMargin", this.RightMargin),
                new XElement("TopMargin", this.TopMargin),
                new XElement("BottomMargin", this.BottomMargin));
        }
    }
}
