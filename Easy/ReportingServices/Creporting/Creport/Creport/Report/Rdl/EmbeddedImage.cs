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

ï»¿using System;
using System.IO;
using System.Xml.Linq;

namespace Creport.Report.Rdl {
    public class EmbeddedImage :IElement {
        private const double Dpi = 96;

        private readonly System.Drawing.Image image;
        private readonly string imageName;

        public EmbeddedImage(System.Drawing.Image image, string imageName) {
            this.image = image;
            this.Width = new Inch(image.Size.Width / Dpi);
            this.Height = new Inch(image.Size.Height / Dpi);
            this.imageName = imageName;
        }

        public Inch Width { get; private set; }

        public Inch Height { get; private set; }

        public XElement Element {
            get {
                return this.Build();
            }
        }

        private XElement Build() {
            return new XElement(
                typeof(EmbeddedImage).GetShortName(),
                new XAttribute("Name", this.imageName),
                new XElement("MIMEType", "image/png"),
                new XElement("ImageData", this.ConvertToBase64String()));
        }

        private string ConvertToBase64String() {
            using (var ms = new MemoryStream()) {
                this.image.Save(ms, this.image.RawFormat);
                return Convert.ToBase64String(ms.ToArray());
            }
        }
    }
}
