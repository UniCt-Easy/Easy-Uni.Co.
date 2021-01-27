
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


namespace meta_istanzaeq_segview
{
    public class Meta_istanzaeq_segview : Meta_easydata 
	{
        public Meta_istanzaeq_segview(DataAccess Conn, MetaDataDispatcher Dispatcher) :
            base(Conn, Dispatcher, "istanzaeq_segview") {
				Name = "Istanza di equipollenza ";
			EditTypes.Add("eq_seg");
			ListingTypes.Add("eq_seg");
			//$EditTypes$
        }

		private string[] mykey = new string[] {"idistanza","idistanzakind","idreg_studenti"};

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
				case "eq_seg": {
						DescribeAColumn(T, "registrystudenti_title", "Studente", nPos++);
						DescribeAColumn(T, "aa", "Anno accademico", nPos++);
						DescribeAColumn(T, "istanza_data", "Data", nPos++);
						if (T.Columns.Contains("istanza_data")) T.Columns["istanza_data"].ExtendedProperties["format"] = "g";
						DescribeAColumn(T, "corsostudio_title", "Corso di studi", nPos++);
						DescribeAColumn(T, "didprog_title", "Denominazione Didattica programmata", nPos++);
						DescribeAColumn(T, "didprog_aa", "Anno accademico Didattica programmata", nPos++);
						DescribeAColumn(T, "didprog_idsede", "Sede Didattica programmata", nPos++);
						DescribeAColumn(T, "iscrizione_anno", "Anno di corso Iscrizione", nPos++);
						DescribeAColumn(T, "iscrizione_iddidprog", "Didattica programmata Iscrizione", nPos++);
						DescribeAColumn(T, "iscrizione_aa", "Anno accademico Iscrizione", nPos++);
						DescribeAColumn(T, "statuskind_title", "Status", nPos++);
						DescribeAColumn(T, "istanzaparent_idistanzakind", "Tipologia Istanza collegata", nPos++);
						DescribeAColumn(T, "istanzaparent_idreg_studenti", "Studente Istanza collegata", nPos++);
						DescribeAColumn(T, "istanzaparent_aa", "Anno accademico Istanza collegata", nPos++);
						DescribeAColumn(T, "istanzaparent_data", "Data Istanza collegata", nPos++);
						if (T.Columns.Contains("istanzaparent_data")) T.Columns["istanzaparent_data"].ExtendedProperties["format"] = "g";
						DescribeAColumn(T, "istanzaparent_iddidprog", "Didattica programmata Istanza collegata", nPos++);
						DescribeAColumn(T, "istanzaparent_idstatuskind", "Status Istanza collegata", nPos++);
						DescribeAColumn(T, "istanzaparent_idiscrizione", "Iscrizione Istanza collegata", nPos++);
						DescribeAColumn(T, "dichiartitolo_seg_iddichiarkind", "Dichiarazione del titolo di studio", nPos++);
						DescribeAColumn(T, "dichiartitolo_seg_idreg", "Dichiarazione del titolo di studio", nPos++);
						DescribeAColumn(T, "dichiartitolo_seg_aa", "Dichiarazione del titolo di studio", nPos++);
						DescribeAColumn(T, "dichiartitolo_seg_date", "Dichiarazione del titolo di studio", nPos++);
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
