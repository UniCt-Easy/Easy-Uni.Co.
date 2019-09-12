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
//Pino: using livellobilancio; diventato inutile

namespace meta_finlevel//meta_livellobilancio//
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	public class Meta_finlevel : Meta_easydata 
	{
		public Meta_finlevel(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "finlevel") 
		{
			EditTypes.Add("default");
			ListingTypes.Add("default");
		}
		protected override Form GetForm(string FormName)
		{
			if (FormName=="default") 
			{
				Name = "Livelli del bilancio annuale";
				ActAsList();
				return MetaData.GetFormByDllName("finlevel_default");//PinoRana
			}

			return null;
		}			
	
		public override void SetDefaults(DataTable PrimaryTable)
		{
			base.SetDefaults(PrimaryTable);
			SetDefault(PrimaryTable, "ayear", GetSys("esercizio"));
			SetDefault(PrimaryTable, "flag", 4);
		}

		public override DataRow Get_New_Row(DataRow ParentRow, DataTable T)
		{
			RowChange.MarkAsAutoincrement(T.Columns["nlevel"],null,
				null,0);
			RowChange.SetSelector(T, "ayear");
			return base.Get_New_Row(ParentRow, T);
		}
	
		public override void DescribeColumns(DataTable T, string listtype)
		{
			base.DescribeColumns(T, listtype);
			foreach (DataColumn C in T.Columns)
				DescribeAColumn(T, C.ColumnName, "");
			DescribeAColumn(T, "nlevel","Codice Livello");
			DescribeAColumn(T, "description","Descrizione");
		}   

	
	}
}
