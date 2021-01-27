
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
    public class Textbox :ReportItem {
        private static int index;
        private readonly string name;
        private readonly Paragraphs paragraphs = new Paragraphs();
        private readonly string rdlName;

        public Textbox(Paragraph paragraph) {
            this.rdlName = typeof(Textbox).GetShortName();
            this.name = this.rdlName + ++index;
            this.AddParagraph(paragraph);
        }


        public TextboxStyle TextboxStyle { get; set; }

        public Visibility Visibility { get; set; }

        public ActionInfo ActionInfo { get; set; }

        public void AddParagraph(Paragraph paragraph) {
            this.paragraphs.Add(paragraph);
        }


        protected override XElement Build() {
            var result = new XElement(
                this.rdlName,
                new XAttribute("Name", this.name),
                new XElement("CanGrow", true),
                new XElement("KeepTogether", true),
                this.paragraphs.Element);
            this.ConfigureVisibility(result);
            this.ConfigureActionInfo(result);
            this.ConfigureTextboxStyle(result);
            this.ConfigureTop(result);
            this.ConfigureLeft(result);
            this.ConfigureHeight(result);
            this.ConfigureWidth(result);

            return result;
        }

        private void ConfigureTextboxStyle(XElement textbox) {
            if (this.TextboxStyle != null) {
                textbox.Add(this.TextboxStyle.Element);
            }
        }


        private void ConfigureVisibility(XElement textbox) {
            if (this.Visibility != null) {
                textbox.Add(this.Visibility.Element);
            }
        }

        private void ConfigureActionInfo(XElement textbox) {
            if (this.ActionInfo != null) {
                textbox.Add(this.ActionInfo.Element);
            }
        }

    }
}
