
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


using System;
using System.Data;
using System.Windows.Forms;
using metaeasylibrary;
using metadatalibrary;

namespace meta_accountsorting {
	/// <summary>
	/// Summary description for Meta_upbsorting.
	/// </summary>
	public class Meta_accountsorting : Meta_easydata {
		public Meta_accountsorting(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "accountsorting") {
			EditTypes.Add("single");
			EditTypes.Add("default");
			ListingTypes.Add("default");
			ListingTypes.Add("elenco");
		}

		protected override Form GetForm(string FormName) {
			
			if (FormName=="single") {
				Name = "Classificazione conto";
				DefaultListType = "default";
				return GetFormByDllName("accountsorting_single");
			}
			if (FormName == "default") {
				Name = "Classificazione conto";
				DefaultListType = "elenco";
				return GetFormByDllName("accountsorting_imputazione");
			}
			return null;
		}

		public override DataRow SelectOne(string ListingType, string filter, string searchtable, DataTable Exclude) {

			if (ListingType.StartsWith("elenco."))
				return base.SelectOne(ListingType, filter, "accountsortingview", Exclude);
			else
				return base.SelectOne(ListingType, filter, "accountsorting", Exclude);
		}

		public override void DescribeColumns(DataTable T, string ListingType){
			base.DescribeColumns(T, ListingType);
            foreach (DataColumn C in T.Columns)
            {
                DescribeAColumn(T, C.ColumnName, "", -1);
            }
			if (ListingType == "default") {
				int nPos = 1;
				//DescribeAColumn(T, "idsorkind", "Tipo", nPos++);
				DescribeAColumn(T, "!sortingkind", "Tipo", "sortingview.sortingkind", nPos++);
				DescribeAColumn(T, "!codiceclass", "Codice", "sortingview.sortcode", nPos++);
				DescribeAColumn(T, "!descrizione", "Descrizione", "sortingview.description", nPos++);
				DescribeAColumn(T, "quota", "Quota", nPos++);
				HelpForm.SetFormatForColumn(T.Columns["quota"], "p");
			}
		}
	}
}
