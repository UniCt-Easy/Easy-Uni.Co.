
/*
Easy
Copyright (C) 2022 Università degli Studi di Catania (www.unict.it)
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

namespace meta_servicesorting {
	/// <summary>
	/// Summary description for Meta_servicesorting.
	/// </summary>
	public class Meta_servicesorting : Meta_easydata {
		public Meta_servicesorting(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "servicesorting") {
			EditTypes.Add("single");
			ListingTypes.Add("default");
		}

		protected override Form GetForm(string FormName) {
			
			if (FormName=="single") {
				Name = "Classificazione Prestazioni";
				DefaultListType = "default";
				return GetFormByDllName("servicesorting_single");
			}
			return null;
		}	

		public override void DescribeColumns(DataTable T, string ListingType){
			base.DescribeColumns(T, ListingType);
			DescribeAColumn(T, "idsorkind", "Tipo");
			DescribeAColumn(T, "idsor", "");
			DescribeAColumn(T, "idser", "");
			DescribeAColumn(T, "!codiceclass", "Codice", "sorting.sortcode");
			DescribeAColumn(T, "!descrizione", "Descrizione", "sorting.description");
			DescribeAColumn(T, "quota", "Quota");
			HelpForm.SetFormatForColumn(T.Columns["quota"],"p");
		}   
	}
}
