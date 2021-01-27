
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
using metadatalibrary;
using metaeasylibrary;
using System.Windows.Forms;
using System.Data;

namespace meta_trasmissionmanager//meta_responsabiletrasmissione//
{
	/// <summary>
	/// Summary description for Meta_responsabiletrasmissione.
	/// </summary>
	public class Meta_trasmissionmanager : Meta_easydata
	{
		public Meta_trasmissionmanager(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "trasmissionmanager") 
		{
			EditTypes.Add("default");
			ListingTypes.Add("default");
		}

		protected override Form GetForm(string FormName)
		{
			if (FormName=="default") 
			{
				DefaultListType="default";
				Name = "Responsabile Trasmissione Documenti";
				return GetFormByDllName("trasmissionmanager_default");
			}
			return null;
		}

		public override void SetDefaults(DataTable PrimaryTable)
		{
			base.SetDefaults(PrimaryTable);
			SetDefault(PrimaryTable, "ayear", GetSys("esercizio"));
		}

		public override DataRow SelectOne(string ListingType, string filter, string searchtable, DataTable ToMerge)
		{
			if (ListingType=="default")
			{
				return base.SelectOne(ListingType, filter, "trasmissionmanagerview", ToMerge);
			}
			return base.SelectOne (ListingType, filter, searchtable, ToMerge);
		}

	}
}
