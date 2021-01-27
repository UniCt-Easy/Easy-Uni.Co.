
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


namespace meta_istanzapas_seganagstuview
{
    public class Meta_istanzapas_seganagstuview : Meta_easydata 
	{
        public Meta_istanzapas_seganagstuview(DataAccess Conn, MetaDataDispatcher Dispatcher) :
            base(Conn, Dispatcher, "istanzapas_seganagstuview") {
				Name = "Istanze di passaggio corso o cambio ordinamento";
			EditTypes.Add("pas_seganagstu");
			ListingTypes.Add("pas_seganagstu");
			//$EditTypes$
        }

		private string[] mykey = new string[] {"idcorsostudio","iddidprog","idiscrizione","idistanza","idistanzakind","idreg_studenti"};

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
				case "pas_seganagstu": {
						DescribeAColumn(T, "aa", "Anno accademico", nPos++);
						DescribeAColumn(T, "data", "Data", nPos++);
						if (T.Columns.Contains("data")) T.Columns["data"].ExtendedProperties["format"] = "g";
						DescribeAColumn(T, "statuskind_title", "Status", nPos++);
						DescribeAColumn(T, "istanza_protnumero", "Numero di protocollo", nPos++);
						DescribeAColumn(T, "istanza_protanno", "Anno di protocollo", nPos++);
						DescribeAColumn(T, "iscrizionefrom_anno", "Anno di corso Iscrizione di partenza", nPos++);
						DescribeAColumn(T, "iscrizionefrom_iddidprog", "Didattica programmata Iscrizione di partenza", nPos++);
						DescribeAColumn(T, "iscrizionefrom_aa", "Anno accademico Iscrizione di partenza", nPos++);
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
