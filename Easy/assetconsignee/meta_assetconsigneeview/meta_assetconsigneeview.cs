/*
    Easy
    Copyright (C) 2019 Universit� degli Studi di Catania (www.unict.it)

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
using metaeasylibrary;
using metadatalibrary;

namespace meta_assetconsigneeview//meta_consegnatarioinventarioview//
{
	/// <summary>
	/// Summary description for Meta_consegnatarioinventarioview
	/// </summary>
	public class Meta_assetconsigneeview : Meta_easydata {
		public Meta_assetconsigneeview(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "assetconsigneeview") {
			ListingTypes.Add("default");
			Name = "Elenco consegnatari inventario";
		}

		public override void DescribeColumns(DataTable T, string ListingType) {
			base.DescribeColumns(T, ListingType);
			if (ListingType=="default") {
				foreach (DataColumn C in T.Columns)
					DescribeAColumn(T, C.ColumnName, "");

				//DescribeAColumn(T, "idinventoryagency", "Codice ente");
				DescribeAColumn(T, "agency", "Ente");
				DescribeAColumn(T, "start", "Data inizio");
				DescribeAColumn(T, "qualification", "Titolo");
				DescribeAColumn(T, "title", "Consegnatario");
			}
		}
	}
}
