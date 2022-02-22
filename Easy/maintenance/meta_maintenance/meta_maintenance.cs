
/*
Easy
Copyright (C) 2022 Università degli Studi di Catania (www.unict.it)
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

namespace meta_maintenance
{
	/// <summary>
	/// Summary description for eventotecnico.
	/// </summary>
	public class Meta_maintenance : Meta_easydata 
	{
		public Meta_maintenance(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "maintenance") {
			EditTypes.Add("default");
			ListingTypes.Add("default");
		}
	
		protected override Form GetForm(string FormName) {
			if (FormName=="default")
			{
				Name="Manutenzione";
				DefaultListType="default";
				return MetaData.GetFormByDllName("maintenance_default");//PinoRana
			}
			return null;
		}

		public override DataRow Get_New_Row(DataRow ParentRow, DataTable T) {
			RowChange.MarkAsAutoincrement(T.Columns["nmaintenance"],null,null,6);
			return base.Get_New_Row(ParentRow, T);
		}
		
		public override void SetDefaults(DataTable T) {
			base.SetDefaults(T);
			SetDefault(T,"adate",GetSys("datacontabile"));
		}

		public override bool IsValid(DataRow R,out string errmess, out string errfield) {
			// Bisogna innanzitutto chiamare IsValid della classe base
			if (!base.IsValid(R, out errmess, out errfield)) return false;                   
			
			if(CfgFn.GetNoNullInt32(R["idasset"])<=0) {
				errmess="E' necessario specificare un bene.";
				errfield=null;
				return false;
			}
			if(R["description"].ToString()=="") {
				errmess="E' necessario specificare la descrizione dell'evento tecnico.";
				errfield="description";
				return false;
			}
			if(R["amount"]==DBNull.Value) {
				errmess="E' necessario specificare l'importo.";
				errfield="amount";
				return false;
			}
			return true;
		}

		public override DataRow SelectOne(string ListingType,string filter, string searchtable, DataTable ToMerge) {
			if(ListingType=="default")
				return base.SelectOne(ListingType, filter,"maintenanceview", ToMerge);
			return base.SelectOne(ListingType, filter, searchtable, ToMerge);
		}
	}
}
