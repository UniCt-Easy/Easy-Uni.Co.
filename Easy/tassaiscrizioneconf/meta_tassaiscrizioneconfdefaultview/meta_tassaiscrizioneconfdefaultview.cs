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


namespace meta_tassaiscrizioneconfdefaultview
{
    public class Meta_tassaiscrizioneconfdefaultview : Meta_easydata 
	{
        public Meta_tassaiscrizioneconfdefaultview(DataAccess Conn, MetaDataDispatcher Dispatcher) :
            base(Conn, Dispatcher, "tassaiscrizioneconfdefaultview") {
				Name = "Definizione delle tasse di iscrizione";
			EditTypes.Add("default");
			ListingTypes.Add("default");
			//$EditTypes$
        }

		private string[] mykey = new string[] {"idtassaiscrizioneconf"};

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
						DescribeAColumn(T, "tassaiscrizioneconf_aa", "Anno accademico", nPos++);
						DescribeAColumn(T, "title", "Title", nPos++);
						DescribeAColumn(T, "tassaiscrizioneconf_aamax", "Anno accademico massimo", nPos++);
						DescribeAColumn(T, "tassaiscrizioneconf_aamin", "Anno accademico minimo", nPos++);
						DescribeAColumn(T, "tassaiscrizioneconf_annofcmax", "Anno di iscrizione fuori corso massimo", nPos++);
						DescribeAColumn(T, "tassaiscrizioneconf_annofcmin", "Anno di iscrizione fuori corso minimo", nPos++);
						DescribeAColumn(T, "tassaiscrizioneconf_annomax", "Anno di iscrizione massimo", nPos++);
						DescribeAColumn(T, "tassaiscrizioneconf_annomin", "Anno di iscrizione minimo", nPos++);
						DescribeAColumn(T, "tassaiscrizioneconf_codice_corsostudio", "Codice del corso di studio", nPos++);
						DescribeAColumn(T, "tassaiscrizioneconf_codice_didprog", "Codice della didattica programmata", nPos++);
						DescribeAColumn(T, "tassaiscrizioneconf_codice_didprogcurr", "Codice del curriculum", nPos++);
						DescribeAColumn(T, "tassaiscrizioneconf_codice_didprogori", "Codice dell'orientamento", nPos++);
						DescribeAColumn(T, "tassaiscrizioneconf_corsisingoli", "Corsi singoli", nPos++);
						DescribeAColumn(T, "costoscontodef_title", "Costo", nPos++);
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

		//$GetStaticFilter$
		
		//$CustomCode$
    }
}
