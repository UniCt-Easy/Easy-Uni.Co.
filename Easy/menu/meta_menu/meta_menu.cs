
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
//Pino: using MenuMaker; diventato inutile
using metaeasylibrary;
using metadatalibrary;

namespace meta_menu//meta_menu//
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	public class Meta_menu : Meta_easydata 
	{
		public Meta_menu(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "menu") 
		{
			EditTypes.Add("default");
			ListingTypes.Add("default");
		}
		protected override Form GetForm(string FormName)
		{
			
			if (FormName=="default")
			{
				Name = "Gestione del Menu";
				DefaultListType = "default";
				return MetaData.GetFormByDllName("menu_default");//PinoRana
			}
			return null;
		}			
		public override DataRow Get_New_Row(DataRow ParentRow, DataTable T)
		{
			RowChange.MarkAsAutoincrement(T.Columns["idmenu"],null,
				null,7);
			return base.Get_New_Row(ParentRow, T);
		}

		public override void DescribeColumns(DataTable T, string ListingType)
		{
			base.DescribeColumns(T, ListingType);
			DescribeAColumn(T,"idmenu","ID_Menu");
			DescribeAColumn(T,"paridmenu","SupID");
			DescribeAColumn(T,"menucode","MenuCode");
			DescribeAColumn(T,"title","Testo");
			DescribeAColumn(T,"metadata","Metadata");
			DescribeAColumn(T,"edittype","EditType");
			DescribeAColumn(T,"modal","Modal");
			DescribeAColumn(T,"ruleparameter","Parametro");
			DescribeAColumn(T,"userid","UserId");
		}
	}
}
