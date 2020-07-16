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


namespace meta_provaaulaview
{
    public class Meta_provaaulaview : Meta_easydata 
	{
        public Meta_provaaulaview(DataAccess Conn, MetaDataDispatcher Dispatcher) :
            base(Conn, Dispatcher, "provaaulaview") {
				Name = "Prove";
			EditTypes.Add("aula");
			ListingTypes.Add("aula");
			//$EditTypes$
        }

		private string[] mykey = new string[] {"idprova"};

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
				case "aula": {
						DescribeAColumn(T, "title", "Denominazione", nPos++);
						DescribeAColumn(T, "prova_start", "Data e ora inizio", nPos++);
						if (T.Columns.Contains("prova_start")) T.Columns["prova_start"].ExtendedProperties["format"] = "g";
						DescribeAColumn(T, "prova_stop", "Data e ora fine", nPos++);
						if (T.Columns.Contains("prova_stop")) T.Columns["prova_stop"].ExtendedProperties["format"] = "g";
						break;
					}
					//$DescribeAColumn$
			}
		}

		public override string GetSorting(string ListingType) {
			switch (ListingType) {
				case "aula": {
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
