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

using System;
using System.Data;
using metadatalibrary;
using metaeasylibrary;


namespace meta_maintenanceview//meta_eventotecnicoview//
{
	/// <summary>
	/// Summary description for eventotecnicoview.
	/// </summary>
	public class Meta_maintenanceview : Meta_easydata 
	{
		public Meta_maintenanceview(DataAccess Conn, MetaDataDispatcher Dispatcher):
		base(Conn, Dispatcher, "maintenanceview") 
		{
			ListingTypes.Add("default");
			Name = "eventi tecnici";
		}

		public override void DescribeColumns(DataTable T, string listtype)
		{
			base.DescribeColumns(T, listtype);
			if (listtype=="default") 
			{
				foreach (DataColumn C in T.Columns)
					DescribeAColumn(T, C.ColumnName, "",-1);

				DescribeAColumn(T, "nmaintenance", "Num. evento",1);
				DescribeAColumn(T, "maintenancekind", "Tipo evento",2);
				DescribeAColumn(T, "description", "Descrizione",3);
				DescribeAColumn(T, "ninventory", "Num. inventario",4);
				DescribeAColumn(T, "inventory", "Inventario",5);
				DescribeAColumn(T, "idasset", "Num. bene",6);
				DescribeAColumn(T, "loaddescription", "Descrizione bene inv.",7);
				DescribeAColumn(T, "amount", "Importo",8);
				DescribeAColumn(T, "adate", "Data cont.",9);
				DescribeAColumn(T, "codemaintenancekind", "Cod. evento.",10);
			}
		}   
	}
}
