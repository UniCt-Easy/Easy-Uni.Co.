
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
using metadatalibrary;
using metaeasylibrary;
using System.Windows.Forms;
using System.Data;


namespace meta_mod770_exemptioncode
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	public class Meta_mod770_exemptioncode : Meta_easydata
	{
		public Meta_mod770_exemptioncode(DataAccess Conn, MetaDataDispatcher Dispatcher)
            : base(Conn, Dispatcher, "mod770_exemptioncode")
		{
			Name="Causali esenzione per il mod. 770";
			EditTypes.Add("default");
			ListingTypes.Add("default");
		}

		protected override Form GetForm(string FormName)
		{
			if (FormName=="default") 
			{
				ActAsList();
                return GetFormByDllName("mod770_exemptioncode_default");
			}
			return null;
		}			

		public override void SetDefaults(DataTable PrimaryTable)
		{
			base.SetDefaults(PrimaryTable);
			SetDefault(PrimaryTable, "ayear", 
				Conn.GetEsercizio());
		}

		public override void DescribeColumns(DataTable T, string ListingType)
		{
			base.DescribeColumns (T, ListingType);
			DescribeAColumn(T, "ayear", "Anno 770");
			DescribeAColumn(T, "exemptioncode", "Codice");
			DescribeAColumn(T, "description", "Descrizione della causale di esenzione");
		}
	}
}
