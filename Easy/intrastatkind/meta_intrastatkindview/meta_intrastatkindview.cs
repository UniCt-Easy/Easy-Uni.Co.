
/*
Easy
Copyright (C) 2024 Università degli Studi di Catania (www.unict.it)
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
using metaeasylibrary;
using metadatalibrary;
//Pino: using tiposcadenza; diventato inutile
using System.Windows.Forms;

namespace meta_intrastatkindview//meta_tiposcadenza//
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	public class Meta_intrastatkindview : Meta_easydata {
		public Meta_intrastatkindview(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "intrastatkind") {
			EditTypes.Add("default");
			ListingTypes.Add("default");
			ListingTypes.Add("old");
		}
		
		public override void DescribeColumns(DataTable T, string listtype) {
			base.DescribeColumns(T, listtype);
						
			if (listtype == "default") {
				foreach (DataColumn C in T.Columns)
					DescribeAColumn(T, C.ColumnName, "", -1);

				int pos = 1;
				DescribeAColumn(T, "code_a", "Codice A", pos++);
				DescribeAColumn(T, "description_a", "Natura della Transazione A", pos++);
				DescribeAColumn(T, "code_b", "Codice B", pos++);
				DescribeAColumn(T, "description_b", "Natura della Transazione B", pos++);
			}
			if (listtype == "old") {
				foreach (DataColumn C in T.Columns)
					DescribeAColumn(T, C.ColumnName, "", -1);

				int pos = 1;
				DescribeAColumn(T, "idintrastatkind", "Codice", pos++);
				DescribeAColumn(T, "description_a", "Descrizione", pos++);
			}
		}   
	}
}
