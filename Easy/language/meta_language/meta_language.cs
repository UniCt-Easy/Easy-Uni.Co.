
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
using System.Windows.Forms;
using System.Data;
using metaeasylibrary;
//Pino: using lingualista; diventato inutile
//using lingua;
using metadatalibrary;

namespace meta_language//meta_lingua//
{

	public class Meta_language : Meta_easydata 
	{
		public Meta_language(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "language") 
		{
			EditTypes.Add("lista");
			ListingTypes.Add("default");
			Name = "Lingua";
		}
		protected override Form GetForm(string FormName)
		{
			if (FormName=="lista") 
			{
				ActAsList();
				return MetaData.GetFormByDllName("language_lista");//PinoRana
			}

			return null;
		}			
	
		
		public override void DescribeColumns(DataTable T, string listtype)
		{
			base.DescribeColumns(T, listtype);
			DescribeAColumn(T, "idlanguage","Codice Lingua");
			DescribeAColumn(T, "description","Nome Lingua");
		}   

	
	}
}
