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
using metaeasylibrary;
using metadatalibrary;

namespace meta_finlookup//meta_convertbilancio//
{
	/// <summary>
	/// Summary description for Meta_convertbilancio.
	/// </summary>
	public class Meta_finlookup : Meta_easydata
	{
		public Meta_finlookup(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "finlookup") 
		{		
			EditTypes.Add("default");
			ListingTypes.Add("default");
		}

		protected override Form GetForm(string EditType)
		{
			if (EditType=="default")
			{
				Name = "Converti voci di Bilancio annuale";
				DefaultListType = "default";
				return GetFormByDllName("finlookup_default");
			}
			return null;
		}

		public override void SetDefaults(DataTable PrimaryTable)
		{
			base.SetDefaults(PrimaryTable);
		}

		public override void DescribeColumns(DataTable T, string ListingType) 
		{
			base.DescribeColumns (T, ListingType);

			if (ListingType=="default") 
			{
				foreach (DataColumn C in T.Columns)
					DescribeAColumn(T,C.ColumnName,"");

				DescribeAColumn(T,"oldidfin","Vecchio ID");
				DescribeAColumn(T,"newidfin","Nuovo ID");
			}
		}

		public override DataRow SelectOne(string ListingType, string filter, string searchtable, DataTable Exclude) 
		{
			if (ListingType=="default") return base.SelectOne(ListingType, filter, "finlookupview", Exclude);
			return base.SelectOne(ListingType, filter, "finlookup", Exclude);
		}		

	}
}
