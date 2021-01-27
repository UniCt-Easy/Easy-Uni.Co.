
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


namespace meta_istanzaimm_seganagstupreview
{
    public class Meta_istanzaimm_seganagstupreview : Meta_easydata 
	{
        public Meta_istanzaimm_seganagstupreview(DataAccess Conn, MetaDataDispatcher Dispatcher) :
            base(Conn, Dispatcher, "istanzaimm_seganagstupreview") {
				Name = "Istanze di preimmatricolazione";
			EditTypes.Add("imm_seganagstupre");
			ListingTypes.Add("imm_seganagstupre");
			//$EditTypes$
        }

		private string[] mykey = new string[] {"idcorsostudio","iddidprog","idistanza","idistanzakind","idreg_studenti"};

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
				case "imm_seganagstupre": {
						DescribeAColumn(T, "aa", "Anno accademico", nPos++);
						DescribeAColumn(T, "didprog_title", "Denominazione Didattica programmata", nPos++);
						DescribeAColumn(T, "didprog_aa", "Anno accademico Didattica programmata", nPos++);
						DescribeAColumn(T, "didprog_idsede", "Sede Didattica programmata", nPos++);
						DescribeAColumn(T, "data", "Data", nPos++);
						if (T.Columns.Contains("data")) T.Columns["data"].ExtendedProperties["format"] = "g";
						DescribeAColumn(T, "statuskind_title", "Status", nPos++);
						DescribeAColumn(T, "istanza_protnumero", "Numero di protocollo", nPos++);
						DescribeAColumn(T, "istanza_protanno", "Anno di protocollo", nPos++);
						DescribeAColumn(T, "didprogcurr_title", "Curriculum", nPos++);
						DescribeAColumn(T, "didprogori_title", "Corso e orientamento", nPos++);
						DescribeAColumn(T, "istanza_imm_parttime", "Iscrizione Part-Time", nPos++);
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
