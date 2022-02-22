
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
//Pino: using varclassmovimentispese; diventato inutile

namespace meta_sortingprevexpensevar//meta_varclassmovimentispese//
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	public class Meta_sortingprevexpensevar : Meta_easydata 
	{
		public Meta_sortingprevexpensevar(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "sortingprevexpensevar") 
		{
			EditTypes.Add("default");
			EditTypes.Add("relation");
			ListingTypes.Add("default");
		}
		protected override Form GetForm(string FormName)
		{
			if ((FormName=="default") || (FormName=="relation")) 
			{
				Name="Spese";
				DefaultListType="default";			
				return MetaData.GetFormByDllName("sortingprevexpensevar_default");//PinoRana
			}
			return null;
		}	

		public override void SetDefaults(DataTable PrimaryTable)
		{
			base.SetDefaults(PrimaryTable);
			SetDefault(PrimaryTable, "yvar", GetSys("esercizio"));
			SetDefault(PrimaryTable, "ayear", GetSys("esercizio"));
			SetDefault(PrimaryTable, "adate", GetSys("datacontabile"));
		}

		public override DataRow Get_New_Row(DataRow ParentRow, DataTable T)
		{
			RowChange.SetSelector(T,"yvar");
			RowChange.MarkAsAutoincrement(T.Columns["nvar"],null,
				null,7);
			return base.Get_New_Row(ParentRow, T);
		}

		public override DataRow SelectOne(string ListingType, string filter, string searchtable, DataTable Exclude) 
		{
			if (ListingType=="default") 
				return base.SelectOne(ListingType, filter, "sortingprevexpensevarview", Exclude);
			return null;
		}

	}
}
