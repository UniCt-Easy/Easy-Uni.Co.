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


namespace meta_attivformpropeddefaultview
{
    public class Meta_attivformpropeddefaultview : Meta_easydata 
	{
        public Meta_attivformpropeddefaultview(DataAccess Conn, MetaDataDispatcher Dispatcher) :
            base(Conn, Dispatcher, "attivformpropeddefaultview") {
				Name = "Propedeuticità";
			EditTypes.Add("default");
			ListingTypes.Add("default");
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
				case "default": {
						DescribeAColumn(T, "attivformproped_alternativa", "Alternativa", nPos++);
						DescribeAColumn(T, "attivform_proped_iddidprogcurr", "Curriculum", nPos++);
						DescribeAColumn(T, "attivform_proped_iddidprogori", "Orientamento", nPos++);
						DescribeAColumn(T, "attivform_proped_iddidproganno", "Anno di corso", nPos++);
						DescribeAColumn(T, "attivform_proped_iddidprogporzanno", "Porzione d'anno", nPos++);
						DescribeAColumn(T, "attivform_proped_iddidproggrupp", "Gruppo opzionale", nPos++);
						DescribeAColumn(T, "attivform_proped_idinsegn", "Insegnamento", nPos++);
						DescribeAColumn(T, "attivform_proped_idinsegninteg", "Integrando", nPos++);
						DescribeAColumn(T, "attivform_proped_start", "Dal", nPos++);
						DescribeAColumn(T, "attivform_proped_stop", "Al", nPos++);
						DescribeAColumn(T, "attivform_proped_tipovalutaz", "Profitto o Idoneità", nPos++);
						break;
					}
					//$DescribeAColumn$
			}
		}

		public override string GetSorting(string ListingType) {
			switch (ListingType) {
				case "default": {
						return "attivform_proped_sortcode";
					}
				//$GetSorting$
			}
			return base.GetSorting(ListingType);
		}

		//$GetStaticFilter$
		
		//$CustomCode$
    }
}
