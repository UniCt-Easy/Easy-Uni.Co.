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

namespace meta_sortingprevexpensevarview//meta_varclassmovimentispeseview//
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	public class Meta_sortingprevexpensevarview : Meta_easydata 
	{
		public Meta_sortingprevexpensevarview(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "sortingprevexpensevarview") 
		{
			ListingTypes.Add("default");   
		}

		public override void DescribeColumns(DataTable T, string ListingType) 
		{			
			base.DescribeColumns(T, ListingType);
			if (ListingType=="default") 
			{
				foreach(DataColumn C in T.Columns) 
				{
					DescribeAColumn(T, C.ColumnName, "");
				}

				DescribeAColumn(T, "yvar", "Eserc. variaz.");
				DescribeAColumn(T, "nvar", "Num. variaz.");
				DescribeAColumn(T, "sortcode", "Codice class.");
				DescribeAColumn(T, "sorting", "Descr. class.");
				DescribeAColumn(T, "ayear", "Esercizio");
				DescribeAColumn(T, "description", "Descrizione");
				DescribeAColumn(T, "amount", "Importo");
				DescribeAColumn(T, "adate", "Data contabile");
			}
		}
	}
}
