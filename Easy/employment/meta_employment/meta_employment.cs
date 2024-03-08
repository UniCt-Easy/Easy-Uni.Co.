
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
using System.Windows.Forms;
using System.Data;
using metaeasylibrary;
//Pino: using tipocategorialista; diventato inutile
using metadatalibrary;



namespace meta_employment//meta_tipocategoria//
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	public class Meta_employment : Meta_easydata 
	{
		public Meta_employment(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "employment") 
		{
			EditTypes.Add("lista");
			ListingTypes.Add("default");
			Name = "Tipo categoria";
		}
		protected override Form GetForm(string FormName)
		{
			if (FormName=="lista") 
			{
				ActAsList();
				return MetaData.GetFormByDllName("employment_lista");//PinoRana
			}
			return null;
		}			
		public override void DescribeColumns(DataTable T, string listtype)
		{
			base.DescribeColumns(T, listtype);
			if ( listtype=="default")
			{
				DescribeAColumn(T, "idemployment","Categoria");
				DescribeAColumn(T, "description","Descrizione");
			}
		}   
	}
}
