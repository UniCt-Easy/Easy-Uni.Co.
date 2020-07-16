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


namespace meta_esonerodisabilview
{
    public class Meta_esonerodisabilview : Meta_easydata 
	{
        public Meta_esonerodisabilview(DataAccess Conn, MetaDataDispatcher Dispatcher) :
            base(Conn, Dispatcher, "esonerodisabilview") {
				Name = "Definizione degli esoneri di invalidità";
			EditTypes.Add("disabil");
			ListingTypes.Add("disabil");
			//$EditTypes$
        }

		private string[] mykey = new string[] {"idesonero"};

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
				case "disabil": {
						DescribeAColumn(T, "esonero_aa", "Anno accademico", nPos++);
						DescribeAColumn(T, "title", "Denominazione", nPos++);
						DescribeAColumn(T, "esonero_description", "Descrizione", nPos++);
						DescribeAColumn(T, "esonero_applunavolta", "Applicabile una sola volta", nPos++);
						DescribeAColumn(T, "costoscontodef_title", "Sconto", nPos++);
						DescribeAColumn(T, "esoneroanskind_title", "Tipologia Codice ANS", nPos++);
						DescribeAColumn(T, "esoneroanskind_description", "Descrizione Codice ANS", nPos++);
						DescribeAColumn(T, "esonero_retroattivo", "Retroattivo", nPos++);
						DescribeAColumn(T, "esonero_soloconisee", "Applicabile solo con ISEE", nPos++);
						DescribeAColumn(T, "esonero_disabil_percmax", "Percentuale massima", nPos++);
						if (T.Columns.Contains("esonero_disabil_percmax")) T.Columns["esonero_disabil_percmax"].ExtendedProperties["format"] = "fixed.2";
						DescribeAColumn(T, "esonero_disabil_percmin", "Percentuale minima", nPos++);
						if (T.Columns.Contains("esonero_disabil_percmin")) T.Columns["esonero_disabil_percmin"].ExtendedProperties["format"] = "fixed.2";
						break;
					}
					//$DescribeAColumn$
			}
		}

		public override string GetSorting(string ListingType) {
			switch (ListingType) {
				case "disabil": {
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
