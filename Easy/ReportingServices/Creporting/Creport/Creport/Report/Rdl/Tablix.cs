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
    public class Tablix :ReportItem {
        private static int index;
        private readonly string name;
        private readonly TablixCorner tablixCorner;
        private readonly TablixColumnHierarchy tablixColumnHierarchy;
        private readonly TablixRowHierarchy tablixRowHierarchy;
        private readonly TablixBody tablixBody;
        private readonly string dataSetName;
        private readonly string rdlName;

        public Tablix(
            TablixColumnHierarchy tablixColumnHierarchy,
            TablixRowHierarchy tablixRowHierarchy,
            TablixBody tablixBody,
            string dataSetName) {
            this.rdlName = typeof(Tablix).GetShortName();
            this.name = this.rdlName + ++index;
            this.tablixColumnHierarchy = tablixColumnHierarchy;
            this.tablixRowHierarchy = tablixRowHierarchy;
            this.tablixBody = tablixBody;
            this.dataSetName = dataSetName;
        }

        public Tablix(
            TablixCorner tablixCorner,
            TablixColumnHierarchy tablixColumnHierarchy,
            TablixRowHierarchy tablixRowHierarchy,
            TablixBody tablixBody,
            string dataSetName)
            : this(tablixColumnHierarchy, tablixRowHierarchy, tablixBody, dataSetName) {
            this.tablixCorner = tablixCorner;
        }

        public Style Style { get; set; }

        protected override XElement Build() {
            this.Height = this.tablixBody.Height + this.tablixColumnHierarchy.Height;
            this.Width = this.tablixBody.Width + this.tablixRowHierarchy.Width;
            var result = new XElement(
                this.rdlName,
                new XAttribute("Name", this.name),
                this.tablixColumnHierarchy.Element,
                this.tablixRowHierarchy.Element,
                this.tablixBody.Element,
                new XElement("DataSetName", this.dataSetName));
            this.ConfigureTablixCorner(result);
            this.ConfigureTop(result);
            this.ConfigureLeft(result);
            this.ConfigureHeight(result);
            this.ConfigureWidth(result);
            this.ConfigureStyle(result);

            return result;
        }

        private void ConfigureTablixCorner(XElement tablix) {
            if (this.tablixCorner != null) {
                tablix.Add(this.tablixCorner.Element);
            }
        }

        private void ConfigureStyle(XElement tablix) {
            if (this.Style != null) {
                tablix.Add(this.Style.Element);
            }
        }
    }
}
