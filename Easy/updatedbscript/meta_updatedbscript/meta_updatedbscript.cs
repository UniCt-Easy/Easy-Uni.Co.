
/*
Easy
Copyright (C) 2021 Università degli Studi di Catania (www.unict.it)
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
using System.Windows.Forms;
using metaeasylibrary;
using metadatalibrary;
//Pino: using updatedbscript; diventato inutile
using System.Data;

namespace meta_updatedbscript//meta_updatedbscript//
{
	/// <summary>
	/// Summary description for Meta_updatedbscript.
	/// </summary>
	public class Meta_updatedbscript : Meta_easydata {
		public Meta_updatedbscript(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "updatedbscript") {		
			Name= "Script SQL";
			EditTypes.Add("default");			
			ListingTypes.Add("default");
		}

		protected override Form GetForm(string FormName) {
			if (FormName=="default") {
				DefaultListType= "default";
				return MetaData.GetFormByDllName("updatedbscript_default");//PinoRana
			}
			return null;
		}

		public override void DescribeColumns(System.Data.DataTable T, string ListingType) {
			base.DescribeColumns (T);
			if (ListingType == "default") {
				foreach (DataColumn C in T.Columns)
					DescribeAColumn(T,C.ColumnName,"");
				DescribeAColumn(T, "scriptname", "Nome dello script");
				DescribeAColumn(T, "result", "Risultato");
			}
		}
	}
}
