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
using System.Windows.Forms;
using metaeasylibrary;
using metadatalibrary;
//Pino: using classtreeclassinventariosingle; diventato inutile

namespace meta_inventorytreesorting{//meta_classtreeclassinventario//
	/// <summary>
	/// Summary description for Meta_classtreeclassinventario.
	/// </summary>
	public class Meta_inventorytreesorting : Meta_easydata {
		public Meta_inventorytreesorting(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "inventorytreesorting") {
//			EditTypes.Add("default");
			EditTypes.Add("single");
			ListingTypes.Add("default");
			Name = "Classificazione gerarchica inventario";
		}
		protected override Form GetForm(string FormName){
			if (FormName=="single") 
				return MetaData.GetFormByDllName("inventorytreesorting_single");//PinoRana
			return null;
		}			

		public override void DescribeColumns(DataTable T, string ListingType){
			base.DescribeColumns(T, ListingType);

			if (ListingType=="default") {
				foreach (DataColumn C in T.Columns)
					DescribeAColumn(T,C.ColumnName,"");
                int nPos = 1;
                DescribeAColumn(T, "!sortingkind", "Tipo", "sortingview.sortingkind", nPos++);
                DescribeAColumn(T, "!codiceclass", "Codice", "sortingview.sortcode", nPos++);
                DescribeAColumn(T, "!description", "Descrizione", "sortingview.description", nPos++);
			}
		}   
	}
}
