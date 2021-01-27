
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
    public class Group :IElement {
        private static int index;
        private readonly string name;
        private readonly GroupExpressions groupExpressions;
        private readonly string rdlName;

        public Group(GroupExpressions groupExpressions) {
            this.rdlName = typeof(Group).GetShortName();
            this.name = this.rdlName + ++index;
            this.groupExpressions = groupExpressions;
        }

        public XElement Element {
            get {
                return this.Build();
            }
        }

        private XElement Build() {
            return new XElement(this.rdlName, new XAttribute("Name", this.name), this.groupExpressions.Element);
        }
    }
}
