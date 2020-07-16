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


namespace meta_attivformappelloview
{
    public class Meta_attivformappelloview : Meta_easydata 
	{
        public Meta_attivformappelloview(DataAccess Conn, MetaDataDispatcher Dispatcher) :
            base(Conn, Dispatcher, "attivformappelloview") {
				Name = "Attività formative";
			EditTypes.Add("appello");
			ListingTypes.Add("appello");
			//$EditTypes$
        }

		private string[] mykey = new string[] {"aa","idattivform","idcorsostudio","iddidprog","iddidproganno","iddidprogcurr","iddidprogori","iddidprogporzanno"};

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
				case "appello": {
						DescribeAColumn(T, "didprog_title", "Didattica programmata", nPos++);
						DescribeAColumn(T, "insegn_denominazione", "Denominazione Insegnamento", nPos++);
						DescribeAColumn(T, "insegn_codice", "Codice Insegnamento", nPos++);
						DescribeAColumn(T, "insegninteg_denominazione", "Denominazione Integrando", nPos++);
						DescribeAColumn(T, "insegninteg_codice", "Codice Integrando", nPos++);
						DescribeAColumn(T, "attivform_tipovalutaz", "Profitto o Idoneità", nPos++);
						break;
					}
					//$DescribeAColumn$
			}
		}

		public override string GetSorting(string ListingType) {
			switch (ListingType) {
				case "appello": {
						return "attivform_sortcode";
					}
				//$GetSorting$
			}
			return base.GetSorting(ListingType);
		}

		//$GetStaticFilter$
		
		//$CustomCode$
    }
}
