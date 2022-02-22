
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
using metaeasylibrary;
using metadatalibrary;
//Pino: using colname; diventato inutile
using System.Windows.Forms;

namespace meta_colname//meta_colname//
{
	/// <summary>
	/// Summary description for Class1.PINO
	/// </summary>
	public class Meta_colname : Meta_easydata
	{
		public Meta_colname(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "colname") 
		{		
			EditTypes.Add("default");
			Name="colname";
		}
		protected override Form GetForm(string FormName)
		{
			switch (FormName) {
				case "default": 
					return MetaData.GetFormByDllName("colname_default");//PinoRana
				case "traduci":
					return GetFormByDllName("colname_traduci");
			}
			return null;
		}
	}
}
