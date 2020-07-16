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
    public class TablixBody {
        private readonly TablixColumns tablixColumns;
        private readonly TablixRows tablixRows;

        public TablixBody(TablixColumns tablixColumns, TablixRows tablixRows) {
            this.tablixColumns = tablixColumns;
            this.tablixRows = tablixRows;
        }

        public Inch Height {
            get {
                return this.tablixRows.Height;
            }
        }

        public Inch Width {
            get {
                return this.tablixColumns.Width;
            }
        }

        public XElement Element {
            get {
                return this.Build();
            }
        }

        private XElement Build() {
            return new XElement(typeof(TablixBody).GetShortName(), this.tablixColumns.Element, this.tablixRows.Element);
        }
    }
}
