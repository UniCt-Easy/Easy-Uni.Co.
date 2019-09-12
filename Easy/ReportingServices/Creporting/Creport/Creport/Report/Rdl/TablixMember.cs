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
    public class TablixMember :IElement {
        private readonly Group group;
        private readonly SortExpressions sortExpressions;
        private readonly TablixHeader tablixHeader;

        public TablixMember() {
        }

        public TablixMember(Group group, SortExpressions sortExpressions, TablixHeader tablixHeader) {
            this.group = group;
            this.sortExpressions = sortExpressions;
            this.tablixHeader = tablixHeader;
        }

        public Inch Size {
            get {
                return this.tablixHeader == null ? new Inch(0) : this.tablixHeader.Size;
            }
        }

        public XElement Element {
            get {
                return this.Build();
            }
        }

        private XElement Build() {
            var result = new XElement(typeof(TablixMember).GetShortName());
            this.ConfigureGroup(result);
            this.ConfigureSortExpressions(result);
            this.ConfigureTablixHeader(result);
            return result;
        }

        private void ConfigureGroup(XElement tablixMember) {
            if (this.group != null) {
                tablixMember.Add(this.group.Element);
            }
        }

        private void ConfigureSortExpressions(XElement tablixMember) {
            if (this.sortExpressions != null) {
                tablixMember.Add(this.sortExpressions.Element);
            }
        }

        private void ConfigureTablixHeader(XElement tablixMember) {
            if (this.tablixHeader != null) {
                tablixMember.Add(this.tablixHeader.Element);
            }
        }
    }
}