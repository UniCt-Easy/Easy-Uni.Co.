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

namespace meta_assetvardetailview{//meta_dettvarpatrimonioview//
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	public class Meta_assetvardetailview : Meta_easydata {
		public Meta_assetvardetailview(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "assetvardetailview") {		
			Name= "dettaglio variazione patrimonio";
			ListingTypes.Add("default");
		}

		public override void DescribeColumns(DataTable T, string listtype) {
			base.DescribeColumns(T, listtype);
			if (listtype=="default") {
				foreach(DataColumn C in T.Columns) {
					DescribeAColumn(T,C.ColumnName,"",-1);
				}
				int nPos = 1;
				DescribeAColumn(T, "yvar","Eserc. variaz.", nPos++);
				DescribeAColumn(T, "nvar","Num. variaz.", nPos++);
				DescribeAColumn(T, "codeinventoryagency","Codice Ente inv.", nPos++);
				DescribeAColumn(T, "inventoryagency","Ente inv.", nPos++);
				DescribeAColumn(T, "variationdescription","Desc. variaz.", nPos++);
				DescribeAColumn(T, "enactment","Provvedimento", nPos++);
				DescribeAColumn(T, "nenactment","Num. provv.", nPos++);
				DescribeAColumn(T, "enactementdate","Data provv.", nPos++);
				DescribeAColumn(T, "variationkind","Tipo var.", nPos++);
				DescribeAColumn(T, "codeinv","Codice class.", nPos++);
				DescribeAColumn(T, "inventorytree","Denom. class.", nPos++);
				DescribeAColumn(T, "description", "Descrizione", nPos++);
				DescribeAColumn(T, "amount", "Importo", nPos++);
				DescribeAColumn(T, "adate", "Data cont.", nPos++);
				DescribeAColumn(T, "inventory", "Inventario", nPos++);
			}
		}   
	}
}