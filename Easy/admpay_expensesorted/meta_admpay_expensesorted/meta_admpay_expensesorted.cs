
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
using System.Data;
using System.Windows.Forms;
using metadatalibrary;
using metaeasylibrary;
using funzioni_configurazione;

namespace meta_admpay_expensesorted {
	/// <summary>
	/// Summary description for Meta_admpay_expensesorted.
	/// </summary>
	public class Meta_admpay_expensesorted : Meta_easydata {
		public Meta_admpay_expensesorted(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "admpay_expensesorted") {	
			EditTypes.Add("detail");
			ListingTypes.Add("detail");
		}

		protected override Form GetForm(string EditType) {
			if (EditType == "detail") {
				DefaultListType = "detail";
				Name = "Classificazione Spesa dei Pagamenti Stipendi";
				return GetFormByDllName("admpay_expensesorted_detail");
			}
			return null;
		}

		public override DataRow Get_New_Row(DataRow ParentRow, DataTable T) {
			RowChange.SetSelector(T, "yadmpay");
			RowChange.SetSelector(T, "nadmpay");
			RowChange.SetSelector(T, "nexpense");
			RowChange.SetSelector(T, "idsor");
			RowChange.MarkAsAutoincrement(T.Columns["idsubclass"], null, null, 7);
			return base.Get_New_Row(ParentRow, T);
		}

		public override void DescribeColumns(DataTable T, string ListingType) {
			base.DescribeColumns (T, ListingType);
			if (ListingType == "detail") {
				foreach(DataColumn C in T.Columns) {
					DescribeAColumn(T, C.ColumnName, "", -1);
				}
				int nPos = 1;
                DescribeAColumn(T, "!idsorkind", "", "sorting.idsorkind", nPos++);
				DescribeAColumn(T, "idsubclass", "#", nPos++);
				DescribeAColumn(T, "!percentuale", "%", "", nPos++);
				DescribeAColumn(T, "!sortcode", "Classificazione", "sorting.sortcode", nPos++);
				DescribeAColumn(T, "amount", "Importo", nPos++);
				ComputeRowsAs(T, "detail");
			}
		}

		public override void CalculateFields(System.Data.DataRow R, string listtype) {
			DataTable Unfiltered = (DataTable) R.Table.ExtendedProperties["UnfilteredTable"];
			if (Unfiltered==null) Unfiltered = R.Table;
			if (Unfiltered.ExtendedProperties["TotaleImporto"]==null) return;
			decimal tot = CfgFn.GetNoNullDecimal(Unfiltered.ExtendedProperties["TotaleImporto"]);
			if (tot==0) {
				R["!percentuale"]="-";
				return;
			}
			decimal perc= CfgFn.GetNoNullDecimal(R["amount"])/tot;
			R["!percentuale"]= perc.ToString("p");
		}

		public override void SetEntityDetail(DataRow SourceRow) {
			DS.Tables["admpay_expensesorted"].ExtendedProperties["importototale"]= 
				SourceRow.Table.ExtendedProperties["importototale"];
			DS.Tables["admpay_expensesorted"].ExtendedProperties["importoresiduo"]= 
				SourceRow.Table.ExtendedProperties["importoresiduo"];
            DS.Tables["admpay_expensesorted"].ExtendedProperties["CustomParentRelation"] =
                SourceRow.Table.ExtendedProperties["CustomParentRelation"];
			CopyCustomFilter(SourceRow);
		}

		void CopyCustomFilter(DataRow SourceRow){
			if (SourceRow.Table.ExtendedProperties["ExtraParams"]==null) return;
            DataRow parent = SourceRow.GetParentRow("sortingadmpay_expensesorted");
            if (parent == null) return;
            string filter = QHC.CmpEq("!idsorkind", parent["idsorkind"]);
			DataTable OldTable = 
				(DataTable) SourceRow.Table.ExtendedProperties[MetaData.ExtraParams];
			DataTable newTable = OldTable.Clone();
			DataRow []selected = OldTable.Select(filter);
			foreach(DataRow R in selected){
				DataRow newR= newTable.NewRow();
				foreach(DataColumn C in newTable.Columns){
					newR[C]= R[C.ColumnName];
				}
				newTable.Rows.Add(newR);
				newR.AcceptChanges();
			}
			PrimaryDataTable.ExtendedProperties[MetaData.ExtraParams]= newTable;
		}
	}
}
