
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
using metadatalibrary;
using metaeasylibrary;
using System.Windows.Forms;

namespace meta_department {
	/// <summary>
	/// Summary description for Meta_department.
	/// </summary>
	public class Meta_department : Meta_easydata {
		public Meta_department(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "department") {
			EditTypes.Add("default");
			ListingTypes.Add("default");
		}

		protected override Form GetForm(string EditType) {
			if (EditType == "default") {
				Name = "Lista Dipartimenti";
				DefaultListType = "default";
				ActAsList();
				return GetFormByDllName("department_lista");
			}
			return null;
		}

		public override DataRow Get_New_Row(DataRow ParentRow, DataTable T) {
			RowChange.MarkAsAutoincrement(T.Columns["iddepartment"], null, null, 7);
			DataRow R = base.Get_New_Row (ParentRow, T);
			return R;
		}

		public override void DescribeColumns(DataTable T, string ListingType) {
			base.DescribeColumns (T, ListingType);
			if (ListingType == "default") {
				foreach(DataColumn C in T.Columns) {
					DescribeAColumn(T, C.ColumnName, "", -1);
				}
				int nPos = 1;
				DescribeAColumn(T, "iddepartment", "ID Dipartimento", nPos++);
				DescribeAColumn(T, "description", "Nome Dip.", nPos++);
				DescribeAColumn(T, "server", "Nome del Server", nPos++);
				DescribeAColumn(T, "db", "Nome del DB", nPos++);
			}
		}
	}
}
