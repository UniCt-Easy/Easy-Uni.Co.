/*
    Easy
    Copyright (C) 2019 Università degli Studi di Catania (www.unict.it)

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

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using metadatalibrary;
using metaeasylibrary;

namespace meta_geo_city_agencyview {
    class Meta_geo_city_agencyview : Meta_easydata {
        public Meta_geo_city_agencyview(DataAccess Conn, MetaDataDispatcher Dispatcher)
            :
			base(Conn, Dispatcher, "geo_city_agencyview") 
		{		
			Name= "Codici per Comune";
			ListingTypes.Add("default");
		}
        private string[] mykey = new string[] { "idagency","idcity","idcode","version"};
        public override string[] primaryKey() {
            return mykey;
        }
		public override void DescribeColumns(DataTable T, string ListingType) 
		{
			base.DescribeColumns(T, ListingType);
			if (ListingType=="default") 
			{
				foreach (DataColumn C in T.Columns)
					DescribeAColumn(T, C.ColumnName, "", -1);

                int nPos = 1;
                DescribeAColumn(T, "title", "Comune", nPos++);
                DescribeAColumn(T, "provincecode", "Sigla", nPos++);
                DescribeAColumn(T, "agencyname", "Ente", nPos++);
                DescribeAColumn(T, "codename", "Nome del Codice", nPos++);
                DescribeAColumn(T, "value", "Valore", nPos++);
                DescribeAColumn(T, "start", "Data Inizio", nPos++);
                DescribeAColumn(T, "stop", "Data Fine", nPos++);
                DescribeAColumn(T, "agencywebsite", "U.R.L.", nPos++);
			}
		}
	}
}

