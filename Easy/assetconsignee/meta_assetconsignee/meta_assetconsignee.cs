/*
    Easy
    Copyright (C) 2020 Università degli Studi di Catania (www.unict.it)
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
//Pino: using consegnatarioinventario; diventato inutile

namespace meta_assetconsignee//meta_consegnatarioinventario//
{
	/// <summary>
	/// Summary description for Meta_consegnatarioinventario 
	/// </summary>
	public class Meta_assetconsignee : Meta_easydata {
		public Meta_assetconsignee(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "assetconsignee") {
			EditTypes.Add("default");
			EditTypes.Add("lista");
			ListingTypes.Add("default");
			ListingTypes.Add("lista");
		}

		protected override Form GetForm(string FormName) {
			if (FormName=="default") {
				DefaultListType = "default";
				Name = "Consegnatario inventario";
				return MetaData.GetFormByDllName("assetconsignee_default");//PinoRana
			}
			if (FormName=="lista") 
			{
				ActAsList();
				Name = "Consegnatario inventario";
				DefaultListType = "lista";
				return GetFormByDllName("assetconsignee_lista");
			}
			return null;
		}
	
		public override void SetDefaults(DataTable PrimaryTable)
		{
			base.SetDefaults(PrimaryTable);
			
			SetDefault(PrimaryTable, "start", Conn.GetDataContabile());
            SetDefault(PrimaryTable, "active", 'S');
		}
		
		public override DataRow SelectOne(string ListingType, string filter, string searchtable, DataTable ToMerge) 
		{
			if (ListingType=="default")
				return base.SelectOne (ListingType, filter, "assetconsigneeview", ToMerge);
			return base.SelectOne (ListingType, filter, searchtable, ToMerge);
		}

		public override void DescribeColumns(DataTable T, string ListingType) {
			base.DescribeColumns(T, ListingType);
			if (ListingType=="lista") {
				foreach (DataColumn C in T.Columns)
					DescribeAColumn(T, C.ColumnName, "");

                DescribeAColumn(T, "!codeinventoryagency", "Codice ente", "inventoryagency.codeinventoryagency");
				DescribeAColumn(T, "!ente", "Ente","inventoryagency.description");
				DescribeAColumn(T, "start", "Data inizio");
				DescribeAColumn(T, "qualification", "Titolo");
				DescribeAColumn(T, "title", "Nome");
                DescribeAColumn(T, "active", "Attivo");
			}
		}

	}
}
