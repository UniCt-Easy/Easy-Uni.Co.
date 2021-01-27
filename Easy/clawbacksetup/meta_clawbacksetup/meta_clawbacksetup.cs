
/*
Easy
Copyright (C) 2021 Universit� degli Studi di Catania (www.unict.it)
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
//Pino: using automatismirecuperi; diventato inutile


namespace meta_clawbacksetup//meta_automatismirecuperi//
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	public class Meta_clawbacksetup : Meta_easydata {
		public Meta_clawbacksetup(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "clawbacksetup") {
			EditTypes.Add("default");
			ListingTypes.Add("lista");
			Name = "";
		}
		protected override Form GetForm(string FormName)
		{
			if (FormName=="default")
			{
				DefaultListType="lista";
				Name = "Automatismi dei recuperi";
				return MetaData.GetFormByDllName("clawbacksetup_default");//PinoRana
			}
			return null;
		}		
	
		public override void SetDefaults(DataTable PrimaryTable){
			base.SetDefaults(PrimaryTable);
			SetDefault(PrimaryTable, "ayear", GetSys("esercizio").ToString());
		}

		public override bool IsValid(DataRow R,out string errmess, out string errfield){            
			if (!base.IsValid(R, out errmess, out errfield)) return false;                 
			if (R["clawbackfinance"]==DBNull.Value){
				errmess="Attenzione! Inserire una voce di bilancio.";
				errfield="clawbackfinance";
				return false;
			}
			return true;
		}

		public override DataRow SelectOne(string ListingType, string filter, string searchtable, DataTable Exclude) {
			if (ListingType=="lista")
				return base.SelectOne(ListingType, filter, "clawbacksetupview", Exclude);
			else
				return base.SelectOne(ListingType, filter, "clawbacksetup", Exclude);
		}		
	}
}
