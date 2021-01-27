
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


namespace meta_dichiardisabil_seganagstuview
{
    public class Meta_dichiardisabil_seganagstuview : Meta_easydata 
	{
        public Meta_dichiardisabil_seganagstuview(DataAccess Conn, MetaDataDispatcher Dispatcher) :
            base(Conn, Dispatcher, "dichiardisabil_seganagstuview") {
				Name = "Dichiarazione di disabilità";
			EditTypes.Add("disabil_seganagstu");
			ListingTypes.Add("disabil_seganagstu");
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
				case "disabil_seganagstu": {
						DescribeAColumn(T, "aa", "Anno Accademico", nPos++);
						DescribeAColumn(T, "dichiar_date", "Data", nPos++);
						DescribeAColumn(T, "dichiarkind_title", "Tipologia", nPos++);
						DescribeAColumn(T, "dichiardisabilkind_title", "Iddichiardisabilkind", nPos++);
						DescribeAColumn(T, "dichiardisabilsuppkind_title", "Iddichiardisabilsuppkind", nPos++);
						DescribeAColumn(T, "dichiar_disabil_percentuale", "Percentuale", nPos++);
						if (T.Columns.Contains("dichiar_disabil_percentuale")) T.Columns["dichiar_disabil_percentuale"].ExtendedProperties["format"] = "fixed.2";
						DescribeAColumn(T, "dichiar_disabil_permanente", "Permanente", nPos++);
						DescribeAColumn(T, "dichiar_disabil_scadenza", "Scadenza", nPos++);
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
