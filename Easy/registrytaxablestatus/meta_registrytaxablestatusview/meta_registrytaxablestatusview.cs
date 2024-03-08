
/*
Easy
Copyright (C) 2024 Università degli Studi di Catania (www.unict.it)
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
using System.Data;
using metadatalibrary;
using metaeasylibrary;


namespace meta_registrytaxablestatusview//meta_posretributivaview//
{
	/// <summary>
	/// Summary description for posretributivaview.
	/// </summary>
	public class Meta_registrytaxablestatusview : Meta_easydata 
	{
		public Meta_registrytaxablestatusview(DataAccess Conn, MetaDataDispatcher Dispatcher):
		base(Conn, Dispatcher, "registrytaxablestatusview") 
		{
			
			ListingTypes.Add("posretr");
			ListingTypes.Add("anagrafica");
			
		}

		public override void DescribeColumns(DataTable T, string listtype)
		{
			base.DescribeColumns(T, listtype);
			if (listtype=="posretr")  
			{
				foreach (DataColumn C in T.Columns)
					DescribeAColumn(T, C.ColumnName, "", -1);

                int nPos = 1;
                DescribeAColumn(T, "registry", "Denom. anagrafica", nPos++);
                DescribeAColumn(T, "start", "Decorrenza", nPos++);
                DescribeAColumn(T, "supposedincome", "Retrib. fiscale", nPos++);
			}
			if (listtype=="anagrafica") 
			{
				foreach (DataColumn C in T.Columns)
					DescribeAColumn(T, C.ColumnName, "", -1);

                int nPos = 1;
                DescribeAColumn(T, "start", "Data", nPos++);
                DescribeAColumn(T, "idreg", "Codice", nPos++);
                DescribeAColumn(T, "registry", "Denominazione", nPos++);
                DescribeAColumn(T, "supposedincome", "Fiscale", nPos++);
			}
		}   
	}
}
