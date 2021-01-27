
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

namespace meta_geo_region_view
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	public class Meta_geo_region_view : Meta_easydata {
		public Meta_geo_region_view(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "geo_region_view") {		
			ListingTypes.Add("default");
			Name="Regioni";
		}
		public override void DescribeColumns(DataTable T, string ListingType){
			base.DescribeColumns(T, ListingType);
			if (ListingType=="default"){
				foreach (DataColumn C in T.Columns)
					C.Caption="";

				DescribeAColumn(T,"start", "Inizio validità");
				DescribeAColumn(T,"stop", "Fine validità");
				DescribeAColumn(T,"title", "Regione");
			}
		}
	}
}
