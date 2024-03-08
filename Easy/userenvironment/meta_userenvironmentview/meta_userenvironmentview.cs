
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

namespace meta_userenvironmentview//meta_userenvironmentview//
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	public class Meta_userenvironmentview : Meta_easydata {
		public Meta_userenvironmentview(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "userenvironmentview") {		
			Name= "variabili d'ambiente";
			ListingTypes.Add("lista");
		}
		public override void DescribeColumns(DataTable T, string ListingType) {
			base.DescribeColumns(T, ListingType);
			if (ListingType=="lista") {
				foreach (DataColumn C in T.Columns)
					DescribeAColumn(T, C.ColumnName, "");
				DescribeAColumn(T, "username", "Nome utente");
				DescribeAColumn(T, "variablename", "Nome var.");
				DescribeAColumn(T, "value", "Valore var.");
				DescribeAColumn(T, "kind", "Tipo var.");
				DescribeAColumn(T, "flagadmin", "Modif. ammin.?");
				DescribeAColumn(T, "idenvironment", "ID var.");
			}
		}
	}
}
