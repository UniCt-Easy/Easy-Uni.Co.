
/*
Easy
Copyright (C) 2024 UniversitÓ degli Studi di Catania (www.unict.it)
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


namespace meta_itinerationrefundaidadvanceview
{
    public class Meta_itinerationrefundaidadvanceview : Meta_easydata 
	{
        public Meta_itinerationrefundaidadvanceview(DataAccess Conn, MetaDataDispatcher Dispatcher) :
            base(Conn, Dispatcher, "itinerationrefundaidadvanceview") {
				Name = "Anticipi";
			EditTypes.Add("aidadvance");
			ListingTypes.Add("aidadvance");
			//$EditTypes$
        }

		private string[] mykey = new string[] {"iditineration","nrefund"};

		public override string[] primaryKey() {
			return mykey;
		}

		//$SetDefault$

		//$Get_New_Row$

		//$IsValid$

		//$DescribeAColumn$

		public override string GetSorting(string ListingType) {
			switch (ListingType) {
				case "aidadvance": {
						return "itinerationrefund_starttime asc ";
					}
				//$GetSorting$
			}
			return base.GetSorting(ListingType);
		}

		public override string GetStaticFilter(string ListingType) {
			switch (ListingType) {
				case "aidadvance": {
						return "flagadvancebalance = 'A'";
						break;
					}
				//$GetStaticFilter$
			}
			return base.GetStaticFilter(ListingType);
		}
		
		//$CustomCode$
    }
}
