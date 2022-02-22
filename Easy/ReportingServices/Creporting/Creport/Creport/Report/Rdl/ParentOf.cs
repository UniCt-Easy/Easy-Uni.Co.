
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
    public abstract class ParentOf<T> :IElement {


        protected ParentOf(T item) {
            this.Item = item;
        }

        protected ParentOf(T item, Direction direction) {
            this.Item = item;
            this.Direction = direction;
        }




        public XElement Element {
            get {
                return this.Build();
            }
        }

        protected T Item { get; private set; }
        protected Direction Direction { get; private set; }

        protected abstract string GetRdlName();

        protected virtual XElement Build() {
            var result = new XElement(this.GetRdlName());
            var value = this.Item as IElement;
            if (value != null) {
                result.Add(value.Element);
            }
            else {
                result.Add(this.Item);
            }
            var direct = this.Direction as IElement;
            if(direct != null) {
                result.Add(direct.Element);
            }

            return result;
        }
    }
}
