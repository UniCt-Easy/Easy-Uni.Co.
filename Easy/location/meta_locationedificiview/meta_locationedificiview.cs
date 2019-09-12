/*
    Easy
    Copyright (C) 2019 Universit� degli Studi di Catania (www.unict.it)

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


namespace meta_locationedificiview
{
    public class Meta_locationedificiview : Meta_easydata 
	{
        public Meta_locationedificiview(DataAccess Conn, MetaDataDispatcher Dispatcher) :
            base(Conn, Dispatcher, "locationedificiview") {
				Name = "Edifici";
			EditTypes.Add("edifici");
            ListingTypes.Add("edifici");
            //$EditTypes$
        }

		private string[] mykey = new string[] {"idlocation"};

		public override string[] primaryKey() {
			return mykey;
		}

		public override void SetDefaults(DataTable PrimaryTable) {
			base.SetDefaults(PrimaryTable);
			switch (edit_type) {
					//$SetDefault$
			}
		}

		public override DataRow Get_New_Row(DataRow ParentRow, DataTable T) {
			
			//$Get_New_Row$

			DataRow R = base.Get_New_Row(ParentRow, T);
			return R;
		}

		public override bool IsValid(DataRow R, out string errmess, out string errfield) {
			if (!base.IsValid(R, out errmess, out errfield)) return false;

			switch (edit_type) {
				case "edifici": {
						if (R.Table.Columns.Contains("address") && R["address"].ToString().Trim().Length > 100) {
							errmess = "Attenzione! Il campo 'Indirizzo' può essere al massimo di 100 caratteri";
							errfield = "address";
							return false;
						}
						if (R.Table.Columns.Contains("annotations") && R["annotations"].ToString().Trim().Length > 400) {
							errmess = "Attenzione! Il campo 'Note' può essere al massimo di 400 caratteri";
							errfield = "annotations";
							return false;
						}
						if (R.Table.Columns.Contains("cap") && R["cap"].ToString().Trim().Length > 20) {
							errmess = "Attenzione! Il campo 'CAP' può essere al massimo di 20 caratteri";
							errfield = "cap";
							return false;
						}
						if (R.Table.Columns.Contains("location") && R["location"].ToString().Trim().Length > 20) {
							errmess = "Attenzione! Il campo 'Località' può essere al massimo di 20 caratteri";
							errfield = "location";
							return false;
						}
						if (R.Table.Columns.Contains("description") && R["description"].ToString().Trim() == "") {
							errmess = "Attenzione! Il campo 'Denominazione' è obbligatorio";
							errfield = "description";
							return false;
						}
						if (R.Table.Columns.Contains("description") && R["description"].ToString().Trim().Length > 150) {
							errmess = "Attenzione! Il campo 'Denominazione' può essere al massimo di 150 caratteri";
							errfield = "description";
							return false;
						}
						if (R.Table.Columns.Contains("locationcode") && R["locationcode"].ToString().Trim() == "") {
							errmess = "Attenzione! Il campo 'Codice' è obbligatorio";
							errfield = "locationcode";
							return false;
						}
						if (R.Table.Columns.Contains("locationcode") && R["locationcode"].ToString().Trim().Length > 50) {
							errmess = "Attenzione! Il campo 'Codice' può essere al massimo di 50 caratteri";
							errfield = "locationcode";
							return false;
						}
						if (R.Table.Columns.Contains("nlevel") && R["nlevel"].ToString().Trim() == "") {
							errmess = "Attenzione! Il campo 'N. livello' è obbligatorio";
							errfield = "nlevel";
							return false;
						}
						break;
					}
				//$IsValid$
			}

			return true;
		}

		public override void DescribeColumns(DataTable T, string ListingType) {
			base.DescribeColumns(T, ListingType);

			foreach (DataColumn C in T.Columns) {
				DescribeAColumn(T, C.ColumnName, "", -1);
			}
			int nPos = 1;
					
			switch (ListingType) {
				case "edifici": {
						DescribeAColumn(T, "locationparent_description", "Sede", nPos++);
						DescribeAColumn(T, "location_locationcode", "Codice", nPos++);
						DescribeAColumn(T, "description", "Denominazione", nPos++);
						DescribeAColumn(T, "location_address", "Indirizzo", nPos++);
						DescribeAColumn(T, "geo_city_title", "Comune", nPos++);
						DescribeAColumn(T, "location_active", "Attivo", nPos++);
						break;
					}
				//$DescribeAColumn$
			}
		}

		public override string GetSorting(string ListingType) {

			switch (ListingType) {
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
