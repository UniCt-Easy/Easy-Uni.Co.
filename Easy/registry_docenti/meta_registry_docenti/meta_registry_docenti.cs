
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

namespace meta_registry_docenti{
	/// <summary>
	/// MetaData for registry_docenti
	/// </summary>
	public class Meta_registry_docenti : Meta_easydata {
		public Meta_registry_docenti(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "registry_docenti") {
			Name = "Docenti";
			ListingTypes.Add("default");
			EditTypes.Add("default");
		}

		public override void SetDefaults(DataTable T) {
			base.SetDefaults(T);
		}

		protected override Form GetForm(string FormName) {

			if (FormName == "anagraficadetail") {
				Name = "Istituto, Ente o Azienda";
				DefaultListType = "anagraficadetail";
				return GetFormByDllName("registry_docenti_anagraficadetail");
			}

			return null;
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

		public override bool IsValid(DataRow R, out string errmess, out string errfield) {
			if (!base.IsValid(R, out errmess, out errfield)) return false;

			return true;
		}
		public override DataRow Get_New_Row(DataRow ParentRow, DataTable T) {
			return base.Get_New_Row(ParentRow, T);
		}
	}



}
