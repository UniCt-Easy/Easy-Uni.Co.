
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


using System.Collections.Generic;
using System.Xml.Linq;

namespace Creport.Report.Rdl {
    public class DataSet :IElement {
        private static int index;

        private readonly List<string> fields;
        private readonly string rdlName;

        public DataSet() {
            this.rdlName = typeof(DataSet).GetShortName();
            this.Name = this.rdlName + ++index;
            this.fields = new List<string>();
        }

        public string Name { get; private set; }

        public XElement Element {
            get {
                return this.Build();
            }
        }

        public void AddField(string field) {
            this.fields.Add(field);
        }

        private XElement Build() {
            var f = new XElement("Fields");
            var dataSet = new XElement(
                this.rdlName,
                new XAttribute("Name", this.Name),
                new XElement(
                    "Query",
                    new XElement("DataSourceName", DataSources.DataSourceName),
                    new XElement("CommandText")),
                f);
            foreach (var field in this.fields) {
                f.Add(new XElement(
                    "Field",
                    new XAttribute("Name", field),
                    new XElement("DataField", field)));
            }

            return dataSet;
        }
    }
}
