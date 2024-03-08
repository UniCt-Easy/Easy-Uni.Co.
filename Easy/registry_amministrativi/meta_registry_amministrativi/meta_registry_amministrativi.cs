
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
using System.Windows.Forms;
using System.Data;
using metaeasylibrary;
using metadatalibrary;

namespace meta_registry_amministrativi {
	/// <summary>
	/// MetaData for registry_amministrativi
	/// </summary>
	public class Meta_registry_amministrativi : Meta_easydata {
		public Meta_registry_amministrativi(DataAccess Conn, MetaDataDispatcher Dispatcher) :
			base(Conn, Dispatcher, "registry_amministrativi") {
			Name = "Amministrativi";
			ListingTypes.Add("default");
			EditTypes.Add("default");
		}

		public override void SetDefaults(DataTable T) {
			base.SetDefaults(T);
		}

		public override void DescribeColumns(DataTable T, string ListingType) {
			base.DescribeColumns(T, ListingType);
			if (ListingType == "anagraficadetail") {
				foreach (DataColumn C in T.Columns)
					DescribeAColumn(T, C.ColumnName, "", -1);
				int nPos = 1;
				DescribeAColumn(T, "idreg", "Codice", nPos++);
			}
		}

		protected override Form GetForm(string FormName) {

			if (FormName == "anagraficadetail") {
				Name = "Amministrativi";
				DefaultListType = "anagraficadetail";
				return GetFormByDllName("registry_amministrativi_anagraficadetail");
			}

			return null;
		}

		public override bool IsValid(DataRow R, out string errmess, out string errfield) {
			if (!base.IsValid(R, out errmess, out errfield)) return false;

			return true;
		}
		public override DataRow Get_New_Row(DataRow ParentRow, DataTable T) {
			return base.Get_New_Row(ParentRow, T);
		}
	}



}
