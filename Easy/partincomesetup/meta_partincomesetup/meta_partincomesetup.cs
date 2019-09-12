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
using System.Data;
using System.Windows.Forms;
using metaeasylibrary;
using metadatalibrary;
//Pino: using ripassegnazione; diventato inutile


namespace meta_partincomesetup//meta_ripassegnazione//
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	public class Meta_partincomesetup : Meta_easydata {
		public Meta_partincomesetup(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "partincomesetup") {
			EditTypes.Add("default");
			ListingTypes.Add("lista");
		}
		protected override Form GetForm(string FormName){
			if (FormName=="default") {
				DefaultListType="lista";
				Name = "Configurazione";
				return MetaData.GetFormByDllName("partincomesetup_default");//PinoRana
			}
			return null;
		}		
	
		public override void SetDefaults(DataTable PrimaryTable){
			base.SetDefaults(PrimaryTable);
		}

		public override bool IsValid(DataRow R,out string errmess, out string errfield){            
			if (!base.IsValid(R, out errmess, out errfield)) return false;                 
			if (R["idfinincome"].ToString()==""){
				errmess="Inserire una voce bilancio di entrata.";
				errfield=null;
				return false;
			}
			if (R["idfinexpense"].ToString()==""){
				errmess="Inserire una voce bilancio di spesa.";
				errfield=null;
				return false;
			}
			if (R["percentage"]==DBNull.Value){
				errmess="Attenzione! Inserire una percentuale.";
				errfield="percentage";
				return false;
			}
			return true;
		}

		public override DataRow SelectOne(string ListingType, string filter, string searchtable, DataTable Exclude) {
			if (ListingType=="lista")
				return base.SelectOne(ListingType, filter, "partincomesetupview", Exclude);
			else
				return base.SelectOne(ListingType, filter, "partincomesetup", Exclude);
		}		
	}
}
