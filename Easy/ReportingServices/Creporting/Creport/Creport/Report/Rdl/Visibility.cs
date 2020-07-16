/*
    Easy
    Copyright (C) 2020 Università degli Studi di Catania (www.unict.it)
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

﻿using System.Xml.Linq;

namespace Creport.Report.Rdl {
    public class Visibility {

        /// <summary>
        /// Funzione di drilldown. Hidden indica se la cella è visibile o meno, Toggleitem = textbox su cui vale la proprietà
        /// </summary>
        /// <param name="Hidden"></param>
        /// <param name="Toggleitem"></param>
        public Visibility(bool Hidden, string Toggleitem) {
            this.hidden = Hidden;
            this.toggleitem = Toggleitem;
            Build();
        }


        /// <summary>
        /// Funzione di drilldown. Hidden indica se la cella è visibile o meno, Toggleitem = textbox su cui vale la proprietà
        /// </summary>
        /// <param name="Hidden"></param>
        /// <param name="Toggleitem"></param>
        public Visibility(string Hidden, string Toggleitem) {
            this.hidden = Hidden;
            this.toggleitem = Toggleitem;
            Build();
        }

        public XElement Element {
            get {
                return this.Build();
            }
        }

        public object hidden { get; private set; }
        public object toggleitem { get; private set; }

        protected virtual XElement Build() {
            var result = new XElement(typeof(Visibility).GetShortName());
            this.Hidden(result);
            this.Toggleitem(result);
            return result;
        }

        private void Hidden(XElement Visibility) {
            if (this.hidden != null) {
                Visibility.Add(new XElement("Hidden", this.hidden));
            }
        }

        private void Toggleitem(XElement Visibility) {
            if (this.toggleitem != null) {
                Visibility.Add(new XElement("ToggleItem", this.toggleitem));
            }
        }


        ///// <summary>
        ///// Funzione di drilldown. Hidden indica se la cella è visibile o meno, ItemToggle = textbox su cui vale la proprietà
        ///// </summary>
        ///// <param name="hidden"></param>
        ///// <param name="ItemToggle"></param>
        ///// <returns></returns>
        //public static Visibility CreateToggleItem(bool hidden, string ItemToggle) {
        //    return new Visibility { hidden = hidden, toggleitem = ItemToggle };
        //}




    }
}
