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

using System;
using System.Data;
using System.Windows.Forms;
using metaeasylibrary;
using metadatalibrary;

namespace meta_taxsortingsetup {
	/// <summary>
	/// </summary>
	public class Meta_taxsortingsetup : Meta_easydata {
		public Meta_taxsortingsetup(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "taxsortingsetup") {
			EditTypes.Add("default");
			ListingTypes.Add("default");
		}
		protected override Form GetForm(string FormName){

			if (FormName=="default") {
				Name = "Classificazione Ritenute/Prestazioni";
				DefaultListType="default";
				return GetFormByDllName("taxsortingsetup_default");
			}
			return null;
		}

		public override DataRow Get_New_Row(DataRow ParentRow, DataTable T) {
			RowChange.SetSelector(T, "ayear");
			RowChange.MarkAsAutoincrement(T.Columns["idautotaxsor"],null,null,0);
			return base.Get_New_Row (ParentRow, T);
		}

		public override void SetDefaults(DataTable PrimaryTable) {
			base.SetDefaults (PrimaryTable);
			SetDefault(PrimaryTable, "ayear", GetSys("esercizio"));
			SetDefault(PrimaryTable, "flaginherit", "N");
		}

		public override DataRow SelectOne(string ListingType, string filter, string searchtable, DataTable ToMerge) {
			if (ListingType == "default"){
				return base.SelectOne (ListingType, filter, "taxsortingsetupview", ToMerge);
			}
			return base.SelectOne (ListingType, filter, "taxsortingsetup", ToMerge);
		}

	}
}


