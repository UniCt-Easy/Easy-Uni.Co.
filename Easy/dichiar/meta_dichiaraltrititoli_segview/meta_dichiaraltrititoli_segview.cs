
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


namespace meta_dichiaraltrititoli_segview
{
    public class Meta_dichiaraltrititoli_segview : Meta_easydata 
	{
        public Meta_dichiaraltrititoli_segview(DataAccess Conn, MetaDataDispatcher Dispatcher) :
            base(Conn, Dispatcher, "dichiaraltrititoli_segview") {
				Name = "Altri titoli";
			EditTypes.Add("altrititoli_seg");
			ListingTypes.Add("altrititoli_seg");
			//$EditTypes$
        }

		private string[] mykey = new string[] {"iddichiar","idreg"};

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
				case "altrititoli_seg": {
						DescribeAColumn(T, "registry_title", "Studente", nPos++);
						DescribeAColumn(T, "aa", "Anno Accademico", nPos++);
						DescribeAColumn(T, "dichiar_date", "Data", nPos++);
						DescribeAColumn(T, "dichiar_altrititoli_title", "Titolo", nPos++);
						DescribeAColumn(T, "dichiar_altrititoli_dataottenimento", "Data ottenimento", nPos++);
						DescribeAColumn(T, "dichiar_altrititoli_rilasciatoda", "Rilasciato da", nPos++);
						break;
					}
					//$DescribeAColumn$
			}
		}

		public override string GetSorting(string ListingType) {
			switch (ListingType) {
				case "altrititoli_seg": {
						return "dichiar_altrititoli_title desc";
					}
				//$GetSorting$
			}
			return base.GetSorting(ListingType);
		}

		//$GetStaticFilter$
		
		//$CustomCode$
    }
}
