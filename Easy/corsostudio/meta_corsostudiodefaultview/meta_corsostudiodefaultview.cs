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


namespace meta_corsostudiodefaultview
{
    public class Meta_corsostudiodefaultview : Meta_easydata 
	{
        public Meta_corsostudiodefaultview(DataAccess Conn, MetaDataDispatcher Dispatcher) :
            base(Conn, Dispatcher, "corsostudiodefaultview") {
				Name = "Corsi di studio";
			EditTypes.Add("default");
			ListingTypes.Add("default");
			//$EditTypes$
        }

		private string[] mykey = new string[] {"idcorsostudio"};

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
				case "default": {
						DescribeAColumn(T, "title", "Denominazione", nPos++);
						DescribeAColumn(T, "corsostudio_title_en", "Denominazione (EN)", nPos++);
						DescribeAColumn(T, "corsostudio_codice", "Codice", nPos++);
						DescribeAColumn(T, "corsostudio_codicemiur", "Codice MIUR", nPos++);
						DescribeAColumn(T, "corsostudio_codicemiurlungo", "Codice MIUR lungo", nPos++);
						DescribeAColumn(T, "corsostudiokind_title", "Tipologia", nPos++);
						DescribeAColumn(T, "struttura_title", "Struttura di riferimento", nPos++);
						DescribeAColumn(T, "corsostudio_crediti", "Crediti", nPos++);
						DescribeAColumn(T, "corsostudio_durata", "Durata", nPos++);
						DescribeAColumn(T, "duratakind_title", "Tipologia della durata", nPos++);
						DescribeAColumn(T, "corsostudionorma_title", "Normativa di riferimento", nPos++);
						DescribeAColumn(T, "corsostudiolivello_title", "Livello", nPos++);
						break;
					}
					//$DescribeAColumn$
			}
		}

		public override string GetSorting(string ListingType) {
			switch (ListingType) {
				case "default": {
						return "title asc ";
					}
				//$GetSorting$
			}
			return base.GetSorting(ListingType);
		}

		public override string GetStaticFilter(string ListingType) {
			switch (ListingType) {
				case "default": {
						return "corsostudio_idcorsostudiokind not in (12,13,2)";
						break;
					}
				//$GetStaticFilter$
			}
			return base.GetStaticFilter(ListingType);
		}
		
		//$CustomCode$
    }
}
