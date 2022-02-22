
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
using metadatalibrary;
using metaeasylibrary;
using System.Windows.Forms;
//Pino: using Gruppoestero; diventato inutile

namespace meta_foreigngroup//meta_gruppoestero//
{
	/// <summary>
	/// Summary description for gruppoestero.
	/// </summary>
	public class Meta_foreigngroup : Meta_easydata
	{
		public Meta_foreigngroup(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "foreigngroup") {		
			EditTypes.Add("default");
			ListingTypes.Add("default");
		}

		protected override Form GetForm(string FormName)
		{
			if (FormName=="default")
			{
				Name="Elenco dei gruppi esteri";
				DefaultListType="default";
				return MetaData.GetFormByDllName("foreigngroup_default");//PinoRana
			}
			return null;
		}
		
		public override void DescribeColumns(DataTable T, string ListingType){
			base.DescribeColumns(T, ListingType);
			if (ListingType=="default"){
				DescribeAColumn(T,"start","Data di Decorrenza");
				DescribeAColumn(T,"foreigngroupnumber","Gruppo estero");
			}
			return;
		}
	}
}
