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
    public abstract class ReportItem :IElement {
        private Inch top = new Inch(0);

        public Inch Top {
            get {
                return this.top;
            }

            set {
                this.top = value;
            }
        }

        public Inch Left { get; set; }

        public Inch Height { get; set; }

        public Inch Width { get; set; }

        public Inch NextTop {
            get {
                return this.Top + this.Height;
            }
        }

        public XElement Element {
            get {
                return this.Build();
            }
        }

        protected abstract XElement Build();

        protected void ConfigureTop(XElement item) {
            if (this.Top.ToString() != new Inch(0).ToString()) {
                item.Add(new XElement("Top", this.Top));
            }
        }

        protected void ConfigureLeft(XElement item) {
            if (this.Left != null) {
                item.Add(new XElement("Left", this.Left));
            }
        }

        protected void ConfigureHeight(XElement item) {
            if (this.Height != null) {
                item.Add(new XElement("Height", this.Height));
            }
        }

        protected void ConfigureWidth(XElement item) {
            if (this.Width != null) {
                item.Add(new XElement("Width", this.Width));
            }
        }
    }
}
