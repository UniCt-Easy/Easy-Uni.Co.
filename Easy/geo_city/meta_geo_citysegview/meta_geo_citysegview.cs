/*
    Easy
    Copyright (C) 2020 Università degli Studi di Catania (www.unict.it)
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

﻿using System.Data;
using metadatalibrary;
using metaeasylibrary;
//$CustomUsing$


namespace meta_geo_citysegview
{
    public class Meta_geo_citysegview : Meta_easydata 
	{
        public Meta_geo_citysegview(DataAccess Conn, MetaDataDispatcher Dispatcher) :
            base(Conn, Dispatcher, "geo_citysegview") {
				Name = "Comuni";
			EditTypes.Add("seg");
            ListingTypes.Add("seg");
            EditTypes.Add("seg");
			ListingTypes.Add("seg");
			//$EditTypes$
        }

		private string[] mykey = new string[] {"idcity"};

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
				case "seg": {
						DescribeAColumn(T, "title", "Denominazione", nPos++);
						DescribeAColumn(T, "geo_country_title", "Provincia", nPos++);
						DescribeAColumn(T, "geo_city_1_title", "Nuovo comune in cui questo è confluito", nPos++);
						DescribeAColumn(T, "geo_city_2_title", "id comune da cui questo è confluito", nPos++);
						DescribeAColumn(T, "geo_city_start", "data inizio", nPos++);
						DescribeAColumn(T, "geo_city_stop", "data fine", nPos++);
						break;
					}
					//$DescribeAColumn$
			}
		}

		public override string GetSorting(string ListingType) {

			switch (ListingType) {
				case "seg": {
						return "title asc ";
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
