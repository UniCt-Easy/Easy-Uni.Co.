
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


namespace meta_dichiarisee_segview
{
    public class Meta_dichiarisee_segview : Meta_easydata 
	{
        public Meta_dichiarisee_segview(DataAccess Conn, MetaDataDispatcher Dispatcher) :
            base(Conn, Dispatcher, "dichiarisee_segview") {
				Name = "Attestazione ISEE";
			EditTypes.Add("isee_seg");
			ListingTypes.Add("isee_seg");
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
				case "isee_seg": {
						DescribeAColumn(T, "aa", "Anno Accademico", nPos++);
						DescribeAColumn(T, "dichiar_date", "Data", nPos++);
						DescribeAColumn(T, "registry_title", "Studente", nPos++);
						DescribeAColumn(T, "dichiar_isee_anno", "Anno", nPos++);
						DescribeAColumn(T, "dichiar_isee_conforme", "Conformità", nPos++);
						DescribeAColumn(T, "dichiar_isee_dataauthdiff", "Data autorizzazione", nPos++);
						DescribeAColumn(T, "dichiar_isee_datasottoscriz", "Data di sottoscrizione", nPos++);
						DescribeAColumn(T, "dichiar_isee_enterilascio", "Ente del rilascio", nPos++);
						DescribeAColumn(T, "dichiar_isee_isee", "Valore ISEE", nPos++);
						if (T.Columns.Contains("dichiar_isee_isee")) T.Columns["dichiar_isee_isee"].ExtendedProperties["format"] = "fixed.2";
						DescribeAColumn(T, "dichiar_isee_numeroprot", "Numero protocollo dell'ente di rilascio", nPos++);
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
