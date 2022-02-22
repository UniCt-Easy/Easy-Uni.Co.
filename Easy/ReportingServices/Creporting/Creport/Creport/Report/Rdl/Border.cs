
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
    public class Border :IElement {
        public object Style { get; set; }

        public string Color { get; set; }

        public Point Width { get; set; }

        public XElement Element {
            get {
                return this.Build();
            }
        }

        protected virtual string BorderName {
            get {
                return "Border";
            }
        }

        private XElement Build() {
            if (this.Style == null) {
                return null;
            }

            var result = new XElement(this.BorderName);
            result.Add(new XElement("Style", this.Style));
            if (this.Color != null) {
                result.Add(new XElement("Color", this.Color));
            }

            if (this.Width != null) {
                result.Add(new XElement("Width", this.Width));
            }

            return result;
        }
    }
}
