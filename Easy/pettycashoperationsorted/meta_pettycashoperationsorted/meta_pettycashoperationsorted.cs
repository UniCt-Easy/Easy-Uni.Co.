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
using System.Windows.Forms;
using System.Data;
using metaeasylibrary;
using metadatalibrary;
using funzioni_configurazione;

namespace meta_pettycashoperationsorted
{
	/// <summary>
	/// Summary description for Meta_pettycashoperationsorted.
	/// </summary>
	public class Meta_pettycashoperationsorted : Meta_easydata {
		public Meta_pettycashoperationsorted(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "pettycashoperationsorted") {
			EditTypes.Add("default");
			ListingTypes.Add("default");
		}

		protected override Form GetForm(string FormName) {
			// if (FormName=="default") return new frmClassGerarchica();
			if (FormName=="default") {
				Name = "Classificazione Operazione Fondo Economale";
				return MetaData.GetFormByDllName("pettycashoperationsorted_default");
			}
			return null;
		}			
		
		public override void SetEntityDetail(DataRow SourceRow) {
			DS.Tables["pettycashoperationsorted"].ExtendedProperties["importototale"]= 
				SourceRow.Table.ExtendedProperties["importototale"];
			DS.Tables["pettycashoperationsorted"].ExtendedProperties["importoresiduo"]= 
				SourceRow.Table.ExtendedProperties["importoresiduo"];
            DS.Tables["pettycashoperationsorted"].ExtendedProperties["CustomParentRelation"] =
                SourceRow.Table.ExtendedProperties["CustomParentRelation"];
			CopyCustomFilter(SourceRow);
		}   

		public override void CalculateFields(System.Data.DataRow R, string listtype) {
			DataTable Unfiltered= (DataTable) R.Table.ExtendedProperties["UnfilteredTable"];
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
		


		public override void DescribeColumns(DataTable T, string ListingType) {
			base.DescribeColumns(T, ListingType);
			if (ListingType=="default") {
				foreach(DataColumn C in T.Columns) {
					DescribeAColumn(T, C.ColumnName, "");
				}
                int nPos = 1;
				DescribeAColumn(T,"idsubclass","#", nPos++);
                DescribeAColumn(T, "!idsorkind", "", "sorting.idsorkind");
                DescribeAColumn(T, "!codiceclass", "Codice", "sorting.sortcode", nPos++);
                DescribeAColumn(T, "!descrizione", "Descrizione", "sorting.description", nPos++);
                DescribeAColumn(T, "!percentuale", "%", "", nPos++);
				for (int i = 1; i <= 5; i++) {
					DescribeAColumn(T, "valuen" + i.ToString(), "", nPos++);
					DescribeAColumn(T, "values" + i.ToString(), "", nPos++);
					DescribeAColumn(T, "valuev" + i.ToString(), "", nPos++);
				}
				DescribeAColumn(T, "amount", "Importo", nPos++);
				ComputeRowsAs(T,"default");
			}
		}
		
		void CopyCustomFilter(DataRow SourceRow){
			if (SourceRow.Table.ExtendedProperties["ExtraParams"]==null) return;
            DataRow parent = SourceRow.GetParentRow("sortingpettycashoperationsorted");
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

		public override DataRow Get_New_Row(DataRow ParentRow, DataTable T) {
			RowChange.MarkAsAutoincrement(
				T.Columns["idsubclass"], 
				null,
				null,
				7,
				false);
			RowChange.SetSelector(T, "idpettycash");
			RowChange.SetSelector(T, "yoperation");
			RowChange.SetSelector(T, "noperation");
            //RowChange.SetSelector(T, "idsorkind");
			RowChange.SetSelector(T, "idsor");
			return base.Get_New_Row (ParentRow, T);
		}
	}
}
