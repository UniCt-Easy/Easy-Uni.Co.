
/*
Easy
Copyright (C) 2024 UniversitÓ degli Studi di Catania (www.unict.it)
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


using System;
using System.Data;
using System.Windows.Forms;
using metaeasylibrary;
using metadatalibrary;
using funzioni_configurazione;

namespace meta_f24sedialtrienti {
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	public class Meta_f24sedialtrienti : Meta_easydata {
		public Meta_f24sedialtrienti(DataAccess Conn, MetaDataDispatcher Dispatcher) :
			base(Conn, Dispatcher, "f24sedialtrienti") {
			ListingTypes.Add("default");
		}

		public override void DescribeColumns(DataTable T, string ListingType) {
			base.DescribeColumns(T, ListingType);
			if (ListingType == "default") {
				foreach (DataColumn C in T.Columns) {
                    DescribeAColumn(T, C.ColumnName, "");
                }
                int nPos = 1;
				DescribeAColumn(T, "idaltrienti", "Codice Ente", nPos++);
				DescribeAColumn(T, "codicesede", "Codice Sede", nPos++);
				DescribeAColumn(T, "descrizione", "Descrizione", nPos++);
			}
		}
	}
}
