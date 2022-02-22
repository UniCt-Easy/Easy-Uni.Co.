
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

namespace meta_finsetup//meta_persbilancio//
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	public class Meta_finsetup : Meta_easydata 
	{
		public Meta_finsetup(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "finsetup") 
		{
			EditTypes.Add("default");
			ListingTypes.Add("persbilancio");
		}
		protected override Form GetForm(string FormName)
		{
			if (FormName=="default") 
			{
				Name = "Configurazione";
				DefaultListType="persbilancio";
				Form F = GetFormByDllName("finsetup_default");
				return F;
			}

			return null;
		}		


		public override void SetDefaults(DataTable PrimaryTable) {
			base.SetDefaults (PrimaryTable);
			SetDefault(PrimaryTable,"ayear", GetSys("esercizio"));
		}
	
		public override void DescribeColumns(DataTable T, string listtype)
		{
			base.DescribeColumns(T, listtype);
			DescribeAColumn(T, "ayear", "");
		}   
	}
}
