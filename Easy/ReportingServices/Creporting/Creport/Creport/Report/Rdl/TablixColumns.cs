
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


using System.Linq;

namespace Creport.Report.Rdl {
    public class TablixColumns :CollectionOf<TablixColumn>, IElement {

        public TablixColumns() {
        }

        public TablixColumns(TablixColumn tablixColumn)
            : base(tablixColumn) {
        }

        public Inch Width {
            get {
                var result = new Inch(0);
                return this.Collection.Aggregate(result, (current, tablixColum) => current + tablixColum.Width);
            }
        }

        /// <summary>
        /// Numero di colonne da creare
        /// </summary>
        /// <param name="nColumn">2</param>
        public static TablixColumns CreateColumn(int nColumn) {

            TablixColumns tablixColumns = new TablixColumns();
            for (int i = 0; i < nColumn; i++) {
                tablixColumns.Add(new TablixColumn(new Width(new Inch(1))));
            }
            return tablixColumns;
        }


        protected sealed override string GetRdlName() {
            return typeof(TablixColumns).GetShortName();
        }
    }
}
