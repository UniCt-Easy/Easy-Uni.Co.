
/*
Easy
Copyright (C) 2021 Universit� degli Studi di Catania (www.unict.it)
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


namespace meta_geo_countrysegchildview
{
    public class Meta_geo_countrysegchildview : Meta_easydata 
	{
        public Meta_geo_countrysegchildview(DataAccess Conn, MetaDataDispatcher Dispatcher) :
            base(Conn, Dispatcher, "geo_countrysegchildview") {
				Name = "Province";
			EditTypes.Add("segchild");
			ListingTypes.Add("segchild");
			//$EditTypes$
        }

		private string[] mykey = new string[] {"idcountry"};

		public override string[] primaryKey() {
			return mykey;
		}

		//$SetDefault$

		//$Get_New_Row$

		//$IsValid$

		public override void DescribeColumns(DataTable T, string ListingType) {
			base.DescribeColumns(T, ListingType);

			foreach (DataColumn C in T.Columns) {
				DescribeAColumn(T, C.ColumnName, "", -1);
			}
			int nPos = 1;
					
			switch (ListingType) {
				case "segchild": {
						DescribeAColumn(T, "title", "Denominazione", nPos++);
						DescribeAColumn(T, "geo_country_1_title", "id nuova provincia in cui questa � confluita", nPos++);
						DescribeAColumn(T, "geo_country_2_title", "id provincia da cui questa � confluita", nPos++);
						DescribeAColumn(T, "geo_country_province", "sigla provincia", nPos++);
						DescribeAColumn(T, "geo_country_start", "data inizio", nPos++);
						DescribeAColumn(T, "geo_country_stop", "data fine", nPos++);
						break;
					}
					//$DescribeAColumn$
			}
		}

		public override string GetSorting(string ListingType) {
			switch (ListingType) {
				case "segchild": {
						return "title asc ";
					}
				//$GetSorting$
			}
			return base.GetSorting(ListingType);
		}

		//$GetStaticFilter$
		
		//$CustomCode$
    }
}
