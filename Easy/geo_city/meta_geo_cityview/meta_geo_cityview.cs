
/*
Easy
Copyright (C) 2021 Università degli Studi di Catania (www.unict.it)
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
using metadatalibrary;
using metaeasylibrary;
using System.Data;

namespace meta_geo_cityview//meta_geo_comune_view//
{
	/// <summary>
	/// Summary description for Meta_geo_comune_view.
	/// </summary>
	public class Meta_geo_cityview : Meta_easydata {
		public Meta_geo_cityview(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "geo_cityview") {		
			ListingTypes.Add("default");
			ListingTypes.Add("storia");
			Name="Comuni";
		}
	    private string[] mykey = new string[] { "idcity"};
	    public override string[] primaryKey() {
	        return mykey;
	    }
		public override void DescribeColumns(DataTable T, string ListingType){
			base.DescribeColumns(T, ListingType);
			if (ListingType=="default"){
				foreach (DataColumn C in T.Columns)
					C.Caption="";
                int nPos = 1;
				DescribeAColumn(T, "title", "Comune", nPos++);
                DescribeAColumn(T, "country", "Provincia", nPos++);
                DescribeAColumn(T, "region", "Regione", nPos++);
                DescribeAColumn(T, "nation", "Nazione", nPos++);
                DescribeAColumn(T, "start", "Inizio validità", nPos++);
                DescribeAColumn(T, "stop", "Fine validità", nPos++);
			}
			if (ListingType=="storia")
			{
				foreach (DataColumn C in T.Columns)
					C.Caption="";

				DescribeAColumn(T,"title", "Comune");
				DescribeAColumn(T,"provincecode","Provincia");
			}
		}
	}
}
