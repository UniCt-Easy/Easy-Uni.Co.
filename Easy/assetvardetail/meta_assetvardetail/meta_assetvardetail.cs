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
using metaeasylibrary;
using metadatalibrary;
using assetvardetail_default;//dettvarpatrimonio
//Pino: using dettvarpatrimonio_detail; diventato inutile
using System.Windows.Forms;
using System.Data;

namespace meta_assetvardetail {//meta_dettvarpatrimonio//
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	public class Meta_assetvardetail : Meta_easydata {
		public Meta_assetvardetail(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "assetvardetail") {		
			EditTypes.Add("default");
			EditTypes.Add("detail");
			ListingTypes.Add("default");
		}

		protected override Form GetForm(string FormName) {
			if (FormName=="default") {
				Name = "Dettaglio variazione";
				DefaultListType = "default";
				return MetaData.GetFormByDllName("assetvardetail_default");//PinoRana
			}
			if (FormName=="detail") {
				Name = "Dettaglio variazione";
				DefaultListType = "default";
				return MetaData.GetFormByDllName("assetvardetail_detail");//PinoRana
			}
			return null;
		}

		public override DataRow Get_New_Row(DataRow ParentRow, DataTable T) {
			RowChange.SetSelector(T, "idassetvar");
			RowChange.MarkAsAutoincrement(T.Columns["idassetvardetail"], null, null, 7);
			DataRow R = base.Get_New_Row (ParentRow, T);
			return R;
		}

		public override void DescribeColumns(DataTable T, string listtype) {
			base.DescribeColumns(T, listtype);
			if (listtype=="default") {
				foreach(DataColumn C in T.Columns) {
					DescribeAColumn(T, C.ColumnName, "", -1);
				}
				int nPos = 1;
				DescribeAColumn(T, "!classificazione", "Classificazione", "inventorytree.codeinv", nPos++);
				DescribeAColumn(T, "!nome_classificazione", "Denom. classificazione", "inventorytree.description", nPos++);
				DescribeAColumn(T, "description", "Descrizione", nPos++);	
				DescribeAColumn(T, "amount", "Importo", nPos++);
				DescribeAColumn(T, "!inventory", "Inventario", "inventory.description", nPos++);
			}
		}   
		
		public override System.Data.DataRow SelectOne(string ListingType, string filter, string searchtable, System.Data.DataTable ToMerge) {
			if (ListingType=="default") {
				return base.SelectOne (ListingType, filter, "assetvardetailview", ToMerge);
			}
			return base.SelectOne (ListingType, filter, searchtable, ToMerge);
		}

		public override bool IsValid(DataRow R, out string errmess, out string errfield) {
			if (!base.IsValid (R, out errmess, out errfield)) return false;

			if (R["amount"].ToString()=="") {
				errmess="E' necessario specificare l'importo";
				errfield="amount";
				return false;
			}
			return true;
		}

	}
}