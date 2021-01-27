
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
using metaeasylibrary;
using metadatalibrary;
using System.Data;

namespace meta_geo_comuni_da_importare//meta_geo_comuni_da_importare//
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	public class Meta_geo_comuni_da_importare : Meta_easydata
	{
		public Meta_geo_comuni_da_importare(DataAccess Conn, MetaDataDispatcher Dispatcher):
		base(Conn, Dispatcher, "geo_comuni_da_importare") 
		{		
			Name="Geo_comuni_da_importare";
		}

		public override DataRow Get_New_Row(DataRow ParentRow, DataTable T)
		{
			RowChange.MarkAsAutoincrement(T.Columns["idcity"],null,
				null,7);
			return base.Get_New_Row(ParentRow, T);
		}
	}
}
