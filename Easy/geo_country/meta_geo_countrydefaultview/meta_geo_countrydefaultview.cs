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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using metadatalibrary;
using metaeasylibrary;
//$CustomUsing$


namespace meta_geo_countrydefaultview
{
    public class Meta_geo_countrydefaultview : Meta_easydata 
	{
        public Meta_geo_countrydefaultview(DataAccess Conn, MetaDataDispatcher Dispatcher) :
            base(Conn, Dispatcher, "geo_countrydefaultview") {
			EditTypes.Add("default");
            ListingTypes.Add("default");
            //$EditTypes$
        }

		private string[] mykey = new string[] {"idcountry"};

		public override string[] primaryKey() {
			return mykey;
		}

		//$SetDefault$

		//$Get_New_Row$

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
				case "default": {
						DescribeAColumn(T, "title", "Denominazione", nPos++);
						DescribeAColumn(T, "geo_region_title", "Regione", nPos++);
						DescribeAColumn(T, "geo_country_newcountry", "id nuova provincia in cui questa è confluita", nPos++);
						DescribeAColumn(T, "geo_country_oldcountry", "id provincia da cui questa è confluita", nPos++);
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
				case "default": {
						return "geo_region_title desc, title desc";
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
