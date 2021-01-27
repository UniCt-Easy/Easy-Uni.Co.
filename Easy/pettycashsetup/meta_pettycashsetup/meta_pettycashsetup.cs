
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
using System.Data;
using System.Windows.Forms;
using metadatalibrary;
using metaeasylibrary;
//Pino: using perspiccolespese; diventato inutile


namespace meta_pettycashsetup {//meta_perspiccolespese//
	/// <summary>
	/// Summary description for perspiccolespese.
	/// </summary>
	public class Meta_pettycashsetup : Meta_easydata {
		public Meta_pettycashsetup(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "pettycashsetup") {
			EditTypes.Add("default");
			ListingTypes.Add("default");
		}
	
		protected override Form GetForm(string FormName) {
			if (FormName=="default") {
				DefaultListType="default";
				Name="Configurazione";
				return MetaData.GetFormByDllName("pettycashsetup_default");//PinoRana
			}
			return null;
		}

		public override void SetDefaults(DataTable PrimaryTable) {
			base.SetDefaults(PrimaryTable);
			SetDefault(PrimaryTable, "ayear", GetSys("esercizio"));
		}

		public override DataRow SelectOne(string ListingType, 
			string filter, string searchtable, DataTable ToMerge) {
			if(ListingType=="default")
				return base.SelectOne(ListingType, filter, 
					"pettycashsetupview", ToMerge);
			return base.SelectOne(ListingType, filter, 
				searchtable, ToMerge);
		}

	}
}
