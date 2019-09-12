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
using metadatalibrary;
using metaeasylibrary;

namespace meta_unifiedivapay {
	/// <summary>
	/// Summary description for Meta_unifiedivapay.
	/// </summary>
	public class Meta_unifiedivapay : Meta_easydata {
		public Meta_unifiedivapay(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "unifiedivapay") {
			EditTypes.Add("default");
			ListingTypes.Add("default");
		}

		protected override Form GetForm(string FormName){
			if (FormName=="default") {
				Name="Consolidamento Liquidazione IVA Periodica";
				DefaultListType="default";
				return MetaData.GetFormByDllName("unifiedivapay_default");
			}
			return null;
		}

		public override void DescribeColumns(DataTable T, string ListingType){
			base.DescribeColumns(T, ListingType);
			if ( ListingType=="default"){
				foreach (DataColumn C in T.Columns) {
					DescribeAColumn(T, C.ColumnName,"",-1);
				}
				int nPos = 1;
				DescribeAColumn(T, "yunifiedivapay","Eserc. Liquidazione", nPos++);
				DescribeAColumn(T, "nunifiedivapay","Num. Liquidazione", nPos++);
				DescribeAColumn(T, "iddepartment", "ID Dipartimento", nPos++);
			}
		}

		public override void SetDefaults(DataTable PrimaryTable) {
			base.SetDefaults (PrimaryTable);
			SetDefault(PrimaryTable, "yunifiedivapay", Conn.GetSys("esercizio"));
		}

		public override DataRow Get_New_Row(DataRow ParentRow, DataTable T) {
			RowChange.SetSelector(T, "iddepartment");
			RowChange.SetSelector(T, "yunifiedivapay");
			RowChange.MarkAsAutoincrement(T.Columns["nunifiedivapay"], null, null, 7);
			DataRow R = base.Get_New_Row (ParentRow, T);
			return R;
		}

		public override DataRow SelectOne(string ListingType, string filter, string searchtable, DataTable ToMerge) {
			if (ListingType == "default") {
				return base.SelectOne (ListingType, filter, "unifiedivapayview", ToMerge);
			}
			return base.SelectOne (ListingType, filter, searchtable, ToMerge);
		}

	}
}