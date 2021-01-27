
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
using metadatalibrary;
using metaeasylibrary;
//$CustomUsing$


namespace meta_itinerationrefundinstmuseradvanceview
{
	public class Meta_itinerationrefundinstmuseradvanceview : Meta_easydata
	{
		public Meta_itinerationrefundinstmuseradvanceview(DataAccess Conn, MetaDataDispatcher Dispatcher) :
			base(Conn, Dispatcher, "itinerationrefundinstmuseradvanceview") {
			Name = "Anticipi";
			EditTypes.Add("instmuseradvance");
			ListingTypes.Add("instmuseradvance");
			//$EditTypes$
		}

		private string[] mykey = new string[] {"iditineration","nrefund"};

		public override string[] primaryKey() {
			return mykey;
		}

		//$SetDefault$

		public override DataRow Get_New_Row(DataRow ParentRow, DataTable T) {

			//$Get_New_Row$

			DataRow R = base.Get_New_Row(ParentRow, T);
			return R;
		}

		public override bool IsValid(DataRow R, out string errmess, out string errfield) {
			if (!base.IsValid(R, out errmess, out errfield)) return false;

			//$IsValid$

			return true;
		}

		public override void DescribeColumns(DataTable T, string ListingType) {
			base.DescribeColumns(T, ListingType);

			foreach (DataColumn C in T.Columns) {
				DescribeAColumn(T, C.ColumnName, "", -1);
			}
			int nPos = 1;

			switch (ListingType) {
				case "instmuseradvance": {
						DescribeAColumn(T, "itinerationrefundkind_description", "Tipologia", nPos++);
						DescribeAColumn(T, "itinerationrefund_starttime", "data inizio ", nPos++);
						T.Columns["itinerationrefund_starttime"].ExtendedProperties["format"] = "g";
						DescribeAColumn(T, "itinerationrefund_requiredamount", "Importo", nPos++);
						DescribeAColumn(T, "currency_description", "Valuta", nPos++);
						break;
					}
					//$DescribeAColumn$
			}
		}

		public override string GetSorting(string ListingType) {

			switch (ListingType) {
				case "instmuseradvance": {
						return "itinerationrefund_starttime desc";
					}
					//$GetSorting$
			}
			return base.GetSorting(ListingType);
		}

		public override string GetStaticFilter(string ListingType) {
			switch (ListingType) {
				//$GetStaticFilter$
			}
			return base.GetStaticFilter(ListingType);
		}

		//$CustomCode$
	}
}
