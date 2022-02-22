
/*
Easy
Copyright (C) 2022 Universit� degli Studi di Catania (www.unict.it)
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
    public class Rectangle :ReportItemsContainer {
        private static int index;
        private readonly string name;
        private readonly string rdlName;

        public Rectangle() {
            this.rdlName = typeof(Rectangle).GetShortName();
            this.name = this.rdlName + ++index;
        }

        protected override XElement Build() {
            var result = new XElement(
                this.rdlName,
                new XAttribute("Name", this.name),
                new XElement("KeepTogether", true),
                this.ReportItems.Element);
            this.ConfigureTop(result);
            this.ConfigureLeft(result);
            this.ConfigureWidth(result);
            this.ConfigureContainerHeight(result);

            return result;
        }
    }
}
