
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

namespace meta_invoiceadditionalfields {
	public class Meta_invoiceadditionalfields : Meta_easydata {
		public Meta_invoiceadditionalfields(DataAccess Conn, MetaDataDispatcher Dispatcher) :
			base(Conn, Dispatcher, "invoiceadditionalfields") {
			EditTypes.Add("detail");
			ListingTypes.Add("detail");
			Name = "Campi aggiuntivi fattura";
		}

		protected override Form GetForm(string FormName) {
			if (FormName == "detail") {
				DefaultListType = "detail";
				Name = "Campi Aggiuntivi Fattura";
				return GetFormByDllName("invoiceadditionalfields_detail");
			}
			return null;
		}
		public override string GetFilterForSearch(DataTable T) {
			return null;
		}

		public override void DescribeColumns(DataTable T, string ListingType) {
			base.DescribeColumns(T, ListingType);
			if (ListingType == "detail") {
				foreach (DataColumn C in T.Columns) {
					DescribeAColumn(T, C.ColumnName, "", -1);
				}
				int nPos = 1;
				DescribeAColumn(T, "documentkind", "Tipo documento", nPos++);
				DescribeAColumn(T, "idadditionalfields", "#", nPos++);
				DescribeAColumn(T, "labelfield1int","Campo", nPos++);
				DescribeAColumn(T, "valuefield1int","Valore", nPos++);

				DescribeAColumn(T, "labelfield1str", "Campo", nPos++);
				DescribeAColumn(T, "valuefield1str", "Valore", nPos++);
				DescribeAColumn(T, "labelfield1date", "Campo", nPos++);
				DescribeAColumn(T, "valuefield1date", "Valore", nPos++);

				DescribeAColumn(T, "labelfield2str", "Campo", nPos++);
				DescribeAColumn(T, "valuefield2str", "Valore", nPos++);
				DescribeAColumn(T, "labelfield3str", "Campo", nPos++);
				DescribeAColumn(T, "valuefield3str", "Valore", nPos++);
				DescribeAColumn(T, "labelfield4str", "Campo", nPos++);
				DescribeAColumn(T, "valuefield4str", "Valore", nPos++);
				DescribeAColumn(T, "labelfield5str", "Campo", nPos++);
				DescribeAColumn(T, "valuefield5str", "Valore", nPos++);
			}

		}

		public override void SetDefaults(DataTable PrimaryTable) {
			base.SetDefaults(PrimaryTable);
		}

		public override DataRow Get_New_Row(DataRow ParentRow, DataTable T) {
			RowChange.SetSelector(T, "idinvkind");
			RowChange.SetSelector(T, "yinv");
			RowChange.SetSelector(T, "ninv");
			RowChange.MarkAsAutoincrement(T.Columns["idadditionalfields"], null, null, 6);
			RowChange.setMinimumTempValue(T.Columns["idadditionalfields"], 10000);
			DataRow R = base.Get_New_Row(ParentRow, T);

			return R;
		}

		public override DataRow SelectOne(string ListingType, string filter, string searchtable, DataTable Exclude) {
		
			return base.SelectOne(ListingType, filter, "invoiceadditionalfields", Exclude);
		}
	}
}
