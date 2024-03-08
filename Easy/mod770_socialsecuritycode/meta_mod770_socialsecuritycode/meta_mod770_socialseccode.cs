
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


namespace meta_mod770_socialsecuritycode {
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	public class Meta_mod770_socialsecuritycode : Meta_easydata
	{
		public Meta_mod770_socialsecuritycode(DataAccess Conn, MetaDataDispatcher Dispatcher)
            : base(Conn, Dispatcher, "mod770_socialsecuritycode")
		{
			Name="Categorie Previdenziali per la Certificazione Unica (Autonomi)";
			EditTypes.Add("default");
			ListingTypes.Add("default");
		}

		protected override Form GetForm(string FormName)
		{
			if (FormName=="default") 
			{
				 
                return GetFormByDllName("mod770_socialsecuritycode_default");
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
			DescribeAColumn(T, "ayear", "Anno Redditi");
			DescribeAColumn(T, "socialseccode", "Codice Categoria Previdenziale");
			DescribeAColumn(T, "description", "Descrizione Categoria Previdenziale");
            DescribeAColumn(T, "cfagency", "Codice Fiscale Ente Previdenziale");
            DescribeAColumn(T, "titleagency", "Ente Previdenziale");
        }
	}
}
