
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
    public class TextRun :IElement {
        public string Value { get; set; }

        public string FontFamily { get; set; }

        public Point FontSize { get; set; }

        public FontWeight FontWeight { get; set; }

        public string Color { get; set; }

        public MarkupType MarkupType { get; set; }

        public string Format { get; set; }

        public XElement Element {
            get {
                return this.Build();
            }
        }

        private XElement Build() {
            var result = new XElement(typeof(TextRun).GetShortName(), new XElement("Value", this.Value));
            this.ConfigureMarkupType(result);
            this.ConfigureStyle(result);
            return result;
        }

        private void ConfigureStyle(XElement textRun) {
            var style = new XElement("Style");

            if (this.FontFamily != null) {
                style.Add(new XElement("FontFamily", this.FontFamily));
            }

            if (this.FontSize != null) {
                style.Add(new XElement("FontSize", this.FontSize));
            }

            if (this.FontWeight != FontWeight.Default) {
                style.Add(new XElement("FontWeight", this.FontWeight));
            }

            if (this.Color != null) {
                style.Add(new XElement("Color", this.Color));
            }

            if (this.Format != null) {
                style.Add(new XElement("Format", this.Format));
            }

            if (style.HasElements) {
                textRun.Add(style);
            }
        }

        private void ConfigureMarkupType(XElement textRun) {
            if (this.MarkupType != MarkupType.None) {
                textRun.Add(new XElement("MarkupType", this.MarkupType));
            }
        }
    }
}
