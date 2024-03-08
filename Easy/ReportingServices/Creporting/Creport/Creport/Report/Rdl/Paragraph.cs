
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
    public class Paragraph :ParentOf<TextRuns> {
        public Paragraph(TextRuns item)
            : base(item) {
        }

        public TextAlign TextAlign { get; set; }

        protected sealed override string GetRdlName() {
            return typeof(Paragraph).GetShortName();
        }

        protected override XElement Build() {
            var result = base.Build();
            result.Add(this.BuildStyle());
            return result;
        }

        private XElement BuildStyle() {
            var result = new XElement("Style");

            if (this.TextAlign != TextAlign.Default) {
                result.Add(new XElement("TextAlign", this.TextAlign));
            }

            return result.HasElements ? result : null;
        }
    }
}
