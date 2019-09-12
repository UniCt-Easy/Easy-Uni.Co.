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

ï»¿namespace Creport.Report.Rdl {
    class TablixStyle {

        /// <summary>
        /// Stile per la tablix. Color = colore del bordo, Style = stile del bordo, grandezza = spesso del bordo, BackgroundColor = colore dello sfondo della cella
        /// </summary>
        /// <param name="color">RdlColor.Black.ToString()</param>
        /// <param name="style">BorderStyle.Dashed.ToString()</param>
        /// <param name="grandezza">2</param>
        /// <param name="BackgroundColor">System.Drawing.Color.AliceBlue.Name</param>
        /// <returns></returns>
        public static Style CreateTablixStyle(string color, string style, int grandezza, string BackgroundColor) {
            var border = new Border {
                Color = color,
                Style = style,
                Width = new Point(grandezza),
            };
            return new Style {
                Border = border,
                BackgroundColor = BackgroundColor
            };
        }

        /// <summary>
        /// Stile per la tablix. Color = colore del bordo, Style = stile del bordo, grandezza = spesso del bordo
        /// </summary>
        /// <param name="color">RdlColor.Black.ToString()</param>
        /// <param name="style">BorderStyle.Dashed.ToString()</param>
        /// <param name="grandezza">2</param>
        /// <returns></returns>
        public static Style CreateTablixStyle(string color, string style, int grandezza) {
            var border = new Border {
                Color = color,
                Style = style,
                Width = new Point(grandezza),
            };
            return new Style {
                Border = border,
            };
        }
    }
}
