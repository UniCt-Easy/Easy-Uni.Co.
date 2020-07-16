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

namespace meta_prevfin//meta_bilancioprevisione//
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	public class Meta_prevfin : Meta_easydata {
		public Meta_prevfin(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "prevfin") {
			EditTypes.Add("default");
			ListingTypes.Add("default");
		}

		protected override Form GetForm(string FormName) {
			if (FormName=="default")
			{
                int N = Convert.ToInt32(GetSys("esercizio")) + 1;
				Name = "Previsione di Bilancio "+N;
				DefaultListType="default";
				return GetFormByDllName("prevfin_default");		
			}
			return null;
		}			

		public override DataRow Get_New_Row(DataRow ParentRow, DataTable T) {
			RowChange.SetSelector(T, "ayear");
			RowChange.MarkAsAutoincrement(T.Columns["nprevfin"],null,
				null,0);
			DataRow R = base.Get_New_Row(ParentRow, T);
			//if (edit_type=="default") R["numprevisione"]=-1;
			return R;
		}
		
		public override void DescribeColumns(DataTable T, string listtype) {
			base.DescribeColumns(T, listtype);
			if (listtype=="default") {
				foreach (DataColumn C in T.Columns)
					DescribeAColumn(T, C.ColumnName, "");
				DescribeAColumn(T, "ayear", "Esercizio");
				DescribeAColumn(T, "nprevfin", "Num. Prev.");
			}
		}   
		
		public override void SetDefaults(DataTable T) {
			base.SetDefaults(T);
			SetDefault(T,"ayear",GetSys("esercizio"));
			SetDefault(T,"previsiondate", GetSys("datacontabile"));
		}

		public override DataRow SelectOne(string ListingType, string filter, string searchtable, DataTable Exclude) {
			return base.SelectOne(ListingType, filter, "prevfin", Exclude);			
		}			
	}
}
