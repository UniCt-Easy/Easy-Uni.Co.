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


namespace meta_aulaseg_childview
{
    public class Meta_aulaseg_childview : Meta_easydata 
	{
        public Meta_aulaseg_childview(DataAccess Conn, MetaDataDispatcher Dispatcher) :
            base(Conn, Dispatcher, "aulaseg_childview") {
				Name = "Aule";
			EditTypes.Add("seg_child");
			ListingTypes.Add("seg_child");
			//$EditTypes$
        }

		private string[] mykey = new string[] {"idaula","idedificio","idsede"};

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
				case "seg_child": {
						DescribeAColumn(T, "title", "Denominazione", nPos++);
						DescribeAColumn(T, "aula_code", "Codice", nPos++);
						DescribeAColumn(T, "struttura_title", "Struttra didattica di afferenza", nPos++);
						DescribeAColumn(T, "aula_capienza", "Capienza", nPos++);
						DescribeAColumn(T, "aula_capienzadis", "Capienza disabili", nPos++);
						DescribeAColumn(T, "aulakind_title", "Tipologia", nPos++);
						break;
					}
					//$DescribeAColumn$
			}
		}

		public override string GetSorting(string ListingType) {
			switch (ListingType) {
				case "seg_child": {
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
