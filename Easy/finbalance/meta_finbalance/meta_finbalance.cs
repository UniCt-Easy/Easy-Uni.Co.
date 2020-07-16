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

namespace meta_finbalance//meta_bilancioassestamento//
{
	/// <summary>
	/// Summary description for Meta_bilancioassestamento.
	/// </summary>
	public class Meta_finbalance : Meta_easydata
	{
		public Meta_finbalance(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "finbalance") 
		{
			EditTypes.Add("default");
			ListingTypes.Add("default");
			Name = "Assestamento Bilancio Annuale";
		}

		protected override Form GetForm(string FormName) 
		{
			if (FormName=="default") 
			{
				DefaultListType="default";
				Form F = GetFormByDllName("finbalance_default");		
				return F;
			}
			return null;
		}			

		public override DataRow Get_New_Row(DataRow ParentRow, DataTable T) 
		{
			RowChange.SetSelector(T, "ayear");
			RowChange.MarkAsAutoincrement(T.Columns["nfinbalance"],null,
				null,0);
			DataRow R = base.Get_New_Row(ParentRow, T);
			return R;
		}

		
		public override void DescribeColumns(DataTable T, string listtype) 
		{
			base.DescribeColumns(T, listtype);
			if (listtype=="default") 
			{
				foreach (DataColumn C in T.Columns)
					DescribeAColumn(T, C.ColumnName, "");
				DescribeAColumn(T, "ayear", "Esercizio");
				DescribeAColumn(T, "nfinbalance", "Num. Assestamento");
			}
		}   

		
		public override void SetDefaults(DataTable T) 
		{
			base.SetDefaults(T);
			SetDefault(T,"ayear",GetSys("esercizio").ToString());
			SetDefault(T,"balancedate", GetSys("datacontabile").ToString());
		}

		public override DataRow SelectOne(string ListingType, string filter, string searchtable, DataTable Exclude) 
		{
			return base.SelectOne(ListingType, filter, "finbalance", Exclude);			
		}		
	
	}
}
