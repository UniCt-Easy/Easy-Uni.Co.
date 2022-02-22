
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
    public class Action :IElement {

        public Drillthrough Drillthrough = new Drillthrough();
        private readonly string rdlName;


        public Action(string reportname) {
            this.rdlName = typeof(Action).GetShortName();
            this.Addreportname(reportname);
        }

        public void Addreportname(string reportname) {
            this.Drillthrough.Add(reportname);
        }


        public XElement Element {
            get {
                return this.Build();
            }
        }

        protected virtual XElement Build() {
            var result = new XElement(
                this.rdlName);
            this.ConfigureDrillthrough(result);
            return result;
        }

        private void ConfigureDrillthrough(XElement action) {
            if (this.Drillthrough != null) {
                action.Add(this.Drillthrough.Element);
            }
        }

    }
}
