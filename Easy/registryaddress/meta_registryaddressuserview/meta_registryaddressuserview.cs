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

﻿using System;
using System.Data;
using metadatalibrary;
using metaeasylibrary;
//$CustomUsing$


namespace meta_registryaddressuserview
{
    public class Meta_registryaddressuserview : Meta_easydata 
	{
        public Meta_registryaddressuserview(DataAccess Conn, MetaDataDispatcher Dispatcher) :
            base(Conn, Dispatcher, "registryaddressuserview") {
				Name = "Indirizzi";
			EditTypes.Add("user");
			ListingTypes.Add("user");
			//$EditTypes$
        }

		private string[] mykey = new string[] {"idaddresskind","idreg","start"};

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
				case "user": {
						DescribeAColumn(T, "address", "Indirizzo", nPos++);
						DescribeAColumn(T, "geo_city_title", "Comune", nPos++);
						DescribeAColumn(T, "registryaddress_location", "Località", nPos++);
						DescribeAColumn(T, "registryaddress_cap", "CAP", nPos++);
						break;
					}
					//$DescribeAColumn$
			}
		}

		//$GetSortings$

		//$GetStaticFilter$
		
		//$CustomCode$
    }
}
