
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


namespace meta_strutturaseg_childview
{
    public class Meta_strutturaseg_childview : Meta_easydata 
	{
        public Meta_strutturaseg_childview(DataAccess Conn, MetaDataDispatcher Dispatcher) :
            base(Conn, Dispatcher, "strutturaseg_childview") {
				Name = "Struttura / Unità organizzativa";
			EditTypes.Add("seg_child");
			ListingTypes.Add("seg_child");
			//$EditTypes$
        }

		private string[] mykey = new string[] {"idstruttura"};

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
				case "seg_child": {
						DescribeAColumn(T, "strutturakind_title", "Tipologia", nPos++);
						DescribeAColumn(T, "title", "Denominazione", nPos++);
						DescribeAColumn(T, "struttura_codice", "Codice", nPos++);
						DescribeAColumn(T, "struttura_title_en", "Denominazione (ENG)", nPos++);
						DescribeAColumn(T, "struttura_email", "E-Mail", nPos++);
						DescribeAColumn(T, "struttura_fax", "Fax", nPos++);
						DescribeAColumn(T, "registry_title", "Istituto o ente o azienda", nPos++);
						DescribeAColumn(T, "struttura_telefono", "Telefono", nPos++);
						break;
					}
					//$DescribeAColumn$
			}
		}

		public override string GetSorting(string ListingType) {
			switch (ListingType) {
				case "seg_child": {
						return "struttura_title asc ";
					}
				//$GetSorting$
			}
			return base.GetSorting(ListingType);
		}

		//$GetStaticFilter$
		
		//$CustomCode$
    }
}
