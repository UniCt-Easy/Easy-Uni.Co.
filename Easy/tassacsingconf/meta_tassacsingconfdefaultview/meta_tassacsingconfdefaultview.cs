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


namespace meta_tassacsingconfdefaultview
{
    public class Meta_tassacsingconfdefaultview : Meta_easydata 
	{
        public Meta_tassacsingconfdefaultview(DataAccess Conn, MetaDataDispatcher Dispatcher) :
            base(Conn, Dispatcher, "tassacsingconfdefaultview") {
				Name = "Definizione dei costi dei corsi singoli";
			EditTypes.Add("default");
			ListingTypes.Add("default");
			//$EditTypes$
        }

		private string[] mykey = new string[] {"idtassacsingconf"};

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
						DescribeAColumn(T, "tassacsingconf_aa", "Anno accademico", nPos++);
						DescribeAColumn(T, "tassacsingconf_costomax", "Costo massimo", nPos++);
						if (T.Columns.Contains("tassacsingconf_costomax")) T.Columns["tassacsingconf_costomax"].ExtendedProperties["format"] = "fixed.2";
						DescribeAColumn(T, "costoscontodef_title", "Costo", nPos++);
						DescribeAColumn(T, "costoscontodef_2_title", "Costo corsi speciali", nPos++);
						DescribeAColumn(T, "costoscontodef_sconto_title", "Sconto", nPos++);
						DescribeAColumn(T, "tassacsingconf_numerosconto", "Numero di insegnamenti per cui si applica lo sconto", nPos++);
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
