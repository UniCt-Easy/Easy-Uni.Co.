
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
    public abstract class CollectionOf<T> where T : IElement {
        protected CollectionOf() {
            this.Collection = new List<T>();
        }

        protected CollectionOf(T item)
            : this() {
            this.Add(item);
        }

        public XElement Element {
            get {
                return this.Build();
            }
        }

        protected List<T> Collection { get; private set; }

        public void Add(T item) {
            this.Collection.Add(item);
        }

        protected abstract string GetRdlName();

        protected virtual XElement Build() {
            var result = new XElement(this.GetRdlName());
            foreach (var item in this.Collection) {
                result.Add(item.Element);
            }

            return result.HasElements ? result : null;
        }
    }
}
