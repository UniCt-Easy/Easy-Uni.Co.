
/*
Easy
Copyright (C) 2024 Universit� degli Studi di Catania (www.unict.it)
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


namespace meta_registrymilitariview
{
    public class Meta_registrymilitariview : Meta_easydata 
	{
        public Meta_registrymilitariview(DataAccess Conn, MetaDataDispatcher Dispatcher) :
            base(Conn, Dispatcher, "registrymilitariview") {
				Name = "Personale militare";
			EditTypes.Add("militari");
			ListingTypes.Add("militari");
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
				case "militari": {
						DescribeAColumn(T, "title_description", "Titolo", nPos++);
						DescribeAColumn(T, "registry_surname", "Cognome", nPos++);
						DescribeAColumn(T, "registry_forename", "Nome", nPos++);
						DescribeAColumn(T, "registry_cf", "Codice fiscale", nPos++);
						DescribeAColumn(T, "registry_badgecode", "Codice bedge", nPos++);
						DescribeAColumn(T, "registry_active", "Attivo", nPos++);
						DescribeAColumn(T, "struttura_title", "Unit� produttiva", nPos++);
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
