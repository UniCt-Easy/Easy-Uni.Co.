
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


namespace meta_itinerationinstm_instmuserview
{
    public class Meta_itinerationinstm_instmuserview : Meta_easydata 
	{
        public Meta_itinerationinstm_instmuserview(DataAccess Conn, MetaDataDispatcher Dispatcher) :
            base(Conn, Dispatcher, "itinerationinstm_instmuserview") {
				Name = "Missioni";
			EditTypes.Add("instm_instmuser");
			ListingTypes.Add("instm_instmuser");
			//$EditTypes$
        }

		private string[] mykey = new string[] {"iditineration"};

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
				case "instm_instmuser": {
						DescribeAColumn(T, "description", "Motivazione", nPos++);
						DescribeAColumn(T, "itineration_location", "Località di destinazione", nPos++);
						DescribeAColumn(T, "itineration_starttime", "Starttime", nPos++);
						T.Columns["itineration_starttime"].ExtendedProperties["format"] = "g";
						DescribeAColumn(T, "itineration_stoptime", "Stoptime", nPos++);
						T.Columns["itineration_stoptime"].ExtendedProperties["format"] = "g";
						DescribeAColumn(T, "itineration_instm_title", "Titolo Progetto", nPos++);
						DescribeAColumn(T, "itineration_instm_destination", "Presso", nPos++);
						DescribeAColumn(T, "itineration_instm_titlewp", "Titolo Work Package", nPos++);
						DescribeAColumn(T, "itineration_instm_authemployer", "Autorizzazione da sede di appartenenza", nPos++);
						break;
					}
					//$DescribeAColumn$
			}
		}

		public override string GetSorting(string ListingType) {
			switch (ListingType) {
				case "instm_instmuser": {
						return "itineration_instm_title desc, itineration_starttime asc , itineration_stoptime asc ";
					}
				//$GetSorting$
			}
			return base.GetSorting(ListingType);
		}

		public override string GetStaticFilter(string ListingType) {
			switch (ListingType) {
				case "instm_instmuser": {
						return "(itineration_idreg='" + security.GetUsr("idreg").ToString() + "')";
						break;
					}
				//$GetStaticFilter$
			}
			return base.GetStaticFilter(ListingType);
		}
		
		//$CustomCode$
    }
}
