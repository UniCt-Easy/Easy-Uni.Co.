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


namespace meta_titolostudiodocentiview
{
    public class Meta_titolostudiodocentiview : Meta_easydata 
	{
        public Meta_titolostudiodocentiview(DataAccess Conn, MetaDataDispatcher Dispatcher) :
            base(Conn, Dispatcher, "titolostudiodocentiview") {
				Name = "Titoli di studio";
			EditTypes.Add("docenti");
			ListingTypes.Add("docenti");
			//$EditTypes$
        }

		private string[] mykey = new string[] {"idreg","idtitolostudio"};

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
				case "docenti": {
						DescribeAColumn(T, "istattitolistudio_titolo", "Titolo ISTAT", nPos++);
						DescribeAColumn(T, "titolostudio_voto", "Voto", nPos++);
						DescribeAColumn(T, "titolostudio_votosu", "Su", nPos++);
						DescribeAColumn(T, "titolostudio_votolode", "Lode", nPos++);
						DescribeAColumn(T, "titolostudio_aa", "Anno accademco", nPos++);
						DescribeAColumn(T, "registry_istituti_title", "Istituto", nPos++);
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
