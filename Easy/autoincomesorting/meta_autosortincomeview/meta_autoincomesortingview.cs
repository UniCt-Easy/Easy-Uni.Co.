
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
using metadatalibrary;
using System.Windows.Forms;
using metaeasylibrary;
using System.Data;

namespace meta_autoincomesortingview {//meta_autoclassentrateview//
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	public class Meta_autoincomesortingview : Meta_easydata {
		public Meta_autoincomesortingview(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "autoincomesortingview") {
			ListingTypes.Add("default");
		}

		public override void DescribeColumns(DataTable T, string ListingType) {
			base.DescribeColumns(T, ListingType);
			if (ListingType=="default") {
				foreach (DataColumn C in T.Columns)
					DescribeAColumn(T, C.ColumnName, "", -1);

                int nPos = 1;
                DescribeAColumn(T, "codefin", "Cod.Bil.", nPos++);
                DescribeAColumn(T, "codeupb", "Cod. U.P.B.", nPos++);
                DescribeAColumn(T, "regsortingkind", "Tipo Class. Anagrafica", nPos++);
                DescribeAColumn(T, "registrysortcode", "Cod. Class. Anagrafica", nPos++);
                DescribeAColumn(T, "registrykind", "Class. Anagrafica", nPos++);
                DescribeAColumn(T, "manager", "Resp.", nPos++);
                DescribeAColumn(T, "sortingkind", "Tipo Class. Movimenti", nPos++);
                DescribeAColumn(T, "sortingcode", "Codice Class. Movimenti", nPos++);
                DescribeAColumn(T, "sorting", "Class. Movimenti", nPos++);
                DescribeAColumn(T, "numerator", "Num.", nPos++);
                DescribeAColumn(T, "denominator", "Denom.", nPos++);
			}
		}
	}	
}
