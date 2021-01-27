
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


namespace meta_registryistitutiesteriview
{
    public class Meta_registryistitutiesteriview : Meta_easydata 
	{
        public Meta_registryistitutiesteriview(DataAccess Conn, MetaDataDispatcher Dispatcher) :
            base(Conn, Dispatcher, "registryistitutiesteriview") {
				Name = "Istituti esteri";
			EditTypes.Add("istitutiesteri");
			ListingTypes.Add("istitutiesteri");
			//$EditTypes$
        }

		private string[] mykey = new string[] {"idreg"};

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
				case "istitutiesteri": {
						DescribeAColumn(T, "title", "Denominazione", nPos++);
						DescribeAColumn(T, "registry_cf", "Codice fiscale", nPos++);
						DescribeAColumn(T, "registry_p_iva", "Partita iva", nPos++);
						DescribeAColumn(T, "registry_active", "attivo", nPos++);
						DescribeAColumn(T, "geo_city_title", "Città", nPos++);
						DescribeAColumn(T, "geo_nation_title", "Nazione", nPos++);
						DescribeAColumn(T, "registry_istitutiesteri_idreg", "Identificativo", nPos++);
						DescribeAColumn(T, "registry_istitutiesteri_name", "Name", nPos++);
						DescribeAColumn(T, "registry_istitutiesteri_city", "City", nPos++);
						DescribeAColumn(T, "registry_istitutiesteri_code", "Code", nPos++);
						DescribeAColumn(T, "registry_istitutiesteri_institutionalcode", "Institutional code", nPos++);
						DescribeAColumn(T, "registry_istitutiesteri_referencenumber", "Reference number", nPos++);
						break;
					}
					//$DescribeAColumn$
			}
		}

		public override string GetSorting(string ListingType) {
			switch (ListingType) {
				case "istitutiesteri": {
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
