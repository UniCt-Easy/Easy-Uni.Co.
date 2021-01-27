
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


namespace meta_registryaddresssegview
{
    public class Meta_registryaddresssegview : Meta_easydata 
	{
        public Meta_registryaddresssegview(DataAccess Conn, MetaDataDispatcher Dispatcher) :
            base(Conn, Dispatcher, "registryaddresssegview") {
				Name = "Indirizzi";
			EditTypes.Add("seg");
			ListingTypes.Add("seg");
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
				case "seg": {
						DescribeAColumn(T, "address_description", "Tipologia", nPos++);
						DescribeAColumn(T, "start", "Data inizio", nPos++);
						DescribeAColumn(T, "registryaddress_stop", "Data fine", nPos++);
						DescribeAColumn(T, "registryaddress_active", "Attivo", nPos++);
						DescribeAColumn(T, "registryaddress_address", "Indirizzo", nPos++);
						DescribeAColumn(T, "registryaddress_flagforeign", "Estero", nPos++);
						DescribeAColumn(T, "geo_city_title", "Comune", nPos++);
						DescribeAColumn(T, "registryaddress_location", "Località", nPos++);
						DescribeAColumn(T, "registryaddress_cap", "CAP", nPos++);
						DescribeAColumn(T, "geo_nation_title", "Nazione", nPos++);
						DescribeAColumn(T, "registryaddress_annotations", "Annotazioni", nPos++);
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
