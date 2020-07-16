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
using metadatalibrary;
using metaeasylibrary;
using System.Data;
using System.Windows.Forms;

namespace meta_checkup{//meta_diagnostica//
	/// <summary>
	/// Summary description for diagnostica.
	/// </summary>
	public class Meta_checkup : Meta_easydata {
		public Meta_checkup(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "checkup") {		
			EditTypes.Add("default");
			ListingTypes.Add("default");
			
			//
			// TODO: Add constructor logic here
			//
		}

		protected override Form GetForm(string FormName){
			if (FormName=="default") {
				Name="Diagnostica";
				DefaultListType="default";
				//IsList=false;
				return GetFormByDllName("checkup_default");
			}
			return null;
		}
		public override DataRow Get_New_Row(DataRow ParentRow, DataTable T) {
			RowChange.MarkAsAutoincrement(T.Columns["idcheckup"],null,null,6);
			return base.Get_New_Row (ParentRow, T);
		}

		
		public override void DescribeColumns(DataTable T, string ListingType){
			base.DescribeColumns(T, ListingType);
			if (ListingType=="default"){
				//DescribeAColumn(T,"idcustomuser","Codice utente");
				//DescribeAColumn(T,"username","Nome utente");
			}
			return;
		}

	}
}