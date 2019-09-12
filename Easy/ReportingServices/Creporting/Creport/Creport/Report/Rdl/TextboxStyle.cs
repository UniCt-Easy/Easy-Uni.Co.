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
    public class TextboxStyle :Style {
        public TextboxStyle() {
            this.PaddingLeft = new Point(2);
            this.PaddingRight = new Point(2);
            this.PaddingTop = new Point(2);
            this.PaddingBottom = new Point(2);
        }

        public Point PaddingLeft { get; set; }

        public Point PaddingRight { get; set; }

        public Point PaddingTop { get; set; }

        public Point PaddingBottom { get; set; }

        public VerticalAlign VerticalAlign { get; set; }

        protected override XElement Build() {
            var result = base.Build();
            this.ConfigurePaddingTop(result);
            this.ConfigurePaddingBottom(result);
            this.ConfigurePaddingLeft(result);
            this.ConfigurePaddingRight(result);
            this.ConfigureVerticalAlign(result);
            return result;
        }

        private void ConfigurePaddingTop(XElement textboxStyle) {
            if (this.PaddingTop != null) {
                textboxStyle.Add(new XElement("PaddingTop", this.PaddingTop));
            }
        }

        private void ConfigurePaddingBottom(XElement textboxStyle) {
            if (this.PaddingBottom != null) {
                textboxStyle.Add(new XElement("PaddingBottom", this.PaddingBottom));
            }
        }

        private void ConfigurePaddingLeft(XElement textboxStyle) {
            if (this.PaddingLeft != null) {
                textboxStyle.Add(new XElement("PaddingLeft", this.PaddingLeft));
            }
        }

        private void ConfigurePaddingRight(XElement textboxStyle) {
            if (this.PaddingRight != null) {
                textboxStyle.Add(new XElement("PaddingRight", this.PaddingRight));
            }
        }

        private void ConfigureVerticalAlign(XElement textboxStyle) {
            if (this.VerticalAlign != VerticalAlign.Default) {
                textboxStyle.Add(new XElement("VerticalAlign", this.VerticalAlign));
            }
        }
    }
}
