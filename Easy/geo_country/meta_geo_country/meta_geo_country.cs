
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


using System.Data;
using metadatalibrary;
using metaeasylibrary;
//$CustomUsing$


namespace meta_geo_country
{
    public class Meta_geo_country : Meta_easydata 
	{
        public Meta_geo_country(DataAccess Conn, MetaDataDispatcher Dispatcher) :
            base(Conn, Dispatcher, "geo_country") {
				Name = "Provincia";
			EditTypes.Add("default");
			ListingTypes.Add("default");
			EditTypes.Add("seg");
			ListingTypes.Add("seg");
			EditTypes.Add("segchild");
			ListingTypes.Add("segchild");
			//$EditTypes$
        }

		//$PrymaryKey$


		public override DataRow Get_New_Row(DataRow ParentRow, DataTable T) {
			RowChange.MarkAsAutoincrement(T.Columns["idcountry"], null, null, 0);
			RowChange.setMinimumTempValue(T.Columns["idcountry"], 9990000);
			//$Get_New_Row$
			DataRow R = base.Get_New_Row(ParentRow, T);
			return R;
		}



		public override void DescribeColumns(DataTable T, string ListingType) {
			base.DescribeColumns(T, ListingType);

			foreach (DataColumn C in T.Columns) {
				DescribeAColumn(T, C.ColumnName, "", -1);
			}
			int nPos = 1;
					
			switch (ListingType) {
				case "default": {
						DescribeAColumn(T, "start", "Inizio validità", nPos++);
						DescribeAColumn(T, "stop", "Fine validità", nPos++);
						DescribeAColumn(T, "title", "Provincia", nPos++);
						break;
					}
				case "seg": {
						DescribeAColumn(T, "title", "Denominazione", nPos++);
						DescribeAColumn(T, "!idregion_geo_region_title", "Regione", nPos++);
						DescribeAColumn(T, "!newcountry_geo_country_title", "id nuova provincia in cui questa è confluita", nPos++);
						DescribeAColumn(T, "!oldcountry_geo_country_title", "id provincia da cui questa è confluita", nPos++);
						DescribeAColumn(T, "province", "sigla provincia", nPos++);
						DescribeAColumn(T, "start", "data inizio", nPos++);
						DescribeAColumn(T, "stop", "data fine", nPos++);
						break;
					}
				case "segchild": {
						DescribeAColumn(T, "title", "Denominazione", nPos++);
						DescribeAColumn(T, "!newcountry_geo_country_title", "id nuova provincia in cui questa è confluita", nPos++);
						DescribeAColumn(T, "!oldcountry_geo_country_title", "id provincia da cui questa è confluita", nPos++);
						DescribeAColumn(T, "province", "sigla provincia", nPos++);
						DescribeAColumn(T, "start", "data inizio", nPos++);
						DescribeAColumn(T, "stop", "data fine", nPos++);
						break;
					}
					//$DescribeAColumn$
			}
		}

		public override string GetSorting(string ListingType) {

			switch (ListingType) {
				case "default": {
						return "title desc";
					}
				case "segchild": {
						return "title desc";
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
