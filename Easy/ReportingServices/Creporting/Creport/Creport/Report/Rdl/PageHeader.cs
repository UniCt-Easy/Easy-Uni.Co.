
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


using System.Xml.Linq;

namespace Creport.Report.Rdl {
    public class PageHeader:ReportItemsContainer {

        public PageHeader(Inch Height, object PrintOnFirstPage, object PrintOnLastPage) {
            this.height = Height;
            this.printOnFirstPage = PrintOnFirstPage;
            this.printOnLastPage = PrintOnLastPage;
            Build();
        }
        

        public Inch height { get; private set; }
        public object printOnFirstPage { get; private set; }

        public object printOnLastPage { get; private set; }

        protected override XElement Build() {
            var result = new XElement(typeof(PageHeader).GetShortName());
            this.Height(result);
            this.PrintOnFirstPage(result);
            this.PrintOnLastPage(result);
            result.Add(this.ReportItems.Element);
            return result;
        }

        private new void Height(XElement PageHeader) {
            if (this.height != null) {
                PageHeader.Add(new XElement("Height", this.height));
            }
        }

        private void PrintOnFirstPage(XElement PageHeader) {
            if (this.printOnFirstPage != null) {
                PageHeader.Add(new XElement("PrintOnFirstPage", this.printOnFirstPage));
            }
        }

        private void PrintOnLastPage(XElement PageHeader) {
            if (this.printOnLastPage != null) {
                PageHeader.Add(new XElement("PrintOnLastPage", this.printOnLastPage));
            }
        }


    }
}
