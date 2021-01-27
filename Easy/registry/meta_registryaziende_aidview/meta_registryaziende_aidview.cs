
/*
Easy
Copyright (C) 2021 Universit� degli Studi di Catania (www.unict.it)
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


namespace meta_registryaziende_aidview
{
    public class Meta_registryaziende_aidview : Meta_easydata 
	{
        public Meta_registryaziende_aidview(DataAccess Conn, MetaDataDispatcher Dispatcher) :
            base(Conn, Dispatcher, "registryaziende_aidview") {
				Name = "Clienti e partners";
			EditTypes.Add("aziende_aid");
			ListingTypes.Add("aziende_aid");
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
				case "aziende_aid": {
						DescribeAColumn(T, "registryclass_description", "Tipologia", nPos++);
						DescribeAColumn(T, "title", "Denominazione", nPos++);
						DescribeAColumn(T, "registry_cf", "Codice fiscale", nPos++);
						DescribeAColumn(T, "registry_p_iva", "Partita iva", nPos++);
						DescribeAColumn(T, "registry_active", "attivo", nPos++);
						DescribeAColumn(T, "ateco_codice", "Codice Classificazione Ateco", nPos++);
						DescribeAColumn(T, "ateco_title", "Titolo Classificazione Ateco", nPos++);
						DescribeAColumn(T, "naturagiur_title", "Natura Giuridica", nPos++);
						DescribeAColumn(T, "numerodip_title", "Numero di dipendenti", nPos++);
						DescribeAColumn(T, "nace_idnace", "Codice Codice NACE", nPos++);
						DescribeAColumn(T, "nace_activity", "Activity Codice NACE", nPos++);
						break;
					}
					//$DescribeAColumn$
			}
		}

		public override string GetSorting(string ListingType) {
			switch (ListingType) {
				case "aziende_aid": {
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
