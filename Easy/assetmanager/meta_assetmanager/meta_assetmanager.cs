
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
using System.Windows.Forms;
using metadatalibrary;
using metaeasylibrary;
using funzioni_configurazione;
//Pino: using responsabileinventariosingle; diventato inutile

namespace meta_assetmanager{//meta_responsabileinventario//
	/// <summary>
	/// Summary description for Meta_ubicazioneinventario.
	/// </summary>
	public class Meta_assetmanager : Meta_easydata {
		public Meta_assetmanager(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "assetmanager") {
			EditTypes.Add("single");
			ListingTypes.Add("detail");
			Name = "Responsabile cespite";
		}
		protected override Form GetForm(string FormName){
			if (FormName=="single") 
				return MetaData.GetFormByDllName("assetmanager_single");//PinoRana
			return null;
		}
        public override DataRow Get_New_Row(DataRow ParentRow, DataTable T) {
            RowChange.SetSelector(T, "idasset");
            RowChange.MarkAsAutoincrement(T.Columns["idassetmanager"], null, null, 7);
            return base.Get_New_Row(ParentRow, T);
        }

		public override void DescribeColumns(DataTable T, string ListingType) {
			base.DescribeColumns (T, ListingType);

			if (ListingType=="detail") {
				foreach (DataColumn C in T.Columns) 
					DescribeAColumn(T,C.ColumnName,"");

				DescribeAColumn(T,"start","Data");
				DescribeAColumn(T,"!manager","Descrizione","manager.title");
			}
		}
        public override bool IsValid(DataRow R, out string errmess, out string errfield) {
            if (CfgFn.GetNoNullInt32(R["idman"]) == 0) {
                errmess = "E' necessario selezionare il responsabile";
                errfield = "idman";
                return false;
            }
            return base.IsValid(R, out errmess, out errfield);
        }


	}
}
