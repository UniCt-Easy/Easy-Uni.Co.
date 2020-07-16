/*
    Easy
    Copyright (C) 2020 Università degli Studi di Catania (www.unict.it)
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

﻿using System;
using System.Data;
using metadatalibrary;
using metaeasylibrary;
//$CustomUsing$


namespace meta_istanzaimm_segview
{
    public class Meta_istanzaimm_segview : Meta_easydata 
	{
        public Meta_istanzaimm_segview(DataAccess Conn, MetaDataDispatcher Dispatcher) :
            base(Conn, Dispatcher, "istanzaimm_segview") {
				Name = "Istanze di immatricolazione";
			EditTypes.Add("imm_seg");
			ListingTypes.Add("imm_seg");
			//$EditTypes$
        }

		private string[] mykey = new string[] {"idistanza","idreg_studenti"};

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
				case "imm_seg": {
						DescribeAColumn(T, "istanza_aa", "Anno accademico", nPos++);
						DescribeAColumn(T, "registrystudenti_title", "Studente", nPos++);
						DescribeAColumn(T, "istanza_data", "Data", nPos++);
						if (T.Columns.Contains("istanza_data")) T.Columns["istanza_data"].ExtendedProperties["format"] = "g";
						DescribeAColumn(T, "statuskind_title", "Status", nPos++);
						DescribeAColumn(T, "istanza_protnumero", "Numero di protocollo", nPos++);
						DescribeAColumn(T, "istanza_protanno", "Anno di protocollo", nPos++);
						DescribeAColumn(T, "didprog_title", "Didattica programmata", nPos++);
						DescribeAColumn(T, "didprogcurr_title", "Curriculum", nPos++);
						DescribeAColumn(T, "didprogori_title", "Corso e orientamento", nPos++);
						DescribeAColumn(T, "istanza_imm_parttime", "Iscrizione Part-Time", nPos++);
						break;
					}
					//$DescribeAColumn$
			}
		}

		//$GetSortings$

		public override string GetStaticFilter(string ListingType) {
			switch (ListingType) {
				case "imm_seg": {
						return "istanza_idistanzakind = 14";
						break;
					}
				//$GetStaticFilter$
			}
			return base.GetStaticFilter(ListingType);
		}
		
		//$CustomCode$
    }
}
