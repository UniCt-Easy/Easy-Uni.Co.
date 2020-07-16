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


namespace meta_iscrizioneseganagstustatoview
{
    public class Meta_iscrizioneseganagstustatoview : Meta_easydata 
	{
        public Meta_iscrizioneseganagstustatoview(DataAccess Conn, MetaDataDispatcher Dispatcher) :
            base(Conn, Dispatcher, "iscrizioneseganagstustatoview") {
				Name = "Iscrizioni a esami di stato";
			EditTypes.Add("seganagstustato");
			ListingTypes.Add("seganagstustato");
			//$EditTypes$
        }

		private string[] mykey = new string[] {"idcorsostudio","iddidprog","idiscrizione","idreg"};

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
				case "seganagstustato": {
						DescribeAColumn(T, "iscrizione_aa", "Anno accademico", nPos++);
						DescribeAColumn(T, "iscrizione_data", "Data", nPos++);
						if (T.Columns.Contains("iscrizione_data")) T.Columns["iscrizione_data"].ExtendedProperties["format"] = "g";
						DescribeAColumn(T, "didprog_title", "Esame di stato", nPos++);
						DescribeAColumn(T, "iscrizione_matricola", "Matricola", nPos++);
						break;
					}
					//$DescribeAColumn$
			}
		}

		public override string GetSorting(string ListingType) {
			switch (ListingType) {
				case "seganagstustato": {
						return "iscrizione_data desc";
					}
				//$GetSorting$
			}
			return base.GetSorting(ListingType);
		}

		public override string GetStaticFilter(string ListingType) {
			switch (ListingType) {
				case "seganagstustato": {
						return "iddidprog in (select dp.iddidprog from didprog dp where dp.idcorsostudio in (select cs.idcorsostudio from corsostudio cs where cs.idcorsostudiokind = 13))";
						break;
					}
				//$GetStaticFilter$
			}
			return base.GetStaticFilter(ListingType);
		}
		
		//$CustomCode$
    }
}
