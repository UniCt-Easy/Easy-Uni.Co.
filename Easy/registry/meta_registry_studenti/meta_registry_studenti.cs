/*
    Easy
    Copyright (C) 2019 Università degli Studi di Catania (www.unict.it)

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


namespace meta_registry_studenti
{
    public class Meta_registry_studenti : Meta_easydata 
	{
        public Meta_registry_studenti(DataAccess Conn, MetaDataDispatcher Dispatcher) :
            base(Conn, Dispatcher, "registry_studenti") {
				Name = "Studenti";
			EditTypes.Add("studenti");
            ListingTypes.Add("studenti");
            //$EditTypes$
        }

		//$PrymaryKey$

				public override void SetDefaults(DataTable PrimaryTable) {
			base.SetDefaults(PrimaryTable);
						SetDefault(PrimaryTable, "authinps", "N");
						SetDefault(PrimaryTable, "idstuddirittokind", "1");
						SetDefault(PrimaryTable, "idstudprenotkind", "0");
		}


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
				case "studenti": {
						DescribeAColumn(T, "authinps", "Autorizzazione all'istituto di accedere ai propri dati INPS", nPos++);
						DescribeAColumn(T, "idreg", "Codice Istituto", nPos++);
						DescribeAColumn(T, "!idstuddirittokind_studdirittokind_title", "Tipologia per il diritto allo studio", nPos++);
						DescribeAColumn(T, "!idstudprenotkind_studprenotkind_title", "Tipologia per la prenotazione degli appelli", nPos++);
						DescribeAColumn(T, "!idstudprenotkind_studprenotkind_description", "Tipologia per la prenotazione degli appelli", nPos++);
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