/*
    Easy
    Copyright (C) 2019 Università degli Studi di Catania (www.unict.it)

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

ï»¿using System.Xml.Linq;

namespace Creport.Report.Rdl {
    public class BackgroundImage :IElement {
        private readonly Source source;
        private readonly BackgroundRepeat backgroundRepeat;
        private readonly string value;

        public BackgroundImage(Source source, BackgroundRepeat backgroundRepeat, string value) {
            this.source = source;
            this.backgroundRepeat = backgroundRepeat;
            this.value = value;
        }

        public XElement Element {
            get {
                return this.Build();
            }
        }

        private XElement Build() {
            return new XElement(
                typeof(BackgroundImage).GetShortName(),
                new XElement("Source", this.source),
                new XElement("BackgroundRepeat", this.backgroundRepeat),
                new XElement("Value", this.value));
        }
    }
}
